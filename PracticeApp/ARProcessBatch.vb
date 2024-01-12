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
Public Class ARProcessBatch
    Inherits System.Windows.Forms.Form

    Dim DropShipPONumber, ReceiverNumber, NextBillingNumber, ConsignmentBillingNumber, CountLineNumber, InvoiceLine, UpdateLines, counter, LastBatchNumber, NextBatchNumber, LastGLNumber, NextGLNumber, LastLineGLNumber, NextLineGLNumber As Integer
    Dim PreferredVendor, VendorClass, InvoiceStatus, PartDescription, BatchStatus, FOB, FOBName, CustomerClass, PartNumber, ItemClass, BatchDescription, CreditGLAccount, DebitGLAccount, RevenueGLAccount, COSGLAccount As String
    Dim UnitCOS, LineFreight, LineSalesTax, ExtendedCOSPositive, ExtendedAmountPositive, SalesTaxPositive, BilledFreightPositive, LineCost, ExtendedAmount, BatchAmount, UndistributedAmount, UpdateTotals As Double
    Dim BatchDate, InvoiceDate As Date
    Dim CheckForReturns As Integer = 0
    Dim strCheckForReturns As String = ""
    Dim OpenBatches As Integer = 0
    Dim strOpenBatches As String = ""
    Dim SUMSerialCost As Double = 0
    Dim SerialInvoiceNumber As Integer = 0
    Dim SerialStatus As String = ""

    'FIFO Variables
    Dim SumInvoiceCOS, QuantityShipped, LineItemCost, ExtendedCOS, SUMCOS, FIFOCost, FIFOExtendedAmount, Price As Double

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isloaded As Boolean = False
    Dim lastBatch As String = ""
    Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\TransferData\UploadedPickTickets")

    Private Sub ARProcessBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" And GlobalARDivisionCode = "" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        ElseIf EmployeeCompanyCode = "ADM" And GlobalARDivisionCode <> "" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = GlobalARDivisionCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If GlobalARBatchNumber > 0 Then
            cboBatchNumber.Text = GlobalARBatchNumber
        Else
            cboBatchNumber.SelectedIndex = -1
        End If

        isloaded = True
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

    Public Sub ShowBatchLines()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID ORDER BY CustomerID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderTable")
        dgvInvoiceHeaders.DataSource = ds.Tables("InvoiceHeaderTable")
        dgvInvoiceHeaders.Columns(7).DefaultCellStyle.Format = "N3"
        con.Close()
        ColorLines()
    End Sub

    Private Sub ColorLines()
        For Each rw As DataGridViewRow In dgvInvoiceHeaders.Rows
            If Not IsDBNull(rw.Cells("ShipmentNumberColumn").Value) AndAlso Val(rw.Cells("ShipmentNumberColumn").Value) <> 0 Then
                cmd = New SqlCommand("SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.Int).Value = rw.Cells("ShipmentNumberColumn").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd.ExecuteScalar()
                con.Close()
                If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                    If CType(obj, Integer) > 0 Then
                        If dir.GetFiles(rw.Cells("ShipmentNumberColumn").Value.ToString + ".pdf").Length = 0 Then
                            rw.DefaultCellStyle.BackColor = Color.LightCoral
                        Else
                            rw.DefaultCellStyle.BackColor = dgvInvoiceHeaders.DefaultCellStyle.BackColor
                        End If
                    Else
                        rw.DefaultCellStyle.BackColor = dgvInvoiceHeaders.DefaultCellStyle.BackColor
                    End If
                Else
                    rw.DefaultCellStyle.BackColor = dgvInvoiceHeaders.DefaultCellStyle.BackColor
                End If
            Else
                rw.DefaultCellStyle.BackColor = dgvInvoiceHeaders.DefaultCellStyle.BackColor
            End If
        Next
    End Sub

    Public Sub ClearBatchLines()
        dgvInvoiceHeaders.DataSource = Nothing
    End Sub

    Public Sub LoadBatchNumber()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT BatchNumber FROM InvoiceProcessingBatchHeader WHERE DivisionID = @DivisionID AND BatchStatus <> @BatchStatus AND BatchDescription <> @BatchDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@BatchDescription", SqlDbType.VarChar).Value = "BILL ONLY INVOICE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "InvoiceProcessingBatchHeader")
        cboBatchNumber.DataSource = ds1.Tables("InvoiceProcessingBatchHeader")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadInvoiceNumber()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber ORDER BY InvoiceNumber ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "InvoiceHeaderTable")
        cboInvoiceNumber.DataSource = ds2.Tables("InvoiceHeaderTable")
        con.Close()
        cboInvoiceNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowSerialLines()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM InvoiceLineSerialNumberQuery WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = SerialInvoiceNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "InvoiceLineSerialNumberQuery")
        dgvInvoiceSerialLines.DataSource = ds3.Tables("InvoiceLineSerialNumberQuery")
        con.Close()
    End Sub

    Public Sub ClearSerialLines()
        dgvInvoiceSerialLines.DataSource = Nothing
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isloaded Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If

        'Load defaults
        LoadBatchNumber()
        ClearBatch()
        ClearBatchLines()

        CheckPendingReturns()
        CheckOpenBatches()
        CheckOpenBillOnly()

        cmdGenerateBatchNumber.Focus()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

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

    Public Sub LoadBatchInfo()
        'Load the Batch Totals
        Dim BatchDateStatement As String = "SELECT BatchDate FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchDateCommand As New SqlCommand(BatchDateStatement, con)
        BatchDateCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchAmountStatement As String = "SELECT BatchAmount FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchAmountCommand As New SqlCommand(BatchAmountStatement, con)
        BatchAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchDescriptionStatement As String = "SELECT BatchDescription FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchDescriptionCommand As New SqlCommand(BatchDescriptionStatement, con)
        BatchDescriptionCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchDate = CDate(BatchDateCommand.ExecuteScalar)
        Catch ex As Exception
            BatchDate = dtpBatchCreationDate.Value
        End Try
        Try
            BatchAmount = CDbl(BatchAmountCommand.ExecuteScalar)
        Catch ex As Exception
            BatchAmount = 0
        End Try
        Try
            BatchDescription = CStr(BatchDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            BatchDescription = "AR INVOICE PROCESSING"
        End Try
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = "OPEN"
        End Try
        con.Close()

        If BatchDescription = "" Then
            BatchDescription = "AR INVOICE PROCESSING"
        End If

        If BatchStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdSelectReturns.Enabled = False
            cmdPostBatch.Enabled = False
            cmdEditInvoices.Enabled = False
            cmdSave.Enabled = False
            cmdSelectShipments.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdSelectReturns.Enabled = True
            cmdPostBatch.Enabled = True
            cmdEditInvoices.Enabled = True
            cmdSave.Enabled = True
            cmdSelectShipments.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
        End If

        dtpBatchCreationDate.Text = BatchDate
        txtBatchTotal.Text = BatchAmount
        txtBatchDescription.Text = BatchDescription
        txtBatchStatus.Text = BatchStatus
    End Sub

    Public Sub CheckPendingReturns()
        Dim CheckForReturnsStatement As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductHeaderTable WHERE ReturnStatus = @ReturnStatus AND DivisionID = @DivisionID"
        Dim CheckForReturnsCommand As New SqlCommand(CheckForReturnsStatement, con)
        CheckForReturnsCommand.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "PENDING"
        CheckForReturnsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckForReturns = CInt(CheckForReturnsCommand.ExecuteScalar)
        Catch ex As Exception
            CheckForReturns = 0
        End Try
        con.Close()

        If CheckForReturns = 1 Then
            lblPendingReturns.Visible = True
            lblPendingReturns.Text = "There is 1 Return ready to be processed for credit."
        ElseIf CheckForReturns > 1 Then
            lblPendingReturns.Visible = True
            strCheckForReturns = CStr(CheckForReturns)
            lblPendingReturns.Text = "There are " + strCheckForReturns + " Returns ready to be processed for credit."
        Else
            lblPendingReturns.Visible = False
        End If
    End Sub

    Public Sub CheckOpenBatches()
        Dim OpenBatchesStatement As String = "SELECT COUNT(BatchNumber) FROM InvoiceProcessingBatchHeader WHERE BatchStatus = @BatchStatus AND DivisionID = @DivisionID AND BatchDescription <> @BatchDescription"
        Dim OpenBatchesCommand As New SqlCommand(OpenBatchesStatement, con)
        OpenBatchesCommand.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        OpenBatchesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        OpenBatchesCommand.Parameters.Add("@BatchDescription", SqlDbType.VarChar).Value = "BILL ONLY INVOICE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OpenBatches = CInt(OpenBatchesCommand.ExecuteScalar)
        Catch ex As Exception
            OpenBatches = 0
        End Try
        con.Close()

        If OpenBatches = 1 Then
            lblOpenBatches.Visible = True
            lblOpenBatches.Text = "There is 1 Open Batch ready to be processed."
        ElseIf OpenBatches > 1 Then
            lblOpenBatches.Visible = True
            strOpenBatches = CStr(OpenBatches)
            lblOpenBatches.Text = "There are " + strOpenBatches + " Open Batches ready to be processed."
        Else
            lblOpenBatches.Visible = False
        End If
    End Sub

    Public Sub CheckOpenBillOnly()
        Dim OpenBatchesStatement As String = "SELECT COUNT(BatchNumber) FROM InvoiceProcessingBatchHeader WHERE BatchStatus = @BatchStatus AND DivisionID = @DivisionID AND BatchDescription = @BatchDescription"
        Dim OpenBatchesCommand As New SqlCommand(OpenBatchesStatement, con)
        OpenBatchesCommand.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        OpenBatchesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        OpenBatchesCommand.Parameters.Add("@BatchDescription", SqlDbType.VarChar).Value = "BILL ONLY INVOICE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OpenBatches = CInt(OpenBatchesCommand.ExecuteScalar)
        Catch ex As Exception
            OpenBatches = 0
        End Try
        con.Close()

        If OpenBatches = 1 Then
            lblOpenBillOnly.Visible = True
            lblOpenBillOnly.Text = "There is 1 Bill Only Invoice ready to be processed."
        ElseIf OpenBatches > 1 Then
            lblOpenBillOnly.Visible = True
            strOpenBatches = CStr(OpenBatches)
            lblOpenBillOnly.Text = "There are " + strOpenBatches + " Bill Only Invoices ready to be processed."
        Else
            lblOpenBillOnly.Visible = False
        End If
    End Sub

    Public Sub ClearBatch()
        cboBatchNumber.Text = ""
        cboInvoiceNumber.Text = ""

        txtBatchDescription.Refresh()
        txtBatchTotal.Refresh()
        txtCurrentTotal.Refresh()
        txtEntryNumber.Refresh()
        txtUndistributedAmount.Refresh()

        cboBatchNumber.Refresh()
        cboInvoiceNumber.Refresh()
        cboDay.Refresh()
        cboTime.Refresh()

        cboBatchNumber.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1
        cboDay.SelectedIndex = -1
        cboTime.SelectedIndex = -1

        dtpBatchCreationDate.Text = ""

        txtBatchTotal.Clear()
        txtCurrentTotal.Clear()
        txtUndistributedAmount.Clear()
        txtEntryNumber.Clear()

        cmdGenerateBatchNumber.Focus()

        cmdDelete.Enabled = True
        cmdSelectReturns.Enabled = True
        cmdPostBatch.Enabled = True
        cmdEditInvoices.Enabled = True
        cmdSave.Enabled = True
        cmdSelectShipments.Enabled = True
        SaveBatchToolStripMenuItem.Enabled = True
        DeleteBatchToolStripMenuItem.Enabled = True

        CheckPendingReturns()
        CheckOpenBatches()
    End Sub

    Public Sub ClearVariables()
        NextBillingNumber = 0
        ConsignmentBillingNumber = 0
        CountLineNumber = 0
        InvoiceLine = 0
        UpdateLines = 0
        counter = 0
        LastBatchNumber = 0
        NextBatchNumber = 0
        LastGLNumber = 0
        NextGLNumber = 0
        LastLineGLNumber = 0
        NextLineGLNumber = 0
        PartDescription = ""
        BatchStatus = ""
        CustomerClass = ""
        PartNumber = ""
        ItemClass = ""
        BatchDescription = ""
        CreditGLAccount = ""
        DebitGLAccount = ""
        RevenueGLAccount = ""
        COSGLAccount = ""
        LineCost = 0
        ExtendedAmount = 0
        BatchAmount = 0
        UndistributedAmount = 0
        UpdateTotals = 0
        SUMCOS = 0
        FIFOCost = 0
        FIFOExtendedAmount = 0
        Price = 0
        QuantityShipped = 0
        GlobalARBatchNumber = 0
        ReceiverNumber = 0
        ExtendedCOS = 0
        LineItemCost = 0
        DropShipPONumber = 0
        InvoiceStatus = ""
        ExtendedCOSPositive = 0
        LineFreight = 0
        LineSalesTax = 0
        PreferredVendor = ""
        VendorClass = ""
        SumInvoiceCOS = 0
        lastBatch = ""
        FOBName = ""
        FOB = ""
        SerialInvoiceNumber = 0
        UnitCOS = 0
    End Sub

    Public Sub LoadTotals()
        'UPDATE TOTALS AND DISTRIBUTABLE AMOUNT
        Dim BatchAmountStatement As String = "SELECT BatchAmount FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchAmountCommand As New SqlCommand(BatchAmountStatement, con)
        BatchAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim UpdateTotalsStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim UpdateTotalsCommand As New SqlCommand(UpdateTotalsStatement, con)
        UpdateTotalsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        UpdateTotalsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim UpdateLinesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim UpdateLinesCommand As New SqlCommand(UpdateLinesStatement, con)
        UpdateLinesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        UpdateLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchAmount = CDbl(BatchAmountCommand.ExecuteScalar)
        Catch ex As Exception
            BatchAmount = Val(txtBatchTotal.Text)
        End Try
        Try
            UpdateTotals = CDbl(UpdateTotalsCommand.ExecuteScalar)
        Catch ex As Exception
            UpdateTotals = 0
        End Try
        Try
            UpdateLines = CInt(UpdateLinesCommand.ExecuteScalar)
        Catch ex As Exception
            UpdateLines = 0
        End Try
        con.Close()

        'UPDATE Distributable Totals
        UndistributedAmount = BatchAmount - UpdateTotals
        txtBatchTotal.Text = BatchAmount
        txtCurrentTotal.Text = UpdateTotals
        txtUndistributedAmount.Text = UndistributedAmount
        txtEntryNumber.Text = UpdateLines
    End Sub

    Private Sub cmdGenerateBatchNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateBatchNumber.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If

        cboBatchNumber.Text = ""
        isloaded = False
        ClearVariables()
        ClearBatch()
        ShowBatchLines()
        isloaded = True

        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a specific division to process invoices.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Find the next Batch Number to use
        Dim MAXStatement As String = "SELECT MAX(BatchNumber) FROM InvoiceProcessingBatchHeader"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 2200000
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1
        cboBatchNumber.Text = NextBatchNumber

        BatchDate = dtpBatchCreationDate.Value

        Try
            'Write Data to Batch Header Database Table
            cmd = New SqlCommand("Insert Into InvoiceProcessingBatchHeader(BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, UserID, Locked)Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @UserID, @UserID)", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Generate Batch Number --- Insert new AR batch"
            ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        lastBatch = cboBatchNumber.Text
    End Sub

    Private Sub cmdSelectShipments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectShipments.Click
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a specific division to process invoices.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must select or create a valid Batch Number to select Shipments for invoicing.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If isSomeoneEditing() Then
            Exit Sub
        End If

        BatchDate = dtpBatchCreationDate.Value

        'Determine Batch Status for saving
        Dim CheckBatchDivision As String = ""

        Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckBatchDivisionStatement As String = "SELECT DivisionID FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber"
        Dim CheckBatchDivisionCommand As New SqlCommand(CheckBatchDivisionStatement, con)
        CheckBatchDivisionCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = "OPEN"
        End Try
        Try
            CheckBatchDivision = CStr(CheckBatchDivisionCommand.ExecuteScalar)
        Catch ex As Exception
            CheckBatchDivision = ""
        End Try
        con.Close()

        If CheckBatchDivision <> cboDivisionID.Text Then
            MsgBox("Current division does not match the division saved for this batch.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If BatchStatus = "OPEN" Then
            Try
                'Save Data to Batch Header Database Table
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, UserID = @UserID, Locked = @UserID WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error check
            End Try

            GlobalARBatchNumber = Val(cboBatchNumber.Text)
            GlobalARBatchDate = dtpBatchCreationDate.Value
            GlobalDivisionCode = cboDivisionID.Text
            GlobalARDivisionCode = cboDivisionID.Text

            Dim NewSelectShipmentsForInvoicing As New SelectShipmentsForInvoicing
            NewSelectShipmentsForInvoicing.Show()

            isloaded = False

            Me.Dispose()
            Me.Close()
        Else
            MsgBox("Batch is not open.", MsgBoxStyle.OkOnly)

            'GlobalARBatchNumber = Val(cboBatchNumber.Text)
            'GlobalARBatchDate = dtpBatchCreationDate.Value
            'GlobalDivisionCode = cboDivisionID.Text
            'GlobalARDivisionCode = cboDivisionID.Text

            'Dim NewSelectShipmentsForInvoicing As New SelectShipmentsForInvoicing
            'NewSelectShipmentsForInvoicing.Show()

            'isloaded = False

            'Me.Dispose()
            'Me.Close()
        End If
    End Sub

    Private Sub cmdEditInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditInvoices.Click
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a specific division to process invoices.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must select or create a valid Batch Number to Edit Invoices.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        'Determine Batch Status for saving
        Dim CheckBatchDivision As String = ""

        Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckBatchDivisionStatement As String = "SELECT DivisionID FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber"
        Dim CheckBatchDivisionCommand As New SqlCommand(CheckBatchDivisionStatement, con)
        CheckBatchDivisionCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = "OPEN"
        End Try
        Try
            CheckBatchDivision = CStr(CheckBatchDivisionCommand.ExecuteScalar)
        Catch ex As Exception
            CheckBatchDivision = ""
        End Try
        con.Close()

        If CheckBatchDivision <> cboDivisionID.Text Then
            MsgBox("Current division does not match the division saved for this batch.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If BatchStatus <> "OPEN" Then
            MsgBox("Batch is not open.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

            BatchDate = dtpBatchCreationDate.Value

        If Not isSomeoneEditing() Then
            Try
                'Save Data to Batch Header Database Table
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, UserID = @UserID, Locked = @UserID WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error log
            End Try
        End If

        GlobalARBatchNumber = Val(cboBatchNumber.Text)
        GlobalARBatchDate = dtpBatchCreationDate.Value
        GlobalARDivisionCode = cboDivisionID.Text

        Dim NewInvoicingForm As New InvoicingForm
        NewInvoicingForm.Show()

        isloaded = False

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClearBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearBatch.Click
        unlockBatch()
        isloaded = False
        ClearVariables()
        ClearBatch()
        ShowBatchLines()
        lastBatch = ""
        isloaded = True
    End Sub

    Private Sub cmdSelectReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectReturns.Click
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a specific division to process invoices.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must select or create a valid Batch Number to select Shipments for invoicing.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If isSomeoneEditing() Then
            Exit Sub
        End If

            BatchDate = dtpBatchCreationDate.Value

        'Determine Batch Status for saving
        Dim CheckBatchDivision As String = ""

        Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckBatchDivisionStatement As String = "SELECT DivisionID FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber"
        Dim CheckBatchDivisionCommand As New SqlCommand(CheckBatchDivisionStatement, con)
        CheckBatchDivisionCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = "OPEN"
        End Try
        Try
            CheckBatchDivision = CStr(CheckBatchDivisionCommand.ExecuteScalar)
        Catch ex As Exception
            CheckBatchDivision = ""
        End Try
        con.Close()

        If CheckBatchDivision <> cboDivisionID.Text Then
            MsgBox("Current division does not match the division saved for this batch.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If BatchStatus = "OPEN" Then
            Try
                'Save Data to Batch Header Database Table
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, UserID = @UserID, Locked = @UserID WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error check
            End Try

            GlobalARBatchNumber = Val(cboBatchNumber.Text)
            GlobalDivisionCode = cboDivisionID.Text
            GlobalARDivisionCode = cboDivisionID.Text

            Dim NewSelectCustomerReturnsForCredit As New SelectCustomerReturnsForCredit
            NewSelectCustomerReturnsForCredit.Show()

            isloaded = False

            Me.Dispose()
            Me.Close()
        Else
            MsgBox("Batch is not open.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cboBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBatchNumber.SelectedIndexChanged
        If isloaded Then
            unlockBatch(lastBatch)
        End If
        LoadBatchInfo()
        LoadInvoiceNumber()
        LoadTotals()
        ShowBatchLines()
        lastBatch = cboBatchNumber.Text
    End Sub

    Private Sub ClearBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBatchToolStripMenuItem.Click
        unlockBatch()
        isloaded = False
        ClearVariables()
        ClearBatch()
        ShowBatchLines()
        lastBatch = ""
        isloaded = True
    End Sub

    Private Sub PrintBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBatchToolStripMenuItem.Click
        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            BatchDate = dtpBatchCreationDate.Value

            'Determine Batch Status for saving
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "OPEN"
            End Try
            con.Close()

            If BatchStatus = "OPEN" Then
                If Not isSomeoneEditing() Then
                    Try
                        'Save Data to Batch Header Database Table
                        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, UserID = @UserID, Locked = @UserID WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                            .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                    End Try
                End If

                'Determine which invoice form to use - US/CANADA
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalARBatchNumber = Val(cboBatchNumber.Text)
                    Using NewPrintInvoiceBatch As New PrintInvoiceBatch
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                Else
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalARBatchNumber = Val(cboBatchNumber.Text)
                    Using NewPrintInvoiceBatch As New PrintInvoiceBatch
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                End If
            Else
                'Determine which invoice form to use - US/CANADA
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalARBatchNumber = Val(cboBatchNumber.Text)
                    Using NewPrintInvoiceBatch As New PrintInvoiceBatch
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                Else
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalARBatchNumber = Val(cboBatchNumber.Text)
                    Using NewPrintInvoiceBatch As New PrintInvoiceBatch
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a specific division to print invoices.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            BatchDate = dtpBatchCreationDate.Value
   
            'Determine Batch Status for saving
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "OPEN"
            End Try
            con.Close()

            If BatchStatus = "OPEN" Then
                If Not isSomeoneEditing() Then
                    Try
                        'Save Data to Batch Header Database Table
                        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, UserID = @UserID, Locked = @UserID WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                            .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                    End Try
                End If

                GlobalDivisionCode = cboDivisionID.Text
                GlobalARBatchNumber = Val(cboBatchNumber.Text)

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
                    Using NewPrintInvoiceBatchRemote As New PrintInvoiceBatchRemote
                        Dim result = NewPrintInvoiceBatchRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBatch As New PrintInvoiceBatch
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub cmdPrintCerts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCerts.Click
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a specific division to print certs.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim button As DialogResult = MessageBox.Show("Do you wish to print all of the certs for these Invoices?", "PRINT CERTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                BatchDate = dtpBatchCreationDate.Value
           
                'Determine Batch Status for saving
                Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
                BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    BatchStatus = "OPEN"
                End Try
                con.Close()

                If BatchStatus = "OPEN" Then
                    If Not isSomeoneEditing() Then
                        Try
                            'Save Data to Batch Header Database Table
                            cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, UserID = @UserID WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error Log
                        End Try
                    End If

                    'Select Shipment Number for each invoice and auto-print all of the certs
                    Dim InvoiceShipmentNumber As Integer

                    For Each row As DataGridViewRow In dgvInvoiceHeaders.Rows
                        'Error check to ensure no NULL Values
                        Try
                            InvoiceShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                        Catch ex As System.Exception
                            InvoiceShipmentNumber = 0
                        End Try

                        If InvoiceShipmentNumber = 0 Then
                            'skip - no certs
                        Else
                            GlobalShipmentNumber = InvoiceShipmentNumber

                            Using NewPrintInvoiceCerts As New PrintInvoiceCerts
                                Dim result = NewPrintInvoiceCerts.ShowDialog()
                            End Using
                        End If
                    Next
                Else
                    'Select Shipment Number for each invoice and auto-print all of the certs
                    Dim InvoiceShipmentNumber As Integer

                    For Each row As DataGridViewRow In dgvInvoiceHeaders.Rows
                        'Error check to ensure no NULL Values
                        Try
                            InvoiceShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                        Catch ex As System.Exception
                            InvoiceShipmentNumber = 0
                        End Try

                        If InvoiceShipmentNumber = 0 Then
                            'skip - no certs
                        Else
                            GlobalShipmentNumber = InvoiceShipmentNumber

                            Using NewPrintInvoiceCerts As New PrintInvoiceCerts
                                Dim result = NewPrintInvoiceCerts.ShowDialog()
                            End Using
                        End If
                    Next
                End If
            ElseIf button = DialogResult.Yes Then
                cmdPrintCerts.Focus()
        End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Save batch and verify valid Batch Number
        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You need a valid Batch Number to save this batch.", MsgBoxStyle.OkOnly)
        Else
            If cboDivisionID.Text = "ADM" Then
                MsgBox("You must select a valid division to save this batch", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Determine Batch Status for saving
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "OPEN"
            End Try
            con.Close()

            'Calculate Batch Total from Invoices
            LoadTotals()

            If BatchStatus = "OPEN" Then
                If isSomeoneEditing() Then
                    Exit Sub
                End If

                'Command to update Batch Total in Batch
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount, Locked = @Locked WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = UpdateTotals
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Reload Totals after update
                LoadTotals()

                BatchDate = dtpBatchCreationDate.Value
         
                Try
                    'Save Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                End Try

                MsgBox("Batch has been saved.", MsgBoxStyle.OkOnly)
                cmdSave.Focus()
            Else
                MsgBox("Batch cannot be saved - it has been posted.", MsgBoxStyle.OkOnly)
        End If
        End If
    End Sub

    Private Sub SaveBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBatchToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub cmdPostBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostBatch.Click
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a specific division to post invoices.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Save batch and verify valid Batch Number
        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You need a valid Batch Number to POST this batch.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If isSomeoneEditing() Then
            Exit Sub
        End If
        '******************************************************************************************************************************************************
        Dim button As DialogResult = MessageBox.Show("Do you wish to POST this Invoice Batch?", "POST BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Check Batch Status
            Dim CheckInvoiceNumber As Integer = 0
            Dim SumInvoiceNumber As Integer = 0
            Dim InvoiceExists As String = ""
            Dim ShipmentExists As String = ""
            Dim PostDivision As String = ""

            If cboDivisionID.Text = "TFP" Then
                PostDivision = "TWD"
            Else
                PostDivision = cboDivisionID.Text
            End If

            'Validate before posting
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = ""
            End Try
            con.Close()

            If BatchStatus = "POSTED" Then
                MsgBox("This batch has been posted. Contact system admin.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '******************************************************************************************************************************************************
            'Check all Invoice Numbers to see if any or all have posted.
            'Check all invoices and see if there are multiple invoices for one shipment
            'Also check Invoice Dates and make sure none are from a prior Fiscal Period
            '******************************************************************************************************************************************************
            For Each row As DataGridViewRow In dgvInvoiceHeaders.Rows
                Dim CheckInvoiceDate As Date
                Dim CheckShipmentNumber As Integer = 0
                Dim CheckCustomerClass As String = ""
                Dim CheckCustomerID As String = ""
                Dim GetCustomerClass As String = ""

                Try
                    CheckInvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                Catch ex As Exception
                    CheckInvoiceNumber = 0
                End Try
                Try
                    CheckShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                Catch ex As Exception
                    CheckShipmentNumber = 0
                End Try
                Try
                    CheckInvoiceDate = row.Cells("InvoiceDateColumn").Value
                Catch ex As Exception
                    CheckInvoiceDate = dtpBatchCreationDate.Value
                End Try
                Try
                    CheckCustomerClass = row.Cells("CustomerClassColumn").Value
                Catch ex As Exception
                    CheckCustomerClass = "STANDARD"
                End Try
                Try
                    CheckCustomerID = row.Cells("CustomerIDColumn").Value
                Catch ex As Exception
                    CheckCustomerID = ""
                End Try
                '******************************************************************************************************
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    'Skip Date Validation
                Else
                    ''Validate Date
                    'Dim CurrentDate, TodaysDate As Date
                    'Dim MonthOfYear, YearOfYear, TodaysMonthOfYear, TodaysYearOfYear As Integer

                    'TodaysDate = Today()
                    'CurrentDate = CheckInvoiceDate

                    'MonthOfYear = CurrentDate.Month
                    'YearOfYear = CurrentDate.Year
                    'TodaysMonthOfYear = TodaysDate.Month
                    'TodaysYearOfYear = TodaysDate.Year

                    'If TodaysYearOfYear - YearOfYear > 1 Then
                    '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                    '    Exit Sub
                    'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear < 5 And (TodaysMonthOfYear >= 1 And TodaysMonthOfYear < 5) Then
                    '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                    '    Exit Sub
                    'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear > 5 And (TodaysMonthOfYear >= 5 And TodaysMonthOfYear <= 12) Then
                    '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                    '    Exit Sub
                    'ElseIf TodaysYearOfYear - YearOfYear = 0 And MonthOfYear < 5 And TodaysMonthOfYear >= 5 Then
                    '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                    '    Exit Sub
                    'ElseIf TodaysYearOfYear - YearOfYear < 0 Then
                    '    MsgBox("You cannot post a Return to a future period.", MsgBoxStyle.OkOnly)
                    '    Exit Sub
                    'ElseIf TodaysYearOfYear - YearOfYear = 0 And TodaysMonthOfYear < MonthOfYear Then
                    '    MsgBox("You cannot post a Return to a future period.", MsgBoxStyle.OkOnly)
                    '    Exit Sub
                    'Else
                    '    'Date is okay --- Continue
                    'End If
                End If
                '***********************************************************************************************************
                'Set Division in case of TFP/TWD
                Dim CheckDivision As String = ""

                If cboDivisionID.Text = "TFP" Then
                    CheckDivision = "TWD"
                Else
                    CheckDivision = cboDivisionID.Text
                End If
                '*******************************************************************************************************
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    If CheckCustomerClass = "AMERICAN" Then
                        'Do nothing
                    ElseIf CheckCustomerClass = "CANADIAN" Then
                        'Do nothing
                    ElseIf CheckCustomerClass = "SRL" Then
                        'Do nothing
                    Else
                        Dim GetCustomerClassStatement As String = "SELECT CustomerClass From CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim GetCustomerClassCommand As New SqlCommand(GetCustomerClassStatement, con)
                        GetCustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CheckCustomerID
                        GetCustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetCustomerClass = CStr(GetCustomerClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetCustomerClass = ""
                        End Try
                        con.Close()

                        'Command to update Batch Status
                        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET CustomerClass = @CustomerClass WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = CheckInvoiceNumber
                        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = GetCustomerClass
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Else
                    'Skip
                End If
                '********************************************************************************************************
                Dim SumInvoiceNumberStatement As String = "SELECT COUNT(GLTransactionKey) From GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
                Dim SumInvoiceNumberCommand As New SqlCommand(SumInvoiceNumberStatement, con)
                SumInvoiceNumberCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = CheckInvoiceNumber
                SumInvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumInvoiceNumber = CInt(SumInvoiceNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    SumInvoiceNumber = 0
                End Try
                con.Close()

                If SumInvoiceNumber = 0 Then
                    InvoiceExists = "NO"
                Else
                    InvoiceExists = "YES"
                    'Exit For
                End If
                '************************************************************************************************************
                If InvoiceExists = "YES" Then
                    MsgBox("You cannot post a batch that has been posted. This batch will close.", MsgBoxStyle.OkOnly)
                    Try
                        'Command to update Batch Status
                        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchStatus = @BatchStatus, BatchDescription = @BatchDescription, UserID = @UserID WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                        cmd.Parameters.Add("@BatchDescription", SqlDbType.VarChar).Value = "AUTO-CLOSED"
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Batch auto-closed
                        Dim strBatchNumber As String = ""
                        Dim TempBatchNumber As Integer = 0

                        TempBatchNumber = Val(cboBatchNumber.Text)
                        strBatchNumber = CStr(TempBatchNumber)

                        ErrorDate = Today()
                        ErrorComment = "Batch auto-closed - check GL Postings and re-open batch to re-post"
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Process AR Batch --- Invoice Batch Autoclose"
                        ErrorReferenceNumber = "Batch # " + strBatchNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        ClearVariables()
                        ClearBatch()
                    Catch ex As Exception
                        'Batch auto-closed
                        Dim strBatchNumber As String = ""
                        Dim TempBatchNumber As Integer = 0

                        TempBatchNumber = Val(cboBatchNumber.Text)
                        strBatchNumber = CStr(TempBatchNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Process AR Batch --- Invoice Batch Autoclose Failure"
                        ErrorReferenceNumber = "Batch # " + strBatchNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    'Exit Routine
                    Exit Sub
                End If
            Next
            '************************************************************************************************************
            ' Validation is done proceed with GL Entry

            'Calculate Batch Total from Invoices
            LoadTotals()

            Try
                'Command to update Batch Total in Batch
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount, UserID = @UserID, PrintDate = @PrintDate WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = UpdateTotals
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                cmd.Parameters.Add("@PrintDate", SqlDbType.VarChar).Value = Today()

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Batch total update
                Dim strBatchNumber As String = ""
                Dim TempBatchNumber As Integer = 0

                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Process AR Batch --- Invoice Batch Total Update Failure"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Reload Totals after update
            LoadTotals()

            BatchDate = dtpBatchCreationDate.Value
            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            'Declare variables used in the datagrid
            'Get data from each invoice header in the datagrid
            Dim InvoiceNumber, SalesOrderNumber, ShipmentNumber As Integer
            Dim BilledFreight, SalesTax, SalesTax2, SalesTax3, InvoiceTotal As Double
            Dim CustomerID As String = ""
            Dim TaxAccount, ARAccount, FreightGLAccount As String

            'Extract Line data from the datagrid
            For Each row As DataGridViewRow In dgvInvoiceHeaders.Rows
                'Clear Tax and Freight
                SalesTax = 0
                SalesTax2 = 0
                SalesTax3 = 0
                BilledFreight = 0
                InvoiceTotal = 0
                LineSalesTax = 0
                LineFreight = 0
                InvoiceNumber = 0
                SalesOrderNumber = 0
                ShipmentNumber = 0
                TaxAccount = ""
                ARAccount = ""
                FreightGLAccount = ""

                Try
                    InvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                Catch ex As Exception
                    InvoiceNumber = 0
                End Try
                Try
                    SalesOrderNumber = row.Cells("SalesOrderNumberColumn").Value
                Catch ex As Exception
                    SalesOrderNumber = 0
                End Try
                Try
                    ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                Catch ex As Exception
                    ShipmentNumber = 0
                End Try
                Try
                    BilledFreight = row.Cells("BilledFreightColumn").Value
                Catch ex As Exception
                    BilledFreight = 0
                End Try
                Try
                    SalesTax = row.Cells("SalesTaxColumn").Value
                Catch ex As Exception
                    SalesTax = 0
                End Try
                Try
                    SalesTax2 = row.Cells("SalesTax2Column").Value
                Catch ex As Exception
                    SalesTax2 = 0
                End Try
                Try
                    SalesTax3 = row.Cells("SalesTax3Column").Value
                Catch ex As Exception
                    SalesTax3 = 0
                End Try
                Try
                    CustomerID = row.Cells("CustomerIDColumn").Value
                Catch ex As Exception
                    CustomerID = ""
                End Try
                Try
                    InvoiceDate = row.Cells("InvoiceDateColumn").Value
                Catch ex As Exception
                    InvoiceDate = dtpBatchCreationDate.Value
                End Try
                Try
                    InvoiceTotal = row.Cells("InvoiceTotalColumn").Value
                Catch ex As Exception
                    InvoiceTotal = 0
                End Try
                Try
                    DropShipPONumber = row.Cells("DropShipPONumberColumn").Value
                Catch ex As Exception
                    DropShipPONumber = 0
                End Try
                Try
                    CustomerClass = row.Cells("CustomerClassColumn").Value
                Catch ex As Exception
                    CustomerClass = "STANDARD"
                End Try
                Try
                    FOBName = row.Cells("FOBColumn").Value
                Catch ex As Exception
                    FOBName = ""
                End Try

                'Validate FOB Name and Customer Class
                If FOBName = "MEDINA" Or FOBName = "" Then
                    FOBName = "Medina"
                End If

                If CustomerClass = "" Then
                    CustomerClass = "STANDARD"
                End If

                '***************************************************************************************************************
                'Seven different scenarios for billing
                '#1-- Billing from Consignment to our customer (TWD)
                '#2-- Billing usage from Consignment
                '#3-- Bill Only when shipping to a consigment
                '#4-- Normal Billing procedure - American
                '#5-- Normal Billing procedure - Canadian
                '#6-- Billing Consignment - Canadian
                '#7-- Billing Consignment - Truweld Equipment (Sames as TWD)
                '***************************************************************************************************************

                'Assign FOB ID to FOB Name
                Select Case FOBName
                    Case "Downey", "DCW"
                        FOB = "DCW"
                    Case "Bessemer", "BCW"
                        FOB = "BCW"
                    Case "Phoenix", "PCW"
                        FOB = "PCW"
                    Case "Hayward", "HCW"
                        FOB = "HCW"
                    Case "Lyndhurst", "YCW"
                        FOB = "YCW"
                    Case "Lewisville", "LCW"
                        FOB = "LCW"
                    Case "Seattle", "SCW"
                        FOB = "SCW"
                    Case "Renton", "RCW"
                        FOB = "RCW"
                    Case "Lake Stevens", "LSCW"
                        FOB = "LSCW"
                    Case "SRL"
                        FOB = "SRL"
                    Case "TFF"
                        FOB = "TFF"
                    Case "TOR"
                        FOB = "TOR"
                    Case "ALB"
                        FOB = "ALB"
                    Case "STANDARD"
                        FOB = "STANDARD"
                    Case "TWD"
                        FOB = "Medina"
                    Case Else
                        FOB = "Medina"
                End Select

                'Determine which Billing Routine
                Dim BillingDivision As String = ""
                Dim BillingScenario As String = ""

                BillingDivision = cboDivisionID.Text

                Select Case BillingDivision
                    Case "ATL"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "CBS"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "CGO"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "CHT"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "DEN"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "HOU"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "SLC"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "TFF"
                        If CustomerClass = "AMERICAN" And FOB = "SRL" Then
                            BillingScenario = "ConsignmentCanadian"
                        ElseIf CustomerClass = "AMERICAN" And FOB <> "SRL" Then
                            BillingScenario = "NormalCanadian"
                        ElseIf CustomerClass = "CANADIAN" And FOB = "SRL" Then
                            BillingScenario = "ConsignmentCanadian"
                        ElseIf CustomerClass = "CANADIAN" And FOB <> "SRL" Then
                            BillingScenario = "NormalCanadian"
                        ElseIf CustomerClass = "SRL" And FOB = "STANDARD" Then
                            BillingScenario = "ConsignmentZeroDollar"
                        ElseIf CustomerClass = "SRL" And FOB = "SRL" Then
                            BillingScenario = "NormalCanadian"
                        ElseIf CustomerClass = "SRL" And FOB = "TFF" Then
                            BillingScenario = "NormalCanadian"
                        Else
                            'Error Log
                            Dim strInvoiceNumber As String = ""

                            strInvoiceNumber = CStr(InvoiceNumber)

                            ErrorDate = Today()
                            ErrorComment = "Customer Class - " + CustomerClass
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Process AR Batch --- No billing procedure determined by Customer Class."
                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End If
                    Case "TFP"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "TFJ"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "TFT"
                        'Normal Billing Procedure - American
                        BillingScenario = "NormalAmerican"
                    Case "TOR"
                        If CustomerClass = "AMERICAN" Then
                            BillingScenario = "NormalCanadian"
                        ElseIf CustomerClass = "CANADIAN" Then
                            BillingScenario = "NormalCanadian"
                        Else
                            'Error Log
                            Dim strInvoiceNumber As String = ""

                            strInvoiceNumber = CStr(InvoiceNumber)

                            ErrorDate = Today()
                            ErrorComment = "Customer Class - " + CustomerClass
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Process AR Batch --- No billing procedure determined by Customer Class."
                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End If
                    Case "ALB"
                        If CustomerClass = "AMERICAN" Then
                            BillingScenario = "NormalCanadian"
                        ElseIf CustomerClass = "CANADIAN" Then
                            BillingScenario = "NormalCanadian"
                        Else
                            'Error Log
                            Dim strInvoiceNumber As String = ""

                            strInvoiceNumber = CStr(InvoiceNumber)

                            ErrorDate = Today()
                            ErrorComment = "Customer Class - " + CustomerClass
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Process AR Batch --- No billing procedure determined by Customer Class."
                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End If
                    Case "TWD"
                        If CustomerClass = "STANDARD" And FOB <> "Medina" Then
                            BillingScenario = "ConsignmentUsage"
                        ElseIf CustomerClass = "STANDARD" And FOB = "Medina" Then
                            BillingScenario = "NormalAmerican"
                        ElseIf CustomerClass <> "STANDARD" And FOB = "Medina" Then
                            BillingScenario = "ConsignmentZeroDollar"
                        ElseIf CustomerClass <> "STANDARD" And FOB <> "Medina" Then
                            BillingScenario = "ConsignmentUsage"
                        Else
                            BillingScenario = "NormalAmerican"
                        End If
                    Case "TWE"
                        If CustomerClass = "STANDARD" And FOB <> "Medina" Then
                            BillingScenario = "ConsignmentUsage"
                        ElseIf CustomerClass = "STANDARD" And FOB = "Medina" Then
                            BillingScenario = "NormalAmerican"
                        ElseIf CustomerClass <> "STANDARD" And FOB = "Medina" Then
                            BillingScenario = "ConsignmentZeroDollar"
                        ElseIf CustomerClass <> "STANDARD" And FOB <> "Medina" Then
                            BillingScenario = "ConsignmentUsage"
                        Else
                            BillingScenario = "NormalAmerican"
                        End If
                    Case "TST"
                        If CustomerClass = "STANDARD" And FOB <> "Medina" Then
                            BillingScenario = "ConsignmentUsage"
                        ElseIf CustomerClass = "STANDARD" And FOB = "Medina" Then
                            BillingScenario = "NormalAmerican"
                        ElseIf CustomerClass <> "STANDARD" And FOB = "Medina" Then
                            BillingScenario = "ConsignmentZeroDollar"
                        ElseIf CustomerClass <> "STANDARD" And FOB <> "Medina" Then
                            BillingScenario = "ConsignmentUsage"
                        Else
                            BillingScenario = "NormalAmerican"
                        End If
                End Select
                '**********************************************************************************************
                'Based on division, customer class, and FOB - choose billing scenario
                '**********************************************************************************************
                Select Case BillingScenario
                    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    Case "ConsignmentCanadian"
                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'Freight Billing Routine for Canadian Consignment
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        If CustomerClass = "AMERICAN" Then
                            FreightGLAccount = "49500"
                            ARAccount = "11000"
                        Else
                            FreightGLAccount = "C$49500"
                            ARAccount = "C$11000"
                        End If

                        If BilledFreight > 0 Then
                            '**********************************************************************
                            Try
                                ' CREDIT ENTRY ********************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                ' DEBIT ENTRY ********************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Invoice add freight error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Freight Cons. Can. Error (+)"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf BilledFreight < 0 Then
                            'Convert freight
                            BilledFreightPositive = BilledFreight * -1

                            Try
                                'DEBIT ENTRY *******************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Invoice add freight error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Freight Cons. Can. Error (-)"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Continue
                        End If

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'End of Freight Routine for Canadian Customers
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                        '*********************************************************************************************
                        'Sales Tax Routine - For Canadian Customers
                        '*********************************************************************************************

                        If CustomerClass = "AMERICAN" Then
                            TaxAccount = "23100"
                            ARAccount = "11000"
                        Else
                            TaxAccount = "C$23100"
                            ARAccount = "C$11000"
                        End If

                        If SalesTax > 0 Then
                            Try
                                'CREDIT ENTRY ***************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - GST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - GST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Invoice add tax error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax Cons. Can. Error (+)"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf SalesTax < 0 Then
                            'Convert Sales Tax to positive before reversing the entry
                            SalesTaxPositive = SalesTax * -1

                            Try
                                'DEBIT ENTRY*************************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - GST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '**********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - GST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Invoice add tax error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax Cons. Can. Error (-)"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Do nothing and continue
                        End If

                        If CustomerClass = "AMERICAN" Then
                            TaxAccount = "23150"
                            ARAccount = "11000"
                        Else
                            TaxAccount = "C$23150"
                            ARAccount = "C$11000"
                        End If

                        If SalesTax2 > 0 Then
                            Try
                                'CREDIT ENTRY ***************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax2
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '**********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax2
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Invoice add tax error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax 2 Cons. Can. Error (+)"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf SalesTax2 < 0 Then
                            'Convert Sales Tax to positive before reversing the entry
                            SalesTaxPositive = SalesTax2 * -1

                            Try
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    ' .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '**********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Invoice add tax error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax 2 Cons. Can. Error (-)"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Do nothing and continue
                        End If

                        If CustomerClass = "AMERICAN" Then
                            TaxAccount = "23120"
                            ARAccount = "11000"
                        Else
                            TaxAccount = "C$23120"
                            ARAccount = "C$11000"
                        End If

                        If SalesTax3 > 0 Then
                            Try
                                'CREDIT ENTRY ***************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    ' .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax3
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax3
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Invoice add tax error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax 3 Cons. Can. Error (+)"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf SalesTax3 < 0 Then
                            'Convert Sales Tax to positive before reversing the entry
                            SalesTaxPositive = SalesTax3 * -1

                            Try
                                'DEBIT ENTRY **********************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Invoice add tax error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax 3 Cons. Can. Error (-)"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Do nothing and continue
                        End If

                        '*********************************************************************************************
                        'End of Sales Tax Routine For Canadian Customers
                        '*********************************************************************************************

                        '*********************************************************************************************
                        'Line Routine - writing line items from the invoice to the database for Canadian Consignment Billing
                        '*********************************************************************************************

                        '*********************************************************************************************
                        'Consignment Line Routine - writing line items from the invoice to the database
                        '*********************************************************************************************

                        'Count the number of line items
                        Dim CountLine2Statement As String = "SELECT COUNT(InvoiceHeaderKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                        Dim CountLine2Command As New SqlCommand(CountLine2Statement, con)
                        CountLine2Command.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                        CountLine2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountLineNumber = CInt(CountLine2Command.ExecuteScalar)
                        Catch ex As Exception
                            CountLineNumber = 1
                        End Try
                        con.Close()

                        'Initialize first line number
                        InvoiceLine = 1

                        'Writes Line GL Entries for each Invoice to the GL
                        For i As Integer = 1 To CountLineNumber
                            ExtendedAmount = 0
                            PartNumber = ""
                            QuantityShipped = 0
                            PartDescription = ""
                            Price = 0
                            ExtendedCOS = 0
                            UnitCOS = 0

                            'Extract data from Invoice Line Table
                            Dim ExtendedAmountStatement As String = "SELECT ExtendedAmount FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim ExtendedAmountCommand As New SqlCommand(ExtendedAmountStatement, con)
                            ExtendedAmountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            ExtendedAmountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartNumberStatement As String = "SELECT PartNumber FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartNumberCommand As New SqlCommand(PartNumberStatement, con)
                            PartNumberCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartNumberCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim QuantityShippedStatement As String = "SELECT QuantityBilled FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim QuantityShippedCommand As New SqlCommand(QuantityShippedStatement, con)
                            QuantityShippedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            QuantityShippedCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartDescriptionStatement As String = "SELECT PartDescription FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
                            PartDescriptionCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartDescriptionCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PriceStatement As String = "SELECT Price FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PriceCommand As New SqlCommand(PriceStatement, con)
                            PriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PriceCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim ExtendedCOSStatement As String = "SELECT ExtendedCOS FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim ExtendedCOSCommand As New SqlCommand(ExtendedCOSStatement, con)
                            ExtendedCOSCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            ExtendedCOSCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ExtendedAmount = CDbl(ExtendedAmountCommand.ExecuteScalar)
                            Catch ex As Exception
                                ExtendedAmount = 0
                            End Try
                            Try
                                PartNumber = CStr(PartNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartNumber = ""
                            End Try
                            Try
                                QuantityShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
                            Catch ex As Exception
                                QuantityShipped = 0
                            End Try
                            Try
                                PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartDescription = ""
                            End Try
                            Try
                                Price = CDbl(PriceCommand.ExecuteScalar)
                            Catch ex As Exception
                                Price = 0
                            End Try
                            Try
                                ExtendedCOS = CDbl(ExtendedCOSCommand.ExecuteScalar)
                            Catch ex As Exception
                                ExtendedCOS = 0
                            End Try
                            con.Close()

                            'Round dollars to two decimals
                            ExtendedAmount = Math.Round(ExtendedAmount, 2)
                            ExtendedCOS = Math.Round(ExtendedCOS, 2)
                            If QuantityShipped <> 0 Then
                                UnitCOS = ExtendedCOS / QuantityShipped
                                UnitCOS = Math.Round(UnitCOS, 4)
                            Else
                                UnitCOS = 0
                            End If
                            '******************************************************************************************************************************************
                            If ExtendedCOS = 0 Then
                                'Get FIFO Cost of Part

                                'Define Variables used in FIFO
                                Dim GetMaxTransactionNumber As Integer = 0
                                Dim GetUpperLimit As Double = 0
                                Dim UpperLimit As Double = 0
                                Dim QuantityRemaining As Double = 0
                                Dim NextUpperLimit As Double = 0
                                Dim NextLowerLimit As Double = 0
                                Dim StandardCost As Double = 0
                                Dim TransactionCost As Double = 0
                                '******************************************************************************************************************************************
                                'Determine FIFO Cost on Part Number to remove from Inventory
                                Dim TotalQuantityBilled As Double = 0
                                Dim NoCostTierFound As String = "FALSE"
                                FIFOCost = 0
                                FIFOExtendedAmount = 0
                                '******************************************************************************************************************************************
                                'Determine Total Quantity Shipped
                                Dim TotalQuantityBilledStatement As String = "SELECT SUM(QuantityBilled) FROM ConsignmentBillingTable WHERE PartNumber = @PartNumber AND CustomerClass = @CustomerClass AND BillDate <= @BillDate"
                                Dim TotalQuantityBilledCommand As New SqlCommand(TotalQuantityBilledStatement, con)
                                TotalQuantityBilledCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                TotalQuantityBilledCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = FOB
                                TotalQuantityBilledCommand.Parameters.Add("@BillDate", SqlDbType.VarChar).Value = InvoiceDate

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    TotalQuantityBilled = CDbl(TotalQuantityBilledCommand.ExecuteScalar)
                                Catch ex As Exception
                                    TotalQuantityBilled = 0
                                End Try
                                con.Close()
                                '******************************************************************************************************************************************
                                'Check to see if Total Quantity Shipped falls within the Cost Tiers
                                Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
                                Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                                GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetMaxTransactionNumber = 0
                                End Try
                                con.Close()

                                Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                                Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
                                GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber
                                GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetUpperLimit = 0
                                End Try
                                con.Close()

                                If TotalQuantityBilled = 0 Then
                                    TotalQuantityBilled = 1
                                Else
                                    TotalQuantityBilled = TotalQuantityBilled + 1
                                End If

                                If TotalQuantityBilled + QuantityShipped > GetUpperLimit Then
                                    'Item is beyond the Cost Tier - skip FIFO
                                    FIFOCost = 0
                                    FIFOExtendedAmount = 0
                                Else
                                    '******************************************************************************************************************************************
                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                    'Get Max Transaction Number where 
                                    Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                    Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
                                    GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                    GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = TotalQuantityBilled
                                    GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
                                    Catch ex As Exception
                                        GetMaxTransactionNumber = 0
                                    End Try
                                    con.Close()

                                    If GetMaxTransactionNumber = 0 Then
                                        NoCostTierFound = "TRUE"
                                    Else
                                        NoCostTierFound = "FALSE"

                                        Dim ItemCost2Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                        Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                                        ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                        ItemCost2Command.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = TotalQuantityBilled
                                        ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                        ItemCost2Command.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                        UpperLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = TotalQuantityBilled
                                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                        UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            FIFOCost = CDbl(ItemCost2Command.ExecuteScalar)
                                        Catch ex As Exception
                                            FIFOCost = 0
                                        End Try
                                        Try
                                            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            UpperLimit = 0
                                        End Try
                                        con.Close()
                                    End If

                                    If NoCostTierFound = "TRUE" Then
                                        FIFOCost = 0
                                        FIFOExtendedAmount = 0
                                    Else
                                        If TotalQuantityBilled + QuantityShipped - 1 > UpperLimit Then
                                            'Quantity crosses a cost tier
                                            QuantityRemaining = (TotalQuantityBilled + QuantityShipped - 1) - UpperLimit

                                            FIFOExtendedAmount = (UpperLimit - (TotalQuantityBilled - 1)) * FIFOCost

                                            'Create loop to calculate remainder of quantity
                                            Do While QuantityRemaining > 0
                                                Dim TempQuantity As Double = 0

                                                'Get Max Transaction Number where 
                                                Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                                                GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                Try
                                                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumber2Command.ExecuteScalar)
                                                Catch ex As Exception
                                                    GetMaxTransactionNumber = 0
                                                End Try
                                                con.Close()

                                                If GetMaxTransactionNumber = 0 Then
                                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextItemCostCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextUpperLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextLowerLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                                    If con.State = ConnectionState.Closed Then con.Open()
                                                    Try
                                                        FIFOCost = CDbl(NextItemCostCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        FIFOCost = 0
                                                    End Try
                                                    Try
                                                        NextUpperLimit = CDbl(NextUpperLimitCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        NextUpperLimit = 0
                                                    End Try
                                                    Try
                                                        NextLowerLimit = CDbl(NextLowerLimitCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        NextLowerLimit = 0
                                                    End Try
                                                    con.Close()
                                                Else
                                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextItemCostCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                                    NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextUpperLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                                    NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextLowerLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                                    NextLowerLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                    If con.State = ConnectionState.Closed Then con.Open()
                                                    Try
                                                        FIFOCost = CDbl(NextItemCostCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        FIFOCost = 0
                                                    End Try
                                                    Try
                                                        NextUpperLimit = CDbl(NextUpperLimitCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        NextUpperLimit = 0
                                                    End Try
                                                    Try
                                                        NextLowerLimit = CDbl(NextLowerLimitCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        NextLowerLimit = 0
                                                    End Try
                                                    con.Close()
                                                End If

                                                TempQuantity = (NextUpperLimit + 1) - NextLowerLimit

                                                If QuantityRemaining > TempQuantity Then
                                                    'Add to existing FIFO Extended Amount
                                                    FIFOExtendedAmount = FIFOExtendedAmount + (TempQuantity * FIFOCost)

                                                    'Redefine Quantity Remaining after the next cost tier
                                                    QuantityRemaining = QuantityRemaining - TempQuantity
                                                    UpperLimit = NextUpperLimit
                                                Else
                                                    FIFOExtendedAmount = FIFOExtendedAmount + (QuantityRemaining * FIFOCost)
                                                    QuantityRemaining = 0
                                                End If
                                            Loop
                                        Else
                                            'Entire quantity falls into one cost tier
                                            FIFOExtendedAmount = FIFOCost * QuantityShipped
                                        End If
                                    End If
                                End If

                                'Run routine if no FIFO Cost is retrieved - Use LPC, TC, STD Cost
                                '*****************************************************************************************************************************************
                                If FIFOCost = 0 Then
                                    TransactionCost = 0

                                    Dim TransactionCostStatement As String = "SELECT MAX(ItemCost) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        TransactionCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = TransactionCost
                                    FIFOExtendedAmount = FIFOCost * QuantityShipped
                                End If
                                '*****************************************************************************************************************************************
                                'If FIFO Cost = 0, pull Standard Cost from Item List
                                If FIFOCost = 0 Then
                                    StandardCost = 0

                                    Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                                    Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                                    StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                    StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        StandardCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = StandardCost
                                    FIFOExtendedAmount = FIFOCost * QuantityShipped
                                End If
                            Else
                                FIFOExtendedAmount = ExtendedCOS
                            End If
                            '****************************************************************************************************
                            'Determine Clearing Account for specific location
                            If FOBName = "SRL" And CustomerClass = "CANADIAN" Then
                                DebitGLAccount = "12670"
                                RevenueGLAccount = "C$42670"
                                COSGLAccount = "52670"
                                ARAccount = "C$11000"
                            ElseIf FOBName = "SRL" And CustomerClass = "AMERICAN" Then
                                DebitGLAccount = "12670"
                                RevenueGLAccount = "42670"
                                COSGLAccount = "52670"
                                ARAccount = "11000"
                            ElseIf FOBName = "SRL" And CustomerClass = "SRL" Then
                                DebitGLAccount = "12670"
                                RevenueGLAccount = "C$42670"
                                COSGLAccount = "52670"
                                ARAccount = "C$11000"
                            Else
                                DebitGLAccount = "12670"
                                RevenueGLAccount = "C$42670"
                                COSGLAccount = "52670"
                                ARAccount = "C$11000"
                            End If
                            '******************************************************************
                            'Check to see if it is a credit
                            If ExtendedAmount >= 0 Then
                                Try
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Invoice Line error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Add Line Cons. Can. (REVENUES)"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                                Try
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Invoice Line error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Add Line Cons. Can. (COS)"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                            ElseIf ExtendedAmount < 0 Then
                                'Convert to Positive before reversing entry
                                ExtendedAmountPositive = ExtendedAmount * -1
                                ExtendedCOSPositive = FIFOExtendedAmount * -1

                                Try
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Invoice Line error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Add Line Cons. Can. (REVENUES CR)"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                                Try
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Invoice Line error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Add Line Cons. Can. (COS CR)"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try

                            End If
                            '****************************************************************************************************
                            Try
                                'Update COS to Invoice Line Table
                                cmd = New SqlCommand("UPDATE InvoiceLineTable SET ExtendedCOS = @ExtendedCOS, LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                                With cmd.Parameters
                                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Retotal Invoice Line Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Invoice Line Retotal Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '****************************************************************************************************
                            'Get next Consignment Billing Number
                            Dim LastConsignmentNumber As Integer = 0
                            Dim NextConsignmentNumber As Integer = 0

                            Dim MaxConsignmentNumberStatement As String = "SELECT MAX(ConsignmentBillingNumber) FROM ConsignmentBillingTable"
                            Dim MaxConsignmentNumberCommand As New SqlCommand(MaxConsignmentNumberStatement, con)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastConsignmentNumber = CInt(MaxConsignmentNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                LastConsignmentNumber = 87444000
                            End Try
                            con.Close()

                            NextConsignmentNumber = LastConsignmentNumber + 1

                            Try
                                'Insert into Consignment Billing Table
                                cmd = New SqlCommand("INSERT INTO ConsignmentBillingTable (ConsignmentBillingNumber, PartNumber, PartDescription, QuantityBilled, UnitCost, UnitPrice, ExtendedCost, ExtendedAmount, DivisionID, BillDate, InvoiceNumber, CustomerClass) values (@ConsignmentBillingNumber, @PartNumber, @PartDescription, @QuantityBilled, @UnitCost, @UnitPrice, @ExtendedCost, @ExtendedAmount, @DivisionID, @BillDate, @InvoiceNumber, @CustomerClass)", con)

                                With cmd.Parameters
                                    .Add("@ConsignmentBillingNumber", SqlDbType.VarChar).Value = NextConsignmentNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                    .Add("@QuantityBilled", SqlDbType.VarChar).Value = QuantityShipped
                                    .Add("@UnitCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@UnitPrice", SqlDbType.VarChar).Value = Price
                                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@BillDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@CustomerClass", SqlDbType.VarChar).Value = FOB
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Retotal Invoice Line Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- INSERT Consignment Billing Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '****************************************************************************************************
                            Try
                                'Insert into Consignment Billing Table
                                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                                With cmd.Parameters
                                    '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                                    .Add("@TransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Consignment Billing"
                                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = InvoiceLine
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                    .Add("@Quantity", SqlDbType.VarChar).Value = QuantityShipped
                                    .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                    .Add("@ItemPrice", SqlDbType.VarChar).Value = Price
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                                    .Add("@GLAccount", SqlDbType.VarChar).Value = DebitGLAccount
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Retotal Invoice Line Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- INSERT Consignment Billing Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '****************************************************************************************************
                            InvoiceLine = InvoiceLine + 1
                        Next i
                        '*************************************************************************************************************************
                        'End of Canadian Consignment Line Routine
                        '*************************************************************************************************************************

                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    Case "ConsignmentUsage"
                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        '*************************************************************************************************
                        'Routine for billing consigment warehouses - Billing consigment usage
                        '*************************************************************************************************

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'Consignment Freight Routine
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        If BilledFreight > 0 Then
                            Try
                                'CREDIT ENTRY ******************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "49500"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed - Consignment Usage"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed - Consignment Usage"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Retotal Freight Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Cons. Usage Add Freight Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf BilledFreight < 0 Then
                            'Convert freight
                            BilledFreightPositive = BilledFreight * -1

                            Try
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "49500"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed - Consignment Usage"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed - Consignment Usage"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Freight Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Cons. Usage Add Freight CR Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Continue
                        End If
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'End Consignment Freight Routine
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'Consignment Tax Routine
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        If SalesTax > 0 Then
                            Try
                                'CREDIT ENTRY ************************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "25000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - Consignment Usage"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - Consignment Usage"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Cons. Usage Add Tax Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf SalesTax < 0 Then
                            'Convert Sales Tax to positive before reversing the entry
                            SalesTaxPositive = SalesTax * -1

                            Try
                                'DENIT ENTRY ***********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "25000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - Consignment Usage"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - Consignment Usage"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Cons. Usage Add Tax CR Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Do nothing and continue
                        End If

                        'Clear Tax and Freight
                        'SalesTax = 0
                        'SalesTax2 = 0
                        'SalesTax3 = 0
                        'BilledFreight = 0
                        LineSalesTax = 0
                        LineFreight = 0

                        '*********************************************************************************************
                        'Consignment Line Routine - writing line items from the invoice to the database
                        '*********************************************************************************************

                        'Count the number of line items
                        Dim CountLine2Statement As String = "SELECT COUNT(InvoiceHeaderKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                        Dim CountLine2Command As New SqlCommand(CountLine2Statement, con)
                        CountLine2Command.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                        CountLine2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountLineNumber = CInt(CountLine2Command.ExecuteScalar)
                        Catch ex As Exception
                            CountLineNumber = 1
                        End Try
                        con.Close()

                        'Initialize first line number
                        InvoiceLine = 1

                        'Writes Line GL Entries for each Invoice to the GL
                        For i As Integer = 1 To CountLineNumber
                            ExtendedAmount = 0
                            PartNumber = ""
                            QuantityShipped = 0
                            PartDescription = ""
                            Price = 0

                            'Extract data from Invoice Line Table
                            Dim ExtendedAmountStatement As String = "SELECT ExtendedAmount FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim ExtendedAmountCommand As New SqlCommand(ExtendedAmountStatement, con)
                            ExtendedAmountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            ExtendedAmountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartNumberStatement As String = "SELECT PartNumber FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartNumberCommand As New SqlCommand(PartNumberStatement, con)
                            PartNumberCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartNumberCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim QuantityShippedStatement As String = "SELECT QuantityBilled FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim QuantityShippedCommand As New SqlCommand(QuantityShippedStatement, con)
                            QuantityShippedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            QuantityShippedCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartDescriptionStatement As String = "SELECT PartDescription FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
                            PartDescriptionCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartDescriptionCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PriceStatement As String = "SELECT Price FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PriceCommand As New SqlCommand(PriceStatement, con)
                            PriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PriceCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ExtendedAmount = CDbl(ExtendedAmountCommand.ExecuteScalar)
                            Catch ex As Exception
                                ExtendedAmount = 0
                            End Try
                            Try
                                PartNumber = CStr(PartNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartNumber = ""
                            End Try
                            Try
                                QuantityShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
                            Catch ex As Exception
                                QuantityShipped = 0
                            End Try
                            Try
                                PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartDescription = ""
                            End Try
                            Try
                                Price = CDbl(PriceCommand.ExecuteScalar)
                            Catch ex As Exception
                                Price = 0
                            End Try
                            con.Close()

                            'Round dollars to two decimals
                            ExtendedAmount = Math.Round(ExtendedAmount, 2)
                            '******************************************************************************************************************************************
                            'If TWE or TST and serialized assembly, get serial cost of part
                            If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Then
                                Dim SUMSerialCostStatement As String = "SELECT SUM(SerialNumberCost) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber AND InvoiceLineNumber = @InvoiceLineNumber"
                                Dim SUMSerialCostCommand As New SqlCommand(SUMSerialCostStatement, con)
                                SUMSerialCostCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                SUMSerialCostCommand.Parameters.Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = InvoiceLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    SUMSerialCost = CDbl(SUMSerialCostCommand.ExecuteScalar)
                                Catch ex As Exception
                                    SUMSerialCost = 0
                                End Try
                                con.Close()

                                SUMSerialCost = Math.Round(SUMSerialCost, 2)
                            Else
                                'Skip
                            End If
                            '*******************************************************************************************************************************************
                            'If Sum Serial Cost = 0, then proceed with FIFO -- if not 0, use Serial Cost
                            If SUMSerialCost = 0 Then
                                '*******************************************************************************************************************************************
                                'Get FIFO Cost of Part

                                'Define Variables used in FIFO
                                Dim GetMaxTransactionNumber As Integer = 0
                                Dim GetUpperLimit As Double = 0
                                Dim UpperLimit As Double = 0
                                Dim QuantityRemaining As Double = 0
                                Dim NextUpperLimit As Double = 0
                                Dim NextLowerLimit As Double = 0
                                Dim StandardCost As Double = 0
                                Dim TransactionCost As Double = 0
                                '******************************************************************************************************************************************
                                'Determine FIFO Cost on Part Number to remove from Inventory
                                Dim TotalQuantityBilled As Double = 0
                                Dim NoCostTierFound As String = "FALSE"
                                FIFOCost = 0
                                FIFOExtendedAmount = 0
                                '******************************************************************************************************************************************
                                'Determine Total Quantity Shipped
                                Dim TotalQuantityBilledStatement As String = "SELECT SUM(QuantityBilled) FROM ConsignmentBillingTable WHERE PartNumber = @PartNumber AND CustomerClass = @CustomerClass AND BillDate <= @BillDate"
                                Dim TotalQuantityBilledCommand As New SqlCommand(TotalQuantityBilledStatement, con)
                                TotalQuantityBilledCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                TotalQuantityBilledCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = FOB
                                TotalQuantityBilledCommand.Parameters.Add("@BillDate", SqlDbType.VarChar).Value = InvoiceDate

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    TotalQuantityBilled = CDbl(TotalQuantityBilledCommand.ExecuteScalar)
                                Catch ex As Exception
                                    TotalQuantityBilled = 0
                                End Try
                                con.Close()
                                '******************************************************************************************************************************************
                                'Check to see if Total Quantity Shipped falls within the Cost Tiers
                                Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
                                Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                                GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetMaxTransactionNumber = 0
                                End Try
                                con.Close()

                                Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                                Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
                                GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber
                                GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetUpperLimit = 0
                                End Try
                                con.Close()

                                If TotalQuantityBilled = 0 Then
                                    TotalQuantityBilled = 1
                                Else
                                    TotalQuantityBilled = TotalQuantityBilled + 1
                                End If

                                If TotalQuantityBilled + QuantityShipped > GetUpperLimit Then
                                    'Item is beyond the Cost Tier - skip FIFO
                                    FIFOCost = 0
                                    FIFOExtendedAmount = 0
                                Else
                                    '******************************************************************************************************************************************
                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                    'Get Max Transaction Number where 
                                    Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                    Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
                                    GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                    GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = TotalQuantityBilled
                                    GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
                                    Catch ex As Exception
                                        GetMaxTransactionNumber = 0
                                    End Try
                                    con.Close()

                                    If GetMaxTransactionNumber = 0 Then
                                        NoCostTierFound = "TRUE"
                                    Else
                                        NoCostTierFound = "FALSE"

                                        Dim ItemCost2Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                        Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                                        ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                        ItemCost2Command.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = TotalQuantityBilled
                                        ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                        ItemCost2Command.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                        UpperLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = TotalQuantityBilled
                                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                        UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            FIFOCost = CDbl(ItemCost2Command.ExecuteScalar)
                                        Catch ex As Exception
                                            FIFOCost = 0
                                        End Try
                                        Try
                                            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            UpperLimit = 0
                                        End Try
                                        con.Close()
                                    End If

                                    If NoCostTierFound = "TRUE" Then
                                        FIFOCost = 0
                                        FIFOExtendedAmount = 0
                                    Else
                                        If TotalQuantityBilled + QuantityShipped - 1 > UpperLimit Then
                                            'Quantity crosses a cost tier
                                            QuantityRemaining = (TotalQuantityBilled + QuantityShipped - 1) - UpperLimit

                                            FIFOExtendedAmount = (UpperLimit - (TotalQuantityBilled - 1)) * FIFOCost

                                            'Create loop to calculate remainder of quantity
                                            Do While QuantityRemaining > 0
                                                Dim TempQuantity As Double = 0

                                                'Get Max Transaction Number where 
                                                Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                                                GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                Try
                                                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumber2Command.ExecuteScalar)
                                                Catch ex As Exception
                                                    GetMaxTransactionNumber = 0
                                                End Try
                                                con.Close()

                                                If GetMaxTransactionNumber = 0 Then
                                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextItemCostCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextUpperLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextLowerLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate

                                                    If con.State = ConnectionState.Closed Then con.Open()
                                                    Try
                                                        FIFOCost = CDbl(NextItemCostCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        FIFOCost = 0
                                                    End Try
                                                    Try
                                                        NextUpperLimit = CDbl(NextUpperLimitCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        NextUpperLimit = 0
                                                    End Try
                                                    Try
                                                        NextLowerLimit = CDbl(NextLowerLimitCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        NextLowerLimit = 0
                                                    End Try
                                                    con.Close()
                                                Else
                                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextItemCostCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                                    NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextUpperLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                                    NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
                                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                                    NextLowerLimitCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = UpperLimit + 1
                                                    NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = InvoiceDate
                                                    NextLowerLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                    If con.State = ConnectionState.Closed Then con.Open()
                                                    Try
                                                        FIFOCost = CDbl(NextItemCostCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        FIFOCost = 0
                                                    End Try
                                                    Try
                                                        NextUpperLimit = CDbl(NextUpperLimitCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        NextUpperLimit = 0
                                                    End Try
                                                    Try
                                                        NextLowerLimit = CDbl(NextLowerLimitCommand.ExecuteScalar)
                                                    Catch ex As Exception
                                                        NextLowerLimit = 0
                                                    End Try
                                                    con.Close()
                                                End If

                                                TempQuantity = (NextUpperLimit + 1) - NextLowerLimit

                                                If QuantityRemaining > TempQuantity Then
                                                    'Add to existing FIFO Extended Amount
                                                    FIFOExtendedAmount = FIFOExtendedAmount + (TempQuantity * FIFOCost)

                                                    'Redefine Quantity Remaining after the next cost tier
                                                    QuantityRemaining = QuantityRemaining - TempQuantity
                                                    UpperLimit = NextUpperLimit
                                                Else
                                                    FIFOExtendedAmount = FIFOExtendedAmount + (QuantityRemaining * FIFOCost)
                                                    QuantityRemaining = 0
                                                End If
                                            Loop
                                        Else
                                            'Entire quantity falls into one cost tier
                                            FIFOExtendedAmount = FIFOCost * QuantityShipped
                                        End If
                                    End If
                                End If
                                '*****************************************************************************************************************************************
                                'Run routine if no FIFO Cost is retrieved - Use LPC, TC, STD Cost
                                '*****************************************************************************************************************************************
                                If FIFOCost = 0 Then
                                    Dim MaxCostDate As Integer = 0
                                    TransactionCost = 0

                                    Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        MaxCostDate = CInt(MAXDateCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        MaxCostDate = 0
                                    End Try
                                    con.Close()

                                    Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxCostDate

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        TransactionCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = TransactionCost
                                    FIFOExtendedAmount = FIFOCost * QuantityShipped
                                End If
                                '*****************************************************************************************************************************************
                                'If FIFO Cost = 0, pull Standard Cost from Item List
                                If FIFOCost = 0 Then
                                    StandardCost = 0

                                    Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                                    Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                                    StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                    StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        StandardCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = StandardCost
                                    FIFOExtendedAmount = FIFOCost * QuantityShipped
                                End If
                            Else
                                FIFOCost = SUMSerialCost / QuantityShipped
                                FIFOExtendedAmount = SUMSerialCost
                            End If
                            '*****************************************************************************************************************************************
                            'Extract GL Account Numbers for Revenues and AR Accounts by Item Class
                            Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
                            ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ItemClass = CStr(ItemClassCommand.ExecuteScalar)
                            Catch ex As Exception
                                ItemClass = ""
                            End Try
                            con.Close()
                            '*******************************************************************************************************************************************
                            'If Item Class is a ferrule in the consignment, set FIFO Extended Amount equal to zero
                            If ItemClass = "TW FER" Then
                                FIFOCost = 0
                                FIFOExtendedAmount = 0
                            End If
                            '*******************************************************************************************************************************************
                            Dim RevenueGLAccountStatement As String = "SELECT GLSalesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                            Dim RevenueGLAccountCommand As New SqlCommand(RevenueGLAccountStatement, con)
                            RevenueGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                            Dim COSGLAccountStatement As String = "SELECT GLCOGSAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                            Dim COSGLAccountCommand As New SqlCommand(COSGLAccountStatement, con)
                            COSGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                RevenueGLAccount = CStr(RevenueGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                RevenueGLAccount = "41000"
                            End Try
                            Try
                                COSGLAccount = CStr(COSGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                COSGLAccount = "51000"
                            End Try
                            con.Close()
                            '****************************************************************************************************
                            'Determine Clearing Account for specific location
                            If FOBName = "Medina" Then
                                DebitGLAccount = "49999"
                            ElseIf FOBName = "Hayward" Then
                                DebitGLAccount = "12620"
                                RevenueGLAccount = "42620"
                                COSGLAccount = "52620"
                            ElseIf FOBName = "Bessemer" Then
                                DebitGLAccount = "12610"
                                RevenueGLAccount = "42610"
                                COSGLAccount = "52610"
                            ElseIf FOBName = "Lyndhurst" Then
                                DebitGLAccount = "12600"
                                RevenueGLAccount = "42600"
                                COSGLAccount = "52600"
                            ElseIf FOBName = "Downey" Then
                                DebitGLAccount = "12630"
                                RevenueGLAccount = "42630"
                                COSGLAccount = "52630"
                            ElseIf FOBName = "Seattle" Then
                                DebitGLAccount = "12640"
                                RevenueGLAccount = "42640"
                                COSGLAccount = "52640"
                            ElseIf FOBName = "Lewisville" Then
                                DebitGLAccount = "12650"
                                RevenueGLAccount = "42650"
                                COSGLAccount = "52650"
                            ElseIf FOBName = "Phoenix" Then
                                DebitGLAccount = "12660"
                                RevenueGLAccount = "42660"
                                COSGLAccount = "52660"
                            ElseIf FOBName = "Renton" Then
                                DebitGLAccount = "12680"
                                RevenueGLAccount = "42680"
                                COSGLAccount = "52680"
                            ElseIf FOBName = "Lake Stevens" Then
                                DebitGLAccount = "12690"
                                RevenueGLAccount = "42690"
                                COSGLAccount = "52690"
                            Else
                                'If Invoice is a DROP SHIP, use the Drop Ship Clearing Account
                                If DropShipPONumber > 0 Then
                                    DebitGLAccount = "20990"
                                Else
                                    DebitGLAccount = "49999"
                                End If
                            End If
                            '******************************************************************
                            'Check to see if it is a credit
                            If ExtendedAmount >= 0 Then
                                Try
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Add Line Error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Cons. Usage Add Line (REVENUES) Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                                Try
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Add Line Error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Cons. Usage Add Line (COS) Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                            ElseIf ExtendedAmount < 0 Then
                                'Convert to Positive before reversing entry
                                ExtendedAmountPositive = ExtendedAmount * -1
                                ExtendedCOSPositive = FIFOExtendedAmount * -1

                                Try
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Add Line Error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Cons. Usage Add Line (REVENUES CR) Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                                Try
                                    '****************************************************************************************************
                                    'Command to write Line Amount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    '****************************************************************************************************
                                    'Command to write LineAmount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Usage"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Add Line Error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Cons. Usage Add Line (COS CR) Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                            End If
                            '****************************************************************************************************
                            Try
                                'Update COS to Invoice Line Table
                                cmd = New SqlCommand("UPDATE InvoiceLineTable SET ExtendedCOS = @ExtendedCOS, LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                                With cmd.Parameters
                                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Retotal Invoice Line Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Invoice Line Retotal Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '***************************************************************************************************
                            'Check to see if it is an invoice from a return
                            Dim CheckReturnNumber As Integer = 0

                            Dim CheckReturnNumberStatement As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductHeaderTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                            Dim CheckReturnNumberCommand As New SqlCommand(CheckReturnNumberStatement, con)
                            CheckReturnNumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            CheckReturnNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                CheckReturnNumber = CInt(CheckReturnNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                CheckReturnNumber = 0
                            End Try
                            con.Close()

                            If CheckReturnNumber = 0 Then
                                'Get next Consignment Billing Number
                                Dim LastConsignmentNumber As Integer = 0
                                Dim NextConsignmentNumber As Integer = 0

                                Dim MaxConsignmentNumberStatement As String = "SELECT MAX(ConsignmentBillingNumber) FROM ConsignmentBillingTable"
                                Dim MaxConsignmentNumberCommand As New SqlCommand(MaxConsignmentNumberStatement, con)

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    LastConsignmentNumber = CInt(MaxConsignmentNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    LastConsignmentNumber = 87444000
                                End Try
                                con.Close()

                                NextConsignmentNumber = LastConsignmentNumber + 1

                                Try
                                    'Insert into Consignment Billing Table
                                    cmd = New SqlCommand("INSERT INTO ConsignmentBillingTable (ConsignmentBillingNumber, PartNumber, PartDescription, QuantityBilled, UnitCost, UnitPrice, ExtendedCost, ExtendedAmount, DivisionID, BillDate, InvoiceNumber, CustomerClass) values (@ConsignmentBillingNumber, @PartNumber, @PartDescription, @QuantityBilled, @UnitCost, @UnitPrice, @ExtendedCost, @ExtendedAmount, @DivisionID, @BillDate, @InvoiceNumber, @CustomerClass)", con)

                                    With cmd.Parameters
                                        .Add("@ConsignmentBillingNumber", SqlDbType.VarChar).Value = NextConsignmentNumber
                                        .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                        .Add("@QuantityBilled", SqlDbType.VarChar).Value = QuantityShipped
                                        .Add("@UnitCost", SqlDbType.VarChar).Value = FIFOCost
                                        .Add("@UnitPrice", SqlDbType.VarChar).Value = Price
                                        .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@BillDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@CustomerClass", SqlDbType.VarChar).Value = FOB
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Retotal Invoice Line Error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- INSERT Consignment Billing Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                                '****************************************************************************************************
                                'Create Inventory Transaction for the Consigment Warehouse
                                Try
                                    'Insert into Consignment Billing Table
                                    cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                                    With cmd.Parameters
                                        '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                                        .Add("@TransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@TransactionType", SqlDbType.VarChar).Value = "Consignment Billing"
                                        .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                        .Add("@Quantity", SqlDbType.VarChar).Value = QuantityShipped
                                        .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                                        .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                        .Add("@ItemPrice", SqlDbType.VarChar).Value = Price
                                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                        .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                                        .Add("@GLAccount", SqlDbType.VarChar).Value = DebitGLAccount
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Retotal Invoice Line Error
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(InvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- INSERT Consignment Billing Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                            End If
                            '****************************************************************************************************
                            'Advance line number to write next line
                            InvoiceLine = InvoiceLine + 1
                        Next i
                        '****************************************************************************************************
                        'Serial Number Routine for TWE

                        'Check to see if Invoice Serial Lines need to be updated
                        Dim CountSerialLines As Integer = 0

                        Dim CountSerialLinesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber"
                        Dim CountSerialLinesCommand As New SqlCommand(CountSerialLinesStatement, con)
                        CountSerialLinesCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountSerialLines = CInt(CountSerialLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountSerialLines = 0
                        End Try
                        con.Close()

                        If CountSerialLines = 0 Then
                            'Skip Routine
                        Else
                            'Serial Line Query into datagrid
                            SerialInvoiceNumber = InvoiceNumber

                            ShowSerialLines()

                            'Declare Serial Line Variables
                            Dim SerialInvoiceLineNumber As Integer = 0
                            Dim SerialNumber As String = ""
                            Dim SerialCustomer As String = ""
                            Dim SerialPartNumber As String = ""

                            'Get Datagrid Lines and update Serial Assembly Log
                            For Each row5 As DataGridViewRow In dgvInvoiceSerialLines.Rows
                                Try
                                    SerialInvoiceLineNumber = row5.Cells("SNInvoiceLineColumn").Value
                                Catch ex As Exception
                                    SerialInvoiceLineNumber = 0
                                End Try
                                Try
                                    SerialNumber = row5.Cells("SNInvoiceSerialNumberColumn").Value
                                Catch ex As Exception
                                    SerialNumber = ""
                                End Try
                                Try
                                    SerialCustomer = row5.Cells("SNCustomerIDColumn").Value
                                Catch ex As Exception
                                    SerialCustomer = ""
                                End Try
                                Try
                                    SerialPartNumber = row5.Cells("SNPartNumberColumn").Value
                                Catch ex As Exception
                                    SerialPartNumber = ""
                                End Try
                                '**************************************************************************
                                'Check to see if invoice is a credit
                                'If Invoice is a credit, change assembly log status to open
                                If InvoiceTotal > 0 Then
                                    SerialStatus = "CLOSED"
                                ElseIf InvoiceTotal = 0 Then
                                    'Check to see if it is a return (zero dollar)
                                    If ShipmentNumber >= 7500000 And ShipmentNumber < 8000000 Then
                                        SerialStatus = "OPEN"
                                    Else
                                        SerialStatus = "CLOSED"
                                    End If
                                Else
                                    SerialStatus = "OPEN"
                                End If

                                If SerialNumber <> "" Then
                                    'Update Serial Log
                                    Try
                                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, CustomerID = @CustomerID, BatchNumber = @BatchNumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = SerialPartNumber
                                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                            .Add("@CustomerID", SqlDbType.VarChar).Value = SerialCustomer
                                            .Add("@BatchNumber", SqlDbType.VarChar).Value = SerialInvoiceLineNumber
                                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = SerialInvoiceNumber
                                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@Status", SqlDbType.VarChar).Value = SerialStatus
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex6 As Exception
                                        'Shipment Status Update
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(SerialInvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex6.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch --- Update Serial Log Fail"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber + " -- Serial # - " + SerialNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                Else
                                    'Skip - no serial number
                                End If

                                'Clear Serial Variables
                                SerialNumber = ""
                                SerialPartNumber = ""
                                SerialInvoiceLineNumber = 0
                                SerialCustomer = ""
                                SerialStatus = ""
                            Next
                        End If
                        '****************************************************************************************************

                        '*************************************************************************************************************************
                        'End of Consignment Line Routine - update Headers
                        '*************************************************************************************************************************

                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    Case "ConsignmentZeroDollar"
                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        '*************************************************************************************************
                        'Routine for billing consigment warehouses - Stage 3 - Bill ZERO Invoice
                        '*************************************************************************************************

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'Consignment Freight Routine
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        If BilledFreight > 0 Then
                            Try
                                'CREDIT ENTRY ***************************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "49500"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed - Consignment Zero Bill"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed - Consignment Zero Bill"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Freight
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(SerialInvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Cons. Zero Add Freight Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf BilledFreight < 0 Then
                            BilledFreightPositive = BilledFreight * -1

                            Try
                                'DEBIT ENTRY *****************************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "49500"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed - Consignment Zero Bill"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed - Consignment Zero Bill"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Freight
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(SerialInvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Cons. Zero Add Freight CR Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Continue
                        End If
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'End Freight Routine
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'Consignment Tax Routine
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        If SalesTax > 0 Then
                            Try
                                'CREDIT ENTRY ***************************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "25000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - Consignment Zero Bill"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - Consignment Zero Bill"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(SerialInvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Cons. Zero Add Tax Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf SalesTax < 0 Then
                            'Convert Sales Tax to positive before reversing the entry
                            SalesTaxPositive = SalesTax * -1

                            Try
                                '***********************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "25000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - Consignment Zero Bill"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '**********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - Consignment Zero Bill"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(SerialInvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Cons. Zero Add Tax CR Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Do nothing and continue
                        End If

                        '*********************************************************************************************
                        'Consignment Line Routine - writing line items from the invoice to the database
                        '*********************************************************************************************

                        'Count the number of line items
                        Dim CountLine2Statement As String = "SELECT COUNT(InvoiceHeaderKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                        Dim CountLine2Command As New SqlCommand(CountLine2Statement, con)
                        CountLine2Command.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                        CountLine2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountLineNumber = CInt(CountLine2Command.ExecuteScalar)
                        Catch ex As Exception
                            CountLineNumber = 1
                        End Try
                        con.Close()

                        'Initialize first line number
                        InvoiceLine = 1

                        'Writes Line GL Entries for each Invoice to the GL
                        For i As Integer = 1 To CountLineNumber

                            'Extract data from Invoice Line Table
                            Dim ExtendedAmountStatement As String = "SELECT ExtendedAmount FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim ExtendedAmountCommand As New SqlCommand(ExtendedAmountStatement, con)
                            ExtendedAmountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            ExtendedAmountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartNumberStatement As String = "SELECT PartNumber FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartNumberCommand As New SqlCommand(PartNumberStatement, con)
                            PartNumberCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartNumberCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim QuantityShippedStatement As String = "SELECT QuantityBilled FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim QuantityShippedCommand As New SqlCommand(QuantityShippedStatement, con)
                            QuantityShippedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            QuantityShippedCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartDescriptionStatement As String = "SELECT PartDescription FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
                            PartDescriptionCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartDescriptionCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PriceStatement As String = "SELECT Price FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PriceCommand As New SqlCommand(PriceStatement, con)
                            PriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PriceCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ExtendedAmount = CDbl(ExtendedAmountCommand.ExecuteScalar)
                            Catch ex As Exception
                                ExtendedAmount = 0
                            End Try
                            Try
                                PartNumber = CStr(PartNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartNumber = ""
                            End Try
                            Try
                                QuantityShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
                            Catch ex As Exception
                                QuantityShipped = 0
                            End Try
                            Try
                                PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartDescription = ""
                            End Try
                            Try
                                Price = CDbl(PriceCommand.ExecuteScalar)
                            Catch ex As Exception
                                Price = 0
                            End Try
                            con.Close()

                            'Round dollars to two decimals
                            ExtendedAmount = Math.Round(ExtendedAmount, 2)
                            '*****************************************************************************************************************************************
                            'Extract GL Account Numbers for Revenues and AR Accounts by Item Class
                            Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
                            ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ItemClass = CStr(ItemClassCommand.ExecuteScalar)
                            Catch ex As Exception
                                ItemClass = ""
                            End Try
                            con.Close()

                            Dim RevenueGLAccountStatement As String = "SELECT GLSalesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                            Dim RevenueGLAccountCommand As New SqlCommand(RevenueGLAccountStatement, con)
                            RevenueGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                            Dim COSGLAccountStatement As String = "SELECT GLCOGSAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                            Dim COSGLAccountCommand As New SqlCommand(COSGLAccountStatement, con)
                            COSGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                RevenueGLAccount = CStr(RevenueGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                RevenueGLAccount = "41000"
                            End Try
                            Try
                                COSGLAccount = CStr(COSGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                COSGLAccount = "51000"
                            End Try
                            con.Close()
                            '****************************************************************************************************
                            'Determine Clearing Account for specific location
                            If FOBName = "Medina" Then
                                DebitGLAccount = "49999"
                            ElseIf FOBName = "Hayward" Then
                                DebitGLAccount = "12620"
                                RevenueGLAccount = "42620"
                                COSGLAccount = "52620"
                            ElseIf FOBName = "Bessemer" Then
                                DebitGLAccount = "12610"
                                RevenueGLAccount = "42610"
                                COSGLAccount = "52610"
                            ElseIf FOBName = "Lyndhurst" Then
                                DebitGLAccount = "12600"
                                RevenueGLAccount = "42600"
                                COSGLAccount = "52600"
                            ElseIf FOBName = "Downey" Then
                                DebitGLAccount = "12630"
                                RevenueGLAccount = "42630"
                                COSGLAccount = "52630"
                            ElseIf FOBName = "Seattle" Then
                                DebitGLAccount = "12640"
                                RevenueGLAccount = "42640"
                                COSGLAccount = "52640"
                            ElseIf FOBName = "Lewisville" Then
                                DebitGLAccount = "12650"
                                RevenueGLAccount = "42650"
                                COSGLAccount = "52650"
                            ElseIf FOBName = "Phoenix" Then
                                DebitGLAccount = "12660"
                                RevenueGLAccount = "42660"
                                COSGLAccount = "52660"
                            ElseIf FOBName = "Renton" Then
                                DebitGLAccount = "12680"
                                RevenueGLAccount = "42680"
                                COSGLAccount = "52680"
                            ElseIf FOBName = "Lake Stevens" Then
                                DebitGLAccount = "12690"
                                RevenueGLAccount = "42690"
                                COSGLAccount = "52690"
                            ElseIf FOBName = "SRL" Then
                                DebitGLAccount = "12670"
                                RevenueGLAccount = "42670"
                                COSGLAccount = "52670"
                            Else
                                'If Invoice is a DROP SHIP, use the Drop Ship Clearing Account
                                If DropShipPONumber > 0 Then
                                    DebitGLAccount = "20990"
                                Else
                                    DebitGLAccount = "49999"
                                End If
                            End If

                            'Check to see if it is a credit
                            If ExtendedAmount >= 0 Then
                                Try
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Zero Bill"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Zero Bill"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Add Line
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(SerialInvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Cons. Zero Add Line (REVENUES) Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                                Try
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Zero Bill"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Consignment Zero Bill"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Add Line
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(SerialInvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Cons. Zero Add Line (COS) Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                            ElseIf ExtendedAmount < 0 Then
                                'Convert to Positive before reversing entry
                                ExtendedAmountPositive = ExtendedAmount * -1
                                ExtendedCOSPositive = FIFOExtendedAmount * -1

                                Try
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Zero Bill"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Sales/AR
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Zero Bill"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Add Line
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(SerialInvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Cons. Zero Add Line (REVENUES CR) Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                                Try
                                    'CREDIT ENTRY ****************************************************************************************************
                                    'Command to write Line Amount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Zero Bill"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'DEBIT ENTRY ****************************************************************************************************
                                    'Command to write LineAmount to GL - Inventory/Sales Clearing
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data - Consignment Zero Bill"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Add Line
                                    Dim strInvoiceNumber As String = ""

                                    strInvoiceNumber = CStr(SerialInvoiceNumber)

                                    ErrorDate = Today()
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Process AR Batch --- Cons. Zero Add Line (COS CR) Failure"
                                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                            End If
                            '****************************************************************************************************
                            Try
                                'Update COS to Invoice Line Table
                                cmd = New SqlCommand("UPDATE InvoiceLineTable SET ExtendedCOS = @ExtendedCOS, LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                                With cmd.Parameters
                                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = 0
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Retotal Invoice Line Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Invoice Line Retotal Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '****************************************************************************************************
                            InvoiceLine = InvoiceLine + 1
                        Next i
                        '*************************************************************************************************************************
                        'Serial Number Routine for TWE

                        'Check to see if Invoice Serial Lines need to be updated
                        Dim CountSerialLines As Integer = 0

                        Dim CountSerialLinesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber"
                        Dim CountSerialLinesCommand As New SqlCommand(CountSerialLinesStatement, con)
                        CountSerialLinesCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountSerialLines = CInt(CountSerialLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountSerialLines = 0
                        End Try
                        con.Close()

                        If CountSerialLines = 0 Then
                            'Skip Routine
                        Else
                            'Serial Line Query into datagrid
                            SerialInvoiceNumber = InvoiceNumber

                            ShowSerialLines()

                            'Declare Serial Line Variables
                            Dim SerialInvoiceLineNumber As Integer = 0
                            Dim SerialNumber As String = ""
                            Dim SerialCustomer As String = ""
                            Dim SerialPartNumber As String = ""

                            'Get Datagrid Lines and update Serial Assembly Log
                            For Each row5 As DataGridViewRow In dgvInvoiceSerialLines.Rows
                                Try
                                    SerialInvoiceLineNumber = row5.Cells("SNInvoiceLineColumn").Value
                                Catch ex As Exception
                                    SerialInvoiceLineNumber = 0
                                End Try
                                Try
                                    SerialNumber = row5.Cells("SNInvoiceSerialNumberColumn").Value
                                Catch ex As Exception
                                    SerialNumber = ""
                                End Try
                                Try
                                    SerialCustomer = row5.Cells("SNCustomerIDColumn").Value
                                Catch ex As Exception
                                    SerialCustomer = ""
                                End Try
                                Try
                                    SerialPartNumber = row5.Cells("SNPartNumberColumn").Value
                                Catch ex As Exception
                                    SerialPartNumber = ""
                                End Try

                                If SerialNumber <> "" Then
                                    'Check to see if invoice is a credit
                                    'If Invoice is a credit, change assembly log status to open
                                    If InvoiceTotal > 0 Then
                                        SerialStatus = "CLOSED"
                                    ElseIf InvoiceTotal = 0 Then
                                        'Check to see if it is a return (zero dollar)
                                        If ShipmentNumber >= 7500000 And ShipmentNumber < 8000000 Then
                                            SerialStatus = "OPEN"
                                        Else
                                            SerialStatus = "CLOSED"
                                        End If
                                    Else
                                        SerialStatus = "OPEN"
                                    End If

                                    'Update Serial Log
                                    Try
                                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, CustomerID = @CustomerID, BatchNumber = @BatchNumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = SerialPartNumber
                                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                            .Add("@CustomerID", SqlDbType.VarChar).Value = SerialCustomer
                                            .Add("@BatchNumber", SqlDbType.VarChar).Value = SerialInvoiceLineNumber
                                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = SerialInvoiceNumber
                                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@Status", SqlDbType.VarChar).Value = SerialStatus
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex6 As Exception
                                        'Shipment Status Update
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(SerialInvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex6.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch --- Update Serial Log Fail"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber + " -- Serial # - " + SerialNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                Else
                                    'Skip - no serial number
                                End If

                                'Clear Serial Variables
                                SerialNumber = ""
                                SerialPartNumber = ""
                                SerialInvoiceLineNumber = 0
                                SerialCustomer = ""
                                SerialStatus = ""
                            Next
                        End If
                        '****************************************************************************************************

                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    Case "NormalAmerican"
                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'Freight Routine for American Divisions
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                        If BilledFreight > 0 Then
                            Try
                                'CREDIT ENTRY ****************************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "49500"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Freight Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch ---  Normal Add Freight Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf BilledFreight < 0 Then
                            'Convert freight
                            BilledFreightPositive = BilledFreight * -1

                            Try
                                'DEBIT ENTRY *********************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "49500"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Freight Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch ---  Normal Add Freight CR Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Continue
                        End If

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'End of Freight Routine for American Billing
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                        '*********************************************************************************************
                        'Sales Tax Routine - For American Customers
                        '*********************************************************************************************

                        If SalesTax > 0 Then
                            Try
                                'CREDIT ENTRY **********************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "25000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch ---  Normal Add Tax Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf SalesTax < 0 Then
                            'Convert Sales Tax to positive before reversing the entry
                            SalesTaxPositive = SalesTax * -1

                            Try
                                'DEBIT ENTRY *********************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "25000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch ---  Normal Add Tax CR Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Do nothing and continue
                        End If

                        '*********************************************************************************************
                        'End of Sales Tax Routine For American Customers
                        '*********************************************************************************************

                        '*********************************************************************************************
                        'Line Routine - writing line items from the invoice to the database for American Billing
                        '*********************************************************************************************

                        'Count the number of line items
                        Dim CountLineStatement As String = "SELECT COUNT(InvoiceHeaderKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                        Dim CountLineCommand As New SqlCommand(CountLineStatement, con)
                        CountLineCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                        CountLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountLineNumber = CInt(CountLineCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountLineNumber = 1
                        End Try
                        con.Close()

                        'Initialize first line number
                        InvoiceLine = 1

                        'Writes Line GL Entries for each Invoice to the GL
                        For i As Integer = 1 To CountLineNumber
                            'Extract data from Invoice Line Table

                            'Clear Variables before use
                            ExtendedAmount = 0
                            ExtendedCOS = 0

                            Dim ExtendedAmountStatement As String = "SELECT ExtendedAmount FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim ExtendedAmountCommand As New SqlCommand(ExtendedAmountStatement, con)
                            ExtendedAmountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            ExtendedAmountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartNumberStatement As String = "SELECT PartNumber FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartNumberCommand As New SqlCommand(PartNumberStatement, con)
                            PartNumberCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartNumberCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim DebitGLAccountStatement As String = "SELECT DebitGLAccount FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim DebitGLAccountCommand As New SqlCommand(DebitGLAccountStatement, con)
                            DebitGLAccountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            DebitGLAccountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim CreditGLAccountStatement As String = "SELECT CreditGLAccount FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim CreditGLAccountCommand As New SqlCommand(CreditGLAccountStatement, con)
                            CreditGLAccountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            CreditGLAccountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim QuantityShippedStatement As String = "SELECT QuantityBilled FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim QuantityShippedCommand As New SqlCommand(QuantityShippedStatement, con)
                            QuantityShippedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            QuantityShippedCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartDescriptionStatement As String = "SELECT PartDescription FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
                            PartDescriptionCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartDescriptionCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PriceStatement As String = "SELECT Price FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PriceCommand As New SqlCommand(PriceStatement, con)
                            PriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PriceCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim ExtendedCOSStatement As String = "SELECT ExtendedCOS FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim ExtendedCOSCommand As New SqlCommand(ExtendedCOSStatement, con)
                            ExtendedCOSCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            ExtendedCOSCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ExtendedAmount = CDbl(ExtendedAmountCommand.ExecuteScalar)
                            Catch ex As Exception
                                ExtendedAmount = 0
                            End Try
                            Try
                                PartNumber = CStr(PartNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartNumber = ""
                            End Try
                            Try
                                DebitGLAccount = CStr(DebitGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                DebitGLAccount = ""
                            End Try
                            Try
                                CreditGLAccount = CStr(CreditGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                CreditGLAccount = ""
                            End Try
                            Try
                                QuantityShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
                            Catch ex As Exception
                                QuantityShipped = 0
                            End Try
                            Try
                                PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartDescription = ""
                            End Try
                            Try
                                Price = CDbl(PriceCommand.ExecuteScalar)
                            Catch ex As Exception
                                Price = 0
                            End Try
                            Try
                                ExtendedCOS = CDbl(ExtendedCOSCommand.ExecuteScalar)
                            Catch ex As Exception
                                ExtendedCOS = 0
                            End Try
                            con.Close()

                            'Round dollars to two decimals
                            ExtendedCOS = Math.Round(ExtendedCOS, 2)
                            ExtendedAmount = Math.Round(ExtendedAmount, 2)

                            LineItemCost = ExtendedCOS / QuantityShipped

                            'Extract GL Account Numbers for Revenues and AR Accounts by Item Class
                            Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
                            ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ItemClass = CStr(ItemClassCommand.ExecuteScalar)
                            Catch ex As Exception
                                ItemClass = ""
                            End Try
                            con.Close()

                            Dim RevenueGLAccountStatement As String = "SELECT GLSalesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                            Dim RevenueGLAccountCommand As New SqlCommand(RevenueGLAccountStatement, con)
                            RevenueGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                            Dim COSGLAccountStatement As String = "SELECT GLCOGSAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                            Dim COSGLAccountCommand As New SqlCommand(COSGLAccountStatement, con)
                            COSGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                RevenueGLAccount = CStr(RevenueGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                RevenueGLAccount = "41000"
                            End Try
                            Try
                                COSGLAccount = CStr(COSGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                COSGLAccount = "51000"
                            End Try
                            con.Close()
                            '****************************************************************************************************
                            'If Invoice is a DROP SHIP, use the Drop Ship Clearing Account
                            If DropShipPONumber > 0 Then
                                DebitGLAccount = "20990"
                            Else
                                DebitGLAccount = "49999"
                            End If
                            '*******************************************************************************************************
                            'Check to see if Part Number is Freight or Sales Tax
                            If PartNumber = "SALES TAX" Then
                                'Get GL Accounts based on Division and Customer Class
                                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "AMERICAN" Then
                                    ARAccount = "11000"
                                    TaxAccount = "23100"
                                ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "CANADIAN" Then
                                    ARAccount = "C$11000"
                                    TaxAccount = "C$23100"
                                Else
                                    ARAccount = "11000"
                                    TaxAccount = "25000"
                                End If

                                If ExtendedAmount < 0 Then
                                    'Convert Extended Amount to a positive and reverse GL
                                    ExtendedAmountPositive = ExtendedAmount * -1

                                    Try
                                        'CREDIT ENTRY ****************************************************************************************************
                                        'Command to write Sales Tax Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Sales Tax"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                        'DEBIT ENTRY ****************************************************************************************************
                                        'Command to write LineAmount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Sales Tax"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Add Line Tax Error
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(InvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch ---  Normal Add Line Tax CR Failure"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                Else
                                    Try
                                        'DEBIT ENTRY ****************************************************************************************************
                                        'Command to write Sales Tax Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Sales Tax"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                        'CREDIT ENTRY ****************************************************************************************************
                                        'Command to write LineAmount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Sales Tax"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Add Line Tax Error
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(InvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch ---  Normal Add Line Tax Failure"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                End If
                            ElseIf PartNumber = "FREIGHT" Then
                                'Get GL Accounts based on Division and Customer Class
                                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "AMERICAN" Then
                                    ARAccount = "11000"
                                    FreightGLAccount = "49500"
                                ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "CANADIAN" Then
                                    ARAccount = "C$11000"
                                    FreightGLAccount = "C$49500"
                                Else
                                    ARAccount = "11000"
                                    FreightGLAccount = "49500"
                                End If

                                'Check to see if Freight is a credit
                                If ExtendedAmount < 0 Then
                                    'Convert Extended Amount to a positive and reverse GL
                                    ExtendedAmountPositive = ExtendedAmount * -1

                                    Try
                                        'CREDIT ENTRY ****************************************************************************************************
                                        'Command to write Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Freight Billed"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                        'DEBIT ENTRY ****************************************************************************************************
                                        'Command to write Freight Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Freight Billed"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Add Line Freight Error
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(InvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch ---  Normal Add Line Freight CR Failure"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                Else
                                    Try
                                        'DEBIT ENTRY ****************************************************************************************************
                                        'Command to write Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Freight Billed"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                        'CREDIT ENTRY ****************************************************************************************************
                                        'Command to write Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Freight Billed"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Add Line Freight Error
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(InvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch ---  Normal Add Line Freight Failure"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                End If
                            Else   'Routine to run for normal part numbers on lines
                                'Line cost is based on preferred Vendor source of the Item for Canadian customers
                                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                                    'Get GL Accounts based on the part number for the costing side
                                    Dim PreferredVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                                    Dim PreferredVendorCommand As New SqlCommand(PreferredVendorStatement, con)
                                    PreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                                    PreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        PreferredVendor = CStr(PreferredVendorCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        PreferredVendor = ""
                                    End Try
                                    con.Close()

                                    If PreferredVendor = "AMERICAN" Or PreferredVendor = "CANADIAN" Then
                                        VendorClass = PreferredVendor
                                    ElseIf PreferredVendor = "" Then
                                        VendorClass = "CANADIAN"
                                    Else
                                        Dim GetVendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                                        Dim GetVendorClassCommand As New SqlCommand(GetVendorClassStatement, con)
                                        GetVendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = PreferredVendor
                                        GetVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            VendorClass = CStr(GetVendorClassCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            VendorClass = "CANADIAN"
                                        End Try
                                        con.Close()
                                    End If

                                    'Get GL Accounts based on Division and Customer Class for the Sales Side
                                    If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "AMERICAN" Then
                                        ARAccount = "11000"
                                        'Revenue Account is correct
                                    ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "CANADIAN" Then
                                        ARAccount = "C$11000"
                                        RevenueGLAccount = "C$" & RevenueGLAccount
                                    Else
                                        ARAccount = "11000"
                                        RevenueGLAccount = "41000"
                                    End If

                                    'Get GL Accounts based on Division and Vendor Class for the Costing Side
                                    If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "AMERICAN" Then
                                        'COGS Account is correct
                                        'Debit GL Account is correct
                                    ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                        COSGLAccount = "C$" & COSGLAccount
                                        DebitGLAccount = "C$" & DebitGLAccount
                                    Else
                                        'COGS Account is correct
                                        'Debit GL Account is correct
                                    End If

                                    'Check to see if it is a credit
                                    If ExtendedAmount >= 0 Then
                                        Try
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()

                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch ---  Normal Add Line Item (REVENUES) Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                        Try
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOS
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOS
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch ---  Normal Add Line Item (COS) Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                    ElseIf ExtendedAmount < 0 Then
                                        'Convert to Positive before reversing entry
                                        ExtendedAmountPositive = ExtendedAmount * -1
                                        ExtendedCOSPositive = ExtendedCOS * -1

                                        Try
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch ---  Normal Add Line Item (REVENUES CR) Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                        Try
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch ---  Normal Add Line Item (COS CR) Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                    End If
                                Else '*************************************American Line Routine************************************************
                                    'Check to see if it is a credit
                                    If ExtendedAmount >= 0 Then
                                        Try
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch ---  Normal Add Line Item (REVENUES) Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                        Try
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOS
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOS
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch ---  Normal Add Line Item (COS) Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                    ElseIf ExtendedAmount < 0 Then
                                        'Convert to Positive before reversing entry
                                        ExtendedAmountPositive = ExtendedAmount * -1
                                        ExtendedCOSPositive = ExtendedCOS * -1

                                        Try
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch ---  Normal Add Line Item (REVENUES CR) Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                        Try
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch ---  Normal Add Line Item (COS CR) Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                    End If
                                End If
                            End If
                            '****************************************************************************************************
                            Try
                                'Update COS to Invoice Line Table
                                cmd = New SqlCommand("UPDATE InvoiceLineTable SET ExtendedCOS = @ExtendedCOS, LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                                With cmd.Parameters
                                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Retotal Invoice Line Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Invoice Line Retotal Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try

                            InvoiceLine = InvoiceLine + 1
                        Next i
                        '****************************************************************************************************
                        'Serial Number Routine for TWE

                        'Check to see if Invoice Serial Lines need to be updated
                        Dim CountSerialLines As Integer = 0

                        Dim CountSerialLinesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber"
                        Dim CountSerialLinesCommand As New SqlCommand(CountSerialLinesStatement, con)
                        CountSerialLinesCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountSerialLines = CInt(CountSerialLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountSerialLines = 0
                        End Try
                        con.Close()

                        If CountSerialLines = 0 Then
                            'Skip Routine
                        Else
                            'Serial Line Query into datagrid
                            SerialInvoiceNumber = InvoiceNumber

                            ShowSerialLines()

                            'Declare Serial Line Variables
                            Dim SerialInvoiceLineNumber As Integer = 0
                            Dim SerialNumber As String = ""
                            Dim SerialCustomer As String = ""
                            Dim SerialPartNumber As String = ""

                            'Get Datagrid Lines and update Serial Assembly Log
                            For Each row5 As DataGridViewRow In dgvInvoiceSerialLines.Rows
                                Try
                                    SerialInvoiceLineNumber = row5.Cells("SNInvoiceLineColumn").Value
                                Catch ex As Exception
                                    SerialInvoiceLineNumber = 0
                                End Try
                                Try
                                    SerialNumber = row5.Cells("SNInvoiceSerialNumberColumn").Value
                                Catch ex As Exception
                                    SerialNumber = ""
                                End Try
                                Try
                                    SerialCustomer = row5.Cells("SNCustomerIDColumn").Value
                                Catch ex As Exception
                                    SerialCustomer = ""
                                End Try
                                Try
                                    SerialPartNumber = row5.Cells("SNPartNumberColumn").Value
                                Catch ex As Exception
                                    SerialPartNumber = ""
                                End Try

                                If SerialNumber <> "" Then
                                    'Check to see if invoice is a credit
                                    'If Invoice is a credit, change assembly log status to open
                                    If InvoiceTotal > 0 Then
                                        SerialStatus = "CLOSED"
                                    ElseIf InvoiceTotal = 0 Then
                                        'Check to see if it is a return (zero dollar)
                                        If ShipmentNumber >= 7500000 And ShipmentNumber < 8000000 Then
                                            SerialStatus = "OPEN"
                                        Else
                                            SerialStatus = "CLOSED"
                                        End If
                                    Else
                                        SerialStatus = "OPEN"
                                    End If

                                    'Update Serial Log
                                    Try
                                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, CustomerID = @CustomerID, BatchNumber = @BatchNumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = SerialPartNumber
                                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                            .Add("@CustomerID", SqlDbType.VarChar).Value = SerialCustomer
                                            .Add("@BatchNumber", SqlDbType.VarChar).Value = SerialInvoiceLineNumber
                                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = SerialInvoiceNumber
                                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@Status", SqlDbType.VarChar).Value = SerialStatus
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex6 As Exception
                                        'Shipment Status Update
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(SerialInvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex6.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch --- Update Serial Log Fail"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber + " -- Serial # - " + SerialNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                Else
                                    'Skip - no serial number
                                End If

                                'Clear Serial Variables
                                SerialNumber = ""
                                SerialPartNumber = ""
                                SerialInvoiceLineNumber = 0
                                SerialCustomer = ""
                                SerialStatus = ""
                            Next
                        End If
                        '****************************************************************************************************

                        '*************************************************************************************************************************
                        'End of Line Routine Anerican
                        '*************************************************************************************************************************

                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    Case "NormalCanadian"
                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'Freight Routine for Canadian Divisions
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                        If CustomerClass = "AMERICAN" Then
                            FreightGLAccount = "49500"
                            ARAccount = "11000"
                        ElseIf CustomerClass = "SRL" And FOB = "TFF" Then
                            FreightGLAccount = "49500"
                            ARAccount = "11000"
                        ElseIf CustomerClass = "SRL" And FOB = "SRL" Then
                            TaxAccount = "C$49500"
                            ARAccount = "C$11000"
                        Else
                            FreightGLAccount = "C$49500"
                            ARAccount = "C$11000"
                        End If

                        If BilledFreight > 0 Then
                            Try
                                'CREDIT ENTRY ************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreight
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Freight Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Freight Canadian Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf BilledFreight < 0 Then
                            'Convert Freight
                            BilledFreightPositive = BilledFreight * -1

                            Try
                                'DEBIT ENTRY **********************************************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    ''.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Freight Charges to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreightPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Freight Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Freight CR Canadian Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Continue
                        End If

                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                        'End of Freight Routine for Canadian Customers
                        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                        '*********************************************************************************************
                        'Sales Tax Routine - For Canadian Customers
                        '*********************************************************************************************

                        If CustomerClass = "AMERICAN" Then
                            TaxAccount = "23100"
                            ARAccount = "11000"
                        ElseIf CustomerClass = "SRL" And FOB = "TFF" Then
                            TaxAccount = "23100"
                            ARAccount = "11000"
                        ElseIf CustomerClass = "SRL" And FOB = "SRL" Then
                            TaxAccount = "C$23100"
                            ARAccount = "C$11000"
                        Else
                            TaxAccount = "C$23100"
                            ARAccount = "C$11000"
                        End If

                        If SalesTax > 0 Then
                            Try
                                'CREDIT ENTRY *********************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - GST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - GST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax Canadian Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf SalesTax < 0 Then
                            'Convert Sales Tax to positive before reversing the entry
                            SalesTaxPositive = SalesTax * -1

                            Try
                                'DEBIT ENTRY ******************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - GST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - GST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax CR Canadian Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Do nothing and continue
                        End If

                        If CustomerClass = "AMERICAN" Then
                            TaxAccount = "23150"
                            ARAccount = "11000"
                        ElseIf CustomerClass = "SRL" And FOB = "TFF" Then
                            TaxAccount = "23150"
                            ARAccount = "11000"
                        ElseIf CustomerClass = "SRL" And FOB = "SRL" Then
                            TaxAccount = "C$23150"
                            ARAccount = "C$11000"
                        Else
                            TaxAccount = "C$23150"
                            ARAccount = "C$11000"
                        End If

                        If SalesTax2 > 0 Then
                            Try
                                'CREDIT ENTRY ***********************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax2
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax2
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax 2 Canadian Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf SalesTax2 < 0 Then
                            'Convert Sales Tax to positive before reversing the entry
                            SalesTaxPositive = SalesTax2 * -1

                            Try
                                '****************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '**********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax 2 CR Canadian Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Do nothing and continue
                        End If

                        If CustomerClass = "AMERICAN" Then
                            TaxAccount = "23120"
                            ARAccount = "11000"
                        ElseIf CustomerClass = "SRL" And FOB = "TFF" Then
                            TaxAccount = "23120"
                            ARAccount = "11000"
                        ElseIf CustomerClass = "SRL" And FOB = "SRL" Then
                            TaxAccount = "C$23120"
                            ARAccount = "C$11000"
                        Else
                            TaxAccount = "C$23120"
                            ARAccount = "C$11000"
                        End If

                        If SalesTax3 > 0 Then
                            Try
                                'CREDIT ENTRY **********************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax3
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'DEBIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax3
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax 3 Canadian Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        ElseIf SalesTax3 < 0 Then
                            'Convert Sales Tax to positive before reversing the entry
                            SalesTaxPositive = SalesTax3 * -1

                            Try
                                'DEBIT ENTRY ************************************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'CREDIT ENTRY **********************************************************************
                                'Command to write Sales Tax to GL
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTaxPositive
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Add Tax Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Add Tax 3 CR Canadian Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            'Do nothing and continue
                        End If

                        '*********************************************************************************************
                        'End of Sales Tax Routine For Canadian Customers
                        '*********************************************************************************************

                        '*********************************************************************************************
                        'Line Routine - writing line items from the invoice to the database for Canadian Billing
                        '*********************************************************************************************

                        'Count the number of line items
                        Dim CountLineStatement As String = "SELECT COUNT(InvoiceHeaderKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                        Dim CountLineCommand As New SqlCommand(CountLineStatement, con)
                        CountLineCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                        CountLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountLineNumber = CInt(CountLineCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountLineNumber = 1
                        End Try
                        con.Close()

                        'Initialize first line number
                        InvoiceLine = 1

                        'Writes Line GL Entries for each Invoice to the GL
                        For i As Integer = 1 To CountLineNumber
                            'Extract data from Invoice Line Table

                            'Clear Variables before use
                            ExtendedAmount = 0
                            ExtendedCOS = 0

                            Dim ExtendedAmountStatement As String = "SELECT ExtendedAmount FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim ExtendedAmountCommand As New SqlCommand(ExtendedAmountStatement, con)
                            ExtendedAmountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            ExtendedAmountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartNumberStatement As String = "SELECT PartNumber FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartNumberCommand As New SqlCommand(PartNumberStatement, con)
                            PartNumberCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartNumberCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim DebitGLAccountStatement As String = "SELECT DebitGLAccount FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim DebitGLAccountCommand As New SqlCommand(DebitGLAccountStatement, con)
                            DebitGLAccountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            DebitGLAccountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim CreditGLAccountStatement As String = "SELECT CreditGLAccount FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim CreditGLAccountCommand As New SqlCommand(CreditGLAccountStatement, con)
                            CreditGLAccountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            CreditGLAccountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim QuantityShippedStatement As String = "SELECT QuantityBilled FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim QuantityShippedCommand As New SqlCommand(QuantityShippedStatement, con)
                            QuantityShippedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            QuantityShippedCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PartDescriptionStatement As String = "SELECT PartDescription FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
                            PartDescriptionCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PartDescriptionCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim PriceStatement As String = "SELECT Price FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim PriceCommand As New SqlCommand(PriceStatement, con)
                            PriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            PriceCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            Dim ExtendedCOSStatement As String = "SELECT ExtendedCOS FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim ExtendedCOSCommand As New SqlCommand(ExtendedCOSStatement, con)
                            ExtendedCOSCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                            ExtendedCOSCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ExtendedAmount = CDbl(ExtendedAmountCommand.ExecuteScalar)
                            Catch ex As Exception
                                ExtendedAmount = 0
                            End Try
                            Try
                                PartNumber = CStr(PartNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartNumber = ""
                            End Try
                            Try
                                DebitGLAccount = CStr(DebitGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                DebitGLAccount = ""
                            End Try
                            Try
                                CreditGLAccount = CStr(CreditGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                CreditGLAccount = ""
                            End Try
                            Try
                                QuantityShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
                            Catch ex As Exception
                                QuantityShipped = 0
                            End Try
                            Try
                                PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
                            Catch ex As Exception
                                PartDescription = ""
                            End Try
                            Try
                                Price = CDbl(PriceCommand.ExecuteScalar)
                            Catch ex As Exception
                                Price = 0
                            End Try
                            Try
                                ExtendedCOS = CDbl(ExtendedCOSCommand.ExecuteScalar)
                            Catch ex As Exception
                                ExtendedCOS = 0
                            End Try
                            con.Close()

                            'Round dollars to two decimals
                            ExtendedCOS = Math.Round(ExtendedCOS, 2)
                            ExtendedAmount = Math.Round(ExtendedAmount, 2)

                            LineItemCost = ExtendedCOS / QuantityShipped

                            'Extract GL Account Numbers for Revenues and AR Accounts by Item Class
                            Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
                            ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ItemClass = CStr(ItemClassCommand.ExecuteScalar)
                            Catch ex As Exception
                                ItemClass = ""
                            End Try
                            con.Close()

                            Dim RevenueGLAccountStatement As String = "SELECT GLSalesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                            Dim RevenueGLAccountCommand As New SqlCommand(RevenueGLAccountStatement, con)
                            RevenueGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                            Dim COSGLAccountStatement As String = "SELECT GLCOGSAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                            Dim COSGLAccountCommand As New SqlCommand(COSGLAccountStatement, con)
                            COSGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                RevenueGLAccount = CStr(RevenueGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                RevenueGLAccount = "41000"
                            End Try
                            Try
                                COSGLAccount = CStr(COSGLAccountCommand.ExecuteScalar)
                            Catch ex As Exception
                                COSGLAccount = "51000"
                            End Try
                            con.Close()
                            '****************************************************************************************************
                            'If Invoice is a DROP SHIP, use the Drop Ship Clearing Account
                            If DropShipPONumber > 0 Then
                                DebitGLAccount = "20990"
                            Else
                                DebitGLAccount = "49999"
                            End If
                            '*******************************************************************************************************
                            'Check to see if Part Number is Freight or Sales Tax
                            If PartNumber = "SALES TAX" Then
                                'Get GL Accounts based on Division and Customer Class
                                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "AMERICAN" Then
                                    ARAccount = "11000"
                                    TaxAccount = "23100"
                                ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "CANADIAN" Then
                                    ARAccount = "C$11000"
                                    TaxAccount = "C$23100"
                                Else
                                    ARAccount = "11000"
                                    TaxAccount = "25000"
                                End If

                                If ExtendedAmount < 0 Then
                                    'Convert Extended Amount to a positive and reverse GL
                                    ExtendedAmountPositive = ExtendedAmount * -1

                                    Try
                                        'CREDIT ENTRY ****************************************************************************************************
                                        'Command to write Sales Tax Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Sales Tax"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                        'DEBIT ENTRY ****************************************************************************************************
                                        'Command to write LineAmount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Sales Tax"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Add Line Tax Error
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(InvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch --- Add Line Tax CR Canadian Failure"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                Else
                                    Try
                                        'DEBIT ENTRY ****************************************************************************************************
                                        'Command to write Sales Tax Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Sales Tax"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                        'CREDIT ENTRY ****************************************************************************************************
                                        'Command to write LineAmount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = TaxAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Sales Tax"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Add Line Tax Error
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(InvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch --- Add Line Tax Canadian Failure"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                End If
                            ElseIf PartNumber = "FREIGHT" Then
                                'Get GL Accounts based on Division and Customer Class
                                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "AMERICAN" Then
                                    ARAccount = "11000"
                                    FreightGLAccount = "49500"
                                ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "CANADIAN" Then
                                    ARAccount = "C$11000"
                                    FreightGLAccount = "C$49500"
                                Else
                                    ARAccount = "11000"
                                    FreightGLAccount = "49500"
                                End If

                                'Check to see if Freight is a credit
                                If ExtendedAmount < 0 Then
                                    'Convert Extended Amount to a positive and reverse GL
                                    ExtendedAmountPositive = ExtendedAmount * -1

                                    Try
                                        'CREDIT ENTRY ****************************************************************************************************
                                        'Command to write Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Freight Billed"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                        'DEBIT ENTRY ****************************************************************************************************
                                        'Command to write Freight Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Freight Billed"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Add Line Freight Error
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(InvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch --- Add Line Freight CR Canadian Failure"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                Else
                                    Try
                                        'DEBIT ENTRY ****************************************************************************************************
                                        'Command to write Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Freight Billed"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                        'CREDIT ENTRY ****************************************************************************************************
                                        'Command to write Line Amount to GL - Sales/AR
                                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                        With cmd.Parameters
                                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data - Freight Billed"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Add Line Freight Error
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(InvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch --- Add Line Freight Canadian Failure"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                End If
                            Else   'Routine to run for normal part numbers on lines
                                'Line cost is based on preferred Vendor source of the Item for Canadian customers
                                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                                    'Get GL Accounts based on the part number for the costing side
                                    Dim PreferredVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                                    Dim PreferredVendorCommand As New SqlCommand(PreferredVendorStatement, con)
                                    PreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                                    PreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        PreferredVendor = CStr(PreferredVendorCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        PreferredVendor = ""
                                    End Try
                                    con.Close()

                                    If PreferredVendor = "AMERICAN" Or PreferredVendor = "CANADIAN" Then
                                        VendorClass = PreferredVendor
                                    ElseIf PreferredVendor = "" Then
                                        VendorClass = "CANADIAN"
                                    Else
                                        Dim GetVendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                                        Dim GetVendorClassCommand As New SqlCommand(GetVendorClassStatement, con)
                                        GetVendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = PreferredVendor
                                        GetVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            VendorClass = CStr(GetVendorClassCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            VendorClass = "CANADIAN"
                                        End Try
                                        con.Close()
                                    End If

                                    'Get GL Accounts based on Division and Customer Class for the Sales Side
                                    If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "AMERICAN" Then
                                        ARAccount = "11000"
                                        'Revenue Account is correct
                                    ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And CustomerClass = "CANADIAN" Then
                                        ARAccount = "C$11000"
                                        RevenueGLAccount = "C$" & RevenueGLAccount
                                    Else
                                        ARAccount = "11000"
                                        RevenueGLAccount = "41000"
                                    End If

                                    'Get GL Accounts based on Division and Vendor Class for the Costing Side
                                    If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "AMERICAN" Then
                                        'COGS Account is correct
                                        'Debit GL Account is correct
                                    ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                        COSGLAccount = "C$" & COSGLAccount
                                        DebitGLAccount = "C$" & DebitGLAccount
                                    Else
                                        'COGS Account is correct
                                        'Debit GL Account is correct
                                    End If

                                    'Assign Accounts if this is a Canadian Consignment Bill for a return
                                    If cboDivisionID.Text = "TFF" And CustomerClass = "SRL" And FOB = "TFF" Then
                                        COSGLAccount = "52670"
                                        DebitGLAccount = "51000"
                                        ARAccount = "11000"
                                        RevenueGLAccount = "41000"
                                    End If
                                    If cboDivisionID.Text = "TFF" And CustomerClass = "SRL" And FOB = "SRL" Then
                                        COSGLAccount = "52670"
                                        DebitGLAccount = "49999"
                                        ARAccount = "C$11000"
                                        RevenueGLAccount = "C$42670"
                                    End If

                                    'Check to see if it is a credit
                                    If ExtendedAmount >= 0 Then
                                        Try
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Freight Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch --- Add Line Item (REVENUES) Canadian Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                        Try
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOS
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOS
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch --- Add Line Item (COS) Canadian Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                    ElseIf ExtendedAmount < 0 Then
                                        'Convert to Positive before reversing entry
                                        ExtendedAmountPositive = ExtendedAmount * -1
                                        ExtendedCOSPositive = ExtendedCOS * -1

                                        Try
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch --- Add Line Item (REVENUES CR) Canadian Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                        Try
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch --- Add Line Item (COS CR) Canadian Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                    End If
                                Else '*************************************American Line Routine************************************************
                                    'Check to see if it is a credit
                                    If ExtendedAmount >= 0 Then
                                        Try
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch --- Add Line Item (REVENUES) Canadian Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                        Try
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOS
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOS
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch --- Add Line Item (COS) Canadian Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                    ElseIf ExtendedAmount < 0 Then
                                        'Convert to Positive before reversing entry
                                        ExtendedAmountPositive = ExtendedAmount * -1
                                        ExtendedCOSPositive = ExtendedCOS * -1

                                        Try
                                            'CREDIT ENTRY ****************************************************************************************************
                                            'Command to write Line Amount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "11000"
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            'DEBIT ENTRY ****************************************************************************************************
                                            'Command to write LineAmount to GL - Sales/AR
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmountPositive
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch --- Add Line Item (REVENUES CR) Canadian Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                        Try
                                            '****************************************************************************************************
                                            'Command to write Line Amount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = COSGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                            '****************************************************************************************************
                                            'Command to write LineAmount to GL - Inventory/Sales Clearing
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedCOSPositive
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Memo Line Data"
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            'Add Line Item Error
                                            Dim strInvoiceNumber As String = ""

                                            strInvoiceNumber = CStr(InvoiceNumber)

                                            ErrorDate = Today()
                                            ErrorComment = ex.ToString()
                                            ErrorDivision = cboDivisionID.Text
                                            ErrorDescription = "Process AR Batch --- Add Line Item (COS CR) Canadian Failure"
                                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                            ErrorUser = EmployeeLoginName

                                            TFPErrorLogUpdate()
                                        End Try
                                    End If
                                End If
                            End If
                            '****************************************************************************************************
                            Try
                                'Update COS to Invoice Line Table
                                cmd = New SqlCommand("UPDATE InvoiceLineTable SET ExtendedCOS = @ExtendedCOS, LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                                With cmd.Parameters
                                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Retotal Invoice Line Error
                                Dim strInvoiceNumber As String = ""

                                strInvoiceNumber = CStr(InvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Process AR Batch --- Invoice Line Retotal Failure"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try

                            InvoiceLine = InvoiceLine + 1
                        Next i
                        '****************************************************************************************************
                        'Serial Number Routine for TWE

                        'Check to see if Invoice Serial Lines need to be updated
                        Dim CountSerialLines As Integer = 0

                        Dim CountSerialLinesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber"
                        Dim CountSerialLinesCommand As New SqlCommand(CountSerialLinesStatement, con)
                        CountSerialLinesCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountSerialLines = CInt(CountSerialLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountSerialLines = 0
                        End Try
                        con.Close()

                        If CountSerialLines = 0 Then
                            'Skip Routine
                        Else
                            'Serial Line Query into datagrid
                            SerialInvoiceNumber = InvoiceNumber

                            ShowSerialLines()

                            'Declare Serial Line Variables
                            Dim SerialInvoiceLineNumber As Integer = 0
                            Dim SerialNumber As String = ""
                            Dim SerialCustomer As String = ""
                            Dim SerialPartNumber As String = ""

                            'Get Datagrid Lines and update Serial Assembly Log
                            For Each row5 As DataGridViewRow In dgvInvoiceSerialLines.Rows
                                Try
                                    SerialInvoiceLineNumber = row5.Cells("SNInvoiceLineColumn").Value
                                Catch ex As Exception
                                    SerialInvoiceLineNumber = 0
                                End Try
                                Try
                                    SerialNumber = row5.Cells("SNInvoiceSerialNumberColumn").Value
                                Catch ex As Exception
                                    SerialNumber = ""
                                End Try
                                Try
                                    SerialCustomer = row5.Cells("SNCustomerIDColumn").Value
                                Catch ex As Exception
                                    SerialCustomer = ""
                                End Try
                                Try
                                    SerialPartNumber = row5.Cells("SNPartNumberColumn").Value
                                Catch ex As Exception
                                    SerialPartNumber = ""
                                End Try

                                If SerialNumber <> "" Then
                                    'Check to see if invoice is a credit
                                    'If Invoice is a credit, change assembly log status to open
                                    If InvoiceTotal > 0 Then
                                        SerialStatus = "CLOSED"
                                    ElseIf InvoiceTotal = 0 Then
                                        'Check to see if it is a return (zero dollar)
                                        If ShipmentNumber >= 7500000 And ShipmentNumber < 8000000 Then
                                            SerialStatus = "OPEN"
                                        Else
                                            SerialStatus = "CLOSED"
                                        End If
                                    Else
                                        SerialStatus = "OPEN"
                                    End If

                                    'Update Serial Log
                                    Try
                                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, CustomerID = @CustomerID, BatchNumber = @BatchNumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = SerialPartNumber
                                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = FOB
                                            .Add("@CustomerID", SqlDbType.VarChar).Value = SerialCustomer
                                            .Add("@BatchNumber", SqlDbType.VarChar).Value = SerialInvoiceLineNumber
                                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = SerialInvoiceNumber
                                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                                            .Add("@Status", SqlDbType.VarChar).Value = SerialStatus
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex6 As Exception
                                        'Shipment Status Update
                                        Dim strInvoiceNumber As String = ""

                                        strInvoiceNumber = CStr(SerialInvoiceNumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex6.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Process AR Batch --- Update Serial Log Fail"
                                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber + " -- Serial # - " + SerialNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                Else
                                    'Skip - no serial number
                                End If

                                'Clear Serial Variables
                                SerialNumber = ""
                                SerialPartNumber = ""
                                SerialInvoiceLineNumber = 0
                                SerialCustomer = ""
                                SerialStatus = ""
                            Next
                        End If
                        '****************************************************************************************************

                        '*************************************************************************************************************************
                        'End of Line Routine Canadian
                        '*************************************************************************************************************************
                End Select

                '*************************************************************************************************************************
                'UPDATE ALL TOTALS FOR ALL BILLING SCENARIOS
                '*************************************************************************************************************************

                'Retotal Invoices
                Dim SumProductTotal As Double = 0
                SumInvoiceCOS = 0

                Dim SumProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                Dim SumProductTotalCommand As New SqlCommand(SumProductTotalStatement, con)
                SumProductTotalCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                SumProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumProductTotal = CDbl(SumProductTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    SumProductTotal = 0
                End Try
                con.Close()

                InvoiceTotal = BilledFreight + SalesTax + SalesTax2 + SalesTax3 + SumProductTotal

                'Recalculate Invoice COS
                Dim SumInvoiceCOSStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                Dim SumInvoiceCOSCommand As New SqlCommand(SumInvoiceCOSStatement, con)
                SumInvoiceCOSCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                SumInvoiceCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumInvoiceCOS = CDbl(SumInvoiceCOSCommand.ExecuteScalar)
                Catch ex As Exception
                    SumInvoiceCOS = 0
                End Try
                con.Close()

                'Round dollars to two decimals
                SumProductTotal = Math.Round(SumProductTotal, 2)
                BilledFreight = Math.Round(BilledFreight, 2)
                SalesTax = Math.Round(SalesTax, 2)
                SalesTax2 = Math.Round(SalesTax2, 2)
                SalesTax3 = Math.Round(SalesTax3, 2)
                InvoiceTotal = Math.Round(InvoiceTotal, 2)
                SumInvoiceCOS = Math.Round(SumInvoiceCOS, 2)

                'Re-total invoices before posting
                Try
                    'Total Invoices
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceTotal = InvoiceTotal, ProductTotal = @ProductTotal, InvoiceCOS = @InvoiceCOS WHERE DivisionID = @DivisionID AND InvoiceNumber = @InvoiceNumber", con)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                    cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = SumProductTotal
                    cmd.Parameters.Add("@InvoiceCOS", SqlDbType.VarChar).Value = SumInvoiceCOS

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Retotal Invoice Error
                    Dim strInvoiceNumber As String = ""

                    strInvoiceNumber = CStr(InvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Process AR Batch --- Invoice Retotal Failure"
                    ErrorReferenceNumber = "Batch # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Total Invoices
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceTotal = ProductTotal + BilledFreight + SalesTax + SalesTax2 + SalesTax3 WHERE DivisionID = @DivisionID AND InvoiceNumber = @InvoiceNumber", con)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Retotal Invoice Error
                    Dim strInvoiceNumber As String = ""

                    strInvoiceNumber = CStr(InvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Process AR Batch --- Invoice Retotal Failure"
                    ErrorReferenceNumber = "Batch # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '****************************************************************************************************************************
                'If Invoice Total is zero, close Invoice
                If InvoiceTotal = 0 Then
                    InvoiceStatus = "CLOSED"
                Else
                    InvoiceStatus = "OPEN"
                End If
                '****************************************************************************************************************************
                Try
                    'Update Invoice Header Status
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus, InvoiceTotal = ProductTotal + SalesTax + SalesTax2 + SalesTax3 + BilledFreight WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@InvoiceStatus", SqlDbType.VarChar).Value = InvoiceStatus
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Retotal Invoice Status Error
                    Dim strInvoiceNumber As String = ""

                    strInvoiceNumber = CStr(InvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Process AR Batch --- Invoice Status Update Failure"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '****************************************************************************************************************************
                Try
                    'Update Invoice Line Status
                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@LineStatus", SqlDbType.VarChar).Value = InvoiceStatus
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Retotal Invoice Line Error
                    Dim strInvoiceNumber As String = ""

                    strInvoiceNumber = CStr(InvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Process AR Batch --- Invoice Line Status Failure"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next
            '****************************************************************************************************************************
            Try
                'Save Data to Batch Header Database Table
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, UserID = @UserID, Locked = @Locked, PrintDate = @PrintDate WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@Locked", SqlDbType.VarChar).Value = ""
                    .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex9 As Exception
                'Batch Status Update
                Dim strBatchNumber As String = ""
                Dim TempBatchNumber As Integer = 0

                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex9.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Process AR Batch --- Invoice Batch Failure"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Batch has posted to the GL but failed to close. Contact System Administrator.", MsgBoxStyle.OkOnly)
            End Try
            '****************************************************************************************************************************
            'Update Shipments so they can not be invoiced again
            'Extract Line data from the datagrid
            For Each row As DataGridViewRow In dgvInvoiceHeaders.Rows
                Try
                    ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                Catch ex As Exception
                    ShipmentNumber = 0
                End Try

                If ShipmentNumber <> 0 Then
                    'Update Shipment Header Table
                    Try
                        cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex6 As Exception
                        'Shipment Status Update
                        Dim strShipNumber As String = ""

                        strShipNumber = CStr(ShipmentNumber)

                        ErrorDate = Today()
                        ErrorComment = ex6.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Process AR Batch --- Shipment Status Failure"
                        ErrorReferenceNumber = "Batch # " + strShipNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    'Skip - it's a Bill Only
                End If
            Next
            '***********************************************************************************************************
            'Check for unposted invoice (Invalid Status) and write to error log
            Dim CountPendingInvoices As Integer = 0

            Dim CountPendingInvoicesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND InvoiceStatus = @InvoiceStatus"
            Dim CountPendingInvoicesCommand As New SqlCommand(CountPendingInvoicesStatement, con)
            CountPendingInvoicesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            CountPendingInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            CountPendingInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPendingInvoices = CInt(CountPendingInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                CountPendingInvoices = 0
            End Try
            con.Close()

            If CountPendingInvoices = 0 Then
                ''Write to error log
                'Dim strBatchNumber As String = ""
                'Dim TempBatchNumber As Integer = 0

                'TempBatchNumber = Val(cboBatchNumber.Text)
                'strBatchNumber = CStr(TempBatchNumber)

                'ErrorDate = Today()
                'ErrorComment = "Invoice Batch Completed in FULL."
                'ErrorDivision = cboDivisionID.Text
                'ErrorDescription = "Process AR Batch"
                'ErrorReferenceNumber = "Batch # " + strBatchNumber
                'ErrorUser = EmployeeLoginName

                'TFPErrorLogUpdate()
            Else
                'Write to error log
                Dim strBatchNumber As String = ""
                Dim TempBatchNumber As Integer = 0

                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = "One or more invoices are pending in this batch."
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Process AR Batch"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                'Update Pending Invoices to Open
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND InvoiceStatus = 'PENDING'", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            '**************************************************************************************************
            MsgBox("Batch has been posted", MsgBoxStyle.OkOnly)

            ClearVariables()
            ClearBatch()
            LoadBatchNumber()
            ShowBatchLines()
        ElseIf button = DialogResult.No Then
            cmdPostBatch.Focus()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Determine valid Batch Number
        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                Exit Sub
            End If

            'Determine Batch Status 
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = ""
            End Try
            con.Close()

            If BatchStatus = "OPEN" Then
                'Prompt before deleting
                Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Batch?", "DELETE BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    Dim ShipmentNumber, DropShipPONumber, SONumber As Integer
                    Dim SpecialInstructions As String = ""
                    Dim FOB, CustomerClass As String
                    Dim DeleteInvoiceNumber As Integer = 0
                    Dim DeleteInvoiceTotal As Double = 0
                    Dim DeleteCustomerID As String = ""

                    For Each row As DataGridViewRow In dgvInvoiceHeaders.Rows
                        Try
                            ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                        Catch ex As Exception
                            ShipmentNumber = 0
                        End Try
                        Try
                            SpecialInstructions = row.Cells("SpecialInstructionsColumn").Value
                        Catch ex As Exception
                            SpecialInstructions = ""
                        End Try
                        Try
                            DropShipPONumber = row.Cells("DropShipPONumberColumn").Value
                        Catch ex As Exception
                            DropShipPONumber = 0
                        End Try
                        Try
                            SONumber = row.Cells("SalesOrderNumberColumn").Value
                        Catch ex As Exception
                            SONumber = 0
                        End Try
                        Try
                            CustomerClass = row.Cells("CustomerClassColumn").Value
                        Catch ex As Exception
                            CustomerClass = ""
                        End Try
                        Try
                            FOB = row.Cells("FOBColumn").Value
                        Catch ex As Exception
                            FOB = ""
                        End Try
                        Try
                            DeleteInvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                        Catch ex As Exception
                            DeleteInvoiceNumber = 0
                        End Try
                        Try
                            DeleteInvoiceTotal = row.Cells("InvoiceTotalColumn").Value
                        Catch ex As Exception
                            DeleteInvoiceTotal = 0
                        End Try
                        Try
                            DeleteCustomerID = row.Cells("CustomerIDColumn").Value
                        Catch ex As Exception
                            DeleteCustomerID = ""
                        End Try
                        '*******************************************************************************************
                        'Write to Audit Trail Table
                        Dim AuditComment As String = ""
                        Dim AuditInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String = ""

                        AuditInvoiceNumber = DeleteInvoiceNumber
                        strInvoiceNumber = CStr(AuditInvoiceNumber)
                        AuditComment = "Invoice #" + strInvoiceNumber + " for customer " + DeleteCustomerID + " was deleted on " + Today()

                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "INVOICE BATCH - DELETION"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = DeleteInvoiceTotal
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strInvoiceNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '*******************************************************************************************
                        'Check to see if there are any serial numbers on this invoice
                        Dim CountSerialNumbers As Integer = 0

                        Dim CountSerialNumbersStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber"
                        Dim CountSerialNumbersCommand As New SqlCommand(CountSerialNumbersStatement, con)
                        CountSerialNumbersCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = DeleteInvoiceNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountSerialNumbers = CInt(CountSerialNumbersCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountSerialNumbers = 0
                        End Try
                        con.Close()

                        If CountSerialNumbers = 0 Then
                            'Skip
                        Else
                            If FOB = "Medina" Or FOB = "STANDARD" Or FOB = "DROPSHIP" Then
                                'Reset Serial #'s to the division
                                'Reset Serial Numbers for Each Invoice
                                cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, DivisionID = @DivisionID, CustomerID = @CustomerID WHERE BatchNumber = @BatchNumber", con)
                                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = DeleteInvoiceNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = ""

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else
                                'Reset Serial #'s to the comsignment
                                Dim FOBDivision As String = ""

                                Select Case FOB
                                    Case "Bessemer"
                                        FOBDivision = "BCW"
                                    Case "Downey"
                                        FOBDivision = "DCW"
                                    Case "Hayward"
                                        FOBDivision = "HCW"
                                    Case "Lewisville"
                                        FOBDivision = "LCW"
                                    Case "Phoenix"
                                        FOBDivision = "PCW"
                                    Case "Seattle"
                                        FOBDivision = "SCW"
                                    Case "Lyndhurst"
                                        FOBDivision = "YCW"
                                End Select

                                'Reset Serial Numbers for Each Invoice
                                cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, DivisionID = @DivisionID, CustomerID = @CustomerID, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate WHERE TransactionNumber = @TransactionNumber", con)
                                cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = DeleteInvoiceNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = FOBDivision
                                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = 0
                                cmd.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = ""

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                        End If
                        '*******************************************************************************************
                        If DropShipPONumber > 0 And SpecialInstructions = "DROPSHIP" Then
                            'Create command to change Status of PO
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = DropShipPONumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Create command to change Status of PO Lines
                            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = DropShipPONumber
                            cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Create command to change Status of SO
                            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                            cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "DROPSHIP"

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Create command to change Status of SO Lines
                            cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Get Receiver Number to delete - stored in Pick Ticket Number column of Shipping Header Table
                            Dim ReceiverNumberStatement As String = "SELECT PickTicketNumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                            Dim ReceiverNumberCommand As New SqlCommand(ReceiverNumberStatement, con)
                            ReceiverNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            ReceiverNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ReceiverNumber = CInt(ReceiverNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                ReceiverNumber = 0
                            End Try
                            con.Close()

                            'Delete Receiver and Shipment for the Drop Ship
                            cmd = New SqlCommand("DELETE FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            cmd = New SqlCommand("DELETE FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        ElseIf DropShipPONumber = 0 And SpecialInstructions <> "DROPSHIP" Then
                            'Check to see if Invoice is a credit from a customer return
                            If SpecialInstructions = "CREDIT" Then
                                'Create command to change Status of Return
                                cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "PENDING"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Change status of return lines
                                cmd = New SqlCommand("UPDATE ReturnProductLineTable SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else
                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                        Else
                            Try
                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Do nothing if fails - Bill Only Invoice
                            End Try
                        End If

                        'If Consignment Invoice, reset Sales Order
                        If CustomerClass = "STANDARD" And FOB <> "Medina" And (cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "TWE") Then
                            Try
                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Do nothing if fails - Bill Only Invoice
                            End Try
                        ElseIf CustomerClass <> "STANDARD" And FOB <> "Medina" And (cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "TWE") Then
                            Try
                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Do nothing if fails - Bill Only Invoice
                            End Try
                        Else
                            'Do nothing
                        End If
                    Next

                    'Create command to delete batch
                    cmd = New SqlCommand("DELETE FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear text boxes on delete
                    'Load defaults
                    LoadBatchNumber()
                    ClearVariables()
                    ClearBatch()
                    LoadTotals()
                    LoadBatchInfo()
                    ShowBatchLines()
                ElseIf button = DialogResult.No Then
                    cmdGenerateBatchNumber.Focus()
                End If
            Else
                MsgBox("Batch cannot be deleted - Batch is already posted.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub DeleteBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBatchToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Save batch and verify valid Batch Number
        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            GlobalARBatchNumber = 0
            ClearVariables()
            ClearBatch()
            Me.Dispose()
            Me.Close()
        Else
            If isSomeoneEditing() Then
                GlobalARBatchNumber = 0
                ClearVariables()
                ClearBatch()
                Me.Dispose()
                Me.Close()
            End If
            If cboDivisionID.Text = "ADM" Then
                MsgBox("You must select a specific division to process invoices.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Calculate Batch Total from Invoices
            LoadTotals()

            'Command to update Batch Total in Batch
            cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount, Locked = '' WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = UpdateTotals
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reload Totals after update
            LoadTotals()

            'Determine Batch Status
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "OPEN"
            End Try
            con.Close()

            BatchDate = dtpBatchCreationDate.Value
  
            If BatchStatus = "OPEN" Then
                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("Insert Into InvoiceProcessingBatchHeader(BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, UserID)Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @UserID)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Save Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, UserID = @UserID WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Try

                GlobalARBatchNumber = 0
                ClearVariables()
                ClearBatch()
                Me.Dispose()
                Me.Close()
            Else
                GlobalARBatchNumber = 0
                ClearVariables()
                ClearBatch()
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.GetValue(0)) Then
                personEditing = reader.GetValue(0)
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this batch. You are unable to make any changes.", "Unable to save/Post", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET Locked = @Locked WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET Locked = '' WHERE BatchNumber = @BatchNumber AND Locked = @Locked", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        Else
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub ARProcessBatch_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            unlockBatch()
        End If
    End Sub

    Private Sub UnLockBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockBatchToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this batch?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET Locked = '' WHERE BatchNumber = @BatchNumber", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Batch is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a batch number to un-lock", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
        End If
    End Sub

    Private Sub cmdPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAll.Click
        GlobalARBatchNumber = Val(cboBatchNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintAllInvoiceDocs As New PrintAllInvoiceDocs
            Dim Result = NewPrintAllInvoiceDocs.ShowDialog()
        End Using
    End Sub

    Private Sub dgvInvoiceHeaders_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceHeaders.CellContentClick
        Dim LineInvoiceNumber As Integer = 0

        If Me.dgvInvoiceHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInvoiceHeaders.CurrentCell.RowIndex

            LineInvoiceNumber = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("InvoiceNumberColumn").Value

            cboInvoiceNumber.Text = LineInvoiceNumber
        Else
            'Do nothing
        End If
    End Sub

    Private Sub dgvInvoiceHeaders_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceHeaders.CellDoubleClick
        Dim LineInvoiceNumber, LineShipmentNumber, LineSONumber As Integer
        Dim RowDivision, RowCustomer As String

        If Me.dgvInvoiceHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInvoiceHeaders.CurrentCell.RowIndex

            LineInvoiceNumber = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            LineShipmentNumber = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            LineSONumber = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
            RowDivision = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value
            RowCustomer = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value

            'Get Invoice Email Address
            Dim EmailAddressStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailAddressCommand As New SqlCommand(EmailAddressStatement, con)
            EmailAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
            EmailAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailAddress = CStr(EmailAddressCommand.ExecuteScalar)
            Catch ex As Exception
                EmailAddress = ""
            End Try
            con.Close()

            EmailInvoiceNumber = LineInvoiceNumber
            EmailSalesOrderNumber = LineSONumber
            EmailShipmentNumber = LineShipmentNumber
            GlobalDivisionCode = RowDivision
            EmailInvoiceCustomer = RowCustomer
            EmailCustomerEmailAddress = EmailAddress

            Using NewEmailAllInvoiceDocs As New EmailAllInvoiceDocs
                Dim Result = NewEmailAllInvoiceDocs.ShowDialog()
            End Using
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdDeleteInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteInvoice.Click
        Dim ShipmentNumber, DropShipPONumber, SONumber As Integer
        Dim SpecialInstructions As String = ""
        Dim FOB, CustomerClass As String
        Dim DeleteInvoiceNumber As Integer = 0
        Dim DeleteInvoiceTotal As Double = 0
        Dim DeleteCustomerID As String = ""
        Dim CheckBatchUserID As String = ""
        '*********************************************************************************
        'Check to see if it is some elses batch
        Dim CheckBatchUserIDStatement As String = "SELECT Locked FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim CheckBatchUserIDCommand As New SqlCommand(CheckBatchUserIDStatement, con)
        CheckBatchUserIDCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        CheckBatchUserIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckBatchUserID = CStr(CheckBatchUserIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckBatchUserID = ""
        End Try
        con.Close()

        If CheckBatchUserID = EmployeeLoginName Or CheckBatchUserID = "" Then
            'skip
        Else
            MsgBox("You cannot delete an invoice from another user's batch.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*********************************************************************************
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a specific division to delete invoices.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete these Invoices?", "DELETE BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    If Me.dgvInvoiceHeaders.SelectedRows.Count > 1 Then
                        For Each row As DataGridViewRow In Me.dgvInvoiceHeaders.SelectedRows
                            Try
                                ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                            Catch ex As Exception
                                ShipmentNumber = 0
                            End Try
                            Try
                                SpecialInstructions = row.Cells("SpecialInstructionsColumn").Value
                            Catch ex As Exception
                                SpecialInstructions = ""
                            End Try
                            Try
                                DropShipPONumber = row.Cells("DropShipPONumberColumn").Value
                            Catch ex As Exception
                                DropShipPONumber = 0
                            End Try
                            Try
                                SONumber = row.Cells("SalesOrderNumberColumn").Value
                            Catch ex As Exception
                                SONumber = 0
                            End Try
                            Try
                                CustomerClass = row.Cells("CustomerClassColumn").Value
                            Catch ex As Exception
                                CustomerClass = ""
                            End Try
                            Try
                                FOB = row.Cells("FOBColumn").Value
                            Catch ex As Exception
                                FOB = ""
                            End Try
                            Try
                                DeleteInvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                            Catch ex As Exception
                                DeleteInvoiceNumber = 0
                            End Try
                            Try
                                DeleteInvoiceTotal = row.Cells("InvoiceTotalColumn").Value
                            Catch ex As Exception
                                DeleteInvoiceTotal = 0
                            End Try
                            Try
                                DeleteCustomerID = row.Cells("CustomerIDColumn").Value
                            Catch ex As Exception
                                DeleteCustomerID = ""
                            End Try

                            'Write to Audit Trail Table
                            Dim AuditComment As String = ""
                            Dim AuditInvoiceNumber As Integer = 0
                            Dim strInvoiceNumber As String = ""

                            AuditInvoiceNumber = DeleteInvoiceNumber
                            strInvoiceNumber = CStr(AuditInvoiceNumber)
                            AuditComment = "Invoice #" + strInvoiceNumber + " for customer " + DeleteCustomerID + " was deleted on " + Today()

                            cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@AuditType", SqlDbType.VarChar).Value = "INVOICE BATCH - DELETION"
                                .Add("@AuditAmount", SqlDbType.VarChar).Value = DeleteInvoiceTotal
                                .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strInvoiceNumber
                                .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            If DropShipPONumber > 0 And SpecialInstructions = "DROPSHIP" Then
                                'Create command to change Status of PO
                                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = DropShipPONumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of PO Lines
                                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = DropShipPONumber
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of SO
                                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "DROPSHIP"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of SO Lines
                                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Get Receiver Number to delete - stored in Pick Ticket Number column of Shipping Header Table
                                Dim ReceiverNumberStatement As String = "SELECT PickTicketNumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                                Dim ReceiverNumberCommand As New SqlCommand(ReceiverNumberStatement, con)
                                ReceiverNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                ReceiverNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    ReceiverNumber = CInt(ReceiverNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverNumber = 0
                                End Try
                                con.Close()

                                'Delete Receiver and Shipment for the Drop Ship
                                cmd = New SqlCommand("DELETE FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                cmd = New SqlCommand("DELETE FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            ElseIf DropShipPONumber = 0 And SpecialInstructions <> "DROPSHIP" Then
                                'Check to see if Invoice is a credit from a customer return
                                If SpecialInstructions = "CREDIT" Then
                                    'Create command to change Status of Return
                                    cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
                                    cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "PENDING"

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Change status of return lines
                                    cmd = New SqlCommand("UPDATE ReturnProductLineTable SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
                                    cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                    cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Else
                                    'Create command to change Status of Shipments
                                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                    cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Create command to change Status of Shipments
                                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            Else
                                Try
                                    'Create command to change Status of Shipments
                                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                    cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Create command to change Status of Shipments
                                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Do nothing if fails - Bill Only Invoice
                                End Try
                            End If

                            'If Consignment Invoice, reset Sales Order
                            If CustomerClass = "STANDARD" And FOB <> "Medina" And cboDivisionID.Text = "TWD" Then
                                Try
                                    'Create command to change Status of Shipments
                                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                    cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                                    cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Create command to change Status of Shipments
                                    cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Do nothing if fails - Bill Only Invoice
                                End Try
                            ElseIf CustomerClass <> "STANDARD" And FOB <> "Medina" And cboDivisionID.Text = "TWD" Then
                                Try
                                    'Create command to change Status of Shipments
                                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                    cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                                    cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Create command to change Status of Shipments
                                    cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Do nothing if fails - Bill Only Invoice
                                End Try
                            Else
                                'Do nothing
                            End If

                            'Create command to delete invoice
                            cmd = New SqlCommand("DELETE FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = DeleteInvoiceNumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Next
                    Else
                        Dim ShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                        Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)
                        ShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        ShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim SpecialInstructionsStatement As String = "SELECT SpecialInstructions FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                        Dim SpecialInstructionsCommand As New SqlCommand(SpecialInstructionsStatement, con)
                        SpecialInstructionsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        SpecialInstructionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim DropShipPONumberStatement As String = "SELECT DropShipPONumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                        Dim DropShipPONumberCommand As New SqlCommand(DropShipPONumberStatement, con)
                        DropShipPONumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        DropShipPONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim SONumberStatement As String = "SELECT SalesOrderNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                        Dim SONumberCommand As New SqlCommand(SONumberStatement, con)
                        SONumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        SONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim CustomerClassStatement As String = "SELECT CustomerClass FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                        Dim CustomerClassCommand As New SqlCommand(CustomerClassStatement, con)
                        CustomerClassCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        CustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim FOBStatement As String = "SELECT FOB FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                        Dim FOBCommand As New SqlCommand(FOBStatement, con)
                        FOBCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        FOBCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim DeleteInvoiceTotalStatement As String = "SELECT InvoiceTotal FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                        Dim DeleteInvoiceTotalCommand As New SqlCommand(DeleteInvoiceTotalStatement, con)
                        DeleteInvoiceTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        DeleteInvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim DeleteCustomerIDStatement As String = "SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                        Dim DeleteCustomerIDCommand As New SqlCommand(DeleteCustomerIDStatement, con)
                        DeleteCustomerIDCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        DeleteCustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            ShipmentNumber = 0
                        End Try
                        Try
                            SpecialInstructions = CStr(SpecialInstructionsCommand.ExecuteScalar)
                        Catch ex As Exception
                            SpecialInstructions = ""
                        End Try
                        Try
                            DropShipPONumber = CInt(DropShipPONumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            DropShipPONumber = 0
                        End Try
                        Try
                            SONumber = CInt(SONumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            SONumber = 0
                        End Try
                        Try
                            CustomerClass = CStr(CustomerClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            CustomerClass = ""
                        End Try
                        Try
                            FOB = CStr(FOBCommand.ExecuteScalar)
                        Catch ex As Exception
                            FOB = ""
                        End Try
                        Try
                            DeleteInvoiceTotal = CDbl(DeleteInvoiceTotalCommand.ExecuteScalar)
                        Catch ex As Exception
                            DeleteInvoiceTotal = 0
                        End Try
                        Try
                            DeleteCustomerID = CStr(DeleteCustomerIDCommand.ExecuteScalar)
                        Catch ex As Exception
                            DeleteCustomerID = ""
                        End Try
                        con.Close()

                        DeleteInvoiceNumber = Val(cboInvoiceNumber.Text)

                        'Write to Audit Trail Table
                        Dim AuditComment As String = ""
                        Dim AuditInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String = ""

                        AuditInvoiceNumber = DeleteInvoiceNumber
                        strInvoiceNumber = CStr(AuditInvoiceNumber)
                        AuditComment = "Invoice #" + strInvoiceNumber + " for customer " + DeleteCustomerID + " was deleted on " + Today()

                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "INVOICE BATCH - DELETION"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = DeleteInvoiceTotal
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strInvoiceNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If DropShipPONumber > 0 And SpecialInstructions = "DROPSHIP" Then
                            'Create command to change Status of PO
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = DropShipPONumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Create command to change Status of PO Lines
                            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = DropShipPONumber
                            cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Create command to change Status of SO
                            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                            cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "DROPSHIP"

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Create command to change Status of SO Lines
                            cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Get Receiver Number to delete - stored in Pick Ticket Number column of Shipping Header Table
                            Dim ReceiverNumberStatement As String = "SELECT PickTicketNumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                            Dim ReceiverNumberCommand As New SqlCommand(ReceiverNumberStatement, con)
                            ReceiverNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            ReceiverNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ReceiverNumber = CInt(ReceiverNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                ReceiverNumber = 0
                            End Try
                            con.Close()

                            'Delete Receiver and Shipment for the Drop Ship
                            cmd = New SqlCommand("DELETE FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            cmd = New SqlCommand("DELETE FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        ElseIf DropShipPONumber = 0 And SpecialInstructions <> "DROPSHIP" Then
                            'Check to see if Invoice is a credit from a customer return
                            If SpecialInstructions = "CREDIT" Then
                                'Create command to change Status of Return
                                cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "PENDING"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Change status of return lines
                                cmd = New SqlCommand("UPDATE ReturnProductLineTable SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else
                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                        Else
                            Try
                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Do nothing if fails - Bill Only Invoice
                            End Try
                        End If

                        'If Consignment Invoice, reset Sales Order
                        If CustomerClass = "STANDARD" And FOB <> "Medina" And cboDivisionID.Text = "TWD" Then
                            Try
                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Do nothing if fails - Bill Only Invoice
                            End Try
                        ElseIf CustomerClass <> "STANDARD" And FOB <> "Medina" And cboDivisionID.Text = "TWD" Then
                            Try
                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Create command to change Status of Shipments
                                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Do nothing if fails - Bill Only Invoice
                            End Try
                        Else
                            'Do nothing
                        End If
                    End If

                    'Create command to delete invoice
                    cmd = New SqlCommand("DELETE FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = DeleteInvoiceNumber
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Load batch data
                    LoadBatchInfo()
                    LoadInvoiceNumber()
                    LoadTotals()
                    ShowBatchLines()
                Catch ex As Exception
                    'Write to error log
                    Dim strInvoiceNumber As String = ""

                    strInvoiceNumber = CStr(DeleteInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Process AR Batch --- Delete Invoice Failure"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            ElseIf button = DialogResult.No Then
                cmdGenerateBatchNumber.Focus()
            End If
        End If
    End Sub

    Private Sub dgvInvoiceHeaders_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvInvoiceHeaders.Sorted
        ColorLines()
    End Sub

    Private Sub dgvInvoiceHeaders_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvInvoiceHeaders.VisibleChanged
        ColorLines()
    End Sub

    Private Function canSplit() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must enter a batch number", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If dgvInvoiceHeaders.Rows.Count = 0 Then
            MessageBox.Show("You have lines to split a batch", "Enter some lines", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvInvoiceHeaders.SelectedRows.Count = 0 Then
            MessageBox.Show("You must select a row to split to a new batch", "Select a row", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function
   
    Private Sub cmdSplitBatch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSplitBatch.Click
        If canSplit() Then

            If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
                ''unlocks the batch if the user is the one that has it locked
                unlockBatch(lastBatch)
            End If

            'declares the old and new batch numbers
            Dim oldBatchNum As Integer = Val(cboBatchNumber.Text)
            Dim newBatchNum As Integer = 0

            'Find the next Batch Number to use
            Dim MAXStatement As String = "SELECT MAX(BatchNumber) FROM InvoiceProcessingBatchHeader"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastBatchNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastBatchNumber = 2200000
            End Try
            con.Close()

            'Saves the next batch number available
            NextBatchNumber = LastBatchNumber + 1
            'cboBatchNumber.Text = NextBatchNumber
            newBatchNum = NextBatchNumber
            BatchDate = dtpBatchCreationDate.Value

            Try
                'Write Data to Batch Header Database Table
                cmd = New SqlCommand("Insert Into InvoiceProcessingBatchHeader(BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, UserID, Locked)Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @UserID, @UserID)", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                    .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Generate Batch Number --- Insert new AR batch"
                ErrorReferenceNumber = "Batch # " + NextBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            For Each row As DataGridViewRow In dgvInvoiceHeaders.Rows
                If row.Selected Then
                    'Pulls in the batch number, invoice number, and shipment number from the selected rows
                    Dim Batchnumber As Integer = row.Cells("BatchNumberColumn").Value
                    Dim invoiceNum As Integer = row.Cells("InvoiceNumberColumn").Value
                    Dim shipNum As Integer = row.Cells("ShipmentNumberColumn").Value

                    Try
                        'Updates the existing batch numbers to the new one
                        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET BatchNumber = @NewBatchNumber WHERE BatchNumber = @CurrentBatchNumber AND DivisionID = @DivisionID AND ShipmentNumber = @ShipmentNum AND InvoiceNumber = @InvoiceNum", con)
                        cmd.Parameters.Add("@CurrentBatchNumber", SqlDbType.Int).Value = Batchnumber
                        cmd.Parameters.Add("@NewBatchNumber", SqlDbType.Int).Value = NextBatchNumber
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@ShipmentNum", SqlDbType.Int).Value = shipNum
                        cmd.Parameters.Add("@InvoiceNum", SqlDbType.Int).Value = invoiceNum
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Split Batch --- Updating old batch to new batch numbers"
                        ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
            Next

            'Gets sum of the new batch
            Dim batchTotal As Double = 0

            cmd = New SqlCommand("Select SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE BatchNumber = @NewBatchNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@NewBatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            batchTotal = CDbl(cmd.ExecuteScalar)
            con.Close()

            lastBatch = cboBatchNumber.Text

            Try
                'Updates new batch numbers amounts
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND BatchDate = @BatchDate AND DivisionID = @DivisionID AND UserID = @UserID", con)
                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                    .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = batchTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Split Batch --- Update Existing Total"
                ErrorReferenceNumber = "Batch # " + newBatchNum
                ErrorUser = EmployeeLoginName
                TFPErrorLogUpdate()
            End Try

            batchTotal = 0

            'Gets sum of old batch number
            cmd = New SqlCommand("Select SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE BatchNumber = @NewBatchNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@NewBatchNumber", SqlDbType.VarChar).Value = oldBatchNum
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            If IsDBNull(cmd.ExecuteScalar) Then
                batchTotal = 0
            Else
                batchTotal = CDbl(cmd.ExecuteScalar)
            End If
            con.Close()

            lastBatch = cboBatchNumber.Text

            Try
                'Updates old batch number amounts
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND BatchDate = @BatchDate AND DivisionID = @DivisionID AND UserID = @UserID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = oldBatchNum
                    .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = batchTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Split Batch --- Update Original Batch Amount"
                ErrorReferenceNumber = "Batch # " + oldBatchNum.ToString
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Reset controls
            LoadBatchNumber()
            cboBatchNumber.Text = oldBatchNum
            ShowBatchLines()

            CheckPendingReturns()
            CheckOpenBatches()
            CheckOpenBillOnly()

            'Message of what the batch number is
            Dim message As String = "Selected Invoices have been split into batch number: " + newBatchNum.ToString
            MsgBox(message)
        End If
    End Sub

    Private Sub cmdSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSchedule.Click
        'Declare variables
        Dim RowInvoiceNumber, RowShipmentNumber As Integer
        Dim RowDivisionID, RowCustomerID As String
        Dim RowEmailType As String = ""
        Dim GetInvoiceEmail, GetInvoiceCertEmail As String

        If Me.dgvInvoiceHeaders.RowCount = 0 Then
            MsgBox("No rows exist for this batch.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboTime.Text = "" Or cboDay.Text = "" Then
            MsgBox("You must select date and time to send emails.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboDay.Text.StartsWith("TONIGHT") And cboTime.Text.Contains("PM") Then
            MsgBox("Select a time after midnight.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        For Each row As DataGridViewRow In dgvInvoiceHeaders.Rows
            Try
                RowDivisionID = row.Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivisionID = cboDivisionID.Text
            End Try
            Try
                RowCustomerID = row.Cells("CustomerIDColumn").Value
            Catch ex As Exception
                RowCustomerID = ""
            End Try
            Try
                RowInvoiceNumber = row.Cells("InvoiceNumberColumn").Value
            Catch ex As Exception
                RowInvoiceNumber = 0
            End Try
            Try
                RowShipmentNumber = row.Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                RowShipmentNumber = 0
            End Try

            'Check if invoice is already scheduled
            Dim CountScheduledInvoice As Integer = 0

            Dim CountScheduledInvoiceStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceEmailLog WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID AND EmailStatus = 'OPEN'"
            Dim CountScheduledInvoiceCommand As New SqlCommand(CountScheduledInvoiceStatement, con)
            CountScheduledInvoiceCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
            CountScheduledInvoiceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountScheduledInvoice = CInt(CountScheduledInvoiceCommand.ExecuteScalar)
            Catch ex As Exception
                CountScheduledInvoice = 0
            End Try
            con.Close()

            If CountScheduledInvoice = 0 Then
                'Check Customer for email addresses in Invoice field and cert field
                Dim GetInvoiceEmailStatement As String = "SELECT InvoiceEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim GetInvoiceEmailCommand As New SqlCommand(GetInvoiceEmailStatement, con)
                GetInvoiceEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID
                GetInvoiceEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID

                Dim GetInvoiceCertEmailStatement As String = "SELECT InvoiceCertEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim GetInvoiceCertEmailCommand As New SqlCommand(GetInvoiceCertEmailStatement, con)
                GetInvoiceCertEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID
                GetInvoiceCertEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetInvoiceEmail = CStr(GetInvoiceEmailCommand.ExecuteScalar)
                Catch ex As Exception
                    GetInvoiceEmail = ""
                End Try
                Try
                    GetInvoiceCertEmail = CStr(GetInvoiceCertEmailCommand.ExecuteScalar)
                Catch ex As Exception
                    GetInvoiceCertEmail = ""
                End Try
                con.Close()

                If GetInvoiceEmail = "" And GetInvoiceCertEmail = "" Then
                    RowEmailType = "SKIP"
                ElseIf GetInvoiceEmail <> "" And GetInvoiceCertEmail <> "" Then
                    RowEmailType = "BOTH"
                ElseIf GetInvoiceEmail <> "" And GetInvoiceCertEmail = "" Then
                    RowEmailType = "INVOICE"
                ElseIf GetInvoiceEmail = "" And GetInvoiceCertEmail <> "" Then
                    RowEmailType = "CERTS"
                Else
                    RowEmailType = "SKIP"
                End If

                If RowEmailType = "SKIP" Then
                    'Skip
                Else
                    'Insert Into InvoiceEmailLog
                    cmd = New SqlCommand("INSERT INTO InvoiceEmailLog (DivisionID, CustomerID, InvoiceNumber, ShipmentNumber, EmailDay, EmailTime, EmailType, SentDate, UserID, EmailStatus, InvoiceEmailAddress, CertEmailAddress) values (@DivisionID, @CustomerID, @InvoiceNumber, @ShipmentNumber, @EmailDay, @EmailTime, @EmailType, @SentDate, @UserID, @EmailStatus, @InvoiceEmailAddress, @CertEmailAddress)", con)

                    With cmd.Parameters
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                        .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                        .Add("@EmailDay", SqlDbType.VarChar).Value = cboDay.Text
                        .Add("@EmailTime", SqlDbType.VarChar).Value = cboTime.Text
                        .Add("@EmailType", SqlDbType.VarChar).Value = RowEmailType
                        .Add("@SentDate", SqlDbType.VarChar).Value = Now()
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@EmailStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@InvoiceEmailAddress", SqlDbType.VarChar).Value = GetInvoiceEmail
                        .Add("@CertEmailAddress", SqlDbType.VarChar).Value = GetInvoiceCertEmail
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Else
                'Skip scheduling - already scheduled
            End If
        Next

        MsgBox("Emails scheduled to send.", MsgBoxStyle.OkOnly)

        cboDay.SelectedIndex = -1
        cboTime.SelectedIndex = -1
    End Sub
End Class