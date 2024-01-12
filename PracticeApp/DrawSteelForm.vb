Imports System.Data.SqlClient

Public Class DrawSteelForm
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1 As New SqlDataAdapter
    Dim ds, ds1 As DataSet
    Dim GetRMID As String = ""

    Dim isLoaded As Boolean = False

    Dim FocusedField As New usefulFunctions.FocusedItem()
    Dim wasDeleted As Boolean = False

    ''***************************
    ''NEEDS TAKEN OUT
    'Dim EmployeeCompanyCode As String = "TST"
    'Dim EmployeeLoginName As String = "TEST"

    Private Sub LoadCoilID()
        bgwkLoadCoilID.RunWorkerAsync()
    End Sub

    Private Sub bgwkLoadCoilID_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkLoadCoilID.DoWork
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status = 'RAW';", con)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "CharterSteelCoilIdentification")
        con.Close()
    End Sub

    Private Sub DrawSteelForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds1 = New DataSet
        LoadCoilID()
        isLoaded = True
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub LoadCoilData()
        If isLoaded Then
            cmd = New SqlCommand("SELECT Carbon, SteelSize FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("Carbon")) Then
                    txtCoilCarbon.Text = ""
                Else
                    txtCoilCarbon.Text = reader.Item("Carbon")
                End If
                If IsDBNull(reader.Item("SteelSize")) Then
                    txtCoilSteelSize.Text = ""
                Else
                    txtCoilSteelSize.Text = reader.Item("SteelSize")
                End If
            Else
                txtCoilCarbon.Text = ""
                txtCoilSteelSize.Text = ""
            End If
            reader.Close()
            con.Close()

            If String.IsNullOrEmpty(txtCoilCarbon.Text) = False Then
                cmd = New SqlCommand("SELECT DISTINCT(SteelSize) FROM RawMaterialsTable WHERE Carbon = @Carbon;", con)
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtCoilCarbon.Text
                ds1 = New DataSet()
                myAdapter1.SelectCommand = cmd

                If con.State = ConnectionState.Closed Then con.Open()
                myAdapter1.Fill(ds1, "RawMaterialsTable")
                con.Close()

                Dim i As Integer = 0
                Dim currentSize As Double = getNumber(txtCoilSteelSize.Text)
                ''removes sizes equal to or greater than the current coil size
                While i < ds1.Tables("RawMaterialsTable").Rows.Count
                    Dim nbr As Double = getNumber(ds1.Tables("RawMaterialsTable").Rows(i).Item("SteelSize").ToString)
                    If nbr >= currentSize Then
                        ds1.Tables("RawMaterialsTable").Rows.RemoveAt(i)
                    Else
                        i += 1
                    End If
                End While
                cboNewSteelSize.DisplayMember = "SteelSize"
                cboNewSteelSize.DataSource = ds1.Tables("RawMaterialsTable")
                cboNewSteelSize.SelectedIndex = -1
            End If
        End If
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

    Private Sub cmdPostSizeChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostSizeChange.Click
        If canPost() Then
            'Get RMID from test fields - carbon, steel size
            Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
            Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
            GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtCoilCarbon.Text
            GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = txtCoilSteelSize.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetRMID = ""
            End Try
            con.Close()

            ''this will change the steel Carbon for each of the coils and will make the adjustment into the SteelAdjustmentTable
            cmd = New SqlCommand("SELECT Weight from CharterSteelCoilIdentification WHERE CoilID = @CoilID", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            Dim weight As Double = cmd.ExecuteScalar()
            Dim totalCost As Double = SteelModule.GetSteelCosting(GetRMID, weight, con, Now)
            Dim CostPerPound As Double = Math.Round(totalCost / weight, 5, MidpointRounding.AwayFromZero)
            Dim UsageKey As Integer = addUsageEntry(CostPerPound, totalCost, weight)
            addSteelTransaction(weight, CostPerPound, totalCost, UsageKey, txtCoilID.Text, "SUBTRACT")
            updateCoilSize(txtCoilID.Text)
            Dim addKey As Integer = addReturnToYardEntry(CostPerPound, totalCost, weight)
            addSteelTransaction(weight, CostPerPound, totalCost, addKey, txtCoilID.Text, "ADD")

            ''writes the cost Tier for the drawn steel
            addCostTier(totalCost)
            ''writes the annealing lot transfer to the GL
            writeToGL(totalCost, UsageKey)
            If con.State = ConnectionState.Open Then con.Close()
            ClearData()
        End If
    End Sub

    Private Function canPost() As Boolean
        If String.IsNullOrEmpty(txtCoilID.Text) Then
            MessageBox.Show("You must select a coil", "Select a coil", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilID.Focus()
            Return False
        End If
        cmd = New SqlCommand("SELECT Status FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
        Dim stat As String = "NONE"

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.HasRows Then
            reader.Read()
            stat = reader.GetValue(0)
        End If
        reader.Close()
        con.Close()
        Select Case stat
            Case "NONE"
                MessageBox.Show("Coil was not found. Check entered ID and try again", "Unable to POST", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            Case "OPEN"
                MessageBox.Show("Coil has not been received in. Receive in the coil then you can proceed", "Unable to POST", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            Case "WIP"
                MessageBox.Show("Coil is not in RAW status. Return coil back to yard first", "Unable to POST", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            Case "CLOSED"
                MessageBox.Show("Coil is showing that it has been completely used, unable to proceed.", "Unable to POST", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
        End Select
        If String.IsNullOrEmpty(cboNewSteelSize.Text) Then
            MessageBox.Show("You must select a new Size", "Select a new Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboNewSteelSize.Focus()
            Return False
        End If
        If cboNewSteelSize.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Size.", "Enter a valid Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboNewSteelSize.SelectAll()
            cboNewSteelSize.Focus()
            Return False
        End If
        If DialogResult.Yes <> MessageBox.Show("This process is not reversable. Do you wish to change the Size for the specified Coil?", "Change Size", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            Return False
        End If
        Return True
    End Function

    Private Function addUsageEntry(ByVal SteelCost As Double, ByVal ExtendedCost As Double, ByVal weight As Double) As Integer
        'Get RMID from test fields - carbon, steel size
        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtCoilCarbon.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = txtCoilSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetRMID = ""
        End Try
        con.Close()

        'Insert Into Database
        cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(SteelUsageKey)+1, 22000000) FROM SteelUsageTable);INSERT INTO SteelUsageTable (SteelUsageKey, UsageDate, ReferenceNumber, ReferenceLineNumber, UsageWeight, SteelCost, ExtendedCost, RMID, DivisionID, Status, PrintDate) VALUES(@Key, @Date, @ReferenceNumber, @ReferenceLineNumber, @Weight, @SteelCost, @ExtendedCost, @RMID, @DivisionID, 'POSTED', @PrintDate); SELECT @Key;", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Now
            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = "0"
            .Add("@ReferenceLineNumber", SqlDbType.Int).Value = 0
            .Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
            .Add("@Weight", SqlDbType.Float).Value = weight
            .Add("@RMID", SqlDbType.VarChar).Value = GetRMID
            .Add("@PrintDate", SqlDbType.DateTime2).Value = Now
            .Add("@SteelCost", SqlDbType.Float).Value = SteelCost
            .Add("@ExtendedCost", SqlDbType.Float).Value = ExtendedCost
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Dim UsageKey As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        Return UsageKey
    End Function

    Private Function addReturnToYardEntry(ByVal SteelCost As Double, ByVal ExtendedCost As Double, ByVal weight As Double) As Integer
        'Get RMID from test fields - carbon, steel size
        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtCoilCarbon.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboNewSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetRMID = ""
        End Try
        con.Close()

        'Insert INTO Database
        cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(SteelReturnKey) + 1, 63000001) FROM SteelYardEntryTable); INSERT INTO SteelYardEntryTable (SteelReturnKey, ReturnDate, CoilID, ReturnWeight, SteelCost, ExtendedCost, RMID, DivisionID, Status, HeatNumber, Comment, ReferenceNumber, ReferenceLineNumber, PrintDate) VALUES (@Key, @ReturnDate, @CoilID, @Weight, @SteelCost, @ExtendedCost, @RMID, @DivisionID, 'POSTED', (SELECT HeatNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID), 'DRAWN WIRE', @ReferenceNumber, 0, @PrintDate); SELECT @Key;", con)

        With cmd.Parameters
            .Add("@ReturnDate", SqlDbType.Date).Value = Now
            .Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
            .Add("@RMID", SqlDbType.VarChar).Value = GetRMID
            .Add("@Weight", SqlDbType.Float).Value = weight
            .Add("@ReferenceNumber", SqlDbType.Int).Value = 0
            .Add("@SteelCost", SqlDbType.Float).Value = SteelCost
            .Add("@ExtendedCost", SqlDbType.Float).Value = ExtendedCost
            .Add("@PrintDate", SqlDbType.Date).Value = Now
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Return cmd.ExecuteScalar()
    End Function

    Private Sub writeToGL(ByVal totalCost As Double, ByVal UsageKey As Integer)

        cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)

        cmd.CommandText += "(@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, 0, @GLTransactionStatus)"
        With cmd.Parameters
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"
            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Draw"
            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = Today.Date.ToString()
            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = totalCost
            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
            .Add("@GLReferenceNumber", SqlDbType.Int).Value = UsageKey
            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Steel Draw Coil ID #" & txtCoilID.Text
            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        cmd.CommandText += ", (@Key + 1, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, 0, @GLTransactionStatus)"

        With cmd.Parameters
            .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = 0
            .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = totalCost
        End With

        cmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            sendErrorToDataBase("DrawSteelForm - writeToGL --Error trying to write entries into GL", "Coil #" + txtCoilID.Text, ex.ToString())
        End Try
        '**********************************
        'End of Ledger Entry
        '**********************************
    End Sub

    ''add entry into steel transaction table for either adding or subtracting
    Private Sub addSteelTransaction(ByVal weight As Double, ByVal CostPerPound As Double, ByVal steelCost As Double, ByRef Key As Integer, ByVal coil As String, ByVal mat As String)
        ''inserts the entry into the SteelTransactionTable
        cmd = New SqlCommand("INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType, SteelTransactionDate) VALUES((SELECT isnull(MAX(TransactionNumber) + 1,7700001) FROM SteelTransactionTable), @DivisionID, @Carbon, @SteelSize, @Quantity, @SteelCost, @ExtendedCost, @SteelReferenceNumber, @SteelReferenceLine, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @TransactionMath, @TransactionType, @SteelTransactionDate);", con)
        If mat.Equals("ADD") Then
            cmd.Parameters.Add("@TransactionType", SqlDbType.VarChar).Value = "STEEL YARD ENTRY"
        Else
            cmd.Parameters.Add("@TransactionType", SqlDbType.VarChar).Value = "WIRE YARD REMOVED"
        End If

        With cmd.Parameters
            .Add("@SteelReferenceNumber", SqlDbType.Int).Value = Key
            .Add("@Quantity", SqlDbType.Float).Value = Math.Round(weight, 2, MidpointRounding.AwayFromZero)
            .Add("@SteelCost", SqlDbType.VarChar).Value = CostPerPound
            .Add("@ExtendedCost", SqlDbType.Float).Value = steelCost
            .Add("@SteelReferenceLine", SqlDbType.Int).Value = 0
            .Add("@Carbon", SqlDbType.VarChar).Value = txtCoilCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = txtCoilSteelSize.Text
            .Add("@TransactionMath", SqlDbType.VarChar).Value = mat
            .Add("@SteelTransactionDate", SqlDbType.Date).Value = Now
        End With
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
    End Sub

    ''updates the carbon for the coil so that it is showin as Annealed
    Private Sub updateCoilSize(ByVal coil As String)
        Try
            'UPDATE Steel Coil to Annealed Carbon Type
            cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET SteelSize = @Size WHERE CoilID = @CoilID;", con)

            With cmd.Parameters
                .Add("@CoilID", SqlDbType.VarChar).Value = coil
                .Add("@Size", SqlDbType.VarChar).Value = cboNewSteelSize.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            sendErrorToDataBase("DrawSteelForm - updateCoilSize --Error trying to update CharterSteelCoilIdentification table to new size " + cboNewSteelSize.Text, "Coil ID #" + coil, ex.ToString())
        End Try
    End Sub

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

    Private Sub addCostTier(ByVal totalCost As Double)
        Dim NewUpperLimit, LowerLimit, UpperLimit, weight As Double

        cmd = New SqlCommand("SELECT Weight FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            weight = CDbl(cmd.ExecuteScalar())
        Catch ex As System.Exception
            weight = 0.0
        End Try

        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize));"
        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
        UpperLimitCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtCoilCarbon.Text
        UpperLimitCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboNewSteelSize.Text

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
            cmd = New SqlCommand("Insert Into SteelCostingTable (RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values((SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @Carbon, @SteelSize, @CostingDate, @SteelCostPerPound, @CostingQuantity, @Status, @LowerLimit, @UpperLimit, (SELECT isnull(MAX(TransactionNumber) + 1, 73700001) FROM SteelCostingTable), @ReferenceNumber, @ReferenceLine);", con)

            With cmd.Parameters
                .Add("@Carbon", SqlDbType.VarChar).Value = txtCoilCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = cboNewSteelSize.Text
                .Add("@CostingDate", SqlDbType.VarChar).Value = Today.Date.ToString()
                .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = Math.Round(totalCost / weight, 4)
                .Add("@CostingQuantity", SqlDbType.VarChar).Value = weight
                .Add("@Status", SqlDbType.VarChar).Value = "STEEL DRAW"
                .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = 0
                .Add("@ReferenceLine", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            sendErrorToDataBase("DrawStelForm - addCostTiers --Error trying to inserting Steel Size change into SteelCostingTable", "Coil ID #" + txtCoilID.Text, ex.ToString())
            MessageBox.Show("There was an issue with updating cost tiers. Contact system admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearData()
    End Sub

    Private Sub ClearData()
        isLoaded = False
        txtCoilID.Clear()
        ds1.Clear()
        cboNewSteelSize.SelectedIndex = -1
        cboNewSteelSize.Text = ""
        txtCoilCarbon.Text = ""
        txtCoilSteelSize.Text = ""
        isLoaded = True
        lstCoilIDSuggest.Items.Clear()
        lstSizeSuggest.Items.Clear()
        txtCoilID.Focus()
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

    Private Sub cmdDash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDash.Click
        addText(sender, e, "-")
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

    Private Sub cmdTWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTWD.Click
        addText(sender, e, "TWD", 3)
    End Sub

    Private Sub cmdBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackspace.Click
        If Not String.IsNullOrEmpty(FocusedField.name) Then
            ''check to make sure there is something to delete
            If Me.Controls(FocusedField.name).Text.Length > 0 Then
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

    Private Sub addText(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal tex As String, Optional ByVal charCount As Integer = 1)
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
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
            If charCount > 1 Then
                FocusedField.Position += charCount - 1
            End If
            FocusedField.Focus()
        End If
    End Sub

    Private Sub txtCoilID_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCoilID.MouseClick
        If txtCoilID.Focused Then
            FocusedField.Position = txtCoilID.SelectionStart
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
                lstCoilIDSuggest.Hide()
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
        If String.IsNullOrEmpty(FocusedField.Name) Then
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Hide()
            End If
            Return False
        End If
        If Not FocusedField.Name.Equals("txtCoilID") Then
            Return False
        End If
        If txtCoilID.Focused AndAlso txtCoilID.Text.Length <= 3 Then
            Return False
        End If
        If txtCoilID.Text.Length = 0 Then
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Hide()
            End If
            Return False
        End If
        Return True
    End Function

    Private Sub txtCoilID_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCoilID.MouseUp
        If txtCoilID.Focused Then
            FocusedField.Position = txtCoilID.SelectionStart
            FocusedField.SelectionLength = txtCoilID.SelectionLength
        End If
    End Sub

    Private Sub lstCoilIDSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCoilIDSuggest.SelectedValueChanged
        If lstCoilIDSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstCoilIDSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                txtCoilID.Text = lstCoilIDSuggest.SelectedItem
                LoadCoilData()
                lstCoilIDSuggest.Hide()
                cboNewSteelSize.SelectAll()
                cboNewSteelSize.Focus()
            End If
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
            lstCoilIDSuggest.Show()
        End If
    End Sub

    Private Sub cboNewSteelSize_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNewSteelSize.DropDown
        If lstSizeSuggest.Visible Then
            lstSizeSuggest.Hide()
        End If
    End Sub

    Private Sub cboNewSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNewSteelSize.TextChanged
        If lstSizeSuggest.Visible Then
            lstSizeSuggest.Hide()
        End If
        If Not wasDeleted Then
            FocusedField.Position += 1
        Else
            wasDeleted = False
        End If
        lstSizeSuggest.Items.Clear()
        If canSuggestSize() Then
            For i As Integer = 0 To ds1.Tables("RawMaterialsTable").Rows.Count - 1
                If ds1.Tables("RawMaterialsTable").Rows(i).Item("SteelSize").ToString().Contains(cboNewSteelSize.Text) Then
                    lstSizeSuggest.Items.Add(ds1.Tables("RawMaterialsTable").Rows(i).Item("SteelSize").ToString())
                End If
            Next
            If lstSizeSuggest.Items.Count > 1 Then
                If lstSizeSuggest.Items.Count < 5 Then
                    If lstSizeSuggest.Items.Count = 0 Then
                        lstSizeSuggest.Height = 40
                    Else
                        lstSizeSuggest.Height = lstSizeSuggest.Items.Count * 40
                    End If
                Else
                    lstSizeSuggest.Height = 5 * 20
                End If
                lstSizeSuggest.Show()
            End If
        End If
    End Sub

    Private Function canSuggestSize() As Boolean
        If String.IsNullOrEmpty(FocusedField.Name) Then
            If lstSizeSuggest.Visible Then
                lstSizeSuggest.Hide()
            End If
            Return False
        End If
        If Not FocusedField.Name.Equals("cboNewSteelSize") Then
            Return False
        End If
        If cboNewSteelSize.Text.Length = 0 Then
            If lstSizeSuggest.Visible Then
                lstSizeSuggest.Hide()
            End If
            Return False
        End If
        If ds1.Tables.Count < 1 Then
            Return False
        End If
        Return True
    End Function

    Private Sub cboNewSteelSize_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboNewSteelSize.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = cboNewSteelSize.SelectionStart
            FocusedField.SelectionLength = cboNewSteelSize.SelectionLength
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

    Private Sub cboNewSteelSize_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNewSteelSize.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboNewSteelSize") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(cboNewSteelSize)
            Else
                cboNewSteelSize.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(cboNewSteelSize)
        End If
    End Sub

    Private Sub hideSuggest(ByVal ctrl As String)
        If Not String.IsNullOrEmpty(ctrl) Then
            Select Case ctrl
                Case "txtCoilID"
                    lstCoilIDSuggest.Hide()
                Case "cboNewSteelSize"
                    lstSizeSuggest.Hide()
            End Select
        End If
    End Sub


    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If FocusedField.isSet() Then
            Select Case FocusedField.Name
                Case "txtCoilID"
                    If lstCoilIDSuggest.Items.Count = 1 Then
                        If Not txtCoilID.Text.Equals(lstCoilIDSuggest.Items(0)) Then
                            txtCoilID.Text = lstCoilIDSuggest.Items(0)
                            LoadCoilData()
                        End If
                    End If
                    cboNewSteelSize.SelectAll()
                    cboNewSteelSize.Focus()
                Case "cboNewSteelSize"
                    If lstSizeSuggest.Items.Count = 1 Then
                        If Not cboNewSteelSize.Text.Equals(lstSizeSuggest.Items(0)) Then
                            cboNewSteelSize.Text = lstSizeSuggest.Items(0)
                        End If
                    End If
                    cmdPostSizeChange.Focus()
                Case Else
                    SelectNextControl(Me.Controls(FocusedField.Name), True, True, True, True)
            End Select
        End If
    End Sub

    Private Sub cmdPostSizeChange_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostSizeChange.Enter
        If FocusedField.isSet() Then
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        wasDeleted = True
        FocusedField.Text = ""
        FocusedField.Position = 0
        FocusedField.SelectionLength = 0
    End Sub

    Private Sub lstSizeSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSizeSuggest.SelectedValueChanged
        If lstSizeSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstSizeSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                cboNewSteelSize.Text = lstSizeSuggest.SelectedItem
                lstSizeSuggest.Hide()
                cmdPostSizeChange.Focus()
            End If
        End If
    End Sub

    Private Sub txtCoilID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilID.KeyUp
        If e.KeyCode = Keys.Enter Then
            LoadCoilData()
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Hide()
            End If
            cboNewSteelSize.Focus()
        End If
    End Sub
End Class