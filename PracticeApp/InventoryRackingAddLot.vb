Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class InventoryRackingAddLot
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim isLoaded As Boolean = False
    Dim controlkey As Boolean = False

    Public Sub New()
        InitializeComponent()
        LoadLots()
        isLoaded = True
    End Sub

    Public Sub New(ByVal part As String)
        InitializeComponent()
        LoadLots(part)
        isLoaded = True
    End Sub

    Private Sub LoadLots(Optional ByVal part As String = Nothing)
        cmd = New SqlCommand("SELECT LotNumber, BoxCount FROM LotNumber", con)
        If part IsNot Nothing Then
            cmd.CommandText += " WHERE PartNumber = @PartNumber"
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = part
        End If
        Dim dt As New Data.DataTable("LotNumber")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()
        If cboLotNumber.DisplayMember <> "LotNumber" Then cboLotNumber.DisplayMember = "LotNumber"
        cboLotNumber.DataSource = dt
        cboLotNumber.SelectedIndex = -1
    End Sub

    Private Sub txtBoxes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxes.TextChanged, txtPiecesPerBox.TextChanged
        lblTotalPieces.Text = Val(txtBoxes.Text) * Val(txtPiecesPerBox.Text)
    End Sub

    Private Sub txtBoxes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoxes.KeyPress, txtPiecesPerBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not controlkey Then
            e.KeyChar = Nothing
        End If
        controlkey = False
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If CanAdd() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Function CanAdd() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must enter a lot number", "Enter a lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid lot number", "Enter a lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBoxes.Text) Then
            MessageBox.Show("You must enter a box quantity", "Enter a box quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBoxes.Focus()
            Return False
        End If
        If Not IsNumeric(txtBoxes.Text) Then
            MessageBox.Show("You must enter a valid box quantity", "Enter a valid box quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBoxes.SelectAll()
            txtBoxes.Focus()
            Return False
        End If
        If txtBoxes.Text.Contains(".") Then
            MessageBox.Show("Box quantity must be a whole number.", "Enter a valid box quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBoxes.SelectAll()
            txtBoxes.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPiecesPerBox.Text) Then
            MessageBox.Show("You must enter a pieces per box", "Enter a pieces per box", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiecesPerBox.Focus()
            Return False
        End If
        If Not IsNumeric(txtPiecesPerBox.Text) Then
            MessageBox.Show("You must enter a pieces per box", "Enter a valid pieces per box", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiecesPerBox.SelectAll()
            txtPiecesPerBox.Focus()
            Return False
        End If
        If txtPiecesPerBox.Text.Contains(".") Then
            MessageBox.Show("Pieces per box must be a whole number.", "Enter a valid pieces per box", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiecesPerBox.SelectAll()
            txtPiecesPerBox.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        If isLoaded AndAlso cboLotNumber.SelectedIndex <> -1 AndAlso String.IsNullOrEmpty(txtPiecesPerBox.Text) Then
            txtPiecesPerBox.Text = CType(cboLotNumber.DataSource, Data.DataTable).Rows(cboLotNumber.SelectedIndex).Item("BoxCount").ToString
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtBoxes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxes.KeyDown, txtPiecesPerBox.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Tab Then
            controlkey = True
        End If
    End Sub
End Class