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
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class ShippingUpdater
    Inherits System.Windows.Forms.Form

    Dim FormName As String = "Shipment Updater"

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim PickPartNumber As String = ""
    Dim RackPartNumber As String = ""
    Dim LotPartNumber As String = ""
    Dim GetPullTestNumber As String = ""
    Dim GetShipmentNumber As Integer = 0
    Dim LoadLotNumberForPullTest As String = ""

    Dim LastLotLineNumber, NextLotLineNumber As Integer
    Dim RackingKeyQuantity As Integer = 0
    Dim RackingKeyBoxQuantity As Integer = 0
    Dim RackingKeyPiecesPerBox As Integer = 0
    Dim RackingKeyRackingWeight As Double = 0
    Dim RackingKeyTotalPieces As Double = 0
    Dim RackingKeyPartDescription As String = ""

    Dim PickDivisionID As String = ""
    Dim RackingKey As Integer = 0
    Dim PickLineNumber As Integer = 0
    Dim LineBoxQuantity, LinePiecesPerBox, LineTotalPieces As Integer
    Dim LineRackingWeight, LinePieceWeight As Double

    Dim AddPickTicketNumber, AddRackingKey, AddBinNumber, AddHeatNumber, AddLotNumber As String
    Dim AddTotalPieces, AddBoxQuantity, AddPiecesPerBox As Integer
    Dim AddRackingWeight As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Async=True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable

    Private Sub ShippingUpdater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'Form Login
        FormLoginRoutine()

        ClearData()
        ClearVariables()
        txtPickTicketNumber.Focus()
    End Sub

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), &HF060, 1)
            Case &HFFFFFFFF
        End Select
    End Sub

    Private Sub ShippingUpdater_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Count > 300 Then
            ErrorComment = ErrorComment.Substring(0, 300)
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

    Public Sub ShowPickLines()
        cmd = New SqlCommand("SELECT * FROM PickListLineQuery2 WHERE PickListHeaderKey = @PickListHeaderKey", con)
        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PickListLineQuery2")
        dgvPickLines.DataSource = ds.Tables("PickListLineQuery2")
        con.Close()

        LoadFormatting()
    End Sub

    Public Sub ShowRacking()
        cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID ORDER BY BoxQuantity, BinNumber ASC", con)
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PickPartNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RackingTransactionTable")
        dgvViewRacking.DataSource = ds1.Tables("RackingTransactionTable")
        con.Close()
    End Sub

    Public Sub LoadFormatting()
        Dim RowPickQuantity As Integer = 0
        Dim RowPulledQuantity As Integer = 0

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvPickLines.Rows
            Try
                RowPickQuantity = row.Cells("QuantityColumn").Value
            Catch ex As System.Exception
                RowPickQuantity = 0
            End Try
            Try
                RowPulledQuantity = row.Cells("SumTotalPiecesColumn").Value
            Catch ex As System.Exception
                RowPulledQuantity = 0
            End Try

            If RowPickQuantity = RowPulledQuantity Then
                Me.dgvPickLines.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvPickLines.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf RowPickQuantity > RowPulledQuantity Then
                Me.dgvPickLines.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvPickLines.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf RowPickQuantity < RowPulledQuantity Then
                Me.dgvPickLines.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvPickLines.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                Me.dgvPickLines.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvPickLines.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadPickHeaderData()
        Dim CustomerName, SpecialInstructions, CustomerPO, Salesperson, ShipVia, ShipMethod As String
        Dim SONumber As Integer

        Dim LoadPickDataStatement As String = "SELECT * FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey"
        Dim LoadPickDataCommand As New SqlCommand(LoadPickDataStatement, con)
        LoadPickDataCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadPickDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShipToName")) Then
                CustomerName = ""
            Else
                CustomerName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("SpecialInstructions")) Then
                SpecialInstructions = ""
            Else
                SpecialInstructions = reader.Item("SpecialInstructions")
            End If
            If IsDBNull(reader.Item("CustomerPO")) Then
                CustomerPO = ""
            Else
                CustomerPO = reader.Item("CustomerPO")
            End If
            If IsDBNull(reader.Item("SalesmanID")) Then
                Salesperson = ""
            Else
                Salesperson = reader.Item("SalesmanID")
            End If
            If IsDBNull(reader.Item("ShipVia")) Then
                ShipVia = ""
            Else
                ShipVia = reader.Item("ShipVia")
            End If
            If IsDBNull(reader.Item("ShippingMethod")) Then
                ShipMethod = ""
            Else
                ShipMethod = reader.Item("ShippingMethod")
            End If
            If IsDBNull(reader.Item("SalesOrderHeaderKey")) Then
                SONumber = 0
            Else
                SONumber = reader.Item("SalesOrderHeaderKey")
            End If
        Else
            CustomerName = ""
            SpecialInstructions = ""
            CustomerPO = ""
            Salesperson = ""
            ShipVia = ""
            ShipMethod = ""
            SONumber = 0
        End If
        reader.Close()
        con.Close()

        txtCustomerPO.Text = CustomerPO
        txtCustomer.Text = CustomerName
        txtSalesperson.Text = Salesperson
        txtShipMethod.Text = ShipMethod
        txtShipVia.Text = ShipVia
        txtSONumber.Text = SONumber
        txtSpecialInstructions.Text = SpecialInstructions
    End Sub

    Public Sub LoadScanLotNumberData()
        Dim LotPartNumber, LotPartDescription, LotHeatNumber As String
        Dim LotBoxCount, LotPalletCount, LotPalletPieces As Integer
        Dim LotBoxWeight, LotPalletWeight As Double

        Dim LoadLotDataStatement As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim LoadLotDataCommand As New SqlCommand(LoadLotDataStatement, con)
        LoadLotDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadLotDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                LotPartNumber = ""
            Else
                LotPartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                LotPartDescription = ""
            Else
                LotPartDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                LotHeatNumber = ""
            Else
                LotHeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                LotBoxCount = 0
            Else
                LotBoxCount = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                LotPalletCount = 0
            Else
                LotPalletCount = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("PalletPieces")) Then
                LotPalletPieces = 0
            Else
                LotPalletPieces = reader.Item("PalletPieces")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                LotBoxWeight = 0
            Else
                LotBoxWeight = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("PalletWeight")) Then
                LotPalletWeight = 0
            Else
                LotPalletWeight = reader.Item("PalletWeight")
            End If
        Else
            LotBoxWeight = 0
            LotBoxCount = 0
            LotPalletPieces = 0
            LotPalletCount = 0
            LotHeatNumber = ""
            LotPartDescription = ""
            LotPartNumber = ""
            LotPalletWeight = 0
        End If
        reader.Close()
        con.Close()

        txtScanPartNumber.Text = LotPartNumber
        txtScanBoxCount.Text = LotBoxCount
        txtScanBoxWeight.Text = LotBoxWeight
        txtScanHeatNumber.Text = LotHeatNumber
        txtScanPalletCount.Text = LotPalletCount
        txtScanPalletPieces.Text = LotPalletPieces
        txtScanPalletWeight.Text = LotPalletWeight
        txtScanPartDescription.Text = LotPartDescription
    End Sub

    Public Sub LoadPartData()
        Dim ItemPartDescription As String
        Dim ItemBoxCount, ItemPalletCount, ItemPalletPieces As Integer
        Dim ItemBoxWeight, ItemPalletWeight As Double

        Dim LoadPartDataStatement As String = "SELECT * FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LoadPartDataCommand As New SqlCommand(LoadPartDataStatement, con)
        LoadPartDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtScanPartNumber.Text
        LoadPartDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadPartDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShortDescription")) Then
                ItemPartDescription = ""
            Else
                ItemPartDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                ItemBoxCount = 0
            Else
                ItemBoxCount = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                ItemPalletCount = 0
            Else
                ItemPalletCount = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                ItemBoxWeight = 0
            Else
                ItemBoxWeight = reader.Item("BoxWeight")
            End If
        Else
            ItemBoxWeight = 0
            ItemBoxCount = 0
            ItemPalletCount = 0
            ItemPartDescription = ""
        End If
        reader.Close()
        con.Close()

        ItemPalletPieces = ItemBoxCount * ItemPalletCount
        ItemPalletWeight = ItemPalletCount * ItemBoxWeight

        txtScanBoxCount.Text = ItemBoxCount
        txtScanBoxWeight.Text = ItemBoxWeight
        txtScanHeatNumber.Text = ""
        txtScanPalletCount.Text = ItemPalletCount
        txtScanPalletPieces.Text = ItemPalletPieces
        txtScanPalletWeight.Text = ItemPalletWeight
        txtScanPartDescription.Text = ItemPartDescription
    End Sub

    Public Sub LoadRackData()
        Dim LotNumber, HeatNumber, BinNumber, RackPartNumber, RackDivisionID As String
        Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
        Dim RackingWeight As Double

        Dim LoadRackDataStatement As String = "SELECT * FROM RackingTransactionTable WHERE RackingKey = @RackingKey"
        Dim LoadRackDataCommand As New SqlCommand(LoadRackDataStatement, con)
        LoadRackDataCommand.Parameters.Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadRackDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LotNumber")) Then
                LotNumber = ""
            Else
                LotNumber = reader.Item("LotNumber")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = ""
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("BinNumber")) Then
                BinNumber = ""
            Else
                BinNumber = reader.Item("BinNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                RackPartNumber = ""
            Else
                RackPartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("DivisionID")) Then
                RackDivisionID = ""
            Else
                RackDivisionID = reader.Item("DivisionID")
            End If
            If IsDBNull(reader.Item("BoxQuantity")) Then
                BoxQuantity = 0
            Else
                BoxQuantity = reader.Item("BoxQuantity")
            End If
            If IsDBNull(reader.Item("PiecesPerBox")) Then
                PiecesPerBox = 0
            Else
                PiecesPerBox = reader.Item("PiecesPerBox")
            End If
            If IsDBNull(reader.Item("TotalPieces")) Then
                TotalPieces = 0
            Else
                TotalPieces = reader.Item("TotalPieces")
            End If
            If IsDBNull(reader.Item("RackingWeight")) Then
                RackingWeight = 0
            Else
                RackingWeight = reader.Item("RackingWeight")
            End If
        Else
            LotNumber = ""
            HeatNumber = ""
            BinNumber = ""
            RackPartNumber = ""
            RackDivisionID = ""
            BoxQuantity = 0
            PiecesPerBox = 0
            TotalPieces = 0
            RackingWeight = 0
            PiecesPerBox = 0
        End If
        reader.Close()
        con.Close()

        txtPartNumber.Text = RackPartNumber
        txtLotNumber.Text = LotNumber
        txtHeatNumber.Text = HeatNumber
        txtBinNumber.Text = BinNumber
        txtBoxQuantity.Text = BoxQuantity
        txtPiecesPerBox.Text = PiecesPerBox
        txtRackWeight.Text = RackingWeight
        txtTotalPieces.Text = TotalPieces

        If Val(txtBoxQuantity.Text) = 1 Then
            txtPiecesPerBox.ReadOnly = False
            txtPiecesPerBox.BackColor = Color.LightYellow
        Else
            txtPiecesPerBox.ReadOnly = True
            txtPiecesPerBox.BackColor = Color.White
        End If
    End Sub

    Public Sub LoadItemPieceWeight()
        Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
        GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text
        GetPieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LinePieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
        Catch ex As Exception
            LinePieceWeight = 0
        End Try
        con.Close()
    End Sub

    Public Sub LoadQuantityOnHand()
        Dim TotalPiecesInRack As Double = 0
        Dim TotalQuantityOnHand As Double = 0

        Dim TotalPiecesInRackStatement As String = "SELECT SUM(TotalPieces) FROM RackingTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim TotalPiecesInRackCommand As New SqlCommand(TotalPiecesInRackStatement, con)
        TotalPiecesInRackCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PickPartNumber
        TotalPiecesInRackCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID

        Dim TotalQuantityOnHandStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TotalQuantityOnHandCommand As New SqlCommand(TotalQuantityOnHandStatement, con)
        TotalQuantityOnHandCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PickPartNumber
        TotalQuantityOnHandCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalPiecesInRack = CDbl(TotalPiecesInRackCommand.ExecuteScalar)
            TotalPiecesInRack = Math.Round(TotalPiecesInRack, 0)
        Catch ex As Exception
            TotalPiecesInRack = 0
        End Try
        Try
            TotalQuantityOnHand = CDbl(TotalQuantityOnHandCommand.ExecuteScalar)
            TotalQuantityOnHand = Math.Round(TotalQuantityOnHand, 0)
        Catch ex As Exception
            TotalQuantityOnHand = 0
        End Try
        con.Close()

        lblTotalInRack.Text = TotalPiecesInRack
        lblQuantityOnHand.Text = TotalQuantityOnHand
    End Sub

    Public Sub LoadPullTestNumber()
        'Check if Heat Quantity is equal to Line Quantity
        Dim HeatQuantity As Double = Val(txtTotalPieces.Text)
        Dim LineQuantity As Double = 0
        Dim SumHeatQuantity As Double = 0
        Dim LotNominalLength As Double = 0
        Dim LotNominalDiameter As Double = 0
        Dim LotItemClass As String = ""
        Dim PullTestNumber As String = ""
        Dim MinNominalLength As Double = 0
        Dim ShipmentCertType As String = ""
        Dim LotStatus As String = ""
        Dim MinTensile As Double = 0
        Dim MinYield As Double = 0
        Dim ROAPercent As Double = 0
        Dim ElongationPercent As Double = 0
        Dim PartHeatNumber As String = ""
        Dim GetMinPartNumber As String = ""
        Dim MinTensileFilter As String = ""
        Dim MinYieldFilter As String = ""
        Dim ROAPercentFilter As String = ""
        Dim ElongationPercentFilter As String = ""
        Dim strMinTensile As String = ""
        Dim strMinYield As String = ""
        Dim strROAPercent As String = ""
        Dim strElongationPercent As String = ""

        'Get Lot Number Data
        Dim GetLotDataString As String = "SELECT Status, HeatNumber, NominalDiameter, NominalLength, ItemClass FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetLotDataCommand As New SqlCommand(GetLotDataString, con)
        GetLotDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetLotDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Status")) Then
                LotStatus = ""
            Else
                LotStatus = reader.Item("Status")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                PartHeatNumber = ""
            Else
                PartHeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("NominalDiameter")) Then
                LotNominalDiameter = 0
            Else
                LotNominalDiameter = reader.Item("NominalDiameter")
            End If
            If IsDBNull(reader.Item("NominalLength")) Then
                LotNominalLength = 0
            Else
                LotNominalLength = reader.Item("NominalLength")
            End If
            If IsDBNull(reader.Item("ItemClass")) Then
                LotItemClass = ""
            Else
                LotItemClass = reader.Item("ItemClass")
            End If
        Else
            LotStatus = ""
            PartHeatNumber = ""
            LotNominalDiameter = 0
            LotNominalLength = 0
            LotItemClass = ""
        End If
        reader.Close()
        con.Close()
        '*****************************************************************************************
        'Validate Certification Type at the time of entering Lot Numbers
        Dim CheckCertType As String = ""
        Dim GetFOXCertType As String = ""

        Dim CheckCertTypeStatement As String = "SELECT CertificationType FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
        Dim CheckCertTypeCommand As New SqlCommand(CheckCertTypeStatement, con)
        CheckCertTypeCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
        CheckCertTypeCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckCertType = CStr(CheckCertTypeCommand.ExecuteScalar)
            ShipmentCertType = CheckCertType
        Catch ex As Exception
            CheckCertType = ""
            ShipmentCertType = CheckCertType
        End Try
        con.Close()

        If CheckCertType = "" Or CheckCertType = "0" Then
            Dim GetFOXCertTypeStatement As String = "SELECT CertificationType FROM FOXTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim GetFOXCertTypeCommand As New SqlCommand(GetFOXCertTypeStatement, con)
            GetFOXCertTypeCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
            GetFOXCertTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetFOXCertType = CStr(GetFOXCertTypeCommand.ExecuteScalar)
                ShipmentCertType = GetFOXCertType
            Catch ex As Exception
                GetFOXCertType = "0"
                ShipmentCertType = GetFOXCertType
            End Try
            con.Close()

            If GetFOXCertType = "" Then
                'If Cert Code is blank, use default
                Dim NewGetCertCode As String = ""

                Select Case LotItemClass
                    Case "TW DS"
                        NewGetCertCode = "1"
                    Case "TW CA"
                        NewGetCertCode = "1"
                    Case "TW SC"
                        NewGetCertCode = "1"
                    Case "TW DB"
                        NewGetCertCode = "2"
                    Case "TW TT"
                        NewGetCertCode = "6"
                    Case "TW TP"
                        NewGetCertCode = "6"
                    Case "TW CS"
                        NewGetCertCode = "6"
                    Case "TW NT"
                        NewGetCertCode = "6"
                    Case "TW PS"
                        NewGetCertCode = "1"
                    Case "TW SWR"
                        NewGetCertCode = "17"
                    Case Else
                        NewGetCertCode = "0"
                End Select

                GetFOXCertType = NewGetCertCode
                ShipmentCertType = GetFOXCertType
            Else
                'Skip
            End If
        End If
        '****************************************************************************************
        'Get Requirements for the specific cert code
        Dim GetCertDataString As String = "SELECT MinTensile, MinYield, ROAPercent, ElongationPercent FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim GetCertDataCommand As New SqlCommand(GetCertDataString, con)
        GetCertDataCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = ShipmentCertType

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader2 As SqlDataReader = GetCertDataCommand.ExecuteReader()
        If reader2.HasRows Then
            reader2.Read()
            If IsDBNull(reader2.Item("MinTensile")) Then
                MinTensile = ""
            Else
                MinTensile = reader2.Item("MinTensile")
            End If
            If IsDBNull(reader2.Item("MinYield")) Then
                MinYield = 0
            Else
                MinYield = reader2.Item("MinYield")
            End If
            If IsDBNull(reader2.Item("ROAPercent")) Then
                ROAPercent = ""
            Else
                ROAPercent = reader2.Item("ROAPercent")
            End If
            If IsDBNull(reader2.Item("ElongationPercent")) Then
                ElongationPercent = 0
            Else
                ElongationPercent = reader2.Item("ElongationPercent")
            End If
        Else
            MinTensile = 0
            MinYield = 0
            ROAPercent = 0
            ElongationPercent = 0
        End If
        reader2.Close()
        con.Close()
        '****************************************************************************************
        'Define requirements for cert type
        Select Case ShipmentCertType
            Case "0"
                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "1"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = CStr(ElongationPercent)
                strROAPercent = CStr(ROAPercent)

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = " AND ReductionPercent >= '" + strROAPercent + "'"
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "2"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "3"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = CStr(ROAPercent)

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "4"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "5"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = CStr(ElongationPercent)
                strROAPercent = CStr(ROAPercent)

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = " AND ReductionPercent >= '" + strROAPercent + "'"
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "6"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "7"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "8"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = CStr(ElongationPercent)
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "9"
                strMinTensile = ""
                strMinYield = ""
                strElongationPercent = CStr(ElongationPercent)
                strROAPercent = ""

                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "10"
                strMinTensile = ""
                strMinYield = ""
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "11"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "12"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "13"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "17"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "CERT REQUIRED"
                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case Else
                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
        End Select
        '****************************************************************************************
        If LotItemClass = "TW DB" Or LotItemClass = "TW PS" Or LotItemClass = "TW SWR" Then
            'Get Pull Test Number for selected Lot Number Data
            Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
            Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
            GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LotPartNumber
            GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
            GetPullTestNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetPullTestNumber = ""
            End Try
            con.Close()

            'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
            If GetPullTestNumber = "" Then
                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Do nothing - exact Pull Test exists
            End If

            'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
            If GetPullTestNumber = "" Then
                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Do nothing - exact Pull Test exists
            End If

            'Write to error log
            If GetPullTestNumber = "" Then
                GetPullTestNumber = "NO CERT"

                Try
                    'Write to error log
                    cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                    With cmd.Parameters
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                        .Add("@Date", SqlDbType.VarChar).Value = Today()
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                        .Add("@Comment", SqlDbType.VarChar).Value = "Shipping Updater"
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
            End If
        ElseIf LotItemClass = "TW TT" Then
            'Get Pull Test Number for selected Lot Number Data
            Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
            Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
            GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LotPartNumber
            GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
            GetPullTestNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetPullTestNumber = ""
            End Try
            con.Close()

            'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
            If GetPullTestNumber = "" Then
                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Do nothing - exact Pull Test exists
            End If

            'Check for Pull Test using Steel Diameter
            If GetPullTestNumber = "" Then
                Dim GetSteelSize As String = ""

                Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM LotNumber WHERE LotNumber = @LotNumber"
                Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
                GetSteelSizeCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSteelSize = ""
                End Try
                con.Close()

                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND SteelSize = @SteelSize AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = GetSteelSize
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Skip
            End If

            'Write to error log
            If GetPullTestNumber = "" Then
                GetPullTestNumber = "NO CERT"

                Try
                    'Write to error log
                    cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                    With cmd.Parameters
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                        .Add("@Date", SqlDbType.VarChar).Value = Today()
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                        .Add("@Comment", SqlDbType.VarChar).Value = "Shipping Updater"
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
            End If
        ElseIf LotItemClass = "Trufit Parts" Then
            'Skip printing cert
            'MsgBox("No cert exists for this TFP Part.", MsgBoxStyle.OkOnly)
        Else
            'Get Pull Test Number for selected Lot Number Data
            Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
            Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
            GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LotPartNumber
            GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
            GetPullTestNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetPullTestNumber = ""
            End Try
            con.Close()

            'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
            If GetPullTestNumber = "" Then
                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND NominalLength >= @NominalLength AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                GetMinPartNumberCommand.Parameters.Add("@NominalLength", SqlDbType.VarChar).Value = LotNominalLength
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Do nothing - exact Pull Test exists
            End If

            'Write to error log
            If GetPullTestNumber = "" Then
                GetPullTestNumber = "NO CERT"

                Try
                    'Write to error log
                    cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                    With cmd.Parameters
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                        .Add("@Date", SqlDbType.VarChar).Value = Today()
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                        .Add("@Comment", SqlDbType.VarChar).Value = "Shipping Updater"
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
            End If
        End If
    End Sub

    Public Sub LoadPullTestNumberManualEntry()
        'Check if Heat Quantity is equal to Line Quantity
        Dim HeatQuantity As Double = Val(txtTotalPieces.Text)
        Dim LineQuantity As Double = 0
        Dim SumHeatQuantity As Double = 0
        Dim LotNominalLength As Double = 0
        Dim LotNominalDiameter As Double = 0
        Dim LotItemClass As String = ""
        Dim PullTestNumber As String = ""
        Dim MinNominalLength As Double = 0
        Dim ShipmentCertType As String = ""
        Dim LotStatus As String = ""
        Dim MinTensile As Double = 0
        Dim MinYield As Double = 0
        Dim ROAPercent As Double = 0
        Dim ElongationPercent As Double = 0
        Dim PartHeatNumber As String = ""
        Dim GetMinPartNumber As String = ""
        Dim MinTensileFilter As String = ""
        Dim MinYieldFilter As String = ""
        Dim ROAPercentFilter As String = ""
        Dim ElongationPercentFilter As String = ""
        Dim strMinTensile As String = ""
        Dim strMinYield As String = ""
        Dim strROAPercent As String = ""
        Dim strElongationPercent As String = ""

        'Get Lot Number Data
        Dim GetLotDataString As String = "SELECT Status, HeatNumber, NominalDiameter, NominalLength, ItemClass FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetLotDataCommand As New SqlCommand(GetLotDataString, con)
        GetLotDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetLotDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Status")) Then
                LotStatus = ""
            Else
                LotStatus = reader.Item("Status")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                PartHeatNumber = ""
            Else
                PartHeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("NominalDiameter")) Then
                LotNominalDiameter = 0
            Else
                LotNominalDiameter = reader.Item("NominalDiameter")
            End If
            If IsDBNull(reader.Item("NominalLength")) Then
                LotNominalLength = 0
            Else
                LotNominalLength = reader.Item("NominalLength")
            End If
            If IsDBNull(reader.Item("ItemClass")) Then
                LotItemClass = ""
            Else
                LotItemClass = reader.Item("ItemClass")
            End If
        Else
            LotStatus = ""
            PartHeatNumber = ""
            LotNominalDiameter = 0
            LotNominalLength = 0
            LotItemClass = ""
        End If
        reader.Close()
        con.Close()
        '****************************************************************************************

        '****************************************************************************************
        'Validate Certification Type at the time of entering Lot Numbers
        Dim CheckCertType As String = ""
        Dim GetFOXCertType As String = ""

        Dim CheckCertTypeStatement As String = "SELECT CertificationType FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
        Dim CheckCertTypeCommand As New SqlCommand(CheckCertTypeStatement, con)
        CheckCertTypeCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
        CheckCertTypeCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckCertType = CStr(CheckCertTypeCommand.ExecuteScalar)
            ShipmentCertType = CheckCertType
        Catch ex As Exception
            CheckCertType = ""
            ShipmentCertType = CheckCertType
        End Try
        con.Close()

        If CheckCertType = "" Or CheckCertType = "0" Then
            Dim GetFOXCertTypeStatement As String = "SELECT CertificationType FROM FOXTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim GetFOXCertTypeCommand As New SqlCommand(GetFOXCertTypeStatement, con)
            GetFOXCertTypeCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtScanPartNumber.Text
            GetFOXCertTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetFOXCertType = CStr(GetFOXCertTypeCommand.ExecuteScalar)
                ShipmentCertType = GetFOXCertType
            Catch ex As Exception
                GetFOXCertType = "0"
                ShipmentCertType = GetFOXCertType
            End Try
            con.Close()

            If GetFOXCertType = "" Then
                'If Cert Code is blank, use default
                Dim NewGetCertCode As String = ""

                Select Case LotItemClass
                    Case "TW DS"
                        NewGetCertCode = "1"
                    Case "TW CA"
                        NewGetCertCode = "1"
                    Case "TW SC"
                        NewGetCertCode = "1"
                    Case "TW DB"
                        NewGetCertCode = "2"
                    Case "TW TT"
                        NewGetCertCode = "6"
                    Case "TW TP"
                        NewGetCertCode = "6"
                    Case "TW CS"
                        NewGetCertCode = "6"
                    Case "TW NT"
                        NewGetCertCode = "6"
                    Case "TW PS"
                        NewGetCertCode = "1"
                    Case "TW SWR"
                        NewGetCertCode = "17"
                    Case Else
                        NewGetCertCode = "0"
                End Select

                GetFOXCertType = NewGetCertCode
                ShipmentCertType = GetFOXCertType
            Else
                'Skip
            End If
        End If
        '****************************************************************************************
        'Get Requirements for the specific cert code
        Dim GetCertDataString As String = "SELECT MinTensile, MinYield, ROAPercent, ElongationPercent FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim GetCertDataCommand As New SqlCommand(GetCertDataString, con)
        GetCertDataCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = ShipmentCertType

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader2 As SqlDataReader = GetCertDataCommand.ExecuteReader()
        If reader2.HasRows Then
            reader2.Read()
            If IsDBNull(reader2.Item("MinTensile")) Then
                MinTensile = ""
            Else
                MinTensile = reader2.Item("MinTensile")
            End If
            If IsDBNull(reader2.Item("MinYield")) Then
                MinYield = 0
            Else
                MinYield = reader2.Item("MinYield")
            End If
            If IsDBNull(reader2.Item("ROAPercent")) Then
                ROAPercent = ""
            Else
                ROAPercent = reader2.Item("ROAPercent")
            End If
            If IsDBNull(reader2.Item("ElongationPercent")) Then
                ElongationPercent = 0
            Else
                ElongationPercent = reader2.Item("ElongationPercent")
            End If
        Else
            MinTensile = 0
            MinYield = 0
            ROAPercent = 0
            ElongationPercent = 0
        End If
        reader2.Close()
        con.Close()
        '****************************************************************************************
        'Define requirements for cert type
        Select Case ShipmentCertType
            Case "0"
                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "1"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = CStr(ElongationPercent)
                strROAPercent = CStr(ROAPercent)

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = " AND ReductionPercent >= '" + strROAPercent + "'"
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "2"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "3"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = CStr(ROAPercent)

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "4"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "5"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = CStr(ElongationPercent)
                strROAPercent = CStr(ROAPercent)

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = " AND ReductionPercent >= '" + strROAPercent + "'"
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "6"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "7"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "8"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = CStr(ElongationPercent)
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "9"
                strMinTensile = ""
                strMinYield = ""
                strElongationPercent = CStr(ElongationPercent)
                strROAPercent = ""

                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
            Case "10"
                strMinTensile = ""
                strMinYield = ""
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "11"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "12"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "13"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "17"
                strMinTensile = CStr(MinTensile)
                strMinYield = CStr(MinYield)
                strElongationPercent = ""
                strROAPercent = ""

                MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case "CERT REQUIRED"
                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
            Case Else
                MinTensileFilter = ""
                MinYieldFilter = ""
                ROAPercentFilter = ""
                ElongationPercentFilter = ""
        End Select
        '****************************************************************************************
        If LotItemClass = "TW DB" Or LotItemClass = "TW PS" Or LotItemClass = "TW SWR" Then
            'Get Pull Test Number for selected Lot Number Data
            Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
            Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
            GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LotPartNumber
            GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
            GetPullTestNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetPullTestNumber = ""
            End Try
            con.Close()

            'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
            If GetPullTestNumber = "" Then
                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Do nothing - exact Pull Test exists
            End If

            'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
            If GetPullTestNumber = "" Then
                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Do nothing - exact Pull Test exists
            End If

            'Write to error log
            If GetPullTestNumber = "" Then
                GetPullTestNumber = "NO CERT"

                Try
                    'Write to error log
                    cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                    With cmd.Parameters
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                        .Add("@Date", SqlDbType.VarChar).Value = Today()
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtScanPartNumber.Text
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                        .Add("@Comment", SqlDbType.VarChar).Value = "Shipping Updater"
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
            End If
        ElseIf LotItemClass = "TW TT" Then
            'Get Pull Test Number for selected Lot Number Data
            Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
            Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
            GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LotPartNumber
            GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
            GetPullTestNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetPullTestNumber = ""
            End Try
            con.Close()

            'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
            If GetPullTestNumber = "" Then
                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Do nothing - exact Pull Test exists
            End If

            'Check for Pull Test using Steel Diameter
            If GetPullTestNumber = "" Then
                Dim GetSteelSize As String = ""

                Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM LotNumber WHERE LotNumber = @LotNumber"
                Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
                GetSteelSizeCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSteelSize = ""
                End Try
                con.Close()

                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND SteelSize = @SteelSize AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = GetSteelSize
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Skip
            End If

            'Write to error log
            If GetPullTestNumber = "" Then
                GetPullTestNumber = "NO CERT"

                Try
                    'Write to error log
                    cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                    With cmd.Parameters
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                        .Add("@Date", SqlDbType.VarChar).Value = Today()
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtScanPartNumber.Text
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                        .Add("@Comment", SqlDbType.VarChar).Value = "Shipping Updater"
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
            End If
        ElseIf LotItemClass = "Trufit Parts" Then
            'Skip printing cert
            'MsgBox("No cert exists for this TFP Part.", MsgBoxStyle.OkOnly)
        Else
            'Get Pull Test Number for selected Lot Number Data
            Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
            Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
            GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LotPartNumber
            GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
            GetPullTestNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetPullTestNumber = ""
            End Try
            con.Close()

            'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
            If GetPullTestNumber = "" Then
                Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND NominalLength >= @NominalLength AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                GetMinPartNumberCommand.Parameters.Add("@NominalLength", SqlDbType.VarChar).Value = LotNominalLength
                GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMinPartNumber = ""
                End Try
                con.Close()

                Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()
            Else
                'Do nothing - exact Pull Test exists
            End If

            'Write to error log
            If GetPullTestNumber = "" Then
                GetPullTestNumber = "NO CERT"

                Try
                    'Write to error log
                    cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                    With cmd.Parameters
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                        .Add("@Date", SqlDbType.VarChar).Value = Today()
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtScanPartNumber.Text
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                        .Add("@Comment", SqlDbType.VarChar).Value = "Shipping Updater"
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
            End If
        End If
    End Sub

    Public Sub ClearData()
        txtBinNumber.Clear()
        txtBoxQuantity.Clear()
        txtCustomer.Clear()
        txtCustomerPO.Clear()
        txtHeatNumber.Clear()
        txtLineNumber.Clear()
        txtLotNumber.Clear()
        txtPartNumber.Clear()
        txtPickTicketNumber.Clear()
        txtPiecesPerBox.Clear()
        txtRackWeight.Clear()
        txtSalesperson.Clear()
        txtShipMethod.Clear()
        txtShipVia.Clear()
        txtSONumber.Clear()
        txtSpecialInstructions.Clear()
        txtTotalPieces.Clear()

        txtScanBoxCount.Clear()
        txtScanBoxWeight.Clear()
        txtScanHeatNumber.Clear()
        txtScanLotNumber.Clear()
        txtScanPalletCount.Clear()
        txtScanPalletPieces.Clear()
        txtScanPalletWeight.Clear()
        txtScanPartDescription.Clear()
        txtScanPartNumber.Clear()

        txtScanPickLineNumber.Clear()
        txtScanPickPartNumber.Clear()

        lblQuantityOnHand.Text = ""
        lblTotalInRack.Text = ""

        dgvPickLines.DataSource = Nothing
        dgvViewRacking.DataSource = Nothing

        gpxRackData.Enabled = True
        gpxScanLot.Visible = False
        dgvViewRacking.Visible = True
        gpxRackingList.Visible = True

        txtPickTicketNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        PickPartNumber = ""
        RackPartNumber = ""
        LotPartNumber = ""
        GetPullTestNumber = ""
        GetShipmentNumber = 0
        LoadLotNumberForPullTest = ""
        LastLotLineNumber = 0
        NextLotLineNumber = 0
        RackingKeyQuantity = 0
        RackingKeyBoxQuantity = 0
        RackingKeyPiecesPerBox = 0
        RackingKeyRackingWeight = 0
        RackingKeyTotalPieces = 0
        PickDivisionID = ""
        RackingKey = 0
        PickLineNumber = 0
        LineBoxQuantity = 0
        LinePiecesPerBox = 0
        LineTotalPieces = 0
        LineRackingWeight = 0
        LinePieceWeight = 0
        AddRackingKey = 0
        AddBinNumber = 0
        AddHeatNumber = 0
        AddLotNumber = 0
        AddTotalPieces = 0
        AddBoxQuantity = 0
        AddPiecesPerBox = 0
        AddRackingWeight = 0

        txtPickTicketNumber.Focus()
    End Sub

    Public Sub ClearRackData()
        txtBinNumber.Clear()
        txtBoxQuantity.Clear()
        txtHeatNumber.Clear()
        txtLineNumber.Clear()
        txtLotNumber.Clear()
        txtPartNumber.Clear()
        txtPiecesPerBox.Clear()
        txtRackWeight.Clear()
        txtTotalPieces.Clear()
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

    Private Sub txtPickTicketNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPickTicketNumber.TextChanged
        If txtPickTicketNumber.Text.Length < 6 Then
            'Do nothing
        Else
            dgvViewRacking.DataSource = Nothing

            'Check Pick Status
            Dim GetPickStatus As String = ""

            Dim GetPickStatusStatement As String = "SELECT PLStatus FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
            Dim GetPickStatusCommand As New SqlCommand(GetPickStatusStatement, con)
            GetPickStatusCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
            GetPickStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPickStatus = CStr(GetPickStatusCommand.ExecuteScalar)
            Catch ex As Exception
                GetPickStatus = ""
            End Try
            con.Close()

            If GetPickStatus = "PENDING" Then
                ShowPickLines()
                LoadPickHeaderData()
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Form Logout
        FormLogoutRoutine()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvPickLines_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPickLines.CellClick
        If dgvPickLines.RowCount <> 0 Then
            ClearRackData()

            Dim RowIndex As Integer = Me.dgvPickLines.CurrentCell.RowIndex

            PickPartNumber = Me.dgvPickLines.Rows(RowIndex).Cells("ItemIDColumn").Value
            PickDivisionID = Me.dgvPickLines.Rows(RowIndex).Cells("PickDivisionIDColumn").Value
            PickLineNumber = Me.dgvPickLines.Rows(RowIndex).Cells("PickListLineKeyColumn").Value

            ShowRacking()
            LoadQuantityOnHand()

            txtScanPickPartNumber.Text = PickPartNumber
            txtScanPickLineNumber.Text = PickLineNumber
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvPickLines_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPickLines.CellContentClick
        If dgvPickLines.RowCount <> 0 Then
            ClearRackData()

            Dim RowIndex As Integer = Me.dgvPickLines.CurrentCell.RowIndex

            PickPartNumber = Me.dgvPickLines.Rows(RowIndex).Cells("ItemIDColumn").Value
            PickDivisionID = Me.dgvPickLines.Rows(RowIndex).Cells("PickDivisionIDColumn").Value
            PickLineNumber = Me.dgvPickLines.Rows(RowIndex).Cells("PickListLineKeyColumn").Value

            ShowRacking()
            LoadQuantityOnHand()

            txtScanPickPartNumber.Text = PickPartNumber
            txtScanPickLineNumber.Text = PickLineNumber
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvPickLines_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPickLines.RowHeaderMouseClick
        If dgvPickLines.RowCount <> 0 Then
            ClearRackData()

            Dim RowIndex As Integer = Me.dgvPickLines.CurrentCell.RowIndex

            PickPartNumber = Me.dgvPickLines.Rows(RowIndex).Cells("ItemIDColumn").Value
            PickDivisionID = Me.dgvPickLines.Rows(RowIndex).Cells("PickDivisionIDColumn").Value
            PickLineNumber = Me.dgvPickLines.Rows(RowIndex).Cells("PickListLineKeyColumn").Value

            ShowRacking()
            LoadQuantityOnHand()

            txtScanPickPartNumber.Text = PickPartNumber
            txtScanPickLineNumber.Text = PickLineNumber
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvViewRacking_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvViewRacking.CellClick
        If dgvViewRacking.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvViewRacking.CurrentCell.RowIndex

            RackingKey = Me.dgvViewRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value

            LoadRackData()
            txtLineNumber.Text = PickLineNumber
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvViewRacking_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvViewRacking.CellContentClick
        If dgvViewRacking.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvViewRacking.CurrentCell.RowIndex

            RackingKey = Me.dgvViewRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value

            LoadRackData()
            txtLineNumber.Text = PickLineNumber
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvViewRacking_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvViewRacking.RowHeaderMouseClick
        If dgvViewRacking.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvViewRacking.CurrentCell.RowIndex

            RackingKey = Me.dgvViewRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value

            LoadRackData()
            txtLineNumber.Text = PickLineNumber
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
    End Sub

    Private Sub txtBoxQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxQuantity.TextChanged
        If txtBoxQuantity.Text <> "" And txtPiecesPerBox.Text <> "" Then
            LineBoxQuantity = Val(txtBoxQuantity.Text)
            LinePiecesPerBox = Val(txtPiecesPerBox.Text)
            LoadItemPieceWeight()
            LineTotalPieces = LineBoxQuantity * LinePiecesPerBox
            LineRackingWeight = LineTotalPieces * LinePieceWeight

            LineRackingWeight = Math.Round(LineRackingWeight, 0)
            txtRackWeight.Text = LineRackingWeight
            txtTotalPieces.Text = LineTotalPieces

            If Val(txtBoxQuantity.Text) = 1 Then
                txtPiecesPerBox.ReadOnly = False
                txtPiecesPerBox.BackColor = Color.LightYellow
            Else
                txtPiecesPerBox.ReadOnly = True
                txtPiecesPerBox.BackColor = Color.White
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub txtPiecesPerBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiecesPerBox.TextChanged
        If txtBoxQuantity.Text <> "" And txtPiecesPerBox.Text <> "" Then
            LineBoxQuantity = Val(txtBoxQuantity.Text)
            LinePiecesPerBox = Val(txtPiecesPerBox.Text)
            LoadItemPieceWeight()
            LineTotalPieces = LineBoxQuantity * LinePiecesPerBox
            LineRackingWeight = LineTotalPieces * LinePieceWeight

            LineRackingWeight = Math.Round(LineRackingWeight, 0)
            txtRackWeight.Text = LineRackingWeight
            txtTotalPieces.Text = LineTotalPieces
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdAddToOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToOrder.Click
        '********************************************************************************************************
        'Fill Variables
        Dim RowIndex1 As Integer = Me.dgvPickLines.CurrentCell.RowIndex
        PickPartNumber = Me.dgvPickLines.Rows(RowIndex1).Cells("ItemIDColumn").Value
        Dim CalculatedBoxWeight As Double = 0
        Dim CalculatedPieceWeight As Double = 0

        Dim RowIndex As Integer = Me.dgvViewRacking.CurrentCell.RowIndex
        RackingKey = Me.dgvViewRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value
        RackingKeyQuantity = Me.dgvViewRacking.Rows(RowIndex).Cells("TotalPiecesColumn").Value
        RackingKeyBoxQuantity = Me.dgvViewRacking.Rows(RowIndex).Cells("BoxQuantityColumn").Value
        RackingKeyPiecesPerBox = Me.dgvViewRacking.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
        RackingKeyRackingWeight = Me.dgvViewRacking.Rows(RowIndex).Cells("RackingWeightColumn").Value
        RackingKeyTotalPieces = Me.dgvViewRacking.Rows(RowIndex).Cells("TotalPiecesColumn").Value
        RackingKeyPartDescription = Me.dgvViewRacking.Rows(RowIndex).Cells("PartDescriptionColumn").Value

        AddRackingKey = RackingKey
        AddHeatNumber = txtHeatNumber.Text
        AddLotNumber = txtLotNumber.Text
        AddBinNumber = txtBinNumber.Text
        AddBoxQuantity = Val(txtBoxQuantity.Text)
        AddPiecesPerBox = Val(txtPiecesPerBox.Text)
        AddRackingWeight = Val(txtRackWeight.Text)
        AddTotalPieces = Val(txtTotalPieces.Text)

        'Calculate Box Weight
        If RackingKeyBoxQuantity <> 0 Then
            CalculatedBoxWeight = RackingKeyRackingWeight / RackingKeyBoxQuantity
            CalculatedBoxWeight = Math.Round(CalculatedBoxWeight, 0)
            CalculatedPieceWeight = RackingKeyRackingWeight / RackingKeyTotalPieces
            CalculatedPieceWeight = Math.Round(CalculatedPieceWeight, 4)
        Else
            'Get Box Weight from Item List
            Dim GetBoxWeight As Double = 0

            Dim GetBoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetBoxWeightCommand As New SqlCommand(GetBoxWeightStatement, con)
            GetBoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PickPartNumber
            GetBoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetBoxWeight = CDbl(GetBoxWeightCommand.ExecuteScalar)
            Catch ex As Exception
                GetBoxWeight = 0
            End Try
            con.Close()

            CalculatedBoxWeight = GetBoxWeight
        End If

        If AddTotalPieces > RackingKeyQuantity Then
            MsgBox("You cannot add more pieces that are in the rack.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*******************************************************************************************************
        'Check to see if rack has been already pulled
        Dim CheckRack As Integer = 0
        Dim CheckQuantity As Double = 0

        Dim CheckRackStatement As String = "SELECT COUNT(RackingKey) FROM RackingTransactionTable WHERE RackingKey = @RackingKey"
        Dim CheckRackCommand As New SqlCommand(CheckRackStatement, con)
        CheckRackCommand.Parameters.Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckRack = CInt(CheckRackCommand.ExecuteScalar)
        Catch ex As Exception
            CheckRack = 0
        End Try
        con.Close()

        If CheckRack = 0 Then
            MsgBox("This rack has been emptied. Select another rack.", MsgBoxStyle.OkOnly)
            ClearRackData()
            Exit Sub
        End If

        Dim CheckQuantityStatement As String = "SELECT TotalPieces FROM RackingTransactionTable WHERE RackingKey = @RackingKey"
        Dim CheckQuantityCommand As New SqlCommand(CheckQuantityStatement, con)
        CheckQuantityCommand.Parameters.Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckQuantity = CDbl(CheckQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            CheckQuantity = 0
        End Try
        con.Close()

        If CheckQuantity <> RackingKeyTotalPieces Then
            MsgBox("This rack quantity has changed. Select another rack.", MsgBoxStyle.OkOnly)
            ClearRackData()
            Exit Sub
        End If
        '********************************************************************************************************
        'Check to see if summation of quantity of single line exceeds line quantity

        'Get current pulled lines
        Dim CurrentPulledQuantity As Integer = 0
        Dim GetPickListQuantity As Integer = 0

        Dim CurrentPulledQuantityStatement As String = "SELECT SUM(TotalPieces) FROM PickListPulledLines WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey"
        Dim CurrentPulledQuantityCommand As New SqlCommand(CurrentPulledQuantityStatement, con)
        CurrentPulledQuantityCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        CurrentPulledQuantityCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)

        Dim GetPickListQuantityStatement As String = "SELECT Quantity FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey"
        Dim GetPickListQuantityCommand As New SqlCommand(GetPickListQuantityStatement, con)
        GetPickListQuantityCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        GetPickListQuantityCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CurrentPulledQuantity = CInt(CurrentPulledQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            CurrentPulledQuantity = 0
        End Try
        Try
            GetPickListQuantity = CInt(GetPickListQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            GetPickListQuantity = 0
        End Try
        con.Close()

        CurrentPulledQuantity = CurrentPulledQuantity + AddTotalPieces

        If CurrentPulledQuantity > GetPickListQuantity Then
            Dim button As DialogResult = MessageBox.Show("Adding this to the order exceeds the quantity open. Do you wish to continue?", "ADD TO ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Skip and continue
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        End If
        '********************************************************************************************************
        'Get new racking key to add
        Dim GetNewLineKey As Integer = 0
        Dim GetNextLineKey As Integer = 0

        Dim GetNewLineKeyStatement As String = "SELECT MAX(LineKey) FROM PickListPulledLines WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey"
        Dim GetNewLineKeyCommand As New SqlCommand(GetNewLineKeyStatement, con)
        GetNewLineKeyCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        GetNewLineKeyCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetNewLineKey = CInt(GetNewLineKeyCommand.ExecuteScalar)
        Catch ex As Exception
            GetNewLineKey = 0
        End Try
        con.Close()

        GetNextLineKey = GetNewLineKey + 1
        '********************************************************************************************************
        'Get Item Class of Part
        Dim GetItemClass As String = ""
        Dim CheckLotNumber As String = ""
        Dim TempDivision As String = ""

        Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text
        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            GetItemClass = ""
        End Try
        con.Close()

        Select Case GetItemClass
            Case "TW CA", "TW SC", "TW DS", "TW DB", "TW PS", "TW TT", "TW TP", "TW NT", "TW SWR", "TW CS", "TW TR", "TW GS", "TW IT"
                CheckLotNumber = "YES TWD"
            Case "Trufit Parts"
                CheckLotNumber = "YES TFP"
            Case Else
                CheckLotNumber = "NO"
        End Select
        '********************************************************************************************************
        If CheckLotNumber = "NO" Then
            'skip lot number 
            'Insert into Pick List Pulled Lines Table
            Try
                'Update Lines
                cmd = New SqlCommand("INSERT INTO PickListPulledLines (PickListHeaderKey, PickListLineKey, LineKey, RackingKey, BinNumber, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight) Values (@PickListHeaderKey, @PickListLineKey, @LineKey, @RackingKey, @BinNumber, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight)", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)
                    .Add("@LineKey", SqlDbType.VarChar).Value = GetNextLineKey
                    .Add("@RackingKey", SqlDbType.VarChar).Value = AddRackingKey
                    .Add("@BinNumber", SqlDbType.VarChar).Value = AddBinNumber
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = AddHeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = AddLotNumber
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = AddBoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = AddPiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = AddTotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = AddRackingWeight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempPickNumber As Integer = 0
                Dim strPickNumber As String
                TempPickNumber = Val(txtPickTicketNumber.Text)
                strPickNumber = CStr(TempPickNumber)
                Dim strGetLineKey As String = ""
                strGetLineKey = CStr(GetNextLineKey)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "Shipping Updater - Add To Order - Pulled Lines"
                ErrorReferenceNumber = "PT # " + strPickNumber + " - Line Key - " + strGetLineKey
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        Else
            If CheckLotNumber = "YES TWD" Then
                TempDivision = "TWD"
            ElseIf CheckLotNumber = "YES TWD" Then
                TempDivision = "TFP"
            Else
                TempDivision = EmployeeCompanyCode
            End If
            'Validate Lot Number data
            Dim GetLotPartNumberStatement As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber AND DivisionID = @DivisionID"
            Dim GetLotPartNumberCommand As New SqlCommand(GetLotPartNumberStatement, con)
            GetLotPartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
            GetLotPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = TempDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LotPartNumber = CStr(GetLotPartNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LotPartNumber = ""
            End Try
            con.Close()

            If LotPartNumber = txtPartNumber.Text Then
                'Continue
            Else
                MsgBox("Part # does not match lot.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            If PickPartNumber = txtPartNumber.Text Then
                'Continue
            Else
                MsgBox("Part # does not match line part #.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '********************************************************************************************************
            'Insert into Pick List Pulled Lines Table
            '********************************************************************************************************
            Try
                'Update Lines
                cmd = New SqlCommand("INSERT INTO PickListPulledLines (PickListHeaderKey, PickListLineKey, LineKey, RackingKey, BinNumber, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight) Values (@PickListHeaderKey, @PickListLineKey, @LineKey, @RackingKey, @BinNumber, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight)", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)
                    .Add("@LineKey", SqlDbType.VarChar).Value = GetNextLineKey
                    .Add("@RackingKey", SqlDbType.VarChar).Value = AddRackingKey
                    .Add("@BinNumber", SqlDbType.VarChar).Value = AddBinNumber
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = AddHeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = AddLotNumber
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = AddBoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = AddPiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = AddTotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = AddRackingWeight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempPickNumber As Integer = 0
                Dim strPickNumber As String
                TempPickNumber = Val(txtPickTicketNumber.Text)
                strPickNumber = CStr(TempPickNumber)
                Dim strGetLineKey As String = ""
                strGetLineKey = CStr(GetNextLineKey)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "Shipping Updater - Add To Order - Pulled Lines"
                ErrorReferenceNumber = "PT # " + strPickNumber + " - Line Key - " + strGetLineKey
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '********************************************************************************************************
            'Insert Lot Numbers into shipment

            Dim GetShipmentNumberStatement As String = "SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber AND DivisionID = @DivisionID"
            Dim GetShipmentNumberCommand As New SqlCommand(GetShipmentNumberStatement, con)
            GetShipmentNumberCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
            GetShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetShipmentNumber = CInt(GetShipmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetShipmentNumber = 0
            End Try
            con.Close()

            If GetShipmentNumber = 0 Then
                MsgBox("No shipment can't be found.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '***************************************************************************************************************************
            'Get Pull Test
            LoadPullTestNumber()
            '****************************************************************************************************************************
            'Check to see if line exists and set to update - if not, then insert
            Dim CheckForLot As Integer = 0

            Dim CheckForLotStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber"
            Dim CheckForLotCommand As New SqlCommand(CheckForLotStatement, con)
            CheckForLotCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
            CheckForLotCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)
            CheckForLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckForLot = CInt(CheckForLotCommand.ExecuteScalar)
            Catch ex As Exception
                CheckForLot = 0
            End Try
            con.Close()
            '**************************************************************************************************************************
            If CheckForLot = 0 Then 'INSERT NEW LINE
                'Find the next Shipment Lot Line Number to use
                Dim MAXStatement As String = "SELECT MAX(LotLineNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)
                MAXCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                MAXCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastLotLineNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As Exception
                    LastLotLineNumber = 0
                End Try
                con.Close()

                NextLotLineNumber = LastLotLineNumber + 1

                Try
                    'Update Lines
                    cmd = New SqlCommand("INSERT INTO ShipmentLineLotNumbers (ShipmentNumber, ShipmentLineNumber, LotLineNumber, LotNumber, PullTestNumber, HeatQuantity) Values (@ShipmentNumber, @ShipmentLineNumber, @LotLineNumber, @LotNumber, @PullTestNumber, @HeatQuantity)", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)
                        .Add("@LotLineNumber", SqlDbType.VarChar).Value = NextLotLineNumber
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                        .Add("@PullTestNumber", SqlDbType.VarChar).Value = GetPullTestNumber
                        .Add("@HeatQuantity", SqlDbType.VarChar).Value = Val(txtTotalPieces.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempPickNumber As Integer = 0
                    Dim strPickNumber As String
                    TempPickNumber = Val(txtPickTicketNumber.Text)
                    strPickNumber = CStr(TempPickNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Shipping Updater - Add To Order - Insert Line Lot Numbers"
                    ErrorReferenceNumber = "PT # " + strPickNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else 'UPDATE EXISTING LINE
                'Get current quantity and add to it
                Dim CurrentQuantity As Integer = 0
                Dim UpdatedQuantity As Integer = 0

                Dim GetCurrentQuantityStatement As String = "SELECT HeatQuantity FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber"
                Dim GetCurrentQuantityCommand As New SqlCommand(GetCurrentQuantityStatement, con)
                GetCurrentQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                GetCurrentQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)
                GetCurrentQuantityCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CurrentQuantity = CInt(GetCurrentQuantityCommand.ExecuteScalar)
                Catch ex As Exception
                    CurrentQuantity = 0
                End Try
                con.Close()

                UpdatedQuantity = CurrentQuantity + Val(txtTotalPieces.Text)
                '*******************************************************************************************************
                Try
                    'Update Lines
                    cmd = New SqlCommand("UPDATE ShipmentLineLotNumbers SET HeatQuantity = @HeatQuantity WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtLineNumber.Text)
                        '.Add("@LotLineNumber", SqlDbType.VarChar).Value = NextLotLineNumber
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                        '.Add("@PullTestNumber", SqlDbType.VarChar).Value = AddHeatNumber
                        .Add("@HeatQuantity", SqlDbType.VarChar).Value = UpdatedQuantity
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempPickNumber As Integer = 0
                    Dim strPickNumber As String
                    TempPickNumber = Val(txtPickTicketNumber.Text)
                    strPickNumber = CStr(TempPickNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Shipping Updater - Add To Order - Update Line Lot Numbers"
                    ErrorReferenceNumber = "PT # " + strPickNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        End If
        '********************************************************************************************************
        'Update Rack Transaction Table and Rack Activity Table

        'If Racking Key quantity equals update quantity then delete, else update
        If RackingKeyQuantity = Val(txtTotalPieces.Text) Then 'DELETE RACK
            'Update Item List with new Standard Cost and Price
            cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE RackingKey = @RackingKey", con)

            With cmd.Parameters
                .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        ElseIf Val(txtTotalPieces.Text) > RackingKeyQuantity Then 'ERROR - CANNOT BE GREATER
            MsgBox("Error - rack not updated. Check rack.", MsgBoxStyle.OkOnly)
            Exit Sub
        ElseIf Val(txtTotalPieces.Text) < RackingKeyQuantity Then 'UPDATE RACK
            Dim UpdatePiecesPerBox As Integer = 0
            Dim UpdateBoxQuantity As Integer = 0
            Dim UpdateOrInsert As String = ""

            If Val(txtBoxQuantity.Text) = 1 And RackingKeyBoxQuantity = 1 Then
                UpdatePiecesPerBox = RackingKeyPiecesPerBox - Val(txtPiecesPerBox.Text)
                UpdateBoxQuantity = 1
                UpdateOrInsert = "UPDATE"
            ElseIf Val(txtBoxQuantity.Text) = 1 And RackingKeyBoxQuantity > 1 Then
                UpdatePiecesPerBox = Val(txtPiecesPerBox.Text)

                If UpdatePiecesPerBox = RackingKeyPiecesPerBox Then
                    'Remove one box
                    UpdateOrInsert = "UPDATE"
                ElseIf UpdatePiecesPerBox < RackingKeyPiecesPerBox Then
                    'Remove one box and insert remainder of box as new racking key
                    UpdateOrInsert = "INSERT"
                Else
                    'If pieces to add is greater than box pieces
                    MsgBox("You cannot add more pieces in one box than the rack has.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                UpdateBoxQuantity = RackingKeyBoxQuantity - Val(txtBoxQuantity.Text)
            Else
                UpdatePiecesPerBox = Val(txtPiecesPerBox.Text)
                UpdateBoxQuantity = RackingKeyBoxQuantity - Val(txtBoxQuantity.Text)
                UpdateOrInsert = "UPDATE"
            End If

            If UpdateOrInsert = "UPDATE" Then
                Try
                    'Update Racking Activity Log
                    cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey", con)

                    With cmd.Parameters
                        .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                        .Add("@BoxQuantity", SqlDbType.VarChar).Value = UpdateBoxQuantity
                        .Add("@PiecesPerBox", SqlDbType.VarChar).Value = UpdatePiecesPerBox
                        .Add("@TotalPieces", SqlDbType.VarChar).Value = RackingKeyQuantity - Val(txtTotalPieces.Text)
                        .Add("@RackingWeight", SqlDbType.VarChar).Value = RackingKeyRackingWeight - Val(txtRackWeight.Text)
                        .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                        .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempPickNumber As Integer = 0
                    Dim strPickNumber As String
                    TempPickNumber = Val(txtPickTicketNumber.Text)
                    strPickNumber = CStr(TempPickNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Shipping Updater - Add To Order - Update Rack Transactions"
                    ErrorReferenceNumber = "PT # " + strPickNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                Try
                    'Update Line
                    cmd = New SqlCommand("UPDATE RackingMasterList SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight WHERE RackingKey = @RackingKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID
                        .Add("@BoxQuantity", SqlDbType.VarChar).Value = UpdateBoxQuantity
                        .Add("@PiecesPerBox", SqlDbType.VarChar).Value = UpdatePiecesPerBox
                        .Add("@TotalPieces", SqlDbType.VarChar).Value = RackingKeyQuantity - Val(txtTotalPieces.Text)
                        .Add("@RackingWeight", SqlDbType.VarChar).Value = RackingKeyRackingWeight - Val(txtRackWeight.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                    Dim TempPickNumber As Integer = 0
                    Dim strPickNumber As String
                    TempPickNumber = Val(txtPickTicketNumber.Text)
                    strPickNumber = CStr(TempPickNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Shipping Updater - Add To Order - Update Rack Master List"
                    ErrorReferenceNumber = "PT # " + strPickNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Get new Racking Key for Insert
                Dim GetNewRackingKey As Integer = 0

                Dim GetNewRackingKeyStatement As String = "SELECT MAX(RackingKey) FROM RackingTransactionTable"
                Dim GetNewRackingKeyCommand As New SqlCommand(GetNewRackingKeyStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetNewRackingKey = CInt(GetNewRackingKeyCommand.ExecuteScalar)
                Catch ex As Exception
                    GetNewRackingKey = 0
                End Try
                con.Close()

                Try
                    'Update Racking for removal of one box
                    cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey", con)

                    With cmd.Parameters
                        .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                        .Add("@BoxQuantity", SqlDbType.VarChar).Value = UpdateBoxQuantity
                        .Add("@TotalPieces", SqlDbType.VarChar).Value = RackingKeyQuantity - RackingKeyPiecesPerBox
                        .Add("@RackingWeight", SqlDbType.VarChar).Value = CalculatedBoxWeight * UpdateBoxQuantity
                        .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                        .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Insert the one partial box with a new racking key
                    cmd = New SqlCommand("INSERT INTO RackingTransactionTable (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, ActivityDate, DivisionID, CreationDate, AddedBy, Comment) values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @ActivityDate, @DivisionID, @CreationDate, @AddedBy, @Comment)", con)

                    With cmd.Parameters
                        .Add("@RackingKey", SqlDbType.VarChar).Value = GetNewRackingKey + 1
                        .Add("@BinNumber", SqlDbType.VarChar).Value = txtBinNumber.Text
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = RackingKeyPartDescription
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                        .Add("@BoxQuantity", SqlDbType.VarChar).Value = 1
                        .Add("@PiecesPerBox", SqlDbType.VarChar).Value = RackingKeyPiecesPerBox - Val(txtPiecesPerBox.Text)
                        .Add("@TotalPieces", SqlDbType.VarChar).Value = RackingKeyPiecesPerBox - Val(txtPiecesPerBox.Text)
                        .Add("@RackingWeight", SqlDbType.VarChar).Value = Math.Round(CalculatedPieceWeight * (RackingKeyPiecesPerBox - Val(txtPiecesPerBox.Text)), 0)
                        .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                        .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@Comment", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempPickNumber As Integer = 0
                    Dim strPickNumber As String
                    TempPickNumber = Val(txtPickTicketNumber.Text)
                    strPickNumber = CStr(TempPickNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Shipping Updater - Add To Order - Update Rack Transactions"
                    ErrorReferenceNumber = "PT # " + strPickNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                Try
                    'Update existing record for removal of one box
                    cmd = New SqlCommand("UPDATE RackingMasterList SET BoxQuantity = @BoxQuantity, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight WHERE RackingKey = @RackingKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID
                        .Add("@BoxQuantity", SqlDbType.VarChar).Value = UpdateBoxQuantity
                        .Add("@TotalPieces", SqlDbType.VarChar).Value = RackingKeyQuantity - RackingKeyPiecesPerBox
                        .Add("@RackingWeight", SqlDbType.VarChar).Value = CalculatedBoxWeight * UpdateBoxQuantity
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Insert the one partial box with a new racking key
                    cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                    With cmd.Parameters
                        .Add("@RackingKey", SqlDbType.VarChar).Value = GetNewRackingKey + 1
                        .Add("@BinNumber", SqlDbType.VarChar).Value = txtBinNumber.Text
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = RackingKeyPartDescription
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                        .Add("@BoxQuantity", SqlDbType.VarChar).Value = 1
                        .Add("@PiecesPerBox", SqlDbType.VarChar).Value = RackingKeyPiecesPerBox - Val(txtPiecesPerBox.Text)
                        .Add("@TotalPieces", SqlDbType.VarChar).Value = RackingKeyPiecesPerBox - Val(txtPiecesPerBox.Text)
                        .Add("@RackingWeight", SqlDbType.VarChar).Value = Math.Round(CalculatedPieceWeight * (RackingKeyPiecesPerBox - Val(txtPiecesPerBox.Text)), 0)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                    Dim TempPickNumber As Integer = 0
                    Dim strPickNumber As String
                    TempPickNumber = Val(txtPickTicketNumber.Text)
                    strPickNumber = CStr(TempPickNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Shipping Updater - Add To Order - Update Rack Master List"
                    ErrorReferenceNumber = "PT # " + strPickNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        End If
        '*************************************************************************************************************************
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
            AddPickTicketNumber = txtPickTicketNumber.Text

            'Update Racking Activity Log
            cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate, PickTicketNumber) Values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate, @PickTicketNumber)", con)

            With cmd.Parameters
                .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                .Add("@BinNumber", SqlDbType.VarChar).Value = AddBinNumber
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                .Add("@HeatNumber", SqlDbType.VarChar).Value = AddHeatNumber
                .Add("@LotNumber", SqlDbType.VarChar).Value = AddLotNumber
                .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = AddTotalPieces
                .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = 0
                .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = AddTotalPieces * -1
                .Add("@DivisionID", SqlDbType.VarChar).Value = PickDivisionID
                .Add("@TransactionType", SqlDbType.VarChar).Value = "DELETED"
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
                .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                .Add("@PickTicketNumber", SqlDbType.VarChar).Value = AddPickTicketNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempPickNumber As Integer = 0
            Dim strPickNumber As String
            TempPickNumber = Val(txtPickTicketNumber.Text)
            strPickNumber = CStr(TempPickNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = EmployeeCompanyCode
            ErrorDescription = "Shipping Updater - Add To Order - Update Racking Log"
            ErrorReferenceNumber = "PT # " + strPickNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '****************************************************************************************
        'Clear Variables
        ClearVariables()
        ClearRackData()

        ShowPickLines()
        ShowRacking()

        MsgBox("Shipment and racks have been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub RemovePulledItemsFrom1LineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemovePulledItemsFrom1LineToolStripMenuItem.Click
        'Check Pick Status
        Dim GetPickStatus As String = ""

        Dim GetPickStatusStatement As String = "SELECT PLStatus FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
        Dim GetPickStatusCommand As New SqlCommand(GetPickStatusStatement, con)
        GetPickStatusCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        GetPickStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetPickStatus = CStr(GetPickStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetPickStatus = ""
        End Try
        con.Close()

        If GetPickStatus = "PENDING" Then
            Dim button As DialogResult = MessageBox.Show("This will also remove all of the lot numbers from the shipment line. Countinue?", "REMOVE PULLED QTY FROM LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Get Shipment Number
                Dim TempShipmentNumber As Integer

                Dim TempShipmentNumberStatement As String = "SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber AND DivisionID = @DivisionID"
                Dim TempShipmentNumberCommand As New SqlCommand(TempShipmentNumberStatement, con)
                TempShipmentNumberCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
                TempShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TempShipmentNumber = CInt(TempShipmentNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    TempShipmentNumber = 0
                End Try
                con.Close()
                '*************************************************************************
                'Get Line Number to delete
                Dim CurrentRowNumber As Integer = 0
                Dim RowIndex As Integer = Me.dgvPickLines.CurrentCell.RowIndex

                CurrentRowNumber = Me.dgvPickLines.Rows(RowIndex).Cells("PickLisyLineKeyColumn").Value
                '*************************************************************************
                'Update Item List with new Standard Cost and Price
                cmd = New SqlCommand("DELETE FROM PickListPulledLines WHERE PickListHeaderKey = @PickListHeaderKey AND PIckListLineKey = @PickListLineKey", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = CurrentRowNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*************************************************************************
                'Update Item List with new Standard Cost and Price
                cmd = New SqlCommand("DELETE FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = TempShipmentNumber
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = CurrentRowNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Pick Ticket and shipment have been cleared of lot numbers for the selected line.", MsgBoxStyle.OkOnly)
                ShowPickLines()
            ElseIf button = DialogResult.No Then
                'Do nothing
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub RemoveAllPulledItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllPulledItemsToolStripMenuItem.Click
        'Check Pick Status
        Dim GetPickStatus As String = ""

        Dim GetPickStatusStatement As String = "SELECT PLStatus FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
        Dim GetPickStatusCommand As New SqlCommand(GetPickStatusStatement, con)
        GetPickStatusCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        GetPickStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetPickStatus = CStr(GetPickStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetPickStatus = ""
        End Try
        con.Close()

        If GetPickStatus = "PENDING" Then
            Dim button As DialogResult = MessageBox.Show("This will also remove all of the lot numbers from the shipment. Countinue?", "REMOVE ALL PULLED LINES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Get Shipment Number
                Dim TempShipmentNumber As Integer

                Dim TempShipmentNumberStatement As String = "SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber AND DivisionID = @DivisionID"
                Dim TempShipmentNumberCommand As New SqlCommand(TempShipmentNumberStatement, con)
                TempShipmentNumberCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
                TempShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TempShipmentNumber = CInt(TempShipmentNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    TempShipmentNumber = 0
                End Try
                con.Close()
                '*************************************************************************
                'Update Item List with new Standard Cost and Price
                cmd = New SqlCommand("DELETE FROM PickListPulledLines WHERE PickListHeaderKey = @PickListHeaderKey", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*************************************************************************
                'Update Item List with new Standard Cost and Price
                cmd = New SqlCommand("DELETE FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = TempShipmentNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Pick Ticket and shipment have been cleared of lot numbers.", MsgBoxStyle.OkOnly)
                ShowPickLines()
            ElseIf button = DialogResult.No Then
                'Do nothing
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdExitLotScanner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExitLotScanner.Click
        gpxRackData.Enabled = True
        gpxScanLot.Visible = False
        dgvViewRacking.Visible = True
        gpxRackingList.Visible = True
    End Sub

    Private Sub cmdScanLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScanLotNumber.Click
        gpxRackData.Enabled = False
        gpxScanLot.Visible = True
        dgvViewRacking.Visible = False
        gpxRackingList.Visible = False

        txtScanLotNumber.Focus()
    End Sub

    Private Sub txtScanLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanLotNumber.TextChanged
        LoadScanLotNumberData()
    End Sub

    Private Sub txtScanBoxCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanBoxCount.TextChanged
        If txtScanBoxCount.Text <> "" And txtScanPalletCount.Text <> "" Then
            Dim TempPiecesInBox, TempBoxesOnPallet, TempBoxWeight As Integer

            TempBoxesOnPallet = Val(txtScanPalletCount.Text)
            TempPiecesInBox = Val(txtScanBoxCount.Text)
            TempBoxWeight = Val(txtScanBoxWeight.Text)

            txtScanPalletPieces.Text = TempBoxesOnPallet * TempPiecesInBox
            txtScanPalletWeight.Text = TempBoxesOnPallet * TempBoxWeight
        Else
            'Do nothing
        End If
    End Sub

    Private Sub txtScanPalletCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanPalletCount.TextChanged
        If txtScanBoxCount.Text <> "" And txtScanPalletCount.Text <> "" Then
            Dim TempPiecesInBox, TempBoxesOnPallet, TempBoxWeight As Integer

            TempBoxesOnPallet = Val(txtScanPalletCount.Text)
            TempPiecesInBox = Val(txtScanBoxCount.Text)
            TempBoxWeight = Val(txtScanBoxWeight.Text)

            txtScanPalletPieces.Text = TempBoxesOnPallet * TempPiecesInBox
            txtScanPalletWeight.Text = TempBoxesOnPallet * TempBoxWeight
        Else
            'Do nothing
        End If
    End Sub

    Private Sub txtScanBoxWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanBoxWeight.TextChanged
        If txtScanBoxCount.Text <> "" And txtScanPalletCount.Text <> "" Then
            Dim TempPiecesInBox, TempBoxesOnPallet, TempBoxWeight As Integer

            TempBoxesOnPallet = Val(txtScanPalletCount.Text)
            TempPiecesInBox = Val(txtScanBoxCount.Text)
            TempBoxWeight = Val(txtScanBoxWeight.Text)

            txtScanPalletPieces.Text = TempBoxesOnPallet * TempPiecesInBox
            txtScanPalletWeight.Text = TempBoxesOnPallet * TempBoxWeight
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdClearLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLotNumber.Click
        txtScanBoxCount.Clear()
        txtScanBoxWeight.Clear()
        txtScanHeatNumber.Clear()
        txtScanLotNumber.Clear()
        txtScanPalletCount.Clear()
        txtScanPalletPieces.Clear()
        txtScanPalletWeight.Clear()
        txtScanPartDescription.Clear()
        txtScanPartNumber.Clear()
        txtScanLotNumber.Focus()
    End Sub

    Private Sub txtScanPartNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanPartNumber.TextChanged
        If txtScanLotNumber.Text = "" Then
            LoadPartData()
        End If
    End Sub

    Private Sub cmdAddLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLotNumber.Click
        '********************************************************************************************************
        'Check to see if summation of quantity of single line exceeds line quantity

        'Get current pulled lines
        Dim CurrentPulledQuantity As Integer = 0
        Dim GetPickListQuantity As Integer = 0

        Dim CurrentPulledQuantityStatement As String = "SELECT SUM(TotalPieces) FROM PickListPulledLines WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey"
        Dim CurrentPulledQuantityCommand As New SqlCommand(CurrentPulledQuantityStatement, con)
        CurrentPulledQuantityCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        CurrentPulledQuantityCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)

        Dim GetPickListQuantityStatement As String = "SELECT Quantity FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey"
        Dim GetPickListQuantityCommand As New SqlCommand(CurrentPulledQuantityStatement, con)
        GetPickListQuantityCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        GetPickListQuantityCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CurrentPulledQuantity = CInt(CurrentPulledQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            CurrentPulledQuantity = 0
        End Try
        Try
            GetPickListQuantity = CInt(GetPickListQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            GetPickListQuantity = 0
        End Try
        con.Close()

        CurrentPulledQuantity = CurrentPulledQuantity + Val(txtScanPalletPieces.Text)

        If CurrentPulledQuantity > GetPickListQuantity Then
            Dim button As DialogResult = MessageBox.Show("Adding this to the order exceeds the quantity open. Do you wish to continue?", "ADD TO ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Skip and continue
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        End If
        '********************************************************************************************************
        'Get new racking key to add
        Dim GetNewLineKey As Integer = 0
        Dim GetNextLineKey As Integer = 0

        Dim GetNewLineKeyStatement As String = "SELECT MAX(LineKey) FROM PickListPulledLines WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey"
        Dim GetNewLineKeyCommand As New SqlCommand(GetNewLineKeyStatement, con)
        GetNewLineKeyCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        GetNewLineKeyCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetNewLineKey = CInt(GetNewLineKeyCommand.ExecuteScalar)
        Catch ex As Exception
            GetNewLineKey = 0
        End Try
        con.Close()

        GetNextLineKey = GetNewLineKey + 1
        '********************************************************************************************************
        If txtScanLotNumber.Text = "" And txtScanPartNumber.Text <> "" And (txtScanPartNumber.Text.StartsWith("FER") Or txtScanPartNumber.Text.StartsWith("CD") Or txtScanPartNumber.Text.StartsWith("CH")) Then
            'Add part without a Lot Number (Ferrules Only)

            'Validate part
            If txtScanPickPartNumber.Text = txtScanPartNumber.Text Then
                'Continue
            Else
                MsgBox("Part Number has to match part of the pick ticket.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '********************************************************************************************************
            'Insert into Pick List Pulled Lines Table
            Try
                'Update Lines
                cmd = New SqlCommand("INSERT INTO PickListPulledLines (PickListHeaderKey, PickListLineKey, LineKey, RackingKey, BinNumber, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight) Values (@PickListHeaderKey, @PickListLineKey, @LineKey, @RackingKey, @BinNumber, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight)", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)
                    .Add("@LineKey", SqlDbType.VarChar).Value = GetNextLineKey
                    .Add("@RackingKey", SqlDbType.VarChar).Value = 0
                    .Add("@BinNumber", SqlDbType.VarChar).Value = ""
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = txtScanHeatNumber.Text
                    .Add("@LotNumber", SqlDbType.VarChar).Value = ""
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = Val(txtScanPalletCount.Text)
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = Val(txtScanBoxCount.Text)
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = Val(txtScanPalletPieces.Text)
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = Val(txtScanPalletWeight.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
            End Try
            '********************************************************************************************************
            ShowPickLines()

            'Clear Manual entry Fields
            cmdClearLotNumber_Click(sender, e)

            Exit Sub
        ElseIf txtScanLotNumber.Text = "" And txtScanPartNumber.Text = "" Then
            MsgBox("You must select a part number or lot number to enter.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If
        '******************************************************************************************************
        'Validate Lot Number data
        Dim GetLotPartNumberStatement As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber AND DivisionID = @DivisionID"
        Dim GetLotPartNumberCommand As New SqlCommand(GetLotPartNumberStatement, con)
        GetLotPartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text
        GetLotPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LotPartNumber = CStr(GetLotPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LotPartNumber = ""
        End Try
        con.Close()

        If LotPartNumber = txtScanPartNumber.Text Then
            'Continue
        Else
            MsgBox("Part # does not match lot.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtScanPickPartNumber.Text = txtScanPartNumber.Text Then
            'Continue
        Else
            MsgBox("Part # does not match line part #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************************************
        'Insert into Pick List Pulled Lines Table
        Try
            'Update Lines
            cmd = New SqlCommand("INSERT INTO PickListPulledLines (PickListHeaderKey, PickListLineKey, LineKey, RackingKey, BinNumber, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight) Values (@PickListHeaderKey, @PickListLineKey, @LineKey, @RackingKey, @BinNumber, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight)", con)

            With cmd.Parameters
                .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
                .Add("@PickListLineKey", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)
                .Add("@LineKey", SqlDbType.VarChar).Value = GetNextLineKey
                .Add("@RackingKey", SqlDbType.VarChar).Value = 0
                .Add("@BinNumber", SqlDbType.VarChar).Value = ""
                .Add("@HeatNumber", SqlDbType.VarChar).Value = txtScanHeatNumber.Text
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text
                .Add("@BoxQuantity", SqlDbType.VarChar).Value = Val(txtScanPalletCount.Text)
                .Add("@PiecesPerBox", SqlDbType.VarChar).Value = Val(txtScanBoxCount.Text)
                .Add("@TotalPieces", SqlDbType.VarChar).Value = Val(txtScanPalletPieces.Text)
                .Add("@RackingWeight", SqlDbType.VarChar).Value = Val(txtScanPalletWeight.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
        End Try
        '********************************************************************************************************
        'Insert Lot Numbers into shipment

        Dim GetShipmentNumberStatement As String = "SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber AND DivisionID = @DivisionID"
        Dim GetShipmentNumberCommand As New SqlCommand(GetShipmentNumberStatement, con)
        GetShipmentNumberCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(txtPickTicketNumber.Text)
        GetShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetShipmentNumber = CInt(GetShipmentNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetShipmentNumber = 0
        End Try
        con.Close()

        If GetShipmentNumber = 0 Then
            MsgBox("No shipment can be found.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '***************************************************************************************************************************
        'Get Pull Test
        LoadPullTestNumberManualEntry()
        '****************************************************************************************************************************
        'Check to see if line exists and set to update - if not, then insert
        Dim CheckForLot As Integer = 0

        Dim CheckForLotStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber"
        Dim CheckForLotCommand As New SqlCommand(CheckForLotStatement, con)
        CheckForLotCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
        CheckForLotCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)
        CheckForLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckForLot = CInt(CheckForLotCommand.ExecuteScalar)
        Catch ex As Exception
            CheckForLot = 0
        End Try
        con.Close()
        '**************************************************************************************************************************
        If CheckForLot = 0 Then 'INSERT NEW LINE
            'Find the next Shipment Lot Line Number to use
            Dim MAXStatement As String = "SELECT MAX(LotLineNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)
            MAXCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
            MAXCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastLotLineNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastLotLineNumber = 0
            End Try
            con.Close()

            NextLotLineNumber = LastLotLineNumber + 1

            Try
                'Update Lines
                cmd = New SqlCommand("INSERT INTO ShipmentLineLotNumbers (ShipmentNumber, ShipmentLineNumber, LotLineNumber, LotNumber, PullTestNumber, HeatQuantity) Values (@ShipmentNumber, @ShipmentLineNumber, @LotLineNumber, @LotNumber, @PullTestNumber, @HeatQuantity)", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)
                    .Add("@LotLineNumber", SqlDbType.VarChar).Value = NextLotLineNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text
                    .Add("@PullTestNumber", SqlDbType.VarChar).Value = GetPullTestNumber
                    .Add("@HeatQuantity", SqlDbType.VarChar).Value = Val(txtScanPalletPieces.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
            End Try
        Else 'UPDATE EXISTING LINE
            'Get current quantity and add to it
            Dim CurrentQuantity As Integer = 0
            Dim UpdatedQuantity As Integer = 0

            Dim GetCurrentQuantityStatement As String = "SELECT HeatQuantity FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber"
            Dim GetCurrentQuantityCommand As New SqlCommand(GetCurrentQuantityStatement, con)
            GetCurrentQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
            GetCurrentQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)
            GetCurrentQuantityCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CurrentQuantity = CInt(GetCurrentQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                CurrentQuantity = 0
            End Try
            con.Close()

            UpdatedQuantity = CurrentQuantity + Val(txtScanPalletPieces.Text)
            '*******************************************************************************************************
            Try
                'Update Lines
                cmd = New SqlCommand("UPDATE ShipmentLineLotNumbers SET HeatQuantity = @HeatQuantity WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(txtScanPickLineNumber.Text)
                    '.Add("@LotLineNumber", SqlDbType.VarChar).Value = NextLotLineNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = txtScanLotNumber.Text
                    '.Add("@PullTestNumber", SqlDbType.VarChar).Value = AddHeatNumber
                    .Add("@HeatQuantity", SqlDbType.VarChar).Value = UpdatedQuantity
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
            End Try
        End If

        'Upadte Datagrid and cleat fields
        ShowPickLines()

        cmdClearLotNumber_Click(sender, e)
    End Sub

    Private Sub ViewRacksPulledFromToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewRacksPulledFromToolStripMenuItem.Click
        If txtPickTicketNumber.Text = "" Then
            'Skip
        Else
            GlobalPickListNumber = Val(txtPickTicketNumber.Text)
            GlobalDivisionCode = EmployeeCompanyCode

            Using NewOpenRacking As New ShippingUpdaterRacking
                Dim Result = NewOpenRacking.ShowDialog()
            End Using

            ShowPickLines()
            ShowRacking()
        End If
    End Sub

End Class