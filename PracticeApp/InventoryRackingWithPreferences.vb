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
Public Class InventoryRackingWithPreferences
    Inherits System.Windows.Forms.Form

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Create Array for Bin Preferences
    Dim BinPreferenceString(18) As String
    Dim LoopCounter As Integer = 0
    Dim TempBinPref As String = ""
    Dim StrLoopCounter As String = ""
    Dim GetRackPrefix As String = ""
    Dim ORStatement As String = ""

    Dim bc As New BarcodeLabel

    'Common Variables
    Dim LineRackNumber As String = ""
    Dim LineDivisionID As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim FormName As String = "Inventory Racking By Preference"
    Dim RackFilter, PartFilter, HeatFilter, LotFilter, PartStartsWithFilter, PartContainsFilter, RackContainsFilter As String
    Dim QOHPartNumber As String = ""
    Dim QOHInventory, QOHRacking, QOHDifference As Double

    Private Sub InventoryRackingWithPreferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)

        'Form Login
        FormLoginRoutine()
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If cboDivisionID.Text = "SLC" Then
            LoadTotalEmptyRacksSLC()
        Else
            LoadTotalEmptyRacks()
        End If
    End Sub

    'Load Datasets

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderLineQueryQO WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "PurchaseOrderLineQueryQO")
        con.Close()
    End Sub

    Public Sub LoadPO()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "PurchaseOrderHeaderTable")
        con.Close()

        cboPurchaseOrderNumber.DataSource = ds1.Tables("PurchaseOrderHeaderTable")
        cboPurchaseOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowDataByFilter()
        If cboPartNumber.Text = "" Then
            PartFilter = ""
        Else
            PartFilter = " AND PartNumber = '" + cboPartNumber.Text + "'"
        End If
        If cboRackNumber.Text = "" Then
            RackFilter = ""
        Else
            RackFilter = " AND BinNumber = '" + cboRackNumber.Text + "'"
        End If
        If txtHeatNumber.Text = "" Then
            HeatFilter = ""
        Else
            HeatFilter = " AND HeatNumber = '" + txtHeatNumber.Text + "'"
        End If
        If txtLotNumber.Text = "" Then
            LotFilter = ""
        Else
            LotFilter = " AND LotNumber = '" + txtLotNumber.Text + "'"
        End If
        If txtPartTextStartsWith.Text = "" Then
            PartStartsWithFilter = ""
        Else
            PartStartsWithFilter = " AND PartNumber LIKE '" + txtPartTextStartsWith.Text + "%'"
        End If
        If txtPartTextContains.Text = "" Then
            PartContainsFilter = ""
        Else
            PartContainsFilter = " AND PartNumber LIKE '%" + txtPartTextContains.Text + "%'"
        End If
        If txtRackTextContains.Text = "" Then
            RackContainsFilter = ""
        Else
            RackContainsFilter = " AND BinNumber LIKE '%" + txtRackTextContains.Text + "%'"
        End If

        cmd = New SqlCommand("SELECT * FROM RackingTransactionQuery WHERE DivisionID = @DivisionID" + RackFilter + PartFilter + HeatFilter + LotFilter + PartStartsWithFilter + PartContainsFilter + RackContainsFilter + " ORDER BY BinNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RackingTransactionQuery")
        dgvInventoryRacking.DataSource = ds.Tables("RackingTransactionQuery")
        con.Close()

        'Lock datagrid field (Pieces Per Box) unless Box Count = 1
        Dim CheckBoxQuantity As Integer = 0

        For Each LineRow As DataGridViewRow In dgvInventoryRacking.Rows
            Try
                CheckBoxQuantity = LineRow.Cells("BoxQuantityColumn").Value
            Catch ex As System.Exception
                CheckBoxQuantity = 1
            End Try

            If CheckBoxQuantity = 1 Then
                LineRow.Cells("PiecesPerBoxColumn").ReadOnly = False
            Else
                LineRow.Cells("PiecesPerBoxColumn").ReadOnly = True
            End If
        Next

        LoadTotals()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvInventoryRacking.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE ItemClass <> 'DEACTIVATED-PART' AND  DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE ItemClass <> 'DEACTIVATED-PART' AND DivisionID = @DivisionID AND SalesProdLineID <> @SalesProdLineID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadAddPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE ItemClass <> 'DEACTIVATED-PART' AND DivisionID = @DivisionID AND SalesProdLineID <> @SalesProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboAddToPartNumber.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboAddToPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadAddPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE ItemClass <> 'DEACTIVATED-PART' AND DivisionID = @DivisionID AND SalesProdLineID <> @SalesProdLineID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboAddToPartDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboAddToPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadBinNumber()
        cmd = New SqlCommand("SELECT BinNumber FROM BinNumber WHERE RackPosition <> 'UNAVAILABLE' AND DivisionID = @DivisionID ORDER BY BinNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "BinNumber")
        cboRackNumber.DataSource = ds5.Tables("BinNumber")
        con.Close()
        cboRackNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadRackContents()
        cmd = New SqlCommand("SELECT * FROM RackingTransactionQuery WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = LineRackNumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "RackingTransactionQuery")
        dgvRackContents.DataSource = ds7.Tables("RackingTransactionQuery")
        con.Close()
        dgvRackContents.Visible = True
        lblRackNumber.Visible = True
    End Sub

    'Public Sub LoadAllAddToBinNumbers()
    '    cmd = New SqlCommand("SELECT BinNumber FROM BinNumber WHERE RackPosition <> 'UNAVAILABLE' AND DivisionID = @DivisionID ORDER BY BinNumber", con)
    '    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
    '    If con.State = ConnectionState.Closed Then con.Open()
    '    ds6 = New DataSet()
    '    myAdapter6.SelectCommand = cmd
    '    myAdapter6.Fill(ds6, "BinNumber")
    '    cboAddToRackNumber.DataSource = ds6.Tables("BinNumber")
    '    con.Close()
    '    cboAddToRackNumber.SelectedIndex = -1
    'End Sub

    'Public Sub LoadEmptyAddToBinNumbers()
    '    cmd = New SqlCommand("SELECT BinNumber FROM EmptyBinQuerySLC WHERE RackPosition <> 'UNAVAILABLE' AND DivisionID = @DivisionID AND RackContent = @RackContent ORDER BY BinNumber", con)
    '    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
    '    cmd.Parameters.Add("@RackContent", SqlDbType.VarChar).Value = 0
    '    If con.State = ConnectionState.Closed Then con.Open()
    '    ds6 = New DataSet()
    '    myAdapter6.SelectCommand = cmd
    '    myAdapter6.Fill(ds6, "BinNumber")
    '    cboAddToRackNumber.DataSource = ds6.Tables("BinNumber")
    '    con.Close()
    '    cboAddToRackNumber.SelectedIndex = -1
    'End Sub

    'Public Sub LoadEmptyAddToBinNumbersByPreference()
    '    cmd = New SqlCommand("SELECT BinNumber FROM EmptyBinQuerySLC WHERE RackPosition <> 'UNAVAILABLE' AND DivisionID = @DivisionID AND RackContent = @RackContent ORDER BY BinNumber", con)
    '    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
    '    cmd.Parameters.Add("@RackContent", SqlDbType.VarChar).Value = 0
    '    If con.State = ConnectionState.Closed Then con.Open()
    '    ds6 = New DataSet()
    '    myAdapter6.SelectCommand = cmd
    '    myAdapter6.Fill(ds6, "BinNumber")
    '    cboAddToRackNumber.DataSource = ds6.Tables("BinNumber")
    '    con.Close()
    'End Sub

    'Load Data Routines

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadPartByDescriptionADD()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboAddToPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboAddToPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPartADD()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAddToPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboAddToPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadTotals()
        If Me.dgvInventoryRacking.RowCount > 0 Then
            Dim QOHDivision As String = ""

            Dim RowIndex As Integer = Me.dgvInventoryRacking.CurrentCell.RowIndex

            Try
                QOHPartNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                QOHPartNumber = ""
            End Try
            Try
                QOHDivision = Me.dgvInventoryRacking.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                QOHDivision = ""
            End Try

            Dim QOHRackingString As String = "SELECT SUM(TotalPieces) FROM RackingTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim QOHRackingCommand As New SqlCommand(QOHRackingString, con)
            QOHRackingCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = QOHPartNumber
            QOHRackingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = QOHDivision

            Dim QOHInventoryString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim QOHInventoryCommand As New SqlCommand(QOHInventoryString, con)
            QOHInventoryCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = QOHPartNumber
            QOHInventoryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = QOHDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                QOHRacking = CDbl(QOHRackingCommand.ExecuteScalar)
            Catch ex As Exception
                QOHRacking = 0
            End Try
            Try
                QOHInventory = CDbl(QOHInventoryCommand.ExecuteScalar)
            Catch ex As Exception
                QOHInventory = 0
            End Try
            con.Close()

            QOHDifference = QOHInventory - QOHRacking

            lblPartNumber.Text = QOHPartNumber
            lblDifference.Text = QOHDifference
            lblQOH.Text = QOHInventory
            lblQuantityInRack.Text = QOHRacking
        End If
    End Sub

    Public Sub LoadPartDataByLotNumber()
        Dim GetPiecesPerBox As Integer = 0
        Dim GetPieceWeight As Double = 0
        Dim GetHeatNumber As String = ""
        Dim GetPartNumber As String = ""
        Dim GetBoxWeight As Double = 0
        Dim GetPalletCount As Integer = 0

        Dim GetPartDataStatement As String = "SELECT PieceWeight, BoxCount, PalletCount, HeatNumber, PartNumber, BoxWeight FROM LotNumber WHERE LotNumber = @LotNumber AND DivisionID = @DivisionID"
        Dim GetPartDataCommand As New SqlCommand(GetPartDataStatement, con)
        GetPartDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        GetPartDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtAddLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPartDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("BoxCount")) Then
                GetPiecesPerBox = 0
            Else
                GetPiecesPerBox = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                GetPieceWeight = 0
            Else
                GetPieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                GetHeatNumber = ""
            Else
                GetHeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                GetPartNumber = ""
            Else
                GetPartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                GetBoxWeight = 0
            Else
                GetBoxWeight = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                GetPalletCount = 0
            Else
                GetPalletCount = reader.Item("PalletCount")
            End If
        Else
            GetPiecesPerBox = 0
            GetPieceWeight = 0
            GetHeatNumber = ""
            GetPartNumber = ""
            GetBoxWeight = 0
            GetPalletCount = 0
        End If
        reader.Close()
        con.Close()

        'Load Part Nunber first, then part data from Lot Number
        cboAddToPartNumber.Text = GetPartNumber
        txtBoxQuantity.Text = GetPalletCount
        txtAddBoxWeight.Text = GetBoxWeight
        txtAddHeatNumber.Text = GetHeatNumber
        txtPieceWeight.Text = GetPieceWeight
        txtPiecesPerBox.Text = GetPiecesPerBox
    End Sub

    Public Sub LoadPartDataByPartNumber()
        Dim GetPiecesPerBox As Integer = 0
        Dim GetPieceWeight As Double = 0
        Dim GetBoxWeight As Double = 0
        Dim GetPalletCount As Integer = 0

        Dim GetPartDataStatement As String = "SELECT PieceWeight, BoxCount, PalletCount, BoxWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetPartDataCommand As New SqlCommand(GetPartDataStatement, con)
        GetPartDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetPartDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAddToPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPartDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("BoxCount")) Then
                GetPiecesPerBox = 0
            Else
                GetPiecesPerBox = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                GetPieceWeight = 0
            Else
                GetPieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                GetBoxWeight = 0
            Else
                GetBoxWeight = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                GetPalletCount = 0
            Else
                GetPalletCount = reader.Item("PalletCount")
            End If
        Else
            GetPiecesPerBox = 0
            GetPieceWeight = 0
            GetBoxWeight = 0
            GetPalletCount = 0
        End If
        reader.Close()
        con.Close()

        txtAddBoxWeight.Text = GetBoxWeight
        txtPiecesPerBox.Text = GetPiecesPerBox
        txtBoxQuantity.Text = GetPalletCount
        txtPieceWeight.Text = GetPieceWeight
    End Sub

    Public Sub LoadTotalEmptyRacks()
        Dim TotalEmptyRacks As Integer = 0

        Dim TotalEmptyRacksStatement As String = "SELECT COUNT(BinNumber) FROM EmptyBinQuery WHERE DivisionID = @DivisionID AND RackContent = @RackContent AND RackPosition <> @RackPosition"
        Dim TotalEmptyRacksCommand As New SqlCommand(TotalEmptyRacksStatement, con)
        TotalEmptyRacksCommand.Parameters.Add("@RackContent", SqlDbType.VarChar).Value = 0
        TotalEmptyRacksCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalEmptyRacksCommand.Parameters.Add("@RackPosition", SqlDbType.VarChar).Value = "UNAVAILABLE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalEmptyRacks = CInt(TotalEmptyRacksCommand.ExecuteScalar)
        Catch ex As Exception
            TotalEmptyRacks = 0
        End Try
        con.Close()

        lblEmptyRacks.Text = TotalEmptyRacks
    End Sub

    Public Sub LoadTotalEmptyRacksSLC()
        Dim TotalEmptyRacks As Integer = 0

        Dim TotalEmptyRacksStatement As String = "SELECT COUNT(BinNumber) FROM EmptyBinQuerySLC WHERE DivisionID = @DivisionID AND RackContent = @RackContent AND RackPosition <> @RackPosition"
        Dim TotalEmptyRacksCommand As New SqlCommand(TotalEmptyRacksStatement, con)
        TotalEmptyRacksCommand.Parameters.Add("@RackContent", SqlDbType.VarChar).Value = 0
        TotalEmptyRacksCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalEmptyRacksCommand.Parameters.Add("@RackPosition", SqlDbType.VarChar).Value = "UNAVAILABLE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalEmptyRacks = CInt(TotalEmptyRacksCommand.ExecuteScalar)
        Catch ex As Exception
            TotalEmptyRacks = 0
        End Try
        con.Close()

        lblEmptyRacks.Text = TotalEmptyRacks
    End Sub

    Public Sub LoadTotalEmptyRacksTFF()
        Dim TotalEmptyRacks As Integer = 0

        Dim TotalEmptyRacksStatement As String = "SELECT COUNT(BinNumber) FROM EmptyBinQuerySLC WHERE DivisionID = @DivisionID AND RackContent = @RackContent AND RackPosition <> @RackPosition"
        Dim TotalEmptyRacksCommand As New SqlCommand(TotalEmptyRacksStatement, con)
        TotalEmptyRacksCommand.Parameters.Add("@RackContent", SqlDbType.VarChar).Value = 0
        TotalEmptyRacksCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalEmptyRacksCommand.Parameters.Add("@RackPosition", SqlDbType.VarChar).Value = "UNAVAILABLE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalEmptyRacks = CInt(TotalEmptyRacksCommand.ExecuteScalar)
        Catch ex As Exception
            TotalEmptyRacks = 0
        End Try
        con.Close()

        lblEmptyRacks.Text = TotalEmptyRacks
    End Sub

    Public Sub LoadRackPreference()
        Dim PartPrefix As String = ""

        Dim PartPrefixStatement As String = "SELECT BinPreference FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartPrefixCommand As New SqlCommand(PartPrefixStatement, con)
        PartPrefixCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAddToPartNumber.Text
        PartPrefixCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartPrefix = CStr(PartPrefixCommand.ExecuteScalar)
        Catch ex As Exception
            PartPrefix = ""
        End Try
        con.Close()

        If PartPrefix = "" Then
            'Skiip Rack Presference and leave blank.
            Exit Sub
        End If
        '*******************************************************************
        If rdoAddPallet.Checked = True And cboAddToPartNumber.Text <> "" Then
            'Load Rack Preferences by Pallet (Empty Bins Only)

            'Fill Array for Rack Preferences (Pref01 to Pref18)
            LoopCounter = 1

            For i As Integer = 1 To 18

                If LoopCounter < 10 Then
                    StrLoopCounter = "0" + CStr(LoopCounter)
                Else
                    StrLoopCounter = CStr(LoopCounter)
                End If

                TempBinPref = "Pref" + StrLoopCounter

                Dim GetRackPrefixStatement As String = "SELECT " + TempBinPref + " FROM BinPrefLocation WHERE RowName = @RowName AND DivisionID = @DivisionID"
                Dim GetRackPrefixCommand As New SqlCommand(GetRackPrefixStatement, con)
                GetRackPrefixCommand.Parameters.Add("@RowName", SqlDbType.VarChar).Value = PartPrefix
                GetRackPrefixCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetRackPrefix = CStr(GetRackPrefixCommand.ExecuteScalar)
                Catch ex As Exception
                    GetRackPrefix = ""
                End Try
                con.Close()

                BinPreferenceString(LoopCounter) = GetRackPrefix

                'Clear Temp Variables
                GetRackPrefix = ""
                StrLoopCounter = ""
                TempBinPref = ""

                LoopCounter = LoopCounter + 1
            Next

            'Get Empty Bins for all Bin Preferences in the array

            'Create Compound OR Statement based on Bin Preferences in the array
            ORStatement = "(BinNumber LIKE '" + BinPreferenceString(1) + "%' OR BinNumber LIKE '" + BinPreferenceString(2) + "%' OR BinNumber LIKE '" + BinPreferenceString(3) + "%' OR BinNumber LIKE '" + BinPreferenceString(4) + "%' OR BinNumber LIKE '" + BinPreferenceString(5) + "%' OR BinNumber LIKE '" + BinPreferenceString(6) + "%' OR BinNumber LIKE '" + BinPreferenceString(7) + "%' OR BinNumber LIKE '" + BinPreferenceString(8) + "%' OR BinNumber LIKE '" + BinPreferenceString(9) + "%' OR BinNumber LIKE '" + BinPreferenceString(10) + "%'OR BinNumber LIKE '" + BinPreferenceString(11) + "%'OR BinNumber LIKE '" + BinPreferenceString(12) + "%'OR BinNumber LIKE '" + BinPreferenceString(13) + "%'OR BinNumber LIKE '" + BinPreferenceString(14) + "%'OR BinNumber LIKE '" + BinPreferenceString(15) + "%'OR BinNumber LIKE '" + BinPreferenceString(16) + "%'OR BinNumber LIKE '" + BinPreferenceString(17) + "%'OR BinNumber LIKE '" + BinPreferenceString(18) + "%')"

            'cboAddToRackNumber.DataSource = Nothing

            cmd = New SqlCommand("SELECT BinNumber FROM EmptyBinQuerySLC WHERE RackPosition <> 'UNAVAILABLE' AND DivisionID = @DivisionID AND RackContent = @RackContent AND " + ORStatement + " ORDER BY BinNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@RackContent", SqlDbType.VarChar).Value = 0
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "EmptyBinQuerySLC")
            cboAddToRackNumber.DataSource = ds6.Tables("EmptyBinQuerySLC")
            con.Close()

            If cboAddToPartNumber.Text = "" Then
                cboAddToRackNumber.SelectedIndex = -1
            Else
                cboAddToRackNumber.SelectedIndex = 1
            End If
        ElseIf rdoAddBoxes.Checked = True And cboAddToPartNumber.Text <> "" Then
            'Load Rack Preferences by Boxes (Empty Bins and Partial Bins)

            'Fill Array for Rack Preferences (Pref01 to Pref18)
            LoopCounter = 1

            For i As Integer = 1 To 18

                If LoopCounter < 10 Then
                    StrLoopCounter = "0" + CStr(LoopCounter)
                Else
                    StrLoopCounter = CStr(LoopCounter)
                End If

                TempBinPref = "Pref" + StrLoopCounter

                Dim GetRackPrefixStatement As String = "SELECT " + TempBinPref + " FROM BinPrefLocation WHERE RowName = @RowName AND DivisionID = @DivisionID"
                Dim GetRackPrefixCommand As New SqlCommand(GetRackPrefixStatement, con)
                GetRackPrefixCommand.Parameters.Add("@RowName", SqlDbType.VarChar).Value = PartPrefix
                GetRackPrefixCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetRackPrefix = CStr(GetRackPrefixCommand.ExecuteScalar)
                Catch ex As Exception
                    GetRackPrefix = ""
                End Try
                con.Close()

                BinPreferenceString(LoopCounter) = GetRackPrefix

                'Clear Temp Variables
                GetRackPrefix = ""
                StrLoopCounter = ""
                TempBinPref = ""

                LoopCounter = LoopCounter + 1
            Next

            'Get Bins that are not full to display


            'Create Compound OR Statement based on Bin Preferences in the array
            ORStatement = "(BinNumber LIKE '" + BinPreferenceString(1) + "%' OR BinNumber LIKE '" + BinPreferenceString(2) + "%' OR BinNumber LIKE '" + BinPreferenceString(3) + "%' OR BinNumber LIKE '" + BinPreferenceString(4) + "%' OR BinNumber LIKE '" + BinPreferenceString(5) + "%' OR BinNumber LIKE '" + BinPreferenceString(6) + "%' OR BinNumber LIKE '" + BinPreferenceString(7) + "%' OR BinNumber LIKE '" + BinPreferenceString(8) + "%' OR BinNumber LIKE '" + BinPreferenceString(9) + "%' OR BinNumber LIKE '" + BinPreferenceString(10) + "%'OR BinNumber LIKE '" + BinPreferenceString(11) + "%'OR BinNumber LIKE '" + BinPreferenceString(12) + "%'OR BinNumber LIKE '" + BinPreferenceString(13) + "%'OR BinNumber LIKE '" + BinPreferenceString(14) + "%'OR BinNumber LIKE '" + BinPreferenceString(15) + "%'OR BinNumber LIKE '" + BinPreferenceString(16) + "%'OR BinNumber LIKE '" + BinPreferenceString(17) + "%'OR BinNumber LIKE '" + BinPreferenceString(18) + "%')"

            'cboAddToRackNumber.DataSource = Nothing

            cmd = New SqlCommand("SELECT * FROM BinRackingWeightDetailsSLC WHERE RackPosition <> 'UNAVAILABLE' AND DivisionID = @DivisionID AND BarWeightOpen > @BarWeightOpen AND " + ORStatement + " ORDER BY BinNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BarWeightOpen", SqlDbType.VarChar).Value = 0
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "BinRackingWeightDetailsSLC")
            dgvSuggestedRacks.DataSource = ds6.Tables("BinRackingWeightDetailsSLC")
            con.Close()

            Dim RowIndex As Integer = 0

            'Run A FOR/EACH Loop on Datagrid to load Box Count
            For Each LineRow As DataGridViewRow In dgvSuggestedRacks.Rows
                Dim TempLineRackNumber As String = ""
                Dim TempLineDivision As String = ""

                Try
                    TempLineRackNumber = LineRow.Cells("BinNumberColumn22").Value
                Catch ex As System.Exception
                    TempLineRackNumber = ""
                End Try
                Try
                    TempLineDivision = LineRow.Cells("DivisionIDColumn22").Value
                Catch ex As System.Exception
                    TempLineRackNumber = ""
                End Try

                Dim SUMTotalBoxes As Double = 0

                Dim SUMTotalBoxesStatement As String = "SELECT SUM(BoxQuantity) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
                Dim SUMTotalBoxesCommand As New SqlCommand(SUMTotalBoxesStatement, con)
                SUMTotalBoxesCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = TempLineRackNumber
                SUMTotalBoxesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = TempLineDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SUMTotalBoxes = CDbl(SUMTotalBoxesCommand.ExecuteScalar)
                Catch ex As Exception
                    SUMTotalBoxes = 0
                End Try
                con.Close()

                If SUMTotalBoxes = 0 Then
                    Me.dgvSuggestedRacks.Rows(RowIndex).Cells("NumberOfBoxesColumn22").Value = "EMPTY"
                Else
                    Me.dgvSuggestedRacks.Rows(RowIndex).Cells("NumberOfBoxesColumn22").Value = SUMTotalBoxes
                End If

                SUMTotalBoxes = 0
                TempLineDivision = ""
                TempLineRackNumber = ""
                RowIndex = RowIndex + 1
            Next

            If cboAddToPartNumber.Text = "" Then
                cboAddToRackNumber.SelectedIndex = -1
            Else

            End If

            Label22.Visible = True
            dgvSuggestedRacks.Visible = True

        Else
            'Load All Racks

        End If
    End Sub


    'Error checking / Clear / Login Routines

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

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), &HF060, 1)
            Case &HFFFFFFFF
        End Select
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

    Public Sub FormLoginRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LoginTime", SqlDbType.VarChar).Value = strTodaysTime
            .Add("@LogoutDate", SqlDbType.VarChar).Value = ""
            .Add("@LogoutTime", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub FormLogoutRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = ""
            .Add("@LoginTime", SqlDbType.VarChar).Value = ""
            .Add("@LogoutDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LogoutTime", SqlDbType.VarChar).Value = strTodaysTime
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub













    ' Combo Box / Text Box Events

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        LoadAddPartNumber()
        LoadAddPartDescription()
        LoadBinNumber()
        LoadPO()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboAddToPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddToPartNumber.SelectedIndexChanged
        Me.dgvRackContents.DataSource = Nothing
        lblRackNumber.Text = ""

        If cboAddToPartNumber.Text <> "" Then
            LoadPartDataByPartNumber()
            LoadDescriptionByPartADD()

            LoadRackPreference()
        Else
            txtPiecesPerBox.Clear()
            txtPieceWeight.Clear()
            txtHeatNumber.Clear()
            txtBoxQuantity.Clear()

            txtAddRackingWeight.Text = ""
            txtAddTotalPieces.Text = ""
            cboAddToRackNumber.SelectedIndex = -1
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadRackPreference()
    End Sub

    Private Sub cboAddToPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddToPartDescription.SelectedIndexChanged
        LoadPartByDescriptionADD()
    End Sub

    Private Sub txtAddLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddLotNumber.TextChanged
        If txtAddLotNumber.Text <> "" Then
            Dim TempLotNumber As String = ""
            Dim TextLength As Integer = 0

            TempLotNumber = txtAddLotNumber.Text

            If TempLotNumber.StartsWith("S") Then
                TextLength = TempLotNumber.Length
                TempLotNumber = TempLotNumber.Substring(1, TextLength - 1)
                txtAddLotNumber.Text = TempLotNumber
            End If

            LoadPartDataByLotNumber()
        End If
    End Sub

    Private Sub txtBoxQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxQuantity.TextChanged
        If txtBoxQuantity.Text <> "" And txtPiecesPerBox.Text <> "" Then
            Dim TempBoxQuantity As Integer = 0
            Dim TempPieces As Integer = 0
            Dim TempTotalPieces As Integer = 0
            Dim TempPieceWeight As Double = 0
            Dim TempTotalWeight As Double = 0
            Dim TempBoxWeight As Double = 0

            TempBoxQuantity = Val(txtBoxQuantity.Text)
            TempPieces = Val(txtPiecesPerBox.Text)
            TempPieceWeight = Val(txtPieceWeight.Text)
            TempBoxWeight = Val(txtAddBoxWeight.Text)

            If Val(txtAddBoxWeight.Text) = 0 Then
                'Calculate Box Weight from Piece Weight
                TempBoxWeight = TempPieceWeight * TempPieces
                TempBoxWeight = Math.Round(TempBoxWeight, 0)
                txtAddBoxWeight.Text = TempBoxWeight
            End If

            TempTotalPieces = TempBoxQuantity * TempPieces
            TempTotalWeight = TempBoxWeight * TempBoxQuantity
            TempTotalWeight = Math.Round(TempTotalWeight, 0)

            txtAddTotalPieces.Text = TempTotalPieces
            txtAddRackingWeight.Text = TempTotalWeight
        End If
    End Sub

    Private Sub txtPiecesPerBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiecesPerBox.TextChanged
        If txtBoxQuantity.Text <> "" And txtPiecesPerBox.Text <> "" Then
            Dim TempBoxQuantity As Integer = 0
            Dim TempPieces As Integer = 0
            Dim TempTotalPieces As Integer = 0
            Dim TempPieceWeight As Double = 0
            Dim TempTotalWeight As Double = 0
            Dim TempBoxWeight As Double = 0

            TempBoxQuantity = Val(txtBoxQuantity.Text)
            TempPieces = Val(txtPiecesPerBox.Text)
            TempPieceWeight = Val(txtPieceWeight.Text)
            TempBoxWeight = Val(txtAddBoxWeight.Text)

            If Val(txtAddBoxWeight.Text) = 0 Then
                'Calculate Box Weight from Piece Weight
                TempBoxWeight = TempPieceWeight * TempPieces
                TempBoxWeight = Math.Round(TempBoxWeight, 0)
                txtAddBoxWeight.Text = TempBoxWeight
            End If

            TempTotalPieces = TempBoxQuantity * TempPieces
            TempTotalWeight = TempBoxWeight * TempBoxQuantity
            TempTotalWeight = Math.Round(TempTotalWeight, 0)

            txtAddTotalPieces.Text = TempTotalPieces
            txtAddRackingWeight.Text = TempTotalWeight
        End If
    End Sub

    Private Sub txtPieceWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPieceWeight.TextChanged
        If Val(txtPieceWeight.Text) <> 0 And Val(txtAddBoxWeight.Text) = 0 And Val(txtPiecesPerBox.Text) <> 0 Then
            'Load Box Weight from piece weight
            Dim TempPieceWeight As Double = 0
            Dim TempBoxWeight As Double = 0
            Dim TempPiecesPerBox As Integer = 0

            TempPieceWeight = Val(txtPieceWeight.Text)
            TempPiecesPerBox = Val(txtPiecesPerBox.Text)
            TempBoxWeight = TempPieceWeight * TempPiecesPerBox
            TempBoxWeight = Math.Round(TempBoxWeight, 0)
            txtAddBoxWeight.Text = TempBoxWeight
        End If
    End Sub

    Private Sub txtAddBoxWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddBoxWeight.TextChanged
        If Val(txtBoxQuantity.Text) <> 0 And Val(txtAddBoxWeight.Text) <> 0 Then
            Dim TempBoxCount As Integer = 0
            Dim TempBoxWeight As Double = 0
            Dim TempTotalWeight As Double = 0

            TempBoxCount = Val(txtBoxQuantity.Text)
            TempBoxWeight = Val(txtAddBoxWeight.Text)
            TempTotalWeight = TempBoxCount * TempBoxWeight
            TempTotalWeight = Math.Round(TempTotalWeight, 0)
            txtAddRackingWeight.Text = TempTotalWeight
        End If
    End Sub

    'Command Button Events

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If Me.dgvInventoryRacking.RowCount > 0 Then
            Dim RowTransactionKey As Integer = 0
            Dim RowDivision As String = ""
            Dim RowBinNumber As String = ""
            Dim RowPartNumber As String = ""
            Dim RowHeatNumber As String = ""
            Dim RowLotNumber As String = ""
            Dim RowTotalPieces As Integer = 0

            'Get Line Data
            Dim RowIndex As Integer = Me.dgvInventoryRacking.CurrentCell.RowIndex

            Try
                RowTransactionKey = Me.dgvInventoryRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value
            Catch ex As Exception
                RowTransactionKey = 0
            End Try
            Try
                RowDivision = Me.dgvInventoryRacking.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try
            Try
                RowPartNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowBinNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("BinNumberColumn").Value
            Catch ex As Exception
                RowBinNumber = ""
            End Try
            Try
                RowHeatNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("HeatNumberColumn").Value
            Catch ex As Exception
                RowHeatNumber = ""
            End Try
            Try
                RowLotNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("LotNumberColumn").Value
            Catch ex As Exception
                RowLotNumber = ""
            End Try
            Try
                RowTotalPieces = Me.dgvInventoryRacking.Rows(RowIndex).Cells("TotalPiecesColumn").Value
            Catch ex As Exception
                RowTotalPieces = 0
            End Try

            Dim button As DialogResult = MessageBox.Show("Are you sure that you want to delete this line?", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    'Delete from Racking Transaction Table
                    cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE RackingKey = @RackingKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@RackingKey", SqlDbType.VarChar).Value = RowTransactionKey
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log

                End Try

                'Update Racking Activity Log
                Try
                    'Get Time and Date
                    Dim TodaysDate As Date = Now()
                    Dim intHours, intMinutes, intSeconds As Integer
                    Dim strHours, strMinutes, strSeconds As String
                    Dim RackTime As String = ""
                    Dim RackDate As String = ""

                    intHours = TodaysDate.Hour
                    intMinutes = TodaysDate.Minute
                    intSeconds = TodaysDate.Second

                    strHours = CStr(intHours)
                    strMinutes = CStr(intMinutes)
                    strSeconds = CStr(intSeconds)

                    RackTime = strHours + ":" + strMinutes + ":" + strSeconds
                    RackDate = TodaysDate.ToString()

                    cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate) values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate)", con)

                    With cmd.Parameters
                        .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                        .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                        .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                        .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                        .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = 0
                        .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = RowTotalPieces * (-1)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@TransactionType", SqlDbType.VarChar).Value = "DELETED"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = RowTransactionKey
                        .Add("@RackTime", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@RackDate", SqlDbType.VarChar).Value = RowTransactionKey
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip activity Log
                End Try

                ShowDataByFilter()

                If cboDivisionID.Text = "SLC" Then
                    LoadTotalEmptyRacksSLC()
                Else
                    LoadTotalEmptyRacks()
                End If
            ElseIf button = DialogResult.No Then
                cmdDeleteLine.Focus()
            End If
        End If
    End Sub

    Private Sub cmdDeleteRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRack.Click
        If Me.dgvInventoryRacking.RowCount > 0 Then
            Dim RowTransactionKey As Integer = 0
            Dim RowDivision As String = ""
            Dim RowBinNumber As String = ""
            Dim RowPartNumber As String = ""
            Dim RowHeatNumber As String = ""
            Dim RowLotNumber As String = ""
            Dim RowTotalPieces As Integer = 0

            'Get Line Data
            Dim RowIndex As Integer = Me.dgvInventoryRacking.CurrentCell.RowIndex

            Try
                RowTransactionKey = Me.dgvInventoryRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value
            Catch ex As Exception
                RowTransactionKey = 0
            End Try
            Try
                RowDivision = Me.dgvInventoryRacking.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try
            Try
                RowPartNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowBinNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("BinNumberColumn").Value
            Catch ex As Exception
                RowBinNumber = ""
            End Try
            Try
                RowHeatNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("HeatNumberColumn").Value
            Catch ex As Exception
                RowHeatNumber = ""
            End Try
            Try
                RowLotNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("LotNumberColumn").Value
            Catch ex As Exception
                RowLotNumber = ""
            End Try
            Try
                RowTotalPieces = Me.dgvInventoryRacking.Rows(RowIndex).Cells("TotalPiecesColumn").Value
            Catch ex As Exception
                RowTotalPieces = 0
            End Try

            Dim button As DialogResult = MessageBox.Show("Are you sure that you want to delete this entire rack?", "DELETE RACK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    'Delete from Racking Transaction Table
                    cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                End Try

                'Update Racking Activity Log
                Try
                    'Get Time and Date
                    Dim TodaysDate As Date = Now()
                    Dim intHours, intMinutes, intSeconds As Integer
                    Dim strHours, strMinutes, strSeconds As String
                    Dim RackTime As String = ""
                    Dim RackDate As String = ""

                    intHours = TodaysDate.Hour
                    intMinutes = TodaysDate.Minute
                    intSeconds = TodaysDate.Second

                    strHours = CStr(intHours)
                    strMinutes = CStr(intMinutes)
                    strSeconds = CStr(intSeconds)

                    RackTime = strHours + ":" + strMinutes + ":" + strSeconds
                    RackDate = TodaysDate.ToString()

                    cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate) values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate)", con)

                    With cmd.Parameters
                        .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                        .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                        .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                        .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                        .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = 0
                        .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = RowTotalPieces * (-1)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@TransactionType", SqlDbType.VarChar).Value = "DELETED"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = RowTransactionKey
                        .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                        .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip activity Log
                End Try

                ShowDataByFilter()

                If cboDivisionID.Text = "SLC" Then
                    LoadTotalEmptyRacksSLC()
                Else
                    LoadTotalEmptyRacks()
                End If
            ElseIf button = DialogResult.No Then
                cmdDeleteRack.Focus()
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        FormLogoutRoutine()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilter()

        If cboDivisionID.Text = "SLC" Then
            LoadTotalEmptyRacksSLC()
        Else
            LoadTotalEmptyRacks()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboRackNumber.SelectedIndex = -1
        txtHeatNumber.Clear()
        txtLotNumber.Clear()
        txtPartTextContains.Clear()
        txtPartTextStartsWith.Clear()
        txtRackTextContains.Clear()

        lblDifference.Clear()
        lblPartNumber.Clear()
        lblQOH.Clear()
        lblQuantityInRack.Clear()

        ClearDataInDatagrid()
        cboPartNumber.Focus()

        If cboDivisionID.Text = "SLC" Then
            LoadTotalEmptyRacksSLC()
        Else
            LoadTotalEmptyRacks()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalPrintRackingType = "PrintListing"
        GDS = ds

        Using NewPrintRackingByFilter As New PrintRackingByFilter
            Dim Result = NewPrintRackingByFilter.ShowDialog()
        End Using
    End Sub

    Private Sub cmdClearAddToRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAddToRack.Click
        cboAddToPartDescription.SelectedIndex = -1
        cboAddToPartNumber.SelectedIndex = -1
        cboAddToRackNumber.SelectedIndex = -1

        dgvSuggestedRacks.DataSource = Nothing
        dgvRackContents.DataSource = Nothing

        txtAddHeatNumber.Clear()
        txtAddLotNumber.Clear()
        txtAddRackingWeight.Text = ""
        txtAddTotalPieces.Text = ""
        txtBoxQuantity.Clear()
        txtPiecesPerBox.Clear()
        txtPieceWeight.Clear()
        txtAddBoxWeight.Clear()
        txtRackComment.Clear()

        lblRackNumber.Text = ""

        If rdoAddPallet.Checked = True Then
            dgvSuggestedRacks.Visible = False
            dgvRackContents.Visible = False
            Label22.Visible = False
            lblRackNumber.Visible = False
        Else
            dgvRackContents.Visible = False
            lblRackNumber.Visible = False
        End If

        If cboDivisionID.Text = "SLC" Then
            LoadTotalEmptyRacksSLC()
        Else
            LoadTotalEmptyRacks()
        End If

        txtAddLotNumber.Focus()
    End Sub

    Private Sub cmdAddToRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToRack.Click
        'Validation - check part number, rack number

        Dim CheckPartNumber As Integer = 0

        Dim CheckPartNumberString As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CheckPartNumberCommand As New SqlCommand(CheckPartNumberString, con)
        CheckPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAddToPartNumber.Text
        CheckPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPartNumber = CInt(CheckPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPartNumber = 0
        End Try
        con.Close()

        If CheckPartNumber = 0 Then
            MsgBox("Part Number does not exist in this division.", MsgBoxStyle.OkOnly)
            Exit Sub
            cboAddToPartNumber.Focus()
        End If
        '****************************************************************************************
        Dim CheckRackNumber As Integer = 0

        Dim CheckRackNumberString As String = "SELECT COUNT(BinNumber) FROM BinNumber WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID AND RackPosition <> @RackPosition"
        Dim CheckRackNumberCommand As New SqlCommand(CheckRackNumberString, con)
        CheckRackNumberCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboAddToRackNumber.Text
        CheckRackNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CheckRackNumberCommand.Parameters.Add("@RackPosition", SqlDbType.VarChar).Value = "UNAVAILABLE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckRackNumber = CInt(CheckRackNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckRackNumber = 0
        End Try
        con.Close()

        If CheckRackNumber = 0 Then
            MsgBox("Bin Number does not exist or is unavailable.", MsgBoxStyle.OkOnly)
            Exit Sub
            cboAddToPartNumber.Focus()
        End If
        '****************************************************************************************
        If cboAddToPartNumber.Text = "" Or cboAddToPartDescription.Text = "" Or txtBoxQuantity.Text = "" Or txtPiecesPerBox.Text = "" Then
            MsgBox("One or more fields are empty.", MsgBoxStyle.OkOnly)
            Exit Sub
            cboAddToPartNumber.Focus()
        End If
        If Val(txtAddBoxWeight.Text) = 0 Or Val(txtBoxQuantity.Text) = 0 Or Val(txtPiecesPerBox.Text) = 0 Or Val(txtAddRackingWeight.Text) = 0 Or Val(txtAddTotalPieces.Text) = 0 Then
            MsgBox("One or more required fields are zero.", MsgBoxStyle.OkOnly)
            Exit Sub
            cboAddToPartNumber.Focus()
        End If
        '****************************************************************************************
        'Before entering product - check to see if anything is in the rack first
        'If Full Pallet is checked - do not allow
        'If Boxes are checked - prompt with message box

        Dim CheckRackContents As Integer = 0

        Dim CheckRackContentsString As String = "SELECT SUM(TotalPieces) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
        Dim CheckRackContentsCommand As New SqlCommand(CheckRackContentsString, con)
        CheckRackContentsCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboAddToRackNumber.Text
        CheckRackContentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckRackContents = CInt(CheckRackContentsCommand.ExecuteScalar)
        Catch ex As Exception
            CheckRackContents = 0
        End Try
        con.Close()

        If rdoAddPallet.Checked = True Then
            If CheckRackContents = 0 Then
                'Do nothing - can add pallet to empty rack
            Else
                MsgBox("You cannot add a pallet to a rack with product in it.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Else
            If CheckRackContents = 0 Then
                'Continue - no restrictions adding boxes to an empty rack
            Else
                Dim button As DialogResult = MessageBox.Show("This rack is not empty. Do you wish to add product?", "RACK NOT EMPTY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Continue - add boxes to non-empty rack
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If
        '****************************************************************************************
        'Get Original Rack Contents for that part number before the update.
        Dim OriginalRackQuantity As Integer = 0
        Dim CurrentTotalPieces As Integer = 0
        Dim TotalDifference As Integer = 0

        Dim OriginalRackQuantityString As String = "SELECT SUM(TotalPieces) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim OriginalRackQuantityCommand As New SqlCommand(OriginalRackQuantityString, con)
        OriginalRackQuantityCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboAddToRackNumber.Text
        OriginalRackQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        OriginalRackQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAddToPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OriginalRackQuantity = CInt(OriginalRackQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            OriginalRackQuantity = 0
        End Try
        con.Close()

        CurrentTotalPieces = OriginalRackQuantity + Val(txtAddTotalPieces.Text)
        TotalDifference = Val(txtAddTotalPieces.Text)
        '****************************************************************************************
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()

        Dim MaxRackingKey As Integer = 0
        Dim NextRackingKey As Integer = 0

        Dim GetMAXKeyString As String = "SELECT MAX(RackingKey) FROM RackingTransactionTable"
        Dim GetMAXKeyCommand As New SqlCommand(GetMAXKeyString, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxRackingKey = CInt(GetMAXKeyCommand.ExecuteScalar)
        Catch ex As Exception
            MaxRackingKey = 0
        End Try
        con.Close()

        NextRackingKey = MaxRackingKey + 1

        'Update Racking Tables (2)
        Try
            'Update Racking Transaction Table
            cmd = New SqlCommand("INSERT INTO RackingTransactionTable (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, ActivityDate, DivisionID, CreationDate, PickTicket, PickDate, AddedBy, Comment) values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @ActivityDate, @DivisionID, @CreationDate, @PickTicket, @PickDate, @AddedBy, @Comment)", con)

            With cmd.Parameters
                .Add("@RackingKey", SqlDbType.VarChar).Value = NextRackingKey
                .Add("@BinNumber", SqlDbType.VarChar).Value = cboAddToRackNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboAddToPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboAddToPartDescription.Text
                .Add("@HeatNumber", SqlDbType.VarChar).Value = txtAddHeatNumber.Text
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtAddLotNumber.Text
                .Add("@BoxQuantity", SqlDbType.VarChar).Value = Val(txtBoxQuantity.Text)
                .Add("@PiecesPerBox", SqlDbType.VarChar).Value = Val(txtPiecesPerBox.Text)
                .Add("@TotalPieces", SqlDbType.VarChar).Value = Val(txtAddTotalPieces.Text)
                .Add("@RackingWeight", SqlDbType.VarChar).Value = Val(txtAddRackingWeight.Text)
                .Add("@ActivityDate", SqlDbType.VarChar).Value = strTodaysDate
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@CreationDate", SqlDbType.VarChar).Value = strTodaysDate
                .Add("@PickTicket", SqlDbType.VarChar).Value = 0
                .Add("@PickDate", SqlDbType.VarChar).Value = strTodaysDate
                .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@Comment", SqlDbType.VarChar).Value = txtRackComment.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
        End Try
        '****************************************************************************************
        Try
            'Update Racking Master List
            cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

            With cmd.Parameters
                .Add("@RackingKey", SqlDbType.VarChar).Value = NextRackingKey
                .Add("@BinNumber", SqlDbType.VarChar).Value = cboAddToRackNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboAddToPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboAddToPartDescription.Text
                .Add("@HeatNumber", SqlDbType.VarChar).Value = txtAddHeatNumber.Text
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtAddLotNumber.Text
                .Add("@BoxQuantity", SqlDbType.VarChar).Value = Val(txtBoxQuantity.Text)
                .Add("@PiecesPerBox", SqlDbType.VarChar).Value = Val(txtPiecesPerBox.Text)
                .Add("@TotalPieces", SqlDbType.VarChar).Value = Val(txtAddTotalPieces.Text)
                .Add("@RackingWeight", SqlDbType.VarChar).Value = Val(txtAddRackingWeight.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@CreationDate", SqlDbType.VarChar).Value = strTodaysDate
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
        End Try
        '****************************************************************************************
        If TotalDifference = 0 Then
            'Skip activity Log
        Else
            Try
                'Get Time and Date
                Todaysdate = Now()
                Dim intHours, intMinutes, intSeconds As Integer
                Dim strHours, strMinutes, strSeconds As String
                Dim RackTime As String = ""
                Dim RackDate As String = ""

                intHours = Todaysdate.Hour
                intMinutes = Todaysdate.Minute
                intSeconds = Todaysdate.Second

                strHours = CStr(intHours)
                strMinutes = CStr(intMinutes)
                strSeconds = CStr(intSeconds)

                RackTime = strHours + ":" + strMinutes + ":" + strSeconds
                RackDate = Todaysdate.ToString()

                'Update Racking Activity Log
                cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate) values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate)", con)

                With cmd.Parameters
                    .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                    .Add("@BinNumber", SqlDbType.VarChar).Value = cboAddToRackNumber.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAddToPartNumber.Text
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = txtAddHeatNumber.Text
                    .Add("@LotNumber", SqlDbType.VarChar).Value = txtAddLotNumber.Text
                    .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = OriginalRackQuantity
                    .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = CurrentTotalPieces
                    .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = TotalDifference
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "CREATED"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NextRackingKey
                    .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                    .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
            End Try
        End If
        '***************************************************************************************
        'If Label Print Box is checked, print the pallet location label

        If chkPalletLabel.Checked = True Then
            bc.PalletBinLabelSetup(cboAddToRackNumber.Text, 1)
            bc.PrintBarcodeLine("Zebra" + cboDivisionID.Text)
        Else
            'Do nothing
        End If
        '****************************************************************************************
        MsgBox("Quantity added to rack.", MsgBoxStyle.OkOnly)

        If cboDivisionID.Text = "SLC" Then
            LoadTotalEmptyRacksSLC()
        Else
            LoadTotalEmptyRacks()
        End If

        'Clear Fields
        cmdClearAddToRack_Click(sender, e)
    End Sub

    Private Sub cmdPrintByShipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintByShipment.Click
        If txtShipmentNumber.Text = "" Then
            'Skip Print Form
        Else
            GlobalShipmentNumber = Val(txtShipmentNumber.Text)

            Using NewPrintShipmentBarCodes As New PrintShipmentBarCodes
                Dim Result = NewPrintShipmentBarCodes.ShowDialog()
            End Using

            txtShipmentNumber.Clear()
        End If
    End Sub

    Private Sub cmdPrintPOBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPOBarcode.Click
        If cboDivisionID.Text = "" Then
            MsgBox("You must select a valid Purchase Order Number and Vendor ID before printing", MsgBoxStyle.OkOnly)
        Else
            GlobalPONumber = Val(cboPurchaseOrderNumber.Text)
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintPurchaseOrders As New PrintPurchaseOrderBarcode
                Dim result = NewPrintPurchaseOrders.ShowDialog()
            End Using
        End If
    End Sub

    'Menu Strip Events

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        FormLogoutRoutine()

        Me.Dispose()
        Me.Close()
    End Sub

    'Datagrid Events

    Private Sub dgvInventoryRacking_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryRacking.CellValueChanged
        If Me.dgvInventoryRacking.RowCount = 0 Then
            'Do nothing
        Else
            'Set Variables for line items
            Dim RowTransactionKey As Integer = 0
            Dim RowPartNumber As String = ""
            Dim RowBoxQuantity As Integer = 0
            Dim RowPiecesPerBox As Integer = 0
            Dim RowTotalPieces As Integer = 0
            Dim RowRackingWeight As Double = 0
            Dim RowDivision As String = ""
            Dim RowComment As String = ""
            Dim RowPieceWeight As Double = 0
            Dim NewRowTotalPieces As Integer = 0
            Dim NewRowRackingWeight As Double = 0
            Dim Todaysdate As Date = Now()
            Dim strTodaysDate As String = ""

            'Variables for Rack Activity Log
            Dim RowBinNumber As String = ""
            Dim RowPartDescription As String = ""
            Dim RowLotNumber As String = ""
            Dim RowHeatNumber As String = ""
            Dim RowOriginalPieces As Integer = 0
            Dim RowCurrentPieces As Integer = 0
            Dim RowTotalDifference As Integer = 0

            strTodaysDate = Todaysdate.ToShortDateString()

            'Get Line Data
            Dim RowIndex As Integer = Me.dgvInventoryRacking.CurrentCell.RowIndex

            Try
                RowPartNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowBinNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("BinNumberColumn").Value
            Catch ex As Exception
                RowBinNumber = ""
            End Try
            Try
                RowTransactionKey = Me.dgvInventoryRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value
            Catch ex As Exception
                RowTransactionKey = 0
            End Try
            Try
                RowBoxQuantity = Me.dgvInventoryRacking.Rows(RowIndex).Cells("BoxQuantityColumn").Value
            Catch ex As Exception
                RowBoxQuantity = 0
            End Try
            Try
                RowPiecesPerBox = Me.dgvInventoryRacking.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
            Catch ex As Exception
                RowPiecesPerBox = 0
            End Try
            Try
                RowTotalPieces = Me.dgvInventoryRacking.Rows(RowIndex).Cells("TotalPiecesColumn").Value
            Catch ex As Exception
                RowTotalPieces = 0
            End Try
            Try
                RowRackingWeight = Me.dgvInventoryRacking.Rows(RowIndex).Cells("RackingWeightColumn").Value
            Catch ex As Exception
                RowRackingWeight = 0
            End Try
            Try
                RowDivision = Me.dgvInventoryRacking.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try
            Try
                RowComment = Me.dgvInventoryRacking.Rows(RowIndex).Cells("RackCommentColumn").Value
            Catch ex As Exception
                RowComment = ""
            End Try

            'Preserve Row Pieces before update
            RowOriginalPieces = RowTotalPieces

            'Get Weight
            If RowRackingWeight = 0 Then
                If RowBoxQuantity = 0 Or RowPiecesPerBox = 0 Then
                    NewRowTotalPieces = 0
                    NewRowRackingWeight = 0
                Else
                    'Get Piece Weight from Item Maintenance
                    Dim GetItemPieceWeight As Double = 0

                    Dim GetItemPieceWeightString As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim GetItemPieceWeightCommand As New SqlCommand(GetItemPieceWeightString, con)
                    GetItemPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                    GetItemPieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetItemPieceWeight = CDbl(GetItemPieceWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetItemPieceWeight = 0
                    End Try
                    con.Close()

                    If GetItemPieceWeight = 0 Then
                        NewRowTotalPieces = RowBoxQuantity * RowPiecesPerBox
                        NewRowTotalPieces = Math.Round(NewRowTotalPieces, 0)
                        NewRowRackingWeight = 0
                    Else
                        NewRowTotalPieces = RowBoxQuantity * RowPiecesPerBox
                        NewRowTotalPieces = Math.Round(NewRowTotalPieces, 0)
                        NewRowRackingWeight = NewRowTotalPieces * GetItemPieceWeight
                        NewRowRackingWeight = Math.Round(NewRowRackingWeight, 0)
                    End If
                End If
            Else
                If RowBoxQuantity = 0 Or RowPiecesPerBox = 0 Then
                    NewRowTotalPieces = 0
                    NewRowRackingWeight = 0
                Else
                    RowPieceWeight = RowRackingWeight / RowTotalPieces

                    NewRowTotalPieces = RowBoxQuantity * RowPiecesPerBox
                    NewRowTotalPieces = Math.Round(NewRowTotalPieces, 0)
                    NewRowRackingWeight = NewRowTotalPieces * RowPieceWeight
                    NewRowRackingWeight = Math.Round(NewRowRackingWeight, 0)
                End If
            End If

            'Update Racking Tables (2)
            Try
                'Update Racking Transaction Table
                cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate, AddedBy = @AddedBy, Comment = @Comment WHERE RackingKey = @RackingKey", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = RowTransactionKey
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = RowBoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = RowPiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = NewRowTotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = NewRowRackingWeight
                    .Add("@ActivityDate", SqlDbType.VarChar).Value = strTodaysDate
                    .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
            End Try

            'Update Datagrid
            Me.dgvInventoryRacking.Rows(RowIndex).Cells("TotalPiecesColumn").Value = NewRowTotalPieces
            Me.dgvInventoryRacking.Rows(RowIndex).Cells("RackingWeightColumn").Value = NewRowRackingWeight

            'Variables for changes
            RowCurrentPieces = NewRowTotalPieces
            RowTotalDifference = RowCurrentPieces - RowOriginalPieces

            If RowCurrentPieces = RowOriginalPieces Then
                'No activity - skip
            Else
                Try
                    'Get Time and Date
                    Todaysdate = Now()
                    Dim intHours, intMinutes, intSeconds As Integer
                    Dim strHours, strMinutes, strSeconds As String
                    Dim RackTime As String = ""
                    Dim RackDate As String = ""

                    intHours = Todaysdate.Hour
                    intMinutes = Todaysdate.Minute
                    intSeconds = Todaysdate.Second

                    strHours = CStr(intHours)
                    strMinutes = CStr(intMinutes)
                    strSeconds = CStr(intSeconds)

                    RackTime = strHours + ":" + strMinutes + ":" + strSeconds
                    RackDate = Todaysdate.ToString()

                    'Insert Into Racking Master List
                    cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate) values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate)", con)

                    With cmd.Parameters
                        .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                        .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                        .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                        .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = RowOriginalPieces
                        .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = RowCurrentPieces
                        .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = RowTotalDifference
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@TransactionType", SqlDbType.VarChar).Value = "UPDATED"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = RowTransactionKey
                        .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                        .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip activity Log
                End Try

                If cboDivisionID.Text = "SLC" Then
                    LoadTotalEmptyRacksSLC()
                Else
                    LoadTotalEmptyRacks()
                End If
            End If
        End If
    End Sub

    Private Sub dgvInventoryRacking_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInventoryRacking.RowHeaderMouseClick
        LoadTotals()
    End Sub

    Private Sub dgvInventoryRacking_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryRacking.CellClick
        LoadTotals()
    End Sub

    Private Sub dgvInventoryRacking_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryRacking.CellContentClick
        LoadTotals()
    End Sub

    Private Sub dgvSuggestedRacks_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSuggestedRacks.CellClick
        'Load Rack Data
        If Me.dgvSuggestedRacks.RowCount > 0 Then
            Me.dgvRackContents.DataSource = Nothing
            lblRackNumber.Text = ""

            Dim RowIndex As Integer = Me.dgvSuggestedRacks.CurrentCell.RowIndex

            Try
                LineRackNumber = Me.dgvSuggestedRacks.Rows(RowIndex).Cells("BinNumberColumn22").Value
            Catch ex As Exception
                LineRackNumber = ""
            End Try
            Try
                LineDivisionID = Me.dgvSuggestedRacks.Rows(RowIndex).Cells("DivisionIDColumn22").Value
            Catch ex As Exception
                LineDivisionID = ""
            End Try

            LoadRackContents()
            lblRackNumber.Text = "Rack Contents for " + LineRackNumber
            cboAddToRackNumber.Text = LineRackNumber
        End If
    End Sub

    Private Sub dgvSuggestedRacks_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSuggestedRacks.CellContentClick
        'Load Rack Data
        If Me.dgvSuggestedRacks.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvSuggestedRacks.CurrentCell.RowIndex

            Try
                LineRackNumber = Me.dgvSuggestedRacks.Rows(RowIndex).Cells("BinNumberColumn22").Value
            Catch ex As Exception
                LineRackNumber = ""
            End Try
            Try
                LineDivisionID = Me.dgvSuggestedRacks.Rows(RowIndex).Cells("DivisionIDColumn22").Value
            Catch ex As Exception
                LineDivisionID = ""
            End Try

            LoadRackContents()
            lblRackNumber.Text = "Rack Contents for " + LineRackNumber
            cboAddToRackNumber.Text = LineRackNumber
        End If
    End Sub

    Private Sub dgvSuggestedRacks_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSuggestedRacks.ColumnHeaderMouseClick
        'Run A FOR/EACH Loop on Datagrid to load Box Count
        For Each LineRow As DataGridViewRow In dgvSuggestedRacks.Rows
            Dim TempLineRackNumber As String = ""
            Dim TempLineDivision As String = ""
            Dim RowIndex As Integer = Me.dgvSuggestedRacks.CurrentCell.RowIndex

            Try
                TempLineRackNumber = LineRow.Cells("BinNumberColumn22").Value
            Catch ex As System.Exception
                TempLineRackNumber = ""
            End Try
            Try
                TempLineDivision = LineRow.Cells("DivisionIDColumn22").Value
            Catch ex As System.Exception
                TempLineRackNumber = ""
            End Try

            Dim SUMTotalBoxes As Double = 0

            Dim SUMTotalBoxesStatement As String = "SELECT SUM(BoxQuantity) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
            Dim SUMTotalBoxesCommand As New SqlCommand(SUMTotalBoxesStatement, con)
            SUMTotalBoxesCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = TempLineRackNumber
            SUMTotalBoxesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = TempLineDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMTotalBoxes = CDbl(SUMTotalBoxesCommand.ExecuteScalar)
            Catch ex As Exception
                SUMTotalBoxes = 0
            End Try
            con.Close()

            If SUMTotalBoxes = 0 Then
                Me.dgvSuggestedRacks.Rows(RowIndex).Cells("NumberOfBoxesColumn22").Value = "EMPTY"
            Else
                Me.dgvSuggestedRacks.Rows(RowIndex).Cells("NumberOfBoxesColumn22").Value = SUMTotalBoxes
            End If

            SUMTotalBoxes = 0
            TempLineDivision = ""
            TempLineRackNumber = ""
        Next

    End Sub

    Private Sub dgvSuggestedRacks_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSuggestedRacks.Sorted
        'Run A FOR/EACH Loop on Datagrid to load Box Count
        For Each LineRow As DataGridViewRow In dgvSuggestedRacks.Rows
            Dim TempLineRackNumber As String = ""
            Dim TempLineDivision As String = ""
            Dim RowIndex As Integer = Me.dgvSuggestedRacks.CurrentCell.RowIndex

            Try
                TempLineRackNumber = LineRow.Cells("BinNumberColumn22").Value
            Catch ex As System.Exception
                TempLineRackNumber = ""
            End Try
            Try
                TempLineDivision = LineRow.Cells("DivisionIDColumn22").Value
            Catch ex As System.Exception
                TempLineRackNumber = ""
            End Try

            Dim SUMTotalBoxes As Double = 0

            Dim SUMTotalBoxesStatement As String = "SELECT SUM(BoxQuantity) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
            Dim SUMTotalBoxesCommand As New SqlCommand(SUMTotalBoxesStatement, con)
            SUMTotalBoxesCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = TempLineRackNumber
            SUMTotalBoxesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = TempLineDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMTotalBoxes = CDbl(SUMTotalBoxesCommand.ExecuteScalar)
            Catch ex As Exception
                SUMTotalBoxes = 0
            End Try
            con.Close()

            If SUMTotalBoxes = 0 Then
                Me.dgvSuggestedRacks.Rows(RowIndex).Cells("NumberOfBoxesColumn22").Value = "EMPTY"
            Else
                Me.dgvSuggestedRacks.Rows(RowIndex).Cells("NumberOfBoxesColumn22").Value = SUMTotalBoxes
            End If

            SUMTotalBoxes = 0
            TempLineDivision = ""
            TempLineRackNumber = ""
        Next
    End Sub

    Private Sub rdoAddPallet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAddPallet.CheckedChanged
        dgvSuggestedRacks.Visible = False
        dgvRackContents.Visible = False
        Label22.Visible = False
        lblRackNumber.Visible = False

        chkPalletLabel.Checked = True
        cmdClearAddToRack_Click(sender, e)

        If cboDivisionID.Text = "SLC" Then
            LoadTotalEmptyRacksSLC()
        Else
            LoadTotalEmptyRacks()
        End If
    End Sub

    Private Sub rdoAddBoxes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAddBoxes.CheckedChanged
        dgvSuggestedRacks.Visible = True
        dgvRackContents.Visible = False
        Label22.Visible = True
        lblRackNumber.Visible = False

        chkPalletLabel.Checked = False
        cmdClearAddToRack_Click(sender, e)

        If cboDivisionID.Text = "SLC" Then
            LoadTotalEmptyRacksSLC()
        Else
            LoadTotalEmptyRacks()
        End If
    End Sub

End Class