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
Public Class RequisitionForm
    Inherits System.Windows.Forms.Form

    Dim Quantity, NextTransactionNumber, LastTransactionNumber, counter As Integer
    Dim Cost, Total As Double
    Dim ReqDate, PartNumber, Description, RequestedBy, Status, VendorID, Comment As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub RequisitionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        'Initialize Data
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        'Load Vendor List for specific division
        LoadVendorList()
        LoadRequisitionNumber()

        'Initialize data
        ClearData()
        ShowData()
    End Sub

    Public Sub LoadVendorList()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboVendor.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboVendor.SelectedIndex = -1
    End Sub

    Public Sub LoadRequisitionNumber()
        cmd = New SqlCommand("SELECT RequisitionNumber FROM RequisitionEntry WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RequisitionEntry")
        cboRequisitionNumber.DataSource = ds2.Tables("RequisitionEntry")
        con.Close()
        cboRequisitionNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowDataByDate()
        cmd = New SqlCommand("SELECT * FROM RequisitionEntry WHERE ReqDate = @ReqDate and DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReqDate", SqlDbType.VarChar).Value = dtpReqDate.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RequisitionEntry")
        dgvRequisitionTable.DataSource = ds.Tables("RequisitionEntry")
        con.Close()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM RequisitionEntry WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RequisitionEntry")
        dgvRequisitionTable.DataSource = ds.Tables("RequisitionEntry")
        con.Close()
    End Sub

    Public Sub ShowDataOpen()
        cmd = New SqlCommand("SELECT * FROM RequisitionEntry WHERE Status = @Status and DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RequisitionEntry")
        dgvRequisitionTable.DataSource = ds.Tables("RequisitionEntry")
        con.Close()
    End Sub

    Public Sub ShowDataClosed()
        cmd = New SqlCommand("SELECT * FROM RequisitionEntry WHERE Status = @Status and DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RequisitionEntry")
        dgvRequisitionTable.DataSource = ds.Tables("RequisitionEntry")
        cboRequisitionNumber.DataSource = ds.Tables("RequisitionEntry")
        con.Close()
    End Sub

    Public Sub ShowDataPending()
        cmd = New SqlCommand("SELECT * FROM RequisitionEntry WHERE Status = @Status and DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "PENDING"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RequisitionEntry")
        dgvRequisitionTable.DataSource = ds.Tables("RequisitionEntry")
        con.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub ClearData()
        cboRequisitionNumber.Refresh()
        cboVendor.Refresh()
        cboReqNumber.Refresh()

        txtComment.Refresh()
        txtCost.Refresh()
        txtDescription.Refresh()
        txtPartNumber.Refresh()
        txtQuantity.Refresh()
        txtRequestedBy.Refresh()
        txtTotal.Refresh()
        txtStatus.Refresh()

        cboDivisionID.Text = EmployeeCompanyCode
        cboRequisitionNumber.SelectedIndex = -1
        cboVendor.SelectedIndex = -1
        cboReqNumber.SelectedIndex = -1

        txtComment.Clear()
        txtCost.Clear()
        txtDescription.Clear()
        txtPartNumber.Clear()
        txtQuantity.Clear()
        txtRequestedBy.Clear()
        txtTotal.Clear()
        txtStatus.Clear()
        cboRequisitionNumber.Focus()
    End Sub

    Public Sub LoadRequisitionData()
        Dim ReqDateString As String = "SELECT ReqDate FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim ReqDateCommand As New SqlCommand(ReqDateString, con)
        ReqDateCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        Dim PartNumberString As String = "SELECT PartNumber FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim PartNumberCommand As New SqlCommand(PartNumberString, con)
        PartNumberCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        Dim DescriptionString As String = "SELECT Description FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim DescriptionCommand As New SqlCommand(DescriptionString, con)
        DescriptionCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        Dim RequestedByString As String = "SELECT RequestedBy FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim RequestedByCommand As New SqlCommand(RequestedByString, con)
        RequestedByCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        Dim CostString As String = "SELECT Cost FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim CostCommand As New SqlCommand(CostString, con)
        CostCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        Dim QuantityString As String = "SELECT Quantity FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim QuantityCommand As New SqlCommand(QuantityString, con)
        QuantityCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        Dim TotalString As String = "SELECT Total FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim TotalCommand As New SqlCommand(TotalString, con)
        TotalCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        Dim StatusString As String = "SELECT Status FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim StatusCommand As New SqlCommand(StatusString, con)
        StatusCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        Dim VendorIDString As String = "SELECT VendorID FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim VendorIDCommand As New SqlCommand(VendorIDString, con)
        VendorIDCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        Dim CommentString As String = "SELECT Comment FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber"
        Dim CommentCommand As New SqlCommand(CommentString, con)
        CommentCommand.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ReqDate = CStr(ReqDateCommand.ExecuteScalar)
        Catch ex As Exception
            ReqDate = ""
        End Try
        Try
            PartNumber = CStr(PartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            PartNumber = ""
        End Try
        Try
            Description = CStr(DescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            Description = ""
        End Try
        Try
            RequestedBy = CStr(RequestedByCommand.ExecuteScalar)
        Catch ex As Exception
            RequestedBy = ""
        End Try
        Try
            Cost = CDbl(CostCommand.ExecuteScalar)
        Catch ex As Exception
            Cost = 0
        End Try
        Try
            Quantity = CInt(QuantityCommand.ExecuteScalar)
        Catch ex As Exception
            Quantity = 0
        End Try
        Try
            Total = CDbl(TotalCommand.ExecuteScalar)
        Catch ex As Exception
            Total = 0
        End Try
        Try
            Status = CStr(StatusCommand.ExecuteScalar)
        Catch ex As Exception
            Status = ""
        End Try
        Try
            VendorID = CStr(VendorIDCommand.ExecuteScalar)
        Catch ex As Exception
            VendorID = ""
        End Try
        Try
            Comment = CStr(CommentCommand.ExecuteScalar)
        Catch ex As Exception
            Comment = ""
        End Try
        con.Close()

        dtpReqDate.Text = ReqDate
        txtPartNumber.Text = PartNumber
        txtDescription.Text = Description
        txtRequestedBy.Text = RequestedBy
        txtCost.Text = Cost
        txtQuantity.Text = Quantity
        txtTotal.Text = Total
        txtStatus.text = Status
        cboVendor.Text = VendorID
        txtComment.Text = Comment
    End Sub

    Private Sub cndEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cndEnter.Click
        Try
            'Write Data to Requisition Table
            cmd = New SqlCommand("Insert Into RequisitionEntry(RequisitionNumber, ReqDate, DivisionID, PartNumber, Description, RequestedBy, Cost, Quantity, Status, VendorID, Comment, Total)Values(@RequisitionNumber, @ReqDate, @DivisionID, @PartNumber, @Description, @RequestedBy, @Cost, @Quantity, @Status, @VendorID, @Comment, @Total )", con)

            With cmd.Parameters
                .Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)
                .Add("@ReqDate", SqlDbType.VarChar).Value = dtpReqDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                .Add("@RequestedBy", SqlDbType.VarChar).Value = txtRequestedBy.Text
                .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                .Add("@Status", SqlDbType.VarChar).Value = "Open"
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@Total", SqlDbType.VarChar).Value = Val(txtTotal.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Write Data to Requisition Table
            cmd = New SqlCommand("UPDATE RequisitionEntry SET ReqDate = @ReqDate, PartNumber = @PartNumber, Description = @Description, RequestedBy = @RequestedBy, Cost = @Cost, Quantity = @Quantity, Status = @Status, VendorID = @VendorID, Comment = @Comment, Total = @Total WHERE RequisitionNumber = @RequisitionNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)
                .Add("@ReqDate", SqlDbType.VarChar).Value = dtpReqDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                .Add("@RequestedBy", SqlDbType.VarChar).Value = txtRequestedBy.Text
                .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                .Add("@Status", SqlDbType.VarChar).Value = "Open"
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@Total", SqlDbType.VarChar).Value = Val(txtTotal.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try

        ShowData()
        ClearData()

        Cost = 0
        Quantity = 0
        Total = 0
    End Sub

    Private Sub txtCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCost.TextChanged
        'Validate numeric data
        Cost = Val(txtCost.Text)
        If Cost <> 0 And Quantity <> 0 Then
            Total = Cost * Quantity
            txtTotal.Text = FormatCurrency(Total, 2)
        Else
            'Do nothing
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        'Validate numeric data and populate Total Field
        Quantity = Val(txtQuantity.Text)
        If Cost <> 0 And Quantity <> 0 Then
            Total = Cost * Quantity
            txtTotal.Text = FormatCurrency(Total, 2)
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboRequisitionNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRequisitionNumber.SelectedIndexChanged
        LoadRequisitionData()
        ShowData()
    End Sub

    Private Sub dtpReqDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReqDate.ValueChanged
        ShowDataByDate()
    End Sub

    Private Sub cmdViewOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewOpen.Click
        ShowDataOpen()
    End Sub

    Private Sub cmdViewClosed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewClosed.Click
        ShowDataClosed()
    End Sub

    Private Sub cmdViewPending_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPending.Click
        ShowDataPending()
    End Sub

    Private Sub cmdApproveReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApproveReq.Click

        If EmployeeCompanyCode = "ADM" Then
            'Change Status of Requisition
            cmd = New SqlCommand("UPDATE RequisitionEntry SET Status = @Status WHERE RequisitionNumber = @RequisitionNumber", con)
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "PENDING"
            cmd.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboReqNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearData()
            MessageBox.Show("Requisition has been approved", "REQUISITION APPROVED")
        Else
            MessageBox.Show("You are not authorized to approve data", "ACCESS DENIED")
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ShowData()
    End Sub

    Private Sub cmdGenerateNewReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewReq.Click
        'Clear form on next number
        ClearData()
        ShowData()

        Dim MAXStatement As String = "SELECT MAX(RequisitionNumber) FROM RequisitionEntry"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim LastTransactionNumber As Integer = CInt(MAXCommand.ExecuteScalar)
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        cboRequisitionNumber.Text = NextTransactionNumber

        'Save Requisition Number so it can not be selected again
        Try
            'Write Data to Requisition Table
            cmd = New SqlCommand("Insert Into RequisitionEntry(RequisitionNumber, ReqDate, DivisionID, PartNumber, Description, RequestedBy, Cost, Quantity, Status, VendorID, Comment, Total)Values(@RequisitionNumber, @ReqDate, @DivisionID, @PartNumber, @Description, @RequestedBy, @Cost, @Quantity, @Status, @VendorID, @Comment, @Total )", con)

            With cmd.Parameters
                .Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)
                .Add("@ReqDate", SqlDbType.VarChar).Value = dtpReqDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                .Add("@RequestedBy", SqlDbType.VarChar).Value = txtRequestedBy.Text
                .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                .Add("@Status", SqlDbType.VarChar).Value = "Open"
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@Total", SqlDbType.VarChar).Value = Val(txtTotal.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Write Data to Requisition Table
            cmd = New SqlCommand("UPDATE RequisitionEntry SET ReqDate = @ReqDate, PartNumber = @PartNumber, Description = @Description, RequestedBy = @RequestedBy, Cost = @Cost, Quantity = @Quantity, Status = @Status, VendorID = @VendorID, Comment = @Comment, Total = @Total WHERE RequisitionNumber = @RequisitionNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)
                .Add("@ReqDate", SqlDbType.VarChar).Value = dtpReqDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                .Add("@RequestedBy", SqlDbType.VarChar).Value = txtRequestedBy.Text
                .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                .Add("@Status", SqlDbType.VarChar).Value = "Open"
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@Total", SqlDbType.VarChar).Value = Val(txtTotal.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try

        cboRequisitionNumber.Focus()
    End Sub

    Private Sub cmdCloseReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseReq.Click
        If EmployeeCompanyCode = "ADM" Then
            'Change Status of Requisition
            cmd = New SqlCommand("UPDATE RequisitionEntry SET Status = @Status WHERE RequisitionNumber = @RequisitionNumber", con)
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            cmd.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboReqNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearData()
            MessageBox.Show("Requisition has been closed", "REQUISITION CLOSED")
        Else
            MessageBox.Show("You are not authorized to approve data", "ACCESS DENIED")
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboRequisitionNumber.Text = "" Then
            MsgBox("You must have a valid Requisition Number.", MsgBoxStyle.OkOnly)
        Else
            Try
                'Write Data to Requisition Table
                cmd = New SqlCommand("Insert Into RequisitionEntry(RequisitionNumber, ReqDate, DivisionID, PartNumber, Description, RequestedBy, Cost, Quantity, Status, VendorID, Comment, Total)Values(@RequisitionNumber, @ReqDate, @DivisionID, @PartNumber, @Description, @RequestedBy, @Cost, @Quantity, @Status, @VendorID, @Comment, @Total )", con)

                With cmd.Parameters
                    .Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)
                    .Add("@ReqDate", SqlDbType.VarChar).Value = dtpReqDate.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                    .Add("@RequestedBy", SqlDbType.VarChar).Value = txtRequestedBy.Text
                    .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "Open"
                    .Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@Total", SqlDbType.VarChar).Value = Val(txtTotal.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write Data to Requisition Table
                cmd = New SqlCommand("UPDATE RequisitionEntry SET ReqDate = @ReqDate, PartNumber = @PartNumber, Description = @Description, RequestedBy = @RequestedBy, Cost = @Cost, Quantity = @Quantity, Status = @Status, VendorID = @VendorID, Comment = @Comment, Total = @Total WHERE RequisitionNumber = @RequisitionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)
                    .Add("@ReqDate", SqlDbType.VarChar).Value = dtpReqDate.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                    .Add("@RequestedBy", SqlDbType.VarChar).Value = txtRequestedBy.Text
                    .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "Open"
                    .Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@Total", SqlDbType.VarChar).Value = Val(txtTotal.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try

            ClearData()
            ShowData()
            MessageBox.Show("Requisition has been saved", "REQUISITION SAVED")
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Requisition?", "DELETE REQUISITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then

            'Create command to delete data from text boxes
            cmd = New SqlCommand("DELETE FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboReqNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Prompt before deleting
            MsgBox("This Requisition has been deleted", MsgBoxStyle.OkOnly)

            ClearData()
            ShowData()

        ElseIf button = DialogResult.No Then
            cboRequisitionNumber.Focus()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalRequisitionNumber = Val(cboReqNumber.Text)
        Using NewPrintRequisition As New PrintRequisition
            Dim result = NewPrintRequisition.ShowDialog()
        End Using
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        ClearData()
        ShowData()
    End Sub

    Private Sub PrintRequisitionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintRequisitionToolStripMenuItem.Click
        GlobalRequisitionNumber = Val(cboReqNumber.Text)
        Using NewPrintRequisition As New PrintRequisition
            Dim result = NewPrintRequisition.ShowDialog()
        End Using
    End Sub

    Private Sub DeleteRequisitionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteRequisitionToolStripMenuItem.Click
        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Requisition?", "DELETE REQUISITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then

            'Create command to delete data from text boxes
            cmd = New SqlCommand("DELETE FROM RequisitionEntry WHERE RequisitionNumber = @RequisitionNumber", con)
            cmd.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboReqNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Prompt before deleting
            MsgBox("This Requisition has been deleted", MsgBoxStyle.OkOnly)

            ClearData()
            ShowData()

        ElseIf button = DialogResult.No Then
            cboRequisitionNumber.Focus()
        End If
    End Sub

    Private Sub SaveRequisitionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveRequisitionToolStripMenuItem.Click
        If cboRequisitionNumber.Text = "" Then
            MsgBox("You must have a valid Requisition Number.", MsgBoxStyle.OkOnly)
        Else
            Try
                'Write Data to Requisition Table
                cmd = New SqlCommand("Insert Into RequisitionEntry(RequisitionNumber, ReqDate, DivisionID, PartNumber, Description, RequestedBy, Cost, Quantity, Status, VendorID, Comment, Total)Values(@RequisitionNumber, @ReqDate, @DivisionID, @PartNumber, @Description, @RequestedBy, @Cost, @Quantity, @Status, @VendorID, @Comment, @Total )", con)

                With cmd.Parameters
                    .Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)
                    .Add("@ReqDate", SqlDbType.VarChar).Value = dtpReqDate.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                    .Add("@RequestedBy", SqlDbType.VarChar).Value = txtRequestedBy.Text
                    .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "Open"
                    .Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@Total", SqlDbType.VarChar).Value = Val(txtTotal.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write Data to Requisition Table
                cmd = New SqlCommand("UPDATE RequisitionEntry SET ReqDate = @ReqDate, PartNumber = @PartNumber, Description = @Description, RequestedBy = @RequestedBy, Cost = @Cost, Quantity = @Quantity, Status = @Status, VendorID = @VendorID, Comment = @Comment, Total = @Total WHERE RequisitionNumber = @RequisitionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@RequisitionNumber", SqlDbType.VarChar).Value = Val(cboRequisitionNumber.Text)
                    .Add("@ReqDate", SqlDbType.VarChar).Value = dtpReqDate.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                    .Add("@RequestedBy", SqlDbType.VarChar).Value = txtRequestedBy.Text
                    .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "Open"
                    .Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@Total", SqlDbType.VarChar).Value = Val(txtTotal.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try

            ClearData()
            ShowData()
            MessageBox.Show("Requisition has been saved", "REQUISITION SAVED")
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        'Load Vendor List for specific division
        LoadVendorList()
        LoadRequisitionNumber()
        ClearData()
        ShowData()
    End Sub
End Class