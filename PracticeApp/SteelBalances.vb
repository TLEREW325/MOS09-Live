Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class SteelBalances
    Inherits System.Windows.Forms.Form
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim dt As Data.DataTable

    Private Sub SteelBalances_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        LoadCarbon()
        LoadSteelSize()
    End Sub

    Private Sub LoadCarbon()
        Dim cmd As New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Dim ds As New DataSet
        Dim myAdapter As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "RawMaterialsTable")
        con.Close()

        cboSteelCarbon.DisplayMember = "Carbon"
        cboSteelCarbon.DataSource = ds.Tables("RawMaterialsTable")
        cboSteelCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        Dim cmd As New SqlCommand("SELECT DISTINCT(SteelSize) FROM RawMaterialsTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "RawMaterialsTable")
        con.Close()

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = ds.Tables("RawMaterialsTable")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub LoadDescription()
        Dim SteelDescription As String
        Dim SteelDescriptionString As String = "SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND DivisionID = @DivisionID"
        Dim SteelDescriptionCommand As New SqlCommand(SteelDescriptionString, con)
        SteelDescriptionCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        SteelDescriptionCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        SteelDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelDescription = CStr(SteelDescriptionCommand.ExecuteScalar)
        Catch ex As System.SystemException
            SteelDescription = ""
        End Try
        con.Close()

        txtSteelDescription.Text = SteelDescription
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboSteelCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboSteelCarbon.Text) Then
            cboSteelCarbon.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If
      
        txtSteelDescription.Clear()
        cboSteelCarbon.Focus()
        dgvSteelBalances.DataSource = Nothing
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim isFirst As Boolean = True

        Dim cmd As New SqlCommand("SELECT * FROM SteelInventoryTotals", con)

        If cboSteelSize.Text.Contains("/") Then
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
        Else
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = GetFractional(cboSteelSize.Text)
        End If

        If chkQOH.Checked Then
            cmd.CommandText += " Where SteelEndingInventory > 0"
            If String.IsNullOrEmpty(cboSteelCarbon.Text) = False Then
                cmd.CommandText += " And Carbon = @Carbon"
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
            End If
            If String.IsNullOrEmpty(cboSteelSize.Text) = False Then
                cmd.CommandText += " AND (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
            End If

        ElseIf chkQOH.Checked = False Then

            If String.IsNullOrEmpty(cboSteelCarbon.Text) = False Then
                If isFirst Then
                    cmd.CommandText += " WHERE Carbon = @Carbon"
                    isFirst = False
                Else
                    cmd.CommandText += " And Carbon = @Carbon"
                End If
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
            End If


            If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                If isFirst Then
                    cmd.CommandText += " WHERE (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
                    isFirst = False
                Else
                    cmd.CommandText += " AND (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
                End If
            End If
        End If

        dt = New Data.DataTable("SteelInventoryTotals")
        Dim myAdapter As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dt)
        con.Close()
        dgvSteelBalances.DataSource = dt
    End Sub

    Private Sub cmdOpenVoucherForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenVoucherForm.Click
        Using NewRawMaterialMaintenanceForm As New RawMaterialMaintenanceForm
            Dim result = NewRawMaterialMaintenanceForm.ShowDialog()
        End Using
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboSteelCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelCarbon.SelectedIndexChanged
        If String.IsNullOrEmpty(cboSteelCarbon.Text) = False And String.IsNullOrEmpty(cboSteelSize.Text) = False Then
            LoadDescription()
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If String.IsNullOrEmpty(cboSteelCarbon.Text) = False And String.IsNullOrEmpty(cboSteelSize.Text) = False Then
            LoadDescription()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintListingToolStripMenuItem.Click
        Dim newPrintListing As New PrintSteelBalances(dt)
        newPrintListing.ShowDialog()
    End Sub

    Private Sub cboSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.TextChanged
        If cboSteelSize.Text.StartsWith(".") And cboSteelSize.Text.Length = 1 Then
            cboSteelSize.Text = "0."
            cboSteelSize.Select(cboSteelSize.Text.Length, 0)
        End If
    End Sub
End Class