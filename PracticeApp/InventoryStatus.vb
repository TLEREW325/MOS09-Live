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
Public Class InventoryStatus
    Inherits System.Windows.Forms.Form

    Dim NewLoading As New Loading
    Dim asyncDivision As String = ""

    Dim PartNumber, PartDescription, SPLFilter, DescriptionFilter, ZeroQuantityFilter, PartFilter, ItemClassTextFilter, ItemClassFilter, Text1Filter, Text2Filter, Text3Filter, Text4Filter, Text5Filter As String
    Dim MaxDate As Integer
    Dim QuantityOnHand, StandardCost, StandardPrice, LastSalesPrice, LastPurchaseCost As Double

    'User Preferences
    Dim HideAssembly As String = ""
    Dim HideCustomerReturn As String = ""
    Dim HideFOX As String = ""
    Dim HideMaxStock As String = ""
    Dim HideMinStock As String = ""
    Dim HidePO As String = ""
    Dim HideProductionQty As String = ""
    Dim HideQtyAdjusted As String = ""
    Dim HideQtyReceived As String = ""
    Dim HideQtyShipped As String = ""
    Dim HideSO As String = ""
    Dim HideStandardCost As String = ""
    Dim HideStandardPrice As String = ""
    Dim HideVendorReturn As String = ""
    Dim HideWCProduction As String = ""
    Dim HidePreferredVendor As String = ""
    Dim HideLeadTime As String = ""

    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")

    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim isLoaded As Boolean = False

    Public Sub LoadColumnPreferences()
        Dim GetPreferences As String = ""

        'Get preferences from the database
        Dim GetPreferencesStatement As String = "SELECT CustomCode FROM EmployeeData WHERE LoginName = @LoginName"
        Dim GetPreferencesCommand As New SqlCommand(GetPreferencesStatement, con)
        GetPreferencesCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetPreferences = CStr(GetPreferencesCommand.ExecuteScalar)
        Catch ex As Exception
            GetPreferences = ""
        End Try
        con.Close()

        GlobalStockStatusUserPreferences = GetPreferences

        HideAssembly = GlobalStockStatusUserPreferences.Substring(0, 1)
        HideCustomerReturn = GlobalStockStatusUserPreferences.Substring(1, 1)
        HideFOX = GlobalStockStatusUserPreferences.Substring(2, 1)
        HideMaxStock = GlobalStockStatusUserPreferences.Substring(3, 1)
        HideMinStock = GlobalStockStatusUserPreferences.Substring(4, 1)
        HidePO = GlobalStockStatusUserPreferences.Substring(5, 1)
        HideProductionQty = GlobalStockStatusUserPreferences.Substring(6, 1)
        HideQtyAdjusted = GlobalStockStatusUserPreferences.Substring(7, 1)
        HideQtyReceived = GlobalStockStatusUserPreferences.Substring(8, 1)
        HideQtyShipped = GlobalStockStatusUserPreferences.Substring(9, 1)
        HideSO = GlobalStockStatusUserPreferences.Substring(10, 1)
        HideStandardCost = GlobalStockStatusUserPreferences.Substring(11, 1)
        HideStandardPrice = GlobalStockStatusUserPreferences.Substring(12, 1)
        HideVendorReturn = GlobalStockStatusUserPreferences.Substring(13, 1)
        HideWCProduction = GlobalStockStatusUserPreferences.Substring(14, 1)
        HidePreferredVendor = GlobalStockStatusUserPreferences.Substring(15, 1)
        HideLeadTime = GlobalStockStatusUserPreferences.Substring(16, 1)

        If HideAssembly = "0" Then
            Me.dgvInventoryTotals.Columns("AssemblyBuildQuantityColumn").Visible = False
            HideAssemblyColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("AssemblyBuildQuantityColumn").Visible = True
            HideAssemblyColumn.Checked = False
        End If
        If HideCustomerReturn = "0" Then
            Me.dgvInventoryTotals.Columns("CustomerReturnQuantityColumn").Visible = False
            HideCustomerReturnColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("CustomerReturnQuantityColumn").Visible = True
            HideCustomerReturnColumn.Checked = False
        End If
        If HideFOX = "0" Then
            Me.dgvInventoryTotals.Columns("FOXNumberColumn").Visible = False
            HideFOXColumn.Checked = True
            chkShowFOX.Checked = False
        Else
            Me.dgvInventoryTotals.Columns("FOXNumberColumn").Visible = True
            HideFOXColumn.Checked = False
            chkShowFOX.Checked = True
        End If
        If HideMaxStock = "0" Then
            Me.dgvInventoryTotals.Columns("MaximumStockColumn").Visible = False
            HideMaxStockColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("MaximumStockColumn").Visible = True
            HideMaxStockColumn.Checked = False
        End If
        If HideMinStock = "0" Then
            Me.dgvInventoryTotals.Columns("MinimumStockColumn").Visible = False
            HideMinStockColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("MinimumStockColumn").Visible = True
            HideMinStockColumn.Checked = False
        End If
        If HidePO = "0" Then
            Me.dgvInventoryTotals.Columns("OpenPOQuantityColumn").Visible = False
            HidePOColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("OpenPOQuantityColumn").Visible = True
            HidePOColumn.Checked = False
        End If
        If HideProductionQty = "0" Then
            Me.dgvInventoryTotals.Columns("ProductionQuantityColumn").Visible = False
            HideProductionQtyColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("ProductionQuantityColumn").Visible = True
            HideProductionQtyColumn.Checked = False
        End If
        If HideQtyAdjusted = "0" Then
            Me.dgvInventoryTotals.Columns("AdjustmentQuantityColumn").Visible = False
            HideQtyAdjustedColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("AdjustmentQuantityColumn").Visible = True
            HideQtyAdjustedColumn.Checked = False
        End If
        If HideQtyReceived = "0" Then
            Me.dgvInventoryTotals.Columns("TotalReceivedQuantityColumn").Visible = False
            HideQtyReceivedColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("TotalReceivedQuantityColumn").Visible = True
            HideQtyReceivedColumn.Checked = False
        End If
        If HideQtyShipped = "0" Then
            Me.dgvInventoryTotals.Columns("TotalQuantityShippedColumn").Visible = False
            HideQtyShippedColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("TotalQuantityShippedColumn").Visible = True
            HideQtyShippedColumn.Checked = False
        End If
        If HideSO = "0" Then
            Me.dgvInventoryTotals.Columns("OpenSOQuantityColumn").Visible = False
            HideSOColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("OpenSOQuantityColumn").Visible = True
            HideSOColumn.Checked = False
        End If
        If HideStandardCost = "0" Then
            Me.dgvInventoryTotals.Columns("StandardCostColumn").Visible = False
            HideStandardCostColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("StandardCostColumn").Visible = True
            HideStandardCostColumn.Checked = False
        End If
        If HideStandardPrice = "0" Then
            Me.dgvInventoryTotals.Columns("StandardPriceColumn").Visible = False
            HideStandardPriceColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("StandardPriceColumn").Visible = True
            HideStandardPriceColumn.Checked = False
        End If
        If HideVendorReturn = "0" Then
            Me.dgvInventoryTotals.Columns("VendorReturnQuantityColumn").Visible = False
            HideVendorReturnColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("VendorReturnQuantityColumn").Visible = True
            HideVendorReturnColumn.Checked = False
        End If
        If HideWCProduction = "0" Then
            Me.dgvInventoryTotals.Columns("WCProductionQuantityColumn").Visible = False
            HideWCProductionColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("WCProductionQuantityColumn").Visible = True
            HideWCProductionColumn.Checked = False
        End If
        If HidePreferredVendor = "0" Then
            Me.dgvInventoryTotals.Columns("PreferredVendorColumn").Visible = False
            HidePrefVendorColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("PreferredVendorColumn").Visible = True
            HidePrefVendorColumn.Checked = False
        End If
        If HideLeadTime = "0" Then
            Me.dgvInventoryTotals.Columns("LeadTimeColumn").Visible = False
            HideLeadTimeColumn.Checked = True
        Else
            Me.dgvInventoryTotals.Columns("LeadTimeColumn").Visible = True
            HideLeadTimeColumn.Checked = False
        End If
    End Sub

    Public Sub SaveUserPreferences()
        GlobalStockStatusUserPreferences = ""

        If HideAssemblyColumn.Checked = True Then
            HideAssembly = "0"
        Else
            HideAssembly = "1"
        End If
        If HideCustomerReturnColumn.Checked = True Then
            HideCustomerReturn = "0"
        Else
            HideCustomerReturn = "1"
        End If
        If HideFOXColumn.Checked = True Then
            HideFOX = "0"
        Else
            HideFOX = "1"
        End If
        If HideMaxStockColumn.Checked = True Then
            HideMaxStock = "0"
        Else
            HideMaxStock = "1"
        End If
        If HideMinStockColumn.Checked = True Then
            HideMinStock = "0"
        Else
            HideMinStock = "1"
        End If
        If HidePOColumn.Checked = True Then
            HidePO = "0"
        Else
            HidePO = "1"
        End If
        If HideProductionQtyColumn.Checked = True Then
            HideProductionQty = "0"
        Else
            HideProductionQty = "1"
        End If
        If HideQtyAdjustedColumn.Checked = True Then
            HideQtyAdjusted = "0"
        Else
            HideQtyAdjusted = "1"
        End If
        If HideQtyReceivedColumn.Checked = True Then
            HideQtyReceived = "0"
        Else
            HideQtyReceived = "1"
        End If
        If HideQtyShippedColumn.Checked = True Then
            HideQtyShipped = "0"
        Else
            HideQtyShipped = "1"
        End If
        If HideSOColumn.Checked = True Then
            HideSO = "0"
        Else
            HideSO = "1"
        End If
        If HideStandardCostColumn.Checked = True Then
            HideStandardCost = "0"
        Else
            HideStandardCost = "1"
        End If
        If HideStandardPriceColumn.Checked = True Then
            HideStandardPrice = "0"
        Else
            HideStandardPrice = "1"
        End If
        If HideVendorReturnColumn.Checked = True Then
            HideVendorReturn = "0"
        Else
            HideVendorReturn = "1"
        End If
        If HideWCProductionColumn.Checked = True Then
            HideWCProduction = "0"
        Else
            HideWCProduction = "1"
        End If
        If HidePrefVendorColumn.Checked = True Then
            HidePreferredVendor = "0"
        Else
            HidePreferredVendor = "1"
        End If
        If HideLeadTimeColumn.Checked = True Then
            HideLeadTime = "0"
        Else
            HideLeadTime = "1"
        End If

        GlobalStockStatusUserPreferences = HideAssembly + HideCustomerReturn + HideFOX + HideMaxStock + HideMinStock + HidePO + HideProductionQty + HideQtyAdjusted + HideQtyReceived + HideQtyShipped + HideSO + HideStandardCost + HideStandardPrice + HideVendorReturn + HideWCProduction + HidePreferredVendor + HideLeadTime

        'UPDATE Assembly Data in grid
        cmd = New SqlCommand("UPDATE EmployeeData SET CustomCode = @CustomCode WHERE LoginName = @LoginName", con)

        With cmd.Parameters
            .Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@CustomCode", SqlDbType.VarChar).Value = GlobalStockStatusUserPreferences
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub InventoryStatus_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveUserPreferences()
    End Sub

    Private Sub InventoryStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadSPL()
        LoadSelectByItemClass()
        LoadCurrentDivision()
        LoadItemClassForReorderWorksheet()

        isLoaded = True

        usefulFunctions.LoadSecurity(Me)

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            'chkShowFOX.Checked = True
            chkShowFOX.Visible = True
            LoadTWItemClass()
        Else
            chkShowFOX.Checked = False
            chkShowFOX.Visible = False
            LoadItemClass()
        End If

        LoadColumnPreferences()
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
        dgvInventoryTotals.DataSource = Nothing
        lblLoading.Visible = False
    End Sub

    Public Sub ShowDataByFilters()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID >= '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboPartNumber.Text = "" And cboPartDescription.Text <> "" Then
            DescriptionFilter = " AND ShortDescription LIKE '" + usefulFunctions.checkQuote(cboPartDescription.Text) + "%'"
        Else
            DescriptionFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If cboSPL.Text <> "" Then
            SPLFilter = " AND SalesProdLineID = '" + cboSPL.Text + "'"
        Else
            SPLFilter = ""
        End If
        If txtClassTextFilter.Text <> "" Then
            ItemClassTextFilter = " AND ItemClass LIKE '%" + txtClassTextFilter.Text + "%'"
        Else
            ItemClassTextFilter = ""
        End If
        If chkOmit.Checked = True Then
            ZeroQuantityFilter = " AND QuantityOnHand <> 0"
        Else
            ZeroQuantityFilter = ""
        End If
        If txtTextFilter1.Text <> "" Then
            Text1Filter = " AND (ShortDescription LIKE '" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%' OR ItemID LIKE '" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%')"
        Else
            Text1Filter = ""
        End If
        If txtTextFilter2.Text <> "" Then
            Text2Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%')"
        Else
            Text2Filter = ""
        End If
        If txtTextFilter3.Text <> "" Then
            Text3Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%')"
        Else
            Text3Filter = ""
        End If
        If txtTextFilter4.Text <> "" Then
            Text4Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter4.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter4.Text) + "%')"
        Else
            Text4Filter = ""
        End If
        If txtTextFilter5.Text <> "" Then
            Text5Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter5.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter5.Text) + "%')"
        Else
            Text5Filter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass <> 'RENTAL' AND ItemClass <> 'MISC-CHARGE' AND ItemClass <> 'DEACTIVATED-PART'" + PartFilter + DescriptionFilter + ItemClassFilter + SPLFilter + ItemClassTextFilter + ZeroQuantityFilter + Text1Filter + Text2Filter + Text3Filter + Text4Filter + Text5Filter + " ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
    End Sub

    Public Sub ShowColumns()
        Me.dgvInventoryTotals.Columns("FOXNumberColumn").Visible = True
        Me.dgvInventoryTotals.Columns("MinimumStockColumn").Visible = True
        Me.dgvInventoryTotals.Columns("MaximumStockColumn").Visible = True
        Me.dgvInventoryTotals.Columns("OpenSOQuantityColumn").Visible = True
        Me.dgvInventoryTotals.Columns("OpenPOQuantityColumn").Visible = True
        Me.dgvInventoryTotals.Columns("AdjustmentQuantityColumn").Visible = True
        Me.dgvInventoryTotals.Columns("VendorReturnQuantityColumn").Visible = True
        Me.dgvInventoryTotals.Columns("CustomerReturnQuantityColumn").Visible = True
        Me.dgvInventoryTotals.Columns("ProductionQuantityColumn").Visible = True
        Me.dgvInventoryTotals.Columns("WCProductionQuantityColumn").Visible = True
        Me.dgvInventoryTotals.Columns("AssemblyBuildQuantityColumn").Visible = True
        Me.dgvInventoryTotals.Columns("StandardCostColumn").Visible = True
        Me.dgvInventoryTotals.Columns("StandardPriceColumn").Visible = True
        Me.dgvInventoryTotals.Columns("TotalReceivedQuantityColumn").Visible = True
        Me.dgvInventoryTotals.Columns("TotalQuantityShippedColumn").Visible = True
        Me.dgvInventoryTotals.Columns("TotalShipQuantityPendingColumn").Visible = True
        Me.dgvInventoryTotals.Columns("PreferredVendorColumn").Visible = True
        Me.dgvInventoryTotals.Columns("LeadTimeColumn").Visible = True

        HideAssemblyColumn.Checked = False
        HideCustomerReturnColumn.Checked = False
        HideMaxStockColumn.Checked = False
        HideMinStockColumn.Checked = False
        HidePOColumn.Checked = False
        HideProductionQtyColumn.Checked = False
        HideQtyAdjustedColumn.Checked = False
        HideQtyReceivedColumn.Checked = False
        HideQtyShippedColumn.Checked = False
        HideSOColumn.Checked = False
        HideStandardCostColumn.Checked = False
        HideStandardPriceColumn.Checked = False
        HideVendorReturnColumn.Checked = False
        HideWCProductionColumn.Checked = False
        HidePrefVendorColumn.Checked = False
        HideLeadTimeColumn.Checked = False

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            HideFOXColumn.Checked = False
            chkShowFOX.Checked = True
            HideFOXColumn.Enabled = True
            chkShowFOX.Visible = True
        Else
            HideFOXColumn.Checked = True
            chkShowFOX.Checked = False
            HideFOXColumn.Enabled = False
            chkShowFOX.Visible = False
        End If
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList Where DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "ItemList")
        con.Close()

        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartNumber.DisplayMember = "ItemID"
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadTWItemClass()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass WHERE ItemClassID LIKE 'TW%' OR ItemClassID = 'BOXES' OR ItemClassID = 'FERRULE'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemClass")
        cboItemClass.DataSource = ds2.Tables("ItemClass")
        con.Close()
        cboItemClass.SelectedIndex = -1
    End Sub

    Private Sub LoadDivision()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "DivisionTable")
        con.Close()

        cboDivisionID.DataSource = ds3.Tables("DivisionTable")
        cboDivisionID.DisplayMember = "DivisionKey"
        cboDivisionID.SelectedIndex = -1
    End Sub

    Private Sub LoadItemClass()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass WHERE ItemClassID <> 'DEACTIVATED-PART' AND ItemClassID <> 'RENTAL' AND ItemClassID <> 'BOXES' AND ItemClassID <> 'MISC-CHARGE'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemClass")
        cboItemClass.DataSource = ds2.Tables("ItemClass")
        con.Close()
        cboItemClass.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList Where DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter8.Fill(ds8, "ItemList")
        con.Close()

        cboPartDescription.DataSource = ds8.Tables("ItemList")
        cboPartDescription.DisplayMember = "ShortDescription"
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadSPL()
        cmd = New SqlCommand("SELECT SalesProdLineID FROM SalesProductLine ORDER BY SalesProdLineID ASC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "SalesProductLine")
        cboSPL.DataSource = ds9.Tables("SalesProductLine")
        con.Close()
        cboSPL.SelectedIndex = -1
    End Sub

    Public Sub LoadSelectByItemClass()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass WHERE ItemClassID LIKE 'TW%' OR ItemClassID = 'BOXES' OR ItemClassID = 'FERRULE'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds10 = New DataSet()
        myAdapter10.SelectCommand = cmd
        myAdapter10.Fill(ds10, "ItemClass")
        cboSelectByItemClass.DataSource = ds10.Tables("ItemClass")
        con.Close()
        cboSelectByItemClass.SelectedIndex = -1
    End Sub

    Public Sub LoadItemClassForReorderWorksheet()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemClass")
        cboItemClassReorderWorksheet.DataSource = ds2.Tables("ItemClass")
        con.Close()
        cboItemClassReorderWorksheet.SelectedIndex = -1
    End Sub

    Public Sub LoadQOHShippingDataset()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID >= '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboPartNumber.Text = "" And cboPartDescription.Text <> "" Then
            DescriptionFilter = " AND ShortDescription >= '" + usefulFunctions.checkQuote(cboPartDescription.Text) + "'"
        Else
            DescriptionFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If cboSPL.Text <> "" Then
            SPLFilter = " AND SalesProdLineID = '" + cboSPL.Text + "'"
        Else
            SPLFilter = ""
        End If
        If txtClassTextFilter.Text <> "" Then
            ItemClassTextFilter = " AND ItemClass LIKE '%" + txtClassTextFilter.Text + "%'"
        Else
            ItemClassTextFilter = ""
        End If
        If chkOmit.Checked = True Then
            ZeroQuantityFilter = " AND QuantityOnHand <> 0"
        Else
            ZeroQuantityFilter = ""
        End If
        If txtTextFilter1.Text <> "" Then
            Text1Filter = " AND (ShortDescription LIKE '" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%' OR ItemID LIKE '" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%')"
        Else
            Text1Filter = ""
        End If
        If txtTextFilter2.Text <> "" Then
            Text2Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%')"
        Else
            Text2Filter = ""
        End If
        If txtTextFilter3.Text <> "" Then
            Text3Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%')"
        Else
            Text3Filter = ""
        End If
        If txtTextFilter4.Text <> "" Then
            Text4Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter4.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter4.Text) + "%')"
        Else
            Text4Filter = ""
        End If
        If txtTextFilter5.Text <> "" Then
            Text5Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter5.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter5.Text) + "%')"
        Else
            Text5Filter = ""
        End If

        cmd = New SqlCommand("SELECT ItemID, DivisionID, ShortDescription, OpenSOQuantity, OpenPOQuantity, TotalQuantityShipped, QuantityOnHand, LastYearShippedToDate  FROM ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'" + PartFilter + DescriptionFilter + ItemClassFilter + SPLFilter + ItemClassTextFilter + ZeroQuantityFilter + Text1Filter + Text2Filter + Text3Filter + Text4Filter + Text5Filter + " ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd

        If con1.State = ConnectionState.Closed Then con1.Open()
        myAdapter7.Fill(ds7, "ADMInventoryTotal")
        con1.Close()
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
        cboItemClass.Text = ""
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""

        cboItemClass.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboSPL.SelectedIndex = -1

        txtTextFilter1.Clear()
        txtTextFilter2.Clear()
        txtTextFilter3.Clear()
        txtTextFilter4.Clear()
        txtTextFilter5.Clear()
        txtClassTextFilter.Clear()

        lblLoading.Visible = False

        chkOmit.Checked = False
        chkWithoutCommitted.Checked = False

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            chkShowFOX.Visible = True
        Else
            chkShowFOX.Visible = False
        End If

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        PartNumber = ""
        PartDescription = ""
        ZeroQuantityFilter = ""
        PartFilter = ""
        ItemClassFilter = ""
        Text1Filter = ""
        Text2Filter = ""
        Text3Filter = ""
        Text4Filter = ""
        Text5Filter = ""
        ItemClassTextFilter = ""

        MaxDate = 0
        QuantityOnHand = 0
        StandardCost = 0
        StandardPrice = 0
        LastSalesPrice = 0
        LastPurchaseCost = 0
    End Sub

    Public Sub ClearAllDatagrids()
        dgvInventoryTotals.DataSource = Nothing
    End Sub

    Private Sub cmdOpenItemForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalMaintenancePartDescription = cboPartDescription.Text

        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        lblLoading.Visible = True
        ShowDataByFilters()
        BGLoading.RunWorkerAsync()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            chkShowFOX.Visible = True
            HideFOXColumn.Enabled = True
        Else
            chkShowFOX.Visible = False
            Me.dgvInventoryTotals.Columns("FOXNumberColumn").Visible = False
            HideFOXColumn.Checked = True
            HideFOXColumn.Enabled = False
        End If

        LoadColumnPreferences()
    End Sub

    Private Sub cmdUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsage.Click
        LoadQOHShippingDataset()

        GDS5 = ds7

        Using NewPrintInventoryStockShippingTotals As New PrintInventoryStockShippingTotals
            Dim result = NewPrintInventoryStockShippingTotals.ShowDialog()
        End Using
    End Sub

    Private Sub InventoryUsageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryUsageToolStripMenuItem.Click
        LoadQOHShippingDataset()
        GDS5 = ds7

        Using NewPrintInventoryStockShippingTotals As New PrintInventoryStockShippingTotals
            Dim result = NewPrintInventoryStockShippingTotals.ShowDialog()
        End Using
    End Sub

    Private Sub cmdReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReorder.Click
        If cboItemClassReorderWorksheet.Text <> "" Then
            GlobalItemClass = cboItemClassReorderWorksheet.Text
        Else
            GlobalItemClass = "NO FILTER"
        End If

        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintReorderWorksheet As New PrintReorderWorksheet
            Dim result = NewPrintReorderWorksheet.ShowDialog()
        End Using
    End Sub

    Private Sub ReorderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReorderToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintReorderWorksheet As New PrintReorderWorksheet
            Dim result = NewPrintReorderWorksheet.ShowDialog()
        End Using
    End Sub

    Private Sub cmdCountSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCountSheet.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintInventoryCountSheet As New PrintInventoryCountSheet
            Dim result = NewPrintInventoryCountSheet.ShowDialog()
        End Using
    End Sub

    Private Sub InventoryCountSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryCountSheetToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintInventoryCountSheet As New PrintInventoryCountSheet
            Dim result = NewPrintInventoryCountSheet.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        SaveUserPreferences()
        ClearData()
        ClearVariables()
        ClearAllDatagrids()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintStockStatus As New PrintStockStatus
            Dim result = NewPrintStockStatus.ShowDialog()
        End Using
    End Sub

    Private Sub dgvInventoryTotals_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryTotals.CellDoubleClick
        If cboDivisionID.Text = "TWD" Then
            Dim RowIndex As Integer = Me.dgvInventoryTotals.CurrentCell.RowIndex
            Dim RowPartNumber As String = Me.dgvInventoryTotals.Rows(RowIndex).Cells("ItemIDColumn").Value
            GlobalPartNumberLookup = RowPartNumber
            GlobalDivisionCode = cboDivisionID.Text

            Dim NewPriceLookup As New PriceLookup
            NewPriceLookup.Show()
        Else
            Dim RowIndex As Integer = Me.dgvInventoryTotals.CurrentCell.RowIndex
            Dim RowPartNumber As String = Me.dgvInventoryTotals.Rows(RowIndex).Cells("ItemIDColumn").Value
            GlobalPartNumberLookup = RowPartNumber
            GlobalDivisionCode = cboDivisionID.Text

            Dim NewPriceLookup As New ItemLookup
            NewPriceLookup.Show()
        End If
    End Sub

    Private Sub cmdNegativeInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNegativeInventory.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintNegativeInventory As New PrintNegativeInventory
            Dim Result = NewPrintNegativeInventory.ShowDialog()
        End Using
    End Sub

    Private Sub NegativeInventoryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NegativeInventoryReportToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintNegativeInventory As New PrintNegativeInventory
            Dim Result = NewPrintNegativeInventory.ShowDialog()
        End Using
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdTWDInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTWDInventory.Click
        'Choose the correct Print Form (REMOTE or LOCAL)

        'Get Login Type
        Dim GetLoginType As String = ""

        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetLoginType = ""
        End Try
        con.Close()

        GlobalItemClass = cboSelectByItemClass.Text
        If chkWithoutCommitted.Checked = True Then
            GlobalPrintWithoutCommitted = "YES"
        Else
            GlobalPrintWithoutCommitted = "NO"
        End If

        If GetLoginType = "REMOTE" Then
            Using NewPrintTWDStockStatusRemote As New PrintTWDStockStatusRemote
                Dim Result = NewPrintTWDStockStatusRemote.ShowDialog()
            End Using
        Else
            Using NewPrintTWDStockStatus As New PrintTWDStockStatus
                Dim Result = NewPrintTWDStockStatus.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BGLoading_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGLoading.DoWork
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "ADMInventoryTotal")
        con.Close()
    End Sub

    Private Sub BGLoading_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGLoading.RunWorkerCompleted
        dgvInventoryTotals.DataSource = ds.Tables("ADMInventoryTotal")

        dgvInventoryTotals.Columns("ItemIDColumn").Width = 230
        dgvInventoryTotals.Columns("ShortDescriptionColumn").Width = 320
        lblLoading.Visible = False

        LoadColumnPreferences()
    End Sub

    Private Sub cmdItemMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemMaintenance.Click
        Dim RowIndex As Integer = Me.dgvInventoryTotals.CurrentCell.RowIndex
        Dim RowPartNumber As String = Me.dgvInventoryTotals.Rows(RowIndex).Cells("ItemIDColumn").Value

        GlobalItemListingPartNumber = RowPartNumber
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewItemForm As New ItemMaintenance
        NewItemForm.Show()
    End Sub

    Private Sub cmdViewWIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewWIP.Click
        If dgvInventoryTotals.SelectedCells.Count > 0 Or dgvInventoryTotals.SelectedRows.Count > 0 Then
            If dgvInventoryTotals.SelectedRows.Count > 0 Then
                Dim lst As New List(Of String)
                For i As Integer = dgvInventoryTotals.SelectedRows.Count - 1 To 0 Step -1
                    lst.Add(dgvInventoryTotals.SelectedRows(i).Cells("ItemIDColumn").Value)
                Next
                Dim newViewWIPPopup As New ViewWIPPopup(lst)
                newViewWIPPopup.ShowDialog()
            Else
                Dim newViewWIPPopup As New ViewWIPPopup(dgvInventoryTotals.Rows(dgvInventoryTotals.SelectedCells(0).RowIndex).Cells("ItemIDColumn").Value)
                newViewWIPPopup.ShowDialog()
            End If

            Me.BringToFront()
        End If
    End Sub

    Private Sub cmdPrintRackContents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintRackContents.Click
        Using NewPrintRackContents As New PrintRackContents
            Dim Result = NewPrintRackContents.ShowDialog()
        End Using
    End Sub

    Private Sub HideSOColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideSOColumn.Click
        If HideSOColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("OpenSOQuantityColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("OpenSOQuantityColumn").Visible = True
        End If
    End Sub

    Private Sub HidePOColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HidePOColumn.Click
        If HidePOColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("OpenPOQuantityColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("OpenPOQuantityColumn").Visible = True
        End If
    End Sub

    Private Sub HideStandardCostColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideStandardCostColumn.Click
        If HideStandardCostColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("StandardCostColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("StandardCostColumn").Visible = True
        End If
    End Sub

    Private Sub HideStandardPriceColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideStandardPriceColumn.Click
        If HideStandardPriceColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("StandardPriceColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("StandardPriceColumn").Visible = True
        End If
    End Sub

    Private Sub HideMinStockColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideMinStockColumn.Click
        If HideMinStockColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("MinimumStockColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("MinimumStockColumn").Visible = True
        End If
    End Sub

    Private Sub HideMaxStockColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideMaxStockColumn.Click
        If HideMaxStockColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("MaximumStockColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("MaximumStockColumn").Visible = True
        End If
    End Sub

    Private Sub HideFOXColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideFOXColumn.Click
        If HideFOXColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("FOXNumberColumn").Visible = False
            chkShowFOX.Checked = False
        Else
            Me.dgvInventoryTotals.Columns("FOXNumberColumn").Visible = True
            chkShowFOX.Checked = True
        End If
    End Sub

    Private Sub HideQtyReceivedColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideQtyReceivedColumn.Click
        If HideQtyReceivedColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("TotalReceivedQuantityColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("TotalReceivedQuantityColumn").Visible = True
        End If
    End Sub

    Private Sub HideQtyShippedColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideQtyShippedColumn.Click
        If HideQtyShippedColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("TotalQuantityShippedColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("TotalQuantityShippedColumn").Visible = True
        End If
    End Sub

    Private Sub HideQtyAdjustedColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideQtyAdjustedColumn.Click
        If HideQtyAdjustedColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("AdjustmentQuantityColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("AdjustmentQuantityColumn").Visible = True
        End If
    End Sub

    Private Sub HideCustonerReturnColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideCustomerReturnColumn.Click
        If HideCustomerReturnColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("CustomerReturnQuantityColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("CustomerReturnQuantityColumn").Visible = True
        End If
    End Sub

    Private Sub HideVendorReturnColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideVendorReturnColumn.Click
        If HideVendorReturnColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("VendorReturnQuantityColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("VendorReturnQuantityColumn").Visible = True
        End If
    End Sub

    Private Sub HideProductionQtyColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideProductionQtyColumn.Click
        If HideProductionQtyColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("ProductionQuantityColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("ProductionQuantityColumn").Visible = True
        End If
    End Sub

    Private Sub HideWCProductionColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideWCProductionColumn.Click
        If HideWCProductionColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("WCProductionQuantityColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("WCProductionQuantityColumn").Visible = True
        End If
    End Sub

    Private Sub HideAssemblyColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideAssemblyColumn.Click
        If HideAssemblyColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("AssemblyBuildQuantityColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("AssemblyBuildQuantityColumn").Visible = True
        End If
    End Sub

    Private Sub HidePrefVendorColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HidePrefVendorColumn.Click
        If HidePrefVendorColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("PreferredVendorColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("PreferredVendorColumn").Visible = True
        End If
    End Sub

    Private Sub HideLeadTimeColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideLeadTimeColumn.Click
        If HideLeadTimeColumn.Checked = True Then
            Me.dgvInventoryTotals.Columns("LeadTimeColumn").Visible = False
        Else
            Me.dgvInventoryTotals.Columns("LeadTimeColumn").Visible = True
        End If
    End Sub

    Private Sub ShowAllColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllColumnsToolStripMenuItem.Click
        ShowColumns()
    End Sub

    Private Sub InactivityReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InactivityReportToolStripMenuItem.Click
        'Declare variable used only in this routine
        Dim ActivityQuantityOnHand As Double = 0
        Dim ActivityPartNumber As String = ""
        Dim ActivityDescription As String = ""
        Dim CheckActivity As Integer = 0
        Dim DayOfDate, MonthOfDate, YearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate As String
        Dim NewYearOfDate As Integer = 0
        Dim strNewYearOfDate As String = ""

        Dim CurrentDate As Date
        Dim ActivityDate As String = ""
        Dim MaxActivityDate As String = ""

        CurrentDate = Today()

        DayOfDate = CurrentDate.Day
        MonthOfDate = CurrentDate.Month
        YearOfDate = CurrentDate.Year

        NewYearOfDate = YearOfDate - 1
        strNewYearOfDate = CStr(NewYearOfDate)

        strDayOfDate = CStr(DayOfDate)
        strMonthOfDate = CStr(MonthOfDate)

        ActivityDate = strMonthOfDate + "/" + strDayOfDate + "/" + strNewYearOfDate

        If Me.dgvInventoryTotals.RowCount <> 0 Then
            'Delete from Temp Table
            Try
                cmd = New SqlCommand("DELETE FROM InventoryActivityTempLog WHERE DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Fail 
            End Try

            'Go thru datagrid, one part at a time, and determine if it had activity

            For Each row As DataGridViewRow In dgvInventoryTotals.Rows
                Try
                    ActivityPartNumber = row.Cells("ItemIDColumn").Value
                Catch ex As Exception
                    ActivityPartNumber = ""
                End Try
                Try
                    ActivityDescription = row.Cells("ShortDescriptionColumn").Value
                Catch ex As Exception
                    ActivityDescription = ""
                End Try
                Try
                    ActivityQuantityOnHand = row.Cells("QuantityOnHandColumn").Value
                Catch ex As Exception
                    ActivityQuantityOnHand = 0
                End Try

                'Check Activity
                Dim CheckActivityStatement As String = "SELECT COUNT(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionDate > = @TransactionDate"
                Dim CheckActivityCommand As New SqlCommand(CheckActivityStatement, con)
                CheckActivityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ActivityPartNumber
                CheckActivityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CheckActivityCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = ActivityDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckActivity = CInt(CheckActivityCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckActivity = 0
                End Try
                con.Close()

                If CheckActivity = 0 Then
                    'Get Max Activity Date
                    Dim MAXActivityStatement As String = "SELECT MAX(TransactionDate) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim MAXActivityCommand As New SqlCommand(MAXActivityStatement, con)
                    MAXActivityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ActivityPartNumber
                    MAXActivityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxActivityDate = CStr(MAXActivityCommand.ExecuteScalar)
                    Catch ex As Exception
                        MaxActivityDate = ""
                    End Try
                    con.Close()

                    'Get Average Cost
                    Dim AverageCost As Double = 0
                    Dim ExtendedCost As Double = 0

                    Dim AverageCostStatement As String = "SELECT AVG(ItemCost) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim AverageCostCommand As New SqlCommand(AverageCostStatement, con)
                    AverageCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ActivityPartNumber
                    AverageCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        AverageCost = CDbl(AverageCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        AverageCost = 0
                    End Try
                    con.Close()

                    ExtendedCost = AverageCost * ActivityQuantityOnHand
                    ExtendedCost = Math.Round(ExtendedCost, 2)

                    'Write to temp table
                    Try
                        cmd = New SqlCommand("INSERT INTO InventoryActivityTempLog (DivisionID, PartNumber, Description, QuantityOnHand, AverageCost, ExtendedCost, LastActivityDate, CurrentDate) values (@DivisionID, @PartNumber, @Description, @QuantityOnHand, @AverageCost, @ExtendedCost, @LastActivityDate, @CurrentDate)", con)

                        With cmd.Parameters
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@PartNumber", SqlDbType.VarChar).Value = ActivityPartNumber
                            .Add("@Description", SqlDbType.VarChar).Value = ActivityDescription
                            .Add("@QuantityOnHand", SqlDbType.VarChar).Value = ActivityQuantityOnHand
                            .Add("@AverageCost", SqlDbType.VarChar).Value = AverageCost
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                            .Add("@LastActivityDate", SqlDbType.VarChar).Value = MaxActivityDate
                            .Add("@CurrentDate", SqlDbType.VarChar).Value = CurrentDate
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        ExtendedCost = 0
                        AverageCost = 0
                    Catch ex As Exception
                        'Fail 
                    End Try
                Else
                    'Skip
                End If

                ActivityDescription = ""
                ActivityPartNumber = ""
                ActivityQuantityOnHand = 0
                MaxActivityDate = ""
                CheckActivity = 0
            Next

            'Bring up crystal report based on the temp table
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintInventoryActivity As New PrintInventoryActivity
                Dim result = NewPrintInventoryActivity.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub chkShowFOX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowFOX.CheckedChanged
        If (cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP") And chkShowFOX.Checked = True Then
            Me.dgvInventoryTotals.Columns("FOXNumberColumn").Visible = True
            HideFOXColumn.CheckState = CheckState.Unchecked
        ElseIf (cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP") And chkShowFOX.Checked = False Then
            Me.dgvInventoryTotals.Columns("FOXNumberColumn").Visible = False
            HideFOXColumn.CheckState = CheckState.Checked
        Else
            Me.dgvInventoryTotals.Columns("FOXNumberColumn").Visible = False
            HideFOXColumn.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub WCFerruleProductionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WCFerruleProductionToolStripMenuItem.Click
        'Clear data in datagrid
        ClearDataInDatagrid()

        'Filter Dataset
        Dim TWDDataset As New DataSet
        Dim TWDAdapter As New SqlDataAdapter

        cmd = New SqlCommand("SELECT * FROM ADMInventoryTotal WHERE DivisionID = 'TWD' AND ItemClass = 'FERRULE'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        TWDDataset = New DataSet()
        TWDAdapter.SelectCommand = cmd
        TWDAdapter.Fill(TWDDataset, "ADMInventoryTotal")
        dgvInventoryTotals.DataSource = TWDDataset.Tables("ADMInventoryTotal")
        con.Close()

        'Open Crystal Report








    End Sub

End Class