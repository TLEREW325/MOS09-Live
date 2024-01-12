Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class FinalPieceInspectionSignoff
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim isloaded As Boolean = False

    Public Sub New()
        InitializeComponent()
        LoadLotNumber()

        If con.State = ConnectionState.Open Then con.Close()
        isloaded = True
    End Sub

    Private Sub LoadLotNumber()
        cboLotNumber.Items.Clear()
        'load lotnumbers from table to combo box
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE QCInspected = 'NO' and Status = 'CLOSED';", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboLotNumber.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub LoadPartData()
        'read selected lot number, load lot number data into lbls.text
        Dim LotNumberData As String = "SELECT ShortDescription, PartNumber, FoxNumber FROM LotNumber WHERE LotNumber = @LotNumber;"
        Dim LotNumberCommand As New SqlCommand(LotNumberData, con)
        LotNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LotNumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            lblPartNumber.Text = reader.Item("PartNumber")
            lblShortDescription.Text = reader.Item("ShortDescription")
            lblFoxNumber.Text = reader.Item("FoxNumber")
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        If isloaded Then
            If cboLotNumber.SelectedIndex <> -1 Then
                LoadPartData()
            Else
                'clear everything but Lot Number and Inspector
                lblPartNumber.Text = ""
                lblShortDescription.Text = ""
                lblFoxNumber.Text = ""
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        isloaded = False
        'clear everything when clear button is clicked
        cboLotNumber.Text = ""
        txtQcInspector.Clear()
        lblPartNumber.Text = ""
        lblShortDescription.Text = ""
        lblFoxNumber.Text = ""
        isloaded = True
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If CanUpdate() Then
            cmd = New SqlCommand("UPDATE LotNumber SET QCInspected = 'YES', QCInspector = @QCInspector, QCInspectorPC = @QCInspectorPC, QCInspectedDateTime = @QCInspectedDateTime WHERE LotNumber = @LotNumber;", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
            cmd.Parameters.Add("@QCInspector", SqlDbType.VarChar).Value = txtQcInspector.Text
            cmd.Parameters.Add("@QCInspectorPC", SqlDbType.VarChar).Value = My.Computer.Name
            cmd.Parameters.Add("@QCInspectedDateTime", SqlDbType.DateTime2).Value = Now
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            LoadLotNumber()
            ClearForm()
        End If

    End Sub

    Private Function CanUpdate() As Boolean
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must enter a lot number", "Enter a lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid lot number", "You must enter a valid lot number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtQcInspector.Text) Then
            MessageBox.Show("You must enter an inspector", "Enter an inspector", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQcInspector.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtQcInspector.Text.Replace(" ", "")) Then
            MessageBox.Show("You must enter an inspector", "Enter an inspector", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQcInspector.SelectAll()
            txtQcInspector.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub FinalPieceInspectionSignoff_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        isloaded = False
    End Sub
End Class