Imports System.Data.SqlClient

Public Class TFPQuotationMachineCosting
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds As DataSet

    Dim isLoaded As Boolean = False

    Private Sub TFPQuotationMachineCosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMachineCosts()
        isLoaded = True
        If EmployeeSecurityCode <= 1002 Then
            DeleteSelectionToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub LoadMachineCosts()
        cmd = New SqlCommand("SELECT * FROM QuotationCosting;", con)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "QuotationCosting")
        con.Close()

        dgvQuoteCosting.DataSource = ds.Tables("QuotationCosting")
        SetupDGV()
    End Sub

    Private Sub SetupDGV()
        dgvQuoteCosting.Columns("QuoteCostKey").Visible = False
        dgvQuoteCosting.Columns("MachineType").HeaderText = "Machine Type"
        dgvQuoteCosting.Columns("MachineType").ReadOnly = True
        dgvQuoteCosting.Columns("MachineType").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvQuoteCosting.Columns("QuoteCost").HeaderText = "Quote Cost"
        dgvQuoteCosting.Columns("SetupCost").HeaderText = "Setup Cost"
        dgvQuoteCosting.Columns("LastUpdated").HeaderText = "Last Updated"

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dgvQuoteCosting_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuoteCosting.CellValueChanged
        If isLoaded Then
            cmd = New SqlCommand("UPDATE QuotationCosting SET QuoteCost = @QuoteCost, SetupCost = @SetupCost, LastUpdated = @LastUpdated WHERE QuoteCostKey = @QuoteCostKey;", con)
            With cmd.Parameters
                .Add("@QuoteCostKey", SqlDbType.Int).Value = dgvQuoteCosting.Rows(e.RowIndex).Cells("QuoteCostKey").Value
                .Add("@QuoteCost", SqlDbType.Float).Value = dgvQuoteCosting.Rows(e.RowIndex).Cells("QuoteCost").Value
                .Add("@SetupCost", SqlDbType.Float).Value = dgvQuoteCosting.Rows(e.RowIndex).Cells("SetupCost").Value
                .Add("@LastUpdated", SqlDbType.Date).Value = Today.Date
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            isLoaded = False
            LoadMachineCosts()
            isLoaded = True
            dgvQuoteCosting.CurrentCell = dgvQuoteCosting.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If canAddMachineType() Then
            cmd = New SqlCommand("INSERT INTO QuotationCosting (QuoteCostKey, MachineType, QuoteCost, SetupCost, LastUpdated) VALUES ((SELECT isnull(MAX(QuoteCostKey) + 1, 1) FROM QuotationCosting), @MachineType, @QuoteCost, @SetupCost, @LastUpdated);", con)

            With cmd.Parameters
                .Add("@MachineType", SqlDbType.VarChar).Value = txtMachineType.Text
                .Add("@QuoteCost", SqlDbType.Float).Value = Val(txtQuoteCost.Text)
                .Add("@SetupCost", SqlDbType.Float).Value = Val(txtSetupCost.Text)
                .Add("@LastUpdated", SqlDbType.Date).Value = Today.Date
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearControls()
            isLoaded = False
            LoadMachineCosts()
            isLoaded = True
            dgvQuoteCosting.FirstDisplayedScrollingRowIndex = dgvQuoteCosting.Rows.Count - 1
            MessageBox.Show("Machine Costing has been Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canAddMachineType() As Boolean
        If String.IsNullOrEmpty(txtMachineType.Text) Then
            MessageBox.Show("You must enter a Machine Type", "Enter a Machine Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMachineType.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtQuoteCost.Text) Then
            MessageBox.Show("You must enter a Quote Cost", "Enter a Quote Cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuoteCost.Focus()
            Return False
        End If
        If Not IsNumeric(txtQuoteCost.Text) Then
            MessageBox.Show("You must enter a number for Quote Cost", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuoteCost.SelectAll()
            txtQuoteCost.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(txtSetupCost.Text) Then
            If Not IsNumeric(txtSetupCost.Text) Then
                MessageBox.Show("You must enter a number for Setup Cost", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSetupCost.SelectAll()
                txtSetupCost.Focus()
                Return False
            End If
        Else
            txtSetupCost.Text = "0"
        End If
        Return True
    End Function

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearControls()
    End Sub

    Private Sub ClearControls()
        txtMachineType.Clear()
        txtQuoteCost.Clear()
        txtSetupCost.Clear()
        txtMachineType.Focus()
    End Sub

    Private Sub DeleteSelectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectionToolStripMenuItem.Click
        If canDelete() Then
            cmd = New SqlCommand("DELETE QuotationCosting WHERE QuoteCostKey = @QuoteCostKey;", con)
            cmd.Parameters.Add("@QuoteCostKey", SqlDbType.Int).Value = dgvQuoteCosting.Rows(dgvQuoteCosting.CurrentCell.RowIndex).Cells("QuoteCostKey").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            isLoaded = False
            LoadMachineCosts()
            isLoaded = True
            MessageBox.Show("Machine Costing has been Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canDelete() As Boolean
        If dgvQuoteCosting.Rows.Count = 0 Then
            MessageBox.Show("There are no Costs to Delete", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvQuoteCosting.CurrentCell Is Nothing Then
            MessageBox.Show("There is no row selected.", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function
End Class