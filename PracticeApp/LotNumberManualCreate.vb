Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class LotNumberManualCreate
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim FormHeatFileRecord As Integer = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub LotNumberManualCreate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID AND Status <> @Status ORDER BY FOXNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "INACTIVE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "FOXTable")
        cboFOXNumber.DataSource = ds1.Tables("FOXTable")
        con.Close()
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT (HeatNumber) FROM HeatNumberLog WHERE Status = @Status ORDER BY HeatNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "HeatNumberLog")
        cboHeatNumber.DataSource = ds2.Tables("HeatNumberLog")
        con.Close()
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE Status = @Status ORDER BY LotNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "LotNumber")
        cboLotNumber.DataSource = ds3.Tables("LotNumber")
        con.Close()
        cboLotNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadRMID()
        cmd = New SqlCommand("SELECT RMID FROM RawMaterialsTable WHERE SteelStatus = @SteelStatus AND DivisionID ='TWD' ORDER BY RMID", con)
        cmd.Parameters.Add("@SteelStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "RawMaterialsTable")
        cboRMID.DataSource = ds4.Tables("RawMaterialsTable")
        con.Close()
        cboRMID.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemList")
        cboPartNumber.DataSource = ds5.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Private Sub clbHeatFileRecords_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbHeatFileRecords.SelectedValueChanged
        'Load Heat Number Data when heat file record is checked
        If clbHeatFileRecords.CheckedItems.Count > 1 Then
            MsgBox("Only check one heat size.", MsgBoxStyle.OkOnly)
            Exit Sub
        ElseIf clbHeatFileRecords.CheckedItems.Count = 0 Then
            'Clear Heat Fields
            txtSteelCarbonFromHeat.Clear()
            txtSteelSizeFromHeat.Clear()
            txtSteelPONumber.Clear()
            txtSteelVendor.Clear()
            txtSteelDateReceived.Clear()
        Else
            'If one item is checked, get the Heat File #
            Dim HeatRecordString As String = ""

            HeatRecordString = clbHeatFileRecords.CheckedItems(0)
            'Get Heat File Record from the string value - will be between the asterisks (**)
            Dim strHeatFileNumber As String = ""
     
            Dim startIndex As Integer = HeatRecordString.IndexOf("/*")
            Dim endIndex As Integer = HeatRecordString.IndexOf("*\")

            If endIndex > startIndex Then
                strHeatFileNumber = HeatRecordString.Substring(startIndex + 2, endIndex - startIndex - 2)
            End If

            If strHeatFileNumber <> "" Then
                FormHeatFileRecord = CInt(strHeatFileNumber)
                LoadHeatFileRecordsByHeatNumber()
            End If
        End If
    End Sub

    Public Sub LoadHeatFileRecords()
        clbHeatFileRecords.Items.Clear()

        Dim RowSteelCarbon, RowSteelSize, RowHeatNumberSteel, RowHeatFileNumber As String
        Dim intHeatFileNumber As Integer = 0

        cmd = New SqlCommand("SELECT SteelType, SteelSize, HeatFileNumber FROM HeatNumberLog WHERE HeatNumber = @HeatNumber", con)
        cmd.Parameters.Add("HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        Dim DT As New Data.DataTable("HeatNumberLog")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(DT)
        con.Close()

        For Each Row As DataRow In DT.Rows
            RowSteelCarbon = Row(0).ToString
            RowSteelSize = Row(1).ToString
            intHeatFileNumber = Row(2)
            RowHeatFileNumber = CStr(intHeatFileNumber)

            RowHeatNumberSteel = RowSteelCarbon + " / " + RowSteelSize + " -  (Heat File # - /*" + RowHeatFileNumber + "*\)"

            clbHeatFileRecords.Items.Add(RowHeatNumberSteel)
        Next

        If clbHeatFileRecords.Items.Count = 1 Then
            clbHeatFileRecords.SetItemChecked(0, True)
            FormHeatFileRecord = intHeatFileNumber
            LoadHeatFileRecordsByHeatNumber()
        ElseIf clbHeatFileRecords.Items.Count <> 1 Then
            'Clear Heat Fields
            txtSteelCarbonFromHeat.Clear()
            txtSteelSizeFromHeat.Clear()
            txtSteelPONumber.Clear()
            txtSteelVendor.Clear()
            txtSteelDateReceived.Clear()
        End If
    End Sub

    Public Sub LoadHeatFileRecordsByHeatNumber()
        'Get Heat Records from the Heat File Number
        Dim VendorID, DateReceived, SteelPONumber, SteelType, SteelSize As String

        'Get steel for the specific RMID
        Dim GetHeatDataString As String = "SELECT * FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber"
        Dim GetHeatDataCommand As New SqlCommand(GetHeatDataString, con)
        GetHeatDataCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = FormHeatFileRecord

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetHeatDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SteelType")) Then
                SteelType = ""
            Else
                SteelType = reader.Item("SteelType")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("VendorID")) Then
                VendorID = ""
            Else
                VendorID = reader.Item("VendorID")
            End If
            If IsDBNull(reader.Item("DateReceived")) Then
                DateReceived = ""
            Else
                DateReceived = reader.Item("DateReceived")
            End If
            If IsDBNull(reader.Item("SteelPONumber")) Then
                SteelPONumber = ""
            Else
                SteelPONumber = reader.Item("SteelPONumber")
            End If
        Else
            SteelType = ""
            SteelPONumber = ""
            SteelSize = ""
            VendorID = ""
            DateReceived = ""
        End If
        reader.Close()
        con.Close()

        txtSteelCarbonFromHeat.Text = SteelType
        txtSteelSizeFromHeat.Text = SteelSize
        txtSteelPONumber.Text = SteelPONumber
        txtSteelVendor.Text = VendorID
        txtSteelDateReceived.Text = DateReceived
    End Sub

    Public Sub LoadSteelDetails()
        Dim SteelDescription, SteelSize, SteelCarbon As String

        'Get steel for the specific RMID
        Dim GetSteelDataString As String = "SELECT * FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = 'TWD'"
        Dim GetSteelDataCommand As New SqlCommand(GetSteelDataString, con)
        GetSteelDataCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = cboRMID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader2 As SqlDataReader = GetSteelDataCommand.ExecuteReader()
        If reader2.HasRows Then
            reader2.Read()
            If IsDBNull(reader2.Item("Description")) Then
                SteelDescription = ""
            Else
                SteelDescription = reader2.Item("Description")
            End If
            If IsDBNull(reader2.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader2.Item("SteelSize")
            End If
            If IsDBNull(reader2.Item("Carbon")) Then
                SteelCarbon = ""
            Else
                SteelCarbon = reader2.Item("Carbon")
            End If
        Else
            SteelDescription = ""
            SteelCarbon = ""
            SteelSize = ""
        End If
        reader2.Close()
        con.Close()

        txtSteelCarbonFromRMID.Text = SteelCarbon
        txtSteelSizeFromRMID.Text = SteelSize
        txtSteelDescription.Text = SteelDescription
    End Sub

    Public Sub LoadFOXDetails()
        Dim FOXComment, FOXPartNumber, AlternateSteel, CertificationType, BoxType As String
        Dim RawMaterialWeight, ScrapWeight, FinishWeight As Double
        Dim BlueprintNumber, BlueprintRevision As String

        'Get FOX Data for the specific FOX Number
        Dim GetFOXDataString As String = "SELECT * FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
        Dim GetFOXDataCommand As New SqlCommand(GetFOXDataString, con)
        GetFOXDataCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        GetFOXDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetFOXDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ScheduledRMID")) Then
                AlternateSteel = ""
            Else
                AlternateSteel = reader.Item("ScheduledRMID")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                FOXPartNumber = ""
            Else
                FOXPartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                BlueprintNumber = ""
            Else
                BlueprintNumber = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("BlueprintRevision")) Then
                BlueprintRevision = ""
            Else
                BlueprintRevision = reader.Item("BlueprintRevision")
            End If
            If IsDBNull(reader.Item("CertificationType")) Then
                CertificationType = ""
            Else
                CertificationType = reader.Item("CertificationType")
            End If
            If IsDBNull(reader.Item("BoxType")) Then
                BoxType = ""
            Else
                BoxType = reader.Item("BoxType")
            End If
            If IsDBNull(reader.Item("Comments")) Then
                FOXComment = ""
            Else
                FOXComment = reader.Item("Comments")
            End If
            If IsDBNull(reader.Item("RawMaterialWeight")) Then
                RawMaterialWeight = 0
            Else
                RawMaterialWeight = reader.Item("RawMaterialWeight")
            End If
            If IsDBNull(reader.Item("ScrapWeight")) Then
                ScrapWeight = 0
            Else
                ScrapWeight = reader.Item("ScrapWeight")
            End If
            If IsDBNull(reader.Item("FinishedWeight")) Then
                FinishWeight = 0
            Else
                FinishWeight = reader.Item("FinishedWeight")
            End If
        Else
            AlternateSteel = ""
            FOXPartNumber = ""
            BlueprintNumber = ""
            BlueprintRevision = ""
            CertificationType = ""
            BoxType = ""
            FOXComment = ""
            RawMaterialWeight = 0
            ScrapWeight = 0
            FinishWeight = 0
        End If
        reader.Close()
        con.Close()

        txtFOXAlternateSteel.Text = AlternateSteel
        cboPartNumber.Text = FOXPartNumber
        txtFOXBlueprintNumber.Text = BlueprintNumber
        txtFOXBPRevision.Text = BlueprintRevision
        txtFOXCertType.Text = CertificationType
        txtFOXBoxType.Text = BoxType
        txtFOXComment.Text = FOXComment
        txtFOXRawMaterialWeight.Text = RawMaterialWeight
        txtFOXScrapWeight.Text = ScrapWeight
        txtFOXFinishedWeight.Text = FinishWeight
    End Sub

    Public Sub LoadPartNumberDetails()
        Dim ItemClass, ShortDescription, LongDescription As String
        Dim PieceWeight, BoxWeight, PalletWeight, BoxCount, PalletCount, PalletPieces, NominalDiameter, NominalLength As Double
   
        'Get Item Data for the specific Part Number
        Dim GetPartDataString As String = "SELECT * FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetPartDataCommand As New SqlCommand(GetPartDataString, con)
        GetPartDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetPartDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPartDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ItemClass")) Then
                ItemClass = ""
            Else
                ItemClass = reader.Item("ItemClass")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                ShortDescription = ""
            Else
                ShortDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("LongDescription")) Then
                LongDescription = ""
            Else
                LongDescription = reader.Item("LongDescription")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                PieceWeight = 0
            Else
                PieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                BoxWeight = 0
            Else
                BoxWeight = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("PalletWeight")) Then
                PalletWeight = 0
            Else
                PalletWeight = reader.Item("PalletWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                BoxCount = 0
            Else
                BoxCount = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                PalletCount = 0
            Else
                PalletCount = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("PalletPieces")) Then
                PalletPieces = 0
            Else
                PalletPieces = reader.Item("PalletPieces")
            End If
            If IsDBNull(reader.Item("NominalDiameter")) Then
                NominalDiameter = 0
            Else
                NominalDiameter = reader.Item("NominalDiameter")
            End If
            If IsDBNull(reader.Item("NominalLength")) Then
                NominalLength = 0
            Else
                NominalLength = reader.Item("NominalLength")
            End If
        Else
            ItemClass = ""
            ShortDescription = ""
            LongDescription = ""
            PieceWeight = 0
            BoxWeight = 0
            PalletWeight = 0
            BoxCount = 0
            PalletCount = 0
            PalletPieces = 0
            NominalDiameter = 0
            NominalLength = 0
        End If
        reader.Close()
        con.Close()

        txtPartShortDescription.Text = ShortDescription
        txtPartLongDescription.Text = LongDescription
        txtItemClass.Text = ItemClass
        txtPieceWeight.Text = PieceWeight
        txtBoxWeight.Text = BoxWeight
        txtPalletWeight.Text = PalletWeight
        txtBoxCount.Text = BoxCount
        txtPalletBoxes.Text = PalletCount
        txtPalletPieces.Text = PalletPieces
        txtNominalDiameter.Text = NominalDiameter
        txtNominalLength.Text = NominalLength
    End Sub

    Public Sub LoadLotNumberDetails()
        Dim FOXNumber, HeatNumberID As Integer
        Dim PartNumber, RMID, HeatNumber As String

        'Get Item Data for the specific Part Number
        Dim GetLotDataString As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber AND DivisionID = @DivisionID"
        Dim GetLotDataCommand As New SqlCommand(GetLotDataString, con)
        GetLotDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        GetLotDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetLotDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = ""
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                FOXNumber = 0
            Else
                FOXNumber = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("RMID")) Then
                RMID = ""
            Else
                RMID = reader.Item("RMID")
            End If
            If IsDBNull(reader.Item("HeatNumberID")) Then
                HeatNumberID = 0
            Else
                HeatNumberID = reader.Item("HeatNumberID")
            End If
        Else
            HeatNumber = ""
            PartNumber = ""
            RMID = ""
            FOXNumber = 0
            HeatNumberID = 0
        End If
        reader.Close()
        con.Close()

        cboFOXNumber.Text = FOXNumber
        cboRMID.Text = RMID
        cboPartNumber.Text = PartNumber
        cboHeatNumber.Text = HeatNumber

        FormHeatFileRecord = HeatNumberID

        'Get data to auto-check the correct heat file number in the list box
        Dim CheckHeatFileString As String = ""
        Dim strHeatFileNumber As String = CStr(FormHeatFileRecord)
        Dim Counter As Integer = 0
        Dim CountItems As Integer = 0
        CountItems = clbHeatFileRecords.Items.Count

        Dim CheckSteelCarbon, CheckSteekSize As String
        CheckSteelCarbon = txtSteelCarbonFromRMID.Text
        CheckSteekSize = txtSteelSizeFromRMID.Text

        CheckHeatFileString = CheckSteelCarbon + " / " + CheckSteekSize + " -  (Heat File # - /*" + strHeatFileNumber + "*\)"

        For i As Integer = 0 To (CountItems - 1)
            If clbHeatFileRecords.Items(Counter).ToString = CheckHeatFileString Then
                clbHeatFileRecords.SetItemChecked(Counter, True)
                LoadHeatFileRecordsByHeatNumber()
            End If

            Counter = Counter + 1
        Next
    End Sub

    Public Sub ClearAllFields()
        cboFOXNumber.Refresh()
        cboHeatNumber.Refresh()
        cboPartNumber.Refresh()
        cboLotNumber.Refresh()
        cboRMID.Refresh()

        cboFOXNumber.SelectedIndex = -1
        cboHeatNumber.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        cboRMID.SelectedIndex = -1

        txtBoxCount.Clear()
        txtBoxWeight.Clear()
        txtFOXAlterativeCarbon.Clear()
        txtFOXAlternateSteel.Clear()
        txtFOXAlternativeSteelSize.Clear()
        txtFOXBlueprintNumber.Clear()
        txtFOXBoxType.Clear()
        txtFOXBPRevision.Clear()
        txtFOXCertType.Clear()
        txtFOXComment.Clear()
        txtFOXFinishedWeight.Clear()
        txtFOXRawMaterialWeight.Clear()
        txtFOXScrapWeight.Clear()
        txtItemClass.Clear()
        txtNewLotNumber.Clear()
        txtNominalDiameter.Clear()
        txtNominalLength.Clear()
        txtPalletBoxes.Clear()
        txtPalletPieces.Clear()
        txtPalletWeight.Clear()
        txtPartLongDescription.Clear()
        txtPartShortDescription.Clear()
        txtPartNumber.Clear()
        txtPieceWeight.Clear()
        txtSteelCarbonFromHeat.Clear()
        txtSteelCarbonFromRMID.Clear()
        txtSteelDescription.Clear()
        txtSteelVendor.Clear()
        txtSteelDateReceived.Clear()
        txtSteelPONumber.Clear()
        txtSteelSizeFromHeat.Clear()
        txtSteelSizeFromRMID.Clear()
        txtSteelVendor.Clear()
        FormHeatFileRecord = 0

        clbHeatFileRecords.Items.Clear()

        cboFOXNumber.Focus()
    End Sub

    Public Sub LoadPartNumberFromFOX()
        'Get Part Number FRom FOX
        Dim FoxPartNumber As String = ""

        Dim FoxPartNumberStatement As String = "SELECT PartNumber FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
        Dim FoxPartNumberCommand As New SqlCommand(FoxPartNumberStatement, con)
        FoxPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        FoxPartNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            FoxPartNumber = CStr(FoxPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            FoxPartNumber = ""
        End Try
        con.Close()

        cboPartNumber.Text = FoxPartNumber
    End Sub

    Public Sub LoadRMIDFromFOX()
        'Get Part Number FRom FOX
        Dim FoxRMID As String = ""

        Dim FoxRMIDStatement As String = "SELECT RMID FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
        Dim FoxRMIDCommand As New SqlCommand(FoxRMIDStatement, con)
        FoxRMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        FoxRMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            FoxRMID = CStr(FoxRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            FoxRMID = ""
        End Try
        con.Close()

        cboRMID.Text = FoxRMID
    End Sub

    Public Sub LoadAlternateSteel()
        'Get Part Number FRom FOX
        Dim AlternateSteelSize, AlternateSteelCarbon As String

        Dim AlternateSteelCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = @DivisionID"
        Dim AlternateSteelCarbonCommand As New SqlCommand(AlternateSteelCarbonStatement, con)
        AlternateSteelCarbonCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        AlternateSteelCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtFOXAlternateSteel.Text

        Dim AlternateSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = @DivisionID"
        Dim AlternateSteelSizeCommand As New SqlCommand(AlternateSteelSizeStatement, con)
        AlternateSteelSizeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        AlternateSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtFOXAlternateSteel.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AlternateSteelCarbon = CStr(AlternateSteelCarbonCommand.ExecuteScalar)
        Catch ex As Exception
            AlternateSteelCarbon = ""
        End Try
        Try
            AlternateSteelSize = CStr(AlternateSteelSizeCommand.ExecuteScalar)
        Catch ex As Exception
            AlternateSteelSize = ""
        End Try
        con.Close()

        txtFOXAlternativeSteelSize.Text = AlternateSteelSize
        txtFOXAlterativeCarbon.Text = AlternateSteelCarbon
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

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadFOXNumber()
        LoadRMID()
        LoadPartNumber()
        LoadHeatNumber()
        LoadLotNumber()
        ClearAllFields()
    End Sub

    Private Sub cboFOXNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOXNumber.SelectedIndexChanged
        If cboFOXNumber.Text <> "" Then
            LoadPartNumberFromFOX()
            LoadRMIDFromFOX()
            LoadFOXDetails()
        Else
            'Skip - do not load
        End If
    End Sub

    Private Sub cboRMID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRMID.SelectedIndexChanged
        If cboRMID.Text = "" Then
            'Skip - do nothing
            txtSteelCarbonFromRMID.Clear()
            txtSteelSizeFromRMID.Clear()
            txtSteelDescription.Clear()
        Else
            LoadSteelDetails()
        End If
    End Sub

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        If cboLotNumber.Text = "" Then
            'Skip - do nothing
        Else
            LoadLotNumberDetails()
        End If
    End Sub

    Private Sub cboHeatNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.SelectedIndexChanged
        If cboHeatNumber.Text = "" Then
            'Skip - do nothing
            clbHeatFileRecords.Items.Clear()
        Else
            LoadHeatFileRecords()
        End If
    End Sub

    Private Sub txtFOXAlternateSteel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFOXAlternateSteel.TextChanged
        'Load Carbon and Steel Size for Alternate Steel
        If txtFOXAlternateSteel.Text = "" Then
            txtFOXAlternativeSteelSize.Clear()
            txtFOXAlterativeCarbon.Clear()
        Else
            LoadAlternateSteel()
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If cboPartNumber.Text = "" Then
            txtPartShortDescription.Clear()
            txtPartLongDescription.Clear()
            txtItemClass.Clear()
            txtPieceWeight.Clear()
            txtBoxWeight.Clear()
            txtPalletWeight.Clear()
            txtBoxCount.Clear()
            txtPalletBoxes.Clear()
            txtPalletPieces.Clear()
            txtNominalDiameter.Clear()
            txtNominalLength.Clear()
        Else
            LoadPartNumberDetails()
            txtPartNumber.Text = cboPartNumber.Text
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearAllFields()
    End Sub

    Private Sub cmdCreateLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateLotNumber.Click
        'Check to make sure lot number does not already exist
        If txtNewLotNumber.Text = "" Then
            MsgBox("You must create a valid lot number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If txtNewLotNumber.TextLength < 9 Then
            MsgBox("A lot number must be at least 9 characters.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim ValidateLotNumber As Integer = 0

        Dim ValidateLotNumberStatement As String = "SELECT COUNT(LotNumber) FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim ValidateLotNumberCommand As New SqlCommand(ValidateLotNumberStatement, con)
        ValidateLotNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtNewLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ValidateLotNumber = CInt(ValidateLotNumberCommand.ExecuteScalar)
        Catch ex As Exception
            ValidateLotNumber = 0
        End Try
        con.Close()

        If ValidateLotNumber = 0 Then
            'Proceed - Lot Number does not exist
        Else
            MsgBox("This Lot Number already exists.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************
        'Validate steel - FOX Steel matches the Heat Number Steel
        Dim RawSteelCarbon As String = txtSteelCarbonFromRMID.Text
        Dim RawSteelSize As String = txtSteelSizeFromRMID.Text
        Dim HeatSteelCarbon As String = txtSteelCarbonFromHeat.Text
        Dim HeatSteelSize As String = txtSteelSizeFromHeat.Text

        If RawSteelCarbon = HeatSteelCarbon And RawSteelSize = HeatSteelSize Then
            'Continue - steel matches
        Else
            MsgBox("Carbon/Alloy, Steel Size must match Raw Materials Table.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************
        'Check critical fields
        If cboPartNumber.Text = "" Then
            MsgBox("You must select a part number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboRMID.Text = "" Then
            MsgBox("You must select a raw material.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboHeatNumber.Text = "" Then
            MsgBox("You must select a heat number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboFOXNumber.Text = "" Then
            MsgBox("You must select a FOX number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************
        'Load missing misc. data
        Dim FluxloadNumber As String = ""
        Dim HeadMarking As String = ""
        Dim MaterialOrigin As String = ""

        Dim GetFluxLoadNumberStatement As String = "SELECT FluxLoadNumber FROM FOXTable WHERE FOXNumber = @FOXNumber"
        Dim GetFluxLoadNumberCommand As New SqlCommand(GetFluxLoadNumberStatement, con)
        GetFluxLoadNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

        Dim GetHeadMarkingStatement As String = "SELECT HeadMarking FROM FOXTable WHERE FOXNumber = @FOXNumber"
        Dim GetHeadMarkingCommand As New SqlCommand(GetHeadMarkingStatement, con)
        GetHeadMarkingCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

        Dim GetMaterialOriginStatement As String = "SELECT MaterialOrigin FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber"
        Dim GetMaterialOriginCommand As New SqlCommand(GetMaterialOriginStatement, con)
        GetMaterialOriginCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = FormHeatFileRecord

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            FluxloadNumber = CStr(GetFluxLoadNumberCommand.ExecuteScalar)
        Catch ex As Exception
            FluxloadNumber = ""
        End Try
        Try
            HeadMarking = CStr(GetHeadMarkingCommand.ExecuteScalar)
        Catch ex As Exception
            HeadMarking = ""
        End Try
        Try
            MaterialOrigin = CStr(GetMaterialOriginCommand.ExecuteScalar)
        Catch ex As Exception
            MaterialOrigin = ""
        End Try
        con.Close()
        '********************************************************************************
        'Insert Lot Number Data into table 
        Try
            cmd = New SqlCommand("Insert Into LotNumber(LotNumber, HeatNumber, PartNumber, FOXNumber, CreationDate, RMID, HeatNumberID, SteelVendorID, SteelPONumber, DateReceived, SteelType, SteelSize, SteelDescription, RawMaterialWeight, ScrapWeight, FinishedWeight, BlueprintNumber, AnnealedHeatNumber, FluxLoadNumber, CertificationType, ShortDescription, LongDescription, PieceWeight, BoxWeight, PalletWeight, BoxCount, PalletCount, PalletPieces, BoxType, HeadMarking, NominalDiameter, NominalLength, DivisionID, ItemClass, Status, UserID, Comment, BlueprintRevision, MaterialOrigin, QCInspected, QCInspector, QCInspectorPC, QCInspectedDateTime)Values(@LotNumber, @HeatNumber, @PartNumber, @FOXNumber, @CreationDate, @RMID, @HeatNumberID, @SteelVendorID, @SteelPONumber, @DateReceived, @SteelType, @SteelSize, @SteelDescription, @RawMaterialWeight, @ScrapWeight, @FinishedWeight, @BlueprintNumber, @AnnealedHeatNumber, @FluxLoadNumber, @CertificationType, @ShortDescription, @LongDescription, @PieceWeight, @BoxWeight, @PalletWeight, @BoxCount, @PalletCount, @PalletPieces, @BoxType, @HeadMarking, @NominalDiameter, @NominalLength, @DivisionID, @ItemClass, @Status, @UserID, @Comment, @BlueprintRevision, @MaterialOrigin, @QCInspected, @QCInspector, @QCInspectorPC, @QCInspectedDateTime)", con)

            With cmd.Parameters
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtNewLotNumber.Text
                .Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                .Add("@RMID", SqlDbType.VarChar).Value = cboRMID.Text
                .Add("@HeatNumberID", SqlDbType.VarChar).Value = FormHeatFileRecord
                .Add("@SteelVendorID", SqlDbType.VarChar).Value = txtSteelVendor.Text
                .Add("@SteelPONumber", SqlDbType.VarChar).Value = txtSteelPONumber.Text
                .Add("@DateReceived", SqlDbType.VarChar).Value = txtSteelDateReceived.Text
                .Add("@SteelType", SqlDbType.VarChar).Value = txtSteelCarbonFromRMID.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeFromRMID.Text
                .Add("@SteelDescription", SqlDbType.VarChar).Value = txtSteelDescription.Text
                .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = Val(txtFOXRawMaterialWeight.Text)
                .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtFOXScrapWeight.Text)
                .Add("@FinishedWeight", SqlDbType.VarChar).Value = Val(txtFOXFinishedWeight.Text)
                .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtFOXBlueprintNumber.Text
                .Add("@AnnealedHeatNumber", SqlDbType.VarChar).Value = ""
                .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = FluxLoadNumber
                .Add("@CertificationType", SqlDbType.VarChar).Value = txtFOXCertType.Text
                .Add("@ShortDescription", SqlDbType.VarChar).Value = txtPartShortDescription.Text
                .Add("@LongDescription", SqlDbType.VarChar).Value = txtPartLongDescription.Text
                .Add("@PieceWeight", SqlDbType.VarChar).Value = Val(txtPieceWeight.Text)
                .Add("@BoxWeight", SqlDbType.VarChar).Value = Val(txtBoxWeight.Text)
                .Add("@PalletWeight", SqlDbType.VarChar).Value = Val(txtPalletWeight.Text)
                .Add("@BoxCount", SqlDbType.VarChar).Value = Val(txtBoxCount.Text)
                .Add("@PalletCount", SqlDbType.VarChar).Value = Val(txtPalletBoxes.Text)
                .Add("@PalletPieces", SqlDbType.VarChar).Value = Val(txtPalletPieces.Text)
                .Add("@BoxType", SqlDbType.VarChar).Value = txtFOXBoxType.Text
                .Add("@HeadMarking", SqlDbType.VarChar).Value = HeadMarking
                .Add("@NominalDiameter", SqlDbType.VarChar).Value = Val(txtNominalDiameter.Text)
                .Add("@NominalLength", SqlDbType.VarChar).Value = Val(txtNominalLength.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ItemClass", SqlDbType.VarChar).Value = txtItemClass.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@Comment", SqlDbType.VarChar).Value = txtFOXComment.Text
                .Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtFOXBPRevision.Text
                .Add("@MaterialOrigin", SqlDbType.VarChar).Value = MaterialOrigin
                .Add("@QCInspected", SqlDbType.VarChar).Value = ""
                .Add("@QCInspector", SqlDbType.VarChar).Value = ""
                .Add("@QCInspectorPC", SqlDbType.VarChar).Value = My.Computer.Name.ToString
                .Add("@QCInspectedDateTime", SqlDbType.VarChar).Value = Now()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempLotNumber As String = ""
            TempLotNumber = txtNewLotNumber.Text

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Create Manual Lot # - Insert Into Lot Number"
            ErrorReferenceNumber = "Lot # " + TempLotNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '********************************************************************************
        'Msgbox - do not clear to give the opportunity to print tub tag
        MsgBox("Lot Numnber has been created - you may print a tub tag.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdTubTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTubTag.Click
        If txtNewLotNumber.Text <> "" Then
            Dim newViewTubPage As New ViewTubPage(cboFOXNumber.Text, txtNewLotNumber.Text, True)
            newViewTubPage.ShowDialog()
        End If
    End Sub
End Class