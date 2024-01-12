Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class AnnealingLogForm
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async=true;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async=true;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet

    Dim scannedSequence As String = ""
    Dim totalScanTime As Integer
    Dim barcodeScanner As Boolean = False
    Dim GetRMID As String = ""

    ''******************************
    ''NEEDS TAKEN OUT
    'Dim EmployeeCompanyCode = "TST"
    'Dim EmployeeLoginName = "JAGLER"
    ''******************************

    Dim isLoaded As Boolean = False
    Dim needsSaved As Boolean = False
    Dim neededLabels As New List(Of String)
    Dim passedLotNumber As String
    Dim canMove As Boolean = True

    Dim FocusedField As New usefulFunctions.FocusedItem()
    Dim wasDeleted As Boolean = False
    Dim notFinished As Boolean = False

    Public Sub New()
        InitializeComponent()
        passedLotNumber = ""
    End Sub

    Public Sub New(ByVal lotNumber As String)
        InitializeComponent()
        passedLotNumber = lotNumber
    End Sub

    Private Sub AnnealingLogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Environment.MachineName.ToLower.Contains("tablet") Then ''And Not Environment.MachineName.ToLower.Contains("agler") Then
            Me.Size = New System.Drawing.Size(1085, 576)
            Me.StartPosition = FormStartPosition.CenterParent
        Else
            Me.Location = Screen.GetWorkingArea(Me).Location
        End If
        ''turns off visibility for unneeded people
        usefulFunctions.LoadSecurity(Me)

        bgwkCoilID.RunWorkerAsync()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        LoadAnnealLotNumber()
        LoadCarbon()
        LoadSteelSize()
        isLoaded = True
        If Not String.IsNullOrEmpty(passedLotNumber) Then
            cboAnnealLotNumber.Text = passedLotNumber
            passedLotNumber = ""
        End If
        'If FocusedField.isSet() Then
        '    FocusedField.position = 0
        'End If

    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM AnnealingCoilLines WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = Val(cboAnnealLotNumber.Text)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "AnnealingCoilLines")
        con.Close()

        dgvAnnealLotLines.DataSource = ds.Tables("AnnealingCoilLines")
        dgvAnnealLotLines.Columns("AnnealLotNumber").Visible = False
        dgvAnnealLotLines.Columns("CoilID").ReadOnly = True
        dgvAnnealLotLines.Columns("AnnealedWeight").ReadOnly = True
        cboDeleteCoilID.DataSource = ds.Tables("AnnealingCoilLines")
        cboDeleteCoilID.DisplayMember = "CoilID"
        If dgvAnnealLotLines.Rows.Count = 0 Then
            cboDeleteCoilID.Text = ""
        End If
    End Sub

    Public Sub LoadCoilID()
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status = 'RAW';", con)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "CharterSteelCoilIdentification")
        con.Close()

        cboCoilID.DisplayMember = "CoilID"
        cboCoilID.DataSource = ds2.Tables("CharterSteelCoilIdentification")
        cboCoilID.SelectedIndex = -1
    End Sub

    Public Sub LoadAnnealLotNumber()
        If EmployeeCompanyCode.Equals("TST") Then
            cmd = New SqlCommand("SELECT AnnealLotNumber FROM AnnealingLog WHERE DivisionID = 'TST' ORDER BY AnnealLotNumber DESC;", con)
        Else
            cmd = New SqlCommand("SELECT AnnealLotNumber FROM AnnealingLog WHERE DivisionID <> 'TST' ORDER BY AnnealLotNumber DESC;", con)
        End If

        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "AnnealingLog")
        con.Close()

        cboAnnealLotNumber.DisplayMember = "AnnealLotNumber"
        cboAnnealLotNumber.DataSource = ds3.Tables("AnnealingLog")
        cboAnnealLotNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable;", con)
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "RawMaterialsTable")
        con.Close()

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = ds4.Tables("RawMaterialsTable")
        cboCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT(SteelSize) FROM RawMaterialsTable;", con)
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        con.Close()

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = ds1.Tables("RawMaterialsTable")
        cboSteelSize.SelectedIndex = -1
        txtSteelDescription.Text = ""
    End Sub

    Public Sub ClearData()
        cboCarbon.Refresh()
        cboAnnealLotNumber.Refresh()
        cboSteelSize.Refresh()
        cboCoilID.Refresh()

        txtAnnealedDescription.Refresh()
        txtAnnealCarbon.Refresh()
        txtAnnealSteelSize.Refresh()
        txtBase.Refresh()
        txtCoilWeight.Refresh()
        txtComments.Refresh()
        txtHeatNumber.Refresh()
        txtNumberOfCoils.Refresh()
        txtPreviousLot.Refresh()
        txtProgram.Refresh()
        txtSteelDescription.Refresh()
        txtTotalWeight.Refresh()

        cboCarbon.SelectedIndex = -1
        cboAnnealLotNumber.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboCoilID.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCoilID.Text) Then
            cboCoilID.Text = ""
        End If

        txtAnnealedDescription.Clear()
        txtAnnealCarbon.Clear()
        txtAnnealSteelSize.Clear()
        txtBase.Clear()
        txtCoilWeight.Clear()
        txtComments.Clear()
        txtHeatNumber.Clear()
        txtNumberOfCoils.Clear()
        txtPreviousLot.Clear()
        txtProgram.Clear()
        txtSteelDescription.Clear()
        txtTotalWeight.Clear()
        txtCoilCarbon.Clear()
        txtCoilSize.Clear()
        txtSurfaceHardness.Clear()
        txtCoreHardness.Clear()
        txtFreeFerrite.Clear()
        txtTotalDecarb.Clear()
        txtSpheroid.Clear()
        txtSampleMicro.Clear()
        txtSampleBox.Clear()

        dtpDateIn.Text = ""
        dtpDateOut.Text = ""
        dtpLotCreationDate.Text = ""

        If cmdAddCoil.Enabled = False Then
            cmdAddCoil.Enabled = True
            cmdSplitCoil.Enabled = True
            cmdRemoveCoil.Enabled = True
            cmdPostAnnealingLot.Enabled = True
            cmdDelete.Enabled = True
            txtAnnealCarbon.ReadOnly = False
            txtAnnealSteelSize.ReadOnly = False
            PrintSampleTagToolStripMenuItem.Enabled = False
        End If

        cboCarbon.Enabled = True
        cboSteelSize.Enabled = True
        txtHeatNumber.ReadOnly = False
        dgvAnnealLotLines.DataSource = New DataSet().Tables("")
        lblQCMessage.Visible = False
        lblQCMessage.Text = ""
        cboAnnealLotNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        hideSuggest(FocusedField.Name)
        FocusedField = New usefulFunctions.FocusedItem()
        barcodeScanner = False
        totalScanTime = 0
        GetRMID = ""
    End Sub

    Public Sub LoadCoilData()
        Dim carbon As String = ""
        Dim steelSize As String = ""
        Dim heat As String = ""
        Dim CoilWeight As String = ""

        cmd = New SqlCommand("SELECT Weight, Carbon, SteelSize, HeatNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Weight")) Then
                CoilWeight = 0
            Else
                CoilWeight = reader.Item("Weight")
            End If
            If Not IsDBNull(reader.Item("Carbon")) Then
                carbon = reader.Item("Carbon")
            End If
            If Not IsDBNull(reader.Item("SteelSize")) Then
                steelSize = reader.Item("SteelSize")
            End If
            If Not IsDBNull(reader.Item("HeatNumber")) Then
                heat = reader.Item("HeatNumber")
            End If
        Else
            CoilWeight = 0
            carbon = ""
            steelSize = ""
        End If
        reader.Close()
        con.Close()
        ''check to see if the carbon has text and if not will fill it
        If String.IsNullOrEmpty(cboCarbon.Text) Or dgvAnnealLotLines.Rows.Count = 0 Then
            cboCarbon.Text = carbon
            needsSaved = True
        End If
        ''check to see if the steelSize has text and if not will fill it
        If String.IsNullOrEmpty(cboSteelSize.Text) Or dgvAnnealLotLines.Rows.Count = 0 Then
            cboSteelSize.Text = steelSize
            needsSaved = True
        End If
        If String.IsNullOrEmpty(txtHeatNumber.Text) Or dgvAnnealLotLines.Rows.Count = 0 Then
            txtHeatNumber.Text = heat
            needsSaved = True
        End If
        txtCoilCarbon.Text = carbon
        txtCoilSize.Text = steelSize
        txtAnnealSteelSize.Text = cboSteelSize.Text
        LoadSteelDescription()
        LoadAnnealedDescription()
        txtCoilWeight.Text = CoilWeight
    End Sub

    Public Sub LoadSteelDescription()
        Dim SteelDescription As String = ""
        cmd = New SqlCommand("SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @Size;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelDescription = cmd.ExecuteScalar
        Catch ex As System.Exception
            SteelDescription = ""
        End Try
        con.Close()

        txtSteelDescription.Text = SteelDescription
    End Sub

    Public Sub LoadAnnealedDescription()
        Dim AnnealedSteelDescription As String = ""
        cmd = New SqlCommand("SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @Size;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtAnnealCarbon.Text
        cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = txtAnnealSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AnnealedSteelDescription = cmd.ExecuteScalar
        Catch ex As System.Exception
            AnnealedSteelDescription = ""
        End Try
        con.Close()

        txtAnnealedDescription.Text = AnnealedSteelDescription
    End Sub

    Public Sub LoadAnnealLotData()
        Dim status As String = ""
        Dim AnnealedRMIDCarbon As String = ""
        Dim AnnealedRMIDSteelSize As String = ""
        Dim PoundsAnnealed As String = ""
        Dim HeatNumber As String = ""
        Dim DateIn As Date = Now
        Dim DateOut As Date = Now
        Dim Comments As String = ""
        Dim PreviousAnnealLotNumber As String = ""
        Dim Base As String = ""
        Dim Program As String = ""
        Dim NumberOfCoils As String = ""
        Dim Carbon As String = ""

        Dim RMIDCommand As New SqlCommand("SELECT AnnealedCarbon, AnnealedSteelSize, TotalPoundsAnnealed, HeatNumber, DateIn, DateOut, Comments, PreviousAnnealLotNumber, Base, Program, NumberOfCoils, RawMaterialsTable.Carbon, SurfaceHardness, CoreHardness, FreeFerrite, TotalDecarb, SpheroidPercent, SpheroSampleMicro, SpheroSampleBox, MaterialStatus FROM AnnealingLog LEFT OUTER JOIN RawMaterialsTable ON AnnealingLog.RMID = RawMaterialsTable.RMID WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        RMIDCommand.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = Val(cboAnnealLotNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = RMIDCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("AnnealedCarbon")) Then
                AnnealedRMIDCarbon = ""
            Else
                AnnealedRMIDCarbon = reader.Item("AnnealedCarbon")
            End If
            If IsDBNull(reader.Item("AnnealedSteelSize")) Then
                AnnealedRMIDSteelSize = ""
            Else
                AnnealedRMIDSteelSize = reader.Item("AnnealedSteelSize")
            End If
            If IsDBNull(reader.Item("TotalPoundsAnnealed")) Then
                PoundsAnnealed = 0
            Else
                PoundsAnnealed = reader.Item("TotalPoundsAnnealed")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = ""
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("DateIn")) Then
                DateIn = Now
            Else
                DateIn = reader.Item("DateIn")
            End If
            If IsDBNull(reader.Item("DateOut")) Then
                DateOut = Now
            Else
                DateOut = reader.Item("DateOut")
            End If
            If IsDBNull(reader.Item("Comments")) Then
                Comments = ""
            Else
                Comments = reader.Item("Comments")
            End If
            If IsDBNull(reader.Item("PreviousAnnealLotNumber")) Then
                PreviousAnnealLotNumber = ""
            Else
                PreviousAnnealLotNumber = reader.Item("PreviousAnnealLotNumber")
            End If
            If IsDBNull(reader.Item("Base")) Then
                Base = ""
            Else
                Base = reader.Item("Base")
            End If
            If IsDBNull(reader.Item("Program")) Then
                Program = ""
            Else
                Program = reader.Item("Program")
            End If
            If IsDBNull(reader.Item("NumberOfCoils")) Then
                NumberOfCoils = 0
            Else
                NumberOfCoils = reader.Item("NumberOfCoils")
            End If
            If IsDBNull(reader.Item("Carbon")) Then
                Carbon = ""
            Else
                Carbon = reader.Item("Carbon")
            End If
            If IsDBNull(reader.Item("SurfaceHardness")) Then
                txtSurfaceHardness.Text = ""
            Else
                txtSurfaceHardness.Text = reader.Item("SurfaceHardness")
            End If
            If IsDBNull(reader.Item("CoreHardness")) Then
                txtCoreHardness.Text = ""
            Else
                txtCoreHardness.Text = reader.Item("CoreHardness")
            End If
            If IsDBNull(reader.Item("FreeFerrite")) Then
                txtFreeFerrite.Text = ""
            Else
                txtFreeFerrite.Text = reader.Item("FreeFerrite")
            End If
            If IsDBNull(reader.Item("TotalDecarb")) Then
                txtTotalDecarb.Text = ""
            Else
                txtTotalDecarb.Text = reader.Item("TotalDecarb")
            End If
            If IsDBNull(reader.Item("SpheroidPercent")) Then
                txtSpheroid.Text = ""
            Else
                txtSpheroid.Text = reader.Item("SpheroidPercent")
            End If
            If IsDBNull(reader.Item("SpheroSampleMicro")) Then
                txtSampleMicro.Text = ""
            Else
                txtSampleMicro.Text = reader.Item("SpheroSampleMicro")
            End If
            If IsDBNull(reader.Item("SpheroSampleBox")) Then
                txtSampleBox.Text = ""
            Else
                txtSampleBox.Text = reader.Item("SpheroSampleBox")
            End If
            If IsDBNull(reader.Item("MaterialStatus")) Then
                lblQCMessage.Visible = False
                lblQCMessage.Text = ""
            Else
                lblQCMessage.Text = reader.Item("MaterialStatus")
                lblQCMessage.Visible = True
            End If
        Else
            txtAnnealCarbon.Text = ""
            txtAnnealSteelSize.Text = ""
            PoundsAnnealed = 0
            HeatNumber = ""
            DateIn = Now
            DateOut = Now
            Comments = ""
            PreviousAnnealLotNumber = ""
            Base = ""
            Program = ""
            NumberOfCoils = 0
            Carbon = ""
            txtSurfaceHardness.Text = ""
            txtCoreHardness.Text = ""
            txtFreeFerrite.Text = ""
            txtTotalDecarb.Text = ""
            txtSpheroid.Text = ""
            txtSampleMicro.Text = ""
            txtSampleBox.Text = ""
            lblQCMessage.Hide()
            lblQCMessage.Text = ""
        End If
        reader.Close()
        con.Close()

        txtAnnealCarbon.Text = AnnealedRMIDCarbon
        dtpLotCreationDate.Value = DateIn
        cboCarbon.Text = Carbon
        txtAnnealSteelSize.Text = AnnealedRMIDSteelSize
        LoadSteelDescription()
        LoadAnnealedDescription()
        cboSteelSize.Text = txtAnnealSteelSize.Text
        txtTotalWeight.Text = PoundsAnnealed
        txtHeatNumber.Text = HeatNumber
        dtpDateIn.Value = DateIn
        dtpDateOut.Value = DateOut
        txtComments.Text = Comments
        txtPreviousLot.Text = PreviousAnnealLotNumber
        txtProgram.Text = Program
        txtBase.Text = Base
        txtNumberOfCoils.Text = NumberOfCoils

        Select Case lblQCMessage.Text
            Case "Ok To Process"
                lblQCMessage.ForeColor = Color.Green
            Case "Ok - See Comment"
                lblQCMessage.ForeColor = Color.DeepSkyBlue
            Case "Hold - See Comment"
                lblQCMessage.ForeColor = Color.Goldenrod
            Case "Do Not Use - See Comment"
                lblQCMessage.ForeColor = Color.Red
            Case Else
                lblQCMessage.ForeColor = Color.Green
        End Select

        checkStatus()
    End Sub

    Private Function checkStatus() As Boolean
        ''check to make sure there is something in the Annealing Lot field
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            cmdAddCoil.Enabled = True
            cmdSplitCoil.Enabled = True
            cmdRemoveCoil.Enabled = True
            cmdPostAnnealingLot.Enabled = True
            cmdDelete.Enabled = True
            txtAnnealCarbon.ReadOnly = False
            txtAnnealSteelSize.ReadOnly = False
            Exit Function
        End If

        Dim status As String = "CLOSED"
        cmd = New SqlCommand("SELECT Status FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            status = cmd.ExecuteScalar()
        Catch ex As System.Exception
        End Try
        con.Close()

        If status.Equals("CLOSED") Or status.Equals("FINISHED") Then
            cmdAddCoil.Enabled = False
            cmdSplitCoil.Enabled = False
            cmdRemoveCoil.Enabled = False
            cmdPostAnnealingLot.Enabled = False
            cmdDelete.Enabled = False
            txtAnnealCarbon.ReadOnly = True
            txtAnnealSteelSize.ReadOnly = True
            PrintSampleTagToolStripMenuItem.Enabled = True
            Return True
        Else
            cmdAddCoil.Enabled = True
            cmdSplitCoil.Enabled = True
            cmdRemoveCoil.Enabled = True
            cmdPostAnnealingLot.Enabled = True
            cmdDelete.Enabled = True
            txtAnnealCarbon.ReadOnly = False
            txtAnnealSteelSize.ReadOnly = False
            PrintSampleTagToolStripMenuItem.Enabled = False
            Return False
        End If
    End Function

    Public Sub LoadAnnealingTotals()
        Dim TotalWeight As String = ""
        Dim NumberOfCoils As String = ""

        Dim TotalWeightStatement As String = "SELECT SUM(AnnealedWeight) as TotalAnnealedWeight, COUNT(AnnealLotNumber) as CoilCount FROM AnnealingCoilLines WHERE AnnealLotNumber = @AnnealLotNumber;"
        Dim TotalWeightCommand As New SqlCommand(TotalWeightStatement, con)
        TotalWeightCommand.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = Val(cboAnnealLotNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = TotalWeightCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("TotalAnnealedWeight")) Then
                TotalWeight = 0
            Else
                TotalWeight = reader.Item("TotalAnnealedWeight")
            End If
            If IsDBNull(reader.Item("CoilCount")) Then
                NumberOfCoils = 0
            Else
                NumberOfCoils = reader.Item("CoilCount")
            End If
        Else
            TotalWeight = 0
            NumberOfCoils = 0
        End If
        reader.Close()
        con.Close()

        txtTotalWeight.Text = TotalWeight
        txtNumberOfCoils.Text = NumberOfCoils

        updateAnnealingLog()
        needsSaved = False
    End Sub

    Private Sub cmdGenerateNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNew.Click

        isLoaded = False
        ClearVariables()
        ClearData()

        cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(AnnealLotNumber) + 1, 1001) FROM AnnealingLog); INSERT INTO AnnealingLog(AnnealLotNumber, DivisionID, Status)VALUES(@Key, @DivisionID, 'OPEN'); SELECT @Key;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As New Object
        Try
            obj = cmd.ExecuteScalar()
        Catch ex As System.Exception
            con.Close()
            sendErrorToDataBase("AnnealingLogForm - cmdGenerateNew_Click --Error trying to insert into AnnealingLog a new Anneal Lot Number", "New Anneal Lot Number", ex.ToString())
            MessageBox.Show("Unable to generate a new Anneal Lot Number. Contact system admin", "Unable to get Anneal Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        con.Close()
        LoadAnnealLotNumber()
        If Not IsDBNull(obj) Then
            cboAnnealLotNumber.Text = obj.ToString()
        End If

        cboCoilID.Focus()
        isLoaded = True
        ShowData()
    End Sub

    Private Sub cmdEnterCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddCoil.Click
        If canEnterCoil() Then
            'Load Current Totals for Annealing Batch
            LoadAnnealingTotals()
            If needsSaved Then
                Try
                    updateAnnealingLog()
                    needsSaved = False
                Catch ex As System.Exception
                    sendErrorToDataBase("AnnealingLogForm - cmdEnterCoil_Click --Error trying to update the line in the AnnealingLog Table", "Annealing Lot #" + cboAnnealLotNumber.Text, ex.ToString())
                End Try
            End If

            Try
                'Create command to add Coils to Annealing Lot
                cmd = New SqlCommand("INSERT INTO AnnealingCoilLines (AnnealLotNumber, CoilID, AnnealedWeight)values(@AnnealLotNumber, @CoilID, (SELECT Weight FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID));", con)

                With cmd.Parameters
                    .Add("@AnnealLotNumber", SqlDbType.VarChar).Value = Val(cboAnnealLotNumber.Text)
                    .Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("AnnealingLogForm - cmdEnterCoil_Click --Error trying to add coil to Anneal Lot #" + cboAnnealLotNumber.Text, "Coil #" + cboCoilID.Text, ex.ToString())
                MessageBox.Show("There was an error trying ot add the coil to the Anneal Lot. Unable to complete process", "Unable to complete adding coil process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            'Clear Coil Lines
            isLoaded = False
            cboCoilID.SelectedIndex = -1
            isLoaded = True
            txtCoilWeight.Clear()
            txtCoilCarbon.Clear()
            txtCoilSize.Clear()

            LoadAnnealingTotals()
            ShowData()
            cboCoilID.Focus()
            checkCarbonSizeHeatLock()
        End If
    End Sub

    Private Function canEnterCoil() As Boolean
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            MessageBox.Show("You must select a Anneal Lot Number", "Select an Anneal Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If cboAnnealLotNumber.SelectedIndex = -1 Then
            cmd = New SqlCommand("INSERT INTO AnnealingLog(AnnealLotNumber, DivisionID, Status) VALUES(@AnnealLotNumber, @DivisionID, 'OPEN');", con)
            cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            isLoaded = False
            Dim temp As String = cboAnnealLotNumber.Text
            LoadAnnealLotNumber()
            cboAnnealLotNumber.Text = temp
            isLoaded = True
        End If
        If String.IsNullOrEmpty(cboCarbon.Text) Then
            MessageBox.Show("You must select an Anneal Carbon", "Select an Anneal Carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCarbon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelSize.Text) Then
            MessageBox.Show("You must select an Anneal Steel Size", "Select an Anneal Steel Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.Focus()
            Return False
        End If
        If checkAnnealRMID() Then
            MessageBox.Show("Annealing Carbon/Steel Size is not in Raw Materials. Make sure it has been entered.", "Unable to Add", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboCoilID.Text) Then
            MessageBox.Show("You must select a Coil ID", "Select a Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.Focus()
            Return False
        End If
        If cboCoilID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Coil ID", "Enter a valid Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.SelectAll()
            cboCoilID.Focus()
            Return False
        End If

        Dim carb As String = ""
        Dim sz As String = ""
        Dim ht As String = ""

        cmd = New SqlCommand("SELECT Carbon, SteelSize, HeatNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            carb = reader.Item("Carbon")
            sz = reader.Item("SteelSize")
            ht = reader.Item("HeatNumber")
        End If
        reader.Close()
        con.Close()

        If Not carb.Equals(cboCarbon.Text) And Not carb.Equals(txtAnnealCarbon.Text) Then
            If cboCarbon.Enabled Then
                cboCarbon.Text = carb
            Else
                MessageBox.Show("Carbon for Coil entered doesn't match requirements. Check Coil ID and try again.", "Check Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboCoilID.SelectAll()
                cboCoilID.Focus()
                Return False
            End If
        End If
        If Not sz.Equals(cboSteelSize.Text) Then
            MessageBox.Show("Size for Coil entered doesn't match requirements. Check Coil ID and try again.", "Check Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.SelectAll()
            cboCoilID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtHeatNumber.Text) = False Then
            If Not ht.Equals(txtHeatNumber.Text) Then
                If txtHeatNumber.ReadOnly Then
                    MessageBox.Show("Heat number for Coil entered does not match Heat currently in Annealing lot. Heat number must match", "Heat number must match", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboCoilID.SelectAll()
                    cboCoilID.Focus()
                    Return False
                Else
                    txtHeatNumber.Text = ht
                End If
            End If
        Else
            txtHeatNumber.Text = ht
            txtHeatNumber.ReadOnly = True
        End If
        For i As Integer = 0 To dgvAnnealLotLines.Rows.Count - 1
            If cboCoilID.Text = dgvAnnealLotLines.Rows(i).Cells("CoilID").Value Then
                MessageBox.Show("Specified Coil has already been added to this Anneal Lot", "Already added to Anneal Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboCoilID.SelectAll()
                cboCoilID.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    Private Function checkAnnealRMID() As Boolean
        cmd = New SqlCommand("SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtAnnealCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = txtAnnealSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Close()
            con.Close()
            Return False
        End If
        reader.Close()
        con.Close()
        Return True
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveDataToolStripMenuItem.Click
        If canSave() Then
            'Load totals before save
            LoadAnnealingTotals()

            Try
                updateAnnealingLog()
                MsgBox("Annealing Lot has been saved.", MsgBoxStyle.OkOnly)
            Catch ex As System.Exception
                sendErrorToDataBase("AnnealingLogForm - cmdEnterCoil_Click --Error trying to update the line in the AnnealingLog Table", "Annealing Lot #" + cboAnnealLotNumber.Text, ex.ToString())
                MessageBox.Show("There was an error trying to save the updated information. Please check info and try again. If problem persists, contact system admin.", "Error trying to save Anneal Lot data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Function canSave()
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            MessageBox.Show("You must select a Anneal Lot Number", "Select an Anneal Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If cboAnnealLotNumber.SelectedIndex = -1 Then
            cmd = New SqlCommand("INSERT INTO AnnealingLog(AnnealLotNumber, DivisionID, Status)VALUES(@AnnealLotNumber, @DivisionID, 'OPEN');", con)
            cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            isLoaded = False
            Dim temp As String = cboAnnealLotNumber.Text
            LoadAnnealLotNumber()
            cboAnnealLotNumber.Text = temp
            isLoaded = True
        End If
        Return True
    End Function

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteDataToolStripMenuItem.Click
        If canDelete() Then
            'Prompt before Deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Lot Number?", "DELETE ANNEAL LOT NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then

                cmd = New SqlCommand("DELETE FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber;", con)
                cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = Val(cboAnnealLotNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Your data has been deleted.", MsgBoxStyle.OkOnly)

                isLoaded = False
                'Reset Form
                ClearVariables()
                ClearData()
                LoadAnnealLotNumber()
                ClearData()
                ShowData()
                isLoaded = True
            End If
            cboAnnealLotNumber.Focus()
        End If
    End Sub

    Private Function canDelete() As Boolean
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            MessageBox.Show("You must select an Anneal Lot number", "Select an Anneal Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If cboAnnealLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Anneal Lot Number", "Enter a valid Anneal Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.SelectAll()
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If checkStatus() Then
            MessageBox.Show("Annealing Lot can not be deleted.", "Unable to delete Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintDataToolStripMenuItem.Click
        Dim tempDS As New DataSet
        cmd = New SqlCommand("SELECT * FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)
        Dim tempadap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        tempadap.Fill(tempDS, "AnnealingLog")
        con.Close()
        Using NewPrintAnnealingLogFiltered As New PrintAnnealingLogFiltered(tempDS)
            Dim Result = NewPrintAnnealingLogFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cboAnnealLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAnnealLotNumber.SelectedIndexChanged
        If isLoaded Then
            If cboAnnealLotNumber.SelectedIndex <> -1 Then
                If lstAnnealingSuggest.Visible Then
                    lstAnnealingSuggest.Hide()
                End If
            End If
            LoadAnnealLotData()
            ShowData()
            checkCarbonSizeHeatLock()
        End If
    End Sub

    Private Sub cboCoilID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoilID.SelectedIndexChanged
        If isLoaded Then
            LoadCoilData()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        If canExit() Then
            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Lot Number?", "SAVE ANNEAL LOT NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Load totals before save
                LoadAnnealingTotals()

                Try
                    updateAnnealingLog()
                Catch ex As System.Exception
                    sendErrorToDataBase("AnnelaingLogForm - cmdExit_Click --Error trying to save the Annealing Lot data", "Annealing Lot #" + cboAnnealLotNumber.Text, ex.ToString())
                    MessageBox.Show("There was an error trying to save the Annealing Lot. Contact system admin", "Error saving Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            End If
        End If
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Function canExit() As Boolean
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            Return False
        End If
        Dim stat As String = "CLOSED"
        cmd = New SqlCommand("IF Exists(SELECT Status FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber)  SELECT Status FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber ELSE SELECT 'CLOSED';", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            stat = cmd.ExecuteScalar()
        Catch ex As System.Exception

        End Try
        con.Close()

        If stat.Equals("CLOSED") Or stat.Equals("FINISHED") Then
            Return False
        End If
        If Not needsSaved Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click, ClearDataToolStripMenuItem.Click
        isLoaded = False
        ClearVariables()
        ClearData()
        ShowData()
        LoadAnnealLotNumber()
        isLoaded = True
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
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If isLoaded Then
            If cboCarbon.Focused Then
                needsSaved = True
            End If
            If cboCarbon.Text.Contains("C") Then
                Dim grade As Integer = Val(cboCarbon.Text.Substring(1, 4))
                Select Case grade
                    Case Is > 1020
                        If cboCarbon.Text.Contains("SA") Then
                            txtAnnealCarbon.Text = cboCarbon.Text
                        Else
                            txtAnnealCarbon.Text = cboCarbon.Text + "SA"
                        End If
                    Case Is <= 1020
                        If cboCarbon.Text.Contains("A") Then
                            txtAnnealCarbon.Text = cboCarbon.Text
                        Else
                            txtAnnealCarbon.Text = cboCarbon.Text + "A"
                        End If
                    Case Else
                        If cboCarbon.Text.Contains("A") Then
                            txtAnnealCarbon.Text = cboCarbon.Text
                        Else
                            txtAnnealCarbon.Text = cboCarbon.Text + "A"
                        End If
                End Select
            Else
                txtAnnealCarbon.Text = cboCarbon.Text
            End If

            If Not String.IsNullOrEmpty(txtAnnealSteelSize.Text) Then
                LoadSteelDescription()
                LoadAnnealedDescription()
            End If
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If cboSteelSize.SelectedIndex <> -1 Then
            If cboSteelSize.Focused Then
                needsSaved = True
            End If
            txtAnnealSteelSize.Text = cboSteelSize.Text
            If String.IsNullOrEmpty(txtAnnealCarbon.Text) = False Then
                LoadSteelDescription()
                LoadAnnealedDescription()
            End If
        Else
            txtAnnealSteelSize.Text = ""
        End If
    End Sub

    Private Sub cboCoilID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoilID.TextChanged
        If cboCoilID.Text.Length > 1 And cboCoilID.Text.Length < 3 Then
            If Char.ToLower(cboCoilID.Text.ElementAt(0)) = "s" Then
                cboCoilID.Text = cboCoilID.Text.Substring(1, cboCoilID.Text.Length - 1)
                cboCoilID.Select(cboCoilID.Text.Length, 0)
            End If
        End If
        If cboCoilID.Focused Then
            'FocusedField.position = cboCoilID.SelectionStart
            'FocusedField.selectLength = 0
            If wasDeleted Then
                wasDeleted = False
            End If
        Else
            If Not wasDeleted Then
                'FocusedField.position += 1
            Else
                wasDeleted = False
            End If
        End If
        If canSuggestID() Then
            While bgwkCoilID.IsBusy
                Exit Sub
            End While
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Hide()
            End If
            lstCoilIDSuggest.Items.Clear()
            If bgwkCoilIDSuggest.IsBusy Then
                bgwkCoilIDSuggest.CancelAsync()
            End If
            While bgwkCoilIDSuggest.IsBusy
                System.Windows.Forms.Application.DoEvents()
            End While
            bgwkCoilIDSuggest.RunWorkerAsync(cboCoilID.Text)
            'bgwkCoilIDSuggestAssist.RunWorkerAsync()
            'For i As Integer = 0 To ds1.Tables("CharterSteelCoilIdentification").Rows.Count - 1
            '    If ds1.Tables("CharterSteelCoilIdentification").Rows(i).Item("CoilID").ToString().Contains(txtCoilID.Text) Then
            '        lstCoilIDSuggest.Items.Add(ds1.Tables("CharterSteelCoilIdentification").Rows(i).Item("CoilID").ToString())
            '    End If
            'Next
            'If lstCoilIDSuggest.Items.Count < 5 Then
            '    If lstCoilIDSuggest.Items.Count = 0 Then
            '        lstCoilIDSuggest.Height = 40
            '    Else
            '        lstCoilIDSuggest.Height = lstCoilIDSuggest.Items.Count * 40
            '    End If

            'Else
            '    lstCoilIDSuggest.Height = 5 * 20
            'End If
            'lstCoilIDSuggest.Visible = True
        End If
    End Sub

    Private Function canSuggestID() As Boolean
        If String.IsNullOrEmpty(FocusedField.name) Then
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Hide()
            End If
            Return False
        End If
        If Not FocusedField.name.Equals("cboCoilID") Then
            Return False
        End If
        If cboCoilID.Focused Then
            Return False
        End If
        If cboCoilID.Text.Length = 0 Then
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Hide()
            End If
            Return False
        End If
        Return True
    End Function

    Private Sub bgwkCoilIDSuggest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkCoilIDSuggest.DoWork
        Dim lst As New List(Of String)
        Dim cmd2 As SqlCommand = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status = 'RAW' and CoilID LIKE @CoilID;", con2)
        cmd2.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = e.Argument.ToString() + "%"

        If con2.State = ConnectionState.Closed Then con2.Open()
        Dim reader As SqlDataReader = cmd2.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If bgwkCoilIDSuggest.CancellationPending() Then
                    Exit While
                End If
                lst.Add(reader.GetValue(0))
            End While
        End If
        reader.Close()
        con2.Close()
        'For i As Integer = 0 To ds1.Tables("CharterSteelCoilIdentification").Rows.Count - 1
        '    If bgwkCoilIDSuggest.CancellationPending() Then
        '        Exit For
        '    End If
        '    If ds1.Tables("CharterSteelCoilIdentification").Rows(i).Item("CoilID").ToString().Contains(txtCoilID.Text) Then
        '        lst.Add(ds1.Tables("CharterSteelCoilIdentification").Rows(i).Item("CoilID").ToString())
        '    End If
        'Next
        e.Result = lst
    End Sub

    Private Sub bgwkCoilIDSuggest_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkCoilIDSuggest.RunWorkerCompleted
        If e.Cancelled Then
            Exit Sub
        End If
        Dim lst As List(Of String) = e.Result
        For i As Integer = 0 To lst.Count - 1
            lstCoilIDSuggest.Items.Add(lst(i))
        Next
        formatListbox(lstCoilIDSuggest)
    End Sub

    Private Sub cmdSplitCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSplitCoil.Click
        If canSplit() Then
            neededLabels = New List(Of String)
            Dim NewAnnealingLogSplit As New AnnealingLogSplitCoil
            NewAnnealingLogSplit.txtCurrentCoilID.Text = cboCoilID.Text
            NewAnnealingLogSplit.txtCurrentLotNumber.Text = cboAnnealLotNumber.Text
            NewAnnealingLogSplit.updateOrigWeight(Val(txtCoilWeight.Text))
            If NewAnnealingLogSplit.ShowDialog() = System.Windows.Forms.DialogResult.Yes Then
                Dim ids As List(Of String) = NewAnnealingLogSplit.getIDs()
                bgwkCoilID.RunWorkerAsync()
                ''checks to see if the first part was being sent to this annealing lot and if so will complete the adding the coil ID to the annealing lot
                Select Case NewAnnealingLogSplit.cboFirstWhere.SelectedIndex
                    Case 0
                        cboCoilID.Text = ids(0)
                        cmdEnterCoil_Click(sender, e)
                    Case 3
                        If addToNextAnnealLot(ids(0)) Then
                            NewAnnealingLogSplit.chkFirstPrintLabel.Checked = True
                        End If
                End Select
                ''checks to see where the second part of a coil is going and will complete adding coil ID to annealing lot if that was selected
                Select Case NewAnnealingLogSplit.cboSecondWhere.SelectedIndex
                    Case 0
                        While bgwkCoilID.IsBusy
                            System.Windows.Forms.Application.DoEvents()
                        End While
                        cboCoilID.Text = ids(1)
                        cmdEnterCoil_Click(sender, e)
                    Case 3
                        If addToNextAnnealLot(ids(1)) Then
                            NewAnnealingLogSplit.chkSecondPrintLabel.Checked = True
                        End If
                End Select
                lstCoilIDSuggest.Visible = False
                ''creates the barcode object so the printer name is not needed each time it wants to print a label
                Dim bc As New BarcodeLabel
                ''checks to see if the first part of the coil has the print label checked
                If NewAnnealingLogSplit.chkFirstPrintLabel.Checked Then
                    If tmrWaitToPrint.Enabled Then
                        neededLabels.Add(ids(0))
                    Else
                        bc.setupYardLabel(ids(0))
                        bc.PrintBarcodeLine()
                        tmrWaitToPrint.Start()
                    End If
                End If
                ''checks to see if the second part of the coil has the print label checked
                If NewAnnealingLogSplit.chkSecondPrintLabel.Checked Then
                    If tmrWaitToPrint.Enabled Then
                        neededLabels.Add(ids(1))
                    Else
                        bc.setupYardLabel(ids(1))
                        bc.PrintBarcodeLine()
                        tmrWaitToPrint.Start()
                    End If
                End If
                checkCarbonSizeHeatLock()
                LoadAnnealingTotals()
            End If
        End If
    End Sub

    Private Function canSplit() As Boolean
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            MessageBox.Show("You must select an Annealing Lot Number", "Select an Annealing Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If cboAnnealLotNumber.SelectedIndex = -1 Then
            cmd = New SqlCommand("INSERT INTO AnnealingLog(AnnealLotNumber, DivisionID, Status)VALUES(@AnnealLotNumber, @DivisionID, 'OPEN');", con)
            cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            isLoaded = False
            Dim temp As String = cboAnnealLotNumber.Text
            LoadAnnealLotNumber()
            cboAnnealLotNumber.Text = temp
            isLoaded = True
        End If
        If String.IsNullOrEmpty(cboCoilID.Text) Then
            MessageBox.Show("You must select a Coil ID to split", "Select a Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.Focus()
            Return False
        End If
        If cboCoilID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid coil ID", "Enter a valid Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.SelectAll()
            cboCoilID.Focus()
            Return False
        End If
        Dim carb As String = ""
        Dim sz As String = ""
        cmd = New SqlCommand("SELECT Carbon, SteelSize FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            carb = reader.GetValue(0)
            sz = reader.GetValue(1)
        End If
        reader.Close()
        con.Close()

        If carb <> cboCarbon.Text Then
            MessageBox.Show("Carbon for Coil entered doesn't match requirements. Check Coil ID and try again.", "Check Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.SelectAll()
            cboCoilID.Focus()
            Return False
        End If
        If sz <> cboSteelSize.Text Then
            MessageBox.Show("Size for Coil entered doesn't match requirements. Check Coil ID and try again.", "Check Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.SelectAll()
            cboCoilID.Focus()
            Return False
        End If
        If dgvAnnealLotLines.Rows.Count > 0 Then
            For i As Integer = 0 To dgvAnnealLotLines.Rows.Count - 1
                If dgvAnnealLotLines.Rows(i).Cells("CoilID").Value = cboCoilID.Text Then
                    MessageBox.Show("Specified Coil has already is part of the Annealing Lot and can't be split.", "Unable to split", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Private Function addToNextAnnealLot(ByVal coilID As String) As Boolean
        Dim nextAnnealLot As Integer = Val(cboAnnealLotNumber.Text) + 1
        Dim wei As Double = 0.0
        Dim crb As String = ""
        Dim sz As String = ""
        Dim heat As String = ""
        cmd = New SqlCommand("SELECT Weight, Carbon, SteelSize, HeatNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = coilID
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("Weight")) Then
                wei = reader.Item("Weight")
            End If
            If IsDBNull(reader.Item("Carbon")) Then
                crb = cboCarbon.Text
            Else
                crb = reader.Item("Carbon")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                sz = cboSteelSize.Text
            Else
                sz = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                heat = ""
            Else
                heat = reader.Item("HeatNumber")
            End If
        Else
            crb = cboCarbon.Text
            sz = cboSteelSize.Text
            heat = ""
        End If
        reader.Close()
        con.Close()

        cmd = New SqlCommand("SELECT AnnealedCarbon, AnnealedSteelSize, Status, HeatNumber FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = nextAnnealLot.ToString()

        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()
        ''checks to see if the carbon and steel size match the annealing lot and if so will just continue else will give user a message
        If reader.HasRows Then
            Dim carb As String = ""
            Dim steelSize As String = ""
            Dim stat As String = "CLOSED"
            Dim ht As String = heat
            reader.Read()
            If Not IsDBNull(reader.Item("AnnealedCarbon")) Then
                carb = reader.Item("AnnealedCarbon")
            End If
            If Not IsDBNull(reader.Item("AnnealedSteelSize")) Then
                steelSize = reader.Item("AnnealedSteelSize")
            End If
            If Not IsDBNull(reader.Item("Status")) Then
                stat = reader.Item("Status")
            End If
            If Not IsDBNull(reader.Item("HeatNumber")) Then
                ht = reader.Item("HeatNumber")
            End If
            reader.Close()
            ''checks to see if carbon and steelsize match needed for Annealing lot. Also makes sure the Annealing Lot is not Posted
            Select Case True
                Case (carb <> crb + "A")
                    MessageBox.Show("Next Annealing Lot has a different Carbon than the Coil ID #" + coilID + ". It has been defaulted to the yard.", "Sent to yard", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return True
                Case (steelSize <> sz)
                    MessageBox.Show("Next Annealing Lot has a different Steel Size than the Coil ID #" + coilID + ". It has been defaulted to the yard.", "Sent to yard", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return True
                Case (stat.Equals("CLOSED") Or stat.Equals("FINISHED"))
                    MessageBox.Show("Next Annealing Lot has been posted. Coil ID #" + coilID + " has been defaulted to the yard.", "Sent to yard", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return True
                Case (ht <> heat)
                    MessageBox.Show("Next Annealing Lot has a different Heat than the Coil ID #" + coilID + ". It has been defaulted to the yard.", "Sent to yard", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return True
            End Select
        Else
            reader.Close()

            cmd = New SqlCommand("INSERT INTO AnnealingLog (AnnealedRMID, RMID, AnnealLotNumber, AnnealedCarbon, AnnealedSteelSize, HeatNumber, TotalPoundsAnnealed, NumberOfCoils, DivisionID, Status) VALUES((SELECT RMID FROM RawMaterialsTable WHERE Carbon = @AnnealedCarbon AND SteelSize = @AnnealedSteelSize), (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @AnnealLotNumber, @AnnealedCarbon, @AnnealedSteelSize, @HeatNumber, @TotalPoundsAnnealed, @NumberOfCoils, @DivisionID, 'OPEN');", con)
            With cmd.Parameters
                .Add("@AnnealLotNumber", SqlDbType.VarChar).Value = nextAnnealLot.ToString()
                .Add("@AnnealedCarbon", SqlDbType.VarChar).Value = txtAnnealCarbon.Text
                .Add("@AnnealedSteelSize", SqlDbType.VarChar).Value = txtAnnealSteelSize.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                .Add("@HeatNumber", SqlDbType.VarChar).Value = heat
                .Add("@TotalPoundsAnnealed", SqlDbType.Float).Value = wei
                .Add("@NumberOfCoils", SqlDbType.Int).Value = 1
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
        Try
            'Create command to add Coils to Annealing Lot
            cmd = New SqlCommand("INSERT INTO AnnealingCoilLines (AnnealLotNumber, CoilID, AnnealedWeight)values(@AnnealLotNumber, @CoilID, (SELECT Weight FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID));", con)

            With cmd.Parameters
                .Add("@AnnealLotNumber", SqlDbType.Int).Value = nextAnnealLot.ToString()
                .Add("@CoilID", SqlDbType.VarChar).Value = coilID
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            sendErrorToDataBase("AnnealingLogForm - addToNextAnnealLot --Error trying to add coil to Anneal Lot #" + cboAnnealLotNumber.Text, "Coil #" + cboCoilID.Text, ex.ToString())
            MessageBox.Show("There was an error trying ot add the coil to the Anneal Lot. Coil has been sent to the Yard.", "Unable to complete adding coil process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return True
        End Try
        Return False
    End Function

    Private Sub cmdRemoveCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveCoil.Click
        If canDelete() Then
            Dim currentRow As Integer = cboDeleteCoilID.SelectedIndex
            ''deletes the coilID from the Annealing Lot
            Try
                cmd = New SqlCommand("DELETE FROM AnnealingCoilLines WHERE CoilID = @CoilID AND AnnealLotNumber = @AnnealLotNumber;", con)
                cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = dgvAnnealLotLines.Rows(currentRow).Cells("CoilID").Value
                cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            Catch ex As System.Exception
                con.Close()
                sendErrorToDataBase("AnnealingLogForm - addToNextAnnealLot --Error tryign to delete coil from Annealing Lot #" + cboAnnealLotNumber.Text, "CoilID #" + dgvAnnealLotLines.Rows(currentRow).Cells("CoilID").Value, ex.ToString())
                MessageBox.Show("There was an error trying to delete the Coil from the Annealing Lot. Contact System admin.", "Error deleting Coil from Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            ''updates the totals for the Annealing Lot to show that the coil was removed
            Try
                cmd = New SqlCommand("UPDATE AnnealingLog SET TotalPoundsAnnealed = (SELECT SUM(AnnealedWeight) FROM AnnealingCoilLines WHERE AnnealLotNumber = @AnnealLotNumber), NumberOfCoils = (SELECT COUNT(AnnealedWeight) FROM AnnealingCoilLines WHERE AnnealLotNumber = @AnnealLotNumber) WHERE AnnealLotNumber = @AnnealLotNumber;", con)
                With cmd.Parameters
                    .Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            Catch ex As System.Exception
                sendErrorToDataBase("AnnealingLogForm - cmdRemoveCoil_Click --Error trying to delete coil from Annealing Lot #" + cboAnnealLotNumber.Text, "CoilID #" + dgvAnnealLotLines.Rows(currentRow).Cells("CoilID").Value, ex.ToString())
                MessageBox.Show("There was an error trying to update totals for the Annealing Lot. Contact System admin.", "Error updating totals for Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            con.Close()
            LoadAnnealingTotals()
            ShowData()
            checkCarbonSizeHeatLock()
        End If

    End Sub

    Private Function canRemoveCoil()
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            MessageBox.Show("You must enter an Annealing Lot Number", "Enter an Annealing Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If cboAnnealLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a Valid Annealing Lot", "Enter a valid Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.SelectAll()
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If dgvAnnealLotLines.Rows.Count = 0 Then
            MessageBox.Show("There are no coils to delete", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboDeleteCoilID.SelectedIndex = -1 Then
            MessageBox.Show("Select a valid Coil ID", "Select a valid Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteCoilID.SelectAll()
            cboDeleteCoilID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cboPostAnnealingLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostAnnealingLot.Click
        If canPost() Then
            LoadAnnealingTotals()
            updateAnnealingLog()
            ''will update the Annealing lot so that no more changes can be made to the Lot
            Try
                cmd = New SqlCommand("UPDATE AnnealingLog SET Status = 'FINISHED' WHERE AnnealLotNumber = @AnnealLotNumber;", con)
                cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                con.Close()
                sendErrorToDataBase("AnnealingLogForm - cboPostAnnealingLot_Click  --Error trying to update the Annealing Lot to CLOSED status", "Annealing Lot #" + cboAnnealLotNumber.Text, ex.ToString())
                MessageBox.Show("There was an error trying to close the Annealing Lot. Contact system admin.", "Error trying to close Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If Not cboCarbon.Text.Equals(txtAnnealCarbon.Text) Then
                
                ''this will change the steel Carbon for each of the coils and will make the adjustment into the SteelAdjustmentTable
                Dim totalSteelCost As Double = getSteelCosting()
               

                ''writes the annealing lot transfer to the GL
                ''writeToGL(totalSteelCost, UsageKey)
            End If
            ''updates the coil so that it is the correct annealed carbon
            updateCoilCarbon()
            checkStatus()
        End If
    End Sub

    Private Function canPost() As Boolean
        If dgvAnnealLotLines.Rows.Count = 0 Then
            MessageBox.Show("You must have at leat 1 Coil in an Annealing Lot", "Add a Coil", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.Focus()
            Return False
        End If
        If canSave() = False Then
            Return False
        End If
        If String.IsNullOrEmpty(txtBase.Text) Then
            MessageBox.Show("You must enter a Base", "Enter a Base", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBase.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtProgram.Text) Then
            MessageBox.Show("You must enter a Program", "Enter a Program", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProgram.Focus()
            Return False
        End If
        Dim rslt As DialogResult = MessageBox.Show("Posting will close the Annealing batch so that no more changes are able to me made. Do you wish to continue?", "Continue?", MessageBoxButtons.YesNo)
        If rslt <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub writeToGL(ByVal totalCost As Double, ByVal UsageKey As Integer)
        ''gets key for next GL transaction
        cmd = New SqlCommand("BEGIN TRAN DECLARE @key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList)," _
                             + " @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList);" _
                             + " SET xact_abort on;" _
                             + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
        ''debit entry for GL postings
        cmd.CommandText += "(@key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

        With cmd.Parameters
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"
            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Annealing"
            .Add("@GLTransactionDate", SqlDbType.Date).Value = Now.ToShortDateString()
            .Add("@GLTransactionDebitAmount", SqlDbType.Float).Value = totalCost
            .Add("@GLTransactionCreditAmount", SqlDbType.Float).Value = 0
            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Annealing Lot #" & cboAnnealLotNumber.Text
            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
            .Add("@GLReferenceNumber", SqlDbType.Int).Value = UsageKey
            .Add("@GLReferenceLine", SqlDbType.Int).Value = 0
            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        End With

        If cboDivisionID.Text.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If
        ''credit entry go GL postings
        cmd.CommandText += ", (@key + 1, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"
        With cmd.Parameters
            .Add("@GLTransactionDebitAmount1", SqlDbType.Float).Value = 0
            .Add("@GLTransactionCreditAmount1", SqlDbType.Float).Value = totalCost
        End With

        cmd.CommandText += " ; COMMIT TRAN; SET xact_abort OFF;"
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        '**********************************
        'End of Ledger Entry
        '**********************************
    End Sub

    Private Sub tmrWaitToPrint_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrWaitToPrint.Tick
        tmrWaitToPrint.Stop()
        If neededLabels.Count > 0 Then
            ''creates the barcode object so the printer name is not needed each time it wants to print a label
            Dim bc As New BarcodeLabel
            bc.setupYardLabel(neededLabels(0))
            bc.PrintBarcodeLine()
            tmrWaitToPrint.Start()
            neededLabels.RemoveAt(0)
        End If
    End Sub

    Private Sub updateAnnealingLog(Optional ByVal status As String = "OPEN")
        cmd = New SqlCommand("UPDATE AnnealingLog SET RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @Size), AnnealedRMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon1 AND SteelSize = @Size1), HeatNumber = @HeatNumber, DateIn = @DateIn, DateOut = @DateOut, Comments = @Comments, PreviousAnnealLotNumber = @PreviousAnnealLotNumber, Base = @Base, Program = @Program, DivisionID = @DivisionID, AnnealedCarbon = @AnnealedCarbon, AnnealedSteelSize = @AnnealedSteelSize, TotalPoundsAnnealed = @TotalPoundsAnnealed, NumberOfCoils = @NumberOfCoils WHERE AnnealLotNumber = @AnnealLotNumber;", con)

        With cmd.Parameters
            .Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)
            .Add("@Carbon1", SqlDbType.VarChar).Value = txtAnnealCarbon.Text
            .Add("@Size1", SqlDbType.VarChar).Value = txtAnnealSteelSize.Text
            .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            .Add("@Size", SqlDbType.VarChar).Value = cboSteelSize.Text
            .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
            .Add("@DateIn", SqlDbType.Date).Value = dtpDateIn.Text
            .Add("@DateOut", SqlDbType.Date).Value = dtpDateOut.Text
            .Add("@Comments", SqlDbType.VarChar).Value = txtComments.Text
            .Add("@PreviousAnnealLotNumber", SqlDbType.VarChar).Value = txtPreviousLot.Text
            .Add("@Base", SqlDbType.VarChar).Value = txtBase.Text
            .Add("@Program", SqlDbType.VarChar).Value = txtProgram.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@AnnealedCarbon", SqlDbType.VarChar).Value = txtAnnealCarbon.Text
            .Add("@AnnealedSteelSize", SqlDbType.VarChar).Value = txtAnnealSteelSize.Text
            .Add("@TotalPoundsAnnealed", SqlDbType.Float).Value = txtTotalWeight.Text
            .Add("@NumberOfCoils", SqlDbType.Int).Value = txtNumberOfCoils.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    ''gets the cost per each coil
    Private Function getSteelCosting() As Double
        'Get RMID from test fields - carbon, steel size
        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetRMID = ""
        End Try
        con.Close()

        Dim totalCost As Double = 0D
        For i As Integer = 0 To dgvAnnealLotLines.Rows.Count - 1

            Dim TotalCoilCost As Double = SteelModule.GetSteelCosting(GetRMID, dgvAnnealLotLines.Rows(i).Cells("AnnealedWeight").Value, con, dtpDateOut.Value)
            Dim CostPerPound As Double = Math.Round(TotalCoilCost / dgvAnnealLotLines.Rows(i).Cells("AnnealedWeight").Value, 5, MidpointRounding.AwayFromZero)
            ''adds the entry into the steel usage table to show that the origional steel was used
            Dim UsageKey As Integer = addUsageEntry(i, CostPerPound, TotalCoilCost)
            addSteelTransaction(dgvAnnealLotLines.Rows(i).Cells("AnnealedWeight").Value, CostPerPound, TotalCoilCost, cboCarbon.Text, cboSteelSize.Text, UsageKey, 0, "SUBTRACT")
            ''adds entry to return to Yard for the coils in the annealing lot
            Dim EntryKey As Integer = addReturnToYardEntry(UsageKey, i, CostPerPound, TotalCoilCost)
            addSteelTransaction(dgvAnnealLotLines.Rows(i).Cells("AnnealedWeight").Value, CostPerPound, TotalCoilCost, txtAnnealCarbon.Text, txtAnnealSteelSize.Text, EntryKey, 0, "ADD")

            totalCost += TotalCoilCost
        Next
        ''adds the cost Tier
        If Not EmployeeCompanyCode.Equals("TST") Then
            addCostTier(totalCost)
        End If
        Return totalCost
    End Function

    ''add entry into steel transaction table for either adding or subtracting
    Private Sub addSteelTransaction(ByVal weight As Double, ByVal CostPerPound As Double, ByVal TotalExtendedCost As Double, ByVal carb As String, ByVal siz As String, ByVal UsageKey As Integer, ByVal LineKey As Integer, ByVal mat As String)
        ''inserts the entry into the SteelTransactionTable
        If mat.Equals("ADD") Then
            cmd = New SqlCommand("INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType, SteelTransactionDate)" _
                                 + " VALUES((SELECT isnull(MAX(TransactionNumber) + 1,7700001) FROM SteelTransactionTable), @DivisionID, @Carbon, @SteelSize, @Quantity, @SteelCost, @ExtendedCost,  @SteelReferenceNumber, @SteelReferenceLine, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @TransactionMath, @TransactionType, @SteelTransactionDate);", con)
            cmd.Parameters.Add("@TransactionType", SqlDbType.VarChar).Value = "ANNEAL ENTRY"
        Else
            cmd = New SqlCommand("INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType, SteelTransactionDate)" _
                                 + " VALUES((SELECT isnull(MAX(TransactionNumber) + 1,7700001) FROM SteelTransactionTable), @DivisionID, @Carbon, @SteelSize, @Quantity, @SteelCost, @ExtendedCost, @SteelReferenceNumber, @SteelReferenceLine, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @TransactionMath, @TransactionType, @SteelTransactionDate);", con)
            cmd.Parameters.Add("@TransactionType", SqlDbType.VarChar).Value = "ANNEAL REMOVED"
        End If

        With cmd.Parameters
            .Add("@Quantity", SqlDbType.Float).Value = Math.Round(weight, 2, MidpointRounding.AwayFromZero)
            .Add("@SteelCost", SqlDbType.VarChar).Value = CostPerPound
            .Add("@ExtendedCost", SqlDbType.Float).Value = TotalExtendedCost
            .Add("@SteelReferenceNumber", SqlDbType.Int).Value = UsageKey
            .Add("@SteelReferenceLine", SqlDbType.Int).Value = LineKey
            .Add("@Carbon", SqlDbType.VarChar).Value = carb
            .Add("@SteelSize", SqlDbType.VarChar).Value = siz
            .Add("@TransactionMath", SqlDbType.VarChar).Value = mat
            .Add("@SteelTransactionDate", SqlDbType.Date).Value = dtpLotCreationDate.Text
        End With

        If cboDivisionID.Text.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
    End Sub

    ''updates the carbon for the coil so that it is showin as Annealed
    Private Sub updateCoilCarbon()
        For i As Integer = 0 To dgvAnnealLotLines.Rows.Count - 1
            Try
                'UPDATE Steel Coil to Annealed Carbon Type
                cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Carbon = @Carbon, Description = @Description, AnnealLot = @AnnealLot WHERE CoilID = @CoilID;", con)

                With cmd.Parameters
                    .Add("@CoilID", SqlDbType.VarChar).Value = dgvAnnealLotLines.Rows(i).Cells("CoilID").Value
                    .Add("@Carbon", SqlDbType.VarChar).Value = txtAnnealCarbon.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtAnnealedDescription.Text
                    .Add("@AnnealLot", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            Catch ex As System.Exception
                sendErrorToDataBase("AnnealingLogForm - cboPostAnnealingLot_Click --Error trying to update CharterSteelCoilIdentification table to show that it was annealed Anneal Lot #" + cboAnnealLotNumber.Text, "Coil ID #" + dgvAnnealLotLines.Rows(i).Cells("CoilID").Value, ex.ToString())
            End Try
        Next
        con.Close()
    End Sub

    ''grabs the total weight of the coils in the annealing lot and will add the cost tier for the carbon and steel size
    Private Sub addCostTier(ByVal totalCost As Double)
        Dim NewUpperLimit, LowerLimit, UpperLimit, weight As Double

        cmd = New SqlCommand("SELECT SUM(AnnealedWeight) FROM AnnealingCoilLines WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            weight = CDbl(cmd.ExecuteScalar())
        Catch ex As System.Exception
            weight = 0.0
        End Try

        Dim UpperLimitCommand As New SqlCommand("SELECT UpperLimit FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize));", con)
        UpperLimitCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtAnnealCarbon.Text
        UpperLimitCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = txtAnnealSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
        Catch ex As System.Exception
            UpperLimit = 0
        End Try

        'Calculate the NEW Lower/Upper Limit for the next post
        LowerLimit = UpperLimit + 1
        NewUpperLimit = LowerLimit + weight - 1

        Try
            cmd = New SqlCommand("Insert Into SteelCostingTable (RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values((SELECT AnnealedRMID FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber), (SELECT AnnealedCarbon FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber), (SELECT AnnealedSteelSize FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber), @CostingDate, @SteelCostPerPound, @CostingQuantity, @Status, @LowerLimit, @UpperLimit, (SELECT isnull(MAX(TransactionNumber) + 1, 73700001) FROM SteelCostingTable), @ReferenceNumber, @ReferenceLine);", con)

            With cmd.Parameters
                .Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)
                .Add("@CostingDate", SqlDbType.Date).Value = Now.Date
                .Add("@SteelCostPerPound", SqlDbType.Float).Value = Math.Round(totalCost / weight, 5, MidpointRounding.AwayFromZero)
                .Add("@CostingQuantity", SqlDbType.Float).Value = weight
                .Add("@Status", SqlDbType.VarChar).Value = "STEEL ANNEALED"
                .Add("@LowerLimit", SqlDbType.Float).Value = LowerLimit
                .Add("@UpperLimit", SqlDbType.Float).Value = NewUpperLimit
                .Add("@ReferenceNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)
                .Add("@ReferenceLine", SqlDbType.Int).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            sendErrorToDataBase("SteelCoilReceiving - addCostTiers --Error trying to inserting Annealing Lot into SteelCostingTable", "Annealing Lot #" + cboAnnealLotNumber.Text, ex.ToString())
            MessageBox.Show("There was an issue with updating cost tiers. Contact system admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub dtpLotCreationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLotCreationDate.ValueChanged
        If dtpLotCreationDate.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        If Not String.IsNullOrEmpty(FocusedField.name) Then
            If FocusedField.name.Equals("txtHeatNumber") Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub txtBase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBase.TextChanged
        If Not String.IsNullOrEmpty(FocusedField.name) Then
            If FocusedField.name.Equals("txtBase") Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub txtProgram_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProgram.TextChanged
        If Not String.IsNullOrEmpty(FocusedField.name) Then
            If FocusedField.name.Equals("txtProgram") Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub dtpDateIn_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateIn.ValueChanged
        If dtpDateIn.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub checkCarbonSizeHeatLock()
        If dgvAnnealLotLines.Rows.Count > 0 Then
            cboCarbon.Enabled = False
            cboSteelSize.Enabled = False
            txtHeatNumber.ReadOnly = True
        Else
            cboCarbon.Enabled = True
            cboSteelSize.Enabled = True
            txtHeatNumber.ReadOnly = False
        End If
    End Sub

    Private Function addUsageEntry(ByVal i As Integer, ByVal CostPerPound As Double, ByVal TotalCoilCost As Double) As Integer
        cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(SteelUsageKey)+1, 63000001) FROM SteelUsageTable);" _
                             + " INSERT INTO SteelUsageTable (SteelUsageKey, UsageDate, ReferenceNumber, ReferenceLineNumber, UsageWeight, SteelCost, ExtendedCost, RMID, DivisionID, Status, PrintDate)" _
                             + " VALUES(@Key, @Date, @ReferenceNumber, @ReferenceLineNumber, @UsageWeight, @SteelCost, @ExtendedCost, (SELECT RMID FROM AnnealingLog WHERE AnnealLotNumber = @ReferenceNumber), @DivisionID, 'POSTED', @PrintDate);" _
                             + " SELECT @Key;", con)
        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = dtpLotCreationDate.Text
            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
            .Add("@ReferenceLineNumber", SqlDbType.Int).Value = i
            .Add("@UsageWeight", SqlDbType.Float).Value = dgvAnnealLotLines.Rows(i).Cells("AnnealedWeight").Value
            .Add("@SteelCost", SqlDbType.Float).Value = CostPerPound
            .Add("@ExtendedCost", SqlDbType.Float).Value = TotalCoilCost
            .Add("@PrintDate", SqlDbType.DateTime2).Value = Now
        End With

        If cboDivisionID.Text.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Dim UsageKey As Integer = Val(cmd.ExecuteScalar())
        con.Close()
        Return UsageKey
    End Function

    Private Function addReturnToYardEntry(ByVal UsageKey As Integer, ByVal i As Integer, ByVal CostPerPound As Double, ByVal TotalCoilCost As Double) As Integer
        Dim key As Integer = 0
        cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(SteelReturnKey) + 1, 63000001) FROM SteelYardEntryTable);" _
                                         + " INSERT INTO SteelYardEntryTable (SteelReturnKey, ReturnDate, CoilID, ReturnWeight, RMID, DivisionID, Status, HeatNumber, Comment, ReferenceNumber, ReferenceLineNumber, PrintDate, SteelCost, ExtendedCost) VALUES (@Key, @ReturnDate, @CoilID, @ReturnWeight, (SELECT AnnealedRMID FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber), @DivisionID, 'POSTED', @HeatNumber, 'ANNEALED', @ReferenceNumber, @ReferenceLineNumber, @PrintDate, @SteelCost, @ExtendedCost); SELECT @Key", con)
        With cmd.Parameters
            .Add("@ReturnDate", SqlDbType.Date).Value = dtpLotCreationDate.Text
            .Add("@AnnealLotNumber", SqlDbType.Int).Value = cboAnnealLotNumber.Text
            .Add("@CoilID", SqlDbType.VarChar).Value = dgvAnnealLotLines.Rows(i).Cells("CoilID").Value
            .Add("@ReturnWeight", SqlDbType.Float).Value = dgvAnnealLotLines.Rows(i).Cells("AnnealedWeight").Value
            .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
            .Add("@ReferenceNumber", SqlDbType.Int).Value = UsageKey
            .Add("@ReferenceLineNumber", SqlDbType.Int).Value = 0
            .Add("@PrintDate", SqlDbType.DateTime2).Value = Now
            .Add("@SteelCost", SqlDbType.Float).Value = CostPerPound
            .Add("@ExtendedCost", SqlDbType.Float).Value = TotalCoilCost
        End With

        If cboDivisionID.Text.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        key = cmd.ExecuteScalar()

        con.Close()
        Return key
    End Function

    Private Sub AnnealingLogForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        While neededLabels.Count > 0
            System.Windows.Forms.Application.DoEvents()
        End While
    End Sub

    Private Sub bgwkCoilID_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkCoilID.DoWork
        cmd1 = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status = 'RAW';", con1)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd1

        If con1.State = ConnectionState.Closed Then con1.Open()
        myAdapter2.Fill(ds2, "CharterSteelCoilIdentification")
        con1.Close()
    End Sub

    Private Sub bgwkCoilID_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkCoilID.RunWorkerCompleted
        isLoaded = False
        Dim temp As String = cboCoilID.Text
        cboCoilID.DisplayMember = "CoilID"
        cboCoilID.DataSource = ds2.Tables("CharterSteelCoilIdentification")
        cboCoilID.SelectedIndex = -1
        cboCoilID.Text = temp
        isLoaded = True
    End Sub

    Private Sub cboCoilID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCoilID.KeyUp
        If barcodeScanner And e.KeyCode = Keys.Enter Then
            barcodeScanner = False
            isLoaded = False
            tmrScanTime.Stop()
            totalScanTime = 0
            If Char.ToLower(scannedSequence(0)).Equals("s"c) Then
                cboCoilID.Text = scannedSequence.Substring(1, scannedSequence.Length - 1)
            Else
                cboCoilID.Text = scannedSequence
            End If

            scannedSequence = ""
            cboCoilID.SelectionStart = cboCoilID.Text.Length
            isLoaded = True
        End If
        If e.KeyCode = Keys.Enter And canMove Then
            e.Handled = True
            cmdAddCoil.Focus()
        Else
            canMove = True
        End If
    End Sub

    Private Sub cmdEnterCoil_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cmdAddCoil.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            canMove = False
        End If
    End Sub

    Private Sub cmdZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZero.Click
        addText(sender, e, "0")
    End Sub

    Private Sub cmdDecimal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDecimal.Click
        addText(sender, e, ".")
    End Sub

    Private Sub cmdForwardSlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForwardSlash.Click
        addText(sender, e, "/")
    End Sub

    Private Sub cmdOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOne.Click
        addText(sender, e, "1")
    End Sub

    Private Sub cmdTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTwo.Click
        addText(sender, e, "2")
    End Sub

    Private Sub cmdThree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThree.Click
        addText(sender, e, "3")
    End Sub

    Private Sub cmdFour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFour.Click
        addText(sender, e, "4")
    End Sub

    Private Sub cmdFive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFive.Click
        addText(sender, e, "5")
    End Sub

    Private Sub cmdSix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSix.Click
        addText(sender, e, "6")
    End Sub

    Private Sub cmdSeven_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeven.Click
        addText(sender, e, "7")
    End Sub

    Private Sub cmdEight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEight.Click
        addText(sender, e, "8")
    End Sub

    Private Sub cmdNine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNine.Click
        addText(sender, e, "9")
    End Sub

    Private Sub addText(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal tex As String, Optional ByVal charCount As Integer = 1)
        If Not String.IsNullOrEmpty(FocusedField.name) Then
            ''check to see if there is a selection
            If FocusedField.SelectionLength > 0 Then
                cmdBackspace_Click(sender, e)
            End If
            If FocusedField.Position = FocusedField.Text.Length Then
                FocusedField.Text += tex
            Else
                If FocusedField.Position > FocusedField.Text.Length Then
                    FocusedField.Position = FocusedField.Text.Length
                End If
                FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + tex + FocusedField.Text.Substring(FocusedField.Position, FocusedField.Text.Length - FocusedField.Position)
            End If
            FocusedField.Position += charCount
            'FocusedField.Focus()        
        End If
    End Sub

    Private Sub cmdBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackspace.Click
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Text.Length > 0 Then
                wasDeleted = True
                ''check to see if there was a selection made
                If FocusedField.SelectionLength > 0 Then
                    Select Case True
                        Case FocusedField.SelectionLength = FocusedField.Text.Length
                            FocusedField.Text = ""
                            Exit Select
                        Case FocusedField.Position = 0
                            FocusedField.Text = FocusedField.Text.Substring(FocusedField.SelectionLength, FocusedField.Text.Length - FocusedField.SelectionLength)
                            Exit Select
                        Case FocusedField.SelectionLength = (FocusedField.Text.Length - FocusedField.Position)
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position)
                            Exit Select
                        Case Else
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + FocusedField.Text.Substring(FocusedField.Position + FocusedField.SelectionLength, FocusedField.Text.Length - (FocusedField.Position + FocusedField.SelectionLength))
                    End Select
                Else
                    ''check to se if we are at the back of the text
                    If FocusedField.Position = FocusedField.Text.Length Then
                        FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Text.Length - 1)
                    Else
                        If FocusedField.Position > 0 Then
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position - 1) + FocusedField.Text.Substring(FocusedField.Position, FocusedField.Text.Length - FocusedField.Position)
                        End If
                    End If
                End If
            End If
            FocusedField.SelectionLength = 0
        End If
    End Sub

    Private Sub hideSuggest(ByVal ctrl As String)
        If Not String.IsNullOrEmpty(ctrl) Then
            Select Case ctrl
                Case "cboCoilID"
                    lstCoilIDSuggest.Hide()
                Case "cboAnnealLotNumber"
                    lstAnnealingSuggest.Hide()
                Case "cboCarbon"
                    lstCarbonSuggest.Hide()
                Case "cboSteelSize"
                    lstSizeSuggest.Hide()
            End Select
        End If
    End Sub

    Private Sub cboAnnealLotNumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAnnealLotNumber.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("cboAnnealLotNumber") Then
                hideSuggest(FocusedField.name)
                FocusedField = New usefulFunctions.FocusedItem(cboAnnealLotNumber)
            Else
                cboAnnealLotNumber.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(cboAnnealLotNumber)
        End If
    End Sub

    Private Sub cboCarbon_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboCarbon") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(cboCarbon)
            Else
                cboCarbon.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(cboCarbon)
        End If
    End Sub

    Private Sub cboSteelSize_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboSteelSize") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(cboSteelSize)
            Else
                cboSteelSize.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(cboSteelSize)
        End If
    End Sub

    Private Sub cboCoilID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoilID.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboCoilID") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(cboCoilID)
            Else
                cboCoilID.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(cboCoilID)
        End If
    End Sub

    Private Sub txtHeatNumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtHeatNumber") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(txtHeatNumber)
            Else
                txtHeatNumber.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(txtHeatNumber)
        End If
    End Sub

    Private Sub txtBase_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBase.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtBase") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(txtBase)
            Else
                txtBase.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(txtBase)
        End If
    End Sub

    Private Sub txtProgram_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProgram.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtProgram") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(txtProgram)
            Else
                txtProgram.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(txtProgram)
        End If
    End Sub

    Private Sub txtPreviousLot_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreviousLot.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtPreviousLot") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(txtPreviousLot)
            Else
                txtPreviousLot.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(txtPreviousLot)
        End If
    End Sub

    Private Sub txtComments_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtComments") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(txtComments)
            Else
                txtComments.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(txtComments)
        End If
    End Sub

    Private Sub cmdL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL.Click
        addText(sender, e, "L")
    End Sub

    Private Sub cmdM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdM.Click
        addText(sender, e, "M")
    End Sub

    Private Sub cmdN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdN.Click
        addText(sender, e, "N")
    End Sub

    Private Sub cmdB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdB.Click
        addText(sender, e, "B")
    End Sub

    Private Sub cmdV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdV.Click
        addText(sender, e, "V")
    End Sub

    Private Sub cmdC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdC.Click
        addText(sender, e, "C")
    End Sub

    Private Sub cmdX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdX.Click
        addText(sender, e, "X")
    End Sub

    Private Sub cmdZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZ.Click
        addText(sender, e, "Z")
    End Sub

    Private Sub cmdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdA.Click
        addText(sender, e, "A")
    End Sub

    Private Sub cmdQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQ.Click
        addText(sender, e, "Q")
    End Sub

    Private Sub cmdW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdW.Click
        addText(sender, e, "W")
    End Sub

    Private Sub cmdE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdE.Click
        addText(sender, e, "E")
    End Sub

    Private Sub cmdR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdR.Click
        addText(sender, e, "R")
    End Sub

    Private Sub cmdT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdT.Click
        addText(sender, e, "T")
    End Sub

    Private Sub cmdY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdY.Click
        addText(sender, e, "Y")
    End Sub

    Private Sub cmdU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdU.Click
        addText(sender, e, "U")
    End Sub

    Private Sub cmdI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdI.Click
        addText(sender, e, "I")
    End Sub

    Private Sub cmdO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdO.Click
        addText(sender, e, "O")
    End Sub

    Private Sub cmdP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdP.Click
        addText(sender, e, "P")
    End Sub

    Private Sub cmdS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS.Click
        addText(sender, e, "S")
    End Sub

    Private Sub cmdD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdD.Click
        addText(sender, e, "D")
    End Sub

    Private Sub cmdF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF.Click
        addText(sender, e, "F")
    End Sub

    Private Sub cmdG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdG.Click
        addText(sender, e, "G")
    End Sub

    Private Sub cmdH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdH.Click
        addText(sender, e, "H")
    End Sub

    Private Sub cmdJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJ.Click
        addText(sender, e, "J")
    End Sub

    Private Sub cmdK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdK.Click
        addText(sender, e, "K")
    End Sub

    Private Sub cmdSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSpace.Click
        addText(sender, e, " ")
    End Sub

    Private Sub cmdDash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDash.Click
        addText(sender, e, "-")
    End Sub

    Private Sub cboAnnealLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAnnealLotNumber.TextChanged
        If isLoaded Then
            lstAnnealingSuggest.Visible = False
            lstAnnealingSuggest.Items.Clear()
            If canSuggestLot() Then
                For i As Integer = 0 To ds3.Tables("AnnealingLog").Rows.Count - 1
                    If ds3.Tables("AnnealingLog").Rows(i).Item("AnnealLotNumber").ToString.Contains(cboAnnealLotNumber.Text) Then
                        lstAnnealingSuggest.Items.Add(ds3.Tables("AnnealingLog").Rows(i).Item("AnnealLotNumber"))
                    End If
                Next
                formatListbox(lstAnnealingSuggest)
            End If
        End If
    End Sub

    Private Function canSuggestLot() As Boolean
        If String.IsNullOrEmpty(FocusedField.Name) Then
            Return False
        End If
        If Not FocusedField.Name.Equals("cboAnnealLotNumber") Then
            Return False
        End If
        If cboAnnealLotNumber.Focused Then
            Return False
        End If
        If cboAnnealLotNumber.Text.Length = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub formatListbox(ByRef lstbx As System.Windows.Forms.ListBox)
        If lstbx.Items.Count < 5 Then
            If lstbx.Items.Count = 0 Then
                lstbx.Height = 40
            Else
                lstbx.Height = lstbx.Items.Count * 40
            End If
        Else
            lstbx.Height = 5 * 20
        End If
        lstbx.Show()
    End Sub

    Private Sub lstAnnealingSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAnnealingSuggest.SelectedValueChanged
        If lstAnnealingSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstAnnealingSuggest.SelectedItem) Then
                FocusedField = New usefulFunctions.FocusedItem()
                cboAnnealLotNumber.Text = lstAnnealingSuggest.SelectedItem
                lstAnnealingSuggest.Hide()
                cboCoilID.Focus()
            End If
        End If
    End Sub

    Private Sub cboCarbon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.TextChanged
        lstCarbonSuggest.Visible = False
        lstCarbonSuggest.Items.Clear()
        If canSuggestCarbon() Then
            For i As Integer = 0 To ds4.Tables("RawMaterialsTable").Rows.Count - 1
                If ds4.Tables("RawMaterialsTable").Rows(i).Item("Carbon").ToString.Contains(cboCarbon.Text) Then
                    lstCarbonSuggest.Items.Add(ds4.Tables("RawMaterialsTable").Rows(i).Item("Carbon"))
                End If
            Next
            formatListbox(lstCarbonSuggest)
        End If
    End Sub

    Private Function canSuggestCarbon() As Boolean
        If String.IsNullOrEmpty(FocusedField.Name) Then
            Return False
        End If
        If Not FocusedField.Name.Equals("cboCarbon") Then
            Return False
        End If
        If cboCarbon.Focused Then
            Return False
        End If
        If cboCarbon.Text.Length = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub lstCarbonSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCarbonSuggest.SelectedValueChanged
        If lstCarbonSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstCarbonSuggest.SelectedItem) Then
                FocusedField = New usefulFunctions.FocusedItem()
                cboCarbon.Text = lstCarbonSuggest.SelectedItem
                lstCarbonSuggest.Hide()
                cboSteelSize.Focus()
            End If
        End If
    End Sub

    Private Sub cboSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.TextChanged
        lstSizeSuggest.Visible = False
        lstSizeSuggest.Items.Clear()
        If canSuggestSize() Then
            For i As Integer = 0 To ds1.Tables("RawMaterialsTable").Rows.Count - 1
                If ds1.Tables("RawMaterialsTable").Rows(i).Item("SteelSize").ToString.Contains(cboSteelSize.Text) Then
                    lstSizeSuggest.Items.Add(ds1.Tables("RawMaterialsTable").Rows(i).Item("SteelSize"))
                End If
            Next
            formatListbox(lstSizeSuggest)
        End If
    End Sub

    Private Function canSuggestSize() As Boolean
        If String.IsNullOrEmpty(FocusedField.Name) Then
            Return False
        End If
        If Not FocusedField.Name.Equals("cboSteelSize") Then
            Return False
        End If
        If cboSteelSize.Focused Then
            Return False
        End If
        If cboSteelSize.Text.Length = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub lstSizeSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSizeSuggest.SelectedValueChanged
        If lstSizeSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstSizeSuggest.SelectedItem) Then
                FocusedField = New usefulFunctions.FocusedItem()
                cboSteelSize.Text = lstSizeSuggest.SelectedItem
                lstSizeSuggest.Hide()
                cboCoilID.Focus()
            End If
        End If
    End Sub

    Private Sub lstCoilIDSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCoilIDSuggest.SelectedValueChanged
        If lstCoilIDSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstCoilIDSuggest.SelectedItem) Then
                FocusedField = New usefulFunctions.FocusedItem()
                cboCoilID.Text = lstCoilIDSuggest.SelectedItem
                lstCoilIDSuggest.Hide()
                cboCoilID.Focus()
            End If
        End If
    End Sub

    Private Sub txtPreviousLot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreviousLot.TextChanged
        If txtPreviousLot.Focused Then
            needsSaved = True
        ElseIf FocusedField.Name.Equals("txtPreviousLot") Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged
        If txtComments.Focused Then
            needsSaved = True
        ElseIf FocusedField.Name.Equals("txtComments") Then
            needsSaved = True
        End If
    End Sub

    Private Sub cboAnnealLotNumber_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboAnnealLotNumber.MouseUp
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Name.Equals("cboAnnealLotNumber") Then
                FocusedField.Position = cboAnnealLotNumber.SelectionStart
                FocusedField.SelectionLength = cboAnnealLotNumber.SelectionLength
            End If
        End If
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        Select Case FocusedField.Name
            Case "cboAnnealLotNumber"
                If lstAnnealingSuggest.Items.Count = 1 Then
                    If Not cboAnnealLotNumber.Text.Equals(lstAnnealingSuggest.Items(0)) Then
                        cboAnnealLotNumber.Text = lstAnnealingSuggest.Items(0)
                    End If
                End If
                If String.IsNullOrEmpty(cboCarbon.Text) Then
                    cboCarbon.Focus()
                Else
                    cboCoilID.Focus()
                End If
            Case "cboCarbon"
                If lstCarbonSuggest.Items.Count = 1 Then
                    If Not cboCarbon.Text.Equals(lstCarbonSuggest.Items(0)) Then
                        cboCarbon.Text = lstCarbonSuggest.Items(0)
                    End If
                End If
                cboSteelSize.Focus()
            Case "cboSteelSize"
                If lstSizeSuggest.Items.Count = 1 Then
                    If Not cboSteelSize.Text.Equals(lstSizeSuggest.Items(0)) Then
                        cboSteelSize.Text = lstSizeSuggest.Items(0)
                    End If
                End If
                cboCoilID.Focus()
            Case "cboCoilID"
                If lstCoilIDSuggest.Items.Count = 1 Then
                    If Not cboCoilID.Text.Equals(lstCoilIDSuggest.Items(0)) Then
                        cboCoilID.Text = lstCoilIDSuggest.Items(0)
                    End If
                End If
                If String.IsNullOrEmpty(txtHeatNumber.Text) Then
                    txtHeatNumber.Focus()
                Else
                    txtBase.Focus()
                End If
                txtHeatNumber.Focus()
            Case "txtHeatNumber"
                txtBase.Focus()
            Case "txtBase"
                txtProgram.Focus()
            Case "txtProgram"
                txtPreviousLot.Focus()
            Case "txtPreviousLot"
                txtComments.Focus()
            Case "txtComments"
                cmdPostAnnealingLot.Focus()
            Case Else
                cboAnnealLotNumber.Focus()
        End Select
    End Sub

    Private Sub cmdPostAnnealingLot_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostAnnealingLot.Enter
        FocusedField = New usefulFunctions.FocusedItem()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If FocusedField.isSet() Then
            FocusedField.Text = ""
            FocusedField.Focus()
        End If
    End Sub

    Private Sub cboCarbon_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboCarbon.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = cboCarbon.SelectionStart
            FocusedField.SelectionLength = cboCarbon.SelectionLength
        End If
    End Sub

    Private Sub cboSteelSize_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboSteelSize.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = cboSteelSize.SelectionStart
            FocusedField.SelectionLength = cboSteelSize.SelectionLength
        End If
    End Sub

    Private Sub cboCoilID_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboCoilID.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = cboCoilID.SelectionStart
            FocusedField.SelectionLength = cboCoilID.SelectionLength
        End If
    End Sub

    Private Sub txtHeatNumber_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtHeatNumber.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtHeatNumber.SelectionStart
            FocusedField.SelectionLength = txtHeatNumber.SelectionLength
        End If
    End Sub

    Private Sub txtBase_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBase.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtBase.SelectionStart
            FocusedField.SelectionLength = txtBase.SelectionLength
        End If
    End Sub

    Private Sub txtProgram_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtProgram.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtProgram.SelectionStart
            FocusedField.SelectionLength = txtProgram.SelectionLength
        End If
    End Sub

    Private Sub txtPreviousLot_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPreviousLot.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtPreviousLot.SelectionStart
            FocusedField.SelectionLength = txtPreviousLot.SelectionLength
        End If
    End Sub

    Private Sub txtComments_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtComments.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtComments.SelectionStart
            FocusedField.SelectionLength = txtComments.SelectionLength
        End If
    End Sub

    Private Sub txtAnnealCarbon_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAnnealCarbon.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtAnnealCarbon.SelectionStart
            FocusedField.SelectionLength = txtAnnealCarbon.SelectionLength
        End If
    End Sub

    Private Sub txtAnnealCarbon_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAnnealCarbon.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtAnnealCarbon") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(txtAnnealCarbon)
            Else
                txtAnnealCarbon.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(txtAnnealCarbon)
        End If
    End Sub

    Private Sub txtAnnealCarbon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAnnealCarbon.TextChanged
        If txtAnnealCarbon.Focused Then
            LoadAnnealedDescription()
        ElseIf FocusedField.Name.Equals("txtAnnealCarbon") Then
            LoadAnnealedDescription()
        End If
    End Sub

    Private Sub txtAnnealSteelSize_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAnnealSteelSize.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtAnnealSteelSize.SelectionStart
            FocusedField.SelectionLength = txtAnnealSteelSize.SelectionLength
        End If
    End Sub

    Private Sub txtAnnealSteelSize_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAnnealSteelSize.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtAnnealSteelSize") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New usefulFunctions.FocusedItem(txtAnnealSteelSize)
            Else
                txtAnnealSteelSize.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New usefulFunctions.FocusedItem(txtAnnealSteelSize)
        End If
    End Sub

    Private Sub UpdateTotalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateTotalToolStripMenuItem.Click
        LoadAnnealingTotals()
    End Sub

    Private Sub UnLockAnnealToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockAnnealToolStripMenuItem.Click
        cmd = New SqlCommand("UPDATE AnnealingLog SET Status = 'OPEN' WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        checkStatus()
    End Sub

    Private Sub PrintSampleTagToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSampleTagToolStripMenuItem.Click
        If canPrintSampleLabel() Then
            ''creates the barcode object so the printer name is not needed each time it wants to print a label
            Dim bc As New BarcodeLabel
            bc.SetupSampleLabel(cboAnnealLotNumber.Text)
            If Environment.UserName.Contains("WireyardTablet") Then
                bc.PrintBarcodeLine("ZebraWireyard")
            Else
                bc.PrintBarcodeLine()
            End If
        End If
    End Sub

    Private Function canPrintSampleLabel() As Boolean
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            MessageBox.Show("You must enter an Anneal Lot Number", "Enter an Anneal Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If cboAnnealLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Anneal Lot Number", "Enter an Anneal Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.SelectAll()
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If Not checkStatus() Then
            Return False
        End If
        Return True
    End Function

    Private Sub cboCoilID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCoilID.KeyPress
        If barcodeScanner Then
            If e.KeyChar = "<"c Then
                e.KeyChar = Nothing
                e.Handled = True
            Else
                scannedSequence += e.KeyChar
            End If
        End If
    End Sub

    Private Sub cboCoilID_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cboCoilID.PreviewKeyDown
        If e.Modifiers = Keys.Shift And e.KeyCode = Keys.Oemcomma Then
            barcodeScanner = True
            tmrScanTime.Start()
        End If
    End Sub

    Private Sub tmrScanTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrScanTime.Tick
        If totalScanTime >= 5 Then
            tmrScanTime.Stop()
            totalScanTime = 0
            barcodeScanner = False
            scannedSequence = "<" + scannedSequence
            cboCoilID.Text = scannedSequence
            cboCoilID.SelectionStart = cboCoilID.Text.Length
            scannedSequence = ""
        Else
            totalScanTime += 1
        End If
    End Sub

    Private Sub cboCoilID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoilID.Leave
        If barcodeScanner Then
            barcodeScanner = False
        End If
    End Sub
End Class