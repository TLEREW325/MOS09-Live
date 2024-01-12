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
Public Class SteelReceivingByCoil
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim LastReceiverNumber, NextReceiverNumber As Integer
    Dim SUMSteelLineAmount As Double = 0
    Dim SUMSteelLineWeight As Double = 0
    Dim RecalcFreight, RecalcOther, RecalcSteelTotal As Double
    Dim TotalNumberOfCoils As Integer = 0

    Private Sub SteelReceivingByCoil_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        ClearSteelCoilLines()
    End Sub

    Private Sub SteelReceivingByCoil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "TFP" Then
            cboDivisionID.Text = "TWD"
            LoadSteelReceiverNumber()
            LoadSteelPONumber()
            LoadSteelBOLNumber()
            ClearVariables()
            ClearData()
        ElseIf EmployeeCompanyCode = "TWD" Then
            cboDivisionID.Text = "TWD"
            cboDivisionID.Text = "TWD"
            LoadSteelReceiverNumber()
            LoadSteelPONumber()
            LoadSteelBOLNumber()
            ClearVariables()
            ClearData()
        Else
            'Lock controls
        End If

        If GlobalSteelReceivingNumber = 0 Then
            'Do nothing
        Else
            cboSteelReceivingNumber.Text = GlobalSteelReceivingNumber
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

    Public Sub LoadSteelReceivingLines()
        cmd = New SqlCommand("SELECT * FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReceivingLineTable")
        dgvSteelReceivingLines.DataSource = ds.Tables("SteelReceivingLineTable")
        con.Close()

        If Me.dgvSteelReceivingLines.RowCount > 0 Then
            cboSteelBOLNumber.Enabled = False
            cboSteelPONumber.Enabled = False
            cmdSelectCoils.Enabled = False
            cboDeleteLineNumber.Enabled = True
            LoadLineNumbers()
        Else
            cboSteelBOLNumber.Enabled = True
            cboSteelPONumber.Enabled = True
            cmdSelectCoils.Enabled = True
            cboDeleteLineNumber.Enabled = False
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvSteelReceivingLines.DataSource = Nothing
    End Sub

    Public Sub LoadSteelReceiverNumber()
        cmd = New SqlCommand("SELECT SteelReceivingHeaderKey FROM SteelReceivingHeaderTable WHERE DivisionID = @DivisionID AND SteelVendor = @SteelVendor AND ReceivingStatus = @ReceivingStatus", con)
        cmd.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = "CHARTERSTEEL"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@ReceivingStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "SteelReceivingHeaderTable")
        cboSteelReceivingNumber.DataSource = ds1.Tables("SteelReceivingHeaderTable")
        con.Close()
        cboSteelReceivingNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelPONumber()
        cmd = New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID AND SteelVendorID = @SteelVendorID", con)
        cmd.Parameters.Add("@SteelVendorID", SqlDbType.VarChar).Value = "CHARTERSTEEL"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SteelPurchaseOrderHeader")
        cboSteelPONumber.DataSource = ds2.Tables("SteelPurchaseOrderHeader")
        con.Close()
        cboSteelPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelBOLNumber()
        cmd = New SqlCommand("SELECT DISTINCT (DespatchNumber) FROM CharterSteelCoilIdentification WHERE Status = @Status", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CharterSteelCoilIdentification")
        cboSteelBOLNumber.DataSource = ds3.Tables("CharterSteelCoilIdentification")
        con.Close()
        cboSteelBOLNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelCoilLines()
        cmd = New SqlCommand("SELECT * FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SteelReceivingCoilLines")
        dgvSteelCoils.DataSource = ds4.Tables("SteelReceivingCoilLines")
        con.Close()
    End Sub

    Public Sub ClearSteelCoilLines()
        Me.dgvSteelCoils.DataSource = Nothing
    End Sub

    Public Sub LoadLineNumbers()
        cmd = New SqlCommand("SELECT SteelReceivingLineKey FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "SteelReceivingLineTable")
        cboDeleteLineNumber.DataSource = ds5.Tables("SteelReceivingLineTable")
        con.Close()
        cboDeleteLineNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelReceivingData()
        Dim SteelVendor, SteelBOLNumber, Comment, ReceivingStatus, SteelReceivingDate As String
        Dim SteelTotalWeight, SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal As Double
        Dim SteelPONumber As Integer = 0

        Dim SteelReceivingDataString As String = "SELECT * FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim SteelReceivingDataCommand As New SqlCommand(SteelReceivingDataString, con)
        SteelReceivingDataCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
        SteelReceivingDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = SteelReceivingDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ReceivingDate")) Then
                SteelReceivingDate = Today()
            Else
                SteelReceivingDate = reader.Item("ReceivingDate")
            End If
            If IsDBNull(reader.Item("SteelVendor")) Then
                SteelVendor = ""
            Else
                SteelVendor = reader.Item("SteelVendor")
            End If
            If IsDBNull(reader.Item("SteelBOLNumber")) Then
                SteelBOLNumber = ""
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
                Comment = ""
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("ReceivingStatus")) Then
                ReceivingStatus = "OPEN"
            Else
                ReceivingStatus = reader.Item("ReceivingStatus")
            End If
            If IsDBNull(reader.Item("SteelPONumber")) Then
                SteelPONumber = 0
            Else
                SteelPONumber = reader.Item("SteelPONumber")
            End If
        Else
            SteelReceivingDate = Today()
            SteelVendor = ""
            SteelBOLNumber = ""
            SteelTotalWeight = 0
            SteelFreightCharges = 0
            SteelOtherCharges = 0
            SteelTotal = 0
            InvoiceTotal = 0
            Comment = ""
            ReceivingStatus = "OPEN"
            SteelPONumber = 0
        End If
        reader.Close()
        con.Close()

        cboSteelPONumber.Text = SteelPONumber
        dtpReceiverDate.Text = SteelReceivingDate
        txtSteelVendorID.Text = SteelVendor
        cboSteelBOLNumber.Text = SteelBOLNumber
        txtTotalShipmentWeight.Text = SteelTotalWeight
        txtFreightTotal.Text = SteelFreightCharges
        txtOtherTotal.Text = SteelOtherCharges
        lblSteelTotal.Text = FormatCurrency(SteelTotal, 2)
        lblInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtComment.Text = Comment
        txtStatus.Text = ReceivingStatus
    End Sub

    Public Sub UnlockForm()
        Try
            'Create command to unlock
            cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET Locked = '' WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID AND ReceivingStatus = @ReceivingStatus", con)

            With cmd.Parameters
                .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmdDelete.Enabled = True
            cmdPostReceiver.Enabled = True
            cmdSave.Enabled = True
            cmdSelectCoils.Enabled = True
            cmdDeleteLine.Enabled = True
        Catch ex As Exception
            'Continue
        End Try
    End Sub

    Public Sub LockControls()
        If cboSteelReceivingNumber.Text = "" Then
            cmdDelete.Enabled = True
            cmdPostReceiver.Enabled = True
            cmdSave.Enabled = True
            cmdSelectCoils.Enabled = True
            cmdDeleteLine.Enabled = True
        Else
            Dim CheckUser As String = ""

            Dim CheckUserString As String = "SELECT Locked FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID"
            Dim CheckUserCommand As New SqlCommand(CheckUserString, con)
            CheckUserCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
            CheckUserCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckUser = CStr(CheckUserCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckUser = ""
            End Try
            con.Close()

            If CheckUser = EmployeeLoginName Then
                cmdDelete.Enabled = True
                cmdPostReceiver.Enabled = True
                cmdSave.Enabled = True
                cmdDeleteLine.Enabled = True
                cmdSelectCoils.Enabled = True
            ElseIf CheckUser = "" Then
                cmdDelete.Enabled = True
                cmdPostReceiver.Enabled = True
                cmdSave.Enabled = True
                cmdSelectCoils.Enabled = True
                cmdDeleteLine.Enabled = True
            Else
                cmdDelete.Enabled = False
                cmdPostReceiver.Enabled = False
                cmdSave.Enabled = False
                cmdSelectCoils.Enabled = False
                cmdDeleteLine.Enabled = False
            End If
        End If
    End Sub

    Public Sub LoadSteelVendorFromPO()
        Dim SteelVendorFromPO As String = ""

        Dim SteelVendorIDString As String = "SELECT SteelVendorID FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey AND DivisionID = @DivisionID"
        Dim SteelVendorIDCommand As New SqlCommand(SteelVendorIDString, con)
        SteelVendorIDCommand.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
        SteelVendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelVendorFromPO = CStr(SteelVendorIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelVendorFromPO = ""
        End Try
        con.Close()

        txtSteelVendorID.Text = SteelVendorFromPO
    End Sub

    Public Sub LoadVendorName()
        Dim SteelVendorName As String = ""

        Dim SteelVendorNameString As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim SteelVendorNameCommand As New SqlCommand(SteelVendorNameString, con)
        SteelVendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = txtSteelVendorID.Text
        SteelVendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelVendorName = CStr(SteelVendorNameCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelVendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = SteelVendorName
    End Sub

    Public Sub LoadSteelReceivingTotals()
        'Calculate and load totals off line tables
        Dim SUMLineWeightString As String = "SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey"
        Dim SUMLineWeightCommand As New SqlCommand(SUMLineWeightString, con)
        SUMLineWeightCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)

        Dim SUMLineAmountString As String = "SELECT SUM(SteelExtendedCost) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey"
        Dim SUMLineAmountCommand As New SqlCommand(SUMLineAmountString, con)
        SUMLineAmountCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SUMSteelLineWeight = CDbl(SUMLineWeightCommand.ExecuteScalar)
        Catch ex As System.Exception
            SUMSteelLineWeight = 0
        End Try
        Try
            SUMSteelLineAmount = CDbl(SUMLineAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            SUMSteelLineAmount = 0
        End Try
        con.Close()

        RecalcFreight = Val(txtFreightTotal.Text)
        RecalcOther = Val(txtOtherTotal.Text)

        RecalcSteelTotal = SUMSteelLineAmount + RecalcFreight + RecalcOther
        RecalcSteelTotal = Math.Round(RecalcSteelTotal, 2)

        Dim SUMTotalCoilsString As String = "SELECT COUNT(SteelReceivingHeaderKey) FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey"
        Dim SUMTotalCoilsCommand As New SqlCommand(SUMTotalCoilsString, con)
        SUMTotalCoilsCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalNumberOfCoils = CInt(SUMTotalCoilsCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalNumberOfCoils = 0
        End Try
        con.Close()

        lblInvoiceTotal.Text = FormatCurrency(RecalcSteelTotal, 2)
        lblSteelTotal.Text = FormatCurrency(SUMSteelLineAmount, 2)
        txtTotalShipmentWeight.Text = FormatNumber(SUMSteelLineWeight, 0)
        txtCoilsInShipment.Text = FormatNumber(TotalNumberOfCoils, 0)
    End Sub

    Public Sub UpdateReceivingHeaderTable()
        'Load Totals First

        'Command to save
        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingDate = @ReceivingDate, SteelVendor = @SteelVendor, SteelBOLNumber = @SteelBOLNumber, SteelTotalWeight = @SteelTotalWeight, SteelFreightCharges = @SteelFreightCharges, SteelOtherCharges = @SteelOtherCharges, SteelTotal = @SteelTotal, InvoiceTotal = @InvoiceTotal, Comment = @Comment, ReceivingStatus = @ReceivingStatus, Locked = @Locked, SteelPONumber = @SteelPONumber WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ReceivingDate", SqlDbType.VarChar).Value = dtpReceiverDate.Text
            .Add("@SteelVendor", SqlDbType.VarChar).Value = txtSteelVendorID.Text
            .Add("@SteelBOLNumber", SqlDbType.VarChar).Value = cboSteelBOLNumber.Text
            .Add("@SteelTotalWeight", SqlDbType.VarChar).Value = SUMSteelLineWeight
            .Add("@SteelFreightCharges", SqlDbType.VarChar).Value = Val(txtFreightTotal.Text)
            .Add("@SteelOtherCharges", SqlDbType.VarChar).Value = Val(txtOtherTotal.Text)
            .Add("@SteelTotal", SqlDbType.VarChar).Value = SUMSteelLineAmount
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = RecalcSteelTotal
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@SteelPONumber", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
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

    Public Sub ClearData()
        cboSteelReceivingNumber.Text = ""
        cboSteelBOLNumber.Text = ""

        cboSteelBOLNumber.Refresh()
        cboSteelPONumber.Refresh()
        cboSteelReceivingNumber.Refresh()

        txtCoilsInShipment.Clear()
        txtComment.Clear()
        txtFreightTotal.Clear()
        txtOtherTotal.Clear()
        txtStatus.Clear()
        txtSteelVendorID.Clear()
        txtTotalShipmentWeight.Clear()
        txtVendorName.Clear()

        cboSteelBOLNumber.SelectedIndex = -1
        cboSteelPONumber.SelectedIndex = -1
        cboSteelReceivingNumber.SelectedIndex = -1

        lblInvoiceTotal.Text = ""
        lblSteelTotal.Text = ""

        cmdDelete.Enabled = True
        cmdPostReceiver.Enabled = True
        cmdSave.Enabled = True
        cmdSelectCoils.Enabled = True
        cmdDeleteLine.Enabled = True

        cboSteelBOLNumber.Enabled = True
        cboSteelPONumber.Enabled = True

        dtpReceiverDate.Value = Today()

        cboSteelReceivingNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        LastReceiverNumber = 0
        NextReceiverNumber = 0
        SUMSteelLineAmount = 0
        SUMSteelLineWeight = 0
        RecalcFreight = 0
        RecalcOther = 0
        RecalcSteelTotal = 0
        TotalNumberOfCoils = 0
    End Sub

    Private Sub cmdGenerateNewReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewReceipt.Click
        'Create Receipt Ticket Number
        Dim MAXStatement As String = "SELECT MAX(SteelReceivingHeaderKey) FROM SteelReceivingHeaderTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastReceiverNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastReceiverNumber = 5500000
        End Try
        con.Close()

        NextReceiverNumber = LastReceiverNumber + 1
        cboSteelReceivingNumber.Text = NextReceiverNumber

        cmd = New SqlCommand("INSERT INTO SteelReceivingHeaderTable (SteelReceivingHeaderKey, DivisionID, ReceivingDate, SteelVendor, SteelBOLNumber, SteelTotalWeight, SteelFreightCharges, SteelOtherCharges, SteelTotal, InvoiceTotal, Comment, ReceivingStatus, Locked, SteelPONumber)values(@SteelReceivingHeaderKey, @DivisionID, @ReceivingDate, @SteelVendor, @SteelBOLNumber, @SteelTotalWeight, @SteelFreightCharges, @SteelOtherCharges, @SteelTotal, @InvoiceTotal, @Comment, @ReceivingStatus, @Locked, @SteelPONumber)", con)

        With cmd.Parameters
            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ReceivingDate", SqlDbType.VarChar).Value = dtpReceiverDate.Text
            .Add("@SteelVendor", SqlDbType.VarChar).Value = txtSteelVendorID.Text
            .Add("@SteelBOLNumber", SqlDbType.VarChar).Value = cboSteelBOLNumber.Text
            .Add("@SteelTotalWeight", SqlDbType.VarChar).Value = 0
            .Add("@SteelFreightCharges", SqlDbType.VarChar).Value = 0
            .Add("@SteelOtherCharges", SqlDbType.VarChar).Value = 0
            .Add("@SteelTotal", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@SteelPONumber", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        txtStatus.Text = "OPEN"
    End Sub

    Private Sub cmdSelectCoils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectCoils.Click
        'Validate fields
        If cboSteelPONumber.Text = "" Or cboSteelReceivingNumber.Text = "" Or txtSteelVendorID.Text <> "CHARTERSTEEL" Or cboSteelBOLNumber.Text = "" Then
            MsgBox("You must have a BOL #, PO #, Vendor, and Receiver # to save.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*********************************************************************
        If txtStatus.Text = "OPEN" Then
            'Continue
        Else
            MsgBox("Receiver must be open to add coils.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '**********************************************************************
        'Load Totals
        LoadSteelReceivingTotals()
        '**********************************************************************
        'Save
        Try
            UpdateReceivingHeaderTable()
        Catch ex As Exception
            'Error log
            Dim TempReceiverNumber As Integer = 0
            Dim strReceiverNumber As String
            TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
            strReceiverNumber = CStr(TempReceiverNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Steel Receiver By Coil - SAVE Button"
            ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        'Open pop up
        GlobalSteelReceivingNumber = Val(cboSteelReceivingNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text
        GlobalSteelDespatchNumber = cboSteelBOLNumber.Text

        Dim NewSelectSteelCoilsForReceiving As New SelectSteelCoilsForReceiving
        NewSelectSteelCoilsForReceiving.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPostReceiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostReceiver.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to POST this Receiver?", "POST STEEL RECEIPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Validate Fields
            If cboSteelBOLNumber.Text = "" Or cboSteelReceivingNumber.Text = "" Or cboSteelPONumber.Text = "" Or txtSteelVendorID.Text = "" Or txtStatus.Text <> "OPEN" Or Me.dgvSteelReceivingLines.RowCount = 0 Then
                MsgBox("Cannot POST at this time. Check data.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '**********************************************************************
            'Check for discontinued steel type
            Dim CheckCarbon As Integer = 0

            Dim CheckCarbonString As String = "SELECT COUNT(SteelReceivingHeaderKey) FROM SteelReceivingLineTable WHERE RMID LIKE 'C1010 %' AND SteelReceivingHeaderKey = @SteelReceivingHeaderKey"
            Dim CheckCarbonCommand As New SqlCommand(CheckCarbonString, con)
            CheckCarbonCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckCarbon = CInt(CheckCarbonCommand.ExecuteScalar)
            Catch ex As Exception
                CheckCarbon = 0
            End Try

            If CheckCarbon > 0 Then
                Dim button5 As DialogResult = MessageBox.Show("One of these steel types is no longer used. Do you wish to continue?", "CONTINUE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button5 = DialogResult.Yes Then
                    'Do nothing
                ElseIf button5 = DialogResult.No Then
                    Exit Sub
                End If
            End If
            '**********************************************************************
            Dim CheckReceiverPosting As Integer = 0

            'Check if Receiver is posted
            Dim CheckReceiverPostingString As String = "SELECT COUNT(GLTransactionKey) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
            Dim CheckReceiverPostingCommand As New SqlCommand(CheckReceiverPostingString, con)
            CheckReceiverPostingCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
            CheckReceiverPostingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckReceiverPosting = CInt(CheckReceiverPostingCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckReceiverPosting = 0
            End Try
            con.Close()

            If CheckReceiverPosting > 0 Then
                MsgBox("This Receiver already has a G/L Posting and will close.", MsgBoxStyle.OkOnly)

                'Error Log
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = Today()
                ErrorComment = "Auto-close receiver for duplicate posting."
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Receiver By Coil - POST Button - Duplicate Receiver"
                ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                'Close Receiver
                '***********************************************************************
                Try
                    'Set Receiver as Posted
                    cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error log
                    Dim TempReceiverNumber2 As Integer = 0
                    Dim strReceiverNumber2 As String
                    TempReceiverNumber2 = Val(cboSteelReceivingNumber.Text)
                    strReceiverNumber2 = CStr(TempReceiverNumber2)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Steel Receiver By Coil - POST Button - Update Header"
                    ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber2
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '**********************************************************************
                Try
                    'Set Receiver lines as Posted
                    cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)

                    With cmd.Parameters
                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error log
                    Dim TempReceiverNumber3 As Integer = 0
                    Dim strReceiverNumber3 As String
                    TempReceiverNumber3 = Val(cboSteelReceivingNumber.Text)
                    strReceiverNumber3 = CStr(TempReceiverNumber3)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Steel Receiver By Coil - POST Button - Update Lines"
                    ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber3
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************

                Exit Sub
            End If
            '***********************************************************************
            'Load Totals
            LoadSteelReceivingTotals()

            'Save Routine
            UpdateReceivingHeaderTable()
            '***********************************************************************
            Dim RowRMID As String = ""
            Dim RowExtendedCost As Double = 0
            Dim RowReceiveWeight As Double = 0
            Dim RowLineNumber As Integer = 0
            Dim RowSteelCostPerPound As Double = 0
            Dim GetPOSteelCost As Double = 0
            Dim RowPOLineNumber As Integer = 0
            Dim SteelUnitCost As Double = 0

            For Each LineRow As DataGridViewRow In dgvSteelReceivingLines.Rows
                Try
                    RowLineNumber = LineRow.Cells("SteelReceivingLineKeyColumn").Value
                Catch ex As System.Exception
                    RowLineNumber = 1
                End Try
                Try
                    RowRMID = LineRow.Cells("RMIDColumn").Value
                Catch ex As System.Exception
                    RowRMID = ""
                End Try
                Try
                    RowExtendedCost = LineRow.Cells("SteelExtendedCostColumn").Value
                Catch ex As System.Exception
                    RowExtendedCost = 0
                End Try
                Try
                    RowReceiveWeight = LineRow.Cells("ReceiveWeightColumn").Value
                Catch ex As System.Exception
                    RowReceiveWeight = 0
                End Try
                Try
                    RowPOLineNumber = LineRow.Cells("SteelPOLineNumberColumn").Value
                Catch ex As System.Exception
                    RowPOLineNumber = 1
                End Try
                '****************************************************************************
                'Check RMID to see if matches PO
                Dim CheckPORMID As String = ""

                Dim CheckPORMIDString As String = "SELECT RMID FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber"
                Dim CheckPORMIDCommand As New SqlCommand(CheckPORMIDString, con)
                CheckPORMIDCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
                CheckPORMIDCommand.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = RowPOLineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckPORMID = CStr(CheckPORMIDCommand.ExecuteScalar)
                Catch ex As System.Exception
                    CheckPORMID = ""
                End Try
                con.Close()

                If RowRMID = CheckPORMID Then
                    'continue
                Else
                    'Error log
                    Dim TempReceiverNumber As Integer = 0
                    Dim strReceiverNumber As String
                    TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                    strReceiverNumber = CStr(TempReceiverNumber)

                    ErrorDate = Today()
                    ErrorComment = "Receiver RMID - " + RowRMID + ", PO RMID - " + CheckPORMID
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Steel Receiver By Coil - POST Button - Check RMID"
                    ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End If
                '****************************************************************************
                'Get Carbon, Steel Size
                Dim RowSteelSize, RowCarbon As String

                Dim GetCarbonString As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = @DivisionID"
                Dim GetCarbonCommand As New SqlCommand(GetCarbonString, con)
                GetCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                GetCarbonCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                Dim GetSteelSizeString As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = @DivisionID"
                Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeString, con)
                GetSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                GetSteelSizeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    RowCarbon = CStr(GetCarbonCommand.ExecuteScalar)
                Catch ex As System.Exception
                    RowCarbon = ""
                End Try
                Try
                    RowSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    RowSteelSize = ""
                End Try
                con.Close()

                If RowReceiveWeight <> 0 Then
                    RowSteelCostPerPound = RowExtendedCost / RowReceiveWeight
                    SteelUnitCost = RowSteelCostPerPound
                    SteelUnitCost = Math.Round(SteelUnitCost, 5)
                Else
                    RowSteelCostPerPound = 0
                End If

                If RowSteelCostPerPound = 0 Then
                    'Get Steel Cost
                    Dim GetPOSteelCostString As String = "SELECT PurchasePricePerPound FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND RMID = @RMID"
                    Dim GetPOSteelCostCommand As New SqlCommand(GetPOSteelCostString, con)
                    GetPOSteelCostCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
                    GetPOSteelCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                    GetPOSteelCostCommand.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = RowPOLineNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPOSteelCost = CDbl(GetPOSteelCostCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        GetPOSteelCost = 0
                    End Try
                    con.Close()

                    RowExtendedCost = RowReceiveWeight * GetPOSteelCost
                    RowExtendedCost = Math.Round(RowExtendedCost, 2)
                    SteelUnitCost = GetPOSteelCost
                    SteelUnitCost = Math.Round(SteelUnitCost, 5)

                    'Update Steel Receiving Line Table with cost
                    cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SteelExtendedCost = @SteelExtendedCost WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                    With cmd.Parameters
                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                        .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@SteelExtendedCost", SqlDbType.VarChar).Value = RowExtendedCost
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
                '**********************************************************************
                'Create Cost Tier
                Dim LastCostTransactionNumber, NextCostTransactionNumber As Integer

                'Get New Transaction Number
                Dim MAXCostTransactionStatement As String = "SELECT MAX(TransactionNumber) FROM SteelCostingTable"
                Dim MAXCostTransactionCommand As New SqlCommand(MAXCostTransactionStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastCostTransactionNumber = CInt(MAXCostTransactionCommand.ExecuteScalar)
                Catch ex As Exception
                    LastCostTransactionNumber = 5500000
                End Try
                con.Close()

                NextCostTransactionNumber = LastCostTransactionNumber + 1
                '***********************************************************************
                'Get Upper and Lower Limits
                Dim UpperLimit, NewUpperLimit, NewLowerLimit As Double
                Dim MAXTransactionNumber As Integer = 0

                Dim GetMAXtransactionNumberString As String = "SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID"
                Dim GetMAXtransactionNumberCommand As New SqlCommand(GetMAXtransactionNumberString, con)
                GetMAXtransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXTransactionNumber = CInt(GetMAXtransactionNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    MAXTransactionNumber = 0
                End Try
                con.Close()

                Dim GetUpperLimitString As String = "SELECT UpperLimit FROM SteelCostingTable WHERE RMID = @RMID AND TransactionNumber = @TransactionNumber"
                Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitString, con)
                GetUpperLimitCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    UpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
                Catch ex As System.Exception
                    UpperLimit = 0
                End Try
                con.Close()

                NewLowerLimit = UpperLimit + 1
                NewUpperLimit = NewLowerLimit + RowReceiveWeight

                Try
                    'INSERT INTO Steel Costing Table
                    cmd = New SqlCommand("INSERT INTO SteelCostingTable (RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, LowerLimit, UpperLimit, Status, TransactionNumber, ReferenceNumber, ReferenceLine) values (@RMID, @Carbon, @SteelSize, @CostingDate, @SteelCostPerPound, @CostingQuantity, @LowerLimit, @UpperLimit, @Status, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                    With cmd.Parameters
                        .Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                        .Add("@Carbon", SqlDbType.VarChar).Value = RowCarbon
                        .Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSize
                        .Add("@CostingDate", SqlDbType.VarChar).Value = dtpReceiverDate.Text
                        .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = SteelUnitCost
                        .Add("@CostingQuantity", SqlDbType.VarChar).Value = RowReceiveWeight
                        .Add("@LowerLimit", SqlDbType.VarChar).Value = NewLowerLimit
                        .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                        .Add("@Status", SqlDbType.VarChar).Value = "STEEL RECEIVING"
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostTransactionNumber
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                        .Add("@ReferenceLine", SqlDbType.VarChar).Value = RowLineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error log
                    Dim TempReceiverNumber As Integer = 0
                    Dim strReceiverNumber As String
                    TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                    strReceiverNumber = CStr(TempReceiverNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Steel Receiver By Coil - POST Button - Steel Cost Tier"
                    ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************
                'Create Steel Transaction
                Try
                    'INSERT INTO Steel Transaction Table
                    cmd = New SqlCommand("INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, SteelTransactionDate, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType) values ((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM SteelTransactionTable), @DivisionID, @SteelTransactionDate, @Carbon, @SteelSize, @Quantity, @SteelCost, @ExtendedCost, @SteelReferenceNumber, @SteelReferenceLine, @RMID, @TransactionMath, @TransactionType)", con)

                    With cmd.Parameters
                        '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextSteelTransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@SteelTransactionDate", SqlDbType.VarChar).Value = dtpReceiverDate.Text
                        .Add("@Carbon", SqlDbType.VarChar).Value = RowCarbon
                        .Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSize
                        .Add("@Quantity", SqlDbType.VarChar).Value = RowReceiveWeight
                        .Add("@SteelCost", SqlDbType.VarChar).Value = SteelUnitCost
                        .Add("@ExtendedCost", SqlDbType.VarChar).Value = RowExtendedCost
                        .Add("@SteelReferenceNumber", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                        .Add("@SteelReferenceLine", SqlDbType.VarChar).Value = RowLineNumber
                        .Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                        .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                        .Add("@TransactionType", SqlDbType.VarChar).Value = "RECEIPT OF GOODS"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error log
                    Dim TempReceiverNumber As Integer = 0
                    Dim strReceiverNumber As String
                    TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                    strReceiverNumber = CStr(TempReceiverNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Steel Receiver By Coil - POST Button - Steel Transaction"
                    ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                RowRMID = ""
                RowExtendedCost = 0
                RowReceiveWeight = 0
                RowLineNumber = 0
                RowSteelCostPerPound = 0
                GetPOSteelCost = 0
                RowPOLineNumber = 0
                SteelUnitCost = 0
                LastCostTransactionNumber = 0
                NextCostTransactionNumber = 0
                UpperLimit = 0
                NewUpperLimit = 0
                NewLowerLimit = 0
                SteelUnitCost = 0
                MAXTransactionNumber = 0
            Next
            '***********************************************************************
            'Steel Posting

            'Get Total Steel Cost of Receiver
            Dim TotalSteelCost As Double = 0

            Dim TotalSteelCostString As String = "SELECT SteelTotal FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID"
            Dim TotalSteelCostCommand As New SqlCommand(TotalSteelCostString, con)
            TotalSteelCostCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
            TotalSteelCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalSteelCost = CDbl(TotalSteelCostCommand.ExecuteScalar)
            Catch ex As System.Exception
                TotalSteelCost = 0
            End Try
            con.Close()
            '************************************************************************
            Try
                'Command to write Line Amount to GL
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "20995"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Receiving"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpReceiverDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = TotalSteelCost
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Steel Vendor " + txtSteelVendorID.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error log
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Receiver By Coil - POST Button - G/L Credit"
                ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
    
            Try
                'Command to write Line Amount to GL
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Receiving"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpReceiverDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = TotalSteelCost
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Steel Vendor " + txtSteelVendorID.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error log
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Receiver By Coil - POST Button - G/L Debit"
                ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '***********************************************************************
            Try
                'Set Receiver as Posted
                cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus, Locked = @Locked, PrintDate = @PrintDate WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                    .Add("@Locked", SqlDbType.VarChar).Value = ""
                    .Add("@PrintDate", SqlDbType.VarChar).Value = Now()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error log
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Receiver By Coil - POST Button - Update Header"
                ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**********************************************************************
            Try
                'Set Receiver lines as Posted
                cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)

                With cmd.Parameters
                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error log
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Receiver By Coil - POST Button - Update Lines"
                ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '***********************************************************************
            'Clear Fields
            LoadSteelReceiverNumber()
            ClearVariables()
            ClearData()
            ClearDataInDatagrid()
            ClearSteelCoilLines()

            cboSteelReceivingNumber.Focus()

            MsgBox("Receipt is posted.", MsgBoxStyle.OkOnly)
        ElseIf button = DialogResult.No Then
            Exit Sub
            cmdPostReceiver.Focus()
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Ask question
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this receiver?", "SAVE RECEIVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Validate fields
            If cboSteelPONumber.Text = "" Or cboSteelReceivingNumber.Text = "" Or txtSteelVendorID.Text <> "CHARTERSTEEL" Or cboSteelBOLNumber.Text = "" Then
                MsgBox("You must have a BOL #, PO #, Vendor, and Receiver # to save.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*********************************************************************
            If txtStatus.Text = "OPEN" Then
                'Continue
            Else
                MsgBox("Receiver must be open to save.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '**********************************************************************
            'Check for discontinued steel type
            Dim CheckCarbon As Integer = 0

            Dim CheckCarbonString As String = "SELECT COUNT(SteelReceivingHeaderKey) FROM SteelReceivingLineTable WHERE RMID LIKE 'C1010 %' AND SteelReceivingHeaderKey = @SteelReceivingHeaderKey"
            Dim CheckCarbonCommand As New SqlCommand(CheckCarbonString, con)
            CheckCarbonCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckCarbon = CInt(CheckCarbonCommand.ExecuteScalar)
            Catch ex As Exception
                CheckCarbon = 0
            End Try

            If CheckCarbon > 0 Then
                Dim button4 As DialogResult = MessageBox.Show("One of these steel types is no longer used. Do you wish to continue?", "CONTINUE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button4 = DialogResult.Yes Then
                    'Do nothing
                ElseIf button4 = DialogResult.No Then
                    Exit Sub
                End If
            End If
            '**********************************************************************
            'Load Totals
            LoadSteelReceivingTotals()
            '**********************************************************************
            'Save
            Try
                UpdateReceivingHeaderTable()

                MsgBox("Steel receiver has been saved.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Error log
                Dim TempReceiverNumber As Integer = 0
                Dim strReceiverNumber As String
                TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                strReceiverNumber = CStr(TempReceiverNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Receiver By Coil - SAVE Button"
                ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        ElseIf button = DialogResult.No Then
            cmdSave.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmdClearAllData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAllData.Click
        If cboSteelReceivingNumber.Text <> "" And txtStatus.Text = "OPEN" Then
            UnlockForm()
        End If

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        ClearSteelCoilLines()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Steel Receiver?", "DELETE STEEL RECEIVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Validation
            If cboSteelReceivingNumber.Text = "" Or txtStatus.Text <> "OPEN" Then
                MsgBox("You must have a valid receiver # and status must be OPEN.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Check receiver # in database
                Dim CheckReceiverNumber As Integer = 0
                Dim CheckStatus As String = ""

                Dim CheckReceiverNumberStatement As String = "SELECT COUNT(SteelReceivingHeaderKey) From SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID"
                Dim CheckReceiverNumberCommand As New SqlCommand(CheckReceiverNumberStatement, con)
                CheckReceiverNumberCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                CheckReceiverNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim CheckReceiverStatusStatement As String = "SELECT ReceivingStatus From SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID"
                Dim CheckReceiverStatusCommand As New SqlCommand(CheckReceiverStatusStatement, con)
                CheckReceiverStatusCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                CheckReceiverStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckReceiverNumber = CInt(CheckReceiverNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckReceiverNumber = 0
                End Try
                Try
                    CheckStatus = CStr(CheckReceiverStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckStatus = ""
                End Try
                con.Close()

                If CheckStatus = "OPEN" And CheckReceiverNumber = 1 Then
                    'Continue
                Else
                    MsgBox("Receiver must exist and be open to delete.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*********************************************************************************
                'Reset Charter Coils back to OPEN
                Dim RowCoilID As String = ""

                If Me.dgvSteelCoils.RowCount > 0 Then
                    For Each LineRow As DataGridViewRow In dgvSteelCoils.Rows
                        Try
                            RowCoilID = LineRow.Cells("CoilIDColumnCL").Value
                        Catch ex As System.Exception
                            RowCoilID = ""
                        End Try

                        'Create command to change Charter Coils to Open
                        cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Status = 'OPEN' WHERE CoilID = @CoilID", con)

                        With cmd.Parameters
                            '.Add("@DespatchNumber", SqlDbType.VarChar).Value = cboSteelReceivingNumber.Text
                            .Add("@CoilID", SqlDbType.VarChar).Value = RowCoilID
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        RowCoilID = ""
                    Next
                End If
                '*********************************************************************************
                Try
                    'Create command to delete
                    cmd = New SqlCommand("DELETE FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID AND ReceivingStatus = @ReceivingStatus", con)

                    With cmd.Parameters
                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*********************************************************************************
                    MsgBox("Steel Receiver has been deleted", MsgBoxStyle.OkOnly)

                    LoadSteelReceiverNumber()
                    ClearVariables()
                    ClearData()
                    ClearSteelCoilLines()
                    ClearDataInDatagrid()
                Catch ex As Exception
                    'Error log
                    Dim TempReceiverNumber As Integer = 0
                    Dim strReceiverNumber As String
                    TempReceiverNumber = Val(cboSteelReceivingNumber.Text)
                    strReceiverNumber = CStr(TempReceiverNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Steel Receiver By Coil - DELETE Button"
                    ErrorReferenceNumber = "Steel Receiver # " + strReceiverNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        ElseIf button = DialogResult.No Then
            cmdDelete.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this line from the receiver?", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Validation
            If cboSteelReceivingNumber.Text = "" Or txtStatus.Text <> "OPEN" Or cboDeleteLineNumber.Text = "" Or Me.dgvSteelReceivingLines.RowCount = 0 Then
                MsgBox("Cannot delete a line at this time.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '*************************************************************************
            'Reset Charter Coils back to OPEN
            Dim RowCoilID As String = ""

            If Me.dgvSteelCoils.RowCount > 0 Then
                For Each LineRow As DataGridViewRow In dgvSteelCoils.Rows
                    Try
                        RowCoilID = LineRow.Cells("CoilIDColumnCL").Value
                    Catch ex As System.Exception
                        RowCoilID = ""
                    End Try

                    'Create command to change Charter Coils to Open
                    cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Status = 'OPEN' WHERE CoilID = @CoilID", con)

                    With cmd.Parameters
                        '.Add("@DespatchNumber", SqlDbType.VarChar).Value = cboSteelReceivingNumber.Text
                        .Add("@CoilID", SqlDbType.VarChar).Value = RowCoilID
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    RowCoilID = ""
                Next
            End If
            '*************************************************************************
            Try
                'Delete Line
                cmd = New SqlCommand("DELETE FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                With cmd.Parameters
                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelReceivingNumber.Text)
                    .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = Val(cboDeleteLineNumber.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log

            End Try
            '*************************************************************************
            'Load totals and reload datagrids
            LoadSteelReceivingTotals()

            LoadSteelReceivingLines()

            LoadSteelCoilLines()
            '*************************************************************************
            'Save Data

            UpdateReceivingHeaderTable()
            '*************************************************************************
            'Unlock Controls (If necessary)

            UnlockForm()

            cboDeleteLineNumber.Text = ""
        ElseIf button = DialogResult.No Then
            Exit Sub
            cmdDeleteLine.Focus()
        End If
    End Sub

    Private Sub cboSteelReceivingNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelReceivingNumber.SelectedIndexChanged
        LoadSteelReceivingData()
        LoadSteelReceivingTotals()
        LoadSteelReceivingLines()
        LoadSteelCoilLines()
        LockControls()
    End Sub

    Private Sub cboSteelPONumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelPONumber.SelectedIndexChanged
        LoadSteelVendorFromPO()
    End Sub

    Private Sub txtSteelVendorID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSteelVendorID.TextChanged
        LoadVendorName()
    End Sub

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged
        LoadSteelReceivingTotals()
    End Sub

    Private Sub txtOtherTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherTotal.TextChanged
        LoadSteelReceivingTotals()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If cboSteelReceivingNumber.Text <> "" And txtStatus.Text = "OPEN" Then
            UnlockForm()
        End If

        GlobalSteelDespatchNumber = 0
        GlobalSteelReceivingNumber = 0

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

End Class