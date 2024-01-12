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
Public Class ViewSteelWireYardEntry
    Inherits System.Windows.Forms.Form

    Dim CarbonFilter, CarbonLikeFilter, SteelSizeFilter, HeatFilter, CoilIDFilter, DateFilter As String
    Dim BeginDate, EndDate As Date
    Dim CarbonLength As Integer = 0
    Dim CarbonPrefix As String = ""
    Dim TotalNumberOfCoils As Integer = 0
    Dim TotalWeight As Double = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewSteelWireYardEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadSteelSize()
        LoadSteelType()
        LoadHeatNumber()
        LoadCoilID()

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Public Sub ShowDataByFilters()
        If cboCarbon.Text <> "" Then
            If chkAllTypes.Checked = True Then
                CarbonLength = cboCarbon.Text.Length
                If CarbonLength > 4 Then
                    CarbonPrefix = cboCarbon.Text.Substring(0, 5)
                Else
                    CarbonPrefix = cboCarbon.Text.Substring(0, CarbonLength)
                End If

                CarbonFilter = " AND Carbon LIKE '%" + CarbonPrefix + "%'"
            Else
                CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
            End If
        Else
            CarbonFilter = ""
        End If
        If cboSteelSize.Text <> "" Then
            SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
        Else
            SteelSizeFilter = ""
        End If
        If cboCoilID.Text <> "" Then
            CoilIDFilter = " AND CoilID = '" + cboCoilID.Text + "'"
        Else
            CoilIDFilter = ""
        End If
        If cboHeatNumber.Text <> "" Then
            HeatFilter = " AND HeatNumber = '" + cboHeatNumber.Text + "'"
        Else
            HeatFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM SteelWireYardEntryQuery WHERE DivisionID <> @DivisionID" + CarbonFilter + CarbonLikeFilter + SteelSizeFilter + HeatFilter + CoilIDFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelWireYardEntryQuery")
        dgvSteelYardEntry.DataSource = ds.Tables("SteelWireYardEntryQuery")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSteelYardEntry.DataSource = Nothing
    End Sub

    Public Sub LoadSteelType()
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

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT HeatNumber FROM HeatNumberLog ORDER BY HeatNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "HeatNumberLog")
        cboHeatNumber.DataSource = ds2.Tables("HeatNumberLog")
        con.Close()
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCoilID()
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification ORDER BY CoilID", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CharterSteelCoilIdentification")
        cboCoilID.DataSource = ds2.Tables("CharterSteelCoilIdentification")
        con.Close()
        cboCoilID.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboCarbon.SelectedIndex = -1
        cboCoilID.SelectedIndex = -1
        cboHeatNumber.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1

        chkAllTypes.Checked = False
        chkDateRange.Checked = False

        txtCoilWeight.Clear()
        txtNumberOfCoils.Clear()

        dtpBeginDate.Value = Today()
        dtpEndDate.Value = Today
    End Sub

    Public Sub ClearVariables()
        CarbonFilter = ""
        CarbonLikeFilter = ""
        SteelSizeFilter = ""
        HeatFilter = ""
        CoilIDFilter = ""
        DateFilter = ""
        CarbonLength = 0
        CarbonPrefix = ""
        TotalNumberOfCoils = 0
        TotalWeight = 0
    End Sub

    Public Sub LoadDatagridTotals()
        Dim TotalCoilsString As String = "SELECT COUNT(SteelReturnKey) FROM SteelWireYardEntryQuery WHERE DivisionID <> @DivisionID" + CarbonFilter + CarbonLikeFilter + SteelSizeFilter + HeatFilter + CoilIDFilter + DateFilter
        Dim TotalCoilsCommand As New SqlCommand(TotalCoilsString, con)
        TotalCoilsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        TotalCoilsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalCoilsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalWeightString As String = "SELECT SUM(ReturnWeight)FROM SteelWireYardEntryQuery WHERE DivisionID <> @DivisionID" + CarbonFilter + CarbonLikeFilter + SteelSizeFilter + HeatFilter + CoilIDFilter + DateFilter
        Dim TotalWeightCommand As New SqlCommand(TotalWeightString, con)
        TotalWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        TotalWeightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TotalWeightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalNumberOfCoils = CInt(TotalCoilsCommand.ExecuteScalar)
        Catch ex As Exception
            TotalNumberOfCoils = 0
        End Try
        Try
            TotalWeight = CDbl(TotalWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalWeight = 0
        End Try
        con.Close()

        txtCoilWeight.Text = FormatNumber(TotalWeight, 0)
        txtNumberOfCoils.Text = TotalNumberOfCoils
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
        LoadDatagridTotals()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintSteelYardEntryFiltered As New PrintSteelYardEntryFiltered
            Dim result = NewPrintSteelYardEntryFiltered.ShowDialog()
        End Using
    End Sub
End Class