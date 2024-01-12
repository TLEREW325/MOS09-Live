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
Public Class ViewFOXListing
    Inherits System.Windows.Forms.Form

    Dim PartFilter, CustomerFilter, RMIDFilter, FOXFilter, BlueprintFilter, SOFilter, ItemClassFilter, TextFilter, DivisionFilter, StatusFilter, DateFilter As String

    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewFOXListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        Me.AcceptButton = cmdView

        LoadCurrentDivision()

        'Load Defaults
        LoadBlueprintNumber()
        LoadFOXNumber()

        LoadSalesOrderNumber()
        LoadSteelCarbon()
        LoadSteelSize()

        If GlobalFOXNumber > 0 Then
            cboFOXNumber.Text = GlobalFOXNumber
        Else
            ClearData()
        End If
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvFoxListing.DataSource = Nothing
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboBlueprint.Text <> "" Then
            BlueprintFilter = " AND BlueprintNumber = '" + cboBlueprint.Text + "'"
        Else
            BlueprintFilter = ""
        End If
        If cboFOXNumber.Text <> "" Then
            FOXFilter = " AND FOXNumber = '" + cboFOXNumber.Text + "'"
        Else
            FOXFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SOFilter = " AND OrderReferenceNumber = '" + cboSalesOrderNumber.Text + "'"
        Else
            SOFilter = ""
        End If
        If txtCustomer.Text <> "" Then
            CustomerFilter = " AND CustomerID LIKE '%" + txtCustomer.Text + "%'"
        Else
            CustomerFilter = ""
        End If
        If txtRMID.Text <> "" Then
            RMIDFilter = " AND ScheduledRMID = '" + txtRMID.Text + "'"
        Else
            RMIDFilter = ""
        End If
        If cboStatus.Text <> "" Then
            StatusFilter = " AND Status = '" + cboStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If cboDivisionID.Text = "TWD" Then
            DivisionFilter = " AND DivisionID = '" + cboDivisionID.Text + "'"
        ElseIf cboDivisionID.Text = "TFP" Then
            DivisionFilter = " AND DivisionID = '" + cboDivisionID.Text + "'"
        Else
            DivisionFilter = ""
        End If
        If txtTextSearch.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '" + txtTextSearch.Text + "%' OR ShortDescription LIKE '%" + txtTextSearch.Text + "%')"
        Else
            TextFilter = ""
        End If
        If chkUseDateRange.Checked = True Then
            DateFilter = " AND CreationDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM FOXTableQuery WHERE DivisionID <> @DivisionID" + PartFilter + CustomerFilter + RMIDFilter + FOXFilter + BlueprintFilter + SOFilter + ItemClassFilter + TextFilter + StatusFilter + DivisionFilter + DateFilter + " ORDER BY FOXNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpStartDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXTableQuery")
        dgvFoxListing.DataSource = ds.Tables("FOXTableQuery")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "RawMaterialsTable")
        cboSteelCarbon.DataSource = ds3.Tables("RawMaterialsTable")
        con.Close()
        cboSteelCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "RawMaterialsTable")
        cboSteelSize.DataSource = ds4.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable ORDER BY FOXNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "FOXTable")
        cboFOXNumber.DataSource = ds5.Tables("FOXTable")
        con.Close()
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBlueprintNumber()
        cmd = New SqlCommand("SELECT DISTINCT BlueprintNumber FROM FOXTable ORDER BY BlueprintNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "FOXTable")
        cboBlueprint.DataSource = ds6.Tables("FOXTable")
        con.Close()
        cboBlueprint.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesOrderNumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD' ORDER BY SalesOrderKey", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds7.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadRMID()
        Dim RMID As String = ""

        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            RMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            RMID = ""
        End Try
        con.Close()

        txtRMID.Text = RMID
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
        cboBlueprint.SelectedIndex = -1
        cboFOXNumber.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboSteelCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1

        txtCustomer.Clear()
        txtRMID.Clear()
        txtTextSearch.Clear()

        chkUseDateRange.Checked = False

        dtpEndDate.Text = ""
        dtpStartDate.Text = ""

        cboPartNumber.Focus()
    End Sub

    Private Sub cmdSOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSOForm.Click
        Dim RowSONumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowIndex As Integer = Me.dgvFoxListing.CurrentCell.RowIndex

        RowSONumber = Me.dgvFoxListing.Rows(RowIndex).Cells("OrderReferenceNumberColumn").Value
        RowDivision = Me.dgvFoxListing.Rows(RowIndex).Cells("DivisionIDColumn").Value

        GlobalSONumber = RowSONumber
        GlobalDivisionCode = RowDivision

        Dim NewSOForm As New SOForm
        NewSOForm.Show()
    End Sub

    Private Sub cmdOpenFOXForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenFOXForm.Click
        Dim RowFOXNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowIndex As Integer = Me.dgvFoxListing.CurrentCell.RowIndex

        RowFOXNumber = Me.dgvFoxListing.Rows(RowIndex).Cells("FOXNumberColumn").Value
        RowDivision = Me.dgvFoxListing.Rows(RowIndex).Cells("DivisionIDColumn").Value

        GlobalFOXNumber = RowFOXNumber
        GlobalDivisionCode = RowDivision

        Dim NewFOXMenu As New FOXMenu
        NewFOXMenu.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintFOXListingFiltered As New PrintFOXListingFiltered
            Dim result = NewPrintFOXListingFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub dgvFoxListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFoxListing.CellDoubleClick
        If dgvFoxListing.RowCount > 0 Then
            Dim RowFOXNumber As Integer = 0
            Dim RowIndex As Integer = Me.dgvFoxListing.CurrentCell.RowIndex

            RowFOXNumber = Me.dgvFoxListing.Rows(RowIndex).Cells("FOXNumberColumn").Value

            GlobalFOXNumber = RowFOXNumber

            Using NewPrintFOX As New PrintFOX
                Dim result = NewPrintFOX.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvFoxListing_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFoxListing.CellValueChanged
        'Load Security
        Select Case EmployeeSecurityCode
            Case 1001, 1002, 1003, 1004, 1007, 1008, 1009, 1010
                'Continue - allowed to edit fields
            Case Else
                'Exit - not allowed to edit fields
                Exit Sub
        End Select

        Dim RowFOXNumber As Integer = 0
        Dim RowCustomer As String = ""
        Dim RowBlueprintNumber As String = ""
        Dim RowBPRevision As String = ""
        Dim RowRMWeight As Double = 0
        Dim RowScrapWeight As Double = 0
        Dim RowFinishWeight As Double = 0
        Dim RowFluxNumber As String = ""
        Dim RowComments As String = ""
        Dim RowCertType As String = ""
        Dim RowBoxType As String = ""
        Dim RowProductionQuantity As Double = 0
        Dim RowOrderNumber As Integer = 0
        Dim RowQuoteNumber As String = ""
        Dim RowQuotePrice As Double = 0
        Dim RowProductionNote As String = ""

        If dgvFoxListing.RowCount > 0 Then

            Dim RowIndex As Integer = Me.dgvFoxListing.CurrentCell.RowIndex

            Try
                RowFOXNumber = Me.dgvFoxListing.Rows(RowIndex).Cells("FOXNumberColumn").Value
            Catch ex As Exception
                RowFOXNumber = 0
            End Try
            Try
                RowCustomer = Me.dgvFoxListing.Rows(RowIndex).Cells("CustomerIDColumn").Value
            Catch ex As Exception
                RowCustomer = ""
            End Try
            Try
                RowBlueprintNumber = Me.dgvFoxListing.Rows(RowIndex).Cells("BlueprintNumberColumn").Value
            Catch ex As Exception
                RowBlueprintNumber = ""
            End Try
            Try
                RowBPRevision = Me.dgvFoxListing.Rows(RowIndex).Cells("BlueprintRevisionColumn").Value
            Catch ex As Exception
                RowBPRevision = ""
            End Try
            Try
                RowRMWeight = Me.dgvFoxListing.Rows(RowIndex).Cells("RawMaterialWeightColumn").Value
            Catch ex As Exception
                RowRMWeight = 0
            End Try
            Try
                RowScrapWeight = Me.dgvFoxListing.Rows(RowIndex).Cells("ScrapWeightColumn").Value
            Catch ex As Exception
                RowScrapWeight = 0
            End Try
            Try
                RowFinishWeight = Me.dgvFoxListing.Rows(RowIndex).Cells("FinishedWeightColumn").Value
            Catch ex As Exception
                RowFinishWeight = 0
            End Try
            Try
                RowFluxNumber = Me.dgvFoxListing.Rows(RowIndex).Cells("FluxLoadNumberColumn").Value
            Catch ex As Exception
                RowFluxNumber = ""
            End Try
            Try
                RowComments = Me.dgvFoxListing.Rows(RowIndex).Cells("CommentsColumn").Value
            Catch ex As Exception
                RowComments = ""
            End Try
            Try
                RowCertType = Me.dgvFoxListing.Rows(RowIndex).Cells("CertificationTypeColumn").Value
            Catch ex As Exception
                RowCertType = ""
            End Try
            Try
                RowBoxType = Me.dgvFoxListing.Rows(RowIndex).Cells("BoxTypeColumn").Value
            Catch ex As Exception
                RowBoxType = ""
            End Try
            Try
                RowProductionQuantity = Me.dgvFoxListing.Rows(RowIndex).Cells("FOXNumberColumn").Value
            Catch ex As Exception
                RowProductionQuantity = 0
            End Try
            Try
                RowOrderNumber = Me.dgvFoxListing.Rows(RowIndex).Cells("OrderReferenceNumberColumn").Value
            Catch ex As Exception
                RowOrderNumber = 0
            End Try
            Try
                RowQuoteNumber = Me.dgvFoxListing.Rows(RowIndex).Cells("QuoteNumberColumn").Value
            Catch ex As Exception
                RowQuoteNumber = ""
            End Try
            Try
                RowQuotePrice = Me.dgvFoxListing.Rows(RowIndex).Cells("QuotePriceColumn").Value
            Catch ex As Exception
                RowQuotePrice = 0
            End Try
            Try
                RowProductionNote = Me.dgvFoxListing.Rows(RowIndex).Cells("ProductionNoteColumn").Value
            Catch ex As Exception
                RowProductionNote = ""
            End Try

            Try
                'Update FOX Table
                cmd = New SqlCommand("UPDATE FOXTable SET BlueprintNumber = @BlueprintNumber, RawMaterialWeight = @RawMaterialWeight, FinishedWeight = @FinishedWeight, ScrapWeight = @ScrapWeight, FluxLoadNumber = @FluxLoadNumber, Comments = @Comments, CertificationType = @CertificationType, BoxType = @BoxType, CustomerID = @CustomerID, ProductionQuantity = @ProductionQuantity, OrderReferenceNumber = @OrderReferenceNumber, BlueprintRevision = @BlueprintRevision, QuoteNumber = @QuoteNumber, QuotePrice = @QuotePrice, ProductionNote = @ProductionNote WHERE FOXNumber = @FOXNumber", con)

                With cmd.Parameters
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                    .Add("@BlueprintNumber", SqlDbType.VarChar).Value = RowBlueprintNumber
                    .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = RowRMWeight
                    .Add("@FinishedWeight", SqlDbType.VarChar).Value = RowFinishWeight
                    .Add("@ScrapWeight", SqlDbType.VarChar).Value = RowScrapWeight
                    .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = RowFluxNumber
                    .Add("@Comments", SqlDbType.VarChar).Value = RowComments
                    .Add("@CertificationType", SqlDbType.VarChar).Value = RowCertType
                    .Add("@BoxType", SqlDbType.VarChar).Value = RowBoxType
                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                    .Add("@ProductionQuantity", SqlDbType.VarChar).Value = RowProductionQuantity
                    .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = RowOrderNumber
                    .Add("@BlueprintRevision", SqlDbType.VarChar).Value = RowBPRevision
                    .Add("@QuoteNumber", SqlDbType.VarChar).Value = RowQuoteNumber
                    .Add("@QuotePrice", SqlDbType.VarChar).Value = RowQuotePrice
                    .Add("@ProductionNote", SqlDbType.VarChar).Value = RowProductionNote
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartDescription()
        LoadPartNumber()
    End Sub

    Private Sub cboSteelCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelCarbon.SelectedIndexChanged
        LoadRMID()
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        LoadRMID()
    End Sub
End Class