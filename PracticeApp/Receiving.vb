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
Public Class Receiving
    Inherits System.Windows.Forms.Form

    Dim LastCostingTransactionNumber, NextCostingTransactionNumber, ReceivingLineNumber, TempReceiverLine, CountLines, LastInventoryTransactionNumber, NextInventoryTransactionNumber, counter, LastTransactionNumber, NextTransactionNumber As Integer
    Dim CheckItemClass, GetItemClass, IsTaxable, VendorClass, POOrderNumber, ReceiptTicketNumber As String
    Dim VerifyVendor, LineStatus, PODate, VendorID, VendorName, POHeaderComment, ShipMethodID As String
    Dim POFreightCharge, POProductTotal, POSalesTaxRate, POTax, POQuantityReceived, POOrderQuantity, FreightCharge, SalesTax, ReceiverTotal, ProductTotal, ExtendedAmount As Double
    Dim ReceiverStatus, CheckReceiverStatus, CheckNegatives, ReceiverDate, DebitGLAccount, CreditGLAccount, ItemClass As String
    Dim CheckLedger, CheckLedgerTotal, CheckGLReceiver, CountReceiverLines, POLineNumber, CountPOLines, LastGLNumber, NextGLNumber, RTLineCount, PONumber As Integer
    Dim ConvertReceiverDate, ConvertPODate, TodaysDate As Date
    Dim VerifyDate As String = "DATE-OK"

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isLoaded = False
    Dim lastBatch As String = ""
    Dim PSUpload As PackingSlipScannerUploadAPI

    Private Sub Receiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCurrentDivision()

        TodaysDate = Today.ToShortDateString()

        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdUploadPackingSlip.Visible = False
            cmdViewPackingList.Enabled = False
            ReUploadPackingSlipToolStripMenuItem.Enabled = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
        Else
            cmdRemoteScan.Visible = False
            cmdUploadPackingSlip.Visible = True
        End If

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
            gpxPOHeader.Enabled = True
            gpxPostReceipt.Enabled = True
            gpxReceiverTotals.Enabled = True
            gpxReceivingHeaderInfo.Enabled = True
            gpxSelectLines.Enabled = True
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveReceiptToolStripMenuItem.Enabled = True
            DeleteReceiptToolStripMenuItem.Enabled = True
        ElseIf EmployeeCompanyCode = "TFP" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
            gpxPOHeader.Enabled = False
            gpxPostReceipt.Enabled = False
            gpxReceiverTotals.Enabled = False
            gpxReceivingHeaderInfo.Enabled = False
            gpxSelectLines.Enabled = False
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            SaveReceiptToolStripMenuItem.Enabled = False
            DeleteReceiptToolStripMenuItem.Enabled = False
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
            gpxPOHeader.Enabled = True
            gpxPostReceipt.Enabled = True
            gpxReceiverTotals.Enabled = True
            gpxReceivingHeaderInfo.Enabled = True
            gpxSelectLines.Enabled = True
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveReceiptToolStripMenuItem.Enabled = True
            DeleteReceiptToolStripMenuItem.Enabled = True
        End If

        PSUpload = New PackingSlipScannerUploadAPI(cmdUploadPackingSlip, cboReceivingTicketNumber, ReUploadPackingSlipToolStripMenuItem, Me, AppendUploadedPickTicketToolStripMenuItem)

        LoadOpenReceivers()
        isLoaded = True
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

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvReceivingLines.CellValueChanged
        If isLoaded Then
            If isSomeoneEditing() Then
                isLoaded = False
                ShowReceiverLines()
                LoadReceiverData()
                checkRows()
                CalculateReceiverTotals()
                isLoaded = True
                Exit Sub
            End If

            Dim currentRow As Integer = dgvReceivingLines.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvReceivingLines.CurrentCell.ColumnIndex

            Dim LineReceivingQuantity, LineExtendedAmount, LineUnitCost As Double
            Dim LineNumber As Integer

            'Retrieve line data from Receiver Table and UPDATE Totals
            If IsDBNull(dgvReceivingLines.Rows(currentRow).Cells("UnitCostColumn").Value) Then
                LineUnitCost = 0
            Else
                LineUnitCost = dgvReceivingLines.Rows(currentRow).Cells("UnitCostColumn").Value
            End If
            If IsDBNull(dgvReceivingLines.Rows(currentRow).Cells("QuantityReceivedColumn").Value) Then
                LineReceivingQuantity = 0
            Else
                LineReceivingQuantity = dgvReceivingLines.Rows(currentRow).Cells("QuantityReceivedColumn").Value
            End If

            LineNumber = dgvReceivingLines.Rows(currentRow).Cells("ReceivingLineKeyColumn").Value

            LineExtendedAmount = LineUnitCost * LineReceivingQuantity
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

            Try
                'UPDATE Receiver Lines based on line changes
                cmd = New SqlCommand("UPDATE ReceivingLineTable SET UnitCost = @UnitCost, QuantityReceived = @QuantityReceived, ExtendedAmount = @ExtendedAmount WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineNumber
                    .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                    .Add("@QuantityReceived", SqlDbType.VarChar).Value = LineReceivingQuantity
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write to error log
                'Log error on update failure
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Receipt Of Goods --- Update lines in datagrid"
                ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Calculate Receiver Totals
            CalculateReceiverTotals()

            Try
                'UPDATE Receiver Header based on line changes
                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET FreightCharge = @FreightCharge, SalesTax = @SalesTax, ProductTotal = @ProductTotal, POTotal = @POTotal WHERE ReceivingHeaderKey = @ReceivingHeaderKey", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                    .Add("@FreightCharge", SqlDbType.VarChar).Value = FreightCharge
                    .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@POTotal", SqlDbType.VarChar).Value = ReceiverTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write to error log
                'Log error on update failure
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Receipt Of Goods --- Update Header after lines in datagrid"
                ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            ShowReceiverLines()
            dgvReceivingLines.CurrentCell = dgvReceivingLines.Rows(currentRow).Cells(currentColumn)
        End If
    End Sub

    Public Sub ClearData()
        cboPONumber.Text = ""
        cboReceivingTicketNumber.Text = ""
        LoadPONumber()
        LoadReceiverNumber()

        dtpPODate.Text = ""
        dtpReceivingDate.Text = ""

        cboReceivingTicketNumber.Refresh()
        cboPONumber.Refresh()

        If cboPONumber.Enabled = False Then
            cboPONumber.Enabled = True
        End If

        cboShipVia.Refresh()

        cboPONumber.SelectedIndex = -1
        cboReceivingTicketNumber.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1

        txtFreightCharge.Refresh()
        txtReceiverTotal.Refresh()
        txtProductTotal.Refresh()
        txtSalesTax.Refresh()
        txtVendorName.Refresh()
        txtComment.Refresh()
        txtVendorID.Refresh()

        txtFreightCharge.Clear()
        txtReceiverTotal.Clear()
        txtProductTotal.Clear()
        txtSalesTax.Clear()
        txtVendorName.Clear()
        txtComment.Clear()
        txtVendorName.Clear()
        txtVendorID.Clear()

        lblOpenReceivers.Text = ""

        If My.Computer.Name.StartsWith("TFP") Then
            cmdViewPackingList.Enabled = False
            cmdUploadPackingSlip.Visible = False
            cmdRemoteScan.Visible = True
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
            ReUploadPackingSlipToolStripMenuItem.Enabled = False
        Else
            cmdViewPackingList.Enabled = False
            cmdUploadPackingSlip.Enabled = True
            cmdRemoteScan.Visible = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
            ReUploadPackingSlipToolStripMenuItem.Enabled = False
        End If

        cmdGenerateNewReceipt.Focus()
    End Sub

    Public Sub ClearVariables()
        LastInventoryTransactionNumber = 0
        NextInventoryTransactionNumber = 0
        LastCostingTransactionNumber = 0
        NextCostingTransactionNumber = 0
        POProductTotal = 0
        POSalesTaxRate = 0
        POTax = 0
        IsTaxable = ""
        counter = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        POOrderNumber = ""
        ReceiptTicketNumber = ""
        PODate = ""
        VendorID = ""
        VendorName = ""
        POHeaderComment = ""
        ShipMethodID = ""
        FreightCharge = 0
        SalesTax = 0
        ReceiverTotal = 0
        ProductTotal = 0
        ExtendedAmount = 0
        DebitGLAccount = ""
        CreditGLAccount = ""
        LastGLNumber = 0
        NextGLNumber = 0
        RTLineCount = 0
        PONumber = 0
        ReceiverDate = ""
        ItemClass = ""
        CountLines = 0
        TempReceiverLine = 0
        ReceivingLineNumber = 0
        VerifyVendor = ""
        CheckNegatives = "NO"
        VendorClass = ""
        CheckGLReceiver = 0
        CheckLedger = 0
        CheckLedgerTotal = 0
        VerifyDate = "DATE-OK"
        CheckItemClass = ""
        GetItemClass = ""
        ConvertPODate = TodaysDate
        ConvertReceiverDate = TodaysDate
        lastBatch = ""
        ReceiverStatus = ""
        POFreightCharge = 0
    End Sub

    Public Sub ShowReceiverLines()
        cmd = New SqlCommand("SELECT * FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceivingLineTable")
        dgvReceivingLines.DataSource = ds.Tables("ReceivingLineTable")
        con.Close()
    End Sub

    Public Sub ClearReceiverLines()
        dgvReceivingLines.DataSource = Nothing
    End Sub

    Public Sub LoadPONumber()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID AND Status = @Status ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "PurchaseOrderHeaderTable")
        cboPONumber.DataSource = ds1.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadReceiverNumber()
        cmd = New SqlCommand("SELECT ReceivingHeaderKey FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID AND Status = @Status", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ReceivingHeaderTable")
        cboReceivingTicketNumber.DataSource = ds3.Tables("ReceivingHeaderTable")
        con.Close()
        cboReceivingTicketNumber.SelectedIndex = -1
    End Sub

    Public Sub VerifyPostDate()
        'Dim PostDate, TodaysDate As Date
        'Dim TodayMonthOfDate, TodayYearOfDate, PostMonthOfDate, PostYearOfDate As Integer

        'TodaysDate = Today()
        'PostDate = dtpReceivingDate.Value

        ''Get month and year
        'TodayMonthOfDate = TodaysDate.Month
        'TodayYearOfDate = TodaysDate.Year

        'PostMonthOfDate = PostDate.Month
        'PostYearOfDate = PostDate.Year

        'If TodayYearOfDate = PostYearOfDate And (TodayMonthOfDate - PostMonthOfDate > 1) Then
        '    MsgBox("You cannot post to a past period greater than last month.", MsgBoxStyle.OkOnly)
        '    VerifyDate = "NOT-OK"
        'ElseIf TodayYearOfDate - PostYearOfDate = 1 And TodayMonthOfDate <> 1 Then
        '    MsgBox("You cannot post to a past period greater than last month.", MsgBoxStyle.OkOnly)
        '    VerifyDate = "NOT-OK"
        'ElseIf TodayYearOfDate - PostYearOfDate = 1 And TodayMonthOfDate = 1 And PostMonthOfDate <> 12 Then
        '    MsgBox("You cannot post to a past period greater than last month.", MsgBoxStyle.OkOnly)
        '    VerifyDate = "NOT-OK"
        'ElseIf TodayYearOfDate - PostYearOfDate > 1 Then
        '    MsgBox("You cannot post to a past period greater than last month.", MsgBoxStyle.OkOnly)
        '    VerifyDate = "NOT-OK"
        'Else
        '    VerifyDate = "DATE-OK"
        'End If

        VerifyDate = "DATE-OK"
    End Sub

    Public Sub LoadReceiverData()
        'Extract data from Receiver Header table
        Dim RCPONumber As Integer = 0
        Dim RCVendorCode, RCReceivingDate, RCHeaderComment, RCPODate, RCShipMethodID, RCStatus, RCReceivingAgent As String
        Dim RCFreightCharge, RCSalesTax, RCProductTotal, RCReceiverTotal As Double

        Dim GetReceiverDataString As String = "SELECT * FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim GetReceiverDataCommand As New SqlCommand(GetReceiverDataString, con)
        GetReceiverDataCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        GetReceiverDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetReceiverDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PONumber")) Then
                RCPONumber = 0
            Else
                RCPONumber = reader.Item("PONumber")
            End If
            If IsDBNull(reader.Item("VendorCode")) Then
                RCVendorCode = ""
            Else
                RCVendorCode = reader.Item("VendorCode")
            End If
            If IsDBNull(reader.Item("ReceivingDate")) Then
                RCReceivingDate = Today()
            Else
                RCReceivingDate = reader.Item("ReceivingDate")
            End If
            If IsDBNull(reader.Item("HeaderComment")) Then
                RCHeaderComment = ""
            Else
                RCHeaderComment = reader.Item("HeaderComment")
            End If
            If IsDBNull(reader.Item("PODate")) Then
                RCPODate = ""
            Else
                RCPODate = reader.Item("PODate")
            End If
            If IsDBNull(reader.Item("ShipMethodID")) Then
                RCShipMethodID = ""
            Else
                RCShipMethodID = reader.Item("ShipMethodID")
            End If
            If IsDBNull(reader.Item("FreightCharge")) Then
                RCFreightCharge = 0
            Else
                RCFreightCharge = reader.Item("FreightCharge")
            End If
            If IsDBNull(reader.Item("SalesTax")) Then
                RCSalesTax = 0
            Else
                RCSalesTax = reader.Item("SalesTax")
            End If
            If IsDBNull(reader.Item("ProductTotal")) Then
                RCProductTotal = 0
            Else
                RCProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("POTotal")) Then
                RCReceiverTotal = 0
            Else
                RCReceiverTotal = reader.Item("POTotal")
            End If
            If IsDBNull(reader.Item("Status")) Then
                RCStatus = ""
            Else
                RCStatus = reader.Item("Status")
            End If
            If IsDBNull(reader.Item("ReceivingAgent")) Then
                RCReceivingAgent = ""
            Else
                RCReceivingAgent = reader.Item("ReceivingAgent")
            End If
        Else
            RCReceivingDate = Today()
            RCHeaderComment = ""
            RCFreightCharge = 0
            RCPODate = ""
            RCPONumber = 0
            RCProductTotal = 0
            RCReceiverTotal = 0
            RCReceivingAgent = ""
            RCSalesTax = 0
            RCShipMethodID = ""
            RCStatus = ""
            RCVendorCode = ""
        End If
        reader.Close()
        con.Close()

        'Load extracted Receiver data into text boxes
        cboPONumber.Text = RCPONumber
        cboShipVia.Text = RCShipMethodID
        txtComment.Text = RCHeaderComment
        txtFreightCharge.Text = RCFreightCharge
        txtProductTotal.Text = RCProductTotal
        txtReceiverTotal.Text = RCReceiverTotal
        txtSalesTax.Text = RCSalesTax
        txtVendorID.Text = RCVendorCode
        txtReceivingAgent.Text = RCReceivingAgent

        dtpReceivingDate.Text = RCReceivingDate
        dtpPODate.Text = RCPODate
    End Sub

    Public Sub LoadPOData()
        'Extract data from Purchase Order Header table
        Dim GetPODataString As String = "SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim GetPODataCommand As New SqlCommand(GetPODataString, con)
        GetPODataCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        GetPODataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPODataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("VendorID")) Then
                VendorID = ""
            Else
                VendorID = reader.Item("VendorID")
            End If
            If IsDBNull(reader.Item("PODate")) Then
                PODate = ""
            Else
                PODate = reader.Item("PODate")
            End If
            If IsDBNull(reader.Item("POHeaderComment")) Then
                POHeaderComment = ""
            Else
                POHeaderComment = reader.Item("POHeaderComment")
            End If
            If IsDBNull(reader.Item("ShipMethodID")) Then
                ShipMethodID = ""
            Else
                ShipMethodID = reader.Item("ShipMethodID")
            End If
            If IsDBNull(reader.Item("SalesTax")) Then
                POTax = 0
            Else
                POTax = reader.Item("SalesTax")
            End If
            If IsDBNull(reader.Item("ProductTotal")) Then
                POProductTotal = 0
            Else
                POProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("FreightCharge")) Then
                POFreightCharge = 0
            Else
                POFreightCharge = reader.Item("FreightCharge")
            End If
        Else
            VendorID = ""
            PODate = ""
            POHeaderComment = ""
            ShipMethodID = ""
            POTax = 0
            POProductTotal = 0
            POFreightCharge = 0
        End If
        reader.Close()
        con.Close()

        'Load extracted PO data into text boxes
        txtSalesTax.Text = POTax
        txtFreightCharge.Text = POFreightCharge
        txtVendorID.Text = VendorID
        dtpPODate.Text = PODate
        txtComment.Text = POHeaderComment
        cboShipVia.Text = ShipMethodID
    End Sub

    Public Sub LoadVendorByPONUmber()
        Dim VendorFromPO As String = ""

        Dim VendorIDString As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim VendorIDCommand As New SqlCommand(VendorIDString, con)
        VendorIDCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        VendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorFromPO = CStr(VendorIDCommand.ExecuteScalar)
        Catch ex As Exception
            VendorFromPO = ""
        End Try
        con.Close()

        txtVendorID.Text = VendorFromPO
    End Sub

    Public Sub LoadVendorName()

        Dim VendorNameString As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = txtVendorID.Text
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

    Public Sub LoadOpenReceivers()
        Dim OpenReceivers As Integer = 0
        Dim strOpenReceivers As String = ""
        lblOpenReceivers.Text = ""

        Dim OpenReceiversString As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingHeaderTable WHERE Status = @Status AND DivisionID = @DivisionID"
        Dim OpenReceiversCommand As New SqlCommand(OpenReceiversString, con)
        OpenReceiversCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        OpenReceiversCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OpenReceivers = CInt(OpenReceiversCommand.ExecuteScalar)
        Catch ex As Exception
            OpenReceivers = 0
        End Try
        con.Close()

        strOpenReceivers = CStr(OpenReceivers)

        If OpenReceivers = 0 Then
            lblOpenReceivers.Text = "There are no open receivers for this division."
        ElseIf OpenReceivers = 1 Then
            lblOpenReceivers.Text = "There is one open receiver for this division. "
        Else
            lblOpenReceivers.Text = "There are " + strOpenReceivers + " open receivers for this division."
        End If
    End Sub

    Public Sub CalculateReceiverTotals()
        Dim ProductTotalString As String = "SELECT SUM(ExtendedAmount) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
        ProductTotalCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        'Load extracted Receiver Header data into text boxes
        FreightCharge = Val(txtFreightCharge.Text)
        SalesTax = Val(txtSalesTax.Text)
        ReceiverTotal = ProductTotal + FreightCharge + SalesTax
        txtReceiverTotal.Text = FormatCurrency(ReceiverTotal, 2)
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded And Not String.IsNullOrEmpty(lastBatch) Then
            unlockBatch(lastBatch)
        End If

        'Clear Text boxes on load
        LoadReceiverNumber()
        LoadPONumber()
        ClearData()

        If GlobalSelectLinesReceiverNumber < 1 Then
            cboReceivingTicketNumber.SelectedIndex = -1
        Else
            cboReceivingTicketNumber.Text = GlobalSelectLinesReceiverNumber
        End If

        If GlobalSelectLinesPONumber < 1 Then
            cboPONumber.SelectedIndex = -1
        Else
            cboPONumber.Text = GlobalSelectLinesPONumber
        End If

        If cboDivisionID.Text = "ADM" Then
            cboDivisionID.Enabled = True
            gpxPOHeader.Enabled = True
            gpxPostReceipt.Enabled = True
            gpxReceiverTotals.Enabled = True
            gpxReceivingHeaderInfo.Enabled = True
            gpxSelectLines.Enabled = True
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveReceiptToolStripMenuItem.Enabled = True
            DeleteReceiptToolStripMenuItem.Enabled = True
        ElseIf cboDivisionID.Text = "TFP" Then
            cboDivisionID.Enabled = False
            gpxPOHeader.Enabled = False
            gpxPostReceipt.Enabled = False
            gpxReceiverTotals.Enabled = False
            gpxReceivingHeaderInfo.Enabled = False
            gpxSelectLines.Enabled = False
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            SaveReceiptToolStripMenuItem.Enabled = False
            DeleteReceiptToolStripMenuItem.Enabled = False
        Else
            cboDivisionID.Enabled = False
            gpxPOHeader.Enabled = True
            gpxPostReceipt.Enabled = True
            gpxReceiverTotals.Enabled = True
            gpxReceivingHeaderInfo.Enabled = True
            gpxSelectLines.Enabled = True
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveReceiptToolStripMenuItem.Enabled = True
            DeleteReceiptToolStripMenuItem.Enabled = True
        End If

        cmdGenerateNewReceipt.Focus()
    End Sub

    Private Sub cboPONumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPONumber.SelectedIndexChanged
        If isLoaded Then
            LoadPOData()
            LoadVendorByPONUmber()
            ShowReceiverLines()
        End If
    End Sub

    Public Sub LoadScannedReceivers()
        Dim ReceiverFilename As String = ""
        Dim ReceiverFilenameAndPath As String = ""

        If cboReceivingTicketNumber.Text = "" Then
            'Do nothing
        Else
            Dim UploadedReceiverNumber As String = cboReceivingTicketNumber.Text

            ReceiverFilename = UploadedReceiverNumber + ".pdf"
            ReceiverFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + ReceiverFilename

            If My.Computer.Name.StartsWith("TFP") Then
                If File.Exists(ReceiverFilenameAndPath) Then
                    cmdUploadPackingSlip.Visible = False
                    cmdViewPackingList.Enabled = True
                    cmdRemoteScan.Visible = True
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                    ReUploadPackingSlipToolStripMenuItem.Enabled = False
                Else
                    cmdViewPackingList.Enabled = False
                    cmdUploadPackingSlip.Visible = False
                    cmdRemoteScan.Visible = True
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                    ReUploadPackingSlipToolStripMenuItem.Enabled = False
                End If
            Else
                If File.Exists(ReceiverFilenameAndPath) Then
                    cmdUploadPackingSlip.Enabled = False
                    cmdViewPackingList.Enabled = True
                    cmdRemoteScan.Visible = False
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = True
                    ReUploadPackingSlipToolStripMenuItem.Enabled = True
                Else
                    cmdViewPackingList.Enabled = False
                    cmdUploadPackingSlip.Enabled = True
                    cmdRemoteScan.Visible = False
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                    ReUploadPackingSlipToolStripMenuItem.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub cboReceivingTicketNumber_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReceivingTicketNumber.GotFocus
        LoadScannedReceivers()
    End Sub

    Private Sub cboReceivingTicketNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReceivingTicketNumber.SelectedIndexChanged
        If PSUpload IsNot Nothing Then PSUpload.CheckUploadPackingSlip()
        If isLoaded Then
            If Not String.IsNullOrEmpty(lastBatch) Then
                unlockBatch(lastBatch)
            End If

            Dim PONumberString As String = "SELECT PONumber FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey"
            Dim PONumberCommand As New SqlCommand(PONumberString, con)
            PONumberCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PONumber = CInt(PONumberCommand.ExecuteScalar)
            Catch ex As Exception
                PONumber = Val(cboPONumber.Text)
            End Try
            con.Close()

            Dim receivingNumber As String = cboReceivingTicketNumber.Text

            isLoaded = False
            ClearData()
            cboReceivingTicketNumber.Text = receivingNumber
            cboReceivingTicketNumber.Focus()
            cboPONumber.Text = PONumber
            isLoaded = True
            ShowReceiverLines()
            LoadReceiverData()
            LoadOpenReceivers()
            LoadScannedReceivers()
            checkRows()
            CalculateReceiverTotals()
            lastBatch = cboReceivingTicketNumber.Text
        End If
    End Sub

    Private Sub checkRows()
        If dgvReceivingLines.Rows.Count > 0 Then
            If cboPONumber.Enabled Then
                cboPONumber.Enabled = False
            End If
        Else
            If cboPONumber.Enabled = False Then
                cboPONumber.Enabled = True
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        unlockBatch()
        GlobalPONumber = 0
        GlobalReceiverNumber = 0
        GlobalSelectLinesPONumber = 0
        GlobalSelectLinesReceiverNumber = 0
        ClearVariables()
        ClearData()
        ShowReceiverLines()
        LoadOpenReceivers()
    End Sub

    Private Sub ClearReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearReceiptToolStripMenuItem.Click
        cmdClear_Click(sender, e)
    End Sub

    Private Sub cmdGenerateNewReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewReceipt.Click
        If Not String.IsNullOrEmpty(lastBatch) Then
            unlockBatch(lastBatch)
        End If

        'Clear Form for next number
        ClearVariables()
        ClearData()
        ShowReceiverLines()

        'Create Receipt Ticket Number
        Dim MAXStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingHeaderTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 5500000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        cboReceivingTicketNumber.Text = NextTransactionNumber

        ConvertPODate = dtpPODate.Value
        ConvertReceiverDate = dtpReceivingDate.Value

        ReceiverStatus = "OPEN"

        'Save number so it can not be selected again
        Try
            InsertIntoReceivingHeaderTable()
        Catch ex As Exception
            'Write to error log
            'Log error on update failure
            Dim TempReceiverNumber As Integer = 0
            Dim strReceiverNumber As String
            TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
            strReceiverNumber = CStr(TempReceiverNumber)

            ErrorDate = TodaysDate
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Receipt Of Goods --- Create New Receipt"
            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            ClearVariables()
            ClearData()
            cboReceivingTicketNumber.SelectedIndex = -1
            MsgBox("Receiver # has already been used. You must select another.", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try

        isLoaded = False
        LoadReceiverNumber()
        LoadOpenReceivers()

        isLoaded = True
        cboReceivingTicketNumber.Text = NextTransactionNumber
        cboReceivingTicketNumber.Focus()

        If cboPONumber.Enabled = False Then
            cboPONumber.Enabled = True
        End If

        lastBatch = cboReceivingTicketNumber.Text
    End Sub

    Private Sub cmdSelectLinesFromPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectLinesFromPO.Click
        If canSelectLines() Then
            ConvertPODate = dtpPODate.Value
            ConvertReceiverDate = dtpReceivingDate.Value

            CalculateReceiverTotals()
            ReceiverStatus = "OPEN"

            Try
                UpdateReceivingHeaderTable()
            Catch ex1 As Exception
                'Write to error log
                'Log error on update failure
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex1.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Receipt Of Goods --- Update Header"
                ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            Dim NewSelectReceiverLines As New SelectReceiverLines
            NewSelectReceiverLines.setReceivingTicketNumber(cboReceivingTicketNumber.Text)
            NewSelectReceiverLines.setPONumber(cboPONumber.Text)
            NewSelectReceiverLines.setDivisionID(cboDivisionID.Text)
            NewSelectReceiverLines.ShowReceiverLines()

            Me.Hide()

            If NewSelectReceiverLines.ShowDialog() = Windows.Forms.DialogResult.OK Then
                cboPONumber.Enabled = False
            End If

            ShowReceiverLines()
            CalculateReceiverTotals()

            Me.Show()
            Me.BringToFront()
        End If 'End verify Statement
    End Sub

    Private Function canSelectLines() As Boolean
        If String.IsNullOrEmpty(cboReceivingTicketNumber.Text) Then
            MessageBox.Show("You must enter a receiving number", "Enter a receiving number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReceivingTicketNumber.Focus()
            Return False
        End If
        If cboReceivingTicketNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Receiving number", "Enter valid receiving number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReceivingTicketNumber.SelectAll()
            cboReceivingTicketNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            isLoaded = False
            ShowReceiverLines()
            LoadReceiverData()
            checkRows()
            CalculateReceiverTotals()
            isLoaded = True
            Return False
        End If
        If String.IsNullOrEmpty(cboPONumber.Text) Then
            MessageBox.Show("You must enter a PO number", "Enter a PO number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPONumber.Focus()
            Return False
        End If
        If cboPONumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid PO number", "Enter a vlaid PO number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPONumber.SelectAll()
            cboPONumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdPostReceiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostReceiver.Click
        If cantContinue() Then
            Exit Sub
        End If

        ConvertPODate = dtpPODate.Value
        ConvertReceiverDate = dtpReceivingDate.Value

        If EmployeeSecurityCode = "1002" Or EmployeeSecurityCode = "1001" Then
            VerifyDate = "DATE-OK"
        Else
            'Verify that date is not posting to a prior period beyond one
            VerifyPostDate()
        End If

        If ConvertReceiverDate > TodaysDate Then ConvertReceiverDate = TodaysDate

        If VerifyDate = "NOT-OK" Then
            'Message box will already come up...
        Else
            Try
                If canPost() Then

                    CalculateReceiverTotals()
                    ReceiverStatus = "OPEN"

                    Try
                        UpdateReceivingHeaderTable()
                    Catch ex1 As Exception
                        'Write to error log
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String
                        TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex1.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Receipt Of Goods --- Update Header Table before Post"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '******************************************************************************************************************************************
                    'Delete lines with Zero Quantity Shipped
                    '*****************************************************************************************************************************************
                    'Renumber Receiver lines if necessary
                    Dim CountLinesStatement As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
                    Dim CountLinesCommand As New SqlCommand(CountLinesStatement, con)
                    CountLinesCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                    CountLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountLines = CInt(CountLinesCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountLines = 0
                    End Try
                    con.Close()

                    'Starting Temp Row Number
                    TempReceiverLine = 10000

                    For Each row As DataGridViewRow In dgvReceivingLines.Rows

                        Dim TempReceivingLineNumber As Integer = row.Cells("ReceivingLineKeyColumn").Value

                        Try
                            'Reorder row numbers - assign temp row number
                            cmd = New SqlCommand("UPDATE ReceivingLineTable SET ReceivingLineKey = @ReceivingLineKey WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey1", con)

                            With cmd.Parameters
                                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                                .Add("@ReceivingLineKey1", SqlDbType.VarChar).Value = TempReceivingLineNumber
                                .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = TempReceiverLine
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Write to error log
                            'Log error on update failure
                            Dim TempReceiverNumber As Integer = 0
                            Dim strReceiverNumber As String
                            TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                            strReceiverNumber = CStr(TempReceiverNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Receipt Of Goods --- Update Line # - re-order lines"
                            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        TempReceiverLine = TempReceiverLine + 1
                    Next

                    ShowReceiverLines()

                    'Assign re-ordered Line Numbers
                    ReceivingLineNumber = 1

                    For Each row As DataGridViewRow In dgvReceivingLines.Rows

                        Dim FinalReceivingLineNumber As Integer = row.Cells("ReceivingLineKeyColumn").Value

                        Try
                            'Reorder row numbers - assign row number
                            cmd = New SqlCommand("UPDATE ReceivingLineTable SET ReceivingLineKey = @ReceivingLineKey WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey1", con)

                            With cmd.Parameters
                                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                                .Add("@ReceivingLineKey1", SqlDbType.VarChar).Value = FinalReceivingLineNumber
                                .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineNumber
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Write to error log
                            'Log error on update failure
                            Dim TempReceiverNumber As Integer = 0
                            Dim strReceiverNumber As String
                            TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                            strReceiverNumber = CStr(TempReceiverNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Receipt Of Goods --- Update Line # - re-order lines"
                            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        ReceivingLineNumber = ReceivingLineNumber + 1
                    Next

                    'Show data with re-ordered lines
                    ShowReceiverLines()
                    '******************************************************************************************************************************************
                    'If company division is TFF, determine Vendor Class
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                        Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
                        VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = txtVendorID.Text
                        VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            VendorClass = CStr(VendorClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            VendorClass = "CANADIAN"
                        End Try
                        con.Close()
                    Else
                        'Continue - vendor class does not matter
                    End If

                    'Extract Line data from the datagrid
                    For Each row As DataGridViewRow In dgvReceivingLines.Rows
                        Dim cell As DataGridViewTextBoxCell = row.Cells("ReceivingHeaderKeyColumn")

                        If cell.Value = Val(cboReceivingTicketNumber.Text) Then
                            Dim ReceivingHeaderKey As Integer = row.Cells("ReceivingHeaderKeyColumn").Value
                            Dim ReceivingLineKey As Integer = row.Cells("ReceivingLineKeyColumn").Value
                            Dim ExtendedAmount As Double = Math.Round(row.Cells("ExtendedAmountColumn").Value, 2)
                            Dim DebitGLAccount As String = row.Cells("DebitGLAccountColumn").Value
                            Dim CreditGLAccount As String = row.Cells("CreditGLAccountColumn").Value
                            Dim QuantityReceived As Double = row.Cells("QuantityReceivedColumn").Value
                            Dim UnitCost As Double = row.Cells("UnitCostColumn").Value
                            Dim PartNumber As String = row.Cells("PartNumberColumn").Value
                            Dim PartDescription As String = row.Cells("PartDescriptionColumn").Value
                            '****************************************************************************************************************************
                            If CreditGLAccount = "11400" And PartNumber <> "EMPLOYEEPURCHASES" Then
                                'Get Credit GL Account from the Item List
                                Dim PartItemClass As String = ""
                                Dim PartCreditAccount As String = ""

                                Dim PartItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                                Dim PartItemClassCommand As New SqlCommand(PartItemClassStatement, con)
                                PartItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                                PartItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    PartItemClass = CStr(PartItemClassCommand.ExecuteScalar)
                                Catch ex As Exception
                                    PartItemClass = ""
                                End Try
                                con.Close()

                                Dim PartCreditAccountStatement As String = "SELECT GLInventoryAccouht FROM ItemClass WHERE ItemClassID = @ItemClassID"
                                Dim PartCreditAccountCommand As New SqlCommand(PartCreditAccountStatement, con)
                                PartCreditAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = PartItemClass

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    PartCreditAccount = CStr(PartCreditAccountCommand.ExecuteScalar)
                                Catch ex As Exception
                                    PartCreditAccount = ""
                                End Try
                                con.Close()

                                If PartCreditAccount <> "" Then
                                    CreditGLAccount = PartCreditAccount
                                Else
                                    CreditGLAccount = "64500"
                                End If
                            Else
                                'Do nothing
                            End If
                            '****************************************************************************************************************************
                            'Verify that Receiver has not been written to the GL Transaction Master List
                            Dim CheckGLReceiverStatement As String = "SELECT COUNT(GLTransactionKey) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND GLReferenceLine = @GLReferenceLine AND DivisionID = @DivisionID"
                            Dim CheckGLReceiverCommand As New SqlCommand(CheckGLReceiverStatement, con)
                            CheckGLReceiverCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = ReceivingHeaderKey
                            CheckGLReceiverCommand.Parameters.Add("@GLReferenceLine", SqlDbType.VarChar).Value = ReceivingLineKey
                            CheckGLReceiverCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                CheckGLReceiver = CInt(CheckGLReceiverCommand.ExecuteScalar)
                            Catch ex As Exception
                                CheckGLReceiver = 0
                            End Try
                            con.Close()
                            '****************************************************************************************************************************
                            If CheckGLReceiver <> 0 Then
                                'Skip posting - Receiver Line already posted
                            Else
                                'Validate Credit and Debit GL Accounts
                                If DebitGLAccount = "" Then
                                    DebitGLAccount = "20999"
                                End If

                                If CreditGLAccount = "" Then
                                    CreditGLAccount = "12100"
                                End If
                                '****************************************************************************************************************************
                                'Write Purchased Values to Inventory Costing Table
                                GetItemClass = ""
                                Dim GetPPL As String = ""
                                Dim GetSPL As String = ""

                                'Get Requirements for the specific cert code
                                Dim GetItemDataString As String = "SELECT ItemClass, PurchProdLineID, SalesProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                                Dim GetItemDataCommand As New SqlCommand(GetItemDataString, con)
                                GetItemDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                                GetItemDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Dim Reader As SqlDataReader = GetItemDataCommand.ExecuteReader()
                                If Reader.HasRows Then
                                    Reader.Read()
                                    If IsDBNull(Reader.Item("ItemClass")) Then
                                        GetItemClass = ""
                                    Else
                                        GetItemClass = Reader.Item("ItemClass")
                                    End If
                                    If IsDBNull(Reader.Item("PurchProdLineID")) Then
                                        GetPPL = ""
                                    Else
                                        GetPPL = Reader.Item("PurchProdLineID")
                                    End If
                                    If IsDBNull(Reader.Item("SalesProdLineID")) Then
                                        GetSPL = ""
                                    Else
                                        GetSPL = Reader.Item("SalesProdLineID")
                                    End If
                                Else
                                    GetItemClass = ""
                                    GetPPL = ""
                                    GetSPL = ""
                                End If
                                Reader.Close()
                                con.Close()
                                '******************************************************************************************************************************************
                                Select Case GetItemClass
                                    Case "BOXES"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "CIP"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "CURRENCY"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "EMPLOYEEPURCHASE"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "Equipment for shop use"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "EXPENSES"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "FACTORY SUPPLIES"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "FIXED ASSET"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "FREIGHT"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "GST TAX"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "LABOR"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "MISC ITEMS"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "MISC-CHARGE"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "OUTSIDE WORK"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "PST TAX"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "RENTAL"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "REPAIR"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SALES TAX"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-BUILDING"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-CONSTRUCTION"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-EQUIPMENT"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-FACTORY"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-JANITORIAL"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-MISC"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-OFFICE"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-PLATING"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-REPAIR PARTS"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-SHIPPING"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case "SUPPLY-TOOLROOM"
                                        CheckItemClass = "NON-INVENTORY"
                                    Case Else
                                        CheckItemClass = GetItemClass
                                End Select

                                If CheckItemClass = "NON-INVENTORY" Or GetPPL = "NON-INVENTORY" Or GetSPL = "SUPPLY" Or CheckItemClass = "" Then
                                    'Skip Cost Tier
                                Else
                                    'Extract the Upper and Lower Limit of the Inventory Costing Table
                                    Dim NewUpperLimit, LowerLimit, UpperLimit As Double
                                    Dim MaxTransactionNumber As Integer
                                    Dim MaxDate As String = ""

                                    'Get Max date first
                                    Dim MAXDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        MaxDate = CStr(MAXDateCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        MaxDate = ""
                                    End Try
                                    con.Close()

                                    Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
                                    Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                                    MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    MaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MaxDate

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        MaxTransactionNumber = 0
                                    End Try
                                    con.Close()

                                    Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID AND PartNumber = @PartNumber"
                                    Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                                    UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
                                    UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        UpperLimit = 0
                                    End Try
                                    con.Close()

                                    'Calculate the NEW Lower/Upper Limit for the next post
                                    LowerLimit = UpperLimit + 1
                                    NewUpperLimit = LowerLimit + QuantityReceived - 1

                                    'Get next Transaction Number
                                    Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
                                    Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        LastCostingTransactionNumber = 63600000
                                    End Try
                                    con.Close()

                                    NextCostingTransactionNumber = LastCostingTransactionNumber + 1

                                    'Write Values to Inventory Costing Table
                                    Try
                                        cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                                        With cmd.Parameters
                                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                            .Add("@CostingDate", SqlDbType.VarChar).Value = ConvertReceiverDate
                                            .Add("@ItemCost", SqlDbType.VarChar).Value = UnitCost
                                            .Add("@CostQuantity", SqlDbType.VarChar).Value = QuantityReceived
                                            .Add("@Status", SqlDbType.VarChar).Value = "PO RECEIVING"
                                            .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                                            .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ReceivingHeaderKey
                                            .Add("@ReferenceLine", SqlDbType.VarChar).Value = ReceivingLineKey
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()

                                        LowerLimit = 0
                                        UpperLimit = 0
                                        NewUpperLimit = 0
                                        NextCostingTransactionNumber = 0
                                        LastCostingTransactionNumber = 0
                                    Catch ex As Exception
                                        'Write to error log
                                        'Log error on update failure
                                        Dim TempReceiverNumber As Integer = 0
                                        Dim strReceiverNumber As String
                                        TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                                        strReceiverNumber = CStr(TempReceiverNumber)

                                        ErrorDate = TodaysDate
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Receipt Of Goods --- Insert into Inventory Costing"
                                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                    '****************************************************************************************************************************
                                    'Write Values to Inventory Transaction Table

                                    'Find Next Transaction Number
                                    Dim InventoryTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
                                    Dim InventoryTransactionNumberCommand As New SqlCommand(InventoryTransactionNumberStatement, con)

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        LastInventoryTransactionNumber = CInt(InventoryTransactionNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        LastInventoryTransactionNumber = 867500000
                                    End Try
                                    con.Close()

                                    NextInventoryTransactionNumber = LastInventoryTransactionNumber + 1
                                    '******************************************************************************************************************************************
                                    'Write Data to the Inventory Transaction Table
                                    Try
                                        cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                                        With cmd.Parameters
                                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                                            .Add("@TransactionDate", SqlDbType.VarChar).Value = ConvertReceiverDate
                                            .Add("@TransactionType", SqlDbType.VarChar).Value = "RECEIPT OF GOODS"
                                            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = ReceivingHeaderKey
                                            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = ReceivingLineKey
                                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                            .Add("@Quantity", SqlDbType.VarChar).Value = QuantityReceived
                                            .Add("@ItemCost", SqlDbType.VarChar).Value = UnitCost
                                            .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedAmount
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                            .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                                            .Add("@GLAccount", SqlDbType.VarChar).Value = CreditGLAccount
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Write to error log
                                        'Log error on update failure
                                        Dim TempReceiverNumber As Integer = 0
                                        Dim strReceiverNumber As String
                                        TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                                        strReceiverNumber = CStr(TempReceiverNumber)

                                        ErrorDate = TodaysDate
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Receipt Of Goods --- Insert into Inventory Transactions"
                                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                End If

                                '**************************************************************************************************************************
                                'GL Posting
                                '**************************************************************************************************************************
                                'If Vendor Class is Canadian, write to the appropriate GL Account
                                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                    DebitGLAccount = "C$" & DebitGLAccount
                                    CreditGLAccount = "C$" & CreditGLAccount

                                    'Validate GL Account
                                    Dim CheckDebitAccount, CheckCreditAccount As Integer

                                    Dim CheckCreditAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID AND PartNumber = @PartNumber"
                                    Dim CheckCreditAccountCommand As New SqlCommand(CheckCreditAccountStatement, con)
                                    CheckCreditAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = CreditGLAccount

                                    Dim CheckDebitAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID AND PartNumber = @PartNumber"
                                    Dim CheckDebitAccountCommand As New SqlCommand(CheckDebitAccountStatement, con)
                                    CheckDebitAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        CheckCreditAccount = CInt(CheckCreditAccountCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        CheckCreditAccount = 0
                                    End Try
                                    Try
                                        CheckDebitAccount = CInt(CheckDebitAccountCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        CheckDebitAccount = 0
                                    End Try
                                    con.Close()

                                    If CheckCreditAccount = 0 Or CheckDebitAccount = 0 Then
                                        'Write to error log
                                        Dim TempReceiverNumber As Integer = 0
                                        Dim strReceiverNumber As String
                                        TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                                        strReceiverNumber = CStr(TempReceiverNumber)

                                        ErrorDate = TodaysDate
                                        ErrorComment = "Receiver used a nonexistaent G/L Account"
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Receipt Of Goods --- Canadian GL Account"
                                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    Else
                                        'Continue
                                    End If
                                Else
                                    'Do nothing - proceed as usual
                                End If
                                '****************************************************************************************************************************
                                'Recalculate Extended Amount based on the Quantity/Cost
                                ExtendedAmount = Math.Round(QuantityReceived * UnitCost, 2)

                                Try
                                    'Command to write to GL
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Goods"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ConvertReceiverDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Vendor " & txtVendorID.Text & "-- PO Number " & Val(cboPONumber.Text)
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "PURCHASESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = ReceivingHeaderKey
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = ReceivingHeaderKey
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ReceivingLineKey
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Write to error log
                                    'Log error on update failure
                                    Dim TempReceiverNumber As Integer = 0
                                    Dim strReceiverNumber As String
                                    TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                                    strReceiverNumber = CStr(TempReceiverNumber)

                                    ErrorDate = TodaysDate
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Receipt Of Goods --- Insert into GL Line Items"
                                    ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                                '****************************************************************************************************************************
                                Try
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = CreditGLAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Goods"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ConvertReceiverDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Vendor " & txtVendorID.Text & "-- PO Number " & Val(cboPONumber.Text)
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "PURCHASESJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = ReceivingHeaderKey
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = ReceivingHeaderKey
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ReceivingLineKey
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Write to error log
                                    'Log error on update failure
                                    Dim TempReceiverNumber As Integer = 0
                                    Dim strReceiverNumber As String
                                    TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                                    strReceiverNumber = CStr(TempReceiverNumber)

                                    ErrorDate = TodaysDate
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Receipt Of Goods --- Insert into GL Line Items"
                                    ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try

                                '**********************************
                                'End of Ledger Entry
                                '**********************************

                                'UPDATE Receiving Line Status
                                Try
                                    cmd = New SqlCommand("UPDATE ReceivingLineTable SET LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)

                                    With cmd.Parameters
                                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceivingHeaderKey
                                        .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineKey
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Write to error log
                                    'Log error on update failure
                                    Dim TempReceiverNumber As Integer = 0
                                    Dim strReceiverNumber As String
                                    TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                                    strReceiverNumber = CStr(TempReceiverNumber)

                                    ErrorDate = TodaysDate
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "Receipt Of Goods --- Update Receiving Lines"
                                    ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                            End If
                        End If
                    Next

                    '**************************************************
                    'Check line status to update PO Line Table
                    '**************************************************

                    'For each row in the receiver, update po lines
                    For Each row As DataGridViewRow In dgvReceivingLines.Rows

                        Dim RowPONumber As Integer = Val(cboPONumber.Text)
                        Dim RowPOLineNumber As Integer = row.Cells("POLineNumberColumn").Value

                        Dim OrderQuantityString As String = "SELECT OrderQuantity FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                        Dim OrderQuantityCommand As New SqlCommand(OrderQuantityString, con)
                        OrderQuantityCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = RowPONumber
                        OrderQuantityCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = RowPOLineNumber

                        Dim POQuantityReceivedString As String = "SELECT SUM(POQuantityReceived) FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                        Dim POQuantityReceivedCommand As New SqlCommand(POQuantityReceivedString, con)
                        POQuantityReceivedCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = RowPONumber
                        POQuantityReceivedCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = RowPOLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            POOrderQuantity = CDbl(OrderQuantityCommand.ExecuteScalar)
                        Catch ex As Exception
                            POOrderQuantity = 0
                        End Try
                        Try
                            POQuantityReceived = CDbl(POQuantityReceivedCommand.ExecuteScalar)
                        Catch ex As Exception
                            POQuantityReceived = 0
                        End Try
                        con.Close()

                        If POOrderQuantity <= POQuantityReceived Then
                            Try
                                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                                With cmd.Parameters
                                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = RowPONumber
                                    .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = RowPOLineNumber
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Write to error log
                                'Log error on update failure
                                Dim TempReceiverNumber As Integer = 0
                                Dim strReceiverNumber As String
                                TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                                strReceiverNumber = CStr(TempReceiverNumber)

                                ErrorDate = TodaysDate
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Receipt Of Goods --- Update PO Lines"
                                ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            Try
                                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                                With cmd.Parameters
                                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = RowPONumber
                                    .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = RowPOLineNumber
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Write to error log
                                'Log error on update failure
                                Dim TempReceiverNumber As Integer = 0
                                Dim strReceiverNumber As String
                                TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                                strReceiverNumber = CStr(TempReceiverNumber)

                                ErrorDate = TodaysDate
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Receipt Of Goods --- Update PO Lines"
                                ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End If
                    Next

                    '**************************************************
                    'Check line status to write to Header if necessary
                    '**************************************************
                    Dim CheckLineStatus As Integer = 0

                    Dim CheckLineStatusString As String = "SELECT COUNT(PurchaseOrderHeaderKey) FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND LineStatus = @LineStatus"
                    Dim CheckLineStatusCommand As New SqlCommand(CheckLineStatusString, con)
                    CheckLineStatusCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                    CheckLineStatusCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckLineStatus = CInt(CheckLineStatusCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckLineStatus = 0
                    End Try
                    con.Close()

                    If CheckLineStatus > 0 Then
                        Try
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Write to error log
                            'Log error on update failure
                            Dim TempReceiverNumber As Integer = 0
                            Dim strReceiverNumber As String
                            TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                            strReceiverNumber = CStr(TempReceiverNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Receipt Of Goods --- Update PO Header (OPEN)"
                            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        Try
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Write to error log
                            'Log error on update failure
                            Dim TempReceiverNumber As Integer = 0
                            Dim strReceiverNumber As String
                            TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                            strReceiverNumber = CStr(TempReceiverNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Receipt Of Goods --- Update PO Header (CLOSED)"
                            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    End If
                    '**************************************************************************************************************
                    Try
                        'UPDATE Receiving Header Status
                        cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status, ReceivingAgent = @ReceivingAgent, PrintDate = @PrintDate WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                            .Add("@ReceivingAgent", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String
                        TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Receipt Of Goods --- Update Receiving Header"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    '**********************************************************************************************
                    'Auto-print receiver
                    If cboDivisionID.Text = "CGO" Or cboDivisionID.Text = "TFT" Or cboDivisionID.Text = "TST" Then
                        GlobalAutoPrintReceiver = "YES"

                        GlobalReceiverNumber = Val(cboReceivingTicketNumber.Text)
                        GlobalDivisionCode = cboDivisionID.Text

                        Using NewPrintReceiver As New PrintReceiver
                            Dim Result = NewPrintReceiver.ShowDialog()
                            NewPrintReceiver.Visible = False
                            NewPrintReceiver.Hide()
                        End Using
                    Else
                        'Skip auto-print
                        GlobalAutoPrintReceiver = "NO"
                    End If
                    '**********************************************************************************************
                    unlockBatch()

                    'Clear Data after POSTING
                    ClearData()
                    ShowReceiverLines()

                    MsgBox("Receipt of Goods has been posted and no further changes may be made.", MsgBoxStyle.OkOnly)
                End If
            Catch ex As Exception
                MsgBox("There is a problem with this Receiver. Please contact System Administrator.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Function canPost() As Boolean
        If ConvertReceiverDate > TodaysDate Then
            MsgBox("You cannot post a receiver to a future date.", MsgBoxStyle.OkOnly)
            dtpReceivingDate.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboReceivingTicketNumber.Text) Then
            MessageBox.Show("You must enter a receiving number", "Enter a receiving number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReceivingTicketNumber.Focus()
            Return False
        End If
        If cboReceivingTicketNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid receiving number", "Enter a valid receiving number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReceivingTicketNumber.SelectAll()
            cboReceivingTicketNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            isLoaded = False
            ShowReceiverLines()
            LoadReceiverData()
            checkRows()
            CalculateReceiverTotals()
            isLoaded = True
            Return False
        End If
        If String.IsNullOrEmpty(cboPONumber.Text) Then
            MessageBox.Show("You must enter a PO number", "Enter a PO number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPONumber.Focus()
            Return False
        End If
        If cboPONumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid PO number", "Enter a valid PO number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPONumber.SelectAll()
            cboPONumber.Focus()
            Return False
        End If
        GetStatus()
        If CheckReceiverStatus <> "OPEN" Then
            MsgBox("This Receiver has already been received.", MsgBoxStyle.OkOnly)
            Return False
        End If
        deleteZeroRows()
        countRows()
        If CountReceiverLines = 0 Then
            MsgBox("You cannot post a Receiver with no lines.", MsgBoxStyle.OkOnly)
            Return False
        End If
        If String.IsNullOrEmpty(txtVendorID.Text) Then
            MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
            Return False
        End If
        negCheck()
        If CheckNegatives = "YES" Then
            MsgBox("There are negative quantities on this receiver - fix and try again.", MsgBoxStyle.OkOnly)
            Return False
        End If
        Return True
    End Function

    Private Function cantContinue() As Boolean
        Dim aboveFound As Boolean = False
        Dim msg As String = "You are receiving items(s)"
        For i As Integer = 0 To ds.Tables("ReceivingLineTable").Rows.Count - 1
            cmd = New SqlCommand("SELECT OrderQuantity - POQuantityReceived FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @POLineNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = cboPONumber.Text
            cmd.Parameters.Add("@POLineNumber", SqlDbType.VarChar).Value = ds.Tables("ReceivingLineTable").Rows(i).Item("POLineNumber")
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            reader.Read()
            Dim poOpenQuant As Double = reader.GetValue(0)
            reader.Close()
            con.Close()
            If ds.Tables("ReceivingLineTable").Rows(i).Item("QuantityReceived") > poOpenQuant Then
                If aboveFound = False Then
                    aboveFound = True
                    msg += " " + ds.Tables("ReceivingLineTable").Rows(i).Item("PartNumber")
                Else
                    msg += ", " + ds.Tables("ReceivingLineTable").Rows(i).Item("PartNumber")
                End If
            End If
        Next
        If aboveFound Then
            Dim rslt As DialogResult = MessageBox.Show(msg + " with quantities above what is ordered, do you wish to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rslt <> DialogResult.Yes Then
                Return True
            End If
        End If
        If isSomeoneEditing() Then
            isLoaded = False
            ShowReceiverLines()
            LoadReceiverData()
            checkRows()
            CalculateReceiverTotals()
            isLoaded = True
            Return True
        End If
        Return False
    End Function

    Private Sub GetStatus()
        'Check to see if receiver is posted
        Dim CheckReceiverStatusString As String = "SELECT Status FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim CheckReceiverStatusCommand As New SqlCommand(CheckReceiverStatusString, con)
        CheckReceiverStatusCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        CheckReceiverStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckReceiverStatus = CStr(CheckReceiverStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CheckReceiverStatus = "RECEIVED"
        End Try
        con.Close()
    End Sub

    Private Sub countRows()
        'Verify Lines on the receiver
        Dim CountReceiverLinesString As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim CountReceiverLinesCommand As New SqlCommand(CountReceiverLinesString, con)
        CountReceiverLinesCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        CountReceiverLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountReceiverLines = CInt(CountReceiverLinesCommand.ExecuteScalar)
        Catch ex As Exception
            CountReceiverLines = 0
        End Try
        con.Close()
    End Sub

    Private Sub negCheck()
        'Check to see if there are negative quantites on receiver
        For Each row As DataGridViewRow In dgvReceivingLines.Rows
            Dim ReceivingLineQuantity As Integer = row.Cells("QuantityReceivedColumn").Value
            CheckNegatives = "NO"

            If ReceivingLineQuantity < 0 Then
                CheckNegatives = "YES"
                Exit For
            End If
        Next
    End Sub

    Private Sub deleteZeroRows()
        Try
            cmd = New SqlCommand("DELETE FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID AND (QuantityReceived = @QuantityReceived OR QuantityReceived IS NULL)", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@QuantityReceived", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Write to error log
            'Log error on update failure
            Dim TempReceiverNumber As Integer = 0
            Dim strReceiverNumber As String
            TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
            strReceiverNumber = CStr(TempReceiverNumber)

            ErrorDate = TodaysDate
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Receipt Of Goods --- Delete Receiver"
            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        ShowReceiverLines()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Verify PO Number and Make sure Receipt Number isn't blank
        If cboReceivingTicketNumber.Text = "" Or cboPONumber.Text = "" Or Val(cboReceivingTicketNumber.Text) = 0 Or Val(cboPONumber.Text) = 0 Then
            MsgBox("Cannot create Receiving Ticket without a valid Ticket Number and PO Number", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If isSomeoneEditing() Then
            isLoaded = False
            ShowReceiverLines()
            LoadReceiverData()
            checkRows()
            CalculateReceiverTotals()
            isLoaded = True
            Exit Sub
        End If

        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to Save this Receiving Ticket?", "SAVE RECEIPT OF GOODS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Check Receiver Status
            Dim CheckReceiverStatusStatement As String = "SELECT Status FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
            Dim CheckReceiverStatusCommand As New SqlCommand(CheckReceiverStatusStatement, con)
            CheckReceiverStatusCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
            CheckReceiverStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckReceiverStatus = CStr(CheckReceiverStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckReceiverStatus = "RECEIVED"
            End Try
            con.Close()

            If CheckReceiverStatus <> "OPEN" Then
                MsgBox("Changes cannot be saved at this time.", MsgBoxStyle.OkOnly)
            Else
                ConvertPODate = dtpPODate.Value
                ConvertReceiverDate = dtpReceivingDate.Value

                'Validate Vendor
                Dim VerifyVendorStatement As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
                Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
                VerifyVendorCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
                Catch ex As Exception
                    VerifyVendor = ""
                End Try
                con.Close()

                If txtVendorID.Text <> VerifyVendor Then
                    MsgBox("Vendor must match the vendor from the PO.", MsgBoxStyle.OkOnly)
                Else

                    CalculateReceiverTotals()
                    ReceiverStatus = "OPEN"

                    Try
                        UpdateReceivingHeaderTable()
                    Catch ex1 As Exception
                        'Write to error log
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String
                        TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex1.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Receipt Of Goods --- Update Header Table on Save"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
            End If
        ElseIf button = DialogResult.No Then
            cmdSave.Focus()
        End If
    End Sub

    Private Sub SaveReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveReceiptToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub PrintReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReceiptToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboReceivingTicketNumber.Text = "" Then
            MsgBox("You must have a valid Receiver Number selected.", MsgBoxStyle.OkOnly)
        End If

        'Validate Vendor
        Dim VerifyVendorStatement As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
        VerifyVendorCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyVendor = ""
        End Try
        con.Close()

        If txtVendorID.Text <> VerifyVendor Then
            MsgBox("Vendor must match the vendor from the PO.", MsgBoxStyle.OkOnly)
        Else
            'Check Receiver Status
            Dim CheckReceiverStatusStatement As String = "SELECT Status FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
            Dim CheckReceiverStatusCommand As New SqlCommand(CheckReceiverStatusStatement, con)
            CheckReceiverStatusCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
            CheckReceiverStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckReceiverStatus = CStr(CheckReceiverStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckReceiverStatus = "RECEIVED"
            End Try
            con.Close()

            If CheckReceiverStatus <> "OPEN" Then
                GlobalReceiverNumber = Val(cboReceivingTicketNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintReceiver As New PrintReceiver
                    Dim Result = NewPrintReceiver.ShowDialog()
                End Using
            Else
                ConvertPODate = dtpPODate.Value
                ConvertReceiverDate = dtpReceivingDate.Value

                CalculateReceiverTotals()
                ReceiverStatus = "OPEN"

                If Not isSomeoneEditing() Then
                    Try
                        UpdateReceivingHeaderTable()
                    Catch ex1 As Exception
                        'Write to error log
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String
                        TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex1.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Receipt Of Goods --- Update Header on Print"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    isLoaded = False
                    ShowReceiverLines()
                    LoadReceiverData()
                    checkRows()
                    CalculateReceiverTotals()
                    isLoaded = True
                End If

                GlobalReceiverNumber = Val(cboReceivingTicketNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintReceiver As New PrintReceiver
                    Dim Result = NewPrintReceiver.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboReceivingTicketNumber.Text = "" Then
            Exit Sub
        End If

        If isSomeoneEditing() Then
            isLoaded = False
            ShowReceiverLines()
            LoadReceiverData()
            checkRows()
            CalculateReceiverTotals()
            isLoaded = True
            Exit Sub
        End If

        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Receiving Ticket?", "DELETE RECEIPT OF GOODS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            PSUpload.DeletePackingSlip()
            'Check Receiver Status
            Dim CheckReceiverStatusStatement As String = "SELECT Status FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
            Dim CheckReceiverStatusCommand As New SqlCommand(CheckReceiverStatusStatement, con)
            CheckReceiverStatusCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
            CheckReceiverStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckReceiverStatus = CStr(CheckReceiverStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckReceiverStatus = "RECEIVED"
            End Try
            con.Close()

            If CheckReceiverStatus <> "OPEN" Then
                MsgBox("Receiver cannot be deleted.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Reset to 0
                CheckLedgerTotal = 0

                For Each row As DataGridViewRow In dgvReceivingLines.Rows
                    Dim TempReceivingLineNumber2 As Integer = row.Cells("ReceivingLineKeyColumn").Value

                    Dim CheckLedgerStatement As String = "SELECT COUNT(GLTransactionKey) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND GLReferenceLine = @GLReferenceLine AND DivisionID = @DivisionID"
                    Dim CheckLedgerCommand As New SqlCommand(CheckLedgerStatement, con)
                    CheckLedgerCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                    CheckLedgerCommand.Parameters.Add("@GLReferenceLine", SqlDbType.VarChar).Value = TempReceivingLineNumber2
                    CheckLedgerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckLedger = CInt(CheckLedgerCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckLedger = 0
                    End Try
                    con.Close()

                    CheckLedgerTotal = CheckLedgerTotal + CheckLedger
                Next

                If CheckLedgerTotal <> 0 Then
                    MsgBox("This receiver cannot be deleted. Contact system administrator.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    '*****************************************************************************************************
                    'Write to Audit Trail Table
                    Dim AuditComment As String = ""
                    Dim AuditReceiverNumber As Integer = 0
                    Dim strReceiverNumber As String = ""

                    AuditReceiverNumber = Val(cboReceivingTicketNumber.Text)
                    strReceiverNumber = CStr(AuditReceiverNumber)
                    AuditComment = "Receiver #" + strReceiverNumber + " for vendor " + txtVendorID.Text + " was deleted on " + TodaysDate

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "RECEIVER - DELETION"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(txtReceiverTotal.Text)
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strReceiverNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip
                    End Try
                    '*****************************************************************************************************
                    Try
                        'Create command to save data from text boxes
                        cmd = New SqlCommand("DELETE FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber1 As String = ""
                        TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                        strReceiverNumber1 = CStr(TempReceiverNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Receipt Of Goods --- Delete Receiver"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber1
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                        MessageBox.Show("Unable to delete receiving ticket, contact system admin", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try

                    'Change PO Status Back to Open
                    'Retrieve line data from PO Table to update
                    For Each row As DataGridViewRow In dgvReceivingLines.Rows
                        Dim POLineNumber As Integer = row.Cells("ReceivingLineKeyColumn").Value

                        Try
                            'Create command to Update PO Line Table
                            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)
                            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                            cmd.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = POLineNumber
                            cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Write to error log
                            'Log error on update failure
                            Dim TempReceiverNumber As Integer = 0
                            Dim strReceiverNumber1 As String = ""
                            TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                            strReceiverNumber1 = CStr(TempReceiverNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Receipt Of Goods --- Delete Receiver"
                            ErrorReferenceNumber = "Receiver # " + strReceiverNumber1
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                            MessageBox.Show("There was an error releasing the PO lines from the receiving ticket, contact system admin", "unable to release lines", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    Next

                    Try
                        'Create command to Update PO Header Table
                        cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
                        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber1 As String = ""
                        TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                        strReceiverNumber1 = CStr(TempReceiverNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Receipt Of Goods --- Delete Receiver"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber1
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                        MessageBox.Show("Unable to release PO from receiving ticket, contact system admin", "Unable to release PO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try

                    'Clear text boxes on delete
                    GlobalPONumber = 0
                    GlobalReceiverNumber = 0
                    GlobalSelectLinesPONumber = 0

                    GlobalSelectLinesReceiverNumber = 0
                    LoadReceiverNumber()
                    LoadReceiverData()
                    ClearVariables()
                    ClearData()
                    ShowReceiverLines()
                    LoadOpenReceivers()

                    'Prompt after deletion
                    MsgBox("This Receiving Ticket has been deleted.", MsgBoxStyle.OkOnly)
                End If
            End If
        ElseIf button = DialogResult.No Then
            cmdClear.Focus()
        End If
    End Sub

    Private Sub DeleteReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteReceiptToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Verify PO Number and Make sure Receipt Number isn't blank
        If cboReceivingTicketNumber.Text = "" Or Val(cboReceivingTicketNumber.Text) = 0 Then
            GlobalSelectLinesPONumber = 0
            GlobalSelectLinesReceiverNumber = 0
            ClearVariables()
            ClearData()
            Me.Dispose()
            Me.Close()
        Else
            'Check Receiver Status
            Dim CheckReceiverStatusStatement As String = "SELECT Status FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
            Dim CheckReceiverStatusCommand As New SqlCommand(CheckReceiverStatusStatement, con)
            CheckReceiverStatusCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
            CheckReceiverStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckReceiverStatus = CStr(CheckReceiverStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckReceiverStatus = "RECEIVED"
            End Try
            con.Close()

            If CheckReceiverStatus <> "OPEN" Then
                GlobalSelectLinesPONumber = 0
                GlobalSelectLinesReceiverNumber = 0
                ClearVariables()
                ClearData()
                Me.Dispose()
                Me.Close()
            Else
                If isSomeoneEditing() Then
                    GlobalSelectLinesPONumber = 0
                    GlobalSelectLinesReceiverNumber = 0
                    ClearVariables()
                    ClearData()
                    Me.Dispose()
                    Me.Close()
                    Exit Sub
                End If

                'Prompt before Saving
                Dim button As DialogResult = MessageBox.Show("Do you wish to Save this Receiving Ticket?", "SAVE RECEIPT OF GOODS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    If cboPONumber.Text = "" Or txtVendorID.Text = "" Then
                        MsgBox("You must have a valid PO Number and Vendor selected.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    Else
                        ConvertPODate = dtpPODate.Value
                        ConvertReceiverDate = dtpReceivingDate.Value

                        CalculateReceiverTotals()
                        ReceiverStatus = "OPEN"

                        'Validate Vendor
                        Dim VerifyVendorStatement As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
                        Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
                        VerifyVendorCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                        VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
                        Catch ex As Exception
                            VerifyVendor = ""
                        End Try
                        con.Close()

                        If txtVendorID.Text <> VerifyVendor Then
                            MsgBox("Vendor must match the vendor from the PO.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        Else
                            Try
                                UpdateReceivingHeaderTable()
                            Catch ex1 As Exception
                                'Write to error log
                                'Log error on update failure
                                Dim TempReceiverNumber As Integer = 0
                                Dim strReceiverNumber As String = ""
                                TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                                strReceiverNumber = CStr(TempReceiverNumber)

                                ErrorDate = TodaysDate
                                ErrorComment = ex1.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Receipt Of Goods --- Delete Receiver"
                                ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try

                            GlobalSelectLinesPONumber = 0
                            GlobalSelectLinesReceiverNumber = 0
                            ClearVariables()
                            ClearData()
                            Me.Dispose()
                            Me.Close()
                        End If


                    End If
                ElseIf button = DialogResult.No Then
                    GlobalSelectLinesPONumber = 0
                    GlobalSelectLinesReceiverNumber = 0
                    ClearVariables()
                    ClearData()
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        ' The return value specifies the previous state of the menu item (it is either      
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.      
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub

    Private Sub Receiving_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Public Sub UpdateReceivingHeaderTable()
        'If there is a scanned packing list - save to header table.
        Dim ReceiverFilename As String = ""
        Dim ReceiverFilenameAndPath As String = ""
        Dim strReceiverNumber As String = ""
        Dim ReceiverNumber As Integer = 0
        Dim TempFileName As String = ""

        'Verify that they have a receiver selected
        If cboReceivingTicketNumber.Text = "" Then
            'Do nothing
        Else
            ReceiverNumber = cboReceivingTicketNumber.Text
            strReceiverNumber = CStr(ReceiverNumber)
        End If

        ReceiverFilename = strReceiverNumber + ".pdf"
        ReceiverFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + ReceiverFilename

        If File.Exists(ReceiverFilenameAndPath) Then
            TempFileName = ReceiverFilename
        Else
            TempFileName = ""
        End If
        '**********************************************************************************************
        'Write Data to Receiving Header Database Table
        cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET PONumber = @PONumber, VendorCode = @VendorCode, ReceivingDate = @ReceivingDate, InvoiceNumber = @InvoiceNumber, HeaderComment = @HeaderComment, PODate = @PODate, ShipMethodID = @ShipMethodID, FreightCharge = @FreightCharge, SalesTax = @SalesTax, ProductTotal = @ProductTotal, POTotal = @POTotal, Status = @Status, TransferDivision = @TransferDivision, Locked = @Locked, ScannedFilename = @ScannedFilename WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
            .Add("@VendorCode", SqlDbType.VarChar).Value = txtVendorID.Text
            .Add("@ReceivingDate", SqlDbType.VarChar).Value = ConvertReceiverDate
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ""
            .Add("@HeaderComment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@PODate", SqlDbType.VarChar).Value = ConvertPODate
            .Add("@ShipMethodID", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
            .Add("@SalesTax", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@POTotal", SqlDbType.VarChar).Value = ReceiverTotal
            .Add("@Status", SqlDbType.VarChar).Value = ReceiverStatus
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@TransferDivision", SqlDbType.VarChar).Value = ""
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@ScannedFilename", SqlDbType.VarChar).Value = TempFileName
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub InsertIntoReceivingHeaderTable()
        'Write Data to Receiving Header Database Table
        cmd = New SqlCommand("Insert Into ReceivingHeaderTable(ReceivingHeaderKey, PONumber, VendorCode, ReceivingDate, InvoiceNumber, HeaderComment, PODate, ShipMethodID, FreightCharge, SalesTax, ProductTotal, POTotal, Status, DivisionID, TransferDivision, ReceivingAgent, Locked) Values (@ReceivingHeaderKey, @PONumber, @VendorCode, @ReceivingDate, @InvoiceNumber, @HeaderComment, @PODate, @ShipMethodID, @FreightCharge, @SalesTax, @ProductTotal, @POTotal, @Status, @DivisionID, @TransferDivision, @ReceivingAgent, @Locked)", con)

        With cmd.Parameters
            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
            .Add("@VendorCode", SqlDbType.VarChar).Value = txtVendorID.Text
            .Add("@ReceivingDate", SqlDbType.VarChar).Value = ConvertReceiverDate
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ""
            .Add("@HeaderComment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@PODate", SqlDbType.VarChar).Value = ConvertPODate
            .Add("@ShipMethodID", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
            .Add("@SalesTax", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@POTotal", SqlDbType.VarChar).Value = ReceiverTotal
            .Add("@Status", SqlDbType.VarChar).Value = ReceiverStatus
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@TransferDivision", SqlDbType.VarChar).Value = ""
            .Add("@ReceivingAgent", SqlDbType.VarChar).Value = EmployeeSalespersonCode
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub txtSalesTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTax.TextChanged
        If txtProductTotal.Text.Length > 1 Then
            Dim test As Double = Val(txtProductTotal.Text.Replace("$", "").Replace(",", ""))
            txtReceiverTotal.Text = FormatCurrency(test + Val(txtSalesTax.Text.Replace("$", "").Replace(",", "")) + Val(txtFreightCharge.Text.Replace("$", "").Replace(",", "")), 2)
        End If
    End Sub

    Private Sub txtFreightCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightCharge.TextChanged
        If txtProductTotal.Text.Length > 1 Then
            Dim test As Double = Val(txtProductTotal.Text.Replace("$", "").Replace(",", ""))
            txtReceiverTotal.Text = FormatCurrency(test + Val(txtSalesTax.Text.Replace("$", "").Replace(",", "")) + Val(txtFreightCharge.Text.Replace("$", "").Replace(",", "")), 2)
        End If
    End Sub

    Private Sub dgvReceivingLines_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvReceivingLines.DataError
        If isLoaded Then
            If dgvReceivingLines.Rows.Count > 0 Then
                If e.Exception.Message.ToString().Contains("Input string was not in a correct") Then
                    dgvReceivingLines.RefreshEdit()
                End If
            End If
        End If
    End Sub

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
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
        cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Locked = @Locked WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = cboReceivingTicketNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Locked = '' WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND Locked = @Locked AND DivisionID = @DivisionID", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        Else
            cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub UnLockReceiverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockReceiverToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboReceivingTicketNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to unlock this Receiver?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Locked = '' WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Receiver is now unlocked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a Receiver number to unlock", "Enter a Receiver number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReceivingTicketNumber.Focus()
        End If
    End Sub

    Private Sub Receiving_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(cboReceivingTicketNumber.Text) Then
            unlockBatch()
        End If
    End Sub

    Private Sub txtVendorID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVendorID.TextChanged
        LoadVendorName()
    End Sub

    Private Sub cmdViewPackingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPackingList.Click
        Dim ReceiverFilename As String = ""
        Dim ReceiverFilenameAndPath As String = ""

        If cboReceivingTicketNumber.Text = "" Then
            'Do nothing
        Else
            Dim UploadedReceiverNumber As String = cboReceivingTicketNumber.Text

            ReceiverFilename = UploadedReceiverNumber + ".pdf"
            ReceiverFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + ReceiverFilename

            If File.Exists(ReceiverFilenameAndPath) Then
                System.Diagnostics.Process.Start(ReceiverFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdUploadPackingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadPackingSlip.Click
    End Sub

    Private Sub cmdRemoteScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoteScan.Click
        Dim ReceiverFilename As String = ""
        Dim ReceiverFilenameAndPath As String = ""
        Dim strReceiverNumber As String = ""
        Dim ReceiverNumber As Integer = 0

        'Verify that they have a receiver selected
        If cboReceivingTicketNumber.Text = "" Then
            MsgBox("You must select a valid receiver.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            ReceiverNumber = cboReceivingTicketNumber.Text
            strReceiverNumber = CStr(ReceiverNumber)
        End If

        Dim UploadedReceiverNumber As String = cboReceivingTicketNumber.Text

        ReceiverFilename = strReceiverNumber + ".pdf"
        ReceiverFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + ReceiverFilename

        If File.Exists(ReceiverFilenameAndPath) Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned receiver?", "OVERWRITE EXISTING RECEIVER?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete existing receiver before upload
                File.Delete(ReceiverFilenameAndPath)

                Dim My_Process As New Process()
                'Dim My_Process_Info As New ProcessStartInfo

                Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                strReceiverNumber = CStr(cboReceivingTicketNumber.Text)
                ReceiverFilename = strReceiverNumber + ".pdf"
                ReceiverFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + ReceiverFilename

                Try
                    My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    My_Process.StartInfo.CreateNoWindow = True
                    My_Process.Start(ApplicationFileAndPath, "-o " & ReceiverFilenameAndPath)
                    My_Process.Close()

                    cboReceivingTicketNumber.Refresh()
                    LoadScannedReceivers()
                    cboReceivingTicketNumber.Text = ReceiverNumber
                    cmdViewPackingList.Enabled = True

                    'Save file name to Receiver Header Table
                    cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET ScannedFilename = @ScannedFilename WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                        .Add("@ScannedFilename", SqlDbType.VarChar).Value = ReceiverFilename
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempReceiverNumber As Integer = 0
                    Dim strReceiverNumber1 As String = ""
                    TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                    strReceiverNumber1 = CStr(TempReceiverNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ApplicationFileAndPath & "" & ReceiverFilenameAndPath
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Receipt Of Goods --- Scan"
                    ErrorReferenceNumber = "Receiver # " + strReceiverNumber1
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MsgBox("Scan Failed - L3148", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            Dim My_Process As New Process()
            'Dim My_Process_Info As New ProcessStartInfo

            Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
            strReceiverNumber = CStr(cboReceivingTicketNumber.Text)
            ReceiverFilename = strReceiverNumber + ".pdf"
            ReceiverFileNameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + ReceiverFileName

            Try
                My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                My_Process.StartInfo.CreateNoWindow = True
                My_Process.Start(ApplicationFileAndPath, "-o " & ReceiverFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()

                cboReceivingTicketNumber.Refresh()
                LoadScannedReceivers()
                cboReceivingTicketNumber.Text = ReceiverNumber
                cmdViewPackingList.Enabled = True

                'Save file name to Receiver Header Table
                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET ScannedFilename = @ScannedFilename WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                    .Add("@ScannedFilename", SqlDbType.VarChar).Value = ReceiverFilename
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Log error on update failure
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber1 As String = ""
                TempReceiverNumber = Val(cboReceivingTicketNumber.Text)
                strReceiverNumber1 = CStr(TempReceiverNumber)

                ErrorDate = TodaysDate
                ErrorComment = ApplicationFileAndPath & "" & ReceiverFilenameAndPath
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Receipt Of Goods --- Scan"
                ErrorReferenceNumber = "Receiver # " + strReceiverNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan Failed L3204", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub
End Class