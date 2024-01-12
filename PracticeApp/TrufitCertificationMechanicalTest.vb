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
Public Class TrufitCertificationMechanicalTest
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim isLoaded As Boolean = False
    Dim controlKey As Boolean = False

    Public Sub New()
        InitializeComponent()
        LoadTestNumber()
        LoadLotNumbers()

        If GlobalMechanicalTestNumber = "" Then
            'Do nothing
        Else
            cboTestNumber.Text = GlobalMechanicalTestNumber
            cboLotNumber.SelectedIndex = -1
            lblPartDescription.Text = ""
            ShowResults()
            LoadTestData()
            checkLotLock()
        End If

        isLoaded = True
    End Sub

    Private Sub LoadTestNumber()
        cmd = New SqlCommand("SELECT TestNumber FROM TrufitCertificationMechanicalTestHeader ORDER BY TestNumber DESC;", con)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "TrufitCertificationMechanicalTest")
        con.Close()

        cboTestNumber.DisplayMember = "TestNumber"
        cboTestNumber.DataSource = ds.Tables("TrufitCertificationMechanicalTest")
        cboTestNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadLotNumbers()
        Dim curr As String = cboLotNumber.Text
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE ItemClass ='Trufit Parts';", con)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "TrufitCertificationHeatLines")
        con.Close()

        cboLotNumber.DisplayMember = "LotNumber"
        cboLotNumber.DataSource = ds2.Tables("TrufitCertificationHeatLines")
        If ds2.Tables("TrufitCertificationHeatLines").Rows.Count = 1 Then
            cboLotNumber.SelectedIndex = 0
        Else
            If String.IsNullOrEmpty(curr) Then
                cboLotNumber.SelectedIndex = -1
            Else
                cboLotNumber.Text = curr
            End If
        End If
    End Sub

    Private Sub ShowResults()
        isLoaded = False
        cmd = New SqlCommand("SELECT ResultNumber, Area, ProofPound, LoadPSI, LoadMPA, UltimatePound, TensilePSI, TensileMPA, Results, TestNumber FROM TrufitCertificationMechanicalTestLine WHERE TestNumber = @TestNumber ORDER BY ResultNumber ASC;", con)
        cmd.Parameters.Add("@TesTNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "TrufitCertificationMechanicalTestLine")
        con.Close()

        dgvResultData.DataSource = ds3.Tables("TrufitCertificationMechanicalTestLine")
        dgvResultData.Columns("ResultNumber").HeaderText = "Sample Number"
        dgvResultData.Columns("ResultNumber").ReadOnly = True
        dgvResultData.Columns("ProofPound").HeaderText = "Proof Pound"
        dgvResultData.Columns("LoadPSI").HeaderText = "Load PSI"
        dgvResultData.Columns("LoadPSI").ReadOnly = True
        dgvResultData.Columns("LoadMPA").HeaderText = "Load Mpa"
        dgvResultData.Columns("LoadMPA").ReadOnly = True
        dgvResultData.Columns("UltimatePound").HeaderText = "UltimatePound"
        dgvResultData.Columns("TensilePSI").HeaderText = "Tensile PSI"
        dgvResultData.Columns("TensilePSI").ReadOnly = True
        dgvResultData.Columns("TensileMPA").HeaderText = "Tensile Mpa"
        dgvResultData.Columns("TensileMPA").ReadOnly = True
        dgvResultData.Columns("TestNumber").Visible = False

        cboDeleteResultNumber.DisplayMember = "ResultNumber"
        cboDeleteResultNumber.DataSource = ds3.Tables("TrufitCertificationMechanicalTestLine")
        isLoaded = True
    End Sub

    Private Sub cmdGenerateTestNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateTestNumber.Click
        isLoaded = False
        clearAll()
        isLoaded = True
        Dim Key As String = "TF" + Now.Year.ToString.Substring(2)
        cmd = New SqlCommand("SELECT MAX(CAST(RIGHT(TestNumber, 3) as int)) as MaxNumber FROM TrufitCertificationMechanicalTestHeader WHERE TestNumber Like @TesTNumber", con)
        cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = Key + "%"

        If con.State = ConnectionState.Closed Then con.Open()

        Dim obj As Object = cmd.ExecuteScalar()
        If Not IsDBNull(obj) Then
            If obj IsNot Nothing Then
                Dim tmpint As Integer = obj
                tmpint += 1
                If tmpint < 10 Then
                    Key += "-00" + tmpint.ToString()
                ElseIf tmpint < 100 Then
                    Key += "-0" + tmpint.ToString()
                Else
                    Key += "-" + tmpint.ToString()
                End If
            Else
                Key += "-001"
            End If
        Else
            Key += "-001"
        End If

        cmd = New SqlCommand("INSERT INTO TrufitCertificationMechanicalTestHeader (TestNumber, CreationDate, Status) VALUES (@TestNumber, @CreationDate, 'OPEN');", con)
        With cmd.Parameters
            .Add("@TestNumber", SqlDbType.VarChar).Value = Key
            .Add("@CreationDate", SqlDbType.DateTime2).Value = dtpCreatedDate.Value
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        LoadTestNumber()
        cboTestNumber.Text = Key
    End Sub

    Private Sub cboTestNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTestNumber.SelectedIndexChanged
        If isLoaded Then
            cboLotNumber.SelectedIndex = -1
            lblPartDescription.Text = ""
            ShowResults()
            LoadTestData()
            checkLotLock()
        End If
    End Sub

    Private Sub LoadTestData()
        isLoaded = False
        Dim status As String = "OPEN"
        cmd = New SqlCommand("SELECT LotNumber, CreationDate, HeatNumber, PartNumber, Description, TestedBy, ApprovedBy, Status FROM TrufitCertificationMechanicalTestHeader WHERE TestNumber = @TestNumber;", con)
        cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LotNumber")) Then
                cboLotNumber.Text = ""
            Else
                cboLotNumber.Text = reader.Item("LotNumber")
            End If
            If IsDBNull(reader.Item("CreationDate")) Then
                dtpCreatedDate.Value = Now
            Else
                dtpCreatedDate.Value = reader.Item("CreationDate")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                lblHeatNumber.Text = ""
            Else
                lblHeatNumber.Text = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                lblPartNumber.Text = ""
            Else
                lblPartNumber.Text = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("Description")) Then
                lblPartDescription.Text = ""
            Else
                lblPartDescription.Text = reader.Item("Description")
            End If
            If IsDBNull(reader.Item("TestedBy")) Then
                txtTestedBy.Text = ""
            Else
                txtTestedBy.Text = reader.Item("TestedBy")
            End If
            If IsDBNull(reader.Item("ApprovedBy")) Then
                txtApprovedBy.Text = ""
            Else
                txtApprovedBy.Text = reader.Item("ApprovedBy")
            End If
            If IsDBNull(reader.Item("Status")) Then
                status = "OPEN"
            Else
                status = reader.Item("Status")
            End If
        Else
            cboLotNumber.Text = ""
            lblHeatNumber.Text = ""
            lblPartNumber.Text = ""
            lblPartDescription.Text = ""
            txtTestedBy.Text = ""
            txtApprovedBy.Text = ""
        End If
        reader.Close()
        con.Close()
        isLoaded = True
        checkStatus()
    End Sub

    Private Sub clearAdd()
        txtArea.Clear()
        txtProofPound.Clear()
        txtLoadPSI.Text = ""
        txtUltimatePound.Clear()
        txtTensilePSI.Text = ""
        txtResults.Clear()
    End Sub

    Private Sub cmdAddResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddResult.Click
        If canAddResult() Then
            'Check to see if the part is one the list to check tolerances
            Dim CountPartNumber As Integer = 0
            Dim UltMinPSI As Integer = 0
            Dim UltMaxPSI As Integer = 0
            Dim CheckTensile As String = ""

            Dim CountPartNumberStatement As String = "SELECT COUNT(PartNumber) FROM TrufitCertificationMechanicalTestTolerances WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim CountPartNumberCommand As New SqlCommand(CountPartNumberStatement, con)
            CountPartNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
            CountPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPartNumber = CInt(CountPartNumberCommand.ExecuteScalar)
            Catch ex As Exception
                CountPartNumber = 0
            End Try
            con.Close()

            If CountPartNumber = 0 Then
                'Skip
                CheckTensile = "NO"
            Else
                'Get Min and Max Tensile for the part number
                Dim MinTensileStatement As String = "SELECT UltimateMinPSI FROM TrufitCertificationMechanicalTestTolerances WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim MinTensileCommand As New SqlCommand(MinTensileStatement, con)
                MinTensileCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
                MinTensileCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

                Dim MaxTensileStatement As String = "SELECT UltimateMaxPSI FROM TrufitCertificationMechanicalTestTolerances WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim MaxTensileCommand As New SqlCommand(MaxTensileStatement, con)
                MaxTensileCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
                MaxTensileCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    UltMinPSI = CInt(MinTensileCommand.ExecuteScalar)
                Catch ex As Exception
                    UltMinPSI = 0
                End Try
                Try
                    UltMaxPSI = CInt(MaxTensileCommand.ExecuteScalar)
                Catch ex As Exception
                    UltMaxPSI = 0
                End Try
                con.Close()

                CheckTensile = "YES"
            End If

            'Update Header Table
            updateTrufitCertificationMechanicalTest()

            'Check against Min Tensile
            If CheckTensile = "YES" Then
                Dim CurrentTensile As Double = 0

                CurrentTensile = Val(txtTensilePSI.Text)

                If CurrentTensile >= UltMinPSI Then
                    'It passes the min
                Else
                    MsgBox("Test result does not pass Min Tensile Test for this part #.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Check against Max Tensile
                If UltMaxPSI = 0 Then
                    'No Max Tensile Test
                Else
                    If CurrentTensile <= UltMaxPSI Then
                        'It passes the MAX
                    Else
                        MsgBox("Test result does not pass Max Tensile Test for this part #.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                End If
            Else
                'Skip - no tensile test
            End If

            'Update/add to line table
            cmd = New SqlCommand("INSERT INTO TrufitCertificationMechanicalTestLine (TestNumber, ResultNumber, Area, ProofPound, LoadPSI, UltimatePound, TensilePSI, Results, LoadMPA, TensileMPA) VALUES (@TestNumber, (SELECT isnull(MAX(ResultNumber) + 1, 1) FROM TrufitCertificationMechanicalTestLine WHERE TestNumber = @TestNumber), @Area, @ProofPound, @LoadPSI, @UltimatePound, @TensilePSI, @Results, @LoadMPA, @TensileMPA);", con)

            With cmd.Parameters
                .Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
                .Add("@Area", SqlDbType.VarChar).Value = txtArea.Text
                .Add("@ProofPound", SqlDbType.VarChar).Value = txtProofPound.Text
                .Add("@LoadPSI", SqlDbType.VarChar).Value = txtLoadPSI.Text
                .Add("@LoadMPA", SqlDbType.VarChar).Value = txtLoadMPA.Text
                .Add("@UltimatePound", SqlDbType.VarChar).Value = txtUltimatePound.Text
                .Add("@TensilePSI", SqlDbType.VarChar).Value = txtTensilePSI.Text
                .Add("@TensileMPA", SqlDbType.VarChar).Value = txtTensileMPA.Text
                .Add("@Results", SqlDbType.VarChar).Value = txtResults.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowResults()
            clearAdd()
            checkLotLock()
            txtArea.Focus()
        End If
    End Sub

    Private Function canAddResult() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must select a Test Number", "Select a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test Number", "Enter a valid Test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must select a Lot Number", "Select a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Lot Number", "Enter a valid Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        If isLoaded Then
            cmd = New SqlCommand("SELECT HeatNumber, PartNumber, ShortDescription FROM LotNumber WHERE LotNumber = @LotNumber;", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("HeatNumber")) Then
                    lblHeatNumber.Text = ""
                Else
                    lblHeatNumber.Text = reader.Item("HeatNumber")
                End If
                If IsDBNull(reader.Item("PartNumber")) Then
                    lblPartNumber.Text = ""
                Else
                    lblPartNumber.Text = reader.Item("PartNumber")
                End If
                If IsDBNull(reader.Item("ShortDescription")) Then
                    lblPartDescription.Text = ""
                Else
                    lblPartDescription.Text = reader.Item("ShortDescription")
                End If
            Else
                lblHeatNumber.Text = ""
                lblPartNumber.Text = ""
                lblPartDescription.Text = ""
            End If
            reader.Close()
            con.Close()
        End If
    End Sub

    Private Sub checkLotLock()
        If dgvResultData.Rows.Count > 0 Then
            cboLotNumber.Enabled = False
        Else
            cboLotNumber.Enabled = True
        End If
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveDataToolStripMenuItem.Click
        If canSave() Then
            updateTrufitCertificationMechanicalTest()
            ShowResults()
            MessageBox.Show("Test data has been saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must select a Test Number", "Select a Test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test Number", "Enter a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If checkStatus().Equals("CLOSED") Then
            Return False
        End If
        Return True
    End Function

    Private Sub updateTrufitCertificationMechanicalTest()
        cmd = New SqlCommand("UPDATE TrufitCertificationMechanicalTestHeader SET LotNumber = @LotNumber, HeatNumber = @HeatNumber, PartNumber = @PartNumber, Description = @Description, TestedBy = @TestedBy, ApprovedBy = @ApprovedBy WHERE TestNumber = @TestNumber;", con)

        With cmd.Parameters
            .Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
            .Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
            .Add("@HeatNumber", SqlDbType.VarChar).Value = lblHeatNumber.Text
            .Add("@TestedBy", SqlDbType.VarChar).Value = txtTestedBy.Text
            .Add("@ApprovedBy", SqlDbType.VarChar).Value = txtApprovedBy.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
            .Add("@Description", SqlDbType.VarChar).Value = lblPartDescription.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub clearPart()
        isLoaded = False
        cboTestNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        lblHeatNumber.Text = ""
        lblPartNumber.Text = ""
        lblPartDescription.Text = ""
        dtpCreatedDate.Text = Today.Date.ToShortDateString()
        ds3 = New DataSet()
        dgvResultData.DataSource = ds3.Tables("")
        checkLotLock()
        isLoaded = True
    End Sub

    Private Sub clearAll()
        clearAdd()
        isLoaded = False
        cboTestNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        lblHeatNumber.Text = ""
        lblPartNumber.Text = ""
        lblPartDescription.Text = ""
        txtTestedBy.Clear()
        txtApprovedBy.Clear()
        dtpCreatedDate.Value = Now
        ds3 = New DataSet()
        dgvResultData.DataSource = Nothing
        cboDeleteResultNumber.DataSource = Nothing
        checkLotLock()
        isLoaded = True
    End Sub

    Private Sub ClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click, ClearDataToolStripMenuItem.Click
        clearAll()
        checkStatus("OPEN")
        cboTestNumber.Focus()
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteDataToolStripMenuItem.Click
        If canDelete() Then
            cmd = New SqlCommand("DELETE TrufitCertificationMechanicalTestHeader WHERE TestNumber = @TestNumber;", con)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            clearAll()
            LoadTestNumber()
        End If
    End Sub

    Private Function canDelete() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must select a Test to Delete", "Select a Test", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test Number", "Enter a valid Test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to delete Mechanical Test?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        If canExit() Then
            If canSave() Then
                updateTrufitCertificationMechanicalTest()
            Else
                Exit Sub
            End If
        End If
        Me.Dispose()
        Me.Close()
    End Sub

    Private Function canExit() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            Return False
        End If
        If Not checkStatus().Equals("OPEN") Then
            Return False
        End If
        If MessageBox.Show("Do you wish to save the data?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRow.Click
        If canDeleteRow() Then
            cmd = New SqlCommand("DELETE TrufitCertificationMechanicalTestLine WHERE ResultNumber = @ResultNumber AND TestNumber = @TestNumber;" _
                                 + " UPDATE TrufitCertificationMechanicalTestLine SET ResultNumber = ResultNumber - 1 WHERE TestNumber = @TestNumber and ResultNumber > @ResultNumber", con)
            cmd.Parameters.Add("@ResultNumber", SqlDbType.VarChar).Value = Val(cboDeleteResultNumber.Text)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowResults()
            checkLotLock()
        End If
    End Sub

    Private Function canDeleteRow() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must enter a Test Number", "Enter a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test number", "Enter a valid Test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If dgvResultData.Rows.Count = 0 Then
            MessageBox.Show("There are no Result Entries to delete", "No entries", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboDeleteResultNumber.Text) Then
            MessageBox.Show("You must select a Result Number", "Select a Result Nubmer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteResultNumber.Focus()
            Return False
        End If
        If cboDeleteResultNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid result number", "Enter a valid Result Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteResultNumber.SelectAll()
            cboDeleteResultNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        clearAdd()
        txtArea.Focus()
    End Sub

    Private Sub dgvResultData_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultData.CellValueChanged
        If canUpdateValue() Then
            Dim dgvValue As String = ""
            Dim currentRow As Integer = dgvResultData.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvResultData.CurrentCell.ColumnIndex

            If Not IsDBNull(dgvResultData.CurrentCell.Value) Then
                dgvValue = dgvResultData.CurrentCell.Value
            End If

            Select Case dgvResultData.Columns(currentColumn).DataPropertyName
                Case "LoadPSI"
                    cmd = New SqlCommand("UPDATE TrufitCertificationMechanicalTestLine SET " + dgvResultData.Columns(currentColumn).DataPropertyName + " = @newValue, LoadMPA = @newValue2 WHERE ResultNumber = @ResultNumber AND TestNumber = @TestNumber;", con)
                    cmd.Parameters.Add("@newValue2", SqlDbType.VarChar).Value = Math.Round(PSIToMPA(dgvValue), 0, MidpointRounding.AwayFromZero)
                Case "LoadMPA"
                    cmd = New SqlCommand("UPDATE TrufitCertificationMechanicalTestLine SET " + dgvResultData.Columns(currentColumn).DataPropertyName + " = @newValue, LoadPSI = @newValue2 WHERE ResultNumber = @ResultNumber AND TestNumber = @TestNumber;", con)
                    cmd.Parameters.Add("@newValue2", SqlDbType.VarChar).Value = MPAToPSI(dgvValue)
                Case "TensilePSI"
                    cmd = New SqlCommand("UPDATE TrufitCertificationMechanicalTestLine SET " + dgvResultData.Columns(currentColumn).DataPropertyName + " = @newValue, TensileMPA = @newValue2 WHERE ResultNumber = @ResultNumber AND TestNumber = @TestNumber;", con)
                    cmd.Parameters.Add("@newValue2", SqlDbType.VarChar).Value = Math.Round(PSIToMPA(dgvValue), 0, MidpointRounding.AwayFromZero)
                Case "TensileMPA"
                    cmd = New SqlCommand("UPDATE TrufitCertificationMechanicalTestLine SET " + dgvResultData.Columns(currentColumn).DataPropertyName + " = @newValue, TensilePSI = @newValue2 WHERE ResultNumber = @ResultNumber AND TestNumber = @TestNumber;", con)
                    cmd.Parameters.Add("@newValue2", SqlDbType.VarChar).Value = MPAToPSI(dgvValue)
                Case Else
                    cmd = New SqlCommand("UPDATE TrufitCertificationMechanicalTestLine SET " + dgvResultData.Columns(currentColumn).DataPropertyName + " = @newValue WHERE ResultNumber = @ResultNumber AND TestNumber = @TestNumber;", con)
            End Select
            If dgvValue.Length > 50 Then
                dgvValue = dgvValue.Substring(0, 50)
            End If
            cmd.Parameters.Add("@newValue", SqlDbType.VarChar).Value = dgvValue
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
            cmd.Parameters.Add("@ResultNumber", SqlDbType.VarChar).Value = dgvResultData.Rows(currentRow).Cells("ResultNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowResults()
            If Not dgvResultData.Rows(currentRow).Cells(currentColumn) Is Nothing Then
                dgvResultData.CurrentCell = dgvResultData.Rows(currentRow).Cells(currentColumn)
            End If
        End If
    End Sub

    Private Function canUpdateValue() As Boolean
        If Not isLoaded Then
            Return False
        End If
        Return True
    End Function

    ''calculation from PSI to Mpa
    Private Function PSIToMPA(ByVal inVal As Double) As Double
        Return (inVal / 145.0377)
    End Function

    ''Calculation from Mpa to PSI
    Private Function MPAToPSI(ByVal inVal As Double) As Double
        Return (inVal * 145.0377)
    End Function

    Private Sub Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintDataToolStripMenuItem.Click
        If canPrint() Then
            If checkStatus().Equals("OPEN") Then
                updateTrufitCertificationMechanicalTest()
            End If
            If Not ds3.Tables.Contains("TrufitCertificationMechanicalTestHeader") Then
                ds3.Tables.Add("TrufitCertificationMechanicalTestHeader")
                ds3.Tables("TrufitCertificationMechanicalTestHeader").Columns.Add("TestNumber")
                ds3.Tables("TrufitCertificationMechanicalTestHeader").Columns.Add("LotNumber")
                ds3.Tables("TrufitCertificationMechanicalTestHeader").Columns.Add("HeatNumber")
                ds3.Tables("TrufitCertificationMechanicalTestHeader").Columns.Add("PartNumber")
                ds3.Tables("TrufitCertificationMechanicalTestHeader").Columns.Add("Description")
                ds3.Tables("TrufitCertificationMechanicalTestHeader").Columns.Add("TestedBy")
                ds3.Tables("TrufitCertificationMechanicalTestHeader").Columns.Add("ApprovedBy")
            Else
                ds3.Tables("TrufitCertificationMechanicalTestHeader").Rows.Clear()
            End If

            ds3.Tables("TrufitCertificationMechanicalTestHeader").Rows.Add(cboTestNumber.Text, cboLotNumber.Text, lblHeatNumber.Text, lblPartNumber.Text, lblPartDescription.Text, txtTestedBy.Text, txtApprovedBy.Text)

            Dim newPrintMechanicalTest As New PrintTrufitCertificationMechanicalTest(ds3)
            newPrintMechanicalTest.ShowDialog()
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must select a Test Number", "Select a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test Number", "Enter a valid Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If checkStatus().Equals("OPEN") Then
            MessageBox.Show("You can only print CLOSED Mechanical testing.", "Unable to print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub txtLoadPSI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadPSI.TextChanged
        txtLoadMPA.Text = Math.Round(PSIToMPA(Val(txtLoadPSI.Text)), 6)
    End Sub

    Private Sub txtTensilePSI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTensilePSI.TextChanged
        txtTensileMPA.Text = Math.Round(PSIToMPA(Val(txtTensilePSI.Text)), 6)
    End Sub

    Private Sub txtArea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArea.TextChanged
        If isLoaded Then
            calculateLoadPSI()
            calculateTensilePSI()
        End If
    End Sub

    Private Sub calculateLoadPSI()
        If Val(txtArea.Text) = 0 Then
            txtLoadPSI.Text = 0
        Else
            txtLoadPSI.Text = Math.Round(Val(txtProofPound.Text) / Val(txtArea.Text), 6)
        End If
    End Sub

    Private Sub calculateTensilePSI()
        If Val(txtArea.Text) = 0 Then
            txtTensilePSI.Text = 0
        Else
            txtTensilePSI.Text = Math.Round(Val(txtUltimatePound.Text) / Val(txtArea.Text), 6)
        End If
    End Sub

    Private Sub txtProofPound_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProofPound.TextChanged
        If isLoaded Then
            calculateLoadPSI()
        End If
    End Sub

    Private Sub txtUltimatePound_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUltimatePound.TextChanged
        If isLoaded Then
            calculateTensilePSI()
        End If
    End Sub

    Private Sub cmdFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        If CanFinish() Then
            updateTrufitCertificationMechanicalTest()

            cmd = New SqlCommand("UPDATE TrufitCertificationMechanicalTestHeader SET Status = 'CLOSED' WHERE TestNumber = @TestNumber;", con)
            cmd.CommandText += " UPDATE PullTestLog SET PullTestNumber = @TestNumber WHERE LotNumber = @LotNumber AND (PullTestNumber is null or TestNumber = '');"
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = Val(cboLotNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            checkStatus("CLOSED")
        End If
    End Sub

    Private Function CanFinish() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must enter a Test number", "Enter a testNumber", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid test nubmer", "Enter a vlaid test number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must enter a lot number", "Enter a lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Lot number", "Enter a valid Lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTestedBy.Text) Then
            MessageBox.Show("You must enter a tested by", "Enter a tested by", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTestedBy.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtApprovedBy.Text) Then
            MessageBox.Show("You must enter an approved by", "Enter an approved by", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtApprovedBy.Focus()
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to finish this test", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Function checkStatus(Optional ByVal status As String = "NONE") As String
        If status.Equals("NONE") Then
            cmd = New SqlCommand("SELECT Status FROM TrufitCertificationMechanicalTestHeader WHERE TestNumber = @TestNumber", con)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()
            If Not IsDBNull(obj) Then
                If obj IsNot Nothing Then
                    status = obj
                Else
                    status = "OPEN"
                End If
            Else
                status = "OPEN"
            End If
        End If
        checkLotLock()
        If status.Equals("OPEN") Then
            gpxSampleEntry.Enabled = True
            gpxSignOffEntry.Enabled = True
            gpxDeleteRow.Enabled = True
            cmdSave.Enabled = True
            cmdDelete.Enabled = True
            UnLockTestToolStripMenuItem.Enabled = False
            dgvResultData.Enabled = True
            cmdFinish.Enabled = True
            SaveDataToolStripMenuItem.Enabled = True
            DeleteDataToolStripMenuItem.Enabled = True

        Else
            gpxSampleEntry.Enabled = False
            gpxSignOffEntry.Enabled = False
            gpxDeleteRow.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            UnLockTestToolStripMenuItem.Enabled = True
            dgvResultData.Enabled = False
            cmdFinish.Enabled = False
            SaveDataToolStripMenuItem.Enabled = False
            DeleteDataToolStripMenuItem.Enabled = False
        End If
        Return status
    End Function

    Private Sub UnLockCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockTestToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you wish to unlock?", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            cmd = New SqlCommand("UPDATE TrufitCertificationMechanicalTestHeader SET Status = 'OPEN' WHERE TestNumber = @TestNumber", con)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            checkStatus("OPEN")
        End If
    End Sub

    Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArea.KeyDown, txtProofPound.KeyDown, txtUltimatePound.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Then
            controlKey = True
        ElseIf e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Then
            If Not CType(sender, System.Windows.Forms.TextBox).Text.Contains(".") Then
                controlKey = True
            End If
        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtArea.KeyPress, txtProofPound.KeyPress, txtUltimatePound.KeyPress
        If Not controlKey And Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub TrufitCertificationMechanicalTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


End Class