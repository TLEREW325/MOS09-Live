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
Public Class ViewReceivingHeaders
    Inherits System.Windows.Forms.Form

    Dim VendorName, VendorFilter, DateFilter, StatusFilter, POFilter, ReceiverFilter As String
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

    Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\TransferData\UploadedPackingSlips")

    Private Sub ViewReceivingHeaders_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub ViewReceivingHeaders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()

        If EmployeeLoginName = "LEREW" Then
            UpdateWUploadedDocsToolStripMenuItem.Enabled = True
        Else
            UpdateWUploadedDocsToolStripMenuItem.Enabled = False
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

    Public Sub ClearData()
        cboPONumber.Text = ""
        cboVendorID.Text = ""
        cboStatus.Text = ""
        cboReceiverNumber.Text = ""

        cboPONumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboReceiverNumber.SelectedIndex = -1

        txtVendorName.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboVendorID.Focus()
    End Sub

    Public Sub ClearVariables()
        VendorName = ""
        VendorFilter = ""
        DateFilter = ""
        StatusFilter = ""
        POFilter = ""
        ReceiverFilter = ""
        PONumber = 0
        ReceiverNumber = 0
        strPONumber = ""
        strReceiverNumber = ""
        GlobalReceiverNumber = 0
    End Sub

    Public Sub ShowDataByFilter()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorCode = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboStatus.Text <> "" Then
            StatusFilter = " AND Status = '" + cboStatus.Text + "'"
        Else
            StatusFilter = ""
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
            ReceiverFilter = " AND ReceivingHeaderKey = '" + strReceiverNumber + "'"
        Else
            ReceiverFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ReceivingHeaderTable WHERE DivisionID <> @DivisionID" + POFilter + ReceiverFilter + StatusFilter + VendorFilter + DateFilter + " ORDER BY DivisionID, ReceivingHeaderKey", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceivingHeaderTable")
            dgvReceivingHeaders.DataSource = ds.Tables("ReceivingHeaderTable")
            con.Close()
            Me.dgvReceivingHeaders.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID" + POFilter + ReceiverFilter + StatusFilter + VendorFilter + DateFilter + " ORDER BY ReceivingHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceivingHeaderTable")
            dgvReceivingHeaders.DataSource = ds.Tables("ReceivingHeaderTable")
            con.Close()
            Me.dgvReceivingHeaders.Columns("DivisionIDColumn").Visible = False
        End If

        LoadFormatting()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvReceivingHeaders.DataSource = Nothing
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass order by VendorCode", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboVendorID.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadFormatting()
        Dim ReceiverFileStatus As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvReceivingHeaders.Rows
            Try
                ReceiverFileStatus = row.Cells("ScannedFilenameColumn").Value
            Catch ex As System.Exception
                ReceiverFileStatus = ""
            End Try

            If ReceiverFileStatus = "" Then
                Me.dgvReceivingHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvReceivingHeaders.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                Me.dgvReceivingHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvReceivingHeaders.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadPONumber()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "PurchaseOrderHeaderTable")
        cboPONumber.DataSource = ds2.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadReceiverNumber()
        cmd = New SqlCommand("SELECT ReceivingHeaderKey FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID ORDER BY ReceivingHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ReceivingHeaderTable")
        cboReceiverNumber.DataSource = ds3.Tables("ReceivingHeaderTable")
        con.Close()
        cboReceiverNumber.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadVendor()
        LoadPONumber()
        LoadReceiverNumber()
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadVendorName()
        'Check to see if line is open or closed
        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
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

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub dgvReceivingHeaders_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceivingHeaders.CellValueChanged
        Dim RowReceiverNumber As Integer
        Dim RowHeaderComment, RowShipMethod, RowReceivingAgent As String

        If Me.dgvReceivingHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvReceivingHeaders.CurrentCell.RowIndex

            Try
                RowReceiverNumber = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value
            Catch ex As Exception
                RowReceiverNumber = 0
            End Try
            Try
                RowHeaderComment = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("HeaderCommentColumn").Value
            Catch ex As Exception
                RowHeaderComment = 0
            End Try
            Try
                RowShipMethod = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("ShipMethodIDColumn").Value
            Catch ex As Exception
                RowShipMethod = 0
            End Try
            Try
                RowReceivingAgent = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("ReceivingAgentColumn").Value
            Catch ex As Exception
                RowReceivingAgent = 0
            End Try

            'UPDATE Receiver Header
            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET HeaderComment = @ExtendedCOS, ShipMethodID = @ShipMethodID, ReceivingAgent = @ReceivingAgent WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = RowReceiverNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@HeaderComment", SqlDbType.VarChar).Value = RowHeaderComment
                .Add("@ShipMethodID", SqlDbType.VarChar).Value = RowShipMethod
                .Add("@ReceivingAgent", SqlDbType.VarChar).Value = RowReceivingAgent
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            'Skip Update
        End If
    End Sub

    Private Sub cmdReceivingForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceivingForm.Click
        Dim RowReceiverNumber As Integer = 0
        Dim RowDivisionID As String = ""

        If Me.dgvReceivingHeaders.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvReceivingHeaders.CurrentCell.RowIndex

            RowReceiverNumber = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value
            RowDivisionID = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalReceiverNumber = RowReceiverNumber
            GlobalDivisionCode = RowDivisionID
        End If

        Dim NewReceivingForm As New Receiving
        NewReceivingForm.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintReceivingHeadersFiltered As New PrintReceivingHeadersFiltered
            Dim Result = NewPrintReceivingHeadersFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintReceivingHeadersFiltered As New PrintReceivingHeadersFiltered
            Dim Result = NewPrintReceivingHeadersFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdReprintReceiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintReceiver.Click
        Dim RowReceiverNumber As Integer = 0
        If Me.dgvReceivingHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvReceivingHeaders.CurrentCell.RowIndex

            RowReceiverNumber = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value

            GlobalReceiverNumber = RowReceiverNumber
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintReceiver As New PrintReceiver
                Dim Result = NewPrintReceiver.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ReprintSelectedReceiverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprintSelectedReceiverToolStripMenuItem.Click
        Dim RowReceiverNumber As Integer = 0
        If Me.dgvReceivingHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvReceivingHeaders.CurrentCell.RowIndex

            RowReceiverNumber = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value

            GlobalReceiverNumber = RowReceiverNumber
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintReceiver As New PrintReceiver
                Dim Result = NewPrintReceiver.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvReceivingHeaders_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceivingHeaders.CellDoubleClick
        Dim RowReceiverNumber As Integer = 0
        If Me.dgvReceivingHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvReceivingHeaders.CurrentCell.RowIndex

            RowReceiverNumber = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value

            GlobalReceiverNumber = RowReceiverNumber
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintReceiver As New PrintReceiver
                Dim Result = NewPrintReceiver.ShowDialog()
            End Using
        End If
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

    Private Sub cmdReceiverEditMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceiverEditMode.Click
        Dim RowReceiverNumber As Integer = 0
        Dim RowDivisionID As String = ""

        If Me.dgvReceivingHeaders.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvReceivingHeaders.CurrentCell.RowIndex

            RowReceiverNumber = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value
            RowDivisionID = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalReceiverNumber = RowReceiverNumber
            GlobalDivisionCode = RowDivisionID
        End If
    
        Dim NewReceiverEditMode As New ReceiverEditMode
        NewReceiverEditMode.Show()
    End Sub

    Private Sub CheckPackingSlipUpload()
        If dgvReceivingHeaders.SelectedCells.Count > 0 AndAlso dgvReceivingHeaders.SelectedCells(0).RowIndex >= 0 Then
            Dim fls As IO.FileInfo() = dir.GetFiles(dgvReceivingHeaders.Rows(dgvReceivingHeaders.SelectedCells(0).RowIndex).Cells("ReceivingHeaderKeyColumn").Value.ToString + ".pdf")
            If fls.Length > 0 Then
                cmdViewPackingSlip.Enabled = True
                UploadPackingSlipToolStripMenuItem.Enabled = False
                ReUploadPackingSlipToolStripMenuItem.Enabled = True
            Else
                cmdViewPackingSlip.Enabled = False
                UploadPackingSlipToolStripMenuItem.Enabled = True
                ReUploadPackingSlipToolStripMenuItem.Enabled = False
            End If
        Else
            cmdViewPackingSlip.Enabled = False
            UploadPackingSlipToolStripMenuItem.Enabled = True
            ReUploadPackingSlipToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub cmdViewPackingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPackingSlip.Click
        Dim RowReceiverNumber As Integer = 0
        Dim ReceiverFilename As String = ""
        Dim ReceiverFilenameAndPath As String = ""

        If Me.dgvReceivingHeaders.RowCount > 0 Then
            Dim UploadedReceiverNumber As String = ""
            Dim RowIndex As Integer = Me.dgvReceivingHeaders.CurrentCell.RowIndex

            RowReceiverNumber = Me.dgvReceivingHeaders.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value

            UploadedReceiverNumber = CStr(RowReceiverNumber)
            ReceiverFilename = UploadedReceiverNumber + ".pdf"
            ReceiverFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + ReceiverFilename

            If File.Exists(ReceiverFilenameAndPath) Then
                System.Diagnostics.Process.Start(ReceiverFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox("You must have a valid Receiver number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Private Sub UploadPackingSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadPackingSlipToolStripMenuItem.Click
        Dim psUpload As New PackingSlipScannerUploadAPI(New Windows.Forms.Button(), New Windows.Forms.Control(dgvReceivingHeaders.Rows(dgvReceivingHeaders.SelectedCells(0).RowIndex).Cells("ReceivingHeaderKeyColumn").Value), New Windows.Forms.ToolStripMenuItem(), Me, AppendUploadedPackingSlipToolStripMenuItem)
        psUpload.UploadPackingSlip()
        CheckPackingSlipUpload()
        Me.BringToFront()
    End Sub

    Private Sub ReUploadPackingSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReUploadPackingSlipToolStripMenuItem.Click
        Dim psUpload As New PackingSlipScannerUploadAPI(New Windows.Forms.Button(), New Windows.Forms.Control(dgvReceivingHeaders.Rows(dgvReceivingHeaders.SelectedCells(0).RowIndex).Cells("ReceivingHeaderKeyColumn").Value), New Windows.Forms.ToolStripMenuItem(), Me, AppendUploadedPackingSlipToolStripMenuItem)
        psUpload.ReUploadPackingSlip()
        CheckPackingSlipUpload()
        Me.BringToFront()
    End Sub

    Private Sub dgvReceivingHeaders_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvReceivingHeaders.SelectionChanged
        CheckPackingSlipUpload()
    End Sub

    Private Sub UpdateWUploadedDocsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateWUploadedDocsToolStripMenuItem.Click
        'For every row in datagrid, see if there is an uploaded doc
        'If there is, write doc name to header table

        Dim RowReceiverNumber As Integer = 0
        Dim RowFileName As String = ""
        Dim strRowReceiverNumber As String = ""
        Dim RowFileNameAndPath As String = ""

        If Me.dgvReceivingHeaders.RowCount > 0 Then
            For Each LineRow As DataGridViewRow In dgvReceivingHeaders.Rows
                RowReceiverNumber = LineRow.Cells("ReceivingHeaderKeyColumn").Value

                strRowReceiverNumber = CStr(RowReceiverNumber)
                RowFileName = strRowReceiverNumber + ".pdf"
                RowFileNameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + RowFileName

                If File.Exists(RowFileNameAndPath) Then
                    'Write filename to Header Table
                    'UPDATE Receiver Header
                    cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET ScannedFilename = @ScannedFilename WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = RowReceiverNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ScannedFilename", SqlDbType.VarChar).Value = RowFileName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET ScannedFilename = @ScannedFilename WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = RowReceiverNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ScannedFilename", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next

            MsgBox("Database updated.", MsgBoxStyle.OkOnly)
        End If
    End Sub
End Class