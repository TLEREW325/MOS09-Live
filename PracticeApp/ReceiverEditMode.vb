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
Public Class ReceiverEditMode
    Inherits System.Windows.Forms.Form

    Dim PartNumber, PartDescription, SelectForInvoice, VendorID, ReceiverDate, PODate, HeaderComment, ReceiverStatus, ShipMethodID, VendorName As String
    Dim FreightCharge, ProductTotal, SalesTax, ReceiverTotal, QuantityReceived, QuantityReturned, QuantityOnPO, QuantityVouched As Double
    Dim PONumber, ReceivingHeaderKey As Integer

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""
    Dim TodaysDate As Date = Now()

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ReceiverEditMode_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalReceiverNumber = 0
        ClearVariables()
        ClearData()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 399 Then
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

    Private Sub ReceiverEditMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If My.Computer.Name.StartsWith("TFP") Then
            ScanPackingSkipToolStripMenuItem.Visible = True
            ViewPackingSlipToolStripMenuItem.Visible = True
        Else
            ScanPackingSkipToolStripMenuItem.Visible = False
            ViewPackingSlipToolStripMenuItem.Visible = True
        End If

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
            gpxCloseLine.Enabled = True
            gpxCloseReceiver.Enabled = True
            gpxLineDetails.Enabled = True
            gpxPOHeader.Enabled = True
            gpxReceiverTotals.Enabled = True
            gpxReceivingHeaderInfo.Enabled = True
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveChangesToolStripMenuItem.Enabled = True
            DeleteReceiverToolStripMenuItem.Enabled = True
        ElseIf EmployeeCompanyCode = "TFP" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
            gpxCloseLine.Enabled = False
            gpxCloseReceiver.Enabled = False
            gpxLineDetails.Enabled = False
            gpxPOHeader.Enabled = False
            gpxReceiverTotals.Enabled = False
            gpxReceivingHeaderInfo.Enabled = False
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            SaveChangesToolStripMenuItem.Enabled = False
            DeleteReceiverToolStripMenuItem.Enabled = False
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
            gpxCloseLine.Enabled = True
            gpxCloseReceiver.Enabled = True
            gpxLineDetails.Enabled = True
            gpxPOHeader.Enabled = True
            gpxReceiverTotals.Enabled = True
            gpxReceivingHeaderInfo.Enabled = True
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveChangesToolStripMenuItem.Enabled = True
            DeleteReceiverToolStripMenuItem.Enabled = True
        End If

        LoadReceiverNumber()
        ShowReceiverLines()
        ClearData()
        ClearVariables()

        If GlobalReceiverNumber > 0 Then
            cboReceivingTicketNumber.Text = GlobalReceiverNumber
            cboDivisionID.Text = GlobalDivisionCode
        Else
            cboReceivingTicketNumber.SelectedIndex = -1
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "ADM" Then
            cboDivisionID.Enabled = True
            gpxCloseLine.Enabled = True
            gpxCloseReceiver.Enabled = True
            gpxLineDetails.Enabled = True
            gpxPOHeader.Enabled = True
            gpxReceiverTotals.Enabled = True
            gpxReceivingHeaderInfo.Enabled = True
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveChangesToolStripMenuItem.Enabled = True
            DeleteReceiverToolStripMenuItem.Enabled = True
        ElseIf cboDivisionID.Text = "TFP" Then
            cboDivisionID.Enabled = False
            gpxCloseLine.Enabled = False
            gpxCloseReceiver.Enabled = False
            gpxLineDetails.Enabled = False
            gpxPOHeader.Enabled = False
            gpxReceiverTotals.Enabled = False
            gpxReceivingHeaderInfo.Enabled = False
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            SaveChangesToolStripMenuItem.Enabled = False
            DeleteReceiverToolStripMenuItem.Enabled = False
        Else
            cboDivisionID.Enabled = False
            gpxCloseLine.Enabled = True
            gpxCloseReceiver.Enabled = True
            gpxLineDetails.Enabled = True
            gpxPOHeader.Enabled = True
            gpxReceiverTotals.Enabled = True
            gpxReceivingHeaderInfo.Enabled = True
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveChangesToolStripMenuItem.Enabled = True
            DeleteReceiverToolStripMenuItem.Enabled = True
        End If

        ClearData()
        ClearVariables()
        LoadReceiverNumber()
        ShowReceiverLines()
    End Sub

    Public Sub ShowReceiverLines()
        cmd = New SqlCommand("SELECT * FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceivingLineTable")
        dgvReceiverLines.DataSource = ds.Tables("ReceivingLineTable")
        cboReceiverLine.DataSource = ds.Tables("ReceivingLineTable")
        con.Close()
    End Sub

    Public Sub ShowRPCLines()
        cmd = New SqlCommand("SELECT * FROM ReceiverPurchaseClearing WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ReceiverPurchaseClearing")
        dgvReceiverPurchaseClearing.DataSource = ds1.Tables("ReceiverPurchaseClearing")
        con.Close()
    End Sub

    Public Sub LoadReceiverNumber()
        cmd = New SqlCommand("SELECT ReceivingHeaderKey FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID ORDER BY ReceivingHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ReceivingHeaderTable")
        cboReceivingTicketNumber.DataSource = ds2.Tables("ReceivingHeaderTable")
        con.Close()
        cboReceivingTicketNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadReceiverData()
        'Extract data from Receiver Header table
        Dim VendorIDString As String = "SELECT VendorCode FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim VendorIDCommand As New SqlCommand(VendorIDString, con)
        VendorIDCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        VendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PODateString As String = "SELECT PODate FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim PODateCommand As New SqlCommand(PODateString, con)
        PODateCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        PODateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim HeaderCommentString As String = "SELECT HeaderComment FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim HeaderCommentCommand As New SqlCommand(HeaderCommentString, con)
        HeaderCommentCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        HeaderCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipMethodIDString As String = "SELECT ShipMethodID FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim ShipMethodIDCommand As New SqlCommand(ShipMethodIDString, con)
        ShipMethodIDCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        ShipMethodIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ReceiverDateString As String = "SELECT ReceivingDate FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim ReceiverDateCommand As New SqlCommand(ReceiverDateString, con)
        ReceiverDateCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        ReceiverDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PONumberString As String = "SELECT PONumber FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim PONumberCommand As New SqlCommand(PONumberString, con)
        PONumberCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        PONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FreightChargeString As String = "SELECT FreightCharge FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim FreightChargeCommand As New SqlCommand(FreightChargeString, con)
        FreightChargeCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        FreightChargeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTaxString As String = "SELECT SalesTax FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim SalesTaxCommand As New SqlCommand(SalesTaxString, con)
        SalesTaxCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        SalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ProductTotalString As String = "SELECT ProductTotal FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
        ProductTotalCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ReceiverTotalString As String = "SELECT POTotal FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim ReceiverTotalCommand As New SqlCommand(ReceiverTotalString, con)
        ReceiverTotalCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        ReceiverTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ReceiverStatusString As String = "SELECT Status FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim ReceiverStatusCommand As New SqlCommand(ReceiverStatusString, con)
        ReceiverStatusCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        ReceiverStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorID = CStr(VendorIDCommand.ExecuteScalar)
        Catch ex As Exception
            VendorID = ""
        End Try
        Try
            SalesTax = CDbl(SalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SalesTax = 0
        End Try
        Try
            PODate = CStr(PODateCommand.ExecuteScalar)
        Catch ex As Exception
            PODate = ""
        End Try
        Try
            HeaderComment = CStr(HeaderCommentCommand.ExecuteScalar)
        Catch ex As Exception
            HeaderComment = ""
        End Try
        Try
            ShipMethodID = CStr(ShipMethodIDCommand.ExecuteScalar)
        Catch ex As Exception
            ShipMethodID = ""
        End Try
        Try
            ReceiverDate = CStr(ReceiverDateCommand.ExecuteScalar)
        Catch ex As Exception
            ReceiverDate = ""
        End Try
        Try
            PONumber = CInt(PONumberCommand.ExecuteScalar)
        Catch ex As Exception
            PONumber = 0
        End Try
        Try
            FreightCharge = CDbl(FreightChargeCommand.ExecuteScalar)
        Catch ex As Exception
            FreightCharge = 0
        End Try
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            ReceiverTotal = CDbl(ReceiverTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ReceiverTotal = 0
        End Try
        Try
            ReceiverStatus = CStr(ReceiverStatusCommand.ExecuteScalar)
        Catch ex As Exception
            ReceiverStatus = "RECEIVED"
        End Try
        con.Close()

        'Load extracted PO data into text boxes
        txtVendorID.Text = VendorID
        dtpPODate.Text = PODate
        txtComment.Text = HeaderComment
        cboShipVia.Text = ShipMethodID
        dtpReceivingDate.Text = ReceiverDate
        txtSalesTax.Text = SalesTax
        txtFreightCharge.Text = FreightCharge
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtReceiverTotal.Text = FormatCurrency(ReceiverTotal, 2)
        dtpReceivingDate.Text = ReceiverDate
        txtStatus.Text = ReceiverStatus
        txtPONumber.Text = PONumber
    End Sub

    Public Sub LoadReceiverTotals()
        Dim ProductTotalString As String = "SELECT ProductTotal FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
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

        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)

        FreightCharge = Val(txtFreightCharge.Text)
        SalesTax = Val(txtSalesTax.Text)
        ReceiverTotal = ProductTotal + SalesTax + FreightCharge
        txtReceiverTotal.Text = FormatCurrency(ReceiverTotal, 2)
    End Sub

    Private Sub cboReceivingTicketNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReceivingTicketNumber.SelectedIndexChanged
        ClearLines()
        LoadReceiverData()
        ShowReceiverLines()
    End Sub

    Public Sub LoadLineDetails()
        Dim PartNumberString As String = "SELECT PartNumber FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID"
        Dim PartNumberCommand As New SqlCommand(PartNumberString, con)
        PartNumberCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        PartNumberCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = Val(cboReceiverLine.Text)
        PartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PartDescriptionString As String = "SELECT PartDescription FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID"
        Dim PartDescriptionCommand As New SqlCommand(PartDescriptionString, con)
        PartDescriptionCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        PartDescriptionCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = Val(cboReceiverLine.Text)
        PartDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim QuantityReceivedString As String = "SELECT QuantityReceived FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID"
        Dim QuantityReceivedCommand As New SqlCommand(QuantityReceivedString, con)
        QuantityReceivedCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        QuantityReceivedCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = Val(cboReceiverLine.Text)
        QuantityReceivedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SelectForInvoiceString As String = "SELECT SelectForInvoice FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID"
        Dim SelectForInvoiceCommand As New SqlCommand(SelectForInvoiceString, con)
        SelectForInvoiceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        SelectForInvoiceCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = Val(cboReceiverLine.Text)
        SelectForInvoiceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber = CStr(PartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            PartNumber = ""
        End Try
        Try
            PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            PartDescription = ""
        End Try
        Try
            QuantityReceived = CDbl(QuantityReceivedCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityReceived = 0
        End Try
        Try
            SelectForInvoice = CStr(SelectForInvoiceCommand.ExecuteScalar)
        Catch ex As Exception
            SelectForInvoice = "OPEN"
        End Try
        con.Close()

        txtPartNumber.Text = PartNumber
        txtDescription.Text = PartDescription
        txtQuantityReceived.Text = QuantityReceived
        txtAPLineStatus.Text = SelectForInvoice

        Dim POQuantityString As String = "SELECT OrderQuantity FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim POQuantityCommand As New SqlCommand(POQuantityString, con)
        POQuantityCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(txtPONumber.Text)
        POQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
        POQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim QuantityVouchedString As String = "SELECT SUM(Quantity) FROM ReceiptOfInvoiceVoucherLines WHERE ReceiverNumber = @ReceiverNumber AND ReceiverLine = @ReceiverLine AND PartNumber = @PartNumber"
        Dim QuantityVouchedCommand As New SqlCommand(QuantityVouchedString, con)
        QuantityVouchedCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        QuantityVouchedCommand.Parameters.Add("@ReceiverLine", SqlDbType.VarChar).Value = Val(cboReceiverLine.Text)
        QuantityVouchedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

        Dim QuantityReturnedString As String = "SELECT SUM(Quantity) FROM VendorReturnLineQuery WHERE ReceiverNumber = @ReceiverNumber AND ReceiverLineNumber = @ReceiverLineNumber AND DivisionID = @DivisionID"
        Dim QuantityReturnedCommand As New SqlCommand(QuantityReturnedString, con)
        QuantityReturnedCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
        QuantityReturnedCommand.Parameters.Add("@ReceiverLineNumber", SqlDbType.VarChar).Value = Val(cboReceiverLine.Text)
        QuantityReturnedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantityOnPO = CDbl(POQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityOnPO = 0
        End Try
        Try
            QuantityVouched = CDbl(QuantityVouchedCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityVouched = 0
        End Try
        Try
            QuantityReturned = CDbl(QuantityReturnedCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityReturned = 0
        End Try
        con.Close()

        txtQuantityOnPO.Text = QuantityOnPO
        txtQuantityVouched.Text = QuantityVouched
        txtQuantityReturned.Text = QuantityReturned
    End Sub

    Private Sub cboReceiverLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReceiverLine.SelectedIndexChanged
        LoadLineDetails()
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

    Private Sub txtVendorID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVendorID.TextChanged
        LoadVendorName()
    End Sub

    Public Sub ClearData()
        cboReceiverLine.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboReceivingTicketNumber.SelectedIndex = -1

        txtAPLineStatus.Clear()
        txtComment.Clear()
        txtDescription.Clear()
        txtFreightCharge.Clear()
        txtPartNumber.Clear()
        txtPONumber.Clear()
        txtProductTotal.Clear()
        txtQuantityOnPO.Clear()
        txtQuantityReceived.Clear()
        txtQuantityVouched.Clear()
        txtReceiverTotal.Clear()
        txtSalesTax.Clear()
        txtStatus.Clear()
        txtVendorID.Clear()
        txtVendorName.Clear()
        txtQuantityReturned.Clear()

        dtpPODate.Text = ""
        dtpReceivingDate.Text = ""

        cboReceivingTicketNumber.Focus()
    End Sub

    Public Sub ClearLines()
        txtQuantityOnPO.Clear()
        txtQuantityReceived.Clear()
        txtQuantityVouched.Clear()
        txtQuantityReturned.Clear()
        txtPartNumber.Clear()
        txtDescription.Clear()
        txtAPLineStatus.Clear()
        cboReceiverLine.SelectedIndex = -1
    End Sub

    Public Sub ClearVariables()
        PartNumber = ""
        PartDescription = ""
        SelectForInvoice = ""
        VendorID = ""
        ReceiverDate = ""
        PODate = ""
        HeaderComment = ""
        ReceiverStatus = ""
        ShipMethodID = ""
        VendorName = ""
        FreightCharge = 0
        ProductTotal = 0
        SalesTax = 0
        ReceiverTotal = 0
        PONumber = 0
        ReceivingHeaderKey = 0
        QuantityReceived = 0
        QuantityOnPO = 0
        QuantityVouched = 0
        QuantityReturned = 0
    End Sub

    Private Sub txtSalesTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTax.TextChanged
        SalesTax = Val(txtSalesTax.Text)
        ReceiverTotal = ProductTotal + SalesTax + FreightCharge
        txtReceiverTotal.Text = FormatCurrency(ReceiverTotal, 2)
    End Sub

    Private Sub txtFreightCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightCharge.TextChanged
        FreightCharge = Val(txtFreightCharge.Text)
        ReceiverTotal = ProductTotal + SalesTax + FreightCharge
        txtReceiverTotal.Text = FormatCurrency(ReceiverTotal, 2)
    End Sub

    Private Sub ReOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReOpenToolStripMenuItem.Click
        If cboReceivingTicketNumber.Text = "" Then
            MsgBox("You must have a valid Receiver selected.", MsgBoxStyle.OkOnly)
        Else
            'Get Lines that should be open (unvouched)
            ShowRPCLines()

            Dim ReceivingLineKey As Integer = 0
            Dim QuantityOpen As Double = 0

            For Each row As DataGridViewRow In dgvReceiverPurchaseClearing.Rows
                Try
                    ReceivingLineKey = row.Cells("RLColumn").Value
                Catch ex As Exception
                    ReceivingLineKey = 0
                End Try
                Try
                    QuantityOpen = row.Cells("QOColumn").Value
                Catch ex As Exception
                    QuantityOpen = 0
                End Try

                If QuantityOpen = 0 Then
                    'skip Line
                Else
                    'Open Receiver Line
                    cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                        .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineKey
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
      
                QuantityOpen = 0
                ReceivingLineKey = 0
            Next
            '***********************************************************************************************************
            'Open Receiver Header
            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '***********************************************************************************************************
            txtStatus.Text = "RECEIVED"

            ShowReceiverLines()

            MsgBox("This receiver has been re-opened.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdOpenLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenLine.Click
        If cboReceivingTicketNumber.Text = "" And cboReceiverLine.Text <> "" Then
            MsgBox("You must have a valid Receiver and Line Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Open Receiver Line
            cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = Val(cboReceiverLine.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Open Receiver Header
            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtStatus.Text = "RECEIVED"

            ShowReceiverLines()
            MsgBox("Line has been re-opened for Invoicing.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdCloseLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseLine.Click
        If cboReceivingTicketNumber.Text = "" And cboReceiverLine.Text <> "" Then
            MsgBox("You must have a valid Receiver and Line Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Close Receiver Line
            cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = Val(cboReceiverLine.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowReceiverLines()
            MsgBox("Line has been closed.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdCloseReceiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseReceiver.Click
        If cboReceivingTicketNumber.Text = "" Then
            MsgBox("You must have a valid Receiver and Line Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Close All Receiver Lines
            cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = Val(cboReceiverLine.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Close Receiver Header
            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadReceiverData()
            ShowReceiverLines()
            MsgBox("Receiver has been closed.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub CloseReceiverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseReceiverToolStripMenuItem.Click
        cmdCloseReceiver_Click(sender, e)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboReceivingTicketNumber.Text = "" Then
            MsgBox("You must have a valid Receiver and Line Number selected.", MsgBoxStyle.OkOnly)
        Else
            LoadReceiverTotals()

            'Save Receiver Header Data
            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET HeaderComment = @HeaderComment, ShipMethodID = @ShipMethodID, FreightCharge = @FreightCharge, SalesTax = @SalesTax, POTotal = @POTotal WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@HeaderComment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@ShipMethodID", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = FreightCharge
                .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                .Add("@POTotal", SqlDbType.VarChar).Value = ReceiverTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadReceiverData()
            ShowReceiverLines()
            MsgBox("Receiver has been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub SaveChangesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveChangesToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If txtStatus.Text = "OPEN" Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Receiver?", "DELETE RECEIVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete Receiver Header Data
                cmd = New SqlCommand("DELETE FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboReceivingTicketNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ClearVariables()
                ClearData()
                LoadReceiverNumber()
            ElseIf button = DialogResult.No Then
                'Continue
                cmdDelete.Focus()
            End If
        Else
            MsgBox("You cannot delete a receiver that has been posted.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub DeleteReceiverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteReceiverToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalReceiverNumber = Val(cboReceivingTicketNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintReceiver As New PrintReceiver
            Dim Result = NewPrintReceiver.ShowDialog()
        End Using
    End Sub

    Private Sub PrintReceiverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReceiverToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalReceiverNumber = 0
        ClearVariables()
        ClearData()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalReceiverNumber = 0
        ClearVariables()
        ClearData()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        GlobalReceiverNumber = 0
        ClearVariables()
        ClearData()
        ShowReceiverLines()
    End Sub

    Private Sub ScanPackingSkipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanPackingSkipToolStripMenuItem.Click
        Dim PackingSlipFilename As String = ""
        Dim PackingSlipFilenameAndPath As String = ""
        Dim strPackingSlipNumber As String = ""
        Dim PackingSlipNumber As Integer = 0

        'Scanning Program
        Dim My_Process As New Process()

        'Verify that they have a PackingSlip selected
        If cboReceivingTicketNumber.Text = "" Then
            MsgBox("You must select a valid PackingSlip.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            PackingSlipNumber = cboReceivingTicketNumber.Text
            strPackingSlipNumber = CStr(PackingSlipNumber)
        End If

        PackingSlipFilename = strPackingSlipNumber + ".pdf"
        PackingSlipFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + PackingSlipFilename

        If File.Exists(PackingSlipFilenameAndPath) Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned Pick Ticket?", "OVERWRITE EXISTING PICK TICKET?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete existing PackingSlip before upload
                File.Delete(PackingSlipFilenameAndPath)

                Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                strPackingSlipNumber = CStr(cboReceivingTicketNumber.Text)
                PackingSlipFilename = strPackingSlipNumber + ".pdf"
                PackingSlipFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + PackingSlipFilename

                Try
                    My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    My_Process.StartInfo.CreateNoWindow = True
                    My_Process.Start(ApplicationFileAndPath, "-o " & PackingSlipFilenameAndPath)
                    My_Process.Close()

                    MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
                Catch ex As System.Exception
                    '    'Log error on update failure
                    Dim TempPackingSlipNumber As Integer = 0
                    Dim strPackingSlipNumber1 As String = ""
                    TempPackingSlipNumber = Val(cboReceivingTicketNumber.Text)
                    strPackingSlipNumber1 = CStr(TempPackingSlipNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ApplicationFileAndPath & "" & PackingSlipFilenameAndPath
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Edit Receiver --- Scan"
                    ErrorReferenceNumber = "Shipment # " + strPackingSlipNumber1
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MsgBox("Scan failed", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"

            strPackingSlipNumber = CStr(cboReceivingTicketNumber.Text)
            PackingSlipFilename = strPackingSlipNumber + ".pdf"
            PackingSlipFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + PackingSlipFilename

            Try
                My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                My_Process.StartInfo.CreateNoWindow = True
                My_Process.Start(ApplicationFileAndPath, "-o " & PackingSlipFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()

                MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                '    'Log error on update failure
                Dim TempPackingSlipNumber As Integer = 0
                Dim strPackingSlipNumber1 As String = ""
                TempPackingSlipNumber = Val(cboReceivingTicketNumber.Text)
                strPackingSlipNumber1 = CStr(TempPackingSlipNumber)

                ErrorDate = TodaysDate
                ErrorComment = ApplicationFileAndPath & "" & PackingSlipFilenameAndPath
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Edit Receiver --- Scan"
                ErrorReferenceNumber = "Shipment # " + strPackingSlipNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan failed", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub ViewPackingSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewPackingSlipToolStripMenuItem.Click
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
End Class