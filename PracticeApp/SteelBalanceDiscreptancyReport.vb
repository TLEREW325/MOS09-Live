Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class SteelBalanceDiscreptancyReport
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Dim DoesNotContainFilter, CarbonFilter, SteelSizeFilter, TextFilter, CoilQuantityZeroFilter, SteelQuantityZeroFilter, NoDiscrepancyFilter As String

    Private Sub SteelBalanceDiscreptancyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdSearch

        LoadCarbon()
        LoadSteelSize()
        ShowAll()
    End Sub

    Private Sub ShowAll()
        cmd = New SqlCommand("SELECT * FROM SteelBalanceDiscreptancy WHERE Description <> @Description1 ORDER BY RMID", con)
        cmd.Parameters.Add("@Description1", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelBalanceDiscreptancy")
        dgvInventory.DataSource = ds.Tables("SteelBalanceDiscreptancy")
        con.Close()

        colorDifference()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvInventory.DataSource = Nothing
    End Sub

    Private Sub colorDifference()
        For i As Integer = 0 To dgvInventory.Rows.Count - 1
            If dgvInventory.Rows(i).Cells("DifferenceColumn").Value < 0 Then
                dgvInventory.Rows(i).Cells("DifferenceColumn").Style.BackColor = Color.LightCoral
                dgvInventory.Rows(i).Cells("DifferenceColumn").Style.ForeColor = Color.DarkRed
            Else
                If dgvInventory.Rows(i).Cells("DifferenceColumn").Value <> 0 Then
                    dgvInventory.Rows(i).Cells("DifferenceColumn").Style.BackColor = Color.LightGreen
                    dgvInventory.Rows(i).Cells("DifferenceColumn").Style.ForeColor = Color.DarkGreen
                End If
            End If
        Next
    End Sub

    Private Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub ShowDataByFilters()
        If cboCarbon.Text <> "" Then
            CarbonFilter = " AND Carbon = '" + usefulFunctions.checkQuote(cboCarbon.Text) + "'"
        Else
            CarbonFilter = ""
        End If
        If cboSteelSize.Text <> "" Then
            SteelSizeFilter = " AND SteelSize = '" + usefulFunctions.checkQuote(cboSteelSize.Text) + "'"
        Else
            SteelSizeFilter = ""
        End If
        If txtTextSearch.Text <> "" Then
            TextFilter = " AND Description LIKE '%" + txtTextSearch.Text + "%'"
        Else
            TextFilter = ""
        End If
        If txtDoesNotContain.Text <> "" Then
            DoesNotContainFilter = " AND Description NOT LIKE '%" + txtDoesNotContain.Text + "%'"
        Else
            DoesNotContainFilter = ""
        End If
        If chkZeroDiscrepancy.Checked = True Then
            NoDiscrepancyFilter = " AND Difference <> '0'"
        Else
            NoDiscrepancyFilter = ""
        End If
        If chkZeroCoils.Checked = True Then
            CoilQuantityZeroFilter = " AND SteelBalanceFromCoilTable <> '0'"
        Else
            CoilQuantityZeroFilter = ""
        End If
        If chkZeroQOH.Checked = True Then
            SteelQuantityZeroFilter = " AND CalculatedSteelBalance <> '0'"
        Else
            SteelQuantityZeroFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM SteelBalanceDiscreptancy WHERE Description <> @Description1" + CarbonFilter + SteelSizeFilter + TextFilter + DoesNotContainFilter + NoDiscrepancyFilter + CoilQuantityZeroFilter + SteelQuantityZeroFilter + " ORDER BY RMID", con)
        cmd.Parameters.Add("@Description1", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelBalanceDiscreptancy")
        dgvInventory.DataSource = ds.Tables("SteelBalanceDiscreptancy")
        con.Close()

        colorDifference()
    End Sub

    Public Sub Cleardata()
        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1

        txtTextSearch.Clear()
        txtDoesNotContain.Clear()

        chkZeroCoils.Checked = False
        chkZeroDiscrepancy.Checked = False
        chkZeroQOH.Checked = False

        cboCarbon.Focus()
    End Sub

    Public Sub ClearVariables()
        CarbonFilter = ""
        SteelSizeFilter = ""
        TextFilter = ""
        CoilQuantityZeroFilter = ""
        SteelQuantityZeroFilter = ""
        NoDiscrepancyFilter = ""
        DoesNotContainFilter = ""
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        ClearVariables()
        Cleardata()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        Cleardata()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintSteelDiscrepancyReport As New PrintSteelBalanceDiscreptancyReport
            Dim Result = NewPrintSteelDiscrepancyReport.ShowDialog
        End Using
    End Sub

    Private Sub dgvInventory_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInventory.ColumnHeaderMouseClick
        colorDifference()
    End Sub

    Private Sub cmdOpenRawMaterialMaintenanceForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenRawMaterialMaintenanceForm.Click
        Dim NewRawMaterialsMaintenanceForm As New RawMaterialMaintenanceForm
        NewRawMaterialsMaintenanceForm.Show()
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintSteelDiscrepancyReport As New PrintSteelBalanceDiscreptancyReport
            Dim Result = NewPrintSteelDiscrepancyReport.ShowDialog
        End Using
    End Sub

    Private Sub gpxSearchFields_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpxSearchFields.Enter

    End Sub
End Class
