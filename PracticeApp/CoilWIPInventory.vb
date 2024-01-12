Imports System.Data.SqlClient

Public Class CoilWIPInventory
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim ds, ds1 As DataSet

    Dim isLoaded As Boolean = False
    Dim controlKey As Boolean = False
    Dim FocusedField As New usefulFunctions.FocusedItem()

    Public Sub New()
        InitializeComponent()
        ds1 = New DataSet()
        LoadCoils()
        LoadList()
        LoadCarbonSize()
        If con.State = ConnectionState.Open Then con.Close()
        isLoaded = True

        If Environment.MachineName.ToLower.Contains("tablet") Then ''Or Environment.MachineName.ToLower.Contains("agler") Then
            dgvWIPCoils.Size = New System.Drawing.Size(872, 365)
            Me.Size = New System.Drawing.Size(1200, 750)
            gpxKeyboard.Show()
        End If
    End Sub

    Private Sub LoadCoils()
        cmd = New SqlCommand("SELECT CoilID, Carbon, SteelSize, Weight FROM CharterSteelCoilIdentification", con)
        ds = New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "CharterSteelCoilIdentification")

        cboCoilID.DisplayMember = "CoilID"
        cboCoilID.DataSource = ds.Tables("CharterSteelCoilIdentification")
        cboCoilID.SelectedIndex = -1
    End Sub

    Private Sub LoadList()
        cmd = New SqlCommand("SELECT InventoryKey, CoilID, Carbon, SteelSize, Weight, Cost FROM TFPInventoryCoilWIP ORDER BY InventoryKey", con)
        Dim adap As New SqlDataAdapter(cmd)
        ds1 = New DataSet()
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds1, "TFPInventoryCoilWIP")

        dgvWIPCoils.DataSource = ds1.Tables("TFPInventoryCoilWIP")

        dgvWIPCoils.Columns("InventoryKey").Visible = False
        dgvWIPCoils.Columns("CoilID").HeaderText = "Coil ID"
        dgvWIPCoils.Columns("SteelSize").HeaderText = "Steel Size"
    End Sub

    Private Sub LoadCarbonSize()
        cmd = New SqlCommand("SELECT DISTINCT(Carbon) as Carbon FROM RawMaterialsTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("Carbon")) Then
                    cboCarbon.Items.Add(reader.Item("Carbon"))
                End If
            End While
        End If
        reader.Close()
        cmd = New SqlCommand("SELECT DISTINCT(SteelSize) as SteelSize FROM RawMaterialsTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("SteelSize")) Then
                    cboSteelSize.Items.Add(reader.Item("SteelSize"))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub cboCoilID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoilID.SelectedIndexChanged
        If isLoaded Then
            cboCarbon.Text = ds.Tables("CharterSteelCoilIdentification").Rows(cboCoilID.SelectedIndex).Item("Carbon")
            cboSteelSize.Text = ds.Tables("CharterSteelCoilIdentification").Rows(cboCoilID.SelectedIndex).Item("SteelSize")
            txtWeight.Text = ds.Tables("CharterSteelCoilIdentification").Rows(cboCoilID.SelectedIndex).Item("Weight")
        End If
    End Sub

    Private Sub txtWeight_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWeight.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Then
            controlKey = True
        End If
    End Sub

    Private Sub txtWeight_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWeight.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If canAdd() Then
            Dim totalCost As Double = getSteelCosting()
            cmd = New SqlCommand("INSERT INTO TFPInventoryCoilWIP (InventoryKey, CoilID, Carbon, SteelSize, Weight, Cost) VALUES ((SELECT isnull(MAX(InventoryKey) + 1, 1) FROM TFPInventoryCoilWIP), @CoilID, @Carbon, @SteelSize, @Weight, @Cost)", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text
            cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = Val(txtWeight.Text)
            cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = totalCost

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                cmd.ExecuteNonQuery()
            Catch ex As System.Exception
                MessageBox.Show("There was a problem adding the coil to the list.", "Unable to add coil", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            ClearAdd()
            LoadList()
        End If

        If con.State = ConnectionState.Open Then con.Close()
        cboCoilID.Focus()
    End Sub

    Private Function canAdd() As Boolean
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
        If String.IsNullOrEmpty(cboCarbon.Text) Then
            MessageBox.Show("You must have a Carbon entered", "Enter a carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCarbon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelSize.Text) Then
            MessageBox.Show("You must enter a steel size", "Enter a steel size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtWeight.Text) Then
            MessageBox.Show("You must enter a weight", "Enter a weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWeight.Focus()
            Return False
        End If
        If Not IsNumeric(txtWeight.Text) Then
            MessageBox.Show("You must enter a number for weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWeight.SelectAll()
            txtWeight.Focus()
            Return False
        End If
        cmd = New SqlCommand("SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            MessageBox.Show("The Carbon/Size entered does not exist in the system, unable to add.", "RMID doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.SelectAll()
            cboCoilID.Focus()
            Return False
        End If
        Return True
    End Function
    ''gets the steel cost
    Private Function getSteelCosting() As Double
        Dim totalUsed As Double = 0
        Dim rmid As String = ""
        Dim Weight As Double = 0
        cmd = New SqlCommand("SELECT isnull(SUM(UsageWeight), 0) as TotalUsageWeight, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) as RMID FROM SteelUsageTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) and Status = 'POSTED' AND DivisionID = 'TWD';", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        Weight = Val(txtWeight.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            totalUsed = reader.Item("TotalUsageWeight")
            If Not IsDBNull(reader.Item("RMID")) Then
                rmid = reader.Item("RMID")
            Else
                reader.Close()
                con.Close()
                MessageBox.Show("Grade and Size of coil does not produce an RMID. Costing will be 0.", "Unable to cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

        End If
        reader.Close()

        Dim totalCost As Double = 0.0
        Dim contin As Boolean = True
        Dim upperLimit As Double = 0.0

        While contin
            contin = False
            'Extract the Cost of Steel
            Dim SteelCost As Double = 0.0
            Dim lowerLimit As Double = 0.0

            Dim SteelCostCommand As New SqlCommand("", con)
            SteelCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = rmid

            If upperLimit > 0 Then
                SteelCostCommand.CommandText = "SELECT SteelCostPerPound, UpperLimit, LowerLimit FROM SteelCostingTable WHERE RMID = @RMID AND @nextTier BETWEEN LowerLimit AND UpperLimit;"
                SteelCostCommand.Parameters.Add("@nextTier", SqlDbType.VarChar).Value = upperLimit + 1
            Else
                SteelCostCommand.CommandText = "SELECT SteelCostPerPound, UpperLimit, LowerLimit FROM SteelCostingTable WHERE RMID = @RMID AND @start BETWEEN LowerLimit AND UpperLimit;"

                If totalUsed <> 0 Then
                    SteelCostCommand.Parameters.Add("@start", SqlDbType.VarChar).Value = totalUsed
                Else
                    SteelCostCommand.Parameters.Add("@start", SqlDbType.VarChar).Value = 1
                End If
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            reader = SteelCostCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("SteelCostPerPound")) = False Then
                    SteelCost = reader.Item("SteelCostPerPound")
                End If
                If IsDBNull(reader.Item("UpperLimit")) = False Then
                    upperLimit = reader.Item("UpperLimit")
                End If
                If IsDBNull(reader.Item("LowerLimit")) = False Then
                    lowerLimit = reader.Item("LowerLimit")
                End If
            End If
            reader.Close()
            'Extract Last Purchase Cost of Steel if Steel Cost is 0
            If SteelCost = 0 Then
                Dim LastSteelPrice As Double = 0
                'Load values into Cost Field
                Dim LastPriceStatement As String = "SELECT SteelCostPerPound FROM SteelReceivingLineQuery WHERE SteelReceivingHeaderKey = (SELECT MAX(SteelReceivingHeaderKey) FROM SteelReceivingLineQuery WHERE DivisionID = 'TWD' AND RMID = @RMID) AND RMID = @RMID;"
                Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                LastPriceCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = rmid

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastSteelPrice = CDbl(LastPriceCommand.ExecuteScalar)
                    SteelCost = LastSteelPrice
                Catch ex As System.Exception
                    LastSteelPrice = 0
                    SteelCost = LastSteelPrice
                End Try
                ''sets the upper limit above the weight so that it will exit since it had to get last purchase cost
                upperLimit += Weight + totalUsed + 1
            End If
            If totalUsed <> 0 Then
                If Weight + totalUsed <= upperLimit Then
                    totalCost += Math.Round(Weight * SteelCost, 2)
                Else
                    contin = True
                    totalCost += Math.Round((upperLimit - totalUsed) * SteelCost, 2)
                    Weight = Weight - (upperLimit - totalUsed)
                    totalUsed = 0
                End If
            Else
                If Weight <= upperLimit + 1 - lowerLimit Then
                    totalCost += Math.Round(Weight * SteelCost, 2)
                Else
                    contin = True
                    totalCost += Math.Round((upperLimit - lowerLimit + 1) * SteelCost, 2)
                    Weight = Weight - (upperLimit - lowerLimit + 1)
                End If
            End If
        End While
        Return totalCost
    End Function

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearAdd()
        cboCoilID.Focus()
    End Sub

    Private Sub ClearAdd()
        isLoaded = False
        cboCoilID.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCoilID.Text) Then
            cboCoilID.Text = ""
        End If
        cboCarbon.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cboCarbon.Text = ""
        End If
        cboSteelSize.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If
        txtWeight.Clear()
        isLoaded = True
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

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If MessageBox.Show("Are you sure you wish to delete the entry?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then


            If dgvWIPCoils.SelectedCells.Count > 0 Then
                Dim lst As New List(Of Integer)

                For i As Integer = 0 To dgvWIPCoils.SelectedCells.Count - 1
                    If Not lst.Contains(dgvWIPCoils.SelectedCells(i).RowIndex) Then
                        lst.Add(dgvWIPCoils.SelectedCells(i).RowIndex)
                    End If
                Next
                cmd = New SqlCommand("DELETE TFPInventoryCoilWIP WHERE ", con)
                For i As Integer = 0 To lst.Count - 1
                    If i = 0 Then
                        cmd.CommandText += "InventoryKey = @InventoryKey" + i.ToString
                    Else
                        cmd.CommandText += " OR InventoryKey = @InventoryKey" + i.ToString
                    End If
                    cmd.Parameters.Add("@InventoryKey" + i.ToString, SqlDbType.VarChar).Value = dgvWIPCoils.Rows(lst(i)).Cells("InventoryKey").Value
                Next
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                LoadList()
                If con.State = ConnectionState.Open Then con.Close()
            Else
                MessageBox.Show("There are no selected cells.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DeleteAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you wish to delete ALL entries?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            cmd = New SqlCommand("DELETE TFPInventoryCoilWIP", con)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            LoadList()
            If con.State = ConnectionState.Open Then con.Close()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim newViewInventoryCoilWIP As New ViewInventoryCoilWIP(ds1)
        newViewInventoryCoilWIP.ShowDialog()
    End Sub
    ''input section start
    Private Sub cmdZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZero.Click
        addText(sender, e, "0")
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

    Private Sub addText(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal tex As String, Optional ByVal charCount As Integer = 1)
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to see if there is a selection
            If FocusedField.SelectionLength > 0 Then
                cmdBackspace_Click(sender, e)
            End If
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
            FocusedField.Focus()
        End If
    End Sub

    Private Sub cmdBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackspace.Click
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to make sure there is something to delete
            If FocusedField.Text.Length > 0 Then
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

    Private Sub cboCoilID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoilID.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboCoilID") Then
                FocusedField = New usefulFunctions.FocusedItem(cboCoilID)
            Else
                cboCoilID.SelectionStart = FocusedField.Position
                If cboCoilID.Text.Length > 4 Then
                    lstCoilSuggest.Hide()
                    lstCoilSuggest.DataSource = Nothing
                    cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE CoilID LIKE @CoilID", con)
                    cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text + "%"

                    Dim tempds As New DataSet()
                    Dim adap As New SqlDataAdapter(cmd)

                    If con.State = ConnectionState.Closed Then con.Open()
                    adap.Fill(tempds, "CharterSteelCoilIdentification")
                    con.Close()
                    lstCoilSuggest.DisplayMember = "CoilID"
                    lstCoilSuggest.ValueMember = "CoilID"
                    lstCoilSuggest.DataSource = tempds.Tables("CharterSteelCoilIdentification")
                    If lstCoilSuggest.Items.Count > 0 Then
                        If Not cboCoilID.Text.Equals(lstCoilSuggest.SelectedValue) Then
                            lstCoilSuggest.Show()
                        End If
                    End If
                End If
            End If
        Else
            FocusedField = New usefulFunctions.FocusedItem(cboCoilID)
        End If
    End Sub

    Private Sub lstCoilSuggest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCoilSuggest.SelectedIndexChanged
        If lstCoilSuggest.Visible Then
            Dim obj As Object = lstCoilSuggest.SelectedValue
            If Not String.IsNullOrEmpty(lstCoilSuggest.SelectedValue) Then
                FocusedField = New usefulFunctions.FocusedItem()
                cboCoilID.Text = lstCoilSuggest.SelectedValue
                lstCoilSuggest.Visible = False
                txtWeight.Focus()
            End If
        End If
    End Sub

    Private Sub cboCoilID_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboCoilID.MouseUp
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Name.Equals("cboCoilID") Then
                FocusedField.Position = cboCoilID.SelectionStart
                FocusedField.SelectionLength = cboCoilID.SelectionLength
            End If
        End If
    End Sub

    Private Sub txtWeight_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWeight.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtWeight") Then
                FocusedField = New usefulFunctions.FocusedItem(txtWeight)
            Else
                txtWeight.SelectionStart = FocusedField.Position
            End If
        Else
            FocusedField = New usefulFunctions.FocusedItem(txtWeight)
        End If
    End Sub

    Private Sub txtWeight_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtWeight.MouseUp
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Name.Equals("txtWeight") Then
                FocusedField.Position = txtWeight.SelectionStart
                FocusedField.SelectionLength = txtWeight.SelectionLength
            End If
        End If
    End Sub

    Private Sub cmdClearSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearSelected.Click
        If FocusedField.isSet() Then
            Me.Controls(FocusedField.name).Text = ""
            Me.Controls(FocusedField.name).Focus()
        End If
    End Sub

    Private Sub cmdKeyboardEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKeyboardEnter.Click
        If FocusedField.Name.Equals("cboCoilID") Then
            txtWeight.Focus()
        Else
            cmdAdd.Focus()
        End If
    End Sub

    Private Sub cboCoilID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCoilID.KeyUp
        If e.KeyCode = Keys.Enter Then
            If cboCoilID.Text.Length > 1 Then
                If cboCoilID.Text(0).ToString.ToLower.Equals("s") Then
                    cboCoilID.Text = cboCoilID.Text.Substring(1)
                End If
            End If
            txtWeight.Focus()
        End If
    End Sub

    Private Sub cboCarbon_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboCarbon") Then
                FocusedField = New usefulFunctions.FocusedItem(cboCarbon)
            Else
                cboCarbon.SelectionStart = FocusedField.Position
            End If
        Else
            FocusedField = New usefulFunctions.FocusedItem(cboCarbon)
        End If
    End Sub

    Private Sub cboCarbon_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCarbon.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboSteelSize.Focus()
        End If
    End Sub

    Private Sub cboCarbon_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboCarbon.MouseUp
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Name.Equals("cboCarbon") Then
                FocusedField.Position = cboCarbon.SelectionStart
                FocusedField.SelectionLength = cboCarbon.SelectionLength
            End If
        End If
    End Sub

    Private Sub cboSteelSize_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboSteelSize") Then
                FocusedField = New usefulFunctions.FocusedItem(cboSteelSize)
            Else
                cboSteelSize.SelectionStart = FocusedField.Position
            End If
        Else
            FocusedField = New usefulFunctions.FocusedItem(cboSteelSize)
        End If
    End Sub

    Private Sub cboSteelSize_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelSize.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtWeight.Focus()
        End If
    End Sub

    Private Sub cboSteelSize_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboSteelSize.MouseUp
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Name.Equals("cboCarbon") Then
                FocusedField.Position = cboCarbon.SelectionStart
                FocusedField.SelectionLength = cboCarbon.SelectionLength
            End If
        End If
    End Sub

    Private Sub cmdForwardSlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForwardSlash.Click
        addText(sender, e, "/")
    End Sub
End Class