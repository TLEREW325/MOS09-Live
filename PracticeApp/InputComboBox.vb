Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class InputComboBox

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Initializes the ComboBox with the user specified field.
    ''' </summary>
    ''' <param name="InputText">Field that should be displayed</param>
    ''' <param name="LimitingField">Division ID or another limiting field.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal InputText As String, ByVal LimitingField As String)
        InitializeComponent()
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As SqlCommand

        Select Case InputText
            Case "Customer ID"
                cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = LimitingField
            Case "FOX"
                If String.IsNullOrEmpty(LimitingField) Then
                    cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable", con)
                Else
                    cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = LimitingField
                End If
            Case "Part Number"
                If String.IsNullOrEmpty(LimitingField) Then
                    cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = 'TWD' OR DivisionID = 'TFP'", con)
                Else
                    cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = LimitingField
                End If
            Case "Carbon"
                If String.IsNullOrEmpty(LimitingField) Then
                    cmd = New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable ORDER BY Carbon", con)
                Else
                    cmd = New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable WHERE SteelSize = @SteelSize ORDER BY Carbon", con)
                    cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = LimitingField
                End If
            Case "Lot Number"
                If String.IsNullOrEmpty(LimitingField) Then
                    cmd = New SqlCommand("SELECT LotNumber FROM LotNumber", con)
                Else
                    cmd = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE PartNumber = @PartNumber", con)
                    cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LimitingField
                End If
            Case Else
                cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = LimitingField
        End Select

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboInputValue.Items.Add(reader.Item(0))
            End While
        End If
        reader.Close()
        con.Close()
        lblInputType.Text = InputText
        Me.Text = "Input " + InputText
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If Not cboInputValue.SelectedIndex = -1 Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Not a valid entry", "Not a valid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInputValue.Focus()
            cboInputValue.SelectAll()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub InputComboBox_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = System.Windows.Forms.DialogResult.None Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub
End Class
