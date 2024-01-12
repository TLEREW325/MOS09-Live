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
Public Class LotNumberCreateSpecial
    Inherits System.Windows.Forms.Form

    'Variables to calculate MTD and YTD Sales
    Dim YearDate, MonthDate, BeginDate, EndDate As Date
    Dim YearOfYear, MonthOfYear, Year As Integer
    Dim strMonthOfYear, strYear As String

    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    'Variables for specific Lot Number
    Dim HeatNumber, PartNumber, RMID, SteelVendorID, SteelPONumber, DateReceived, SteelCarbon, SteelSize, SteelDescription, BlueprintNumber, AnnealedHeatNumber, FluxLoadNumber, CertificationType, ShortDescription, LongDescription, BoxType, HeadMarking, ItemClass, Status, UsedID, Comment, BlueprintRevision, MaterialOrigin, QCInspected, QCInspector As String
    Dim FOXNumber, HeatNumberID, BoxCount, PalletCount, PalletPieces As Integer
    Dim NominalDiameter, NominalLength, PieceWeight, BoxWeight, PalletWeight, RawMaterialWeight, ScrapWeight, FinishedWeight As Double


    Private Sub LotNumberCreateSpecial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()





    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE DivisionID = @DivisionID ORDER BY LotNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "LotNumber")
        cboLotNumber.DataSource = ds1.Tables("LotNumber")
        con.Close()
        cboLotNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadDataFields()
        'Extract data from source table
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
            If IsDBNull(reader.Item("SteelVendorID")) Then
                SteelVendorID = ""
            Else
                SteelVendorID = reader.Item("SteelVendorID")
            End If
            If IsDBNull(reader.Item("SteelPONumber")) Then
                SteelPONumber = ""
            Else
                SteelPONumber = reader.Item("SteelPONumber")
            End If
            If IsDBNull(reader.Item("DateReceived")) Then
                DateReceived = ""
            Else
                DateReceived = reader.Item("DateReceived")
            End If
            If IsDBNull(reader.Item("SteelType")) Then
                SteelCarbon = ""
            Else
                SteelCarbon = reader.Item("SteelType")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("SteelDescription")) Then
                SteelDescription = ""
            Else
                SteelDescription = reader.Item("SteelDescription")
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
                FinishedWeight = 0
            Else
                FinishedWeight = reader.Item("FinishedWeight")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                BlueprintNumber = ""
            Else
                BlueprintNumber = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("AnnealedHeatNumber")) Then
                AnnealedHeatNumber = ""
            Else
                AnnealedHeatNumber = reader.Item("AnnealedHeatNumber")
            End If
            If IsDBNull(reader.Item("FluxLoadNumber")) Then
                FluxLoadNumber = ""
            Else
                FluxLoadNumber = reader.Item("FluxLoadNumber")
            End If
            If IsDBNull(reader.Item("CertificationType")) Then
                CertificationType = ""
            Else
                CertificationType = reader.Item("CertificationType")
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
            If IsDBNull(reader.Item("BoxType")) Then
                BoxType = ""
            Else
                BoxType = reader.Item("BoxType")
            End If
            If IsDBNull(reader.Item("HeadMarking")) Then
                HeadMarking = ""
            Else
                HeadMarking = reader.Item("HeadMarking")
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
            If IsDBNull(reader.Item("ItemClass")) Then
                ItemClass = ""
            Else
                ItemClass = reader.Item("ItemClass")
            End If
            If IsDBNull(reader.Item("Status")) Then
                Status = "OPEN"
            Else
                Status = reader.Item("Status")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = ""
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("BlueprintRevision")) Then
                BlueprintRevision = ""
            Else
                BlueprintRevision = reader.Item("BlueprintRevision")
            End If
            If IsDBNull(reader.Item("MaterialOrigin")) Then
                MaterialOrigin = ""
            Else
                MaterialOrigin = reader.Item("MaterialOrigin")
            End If
            If IsDBNull(reader.Item("QCInspected")) Then
                QCInspected = ""
            Else
                QCInspected = reader.Item("QCInspected")
            End If
            If IsDBNull(reader.Item("QCInspector")) Then
                QCInspector = ""
            Else
                QCInspector = reader.Item("QCInspector")
            End If
        Else
            HeatNumber = ""
            PartNumber = ""
            FOXNumber = 0
            RMID = ""
            HeatNumberID = 0
            SteelVendorID = ""
            SteelPONumber = ""
            DateReceived = ""
            SteelCarbon = ""
            SteelSize = ""
            SteelDescription = ""
            RawMaterialWeight = 0
            ScrapWeight = 0
            FinishedWeight = 0
            BlueprintNumber = ""
            AnnealedHeatNumber = ""
            FluxLoadNumber = ""
            CertificationType = ""
            ShortDescription = ""
            LongDescription = ""
            PieceWeight = 0
            BoxWeight = 0
            PalletWeight = 0
            PalletCount = 0
            PalletPieces = 0
            BoxType = ""
            HeadMarking = ""
            NominalDiameter = 0
            NominalLength = 0
            ItemClass = ""
            Status = "OPEN"
            Comment = ""
            BlueprintRevision = ""
            MaterialOrigin = ""
            QCInspected = ""
            QCInspector = ""
        End If
        reader.Close()
        con.Close()

        txtFOXNumber.Text = FOXNumber
        txtHeatNumber.Text = HeatNumber
        txtPartNumber.Text = PartNumber
        txtSteelCarbon.Text = SteelCarbon
        txtSteelSize.Text = SteelSize
        txtSteelVendor.Text = SteelVendorID
        txtShortDescription.Text = ShortDescription
        txtLotComment.Text = Comment
    End Sub

    Public Sub ClearFields()
        cboLotNumber.SelectedIndex = -1
        txtFOXNumber.Clear()
        txtHeatNumber.Clear()
        txtLotComment.Clear()
        txtLotSuffix.Clear()
        txtPartNumber.Clear()
        txtShortDescription.Clear()
        txtSteelCarbon.Clear()
        txtSteelSize.Clear()
        txtSteelVendor.Clear()

        cboLotNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        HeatNumber = ""
        PartNumber = ""
        FOXNumber = 0
        RMID = ""
        HeatNumberID = 0
        SteelVendorID = ""
        SteelPONumber = ""
        DateReceived = ""
        SteelCarbon = ""
        SteelSize = ""
        SteelDescription = ""
        RawMaterialWeight = 0
        ScrapWeight = 0
        FinishedWeight = 0
        BlueprintNumber = ""
        AnnealedHeatNumber = ""
        FluxLoadNumber = ""
        CertificationType = ""
        ShortDescription = ""
        LongDescription = ""
        PieceWeight = 0
        BoxWeight = 0
        PalletWeight = 0
        PalletCount = 0
        PalletPieces = 0
        BoxType = ""
        HeadMarking = ""
        NominalDiameter = 0
        NominalLength = 0
        ItemClass = ""
        Status = "OPEN"
        Comment = ""
        BlueprintRevision = ""
        MaterialOrigin = ""
        QCInspected = ""
        QCInspector = ""
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

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdCreateNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateNew.Click
        'Check blank fields
        If cboLotNumber.Text = "" Or txtLotComment.Text = "" Then
            MsgBox("You must select a valid Lot # and Lot # Suffix to continue.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************************************************************
        'Validate that main lot elements are loaded as variables
        If HeatNumber = "" Then
            MsgBox("No valid heat # loaded.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If FOXNumber = 0 Then
            MsgBox("No valid FOX # loaded.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If PartNumber = "" Then
            MsgBox("No valid part # loaded.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If RMID = "" Then
            MsgBox("No valid raw material loaded.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************************************************************
        'Check if Lot # is valid
        Dim CountLotNumber As Integer = 0

        Dim CountLotNumberString As String = "SELECT COUNT(LotNumber) FROM LotNumber WHERE LotNumber = @LotNumber AND DivisionID = @DivisionID"
        Dim CountLotNumberCommand As New SqlCommand(CountLotNumberString, con)
        CountLotNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        CountLotNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountLotNumber = CInt(CountLotNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CountLotNumber = 0
        End Try
        con.Close()

        If CountLotNumber = 0 Then
            MsgBox("Lot Number does not exist. Select a valid Lot #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************************************************************
        'Create and validate new lot number
        Dim NewLotNumber As String = ""
        Dim LotNumberPrefix, LotNumberSuffix As String

        LotNumberPrefix = cboLotNumber.Text
        LotNumberSuffix = txtLotSuffix.Text

        NewLotNumber = LotNumberPrefix + LotNumberSuffix

        Dim CountNewLotNumber As Integer = 0

        Dim CountNewLotNumberString As String = "SELECT COUNT(LotNumber) FROM LotNumber WHERE LotNumber = @LotNumber AND DivisionID = @DivisionID"
        Dim CountNewLotNumberCommand As New SqlCommand(CountNewLotNumberString, con)
        CountNewLotNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = NewLotNumber
        CountNewLotNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountNewLotNumber = CInt(CountNewLotNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CountNewLotNumber = 0
        End Try
        con.Close()

        If CountNewLotNumber = 1 Then
            MsgBox("Lot Number already exists. Change the extension.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************************************************************
        'Insert Lot Number Data into table 
        Try
            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("Insert Into LotNumber(LotNumber, HeatNumber, PartNumber, FOXNumber, CreationDate, RMID, HeatNumberID, SteelVendorID, SteelPONumber, DateReceived, SteelType, SteelSize, SteelDescription, RawMaterialWeight, ScrapWeight, FinishedWeight, BlueprintNumber, AnnealedHeatNumber, FluxLoadNumber, CertificationType, ShortDescription, LongDescription, PieceWeight, BoxWeight, PalletWeight, BoxCount, PalletCount, PalletPieces, BoxType, HeadMarking, NominalDiameter, NominalLength, DivisionID, ItemClass, Status, UserID, Comment, BlueprintRevision, MaterialOrigin, QCInspected, QCInspector, QCInspectorPC, QCInspectedDateTime)Values(@LotNumber, @HeatNumber, @PartNumber, @FOXNumber, @CreationDate, @RMID, @HeatNumberID, @SteelVendorID, @SteelPONumber, @DateReceived, @SteelType, @SteelSize, @SteelDescription, @RawMaterialWeight, @ScrapWeight, @FinishedWeight, @BlueprintNumber, @AnnealedHeatNumber, @FluxLoadNumber, @CertificationType, @ShortDescription, @LongDescription, @PieceWeight, @BoxWeight, @PalletWeight, @BoxCount, @PalletCount, @PalletPieces, @BoxType, @HeadMarking, @NominalDiameter, @NominalLength, @DivisionID, @ItemClass, @Status, @UserID, @Comment, @BlueprintRevision, @MaterialOrigin, @QCInspected, @QCInspector, @QCInspectorPC, @QCInspectedDateTime)", con)

            With cmd.Parameters
                .Add("@LotNumber", SqlDbType.VarChar).Value = NewLotNumber
                .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                .Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
                .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                .Add("@RMID", SqlDbType.VarChar).Value = RMID
                .Add("@HeatNumberID", SqlDbType.VarChar).Value = HeatNumberID
                .Add("@SteelVendorID", SqlDbType.VarChar).Value = SteelVendorID
                .Add("@SteelPONumber", SqlDbType.VarChar).Value = SteelPONumber
                .Add("@DateReceived", SqlDbType.VarChar).Value = DateReceived
                .Add("@SteelType", SqlDbType.VarChar).Value = SteelCarbon
                .Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize
                .Add("@SteelDescription", SqlDbType.VarChar).Value = SteelDescription
                .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = RawMaterialWeight
                .Add("@ScrapWeight", SqlDbType.VarChar).Value = ScrapWeight
                .Add("@FinishedWeight", SqlDbType.VarChar).Value = FinishedWeight
                .Add("@BlueprintNumber", SqlDbType.VarChar).Value = BlueprintNumber
                .Add("@AnnealedHeatNumber", SqlDbType.VarChar).Value = AnnealedHeatNumber
                .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = FluxLoadNumber
                .Add("@CertificationType", SqlDbType.VarChar).Value = CertificationType
                .Add("@ShortDescription", SqlDbType.VarChar).Value = ShortDescription
                .Add("@LongDescription", SqlDbType.VarChar).Value = LongDescription
                .Add("@PieceWeight", SqlDbType.VarChar).Value = PieceWeight
                .Add("@BoxWeight", SqlDbType.VarChar).Value = BoxWeight
                .Add("@PalletWeight", SqlDbType.VarChar).Value = PalletWeight
                .Add("@BoxCount", SqlDbType.VarChar).Value = BoxCount
                .Add("@PalletCount", SqlDbType.VarChar).Value = PalletCount
                .Add("@PalletPieces", SqlDbType.VarChar).Value = PalletPieces
                .Add("@BoxType", SqlDbType.VarChar).Value = BoxType
                .Add("@HeadMarking", SqlDbType.VarChar).Value = HeadMarking
                .Add("@NominalDiameter", SqlDbType.VarChar).Value = NominalDiameter
                .Add("@NominalLength", SqlDbType.VarChar).Value = NominalLength
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ItemClass", SqlDbType.VarChar).Value = ItemClass
                .Add("@Status", SqlDbType.VarChar).Value = Status
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@Comment", SqlDbType.VarChar).Value = txtLotComment.Text
                .Add("@BlueprintRevision", SqlDbType.VarChar).Value = BlueprintRevision
                .Add("@MaterialOrigin", SqlDbType.VarChar).Value = MaterialOrigin
                .Add("@QCInspected", SqlDbType.VarChar).Value = QCInspected
                .Add("@QCInspector", SqlDbType.VarChar).Value = QCInspector
                .Add("@QCInspectorPC", SqlDbType.VarChar).Value = ""
                .Add("@QCInspectedDateTime", SqlDbType.VarChar).Value = Now()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log

            MsgBox("", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try
        '*************************************************************************************************************************************
        ClearFields()
        ClearVariables()

        MsgBox("Lot Number has been created.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadLotNumber()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearFields()
    End Sub

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        LoadDataFields()
    End Sub
End Class