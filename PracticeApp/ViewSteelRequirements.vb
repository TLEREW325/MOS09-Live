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
Imports System.ComponentModel
Public Class ViewSteelRequirements
    Inherits System.Windows.Forms.Form

    Dim CarbonFilter, SteelSizeFilter, MinReqFilter, TextFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewSteelRequirements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCarbon()
        LoadSteelSize()
    End Sub

    Public Sub ShowDataByFilters()
        If chkAllTypes.Checked = True Then
            If cboCarbon.Text = "" Then
                CarbonFilter = ""
            Else
                CarbonFilter = " AND Carbon LIKE '" + cboCarbon.Text + "%'"
            End If
        Else
            If cboCarbon.Text = "" Then
                CarbonFilter = ""
            Else
                CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
            End If
        End If
        If cboSteelSize.Text = "" Then
            SteelSizeFilter = ""
        Else
            SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
        End If
        If txtSteelRequired.Text = "" Then
            MinReqFilter = ""
        Else
            MinReqFilter = " AND SteelRequirements > '" + txtSteelRequired.Text + "'"
        End If
        If txtTextFilter.Text = "" Then
            TextFilter = ""
        Else
            TextFilter = " AND (RMID LIKE '%" + txtTextFilter.Text + "%' OR SteelSize LIKE '%" + txtTextFilter.Text + "%')"
        End If

        cmd = New SqlCommand("SELECT * FROM SteelFOXReportQuery WHERE RMID <> 'DEFAULT'" + CarbonFilter + SteelSizeFilter + MinReqFilter + TextFilter + " ORDER BY RMID", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelFOXReportQuery")
        dgvSteelFOXQuery.DataSource = ds.Tables("SteelFOXReportQuery")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvSteelFOXQuery.DataSource = Nothing
    End Sub

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        lblLoadingMessage.Visible = True
        pbProgressBar.Visible = True
        ShowDataByFilters()
        GetWIPForRMID()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        chkAllTypes.Checked = False
        txtSteelRequired.Clear()
        txtTextFilter.Clear()
        pbProgressBar.Visible = False
        lblLoadingMessage.Visible = False
        ClearDataInDatagrid()
        ds = New DataSet
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintReportToolStripMenuItem.Click
        If Me.dgvSteelFOXQuery.RowCount > 0 Then
            GDS = ds

            Using NewPrintSteelRequirements As New PrintSteelRequirements
                Dim result = NewPrintSteelRequirements.ShowDialog()
            End Using
        Else
            MsgBox("There is no data to print.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvSteelFOXQuery_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSteelFOXQuery.ColumnHeaderMouseClick
        GetWIPForRMID()
    End Sub

    Private Sub dgvSteelFOXQuery_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSteelFOXQuery.DoubleClick
        If dgvSteelFOXQuery.Rows.Count > 0 Then
            If dgvSteelFOXQuery.CurrentCell.RowIndex <> -1 Then
                Dim newSteelRequirementsDetails = New ViewSteelRequirementDetails(dgvSteelFOXQuery.Rows(dgvSteelFOXQuery.CurrentCell.RowIndex).Cells("RMIDColumn").Value)
                newSteelRequirementsDetails.Show()
            End If
        End If
    End Sub

    Public Sub GetWIPForRMID()
        'Set PB defaults
        pbProgressBar.Visible = True
        pbProgressBar.Value = pbProgressBar.Minimum

        Me.pbProgressBar.Maximum = 1280
        Me.pbProgressBar.Minimum = 0
        Me.pbProgressBar.Step = 1
        Me.pbProgressBar.Increment(1)

        Dim GetRMIDForWIP As String = ""
        Dim GetBeginningNumber, GetEndingNumber, GetBlankWeight As Double
        Dim GetSteelRequirements As Double = 0
        Dim Counter As Integer = 0

        For Each row As DataGridViewRow In dgvSteelFOXQuery.Rows
            Try
                GetRMIDForWIP = row.Cells("RMIDColumn").Value
            Catch ex As Exception
                GetRMIDForWIP = ""
            End Try
            Try
                GetSteelRequirements = row.Cells("SteelRequirementsColumn").Value
            Catch ex As Exception
                GetSteelRequirements = 0
            End Try

            If GetSteelRequirements < 0 Then
                row.Cells("SteelRequirementsColumn").Value = 0
            Else
                'Do nothing
            End If

            Dim BeginningStatement As String = "SELECT SUM(LineWeight) FROM TimeSlipLineQuery WHERE RMID = @RMID AND FOXStep = @FOXStep"
            Dim BeginningCommand As New SqlCommand(BeginningStatement, con)
            BeginningCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMIDForWIP
            BeginningCommand.Parameters.Add("@FOXStep", SqlDbType.VarChar).Value = 1

            Dim EndingStatement As String = "SELECT SUM(LineWeight) FROM TimeSlipLineQuery WHERE RMID = @RMID AND InventoryPieces <> 0"
            Dim EndingCommand As New SqlCommand(EndingStatement, con)
            EndingCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMIDForWIP

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetBeginningNumber = CDbl(BeginningCommand.ExecuteScalar)
            Catch ex As Exception
                GetBeginningNumber = 0
            End Try
            Try
                GetEndingNumber = CDbl(EndingCommand.ExecuteScalar)
            Catch ex As Exception
                GetEndingNumber = 0
            End Try
            con.Close()

            GetBlankWeight = GetBeginningNumber - GetEndingNumber
            If GetBlankWeight < 0 Then
                GetBlankWeight = 0
            End If

            row.Cells("BlanksColumn").Value = GetBlankWeight

            Do While Counter < 1280
                pbProgressBar.PerformStep()
                Counter = Counter + 1
            Loop
        Next

        lblLoadingMessage.Visible = False
        pbProgressBar.Visible = False
    End Sub
End Class