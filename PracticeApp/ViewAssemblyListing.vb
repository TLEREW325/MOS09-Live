Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewAssemblyListing
    Inherits System.Windows.Forms.Form

    Dim AssemblyDescription As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ViewAssemblyListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvAssemblyListing.DataSource = Nothing
    End Sub

    Public Sub ShowAllData()
        cmd = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblyHeaderTable")
        dgvAssemblyListing.DataSource = ds.Tables("AssemblyHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowDataByPart()
        cmd = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber AND ItemClass <> 'DEACTIVATED-PART'", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblyHeaderTable")
        dgvAssemblyListing.DataSource = ds.Tables("AssemblyHeaderTable")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' AND PurchProdLineID = @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' AND PurchProdLineID = @PurchProdLineID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadAssemblyDescription()
        Dim AssemblyDescriptionStatement As String = "SELECT AssemblyDescription FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
        Dim AssemblyDescriptionCommand As New SqlCommand(AssemblyDescriptionStatement, con)
        AssemblyDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AssemblyDescriptionCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AssemblyDescription = CStr(AssemblyDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            AssemblyDescription = ""
        End Try
        con.Close()

        txtAssemblyDescription.Text = AssemblyDescription
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
        LoadAssemblyDescription()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        ShowAllData()
        ClearData()
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub ClearData()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        txtAssemblyDescription.Clear()
        cboPartNumber.Focus()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        If cboPartNumber.Text = "" Then
            ShowAllData()
        Else
            ShowDataByPart()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ShowAllData()
    End Sub

    Private Sub cmdOpenItemMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenItemMaintenance.Click
        If cboPartNumber.Text = "" Then
            GlobalItemListingPartNumber = ""
        Else
            GlobalItemListingPartNumber = cboPartNumber.Text
        End If

        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvAssemblyListing_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssemblyListing.CellValueChanged
        If Me.dgvAssemblyListing.RowCount <> 0 Then
            Dim RowPartNumber As String = ""
            Dim RowIndex As Integer = Me.dgvAssemblyListing.CurrentCell.RowIndex

            RowPartNumber = Me.dgvAssemblyListing.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value







        End If
    End Sub

    Private Sub dgvAssemblyListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssemblyListing.CellDoubleClick
        If Me.dgvAssemblyListing.RowCount <> 0 Then
            Dim RowPartNumber As String = ""
            Dim RowIndex As Integer = Me.dgvAssemblyListing.CurrentCell.RowIndex

            RowPartNumber = Me.dgvAssemblyListing.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value

            GlobalAssemblyPartNumber = RowPartNumber

            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintAssemblyBOM As New PrintAssemblyBOM
                Dim Result = NewPrintAssemblyBOM.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdPrintBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintBOM.Click
        If cboPartNumber.Text = "" Then
            If Me.dgvAssemblyListing.RowCount <> 0 Then
                Dim RowPartNumber As String = ""
                Dim RowIndex As Integer = Me.dgvAssemblyListing.CurrentCell.RowIndex

                RowPartNumber = Me.dgvAssemblyListing.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value

                GlobalAssemblyPartNumber = RowPartNumber
            End If
        Else
            GlobalAssemblyPartNumber = cboPartNumber.Text
        End If

        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintAssemblyBOM As New PrintAssemblyBOM
            Dim Result = NewPrintAssemblyBOM.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintAssemblyListingFiltered As New PrintAssemblyListingFiltered
            Dim Result = NewPrintAssemblyListingFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintAssemblyListingFiltered As New PrintAssemblyListingFiltered
            Dim Result = NewPrintAssemblyListingFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboPartNumber.Text = "" Then
            MsgBox("Select a valid part number.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Verify Delete
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Assembly", "DELETE ASSEMBLY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete Line
                cmd = New SqlCommand("DELETE FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Delete Header
                cmd = New SqlCommand("DELETE FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Me.dgvAssemblyListing.DataSource = Nothing

                MsgBox("Assembly has been deleted.", MsgBoxStyle.OkOnly)
            ElseIf button = DialogResult.No Then
                cboPartNumber.Focus()
            End If
        End If
    End Sub
End Class