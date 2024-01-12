Imports System
Imports System.Math
Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class HeatTreatDataForm
    Inherits System.Windows.Forms.Form

    Dim ShortDescription, CustomerID, HeatNumber, BlueprintNumber, SteelSize, SteelCarbon, PartNumber As String
    Dim LotNumber, AnnealLotNumber, Signoff1, Signoff2, Signoff3, ProcessDescription, ProgramDescription, CreationDate, Comments, AustenizingFurnace, AustenizingTemperature, AustenizingTime, DivisionID, OperatorName, QuenchType, QuenchTemperature As String
    Dim WeightPerLoad, FOXNumber As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet

    Dim isLoaded As Boolean = False
    Dim isClosing As Boolean = False

    Public Sub LoadHeatTreatFileNumber()
        cmd = New SqlCommand("SELECT HeatTreatRecordNumber FROM HeatTreatInspectionLog ORDER BY HeatTreatRecordNumber DESC;", con)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "HeatTreatInspectionLog")
        con.Close()

        cboHeatTreatFileNumber.DisplayMember = "HeatTreatRecordNumber"
        cboHeatTreatFileNumber.DataSource = ds.Tables("HeatTreatInspectionLog")
        cboHeatTreatFileNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber;", con)
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter7.Fill(ds7, "LotNumber")
        con.Close()

        cboLotNumber.DisplayMember = "LotNumber"
        cboLotNumber.DataSource = ds7.Tables("LotNumber")
        cboLotNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartData()
        Dim ShortDescriptionString As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP');"
        Dim ShortDescriptionCommand As New SqlCommand(ShortDescriptionString, con)
        ShortDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShortDescription = ShortDescriptionCommand.ExecuteScalar().ToString()
        Catch ex As Exception
            ShortDescription = ""
        End Try
        con.Close()

        lblPartDescription.Text = ShortDescription
    End Sub

    Public Sub LoadLotNumberData()
        Dim lotNumb As String = cboLotNumber.Text
        If lotNumb.Contains("-") Then
            lotNumb = lotNumb.Substring(0, lotNumb.LastIndexOf("-"))
        End If
        Dim HeatNumberString As String = "SELECT HeatNumber, LotNumber.PartNumber, LotNumber.FOXNumber, SteelSize, SteelType, LotNumber.BlueprintNumber, AnnealedHeatNumber, FOXTable.DivisionID FROM LotNumber LEFT OUTER JOIN FOXTable on LotNumber.FOXNumber = FOXTable.FOXNumber WHERE LotNumber.LotNumber = @LotNumber;"
        Dim HeatNumberCommand As New SqlCommand(HeatNumberString, con)
        HeatNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = lotNumb

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = HeatNumberCommand.ExecuteReader()
        Dim annealHeat As String = ""
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = txtHeatNumber.Text
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = txtPartNumber.Text
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                FOXNumber = Val(txtFOXNumber.Text)
            Else
                FOXNumber = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = txtSteelSize.Text
            Else
                SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("SteelType")) Then
                SteelCarbon = txtCarbon.Text
            Else
                SteelCarbon = reader.Item("SteelType")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                BlueprintNumber = txtBlueprintNumber.Text
            Else
                BlueprintNumber = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("AnnealedHeatNumber")) Then
                annealHeat = ""
            Else
                annealHeat = reader.Item("AnnealedHeatNumber")
            End If
            If IsDBNull(reader.Item("DivisionID")) Then
                cboDivisionID.Text = EmployeeCompanyCode
            Else
                cboDivisionID.Text = reader.Item("DivisionID")
            End If
        Else
            HeatNumber = txtHeatNumber.Text
            PartNumber = txtPartNumber.Text
            FOXNumber = Val(txtFOXNumber.Text)
            SteelSize = txtSteelSize.Text
            SteelCarbon = txtCarbon.Text
            BlueprintNumber = txtBlueprintNumber.Text
            annealHeat = ""
            cboDivisionID.Text = EmployeeCompanyCode
        End If
        reader.Close()
        con.Close()

        txtHeatNumber.Text = HeatNumber
        txtFOXNumber.Text = FOXNumber
        txtPartNumber.Text = PartNumber
        txtSteelSize.Text = SteelSize
        txtCarbon.Text = SteelCarbon
        txtBlueprintNumber.Text = BlueprintNumber
        txtAnnealLot.Text = annealHeat
    End Sub

    Public Sub LoadHeatFileData()
        Dim FinishDiameter As Double = 0
        Dim Status As String = ""
        Dim HeatNumberString As String = "SELECT * FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber"
        Dim HeatNumberCommand As New SqlCommand(HeatNumberString, con)
        HeatNumberCommand.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = Val(cboHeatTreatFileNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = HeatNumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = txtHeatNumber.Text
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                FOXNumber = Val(txtFOXNumber.Text)
            Else
                FOXNumber = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("LotNumber")) Then
                LotNumber = cboLotNumber.Text
            Else
                LotNumber = reader.Item("LotNumber")
            End If
            If IsDBNull(reader.Item("AnnealLotNumber")) Then
                AnnealLotNumber = ""
            Else
                AnnealLotNumber = reader.Item("AnnealLotNumber")
            End If
            If IsDBNull(reader.Item("Signoff1")) Then
                Signoff1 = ""
            Else
                Signoff1 = reader.Item("Signoff1")
            End If
            If IsDBNull(reader.Item("Signoff2")) Then
                Signoff2 = ""
            Else
                Signoff2 = reader.Item("Signoff2")
            End If
            If IsDBNull(reader.Item("Signoff3")) Then
                Signoff3 = ""
            Else
                Signoff3 = reader.Item("Signoff3")
            End If
            If IsDBNull(reader.Item("FinishDiameter")) Then
                FinishDiameter = 0
            Else
                FinishDiameter = reader.Item("FinishDiameter")
            End If
            If IsDBNull(reader.Item("WeightPerLoad")) Then
                WeightPerLoad = 0
            Else
                WeightPerLoad = reader.Item("WeightPerLoad")
            End If
            If IsDBNull(reader.Item("ProcessDescription")) Then
                ProcessDescription = cboProcessType.Text
            Else
                ProcessDescription = reader.Item("ProcessDescription")
            End If
            If IsDBNull(reader.Item("ProgramDescription")) Then
                ProgramDescription = cboProgramNumber.Text
            Else
                ProgramDescription = reader.Item("ProgramDescription")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                BlueprintNumber = ""
            Else
                BlueprintNumber = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("CreationDate")) Then
                CreationDate = Today()
            Else
                CreationDate = reader.Item("CreationDate")
            End If
            If IsDBNull(reader.Item("Comments")) Then
                Comments = ""
            Else
                Comments = reader.Item("Comments")
            End If
            If IsDBNull(reader.Item("AustenizingFurnace")) Then
                AustenizingFurnace = cboFurnaceSelection.Text
            Else
                AustenizingFurnace = reader.Item("AustenizingFurnace")
            End If
            If IsDBNull(reader.Item("AustenizingTemperature")) Then
                AustenizingTemperature = ""
            Else
                AustenizingTemperature = reader.Item("AustenizingTemperature")
            End If
            If IsDBNull(reader.Item("AustenizingTime")) Then
                AustenizingTime = ""
            Else
                AustenizingTime = reader.Item("AustenizingTime")
            End If
            If IsDBNull(reader.Item("DivisionID")) Then
                DivisionID = EmployeeCompanyCode
            Else
                DivisionID = reader.Item("DivisionID")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                CustomerID = txtCustomerID.Text
            Else
                CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = txtPartNumber.Text
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("OperatorName")) Then
                OperatorName = ""
            Else
                OperatorName = reader.Item("OperatorName")
            End If
            If IsDBNull(reader.Item("Shift")) Then
                cboEmployeeShift.SelectedIndex = -1
            Else
                cboEmployeeShift.Text = reader.Item("Shift")
            End If
            If IsDBNull(reader.Item("QuenchType")) Then
                QuenchType = cboQuenchType.Text
            Else
                QuenchType = reader.Item("QuenchType")
            End If
            If IsDBNull(reader.Item("QuenchTemperature")) Then
                QuenchTemperature = ""
            Else
                QuenchTemperature = reader.Item("QuenchTemperature")
            End If
            If IsDBNull(reader.Item("BatchNumber")) Then
                txtBatchNumber.Text = ""
            Else
                txtBatchNumber.Text = reader.Item("BatchNumber")
            End If
            If IsDBNull(reader.Item("Status")) Then
                Status = ""
            Else
                Status = reader.Item("Status")
            End If
        Else
            HeatNumber = txtHeatNumber.Text
            FOXNumber = Val(txtFOXNumber.Text)
            LotNumber = cboLotNumber.Text
            AnnealLotNumber = ""
            Signoff1 = ""
            Signoff2 = ""
            Signoff3 = ""
            FinishDiameter = 0
            WeightPerLoad = 0
            ProcessDescription = cboProcessType.Text
            ProgramDescription = cboProgramNumber.Text
            BlueprintNumber = ""
            CreationDate = Today()
            Comments = ""
            AustenizingFurnace = cboFurnaceSelection.Text
            AustenizingTemperature = ""
            AustenizingTime = ""
            DivisionID = EmployeeCompanyCode
            CustomerID = txtCustomerID.Text
            PartNumber = txtPartNumber.Text
            OperatorName = ""
            cboEmployeeShift.SelectedIndex = -1
            QuenchType = cboQuenchType.Text
            QuenchTemperature = ""
            txtBatchNumber.Text = ""
            Status = ""
        End If
        reader.Close()
        con.Close()

        txtHeatNumber.Text = HeatNumber
        txtFOXNumber.Text = FOXNumber
        cboLotNumber.Text = LotNumber

        If String.IsNullOrEmpty(txtCarbon.Text) Then
            LoadLotNumberData()
        End If

        txtAnnealLot.Text = AnnealLotNumber
        txtInsp1.Text = Signoff1
        txtInsp2.Text = Signoff2
        txtInsp3.Text = Signoff3
        txtFinishedDiameter.Text = FinishDiameter
        txtWeightPerLoad.Text = WeightPerLoad
        cboProcessType.Text = ProcessDescription
        cboProgramNumber.Text = ProgramDescription
        txtBlueprintNumber.Text = BlueprintNumber
        dtpRecordDate.Text = CreationDate
        txtComments.Text = Comments
        cboFurnaceSelection.Text = AustenizingFurnace
        txtAustenizingTemperature.Text = AustenizingTemperature
        txtAustenizingTime.Text = AustenizingTime
        cboDivisionID.Text = DivisionID
        txtCustomerID.Text = CustomerID
        txtPartNumber.Text = PartNumber
        txtOperatorName.Text = OperatorName
        If cboEmployeeShift.Text = "0" Then
            cboEmployeeShift.Text = ""
        End If
        cboQuenchType.Text = QuenchType
        txtQuenchTemperature.Text = QuenchTemperature

        If Status.Equals("OPEN") Then
            dtpRecordDate.Enabled = True
            cboLotNumber.Enabled = True
            txtAnnealLot.Enabled = True
            cboDivisionID.Enabled = True
            txtComments.Enabled = True
            txtInsp1.Enabled = True
            txtInsp2.Enabled = True
            txtInsp3.Enabled = True
            grpxProcessData.Enabled = True
            cboTemperingFurnace.Enabled = True
            cboFinishType.Enabled = True
            txtTemperingTemperature.Enabled = True
            txtTemperingTime.Enabled = True
            cboCoreHardness.Enabled = True
            dgvTestData.Enabled = True
            cmdSave.Enabled = True
            cmdDelete.Enabled = True
            cmdLockRecord.Enabled = True
        Else
            dtpRecordDate.Enabled = False
            cboLotNumber.Enabled = False
            txtAnnealLot.Enabled = False
            cboDivisionID.Enabled = False
            txtComments.Enabled = False
            txtInsp1.Enabled = False
            txtInsp2.Enabled = False
            txtInsp3.Enabled = False
            grpxProcessData.Enabled = False
            cboTemperingFurnace.Enabled = False
            cboFinishType.Enabled = False
            txtTemperingTemperature.Enabled = False
            txtTemperingTime.Enabled = False
            cboCoreHardness.Enabled = False
            dgvTestData.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdLockRecord.Enabled = False
        End If
    End Sub

    Private Sub LoadFOXData()
        cmd = New SqlCommand("SELECT PartNumber, BluePrintNumber, CustomerID FROM FOXTable WHERE FOXNumber = @FOXNumber;", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = txtFOXNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                txtPartNumber.Text = ""
            Else
                txtPartNumber.Text = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("BluePrintNumber")) Then
                txtBlueprintNumber.Text = ""
            Else
                txtBlueprintNumber.Text = reader.Item("BluePrintNumber")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                txtCustomerID.Text = ""
            Else
                txtCustomerID.Text = reader.Item("CustomerID")
            End If
        Else
            txtPartNumber.Text = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND (DivisionID = @DivisionID OR DivisionID='TFP' );", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerName")) Then
                lblCustomerName.Text = ""
            Else
                lblCustomerName.Text = reader.Item("CustomerName")
            End If
        Else
            lblCustomerName.Text = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub Cleardata()
        cboHeatTreatFileNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            cboHeatTreatFileNumber.Text = ""
        End If
        cboLotNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            cboLotNumber.Text = ""
        End If
        cboTestType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboTestType.Text) Then
            cboTestType.Text = ""
        End If
        cboProcessType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboProcessType.Text) Then
            cboProcessType.Text = ""
        End If
        cboProgramNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboProgramNumber.Text) Then
            cboProgramNumber.Text = ""
        End If
        cboCoreHardness.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCoreHardness.Text) Then
            cboCoreHardness.Text = ""
        End If
        cboEmployeeShift.SelectedIndex = 0
        cboFinishType.SelectedIndex = 0
        cboFurnaceSelection.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFurnaceSelection.Text) Then
            cboFurnaceSelection.Text = ""
        End If
        cboQuenchType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboQuenchType.Text) Then
            cboQuenchType.Text = ""
        End If
        cboTemperingFurnace.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboTemperingFurnace.Text) Then
            cboTemperingFurnace.Text = ""
        End If

        nupTemperingNumber.Value = 1
        lblPartDescription.Text = ""
        lblCustomerName.Text = ""

        txtHeatNumber.Clear()
        txtFOXNumber.Clear()
        txtCustomerID.Clear()
        txtCarbon.Clear()
        txtPartNumber.Clear()
        txtSteelSize.Clear()
        txtBlueprintNumber.Clear()
        txtInsp1.Clear()
        txtInsp2.Clear()
        txtInsp3.Clear()
        txtAustenizingTemperature.Clear()
        txtFinishedDiameter.Clear()
        txtOperatorName.Clear()
        txtQuenchTemperature.Clear()
        txtTemperingTemperature.Clear()
        txtWeightPerLoad.Clear()
        txtScanLotNumber.Clear()

        txtCoreScaleHigh.Clear()
        txtCoreScaleLow.Clear()
        txtCoreScaleMean.Clear()
        txtSurfaceScale1High.Clear()
        txtSurfaceScale1Low.Clear()
        txtSurfaceScale1Mean.Clear()
        txtSurfaceScale2High.Clear()
        txtSurfaceScale2Low.Clear()
        txtSurfaceScale2Mean.Clear()

        cboHeatTreatFileNumber.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub HeatTreatDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadHeatTreatFileNumber()
        LoadLotNumber()
        Cleardata()
        setupRockTestDGV()

        isLoaded = True

        If EmployeeSecurityCode.Equals(1002) Or EmployeeSecurityCode.Equals(1001) Or EmployeeSecurityCode.Equals(1030) Or EmployeeSecurityCode.Equals(1007) Or EmployeeLoginName.Equals("AFINCHAM") Then
            UnLockRecordToolStripMenuItem.Enabled = True
        End If
        If GlobalHeatTreatFileNumber <> 0 Then
            cboHeatTreatFileNumber.Text = GlobalHeatTreatFileNumber
        End If
    End Sub

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        If isLoaded Then
            ''Check for "S" is front of lot number and replace
            'If cboLotNumber.Text.Length > 0 Then
            '    Select Case cboLotNumber.Text.Substring(0, 1).ToUpper
            '        Case "S"
            '            If cboLotNumber.Text.Length = 1 Then
            '                cboLotNumber.Text = ""
            '            Else
            '                cboLotNumber.Text = cboLotNumber.Text.Substring(1)
            '            End If
            '        Case Else
            '    End Select
            'End If

            LoadLotNumberData()
            LoadFOXData()
            If String.IsNullOrEmpty(txtCustomerID.Text) = False Then
                If txtCustomerID.Text <> "STOCK" Then
                    LoadCustomerName()
                Else
                    lblCustomerName.Text = ""
                End If
            End If
            If String.IsNullOrEmpty(txtPartNumber.Text) = False Then
                LoadPartData()
            End If
        End If
    End Sub

    Private Function shouldFindData() As Boolean
        If cboLotNumber.Text.Length < 8 Then
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        isClosing = False
        isLoaded = False
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub ClearRockwellData()
        isLoaded = False
        cboTestType.SelectedIndex = -1
        cboCoreHardness.SelectedIndex = -1
        dgvTestData.Rows.Clear()
        dgvTestData.Columns.Clear()
        setupRockTestDGV()
        isLoaded = True
    End Sub

    Public Sub ClearTemperingData()
        cboTemperingFurnace.SelectedIndex = -1
        cboFinishType.SelectedIndex = -1
        txtTemperingTemperature.Clear()
        txtTemperingTime.Clear()
        cboTemperingFurnace.Focus()
    End Sub

    Private Function canEnterTest() As Boolean
        If String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            MessageBox.Show("You must select a heat treat record number", "Enter a record number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If cboHeatTreatFileNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid heat treat record number", "Enter a valid record number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatFileNumber.SelectAll()
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If IsLocked() Then
            MessageBox.Show("Unable to Save, Heat Record has been locked", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboTestType.Text) Then
            MessageBox.Show("You must select a test type", "Select a test type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestType.Focus()
            Return False
        End If
        If cboTestType.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid test type", "Enter a valid test type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestType.SelectAll()
            cboTestType.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboCoreHardness.Text) Then
            MessageBox.Show("You must select a core hardness", "Select a core hardness", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoreHardness.Focus()
            Return False
        End If
        If cboCoreHardness.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid core hardness", "Enter a valid core hardness", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoreHardness.SelectAll()
            cboCoreHardness.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canDeleteRockwellTestData() As Boolean
        If String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            MessageBox.Show("You must have a Heat Treat File Number selected", "Enter a Heat Treat File Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If cboHeatTreatFileNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid heat treat record number", "Enter a valid record number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatFileNumber.SelectAll()
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboTestType.Text) Then
            MessageBox.Show("You must enter a test type", "Enter a test type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestType.Focus()
            Return False
        End If
        If cboTestType.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid test type to delete", "Enter a valid Test Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestType.SelectAll()
            cboTestType.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDeleteDrawData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If canDeleteDrawData() Then
            ''checks to see if the record exists before trying to delete it.
            cmd = New SqlCommand("IF EXISTS(SELECT HeatTreatRecordNumber FROM HeatTreatTemperatureDraw WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber AND TemperatureDrawNumber = @TemperatureDrawNumber) DELETE FROM HeatTreatTemperatureDraw WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber AND TemperatureDrawNumber = @TemperatureDrawNumber;", con)
            cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.Int).Value = Val(cboHeatTreatFileNumber.Text)
            cmd.Parameters.Add("@TemperatureDrawNumber", SqlDbType.Int).Value = nupTemperingNumber.Value
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            ClearTemperingData()
        End If
    End Sub

    Private Function canDeleteDrawData() As Boolean
        If String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            MessageBox.Show("You must have a Heat Treat File Number selected", "Enter a Heat Treat File Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If cboHeatTreatFileNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid heat treat record number", "Enter a valid record number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatFileNumber.SelectAll()
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If IsLocked() Then
            MessageBox.Show("Unable to delete, Heat Record has been locked", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub cmdViewLotNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewLotNumbers.Click
        Using NewViewLotNumbers As New ViewLotNumbers
            Dim result = NewViewLotNumbers.ShowDialog()
        End Using
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click, ClearDataToolStripMenuItem.Click
        Cleardata()
        IsLocked()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintDataToolStripMenuItem.Click
        Using NewPrintHeatTreatCert As New PrintHeatTreatCert(cboHeatTreatFileNumber.Text)
            Dim result = NewPrintHeatTreatCert.ShowDialog()
        End Using
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveDataToolStripMenuItem.Click
        If canSave() Then
            SaveDrawData()
            Try
                updateOrInsertIntoHeatTreatInspectionLog()
                MessageBox.Show("Data was saved sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                sendErrorToDataBase("HeatTreatDataForm - cmdSave_Click --Error trying to insert/update heat treat record in HeatTreatInspectionLog", "Record #" + cboHeatTreatFileNumber.Text, ex.ToString())
                MessageBox.Show("There was an error trying to save the data. Contact system admin", "Unable to complete save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            MsgBox("You must have a valid Heat Treat File Number selected.", MsgBoxStyle.OkOnly)
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If cboHeatTreatFileNumber.SelectedIndex = -1 Then
            MessageBox.Show("You muse enter a valid record number", "Enter a valid record number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatFileNumber.SelectAll()
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If IsLocked() Then
            MessageBox.Show("Unable to Save, Heat Record has been locked", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(txtWeightPerLoad.Text) Then
            MessageBox.Show("You must have a weight per load entered", "Enter a weight per load", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWeightPerLoad.Focus()
            Return False
        End If
        If IsNumeric(txtWeightPerLoad.Text) = False Then
            MessageBox.Show("You must enter a number for weight per load", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWeightPerLoad.SelectAll()
            txtWeightPerLoad.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must enter a valid lot number", "Enter a valid lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtFinishedDiameter.Text) = False Then
            If IsNumeric(txtFinishedDiameter.Text) = False Then
                MessageBox.Show("You must enter a number for finished diameter", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFinishedDiameter.SelectAll()
                txtFinishedDiameter.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(cboEmployeeShift.Text) Then
            If cboEmployeeShift.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid shift number", "Enter a valid shift number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboEmployeeShift.SelectAll()
                cboEmployeeShift.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtOperatorName.Text) Then
            MessageBox.Show("You must enter an operator name", "Enter a name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOperatorName.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(cboProcessType.Text) Then
            If cboProcessType.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid process type", "Enter a valid process type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboProcessType.SelectAll()
                cboProcessType.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(cboProgramNumber.Text) And (cboFurnaceSelection.Text.ToLower.Equals("allcase1") Or cboFurnaceSelection.Text.ToLower.Equals("allcase2")) Then
            MessageBox.Show("You must enter a valid program number", "Enter a valid program number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProgramNumber.SelectAll()
            cboProgramNumber.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(cboFurnaceSelection.Text) Then
            If cboFurnaceSelection.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid furnace", "Enter a valid furnace", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboFurnaceSelection.SelectAll()
                cboFurnaceSelection.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(cboQuenchType.Text) Then
            If cboQuenchType.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid quench", "Enter a valid quench", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboQuenchType.SelectAll()
                cboQuenchType.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtQuenchTemperature.Text) Then
                MessageBox.Show("You must enter a Quench initial temperature", "Enter a Quench initial temp", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQuenchTemperature.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtAustenizingTemperature.Text) Then
            If Not String.IsNullOrEmpty(txtAustenizingTime.Text) Then
                If txtAustenizingTime.Text.Contains(":") Then
                    Dim spl As String() = txtAustenizingTime.Text.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                    For i As Integer = 0 To spl.Count - 1
                        If Not IsNumeric(spl(i)) Then
                            MessageBox.Show("You must enter an Austenizing Time", "Enter an Austenizing Time", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtAustenizingTime.SelectAll()
                            txtAustenizingTime.Focus()
                            Return False
                        End If
                    Next
                Else
                    If IsNumeric(txtAustenizingTime.Text) = False Then
                        MessageBox.Show("You must enter an Austenizing Time", "Enter an Austenizing Time", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtAustenizingTime.SelectAll()
                        txtAustenizingTime.Focus()
                        Return False
                    End If
                End If
            End If
        End If
        If Not String.IsNullOrEmpty(txtAustenizingTime.Text) Then
            If String.IsNullOrEmpty(txtAustenizingTemperature.Text) Then
                MessageBox.Show("You must enter an austenizing temperature", "Enter and austenizing temperature", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAustenizingTemperature.Focus()
                Return False
            End If
            If txtAustenizingTime.Text.Contains(":") Then
                Dim spl As String() = txtAustenizingTime.Text.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                For i As Integer = 0 To spl.Count - 1
                    If Not IsNumeric(spl(i)) Then
                        MessageBox.Show("You must enter an Austenizing Time", "Enter an Austenizing Time", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtAustenizingTime.SelectAll()
                        txtAustenizingTime.Focus()
                        Return False
                    End If
                Next
            Else
                If Not IsNumeric(txtAustenizingTime.Text) Then
                    MessageBox.Show("You must enter an Austenizing Time", "Enter an Austenizing Time", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAustenizingTime.SelectAll()
                    txtAustenizingTime.Focus()
                    Return False
                End If
            End If
        End If
        If String.IsNullOrEmpty(txtBatchNumber.Text) Then
            MessageBox.Show("You must enter the Lot/Batch Number", "Enter the Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBatchNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdGenerateNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNext.Click
        isLoaded = False
        Cleardata()
        Dim nextKey As Integer = 0
        cmd = New SqlCommand("BEGIN TRAN DECLARE @key as int = (SELECT isnull(MAX(HeatTreatRecordNumber) + 1, 6200000) FROM HeatTreatInspectionLog); INSERT INTO HeatTreatInspectionLog(HeatTreatRecordNumber, WeightPerLoad, DivisionID)VALUES(@key, 0, @DivisionID); SELECT @key; commit tran;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            nextKey = cmd.ExecuteScalar()
            con.Close()
        Catch ex As Exception
            con.Close()
            sendErrorToDataBase("HeatTreatDataForm - cmdGenerateNext_Click --Error trying to generate new heat treat record number", "Heat treat record #" + nextKey.ToString(), ex.ToString())
            MessageBox.Show("Unable to generate a new heat treat record number. Contact system admin", "Unable to generate new record number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        LoadHeatTreatFileNumber()
        cboHeatTreatFileNumber.Text = nextKey.ToString()

        txtScanLotNumber.Focus()

        isLoaded = True
    End Sub

    Private Sub cmdViewHeatTreatLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewHeatTreatLog.Click
        Using NewViewHeatTreatInspectionLog As New ViewHeatTreatInspectionLog
            Dim result = NewViewHeatTreatInspectionLog.ShowDialog()
        End Using
    End Sub

    Private Sub cmdViewHeatNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewHeatNumbers.Click
        Using NewViewHeatNumberLog As New ViewHeatNumberLog
            Dim result = NewViewHeatNumberLog.ShowDialog()
        End Using
    End Sub

    Private Sub cboHeatTreatFileNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatTreatFileNumber.SelectedIndexChanged
        If isLoaded Then
            isLoaded = False
            Dim heatFile As String = cboHeatTreatFileNumber.Text
            Cleardata()
            dgvTestData.Rows.Clear()
            dgvTestData.Columns.Clear()
            setupRockTestDGV()
            cboHeatTreatFileNumber.Text = heatFile
            isLoaded = True
            LoadHeatFileData()
            If cboLotNumber.Text.Contains("-") Then
                LoadLotNumberData()
            End If
            If Not String.IsNullOrEmpty(txtPartNumber.Text) Then
                LoadPartData()
            End If
            If Not String.IsNullOrEmpty(txtCustomerID.Text) Then
                If txtCustomerID.Text <> "STOCK" Then
                    LoadCustomerName()
                Else
                    lblCustomerName.Text = ""
                End If
            End If

            cboTestType.SelectedIndex = 0
            getTemperingDrawData()
            LoadRockwellTotals()
            IsLocked()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteDataToolStripMenuItem.Click
        If canDelete() Then
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete Heat Treat File Number?", "Delete Heat Treat File Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Create command to Delete Test Data from Database
                cmd = New SqlCommand("DELETE FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber;", con)
                cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = Val(cboHeatTreatFileNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Cleardata()
                isLoaded = False
                LoadHeatTreatFileNumber()
                isLoaded = True
            End If
        End If
    End Sub

    Private Function canDelete() As Boolean
        If String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            MessageBox.Show("You must select a record number", "Select a record number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If cboHeatTreatFileNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid record number", "Enter a valid record number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatFileNumber.SelectAll()
            cboHeatTreatFileNumber.Focus()
            Return False
        End If
        If IsLocked() Then
            MessageBox.Show("Unable to delete, Heat Record has been locked", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

        'Write to database
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub updateOrInsertIntoHeatTreatInspectionLog(Optional ByVal status As String = "OPEN")
        ''checks to see if it exists already, if so will update if not will insert
        cmd = New SqlCommand("IF EXISTS(SELECT BatchNumber FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber) UPDATE HeatTreatInspectionLog SET HeatNumber = @HeatNumber, FOXNumber = @FOXNumber, LotNumber = @LotNumber, RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), AnnealLotNumber = @AnnealLotNumber, Signoff1 = @Signoff1, Signoff2 = @Signoff2, Signoff3 = @Signoff3, FinishDiameter = @FinishDiameter, WeightPerLoad = @WeightPerLoad, ProcessDescription = @ProcessDescription, ProgramDescription = @ProgramDescription, BlueprintNumber = @BlueprintNumber, CreationDate = @CreationDate, Comments = @Comments, AustenizingFurnace = @AustenizingFurnace, AustenizingTemperature = @AustenizingTemperature, AustenizingTime = @AustenizingTime, DivisionID = @DivisionID, CustomerID = @CustomerID, PartNumber = @PartNumber, OperatorName = @OperatorName, Shift = @Shift, QuenchType = @QuenchType, QuenchTemperature = @QuenchTemperature, BatchNumber = @BatchNumber, Status = @Status WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber ELSE Insert Into HeatTreatInspectionLog(HeatTreatRecordNumber, HeatNumber, FOXNumber, LotNumber, RMID, AnnealLotNumber, Signoff1, Signoff2, Signoff3, FinishDiameter, WeightPerLoad, ProcessDescription, ProgramDescription, BlueprintNumber, CreationDate, Comments, AustenizingFurnace, AustenizingTemperature, AustenizingTime, DivisionID, CustomerID, PartNumber, OperatorName, Shift, QuenchType, QuenchTemperature, BatchNumber, Status)Values(@HeatTreatRecordNumber, @HeatNumber, @FOXNumber, @LotNumber, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @AnnealLotNumber, @Signoff1, @Signoff2, @Signoff3, @FinishDiameter, @WeightPerLoad, @ProcessDescription, @ProgramDescription, @BlueprintNumber, @CreationDate, @Comments, @AustenizingFurnace, @AustenizingTemperature, @AustenizingTime, @DivisionID, @CustomerID, @PartNumber, @OperatorName, @Shift, @QuenchType, @QuenchTemperature, @BatchNumber, @Status);", con)

        With cmd.Parameters
            .Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = Val(cboHeatTreatFileNumber.Text)
            .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
            .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(txtFOXNumber.Text)
            .Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
            .Add("@Carbon", SqlDbType.VarChar).Value = txtCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSize.Text
            .Add("@AnnealLotNumber", SqlDbType.VarChar).Value = txtAnnealLot.Text
            .Add("@Signoff1", SqlDbType.VarChar).Value = txtInsp1.Text
            .Add("@Signoff2", SqlDbType.VarChar).Value = txtInsp2.Text
            .Add("@Signoff3", SqlDbType.VarChar).Value = txtInsp3.Text
            .Add("@FinishDiameter", SqlDbType.VarChar).Value = Val(txtFinishedDiameter.Text)
            .Add("@WeightPerLoad", SqlDbType.VarChar).Value = Val(txtWeightPerLoad.Text)
            .Add("@ProcessDescription", SqlDbType.VarChar).Value = cboProcessType.Text
            .Add("@ProgramDescription", SqlDbType.VarChar).Value = cboProgramNumber.Text
            .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text
            .Add("@CreationDate", SqlDbType.VarChar).Value = dtpRecordDate.Text
            .Add("@Comments", SqlDbType.VarChar).Value = txtComments.Text
            .Add("@AustenizingFurnace", SqlDbType.VarChar).Value = cboFurnaceSelection.Text
            .Add("@AustenizingTemperature", SqlDbType.VarChar).Value = txtAustenizingTemperature.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
            .Add("@OperatorName", SqlDbType.VarChar).Value = txtOperatorName.Text
            .Add("@Shift", SqlDbType.VarChar).Value = Val(cboEmployeeShift.Text)
            .Add("@QuenchType", SqlDbType.VarChar).Value = cboQuenchType.Text
            .Add("@QuenchTemperature", SqlDbType.VarChar).Value = txtQuenchTemperature.Text
            .Add("@BatchNumber", SqlDbType.VarChar).Value = txtBatchNumber.Text
            .Add("@Status", SqlDbType.VarChar).Value = status
        End With

        If txtAustenizingTime.Text.Contains(":") Then
            cmd.Parameters.Add("@AustenizingTime", SqlDbType.VarChar).Value = Val(txtAustenizingTime.Text).ToString()
        ElseIf Not String.IsNullOrEmpty(txtAustenizingTime.Text) Then
            cmd.Parameters.Add("@AustenizingTime", SqlDbType.VarChar).Value = Val(txtAustenizingTime.Text).ToString() + ":00"
        Else
            cmd.Parameters.Add("@AustenizingTime", SqlDbType.VarChar).Value = ""
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cboLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.TextChanged
        If cboLotNumber.Text.Length > 1 And cboLotNumber.Text.Length < 3 Then
            If cboLotNumber.Text.ElementAt(0) = "s" Then
                cboLotNumber.Text = cboLotNumber.Text.Substring(1, cboLotNumber.Text.Length - 1)
                cboLotNumber.Select(cboLotNumber.Text.Length, 0)
            End If
        End If
    End Sub

    Private Sub nupTemperingNumber_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupTemperingNumber.ValueChanged
        If shouldGetDrawTestData() Then
            getTemperingDrawData()
        End If
    End Sub

    Private Function shouldGetDrawTestData() As Boolean
        If isLoaded = False Then
            Return False
        End If
        If String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            Return False
        End If
        If cboHeatTreatFileNumber.SelectedIndex = -1 Then
            Return False
        End If
        Return True
    End Function

    Private Sub getTemperingDrawData()
        Dim tim As String = ""
        cmd = New SqlCommand("SELECT TemperingTemperature, TemperingTime, TemperingType, FinishType FROM HeatTreatTemperatureDraw WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber AND TemperatureDrawNumber = @TemperatureDrawNumber;", con)
        cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = cboHeatTreatFileNumber.Text
        cmd.Parameters.Add("@TemperatureDrawNumber", SqlDbType.Int).Value = nupTemperingNumber.Value

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("TemperingTemperature")) Then
                txtTemperingTemperature.Text = ""
            Else
                txtTemperingTemperature.Text = reader.Item("TemperingTemperature")
            End If
            If Not IsDBNull(reader.Item("TemperingTime")) Then
                tim = reader.Item("TemperingTime")
            End If
            If IsDBNull(reader.Item("TemperingType")) Then
                cboTemperingFurnace.SelectedIndex = -1
            Else
                cboTemperingFurnace.Text = reader.Item("TemperingType")
            End If
            If IsDBNull(reader.Item("FinishType")) Then
                cboFinishType.SelectedIndex = 0
            Else
                cboFinishType.Text = reader.Item("FinishType")
            End If
        Else
            txtTemperingTemperature.Text = ""
            tim = ""
            cboTemperingFurnace.SelectedIndex = -1
            cboFinishType.SelectedIndex = 0
        End If
        reader.Close()
        con.Close()
        txtTemperingTime.Text = tim
    End Sub

    Private Sub getRockwellTestData()
        cmd = New SqlCommand("SELECT Test1, Test2, Test3, Test4, LineAverage, CoreHardnessScale FROM HeatTreatRockwellTest WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber AND TestType = @TestType;", con)
        cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = cboHeatTreatFileNumber.Text
        cmd.Parameters.Add("@TestType", SqlDbType.VarChar).Value = cboTestType.Text
        Dim rockDS As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(rockDS, "HeatTreatRockwellTest")
        con.Close()

        If rockDS.Tables("HeatTreatRockwellTest").Rows.Count > 0 Then
            cboCoreHardness.Text = rockDS.Tables("HeatTreatRockwellTest").Rows(0).Item("CoreHardnessScale")
        End If
        Dim lowAvg As Double = Double.MaxValue
        Dim highAvg As Double = Double.MinValue
        Dim total As Double = 0D
        Dim testsAdded As Integer = 0
        Dim sampAdded As Integer = 0
        ''goes through all the samples and will calculate the average and put the test results in the proper location
        For i As Integer = 0 To rockDS.Tables("HeatTreatRockwellTest").Rows.Count - 1
            Dim SampTotal As Double = 0D

            If rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("Test1") <> 0 Then
                dgvTestData.Rows(0).Cells(i).Value = rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("Test1").ToString()
            End If
            If rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("Test2") <> 0 Then
                dgvTestData.Rows(1).Cells(i).Value = rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("Test2").ToString()
            End If
            If rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("Test3") <> 0 Then
                dgvTestData.Rows(2).Cells(i).Value = rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("Test3").ToString()
            End If
            If rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("Test4") <> 0 Then
                dgvTestData.Rows(3).Cells(i).Value = rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("Test4").ToString()
            End If

            If rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("LineAverage") <> 0 Then
                SampTotal = rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("LineAverage")
            End If

            total += SampTotal
            If lowAvg > SampTotal And SampTotal > 0 Then
                lowAvg = SampTotal
            End If
            If highAvg < SampTotal And SampTotal > 0 Then
                highAvg = SampTotal
            End If
            If SampTotal > 0 Then
                sampAdded += 1
                dgvTestData.Rows(4).Cells(i).Value = Math.Round(SampTotal, 5, MidpointRounding.AwayFromZero)
            End If
        Next
    End Sub

    Private Sub setupRockTestDGV()
        dgvTestData.Columns.Add("Sample1", "Sample 1")
        dgvTestData.Columns("Sample1").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        dgvTestData.Columns.Add("Sample2", "Sample 2")
        dgvTestData.Columns("Sample2").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        dgvTestData.Columns.Add("Sample3", "Sample 3")
        dgvTestData.Columns("Sample3").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        dgvTestData.Columns.Add("Sample4", "Sample 4")
        dgvTestData.Columns("Sample4").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        dgvTestData.Rows.Add(5)
        dgvTestData.Rows(0).HeaderCell.Value = "Test 1"
        dgvTestData.Rows(1).HeaderCell.Value = "Test 2"
        dgvTestData.Rows(2).HeaderCell.Value = "Test 3"
        dgvTestData.Rows(3).HeaderCell.Value = "Test 4"
        dgvTestData.Rows(4).HeaderCell.Value = "Average"
        dgvTestData.Rows(4).ReadOnly = True
    End Sub

    Private Sub cboTestType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTestType.SelectedIndexChanged
        If isLoaded And cboTestType.SelectedIndex <> -1 Then
            isLoaded = False
            dgvTestData.Rows.Clear()
            dgvTestData.Columns.Clear()
            setupRockTestDGV()
            getRockwellTestData()
            isLoaded = True
        End If
    End Sub

    Private Sub dgvTestData_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTestData.CellValueChanged
        If canSaveRockwellTestData() Then
            ''SQL will see if the test entry exists if not will add it in
            cmd = New SqlCommand("IF NOT EXISTS(SELECT * FROM HeatTreatRockwellTest WHERE SampleNumber = @SampleNumber AND HeatTreatRecordNumber = @HeatTreatRecordNumber AND TestType = @TestType) INSERT INTO HeatTreatRockwellTest (HeatTreatRecordNumber, TestType, SampleNumber, Test1, Test2, Test3, Test4, LineAverage, CoreHardnessScale) VALUES (@HeatTreatRecordNumber, @TestType, @SampleNumber, @Test0, @Test1, @Test2, @Test3, @LineAverage, @CoreHardnessScale) ELSE UPDATE HeatTreatRockwellTest SET Test1 = @Test0, Test2 = @Test1, Test3 = @Test2, Test4 = @Test3, LineAverage = @LineAverage WHERE SampleNumber = @SampleNumber AND HeatTreatRecordNumber = @HeatTreatRecordNumber AND TestType = @TestType;", con)
            cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.Int).Value = Val(cboHeatTreatFileNumber.Text)
            cmd.Parameters.Add("@CoreHardnessScale", SqlDbType.VarChar).Value = cboCoreHardness.Text
            cmd.Parameters.Add("@TestType", SqlDbType.VarChar).Value = cboTestType.Text

            Select Case dgvTestData.Columns(e.ColumnIndex).HeaderCell.Value
                Case "Sample 1"
                    cmd.Parameters.Add("@SampleNumber", SqlDbType.Int).Value = 1
                Case "Sample 2"
                    cmd.Parameters.Add("@SampleNumber", SqlDbType.Int).Value = 2
                Case "Sample 3"
                    cmd.Parameters.Add("@SampleNumber", SqlDbType.Int).Value = 3
                Case "Sample 4"
                    cmd.Parameters.Add("@SampleNumber", SqlDbType.Int).Value = 4
            End Select

            Dim entries As Integer = 0
            Dim total As Double = 0D
            ''goes through all the lines and will average the tests so that the data is all correct
            For i As Integer = 0 To 3
                If dgvTestData.Rows(i).Cells(e.ColumnIndex).Value IsNot Nothing Then
                    If Val(dgvTestData.Rows(i).Cells(e.ColumnIndex).Value) <> 0 Then
                        total += Val(dgvTestData.Rows(i).Cells(e.ColumnIndex).Value)
                        entries += 1
                    End If
                    cmd.Parameters.Add("@Test" + i.ToString(), SqlDbType.Float).Value = Val(dgvTestData.Rows(i).Cells(e.ColumnIndex).Value)
                Else
                    cmd.Parameters.Add("@Test" + i.ToString(), SqlDbType.Float).Value = 0
                End If
            Next
            If total = 0 Then
                cmd.Parameters.Add("@LineAverage", SqlDbType.Float).Value = 0
            Else
                cmd.Parameters.Add("@LineAverage", SqlDbType.Float).Value = Math.Round(total / entries, 5, MidpointRounding.AwayFromZero)
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            isLoaded = False
            dgvTestData.Rows.Clear()
            dgvTestData.Columns.Clear()
            setupRockTestDGV()
            getRockwellTestData()
            LoadRockwellTotals()
            isLoaded = True
            If e.RowIndex = 3 And e.ColumnIndex <> 3 Then
                dgvTestData.CurrentCell = dgvTestData.Rows(0).Cells(e.ColumnIndex + 1)
            ElseIf e.RowIndex = 3 And e.ColumnIndex = 3 Then
                dgvTestData.CurrentCell = dgvTestData.Rows(0).Cells(e.ColumnIndex)
            Else
                dgvTestData.CurrentCell = dgvTestData.Rows(e.RowIndex + 1).Cells(e.ColumnIndex)
            End If
        End If
    End Sub

    Private Function canSaveRockwellTestData() As Boolean
        If Not isLoaded Then
            Return False
        End If
        If String.IsNullOrEmpty(cboTestType.Text) Then
            MessageBox.Show("You must select a test type before entering values", "Unable to enter data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestType.Focus()
            Return False
        End If
        If cboTestType.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid Test Type", "Select a valid TestType", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestType.SelectAll()
            cboTestType.Focus()
            Return False
        End If
        If IsLocked() Then
            MessageBox.Show("Unable to Save, Heat Record has been locked", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub LoadRockwellTotals()
        cmd = New SqlCommand("SELECT LineAverage, TestType FROM HeatTreatRockwellTest WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber Order BY TestType;", con)
        cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = cboHeatTreatFileNumber.Text
        Dim rockDS As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(rockDS, "HeatTreatRockwellTest")
        con.Close()

        Dim lowAvg As Double = Double.MaxValue
        Dim highAvg As Double = Double.MinValue
        Dim total As Double = 0D
        Dim testsAdded As Integer = 0
        Dim sampAdded As Integer = 0
        Dim currentTestType As String = ""

        If rockDS.Tables("HeatTreatRockwellTest").Rows.Count > 0 Then
            currentTestType = rockDS.Tables("HeatTreatRockwellTest").Rows(0).Item("TestType")
        End If

        ''goes through all the samples and will calculate the average and put the test results in the proper location
        For i As Integer = 0 To rockDS.Tables("HeatTreatRockwellTest").Rows.Count - 1
            If Not currentTestType.Equals(rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("TestType")) Then
                Select Case currentTestType
                    Case "Core Scale"
                        ''fills the min max and average test result textboxes
                        If lowAvg <> Double.MaxValue Then
                            txtCoreScaleLow.Text = Math.Round(lowAvg, 5, MidpointRounding.AwayFromZero).ToString()
                        End If
                        If highAvg <> Double.MinValue Then
                            txtCoreScaleHigh.Text = Math.Round(highAvg, 5, MidpointRounding.AwayFromZero).ToString()
                        End If
                        If total <> 0 Then
                            txtCoreScaleMean.Text = Math.Round(total / sampAdded, 5, MidpointRounding.AwayFromZero)
                        End If
                    Case "Surface Scale 1"
                        ''fills the min max and average test result textboxes
                        If lowAvg <> Double.MaxValue Then
                            txtSurfaceScale1Low.Text = Math.Round(lowAvg, 5, MidpointRounding.AwayFromZero).ToString()
                        End If
                        If highAvg <> Double.MinValue Then
                            txtSurfaceScale1High.Text = Math.Round(highAvg, 5, MidpointRounding.AwayFromZero).ToString()
                        End If
                        If total <> 0 Then
                            txtSurfaceScale1Mean.Text = Math.Round(total / sampAdded, 5, MidpointRounding.AwayFromZero)
                        End If
                    Case "Surface Scale 2"
                        ''fills the min max and average test result textboxes
                        If lowAvg <> Double.MaxValue Then
                            txtSurfaceScale2Low.Text = Math.Round(lowAvg, 5, MidpointRounding.AwayFromZero).ToString()
                        End If
                        If highAvg <> Double.MinValue Then
                            txtSurfaceScale2High.Text = Math.Round(highAvg, 5, MidpointRounding.AwayFromZero).ToString()
                        End If
                        If total <> 0 Then
                            txtSurfaceScale2Mean.Text = Math.Round(total / sampAdded, 5, MidpointRounding.AwayFromZero)
                        End If
                End Select
                lowAvg = Double.MaxValue
                highAvg = Double.MinValue
                total = 0D
                sampAdded = 0
                currentTestType = rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("TestType")
            End If
            Dim SampTotal As Double = 0
            If rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("LineAverage") <> 0 Then
                SampTotal = rockDS.Tables("HeatTreatRockwellTest").Rows(i).Item("LineAverage")
            End If
            total += SampTotal
            If lowAvg > SampTotal And SampTotal > 0 Then
                lowAvg = SampTotal
            End If
            If highAvg < SampTotal And SampTotal > 0 Then
                highAvg = SampTotal
            End If
            If SampTotal > 0 Then
                sampAdded += 1
            End If
        Next
        Select Case currentTestType
            Case "Core Scale"
                ''fills the min max and average test result textboxes
                If lowAvg <> Double.MaxValue Then
                    txtCoreScaleLow.Text = Math.Round(lowAvg, 5, MidpointRounding.AwayFromZero).ToString()
                End If
                If highAvg <> Double.MinValue Then
                    txtCoreScaleHigh.Text = Math.Round(highAvg, 5, MidpointRounding.AwayFromZero).ToString()
                End If
                If total <> 0 Then
                    txtCoreScaleMean.Text = Math.Round(total / sampAdded, 5, MidpointRounding.AwayFromZero)
                End If
            Case "Surface Scale 1"
                ''fills the min max and average test result textboxes
                If lowAvg <> Double.MaxValue Then
                    txtSurfaceScale1Low.Text = Math.Round(lowAvg, 5, MidpointRounding.AwayFromZero).ToString()
                End If
                If highAvg <> Double.MinValue Then
                    txtSurfaceScale1High.Text = Math.Round(highAvg, 5, MidpointRounding.AwayFromZero).ToString()
                End If
                If total <> 0 Then
                    txtSurfaceScale1Mean.Text = Math.Round(total / sampAdded, 5, MidpointRounding.AwayFromZero)
                End If
            Case "Surface Scale 2"
                ''fills the min max and average test result textboxes
                If lowAvg <> Double.MaxValue Then
                    txtSurfaceScale2Low.Text = Math.Round(lowAvg, 5, MidpointRounding.AwayFromZero).ToString()
                End If
                If highAvg <> Double.MinValue Then
                    txtSurfaceScale2High.Text = Math.Round(highAvg, 5, MidpointRounding.AwayFromZero).ToString()
                End If
                If total <> 0 Then
                    txtSurfaceScale2Mean.Text = Math.Round(total / sampAdded, 5, MidpointRounding.AwayFromZero)
                End If
        End Select

    End Sub

    Private Sub cmdLockRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLockRecord.Click
        If canLockRecord() Then
            updateOrInsertIntoHeatTreatInspectionLog("LOCKED")
            IsLocked()
        End If
    End Sub

    Private Function canLockRecord() As Boolean
        If Not isLoaded Then
            Return False
        End If
        If String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            MessageBox.Show("You must select a Heat Record to lock", "Unable to lock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboHeatTreatFileNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Heat Record to lock.", "Enter a valid Heat Record", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(txtInsp1.Text) Then
            MessageBox.Show("You must enter at least 1 inspector", "Enter an inspector", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInsp1.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function IsLocked() As Boolean
        cmd = New SqlCommand("if exists(SELECT Status FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber) SELECT isnull(Status, 'OPEN') as Status FROM HeatTreatInspectionLog WHERE HEatTreatRecordNumber = @HeatTreatRecordNumber ELSE SELECT 'OPEN' as Status;", con)
        cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.Int).Value = Val(cboHeatTreatFileNumber.Text)
        Dim status As String = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            status = reader.Item("Status")
        End If
        reader.Close()
        con.Close()

        If status.Equals("OPEN") Then
            dtpRecordDate.Enabled = True
            cboLotNumber.Enabled = True
            txtAnnealLot.Enabled = True
            cboDivisionID.Enabled = True
            txtComments.Enabled = True
            txtInsp1.Enabled = True
            txtInsp2.Enabled = True
            txtInsp3.Enabled = True
            grpxProcessData.Enabled = True
            cboTemperingFurnace.Enabled = True
            cboFinishType.Enabled = True
            txtTemperingTemperature.Enabled = True
            txtTemperingTime.Enabled = True
            cboCoreHardness.Enabled = True
            dgvTestData.Enabled = True
            cmdSave.Enabled = True
            cmdDelete.Enabled = True
            cmdLockRecord.Enabled = True
            Return False
        Else
            dtpRecordDate.Enabled = False
            cboLotNumber.Enabled = False
            txtAnnealLot.Enabled = False
            cboDivisionID.Enabled = False
            txtComments.Enabled = False
            txtInsp1.Enabled = False
            txtInsp2.Enabled = False
            txtInsp3.Enabled = False
            grpxProcessData.Enabled = False
            cboTemperingFurnace.Enabled = False
            cboFinishType.Enabled = False
            txtTemperingTemperature.Enabled = False
            txtTemperingTime.Enabled = False
            cboCoreHardness.Enabled = False
            dgvTestData.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdLockRecord.Enabled = False
            Return True
        End If
    End Function

    Private Sub txtAustenizingTime_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAustenizingTime.Leave
        If Not String.IsNullOrEmpty(txtAustenizingTime.Text) Then
            If txtAustenizingTime.Text.Contains(":") Then
                Dim sep() As String = txtAustenizingTime.Text.Split(New String() {":"}, StringSplitOptions.None)
                If sep(0).Length < 2 Then
                    While sep(0).Length < 2
                        sep(0) = "0" + sep(0)
                    End While
                End If
                If sep(1).Length < 2 Then
                    While sep(1).Length < 2
                        sep(1) = "0" + sep(1)
                    End While
                End If
                txtAustenizingTime.Text = sep(0) + ":" + sep(1)
            Else
                If txtAustenizingTime.Text.Length = 1 Then
                    txtAustenizingTime.Text = "0" + txtAustenizingTime.Text + ":00"
                Else
                    txtAustenizingTime.Text += ":00"
                End If
            End If
        Else
            If Not String.IsNullOrEmpty(txtAustenizingTemperature.Text) Then
                txtAustenizingTime.Text = "00:00"
            End If
        End If
    End Sub

    Private Sub txtTemperingTime_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTemperingTime.Leave
        If Not String.IsNullOrEmpty(txtTemperingTime.Text) Then
            If txtTemperingTime.Text.Contains(":") Then
                Dim sep() As String = txtTemperingTime.Text.Split(New String() {":"}, StringSplitOptions.None)
                If sep(0).Length < 2 Then
                    While sep(0).Length < 2
                        sep(0) = "0" + sep(0)
                    End While
                End If
                If sep(1).Length < 2 Then
                    While sep(1).Length < 2
                        sep(1) = "0" + sep(1)
                    End While
                End If
                txtTemperingTime.Text = sep(0) + ":" + sep(1)
            Else
                If txtTemperingTime.Text.Length = 1 Then
                    txtTemperingTime.Text = "0" + txtTemperingTime.Text + ":00"
                Else
                    txtTemperingTime.Text += ":00"
                End If
            End If
        Else
            txtTemperingTime.Text += "00:00"
        End If
        If canEnterTemp() Then
            SaveDrawData()
        End If
    End Sub

    Private Sub dgvTestData_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvTestData.SelectionChanged
        If isLoaded Then
            If dgvTestData.SelectedCells.Contains(dgvTestData.Rows(4).Cells(1)) Then
                dgvTestData.Rows(0).Cells(1).Selected = True
            ElseIf dgvTestData.SelectedCells.Contains(dgvTestData.Rows(4).Cells(2)) Then
                dgvTestData.Rows(0).Cells(2).Selected = True
            ElseIf dgvTestData.SelectedCells.Contains(dgvTestData.Rows(4).Cells(3)) Then
                dgvTestData.Rows(0).Cells(3).Selected = True
            End If

        End If
    End Sub

    Private Sub UnLockRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockRecordToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            If cboHeatTreatFileNumber.SelectedIndex <> -1 Then
                cmd = New SqlCommand("UPDATE HeatTreatInspectionLog SET Status = 'OPEN' WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
                cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.Int).Value = Val(cboHeatTreatFileNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Enable fields to be edited
                dtpRecordDate.Enabled = True
                cboLotNumber.Enabled = True
                txtAnnealLot.Enabled = True
                cboDivisionID.Enabled = True
                txtComments.Enabled = True
                txtInsp1.Enabled = True
                txtInsp2.Enabled = True
                txtInsp3.Enabled = True
                grpxProcessData.Enabled = True
                cboTemperingFurnace.Enabled = True
                cboFinishType.Enabled = True
                txtTemperingTemperature.Enabled = True
                txtTemperingTime.Enabled = True
                cboCoreHardness.Enabled = True
                dgvTestData.Enabled = True
                cmdSave.Enabled = True
                cmdDelete.Enabled = True
                cmdLockRecord.Enabled = True
            End If
        End If
    End Sub

    Private Sub cboTemperingFurnace_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTemperingFurnace.Leave
        If canEnterTemp() And Not String.IsNullOrEmpty(cboTemperingFurnace.Text) Then
            SaveDrawData()
        End If
    End Sub

    Private Sub SaveDrawData()
        Try
            'Create command to UPDATE Test Data into Database
            cmd = New SqlCommand("IF EXISTS(SELECT HeatTreatRecordNumber FROM HeatTreatTemperatureDraw WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber AND TemperatureDrawNumber = @TemperatureDrawNumber) UPDATE HeatTreatTemperatureDraw SET TemperingTemperature = @TemperingTemperature, TemperingTime = @TemperingTime, TemperingType = @TemperingType, FinishType = @FinishType WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber AND TemperatureDrawNumber = @TemperatureDrawNumber ELSE INSERT INTO HeatTreatTemperatureDraw(HeatTreatRecordNumber, TemperatureDrawNumber, TemperingTemperature, TemperingTime, TemperingType, FinishType)Values(@HeatTreatRecordNumber, @TemperatureDrawNumber, @TemperingTemperature, @TemperingTime, @TemperingType, @FinishType);", con)

            With cmd.Parameters
                .Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = Val(cboHeatTreatFileNumber.Text)
                .Add("@TemperatureDrawNumber", SqlDbType.VarChar).Value = nupTemperingNumber.Value
                .Add("@TemperingTemperature", SqlDbType.VarChar).Value = txtTemperingTemperature.Text
                .Add("@TemperingType", SqlDbType.VarChar).Value = cboTemperingFurnace.Text
                .Add("@FinishType", SqlDbType.VarChar).Value = cboFinishType.Text
            End With

            If txtTemperingTime.Text.Contains(":") Then
                cmd.Parameters.Add("@TemperingTime", SqlDbType.VarChar).Value = txtTemperingTime.Text.ToString()
            Else
                cmd.Parameters.Add("@TemperingTime", SqlDbType.VarChar).Value = txtTemperingTime.Text + ":00"
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            sendErrorToDataBase("HeatTreatDataForm - cmdEnterTemp_Click --Error triyng to insert/update TemperatureDrawNumber in HeatTreatTemperaturDraw", "Record #" + cboHeatTreatFileNumber.Text, ex.ToString())
            MessageBox.Show("There was an error trying to save the temperature draw data. Contact system admin", "Error unable to complete save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
    End Sub

    Private Function canEnterTemp() As Boolean
        If String.IsNullOrEmpty(cboHeatTreatFileNumber.Text) Then
            Return False
        End If
        If cboHeatTreatFileNumber.SelectedIndex = -1 Then
            Return False
        End If
        If IsLocked() Then
            Return False
        End If
        Return True
    End Function

    Private Sub cboFinishType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFinishType.Leave
        If canEnterTemp() And Not String.IsNullOrEmpty(cboFinishType.Text) Then
            SaveDrawData()
        End If
    End Sub

    Private Sub txtTemperingTemperature_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTemperingTemperature.Leave
        If canEnterTemp() And Not String.IsNullOrEmpty(txtTemperingTemperature.Text) Then
            SaveDrawData()
        End If
    End Sub

    Private Sub txtWeightPerLoad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWeightPerLoad.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub cboEmployeeShift_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEmployeeShift.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtScanLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanLotNumber.TextChanged
        'txtSerialLotNumber.Text = ""
        If txtScanLotNumber.Text.Length > 0 Then
            Select Case txtScanLotNumber.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScanLotNumber.Text.Length = 1 Then
                        txtScanLotNumber.Text = ""
                    Else
                        cboLotNumber.Text = txtScanLotNumber.Text.Substring(1)
                    End If

                Case Else
                    cboLotNumber.Text = txtScanLotNumber.Text
            End Select
        End If
    End Sub
End Class