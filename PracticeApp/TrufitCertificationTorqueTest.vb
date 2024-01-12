Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class TrufitCertificationTorqueTest
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim isLoaded As Boolean = False
    Dim controlKey As Boolean = False

    Public Sub New()
        InitializeComponent()

        LoadTestNumbers()
        LoatLotNumbers()
        If con.State = ConnectionState.Open Then con.Close()
        isLoaded = True
    End Sub

    Public Sub New(ByVal TestNumber As String)
        InitializeComponent()

        LoadTestNumbers()
        LoatLotNumbers()
        If con.State = ConnectionState.Open Then con.Close()
        isLoaded = True

        cboTestNumber.Text = TestNumber
    End Sub

    Private Sub LoadTestNumbers()
        Dim cmd As New SqlCommand("SELECT TestNumber FROM TrufitCertificationTorqueTestHeader", con)

        Dim tempds As New DataSet
        Dim tempadap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        tempadap.Fill(tempds, "TrufitCertificationTorqueTestHeader")

        cboTestNumber.DisplayMember = "TestNumber"
        cboTestNumber.DataSource = tempds.Tables("TrufitCertificationTorqueTestHeader")
        cboTestNumber.SelectedIndex = -1
    End Sub

    Private Sub LoatLotNumbers()
        Dim cmd As New SqlCommand("SELECT LotNumber FROM LotNumber WHERE ItemClass = 'Trufit Parts'", con)

        Dim tempds As New DataSet
        Dim tempadap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        tempadap.Fill(tempds, "LotNumber")

        cboLotNumber.DisplayMember = "LotNumber"
        cboLotNumber.DataSource = tempds.Tables("LotNumber")
        cboLotNumber.SelectedIndex = -1
    End Sub

    Private Sub cmdGenerateTestNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateTestNumber.Click
        isLoaded = False
        clearAll()
        isLoaded = True
        Dim Key As String = "TFTT" + dtpCreatedDate.Value.Year.ToString.Substring(2)
        Dim cmd As New SqlCommand("SELECT MAX(CAST(RIGHT(TestNumber, 3) as int)) as MaxNumber FROM TrufitCertificationTorqueTestHeader WHERE TestNumber Like @TestNumber", con)
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

        cmd = New SqlCommand("INSERT INTO TrufitCertificationTorqueTestHeader (TestNumber, TestingDate, Status) VALUES (@TestNumber, @TestingDate, 'OPEN');", con)
        With cmd.Parameters
            .Add("@TestNumber", SqlDbType.VarChar).Value = Key
            .Add("@TestingDate", SqlDbType.DateTime2).Value = dtpCreatedDate.Value
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        LoadTestNumbers()
        cboTestNumber.Text = Key
    End Sub

    Private Sub clearAll()
        clearAdd()
        Dim tempIsLoaded As Boolean = isLoaded
        isLoaded = False
        cboTestNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        lblHeatNumber.Text = ""
        lblPartNumber.Text = ""
        lblPartDescription.Text = ""
        txtTestedBy.Clear()
        txtApprovedBy.Clear()
        dtpCreatedDate.Value = Now

        dgvResultData.DataSource = Nothing
        cboDeleteResultNumber.DataSource = Nothing
        checkLotLock()
        isLoaded = tempIsLoaded
    End Sub

    Private Sub clearAdd()
        txtActualTorque.Clear()
        txtResults.Clear()
    End Sub

    Private Sub checkLotLock()
        If dgvResultData.Rows.Count > 0 Then
            cboLotNumber.Enabled = False
        Else
            cboLotNumber.Enabled = True
        End If
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
        Dim cmd As New SqlCommand("SELECT LotNumber, TestingDate, HeatNumber, PartNumber, Description, TestedBy, ApprovedBy, Status FROM TrufitCertificationTorqueTestHeader WHERE TestNumber = @TestNumber;", con)
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
            If IsDBNull(reader.Item("TestingDate")) Then
                dtpCreatedDate.Value = Now
            Else
                dtpCreatedDate.Value = reader.Item("TestingDate")
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

    Private Sub ShowResults()
        isLoaded = False
        Dim cmd As New SqlCommand("SELECT SampleNumber, RequiredTorque, ActualTorque, Remarks, TestNumber FROM TrufitCertificationTorqueTestLine WHERE TestNumber = @TestNumber ORDER BY SampleNumber ASC;", con)
        cmd.Parameters.Add("@TesTNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
        Dim ds3 As New DataSet()
        Dim myAdapter3 As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "TrufitCertificationTorqueTestLine")
        con.Close()

        dgvResultData.DataSource = ds3.Tables("TrufitCertificationTorqueTestLine")
        dgvResultData.Columns("SampleNumber").HeaderText = "Sample Number"
        dgvResultData.Columns("SampleNumber").ReadOnly = True
        dgvResultData.Columns("RequiredTorque").Visible = False
        dgvResultData.Columns("ActualTorque").HeaderText = "Actual Torque"
        dgvResultData.Columns("TestNumber").Visible = False

        cboDeleteResultNumber.DisplayMember = "SampleNumber"
        cboDeleteResultNumber.DataSource = ds3.Tables("TrufitCertificationTorqueTestLine")
        isLoaded = True
    End Sub

    Private Function checkStatus(Optional ByVal status As String = "NONE") As String
        If status.Equals("NONE") Then
            Dim cmd As New SqlCommand("SELECT Status FROM TrufitCertificationTorqueTestHeader WHERE TestNumber = @TestNumber", con)
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
            cmdPrint.Enabled = False
            UnLockTestToolStripMenuItem.Enabled = False
            dgvResultData.Enabled = True
            cmdFinish.Enabled = True
            SaveDataToolStripMenuItem.Enabled = True
            DeleteDataToolStripMenuItem.Enabled = True
            PrintDataToolStripMenuItem.Enabled = False
        Else
            gpxSampleEntry.Enabled = False
            gpxSignOffEntry.Enabled = False
            gpxDeleteRow.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdPrint.Enabled = True
            UnLockTestToolStripMenuItem.Enabled = True
            dgvResultData.Enabled = False
            cmdFinish.Enabled = False
            SaveDataToolStripMenuItem.Enabled = False
            DeleteDataToolStripMenuItem.Enabled = False
            PrintDataToolStripMenuItem.Enabled = True
        End If
        Return status
    End Function

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        If isLoaded Then
            Dim cmd As New SqlCommand("SELECT HeatNumber, PartNumber, ShortDescription FROM LotNumber WHERE LotNumber = @LotNumber;", con)
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

    Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtActualTorque.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Then
            controlKey = True
        ElseIf e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Then
            If Not CType(sender, System.Windows.Forms.TextBox).Text.Contains(".") Then
                controlKey = True
            End If
        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtActualTorque.KeyPress
        If Not controlKey And Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub cmdAddSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSample.Click
        If canAddSample() Then
            updateTrufitCertificationTorqueTest()

            Dim cmd As New SqlCommand("INSERT INTO TrufitCertificationTorqueTestLine (TestNumber, SampleNumber, ActualTorque, Remarks) VALUES (@TestNumber, (SELECT isnull(MAX(SampleNumber) + 1, 1) FROM TrufitCertificationTorqueTestLine WHERE TestNumber = @TestNumber), @ActualTorque, @Remarks);", con)
            With cmd.Parameters
                .Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
                .Add("@ActualTorque", SqlDbType.VarChar).Value = txtActualTorque.Text

                .Add("@Remarks", SqlDbType.VarChar).Value = txtResults.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowResults()
            clearAdd()
            checkLotLock()
        End If
    End Sub

    Private Function canAddSample() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must enter a Test Number", "Enter a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test Number", "Enter a valid Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must enter a Lot Number", "Etner a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Lot Number", "Enter a valid Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtActualTorque.Text) Then
            MessageBox.Show("You must enter a value for Acutal Torque", "Enter a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtActualTorque.Focus()
            Return False
        End If
        If Not IsNumeric(txtActualTorque.Text) Then
            MessageBox.Show("You must enter a number for Actual Torque", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtActualTorque.SelectAll()
            txtActualTorque.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub updateTrufitCertificationTorqueTest()
        Dim cmd As New SqlCommand("UPDATE TrufitCertificationTorqueTestHeader SET LotNumber = @LotNumber, HeatNumber = @HeatNumber, PartNumber = @PartNumber, Description = @Description, TestedBy = @TestedBy, ApprovedBy = @ApprovedBy WHERE TestNumber = @TestNumber;", con)

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

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click, ClearDataToolStripMenuItem.Click
        clearAdd()
    End Sub

    Private Sub cmdFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        If canFinish() Then
            updateTrufitCertificationTorqueTest()
            Dim cmd As New SqlCommand("UPDATE TrufitCertificationTorqueTestHeader SET Status = 'CLOSED' WHERE TestNumber = @TestNumber;", con)
            cmd.CommandText += " UPDATE PullTestLog SET TorqueTestNumber = @TestNumber WHERE LotNumber = @LotNumber AND (TestNumber is null or TestNumber = '') AND (TestType = 'PULL AND TORQUE' OR TestType = 'TORQUE');"
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = Val(cboLotNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            checkStatus("CLOSED")
        End If
    End Sub

    Private Function canFinish() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must enter a Test Number", "Enter a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test Nubmer", "Enter a valid Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must enter a Lot Number", "Enter a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Lot Number", "Enter a valid Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveDataToolStripMenuItem.Click
        If canSave() Then
            updateTrufitCertificationTorqueTest()
            checkStatus("OPEN")
        End If
    End Sub

    Private Function canSave() As Boolean
        If Not checkStatus().Equals("OPEN") Then
            MessageBox.Show("Unable ot save, already finished.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must enter a Test Number", "Enter a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test Number", "Enter a valid Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click, ClearDataToolStripMenuItem.Click
        clearAll()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteDataToolStripMenuItem.Click
        If canDelete() Then
            Dim cmd As New SqlCommand("DELETE TrufitCertificationTorqueTestHeader WHERE TestNumber = @TestNumber;", con)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            clearAll()
            LoadTestNumbers()
        End If
    End Sub

    Private Function canDelete() As Boolean
        If Not checkStatus().Equals("OPEN") Then
            MessageBox.Show("Unable to delete a finished test.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must enter a Test Number", "Enter a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.Focus()
            Return False
        End If
        If cboTestNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Test Number", "Enter a valid Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTestNumber.SelectAll()
            cboTestNumber.Focus()
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to delete this test?", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub UnLockTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockTestToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you wish to unlock?", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim cmd As New SqlCommand("UPDATE TrufitCertificationTorqueTestHeader SET Status = 'OPEN' WHERE TestNumber = @TestNumber", con)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            checkStatus("OPEN")
        End If
    End Sub

    Private Sub cmdDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRow.Click
        If canDeleteRow() Then
            Dim cmd As New SqlCommand("DELETE TrufitCertificationTorqueTestLine WHERE SampleNumber = @SampleNumber AND TestNumber = @TestNumber;" _
                                      + " UPDATE TrufitCertificationTorqueTestLine SET SampleNumber = SampleNumber - 1 WHERE TestNumber = @TestNumber and SampleNumber > @SampleNumber", con)
            cmd.Parameters.Add("@SampleNumber", SqlDbType.VarChar).Value = Val(cboDeleteResultNumber.Text)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowResults()
            checkLotLock()
            If dgvResultData.Rows.Count = 0 Then
                cboDeleteResultNumber.Text = ""
            End If
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

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintDataToolStripMenuItem.Click
        If canPrint() Then
            Dim ds3 As New DataSet
            ds3.Tables.Add(CType(dgvResultData.DataSource, System.Data.DataTable).Copy())
            If Not ds3.Tables.Contains("TrufitCertificationTorqueTestHeader") Then
                ds3.Tables.Add("TrufitCertificationTorqueTestHeader")
                ds3.Tables("TrufitCertificationTorqueTestHeader").Columns.Add("TestNumber")
                ds3.Tables("TrufitCertificationTorqueTestHeader").Columns.Add("LotNumber")
                ds3.Tables("TrufitCertificationTorqueTestHeader").Columns.Add("HeatNumber")
                ds3.Tables("TrufitCertificationTorqueTestHeader").Columns.Add("PartNumber")
                ds3.Tables("TrufitCertificationTorqueTestHeader").Columns.Add("Description")
                ds3.Tables("TrufitCertificationTorqueTestHeader").Columns.Add("TestedBy")
                ds3.Tables("TrufitCertificationTorqueTestHeader").Columns.Add("ApprovedBy")
            Else
                ds3.Tables("TrufitCertificationTorqueTestHeader").Rows.Clear()
            End If
            ds3.Tables("TrufitCertificationTorqueTestHeader").Rows.Add(cboTestNumber.Text, cboLotNumber.Text, lblHeatNumber.Text, lblPartNumber.Text, lblPartDescription.Text, txtTestedBy.Text, txtApprovedBy.Text)

            Dim newPrintTFPTorqueTest As New PrintTrufitCertificationTorqueTest(ds3)
            newPrintTFPTorqueTest.ShowDialog()
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            MessageBox.Show("You must enter a Test Number", "Enter a Test Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            MessageBox.Show("Testing must be finished to print.", "Finish the testing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub dgvResultData_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultData.CellValueChanged
        If canUpdateCell() Then
            Dim cmd As New SqlCommand("UPDATE TrufitCertificationTorqueTestLine SET " + dgvResultData.Columns(e.ColumnIndex).DataPropertyName + " = @value WHERE TesTNumber = @TesTNumber and SampleNumber = @SampleNumber", con)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = cboTestNumber.Text
            cmd.Parameters.Add("@SampleNumber", SqlDbType.Int).Value = dgvResultData.Rows(e.RowIndex).Cells("SampleNumber").Value
            cmd.Parameters.Add("@value", SqlDbType.VarChar).Value = dgvResultData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            ShowResults()
        End If
    End Sub

    Private Function canUpdateCell() As Boolean
        If Not isLoaded Then
            Return False
        End If
        If String.IsNullOrEmpty(cboTestNumber.Text) Then
            Return False
        End If
        If dgvResultData.Rows.Count = 0 Then
            Return False
        End If
        If dgvResultData.SelectedCells.Count = 0 Then
            Return False
        End If
        If checkStatus().Equals("CLOSED") Then
            Return False
        End If
        Return True
    End Function

    Private Sub TrufitCertificationTorqueTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class