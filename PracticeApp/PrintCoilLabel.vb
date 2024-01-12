Imports System.Data.SqlClient

Public Class PrintCoilLabel
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet

    Dim isLoaded As Boolean = False
    Dim cleared As Boolean = False

    Dim FocusedField As New usefulFunctions.FocusedItem()
    Dim wasDeleted As Boolean = False
    Dim notFinished As Boolean = False
    Dim bc As New BarcodeLabel


    Public Sub New()
        InitializeComponent()

    End Sub

    Public Sub LoadCoilInfo()
        Dim Weight As Double = 0
        Dim HeatNumber, Carbon, SteelSize, Description As String
        'Extract data from Charter Steel Table
        Dim HeatNumberString As String = "SELECT HeatNumber, Weight, Carbon, SteelSize, Description, AnnealLot FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID"
        Dim HeatNumberCommand As New SqlCommand(HeatNumberString, con)
        HeatNumberCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

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
            If IsDBNull(reader.Item("AnnealLot")) Then
                lblAnnealLot.Text = ""
            Else
                lblAnnealLot.Text = reader.Item("AnnealLot")
            End If
        Else
            HeatNumber = ""
            Weight = 0
            Carbon = ""
            SteelSize = ""
            Description = ""
            lblAnnealLot.Text = ""
        End If
        reader.Close()
        con.Close()

        lblSteelSize.Text = SteelSize
        lblCarbon.Text = Carbon
        txtCoilDescription.Text = Description
        lblCoilWeight.Text = Weight
        lblHeatNumber.Text = HeatNumber
    End Sub

    Private Sub txtCoilID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(txtCoilID.Text) Then
            LoadCoilInfo()
        End If
    End Sub

    Private Sub txtCoilID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilID.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtCoilID") Then
                lstCoilIDSuggest.Visible = False
                FocusedField = New FocusedItem(txtCoilID)
            Else
                txtCoilID.SelectionStart = FocusedField.Position
            End If
        Else
            lstCoilIDSuggest.Visible = False
            FocusedField = New FocusedItem(txtCoilID)
        End If
    End Sub

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
                FocusedField.Position += 1
            Else
                wasDeleted = False
            End If
        End If
        If canSuggestID() Then
            If lstCoilIDSuggest.Visible Then
                lstCoilIDSuggest.Visible = False
            End If
            lstCoilIDSuggest.Items.Clear()
            cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE CoilID LIKE @CoilID", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text + "%"

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    lstCoilIDSuggest.Items.Add(reader.Item("CoilID"))
                End While
            End If
            reader.Close()
            con.Close()
            If lstCoilIDSuggest.Items.Count < 5 Then
                If lstCoilIDSuggest.Items.Count = 0 Then
                    lstCoilIDSuggest.Height = 40
                Else
                    lstCoilIDSuggest.Height = lstCoilIDSuggest.Items.Count * 40
                End If
            Else
                lstCoilIDSuggest.Height = 5 * 20
            End If
            lstCoilIDSuggest.Visible = True
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
        If txtCoilID.Text.Length < 4 Then
            Return False
        End If
        Return True
    End Function

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
                FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + tex + FocusedField.Text.Substring(FocusedField.Position, FocusedField.Text.Length - FocusedField.Position)
            End If
            If charCount > 1 Then
                FocusedField.Position += charCount - 1
            End If
            Me.Controls(FocusedField.Name).Focus()
        End If
    End Sub

    Private Sub lstCoilIDSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCoilIDSuggest.SelectedValueChanged
        If lstCoilIDSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstCoilIDSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                txtCoilID.Text = lstCoilIDSuggest.SelectedItem
                LoadCoilInfo()
                lstCoilIDSuggest.Visible = False
                cmdPrintLabels.Focus()
            End If
        End If
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

    Private Sub cmdTWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTWD.Click
        addText(sender, e, "TWD", 3)
    End Sub

    Private Sub cmdDash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDash.Click
        addText(sender, e, "-")
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
                    If FocusedField.Text.Length < FocusedField.Position Then
                        FocusedField.Position = FocusedField.Text.Length
                    End If
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
            Me.Controls(FocusedField.Name).Focus()
        End If
    End Sub

    Private Sub cmdPrintLabels_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLabels.Enter
        If FocusedField.isSet() Then
            lstCoilIDSuggest.Visible = False
            FocusedField = New FocusedItem()
        End If
    End Sub

    Private Sub cmdPrintLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLabels.Click
        If canPrintLables() Then
            Dim barc As New BarcodeLabel
            barc.setupYardLabel(txtCoilID.Text, Val(txtLabelCount.Text))
            If Environment.UserName.Contains("WireyardTablet") Then
                barc.PrintBarcodeLine("ZebraWireyard")
            Else
                barc.PrintBarcodeLine()
            End If
            cmdClearAll_Click(sender, e)
        End If
    End Sub

    Private Function canPrintLables() As Boolean
        If String.IsNullOrEmpty(txtCoilID.Text) Then
            MessageBox.Show("You must enter a Coil ID", "Enter a Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilID.Focus()
            Return False
        End If
        cmd = New SqlCommand("SELECT COUNT(CoilID) FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            MessageBox.Show("You must enter a valid Coil ID", "Enter a valid Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilID.SelectAll()
            txtCoilID.Focus()
            Return False
        End If
        con.Close()
        If String.IsNullOrEmpty(txtLabelCount.Text) Then
            MessageBox.Show("You must enter a number of labels to print", "Enter a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLabelCount.Focus()
            Return False
        End If
        If Not IsNumeric(txtLabelCount.Text) Then
            MessageBox.Show("You must enter a number for number of labels", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLabelCount.SelectAll()
            txtLabelCount.Focus()
            Return False
        End If
        If Val(txtLabelCount.Text) = 0 Then
            MessageBox.Show("You must enter a value greater than 0", "Enter a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLabelCount.SelectAll()
            txtLabelCount.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        txtCoilID.Clear()
        lblCarbon.Text = ""
        lblSteelSize.Text = ""
        lblHeatNumber.Text = ""
        lblCoilWeight.Text = ""
        txtCoilDescription.Text = ""
        lblAnnealLot.Text = ""
        txtLabelCount.Text = 2
        txtCoilID.Focus()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        wasDeleted = True
        Me.Controls(FocusedField.Name).Text = ""
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
                        End If
                    End If
                    LoadCoilInfo()
                    cmdPrintLabels.Focus()
                Case "txtLabelCount"
                    cmdPrintLabels.Focus()
                Case Else
                    SelectNextControl(Me.Controls(FocusedField.Name), True, True, True, True)
            End Select
        End If
    End Sub

    Private Sub txtLabelCount_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLabelCount.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtLabelCount") Then
                FocusedField = New FocusedItem(txtLabelCount)
            Else
                txtLabelCount.SelectionStart = FocusedField.Position
            End If
        Else
            FocusedField = New FocusedItem(txtLabelCount)
        End If
    End Sub

    Private Sub txtLabelCount_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLabelCount.MouseUp
        txtLabelCount.Clear()
        If txtLabelCount.Focused Then
            FocusedField.Position = txtLabelCount.SelectionStart
            FocusedField.SelectionLength = txtLabelCount.SelectionLength
        End If
    End Sub

    Private Sub txtLabelCount_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLabelCount.MouseClick
        If txtLabelCount.Focused Then
            FocusedField.Position = txtLabelCount.SelectionStart
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtLabelCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLabelCount.TextChanged
        If txtLabelCount.Focused Then
            FocusedField.Position = txtLabelCount.SelectionStart
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

    Private Sub txtCoilID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilID.KeyUp
        If e.KeyCode = Keys.Enter Then
            lstCoilIDSuggest.Visible = False
            LoadCoilInfo()
            e.Handled = True
            cmdPrintLabels.Focus()
        End If
    End Sub
End Class
