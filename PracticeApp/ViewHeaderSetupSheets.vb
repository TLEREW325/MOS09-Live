Imports System.Data.SqlClient

Public Class ViewHeaderSetupSheets
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Public Sub New()
        InitializeComponent()

        LoadFOXNumbers()
        LoadBlueprintNumbers()
        LoadMachineNumbers()
        LoadPartNumbers()
        If con.State = ConnectionState.Open Then con.Close()
    End Sub

    Private Sub LoadFOXNumbers()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboFOXNumber.Items.Add(reader.Item("FOXNumber"))
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadBlueprintNumbers()
        cmd = New SqlCommand("SELECT DISTINCT(BlueprintNumber) as BlueprintNumber FROM FOXTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboBlueprintNumber.Items.Add(reader.Item("BlueprintNumber"))
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadMachineNumbers()
        cmd = New SqlCommand("SELECT MachineID FROM MachineTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboMachineNumber.Items.Add(reader.Item("MachineID"))
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadPartNumbers()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = 'TWD' OR DivisionID = 'TFP'", con)
        Dim ds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "ItemList")

        cboPartNumber.DisplayMember = "ItemID"
        cboPartDescription.DisplayMember = "ShortDescription"
        cboPartNumber.DataSource = ds.Tables("ItemList")
        cboPartDescription.DataSource = ds.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        cmd = New SqlCommand("SELECT SetupKey, FOXNumber, Date, Description, BlueprintNumber, BlueprintRevision, Operator, MachineNumber, CustomerID, Comments FROM HeaderSetupHeaderTable", con)

        Dim isFirst As Boolean = True
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE FOXNumber = @FOXNumber"
            Else
                cmd.CommandText += " AND FOXNumber = @FOXNumber"
            End If
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
        End If
        If Not String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE BlueprintNumber = @BlueprintNumber"
            Else
                cmd.CommandText += " AND BlueprintNumber = @BlueprintNumber"
            End If
            cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBlueprintNumber.Text
        End If
        If Not String.IsNullOrEmpty(txtBlueprintRevision.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE BlueprintRevision = @BlueprintRevision"
            Else
                cmd.CommandText += " AND BlueprintRevision = @BlueprintRevision"
            End If
            cmd.Parameters.Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtBlueprintRevision.Text
        End If
        If Not String.IsNullOrEmpty(cboMachineNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE MachineNumber = @MachineNumber"
            Else
                cmd.CommandText += " AND MachineNumber = @MachineNumber"
            End If
            cmd.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE Description = @Description"
            Else
                cmd.CommandText += " AND Description = @Description"
            End If
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = cboPartDescription.Text
        End If

        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "HeaderSetupHeaderTable")
        con.Close()
        dgvHeaderSetupSheets.DataSource = tempds.Tables("HeaderSetupHeaderTable")

        dgvHeaderSetupSheets.Columns("SetupKey").Visible = False
        dgvHeaderSetupSheets.Columns("FOXNumber").HeaderText = "FOX Number"
        dgvHeaderSetupSheets.Columns("BlueprintNumber").HeaderText = "Blueprint Number"
        dgvHeaderSetupSheets.Columns("BlueprintRevision").HeaderText = "Blueprint Revision"
        dgvHeaderSetupSheets.Columns("MachineNumber").HeaderText = "Machine Number"
        dgvHeaderSetupSheets.Columns("CustomerID").HeaderText = "Customer ID"
        dgvHeaderSetupSheets.Columns("Date").DefaultCellStyle.Format = "MM/dd/yyyy"

    End Sub

    Private Sub cmdPrintSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintSheet.Click
        If dgvHeaderSetupSheets.SelectedCells.Count > 0 Then
            Dim newPrintHeaderSetupSheet As New PrintHeaderSetupSheet(dgvHeaderSetupSheets.Rows(dgvHeaderSetupSheets.SelectedCells(0).RowIndex).Cells("SetupKey").Value)
            newPrintHeaderSetupSheet.ShowDialog()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboFOXNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cboFOXNumber.Text = ""
        End If
        cboBlueprintNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
            cboBlueprintNumber.Text = ""
        End If
        txtBlueprintRevision.Clear()
        cboMachineNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboMachineNumber.Text) Then
            cboMachineNumber.Text = ""
        End If
        cboPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
            cboPartDescription.Text = ""
        End If
        dgvHeaderSetupSheets.DataSource = Nothing
    End Sub

    Private Sub dgvHeaderSetupSheets_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHeaderSetupSheets.CellContentDoubleClick
        If e.RowIndex <> -1 Then
            Dim newPrintHeaderSetupSheet As New PrintHeaderSetupSheet(dgvHeaderSetupSheets.Rows(e.RowIndex).Cells("SetupKey").Value)
            newPrintHeaderSetupSheet.ShowDialog()
        End If
    End Sub
End Class