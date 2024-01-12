Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class HeaderSetupSheet
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Dim isLoaded As Boolean = False

    Dim SetupDS As DataSet

    Public Sub New()
        InitializeComponent()

        LoadBlueprintNumbers()
        LoadMachineNumbers()
        SetupDGV()
        dgvHeaderSetupData.Enabled = False
        isLoaded = True
    End Sub

    Private Sub LoadBlueprintNumbers()
        cmd = New SqlCommand("SELECT DISTINCT(BlueprintNumber) as BlueprintNumber FROM FOXTable WHERE BlueprintNumber is not null", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboBlueprintNumber.Items.Add(reader.Item("BlueprintNumber"))
            End While
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub LoadMachineNumbers()
        cmd = New SqlCommand("SELECT MachineID FROM MachineTable WHERE DivisionID = 'TWD' and MachineID is not null", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboMachineNumber.Items.Add(reader.Item("MachineID"))
            End While
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cboBlueprintNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBlueprintNumber.SelectedIndexChanged
        If isLoaded Then

            Dim bpRev As String = ""
            Dim newSelectFOX As New HeaderSetupSheetSelectFOX(cboBlueprintNumber.Text)
            If newSelectFOX.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                If newSelectFOX.dgvFOXes.SelectedRows.Count > 0 Then
                    Dim rowIndex As Integer = newSelectFOX.dgvFOXes.SelectedRows(0).Index

                    lblFOXNumber.Text = newSelectFOX.dgvFOXes.Rows(rowIndex).Cells("FOXNumber").Value
                    lblCustomer.Text = newSelectFOX.dgvFOXes.Rows(rowIndex).Cells("CustomerID").Value
                    bpRev = newSelectFOX.dgvFOXes.Rows(rowIndex).Cells("BlueprintRevision").Value
                    lblPartDescription.Text = newSelectFOX.dgvFOXes.Rows(rowIndex).Cells("ShortDescription").Value
                Else
                    Dim rowIndex As Integer = newSelectFOX.dgvFOXes.SelectedCells(0).RowIndex

                    lblFOXNumber.Text = newSelectFOX.dgvFOXes.Rows(rowIndex).Cells("FOXNumber").Value
                    lblCustomer.Text = newSelectFOX.dgvFOXes.Rows(rowIndex).Cells("CustomerID").Value
                    bpRev = newSelectFOX.dgvFOXes.Rows(rowIndex).Cells("BlueprintRevision").Value
                    lblPartDescription.Text = newSelectFOX.dgvFOXes.Rows(rowIndex).Cells("ShortDescription").Value
                End If
            Else
                isLoaded = False
                cboBlueprintNumber.SelectedIndex = -1
                If Not String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
                    cboBlueprintNumber.Text = ""
                End If
                isLoaded = True
                lblFOXNumber.Text = ""
                lblCustomer.Text = ""
                lblPartDescription.Text = ""
            End If
            newSelectFOX.Dispose()

            If cboMachineNumber.SelectedIndex <> -1 Then
                LoadSetups(bpRev)
                LoadSetupData()
            Else
                cboBlueprintRevision.Text = bpRev
                dgvHeaderSetupData.Enabled = False
                If Not String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
                    cboMachineNumber.Focus()
                Else
                    cboBlueprintNumber.Focus()
                End If

            End If
        End If
    End Sub

    Private Sub LoadSetups(ByVal bpRev As String)
        SetupDS = New DataSet()

        cmd = New SqlCommand("SELECT SetupKey, Date, Operator, MachineNumber, Comments, BlueprintRevision FROM HeaderSetupHeaderTable WHERE FOXNumber = @FOXNumber AND BlueprintNumber = @BlueprintNumber AND MachineNumber = @MachineNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
        cmd.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBlueprintNumber.Text

        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(SetupDS, "HeaderSetupHeaderTable")
        con.Close()

        Dim found As Boolean = False
        For i As Integer = 0 To SetupDS.Tables("HeaderSetupHeaderTable").Rows.Count - 1 And Not found
            If SetupDS.Tables("HeaderSetupHeaderTable").Rows(i).Item("BlueprintRevision").ToString.Equals(bpRev) Then
                found = True
            End If
        Next

        If Not found Then
            SetupDS.Tables("HeaderSetupHeaderTable").Rows.Add(0, Now.Date, txtOperator.Text, cboMachineNumber.Text, txtComments.Text, cboBlueprintRevision.Text)
        End If
        isLoaded = False
        cboBlueprintRevision.DisplayMember = "BlueprintRevision"
        cboBlueprintRevision.DataSource = SetupDS.Tables("HeaderSetupHeaderTable")
        isLoaded = True
        SetupDGV()
        cboBlueprintRevision.Text = bpRev
        dgvHeaderSetupData.Enabled = True
    End Sub

    Private Sub cboMachineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMachineNumber.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboBlueprintNumber.Text) And Not String.IsNullOrEmpty(cboBlueprintRevision.Text) Then
                LoadSetups(cboBlueprintRevision.Text)
                LoadSetupData()
                If Not String.IsNullOrEmpty(cboMachineNumber.Text) Then
                    If Not dgvHeaderSetupData.Enabled Then
                        dgvHeaderSetupData.Enabled = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        isLoaded = False
        cboBlueprintNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
            cboBlueprintNumber.Text = ""
        End If
        cboBlueprintRevision.DataSource = Nothing
        cboBlueprintRevision.Text = ""
        cboMachineNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboMachineNumber.Text) Then
            cboMachineNumber.Text = ""
        End If
        dtpDate.Value = Now
        lblFOXNumber.Text = ""
        lblCustomer.Text = ""
        txtOperator.Clear()
        lblPartDescription.Text = ""
        txtComments.Clear()
        SetupDGV()
        dgvHeaderSetupData.Enabled = False
        isLoaded = True
    End Sub

    Private Sub SetupDGV()
        isLoaded = False
        If Not ClearDGV() Then
            dgvHeaderSetupData.Columns.Add("ToolingNames", "ToolingNames")
            dgvHeaderSetupData.Columns("ToolingNames").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            dgvHeaderSetupData.Columns("ToolingNames").ReadOnly = True
            dgvHeaderSetupData.Columns("ToolingNames").DefaultCellStyle.Font = New System.Drawing.Font(dgvHeaderSetupData.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold)
            dgvHeaderSetupData.Columns("ToolingNames").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvHeaderSetupData.Columns.Add("1", "1")
            dgvHeaderSetupData.Columns("1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvHeaderSetupData.Columns.Add("2", "2")
            dgvHeaderSetupData.Columns("2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvHeaderSetupData.Columns.Add("3", "3")
            dgvHeaderSetupData.Columns("3").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvHeaderSetupData.Columns.Add("4", "4")
            dgvHeaderSetupData.Columns("4").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvHeaderSetupData.Columns.Add("5", "5")
            dgvHeaderSetupData.Columns("5").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvHeaderSetupData.Columns.Add("6", "6")
            dgvHeaderSetupData.Columns("6").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dgvHeaderSetupData.Rows.Add("Tooling", "Station 1", "Station 2", "Station 3", "Station 4", "Station 5", "Station 6")
            dgvHeaderSetupData.Rows(0).DefaultCellStyle.Font = New System.Drawing.Font(dgvHeaderSetupData.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold)
            dgvHeaderSetupData.Rows(0).ReadOnly = True
            dgvHeaderSetupData.Rows.Add("Hammer Length")
            dgvHeaderSetupData.Rows.Add("Hammer Pin Length")
            dgvHeaderSetupData.Rows.Add("Hammer Filler Length")
            dgvHeaderSetupData.Rows.Add("Hammer Block Filler Length")
            dgvHeaderSetupData.Rows.Add("Positive Knock Out Pin Length")
            dgvHeaderSetupData.Rows.Add("Wedge Length")
            dgvHeaderSetupData.Rows.Add("Length Adjuster")
            dgvHeaderSetupData.Rows.Add("Buttons")
        End If
        isLoaded = True
        dgvHeaderSetupData.Rows(1).Cells(1).Selected = True
    End Sub

    Private Function ClearDGV() As Boolean
        If dgvHeaderSetupData.Rows.Count > 0 Then
            For i As Integer = 1 To dgvHeaderSetupData.Rows.Count - 1
                dgvHeaderSetupData.Rows(i).Cells(1).Value = ""
                dgvHeaderSetupData.Rows(i).Cells(2).Value = ""
                dgvHeaderSetupData.Rows(i).Cells(3).Value = ""
                dgvHeaderSetupData.Rows(i).Cells(4).Value = ""
                dgvHeaderSetupData.Rows(i).Cells(5).Value = ""
                dgvHeaderSetupData.Rows(i).Cells(6).Value = ""
            Next
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub dgvHeaderSetupData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvHeaderSetupData.Click
        If isLoaded Then
            If Not dgvHeaderSetupData.Enabled Then
                MessageBox.Show("You must select a Blueprint, Revision Level, and Machine in order to edit stations.", "Unable to Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub dgvHeaderSetupData_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHeaderSetupData.CellValueChanged
        If isLoaded Then
            If Not IsNumeric(dgvHeaderSetupData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                isLoaded = False
                dgvHeaderSetupData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                isLoaded = True
            End If
            Dim key As Integer = SaveHeader()
            If key <> 0 Then
                cmd = New SqlCommand("IF EXISTS(SELECT StationNumber FROM HeaderSetupLineTable WHERE SetupKey = @SetupKey AND StationNumber = @StationNumber) UPDATE HeaderSetupLineTable SET HammerLength = @HammerLength, HammerPinLength = @HammerPinLength, HammerFillerLength = @HammerFillerLength, HammerBlockFillerLength = @HammerBlockFillerLength, PositiveKnockOutPinLength = @PositiveKnockOutPinLength, WedgeLength = @WedgeLength, LengthAdjuster = @LengthAdjuster, Buttons = @Buttons WHERE SetupKey = @SetupKey AND StationNumber = @StationNumber ELSE INSERT INTO HeaderSetupLineTable (SetupKey, StationNumber, HammerLength, HammerPinLength, HammerFillerLength, HammerBlockFillerLength, PositiveKnockOutPinLength, WedgeLength, LengthAdjuster, Buttons) VALUES (@SetupKey, @StationNumber, @HammerLength, @HammerPinLength, @HammerFillerLength, @HammerBlockFillerLength, @PositiveKnockOutPinLength, @WedgeLength, @LengthAdjuster, @Buttons)", con)
                With cmd.Parameters
                    .Add("@SetupKey", SqlDbType.Int).Value = key
                    .Add("@StationNumber", SqlDbType.Int).Value = e.ColumnIndex
                    .Add("@HammerLength", SqlDbType.Float).Value = Val(dgvHeaderSetupData.Rows(1).Cells(e.ColumnIndex).Value)
                    .Add("@HammerPinLength", SqlDbType.Float).Value = Val(dgvHeaderSetupData.Rows(2).Cells(e.ColumnIndex).Value)
                    .Add("@HammerFillerLength", SqlDbType.Float).Value = Val(dgvHeaderSetupData.Rows(3).Cells(e.ColumnIndex).Value)
                    .Add("@HammerBlockFillerLength", SqlDbType.Float).Value = Val(dgvHeaderSetupData.Rows(4).Cells(e.ColumnIndex).Value)
                    .Add("@PositiveKnockOutPinLength", SqlDbType.Float).Value = Val(dgvHeaderSetupData.Rows(5).Cells(e.ColumnIndex).Value)
                    .Add("@WedgeLength", SqlDbType.Float).Value = Val(dgvHeaderSetupData.Rows(6).Cells(e.ColumnIndex).Value)
                    .Add("@LengthAdjuster", SqlDbType.Float).Value = Val(dgvHeaderSetupData.Rows(7).Cells(e.ColumnIndex).Value)
                    .Add("@Buttons", SqlDbType.Float).Value = Val(dgvHeaderSetupData.Rows(8).Cells(e.ColumnIndex).Value)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Public Function SaveHeader() As Integer
        If Not SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey").Equals(0) Then
            cmd = New SqlCommand("UPDATE HeaderSetupHeaderTable SET FOXNumber = @FOXnumber, Date = @Date, Description = @Description, BlueprintNumber = @BlueprintNumber, BlueprintRevision = @BlueprintRevision, Operator = @Operator, MachineNumber = @MachineNumber, CustomerID = @CustomerID, Comments = @Comments WHERE SetupKey = @Setupkey;", con)
            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
                .Add("@Date", SqlDbType.DateTime).Value = dtpDate.Value
                .Add("@Description", SqlDbType.VarChar).Value = lblPartDescription.Text
                .Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBlueprintNumber.Text
                .Add("@BlueprintRevision", SqlDbType.VarChar).Value = cboBlueprintRevision.Text
                .Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
                .Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomer.Text
                .Add("@Operator", SqlDbType.VarChar).Value = txtOperator.Text
                .Add("@Comments", SqlDbType.VarChar).Value = txtComments.Text
                .Add("@SetupKey", SqlDbType.Int).Value = SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey")
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteScalar()
            con.Close()
            Return SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey")
        Else
            cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(SetupKey) + 1, 1) FROM HeaderSetupHeaderTable); INSERT INTO HeaderSetupHeaderTable (SetupKey, FOXNumber, Date, Description, BlueprintNumber, BlueprintRevision, Operator, MachineNumber, CustomerID, Comments) VALUES (@Key, @FOXNumber, @Date, @Description, @BlueprintNumber, @BlueprintRevision, @Operator, @MachineNumber, @CustomerID, @Comments); SELECT @Key;", con)
            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
                .Add("@Date", SqlDbType.DateTime).Value = dtpDate.Value
                .Add("@Description", SqlDbType.VarChar).Value = lblPartDescription.Text
                .Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBlueprintNumber.Text
                .Add("@BlueprintRevision", SqlDbType.VarChar).Value = cboBlueprintRevision.Text
                .Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
                .Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomer.Text
                .Add("@Operator", SqlDbType.VarChar).Value = txtOperator.Text
                .Add("@Comments", SqlDbType.VarChar).Value = txtComments.Text
            End With
            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()
            If Not IsDBNull(obj) Then
                SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey") = obj
                Return obj
            Else
                Return 0
            End If
        End If
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSaveHeader() Then
            Dim key As Integer = SaveHeader()
            If SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey").Equals(0) Then
                SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey") = key
            End If
            MessageBox.Show("Setup Sheet has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Function canSaveHeader() As Boolean
        If String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
            MessageBox.Show("You must select a Blueprint Number", "Select a Blueprint Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBlueprintNumber.Focus()
            Return False
        End If
        If cboBlueprintNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid Blueprint Number", "Select a Blueprint Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBlueprintNumber.SelectAll()
            cboBlueprintNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboBlueprintRevision.Text) Then
            MessageBox.Show("You must select a Revision Level", "Select a Revision Level", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBlueprintRevision.Focus()
            Return False
        End If
        If cboBlueprintRevision.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid Revision Level", "Select a Revision Level", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBlueprintRevision.SelectAll()
            cboBlueprintRevision.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboMachineNumber.Text) Then
            MessageBox.Show("You must select a machine", "Select a machine", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMachineNumber.Focus()
            Return False
        End If
        If cboMachineNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid machine", "Select a valid machine", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMachineNumber.SelectAll()
            cboMachineNumber.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub cboBlueprintRevision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBlueprintRevision.SelectedIndexChanged
        If isLoaded And cboBlueprintRevision.SelectedIndex <> -1 Then
            LoadSetupData()
        End If
    End Sub

    Private Sub LoadSetupData()
        If Not SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey").Equals(0) Then
            cmd = New SqlCommand("SELECT Operator, Comments FROM HeaderSetupHeaderTable WHERE SetupKey = @SetupKey", con)
            cmd.Parameters.Add("@SetupKey", SqlDbType.Int).Value = SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey")

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If reader.IsDBNull(0) Or reader.IsDBNull(1) Then
                    txtOperator.Clear()
                    txtComments.Clear()
                Else
                    txtOperator.Text = reader.Item("Operator")
                    txtComments.Text = reader.Item("Comments")
                End If
            End If
            reader.Close()

            cmd.CommandText = "SELECT StationNumber, HammerLength, HammerPinLength, HammerFillerLength, HammerBlockFillerLength, PositiveKnockOutPinLength, WedgeLength, LengthAdjuster, Buttons FROM HeaderSetupLineTable WHERE SetupKey = @SetupKey"

            If con.State = ConnectionState.Closed Then con.Open()
            reader = cmd.ExecuteReader()

            If reader.HasRows Then
                isLoaded = False
                While reader.Read()
                    Dim colIndex As Integer = reader.Item("StationNumber")
                    If Not IsDBNull(reader.Item("HammerLength")) Then
                        dgvHeaderSetupData.Rows(1).Cells(colIndex).Value = reader.Item("HammerLength")
                    End If
                    If Not IsDBNull(reader.Item("HammerPinLength")) Then
                        dgvHeaderSetupData.Rows(2).Cells(colIndex).Value = reader.Item("HammerPinLength")
                    End If
                    If Not IsDBNull(reader.Item("HammerFillerLength")) Then
                        dgvHeaderSetupData.Rows(3).Cells(colIndex).Value = reader.Item("HammerFillerLength")
                    End If
                    If Not IsDBNull(reader.Item("HammerBlockFillerLength")) Then
                        dgvHeaderSetupData.Rows(4).Cells(colIndex).Value = reader.Item("HammerBlockFillerLength")
                    End If
                    If Not IsDBNull(reader.Item("PositiveKnockOutPinLength")) Then
                        dgvHeaderSetupData.Rows(5).Cells(colIndex).Value = reader.Item("PositiveKnockOutPinLength")
                    End If
                    If Not IsDBNull(reader.Item("WedgeLength")) Then
                        dgvHeaderSetupData.Rows(6).Cells(colIndex).Value = reader.Item("WedgeLength")
                    End If
                    If Not IsDBNull(reader.Item("LengthAdjuster")) Then
                        dgvHeaderSetupData.Rows(7).Cells(colIndex).Value = reader.Item("LengthAdjuster")
                    End If
                    If Not IsDBNull(reader.Item("Buttons")) Then
                        dgvHeaderSetupData.Rows(8).Cells(colIndex).Value = reader.Item("Buttons")
                    End If
                End While
                isLoaded = True
            End If
            reader.Close()
            con.Close()
        End If

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If canPrint() Then
            Dim newPrintHeaderSetupSheet As New PrintHeaderSetupSheet(SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey"))
            newPrintHeaderSetupSheet.ShowDialog()
        End If
    End Sub

    Private Function canPrint() As Boolean
        If cboBlueprintNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid Blueprint Number", "Select a Blueprint", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBlueprintNumber.Focus()
            Return False
        End If
        If cboBlueprintRevision.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid Revision", "Select a Revision", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBlueprintRevision.Focus()
            Return False
        End If
        If cboMachineNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid Machine", "Select a valid Machine", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMachineNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDelete() Then
            If cboBlueprintRevision.SelectedIndex <> -1 Then
                cmd = New SqlCommand("DELETE HeaderSetupHeaderTable WHERE SetupKey = @SetupKey", con)
                cmd.Parameters.Add("@SetupKey", SqlDbType.Int).Value = SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey")

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            cmdClear_Click(sender, e)
            MessageBox.Show("Setup has been deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboBlueprintNumber.Focus()
        End If
    End Sub

    Private Function canDelete() As Boolean
        If String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
            Return False
        End If
        If String.IsNullOrEmpty(cboBlueprintRevision.Text) Then
            Return False
        End If
        If String.IsNullOrEmpty(cboMachineNumber.Text) Then
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to delete the Setup data?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cboMachineNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMachineNumber.Leave
        If Not String.IsNullOrEmpty(cboMachineNumber.Text) Then
            If cboMachineNumber.Text.Length < 3 Then
                While cboMachineNumber.Text.Length < 3
                    cboMachineNumber.Text = "0" + cboMachineNumber.Text
                End While
            End If
        End If
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboBlueprintNumber.Text) And Not String.IsNullOrEmpty(cboBlueprintRevision.Text) Then
                LoadSetups(cboBlueprintRevision.Text)
                LoadSetupData()
            End If
        End If
    End Sub

    Private Sub CopyFromToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromToolStripMenuItem.Click
        If canCopy() Then
            Dim test As String = SaveHeader().ToString()
            Dim newSelectSetupSheet As New HeaderSetupSheetSelectSetup(cboBlueprintNumber.Text, SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey"))
            If newSelectSetupSheet.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                cmd = New SqlCommand("DECLARE @NewComments as varchar(500) = (SELECT Comments FROM HeaderSetupHeaderTable WHERE SetupKey = @OldSetupKey); DELETE HeaderSetupLineTable WHERE SetupKey = @NewSetupKey; INSERT INTO HeaderSetupLineTable (SetupKey, StationNumber, HammerLength, HammerPinLength, HammerFillerLength, HammerBlockFillerLength, PositiveKnockOutPinLength, WedgeLength, LengthAdjuster, Buttons) SELECT @NewSetupKey, StationNumber, HammerLength, HammerPinLength, HammerFillerLength, HammerBlockFillerLength, PositiveKnockOutPinLength, WedgeLength, LengthAdjuster, Buttons FROM HeaderSetupLineTable WHERE SetupKey = @OldSetupKey; UPDATE HeaderSetupHeaderTable SET Comments = @NewComments WHERE SetupKey = @NewSetupKey; SELECT @NewComments;", con)
                cmd.Parameters.Add("@NewSetupKey", SqlDbType.Int).Value = Val(SetupDS.Tables("HeaderSetupHeaderTable").Rows(cboBlueprintRevision.SelectedIndex).Item("SetupKey"))
                cmd.Parameters.Add("@OldSetupKey", SqlDbType.Int).Value = newSelectSetupSheet.dgvSetup.Rows(newSelectSetupSheet.dgvSetup.CurrentCell.RowIndex).Cells("SetupKey").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd.ExecuteScalar()
                If obj IsNot Nothing Then
                    txtComments.Text = obj.ToString()
                End If
                LoadSetupData()
            End If
        End If
    End Sub

    Private Function canCopy() As Boolean
        If String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
            MessageBox.Show("You must enter a blueprint number", "Enter a blueprint number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBlueprintNumber.Focus()
            Return False
        End If
        If cboBlueprintNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid blueprint number", "Enter a valid blueprint number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBlueprintNumber.SelectAll()
            cboBlueprintNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboBlueprintRevision.Text) Then
            MessageBox.Show("You must enter a revision level", "Enter a revision level", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBlueprintRevision.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboMachineNumber.Text) Then
            MessageBox.Show("You must enter a machine", "Enter a machine", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMachineNumber.Focus()
            Return False
        End If
        If cboMachineNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid machine", "Enter a valid machine", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMachineNumber.SelectAll()
            cboMachineNumber.Focus()
            Return False
        End If
        If MessageBox.Show("Copying from another setup sheet will overwrite existing setup numbers and comments. Do you wish to continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub HeaderSetupSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class