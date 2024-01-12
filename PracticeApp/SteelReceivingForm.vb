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
Public Class SteelReceivingForm
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet

    ''check to see if the form is loaded
    Dim isLoaded As Boolean = False
    Dim needsSaved As Boolean = False
    Dim lastBatch As String = ""
    Dim controlKey As Boolean = False

    Private Const BOLDir As String = "\\TFP-SQL\\TransferData\Charter Steel BOLs"

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

    Public Sub New()
        InitializeComponent()

        LoadInitialData()
    End Sub

    Public Sub New(ByVal SteelReceiverNumber As String)
        InitializeComponent()

        LoadInitialData()

        cboSteelRecTicket.Text = SteelReceiverNumber
    End Sub

    Private Sub LoadInitialData()
        usefulFunctions.LoadSecurity(Me)
        cboDivisionID.Text = EmployeeCompanyCode
        'Clear all text boxes on load
        LoadSteelPONumber()
        LoadSteelReceiptNumber()
        LoadVendor()
        isLoaded = True
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvSteelReceiving.CellValueChanged
        If canChangeValue() Then
            LockBatch()
            Dim LineExtendedAmount, LineUnitCost As Double
            Dim LineReceiveQuantity, LineNumber As Integer
            Dim coilID As String = ""
            Dim currentRow As Integer = dgvSteelReceiving.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvSteelReceiving.CurrentCell.ColumnIndex

            cmd = New SqlCommand("SELECT SteelCostPerPound FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @HeaderKey AND SteelReceivingLineKey = @LineKey;", con)
            cmd.Parameters.Add("@HeaderKey", SqlDbType.VarChar).Value = dgvSteelReceiving.Rows(currentRow).Cells("SteelReceivingHeaderKey").Value
            cmd.Parameters.Add("@LineKey", SqlDbType.VarChar).Value = dgvSteelReceiving.Rows(currentRow).Cells("SteelReceivingLineKey").Value

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LineUnitCost = cmd.ExecuteScalar()
            Catch ex As System.Exception
                MessageBox.Show("There was a problem updating the value, try again", "Error updating value", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ShowLineItems()
                dgvSteelReceiving.CurrentCell = dgvSteelReceiving.Rows(currentRow).Cells(currentColumn)
                Exit Sub
            End Try
            con.Close()

            ''UPDATE Line in the Table when a change in the datagrid is made
            If IsDBNull(dgvSteelReceiving.Rows(currentRow).Cells("ReceiveWeight").Value) Then
                LineReceiveQuantity = 0
            Else
                LineReceiveQuantity = dgvSteelReceiving.Rows(currentRow).Cells("ReceiveWeight").Value
            End If

            LineNumber = dgvSteelReceiving.Rows(currentRow).Cells("SteelReceivingLineKey").Value

            LineExtendedAmount = Math.Round(LineUnitCost * LineReceiveQuantity, 2, MidpointRounding.AwayFromZero)

            'UPDATE Steel Coil Lines on grid changes
            cmd = New SqlCommand("UPDATE SteelReceivingCoilLines SET CoilWeight = @CoilWeight, SteelExtendedAmount = @SteelExtendedAmount WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey;", con)
            'UPDATE Steel Receiving Lines on grid changes
            cmd.CommandText += " UPDATE SteelReceivingLineTable SET ReceiveWeight = (SELECT SUM(CoilWeight) FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey), SteelExtendedCost = (SELECT SUM(SteelExtendedAmount) FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey) WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey;"
            'UPDATE Steel Receiving Header on grid changes
            cmd.CommandText += " DECLARE @SteelCost as float = (SELECT SUM(SteelExtendedCost) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey);UPDATE SteelReceivingHeaderTable SET SteelTotalWeight = (SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey), SteelTotal = @SteelCost, InvoiceTotal = ROUND(@SteelCost + @SteelFreightCharges + @SteelOtherCharges, 2), SteelFreightCharges = @SteelFreightCharges, SteelOtherCharges = @SteelOtherCharges WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey;"
            With cmd.Parameters
                .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
                .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = LineNumber
                .Add("@CoilWeight", SqlDbType.VarChar).Value = LineReceiveQuantity
                .Add("@SteelExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                .Add("@SteelFreightCharges", SqlDbType.Float).Value = Val(txtFreightTotal.Text)
                .Add("@SteelOtherCharges", SqlDbType.Float).Value = Val(txtOtherTotal.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowLineItems()
            dgvSteelReceiving.CurrentCell = dgvSteelReceiving.Rows(currentRow).Cells(currentColumn)
            UpdateTotals()
        End If
    End Sub

    Private Function canChangeValue() As Boolean
        If isLoaded = False Then
            Return False
        End If
        If dgvSteelReceiving.Rows.Count < 1 Then
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        Return True
    End Function

    Public Sub ShowLineItems()
        cmd = New SqlCommand("SELECT RawMaterialsTable.Carbon, RawMaterialsTable.SteelSize, SteelReceivingHeaderKey, SteelReceivingLineKey, ReceiveWeight, SteelExtendedCost, LineComment FROM SteelReceivingLineTable Left outer join RawMaterialsTable on SteelReceivingLineTable.RMID = RawMaterialsTable.RMID WHERE SteelReceivingLineTable.SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Or cboDivisionID.Text.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SteelReceivingLineTable")
        con.Close()

        dgvSteelReceiving.DataSource = ds.Tables("SteelReceivingLineTable")

        dgvSteelReceiving.Columns("SteelReceivingHeaderKey").Visible = False
        dgvSteelReceiving.Columns("SteelReceivingLineKey").Visible = False

        dgvSteelReceiving.Columns("Carbon").ReadOnly = True
        dgvSteelReceiving.Columns("SteelSize").ReadOnly = True
        dgvSteelReceiving.Columns("SteelExtendedCost").ReadOnly = True
        dgvSteelReceiving.Columns("LineComment").ReadOnly = True

        dgvSteelReceiving.Columns("SteelSize").HeaderText = "Steel Size"
        dgvSteelReceiving.Columns("ReceiveWeight").HeaderText = "Receive Weight"
        dgvSteelReceiving.Columns("SteelExtendedCost").HeaderText = "Extended Cost"
        dgvSteelReceiving.Columns("LineComment").HeaderText = "Purchase Order Line Comment"

        dgvSteelReceiving.Columns("SteelExtendedCost").DefaultCellStyle.Format = "N2"
    End Sub

    Public Sub LoadSteelReceiptNumber()
        If EmployeeCompanyCode.Equals("TST") Then
            cmd = New SqlCommand("SELECT SteelReceivingHeaderKey FROM SteelReceivingHeaderTable WHERE ReceivingStatus = 'OPEN' AND DivisionID = 'TST' ORDER BY SteelReceivingHeaderKey DESC;", con)
        Else
            cmd = New SqlCommand("SELECT SteelReceivingHeaderKey FROM SteelReceivingHeaderTable WHERE ReceivingStatus = 'OPEN' AND DivisionID <> 'TST' ORDER BY SteelReceivingHeaderKey DESC;", con)
        End If

        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "SteelReceivingHeaderTable")
        con.Close()

        cboSteelRecTicket.DisplayMember = "SteelReceivingHeaderKey"
        cboSteelRecTicket.DataSource = ds1.Tables("SteelReceivingHeaderTable")
        cboSteelRecTicket.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelPONumber()
        cmd = New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE Status = 'OPEN' AND DivisionID = @DivisionID;", con)
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "SteelPurchaseOrderHeader")
        con.Close()

        cboSteelPO.DisplayMember = "SteelPurchaseOrderKey"
        cboSteelPO.DataSource = ds2.Tables("SteelPurchaseOrderHeader")
        cboSteelPO.SelectedIndex = -1
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE VendorClass = @VendorClass AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Or cboDivisionID.Text.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "Vendor")
        con.Close()

        cboSteelVendor.DisplayMember = "VendorCode"
        cboSteelVendor.DataSource = ds3.Tables("Vendor")
        cboSteelVendor.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelReceiptData()
        Dim ReceivingDate As Date
        Dim SteelVendor, SteelBOLNumber, Comment, ReceivingStatus As String
        Dim SteelTotalWeight As Integer
        Dim SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal As Double

        cmd = New SqlCommand("SELECT ReceivingDate, SteelVendor, SteelBOLNumber, SteelTotalWeight, SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal, Comment, ReceivingStatus FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ReceivingDate")) Then
                ReceivingDate = dtpSteelReceivingDate.Value
            Else
                ReceivingDate = reader.Item("ReceivingDate").ToString()
            End If
            If IsDBNull(reader.Item("ReceivingDate")) Then
                SteelVendor = cboSteelVendor.Text
            Else
                SteelVendor = reader.Item("SteelVendor")
            End If
            If IsDBNull(reader.Item("SteelBOLNumber")) Then
                SteelBOLNumber = txtSteelBOL.Text
            Else
                SteelBOLNumber = reader.Item("SteelBOLNumber")
            End If
            If IsDBNull(reader.Item("SteelTotalWeight")) Then
                SteelTotalWeight = 0
            Else
                SteelTotalWeight = reader.Item("SteelTotalWeight")
            End If
            If IsDBNull(reader.Item("SteelFreightCharges")) Then
                SteelFreightCharges = 0
            Else
                SteelFreightCharges = reader.Item("SteelFreightCharges")
            End If
            If IsDBNull(reader.Item("SteelOtherCharges")) Then
                SteelOtherCharges = 0
            Else
                SteelOtherCharges = reader.Item("SteelOtherCharges")
            End If
            If IsDBNull(reader.Item("SteelTotal")) Then
                SteelTotal = 0
            Else
                SteelTotal = reader.Item("SteelTotal")
            End If
            If IsDBNull(reader.Item("InvoiceTotal")) Then
                InvoiceTotal = 0
            Else
                InvoiceTotal = reader.Item("InvoiceTotal")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = txtSteelComment.Text
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("ReceivingStatus")) Then
                ReceivingStatus = "OPEN"
            Else
                ReceivingStatus = reader.Item("ReceivingStatus")
            End If
        Else
            ReceivingDate = dtpSteelReceivingDate.Text
            SteelVendor = cboSteelVendor.Text
            SteelBOLNumber = txtSteelBOL.Text
            SteelTotalWeight = 0
            SteelFreightCharges = 0
            SteelOtherCharges = 0
            SteelTotal = 0
            InvoiceTotal = 0
            Comment = txtSteelComment.Text
            ReceivingStatus = "OPEN"
        End If
        reader.Close()
        con.Close()

        If ReceivingStatus = "RECEIVED" Or ReceivingStatus = "CLOSED" Then
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            cmdSaveAndPost.Enabled = False
            cmdSelectLines.Enabled = False
            SaveReceiptToolStripMenuItem.Enabled = False
            DeleteReceiptToolStripMenuItem.Enabled = False
            cboSteelPO.Enabled = False
            cboSteelVendor.Enabled = False
            txtSteelBOL.ReadOnly = True
            txtSteelComment.ReadOnly = True
            txtFreightTotal.ReadOnly = True
            txtOtherTotal.ReadOnly = True
        Else
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            cmdSaveAndPost.Enabled = True
            cmdSelectLines.Enabled = True
            SaveReceiptToolStripMenuItem.Enabled = True
            DeleteReceiptToolStripMenuItem.Enabled = True
            cboSteelPO.Enabled = True
            cboSteelVendor.Enabled = True
            txtSteelBOL.ReadOnly = False
            txtSteelComment.ReadOnly = False
            txtFreightTotal.ReadOnly = False
            txtOtherTotal.ReadOnly = False
        End If

        dtpSteelReceivingDate.Value = ReceivingDate
        cboSteelVendor.Text = SteelVendor
        txtSteelBOL.Text = SteelBOLNumber
        txtSteelComment.Text = Comment
        txtReceivingStatus.Text = ReceivingStatus
        lblSteelTotal.Text = FormatCurrency(SteelTotal, 2).ToString()
        txtFreightTotal.Text = SteelFreightCharges.ToString()
        txtOtherTotal.Text = SteelOtherCharges.ToString()
        lblInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2).ToString()
    End Sub

    Private Sub cboSteelVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelVendor.SelectedIndexChanged
        If isLoaded Then
            LoadVendorName()
            If needsSaved = False And cboSteelVendor.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Public Sub ClearVariables()
        GlobalSteelReceivingNumber = 0
        GlobalSteelPONumber = 0
        lastBatch = ""
    End Sub

    Public Sub ClearData()
        cboSteelPO.Text = ""
        cboSteelRecTicket.Text = ""
        cboSteelVendor.Text = ""

        cboSteelPO.Refresh()
        cboSteelRecTicket.Refresh()
        cboSteelVendor.Refresh()

        txtSteelComment.Clear()
        txtSteelBOL.Clear()
        txtVendorName.Clear()

        dtpSteelReceivingDate.Text = ""

        cboSteelRecTicket.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelRecTicket.Text) Then
            cboSteelRecTicket.Text = ""
        End If
        cboSteelVendor.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelVendor.Text) Then
            cboSteelVendor.Text = ""
        End If
        cboSteelPO.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelPO.Text) Then
            cboSteelPO.Text = ""
        End If
        lblSteelTotal.Text = ""
        txtFreightTotal.Clear()
        txtOtherTotal.Clear()
        lblInvoiceTotal.Text = ""
        cboSteelRecTicket.Focus()
    End Sub

    Public Sub LoadVendorFromPO()
        Dim SteelVendor As String

        cmd = New SqlCommand("SELECT SteelVendorID FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = Val(cboSteelPO.Text)
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelVendor = CStr(cmd.ExecuteScalar)
        Catch ex As System.Exception
            SteelVendor = ""
        End Try
        con.Close()

        cboSteelVendor.Text = SteelVendor
        cboSteelVendor.Enabled = False
        txtVendorName.Enabled = False

        If String.IsNullOrEmpty(SteelVendor) Then
            txtVendorName.Clear()
        End If
    End Sub

    Public Sub LoadVendorName()
        Dim VendorName As String = ""

        If cboSteelVendor.SelectedIndex <> -1 Then
            cmd = New SqlCommand("SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID;", con)
            cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboSteelVendor.Text
            If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Or cboDivisionID.Text.Equals("TST") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End If
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorName = CStr(cmd.ExecuteScalar)
            Catch ex As System.Exception
                VendorName = ""
            End Try
            con.Close()
        End If

        txtVendorName.Text = VendorName
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDeleteReceiveTicket() Then
            'Check if receiver exist is the GL Table
            Dim CountGLTransactions As Integer = 0

            Dim CountGLTransactionsString As String = "SELECT COUNT(GLTransactionKey) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
            Dim CountGLTransactionsCommand As New SqlCommand(CountGLTransactionsString, con)
            CountGLTransactionsCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
            CountGLTransactionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountGLTransactions = CInt(CountGLTransactionsCommand.ExecuteScalar)
            Catch ex As Exception
                CountGLTransactions = 0
            End Try
            con.Close()

            If CountGLTransactions <> 0 Then
                MsgBox("This steel receiver has already been posted.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '**********************************************************************************************
            'Create command to delete data from text boxes
            cmd = New SqlCommand("DELETE FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID;", con)
            cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
            If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '***************************************************************************************************
            'Write to Audit Trail Table
            Dim AuditComment As String = ""
            Dim AuditReceiverNumber As Integer = 0
            Dim strReceiverNumber As String = ""

            AuditReceiverNumber = Val(cboSteelRecTicket.Text)
            strReceiverNumber = CStr(AuditReceiverNumber)
            AuditComment = "Receiver #" + strReceiverNumber + " from vendor " + cboSteelVendor.Text + " was deleted on " + Today()

            Try
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "STEEL RECEIVING BY PO - DELETION"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(lblInvoiceTotal.Text)
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strReceiverNumber
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
            '**************************************************************************************************
            ClearVariables()
            ClearData()
            ShowLineItems()
            LoadSteelReceiptNumber()
            cboSteelRecTicket.Focus()

            MsgBox("This Receipt has been deleted", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canDeleteReceiveTicket() As Boolean
        If String.IsNullOrEmpty(cboSteelRecTicket.Text) Then
            MessageBox.Show("You must select a Receiving Number", "Select a Receiving Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelRecTicket.Focus()
            Return False
        End If
        If cboSteelRecTicket.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid Receiving Number", "Select a valid Receiving Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelRecTicket.SelectAll()
            cboSteelRecTicket.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If MessageBox.Show("Do you wish to delete this Receiving Ticket?", "DELETE RECEIPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cboSteelRecTicket_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelRecTicket.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(lastBatch) Then
                unlockBatch()
            End If
            LoadSteelReceiptData()
            ShowLineItems()
            isLoaded = False
            getAssociatedPONumber()
            isLoaded = True
            lastBatch = cboSteelRecTicket.Text
        End If
    End Sub

    Private Sub getAssociatedPONumber()
        cmd = New SqlCommand("SELECT PONumber FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @HeaderKey;", con)
        cmd.Parameters.Add("@HeaderKey", SqlDbType.VarChar).Value = cboSteelRecTicket.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            cboSteelPO.Text = reader.Item("PONumber")
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cmdGenerateReceivingTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateReceivingTicket.Click
        If Not String.IsNullOrEmpty(cboSteelRecTicket.Text) Then
            unlockBatch()
        End If
        If Not cboDivisionID.Text.Equals("TWD") And Not cboDivisionID.Text.Equals("TST") Then
            MessageBox.Show("Steel can only be received in under TWD division", "Unable to receive steel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Clear form on next number
        ClearVariables()
        ClearData()
        ShowLineItems()
        Dim NextTransactionNumber As Integer

        'Save number so it can not be used again
        Try
            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("BEGIN DECLARE @key as int = (SELECT isnull(MAX(SteelReceivingHeaderKey) + 1, 660001) FROM SteelReceivingHeaderTable); Insert Into SteelReceivingHeaderTable(SteelReceivingHeaderKey, ReceivingDate, SteelVendor, SteelBOLNumber, SteelTotalWeight, SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal, Comment, ReceivingStatus, DivisionID, Locked)Values(@key, @ReceivingDate, @SteelVendor, @SteelBOLNumber, @SteelTotalWeight, @SteelFreightCharges, @SteelOtherCharges, @SteelTotal, @InvoiceTotal, @Comment, @ReceivingStatus, @DivisionID, @Locked); SELECT @key; END", con)

            With cmd.Parameters
                .Add("@ReceivingDate", SqlDbType.VarChar).Value = dtpSteelReceivingDate.Text
                .Add("@SteelVendor", SqlDbType.VarChar).Value = cboSteelVendor.Text
                .Add("@SteelBOLNumber", SqlDbType.VarChar).Value = txtSteelBOL.Text
                .Add("@SteelTotalWeight", SqlDbType.VarChar).Value = 0
                .Add("@SteelFreightCharges", SqlDbType.VarChar).Value = 0
                .Add("@SteelOtherCharges", SqlDbType.VarChar).Value = 0
                .Add("@SteelTotal", SqlDbType.VarChar).Value = 0
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
                .Add("@Comment", SqlDbType.VarChar).Value = txtSteelComment.Text
                .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            NextTransactionNumber = cmd.ExecuteScalar()
            con.Close()
        Catch ex As System.Exception
            'Log error on update failure
            Dim TempReceiverNumber As Integer = 0
            Dim strReceiverNumber As String
            TempReceiverNumber = Val(cboSteelRecTicket.Text)
            strReceiverNumber = CStr(TempReceiverNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Steel Receipt By PO = Create New"
            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            MsgBox("There was an error creating this receiver. Try again.", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try

        isLoaded = False
        LoadSteelReceiptNumber()
        cboSteelRecTicket.Text = NextTransactionNumber.ToString()
        isLoaded = True
        cboSteelRecTicket.Focus()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            updateOrInsertSteelReceivingHeaderTable()
            ShowLineItems()
            LoadSteelReceiptData()
            MsgBox("Your changes have been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboSteelRecTicket.Text) Then
            MsgBox("You must have a valid Steel Receiving Ticket Number selected to enter data.", MsgBoxStyle.OkOnly)
            cboSteelRecTicket.Focus()
            Return False
        End If
        If cboSteelRecTicket.SelectedIndex = -1 Then
            MessageBox.Show("You muse enter a valid receipt number", "Enter a valid receipt number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelRecTicket.SelectAll()
            cboSteelRecTicket.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelPO.Text) = False Then
           If cboSteelPO.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid PO", "Enter a valid PO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSteelPO.SelectAll()
                cboSteelPO.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cmdSaveAndPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveAndPost.Click
        If canPost() Then
            'Prompt before saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to Save and Post this Steel Receipt? No further changes may be made after it is posted.", "POST STEEL RECEIPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Check if receiver exist is the GL Table
                Dim CountGLTransactions As Integer = 0

                Dim CountGLTransactionsString As String = "SELECT COUNT(GLTransactionKey) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
                Dim CountGLTransactionsCommand As New SqlCommand(CountGLTransactionsString, con)
                CountGLTransactionsCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
                CountGLTransactionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountGLTransactions = CInt(CountGLTransactionsCommand.ExecuteScalar)
                Catch ex As Exception
                    CountGLTransactions = 0
                End Try
                con.Close()

                If CountGLTransactions <> 0 Then
                    MsgBox("This steel receiver has already been posted.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                If Me.dgvSteelReceiving.RowCount = 0 Then
                    MsgBox("This steel receiver has no line items and cannot be posted.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                If needsSaved Then
                    updateOrInsertSteelReceivingHeaderTable()
                    needsSaved = False
                End If

                'assigns coil ID's if the user doesnt cancel out
                If Not assignCoilID() Then
                    isLoaded = False
                    ShowLineItems()
                    isLoaded = True
                    Exit Sub
                End If

                cmd = New SqlCommand("SELECT SteelReceivingLineKey, SteelReceivingLineTable.RMID, Carbon, SteelSize, ReceiveWeight, SteelExtendedCost FROM SteelReceivingLineTable LEFT OUTER JOIN RawMaterialsTable ON SteelReceivingLineTable.RMID = RawMaterialsTable.RMID WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey ORDER BY SteelReceivingLineKey", con)
                cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.Int).Value = cboSteelRecTicket.Text

                Dim tempds As New DataSet
                Dim adap As New SqlDataAdapter(cmd)

                If con.State = ConnectionState.Closed Then con.Open()
                adap.Fill(tempds, "SteelReceivingLineTable")
                ''adds the entries into the SteelTransactionTable
                addToSteelTrans(tempds)
                'adds the entries into the SteelCostingTable
                If Not EmployeeCompanyCode.Equals("TST") Then
                    addCostTiers(tempds)
                End If

                '**************************************************
                'Check line status to update Line Table
                '**************************************************
                checkAndUpdatePOStatus()

                'Update Steel Receiving Lines to show status as RECEIVED
                cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey;", con)
                cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ''update the receiverheader so that it is showing received
                updateOrInsertSteelReceivingHeaderTable("RECEIVED")

                '**********************************
                'Write to General Ledger
                '**********************************
                Dim paramCount As Integer = 0
                Dim keyCount As Integer = 0
                Dim batchCount As Integer = 0

                ''GL DEBIT to add to the RAW Material
                cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) VALUES", con)

                If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End If

                With cmd.Parameters
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Receiving"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpSteelReceivingDate.Value.ToShortDateString()
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Steel Vendor " & cboSteelVendor.Text
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                For i As Integer = 0 To tempds.Tables("SteelReceivingLineTable").Rows.Count - 1
                    If i = 0 Then
                        cmd.CommandText += "(@Key + " + keyCount.ToString + ", @GLAccountNumber" + paramCount.ToString + ", @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount" + paramCount.ToString + ", @GLTransactionCreditAmount" + paramCount.ToString + ",  @GLTransactionComment, @DivisionID, @GLJournalID" + paramCount.ToString + ", @batch + " + batchCount.ToString + ", @GLReferenceNumber, @GLReferenceLine" + paramCount.ToString + ", @GLTransactionStatus)"
                    Else
                        cmd.CommandText += ", (@Key + " + keyCount.ToString + ", @GLAccountNumber" + paramCount.ToString + ", @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount" + paramCount.ToString + ", @GLTransactionCreditAmount" + paramCount.ToString + ",  @GLTransactionComment, @DivisionID, @GLJournalID" + paramCount.ToString + ", @batch + " + batchCount.ToString + ", @GLReferenceNumber, @GLReferenceLine" + paramCount.ToString + ", @GLTransactionStatus)"
                    End If
                    keyCount += 1
                    With cmd.Parameters
                        .Add("@GLAccountNumber" + paramCount.ToString, SqlDbType.VarChar).Value = "12000"
                        .Add("@GLTransactionDebitAmount" + paramCount.ToString, SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelExtendedCost")
                        .Add("@GLTransactionCreditAmount" + paramCount.ToString, SqlDbType.VarChar).Value = 0
                        .Add("@GLJournalID" + paramCount.ToString, SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLReferenceLine" + paramCount.ToString, SqlDbType.VarChar).Value = i + 1
                    End With
                    paramCount += 1

                    cmd.CommandText += ", (@Key + " + keyCount.ToString + ", @GLAccountNumber" + paramCount.ToString + ", @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount" + paramCount.ToString + ", @GLTransactionCreditAmount" + paramCount.ToString + ",  @GLTransactionComment, @DivisionID, @GLJournalID" + paramCount.ToString + ", @batch + " + batchCount.ToString + ", @GLReferenceNumber, @GLReferenceLine" + paramCount.ToString + ", @GLTransactionStatus)"
                    keyCount += 1
                    With cmd.Parameters
                        .Add("@GLAccountNumber" + paramCount.ToString, SqlDbType.VarChar).Value = "20995"
                        .Add("@GLTransactionDebitAmount" + paramCount.ToString, SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount" + paramCount.ToString, SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelExtendedCost")
                        .Add("@GLJournalID" + paramCount.ToString, SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLReferenceLine" + paramCount.ToString, SqlDbType.VarChar).Value = i + 1
                    End With
                    paramCount += 1
                Next
                cmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As System.Exception
                    If ex.ToString().ToLower.Contains("primary key") Then
                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex1 As System.Exception
                            'Log error on update failure
                            Dim TempReceiverNumber As Integer = 0
                            Dim strReceiverNumber As String
                            TempReceiverNumber = Val(cboSteelRecTicket.Text)
                            strReceiverNumber = CStr(TempReceiverNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Steel Receipt By PO - Post to GL"
                            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String
                        TempReceiverNumber = Val(cboSteelRecTicket.Text)
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Steel Receipt By PO = Post to GL"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End If
                End Try

                con.Close()
                '**********************************
                'End of Ledger Entry
                '**********************************
                unlockBatch()
                'Reset Form
                isLoaded = False
                ClearData()
                LoadSteelReceiptNumber()
                ShowLineItems()
                isLoaded = True

                MsgBox("Receiver have been posted.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Function canPost() As Boolean
        If String.IsNullOrEmpty(cboSteelRecTicket.Text) Then
            MsgBox("You must have a valid Steel Receiving Ticket Number selected to enter data.", MsgBoxStyle.OkOnly)
            cboSteelRecTicket.Focus()
            Return False
        End If
        If cboSteelRecTicket.SelectedIndex = -1 Then
            MessageBox.Show("You muse enter a valid receipt number", "Enter a valid receipt number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelRecTicket.SelectAll()
            cboSteelRecTicket.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelVendor.Text) Then
            MessageBox.Show("You must enter a vendor", "Enter a vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelVendor.Focus()
            Return False
        End If
        If cboSteelVendor.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a vendor", "Enter a vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelVendor.SelectAll()
            cboSteelVendor.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelPO.Text) Then
            MessageBox.Show("You must select a PO number", "Select a PO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPO.Focus()
            Return False
        End If
        If cboSteelPO.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid PO", "Enter a valid PO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPO.SelectAll()
            cboSteelPO.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtSteelBOL.Text) Then
            MessageBox.Show("You must enter a bill of Lading or packing slip number", "Enter BOL", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSteelBOL.Focus()
            Return False
        End If

        cmd = New SqlCommand("SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE VendorClass = 'SteelVendor' AND VendorID = @SteelVendor AND DivisionID = @DivisionID AND PONumber = @SteelBOLNumber AND VoucherStatus <> 'OPEN'", con)
        cmd.Parameters.Add("@SteelBOLNumber", SqlDbType.VarChar).Value = txtSteelBOL.Text
        cmd.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = cboSteelVendor.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() <> 0 Then
            con.Close()
            MessageBox.Show("Bill of lading or packing slip number has already been used for this customer. Enter a unique BOL or packing slip number.", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSteelBOL.SelectAll()
            txtSteelBOL.Focus()
            Return False
        End If
        cmd = New SqlCommand("SELECT Count(SteelReceivingHeaderKey) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND ReceiveWeight = 0", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.Int).Value = Val(cboSteelRecTicket.Text)
        If cmd.ExecuteScalar() <> 0 Then
            con.Close()
            MessageBox.Show("You can't receive 0 of a line.", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        con.Close()
        If dgvSteelReceiving.Rows.Count < 1 Then
            MessageBox.Show("You must select at least 1 line to receive.", "Select a line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmdSelectLines.Focus()
            Return False
        End If
        If Not cboDivisionID.Text.Equals("TWD") And Not cboDivisionID.Text.Equals("TST") Then
            MessageBox.Show("Steel can only be received in under TWD division", "Unable to receive steel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If EmployeeSecurityCode >= 1003 Then
            If DateDiff(DateInterval.Month, dtpSteelReceivingDate.Value, Now) > 1 Then
                MessageBox.Show("Unable to POST to a date greater than 1 month prior than current date.", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            If DateDiff(DateInterval.Day, dtpSteelReceivingDate.Value, Now) < 0 Then
                MessageBox.Show("Unable to POST to a date that has not happened yet.", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        Return True
    End Function

    Private Function assignCoilID() As Boolean
        Dim newAddInfo As New SteelReceivingAdditionalDataRequired(Val(cboSteelRecTicket.Text))
        Dim onlyABALL As Boolean = True
        Dim originalWeights As New List(Of Integer)

        For i As Integer = 0 To ds.Tables("SteelReceivingLineTable").Rows.Count - 1
            If Not ds.Tables("SteelReceivingLineTable").Rows(i).Item("Carbon").ToString.Contains("ABALL") Then
                newAddInfo.addCarbonSizeWeight(ds.Tables("SteelReceivingLineTable").Rows(i).Item("Carbon"), ds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelSize"), ds.Tables("SteelReceivingLineTable").Rows(i).Item("ReceiveWeight"), ds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelReceivingLineKey"))
                onlyABALL = False
                originalWeights.Add(ds.Tables("SteelReceivingLineTable").Rows(i).Item("ReceiveWeight"))
            End If
        Next

        If onlyABALL Then
            Return True
        End If

        newAddInfo.setQuestionText()

        If newAddInfo.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
            Return False
        End If

        Dim chartCMD As New SqlCommand("BEGIN TRAN INSERT INTO CharterSteelCoilIdentification(CoilID, HeatNumber, Weight, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesOrderNumber, PurchaseOrderNumber, Description, Status) VALUES", con)

        With chartCMD.Parameters
            .Add("@LotNumber", SqlDbType.VarChar).Value = ""
            .Add("@ReceiveDate", SqlDbType.VarChar).Value = dtpSteelReceivingDate.Text
            .Add("@DespatchNumber", SqlDbType.VarChar).Value = txtSteelBOL.Text
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = ""
            .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = cboSteelPO.Text
        End With

        Dim heats As New List(Of String)

        Dim line As Integer = 0

        For i As Integer = 0 To newAddInfo.coils.Count - 1
            cmd = New SqlCommand("SELECT MAX(SteelCostPerPound) FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)
            cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = cboSteelRecTicket.Text
            cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = newAddInfo.coils(i).ReceiveLine

            If con.State = ConnectionState.Closed Then con.Open()
            Dim cst As Double = cmd.ExecuteScalar()

            If Not heats.Contains(newAddInfo.coils(i).heat) Then
                heats.Add(newAddInfo.coils(i).heat)
            End If

            ''check to see if the first one and if so will change the values for the element currently in the CoilLines
            If line <> newAddInfo.coils(i).ReceiveLine Then
                cmd = New SqlCommand("UPDATE SteelReceivingCoilLines SET CoilID = @CoilID, CoilWeight = @CoilWeight, SteelExtendedAmount = @SteelExtendedAmount, HeatNumber = @HeatNumber WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                With cmd.Parameters
                    .Add("@CoilID", SqlDbType.VarChar).Value = newAddInfo.coils(i).id
                    .Add("@CoilWeight", SqlDbType.VarChar).Value = newAddInfo.coils(i).weight
                    .Add("@SteelExtendedAmount", SqlDbType.VarChar).Value = cst * newAddInfo.coils(i).weight
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = newAddInfo.coils(i).heat
                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = cboSteelRecTicket.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = newAddInfo.coils(i).carbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = newAddInfo.coils(i).steelSize
                    .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = newAddInfo.coils(i).ReceiveLine
                End With

                line = newAddInfo.coils(i).ReceiveLine
            Else
                cmd = New SqlCommand("INSERT INTO SteelReceivingCoilLines (SteelReceivingHeaderKey, SteelReceivingLineKey, CoilID, CoilWeight, HeatNumber, PONumber, POLineNumber, SteelCostPerPound, SteelExtendedAmount) VALUES (@SteelReceivingHeaderKey, @SteelReceivingLineKey, @CoilID, @CoilWeight, @HeatNumber, @PONumber, (SELECT TOP 1 POLineNumber FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey), @SteelCostPerPound, @SteelExtendedAmount)", con)

                With cmd.Parameters
                    .Add("@CoilID", SqlDbType.VarChar).Value = newAddInfo.coils(i).id
                    .Add("@CoilWeight", SqlDbType.VarChar).Value = newAddInfo.coils(i).weight
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = newAddInfo.coils(i).heat
                    .Add("@PONumber", SqlDbType.VarChar).Value = cboSteelPO.Text
                    .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = newAddInfo.coils(i).ReceiveLine
                    .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = Math.Round(cst, 5, MidpointRounding.AwayFromZero)
                    .Add("@SteelExtendedAmount", SqlDbType.VarChar).Value = Math.Round(cst * newAddInfo.coils(i).weight, 2, MidpointRounding.AwayFromZero)
                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = cboSteelRecTicket.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = newAddInfo.coils(i).carbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = newAddInfo.coils(i).steelSize
                End With
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            If i = 0 Then
                chartCMD.CommandText += " (@CoilID" + i.ToString() + ", @HeatNumber" + i.ToString() + ", @Weight" + i.ToString() + ", @LotNumber, @Carbon" + i.ToString() + ", @SteelSize" + i.ToString() + ", @ReceiveDate, @DespatchNumber, @SalesOrderNumber, @PurchaseOrderNumber, (SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon" + i.ToString() + " AND SteelSize = @SteelSize" + i.ToString() + "), 'RAW')"
            Else
                chartCMD.CommandText += ", (@CoilID" + i.ToString() + ", @HeatNumber" + i.ToString() + ", @Weight" + i.ToString() + ", @LotNumber, @Carbon" + i.ToString() + ", @SteelSize" + i.ToString() + ", @ReceiveDate, @DespatchNumber, @SalesOrderNumber, @PurchaseOrderNumber, (SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon" + i.ToString() + " AND SteelSize = @SteelSize" + i.ToString() + "), 'RAW')"
            End If

            With chartCMD.Parameters
                .Add("@CoilID" + i.ToString(), SqlDbType.VarChar).Value = newAddInfo.coils(i).id
                .Add("@HeatNumber" + i.ToString(), SqlDbType.VarChar).Value = newAddInfo.coils(i).heat
                .Add("Weight" + i.ToString(), SqlDbType.VarChar).Value = newAddInfo.coils(i).weight
                .Add("@Carbon" + i.ToString(), SqlDbType.VarChar).Value = newAddInfo.coils(i).carbon
                .Add("@SteelSize" + i.ToString(), SqlDbType.VarChar).Value = newAddInfo.coils(i).steelSize
            End With
        Next

        If newAddInfo.coils.Count > 0 Then
            chartCMD.CommandText += "; commit TRAN;"
            If con.State = ConnectionState.Closed Then con.Open()
            chartCMD.ExecuteNonQuery()

            UploadBOL(heats)
        End If

        con.Close()
        Return True
    End Function

    Private Sub UploadBOL(ByVal heats As List(Of String))
        Dim files As String() = System.IO.Directory.GetFiles(BOLDir, "*-" + txtSteelBOL.Text + ".pdf")
        If files.Length = 0 Then
            MessageBox.Show("Bill of lading has not been uploaded into the system. You must upload one to the system.", "Upload BOL", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim fileDialog As New OpenFileDialog
            ''makes the file dialog box open to the directory currently used
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples (PaperPort 12)") Then
                fileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples (PaperPort 12)"
            ElseIf System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples") Then
                fileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples"
            End If
            ''will restore to the initial directory
            fileDialog.RestoreDirectory = True
            fileDialog.Multiselect = False
            fileDialog.DefaultExt = ".pdf"
            fileDialog.Filter = "PDF documents (.pdf)|*.pdf"
            While fileDialog.ShowDialog() <> System.Windows.Forms.DialogResult.OK

            End While
            For Each ht In heats
                If System.IO.File.Exists(BOLDir + "\" + ht + "-" + txtSteelBOL.Text + ".pdf") Then
                    Dim adder As Integer = 0
                    While System.IO.File.Exists(BOLDir + "\" + ht + "-" + txtSteelBOL.Text + "-" + adder.ToString + ".pdf")
                        adder += 1
                    End While
                    Try
                        My.Computer.FileSystem.CopyFile(fileDialog.FileName, BOLDir + "\" + ht + "-" + txtSteelBOL.Text + "-" + adder.ToString + ".pdf")
                    Catch ex As System.Exception
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String
                        TempReceiverNumber = Val(cboSteelRecTicket.Text)
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Steel Receipt By PO - Upload Steel BOL"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    Try
                        My.Computer.FileSystem.CopyFile(fileDialog.FileName, BOLDir + "\" + ht + "-" + txtSteelBOL.Text + ".pdf")
                    Catch ex As System.Exception
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String
                        TempReceiverNumber = Val(cboSteelRecTicket.Text)
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Steel Receipt By PO - Upload Steel BOL"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
            Next
        End If
    End Sub

    Private Sub cmdSelectLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectLines.Click
        If canSelectLines() Then
            ''selects the correct statment to perform
            updateOrInsertSteelReceivingHeaderTable()

            Dim NewSelectSteelLinesForReceiving As New SelectSteelLinesForReceiving
            NewSelectSteelLinesForReceiving.setReceiveAndPO(cboSteelPO.Text, cboSteelRecTicket.Text)
            If NewSelectSteelLinesForReceiving.ShowDialog() = System.Windows.Forms.DialogResult.Yes Then
                LoadSteelReceiptData()
                ShowLineItems()
            End If
        End If
    End Sub

    Private Function canSelectLines() As Boolean
        If String.IsNullOrEmpty(cboSteelRecTicket.Text) Then
            MessageBox.Show("You must have a valid Receiving Ticket number to select lines", "Enter valid receiving ticket number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelRecTicket.Focus()
            cboSteelRecTicket.SelectAll()
            Return False
        End If
        If cboSteelRecTicket.Text = -1 Then
            MessageBox.Show("You must Enter a valid Receiving Number", "Enter a valid Receiver Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelRecTicket.SelectAll()
            cboSteelRecTicket.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelPO.Text) Then
            MessageBox.Show("You must select a Purchase Order Number", "Select a PO Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPO.Focus()
            Return False
        End If
        If cboSteelPO.SelectedIndex = -1 Then
            MessageBox.Show("You must have a valid purchase order selected", "Enter valid purchase order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPO.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(txtSteelBOL.Text) Then
            cmd = New SqlCommand("SELECT isnull(COUNT(SteelReceivingHeaderKey), 0) FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderTable.SteelBOLNumber = @SteelBOLNumber and SteelVendor = @SteelVendor AND DivisionID = @DivisionID AND SteelReceivingHeaderKey <> @SteelReceivingHeaderKey AND ReceivingStatus = 'RECEIVED'", con)
            cmd.Parameters.Add("@SteelBOLNumber", SqlDbType.VarChar).Value = txtSteelBOL.Text
            cmd.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = cboSteelVendor.Text
            If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End If
            cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.Int).Value = Val(cboSteelRecTicket.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar() <> 0 Then
                con.Close()
                MessageBox.Show("Bill of lading or packing slip number has already been used for this customer. Enter a unique BOL or packing slip number.", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSteelBOL.SelectAll()
                txtSteelBOL.Focus()
                Return False
            End If
            con.Close()
        End If
        Return True
    End Function

    Private Sub cmdSteelBalances_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using NewSteelBalances As New SteelBalances
            Dim result = NewSteelBalances.ShowDialog()
        End Using
    End Sub

    Private Sub cmdSteelMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using NewRawMaterialMaintenanceForm As New RawMaterialMaintenanceForm
            Dim result = NewRawMaterialMaintenanceForm.ShowDialog()
        End Using
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        isLoaded = False
        unlockBatch()
        ClearVariables()
        ClearData()
        ShowLineItems()
        isLoaded = True
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        isLoaded = False
        unlockBatch()
        ClearVariables()
        ClearData()
        ShowLineItems()
        isLoaded = True
    End Sub

    Private Sub DeleteReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteReceiptToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub SaveReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveReceiptToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub cboSteelPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelPO.SelectedIndexChanged
        If isLoaded Then
            LoadVendorFromPO()
            If needsSaved = False And cboSteelPO.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub updateOrInsertSteelReceivingHeaderTable(Optional ByVal stat As String = "OPEN")
        Try
            If stat.Equals("RECEIVED") Then
                cmd = New SqlCommand("DECLARE @TotalExtendedCost as float = (SELECT SUM(SteelExtendedCost) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey), @SteelTotalWeight as float = (SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey); IF EXISTS(SELECT SteelReceivingHeaderKey FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey) UPDATE SteelReceivingHeaderTable SET ReceivingDate = @ReceivingDate, SteelVendor = @SteelVendor, SteelBOLNumber = @SteelBOLNumber, SteelTotalWeight = @SteelTotalWeight, SteelFreightCharges = @SteelFreightCharges, SteelOtherCharges = @SteelOtherCharges,  SteelTotal = @TotalExtendedCost, InvoiceTotal = ROUND(@SteelFreightCharges + @SteelOtherCharges + @TotalExtendedCost,2), Comment = @Comment, ReceivingStatus = @ReceivingStatus, DivisionID = @DivisionID, Locked = @Locked, PrintDate = @PrintDate WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey ELSE Insert Into SteelReceivingHeaderTable(SteelReceivingHeaderKey, ReceivingDate, SteelVendor, SteelBOLNumber, SteelTotalWeight, SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal, Comment, ReceivingStatus, DivisionID, Locked, PrintDate)Values(@SteelReceivingHeaderKey, @ReceivingDate, @SteelVendor, @SteelBOLNumber, @SteelTotalWeight, @SteelFreightCharges, @SteelOtherCharges, @TotalExtendedCost, ROUND(@SteelFreightCharges + @SteelOtherCharges + @TotalExtendedCost,2), @Comment, @ReceivingStatus, @DivisionID, @Locked, @PrintDate);", con)
                cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime2).Value = Now
            Else
                cmd = New SqlCommand("DECLARE @TotalExtendedCost as float = (SELECT SUM(SteelExtendedCost) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey), @SteelTotalWeight as float = (SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey); IF EXISTS(SELECT SteelReceivingHeaderKey FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey) UPDATE SteelReceivingHeaderTable SET ReceivingDate = @ReceivingDate, SteelVendor = @SteelVendor, SteelBOLNumber = @SteelBOLNumber, SteelTotalWeight = @SteelTotalWeight, SteelFreightCharges = @SteelFreightCharges, SteelOtherCharges = @SteelOtherCharges,  SteelTotal = @TotalExtendedCost, InvoiceTotal = ROUND(@SteelFreightCharges + @SteelOtherCharges + @TotalExtendedCost,2), Comment = @Comment, ReceivingStatus = @ReceivingStatus, DivisionID = @DivisionID, Locked = @Locked WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey ELSE Insert Into SteelReceivingHeaderTable(SteelReceivingHeaderKey, ReceivingDate, SteelVendor, SteelBOLNumber, SteelTotalWeight, SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal, Comment, ReceivingStatus, DivisionID, Locked)Values(@SteelReceivingHeaderKey, @ReceivingDate, @SteelVendor, @SteelBOLNumber, @SteelTotalWeight, @SteelFreightCharges, @SteelOtherCharges, @TotalExtendedCost, ROUND(@SteelFreightCharges + @SteelOtherCharges + @TotalExtendedCost,2), @Comment, @ReceivingStatus, @DivisionID, @Locked);", con)
            End If

            With cmd.Parameters
                .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
                .Add("@ReceivingDate", SqlDbType.VarChar).Value = dtpSteelReceivingDate.Value.ToShortDateString()
                .Add("@SteelVendor", SqlDbType.VarChar).Value = cboSteelVendor.Text
                .Add("@SteelBOLNumber", SqlDbType.VarChar).Value = txtSteelBOL.Text
                .Add("@SteelFreightCharges", SqlDbType.Float).Value = Val(txtFreightTotal.Text)
                .Add("@SteelOtherCharges", SqlDbType.Float).Value = Val(txtOtherTotal.Text)
                .Add("@Comment", SqlDbType.VarChar).Value = txtSteelComment.Text
                .Add("@ReceivingStatus", SqlDbType.VarChar).Value = stat
                .Add("@SteelPONumber", SqlDbType.VarChar).Value = Val(cboSteelPO.Text)
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempReceiverNumber As Integer = 0
            Dim strReceiverNumber As String
            TempReceiverNumber = Val(cboSteelRecTicket.Text)
            strReceiverNumber = CStr(TempReceiverNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Steel Receipt By PO - Update Steel Header"
            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalSteelReceivingNumber = Val(cboSteelRecTicket.Text)
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintSteelReceiptOfGoods As New PrintSteelReceiptOfGoods
            Dim Result = NewPrintSteelReceiptOfGoods.ShowDialog()
        End Using
    End Sub

    Private Sub PrintReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReceiptToolStripMenuItem.Click
        GlobalSteelReceivingNumber = Val(cboSteelRecTicket.Text)
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintSteelReceiptOfGoods As New PrintSteelReceiptOfGoods
            Dim Result = NewPrintSteelReceiptOfGoods.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If canExit() Then
            If cboSteelRecTicket.SelectedIndex = -1 Then
                MessageBox.Show("You must have a valid Receiving Number to save", "Enter a valid Receiving Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSteelRecTicket.SelectAll()
                cboSteelRecTicket.Focus()
                Exit Sub
            End If
            If Not isSomeoneEditing() Then
                updateOrInsertSteelReceivingHeaderTable()
                'Prompt after saving
                MsgBox("Your changes have been saved.", MsgBoxStyle.OkOnly)
            End If
        End If

        unlockBatch()
        ClearVariables()
        ClearData()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Function canExit() As Boolean
        If txtReceivingStatus.Text = "RECEIVED" Then
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelRecTicket.Text) Then
            Return False
        End If
        If needsSaved Then
            If MessageBox.Show("Do you wish to save this Steel Receipt?", "SAVE STEEL RECEIPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> System.Windows.Forms.DialogResult.Yes Then
                Return False
            End If
            Return True
        End If
        Return False
    End Function

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub dtpSteelReceivingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSteelReceivingDate.ValueChanged
        If needsSaved = False And dtpSteelReceivingDate.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtSteelBOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSteelBOL.TextChanged
        If needsSaved = False And txtSteelBOL.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtSteelComment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSteelComment.TextChanged
        If needsSaved = False And txtSteelComment.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub addToSteelTrans(ByRef tempds As DataSet)
        For i As Integer = 0 To tempds.Tables("SteelReceivingLineTable").Rows.Count - 1
            Dim cst As Double = 0.0

            If tempds.Tables("SteelReceivingLineTable").Rows(i).Item("ReceiveWeight") > 0 Then
                cst = Math.Round(tempds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelExtendedCost") / tempds.Tables("SteelReceivingLineTable").Rows(i).Item("ReceiveWeight"), 4)
            End If

            Try
                cmd = New SqlCommand("INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, RMID, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, TransactionMath, TransactionType, SteelTransactionDate) VALUES((SELECT isnull(MAX(TransactionNumber) + 1, 7700001) FROM SteelTransactionTable), @DivisionID, @RMID, @Carbon, @SteelSize, @Quantity, @SteelCostPerPound, @ExtendedCost, @SteelReferenceNumber, @SteelReferenceLineNumber, @TransactionMath, @TransactionType, @SteelTransactionDate)", con)

                With cmd.Parameters
                    .Add("@Carbon", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("Carbon")
                    .Add("@SteelSize", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelSize")
                    .Add("@Quantity", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("ReceiveWeight")
                    .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = cst
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelExtendedCost")
                    .Add("@RMID", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("RMID")
                    .Add("@SteelReferenceNumber", SqlDbType.VarChar).Value = cboSteelRecTicket.Text
                    .Add("@SteelReferenceLineNumber", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelReceivingLineKey")
                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "RECEIPT OF GOODS"
                    .Add("@SteelTransactionDate", SqlDbType.Date).Value = dtpSteelReceivingDate.Value
                End With

                If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End If

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboSteelRecTicket.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Receipt By PO - Add Steel Transaction"
                ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        Next
    End Sub

    Private Sub addCostTiers(ByRef tempds As DataSet)

        For i As Integer = 0 To tempds.Tables("SteelReceivingLineTable").Rows.Count - 1
            Dim NewUpperLimit, LowerLimit, UpperLimit As Double

            Dim UpperLimitStatement As String = "IF EXISTS(SELECT isnull(UpperLimit,0) FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID)) SELECT isnull(UpperLimit,0) FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID) ELSE SELECT 0;"
            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
            UpperLimitCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("RMID")
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
            Catch ex As System.Exception
                UpperLimit = 0
            End Try
            con.Close()

            'Calculate the NEW Lower/Upper Limit for the next post
            LowerLimit = UpperLimit + 1
            NewUpperLimit = LowerLimit + tempds.Tables("SteelReceivingLineTable").Rows(i).Item("ReceiveWeight") - 1

            Try
                cmd = New SqlCommand("Insert Into SteelCostingTable (RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@RMID, @Carbon, @SteelSize, @CostingDate, @SteelCostPerPound, @CostingQuantity, @Status, @LowerLimit, @UpperLimit, (SELECT isnull(MAX(TransactionNumber) + 1, 73700001) FROM SteelCostingTable), @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@Carbon", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("Carbon")
                    .Add("@SteelSize", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelSize")
                    .Add("@CostingDate", SqlDbType.Date).Value = dtpSteelReceivingDate.Value
                    .Add("@SteelCostPerPound", SqlDbType.Float).Value = Math.Round(tempds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelExtendedCost") / tempds.Tables("SteelReceivingLineTable").Rows(i).Item("ReceiveWeight"), 4)
                    .Add("@CostingQuantity", SqlDbType.Int).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("ReceiveWeight")
                    .Add("@RMID", SqlDbType.VarChar).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("RMID")
                    .Add("@Status", SqlDbType.VarChar).Value = "STEEL RECEIVING"
                    .Add("@LowerLimit", SqlDbType.Int).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.Int).Value = NewUpperLimit
                    .Add("@ReferenceNumber", SqlDbType.Int).Value = Val(cboSteelRecTicket.Text)
                    .Add("@ReferenceLine", SqlDbType.Int).Value = tempds.Tables("SteelReceivingLineTable").Rows(i).Item("SteelReceivingLineKey")
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                'Log error on update failure
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboSteelRecTicket.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Receipt By PO - Add Cost Tier"
                ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        Next
    End Sub

    Private Sub tmrWaitToPrint_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrWaitToPrint.Tick
        tmrWaitToPrint.Stop()
    End Sub

    Private Sub cboSteelRecTicket_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelRecTicket.KeyUp
        If e.KeyCode = Keys.Enter Then
            dtpSteelReceivingDate.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub dtpSteelReceivingDate_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpSteelReceivingDate.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboSteelPO.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub cboSteelPO_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelPO.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboSteelVendor.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub cboSteelVendor_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelVendor.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtSteelBOL.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub txtSteelBOL_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSteelBOL.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtSteelComment.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub txtSteelComment_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSteelComment.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdSelectLines.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub UpdateTotals()
        Dim SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal As Double

        cmd = New SqlCommand("SELECT SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.Int).Value = Val(cboSteelRecTicket.Text)

        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SteelFreightCharges")) Then
                SteelFreightCharges = 0
            Else
                SteelFreightCharges = reader.Item("SteelFreightCharges")
            End If
            If IsDBNull(reader.Item("SteelOtherCharges")) Then
                SteelOtherCharges = 0
            Else
                SteelOtherCharges = reader.Item("SteelOtherCharges")
            End If
            If IsDBNull(reader.Item("SteelTotal")) Then
                SteelTotal = 0
            Else
                SteelTotal = reader.Item("SteelTotal")
            End If
            If IsDBNull(reader.Item("InvoiceTotal")) Then
                InvoiceTotal = 0
            Else
                InvoiceTotal = reader.Item("InvoiceTotal")
            End If
        Else
            SteelFreightCharges = 0
            SteelOtherCharges = 0
            SteelTotal = 0
            InvoiceTotal = 0
        End If
        reader.Close()
        con.Close()

        lblSteelTotal.Text = FormatCurrency(SteelTotal, 2).ToString()
        txtFreightTotal.Text = SteelFreightCharges.ToString()
        txtOtherTotal.Text = SteelOtherCharges.ToString()
        lblInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2).ToString()
    End Sub

    Private Sub checkAndUpdatePOStatus()
        cmd = New SqlCommand("SELECT DISTINCT(PONumber), POLineNumber FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey GROUP BY PONumber, POLineNumber ORDER BY PONumber", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)

        Dim poInfor As New DataSet()
        Dim adaptPO As New SqlDataAdapter
        adaptPO.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        adaptPO.Fill(poInfor, "POS")
        con.Close()
        ''check to make sure there is a PO found in the CoilLines
        If poInfor.Tables("POS").Rows.Count > 0 Then
            While poInfor.Tables("POS").Rows.Count > 0
                Dim test As Integer = poInfor.Tables("POS").Rows(0).Item("POLineNumber")
                Dim test2 As Integer = poInfor.Tables("POS").Rows(0).Item("PONumber")
                cmd = New SqlCommand("SELECT QuantityOpen FROM SteelPurchaseQuantityStatus WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber;", con)
                cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = poInfor.Tables("POS").Rows(0).Item("PONumber")
                cmd.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = poInfor.Tables("POS").Rows(0).Item("POLineNumber")

                Dim quantityOpen As Double = 0

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    quantityOpen = cmd.ExecuteScalar()
                Catch ex As System.Exception
                End Try
                con.Close()

                If quantityOpen <= 0 Then
                    cmd = New SqlCommand("UPDATE SteelPurchaseLine SET LineStatus = @LineStatus WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber;", con)
                    ''gets the count of lines that are still open for the PO
                    cmd.CommandText += " SELECT COUNT(LineStatus) FROM SteelPurchaseQuantityStatus WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND LineStatus = 'OPEN';"
                    With cmd.Parameters
                        .Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPO.Text)
                        .Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = poInfor.Tables("POS").Rows(0).Item("POLineNumber")
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()

                    Dim cnt As Integer = 0
                    ''check to see if the PO needs closed
                    If cnt = 0 Then
                        cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET Status = 'CLOSED' WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey AND DivisionID = @DivisionID;", con)
                        cmd.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = Val(cboSteelPO.Text)
                        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                        Else
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        End If
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()

                    End If
                    con.Close()
                End If
                poInfor.Tables("POS").Rows.RemoveAt(0)
            End While
        End If
    End Sub

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            Dim obj As Object = reader.Item(0)
            If Not IsDBNull(obj) Then
                personEditing = obj
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
        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET Locked = @Locked WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = cboSteelRecTicket.Text
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET Locked = '' WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND Locked = @Locked AND DivisionID = @DivisionID;", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
        Else
            cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = batch
        End If
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub UnLockReceiverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockReceiverToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboSteelRecTicket.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this Receiver?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET Locked = '' WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID;", con)
                cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
                If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Or cboDivisionID.Text.Equals("TST") Then
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End If

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Receiver is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a Receiver number to un-lock", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelRecTicket.Focus()
        End If
    End Sub

    Private Sub cboSteelRecTicket_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelRecTicket.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub cboSteelRecTicket_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelRecTicket.KeyDown
        Select Case e.KeyCode
            Case Keys.Back, Keys.Delete
                controlKey = True
        End Select
    End Sub

    Private Sub cboSteelPO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelPO.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub cboSteelPO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelPO.KeyDown
        Select Case e.KeyCode
            Case Keys.Back, Keys.Delete
                controlKey = True
        End Select
    End Sub

    Private Sub SteelReceivingForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(cboSteelRecTicket.Text) Then
            unlockBatch()
        End If
    End Sub

    Private Sub txtSteelBOL_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSteelBOL.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub txtSteelBOL_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSteelBOL.KeyDown
        Select Case e.KeyCode
            Case Keys.Back, Keys.Delete
                controlKey = True
        End Select
    End Sub

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged
        If isLoaded Then
            lblInvoiceTotal.Text = FormatCurrency(Val(lblSteelTotal.Text.Replace("$", "").Replace(",", "")) + Val(txtFreightTotal.Text) + Val(txtOtherTotal.Text), 2)
        End If
    End Sub

    Private Sub txtOtherTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherTotal.TextChanged
        If isLoaded Then
            lblInvoiceTotal.Text = FormatCurrency(Val(lblSteelTotal.Text.Replace("$", "").Replace(",", "")) + Val(txtFreightTotal.Text) + Val(txtOtherTotal.Text), 2)
        End If
    End Sub

    Private Sub txtFreightTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFreightTotal.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete, Keys.Back
                controlKey = True
            Case Keys.Decimal
                If Not txtFreightTotal.Text.Contains(".") Or (txtFreightTotal.SelectionLength = txtFreightTotal.Text.Length) Then
                    controlKey = True
                End If
        End Select
    End Sub

    Private Sub txtFreightTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFreightTotal.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub txtFreightTotal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFreightTotal.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtOtherTotal.Focus()
            txtOtherTotal.SelectAll()
        End If
    End Sub

    Private Sub txtOtherTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtherTotal.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete, Keys.Back
                controlKey = True
            Case Keys.Decimal
                If Not txtOtherTotal.Text.Contains(".") Or (txtOtherTotal.SelectionLength = txtOtherTotal.Text.Length) Then
                    controlKey = True
                End If
        End Select
    End Sub

    Private Sub txtOtherTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherTotal.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub SteelReceivingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub LoadReceivingData()
        Dim ReceivingDate As Date
        Dim SteelVendor, SteelBOLNumber, Comment, ReceivingStatus As String
        Dim SteelTotalWeight As Integer
        Dim SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal As Double

        cmd = New SqlCommand("SELECT ReceivingDate, SteelVendor, SteelBOLNumber, SteelTotalWeight, SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal, Comment, ReceivingStatus FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelRecTicket.Text)
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ReceivingDate")) Then
                ReceivingDate = dtpSteelReceivingDate.Value
            Else
                ReceivingDate = reader.Item("ReceivingDate").ToString()
            End If
            If IsDBNull(reader.Item("ReceivingDate")) Then
                SteelVendor = cboSteelVendor.Text
            Else
                SteelVendor = reader.Item("SteelVendor")
            End If
            If IsDBNull(reader.Item("SteelBOLNumber")) Then
                SteelBOLNumber = txtSteelBOL.Text
            Else
                SteelBOLNumber = reader.Item("SteelBOLNumber")
            End If
            If IsDBNull(reader.Item("SteelTotalWeight")) Then
                SteelTotalWeight = 0
            Else
                SteelTotalWeight = reader.Item("SteelTotalWeight")
            End If
            If IsDBNull(reader.Item("SteelFreightCharges")) Then
                SteelFreightCharges = 0
            Else
                SteelFreightCharges = reader.Item("SteelFreightCharges")
            End If
            If IsDBNull(reader.Item("SteelOtherCharges")) Then
                SteelOtherCharges = 0
            Else
                SteelOtherCharges = reader.Item("SteelOtherCharges")
            End If
            If IsDBNull(reader.Item("SteelTotal")) Then
                SteelTotal = 0
            Else
                SteelTotal = reader.Item("SteelTotal")
            End If
            If IsDBNull(reader.Item("InvoiceTotal")) Then
                InvoiceTotal = 0
            Else
                InvoiceTotal = reader.Item("InvoiceTotal")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = txtSteelComment.Text
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("ReceivingStatus")) Then
                ReceivingStatus = "OPEN"
            Else
                ReceivingStatus = reader.Item("ReceivingStatus")
            End If
        Else
            ReceivingDate = dtpSteelReceivingDate.Text
            SteelVendor = cboSteelVendor.Text
            SteelBOLNumber = txtSteelBOL.Text
            SteelTotalWeight = 0
            SteelFreightCharges = 0
            SteelOtherCharges = 0
            SteelTotal = 0
            InvoiceTotal = 0
            Comment = txtSteelComment.Text
            ReceivingStatus = "OPEN"
        End If
        reader.Close()
        con.Close()

        If ReceivingStatus = "RECEIVED" Or ReceivingStatus = "CLOSED" Then
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            cmdSaveAndPost.Enabled = False
            cmdSelectLines.Enabled = False
            SaveReceiptToolStripMenuItem.Enabled = False
            DeleteReceiptToolStripMenuItem.Enabled = False
            cboSteelPO.Enabled = False
            cboSteelVendor.Enabled = False
            txtSteelBOL.ReadOnly = True
            txtSteelComment.ReadOnly = True
            txtFreightTotal.ReadOnly = True
            txtOtherTotal.ReadOnly = True
        Else
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            cmdSaveAndPost.Enabled = True
            cmdSelectLines.Enabled = True
            SaveReceiptToolStripMenuItem.Enabled = True
            DeleteReceiptToolStripMenuItem.Enabled = True
            cboSteelPO.Enabled = True
            cboSteelVendor.Enabled = True
            txtSteelBOL.ReadOnly = False
            txtSteelComment.ReadOnly = False
            txtFreightTotal.ReadOnly = False
            txtOtherTotal.ReadOnly = False
        End If

        dtpSteelReceivingDate.Value = ReceivingDate
        cboSteelVendor.Text = SteelVendor
        txtSteelBOL.Text = SteelBOLNumber
        txtSteelComment.Text = Comment
        txtReceivingStatus.Text = ReceivingStatus
        lblSteelTotal.Text = FormatCurrency(SteelTotal, 2)
        txtFreightTotal.Text = SteelFreightCharges
        txtOtherTotal.Text = SteelOtherCharges
        lblInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

End Class