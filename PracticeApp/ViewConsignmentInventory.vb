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
Public Class ViewConsignmentInventory
    Inherits System.Windows.Forms.Form

    Dim PartFilter, QuantityFilter, WarehouseFilter, AllFilter As String

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Public Sub ClearDataInDatagrid()
        dgvConsignmentInventory.DataSource = Nothing
    End Sub

    Public Sub ClearDataInDatagrid2()
        dgvFIFOValue.DataSource = Nothing
    End Sub

    Public Sub ClearDataInDatagrid3()
        dgvFIFOSteelValue.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        Dim WarehouseName As String = ""
        Dim WarehouseID As String = ""
        Dim ItemClassFilter As String = ""

        WarehouseName = cboWarehouse.Text

        Select Case WarehouseName
            Case "Bessemer"
                WarehouseID = "BCW"
            Case "Downey"
                WarehouseID = "DCW"
            Case "Hayward"
                WarehouseID = "HCW"
            Case "Lewisville"
                WarehouseID = "LCW"
            Case "Lyndhurst"
                WarehouseID = "YCW"
            Case "Phoenix"
                WarehouseID = "PCW"
            Case "Seattle"
                WarehouseID = "SCW"
            Case "Renton"
                WarehouseID = "RCW"
            Case "Lake Stevens"
                WarehouseID = "LSCW"
            Case "SRL"
                WarehouseID = "SRL"
            Case Else
                WarehouseID = "TWD"
        End Select

        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If chkQOH.Checked = True Then
            QuantityFilter = " AND QuantityOnHand <> '0'"
        Else
            QuantityFilter = ""
        End If
        If cboWarehouse.Text <> "" Then
            WarehouseFilter = " AND DivisionID = '" + WarehouseID + "'"
        Else
            WarehouseFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If chkAllWarehouses.Checked = True Then
            AllFilter = " AND DivisionID <> 'TWD'"
        Else
            AllFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM ConsignmentInventory WHERE DivisionID <> @DivisionID" + PartFilter + QuantityFilter + WarehouseFilter + ItemClassFilter + AllFilter + " ORDER BY DivisionID, PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ZZZ"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ConsignmentInventory")
        dgvConsignmentInventory.DataSource = ds.Tables("ConsignmentInventory")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadItemClass()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass WHERE ItemClassID LIKE @ItemClassID", con)
        cmd.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = "TW%"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboItemClass.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboItemClass.SelectedIndex = -1
    End Sub

    Public Sub LoadFOB()
        cmd = New SqlCommand("SELECT FOBName FROM FOBTable WHERE DivisionID = @DivisionID AND Status = @Status ORDER BY FOBID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "FOBTable")
        cboWarehouse.DataSource = ds4.Tables("FOBTable")
        con.Close()
        cboWarehouse.SelectedIndex = -1
    End Sub

    Public Sub LoadFOBCanadian()
        cmd = New SqlCommand("SELECT FOBName FROM FOBTable WHERE DivisionID = @DivisionID AND Status = @Status AND Type = @Type ORDER BY FOBID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
        cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "CANADIAN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "FOBTable")
        cboWarehouse.DataSource = ds4.Tables("FOBTable")
        con.Close()
        cboWarehouse.SelectedIndex = -1
    End Sub

    Public Sub LoadFOB2()
        cmd = New SqlCommand("SELECT FOBName FROM FOBTable WHERE DivisionID = @DivisionID AND Status = @Status ORDER BY FOBID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "FOBTable")
        cboValueDivision.DataSource = ds4.Tables("FOBTable")
        con.Close()
        cboValueDivision.SelectedIndex = -1
    End Sub

    Public Sub LoadFOBCanadian2()
        cmd = New SqlCommand("SELECT FOBName FROM FOBTable WHERE DivisionID = @DivisionID AND Status = @Status AND Type = @Type ORDER BY FOBID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
        cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "CANADIAN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "FOBTable")
        cboValueDivision.DataSource = ds4.Tables("FOBTable")
        con.Close()
        cboValueDivision.SelectedIndex = -1
    End Sub

    Public Sub ShowSteelValue()
        Dim WarehouseName As String = ""
        Dim WarehouseID As String = ""

        WarehouseName = cboValueDivision.Text

        Select Case WarehouseName
            Case "Bessemer"
                WarehouseID = "BCW"
            Case "Downey"
                WarehouseID = "DCW"
            Case "Hayward"
                WarehouseID = "HCW"
            Case "Lewisville"
                WarehouseID = "LCW"
            Case "Lyndhurst"
                WarehouseID = "YCW"
            Case "Phoenix"
                WarehouseID = "PCW"
            Case "Seattle"
                WarehouseID = "SCW"
            Case "Renton"
                WarehouseID = "RCW"
            Case "Lake Stevens"
                WarehouseID = "LSCW"
            Case "SRL"
                WarehouseID = "SRL"
            Case Else
                WarehouseID = "TWD"
        End Select

        If chkValueAll.Checked = True Then
            WarehouseName = "All"
        End If

        If WarehouseName = "All" Then
            cmd = New SqlCommand("SELECT * FROM InventorySteelValuation WHERE DivisionID LIKE @DivisionID OR DivisionID = 'SRL' ORDER BY DivisionID, PartNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "%CW"
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "InventorySteelValuation")
            dgvFIFOSteelValue.DataSource = ds6.Tables("InventorySteelValuation")
            con.Close()
        Else
            cmd = New SqlCommand("SELECT * FROM ConsignmentInventory WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "InventorySteelValuation")
            dgvFIFOSteelValue.DataSource = ds6.Tables("InventorySteelValuation")
            con.Close()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
        ClearDataInDatagrid2()

        Me.dgvConsignmentInventory.Visible = True
        Me.dgvFIFOSteelValue.Visible = False
        Me.dgvFIFOValue.Visible = False

        Me.dgvFIFOValue.DataSource = Nothing
        Me.dgvConsignmentInventory.DataSource = Nothing
        Me.dgvFIFOSteelValue.DataSource = Nothing
    End Sub

    Public Sub ClearData()
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""
        cboWarehouse.Text = ""
        cboItemClass.Text = ""

        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboWarehouse.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1

        chkQOH.Checked = False
        chkAllWarehouses.Checked = False

        cboPartNumber.Focus()
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

    Private Sub ViewConsignmentInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCurrentDivision()

        usefulFunctions.LoadSecurity(Me)
        cboDivisionID.Text = EmployeeCompanyCode
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()

        Me.dgvConsignmentInventory.Visible = True
        Me.dgvFIFOValue.Visible = False
        Me.dgvFIFOSteelValue.Visible = False
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

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintConsignmentInventory As New PrintConsignmentInventory
            Dim result = NewPrintConsignmentInventory.ShowDialog()
        End Using
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "TFF" Then
            LoadFOBCanadian()
            LoadFOBCanadian2()
        Else
            LoadFOB()
            LoadFOB2()
        End If

        LoadPartNumber()
        LoadPartDescription()
        LoadItemClass()

        ClearData()
        ClearDataInDatagrid()
        ClearDataInDatagrid2()
        ClearDataInDatagrid3()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub chkAllWarehouses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllWarehouses.CheckedChanged
        If chkAllWarehouses.Checked = True Then
            cboWarehouse.SelectedIndex = -1
            cboWarehouse.Text = ""
        End If
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdApplyFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplyFilter.Click
        ClearDataInDatagrid()
        ClearDataInDatagrid2()

        Me.dgvConsignmentInventory.Visible = True
        Me.dgvFIFOValue.Visible = False
        Me.dgvFIFOSteelValue.Visible = False

        Dim WarehouseName As String = ""
        Dim WarehouseID As String = ""

        WarehouseName = cboValueDivision.Text

        Select Case WarehouseName
            Case "Bessemer"
                WarehouseID = "BCW"
            Case "Downey"
                WarehouseID = "DCW"
            Case "Hayward"
                WarehouseID = "HCW"
            Case "Lewisville"
                WarehouseID = "LCW"
            Case "Lyndhurst"
                WarehouseID = "YCW"
            Case "Phoenix"
                WarehouseID = "PCW"
            Case "Seattle"
                WarehouseID = "SCW"
            Case "Renton"
                WarehouseID = "RCW"
            Case "Lake Stevens"
                WarehouseID = "LSCW"
            Case "SRL"
                WarehouseID = "SRL"
            Case Else
                WarehouseID = "TWD"
        End Select

        If chkValueAll.Checked = True Then
            WarehouseName = "All"
        End If

        If WarehouseName = "All" Then
            cmd = New SqlCommand("SELECT * FROM ConsignmentInventory WHERE DivisionID LIKE @DivisionID OR DivisionID = 'SRL' ORDER BY DivisionID, PartNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "%CW"
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ConsignmentInventory")
            dgvConsignmentInventory.DataSource = ds.Tables("ConsignmentInventory")
            con.Close()
        Else
            cmd = New SqlCommand("SELECT * FROM ConsignmentInventory WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ConsignmentInventory")
            dgvConsignmentInventory.DataSource = ds.Tables("ConsignmentInventory")
            con.Close()
        End If
    End Sub

    Private Sub cmdValueInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValueInventory.Click
        Dim WarehouseName As String = ""
        Dim WarehouseID As String = ""
        Dim PPL As String = ""
        Dim GoToFIFOCosting As String = "YES"
        Dim SumSerialCost As Double = 0
        Dim SerialUnitCost As Double = 0
        Dim CountItems As Integer = 0
        Dim SerializedStatus As String = ""
        Dim GetMaxTransactionNumber As Integer = 0
        Dim GetUpperLimit, QuantityRemaining, UpperLimit, LowerLimit, NextUpperLimit, NextLowerLimit As Double
        Dim LastTransactionCost As Double = 0
        Dim GLAccount As String = ""

        WarehouseName = cboValueDivision.Text

        Select Case WarehouseName
            Case "Bessemer"
                WarehouseID = "BCW"
            Case "Downey"
                WarehouseID = "DCW"
            Case "Hayward"
                WarehouseID = "HCW"
            Case "Lewisville"
                WarehouseID = "LCW"
            Case "Lyndhurst"
                WarehouseID = "YCW"
            Case "Phoenix"
                WarehouseID = "PCW"
            Case "Seattle"
                WarehouseID = "SCW"
            Case "Renton"
                WarehouseID = "RCW"
            Case "Lake Stevens"
                WarehouseID = "LSCW"
            Case "SRL"
                WarehouseID = "SRL"
            Case Else
                WarehouseID = "TWD"
        End Select

        If chkValueAll.Checked = True Then
            WarehouseName = "All"
        End If

        If WarehouseName = "All" Then
            'Delete any existing valuation
            cmd = New SqlCommand("DELETE FROM InventoryFIFOValuation WHERE DivisionID LIKE @DivisionID OR DivisionID = 'SRL'", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = "%CW"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            'Delete any existing valuation
            cmd = New SqlCommand("DELETE FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
        '***************************************************************************************************************
        'For each record in the consignment table, get QOH as of the Value Date then get FIFO Cost and write it to the temp table
        Dim PartNumber, PartDescription, ConsignmentDivision As String
        Dim SumQuantityReturned, SumQuantityShipped, SumQuantityAdjusted, SumQuantityBilled As Double
        Dim QuantityOnHand, FIFOCost, FIFOExtendedAmount As Double
        Dim MaxTransactionDate As Integer = 0

        'Determine FIFO Cost on Part Number to remove from Inventory
        Dim TotalQuantityShipped As Double = 0
        Dim WasTQSZero As String = ""
        Dim NoCostTierFound As String = "FALSE"

        FIFOCost = 0
        FIFOExtendedAmount = 0

        For Each row As DataGridViewRow In dgvConsignmentInventory.Rows
            Try
                PartNumber = row.Cells("PartNumberColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = row.Cells("ShortDescriptionColumn").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                ConsignmentDivision = row.Cells("DivisionIDColumn").Value
            Catch ex As Exception
                ConsignmentDivision = ""
            End Try
            '*******************************************************
            'Get PPL of Part to see if it is an assembly
            Dim PPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PPLCommand As New SqlCommand(PPLStatement, con)
            PPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
            PPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PPL = CStr(PPLCommand.ExecuteScalar)
            Catch ex As Exception
                PPL = ""
            End Try
            con.Close()
            '********************************************************
            'If assembly, see if it is serialized
            If PPL = "ASSEMBLY" Then
                Dim SerializedStatusStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                Dim SerializedStatusCommand As New SqlCommand(SerializedStatusStatement, con)
                SerializedStatusCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                SerializedStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SerializedStatus = CStr(SerializedStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    SerializedStatus = "NO"
                End Try
                con.Close()
            Else
                SerializedStatus = "NO"
            End If
            '*********************************************************
            Select Case ConsignmentDivision
                Case "BCW"
                    WarehouseID = "BCW"
                    GLAccount = "12610"
                Case "DCW"
                    WarehouseID = "DCW"
                    GLAccount = "12630"
                Case "HCW"
                    WarehouseID = "HCW"
                    GLAccount = "12620"
                Case "LCW"
                    WarehouseID = "LCW"
                    GLAccount = "12650"
                Case "YCW"
                    WarehouseID = "YCW"
                    GLAccount = "12600"
                Case "PCW"
                    WarehouseID = "PCW"
                    GLAccount = "12660"
                Case "SCW"
                    WarehouseID = "SCW"
                    GLAccount = "12640"
                Case "RCW"
                    WarehouseID = "RCW"
                    GLAccount = "12680"
                Case "LSCW"
                    WarehouseID = "LSCW"
                    GLAccount = "12690"
                Case "SRL"
                    WarehouseID = "SRL"
                    GLAccount = "12670"
                Case Else
                    WarehouseID = "TWD"
                    GLAccount = "12100"
            End Select

            'Get QOH as of date
            Dim QuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ConsignmentShippingTable WHERE PartNumber = @PartNumber AND CustomerClass = @CustomerClass AND ShipDate <= @ValueDate"
            Dim QuantityShippedCommand As New SqlCommand(QuantityShippedStatement, con)
            QuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            QuantityShippedCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = ConsignmentDivision
            QuantityShippedCommand.Parameters.Add("@ValueDate", SqlDbType.VarChar).Value = dtpValueDate.Text

            Dim QuantityBilledStatement As String = "SELECT SUM(QuantityBilled) FROM ConsignmentBillingTable WHERE PartNumber = @PartNumber AND CustomerClass = @CustomerClass AND BillDate <= @ValueDate"
            Dim QuantityBilledCommand As New SqlCommand(QuantityBilledStatement, con)
            QuantityBilledCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            QuantityBilledCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = ConsignmentDivision
            QuantityBilledCommand.Parameters.Add("@ValueDate", SqlDbType.VarChar).Value = dtpValueDate.Text

            Dim QuantityAdjustedStatement As String = "SELECT SUM(Quantity) FROM ConsignmentAdjustmentTable WHERE PartNumber = @PartNumber AND CustomerClass = @CustomerClass AND AdjustmentDate <= @ValueDate"
            Dim QuantityAdjustedCommand As New SqlCommand(QuantityAdjustedStatement, con)
            QuantityAdjustedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            QuantityAdjustedCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = ConsignmentDivision
            QuantityAdjustedCommand.Parameters.Add("@ValueDate", SqlDbType.VarChar).Value = dtpValueDate.Text

            Dim QuantityReturnedStatement As String = "SELECT SUM(QuantityReturned) FROM ConsignmentReturnTable WHERE PartNumber = @PartNumber AND CustomerClass = @CustomerClass AND ReturnDate <= @ValueDate"
            Dim QuantityReturnedCommand As New SqlCommand(QuantityReturnedStatement, con)
            QuantityReturnedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            QuantityReturnedCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = ConsignmentDivision
            QuantityReturnedCommand.Parameters.Add("@ValueDate", SqlDbType.VarChar).Value = dtpValueDate.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumQuantityShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
            Catch ex As Exception
                SumQuantityShipped = 0
            End Try
            Try
                SumQuantityBilled = CDbl(QuantityBilledCommand.ExecuteScalar)
            Catch ex As Exception
                SumQuantityBilled = 0
            End Try
            Try
                SumQuantityAdjusted = CDbl(QuantityAdjustedCommand.ExecuteScalar)
            Catch ex As Exception
                SumQuantityAdjusted = 0
            End Try
            Try
                SumQuantityReturned = CDbl(QuantityReturnedCommand.ExecuteScalar)
            Catch ex As Exception
                SumQuantityReturned = 0
            End Try
            con.Close()

            QuantityOnHand = (SumQuantityShipped + SumQuantityAdjusted + SumQuantityReturned) - SumQuantityBilled

            If QuantityOnHand = 0 Then
                'Skip this part
                GoToFIFOCosting = "YES"
            Else
                If SerializedStatus = "YES" Then
                    'Count and compare quantity open in assembly serial log
                    Dim CountItemsStatement As String = "SELECT COUNT(AssemblyPartNumber) FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status"
                    Dim CountItemsCommand As New SqlCommand(CountItemsStatement, con)
                    CountItemsCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                    CountItemsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    CountItemsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountItems = CInt(CountItemsCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountItems = 0
                    End Try
                    con.Close()
                End If
                '*********************************************************************************************************************************************
                If SerializedStatus = "YES" And CountItems = QuantityOnHand Then
                    'Skip FIFO for this part and used serial cost
                    Dim SumSerialCostStatement As String = "SELECT SUM(TotalCost) FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status"
                    Dim SumSerialCostCommand As New SqlCommand(SumSerialCostStatement, con)
                    SumSerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                    SumSerialCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    SumSerialCostCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SumSerialCost = CDbl(SumSerialCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        SumSerialCost = 0
                    End Try
                    con.Close()

                    SerialUnitCost = SumSerialCost / QuantityOnHand

                    FIFOCost = SerialUnitCost
                    FIFOExtendedAmount = SumSerialCost

                    GoToFIFOCosting = "NO"
                ElseIf SerializedStatus = "YES" And CountItems <> QuantityOnHand Then
                    'Write to error log
                    'If Insert fails, write error message to database
                    ErrorDate = Today()
                    ErrorComment = PartNumber + " - QOH did not match Serial Qty for consignment " + ConsignmentDivision
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Quantity = " + CStr(QuantityOnHand) + " , Serial Quantity = " + CStr(CountItems)
                    ErrorReferenceNumber = "Valuation Date -- " + dtpValueDate.Text.ToString
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    GoToFIFOCosting = "YES"
                Else
                    GoToFIFOCosting = "YES"
                End If
            End If
            '*********************************************************************************************************************************************
            If QuantityOnHand = 0 And GoToFIFOCosting = "YES" Then
                FIFOCost = 0
                FIFOExtendedAmount = 0
            ElseIf QuantityOnHand <> 0 And GoToFIFOCosting = "YES" Then
                'Get FIFO Cost as of Date
                '******************************************************************************************************************************************
                'Determine Total Quantity Shipped
                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityBilled) FROM ConsignmentBillingTable WHERE PartNumber = @PartNumber AND CustomerClass = @CustomerClass AND BillDate <= @BillDate"
                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                TotalQuantityShippedCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = ConsignmentDivision
                TotalQuantityShippedCommand.Parameters.Add("@BillDate", SqlDbType.VarChar).Value = dtpValueDate.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalQuantityShipped = 0
                End Try
                con.Close()
                '******************************************************************************************************************************************
                'Check to see if Total Quantity Shipped falls within the Cost Tiers
                Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
                Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMaxTransactionNumber = 0
                End Try
                con.Close()

                Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
                GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber
                GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
                Catch ex As Exception
                    GetUpperLimit = 0
                End Try
                con.Close()

                If TotalQuantityShipped + QuantityOnHand > GetUpperLimit Then
                    'Item is beyond the Cost Tier - skip FIFO
                    FIFOCost = 0
                    FIFOExtendedAmount = 0
                Else
                    '******************************************************************************************************************************************
                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                    If TotalQuantityShipped = 0 Then
                        TotalQuantityShipped = 1
                        WasTQSZero = "YES"
                    Else
                        TotalQuantityShipped = TotalQuantityShipped + 1
                        WasTQSZero = "NO"
                    End If

                    'Get Max Transaction Number where 
                    Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                    Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
                    GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                    GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
                    Catch ex As Exception
                        GetMaxTransactionNumber = 0
                    End Try
                    con.Close()

                    If GetMaxTransactionNumber = 0 Then
                        NoCostTierFound = "TRUE"
                        FIFOCost = 0
                        FIFOExtendedAmount = 0
                    Else
                        NoCostTierFound = "FALSE"

                        Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                        Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                        ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                        ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                        ItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text
                        ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                        UpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text
                        UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            FIFOCost = CDbl(ItemCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            FIFOCost = 0
                        End Try
                        Try
                            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                        Catch ex As Exception
                            UpperLimit = 0
                        End Try
                        con.Close()
                    End If

                    If NoCostTierFound = "TRUE" Then
                        'Skip FIFO Costing
                    Else
                        If WasTQSZero = "YES" Then
                            TotalQuantityShipped = 0
                        Else
                            TotalQuantityShipped = TotalQuantityShipped - 1
                        End If

                        If TotalQuantityShipped + QuantityOnHand > UpperLimit Then
                            'Quantity crosses a cost tier
                            QuantityRemaining = (TotalQuantityShipped + QuantityOnHand) - UpperLimit

                            FIFOExtendedAmount = (UpperLimit - TotalQuantityShipped) * FIFOCost

                            'Create loop to calculate remainder of quantity
                            Do While QuantityRemaining > 0
                                Dim TempQuantity As Double = 0

                                'Get Max Transaction Number where 
                                Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                                GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumber2Command.ExecuteScalar)
                                Catch ex As Exception
                                    GetMaxTransactionNumber = 0
                                End Try
                                con.Close()

                                If GetMaxTransactionNumber = 0 Then
                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                    NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text

                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                    NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text

                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                    NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        FIFOCost = CDbl(NextItemCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        FIFOCost = 0
                                    End Try
                                    Try
                                        NextUpperLimit = CDbl(NextUpperLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextUpperLimit = 0
                                    End Try
                                    Try
                                        NextLowerLimit = CDbl(NextLowerLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextLowerLimit = 0
                                    End Try
                                    con.Close()
                                Else
                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                    NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text
                                    NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                    NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text
                                    NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                    NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValueDate.Text
                                    NextLowerLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        FIFOCost = CDbl(NextItemCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        FIFOCost = 0
                                    End Try
                                    Try
                                        NextUpperLimit = CDbl(NextUpperLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextUpperLimit = 0
                                    End Try
                                    Try
                                        NextLowerLimit = CDbl(NextLowerLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextLowerLimit = 0
                                    End Try
                                    con.Close()
                                End If

                                TempQuantity = (NextUpperLimit + 1) - NextLowerLimit

                                If QuantityRemaining > TempQuantity Then
                                    'Add to existing FIFO Extended Amount
                                    FIFOExtendedAmount = FIFOExtendedAmount + (TempQuantity * FIFOCost)

                                    'Redefine Quantity Remaining after the next cost tier
                                    QuantityRemaining = QuantityRemaining - TempQuantity
                                    UpperLimit = NextUpperLimit
                                Else
                                    FIFOExtendedAmount = FIFOExtendedAmount + (QuantityRemaining * FIFOCost)
                                    QuantityRemaining = 0
                                End If
                            Loop
                        Else
                            'Entire quantity falls into one cost tier
                            FIFOExtendedAmount = FIFOCost * QuantityOnHand
                        End If
                    End If
                End If
                '*****************************************************************************************************************************************
                If FIFOExtendedAmount = 0 Then
                    Dim MAXTransactionDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionDate <= @TransactionDate"
                    Dim MAXTransactionDateCommand As New SqlCommand(MAXTransactionDateStatement, con)
                    MAXTransactionDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    MAXTransactionDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    MAXTransactionDateCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValueDate.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxTransactionDate = CInt(MAXTransactionDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MaxTransactionDate = 0
                    End Try
                    con.Close()

                    Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastTransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastTransactionCost = 0
                    End Try
                    con.Close()

                    FIFOCost = LastTransactionCost
                    FIFOExtendedAmount = FIFOCost * QuantityOnHand

                    'If Insert fails, write error message to database
                    ErrorDate = Today()
                    ErrorComment = PartNumber + " FIFO Costing failed - Max Transaction Cost - " + ConsignmentDivision
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory QOH -- " + CStr(QuantityOnHand) + ", TQS -- " + CStr(TotalQuantityShipped) + ", Max Cost -- " + CStr(LastTransactionCost)
                    ErrorReferenceNumber = "Valuation Date -- " + dtpValueDate.Text.ToString
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End If
                '***********************************************************************************
                If QuantityOnHand <> 0 Then
                    FIFOCost = FIFOExtendedAmount / QuantityOnHand
                    FIFOCost = Math.Round(FIFOCost, 5)
                End If
            End If
            '*********************************************************************************************************
            'Check Item Class of the part for ferrules
            Dim CheckItemClass As String = ""

            Dim CheckItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim CheckItemClassCommand As New SqlCommand(CheckItemClassStatement, con)
            CheckItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
            CheckItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckItemClass = CStr(CheckItemClassCommand.ExecuteScalar)
            Catch ex As Exception
                CheckItemClass = 0
            End Try
            con.Close()

            If CheckItemClass = "FERRULE" Then
                FIFOCost = 0
                FIFOExtendedAmount = 0
            End If
            '*********************************************************************************************************
            If QuantityOnHand = 0 Then
                'Skip
            Else
                'Write to Temp Table
                cmd = New SqlCommand("INSERT INTO InventoryFIFOValuation (PartNumber, Description, DivisionID, QuantityOnHand, FIFOCost, FIFOExtendedAmount, GLAccount, ValuationDate)values(@PartNumber, @Description, @DivisionID, @QuantityOnHand, @FIFOCost, @FIFOExtendedAmount, @GLAccount, @ValuationDate)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                    .Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    .Add("@QuantityOnHand", SqlDbType.VarChar).Value = QuantityOnHand
                    .Add("@FIFOCost", SqlDbType.VarChar).Value = FIFOCost
                    .Add("@FIFOExtendedAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                    .Add("@ValuationDate", SqlDbType.VarChar).Value = dtpValueDate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*****************************************************************************************************************************************
                'Clear Variables
                FIFOCost = 0
                FIFOExtendedAmount = 0
                NextLowerLimit = 0
                NextUpperLimit = 0
                QuantityRemaining = 0
                TotalQuantityShipped = 0
                UpperLimit = 0
                LowerLimit = 0
                QuantityOnHand = 0
                GetUpperLimit = 0
                GetMaxTransactionNumber = 0
                PartNumber = ""
                PartDescription = ""
                GoToFIFOCosting = "YES"
                SerializedStatus = "NO"
                PPL = ""
                SumSerialCost = 0
                SerialUnitCost = 0
                CountItems = 0
            End If
        Next

        If chkValueAll.Checked = True Then
            WarehouseName = "All"
        End If

        If WarehouseName = "All" Then
            'Populate Datagrid
            cmd = New SqlCommand("SELECT * FROM InventoryFIFOValuation WHERE DivisionID LIKE @DivisionID OR DivisionID = 'SRL' ORDER BY DivisionID, PartNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "%CW"
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "InventoryFIFOValuation")
            dgvFIFOValue.DataSource = ds4.Tables("InventoryFIFOValuation")
            con.Close()
        Else
            'Populate Datagrid
            cmd = New SqlCommand("SELECT * FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "InventoryFIFOValuation")
            dgvFIFOValue.DataSource = ds4.Tables("InventoryFIFOValuation")
            con.Close()
        End If
   
        Me.dgvConsignmentInventory.Visible = False
        Me.dgvFIFOValue.Visible = True
        Me.dgvFIFOSteelValue.Visible = False
    End Sub

    Private Sub cmdPrintValueReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintValueReport.Click
        GDS = ds4

        Using NewPrintConsignmentValuation As New PrintConsignmentValuation
            Dim Result = NewPrintConsignmentValuation.ShowDialog()
        End Using
    End Sub

    Public Sub LoadInventorySteelValue()
        Dim CountItems As Integer

        Dim CountItemsStatement As String = "SELECT COUNT(ItemID) FROM InventoryValuationSummary WHERE DivisionID = @DivisionID"
        Dim CountItemsCommand As New SqlCommand(CountItemsStatement, con)
        CountItemsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboValueDivision.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountItems = CInt(CountItemsCommand.ExecuteScalar)
        Catch ex As Exception
            CountItems = 0
        End Try
        con.Close()

        Dim PartNumber, PartDescription As String
        Dim QuantityOnHand As Double = 0
        Dim SteelCostUnit As Double = 0
        Dim SteelCostTotal As Double = 0
        Dim PieceWeight As Double = 0
        Dim FOXNumber As Integer
        Dim SteelCarbon, SteelSize, RMID As String
        Dim ConsignmentDivision As String = ""

        'Delete Temp Tables
        cmd = New SqlCommand("Delete FROM InventorySteelValuation", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        For Each row As DataGridViewRow In dgvFIFOValue.Rows
            Try
                PartNumber = row.Cells("PartNumberColumn2").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = row.Cells("DescriptionColumn2").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                QuantityOnHand = row.Cells("QuantityOnHandColumn2").Value
            Catch ex As Exception
                QuantityOnHand = 0
            End Try
            Try
                ConsignmentDivision = row.Cells("DivisionIDColumn2").Value
            Catch ex As Exception
                ConsignmentDivision = ""
            End Try
            '******************************************************************************************************************************************
            'Get FOX Number for part
            Dim FOXNumberStatement As String = "SELECT MAX(FOXNumber) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim FOXNumberCommand As New SqlCommand(FOXNumberStatement, con)
            FOXNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
            FOXNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            Dim PieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PieceWeightCommand As New SqlCommand(PieceWeightStatement, con)
            PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
            PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FOXNumber = CInt(FOXNumberCommand.ExecuteScalar)
            Catch ex As Exception
                FOXNumber = 0
            End Try
            Try
                PieceWeight = CDbl(PieceWeightCommand.ExecuteScalar)
            Catch ex As Exception
                PieceWeight = 0
            End Try
            con.Close()

            Dim RMIDStatement As String = "SELECT RMID FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
            Dim RMIDCommand As New SqlCommand(RMIDStatement, con)
            RMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
            RMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                RMID = CStr(RMIDCommand.ExecuteScalar)
            Catch ex As Exception
                RMID = ""
            End Try
            con.Close()

            'Get Carbon and Steel Size
            Dim SteelCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID"
            Dim SteelCarbonCommand As New SqlCommand(SteelCarbonStatement, con)
            SteelCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RMID

            Dim SteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID"
            Dim SteelSizeCommand As New SqlCommand(SteelSizeStatement, con)
            SteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RMID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SteelCarbon = CStr(SteelCarbonCommand.ExecuteScalar)
            Catch ex As Exception
                SteelCarbon = ""
            End Try
            Try
                SteelSize = CStr(SteelSizeCommand.ExecuteScalar)
            Catch ex As Exception
                SteelSize = ""
            End Try
            con.Close()

            '******************************************************************************************************************************************
            'Get FIFO Cost of Steel
            '******************************************************************************************************************************************
            cmd = New SqlCommand("SELECT isnull(SteelCostPerPound, 0) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND (SELECT isnull(case when SUM(UsageWeight)=0 then 1 else SUM(UsageWeight) END, 1) FROM SteelUsageTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND Status = 'POSTED' AND UsageDate <= @PostingDate) BETWEEN LowerLimit AND UpperLimit AND CostingDate <= @PostingDate;", con)
            cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelCarbon
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize
            cmd.Parameters.Add("@PostingDate", SqlDbType.Date).Value = dtpValueDate.Value

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SteelCostUnit = cmd.ExecuteScalar()
            Catch ex As System.Exception
            End Try

            If SteelCostUnit = 0 Then
                cmd = New SqlCommand("SELECT isnull(SteelCostPerPound, 0) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND (SELECT isnull(case when SUM(UsageWeight)=0 then 1 else SUM(UsageWeight) END, 1) FROM SteelUsageTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit;", con)
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelCarbon
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SteelCostUnit = cmd.ExecuteScalar()
                Catch ex As System.Exception
                End Try

                If SteelCostUnit = 0 Then
                    cmd = New SqlCommand("SELECT (SteelExtendedCost / isnull(ReceiveWeight, 1)) FROM SteelReceivingLineTable  WHERE SteelReceivingHeaderKey = (SELECT MAX(SteelReceivingHeaderKey) FROM SteelReceivingLineTable  WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize));", con)
                    cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelCarbon
                    cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SteelCostUnit = cmd.ExecuteScalar()
                    Catch ex As System.Exception
                        'sendErrorToDataBase("SteelAdjustmentForm - LoadSteelCost --Error trying to get the cost of the currently selected Carbon/Steel Size", " Carbon - " + cboAdjustCarbon.Text + " Size - " + cboAdjustSteelSize.Text, ex.ToString())
                    End Try
                End If
            End If
            con.Close()
            '*****************************************************************************************************************************************
            If QuantityOnHand <> 0 Then
                SteelCostTotal = SteelCostUnit * (QuantityOnHand * PieceWeight)
                SteelCostTotal = Math.Round(SteelCostTotal, 2)
            End If

            If FOXNumber = 0 Or RMID = "" Or SteelCarbon = "" Or SteelSize = "" Then
                'Skip
            Else
                'Write to Temp Table
                cmd = New SqlCommand("INSERT INTO InventorySteelValuation (PartNumber, Description, DivisionID, QuantityOnHand, FOXNumber, RMID, SteelCarbon, SteelSize, SteelCostUnit, SteelCostTotal, ValuationDate, PieceWeight)values(@PartNumber, @Description, @DivisionID, @QuantityOnHand, @FOXNumber, @RMID, @SteelCarbon, @SteelSize, @SteelCostUnit, @SteelCostTotal, @ValuationDate, @PieceWeight)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                    .Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    .Add("@QuantityOnHand", SqlDbType.VarChar).Value = QuantityOnHand
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
                    .Add("@RMID", SqlDbType.VarChar).Value = RMID
                    .Add("@SteelCarbon", SqlDbType.VarChar).Value = SteelCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize
                    .Add("@SteelCostUnit", SqlDbType.VarChar).Value = SteelCostUnit
                    .Add("@SteelCostTotal", SqlDbType.VarChar).Value = SteelCostTotal
                    .Add("@ValuationDate", SqlDbType.VarChar).Value = dtpValueDate.Text
                    .Add("@PieceWeight", SqlDbType.VarChar).Value = PieceWeight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            '*****************************************************************************************************************************************
            'Clear Variables
            FOXNumber = 0
            QuantityOnHand = 0
            PartNumber = ""
            PartDescription = ""
            SteelCarbon = ""
            SteelSize = ""
            SteelCostTotal = 0
            SteelCostUnit = 0
            PieceWeight = 0
            RMID = ""
        Next
    End Sub

    Private Sub cmdValueInventorySteel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValueInventorySteel.Click
        LoadInventorySteelValue()
        ShowSteelValue()
        dgvConsignmentInventory.Visible = False
        dgvFIFOValue.Visible = False
        dgvFIFOSteelValue.Visible = True
    End Sub

    Private Sub cmdPrintInventorySteel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintInventorySteel.Click
        GDS = ds6

        Using NewPrintInventorySteelValue As New PrintInventorySteelValue
            Dim result = NewPrintInventorySteelValue.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

End Class
