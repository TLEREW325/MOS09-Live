Imports System.Data.SqlClient
Imports System.Threading
Imports System

Public Class SteelWireYardRemoval
    Inherits System.Windows.Forms.Form

    Dim HeatNumber, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesorderNumber, PurchaseOrderNumber, Description, SteelDescription As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5 As Data.DataTable
    Dim GetRMID As String = ""

    Dim isLoaded As Boolean = False
    Dim cleared As Boolean = False

    Dim FocusedField As New usefulFunctions.FocusedItem()
    Dim wasDeleted As Boolean = False
    Dim notFinished As Boolean = False

    Dim totalScanTime As Integer
    Dim barcodeScanner As Boolean = False
    ''****************

    Public Sub LoadCoilNumberData()
        bgwkLoadCoilID.RunWorkerAsync()
    End Sub

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT(Carbon) as Carbon FROM RawMaterialsTable;", con)
        ds2 = New Data.DataTable("RawMaterialsTable")
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2)
        con.Close()

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = ds2
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT(SteelSize) as SteelSize FROM RawMaterialsTable;", con)
        ds3 = New Data.DataTable("RawMaterialsTable")
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3)
        con.Close()

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = ds3
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub LoadHeatNumbers()
        cmd = New SqlCommand("SELECT DISTINCT(HeatNumber) FROM CharterSteelCoilIdentification;", con)
        ds5 = New Data.DataTable("CharterSteelCoilIdentification")
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5)
        con.Close()

        cboHeatNumber.DisplayMember = "HeatNumber"
        cboHeatNumber.DataSource = ds5
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        dtpCoilUsageDate.Value = Today.Date
        If bgwkCoilIDSuggest.IsBusy Then
            bgwkCoilIDSuggest.CancelAsync()
        End If
        FocusedField = New FocusedItem()
        'Clear text boxes on load
        txtCoilID.Clear()

        cboCarbon.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cboCarbon.Text = ""
        End If
        cboSteelSize.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If
        cboHeatNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cboHeatNumber.Text = ""
        End If
        barcodeScanner = False
        totalScanTime = 0
        txtCoilDescription.Text = ""
        txtCoilWeight.Clear()
        txtAnnealLot.Clear()
        txtAnnealLot.ReadOnly = True
        If lstCoilIDSuggest.Visible Then
            lstCoilIDSuggest.Visible = False
        End If
        txtInventoryID.Clear()
        txtLocation.Clear()
        txtCoilID.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub SteelUsageForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCoilNumberData()
        LoadCarbon()
        LoadSteelSize()
        LoadHeatNumbers()

        ClearData()
        isLoaded = True
    End Sub

    Public Sub LoadCoilInfo()
        Dim Weight As Double = 0
        'Extract data from Charter Steel Table
        Dim HeatNumberCommand As New SqlCommand("", con)
        If txtCoilID.Text.Length = 0 Then
            HeatNumberCommand.CommandText = "SELECT HeatNumber, Weight, CharterSteelCoilIdentification.Carbon, CharterSteelCoilIdentification.SteelSize, Description, isnull(CAST(AnnealLotNumber AS Varchar(50)), AnnealLot) as AnnealLotNumber, CharterSteelCoilIdentification.CoilID, isnull(CharterSteelCoilIdentification.Location, '') as Location FROM CharterSteelCoilIdentification LEFT OUTER JOIN AnnealingCoilLines ON CharterSteelCoilIdentification.CoilID = AnnealingCoilLines.CoilID WHERE CharterSteelCoilIdentification.InventoryID = @InventoryID;"
            HeatNumberCommand.Parameters.Add("@InventoryID", SqlDbType.VarChar).Value = txtInventoryID.Text
        Else
            HeatNumberCommand.CommandText = "SELECT HeatNumber, Weight, CharterSteelCoilIdentification.Carbon, CharterSteelCoilIdentification.SteelSize, Description, isnull(CAST(AnnealLotNumber AS Varchar(50)), AnnealLot) as AnnealLotNumber, isnull(CharterSteelCoilIdentification.InventoryID, '') as InventoryID, isnull(CharterSteelCoilIdentification.Location, '') as Location FROM CharterSteelCoilIdentification LEFT OUTER JOIN AnnealingCoilLines ON CharterSteelCoilIdentification.CoilID = AnnealingCoilLines.CoilID WHERE CharterSteelCoilIdentification.CoilID = @CoilID;"
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
            If IsDBNull(reader.Item("AnnealLotNumber")) Then
                txtAnnealLot.Text = ""
            Else
                txtAnnealLot.Text = reader.Item("AnnealLotNumber")
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
            txtAnnealLot.Text = ""
            If txtCoilID.Text.Length = 0 Then
                txtCoilID.Text = ""
            Else
                txtInventoryID.Text = ""
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
        If txtAnnealLot.Text.Equals("0") Then
            txtAnnealLot.Text = ""
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAddCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddCoil.Click
        If canRemoveCoil() Then
            If String.IsNullOrEmpty(txtCoilID.Text) Then
                ''asks if the user meant to not put a coil ID
                If MessageBox.Show("Do you wish to generate a coil ID?", "Generate Coil ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    ''assigns a Coil ID and if it errors will exit
                    If assignCoilID() Then
                        MessageBox.Show("There was a problem generating a new Coil ID. Contact system admin", "Error generating Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                ''check to see what needs done to the coil to continue
                If checkSpecifiedCoil() Then
                    'MessageBox.Show("There was a problem with the Coil. Contact System admin", "Unable to continue", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            'UPDATE Coil Table to denote transfer of coil to WIP
            cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Status = 'WIP' WHERE CoilID = @CoilID;", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

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

            Dim totalBatchCost As Double = SteelModule.GetSteelCosting(GetRMID, Val(txtCoilWeight.Text), con, Now)
            Dim CostPerPound As Double = Math.Round(totalBatchCost / Val(txtCoilWeight.Text), 5, MidpointRounding.AwayFromZero)
            Dim usageKey As Integer = 0

            Try
                'Write Data to Steel Usage Table
                cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(SteelUsageKey) + 1, 22000001) FROM SteelUsageTable);" _
                                     + " Insert Into SteelUsageTable(SteelUsageKey, UsageDate, UsageWeight, RMID, DivisionID, Status, ReferenceNumber, ReferenceLineNumber, PrintDate, SteelCost, ExtendedCost)" _
                                     + " Values(@Key, @UsageDate, @UsageWeight, (SELECT TOP 1 RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @DivisionID, 'POSTED', @ReferenceNumber, 0, @PrintDate, @SteelCost, @ExtendedCost);" _
                                     + " SELECT @Key;", con)

                With cmd.Parameters
                    .Add("@UsageDate", SqlDbType.Date).Value = dtpCoilUsageDate.Value
                    .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                    .Add("@UsageWeight", SqlDbType.VarChar).Value = Val(txtCoilWeight.Text)
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = txtCoilID.Text
                    .Add("@PrintDate", SqlDbType.DateTime2).Value = Now
                    .Add("@SteelCost", SqlDbType.Float).Value = CostPerPound
                    .Add("@ExtendedCost", SqlDbType.Float).Value = totalBatchCost
                End With

                If EmployeeCompanyCode.Equals("TST") Then
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                End If

                If con.State = ConnectionState.Closed Then con.Open()
                usageKey = Convert.ToInt32(cmd.ExecuteScalar())
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("SteelWireYardRemoval - cmdAddCoil_Click --Error adding Steel Usage Entry", "Coil ID " + txtCoilID.Text, ex.ToString())
            End Try

            'Add Steel Transaction
            addSteelTransaction(Val(txtCoilWeight.Text), CostPerPound, totalBatchCost, usageKey)

            ''Dim totalBatchCost As Double = getSteelCosting(usageKey)
            '**********************************
            'Write to General Ledger
            '**********************************
            'Write Values to General Ledger (DEBIT)
            cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList)," _
                                 + " @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList);" _
                                 + " SET xact_abort on;" _
                                 + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)" _
                                 + " values(@key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, (SELECT MAX(SteelUsageKey) FROM SteelUsageTable WHERE ReferenceNumber = @CoilID), @GLReferenceLine, @GLTransactionStatus)", con)
            With cmd.Parameters
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12800"
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Yard Removal"
                .Add("@GLTransactionDate", SqlDbType.Date).Value = dtpCoilUsageDate.Value
                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = totalBatchCost
                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Removed Coil"
                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                .Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If EmployeeCompanyCode.Equals("TST") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            End If

            'Write Values to General Ledger (CREDIT)
            cmd.CommandText += ", (@key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, (SELECT MAX(SteelUsageKey) FROM SteelUsageTable WHERE ReferenceNumber = @CoilID), @GLReferenceLine, @GLTransactionStatus); COMMIT TRAN; SET xact_abort OFF;"
            With cmd.Parameters
                .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "12000"
                .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = 0
                .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = totalBatchCost
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                If ex.ToString.ToLower.Contains("primary key") Then
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex1 As Exception
                        sendErrorToDataBase("SteelWireYardRemoval - cmdAddCoil --Error adding GL Entries into GLTransactionMasterList", "Coil #" + txtCoilID.Text, ex1.ToString())
                    End Try
                Else
                    sendErrorToDataBase("SteelWireYardRemoval - cmdAddCoil --Error adding GL Entries into GLTransactionMasterList", "Coil #" + txtCoilID.Text, ex.ToString())
                End If
            End Try

            con.Close()
            '**********************************
            'End of Ledger Entry
            '**********************************
            'Clear text boxes after entry
            ClearData()
            LoadCoilNumberData()
            cleared = True
            txtCoilID.Focus()
        End If
    End Sub

    Private Function canRemoveCoil() As Boolean
        If EmployeeSecurityCode >= 1003 Then
            Dim dateVariance As Long = DateDiff("d", dtpCoilUsageDate.Value, Today.Date)
            If dateVariance > 30 Then
                MessageBox.Show("You must select a date that is less than a month ago", "Select a valid date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpCoilUsageDate.Focus()
                Return False
            End If
            If dateVariance < 0 Then
                MessageBox.Show("You can't select a date in the future.", "Select a valid date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpCoilUsageDate.Focus()
                Return False
            End If
            dateVariance = DateDiff("d", Today.Date, New DateTime(Today.Date.Year, 5, 1))
            If dateVariance <= 0 And dateVariance >= -30 Then
                If DateDiff("d", dtpCoilUsageDate.Value.Date, New DateTime(Today.Date.Year, 5, 1)) > 2 Then
                    MessageBox.Show("You can't post more than 2 day back into a prior fiscal year.", "Enter a valid date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dtpCoilUsageDate.Focus()
                    Return False
                End If
            End If
        End If

        If String.IsNullOrEmpty(cboCarbon.Text) Then
            MessageBox.Show("You must select a Carbon", "Select a Carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCarbon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelSize.Text) Then
            MessageBox.Show("You must select a Steel Size", "Select a Steel Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.Focus()
            Return False
        End If
        cmd = New SqlCommand("SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            MessageBox.Show("Carbon and Steel Size do not match anything in the Raw Materials. Add it to Raw Materials and then try again.", "Unable to complete removal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
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
            MessageBox.Show("You must enter a Weight", "Enter a Weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilWeight.Focus()
            Return False
        End If
        If Not IsNumeric(txtCoilWeight.Text) Then
            MessageBox.Show("You must enter a number for Weight", "Enter a Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilWeight.SelectAll()
            txtCoilWeight.Focus()
            Return False
        End If
        If Val(txtCoilWeight.Text) <= 0 Then
            MessageBox.Show("You must enter a value greater than 0 for Weight", "Enter a valid Weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilWeight.SelectAll()
            txtCoilWeight.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(txtAnnealLot.Text) Then
            If Not txtAnnealLot.ReadOnly Then
                If Not cboCarbon.Text.Contains("A") Then
                    MessageBox.Show("Carbon selected must be Annealed Carbon to add Anneal Lot", "Unable to Add Coil", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub txtCoilID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isLoaded Then
            LoadCoilInfo()
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        'Clear text boxes after entry
        ClearData()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        'Clear text boxes after entry
        ClearData()
    End Sub

    Private Sub addSteelTransaction(ByVal weight As Double, ByVal CostPerPound As Double, ByVal steelCost As Double, ByVal usageKey As Integer, Optional ByVal status As String = "SUBTRACT")
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

        ''inserts the entry into the SteelTransactionTable
        cmd = New SqlCommand("INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType, SteelTransactionDate)" _
                             + " VALUES((SELECT isnull(MAX(TransactionNumber) + 1,7700001) FROM SteelTransactionTable),@DivisionID, @Carbon, @SteelSize, @Quantity, @SteelCost, @ExtendedCost, @SteelReferenceNumber, 0, @RMID, @Status, 'WIRE YARD REMOVED', @PostingDate);", con)
        With cmd.Parameters
            .Add("@Quantity", SqlDbType.Float).Value = weight
            .Add("@SteelCost", SqlDbType.Float).Value = CostPerPound
            .Add("@ExtendedCost", SqlDbType.Float).Value = steelCost
            .Add("@PostingDate", SqlDbType.Date).Value = dtpCoilUsageDate.Value
            .Add("@EmployeeID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@SteelReferenceNumber", SqlDbType.Int).Value = usageKey
            .Add("@Status", SqlDbType.VarChar).Value = status
            .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            .Add("@RMID", SqlDbType.VarChar).Value = GetRMID
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)" _
                             + " VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Now
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

    Private Function assignCoilID() As Boolean
        Dim cnt As Integer = 0
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE ReceiveDate = @ReceiveDate;", con)
        cmd.Parameters.Add("@ReceiveDate", SqlDbType.VarChar).Value = Today.ToShortDateString()
        Dim lst As New List(Of String)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                lst.Add(reader.Item("CoilID"))
            End While
        End If
        reader.Close()
        con.Close()
        ''counts the coils that were received today
        If lst.Count > 0 Then
            For i As Integer = 0 To lst.Count - 1
                If lst(i).Contains("TWD") Then
                    cnt += 1
                End If
            Next
        End If
        cnt += 1

        Dim id As String = "TWD"
        ''check to see if the month is greater than 9 else adds a leading 0
        If Today.Month > 9 Then
            id += Today.Month.ToString()
        Else
            id += "0" + Today.Month.ToString()
        End If
        ''check to see if the day is greater than 9 else adds a leading 0
        If Today.Day > 9 Then
            id += Today.Day.ToString()
        Else
            id += "0" + Today.Day.ToString()
        End If

        id += Today.Year.ToString()
        ''check to see if more than 9 coils else adds a leading 0
        If cnt > 9 Then
            id += "-" + cnt.ToString()
        Else
            id += "-0" + cnt.ToString()
        End If
        ''adds the entry into the CharterSteelCoilIdentification table
        If insertCoilIntoTable(id) Then
            Return True
        End If
        Dim bc As New BarcodeLabel()
        bc.setupYardLabel(id)
        bc.PrintBarcodeLine()
        While MessageBox.Show("Did the labels print correctly?", "Reprint?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes
            bc.PrintBarcodeLine()
        End While
        txtCoilID.Text = id
        Return False
    End Function

    Private Function insertCoilIntoTable(ByVal id As String) As Boolean
        ''adds the Coil ID to the DB
        cmd = New SqlCommand("INSERT INTO CharterSteelCoilIdentification (CoilID, HeatNumber, Weight, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesOrderNumber, PurchaseOrderNumber, Description, Status, AnnealLot)" _
                             + " VALUES (@CoilID, @HeatNumber, @Weight, 0, @Carbon, @SteelSize, @ReceiveDate, 0, 0, 0," _
                             + " (SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), 'RAW', @AnnealLot);", con)
        With cmd.Parameters
            .Add("@CoilID", SqlDbType.VarChar).Value = id
            .Add("@HeatNumber", SqlDbType.VarChar).Value = Val(cboHeatNumber.Text)
            .Add("@Weight", SqlDbType.VarChar).Value = Val(txtCoilWeight.Text)
            .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            .Add("@ReceiveDate", SqlDbType.Date).Value = dtpCoilUsageDate.Value
            .Add("@AnnealLot", SqlDbType.VarChar).Value = txtAnnealLot.Text
        End With
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            con.Close()
            sendErrorToDataBase("SteelWireYardRemoval - assignCoilID --Error trying to add newly assigned Coil ID to CharterSteelCoilIdentification", " Coil ID " + id, ex.ToString())
            Return True
        End Try
        If txtCoilID.Text.Equals(id) And Not String.IsNullOrEmpty(txtAnnealLot.Text) And Not txtAnnealLot.Text.Equals("OSA") Then
            ''if the anneal lot was created and the coil was added successfully will return false else returns true
            If InsertedAnnealLot() Then
                Return False
            Else
                Return True
            End If
        End If
        Return False
    End Function

    Private Function InsertedAnnealLot() As Boolean
        cmd = New SqlCommand("SELECT HeatNumber FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(txtAnnealLot.Text)
        Dim heat As String = ""

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("HeatNumber")) Then
                heat = reader.Item("HeatNumber")
            End If
        End If
        reader.Close()
        ''check to see if a heat number was pulled and if not will add the anneal lot and all data needed
        If String.IsNullOrEmpty(heat) Then
            If EmployeeCompanyCode.Equals("TST") Then
                cmd = New SqlCommand("INSERT INTO AnnealingLog (AnnealLotNumber, RMID, HeatNumber, AnnealedRMID, AnnealedCarbon, AnnealedSteelSize, TotalPoundsAnnealed, NumberOfCoils, DivisionID, Status) VALUES (@AnnealLotNumber, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @AnnealedSteelSize), @HeatNumber, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @AnnealedCarbon AND SteelSize = @AnnealedSteelSize), @AnnealedCarbon, @AnnealedSteelSize, @Weight, 1, 'TST', 'OPEN');", con)
            Else
                cmd = New SqlCommand("INSERT INTO AnnealingLog (AnnealLotNumber, RMID, HeatNumber, AnnealedRMID, AnnealedCarbon, AnnealedSteelSize, TotalPoundsAnnealed, NumberOfCoils, DivisionID, Status) VALUES (@AnnealLotNumber, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @AnnealedSteelSize), @HeatNumber, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @AnnealedCarbon AND SteelSize = @AnnealedSteelSize), @AnnealedCarbon, @AnnealedSteelSize, @Weight, 1, 'TWD', 'OPEN');", con)
            End If

        Else
            If heat.Equals(cboHeatNumber.Text) Then
                cmd = New SqlCommand("UPDATE AnnealingLog SET TotalPoundsAnnealed = (TotalPoundsAnnealed + @Weight), NumberOfCoils = (NumberOfCoils + 1) WHERE AnnealLotNumber = @AnnealLotNumber;", con)
            Else
                MessageBox.Show("Heat number entered is not the same heat number in Annealing Lot entered. Coil has not been added to entered Annealing Lot", "Unable to add to Annealing lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If

        With cmd.Parameters
            .Add("@AnnealLotNumber", SqlDbType.Int).Value = Val(txtAnnealLot.Text)
            .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text.Substring(0, cboCarbon.Text.IndexOf("A"))
            .Add("@AnnealedCarbon", SqlDbType.VarChar).Value = cboCarbon.Text
            .Add("@AnnealedSteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            .Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            .Add("@Weight", SqlDbType.Float).Value = Val(txtCoilWeight.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            sendErrorToDataBase("SteelWireYardRemoval - InsertAnnealLot -- Error inserting/ updating Anneal Lot, Coil ID " + txtCoilID.Text, "Anneal Lot #" + txtAnnealLot.Text, ex.ToString())
            MessageBox.Show("There was a problem creatign the Annealed Lot, Contact system admin", "Unable to create annealed Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
        cmd = New SqlCommand("INSERT INTO AnnealingCoilLines (AnnealLotNumber, CoilID, AnnealedWeight) VALUES (@AnnealLotNumber, @CoilID, @AnnealedWeight);", con)
        With cmd.Parameters
            .Add("@AnnealLotNumber", SqlDbType.Int).Value = txtAnnealLot.Text
            .Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
            .Add("@AnnealedWeight", SqlDbType.Float).Value = Val(txtCoilWeight.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            sendErrorToDataBase("SteelWireYardRemoval - InsertAnnealLot -- Error adding coil to Anneal Lot, Coil ID " + txtCoilID.Text, "Anneal Lot #" + txtAnnealLot.Text, ex.ToString())
            MessageBox.Show("There was a problem addint the Coil to the Anneal Lot, Contact system admin", "Unable to Add Coil to Anneal Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try

        con.Close()
        Return True
    End Function

    Private Function checkSpecifiedCoil() As Boolean
        cmd = New SqlCommand("SELECT Status FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
        Dim coilFound As Boolean = False
        Dim stat As String = ""

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("Status")) Then
                stat = reader.Item("Status")
                coilFound = True
            End If
        End If
        reader.Close()
        con.Close()
        ''check to see if there was a coil found
        If coilFound Then
            ''check the state of the coil
            Select Case stat
                Case "CLOSED"
                    If MessageBox.Show("Coil exists but is showing CLOSED. Do you wish to return the Coil to RAW status?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        reactivateCoil()
                    Else
                        Return True
                    End If
                Case "RAW"
                    Return False
                Case "WIP"
                    MessageBox.Show("Coil has already been removed from the Yard", "Coil already removed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmdClearAll.Focus()
                    Return True
                Case Else
                    MessageBox.Show("Coil is not in a state that can be changed. Make sure it is Received in.", "Check Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmdClearAll.Focus()
                    Return True
            End Select

            Return False
        Else
            Return False
            ' ''check ot make sure the user wanted to add the coil ID
            'If MessageBox.Show("Coil ID does not exist, do you wish to add it?", "Add coil ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            '    Return True
            'End If
        End If
        ''adds the entry into CharterSteelCoilIdentification
        ''Return insertCoilIntoTable(txtCoilID.Text)
    End Function

    Private Sub reactivateCoil()
        cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Status = 'RAW', Weight = @Weight WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
        cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = txtCoilWeight.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()

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

        ''gets the cost of the steel
        Dim TotalCost As Double = SteelModule.GetSteelCosting(GetRMID, Val(txtCoilWeight.Text), con, Now)
        Dim CostPerPound As Double = Math.Round(TotalCost / Val(txtCoilWeight.Text), 5, MidpointRounding.AwayFromZero)
        ''adds the SteelYardEntryTable entry
        cmd = New SqlCommand("DECLARE @Key as int = (SELECT ISNull(MAX(SteelReturnKey) + 1, 63000001) FROM SteelYardEntryTable);" _
                             + " INSERT INTO SteelYardEntryTable (SteelReturnKey, ReturnDate, CoilID, ReturnWeight, RMID, DivisionID, Status, HeatNumber, Comment, ReferenceNumber, SteelCost, ExtendedCost)" _
                             + " VALUES (@key, @ReturnDate, @CoilID, (SELECT Weight FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID), (SELECT TOP 1 RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), 'TWD', 'POSTED', @HeatNumber, 'COIL REACTIVATED', 0, @SteelCost, @ExtendedCost);" _
                             + " SELECT @Key;", con)
        cmd.Parameters.Add("@ReturnDate", SqlDbType.Date).Value = dtpCoilUsageDate.Value
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        cmd.Parameters.Add("@SteelCost", SqlDbType.Float).Value = CostPerPound
        cmd.Parameters.Add("@ExtendedCost", SqlDbType.VarChar).Value = TotalCost

        If con.State = ConnectionState.Closed Then con.Open()
        Dim EntryKey As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        addSteelTransaction(Val(txtCoilWeight.Text), CostPerPound, TotalCost, EntryKey, "ADD")
        ''adds in a cost Tier
        If Not EmployeeCompanyCode.Equals("TST") Then
            addCostTiers(TotalCost)
        End If
        '**********************************
        'Write to General Ledger
        '**********************************
        'Write Values to General Ledger (DEBIT)
        cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList)," _
                             + " @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList);" _
                             + " SET xact_abort on;" _
                             + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)" _
                             + " values(@key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @ReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

        With cmd.Parameters
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"
            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Coil Reactivated"
            .Add("@GLTransactionDate", SqlDbType.Date).Value = dtpCoilUsageDate.Value
            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = TotalCost
            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Coil ID " + txtCoilID.Text
            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = EntryKey.ToString()
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
            .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "12800"
            .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = TotalCost
            .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = 0
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************
        'End of Ledger Entry
        '**********************************
    End Sub

    Private Sub addCostTiers(ByVal steelCost As Double)
        cmd = New SqlCommand("BEGIN DECLARE @NewLower as int = (case when exists(SELECT isnull(UpperLimit, 0) FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize))) THEN (SELECT isnull(UpperLimit, 0) FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize))) ELSE (SELECT 0) END) + 1; Insert Into SteelCostingTable (RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values((SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon and SteelSize = @SteelSize), @Carbon, @SteelSize, @CostingDate, @SteelCostPerPound, @CostingQuantity, @Status, @NewLower, @NewLower + @CostingQuantity, (SELECT isnull(MAX(TransactionNumber) + 1, 73700001) FROM SteelCostingTable), @ReferenceNumber, @ReferenceLine); END", con)

        With cmd.Parameters
            .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            .Add("@CostingDate", SqlDbType.Date).Value = dtpCoilUsageDate.Value
            .Add("@SteelCostPerPound", SqlDbType.Float).Value = Math.Round(steelCost / Val(txtCoilWeight.Text), 4, MidpointRounding.AwayFromZero)
            .Add("@CostingQuantity", SqlDbType.Float).Value = Val(txtCoilWeight.Text)
            .Add("@Status", SqlDbType.VarChar).Value = "COIL REACTIVATED"
            .Add("@ReferenceNumber", SqlDbType.Int).Value = 0
            .Add("@ReferenceLine", SqlDbType.Int).Value = 0
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            sendErrorToDataBase("SteelCoilReceiving - addCostTiers --Error trying to insert Carbon " + cboCarbon.Text + " AND Steel Size " + cboSteelSize.Text + " into SteelCostingTable", "Coil ID " + txtCoilID.Text, ex.ToString())
            MessageBox.Show("There was an issue with updating cost tiers. Contact system admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub txtCoilID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(txtCoilID.Text) Then
            LoadCoilInfo()
        End If
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If Not String.IsNullOrEmpty(cboCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            loadSteelDescription()
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If Not String.IsNullOrEmpty(cboCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            loadSteelDescription()
        End If
    End Sub

    Private Sub loadSteelDescription()
        cmd = New SqlCommand("SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon and SteelSize = @SteelSize;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Description")) Then
                txtCoilDescription.Text = ""
            Else
                txtCoilDescription.Text = reader.Item("Description")
            End If
        Else
            txtCoilDescription.Text = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub bgwkLoadCoilID_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkLoadCoilID.DoWork
        cmd1 = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status = 'RAW';", con1)
        ds1 = New Data.DataTable("CharterSteelCoilIdentification")
        myAdapter1.SelectCommand = cmd1

        If con.State = ConnectionState.Closed Then con1.Open()
        myAdapter1.Fill(ds1)
        con1.Close()
    End Sub

    Private Sub cmdClearAll_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdClearAll.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            ClearData()
            cleared = True
        End If
    End Sub

    Private Sub txtCoilID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilID.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("txtCoilID") Then
                hideSuggest(FocusedField.name)
                FocusedField = New FocusedItem(txtCoilID)
            Else
                txtCoilID.SelectionStart = FocusedField.position
            End If
        Else
            hideSuggest(FocusedField.name)
            FocusedField = New FocusedItem(txtCoilID)
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

    Private Sub cmdBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackspace.Click
        If Not String.IsNullOrEmpty(FocusedField.name) Then
            ''check to make sure there is something to delete
            If Me.Controls("gpxSteelCoilData").Controls(FocusedField.name).Text.Length > 0 Then
                wasDeleted = True
                ''check to see if there was a selection made
                If FocusedField.SelectionLength > 0 Then
                    Select Case True
                        Case FocusedField.SelectionLength = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length
                            Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text = ""
                            FocusedField.Position = 0
                            Exit Select
                        Case FocusedField.Position = 0
                            Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Substring(FocusedField.SelectionLength, Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length - FocusedField.SelectionLength)
                            Exit Select
                        Case FocusedField.SelectionLength = (Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length - FocusedField.Position)
                            Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Substring(0, FocusedField.Position)
                            FocusedField.Position = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length
                            Exit Select
                        Case Else
                            If FocusedField.Position > Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length Then
                                FocusedField.Position = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length
                            End If
                            Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Substring(0, FocusedField.Position) + Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Substring(FocusedField.Position + FocusedField.SelectionLength, Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length - (FocusedField.Position + FocusedField.SelectionLength))
                    End Select
                    FocusedField.SelectionLength = 0
                Else
                    If Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length < FocusedField.Position Then
                        FocusedField.Position = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length
                    End If
                    ''check to se if we are at the back of the text
                    If FocusedField.Position = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length Then
                        Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Substring(0, Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length - 1)
                        FocusedField.Position = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length
                    Else
                        If FocusedField.Position > 0 Then
                            Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text = Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Substring(0, FocusedField.Position - 1) + Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Substring(FocusedField.Position, Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Text.Length - FocusedField.Position)
                            FocusedField.Position -= 1
                        End If
                    End If
                End If
            End If
            Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name).Focus()
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

    Private Sub cboCarbon_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboCarbon") Then
                checkCoilID()
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
                checkCoilID()
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
                checkCoilID()
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

    Private Sub cmdAddCoil_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddCoil.Enter
        If FocusedField.isSet() Then
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem()
        End If
    End Sub

    Private Sub cmdClearAll_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Enter
        If FocusedField.isSet() Then
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem()
        End If
    End Sub

    Private Sub cmdExit_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Enter
        If FocusedField.isSet() Then
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem()
        End If
    End Sub

    Private Sub txtCoilID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilID.TextChanged
        If txtCoilID.Text.Length > 1 And txtCoilID.Text.Length < 3 Then
            If Char.ToLower(txtCoilID.Text.ElementAt(0)) = "s" Then
                txtCoilID.Text = txtCoilID.Text.Substring(1, txtCoilID.Text.Length - 1)
                txtCoilID.Select(txtCoilID.Text.Length, 0)
                FocusedField.Position -= 1
                wasDeleted = True
            End If
        End If
        If txtCoilID.Focused Then
            FocusedField.Position = txtCoilID.SelectionStart
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
        If canSuggestID() Then
            While bgwkLoadCoilID.IsBusy
                Exit Sub
            End While
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
                cmdAddCoil.Focus()
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
        lstCarbonSuggest.DataSource = Nothing
        If canSuggestCarbon() Then
            If lstCarbonSuggest.DisplayMember <> "Carbon" Then lstCarbonSuggest.DisplayMember = "Carbon"
            Dim tmp As Data.DataRow() = ds2.Select("Carbon like '" + cboCarbon.Text.ToUpper() + "%'", " Carbon ASC")
            If tmp.Length > 0 Then
                lstCarbonSuggest.DataSource = tmp.CopyToDataTable()
            End If

            If lstCarbonSuggest.Items.Count < 5 Then
                If lstCarbonSuggest.Items.Count = 0 Then
                    lstCarbonSuggest.Height = 40
                Else
                    lstCarbonSuggest.Height = lstCarbonSuggest.Items.Count * 40
                End If

            Else
                lstCarbonSuggest.Height = 5 * 20
            End If
            lstCarbonSuggest.Visible = True
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
                Case "cboHeatNumber"
                    lstHeatSuggest.Visible = False
            End Select
        End If
    End Sub

    Private Sub lstCarbonSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCarbonSuggest.SelectedValueChanged
        If lstCarbonSuggest.Visible Then
            If Not String.IsNullOrEmpty(CType(lstCarbonSuggest.SelectedItem, Data.DataRowView).Item("Carbon")) Then
                FocusedField = New FocusedItem()
                cboCarbon.Text = CType(lstCarbonSuggest.SelectedItem, Data.DataRowView).Item("Carbon")
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
        lstSizeSuggest.DataSource = Nothing
        If canSuggestSize() Then
            If lstSizeSuggest.DisplayMember <> "SteelSize" Then lstSizeSuggest.DisplayMember = "SteelSize"
            Dim test As String = ds3.Rows(0).Item("SteelSize")
            Dim tmp As Data.DataRow() = ds3.Select("SteelSize like '" + cboSteelSize.Text + "%'", " SteelSize ASC")
            If tmp.Length > 0 Then
                lstSizeSuggest.DataSource = tmp.CopyToDataTable()
            End If

            'For i As Integer = 0 To ds3.Tables("RawMaterialsTable").Rows.Count - 1
            '    If ds3.Tables("RawMaterialsTable").Rows(i).Item("SteelSize").ToString().Contains(cboSteelSize.Text) Then
            '        lstSizeSuggest.Items.Add(ds3.Tables("RawMaterialsTable").Rows(i).Item("SteelSize").ToString())
            '    End If
            'Next
            If lstSizeSuggest.Items.Count < 5 Then
                If lstSizeSuggest.Items.Count = 0 Then
                    lstSizeSuggest.Height = 40
                Else
                    lstSizeSuggest.Height = lstSizeSuggest.Items.Count * 40
                End If

            Else
                lstSizeSuggest.Height = 5 * 20
            End If
            lstSizeSuggest.Visible = True
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
            If Not String.IsNullOrEmpty(CType(lstSizeSuggest.SelectedItem, Data.DataRowView).Item("SteelSize")) Then
                FocusedField = New FocusedItem()
                cboSteelSize.Text = CType(lstSizeSuggest.SelectedItem, Data.DataRowView).Item("SteelSize")
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
            If Not String.IsNullOrEmpty(txtCoilID.Text) Then
                LoadCoilInfo()
                cmdAddCoil.Focus()
                If lstCoilIDSuggest.Visible Then
                    lstCoilIDSuggest.Visible = False
                End If
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

    Private Sub bgwkCoilIDSuggest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkCoilIDSuggest.DoWork
        Dim lst As New List(Of String)
        Dim cmd2 As SqlCommand = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status = 'RAW' and CoilID LIKE @CoilID;", con2)
        cmd2.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text + "%"

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
        If lstCoilIDSuggest.Items.Count < 5 Then
            If lstCoilIDSuggest.Items.Count = 0 Then
                lstCoilIDSuggest.Height = 40
            Else
                lstCoilIDSuggest.Height = lstCoilIDSuggest.Items.Count * 40
            End If
        Else
            lstCoilIDSuggest.Height = 5 * 20
        End If
        If FocusedField.Name.Equals("txtCoilID") Then
            lstCoilIDSuggest.Visible = True
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
        lstHeatSuggest.DataSource = Nothing
        If canSuggestHeat() Then
            If lstHeatSuggest.DisplayMember <> "HeatNumber" Then lstHeatSuggest.DisplayMember = "HeatNumber"
            Dim tmp As Data.DataRow() = ds5.Select("HeatNumber like '" + cboHeatNumber.Text + "%'", "HeatNumber ASC")
            If tmp.Length > 0 Then
                lstHeatSuggest.DataSource = tmp.CopyToDataTable()
            End If

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
            If Not String.IsNullOrEmpty(CType(lstHeatSuggest.SelectedItem, Data.DataRowView).Item("HeatNumber")) Then
                FocusedField = New FocusedItem()
                cboHeatNumber.Text = CType(lstHeatSuggest.SelectedItem, Data.DataRowView).Item("HeatNumber")
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

    Private Sub addText(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal tex As String, Optional ByVal charCount As Integer = 1)
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to see if there is a selection
            If FocusedField.SelectionLength > 0 Then
                cmdBackspace_Click(sender, e)
            End If
            If FocusedField.Position = FocusedField.Text.Length Then
                FocusedField.Text += tex
            Else
                If FocusedField.Position <> 0 Then
                    FocusedField.Position = FocusedField.Text.Length
                End If
                FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + tex + FocusedField.Text.Substring(FocusedField.Position, FocusedField.Text.Length - FocusedField.Position)
            End If
            If charCount > 1 Then
                FocusedField.Position += charCount - 1
            End If
            FocusedField.Focus()
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
                    If lstCoilIDSuggest.Items.Count = 1 Then
                        If Not txtCoilID.Text.Equals(lstCoilIDSuggest.Items(0)) Then
                            txtCoilID.Text = lstCoilIDSuggest.Items(0)
                            LoadCoilInfo()
                            cmdAddCoil.Focus()
                        End If
                    Else
                        SelectNextControl(Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name), True, True, True, True)
                    End If
                Case "cboCarbon"
                    If lstCarbonSuggest.Items.Count = 1 Then
                        If Not cboCarbon.Text.Equals(lstCarbonSuggest.Items(0)) Then
                            cboCarbon.Text = lstCarbonSuggest.Items(0)
                        End If
                    End If
                    SelectNextControl(Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name), True, True, True, True)
                Case "cboSteelSize"
                    If lstSizeSuggest.Items.Count = 1 Then
                        If Not cboSteelSize.Text.Equals(lstSizeSuggest.Items(0)) Then
                            cboSteelSize.Text = lstSizeSuggest.Items(0)
                        End If
                    End If
                    SelectNextControl(Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name), True, True, True, True)
                Case "cboHeatNumber"
                    If lstHeatSuggest.Items.Count = 1 Then
                        If Not cboHeatNumber.Text.Equals(lstHeatSuggest.Items(0)) Then
                            cboHeatNumber.Text = lstHeatSuggest.Items(0)
                        End If
                    End If
                    SelectNextControl(Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name), True, True, True, True)
                Case "txtInventoryID"
                    If lstInventoryIDSuggest.Items.Count = 1 Then
                        If Not txtInventoryID.Text.Equals(lstInventoryIDSuggest.Items(0)) Then
                            txtInventoryID.Text = lstInventoryIDSuggest.Items(0)
                            LoadCoilInfo()
                            lstInventoryIDSuggest.Visible = False
                            cmdAddCoil.Focus()
                        ElseIf txtInventoryID.Text.Equals(lstInventoryIDSuggest.Items(0)) Then
                            LoadCoilInfo()
                            lstInventoryIDSuggest.Visible = False
                            cmdAddCoil.Focus()
                        End If
                    End If
                Case Else
                    SelectNextControl(Me.Controls("gpxSteelCoilData").Controls(FocusedField.Name), True, True, True, True)
            End Select
        End If
    End Sub

    Private Sub cboCarbon_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCarbon.KeyUp
        If e.KeyCode = Keys.Back Then
            If cboCarbon.SelectionLength > 0 Then
                FocusedField.Position -= cboCarbon.SelectionLength
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub cboSteelSize_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelSize.KeyUp
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
        If e.KeyCode = Keys.Back Then
            If txtCoilID.SelectionLength > 0 Then
                FocusedField.Position -= txtCoilID.SelectionLength
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub txtCoilWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilWeight.TextChanged
        If Not wasDeleted Then
            FocusedField.Position += 1
        Else
            wasDeleted = False
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

    Private Sub checkCoilID()
        cmd = New SqlCommand("SELECT COUNT(CoilID) FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
        Dim test As Integer = 0
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            txtAnnealLot.ReadOnly = False
        Else
            con.Close()
            txtAnnealLot.ReadOnly = True
        End If
    End Sub

    Private Sub txtAnnealLot_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAnnealLot.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtAnnealLot") Then
                checkCoilID()
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(txtAnnealLot)
            Else
                txtAnnealLot.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(txtAnnealLot)
        End If
    End Sub

    Private Sub txtAnnealLot_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAnnealLot.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtAnnealLot.SelectionStart
            FocusedField.SelectionLength = txtAnnealLot.SelectionLength
        End If
    End Sub

    Private Sub txtAnnealLot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAnnealLot.TextChanged
        If isLoaded Then
            If txtAnnealLot.Focused Then
                FocusedField.Position = txtAnnealLot.SelectionStart
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
        End If
    End Sub

    Private Sub txtAnnealLot_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAnnealLot.MouseClick
        If txtAnnealLot.Focused Then
            FocusedField.position = txtAnnealLot.SelectionStart
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
        If txtInventoryID.Focused Then
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
            cmdAddCoil.Focus()
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
                cmdAddCoil.Focus()
            End If
        End If
    End Sub

    Private Sub cmdOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOSA.Click
        addText(sender, e, "OSA", 3)
    End Sub
End Class