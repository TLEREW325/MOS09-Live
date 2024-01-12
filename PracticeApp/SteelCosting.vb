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
Public Class SteelCosting
    Inherits System.Windows.Forms.Form

    Dim DateFilter, ReferenceFilter, CarbonFilter, SteelSizeFilter, BothFilter As String
    Dim BeginDate, EndDate As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub SteelCosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCarbon()
        LoadSteelSize()
        LoadReferenceNumber()
    End Sub

    Public Sub ShowDataByFilters()
        'Define filters
        If chkAllTypes.Checked = True And cboCarbon.Text <> "" Then
            CarbonFilter = " AND Carbon LIKE '%" + cboCarbon.Text + "%'"
        ElseIf chkAllTypes.Checked = True And cboCarbon.Text = "" Then
            CarbonFilter = ""
        ElseIf chkAllTypes.Checked = False Then
            If cboCarbon.Text <> "" Then
                CarbonFilter = " AND Carbon = '" + usefulFunctions.checkQuote(cboCarbon.Text) + "'"
            Else
                CarbonFilter = ""
            End If
        End If
        If cboSteelSize.Text <> "" Then
            SteelSizeFilter = " AND SteelSize = '" + usefulFunctions.checkQuote(cboSteelSize.Text) + "'"
        Else
            SteelSizeFilter = ""
        End If
        If cboReferenceNumber.Text <> "" Then
            ReferenceFilter = " AND ReferenceNumber = '" + cboReferenceNumber.Text + "'"
        Else
            ReferenceFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
            DateFilter = " AND CostingDate BETWEEN @BeginDate AND @EndDate"
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM SteelCostingTable WHERE RMID <> ''" + CarbonFilter + SteelSizeFilter + ReferenceFilter + DateFilter + " ORDER BY RMID ASC", con)
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelCostingTable")
        dgvSteelCosting.DataSource = ds.Tables("SteelCostingTable")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSteelCosting.DataSource = Nothing
    End Sub

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadReferenceNumber()
        cmd = New SqlCommand("SELECT DISTINCT ReferenceNumber FROM SteelCostingTable ORDER BY ReferenceNumber ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SteelCostingTable")
        cboReferenceNumber.DataSource = ds3.Tables("SteelCostingTable")
        con.Close()
        cboReferenceNumber.SelectedIndex = -1
    End Sub

    Public Sub ClearVariables()
        DateFilter = ""
        ReferenceFilter = ""
        CarbonFilter = ""
        SteelSizeFilter = ""
        BothFilter = ""
        BeginDate = ""
        EndDate = ""
    End Sub

    Public Sub ClearData()
        chkAllTypes.Checked = False
        chkDateRange.Checked = False

        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboReferenceNumber.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboCarbon.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintSteelCosting As New PrintSteelCurrentCosting
            Dim Result = NewPrintSteelCosting.ShowDialog()
        End Using
    End Sub
End Class