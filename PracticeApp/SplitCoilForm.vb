Imports System.Data.SqlClient
Public Class SplitCoilForm
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim MyAdapter As New SqlDataAdapter
    Dim lst As New List(Of String)
    Dim rePrintList As New List(Of String)
    Dim bc As New BarcodeLabel

    Dim isLoaded As Boolean = False

    Dim FocusedField As New usefulFunctions.FocusedItem()
    Dim wasDeleted As Boolean = False

    Private Sub SplitForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCoilID()
        isLoaded = True
        cboPieces.SelectedIndex = 0
    End Sub

    Private Sub LoadCoilID()
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status = 'RAW'", con1)
        ds = New DataSet()
        MyAdapter.SelectCommand = cmd

        If con1.State = ConnectionState.Closed Then con1.Open()
        MyAdapter.Fill(ds, "CharterSteelCoilIdentification")
        con1.Close()
    End Sub

    Private Sub LoadCoilData()
        If isLoaded Then
            cmd = New SqlCommand("SELECT Carbon, SteelSize, Weight FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("Carbon")) Then
                    txtCarbon.Text = ""
                Else
                    txtCarbon.Text = reader.Item("Carbon")
                End If
                If IsDBNull(reader.Item("SteelSize")) Then
                    txtSteelSize.Text = ""
                Else
                    txtSteelSize.Text = reader.Item("SteelSize")
                End If
                If IsDBNull(reader.Item("Weight")) Then
                    txtWeight.Text = ""
                Else
                    txtWeight.Text = reader.Item("Weight")
                End If
            Else
                txtCarbon.Text = ""
                txtSteelSize.Text = ""
                txtWeight.Text = ""
            End If
            reader.Close()
            con.Close()
        End If
    End Sub

    Private Sub cboPieces_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPieces.SelectedIndexChanged
        Dim pieces As Integer = Val(cboPieces.Text)
        If pieces >= 3 Then
            lblPiece3.Visible = True
            txtPiece3.Visible = True
        Else
            lblPiece3.Visible = False
            txtPiece3.Visible = False
            txtPiece3.Text = ""
        End If
        If pieces >= 4 Then
            lblPiece4.Visible = True
            txtPiece4.Visible = True
        Else
            lblPiece4.Visible = False
            txtPiece4.Visible = False
            txtPiece4.Text = ""
        End If
        If pieces = 5 Then
            lblPiece5.Visible = True
            txtPiece5.Visible = True
        Else
            lblPiece5.Visible = False
            txtPiece5.Visible = False
            txtPiece5.Text = ""
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If lst.Count > 0 Then
            MessageBox.Show("Unable to exit, there are still labels to be printed. Wait till all labels have been printed to exit", "Unable to exit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearData()
    End Sub

    Private Sub ClearData()
        isLoaded = False
        LoadCoilID()
        txtCoilID.Clear()
        isLoaded = True
        txtCarbon.Clear()
        txtSteelSize.Clear()
        txtWeight.Clear()
        cboPieces.Text = "2"
        txtPiece1.Clear()
        txtPiece2.Clear()
        txtPiece3.Clear()
        txtPiece4.Clear()
        txtPiece5.Clear()
        lstCoilIDSuggest.Items.Clear()
        txtCoilID.Focus()
    End Sub

    Private Sub cboCoilID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            cboPieces.Focus()
        End If
    End Sub

    Private Sub cboPieces_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPieces.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtPiece1.Focus()
        End If
    End Sub

    Private Sub txtPiece1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPiece1.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtPiece2.Focus()
        End If
    End Sub

    Private Sub txtPiece2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPiece2.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If txtPiece3.Visible Then
                txtPiece3.Focus()
            Else
                cmdSplitCoil.Focus()
            End If
        End If
    End Sub

    Private Sub txtPiece3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPiece3.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If txtPiece4.Visible Then
                txtPiece4.Focus()
            Else
                cmdSplitCoil.Focus()
            End If
        End If
    End Sub

    Private Sub txtPiece4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPiece4.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If txtPiece5.Visible Then
                txtPiece5.Focus()
            Else
                cmdSplitCoil.Focus()
            End If
        End If
    End Sub

    Private Sub txtPiece5_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPiece5.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            cmdSplitCoil.Focus()
        End If
    End Sub

    Private Sub cmdSplitCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSplitCoil.Click
        If canSplit() Then
            lst = New List(Of String)
            rePrintList = New List(Of String)
            Dim heatNumber As String = ""
            Dim lotNumber As String = ""
            Dim carbon As String = ""
            Dim steelSize As String = ""
            Dim ReceiveDate As String = Today.Date.ToString()
            Dim DespatchNumber As String = ""
            Dim SONumber As String = ""
            Dim PONumber As String = ""
            Dim description As String = ""
            Dim annealLotNumber As String = ""
            ''gets the coil information so that it can add it to the new Coil ID
            cmd = New SqlCommand("SELECT HeatNumber, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesOrderNumber, PurchaseOrderNumber, Description, AnnealLot FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

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
                If Not IsDBNull(reader.Item("AnnealLot")) Then
                    annealLotNumber = reader.Item("AnnealLot")
                End If
            End If
            reader.Close()

            cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Weight = @Weight WHERE CoilID = @CoilID;", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
            cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = txtPiece1.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            If tmrPrintLabel.Enabled Then
                lst.Add(txtCoilID.Text)
                rePrintList.Add(txtCoilID.Text)
            Else
                rePrintList.Add(txtCoilID.Text)
                bc.setupYardLabel(txtCoilID.Text, 1)
                bc.PrintBarcodeLine()
                tmrPrintLabel.Start()
            End If

            Dim annealLot As Boolean = False

            cmd = New SqlCommand("SELECT isnull(MAX(AnnealLotNumber), 0) FROM AnnealingCoilLines WHERE CoilID = @CoilID;", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            Dim ann As Integer = cmd.ExecuteScalar()
            con.Close()

            If ann <> 0 Then
                cmd.CommandText = "UPDATE AnnealingCoilLines SET AnnealedWeight = @AnnealedWeight WHERE CoilID = @CoilID AND AnnealLotNumber = @AnnealLotNumber;"
                cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = ann
                cmd.Parameters.Add("@AnnealedWeight", SqlDbType.Float).Value = txtPiece1.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            End If
            Dim coil As String = ""
            Dim spl As String() = txtCoilID.Text.Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
            Dim part As Integer = 1
            ''check to see if there are more than 3 parts to the coilID, if so this will add 1 to the number if the last field is a number, else it will default back to just adding -01
            coil = usefulFunctions.generateNextID(txtCoilID.Text, part)
            cmd = New SqlCommand("SELECT COUNT(CoilID) FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = coil
            If con.State = ConnectionState.Closed Then con.Open()
            While cmd.ExecuteScalar() > 0
                part += 1
                coil = usefulFunctions.generateNextID(txtCoilID.Text, part)
                cmd.Parameters("@CoilID").Value = coil
            End While

            For i As Integer = 2 To Val(cboPieces.Text)
                cmd = New SqlCommand("INSERT INTO CharterSteelCoilIdentification(CoilID, HeatNumber, Weight, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesOrderNumber, PurchaseOrderNumber, Description, Status, AnnealLot) VALUES(@CoilID, @HeatNumber, @Weight, @LotNumber, @Carbon, @SteelSize, @ReceiveDate, @DespatchNumber, @SalesOrderNumber, @PurchaseOrderNumber, @Description, 'RAW', @AnnealLot);", con)
                With cmd.Parameters
                    .Add("@CoilID", SqlDbType.VarChar).Value = coil
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = heatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = lotNumber
                    .Add("@Carbon", SqlDbType.VarChar).Value = carbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = steelSize
                    .Add("@ReceiveDate", SqlDbType.VarChar).Value = ReceiveDate
                    .Add("@DespatchNumber", SqlDbType.VarChar).Value = DespatchNumber
                    .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = SONumber
                    .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = PONumber
                    .Add("@Description", SqlDbType.VarChar).Value = description
                    .Add("@AnnealLot", SqlDbType.VarChar).Value = annealLotNumber
                End With

                Select Case i
                    Case 2
                        cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = Val(txtPiece2.Text)
                    Case 3
                        cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = Val(txtPiece2.Text)
                    Case 4
                        cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = Val(txtPiece4.Text)
                    Case 5
                        cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = Val(txtPiece5.Text)
                End Select

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()

                If ann <> 0 Then
                    cmd.CommandText = "INSERT INTO AnnealingCoilLines (AnnealLotNumber, CoilID, AnnealedWeight) VALUES (@AnnealLotNumber, @CoilID, @Weight);"
                    cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.Int).Value = ann

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "UPDATE AnnealingLog SET NumberOfCoils = (NumberOfCoils + 1) WHERE AnnealLotNumber = @AnnealLotNumber;"
                    cmd.ExecuteNonQuery()
                End If

                If tmrPrintLabel.Enabled Then
                    lst.Add(coil)
                    rePrintList.Add(coil)
                Else
                    rePrintList.Add(coil)
                    bc.setupYardLabel(coil, 1)
                    bc.PrintBarcodeLine()
                    tmrPrintLabel.Start()
                End If
                spl = coil.Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
                part += 1
                ''check to see if there are more than 3 parts to the coilID, if so this will add 1 to the number if the last field is a number, else it will default back to just adding -01
                coil = usefulFunctions.generateNextID(txtCoilID.Text, part)
            Next
            con.Close()
            While lst.Count > 0
                System.Windows.Forms.Application.DoEvents()
            End While
            If MessageBox.Show("Did the labels print correctly?", "Correctly printed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                lst = rePrintList
                bc.setupYardLabel(lst(0), 1)
                bc.PrintBarcodeLine()
                tmrPrintLabel.Start()
                lst.RemoveAt(0)
            End If
            ClearData()
        End If
    End Sub

    Private Function canSplit() As Boolean
        If String.IsNullOrEmpty(txtCoilID.Text) Then
            MessageBox.Show("You must select a Coil ID", "Select a Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        If cboPieces.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid number from 2 to 5", "Enter a valid number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPieces.SelectAll()
            cboPieces.Focus()
            Return False
        End If
        If IsNumeric(txtPiece1.Text) = False Then
            MessageBox.Show("You must enter a number for weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiece1.SelectAll()
            txtPiece1.Focus()
            Return False
        End If
        If Val(txtPiece1.Text) = 0 Then
            MessageBox.Show("You must enter a number greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiece1.SelectAll()
            txtPiece1.Focus()
            Return False
        End If
        If IsNumeric(txtPiece2.Text) = False Then
            MessageBox.Show("You must enter a number for weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiece2.SelectAll()
            txtPiece2.Focus()
            Return False
        End If
        If Val(txtPiece2.Text) = 0 Then
            MessageBox.Show("You must enter a number greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiece2.SelectAll()
            txtPiece2.Focus()
            Return False
        End If
        If cboPieces.SelectedIndex >= 1 Then
            If IsNumeric(txtPiece3.Text) = False Then
                MessageBox.Show("You must enter a number for weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPiece3.SelectAll()
                txtPiece3.Focus()
                Return False
            End If
            If Val(txtPiece3.Text) = 0 Then
                MessageBox.Show("You must enter a number greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPiece3.SelectAll()
                txtPiece3.Focus()
                Return False
            End If
            If cboPieces.SelectedIndex >= 2 Then
                If IsNumeric(txtPiece4.Text) = False Then
                    MessageBox.Show("You must enter a number for weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtPiece4.SelectAll()
                    txtPiece4.Focus()
                    Return False
                End If
                If Val(txtPiece4.Text) = 0 Then
                    MessageBox.Show("You must enter a number greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtPiece4.SelectAll()
                    txtPiece4.Focus()
                    Return False
                End If
                If cboPieces.SelectedIndex = 3 Then
                    If IsNumeric(txtPiece5.Text) = False Then
                        MessageBox.Show("You must enter a number for weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtPiece5.SelectAll()
                        txtPiece5.Focus()
                        Return False
                    End If
                    If Val(txtPiece5.Text) = 0 Then
                        MessageBox.Show("You must enter a number greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtPiece5.SelectAll()
                        txtPiece5.Focus()
                        Return False
                    End If
                End If
            End If
        End If
        ''check to total weight entered to make sure it is less than or equal to the original coil weight
        Dim totalWeight As Double = Val(txtPiece1.Text) + Val(txtPiece2.Text) + Val(txtPiece3.Text) + Val(txtPiece4.Text) + Val(txtPiece5.Text)
        If totalWeight > Val(txtWeight.Text) Then
            MessageBox.Show("Total piece weight is greater than original Coil weight. Check weights and try again.", "Weight is to high", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiece1.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub tmrPrintLabel_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPrintLabel.Tick
        tmrPrintLabel.Stop()
        If lst.Count > 0 Then
            bc.setupYardLabel(lst(0), 1)
            bc.PrintBarcodeLine()
            lst.RemoveAt(0)
            tmrPrintLabel.Start()
        End If
    End Sub

    Private Sub SplitForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        While lst.Count > 0
            System.Windows.Forms.Application.DoEvents()
        End While
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub txtPiece1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece1.TextChanged
        If Not txtPiece3.Visible Then
            Dim remain As Double = Math.Round(Val(txtWeight.Text) - Val(txtPiece1.Text), 2)
            If remain > 0 Then
                txtPiece2.Text = remain.ToString()
            Else
                txtPiece2.Text = "0"
            End If
        End If
        If txtPiece1.Focused Then
            FocusedField.position = txtPiece1.SelectionStart
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
    ''input section start
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
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to make sure there is something to delete
            If Me.Controls(FocusedField.Name).Text.Length > 0 Then
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
                            Me.Controls(FocusedField.Name).Text = FocusedField.Text.Substring(0, FocusedField.Position)
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
                            If FocusedField.Position > FocusedField.Text.Length Then
                                FocusedField.Position = FocusedField.Text.Length
                            End If
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
                lstCoilIDSuggest.Visible = False
                cboPieces.SelectAll()
                cboPieces.Focus()
            End If
        End If
    End Sub

    Private Sub bgwkCoilIDSuggest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkCoilIDSuggest.DoWork
        Dim lst As New List(Of String)
        Dim cmd2 As SqlCommand = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status = 'RAW' and CoilID LIKE @CoilID;", con1)
        cmd2.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text + "%"

        If con1.State = ConnectionState.Closed Then con1.Open()
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
        con1.Close()
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

    Private Sub hideSuggest(ByVal ctrl As String)
        If Not String.IsNullOrEmpty(ctrl) Then
            If ctrl.Equals("txtCoilID") Then
                lstCoilIDSuggest.Visible = False
            End If
        End If
    End Sub

    Private Sub cboPieces_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPieces.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboPieces") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(cboPieces)
            Else
                cboPieces.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(cboPieces)
        End If
    End Sub

    Private Sub txtPiece1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece1.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtPiece1") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(txtPiece1)
            Else
                txtPiece1.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(txtPiece1)
        End If
    End Sub

    Private Sub txtPiece2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece2.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtPiece2") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(txtPiece2)
            Else
                txtPiece2.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(txtPiece2)
        End If
    End Sub

    Private Sub txtPiece3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece3.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtPiece3") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(txtPiece3)
            Else
                txtPiece3.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(txtPiece3)
        End If
    End Sub

    Private Sub txtPiece4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece4.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtPiece4") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(txtPiece4)
            Else
                txtPiece4.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(txtPiece4)
        End If
    End Sub

    Private Sub txtPiece5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece5.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtPiece5") Then
                hideSuggest(FocusedField.Name)
                FocusedField = New FocusedItem(txtPiece5)
            Else
                txtPiece5.SelectionStart = FocusedField.Position
            End If
        Else
            hideSuggest(FocusedField.Name)
            FocusedField = New FocusedItem(txtPiece5)
        End If
    End Sub

    Private Sub cmdSplitCoil_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSplitCoil.Enter
        If FocusedField.isSet() Then
            FocusedField = New FocusedItem()
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
                    cboPieces.SelectAll()
                    cboPieces.Focus()
                Case "cboPieces"
                    txtPiece1.SelectAll()
                    txtPiece1.Focus()
                Case "txtPieces1"
                    txtPiece2.SelectAll()
                    txtPiece2.Focus()
                Case "txtPieces2"
                    If txtPiece3.Visible Then
                        txtPiece3.SelectAll()
                        txtPiece3.Focus()
                    Else
                        cmdSplitCoil.Focus()
                    End If
                Case "txtPieces3"
                    If txtPiece4.Visible Then
                        txtPiece4.SelectAll()
                        txtPiece4.Focus()
                    Else
                        cmdSplitCoil.Focus()
                    End If
                Case "txtPieces5"
                    If txtPiece5.Visible Then
                        txtPiece5.SelectAll()
                        txtPiece5.Focus()
                    Else
                        cmdSplitCoil.Focus()
                    End If
                Case Else
                    SelectNextControl(Me.Controls(FocusedField.Name), True, True, True, True)
            End Select
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        wasDeleted = True
        Me.Controls(FocusedField.Name).Text = ""
        FocusedField.Position = 0
        FocusedField.SelectionLength = 0
    End Sub

    Private Sub txtPiece2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece2.TextChanged
        If Not txtPiece4.Visible Then
            Dim remain As Double = Math.Round(Val(txtWeight.Text) - (Val(txtPiece1.Text) + Val(txtPiece2.Text)), 2)
            If remain > 0 Then
                txtPiece3.Text = remain.ToString()
            Else
                txtPiece3.Text = "0"
            End If
        End If
        If txtPiece2.Focused Then
            FocusedField.Position = txtPiece2.SelectionStart
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

    Private Sub txtPiece3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece3.TextChanged
        If Not txtPiece5.Visible Then
            Dim remain As Double = Math.Round(Val(txtWeight.Text) - (Val(txtPiece1.Text) + Val(txtPiece2.Text) + Val(txtPiece3.Text)), 2)
            If remain > 0 Then
                txtPiece4.Text = remain.ToString()
            Else
                txtPiece4.Text = "0"
            End If
        End If
        If txtPiece3.Focused Then
            FocusedField.Position = txtPiece3.SelectionStart
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

    Private Sub txtPiece4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece4.TextChanged
        If txtPiece4.Focused Then
            FocusedField.Position = txtPiece4.SelectionStart
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

    Private Sub txtPiece5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiece5.TextChanged
        If txtPiece5.Focused Then
            FocusedField.Position = txtPiece5.SelectionStart
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

    Private Sub cboPieces_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboPieces.MouseUp
        If cboPieces.Focused Then
            FocusedField.Position = cboPieces.SelectionStart
            FocusedField.SelectionLength = cboPieces.SelectionLength
        End If
    End Sub

    Private Sub txtPiece1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPiece1.MouseUp
        If txtPiece1.Focused Then
            FocusedField.Position = txtPiece1.SelectionStart
            FocusedField.SelectionLength = txtPiece1.SelectionLength
        End If
    End Sub

    Private Sub txtPiece2_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPiece2.MouseUp
        If txtPiece2.Focused Then
            FocusedField.Position = txtPiece2.SelectionStart
            FocusedField.SelectionLength = txtPiece2.SelectionLength
        End If
    End Sub

    Private Sub txtPiece3_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPiece3.MouseUp
        If txtPiece3.Focused Then
            FocusedField.Position = txtPiece3.SelectionStart
            FocusedField.SelectionLength = txtPiece3.SelectionLength
        End If
    End Sub

    Private Sub txtPiece4_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPiece4.MouseUp
        If txtPiece4.Focused Then
            FocusedField.Position = txtPiece4.SelectionStart
            FocusedField.SelectionLength = txtPiece4.SelectionLength
        End If
    End Sub

    Private Sub txtPiece5_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPiece5.MouseUp
        If txtPiece5.Focused Then
            FocusedField.Position = txtPiece5.SelectionStart
            FocusedField.SelectionLength = txtPiece5.SelectionLength
        End If
    End Sub

    Private Sub cboPieces_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPieces.TextChanged
        If cboPieces.Focused Then
            FocusedField.Position = cboPieces.SelectionStart
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

    Private Sub cboPieces_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboPieces.MouseClick
        If cboPieces.Focused Then
            FocusedField.position = cboPieces.SelectionStart
        End If
    End Sub

    Private Sub txtCoilID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilID.Leave
        If isLoaded Then
            If String.IsNullOrEmpty(txtCarbon.Text) Then
                LoadCoilData()
            End If
        End If
    End Sub

    Private Sub txtCoilID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilID.KeyUp
        If e.KeyCode = Keys.Enter Then
            lstCoilIDSuggest.Visible = False
            LoadCoilData()
            e.Handled = True
            txtPiece1.Focus()
        End If
    End Sub
End Class
