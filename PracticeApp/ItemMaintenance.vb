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
Imports System.Drawing.Printing
Public Class ItemMaintenance
    Inherits System.Windows.Forms.Form

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

    Dim FormName As String = "Item Maintenance"
    Dim TFJQuantityOnHand, ALBQuantityOnHand, TORQuantityOnHand, HOUQuantityOnHand, CGOQuantityOnHand, ATLQuantityOnHand, CHTQuantityOnHand, CBSQuantityOnHand, SLCQuantityOnHand, TFPQuantityOnHand, TWDQuantityOnHand, TFFQuantityOnHand, TFTQuantityOnHand, TWEQuantityOnHand, DENQuantityOnHand As Double
    Dim MonthlyAverageQuantity, MTDQuantity, YTDQuantity As Integer
    Dim MAXTransactionDate, MAXSalesDate, MAXPurchaseDate, FOXNumber, CheckItemClass As String
    Dim BinPreferenceCode, PartComments, PartLeadTime, VendorID, VendorName, AddAccessory, Carbon, SteelSize, RMID, BoxType, FluxLoadNumber, BluePrintNumber, LongDescription, ItemClass, PurchProdLineID, SalesProdLineID, OldPartNumber As String
    Dim StdBoxWeight, CheckAll, CheckItemOnSO, CheckItemOnPO, CheckItemOnTT, BoxCount, PalletCount, PalletPieces, MaximumStock, MinimumStock As Integer
    Dim OpenPOQuantity, NominalDiameter, NominalLength, PieceWeight, BoxWeight, PalletWeight As Double
    Dim CheckAdjQuantityPending, CheckPOQuantityOpen, CheckSOQuantityOpen, CheckQOH, AssemblyCost, SUMExtendedCost, TransactionCost, ComponentUnitCost, ComponentStandardCost, StandardCost, StandardPrice, StandardMargin, LastPurchaseCost, LastSalesPrice, AverageCost, BeginningBalance As Double
    Dim CreationDate, AssemblyDate As Date
    Dim LastLineNumber, NextLineNumber As Integer
    Dim DuplicatePartDescription As String = ""
    Dim CheckPPL, CheckSPL As Integer
    Dim CurrentDivision, DefaultSPL, DefaultPPL As String
    Dim NextPieceSold As Double = 0
    Dim SerialTextSearch As String = ""
    Dim LabelToolTip As New ToolTip
    Dim LabelToolTip2 As New ToolTip

    'Consignment Variables
    Dim LSCWOnHand, RCWOnHand, SRLOnHand, BCWOnHand, DCWOnHand, HCWOnHand, SCWOnHand, YCWOnHand, LCWOnHand, PCWOnHand As Integer
    Dim LSCWShipped, RCWShipped, SRLShipped, BCWShipped, DCWShipped, HCWShipped, SCWShipped, YCWShipped, LCWShipped, PCWShipped As Integer
    Dim LSCWBilled, RCWBilled, SRLBilled, BCWBilled, DCWBilled, HCWBilled, SCWBilled, YCWBilled, LCWBilled, PCWBilled As Integer
    Dim LSCWReturned, RCWReturned, SRLReturned, BCWReturned, DCWReturned, HCWReturned, SCWReturned, YCWReturned, LCWReturned, PCWReturned As Integer

    'Variables to calculate MTD and YTD Sales
    Dim YearDate, MonthDate, BeginDate, EndDate As Date
    Dim YearOfYear, MonthOfYear, Year, MaxDate As Integer
    Dim strMonthOfYear, strYear As String
    Dim MTDSales, YTDSales As Double

    'Assembly Variables
    Dim AssemblyComment, SerializedStatus As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    'Setup for Barcode Label
    Dim LabelFormat(42), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10, V11 As String
    Dim LabelLines As Integer

    Dim isLoaded As Boolean = False
    Dim needsSaved As Boolean = False
    Dim lastItem As String = ""
    Dim Suggest As SuggestDescriptionAPI

    Dim lstChangedFields As New usefulFunctions.ChangedFields()

    'Load Form Routines

    Private Sub ItemMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'Form Login
        FormLoginRoutine()

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.SalesProductLine' table. You can move, or remove it, as needed.
        Me.SalesProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.SalesProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PurchaseProductLine' table. You can move, or remove it, as needed.
        Me.PurchaseProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PurchaseProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        'Loads the different Safety Data Sheets into the combobox
        LoadSDS()

        'Load predefined security 
        usefulFunctions.LoadSecurity(Me)

        LoadCurrentDivision()

        'If Not EmployeeCompanyCode.Equals("TWD") And Not EmployeeCompanyCode.Equals("TST") And Not EmployeeCompanyCode.Equals("TFP") Then
        '    tabItemMaintenance.TabPages.RemoveAt(5)
        'End If

        isLoaded = True

        If EmployeeSecurityCode <> 1001 And EmployeeSecurityCode <> 1002 Then
            lblLastCost.Text = ""
            UpdateFOXToolStripMenuItem.Enabled = False
        Else
            UpdateFOXToolStripMenuItem.Enabled = True
        End If

        If GlobalItemListingPartNumber <> "" Then
            cboPartNumber.Text = GlobalItemListingPartNumber
        Else
            cboPartNumber.SelectedIndex = -1
        End If

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            Me.dgvSerialNumbers.Columns("TotalCost2Column").ReadOnly = False
            Me.dgvSerialNumbers.Columns("Status2Column").ReadOnly = False
            Me.dgvSerialNumbers.Columns("CustomerID2Column").ReadOnly = False
            Me.dgvSerialNumbers.Columns("BuildNumber2Column").ReadOnly = False
            Me.dgvSerialNumbers.Columns("TransactionNumber2Column").ReadOnly = False
            Me.dgvSerialNumbers.Columns("BatchNumber2Column").ReadOnly = False
            Me.dgvSerialNumbers.Columns("InvoiceNumber2Column").ReadOnly = False
            Me.dgvSerialNumbers.Columns("InvoiceDate2Column").ReadOnly = False
            Me.dgvSerialNumbers.Columns("ShipmentNumber2Column").ReadOnly = False
            Me.dgvSerialNumbers.Columns("ShipmentDate2Column").ReadOnly = False
        Else
            Me.dgvSerialNumbers.Columns("TotalCost2Column").ReadOnly = True
            Me.dgvSerialNumbers.Columns("Status2Column").ReadOnly = True
            Me.dgvSerialNumbers.Columns("CustomerID2Column").ReadOnly = True
            Me.dgvSerialNumbers.Columns("BuildNumber2Column").ReadOnly = True
            Me.dgvSerialNumbers.Columns("TransactionNumber2Column").ReadOnly = True
            Me.dgvSerialNumbers.Columns("BatchNumber2Column").ReadOnly = True
            Me.dgvSerialNumbers.Columns("InvoiceNumber2Column").ReadOnly = True
            Me.dgvSerialNumbers.Columns("InvoiceDate2Column").ReadOnly = True
            Me.dgvSerialNumbers.Columns("ShipmentNumber2Column").ReadOnly = True
            Me.dgvSerialNumbers.Columns("ShipmentDate2Column").ReadOnly = True
        End If

        LoadLabelToolTip()

        ''creates the call to Suggest API
        Suggest = New SuggestDescriptionAPI(cboPartDescription, lstPartDescriptionSuggest, cboPartNumber, ds8)
    End Sub

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), &HF060, 1)
            Case &HFFFFFFFF
        End Select
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

    Public Class FOXStep
        Public ProcessStep As Integer
        Public ProcessAddFG As String
        Public Sub New(ByVal procStep As Integer, ByVal AddFG As String)
            ProcessStep = procStep
            ProcessAddFG = AddFG
        End Sub
    End Class

    Private Sub ItemMaintenance_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Private Sub ItemMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalItemListingPartNumber = ""
    End Sub

    'Load dataset routines

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
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

    Public Sub ShowAssemblyComponents()
        cmd = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber ORDER BY ComponentLineNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "AssemblyLineTable")
        dgvAssemblyLineQuery.DataSource = ds4.Tables("AssemblyLineTable")
        cboDeleteComponent.DataSource = ds4.Tables("AssemblyLineTable")
        con.Close()

        Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
    End Sub

    Public Sub ShowAssemblyComponentsFromTWE()
        cmd = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber ORDER BY ComponentPartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "AssemblyLineTable")
        dgvAssemblyLineQuery.DataSource = ds4.Tables("AssemblyLineTable")
        cboDeleteComponent.DataSource = ds4.Tables("AssemblyLineTable")
        con.Close()

        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TWD" Then
            Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
            cmdUpdateCost.Enabled = True
            Me.dgvAssemblyLineQuery.ReadOnly = False
        Else
            Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = False
            cmdUpdateCost.Enabled = False
            Me.dgvAssemblyLineQuery.ReadOnly = True
        End If
    End Sub

    Public Sub LoadComponentPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemList")
        cboComponentPartNumber.DataSource = ds5.Tables("ItemList")
        con.Close()
        cboComponentPartNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowSerialNumbers()
        'Define serial text search field
        If txtTextSearch.Text = "" Then
            SerialTextSearch = ""
        Else
            SerialTextSearch = " AND SerialNumber LIKE '%" + txtTextSearch.Text + "%'"
        End If

        'Load all serial numbers if TWE, TWD, TST
        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TWE" Then
            cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE DivisionID <> @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber" + SerialTextSearch, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ZZZ"
            dgvSerialNumbers.Columns("TotalCost2Column").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber" + SerialTextSearch + " ORDER BY SerialNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            dgvSerialNumbers.Columns("TotalCost2Column").Visible = False
        End If

        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "AssemblySerialLog")
        dgvSerialNumbers.DataSource = ds6.Tables("AssemblySerialLog")
        con.Close()

        'Load Formatting
        LoadFormatting()
    End Sub

    Public Sub ShowSerialNumbersByDivision()
        'Load serial numbers by one division
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber ORDER BY SerialNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "AssemblySerialLog")
        dgvSerialNumbers.DataSource = ds6.Tables("AssemblySerialLog")
        con.Close()

        'Load Formatting
        LoadFormatting()
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "Vendor")
        cboVendorID.DataSource = ds7.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "ItemList")
        cboPartDescription.DataSource = ds8.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Private Sub LoadSDS()
        cmd = New SqlCommand("SELECT Name FROM SafetyDataSheets", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "SafetyDataSheets")
        cboSafetyDataSheet.DataSource = ds9.Tables("SafetyDataSheets")
        con.Close()
        cboSafetyDataSheet.SelectedIndex = -1
    End Sub

    Public Sub LoadAssemblySummary()
        cmd = New SqlCommand("SELECT * FROM AssemblyBuildSummaryFinal WHERE DivisionID = @DivisionID AND ComponentPartNumber = @ComponentPartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds10 = New DataSet()
        myAdapter10.SelectCommand = cmd
        myAdapter10.Fill(ds10, "AssemblyBuildSummaryFinal")
        dgvAssemblySummary.DataSource = ds10.Tables("AssemblyBuildSummaryFinal")
        con.Close()
    End Sub

    Public Sub LoadLotNumbers()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT * FROM LotNumber WHERE PartNumber = @PartNumber ORDER BY LotNumber DESC", con)
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds11 = New DataSet()
        myAdapter11.SelectCommand = cmd
        myAdapter11.Fill(ds11, "LotNumber")
        dgvLotNumbers.DataSource = ds11.Tables("LotNumber")
        con.Close()
    End Sub

    Public Sub LoadComponentPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds12 = New DataSet()
        myAdapter12.SelectCommand = cmd
        myAdapter12.Fill(ds12, "ItemList")
        cboComponentDescription.DataSource = ds12.Tables("ItemList")
        con.Close()
        cboComponentDescription.SelectedIndex = -1
    End Sub

    'Load form data routines

    Public Sub LoadFOXForPart()
        Dim LoadFOXNumber As Integer = 0

        Dim FOXNumberString As String = "SELECT MAX(FOXNumber) FROM FOXTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND Status <> 'INACTIVE'"
        Dim FOXNumberCommand As New SqlCommand(FOXNumberString, con)
        FOXNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        FOXNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadFOXNumber = CInt(FOXNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LoadFOXNumber = 0
        End Try
        con.Close()

        lblFOXNumber.Text = LoadFOXNumber
    End Sub

    Public Sub LoadNumberOfFoxes()
        'Check to see if there are duplicate foxes with the same part
        Dim CountFOXNumber As Integer = 0
        lblCountFox.Text = CountFOXNumber
    End Sub

    Public Sub LoadCompanyDefaults()
        CurrentDivision = cboDivisionID.Text

        Select Case CurrentDivision
            Case "ATL"
                DefaultPPL = "ATL-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-ATL"
            Case "CHT"
                DefaultPPL = "CHT-MANUFACTUREDPRODUCTS"
                DefaultSPL = "SPL-CHT"
            Case "CBS"
                DefaultPPL = "CBS-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-CBS"
            Case "CGO"
                DefaultPPL = "CGO-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-CGO"
            Case "TFF"
                DefaultPPL = "TFF-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-TFF"
            Case "TFJ"
                DefaultPPL = "TFJ-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-TFJ"
            Case "TFT"
                DefaultPPL = "TFT-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-TFT"
            Case "TWD"
                DefaultPPL = "TWD-MANUFACTUREDPRODUCTS"
                DefaultSPL = "SPL-TWD"
            Case "TFP"
                DefaultPPL = "TFP-MANUFACTUREDPRODUCTS"
                DefaultSPL = "SPL-TFP"
            Case "TWE"
                DefaultPPL = "TWE-MANUFACTUREDPRODUCTS"
                DefaultSPL = "SPL-TWE"
            Case "HOU"
                DefaultPPL = "HOU-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-HOU"
            Case "TOR"
                DefaultPPL = "TOR-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-TOR"
            Case "SLC"
                DefaultPPL = "SLC-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-SLC"
            Case "ALB"
                DefaultPPL = "ALB-PURCHASEPRODUCTS"
                DefaultSPL = "SPL-ALB"
            Case Else
                DefaultPPL = ""
                DefaultSPL = ""
        End Select
    End Sub

    Public Sub LoadDataFields()
        LoadCompanyDefaults()

        'Extract data from source table
        Dim GetItemDataString As String = "SELECT * FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetItemDataCommand As New SqlCommand(GetItemDataString, con)
        GetItemDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetItemDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetItemDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LongDescription")) Then
                LongDescription = ""
            Else
                LongDescription = reader.Item("LongDescription")
            End If
            If IsDBNull(reader.Item("ItemClass")) Then
                ItemClass = ""
            Else
                ItemClass = reader.Item("ItemClass")
            End If
            If IsDBNull(reader.Item("PurchProdLineID")) Then
                PurchProdLineID = DefaultPPL
            Else
                PurchProdLineID = reader.Item("PurchProdLineID")
            End If
            If IsDBNull(reader.Item("SalesProdLineID")) Then
                SalesProdLineID = DefaultSPL
            Else
                SalesProdLineID = reader.Item("SalesProdLineID")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                PieceWeight = 0
            Else
                PieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                BoxCount = 0
            Else
                BoxCount = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                BoxWeight = 0
            Else
                BoxWeight = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                PalletCount = 0
            Else
                PalletCount = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("PalletWeight")) Then
                PalletWeight = 0
            Else
                PalletWeight = reader.Item("PalletWeight")
            End If
            If IsDBNull(reader.Item("PalletPieces")) Then
                PalletPieces = 0
            Else
                PalletPieces = reader.Item("PalletPieces")
            End If
            If IsDBNull(reader.Item("StandardCost")) Then
                StandardCost = 0
            Else
                StandardCost = reader.Item("StandardCost")
            End If
            If IsDBNull(reader.Item("StandardPrice")) Then
                StandardPrice = 0
            Else
                StandardPrice = reader.Item("StandardPrice")
            End If
            If IsDBNull(reader.Item("OldPartNumber")) Then
                OldPartNumber = ""
            Else
                OldPartNumber = reader.Item("OldPartNumber")
            End If
            If IsDBNull(reader.Item("MinimumStock")) Then
                MinimumStock = 0
            Else
                MinimumStock = reader.Item("MinimumStock")
            End If
            If IsDBNull(reader.Item("MaximumStock")) Then
                MaximumStock = 0
            Else
                MaximumStock = reader.Item("MaximumStock")
            End If
            If IsDBNull(reader.Item("CreationDate")) Then
                CreationDate = dtpItemCreationDate.Value
            Else
                CreationDate = reader.Item("CreationDate")
            End If
            If IsDBNull(reader.Item("BeginningBalance")) Then
                BeginningBalance = 0
            Else
                BeginningBalance = reader.Item("BeginningBalance")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                FOXNumber = 0
            Else
                FOXNumber = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("NominalDiameter")) Then
                NominalDiameter = 0
            Else
                NominalDiameter = reader.Item("NominalDiameter")
            End If
            If IsDBNull(reader.Item("NominalLength")) Then
                NominalLength = 0
            Else
                NominalLength = reader.Item("NominalLength")
            End If
            If IsDBNull(reader.Item("AddAccessory")) Then
                AddAccessory = "NO"
            Else
                AddAccessory = reader.Item("AddAccessory")
            End If
            If IsDBNull(reader.Item("BoxWeightSaved")) Then
                StdBoxWeight = 0
            Else
                StdBoxWeight = reader.Item("BoxWeightSaved")
            End If
            If IsDBNull(reader.Item("PreferredVendor")) Then
                VendorID = ""
            Else
                VendorID = reader.Item("PreferredVendor")
            End If
            If IsDBNull(reader.Item("SafetyDataSheet")) Then
                cboSafetyDataSheet.Text = ""
            Else
                cboSafetyDataSheet.Text = reader.Item("SafetyDataSheet")
            End If
            If IsDBNull(reader.Item("Comments")) Then
                PartComments = ""
            Else
                PartComments = reader.Item("Comments")
            End If
            If IsDBNull(reader.Item("LeadTime")) Then
                PartLeadTime = ""
            Else
                PartLeadTime = reader.Item("LeadTime")
            End If
            If IsDBNull(reader.Item("BinPreference")) Then
                BinPreferenceCode = ""
            Else
                BinPreferenceCode = reader.Item("BinPreference")
            End If
        Else
            LongDescription = ""
            ItemClass = ""
            PurchProdLineID = ""
            SalesProdLineID = ""
            PieceWeight = 0
            BoxCount = 0
            BoxWeight = 0
            PalletCount = 0
            PalletWeight = 0
            PalletPieces = 0
            StandardCost = 0
            StandardPrice = 0
            OldPartNumber = ""
            MinimumStock = 0
            MaximumStock = 0
            CreationDate = dtpItemCreationDate.Value
            BeginningBalance = 0
            FOXNumber = 0
            NominalDiameter = 0
            NominalLength = 0
            AddAccessory = ""
            VendorID = ""
            cboSafetyDataSheet.Text = ""
            StdBoxWeight = 0
            PartLeadTime = ""
            PartComments = ""
            BinPreferenceCode = ""
        End If
        reader.Close()
        con.Close()

        If VendorID = "AMERICAN" Then
            chkAmerican.Checked = True
            chkCanadian.Checked = False
        ElseIf VendorID = "CANADIAN" Then
            chkCanadian.Checked = True
            chkAmerican.Checked = False
        Else
            chkAmerican.Checked = False
            chkCanadian.Checked = False
        End If

        txtLongDescription.Text = LongDescription
        txtMaximumStock.Text = MaximumStock
        txtMinimumStock.Text = MinimumStock
        lblCPMinStock.Text = MinimumStock
        lblCPMaxStock.Text = MaximumStock
        txtOldPartNumber.Text = OldPartNumber
        txtPalletCount.Text = PalletCount
        txtPieceWeight.Text = PieceWeight
        txtStandardUnitCost.Text = StandardCost
        txtStandardUnitPrice.Text = StandardPrice
        txtBoxCount.Text = BoxCount
        txtStdBoxWeight.Text = StdBoxWeight
        txtItemComments.Text = PartComments
        txtLeadTime.Text = PartLeadTime
        txtItemListFOX.Text = FOXNumber
        txtBinPreference.Text = BinPreferenceCode

        cboPurchaseProductID.Text = PurchProdLineID
        cboSalesProductLine.Text = SalesProdLineID
        cboItemClass.Text = ItemClass

        lblBoxCount.Text = FormatNumber(BoxCount, 0)
        lblBoxWeight.Text = FormatNumber(BoxWeight, 1)
        lblPalletCount.Text = FormatNumber(PalletCount, 0)
        lblPalletPieceCount.Text = FormatNumber(PalletPieces, 0)
        lblPalletWeight.Text = FormatNumber(PalletWeight, 2)
        lblPieceWeight.Text = FormatNumber(PieceWeight, 4)

        If cboPartNumber.SelectedIndex = -1 Then
            cboItemClass.Enabled = True
        Else
            If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                cboItemClass.Enabled = True
            Else
                cboItemClass.Enabled = False
            End If
        End If

        If cboItemClass.Text = "DEACTIVATED-PART" Then
            chkDeactivatePart.Checked = True
        ElseIf cboItemClass.Text = "TW WELD STUD W/O LOT" Then
            chkNonLotNumber.Checked = True
        Else
            chkDeactivatePart.Checked = False
        End If

        txtNominalDiameter.Text = NominalDiameter
        txtNominalLength.Text = NominalLength
        cboAddAccessories.Text = AddAccessory
        dtpItemCreationDate.Text = CreationDate
        cboVendorID.Text = VendorID

        If PurchProdLineID = "ASSEMBLY" Then
            LoadAssemblyData()
        Else
            dtpAssemblyDate.Text = ""
            txtAssemblyComment.Clear()
            chkSerializedAssembly.Checked = False
        End If
    End Sub

    Public Sub LoadQuantityPending()
        Dim QuantityPending As Double = 0
        Dim CurrentQOH As Double = 0
        Dim QuantityOpen As Double = 0

        'Load quantity pending (all opem lines)
        Dim QuantityOpenString As String = "SELECT SUM(QuantityOpen) FROM SalesOrderQuantityStatus WHERE ItemID = @ItemID AND DivisionKey = @DivisionKey AND LineStatus <> @LineStatus AND LineStatus <> @LineStatus2"
        Dim QuantityOpenCommand As New SqlCommand(QuantityOpenString, con)
        QuantityOpenCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        QuantityOpenCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        QuantityOpenCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
        QuantityOpenCommand.Parameters.Add("@LineStatus2", SqlDbType.VarChar).Value = "QUOTE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantityOpen = CDbl(QuantityOpenCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityOpen = 0
        End Try
        con.Close()

        lblQuantityOpen.Text = FormatNumber(QuantityOpen, 0)

        'Load quantity pending (pending shipment lines)
        Dim QuantityPendingString As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND LineStatus = @LineStatus"
        Dim QuantityPendingCommand As New SqlCommand(QuantityPendingString, con)
        QuantityPendingCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        QuantityPendingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        QuantityPendingCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantityPending = CDbl(QuantityPendingCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityPending = 0
        End Try
        con.Close()

        lblQuantityCommitted.Text = FormatNumber(QuantityPending, 0)

        'Load PO Quantity Open
        Dim OpenPOQuantityString As String = "SELECT SUM(POQuantityOpen) FROM PurchaseOrderQuantityStatus WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim OpenPOQuantityCommand As New SqlCommand(OpenPOQuantityString, con)
        OpenPOQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        OpenPOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OpenPOQuantity = CDbl(OpenPOQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            OpenPOQuantity = 0
        End Try
        con.Close()

        lblOpenPOQuantity.Text = FormatNumber(OpenPOQuantity, 0)

        'Load QOH for current division
        Dim CurrentQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CurrentQOHCommand As New SqlCommand(CurrentQOHString, con)
        CurrentQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CurrentQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CurrentQOH = CDbl(CurrentQOHCommand.ExecuteScalar)
        Catch ex As Exception
            CurrentQOH = 0
        End Try
        con.Close()

        lblQuantityOnHand.Text = FormatNumber(CurrentQOH, 0)
        lblCPQuantityOpen.Text = FormatNumber(OpenPOQuantity, 0)
        lblCPQOH.Text = FormatNumber(CurrentQOH, 0)
    End Sub

    Public Sub LoadQuantityOnHand()
        ATLQuantityOnHand = 0
        CBSQuantityOnHand = 0
        CHTQuantityOnHand = 0
        TWDQuantityOnHand = 0
        TFFQuantityOnHand = 0
        ALBQuantityOnHand = 0
        TFTQuantityOnHand = 0
        TFPQuantityOnHand = 0
        TWEQuantityOnHand = 0
        SLCQuantityOnHand = 0
        CGOQuantityOnHand = 0
        HOUQuantityOnHand = 0
        TORQuantityOnHand = 0
        DENQuantityOnHand = 0
        ALBQuantityOnHand = 0
        TFJQuantityOnHand = 0

        cmd = New SqlCommand("SELECT QuantityOnHand, DivisionID FROM ADMInventoryTotal WHERE ItemID = @ItemID and DivisionID <> 'TST' and DivisionID <> 'BCW' and DivisionID <> 'DCW' and DivisionID <> 'HCW' and DivisionID <> 'LCW' and DivisionID <> 'PCW' and DivisionID <> 'SCW' and DivisionID <> 'YCW'", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                Select Case reader.Item("DivisionID")
                    Case "ATL"
                        ATLQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "CBS"
                        CBSQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "CGO"
                        CGOQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "CHT"
                        CHTQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "HOU"
                        HOUQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "TFF"
                        TFFQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "TFP"
                        TFPQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "TWD"
                        TWDQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "TOR"
                        TORQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "SLC"
                        SLCQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "DEN"
                        DENQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "TFT"
                        TFTQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "TWE"
                        TWEQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "ALB"
                        ALBQuantityOnHand = reader.Item("QuantityOnHand")
                    Case "TFJ"
                        TFJQuantityOnHand = reader.Item("QuantityOnHand")
                End Select
            End While
        End If
        reader.Close()
        con.Close()

        lblAtlantInventory.Text = FormatNumber(ATLQuantityOnHand, 1)
        lblLasVegasInventory.Text = FormatNumber(CBSQuantityOnHand, 1)
        lblWeldingCeramicsInventory.Text = FormatNumber(CHTQuantityOnHand, 1)
        lblTWDInventory.Text = FormatNumber(TWDQuantityOnHand, 1)
        lblVancouverInventory.Text = FormatNumber(TFFQuantityOnHand, 1)
        lblTexasInventory.Text = FormatNumber(TFTQuantityOnHand, 1)
        lblTFPInventory.Text = FormatNumber(TFPQuantityOnHand, 1)
        lblTWEInventory.Text = FormatNumber(TWEQuantityOnHand, 1)
        lblSaltLakeInventory.Text = FormatNumber(SLCQuantityOnHand, 1)
        lblChicagoInventory.Text = FormatNumber(CGOQuantityOnHand, 1)
        lblHoustonQOH.Text = FormatNumber(HOUQuantityOnHand, 1)
        lblTorontoQOH.Text = FormatNumber(TORQuantityOnHand, 1)
        lblDenverQOH.Text = FormatNumber(DENQuantityOnHand, 1)
        lblTexasInventory.Text = FormatNumber(TFTQuantityOnHand, 1)
        lblAlbertaQOH.Text = FormatNumber(ALBQuantityOnHand, 1)
        lblJerseyQOH.Text = FormatNumber(TFJQuantityOnHand, 1)
    End Sub

    Public Sub LoadAssemblyData()
        Dim AssemblyDateStatement As String = "SELECT AssemblyDate, Comment, SerializedStatus FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
        Dim AssemblyDateCommand As New SqlCommand(AssemblyDateStatement, con)
        AssemblyDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AssemblyDateCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = AssemblyDateCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("AssemblyDate")) Then
                AssemblyDate = dtpAssemblyDate.Value
            Else
                AssemblyDate = reader.Item("AssemblyDate")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                AssemblyComment = ""
            Else
                AssemblyComment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("SerializedStatus")) Then
                SerializedStatus = "NO"
            Else
                SerializedStatus = reader.Item("SerializedStatus")
            End If
        Else
            AssemblyDate = dtpAssemblyDate.Value
            AssemblyComment = ""
            SerializedStatus = "NO"
        End If
        reader.Close()
        con.Close()

        dtpAssemblyDate.Text = AssemblyDate
        txtAssemblyComment.Text = AssemblyComment

        If SerializedStatus = "YES" Then
            chkSerializedAssembly.Checked = True
        Else
            chkSerializedAssembly.Checked = False
        End If
    End Sub

    Public Sub LoadAssemblyDataFromTWE()
        Dim AssemblyDateStatement As String = "SELECT AssemblyDate, Comment, SerializedStatus FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
        Dim AssemblyDateCommand As New SqlCommand(AssemblyDateStatement, con)
        AssemblyDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
        AssemblyDateCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = AssemblyDateCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("AssemblyDate")) Then
                AssemblyDate = dtpAssemblyDate.Value
            Else
                AssemblyDate = reader.Item("AssemblyDate")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                AssemblyComment = ""
            Else
                AssemblyComment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("SerializedStatus")) Then
                SerializedStatus = "NO"
            Else
                SerializedStatus = reader.Item("SerializedStatus")
            End If
        Else
            AssemblyDate = dtpAssemblyDate.Value
            AssemblyComment = ""
            SerializedStatus = "NO"
        End If
        reader.Close()
        con.Close()

        dtpAssemblyDate.Text = AssemblyDate
        txtAssemblyComment.Text = AssemblyComment

        If SerializedStatus = "YES" Then
            chkSerializedAssembly.Checked = True
        Else
            chkSerializedAssembly.Checked = False
        End If
    End Sub

    Public Sub LoadAssemblyComponentCost()
        'Get FIFO Cost of component
        '******************************************************************************************************************************************
        'Determine FIFO Cost on Part Number to remove from Inventory
        Dim TotalQuantityShipped As Integer = 0
        Dim TotalQuantityAssembled As Integer = 0
        '******************************************************************************************************************************************
        'Determine Total Quantity Shipped
        Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
        TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPartNumber.Text
        TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShipped = CInt(TotalQuantityShippedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantityShipped = 1
        End Try
        con.Close()

        'Determine Total Quantity Assembled
        Dim TotalQuantityAssembledStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber"
        Dim TotalQuantityAssembledCommand As New SqlCommand(TotalQuantityAssembledStatement, con)
        TotalQuantityAssembledCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboComponentPartNumber.Text
        TotalQuantityAssembledCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityAssembled = CInt(TotalQuantityAssembledCommand.ExecuteScalar)
            TotalQuantityAssembled = TotalQuantityAssembled * -1
        Catch ex As Exception
            TotalQuantityAssembled = 0
        End Try
        con.Close()

        TotalQuantityShipped = TotalQuantityShipped + TotalQuantityAssembled
        '******************************************************************************************************************************************
        'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
        Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
        Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
        ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPartNumber.Text
        ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ComponentUnitCost = CDbl(ItemCostCommand.ExecuteScalar)
        Catch ex As Exception
            ComponentUnitCost = 0
        End Try
        con.Close()

        'Get Last Transaction Cost if FIFO Cost is Zero
        If ComponentUnitCost = 0 Then
            Dim MAXDate As Integer = 0

            Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPartNumber.Text
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MAXDate = 0
            End Try
            con.Close()

            Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
            Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
            TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPartNumber.Text
            TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
            Catch ex As Exception
                TransactionCost = 0
            End Try
            con.Close()

            ComponentUnitCost = TransactionCost
        Else
            'Do nothing
        End If

        'Get Stand Cost if FIFO Cost is Zero
        If ComponentUnitCost = 0 Then
            Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
            StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboComponentPartNumber.Text
            StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ComponentStandardCost = CDbl(StandardCostCommand.ExecuteScalar)
            Catch ex As Exception
                ComponentStandardCost = 0
            End Try
            con.Close()

            ComponentUnitCost = ComponentStandardCost
        Else
            'Do nothing
        End If

        ComponentUnitCost = Math.Round(ComponentUnitCost, 4)

        txtComponentCost.Text = ComponentUnitCost
    End Sub

    Public Sub LoadAssemblyTrackingData()
        'Set up month parameters to load month data
        Dim JanuaryUsage, FebruaryUsage, MarchUsage, AprilUsage, MayUsage, JuneUsage, JulyUsage, AugustUsage, SeptemberUsage, OctoberUsage, NovemberUsage, DecemberUsage As Double
        Dim JanBegin, JanEnd, FebBegin, FebEnd, MarBegin, MarEnd, AprBegin, AprEnd, MayBegin, MayEnd, JunBegin, JunEnd, JulBegin, JulEnd, AugBegin, AugEnd, SepBegin, SepEnd, OctBegin, OctEnd, NovBegin, NovEnd, DecBegin, DecEnd As String
        Dim Counter2 As Integer = 1

        For i As Integer = 1 To 12
            YearDate = Today()
            YearOfYear = YearDate.Year
            MonthOfYear = YearDate.Month

            If Counter2 <= MonthOfYear Then
                strYear = CStr(YearOfYear)
            Else
                YearOfYear = YearOfYear - 1
                strYear = CStr(YearOfYear)
            End If

            Select Case Counter2
                Case 1
                    JanBegin = "01/01/" + strYear
                    JanEnd = "01/31/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = JanBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = JanEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        JanuaryUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        JanuaryUsage = JanuaryUsage * -1
                    Catch ex As Exception
                        JanuaryUsage = 0
                    End Try
                    con.Close()

                    lblYear1.Text = strYear
                Case 2
                    FebBegin = "02/01/" + strYear
                    FebEnd = "02/28/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = FebBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = FebEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        FebruaryUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        FebruaryUsage = FebruaryUsage * -1
                    Catch ex As Exception
                        FebruaryUsage = 0
                    End Try
                    con.Close()

                    lblYear2.Text = strYear
                Case 3
                    MarBegin = "03/01/" + strYear
                    MarEnd = "03/31/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = MarBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = MarEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MarchUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        MarchUsage = MarchUsage * -1
                    Catch ex As Exception
                        MarchUsage = 0
                    End Try
                    con.Close()

                    lblYear3.Text = strYear
                Case 4
                    AprBegin = "04/01/" + strYear
                    AprEnd = "04/30/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = AprBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = AprEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        AprilUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        AprilUsage = AprilUsage * -1
                    Catch ex As Exception
                        AprilUsage = 0
                    End Try
                    con.Close()

                    lblYear4.Text = strYear
                Case 5
                    MayBegin = "05/01/" + strYear
                    MayEnd = "05/31/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = MayBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = MayEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MayUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        MayUsage = MayUsage * -1
                    Catch ex As Exception
                        MayUsage = 0
                    End Try
                    con.Close()

                    lblYear5.Text = strYear
                Case 6
                    JunBegin = "06/01/" + strYear
                    JunEnd = "06/30/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = JunBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = JunEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        JuneUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        JuneUsage = JuneUsage * -1
                    Catch ex As Exception
                        JuneUsage = 0
                    End Try
                    con.Close()

                    lblYear6.Text = strYear
                Case 7
                    JulBegin = "07/01/" + strYear
                    JulEnd = "07/31/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = JulBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = JulEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        JulyUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        JulyUsage = JulyUsage * -1
                    Catch ex As Exception
                        JulyUsage = 0
                    End Try
                    con.Close()

                    lblYear7.Text = strYear
                Case 8
                    AugBegin = "08/01/" + strYear
                    AugEnd = "08/31/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = AugBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = AugEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        AugustUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        AugustUsage = AugustUsage * -1
                    Catch ex As Exception
                        AugustUsage = 0
                    End Try
                    con.Close()

                    lblYear8.Text = strYear
                Case 9
                    SepBegin = "09/01/" + strYear
                    SepEnd = "09/30/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = SepBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = SepEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SeptemberUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        SeptemberUsage = SeptemberUsage * -1
                    Catch ex As Exception
                        SeptemberUsage = 0
                    End Try
                    con.Close()

                    lblYear9.Text = strYear
                Case 10
                    OctBegin = "10/01/" + strYear
                    OctEnd = "10/31/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = OctBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = OctEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OctoberUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        OctoberUsage = OctoberUsage * -1
                    Catch ex As Exception
                        OctoberUsage = 0
                    End Try
                    con.Close()

                    lblYear10.Text = strYear
                Case 11
                    NovBegin = "11/01/" + strYear
                    NovEnd = "11/30/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NovBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = NovEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        NovemberUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        NovemberUsage = NovemberUsage * -1
                    Catch ex As Exception
                        NovemberUsage = 0
                    End Try
                    con.Close()

                    lblYear11.Text = strYear
                Case 12
                    DecBegin = "12/01/" + strYear
                    DecEnd = "12/31/" + strYear

                    Dim GetMonthDataString As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
                    Dim GetMonthDataCommand As New SqlCommand(GetMonthDataString, con)
                    GetMonthDataCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    GetMonthDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMonthDataCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = DecBegin
                    GetMonthDataCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = DecEnd

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        DecemberUsage = CDbl(GetMonthDataCommand.ExecuteScalar)
                        DecemberUsage = DecemberUsage * -1
                    Catch ex As Exception
                        DecemberUsage = 0
                    End Try
                    con.Close()

                    lblYear12.Text = strYear
            End Select

            strYear = ""
            Counter2 = Counter2 + 1
        Next i

        lblCPJan.Text = FormatNumber(JanuaryUsage, 2)
        lblCPFeb.Text = FormatNumber(FebruaryUsage, 2)
        lblCPMar.Text = FormatNumber(MarchUsage, 2)
        lblCPApr.Text = FormatNumber(AprilUsage, 2)
        lblCPMay.Text = FormatNumber(MayUsage, 2)
        lblCPJun.Text = FormatNumber(JuneUsage, 2)
        lblCPJul.Text = FormatNumber(JulyUsage, 2)
        lblCPAug.Text = FormatNumber(AugustUsage, 2)
        lblCPSep.Text = FormatNumber(SeptemberUsage, 2)
        lblCPOct.Text = FormatNumber(OctoberUsage, 2)
        lblCPNov.Text = FormatNumber(NovemberUsage, 2)
        lblCPDec.Text = FormatNumber(DecemberUsage, 2)
    End Sub

    Public Sub LoadLastPurchaseCost()
        'Load values into Cost Field
        Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxDate = CInt(MAXDateCommand.ExecuteScalar)
        Catch ex As Exception
            MaxDate = 0
        End Try
        con.Close()

        Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
        Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
        Catch ex As Exception
            LastPurchaseCost = 0
        End Try
        con.Close()

        lblLastCost.Text = FormatCurrency(LastPurchaseCost, 4)
    End Sub

    Public Sub LoadManufacturedCost()
        'Load values into Cost Field
        Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND Status = @Status"
        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        MAXDateCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "TIME SLIP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxDate = CInt(MAXDateCommand.ExecuteScalar)
        Catch ex As Exception
            MaxDate = 0
        End Try
        con.Close()

        Dim LastPriceStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
        Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastPriceCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
        Catch ex As Exception
            LastPurchaseCost = 0
        End Try
        con.Close()

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            lblLastCost.Text = FormatCurrency(LastPurchaseCost, 4)
        Else
            lblLastCost.Text = ""
        End If
    End Sub

    Public Sub LoadLastSalePrice()
        'Determine if Item Class is subject to price increase
        Dim CheckItemClass As String = cboItemClass.Text
        Dim PriceIncreaseItem As String = ""

        Select Case CheckItemClass
            Case "TW CA", "TW SC", "TW DB", "TW DS", "TW TT", "TW TP", "TW CD", "TW NT", "TW CS", "TW PS", "TW CH", "TW IT", "TW SK", "TW SH", "TW TR", "TW TF", "TW RA", "TW KO"
                PriceIncreaseItem = "5PERCENT"
            Case "WASHERS", "U BOLTS", "TURNBUCKLES", "THREADED ROD", "TC BOLTS", "SOCKET SCREW", "SES", "SCREWS", "RIVET", "PUNCHES", "PINS", "MISC BOLTS", "METRIC", "LOCK NUTS", "LAG BOLTS", "JAM NUTS", "HEX NUTS", "HEX BOLTS", "EYE BOLTS", "EXP ANCHOR", "EPOXY", "DIES", "DES", "CUTTERS", "CPG NUTS", "CLEVIS", "CARR BOLTS", "BITS", "ANCHOR BOLTS"
                PriceIncreaseItem = "12PERCENT"
            Case "WC FERRULES", "WC WELD TILES"
                PriceIncreaseItem = "7PERCENT"
            Case "TW WELD PROD", "TWE ASSEMBLIES", "TWE STUD EQUIP COMP", "TWE CD COMPONENTS"
                PriceIncreaseItem = "5PERCENT"
            Case Else
                PriceIncreaseItem = "NO"
        End Select

        'Load values into Price Field
        Dim GetYearPricingDate As Date
        Dim UpdatedLastSalesPrice As Double = 0

        If cboDivisionID.Text = "SLC" Then
            Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()
        Else
            Dim MAXDateStatement As String = "SELECT MAX(InvoiceHeaderKey) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT InvoiceDate FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetYearPricingDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()
        End If

        If GetYearPricingDate < GlobalTWDPriceChangeDate And cboDivisionID.Text = "TWD" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWD
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalTWDPriceChangeDate And cboDivisionID.Text = "SLC" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWD
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalSLCPriceChangeDate And cboDivisionID.Text = "SLC" And PriceIncreaseItem = "12PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierSLC
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalCHTPriceChangeDate And cboDivisionID.Text = "CHT" And PriceIncreaseItem = "7PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierCHT
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalTWEPriceChangeDate And cboDivisionID.Text = "TWE" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWE
            lblUpdatedPrice.Visible = True
        Else
            UpdatedLastSalesPrice = LastSalesPrice
            lblUpdatedPrice.Visible = False
        End If

        lblLastPrice.Text = FormatCurrency(UpdatedLastSalesPrice, 4)
    End Sub

    Public Sub LoadLastSalesPriceTWDRevised()
        'Declare variables
        Dim MaxDate As Integer = 0
        Dim GetItemClass As String = ""
        Dim GetSPL As String = ""
        Dim GetYearPricingDate As Date
        Dim LastSalesPrice As Double = 0
        Dim AdjustedLastSalesPrice As Double = 0
        Dim GetBracketNumber As Integer = 0
        Dim GetPriceAdjustmentPercentage1 As Double = 0
        Dim GetPriceAdjustmentPercentage2 As Double = 0
        Dim GetPriceAdjustmentPercentage3 As Double = 0
        Dim GetPriceAdjustmentPercentage4 As Double = 0
        Dim GetPriceAdjustmentPercentage5 As Double = 0
        Dim GetPriceAdjustmentPercentage6 As Double = 0
        '***************************************************************************************
        'Get Item Class of part (as well as if it is stainless)
        Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            GetItemClass = ""
        End Try
        con.Close()

        Dim GetSPLStatement As String = "SELECT SalesProdLineID FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim GetSPLCommand As New SqlCommand(GetSPLStatement, con)
        GetSPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetSPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSPL = CStr(GetSPLCommand.ExecuteScalar)
        Catch ex As Exception
            GetSPL = ""
        End Try
        con.Close()
        '***************************************************************************************
        'Get last sales date from Sales Order line table
        Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxDate = CInt(MAXDateCommand.ExecuteScalar)
        Catch ex As Exception
            MaxDate = 0
        End Try
        con.Close()

        Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
        Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
        GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetYearPricingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
        Catch ex As Exception
            GetYearPricingDate = Today()
        End Try
        con.Close()

        Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
        Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
        Catch ex As Exception
            LastSalesPrice = 0
        End Try
        con.Close()

        'If price date is beyond the bracket, exit routine

        '**************************************************
        'Change this date to start of the new period!!!!!
        '**************************************************

        If GetYearPricingDate > "4/30/2022" Then
            'Pricing is current
            LastSalesPrice = Math.Round(LastSalesPrice, 4)
            lblLastPrice.Text = LastSalesPrice
            lblUpdatedPrice.Visible = False

            Exit Sub
        Else
            'Determine the Price Increase Bracket it is in
            Dim GetBracketNumberStatement As String = "SELECT CostTierNumber FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND @PriceDate BETWEEN BeginDate AND EndDate"
            Dim GetBracketNumberCommand As New SqlCommand(GetBracketNumberStatement, con)
            GetBracketNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetBracketNumberCommand.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
            GetBracketNumberCommand.Parameters.Add("@PriceDate", SqlDbType.VarChar).Value = GetYearPricingDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetBracketNumber = CInt(GetBracketNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetBracketNumber = 0
            End Try
            con.Close()

            Select Case GetBracketNumber
                Case 1
                    'Increase price for 6 brackets (plus stainless)

                    'Get % for first bracket (Tier 1)
                    Dim GetPercentage1Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage1Command As New SqlCommand(GetPercentage1Statement, con)
                    GetPercentage1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage1Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage1Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 1

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage1 = CDbl(GetPercentage1Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage1 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage1)

                    'Get % for second bracket (Tier 2)
                    Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                    GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage2 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                    'Get % for third bracket (Tier 3)
                    Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                    GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage3 = 0
                    End Try
                    con.Close()

                    If GetSPL = "STAINLESS" Then
                        GetPriceAdjustmentPercentage3 = 0.05
                    End If

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                    'Get % for fourth bracket (Tier 4)
                    Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                    GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage4 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                    'Get % for fifth bracket (Tier 5)
                    Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage5 = 0
                    End Try
                    con.Close()

                    If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                        GetPriceAdjustmentPercentage5 = 0.15
                    ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                        GetPriceAdjustmentPercentage5 = 0.13
                    Else
                        'Do nothing
                    End If

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                    'Get % for SIXTH bracket (Tier 6)
                    Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage6 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                    'Pricing is adjusted
                    AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                    lblLastPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                    lblUpdatedPrice.Visible = True
                Case 2
                    'Increase price for 5 brackets (plus stainless)

                    'Get % for first bracket (Tier 2)
                    Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                    GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage2 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                    'Get % for second bracket (Tier 3)
                    Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                    GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage3 = 0
                    End Try
                    con.Close()

                    If GetSPL = "STAINLESS" Then
                        GetPriceAdjustmentPercentage3 = 0.05
                    End If

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                    'Get % for third bracket (Tier 4)
                    Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                    GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage4 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                    'Get % for fourth bracket (Tier 5)
                    Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage5 = 0
                    End Try
                    con.Close()

                    If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                        GetPriceAdjustmentPercentage5 = 0.15
                    ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                        GetPriceAdjustmentPercentage5 = 0.13
                    Else
                        'Do nothing
                    End If

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                    'Get % for SIXTH bracket (Tier 6)
                    Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage6 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                    'Pricing is adjusted
                    AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                    lblLastPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                    lblUpdatedPrice.Visible = True
                Case 3
                    'Increase price for FOUR brackets (plus stainless)

                    'Get % for first bracket (Tier 3)
                    Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                    GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage3 = 0
                    End Try
                    con.Close()

                    If GetSPL = "STAINLESS" Then
                        GetPriceAdjustmentPercentage3 = 0.05
                    End If

                    AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                    'Get % for second bracket (Tier 4)
                    Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                    GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage4 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                    'Get % for third bracket (Tier 5)
                    Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage5 = 0
                    End Try
                    con.Close()

                    If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                        GetPriceAdjustmentPercentage5 = 0.15
                    ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                        GetPriceAdjustmentPercentage5 = 0.13
                    Else
                        'Do nothing
                    End If

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                    'Get % for SIXTH bracket (Tier 6)
                    Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage6 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                    'Pricing is adjusted
                    AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                    lblLastPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                    lblUpdatedPrice.Visible = True
                Case 4
                    'Increase price for THREE brackets (Tier 4) plus stainless

                    'Get % for first bracket (Tier 4)
                    Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                    GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage4 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                    'Get % for second bracket (Tier 5)
                    Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage5 = 0
                    End Try
                    con.Close()

                    If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                        GetPriceAdjustmentPercentage5 = 0.15
                    ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                        GetPriceAdjustmentPercentage5 = 0.13
                    Else
                        'Do nothing
                    End If

                    AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                    'Get % for SIXTH bracket (Tier 6)
                    Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage6 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                    'Pricing is adjusted
                    AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                    lblLastPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                    lblUpdatedPrice.Visible = True
                Case 5
                    'Increase price for 2 bracketS (Tier 5) plus stainless

                    'Get % for first bracket (Tier 5)
                    Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage5 = 0
                    End Try
                    con.Close()

                    If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                        GetPriceAdjustmentPercentage5 = 0.15
                    ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                        GetPriceAdjustmentPercentage5 = 0.13
                    Else
                        'Do nothing
                    End If

                    AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                    'Get % for SIXTH bracket (Tier 6)
                    Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage6 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                    'Pricing is adjusted
                    AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                    lblLastPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                    lblUpdatedPrice.Visible = True
                Case 6
                    'Increase price for 1 bracket (Tier 6)

                    'Get % for SIXTH bracket (Tier 6)
                    Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                    GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPriceAdjustmentPercentage6 = 0
                    End Try
                    con.Close()

                    AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                    'Pricing is adjusted
                    AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                    lblLastPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                    lblUpdatedPrice.Visible = True
                Case Else
                    'Pricing is current
                    AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                    lblLastPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                    lblUpdatedPrice.Visible = True
                    Exit Sub
            End Select
        End If
    End Sub

    Public Sub LoadLastAssemblyCost()
        Dim DefaultAssemblyCostStatement As String = "SELECT TotalCost FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
        Dim DefaultAssemblyCostCommand As New SqlCommand(DefaultAssemblyCostStatement, con)
        DefaultAssemblyCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        DefaultAssemblyCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AssemblyCost = CDbl(DefaultAssemblyCostCommand.ExecuteScalar)
        Catch ex As Exception
            AssemblyCost = 0
        End Try
        con.Close()

        lblAssemblyCost.Text = FormatCurrency(AssemblyCost, 4)
    End Sub

    Public Sub LoadLastActivity()
        'Load values into Activity Date field
        Dim MAXSalesDateStatement As String = "SELECT MAX(SalesOrderDate) FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID"
        Dim MAXSalesDateCommand As New SqlCommand(MAXSalesDateStatement, con)
        MAXSalesDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXSalesDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXSalesDate = CStr(MAXSalesDateCommand.ExecuteScalar)
        Catch ex As Exception
            MAXSalesDate = "01/01/2016"
        End Try
        con.Close()

        Dim MAXPurchaseDateStatement As String = "SELECT MAX(PODate) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXPurchaseDateCommand As New SqlCommand(MAXPurchaseDateStatement, con)
        MAXPurchaseDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXPurchaseDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXPurchaseDate = CStr(MAXPurchaseDateCommand.ExecuteScalar)
        Catch ex As Exception
            MAXPurchaseDate = "01/01/2016"
        End Try
        con.Close()

        Dim MAXTransactionDateStatement As String = "SELECT MAX(TransactionDate) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXTransactionDateCommand As New SqlCommand(MAXTransactionDateStatement, con)
        MAXTransactionDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXTransactionDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXTransactionDate = CStr(MAXTransactionDateCommand.ExecuteScalar)
        Catch ex As Exception
            MAXTransactionDate = "01/01/2016"
        End Try
        con.Close()

        If MAXPurchaseDate >= MAXSalesDate And MAXPurchaseDate >= MAXTransactionDate Then
            lblLastActivityDate.Text = MAXPurchaseDate
        ElseIf MAXSalesDate >= MAXPurchaseDate And MAXSalesDate >= MAXTransactionDate Then
            lblLastActivityDate.Text = MAXSalesDate
        ElseIf MAXTransactionDate >= MAXPurchaseDate And MAXTransactionDate >= MAXSalesDate Then
            lblLastActivityDate.Text = MAXTransactionDate
        Else
            lblLastActivityDate.Text = "No Activity"
        End If
    End Sub

    Public Sub LoadAverageCost()
        Dim AVGCostStatement As String = "SELECT AVG(ItemCost) FROM InventoryCosting WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim AVGCostCommand As New SqlCommand(AVGCostStatement, con)
        AVGCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AVGCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AverageCost = CDbl(AVGCostCommand.ExecuteScalar)
        Catch ex As Exception
            AverageCost = 0
        End Try
        con.Close()

        lblAverageCost.Text = FormatCurrency(AverageCost, 4)
    End Sub

    Public Sub LoadNextPieceSold()
        Dim TotalQuantityShipped As Double = 0
        Dim GetMaxTransactionNumber As Integer = 0

        'Get TQS for part
        Dim TotalQuantityShippedString As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND Dropship = @Dropship"
        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedString, con)
        TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "NO"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalQuantityShipped = 0
        End Try
        con.Close()
        '******************************************************************************************************************************************
        'Add Total Quantity used in assemblies
        Dim GetBuildQuantity As Double = 0

        Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
        Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
        TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            GetBuildQuantity = 0
        End Try
        con.Close()

        GetBuildQuantity = GetBuildQuantity * -1

        TotalQuantityShipped = TotalQuantityShipped + GetBuildQuantity + 1
        '******************************************************************************************************************************************
        'Get Max Transaction Number for the Correct Cost Tier
        Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
        Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
        GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetMaxTransactionNumberCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
        GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = Today()

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetMaxTransactionNumber = 0
        End Try
        con.Close()

        'Get FIFO Cost for the next piece sold
        Dim NextPieceSoldStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND PartNumber = @PartNumber"
        Dim NextPieceSoldCommand As New SqlCommand(NextPieceSoldStatement, con)
        NextPieceSoldCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        NextPieceSoldCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        NextPieceSoldCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            NextPieceSold = CDbl(NextPieceSoldCommand.ExecuteScalar)
        Catch ex As System.Exception
            NextPieceSold = 0
        End Try
        con.Close()
    End Sub

    Public Sub LoadComponentPartByDescription()
        Dim PartNumber2 As String = ""

        Dim PartNumber2Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber2Command As New SqlCommand(PartNumber2Statement, con)
        PartNumber2Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboComponentDescription.Text
        PartNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber2 = CStr(PartNumber2Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber2 = ""
        End Try
        con.Close()

        cboComponentPartNumber.Text = PartNumber2
    End Sub

    Public Sub LoadComponentDescriptionByPart()
        Dim PartDescription2 As String = ""

        Dim PartDescription2Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription2Command As New SqlCommand(PartDescription2Statement, con)
        PartDescription2Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboComponentPartNumber.Text
        PartDescription2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription2 = CStr(PartDescription2Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription2 = ""
        End Try
        con.Close()

        cboComponentDescription.Text = PartDescription2
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

    Public Sub VerifyItemClass()
        Dim CheckItemClassStatement As String = "SELECT ItemClassID FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim CheckItemClassCommand As New SqlCommand(CheckItemClassStatement, con)
        CheckItemClassCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckItemClass = CStr(CheckItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            CheckItemClass = "INVALID"
        End Try
        con.Close()
    End Sub

    Public Sub LoadWeightsAndPieces()
        PieceWeight = Val(txtPieceWeight.Text)
        BoxCount = Val(txtBoxCount.Text)
        PalletCount = Val(txtPalletCount.Text)

        BoxWeight = PieceWeight * BoxCount
        PalletPieces = BoxCount * PalletCount
        PalletWeight = PalletPieces * PieceWeight

        lblBoxCount.Text = FormatNumber(BoxCount, 0)
        lblBoxWeight.Text = FormatNumber(BoxWeight, 1)
        lblPalletCount.Text = FormatNumber(PalletCount, 0)
        lblPalletPieceCount.Text = FormatNumber(PalletPieces, 0)
        lblPalletWeight.Text = FormatNumber(PalletWeight, 2)
        lblPieceWeight.Text = FormatNumber(PieceWeight, 4)
    End Sub

    Public Sub LoadMTDSales()
        MonthDate = Today()
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = MonthDate

        Dim MTDSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDSalesCommand As New SqlCommand(MTDSalesStatement, con)
        MTDSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        MTDSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim MTDQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDQuantityCommand As New SqlCommand(MTDQuantityStatement, con)
        MTDQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        MTDQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDSales = CDbl(MTDSalesCommand.ExecuteScalar)
        Catch ex As Exception
            MTDSales = 0
        End Try
        Try
            MTDQuantity = CDbl(MTDQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            MTDQuantity = 0
        End Try
        con.Close()

        lblMTDSales.Text = FormatCurrency(MTDSales, 2)
        lblMTDQuantity.Text = FormatNumber(MTDQuantity, 0)
    End Sub

    Public Sub LoadYTDSales()
        YearDate = Today()
        YearOfYear = YearDate.Year
        MonthOfYear = YearDate.Month

        If MonthOfYear < 5 Then
            YearOfYear = YearOfYear - 1
        End If

        strYear = CStr(YearOfYear)
        BeginDate = "05/01/" + strYear
        EndDate = YearDate

        Dim YTDSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDSalesCommand As New SqlCommand(YTDSalesStatement, con)
        YTDSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        YTDSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim YTDQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDQuantityCommand As New SqlCommand(YTDQuantityStatement, con)
        YTDQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        YTDQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDSales = CDbl(YTDSalesCommand.ExecuteScalar)
        Catch ex As Exception
            YTDSales = 0
        End Try
        Try
            YTDQuantity = CDbl(YTDQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            YTDQuantity = 0
        End Try
        con.Close()

        lblYTDSales.Text = FormatCurrency(YTDSales, 2)
        lblYTDQuantity.Text = FormatNumber(YTDQuantity, 0)
    End Sub

    Public Sub LoadMTDAssemblyPieces()
        Dim MTDComponentQuantity As Double = 0

        MonthDate = Today()
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = MonthDate

        Dim MTDComponentQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDComponentQuantityCommand As New SqlCommand(MTDComponentQuantityStatement, con)
        MTDComponentQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDComponentQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        MTDComponentQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDComponentQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDComponentQuantity = CDbl(MTDComponentQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            MTDComponentQuantity = 0
        End Try
        con.Close()

        If MTDComponentQuantity < 0 Then
            MTDComponentQuantity = MTDComponentQuantity * -1
        Else
            'Do nothing
        End If

        lblAssemblyPiecesMTD.Text = MTDComponentQuantity
        lblCPMonthUsed.Text = MTDComponentQuantity
    End Sub

    Public Sub LoadYTDAssemblyPieces()
        Dim YTDComponentQuantity As Double = 0
        Dim Divisor As Integer = 0
        Dim ComponentAveragePerMonth As Double = 0
        Dim DayOfYear As Integer
        Dim strDayOfYear As String
        Dim strMonthOfYear As String

        YearDate = Today()
        YearOfYear = YearDate.Year
        MonthOfYear = YearDate.Month
        DayOfYear = YearDate.Day

        YearOfYear = YearOfYear - 1

        strYear = CStr(YearOfYear)
        strMonthOfYear = CStr(MonthOfYear)
        strDayOfYear = CStr(DayOfYear)

        BeginDate = strMonthOfYear + "/" + strDayOfYear + "/" + strYear
        EndDate = YearDate

        Dim YTDComponentQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @PartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber AND BuildDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDComponentQuantityCommand As New SqlCommand(YTDComponentQuantityStatement, con)
        YTDComponentQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDComponentQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        YTDComponentQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDComponentQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDComponentQuantity = CDbl(YTDComponentQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            YTDComponentQuantity = 0
        End Try
        con.Close()

        If YTDComponentQuantity < 0 Then
            YTDComponentQuantity = YTDComponentQuantity * -1
        Else
            'Skip
        End If

        ComponentAveragePerMonth = YTDComponentQuantity / 12

        lblAssemblyPiecesYTD.Text = YTDComponentQuantity
        lblCPYearUsed.Text = YTDComponentQuantity
        lblCPAverage.Text = FormatNumber(ComponentAveragePerMonth, 2)
    End Sub

    Public Sub LoadLastTwelveMonthsAverage()
        Dim DateOfToday As Date
        Dim TodayMonth As Integer = 0
        Dim TodayDay As Integer = 0
        Dim TodayYear As Integer = 0
        Dim BeginYear As Integer = 0
        Dim strTodayDay As String = ""
        Dim strTodayMonth As String = ""
        Dim strTodayYear As String = ""
        Dim AverageBeginDate, AverageEndDate As String

        DateOfToday = Today()

        TodayDay = DateOfToday.Day
        TodayMonth = DateOfToday.Month
        TodayYear = DateOfToday.Year

        strTodayDay = CStr(TodayDay)
        strTodayMonth = CStr(TodayMonth)
        BeginYear = TodayYear - 1
        strTodayYear = CStr(BeginYear)

        AverageBeginDate = strTodayMonth + "/" + strTodayDay + "/" + strTodayYear
        AverageEndDate = CStr(DateOfToday)

        BeginDate = CDate(AverageBeginDate)
        EndDate = Today()

        Dim AverageMonthQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim AverageMonthQuantityCommand As New SqlCommand(AverageMonthQuantityStatement, con)
        AverageMonthQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AverageMonthQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        AverageMonthQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        AverageMonthQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MonthlyAverageQuantity = CDbl(AverageMonthQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            MonthlyAverageQuantity = 0
        End Try
        con.Close()

        MonthlyAverageQuantity = MonthlyAverageQuantity / 12

        lblAvgPerMonth.Text = FormatNumber(MonthlyAverageQuantity, 1)
    End Sub

    Public Sub LoadVendorName()
        Dim VendorNameString As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
    End Sub

    Public Sub LoadFormatting()
        Dim SerialStatus As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvSerialNumbers.Rows
            Try
                SerialStatus = row.Cells("Status2Column").Value
            Catch ex As System.Exception
                SerialStatus = ""
            End Try

            If SerialStatus = "OPEN" Then
                Me.dgvSerialNumbers.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightSalmon
                Me.dgvSerialNumbers.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
            ElseIf SerialStatus = "CLOSED" Then
                Me.dgvSerialNumbers.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvSerialNumbers.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf SerialStatus = "AVAILABLE" Then
                Me.dgvSerialNumbers.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvSerialNumbers.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvSerialNumbers.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvSerialNumbers.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadPriceBracketSecurity()
        If cboDivisionID.Text <> "TWD" Then
            gpxPriceBracket.Enabled = False
        End If

        If cboDivisionID.Text = "TWD" Then
            If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                gpxPriceBracket.Enabled = True
            End If

            If EmployeeLoginName = "JSPARKS" Or EmployeeLoginName = "ERUPNOW" Or EmployeeLoginName = "JDAVIES" Or EmployeeLoginName = "PWORKMAN" Then
                gpxPriceBracket.Enabled = True
            End If
        End If
    End Sub

    Public Sub LoadConsignmentInventory()
        'Calculate Inventory for Warehouses
        Dim BCWQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim BCWQOHCommand As New SqlCommand(BCWQOHString, con)
        BCWQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        BCWQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "BCW"

        Dim DCWQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim DCWQOHCommand As New SqlCommand(DCWQOHString, con)
        DCWQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        DCWQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DCW"

        Dim HCWQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim HCWQOHCommand As New SqlCommand(HCWQOHString, con)
        HCWQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        HCWQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HCW"

        Dim LCWQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim LCWQOHCommand As New SqlCommand(LCWQOHString, con)
        LCWQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LCWQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "LCW"

        Dim LSCWQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim LSCWQOHCommand As New SqlCommand(LSCWQOHString, con)
        LSCWQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LSCWQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "LSCW"

        Dim PCWQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PCWQOHCommand As New SqlCommand(PCWQOHString, con)
        PCWQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PCWQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "PCW"

        Dim YCWQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim YCWQOHCommand As New SqlCommand(YCWQOHString, con)
        YCWQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        YCWQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "YCW"

        Dim SCWQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim SCWQOHCommand As New SqlCommand(SCWQOHString, con)
        SCWQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        SCWQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SCW"

        Dim RCWQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim RCWQOHCommand As New SqlCommand(RCWQOHString, con)
        RCWQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        RCWQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "RCW"

        Dim SRLQOHString As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim SRLQOHCommand As New SqlCommand(SRLQOHString, con)
        SRLQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        SRLQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SRL"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BCWOnHand = CInt(BCWQOHCommand.ExecuteScalar)
        Catch ex As Exception
            BCWOnHand = 0
        End Try
        Try
            DCWOnHand = CInt(DCWQOHCommand.ExecuteScalar)
        Catch ex As Exception
            DCWOnHand = 0
        End Try
        Try
            HCWOnHand = CInt(HCWQOHCommand.ExecuteScalar)
        Catch ex As Exception
            HCWOnHand = 0
        End Try
        Try
            LCWOnHand = CInt(LCWQOHCommand.ExecuteScalar)
        Catch ex As Exception
            LCWOnHand = 0
        End Try
        Try
            LSCWOnHand = CInt(LSCWQOHCommand.ExecuteScalar)
        Catch ex As Exception
            LSCWOnHand = 0
        End Try
        Try
            PCWOnHand = CInt(PCWQOHCommand.ExecuteScalar)
        Catch ex As Exception
            PCWOnHand = 0
        End Try
        Try
            SCWOnHand = CInt(SCWQOHCommand.ExecuteScalar)
        Catch ex As Exception
            SCWOnHand = 0
        End Try
        Try
            YCWOnHand = CInt(YCWQOHCommand.ExecuteScalar)
        Catch ex As Exception
            YCWOnHand = 0
        End Try
        Try
            RCWOnHand = CInt(RCWQOHCommand.ExecuteScalar)
        Catch ex As Exception
            RCWOnHand = 0
        End Try
        Try
            SRLOnHand = CInt(SRLQOHCommand.ExecuteScalar)
        Catch ex As Exception
            SRLOnHand = 0
        End Try
        con.Close()

        lblBessemerInventory.Text = BCWOnHand
        lblHaywardInventory.Text = HCWOnHand
        lblDowneyInventory.Text = DCWOnHand
        lblSeattleInventory.Text = SCWOnHand
        lblLyndhurstInventory.Text = YCWOnHand
        lblLewisvilleInventory.Text = LCWOnHand
        lblPhoenixInventory.Text = PCWOnHand
        lblSRLInventory.Text = SRLOnHand
        lblRentonInventory.Text = RCWOnHand
        lblLakeStevensInventory.Text = LSCWOnHand
    End Sub

    Private Sub SetConsignmentZero()
        lblBessemerInventory.Text = "0"
        lblHaywardInventory.Text = "0"
        lblDowneyInventory.Text = "0"
        lblSeattleInventory.Text = "0"
        lblLyndhurstInventory.Text = "0"
        lblLewisvilleInventory.Text = "0"
        lblPhoenixInventory.Text = "0"
        lblRentonInventory.Text = "0"
        lblLakeStevensInventory.Text = "0"
    End Sub

    Public Sub LoadFOXData()
        'Extract data from source table
        Dim RMIDString As String = "SELECT FOXTable.RMID, BlueprintNumber, FluxLoadNumber, BoxType, Carbon, SteelSize FROM FOXTable LEFT OUTER JOIN RawMaterialsTable on FOXTable.RMID = RawMaterialsTable.RMID WHERE FOXNumber = @FOXNumber AND FOXTable.DivisionID = @DivisionID"
        Dim RMIDCommand As New SqlCommand(RMIDString, con)
        RMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(lblFOXNumber.Text)
        RMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = RMIDCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("RMID")) Then
                RMID = ""
            Else
                RMID = reader.Item("RMID")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                BluePrintNumber = ""
            Else
                BluePrintNumber = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("FluxLoadNumber")) Then
                FluxLoadNumber = ""
            Else
                FluxLoadNumber = reader.Item("FluxLoadNumber")
            End If
            If IsDBNull(reader.Item("BoxType")) Then
                BoxType = "Z"
            Else
                BoxType = reader.Item("BoxType")
            End If
            If IsDBNull(reader.Item("Carbon")) Then
                Carbon = ""
            Else
                Carbon = reader.Item("Carbon")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader.Item("SteelSize")
            End If
        Else
            RMID = ""
            BluePrintNumber = ""
            FluxLoadNumber = ""
            BoxType = "Z"
            Carbon = ""
            SteelSize = ""
        End If
        reader.Close()
        con.Close()

        lblItemFluxLoad.Text = FluxLoadNumber
        If BoxType.Equals("Z") Then
            cmd = New SqlCommand("SELECT BOXType FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BoxType = cmd.ExecuteScalar()
            Catch ex As Exception

            End Try
            con.Close()
        End If

        txtBoxType.Text = BoxType

        lblRMID.Text = RMID
        lblItemBlueprintNumber.Text = BluePrintNumber
        lblItemSteelCarbon.Text = Carbon
        lblItemSteelDiameter.Text = SteelSize
    End Sub

    Public Sub UnlockItem()

    End Sub

    'Load validation and clear routines

    Public Sub ClearLotNumbers()
        dgvLotNumbers.DataSource = Nothing
    End Sub

    Public Sub ClearSerialNumbers()
        dgvSerialNumbers.DataSource = Nothing
    End Sub

    Public Sub ClearAssemblyComponents()
        dgvAssemblyLineQuery.DataSource = Nothing
        cboDeleteComponent.DataSource = Nothing

        txtAssemblyComment.Clear()
        dtpAssemblyDate.Value = Today()
        cboComponentPartNumber.SelectedIndex = -1
        cboComponentDescription.SelectedIndex = -1
        txtComponentQuantity.Clear()
        txtComponentCost.Clear()
        txtComponentComment.Clear()
        chkSerializedAssembly.Checked = False
    End Sub

    Public Sub ValidatePPLAndSPL()
        Dim CheckPPLString As String = "SELECT COUNT(PurchaseProductLineID) FROM PurchaseProductLine WHERE PurchaseProductLineID = @PurchaseProductLineID"
        Dim CheckPPLCommand As New SqlCommand(CheckPPLString, con)
        CheckPPLCommand.Parameters.Add("@PurchaseProductLineID", SqlDbType.VarChar).Value = cboPurchaseProductID.Text

        Dim CheckSPLString As String = "SELECT COUNT(SalesProdLineID) FROM SalesProductLine WHERE SalesProdLineID = @SalesProdLineID"
        Dim CheckSPLCommand As New SqlCommand(CheckSPLString, con)
        CheckSPLCommand.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = cboSalesProductLine.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPPL = CInt(CheckPPLCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPPL = 0
        End Try
        Try
            CheckSPL = CInt(CheckSPLCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSPL = 0
        End Try
        con.Close()
    End Sub

    Public Sub ClearLabels()
        lblCountFox.Text = ""
        lblFOXNumber.Text = ""
        lblAtlantInventory.Text = ""
        lblAverageCost.Text = ""
        lblBessemerInventory.Text = ""
        lblSRLInventory.Text = ""
        lblQuantityOpen.Text = ""
        lblBoxCount.Text = ""
        txtBoxType.Clear()
        lblBoxWeight.Text = ""
        lblDowneyInventory.Text = ""
        lblHaywardInventory.Text = ""
        lblLyndhurstInventory.Text = ""
        lblItemBlueprintNumber.Text = ""
        lblItemFluxLoad.Text = ""
        lblItemSteelCarbon.Text = ""
        lblItemSteelDiameter.Text = ""
        lblLastActivityDate.Text = ""
        lblLastCost.Text = ""
        lblLastPrice.Text = ""
        lblLasVegasInventory.Text = ""
        lblMTDSales.Text = ""
        lblPalletCount.Text = ""
        lblPalletPieceCount.Text = ""
        lblPalletWeight.Text = ""
        lblPhoenixInventory.Text = ""
        lblPieceWeight.Text = ""
        lblQuantityOnHand.Text = ""
        lblSaltLakeInventory.Text = ""
        lblTexasInventory.Text = ""
        lblSeattleInventory.Text = ""
        lblTWDInventory.Text = ""
        lblTFPInventory.Text = ""
        lblTWEInventory.Text = ""
        lblJerseyQOH.Text = ""
        lblVancouverInventory.Text = ""
        lblLewisvilleInventory.Text = ""
        lblLakeStevensInventory.Text = ""
        lblRentonInventory.Text = ""
        lblWeldingCeramicsInventory.Text = ""
        lblYTDSales.Text = ""
        lblChicagoInventory.Text = ""
        lblHoustonQOH.Text = ""
        lblAssemblyCost.Text = ""
        lblQuantityCommitted.Text = ""
        lblOpenPOQuantity.Text = ""
        lblTorontoQOH.Text = ""
        lblMTDQuantity.Text = ""
        lblYTDQuantity.Text = ""
        lblAvgPerMonth.Text = ""
        lblAssemblyPiecesMTD.Text = ""
        lblAssemblyPiecesYTD.Text = ""

        lblCPApr.Text = ""
        lblCPAug.Text = ""
        lblCPAverage.Text = ""
        lblCPDec.Text = ""
        lblCPFeb.Text = ""
        lblCPJan.Text = ""
        lblCPJul.Text = ""
        lblCPJun.Text = ""
        lblCPMar.Text = ""
        lblCPMaxStock.Text = ""
        lblCPMay.Text = ""
        lblCPMinStock.Text = ""
        lblCPMonthUsed.Text = ""
        lblCPNov.Text = ""
        lblCPOct.Text = ""
        lblCPQOH.Text = ""
        lblCPQuantityOpen.Text = ""
        lblCPReorderQuantity.Text = ""
        lblCPSep.Text = ""
        lblCPYearUsed.Text = ""
        lblYear1.Text = ""
        lblYear10.Text = ""
        lblYear11.Text = ""
        lblYear12.Text = ""
        lblYear2.Text = ""
        lblYear3.Text = ""
        lblYear4.Text = ""
        lblYear5.Text = ""
        lblYear6.Text = ""
        lblYear7.Text = ""
        lblYear8.Text = ""
        lblYear9.Text = ""

        lblUpdatedPrice.Visible = False

        txtVendorName.Clear()
    End Sub

    Public Sub ClearVariables()
        ATLQuantityOnHand = 0
        CHTQuantityOnHand = 0
        CBSQuantityOnHand = 0
        SLCQuantityOnHand = 0
        TFPQuantityOnHand = 0
        TWDQuantityOnHand = 0
        TFFQuantityOnHand = 0
        TFTQuantityOnHand = 0
        TWEQuantityOnHand = 0
        CGOQuantityOnHand = 0
        HOUQuantityOnHand = 0
        TORQuantityOnHand = 0
        DENQuantityOnHand = 0
        ALBQuantityOnHand = 0
        TFJQuantityOnHand = 0
        BCWOnHand = 0
        DCWOnHand = 0
        HCWOnHand = 0
        SCWOnHand = 0
        YCWOnHand = 0
        LCWOnHand = 0
        PCWOnHand = 0
        SRLOnHand = 0
        LSCWOnHand = 0
        RCWOnHand = 0
        BCWShipped = 0
        DCWShipped = 0
        HCWShipped = 0
        SCWShipped = 0
        YCWShipped = 0
        LCWShipped = 0
        PCWShipped = 0
        SRLShipped = 0
        LSCWShipped = 0
        RCWShipped = 0
        BCWBilled = 0
        DCWBilled = 0
        HCWBilled = 0
        SCWBilled = 0
        YCWBilled = 0
        LCWBilled = 0
        PCWBilled = 0
        SRLBilled = 0
        LSCWBilled = 0
        RCWBilled = 0
        BCWReturned = 0
        DCWReturned = 0
        HCWReturned = 0
        SCWReturned = 0
        YCWReturned = 0
        LCWReturned = 0
        PCWReturned = 0
        SRLReturned = 0
        LSCWReturned = 0
        RCWReturned = 0
        FOXNumber = 0
        NominalDiameter = 0
        NominalLength = 0
        MAXSalesDate = ""
        MAXPurchaseDate = ""
        Carbon = ""
        SteelSize = ""
        RMID = ""
        BoxType = ""
        FluxLoadNumber = ""
        BluePrintNumber = ""
        LongDescription = ""
        ItemClass = ""
        PurchProdLineID = ""
        SalesProdLineID = ""
        OldPartNumber = ""
        AddAccessory = ""
        BoxCount = 0
        PalletCount = 0
        PalletPieces = 0
        MaximumStock = 0
        MinimumStock = 0
        PieceWeight = 0
        BoxWeight = 0
        StdBoxWeight = 0
        PalletWeight = 0
        StandardCost = 0
        StandardPrice = 0
        StandardMargin = 0
        LastPurchaseCost = 0
        LastSalesPrice = 0
        AverageCost = 0
        BeginningBalance = 0
        OpenPOQuantity = 0
        ComponentStandardCost = 0
        DuplicatePartDescription = ""
        PartComments = ""
        PartLeadTime = ""
        AssemblyComment = ""
        SerializedStatus = ""
        CheckItemClass = ""
        TransactionCost = 0
        ComponentUnitCost = 0
        SUMExtendedCost = 0
        CheckItemOnTT = 0
        CheckItemOnSO = 0
        CheckItemOnPO = 0
        CheckAll = 0
        AssemblyCost = 0
        VendorID = ""
        VendorName = ""
        CheckPOQuantityOpen = 0
        CheckSOQuantityOpen = 0
        CheckQOH = 0
        MTDQuantity = 0
        YTDQuantity = 0
        MonthlyAverageQuantity = 0
        SerialTextSearch = ""
        BinPreferenceCode = ""
    End Sub

    Public Sub ClearData()
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""
        cboItemClass.Text = ""
        cboPurchaseProductID.Text = ""
        cboSalesProductLine.Text = ""
        cboAddAccessories.Text = ""
        cboComponentDescription.Text = ""
        cboComponentPartNumber.Text = ""
        cboDeleteComponent.Text = ""
        cboVendorID.Text = ""
        cboSafetyDataSheet.Text = ""
        cboWarehouse.Text = ""

        dtpAdjDate.Text = ""
        dtpItemCreationDate.Text = ""
        dtpAssemblyDate.Text = ""

        chkSerializedAssembly.Checked = False

        txtBoxCount.Clear()
        txtStdBoxWeight.Clear()
        txtLongDescription.Clear()
        txtMaximumStock.Clear()
        txtMinimumStock.Clear()
        txtOldPartNumber.Clear()
        txtPalletCount.Clear()
        txtPieceWeight.Clear()
        txtStandardUnitCost.Clear()
        txtStandardUnitPrice.Clear()
        txtNominalDiameter.Clear()
        txtNominalLength.Clear()
        txtComponentComment.Clear()
        txtAssemblyComment.Clear()
        txtComponentQuantity.Clear()
        txtComponentCost.Clear()
        txtVendorName.Clear()
        txtAdjustQuantity.Clear()
        txtLeadTime.Clear()
        txtItemComments.Clear()
        txtTextSearch.Clear()
        txtBoxType.Clear()
        txtItemListFOX.Clear()
        txtBinPreference.Clear()

        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboPurchaseProductID.SelectedIndex = -1
        cboSalesProductLine.SelectedIndex = -1
        cboAddAccessories.SelectedIndex = -1
        cboComponentDescription.SelectedIndex = -1
        cboComponentPartNumber.SelectedIndex = -1
        cboDeleteComponent.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboSafetyDataSheet.SelectedIndex = -1
        cboWarehouse.SelectedIndex = -1

        lblRMID.Text = ""
        lblPalletCount.Text = ""
        lblPalletPieceCount.Text = ""
        lblPalletWeight.Text = ""
        lblBoxCount.Text = ""
        lblBoxWeight.Text = ""
        lblPieceWeight.Text = ""
        lblItemSteelCarbon.Text = ""
        lblItemSteelDiameter.Text = ""
        lblItemFluxLoad.Text = ""
        lblItemBlueprintNumber.Text = ""
        lblLastCost.Text = ""
        lblLastPrice.Text = ""
        lblLastActivityDate.Text = ""
        lblYTDSales.Text = ""
        lblMTDSales.Text = ""
        lblAtlantInventory.Text = ""
        lblAverageCost.Text = ""
        lblBessemerInventory.Text = ""
        lblDowneyInventory.Text = ""
        lblHaywardInventory.Text = ""
        lblLyndhurstInventory.Text = ""
        lblLakeStevensInventory.Text = ""
        lblRentonInventory.Text = ""
        lblItemSteelCarbon.Text = ""
        lblItemSteelDiameter.Text = ""
        lblLasVegasInventory.Text = ""
        lblPhoenixInventory.Text = ""
        lblQuantityOnHand.Text = ""
        lblJerseyQOH.Text = ""
        lblSaltLakeInventory.Text = ""
        lblSeattleInventory.Text = ""
        lblTexasInventory.Text = ""
        lblTWDInventory.Text = ""
        lblTWEInventory.Text = ""
        lblVancouverInventory.Text = ""
        lblLewisvilleInventory.Text = ""
        lblWeldingCeramicsInventory.Text = ""
        lblChicagoInventory.Text = ""
        lblHoustonQOH.Text = ""
        lblAssemblyCost.Text = ""
        lblQuantityCommitted.Text = ""
        lblOpenPOQuantity.Text = ""
        lblTorontoQOH.Text = ""
        lblMTDQuantity.Text = ""
        lblYTDQuantity.Text = ""
        lblDenverQOH.Text = ""
        lblQuantityOpen.Text = ""
        lblSRLInventory.Text = ""
        lblAvgPerMonth.Text = ""
        lblAssemblyPiecesMTD.Text = ""
        lblAssemblyPiecesYTD.Text = ""
        lblCountFox.Text = ""
        lblFOXNumber.Text = ""

        lblCPApr.Text = ""
        lblCPAug.Text = ""
        lblCPAverage.Text = ""
        lblCPDec.Text = ""
        lblCPFeb.Text = ""
        lblCPJan.Text = ""
        lblCPJul.Text = ""
        lblCPJun.Text = ""
        lblCPMar.Text = ""
        lblCPMaxStock.Text = ""
        lblCPMay.Text = ""
        lblCPMinStock.Text = ""
        lblCPMonthUsed.Text = ""
        lblCPNov.Text = ""
        lblCPOct.Text = ""
        lblCPQOH.Text = ""
        lblCPQuantityOpen.Text = ""
        lblCPReorderQuantity.Text = ""
        lblCPSep.Text = ""
        lblCPYearUsed.Text = ""
        lblYear1.Text = ""
        lblYear10.Text = ""
        lblYear11.Text = ""
        lblYear12.Text = ""
        lblYear2.Text = ""
        lblYear3.Text = ""
        lblYear4.Text = ""
        lblYear5.Text = ""
        lblYear6.Text = ""
        lblYear7.Text = ""
        lblYear8.Text = ""
        lblYear9.Text = ""

        txtLabelAdditionalComments.Text = ""
        txtLabelComments.Text = ""
        txtLabelComments2.Text = ""
        txtLabelComments3.Text = ""
        txtLabelQuantity.Text = ""

        nbrLabelCount.Value = 1

        lblUpdatedPrice.Visible = False

        chkCanadian.Checked = False
        chkAmerican.Checked = False
        chkDeactivatePart.Checked = False
        chkNonLotNumber.Checked = False

        gpxAssemblyData.Enabled = True
        cmdDelete.Enabled = True
        cboItemClass.Enabled = True

        cboPartNumber.Focus()
        dgvProductionData.Rows.Clear()
        dgvProductionData.Columns.Clear()
    End Sub

    Private Function canPrintItemLabel() As Boolean
        If cboPartNumber.Text = "" Then
            MessageBox.Show("You must enter a Part Number.", "Select Part Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If
        If cboPartNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select Part Number.", "Select Part Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub txt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPieceWeight.Leave, txtBoxCount.Leave, txtPalletCount.Leave, txtStdBoxWeight.Leave, txtNominalDiameter.Leave, txtNominalLength.Leave
        If TypeOf (sender) Is System.Windows.Forms.TextBox AndAlso Not String.IsNullOrEmpty(cboPartNumber.Text) AndAlso Not String.IsNullOrEmpty(cboDivisionID.Text) Then
            Dim txt As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            If txt.Tag IsNot Nothing Then
                Dim tmp As New usefulFunctions.FieldData
                tmp.ColumnName = txt.Tag
                cmd = New SqlCommand("SELECT " + txt.Tag + " FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim obj As Object = Nothing
                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    obj = cmd.ExecuteScalar()
                Catch ex As Exception

                Finally
                    con.Close()
                End Try
                If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                    If Not obj.ToString.Equals(txt.Text) Then
                        tmp.OriginalValue = obj.ToString()
                        tmp.NewValue = txt.Text
                        lstChangedFields.Add(tmp)
                    Else
                        lstChangedFields.Remove(tmp)
                    End If
                Else
                    tmp.OriginalValue = ""
                    tmp.NewValue = txt.Text
                    lstChangedFields.Add(tmp)
                End If
            End If
        End If
    End Sub

    Private Sub UpdateLog()
        Dim lst As List(Of usefulFunctions.FieldData) = lstChangedFields.GetList()

        If lst.Count > 0 Then
            cmd = New SqlCommand("INSERT INTO TFPItemListActivityLog (ActivityDateTime, UserID, DivisionID, ItemID, ChangedField, OriginalValue, NewValue)", con)
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            For i As Integer = 0 To lst.Count - 1
                If i = 0 Then
                    cmd.CommandText += " VALUES (CURRENT_TIMESTAMP, @UserID, @DivisionID, @ItemID, @ColumnName" + i.ToString + ", @Original" + i.ToString + ", @New" + i.ToString + ")"
                Else
                    cmd.CommandText += ", (CURRENT_TIMESTAMP, @UserID, @DivisionID, @ItemID, @ColumnName" + i.ToString + ", @Original" + i.ToString + ", @New" + i.ToString + ")"
                End If
                cmd.Parameters.Add("@ColumnName" + i.ToString, SqlDbType.VarChar).Value = lst(i).ColumnName
                cmd.Parameters.Add("@Original" + i.ToString, SqlDbType.VarChar).Value = lst(i).OriginalValue
                cmd.Parameters.Add("@New" + i.ToString, SqlDbType.VarChar).Value = lst(i).NewValue
            Next

            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try

            lstChangedFields.Clear()
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboPartNumber.Text) Then
            MessageBox.Show("You must select a part number", "Select a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.Focus()
            Return False
        End If

        If isSomeoneEditing() Then
            LoadQuantityPending()
            tabItemMaintenance.SelectedIndex = 0
            LoadLastPurchaseCost()
            LoadLastSalePrice()
            LoadLastActivity()
            LoadDataFields()
            LoadAverageCost()
            LoadLastAssemblyCost()
            LoadMTDSales()
            LoadYTDSales()
            LoadConsignmentInventory()
            LoadAssemblyData()
            ShowAssemblyComponents()
            ShowSerialNumbers()
            Return False
        End If

        If String.IsNullOrEmpty(cboPartDescription.Text) Then
            MessageBox.Show("You must enter a part description", "Enter a part description", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartDescription.Focus()
            Return False
        End If

        VerifyItemClass()

        If CheckItemClass = "" Or CheckItemClass = "INVALID" Then
            MessageBox.Show("You must enter a valid Item Class", "Enter a valid Item Class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboItemClass.Focus()
            Return False
        End If

        Return True
    End Function

    Public Sub ClearAssemblyLines()
        txtComponentComment.Clear()
        txtComponentQuantity.Clear()
        cboComponentPartNumber.SelectedIndex = -1
        cboComponentDescription.SelectedIndex = -1
        dtpAssemblyDate.Focus()
    End Sub

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.GetValue(0)) Then
                personEditing = reader.GetValue(0)
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this Item. You are unable to make any changes.", "Unable to make changes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE ItemList SET Locked = @Locked WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch()
        cmd = New SqlCommand("UPDATE ItemList SET Locked = '' WHERE ItemID = @ItemID AND Locked = @Locked AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub FormLoginRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LoginTime", SqlDbType.VarChar).Value = strTodaysTime
            .Add("@LogoutDate", SqlDbType.VarChar).Value = ""
            .Add("@LogoutTime", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub FormLogoutRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = ""
            .Add("@LoginTime", SqlDbType.VarChar).Value = ""
            .Add("@LogoutDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LogoutTime", SqlDbType.VarChar).Value = strTodaysTime
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'ComboBox Routines

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        If isLoaded Then
            LoadVendorName()
            If cboVendorID.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(lastItem) Then
                unlockBatch()
            End If

            ClearLabels()
            lstChangedFields.Clear()
            tabItemMaintenance.SelectedIndex = 0
            LoadLastActivity()
            LoadDataFields()
            LoadAverageCost()
            LoadLastAssemblyCost()

            If cboDivisionID.Text = "TWD" Then
                'LoadLastSalePrice()
                LoadLastSalesPriceTWDRevised()
            Else
                LoadLastSalePrice()
            End If

            Select Case ItemClass
                Case "FREIGHT", "MISC ITEMS", "MISC-CHARGE", "OUTSIDE WORK", "SALES TAX", "REPAIR", "RENTAL"
                    lblAtlantInventory.Text = 0
                    lblLasVegasInventory.Text = 0
                    lblWeldingCeramicsInventory.Text = 0
                    lblTWDInventory.Text = 0
                    lblVancouverInventory.Text = 0
                    lblTexasInventory.Text = 0
                    lblTFPInventory.Text = 0
                    lblTWEInventory.Text = 0
                    lblSaltLakeInventory.Text = 0
                    lblHoustonQOH.Text = 0
                    lblTorontoQOH.Text = 0
                    lblQuantityOnHand.Text = 0
                    lblQuantityCommitted.Text = 0
                    lblQuantityOpen.Text = 0
                    lblOpenPOQuantity.Text = 0
                Case Else
                    LoadQuantityPending()

                    ''check to see if the thread is working on loading totals and if so will cancel the process
                    If bgwkLoadInventoryTotals.IsBusy Then
                        bgwkLoadInventoryTotals.CancelAsync()
                    End If

                    ''waits till the thread has finished
                    While bgwkLoadInventoryTotals.IsBusy
                        System.Windows.Forms.Application.DoEvents()
                    End While

                    ''starts the thread to load inventory totals
                    bgwkLoadInventoryTotals.RunWorkerAsync(cboPartNumber.Text)
            End Select

            LoadMTDSales()
            LoadYTDSales()
            LoadDescriptionByPart()
            LoadLastTwelveMonthsAverage()
            LoadYTDAssemblyPieces()
            LoadMTDAssemblyPieces()
            ShowSerialNumbers()

            'Load Assembly Data if applicable
            If cboPurchaseProductID.Text = "ASSEMBLY" Then
                Dim CheckSerializedStatus As String = ""

                'Check if part is serialized
                Dim CheckSerializedStatusStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                Dim CheckSerializedStatusCommand As New SqlCommand(CheckSerializedStatusStatement, con)
                CheckSerializedStatusCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                CheckSerializedStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckSerializedStatus = CStr(CheckSerializedStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckSerializedStatus = "NO"
                End Try
                con.Close()

                If CheckSerializedStatus = "YES" Then
                    If cboDivisionID.Text = "TWE" Then
                        'Load Assembly Data from division and enable fields
                        LoadAssemblyData()
                        ShowAssemblyComponents()

                        gpxAssemblyData.Enabled = True
                        cmdDeleteComponent.Enabled = True
                        cmdUpdateCost.Enabled = True
                        cmdAddComponent.Enabled = True
                        cmdClearAssembly.Enabled = True
                        chkSerializedAssembly.Checked = True
                        chkSerializedAssembly.Enabled = True

                        Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
                    Else
                        'Load components from TWE and lock fields
                        LoadAssemblyDataFromTWE()
                        ShowAssemblyComponentsFromTWE()

                        gpxAssemblyData.Enabled = False
                        cmdDeleteComponent.Enabled = False
                        cmdUpdateCost.Enabled = False
                        cmdAddComponent.Enabled = False
                        cmdClearAssembly.Enabled = False
                        chkSerializedAssembly.Enabled = False
                        chkSerializedAssembly.Checked = True

                        If cboDivisionID.Text = "TWD" Then
                            Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
                        Else
                            Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = False
                        End If
                    End If
                Else
                    If cboDivisionID.Text = "TWE" Then
                        'Load Assembly Data from division and enable fields
                        LoadAssemblyData()
                        ShowAssemblyComponents()

                        gpxAssemblyData.Enabled = True
                        cmdDeleteComponent.Enabled = True
                        cmdUpdateCost.Enabled = True
                        cmdAddComponent.Enabled = True
                        cmdClearAssembly.Enabled = True
                        chkSerializedAssembly.Checked = False
                        chkSerializedAssembly.Enabled = True

                        Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
                    Else
                        LoadAssemblyData()
                        ShowAssemblyComponents()

                        gpxAssemblyData.Enabled = True
                        cmdDeleteComponent.Enabled = True
                        cmdUpdateCost.Enabled = True
                        cmdAddComponent.Enabled = True
                        cmdClearAssembly.Enabled = True
                        chkSerializedAssembly.Enabled = False
                        chkSerializedAssembly.Checked = False

                        Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
                    End If
                End If
            Else
                ClearAssemblyComponents()
            End If

            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
                If String.IsNullOrEmpty(lblFOXNumber.Text) Then
                    LoadFOXForPart()
                End If

                LoadFOXData()
                LoadManufacturedCost()

                If lblFOXNumber.Text <> txtItemListFOX.Text Then
                    txtItemListFOX.BackColor = Color.Yellow
                Else
                    txtItemListFOX.BackColor = Color.White
                End If
            Else
                SetConsignmentZero()
                LoadLastPurchaseCost()
            End If

            'Load Consignment Data
            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "TFF" Then
                LoadConsignmentInventory()
            Else
                SetConsignmentZero()
            End If

            lastItem = cboPartNumber.Text
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        If cboDivisionID.Text.Equals("TFP") Then
            If cboPartDescription.Focused() Then
                LoadPartByDescription()
            End If
        Else
            LoadPartByDescription()
        End If
    End Sub

    Private Sub cboItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClass.SelectedIndexChanged
        If isLoaded Then
            CheckItemClass = cboItemClass.Text

            If cboItemClass.Focused Then
                needsSaved = True
            End If

            If cboItemClass.Text.Equals("BOXES") And cboDivisionID.Text.Equals("TWD") Then
                txtBoxType.BackColor = cboPartNumber.BackColor
                txtBoxType.ReadOnly = False
            Else
                txtBoxType.BackColor = lblPieceWeight.BackColor
                txtBoxType.ReadOnly = True
            End If

            If cboItemClass.Text = "DEACTIVATED-PART" Then
                chkDeactivatePart.Checked = True
            ElseIf cboItemClass.Text = "TW WELD STUD W/O LOT" Then
                chkNonLotNumber.Checked = True
            Else
                chkDeactivatePart.Checked = False
            End If
        End If
    End Sub

    Private Sub cboSalesProductLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesProductLine.SelectedIndexChanged
        If cboSalesProductLine.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If Not String.IsNullOrEmpty(lastItem) Then
            unlockBatch()
        End If

        'Set date format
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            chkAmerican.Enabled = True
            chkCanadian.Enabled = True
        Else
            chkAmerican.Enabled = False
            chkCanadian.Enabled = False
        End If

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TWD" Then
            lblSRLInventory.Visible = True
            lblSRL.Visible = True
        Else
            lblSRLInventory.Visible = False
            lblSRL.Visible = False
        End If

        LoadPriceBracketSecurity()

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            cmdInventoryRacking.Enabled = True
            gpxAdjustWarehouse.Enabled = True
            llLastPOCostPopup.Text = "Manufactured Cost"
            chkShowSerialNumbersByDivision.Enabled = True
        ElseIf cboDivisionID.Text = "SLC" Then
            cmdInventoryRacking.Enabled = True
            gpxAdjustWarehouse.Enabled = False
            llLastPOCostPopup.Text = "Last Purchase Cost"
            chkShowSerialNumbersByDivision.Enabled = False
        ElseIf cboDivisionID.Text = "TFF" Then
            cmdInventoryRacking.Enabled = False
            gpxAdjustWarehouse.Enabled = True
            llLastPOCostPopup.Text = "Last Purchase Cost"
            chkShowSerialNumbersByDivision.Enabled = False
        ElseIf cboDivisionID.Text = "TWE" Then
            cmdInventoryRacking.Enabled = False
            gpxAdjustWarehouse.Enabled = True
            llLastPOCostPopup.Text = "Manufactured Cost"
            chkShowSerialNumbersByDivision.Enabled = True
        ElseIf cboDivisionID.Text = "TST" Then
            cmdInventoryRacking.Enabled = False
            gpxAdjustWarehouse.Enabled = True
            llLastPOCostPopup.Text = "Manufactured Cost"
            chkShowSerialNumbersByDivision.Enabled = False
        Else
            cmdInventoryRacking.Enabled = False
            gpxAdjustWarehouse.Enabled = False
            llLastPOCostPopup.Text = "Last Purchase Cost"
            chkShowSerialNumbersByDivision.Enabled = False
        End If

        If cboDivisionID.Text = "TWE" Then
            chkSerializedAssembly.Enabled = True
        Else
            chkSerializedAssembly.Enabled = False
        End If

        'Clear text boxes on load
        LoadPartNumber()
        LoadPartDescription()

        LoadComponentPartNumber()
        LoadComponentPartDescription()
        LoadVendor()
        ClearData()

        ShowSerialNumbers()
        ShowAssemblyComponents()
        needsSaved = False
    End Sub

    Private Sub cboPurchaseProductID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPurchaseProductID.SelectedIndexChanged
        If isLoaded Then
            'Load and enable fields to edit assemblies
            If cboPurchaseProductID.Text = "ASSEMBLY" Then
                'Set edit defaults by division
                If cboDivisionID.Text = "TWE" Then
                    Dim CheckSerializedStatus As String = ""

                    'Check if part is serialized
                    Dim CheckSerializedStatusStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim CheckSerializedStatusCommand As New SqlCommand(CheckSerializedStatusStatement, con)
                    CheckSerializedStatusCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    CheckSerializedStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckSerializedStatus = CStr(CheckSerializedStatusCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckSerializedStatus = "NO"
                    End Try
                    con.Close()

                    If CheckSerializedStatus = "YES" Then
                        'Load components from TWE and lock fields
                        LoadAssemblyDataFromTWE()
                        ShowAssemblyComponentsFromTWE()

                        gpxAssemblyData.Enabled = True
                        cmdDeleteComponent.Enabled = True
                        cmdUpdateCost.Enabled = True
                        cmdAddComponent.Enabled = True
                        cmdClearAssembly.Enabled = True
                        chkSerializedAssembly.Checked = True
                        chkSerializedAssembly.Enabled = True

                        Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
                    Else
                        'Load Assembly Data from division and enable fields
                        LoadAssemblyData()
                        ShowAssemblyComponents()

                        gpxAssemblyData.Enabled = True
                        cmdDeleteComponent.Enabled = True
                        cmdUpdateCost.Enabled = True
                        cmdAddComponent.Enabled = True
                        cmdClearAssembly.Enabled = True
                        chkSerializedAssembly.Checked = False
                        chkSerializedAssembly.Enabled = True

                        Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
                    End If
                Else
                    Dim CheckSerializedStatus As String = ""

                    'Check if part is serialized
                    Dim CheckSerializedStatusStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim CheckSerializedStatusCommand As New SqlCommand(CheckSerializedStatusStatement, con)
                    CheckSerializedStatusCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    CheckSerializedStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckSerializedStatus = CStr(CheckSerializedStatusCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckSerializedStatus = "NO"
                    End Try
                    con.Close()

                    If CheckSerializedStatus = "YES" Then
                        'Load components from TWE and lock fields
                        LoadAssemblyDataFromTWE()
                        ShowAssemblyComponentsFromTWE()

                        gpxAssemblyData.Enabled = False
                        cmdDeleteComponent.Enabled = False
                        cmdUpdateCost.Enabled = False
                        cmdAddComponent.Enabled = False
                        cmdClearAssembly.Enabled = False
                        chkSerializedAssembly.Checked = True
                        chkSerializedAssembly.Enabled = False

                        If cboDivisionID.Text = "TWD" Then
                            Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
                        Else
                            Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = False
                        End If
                    Else
                        'Load Assembly Data from division and enable fields
                        LoadAssemblyData()
                        ShowAssemblyComponents()

                        gpxAssemblyData.Enabled = True
                        cmdDeleteComponent.Enabled = True
                        cmdUpdateCost.Enabled = True
                        cmdAddComponent.Enabled = True
                        cmdClearAssembly.Enabled = True
                        chkSerializedAssembly.Checked = False
                        chkSerializedAssembly.Enabled = False

                        Me.dgvAssemblyLineQuery.Columns("UnitCostColumn").Visible = True
                    End If
                End If
            Else
                gpxAssemblyData.Enabled = False
                cmdDeleteComponent.Enabled = False
                cmdUpdateCost.Enabled = False
                cmdAddComponent.Enabled = False
                cmdClearAssembly.Enabled = False
                chkSerializedAssembly.Checked = True
                chkSerializedAssembly.Enabled = False

                ClearAssemblyComponents()
            End If
        End If
    End Sub

    Private Sub cboComponentPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComponentPartNumber.SelectedIndexChanged
        If isLoaded Then
            LoadAssemblyComponentCost()
            LoadComponentDescriptionByPart()
        End If
    End Sub

    Private Sub cboComponentDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComponentDescription.SelectedIndexChanged
        If isLoaded Then
            LoadComponentPartByDescription()
        End If
    End Sub

    Private Sub cboWarehouse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWarehouse.SelectedIndexChanged
        'Load Cost
        '********************************************************************************************************
        Dim WarehouseID As String = ""
        Dim ConsignmentWarehouse As String = ""

        ConsignmentWarehouse = cboWarehouse.Text

        'Validate Consignment Warehouse
        Select Case ConsignmentWarehouse
            Case "Downey"
                WarehouseID = "DCW"
            Case "Phoenix"
                WarehouseID = "PCW"
            Case "Hayward"
                WarehouseID = "HCW"
            Case "Bessemer"
                WarehouseID = "BCW"
            Case "Lewisville"
                WarehouseID = "LCW"
            Case "Seattle"
                WarehouseID = "SCW"
            Case "Lyndhurst"
                WarehouseID = "YCW"
            Case "Renton"
                WarehouseID = "RCW"
            Case "Lake Stevens"
                WarehouseID = "LSCW"
            Case "SRL"
                WarehouseID = "SRL"
            Case Else
                WarehouseID = ""
        End Select
        '********************************************************************************************************
        'Get Cost of Consignment Adjustment
        Dim MAXCostDate As Integer = 0
        Dim LastTransactionCost As Double = 0

        Dim MAXCostDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXCostDateCommand As New SqlCommand(MAXCostDateStatement, con)
        MAXCostDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
        MAXCostDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXCostDate = CInt(MAXCostDateCommand.ExecuteScalar)
        Catch ex As Exception
            MAXCostDate = 0
        End Try
        con.Close()

        Dim LastPriceStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
        Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
        LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastPriceCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionCost = CDbl(LastPriceCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionCost = 0
        End Try
        con.Close()

        If cboWarehouse.Text = "" Then
            txtConsignmentUnitCost.Clear()
        Else
            txtConsignmentUnitCost.Text = LastTransactionCost
        End If
    End Sub

    Private Sub cboAddAccessories_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddAccessories.SelectedIndexChanged
        If cboAddAccessories.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub cboPartNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.Leave
        If Not String.IsNullOrEmpty(cboPartNumber.Text) AndAlso cboPartNumber.SelectedIndex = -1 Then
            cboPartNumber.Text = cboPartNumber.Text.Trim(" "c)
        End If
    End Sub

    'TextBox Routines

    Private Sub txtLongDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongDescription.TextChanged
        If txtLongDescription.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtOldPartNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOldPartNumber.TextChanged
        If txtOldPartNumber.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtStandardUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStandardUnitCost.TextChanged
        If isLoaded Then
            StandardCost = Val(txtStandardUnitCost.Text)
            If txtStandardUnitCost.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub txtStandardUnitPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStandardUnitPrice.TextChanged
        If isLoaded Then
            StandardPrice = Val(txtStandardUnitPrice.Text)
            If txtStandardUnitPrice.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub txtMinimumStock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMinimumStock.TextChanged
        If txtMinimumStock.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtMaximumStock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaximumStock.TextChanged
        If txtMaximumStock.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtPieceWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPieceWeight.TextChanged
        If txtPieceWeight.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtBoxCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxCount.TextChanged
        If txtBoxCount.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtPalletCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPalletCount.TextChanged
        If txtPalletCount.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtNominalDiameter_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNominalDiameter.KeyUp
        If txtNominalDiameter.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtNominalLength_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNominalLength.KeyUp
        If txtNominalLength.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtVendorName_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVendorName.KeyUp
        If txtVendorName.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtPieceWeight_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPieceWeight.LostFocus
        LoadWeightsAndPieces()
    End Sub

    Private Sub txtBoxCount_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxCount.LostFocus
        LoadWeightsAndPieces()
    End Sub

    Private Sub txtPalletCount_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPalletCount.LostFocus
        LoadWeightsAndPieces()
    End Sub

    'Checkbox Routines

    Private Sub chkCanadian_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCanadian.CheckedChanged
        If chkCanadian.Checked = True Then
            chkAmerican.Checked = False
        End If
        If chkCanadian.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub chkAmerican_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAmerican.CheckedChanged
        If chkAmerican.Checked = True Then
            chkCanadian.Checked = False
        End If
        If chkAmerican.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub chkDeactivatePart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDeactivatePart.CheckedChanged
        If chkDeactivatePart.Checked = True Then
            cboItemClass.Text = "DEACTIVATED-PART"
        Else
            If cboItemClass.Text = "DEACTIVATED-PART" Then
                cboItemClass.Enabled = True
            Else
                'Skip
            End If
        End If
    End Sub

    Private Sub chkNonLotNumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNonLotNumber.CheckedChanged
        If chkNonLotNumber.Checked = True Then
            cboItemClass.Text = "TW WELD STUD W/O LOT"
        Else
            'DO NOTHING
        End If
    End Sub

    Private Sub chkShowSerialNumbersByDivision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowSerialNumbersByDivision.CheckedChanged
        If chkShowSerialNumbersByDivision.Checked = True Then
            ShowSerialNumbersByDivision()
        Else
            ShowSerialNumbers()
        End If
    End Sub

    'Command Button Routines

    Private Sub cmdAddComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddComponent.Click
        If cboPartNumber.Text = "" Or cboComponentPartNumber.Text = "" Then
            MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                LoadQuantityPending()
                tabItemMaintenance.SelectedIndex = 0
                LoadLastPurchaseCost()
                LoadLastSalePrice()
                LoadLastActivity()
                LoadDataFields()
                LoadAverageCost()
                LoadLastAssemblyCost()
                LoadMTDSales()
                LoadYTDSales()
                LoadConsignmentInventory()
                LoadAssemblyData()
                ShowAssemblyComponents()
                ShowSerialNumbers()
                Exit Sub
            End If

            LockBatch()

            'Determine Status based on check box
            If chkSerializedAssembly.Checked = True Then
                SerializedStatus = "YES"
            Else
                SerializedStatus = "NO"
            End If

            AssemblyDate = dtpAssemblyDate.Value

            ''checks the assembly header table and will update or insert accordingly
            updateOrInsertIntoAssemblyHeaderTable()

            Dim MAXLineNumberStatement As String = "SELECT MAX(ComponentLineNumber) FROM AssemblyLineTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
            Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberStatement, con)
            MAXLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXLineNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastLineNumber = 0
            End Try
            con.Close()

            NextLineNumber = LastLineNumber + 1

            'Create command to add line to assembly
            cmd = New SqlCommand("INSERT INTO AssemblyLineTable (ComponentLineNumber, AssemblyPartNumber, ComponentPartNumber, ComponentPartDescription, Quantity, UnitCost, ExtendedCost, LineComment, DivisionID)Values(@ComponentLineNumber, @AssemblyPartNumber, @ComponentPartNumber, @ComponentPartDescription, @Quantity, @UnitCost, @ExtendedCost, @LineComment, @DivisionID)", con)

            With cmd.Parameters
                .Add("@ComponentLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboComponentPartNumber.Text
                .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = cboComponentDescription.Text
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtComponentQuantity.Text)
                .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtComponentCost.Text)
                .Add("@ExtendedCost", SqlDbType.VarChar).Value = Val(txtComponentQuantity.Text) * Val(txtComponentCost.Text)
                .Add("@LineComment", SqlDbType.VarChar).Value = txtComponentComment.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Update Cost in Header Table
            Dim SUMExtendedCostStatement As String = "SELECT SUM(ExtendedCost) FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
            Dim SUMExtendedCostCommand As New SqlCommand(SUMExtendedCostStatement, con)
            SUMExtendedCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SUMExtendedCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMExtendedCost = CDbl(SUMExtendedCostCommand.ExecuteScalar)
            Catch ex As Exception
                SUMExtendedCost = 0
            End Try
            con.Close()

            'Create command to save assembly data
            cmd = New SqlCommand("UPDATE AssemblyHeaderTable SET TotalCost = @TotalCost WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@TotalCost", SqlDbType.VarChar).Value = SUMExtendedCost
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            If cboPurchaseProductID.Text <> "ASSEMBLY" Then
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE ItemList SET PurchProdLineID = @PurchProdLineID WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cboPurchaseProductID.Text = "ASSEMBLY"
            Else
                'Do nothing
            End If

            ClearAssemblyLines()
            ShowAssemblyComponents()
        End If
    End Sub

    Private Sub cmdDeleteComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteComponent.Click
        If cboPartNumber.Text = "" Or cboDeleteComponent.Text = "" Then
            MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                LoadQuantityPending()
                tabItemMaintenance.SelectedIndex = 0
                LoadLastPurchaseCost()
                LoadLastSalePrice()
                LoadLastActivity()
                LoadDataFields()
                LoadAverageCost()
                LoadLastAssemblyCost()
                LoadMTDSales()
                LoadYTDSales()
                LoadConsignmentInventory()
                LoadAssemblyData()
                ShowAssemblyComponents()
                ShowSerialNumbers()
                Exit Sub
            End If
            LockBatch()
            'Create command to delete line
            cmd = New SqlCommand("DELETE FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND Quantity = @Quantity AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@Quantity", SqlDbType.VarChar).Value = 0
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowAssemblyComponents()
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Validate before saving
        If canSave() Then
            LockBatch()
            '*****************************************************************************************************
            ValidatePPLAndSPL()

            If CheckPPL = 1 And CheckSPL = 1 Then
                'Continue
            Else
                MsgBox("You must select a valid Sales Product Line and Purchase Product Line.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*****************************************************************************************************
            'Compare item class with saved item class and log any changes
            Dim OldItemClass As String = ""
            Dim NewItemClass As String = ""

            NewItemClass = cboItemClass.Text

            Dim OldItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim OldItemClassCommand As New SqlCommand(OldItemClassStatement, con)
            OldItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            OldItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OldItemClass = CStr(OldItemClassCommand.ExecuteScalar)
            Catch ex As Exception
                OldItemClass = ""
            End Try
            con.Close()

            Try
                If NewItemClass <> OldItemClass Then 'Log change
                    cmd = New SqlCommand("INSERT INTO TFPItemListActivityLog (ActivityDateTime, UserID, DivisionID, ItemID, ChangedField, OriginalValue, NewValue) values (@ActivityDateTime, @UserID, @DivisionID, @ItemID, @ChangedField, @OriginalValue, @NewValue)", con)

                    With cmd.Parameters
                        .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@ChangedField", SqlDbType.VarChar).Value = "Item Class"
                        .Add("@OriginalValue", SqlDbType.VarChar).Value = OldItemClass
                        .Add("@NewValue", SqlDbType.VarChar).Value = NewItemClass
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Catch ex As Exception
                'Skip
            End Try
            '*****************************************************************************************************
            If CheckItemClass = "DEACTIVATED-PART" Then
                'Check for Quantity, Open PO Amount, Open SO Amount
                Dim CheckSOQuantityOpenStatement As String = "SELECT QuantityOpen FROM SalesOrderQuantityStatus WHERE ItemID = @ItemID AND DivisionKey = @DivisionKey"
                Dim CheckSOQuantityOpenCommand As New SqlCommand(CheckSOQuantityOpenStatement, con)
                CheckSOQuantityOpenCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                CheckSOQuantityOpenCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckSOQuantityOpen = CDbl(CheckSOQuantityOpenCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckSOQuantityOpen = 0
                End Try
                con.Close()

                Dim CheckPOQuantityOpenStatement As String = "SELECT POQuantityOpen FROM PurchaseOrderQuantityStatus WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim CheckPOQuantityOpenCommand As New SqlCommand(CheckPOQuantityOpenStatement, con)
                CheckPOQuantityOpenCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                CheckPOQuantityOpenCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckPOQuantityOpen = CDbl(CheckPOQuantityOpenCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckPOQuantityOpen = 0
                End Try
                con.Close()

                Dim CheckQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim CheckQOHCommand As New SqlCommand(CheckQOHStatement, con)
                CheckQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                CheckQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckQOH = CDbl(CheckQOHCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckQOH = 0
                End Try
                con.Close()

                Dim CheckAdjQuantityPendingStatement As String = "SELECT COUNT(PartNumber) FROM InventoryAdjustmentTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND Status = 'OPEN'"
                Dim CheckAdjQuantityPendingCommand As New SqlCommand(CheckAdjQuantityPendingStatement, con)
                CheckAdjQuantityPendingCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                CheckAdjQuantityPendingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckAdjQuantityPending = CDbl(CheckAdjQuantityPendingCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckAdjQuantityPending = 0
                End Try
                con.Close()

                If CheckPOQuantityOpen = 0 And CheckQOH = 0 And CheckSOQuantityOpen = 0 And CheckAdjQuantityPending = 0 Then
                    Try
                        'Create command to update database and fill with text box enties
                        cmd = New SqlCommand("UPDATE ItemList SET ItemClass = @ItemClass WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        MsgBox("Part has been de-activated.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    Catch ex10 As Exception
                        Exit Sub
                    End Try
                    needsSaved = False
                Else
                    MsgBox("You cannot de-activate this part number - it has current activity.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
            '************************************************************************************************************************
            'For De-activated parts you do not have to go any further
            '************************************************************************************************************************
            'Convert to canadian date is necessary
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                AssemblyDate = dtpAssemblyDate.Value

                'Canadian parts require a vendor or Vendor Class
                If cboVendorID.Text = "" And chkAmerican.Checked = False And chkCanadian.Checked = False Then
                    MsgBox("You must select a valid vendor or vendor class for this part.", MsgBoxStyle.OkOnly)
                    cboVendorID.Focus()
                Else
                    'Determine vendor / vendor class
                    If cboVendorID.Text = "" Then
                        If chkAmerican.Checked = True And chkCanadian.Checked = False Then
                            VendorID = "AMERICAN"
                        ElseIf chkAmerican.Checked = False And chkCanadian.Checked = True Then
                            VendorID = "CANADIAN"
                        Else
                            VendorID = "CANADIAN"
                        End If
                    Else
                        VendorID = cboVendorID.Text
                    End If

                    'Checks to see if the itemID exsists and will insert or update accordingly
                    UpdateOrInsertIntoItemList()

                    Try
                        UpdateComponentDescription()
                    Catch ex As Exception
                        'Skip on fail
                    End Try

                    If DuplicatePartDescription = "YES" Then
                        Exit Sub
                    Else
                        'Do nothing
                    End If

                    If cboPurchaseProductID.Text = "ASSEMBLY" Then
                        If chkSerializedAssembly.Checked = True Then
                            SerializedStatus = "YES"
                        Else
                            SerializedStatus = "NO"
                        End If

                        'Declare variable to retrive Assembly Cost
                        Dim SUMExtendedCost As Double

                        'Load Cost Data
                        Dim SUMExtendedCostStatement As String = "SELECT SUM(ExtendedCost) FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                        Dim SUMExtendedCostCommand As New SqlCommand(SUMExtendedCostStatement, con)
                        SUMExtendedCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        SUMExtendedCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SUMExtendedCost = CDbl(SUMExtendedCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            SUMExtendedCost = 0
                        End Try
                        con.Close()

                        ''checks the assembly header table and will update or insert accordingly
                        updateOrInsertIntoAssemblyHeaderTable()
                    Else
                        'Do nothing - Part is not an assembly
                    End If

                    MsgBox("Item Data has been saved.", MsgBoxStyle.OkOnly)
                    Dim nbr As String = cboPartNumber.Text
                    isLoaded = False
                    LoadPartNumber()
                    cboPartNumber.Text = nbr
                    isLoaded = True
                    needsSaved = False
                End If
            Else
                'Standard date for non-canadian
                CreationDate = dtpItemCreationDate.Value

                ''checks to see if the itemID exsists and will insert or update accordingly
                UpdateOrInsertIntoItemList()

                Try
                    UpdateComponentDescription()
                Catch ex As Exception
                    'Skip on fail
                End Try

                If DuplicatePartDescription = "YES" Then
                    Exit Sub
                Else
                    'Do nothing
                End If
                '****************************************************************************************
                'If part is a weld stud, save piece across all divisions.
                If cboDivisionID.Text = "TWD" Then
                    Dim CurrentItemClass As String = cboItemClass.Text

                    Select Case CurrentItemClass
                        Case "TW SC", "TW CA", "TW DS", "TW DB", "TW TT", "TW TP", "TW NT", "TW PS", "TW CD"
                            If Val(txtPieceWeight.Text) = 0 Then
                                'Skip
                            Else
                                'Create command to update database and fill with text box enties
                                cmd = New SqlCommand("UPDATE ItemList SET PieceWeight = @PieceWeight WHERE ItemID = @ItemID", con)

                                With cmd.Parameters
                                    .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                                    .Add("@PieceWeight", SqlDbType.VarChar).Value = Val(txtPieceWeight.Text)
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                        Case Else
                            'No update
                    End Select
                End If
                '*****************************************************************************************
                If cboPurchaseProductID.Text = "ASSEMBLY" Then
                    If chkSerializedAssembly.Checked = True Then
                        SerializedStatus = "YES"
                    Else
                        SerializedStatus = "NO"
                    End If

                    'Declare variable to retrive Assembly Cost
                    Dim SUMExtendedCost As Double

                    'Load Cost Data
                    Dim SUMExtendedCostStatement As String = "SELECT SUM(ExtendedCost) FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim SUMExtendedCostCommand As New SqlCommand(SUMExtendedCostStatement, con)
                    SUMExtendedCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    SUMExtendedCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SUMExtendedCost = CDbl(SUMExtendedCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        SUMExtendedCost = 0
                    End Try
                    con.Close()

                    ''checks the assembly header table and will update or insert accordingly
                    updateOrInsertIntoAssemblyHeaderTable()
                Else
                    'Do nothing - Part is not an assembly
                End If

                MsgBox("Item Data has been saved.", MsgBoxStyle.OkOnly)

                Dim nbr As String = cboPartNumber.Text
                'cboPartNumber.SelectedIndex = -1
                isLoaded = False
                LoadPartNumber()
                cboPartNumber.Text = nbr
                isLoaded = True
                needsSaved = False
            End If
        End If
    End Sub

    Private Sub cmdInventoryRacking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInventoryRacking.Click
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewItemMaintenanceRacking As New ItemMaintenanceRacking
            Dim result = NewItemMaintenanceRacking.ShowDialog()
        End Using
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ''Clears the list of changed fields
        lstChangedFields.Clear()
        'Clear the text boxes
        unlockBatch()
        ClearVariables()
        ClearData()
        ClearSerialNumbers()
        ClearLotNumbers()
        ClearAssemblyComponents()
        needsSaved = False
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Form Logout
        FormLogoutRoutine()
        unlockBatch()

        'Prompt before exiting
        If cboPartNumber.Text = "" Then
            'ClearVariables()
            'ClearData()
            GlobalItemListingPartNumber = ""
            GlobalMaintenancePartNumber = ""
            GlobalPartNumberLookup = ""
            Me.Dispose()
            Me.Close()
        Else
            If cboPartNumber.SelectedIndex = -1 Then
                needsSaved = True
            End If
            If needsSaved = False Then
                'ClearVariables()
                'ClearData()
                GlobalItemListingPartNumber = ""
                GlobalMaintenancePartNumber = ""
                GlobalPartNumberLookup = ""
                Me.Dispose()
                Me.Close()
                Exit Sub
            End If
            If isSomeoneEditing() Then
                'ClearVariables()
                'ClearData()
                GlobalItemListingPartNumber = ""
                GlobalMaintenancePartNumber = ""
                GlobalPartNumberLookup = ""
                Me.Dispose()
                Me.Close()
                Exit Sub
            End If
            If EmployeeSecurityCode = 1016 Then
                'ClearVariables()
                'ClearData()
                GlobalItemListingPartNumber = ""
                GlobalMaintenancePartNumber = ""
                GlobalPartNumberLookup = ""
                Me.Dispose()
                Me.Close()
                Exit Sub
            End If

            Dim button As DialogResult = MessageBox.Show("Do you wish to save these changes?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                VerifyItemClass()

                If CheckItemClass = "" Or CheckItemClass = "INVALID" Then
                    MsgBox("You must have a valid Item Class selected.", MsgBoxStyle.OkOnly)
                    cboItemClass.Focus()
                ElseIf CheckItemClass = "DEACTIVATED-PART" Then
                    'Check for Quantity, Open PO Amount, Open SO Amount
                    Dim CheckSOQuantityOpenStatement As String = "SELECT QuantityOpen FROM SalesOrderQuantityStatus WHERE ItemID = @ItemID AND DivisionKey = @DivisionKey"
                    Dim CheckSOQuantityOpenCommand As New SqlCommand(CheckSOQuantityOpenStatement, con)
                    CheckSOQuantityOpenCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                    CheckSOQuantityOpenCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckSOQuantityOpen = CDbl(CheckSOQuantityOpenCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckSOQuantityOpen = 0
                    End Try
                    con.Close()

                    Dim CheckPOQuantityOpenStatement As String = "SELECT POQuantityOpen FROM PurchaseOrderQuantityStatus WHERE  PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim CheckPOQuantityOpenCommand As New SqlCommand(CheckPOQuantityOpenStatement, con)
                    CheckPOQuantityOpenCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    CheckPOQuantityOpenCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckPOQuantityOpen = CDbl(CheckPOQuantityOpenCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckPOQuantityOpen = 0
                    End Try
                    con.Close()

                    Dim CheckQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE  ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim CheckQOHCommand As New SqlCommand(CheckQOHStatement, con)
                    CheckQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                    CheckQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckQOH = CDbl(CheckQOHCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckQOH = 0
                    End Try
                    con.Close()

                    If CheckPOQuantityOpen = 0 And CheckQOH = 0 And CheckSOQuantityOpen = 0 Then
                        Try
                            'Create command to update database and fill with text box enties
                            cmd = New SqlCommand("UPDATE ItemList SET ItemClass = @ItemClass WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'MsgBox("Part has been deactivated.", MsgBoxStyle.OkOnly)
                        Catch ex10 As Exception
                            'Skip
                        End Try
                    Else
                        'MsgBox("You cannot deactivate this part number - it has current activity.", MsgBoxStyle.OkOnly)
                    End If
                    ClearVariables()
                    ClearData()
                    GlobalItemListingPartNumber = ""
                    GlobalMaintenancePartNumber = ""
                    GlobalPartNumberLookup = ""
                    Me.Dispose()
                    Me.Close()
                Else
                    'Convert to canadian date is necessary
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        'Canadian parts require a vendor or Vendor Class
                        If cboVendorID.Text = "" And chkAmerican.Checked = False And chkCanadian.Checked = False Then
                            MsgBox("You must select a valid vendor or vendor class for this part.", MsgBoxStyle.OkOnly)
                            cboVendorID.Focus()
                        Else
                            'Determine vendor / vendor class
                            If cboVendorID.Text = "" Then
                                If chkAmerican.Checked = True And chkCanadian.Checked = False Then
                                    VendorID = "AMERICAN"
                                ElseIf chkAmerican.Checked = False And chkCanadian.Checked = True Then
                                    VendorID = "CANADIAN"
                                Else
                                    VendorID = "CANADIAN"
                                End If
                            Else
                                VendorID = cboVendorID.Text
                            End If

                            'Convert to canadian date
                            AssemblyDate = dtpAssemblyDate.Value

                            ''checks to see if the itemID exsists and will insert or update accordingly
                            UpdateOrInsertIntoItemList()

                            Try
                                UpdateComponentDescription()
                            Catch ex As Exception
                                'Skip on fail
                            End Try

                            ClearVariables()
                            ClearData()
                            GlobalItemListingPartNumber = ""
                            GlobalMaintenancePartNumber = ""
                            GlobalPartNumberLookup = ""
                            Me.Dispose()
                            Me.Close()
                        End If
                    Else
                        'Use standard date
                        CreationDate = dtpItemCreationDate.Value

                        ''checks to see if the itemID exsists and will insert or update accordingly
                        UpdateOrInsertIntoItemList()

                        Try
                            UpdateComponentDescription()
                        Catch ex As Exception
                            'Skip on fail
                        End Try
                        '****************************************************************************************
                        'If part is a weld stud, save piece across all divisions.
                        If cboDivisionID.Text = "TWD" Then
                            Dim CurrentItemClass As String = cboItemClass.Text

                            Select Case CurrentItemClass
                                Case "TW SC", "TW CA", "TW DS", "TW DB", "TW TT", "TW TP", "TW NT", "TW PS", "TW CD"
                                    If Val(txtPieceWeight.Text) = 0 Then
                                        'Skip
                                    Else
                                        'Create command to update database and fill with text box enties
                                        cmd = New SqlCommand("UPDATE ItemList SET PieceWeight = @PieceWeight WHERE ItemID = @ItemID", con)

                                        With cmd.Parameters
                                            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    End If
                                Case Else
                                    'No update
                            End Select
                        End If
                        '*****************************************************************************************
                        ClearVariables()
                        ClearData()
                        GlobalItemListingPartNumber = ""
                        GlobalMaintenancePartNumber = ""
                        GlobalPartNumberLookup = ""
                        Me.Dispose()
                        Me.Close()
                    End If
                End If
            ElseIf button = DialogResult.No Then
                ClearVariables()
                ClearData()
                GlobalItemListingPartNumber = ""
                GlobalMaintenancePartNumber = ""
                GlobalPartNumberLookup = ""
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboPartNumber.Text = "" Then
            MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                LoadQuantityPending()
                tabItemMaintenance.SelectedIndex = 0
                LoadLastPurchaseCost()
                LoadLastSalePrice()
                LoadLastActivity()
                LoadDataFields()
                LoadAverageCost()
                LoadLastAssemblyCost()
                LoadMTDSales()
                LoadYTDSales()
                LoadConsignmentInventory()
                LoadAssemblyData()
                ShowAssemblyComponents()
                ShowSerialNumbers()
                Exit Sub
            End If
            Dim CheckItemOnSOStatement As String = "SELECT COUNT(ItemID) FROM SalesOrderLineTable WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim CheckItemOnSOCommand As New SqlCommand(CheckItemOnSOStatement, con)
            CheckItemOnSOCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            CheckItemOnSOCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckItemOnSO = CInt(CheckItemOnSOCommand.ExecuteScalar)
            Catch ex As Exception
                CheckItemOnSO = 0
            End Try
            con.Close()

            Dim CheckItemOnPOStatement As String = "SELECT COUNT(PartNumber) FROM PurchaseOrderLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim CheckItemOnPOCommand As New SqlCommand(CheckItemOnPOStatement, con)
            CheckItemOnPOCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            CheckItemOnPOCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckItemOnPO = CInt(CheckItemOnPOCommand.ExecuteScalar)
            Catch ex As Exception
                CheckItemOnPO = 0
            End Try
            con.Close()

            Dim CheckItemOnTTStatement As String = "SELECT COUNT(PartNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim CheckItemOnTTCommand As New SqlCommand(CheckItemOnTTStatement, con)
            CheckItemOnTTCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            CheckItemOnTTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckItemOnTT = CInt(CheckItemOnTTCommand.ExecuteScalar)
            Catch ex As Exception
                CheckItemOnTT = 0
            End Try
            con.Close()

            CheckAll = CheckItemOnPO + CheckItemOnSO + CheckItemOnTT

            If CheckAll > 0 Then
                MsgBox("You cannot delete this item because it has activity.", MsgBoxStyle.OkOnly)
                con.Close()
            Else
                'Prompt before deleting
                Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Item?", "DELETE ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    lstChangedFields.Clear()
                    Dim tmp As New usefulFunctions.FieldData
                    tmp.ColumnName = "DELETED"
                    tmp.OriginalValue = "NO"
                    tmp.NewValue = "YES"
                    lstChangedFields.Add(tmp)
                    UpdateLog()

                    'Create command to delete Part Number from database
                    cmd = New SqlCommand("Delete FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear the text boxes
                    LoadPartNumber()
                    ClearVariables()
                    ClearData()
                    ShowAssemblyComponents()
                    ShowSerialNumbers()
                ElseIf button = DialogResult.No Then
                    cboPartNumber.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdTextSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTextSearch.Click
        ShowSerialNumbers()
    End Sub

    Private Sub cmdClearTextSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearTextSearch.Click
        txtTextSearch.Clear()
        ShowSerialNumbers()
    End Sub

    Private Sub cmdItemPriceSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemPriceSheet.Click
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = cboDivisionID.Text
        GlobalPriceBracketSource = "Item Maintenance"

        Using NewSOPriceBracket As New SOPriceBracket
            Dim result = NewSOPriceBracket.ShowDialog()
        End Using
    End Sub

    Private Sub cmdClearAssembly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAssembly.Click
        dtpAssemblyDate.Text = ""
        txtComponentComment.Clear()
        txtComponentQuantity.Clear()
        txtAssemblyComment.Clear()
        cboComponentPartNumber.SelectedIndex = -1
        cboComponentDescription.SelectedIndex = -1
        dtpAssemblyDate.Focus()
    End Sub

    Private Sub cmdItemHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemHistory.Click
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewItemMaintenancePartHistory As New ItemMaintenancePartHistory
            Dim Result = NewItemMaintenancePartHistory.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintCustomLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCustomLabel.Click
        fillLabelVariables()
        Dim itm As BarcodeLabel.itemComment
        itm.partNumber = V00
        itm.description1 = V04
        itm.description2 = V05
        itm.description3 = V06
        itm.comment1 = V07
        itm.comment2 = V08
        itm.comment3 = V09
        itm.additionalComment = V10
        itm.quantity = V11
        Dim bc As New BarcodeLabel
        bc.itemCommentLabel(itm, nbrLabelCount.Value)
        bc.PrintBarcodeLine()
    End Sub

    Private Sub cmdAdjustQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdjustQuantity.Click
        'Validate Part Number
        Dim CheckPartNumber As Integer = 0
        Dim ValidationRule As String = ""
        Dim ConsignmentWarehouse As String = ""
        Dim WarehouseID As String = ""
        Dim AdjustmentQuantity As Double = 0
        Dim GLInventoryAccount As String = ""
        Dim GLIssuesAccount As String = "59790"
        Dim LastTransactionCost As Double = 0
        Dim ExtendedTransactionCost As Double = 0

        Dim CheckPartNumberCommand As New SqlCommand("SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
        CheckPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CheckPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPartNumber = CInt(CheckPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPartNumber = 0
        End Try
        con.Close()

        ConsignmentWarehouse = cboWarehouse.Text

        'Validate Consignment Warehouse
        Select Case ConsignmentWarehouse
            Case "Downey"
                WarehouseID = "DCW"
                GLInventoryAccount = "12630"
            Case "Phoenix"
                WarehouseID = "PCW"
                GLInventoryAccount = "12660"
            Case "Hayward"
                WarehouseID = "HCW"
                GLInventoryAccount = "12620"
            Case "Bessemer"
                WarehouseID = "BCW"
                GLInventoryAccount = "12610"
            Case "Lewisville"
                WarehouseID = "LCW"
                GLInventoryAccount = "12650"
            Case "Seattle"
                WarehouseID = "SCW"
                GLInventoryAccount = "12640"
            Case "Lyndhurst"
                WarehouseID = "YCW"
                GLInventoryAccount = "12600"
            Case "Renton"
                WarehouseID = "RCW"
                GLInventoryAccount = "12680"
            Case "Lake Stevens"
                WarehouseID = "LSCW"
                GLInventoryAccount = "12690"
            Case "SRL"
                WarehouseID = "SRL"
                GLInventoryAccount = "12670"
            Case Else
                WarehouseID = ""
                GLInventoryAccount = "12100"
        End Select

        If txtAdjustQuantity.Text = "" Or Val(txtAdjustQuantity.Text) = 0 Or Not IsNumeric(txtAdjustQuantity.Text) Or WarehouseID = "" Then
            ValidationRule = "FAIL"
        Else
            ValidationRule = "NO FAIL"
        End If

        If CheckPartNumber = 0 Or ValidationRule = "FAIL" Then
            MsgBox("Check part number, warehouse, and quantity.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If

        'Prompt before adjustment
        Dim button As DialogResult = MessageBox.Show("Do you wish to adjust the inventory for this warehouse", "ADJUST INVENTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then

            Dim NextConsignmentNumber, LastConsignmentNumber As Integer

            'Get next Adjustment Number
            Dim MaxAdjustmentNumberCommand As New SqlCommand("SELECT MAX(ConsignmentAdjustmentNumber) FROM ConsignmentAdjustmentTable", con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastConsignmentNumber = CInt(MaxAdjustmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastConsignmentNumber = 23300000
            End Try
            con.Close()

            NextConsignmentNumber = LastConsignmentNumber + 1

            Try
                AdjustmentQuantity = Val(txtAdjustQuantity.Text)

                If rdoAdd.Checked = True And AdjustmentQuantity > 0 Then
                    'Do nothing - positive number for add
                ElseIf rdoAdd.Checked = True And AdjustmentQuantity < 0 Then
                    AdjustmentQuantity = AdjustmentQuantity * -1
                ElseIf rdoSubtract.Checked = True And AdjustmentQuantity > 0 Then
                    AdjustmentQuantity = AdjustmentQuantity * -1
                ElseIf rdoSubtract.Checked And AdjustmentQuantity < 0 Then
                    'Do nothing Negative Number for subtract
                Else
                    'Do nothing
                End If
                '********************************************************************************************************
                'Get Cost of Consignment Adjustment
                If Val(txtConsignmentUnitCost.Text) = 0 Then
                    Dim MAXCostDate As Integer = 0

                    Dim MAXCostDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                    Dim MAXCostDateCommand As New SqlCommand(MAXCostDateStatement, con)
                    MAXCostDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
                    MAXCostDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXCostDate = CInt(MAXCostDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXCostDate = 0
                    End Try
                    con.Close()

                    Dim LastPriceStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                    Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                    LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    LastPriceCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastTransactionCost = CDbl(LastPriceCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastTransactionCost = 0
                    End Try
                    con.Close()
                Else
                    LastTransactionCost = Val(txtConsignmentUnitCost.Text)
                End If

                ExtendedTransactionCost = AdjustmentQuantity * LastTransactionCost
                ExtendedTransactionCost = Math.Round(ExtendedTransactionCost, 2)
                '********************************************************************************************************
                'Create command to save assembly data
                cmd = New SqlCommand("INSERT INTO ConsignmentAdjustmentTable (ConsignmentAdjustmentNumber, PartNumber, PartDescription, Quantity , UnitCost, ExtendedAmount, DivisionID, AdjustmentDate, CustomerClass, Comment, PostDate, PostedBy) Values (@ConsignmentAdjustmentNumber, @PartNumber, @PartDescription, @Quantity , @UnitCost, @ExtendedAmount, @DivisionID, @AdjustmentDate, @CustomerClass, @Comment, @PostDate, @PostedBy)", con)

                With cmd.Parameters
                    .Add("@ConsignmentAdjustmentNumber", SqlDbType.VarChar).Value = NextConsignmentNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = AdjustmentQuantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = LastTransactionCost
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedTransactionCost
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpAdjDate.Text
                    .Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseID
                    .Add("@Comment", SqlDbType.VarChar).Value = txtAdjustmentComment.Text
                    .Add("@PostDate", SqlDbType.VarChar).Value = Now()
                    .Add("@PostedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue
            End Try
            '********************************************************************************************************
            'Create Inventory Transaction
            'Enter into Inventory Transaction Table for Warehouse ID
            Dim LastITNumber2 As Integer = 0
            Dim NextITNumber2 As Integer = 0

            'Find Next Transaction Number
            Dim ITNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
            Dim ITNumber2Command As New SqlCommand(ITNumber2Statement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastITNumber2 = CInt(ITNumber2Command.ExecuteScalar)
            Catch ex As Exception
                LastITNumber2 = 867500000
            End Try
            con.Close()

            NextITNumber2 = LastITNumber2 + 1

            Try
                'Write Data to the Inventory Transaction Table
                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                With cmd.Parameters
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextITNumber2
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpAdjDate.Text
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Consignment Adjustment"
                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextConsignmentNumber
                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = 1
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = AdjustmentQuantity
                    .Add("@ItemCost", SqlDbType.VarChar).Value = LastTransactionCost
                    .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedTransactionCost
                    .Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip
            End Try
            '********************************************************************************************************
            'Enter into Cost Tier for Warehouse ID

            'Extract the Upper and Lower Limit of the Inventory Costing Table
            Dim NewUpperLimitCosting, LowerLimitCosting, UpperLimitCosting As Double
            Dim MaxTransactionNumber As Integer

            Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
            MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                MaxTransactionNumber = 0
            End Try
            con.Close()

            Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
            UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
            UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                UpperLimitCosting = CDbl(UpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                UpperLimitCosting = 0
            End Try
            con.Close()
            '********************************************************************************************************
            'Calculate the NEW Lower/Upper Limit for the next post
            LowerLimitCosting = UpperLimitCosting + 1
            NewUpperLimitCosting = LowerLimitCosting + AdjustmentQuantity - 1

            'Get next Transaction Number
            Dim LastCostingTransactionNumber As Integer = 0
            Dim NextCostingTransactionNumber As Integer = 0

            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastCostingTransactionNumber = 63600000
            End Try
            con.Close()

            NextCostingTransactionNumber = LastCostingTransactionNumber + 1

            'Write Values to Inventory Costing Table
            Try
                cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
                    .Add("@CostingDate", SqlDbType.VarChar).Value = dtpAdjDate.Text
                    .Add("@ItemCost", SqlDbType.VarChar).Value = LastTransactionCost
                    .Add("@CostQuantity", SqlDbType.VarChar).Value = AdjustmentQuantity
                    .Add("@Status", SqlDbType.VarChar).Value = "CONSIGNMENT ADJUSTMENT"
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimitCosting
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimitCosting
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NextConsignmentNumber
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = 1
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip
            End Try
            '********************************************************************************************************
            'Create GL Transaction

            'Get next Transaction Number
            Dim LastGLTransactionNumber As Integer = 0
            Dim NextGLTransactionNumber As Integer = 0

            Dim GLTransactionNumberStatement As String = "SELECT MAX(GLTransactionKey) FROM GLTransactionMasterList"
            Dim GLTransactionNumberCommand As New SqlCommand(GLTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastGLTransactionNumber = CInt(GLTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastGLTransactionNumber = 63600000
            End Try
            con.Close()

            NextGLTransactionNumber = LastGLTransactionNumber + 1

            'Write Debit to GL Transactions
            Try
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, DivisionID, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount, GLTransactionComment, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @DivisionID, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount, @GLTransactionComment, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLTransactionNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Consignment Inventory Adjustment"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedTransactionCost
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = WarehouseID + " - Adjustment - " + cboPartNumber.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVENTORYJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Write Credit to GL Transactions
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, DivisionID, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount, GLTransactionComment, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @DivisionID, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount, @GLTransactionComment, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLTransactionNumber + 1
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLIssuesAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Consignment Inventory Adjustment"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedTransactionCost
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = WarehouseID + " - Adjustment - " + cboPartNumber.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVENTORYJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip
            End Try
            '********************************************************************************************************
            'Re-Load QOH
            LoadConsignmentInventory()

            'Clear Fields
            cboWarehouse.SelectedIndex = -1
            txtAdjustQuantity.Clear()
            txtAdjustmentComment.Clear()
            rdoAdd.Checked = True
        End If
    End Sub

    Private Sub cmdUpdateCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCost.Click
        Dim ComponentLineNumber As Integer = 0
        Dim ComponentPartNumber As String = ""
        Dim ComponentExtendedCost As Double = 0
        Dim ComponentQuantity As Double = 0
        Dim ComponentCost As Double = 0
        Dim TotalAssemblyCost As Double = 0

        For Each Row As DataGridViewRow In dgvAssemblyLineQuery.Rows

            Try
                ComponentLineNumber = Row.Cells("ComponentLineNumberColumn").Value
            Catch ex As System.Exception
                ComponentLineNumber = 1
            End Try
            Try
                ComponentPartNumber = Row.Cells("ComponentPartNumberColumn").Value
            Catch ex As System.Exception
                ComponentPartNumber = ""
            End Try
            Try
                ComponentQuantity = Row.Cells("QuantityColumn").Value
            Catch ex As System.Exception
                ComponentQuantity = 0
            End Try
            Try
                ComponentCost = Row.Cells("UnitCostColumn").Value
            Catch ex As System.Exception
                ComponentCost = 0
            End Try

            'Get Current Cost
            'Get FIFO Cost of component
            '******************************************************************************************************************************************
            'Determine FIFO Cost on Part Number to remove from Inventory
            Dim TotalQuantityShipped As Integer = 0
            Dim TotalQuantityAssembled As Integer = 0
            '******************************************************************************************************************************************
            'Determine Total Quantity Shipped
            Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
            TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
            TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalQuantityShipped = CInt(TotalQuantityShippedCommand.ExecuteScalar)
            Catch ex As Exception
                TotalQuantityShipped = 1
            End Try
            con.Close()

            'Determine Total Quantity Assembled
            Dim TotalQuantityAssembledStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber"
            Dim TotalQuantityAssembledCommand As New SqlCommand(TotalQuantityAssembledStatement, con)
            TotalQuantityAssembledCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
            TotalQuantityAssembledCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalQuantityAssembled = CInt(TotalQuantityAssembledCommand.ExecuteScalar)
                TotalQuantityAssembled = TotalQuantityAssembled * -1
            Catch ex As Exception
                TotalQuantityAssembled = 0
            End Try
            con.Close()

            TotalQuantityShipped = TotalQuantityShipped + TotalQuantityAssembled
            '******************************************************************************************************************************************
            'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table

            'Get MAX Number
            Dim MAXTransactionNumber As Integer = 0

            Dim MAXTransactionNumberStatement As String = "SELECT MAX (TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
            Dim MAXTransactionNumberCommand As New SqlCommand(MAXTransactionNumberStatement, con)
            MAXTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
            MAXTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXTransactionNumberCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXTransactionNumber = CInt(MAXTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                MAXTransactionNumber = 0
            End Try
            con.Close()

            Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
            Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
            ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
            ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
            ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ComponentUnitCost = CDbl(ItemCostCommand.ExecuteScalar)
            Catch ex As Exception
                ComponentUnitCost = 0
            End Try
            con.Close()

            'Get Last Transaction Cost if FIFO Cost is Zero
            If ComponentUnitCost = 0 Then
                Dim MAXDate As Integer = 0

                Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXDate = CInt(MAXDateCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXDate = 0
                End Try
                con.Close()

                Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                Catch ex As Exception
                    TransactionCost = 0
                End Try
                con.Close()

                ComponentUnitCost = TransactionCost
            Else
                'Do nothing
            End If

            'Get Stand Cost if FIFO Cost is Zero
            If ComponentUnitCost = 0 Then
                Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ComponentStandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                Catch ex As Exception
                    ComponentStandardCost = 0
                End Try
                con.Close()

                ComponentUnitCost = ComponentStandardCost
            Else
                'Do nothing
            End If

            If ComponentUnitCost = 0 Then
                ComponentUnitCost = ComponentCost
            End If

            ComponentUnitCost = Math.Round(ComponentUnitCost, 4)
            ComponentExtendedCost = ComponentQuantity * ComponentUnitCost
            ComponentExtendedCost = Math.Round(ComponentExtendedCost, 2)
            '**************************************************************************************
            Try
                'Create command to update database
                cmd = New SqlCommand("UPDATE AssemblyLineTable SET UnitCost = @UnitCost, ExtendedCost = @ExtendedCost WHERE ComponentPartNumber = @ComponentPartNumber AND AssemblyPartNumber = @AssemblyPartNumber AND ComponentLineNumber = @ComponentLineNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    .Add("@ComponentLineNumber", SqlDbType.VarChar).Value = ComponentLineNumber
                    .Add("@UnitCost", SqlDbType.VarChar).Value = ComponentUnitCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error updating component cost in assembly

            End Try
            '*************************************************************************************************
            Try
                'Create command to update database
                cmd = New SqlCommand("UPDATE AssemblyLineTable SET UnitCost = @UnitCost, ExtendedCost = @ExtendedCost WHERE ComponentPartNumber = @ComponentPartNumber AND AssemblyPartNumber = @AssemblyPartNumber AND ComponentLineNumber = @ComponentLineNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    .Add("@ComponentLineNumber", SqlDbType.VarChar).Value = ComponentLineNumber
                    .Add("@UnitCost", SqlDbType.VarChar).Value = ComponentUnitCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error updating component cost in assembly

            End Try
            '**************************************************************************************************
            'Clear Variables for next entry
            ComponentCost = 0
            ComponentLineNumber = 0
            ComponentExtendedCost = 0
            ComponentPartNumber = ""
            ComponentQuantity = 0
            ComponentQuantity = 0
            ComponentUnitCost = 0
            ComponentStandardCost = 0
            TransactionCost = 0
            TotalQuantityAssembled = 0
            TotalQuantityShipped = 0
        Next

        'Get Total Assembly Cost and update
        Dim TotalAssemblyCostStatement As String = "SELECT SUM(ExtendedCost) FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim TotalAssemblyCostCommand As New SqlCommand(TotalAssemblyCostStatement, con)
        TotalAssemblyCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        TotalAssemblyCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalAssemblyCost = CDbl(TotalAssemblyCostCommand.ExecuteScalar)
        Catch ex As Exception
            TotalAssemblyCost = 0
        End Try
        con.Close()

        Try
            'Create command to update database
            cmd = New SqlCommand("UPDATE AssemblyHeaderTable SET TotalCost = @TotalCost WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@TotalCost", SqlDbType.VarChar).Value = TotalAssemblyCost
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error updating component cost in assembly

        End Try

        ShowAssemblyComponents()
        LoadLastAssemblyCost()

        MsgBox("Assembly has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdPurchaseHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPurchaseHistory.Click
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewItemMaintenancePurchaseHistory As New ItemMaintenancePurchaseHistory
            Dim Result = NewItemMaintenancePurchaseHistory.ShowDialog()
        End Using
    End Sub

    Private Sub cmdCreateUpdateBrackets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateUpdateBrackets.Click
        If txtBasePrice.Text = "" Or Val(txtBasePrice.Text) = 0 Then
            Dim button1 As DialogResult = MessageBox.Show("Do you wish to enter zero base price? This will delete the price levels.", "UPDATE PRICE BRACKET", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button1 = DialogResult.Yes Then
                'Write to error log
                cmd = New SqlCommand("DELETE FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Price level deleted.", MsgBoxStyle.OkOnly)
                Exit Sub
            ElseIf button1 = DialogResult.No Then
                Exit Sub
            End If
        End If

        If cboItemClass.Text = "" Then
            MsgBox("You must have a valid item class selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Not IsNumeric(txtBasePrice.Text) Then
            MsgBox("Base price must be a number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboPartNumber.Text = "" Then
            MsgBox("You must have a part number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '***********************************************************************************
        'Check to see if it is an update or new entry
        Dim CountPriceBracket As Integer = 0
        Dim PriceItemClass As String = cboItemClass.Text
        Dim M01, M02, M03, M04, M05, M06, M07, M08, M09, M10, M11, M12, M13 As Double
        Dim Price01, Price02, Price03, Price04, Price05, Price06, Price07, Price08, Price09, Price10, Price11, Price12, Price13 As Double
        Dim BasePrice As Double = Val(txtBasePrice.Text)

        Dim CountPriceBracketStatement As String = "SELECT COUNT(PartNumber) FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim CountPriceBracketCommand As New SqlCommand(CountPriceBracketStatement, con)
        CountPriceBracketCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        CountPriceBracketCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountPriceBracket = CInt(CountPriceBracketCommand.ExecuteScalar)
        Catch ex As Exception
            CountPriceBracket = 0
        End Try
        con.Close()

        If CountPriceBracket = 0 Then
            'Calculate each Bracket
            Select Case PriceItemClass
                Case "TW TT", "TW TP", "TW NT", "TW CS"
                    M01 = 3.69845
                    M02 = 2.90515
                    M03 = 2.1134
                    M04 = 1.84948
                    M05 = 1.58557
                    M06 = 1.31959
                    M07 = 1.22423
                    M08 = 1.1567
                    M09 = 1.09876
                    M10 = 1.03093
                    M11 = 1.01546
                    M12 = 1.01031
                    M13 = 1.0
                Case "TW SC", "TW DS"
                    M01 = 3.69845
                    M02 = 2.90515
                    M03 = 2.1134
                    M04 = 1.84948
                    M05 = 1.58557
                    M06 = 1.31959
                    M07 = 1.22423
                    M08 = 1.1567
                    M09 = 1.09876
                    M10 = 1.03093
                    M11 = 1.01546
                    M12 = 1.01031
                    M13 = 1.0
                Case "TW CA", "TW PS", "TW DB", "TW SWR"
                    M01 = 3.75654
                    M02 = 2.95079
                    M03 = 2.1466
                    M04 = 1.87853
                    M05 = 1.61047
                    M06 = 1.34031
                    M07 = 1.24346
                    M08 = 1.17487
                    M09 = 1.11602
                    M10 = 1.04712
                    M11 = 1.02094
                    M12 = 1.01047
                    M13 = 1.0
                Case Else
                    M01 = 3.5
                    M02 = 2.75
                    M03 = 2.0
                    M04 = 1.75
                    M05 = 1.5
                    M06 = 1.25
                    M07 = 1.15
                    M08 = 1.1
                    M09 = 1.05
                    M10 = 1.0
                    M11 = 1.0
                    M12 = 1.0
                    M13 = 1.0
            End Select

            'Calculate Bracket Pricing
            Price01 = BasePrice * M01
            Price02 = BasePrice * M02
            Price03 = BasePrice * M03
            Price04 = BasePrice * M04
            Price05 = BasePrice * M05
            Price06 = BasePrice * M06
            Price07 = BasePrice * M07
            Price08 = BasePrice * M08
            Price09 = BasePrice * M09
            Price10 = BasePrice * M10
            Price11 = BasePrice * M11
            Price12 = BasePrice * M12
            Price13 = BasePrice * M13

            'Round to 3 digits
            Price01 = Math.Round(Price01, 3)
            Price02 = Math.Round(Price02, 3)
            Price03 = Math.Round(Price03, 3)
            Price04 = Math.Round(Price04, 3)
            Price05 = Math.Round(Price05, 3)
            Price06 = Math.Round(Price06, 3)
            Price07 = Math.Round(Price07, 3)
            Price08 = Math.Round(Price08, 3)
            Price09 = Math.Round(Price09, 3)
            Price10 = Math.Round(Price10, 3)
            Price11 = Math.Round(Price11, 3)
            Price12 = Math.Round(Price12, 3)
            Price13 = Math.Round(Price13, 3)

            'Insert into Price Bracket Table
            cmd = New SqlCommand("Insert Into ItemPriceSheet(PartNumber, PartDescription, DivisionID, StandardUnitCost, StandardUnitPrice, B100To199, B200To299, B300To399, B400To499, B500To749, B750To999, B1000To2499, B2500To4999, B5000To9999, B10000To24999, B25000To49999, B50000To99999, B100000AndUp)Values(@PartNumber, @PartDescription, @DivisionID, @StandardUnitCost, @StandardUnitPrice, @B100To199, @B200To299, @B300To399, @B400To499, @B500To749, @B750To999, @B1000To2499, @B2500To4999, @B5000To9999, @B10000To24999, @B25000To49999, @B50000To99999, @B100000AndUp)", con)

            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@StandardUnitCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)
                .Add("@StandardUnitPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)
                .Add("@B100To199", SqlDbType.VarChar).Value = Price01
                .Add("@B200To299", SqlDbType.VarChar).Value = Price02
                .Add("@B300To399", SqlDbType.VarChar).Value = Price03
                .Add("@B400To499", SqlDbType.VarChar).Value = Price04
                .Add("@B500To749", SqlDbType.VarChar).Value = Price05
                .Add("@B750To999", SqlDbType.VarChar).Value = Price06
                .Add("@B1000To2499", SqlDbType.VarChar).Value = Price07
                .Add("@B2500To4999", SqlDbType.VarChar).Value = Price08
                .Add("@B5000To9999", SqlDbType.VarChar).Value = Price09
                .Add("@B10000To24999", SqlDbType.VarChar).Value = Price10
                .Add("@B25000To49999", SqlDbType.VarChar).Value = Price11
                .Add("@B50000To99999", SqlDbType.VarChar).Value = Price12
                .Add("@B100000AndUp", SqlDbType.VarChar).Value = Price13
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Pricing bracket created.", MsgBoxStyle.OkOnly)
        Else
            'Prompt (YES/NO) before you update brackets
            Dim button As DialogResult = MessageBox.Show("Do you wish to update this existing price bracket?", "UPDATE PRICE BRACKET", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Calculate each Bracket
                Select Case PriceItemClass
                    Case "TW TT", "TW TP", "TW NT", "TW CS"
                        M01 = 3.69845
                        M02 = 2.90515
                        M03 = 2.1134
                        M04 = 1.84948
                        M05 = 1.58557
                        M06 = 1.31959
                        M07 = 1.22423
                        M08 = 1.1567
                        M09 = 1.09876
                        M10 = 1.03093
                        M11 = 1.01546
                        M12 = 1.01031
                        M13 = 1.0
                    Case "TW SC", "TW DS"
                        M01 = 3.69845
                        M02 = 2.90515
                        M03 = 2.1134
                        M04 = 1.84948
                        M05 = 1.58557
                        M06 = 1.31959
                        M07 = 1.22423
                        M08 = 1.1567
                        M09 = 1.09876
                        M10 = 1.03093
                        M11 = 1.01546
                        M12 = 1.01031
                        M13 = 1.0
                    Case "TW CA", "TW PS", "TW DB", "TW SWR"
                        M01 = 3.75654
                        M02 = 2.95079
                        M03 = 2.1466
                        M04 = 1.87853
                        M05 = 1.61047
                        M06 = 1.34031
                        M07 = 1.24346
                        M08 = 1.17487
                        M09 = 1.11602
                        M10 = 1.04712
                        M11 = 1.02094
                        M12 = 1.01047
                        M13 = 1.0
                    Case Else
                        M01 = 3.5
                        M02 = 2.75
                        M03 = 2.0
                        M04 = 1.75
                        M05 = 1.5
                        M06 = 1.25
                        M07 = 1.15
                        M08 = 1.1
                        M09 = 1.05
                        M10 = 1.0
                        M11 = 1.0
                        M12 = 1.0
                        M13 = 1.0
                End Select

                'Calculate Bracket Pricing
                Price01 = BasePrice * M01
                Price02 = BasePrice * M02
                Price03 = BasePrice * M03
                Price04 = BasePrice * M04
                Price05 = BasePrice * M05
                Price06 = BasePrice * M06
                Price07 = BasePrice * M07
                Price08 = BasePrice * M08
                Price09 = BasePrice * M09
                Price10 = BasePrice * M10
                Price11 = BasePrice * M11
                Price12 = BasePrice * M12
                Price13 = BasePrice * M13

                'Round to 3 digits
                Price01 = Math.Round(Price01, 3)
                Price02 = Math.Round(Price02, 3)
                Price03 = Math.Round(Price03, 3)
                Price04 = Math.Round(Price04, 3)
                Price05 = Math.Round(Price05, 3)
                Price06 = Math.Round(Price06, 3)
                Price07 = Math.Round(Price07, 3)
                Price08 = Math.Round(Price08, 3)
                Price09 = Math.Round(Price09, 3)
                Price10 = Math.Round(Price10, 3)
                Price11 = Math.Round(Price11, 3)
                Price12 = Math.Round(Price12, 3)
                Price13 = Math.Round(Price13, 3)

                'Insert into Price Bracket Table
                cmd = New SqlCommand("UPDATE ItemPriceSheet SET PartDescription = @PartDescription, StandardUnitCost = @StandardUnitCost, StandardUnitPrice = @StandardUnitCost, B100To199 = @B100To199, B200To299 = @B200To299, B300To399 = @B300To399, B400To499 = @B400To499, B500To749 = @B500To749, B750To999 = @B750To999, B1000To2499 = @B1000To2499, B2500To4999 = @B2500To4999, B5000To9999 = @B5000To9999, B10000To24999 = @B10000To24999, B25000To49999 = @B25000To49999, B50000To99999 = @B50000To99999, B100000AndUp = @B100000AndUp WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@StandardUnitCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)
                    .Add("@StandardUnitPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)
                    .Add("@B100To199", SqlDbType.VarChar).Value = Price01
                    .Add("@B200To299", SqlDbType.VarChar).Value = Price02
                    .Add("@B300To399", SqlDbType.VarChar).Value = Price03
                    .Add("@B400To499", SqlDbType.VarChar).Value = Price04
                    .Add("@B500To749", SqlDbType.VarChar).Value = Price05
                    .Add("@B750To999", SqlDbType.VarChar).Value = Price06
                    .Add("@B1000To2499", SqlDbType.VarChar).Value = Price07
                    .Add("@B2500To4999", SqlDbType.VarChar).Value = Price08
                    .Add("@B5000To9999", SqlDbType.VarChar).Value = Price09
                    .Add("@B10000To24999", SqlDbType.VarChar).Value = Price10
                    .Add("@B25000To49999", SqlDbType.VarChar).Value = Price11
                    .Add("@B50000To99999", SqlDbType.VarChar).Value = Price12
                    .Add("@B100000AndUp", SqlDbType.VarChar).Value = Price13
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Pricing bracket updated.", MsgBoxStyle.OkOnly)
            ElseIf button = DialogResult.No Then
                'Do nothing
            End If
        End If

        'Clear variables
        BasePrice = 0
        CountPriceBracket = 0
        PriceItemClass = ""
        Price01 = 0
        Price02 = 0
        Price03 = 0
        Price04 = 0
        Price05 = 0
        Price06 = 0
        Price07 = 0
        Price08 = 0
        Price09 = 0
        Price10 = 0
        Price11 = 0
        Price12 = 0
        Price13 = 0
        M01 = 0
        M02 = 0
        M03 = 0
        M04 = 0
        M05 = 0
        M06 = 0
        M07 = 0
        M08 = 0
        M09 = 0
        M10 = 0
        M11 = 0
        M12 = 0
        M13 = 0
    End Sub

    Private Sub cmdPrintItemLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintItemLabel.Click
        If canPrintItemLabel() Then
            Dim bc As New BarcodeLabel
            bc.itemLabelSetup(cboPartNumber.Text, txtBoxCustom1.Text, txtBoxCustom2.Text, nmrLabelQty.Value)
            bc.PrintBarcodeLine()
        End If

    End Sub

    'Tool Menu Routines

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            unlockBatch()
        End If
        'Clear the text boxes
        ClearVariables()
        isLoaded = False
        LoadPartNumber()
        isLoaded = True
        ClearData()
        ShowAssemblyComponents()
    End Sub

    Private Sub SaveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveItemToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub DeleteItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteItemToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub ActivityLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivityLogToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboPartNumber.Text) AndAlso Not String.IsNullOrEmpty(cboDivisionID.Text) Then
            cmd = New SqlCommand("SELECT ActivityDateTime as [Activity Date], ActivityDateTime as [Activity Time], UserID as [User], ChangedField as [Changed Field], OriginalValue as [Original Value], NewValue as [New Value]  FROM TFPItemListActivityLog WHERE ItemID = @ItemID AND DivisionID = @DivisionID ORDER BY [Activity Date] DESC, [Activity Time] DESC ", con)
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            Dim dt As New Data.DataTable("Activity")
            Dim adap As New SqlDataAdapter(cmd)
            If con.State = ConnectionState.Closed Then con.Open()
            adap.Fill(dt)
            con.Close()
            Dim frm As New ViewActivityLog(dt)
            frm.ShowDialog()
        Else
            Dim frm As New ViewActivityLog("ItemList", cboDivisionID.Text)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub FindByFOXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindByFOXToolStripMenuItem.Click
        If FindByFOXToolStripMenuItem.Enabled Then
            Dim newInput As New InputComboBox("FOX", "")
            If newInput.ShowDialog() = Windows.Forms.DialogResult.OK Then
                cmd = New SqlCommand("SELECT PartNumber, DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = newInput.cboInputValue.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim PartNumber As String = Nothing
                Dim Division As String = Nothing
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If Not IsDBNull(reader.Item("PartNumber")) Then
                        PartNumber = reader.Item("PartNumber")
                    End If
                    If Not IsDBNull(reader.Item("DivisionID")) Then
                        Division = reader.Item("DivisionID")
                    End If
                End If
                reader.Close()
                con.Close()
                If PartNumber IsNot Nothing AndAlso Division IsNot Nothing Then
                    ClearData()
                    isLoaded = False
                    If Not cboDivisionID.Text.Equals(Division) Then cboDivisionID.Text = Division
                    isLoaded = True
                    cboPartNumber.Text = PartNumber
                Else
                    MessageBox.Show("Unable to locate the part number for the given FOX", "Unable to locate", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub ClearFOXFromPartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFOXFromPartToolStripMenuItem.Click
        If cboPartNumber.Text <> "" Then
            'Update FOX Number in the Item List
            cmd = New SqlCommand("UPDATE ItemList SET FOXNumber = @FOXNumber WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.VarChar).Value = ""
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub UnLockPartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockPartToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this Part?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE ItemList SET Locked = '' WHERE ItemID = @ItemID", con)
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = Val(cboPartNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Part is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a Part Number to un-lock", "Enter a Part Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.Focus()
        End If
    End Sub

    Private Sub LTRackingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTRackingToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        Dim NewLiftTruckRacking As New LiftTruckRacking
        NewLiftTruckRacking.Show()
    End Sub

    Private Sub UpdateFOXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateFOXToolStripMenuItem.Click
        If cboPartNumber.Text <> "" Then
            'Update FOX Number in the Item List
            cmd = New SqlCommand("UPDATE ItemList SET FOXNumber = @FOXNumber WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(txtItemListFOX.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    'Link Label Routines

    Private Sub llQuantityOpen_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQuantityOpen.LinkClicked
        GlobalDivisionCode = cboDivisionID.Text
        GlobalMaintenancePartNumber = cboPartNumber.Text

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub llFOXProcesses_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFOXProcesses.LinkClicked
        GlobalFOXNumber = Val(lblFOXNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewItemMaintenanceFoxPopup As New ItemMaintenanceFoxProcesses
            Dim Result = NewItemMaintenanceFoxPopup.ShowDialog()
        End Using
    End Sub

    Private Sub llLastPOCostPopup_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLastPOCostPopup.LinkClicked
        GlobalDivisionCode = cboDivisionID.Text
        GlobalPOPartNumber = cboPartNumber.Text

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            Using NewSOManufacturedCostPopup As New SOManufacturedCostPopup
                Dim Result = NewSOManufacturedCostPopup.ShowDialog()
            End Using
        Else
            Using NewSOPurchaseCostPopup As New SOPurchaseCostPopup
                Dim Result = NewSOPurchaseCostPopup.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub llNextPieceSold_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llNextPieceSold.LinkClicked
        LoadNextPieceSold()
        GlobalNextPieceSold = NextPieceSold

        Using NewNextPieceSold As New LoadNextPieceSold
            Dim Result = NewNextPieceSold.ShowDialog()
        End Using
    End Sub

    'Printing/label Routines

    Private Sub fillLabelVariables()
        V00 = cboPartNumber.Text
        If String.IsNullOrEmpty(cboPartDescription.Text) Then
            V04 = ""
            V05 = ""
            V06 = ""
        Else
            ''tests the length and will divide accordingly for the part description
            If cboPartDescription.Text.Length > 35 Then
                If cboPartDescription.Text.Length > 70 Then
                    V06 = cboPartDescription.Text.Substring(70, cboPartDescription.Text.Length - 70)
                    V05 = cboPartDescription.Text.Substring(35, 35)
                Else
                    V05 = cboPartDescription.Text.Substring(35, cboPartDescription.Text.Length - 35)
                    V06 = ""
                End If
                V04 = cboPartDescription.Text.Substring(0, 35)
            Else
                V04 = cboPartDescription.Text
                V05 = ""
                V06 = ""
            End If
        End If
        If String.IsNullOrEmpty(txtLabelComments.Text) Then
            V07 = ""
        Else
            V07 = txtLabelComments.Text
        End If
        If String.IsNullOrEmpty(txtLabelComments2.Text) Then
            V08 = ""
        Else
            V08 = txtLabelComments2.Text
        End If
        If String.IsNullOrEmpty(txtLabelComments3.Text) Then
            V09 = ""
        Else
            V09 = txtLabelComments3.Text
        End If
        If String.IsNullOrEmpty(txtLabelAdditionalComments.Text) Then
            V10 = ""
        Else
            V10 = txtLabelAdditionalComments.Text
        End If
        If String.IsNullOrEmpty(txtLabelQuantity.Text) Then
            V11 = ""
        Else
            V11 = txtLabelQuantity.Text
        End If
    End Sub

    'Update/Save Routines

    Private Sub UpdateOrInsertIntoItemList()
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            'Vendor ID assigned by check boxes or combo box
        Else
            VendorID = cboVendorID.Text
        End If

        If String.IsNullOrEmpty(CreationDate.ToString()) Then
            CreationDate = Today()
        End If

        cmd = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Close()
            con.Close()
            UpdateItemListTable()
        Else
            reader.Close()
            con.Close()
            InsertIntoItemListTable()
        End If
    End Sub

    Private Sub UpdateItemListTable()
        ''Inserts changes made into the log, if needed
        UpdateLog()
        LoadCompanyDefaults()

        'Check Part Description for Existing
        Dim CheckExistingDescription As Integer = 0
        Dim CheckExistingPartNumber As String = ""

        Dim CheckExistingDescriptionStatement As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim CheckExistingDescriptionCommand As New SqlCommand(CheckExistingDescriptionStatement, con)
        CheckExistingDescriptionCommand.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        CheckExistingDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckExistingDescription = CInt(CheckExistingDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            CheckExistingDescription = 0
        End Try
        con.Close()

        If CheckExistingDescription = 0 Then
            DuplicatePartDescription = "NO"
        ElseIf CheckExistingDescription = 1 Then
            'Check if part number is the same as the one you are entering
            Dim CheckExistingNumberStatement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
            Dim CheckExistingNumberCommand As New SqlCommand(CheckExistingNumberStatement, con)
            CheckExistingNumberCommand.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
            CheckExistingNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckExistingPartNumber = CStr(CheckExistingNumberCommand.ExecuteScalar)
            Catch ex As Exception
                CheckExistingPartNumber = ""
            End Try
            con.Close()

            If CheckExistingPartNumber = cboPartNumber.Text Then
                DuplicatePartDescription = "NO"
            Else
                MsgBox("A Part Number already exists with this exact description.", MsgBoxStyle.OkOnly)
                DuplicatePartDescription = "YES"
                Exit Sub
            End If
        Else
            MsgBox("A Part Number already exists with this exact description.", MsgBoxStyle.OkOnly)
            DuplicatePartDescription = "YES"
            Exit Sub
        End If

        ValidatePPLAndSPL()

        If CheckPPL = 1 And CheckSPL = 1 Then
            'Continue
        Else
            MsgBox("You must select a valid Sales Product Line and Purchase Product Line.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If txtLongDescription.Text = "" Then
            txtLongDescription.Text = cboPartDescription.Text
        End If
        If cboPurchaseProductID.Text = "" Then
            cboPurchaseProductID.Text = DefaultPPL
        End If
        If cboSalesProductLine.Text = "" Then
            cboSalesProductLine.Text = DefaultSPL
        End If
        If cboAddAccessories.Text = "" Then
            cboAddAccessories.Text = "NO"
        End If

        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("UPDATE ItemList SET ShortDescription = @ShortDescription, LongDescription = @LongDescription, ItemClass = @ItemClass, PurchProdLineID = @PurchProdLineID, SalesProdLineID = @SalesProdLineID, PieceWeight = @PieceWeight, BoxCount = @BoxCount, PalletCount = @PalletCount, StandardCost = @StandardCost, StandardPrice = @StandardPrice, OldPartNumber = @OldPartNumber, MinimumStock = @MinimumStock, MaximumStock = @MaximumStock, CreationDate = @CreationDate, BeginningBalance = @BeginningBalance, BoxType = @BoxType, NominalDiameter = @NominalDiameter, NominalLength = @NominalLength, AddAccessory = @AddAccessory, PreferredVendor = @PreferredVendor, SafetyDataSheet = @SafetyDataSheet, BoxWeight = @BoxWeight, Comments = @Comments, LeadTime = @LeadTime, BinPreference = @BinPreference WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text.ToUpper
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text.ToUpper
            .Add("@LongDescription", SqlDbType.VarChar).Value = txtLongDescription.Text.ToUpper
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
            .Add("@PurchProdLineID", SqlDbType.VarChar).Value = cboPurchaseProductID.Text
            .Add("@SalesProdLineID", SqlDbType.VarChar).Value = cboSalesProductLine.Text
            .Add("@PieceWeight", SqlDbType.VarChar).Value = Val(txtPieceWeight.Text)
            .Add("@BoxCount", SqlDbType.VarChar).Value = Val(txtBoxCount.Text)
            .Add("@PalletCount", SqlDbType.VarChar).Value = Val(txtPalletCount.Text)
            .Add("@StandardCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)
            .Add("@StandardPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)
            .Add("@OldPartNumber", SqlDbType.VarChar).Value = txtOldPartNumber.Text
            .Add("@MinimumStock", SqlDbType.VarChar).Value = Val(txtMinimumStock.Text)
            .Add("@MaximumStock", SqlDbType.VarChar).Value = Val(txtMaximumStock.Text)
            .Add("@CreationDate", SqlDbType.VarChar).Value = CreationDate
            .Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
            .Add("@BoxType", SqlDbType.VarChar).Value = txtBoxType.Text
            .Add("@NominalDiameter", SqlDbType.VarChar).Value = Val(txtNominalDiameter.Text)
            .Add("@NominalLength", SqlDbType.VarChar).Value = Val(txtNominalLength.Text)
            .Add("@AddAccessory", SqlDbType.VarChar).Value = cboAddAccessories.Text
            .Add("@PreferredVendor", SqlDbType.VarChar).Value = VendorID
            .Add("@SafetyDataSheet", SqlDbType.VarChar).Value = cboSafetyDataSheet.Text
            .Add("@BoxWeight", SqlDbType.VarChar).Value = Val(txtStdBoxWeight.Text)
            .Add("@Comments", SqlDbType.VarChar).Value = txtItemComments.Text
            .Add("@LeadTime", SqlDbType.VarChar).Value = txtLeadTime.Text
            .Add("@BinPreference", SqlDbType.VarChar).Value = txtBinPreference.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub InsertIntoItemListTable()
        Dim tmp As New usefulFunctions.FieldData
        tmp.ColumnName = "CREATED"
        tmp.OriginalValue = "NO"
        tmp.NewValue = "YES"
        lstChangedFields.InsertAt(0, tmp)

        ''Inserts changes made into the log, if needed
        UpdateLog()
        LoadCompanyDefaults()

        'Check Part Description for Existing
        Dim CheckExistingDescription As Integer = 0

        Dim CheckExistingDescriptionStatement As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim CheckExistingDescriptionCommand As New SqlCommand(CheckExistingDescriptionStatement, con)
        CheckExistingDescriptionCommand.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        CheckExistingDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckExistingDescription = CInt(CheckExistingDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            CheckExistingDescription = 0
        End Try
        con.Close()

        If CheckExistingDescription >= 1 Then
            MsgBox("A Part Number already exists with this exact description.", MsgBoxStyle.OkOnly)
            DuplicatePartDescription = "YES"
            Exit Sub
        Else
            DuplicatePartDescription = "NO"
        End If

        ValidatePPLAndSPL()

        If CheckPPL = 1 And CheckSPL = 1 Then
            'Continue
        Else
            MsgBox("You must select a valid Sales Product Line and Purchase Product Line.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If txtLongDescription.Text = "" Then
            txtLongDescription.Text = cboPartDescription.Text
        End If
        If cboPurchaseProductID.Text = "" Then
            cboPurchaseProductID.Text = DefaultPPL
        End If
        If cboSalesProductLine.Text = "" Then
            cboSalesProductLine.Text = DefaultSPL
        End If
        If cboAddAccessories.Text = "" Then
            cboAddAccessories.Text = "NO"
        End If

        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("Insert Into ItemList(ItemID, DivisionID, ShortDescription, LongDescription, ItemClass, PurchProdLineID, SalesProdLineID, PieceWeight, BoxCount, PalletCount, StandardCost, StandardPrice, OldPartNumber, MinimumStock, MaximumStock, CreationDate, BeginningBalance, FOXNumber, BoxType, NominalDiameter, NominalLength, AddAccessory, PreferredVendor, Locked, SafetyDataSheet, BoxWeight, Comments, LeadTime, BinPreference)Values(@ItemID, @DivisionID, @ShortDescription, @LongDescription, @ItemClass, @PurchProdLineID, @SalesProdLineID, @PieceWeight, @BoxCount, @PalletCount, @StandardCost, @StandardPrice, @OldPartNumber, @MinimumStock, @MaximumStock, @CreationDate, @BeginningBalance, @FOXNumber, @BoxType, @NominalDiameter, @NominalLength, @AddAccessory, @PreferredVendor, @Locked, @SafetyDataSheet, @BoxWeight, @Comments, @LeadTime, @BinPreference)", con)

        With cmd.Parameters
            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text.ToUpper
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text.ToUpper
            .Add("@LongDescription", SqlDbType.VarChar).Value = txtLongDescription.Text.ToUpper
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
            .Add("@PurchProdLineID", SqlDbType.VarChar).Value = cboPurchaseProductID.Text
            .Add("@SalesProdLineID", SqlDbType.VarChar).Value = cboSalesProductLine.Text
            .Add("@PieceWeight", SqlDbType.VarChar).Value = Val(txtPieceWeight.Text)
            .Add("@BoxCount", SqlDbType.VarChar).Value = Val(txtBoxCount.Text)
            .Add("@PalletCount", SqlDbType.VarChar).Value = Val(txtPalletCount.Text)
            .Add("@StandardCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)
            .Add("@StandardPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)
            .Add("@OldPartNumber", SqlDbType.VarChar).Value = txtOldPartNumber.Text
            .Add("@MinimumStock", SqlDbType.VarChar).Value = Val(txtMinimumStock.Text)
            .Add("@MaximumStock", SqlDbType.VarChar).Value = Val(txtMaximumStock.Text)
            .Add("@CreationDate", SqlDbType.VarChar).Value = CreationDate
            .Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
            .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(lblFOXNumber.Text)
            .Add("@BoxType", SqlDbType.VarChar).Value = txtBoxType.Text
            .Add("@NominalDiameter", SqlDbType.VarChar).Value = Val(txtNominalDiameter.Text)
            .Add("@NominalLength", SqlDbType.VarChar).Value = Val(txtNominalLength.Text)
            .Add("@AddAccessory", SqlDbType.VarChar).Value = cboAddAccessories.Text
            .Add("@PreferredVendor", SqlDbType.VarChar).Value = VendorID
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@SafetyDataSheet", SqlDbType.VarChar).Value = cboSafetyDataSheet.Text
            .Add("@BoxWeight", SqlDbType.VarChar).Value = Val(txtStdBoxWeight.Text)
            .Add("@Comments", SqlDbType.VarChar).Value = txtItemComments.Text
            .Add("@LeadTime", SqlDbType.VarChar).Value = txtLeadTime.Text
            .Add("@BinPreference", SqlDbType.VarChar).Value = txtBinPreference.Text
        End With

        If cboDivisionID.Text.Equals("TWE") Or cboDivisionID.Text.Equals("TWD") Then
            If cboItemClass.Text.StartsWith("TW ") Then
                ''gets the division ID from the division table and then narrows the insert by the divisions that do not alreay have the part number
                cmd.CommandText += " INSERT INTO ItemList (ItemID, DivisionID, ShortDescription, LongDescription, ItemClass, PurchProdLineID, SalesProdLineID, PieceWeight, BoxCount, PalletCount, StandardCost, StandardPrice, OldPartNumber, CreationDate, BeginningBalance, BoxType, NominalDiameter, NominalLength, AddAccessory, PreferredVendor, Locked, SafetyDataSheet, BoxWeight, Comments, LeadTime) SELECT @ItemID, DivisionKey, @ShortDescription, @LongDescription, @ItemClass, @PurchProdLineID, @SalesProdLineID, @PieceWeight, @BoxCount, @PalletCount, @StandardCost, @StandardPrice, @OldPartNumber, @CreationDate, @BeginningBalance, @BoxType, @NominalDiameter, @NominalLength, @AddAccessory, @PreferredVendor, '', @SafetyDataSheet, @BoxWeight, @Comments, @LeadTime FROM DivisionTable WHERE DivisionKey not in (SELECT DivisionID FROM ItemList WHERE ItemID = @ItemID) and DivisionKey <> 'ADM' AND DivisionKey <> 'TFP' AND DivisionKey <> 'CHT';"
            End If
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub updateOrInsertIntoAssemblyHeaderTable()
        cmd = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @ItemID", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Close()
            con.Close()
            updateAssemblyHeaderTable()
        Else
            reader.Close()
            con.Close()
            insertIntoAssemblyHeaderTable()
        End If
    End Sub

    Private Sub insertIntoAssemblyHeaderTable()
        'Creates new assembly record
        cmd = New SqlCommand("INSERT INTO AssemblyHeaderTable (AssemblyPartNumber, AssemblyDate, DivisionID, AssemblyDescription, Comment, TotalCost, SerializedStatus, ItemClass)Values(@AssemblyPartNumber, @AssemblyDate, @DivisionID, @AssemblyDescription, @Comment, @TotalCost, @SerializedStatus, @ItemClass)", con)

        With cmd.Parameters
            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@AssemblyDate", SqlDbType.VarChar).Value = AssemblyDate
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@AssemblyDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtAssemblyComment.Text
            .Add("@TotalCost", SqlDbType.VarChar).Value = SUMExtendedCost
            .Add("@SerializedStatus", SqlDbType.VarChar).Value = SerializedStatus
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub updateAssemblyHeaderTable()
        'Create command to save assembly data
        cmd = New SqlCommand("UPDATE AssemblyHeaderTable SET AssemblyDate = @AssemblyDate, AssemblyDescription = @AssemblyDescription, Comment = @Comment, TotalCost = @TotalCost, SerializedStatus = @SerializedStatus, ItemClass = @ItemClass WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@AssemblyDate", SqlDbType.VarChar).Value = AssemblyDate
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@AssemblyDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtAssemblyComment.Text
            .Add("@TotalCost", SqlDbType.VarChar).Value = SUMExtendedCost
            .Add("@SerializedStatus", SqlDbType.VarChar).Value = SerializedStatus
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub UpdateComponentDescription()
        'Update Line table with the description
        cmd = New SqlCommand("UPDATE AssemblyLineTable SET ComponentPartDescription = @ComponentPartDescription WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Datagridview Routines

    Private Sub dgvAssemblyLineQuery_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvAssemblyLineQuery.CellValueChanged
        If Me.dgvAssemblyLineQuery.RowCount <> 0 Then
            Dim LineExtendedAmount, LineUnitCost, SUMExtendedCost As Double
            Dim LineQuantity As Double = 0
            Dim LineComment, LineComponentPartNumber, LineComponentDescription As String

            Dim RowIndex As Integer = Me.dgvAssemblyLineQuery.CurrentCell.RowIndex

            Try
                LineUnitCost = Me.dgvAssemblyLineQuery.Rows(RowIndex).Cells("UnitCostColumn").Value
            Catch ex As Exception
                LineUnitCost = 0
            End Try
            Try
                LineQuantity = Me.dgvAssemblyLineQuery.Rows(RowIndex).Cells("QuantityColumn").Value
            Catch ex As Exception
                LineQuantity = 0
            End Try
            Try
                LineComponentPartNumber = Me.dgvAssemblyLineQuery.Rows(RowIndex).Cells("ComponentPartNumberColumn").Value
            Catch ex As Exception
                LineComponentPartNumber = ""
            End Try
            Try
                LineComponentDescription = Me.dgvAssemblyLineQuery.Rows(RowIndex).Cells("ComponentPartDescriptionColumn").Value
            Catch ex As Exception
                LineComponentDescription = ""
            End Try
            Try
                LineComment = Me.dgvAssemblyLineQuery.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                LineComment = ""
            End Try

            LineExtendedAmount = LineUnitCost * LineQuantity

            Try
                'UPDATE Assembly Data in grid
                cmd = New SqlCommand("UPDATE AssemblyLineTable SET Quantity = @Quantity, UnitCost = @UnitCost, ExtendedCost = @ExtendedCost, LineComment = @LineComment WHERE AssemblyPartNumber = @AssemblyPartNumber AND ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = LineComponentPartNumber
                    .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = LineComponentDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = LineExtendedAmount
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
                MsgBox("Data was not updated. Contact system Admin.", MsgBoxStyle.OkOnly)
                Exit Sub
            End Try

            'Update Cost in Header Table
            Dim SUMExtendedCostStatement As String = "SELECT SUM(ExtendedCost) FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
            Dim SUMExtendedCostCommand As New SqlCommand(SUMExtendedCostStatement, con)
            SUMExtendedCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SUMExtendedCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMExtendedCost = CDbl(SUMExtendedCostCommand.ExecuteScalar)
            Catch ex As Exception
                SUMExtendedCost = 0
            End Try
            con.Close()

            'Save Totals in the Header Table
            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE AssemblyHeaderTable SET TotalCost = @TotalCost WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)
                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@TotalCost", SqlDbType.VarChar).Value = SUMExtendedCost
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If
    End Sub

    Private Sub dgvSerialNumbers_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSerialNumbers.CellDoubleClick
        If dgvSerialNumbers.RowCount > 0 And cboDivisionID.Text = "TWE" Then
            Dim RowTransactionNumber As Integer = 0
            Dim RowPartNumber As String = ""

            Dim RowIndex As Integer = Me.dgvSerialNumbers.CurrentCell.RowIndex

            RowTransactionNumber = Me.dgvSerialNumbers.Rows(RowIndex).Cells("BuildNumber2Column").Value
            RowPartNumber = Me.dgvSerialNumbers.Rows(RowIndex).Cells("AssemblyPartNumber2Column").Value

            If RowTransactionNumber = 0 Then
                GlobalAssemblyPartNumber = RowPartNumber
                GlobalDivisionCode = cboDivisionID.Text

                MsgBox("There is no specific build for this serial #. This will display the default BOM.", MsgBoxStyle.OkOnly)

                Using NewPrintAssemblyBOM As New PrintAssemblyBOM
                    Dim Result = NewPrintAssemblyBOM.ShowDialog()
                End Using
            Else
                GlobalAssemblyTransactionNumber = RowTransactionNumber
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintAssemblyBuilBOM As New PrintAssemblyBuildBOM
                    Dim Result = NewPrintAssemblyBuilBOM.ShowDialog()
                End Using
            End If
        Else
            'Do nothing - no serial number
        End If
    End Sub

    Private Sub dgvAssemblyLineQuery_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssemblyLineQuery.CellDoubleClick
        If dgvSerialNumbers.RowCount > 0 And cboDivisionID.Text = "TWE" Then
            Dim RowAssemblyPartNumber As String = ""

            Dim RowIndex As Integer = Me.dgvAssemblyLineQuery.CurrentCell.RowIndex

            RowAssemblyPartNumber = cboPartNumber.Text
            GlobalAssemblyPartNumber = RowAssemblyPartNumber

            'If Serialized, get data for TWE
            If chkSerializedAssembly.Checked = True Then
                GlobalDivisionCode = "TWE"
            Else
                GlobalDivisionCode = cboDivisionID.Text
            End If

            Using NewPrintAssemblyBOM As New PrintAssemblyBOM
                Dim Result = NewPrintAssemblyBOM.ShowDialog()
            End Using
        Else
            'Do nothing - no serial number
        End If
    End Sub

    Private Sub dgvSerialNumbers_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSerialNumbers.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub dgvSerialNumbers_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSerialNumbers.CellValueChanged
        If Me.dgvSerialNumbers.RowCount = 0 Then
            'Do nothing
        Else
            'Declare variables
            Dim RowTransactionNumber As Integer = 0
            Dim RowDivision As String = ""
            Dim RowComment As String = ""
            Dim RowSerialNumber As String = ""
            Dim RowPartNumber As String = ""
            Dim RowStatus As String = ""
            Dim RowBuildNumber As Integer = 0
            Dim RowBatchNumber As Integer = 0
            Dim RowCustomer As String = ""
            Dim RowTotalCost As Double = 0
            Dim RowShipmentPrice As Double = 0

            Dim RowIndex As Integer = Me.dgvSerialNumbers.CurrentCell.RowIndex

            If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
                Try
                    RowTransactionNumber = Me.dgvSerialNumbers.Rows(RowIndex).Cells("TransactionNumber2Column").Value
                Catch ex As Exception
                    RowTransactionNumber = 0
                End Try
                Try
                    RowDivision = Me.dgvSerialNumbers.Rows(RowIndex).Cells("DivisionID2Column").Value
                Catch ex As Exception
                    RowDivision = ""
                End Try
                Try
                    RowComment = Me.dgvSerialNumbers.Rows(RowIndex).Cells("CommentColumn").Value
                Catch ex As Exception
                    RowComment = ""
                End Try
                Try
                    RowSerialNumber = Me.dgvSerialNumbers.Rows(RowIndex).Cells("SerialNumber2Column").Value
                Catch ex As Exception
                    RowSerialNumber = ""
                End Try
                Try
                    RowPartNumber = Me.dgvSerialNumbers.Rows(RowIndex).Cells("AssemblyPartNumber2Column").Value
                Catch ex As Exception
                    RowPartNumber = ""
                End Try
                Try
                    RowStatus = Me.dgvSerialNumbers.Rows(RowIndex).Cells("Status2Column").Value
                Catch ex As Exception
                    RowStatus = ""
                End Try
                Try
                    RowBuildNumber = Me.dgvSerialNumbers.Rows(RowIndex).Cells("BuildNumber2Column").Value
                Catch ex As Exception
                    RowBuildNumber = 0
                End Try
                Try
                    RowBatchNumber = Me.dgvSerialNumbers.Rows(RowIndex).Cells("BatchNumber2Column").Value
                Catch ex As Exception
                    RowBatchNumber = 0
                End Try
                Try
                    RowCustomer = Me.dgvSerialNumbers.Rows(RowIndex).Cells("CustomerID2Column").Value
                Catch ex As Exception
                    RowCustomer = ""
                End Try
                Try
                    RowTotalCost = Me.dgvSerialNumbers.Rows(RowIndex).Cells("TotalCost2Column").Value
                Catch ex As Exception
                    RowTotalCost = 0
                End Try
                Try
                    RowShipmentPrice = Me.dgvSerialNumbers.Rows(RowIndex).Cells("ShipmentPrice2Column").Value
                Catch ex As Exception
                    RowShipmentPrice = 0
                End Try

                'Validate specific fields
                If RowStatus = "CLOSED" Or RowStatus = "AVAILABLE" Or RowStatus = "OPEN" Then
                    'Continue to save
                Else
                    Exit Sub
                End If
                If RowPartNumber = "" Then
                    Exit Sub
                End If
                If RowSerialNumber = "" Then
                    Exit Sub
                End If
                If RowDivision = "" Then
                    Exit Sub
                End If

                'Update Serial Log
                cmd = New SqlCommand("UPDATE AssemblySerialLog SET Comment = @Comment, TotalCost = @TotalCost, Status = @Status, BuildNumber = @BuildNumber, CustomerID = @CustomerID, BatchNumber = @BatchNumber, TransactionNumber = @TransactionNumber, ShipmentPrice = @ShipmentPrice WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                    .Add("@TotalCost", SqlDbType.VarChar).Value = RowTotalCost
                    .Add("@Status", SqlDbType.VarChar).Value = RowStatus
                    .Add("@BuildNumber", SqlDbType.VarChar).Value = RowBuildNumber
                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = RowBatchNumber
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                    .Add("@ShipmentPrice", SqlDbType.VarChar).Value = RowShipmentPrice
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                Try
                    RowDivision = Me.dgvSerialNumbers.Rows(RowIndex).Cells("DivisionID2Column").Value
                Catch ex As Exception
                    RowDivision = ""
                End Try
                Try
                    RowComment = Me.dgvSerialNumbers.Rows(RowIndex).Cells("Comment2Column").Value
                Catch ex As Exception
                    RowComment = ""
                End Try
                Try
                    RowSerialNumber = Me.dgvSerialNumbers.Rows(RowIndex).Cells("SerialNumber2Column").Value
                Catch ex As Exception
                    RowSerialNumber = ""
                End Try
                Try
                    RowPartNumber = Me.dgvSerialNumbers.Rows(RowIndex).Cells("AssemblyPartNumber2Column").Value
                Catch ex As Exception
                    RowPartNumber = ""
                End Try

                'Update Serial Log
                cmd = New SqlCommand("UPDATE AssemblySerialLog SET Comment = @Comment WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Private Sub dgvLotNumbers_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotNumbers.CellDoubleClick
        Dim RowLotNumber, RowHeatNumber, RowPartNumber, RowCertType, GetMinPartNumber, RowItemClass As String
        Dim RowNominalDiameter, RowNominalLength As Double
        Dim GetPullTestNumber As String

        If Me.dgvLotNumbers.RowCount = 0 Then

        Else
            Dim RowIndex As Integer = Me.dgvLotNumbers.CurrentCell.RowIndex

            RowLotNumber = Me.dgvLotNumbers.Rows(RowIndex).Cells("LotNumberColumn5").Value
            RowHeatNumber = Me.dgvLotNumbers.Rows(RowIndex).Cells("HeatNumberColumn5").Value
            RowPartNumber = Me.dgvLotNumbers.Rows(RowIndex).Cells("PartNumberColumn5").Value
            RowNominalDiameter = Me.dgvLotNumbers.Rows(RowIndex).Cells("NominalDiameterColumn5").Value
            RowNominalLength = Me.dgvLotNumbers.Rows(RowIndex).Cells("NominalLengthColumn5").Value
            RowCertType = Me.dgvLotNumbers.Rows(RowIndex).Cells("CertificationTypeColumn5").Value
            RowItemClass = Me.dgvLotNumbers.Rows(RowIndex).Cells("ItemClassColumn5").Value

            'Print Cert for selected Lot Number

            If RowItemClass = "TW DB" Or RowItemClass = "TW PS" Or RowItemClass = "TW SWR" Then
                'Get Pull Test Number for selected Lot Number Data
                Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestData WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber;"
                Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
                GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()

                'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
                If GetPullTestNumber = "" Then
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestData WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter"
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = RowNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestData WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber;"
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPullTestNumber = ""
                    End Try
                    con.Close()
                Else
                    'Do nothing - exact Pull Test exists
                End If

                'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
                If GetPullTestNumber = "" Then
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestData WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter"
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = RowNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestData WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber;"
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPullTestNumber = ""
                    End Try
                    con.Close()
                Else
                    'Do nothing - exact Pull Test exists
                End If

                'Write to error log
                If GetPullTestNumber = "" Then
                    GetPullTestNumber = "NO CERT"

                    Try
                        'Write to error log
                        cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status)", con)

                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                            .Add("@Date", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "Manual Reprint (No shipment)"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip
                    End Try
                End If
            ElseIf RowItemClass = "TW TT" Then
                'Get Pull Test Number for selected Lot Number Data
                Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestData WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber;"
                Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
                GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()

                'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
                If GetPullTestNumber = "" Then
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestData WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter"
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = RowNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestData WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber;"
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPullTestNumber = ""
                    End Try
                    con.Close()
                Else
                    'Do nothing - exact Pull Test exists
                End If

                'Write to error log
                If GetPullTestNumber = "" Then
                    GetPullTestNumber = "NO CERT"

                    Try
                        'Write to error log
                        cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status)", con)

                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                            .Add("@Date", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "Manual Reprint (No shipment)"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip
                    End Try
                End If
            Else
                'Get Pull Test Number for selected Lot Number Data
                Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestData WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber;"
                Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
                GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()

                'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
                If GetPullTestNumber = "" Then
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestData WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND NominalLength >= @NominalLength;"
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = RowNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@NominalLength", SqlDbType.VarChar).Value = RowNominalLength
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestData WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber;"
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPullTestNumber = ""
                    End Try
                    con.Close()
                Else
                    'Do nothing - exact Pull Test exists
                End If

                'Write to error log
                If GetPullTestNumber = "" Then
                    GetPullTestNumber = "NO CERT"

                    Try
                        'Write to error log
                        cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status)", con)

                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                            .Add("@Date", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "Manual Reprint (No shipment)"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip
                    End Try
                End If
            End If
            '**************************************************************************************************
            'If no pull test exists for the Heat, diameter show message
            If GetPullTestNumber = "" Or GetPullTestNumber = "NO CERT" Then
                MsgBox("No pull test exists for the selected Lot Number. Check your data and try again.", MsgBoxStyle.OkOnly)
            Else
                GlobalReprintHeatNumber = RowHeatNumber
                GlobalReprintLotNumber = RowLotNumber
                GlobalReprintPullTestNumber = GetPullTestNumber
                GlobalDivisionCode = cboDivisionID.Text

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

                If GetLoginType = "REMOTE" Then
                    Using NewReprintCertRemote As New ReprintCertRemote
                        Dim Result = NewReprintCertRemote.ShowDialog()
                    End Using
                Else
                    Using NewReprintCert As New ReprintCert
                        Dim Result = NewReprintCert.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    'Misc Routines and Functions

    Private Sub dtpItemCreationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpItemCreationDate.ValueChanged
        If dtpItemCreationDate.Focused And isLoaded Then
            needsSaved = True
        End If
    End Sub

    Private Sub tabItemMaintenance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabItemMaintenance.SelectedIndexChanged
        If tabItemMaintenance.SelectedIndex = 1 Then
            LoadQuantityOnHand()
        ElseIf tabItemMaintenance.SelectedIndex = 3 Then
            LoadAssemblySummary()
            LoadAssemblyTrackingData()
        ElseIf tabItemMaintenance.SelectedIndex = 4 Then
            LoadFormatting()
        ElseIf tabItemMaintenance.SelectedIndex = 5 Then
            If Not String.IsNullOrEmpty(lblFOXNumber.Text) Then
                If Val(lblFOXNumber.Text) <> 0 Then
                    ProductionAPI.LoadSingleFOXProductionData(New WIPDataPassed(dgvProductionData, lblFOXNumber.Text, pnlNoWIPData, True))
                Else
                    ProductionAPI.LoadSingleFOXProductionData(New WIPDataPassed(dgvProductionData, cboPartNumber.Text, pnlNoWIPData))
                End If
            End If
        ElseIf tabItemMaintenance.SelectedIndex = 6 Then
            LoadLotNumbers()
        Else
            'skip
        End If
    End Sub

    Private Sub bgwkLoadInventoryTotals_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkLoadInventoryTotals.DoWork
        Dim part As String = e.Argument.ToString
        ATLQuantityOnHand = 0
        CBSQuantityOnHand = 0
        CHTQuantityOnHand = 0
        TWDQuantityOnHand = 0
        TFFQuantityOnHand = 0
        TFTQuantityOnHand = 0
        TFPQuantityOnHand = 0
        TWEQuantityOnHand = 0
        SLCQuantityOnHand = 0
        CGOQuantityOnHand = 0
        HOUQuantityOnHand = 0
        TORQuantityOnHand = 0
        ALBQuantityOnHand = 0

        'Load QOH for current division
        Dim ATLQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim ATLQOHCommand As New SqlCommand(ATLQOHString, con1)
        ATLQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        ATLQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"

        Dim CBSQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim CBSQOHCommand As New SqlCommand(CBSQOHString, con1)
        CBSQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        CBSQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"

        Dim CHTQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim CHTQOHCommand As New SqlCommand(CHTQOHString, con1)
        CHTQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        CHTQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"

        Dim SLCQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim SLCQOHCommand As New SqlCommand(SLCQOHString, con1)
        SLCQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        SLCQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

        Dim HOUQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim HOUQOHCommand As New SqlCommand(HOUQOHString, con1)
        HOUQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        HOUQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"

        Dim CGOQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim CGOQOHCommand As New SqlCommand(CGOQOHString, con1)
        CGOQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        CGOQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"

        Dim TFFQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim TFFQOHCommand As New SqlCommand(TFFQOHString, con1)
        TFFQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        TFFQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"

        Dim TFTQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim TFTQOHCommand As New SqlCommand(TFTQOHString, con1)
        TFTQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        TFTQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"

        Dim TWEQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim TWEQOHCommand As New SqlCommand(TWEQOHString, con1)
        TWEQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        TWEQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        Dim TWDQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim TWDQOHCommand As New SqlCommand(TWDQOHString, con1)
        TWDQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        TWDQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        Dim TFPQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim TFPQOHCommand As New SqlCommand(TFPQOHString, con1)
        TFPQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        TFPQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        Dim TORQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InventoryPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InventoryAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim TORQOHCommand As New SqlCommand(TORQOHString, con1)
        TORQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        TORQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"

        Dim ALBQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InvenALByPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InvenALByAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim ALBQOHCommand As New SqlCommand(ALBQOHString, con1)
        ALBQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        ALBQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"

        Dim TFJQOHString As String = "SELECT (ISNULL(ADMPurchaseOrderTotals.TotalPOQuantityReceived, 0) + ISNULL(ADMProductionTotal.SumProductionQuantity, 0) - ISNULL(ADMSalesOrderTotals.TotalQuantityShipped, 0) + ISNULL(ADMAdjustmentTotal.AdjustmentQuantity, 0) + ISNULL(ADMCustomerReturnTotal.ReturnQuantity, 0) - ISNULL(ADMVendorReturnTotal.VendorReturnQuantity, 0) + ISNULL(ADMWCProductionTotal.WCProductionQuantity, 0) + ISNULL(ADMAssemblyBuildTotal.BuildQuantity, 0)) as QuantityOnHand FROM (SELECT ItemID, BeginningBalance FROM dbo.ItemList WHERE DivisionID = @DivisionID and ItemID = @ItemID) as ItemList LEFT OUTER JOIN (SELECT SUM(BuildQuantity) AS BuildQuantity, ComponentPartNumber FROM dbo.AssemblyBuildLineTable WHERE DivisionID = @DivisionID and ComponentPartNumber = @ItemID GROUP BY ComponentPartNumber, DivisionID) as ADMAssemblyBuildTotal  ON ItemList.ItemID = ADMAssemblyBuildTotal.ComponentPartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(ProductionQuantity) AS WCProductionQuantity FROM (SELECT PartNumber, ProductionQuantity FROM FerruleProductionLines INNER JOIN FerruleProductionHeaderTable ON FerruleProductionLines.FerruleProductionKey = FerruleProductionHeaderTable.FerruleTransactionKey AND DivisionID = @DivisionID WHERE PartNumber = @ItemID) as Temp GROUP BY PartNumber, ProductionQuantity)as ADMWCProductionTotal ON ItemList.ItemID = ADMWCProductionTotal.PartNumber LEFT OUTER JOIN (SELECT dbo.PurchaseOrderLineQuery.PartNumber,  SUM(dbo.PurchaseOrderLineQuery.OrderQuantity) AS OrderQuantity, SUM(ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS TotalPOQuantityReceived, SUM(dbo.PurchaseOrderLineQuery.OrderQuantity - ISNULL(dbo.ReceivingLineQuery1.QuantityReceived, 0)) AS POQuantityOpen FROM  dbo.PurchaseOrderLineQuery LEFT OUTER JOIN dbo.ReceivingLineQuery1 ON dbo.PurchaseOrderLineQuery.PurchaseOrderLineNumber = dbo.ReceivingLineQuery1.POLineNumber AND dbo.PurchaseOrderLineQuery.PartNumber = dbo.ReceivingLineQuery1.PartNumber AND dbo.PurchaseOrderLineQuery.PurchaseOrderHeaderKey = dbo.ReceivingLineQuery1.PONumber WHERE dbo.PurchaseOrderLineQuery.DivisionID = @DivisionID AND dbo.PurchaseOrderLineQuery.PartNumber = @ItemID GROUP BY dbo.PurchaseOrderLineQuery.PartNumber) AS ADMPurchaseOrderTotals ON ItemList.ItemID = ADMPurchaseOrderTotals.PartNumber LEFT OUTER JOIN (SELECT dbo.TimeSlipLineItemTable.PartNumber, SUM(dbo.TimeSlipLineItemTable.InvenTFJyPieces) AS SumProductionQuantity FROM dbo.TimeSlipHeaderTable INNER JOIN dbo.TimeSlipLineItemTable ON dbo.TimeSlipHeaderTable.TimeSlipKey = dbo.TimeSlipLineItemTable.TimeSlipKey WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) As ADMProductionTotal ON ItemList.ItemID = ADMProductionTotal.PartNumber LEFT OUTER JOIN (SELECT ItemID, SUM(QuantityShipped) AS TotalQuantityShipped, SUM(QuantityOrdered) AS TotalQuantityOrdered, SUM(CASE WHEN LineStatus <> 'CLOSED' THEN QuantityOrdered - QuantityShipped ELSE 0 END) AS TotalQuantityOpen, SUM(PendingShippingQuantity) AS TotalQuantityPending FROM dbo.SalesOrderQuantityStatusStep1 WHERE (LineStatus <> 'QUOTE') and DivisionKey = @DivisionID and ItemID = @ItemID GROUP BY ItemID) AS ADMSalesOrderTotals ON ItemList.ItemID = ADMSalesOrderTotals.ItemID LEFT OUTER JOIN (SELECT SUM(dbo.VendorReturnLine.Quantity) AS VendorReturnQuantity, dbo.VendorReturnLine.PartNumber FROM dbo.VendorReturn INNER JOIN dbo.VendorReturnLine ON dbo.VendorReturn.ReturnNumber = dbo.VendorReturnLine.ReturnNumber WHERE dbo.VendorReturnLine.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMVendorReturnTotal ON ItemList.ItemID = ADMVendorReturnTotal.PartNumber LEFT OUTER JOIN (SELECT SUM(dbo.ReturnProductLineTable.Quantity) AS ReturnQuantity,dbo.ReturnProductLineTable.PartNumber FROM dbo.ReturnProductHeaderTable INNER JOIN dbo.ReturnProductLineTable ON dbo.ReturnProductHeaderTable.ReturnNumber = dbo.ReturnProductLineTable.ReturnNumber WHERE dbo.ReturnProductLineTable.DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY dbo.ReturnProductLineTable.PartNumber) As ADMCustomerReturnTotal ON ItemList.ItemID = ADMCustomerReturnTotal.PartNumber LEFT OUTER JOIN (SELECT PartNumber, SUM(Quantity) AS AdjustmentQuantity FROM dbo.InvenTFJyAdjustmentTable WHERE DivisionID = @DivisionID and PartNumber = @ItemID GROUP BY PartNumber) AS ADMAdjustmentTotal ON ItemList.ItemID = ADMAdjustmentTotal.PartNumber"
        Dim TFJQOHCommand As New SqlCommand(TFJQOHString, con1)
        TFJQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        TFJQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"

        If con1.State = ConnectionState.Closed Then con1.Open()
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            ATLQuantityOnHand = CDbl(ATLQOHCommand.ExecuteScalar)
        Catch ex As Exception
            ATLQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            CBSQuantityOnHand = CDbl(CBSQOHCommand.ExecuteScalar)
        Catch ex As Exception
            CBSQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            CGOQuantityOnHand = CDbl(CGOQOHCommand.ExecuteScalar)
        Catch ex As Exception
            CGOQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            CHTQuantityOnHand = CDbl(CHTQOHCommand.ExecuteScalar)
        Catch ex As Exception
            CHTQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            HOUQuantityOnHand = CDbl(HOUQOHCommand.ExecuteScalar)
        Catch ex As Exception
            HOUQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            SLCQuantityOnHand = CDbl(SLCQOHCommand.ExecuteScalar)
        Catch ex As Exception
            SLCQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            TFTQuantityOnHand = CDbl(TFTQOHCommand.ExecuteScalar)
        Catch ex As Exception
            TFTQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            TFFQuantityOnHand = CDbl(TFFQOHCommand.ExecuteScalar)
        Catch ex As Exception
            TFFQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            TWDQuantityOnHand = CDbl(TWDQOHCommand.ExecuteScalar)
        Catch ex As Exception
            TWDQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            TWEQuantityOnHand = CDbl(TWEQOHCommand.ExecuteScalar)
        Catch ex As Exception
            TWEQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            TFPQuantityOnHand = CDbl(TFPQOHCommand.ExecuteScalar)
        Catch ex As Exception
            TFPQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            TORQuantityOnHand = CDbl(TORQOHCommand.ExecuteScalar)
        Catch ex As Exception
            TORQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            TFJQuantityOnHand = CDbl(TFJQOHCommand.ExecuteScalar)
        Catch ex As Exception
            TFJQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        Try
            ALBQuantityOnHand = CDbl(ALBQOHCommand.ExecuteScalar)
        Catch ex As Exception
            ALBQuantityOnHand = 0
        End Try
        If bgwkLoadInventoryTotals.CancellationPending Then
            con1.Close()
            Exit Sub
        End If
        If con1.State = ConnectionState.Open Then con1.Close()
    End Sub

    Private Sub bgwkLoadInventoryTotals_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkLoadInventoryTotals.RunWorkerCompleted
        lblAtlantInventory.Text = FormatNumber(ATLQuantityOnHand, 1)
        lblLasVegasInventory.Text = FormatNumber(CBSQuantityOnHand, 1)
        lblWeldingCeramicsInventory.Text = FormatNumber(CHTQuantityOnHand, 1)
        lblTWDInventory.Text = FormatNumber(TWDQuantityOnHand, 1)
        lblVancouverInventory.Text = FormatNumber(TFFQuantityOnHand, 1)
        lblTexasInventory.Text = FormatNumber(TFTQuantityOnHand, 1)
        lblTFPInventory.Text = FormatNumber(TFPQuantityOnHand, 1)
        lblTWEInventory.Text = FormatNumber(TWEQuantityOnHand, 1)
        lblSaltLakeInventory.Text = FormatNumber(SLCQuantityOnHand, 1)
        lblChicagoInventory.Text = FormatNumber(CGOQuantityOnHand, 1)
        lblHoustonQOH.Text = FormatNumber(HOUQuantityOnHand, 1)
        lblTorontoQOH.Text = FormatNumber(TORQuantityOnHand, 1)
        lblAlbertaQOH.Text = FormatNumber(ALBQuantityOnHand, 1)
        lblJerseyQOH.Text = FormatNumber(TFJQuantityOnHand, 1)
    End Sub

    Private Sub lblFOXNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFOXNumber.TextChanged
        LoadNumberOfFoxes()
    End Sub

    'Tool Tips

    Public Sub LoadLabelToolTip()
        LabelToolTip.SetToolTip(lblUpdatedPrice, "The last sales price has been adjusted.")
        LabelToolTip.ToolTipTitle = "Adjusted Price"
        LabelToolTip.IsBalloon = False
        LabelToolTip.ToolTipIcon = ToolTipIcon.None
        LabelToolTip.UseAnimation = False
    End Sub

    Public Sub LoadLabelToolTip2()
        LabelToolTip2.SetToolTip(lblAvgPerMonth, "Last 365 days from today.")
        LabelToolTip2.ToolTipTitle = "Rolling Average"
        LabelToolTip2.IsBalloon = False
        LabelToolTip2.ToolTipIcon = ToolTipIcon.None
        LabelToolTip2.UseAnimation = False
    End Sub

    Private Sub lblAvgPerMonth_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAvgPerMonth.MouseHover
        LoadLabelToolTip2()
    End Sub

    'Key press events

    Private Sub cboComponentDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboComponentDescription.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboComponentPartNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboComponentPartNumber.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboItemClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboItemClass.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboPartDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPartDescription.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboPartNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPartNumber.KeyPress
        If e.KeyChar.Equals(""""c) Or e.KeyChar.Equals("'"c) Then
            e.KeyChar = Nothing
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboPurchaseProductID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPurchaseProductID.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSalesProductLine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSalesProductLine.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboVendorID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVendorID.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboWarehouse_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboWarehouse.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboAddAccessories_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAddAccessories.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboDeleteComponent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDeleteComponent.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSafetyDataSheet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSafetyDataSheet.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

End Class