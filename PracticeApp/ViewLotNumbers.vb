Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ViewLotNumbers
    Inherits System.Windows.Forms.Form

    Dim HeatFilter, LotFilter, PartFilter, VendorFilter, FOXFilter, BlueprintFilter, CarbonFilter, SteelSizeFilter As String
    Dim FOXNumber As Integer
    Dim strFOXNumber As String
    Dim isLoaded As Boolean = False

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet

    Dim OutsideCertUploader As UploadAPIOutsideCertification

    Private Sub ViewLotNumbers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadDivision()

        usefulFunctions.LoadSecurity(Me)

        isLoaded = True

        cboDivisionID.Text = "TWD"
        cboDivisionID.Enabled = True
        OutsideCertUploader = New UploadAPIOutsideCertification(Me, UploadOutsideCertificationToolStripMenuItem, ViewOutsideCertificationToolStripMenuItem, ReUploadOutsideCertificationToolStripMenuItem)
    End Sub

    Private Sub ViewLotNumbers_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvLotNumber.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboDivisionID.Text.Equals("TST") Then
            cmd = New SqlCommand("SELECT * FROM LotNumber WHERE DivisionID <> 'TST'", con)
        Else
            cmd = New SqlCommand("SELECT * FROM LotNumber WHERE DivisionID <> 'TST'", con)
        End If
        If Not String.IsNullOrEmpty(cboSteelVendor.Text) Then
            cmd.CommandText += " AND SteelVendorID = @SteelVendorID"
            cmd.Parameters.Add("@SteelVendorID", SqlDbType.VarChar).Value = cboSteelVendor.Text
        End If
        If Not String.IsNullOrEmpty(txtCarbon.Text) Then
            cmd.CommandText += " AND SteelType = @Carbon"
            cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtCarbon.Text
        End If
        If Not String.IsNullOrEmpty(txtSteelSize.Text) Then
            cmd.CommandText += " AND SteelSize = @SteelSize"
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSize.Text
        End If
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cmd.CommandText += " AND FOXNumber = @FOXNumber"
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
        End If
        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            cmd.CommandText += " AND LotNumber = @LotNumber"
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cmd.CommandText += " AND HeatNumber = @HeatNumber"
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        End If
        If Not String.IsNullOrEmpty(txtBlueprintNumber.Text) Then
            cmd.CommandText += " AND BlueprintNumber LIKE @BlueprintNumber"
            cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text + "%"
        End If
        If Not String.IsNullOrEmpty(cboHeatFileNumber.Text) Then
            cmd.CommandText += " AND HeatNumberID = @HeatNumberID"
            cmd.Parameters.Add("@HeatNumberID", SqlDbType.VarChar).Value = cboHeatFileNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cmd.CommandText += " AND PartNumber = @PartNumber"
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        End If
        If Not String.IsNullOrEmpty(txtHeadMarking.Text) Then
            cmd.CommandText += " AND HeadMarking = @HeadMarking"
            cmd.Parameters.Add("@HeadMarking", SqlDbType.VarChar).Value = txtHeadMarking.Text
        End If
        If Not String.IsNullOrEmpty(cboStatus.Text) Then
            cmd.CommandText += " AND Status = @Status"
            If cboStatus.Text.Equals("LOCKED") Then
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            Else
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = cboStatus.Text
            End If
        End If
        If chkInspectedParts.Checked = True Then
            cmd.CommandText += " AND QCInspected <> @QCInspected"
            cmd.Parameters.Add("@QCInspected", SqlDbType.VarChar).Value = ""
        End If

        cmd.CommandText += " ORDER BY LotNumber DESC"
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "LotNumber")
        con.Close()

        dgvLotNumber.DataSource = ds.Tables("LotNumber")

        LoadFormatting()
    End Sub

    Public Sub LoadFormatting()
        Dim InspectionRequired As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvLotNumber.Rows
            Try
                InspectionRequired = row.Cells("QCInspectedColumn").Value
            Catch ex As System.Exception
                InspectionRequired = ""
            End Try

            If InspectionRequired = "NO" Then
                Me.dgvLotNumber.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                Me.dgvLotNumber.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable", con)
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "FOXTable")
        con.Close()

        cboFOXNumber.DataSource = ds1.Tables("FOXTable")
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "ItemList")
        con.Close()

        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT HeatNumber FROM HeatNumberLog", con)
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "HeatNumberLog")

        con.Close()
        cboHeatNumber.DataSource = ds3.Tables("HeatNumberLog")
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode, VendorName FROM Vendor WHERE DivisionID = 'TWD' AND VendorClass = 'SteelVendor'", con)
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "Vendor")
        con.Close()

        cboSteelVendor.DataSource = ds4.Tables("Vendor")
        cboVendorName.DataSource = ds4.Tables("Vendor")
        cboSteelVendor.SelectedIndex = -1
        cboVendorName.SelectedIndex = -1
    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber", con)
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "LotNumber")
        cboLotNumber.DataSource = ds5.Tables("LotNumber")
        con.Close()

        cboLotNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"

        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter6.Fill(ds6, "ItemList")
        cboPartDescription.DataSource = ds6.Tables("ItemList")
        con.Close()

        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadDivision()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"

        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter7.Fill(ds7, "DivisionTable")
        cboDivisionID.DataSource = ds7.Tables("DivisionTable")
        con.Close()

        cboDivisionID.SelectedIndex = -1
    End Sub

    Private Sub dgvLotNumber_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotNumber.CellDoubleClick
        Dim RowLotStatus, RowLotNumber, RowHeatNumber, RowPartNumber, RowCertType, GetMinPartNumber, RowItemClass As String
        Dim RowNominalDiameter, RowNominalLength As Double
        Dim GetPullTestNumber As String = ""
        Dim MinTensileFilter As String = ""
        Dim MinYieldFilter As String = ""
        Dim MaxTensileFilter As String = ""
        Dim MaxYieldFilter As String = ""
        Dim ROAPercentFilter As String = ""
        Dim ElongationPercentFilter As String = ""
        Dim CEVValueFilter As String = ""
        Dim strMinTensile As String = ""
        Dim strMinYield As String = ""
        Dim strMaxTensile As String = ""
        Dim strMaxYield As String = ""
        Dim strROAPercent As String = ""
        Dim strElongationPercent As String = ""
        Dim strCEVValue As String = ""
        Dim LotStatus As String = ""
        Dim MinTensile As Double = 0
        Dim MinYield As Double = 0
        Dim MaxTensile As Double = 0
        Dim MaxYield As Double = 0
        Dim ROAPercent As Double = 0
        Dim ElongationPercent As Double = 0

        If Me.dgvLotNumber.RowCount = 0 Then
            'Do nothing
        Else
            Dim RowIndex As Integer = Me.dgvLotNumber.CurrentCell.RowIndex

            RowLotNumber = Me.dgvLotNumber.Rows(RowIndex).Cells("LotNumberColumn").Value
            RowHeatNumber = Me.dgvLotNumber.Rows(RowIndex).Cells("HeatNumberColumn").Value
            RowPartNumber = Me.dgvLotNumber.Rows(RowIndex).Cells("PartNumberColumn").Value
            RowNominalDiameter = Me.dgvLotNumber.Rows(RowIndex).Cells("NominalDiameterColumn").Value
            RowNominalLength = Me.dgvLotNumber.Rows(RowIndex).Cells("NominalLengthColumn").Value
            RowCertType = Me.dgvLotNumber.Rows(RowIndex).Cells("CertificationTypeColumn").Value
            RowItemClass = Me.dgvLotNumber.Rows(RowIndex).Cells("ItemClassColumn").Value
            RowLotStatus = Me.dgvLotNumber.Rows(RowIndex).Cells("StatusColumn").Value
            '****************************************************************************************
            If RowLotStatus <> "CLOSED" Then
                MsgBox("This Lot # has not been closed. Contact QC.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '****************************************************************************************
            'Get Requirements for the specific cert code
            Dim GetCertDataString As String = "SELECT MinTensile, MinYield, ROAPercent, ElongationPercent, MaxTensile, MaxYield FROM CertificationType WHERE CertificationCode = @CertificationCode"
            Dim GetCertDataCommand As New SqlCommand(GetCertDataString, con)
            GetCertDataCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = RowCertType

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader2 As SqlDataReader = GetCertDataCommand.ExecuteReader()
            If reader2.HasRows Then
                reader2.Read()
                If IsDBNull(reader2.Item("MinTensile")) Then
                    MinTensile = 0
                Else
                    MinTensile = reader2.Item("MinTensile")
                End If
                If IsDBNull(reader2.Item("MinYield")) Then
                    MinYield = 0
                Else
                    MinYield = reader2.Item("MinYield")
                End If
                If IsDBNull(reader2.Item("ROAPercent")) Then
                    ROAPercent = 0
                Else
                    ROAPercent = reader2.Item("ROAPercent")
                End If
                If IsDBNull(reader2.Item("ElongationPercent")) Then
                    ElongationPercent = 0
                Else
                    ElongationPercent = reader2.Item("ElongationPercent")
                End If
                If IsDBNull(reader2.Item("MaxTensile")) Then
                    MaxTensile = 0
                Else
                    MaxTensile = reader2.Item("MaxTensile")
                End If
                If IsDBNull(reader2.Item("MaxYield")) Then
                    MaxYield = 0
                Else
                    MaxYield = reader2.Item("MaxYield")
                End If
            Else
                MinTensile = 0
                MinYield = 0
                MaxTensile = 0
                MaxYield = 0
                ROAPercent = 0
                ElongationPercent = 0
            End If
            reader2.Close()
            con.Close()
            '****************************************************************************************
            'Get CEV From Heat Number Log
            Dim CEVValue As Double = 0

            Dim CEVValueStatement As String = "SELECT MAX(CEVValue) FROM HeatNumberLog WHERE HeatNumber = @HeatNumber"
            Dim CEVValueCommand As New SqlCommand(CEVValueStatement, con)
            CEVValueCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CEVValue = CDbl(CEVValueCommand.ExecuteScalar)
            Catch ex As Exception
                CEVValue = 0
            End Try
            con.Close()
            '****************************************************************************************
            'Define requirements for cert type
            Select Case RowCertType
                Case "0"
                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "1"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = CStr(ROAPercent)

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = " AND ReductionPercent >= '" + strROAPercent + "'"
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    If CEVValue <= 0.35 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "2"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "3"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = CStr(ROAPercent)

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    CEVValueFilter = "PASS"
                Case "4"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "5"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = CStr(ROAPercent)

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = " AND ReductionPercent >= '" + strROAPercent + "'"
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    CEVValueFilter = "PASS"
                Case "6"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    If CEVValue <= 0.35 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "7"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "8"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    CEVValueFilter = "PASS"
                Case "9"
                    strMinTensile = ""
                    strMinYield = ""
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = ""

                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    CEVValueFilter = "PASS"
                Case "10"
                    strMinTensile = ""
                    strMinYield = ""
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "11"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = "PASS"

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "12"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "13"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "17"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    If CEVValue >= 0.31 And CEVValue < 0.43 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "20"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strMaxTensile = CStr(MaxTensile)
                    strMaxYield = CStr(MaxYield)
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = CStr(ROAPercent)

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = " AND UltimateYieldPSI <= '" + strMaxTensile + "'"
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    If CEVValue <= 0.35 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "21"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    If CEVValue >= 0.31 And CEVValue < 0.43 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "CERT REQUIRED"
                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case Else
                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
            End Select
            '****************************************************************************************
            If RowItemClass = "TW DB" Or RowItemClass = "TW PS" Or RowItemClass = "TW SWR" Or RowItemClass = "TW HSR" Then
                'Get Pull Test Number for selected Lot Number Data
                Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
                GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
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
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = RowNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
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
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = RowNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
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

                'If CEV Value Fails, Pull Test Number is NO CERT
                If CEVValueFilter = "FAIL" Then
                    GetPullTestNumber = ""
                Else
                    'Do nothing
                End If

                'If Cert Code is 17, check min tensile to yield .2% offeset times 1.25
                If RowCertType = "17" And GetPullTestNumber <> "" Then
                    'Get Yield .2% from the pull test
                    Dim Yield2OffsetPSI As Double = 0
                    Dim YieldUltimatePSI As Double = 0

                    Dim Yield2OffsetPSIStatement As String = "SELECT Yield2PercentPSI FROM PullTestQuery WHERE TestNumber = @TestNumber"
                    Dim Yield2OffsetPSICommand As New SqlCommand(Yield2OffsetPSIStatement, con)
                    Yield2OffsetPSICommand.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = GetPullTestNumber

                    Dim YieldUltimatePSIStatement As String = "SELECT UltimateYieldPSI FROM PullTestQuery WHERE TestNumber = @TestNumber"
                    Dim YieldUltimatePSICommand As New SqlCommand(YieldUltimatePSIStatement, con)
                    YieldUltimatePSICommand.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = GetPullTestNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        Yield2OffsetPSI = CDbl(Yield2OffsetPSICommand.ExecuteScalar)
                    Catch ex As Exception
                        Yield2OffsetPSI = 0
                    End Try
                    Try
                        YieldUltimatePSI = CDbl(YieldUltimatePSICommand.ExecuteScalar)
                    Catch ex As Exception
                        YieldUltimatePSI = 0
                    End Try
                    con.Close()

                    If Yield2OffsetPSI * 1.25 > YieldUltimatePSI Then
                        GetPullTestNumber = ""
                    End If
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
                            .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                            .Add("@Date", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                            .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "View Lot Listing"
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
            ElseIf RowItemClass = "TW TT" Then
                'Get Pull Test Number for selected Lot Number Data
                Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
                GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
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
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = RowNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
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
                    GetSteelSizeCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetSteelSize = ""
                    End Try
                    con.Close()

                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND SteelSize = @SteelSize AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = GetSteelSize
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
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

                'If CEV Value Fails, Pull Test Number is NO CERT
                If CEVValueFilter = "FAIL" Then
                    GetPullTestNumber = ""
                Else
                    'Do nothing
                End If

                'Write to error log
                If GetPullTestNumber = "" Then
                    GetPullTestNumber = "NO CERT"

                    Try
                        'Write to error log
                        cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                            .Add("@Date", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                            .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "View Lot Listing"
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
            ElseIf RowItemClass = "Trufit Parts" Then
                'Skip printing cert
                'MsgBox("No cert exists for this TFP Part.", MsgBoxStyle.OkOnly)
            Else
                'Get Pull Test Number for selected Lot Number Data
                Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
                GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
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
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND NominalLength >= @NominalLength AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = RowNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@NominalLength", SqlDbType.VarChar).Value = RowNominalLength
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
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

                'If CEV Value Fails, Pull Test Number is NO CERT
                If CEVValueFilter = "FAIL" Then
                    GetPullTestNumber = ""
                Else
                    'Do nothing
                End If

                'Write to error log
                If GetPullTestNumber = "" Then
                    GetPullTestNumber = "NO CERT"

                    Try
                        'Write to error log
                        cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                            .Add("@Date", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                            .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "View Lot Listing"
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
            '**************************************************************************************************
            'If no pull test exists for the Heat, diameter show message
            If GetPullTestNumber = "" Or GetPullTestNumber = "NO CERT" Then
                MsgBox("No pull test exists for the selected Lot Number. Check your data and try again.", MsgBoxStyle.OkOnly)
            Else
                GlobalReprintHeatNumber = RowHeatNumber
                GlobalReprintLotNumber = RowLotNumber
                GlobalReprintPullTestNumber = GetPullTestNumber
                GlobalDivisionCode = cboDivisionID.Text

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewReprintCertRemote As New ReprintCertRemote
                        Dim Result = NewReprintCertRemote.ShowDialog()
                    End Using
                Else
                    Using NewReprintCert As New ReprintCert
                        Dim Result = NewReprintCert.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID;"
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

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID;"
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

    Public Sub ClearData()
        cboFOXNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cboFOXNumber.Text = ""
        End If
        cboHeatNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cboHeatNumber.Text = ""
        End If
        cboLotNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            cboLotNumber.Text = ""
        End If
        cboPartDescription.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
            cboPartDescription.Text = ""
        End If
        cboPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        cboSteelVendor.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelVendor.Text) Then
            cboSteelVendor.Text = ""
        End If
        cboVendorName.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboVendorName.Text) Then
            cboVendorName.Text = ""
        End If
        cboStatus.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboStatus.Text) Then
            cboStatus.Text = ""
        End If
        If cboHeatFileNumber.DataSource IsNot Nothing Then
            cboHeatFileNumber.SelectedIndex = -1
            If Not String.IsNullOrEmpty(cboHeatFileNumber.Text) Then cboHeatFileNumber.Text = ""
        End If
        txtBlueprintNumber.Clear()
        txtCarbon.Clear()
        txtSteelSize.Clear()
        txtHeadMarking.Clear()

        chkInspectedParts.Checked = False

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        HeatFilter = ""
        LotFilter = ""
        PartFilter = ""
        VendorFilter = ""
        FOXFilter = ""
        BlueprintFilter = ""
        CarbonFilter = ""
        SteelSizeFilter = ""
        FOXNumber = 0
        strFOXNumber = ""
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdOpenLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenLotNumber.Click
        If dgvLotNumber.Rows.Count > 0 Then
            If dgvLotNumber.CurrentCell.RowIndex >= 0 Then
                GlobalLotNumber = Val(dgvLotNumber.Rows(dgvLotNumber.CurrentCell.RowIndex).Cells("LotNumberColumn").Value)
            Else
                GlobalLotNumber = ""
            End If
        Else
            GlobalLotNumber = ""
        End If

        Dim NewLotNumberMaintenance As New LotNumberMaintenance
        NewLotNumberMaintenance.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintLotNumberListFiltered As New PrintLotNumberListFiltered
            Dim result = NewPrintLotNumberListFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintLotNumberListFiltered As New PrintLotNumberListFiltered
            Dim result = NewPrintLotNumberListFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdPrintTubTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintTubTag.Click
        If dgvLotNumber.CurrentRow IsNot Nothing Then
            Dim bc As New BarcodeLabel()
            ' Prepare TUB TAG
            bc.setupTubTag(dgvLotNumber.CurrentRow.Cells("LotNumberColumn").Value)
            bc.PrintBarcodeLine()
        End If
    End Sub

    Private Sub cmdPrintTubPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintTubPage.Click
        'If Me.dgvLotNumber.RowCount > 0 Then
        '    'Loads data into dataset for viewing
        '    cmd1 = New SqlCommand("SELECT * From LotNumber WHERE LotNumber = @LotNumber", con)
        '    cmd1.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = Me.dgvLotNumber.CurrentRow.Cells("LotNumberColumn").Value

        '    cmd2 = New SqlCommand("SELECT * From FOXTable WHERE FOXNumber = @FOXNumber", con)
        '    cmd2.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Me.dgvLotNumber.CurrentRow.Cells("FOXNumberColumn").Value

        '    cmd3 = New SqlCommand("SELECT * From FOXSched WHERE FOXNumber = @FOXNumber", con)
        '    cmd3.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Me.dgvLotNumber.CurrentRow.Cells("FOXNumberColumn").Value

        '    cmd4 = New SqlCommand("SELECT * From FOXCertifications WHERE FOXNumber = @FOXNumber", con)
        '    cmd4.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Me.dgvLotNumber.CurrentRow.Cells("FOXNumberColumn").Value

        '    cmd5 = New SqlCommand("SELECT * From ItemList WHERE ItemID = @ItemID", con)
        '    cmd5.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = Me.dgvLotNumber.CurrentRow.Cells("PartNumberColumn").Value

        '    If con.State = ConnectionState.Closed Then con.Open()
        '    ds = New DataSet()

        '    myAdapter1.SelectCommand = cmd1
        '    myAdapter1.Fill(ds, "LotNumber")

        '    myAdapter2.SelectCommand = cmd2
        '    myAdapter2.Fill(ds, "FOXTable")

        '    myAdapter3.SelectCommand = cmd3
        '    myAdapter3.Fill(ds, "FOXSched")

        '    myAdapter4.SelectCommand = cmd4
        '    myAdapter4.Fill(ds, "FOXCertifications")

        '    myAdapter5.SelectCommand = cmd5
        '    myAdapter5.Fill(ds, "ItemList")

        '    'Sets up viewer to display data from the loaded dataset
        '    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '    MyReport = CRXTubtag1
        '    MyReport.SetDataSource(ds)
        '    MyReport.PrintToPrinter(1, True, 1, 999)
        '    con.Close()
        'End If

        If dgvLotNumber.CurrentRow IsNot Nothing Then
            Dim newViewTubPage As New ViewTubPage(dgvLotNumber.CurrentRow.Cells("FOXNumberColumn").Value, dgvLotNumber.CurrentRow.Cells("LotNumberColumn").Value, CheckPullTests())
            newViewTubPage.ShowDialog()
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded Then
            isLoaded = False

            LoadPartNumber()
            LoadPartDescription()
            LoadFOXNumber()
            LoadHeatNumber()
            LoadVendor()
            LoadLotNumber()
            ClearData()
            ClearVariables()
            ClearDataInDatagrid()

            isLoaded = True
        End If
    End Sub

    Private Sub dgvLotNumber_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotNumber.CellValueChanged
        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Or cboDivisionID.Text = "ADM" Then
            Dim LotNumber, LotComment As String

            If Me.dgvLotNumber.RowCount <> 0 Then
                Dim RowIndex As Integer = Me.dgvLotNumber.CurrentCell.RowIndex

                Try
                    LotNumber = Me.dgvLotNumber.Rows(RowIndex).Cells("LotNumberColumn").Value
                Catch ex As Exception
                    LotNumber = ""
                End Try
                Try
                    LotComment = Me.dgvLotNumber.Rows(RowIndex).Cells("CommentColumn").Value
                Catch ex As Exception
                    LotComment = ""
                End Try

                'Update Lot Number
                cmd = New SqlCommand("UPDATE LotNumber SET Comment = @Comment WHERE LotNumber = @LotNumber", con)

                With cmd.Parameters
                    .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                    .Add("@Comment", SqlDbType.VarChar).Value = LotComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Private Sub dgvLotNumber_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvLotNumber.SelectionChanged
        If dgvLotNumber.SelectedCells.Count > 0 Then
            If dgvLotNumber.Rows(dgvLotNumber.SelectedCells(0).RowIndex).Cells("StatusColumn").Value.Equals("CLOSED") Then
                cmdPrintTubPage.Enabled = True
                cmdPrintTubTag.Enabled = True
            Else
                cmdPrintTubPage.Enabled = False
                cmdPrintTubTag.Enabled = False
            End If
            OutsideCertUploader.ChangeLotNumber(dgvLotNumber.Rows(dgvLotNumber.SelectedCells(0).RowIndex).Cells("LotNumberColumn").Value.ToString)
        Else
            OutsideCertUploader.ChangeLotNumber("")
        End If
    End Sub

    Private Sub cboStatus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboStatus.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Function CheckPullTests() As Boolean
        Dim itmClass As String = dgvLotNumber.CurrentRow.Cells("ItemClassColumn").Value
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
            Case "TW FER"
                itmClass = itmClass
            Case Else
                itmClass = "TW TT"
        End Select

        If dgvLotNumber.CurrentRow.Cells("PartNumberColumn").Value.ToString.StartsWith("SC") Or dgvLotNumber.CurrentRow.Cells("PartNumberColumn").Value.ToString.StartsWith("DSC") Or dgvLotNumber.CurrentRow.Cells("PartNumberColumn").Value.ToString.StartsWith("CA") Then
            cmd = New SqlCommand("SELECT COUNT(TestNumber) FROM PullTestData WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter", con)
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = dgvLotNumber.CurrentRow.Cells("HeatNumberColumn").Value
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = itmClass
            cmd.Parameters.Add("@NominalDiameter", SqlDbType.Float).Value = Val(dgvLotNumber.CurrentRow.Cells("NominalDiameterColumn").Value)

            If con.State = ConnectionState.Closed Then con.Open()

            If cmd.ExecuteScalar() = 0 Then
                con.Close()
                Return True
            Else
                con.Close()
                Return False
            End If
        ElseIf dgvLotNumber.CurrentRow.Cells("DivisionIDColumn").Value.ToString.Equals("TWD") Then
            cmd = New SqlCommand("SELECT COUNT(TestNumber) FROM PullTestData WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalLength >= @NominalLength AND NominalDiameter = @NominalDiameter", con)
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = dgvLotNumber.CurrentRow.Cells("HeatNumberColumn").Value.ToString
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = itmClass
            cmd.Parameters.Add("@NominalLength", SqlDbType.Float).Value = Val(dgvLotNumber.CurrentRow.Cells("NominalLengthColumn").Value)
            cmd.Parameters.Add("@NominalDiameter", SqlDbType.Float).Value = Val(dgvLotNumber.CurrentRow.Cells("NominalDiameterColumn").Value.ToString)

            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar() = 0 Then
                con.Close()
                Return True
            Else
                con.Close()
                Return False
            End If
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Return False
        End If
    End Function

    Private Sub cboHeatFileNumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatFileNumber.Enter
        If cboHeatFileNumber.DataSource Is Nothing Then
            cmd = New SqlCommand("SELECT HeatFileNumber FROM HeatNumberLog", con)

            Dim dt As New Data.DataTable("HeatNumberLog")
            Dim adap As New SqlDataAdapter(cmd)
            If con.State = ConnectionState.Closed Then con.Open()
            adap.Fill(dt)
            con.Close()
            cboHeatFileNumber.DisplayMember = "HeatFileNumber"
            cboHeatFileNumber.DataSource = dt
            cboHeatFileNumber.SelectedIndex = -1
        End If
    End Sub
End Class