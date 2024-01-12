Imports System.Data.SqlClient

Public Class InspectionReport
    Inherits System.Windows.Forms.Form

    Dim LineSampleSize, LineComment, LineInspectionMethod, LineLowSpec, LineHighSpec, LinePartDetail, LineFrequency As String
    Dim LineInspectionLineNumber As Integer

    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim dt As Data.DataTable
    Dim FoxesDT As Data.DataTable

    Dim isLoaded As Boolean = False
    Dim newRecordSaved = True
    Dim FOXPartNumber, FOXBluePrintNumber, OldInspectionKey, NewInspectionKey As String

    Dim BlueprintJournalForm As BlueprintJournal
    Dim freq As New List(Of String)
    ''For drag and drop line reorder
    Dim dragBoxFromMouseDown As System.Drawing.Rectangle
    Dim rowIndexFromMouseDown As Integer = -1
    Dim rowIndexOfItemUnderMouseToDrop As Integer = -1

    Public Sub New()
        InitializeComponent()

        For i As Integer = 0 To cboFrequency.Items.Count - 1
            freq.Add(cboFrequency.Items(i))
        Next
        LoadFOXNumber()
        LoadBlueprint()
        LoadInspectionKey()
        LoadMachines()
        ClearAll()
        ShowData()

        usefulFunctions.LoadSecurity(Me)
        
        isLoaded = True
    End Sub

    Private Sub ShowData()
        Dim tmpIsLoaded As Boolean = isLoaded
        isLoaded = False
        cmd = New SqlCommand("SELECT InspectionKey, InspectionLineNumber, LowSpec, HighSpec, PartDetail, Frequency, SampleSize, InspectionMethod, Specification, LineComment FROM QCInspectionLineTable WHERE InspectionKey = @InspectionKey;", con)
        cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text()
        dt = New Data.DataTable("QCInspectionLineTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        ''ds.Tables("QCInspectionLineTable").Columns("LowSpec").SetOrdinal(2)
        ''ds.Tables("QCInspectionLineTable").Columns("HighSpec").SetOrdinal(3)
        If cboLineNumber.DisplayMember <> "InspectionLineNumber" Then cboLineNumber.DisplayMember = "InspectionLineNumber"
        cboLineNumber.DataSource = dt

        Try
            dgvInspectionReports.DataSource = dt
        Catch ex As System.Exception

        End Try

        dgvInspectionReports.Columns("InspectionKey").Visible = False
        dgvInspectionReports.Columns("InspectionLineNumber").Visible = False
        dgvInspectionReports.Columns("Specification").Visible = False
        dgvInspectionReports.Columns("LowSpec").HeaderText = "Low Spec"
        dgvInspectionReports.Columns("HighSpec").HeaderText = "High Spec"
        dgvInspectionReports.Columns("PartDetail").HeaderText = "Part Detail"
        dgvInspectionReports.Columns("SampleSize").HeaderText = "Sample Size"
        dgvInspectionReports.Columns("InspectionMethod").HeaderText = "Inspection Method"
        dgvInspectionReports.Columns("LineComment").HeaderText = "Line Comment"
        'dgvInspectionReports.Columns("InspectionMethod").ReadOnly = True

        For Each rw As DataGridViewRow In dgvInspectionReports.Rows
            Dim cbo As New DataGridViewComboBoxCell()
            cbo.Items.AddRange(freq.ToArray())
            If Not cboFrequency.Items.Contains(rw.Cells("Frequency").Value) Then
                cbo.Items.Add(rw.Cells("Frequency").Value)
            End If
            cbo.Value = rw.Cells("Frequency").Value
            rw.Cells("Frequency") = cbo
        Next
        isLoaded = tmpIsLoaded
    End Sub

    Private Sub LoadInspectionKey()
        cmd = New SqlCommand("SELECT InspectionKey FROM QCInspectionHeaderTable;", con)
        Dim dt As New Data.DataTable("InspectionHeaderTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboInspectionKey.DisplayMember = "InspectionKey"
        cboInspectionKey.DataSource = dt
        cboInspectionKey.SelectedIndex = -1
    End Sub

    Private Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable;", con)
        Dim dt As New Data.DataTable("FOXTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboFoxNumber.DisplayMember = "FOXNumber"
        cboFoxNumber.DataSource = dt
        cboFoxNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadBlueprint()
        cmd = New SqlCommand("SELECT DISTINCT(BlueprintNumber) as BlueprintNumber FROM FOXTable", con)
        Dim dt As New Data.DataTable("FOXTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboBluePrint.DisplayMember = "BlueprintNumber"
        cboBluePrint.DataSource = dt
        cboBluePrint.SelectedIndex = -1
    End Sub

    Private Sub LoadMachines()
        cmd = New SqlCommand("SELECT MachineID FROM MachineTable WHERE DivisionID = 'TWD';", con)
        Dim dt As New Data.DataTable("MachineTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboMachineNumber.DisplayMember = "MachineID"
        cboMachineNumber.DataSource = dt
        cboMachineNumber.SelectedIndex = -1
    End Sub

    Private Sub AddLine()
        cmd = New SqlCommand("Insert Into QCInspectionLineTable (InspectionKey, InspectionLineNumber, LowSpec, HighSpec, PartDetail, Frequency, SampleSize,  InspectionMethod, LineComment, Specification)values(@InspectionKey, (SELECT isnull(MAX(InspectionLineNumber) + 1, 1) FROM QCInspectionLineTable WHERE InspectionKey = @InspectionKey), @LowSpec, @HighSpec, @PartDetail, @Frequency, @SampleSize,  @InspectionMethod, @LineComment, @Specification);", con)

        With cmd.Parameters
            .Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text
            .Add("@LowSpec", SqlDbType.VarChar).Value = txtLowSpec.Text
            .Add("@HighSpec", SqlDbType.VarChar).Value = txtHighSpec.Text
            .Add("@PartDetail", SqlDbType.VarChar).Value = txtPartDetail.Text
            .Add("@Frequency", SqlDbType.VarChar).Value = cboFrequency.Text
            .Add("@SampleSize", SqlDbType.VarChar).Value = cboSampleSize.Text
            .Add("@InspectionMethod", SqlDbType.VarChar).Value = cboInspection.Text
            .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
            .Add("@Specification", SqlDbType.VarChar).Value = txtPartSpec.Text
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            con.Close()
            MsgBox("Line data was not added, Please check to see That you entered valid data", MsgBoxStyle.OkOnly)
        End Try
        con.Close()

        ShowData()
    End Sub

    Private Sub AddHeader()
        Try
            updateOrInsertIntoQCInspectionHeaderTable()
        Catch ex As System.Exception
            sendErrorToDataBase("InspectionReport - AddHeader --Error trying ot insert/update into QCInspectionHeaderTable", "Inspection key #" + cboInspectionKey.Text, ex.ToString())
        End Try
    End Sub

    Private Sub ClearAll()
        cboFoxNumber.Text = ""
        cboInspection.Text = ""
        cboInspectionKey.Text = ""
        cboLineNumber.Text = ""

        cboInspectionKey.SelectedIndex = -1
        cboFoxNumber.SelectedIndex = -1
        cboLineNumber.SelectedIndex = -1
        cboInspection.SelectedIndex = -1
        cboMachineNumber.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboMachineNumber.Text) Then
            cboMachineNumber.Text = ""
        End If

        txtCustomer.Clear()
        txtHeaderComment.Clear()
        txtDescription.Clear()
        txtLotNumber.Clear()
        txtOperation.Clear()
        txtShift.Clear()
        txtOperator.Clear()
        txtRevisionLevel.Clear()
        txtLowSpec.Clear()
        txtHighSpec.Clear()
        txtPartDetail.Clear()
        txtPartNumber.Clear()
        txtPartSpec.Clear()
        cboBluePrint.SelectedIndex = -1
        cboFrequency.SelectedIndex = 0
        cboSampleSize.Text = 1
        txtLineComment.Clear()

        pnlBlueprintJournalEntries.Hide()
    End Sub

    Public Sub ClearVariables()
        FOXBluePrintNumber = ""
        OldInspectionKey = ""
        NewInspectionKey = ""
    End Sub

    Private Sub ClearLine()
        txtLowSpec.Clear()
        txtHighSpec.Clear()
        txtPartDetail.Clear()
        txtPartSpec.Clear()
        cboFrequency.Text = "Hourly"
        cboSampleSize.Text = 1
        cboInspection.SelectedIndex = -1
        txtLineComment.Clear()
    End Sub

    Private Sub cmdAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLine.Click
        If canAddLine() Then
            AddHeader()
            AddLine()
            ClearLine()
            ShowData()
            MessageBox.Show("Line added sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canAddLine() As Boolean
        If String.IsNullOrEmpty(cboInspectionKey.Text) Then
            MessageBox.Show("You must enter a Fox-Operation", "Enter a Fox-Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInspectionKey.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLowSpec.Text) And String.IsNullOrEmpty(txtHighSpec.Text) Then
            MessageBox.Show("You must specify a specification", "Enter a specification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLowSpec.Focus()
            Return False
        End If
        If IsNumeric(txtLowSpec.Text) And IsNumeric(txtHighSpec.Text) Then
            If Val(txtLowSpec.Text) > Val(txtHighSpec.Text) Then
                MessageBox.Show("Low spec must be the lower limit.", "Switch low and high spec", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLowSpec.SelectAll()
                txtLowSpec.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtPartDetail.Text) Then
            MessageBox.Show("You must enter a part detail", "Enter a part detail", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPartDetail.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboFrequency.Text) Then
            MessageBox.Show("You must specify a frequency", "Enter a frequency", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFrequency.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSampleSize.Text) Then
            MessageBox.Show("You must select a sample size", "Select a sample size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSampleSize.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboInspection.Text) Then
            MessageBox.Show("You must enter an inspection method", "Enter an inspection method", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInspection.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        If newRecordSaved = False Then
            Dim rslt As DialogResult = MessageBox.Show("New inspection report was not saved yet. Do you wish to save before clearing?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rslt = System.Windows.Forms.DialogResult.Yes Then
                cmdSave_Click(sender, e)
            End If
        End If
        isLoaded = False
        ClearVariables()
        ClearAll()
        LoadInspectionKey()
        ShowData()
        isLoaded = True
        If newRecordSaved = False Then
            newRecordSaved = True
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLineInputData.Click
        ClearLine()
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvInspectionReports.CellValueChanged
        If isLoaded Then

            Dim SampleSize, InspectionLineNumber As Integer
            Dim PartDetail, Frequency, InspectionMethod, LineComment As String
            Dim LowSpec, HighSpec As String

            Dim currentRow As Integer = dgvInspectionReports.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvInspectionReports.CurrentCell.ColumnIndex

            'UPDATE Line Table on changes in the datagrid and ensure no NULL values
            If IsDBNull(dgvInspectionReports.Rows(currentRow).Cells("LowSpec").Value) Then
                LowSpec = ""
            Else
                LowSpec = dgvInspectionReports.Rows(currentRow).Cells("LowSpec").Value
            End If
            If IsDBNull(dgvInspectionReports.Rows(currentRow).Cells("HighSpec").Value) Then
                HighSpec = ""
            Else
                HighSpec = dgvInspectionReports.Rows(currentRow).Cells("HighSpec").Value
            End If
            If IsDBNull(dgvInspectionReports.Rows(currentRow).Cells("PartDetail").Value) Then
                PartDetail = ""
            Else
                PartDetail = dgvInspectionReports.Rows(currentRow).Cells("PartDetail").Value
            End If
            If IsDBNull(dgvInspectionReports.Rows(currentRow).Cells("Frequency").Value) Then
                Frequency = "Hourly"
            Else
                Frequency = dgvInspectionReports.Rows(currentRow).Cells("Frequency").Value
            End If
            If IsDBNull(dgvInspectionReports.Rows(currentRow).Cells("LineComment").Value) Then
                LineComment = ""
            Else
                LineComment = dgvInspectionReports.Rows(currentRow).Cells("LineComment").Value
                If LineComment.Length > 100 Then
                    If MessageBox.Show("Line Comment is greater than what can be stored. Do you wish to truncate?", "Truncate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                        Exit Sub
                    End If
                    LineComment = LineComment.Substring(0, 100)
                End If
            End If
            If IsDBNull(dgvInspectionReports.Rows(currentRow).Cells("SampleSize").Value) Then
                SampleSize = 1
            ElseIf String.IsNullOrEmpty(dgvInspectionReports.Rows(currentRow).Cells("SampleSize").Value.ToString) Then
                SampleSize = 1
            Else
                SampleSize = dgvInspectionReports.Rows(currentRow).Cells("SampleSize").Value
            End If
            If IsDBNull(dgvInspectionReports.Rows(currentRow).Cells("InspectionMethod").Value) Then
                InspectionMethod = ""
            Else
                InspectionMethod = dgvInspectionReports.Rows(currentRow).Cells("InspectionMethod").Value
            End If

            InspectionLineNumber = dgvInspectionReports.Rows(currentRow).Cells("InspectionLineNumber").Value

            Try
                cmd = New SqlCommand("UPDATE QCInspectionLineTable SET LowSpec = @LowSpec, HighSpec = @HighSpec, PartDetail = @PartDetail, Frequency = @Frequency, SampleSize = @SampleSize, InspectionMethod = @InspectionMethod, LineComment = @LineComment WHERE InspectionKey = @InspectionKey AND InspectionLineNumber = @InspectionLineNumber;", con)

                With cmd.Parameters
                    .Add("@LowSpec", SqlDbType.VarChar).Value = LowSpec
                    .Add("@HighSpec", SqlDbType.VarChar).Value = HighSpec
                    .Add("@PartDetail", SqlDbType.VarChar).Value = PartDetail
                    .Add("@Frequency", SqlDbType.VarChar).Value = Frequency
                    .Add("@SampleSize", SqlDbType.VarChar).Value = SampleSize
                    .Add("@InspectionMethod", SqlDbType.VarChar).Value = InspectionMethod
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    .Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text
                    .Add("@InspectionLineNumber", SqlDbType.VarChar).Value = InspectionLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("InspectionReport - CellValueChanged --Error updating data that was changed on line #" + currentRow.ToString() + " in the datagrid", "InspectionKey #" + cboInspectionKey.Text, ex.ToString())
                MessageBox.Show("There was a problem trying to save the change made in the datagrid. Contact system admin", "Error saving change", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            ShowData()
            dgvInspectionReports.CurrentCell = dgvInspectionReports.Rows(currentRow).Cells(currentColumn)
        End If
    End Sub

    Private Sub ShowHeaderData()
        Dim FOXNumber As Integer = 0
        Dim BlueprintNumber, PartNumber, Customer, Description, Operation, HeaderComment, Shift, MachineNumber, MachineOperator, RevisionLevel As String

        Dim FOXCommand As New SqlCommand("SELECT QCInspectionHeaderTable.FoxNumber, QCInspectionHeaderTable.BlueprintNumber, QCInspectionHeaderTable.PartNumber, QCInspectionHeaderTable.Customer, QCInspectionHeaderTable.Description, QCInspectionHeaderTable.Operation, QCInspectionHeaderTable.HeaderComment, QCInspectionHeaderTable.Shift, QCInspectionHeaderTable.MachineNumber, QCInspectionHeaderTable.Operator, CASE WHEN FOXTable.BlueprintRevision is null OR FOXTable.BlueprintRevision = '' then QCInspectionHeaderTable.RevisionLevel ELSE FOXTable.BlueprintRevision END AS RevisionLevel, LotNumber FROM QCInspectionHeaderTable LEFT OUTER JOIN FOXTable ON QCInspectionHeaderTable.FOXNumber = FOXTable.FOXNumber WHERE InspectionKey = @InspectionKey;", con)
        FOXCommand.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = FOXCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("FoxNumber")) Then
                FOXNumber = reader.Item("FoxNumber")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                BlueprintNumber = FOXBluePrintNumber
            Else
                BlueprintNumber = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = FOXPartNumber
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("Customer")) Then
                Customer = ""
            Else
                Customer = reader.Item("Customer")
            End If
            If IsDBNull(reader.Item("Description")) Then
                Description = ""
            Else
                Description = reader.Item("Description")
            End If
            If IsDBNull(reader.Item("Operation")) Then
                Operation = ""
            Else
                Operation = reader.Item("Operation")
            End If
            If IsDBNull(reader.Item("HeaderComment")) Then
                HeaderComment = ""
            Else
                HeaderComment = reader.Item("HeaderComment")
            End If
            If IsDBNull(reader.Item("Shift")) Then
                Shift = ""
            Else
                Shift = reader.Item("Shift")
            End If
            If IsDBNull(reader.Item("MachineNumber")) Then
                MachineNumber = ""
            Else
                MachineNumber = reader.Item("MachineNumber")
            End If
            If IsDBNull(reader.Item("Operator")) Then
                MachineOperator = ""
            Else
                MachineOperator = reader.Item("Operator")
            End If
            If IsDBNull(reader.Item("RevisionLevel")) Then
                RevisionLevel = ""
            Else
                RevisionLevel = reader.Item("RevisionLevel")
            End If
            If IsDBNull(reader.Item("LotNumber")) Then
                txtLotNumber.Text = ""
            Else
                txtLotNumber.Text = reader.Item("LotNumber")
            End If
        Else
            BlueprintNumber = FOXBluePrintNumber
            PartNumber = FOXPartNumber
            Customer = ""
            Description = ""
            Operation = ""
            HeaderComment = ""
            Shift = ""
            MachineNumber = ""
            MachineOperator = ""
            RevisionLevel = ""
            txtLotNumber.Text = ""
        End If
        reader.Close()
        con.Close()

        cboFoxNumber.Text = FOXNumber.ToString
        cboBluePrint.Text = BlueprintNumber
        txtPartNumber.Text = PartNumber
        txtCustomer.Text = Customer
        txtDescription.Text = Description
        txtOperation.Text = Operation
        txtHeaderComment.Text = HeaderComment
        txtShift.Text = Shift
        cboMachineNumber.Text = MachineNumber
        txtOperator.Text = MachineOperator
        txtRevisionLevel.Text = RevisionLevel
    End Sub

    Public Sub LoadFOXData()
        Dim FOXPartNumberString As String = "SELECT PartNumber, ShortDescription, BlueprintNumber, BlueprintRevision FROM (SELECT PartNumber, BlueprintNumber, BlueprintRevision, DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber) as FOXTable LEFT OUTER JOIN ItemList ON FOXtable.PartNumber = ItemList.ItemID AND FOXTable.DivisionID = ItemList.DivisionID;"
        Dim FOXPartNumberCommand As New SqlCommand(FOXPartNumberString, con)
        FOXPartNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFoxNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = FOXPartNumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                FOXPartNumber = ""
            Else
                FOXPartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                txtDescription.Text = ""
            Else
                txtDescription.Text = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                FOXBluePrintNumber = ""
            Else
                FOXBluePrintNumber = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("BlueprintRevision")) Then
                txtRevisionLevel.Text = ""
            Else
                txtRevisionLevel.Text = reader.Item("BlueprintRevision").ToString()
            End If
        Else
            FOXPartNumber = ""
            FOXBluePrintNumber = ""
            txtDescription.Text = ""
            txtRevisionLevel.Text = ""
        End If
        reader.Close()
        con.Close()

        txtPartNumber.Text = FOXPartNumber
        cboBluePrint.Text = FOXBluePrintNumber
    End Sub

    Private Sub DeleteRow()
        If canDeleteRow() Then
            ''Deletes the line form the line table
            ''Checks to see if the date that was selected is less than or equal to 5 days, if so will update the line number first piece entry to over 100 for the line number so it wont be pulled
            cmd = New SqlCommand("DELETE FROM QCInspectionLineTable WHERE InspectionKey = @InspectionKey AND InspectionLineNumber = @InspectionLineNumber;" _
                                 + " UPDATE QCInspectionLineTable SET InspectionLineNumber = InspectionLineNumber - 1 WHERE InspectionKey = @InspectionKey AND InspectionLineNumber >= @InspectionLineNumber;" _
                                 + " DECLARE @MAXDate datetime2 = (SELECT isnull(MAX(InspectionDateTime), DATEADD(day, -6, CURRENT_TIMESTAMP)) FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey)" _
                                 + " IF (DATEDIFF(d, @MAXDate, CURRENT_TIMESTAMP) <= 5) BEGIN" _
                                 + " UPDATE QCInspectionFirstPieceTable SET InspectionLineKey = InspectionLineKey + 1000 WHERE InspectionKey = @InspectionKey AND InspectionLineKey = @InspectionLineNumber" _
                                 + " UPDATE QCInspectionFirstPieceTable SET InspectionLineKey = InspectionLineKey - 1 WHERE InspectionKey = @InspectionKey AND InspectionLineKey >= @InspectionLineNumber AND InspectionLineKey < 1000 AND InspectionDateTime = @MAXDate END", con)

            With cmd.Parameters
                .Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text
                .Add("@InspectionLineNumber", SqlDbType.VarChar).Value = cboLineNumber.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            con.Close()
        End If
    End Sub

    Private Function canDeleteRow() As Boolean
        If String.IsNullOrEmpty(cboInspectionKey.Text) Then
            MessageBox.Show("You must enter a FOX-Operation", "Enter a FOX-Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInspectionKey.Focus()
            Return False
        End If
        If cboLineNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a line to delete", "Select a line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLineNumber.Focus()
            Return False
        End If
        If MsgBox("Do you wish to delete the row?", MsgBoxStyle.YesNo) <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cboFoxNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFoxNumber.SelectedIndexChanged
        If isLoaded Then
            If canSearchFoxes() Then
                FoxesDT = New Data.DataTable("QCInspectionHeaderTable")
                cmd = New SqlCommand("SELECT InspectionKey, InspectionDate, FOXNumber, Description, RevisionLevel FROM QCInspectionHeaderTable WHERE FOXNumber = @FOXNumber ORDER BY InspectionDate DESC, RevisionLevel DESC;", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFoxNumber.Text
                Dim adap As New SqlDataAdapter(cmd)
                If con.State = ConnectionState.Closed Then con.Open()
                adap.Fill(FoxesDT)
                con.Close()
                If FoxesDT.Rows.Count > 1 Then
                    selectionForm()
                Else
                    If FoxesDT.Rows.Count = 1 Then
                        cboInspectionKey.Text = FoxesDT.Rows(0).Item("InspectionKey")
                    End If
                End If
            ElseIf cboFoxNumber.SelectedIndex <> -1 Then
                LoadFOXData()
            End If
        End If
    End Sub

    Private Function canSearchFoxes() As Boolean
        If cboBluePrint.SelectedIndex <> -1 Then
            Return False
        End If
        If cboInspectionKey.SelectedIndex <> -1 Then
            Return False
        End If
        If Not String.IsNullOrEmpty(cboInspectionKey.Text) Then
            Return False
        End If
        If cboFoxNumber.SelectedIndex = -1 Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If newRecordSaved Then
            DeleteRow()
            ''ReorderLines()
            ShowData()
        Else
            MessageBox.Show("You must save the new inspection report before making line deletions", "Save inspection report first", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmdSave.Focus()
        End If
    End Sub

    Private Sub cboInspectionKey_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInspectionKey.SelectedIndexChanged
        If isLoaded Then
            ShowData()
            ShowHeaderData()
        End If
    End Sub

    Private Sub GetInspectionKey()
        Dim Operation, FoxNumber, InspectionKey As String

        FoxNumber = cboFoxNumber.Text
        Operation = txtOperation.Text
        InspectionKey = FoxNumber + "-" + Operation

        cboInspectionKey.Text = InspectionKey
        NewInspectionKey = InspectionKey
    End Sub

    Private Sub Print()
        If canPrint() Then
            Dim NewPrintQCInspectionReport As New PrintQCInspectionReport(cboInspectionKey.Text)
            NewPrintQCInspectionReport.ShowDialog()
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboInspectionKey.Text) Then
            MessageBox.Show("You must enter a FOX-Operation", "Enter a FOX-Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInspectionKey.Focus()
            Return False
        End If
        cmd = New SqlCommand("DECLARE @MAXDate datetime2 = (SELECT isnull(MAX(InspectionDateTime), DATEADD(day, -6, CURRENT_TIMESTAMP)) FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey);", con)
        cmd.CommandText += " IF (DATEDIFF(d, @MAXDate, CURRENT_TIMESTAMP) <= 5)"
        cmd.CommandText += " SELECT 1"
        cmd.CommandText += " ELSE SELECT 0"
        cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()
        If Not IsDBNull(obj) AndAlso obj IsNot Nothing Then
            If CType(obj, Integer) = 0 Then
                If MessageBox.Show("There has been no first piece inspection entered, do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                    cmdFirstInspectionEntry.Focus()
                    Return False
                End If
            End If
        Else
            If MessageBox.Show("There has been no first piece inspection entered, do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                cmdFirstInspectionEntry.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub GetNewInspectionKey()
        Dim Operation, FoxNumber, InspectionKey As String

        FoxNumber = cboFoxNumber.Text
        Operation = txtOperation.Text
        InspectionKey = FoxNumber + "-" + Operation
        cboInspectionKey.Text = InspectionKey
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            saveRoutine()
            MessageBox.Show("Inspection report has been created sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboInspectionKey.Text) Then
            MessageBox.Show("You must enter a FOX-Operation", "Enter a FOX-Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInspectionKey.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboFoxNumber.Text) AndAlso cboInspectionKey.SelectedIndex <> -1 Then
            MessageBox.Show("You must enter a FOX number", "Enter a FOX number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBluePrint.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboBluePrint.Text) AndAlso cboInspectionKey.SelectedIndex <> -1 Then
            MessageBox.Show("You must enter a blueprint number", "Enter a blueprint number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBluePrint.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtOperation.Text) AndAlso cboInspectionKey.SelectedIndex <> -1 Then
            MessageBox.Show("You must enter an operation", "Enter an operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOperation.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPartNumber.Text) AndAlso cboInspectionKey.SelectedIndex <> -1 Then
            cmd = New SqlCommand("SELECT PartNumber FROM FOXTable WHERE FOXNumber = @FOXnumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFoxNumber.Text
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("PartNumber")) Then
                    reader.Close()
                    con.Close()
                    MessageBox.Show("Unable to locate part number. You must enter a part number", "Enter a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtPartNumber.Focus()
                    Return False
                Else
                    txtPartNumber.Text = reader.Item("PartNumber")
                End If
            Else
                reader.Close()
                con.Close()
                MessageBox.Show("Unable to locate the part number. You must enter a part number", "Enter a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPartNumber.Focus()
                Return False
            End If
            reader.Close()
            con.Close()
        End If
        If Not String.IsNullOrEmpty(cboMachineNumber.Text) Then
            If cboMachineNumber.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid machine number. Make sure to use 3 digits for all machine numbers", "Enter a valid machine ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMachineNumber.SelectAll()
                cboMachineNumber.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub saveRoutine()
        ''saved the header table portion of the inspection report
        Try
            updateOrInsertIntoQCInspectionHeaderTable()
        Catch ex As System.Exception
            sendErrorToDataBase("InspectionReport - cmdSave_Click --Error trying to insert/update into QCInspectionHeaderTable", "Inspection #" + cboInspectionKey.Text, ex.ToString())
            MessageBox.Show("There was a problem trying to save the Inspection Report", "Unable to save inspection report", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try

        ''checks to see if the lines exsist in the line table
        cmd = New SqlCommand("SELECT * FROM QCInspectionLineTable WHERE InspectionKey = @InspectionKey;", con)
        cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        ''if lines don't exsist then this will insert them into the line table
        If reader.HasRows = False Then
            reader.Close()
            con.Close()

            'Initialize Line Count
            LineInspectionLineNumber = 1

            'Routine to write lines to a new record
            For Each row As DataGridViewRow In dgvInspectionReports.Rows
                If IsDBNull(row.Cells("LowSpec").Value) Then
                    LineLowSpec = ""
                Else
                    LineLowSpec = row.Cells("LowSpec").Value
                End If
                If IsDBNull(row.Cells("HighSpec").Value) Then
                    LineHighSpec = ""
                Else
                    LineHighSpec = row.Cells("HighSpec").Value
                End If
                If IsDBNull(row.Cells("PartDetail").Value) Then
                    LinePartDetail = ""
                Else
                    LinePartDetail = row.Cells("PartDetail").Value
                End If
                If IsDBNull(row.Cells("Frequency").Value) Then
                    LineFrequency = ""
                Else
                    LineFrequency = row.Cells("Frequency").Value
                End If
                If IsDBNull(row.Cells("SampleSize").Value) Then
                    LineSampleSize = ""
                Else
                    LineSampleSize = row.Cells("SampleSize").Value
                End If
                If IsDBNull(row.Cells("InspectionMethod").Value) Then
                    LineInspectionMethod = ""
                Else
                    LineInspectionMethod = row.Cells("InspectionMethod").Value
                End If
                If IsDBNull(row.Cells("LineComment").Value) Then
                    LineComment = ""
                Else
                    LineComment = row.Cells("LineComment").Value
                End If
                'Write to Line Table for new entry - all lines
                Try
                    cmd = New SqlCommand("Insert Into QCInspectionLineTable (InspectionKey, InspectionLineNumber, LowSpec, HighSpec, PartDetail, Frequency, SampleSize, InspectionMethod, LineComment) values(@InspectionKey, @InspectionLineNumber, @LowSpec, @HighSpec, @PartDetail, @Frequency, @SampleSize, @InspectionMethod, @LineComment);", con)

                    With cmd.Parameters
                        .Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text
                        .Add("@InspectionLineNumber", SqlDbType.VarChar).Value = LineInspectionLineNumber
                        .Add("@LowSpec", SqlDbType.VarChar).Value = LineLowSpec
                        .Add("@HighSpec", SqlDbType.VarChar).Value = LineHighSpec
                        .Add("@PartDetail", SqlDbType.VarChar).Value = LinePartDetail
                        .Add("@Frequency", SqlDbType.VarChar).Value = LineFrequency
                        .Add("@SampleSize", SqlDbType.VarChar).Value = LineSampleSize
                        .Add("@InspectionMethod", SqlDbType.VarChar).Value = LineInspectionMethod
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    sendErrorToDataBase("InspectionReport - cmdSaveRoutine --Error trying to save new lines", "Inspection key #" + cboInspectionKey.Text, ex.ToString())
                    MessageBox.Show("There is was an error saving new FOX-Operation lines. Contact system admin", "Unable ot complete save", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                LineInspectionLineNumber = LineInspectionLineNumber + 1
            Next
            ''reloads the inspection keys
            isLoaded = False
            Dim insp As String = cboInspectionKey.Text
            LoadInspectionKey()
            cboInspectionKey.Text = insp
            isLoaded = True
        Else
            reader.Close()
            con.Close()
        End If
        If newRecordSaved = False Then
            newRecordSaved = True
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintToolStripMenuItem.Click
        If canSave() Then
            saveRoutine()
            Print()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If newRecordSaved = False Then
            Dim rslt As DialogResult = MessageBox.Show("New inspection report was not saved yet. Do you wish to save before exiting?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rslt = System.Windows.Forms.DialogResult.Yes Then
                cmdSave_Click(sender, e)
            End If
        End If
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub DeleteReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteReportToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If CanDeleteReport() Then
            Try
                ''deletes form the header table
                cmd = New SqlCommand("DELETE FROM QCInspectionHeaderTable WHERE InspectionKey = @InspectionKey;", con)

                With cmd.Parameters
                    .Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                ''deletes the lines form the line table
                cmd = New SqlCommand("DELETE FROM QCInspectionLineTable WHERE InspectionKey = @InspectionKey;", con)

                With cmd.Parameters
                    .Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                isLoaded = False
                ClearVariables()
                ClearAll()
                LoadInspectionKey()
                ShowData()
                isLoaded = True
                MessageBox.Show("Report has been deleted sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Exception
                sendErrorToDataBase("InspectionReport - cmdDelete_Click --Error trying to delete an inspection", "Inspection key #" + cboInspectionKey.Text, ex.ToString())
                MsgBox("Data cannot be deleted - check for valid Inspection ID.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Function CanDeleteReport() As Boolean
        If String.IsNullOrEmpty(cboInspectionKey.Text) Then
            MsgBox("You must have a valid Inspection ID selected.", MsgBoxStyle.OkOnly)
            cboInspectionKey.SelectAll()
            cboInspectionKey.Focus()
            Return False
        End If
        If cboInspectionKey.SelectedIndex = -1 Then
            MsgBox("You must have a valid Inspection ID selected.", MsgBoxStyle.OkOnly)
            cboInspectionKey.Focus()
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to delete the inspection report?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cboBluePrint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBluePrint.SelectedIndexChanged
        If isLoaded Then
            If canSearchBluePrints() Then
                FoxesDT = New Data.DataTable("QCInspectionHeaderTable")
                cmd = New SqlCommand("SELECT InspectionKey, InspectionDate, FOXNumber, Description, RevisionLevel FROM QCInspectionHeaderTable WHERE BlueprintNumber = @BlueprintNumber ORDER BY InspectionDate DESC, RevisionLevel DESC;", con)
                cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBluePrint.Text
                Dim adap As New SqlDataAdapter(cmd)
                If con.State = ConnectionState.Closed Then con.Open()
                adap.Fill(FoxesDT)
                con.Close()
                If FoxesDT.Rows.Count > 1 Then
                    selectionForm()
                Else
                    If FoxesDT.Rows.Count = 1 Then
                        cboInspectionKey.Text = FoxesDT.Rows(0).Item("InspectionKey")
                    End If
                End If
            End If
            CheckBlueprintJournalEntries()
        End If
    End Sub

    Private Sub selectionForm()
        Dim FoxOpSelection As New SelectFOXFromBlueprint(FoxesDT)
        If FoxOpSelection.ShowDialog() = System.Windows.Forms.DialogResult.Yes Then
            cboInspectionKey.Text = FoxOpSelection.dgvFoundFOXs.Rows(FoxOpSelection.dgvFoundFOXs.CurrentCell.RowIndex).Cells("InspectionKey").Value
        End If
    End Sub

    Private Function canSearchBluePrints() As Boolean
        If Not String.IsNullOrEmpty(cboFoxNumber.Text) Then
            Return False
        End If
        If cboBluePrint.SelectedIndex = -1 Then
            Return False
        End If
        If cboInspectionKey.SelectedIndex <> -1 Then
            Return False
        End If
        Return True
    End Function

    Private Sub CheckBlueprintJournalEntries()
        cmd = New SqlCommand("SELECT SUM(EntryCount) FROM (SELECT COUNT(EntryTitle) as EntryCount FROM BlueprintJournal WHERE BlueprintNumber = @BlueprintNumber UNION SELECT COUNT(QCTransactionNumber) FROM QCHoldAdjustment WHERE LotNumber in (SELECT LotNumber FROM LotNumber WHERE BlueprintNumber = @BlueprintNumber) OR FOXNumber in (SELEct FOXNumber FROM FOXTable where BlueprintNumber = @BlueprintNumber)) as tmp", con)
        cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBluePrint.Text
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            pnlBlueprintJournalEntries.Show()
        Else
            pnlBlueprintJournalEntries.Hide()
        End If
        If con.State = ConnectionState.Open Then con.Close()
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

    Private Sub updateOrInsertIntoQCInspectionHeaderTable()
        Dim GetDivisionByFOX As String = ""

        If Val(cboFoxNumber.Text) < 10000 Then
            GetDivisionByFOX = "TWD"
        Else
            GetDivisionByFOX = "TFP"
        End If

        cmd = New SqlCommand("if exists(SELECT InspectionKey FROM QCInspectionHeaderTable WHERE InspectionKey = @InspectionKey) UPDATE QCInspectionHeaderTable SET PartNumber = @PartNumber, FoxNumber = @FoxNumber, BluePrintNumber = @BlueprintNumber, Customer = @Customer, Description = @Description, Operation = @Operation,  InspectionDate = @InspectionDate, HeaderComment = @HeaderComment, Shift = @Shift, MachineNumber = @MachineNumber, Operator = @Operator, RevisionLevel = @RevisionLevel, LotNumber = @LotNumber, DivisionID = @DivisionID, Inspector = @Inspector WHERE InspectionKey = @InspectionKey ELSE Insert Into QCInspectionHeaderTable (InspectionKey, BlueprintNumber, PartNumber, FoxNumber, Customer, Description, Operation,  InspectionDate, HeaderComment, Shift, MachineNumber, Operator, RevisionLevel, LotNumber, DivisionID, Inspector)values(@InspectionKey, @BlueprintNumber, @PartNumber, @FoxNumber, @Customer, @Description, @Operation,  @InspectionDate, @HeaderComment, @Shift, @MachineNumber, @Operator, @RevisionLevel, @LotNumber, @DivisionID, @Inspector);", con)

        With cmd.Parameters
            .Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text
            .Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFoxNumber.Text)
            .Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBluePrint.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
            .Add("@Customer", SqlDbType.VarChar).Value = txtCustomer.Text
            .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
            .Add("@Operation", SqlDbType.VarChar).Value = txtOperation.Text
            .Add("@InspectionDate", SqlDbType.Date).Value = Today()
            .Add("@HeaderComment", SqlDbType.VarChar).Value = txtHeaderComment.Text
            .Add("@Shift", SqlDbType.VarChar).Value = txtShift.Text
            .Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
            .Add("@Operator", SqlDbType.VarChar).Value = txtOperator.Text
            .Add("@RevisionLevel", SqlDbType.VarChar).Value = txtRevisionLevel.Text
            .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = GetDivisionByFOX
            .Add("@Inspector", SqlDbType.VarChar).Value = EmployeeLoginName
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cboInspectionKey_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInspectionKey.Leave
        If isLoaded Then
            If cboInspectionKey.SelectedIndex = -1 And String.IsNullOrEmpty(cboInspectionKey.Text) = False Then
                newRecordSaved = False
            Else
                newRecordSaved = True
            End If
        End If
    End Sub

    Private Sub dgvInspectionReports_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvInspectionReports.CellBeginEdit
        If newRecordSaved = False Then
            MessageBox.Show("You must save the new inspection report before trying to make changes in the datagrid", "Record needs saved", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmdSave.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmdBlankLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBlankLine.Click
        If cboInspectionKey.SelectedIndex <> -1 And String.IsNullOrEmpty(cboInspectionKey.Text) = False Then
            AddHeader()
            AddLine()
            MessageBox.Show("Blank line added sucessfully", "Blank line added", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("You must enter a FOX-Operation in order to add a blank line.", "Select a FOX-Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInspectionKey.Focus()
        End If
    End Sub

    Private Sub cmdFirstInspectionEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirstInspectionEntry.Click
        If canSave() AndAlso canEnterFirstEntry() Then
            saveRoutine()
            Dim newInspectionReportFirstInspectionEntry As New InspectionReportFirstInspectionEntry(cboInspectionKey.Text, txtLotNumber.Text, txtRevisionLevel.Text)
            newInspectionReportFirstInspectionEntry.ShowDialog()
        End If
    End Sub

    Private Function canEnterFirstEntry() As Boolean
        If String.IsNullOrEmpty(cboFoxNumber.Text) Then
            MessageBox.Show("You must select a FOX Number", "Selecta FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFoxNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtOperation.Text) Then
            MessageBox.Show("You must enter an Operation", "Enter an Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOperation.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdViewEntries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewEntries.Click
        If Not String.IsNullOrEmpty(cboBluePrint.Text) Then
            BlueprintJournalForm = New BlueprintJournal(cboBluePrint.Text)
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

    Private Sub InspectionReport_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If BlueprintJournalForm IsNot Nothing Then
            BlueprintJournalForm.Dispose()
        End If
    End Sub

    Private Sub InspectionReport_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If BlueprintJournalForm IsNot Nothing Then
            If BlueprintJournalForm.Visible Then
                BlueprintJournalForm.BringToFront()
            Else
                Me.BringToFront()
            End If
        Else
            Me.BringToFront()
        End If
    End Sub

    Private Sub dgvInspectionReports_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInspectionReports.CellEnter
        If e.ColumnIndex = dgvInspectionReports.Columns("Frequency").Index AndAlso e.RowIndex > -1 Then
            dgvInspectionReports.BeginEdit(True)
        End If
    End Sub

    Private Sub dgvInspectionReports_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvInspectionReports.MouseMove
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If dragBoxFromMouseDown <> System.Drawing.Rectangle.Empty AndAlso (Not dragBoxFromMouseDown.Contains(e.X, e.Y)) Then
                'Sets drop icon
                Dim dropEffect As DragDropEffects = dgvInspectionReports.DoDragDrop(dgvInspectionReports.Rows(rowIndexFromMouseDown), DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub dgvInspectionReports_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvInspectionReports.MouseDown
        If rowIndexFromMouseDown <> -1 Then
            dgvInspectionReports.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = dgvInspectionReports.DefaultCellStyle.BackColor
        End If
        rowIndexFromMouseDown = dgvInspectionReports.HitTest(e.X, e.Y).RowIndex
        If rowIndexFromMouseDown <> -1 Then
            dgvInspectionReports.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = Color.LightGray
            ' Remember the point where the mouse down occurred. The DragSize indicates the size that the mouse can move before a drag event should be started.
            Dim dragSize As Size = SystemInformation.DragSize
            ' Create a rectangle using the DragSize, with the mouse position being at the center of the rectangle.
            dragBoxFromMouseDown = New System.Drawing.Rectangle(New System.Drawing.Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
        Else
            ' Reset the rectangle if the mouse is not over an item in the ListBox.
            dragBoxFromMouseDown = System.Drawing.Rectangle.Empty
        End If
    End Sub

    Private Sub dgvInspectionReports_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvInspectionReports.DragOver
        e.Effect = DragDropEffects.Move
        If dragBoxFromMouseDown <> System.Drawing.Rectangle.Empty Then
            Dim clientPoint As System.Drawing.Point = dgvInspectionReports.PointToClient(New System.Drawing.Point(e.X, e.Y))
            Dim ht As DataGridView.HitTestInfo = dgvInspectionReports.HitTest(clientPoint.X, clientPoint.Y)
            If ht.RowIndex >= 0 Then
                dgvInspectionReports.ClearSelection()
                dgvInspectionReports.Rows(ht.RowIndex).Selected = True
                dgvInspectionReports.CurrentCell = dgvInspectionReports.Rows(ht.RowIndex).Cells("LowSpec")
            Else
                dgvInspectionReports.ClearSelection()
            End If
        End If
    End Sub

    Private Sub dgvInspectionReports_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvInspectionReports.DragDrop
        ' The mouse locations are relative to the screen, so they must be converted to client coordinates.
        Dim clientPoint As System.Drawing.Point = dgvInspectionReports.PointToClient(New System.Drawing.Point(e.X, e.Y))
        ' Get the row index of the item the mouse is below.
        rowIndexOfItemUnderMouseToDrop = dgvInspectionReports.HitTest(clientPoint.X, clientPoint.Y).RowIndex

        ' If the drag operation was a move then remove and insert the row.
        If e.Effect = DragDropEffects.Move Then
            If rowIndexOfItemUnderMouseToDrop < rowIndexFromMouseDown AndAlso rowIndexOfItemUnderMouseToDrop <> -1 Then
                cmd = New SqlCommand("UPDATE QCInspectionLineTable SET InspectionLineNumber = InspectionLineNumber + 100 WHERE InspectionKey = @InspectionKey AND InspectionLineNumber = @FromLineNumber;" _
                                     + " UPDATE QCInspectionLineTable SET InspectionLineNumber = InspectionLineNumber + 1 WHERE InspectionKey = @InspectionKey AND InspectionLineNumber BETWEEN @DropLineNumber AND (@FromLineNumber - 1);" _
                                     + " UPDATE QCInspectionLineTable SET InspectionLineNumber = @DropLineNumber WHERE InspectionKey = @InspectionKey AND InspectionLineNumber = @FromLineNumber + 100;" _
                                     + " DECLARE @MAXDate datetime2 = (SELECT isnull(MAX(InspectionDateTime), DATEADD(day, -6, CURRENT_TIMESTAMP)) FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey);" _
                                     + " IF (DATEDIFF(d, @MAXDate, CURRENT_TIMESTAMP) <= 5) BEGIN" _
                                     + " UPDATE QCInspectionFirstPieceTable SET InspectionLineKey = InspectionLineKey + 100 WHERE InspectionKey = @InspectionKey AND InspectionLineKey = @FromLineNumber AND InspectionDateTime = @MAXDate;" _
                                     + " UPDATE QCInspectionFirstPieceTable SET InspectionLineKey = InspectionLineKey + 1 WHERE InspectionKey = @InspectionKey AND InspectionLineKey BETWEEN @DropLineNumber AND (@FromLineNumber - 1) AND InspectionDateTime = @MAXDate;" _
                                     + " UPDATE QCInspectionFirstPieceTable SET InspectionLineKey = @DropLineNumber WHERE InspectionKey = @InspectionKey AND InspectionLineKey = @FromLineNumber + 100 AND InspectionDateTime = @MAXDate; END", con)
                cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text
                cmd.Parameters.Add("@DropLineNumber", SqlDbType.Int).Value = dgvInspectionReports.Rows(rowIndexOfItemUnderMouseToDrop).Cells("InspectionLineNumber").Value
                cmd.Parameters.Add("@FromLineNumber", SqlDbType.Int).Value = dgvInspectionReports.Rows(rowIndexFromMouseDown).Cells("InspectionLineNumber").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As System.Exception
                    sendErrorToDataBase("InspectionReport - dgvInspectionReports_DragDrop -- Error updating line & first piece table with new order", "Inspection Key #" + cboInspectionKey.Text, ex.ToString)
                    MessageBox.Show("There was an issue re-ordering the rows. Try again and if issue persists contact system admin.", "Unable to reorder", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
                con.Close()
            ElseIf rowIndexOfItemUnderMouseToDrop <> -1 AndAlso rowIndexOfItemUnderMouseToDrop <> rowIndexFromMouseDown Then
                cmd = New SqlCommand("UPDATE QCInspectionLineTable SET InspectionLineNumber = InspectionLineNumber + 100 WHERE InspectionKey = @InspectionKey AND InspectionLineNumber = @FromLineNumber;" _
                                     + " UPDATE QCInspectionLineTable SET InspectionLineNumber = InspectionLineNumber - 1 WHERE InspectionKey = @InspectionKey AND InspectionLineNumber BETWEEN (@FromLineNumber + 1) AND @DropLineNumber;" _
                                     + " UPDATE QCInspectionLineTable SET InspectionLineNumber = @DropLineNumber WHERE InspectionKey = @InspectionKey AND InspectionLineNumber = @FromLineNumber + 100;" _
                                     + " DECLARE @MAXDate datetime2 = (SELECT isnull(MAX(InspectionDateTime), DATEADD(day, -6, CURRENT_TIMESTAMP)) FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey);" _
                                     + " IF (DATEDIFF(d, @MAXDate, CURRENT_TIMESTAMP) <= 5) BEGIN" _
                                     + " UPDATE QCInspectionFirstPieceTable SET InspectionLineKey = InspectionLineKey + 100 WHERE InspectionKey = @InspectionKey AND InspectionLineKey = @FromLineNumber  AND InspectionDateTime = @MAXDate;" _
                                     + " UPDATE QCInspectionFirstPieceTable SET InspectionLineKey = InspectionLineKey - 1 WHERE InspectionKey = @InspectionKey AND InspectionLineKey BETWEEN (@FromLineNumber + 1) AND @DropLineNumber  AND InspectionDateTime = @MAXDate;" _
                                     + " UPDATE QCInspectionFirstPieceTable SET InspectionLineKey = @DropLineNumber WHERE InspectionKey = @InspectionKey AND InspectionLineKey = @FromLineNumber + 100  AND InspectionDateTime = @MAXDate; END", con)
                cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = cboInspectionKey.Text
                cmd.Parameters.Add("@DropLineNumber", SqlDbType.Int).Value = dgvInspectionReports.Rows(rowIndexOfItemUnderMouseToDrop).Cells("InspectionLineNumber").Value
                cmd.Parameters.Add("@FromLineNumber", SqlDbType.Int).Value = dgvInspectionReports.Rows(rowIndexFromMouseDown).Cells("InspectionLineNumber").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As System.Exception
                    sendErrorToDataBase("InspectionReport - dgvInspectionReports_DragDrop -- Error updating line & first piece table with new order", "Inspection Key #" + cboInspectionKey.Text, ex.ToString)
                    MessageBox.Show("There was an issue re-ordering the rows. Try again and if issue persists contact system admin.", "Unable to reorder", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
                con.Close()
            End If
            dgvInspectionReports.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = dgvInspectionReports.DefaultCellStyle.BackColor
            rowIndexFromMouseDown = -1
            rowIndexFromMouseDown = -1
            dragBoxFromMouseDown = System.Drawing.Rectangle.Empty

            ShowData()
        Else
            dgvInspectionReports.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = dgvInspectionReports.DefaultCellStyle.BackColor
        End If
    End Sub

    Private Sub InspectionReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class