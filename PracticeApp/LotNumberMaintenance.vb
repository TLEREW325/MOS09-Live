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
Imports System.ComponentModel
Imports System.Linq
Public Class LotNumberMaintenance
    Inherits System.Windows.Forms.Form

    Dim CountHeatNumber As Integer = 0
    Dim CountHeatFile As Integer = 0
    Dim SteelAlloy, SteelSize, SteelDescription As String
    Dim LotNumberSteelGrade, LotNumberSteelSize, LotNumberSteelRMID As String
    Dim PartComment As String = ""
    Dim GlobalAnnealLotCarbon As String = ""
    Dim GetRMID As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4 As SqlCommand
    Dim myAdapter, myAdapter3, myadapter8 As New SqlDataAdapter
    Dim ds, ds3, ds8 As DataSet

    Dim isloaded As Boolean = False
    Dim needsSaved As Boolean = False

    Dim HeatDT, SteelDT As Data.DataTable

    Dim BoxReference As New Dictionary(Of String, String)

    Dim FOXSchedVerification As LotNumberMaintenanceFOXSchedVerification
    Dim BlueprintJournalForm As BlueprintJournal

    Dim lstChangedFields As New usefulFunctions.ChangedFields()
    Dim RemoveKeyChar As Boolean = False

    Dim OutsideCertUploader As UploadAPIOutsideCertification

    Public Sub New()
        InitializeComponent()

        LoadFOXNumber()
        LoadHeatNumber()
        LoadCertType()
        LoadBoxType()
        LoadBoxReferences()
        LoadLotNumber()
        LoadSteel()
        If con.State = ConnectionState.Open Then con.Close()
        usefulFunctions.LoadSecurity(Me)
        isloaded = True
        OutsideCertUploader = New UploadAPIOutsideCertification(Me, UploadOutsideCertificationToolStripMenuItem, ViewOutsideCertificationToolStripMenuItem, ReUploadOutsideCertificationToolStripMenuItem)
        If String.IsNullOrEmpty(GlobalLotNumber) Then
            cboLotNumber.SelectedIndex = -1
        Else
            cboLotNumber.Text = GlobalLotNumber
        End If

    End Sub

    Public Sub ClearData()
        cboLotNumber.SelectedIndex = -1
        ClearMost()
        cboLotNumber.Focus()
        If gpxUpdateSteel.Enabled Then
            gpxUpdateSteel.Enabled = False
        End If
    End Sub

    Private Sub ClearMost()
        cboCertCode.Refresh()
        cboFOXNumber.Refresh()
        cboHeatNumber.Refresh()
        cboSteelAlloy.Refresh()
        cboSteelSize.Refresh()

        dtpLotNumberDate.Text = Today.Date.ToShortDateString

        txtCertDescription.Refresh()
        txtHeatNumberComment.Refresh()
        txtAnnealedHN.Refresh()
        txtBlueprintNumber.Refresh()
        txtBoxesPerPallet.Refresh()
        txtFinishWeight.Refresh()
        txtFinishWeight.Refresh()
        txtPiecesPerBox.Refresh()
        txtPiecesPerPallet.Refresh()
        txtRawWeight.Refresh()
        txtScrapWeight.Refresh()
        txtSteelCarbon.Refresh()
        txtSteelSize.Refresh()
        txtWeightPerBox.Refresh()
        txtWeightPerPallet.Refresh()
        txtCertDescription.Refresh()
        txtFluxLoadNumber.Refresh()
        txtLongDescription.Refresh()
        txtSteelDescription.Refresh()
        txtPieceWeight.Refresh()
        txtSteelPONumber.Refresh()
        txtHeatSteelType.Refresh()
        txtVendorID.Refresh()
        txtPartNumber.Clear()
        txtHeatSteelSize.Refresh()

        cboHeatNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cboHeatNumber.Text = ""
        End If
        cboFOXNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cboFOXNumber.Text = ""
        End If
        cboFOXNumber.Enabled = True
        cboCertCode.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCertCode.Text) Then
            cboCertCode.Text = ""
        End If
        cboHeatNumberSize.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatNumberSize.Text) Then
            cboHeatNumberSize.Text = ""
        End If
        cboHeatNumberSize.DataSource = Nothing
        cboHeatFileNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatFileNumber.Text) Then
            cboHeatFileNumber.Text = ""
        End If

        cboSteelAlloy.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboSteelAlloy.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelAlloy.Text) Then
            cboSteelAlloy.Text = ""
        End If
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If
        cboBoxType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboBoxType.Text) Then
            cboBoxType.Text = ""
        End If

        txtHeatNumberComment.Clear()
        txtAnnealedHN.Clear()
        txtBlueprintNumber.Clear()
        txtBoxesPerPallet.Clear()
        txtFinishWeight.Clear()
        txtFinishWeight.Clear()
        txtPiecesPerBox.Clear()
        txtPiecesPerPallet.Clear()
        txtRawWeight.Clear()
        txtScrapWeight.Clear()
        txtSteelCarbon.Clear()
        txtSteelSize.Clear()
        txtWeightPerBox.Clear()
        txtWeightPerPallet.Clear()
        txtCertDescription.Clear()
        txtFluxLoadNumber.Clear()
        txtShortDescription.Clear()
        txtLongDescription.Clear()
        txtNominalDiameter.Clear()
        txtNominalLength.Clear()
        txtItemClass.Clear()
        txtSteelDescription.Clear()
        txtPieceWeight.Clear()
        txtCertType.Clear()
        txtDivisionID.Clear()
        txtHeadMarking.Clear()
        txtBlueprintRevision.Clear()
        txtMaterialOrigin.Clear()
        txtLotComment.Clear()
        txtHeatSteelSize.Clear()
        ClearHeatFileData()

        lblPullTestMessage.Hide()
        lblTorqueTest.Hide()
        lblNominalDiameter.BackColor = Color.Transparent
        lblNominalLength.BackColor = Color.Transparent
        lblBlueprintJournalMessage.Hide()
        cmdViewEntries.Hide()
    End Sub

    Public Sub ClearVariables()
        GlobalLotNumber = ""
        LotNumberSteelGrade = ""
        LotNumberSteelSize = ""
        LotNumberSteelRMID = ""
        PartComment = ""
        needsSaved = False
        GetRMID = ""
    End Sub

    Private Sub ClearHeatFileData()
        cboHeatFileNumber.SelectedIndex = -1
        cboHeatFileNumber.DataSource = Nothing
        txtSteelPONumber.Clear()
        txtVendorID.Clear()
        txtHeatSteelType.Clear()
        txtReceiveDate.Clear()
        txtHeatSteelSize.Clear()
    End Sub

    Public Sub LoadAnnealedSteelCarbon()
        Dim AnnealedSteelCarbon As String = ""

        Dim AnnealedSteelCarbonStatement As String = "SELECT AnnealedCarbon FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber"
        Dim AnnealedSteelCarbonCommand As New SqlCommand(AnnealedSteelCarbonStatement, con)
        AnnealedSteelCarbonCommand.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = Val(txtAnnealedHN.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AnnealedSteelCarbon = CStr(AnnealedSteelCarbonCommand.ExecuteScalar)
        Catch ex As Exception
            AnnealedSteelCarbon = ""
        End Try
        con.Close()

        If AnnealedSteelCarbon = "" Then
            'Do Nothing
        Else
            txtHeatSteelType.Text = AnnealedSteelCarbon
        End If
    End Sub

    Private Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboFOXNumber.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
    End Sub

    ''' <summary>
    ''' Loads last 3 years of lot numbers, unless LoadAll is true.
    ''' </summary>
    ''' <param name="LoadAll">Toggles loading all lot numbers</param>
    ''' <remarks></remarks>
    ''' 

    Private Sub LoadLotNumber(Optional ByVal LoadAll As Boolean = False)
        If LoadAll Then
            cmd = New SqlCommand("SELECT LotNumber FROM LotNumber", con)
        Else
            cmd = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE CreationDate > DATEADD(YEAR, -3, CURRENT_TIMESTAMP)", con)
        End If

        ds = New DataSet
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "Lotnumber")
        con.Close()

        cboLotNumber.DisplayMember = "LotNumber"
        cboLotNumber.DataSource = ds.Tables("LotNumber")
        cboLotNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadCertType()
        cmd = New SqlCommand("SELECT CertificationCode FROM CertificationType", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboCertCode.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT HeatFileNumber, HeatNumber, SteelType, SteelSize, VendorID, DateReceived, SteelPONumber, MaterialOrigin, Comments FROM HeatNumberLog WHERE Status = 'CLOSED';", con)
        HeatDT = New Data.DataTable("HeatNumberLog")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(HeatDT)

        cboHeatNumber.DisplayMember = "HeatNumber"
        cboHeatNumber.DataSource = HeatDT.DefaultView.ToTable(True, "HeatNumber")
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadSteel()
        cmd = New SqlCommand("SELECT RMID, Carbon, SteelSize, Description FROM RawMaterialsTable;", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(SteelDT)

        cboSteelAlloy.DisplayMember = "Carbon"
        cboSteelAlloy.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboSteelAlloy.SelectedIndex = -1

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub LoadCertData()
        Dim CertDescription As String = ""
        Dim CertType As String = ""

        Dim CertDescriptionStatement As String = "SELECT Description, CertificationType FROM CertificationType WHERE CertificationCode = @CertificationCode;"
        Dim CertDescriptionCommand As New SqlCommand(CertDescriptionStatement, con)
        CertDescriptionCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = CertDescriptionCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("Description")) Then
                CertDescription = reader.Item("Description")
            End If
            If Not IsDBNull(reader.Item("CertificationType")) Then
                CertType = reader.Item("CertificationType")
            End If
        End If
        reader.Close()
        con.Close()

        txtCertDescription.Text = CertDescription
        txtCertType.Text = CertType
    End Sub

    Private Sub LoadBoxType()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE ItemClass = 'BOXES' AND DivisionID = 'TWD'", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboBoxType.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadBoxReferences()
        cmd = New SqlCommand("SELECT BoxTypeID, ItemID FROM BoxType", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not BoxReference.ContainsKey(reader.Item("BoxTypeID")) Then
                    BoxReference.Add(reader.Item("BoxTypeID"), reader.Item("ItemID"))
                End If
            End While
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub LoadFOXData()
        Dim PartNumber As String = ""
        Dim CertificationType As String = ""
        Dim FOXRMID As String = ""

        Dim GetFoxDataStatement As String = "SELECT * FROM FOXTable WHERE FOXNumber = @FOXNumber AND (FOXTable.DivisionID = 'TWD' OR DivisionID = 'TFP');"
        Dim GetFoxDataCommand As New SqlCommand(GetFoxDataStatement, con)
        GetFoxDataCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetFoxDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                txtBlueprintNumber.Text = ""
            Else
                txtBlueprintNumber.Text = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("RawMaterialWeight")) Then
                txtRawWeight.Text = 0
            Else
                txtRawWeight.Text = reader.Item("RawMaterialWeight")
            End If
            If IsDBNull(reader.Item("ScrapWeight")) Then
                txtScrapWeight.Text = 0
            Else
                txtScrapWeight.Text = reader.Item("ScrapWeight")
            End If
            If IsDBNull(reader.Item("FinishedWeight")) Then
                txtFinishWeight.Text = 0
            Else
                txtFinishWeight.Text = reader.Item("FinishedWeight")
            End If
            If IsDBNull(reader.Item("FluxLoadNumber")) Then
                txtFluxLoadNumber.Text = ""
            Else
                txtFluxLoadNumber.Text = reader.Item("FluxLoadNumber")
            End If
            If IsDBNull(reader.Item("CertificationType")) Then
                CertificationType = "0"
            Else
                CertificationType = reader.Item("CertificationType")
            End If
            If IsDBNull(reader.Item("BoxType")) Then
                cboBoxType.Text = "BOX-NONSTANDARD"
            Else
                cboBoxType.Text = reader.Item("BoxType")
            End If
            If IsDBNull(reader.Item("DivisionID")) Then
                txtDivisionID.Text = "TWD"
            Else
                txtDivisionID.Text = reader.Item("DivisionID")
            End If
            If Not IsDBNull(reader.Item("RMID")) Then
                FOXRMID = reader.Item("RMID")
            End If
            If Not IsDBNull(reader.Item("BlueprintRevision")) Then
                txtBlueprintRevision.Text = reader.Item("BlueprintRevision")
            End If
        Else
            PartNumber = ""
            txtBlueprintNumber.Text = ""
            txtRawWeight.Text = 0
            txtScrapWeight.Text = 0
            txtFinishWeight.Text = 0
            txtFluxLoadNumber.Text = ""
            CertificationType = "0"
            cboBoxType.Text = "BOX-NONSTANDARD"
            txtDivisionID.Text = "TWD"
            txtBlueprintRevision.Text = ""
        End If
        reader.Close()

        ''will change the box type to the new type of box and update the FOX to reflect the new box types
        If BoxReference.ContainsKey(cboBoxType.Text) Then
            cboBoxType.Text = BoxReference(cboBoxType.Text)
            cmd = New SqlCommand("UPDATE FOXTable SET BoxType = @BoxType WHERE FOXNumber = @FOXNumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = cboFOXNumber.Text
            cmd.Parameters.Add("@BoxType", SqlDbType.VarChar).Value = cboBoxType.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        End If
        con.Close()

        'Get Steel Data based on FOX RMID
        Dim GetCarbon, GetSteelSize As String

        Dim GetSteelDataStatement As String = "SELECT Carbon, SteelSize FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim GetSteelDataCommand As New SqlCommand(GetSteelDataStatement, con)
        GetSteelDataCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = FOXRMID

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader1 As SqlDataReader = GetSteelDataCommand.ExecuteReader()
        If reader1.HasRows Then
            reader1.Read()
            If IsDBNull(reader1.Item("Carbon")) Then
                GetCarbon = ""
            Else
                GetCarbon = reader1.Item("Carbon")
            End If
            If IsDBNull(reader1.Item("SteelSize")) Then
                GetSteelSize = ""
            Else
                GetSteelSize = reader1.Item("SteelSize")
            End If
        Else
            GetCarbon = ""
            GetSteelSize = ""
        End If
        reader1.Close()

        txtSteelCarbon.Text = GetCarbon
        txtSteelSize.Text = GetSteelSize
        txtPartNumber.Text = PartNumber
        cboCertCode.Text = CertificationType
    End Sub

    Public Sub LoadPartData()
        Dim pieceWeight, BoxCount, PalletCount As Double

        Dim LongDescriptionStatement As String = "SELECT LongDescription, PieceWeight, BoxCount, PalletCount, ShortDescription, NominalDiameter, NominalLength, ItemClass, Comments FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP');"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LongDescriptionCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LongDescription")) Then
                txtLongDescription.Text = ""
            Else
                txtLongDescription.Text = reader.Item("LongDescription")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                pieceWeight = 0
            Else
                pieceWeight = reader.Item("PieceWeight")
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
            If IsDBNull(reader.Item("ShortDescription")) Then
                txtShortDescription.Text = ""
            Else
                txtShortDescription.Text = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("NominalDiameter")) Then
                txtNominalDiameter.Text = ""
            Else
                txtNominalDiameter.Text = reader.Item("NominalDiameter")
            End If
            If IsDBNull(reader.Item("NominalLength")) Then
                txtNominalLength.Text = ""
            Else
                txtNominalLength.Text = reader.Item("NominalLength")
            End If
            If IsDBNull(reader.Item("ItemClass")) Then
                txtItemClass.Text = ""
            Else
                txtItemClass.Text = getItemClass(reader.Item("ItemClass"))
            End If
            If IsDBNull(reader.Item("Comments")) Then
                PartComment = ""
            Else
                PartComment = reader.Item("Comments")
            End If
        Else
            txtLongDescription.Text = ""
            pieceWeight = 0
            BoxCount = 0
            PalletCount = 0
            txtShortDescription.Text = ""
            txtNominalDiameter.Text = ""
            txtNominalLength.Text = ""
            txtItemClass.Text = ""
        End If
        reader.Close()
        con.Close()

        Dim BoxWeight As Double = BoxCount * pieceWeight
        Dim PalletPieces As Double = BoxCount * PalletCount
        Dim PalletWeight As Double = PalletPieces * pieceWeight

        txtBoxesPerPallet.Text = PalletCount
        txtPiecesPerBox.Text = BoxCount
        txtPiecesPerPallet.Text = PalletPieces
        txtPieceWeight.Text = pieceWeight
        txtWeightPerBox.Text = BoxWeight
        txtWeightPerPallet.Text = PalletWeight

        If txtLotComment.Text = "" Then
            txtLotComment.Text = PartComment
        Else
            txtLotComment.Text = txtLotComment.Text + " -- " + PartComment
        End If
    End Sub

    Private Sub LoadHeatFileNumbers()
        If cboHeatFileNumber.DisplayMember <> "HeatFileNumber" Then cboHeatFileNumber.DisplayMember = "HeatFileNumber"
        Dim rws As Data.DataRow() = HeatDT.Select("HeatNumber = '" + cboHeatNumber.Text + "' AND SteelSize = '" + cboHeatNumberSize.Text + "'", "HeatFileNumber ASC")
        If rws.Length > 0 Then
            cboHeatFileNumber.DataSource = rws.CopyToDataTable()
            cboHeatFileNumber.SelectedIndex = 0
        Else
            cboHeatFileNumber.DataSource = Nothing
            cboHeatFileNumber.Text = ""
        End If
    End Sub

    Private Sub LoadHeatSizeNumbers()
        If cboHeatNumberSize.DisplayMember <> "SteelSize" Then cboHeatNumberSize.DisplayMember = "SteelSize"
        Dim rws As Data.DataTable = HeatDT.Select("HeatNumber = '" + cboHeatNumber.Text + "'", "HeatNumber ASC").CopyToDataTable.DefaultView.ToTable(True, "SteelSize")
        If rws.Rows.Count > 0 Then
            Dim tmp As String = cboHeatNumberSize.Text
            cboHeatNumberSize.DataSource = rws
            If Not String.IsNullOrEmpty(tmp) Then
                cboHeatNumberSize.Text = tmp
                If cboHeatNumberSize.SelectedIndex = -1 Then
                    If rws.Rows.Count = 1 Then
                        cboHeatNumberSize.SelectedIndex = 0
                    Else
                        cboHeatNumberSize.Text = ""
                    End If
                End If
            Else
                cboHeatNumberSize.SelectedIndex = 0
            End If
        Else
            cboHeatNumberSize.DataSource = Nothing
            cboHeatNumberSize.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadHeatNumberData()
        Dim HeatNumberID As Integer = 0
        Dim SteelTypeStatement As String = "SELECT HeatNumberID FROM LotNumber WHERE LotNumber = @LotNumber;"
        Dim SteelTypeCommand As New SqlCommand(SteelTypeStatement, con)
        SteelTypeCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = SteelTypeCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("HeatNumberID")) Then
                HeatNumberID = reader.Item("HeatNumberID")
            End If
        End If
        reader.Close()
        con.Close()
        If HeatNumberID = 0 Then
            cboHeatFileNumber.Text = ""
        Else
            cboHeatFileNumber.Text = HeatNumberID
        End If
    End Sub

    Public Sub ValidateHeatNumber()
        'Check to see if Heat Number and Heat File exists before saving
        Dim CountHeatNumberStatement As String = "SELECT COUNT(HeatNumber) From HeatNumberLog WHERE HeatNumber = @HeatNumber"
        Dim CountHeatNumberCommand As New SqlCommand(CountHeatNumberStatement, con)
        CountHeatNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text

        Dim CountHeatFileStatement As String = "SELECT COUNT(HeatFileNumber) From HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber AND HeatNumber = @HeatNumber"
        Dim CountHeatFileCommand As New SqlCommand(CountHeatFileStatement, con)
        CountHeatFileCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = Val(cboHeatFileNumber.Text)
        CountHeatFileCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountHeatNumber = CInt(CountHeatNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CountHeatNumber = 0
        End Try
        Try
            CountHeatFile = CInt(CountHeatFileCommand.ExecuteScalar)
        Catch ex As Exception
            CountHeatFile = 0
        End Try
        con.Close()
    End Sub

    Public Sub LoadLotNumberData()
        Dim heatNumber As String = ""

        cmd = New SqlCommand("SELECT * FROM LotNumber WHERE LotNumber = @LotNumber;", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        Dim tempDS As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempDS, "LotNumber")
        con.Close()

        ''check to see if the lot number has been locked
        If tempDS.Tables("LotNumber").Rows(0).Item("Status").ToString.Equals("CLOSED") Then
            isloaded = False
            cboHeatNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("HeatNumber").ToString()
            cboCertCode.Text = tempDS.Tables("LotNumber").Rows(0).Item("CertificationType").ToString()
            txtDivisionID.Text = tempDS.Tables("LotNumber").Rows(0).Item("DivisionID").ToString()
            dtpLotNumberDate.Text = tempDS.Tables("LotNumber").Rows(0).Item("CreationDate").ToString()
            cboFOXNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("FOXNumber").ToString()
            txtPartNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("PartNumber").ToString()
            cboHeatFileNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("HeatNumberID").ToString()

            ''Heat Number Log Data
            txtVendorID.Text = tempDS.Tables("LotNumber").Rows(0).Item("SteelVendorID").ToString()
            txtSteelPONumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("SteelPONumber").ToString()
            txtReceiveDate.Text = tempDS.Tables("LotNumber").Rows(0).Item("DateReceived").ToString()
            cboHeatNumberSize.Text = tempDS.Tables("LotNumber").Rows(0).Item("SteelSize").ToString()
            txtHeatSteelType.Text = tempDS.Tables("LotNumber").Rows(0).Item("SteelType").ToString()
            txtMaterialOrigin.Text = tempDS.Tables("LotNumber").Rows(0).Item("MaterialOrigin").ToString()
            txtHeatSteelSize.Text = tempDS.Tables("LotNumber").Rows(0).Item("SteelSize").ToString()

            ''FOX Data
            txtSteelDescription.Text = tempDS.Tables("LotNumber").Rows(0).Item("SteelDescription").ToString()
            txtRawWeight.Text = tempDS.Tables("LotNumber").Rows(0).Item("RawMaterialWeight").ToString()
            txtScrapWeight.Text = tempDS.Tables("LotNumber").Rows(0).Item("ScrapWeight").ToString()
            txtFinishWeight.Text = tempDS.Tables("LotNumber").Rows(0).Item("FinishedWeight").ToString()
            txtBlueprintNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("BlueprintNumber").ToString()
            txtBlueprintRevision.Text = tempDS.Tables("LotNumber").Rows(0).Item("BlueprintRevision").ToString()
            txtAnnealedHN.Text = tempDS.Tables("LotNumber").Rows(0).Item("AnnealedHeatNumber").ToString()
            txtFluxLoadNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("FluxLoadNumber").ToString()
            LoadCarbonSize(tempDS.Tables("LotNumber").Rows(0).Item("RMID").ToString())

            ''Part Data
            txtShortDescription.Text = tempDS.Tables("LotNumber").Rows(0).Item("ShortDescription").ToString()
            txtLongDescription.Text = tempDS.Tables("LotNumber").Rows(0).Item("LongDescription").ToString()
            txtPieceWeight.Text = tempDS.Tables("LotNumber").Rows(0).Item("PieceWeight").ToString()
            txtPiecesPerBox.Text = tempDS.Tables("LotNumber").Rows(0).Item("BoxCount").ToString()
            txtWeightPerBox.Text = tempDS.Tables("LotNumber").Rows(0).Item("BoxWeight").ToString()
            txtBoxesPerPallet.Text = tempDS.Tables("LotNumber").Rows(0).Item("PalletCount").ToString()
            txtPiecesPerPallet.Text = tempDS.Tables("LotNumber").Rows(0).Item("PalletPieces").ToString()
            txtWeightPerPallet.Text = tempDS.Tables("LotNumber").Rows(0).Item("PalletWeight").ToString()
            cboBoxType.Text = tempDS.Tables("LotNumber").Rows(0).Item("BoxType").ToString()
            txtNominalDiameter.Text = tempDS.Tables("LotNumber").Rows(0).Item("NominalDiameter").ToString()
            txtNominalLength.Text = tempDS.Tables("LotNumber").Rows(0).Item("NominalLength").ToString()
            txtItemClass.Text = tempDS.Tables("LotNumber").Rows(0).Item("ItemClass").ToString()
            txtHeadMarking.Text = tempDS.Tables("LotNumber").Rows(0).Item("HeadMarking").ToString()
            txtLotComment.Text = tempDS.Tables("LotNumber").Rows(0).Item("Comment").ToString()
            isloaded = True
        Else
            cboHeatNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("HeatNumber").ToString()
            cboCertCode.Text = tempDS.Tables("LotNumber").Rows(0).Item("CertificationType").ToString()
            txtDivisionID.Text = tempDS.Tables("LotNumber").Rows(0).Item("DivisionID").ToString()
            dtpLotNumberDate.Text = tempDS.Tables("LotNumber").Rows(0).Item("CreationDate").ToString()

            txtPartNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("PartNumber").ToString()
            cboFOXNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("FOXNumber").ToString()
            cboHeatFileNumber.Text = tempDS.Tables("LotNumber").Rows(0).Item("HeatNumberID").ToString()
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("SteelSize").ToString()) Then
                cboHeatNumberSize.Text = tempDS.Tables("LotNumber").Rows(0).Item("SteelSize").ToString()
            Else
                cboHeatNumberSize.Text = ""
            End If
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("HeadMarking")) Then
                txtHeadMarking.Text = tempDS.Tables("LotNumber").Rows(0).Item("HeadMarking").ToString()
            Else
                txtHeadMarking.Text = ""
            End If
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("Comment").ToString()) Then
                txtLotComment.Text = tempDS.Tables("LotNumber").Rows(0).Item("Comment").ToString()
            Else
                txtLotComment.Text = ""
            End If
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("PieceWeight")) Then
                txtPieceWeight.Text = tempDS.Tables("LotNumber").Rows(0).Item("PieceWeight").ToString()
            End If
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("BoxCount")) Then
                txtPiecesPerBox.Text = tempDS.Tables("LotNumber").Rows(0).Item("BoxCount").ToString()
            End If
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("BoxWeight")) Then
                txtWeightPerBox.Text = tempDS.Tables("LotNumber").Rows(0).Item("BoxWeight").ToString()
            End If
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("PalletCount")) Then
                txtBoxesPerPallet.Text = tempDS.Tables("LotNumber").Rows(0).Item("PalletCount").ToString()
            End If
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("PalletPieces")) Then
                txtPiecesPerPallet.Text = tempDS.Tables("LotNumber").Rows(0).Item("PalletPieces").ToString()
            End If
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("PalletWeight")) Then
                txtWeightPerPallet.Text = tempDS.Tables("LotNumber").Rows(0).Item("PalletWeight").ToString()
            End If
            If Not IsDBNull(tempDS.Tables("LotNumber").Rows(0).Item("BoxType")) Then
                cboBoxType.Text = tempDS.Tables("LotNumber").Rows(0).Item("BoxType").ToString()
            End If
        End If

        If txtLotComment.Text = "" Then
            txtLotComment.Text = PartComment
        Else
            txtLotComment.Text = txtLotComment.Text + " -- " + PartComment
        End If
    End Sub

    Private Sub LoadCarbonSize(ByVal RMID As String)
        Dim rws As Data.DataRow() = SteelDT.Select("RMID = '" + RMID + "'", "RMID ASC")
        If rws.Length > 0 Then
            txtSteelCarbon.Text = rws(0).Item("Carbon")
            txtSteelSize.Text = rws(0).Item("SteelSize")
            txtSteelDescription.Text = rws(0).Item("Description")
        Else
            txtSteelCarbon.Text = ""
            txtSteelSize.Text = ""
            txtSteelDescription.Text = ""
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        isloaded = False
        If needsSaved Then
            Dim rslt As System.Windows.Forms.DialogResult = MessageBox.Show("Lot Number has not been saved. Do you wish to save it?", "Save Lot", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If rslt = Windows.Forms.DialogResult.Yes Then
                If canSave() Then
                    UpdateLotNumber()
                    needsSaved = False
                    MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
                End If
            ElseIf rslt = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If

        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveLotNumberToolStripMenuItem.Click
        If canSave() Then
            ''Check to see if the user added a dash behind the lot
            If cboLotNumber.SelectedIndex = -1 AndAlso cboLotNumber.Text.Contains("-") Then
                cmd = New SqlCommand("INSERT INTO LotNumber (LotNumber, HeatNumber, PartNumber, FOXNumber, CreationDate, RMID, HeatNumberID, SteelVendorID, SteelPONumber, DateReceived, SteelType, SteelSize, SteelDescription, RawMaterialWeight, ScrapWeight, FinishedWeight, BlueprintNumber, AnnealedHeatNumber, FluxLoadNumber, CertificationType, ShortDescription, LongDescription, PieceWeight, BoxWeight, PalletWeight, BoxCount, PalletCount, PalletPieces, BoxType, HeadMarking, NominalDiameter, NominalLength, DivisionID, ItemClass, Status, UserID, Comment, BlueprintRevision, MaterialOrigin, QCInspected, QCInspector, QCInspectorPC, QCInspectedDateTime)" _
                                     + " SELECT @NewLotNumber, HeatNumber, PartNumber, FOXNumber, CreationDate, RMID, HeatNumberID, SteelVendorID, SteelPONumber, DateReceived, SteelType, SteelSize, SteelDescription, RawMaterialWeight, ScrapWeight, FinishedWeight, BlueprintNumber, AnnealedHeatNumber, FluxLoadNumber, CertificationType, ShortDescription, LongDescription, PieceWeight, BoxWeight, PalletWeight, BoxCount, PalletCount, PalletPieces, BoxType, HeadMarking, NominalDiameter, NominalLength, DivisionID, ItemClass, 'OPEN', UserID, Comment, BlueprintRevision, MaterialOrigin, QCInspected, QCInspector, QCInspectorPC, QCInspectedDateTime FROM LotNumber WHERE LotNumber = @OldLotNumber;" _
                                + " INSERT INTO TFPLotActivityLog (ActivityDateTime, LotNumber, ChangedField, OriginalValue, NewValue, LoginName)" _
                                + " VALUES (CURRENT_TIMESTAMP, @NewLotNumber, 'CREATED', 'NO', 'YES', @User);" _
                                + " UPDATE LotNumber SET Status = 'CLOSED' WHERE LotNumber = @OldLotNumber;", con)

                cmd.Parameters.Add("@OldLotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text.Substring(0, cboLotNumber.Text.IndexOf("-"))
                cmd.Parameters.Add("@NewLotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                    con.Close()
                    needsSaved = False
                    MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
                    Dim tmp As String = cboLotNumber.Text
                    isloaded = False
                    LoadLotNumber()
                    isloaded = True
                    cboLotNumber.Text = tmp
                Catch ex As System.Exception
                    con.Close()
                    sendErrorToDataBase("LotNumberMaintenance - cmdSave_Click --Error saving Lot Number data.", "Lot #" + cboLotNumber.Text, ex.ToString())
                    MessageBox.Show("There was an error saving Lot Data. Check information and try again", "Unable to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            Else
                Try
                    UpdateLotNumber()
                    needsSaved = False
                    MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
                Catch ex As System.Exception
                    sendErrorToDataBase("LotNumberMaintenance - cmdSave_Click --Error saving Lot Number data.", "Lot #" + cboLotNumber.Text, ex.ToString())
                    MessageBox.Show("There was an error saving Lot Data. Check information and try again", "Unable to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must select a Lot Number", "Select a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 AndAlso Not cboLotNumber.Text.Contains("-") Then
            MessageBox.Show("You must enter a valid Lot Number", "Enter a valid Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 AndAlso cboLotNumber.Text.Contains("-") Then
            cmd = New SqlCommand("SELECT Count(LotNumber) FROM LotNumber WHERE LotNumber = @LotNumber", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text.Substring(0, cboLotNumber.Text.IndexOf("-"))
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                If cmd.ExecuteScalar() = 0 Then
                    con.Close()
                    MessageBox.Show("Unable to locate a valid originating lot.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                con.Close()
            Catch ex As Exception
                con.Close()
                MessageBox.Show("Unable to locate a valid originating lot.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End Try
            If MessageBox.Show("Duplicating a lot will cause the originating lot, " + cboLotNumber.Text.Substring(0, cboLotNumber.Text.IndexOf("-")) + ", to be closed, if it isn't already. Do you wish to continue?", "Close originating lot", MessageBoxButtons.YesNoCancel) <> Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        End If
        If Not checkStatus() Then
            MessageBox.Show("Unable to save changes, the Lot Number has been locked", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            If cboHeatNumber.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Heat Number", "Enter a valid Heat number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboHeatNumber.Focus()
                Return False
            End If
        End If
        If cboHeatFileNumber.Text.Equals("0") Then
            MessageBox.Show("You must select a valid heat file.", "Select a valid heat file", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatFileNumber.Focus()
            Return False
        End If
        If (txtSteelCarbon.Text.EndsWith("A") And Not txtSteelCarbon.Text.Contains("AK")) Or (txtDivisionID.Text.Equals("TFP") And Not txtSteelCarbon.Text.Contains("SS")) Then
            If String.IsNullOrEmpty(txtAnnealedHN.Text) And EmployeeSecurityCode > 1002 Then
                MessageBox.Show("You must enter something in for Annealed Lot.", "Enter an Annealed Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAnnealedHN.Focus()
                Return False
            End If
        ElseIf txtDivisionID.Text.Equals("TFP") And txtSteelCarbon.Text.Contains("SS") Then
            txtAnnealedHN.Text = ""
        End If
        Return True
    End Function

    Private Sub UpdateLotNumber(Optional ByVal status As String = "OPEN")
        LotNumberSteelGrade = txtHeatSteelType.Text
        LotNumberSteelSize = txtHeatSteelSize.Text

        UpdateLog()

        'Write Lot Number data to the database
        cmd = New SqlCommand("UPDATE LotNumber SET HeatNumber = @HeatNumber, HeatNumberID = @HeatNumberID, PartNumber = @PartNumber, FOXNumber = @FOXNumber, CreationDate = @CreationDate, RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @SteelType AND SteelSize = @SteelSize), SteelVendorID = @SteelVendorID, SteelPONumber = @SteelPONumber, DateReceived = @DateReceived, SteelType = @SteelType, SteelSize = @SteelSize, SteelDescription = @SteelDescription, RawMaterialWeight = @RawMaterialWeight, ScrapWeight = @ScrapWeight, FinishedWeight = @FinishedWeight, BlueprintNumber = @BlueprintNumber, AnnealedHeatNumber = @AnnealedHeatNumber, FluxLoadNumber = @FluxLoadNumber, CertificationType = @CertificationType, ShortDescription = @ShortDescription, LongDescription = @LongDescription, PieceWeight = @PieceWeight, BoxWeight = @BoxWeight, PalletWeight = @PalletWeight, BoxCount = @BoxCount, PalletCount = @PalletCount, PalletPieces = @PalletPieces, BoxType = @BoxType, HeadMarking = @HeadMarking, Status = @Status, NominalDiameter = @NominalDiameter, NominalLength = @NominalLength, ItemClass = @ItemClass, Comment = @Comment, BlueprintRevision = @BlueprintRevision, MaterialOrigin = @MaterialOrigin WHERE LotNumber = @LotNumber;", con)
        If status.Equals("CLOSED") Then
            If lblPullTestMessage.Visible Or lblTorqueTest.Visible Then
                cmd.CommandText += " IF EXISTS(SELECT LotNumber FROM PullTestLog WHERE LotNumber = @LotNumber)" _
                + " UPDATE PullTestLog SET HeatNumber = @HeatNumber, NominalDiameter = @NominalDiameter, NominalLength = @NominalLength WHERE LotNumber = @LotNumber" _
                + " ELSE INSERT INTO PullTestLog (EntryDate, HeatNumber, LotNumber, PartNumber, NominalDiameter, NominalLength, ItemClass, TestType) VALUES (@EntryDate, @HeatNumber, @LotNumber, @PartNumber, @NominalDiameter, @NominalLength, @ItemClass, @TestType);"
                cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime2).Value = Now
                If lblPullTestMessage.Visible AndAlso lblTorqueTest.Visible Then
                    cmd.Parameters.Add("@TestType", SqlDbType.VarChar).Value = "PULL AND TORQUE"
                ElseIf lblPullTestMessage.Visible Then
                    cmd.Parameters.Add("@TestType", SqlDbType.VarChar).Value = "PULL"
                Else
                    cmd.Parameters.Add("@TestType", SqlDbType.VarChar).Value = "TORQUE"
                End If
            Else
                cmd.CommandText += " IF EXISTS(SELECT LotNumber FROM PullTestLog WHERE LotNumber = @LotNumber AND PullTestNumber IS NULL AND TorqueTestNumber IS NULL) DELETE PullTestLog WHERE LotNumber = @LotNumber;"
            End If
        Else
            cmd.CommandText += " IF EXISTS(SELECT LotNumber FROM PullTestLog WHERE LotNumber = @LotNumber AND PullTestNumber IS NULL AND TorqueTestNumber IS NULL) DELETE PullTestLog WHERE LotNumber = @LotNumber;"
        End If

        With cmd.Parameters
            .Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
            .Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
            .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
            .Add("@CreationDate", SqlDbType.VarChar).Value = dtpLotNumberDate.Text
            .Add("@HeatNumberID", SqlDbType.VarChar).Value = cboHeatFileNumber.Text
            .Add("@SteelVendorID", SqlDbType.VarChar).Value = txtVendorID.Text
            .Add("@SteelPONumber", SqlDbType.VarChar).Value = txtSteelPONumber.Text
            .Add("@DateReceived", SqlDbType.VarChar).Value = txtReceiveDate.Text
            .Add("@SteelType", SqlDbType.VarChar).Value = LotNumberSteelGrade
            .Add("@SteelSize", SqlDbType.VarChar).Value = LotNumberSteelSize
            .Add("@SteelDescription", SqlDbType.VarChar).Value = txtSteelDescription.Text
            .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = Val(txtRawWeight.Text)
            .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtScrapWeight.Text)
            .Add("@FinishedWeight", SqlDbType.VarChar).Value = Val(txtPieceWeight.Text) * 1000
            .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text
            .Add("@AnnealedHeatNumber", SqlDbType.VarChar).Value = txtAnnealedHN.Text
            .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = txtFluxLoadNumber.Text
            .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
            .Add("@ShortDescription", SqlDbType.VarChar).Value = txtShortDescription.Text
            .Add("@LongDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
            .Add("@PieceWeight", SqlDbType.VarChar).Value = Val(txtPieceWeight.Text)
            .Add("@BoxWeight", SqlDbType.VarChar).Value = Val(txtWeightPerBox.Text)
            .Add("@PalletWeight", SqlDbType.VarChar).Value = Val(txtWeightPerPallet.Text)
            .Add("@BoxCount", SqlDbType.VarChar).Value = Val(txtPiecesPerBox.Text)
            .Add("@PalletCount", SqlDbType.VarChar).Value = Val(txtBoxesPerPallet.Text)
            .Add("@PalletPieces", SqlDbType.VarChar).Value = Val(txtPiecesPerPallet.Text)
            .Add("@BoxType", SqlDbType.VarChar).Value = cboBoxType.Text
            .Add("@HeadMarking", SqlDbType.VarChar).Value = txtHeadMarking.Text
            .Add("@NominalDiameter", SqlDbType.VarChar).Value = txtNominalDiameter.Text
            .Add("@NominalLength", SqlDbType.VarChar).Value = txtNominalLength.Text
            .Add("@ItemClass", SqlDbType.VarChar).Value = txtItemClass.Text
            .Add("@Status", SqlDbType.VarChar).Value = status
            .Add("@Comment", SqlDbType.VarChar).Value = txtLotComment.Text
            .Add("@ActivityDateTime", SqlDbType.DateTime2).Value = Now
            .Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtBlueprintRevision.Text
            .Add("@MaterialOrigin", SqlDbType.VarChar).Value = txtMaterialOrigin.Text
        End With

        If status.Equals("CLOSED") Then '
            cmd.CommandText += " INSERT INTO TFPLotActivityLog (ActivityDateTime, LotNumber, ChangedField, OriginalValue, NewValue, LoginName) VALUES (@ActivityDateTime, @LotNumber, 'LOCKED', 'NO', 'YES', @LoginName);"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        If needsSaved Then
            needsSaved = False
        End If
    End Sub

    Private Function getItemClass(ByVal itmClass As String) As String
        ''checks to see if needs to be changed and will change it to SC
        Select Case itmClass
            Case "TW CA"
                Return itmClass
            Case "TW CH"
                Return itmClass
            Case "TW DB"
                Return itmClass
            Case "TW DS"
                Return "TW SC"
            Case "TW SC"
                Return "TW SC"
            Case "TW PS"
                Return itmClass
            Case "TW SWR"
                Return itmClass
            Case "TW HSR"
                Return itmClass
            Case "TW FER"
                Return itmClass
            Case "Trufit Parts"
                Return itmClass
            Case "TW WELD PROD"
                Return itmClass
            Case "TWE STUD EQUIP COMP"
                Return itmClass
            Case Else
                Return "TW TT"
        End Select
        Return itmClass
    End Function

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click, ClearDataToolStripMenuItem.Click
        If needsSaved Then
            If MessageBox.Show("You are about to lose unsaved Lot Number data, do you wish to continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If
        End If
        isloaded = False
        ClearVariables()
        ClearData()
        checkStatus()
        isloaded = True
        OutsideCertUploader.ChangeLotNumber(cboLotNumber.Text)
    End Sub

    Private Sub cboFOXNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOXNumber.SelectedIndexChanged
        If isloaded Then
            LoadFOXData()
            CheckBPJournal()
        End If
    End Sub

    Private Sub CheckBPJournal()
        If Not String.IsNullOrEmpty(txtBlueprintNumber.Text) Then
            cmd = New SqlCommand("SELECT SUM(EntryCount) FROM (SELECT COUNT(EntryTitle) as EntryCount FROM BlueprintJournal WHERE BlueprintNumber = @BlueprintNumber" _
                                 + " UNION SELECT COUNT(QCTransactionNumber) FROM QCHoldAdjustment WHERE LotNumber in (SELECT LotNumber FROM LotNumber WHERE BlueprintNumber = @BlueprintNumber) OR FOXNumber in (SELECT FOXNumber FROM FOXTable where BlueprintNumber = @BlueprintNumber)) as tmp", con)
            cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar() > 0 Then
                con.Close()
                lblBlueprintJournalMessage.Show()
                cmdViewEntries.Show()
            Else
                con.Close()
                lblBlueprintJournalMessage.Hide()
                cmdViewEntries.Hide()
            End If
        Else
            lblBlueprintJournalMessage.Hide()
            cmdViewEntries.Hide()
        End If
    End Sub

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        If isloaded Then
            LoadLotNumberData()
            checkStatus()
            CheckPullTests()
            CheckBPJournal()
            cboFOXNumber.Enabled = False
            OutsideCertUploader.ChangeLotNumber(cboLotNumber.Text)
        End If
    End Sub

    Private Sub cboHeatNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.SelectedIndexChanged
        If isloaded Then
            ClearHeatFileData()
            LoadHeatSizeNumbers()
            If Not String.IsNullOrEmpty(cboHeatNumberSize.Text) Then
                LoadHeatFileNumbers()
            End If
            CheckPullTests()
        End If
    End Sub

    Private Sub cboCertCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCertCode.SelectedIndexChanged
        If isloaded Then
            LoadCertData()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteLotNumberToolStripMenuItem.Click
        If canDeleteLotNumber() Then
            'Delete Lot Number
            cmd = New SqlCommand("DELETE FROM LotNumber WHERE LotNumber = @LotNumber;" _
                                 + " INSERT INTO TFPLotActivityLog (ActivityDateTime, LotNumber, ChangedField, OriginalValue, NewValue, LoginName) VALUES (@ActivityDateTime, @LotNumber, 'DELETED', 'NO', 'YES', @LoginName);" _
                                 + " DELETE PullTestLog WHERE LotNumber = @LotNumber;", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
            cmd.Parameters.Add("@ActivityDateTime", SqlDbType.DateTime2).Value = Now
            cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            isloaded = False
            ClearData()
            LoadLotNumber()
            isloaded = True
            needsSaved = False
            MsgBox("Lot Number has been deleted.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canDeleteLotNumber() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must select a Lot Number", "Select a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not checkStatus() Then
            MessageBox.Show("Lot Number is locked, unable to delete.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        cmd = New SqlCommand("SELECT COUNT(LotNumber) FROM ShipmentLineLotNumbers WHERE LotNumber = @LotNumber;", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            MessageBox.Show("There are shipments with this Lot Number, unable to delete.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        cmd.CommandText = "SELECT Count(LotNumber) FROM RackingTransactionTable WHERE LotNumber = @LotNumber"
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            MessageBox.Show("There are locations in the racking with this Lot Number, unable to delete.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        con.Close()
        If MessageBox.Show("Do you wish to delete this Lot Number?", "DELETE LOT NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cboLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.TextChanged
        If cboLotNumber.Text.Length > 1 And cboLotNumber.Text.Length < 3 Then
            If Char.ToLower(cboLotNumber.Text.ElementAt(0)) = "s" Then
                cboLotNumber.Text = cboLotNumber.Text.Substring(1, cboLotNumber.Text.Length - 1)
                cboLotNumber.Select(cboLotNumber.Text.Length, 0)
            End If
        End If
    End Sub

    Private Sub cmdPrintTubTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintTubTag.Click
        If canPrintLabel() Then
            Dim bc As New BarcodeLabel()
            ' Prepare TUB TAG
            bc.setupTubTag(cboLotNumber.Text)
            bc.PrintBarcodeLine()
        End If
    End Sub

    Private Function canPrintLabel() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must select a Serial/Lot Number", "Select a Serial number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Serial/Lot Number", "Enter a valid Serial number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cboHeatFileNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatFileNumber.SelectedIndexChanged
        'Get Steel Data based on Heat
        Dim GetCarbon, GetSteelSize, HeatSteelPONumber, HeatSteelVendor, HeatReceiveDate, HeatMaterialOrigin, HeatComment As String

        Dim GetSteelDataStatement As String = "SELECT SteelType, SteelSize, VendorID, DateReceived, SteelPONumber, Comments, MaterialOrigin FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber"
        Dim GetSteelDataCommand As New SqlCommand(GetSteelDataStatement, con)
        GetSteelDataCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = Val(cboHeatFileNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader1 As SqlDataReader = GetSteelDataCommand.ExecuteReader()
        If reader1.HasRows Then
            reader1.Read()
            If IsDBNull(reader1.Item("SteelType")) Then
                GetCarbon = ""
            Else
                GetCarbon = reader1.Item("SteelType")
            End If
            If IsDBNull(reader1.Item("SteelSize")) Then
                GetSteelSize = ""
            Else
                GetSteelSize = reader1.Item("SteelSize")
            End If
            If IsDBNull(reader1.Item("SteelPONumber")) Then
                HeatSteelPONumber = ""
            Else
                HeatSteelPONumber = reader1.Item("SteelPONumber")
            End If
            If IsDBNull(reader1.Item("VendorID")) Then
                HeatSteelVendor = ""
            Else
                HeatSteelVendor = reader1.Item("VendorID")
            End If
            If IsDBNull(reader1.Item("DateReceived")) Then
                HeatReceiveDate = ""
            Else
                HeatReceiveDate = reader1.Item("DateReceived")
            End If
            If IsDBNull(reader1.Item("MaterialOrigin")) Then
                HeatMaterialOrigin = ""
            Else
                HeatMaterialOrigin = reader1.Item("MaterialOrigin")
            End If
            If IsDBNull(reader1.Item("Comments")) Then
                HeatComment = ""
            Else
                HeatComment = reader1.Item("Comments")
            End If
        Else
            GetCarbon = ""
            GetSteelSize = ""
            HeatComment = ""
            HeatMaterialOrigin = ""
            HeatReceiveDate = ""
            HeatSteelPONumber = ""
            HeatSteelVendor = ""
        End If
        reader1.Close()

        txtHeatSteelSize.Text = GetSteelSize
        txtHeatSteelType.Text = GetCarbon
        txtHeatNumberComment.Text = HeatComment
        txtMaterialOrigin.Text = HeatMaterialOrigin
        txtReceiveDate.Text = HeatReceiveDate
        txtSteelPONumber.Text = HeatSteelPONumber
        txtVendorID.Text = HeatSteelVendor

        If txtAnnealedHN.Text <> "" Then
            If txtAnnealedHN.Text = "N/A" Then
                'Do nothing
            Else
                LoadAnnealedSteelCarbon()
            End If
        End If
    End Sub

    Private Sub cmdGenerateLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateLotNumber.Click
        If canGenerate() Then
            cmdGenerateLotNumber.Enabled = False
            'Command to generate new Lot Number
            Dim LotDate As DateTime = dtpLotNumberDate.Value
            Dim Year As Integer = LotDate.Year
            Dim dayofyear As Integer = LotDate.DayOfYear
            Dim strYear As String = Year.ToString.Substring(2, 2)
            ''checks the number of days and will add leading 0 before if needed
            Dim LotSerialNumber As String = cboFOXNumber.Text + Year.ToString.Substring(2, 2) + checkDayOfYear(dayofyear)
            cmd = New SqlCommand("SELECT COUNT(LotNumber) FROM LotNumber WHERE LotNumber = @LotNumber;", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = LotSerialNumber

            If con.State = ConnectionState.Closed Then con.Open()
            While cmd.ExecuteScalar() > 0
                ''check to see what day of the year it is and if its ay 365 will reset the day count and add to year
                If dayofyear >= 365 Then
                    If dayofyear Mod 4 = 0 And dayofyear = 365 Then
                        dayofyear += 1
                    Else
                        dayofyear = 1
                        Year += 1
                    End If
                Else
                    dayofyear += 1
                End If
                ''checks the number of days and will add leading 0 before if needed
                LotSerialNumber = cboFOXNumber.Text + Year.ToString.Substring(2, 2) + checkDayOfYear(dayofyear)
                cmd.Parameters.Item("@LotNumber").Value = LotSerialNumber
            End While
            con.Close()
            cboLotNumber.Text = LotSerialNumber
            Dim dat As DateTime = dtpLotNumberDate.Value
            If Year <> dat.Year Then
                dtpLotNumberDate.Value = dat.AddYears(Year - dat.Year)
                If dat.DayOfYear <> dayofyear Then
                    dtpLotNumberDate.Value = dat.AddDays(dayofyear - dat.DayOfYear)
                End If
            Else
                If dat.DayOfYear <> dayofyear Then
                    dtpLotNumberDate.Value = dat.AddDays(dayofyear - dat.DayOfYear)
                End If
            End If

            cmd = New SqlCommand("INSERT INTO LotNumber (LotNumber, FOXNumber, SteelDescription, DivisionID, Status, UserID, PieceWeight, BoxWeight, BoxCount, PalletCount, CreationDate) VALUES (@LotNumber, @FOXNumber, '', @DivisionID, 'OPEN', @User, @PieceWeight, @BoxWeight, @BoxCount, @PalletCount, @CreationDate);" _
                                 + " INSERT INTO TFPLotActivityLog (ActivityDateTime, LotNumber, ChangedField, OriginalValue, NewValue, LoginName) VALUES (@ActivityDateTime, @LotNumber, 'CREATED', 'NO', 'YES', @User);", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = EmployeeLoginName
            cmd.Parameters.Add("@ActivityDateTime", SqlDbType.DateTime2).Value = Now
            cmd.Parameters.Add("@PieceWeight", SqlDbType.Float).Value = Val(txtPieceWeight.Text)
            cmd.Parameters.Add("@BoxWeight", SqlDbType.Float).Value = Val(txtWeightPerBox.Text)
            cmd.Parameters.Add("@BoxCount", SqlDbType.Float).Value = Val(txtPiecesPerBox.Text)
            cmd.Parameters.Add("@PalletCount", SqlDbType.Float).Value = Val(txtBoxesPerPallet.Text)
            cmd.Parameters.Add("@CreationDate", SqlDbType.Date).Value = dtpLotNumberDate.Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            isloaded = False
            If DateDiff(DateInterval.Year, dtpLotNumberDate.Value, Now.Date) > 3 Then
                LoadLotNumber(True)
            Else
                LoadLotNumber()
            End If

            cboLotNumber.Text = LotSerialNumber
            isloaded = True
            needsSaved = True
            cboHeatNumber.Focus()
            cboFOXNumber.Enabled = False
            cmdGenerateLotNumber.Enabled = True
            checkStatus()
            LoadLastLotComment()
        End If
    End Sub

    Private Sub LoadLastLotComment()
        cmd = New SqlCommand("SELECT TOP 1 Comment FROM LotNumber WHERE CreationDate < @CurrentDate AND FOXNumber = @FOXNumber ORDER BY CreationDate DESC", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
        cmd.Parameters.Add("@CurrentDate", SqlDbType.Date).Value = dtpLotNumberDate.Value

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()

        If Not IsDBNull(obj) AndAlso obj IsNot Nothing AndAlso Not String.IsNullOrEmpty(CType(obj, String)) Then
            txtLotComment.Text = CType(obj, String)
        End If
    End Sub

    Private Function canGenerate() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must select a FOX Number", "Select a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid FOX", "Enter a valid FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function checkDayOfYear(ByVal dayofyear As String) As String
        If dayofyear < 100 Then
            If dayofyear < 10 Then
                Return "00" + dayofyear.ToString()
            Else
                Return "0" + dayofyear.ToString()
            End If

        Else
            Return dayofyear.ToString()
        End If
    End Function

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdLockLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLockLotNumber.Click
        'Get alternative steel type from FOX
        Dim AlternateRMID, AlternateSteelType, AlternateSteelSize As String

        Dim AlternativeRMIDStatement As String = "SELECT ScheduledRMID FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
        Dim AlternativeRMIDCommand As New SqlCommand(AlternativeRMIDStatement, con)
        AlternativeRMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        AlternativeRMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AlternateRMID = CStr(AlternativeRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            AlternateRMID = ""
        End Try
        con.Close()

        'Get Carbon, Steel Size from Alternative RMID
        Dim AlternativeSteelTypeStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = @DivisionID"
        Dim AlternativeSteelTypeCommand As New SqlCommand(AlternativeSteelTypeStatement, con)
        AlternativeSteelTypeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = AlternateRMID
        AlternativeSteelTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        Dim AlternativeSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = @DivisionID"
        Dim AlternativeSteelSizeCommand As New SqlCommand(AlternativeSteelSizeStatement, con)
        AlternativeSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = AlternateRMID
        AlternativeSteelSizeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AlternateSteelType = CStr(AlternativeSteelTypeCommand.ExecuteScalar)
        Catch ex As Exception
            AlternateSteelType = ""
        End Try
        Try
            AlternateSteelSize = CStr(AlternativeSteelSizeCommand.ExecuteScalar)
        Catch ex As Exception
            AlternateSteelSize = ""
        End Try
        con.Close()

        'Validate Steel - Heat Steel matches Fox Steel
        If (txtHeatSteelType.Text = txtSteelCarbon.Text And txtHeatSteelSize.Text = txtSteelSize.Text) Or (txtHeatSteelType.Text = AlternateSteelType And txtHeatSteelSize.Text = AlternateSteelSize) Then
            'Continue
        Else
            MsgBox("Heat # steel must match preferred/alternate steel in the FOX.", MsgBoxStyle.OkOnly)
            cboHeatNumber.Focus()
            Exit Sub
        End If

        If canLockLotNumber() Then
            FOXSchedVerification = New LotNumberMaintenanceFOXSchedVerification(cboFOXNumber.Text)
            AddHandler FOXSchedVerification.VisibleChanged, AddressOf FOXSchedVerification_VisibilityChanged
            FOXSchedVerification.Show()
        End If
    End Sub

    Private Sub LockLot()
        Try
            ValidateHeatNumber()

            If CountHeatFile = 0 Or CountHeatNumber = 0 Then
                MsgBox("You must have a valid Heat Number and Heat File Number.", MsgBoxStyle.OkOnly)
                cboHeatFileNumber.Enabled = True
                Exit Sub
            Else
                UpdateLotNumber("CLOSED")

                If txtDivisionID.Text.Equals("TFP") Then
                    cmd = New SqlCommand("UPDATE ItemList SET PieceWeight = @PieceWeight, BoxCount = @BoxCount, PalletCount = @PalletCount WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PieceWeight", SqlDbType.Float).Value = Val(txtPieceWeight.Text)
                        .Add("@BoxCount", SqlDbType.Float).Value = Val(txtPiecesPerBox.Text)
                        .Add("@PalletCount", SqlDbType.Int).Value = Val(txtBoxesPerPallet.Text)
                        .Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

            End If
        Catch ex As System.Exception
            sendErrorToDataBase("LotNumberMaintenance - cmdLockLotNumber --Error Locking Lot", "Lot #" + cboLotNumber.Text, ex.ToString())
            MessageBox.Show("There was an error trying to Lock the Lot. Contact system admin.", "Unable to Lock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        checkStatus()
    End Sub

    Private Function canLockLotNumber() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must select a Lot Number", "Select a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Lot Number", "Enter a valid Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        If Not checkStatus() Then
            MessageBox.Show("Lot Number has already been locked", "Already locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboFOXNumber.Text.Trim(" "c)) Then
            cmd = New SqlCommand("SELECT PartNumber FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()
            If Not IsDBNull(obj) And obj IsNot Nothing Then
                txtPartNumber.Text = obj.ToString()
            End If
        End If
        If String.IsNullOrEmpty(cboHeatNumber.Text) Then
            MessageBox.Show("You must select a Heat Number", "Select a Heat Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatNumber.Focus()
            Return False
        End If
        If cboHeatNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Heat Number", "Enter a valid Heat Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatNumber.SelectAll()
            cboHeatNumber.Focus()
            Return False
        End If
        'If txtDivisionID.Text.Equals("TWD") Then
        '    If Not usefulFunctions.ConvertToDecimal(cboHeatNumberSize.Text).Equals(usefulFunctions.ConvertToDecimal(txtSteelSize.Text)) Then
        '        If MessageBox.Show("Material size from the Mill certification data does not match the FOX data. Do you wish to continue?", "Continue", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
        '            Return False
        '        End If
        '    End If
        'End If
        If String.IsNullOrEmpty(cboHeatFileNumber.Text) Then
            MessageBox.Show("You must select a Heat File Number", "Select a Heat File Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatFileNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtSteelCarbon.Text) Then
            MessageBox.Show("Scheduled Material needs to be entered into the FOX.", "Unable to lock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(txtSteelSize.Text) Then
            MessageBox.Show("Scheduled Material needs to be entered into the FOX.", "Unable to lock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        'If Not txtHeatSteelType.Text.Contains(txtSteelCarbon.Text) And Not txtSteelCarbon.Text.Contains(txtHeatSteelType.Text) Then
        '    If txtHeatSteelType.Text.StartsWith("C") AndAlso txtSteelCarbon.Text.StartsWith("C") Then
        '        If Not txtSteelCarbon.Text.Substring(0, 5).Equals(txtHeatSteelType.Text.Substring(0, 5)) AndAlso txtHeatSteelType.Text.Length >= 5 AndAlso txtSteelCarbon.Text.Length >= 5 Then
        '            MessageBox.Show("Heat file grade is not the same as FOX.", "Unable to lock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Return False
        '        End If
        '    Else
        '        MessageBox.Show("Heat file grade is not the same as FOX.", "Unable to lock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        Return False
        '    End If
        'End If
        If (txtSteelCarbon.Text.EndsWith("A") And Not txtSteelCarbon.Text.Contains("AK")) Or txtDivisionID.Text.Equals("TFP") Then
            If String.IsNullOrEmpty(txtAnnealedHN.Text) And EmployeeSecurityCode > 1002 Then
                MessageBox.Show("You must enter something in for Annealed Lot.", "Enter an Annealed Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAnnealedHN.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtPartNumber.Text.Replace(" ", "")) Then
            MessageBox.Show("There must be a part number. Check FOX FORM to make sure there is a part number specified.", "Unable to lock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboCertCode.Text) Then
            MessageBox.Show("You must select a Cert Type", "Select a Cert Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCertCode.Focus()
            Return False
        End If
        If Val(txtPiecesPerBox.Text) = 0 Then
            MessageBox.Show("Pieces per box is showing 0. You must put a pieces per box.", "Unable to lock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiecesPerBox.SelectAll()
            txtPiecesPerBox.Focus()
            Return False
        End If
        If Val(txtWeightPerBox.Text) = 0 Then
            MessageBox.Show("Weight per box is showing 0. You nmust put a box weight", "Unable to lock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWeightPerBox.SelectAll()
            txtWeightPerBox.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function checkStatus() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            cmdSave.Enabled = True
            cmdDelete.Enabled = True
            cmdLockLotNumber.Enabled = True
            UnLockLotNumberToolStripMenuItem.Enabled = False
            ChangeFOXToolStripMenuItem.Enabled = False
            SaveLotNumberToolStripMenuItem.Enabled = True
            DeleteLotNumberToolStripMenuItem.Enabled = True
            cboHeatNumber.Enabled = True
            'cboHeatFileNumber.Enabled = True
            cboCertCode.Enabled = True
            cboHeatNumberSize.Enabled = True
            txtAnnealedHN.Enabled = True
            txtHeadMarking.Enabled = True
            txtLotComment.Enabled = True
            cmdPrintTubTag.Enabled = False
            cmdTubTagPage.Enabled = False
            cmdReloadData.Enabled = True
            cboBoxType.Enabled = True
            Return True
        End If
        Dim status As String = "OPEN"
        cmd = New SqlCommand("SELECT isnull(Status, 'OPEN') FROM LotNumber WHERE LotNumber = @LotNumber;", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            status = cmd.ExecuteScalar()
        Catch ex As System.Exception
        End Try
        con.Close()

        If status Is Nothing Then
            status = "OPEN"
        ElseIf status.Equals("") Then
            status = "OPEN"
        End If

        If status.Equals("OPEN") Then
            cmdSave.Enabled = True
            cmdDelete.Enabled = True
            cmdLockLotNumber.Enabled = True
            UnLockLotNumberToolStripMenuItem.Enabled = False
            ChangeFOXToolStripMenuItem.Enabled = True
            SaveLotNumberToolStripMenuItem.Enabled = True
            DeleteLotNumberToolStripMenuItem.Enabled = True
            cboHeatNumber.Enabled = True
            'cboHeatFileNumber.Enabled = True
            cboCertCode.Enabled = True
            cboHeatNumberSize.Enabled = True
            txtAnnealedHN.Enabled = True
            txtHeadMarking.Enabled = True
            txtLotComment.Enabled = True
            cmdPrintTubTag.Enabled = False
            cmdTubTagPage.Enabled = False
            txtPiecesPerBox.Enabled = True
            txtWeightPerBox.Enabled = True
            txtPieceWeight.Enabled = True
            txtBoxesPerPallet.Enabled = True
            cmdReloadData.Enabled = True
            cboBoxType.Enabled = True
            Return True
        Else
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdLockLotNumber.Enabled = False
            UnLockLotNumberToolStripMenuItem.Enabled = True
            ChangeFOXToolStripMenuItem.Enabled = False
            SaveLotNumberToolStripMenuItem.Enabled = False
            DeleteLotNumberToolStripMenuItem.Enabled = False
            cboHeatNumber.Enabled = False
            cboHeatFileNumber.Enabled = False
            cboCertCode.Enabled = False
            cboHeatNumberSize.Enabled = False
            txtAnnealedHN.Enabled = False
            txtHeadMarking.Enabled = False
            txtLotComment.Enabled = False
            cmdPrintTubTag.Enabled = True
            cmdTubTagPage.Enabled = True
            txtPiecesPerBox.Enabled = False
            txtWeightPerBox.Enabled = False
            txtPieceWeight.Enabled = False
            txtBoxesPerPallet.Enabled = False
            cmdReloadData.Enabled = False
            cboBoxType.Enabled = False
            Return False
        End If
    End Function

    Private Sub UnLockLotNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockLotNumberToolStripMenuItem.Click
        If canUnlock() Then
            cmd = New SqlCommand("UPDATE LotNumber SET Status = 'OPEN' WHERE LotNumber = @LotNumber; INSERT INTO TFPLotActivityLog (ActivityDateTime, LotNumber, ChangedField, OriginalValue, NewValue, LoginName) VALUES (@ActivityDateTime, @LotNumber, 'UNLOCKED', 'NO', 'YES', @LoginName);", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
            cmd.Parameters.Add("@ActivityDateTime", SqlDbType.DateTime2).Value = Now
            cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            checkStatus()
        End If
    End Sub

    Private Function canUnlock() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must select a Lot Number", "Select a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Lot number", "Enter a valid Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cboHeatNumberSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumberSize.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
                LoadHeatFileNumbers()
            End If
        End If
    End Sub

    Private Sub cboHeatNumberSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumberSize.Leave
        If isloaded Then
            If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
                LoadHeatFileNumbers()
            End If
        End If
    End Sub

    Private Sub cmdTubTagPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTubTagPage.Click
        If isloaded And Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            Dim newViewTubPage As New ViewTubPage(cboFOXNumber.Text, cboLotNumber.Text, lblPullTestMessage.Visible, lblTorqueTest.Visible)
            newViewTubPage.ShowDialog()
        End If
    End Sub

    Private Sub UnlockSteelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnlockSteelToolStripMenuItem.Click
        gpxUpdateSteel.Enabled = True
        If cboSteelAlloy.DataSource IsNot Nothing Then
            LoadSteel()
        End If
    End Sub

    Private Sub cmdUpdateSteel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSteel.Click
        If CanUpdateSteel() Then
            'Get RMID from test fields - carbon, steel size
            Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
            Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
            GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelAlloy.Text
            GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetRMID = ""
            End Try
            con.Close()

            'Update Lot Number
            cmd = New SqlCommand("Update LotNumber SET RMID = @RMID, SteelType = @SteelType, SteelSize = @SteelSize, SteelDescription = (SELECT Description FROM RawMaterialsTable WHERE RMID = @RMID)  WHERE LotNumber = @LotNumber; INSERT INTO TFPLotActivityLog (ActivityDateTime, LotNumber, ActionPerformed, LoginName) VALUES (@ActivityDateTime, @LotNumber, 'STEEL UPDATED', @LoginName);", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
            cmd.Parameters.Add("@SteelType", SqlDbType.VarChar).Value = cboSteelAlloy.Text
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID
            cmd.Parameters.Add("@ActivityDateTime", SqlDbType.DateTime2).Value = Now
            cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            gpxUpdateSteel.Enabled = False
            LoadLotNumberData()
        End If
    End Sub

    Private Function CanUpdateSteel() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must enter a Lot Number", "Enter a lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Lot Number", "Enter a valid lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelAlloy.Text) Then
            MessageBox.Show("You must enter a material grade.", "Enter a material grade", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelAlloy.Focus()
            Return False
        End If
        If cboSteelAlloy.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid material grade.", "Enter a valid material grade", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelAlloy.SelectAll()
            cboSteelAlloy.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelSize.Text) Then
            MessageBox.Show("You must enter a material size", "Enter a material Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.Focus()
            Return False
        End If
        If cboSteelSize.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid material size.", "Enter a valid material size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.SelectAll()
            cboSteelSize.Focus()
            Return False
        End If

        'Get RMID from test fields - carbon, steel size
        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelAlloy.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetRMID = ""
        End Try
        con.Close()

        cmd = New SqlCommand("SELECT Count(RMID) FROM RawMaterialsTable where RMID = @RMID", con)
        cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            MessageBox.Show("Material grade and size do not match any known materials. Enter a valid combination.", "Enter a valid grade and size combo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub txtPartNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartNumber.TextChanged
        If isloaded And Not String.IsNullOrEmpty(txtPartNumber.Text) Then
            LoadPartData()
        End If
    End Sub

    Private Sub txtWeightPerBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWeightPerBox.TextChanged
        If txtWeightPerBox.Focused Then
            txtWeightPerPallet.Text = Math.Ceiling(Val(txtWeightPerBox.Text) * Val(txtBoxesPerPallet.Text)).ToString()
        End If
    End Sub

    Private Sub txtBoxesPerPallet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxesPerPallet.TextChanged
        If txtBoxesPerPallet.Focused Then
            txtWeightPerPallet.Text = Math.Ceiling(Val(txtWeightPerBox.Text) * Val(txtBoxesPerPallet.Text)).ToString()
            txtPiecesPerPallet.Text = Math.Ceiling(Val(txtPiecesPerBox.Text) * Val(txtBoxesPerPallet.Text)).ToString()
        End If
    End Sub

    Private Sub txtPieceWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPieceWeight.TextChanged
        If txtPieceWeight.Focused Then
            txtWeightPerBox.Text = Math.Ceiling(Val(txtPiecesPerBox.Text) * Val(txtPieceWeight.Text)).ToString()
            txtWeightPerPallet.Text = Math.Ceiling(Val(txtWeightPerBox.Text) * Val(txtBoxesPerPallet.Text)).ToString()
        End If
    End Sub

    Private Sub txtPiecesPerBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiecesPerBox.TextChanged
        If txtPiecesPerBox.Focused Then
            txtPiecesPerPallet.Text = Math.Ceiling(Val(txtPiecesPerBox.Text) * Val(txtBoxesPerPallet.Text)).ToString()
        End If
    End Sub

    Private Sub txtPieceWeight_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPieceWeight.KeyPress, txtPiecesPerBox.KeyPress, txtWeightPerBox.KeyPress, txtBoxesPerPallet.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack And e.KeyChar <> "."c Then
            e.KeyChar = Nothing
        ElseIf e.KeyChar = "." And TypeOf sender Is System.Windows.Forms.TextBox Then
            If CType(sender, System.Windows.Forms.TextBox).Text.Contains(".") Then
                e.KeyChar = Nothing
            End If
        End If
    End Sub

    Private Sub cmdReloadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReloadData.Click
        LoadFOXData()
        LoadPartData()
        CheckPullTests()
    End Sub

    Private Sub cboHeatNumberSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboHeatNumberSize.KeyPress
        If e.KeyChar.Equals("."c) And (cboSteelSize.Text.Length = 0 Or cboHeatNumberSize.SelectionLength = cboHeatNumberSize.Text.Length) Then
            cboHeatNumberSize.Text = "0."
            e.KeyChar = Nothing
            cboHeatNumberSize.SelectionStart = cboHeatNumberSize.Text.Length
            cboHeatNumberSize.SelectionLength = 0
        End If
    End Sub

    Private Sub cboBoxType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBoxType.Leave
        If BoxReference.ContainsKey(cboBoxType.Text) Then
            cboBoxType.Text = BoxReference(cboBoxType.Text)
        End If
    End Sub

    Private Sub cboBoxType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBoxType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If BoxReference.ContainsKey(cboBoxType.Text) Then
                cboBoxType.Text = BoxReference(cboBoxType.Text)
            End If
        End If
    End Sub

    Public Sub FOXSchedVerification_VisibilityChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If FOXSchedVerification.Visible Then
            Me.Enabled = False
        Else
            Me.Enabled = True
            If FOXSchedVerification.DialogResult = Windows.Forms.DialogResult.OK Then
                CheckPullTests()
                LockLot()

                cmd = New SqlCommand("Select COUNT(ProcessID) FROM FoxSched WHERE FoxNumber = @FoxNumber AND ProcessID = 'FPI';", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                If con.State = ConnectionState.Closed Then con.Open()

                If cmd.ExecuteScalar() <> 0 Then
                    cmd = New SqlCommand("UPDATE LotNumber SET QCInspected = 'NO', QCInspector = '' WHERE LotNumber = @LotNumber;", con)
                    cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
                Else
                    cmd = New SqlCommand("UPDATE LotNumber SET QCInspected = '', QCInspector = '' WHERE LotNumber = @LotNumber;", con)
                    cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
                End If
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            Me.BringToFront()
        End If
    End Sub

    Private Sub LotNumberMaintenance_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If FOXSchedVerification IsNot Nothing Then
            If FOXSchedVerification.Visible Then
                FOXSchedVerification.BringToFront()
            ElseIf BlueprintJournalForm IsNot Nothing Then
                If BlueprintJournalForm.Visible Then
                    BlueprintJournalForm.BringToFront()
                Else
                    Me.BringToFront()
                End If
            Else
                Me.BringToFront()
            End If
        ElseIf BlueprintJournalForm IsNot Nothing Then
            If BlueprintJournalForm.Visible Then
                BlueprintJournalForm.BringToFront()
            Else
                Me.BringToFront()
            End If
        End If
    End Sub

    Private Sub CheckPullTests()
        If txtDivisionID.Text.Equals("TWD") Then
            Dim itmClass As String = txtItemClass.Text
            ''checks to see if needs to be changed and will change it to SC
            Select Case itmClass
                Case "TW CA"
                    itmClass = itmClass
                Case "TW CH"
                    itmClass = itmClass
                Case "TW DB"
                    itmClass = itmClass
                Case "TW DS"
                    itmClass = "TW SC"
                Case "TW SC"
                    itmClass = "TW SC"
                Case "TW PS"
                    itmClass = itmClass
                Case "TW SWR"
                    itmClass = itmClass
                Case "TW FER"
                    itmClass = itmClass
                Case "TW WELD PROD"
                    itmClass = itmClass
                Case Else
                    If Not txtPartNumber.Text.StartsWith("TWE09") Then
                        itmClass = "TW TT"
                    Else
                        itmClass = "TWE PART"
                    End If
            End Select

            If txtPartNumber.Text.StartsWith("DBA") Or txtPartNumber.Text.StartsWith("IT") Or txtPartNumber.Text.StartsWith("NT") Or txtPartNumber.Text.StartsWith("TF") Or txtPartNumber.Text.StartsWith("TP") Or txtPartNumber.Text.StartsWith("TT") Or txtPartNumber.Text.StartsWith("PSR") Or txtPartNumber.Text.StartsWith("SWR") Or txtPartNumber.Text.StartsWith("PSD") Or txtPartNumber.Text.StartsWith("CS") Then

                'MsgBox("Pause", MsgBoxStyle.OkOnly)

                If Val(txtNominalDiameter.Text) = 0 Then
                    lblPullTestMessage.Visible = True

                    lblNominalDiameter.BackColor = Color.LightCoral
                Else
                    lblNominalDiameter.BackColor = Color.Transparent
                    lblNominalLength.BackColor = Color.Transparent
                    cmd = New SqlCommand("", con)
                    cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
                    cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = itmClass
                    cmd.Parameters.Add("@NominalDiameter", SqlDbType.Float).Value = Val(txtNominalDiameter.Text)

                    ''check to see if the part is less than or equal to 14-7/8 long and if so will test based on length as well
                    If Val(txtNominalLength.Text) <= 14.875 Then
                        cmd.Parameters.Add("@NominalLength", SqlDbType.Float).Value = Val(txtNominalLength.Text)
                        If cboCertCode.Text.Equals("5") And Not txtSteelCarbon.Text.StartsWith("SS") Then
                            ''if a PSR or PSD stud this will get the heading process to determine how to check the pull test
                            If txtPartNumber.Text.StartsWith("PSR") Or txtPartNumber.Text.StartsWith("PSD") Then
                                cmd.CommandText = "DECLARE @ProcessID as varchar(50) = CASE WHEN EXISTS(SELECT isnull(ProcessID, 'NONE') FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = 1)" _
                                + " THEN (SELECT isnull(ProcessID, 'NONE') FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = 1)" _
                                + " ELSE (SELECT 'NONE') END;" _
                                + " DECLARE @ProcessType as varchar(5) = CASE WHEN (@ProcessID = '098' OR @ProcessID = '099' OR @ProcessID = '097') THEN (SELECT 'HOT') ELSE (SELECT 'COLD') END;"
                                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                                ''Sets the command to meet the minimum standard for AWD for Stainless
                                cmd.CommandText += "SELECT COUNT(TestNumber) FROM (SELECT TestNumber, PartNumber, DivisionID FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND PullTestData.ItemClass = @ItemClass AND PullTestData.NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 56000 AND UltimateYieldPSI >= 72000 AND Status = 'CLOSED' AND PullTestData.ProcessType = @ProcessType) as PullTestData"
                            Else
                                ''Trims down the entries from the pull test tables
                                cmd.CommandText = "SELECT COUNT(TestNumber) FROM (SELECT TestNumber, PartNumber, DivisionID FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND PullTestData.ItemClass = @ItemClass AND PullTestData.NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 56000 AND UltimateYieldPSI >= 72000 AND Status = 'CLOSED') as PullTestData"
                            End If
                            ''adds in the item list table to check the nominal length
                            cmd.CommandText += " INNER JOIN ItemList on PullTestData.PartNumber = ItemList.ItemID AND PullTestData.DivisionID = ItemList.DivisionID WHERE ItemList.NominalLength >= @NominalLength"
                        ElseIf Not txtSteelCarbon.Text.StartsWith("SS") Then
                            ''if a PSR or PSD stud this will get the heading process to determine how to check the pull test
                            If txtPartNumber.Text.StartsWith("PSR") Or txtPartNumber.Text.StartsWith("PSD") Then
                                cmd.CommandText = "DECLARE @ProcessID as varchar(50) = CASE WHEN EXISTS(SELECT isnull(ProcessID, 'NONE') FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = 1) THEN (SELECT isnull(ProcessID, 'NONE') FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = 1) ELSE (SELECT 'NONE') END; DECLARE @ProcessType as varchar(5) = CASE WHEN (@ProcessID = '098' OR @ProcessID = '099' OR @ProcessId = '097') THEN (SELECT 'HOT') ELSE (SELECT 'COLD') END;"
                                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                                ''Sets the command to meet the minimum standard for AWD for Stainless
                                cmd.CommandText += "SELECT COUNT(TestNumber) FROM (SELECT TestNumber, PartNumber, DivisionID FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND PullTestData.ItemClass = @ItemClass AND PullTestData.NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 51000 AND UltimateYieldPSI >= 65000 AND Status = 'CLOSED' AND PullTestData.ProcessType = @ProcessType) as PullTestData"
                            Else
                                ''Sets the command to meet the minimum standard for AWD for Non-Stainless
                                cmd.CommandText = "SELECT COUNT(TestNumber) FROM (SELECT TestNumber, PartNumber, DivisionID FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND PullTestData.ItemClass = @ItemClass AND PullTestData.NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 49000 AND UltimateYieldPSI >= 61000 AND Status = 'CLOSED') as PullTestData"
                            End If
                            ''adds in the item list table to check the nominal length
                            cmd.CommandText += " INNER JOIN ItemList on PullTestData.PartNumber = ItemList.ItemID AND PullTestData.DivisionID = ItemList.DivisionID WHERE ItemList.NominalLength >= @NominalLength"
                        Else
                            ''Sets the command to meet the minimum standard for AWD for Stainless
                            cmd.CommandText = "SELECT COUNT(TestNumber) FROM (SELECT TestNumber, PartNumber, DivisionID FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND PullTestData.ItemClass = @ItemClass AND PullTestData.NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 35000 AND UltimateYieldPSI >= 70000 AND Status = 'CLOSED') as PullTestData"
                            ''adds in the item list table to check the nominal length
                            cmd.CommandText += " INNER JOIN ItemList on PullTestData.PartNumber = ItemList.ItemID AND PullTestData.DivisionID = ItemList.DivisionID WHERE ItemList.NominalLength >= @NominalLength"
                        End If
                    Else
                        If cboCertCode.Text.Equals("5") And Not txtSteelCarbon.Text.StartsWith("SS") Then
                            cmd.CommandText = "SELECT COUNT(TestNumber) FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 56000 AND UltimateYieldPSI >= 72000 AND Status = 'CLOSED'"
                        ElseIf Not txtSteelCarbon.Text.StartsWith("SS") Then
                            ''Sets the command to meet the minimum standard for AWD for Non-Stainless
                            cmd.CommandText = "SELECT COUNT(TestNumber) FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 51000 AND UltimateYieldPSI >= 65000 AND Status = 'CLOSED'"
                        Else
                            ''Sets the command to meet the minimum standard for AWD for Stainless
                            cmd.CommandText = "SELECT COUNT(TestNumber) FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 35000 AND UltimateYieldPSI >= 70000 AND Status = 'CLOSED'"
                        End If
                    End If

                    If con.State = ConnectionState.Closed Then con.Open()

                    If cmd.ExecuteScalar() = 0 Then
                        lblPullTestMessage.Visible = True
                    Else
                        lblPullTestMessage.Visible = False
                    End If
                End If
                If con.State = ConnectionState.Open Then con.Close()
            ElseIf txtDivisionID.Text.Equals("TWD") And itmClass <> "TW WELD PROD" Then

                'MsgBox("Pause2", MsgBoxStyle.OkOnly)

                If Val(txtNominalLength.Text) = 0 Or Val(txtNominalDiameter.Text) = 0 Then
                    If Not txtPartNumber.Text.StartsWith("TWE09") Then
                        lblPullTestMessage.Visible = True
                        If Val(txtNominalDiameter.Text) = 0 Then
                            lblNominalDiameter.BackColor = Color.LightCoral
                        End If
                        If Val(txtNominalLength.Text) = 0 Then
                            lblNominalLength.BackColor = Color.LightCoral
                        End If
                    Else
                        lblPullTestMessage.Visible = False
                        lblNominalDiameter.BackColor = Color.Transparent
                        lblNominalLength.BackColor = Color.Transparent
                    End If

                Else
                    lblNominalDiameter.BackColor = Color.Transparent
                    lblNominalLength.BackColor = Color.Transparent
                    cmd = New SqlCommand("", con)
                    cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
                    cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = itmClass
                    cmd.Parameters.Add("@NominalLength", SqlDbType.Float).Value = Val(txtNominalLength.Text)
                    cmd.Parameters.Add("@NominalDiameter", SqlDbType.Float).Value = Val(txtNominalDiameter.Text)

                    ''will change the command if the item needs to meet the BS 5400 minimum
                    If cboCertCode.Text.Equals("5") And Not txtSteelCarbon.Text.StartsWith("SS") Then
                        cmd.CommandText = "SELECT COUNT(TestNumber) FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalLength >= @NominalLength AND NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 56000 AND UltimateYieldPSI >= 72000 AND Status = 'CLOSED'"
                    ElseIf Not txtSteelCarbon.Text.StartsWith("SS") Then
                        ''Sets the command to meet the minimum standard for AWD for Non-Stainless
                        cmd.CommandText = "SELECT COUNT(TestNumber) FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalLength >= @NominalLength AND NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 51000 AND UltimateYieldPSI >= 65000 AND Status = 'CLOSED'"
                    Else
                        ''Sets the command to meet the minimum standard for AWD for Stainless
                        cmd.CommandText = "SELECT COUNT(TestNumber) FROM PullTestData INNER JOIN PullTestLineTable ON PullTestData.TestNumber = PullTestLineTable.PullTestNumber WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalLength >= @NominalLength AND NominalDiameter = @NominalDiameter AND Yield2PercentPSI >= 35000 AND UltimateYieldPSI >= 70000 AND Status = 'CLOSED'"
                    End If
                    If con.State = ConnectionState.Closed Then con.Open()
                    If cmd.ExecuteScalar() = 0 Then
                        lblPullTestMessage.Visible = True
                    Else
                        lblPullTestMessage.Visible = False
                    End If
                End If
                If con.State = ConnectionState.Open Then con.Close()
            ElseIf txtDivisionID.Text.Equals("TWD") And itmClass = "TW WELD PROD" Then

                'MsgBox("Pause3", MsgBoxStyle.OkOnly)

                'Set default for TWD parts which require no pull test
                lblPullTestMessage.Visible = False
                lblNominalDiameter.BackColor = Color.Transparent
                lblNominalLength.BackColor = Color.Transparent
            Else
                'Set default for TWD parts which require no pull test
                lblPullTestMessage.Visible = False
                lblNominalDiameter.BackColor = Color.Transparent
                lblNominalLength.BackColor = Color.Transparent
            End If
        Else
            'MsgBox("Pause4", MsgBoxStyle.OkOnly)

            lblNominalDiameter.BackColor = Color.Transparent
            lblNominalLength.BackColor = Color.Transparent

            Dim CountFOXES As Integer = 0
            Dim CountFOXES2 As Integer = 0
            Dim CountFOXES3 As Integer = 0
            Dim CountFOXES4 As Integer = 0

            Dim CountFOXESStatement As String = "SELECT COUNT(FOXNumber) FROM FOXCertifications WHERE FOXNumber = @FOXNumber and Certification = 'Tensile Proof Load and Ultimate'"
            Dim CountFOXESCommand As New SqlCommand(CountFOXESStatement, con)
            CountFOXESCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountFOXES = CInt(CountFOXESCommand.ExecuteScalar)
            Catch ex As System.Exception
                CountFOXES = 0
            End Try
            con.Close()

            If CountFOXES > 0 Then
                Dim CountFOXES2Statement As String = "SELECT COUNT(TestNumber) FROM TrufitCertificationMechanicalTestHeader WHERE LotNumber = @LotNumber"
                Dim CountFOXES2Command As New SqlCommand(CountFOXES2Statement, con)
                CountFOXES2Command.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = Val(cboLotNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountFOXES2 = CInt(CountFOXES2Command.ExecuteScalar)
                Catch ex As System.Exception
                    CountFOXES2 = 0
                End Try
                con.Close()

                If CountFOXES2 > 0 Then
                    lblPullTestMessage.Hide()
                Else
                    lblPullTestMessage.Show()
                End If
            Else
                lblPullTestMessage.Show()
            End If

            Dim CountFOXES3Statement As String = "SELECT COUNT(FOXNumber) FROM FOXCertifications WHERE FOXNumber = @FOXNumber and Certification = 'Torque Test'"
            Dim CountFOXES3Command As New SqlCommand(CountFOXES3Statement, con)
            CountFOXES3Command.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountFOXES3 = CInt(CountFOXES3Command.ExecuteScalar)
            Catch ex As System.Exception
                CountFOXES3 = 0
            End Try
            con.Close()

            If CountFOXES3 > 0 Then
                Dim CountFOXES4Statement As String = "SELECT Count(TestNumber) FROM TrufitCertificationTorqueTestHeader WHERE LotNumber = @LotNumber"
                Dim CountFOXES4Command As New SqlCommand(CountFOXES4Statement, con)
                CountFOXES4Command.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = Val(cboLotNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountFOXES4 = CInt(CountFOXES4Command.ExecuteScalar)
                Catch ex As System.Exception
                    CountFOXES4 = 0
                End Try
                con.Close()

                If CountFOXES4 > 0 Then
                    lblTorqueTest.Hide()
                Else
                    lblTorqueTest.Show()
                End If
            Else
                lblTorqueTest.Hide()
            End If

            CountFOXES = 0
            CountFOXES2 = 0
            CountFOXES3 = 0
            CountFOXES4 = 0
        End If
    End Sub

    Private Sub cmdViewEntries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewEntries.Click
        If Not String.IsNullOrEmpty(txtBlueprintNumber.Text) Then
            BlueprintJournalForm = New BlueprintJournal(txtBlueprintNumber.Text)
            AddHandler BlueprintJournalForm.VisibleChanged, AddressOf BlueprintJournalForm_VisibilityChanged
            BlueprintJournalForm.Show()
        End If
    End Sub

    Public Sub BlueprintJournalForm_VisibilityChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If BlueprintJournalForm.Visible Then
            Me.Enabled = False
        Else
            Me.Enabled = True
            Me.BringToFront()
        End If
    End Sub

    Private Sub txt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPieceWeight.Leave, txtPiecesPerBox.Leave, txtWeightPerBox.Leave, txtBoxesPerPallet.Leave, cboHeatNumber.Leave
        If TypeOf (sender) Is System.Windows.Forms.TextBox AndAlso Not String.IsNullOrEmpty(cboLotNumber.Text) AndAlso Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            Dim txt As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            If txt.Tag IsNot Nothing Then
                Dim tmp As New usefulFunctions.FieldData
                tmp.ColumnName = txt.Tag.Replace("ItemList.", "").Replace("FOXTable.", "")
                cmd = New SqlCommand("IF EXISTS(SELECT LotNumber." + txt.Tag.Replace("ItemList.", "").Replace("FOXTable.", "") + " FROM ItemList INNER JOIN FOXTable ON ItemList.ItemID = FOXTable.PartNumber AND ItemList.DivisionID = FOXTable.DivisionID INNER JOIN LotNumber ON LotNumber.FOXNumber = FOXTable.FOXNumber WHERE LotNumber.LotNumber = @LotNumber)", con)
                cmd.CommandText += " BEGIN SELECT LotNumber." + tmp.ColumnName + " FROM ItemList INNER JOIN FOXTable ON ItemList.ItemID = FOXTable.PartNumber AND ItemList.DivisionID = FOXTable.DivisionID INNER JOIN LotNumber ON LotNumber.FOXNumber = FOXTable.FOXNumber WHERE LotNumber.LotNumber = @LotNumber END"
                cmd.CommandText += " ELSE BEGIN SELECT " + txt.Tag + " FROM ItemList INNER JOIN FOXTable ON ItemList.ItemID = FOXTable.PartNumber AND ItemList.DivisionID = FOXTable.DivisionID WHERE FOXTable.FOXNumber = @FOXNumber END"
                cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

                Dim obj As Object = Nothing
                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    obj = cmd.ExecuteScalar()
                Catch ex As Exception

                Finally
                    con.Close()
                End Try
                If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                    If Not obj.ToString.Equals(txt.Text) Then
                        tmp.OriginalValue = obj.ToString()
                        tmp.NewValue = txt.Text
                        lstChangedFields.Add(tmp)
                    Else
                        lstChangedFields.Remove(tmp)
                    End If
                Else
                    tmp.OriginalValue = ""
                    tmp.NewValue = txt.Text
                    lstChangedFields.Add(tmp)
                End If
            End If
        ElseIf TypeOf (sender) Is System.Windows.Forms.ComboBox AndAlso Not String.IsNullOrEmpty(cboLotNumber.Text) AndAlso Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            Dim cbo As System.Windows.Forms.ComboBox = CType(sender, System.Windows.Forms.ComboBox)
            If cbo.Tag IsNot Nothing Then
                Dim tmp As New usefulFunctions.FieldData
                tmp.ColumnName = cbo.Tag.Replace("ItemList.", "").Replace("FOXTable.", "")
                cmd = New SqlCommand("SELECT LotNumber." + tmp.ColumnName + " FROM LotNumber WHERE LotNumber.LotNumber = @LotNumber", con)
                cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text

                Dim obj As Object = Nothing
                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    obj = cmd.ExecuteScalar()
                Catch ex As Exception

                Finally
                    con.Close()
                End Try
                If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                    If Not obj.ToString.Equals(cbo.Text) Then
                        tmp.OriginalValue = obj.ToString()
                        tmp.NewValue = cbo.Text
                        lstChangedFields.Add(tmp)
                    Else
                        lstChangedFields.Remove(tmp)
                    End If
                Else
                    tmp.OriginalValue = ""
                    tmp.NewValue = cbo.Text
                    lstChangedFields.Add(tmp)
                End If
            End If
        End If
    End Sub

    Private Sub UpdateLog()
        Dim lst As List(Of usefulFunctions.FieldData) = lstChangedFields.GetList()

        If lst.Count > 0 Then
            cmd = New SqlCommand("INSERT INTO TFPLotActivityLog (ActivityDateTime, LoginName, LotNumber, ChangedField, OriginalValue, NewValue)", con)
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text

            For i As Integer = 0 To lst.Count - 1
                If i = 0 Then
                    cmd.CommandText += " VALUES (CURRENT_TIMESTAMP, @UserID, @LotNumber, @ColumnName" + i.ToString + ", @Original" + i.ToString + ", @New" + i.ToString + ")"
                Else
                    cmd.CommandText += ", (CURRENT_TIMESTAMP, @UserID, @LotNumber, @ColumnName" + i.ToString + ", @Original" + i.ToString + ", @New" + i.ToString + ")"
                End If
                cmd.Parameters.Add("@ColumnName" + i.ToString, SqlDbType.VarChar).Value = lst(i).ColumnName
                cmd.Parameters.Add("@Original" + i.ToString, SqlDbType.VarChar).Value = lst(i).OriginalValue
                cmd.Parameters.Add("@New" + i.ToString, SqlDbType.VarChar).Value = lst(i).NewValue
            Next

            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
            lstChangedFields.Clear()
        End If
    End Sub

    Private Sub ActivityLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivityLogToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            cmd = New SqlCommand("SELECT ActivityDateTime as [Activity Date], ActivityDateTime as [Activity Time], LoginName as [User], ChangedField as [Changed Field], OriginalValue as [Original Value], NewValue as [New Value]  FROM TFPLotActivityLog WHERE LotNumber = @LotNumber ORDER BY [Activity Date] DESC, [Activity Time] DESC ", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text

            Dim dt As New Data.DataTable("Activity")
            Dim adap As New SqlDataAdapter(cmd)
            If con.State = ConnectionState.Closed Then con.Open()
            adap.Fill(dt)
            con.Close()
            Dim frm As New ViewActivityLog(dt)
            frm.ShowDialog()
        Else
            Dim frm As New ViewActivityLog("LotNumber", Nothing)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub ChangeFOXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeFOXToolStripMenuItem.Click
        Dim inputFOX As New InputComboBox("FOX", "")
        If CanChangeFOX() AndAlso inputFOX.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmd = New SqlCommand("UPDATE LotNumber SET FOXNumber = @NewFOX WHERE LotNumber = @LotNumber", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
            cmd.Parameters.Add("@NewFOX", SqlDbType.Int).Value = Val(inputFOX.cboInputValue.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cboFOXNumber.Text = inputFOX.cboInputValue.Text
            LoadFOXData()
            LoadPartData()
            CheckPullTests()
        End If
    End Sub

    Private Function CanChangeFOX() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must enter a lot number", "Enter a lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid lot number", "Enter a lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not checkStatus() Then
            MessageBox.Show("Lot number is closed, unable to change FOX.", "Unable to change FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        cmd = New SqlCommand("SELECT Count(LotNumber) FROM RackingMasterList WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            MessageBox.Show("Lot number has been added to the racking, unable to change FOX.", "Unable to change FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        cmd.CommandText = "SELECT Count(LotNumber) FROM ShipmentLineLotNumbers WHERE LotNumber = @LotNumber"
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            MessageBox.Show("Lot number has been added to a shipment, unable to change FOX.", "Unable to change FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        con.Close()
        Return True
    End Function

    Private Sub cboLotNumber_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cboLotNumber.PreviewKeyDown
        If ((e.KeyCode = Keys.OemMinus Or e.KeyCode = Keys.Subtract) And cboLotNumber.Text.Contains("-")) Or (cboLotNumber.Text.Length >= 17 And Not e.KeyCode = Keys.Back And Not e.KeyCode = Keys.Delete) Then
            RemoveKeyChar = True
        End If
    End Sub

    Private Sub cboLotNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLotNumber.KeyPress
        If RemoveKeyChar Then
            e.KeyChar = Nothing
            RemoveKeyChar = False
        Else
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub LoadAllLotNumbersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadAllLotNumbersToolStripMenuItem.Click
        isloaded = False
        Dim tmp As String = cboLotNumber.Text
        LoadLotNumber(True)
        isloaded = True
        cboLotNumber.Text = tmp
    End Sub

    Private Sub cboFOXNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFOXNumber.KeyPress
        If e.KeyChar = "."c Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtAnnealedHN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAnnealedHN.TextChanged
        If txtAnnealedHN.Text = "" Then
            'Do nothing
        ElseIf txtAnnealedHN.Text = "N/A" Then
            'Do nothing
        Else
            LoadAnnealedSteelCarbon()
        End If
    End Sub

    Private Sub LotNumberMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class