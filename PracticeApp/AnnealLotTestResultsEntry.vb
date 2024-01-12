Imports System.Data.SqlClient

Public Class AnnealLotTestResultsEntry
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1 As New SqlDataAdapter
    Dim ds, ds1 As DataSet

    Dim isLoaded As Boolean = False
    Dim needsSaved As Boolean = False

    Private Sub LoadAnnealingLotNumbers()
        If EmployeeCompanyCode.Equals("TST") Then
            cmd = New SqlCommand("SELECT AnnealLotNumber FROM AnnealingLog WHERE DivisionID = 'TST';", con)
        Else
            cmd = New SqlCommand("SELECT AnnealLotNumber FROM AnnealingLog WHERE DivisionID <> 'TST';", con)
        End If

        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "AnnealingLog")
        con.Close()

        cboAnnealLotNumber.DisplayMember = "AnnealLotNumber"
        cboAnnealLotNumber.DataSource = ds.Tables("AnnealingLog")
        cboAnnealLotNumber.SelectedIndex = -1
    End Sub

    Private Sub showAnnealingLotData()
        Dim AnnealedCarbon, AnnealedSteelSize, HeatNumber, DateIn, DateOut, Comments, PreviousAnnealLotNumber, Base, Program, Grain, SpheroSampleBox As String
        Dim NumberOfCoils, SurfaceHardness, CoreHardness, FreeFerrite, TotalDecarb, SpheroidPercent, SpheroSampleMicro, RawMaterialTensile, MPA, PoundsAnnealed As Double

        cmd = New SqlCommand("SELECT AnnealedCarbon, AnnealedSteelSize, TotalPoundsAnnealed, HeatNumber, DateIn, DateOut, SurfaceHardness, CoreHardness, FreeFerrite, TotalDecarb, SpheroidPercent, Grain, Comments, PreviousAnnealLotNumber, SpheroSampleMicro, SpheroSampleBox, RawMaterialTensile, MPA, Base, Program, NumberOfCoils, MaterialStatus FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = Val(cboAnnealLotNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("AnnealedCarbon")) Then
                AnnealedCarbon = ""
            Else
                AnnealedCarbon = reader.Item("AnnealedCarbon")
            End If
            If IsDBNull(reader.Item("AnnealedSteelSize")) Then
                AnnealedSteelSize = ""
            Else
                AnnealedSteelSize = reader.Item("AnnealedSteelSize")
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
                DateIn = ""
            Else
                DateIn = reader.Item("DateIn")
            End If
            If IsDBNull(reader.Item("DateOut")) Then
                DateOut = ""
            Else
                DateOut = reader.Item("DateOut")
            End If
            If IsDBNull(reader.Item("SurfaceHardness")) Then
                SurfaceHardness = 0
            Else
                SurfaceHardness = reader.Item("SurfaceHardness")
            End If
            If IsDBNull(reader.Item("CoreHardness")) Then
                CoreHardness = 0
            Else
                CoreHardness = reader.Item("CoreHardness")
            End If
            If IsDBNull(reader.Item("FreeFerrite")) Then
                FreeFerrite = 0
            Else
                FreeFerrite = reader.Item("FreeFerrite")
            End If
            If IsDBNull(reader.Item("TotalDecarb")) Then
                TotalDecarb = 0
            Else
                TotalDecarb = reader.Item("TotalDecarb")
            End If
            If IsDBNull(reader.Item("SpheroidPercent")) Then
                SpheroidPercent = 0
            Else
                SpheroidPercent = reader.Item("SpheroidPercent")
            End If
            If IsDBNull(reader.Item("Grain")) Then
                Grain = ""
            Else
                Grain = reader.Item("Grain")
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
            If IsDBNull(reader.Item("SpheroSampleMicro")) Then
                SpheroSampleMicro = 0
            Else
                SpheroSampleMicro = reader.Item("SpheroSampleMicro")
            End If
            If IsDBNull(reader.Item("SpheroSampleBox")) Then
                SpheroSampleBox = ""
            Else
                SpheroSampleBox = reader.Item("SpheroSampleBox")
            End If
            'If IsDBNull(reader.GetValue(16)) Then
            '    DecarbSampleMicro = 0
            'Else
            '    DecarbSampleMicro = reader.GetValue(16)
            'End If
            'If IsDBNull(reader.GetValue(17)) Then
            '    DecarbSampleBox = ""
            'Else
            '    DecarbSampleBox = reader.GetValue(17)
            'End If
            If IsDBNull(reader.Item("RawMaterialTensile")) Then
                RawMaterialTensile = 0
            Else
                RawMaterialTensile = reader.Item("RawMaterialTensile")
            End If
            If IsDBNull(reader.Item("MPA")) Then
                MPA = 0
            Else
                MPA = reader.Item("MPA")
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
            If IsDBNull(reader.Item("MaterialStatus")) Then
                cboMaterialStatus.Text = ""
            Else
                cboMaterialStatus.Text = reader.Item("MaterialStatus")
            End If

        Else
            AnnealedCarbon = ""
            AnnealedSteelSize = ""
            PoundsAnnealed = 0
            HeatNumber = ""
            DateIn = ""
            DateOut = ""
            SurfaceHardness = 0
            CoreHardness = 0
            FreeFerrite = 0
            TotalDecarb = 0
            SpheroidPercent = 0
            Grain = ""
            Comments = ""
            PreviousAnnealLotNumber = ""
            SpheroSampleMicro = 0
            SpheroSampleBox = ""
            'DecarbSampleMicro = 0
            'DecarbSampleBox = ""
            RawMaterialTensile = 0
            MPA = 0
            Base = ""
            Program = ""
            NumberOfCoils = 0
            cboMaterialStatus.Text = ""
        End If
        reader.Close()
        con.Close()
        txtAnnealCarbon.Text = AnnealedCarbon
        txtAnnealSteelSize.Text = AnnealedSteelSize
        txtTotalWeight.Text = PoundsAnnealed
        txtHeatNumber.Text = HeatNumber
        txtDateIn.Text = DateIn
        txtDateOut.Text = DateOut
        txtComments.Text = Comments
        txtPreviousLot.Text = PreviousAnnealLotNumber
        txtProgram.Text = Program
        txtBase.Text = Base
        txtNumberOfCoils.Text = NumberOfCoils
        txtSurfaceHardness.Text = SurfaceHardness
        txtCoreHardness.Text = CoreHardness
        txtFreeFerrite.Text = FreeFerrite
        txtTotalDecarb.Text = TotalDecarb
        txtSpheroid.Text = SpheroidPercent
        'txtGrain.Text = Grain
        txtSampleMicro.Text = SpheroSampleMicro
        txtSampleBox.Text = SpheroSampleBox
        'txtDecarbSample.Text = DecarbSampleMicro
        'txtDecarbBox.Text = DecarbSampleBox
        txtTensile.Text = RawMaterialTensile
        'txtMPA.Text = MPA

        Dim status As String = checkStatus()
    End Sub

    Private Function checkStatus() As String
        Dim status As String = "FINISHED"
        cmd = New SqlCommand("SELECT Status FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("Status")) Then
                status = reader.Item("Status")
            End If
        End If
        reader.Close()
        con.Close()

        If status = "CLOSED" Then
            cmdSave.Enabled = False
            cmdPostAnnealingLot.Enabled = False
        Else
            cmdSave.Enabled = True
            cmdPostAnnealingLot.Enabled = True
        End If
        Return status
    End Function

    Private Sub showAnnealingLotCoils()
        cmd = New SqlCommand("SELECT CoilID, AnnealedWeight FROM AnnealingCoilLines WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "AnnealingCoilLines")
        con.Close()

        dgvAnnealLotLines.DataSource = ds1.Tables("AnnealingCoilLines")
        dgvAnnealLotLines.Columns("CoilID").HeaderText = "Coil ID"
        dgvAnnealLotLines.Columns("AnnealedWeight").HeaderText = "Weight"

    End Sub

    Private Sub ClearData()
        isLoaded = False
        cboAnnealLotNumber.Refresh()

        txtBase.Refresh()
        txtComments.Refresh()
        txtCoreHardness.Refresh()
        'txtDecarbBox.Refresh()
        'txtDecarbSample.Refresh()
        txtFreeFerrite.Refresh()
        txtHeatNumber.Refresh()
        txtNumberOfCoils.Refresh()
        txtPreviousLot.Refresh()
        txtProgram.Refresh()
        txtSampleBox.Refresh()
        txtSpheroid.Refresh()
        txtSampleMicro.Refresh()
        txtSurfaceHardness.Refresh()
        txtTensile.Refresh()
        txtTotalDecarb.Refresh()
        txtTotalWeight.Refresh()

        cboAnnealLotNumber.SelectedIndex = -1

        txtAnnealCarbon.Clear()
        txtAnnealSteelSize.Clear()
        txtBase.Clear()
        txtComments.Clear()
        txtCoreHardness.Clear()
        'txtDecarbBox.Clear()
        'txtDecarbSample.Clear()
        txtFreeFerrite.Clear()
        txtHeatNumber.Clear()
        txtNumberOfCoils.Clear()
        txtPreviousLot.Clear()
        txtProgram.Clear()
        txtSampleBox.Clear()
        txtSpheroid.Clear()
        txtSampleMicro.Clear()
        txtSurfaceHardness.Clear()
        txtTensile.Clear()
        txtTotalDecarb.Clear()
        txtTotalWeight.Clear()

        txtDateIn.Clear()
        txtDateOut.Clear()

        If cmdSave.Enabled = False Then
            cmdSave.Enabled = True
            cmdPostAnnealingLot.Enabled = True
        End If
        needsSaved = False
        isLoaded = True
        showAnnealingLotCoils()
        cboAnnealLotNumber.Focus()
        cboMaterialStatus.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboMaterialStatus.Text) Then
            cboMaterialStatus.Text = ""
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveDataToolStripMenuItem.Click
        If canSave() Then
            If updateAnnealingLot() Then
                MessageBox.Show("Annealing Lot has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                needsSaved = False
            Else
                MessageBox.Show("There was a problem saving. Check data and try again.", "Unable to Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            MessageBox.Show("You must select an Annealing Lot", "Select an Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If cboAnnealLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Annealing Lot", "Enter a valid Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.SelectAll()
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(txtSurfaceHardness.Text) Then
            If Not IsNumeric(txtSurfaceHardness.Text) Then
                MessageBox.Show("You must enter a number for Surface Hardness", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSurfaceHardness.SelectAll()
                txtSurfaceHardness.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtCoreHardness.Text) Then
            If Not IsNumeric(txtCoreHardness.Text) Then
                MessageBox.Show("You must enter a number for Core Hardness", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCoreHardness.SelectAll()
                txtCoreHardness.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtFreeFerrite.Text) Then
            If Not IsNumeric(txtFreeFerrite.Text) Then
                MessageBox.Show("You must enter a number for Free Ferrite", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFreeFerrite.SelectAll()
                txtFreeFerrite.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtTotalDecarb.Text) Then
            If Not IsNumeric(txtTotalDecarb.Text) Then
                MessageBox.Show("You must enter a number for Total Decarb", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalDecarb.SelectAll()
                txtTotalDecarb.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtSpheroid.Text) Then
            If Not IsNumeric(txtSpheroid.Text) Then
                MessageBox.Show("You must enter a number for Spheroid", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSpheroid.SelectAll()
                txtSpheroid.Focus()
                Return False
            End If
        End If
        'If String.IsNullOrEmpty(txtGrain.Text) = False Then
        '    If IsNumeric(txtGrain.Text) = False Then
        '        MessageBox.Show("You must enter a number for Grain", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        txtGrain.SelectAll()
        '        txtGrain.Focus()
        '        Return False
        '    End If
        'End If
        If Not String.IsNullOrEmpty(txtSampleMicro.Text) Then
            If Not IsNumeric(txtSampleMicro.Text) Then
                MessageBox.Show("You must enter a number for Sphero Sample", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSampleMicro.SelectAll()
                txtSampleMicro.Focus()
                Return False
            End If
        End If
        'If String.IsNullOrEmpty(txtDecarbSample.Text) = False Then
        '    If IsNumeric(txtDecarbSample.Text) = False Then
        '        MessageBox.Show("You must enter a number for Decarb Sample", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        txtDecarbSample.SelectAll()
        '        txtDecarbSample.Focus()
        '        Return False
        '    End If
        'End If
        If Not String.IsNullOrEmpty(txtTensile.Text) Then
            If Not IsNumeric(txtTensile.Text) Then
                MessageBox.Show("You must enter a number for Tensile", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTensile.SelectAll()
                txtTensile.Focus()
                Return False
            End If
        End If
        If cboMaterialStatus.SelectedIndex = -1 Then
            MessageBox.Show("You must select a status for the material.", "Select a status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMaterialStatus.Focus()
            Return False
        End If
        'If String.IsNullOrEmpty(txtMPA.Text) = False Then
        '    If IsNumeric(txtTensile.Text) = False Then
        '        MessageBox.Show("You must enter a number for MPA", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        txtMPA.SelectAll()
        '        txtMPA.Focus()
        '        Return False
        '    End If
        'End If
        Return True
    End Function

    Private Sub cboAnnealLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAnnealLotNumber.SelectedIndexChanged
        If isLoaded Then
            showAnnealingLotData()
            showAnnealingLotCoils()
        End If
    End Sub

    Private Sub AnnealLotTestResultsEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If EmployeeSecurityCode > 1002 And EmployeeSecurityCode <> 1007 And EmployeeSecurityCode <> 1008 Then
        '    UnLockAnnealLotToolStripMenuItem.Visible = False
        'End If
        usefulFunctions.LoadSecurity(Me)

        LoadAnnealingLotNumbers()

        isLoaded = True
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Function updateAnnealingLot() As Boolean
        Try
            'Create command to save data from text boxes
            cmd = New SqlCommand("UPDATE AnnealingLog SET SurfaceHardness = @SurfaceHardness, CoreHardness = @CoreHardness, FreeFerrite = @FreeFerrite, TotalDecarb = @TotalDecarb, SpheroidPercent = @SpheroidPercent, Grain = @Grain, Comments = @Comments, SpheroSampleMicro = @SpheroSampleMicro, SpheroSampleBox = @SpheroSampleBox, DecarbSampleMicro = @DecarbSampleMicro, DecarbSampleBox = @DecarbSampleBox, RawMaterialTensile = @RawMaterialTensile, MPA = @MPA, Checked = 'true', MaterialStatus = @MaterialStatus WHERE AnnealLotNumber = @AnnealLotNumber;", con)

            With cmd.Parameters
                .Add("@AnnealLotNumber", SqlDbType.VarChar).Value = Val(cboAnnealLotNumber.Text)
                .Add("@SurfaceHardness", SqlDbType.VarChar).Value = Val(txtSurfaceHardness.Text)
                .Add("@CoreHardness", SqlDbType.VarChar).Value = Val(txtCoreHardness.Text)
                .Add("@FreeFerrite", SqlDbType.VarChar).Value = Val(txtFreeFerrite.Text)
                .Add("@TotalDecarb", SqlDbType.VarChar).Value = Val(txtTotalDecarb.Text)
                .Add("@SpheroidPercent", SqlDbType.VarChar).Value = Val(txtSpheroid.Text)
                .Add("@Grain", SqlDbType.VarChar).Value = "" 'txtGrain.Text
                .Add("@Comments", SqlDbType.VarChar).Value = txtComments.Text
                .Add("@SpheroSampleMicro", SqlDbType.VarChar).Value = txtSampleMicro.Text
                .Add("@SpheroSampleBox", SqlDbType.VarChar).Value = txtSampleBox.Text
                .Add("@DecarbSampleMicro", SqlDbType.VarChar).Value = "" 'txtDecarbSample.Text
                .Add("@DecarbSampleBox", SqlDbType.VarChar).Value = "" 'txtDecarbBox.Text
                .Add("@RawMaterialTensile", SqlDbType.VarChar).Value = Val(txtTensile.Text)
                .Add("@MPA", SqlDbType.VarChar).Value = "" 'Val(txtMPA.Text)
                .Add("@MaterialStatus", SqlDbType.VarChar).Value = cboMaterialStatus.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As System.Exception
            sendErrorToDataBase("AnnealingLotTestResultsEntry - updateAnnealingLot --Error trying to update the line in the AnnealingLog Table", "Annealing Lot #" + cboAnnealLotNumber.Text, ex.ToString())
            Return False
        End Try
    End Function

    ''sends the error message to the database given it the description of the failure, reference ID and comment
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

    Private Sub cmdPostAnnealingLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostAnnealingLot.Click
        If canPost() Then
            If updateAnnealingLot() Then
                needsSaved = False
                cmd = New SqlCommand("UPDATE AnnealingLog SET Status = 'CLOSED' WHERE AnnealLotNumber = @AnnealLotNumber;", con)
                cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLotNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As System.Exception
                    con.Close()
                    sendErrorToDataBase("AnnealLotTestResultsEntry - cmdPostAnnealingLot -- Error changing status to CLOSED.", "Annealing Lot #" + cboAnnealLotNumber.Text, ex.ToString())
                    MessageBox.Show("There was a problem closing the Annealing Lot to further changes. Contact system admin", "Unable to close", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
                con.Close()

                cmdSave.Enabled = False
                cmdPostAnnealingLot.Enabled = False

                MessageBox.Show("Annealing Lot has been Posted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("There was a problem with Posting the Annealing Lot. Check data and try again, if issue persists contact system admin.", "Unable to complete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
    End Sub

    Private Function canPost() As Boolean
        If String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            MessageBox.Show("You must select an Annealing Lot", "Select an Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.Focus()
            Return False
        End If
        If cboAnnealLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Annealing Lot", "Enter a valid Annealing Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAnnealLotNumber.SelectAll()
            cboAnnealLotNumber.Focus()
            Return False
        End If

        Dim stat As String = checkStatus()

        If stat = "OPEN" Then
            MessageBox.Show("Annealing Lot Maintenance Entry was not Posted", "Unable to Post", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf stat = "CLOSED" Then
            MessageBox.Show("Annealing Lot has already been Closed", "Unable to complete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(txtSurfaceHardness.Text) Then
            If IsNumeric(txtSurfaceHardness.Text) = False Then
                MessageBox.Show("You must enter a number for Surface Hardness", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSurfaceHardness.SelectAll()
                txtSurfaceHardness.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtCoreHardness.Text) Then
            If IsNumeric(txtCoreHardness.Text) = False Then
                MessageBox.Show("You must enter a number for Core Hardness", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCoreHardness.SelectAll()
                txtCoreHardness.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtFreeFerrite.Text) Then
            If IsNumeric(txtFreeFerrite.Text) = False Then
                MessageBox.Show("You must enter a number for Free Ferrite", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFreeFerrite.SelectAll()
                txtFreeFerrite.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtTotalDecarb.Text) Then
            If IsNumeric(txtTotalDecarb.Text) = False Then
                MessageBox.Show("You must enter a value for Total Decarb", "Enter a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalDecarb.SelectAll()
                txtTotalDecarb.Focus()
                Return False
            End If
        End If
        If IsNumeric(txtTotalDecarb.Text) = False Then
            MessageBox.Show("You must enter a number for Total Decarb", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTotalDecarb.SelectAll()
            txtTotalDecarb.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtSpheroid.Text) Then
            If IsNumeric(txtSpheroid.Text) = False Then
                MessageBox.Show("You must enter a number for Spheroid", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSpheroid.SelectAll()
                txtSpheroid.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtSampleMicro.Text) Then
            If IsNumeric(txtSampleMicro.Text) = False Then
                MessageBox.Show("You must enter a number for Sphero Sample", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSampleMicro.SelectAll()
                txtSampleMicro.Focus()
                Return False
            End If
        End If
        'If String.IsNullOrEmpty(txtDecarbSample.Text) = False Then
        '    If IsNumeric(txtDecarbSample.Text) = False Then
        '        MessageBox.Show("You must enter a number for Decarb Sample", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        txtDecarbSample.SelectAll()
        '        txtDecarbSample.Focus()
        '        Return False
        '    End If
        'End If
        If String.IsNullOrEmpty(txtTensile.Text) = False Then
            If IsNumeric(txtTensile.Text) = False Then
                MessageBox.Show("You must enter a number for Tensile", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTensile.SelectAll()
                txtTensile.Focus()
                Return False
            End If
        End If
        'If String.IsNullOrEmpty(txtMPA.Text) = False Then
        '    If IsNumeric(txtMPA.Text) = False Then
        '        MessageBox.Show("You must enter a number for MPA", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        txtMPA.SelectAll()
        '        txtMPA.Focus()
        '        Return False
        '    End If
        'End If
        Return True
    End Function

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click, ClearDataToolStripMenuItem.Click
        ClearData()
    End Sub

    Private Sub txtComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged
        If txtComments.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtSurfaceHardness_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSurfaceHardness.TextChanged
        If txtSurfaceHardness.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtCoreHardness_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoreHardness.TextChanged
        If txtCoreHardness.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtFreeFerrite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreeFerrite.TextChanged
        If txtFreeFerrite.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtTotalDecarb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalDecarb.TextChanged
        If txtTotalDecarb.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtSpheroid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSpheroid.TextChanged
        If txtSpheroid.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtSpheroSample_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSampleMicro.TextChanged
        If txtSampleMicro.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtSpheroBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSampleBox.TextChanged
        If txtSampleMicro.Focused Then
            needsSaved = True
        End If
    End Sub

    'Private Sub txtDecarbSample_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtDecarbSample.Focused Then
    '        needsSaved = True
    '    End If
    'End Sub

    'Private Sub txtDecarbBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtDecarbBox.Focused Then
    '        needsSaved = True
    '    End If
    'End Sub

    Private Sub txtTensile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTensile.TextChanged
        If txtTensile.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintDataToolStripMenuItem.Click
        cmd = New SqlCommand("SELECT * FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)
        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "AnnealingLog")
        con.Close()
        Using NewPrintAnnealingLogFiltered As New PrintAnnealingLogFiltered(tempds)
            Dim Result = NewPrintAnnealingLogFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub UnLockAnnealLotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockAnnealLotToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboAnnealLotNumber.Text) Then
            cmd = New SqlCommand("UPDATE AnnealingLog SET Status = 'FINISHED' WHERE AnnealLotNumber = @AnnealLotNumber;", con)
            cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(cboAnnealLotNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            checkStatus()
        End If
    End Sub

    Private Sub txtSurfaceHardness_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSurfaceHardness.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
            e.Handled = True
        ElseIf e.KeyChar = "."c And txtSurfaceHardness.Text.Contains(".") Then
            e.KeyChar = Nothing
            e.Handled = True
        End If
    End Sub

    Private Sub txtCoreHardness_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoreHardness.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
            e.Handled = True
        ElseIf e.KeyChar = "."c And txtCoreHardness.Text.Contains(".") Then
            e.KeyChar = Nothing
            e.Handled = True
        End If
    End Sub

    Private Sub txtFreeFerrite_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFreeFerrite.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
            e.Handled = True
        ElseIf e.KeyChar = "."c And txtFreeFerrite.Text.Contains(".") Then
            e.KeyChar = Nothing
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalDecarb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalDecarb.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
            e.Handled = True
        ElseIf e.KeyChar = "."c And txtTotalDecarb.Text.Contains(".") Then
            e.KeyChar = Nothing
            e.Handled = True
        End If
    End Sub

    Private Sub txtSpheroid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSpheroid.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
            e.Handled = True
        ElseIf e.KeyChar = "."c And txtSpheroid.Text.Contains(".") Then
            e.KeyChar = Nothing
            e.Handled = True
        End If
    End Sub

    Private Sub txtSampleMicro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSampleMicro.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
            e.Handled = True
        ElseIf e.KeyChar = "."c And txtSampleMicro.Text.Contains(".") Then
            e.KeyChar = Nothing
            e.Handled = True
        End If
    End Sub

    Private Sub txtSampleBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSampleBox.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
            e.Handled = True
        ElseIf e.KeyChar = "."c And txtSampleBox.Text.Contains(".") Then
            e.KeyChar = Nothing
            e.Handled = True
        End If
    End Sub

    Private Sub txtTensile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTensile.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
            e.Handled = True
        ElseIf e.KeyChar = "."c And txtTensile.Text.Contains(".") Then
            e.KeyChar = Nothing
            e.Handled = True
        End If
    End Sub
End Class
