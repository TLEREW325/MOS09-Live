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
Imports System.ComponentModel
Imports WIA
Imports iTextSharp
Public Class QCShipmentDockChecks
    Inherits System.Windows.Forms.Form

    Dim Approval As String = ""
    Dim DocumentFilename As String = ""
    Dim strShipmentNumber As String
    Dim intShipmentNumber As Integer = 0
    Dim ShipmentNumber As Integer = 0

    Dim PTUpload As PickTicketScannerUploadAPI

    'Scanner Variables
    Dim FilesToDelete As List(Of String)

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim CustomerID As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub QCShipmentDockChecks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        cboDivisionID.Text = EmployeeCompanyCode

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        PTUpload = New PickTicketScannerUploadAPI(cmdScanDocs, txtShipmentNumber, ReUploadPickTicketToolStripMenuItem, Me, AppendPickTicketToolStripMenuItem)
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

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM QCShipmentAudit WHERE DivisionID = @DivisionID ORDER BY ShipDate DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "QCShipmentAudit")
        dgvQCShipments.DataSource = ds.Tables("QCShipmentAudit")
        con.Close()
    End Sub

    Public Sub ShowDataByCustomer()
        If cboCustomerID.Text = "" Then
            Dim RowCustomer As String = ""

            If Me.dgvQCShipments.RowCount > 0 Then
                Dim RowIndex As Integer = Me.dgvQCShipments.CurrentCell.RowIndex

                Try
                    RowCustomer = Me.dgvQCShipments.Rows(RowIndex).Cells("CustomerColumn").Value
                Catch ex As Exception
                    RowCustomer = ""
                End Try

                CustomerID = RowCustomer
            Else
                CustomerID = ""
            End If
        Else
            CustomerID = cboCustomerID.Text
        End If

            cmd = New SqlCommand("SELECT * FROM QCShipmentAudit WHERE DivisionID = @DivisionID AND Customer = @Customer ORDER BY ShipDate DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@Customer", SqlDbType.VarChar).Value = CustomerID
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "QCShipmentAudit")
            dgvQCShipments.DataSource = ds.Tables("QCShipmentAudit")
            con.Close()
    End Sub

    Public Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerName.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadPickTicket()
        cmd = New SqlCommand("SELECT PickListHeaderKey FROM PickListHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "PickListHeaderTable")
        cboPickTicket.DataSource = ds4.Tables("PickListHeaderTable")
        con.Close()
        cboPickTicket.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub LoadAuditData()
        'Declare Shipment Variables
        Dim ShipmentNumber, SalesOrderNumber As Integer
        Dim ShipVia As String = ""
        Dim ShipmentBoxes, ShipmentPallets As Integer
        Dim ShipDate As Date

        'Get data from shipment header table
        Dim GetAuditDataStatement As String = "SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND PickTicketNumber = @PickTicketNumber"
        Dim GetAuditDataCommand As New SqlCommand(GetAuditDataStatement, con)
        GetAuditDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetAuditDataCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicket.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetAuditDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShipmentNumber")) Then
                ShipmentNumber = 0
            Else
                ShipmentNumber = reader.Item("ShipmentNumber")
            End If
            If IsDBNull(reader.Item("SalesOrderKey")) Then
                SalesOrderNumber = 0
            Else
                SalesOrderNumber = reader.Item("SalesOrderKey")
            End If
            If IsDBNull(reader.Item("ShipVia")) Then
                ShipVia = ""
            Else
                ShipVia = reader.Item("ShipVia")
            End If
            If IsDBNull(reader.Item("NumberOfPallets")) Then
                ShipmentPallets = 0
            Else
                ShipmentPallets = reader.Item("NumberOfPallets")
            End If
            If IsDBNull(reader.Item("ShipDate")) Then
                ShipDate = Today()
            Else
                ShipDate = reader.Item("ShipDate")
            End If
        Else
            ShipmentNumber = 0
            SalesOrderNumber = 0
            ShipVia = ""
            ShipmentPallets = 0
            ShipDate = Today()
        End If
        reader.Close()
        con.Close()

        'Format Date
        ShipDate = ShipDate.ToShortDateString()

        Dim GetBoxesStatement As String = "SELECT SUM(LineBoxes) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim GetBoxesCommand As New SqlCommand(GetBoxesStatement, con)
        GetBoxesCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
        GetBoxesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipmentBoxes = CInt(GetBoxesCommand.ExecuteScalar)
        Catch ex As Exception
            ShipmentBoxes = 0
        End Try
        con.Close()

        'Fill Text Fields
        txtBoxCount.Text = ShipmentBoxes
        txtPalletCount.Text = ShipmentPallets
        txtSalesOrderNumber.Text = SalesOrderNumber
        txtShipmentNumber.Text = ShipmentNumber
        txtShipVia.Text = ShipVia
        txtShipDate.Text = ShipDate
    End Sub

    Public Sub ClearData()
        cboPickTicket.Text = ""
        cboPickTicket.SelectedIndex = -1

        txtBoxCount.Clear()
        txtPalletCount.Clear()
        txtQCComments.Clear()
        txtQCInspector.Clear()
        txtSalesOrderNumber.Clear()
        txtShipDate.Clear()
        txtShipmentNumber.Clear()
        txtShipVia.Clear()

        chkFail.Checked = False
        chkPass.Checked = False

        cboPickTicket.Focus()
    End Sub

    Public Sub ClearVariables()
        Approval = ""
        DocumentFilename = ""
        strShipmentNumber = ""
        intShipmentNumber = 0
    End Sub

    Public Sub ValidateFields()
        If cboCustomerID.Text = "" Then
            MsgBox("You must have a valid customer.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboPickTicket.Text = "" Then
            MsgBox("You must have a valid Pick #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtBoxCount.Text = "" Then
            MsgBox("You must enter a box count.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtPalletCount.Text = "" Then
            MsgBox("You must enter a pallet count.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtQCInspector.Text = "" Then
            MsgBox("You must enter the QC Agent's name.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtSalesOrderNumber.Text = "" Then
            MsgBox("You must have a valid SO #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtShipmentNumber.Text = "" Then
            MsgBox("You must have a valid Ship. #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtShipVia.Text = "" Then
            MsgBox("You must have a valid shipper.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If chkFail.Checked = False And chkPass.Checked = False Then
            MsgBox("You must select pass or fail.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            If chkPass.Checked = True And chkFail.Checked = False Then
                Approval = "PASS"
            Else
                Approval = "FAIL"
            End If
        End If
    End Sub

    Public Sub InsertUpdateSaveCommand()
        'Check Fields for valid data
        ValidateFields()

        'Create filename for scanned file
        intShipmentNumber = Val(txtShipmentNumber.Text)
        strShipmentNumber = CStr(intShipmentNumber)

        DocumentFilename = strShipmentNumber + ".pdf"

        Try
            'UPDATE Invoice Header Table
            cmd = New SqlCommand("INSERT INTO QCShipmentAudit (ShipmentNumber, PickTicketNumber, SalesOrderNumber, Customer, ShipVia, ShipDate, QCInspector, Comment, NumberOfBoxes, NumberOfPallets, ScannedDocument, Approved, DivisionID) values (@ShipmentNumber, @PickTicketNumber, @SalesOrderNumber, @Customer, @ShipVia, @ShipDate, @QCInspector, @Comment, @NumberOfBoxes, @NumberOfPallets, @ScannedDocument, @Approved, @DivisionID)", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                .Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicket.Text)
                .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                .Add("@Customer", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@ShipVia", SqlDbType.VarChar).Value = txtShipVia.Text
                .Add("@ShipDate", SqlDbType.VarChar).Value = txtShipDate.Text
                .Add("@QCInspector", SqlDbType.VarChar).Value = txtQCInspector.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtQCComments.Text
                .Add("@NumberOfBoxes", SqlDbType.VarChar).Value = Val(txtBoxCount.Text)
                .Add("@NumberOfPallets", SqlDbType.VarChar).Value = Val(txtPalletCount.Text)
                .Add("@ScannedDocument", SqlDbType.VarChar).Value = DocumentFilename
                .Add("@Approved", SqlDbType.VarChar).Value = Approval
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'If Insert fails, write error message to database
            'Log error on update failure
            Dim TempPickNumber As Integer = 0
            Dim strPickNumber As String
            TempPickNumber = Val(cboPickTicket.Text)
            strPickNumber = CStr(TempPickNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "QC Shipping Audit - Add New"
            ErrorReferenceNumber = "Pick # " + strPickNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        ClearData()
        ShowDataByCustomer()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvQCShipments.DataSource = Nothing
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerID()
        LoadCustomerName()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadPickTicket()
        LoadCustomerNameByID()
    End Sub

    Private Sub cboPickTicket_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPickTicket.SelectedIndexChanged
        LoadAuditData()
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        InsertUpdateSaveCommand()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub chkPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPass.CheckedChanged
        If chkPass.Checked = True Then
            chkFail.Checked = False
        End If
    End Sub

    Private Sub chkFail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFail.CheckedChanged
        If chkFail.Checked = True Then
            chkPass.Checked = False
        End If
    End Sub

    Private Sub cmdViewsDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewsDocs.Click
        Dim LineFileName As String = ""
        Dim intShipmentNumber As Integer = 0
        Dim strShipmentNumber As String = ""

        If Me.dgvQCShipments.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvQCShipments.CurrentCell.RowIndex

            Try
                intShipmentNumber = Me.dgvQCShipments.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                intShipmentNumber = 0
            End Try

            If intShipmentNumber = 0 Then
                MsgBox("Failure - Contact System Admin.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            strShipmentNumber = CStr(intShipmentNumber)
            LineFileName = strShipmentNumber + ".pdf"

            'Check if file exists
            If Not System.IO.File.Exists("\\TFP-FS\TransferData\UploadedPickTickets\" + LineFileName) Then
                MsgBox("Pick ticket has not been uploaded.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Dim psi As New ProcessStartInfo

            psi.UseShellExecute = True
            psi.Verb = "Open"
            psi.WindowStyle = ProcessWindowStyle.Normal
            psi.CreateNoWindow = False
            'psi.Arguments = PrintDialog1.PrinterSettings.PrinterName.ToString()
            psi.FileName = "\\TFP-FS\TransferData\UploadedPickTickets\" + LineFileName  ' Here specify a document to be printed
            Process.Start(psi)
        End If
    End Sub

    Private Sub cmdScanDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScanDocs.Click
        GlobalShipmentNumber = 888555
        ShipmentNumber = GlobalShipmentNumber


    End Sub

    'Private Sub ScanPages(Optional ByVal newPDF As Boolean = True)
    '    Dim mgr As New DeviceManager
    '    Dim Scanner As WIA.Device = Nothing
    '    If mgr.DeviceInfos.Count > 1 Then
    '        ''More than 1 scanner was detected
    '        Dim lst As New List(Of Integer)
    '        ''Finds all the USB scanners
    '        For i As Integer = 1 To mgr.DeviceInfos.Count()
    '            If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
    '                lst.Add(i)
    '            End If
    '        Next
    '        ''Check to see how many usb scanners were found
    '        If lst.Count > 1 Or lst.Count = 0 Then
    '            Dim selectScanner As New WIA.CommonDialog
    '            Scanner = selectScanner.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, True, False)
    '        Else
    '            Scanner = mgr.DeviceInfos(lst(0)).Connect()
    '        End If
    '    ElseIf mgr.DeviceInfos.Count = 0 Then
    '        ''No scanners were detected
    '        If My.Computer.Name.ToString.StartsWith("TFP") Then
    '            'Skip
    '            MsgBox("No scanner found", MsgBoxStyle.OkOnly)
    '        Else
    '            ''No scanners were detected
    '            MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '    Else
    '        ''Only 1 scanner is connected
    '        Scanner = mgr.DeviceInfos(1).Connect()
    '    End If

    '    If Scanner IsNot Nothing Then
    '        Dim item As WIA.Item = Scanner.Items(1)
    '        Dim obj As Object
    '        Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
    '        ''Specific scanning properties
    '        For Each prop As WIA.Property In Scanner.Items(1).Properties
    '            Dim x As WIA.IProperty = prop
    '            Select Case prop.PropertyID
    '                Case "6146" ''Current Intent No clue what this does, but it needs to be 0
    '                    obj = 0
    '                    x.let_Value(obj)
    '                Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
    '                    obj = 2
    '                    x.let_Value(obj)
    '                Case "6147" ''(DPI) Horizontal Resolution
    '                    obj = 200
    '                    x.let_Value(obj)
    '                Case "6148" ''(DPI) Vertical Resolution
    '                    obj = 200
    '                    x.let_Value(obj)
    '                Case "6151" ''horizontal extent (width)
    '                    obj = 1700
    '                    x.let_Value(obj)
    '                Case "6152" ''vertical extent (height)
    '                    obj = 2338
    '                    x.let_Value(obj)
    '            End Select
    '        Next

    '        Dim dial As New WIA.CommonDialog
    '        Dim hasMorePages As Boolean = True
    '        Dim ScannedAtleastOnePage As Boolean = False
    '        Dim pages As Integer = 0
    '        Dim ScannedImages As New List(Of Image)
    '        FilesToDelete = New List(Of String)

    '        ''Loops untill all pages are scanned.
    '        While hasMorePages
    '            pages += 1
    '            Try
    '                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
    '                Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + Now.ToShortDateString.Replace("/", "-") + " " + Now.ToShortTimeString.Replace(":", "") + " " + pages.ToString + ".jpg"
    '                Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatJPEG, False)
    '                Img.SaveFile(tmp)
    '                ScannedImages.Add(Image.FromFile(tmp))
    '                ScannedAtleastOnePage = True
    '                FilesToDelete.Add(tmp)
    '            Catch ex As System.Exception
    '                ''Looks for paper empty error to break the loop and/or to show error message
    '                If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
    '                    If Not ScannedAtleastOnePage Then
    '                        MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                    hasMorePages = False
    '                Else
    '                    If Not ScannedAtleastOnePage Then
    '                        'sendErrorToDataBase("PickTicketScannerUploadAPI - ScanPages --Error trying to scan pages.", "User: " + EmployeeLoginName, ex.ToString())
    '                        MessageBox.Show("There was an issue scanning the pages.", "Unable to scan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    End If
    '                    hasMorePages = False
    '                End If
    '            End Try
    '        End While

    '        'CreateFile()
    '        'CompleteScan()

    '    End If
    'End Sub

    'Public Sub CreateFile(ByVal sender As System.Object, ByVal e As System.EventHandler)
    '    Dim images As List(Of Image) = CType(e.Argument, List(Of Image))
    '    Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
    '    iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream("\\TFP-FS\TransferData\UploadedPickTickets\" + "8675-309" + ".pdf", IO.FileMode.Create)).SetFullCompression()
    '    doc.Open()
    '    ''Adds images to the pdf
    '    For Each img As Image In images
    '        Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
    '        iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
    '        doc.Add(iImage)
    '        doc.Add(New iTextSharp.text.Paragraph())
    '    Next
    '    doc.Close()
    '    e.Result = images
    'End Sub

    'Public Sub CompleteScan(ByVal sender As System.Object, ByVal e As System.EventHandler)
    '    Dim images As List(Of Image) = CType(e.Result, List(Of Image))
    '    Dim TotalPages As Integer = images.Count
    '    While images.Count > 0
    '        images(0).Dispose()
    '        images.RemoveAt(0)
    '    End While
    '    If FilesToDelete IsNot Nothing AndAlso FilesToDelete.Count > 0 Then
    '        For Each filename As String In FilesToDelete
    '            System.IO.File.Delete(filename)
    '        Next
    '    End If

    '    MessageBox.Show("Pick ticket uploaded with " + TotalPages.ToString + " pages.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    'End Sub

    Private Sub dgvQCShipments_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQCShipments.CellValueChanged
        If Me.dgvQCShipments.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvQCShipments.CurrentCell.RowIndex
            Dim RowShipmentNumber, RowPickTicketNumber, RowSONumber As Integer
            Dim RowCustomer, RowShipVia, RowComments, RowQCAgent As String
            Dim RowBoxes, RowPallets As Integer

            Try
                RowShipmentNumber = Me.dgvQCShipments.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                RowShipmentNumber = 0
            End Try
            Try
                RowPickTicketNumber = Me.dgvQCShipments.Rows(RowIndex).Cells("PickTicketNumberColumn").Value
            Catch ex As Exception
                RowPickTicketNumber = 0
            End Try
            Try
                RowSONumber = Me.dgvQCShipments.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
            Catch ex As Exception
                RowSONumber = 0
            End Try
            Try
                RowCustomer = Me.dgvQCShipments.Rows(RowIndex).Cells("CustomerColumn").Value
            Catch ex As Exception
                RowCustomer = ""
            End Try
            Try
                RowShipVia = Me.dgvQCShipments.Rows(RowIndex).Cells("ShipViaColumn").Value
            Catch ex As Exception
                RowShipVia = ""
            End Try
            Try
                RowComments = Me.dgvQCShipments.Rows(RowIndex).Cells("CommentColumn").Value
            Catch ex As Exception
                RowComments = ""
            End Try
            Try
                RowQCAgent = Me.dgvQCShipments.Rows(RowIndex).Cells("QCInspectorColumn").Value
            Catch ex As Exception
                RowQCAgent = ""
            End Try
            Try
                RowBoxes = Me.dgvQCShipments.Rows(RowIndex).Cells("NumberOfBoxesColumn").Value
            Catch ex As Exception
                RowBoxes = 0
            End Try
            Try
                RowPallets = Me.dgvQCShipments.Rows(RowIndex).Cells("NumberOfPalletsColumn").Value
            Catch ex As Exception
                RowPallets = 0
            End Try

            Try
                'UPDATE Invoice Header Table
                cmd = New SqlCommand("UPDATE QCShipmentAudit SET ShipVia = @ShipVia, QCInspector = @QCInspector, Comment = @Comment, NumberOfBoxes = @NumberOfBoxes, NumberOfPallets = @NumberOfPallets WHERE Customer = @Customer AND ShipmentNumber = @ShipmentNumber AND PickTicketNumber = @PickTicketNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                    .Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicket.Text)
                    .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    .Add("@Customer", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@ShipVia", SqlDbType.VarChar).Value = txtShipVia.Text
                    .Add("@ShipDate", SqlDbType.VarChar).Value = txtShipDate.Text
                    .Add("@QCInspector", SqlDbType.VarChar).Value = txtQCInspector.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtQCComments.Text
                    .Add("@NumberOfBoxes", SqlDbType.VarChar).Value = Val(txtBoxCount.Text)
                    .Add("@NumberOfPallets", SqlDbType.VarChar).Value = Val(txtPalletCount.Text)
                    .Add("@ScannedDocument", SqlDbType.VarChar).Value = DocumentFilename
                    .Add("@Approved", SqlDbType.VarChar).Value = Approval
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Data has been updated.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'If Insert fails, write error message to database
                'Log error on update failure
                Dim TempPickNumber As Integer = 0
                Dim strPickNumber As String
                TempPickNumber = Val(cboPickTicket.Text)
                strPickNumber = CStr(TempPickNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "QC Shipping Audit - Add New"
                ErrorReferenceNumber = "Pick # " + strPickNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Sub cmdViewByDivision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByDivision.Click
        ShowData()
    End Sub

    Private Sub cmdViewByCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByCustomer.Click
        ShowDataByCustomer()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim RowShipmentNumber As Integer = 0

        If Me.dgvQCShipments.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvQCShipments.CurrentCell.RowIndex

            Try
                RowShipmentNumber = Me.dgvQCShipments.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                RowShipmentNumber = 0
            End Try

            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this record?", "DELETE SHIPMENT DOCK CHECK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                cmd = New SqlCommand("DELETE FROM QCShipmentAudit WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            ElseIf button = DialogResult.No Then
                'Do nothing
                cmdViewByDivision.Focus()
            End If

            ShowData()
        End If
    End Sub

    Private Sub cmdPrintListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintListing.Click
        GDS = ds

        Using NewPrintQCShipmentAudit As New PrintQCShipmentAudit
            Dim result = NewPrintQCShipmentAudit.ShowDialog()
        End Using
    End Sub
End Class