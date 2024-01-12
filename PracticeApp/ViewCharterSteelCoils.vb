Imports System.Data.SqlClient

Public Class ViewCharterSteelCoils
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3 As DataSet
    Dim FocusedField As New FocusedItem()
    Dim wasDeleted As Boolean = False
    Dim notFinished As Boolean = False
    Dim CoilComment As New ViewSteelCoilsCoilComment()

    Private oskProcess As Process

    Private Class FocusedItem
        Public name As String
        Public position As Integer
        Public selectLength As Integer
        Public parent As String
        Private valid As Boolean
        Public Sub New()
            name = ""
            position = 0
            selectLength = 1
            parent = ""
            valid = False
        End Sub
        Public Sub New(ByRef obj As System.Windows.Forms.TextBox)
            name = obj.Name
            position = obj.SelectionStart
            selectLength = obj.SelectionLength
            parent = obj.Parent.Name
            valid = True
        End Sub
        Public Sub New(ByRef obj As System.Windows.Forms.ComboBox)
            name = obj.Name
            position = obj.SelectionStart
            selectLength = obj.SelectionLength
            parent = obj.Parent.Name
            valid = True
        End Sub
        Public Function isSet() As Boolean
            Return valid
        End Function
    End Class

    Public Sub New()
        InitializeComponent()
        AddHandler CoilComment.Hidden, AddressOf CoilCommentHidden
        'Load Defaults
        LoadSteel()
        LoadHeatNumber()
        LoadPONumber()
        cboStatus.Text = "RAW"
    End Sub

    Private Function sizeCheck(ByVal dec As String, ByVal rawSize As String) As Boolean
        ''checks to see if the size form the raw materials table is a fraction
        If rawSize.Contains("/") Then
            If dec.Equals(rawSize) Then
                Return True
            Else
                Return False
            End If
        Else
            Dim nmr As String() = dec.Split(New String() {"/"}, StringSplitOptions.RemoveEmptyEntries)
            ''checks to see if there is a whole number and if there is it will convert the whole number
            If nmr(0).Contains("-") Then
                Dim tmp As String() = nmr(0).Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
                nmr(0) = Convert.ToInt32(tmp(0) * nmr(1) + tmp(1))
            End If
            Dim dml As String = Convert.ToDouble(nmr(0)) / Convert.ToDouble(nmr(1))
            Dim sepDml As String() = dml.Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            ''checks to make sure that the decimal is only 3 positions if not will add 0 if its more will remove
            If sepDml(1).Length > 3 Then
                dml = dml.Substring(0, dml.LastIndexOf(".") + 4)
            Else
                While sepDml(1).Length < 3
                    sepDml(1) = sepDml(1) + "0"
                End While
                dml = sepDml(0) + "." + sepDml(1)
            End If
            If dml.Equals(rawSize) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub LoadSteel()
        cmd = New SqlCommand("SELECT DISTINCT(Carbon) as Carbon FROM RawMaterialsTable WHERE DivisionID = 'TWD'", con)
        ds1 = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds1, "RawMaterialsTable")
        con.Close()

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        cboCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT(HeatNumber) FROM CharterSteelCoilIdentification WHERE Status <> 'CLOSED'", con)
        ds2 = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds2, "CharterSteelCoilIdentification")
        con.Close()

        cboHeatNumber.DisplayMember = "HeatNumber"
        cboHeatNumber.DataSource = ds2.Tables("CharterSteelCoilIdentification")
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadPONumber()
        cmd = New SqlCommand("SELECT DISTINCT(PurchaseOrderNumber) AS PurchaseOrderNumber FROM CharterSteelCoilIdentification WHERE Status <> 'CLOSED'", con)
        ds3 = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds3, "PurchaseOrderHeaderTable")
        con.Close()

        cboPONumber.DisplayMember = "PurchaseOrderNumber"
        cboPONumber.DataSource = ds3.Tables("PurchaseOrderHeaderTable")
        cboPONumber.SelectedIndex = -1
    End Sub

    ''RMID takes precidence if it is filled in
    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        cmd = New SqlCommand("SELECT CoilID, Carbon, SteelSize, HeatNumber, Weight, ReceiveDate, Status, AnnealLot, Comment, Location FROM CharterSteelCoilIdentification", con)
        Dim cmd1 As New SqlCommand("SELECT SUM(Weight) as TotalWeight, COUNT(WEIGHT) as CoilCount FROM CharterSteelCoilIdentification", con)
        Dim isFirst As Boolean = True
        ''if carbon has something selected
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            If chkAllTypes.Checked Then
                If isFirst Then
                    isFirst = False
                    cmd.CommandText += " WHERE Carbon like @Carbon"
                    cmd1.CommandText += " WHERE Carbon like @Carbon"
                Else
                    cmd.CommandText += " AND Carbon like @Carbon"
                    cmd1.CommandText += " AND Carbon like @Carbon"
                End If
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
                cmd1.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
            Else
                If isFirst Then
                    isFirst = False
                    cmd.CommandText += " WHERE Carbon = @Carbon"
                    cmd1.CommandText += " WHERE Carbon = @Carbon"
                Else
                    cmd.CommandText += " AND Carbon = @Carbon"
                    cmd1.CommandText += " AND Carbon = @Carbon"
                End If
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                cmd1.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            End If
            
        End If
        ''if size has something in the field
        If Not String.IsNullOrEmpty(txtSteelSize.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE SteelSize = @Size"
                cmd1.CommandText += " WHERE SteelSize = @Size"
            Else
                cmd.CommandText += " AND SteelSize = @Size"
                cmd1.CommandText += " AND SteelSize = @Size"
            End If
            cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = txtSteelSize.Text
            cmd1.Parameters.Add("@Size", SqlDbType.VarChar).Value = txtSteelSize.Text
        End If
        ''if heat has something selected
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE HeatNumber = @Heat"
                cmd1.CommandText += " WHERE HeatNumber = @Heat"
            Else
                cmd.CommandText += " AND HeatNumber = @Heat"
                cmd1.CommandText += " AND HeatNumber = @Heat"
            End If
            cmd.Parameters.Add("@Heat", SqlDbType.VarChar).Value = cboHeatNumber.Text
            cmd1.Parameters.Add("@Heat", SqlDbType.VarChar).Value = cboHeatNumber.Text
        End If
        ''if despatch has something in the field
        If String.IsNullOrEmpty(txtDespatchNumber.Text) = False Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE DespatchNumber = @Despatch"
                cmd1.CommandText += " WHERE DespatchNumber = @Despatch"
            Else
                cmd.CommandText += " AND DespatchNumber = @Despatch"
                cmd1.CommandText += " AND DespatchNumber = @Despatch"
            End If
            cmd.Parameters.Add("@Despatch", SqlDbType.VarChar).Value = txtDespatchNumber.Text
            cmd1.Parameters.Add("@Despatch", SqlDbType.VarChar).Value = txtDespatchNumber.Text
        End If
        ''if status has something selected
        If Not String.IsNullOrEmpty(cboStatus.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE Status = @Status"
                cmd1.CommandText += " WHERE Status = @Status"
            Else
                cmd.CommandText += " AND Status = @Status"
                cmd1.CommandText += " AND Status = @Status"
            End If
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = cboStatus.Text
            cmd1.Parameters.Add("@Status", SqlDbType.VarChar).Value = cboStatus.Text
        End If
        ''if purchase order number has something in the field
        If Not String.IsNullOrEmpty(cboPONumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE PurchaseOrderNumber = @PO"
                cmd1.CommandText += " WHERE PurchaseOrderNumber = @PO"
            Else
                cmd.CommandText += " AND PurchaseOrderNumber = @PO"
                cmd1.CommandText += " AND PurchaseOrderNumber = @PO"
            End If
            cmd.Parameters.Add("@PO", SqlDbType.VarChar).Value = cboPONumber.Text
            cmd1.Parameters.Add("@PO", SqlDbType.VarChar).Value = cboPONumber.Text
        End If
        If chkAllTypes.Checked Then
            cmd.CommandText += " ORDER BY Carbon, CoilID, SteelSize"
        End If
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "CharterSteelCoilIdentification")
        Dim reader As SqlDataReader = cmd1.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("TotalWeight")) Then
                lblTotalWeight.Text = "0"
            Else
                lblTotalWeight.Text = FormatNumber(reader.Item("TotalWeight"), 0)
            End If
            If IsDBNull(reader.Item("CoilCount")) Then
                lblTotalCoils.Text = "0"
            Else
                lblTotalCoils.Text = FormatNumber(reader.Item("CoilCount"), 0)
            End If
        Else
            lblTotalWeight.Text = "0"
            lblTotalCoils.Text = "0"
        End If
        reader.Close()
        con.Close()

        dgvCharterCoils.DataSource = ds.Tables("CharterSteelCoilIdentification")
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub txtbxSteelSize_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSteelSize.KeyUp
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrEmpty(txtSteelSize.Text) = False Then
                cmdView_Click(sender, e)
            End If
            cboHeatNumber.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub cboCarbon_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCarbon.KeyUp
        If e.KeyCode = Keys.Enter Then
            If cboCarbon.SelectedIndex <> -1 Then
                cmdView_Click(sender, e)
            End If
            txtSteelSize.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCarbon.SelectedIndex = -1
        cboCarbon.Text = ""
        chkAllTypes.Checked = False
        cboPONumber.SelectedIndex = -1
        cboPONumber.Text = ""
        cboStatus.Text = "RAW"
        cboHeatNumber.SelectedIndex = -1
        cboHeatNumber.Text = ""
        txtSteelSize.Text = ""
        txtDespatchNumber.Text = ""
        ds = New DataSet()
        dgvCharterCoils.DataSource = ds.Tables("")
        lblTotalWeight.Text = ""
        lblTotalCoils.Text = ""
        cboCarbon.Focus()
    End Sub

    Private Sub cboHeatNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboHeatNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            If cboHeatNumber.SelectedIndex <> -1 Then
                cmdView_Click(sender, e)
            End If
            txtDespatchNumber.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub txtbxDespatchNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDespatchNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrEmpty(txtDespatchNumber.Text) = False Then
                cmdView_Click(sender, e)
            End If
            cboStatus.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub cboStatus_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboStatus.KeyUp
        If e.KeyCode = Keys.Enter Then
            If cboStatus.SelectedIndex <> -1 Then
                cmdView_Click(sender, e)
            End If
            cboPONumber.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub cboPONumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPONumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            If cboPONumber.SelectedIndex <> -1 Then
                cmdView_Click(sender, e)
            End If
            cmdView.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub cmdView_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdView.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdClear.Focus()
            e.Handled = True
        End If
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

    Private Sub hideSuggest(ByVal ctrl As String)
        If Not String.IsNullOrEmpty(ctrl) Then
            Select Case ctrl
                Case "cboCarbon"
                    lstCarbonSuggest.Visible = False
                Case "cboSteelSize"
                    'lstSizeSuggest.Visible = False
                Case "cboHeatNumber"
                    lstHeatSuggest.Visible = False
            End Select
        End If
    End Sub

    ''input section start
    Private Sub cmdZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZero.Click
        addText(sender, e, "0")
    End Sub

    Private Sub cmdDash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDash.Click
        addText(sender, e, "-")
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

    Private Sub addText(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal tex As String, Optional ByVal charCount As Integer = 1)
        If Not String.IsNullOrEmpty(FocusedField.name) Then
            ''check to see if there is a selection
            If FocusedField.selectLength > 0 Then
                cmdBackspace_Click(sender, e)
            End If
            If FocusedField.position = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length Then
                Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text += tex
            Else
                If FocusedField.position > Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length Then
                    FocusedField.position = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length
                End If
                Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Substring(0, FocusedField.position) + tex + Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Substring(FocusedField.position, Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length - FocusedField.position)
            End If
            If charCount > 1 Then
                FocusedField.position += charCount - 1
            End If
            Me.Controls(FocusedField.parent).Controls(FocusedField.name).Focus()
        End If
    End Sub

    Private Sub cmdBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackspace.Click
        If Not String.IsNullOrEmpty(FocusedField.name) Then
            ''check to make sure there is something to delete
            If Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length > 0 Then
                wasDeleted = True
                ''check to see if there was a selection made
                If FocusedField.selectLength > 0 Then
                    Select Case True
                        Case FocusedField.selectLength = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length
                            Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text = ""
                            FocusedField.position = 0
                            Exit Select
                        Case FocusedField.position = 0
                            Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Substring(FocusedField.selectLength, Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length - FocusedField.selectLength)
                            Exit Select
                        Case FocusedField.selectLength = (Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length - FocusedField.position)
                            Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Substring(0, FocusedField.position)
                            FocusedField.position = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length
                            Exit Select
                        Case Else
                            If FocusedField.position > Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length Then
                                FocusedField.position = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length
                            End If
                            Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Substring(0, FocusedField.position) + Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Substring(FocusedField.position + FocusedField.selectLength, Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length - (FocusedField.position + FocusedField.selectLength))
                    End Select
                    FocusedField.selectLength = 0
                Else
                    ''check to se if we are at the back of the text
                    If FocusedField.position = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length Then
                        Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Substring(0, Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length - 1)
                        FocusedField.position = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length
                    Else
                        If FocusedField.position > 0 Then
                            Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text = Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Substring(0, FocusedField.position - 1) + Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Substring(FocusedField.position, Me.Controls(FocusedField.parent).Controls(FocusedField.name).Text.Length - FocusedField.position)
                            FocusedField.position -= 1
                        End If
                    End If
                End If
            End If
            Me.Controls(FocusedField.parent).Controls(FocusedField.name).Focus()
        End If
    End Sub

    Private Sub cboCarbon_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("cboCarbon") Then
                hideSuggest(FocusedField.name)
                FocusedField = New FocusedItem(cboCarbon)
            Else
                cboCarbon.SelectionStart = FocusedField.position
            End If
        Else
            hideSuggest(FocusedField.name)
            FocusedField = New FocusedItem(cboCarbon)
        End If
    End Sub

    Private Sub cboSteelSize_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSteelSize.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("txtSteelSize") Then
                hideSuggest(FocusedField.name)
                FocusedField = New FocusedItem(txtSteelSize)
            Else
                txtSteelSize.SelectionStart = FocusedField.position
            End If
        Else
            hideSuggest(FocusedField.name)
            FocusedField = New FocusedItem(txtSteelSize)
        End If
    End Sub

    Private Sub cboCarbon_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboCarbon.MouseUp
        If FocusedField.isSet() Then
            FocusedField.position = cboCarbon.SelectionStart
            FocusedField.selectLength = cboCarbon.SelectionLength
        End If
    End Sub

    Private Sub txtSteelSize_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSteelSize.MouseUp
        If FocusedField.isSet() Then
            FocusedField.position = txtSteelSize.SelectionStart
            FocusedField.selectLength = txtSteelSize.SelectionLength
        End If
    End Sub

    Private Sub cboHeatNumber_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboHeatNumber.MouseUp
        If FocusedField.isSet() Then
            FocusedField.position = cboHeatNumber.SelectionStart
            FocusedField.selectLength = cboHeatNumber.SelectionLength
        End If
    End Sub

    Private Sub cboCarbon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.TextChanged
        If cboCarbon.Focused Then
            FocusedField.position = cboCarbon.SelectionStart
            FocusedField.selectLength = 0
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
        lstCarbonSuggest.Visible = False
        lstCarbonSuggest.Items.Clear()
        If canSuggestCarbon() Then
            For i As Integer = 0 To ds1.Tables("RawMaterialsTable").Rows.Count - 1
                If ds1.Tables("RawMaterialsTable").Rows(i).Item("Carbon").ToString.Contains(cboCarbon.Text) Then
                    lstCarbonSuggest.Items.Add(ds1.Tables("RawMaterialsTable").Rows(i).Item("Carbon"))
                End If
            Next
            formatListbox(lstCarbonSuggest)
        End If
    End Sub

    Private Function canSuggestCarbon() As Boolean
        If String.IsNullOrEmpty(FocusedField.name) Then
            Return False
        End If
        If Not FocusedField.name.Equals("cboCarbon") Then
            Return False
        End If
        If cboCarbon.Focused Then
            Return False
        End If
        If cboCarbon.Text.Length = 0 Then
            Return False
        End If
        Return True
    End Function

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
        lstbx.Visible = True
    End Sub

    Private Sub lstCarbonSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCarbonSuggest.SelectedValueChanged
        If lstCarbonSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstCarbonSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                cboCarbon.Text = lstCarbonSuggest.SelectedItem
                lstCarbonSuggest.Visible = False
                txtSteelSize.Focus()
            End If
        End If
    End Sub

    Private Sub cboHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.TextChanged
        If cboHeatNumber.Focused Then
            FocusedField.position = cboHeatNumber.SelectionStart
            FocusedField.selectLength = 0
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
        lstHeatSuggest.Visible = False
        lstHeatSuggest.Items.Clear()
        If canSuggestHeat() Then
            For i As Integer = 0 To ds2.Tables("CharterSteelCoilIdentification").Rows.Count - 1
                If ds2.Tables("CharterSteelCoilIdentification").Rows(i).Item("HeatNumber").ToString.Contains(cboHeatNumber.Text) Then
                    lstHeatSuggest.Items.Add(ds2.Tables("CharterSteelCoilIdentification").Rows(i).Item("HeatNumber"))
                End If
            Next
            formatListbox(lstHeatSuggest)
        End If
    End Sub

    Private Function canSuggestHeat() As Boolean
        If String.IsNullOrEmpty(FocusedField.name) Then
            Return False
        End If
        If Not FocusedField.name.Equals("cboHeatNumber") Then
            Return False
        End If
        If cboHeatNumber.Focused Then
            Return False
        End If
        If cboHeatNumber.Text.Length = 0 Then
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
                txtDespatchNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cboHeatNumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("cboHeatNumber") Then
                hideSuggest(FocusedField.name)
                FocusedField = New FocusedItem(cboHeatNumber)
            Else
                cboHeatNumber.SelectionStart = FocusedField.position
            End If
        Else
            hideSuggest(FocusedField.name)
            FocusedField = New FocusedItem(cboHeatNumber)
        End If
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        Select Case FocusedField.name
            Case "cboCarbon"
                If lstCarbonSuggest.Items.Count = 1 Then
                    If Not cboCarbon.Text.Equals(lstCarbonSuggest.Items(0)) Then
                        cboCarbon.Text = lstCarbonSuggest.Items(0)
                    End If
                End If
                txtSteelSize.Focus()
            Case "txtSteelSize"
                cboHeatNumber.Focus()
            Case "cboHeatNumber"
                If lstHeatSuggest.Items.Count = 1 Then
                    If Not cboHeatNumber.Text.Equals(lstHeatSuggest.Items(0)) Then
                        cboHeatNumber.Text = lstHeatSuggest.Items(0)
                    End If
                End If
                txtDespatchNumber.Focus()
            Case "txtDespatchNumber"
                cboStatus.Focus()
            Case "cboStatus"
                cboPONumber.Focus()
            Case "cboPONumber"
                cmdView.Focus()
            Case Else
                cmdView.Focus()
        End Select
    End Sub

    Private Sub cmdKeyboardExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKeyboardExit.Click
        Me.Close()
    End Sub

    Private Sub cmdKeyboardPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKeyboardPrint.Click
        GDS = ds
        Using NewPrintCoilListing As New PrintCoilListing
            Dim result = NewPrintCoilListing.ShowDialog()
        End Using
    End Sub

    Private Sub txtDespatchNumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDespatchNumber.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("txtDespatchNumber") Then
                hideSuggest(FocusedField.name)
                FocusedField = New FocusedItem(txtDespatchNumber)
            Else
                txtDespatchNumber.SelectionStart = FocusedField.position
            End If
        Else
            hideSuggest(FocusedField.name)
            FocusedField = New FocusedItem(txtDespatchNumber)
        End If
    End Sub

    Private Sub txtDespatchNumber_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDespatchNumber.MouseUp
        If FocusedField.isSet() Then
            FocusedField.position = txtDespatchNumber.SelectionStart
            FocusedField.selectLength = txtDespatchNumber.SelectionLength
        End If
    End Sub

    Private Sub txtDespatchNumber_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDespatchNumber.MouseClick
        If txtDespatchNumber.Focused Then
            FocusedField.position = txtDespatchNumber.SelectionStart
        End If
    End Sub

    Private Sub cboCarbon_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboCarbon.MouseClick
        If cboCarbon.Focused Then
            FocusedField.position = cboCarbon.SelectionStart
        End If
    End Sub

    Private Sub txtSteelSize_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSteelSize.MouseClick
        If txtSteelSize.Focused Then
            FocusedField.position = txtSteelSize.SelectionStart
        End If
    End Sub

    Private Sub cboHeatNumber_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboHeatNumber.MouseClick
        If cboHeatNumber.Focused Then
            FocusedField.position = cboHeatNumber.SelectionStart
        End If
    End Sub

    Private Sub cboStatus_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboStatus.MouseClick
        If cboStatus.Focused Then
            FocusedField.position = cboStatus.SelectionStart
        End If
    End Sub

    Private Sub cboPONumber_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboPONumber.MouseClick
        If cboPONumber.Focused Then
            FocusedField.position = cboPONumber.SelectionStart
        End If
    End Sub

    Private Sub cboPONumber_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboPONumber.MouseUp
        If FocusedField.isSet() Then
            FocusedField.position = cboPONumber.SelectionStart
            FocusedField.selectLength = cboPONumber.SelectionLength
        End If
    End Sub

    Private Sub cboStatus_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboStatus.MouseUp
        If FocusedField.isSet() Then
            FocusedField.position = cboStatus.SelectionStart
            FocusedField.selectLength = cboStatus.SelectionLength
        End If
    End Sub

    Private Sub txtDespatchNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDespatchNumber.TextChanged
        If txtDespatchNumber.Focused Then
            FocusedField.position = txtDespatchNumber.SelectionStart
            FocusedField.selectLength = 0
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
    End Sub

    Private Sub cboStatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.TextChanged
        If cboStatus.Focused Then
            FocusedField.position = cboStatus.SelectionStart
            FocusedField.selectLength = 0
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
    End Sub

    Private Sub cboPONumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPONumber.TextChanged
        If cboPONumber.Focused Then
            FocusedField.position = cboPONumber.SelectionStart
            FocusedField.selectLength = 0
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
    End Sub

    Private Sub cboStatus_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("cboStatus") Then
                hideSuggest(FocusedField.name)
                FocusedField = New FocusedItem(cboStatus)
            Else
                cboStatus.SelectionStart = FocusedField.position
            End If
        Else
            hideSuggest(FocusedField.name)
            FocusedField = New FocusedItem(cboStatus)
        End If
    End Sub

    Private Sub cboPONumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPONumber.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("cboPONumber") Then
                hideSuggest(FocusedField.name)
                FocusedField = New FocusedItem(cboPONumber)
            Else
                cboPONumber.SelectionStart = FocusedField.position
            End If
        Else
            hideSuggest(FocusedField.name)
            FocusedField = New FocusedItem(cboPONumber)
        End If
    End Sub

    Private Sub cmdView_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Enter
        If FocusedField.isSet() Then
            hideSuggest(FocusedField.name)
            FocusedField = New FocusedItem()
        End If
    End Sub

    Private Sub txtSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSteelSize.TextChanged
        If txtSteelSize.Focused Then
            FocusedField.position = txtSteelSize.SelectionStart
            FocusedField.selectLength = 0
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
    End Sub

    Private Sub dgvCharterCoils_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCharterCoils.CellDoubleClick
        If e.RowIndex <> -1 AndAlso e.ColumnIndex <> -1 AndAlso e.RowIndex < dgvCharterCoils.Rows.Count Then
            Dim Comment As String = ""
            If Not IsDBNull(dgvCharterCoils.Rows(e.RowIndex).Cells("Comment").Value) Then
                Comment = dgvCharterCoils.Rows(e.RowIndex).Cells("Comment").Value
            End If
            CoilComment.Show(dgvCharterCoils.Rows(e.RowIndex).Cells("CoilID").Value, e.RowIndex, Comment)
            If System.IO.File.Exists("C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe") Then
                oskProcess = Process.Start("C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe")
            Else
                oskProcess = Process.Start("osk")
            End If
        End If
    End Sub

    Private Sub CoilCommentHidden()
        If oskProcess IsNot Nothing AndAlso Not oskProcess.HasExited Then
            oskProcess.CloseMainWindow()
            oskProcess.Kill()
            oskProcess = Nothing
        End If
        If CoilComment.DialogResult = System.Windows.Forms.DialogResult.OK Then
            cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Comment = @Comment WHERE CoilID = @CoilID", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = CoilComment.lblCoilID.Text
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = CoilComment.txtComment.Text

            If con.State = ConnectionState.Closed Then con.Open()

            Try
                cmd.ExecuteNonQuery()
                Dim index As Integer = CoilComment.RowIndex

                dgvCharterCoils.Rows(index).Cells("Comment").Value = CoilComment.txtComment.Text
                ColorDGVLines()
            Catch ex As System.Exception
                MessageBox.Show("There was an issue with saving the coil comment.", "Unable to save comment", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
            con.Close()
        End If
        Me.BringToFront()
    End Sub

    Private Sub ColorDGVLines()
        For i As Integer = 0 To dgvCharterCoils.Rows.Count - 1
            If Not IsDBNull(dgvCharterCoils.Rows(i).Cells("Comment").Value) AndAlso Not String.IsNullOrEmpty(dgvCharterCoils.Rows(i).Cells("Comment").Value) Then
                dgvCharterCoils.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
            ElseIf dgvCharterCoils.Rows(i).DefaultCellStyle.BackColor <> dgvCharterCoils.DefaultCellStyle.BackColor Then
                dgvCharterCoils.Rows(i).DefaultCellStyle.BackColor = dgvCharterCoils.DefaultCellStyle.BackColor
            End If
        Next
    End Sub

    Private Sub dgvCharterCoils_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCharterCoils.CellClick
        If e.ColumnIndex < dgvCharterCoils.ColumnCount AndAlso e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (dgvCharterCoils.Columns(e.ColumnIndex).Name.Equals("Location") Or dgvCharterCoils.Columns(e.ColumnIndex).Name.Equals("Comment")) Then
            txtLocationValue.Text = dgvCharterCoils.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
            pnlChangeLocation.Show()
            txtLocationValue.Focus()
            dgvCharterCoils.Enabled = False
        End If
    End Sub

    Private Sub txtLocationValue_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocationValue.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("txtLocationValue") Then
                hideSuggest(FocusedField.name)
                FocusedField = New FocusedItem(txtLocationValue)
            Else
                txtLocationValue.SelectionStart = FocusedField.position
            End If
        Else
            hideSuggest(FocusedField.name)
            FocusedField = New FocusedItem(txtLocationValue)
        End If
    End Sub

    Private Sub txtLocationValue_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLocationValue.MouseClick
        If txtLocationValue.Focused Then
            FocusedField.position = txtLocationValue.SelectionStart
        End If
    End Sub

    Private Sub txtLocationValue_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLocationValue.MouseUp
        If FocusedField.isSet() Then
            FocusedField.position = txtLocationValue.SelectionStart
            FocusedField.selectLength = txtLocationValue.SelectionLength
        End If
    End Sub

    Private Sub cmdChangeLocationValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeLocationValue.Click
        pnlChangeLocation.Hide()
        cmd = New SqlCommand("", con)
        Dim columnIndex As Integer = dgvCharterCoils.SelectedCells(0).ColumnIndex
        Dim rowIndex As Integer = dgvCharterCoils.SelectedCells(0).RowIndex
        If dgvCharterCoils.Columns(columnIndex).Name.Equals("Location") Then
            cmd.CommandText = "UPDATE CharterSteelCoilIdentification SET Location = @NewLocation WHERE CoilID = @CoilID"
            cmd.Parameters.Add("@NewLocation", SqlDbType.VarChar).Value = txtLocationValue.Text
        Else
            cmd.CommandText = "UPDATE CharterSteelCoilIdentification SET Comment = @NewComment WHERE CoilID = @CoilID"
            cmd.Parameters.Add("@NewComment", SqlDbType.VarChar).Value = txtLocationValue.Text
        End If

        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = dgvCharterCoils.Rows(rowIndex).Cells("CoilID").Value.ToString()

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        cmdView_Click(sender, e)

        dgvCharterCoils.Rows(rowIndex).Cells(columnIndex).Selected = True
        dgvCharterCoils.Enabled = True
        dgvCharterCoils.Focus()
    End Sub

    Private Sub cmdCancelLocationChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelLocationChange.Click
        pnlChangeLocation.Hide()
        dgvCharterCoils.Enabled = True
        dgvCharterCoils.Focus()
    End Sub

    Private Sub txtLocationValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocationValue.TextChanged
        If txtLocationValue.Focused Then
            FocusedField.position = txtLocationValue.SelectionStart
            FocusedField.selectLength = 0
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
    End Sub

    Private Sub ViewCharterSteelCoils_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class