Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class SteelReceivingAdditionalDataRequired

    Structure coilInfo
        Public carbon As String
        Public steelSize As String
        Public id As String
        Public weight As Double
        Public heat As String
        Public ReceiveLine As Integer
    End Structure

    Dim carbons As New List(Of String)
    Dim SteelSize As New List(Of String)
    Dim origWeights As New List(Of Integer)
    Dim ReceiveLines As New List(Of Integer)
    Dim ReceivingHeaderKey As Integer
    Dim PO As Integer

    Public coils As New List(Of coilInfo)
    Dim coilCount As Integer = 0
    Dim position As Integer = 0
    Dim moveFocus As Boolean = True

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal headerKey As Integer)
        InitializeComponent()
        ReceivingHeaderKey = headerKey
    End Sub

    Public Sub setOrigionalWeights(ByVal lst As List(Of Integer))
        origWeights = lst
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Select Case True
            Case txtCoilCount.Visible
                addCoilCount()
            Case Else
                addCoilToList()
        End Select
    End Sub

    Private Sub addCoilCount()
        If checkCoilNumberEntered() Then
            coilCount = Val(txtCoilCount.Text)
            position = 1

            lblQuestion.Visible = False
            txtCoilCount.Visible = False

            lblCoilCount.Text = "Coil " + position.ToString() + " of " + coilCount.ToString()
            lblCarbon.Text = "Carbon : " + carbons(0)
            lblSteelSize.Text = "Steel Size : " + SteelSize(0)
            lblCarbon.Visible = True
            lblSteelSize.Visible = True
            lblCoilCount.Visible = True
            lblCoilID.Visible = True
            lblCoilWeight.Visible = True
            lblCoilHeat.Visible = True
            txtCoilID.Visible = True
            txtCoilWeight.Visible = True
            txtCoilHeat.Visible = True
            txtCoilID.Focus()
        End If
    End Sub

    Private Function checkCoilNumberEntered() As Boolean
        If String.IsNullOrEmpty(txtCoilCount.Text) Then
            MessageBox.Show("You must enter a number for Coil Count", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilCount.Focus()
            Return False
        End If
        If IsNumeric(txtCoilCount.Text) = False Then
            MessageBox.Show("You must enter a number for Coil Count", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilCount.SelectAll()
            txtCoilCount.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub addCoilToList()
        ''checks ot make sure the input that the user entered is valid data
        If canAddToList() Then
            ''creates a new coilInfo object to store the data needed later for adding to the DB
            Dim nw As New coilInfo
            nw.carbon = carbons(0)
            nw.steelSize = SteelSize(0)
            nw.weight = Val(txtCoilWeight.Text)
            nw.heat = txtCoilHeat.Text
            nw.id = txtCoilID.Text
            nw.ReceiveLine = ReceiveLines(0)
            ''adds to the list to be written to the DB later
            coils.Add(nw)

            position += 1
            ''check to make sure there are more coils to be added with the carbon and steel size
            If coilCount < position Then
                carbons.RemoveAt(0)
                SteelSize.RemoveAt(0)
                ReceiveLines.RemoveAt(0)
                ''checks to see if there are still carbons to get id's for
                If carbons.Count = 0 Then
                    Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
                    Dim cmd As New SqlCommand("UPDATE SteelReceivingLineTable SET ReceiveWeight = @NewReceiveWeight, SteelExtendedCost = ROUND((SteelExtendedCost / ReceiveWeight) * @NewReceiveWeight, 2) WHERE SteelReceivingHeaderKey = @HeaderKey AND SteelReceivingLineKey = @LineKey", con)
                    cmd.Parameters.Add("@NewReceiveWeight", SqlDbType.Float)
                    cmd.Parameters.Add("@HeaderKey", SqlDbType.Int).Value = ReceivingHeaderKey
                    cmd.Parameters.Add("@LineKey", SqlDbType.Int)

                    Dim totalWeight As Double = 0D
                    Dim linecount As Integer = 0
                    For i As Integer = 0 To coils.Count - 1
                        If linecount + 1 <> coils(i).ReceiveLine Then
                            If totalWeight <> origWeights(linecount) Then
                                If MessageBox.Show("Total Line weight entered for Carbon " + coils(i - 1).carbon + " and Size " + coils(i - 1).steelSize + ", " + origWeights(linecount).ToString + ", does not match the total coil weights entered, " + totalWeight.ToString() + ". Do you wish to adjust entered line weight?", "Adjust line weight", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                                    Me.Close()
                                    Exit Sub
                                Else
                                    cmd.Parameters("@NewReceiveWeight").Value = totalWeight
                                    cmd.Parameters("@LineKey").Value = coils(i - 1).ReceiveLine

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    totalWeight = 0
                                    linecount += 1
                                End If
                            End If
                        Else
                            totalWeight += coils(i).weight
                        End If
                    Next
                    If totalWeight <> origWeights(linecount) Then
                        If MessageBox.Show("Total Line weight entered for Carbon " + coils(coils.Count - 1).carbon + " and Size " + coils(coils.Count - 1).steelSize + " does not match the total coil weights entered. Do you wish to adjust entered line weight?", "Adjust line weight", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                            Me.Close()
                            Exit Sub
                        Else
                            cmd.Parameters("@NewReceiveWeight").Value = totalWeight
                            cmd.Parameters("@LineKey").Value = coils(coils.Count - 1).ReceiveLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            totalWeight = 0
                        End If
                    End If
                    If con.State = ConnectionState.Open Then con.Close()
                    Me.DialogResult = System.Windows.Forms.DialogResult.Yes
                    Me.Close()
                Else
                    lblQuestion.Text = "How many Coils for " + carbons(0) + " " + SteelSize(0) + "?"
                    txtCoilCount.Text = ""
                    lblQuestion.Visible = True
                    txtCoilCount.Visible = True
                    txtCoilCount.Focus()

                    lblCarbon.Visible = False
                    lblSteelSize.Visible = False
                    lblCoilCount.Visible = False
                    lblCoilID.Visible = False
                    lblCoilWeight.Visible = False
                    lblCoilHeat.Visible = False
                    txtCoilID.Visible = False
                    txtCoilWeight.Visible = False
                    txtCoilHeat.Visible = False
                    txtCoilHeat.Text = ""
                    position = 0
                End If
            Else
                lblCoilCount.Text = "Coil " + position.ToString() + " of " + coilCount.ToString()
                txtCoilID.Focus()
            End If
            txtCoilID.Text = ""
            txtCoilWeight.Text = ""
        End If
    End Sub

    Private Function canAddToList() As Boolean
        If String.IsNullOrEmpty(txtCoilID.Text) Then
            MessageBox.Show("You must enter a coilID", "Enter a Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCoilWeight.Text) Then
            MessageBox.Show("You must enter a Weight", "Enter a weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilWeight.Focus()
            Return False
        End If
        If IsNumeric(txtCoilWeight.Text) = False Then
            MessageBox.Show("You must enter a number for Weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilWeight.SelectAll()
            txtCoilWeight.Focus()
            Return False
        End If
        If Val(txtCoilWeight.Text) <= 0 Then
            MessageBox.Show("You must enter a value greater than zero", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilWeight.SelectAll()
            txtCoilWeight.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCoilHeat.Text) Then
            MessageBox.Show("You must enter a Heat Number", "Enter a Heat Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilHeat.Focus()
            Return False
        End If
        ''checks to make sure the coil ID is unique
        If coilIDNotUnique() Then
            Return False
        End If
        Return True
    End Function
    ''checks to make sure the Coil ID is unique
    Private Function coilIDNotUnique() As Boolean
        ''makes sure it hasn't been entered into the batch to be added to the DB
        For i As Integer = 0 To coils.Count - 1
            If coils(i).id = txtCoilID.Text Then
                MessageBox.Show("Coil ID has already been entered. Enter a different Coil ID", "Already entered", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCoilID.SelectAll()
                txtCoilID.Focus()
                Return True
            End If
        Next
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As SqlCommand
        cmd = New SqlCommand("SELECT COUNT(CoilID) FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ''check ot make sure it is not in the DB already
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            MessageBox.Show("There is a coil with this ID already in Inventory. Coil ID must be unique.", "Invalid Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilID.SelectAll()
            txtCoilID.Focus()
            Return True
        End If
        con.Close()
        Return False
    End Function

    Public Sub addCarbonSizeWeight(ByVal carb As String, ByVal siz As String, ByVal wei As Double, ByVal receiveLine As Integer)
        carbons.Add(carb)
        SteelSize.Add(siz)
        origWeights.Add(wei)
        ReceiveLines.Add(receiveLine)
    End Sub

    Public Sub setQuestionText()
        lblQuestion.Text += carbons(0) + " " + SteelSize(0) + "?"
    End Sub

    Private Sub txtCoilCount_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilCount.KeyUp
        If e.KeyCode = Keys.Enter And moveFocus Then
            e.Handled = True
            cmdNext.Focus()
        Else
            moveFocus = True
        End If
    End Sub

    Private Sub txtCoilID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilID.KeyUp
        If e.KeyCode = Keys.Enter And moveFocus Then
            e.Handled = True
            txtCoilID.SelectAll()
            txtCoilWeight.Focus()
        Else
            moveFocus = True
        End If
    End Sub

    Private Sub txtCoilWeight_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilWeight.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtCoilHeat.SelectAll()
            txtCoilHeat.Focus()
        End If
    End Sub

    Private Sub txtCoilHeat_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilHeat.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            cmdNext.Focus()
        End If
    End Sub

    Private Sub cmdNext_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cmdNext.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            moveFocus = False
        End If
    End Sub

    Private Sub cmdQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuit.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class