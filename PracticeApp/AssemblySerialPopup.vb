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
Public Class AssemblySerialPopup
    Inherits System.Windows.Forms.Form

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub AssemblySerialPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalSerialAssemblyQuantity = 0
        GlobalAssemblyPartNumber = ""
        GlobalAssemblyInvoiceNumber = 0
        GlobalAssemblyInvoiceLine = 0
        GlobalAssemblyCustomer = ""
        GlobalSerialFormLocation = ""
    End Sub

    Private Sub AssemblySerialPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load defaults based on which form the pop up opened from
        If GlobalSerialFormLocation = "SALESORDERFORM" Then
            lblTextSearch.Visible = False
            txtTextSearch.Visible = False
            lblInvoiceLabel.Text = "Select Serial Numbers in datagrid. Number selected must match the invoice quantity."
            txtBuildQuantity.Text = GlobalSerialAssemblyQuantity
            txtAssemblyPartNumber.Text = GlobalAssemblyPartNumber

            ShowDataSOForm()

            chkAddNew.Visible = False
            txtSerialNumber.Visible = False
            lblSerialNumber.Visible = False
        ElseIf GlobalSerialFormLocation = "INVENTORYADJUSTMENT" Then
            lblInvoiceLabel.Text = "Select Serial Numbers in datagrid. Number selected must be less than or equal to the number adjusted."
            txtBuildQuantity.Text = GlobalSerialAssemblyQuantity
            txtAssemblyPartNumber.Text = GlobalAssemblyPartNumber
            lblTextSearch.Visible = False
            txtTextSearch.Visible = False

            If GlobalSerialAssemblyQuantity > 0 Then
                ShowDataIAFormADD()
            Else
                ShowDataIAFormSubtract()
            End If

            If GlobalSerialAssemblyQuantity = 1 Then
                chkAddNew.Enabled = True
            Else
                chkAddNew.Enabled = False
            End If
        ElseIf GlobalSerialFormLocation = "CUSTOMERRETURN" Then
            lblInvoiceLabel.Text = "Select Serial Numbers in datagrid. Number selected must match the return quantity."
            txtBuildQuantity.Text = GlobalSerialAssemblyQuantity
            txtAssemblyPartNumber.Text = GlobalAssemblyPartNumber
            ShowDataReturnForm()
            lblTextSearch.Visible = True
            txtTextSearch.Visible = True

            If GlobalSerialAssemblyQuantity = 1 Then
                chkAddNew.Enabled = True
            Else
                chkAddNew.Enabled = False
            End If
        ElseIf GlobalSerialFormLocation = "VENDORRETURN" Then
            lblInvoiceLabel.Text = "Select Serial Numbers in datagrid. Number selected must match the return quantity."
            txtBuildQuantity.Text = GlobalSerialAssemblyQuantity
            txtAssemblyPartNumber.Text = GlobalAssemblyPartNumber
            lblTextSearch.Visible = False
            txtTextSearch.Visible = False
            ShowDataReturnForm()
        ElseIf GlobalSerialFormLocation = "ADDBUILDS" Then
            lblInvoiceLabel.Text = "Select Serial Numbers in datagrid to make available for sale."
            txtBuildQuantity.Enabled = False
            txtBuildQuantity.Clear()
            txtAssemblyPartNumber.Text = GlobalAssemblyPartNumber
            ShowDataIAFormADD()
            lblTextSearch.Visible = False
            txtTextSearch.Visible = False
            chkAddNew.Visible = False
            txtSerialNumber.Visible = False
            lblSerialNumber.Visible = False
        End If
    End Sub

    Public Sub ShowDataSOForm()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber AND Status = @Status", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblySerialLog")
        dgvTempSerialLog.DataSource = ds.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Public Sub ShowDataIAFormADD()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status", con)
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblySerialLog")
        dgvTempSerialLog.DataSource = ds.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Public Sub ShowDataIAFormSubtract()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status", con)
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblySerialLog")
        dgvTempSerialLog.DataSource = ds.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Public Sub ShowDataReturnForm()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND Status <> @Status", con)
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblySerialLog")
        dgvTempSerialLog.DataSource = ds.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalSerialAssemblyQuantity = 0
        GlobalAssemblyPartNumber = ""
        GlobalAssemblyInvoiceNumber = 0
        GlobalAssemblyInvoiceLine = 0
        GlobalAssemblyCustomer = ""

        GlobalSerialValidation = "NO"

        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
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

    Private Sub cmdCreateAssemblies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateAssemblies.Click
        'Choose action depending on what form opened the pop-up
        Select Case GlobalSerialFormLocation
            Case "SALESORDERFORM"
                Dim Counter As Integer = 0

                For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                    Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                    If cell.Value = "SELECTED" Then
                        Counter = Counter + 1
                    End If
                Next
                '*******************************************************************************************
                If Counter = GlobalSerialAssemblyQuantity Then
                    Dim SerialNumber As String = ""
                    Dim SerialCost As Double = 0
                    Dim BuildDate As String = ""
                    Dim BuildNumber As Integer = 0
                    Dim AssemblyPartNumber As String = ""
                    Dim Comment As String = ""
                    Dim DivisionID As String = ""
                    Dim ShipmentNumber As Integer = 0
                    Dim ShipDate As String = ""
                    Dim TransactionNumber As Integer = 0

                    For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                        Dim cell2 As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                        If cell2.Value = "SELECTED" Then
                            'Update Serial Log with a batch number to pull back into the Build Form
                            Try
                                SerialNumber = row.Cells("SerialNumberColumn").Value
                            Catch ex As Exception
                                SerialNumber = ""
                            End Try
                            Try
                                SerialCost = row.Cells("TotalCostColumn").Value
                            Catch ex As Exception
                                SerialCost = 0
                            End Try
                            Try
                                BuildDate = row.Cells("BuildDateColumn").Value
                            Catch ex As Exception
                                BuildDate = ""
                            End Try
                            Try
                                BuildNumber = row.Cells("BuildNumberColumn").Value
                            Catch ex As Exception
                                BuildNumber = 0
                            End Try
                            Try
                                AssemblyPartNumber = row.Cells("AssemblyPartNumberColumn").Value
                            Catch ex As Exception
                                AssemblyPartNumber = ""
                            End Try
                            Try
                                Comment = row.Cells("CommentColumn").Value
                            Catch ex As Exception
                                Comment = ""
                            End Try
                            Try
                                DivisionID = row.Cells("DivisionIDColumn").Value
                            Catch ex As Exception
                                DivisionID = ""
                            End Try
                            Try
                                ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                            Catch ex As Exception
                                ShipmentNumber = 0
                            End Try
                            Try
                                ShipDate = row.Cells("ShipmentDateColumn").Value
                            Catch ex As Exception
                                ShipDate = ""
                            End Try
                            Try
                                TransactionNumber = row.Cells("TransactionNumberColumn").Value
                            Catch ex As Exception
                                TransactionNumber = 0
                            End Try
                            '***********************************************************************************
                            'Get MAX Invoice Serial Line number
                            Dim LastSerialLineNumber, NextSerialLineNumber As Integer

                            Dim MAXSerialLineStatement As String = "SELECT MAX(InvoiceSerialLineNumber) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber AND InvoiceLineNumber = @InvoiceLineNumber"
                            Dim MAXSerialLineCommand As New SqlCommand(MAXSerialLineStatement, con)
                            MAXSerialLineCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceNumber
                            MAXSerialLineCommand.Parameters.Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastSerialLineNumber = CInt(MAXSerialLineCommand.ExecuteScalar)
                            Catch ex As Exception
                                LastSerialLineNumber = 0
                            End Try
                            con.Close()

                            NextSerialLineNumber = LastSerialLineNumber + 1
                            '************************************************************************************
                            'Insert into Invoice Serial lines
                            Try
                                cmd = New SqlCommand("INSERT INTO InvoiceSerialLineTable (InvoiceNumber, InvoiceLineNumber, InvoiceSerialLineNumber, InvoiceSerialNumber, InvoiceShipmentNumber, SerialNumberCost, SerialNumberQuantity) values (@InvoiceNumber, @InvoiceLineNumber, @InvoiceSerialLineNumber, @InvoiceSerialNumber, @InvoiceShipmentNumber, @SerialNumberCost, @SerialNumberQuantity)", con)

                                With cmd.Parameters
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceNumber
                                    .Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceLine
                                    .Add("@InvoiceSerialLineNumber", SqlDbType.VarChar).Value = NextSerialLineNumber
                                    .Add("@InvoiceShipmentNumber", SqlDbType.VarChar).Value = 0
                                    .Add("@InvoiceSerialNumber", SqlDbType.VarChar).Value = SerialNumber
                                    .Add("@SerialNumberCost", SqlDbType.VarChar).Value = SerialCost
                                    .Add("@SerialNumberQuantity", SqlDbType.VarChar).Value = 1
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempInvoiceNumber As Integer = 0
                                Dim strInvoiceNumber As String
                                TempInvoiceNumber = GlobalAssemblyInvoiceNumber
                                strInvoiceNumber = CStr(TempInvoiceNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = GlobalDivisionCode
                                ErrorDescription = "Enter Serial # Popup --- Insert Invoice Serial Line"
                                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber + " Serial# - " + SerialNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()

                                Exit Sub
                            End Try
                            '***********************************************************************************
                            'Update Serial Log
                            cmd = New SqlCommand("INSERT INTO AssemblySerialTempTable (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, BuildNumber, CustomerID, BatchNumber, TransactionNumber, ShipmentNumber, ShipmentDate, InvoiceNumber, InvoiceDate) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @BuildNumber, @CustomerID, @BatchNumber, @TransactionNumber, @ShipmentNumber, @ShipmentDate, @InvoiceNumber, @InvoiceDate)", con)

                            With cmd.Parameters
                                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                                .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                                .Add("@TotalCost", SqlDbType.VarChar).Value = SerialCost
                                .Add("@Comment", SqlDbType.VarChar).Value = Comment
                                .Add("@BuildDate", SqlDbType.VarChar).Value = BuildDate
                                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@BuildNumber", SqlDbType.VarChar).Value = BuildNumber
                                .Add("@CustomerID", SqlDbType.VarChar).Value = GlobalAssemblyCustomer
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceLine
                                .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                .Add("@ShipmentDate", SqlDbType.VarChar).Value = ShipDate
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceNumber
                                .Add("@InvoiceDate", SqlDbType.VarChar).Value = Today()
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Next
                    '*********************************************************************************************************
                    'Update InvoiceLine with total cost
                    Dim SumSerialCost As Double = 0

                    Dim SumSerialCostStatement As String = "SELECT SUM(SerialNumberCost) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber AND InvoiceLineNumber = @InvoiceLineNumber"
                    Dim SumSerialCostCommand As New SqlCommand(SumSerialCostStatement, con)
                    SumSerialCostCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceNumber
                    SumSerialCostCommand.Parameters.Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceLine

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SumSerialCost = CDbl(SumSerialCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        SumSerialCost = 0
                    End Try
                    con.Close()

                    'Update Line Table
                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET ExtendedCOS = @ExtendedCOS WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceNumber
                        .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = GlobalAssemblyInvoiceLine
                        .Add("@ExtendedCOS", SqlDbType.VarChar).Value = SumSerialCost
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*********************************************************************************************************
                    MsgBox("Serial Numbers added.", MsgBoxStyle.OkOnly)

                    GlobalSerialValidation = "YES"
                    Me.Close()
                Else
                    GlobalSerialValidation = "NO"
                    MsgBox("The number selected has to match the invoice quantity.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '---------------------------------------------------------------------------------------
            Case "INVENTORYADJUSTMENT"
                'Initialize variables
                Dim Counter As Integer = 0
                GlobalSumSerialCost = 0
                Dim QuantityString As String = ""

                If GlobalSerialAssemblyQuantity < 0 Then
                    QuantityString = "NEGATIVE"
                    GlobalSerialAssemblyQuantity = GlobalSerialAssemblyQuantity * -1
                Else
                    QuantityString = "POSITIVE"
                End If

                'If checkbox is not selected - continue
                For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                    Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                    If cell.Value = "SELECTED" Then
                        Counter = Counter + 1
                    End If
                Next
                '*******************************************************************************************
                If Counter = GlobalSerialAssemblyQuantity Then
                    Dim SerialNumber As String = ""
                    Dim AssemblyPartNumber As String = ""
                    Dim DivisionID As String = ""
                    Dim TotalCost As Double = 0
                    Dim BuildDate As String = ""
                    Dim BuildNumber As Integer = 0
                    Dim CustomerID As String = ""
                    Dim BatchNumber As Integer = 0
                    Dim RowStatus As String = ""
                    Dim ShipmentNumber As Integer = 0
                    Dim ShipDate As String = ""
                    Dim InvoiceNumber As Integer = 0
                    Dim InvoiceDate As String = ""

                    For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                        Dim cell2 As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                        If cell2.Value = "SELECTED" Then
                            'Update Serial Log with a batch number to pull back into the Build Form
                            Try
                                AssemblyPartNumber = row.Cells("AssemblyPartNumberColumn").Value
                            Catch ex As Exception
                                AssemblyPartNumber = ""
                            End Try
                            Try
                                SerialNumber = row.Cells("SerialNumberColumn").Value
                            Catch ex As Exception
                                SerialNumber = ""
                            End Try
                            Try
                                TotalCost = row.Cells("TotalCostColumn").Value
                            Catch ex As Exception
                                TotalCost = 0
                            End Try
                            Try
                                BuildDate = row.Cells("BuildDateColumn").Value
                            Catch ex As Exception
                                BuildDate = ""
                            End Try
                            Try
                                BuildNumber = row.Cells("BuildNumberColumn").Value
                            Catch ex As Exception
                                BuildNumber = 0
                            End Try
                            Try
                                CustomerID = row.Cells("CustomerIDColumn").Value
                            Catch ex As Exception
                                CustomerID = ""
                            End Try
                            Try
                                ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                            Catch ex As Exception
                                ShipmentNumber = 0
                            End Try
                            Try
                                ShipDate = row.Cells("ShipmentDateColumn").Value
                            Catch ex As Exception
                                ShipDate = ""
                            End Try
                            Try
                                InvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                            Catch ex As Exception
                                InvoiceNumber = 0
                            End Try
                            Try
                                InvoiceDate = row.Cells("InvoiceDateColumn").Value
                            Catch ex As Exception
                                InvoiceDate = ""
                            End Try
                            '**********************************************************************************
                            If QuantityString = "NEGATIVE" Then
                                RowStatus = "CLOSED"
                            Else
                                RowStatus = "OPEN"
                            End If
                            '***********************************************************************************
                            cmd = New SqlCommand("INSERT INTO AssemblySerialTempTable (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, BuildNumber, CustomerID, BatchNumber, TransactionNumber, ShipmentNumber, ShipmentDate, InvoiceNumber, InvoiceDate) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @BuildNumber, @CustomerID, @BatchNumber, @TransactionNumber, @ShipmentNumber, @ShipmentDate, @InvoiceNumber, @InvoiceDate) ", con)

                            With cmd.Parameters
                                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                                .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                                .Add("@TotalCost", SqlDbType.VarChar).Value = TotalCost
                                .Add("@Comment", SqlDbType.VarChar).Value = "Inventory Adjustment"
                                .Add("@BuildDate", SqlDbType.VarChar).Value = BuildDate
                                .Add("@Status", SqlDbType.VarChar).Value = RowStatus
                                .Add("@BuildNumber", SqlDbType.VarChar).Value = BuildNumber
                                .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAssemblyBatchNumber
                                .Add("@TransactionNumber", SqlDbType.VarChar).Value = GlobalAssemblyTransactionNumber
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                .Add("@ShipmentDate", SqlDbType.VarChar).Value = ShipDate
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                            '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                            'Get Serial Cost if TWE
                            GlobalSumSerialCost = GlobalSumSerialCost + TotalCost

                            AssemblyPartNumber = ""
                            SerialNumber = ""
                            TotalCost = 0
                            BuildDate = ""
                            BuildNumber = 0
                            CustomerID = ""
                            BatchNumber = 0
                        End If
                    Next
                    '*********************************************************************************************************
                    MsgBox("Serial Numbers updated.", MsgBoxStyle.OkOnly)

                    GlobalSerialValidation = "YES"
                    GlobalSerialAssemblyQuantity = 0
                    GlobalAssemblyPartNumber = ""
                    GlobalAssemblyBatchNumber = 0
                    GlobalAssemblyTransactionNumber = 0

                    Me.Close()
                Else
                    MsgBox("The number selected has to be equal to the adjustment quantity.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '---------------------------------------------------------------------------------------
            Case "CUSTOMERRETURN"
                'Initialize variables
                Dim Counter As Integer = 0
                GlobalSumSerialCost = 0
                Dim TodaysDate As Date = Today()

                If chkAddNew.Checked = True And txtSerialNumber.Text <> "" Then
                    'Check if serial number already exists
                    Dim CheckSerialNumber As Integer = 0

                    Dim CheckSerialNumberStatement As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber"
                    Dim CheckSerialNumberCommand As New SqlCommand(CheckSerialNumberStatement, con)
                    CheckSerialNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber
                    CheckSerialNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckSerialNumber = CInt(CheckSerialNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckSerialNumber = 0
                    End Try
                    con.Close()

                    If CheckSerialNumber <> 0 Then
                        MsgBox("Serial # for the part already exists in the database and cannot be added.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    'Get Total Cost
                    Dim TotalCost As Double = 0

                    Dim GetTotalCostStatement As String = "SELECT TotalCost FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim GetTotalCostCommand As New SqlCommand(GetTotalCostStatement, con)
                    GetTotalCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber
                    GetTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TotalCost = CDbl(GetTotalCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        TotalCost = 0
                    End Try
                    con.Close()

                    'Add serial Number to assembly serial log
                    cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, BuildNumber, CustomerID, BatchNumber, TransactionNumber, ShipmentNumber, ShipmentDate, InvoiceNumber, InvoiceDate) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @BuildNumber, @CustomerID, @BatchNumber, @TransactionNumber, @ShipmentNumber, @ShipmentDate, @InvoiceNumber, @InvoiceDate) ", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtAssemblyPartNumber.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                        .Add("@TotalCost", SqlDbType.VarChar).Value = TotalCost
                        .Add("@Comment", SqlDbType.VarChar).Value = "Customer Return"
                        .Add("@BuildDate", SqlDbType.VarChar).Value = TodaysDate.ToShortDateString()
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                        .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAssemblyBatchNumber
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = GlobalAssemblyTransactionNumber
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                        .Add("@ShipmentDate", SqlDbType.VarChar).Value = ""
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = 0
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Insert Data into temp table
                    '**********************************************************************************
                    cmd = New SqlCommand("INSERT INTO AssemblySerialTempTable (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, BuildNumber, CustomerID, BatchNumber, TransactionNumber, ShipmentNumber, ShipmentDate, InvoiceNumber, InvoiceDate) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @BuildNumber, @CustomerID, @BatchNumber, @TransactionNumber, @ShipmentNumber, @ShipmentDate, @InvoiceNumber, @InvoiceDate) ", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtAssemblyPartNumber.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                        .Add("@TotalCost", SqlDbType.VarChar).Value = TotalCost
                        .Add("@Comment", SqlDbType.VarChar).Value = "Customer Return"
                        .Add("@BuildDate", SqlDbType.VarChar).Value = TodaysDate.ToShortDateString()
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                        .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAssemblyBatchNumber
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = GlobalAssemblyTransactionNumber
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                        .Add("@ShipmentDate", SqlDbType.VarChar).Value = ""
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = 0
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                    'Get Serial Cost if TWE
                    GlobalSumSerialCost = GlobalSumSerialCost + TotalCost

                    TotalCost = 0
                    '*********************************************************************************************************
                    MsgBox("Serial Number added.", MsgBoxStyle.OkOnly)

                    GlobalSerialValidation = "YES"
                    GlobalSerialAssemblyQuantity = 0
                    GlobalAssemblyPartNumber = ""
                    GlobalAssemblyBatchNumber = 0
                    GlobalAssemblyTransactionNumber = 0

                    Me.Close()
                Else
                    'Continue
                End If
                '*****************************************************************
                For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                    Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                    If cell.Value = "SELECTED" Then
                        Counter = Counter + 1
                    End If
                Next
                '*****************************************************************
                If Counter = GlobalSerialAssemblyQuantity Then
                    Dim SerialNumber As String = ""
                    Dim AssemblyPartNumber As String = ""
                    Dim TotalCost As Double = 0
                    Dim BuildDate As String = ""
                    Dim BuildNumber As Integer = 0
                    Dim CustomerID As String = ""
                    Dim BatchNumber As Integer = 0
                    Dim ShipmentNumber As Integer = 0
                    Dim ShipDate As String = ""
                    Dim InvoiceNumber As Integer = 0
                    Dim InvoiceDate As String = ""

                    For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                        Dim cell2 As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                        If cell2.Value = "SELECTED" Then
                            'Update Serial Log with a batch number to pull back into the Build Form
                            Try
                                AssemblyPartNumber = row.Cells("AssemblyPartNumberColumn").Value
                            Catch ex As Exception
                                AssemblyPartNumber = ""
                            End Try
                            Try
                                SerialNumber = row.Cells("SerialNumberColumn").Value
                            Catch ex As Exception
                                SerialNumber = ""
                            End Try
                            Try
                                TotalCost = row.Cells("TotalCostColumn").Value
                            Catch ex As Exception
                                TotalCost = 0
                            End Try
                            Try
                                BuildDate = row.Cells("BuildDateColumn").Value
                            Catch ex As Exception
                                BuildDate = ""
                            End Try
                            Try
                                BuildNumber = row.Cells("BuildNumberColumn").Value
                            Catch ex As Exception
                                BuildNumber = 0
                            End Try
                            Try
                                CustomerID = row.Cells("CustomerIDColumn").Value
                            Catch ex As Exception
                                CustomerID = ""
                            End Try
                            Try
                                ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                            Catch ex As Exception
                                ShipmentNumber = 0
                            End Try
                            Try
                                ShipDate = row.Cells("ShipmentDateColumn").Value
                            Catch ex As Exception
                                ShipDate = ""
                            End Try
                            Try
                                InvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                            Catch ex As Exception
                                InvoiceNumber = 0
                            End Try
                            Try
                                InvoiceDate = row.Cells("InvoiceDateColumn").Value
                            Catch ex As Exception
                                InvoiceDate = ""
                            End Try
                            '**********************************************************************************
                            cmd = New SqlCommand("INSERT INTO AssemblySerialTempTable (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, BuildNumber, CustomerID, BatchNumber, TransactionNumber, ShipmentNumber, ShipmentDate, InvoiceNumber, InvoiceDate) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @BuildNumber, @CustomerID, @BatchNumber, @TransactionNumber, @ShipmentNumber, @ShipmentDate, @InvoiceNumber, @InvoiceDate) ", con)

                            With cmd.Parameters
                                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                                .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                                .Add("@TotalCost", SqlDbType.VarChar).Value = TotalCost
                                .Add("@Comment", SqlDbType.VarChar).Value = "Customer Return"
                                .Add("@BuildDate", SqlDbType.VarChar).Value = BuildDate
                                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@BuildNumber", SqlDbType.VarChar).Value = BuildNumber
                                .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAssemblyBatchNumber
                                .Add("@TransactionNumber", SqlDbType.VarChar).Value = GlobalAssemblyTransactionNumber
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                .Add("@ShipmentDate", SqlDbType.VarChar).Value = ShipDate
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                            '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                            'Get Serial Cost if TWE
                            GlobalSumSerialCost = GlobalSumSerialCost + TotalCost

                            AssemblyPartNumber = ""
                            SerialNumber = ""
                            TotalCost = 0
                            BuildDate = ""
                            BuildNumber = 0
                            CustomerID = ""
                        End If
                    Next
                    '*********************************************************************************************************
                    MsgBox("Serial Numbers updated.", MsgBoxStyle.OkOnly)

                    GlobalSerialValidation = "YES"
                    GlobalSerialAssemblyQuantity = 0
                    GlobalAssemblyPartNumber = ""
                    GlobalAssemblyBatchNumber = 0
                    GlobalAssemblyTransactionNumber = 0

                    Me.Close()
                Else
                    MsgBox("The number selected has to be equal to the return quantity.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '---------------------------------------------------------------------------------------
            Case "VENDORRETURN"
                'Initialize variables
                Dim Counter As Integer = 0
                GlobalSumSerialCost = 0

                For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                    Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                    If cell.Value = "SELECTED" Then
                        Counter = Counter + 1
                    End If
                Next
                '*****************************************************************
                If Counter = GlobalSerialAssemblyQuantity Then
                    Dim SerialNumber As String = ""
                    Dim AssemblyPartNumber As String = ""
                    Dim TotalCost As Double = 0
                    Dim BuildDate As String = ""
                    Dim BuildNumber As Integer = 0
                    Dim CustomerID As String = ""
                    Dim BatchNumber As Integer = 0
                    Dim ShipmentNumber As Integer = 0
                    Dim ShipDate As String = ""
                    Dim InvoiceNumber As Integer = 0
                    Dim InvoiceDate As String = ""

                    For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                        Dim cell2 As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                        If cell2.Value = "SELECTED" Then
                            'Update Serial Log with a batch number to pull back into the Build Form
                            Try
                                AssemblyPartNumber = row.Cells("AssemblyPartNumberColumn").Value
                            Catch ex As Exception
                                AssemblyPartNumber = ""
                            End Try
                            Try
                                SerialNumber = row.Cells("SerialNumberColumn").Value
                            Catch ex As Exception
                                SerialNumber = ""
                            End Try
                            Try
                                TotalCost = row.Cells("TotalCostColumn").Value
                            Catch ex As Exception
                                TotalCost = 0
                            End Try
                            Try
                                BuildDate = row.Cells("BuildDateColumn").Value
                            Catch ex As Exception
                                BuildDate = ""
                            End Try
                            Try
                                BuildNumber = row.Cells("BuildNumberColumn").Value
                            Catch ex As Exception
                                BuildNumber = 0
                            End Try
                            Try
                                CustomerID = row.Cells("CustomerIDColumn").Value
                            Catch ex As Exception
                                CustomerID = ""
                            End Try
                            Try
                                ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                            Catch ex As Exception
                                ShipmentNumber = 0
                            End Try
                            Try
                                ShipDate = row.Cells("ShipmentDateColumn").Value
                            Catch ex As Exception
                                ShipDate = ""
                            End Try
                            Try
                                InvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                            Catch ex As Exception
                                InvoiceNumber = 0
                            End Try
                            Try
                                InvoiceDate = row.Cells("InvoiceDateColumn").Value
                            Catch ex As Exception
                                InvoiceDate = ""
                            End Try
                            '**********************************************************************************
                            cmd = New SqlCommand("INSERT INTO AssemblySerialTempTable (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, BuildNumber, CustomerID, BatchNumber, TransactionNumber, ShipmentNumber, ShipmentDate, InvoiceNumber, InvoiceDate) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @BuildNumber, @CustomerID, @BatchNumber, @TransactionNumber, @ShipmentNumber, @ShipmentDate, @InvoiceNumber, @InvoiceDate) ", con)

                            With cmd.Parameters
                                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                                .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                                .Add("@TotalCost", SqlDbType.VarChar).Value = TotalCost
                                .Add("@Comment", SqlDbType.VarChar).Value = "Vendor Return"
                                .Add("@BuildDate", SqlDbType.VarChar).Value = BuildDate
                                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@BuildNumber", SqlDbType.VarChar).Value = BuildNumber
                                .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAssemblyBatchNumber
                                .Add("@TransactionNumber", SqlDbType.VarChar).Value = GlobalAssemblyTransactionNumber
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                .Add("@ShipmentDate", SqlDbType.VarChar).Value = ShipDate
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                                .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                            '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                            'Get Serial Cost if TWE
                            GlobalSumSerialCost = GlobalSumSerialCost + TotalCost

                            AssemblyPartNumber = ""
                            SerialNumber = ""
                            TotalCost = 0
                            BuildDate = ""
                            BuildNumber = 0
                            CustomerID = ""
                        End If
                    Next
                    '*********************************************************************************************************
                    MsgBox("Serial Numbers updated.", MsgBoxStyle.OkOnly)

                    GlobalSerialValidation = "YES"
                    GlobalSerialAssemblyQuantity = 0
                    GlobalAssemblyPartNumber = ""
                    GlobalAssemblyBatchNumber = 0
                    GlobalAssemblyTransactionNumber = 0

                    Me.Close()
                Else
                    MsgBox("The number selected has to be equal to the return quantity.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case "ADDBUILDS"
                Dim SerialNumber As String = ""
                Dim AssemblyPartNumber As String = ""

                For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                    Dim cell2 As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                    If cell2.Value = "SELECTED" Then
                        'Update Serial Log with a batch number to pull back into the Build Form
                        Try
                            AssemblyPartNumber = row.Cells("AssemblyPartNumberColumn").Value
                        Catch ex As Exception
                            AssemblyPartNumber = ""
                        End Try
                        Try
                            SerialNumber = row.Cells("SerialNumberColumn").Value
                        Catch ex As Exception
                            SerialNumber = ""
                        End Try
                        '**********************************************************************************
                        'Get oldest build number w/o a serial number to assign
                        Dim MinTransactionNumber As Integer = 0
                        Dim TotalBuildCost As Double = 0
                        Dim BuildDate As String = ""
                        Dim BuildComment As String = ""

                        Dim MinTransactionNumberStatement As String = "SELECT MIN(BuildTransactionNumber) FROM AssemblyBuildHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID"
                        Dim MinTransactionNumberCommand As New SqlCommand(MinTransactionNumberStatement, con)
                        MinTransactionNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber
                        MinTransactionNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                        MinTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MinTransactionNumber = CInt(MinTransactionNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            MinTransactionNumber = 0
                        End Try
                        con.Close()
                        '*********************************************************************************
                        If MinTransactionNumber = 0 Then
                            MsgBox("There are no builds without a serial # for this part.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                        '*********************************************************************************
                        Dim TotalBuildCostStatement As String = "SELECT BuildCost FROM AssemblyBuildHeaderTable WHERE BuildTransactionNumber = @BuildTransactionNumber"
                        Dim TotalBuildCostCommand As New SqlCommand(TotalBuildCostStatement, con)
                        TotalBuildCostCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = MinTransactionNumber

                        Dim BuildDateStatement As String = "SELECT BuildDate FROM AssemblyBuildHeaderTable WHERE BuildTransactionNumber = @BuildTransactionNumber"
                        Dim BuildDateCommand As New SqlCommand(BuildDateStatement, con)
                        BuildDateCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = MinTransactionNumber

                        Dim BuildCommentStatement As String = "SELECT BuildComment FROM AssemblyBuildHeaderTable WHERE BuildTransactionNumber = @BuildTransactionNumber"
                        Dim BuildCommentCommand As New SqlCommand(BuildCommentStatement, con)
                        BuildCommentCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = MinTransactionNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TotalBuildCost = CDbl(TotalBuildCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            TotalBuildCost = 0
                        End Try
                        Try
                            BuildDate = CStr(BuildDateCommand.ExecuteScalar)
                        Catch ex As Exception
                            BuildDate = ""
                        End Try
                        Try
                            BuildComment = CStr(BuildCommentCommand.ExecuteScalar)
                        Catch ex As Exception
                            BuildComment = ""
                        End Try
                        con.Close()
                        '**********************************************************************************
                        'Update Serial Log
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET TotalCost = @TotalCost, BuildDate = @BuildDate, BuildNumber = @BuildNumber, Status = @Status WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                            .Add("@TotalCost", SqlDbType.VarChar).Value = TotalBuildCost
                            .Add("@Comment", SqlDbType.VarChar).Value = BuildComment
                            .Add("@BuildDate", SqlDbType.VarChar).Value = BuildDate
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = MinTransactionNumber
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '**********************************************************************************
                        'Update Build Header Table with serial number
                        cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET SerialNumber = @SerialNumber WHERE BuildTransactionNumber = @BuildTransactionNumber", con)

                        With cmd.Parameters
                            .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = MinTransactionNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '**********************************************************************************
                        'Clear Variables
                        AssemblyPartNumber = ""
                        SerialNumber = ""
                        TotalBuildCost = 0
                        BuildDate = ""
                        MinTransactionNumber = 0
                    End If
                Next
                '*********************************************************************************************************
                MsgBox("Serial Numbers updated.", MsgBoxStyle.OkOnly)

                GlobalSerialValidation = "YES"
                GlobalSerialAssemblyQuantity = 0
                GlobalAssemblyPartNumber = ""
                GlobalAssemblyBatchNumber = 0
                GlobalAssemblyTransactionNumber = 0

                Me.Close()
            Case Else
                MsgBox("Invalid data. Close form and try again.", MsgBoxStyle.OkOnly)
                Exit Sub
        End Select
    End Sub

    Private Sub chkAddNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddNew.CheckedChanged
        If chkAddNew.Checked = True Then
            txtSerialNumber.Enabled = True
        Else
            txtSerialNumber.Enabled = False
        End If
    End Sub

    Private Sub txtTextSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTextSearch.TextChanged
        If GlobalSerialFormLocation = "CUSTOMERRETURN" Then
            If txtTextSearch.Text = "" Then
                cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND Status <> @Status", con)
                cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "AssemblySerialLog")
                dgvTempSerialLog.DataSource = ds.Tables("AssemblySerialLog")
                con.Close()
            Else
                Dim TextSearch As String = ""

                TextSearch = " AND SerialNumber LIKE '" + txtTextSearch.Text + "%'"

                cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND Status <> @Status" + TextSearch, con)
                cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "AssemblySerialLog")
                dgvTempSerialLog.DataSource = ds.Tables("AssemblySerialLog")
                con.Close()
            End If
        Else
            'Do nothing
        End If
    End Sub
End Class