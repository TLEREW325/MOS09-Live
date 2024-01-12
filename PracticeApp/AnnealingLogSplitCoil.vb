Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class AnnealingLogSplitCoil
    ''used for printing labels
    Dim LabelFormat(20) As String
    Dim LabelLines As Integer

    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim newIDs As New List(Of String)
    Dim bc As New BarcodeLabel
    Dim neededLabels As List(Of String)

    '*********************
    'NEEDS REMOVED
    'Dim EmployeeCompanyCode As String = "TST"
    '**********
    Dim origWeight As Double = 0
    Dim FocusedField As New usefulFunctions.FocusedItem()
    Dim wasDeleted As Boolean = False
    Dim notFinished As Boolean = False

  

    Private Sub cboFirstWhere_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirstWhere.SelectedIndexChanged
        If cboFirstWhere.SelectedIndex = 1 Or cboFirstWhere.SelectedIndex = 2 Or cboFirstWhere.SelectedIndex = 3 Then
            chkFirstPrintLabel.Checked = True
        Else
            chkFirstPrintLabel.Checked = False
        End If
    End Sub

    Private Sub cboSecondWhere_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecondWhere.SelectedIndexChanged
        If cboSecondWhere.SelectedIndex = 1 Or cboSecondWhere.SelectedIndex = 2 Or cboSecondWhere.SelectedIndex = 3 Then
            chkSecondPrintLabel.Checked = True
        Else
            chkSecondPrintLabel.Checked = False
        End If
    End Sub

    Private Sub cmdSplitCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSplitCoil.Click
        If FocusedField.isSet() Then
            FocusedField = New usefulFunctions.FocusedItem()
        End If
        If canSplit() Then
            If assignCoilID() Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Yes
                Me.Close()
            End If
        End If
    End Sub

    Private Function canSplit()
        If String.IsNullOrEmpty(cboFirstWhere.Text) Then
            MessageBox.Show("You must enter a where for the first part.", "Enter a Where for part One", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFirstWhere.Focus()
            Return False
        End If
        If cboFirstWhere.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Where for Part One.", "Enter a valid Where for Part One", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFirstWhere.SelectAll()
            cboFirstWhere.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtFirstWeight.Text) Then
            MessageBox.Show("You must enter a weight for Part One", "Enter a weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFirstWhere.Focus()
            Return False
        End If
        If IsNumeric(txtFirstWeight.Text) = False Then
            MessageBox.Show("You must enter a numeric weight for Part One.", "Enter a numeric weight for Part One", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstWeight.SelectAll()
            txtFirstWeight.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSecondWhere.Text) Then
            MessageBox.Show("You must enter a where for the Second part.", "Enter a Where for part Two", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSecondWhere.Focus()
            Return False
        End If
        If cboSecondWhere.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Where for Part Two.", "Enter a valid Where for Part Two", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSecondWhere.SelectAll()
            cboSecondWhere.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtSecondWeight.Text) Then
            MessageBox.Show("You must enter a weight for Part Two", "Enter a weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSecondWeight.Focus()
            Return False
        End If
        If IsNumeric(txtSecondWeight.Text) = False Then
            MessageBox.Show("You must enter a numeric weight for Part Two.", "Enter a numeric weight for Part Two", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSecondWeight.SelectAll()
            txtSecondWeight.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Function assignCoilID() As Boolean
        Dim heatNumber As String = ""
        Dim lotNumber As String = ""
        Dim carbon As String = ""
        Dim steelSize As String = ""
        Dim ReceiveDate As String = Today.Date.ToString()
        Dim DespatchNumber As String = ""
        Dim SONumber As String = ""
        Dim PONumber As String = ""
        Dim description As String = ""
        ''gets the coil information so that it can add it to the new Coil ID
        cmd = New SqlCommand("SELECT HeatNumber, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesOrderNumber, PurchaseOrderNumber, Description FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCurrentCoilID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("HeatNumber")) = False Then
                heatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("LotNumber")) = False Then
                lotNumber = reader.Item("LotNumber")
            End If
            If IsDBNull(reader.Item("Carbon")) = False Then
                carbon = reader.Item("Carbon")
            End If
            If IsDBNull(reader.Item("SteelSize")) = False Then
                steelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("ReceiveDate")) = False Then
                ReceiveDate = reader.Item("ReceiveDate")
            End If
            If IsDBNull(reader.Item("DespatchNumber")) = False Then
                DespatchNumber = reader.Item("DespatchNumber")
            End If
            If IsDBNull(reader.Item("SalesOrderNumber")) = False Then
                SONumber = reader.Item("SalesOrderNumber")
            End If
            If IsDBNull(reader.Item("PurchaseOrderNumber")) = False Then
                PONumber = reader.Item("PurchaseOrderNumber")
            End If
            If IsDBNull(reader.Item("Description")) = False Then
                description = reader.Item("Description")
            End If
        Else
            reader.Close()
            MessageBox.Show("Unable to locate Coil information.", "Unable to obtain Coil Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        reader.Close()
        con.Close()
        'checks the weights to make sure they are less than the origional coil
        If origWeight < (Val(txtFirstWeight.Text) + Val(txtSecondWeight.Text)) Then
            MessageBox.Show("Weights entered exceed the originating coil weight, check weights and try again. If problem persists contact system admin.", "Check entered weights", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstWeight.SelectAll()
            txtFirstWeight.Focus()
            Return False
        End If

        cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Weight = @Weight WHERE CoilID = @CoilID", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCurrentCoilID.Text
        cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = txtFirstWeight.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        newIDs.Add(txtCurrentCoilID.Text)
        Dim coil As String = ""
        Dim spl As String() = txtCurrentCoilID.Text.Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
        Dim part As Integer = 1
        ''check to see if there are more than 3 parts to the coilID, if so this will add 1 to the number if the last field is a number, else it will default back to just adding -01
        coil = usefulFunctions.generateNextID(txtCurrentCoilID.Text, part)
        cmd = New SqlCommand("SELECT COUNT(CoilID) FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = coil
        If con.State = ConnectionState.Closed Then con.Open()
        While cmd.ExecuteScalar() > 0
            part += 1
            coil = usefulFunctions.generateNextID(txtCurrentCoilID.Text, part)
            cmd.Parameters("@CoilID").Value = coil
        End While

        cmd = New SqlCommand("INSERT INTO CharterSteelCoilIdentification(CoilID, HeatNumber, Weight, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesOrderNumber, PurchaseOrderNumber, Description, Status) VALUES(@CoilID, @HeatNumber, @Weight, @LotNumber, @Carbon, @SteelSize, @ReceiveDate, @DespatchNumber, @SalesOrderNumber, @PurchaseOrderNumber, @Description, 'RAW')", con)

        With cmd.Parameters
            .Add("@CoilID", SqlDbType.VarChar).Value = coil
            .Add("@HeatNumber", SqlDbType.VarChar).Value = heatNumber
            .Add("@Weight", SqlDbType.VarChar).Value = txtSecondWeight.Text
            .Add("@LotNumber", SqlDbType.VarChar).Value = lotNumber
            .Add("@Carbon", SqlDbType.VarChar).Value = carbon
            .Add("@SteelSize", SqlDbType.VarChar).Value = steelSize
            .Add("@ReceiveDate", SqlDbType.VarChar).Value = ReceiveDate
            .Add("@DespatchNumber", SqlDbType.VarChar).Value = DespatchNumber
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = SONumber
            .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = PONumber
            .Add("@Description", SqlDbType.VarChar).Value = description
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        newIDs.Add(coil)

        Return True
    End Function

    Public Function getIDs() As List(Of String)
        Return newIDs
    End Function

    Private Sub AnnealingLogSplitCoil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFirstWhere.SelectedIndex = 0
        cboSecondWhere.SelectedIndex = 3
    End Sub
    ''input section start
    Private Sub cmdDecimal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDecimal.Click
        addText(sender, e, ".")
    End Sub

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
                FocusedField.Position += charCount
            End If
        End If
    End Sub

    Private Sub cmdBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackspace.Click
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to make sure there is something to delete
            If FocusedField.Text.Length > 0 Then
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
        End If
    End Sub

    Private Sub txtSecondWeight_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSecondWeight.Enter
        FocusedField = New usefulFunctions.FocusedItem(txtSecondWeight)
    End Sub

    Private Sub txtFirstWeight_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstWeight.Enter
        FocusedField = New usefulFunctions.FocusedItem(txtFirstWeight)
    End Sub

    Private Sub cboSecondWhere_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecondWhere.Enter
        If FocusedField.isSet() Then
            FocusedField = New usefulFunctions.FocusedItem()
        End If
    End Sub

    Private Sub cboFirstWhere_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirstWhere.Enter
        If FocusedField.isSet() Then
            FocusedField = New usefulFunctions.FocusedItem()
        End If
    End Sub

    Private Sub chkFirstPrintLabel_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFirstPrintLabel.Enter
        If FocusedField.isSet() Then
            FocusedField = New usefulFunctions.FocusedItem()
        End If
    End Sub

    Private Sub chkSecondPrintLabel_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSecondPrintLabel.Enter
        If FocusedField.isSet() Then
            FocusedField = New usefulFunctions.FocusedItem()
        End If
    End Sub

    Private Sub txtFirstWeight_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFirstWeight.KeyUp
        If e.KeyCode = Keys.Back Then
            If txtFirstWeight.SelectionLength > 0 Then
                FocusedField.Position -= txtFirstWeight.SelectionLength
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub txtSecondWeight_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSecondWeight.KeyUp
        If e.KeyCode = Keys.Back Then
            If txtSecondWeight.SelectionLength > 0 Then
                FocusedField.Position -= txtSecondWeight.SelectionLength
            Else
                FocusedField.SelectionLength -= 1
            End If
            wasDeleted = True
        End If
    End Sub

    Private Sub txtSecondWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSecondWeight.TextChanged
        If txtSecondWeight.Focused Then
            FocusedField.Position = txtSecondWeight.SelectionStart
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
    End Sub

    Private Sub txtFirstWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstWeight.TextChanged
        If txtFirstWeight.Focused Then
            FocusedField.Position = txtFirstWeight.SelectionStart
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
        Dim remain As Double = origWeight - Val(txtFirstWeight.Text)
        If remain > 0 Then
            txtSecondWeight.Text = remain
        Else
            txtSecondWeight.Text = 0
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If FocusedField.isSet() Then
            FocusedField.Text = ""
            FocusedField.Focus()
        End If
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If FocusedField.isSet() Then
            Select Case FocusedField.Name
                Case "txtFirstWeight"
                    txtSecondWeight.Focus()
                Case "txtSecondWeight"
                    cmdSplitCoil.Focus()
                Case Else
                    txtFirstWeight.Focus()
            End Select
        End If
    End Sub

    Private Sub cmdSplitCoil_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSplitCoil.Enter
        If FocusedField.isSet() Then
            FocusedField = New usefulFunctions.FocusedItem()
        End If
    End Sub

    Private Sub txtFirstWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstWeight.Click
        FocusedField.position = txtFirstWeight.SelectionStart
    End Sub

    Private Sub txtFirstWeight_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtFirstWeight.MouseUp
        FocusedField.position = txtFirstWeight.SelectionStart
        FocusedField.SelectionLength = txtFirstWeight.SelectionLength
    End Sub

    Private Sub txtSecondWeight_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSecondWeight.MouseUp
        FocusedField.position = txtSecondWeight.SelectionStart
        FocusedField.SelectionLength = txtSecondWeight.SelectionLength
    End Sub

    Private Sub txtSecondWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSecondWeight.Click
        FocusedField.position = txtSecondWeight.SelectionStart
    End Sub

    Public Sub updateOrigWeight(ByVal wei As Double)
        origWeight = wei
    End Sub
End Class