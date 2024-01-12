Imports System.Math
Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class PullTestData
    Inherits System.Windows.Forms.Form

    Dim ReducedDiameter, ReducedRadius, ReducedCrossSectionalArea, Radius, CrossSectionalAreaCalculated, NominalDiameter, NominalLength, CrossSectionalArea, Yield2PercentPound, YieldPSI, UltimateYieldPound, UltimatePSI, Elongation2Inch, ElongPercent, Reduction2Inch, ROAPercent, TorqueFootPounds As Double
    Dim Description, OldPartNumber, OldTestNumber, CertificationType, PartNumber, PartDescription, TestDate, FOXNumber, HeatNumber, RMID, TestedBy, Comment As String
    Dim HeatFileNumber, LastTransactionNumber, NextTransactionNumber, counter As Integer
    Dim RowHeatFileNumber As Integer = 0
    Dim CountCheckedItems As Integer = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet

    Dim isLoaded As Boolean = False
    Dim controlKey As Boolean = False

    Private Class UploadEntries
        Private fields As New Dictionary(Of String, String)
        Public Sub Add(ByVal FieldName As String, ByVal FieldValue As String)
            If fields.ContainsKey(FieldName) Then
                fields(FieldName) = FieldValue
            Else
                fields.Add(FieldName, FieldValue)
            End If
        End Sub
        Public Function Item(ByVal FieldName As String) As String
            If fields.ContainsKey(FieldName) Then
                Return fields(FieldName)
            Else
                Return ""
            End If
        End Function
        Public Sub Update(ByVal FieldName As String, ByVal value As String)
            If fields.ContainsKey(FieldName) Then
                fields(FieldName) = value
            Else
                fields.Add(FieldName, value)
            End If
        End Sub
    End Class

    Dim ColumnList As New List(Of String)
    Dim CurrentCertRequirements As CertificationRequirements

    Structure CertificationRequirements
        Public MinimumTensile As Integer
        Public MinimumYeild As Integer
        Public ReductionOfAreaPercent As Integer
        Public ElongationPercent As Integer
    End Structure

    Private Sub PullTestData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearData()

        isLoaded = True

        usefulFunctions.LoadSecurity(Me)

        cboDivisionID.Text = "TWD"

        If GlobalPullTestNumber = "" Then
            cboPullTestNumber.SelectedIndex = -1
        Else
            cboPullTestNumber.Text = GlobalPullTestNumber
        End If
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "FOXTable")
        con.Close()

        cboFOXNumber.DisplayMember = "FOXNumber"
        cboFOXNumber.DataSource = ds1.Tables("FOXTable")
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "ItemList")
        con.Close()

        cboPartNumber.DisplayMember = "ItemID"
        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPullTestNumber()
        cmd = New SqlCommand("SELECT TestNumber FROM PullTestData WHERE DivisionID = @DivisionID ORDER BY TestDate DESC;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "PullTestData")
        con.Close()

        cboPullTestNumber.DisplayMember = "TestNumber"
        cboPullTestNumber.DataSource = ds4.Tables("PullTestData")
        cboPullTestNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT(HeatNumber) FROM HeatNumberLog;", con)
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "HeatNumberLog")
        con.Close()

        cboHeatNumber.DisplayMember = "HeatNumber"
        cboHeatNumber.DataSource = ds5.Tables("HeatNumberLog")
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadRMID()
        Dim LoadRMID As String = ""

        Dim LoadRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim LoadRMIDCommand As New SqlCommand(LoadRMIDStatement, con)
        LoadRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtSteelTypeFromHeat.Text
        LoadRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeFromHeat.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadRMID = CStr(LoadRMIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            LoadRMID = ""
        End Try
        con.Close()

        txtRMIDFromHeat.Text = LoadRMID
    End Sub

    Public Sub LoadCertDescription()
        Dim DescriptionStatement As String = "SELECT Description FROM CertificationType WHERE CertificationCode = @CertificationCode;"
        Dim DescriptionCommand As New SqlCommand(DescriptionStatement, con)
        DescriptionCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = txtCertType.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            Description = CStr(DescriptionCommand.ExecuteScalar)
        Catch ex As System.Exception
            Description = ""
        End Try
        con.Close()

        txtCertDescription.Text = Description
    End Sub

    Public Sub LoadSteelFromHeatNumber()
        Dim LoadHeatSteelType, LoadHeatSteelSize As String

        Dim LoadHeatSteelTypeStatement As String = "SELECT SteelType FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber"
        Dim LoadHeatSteelTypeCommand As New SqlCommand(LoadHeatSteelTypeStatement, con)
        LoadHeatSteelTypeCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = HeatFileNumber

        Dim LoadHeatSteelSizeStatement As String = "SELECT SteelSize FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber"
        Dim LoadHeatSteelSizeCommand As New SqlCommand(LoadHeatSteelSizeStatement, con)
        LoadHeatSteelSizeCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = HeatFileNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadHeatSteelType = CStr(LoadHeatSteelTypeCommand.ExecuteScalar)
        Catch ex As System.Exception
            LoadHeatSteelType = ""
        End Try
        Try
            LoadHeatSteelSize = CStr(LoadHeatSteelSizeCommand.ExecuteScalar)
        Catch ex As System.Exception
            LoadHeatSteelSize = ""
        End Try
        con.Close()

        txtSteelTypeFromHeat.Text = LoadHeatSteelType
        txtSteelSizeFromHeat.Text = LoadHeatSteelSize
    End Sub

    Public Function GetHeatFileNumber() As String
        Dim HeatFileNumberStatement As String = "if exists(SELECT TOP 1 HeatFileNumber FROM HeatNumberLog WHERE HeatNumber = @HeatNumber AND SteelSize = @SteelSize AND SteelType = @SteelType) SELECT TOP 1 HeatFileNumber FROM HeatNumberLog WHERE HeatNumber = @HeatNumber AND SteelSize = @SteelSize AND SteelType = @SteelType else SELECT 0;"
        Dim HeatFileNumberCommand As New SqlCommand(HeatFileNumberStatement, con)
        HeatFileNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        HeatFileNumberCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeFromHeat.Text
        HeatFileNumberCommand.Parameters.Add("@SteelType", SqlDbType.VarChar).Value = txtSteelTypeFromHeat.Text
        Dim heatFile As String = "0"
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            heatFile = HeatFileNumberCommand.ExecuteScalar.ToString()
        Catch ex As System.Exception
        End Try
        con.Close()

        HeatFileNumber = CInt(heatFile)
        Return heatFile
    End Function

    Public Sub LoadPartData()
        Dim NominalDiameterStatement As String = "SELECT NominalDiameter, NominalLength, OldPartNumber, LongDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID;"
        Dim NominalDiameterCommand As New SqlCommand(NominalDiameterStatement, con)
        NominalDiameterCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        NominalDiameterCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = NominalDiameterCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
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
            If IsDBNull(reader.Item("OldPartNumber")) Then
                OldPartNumber = ""
            Else
                OldPartNumber = reader.Item("OldPartNumber")
            End If
            If IsDBNull(reader.Item("LongDescription")) Then
                PartDescription = ""
            Else
                PartDescription = reader.Item("LongDescription")
            End If
        Else
            NominalDiameter = 0
            NominalLength = 0
            OldPartNumber = ""
            PartDescription = ""
        End If
        reader.Close()
        con.Close()

        If cboPartNumber.Text.Length > 3 Then
            If Not cboPartNumber.Text.Substring(0, 2).Equals("SC") And Not cboPartNumber.Text.Substring(0, 3).Equals("DSC") And Not cboPartNumber.Text.Substring(0, 2).Equals("CA") Then
                NominalLength = 100
            End If
            If PartNumber.StartsWith("TT") Or PartNumber.StartsWith("TP") Or PartNumber.StartsWith("NT") Then
                txtArea.Text = "0"
            Else
                calculateArea()
            End If
        End If
        txtOldPartNumber.Text = OldPartNumber
        txtPartDescription.Text = PartDescription
    End Sub

    Public Sub LoadHeatFileTable()
        cmd = New SqlCommand("SELECT * FROM HeatNumberLog WHERE HeatNumber = @HeatNumber ORDER BY HeatFileNumber", con)
        cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "HeatNumberLog")
        dgvHeatFileTable.DataSource = ds7.Tables("HeatNumberLog")
        con.Close()

        If Me.dgvHeatFileTable.RowCount = 1 Then
            Me.dgvHeatFileTable.Rows(0).Cells("CheckBoxColumn").Value = "CHECKED"

            RowHeatFileNumber = Me.dgvHeatFileTable.Rows(0).Cells("HeatFileNumberColumn").Value

            LoadSteelFromHeatNumber()
        Else
            'Do nothing - user must choose heat file number
            txtSteelTypeFromHeat.Clear()
            txtSteelSizeFromHeat.Clear()
            txtRMIDFromHeat.Clear()
        End If
    End Sub

    Private Sub calculateArea()
        Radius = NominalDiameter / 2
        CrossSectionalAreaCalculated = 3.1459 * (Radius * Radius)
        CrossSectionalArea = Math.Round(CrossSectionalAreaCalculated, 5, MidpointRounding.AwayFromZero)
        txtArea.Text = CrossSectionalArea
    End Sub

    Public Sub LoadPullTestData()
        Dim Carbon As String = ""
        Dim SteelSize As String = ""
        Dim PullTestRMID As String = ""

        Dim TestDateStatement As String = "SELECT * FROM PullTestData WHERE Testnumber = @TestNUmber"
        Dim TestDateCommand As New SqlCommand(TestDateStatement, con)
        TestDateCommand.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = TestDateCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("TestDate")) Then
                TestDate = ""
            Else
                TestDate = reader.Item("TestDate")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                FOXNumber = ""
            Else
                FOXNumber = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("PartDescription")) Then
                PartDescription = ""
            Else
                PartDescription = reader.Item("PartDescription")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = ""
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("TestedBy")) Then
                TestedBy = ""
            Else
                TestedBy = reader.Item("TestedBy")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = ""
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("OldTestNumber")) Then
                OldTestNumber = ""
            Else
                OldTestNumber = reader.Item("OldTestNumber")
            End If
            If IsDBNull(reader.Item("OldPartNumber")) Then
                txtOldPartNumber.Text = ""
            Else
                txtOldPartNumber.Text = reader.Item("OldPartNumber")
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
            If IsDBNull(reader.Item("BendTest")) Then
                cboBendTest.Text = ""
            Else
                cboBendTest.Text = reader.Item("BendTest")
            End If
            If IsDBNull(reader.Item("ProcessType")) Then
                cboProcessType.Text = ""
            Else
                cboProcessType.Text = reader.Item("ProcessType")
            End If
            If IsDBNull(reader.Item("HeatFileNumber")) Then
                HeatFileNumber = 0
            Else
                HeatFileNumber = reader.Item("HeatFileNumber")
            End If
            If IsDBNull(reader.Item("RMID")) Then
                PullTestRMID = ""
            Else
                PullTestRMID = reader.Item("RMID")
            End If
        Else
            TestDate = ""
            FOXNumber = ""
            PartNumber = ""
            PartDescription = ""
            HeatNumber = ""
            Carbon = ""
            SteelSize = ""
            TestedBy = ""
            Comment = ""
            OldTestNumber = ""
            txtOldPartNumber.Text = ""
            NominalDiameter = 0
            NominalLength = 0
            cboBendTest.Text = ""
            cboProcessType.Text = ""
            HeatFileNumber = 0
            PullTestRMID = ""
        End If
        reader.Close()
        con.Close()

        cboFOXNumber.Text = FOXNumber

        isLoaded = False
        dtpPullTestDate.Text = TestDate
        cboPartNumber.Text = PartNumber
        txtPartDescription.Text = PartDescription

        cboHeatNumber.Text = HeatNumber
        txtRMIDFromHeat.Text = PullTestRMID
        lblHeatFileNumber.Text = HeatFileNumber

        If HeatFileNumber > 0 Then
            'Check the line in datagrid with the same heat file number
            If Me.dgvHeatFileTable.RowCount > 0 Then
                Dim RowHeatFileNumber As Integer = 0
                For Each row As DataGridViewRow In dgvHeatFileTable.Rows
                    RowHeatFileNumber = row.Cells("HeatFileNumberColumn").Value
                    If RowHeatFileNumber = HeatFileNumber Then
                        'Check the box
                        row.Cells("CheckBoxColumn").Value = "CHECKED"
                        lblHeatFileNumber.Text = RowHeatFileNumber
                    Else
                        row.Cells("CheckBoxColumn").Value = "UNCHECKED"
                    End If
                Next
            End If

            LoadSteelFromHeatNumber()
        Else
            CheckHeatFileRecordFromSavedPullTest()
        End If

        txtTestedBy.Text = TestedBy
        txtComment.Text = Comment
        txtOldTestNumber.Text = OldTestNumber
        isLoaded = True
        checkStatus()

        If cboPartNumber.Text.StartsWith("PSR") Or cboPartNumber.Text.StartsWith("PSD") Then
            lblProcessType.Show()
            cboProcessType.Show()
        Else
            lblProcessType.Hide()
            cboProcessType.Hide()
            cboProcessType.SelectedIndex = -1
            If String.IsNullOrEmpty(cboProcessType.Text) Then
                cboProcessType.Text = ""
            End If
        End If
    End Sub

    Public Sub CheckHeatFileRecordFromSavedPullTest()
        If cboHeatNumber.Text = "" And txtSteelSizeFromHeat.Text = "" And txtSteelTypeFromHeat.Text = "" Then
            'Skip
        Else
            Dim TempHeatFileNumber As Integer = 0

            Dim TempHeatFileNumberStatement As String = "SELECT TOP 1 (HeatFileNumber) FROM HeatNumberLog WHERE HeatNumber = @HeatNumber AND SteelType = @SteelType AND SteelSize = @SteelSize"
            Dim TempHeatFileNumberCommand As New SqlCommand(TempHeatFileNumberStatement, con)
            TempHeatFileNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            TempHeatFileNumberCommand.Parameters.Add("@SteelType", SqlDbType.VarChar).Value = txtSteelTypeFromHeat.Text
            TempHeatFileNumberCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeFromHeat.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TempHeatFileNumber = CInt(TempHeatFileNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                TempHeatFileNumber = 0
            End Try
            con.Close()

            If TempHeatFileNumber = 0 Then
                'Skip - do not check box in datagrid
            Else
                If Me.dgvHeatFileTable.RowCount > 0 Then
                    Dim RowHeatFileNumber As Integer = 0
                    For Each row As DataGridViewRow In dgvHeatFileTable.Rows
                        RowHeatFileNumber = row.Cells("HeatFileNumberColumn").Value
                        If RowHeatFileNumber = TempHeatFileNumber Then
                            'Check the box
                            row.Cells("CheckBoxColumn").Value = "CHECKED"
                            lblHeatFileNumber.Text = RowHeatFileNumber
                        Else
                            row.Cells("CheckBoxColumn").Value = "UNCHECKED"
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Function checkStatus() As Boolean
        Dim status As String = "OPEN"
        If Not String.IsNullOrEmpty(cboPullTestNumber.Text) Then
            cmd = New SqlCommand("SELECT isnull(Status, 'OPEN') FROM PullTestData WHERE TestNumber = @TestNumber;", con)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            status = cmd.ExecuteScalar()
        End If

        If status = "CLOSED" Then
            cboHeatNumber.Enabled = False
            cboFOXNumber.Enabled = False
            cboPartNumber.Enabled = False
            txtOldPartNumber.ReadOnly = True
            cboBreakLocation.Enabled = False
            txtOldTestNumber.ReadOnly = True
            txtArea.ReadOnly = True
            txtYield2Pound.ReadOnly = True
            txtUltimatePounds.ReadOnly = True
            txtElongation.ReadOnly = True
            txtReductionDiameter.ReadOnly = True
            txtTorqueTest.ReadOnly = True
            cboBendTest.Enabled = False
            txtTestedBy.ReadOnly = True
            txtComment.ReadOnly = True
            cmdSaveTest.Enabled = False
            cmdClearTest.Enabled = False
            cmdDeleteTest.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdFinish.Enabled = False
            cmdReloadData.Enabled = False
            cboProcessType.Enabled = False
            Return True
        Else
            cboHeatNumber.Enabled = True
            cboFOXNumber.Enabled = True
            cboPartNumber.Enabled = True
            cboBreakLocation.Enabled = True
            txtOldPartNumber.ReadOnly = False
            txtOldTestNumber.ReadOnly = False
            txtArea.ReadOnly = False
            txtYield2Pound.ReadOnly = False
            txtUltimatePounds.ReadOnly = False
            txtElongation.ReadOnly = False
            txtReductionDiameter.ReadOnly = False
            txtTorqueTest.ReadOnly = False
            cboBendTest.Enabled = True
            txtTestedBy.ReadOnly = False
            txtComment.ReadOnly = False
            cmdSaveTest.Enabled = True
            cmdClearTest.Enabled = True
            cmdDeleteTest.Enabled = True
            cmdSave.Enabled = True
            cmdDelete.Enabled = True
            cmdFinish.Enabled = True
            cmdReloadData.Enabled = True
            cboProcessType.Enabled = True
            Return False
        End If

    End Function

    Public Sub LoadFOXData()
        Dim Carbon As String = ""
        Dim SteelSize As String = ""
        Dim RMIDStatement As String = "SELECT Carbon, SteelSize, CertificationType, PartNumber FROM FOXTable LEFT OUTER JOIN RawMaterialsTable On FOXTable.RMID = RawMaterialsTable.RMID WHERE FOXNumber = @FOXNumber AND FOXTable.DivisionID = @DivisionID;"
        Dim RMIDCommand As New SqlCommand(RMIDStatement, con)
        RMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        RMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = RMIDCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Carbon")) Then
                Carbon = ""
            Else
                Carbon = reader.Item("Carbon")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("CertificationType")) Then
                CertificationType = ""
            Else
                CertificationType = reader.Item("CertificationType")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
        Else
            Carbon = ""
            SteelSize = ""
            CertificationType = ""
            PartNumber = ""
        End If
        reader.Close()
        con.Close()

        txtSteelCarbonFromFOX.Text = Carbon
        txtSteelDiameterFromFOX.Text = SteelSize
        txtCertType.Text = CertificationType

        If cboFOXNumber.Focused Then
            cboPartNumber.Text = PartNumber
        End If

        LoadCertDescription()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If canExit() Then
            'Prompt before Deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Pull Test?", "SAVE PULL TEST", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                If canSave() Then
                    Try
                        updateOrInsertIntoPullTestData()
                    Catch ex As System.Exception
                        sendErrorToDataBase("PullTestData - cmdExit_Click --Error trying to insert/update test data into PullTestData", "Test #" + cboPullTestNumber.Text, ex.ToString())
                        MessageBox.Show("There was a problem saving the pull test to the database.Contact system admin", "Unable ot complete entry", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    Exit Sub
                End If
            ElseIf button = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            ElseIf button = System.Windows.Forms.DialogResult.No Then
                isLoaded = False
                cmdDelete_Click(sender, e)
            End If
        End If
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Function canExit() As Boolean
        If String.IsNullOrEmpty(cboPullTestNumber.Text) Then
            Return False
        End If
        If cboPullTestNumber.SelectedIndex = -1 Then
            Return False
        End If
        If checkStatus() Then
            Return False
        End If
        Return True
    End Function

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Public Sub ClearData()
        cboPullTestNumber.Text = ""

        cboPartNumber.Refresh()
        cboFOXNumber.Refresh()
        cboHeatNumber.Refresh()
        cboPullTestNumber.Refresh()

        txtCertType.Refresh()
        txtPartDescription.Refresh()
        txtCertDescription.Refresh()
        txtComment.Refresh()
        txtOldPartNumber.Refresh()
        txtOldTestNumber.Refresh()
        txtSteelCarbonFromFOX.Refresh()
        txtSteelDiameterFromFOX.Refresh()
        txtSteelSizeFromHeat.Refresh()
        txtSteelTypeFromHeat.Refresh()
        txtRMIDFromHeat.Refresh()

        cboPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        cboFOXNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cboFOXNumber.Text = ""
        End If
        cboHeatNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cboHeatNumber.Text = ""
        End If
        cboPullTestNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPullTestNumber.Text) Then
            cboPullTestNumber.Text = ""
        End If
        cboBendTest.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboBendTest.Text) Then
            cboBendTest.Text = ""
        End If
        cboProcessType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboProcessType.Text) Then
            cboProcessType.Text = ""
        End If

        txtCertDescription.Clear()
        txtCertType.Clear()
        txtComment.Clear()
        txtPartDescription.Clear()
        txtOldPartNumber.Clear()
        txtOldTestNumber.Clear()
        txtTestedBy.Clear()
        txtSteelCarbonFromFOX.Clear()
        txtSteelDiameterFromFOX.Clear()
        txtRMIDFromHeat.Clear()
        txtSteelSizeFromHeat.Clear()
        txtSteelTypeFromHeat.Clear()

        lblHeatFileNumber.Text = ""

        clearTestArea()
        cboTestNumber.SelectedIndex = 0

        dgvHeatFileTable.DataSource = Nothing

        cboPullTestNumber.Focus()
        clearTestArea()
    End Sub

    Private Sub clearTestArea()
        txtArea.Refresh()
        txtYield2Pound.Refresh()
        txtYield2PSI.Refresh()
        txtTestedBy.Refresh()
        txtTorqueTest.Refresh()
        txtElongation.Refresh()
        txtElongationPercent.Refresh()
        txtReductionDiameter.Refresh()
        txtReductionPercent.Refresh()
        txtUltimatePounds.Refresh()
        txtUltimatePSI.Refresh()

        isLoaded = False
        txtArea.Clear()
        txtYield2Pound.Text = "0"
        txtYield2PSI.Text = ""
        lblYieldBelow.Text = ""
        txtTorqueTest.Clear()
        txtElongation.Text = "0"
        txtElongationPercent.Text = ""
        lblElongationBelow.Text = ""
        txtReductionDiameter.Text = "0"
        txtReductionPercent.Text = ""
        lblReductionBelow.Text = ""
        txtUltimatePounds.Text = "0"
        txtUltimatePSI.Text = ""
        lblTensileBelow.Text = ""
        isLoaded = True

        cboBreakLocation.SelectedIndex = -1
    End Sub

    Public Sub ClearVariables()
        ReducedDiameter = 0
        ReducedRadius = 0
        ReducedCrossSectionalArea = 0
        Radius = 0
        CrossSectionalAreaCalculated = 0
        NominalDiameter = 0
        NominalLength = 0
        CrossSectionalArea = 0
        Yield2PercentPound = 0
        YieldPSI = 0
        UltimateYieldPound = 0
        UltimatePSI = 0
        Elongation2Inch = 0
        ElongPercent = 0
        Reduction2Inch = 0
        ROAPercent = 0
        TorqueFootPounds = 0
        Description = ""
        OldPartNumber = ""
        OldTestNumber = ""
        CertificationType = ""
        PartNumber = ""
        PartDescription = ""
        TestDate = ""
        FOXNumber = ""
        HeatNumber = ""
        RMID = ""
        TestedBy = ""
        Comment = ""
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        HeatFileNumber = 0
        counter = 0
    End Sub

    Private Sub txtUltimatePounds_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUltimatePounds.LostFocus
        UltimateYieldPound = Val(txtUltimatePounds.Text)
        UltimatePSI = Math.Round(UltimateYieldPound / Val(txtArea.Text), 2, MidpointRounding.AwayFromZero)
        txtUltimatePSI.Text = Math.Round(UltimatePSI, 2)
    End Sub

    Private Sub txtElongation_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtElongation.LostFocus
        Elongation2Inch = Val(txtElongation.Text)
        ElongPercent = (Elongation2Inch / 2)
        txtElongationPercent.Text = FormatPercent(ElongPercent, 2)
    End Sub

    Private Sub txtArea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArea.TextChanged
        If isLoaded Then
            CrossSectionalArea = Val(txtArea.Text)
            txtYield2Pound_LostFocus(sender, e)
            txtUltimatePounds_LostFocus(sender, e)
            txtElongation_LostFocus(sender, e)
            txtReductionDiameter_TextChanged(sender, e)
            CheckRequirements()
        End If
    End Sub

    Private Sub txtReductionDiameter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReductionDiameter.TextChanged
        If isLoaded Then
            If Val(txtReductionDiameter.Text) <> 0 Then
                Radius = Val(txtReductionDiameter.Text) / 2
                Dim ReductionAreaCalculated As Double = Math.Round(3.1459 * (Radius * Radius), 5, MidpointRounding.AwayFromZero)
                Dim ReductionArea As String = ReductionAreaCalculated.ToString
                txtReductionArea.Text = ReductionAreaCalculated.ToString()
                txtReductionPercent.Text = FormatPercent((Val(txtArea.Text) - ReductionAreaCalculated) / Val(txtArea.Text), 2)
            Else
                txtReductionArea.Text = "0"
                txtReductionPercent.Text = "0%"
            End If
        End If
    End Sub

    Private Sub txtYield2Pound_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYield2Pound.LostFocus
        Yield2PercentPound = Val(txtYield2Pound.Text)
        YieldPSI = Math.Round(Yield2PercentPound / Val(txtArea.Text), 2)
        txtYield2PSI.Text = Math.Round(YieldPSI, 2)
    End Sub

    Private Sub cmdClearHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearHeader.Click
        isLoaded = False
        ClearVariables()
        ClearData()
        dtpPullTestDate.Value = Today.Date
        isLoaded = True
        checkStatus()
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        cmdClearHeader_Click(sender, e)
    End Sub

    Private Sub cmdFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        If canFinalize() Then
            If Not insertOrUpdateTestData() Then
                Exit Sub
            End If
            Dim rslt As DialogResult = MessageBox.Show("This will finalize the pull test and no more changes can be made. Do you wish to continue?", "Finalize pull test", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ''makes sure the user knows that they can't make changes after they enter the pull test
            If rslt <> System.Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If
            Try
                updateOrInsertIntoPullTestData("CLOSED")
            Catch ex As System.Exception
                sendErrorToDataBase("PullTestData - cmdEnter_Click -- Error trying to insert/update into PullTestData", "Test #" + cboPullTestNumber.Text, ex.ToString())
                MessageBox.Show("There was a problem finalizing the pull test. Contact system admin", "Unable ot complete entry", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            checkStatus()
        End If
    End Sub

    Private Function canFinalize() As Boolean
        If checkStatus() Then
            MessageBox.Show("Pull test is finalized, you can't save any changes", "Can't save changes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboPullTestNumber.Text) Then
            MessageBox.Show("You must enter a pull test number", "Enter a pull test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.Focus()
            Return False
        End If
        If cboPullTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid pull test number", "Enter a valid pull test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.SelectAll()
            cboPullTestNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must select a FOX number", "Select a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid FOX number", "Select a valid FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboHeatNumber.Text) Then
            MessageBox.Show("You must select a heat number", "Select a heat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatNumber.Focus()
            Return False
        End If
        If cboHeatNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid heat number", "Enter a valid heat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatNumber.SelectAll()
            cboHeatNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboPartNumber.Text) Then
            MessageBox.Show("You must select a part number", "Select a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.Focus()
            Return False
        End If
        If cboPartNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid part number", "Enter a valid part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.SelectAll()
            cboPartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPartDescription.Text) Then
            getPartDescription()
        End If
        If NominalDiameter.Equals(0) Then
            MessageBox.Show("Nominal diameter in the item maintenance is 0. Unable to complete the pull test until it has been changed.", "Unable to complete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If NominalLength.Equals(0) Then
            MessageBox.Show("Nominal length in item maintenance is 0. Unable to complete the pull test until it has been changed.", "Unable to compelte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboPartNumber.Text.StartsWith("PSR") Or cboPartNumber.Text.StartsWith("PSD") Then
            If String.IsNullOrEmpty(cboProcessType.Text) Then
                cmd = New SqlCommand("DECLARE @ProcessID as varchar(50) = CASE WHEN EXISTS(SELECT isnull(ProcessID, 'NONE') FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = 1) THEN (SELECT isnull(ProcessID, 'NONE') FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = 1) ELSE (SELECT 'NONE') END; DECLARE @ProcessType as varchar(5) = CASE WHEN (@ProcessID = '098' OR @ProcessID = '099') THEN (SELECT 'HOT') ELSE (SELECT 'COLD') END; SELECT @ProcessType;", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd.ExecuteScalar()
                con.Close()
                If obj IsNot Nothing Then
                    cboProcessType.Text = obj.ToString()
                End If
                If String.IsNullOrEmpty(cboProcessType.Text) Then
                    MessageBox.Show("You must select if the stud was HOT or COLD FORMED", "Select a process type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboProcessType.Focus()
                    Return False
                End If
            End If
            If Not cboProcessType.Text.Equals("HOT") And Not cboProcessType.Text.Equals("COLD") Then
                MessageBox.Show("You must enter a valid process type HOT or COLD", "Enter a valid process type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboProcessType.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtTorqueTest.Text) Or txtTorqueTest.Text.Equals("0") Then
            If String.IsNullOrEmpty(txtArea.Text) Then
                MessageBox.Show("You must enter a cross-section area", "Enter a cross-section area", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtArea.Focus()
                Return False
            End If
            If IsNumeric(txtArea.Text) = False Then
                MessageBox.Show("You must enter a numeric cross-section area", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtArea.SelectAll()
                txtArea.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtYield2Pound.Text) Then
                MessageBox.Show("You must enter a yield 2% pound", "Enter a yield 2% pound", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtYield2Pound.Focus()
                Return False
            End If
            If IsNumeric(txtYield2Pound.Text) = False Then
                MessageBox.Show("You must enter a numeric yield 2% pound", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtYield2Pound.SelectAll()
                txtYield2Pound.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtUltimatePounds.Text) Then
                MessageBox.Show("You must enter an ultimate pounds", "Enter an ultimate pounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUltimatePounds.Focus()
                Return False
            End If
            If IsNumeric(txtUltimatePounds.Text) = False Then
                MessageBox.Show("You must enter a numeric ultimate pounds", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUltimatePounds.SelectAll()
                txtUltimatePounds.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtElongation.Text) Then
                MessageBox.Show("You must enter an elongation", "Enter an elongation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtElongation.Focus()
                Return False
            End If
            If IsNumeric(txtElongation.Text) = False Then
                MessageBox.Show("You must enter a numeric elongation", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtElongation.SelectAll()
                txtElongation.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtReductionDiameter.Text) Then
                MessageBox.Show("You must enter a reduction diameter", "Enter a reduction diameter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReductionDiameter.Focus()
                Return False
            End If
            If IsNumeric(txtReductionDiameter.Text) = False Then
                MessageBox.Show("You must enter a numeric reduction diameter", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReductionDiameter.SelectAll()
                txtReductionDiameter.Focus()
                Return False
            End If
        Else
            If String.IsNullOrEmpty(txtTorqueTest.Text) Then
                MessageBox.Show("You must enter a torque", "Enter a torque", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTorqueTest.Focus()
                Return False
            End If
            If IsNumeric(txtTorqueTest.Text) = False Then
                MessageBox.Show("You must enter a numeric toque", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTorqueTest.SelectAll()
                txtTorqueTest.Focus()
                Return False
            End If
        End If

        If String.IsNullOrEmpty(cboBreakLocation.Text) Then
            MessageBox.Show("You must enter a break location", "Enter a break location", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBreakLocation.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(cboBendTest.Text) Then
            If cboBendTest.SelectedIndex = -1 Then
                MessageBox.Show("You must select PASSED or FAILED for Bend Test", "Select a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboBendTest.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtTestedBy.Text) Then
            MessageBox.Show("You must enter a name for tested by", "Enter a name for tested by", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTestedBy.Focus()
            Return False
        End If
        If retrieveRMID() = False Then
            Return False
        End If
        cmd = New SqlCommand("SELECT PullTestLineNumber FROM PullTestLineTable WHERE (BreakLocation = '' or BreakLocation = null) AND PullTestNumber = @PullTestNumber;", con)
        cmd.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            Dim testNumbers As String = ""
            While reader.Read()
                If Not String.IsNullOrEmpty(testNumbers) Then
                    testNumbers += " and "
                End If
                testNumbers += reader.Item("PullTestLineNumber").ToString()
            End While
            reader.Close()
            con.Close()
            MessageBox.Show("Unable to Finish. Test number(s) " + testNumbers + " do not have a break point or pass/fail for bend test. Check results and try again.", "Unable to finish", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        reader.Close()
        cmd.CommandText = "SELECT PullTestLineNumber FROM PullTestLineTable WHERE (CrossSectionalArea = 0 or CrossSectionalArea = null) AND pulltestNumber = @PullTestNumber;"
        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()
        If reader.HasRows Then
            Dim testNumbers As String = ""
            While reader.Read()
                If Not String.IsNullOrEmpty(testNumbers) Then
                    testNumbers += " and "
                End If
                testNumbers += reader.Item("PullTestLineNumber").ToString()
            End While
            reader.Close()
            con.Close()
            MessageBox.Show("Unable to Finish. Test number(s) " + testNumbers + " do not have a valid Cross Sectional Area. Check results and try again.", "Unable to finish", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        reader.Close()
        If CurrentCertRequirements.MinimumTensile <> 0 Then
            cmd.CommandText = "SELECT PullTestLineNumber FROM PullTestLineTable WHERE (UltimateYieldPSI = 0 or UltimateYieldPSI = null or UltimateYieldPSI = @Requirement) AND PullTestNumber = @PullTestNumber;"
            cmd.Parameters.Add("@Requirement", SqlDbType.Float).Value = CurrentCertRequirements.MinimumTensile
            If con.State = ConnectionState.Closed Then con.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim testNumbers As String = ""
                While reader.Read()
                    If Not String.IsNullOrEmpty(testNumbers) Then
                        testNumbers += " and "
                    End If
                    testNumbers += reader.Item("PullTestLineNumber").ToString()
                End While
                reader.Close()
                con.Close()
                MessageBox.Show("Unable to Finish. Test number(s) " + testNumbers + " do not have a valid Cross Ultimate PSI for Certification Type. Check results and try again.", "Unable to finish", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            reader.Close()
        End If
        If CurrentCertRequirements.MinimumYeild <> 0 Then
            cmd.CommandText = "SELECT PullTestLineNumber FROM PullTestLineTable WHERE (Yield2PercentPSI = 0 or Yield2PercentPSI = null or Yield2PercentPSI = @Requirement) AND PullTestNumber = @PullTestNumber;"
            cmd.Parameters("@Requirement").Value = CurrentCertRequirements.MinimumYeild
            If con.State = ConnectionState.Closed Then con.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim testNumbers As String = ""
                While reader.Read()
                    If Not String.IsNullOrEmpty(testNumbers) Then
                        testNumbers += " and "
                    End If
                    testNumbers += reader.Item("PullTestLineNumber").ToString()
                End While
                reader.Close()
                con.Close()
                MessageBox.Show("Unable to Finish. Test number(s) " + testNumbers + " do not have a valid Yield 2% PSI for Certification Type. Check results and try again.", "Unable to finish", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            reader.Close()
        End If
        If CurrentCertRequirements.ReductionOfAreaPercent <> 0 Then
            cmd.CommandText = "SELECT PullTestLineNumber FROM PullTestLineTable WHERE (ReductionPercent = 0 or ReductionPercent = null or ReductionPercent < @Requirement) AND PullTestNumber = @PullTestNumber;"
            cmd.Parameters("@Requirement").Value = CurrentCertRequirements.ReductionOfAreaPercent
            If con.State = ConnectionState.Closed Then con.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim testNumbers As String = ""
                While reader.Read()
                    If Not String.IsNullOrEmpty(testNumbers) Then
                        testNumbers += " and "
                    End If
                    testNumbers += reader.Item("PullTestLineNumber").ToString()
                End While
                reader.Close()
                con.Close()
                MessageBox.Show("Unable to Finish. Test number(s) " + testNumbers + " do not have a valid Reduction percent for Certification Type. Check results and try again.", "Unable to finish", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            reader.Close()
        End If
        If CurrentCertRequirements.ElongationPercent <> 0 Then
            cmd.CommandText = "SELECT PullTestLineNumber FROM PullTestLineTable WHERE (Elongation2Percent = 0 or Elongation2Percent = null or Elongation2Percent < @Requirement) AND PullTestNumber = @PullTestNumber;"
            cmd.Parameters("@Requirement").Value = CurrentCertRequirements.ElongationPercent
            If con.State = ConnectionState.Closed Then con.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim testNumbers As String = ""
                While reader.Read()
                    If Not String.IsNullOrEmpty(testNumbers) Then
                        testNumbers += " and "
                    End If
                    testNumbers += reader.Item("PullTestLineNumber").ToString()
                End While
                reader.Close()
                con.Close()
                MessageBox.Show("Unable to Finish. Test number(s) " + testNumbers + " do not have a valid Elongation percent for Certification Type. Check results and try again.", "Unable to finish", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            reader.Close()
        End If
        If con.State = ConnectionState.Open Then con.Close()
        Return True
    End Function

    Private Function retrieveRMID() As Boolean
        cmd = New SqlCommand("SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @Size;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtSteelTypeFromHeat.Text
        cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = txtSteelSizeFromHeat.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            RMID = cmd.ExecuteScalar()
        Catch ex As System.Exception
            con.Close()
            sendErrorToDataBase("PullTestData - retrieveRMID --Error trying to retrieve the RMID from the raw material table", "Test #" + cboPullTestNumber.Text, ex.ToString())
            MessageBox.Show("There was an error trying to save the pull test. Contact system admin", "Unable to save pull test", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
        Return True
    End Function

    Private Sub cmdGeneratePullTestNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGeneratePullTestNumber.Click
        'Clear Form on next number
        ClearVariables()
        ClearData()
        Dim beginDate As New DateTime
        Dim endDate As New DateTime
        beginDate = Convert.ToDateTime("1/1/" + dtpPullTestDate.Value.Date.Year.ToString())
        endDate = Convert.ToDateTime("12/31/" + dtpPullTestDate.Value.Date.Year.ToString())

        cmd = New SqlCommand("SELECT COUNT(TestNumber) as TestCount FROM PullTestData WHERE TestDate BETWEEN @BeginDate AND @EndDate;", con)
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = beginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = endDate

        Dim count As Integer = 0
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("TestCount")) = False Then
                count = reader.Item("TestCount")
            End If
        End If
        reader.Close()
        con.Close()
        count += 1

        Dim key As String = "TW" + dtpPullTestDate.Value.Date.Year.ToString.Substring(dtpPullTestDate.Value.Date.Year.ToString.Length - 2, 2) + "-"
        If count < 100 Then
            If count < 10 Then
                key += "00"
            Else
                key += "0"
            End If
        End If
        key += count.ToString()

        cmd = New SqlCommand("SELECT COUNT(TestNumber) as TestCount FROM PullTestData WHERE TestNumber = @TestNumber", con)
        cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = key

        If con.State = ConnectionState.Closed Then con.Open()

        While cmd.ExecuteScalar() <> 0
            count += 1
            key = "TW" + dtpPullTestDate.Value.Date.Year.ToString.Substring(dtpPullTestDate.Value.Date.Year.ToString.Length - 2, 2) + "-"
            If count < 100 Then
                If count < 10 Then
                    key += "00"
                Else
                    key += "0"
                End If
            End If
            key += count.ToString()

            cmd.Parameters("@TestNumber").Value = key
        End While

        cmd = New SqlCommand("INSERT INTO PullTestData(TestNumber, TestDate, DivisionID, Status)Values(@TestNumber, @TestDate, @DivisionID, 'OPEN');", con)
        cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = key
        cmd.Parameters.Add("@TestDate", SqlDbType.VarChar).Value = dtpPullTestDate.Value.Date.ToShortDateString()
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()

        cmd.ExecuteNonQuery()
        con.Close()

        isLoaded = False
        LoadPullTestNumber()
        cboPullTestNumber.Text = key
        isLoaded = True
    End Sub

    Private Sub cboPullTestNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPullTestNumber.SelectedIndexChanged
        If isLoaded Then
            LoadPullTestData()
            LoadTestData()
        End If
    End Sub

    Private Sub cboFOXNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOXNumber.SelectedIndexChanged
        If isLoaded Then
            LoadFOXData()
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            Try
                updateOrInsertIntoPullTestData()
            Catch ex As System.Exception
                sendErrorToDataBase("PullTestData - cmdSave_Click --Error trying to insert/update pull test data into PullTestData", "Test #" + cboPullTestNumber.Text, ex.ToString())
                MessageBox.Show("There was a problem trying to save the data, contact system admin.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function canSave() As Boolean
        If checkStatus() Then
            MessageBox.Show("Pull test is finalized, you can't save any changes", "Can't save changes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboPullTestNumber.Text) Then
            MessageBox.Show("You must enter a pull test number", "Enter a pull test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.Focus()
            Return False
        End If
        If cboPullTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid pull test number", "Enter a valid pull test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.SelectAll()
            cboPullTestNumber.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            If cboFOXNumber.SelectedIndex = -1 Then
                MessageBox.Show("You must select a valid FOX number", "Select a valid FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboFOXNumber.SelectAll()
                cboFOXNumber.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            If cboHeatNumber.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid heat number", "Enter a valid heat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboHeatNumber.SelectAll()
                cboHeatNumber.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            If cboPartNumber.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid part number", "Enter a valid part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboPartNumber.SelectAll()
                cboPartNumber.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtPartDescription.Text) Then
                getPartDescription()
            End If
        End If
        If Not cboPartNumber.Text.StartsWith("TT") And Not cboPartNumber.Text.StartsWith("TP") Then
            If Not String.IsNullOrEmpty(cboBendTest.Text) Then
                If cboBendTest.SelectedIndex = -1 Then
                    MessageBox.Show("You must select PASSED or FAILED for Bend Test", "Select a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboBendTest.Focus()
                    Return False
                End If
            End If
        End If
        If String.IsNullOrEmpty(txtRMIDFromHeat.Text) Then
            MessageBox.Show("You must enter a valid steel.", "Enter a valid steel.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTestedBy.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTestedBy.Text) Then
            MessageBox.Show("You must enter a name for tested by", "Enter a name for tested by", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTestedBy.Focus()
            Return False
        End If
        'Make sure only one heat file number is checked in the datagrid
        For Each LineRow As DataGridViewRow In dgvHeatFileTable.Rows

            Dim LineCell As DataGridViewCheckBoxCell = LineRow.Cells("CheckBoxColumn")

            If LineCell.Value = "CHECKED" Then
                CountCheckedItems = CountCheckedItems + 1
            Else
                'Do nothing
            End If
        Next
        If CountCheckedItems = 1 Then
            'Do nothing
        Else
            MessageBox.Show("You must select one heat file number only.", "SELECT ONLY ONE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CountCheckedItems = 0
            Return False
        End If

        Return True
    End Function

    Private Sub getPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShortDescription")) = False Then
                txtPartDescription.Text = reader.Item("ShortDescription")
            End If
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub SaveDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDelete() Then
            Try
                'Delete Data to Pull Test Table
                cmd = New SqlCommand("DELETE FROM PullTestData  WHERE TestNumber = @TestNumber;", con)
                cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("PullTestData - cmdDelete_Click --Error trying to delete pull test", "Test #" + cboPullTestNumber.Text, ex.ToString())
                MessageBox.Show("Unable to delete pull test. Contact system admin", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ClearVariables()
            ClearData()
            isLoaded = False
            LoadPullTestNumber()
            isLoaded = True
            MsgBox("This Pull Test has been deleted", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canDelete() As Boolean
        If checkStatus() Then
            MessageBox.Show("You can't delete a finished pull test", "Can't delete pull test", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboPullTestNumber.Text) Then
            MessageBox.Show("You must enter a pull test number", "Enter a pull test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.Focus()
            Return False
        End If
        If cboPullTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid pull test number", "Enter a valid pull test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.SelectAll()
            cboPullTestNumber.Focus()
            Return False
        End If
        'Prompt before Deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this pull test?", "Delete pull test", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub DeleteDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteDataToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isLoaded Then
            LoadPartData()
            ''loads the FOX number if part number switched by user
            If cboPartNumber.Focused() Then
                cmd = New SqlCommand("SELECT TOP 1 FOXNumber FROM FOXTable WHERE PartNumber = @PartNumber AND Status = 'ACTIVE';", con)
                cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    FOXNumber = reader.Item("FOXNumber")
                Else
                    FOXNumber = ""
                End If
                reader.Close()
                con.Close()
                cboFOXNumber.Text = FOXNumber
            End If
            If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
                If cboPartNumber.Text.StartsWith("PSR") Or cboPartNumber.Text.StartsWith("PSD") Then
                    lblProcessType.Show()
                    cmd = New SqlCommand("DECLARE @ProcessID as varchar(50) = CASE WHEN EXISTS(SELECT isnull(ProcessID, 'NONE') FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = 1) THEN (SELECT isnull(ProcessID, 'NONE') FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = 1) ELSE (SELECT 'NONE') END; DECLARE @ProcessType as varchar(5) = CASE WHEN (@ProcessID = '098' OR @ProcessID = '099') THEN (SELECT 'HOT') ELSE (SELECT 'COLD') END; SELECT @ProcessType;", con)
                    cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = cboFOXNumber.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim obj As Object = cmd.ExecuteScalar()
                    con.Close()
                    If obj IsNot Nothing Then
                        cboProcessType.Text = obj.ToString()
                    End If
                    cboProcessType.Show()
                Else
                    lblProcessType.Hide()
                    cboProcessType.Hide()
                    cboProcessType.SelectedIndex = -1
                    If Not String.IsNullOrEmpty(cboProcessType.Text) Then
                        cboProcessType.Text = ""
                    End If
                End If
            Else
                lblProcessType.Hide()
                cboProcessType.Hide()
                cboProcessType.SelectedIndex = -1
                If Not String.IsNullOrEmpty(cboProcessType.Text) Then
                    cboProcessType.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isLoaded Then
            LoadPartData()
        End If
    End Sub

    Private Sub cboCertificationType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isLoaded Then
            LoadCertDescription()
        End If
    End Sub

    Private Sub cmdSteelTolerances_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSteelTolerances.Click
        GlobalSteelCarbon = txtSteelTypeFromHeat.Text
        Using NewSteelTolerances As New SteelTolerances
            Dim result = NewSteelTolerances.ShowDialog()
        End Using
    End Sub

    Private Sub cmdViewMillCertData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewMillCertData.Click

        GlobalHeatFileNumber = Val(cboHeatNumber.Text)

        Using NewMillCertForm As New MillCertForm()
            Dim result = NewMillCertForm.ShowDialog()
        End Using
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded Then
            isLoaded = False
            LoadPullTestNumber()
            LoadFOXNumber()
            LoadPartNumber()
            LoadHeatNumber()
            isLoaded = True
        End If
    End Sub

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
            .Add("@Division", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub updateOrInsertIntoPullTestData(Optional ByVal status As String = "OPEN")
        Dim itmCls As String = getItemClass()
        GetHeatFileNumber()

        cmd = New SqlCommand("IF EXISTS(SELECT TestNumber FROM PullTestData WHERE TestNumber = @TestNumber AND DivisionID = @DivisionID)UPDATE PullTestData SET TestDate = @TestDate, FOXNumber = @FOXNumber, PartNumber = @PartNumber, NominalDiameter = @NominalDiameter, NominalLength = @NominalLength, PartDescription = @PartDescription, HeatNumber = @HeatNumber, HeatFileNumber = @HeatFileNumber, TestedBy = @TestedBy, Comment = @Comment, RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), OldTestNumber = @OldTestNumber, OldPartNumber = @OldPartNumber, Status = @Status, ItemClass = @ItemClass, BendTest = @BendTest, ProcessType = @ProcessType WHERE TestNumber = @TestNumber AND DivisionID = @DivisionID ELSE Insert Into PullTestData(TestNumber, TestDate, FOXNumber, PartNumber, NominalDiameter, NominalLength, PartDescription, HeatNumber, HeatFileNumber, RMID, TestedBy, Comment, DivisionID, OldTestNumber, OldPartNumber, ItemClass, Status, BendTest, ProcessType)Values(@TestNumber, @TestDate, @FOXNumber, @PartNumber, @NominalDiameter, @NominalLength, @PartDescription, @HeatNumber, @HeatFileNumber, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @TestedBy, @Comment, @DivisionID, @OldTestNumber, @OldPartNumber, @ItemClass, @Status, @BendTest, @ProcessType);", con)

        If status.Equals("CLOSED") Then
            cmd.CommandText += " UPDATE PullTestLog SET PullTestNumber = @TestNumber WHERE ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND NominalLength <= @NominalLength AND HeatNumber = @HeatNumber and PullTestNumber is null"
        End If
        'Write Data to Pull Test Table
        With cmd.Parameters
            .Add("@TestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text
            .Add("@TestDate", SqlDbType.VarChar).Value = dtpPullTestDate.Text
            .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@NominalDiameter", SqlDbType.VarChar).Value = NominalDiameter
            .Add("@NominalLength", SqlDbType.VarChar).Value = NominalLength
            .Add("@PartDescription", SqlDbType.VarChar).Value = txtPartDescription.Text
            .Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            .Add("@HeatFileNumber", SqlDbType.VarChar).Value = HeatFileNumber
            .Add("@Carbon", SqlDbType.VarChar).Value = txtSteelTypeFromHeat.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeFromHeat.Text
            .Add("@TestedBy", SqlDbType.VarChar).Value = txtTestedBy.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@OldTestNumber", SqlDbType.VarChar).Value = txtOldTestNumber.Text
            .Add("@OldPartNumber", SqlDbType.VarChar).Value = txtOldPartNumber.Text
            .Add("@ItemClass", SqlDbType.VarChar).Value = itmCls
            .Add("@Status", SqlDbType.VarChar).Value = status
            .Add("@BendTest", SqlDbType.VarChar).Value = cboBendTest.Text
            .Add("@ProcessType", SqlDbType.VarChar).Value = cboProcessType.Text
        End With
        If cboPartNumber.Text.StartsWith("PSR") Or cboPartNumber.Text.StartsWith("PSD") Then
            cmd.Parameters("@ProcessType").Value = cboProcessType.Text
        Else
            cmd.Parameters("@ProcessType").Value = ""
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        If Not status.Equals("CLOSED") Then
            MsgBox("This data has been saved", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function getItemClass() As String
        cmd = New SqlCommand("SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim itmClass As String = ""

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            itmClass = cmd.ExecuteScalar()
        Catch ex As System.Exception

        End Try
        con.Close()
        If String.IsNullOrEmpty(itmClass) Then
            Return " "
        End If
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
                Return itmClass
            Case "TW PS"
                Return itmClass
            Case "TW FER"
                Return itmClass
            Case "TW SWR"
                Return itmClass
            Case "TW HSR"
                Return itmClass
            Case Else
                Return "TW TT"
        End Select
        Return itmClass
    End Function

    Private Sub txtYield2Pound_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYield2Pound.TextChanged
        If isLoaded Then
            txtYield2Pound_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtUltimatePounds_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUltimatePounds.TextChanged
        If isLoaded Then
            txtUltimatePounds_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtElongation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtElongation.TextChanged
        If isLoaded Then
            txtElongation_LostFocus(sender, e)
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

        Using NewPrintPullTest As New PrintPullTest(cboPullTestNumber.Text)
            Dim Result = NewPrintPullTest.ShowDialog()
        End Using
    End Sub

    Private Function getNumber(ByVal itm As String) As Double
        If Not itm.Contains("/") Then
            Return Val(itm)
        End If
        Dim fnlNumber As Double = 0.0
        If itm.Contains("/") Then
            Dim spl As String() = itm.Split(New String() {"/"}, StringSplitOptions.None)
            If spl(0).Contains("-") Then
                Dim spl2 As String() = spl(0).Split(New String() {"-"}, StringSplitOptions.None)
                spl(0) = Val(spl2(0)) * Val(spl(1)) + Val(spl2(1))
            End If
            Return Val(spl(0)) / Val(spl(1))
        End If
        Return 0
    End Function

    Private Sub checkTensileBelow()
        Dim tensile As Double = 0
        If txtUltimatePSI.Text.Contains(",") Then
            Dim spl As String() = txtUltimatePSI.Text.Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)
            Dim recon As String = ""
            For i As Integer = 0 To spl.Count - 1
                recon += spl(i)
            Next
            tensile = Val(recon)
        Else
            tensile = Val(txtUltimatePSI.Text)
        End If
        If CurrentCertRequirements.MinimumTensile = 0 Then
            If txtSteelTypeFromHeat.Text.Length > 0 Then
                Select Case True
                    Case String.IsNullOrEmpty(txtSteelTypeFromHeat.Text)
                        lblTensileBelow.Text = ""
                    Case (Not txtSteelTypeFromHeat.Text.Contains("SS") And tensile < 65000)
                        lblTensileBelow.Text = "Tensile below AWS Minimum"
                    Case (Not txtSteelTypeFromHeat.Text.Contains("SS") And tensile < 72000)
                        lblTensileBelow.Text = "Tensile below BS 5400 Minimum"
                    Case (txtSteelTypeFromHeat.Text.Contains("SS") And tensile < 70000)
                        lblTensileBelow.Text = "Tensile below AWS Minimum"
                    Case Else
                        lblTensileBelow.Text = ""
                End Select
            End If
        Else
            If tensile < CurrentCertRequirements.MinimumTensile Then
                lblTensileBelow.Text = "Tensile PSI is below Certification Type standards of " + CurrentCertRequirements.MinimumTensile.ToString()
            Else
                lblTensileBelow.Text = ""
            End If
        End If

    End Sub

    Private Sub checkYieldBelow()
        Dim yield As Double = 0
        If txtYield2PSI.Text.Contains(",") Then
            Dim spl As String() = txtYield2PSI.Text.Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)
            Dim recon As String = ""
            For i As Integer = 0 To spl.Count - 1
                recon += spl(i)
            Next
            yield = Val(recon)
        Else
            yield = Val(txtYield2PSI.Text)
        End If
        If CurrentCertRequirements.MinimumYeild = 0 Then
            If txtSteelTypeFromHeat.Text.Length > 0 Then
                Select Case True
                    Case String.IsNullOrEmpty(txtSteelTypeFromHeat.Text)
                        lblYieldBelow.Text = ""
                    Case (Not txtSteelTypeFromHeat.Text.Contains("SS") And yield < 51000)
                        lblYieldBelow.Text = "Yield PSI Below AWS Minimum"
                    Case (Not txtSteelTypeFromHeat.Text.Contains("SS") And yield < 56000)
                        lblYieldBelow.Text = "Yield PSI Below BS 5400 Minimum"
                    Case (txtSteelTypeFromHeat.Text.Contains("SS") And yield < 35000)
                        lblYieldBelow.Text = "Yield PSI Below AWS Minimum"
                    Case Else
                        lblYieldBelow.Text = ""
                End Select
            Else
                lblYieldBelow.Text = ""
            End If
        Else
            If yield < CurrentCertRequirements.MinimumYeild Then
                lblYieldBelow.Text = "Yield PSI Below Certification Type standards of " + CurrentCertRequirements.MinimumYeild.ToString()
            Else
                lblYieldBelow.Text = ""
            End If
        End If

    End Sub

    Private Sub checkReductionBelow()
        If CurrentCertRequirements.ReductionOfAreaPercent = 0 Then
            If txtSteelTypeFromHeat.Text.Length > 0 And txtReductionPercent.Text.Length > 0 Then
                If cboPartNumber.Text.StartsWith("TT") Or cboPartNumber.Text.StartsWith("TP") Then
                    ''will skip adding in the text since it is a threaded stud unless there is a value other than 0 entered
                    If Val(txtReductionDiameter.Text) = 0 Then
                        lblReductionBelow.Text = ""
                        Exit Sub
                    End If
                End If
                Select Case True
                    Case String.IsNullOrEmpty(txtSteelTypeFromHeat.Text)
                        lblReductionBelow.Text = ""
                    Case (Not txtSteelTypeFromHeat.Text.Contains("SS") And Val(txtReductionPercent.Text.Replace("%"c, "").Replace(","c, "")) < 50)
                        lblReductionBelow.Text = "Reduction Below AWS Minimum"
                    Case Else
                        lblReductionBelow.Text = ""
                End Select
            Else
                lblReductionBelow.Text = ""
            End If
        Else
            If Val(txtReductionPercent.Text.Replace("%"c, "").Replace(","c, "")) < CurrentCertRequirements.ReductionOfAreaPercent Then
                lblReductionBelow.Text = "Reduction Below Certification Type standards of " + CurrentCertRequirements.ReductionOfAreaPercent.ToString() + "%"
            Else
                lblReductionBelow.Text = ""
            End If
        End If

    End Sub

    Private Sub checkElongationBelow()
        If CurrentCertRequirements.ElongationPercent = 0 Then
            If txtSteelTypeFromHeat.Text.Length > 0 And txtElongationPercent.Text.Length > 0 Then
                If cboPartNumber.Text.StartsWith("TT") Or cboPartNumber.Text.StartsWith("TP") Then
                    ''will skip adding in the text since it is a threaded stud unless there is a value other than 0 entered
                    If Val(txtElongation.Text) = 0 Then
                        lblElongationBelow.Text = ""
                        Exit Sub
                    End If
                End If
                Select Case True
                    Case String.IsNullOrEmpty(txtSteelTypeFromHeat.Text)
                        lblElongationBelow.Text = ""
                    Case (Not txtSteelTypeFromHeat.Text.Contains("SS") And Val(txtElongationPercent.Text.Replace("%"c, "").Replace(","c, "")) < 20)
                        lblElongationBelow.Text = "Elongation Below AWS Minimum"
                    Case (txtSteelTypeFromHeat.Text.Contains("SS") And Val(txtElongationPercent.Text.Replace("%"c, "").Replace(","c, "")) < 40)
                        lblElongationBelow.Text = "Elongation Below AWS Minimum"
                    Case Else
                        lblElongationBelow.Text = ""
                End Select
            Else
                lblElongationBelow.Text = ""
            End If
        Else
            If Val(txtElongationPercent.Text.Replace("%"c, "").Replace(","c, "")) < CurrentCertRequirements.ElongationPercent Then
                lblElongationBelow.Text = "Elongation Below Certificaiton Type standards of " + CurrentCertRequirements.ElongationPercent.ToString() + "%"
            Else
                lblElongationBelow.Text = ""
            End If
        End If

    End Sub

    Private Sub txtYield2PSI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYield2PSI.TextChanged
        checkYieldBelow()
    End Sub

    Private Sub txtUltimatePSI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUltimatePSI.TextChanged
        checkTensileBelow()
    End Sub

    Private Sub txtElongationPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtElongationPercent.TextChanged
        checkElongationBelow()
    End Sub

    Private Sub txtReductionPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReductionPercent.TextChanged
        checkReductionBelow()
    End Sub

    Private Sub cmdClearTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearTest.Click
        clearTestArea()
    End Sub

    Private Sub cmdSaveTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveTest.Click
        If canSaveTest() Then
            If insertOrUpdateTestData() Then
                MessageBox.Show("Test data has been saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Function canSaveTest() As Boolean
        If String.IsNullOrEmpty(cboPullTestNumber.Text) Then
            MessageBox.Show("You must select a Pull Test Number to save test.", "Select a Pull Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.Focus()
            Return False
        End If
        If cboPullTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Pull Test Number", "Enter a valid Pull Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.SelectAll()
            cboPullTestNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must select a test number", "Select a test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test Number", "Enter a valid Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTorqueTest.Text) Or txtTorqueTest.Text.Equals("0") Then
            If String.IsNullOrEmpty(txtArea.Text) = False Then
                If IsNumeric(txtArea.Text) = False Then
                    MessageBox.Show("You must enter a numeric cross-section area", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtArea.SelectAll()
                    txtArea.Focus()
                    Return False
                End If
                If Val(txtArea.Text) = 0 Then
                    MessageBox.Show("You must enter a value greater than 0 for cross sectional area.", "unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtArea.SelectAll()
                    txtArea.Focus()
                    Return False
                End If
            End If

            If String.IsNullOrEmpty(txtYield2Pound.Text) = False Then
                If IsNumeric(txtYield2Pound.Text) = False Then
                    MessageBox.Show("You must enter a numeric yield 2% pound", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtYield2Pound.SelectAll()
                    txtYield2Pound.Focus()
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(txtUltimatePounds.Text) = False Then
                If IsNumeric(txtUltimatePounds.Text) = False Then
                    MessageBox.Show("You must enter a numeric ultimate pounds", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUltimatePounds.SelectAll()
                    txtUltimatePounds.Focus()
                    Return False
                End If
            End If
            If Not cboPartNumber.Text.StartsWith("TT") And Not cboPartNumber.Text.StartsWith("TP") Then
                If String.IsNullOrEmpty(txtElongation.Text) = False Then
                    If IsNumeric(txtElongation.Text) = False Then
                        MessageBox.Show("You must enter a numeric elongation", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtElongation.SelectAll()
                        txtElongation.Focus()
                        Return False
                    End If
                End If
                If String.IsNullOrEmpty(txtReductionDiameter.Text) Or txtReductionDiameter.Text.Equals("0") Then
                    If MessageBox.Show("Reduction Diameter was not entered or is 0, do you wish to save?", "Save with out Reduction Diameter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                        txtReductionDiameter.SelectAll()
                        txtReductionDiameter.Focus()
                        Return False
                    End If
                End If
            End If

        Else
            If IsNumeric(txtTorqueTest.Text) = False Then
                MessageBox.Show("You must enter a numeric toque", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTorqueTest.SelectAll()
                txtTorqueTest.Focus()
                Return False
            End If
        End If

        If String.IsNullOrEmpty(cboBreakLocation.Text) Then
            MessageBox.Show("You must select a Break Location", "Select a Break Location", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBreakLocation.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function insertOrUpdateTestData() As Boolean
        cmd = New SqlCommand("IF EXISTS(SELECT PullTestLineNumber FROM PullTestLineTable WHERE PullTestNumber = @PullTestNumber AND PullTestLineNumber = @PullTestLineNumber) UPDATE PullTestLineTable SET CrossSectionalArea = @CrossSectionalArea, Yield2PercentPound = @Yield2PercentPound, Yield2PercentPSI = @Yield2PercentPSI, UltimateYieldPound = @UltimateYieldPound, UltimateYieldPSI = @UltimateYieldPSI, Elongation2Inch = @Elongation2Inch, Elongation2Percent = @Elongation2Percent, Reduction2Inch = @Reduction2Inch, ReductionPercent = @ReductionPercent, TorqueFootPounds = @TorqueFootPounds, BreakLocation = @BreakLocation WHERE PullTestNumber = @PullTestNumber AND PullTestLineNumber = @PullTestLineNumber ELSE INSERT INTO PullTestLineTable (PullTestNumber, PullTestLineNumber, CrossSectionalArea, Yield2PercentPound, Yield2PercentPSI, UltimateYieldPound, UltimateYieldPSI, Elongation2Inch, Elongation2Percent, Reduction2Inch, ReductionPercent, TorqueFootPounds, BreakLocation) VALUES (@PullTestNumber, @PullTestLineNumber, @CrossSectionalArea, @Yield2PercentPound, @Yield2PercentPSI, @UltimateYieldPound, @UltimateYieldPSI, @Elongation2Inch, @Elongation2Percent, @Reduction2Inch, @ReductionPercent, @TorqueFootPounds, @BreakLocation);", con)

        With cmd.Parameters
            .Add("@PullTestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text
            .Add("@PullTestLineNumber", SqlDbType.VarChar).Value = Val(cboTestNumber.Text)
            .Add("@CrossSectionalArea", SqlDbType.VarChar).Value = Val(txtArea.Text)
            .Add("@Yield2PercentPound", SqlDbType.VarChar).Value = Val(txtYield2Pound.Text)
            .Add("@Yield2PercentPSI", SqlDbType.VarChar).Value = Val(txtYield2PSI.Text)
            .Add("@UltimateYieldPound", SqlDbType.VarChar).Value = Val(txtUltimatePounds.Text)
            .Add("@UltimateYieldPSI", SqlDbType.VarChar).Value = Val(txtUltimatePSI.Text)
            .Add("@Elongation2Inch", SqlDbType.VarChar).Value = Val(txtElongation.Text)
            .Add("@Elongation2Percent", SqlDbType.VarChar).Value = Val(txtElongationPercent.Text.Replace("%"c, "").Replace(","c, ""))
            .Add("@Reduction2Inch", SqlDbType.VarChar).Value = Val(txtReductionArea.Text)
            .Add("@ReductionPercent", SqlDbType.VarChar).Value = Val(txtReductionPercent.Text.Replace("%"c, "").Replace(","c, ""))
            .Add("@TorqueFootPounds", SqlDbType.VarChar).Value = Val(txtTorqueTest.Text)
            .Add("@BreakLocation", SqlDbType.VarChar).Value = cboBreakLocation.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            con.Close()
            sendErrorToDataBase("PullTestData - InsertTestData --Error trying to insert into PullTestLineTable, Test #" + cboTestNumber.Text, "Pull Test #" + cboPullTestNumber.Text, ex.ToString())
            MessageBox.Show("There was an error trying to insert the test data. Check information and try again, if problem persists contact ssytem admin.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
        Return True
    End Function

    Private Sub cboTestNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTestNumber.SelectedIndexChanged
        If isLoaded Then
            LoadTestData()
            If Val(txtArea.Text) = 0 Then
                calculateArea()
            End If
        End If
    End Sub

    Private Sub LoadTestData()
        Dim ReductionPercent As Double = 0
        cmd = New SqlCommand("SELECT CrossSectionalArea, Yield2PercentPound, Yield2PercentPSI, UltimateYieldPound, UltimateYieldPSI, Elongation2Inch, Elongation2Percent, Reduction2Inch, ReductionPercent, TorqueFootPounds, BreakLocation FROM PullTestLineTable WHERE PullTestNumber = @PullTestNumber AND PullTestLineNumber = @PullTestLineNumber;", con)
        cmd.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text
        cmd.Parameters.Add("@PullTestLineNumber", SqlDbType.VarChar).Value = cboTestNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CrossSectionalArea")) Then
                CrossSectionalArea = 0
            Else
                CrossSectionalArea = reader.Item("CrossSectionalArea")
            End If
            If IsDBNull(reader.Item("Yield2PercentPound")) Then
                Yield2PercentPound = 0
            Else
                Yield2PercentPound = reader.Item("Yield2PercentPound")
            End If
            If IsDBNull(reader.Item("Yield2PercentPSI")) Then
                YieldPSI = 0
            Else
                YieldPSI = reader.Item("Yield2PercentPSI")
            End If
            If IsDBNull(reader.Item("UltimateYieldPound")) Then
                UltimateYieldPound = 0
            Else
                UltimateYieldPound = reader.Item("UltimateYieldPound")
            End If
            If IsDBNull(reader.Item("UltimateYieldPSI")) Then
                UltimatePSI = 0
            Else
                UltimatePSI = reader.Item("UltimateYieldPSI")
            End If
            If IsDBNull(reader.Item("Elongation2Inch")) Then
                Elongation2Inch = 0
            Else
                Elongation2Inch = reader.Item("Elongation2Inch")
            End If
            If IsDBNull(reader.Item("Elongation2Percent")) Then
                ElongPercent = 0
            Else
                ElongPercent = reader.Item("Elongation2Percent")
            End If
            If IsDBNull(reader.Item("Reduction2Inch")) Then
                Reduction2Inch = 0
            Else
                Reduction2Inch = reader.Item("Reduction2Inch")
            End If
            If IsDBNull(reader.Item("ReductionPercent")) Then
                ReductionPercent = 0
            Else
                ReductionPercent = reader.Item("ReductionPercent")
            End If
            If IsDBNull(reader.Item("TorqueFootPounds")) Then
                TorqueFootPounds = 0
            Else
                TorqueFootPounds = reader.Item("TorqueFootPounds")
            End If
            If IsDBNull(reader.Item("BreakLocation")) Then
                cboBreakLocation.Text = ""
            Else
                cboBreakLocation.Text = reader.Item("BreakLocation")
            End If
        Else
            CrossSectionalArea = 0
            Yield2PercentPound = 0
            YieldPSI = 0
            UltimateYieldPound = 0
            UltimatePSI = 0
            Elongation2Inch = 0
            Reduction2Inch = 0
            TorqueFootPounds = 0
            cboBreakLocation.Text = ""
        End If
        reader.Close()
        con.Close()

        isLoaded = False
        txtArea.Text = Math.Round(CrossSectionalArea, 5)
        txtYield2Pound.Text = Yield2PercentPound.ToString()
        txtYield2PSI.Text = YieldPSI.ToString()
        txtUltimatePounds.Text = UltimateYieldPound.ToString()
        txtUltimatePSI.Text = UltimatePSI.ToString()
        txtElongation.Text = Elongation2Inch.ToString()
        txtElongationPercent.Text = FormatNumber(ElongPercent) + "%"
        txtReductionArea.Text = Reduction2Inch.ToString()
        If Reduction2Inch <> 0 Then
            Dim reducDiam As Double = (Math.Sqrt(Reduction2Inch / 3.14159) * 2)
            txtReductionDiameter.Text = Math.Round(reducDiam, 3, MidpointRounding.AwayFromZero).ToString()
        Else
            txtReductionDiameter.Text = 0
        End If

        txtReductionPercent.Text = FormatNumber(ReductionPercent, 2) + "%"
        txtTorqueTest.Text = TorqueFootPounds.ToString()
        isLoaded = True
    End Sub

    Private Sub UnLockPullTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockPullTestToolStripMenuItem.Click
        cmd = New SqlCommand("UPDATE PullTestData SET Status = 'OPEN' WHERE TestNumber = @TestNumber;", con)
        cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        checkStatus()
    End Sub

    Private Sub cmdGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReloadData.Click
        If canGetData() Then
            pnlGetTestMessage.Show()
            bgwkGetTestData.RunWorkerAsync()
        End If
    End Sub

    Private Function canGetData() As Boolean
        If String.IsNullOrEmpty(cboPullTestNumber.Text) Then
            MessageBox.Show("You must enter a pull test number", "Enter a pull test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.Focus()
            Return False
        End If
        If cboPullTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid pull test number", "Enter a valid pull test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPullTestNumber.SelectAll()
            cboPullTestNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must enter a test number", "Enter a test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid test number", "Enter a valid test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDeleteTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteTest.Click
        If canDeleteTest() Then
            cmd = New SqlCommand("DELETE PullTestLineTable WHERE PullTestNumber = @PullTestNumber AND PullTestLineNumber = @PullTestLineNumber", con)
            cmd.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text
            cmd.Parameters.Add("@PullTestLineNumber", SqlDbType.Int).Value = Val(cboTestNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteNonQuery() <> 1 Then

            End If
            If cboTestNumber.Text <> "5" Then
                Dim start As Integer = Val(cboTestNumber.Text)
                cmd = New SqlCommand("if exists(SELECT PullTestLineNumber FROM PullTestLineTable WHERE PullTestNumber = @PullTestNumber AND PullTestLineNumber = @Current) UPDATE PullTestLineTable SET PullTestLineNumber = @NewNumber WHERE PullTestLineNumber = @Current AND PullTestNumber = @PullTestNumber;", con)
                cmd.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = cboPullTestNumber.Text
                cmd.Parameters.Add("@Current", SqlDbType.Int)
                cmd.Parameters.Add("@NewNumber", SqlDbType.Int)
                While start <> 5
                    cmd.Parameters("@Current").Value = start + 1
                    cmd.Parameters("@NewNumber").Value = start
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    start += 1
                End While
            End If
            con.Close()
            clearTestArea()
            If cboTestNumber.Text <> "1" Then
                cboTestNumber.Text = "1"
            Else
                LoadTestData()
            End If
        End If
    End Sub

    Private Function canDeleteTest() As Boolean
        If String.IsNullOrEmpty(cboPullTestNumber.Text) Then
            MessageBox.Show("You must select a pull test number", "Select a pull test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must select a Test Number to delete", "Select a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub cboTestNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTestNumber.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtArea_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtArea.KeyPress
        If Not controlKey And Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub txtArea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArea.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.Back Then
            controlKey = True
        End If
    End Sub

    Private Sub txtYield2Pound_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYield2Pound.KeyPress
        If Not controlKey And Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub txtYield2Pound_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYield2Pound.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.Back Then
            controlKey = True
        End If
    End Sub

    Private Sub txtUltimatePounds_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUltimatePounds.KeyPress
        If Not controlKey And Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub txtUltimatePounds_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUltimatePounds.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.Back Then
            controlKey = True
        End If
    End Sub

    Private Sub txtElongation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtElongation.KeyPress
        If Not controlKey And Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub txtElongation_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtElongation.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.Back Then
            controlKey = True
        End If
    End Sub

    Private Sub txtReductionDiameter_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReductionDiameter.KeyPress
        If Not controlKey And Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub txtReductionDiameter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReductionDiameter.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.Back Then
            controlKey = True
        End If
    End Sub

    Private Function GetYeildPSI(ByVal value As UploadEntries) As Double
        If Val(value.Item("Area")) = 0 Or Val(value.Item("Offset Force @ 0.2%(lbf)")) = 0 Then
            Return 0
        End If
        Return Math.Round(Val(value.Item("Offset Force @ 0.2%(lbf)")) / Val(value.Item("Area")), 2)
    End Function

    Private Function GetUltimatePSI(ByVal value As UploadEntries) As Double
        If Val(value.Item("Area")) = 0 Or Val(value.Item("Ultimate Force(lbf)")) = 0 Then
            Return 0
        End If
        Return Math.Round(Val(value.Item("Ultimate Force(lbf)")) / Val(value.Item("Area")), 2)
    End Function

    Private Function GetElongationPercent(ByVal value As UploadEntries) As Double
        If Val(value.Item("Gage Length (Final)(in)")) = 0 Then
            Return 0
        End If
        Return Math.Round((Val(value.Item("Gage Length (Final)(in)")) / 2) * 100, 2)
    End Function

    Private Function GetReductionPercent(ByVal value As UploadEntries) As Double
        If Val(value.Item("Area")) = 0 Or Val(value.Item("Area (Final)")) = 0 Then
            Return 0
        End If
        Return Math.Round(((Val(value.Item("Area")) - Val(value.Item("Area (Final)"))) / Val(value.Item("Area"))) * 100, 2)
    End Function

    Private Sub bgwkGetTestData_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkGetTestData.DoWork
        Try
            Dim Tests As New List(Of UploadEntries)
            Dim sleepCnt As Integer = 0
            ''check to see if the file exists
            While Not System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Tensile Export\Export.csv") And sleepCnt < 20
                System.Threading.Thread.Sleep(1000)
                sleepCnt += 1
            End While
            If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Tensile Export\Export.csv") Then
                ''reads all the lines from the file
                Using sr As New System.IO.StreamReader(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Tensile Export\Export.csv")
                    While sr.Peek <> -1
                        Dim spl As String() = sr.ReadLine().Split(New String() {","}, StringSplitOptions.None)
                        If ColumnList.Count = 0 Then
                            For j As Integer = 0 To spl.Count - 1
                                If spl(j).Contains("Area") Then
                                    ColumnList.Add(spl(j).Substring(0, spl(j).Length - 5))
                                ElseIf spl(j).ToUpper.Contains("PART") Then
                                    ColumnList.Add("PART")
                                Else
                                    ColumnList.Add(spl(j))
                                End If
                            Next
                        Else
                            Dim entry As New UploadEntries
                            For j As Integer = 0 To spl.Count - 1
                                entry.Add(ColumnList(j), spl(j))
                            Next
                            If Val(entry.Item("Gage Length (Final)(in)")) > 2 Then
                                entry.Update("Gage Length (Final)(in)", (Val(entry.Item("Gage Length (Final)(in)")) - 2).ToString())
                            End If
                            Tests.Add(entry)
                        End If
                    End While
                End Using

                Dim cmd As New SqlCommand("IF EXISTS(SELECT TestNumber FROM PullTestData WHERE TestNumber = @TestNumber AND Status = 'OPEN') INSERT INTO PullTestLineTable (PullTestNumber, PullTestLineNumber, CrossSectionalArea, Yield2PercentPound, Yield2PercentPSI, UltimateYieldPound, UltimateYieldPSI, Elongation2Inch, Elongation2Percent, Reduction2Inch, ReductionPercent, TorqueFootPounds, BreakLocation) VALUES (@TestNumber, (SELECT isnull(MAX(PullTestLineNumber) +1,1) FROM PullTestLineTable WHERE PullTestNumber = @TestNumber), @CrossSectionalArea, @Yield2PercentPound, @Yield2PercentPSI, @UltimateYieldPound, @UltimateYieldPSI, @Elongation2Inch, @Elongation2Percent, @Reduction2Inch, @ReductionPercent, @TorqueFootPounds, @BreakLocation); SELECT @@ROWCOUNT;", con)
                cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar)
                cmd.Parameters.Add("@CrossSectionalArea", SqlDbType.Float)
                cmd.Parameters.Add("@Yield2PercentPound", SqlDbType.Float)
                cmd.Parameters.Add("@Yield2PercentPSI", SqlDbType.Float)
                cmd.Parameters.Add("@UltimateYieldPound", SqlDbType.Float)
                cmd.Parameters.Add("@UltimateYieldPSI", SqlDbType.Float)
                cmd.Parameters.Add("@Elongation2Inch", SqlDbType.Float)
                cmd.Parameters.Add("@Elongation2Percent", SqlDbType.Float)
                cmd.Parameters.Add("@Reduction2Inch", SqlDbType.Float)
                cmd.Parameters.Add("@ReductionPercent", SqlDbType.Float)
                cmd.Parameters.Add("@TorqueFootPounds", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@BreakLocation", SqlDbType.VarChar).Value = ""

                Dim i As Integer = 0
                While i < Tests.Count
                    Dim cross As Double = Val(Tests(i).Item("Area"))
                    Dim yeildpsi As Double = GetYeildPSI(Tests(i))

                    cmd.Parameters("@TestNumber").Value = Tests(i).Item("TEST #")
                    ''Check to see if the part is threaded if so will upload as 0
                    If Tests(i).Item("PART").StartsWith("TT") Or Tests(i).Item("PART").StartsWith("TP") Or Tests(i).Item("PART").StartsWith("NT") Then
                        Tests(i).Update("Area", "0")
                    End If
                    cmd.Parameters("@CrossSectionalArea").Value = Val(Tests(i).Item("Area"))
                    cmd.Parameters("@Yield2PercentPound").Value = Val(Tests(i).Item("Offset Force @ 0.2%(lbf)"))
                    cmd.Parameters("@Yield2PercentPSI").Value = GetYeildPSI(Tests(i))
                    cmd.Parameters("@UltimateYieldPound").Value = Val(Tests(i).Item("Ultimate Force(lbf)"))
                    cmd.Parameters("@UltimateYieldPSI").Value = GetUltimatePSI(Tests(i))
                    cmd.Parameters("@Elongation2Inch").Value = Val(Tests(i).Item("Gage Length (Final)(in)"))
                    cmd.Parameters("@Elongation2Percent").Value = GetElongationPercent(Tests(i))
                    cmd.Parameters("@Reduction2Inch").Value = Val(Tests(i).Item("Area (Final)"))
                    cmd.Parameters("@ReductionPercent").Value = GetReductionPercent(Tests(i))

                    If con.State = ConnectionState.Closed Then con.Open()
                    If cmd.ExecuteScalar() = 0 Then
                        Dim cmd1 As New SqlCommand("IF EXISTS(SELECT isnull(Status, 'NONE') FROM PullTestData WHERE TestNumber = @TestNumber) SELECT isnull(Status, 'NONE') FROM PullTestData WHERE TestNumber = @TestNumber ELSE SELECT 'NONE'", con)
                        cmd1.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = Tests(i).Item("TEST #")
                        If con.State = ConnectionState.Closed Then con.Open()
                        If cmd1.ExecuteScalar().Equals("CLOSED") Then
                            Using sw As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Tensile Export\ErrorLog.txt", True)
                                sw.WriteLine(Now.ToString() + " - Test #" + Tests(i).Item("Test #") + " was found to have tests already closed. Unable to import.")
                            End Using
                            Tests.RemoveAt(i)
                        Else
                            Using sw As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Tensile Export\ErrorLog.txt", True)
                                sw.WriteLine(Now.ToString() + " - Test #" + Tests(i).Item("Test #") + " was found to have tests already saved. Unable to import.")
                            End Using
                            i += 1
                        End If
                    Else
                        Using sw As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Tensile Export\UploadedSucccessfully.txt", True)
                            sw.WriteLine(Now.ToString() + " - Test #" + Tests(i).Item("Test #") + " was uploaded successfully.")
                            sw.WriteLine("    FOX,PART #,Grade,Diameter 1(in),Area(in²),HEAT #,Offset Force @ 0.2%(lbf),Ultimate Force(lbf),Gage Length (Final)(in),Area (Final)(in²)")
                            sw.WriteLine("    " + Tests(i).Item("FOX") + "," + Tests(i).Item("PART #") + "," + Tests(i).Item("Grade") + "," + Tests(i).Item("Diameter 1(in)") + "," + Tests(i).Item("Area(in²)") + "," + Tests(i).Item("HEAT #") + "," + Tests(i).Item("Offset Force @ 0.2%(lbf)") + "," + Tests(i).Item("Ultimate Force(lbf)") + "," + Tests(i).Item("Gage Length (Final)(in)") + "," + Tests(i).Item("Area (Final)(in²)"))
                        End Using
                        Tests.RemoveAt(i)
                    End If
                End While
                i = 0
                If Tests.Count > 0 Then
                    Using sw As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Tensile Export\Export.csv", False)
                        sw.WriteLine("TEST #,FOX,PART #,Grade,Diameter 1(in),Area(in²),HEAT #,Offset Force @ 0.2%(lbf),Ultimate Force(lbf),Gage Length (Final)(in),Area (Final)(in²)")
                        While i < Tests.Count
                            sw.WriteLine(Tests(i).Item("TestNumber") + "," + Tests(i).Item("FOX") + "," + Tests(i).Item("PART #") + "," + Tests(i).Item("Grade") + "," + Tests(i).Item("Diameter 1(in)") + "," + Tests(i).Item("Area(in²)") + "," + Tests(i).Item("HEAT #") + "," + Tests(i).Item("Offset Force @ 0.2%(lbf)") + "," + Tests(i).Item("Ultimate Force(lbf)") + "," + Tests(i).Item("Gage Length (Final)(in)") + "," + Tests(i).Item("Area (Final)(in²)"))
                            i += 1
                        End While
                    End Using
                Else
                    System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Tensile Export\Export.csv")
                End If
            End If
        Catch ex As System.Exception
            Using sw As New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Tensile Export\ErrorLog.txt", True)
                sw.WriteLine(ex.ToString())
            End Using
        End Try
    End Sub

    Private Sub tmrGetTestMessageChange_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetTestMessageChange.Tick
        Select Case lblGetTestMessage.Text
            Case "Getting test data, please wait."
                lblGetTestMessage.Text = "Getting test data, please wait.."
            Case "Getting test data, please wait.."
                lblGetTestMessage.Text = "Getting test data, please wait..."
            Case "Getting test data, please wait..."
                lblGetTestMessage.Text = "Getting test data, please wait."
        End Select
    End Sub

    Private Sub pnlGetTestMessage_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlGetTestMessage.VisibleChanged
        If pnlGetTestMessage.Visible Then
            tmrGetTestMessageChange.Start()
            gpxCertInfo.Enabled = False
            gpxFinish.Enabled = False
            gpxGetData.Enabled = False
            gpxPullTestData.Enabled = False
            gpxTestData.Enabled = False
            pnlButtons.Enabled = False
        Else
            LoadTestData()
            gpxCertInfo.Enabled = True
            gpxFinish.Enabled = True
            gpxGetData.Enabled = True
            gpxPullTestData.Enabled = True
            gpxTestData.Enabled = True
            pnlButtons.Enabled = True
            tmrGetTestMessageChange.Stop()
            lblGetTestMessage.Text = "Getting test data, please wait."
        End If
    End Sub

    Private Sub bgwkGetTestData_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkGetTestData.RunWorkerCompleted
        pnlGetTestMessage.Hide()
    End Sub

    Private Sub txtCertType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCertType.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(txtCertType.Text) Then
                LoadCertRequirements()
            End If
        End If
    End Sub

    Private Sub LoadCertRequirements()
        cmd = New SqlCommand("SELECT MinTensile, MinYield, ROAPercent, ElongationPercent FROM Certificationtype WHERE CertificationCode = @CertificationCode", con)
        cmd.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = txtCertType.Text
        CurrentCertRequirements = New CertificationRequirements()
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            CurrentCertRequirements.MinimumTensile = reader.Item("MinTensile")
            CurrentCertRequirements.MinimumYeild = reader.Item("MinYield")
            CurrentCertRequirements.ReductionOfAreaPercent = reader.Item("ROAPercent")
            CurrentCertRequirements.ElongationPercent = reader.Item("ElongationPercent")
        End If
        reader.Close()
        con.Close()
        CheckRequirements()
    End Sub

    Private Sub CheckRequirements()
        checkTensileBelow()
        checkYieldBelow()
        checkReductionBelow()
        checkElongationBelow()
    End Sub

    Private Sub cboHeatNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.SelectedIndexChanged
        If cboHeatNumber.Text = "" Then
            dgvHeatFileTable.DataSource = Nothing
        Else
            LoadHeatFileTable()
        End If
    End Sub

    Private Sub txtSteelTypeFromHeat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSteelTypeFromHeat.TextChanged
        If txtSteelTypeFromHeat.Text <> "" And txtSteelSizeFromHeat.Text <> "" Then
            LoadRMID()
        End If
    End Sub

    Private Sub txtSteelSizeFromHeat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSteelSizeFromHeat.TextChanged
        If txtSteelTypeFromHeat.Text <> "" And txtSteelSizeFromHeat.Text <> "" Then
            LoadRMID()
        End If
    End Sub

    Private Sub dgvHeatFileTable_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHeatFileTable.CellValueChanged
        If Me.dgvHeatFileTable.RowCount <> 0 Then
            Dim CheckRowIndex As Integer = 0

            Dim RowIndex As Integer = Me.dgvHeatFileTable.CurrentCell.RowIndex

            If Me.dgvHeatFileTable.Rows(RowIndex).Cells("CheckBoxColumn").Value = "CHECKED" Then
                Try
                    RowHeatFileNumber = Me.dgvHeatFileTable.Rows(RowIndex).Cells("HeatFileNumberColumn").Value
                Catch ex As System.Exception
                    RowHeatFileNumber = 0
                End Try

                HeatFileNumber = RowHeatFileNumber
                lblHeatFileNumber.Text = HeatFileNumber

                For i As Integer = 1 To Me.dgvHeatFileTable.RowCount
                    If CheckRowIndex = RowIndex Then
                        'Do nothing
                    Else
                        Me.dgvHeatFileTable.Rows(CheckRowIndex).Cells("CheckBoxColumn").Value = "UNCHECKED"
                    End If

                    CheckRowIndex = CheckRowIndex + 1
                Next

                'Get carbon, steel size, RMID, for the heat number
                LoadSteelFromHeatNumber()
            Else
                'Do nothing - user must choose heat file number
                txtSteelTypeFromHeat.Clear()
                txtSteelSizeFromHeat.Clear()
                txtRMIDFromHeat.Clear()
                lblHeatFileNumber.Text = ""
            End If
        Else
            'Skip Update
        End If
    End Sub

    Private Sub dgvHeatFileTable_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvHeatFileTable.CurrentCellDirtyStateChanged
        If dgvHeatFileTable.IsCurrentCellDirty Then
            dgvHeatFileTable.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub lblHeatFileNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHeatFileNumber.TextChanged
        If Val(lblHeatFileNumber.Text) = 0 Then
            txtSteelSizeFromHeat.Clear()
            txtSteelTypeFromHeat.Clear()
            txtRMIDFromHeat.Clear()
        ElseIf HeatFileNumber > 0 Then
            LoadSteelFromHeatNumber()
        End If
    End Sub
End Class