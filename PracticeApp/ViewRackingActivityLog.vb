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
Public Class ViewRackingActivityLog
    Inherits System.Windows.Forms.Form

    Dim BeginDate, EndDate As Date
    Dim PickFilter, LotFilter, HeatFilter, BinFilter, PartFilter, DateFilter, Division1Filter, Division2Filter, Division3Filter As String
    Dim DivisionSQLFilter As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewRackingActivityLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadPartNumber()
        LoadPartDescription()
        LoadLotNumber()
        LoadHeatNumber()
        LoadBinNumber()

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        If EmployeeCompanyCode = "SLC" Then
            DivisionSQLFilter = " AND DivisionID = 'SLC'"
        Else
            DivisionSQLFilter = " AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        End If
    End Sub

    Public Sub ShowDataByFilter()
        If cboLotNumber.Text <> "" Then
            LotFilter = " AND LotNumber = '" + cboLotNumber.Text + "'"
        Else
            LotFilter = ""
        End If
        If cboHeatNumber.Text <> "" Then
            HeatFilter = " AND HeatNumber = '" + cboHeatNumber.Text + "'"
        Else
            HeatFilter = ""
        End If
        If cboBinNumber.Text <> "" Then
            BinFilter = " AND BinNumber = '" + cboBinNumber.Text + "'"
        Else
            BinFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtPickTicketNumber.Text <> "" Then
            PickFilter = " AND PickTicketNumber = '" + txtPickTicketNumber.Text + "'"
        Else
            PickFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND RackDate >= @BeginDate AND RackDate <= @EndDate"
        End If

        If chkTrufit.Checked = True And chkTruweld.Checked = True And chkSLCParts.Checked = True Then
            Division1Filter = " AND (DivisionID = 'TFP' OR DivisionID = 'TWD' OR DivisionID = 'SLC')"
        ElseIf chkTrufit.Checked = True And chkTruweld.Checked = True And chkSLCParts.Checked = False Then
            Division1Filter = " AND (DivisionID = 'TFP' OR DivisionID = 'TWD')"
        ElseIf chkTrufit.Checked = True And chkTruweld.Checked = False And chkSLCParts.Checked = False Then
            Division1Filter = " AND DivisionID = 'TFP'"
        ElseIf chkTrufit.Checked = True And chkTruweld.Checked = False And chkSLCParts.Checked = True Then
            Division1Filter = " AND (DivisionID = 'TFP' OR DivisionID = 'SLC')"
        ElseIf chkTrufit.Checked = False And chkTruweld.Checked = True And chkSLCParts.Checked = True Then
            Division1Filter = " AND (DivisionID = 'TWD' OR DivisionID = 'SLC')"
        ElseIf chkTrufit.Checked = False And chkTruweld.Checked = True And chkSLCParts.Checked = False Then
            Division1Filter = " AND DivisionID = 'TWD'"
        ElseIf chkTrufit.Checked = False And chkTruweld.Checked = False And chkSLCParts.Checked = True Then
            Division1Filter = " AND DivisionID = 'SLC'"
        Else
            Division1Filter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM TFPRackingActivityLog WHERE DivisionID <> @DivisionID" + BinFilter + HeatFilter + PartFilter + LotFilter + PickFilter + Division1Filter + DateFilter + " ORDER BY ActivityDateTime", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TFPRackingActivityLog")
        dgvRackingActivityLog.DataSource = ds.Tables("TFPRackingActivityLog")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvRackingActivityLog.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE ItemClass <> @ItemClass" + DivisionSQLFilter + " ORDER BY ItemID", con)
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE ItemClass <> @ItemClass" + DivisionSQLFilter + " ORDER BY ItemID", con)
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE Status = 'CLOSED' ORDER BY LotNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "LotNumber")
        cboLotNumber.DataSource = ds3.Tables("LotNumber")
        con.Close()
        cboLotNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT HeatNumber FROM HeatNumberLog ORDER BY HeatNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "HeatNumberLog")
        cboHeatNumber.DataSource = ds4.Tables("HeatNumberLog")
        con.Close()
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBinNumber()
        cmd = New SqlCommand("SELECT BinNumber FROM BinNumber WHERE RackPosition <> 'UNAVAILABLE'" + DivisionSQLFilter + " ORDER BY BinNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "BinNumber")
        cboBinNumber.DataSource = ds5.Tables("BinNumber")
        con.Close()
        cboBinNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription" + DivisionSQLFilter
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub ClearData()
        cboBinNumber.SelectedIndex = -1
        cboHeatNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1

        txtPickTicketNumber.Clear()

        chkDateRange.Checked = False

        If EmployeeCompanyCode = "SLC" Then
            chkTrufit.Checked = False
            chkTruweld.Checked = False
            chkSLCParts.Checked = True
            chkTrufit.Enabled = False
            chkTruweld.Enabled = False
            chkSLCParts.Enabled = True
        Else
            chkTrufit.Checked = True
            chkTruweld.Checked = True
            chkSLCParts.Checked = False
            chkTrufit.Enabled = True
            chkTruweld.Enabled = True
            chkSLCParts.Enabled = True
        End If
    End Sub

    Public Sub ClearVariables()
        LotFilter = ""
        HeatFilter = ""
        BinFilter = ""
        PartFilter = ""
        DateFilter = ""
        Division1Filter = ""
        PickFilter = ""
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID" + DivisionSQLFilter
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
 
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintRackingActivity As New PrintRackingActivityLog
            Dim Result = NewPrintRackingActivity.ShowDialog()
        End Using
    End Sub
End Class