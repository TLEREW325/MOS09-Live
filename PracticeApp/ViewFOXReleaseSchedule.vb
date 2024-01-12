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
Public Class ViewFOXReleaseSchedule
    Inherits System.Windows.Forms.Form

    Dim PartDescription, PartNumber, CustomerID, CustomerName As String
    Dim PartFilter, FOXFilter, CustomerFilter, BlueprintFilter, DateFilter, SOFilter, ShipmentFilter, ReleaseDateFilter, PromiseDateFilter As String
    Dim SONumber, ShipmentNumber, FOXNumber As Integer
    Dim strSONumber, strShipmentNumber, strFOXNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim CalculateOnTime As Boolean = False

    Private Sub ViewFOXReleaseSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
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
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadFOXNumber()
        LoadPartNumber()
        LoadCustomerID()
        LoadCustomerName()
        LoadPartDescription()
        LoadShipmentNumber()
        LoadSONumber()
        LoadBlueprintNumber()

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvFOXReleaseSchedule.DataSource = Nothing
    End Sub

    Public Sub ShowScheduleByFilters()
        Dim statusFilter As String = ""
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboBlueprintNumber.Text <> "" Then
            BlueprintFilter = " AND BlueprintNumber = '" + cboBlueprintNumber.Text + "'"
        Else
            BlueprintFilter = ""
        End If
        If cboStatus.Text <> "" Then
            statusFilter = " AND Status = '" + cboStatus.Text + "'"
        Else
            statusFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND OrderReferenceNumber = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboFOXNumber.Text <> "" Then
            FOXNumber = Val(cboFOXNumber.Text)
            strFOXNumber = CStr(FOXNumber)
            FOXFilter = " AND FOXNumber = '" + strFOXNumber + "'"
        Else
            FOXFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            If chkPromiseDate.Checked = True And chkReleaseDate.Checked = False Then
                DateFilter = " AND PromiseDate BETWEEN @BeginDate AND @EndDate"
            ElseIf chkPromiseDate.Checked = False And chkReleaseDate.Checked = True Then
                DateFilter = " AND ReleaseDate BETWEEN @BeginDate AND @EndDate"
            Else
                DateFilter = " AND (ReleaseDate BETWEEN @BeginDate AND @EndDate OR PromiseDate BETWEEN @BeginDate AND @EndDate)"
            End If
        End If

        cmd = New SqlCommand("SELECT * FROM FOXReleaseScheduleQuery WHERE DivisionID = @DivisionID AND FOXStatus <> @FOXStatus" + PartFilter + CustomerFilter + BlueprintFilter + FOXFilter + SOFilter + ShipmentFilter + DateFilter + statusFilter + " ORDER BY FOXNumber, ReleaseDate ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@FOXStatus", SqlDbType.VarChar).Value = "INACTIVE"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXReleaseScheduleQuery")
        dgvFOXReleaseSchedule.DataSource = ds.Tables("FOXReleaseScheduleQuery")
        con.Close()

        'Change color of lines
        Dim RowStatus As String = ""
        Dim TotalReleases As Integer = 0
        Dim OnTimeReleases As Integer = 0

        For i As Integer = 0 To dgvFOXReleaseSchedule.Rows.Count - 1
            Try
                RowStatus = Me.dgvFOXReleaseSchedule.Rows(i).Cells("StatusColumn").Value
            Catch ex As System.Exception
                RowStatus = ""
            End Try

            If RowStatus = "SHIPPED" Then
                Me.dgvFOXReleaseSchedule.Rows(i).Cells(1).Style.BackColor = Color.LightSteelBlue
            ElseIf RowStatus = "PENDING" Then
                Me.dgvFOXReleaseSchedule.Rows(i).Cells(1).Style.BackColor = Color.LightSalmon
            Else
                Me.dgvFOXReleaseSchedule.Rows(i).Cells(1).Style.BackColor = Color.LightYellow
            End If

            If CalculateOnTime Then
                If Not dgvFOXReleaseSchedule.Rows(i).Cells("StatusColumn").Value.ToString.Equals("OPEN") Then
                    If DateDiff(DateInterval.Day, dgvFOXReleaseSchedule.Rows(i).Cells("PromiseDateColumn").Value, dgvFOXReleaseSchedule.Rows(i).Cells("ShipDateColumn").Value) <= 0 Then
                        OnTimeReleases += 1
                    End If
                    TotalReleases += 1
                Else
                    If DateDiff(DateInterval.Day, dgvFOXReleaseSchedule.Rows(i).Cells("PromiseDateColumn").Value, Now.Date) < 0 Then
                        OnTimeReleases += 1
                    End If
                    TotalReleases += 1
                End If
            End If
        Next

        If CalculateOnTime Then
            lblTotalOnTime.Text = OnTimeReleases.ToString()
            lblOnTimePercent.Text = Math.Round((Convert.ToDouble(OnTimeReleases) / TotalReleases * 100), 2).ToString() + "%"
        End If
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "FOXTable")
        cboFOXNumber.DataSource = ds1.Tables("FOXTable")
        con.Close()
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartNumber.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ShortDescription ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartDescription.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerID ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerID.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerName ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CustomerList")
        cboCustomerName.DataSource = ds5.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadSONumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds6.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds7.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBlueprintNumber()
        cmd = New SqlCommand("SELECT DISTINCT BlueprintNumber FROM FOXTable WHERE DivisionID = @DivisionID ORDER BY BlueprintNumber ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "FOXTable")
        cboBlueprintNumber.DataSource = ds8.Tables("FOXTable")
        con.Close()
        cboBlueprintNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadDescriptionFromPart()
        Dim PartDescriptionString As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescriptionCommand As New SqlCommand(PartDescriptionString, con)
        PartDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            PartDescription = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription
    End Sub

    Public Sub LoadPartFromDescription()
        Dim PartNumberString As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumberCommand As New SqlCommand(PartNumberString, con)
        PartNumberCommand.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber = CStr(PartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            PartNumber = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber
    End Sub

    Public Sub LoadCustomerIDFromName()
        Dim CustomerIDString As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerIDCommand As New SqlCommand(CustomerIDString, con)
        CustomerIDCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID = CStr(CustomerIDCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerID = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID
    End Sub

    Public Sub LoadCustomerNameFromID()
        'Get Sales Order Data
        Dim CustomerNameString As String = "SELECT ItemID FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerNameCommand As New SqlCommand(CustomerNameString, con)
        CustomerNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName = CStr(CustomerNameCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerName = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameFromID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDFromName()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionFromPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartFromDescription()
    End Sub

    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        If chkDateRange.Checked = False Then
            chkPromiseDate.Checked = False
            chkReleaseDate.Checked = False
        End If
    End Sub

    Private Sub chkReleaseDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReleaseDate.CheckedChanged
        If chkReleaseDate.Checked = True Then
            chkDateRange.Checked = True
        End If
    End Sub

    Private Sub chkPromiseDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPromiseDate.CheckedChanged
        If chkPromiseDate.Checked = True Then
            chkDateRange.Checked = True
        End If
    End Sub

    Public Sub ClearData()
        cboFOXNumber.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1
        cboBlueprintNumber.SelectedIndex = -1
        cboStatus.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboStatus.Text) Then
            cboStatus.Text = ""
        End If

        chkDateRange.Checked = False
        chkPromiseDate.Checked = False
        chkReleaseDate.Checked = False

        dtpEndDate.Text = ""
        dtpBeginDate.Text = ""

        cboFOXNumber.Focus()

        If CalculateOnTime Then
            lblOnTimePercent.Text = ""
            lblTotalOnTime.Text = ""
        End If
    End Sub

    Public Sub ClearVariables()
        PartDescription = ""
        PartNumber = ""
        CustomerID = ""
        CustomerName = ""
        PartFilter = ""
        FOXFilter = ""
        CustomerFilter = ""
        BlueprintFilter = ""
        DateFilter = ""
        SOFilter = ""
        ShipmentFilter = ""
        ReleaseDateFilter = ""
        PromiseDateFilter = ""
        SONumber = 0
        ShipmentNumber = 0
        FOXNumber = 0
        strSONumber = ""
        strShipmentNumber = ""
        strFOXNumber = ""
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowScheduleByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdOpenFOXForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenFOXForm.Click
        Dim RowFOXNumber As Integer

        Dim RowIndex As Integer = Me.dgvFOXReleaseSchedule.CurrentCell.RowIndex
        If Me.dgvFOXReleaseSchedule.RowCount > 0 Then
            RowFOXNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("FOXNumberColumn").Value
            GlobalFOXNumber = RowFOXNumber
        Else
            'Do nothing - no FOX Selected
        End If

        Dim NewFOXMenu As New FOXMenu
        NewFOXMenu.Show()
    End Sub

    Private Sub dgvFOXReleaseSchedule_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFOXReleaseSchedule.CellDoubleClick
        Dim RowFOXNumber As Integer

        Dim RowIndex As Integer = Me.dgvFOXReleaseSchedule.CurrentCell.RowIndex

        RowFOXNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("FOXNumberColumn").Value

        GlobalFOXNumber = RowFOXNumber
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintFOXReleaseSchedule As New PrintFOXReleaseSchedule
            Dim result = NewPrintFOXReleaseSchedule.ShowDialog()
        End Using
    End Sub

    Private Sub dgvFOXReleaseSchedule_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFOXReleaseSchedule.CellValueChanged
        Dim RowFOXNumber, RowReleaseLineNumber As Integer
        Dim RowReleaseQuantity As Double
        Dim RowReleaseDate, RowPromiseDate As String

        If Me.dgvFOXReleaseSchedule.RowCount > 0 Then
            Try
                Dim RowIndex As Integer = Me.dgvFOXReleaseSchedule.CurrentCell.RowIndex

                RowFOXNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("FOXNumberColumn").Value
                RowReleaseLineNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseLineNumberColumn").Value
                RowReleaseDate = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseDateColumn").Value
                RowPromiseDate = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("PromiseDateColumn").Value
                RowReleaseQuantity = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseQuantityColumn").Value

                'UPDATE Releases
                cmd = New SqlCommand("UPDATE FOXReleaseSchedule SET ReleaseDate = @ReleaseDate, PromiseDate = @PromiseDate, ReleaseQuantity = @ReleaseQuantity WHERE FOXNumber = @FOXNumber AND ReleaseLineNumber = @ReleaseLineNumber", con)

                With cmd.Parameters
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                    .Add("@ReleaseLineNumber", SqlDbType.VarChar).Value = RowReleaseLineNumber
                    .Add("@ReleaseDate", SqlDbType.VarChar).Value = RowReleaseDate
                    .Add("@PromiseDate", SqlDbType.VarChar).Value = RowPromiseDate
                    .Add("@ReleaseQuantity", SqlDbType.VarChar).Value = RowReleaseQuantity
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'No update
            End Try
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintFOXReleaseListing As New PrintFOXReleaseListing
            Dim Result = NewPrintFOXReleaseListing.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboStatus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboStatus.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim dt As New Data.DataTable("FOXReleaseScheduleQuery")
        For i As Integer = 0 To dgvFOXReleaseSchedule.Columns.Count - 1
            dt.Columns.Add(dgvFOXReleaseSchedule.Columns(i).DataPropertyName, dgvFOXReleaseSchedule.Columns(i).ValueType)
        Next
        Dim test As Integer = dt.Columns.Count
        Dim test2 As Integer = dgvFOXReleaseSchedule.Columns.Count
        For Each rw As DataGridViewRow In dgvFOXReleaseSchedule.Rows
            dt.Rows.Add(GetArray(rw))
        Next
        Using printFOXReleaseCompressed As New PrintFOXReleaseScheduleCompressed(dt)
            printFOXReleaseCompressed.ShowDialog()
        End Using
    End Sub

    Private Function GetArray(ByVal rw As DataGridViewRow) As Object()
        Dim objArray(dgvFOXReleaseSchedule.Columns.Count - 1) As Object
        For i As Integer = 0 To dgvFOXReleaseSchedule.Columns.Count - 1
            objArray(i) = rw.Cells(i).Value
        Next
        Return objArray
    End Function

    Private Sub dgvFOXReleaseSchedule_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvFOXReleaseSchedule.Sorted
        Dim RowStatus As String = ""
        For i As Integer = 0 To dgvFOXReleaseSchedule.Rows.Count - 1
            Try
                RowStatus = Me.dgvFOXReleaseSchedule.Rows(i).Cells("StatusColumn").Value
            Catch ex As System.Exception
                RowStatus = ""
            End Try

            If RowStatus = "SHIPPED" Then
                Me.dgvFOXReleaseSchedule.Rows(i).Cells(1).Style.BackColor = Color.LightSteelBlue
            ElseIf RowStatus = "PENDING" Then
                Me.dgvFOXReleaseSchedule.Rows(i).Cells(1).Style.BackColor = Color.LightSalmon
            Else
                Me.dgvFOXReleaseSchedule.Rows(i).Cells(1).Style.BackColor = Color.LightYellow
            End If
        Next
    End Sub
End Class