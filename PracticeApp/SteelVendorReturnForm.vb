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
Public Class SteelVendorReturnForm
    Inherits System.Windows.Forms.Form

    Dim ProductTotal, ReturnTotal, FreightTotal, OtherTotal As Double
    Dim ReturnStatus As String = ""
    Dim GetRMID As String = ""
    Dim FIFOSteelCost As Double = 0
    Dim HeatNumber As String = ""
    Dim SteelDescription As String = ""
    Dim VendorName As String = ""

    Dim SteelVendor, ReturnComment, ReturnDate As String

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet

    Private Sub SteelVendorReturnForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" And GlobalDivisionCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If
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

    Public Sub ShowReturnLines()
        cmd = New SqlCommand("SELECT * FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber", con)
        cmd.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReturnLineTable")
        dgvSteelReturnLines.DataSource = ds.Tables("SteelReturnLineTable")
        cboDeleteLineNumber.DataSource = ds.Tables("SteelReturnLineTable")
        con.Close()
    End Sub

    Public Sub ClearDatagrid()
        Me.dgvSteelReturnLines.DataSource = Nothing
    End Sub

    Public Sub LoadReturnNumber()
        cmd = New SqlCommand("SELECT SteelReturnNumber FROM SteelReturnHeaderTable WHERE DivisionID = @DivisionID ORDER BY SteelReturnNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "SteelReturnHeaderTable")
        cboReturnNumber.DataSource = ds1.Tables("SteelReturnHeaderTable")
        con.Close()
        cboReturnNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelVendor()
        'Loads only Vendor for the correct division
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Vendor")
        cboVendorCode.DataSource = ds2.Tables("Vendor")
        con.Close()
        cboVendorCode.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelPONumber()
        cmd = New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SteelPurchaseOrderHeader")
        cboPurchaseOrderNumber.DataSource = ds3.Tables("SteelPurchaseOrderHeader")
        con.Close()
        cboPurchaseOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT (Carbon) FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "RawMaterialsTable")
        cboCarbon.DataSource = ds4.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT (SteelSize) FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "RawMaterialsTable")
        cboSteelSize.DataSource = ds5.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadCoilID()
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND Status = 'RAW'", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "CharterSteelCoilIdentification")
        cboCoilID.DataSource = ds7.Tables("CharterSteelCoilIdentification")
        con.Close()
        cboCoilID.SelectedIndex = -1
    End Sub

    Public Sub LoadSelectCarbon()
        cmd = New SqlCommand("SELECT DISTINCT (Carbon) FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "RawMaterialsTable")
        cboSelectCarbon.DataSource = ds8.Tables("RawMaterialsTable")
        con.Close()
        cboSelectCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSelectSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT (SteelSize) FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "RawMaterialsTable")
        cboSelectSteelSize.DataSource = ds9.Tables("RawMaterialsTable")
        con.Close()
        cboSelectSteelSize.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboCarbon.SelectedIndex = -1
        cboCoilID.SelectedIndex = -1
        cboDeleteLineNumber.SelectedIndex = -1
        cboPurchaseOrderNumber.SelectedIndex = -1
        cboReturnNumber.SelectedIndex = -1
        cboSelectCarbon.SelectedIndex = -1
        cboSelectSteelSize.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboVendorCode.SelectedIndex = -1

        txtComment.Clear()
        txtDescription.Clear()
        txtExtendedAmount.Clear()
        txtFreight.Clear()
        txtHeatNumber.Clear()
        txtOther.Clear()
        txtProductTotal.Clear()
        txtReturnedQuantity.Clear()
        txtReturnTotal.Clear()
        txtStatus.Clear()
        txtUnitCost.Clear()
        txtVendorName.Clear()

        dtpReturnDate.Text = ""

        cboReturnNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        ProductTotal = 0
        ReturnTotal = 0
        FreightTotal = 0
        OtherTotal = 0
        ReturnStatus = ""
        GetRMID = ""
        FIFOSteelCost = 0
        HeatNumber = ""
        SteelDescription = ""
        VendorName = ""
        SteelVendor = ""
        ReturnComment = ""
        ReturnDate = ""
    End Sub

    Public Sub ClearLines()
        cboCoilID.SelectedIndex = -1
        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        txtReturnedQuantity.Clear()
        txtUnitCost.Clear()
        txtExtendedAmount.Clear()
        txtHeatNumber.Clear()
        txtDescription.Clear()
        cboCarbon.Focus()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadSteelPONumber()
        LoadReturnNumber()
        LoadSteelVendor()
        LoadCarbon()
        LoadSteelSize()
        LoadSelectCarbon()
        LoadSelectSteelSize()

        ClearData()
        ClearDatagrid()
        ClearVariables()
    End Sub

    Public Sub LoadReturnData()
        Dim GetReturnDataStatement As String = "SELECT * FROM SteelReturnHeaderTable WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID"
        Dim GetReturnDataCommand As New SqlCommand(GetReturnDataStatement, con)
        GetReturnDataCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        GetReturnDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetReturnDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SteelVendor")) Then
                SteelVendor = ""
            Else
                SteelVendor = reader.Item("SteelVendor")
            End If
            If IsDBNull(reader.Item("ReturnDate")) Then
                ReturnDate = ""
            Else
                ReturnDate = reader.Item("ReturnDate")
            End If
            If IsDBNull(reader.Item("ReturnComment")) Then
                ReturnComment = ""
            Else
                ReturnComment = reader.Item("ReturnComment")
            End If
        Else
            SteelVendor = ""
            ReturnDate = ""
            ReturnComment = ""
        End If
        reader.Close()
        con.Close()

        cboVendorCode.Text = SteelVendor
        dtpReturnDate.Text = ReturnDate
        txtComment.Text = ReturnComment
    End Sub

    Public Sub LoadReturnTotals()
        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedCost) FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber"
        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
        SUMExtendedAmountCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

        Dim GetOtherTotalStatement As String = "SELECT OtherTotal FROM SteelReturnHeaderTable WHERE SteelReturnNumber = @SteelReturnNumber"
        Dim GetOtherTotalCommand As New SqlCommand(GetOtherTotalStatement, con)
        GetOtherTotalCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

        Dim GetFreightTotalStatement As String = "SELECT FreightTotal FROM SteelReturnHeaderTable WHERE SteelReturnNumber = @SteelReturnNumber"
        Dim GetFreightTotalCommand As New SqlCommand(GetFreightTotalStatement, con)
        GetFreightTotalCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
            ProductTotal = Math.Round(ProductTotal, 2)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            OtherTotal = CDbl(GetOtherTotalCommand.ExecuteScalar)
            OtherTotal = Math.Round(OtherTotal, 2)
        Catch ex As Exception
            OtherTotal = 0
        End Try
        Try
            FreightTotal = CDbl(GetFreightTotalCommand.ExecuteScalar)
            FreightTotal = Math.Round(FreightTotal, 2)
        Catch ex As Exception
            FreightTotal = 0
        End Try
        con.Close()

        ReturnTotal = ProductTotal + OtherTotal + FreightTotal

        txtProductTotal.Text = ProductTotal
        txtOther.Text = OtherTotal
        txtFreight.Text = FreightTotal
        txtReturnTotal.Text = ReturnTotal
    End Sub

    Public Sub LoadSteelCost()
        'Get Steel Cost
        Dim GetMaxUsage As Double = 0

        Dim GetUsageStatement As String = "SELECT SUM(UsageWeight) FROM SteelUsageTable WHERE RMID = @RMID"
        Dim GetUsageCommand As New SqlCommand(GetUsageStatement, con)
        GetUsageCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetMaxUsage = CDbl(GetUsageCommand.ExecuteScalar)
        Catch ex As Exception
            GetMaxUsage = 0
        End Try
        con.Close()

        Dim GetSteelCostStatement As String = "SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND @SteelUsage BETWEEN LowerLimit AND UpperLimit"
        Dim GetSteelCostCommand As New SqlCommand(GetSteelCostStatement, con)
        GetSteelCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID
        GetSteelCostCommand.Parameters.Add("@SteelUsage", SqlDbType.VarChar).Value = GetMaxUsage

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            FIFOSteelCost = CDbl(GetSteelCostCommand.ExecuteScalar)
        Catch ex As Exception
            FIFOSteelCost = 0
        End Try
        con.Close()

        If FIFOSteelCost = 0 Then
            'Get Steel Cost
            Dim GetMaxTransactionNumber As Integer = 0

            Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM SteelTransactionTable WHERE RMID = @RMID"
            Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
            GetMaxTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetMaxTransactionNumber = 0
            End Try
            con.Close()

            Dim GetLastCostStatement As String = "SELECT SteelCost FROM SteelTransactionTable WHERE TransactionNumber = @TransactionNumber"
            Dim GetLastCostCommand As New SqlCommand(GetLastCostStatement, con)
            GetLastCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FIFOSteelCost = CDbl(GetLastCostCommand.ExecuteScalar)
            Catch ex As Exception
                FIFOSteelCost = 0
            End Try
            con.Close()
        End If

        txtUnitCost.Text = FIFOSteelCost
    End Sub

    Public Sub LoadSteelDescription()
        Dim SteelDescriptionStatement As String = "SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim SteelDescriptionCommand As New SqlCommand(SteelDescriptionStatement, con)
        SteelDescriptionCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        SteelDescriptionCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelDescription = CStr(SteelDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            SteelDescription = ""
        End Try
        con.Close()

        txtDescription.Text = SteelDescription
    End Sub

    Public Sub LoadVendorName()
        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
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

    Public Sub LoadHeatHumberForCoil()
        Dim HeatNumberStatement As String = "SELECT HeatNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID"
        Dim HeatNumberCommand As New SqlCommand(HeatNumberStatement, con)
        HeatNumberCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            HeatNumber = CStr(HeatNumberCommand.ExecuteScalar)
        Catch ex As Exception
            HeatNumber = ""
        End Try
        con.Close()

        txtHeatNumber.Text = HeatNumber
    End Sub

    Public Sub LoadRMID()
        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            GetRMID = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadStatus()
        Dim ReturnStatusStatement As String = "SELECT ReturnStatus FROM SteelReturnHeaderTable WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID"
        Dim ReturnStatusCommand As New SqlCommand(ReturnStatusStatement, con)
        ReturnStatusCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        ReturnStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ReturnStatus = CStr(ReturnStatusCommand.ExecuteScalar)
        Catch ex As Exception
            ReturnStatus = "OPEN"
        End Try
        con.Close()

        txtStatus.Text = ReturnStatus

        'If status is closed or pending, lock controls
        If ReturnStatus = "CLOSED" Or ReturnStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdDeleteLine.Enabled = False
            cmdEnter.Enabled = False
            cmdPostReturn.Enabled = False
            cmdSave.Enabled = False
            cmdSelectByPO.Enabled = False
            'cmdSelectByCoil.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdDeleteLine.Enabled = True
            cmdEnter.Enabled = True
            cmdPostReturn.Enabled = True
            cmdSave.Enabled = True
            cmdSelectByPO.Enabled = True
            'cmdSelectByCoil.Enabled = True
        End If
    End Sub

    Private Sub cboReturnNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReturnNumber.SelectedIndexChanged
        LoadReturnData()
        LoadReturnTotals()
        LoadStatus()

        ShowReturnLines()
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        'Validate steel, Return Number, Status
        If Val(cboReturnNumber.Text) = 0 Or cboReturnNumber.Text = "" Then
            MsgBox("You must have a valid return number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboVendorCode.Text = "" Then
            MsgBox("You must select a vendor.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Load Status
        LoadStatus()

        If ReturnStatus = "OPEN" Then
            'Do nothing
        Else
            MsgBox("Return must be open to edit.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '***********************************************************************************************************
        'Check RMID
        Dim CountRMID As Integer = 0

        Dim CountRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim CountRMIDCommand As New SqlCommand(CountRMIDStatement, con)
        CountRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        CountRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountRMID = CInt(CountRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CountRMID = 0
        End Try
        con.Close()

        If CountRMID = 1 Then
            'Do nothing
        Else
            MsgBox("Invalid steel carbon or steel size.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '***********************************************************************************************************
        'Save Header Table Data
        LoadReturnTotals()
        UpdateSteelReturnHeaderTable()
        '***********************************************************************************************************
        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            GetRMID = ""
        End Try
        con.Close()
        '***********************************************************************************************************
        'Insert into steel return line table
        Dim GetLastLineNumber, GetNextLineNumber As Integer

        Dim MAXStatement As String = "SELECT MAX(SteelReturnLine) FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)
        MAXCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLastLineNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            GetLastLineNumber = 0
        End Try
        con.Close()

        GetNextLineNumber = GetLastLineNumber + 1
        '***********************************************************************************************************
        'Insert into database
        cmd = New SqlCommand("INSERT INTO SteelReturnLineTable (SteelReturnNumber, SteelReturnLine, RMID, ReturnQuantity, UnitCost, ExtendedCost, LineStatus, GLDebitAccount, GLCreditAccount, LineComment) Values (@SteelReturnNumber, @SteelReturnLine, @RMID, @ReturnQuantity, @UnitCost, @ExtendedCost, @LineStatus, @GLDebitAccount, @GLCreditAccount, @LineComment)", con)

        With cmd.Parameters
            .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@SteelReturnLine", SqlDbType.VarChar).Value = GetNextLineNumber
            .Add("@RMID", SqlDbType.VarChar).Value = GetRMID
            .Add("@ReturnQuantity", SqlDbType.VarChar).Value = Val(txtReturnedQuantity.Text)
            .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
            .Add("@ExtendedCost", SqlDbType.VarChar).Value = Val(txtExtendedAmount.Text)
            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "20995"
            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12000"
            .Add("@LineComment", SqlDbType.VarChar).Value = txtHeatNumber.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '***********************************************************************************************************
        Dim NewCoilID As String = ""
        Dim strLineNumber As String = ""

        If cboCoilID.Text = "" Then
            'Create Coil ID
            strLineNumber = CStr(GetNextLineNumber)
            NewCoilID = "Manual Entry (Line #" + strLineNumber + ")"
        End If

        Try
            'Insert into steel return coil lines
            cmd = New SqlCommand("INSERT INTO SteelReturnCoilLines (SteelReturnNumber, SteelReturnLine, CoilID, CoilWeight, CoilCostPerPound, CoilExtendedCost, SteelPONumber, SteelPOLine, HeatNumber, SteelReceiverNumber, SteelReceiverLineNumber) Values (@SteelReturnNumber, @SteelReturnLine, @CoilID, @CoilWeight, @CoilCostPerPound, @CoilExtendedCost, @SteelPONumber, @SteelPOLine, @HeatNumber, @SteelReceiverNumber, @SteelReceiverLineNumber)", con)

            With cmd.Parameters
                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@SteelReturnLine", SqlDbType.VarChar).Value = GetNextLineNumber
                If cboCoilID.Text = "" Then
                    .Add("@CoilID", SqlDbType.VarChar).Value = NewCoilID
                Else
                    .Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text
                End If
                .Add("@CoilWeight", SqlDbType.VarChar).Value = Val(txtReturnedQuantity.Text)
                .Add("@CoilCostPerPound", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                .Add("@CoilExtendedCost", SqlDbType.VarChar).Value = Val(txtExtendedAmount.Text)
                .Add("@SteelPONumber", SqlDbType.VarChar).Value = 0
                .Add("@SteelPOLine", SqlDbType.VarChar).Value = 0
                .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
                .Add("@SteelReceiverNumber", SqlDbType.VarChar).Value = 0
                .Add("@SteelReceiverLineNumber", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log

        End Try
        '***********************************************************************************************************
        'Update Totals
        LoadReturnTotals()

        Try
            UpdateSteelReturnHeaderTable()
        Catch ex As Exception
            'Error Log

        End Try

        'Refresh datagrid
        ShowReturnLines()

        'Clear Line Entry
        ClearLines()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearLines()
    End Sub

    Private Sub cmdSelectByCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectByCoil.Click
        GlobalSteelReturnCarbon = cboSelectCarbon.Text
        GlobalSteelReturnSize = cboSelectSteelSize.Text
        GlobalSteelReturnFormType = "COIL LIST"
        GlobalSteelReturnNumber = Val(cboReturnNumber.Text)

        cboSteelSize.SelectedIndex = -1
        cboSelectCarbon.SelectedIndex = -1

        Using NewSelectSteelCoilsForReturn As New SelectSteelCoilsForReturn
            Dim result = NewSelectSteelCoilsForReturn.ShowDialog()
        End Using

        ShowReturnLines()
        LoadReturnTotals()
    End Sub

    Private Sub cmdSelectByPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectByPO.Click
        GlobalSteelReturnNumber = Val(cboReturnNumber.Text)
        GlobalSteelReturnPONumber = Val(cboPurchaseOrderNumber.Text)
        GlobalSteelReturnFormType = "RECEIVER"

        cboPurchaseOrderNumber.SelectedIndex = -1

        Using NewSelectSteelCoilsForReturn As New SelectSteelCoilsForReturn
            Dim result = NewSelectSteelCoilsForReturn.ShowDialog()
        End Using

        ShowReturnLines()
        LoadReturnTotals()
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If cboReturnNumber.Text = "" Then
            MsgBox("You must select a valid return #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboDeleteLineNumber.Text = "" Then
            MsgBox("Select a line number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            cmd = New SqlCommand("DELETE FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

            With cmd.Parameters
                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@SteelReturnLine", SqlDbType.VarChar).Value = Val(cboDeleteLineNumber.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try

        MsgBox("Line has been deleted.", MsgBoxStyle.OkOnly)

        ShowReturnLines()
        LoadReturnTotals()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearData()
        ClearVariables()
        ClearDatagrid()
    End Sub

    Private Sub cmdPostReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostReturn.Click
        'Validate
        If cboReturnNumber.Text = "" Then
            MsgBox("You must select a valid return number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'LoadStatus
        LoadStatus()

        If ReturnStatus <> "OPEN" Then
            MsgBox("You cannot post a return that is not open.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Me.dgvSteelReturnLines.RowCount = 0 Then
            MsgBox("You cannot post a return that has no lines.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*******************************************************************************************
        'Validate Vendor
        Dim ValidateVendor As Integer = 0

        Dim ValidateVendorStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim ValidateVendorCommand As New SqlCommand(ValidateVendorStatement, con)
        ValidateVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
        ValidateVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ValidateVendor = CInt(ValidateVendorCommand.ExecuteScalar)
        Catch ex As Exception
            ValidateVendor = 0
        End Try
        con.Close()

        If ValidateVendor = 0 Then
            MsgBox("You must select a valid vendor.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*******************************************************************************************
        'Check if Return has already been posted to the GL
        Dim CountGLPostings As Integer = 0

        Dim CountGLPostingsStatement As String = "SELECT GLTransactionKey FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID AND GLTransactionDescription = 'Steel Vendor Return'"
        Dim CountGLPostingsCommand As New SqlCommand(CountGLPostingsStatement, con)
        CountGLPostingsCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        CountGLPostingsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountGLPostings = CInt(CountGLPostingsCommand.ExecuteScalar)
        Catch ex As Exception
            CountGLPostings = 0
        End Try
        con.Close()

        If CountGLPostings = 0 Then
            'Continue
        Else
            MsgBox("This return has already been posted.", MsgBoxStyle.OkOnly)

            'Log Error and close
            Dim TempReturnNumber As Integer = 0
            Dim strReturnNumber As String
            TempReturnNumber = Val(cboReturnNumber.Text)
            strReturnNumber = CStr(TempReturnNumber)

            ErrorDate = Today()
            ErrorComment = "Steel Vendor Return"
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "This return has already been posted."
            ErrorReferenceNumber = "Return # " + strReturnNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            Exit Sub
        End If
        '*********************************************************************************************
        'Save data and update totals
        LoadReturnTotals()
        '*********************************************************************************************
        Try
            UpdateSteelReturnHeaderTable()
        Catch ex As Exception
            'Log error on update failure
            Dim TempReturnNumber As Integer = 0
            Dim strReturnNumber As String
            TempReturnNumber = Val(cboReturnNumber.Text)
            strReturnNumber = CStr(TempReturnNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Steel Vendor Return --- Save Header Failure on Post"
            ErrorReferenceNumber = "Return # " + strReturnNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '**********************************************************************************
        'Line Routine
        Dim RowLineNumber As Integer = 0
        Dim RowExtendedAmount As Double = 0
        Dim RowRMID As String = ""
        Dim RowReturnQuantity As Double = 0
        Dim RowUnitCost As Double = 0
        Dim RowCarbon As String = ""
        Dim RowSteelSize As String = ""

        'Get Line data to post to GL
        For Each Row As DataGridViewRow In dgvSteelReturnLines.Rows
            Try
                RowLineNumber = Row.Cells("SteelReturnLineColumn").Value
            Catch ex As System.Exception
                RowLineNumber = 0
            End Try
            Try
                RowExtendedAmount = Row.Cells("ExtendedCostColumn").Value
            Catch ex As System.Exception
                RowExtendedAmount = 0
            End Try
            Try
                RowRMID = Row.Cells("RMIDColumn").Value
            Catch ex As System.Exception
                RowRMID = ""
            End Try
            Try
                RowReturnQuantity = Row.Cells("ReturnQuantityColumn").Value
            Catch ex As System.Exception
                RowReturnQuantity = 0
            End Try
            Try
                RowUnitCost = Row.Cells("UnitCostColumn").Value
            Catch ex As System.Exception
                RowUnitCost = 0
            End Try
            '***************************************************************************************
            'Get Coil ID from Return Coil Line Table
            Dim GetCoilID As String = ""

            Dim GetCoilIDStatement As String = "SELECT CoilID FROM SteelReturnCoilLines WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine"
            Dim GetCoilIDCommand As New SqlCommand(GetCoilIDStatement, con)
            GetCoilIDCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            GetCoilIDCommand.Parameters.Add("@SteelReturnLine", SqlDbType.VarChar).Value = RowLineNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCoilID = CStr(GetCoilIDCommand.ExecuteScalar)
            Catch ex As Exception
                GetCoilID = ""
            End Try
            con.Close()
            '***************************************************************************************
            'Get Carbon and Steel Size for transation entry
            Dim GetSteelDataStatement As String = "SELECT Carbon, SteelSize FROM RawMaterialsTable WHERE RMID = @RMID"
            Dim GetSteelDataCommand As New SqlCommand(GetSteelDataStatement, con)
            GetSteelDataCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
        
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetSteelDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("Carbon")) Then
                    RowCarbon = ""
                Else
                    RowCarbon = reader.Item("Carbon")
                End If
                If IsDBNull(reader.Item("SteelSize")) Then
                    RowSteelSize = ""
                Else
                    RowSteelSize = reader.Item("SteelSize")
                End If
            Else
                RowCarbon = ""
                RowSteelSize = ""
            End If
            reader.Close()
            con.Close()
            '***************************************************************************************
            Try
                'Update Coil to Closed
                cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Status = @Status, Comment = @Comment WHERE CoilID = @CoilID", con)

                With cmd.Parameters
                    .Add("@CoilID", SqlDbType.VarChar).Value = GetCoilID
                    .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                    .Add("@Comment", SqlDbType.VarChar).Value = "Steel Vendor Return"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip
            End Try
            '****************************************************************************************************
            Try
                'Command to write to GL (Inventory Account)
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Vendor Return"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = RowExtendedAmount
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Steel Vendor " & cboVendorCode.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = RowLineNumber
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Vendor Return --- GL Credit Transaction on POST"
                ErrorReferenceNumber = "Return # " + strReturnNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**********************************************************************************************************************************************
            Try
                'Command to write to GL (Purchase Clearing)
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "20995"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Vendor Return"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = RowExtendedAmount
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Steel Vendor " & cboVendorCode.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = RowLineNumber
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                '******************************************************************************************************************************************
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Vendor Return --- GL Debit Transaction on POST"
                ErrorReferenceNumber = "Return # " + strReturnNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*********************************************************************************************
            Try
                'Create Steel Transaction Entry
                cmd = New SqlCommand("Insert Into SteelTransactionTable (TransactionNumber, DivisionID, SteelTransactionDate, Carbon, SteelSize, Quantity,  SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType) values ((SELECT isnull(MAX(TransactionNumber) + 1, 2200000) FROM SteelTransactionTable), @DivisionID, @SteelTransactionDate, @Carbon, @SteelSize, @Quantity,  @SteelCost, @ExtendedCost, @SteelReferenceNumber, @SteelReferenceLine, @RMID, @TransactionMath, @TransactionType)", con)

                With cmd.Parameters
                    '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@SteelTransactionDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = RowCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSize
                    .Add("@Quantity", SqlDbType.VarChar).Value = RowReturnQuantity
                    .Add("@SteelCost", SqlDbType.VarChar).Value = RowUnitCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = RowExtendedAmount
                    .Add("@SteelReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@SteelReferenceLine", SqlDbType.VarChar).Value = RowLineNumber
                    .Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "VENDOR RETURN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Steel Vendor Return --- Transaction Failure"
                ErrorReferenceNumber = "Return # " + strReturnNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************
            'Create Cost Tier

            'Extract the Upper and Lower Limit of the Inventory Costing Table
            Dim NewUpperLimit, LowerLimit, UpperLimit As Double
            Dim MaxTransactionNumber As Integer = 0
            Dim MAXDate As String = ""

            Dim MAXDateStatement As String = "SELECT MAX(CostingDate) FROM SteelCostingTable WHERE RMID = @RMID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXDate = CStr(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MAXDate = ""
            End Try
            con.Close()

            Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate = @CostingDate"
            Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
            MaxTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
            MaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MAXDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                MaxTransactionNumber = 0
            End Try
            con.Close()
            '**********************************************************************
            Dim UpperLimitStatement As String = "SELECT UpperLimit FROM SteelCostingTable WHERE TransactionNumber = @TransactionNumber AND RMID = @RMID"
            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
            UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
            UpperLimitCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                UpperLimit = 0
            End Try
            con.Close()
            '***********************************************************************
            'Convert quantity to negative for the costing table
            RowReturnQuantity = RowReturnQuantity * -1

            If RowReturnQuantity < 0 Then
                LowerLimit = UpperLimit
                NewUpperLimit = LowerLimit + RowReturnQuantity
            Else
                'Calculate the NEW Lower/Upper Limit for the next post
                LowerLimit = UpperLimit + 1
                NewUpperLimit = LowerLimit + RowReturnQuantity - 1
            End If
            '************************************************************************************************
            Dim NextCostingTransactionNumber, LastCostingTransactionNumber As Integer

            'Get next Transaction Number
            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM SteelCostingTable"
            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastCostingTransactionNumber = 63600000
            End Try
            con.Close()

            NextCostingTransactionNumber = LastCostingTransactionNumber + 1
            '************************************************************************************************
            Try
                'Write Values to Inventory Costing Table
                cmd = New SqlCommand("Insert Into SteelCostingTable (RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, LowerLimit, UpperLimit, Status, TransactionNumber, ReferenceNumber, ReferenceLine)values(@RMID, @Carbon, @SteelSize, @CostingDate, @SteelCostPerPound, @CostingQuantity, @LowerLimit, @UpperLimit, @Status, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                    .Add("@Carbon", SqlDbType.VarChar).Value = RowCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSize
                    .Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                    .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = RowUnitCost
                    .Add("@CostingQuantity", SqlDbType.VarChar).Value = RowReturnQuantity
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@Status", SqlDbType.VarChar).Value = "STEEL VENDOR RETURN"
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = RowLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Vendor Return --- Update costing on POST"
                ErrorReferenceNumber = "Return # " + strReturnNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************
            'Clear variables for next entry in loop
            RowLineNumber = 0
            RowExtendedAmount = 0
            RowRMID = ""
            RowReturnQuantity = 0
            RowUnitCost = 0
            RowCarbon = ""
            RowSteelSize = ""
            GetCoilID = ""
            NewUpperLimit = 0
            LowerLimit = 0
            UpperLimit = 0
            MaxTransactionNumber = 0
            MAXDate = ""
        Next
        '**********************************************************************************************
        'Change Return Line Status to Posted
        Try
            'Update Coil to Closed
            cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

            With cmd.Parameters
                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip
        End Try
        'Change Return Status to Posted
        Try
            'Update Coil to Closed
            cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus, PrintDate = @PrintDate WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip
        End Try
        '**********************************************************************************
        'Clear variables and form
        ClearVariables()
        ClearData()
        ClearDatagrid()

        MsgBox("Steel Return has been posted.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Validate
        If cboReturnNumber.Text = "" Then
            MsgBox("You must select a valid return #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Load Status
        LoadStatus()

        If ReturnStatus = "OPEN" Then
            'Load Return Totals
            LoadReturnTotals()

            Try
                UpdateSteelReturnHeaderTable()
            Catch ex As Exception
                'Error Log

            End Try

            MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Validate
        If cboReturnNumber.Text = "" Then
            MsgBox("You must select a valid return #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Load Status
        LoadStatus()

        If ReturnStatus = "OPEN" Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Vendor Return?", "DELETE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then

                'Insert into database
                cmd = New SqlCommand("DELETE FROM SteelReturnHeaderTable WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Steel return has been deleted.", MsgBoxStyle.OkOnly)

                'Reload Return Numbers
                LoadReturnNumber()

                'Clear form
                ClearVariables()
                ClearData()
                ClearDatagrid()

                cboReturnNumber.Focus()
            ElseIf button = DialogResult.No Then
                cmdDelete.Focus()
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalSteelVendorReturnNumber = Val(cboReturnNumber.Text)

        Using NewPrintSteelVendorReturn As New PrintSteelVendorReturn
            Dim Result = NewPrintSteelVendorReturn.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If cboCarbon.Text = "" Or cboSteelSize.Text = "" Then
            'Do nothing
        Else
            LoadRMID()
            LoadCoilID()
            LoadSteelCost()
            LoadSteelDescription()
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If cboCarbon.Text = "" Or cboSteelSize.Text = "" Then
            'Do nothing
        Else
            LoadRMID()
            LoadCoilID()
            LoadSteelCost()
            LoadSteelDescription()
        End If
    End Sub

    Public Sub InsertIntoSteelReturnHeaderTable()
        'Write to database one time (re-write header information and totals)
        cmd = New SqlCommand("INSERT INTO SteelReturnHeaderTable (SteelReturnNumber, SteelVendor, ReturnDate, ProductTotal, OtherTotal, FreightTotal, ReturnTotal, ReturnComment, ReturnStatus, DivisionID, Locked, UserID, PrintDate) Values (@SteelReturnNumber, @SteelVendor, @ReturnDate, @ProductTotal, @OtherTotal, @FreightTotal, @ReturnTotal, @ReturnComment, @ReturnStatus, @DivisionID, @Locked, @UserID, @PrintDate)", con)

        With cmd.Parameters
            .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@SteelVendor", SqlDbType.VarChar).Value = cboVendorCode.Text
            .Add("@ReturnDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@FreightTotal", SqlDbType.VarChar).Value = FreightTotal
            .Add("@OtherTotal", SqlDbType.VarChar).Value = OtherTotal
            .Add("@ReturnTotal", SqlDbType.VarChar).Value = ReturnTotal
            .Add("@ReturnComment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@PrintDate", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateSteelReturnHeaderTable()
        'Write to database one time (re-write header information and totals)
        cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET SteelVendor = @SteelVendor, ReturnDate = @ReturnDate, ProductTotal = @ProductTotal, OtherTotal = @OtherTotal, FreightTotal = @FreightTotal, ReturnTotal = @ReturnTotal, ReturnComment = @ReturnComment, ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@SteelVendor", SqlDbType.VarChar).Value = cboVendorCode.Text
            .Add("@ReturnDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@FreightTotal", SqlDbType.VarChar).Value = FreightTotal
            .Add("@OtherTotal", SqlDbType.VarChar).Value = OtherTotal
            .Add("@ReturnTotal", SqlDbType.VarChar).Value = ReturnTotal
            .Add("@ReturnComment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@PrintDate", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdGenerateReturnNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateReturnNumber.Click
        ClearData()
        ClearVariables()
        ClearDatagrid()

        'Get next number
        Dim NextTransactionNumber, LastTransactionNumber As Integer

        Dim MAXStatement As String = "SELECT MAX(SteelReturnNumber) FROM SteelReturnHeaderTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 98000000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        cboReturnNumber.Text = NextTransactionNumber

        'Insert into database
        ProductTotal = 0
        OtherTotal = 0
        FreightTotal = 0
        ReturnTotal = 0

        Try
            InsertIntoSteelReturnHeaderTable()
        Catch ex As Exception
            'Error Log

        End Try

        txtStatus.Text = "OPEN"
        cboReturnNumber.Focus()
    End Sub

    Private Sub txtReturnedQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnedQuantity.TextChanged
        Dim LineExtendedAmount, LineUnitCost, LineReturnQuantity As Double

        If txtReturnedQuantity.Text <> "" And txtUnitCost.Text <> "" Then
            LineUnitCost = Val(txtUnitCost.Text)
            LineReturnQuantity = Val(txtReturnedQuantity.Text)

            LineExtendedAmount = LineUnitCost * LineReturnQuantity
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            txtExtendedAmount.Text = LineExtendedAmount
        Else
            'Do nothing
        End If
    End Sub

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        Dim LineExtendedAmount, LineUnitCost, LineReturnQuantity As Double

        If txtReturnedQuantity.Text <> "" And txtUnitCost.Text <> "" Then
            LineUnitCost = Val(txtUnitCost.Text)
            LineReturnQuantity = Val(txtReturnedQuantity.Text)

            LineExtendedAmount = LineUnitCost * LineReturnQuantity
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            txtExtendedAmount.Text = LineExtendedAmount
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cboCoilID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoilID.SelectedIndexChanged
        LoadHeatHumberForCoil()
    End Sub

    Private Sub cboVendorCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorCode.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Private Sub dgvSteelReturnLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelReturnLines.CellValueChanged
        Dim RowReturnQuantity, RowUnitCost, RowExtendedAmount As Double
        Dim RowLineComment As String = ""
        Dim RowLineNumber As Integer = 0

        If Me.dgvSteelReturnLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvSteelReturnLines.CurrentCell.RowIndex

            Try
                RowLineNumber = Me.dgvSteelReturnLines.Rows(RowIndex).Cells("SteelReturnLineColumn").Value
            Catch ex As Exception
                RowLineNumber = 0
            End Try
            Try
                RowReturnQuantity = Me.dgvSteelReturnLines.Rows(RowIndex).Cells("ReturnQuantityColumn").Value
            Catch ex As Exception
                RowReturnQuantity = 0
            End Try
            Try
                RowUnitCost = Me.dgvSteelReturnLines.Rows(RowIndex).Cells("UnitCostColumn").Value
            Catch ex As Exception
                RowUnitCost = 0
            End Try
            Try
                RowLineComment = Me.dgvSteelReturnLines.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                RowLineComment = ""
            End Try

            RowExtendedAmount = RowReturnQuantity * RowUnitCost
            RowExtendedAmount = Math.Round(RowExtendedAmount, 2)

            'Write to database one time (re-write header information and totals)
            cmd = New SqlCommand("UPDATE SteelReturnLineTable SET ReturnQuantity = @ReturnQuantity, UnitCost = @UnitCost, ExtendedCost = @ExtendedCost, LineComment = @LineComment WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

            With cmd.Parameters
                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@SteelReturnLine", SqlDbType.VarChar).Value = RowLineNumber
                .Add("@ReturnQuantity", SqlDbType.VarChar).Value = RowReturnQuantity
                .Add("@UnitCost", SqlDbType.VarChar).Value = RowUnitCost
                .Add("@ExtendedCost", SqlDbType.VarChar).Value = RowExtendedAmount
                .Add("@LineComment", SqlDbType.VarChar).Value = RowLineComment
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Write to database one time (re-write header information and totals)
            cmd = New SqlCommand("UPDATE SteelReturnCoilLines SET CoilWeight = @CoilWeight, CoilCostPerPound = @CoilCostPerPound, CoilExtendedCost = @CoilExtendedCost WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

            With cmd.Parameters
                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@SteelReturnLine", SqlDbType.VarChar).Value = RowLineNumber
                .Add("@CoilWeight", SqlDbType.VarChar).Value = RowReturnQuantity
                .Add("@CoilCostPerPound", SqlDbType.VarChar).Value = RowUnitCost
                .Add("@CoilExtendedCost", SqlDbType.VarChar).Value = RowExtendedAmount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadReturnTotals()
            ShowReturnLines()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        cmdClearAll_Click(sender, e)
    End Sub

    Private Sub ManuallyCloseReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyCloseReturnToolStripMenuItem.Click
        If txtStatus.Text = "POSTED" Then
            'Continue
        ElseIf txtStatus.Text = "OPEN" Then
            MsgBox("This return cannot be closed until it is posted.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Do nothing
        End If

        Try
            'Update return to Closed
            cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus, PrintDate = @PrintDate WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "CLOSED"
                .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip
        End Try

        MsgBox("This return is now closed.", MsgBoxStyle.OkOnly)

        txtStatus.Text = "CLOSED"
    End Sub

    Private Sub UnLockReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockReturnToolStripMenuItem.Click
        Try
            'Update Coil to Closed
            cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET Locked = @Locked WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Locked", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Return is now unlocked.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Skip
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub
End Class