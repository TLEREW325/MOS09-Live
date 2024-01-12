Imports System.Math
Imports System.Data.SqlClient

Public Class SteelWireYardEntry
    Inherits System.Windows.Forms.Form

    Dim HeatNumber, Carbon, SteelSize, Description, CoilID, RMID, Comment, reference As String
    Dim ReturnWeight, DeleteNumber As Integer
    Dim Weight As Double = 0
    Dim GetRMID As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    ''locks some methods from running until fomr is loaded
    Dim isloaded As Boolean = False
    Dim cleared As Boolean = False

    Dim FocusedField As New usefulFunctions.FocusedItem()
    Dim wasDeleted As Boolean = False
    Dim notFinished As Boolean = False

    Dim totalScanTime As Integer
    Dim barcodeScanner As Boolean = False
    ''********************

    Private Sub SteelWireYardRemoval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCoilNumberData()
        LoadCarbon()
        LoadSteelSize()
        LoadHeat()
        isloaded = True
    End Sub

    Public Sub LoadCoilNumberData()
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status = 'WIP';", con)
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "CharterSteelCoilIdentification")
        con.Close()
    End Sub

    Private Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable;", con)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "RawMaterialsTable")
        con.Close()

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = ds.Tables("RawMaterialsTable")
        cboCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT(SteelSize) FROM RawMaterialsTable;", con)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        con.Close()

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub LoadHeat()
        cmd = New SqlCommand("SELECT DISTINCT(HeatNumber) FROM CharterSteelCoilIdentification;", con)
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "CharterSteelCoilIdentification")
        con.Close()

        cboHeatNumber.DisplayMember = "HeatNumber"
        cboHeatNumber.DataSource = ds3.Tables("CharterSteelCoilIdentification")
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub ClearData()

        txtCoilWeight.Refresh()
        txtCoilID.Clear()

        cboCarbon.SelectedIndex = -1
        If String.IsNullOrEmpty(cboCarbon.Text) = False Then
            cboCarbon.Text = ""
        End If
        cboSteelSize.SelectedIndex = -1
        If String.IsNullOrEmpty(cboSteelSize.Text) = False Then
            cboSteelSize.Text = ""
        End If
        cboHeatNumber.SelectedIndex = -1
        If String.IsNullOrEmpty(cboHeatNumber.Text) = False Then
            cboHeatNumber.Text = ""
        End If
        barcodeScanner = False
        totalScanTime = 0
        txtCoilDescription.Text = ""
        txtCoilWeight.Clear()
        txtLocation.Clear()
        txtInventoryID.Clear()
        txtCoilID.Focus()
    End Sub

    Public Sub LoadCoilInfo()
        Dim Weight As Double = 0
        'Extract data from Charter Steel Table
        Dim HeatNumberCommand As New SqlCommand("", con)
        If txtCoilID.Text.Length = 0 Then
            HeatNumberCommand.CommandText = "SELECT HeatNumber, Weight, CharterSteelCoilIdentification.Carbon, CharterSteelCoilIdentification.SteelSize, Description, CharterSteelCoilIdentification.CoilID, isnull(CharterSteelCoilIdentification.Location, '') as Location FROM CharterSteelCoilIdentification LEFT OUTER JOIN AnnealingCoilLines ON CharterSteelCoilIdentification.CoilID = AnnealingCoilLines.CoilID WHERE CharterSteelCoilIdentification.InventoryID = @InventoryID;"
            HeatNumberCommand.Parameters.Add("@InventoryID", SqlDbType.VarChar).Value = txtInventoryID.Text
        Else
            HeatNumberCommand.CommandText = "SELECT HeatNumber, Weight, CharterSteelCoilIdentification.Carbon, CharterSteelCoilIdentification.SteelSize, Description, isnull(CharterSteelCoilIdentification.InventoryID, '') as InventoryID, isnull(CharterSteelCoilIdentification.Location, '') as Location FROM CharterSteelCoilIdentification LEFT OUTER JOIN AnnealingCoilLines ON CharterSteelCoilIdentification.CoilID = AnnealingCoilLines.CoilID WHERE CharterSteelCoilIdentification.CoilID = @CoilID;"
            HeatNumberCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = HeatNumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = ""
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("Weight")) Then
                Weight = 0
            Else
                Weight = reader.Item("Weight")
            End If
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
            If IsDBNull(reader.Item("Description")) Then
                Description = ""
            Else
                Description = reader.Item("Description")
            End If
            If txtCoilID.Text.Length = 0 Then
                If IsDBNull(reader.Item("CoilID")) Then
                    txtCoilID.Text = ""
                Else
                    txtCoilID.Text = reader.Item("CoilID")
                End If
            Else
                If IsDBNull(reader.Item("InventoryID")) Then
                    txtInventoryID.Text = ""
                Else
                    txtInventoryID.Text = reader.Item("InventoryID")
                End If
            End If
            If IsDBNull(reader.Item("Location")) Then
                txtLocation.Text = ""
            Else
                txtLocation.Text = reader.Item("Location")
            End If
        Else
            HeatNumber = ""
            Weight = 0
            Carbon = ""
            SteelSize = ""
            Description = ""
            If txtCoilID.Text.Length = 0 Then
                txtInventoryID.Text = ""
            Else
                txtCoilID.Text = ""
            End If
            txtLocation.Text = ""
        End If
        reader.Close()
        con.Close()

        cboSteelSize.Text = SteelSize
        cboCarbon.Text = Carbon
        txtCoilDescription.Text = Description
        txtCoilWeight.Text = Weight
        cboHeatNumber.Text = HeatNumber

        cboCarbon.Text = Carbon
        cboSteelSize.Text = SteelSize
    End Sub

    Private Sub cmdAddToYard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToYard.Click
        If canAddToYard() Then
            If String.IsNullOrEmpty(txtCoilID.Text) Then
                If insertIntoCharterSteelCoilIdentification() Then
                    Exit Sub
                End If
            End If

            Dim division As String = "TWD"
            Dim YardEntryKey As Integer = 0

            'Get RMID for Steel type / Steel Size
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

            If GetRMID = "" Then
                MsgBox("You must select a valid steel type / steel size.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            ''updates the coil status in CharterSteelCoilIdentification
            Try
                updateCharter()
            Catch ex As System.Exception
                sendErrorToDataBase("SteelWireYardEntry - cmdSave_Click --Error trying to update coil to RAW in CharterSteelCoilIdentification", "Coil ID #" + txtCoilID.Text, ex.ToString())
                MessageBox.Show("There was an error updating coil Status. Contact System admin.", "Error Updating Coil Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            'Get Next Steel Transaction Number

            'Get Next Transaction Number
            Dim GetYardKeyStatement As String = "SELECT MAX(SteelReturnKey) FROM SteelYardEntryTable"
            Dim GetYardKeyCommand As New SqlCommand(GetYardKeyStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                YardEntryKey = CInt(GetYardKeyCommand.ExecuteScalar)
            Catch ex As System.Exception
                YardEntryKey = 62000000
            End Try
            con.Close()

            YardEntryKey = YardEntryKey + 1

            Dim TotalCost As Double = SteelModule.GetSteelCosting(GetRMID, Val(txtCoilWeight.Text), con, Now.Date)
            Dim CostPerPound As Double = Math.Round(TotalCost / Val(txtCoilWeight.Text), 5, MidpointRounding.AwayFromZero)

            'Add to Wire Yard Entry Table
            cmd = New SqlCommand("INSERT INTO SteelYardEntryTable (SteelReturnKey, ReturnDate, CoilID, ReturnWeight, SteelCost, ExtendedCost, RMID, DivisionID, Status, HeatNumber, Comment, ReferenceNumber, ReferenceLineNumber, PrintDate) values (@SteelReturnKey, @ReturnDate, @CoilID, @ReturnWeight, @SteelCost, @ExtendedCost, @RMID, @DivisionID, @Status, @HeatNumber, @Comment, @ReferenceNumber, @ReferenceLineNumber, @PrintDate)", con)

            With cmd.Parameters
                .Add("@SteelReturnKey", SqlDbType.VarChar).Value = YardEntryKey
                .Add("@ReturnDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                .Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
                .Add("@ReturnWeight", SqlDbType.VarChar).Value = Val(txtCoilWeight.Text)
                .Add("@SteelCost", SqlDbType.VarChar).Value = CostPerPound
                .Add("@ExtendedCost", SqlDbType.VarChar).Value = TotalCost
                .Add("@RMID", SqlDbType.VarChar).Value = GetRMID
                .Add("@DivisionID", SqlDbType.VarChar).Value = division
                .Add("@Status", SqlDbType.VarChar).Value = "POSTED"
                .Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
                .Add("@Comment", SqlDbType.VarChar).Value = "PARTIAL COIL"
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = 0
                .Add("@ReferenceLineNumber", SqlDbType.VarChar).Value = 0
                .Add("@PrintDate", SqlDbType.VarChar).Value = Now
            End With

            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("SteelWireYardEntry - cmdAddToYard_Click --Error trying to insert into the SteelYardEntryTable", "Coil ID #" + txtCoilID.Text, ex.ToString())
                MessageBox.Show("There was a problem trying to make the additions the the batch. Contact system admin.", "Unable to add to Yard", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            Try
                ''inserts the entry into the SteelTransactionTable
                cmd = New SqlCommand("INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, SteelTransactionDate, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType) VALUES((SELECT isnull(MAX(TransactionNumber) + 1,7700001) FROM SteelTransactionTable), @DivisionID, @SteelTransactionDate, @Carbon, @SteelSize, @Quantity, @SteelCost, @ExtendedCost, @SteelReferenceNumber, @SteelReferenceLine, @RMID, @TransactionMath, @TransactionType)", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@SteelTransactionDate", SqlDbType.VarChar).Value = Now.Date
                    .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtCoilWeight.Text)
                    .Add("@SteelCost", SqlDbType.VarChar).Value = CostPerPound
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = TotalCost
                    .Add("@SteelReferenceNumber", SqlDbType.VarChar).Value = YardEntryKey
                    .Add("@SteelReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@RMID", SqlDbType.VarChar).Value = GetRMID
                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "STEEL YARD ENTRY"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("SteelWireYardEntry - cmdAddToYard_Click --Error trying to insert into the Steel Transaction Table", "Coil ID #" + txtCoilID.Text, ex.ToString())
            End Try

            If Not EmployeeCompanyCode.Equals("TST") Then
                addCostTier(TotalCost, YardEntryKey)
            End If

            ''does the GL transactions
            Try
                GLTransactionEntries(division, TotalCost, YardEntryKey)
            Catch ex As System.Exception
                If ex.ToString.ToLower.Contains("primary key") Then
                    Try
                        GLTransactionEntries(division, TotalCost, YardEntryKey)
                    Catch ex1 As System.Exception
                        sendErrorToDataBase("SteelWireYardEntry - cmdAddToYard --Error writing GL entries", "Coil ID #" + txtCoilID.Text, ex1.ToString())
                        MessageBox.Show("There was a problem updating the Yard and WIP totals. Contact system admin", "Unable to complete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    sendErrorToDataBase("SteelWireYardEntry - cmdAddToYard --Error writing GL entries", "Coil ID #" + txtCoilID.Text, ex.ToString())
                    MessageBox.Show("There was a problem updating the Yard and WIP totals. Contact system admin", "Unable to complete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            End Try

            cleared = True
            ClearData()
            isloaded = False
            LoadCoilNumberData()
            isloaded = True
        End If
    End Sub

    Private Function canAddToYard() As Boolean
        Dim dateVariance As Long = DateDiff("d", dtpReturnDate.Value, Today.Date)
        If dateVariance > 30 Then
            MessageBox.Show("You must select a date that is less than a month ago", "Select a valid date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpReturnDate.Focus()
            Return False
        End If
        If dateVariance < 0 Then
            MessageBox.Show("You can't select a date in the future.", "Select a valid date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpReturnDate.Focus()
            Return False
        End If
        dateVariance = DateDiff("d", Today.Date, New DateTime(Today.Date.Year, 5, 1))
        If dateVariance <= 0 And dateVariance >= -30 Then
            If DateDiff("d", dtpReturnDate.Value.Date, New DateTime(Today.Date.Year, 5, 1)) > 2 Then
                MessageBox.Show("You can't post more than 2 day back into a prior fiscal year.", "Enter a valid date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpReturnDate.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtCoilID.Text) Then
            cmd = New SqlCommand("if exists(SELECT Status FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID) SELECT Status FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID ELSE SELECT 'Not Found';", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim stat As String = cmd.ExecuteScalar()
            con.Close()
            If stat Is Nothing Then
                stat = "Not Found"
            End If
            Select Case stat
                Case "Not Found"
                    MessageBox.Show("You must enter a valid coil ID", "Enter a valid Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCoilID.SelectAll()
                    txtCoilID.Focus()
                    Return False
                Case "CLOSED"
                    MessageBox.Show("Coil is not in a state that can be used. Contact system admin.", "Enter a valid Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCoilID.SelectAll()
                    txtCoilID.Focus()
                    Return False
                Case "OPEN"
                    MessageBox.Show("Coil is not in a state that can be used. Make sure it has been received in.", "Enter a valid Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCoilID.SelectAll()
                    txtCoilID.Focus()
                    Return False
                Case "RAW"
                    MessageBox.Show("Coil is already entered into the yard.", "Unable to add to yard", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cleared = True
                    ClearData()
                    txtCoilID.Focus()
                    Return False
            End Select
        Else
            MessageBox.Show("You must enter a Coil ID.", "Enter a Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboCarbon.Text) Then
            MessageBox.Show("You must enter a Grade", "Enter a Grade", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCarbon.Focus()
            Return False
        End If
        'If Not cboCarbon.Items.Contains(cboCarbon.Text) Then
        '    MessageBox.Show("You must enter a valid Carbon", "Enter a valid Carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboCarbon.SelectAll()
        '    cboCarbon.Focus()
        '    Return False
        'End If
        If String.IsNullOrEmpty(cboSteelSize.Text) Then
            MessageBox.Show("You must select a Size", "Select a Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.Focus()
            Return False
        End If
        'If cboSteelSize.SelectedIndex = -1 Then
        '    MessageBox.Show("You must enter a valid Size", "Enter a valid Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboSteelSize.SelectAll()
        '    cboSteelSize.Focus()
        '    Return False
        'End If

        cmd = New SqlCommand("SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            MessageBox.Show("You Carbon and Steel Size combination doesn't exist. Enter a valid Carbon/Steel Size Combination", "Invalid Carbon/Steel Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCarbon.SelectAll()
            cboCarbon.Focus()
            Return False
        End If
        con.Close()

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
        If String.IsNullOrEmpty(txtCoilWeight.Text) Then
            MessageBox.Show("You must enter a weight.", "Enter a weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilWeight.Focus()
            Return False
        End If
        If IsNumeric(txtCoilWeight.Text) = False Then
            MessageBox.Show("You must enter a number for weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilWeight.SelectAll()
            txtCoilWeight.Focus()
            Return False
        End If
        If Val(txtCoilWeight.Text) = 0 Then
            MessageBox.Show("Coil Weight must be greater than 0.", "Enter a Coil Weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilWeight.SelectAll()
            txtCoilWeight.Focus()
            Return False
        End If
        If cboCarbon.Text.ToUpper.Contains("SS") Then
            If String.IsNullOrEmpty(txtLocation.Text) Then
                MessageBox.Show("You must enter a location for Stainless Steel", "Enter a location", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLocation.Focus()
                Return False
            End If
        ElseIf cboCarbon.Text.ToUpper.Contains("ALUM") Or cboCarbon.Text.ToUpper.Contains("ALM") Then
            If String.IsNullOrEmpty(txtLocation.Text) Then
                MessageBox.Show("You must enter a location for Aluminum", "Enter a location", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLocation.Focus()
                Return False
            End If
        ElseIf cboCarbon.Text.ToUpper.Contains("BRASS") Or cboCarbon.Text.ToUpper.Contains("BRS") Then
            If String.IsNullOrEmpty(txtLocation.Text) Then
                MessageBox.Show("You must enter a location for Brass", "Enter a location", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLocation.Focus()
                Return False
            End If
        ElseIf cboCarbon.Text.ToUpper.Contains("BRONZE") Or cboCarbon.Text.ToUpper.Contains("BRN") Then
            If String.IsNullOrEmpty(txtLocation.Text) Then
                MessageBox.Show("You must enter a location for Bronze", "Enter a location", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLocation.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cboScanCoilID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isloaded Then
            LoadCoilInfo()
        End If
    End Sub

    Private Sub GLTransactionEntries(ByRef division As String, ByVal SteelCost As Double, ByVal yardEntryKey As Integer)

        'Remove steel weight from WIP and put back into yard

        '**********************************
        'Write to General Ledger
        '**********************************
        'Write Values to General Ledger (DEBIT)
        cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values(@key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @ReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

        With cmd.Parameters
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12800"
            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Yard Entry"
            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = Today()
            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SteelCost
            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Coil ID " + txtCoilID.Text
            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = yardEntryKey
            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        End With
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        'Write Values to General Ledger (CREDIT)
        cmd.CommandText += ", (@key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @ReferenceNumber, @GLReferenceLine, @GLTransactionStatus); COMMIT TRAN; SET xact_abort OFF;"
        With cmd.Parameters
            .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "12000"
            .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = SteelCost
            .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = 0
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        '**********************************
        'End of Ledger Entry
        '**********************************
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        cleared = True
        ClearData()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        ClearData()
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

    Private Sub updateCharter()
        'UPDATE Coil ID into Steel Coil Listing
        cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Weight = @Weight, Status = @Status, Location = @Location, InventoryID = @InventoryID WHERE CoilID = @CoilID;", con)

        With cmd.Parameters
            .Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
            .Add("@Weight", SqlDbType.VarChar).Value = txtCoilWeight.Text
            .Add("@Status", SqlDbType.VarChar).Value = "RAW"
            .Add("@Location", SqlDbType.VarChar).Value = txtLocation.Text
            .Add("@InventoryID", SqlDbType.VarChar).Value = txtInventoryID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function insertIntoCharterSteelCoilIdentification() As Boolean
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE ReceiveDate = @ReceiveDate;", con)
        cmd.Parameters.Add("@ReceiveDate", SqlDbType.VarChar).Value = Today.Date.ToString()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "CharterSteelCoilIdentification")
        con.Close()

        Dim count As Integer = 1
        For i As Integer = 0 To ds4.Tables("CharterSteelCoilIdentification").Rows.Count - 1
            If ds4.Tables("CharterSteelCoilIdentification").Rows(i).Item("CoilID").ToString().Contains("TWD") Then
                count += 1
            End If
        Next
        Dim mont As String = Today.Month.ToString()
        Dim da As String = Today.Day.ToString()
        If mont.Length < 2 Then
            mont = "0" + mont
        End If
        If da.Length < 2 Then
            da = "0" + da
        End If

        Dim id As String = "TWD" + mont + da + Today.Year.ToString()

        If count < 10 Then
            id += "-0" + count.ToString()
        Else
            id += "-" + count.ToString()
        End If

        cmd = New SqlCommand("INSERT INTO CharterSteelCoilIdentification (CoilID, Carbon, SteelSize, HeatNumber, Weight, ReceiveDate, DespatchNumber, PurchaseOrderNumber, SalesOrderNumber, Description, Status, Location, InventoryID) VALUES (@CoilID, @Carbon, @SteelSize, @HeatNumber, @Weight, @ReceiveDate, '0', '0', '0', (SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), 'RAW', @Location, @InventoryID);", con)
        With cmd.Parameters
            .Add("@CoilID", SqlDbType.VarChar).Value = id
            .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            .Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            .Add("@Weight", SqlDbType.Float).Value = Val(txtCoilWeight.Text)
            .Add("@ReceiveDate", SqlDbType.Date).Value = Now.Date
            .Add("@Location", SqlDbType.VarChar).Value = txtLocation.Text
            .Add("@InventoryID", SqlDbType.VarChar).Value = txtInventoryID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            con.Close()
            sendErrorToDataBase("SteelWireYardEntry - insertIntoCharterSteelCoilIdentification --Error inserting new Coil ID into CharterSteelCoilIdentification", "Coil ID #" + id, ex.ToString())
            MessageBox.Show("Unable to create new Coil ID. Contact system admin.", "Unable to generate Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End Try
        con.Close()

        isloaded = False
        LoadCoilNumberData()
        txtCoilID.Text = id
        isloaded = True

        Dim bc As New BarcodeLabel
        bc.setupYardLabel(id)
        bc.PrintBarcodeLine("ZebraWireyard")
        While DialogResult.Yes <> MessageBox.Show("Did the labels print correctly?", "Print Labels", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            bc.PrintBarcodeLine()
        End While
        Return False
    End Function

    Private Sub txtCoilID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilID.TextChanged
        If txtCoilID.Text.Length > 1 And txtCoilID.Text.Length < 3 Then
            If Char.ToLower(txtCoilID.Text.ElementAt(0)) = "s" Then
                txtCoilID.Text = txtCoilID.Text.Substring(1, txtCoilID.Text.Length - 1)
                txtCoilID.Select(txtCoilID.Text.Length, 0)
                FocusedField.position -= 1
                wasDeleted = True
            End If
        End If
        If txtCoilID.Focused Then
            FocusedField.position = txtCoilID.SelectionStart
            FocusedField.SelectionLength = 0
            If wasDeleted Then
                wasDeleted = False
            End If
        Else
            If Not wasDeleted Then
                FocusedField.position += 1
            Else
                wasDeleted = False
            End If
        End If
        If canSuggestID() Then
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Visible = False
            End If
            lstCoilIDSuggest.Items.Clear()
            If bgwkCoilIDSuggest.IsBusy Then
                bgwkCoilIDSuggest.CancelAsync()
            End If
            While bgwkCoilIDSuggest.IsBusy
                System.Windows.Forms.Application.DoEvents()
            End While
            bgwkCoilIDSuggest.RunWorkerAsync()
        End If
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If isloaded Then
            If cboCarbon.SelectedIndex <> -1 Then
                If lstCarbonSuggest.Visible Then
                    lstCarbonSuggest.Visible = False
                End If
            End If
            If String.IsNullOrEmpty(txtCoilID.Text) Then
                If String.IsNullOrEmpty(cboSteelSize.Text) = False Then
                    getSteelDescription()
                End If
            End If
        End If
    End Sub

    Private Sub getSteelDescription()
        cmd = New SqlCommand("SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        Dim describe As String = ""
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            describe = cmd.ExecuteScalar()
        Catch ex As System.Exception
            describe = ""
        End Try
        con.Close()

        txtCoilDescription.Text = describe
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If isloaded Then
            If cboSteelSize.SelectedIndex <> -1 Then
                If lstSizeSuggest.Visible Then
                    lstCarbonSuggest.Visible = False
                End If
            End If
            If String.IsNullOrEmpty(txtCoilID.Text) Then
                If String.IsNullOrEmpty(cboCarbon.Text) = False Then
                    getSteelDescription()
                End If
            End If
        End If
    End Sub

    Private Sub cboCarbon_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCarbon.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            cboSteelSize.SelectAll()
            cboSteelSize.Focus()
        End If
        If e.KeyCode = Keys.Back Then
            If cboCarbon.SelectionLength > 0 Then
                FocusedField.position -= cboCarbon.SelectionLength
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub cboSteelSize_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelSize.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            cboHeatNumber.SelectAll()
            cboHeatNumber.Focus()
        End If
        If e.KeyCode = Keys.Back Then
            If cboSteelSize.SelectionLength > 0 Then
                FocusedField.Position -= cboSteelSize.SelectionLength
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub cboHeatNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboHeatNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtCoilWeight.SelectAll()
            txtCoilWeight.Focus()
        End If
        If e.KeyCode = Keys.Back Then
            If cboHeatNumber.SelectionLength > 0 Then
                FocusedField.Position -= cboHeatNumber.SelectionLength
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub txtCoilWeight_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilWeight.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            cmdAddToYard.Focus()
        End If
        If e.KeyCode = Keys.Back Then
            If txtCoilWeight.SelectionLength > 0 Then
                FocusedField.Position -= txtCoilWeight.SelectionLength
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub addCostTier(ByVal totalCost As Double, ByVal yardEntryKey As Integer)
        Try
            cmd = New SqlCommand("BEGIN DECLARE @NewLower as int = (case when exists(SELECT isnull(UpperLimit, 0) FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize))) THEN (SELECT isnull(UpperLimit, 0) FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize))) ELSE (SELECT 0) END) + 1; Insert Into SteelCostingTable (RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values((SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon and SteelSize = @SteelSize), @Carbon, @SteelSize, @CostingDate, @SteelCostPerPound, @CostingQuantity, @Status, @NewLower, @NewLower + @CostingQuantity, (SELECT isnull(MAX(TransactionNumber) + 1, 73700001) FROM SteelCostingTable), @ReferenceNumber, @ReferenceLine); END", con)

            With cmd.Parameters
                .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                .Add("@CostingDate", SqlDbType.VarChar).Value = Today.Date.ToString()
                .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = Math.Round(totalCost / Val(txtCoilWeight.Text), 4)
                .Add("@CostingQuantity", SqlDbType.VarChar).Value = Val(txtCoilWeight.Text)
                .Add("@Status", SqlDbType.VarChar).Value = "STEEL YARD ENTRY"
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = yardEntryKey
                .Add("@ReferenceLine", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            sendErrorToDataBase("SteelWireYardEntry- addCostTiers --Error trying to inserting Yard Entry into SteelCostingTable", "Coil ID " + txtCoilID.Text, ex.ToString())
        End Try
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

    Private Sub cmdBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackspace.Click
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to make sure there is something to delete
            If Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length > 0 Then
                wasDeleted = True
                ''check to see if there was a selection made
                If FocusedField.SelectionLength > 0 Then
                    Select Case True
                        Case FocusedField.SelectionLength = FocusedField.Text.Length
                            FocusedField.Text = ""
                            FocusedField.Position = 0
                            Exit Select
                        Case FocusedField.Position = 0
                            FocusedField.Text = FocusedField.Text.Substring(FocusedField.SelectionLength, FocusedField.Text.Length - FocusedField.SelectionLength)
                            Exit Select
                        Case FocusedField.SelectionLength = (FocusedField.Text.Length - FocusedField.Position)
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position)
                            FocusedField.Position = FocusedField.Text.Length
                            Exit Select
                        Case Else
                            If FocusedField.Position > FocusedField.Text.Length Then
                                FocusedField.Position = FocusedField.Text.Length
                            End If
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + FocusedField.Text.Substring(FocusedField.Position + FocusedField.SelectionLength, FocusedField.Text.Length - (FocusedField.Position + FocusedField.SelectionLength))
                    End Select
                    FocusedField.SelectionLength = 0
                Else
                    ''check to se if we are at the back of the text
                    If FocusedField.Position = FocusedField.Text.Length Then
                        FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Text.Length - 1)
                        FocusedField.Position = FocusedField.Text.Length
                    Else
                        If FocusedField.Position > 0 Then
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position - 1) + FocusedField.Text.Substring(FocusedField.Position, FocusedField.Text.Length - FocusedField.Position)
                            FocusedField.Position -= 1
                        End If
                    End If
                End If
            End If
            FocusedField.Focus()
        End If
    End Sub

    Private Sub cmdALM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdALM.Click
        addText(sender, e, "ALM", 3)
    End Sub

    Private Sub cmdALUM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdALUM.Click
        addText(sender, e, "ALUM", 4)
    End Sub

    Private Sub cmdBRASS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBRASS.Click
        addText(sender, e, "BRASS", 5)
    End Sub

    Private Sub cmdBRN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBRN.Click
        addText(sender, e, "BRN", 3)
    End Sub

    Private Sub cmdBRS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBRS.Click
        addText(sender, e, "BRS", 3)
    End Sub

    Private Sub cmdCDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCDA.Click
        addText(sender, e, "CDA", 3)
    End Sub

    Private Sub cmdSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSA.Click
        addText(sender, e, "SA", 2)
    End Sub

    Private Sub cmdFS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFS.Click
        addText(sender, e, "FS", 2)
    End Sub

    Private Sub cmdC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdC.Click
        addText(sender, e, "C")
    End Sub

    Private Sub cmdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdA.Click
        addText(sender, e, "A")
    End Sub

    Private Sub cmdTWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTWD.Click
        addText(sender, e, "TWD", 3)
    End Sub

    Private Sub cmdDash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDash.Click
        addText(sender, e, "-")
    End Sub

    Private Sub cmdSS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSS.Click
        addText(sender, e, "SS", 2)
    End Sub

    Private Sub addText(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal tex As String, Optional ByVal charCount As Integer = 1)
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to see if there is a selection
            If FocusedField.SelectionLength > 0 Then
                cmdBackspace_Click(sender, e)
            End If
            If FocusedField.Position = FocusedField.Text.Length Then
                FocusedField.Text += tex
            Else
                FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + tex + FocusedField.Text.Substring(FocusedField.Position, FocusedField.Text.Length - FocusedField.Position)
            End If
            If charCount > 1 Then
                FocusedField.Position += charCount - 1
            End If
            FocusedField.Focus()
        End If
    End Sub

    Private Sub cboCarbon_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.DropDown
        If lstCarbonSuggest.Visible Then
            lstCarbonSuggest.Visible = False
        End If
    End Sub

    Private Sub cboSteelSize_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.DropDown
        If lstSizeSuggest.Visible Then
            lstSizeSuggest.Visible = False
        End If
    End Sub

    Private Sub cboHeatNumber_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.DropDown
        If lstHeatSuggest.Visible Then
            lstHeatSuggest.Visible = False
        End If
    End Sub

    Private Sub cboHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.TextChanged
        If lstHeatSuggest.Visible Then
            lstHeatSuggest.Visible = False
        End If
        If Not wasDeleted Then
            FocusedField.Position += 1
        Else
            wasDeleted = False
        End If
        lstHeatSuggest.Items.Clear()
        If canSuggestHeat() Then
            For i As Integer = 0 To ds3.Tables("CharterSteelCoilIdentification").Rows.Count - 1
                If ds3.Tables("CharterSteelCoilIdentification").Rows(i).Item("HeatNumber").ToString().Contains(cboHeatNumber.Text) Then
                    lstHeatSuggest.Items.Add(ds3.Tables("CharterSteelCoilIdentification").Rows(i).Item("HeatNumber").ToString())
                End If
            Next
            If lstHeatSuggest.Items.Count < 5 Then
                If lstHeatSuggest.Items.Count = 0 Then
                    lstHeatSuggest.Height = 40
                Else
                    lstHeatSuggest.Height = lstHeatSuggest.Items.Count * 40
                End If

            Else
                lstHeatSuggest.Height = 5 * 20
            End If
            lstHeatSuggest.Visible = True
        End If
    End Sub

    Private Function canSuggestHeat() As Boolean
        If String.IsNullOrEmpty(FocusedField.Name) Then
            If lstSizeSuggest.Visible Then
                lstSizeSuggest.Visible = False
            End If
            Return False
        End If
        If Not FocusedField.Name.Equals("cboHeatNumber") Then
            Return False
        End If
        If cboHeatNumber.Text.Length = 0 Then
            If lstHeatSuggest.Visible Then
                lstHeatSuggest.Visible = False
            End If
            Return False
        End If
        Return True
    End Function

    Private Sub lstHeatSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstHeatSuggest.SelectedValueChanged
        If lstHeatSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstHeatSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                cboHeatNumber.Text = lstHeatSuggest.SelectedItem
                lstHeatSuggest.Visible = False
                txtCoilWeight.Focus()
            End If
        End If
    End Sub

    Private Sub txtCoilID_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCoilID.MouseClick
        If txtCoilID.Focused Then
            FocusedField.Position = txtCoilID.SelectionStart
        End If
    End Sub

    Private Sub txtCoilID_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCoilID.MouseUp
        If txtCoilID.Focused Then
            FocusedField.Position = txtCoilID.SelectionStart
            FocusedField.SelectionLength = txtCoilID.SelectionLength
        End If
    End Sub

    Private Sub cboCarbon_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboCarbon") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(cboCarbon)
            Else
                cboCarbon.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(cboCarbon)
        End If
    End Sub

    Private Sub cboSteelSize_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboSteelSize") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(cboSteelSize)
            Else
                cboSteelSize.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(cboSteelSize)
        End If
    End Sub

    Private Sub cboHeatNumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboHeatNumber") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(cboHeatNumber)
            Else
                cboHeatNumber.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(cboHeatNumber)
        End If
    End Sub

    Private Sub txtCoilWeight_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilWeight.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtCoilWeight") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(txtCoilWeight)
            Else
                txtCoilWeight.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(txtCoilWeight)
        End If
    End Sub

    Private Sub cmdAddCoil_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToYard.Enter
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem()
        End If
    End Sub

    Private Sub cmdClearAll_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Enter
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            FocusedField = New FocusedItem()
        End If
    End Sub

    Private Sub cmdExit_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Enter
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            FocusedField = New FocusedItem()
        End If
    End Sub

    Private Function canSuggestID() As Boolean
        If barcodeScanner Then
            Return False
        End If
        If String.IsNullOrEmpty(FocusedField.Name) Then
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Visible = False
            End If
            Return False
        End If
        If Not FocusedField.Name.Equals("txtCoilID") Then
            Return False
        End If
        If txtCoilID.Focused Then
            Return False
        End If
        If txtCoilID.Text.Length = 0 Then
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Visible = False
            End If
            Return False
        End If
        Return True
    End Function

    Private Sub lstCoilIDSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCoilIDSuggest.SelectedValueChanged
        If lstCoilIDSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstCoilIDSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                txtCoilID.Text = lstCoilIDSuggest.SelectedItem
                LoadCoilInfo()
                lstCoilIDSuggest.Visible = False
                txtCoilWeight.SelectAll()
                txtCoilWeight.Focus()
            End If
        End If
    End Sub

    Private Sub cboCarbon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.TextChanged
        If lstCarbonSuggest.Visible Then
            lstCarbonSuggest.Visible = False
        End If
        If Not wasDeleted Then
            FocusedField.Position += 1
        Else
            wasDeleted = False
        End If
        lstCarbonSuggest.Items.Clear()
        If canSuggestCarbon() Then
            For i As Integer = 0 To ds.Tables("RawMaterialsTable").Rows.Count - 1
                If ds.Tables("RawMaterialsTable").Rows(i).Item("Carbon").ToString().Contains(cboCarbon.Text) Then
                    lstCarbonSuggest.Items.Add(ds.Tables("RawMaterialsTable").Rows(i).Item("Carbon").ToString())
                End If
            Next
            formatListbox(lstCarbonSuggest)
            If FocusedField.Name.Equals("cboCarbon") Then
                lstCarbonSuggest.Visible = True
            End If
            'If lstCarbonSuggest.Items.Count < 5 Then
            '    If lstCarbonSuggest.Items.Count = 0 Then
            '        lstCarbonSuggest.Height = 40
            '    Else
            '        lstCarbonSuggest.Height = lstCarbonSuggest.Items.Count * 40
            '    End If

            'Else
            '    lstCarbonSuggest.Height = 5 * 20
            'End If
            'lstCarbonSuggest.Visible = True
        End If
    End Sub

    Private Function canSuggestCarbon() As Boolean
        If String.IsNullOrEmpty(FocusedField.Name) Then
            If lstCarbonSuggest.Visible Then
                lstCarbonSuggest.Visible = False
            End If
            Return False
        End If
        If Not FocusedField.Name.Equals("cboCarbon") Then
            Return False
        End If
        If cboCarbon.Text.Length = 0 Then
            If lstCarbonSuggest.Visible Then
                lstCarbonSuggest.Visible = False
            End If
            Return False
        End If
        Return True
    End Function

    Private Sub hideSuggest(ByVal ctrl As String)
        If Not String.IsNullOrEmpty(ctrl) Then
            Select Case ctrl
                Case "txtCoilID"
                    lstCoilIDSuggest.Visible = False
                Case "cboCarbon"
                    lstCarbonSuggest.Visible = False
                Case "cboSteelSize"
                    lstSizeSuggest.Visible = False
                Case "cboHeat"
                    lstHeatSuggest.Visible = False
            End Select
        End If
    End Sub

    Private Sub lstCarbonSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCarbonSuggest.SelectedValueChanged
        If lstCarbonSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstCarbonSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                cboCarbon.Text = lstCarbonSuggest.SelectedItem
                lstCarbonSuggest.Visible = False
                cboSteelSize.Focus()
            End If
        End If
    End Sub

    Private Sub cboSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.TextChanged
        If lstSizeSuggest.Visible Then
            lstSizeSuggest.Visible = False
        End If
        If Not wasDeleted Then
            FocusedField.Position += 1
        Else
            wasDeleted = False
        End If
        lstSizeSuggest.Items.Clear()
        If canSuggestSize() Then
            For i As Integer = 0 To ds2.Tables("RawMaterialsTable").Rows.Count - 1
                If ds2.Tables("RawMaterialsTable").Rows(i).Item("SteelSize").ToString().Contains(cboSteelSize.Text) Then
                    lstSizeSuggest.Items.Add(ds2.Tables("RawMaterialsTable").Rows(i).Item("SteelSize").ToString())
                End If
            Next
            formatListbox(lstSizeSuggest)
            If FocusedField.Name.Equals("cboSteelSize") Then
                lstSizeSuggest.Visible = True
            End If
        End If
    End Sub

    Private Function canSuggestSize() As Boolean
        If String.IsNullOrEmpty(FocusedField.Name) Then
            If lstSizeSuggest.Visible Then
                lstSizeSuggest.Visible = False
            End If
            Return False
        End If
        If Not FocusedField.Name.Equals("cboSteelSize") Then
            Return False
        End If
        If cboSteelSize.Text.Length = 0 Then
            If lstSizeSuggest.Visible Then
                lstSizeSuggest.Visible = False
            End If
            Return False
        End If
        Return True
    End Function

    Private Sub lstSizeSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSizeSuggest.SelectedValueChanged
        If lstSizeSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstSizeSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                cboSteelSize.Text = lstSizeSuggest.SelectedItem
                lstSizeSuggest.Visible = False
                cboHeatNumber.Focus()
            End If
        End If
    End Sub

    Private Sub txtCoilID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilID.KeyUp
        If e.KeyCode = Keys.Enter Then
            If barcodeScanner Then
                barcodeScanner = False
                tmrScanTime.Stop()
                totalScanTime = 0
            End If
            e.Handled = True
            LoadCoilInfo()
            txtCoilWeight.SelectAll()
            txtCoilWeight.Focus()
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Visible = False
            End If
        End If
        If e.KeyCode = Keys.Back Then
            If txtCoilID.SelectionLength > 0 Then
                FocusedField.Position -= txtCoilID.SelectionLength
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub txtCoilID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilID.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtCoilID") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(txtCoilID)
            Else
                txtCoilID.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(txtCoilID)
        End If
    End Sub

    Private Sub txtCoilWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilWeight.TextChanged
        If Not wasDeleted Then
            FocusedField.Position += 1
        Else
            wasDeleted = False
        End If
    End Sub

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
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        wasDeleted = True
        Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text = ""
        FocusedField.Position = 0
        FocusedField.SelectionLength = 0
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            Select Case FocusedField.Name
                Case "txtCoilID"
                    If lstCoilIDSuggest.Items.Count = 1 And Not txtCoilID.Text.Equals(lstCoilIDSuggest.Items(0)) Then
                        txtCoilID.Text = lstCoilIDSuggest.Items(0)
                        LoadCoilInfo()
                        txtCoilWeight.SelectAll()
                        txtCoilWeight.Focus()
                    End If
                Case "cboCarbon"
                    If lstCarbonSuggest.Items.Count = 1 And Not cboCarbon.Text.Equals(lstCarbonSuggest.Items(0)) Then
                        cboCarbon.Text = lstCarbonSuggest.Items(0)
                    End If
                    SelectNextControl(Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name), True, True, True, True)
                Case "cboSteelSize"
                    If lstSizeSuggest.Items.Count = 1 And Not cboSteelSize.Text.Equals(lstSizeSuggest.Items(0)) Then
                        cboSteelSize.Text = lstSizeSuggest.Items(0)
                    End If
                    SelectNextControl(Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name), True, True, True, True)
                Case "cboHeatNumber"
                    If lstHeatSuggest.Items.Count = 1 And Not cboHeatNumber.Text.Equals(lstHeatSuggest.Items(0)) Then
                        cboHeatNumber.Text = lstHeatSuggest.Items(0)
                    End If
                    SelectNextControl(Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name), True, True, True, True)
                Case Else
                    SelectNextControl(Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name), True, True, True, True)
            End Select
        End If
    End Sub

    Private Sub bgwkCoilIDSuggest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkCoilIDSuggest.DoWork
        Dim lst As New List(Of String)
        For i As Integer = 0 To ds1.Tables("CharterSteelCoilIdentification").Rows.Count - 1
            If bgwkCoilIDSuggest.CancellationPending() Then
                Exit For
            End If
            If ds1.Tables("CharterSteelCoilIdentification").Rows(i).Item("CoilID").ToString().Contains(txtCoilID.Text) Then
                lst.Add(ds1.Tables("CharterSteelCoilIdentification").Rows(i).Item("CoilID").ToString())
            End If
        Next
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
        If FocusedField.Name.Equals("txtCoilID") Then
            lstCoilIDSuggest.Visible = True
        End If
    End Sub

    Private Sub cboHeatNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.SelectedIndexChanged
        If isloaded Then
            If cboHeatNumber.SelectedIndex <> -1 Then
                If lstHeatSuggest.Visible Then
                    lstHeatSuggest.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub txtCoilWeight_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCoilWeight.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtCoilWeight.SelectionStart
            FocusedField.SelectionLength = txtCoilWeight.SelectionLength
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

    Private Sub cboHeatNumber_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboHeatNumber.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = cboHeatNumber.SelectionStart
            FocusedField.SelectionLength = cboHeatNumber.SelectionLength
        End If
    End Sub

    Private Sub txtCoilID_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtCoilID.PreviewKeyDown
        If e.Modifiers = Keys.Shift And e.KeyCode = Keys.Oemcomma Then
            barcodeScanner = True
            tmrScanTime.Start()
        End If
    End Sub

    Private Sub txtCoilID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoilID.KeyPress
        If barcodeScanner Then
            If e.KeyChar = "<"c Then
                e.KeyChar = Nothing
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub tmrScanTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrScanTime.Tick
        If totalScanTime >= 5 Then
            tmrScanTime.Stop()
            totalScanTime = 0
            barcodeScanner = False
            txtCoilID.Text = "<" + txtCoilID.Text
            txtCoilID.SelectionStart = txtCoilID.Text.Length
        Else
            totalScanTime += 1
        End If
    End Sub

    Private Sub cboCarbon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCarbon.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboHeatNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.Leave
        If lstHeatSuggest.Visible Then
            lstHeatSuggest.Visible = False
        End If
    End Sub

    Private Sub txtInventoryID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInventoryID.TextChanged
        If txtInventoryID.Focused Then
            FocusedField.Position = txtInventoryID.SelectionStart
            FocusedField.SelectionLength = 0
            If wasDeleted Then
                wasDeleted = False
            End If
        Else
            If Not wasDeleted Then
                FocusedField.Position += 1
            Else
                wasDeleted = False
            End If
        End If
        If canSuggestInventoryID() Then
            If lstInventoryIDSuggest.Visible Then
                lstInventoryIDSuggest.Visible = False
            End If
            lstInventoryIDSuggest.Items.Clear()

            cmd = New SqlCommand("SELECT DISTINCT(InventoryID) as InventoryID FROM CharterSteelCoilIdentification WHERE InventoryID Like @InventoryID", con)
            cmd.Parameters.Add("@InventoryID", SqlDbType.VarChar).Value = txtInventoryID.Text + "%"

            If con.State = ConnectionState.Closed Then con.Open()

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    lstInventoryIDSuggest.Items.Add(reader.Item("InventoryID"))
                End While
            End If
            reader.Close()
            If lstInventoryIDSuggest.Items.Count < 5 Then
                If lstInventoryIDSuggest.Items.Count = 0 Then
                    lstInventoryIDSuggest.Height = 40
                Else
                    lstInventoryIDSuggest.Height = lstInventoryIDSuggest.Items.Count * 40
                End If

            Else
                lstInventoryIDSuggest.Height = 5 * 20
            End If
            lstInventoryIDSuggest.Visible = True
        End If
    End Sub

    Private Function canSuggestInventoryID() As Boolean
        If barcodeScanner Then
            Return False
        End If
        If String.IsNullOrEmpty(FocusedField.Name) Then
            If lstInventoryIDSuggest.Visible Then
                lstInventoryIDSuggest.Visible = False
            End If
            Return False
        End If
        If Not FocusedField.Name.Equals("txtInventoryID") Then
            Return False
        End If
        If Not txtInventoryID.Focused Then
            Return False
        End If
        If txtInventoryID.Text.Length = 0 Then
            If lstInventoryIDSuggest.Visible Then
                lstInventoryIDSuggest.Visible = False
            End If
            Return False
        End If
        Return True
    End Function

    Private Sub txtInventoryID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInventoryID.KeyUp
        If e.KeyCode = Keys.Enter Then
            If barcodeScanner Then
                barcodeScanner = False
                tmrScanTime.Stop()
                totalScanTime = 0
            End If
            e.Handled = True
            LoadCoilInfo()
            cmdAddToYard.Focus()
            If lstInventoryIDSuggest.Visible Then
                lstInventoryIDSuggest.Visible = False
            End If
        End If
        If e.KeyCode = Keys.Back Then
            If txtInventoryID.Text.Length > 0 Then
                FocusedField.Position -= txtInventoryID.Text.Length
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub txtInventoryID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInventoryID.KeyPress
        If barcodeScanner Then
            If e.KeyChar = "<"c Then
                e.KeyChar = Nothing
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtInventoryID_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtInventoryID.MouseClick
        If txtInventoryID.Focused Then
            FocusedField.Position = txtInventoryID.SelectionStart
        End If
    End Sub

    Private Sub txtInventoryID_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtInventoryID.MouseUp
        If txtInventoryID.Focused Then
            FocusedField.Position = txtInventoryID.SelectionStart
            FocusedField.SelectionLength = txtInventoryID.SelectionLength
        End If
    End Sub

    Private Sub txtInventoryID_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtInventoryID.PreviewKeyDown
        If e.Modifiers = Keys.Shift And e.KeyCode = Keys.Oemcomma Then
            barcodeScanner = True
            tmrScanTime.Start()
        End If
    End Sub

    Private Sub txtInventoryID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInventoryID.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtInventoryID") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(txtInventoryID)
            Else
                txtInventoryID.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(txtInventoryID)
        End If
    End Sub

    Private Sub lstInventoryIDSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInventoryIDSuggest.SelectedValueChanged
        If lstInventoryIDSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstInventoryIDSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                txtInventoryID.Text = lstInventoryIDSuggest.SelectedItem
                LoadCoilInfo()
                lstInventoryIDSuggest.Visible = False
                cmdAddToYard.Focus()
            End If
        End If
    End Sub
End Class