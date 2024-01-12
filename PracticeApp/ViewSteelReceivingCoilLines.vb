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
Public Class ViewSteelReceivingCoilLines
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim CarbonFilter, SteelSizeFilter, HeatFilter, DateFilter, CoilIDFilter, POFilter, BOLFilter, VendorFilter As String
    Dim BeginDate, EndDate As String

    Private Sub ViewSteelReceivingCoilLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadSteelCarbon()
        LoadSteelSize()
        LoadHeatNumber()
        LoadSteelVendor()
        LoadSteelBOLNumber()
        LoadSteelPONumber()
        LoadSteelCoilID()
    End Sub

    Public Sub ShowDataByFilters()
        If cboCoilID.Text = "" Then
            CoilIDFilter = ""
        Else
            CoilIDFilter = " AND CoilID = '" + cboCoilID.Text + "'"
        End If
        If cboHeatNumber.Text = "" Then
            HeatFilter = ""
        Else
            HeatFilter = " AND HeatNumber = '" + cboHeatNumber.Text + "'"
        End If
        If cboBOL.Text = "" Then
            BOLFilter = ""
        Else
            BOLFilter = " AND SteelBOLNumber = '" + cboBOL.Text + "'"
        End If
        If cboSteelVendor.Text = "" Then
            VendorFilter = ""
        Else
            VendorFilter = " AND SteelVendor = '" + cboSteelVendor.Text + "'"
        End If
        If cboPONumber.Text = "" Then
            POFilter = ""
        Else
            Dim SteelPONumber As Integer = 0
            Dim strSteelPONumber As String = ""

            SteelPOnumber = Val(cboPONumber.Text)
            strSteelPONumber = CStr(SteelPONumber)

            POFilter = " AND SteelPONumber = '" + strSteelPONumber + "'"
        End If
        If chkAllTypes.Checked = True Then
            If cboCarbon.Text = "" Then
                CarbonFilter = ""
            Else
                CarbonFilter = " AND Carbon LIKE '" + cboCarbon.Text + "%'"
            End If
            If cboSteelSize.Text = "" Then
                SteelSizeFilter = ""
            Else
                SteelSizeFilter = " AND SteelSize LIKE '" + cboSteelSize.Text + "%'"
            End If
        Else
            If cboCarbon.Text = "" Then
                CarbonFilter = ""
            Else
                CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
            End If
            If cboSteelSize.Text = "" Then
                SteelSizeFilter = ""
            Else
                SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
            End If
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBegin.Text
            EndDate = dtpEnd.Text

            DateFilter = " AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Else
            BeginDate = dtpBegin.Text
            EndDate = dtpEnd.Text

            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM SteelReceivingLineQuery WHERE DivisionID = @DivisionID" + CoilIDFilter + HeatFilter + CarbonFilter + SteelSizeFilter + POFilter + VendorFilter + BOLFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReceivingLineQuery")
        dgvSteelReceivingCoilLines.DataSource = ds.Tables("SteelReceivingLineQuery")
        con.Close()

        LoadSteelTotals()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvSteelReceivingCoilLines.DataSource = Nothing
    End Sub

    Public Sub LoadSteelCarbon()
        cmd = New SqlCommand("SELECT DISTINCT (Carbon) FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY Carbon ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT (SteelSize) FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY SteelSize ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT (HeatNumber) FROM HeatNumberLog WHERE Status = @Status ORDER BY HeatNumber ASC", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "HeatNumberLog")
        cboHeatNumber.DataSource = ds3.Tables("HeatNumberLog")
        con.Close()
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE VendorClass = @VendorClass ORDER BY VendorCode ASC", con)
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "Vendor")
        cboSteelVendor.DataSource = ds4.Tables("Vendor")
        con.Close()
        cboSteelVendor.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelPONumber()
        cmd = New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID ORDER BY SteelPurchaseOrderKey ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "SteelPurchaseOrderHeader")
        cboPONumber.DataSource = ds5.Tables("SteelPurchaseOrderHeader")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelBOLNumber()
        cmd = New SqlCommand("SELECT DISTINCT (DespatchNumber) FROM CharterSteelCoilIdentification ORDER BY DespatchNumber ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CharterSteelCoilIdentification")
        cboBOL.DataSource = ds6.Tables("CharterSteelCoilIdentification")
        con.Close()
        cboBOL.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelCoilID()
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification ORDER BY CoilID ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "CharterSteelCoilIdentification")
        cboCoilID.DataSource = ds7.Tables("CharterSteelCoilIdentification")
        con.Close()
        cboCoilID.SelectedIndex = -1
    End Sub

    Public Sub ClearVariables()
        CarbonFilter = ""
        SteelSizeFilter = ""
        HeatFilter = ""
        DateFilter = ""
        CoilIDFilter = ""
        POFilter = ""
        BOLFilter = ""
        VendorFilter = ""
        BeginDate = ""
        EndDate = ""
    End Sub

    Public Sub ClearData()
        lblTotalCoilAmount.Text = ""
        lblTotalCoils.Text = ""
        lblTotalWeight.Text = ""

        cboBOL.SelectedIndex = -1
        cboCarbon.SelectedIndex = -1
        cboCoilID.SelectedIndex = -1
        cboHeatNumber.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboSteelVendor.SelectedIndex = -1

        txtVendorName.Clear()

        dtpBegin.Text = ""
        dtpEnd.Text = ""

        chkAllTypes.Checked = False
        chkDateRange.Checked = False

        cboCarbon.Focus()
    End Sub

    Public Sub LoadVendorName()
        Dim VendorName As String = ""

        Dim VendorNameString As String = "SELECT VendorName FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
        Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboSteelVendor.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
    End Sub

    Public Sub LoadSteelTotals()
        Dim CountCoils As Integer = 0
        Dim TotalCoilWeight As Double = 0
        Dim TotalCoilCost As Double = 0

        Dim CountCoilsString As String = "SELECT COUNT(SteelReceivingHeaderKey) FROM SteelReceivingLineQuery WHERE DivisionID = @DivisionID" + CoilIDFilter + HeatFilter + CarbonFilter + SteelSizeFilter + POFilter + VendorFilter + BOLFilter + DateFilter
        Dim CountCoilsCommand As New SqlCommand(CountCoilsString, con)
        CountCoilsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        CountCoilsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        CountCoilsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalCoilWeightString As String = "SELECT SUM(CoilWeight) FROM SteelReceivingLineQuery WHERE DivisionID = @DivisionID" + CoilIDFilter + HeatFilter + CarbonFilter + SteelSizeFilter + POFilter + VendorFilter + BOLFilter + DateFilter
        Dim TotalCoilWeightCommand As New SqlCommand(TotalCoilWeightString, con)
        TotalCoilWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        TotalCoilWeightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalCoilWeightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalCoilCostString As String = "SELECT SUM(SteelExtendedAmount) FROM SteelReceivingLineQuery WHERE DivisionID = @DivisionID" + CoilIDFilter + HeatFilter + CarbonFilter + SteelSizeFilter + POFilter + VendorFilter + BOLFilter + DateFilter
        Dim TotalCoilCostCommand As New SqlCommand(TotalCoilCostString, con)
        TotalCoilCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        TotalCoilCostCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalCoilCostCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountCoils = CInt(CountCoilsCommand.ExecuteScalar)
        Catch ex As Exception
            CountCoils = 0
        End Try
        Try
            TotalCoilWeight = CDbl(TotalCoilWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalCoilWeight = 0
        End Try
        Try
            TotalCoilCost = CDbl(TotalCoilCostCommand.ExecuteScalar)
        Catch ex As Exception
            TotalCoilCost = 0
        End Try
        con.Close()

        lblTotalCoils.Text = FormatNumber(CountCoils, 0)
        lblTotalWeight.Text = FormatNumber(TotalCoilWeight, 0)
        lblTotalCoilAmount.Text = FormatCurrency(TotalCoilCost, 2)
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintSteelReceivingCoilLines As New PrintSteelReceivingCoilLines
            Dim result = NewPrintSteelReceivingCoilLines.ShowDialog()
        End Using
    End Sub

    Private Sub dgvSteelReceivingCoilLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelReceivingCoilLines.CellDoubleClick
        If Me.dgvSteelReceivingCoilLines.RowCount > 0 Then
            Dim RowCoilID As String = ""

            Dim RowIndex As Integer = Me.dgvSteelReceivingCoilLines.CurrentCell.RowIndex

            RowCoilID = Me.dgvSteelReceivingCoilLines.Rows(RowIndex).Cells("CoilIDColumn").Value
            GlobalCoilID = RowCoilID

            Using NewSteelCoilPopup As New SteelCoilPopup
                Dim result = NewSteelCoilPopup.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cboSteelVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelVendor.SelectedIndexChanged
        LoadVendorName()
    End Sub
End Class