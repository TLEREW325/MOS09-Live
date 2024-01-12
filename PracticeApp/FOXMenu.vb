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
Public Class FOXMenu
    Inherits System.Windows.Forms.Form

    Dim FormName As String = "FOX Form"
    Dim OrderReferenceNumber, NextFOXNumber, LastFOXNumber As Integer
    Dim ProductionNote, MachineDescription, BlueprintRevision, FOXStatus, SteelCarbon, SteelSize, GLCreditAccount, FirstReleaseDate, FinishedGoods, CertDescription, SteelDescription, RMID, PartNumber, BlueprintNumber, FluxLoadNumber, Comments, CertificationCode, CertType, BoxType As String
    Dim SOQuantityOpen, SOQuantityShipped, RawMaterialWeight, FinishedWeight, ScrapWeight, TWDQuantityOnHand As Double
    Dim OrderStatus, ShippingAccount, ShipEmail, SOStatus, ShipToName, CustomerID, LongDescription, ShortDescription, ItemClass, PurchProdLineID, SalesProdLineID, OldPartNumber As String
    Dim SalesOrderTotal, ProductTotal, PieceWeight, BoxWeight, PalletWeight, StandardCost, StandardPrice As Double
    Dim TotalQuantityShippedCombined, ShippedPrevious, ProductionQuantity, BoxCount, PalletCount, PalletPieces, MinimumStock, MaximumStock As Integer
    Dim MAXSalesOrder, NextSalesOrderNumber, LastSalesOrderNumber, NextReleaseLineNumber, LastReleaseLineNumber, NextProcessStepNumber, LastProcessStepNumber, TWDCommittedQuantity As Integer
    Dim CreationDate, PromiseDate As DateTime
    Dim CheckOldPreferredRMID, CheckOldAlternateRMID, AuditComment As String
    Dim IsSteelTypeValid As String = ""

    'Special Field Variables
    Dim ATLPartNumber, CustomerPartNumber, CustomerPONumber As String

    Const PalletCost As Double = 6.38
    Const BoxCost As Double = 0.7
    Dim TodaysDate As Date
    Dim BlueprintFailurePath As String = "\\TFP-FS\TransferData\Blueprint\Unable to locate blueprint.pdf"

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

    'Variables for shipping
    Dim CheckShippingMethod, ThirdPartyShipper, ShipMethod, BillToName, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip As String

    'Variables to calculate MTD and YTD Production
    Dim YearDate, MonthDate, BeginDate, EndDate As Date
    Dim YearOfYear, MonthOfYear, Year As Integer
    Dim strMonthOfYear, strYear As String
    Dim MTDProduction, YTDProduction As Integer

    Dim QuotedQuantity, QuotedPrice As Double
    Dim QuoteNumber As String = ""

    'Variables for error logging
    Dim ErrorDate As Date = Today()
    Dim ErrorComment, ErrorDivision, ErrorDescription, ErrorReferenceNumber, ErrorUser As String
       
    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12, myAdapter13, myAdapter14, myAdapter15, myAdapter16, myAdapter17, myAdapter18, myAdapter19 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds4, ds5, ds6, ds7, ds8, ds10, ds11, ds12, ds13, ds14, ds15, ds16, ds17, ds18, ds19 As DataSet
    Dim SteelDT As Data.DataTable
    Dim isLoaded As Boolean = False
    Dim needsSaved As Boolean = False
    Dim controlKey As Boolean = False
    Dim lastFOX As String = ""
    Dim machineIDCheck As New List(Of String)

    Public Class FOXStep
        Public ProcessStep As Integer
        Public ProcessAddFG As String

        Public Sub New(ByVal procStep As Integer, ByVal AddFG As String)
            ProcessStep = procStep
            ProcessAddFG = AddFG
        End Sub
    End Class

    Const constLabor As Double = 28

    Dim CompletionTasks As New List(Of ProductionCompletion)

    Dim BoxReference As New Dictionary(Of String, String)

    ''For drag and drop line reorder
    Dim dragBoxFromMouseDown As System.Drawing.Rectangle
    Dim rowIndexFromMouseDown As Integer = -1
    Dim rowIndexOfItemUnderMouseToDrop As Integer = -1

    'Form Operations

    Private Sub FOXMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'Form Login Routine
        FormLoginRoutine()

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadSteel()
        LoadMachineNumber()
        LoadBoxType()
        LoadBoxReferences()
        LoadCertificationType()
        LoadDivision()
        LoadFluxNumbers()
        isLoaded = True

        If EmployeeSecurityCode = 1030 Or EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            txtBoxCount.ReadOnly = False
            txtBoxWeight.ReadOnly = False
            txtPalletCount.ReadOnly = False
            txtPieceWeight.ReadOnly = False
        Else
            txtBoxCount.ReadOnly = True
            txtBoxWeight.ReadOnly = True
            txtPalletCount.ReadOnly = True
            txtPieceWeight.ReadOnly = True
        End If

        cboDivisionID.Text = EmployeeCompanyCode
        TodaysDate = Today.ToShortDateString()

        'Loads Global FOX if applicable
        If GlobalFOXNumber < 1 Then
            cboFOXNumber.SelectedIndex = -1
        Else
            cboDivisionID.Text = GlobalDivisionCode
            cboFOXNumber.Text = GlobalFOXNumber
        End If

        usefulFunctions.LoadSecurity(Me)
    End Sub

    Private Sub FOXMenu_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            unlockBatch()
        End If
    End Sub

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), &HF060, 1)
            Case &HFFFFFFFF
        End Select
    End Sub

    Private Sub FOXMenu_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    'Load datasets and controls

    Public Sub LoadFormatting()
        Dim ShipmentStatus As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvFOXReleaseSchedule.Rows
            Try
                ShipmentStatus = row.Cells("StatusColumn").Value
            Catch ex As System.Exception
                ShipmentStatus = ""
            End Try

            If ShipmentStatus = "OPEN" Then
                Me.dgvFOXReleaseSchedule.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvFOXReleaseSchedule.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf ShipmentStatus = "PENDING" Then
                Me.dgvFOXReleaseSchedule.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            ElseIf ShipmentStatus = "SHIPPED" Then
                Me.dgvFOXReleaseSchedule.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvFOXReleaseSchedule.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvFOXReleaseSchedule.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvFOXReleaseSchedule.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub LoadOutsideOperations()
        cmd = New SqlCommand("SELECT Vendor, Operation, TurnAround as [Turn Around], ProcessStep as [Process Step], EntryNumber FROM FOXOutsideOperations WHERE FOXNumber = @FOXNumber ORDER BY ProcessStep", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
        Dim tempds As New DataSet()
        Dim tempadap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        tempadap.Fill(tempds, "FOXOutsideOperations")
        con.Close()
        dgvFOXOutsideData.DataSource = tempds.Tables("FOXOutsideOperations")
        dgvFOXOutsideData.Columns("EntryNumber").Visible = False
    End Sub

    Private Sub LoadCurrentProductionNumber()
        cmd = New SqlCommand("SELECT ProductionNumber, ProductionQuantity FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN';", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not reader.IsDBNull(0) Then
                txtProductionNumber.Text = reader.Item("ProductionNumber").ToString()
            Else
                txtProductionNumber.Text = ""
            End If
            If Not reader.IsDBNull(1) Then
                txtProductionQuantity.Text = reader.Item("ProductionQuantity").ToString()
            Else
                txtProductionQuantity.Text = ""
            End If
        Else
            txtProductionNumber.Text = ""
            txtProductionQuantity.Text = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub LoadDivision()
        cboDivisionID.Items.Add("TWD")
        cboDivisionID.Items.Add("TFP")

        If EmployeeCompanyCode.Equals("TST") Then
            cboDivisionID.Items.Add("TST")
        End If

        cboDivisionID.SelectedIndex = -1
    End Sub

    Public Sub ShowHeatNumbers()
        cmd = New SqlCommand("SELECT * FROM LotNumber WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter17.SelectCommand = cmd
        myAdapter17.Fill(ds, "LotNumber")
        dgvHeatNumberLog.DataSource = ds.Tables("LotNumber")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        Dim TextFilter As String = ""

        If cboDivisionID.Text = "TFP" Then
            TextFilter = "Trufit Parts"
        Else
            TextFilter = "TW%"
        End If

        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND ItemClass LIKE @TEXT ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@TEXT", SqlDbType.VarChar).Value = TextFilter
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "FOXTable")
        con.Close()

        cboFOXNumber.DisplayMember = "FOXNumber"
        cboFOXNumber.DataSource = ds2.Tables("FOXTable")
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowProcesses()
        Dim changed As Boolean = False
        If isLoaded Then
            changed = True
            isLoaded = False
        End If

        cmd = New SqlCommand("SELECT * FROM FoxSched WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "FoxSched")
        con.Close()
        dgvFoxProcesses.DataSource = ds4.Tables("FoxSched")
        If changed Then
            isLoaded = True
        End If
    End Sub

    Public Sub ClearProcesses()
        Me.dgvFoxProcesses.DataSource = Nothing
    End Sub

    Public Sub LoadMachineNumber()
        cmd = New SqlCommand("SELECT MachineID FROM MachineTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "MachineTable")
        con.Close()

        cboProcessID.DisplayMember = "MachineID"
        cboProcessID.DataSource = ds5.Tables("MachineTable")
        cboProcessID.SelectedIndex = -1

        For i As Integer = 0 To ds5.Tables("MachineTable").Rows.Count - 1
            machineIDCheck.Add(ds5.Tables("MachineTable").Rows(i).Item("MachineID").ToString())
        Next
    End Sub

    Private Sub LoadBoxType()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE ItemClass = 'BOXES' AND DivisionID = 'TWD'", con)

        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter6.Fill(ds6, "ItemList")
        con.Close()

        cboBoxType.DisplayMember = "ItemID"
        cboBoxType.DataSource = ds6.Tables("ItemList")
        cboBoxType.SelectedIndex = -1
    End Sub

    Private Sub LoadBoxReferences()
        cmd = New SqlCommand("SELECT BoxTypeID, ItemID FROM BoxType", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not BoxReference.ContainsKey(reader.Item("BoxTypeID")) Then
                    BoxReference.Add(reader.Item("BoxTypeID"), reader.Item("ItemID"))
                End If
            End While
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub ShowReleases()
        cmd = New SqlCommand("SELECT * FROM FOXReleaseSchedule WHERE FOXNumber = @FOXNumber ORDER BY ReleaseDate", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "FOXReleaseSchedule")
        dgvFOXReleaseSchedule.DataSource = ds7.Tables("FOXReleaseSchedule")
        con.Close()

        LoadFormatting()
    End Sub

    Public Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "CustomerList")
        cboCustomerID.DataSource = ds8.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadSteel()
        cmd = New SqlCommand("SELECT RMID, Carbon, SteelSize, Description FROM RawMaterialsTable WHERE DivisionID = 'TWD'", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        myAdapter9.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter9.Fill(SteelDT)
        con.Close()

        Dim tmpCarbonDT As Data.DataTable = SteelDT.DefaultView.ToTable(True, "Carbon")

        cboSteelCarbon.DisplayMember = "Carbon"
        cboSteelCarbon.DataSource = tmpCarbonDT
        cboSteelCarbon.SelectedIndex = -1

        cboAlternateCarbon.DisplayMember = "Carbon"
        cboAlternateCarbon.DataSource = tmpCarbonDT.Copy()
        cboAlternateCarbon.SelectedIndex = -1

        Dim tmpSizeDT As Data.DataTable = SteelDT.DefaultView.ToTable(True, "SteelSize")

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = tmpSizeDT
        cboSteelSize.SelectedIndex = -1

        cboAlternateSteelSize.DisplayMember = "SteelSize"
        cboAlternateSteelSize.DataSource = tmpSizeDT.Copy()
        cboAlternateSteelSize.SelectedIndex = -1
    End Sub

    Private Sub LoadCertificationType()
        cmd = New SqlCommand("SELECT CertificationCode, CertificationType FROM CertificationType ORDER BY (CASE WHEN ISNUMERIC( CertificationCode) <> 1 then 9999 else CAST(CertificationCode as int) END)", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds10 = New DataSet()
        myAdapter10.SelectCommand = cmd
        myAdapter10.Fill(ds10, "CertificationType")
        cboCertCode.DataSource = ds10.Tables("CertificationType")
        cboCertType.DataSource = ds10.Tables("CertificationType")
        con.Close()
        cboCertType.SelectedIndex = -1
        cboCertCode.SelectedIndex = -1
    End Sub

    Public Sub LoadAdditionalShipTo()
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds12 = New DataSet()
        myAdapter12.SelectCommand = cmd
        myAdapter12.Fill(ds12, "AdditionalShipTo")
        cboShipToID.DataSource = ds12.Tables("AdditionalShipTo")
        con.Close()
        cboShipToID.SelectedIndex = -1
    End Sub

    Public Sub LoadBillingAddress()
        cmd = New SqlCommand("SELECT BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("BillToAddress1")) Then
                txtBillingAddress1.Text = reader.Item("BillToAddress1")
            End If
            If Not IsDBNull(reader.Item("BillToAddress2")) Then
                txtBillingAddress2.Text = reader.Item("BillToAddress2")
            End If
            If Not IsDBNull(reader.Item("BillToCity")) Then
                txtBillingCity.Text = reader.Item("BillToCity")
            End If
            If Not IsDBNull(reader.Item("BillToState")) Then
                txtBillingState.Text = reader.Item("BillToState")
            End If
            If Not IsDBNull(reader.Item("BillToZip")) Then
                txtBillingZip.Text = reader.Item("BillToZip")
            End If
            If Not IsDBNull(reader.Item("BillToCountry")) Then
                txtBillingCountry.Text = reader.Item("BillToCountry")
            End If
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub LoadPartDescription()
        Dim TextFilter As String = ""

        If cboDivisionID.Text = "TFP" Then
            TextFilter = "Trufit Parts"
        Else
            TextFilter = "TW%"
        End If

        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND ItemClass LIKE @TEXT ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@TEXT", SqlDbType.VarChar).Value = TextFilter
        If con.State = ConnectionState.Closed Then con.Open()
        ds13 = New DataSet()
        myAdapter13.SelectCommand = cmd
        myAdapter13.Fill(ds13, "ItemList")
        cboPartDescription.DataSource = ds13.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds14 = New DataSet()
        myAdapter14.SelectCommand = cmd
        myAdapter14.Fill(ds14, "CustomerList")
        cboCustomerName.DataSource = ds14.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Private Sub LoadFOXCertifications()
        If isLoaded Then
            cmd = New SqlCommand("SELECT Certification FROM FOXCertifications WHERE FOXNumber = @FOXNumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
            ds15 = New DataSet()
            myAdapter15.SelectCommand = cmd

            If con.State = ConnectionState.Closed Then con.Open()
            myAdapter15.Fill(ds15, "FOXCertifications")
            con.Close()

            dgvFOXCertifications.DataSource = ds15.Tables("FOXCertifications")
            If dgvFOXCertifications.RowCount = 0 Then
                cmdDeleteFOXCertification.Enabled = False
            Else
                cmdDeleteFOXCertification.Enabled = True
            End If
        End If
    End Sub

    Public Sub ShowFOXProduction()
        cmd = New SqlCommand("SELECT * FROM FOXPiecesProducedByMachine WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds16 = New DataSet()
        myAdapter16.SelectCommand = cmd
        myAdapter16.Fill(ds16, "FOXPiecesProducedByMachine")
        dgvFOXProduction.DataSource = ds16.Tables("FOXPiecesProducedByMachine")
        con.Close()
    End Sub

    Public Sub ShowMachineCost()
        cmd = New SqlCommand("SELECT * FROM FoxScheduleWithCost WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds17 = New DataSet()
        myAdapter17.SelectCommand = cmd
        myAdapter17.Fill(ds17, "FoxScheduleWithCost")
        dgvMachineCost.DataSource = ds17.Tables("FoxScheduleWithCost")
        con.Close()
    End Sub

    Private Sub LoadFluxNumbers()
        cmd = New SqlCommand("SELECT RMID FROM RawMaterialsTable WHERE Carbon = 'ABALL'", con)
        ds18 = New DataSet
        myAdapter18.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter18.Fill(ds18, "RawMaterialsTable")
        con.Close()

        cboFluxLoadNumber.DisplayMember = "RMID"
        cboFluxLoadNumber.DataSource = ds18.Tables("RawMaterialsTable")
        cboFluxLoadNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadProductionProcesses()
        cmd = New SqlCommand("SELECT * FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber ORDER BY ProductionNumber, FOXNumber, ProcessStep", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds19 = New DataSet()
        myAdapter19.SelectCommand = cmd
        myAdapter19.Fill(ds19, "FOXProductionNumberSched")
        dgvProductionProcesses.DataSource = ds19.Tables("FOXProductionNumberSched")
        con.Close()
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

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub LoadNumberOfFoxesForPart()
        Dim CountFoxNumber As Integer = 0

        Dim CountFoxNumberStatement As String = "SELECT COUNT(FOXNumber) FROM FOXTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND FOXNumber <> @FOXNumber"
        Dim CountFoxNumberCommand As New SqlCommand(CountFoxNumberStatement, con)
        CountFoxNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        CountFoxNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CountFoxNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountFoxNumber = CInt(CountFoxNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CountFoxNumber = 0
        End Try
        con.Close()

        If CountFoxNumber = 0 Then
            txtNumberOfFoxes.Clear()
        ElseIf CountFoxNumber = 1 Then
            txtNumberOfFoxes.Text = "There is one other FOX for this specific part number."
        Else
            txtNumberOfFoxes.Text = "There are " + CStr(CountFoxNumber) + " other FOXES with this part number."
        End If
    End Sub

    Public Sub LoadDefaultShippingAddress()
        Dim Ship2Address1, Ship2Address2, Ship2City, Ship2State, Ship2Zip, Ship2Country, Ship2Name As String

        Dim Address1String As String = "SELECT CustomerName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShippingAccount, ShipEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim Address1Command As New SqlCommand(Address1String, con)
        Address1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        Address1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = Address1Command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerName")) Then
                Ship2Name = ""
            Else
                Ship2Name = reader.Item("CustomerName")
            End If
            If IsDBNull(reader.Item("ShipToAddress1")) Then
                Ship2Address1 = ""
            Else
                Ship2Address1 = reader.Item("ShipToAddress1")
            End If
            If IsDBNull(reader.Item("ShipToAddress2")) Then
                Ship2Address2 = ""
            Else
                Ship2Address2 = reader.Item("ShipToAddress2")
            End If
            If IsDBNull(reader.Item("ShipToCity")) Then
                Ship2City = ""
            Else
                Ship2City = reader.Item("ShipToCity")
            End If
            If IsDBNull(reader.Item("ShipToState")) Then
                Ship2State = ""
            Else
                Ship2State = reader.Item("ShipToState")
            End If
            If IsDBNull(reader.Item("ShipToZip")) Then
                Ship2Zip = ""
            Else
                Ship2Zip = reader.Item("ShipToZip")
            End If
            If IsDBNull(reader.Item("ShipToCountry")) Then
                Ship2Country = ""
            Else
                Ship2Country = reader.Item("ShipToCountry")
            End If
            If IsDBNull(reader.Item("ShippingAccount")) Then
                ShippingAccount = ""
            Else
                ShippingAccount = reader.Item("ShippingAccount")
            End If
            If IsDBNull(reader.Item("ShipEmail")) Then
                ShipEmail = ""
            Else
                ShipEmail = reader.Item("ShipEmail")
            End If
        Else
            Ship2Name = ""
            Ship2Address1 = ""
            Ship2Address2 = ""
            Ship2City = ""
            Ship2State = ""
            Ship2Zip = ""
            Ship2Country = ""
            ShippingAccount = ""
            ShipEmail = ""
        End If
        reader.Close()
        con.Close()

        txtSTAddress1.Text = Ship2Address1
        txtSTAddress2.Text = Ship2Address2
        txtSTCity.Text = Ship2City
        txtSTCountry.Text = Ship2Country
        txtSTZip.Text = Ship2Zip
        cboSTState.Text = Ship2State
        txtSTName.Text = Ship2Name
        txtShipEmail.Text = ShipEmail
        txtShippingAccount.Text = ShippingAccount
    End Sub

    Public Sub LoadAddShipToData()
        Dim Ship2Address1, Ship2Address2, Ship2City, Ship2State, Ship2Zip, Ship2Country, Ship2Name As String

        Dim Address1String As String = "SELECT Name, Address1, Address2, City, State, Zip, Country FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim Address1Command As New SqlCommand(Address1String, con)
        Address1Command.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
        Address1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        Address1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = Address1Command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Name")) Then
                Ship2Name = ""
            Else
                Ship2Name = reader.Item("Name")
            End If
            If IsDBNull(reader.Item("Address1")) Then
                Ship2Address1 = ""
            Else
                Ship2Address1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                Ship2Address2 = ""
            Else
                Ship2Address2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                Ship2City = ""
            Else
                Ship2City = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                Ship2State = ""
            Else
                Ship2State = reader.Item("State")
            End If
            If IsDBNull(reader.Item("Zip")) Then
                Ship2Zip = ""
            Else
                Ship2Zip = reader.Item("Zip")
            End If
            If IsDBNull(reader.Item("Country")) Then
                Ship2Country = ""
            Else
                Ship2Country = reader.Item("Country")
            End If
        Else
            Ship2Name = ""
            Ship2Address1 = ""
            Ship2Address2 = ""
            Ship2City = ""
            Ship2State = ""
            Ship2Zip = ""
            Ship2Country = ""
        End If
        reader.Close()
        con.Close()

        txtSTAddress1.Text = Ship2Address1
        txtSTAddress2.Text = Ship2Address2
        txtSTCity.Text = Ship2City
        txtSTCountry.Text = Ship2Country
        txtSTZip.Text = Ship2Zip
        cboSTState.Text = Ship2State
        txtSTName.Text = Ship2Name
    End Sub

    Public Sub LoadFOXCosting()
        'Get Current Steel Cost
        Dim SteelCostPound As Double = 0
        Dim FOXSteelCost As Double = 0
        Dim TotalSteelUsedToDate As Double = 0
        Dim FOXPieceWeight As Double = 0
        Dim OverHeadCost As Double = 0
        Dim TotalFOXCost As Double = 0
        Dim WeightPerThousand As Double = 0
        Dim SumOverhead As Double = 0
        Dim SumPiecesProduced As Double = 0
        Dim ShippingCost As Double = 0
        Dim OtherCost As Double = 0
        Dim FOXPalletCost As Double = 0
        Dim FOXBoxCost As Double = 0
        Dim FOXBoxCount As Integer = 0
        Dim FOXPalletPieces As Integer = 0

        '*************************************************************************************
        Dim SteelUsedToDateStatement As String = "SELECT SUM(UsageWeight) FROM SteelUsageTable WHERE RMID = @RMID"
        Dim SteelUsedToDateCommand As New SqlCommand(SteelUsedToDateStatement, con)
        SteelUsedToDateCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalSteelUsedToDate = CDbl(SteelUsedToDateCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSteelUsedToDate = 0
        End Try
        con.Close()

        If TotalSteelUsedToDate = 0 Then TotalSteelUsedToDate = 1
        '*************************************************************************************
        'Get Steel Cost per Pound
        Dim FOXSteelCostStatement As String = "SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND @TotalQuantityUsedToDate BETWEEN LowerLimit AND UpperLimit"
        Dim FOXSteelCostCommand As New SqlCommand(FOXSteelCostStatement, con)
        FOXSteelCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
        FOXSteelCostCommand.Parameters.Add("@TotalQuantityUsedToDate", SqlDbType.VarChar).Value = TotalSteelUsedToDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelCostPound = CDbl(FOXSteelCostCommand.ExecuteScalar)
        Catch ex As Exception
            SteelCostPound = 0
        End Try
        con.Close()
        '*************************************************************************************
        'Get Piece Weight
        Dim FOXPieceWeightStatement As String = "SELECT FinishedWeight FROM FOXTable WHERE FOXNumber = @FOXNumber"
        Dim FOXPieceWeightCommand As New SqlCommand(FOXPieceWeightStatement, con)
        FOXPieceWeightCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            WeightPerThousand = CDbl(FOXPieceWeightCommand.ExecuteScalar)
        Catch ex As Exception
            WeightPerThousand = 0
        End Try
        con.Close()

        If WeightPerThousand <> 0 Then
            FOXPieceWeight = WeightPerThousand / 1000
        Else
            FOXPieceWeight = 0
        End If

        FOXSteelCost = FOXPieceWeight * SteelCostPound
        FOXSteelCost = Math.Round(FOXSteelCost, 4)
        '*************************************************************************************
        'Get Overhead Cost
        Dim SumPiecesProducedStatement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber"
        Dim SumPiecesProducedCommand As New SqlCommand(SumPiecesProducedStatement, con)
        SumPiecesProducedCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

        Dim SumOverheadCostStatement As String = "SELECT SUM(ExtendedCost) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber"
        Dim SumOverheadCostCommand As New SqlCommand(SumOverheadCostStatement, con)
        SumOverheadCostCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumPiecesProduced = CDbl(SumPiecesProducedCommand.ExecuteScalar)
        Catch ex As Exception
            SumPiecesProduced = 0
        End Try
        Try
            SumOverhead = CDbl(SumOverheadCostCommand.ExecuteScalar)
        Catch ex As Exception
            SumOverhead = 0
        End Try
        con.Close()

        If SumPiecesProduced <> 0 Then
            OverHeadCost = SumOverhead / SumPiecesProduced
        Else
            OverHeadCost = 0
        End If

        'cmd = New SqlCommand("SELECT SUM(CASE WHEN TotalPieces <= 0 then 0 else TotalCost / TotalPieces END) as ProductionCostPerPiece FROM (SELECT TimeSlipLineItemTable.FOXStep, CASE WHEN SUM(ExtendedCost) < 0 THEN 0 ELSE SUM(ExtendedCost) END as TotalCost, SUM(TimeSlipLineItemTable.PiecesProduced) as TotalPieces FROM TimeSlipLineItemTable INNER JOIN MachineTable ON TimeSlipLineItemTable.MachineNumber = MachineTable.MachineID INNER JOIN (SELECT FOXNumber, PRocessStep, ProcessADdFG FROM FoxSched WHERE ProcessAddFG = 'ADDINVENTORY') AS FOXSched ON TimeSlipLineItemTable.FOXNumber = FoxSched.FOXNumber WHERE TimeSlipLineItemTable.FOXNumber = @FOXNumber AND LineKey < 100 AND FOXStep <> 999 AND FOXStep <= CASE WHEN (FOXSched.ProcessStep is not null) THEN FOXSched.ProcessStep ELSE 10 END GROUP BY TimeslipLineItemTable.FOXStep) as tmp", con)
        'cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

        'If con.State = ConnectionState.Closed Then con.Open()
        'Dim obj As Object = cmd.ExecuteScalar()
        'con.Close()
        'If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
        '    OverHeadCost = CType(obj, Double)
        'Else
        '    OverHeadCost = 0
        'End If

        OverHeadCost = Math.Round(OverHeadCost, 4)
        '*************************************************************************************
        'Load Other Cost - Pallet, Box
        Dim PalletPiecesStatement As String = "SELECT PalletPieces FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PalletPiecesCommand As New SqlCommand(PalletPiecesStatement, con)
        PalletPiecesCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PalletPiecesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BoxPiecesStatement As String = "SELECT BoxCount FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim BoxPiecesCommand As New SqlCommand(BoxPiecesStatement, con)
        BoxPiecesCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        BoxPiecesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            FOXPalletPieces = CInt(PalletPiecesCommand.ExecuteScalar)
        Catch ex As Exception
            FOXPalletPieces = 0
        End Try
        Try
            FOXBoxCount = CInt(BoxPiecesCommand.ExecuteScalar)
        Catch ex As Exception
            FOXBoxCount = 0
        End Try
        con.Close()

        If FOXPalletPieces <> 0 Then
            FOXPalletCost = PalletCost / FOXPalletPieces
        Else
            FOXPalletCost = 0
        End If

        If FOXBoxCost <> 0 Then
            FOXBoxCost = BoxCost / FOXBoxCount
        Else
            FOXBoxCost = 0
        End If

        ShippingCost = FOXPalletCost + FOXBoxCost
        ShippingCost = Math.Round(ShippingCost, 4)
        '*************************************************************************************
        TotalFOXCost = OverHeadCost + FOXSteelCost + OtherCost + ShippingCost
        TotalFOXCost = Math.Round(TotalFOXCost, 4)

        txtOverheadCost.Text = OverHeadCost
        txtOtherCost.Text = OtherCost
        txtShippingCost.Text = ShippingCost
        txtTotalCost.Text = TotalFOXCost
        txtRawMaterialCost.Text = FOXSteelCost

        OverHeadCost = 0
        OtherCost = 0
        ShippingCost = 0
        TotalFOXCost = 0
        FOXSteelCost = 0
        FOXPalletCost = 0
        FOXBoxCost = 0
        FOXBoxCount = 0
        FOXPalletPieces = 0
    End Sub

    Public Sub LoadMTDProduction()
        MonthDate = Today()
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = MonthDate

        Dim MTDProductionStatement As String = "SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDProductionCommand As New SqlCommand(MTDProductionStatement, con)
        MTDProductionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDProductionCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        MTDProductionCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDProductionCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDProduction = CInt(MTDProductionCommand.ExecuteScalar)
        Catch ex As Exception
            MTDProduction = 0
        End Try
        con.Close()

        lblMTDProduction.Text = MTDProduction
    End Sub

    Public Sub LoadYTDProduction()
        YearDate = Today()
        YearOfYear = YearDate.Year
        strYear = CStr(YearOfYear)
        BeginDate = "01/01/" + strYear
        EndDate = YearDate

        Dim YTDProductionStatement As String = "SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDProductionCommand As New SqlCommand(YTDProductionStatement, con)
        YTDProductionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDProductionCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        YTDProductionCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDProductionCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDProduction = CInt(YTDProductionCommand.ExecuteScalar)
        Catch ex As Exception
            YTDProduction = 0
        End Try
        con.Close()

        lblYTDProduction.Text = YTDProduction
    End Sub

    Public Sub QuantityOnHand()
        'Show Quantity On Hand for specific division
        Dim TWDQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TWDQOHCommand As New SqlCommand(TWDQOHString, con)
        TWDQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TWDQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TWDQuantityOnHand = CDbl(TWDQOHCommand.ExecuteScalar)
        Catch ex As Exception
            TWDQuantityOnHand = 0
        End Try
        con.Close()

        lblQuantityOnHand.Text = FormatNumber(TWDQuantityOnHand, 1)
    End Sub

    Public Sub CommittedQuantity()
        'Show Quantity On Hand for specific division
        Dim TWDCommittedQuantityString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TWDCommittedQuantityCommand As New SqlCommand(TWDCommittedQuantityString, con)
        TWDCommittedQuantityCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TWDCommittedQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TWDCommittedQuantity = CInt(TWDCommittedQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            TWDCommittedQuantity = 0
        End Try
        con.Close()

        lblCommittedQuantity.Text = FormatNumber(TWDCommittedQuantity, 1)
    End Sub

    Public Sub LoadPartData()
        'Extract data from source table
        Dim ShortDescriptionString As String = "SELECT * FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        cmd = New SqlCommand(ShortDescriptionString, con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
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
                PurchProdLineID = ""
            Else
                PurchProdLineID = reader.Item("PurchProdLineID")
            End If
            If IsDBNull(reader.Item("SalesProdLineID")) Then
                SalesProdLineID = ""
            Else
                SalesProdLineID = reader.Item("SalesProdLineID")
            End If
            If IsDBNull(reader.Item("OldPartNumber")) Then
                OldPartNumber = ""
            Else
                OldPartNumber = reader.Item("OldPartNumber")
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
            If IsDBNull(reader.Item("PalletCount")) Then
                PalletCount = 0
            Else
                PalletCount = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("StandardPrice")) Then
                StandardPrice = 0
            Else
                StandardPrice = reader.Item("StandardPrice")
            End If
            If IsDBNull(reader.Item("StandardCost")) Then
                StandardCost = 0
            Else
                StandardCost = reader.Item("StandardCost")
            End If

            If IsDBNull(reader.Item("MaximumStock")) Then
                MaximumStock = 0
            Else
                MaximumStock = reader.Item("MaximumStock")
            End If
            If IsDBNull(reader.Item("MinimumStock")) Then
                MinimumStock = 0
            Else
                MinimumStock = reader.Item("MinimumStock")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                BoxWeight = 0
            Else
                BoxWeight = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("Comments")) Then
                ProductionNote = ""
            Else
                ProductionNote = reader.Item("Comments")
            End If
        Else
            LongDescription = ""
            ItemClass = ""
            PurchProdLineID = ""
            SalesProdLineID = ""
            PieceWeight = 0
            BoxCount = 0
            PalletCount = 0
            StandardPrice = 0
            StandardCost = 0
            OldPartNumber = ""
            MaximumStock = 0
            MinimumStock = 0
            BoxWeight = 0
            ProductionNote = ""
        End If
        reader.Close()
        con.Close()

        Dim RackQuantity As Double = 0

        Dim RackQuantityStatement As String = "SELECT TotalRackPieces FROM RackingWithQOH WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim RackQuantityCommand As New SqlCommand(RackQuantityStatement, con)
        RackQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        RackQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            RackQuantity = CDbl(RackQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            RackQuantity = 0
        End Try
        con.Close()

        lblQtyInRack.Text = RackQuantity

        'Calculate weight and piece totals
        If BoxWeight = 0 Then
            BoxWeight = PieceWeight * BoxCount
            BoxWeight = Math.Round(BoxWeight, 0)
        Else
            'Skip - Box weight is correct from Item List
        End If

        PalletPieces = BoxCount * PalletCount
        PalletWeight = PalletPieces * PieceWeight

        txtBoxCount.Text = Math.Round(BoxCount, 0)
        txtBoxWeight.Text = Math.Round(BoxWeight, 2)
        lblItemClass.Text = ItemClass
        txtProductionNote.Text = ProductionNote
        lblLongDescription.Text = LongDescription
        lblMaximum.Text = FormatNumber(MaximumStock, 0)
        lblMinimum.Text = FormatNumber(MinimumStock, 0)
        lblOldPartNumber.Text = OldPartNumber
        txtPalletCount.Text = Math.Round(PalletCount, 0)
        lblPalletPieces.Text = Math.Round(PalletPieces, 0)
        lblPalletWeight.Text = Math.Round(PalletWeight, 2)
        txtPieceWeight.Text = Math.Round(PieceWeight, 4)
        lblPPL.Text = PurchProdLineID
        lblShortDescription.Text = cboPartDescription.Text
        lblSPL.Text = SalesProdLineID
        lblStandardCost.Text = FormatCurrency(StandardCost, 4)
        lblStandardPrice.Text = FormatCurrency(StandardPrice, 4)
    End Sub

    Public Sub LoadFOXData()
        Dim FOXPieceWeight As Double = 0

        Dim RMIDString As String = "SELECT * FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
        cmd = New SqlCommand(RMIDString, con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim ScheduledRMID As String = ""
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("RMID")) Then
                RMID = ""
            Else
                RMID = reader.Item("RMID")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                BlueprintNumber = ""
            Else
                BlueprintNumber = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("RawMaterialWeight")) Then
                RawMaterialWeight = 0
            Else
                RawMaterialWeight = reader.Item("RawMaterialWeight")
            End If
            If IsDBNull(reader.Item("FinishedWeight")) Then
                FinishedWeight = 0
            Else
                FinishedWeight = reader.Item("FinishedWeight")
            End If
            If IsDBNull(reader.Item("ScrapWeight")) Then
                ScrapWeight = 0
            Else
                ScrapWeight = reader.Item("ScrapWeight")
            End If
            If IsDBNull(reader.Item("FluxLoadNumber")) Then
                FluxLoadNumber = ""
            Else
                FluxLoadNumber = reader.Item("FluxLoadNumber")
            End If
            If IsDBNull(reader.Item("CreationDate")) Then
                CreationDate = ""
            Else
                CreationDate = reader.Item("CreationDate")
            End If
            If IsDBNull(reader.Item("Comments")) Then
                Comments = ""
            Else
                Comments = reader.Item("Comments")
            End If
            If IsDBNull(reader.Item("CertificationType")) Then
                CertificationCode = "0"
            Else
                CertificationCode = reader.Item("CertificationType")
            End If
            If IsDBNull(reader.Item("BoxType")) Then
                BoxType = ""
            Else
                BoxType = reader.Item("BoxType")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                CustomerID = ""
            Else
                CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("ProductionQuantity")) Then
                ProductionQuantity = 0
            Else
                ProductionQuantity = reader.Item("ProductionQuantity")
            End If
            If IsDBNull(reader.Item("PromiseDate")) Then
                PromiseDate = DateTime.Now
            Else
                PromiseDate = reader.Item("PromiseDate")
            End If
            If IsDBNull(reader.Item("OrderReferenceNumber")) Then
                OrderReferenceNumber = 0
            Else
                OrderReferenceNumber = reader.Item("OrderReferenceNumber")
            End If
            If IsDBNull(reader.Item("Status")) Then
                FOXStatus = "ACTIVE"
            Else
                FOXStatus = reader.Item("Status")
            End If
            If IsDBNull(reader.Item("BlueprintRevision")) Then
                BlueprintRevision = ""
            Else
                BlueprintRevision = reader.Item("BlueprintRevision")
            End If
            If IsDBNull(reader.Item("QuoteNumber")) Then
                QuoteNumber = ""
            Else
                QuoteNumber = reader.Item("QuoteNumber")
            End If
            If IsDBNull(reader.Item("QuotePrice")) Then
                QuotedPrice = 0
            Else
                QuotedPrice = reader.Item("QuotePrice")
            End If
            If IsDBNull(reader.Item("ScheduledRMID")) Then
                ScheduledRMID = RMID
            Else
                ScheduledRMID = reader.Item("ScheduledRMID")
            End If
            If IsDBNull(reader.Item("PartNumber2")) Then
                ATLPartNumber = ""
            Else
                ATLPartNumber = reader.Item("PartNumber2")
            End If
            If IsDBNull(reader.Item("PartNumber3")) Then
                CustomerPartNumber = ""
            Else
                CustomerPartNumber = reader.Item("PartNumber3")
            End If
            If IsDBNull(reader.Item("CustomerPO")) Then
                CustomerPONumber = ""
            Else
                CustomerPONumber = reader.Item("CustomerPO")
            End If
        Else
            RMID = ""
            PartNumber = ""
            BlueprintNumber = ""
            RawMaterialWeight = 0
            FinishedWeight = 0
            ScrapWeight = 0
            FluxLoadNumber = ""
            CreationDate = DateTime.Now
            Comments = ""
            CertificationCode = "0"
            BoxType = ""
            CustomerID = ""
            ProductionQuantity = 0
            PromiseDate = DateTime.Now
            OrderReferenceNumber = 0
            FOXStatus = "ACTIVE"
            BlueprintRevision = ""
            QuoteNumber = ""
            QuotedPrice = 0
            ATLPartNumber = ""
            CustomerPartNumber = ""
            CustomerPONumber = ""
        End If
        reader.Close()
        con.Close()

        FOXPieceWeight = FinishedWeight / 1000

        txtRMID.Text = RMID
        txtAlternateRMID.Text = ScheduledRMID
        cboFOXStatus.Text = FOXStatus
        cboPartNumber.Text = PartNumber
        txtBlueprintNumber.Text = BlueprintNumber
        txtRawMaterialWeight.Text = RawMaterialWeight
        txtScrapWeight.Text = ScrapWeight
        txtFinishedWeight.Text = FinishedWeight
        cboFluxLoadNumber.Text = FluxLoadNumber
        dtpCreationDate.Value = CreationDate
        txtFOXComment.Text = Comments
        cboCertCode.Text = CertificationCode
        cboBoxType.Text = BoxType
        If BoxReference.ContainsKey(cboBoxType.Text) Then
            cboBoxType.Text = BoxReference(cboBoxType.Text)
        End If
        cboCustomerID.Text = CustomerID
        txtQuotedQuantity.Text = ProductionQuantity
        dtpFOXPromiseDate.Value = PromiseDate
        txtRevisionLevel.Text = BlueprintRevision
        txtQuotedPrice.Text = QuotedPrice
        txtQuoteNumber.Text = QuoteNumber
        txtSalesOrderNumber.Text = OrderReferenceNumber
        txtPieceWeightFOX.Text = Math.Round(FOXPieceWeight, 5, MidpointRounding.AwayFromZero).ToString()
        txtATLPartNumber.Text = ATLPartNumber
        txtCustomerPartNumber.Text = CustomerPartNumber
        txtCustomerPONumber.Text = CustomerPONumber
    End Sub

    Public Sub LoadSalesOrderData()
        'Variables for Sales Order Data
        Dim ShipVia, ShipToID, CustomerPO, SpecialInstructions, LastShipDate, NextShipDate As String
        Dim ShipDate, OrderDate As DateTime
        Dim FreightAmount, TotalQuantityShipped, TotalQuantityOpen As Double
        Dim ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry As String
        Dim tmp As Object
        '*******************************************************************************
        Dim SpecialInstructionsString As String = "SELECT SpecialInstructions FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SpecialInstructionsCommand As New SqlCommand(SpecialInstructionsString, con)
        SpecialInstructionsCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SpecialInstructionsCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerPOString As String = "SELECT CustomerPO FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim CustomerPOCommand As New SqlCommand(CustomerPOString, con)
        CustomerPOCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        CustomerPOCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipDateString As String = "SELECT ShippingDate FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipDateCommand As New SqlCommand(ShipDateString, con)
        ShipDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim OrderDateString As String = "SELECT SalesOrderDate FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim OrderDateCommand As New SqlCommand(OrderDateString, con)
        OrderDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        OrderDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FreightAmountString As String = "SELECT FreightCharge FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim FreightAmountCommand As New SqlCommand(FreightAmountString, con)
        FreightAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        FreightAmountCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipViaString As String = "SELECT ShipVia FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipViaCommand As New SqlCommand(ShipViaString, con)
        ShipViaCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipViaCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToIDString As String = "SELECT AdditionalShipTo FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToIDCommand As New SqlCommand(ShipToIDString, con)
        ShipToIDCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipToIDCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipMethodString As String = "SELECT ShippingMethod FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipMethodCommand As New SqlCommand(ShipMethodString, con)
        ShipMethodCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipMethodCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ThirdPartyShipperString As String = "SELECT ThirdPartyShipper FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ThirdPartyShipperCommand As New SqlCommand(ThirdPartyShipperString, con)
        ThirdPartyShipperCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ThirdPartyShipperCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToNameString As String = "SELECT ShipToName FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToNameCommand As New SqlCommand(ShipToNameString, con)
        ShipToNameCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipToNameCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToAddress1String As String = "SELECT ShipToAddress1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToAddress1Command As New SqlCommand(ShipToAddress1String, con)
        ShipToAddress1Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipToAddress1Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToAddress2String As String = "SELECT ShipToAddress2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToAddress2Command As New SqlCommand(ShipToAddress2String, con)
        ShipToAddress2Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipToAddress2Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToCityString As String = "SELECT ShipToCity FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToCityCommand As New SqlCommand(ShipToCityString, con)
        ShipToCityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipToCityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToStateString As String = "SELECT ShipToState FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToStateCommand As New SqlCommand(ShipToStateString, con)
        ShipToStateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipToStateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToZipString As String = "SELECT ShipToZip FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToZipCommand As New SqlCommand(ShipToZipString, con)
        ShipToZipCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipToZipCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToCountryString As String = "SELECT ShipToCountry FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToCountryCommand As New SqlCommand(ShipToCountryString, con)
        ShipToCountryCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipToCountryCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SOStatusString As String = "SELECT SOStatus FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOStatusCommand As New SqlCommand(SOStatusString, con)
        SOStatusCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOStatusCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShippingAccountString As String = "SELECT ShippingAccount FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShippingAccountCommand As New SqlCommand(ShippingAccountString, con)
        ShippingAccountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShippingAccountCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipEmailString As String = "SELECT ShipEmail FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipEmailCommand As New SqlCommand(ShipEmailString, con)
        ShipEmailCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShipEmailCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SpecialInstructions = CStr(SpecialInstructionsCommand.ExecuteScalar)
        Catch ex As Exception
            SpecialInstructions = ""
        End Try
        Try
            CustomerPO = CStr(CustomerPOCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerPO = ""
        End Try
        Try
            tmp = ShipDateCommand.ExecuteScalar
            If Not IsDBNull(tmp) AndAlso tmp IsNot Nothing Then
                ShipDate = CType(tmp, DateTime)
            Else
                ShipDate = DateTime.Now
            End If
        Catch ex As Exception
            ShipDate = DateTime.Now
        End Try
        Try
            tmp = OrderDateCommand.ExecuteScalar
            If Not IsDBNull(tmp) AndAlso tmp IsNot Nothing Then
                OrderDate = CType(tmp, DateTime)
            Else
                OrderDate = DateTime.Now
            End If
        Catch ex As Exception
            OrderDate = DateTime.Now
        End Try
        Try
            FreightAmount = CDbl(FreightAmountCommand.ExecuteScalar)
        Catch ex As Exception
            FreightAmount = 0
        End Try
        Try
            ShipVia = CStr(ShipViaCommand.ExecuteScalar)
        Catch ex As Exception
            ShipVia = ""
        End Try
        Try
            ShipToID = CStr(ShipToIDCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToID = ""
        End Try
        Try
            ShipMethod = CStr(ShipMethodCommand.ExecuteScalar)
        Catch ex As Exception
            ShipMethod = ""
        End Try
        Try
            ThirdPartyShipper = CStr(ThirdPartyShipperCommand.ExecuteScalar)
        Catch ex As Exception
            ThirdPartyShipper = ""
        End Try
        Try
            ShipToName = CStr(ShipToNameCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToName = ""
        End Try
        Try
            ShipToAddress1 = CStr(ShipToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress1 = ""
        End Try
        Try
            ShipToAddress2 = CStr(ShipToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress2 = ""
        End Try
        Try
            ShipToCity = CStr(ShipToCityCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCity = ""
        End Try
        Try
            ShipToState = CStr(ShipToStateCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToState = ""
        End Try
        Try
            ShipToZip = CStr(ShipToZipCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToZip = ""
        End Try
        Try
            ShipToCountry = CStr(ShipToCountryCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCountry = ""
        End Try
        Try
            SOStatus = CStr(SOStatusCommand.ExecuteScalar)
        Catch ex As Exception
            SOStatus = ""
        End Try
        Try
            ShippingAccount = CStr(ShippingAccountCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingAccount = ""
        End Try
        Try
            ShipEmail = CStr(ShipEmailCommand.ExecuteScalar)
        Catch ex As Exception
            ShipEmail = ""
        End Try
        con.Close()

        cboShipToID.Text = ShipToID
        cboShipMethod.Text = ShipMethod
        txtSpecialInstructions.Text = SpecialInstructions
        txtCustomerPO.Text = CustomerPO
        dtpShipDate.Value = ShipDate
        dtpOrderDate.Value = OrderDate
        txtFreightCharge.Text = FreightAmount
        cboShipVia.Text = ShipVia
        txtThirdPartyShipper.Text = ThirdPartyShipper
        txtSTAddress1.Text = ShipToAddress1
        txtSTAddress2.Text = ShipToAddress2
        txtSTCity.Text = ShipToCity
        txtSTCountry.Text = ShipToCountry
        cboSTState.Text = ShipToState
        txtSTZip.Text = ShipToZip
        txtSTName.Text = ShipToName
        txtSOStatus.Text = SOStatus
        txtOrderStatus.Text = SOStatus

        If ShippingAccount = "" Then
            'do nothing
        Else
            txtShippingAccount.Text = ShippingAccount
        End If
        If ShipEmail = "" Then
            'do nothing
        Else
            txtShipEmail.Text = ShipEmail
        End If

        If ShipMethod = "THIRD PARTY" Then
            txtThirdPartyShipper.Enabled = True
        Else
            txtThirdPartyShipper.Enabled = False
        End If
        '*******************************************************************************
        Dim QuotedPriceString As String = "SELECT Price FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim QuotedPriceCommand As New SqlCommand(QuotedPriceString, con)
        QuotedPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        QuotedPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim QuotedQuantityString As String = "SELECT Quantity FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim QuotedQuantityCommand As New SqlCommand(QuotedQuantityString, con)
        QuotedQuantityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        QuotedQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesOrderPrice As Double = 0
        Dim SalesOrderQuantity As Double = 0
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SalesOrderPrice = CDbl(QuotedPriceCommand.ExecuteScalar)
        Catch ex As Exception
            SalesOrderPrice = 0
        End Try

        Try
            SalesOrderQuantity = CDbl(QuotedQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            SalesOrderQuantity = 0
        End Try
        con.Close()

        txtUnitPrice.Text = SalesOrderPrice
        'txtQuotedPrice.Text = SalesOrderPrice
        txtQuantityOrdered.Text = SalesOrderQuantity
        'txtQuotedQuantity.Text = SalesOrderQuantity
        '*******************************************************************************
        Dim LastShipDateString As String = "SELECT MAX(ShipDate) FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim LastShipDateCommand As New SqlCommand(LastShipDateString, con)
        LastShipDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        LastShipDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim NextShipDateString As String = "SELECT MIN(ReleaseDate) FROM FOXReleaseSchedule WHERE FOXNumber = @FOXNumber AND Status = @Status"
        Dim NextShipDateCommand As New SqlCommand(NextShipDateString, con)
        NextShipDateCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        NextShipDateCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastShipDate = CStr(LastShipDateCommand.ExecuteScalar)
        Catch ex As Exception
            LastShipDate = "Not shipped"
        End Try
        Try
            NextShipDate = CStr(NextShipDateCommand.ExecuteScalar)
        Catch ex As Exception
            NextShipDate = "No releases scheduled"
        End Try
        con.Close()

        txtLastShipDate.Text = LastShipDate
        txtNextShipDate.Text = NextShipDate
        '*******************************************************************************
        Dim TotalQuantityShippedString As String = "SELECT QuantityShipped FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedString, con)
        TotalQuantityShippedCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        TotalQuantityShippedCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = 1

        Dim ShippedPreviousString As String = "SELECT ShippedPrevious FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim ShippedPreviousCommand As New SqlCommand(ShippedPreviousString, con)
        ShippedPreviousCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        ShippedPreviousCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = 1

        Dim TotalQuantityOpenString As String = "SELECT QuantityOpen FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim TotalQuantityOpenCommand As New SqlCommand(TotalQuantityOpenString, con)
        TotalQuantityOpenCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        TotalQuantityOpenCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = 1

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantityShipped = 0
        End Try
        Try
            ShippedPrevious = CDbl(ShippedPreviousCommand.ExecuteScalar)
        Catch ex As Exception
            ShippedPrevious = 0
        End Try
        Try
            TotalQuantityOpen = CDbl(TotalQuantityOpenCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantityOpen = 0
        End Try
        con.Close()

        TotalQuantityShippedCombined = ShippedPrevious + TotalQuantityShipped
        txtQuantityOpen.Text = TotalQuantityOpen
        txtQuantityShipped.Text = TotalQuantityShippedCombined
        txtQuantityRemaining.Text = TotalQuantityOpen
        txtQuantityShippedToDate.Text = TotalQuantityShippedCombined

        'Load Release Data
        Dim TotalReleaseQuantity As Double = 0
        Dim ReleaseDifference As Double = 0

        Dim TotalReleaseQuantityString As String = "SELECT SUM(ReleaseQuantity) FROM FOXReleaseScheduleQuery WHERE OrderReferenceNumber = @SalesOrderKey AND FOXNumber = @FOXNumber"
        Dim TotalReleaseQuantityCommand As New SqlCommand(TotalReleaseQuantityString, con)
        TotalReleaseQuantityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        TotalReleaseQuantityCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalReleaseQuantity = CDbl(TotalReleaseQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            TotalReleaseQuantity = 0
        End Try
        con.Close()

        ReleaseDifference = SalesOrderQuantity - TotalReleaseQuantity

        txtDifference.Text = ReleaseDifference
        txtQtyOnOrder.Text = SalesOrderQuantity
        txtQtyOnReleases.Text = TotalReleaseQuantity

        'If Sales Order has any shipments, disable Customer Fields
        Dim CountShipments As Integer = 0

        Dim CountShipmentsString As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim CountShipmentsCommand As New SqlCommand(CountShipmentsString, con)
        CountShipmentsCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        CountShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountShipments = CInt(CountShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            CountShipments = 0
        End Try
        con.Close()

        If CountShipments = 0 Then
            cboCustomerID.Enabled = True
            cboCustomerName.Enabled = True
            cboPartNumber.Enabled = True
            cboPartDescription.Enabled = True
        Else
            cboCustomerID.Enabled = False
            cboCustomerName.Enabled = False
            cboPartNumber.Enabled = False
            cboPartDescription.Enabled = False
        End If
    End Sub

    Public Sub LoadRawMaterialData()
        Dim SteelDescriptionString As String = "SELECT Description, SteelSize, Carbon FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = 'TWD' UNION ALL SELECT Description, SteelSize, Carbon FROM RawMaterialsTable WHERE RMID = @RMID2 AND DivisionID = 'TWD'"
        cmd = New SqlCommand(SteelDescriptionString, con)
        cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
        cmd.Parameters.Add("@RMID2", SqlDbType.VarChar).Value = txtAlternateRMID.Text

        Dim ScheduledSteelDesription As String = ""
        Dim ScheduledSteelSize As String = ""
        Dim ScheduledSteelCarbon As String = ""

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Description")) Then
                SteelDescription = ""
            Else
                SteelDescription = reader.Item("Description")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("Carbon")) Then
                SteelCarbon = ""
            Else
                SteelCarbon = reader.Item("Carbon")
            End If
            If reader.Read() Then
                If IsDBNull(reader.Item("Description")) Then
                    ScheduledSteelDesription = ""
                Else
                    ScheduledSteelDesription = reader.Item("Description")
                End If
                If IsDBNull(reader.Item("SteelSize")) Then
                    ScheduledSteelSize = ""
                Else
                    ScheduledSteelSize = reader.Item("SteelSize")
                End If
                If IsDBNull(reader.Item("Carbon")) Then
                    ScheduledSteelCarbon = ""
                Else
                    ScheduledSteelCarbon = reader.Item("Carbon")
                End If
            End If
        Else
            SteelDescription = ""
            SteelSize = ""
            SteelCarbon = ""
        End If
        reader.Close()
        con.Close()

        cboSteelSize.Text = SteelSize
        cboSteelCarbon.Text = SteelCarbon
        txtSteelDescription.Text = SteelDescription

        cboAlternateCarbon.Text = ScheduledSteelCarbon
        cboAlternateSteelSize.Text = ScheduledSteelSize
        txtAlternateDescription.Text = ScheduledSteelDesription

        'Load steel inventory
        Dim SteelQOH As Double = 0
        Dim SteelCommitted As Double = 0
        Dim SteelAvailable As Double = 0

        Dim SteelQOHString As String = "SELECT SteelEndingInventory FROM SteelFOXReportQuery WHERE RMID = @RMID"
        Dim SteelQOHCommand As New SqlCommand(SteelQOHString, con)
        SteelQOHCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text

        Dim SteelCommittedString As String = "SELECT (SteelCommittedToFoxTFP + SteelCommittedToFoxTWD) as SteelCommittedToFOX FROM SteelFOXReportQuery WHERE RMID = @RMID"
        Dim SteelCommittedCommand As New SqlCommand(SteelCommittedString, con)
        SteelCommittedCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text

        cmd = New SqlCommand("SELECT isnull(SUM(QuantityOpen),0) FROM SteelPurchaseQuantityStatus WHERE RMID = @RMID AND DivisionID = 'TWD' AND QuantityOpen > 0 AND Status = 'OPEN'", con)
        cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelQOH = CDbl(SteelQOHCommand.ExecuteScalar)
        Catch ex As Exception
            SteelQOH = 0
        End Try
        Try
            SteelCommitted = CDbl(SteelCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            SteelCommitted = 0
        End Try
        Dim obj As Object = cmd.ExecuteScalar()
        If obj IsNot Nothing Then
            txtOpenSteelPOQuantity.Text = FormatNumber(obj, 0)
        Else
            txtOpenSteelPOQuantity.Text = "0"
        End If
        con.Close()

        SteelAvailable = SteelQOH - SteelCommitted

        txtSteelQOH.Text = SteelQOH
        txtSteelCommitted.Text = SteelCommitted
        txtSteelAvailable.Text = SteelAvailable

        'Load Steel Requirements for this FOX
        Dim SteelRequired As Double = 0
        Dim SteelShipped As Double = 0
        Dim SteelRemaining As Double = 0
        Dim SteelPieceWeightByFOX As Double = 0
        If RawMaterialWeight = 0 Then RawMaterialWeight = Val(txtRawMaterialWeight.Text)

        SteelPieceWeightByFOX = RawMaterialWeight / 1000
        SteelRequired = SteelPieceWeightByFOX * Val(txtQuantityOrdered.Text)
        SteelShipped = SteelPieceWeightByFOX * Val(txtQuantityShipped.Text)
        SteelRemaining = SteelPieceWeightByFOX * Val(txtQuantityOpen.Text)

        SteelRequired = Math.Round(SteelRequired, 1)
        SteelShipped = Math.Round(SteelShipped, 1)
        SteelRemaining = Math.Round(SteelRemaining, 1)

        txtSteelRequired.Text = SteelRequired
        txtSteelShipped.Text = SteelShipped
        txtSteelRemaining.Text = SteelRemaining
    End Sub

    Public Sub LoadMachineDescription()
        Dim MachineDescriptionString As String = "SELECT Description FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = 'TWD'"
        Dim MachineDescriptionCommand As New SqlCommand(MachineDescriptionString, con)
        MachineDescriptionCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboProcessID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MachineDescription = CStr(MachineDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            MachineDescription = ""
        End Try
        con.Close()

        txtMachineDescription.Text = MachineDescription
    End Sub

    Public Sub CheckForValidPartNumber()
        Dim CheckForPartNumber As Integer = 0

        Dim CheckForPartNumberString As String = "SELECT COUNT(ItemID) FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim CheckForPartNumberCommand As New SqlCommand(CheckForPartNumberString, con)
        CheckForPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CheckForPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckForPartNumber = CInt(CheckForPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckForPartNumber = 0
        End Try
        con.Close()
    End Sub

    Public Sub LoadCertData()
        Dim CertificationType As String = ""

        Dim CertTypeString As String = "SELECT CertificationType, Description FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim CertTypeCommand As New SqlCommand(CertTypeString, con)
        CertTypeCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = CertTypeCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CertificationType")) Then
                CertificationType = ""
            Else
                CertificationType = reader.Item("CertificationType")
            End If
            If IsDBNull(reader.Item("Description")) Then
                CertDescription = ""
            Else
                CertDescription = reader.Item("Description")
            End If
        Else
            CertDescription = ""
            CertificationType = ""
        End If
        reader.Close()
        con.Close()

        lblCertDescription.Text = CertDescription
        cboCertType.Text = CertificationType
    End Sub

    Private Sub LoadRMIDAndDescription(Optional ByVal NotScheduled As Boolean = True)
        If NotScheduled Then
            Dim foundRows As Data.DataRow()
            If cboSteelSize.Text.Contains("/") Then
                foundRows = SteelDT.Select("Carbon = '" + cboSteelCarbon.Text + "' AND (SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "')")
            Else
                foundRows = SteelDT.Select("Carbon = '" + cboSteelCarbon.Text + "' AND (SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "')")
            End If
            If foundRows IsNot Nothing AndAlso foundRows.Length > 0 Then
                txtRMID.Text = foundRows(0).Item("RMID")
                txtSteelDescription.Text = foundRows(0).Item("Description")
            End If
        Else
            Dim foundRows As Data.DataRow()
            If cboAlternateSteelSize.Text.Contains("/") Then
                foundRows = SteelDT.Select("Carbon = '" + cboAlternateCarbon.Text + "' AND (SteelSize = '" + cboAlternateSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboAlternateSteelSize.Text) + "')")
            Else
                foundRows = SteelDT.Select("Carbon = '" + cboAlternateCarbon.Text + "' AND (SteelSize = '" + cboAlternateSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboAlternateSteelSize.Text) + "')")
            End If
            If foundRows IsNot Nothing AndAlso foundRows.Length > 0 Then
                txtAlternateRMID.Text = foundRows(0).Item("RMID")
                txtAlternateDescription.Text = foundRows(0).Item("Description")
            End If
        End If
    End Sub

    Private Sub LoadBoxDescription()
        cmd = New SqlCommand("SELECT Description FROM BoxType WHERE BoxTypeID = @BoxTypeID", con)
        cmd.Parameters.Add("@BoxTypeID", SqlDbType.VarChar).Value = cboBoxType.Text
        Dim descr As String = ""

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("Description")) Then
                descr = reader.Item("Description")
            End If
        End If
        reader.Close()
        con.Close()

        txtBoxDescription.Text = descr
    End Sub

    Private Sub LocateRMID(Optional ByVal notScheduled As Boolean = True)
        If notScheduled Then
            Dim foundRows As Data.DataRow()
            If cboSteelSize.Text.Contains("/") Then
                foundRows = SteelDT.Select("Carbon = '" + cboSteelCarbon.Text + "' AND (SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "')")
            Else
                foundRows = SteelDT.Select("Carbon = '" + cboSteelCarbon.Text + "' AND (SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "')")
            End If
            If foundRows IsNot Nothing AndAlso foundRows.Length > 0 Then
                txtRMID.Text = foundRows(0).Item("RMID")
                txtSteelDescription.Text = foundRows(0).Item("Description")
                If cboSteelSize.Text <> foundRows(0).Item("SteelSize") Then cboSteelSize.Text = foundRows(0).Item("SteelSize")
            Else
                txtRMID.Text = ""
                txtSteelDescription.Text = ""
            End If
        Else
            cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAlternateCarbon.Text
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboAlternateSteelSize.Text
            Dim foundRows As Data.DataRow()
            If cboAlternateSteelSize.Text.Contains("/") Then
                foundRows = SteelDT.Select("Carbon = '" + cboAlternateCarbon.Text + "' AND (SteelSize = '" + cboAlternateSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboAlternateSteelSize.Text) + "')")
            Else
                foundRows = SteelDT.Select("Carbon = '" + cboAlternateCarbon.Text + "' AND (SteelSize = '" + cboAlternateSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboAlternateSteelSize.Text) + "')")
            End If
            If foundRows IsNot Nothing AndAlso foundRows.Length > 0 Then
                txtAlternateRMID.Text = foundRows(0).Item("RMID")
                txtAlternateDescription.Text = foundRows(0).Item("Description")
                If cboAlternateSteelSize.Text <> foundRows(0).Item("SteelSize") Then cboAlternateSteelSize.Text = foundRows(0).Item("SteelSize")
            Else
                txtAlternateRMID.Text = ""
                txtAlternateDescription.Text = ""
            End If
        End If
    End Sub

    Public Sub ValidateShippingMethod()
        ShipMethod = cboShipMethod.Text

        Select Case ShipMethod
            Case "COLLECT"
                CheckShippingMethod = ""
            Case "PREPAID"
                CheckShippingMethod = ""
            Case "PREPAID/ADD"
                CheckShippingMethod = ""
            Case "THIRD PARTY"
                If txtThirdPartyShipper.Text = "" Then
                    MsgBox("You must fill-in third party shipping info", MsgBoxStyle.OkOnly)
                    CheckShippingMethod = "EXIT SUB"
                    txtThirdPartyShipper.Focus()
                    Exit Sub
                End If
            Case "OTHER"
                CheckShippingMethod = ""
            Case Else
                MsgBox("You must select a valid Shipping Method", MsgBoxStyle.OkOnly)
                CheckShippingMethod = "EXIT SUB"
                cboShipMethod.Focus()
                Exit Sub
        End Select
    End Sub

    Public Sub GetThirdPartyBillingData()
        Dim BillToNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToNameCommand As New SqlCommand(BillToNameStatement, con)
        BillToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
        BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
        BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
        BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
        BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
        BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BillToName = CStr(BillToNameCommand.ExecuteScalar)
        Catch ex As Exception
            BillToName = ""
        End Try
        Try
            BillToAddress1 = CStr(BillToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            BillToAddress1 = ""
        End Try
        Try
            BillToAddress2 = CStr(BillToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            BillToAddress2 = ""
        End Try
        Try
            BillToCity = CStr(BillToCityCommand.ExecuteScalar)
        Catch ex As Exception
            BillToCity = ""
        End Try
        Try
            BillToState = CStr(BillToStateCommand.ExecuteScalar)
        Catch ex As Exception
            BillToState = ""
        End Try
        Try
            BillToZip = CStr(BillToZipCommand.ExecuteScalar)
        Catch ex As Exception
            BillToZip = ""
        End Try
        con.Close()

        txtThirdPartyShipper.Text = BillToName + Environment.NewLine + BillToAddress1 + Environment.NewLine + BillToAddress2 + Environment.NewLine + BillToCity + ", " + BillToState + "  " + BillToZip
    End Sub

    Public Sub TrackChangesInSteel()
        'Get Old RMID saved in FOX
        Dim CheckOldPreferredRMIDStatement As String = "SELECT RMID FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
        Dim CheckOldPreferredRMIDCommand As New SqlCommand(CheckOldPreferredRMIDStatement, con)
        CheckOldPreferredRMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        CheckOldPreferredRMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckOldAlternateRMIDStatement As String = "SELECT RMID FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
        Dim CheckOldAlternateRMIDCommand As New SqlCommand(CheckOldAlternateRMIDStatement, con)
        CheckOldAlternateRMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        CheckOldAlternateRMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckOldPreferredRMID = CStr(CheckOldPreferredRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckOldPreferredRMID = ""
        End Try
        Try
            CheckOldAlternateRMID = CStr(CheckOldAlternateRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckOldAlternateRMID = ""
        End Try
        con.Close()

        'Compare it to new RMID        
        'If different, Log Change

        If CheckOldAlternateRMID <> txtAlternateRMID.Text Then
            Try
                AuditComment = "FOX Alternate steel changed from " + CheckOldAlternateRMID + " to " + txtAlternateRMID.Text

                'Write to audit table
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "FOX Maintenance - Steel Change"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = "FOX # - " + cboFOXNumber.Text
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        Else
            'Do nothing
        End If
        If CheckOldPreferredRMID <> txtRMID.Text Then
            'Write to audit table
            Try
                AuditComment = "FOX Preferred steel changed from " + CheckOldPreferredRMID + " to " + txtRMID.Text

                'Write to audit table
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "FOX Maintenance - Steel Change"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = "FOX # - " + cboFOXNumber.Text
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        Else
            'Do nothing
        End If
    End Sub

    Public Sub LoadWIPDataForAdjustments()
        Dim GetProcessStepOne As String = ""
        Dim GetProcessStepFG As String = ""
        Dim GetNumberOfBlanks As Integer = 0

        Dim GetProcessStepOneStatement As String = "SELECT ProcessID FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep"
        Dim GetProcessStepOneCommand As New SqlCommand(GetProcessStepOneStatement, con)
        GetProcessStepOneCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        GetProcessStepOneCommand.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = 1

        Dim GetProcessStepFGStatement As String = "SELECT ProcessID FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = @ProcessAddFG"
        Dim GetProcessStepFGCommand As New SqlCommand(GetProcessStepFGStatement, con)
        GetProcessStepFGCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        GetProcessStepFGCommand.Parameters.Add("@ProcessAddFG", SqlDbType.VarChar).Value = "ADDINVENTORY"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetProcessStepOne = CStr(GetProcessStepOneCommand.ExecuteScalar)
        Catch ex As Exception
            GetProcessStepOne = ""
        End Try
        Try
            GetProcessStepFG = CStr(GetProcessStepFGCommand.ExecuteScalar)
        Catch ex As Exception
            GetProcessStepFG = ""
        End Try
        con.Close()

        txtWIPFinishedGoodsStep.Text = GetProcessStepFG
        txtWIPProcessStep.Text = GetProcessStepOne

        'New Way of Calculating Blanks
        Dim GetFinishedGoodStep As Integer = 0
        Dim GetHeadingStep As Integer = 0
        Dim GetMAXProductionNumber As Integer = 0
        Dim GetHeadingQuantity As Double = 0
        Dim GetFinishedGoodsQuantity As Double = 0
        Dim GetTotalBlanks As Double = 0

        Dim GetFinishedStepString As String = "SELECT ProcessStep FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = @ProcessAddFG"
        Dim GetFinishedStepCommand As New SqlCommand(GetFinishedStepString, con)
        GetFinishedStepCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        GetFinishedStepCommand.Parameters.Add("@ProcessAddFG", SqlDbType.VarChar).Value = "ADDINVENTORY"

        Dim GetHeadingStepString As String = "SELECT MIN(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG <> @ProcessAddFG AND ProcessStep <> 0"
        Dim GetHeadingStepCommand As New SqlCommand(GetHeadingStepString, con)
        GetHeadingStepCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        GetHeadingStepCommand.Parameters.Add("@ProcessAddFG", SqlDbType.VarChar).Value = "ADDINVENTORY"

        Dim GetMAXProductionNumberString As String = "SELECT MAX(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber"
        Dim GetMAXProductionNumberCommand As New SqlCommand(GetMAXProductionNumberString, con)
        GetMAXProductionNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetFinishedGoodStep = CInt(GetFinishedStepCommand.ExecuteScalar)
        Catch ex As Exception
            GetFinishedGoodStep = 0
        End Try
        Try
            GetHeadingStep = CInt(GetHeadingStepCommand.ExecuteScalar)
        Catch ex As Exception
            GetHeadingStep = 1
        End Try
        Try
            GetMAXProductionNumber = CInt(GetMAXProductionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetMAXProductionNumber = 0
        End Try
        con.Close()

        'Get Summation of Headed Goods minus Finished Goods
        Dim GetHeadedQuantityString As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND FOXStep = @FOXStep AND ProductionStatus <> 'CLOSED'"
        Dim GetHeadedQuantityCommand As New SqlCommand(GetHeadedQuantityString, con)
        GetHeadedQuantityCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        GetHeadedQuantityCommand.Parameters.Add("@ProductionNumber", SqlDbType.VarChar).Value = GetMAXProductionNumber
        GetHeadedQuantityCommand.Parameters.Add("@FOXStep", SqlDbType.VarChar).Value = GetHeadingStep

        Dim GetFinishedQuantityString As String = "SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND FOXStep = @FOXStep AND ProductionStatus <> 'CLOSED'"
        Dim GetFinishedQuantityCommand As New SqlCommand(GetFinishedQuantityString, con)
        GetFinishedQuantityCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        GetFinishedQuantityCommand.Parameters.Add("@ProductionNumber", SqlDbType.VarChar).Value = GetMAXProductionNumber
        GetFinishedQuantityCommand.Parameters.Add("@FOXStep", SqlDbType.VarChar).Value = GetFinishedGoodStep

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetHeadingQuantity = CDbl(GetHeadedQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            GetHeadingQuantity = 0
        End Try
        Try
            GetFinishedGoodsQuantity = CDbl(GetFinishedQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            GetFinishedGoodsQuantity = 0
        End Try
        con.Close()

        GetTotalBlanks = GetHeadingQuantity - GetFinishedGoodsQuantity

        txtWIPBlanksInWIP.Text = GetTotalBlanks
    End Sub

    'Validation

    Public Sub ValidateSteelInFOX()
        Dim CheckScheduledRMID, CheckAlternateRMID As Integer

        Dim CheckScheduledRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = @DivisionID AND SteelStatus <> 'CLOSED'"
        Dim CheckScheduledRMIDCommand As New SqlCommand(CheckScheduledRMIDStatement, con)
        CheckScheduledRMIDCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
        CheckScheduledRMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        Dim CheckAlternateRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = @DivisionID AND SteelStatus <> 'CLOSED'"
        Dim CheckAlternateRMIDCommand As New SqlCommand(CheckAlternateRMIDStatement, con)
        CheckAlternateRMIDCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtAlternateRMID.Text
        CheckAlternateRMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckScheduledRMID = CInt(CheckScheduledRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckScheduledRMID = 0
        End Try
        Try
            CheckAlternateRMID = CInt(CheckAlternateRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckAlternateRMID = 0
        End Try
        con.Close()

        If CheckAlternateRMID = 0 Or CheckScheduledRMID = 0 Then
            IsSteelTypeValid = "INVALID STEEL"
        Else
            IsSteelTypeValid = "VALID STEEL"
        End If

        If (cboAlternateCarbon.Text = "" And cboAlternateSteelSize.Text = "") Or (cboSteelCarbon.Text = "" And cboSteelSize.Text = "") Then
            IsSteelTypeValid = "VALID STEEL"
        End If
    End Sub

    Private Function canGetProcessStep() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must select a FOX", "Select a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must select a FOX", "Select a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            ShowHeatNumbers()
            ShowProcesses()
            ShowReleases()
            LoadFOXData()
            isLoaded = False
            LoadRawMaterialData()
            isLoaded = True
            Return False
        End If
        If String.IsNullOrEmpty(cboPartNumber.Text) = False Then
            If cboPartNumber.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Part Number", "Enter a valid Part Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboPartNumber.SelectAll()
                cboPartNumber.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(cboBoxType.Text) = False Then
            If cboBoxType.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Box Type", "Enter a valid Box Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboBoxType.SelectAll()
                cboBoxType.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(cboCertCode.Text) = False Then
            If cboCertCode.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Certification Code", "Enter a Certification Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboCertCode.SelectAll()
                cboCertCode.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(cboSteelCarbon.Text) = False Then
            If cboSteelCarbon.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Carbon", "Enter a valid Carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tabItemProcess.SelectedIndex = 5
                cboSteelCarbon.SelectAll()
                cboSteelCarbon.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(cboSteelSize.Text) = False Then
            If cboSteelSize.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Steel Size", "Enter a valid Steel Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tabItemProcess.SelectedIndex = 5
                cboSteelSize.SelectAll()
                cboSteelSize.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(cboSteelCarbon.Text) = False And String.IsNullOrEmpty(cboSteelSize.Text) = False Then
            cmd = New SqlCommand("SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize", con)
            cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar() = 0 Then
                con.Close()
                MessageBox.Show("Carbon and Steel Size do not match any known combinations. Add the combination to Raw Materials", "Unknown combination", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tabItemProcess.SelectedIndex = 5
                cboSteelCarbon.SelectAll()
                cboSteelCarbon.Focus()
                Return False
            End If
            con.Close()
        End If
        If String.IsNullOrEmpty(cboFOXStatus.Text) Then
            cboFOXStatus.Text = "ACTIVE"
        Else
            If Not cboFOXStatus.Text.Equals("ACTIVE") And Not cboFOXStatus.Text.Equals("INACTIVE") Then
                MessageBox.Show("You must enter a valid status.", "Enter a valid status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboFOXStatus.SelectAll()
                cboFOXStatus.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtRawMaterialWeight.Text) AndAlso Val(txtRawMaterialWeight.Text) <> 0 AndAlso Val(txtRawMaterialWeight.Text) < 5 Then
            MessageBox.Show("Raw material weight per 1000 must be greater than 5 pounds.", "Invalid raw material weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tabItemProcess.SelectedIndex = 5
            txtRawMaterialWeight.SelectAll()
            txtRawMaterialWeight.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(txtFinishedWeight.Text) AndAlso Val(txtFinishedWeight.Text) <> 0 AndAlso Val(txtFinishedWeight.Text) < 5 Then
            MessageBox.Show("Finished weight per 1000 must be greater than 5 pounds.", "Invalid finished weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tabItemProcess.SelectedIndex = 5
            txtRawMaterialWeight.SelectAll()
            txtRawMaterialWeight.Focus()
            Return False
        End If
        'If String.IsNullOrEmpty(txtRawMaterialWeight.Text) = False Then
        '    If IsNumeric(txtRawMaterialWeight.Text) = False Then
        '        MessageBox.Show("You must enter a number for Raw Material Weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        tabItemProcess.SelectedIndex = 5
        '        txtRawMaterialWeight.SelectAll()
        '        txtRawMaterialWeight.Focus()
        '        Return False
        '    End If
        '    If Val(txtRawMaterialWeight.Text) <= 0 Then
        '        MessageBox.Show("You must enter a value larger than 0 for Raw Material Weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        tabItemProcess.SelectedIndex = 5
        '        txtRawMaterialWeight.SelectAll()
        '        txtRawMaterialWeight.Focus()
        '        Return False
        '    End If
        'End If
        ' ''will fill Scrap Weight with 0 if nothing is entered
        'If String.IsNullOrEmpty(txtScrapWeight.Text) Then
        '    txtScrapWeight.Text = 0
        'End If
        'If String.IsNullOrEmpty(txtFinishedWeight.Text) = False Then
        '    If IsNumeric(txtFinishedWeight.Text) = False Then
        '        MessageBox.Show("You must enter a number for Finished Weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        tabItemProcess.SelectedIndex = 5
        '        txtFinishedWeight.SelectAll()
        '        txtFinishedWeight.Focus()
        '        Return False
        '    End If
        '    If Val(txtFinishedWeight.Text) <= 0 Then
        '        MessageBox.Show("You must enter a value greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        tabItemProcess.SelectedIndex = 5
        '        txtFinishedWeight.SelectAll()
        '        txtFinishedWeight.Focus()
        '        Return False
        '    End If
        'End If
        Return True
    End Function

    Private Function canDeleteFOX() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must select a FOX", "Select a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid FOX Number to Delete", "Enter a valid FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            ShowHeatNumbers()
            ShowProcesses()
            ShowReleases()
            LoadFOXData()
            isLoaded = False
            LoadRawMaterialData()
            isLoaded = True
            Return False
        End If
        ''check ot see if the sales order associated foir TFP is still open for the given part.
        If cboDivisionID.Text.Equals("TFP") Then
            If txtSalesOrderNumber.Text <> "0" Then
                cmd = New SqlCommand("SELECT Count(SalesOrderLineKey) FROM  SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND ItemID = @ItemID AND LineStatus = 'OPEN'", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.Int).Value = Val(txtSalesOrderNumber.Text)
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                If cmd.ExecuteScalar() > 0 Then
                    con.Close()
                    MessageBox.Show("Unable ot delete FOX. The sales order associated has active lines.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End If
        End If

        cmd = New SqlCommand("SELECT COUNT(TimeSlipKey) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
        ''check to see if there are any timeslip entries for the FOX
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            MessageBox.Show("You can't delete a FOX that has time slip postings. If you are done with the FOX, change the status to INACTIVE.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        con.Close()
        'Prompt before deleting
        If MessageBox.Show("Do you wish to delete this FOX?", "DELETE FOX", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Function canAddStep() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must select a FOX", "Select a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            ShowHeatNumbers()
            ShowProcesses()
            ShowReleases()
            LoadFOXData()
            isLoaded = False
            LoadRawMaterialData()
            isLoaded = True
            Return False
        End If
        If String.IsNullOrEmpty(txtProcessStep.Text) Then
            MessageBox.Show("You must enter a Process Step Number", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProcessStep.Focus()
            Return False
        End If
        If Val(txtProcessStep.Text) = 0 Or Val(txtProcessStep.Text) > dgvFoxProcesses.Rows.Count + 1 Then
            MessageBox.Show("Process step must be greater than 0 and less than 1 more than the current last process step.", "Unable ot add process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProcessStep.SelectAll()
            txtProcessStep.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboProcessID.Text) Then
            MessageBox.Show("You must enter a Process ID", "Enter a Process ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProcessID.Focus()
            Return False
        End If
        If cboProcessID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Process ID", "Enter a valid Process ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProcessID.SelectAll()
            cboProcessID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canSaveProcessChanges() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX number", "Select a FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid FOX Number", "Enter a valid FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If dgvFoxProcesses.Rows.Count = 0 Then
            MessageBox.Show("There are no processes to save.", "Enter a process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProcessStep.Focus()
            Return False
        End If
        For i As Integer = 0 To dgvFoxProcesses.RowCount - 1
            ''check to make sure the value entered is valid for machine ID
            If Not machineIDCheck.Contains(dgvFoxProcesses.Rows(i).Cells("ProcessIDColumn").Value.ToString()) Then
                If Not machineIDCheck.Contains(dgvFoxProcesses.Rows(i).Cells("ProcessIDColumn").Value.ToString().ToUpper()) Then
                    MessageBox.Show("Process ID " + dgvFoxProcesses.Rows(i).Cells("ProcessIDColumn").Value.ToString() + " for step #" + dgvFoxProcesses.Rows(i).Cells("ProcessStepColumn").Value.ToString() + " is not a valid Process ID. Check the Process ID and try again", "Invalid Process ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dgvFoxProcesses.Focus()
                    dgvFoxProcesses.CurrentCell = dgvFoxProcesses.Rows(i).Cells("ProcessIDColumn")
                    Return False
                Else
                    dgvFoxProcesses.Rows(i).Cells("ProcessIDColumn").Value = dgvFoxProcesses.Rows(i).Cells("ProcessIDColumn").Value.ToString.ToUpper
                End If

            End If
        Next
        Return True
    End Function

    Private Function canDeleteProcess()
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX Number", "Enter a FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If dgvFoxProcesses.CurrentCell Is Nothing Then
            MessageBox.Show("You must select a Process Step to Delete", "Select a Process Step", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dgvFoxProcesses.Focus()
            Return False
        End If
        If dgvFoxProcesses.CurrentCell.RowIndex = -1 Then
            MessageBox.Show("You must select a valid Process Step", "Select a valid Process Step", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dgvFoxProcesses.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            ShowHeatNumbers()
            ShowProcesses()
            ShowReleases()
            LoadFOXData()
            isLoaded = False
            LoadRawMaterialData()
            isLoaded = True
            Return False
        End If
        'EmployeeSecurityCode > 1002 Or 
        ''Checking to make sure its a valid production number and if it is counting how many lines have been posted to time slips for the given fox, process Step and production number
        cmd = New SqlCommand("IF (@ProductionNumber <> 0) SELECT Count(TimeSlipKey) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND FOXStep >= @FOXStep ELSE SELECT 0;", con)

        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
        cmd.Parameters.Add("@FOXStep", SqlDbType.Int).Value = Val(dgvFoxProcesses.Rows(dgvFoxProcesses.CurrentCell.RowIndex).Cells("ProcessStepColumn").Value)
        cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            If EmployeeLoginName <> "SBALLIET" And EmployeeLoginName <> "SRAY" And EmployeeLoginName <> "TWHITE" And EmployeeLoginName <> "JSCHULTZ" And EmployeeSecurityCode <> 1001 And EmployeeSecurityCode <> 1002 Then
                MessageBox.Show("There has been production ran on the step or steps after the one you are trying to delete.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf MessageBox.Show("Removing this step may cause issues with time slip line entries. Do you wish to continue?", "Continue", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        ElseIf MessageBox.Show("Do you wish to delete the process step?", "DELETE DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

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

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division)", con)
        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function canDeleteRelease() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must select a FOX number", "Select a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            ShowHeatNumbers()
            ShowProcesses()
            ShowReleases()
            LoadFOXData()
            isLoaded = False
            LoadRawMaterialData()
            isLoaded = True
            Return False
        End If
        Return True
    End Function

    Private Function canReorderProcesses() As Boolean
        If isSomeoneEditing() Then
            ShowHeatNumbers()
            ShowProcesses()
            ShowReleases()
            LoadFOXData()
            isLoaded = False
            LoadRawMaterialData()
            isLoaded = True
            Return False
        End If
        ''Checking to make sure its a valid production number and if it is counting how many lines have been posted to time slips for the given fox, process Step and production number
        cmd = New SqlCommand("IF (@ProductionNumber <> 0) SELECT Count(TimeSlipKey) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber ELSE SELECT 0;", con)

        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
        cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            If EmployeeSecurityCode > 1002 Then
                MessageBox.Show("There has been production ran on the step or steps after the one you are trying to delete.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf MessageBox.Show("Removing this step may cause issues with time slip line entries. Do you wish to continue?", "Continue", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        End If
        If con.State = ConnectionState.Open Then con.Close()
        Return True
    End Function

    Private Function canReissue() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX Number", "Enter a FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid FOX Number", "Enter a valid FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to Re-Issue this FOX?", "RE-ISSUE FOX", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Function canCreateSO() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX Number", "Enter a FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid FOX Number", "Enter a valid FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MessageBox.Show("You must enter a Customer ID", "Enter a Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Customer ID", "Enter a valid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboPartNumber.Text) Then
            MessageBox.Show("You must select a Part Number", "Select a PartNumber", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.Focus()
            Return False
        End If
        If cboPartNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Part Number", "Enter a valid Part Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.SelectAll()
            cboPartNumber.Focus()
            Return False
        End If
        If Not IsNumeric(txtQuotedPrice.Text) Then
            MessageBox.Show("You must enter a number for Price in Quoted Price", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuotedPrice.SelectAll()
            txtQuotedPrice.Focus()
            Return False
        End If
        If Not IsNumeric(txtQuotedQuantity.Text) Then
            MessageBox.Show("You must enter a number for Quantity in Quote Quantity", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuotedQuantity.SelectAll()
            txtQuotedQuantity.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function CanCloseSO() As Boolean
        cmd = New SqlCommand("SELECT isnull(COUNT(ShipmentNumber), 0) FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = 'TFP' AND ShipmentStatus = 'PENDING'", con)
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.Int).Value = Val(txtSalesOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            MessageBox.Show("Unable to CLOSE the sales order, there are shipments pending.", "Unable to close sales order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        cmd.CommandText = "SELECT isnull(Count(SalesOrderKey), 0) FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = 'TFP' AND SOStatus = 'OPEN'"

        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            Return False
        End If
        con.Close()
        Return True
    End Function

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("Locked")) Then
                personEditing = reader.Item("Locked")
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this FOX. You are unable to make any changes.", "Unable to make changes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE FOXTable SET Locked = @Locked WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE FOXTable SET Locked = '' WHERE FOXNumber = @FOXNumber AND Locked = @Locked", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
        Else
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function CanStartNewProduction() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX", "Enter a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid FOX", "Enter a valid FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If cboDivisionID.Text.Equals("TFP") Then
            MessageBox.Show("Can't start new production on a TFP FOX.", "Unable to start new Production", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not cboFOXStatus.Text.Equals("ACTIVE") Then
            MessageBox.Show("Unable to start a new production run on a non-active FOX", "Unable to start new production run", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Val(txtProductionNumber.Text) = 0 Then
            If MessageBox.Show("Are you sure you wish to start a new production run?", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        Else
            If MessageBox.Show("Are you sure you wish to start a new production run? No further additions will be done to the current production.", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        End If
        cmd = New SqlCommand("SELECT COUNT(ProcessID) FROM FOXSched WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            MessageBox.Show("You can't create a new production on a FOX with no steps.", "Unable to create new Produciton Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Function canUpdateProdQty() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX Number", "Enter a FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid FOX Number", "Enter a valid FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtProductionNumber.Text) Then
            MessageBox.Show("There is no Production Number. You must start a new Production.", "unable to update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Function canAddCertification() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX number", "Enter a FOXNumber", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid FOX Number", "Select a valid FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboFOXCertifications.Text) Then
            MessageBox.Show("You must enter a Certification", "Enter a Certification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXCertifications.Focus()
            Return False
        End If
        If cboFOXCertifications.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid Certification", "Select a valid Certification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXCertifications.SelectAll()
            cboFOXCertifications.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub clearOutsideOperations()
        txtOutsideOperation.Clear()
        txtOutsideVendorID.Clear()
        txtRouting.Clear()
        txtTurnAround.Clear()

        Me.dgvFOXOutsideData.DataSource = Nothing
    End Sub

    Private Function canAddOutside() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX Number", "Enter a FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid FOX Number", "Enter a valid FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtOutsideVendorID.Text) Then
            MessageBox.Show("You must enter a Vendor", "Enter a vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOutsideVendorID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtOutsideOperation.Text) Then
            MessageBox.Show("You must enter an Operation", "Enter an Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOutsideOperation.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTurnAround.Text) Then
            MessageBox.Show("You must enter a turn around time", "Enter turn around", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTurnAround.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtRouting.Text) Then
            MessageBox.Show("You must enter a process step", "Enter a process step", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRouting.Focus()
            Return False
        End If
        If Val(txtRouting.Text) > dgvFoxProcesses.Rows.Count Or Val(txtRouting.Text) = 0 Then
            MessageBox.Show("You must enter a valid process step", "Enter a valid step", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRouting.SelectAll()
            txtRouting.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canDeleteOutside() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX Number", "Enter a FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If dgvFOXOutsideData.Rows.Count = 0 Then
            MessageBox.Show("There is nothing to delete", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvFOXOutsideData.CurrentCell Is Nothing Then
            MessageBox.Show("You must select an Operation to delete", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

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

    'Blueprint Events

    Private Sub CheckBPJournal()
        Dim CountBPJournalEntries As Integer = 0

        Dim CountBPJournalEntriesStatement As String = "SELECT COUNT(BlueprintNumber) FROM BlueprintJournal WHERE BlueprintNumber = @BlueprintNumber"
        Dim CountBPJournalEntriesCommand As New SqlCommand(CountBPJournalEntriesStatement, con)
        CountBPJournalEntriesCommand.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountBPJournalEntries = CInt(CountBPJournalEntriesCommand.ExecuteScalar)
        Catch ex As Exception
            CountBPJournalEntries = 0
        End Try
        con.Close()

        If CountBPJournalEntries = 0 Then
            cmdViewEntries.Enabled = False
            lblBPMessage.Text = "No entries found."
        Else
            cmdViewEntries.Enabled = True
            lblBPMessage.Text = "Blueprint journal entries found."
        End If

    End Sub

    Private Sub cmdViewEntries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewEntries.Click
        Using NewBlueprintJournal As New BlueprintJournal(txtBlueprintNumber.Text)
            Dim Result = NewBlueprintJournal.ShowDialog
        End Using
    End Sub

    Private Sub chkFGPrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFGPrint.CheckedChanged
        If chkFGPrint.Checked = True Then
            chkHeadingPrint.Checked = False
            chkToolingPrint.Checked = False
            chkTWEAccessories.Checked = False
            chkMachiningPrint.Checked = False
        End If
    End Sub

    Private Sub chkHeadingPrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeadingPrint.CheckedChanged
        If chkHeadingPrint.Checked = True Then
            chkFGPrint.Checked = False
            chkToolingPrint.Checked = False
            chkTWEAccessories.Checked = False
            chkMachiningPrint.Checked = False
        End If
    End Sub

    Private Sub chkToolingPrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkToolingPrint.CheckedChanged
        If chkToolingPrint.Checked = True Then
            chkFGPrint.Checked = False
            chkHeadingPrint.Checked = False
            chkTWEAccessories.Checked = False
            chkMachiningPrint.Checked = False
        End If
    End Sub

    Private Sub chkTWEAccessories_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTWEAccessories.CheckedChanged
        If chkTWEAccessories.Checked = True Then
            chkFGPrint.Checked = False
            chkToolingPrint.Checked = False
            chkHeadingPrint.Checked = False
            chkMachiningPrint.Checked = False
        End If
    End Sub

    Private Sub chkMachiningPrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMachiningPrint.CheckedChanged
        If chkMachiningPrint.Checked = True Then
            chkFGPrint.Checked = False
            chkToolingPrint.Checked = False
            chkHeadingPrint.Checked = False
            chkTWEAccessories.Checked = False
        End If
    End Sub

    Private Sub cmdGetBlueprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetBlueprint.Click

        'If chkFGPrint.Checked = True Then
        '    Dim BlueprintFilename As String = ""
        '    Dim BlueprintFilePath As String = ""

        '    BlueprintFilename = "F" + txtBlueprintNumber.Text + ".pdf"
        '    BlueprintFilePath = "\\TFP-FS\TransferData\BluePrint\FinishedPart\" + BlueprintFilename

        '    If File.Exists(BlueprintFilePath) Then
        '        Me.wbBlueprintViewer.Navigate(BlueprintFilePath)
        '    Else
        '        Me.wbBlueprintViewer.Navigate(BlueprintFailurePath)
        '    End If
        'ElseIf chkHeadingPrint.Checked = True Then
        '    Dim BlueprintFilename As String = ""
        '    Dim BlueprintFilePath As String = ""

        '    BlueprintFilename = "H" + txtBlueprintNumber.Text + ".pdf"
        '    BlueprintFilePath = "\\TFP-FS\TransferData\BluePrint\Header\" + BlueprintFilename

        '    If File.Exists(BlueprintFilePath) Then
        '        Me.wbBlueprintViewer.Navigate(BlueprintFilePath)
        '    Else
        '        Me.wbBlueprintViewer.Navigate(BlueprintFailurePath)
        '    End If
        'ElseIf chkToolingPrint.Checked = True Then

        '    Dim BlueprintFilename As String = ""
        '    Dim BlueprintFilePath As String = ""

        '    BlueprintFilename = "M" + txtBlueprintNumber.Text + ".pdf"
        '    BlueprintFilePath = "\\TFP-FS\TransferData\BluePrint\Machining\" + BlueprintFilename

        '    If File.Exists(BlueprintFilePath) Then
        '        Me.wbBlueprintViewer.Navigate(BlueprintFilePath)
        '    Else
        '        Me.wbBlueprintViewer.Navigate(BlueprintFailurePath)
        '    End If
        'ElseIf chkTWEAccessories.Checked = True Then

        '    Dim BlueprintFilename As String = ""
        '    Dim BlueprintFilePath As String = ""

        '    BlueprintFilename = txtBlueprintNumber.Text + ".pdf"
        '    BlueprintFilePath = "\\TFP-FS\TransferData\BluePrint\TWE Accessories\" + BlueprintFilename

        '    If File.Exists(BlueprintFilePath) Then
        '        Me.wbBlueprintViewer.Navigate(BlueprintFilePath)
        '    Else
        '        Me.wbBlueprintViewer.Navigate(BlueprintFailurePath)
        '    End If
        'Else
        '    Me.wbBlueprintViewer.Navigate(BlueprintFailurePath)
        'End If

        Dim PrintType As String = ""
        Dim BlueprintFilename As String = ""
        Dim BlueprintFilenameAndPath As String = ""
        Dim BlueprintNumber As String = ""

        If chkFGPrint.Checked = True Then
            PrintType = "FINISHED"
        ElseIf chkHeadingPrint.Checked = True Then
            PrintType = "HEADING"
        ElseIf chkMachiningPrint.Checked = True Then
            PrintType = "MACHINING"
        ElseIf chkToolingPrint.Checked = True Then
            PrintType = "TOOLING"
        ElseIf chkTWEAccessories.Checked = True Then
            PrintType = "TWE"
        ElseIf chkHeatTreatPrints.Checked = True Then
            PrintType = "HEAT TREAT"
        Else
            PrintType = ""
        End If

        If PrintType = "" Or txtBlueprintNumber.Text = "" Then
            MsgBox("Select a valid B/P # and print type.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Load Blueprint
        BlueprintNumber = txtBlueprintNumber.Text

        Select Case PrintType
            Case "FINISHED"
                BlueprintFilename = "F" + BlueprintNumber + ".pdf"
                BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\FinishedPart\" + BlueprintFilename
            Case "HEADING"
                BlueprintFilename = "H" + BlueprintNumber + ".pdf"
                BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\Header\" + BlueprintFilename
            Case "MACHINING"
                BlueprintFilename = "M" + BlueprintNumber + ".pdf"
                BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\Machining\" + BlueprintFilename
            Case "TOOLING"
                BlueprintFilename = "BP" + BlueprintNumber + ".pdf"
                BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\ToolLayout\" + BlueprintFilename
            Case "TWE"
                BlueprintFilename = BlueprintNumber + ".pdf"
                BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\TWE Accessories\" + BlueprintFilename
            Case "HEAT TREAT"
                BlueprintFilename = "HT" + BlueprintNumber + ".pdf"
                BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\Heat Treat\" + BlueprintFilename
            Case Else
                BlueprintFilenameAndPath = ""
                MsgBox("Select a valid B/P # and print type.", MsgBoxStyle.OkOnly)
                Exit Sub
        End Select

        If File.Exists(BlueprintFilenameAndPath) Then
            System.Diagnostics.Process.Start(BlueprintFilenameAndPath)
        Else
            MsgBox("File can not be found", MsgBoxStyle.OkOnly)
        End If
    End Sub

    'Combo Box functions

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(lastFOX) Then
                unlockBatch(lastFOX)
            End If

            isLoaded = False

            'Load Defaults
            If cboDivisionID.Text = "TFP" Then
                cmdReIssue.Enabled = True
                gpxCreateNewOrder.Enabled = True
                gpxFoxOrderDetails.Enabled = True
                gpxOrderCreation.Enabled = True
                gpxEditRelease.Enabled = True
                gpxExpedite.Enabled = True
                gpxAddShipTo.Enabled = True
                dgvFOXReleaseSchedule.Enabled = True
                PrintOrderConfirmationsToolStripMenuItem.Enabled = True
                PrintPackingSlipsToolStripMenuItem.Enabled = True
                PrintPickTicketsToolStripMenuItem.Enabled = True
                PrintInvoicesToolStripMenuItem.Enabled = True
            Else
                cmdReIssue.Enabled = False
                gpxCreateNewOrder.Enabled = False
                gpxFoxOrderDetails.Enabled = False
                gpxOrderCreation.Enabled = False
                gpxEditRelease.Enabled = False
                gpxExpedite.Enabled = False
                gpxAddShipTo.Enabled = False
                dgvFOXReleaseSchedule.Enabled = False
                PrintOrderConfirmationsToolStripMenuItem.Enabled = False
                PrintPackingSlipsToolStripMenuItem.Enabled = False
                PrintPickTicketsToolStripMenuItem.Enabled = False
                PrintInvoicesToolStripMenuItem.Enabled = False
            End If

            LoadFOXNumber()
            LoadPartNumber()
            LoadPartDescription()
            LoadCustomerID()
            LoadCustomerName()
            LoadCertificationType()

            ClearData()

            ShowReleases()
            ShowProcesses()

            needsSaved = False
            isLoaded = True
        End If
    End Sub

    Private Sub cboPartNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPartNumber.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isLoaded Then
            isLoaded = True
            LoadDescriptionByPart()
            LoadPartData()
            QuantityOnHand()
            CommittedQuantity()
            LoadMTDProduction()
            LoadYTDProduction()
            LoadNumberOfFoxesForPart()
            If cboPartNumber.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboCertCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCertCode.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCertCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCertCode.SelectedIndexChanged
        If isLoaded Then
            LoadCertData()
            If cboCertCode.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboCertType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCertType.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCertType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCertType.SelectedIndexChanged
        If isLoaded Then
            LoadCertData()
            If cboCertType.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboFOXNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOXNumber.SelectedIndexChanged
        If isLoaded Then
            If pnlOverHeadBreakdown.Visible Then pnlOverHeadBreakdown.Hide()
            If Not String.IsNullOrEmpty(lastFOX) Then
                unlockBatch(lastFOX)
            End If

            ClearVariables()
            ClearData()
            ShowHeatNumbers()
            ShowProcesses()
            ShowReleases()
            ShowFOXProduction()
            LoadFOXData()
            LoadFOXCertifications()
            ShowMachineCost()
            LoadOutsideOperations()
            LoadCurrentProductionNumber()
            LoadProductionProcesses()
            isLoaded = False
            LoadRawMaterialData()
            LoadFOXCosting()
            LoadWIPDataForAdjustments()
            isLoaded = True
            needsSaved = False
            lastFOX = cboFOXNumber.Text
            If tabItemProcess.SelectedIndex = 6 Then
                ProductionAPI.LoadSingleFOXProductionData(New WIPDataPassed(dgvProductionData, cboFOXNumber.Text, pnlNoWIPData, True))
            End If
        End If
    End Sub

    Private Sub cboSteelCarbon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelCarbon.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSteelCarbon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelCarbon.TextChanged
        If isLoaded Then
            If cboSteelCarbon.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.TextChanged
        If isLoaded Then
            If cboSteelSize.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboBoxType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBoxType.TextChanged
        If isLoaded Then
            If cboBoxType.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboCustomerID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerID.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCustomerID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.TextChanged
        If isLoaded Then
            If cboCustomerID.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboSteelCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelCarbon.SelectedIndexChanged
        If isLoaded Then
            If String.IsNullOrEmpty(cboAlternateCarbon.Text) Then
                cboAlternateCarbon.Text = cboSteelCarbon.Text
            End If
            If cboSteelSize.SelectedIndex <> -1 Then
                LoadRMIDAndDescription()
            End If
            If Not String.IsNullOrEmpty(cboSteelCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isLoaded = False
                cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboSteelCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                cboSteelSize.Text = tmp
                isLoaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isLoaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isLoaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If isLoaded Then
            If String.IsNullOrEmpty(cboAlternateSteelSize.Text) Then
                cboAlternateSteelSize.Text = cboSteelSize.Text
            End If
            If cboSteelCarbon.SelectedIndex <> -1 Then
                LoadRMIDAndDescription()
            End If
            If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                Dim tmp As String = cboSteelCarbon.Text
                isLoaded = False
                If cboSteelSize.Text.Contains("/") Then
                    cboSteelCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                Else
                    cboSteelCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelCarbon.Text = tmp
                isLoaded = True
            Else
                Dim tmp As String = cboSteelCarbon.Text
                isLoaded = False
                cboSteelCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
                cboSteelCarbon.Text = tmp
                isLoaded = True
            End If
        End If
    End Sub

    Private Sub cboBoxType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBoxType.SelectedIndexChanged
        If isLoaded Then
            ''LoadBoxDescription()
            If cboBoxType.SelectedIndex <> -1 Then
                txtBoxDescription.Text = ds6.Tables("ItemList").Rows(cboBoxType.SelectedIndex).Item("ShortDescription")
            End If
        End If
    End Sub

    Private Sub cboBoxType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBoxType.Leave
        If cboBoxType.SelectedIndex = -1 Then
            If BoxReference.ContainsKey(cboBoxType.Text) Then
                cboBoxType.Text = BoxReference(cboBoxType.Text)
            Else
                txtBoxDescription.Text = ""
            End If
        End If
    End Sub

    Private Sub cboPartDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPartDescription.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        If isLoaded Then
            If cboDivisionID.Text.Equals("TFP") Then
                If cboPartDescription.Focused() Then
                    LoadPartByDescription()
                End If
            Else
                LoadPartByDescription()
            End If

            If cboPartDescription.Focused() Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If isLoaded Then
            LoadCustomerNameByID()
            isLoaded = False
            LoadAdditionalShipTo()
            isLoaded = True
            LoadBillingAddress()

            If cboShipToID.Text = "" Then
                LoadDefaultShippingAddress()
            Else
                LoadAddShipToData()
            End If
        End If
    End Sub

    Private Sub cboCustomerName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerName.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        If isLoaded Then
            LoadCustomerIDByName()
        End If
    End Sub

    Private Sub cboProcessID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProcessID.SelectedIndexChanged
        If isLoaded Then
            LoadMachineDescription()
        End If
    End Sub

    Private Sub cboShipToID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShipToID.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShipToID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToID.SelectedIndexChanged
        If isLoaded Then
            If cboShipToID.Text = "" Then
                LoadDefaultShippingAddress()
            Else
                LoadAddShipToData()
            End If
        End If
    End Sub

    Private Sub cboFOXStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOXStatus.SelectedIndexChanged
        If cboFOXStatus.Text = "INACTIVE" Then
            gpxOrderSteel.Enabled = False
        Else
            gpxOrderSteel.Enabled = True
        End If
    End Sub

    Private Sub cboFOXCertifications_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFOXCertifications.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShipVia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShipVia.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSTState_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSTState.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSteelCarbon_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelCarbon.Leave
        If Not String.IsNullOrEmpty(cboSteelCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            LocateRMID()
        ElseIf String.IsNullOrEmpty(cboSteelCarbon.Text) And Not String.IsNullOrEmpty(txtRMID.Text) Then
            txtRMID.Clear()
        End If
    End Sub

    Private Sub cboAlternateCarbon_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlternateCarbon.Leave
        If Not String.IsNullOrEmpty(cboAlternateCarbon.Text) And Not String.IsNullOrEmpty(cboAlternateSteelSize.Text) Then
            LocateRMID(False)
        ElseIf String.IsNullOrEmpty(cboAlternateSteelSize.Text) And Not String.IsNullOrEmpty(txtAlternateRMID.Text) Then
            txtAlternateRMID.Clear()
        End If
    End Sub

    Private Sub cboSteelSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Leave
        If Not String.IsNullOrEmpty(cboSteelCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            LocateRMID()
        ElseIf String.IsNullOrEmpty(cboSteelSize.Text) And Not String.IsNullOrEmpty(txtRMID.Text) Then
            txtRMID.Clear()
        End If
    End Sub

    Private Sub cboSteelCarbon_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelCarbon.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(cboSteelCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                LocateRMID()
            End If
        End If
    End Sub

    Private Sub cboAlternateCarbon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAlternateCarbon.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboAlternateCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlternateCarbon.SelectedIndexChanged
        If isLoaded Then
            If cboAlternateSteelSize.SelectedIndex <> -1 Then
                LoadRMIDAndDescription(False)
            End If
            If Not String.IsNullOrEmpty(cboAlternateCarbon.Text) Then
                Dim tmp As String = cboAlternateSteelSize.Text
                isLoaded = False
                cboAlternateSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboAlternateCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                cboAlternateSteelSize.Text = tmp
                isLoaded = True
            Else
                Dim tmp As String = cboAlternateSteelSize.Text
                isLoaded = False
                cboAlternateSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboAlternateSteelSize.Text = tmp
                isLoaded = True
            End If
        End If
    End Sub

    Private Sub cboAlternateCarbon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlternateCarbon.TextChanged
        If isLoaded Then
            If cboAlternateCarbon.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboAlternateCarbon_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAlternateCarbon.KeyUp
        If Not String.IsNullOrEmpty(cboAlternateCarbon.Text) And Not String.IsNullOrEmpty(cboAlternateSteelSize.Text) Then
            LocateRMID(False)
        End If
    End Sub

    Private Sub cboAlternateSteelSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAlternateSteelSize.KeyPress
        If cboAlternateSteelSize.Text.Length = 0 Then
            If e.KeyChar = "."c Then
                cboAlternateSteelSize.Text = "0."
                e.KeyChar = Nothing
                cboAlternateSteelSize.SelectionStart = cboAlternateSteelSize.Text.Length
                cboAlternateSteelSize.SelectionLength = 0
            End If
        ElseIf cboAlternateSteelSize.SelectionLength = cboAlternateSteelSize.Text.Length Then
            If e.KeyChar = "."c Then
                cboAlternateSteelSize.Text = "0."
                e.KeyChar = Nothing
                cboAlternateSteelSize.SelectionStart = cboAlternateSteelSize.Text.Length
                cboAlternateSteelSize.SelectionLength = 0
            End If
        ElseIf e.KeyChar.Equals("."c) And cboAlternateSteelSize.Text.Contains(".") Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub cboAlternateSteelSize_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAlternateSteelSize.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(cboAlternateCarbon.Text) And Not String.IsNullOrEmpty(cboAlternateSteelSize.Text) Then
                LocateRMID(False)
            End If
        End If
    End Sub

    Private Sub cboAlternateSteelSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlternateSteelSize.Leave
        If Not String.IsNullOrEmpty(cboAlternateCarbon.Text) And Not String.IsNullOrEmpty(cboAlternateSteelSize.Text) Then
            LocateRMID(False)
        ElseIf String.IsNullOrEmpty(cboAlternateSteelSize.Text) And Not String.IsNullOrEmpty(txtAlternateRMID.Text) Then
            txtAlternateRMID.Clear()
        End If
    End Sub

    Private Sub cboAlternateSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlternateSteelSize.SelectedIndexChanged
        If isLoaded Then
            If cboAlternateCarbon.SelectedIndex <> -1 Then
                LoadRMIDAndDescription(False)
            End If
            If Not String.IsNullOrEmpty(cboAlternateSteelSize.Text) Then
                Dim tmp As String = cboAlternateCarbon.Text
                isLoaded = False
                If cboAlternateSteelSize.Text.Contains("/") Then
                    cboAlternateCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboAlternateSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboAlternateSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                Else
                    cboAlternateCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboAlternateSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboAlternateSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                End If
                cboAlternateCarbon.Text = tmp
                isLoaded = True
            Else
                Dim tmp As String = cboAlternateCarbon.Text
                isLoaded = False
                cboAlternateCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
                cboAlternateCarbon.Text = tmp
                isLoaded = True
            End If
        End If
    End Sub

    Private Sub cboAlternateSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlternateSteelSize.TextChanged
        If isLoaded Then
            If cboAlternateSteelSize.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cboBoxType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBoxType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If BoxReference.ContainsKey(cboBoxType.Text) Then
                cboBoxType.Text = BoxReference(cboBoxType.Text)
            End If
        End If
    End Sub

    Private Sub cboBoxType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBoxType.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSteelSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelSize.KeyPress
        If cboSteelSize.Text.Length = 0 Then
            If e.KeyChar = "."c Then
                cboSteelSize.Text = "0."
                e.KeyChar = Nothing
                cboSteelSize.SelectionStart = cboSteelSize.Text.Length
                cboSteelSize.SelectionLength = 0
            End If
        ElseIf cboSteelSize.SelectionLength = cboSteelSize.Text.Length Then
            If e.KeyChar = "."c Then
                cboSteelSize.Text = "0."
                e.KeyChar = Nothing
                cboSteelSize.SelectionStart = cboSteelSize.Text.Length
                cboSteelSize.SelectionLength = 0
            End If
        ElseIf e.KeyChar.Equals("."c) And cboSteelSize.Text.Contains(".") Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub cboSteelSize_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelSize.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(cboSteelCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                LocateRMID()
            End If
        End If
    End Sub

    Private Sub cboShipMethod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShipMethod.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShipMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipMethod.SelectedIndexChanged
        If cboShipMethod.Text = "THIRD PARTY" Then
            txtThirdPartyShipper.Enabled = True
            GetThirdPartyBillingData()
            txtThirdPartyShipper.Focus()
        Else
            txtThirdPartyShipper.Enabled = False
            txtThirdPartyShipper.Clear()
        End If
    End Sub

    Private Sub cboFluxLoadNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFluxLoadNumber.SelectedIndexChanged
        If isLoaded Then
            cmd = New SqlCommand("SELECT Description FROM RawMaterialsTable WHERE RMID = @RMID", con)
            cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = cboFluxLoadNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            If Not IsDBNull(cmd.ExecuteScalar()) Then
                txtFluxDescription.Text = cmd.ExecuteScalar()
            Else
                txtFluxDescription.Text = ""
            End If
        End If
    End Sub

    Private Sub cboFluxLoadNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFluxLoadNumber.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    'Text box functions

    Private Sub txtSalesOrderNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesOrderNumber.TextChanged
        If isLoaded Then
            If txtSalesOrderNumber.Focused Then
                needsSaved = True
            End If

            LoadSalesOrderData()

            If Val(txtSalesOrderNumber.Text) > 0 And cboDivisionID.Text = "TFP" Then
                cmdExpediteRelease.Enabled = True
            Else
                cmdExpediteRelease.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtBlueprintNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBlueprintNumber.TextChanged
        If isLoaded Then
            If txtBlueprintNumber.Focused Then
                needsSaved = True
            End If
        End If

        CheckBPJournal()
        'GetBlueprintAndLoad()
    End Sub

    Private Sub txtFOXComment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFOXComment.TextChanged
        If isLoaded Then
            If txtFOXComment.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub txtSteelDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSteelDescription.TextChanged
        If isLoaded Then
            If txtSteelDescription.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub txtRawMaterialWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRawMaterialWeight.TextChanged
        If isLoaded Then
            If txtRawMaterialWeight.Focused Then
                needsSaved = True
                Dim finished As Double = Val(txtRawMaterialWeight.Text) - Val(txtScrapWeight.Text)
                txtFinishedWeight.Text = finished.ToString
                txtPieceWeightFOX.Text = Math.Round(finished / 1000, 5, MidpointRounding.AwayFromZero).ToString
            End If
        End If
    End Sub

    Private Sub txtFinishedWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFinishedWeight.TextChanged
        If isLoaded Then
            If txtFinishedWeight.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub txtScrapWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScrapWeight.TextChanged
        If isLoaded Then
            If txtScrapWeight.Focused Then
                needsSaved = True
                Dim finished As Double = Val(txtRawMaterialWeight.Text) - Val(txtScrapWeight.Text)
                txtFinishedWeight.Text = finished.ToString
                txtPieceWeightFOX.Text = Math.Round(finished / 1000, 5, MidpointRounding.AwayFromZero).ToString
            End If
        End If
    End Sub

    Private Sub txtRouting_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRouting.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = ""
        End If
        If controlKey Then
            controlKey = False
        End If
    End Sub

    Private Sub txtRouting_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtRouting.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Or e.KeyCode = Keys.Tab Then
            controlKey = True
        End If
    End Sub

    Private Sub txtTurnAround_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtTurnAround.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Or e.KeyCode = Keys.Tab Then
            controlKey = True
        End If
    End Sub

    Private Sub txtTurnAround_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTurnAround.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = ""
        End If
        If controlKey Then
            controlKey = False
        End If
    End Sub

    'Datagrid functions

    Private Sub dgvFOXReleaseSchedule_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFOXReleaseSchedule.CellContentClick
        For BeginningIndex As Integer = 0 To dgvFOXReleaseSchedule.Rows.Count - 1

            If dgvFOXReleaseSchedule.Rows(BeginningIndex).Cells("StatusColumn").Value = "SHIPPED" Then
                dgvFOXReleaseSchedule.Rows(BeginningIndex).ReadOnly = True
            End If

            BeginningIndex = BeginningIndex + 1
        Next
    End Sub

    Private Sub dgvFOXReleaseSchedule_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFOXReleaseSchedule.CellDoubleClick
        If Me.dgvFOXReleaseSchedule.RowCount <> 0 Then
            Dim GetPickTicketNumber As Integer
            Dim RowIndex As Integer = Me.dgvFOXReleaseSchedule.CurrentCell.RowIndex
            Dim RowShipmentNumber As Integer = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            If dgvFOXReleaseSchedule.Rows(RowIndex).Cells("StatusColumn").Value <> "SHIPPED" Then

                If RowShipmentNumber = 0 Then
                    MsgBox("There is no Pick Ticket for this Release.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Get Pick Ticket Number for Shipment
                    Dim GetPickTicketNumberString As String = "SELECT PickTicketNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND ShipmentNumber = @ShipmentNumber"
                    Dim GetPickTicketNumberCommand As New SqlCommand(GetPickTicketNumberString, con)
                    GetPickTicketNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPickTicketNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPickTicketNumber = CInt(GetPickTicketNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetPickTicketNumber = 0
                    End Try
                    con.Close()

                    GlobalPickListNumber = GetPickTicketNumber
                    GlobalDivisionCode = cboDivisionID.Text

                    Using NewReprintPickList As New ReprintPickList
                        Dim result = NewReprintPickList.ShowDialog()
                    End Using
                End If
            ElseIf dgvFOXReleaseSchedule.Rows(RowIndex).Cells("StatusColumn").Value = "SHIPPED" Then
                If RowShipmentNumber = 0 Then
                    MsgBox("There is no Shipment for this Release.", MsgBoxStyle.OkOnly)
                Else
                    GlobalShipmentNumber = RowShipmentNumber
                    GlobalDivisionCode = cboDivisionID.Text

                    Using PrintPackingList As New PrintPackingList
                        Dim result = PrintPackingList.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub dgvFOXReleaseSchedule_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFOXReleaseSchedule.CellValueChanged
        Try
            Dim RowLineNumber, RowShipmentNumber As Integer
            Dim RowReleaseStatus As String
            Dim RowReleaseQuantity As Double
            Dim RowReleaseDate, RowPromiseDate As DateTime

            Dim RowIndex As Integer = Me.dgvFOXReleaseSchedule.CurrentCell.RowIndex

            RowLineNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseLineNumberColumn").Value
            RowReleaseDate = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseDateColumn").Value
            RowPromiseDate = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("PromiseDateColumn").Value
            RowReleaseStatus = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("StatusColumn").Value
            RowReleaseQuantity = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseQuantityColumn").Value
            RowShipmentNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ShipmentNumberColumn").Value

            If RowReleaseStatus = "OPEN" Or RowReleaseStatus = "PENDING" Then
                'UPDATE Release Schedule
                cmd = New SqlCommand("UPDATE FOXReleaseSchedule SET ReleaseDate = @ReleaseDate, PromiseDate = @PromiseDate, ReleaseQuantity = @ReleaseQuantity WHERE FOXNumber = @FOXNumber AND ReleaseLineNumber = @ReleaseLineNumber", con)

                With cmd.Parameters
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                    .Add("@ReleaseLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                    .Add("@ReleaseDate", SqlDbType.Date).Value = RowReleaseDate
                    .Add("@PromiseDate", SqlDbType.Date).Value = RowPromiseDate
                    .Add("@ReleaseQuantity", SqlDbType.VarChar).Value = RowReleaseQuantity
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*****************************************************************************************************
                If RowReleaseStatus = "PENDING" Then
                    'UPDATE Shipment Line Table
                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET QuantityShipped = @QuantityShipped WHERE ShipmentNumber = @ShipmentNumber and PartNumber = @PartNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@QuantityShipped", SqlDbType.VarChar).Value = RowReleaseQuantity
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*****************************************************************************************************
                    'UPDATE Shipment Line Table
                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE ShipmentNumber = @ShipmentNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*****************************************************************************************************
                    Dim SumExtendedAmount As Double = 0

                    Dim SumExtendedAmountString As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE DivisionID = @DivisionID AND ShipmentNumber = @ShipmentNumber"
                    Dim SumExtendedAmountCommand As New SqlCommand(SumExtendedAmountString, con)
                    SumExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    SumExtendedAmountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SumExtendedAmount = CInt(SumExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        SumExtendedAmount = 0
                    End Try
                    con.Close()

                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal WHERE ShipmentNumber = @ShipmentNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*****************************************************************************************************
                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*****************************************************************************************************
                    'Get Current Pick Ticket number
                    Dim GetPickNumber As Integer = 0

                    Dim GetPickNumberString As String = "SELECT PickTicketNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND ShipmentNumber = @ShipmentNumber"
                    Dim GetPickNumberCommand As New SqlCommand(GetPickNumberString, con)
                    GetPickNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetPickNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPickNumber = CInt(GetPickNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetPickNumber = 0
                    End Try
                    con.Close()

                    'Update Pick Ticket
                    cmd = New SqlCommand("UPDATE PickListLineTable SET Quantity = @Quantity, ExtendedAmount = Price * @Quantity WHERE PickListHeaderKey = @PickListHeaderKey AND ItemID = @ItemID", con)

                    With cmd.Parameters
                        .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GetPickNumber
                        .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@Quantity", SqlDbType.VarChar).Value = RowReleaseQuantity
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*****************************************************************************************************
                Else
                    'Do nothing - no shipment to update
                End If

                LoadSalesOrderData()
            Else
                'Skip update on closed or pending lines
            End If
        Catch ex As Exception
            'Write to Error Log
        End Try
    End Sub

    Private Sub dgvHeatNumberLog_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHeatNumberLog.CellDoubleClick
        Dim RowLotNumber, RowHeatNumber, RowPartNumber, RowCertType, GetMinPartNumber, RowItemClass As String
        Dim RowNominalDiameter, RowNominalLength As Double
        Dim GetPullTestNumber As String

        If Me.dgvHeatNumberLog.RowCount = 0 Then

        Else
            Dim RowIndex As Integer = Me.dgvHeatNumberLog.CurrentCell.RowIndex

            RowLotNumber = Me.dgvHeatNumberLog.Rows(RowIndex).Cells("LotNumberColumn5").Value
            RowHeatNumber = Me.dgvHeatNumberLog.Rows(RowIndex).Cells("HeatNumberColumn5").Value
            RowPartNumber = Me.dgvHeatNumberLog.Rows(RowIndex).Cells("PartNumberColumn5").Value
            RowNominalDiameter = Me.dgvHeatNumberLog.Rows(RowIndex).Cells("NominalDiameterColumn5").Value
            RowNominalLength = Me.dgvHeatNumberLog.Rows(RowIndex).Cells("NominalLengthColumn5").Value
            RowCertType = Me.dgvHeatNumberLog.Rows(RowIndex).Cells("CertificationTypeColumn5").Value
            RowItemClass = Me.dgvHeatNumberLog.Rows(RowIndex).Cells("ItemClassColumn5").Value

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

                Using NewReprintCert As New ReprintCert
                    Dim Result = NewReprintCert.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub dgvFoxProcesses_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFoxProcesses.CellValueChanged
        If isLoaded Then
            If isSomeoneEditing() Then
                ShowHeatNumbers()
                ShowProcesses()
                ShowReleases()
                LoadFOXData()
                isLoaded = False
                LoadRawMaterialData()
                isLoaded = True
                Exit Sub
            End If
            LockBatch()

            If canSaveProcessChanges() Then
                'Save changes in Fox Table
                InsertUpdateFOXTable()
                UpdateFOXInItemList()
                UpdateSalesOrderFromFOX()
                InsertUpdateAdditionalShipTo()

                If dgvFoxProcesses.Columns(e.ColumnIndex).Name.Equals("ProcessIDColumn") Or dgvFoxProcesses.Columns(e.ColumnIndex).Name.Equals("ProcessAddFGColumn") Then
                    If dgvFoxProcesses.Columns(e.ColumnIndex).Name.Equals("ProcessAddFGColumn") Then
                        If dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessAddFGColumn").Value.ToString() = "NO" Then
                            Dim addFGFound As Boolean = False
                            For i As Integer = 0 To dgvFoxProcesses.Rows.Count - 1
                                If dgvFoxProcesses.Rows(i).Cells("ProcessAddFGColumn").Value.ToString.Equals("ADDINVENTORY") Then
                                    addFGFound = True
                                End If
                            Next
                            If Not addFGFound Then
                                isLoaded = False
                                dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessAddFGColumn").Value = "ADDINVENTORY"
                                isLoaded = True
                                cmd = New SqlCommand("Update FoxSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber; Update FoxProductionNumberSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber;", con)

                                FinishedGoods = "ADDINVENTORY"
                                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                                cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                            End If
                        Else
                            cmd = New SqlCommand("Update FoxSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber; Update FoxProductionNumberSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber;", con)
                            ''Adds Audit trail entry for finished goods.
                            cmd.CommandText += "  INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID);"

                            FinishedGoods = "ADDINVENTORY"
                            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                            cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)
                            cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
                            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX FINISHED GOODS STEP ADDED"
                            cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessStepColumn").Value)
                            cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
                            cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = "FOX #" + cboFOXNumber.Text + " Process Step # " + dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessStepColumn").Value.ToString() + " Machine # " + dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessIDColumn").Value.ToString() + " now adds to finished goods."
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                        End If
                    End If

                    isLoaded = False
                    If Val(dgvFoxProcesses.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) <> 0 Then
                        While dgvFoxProcesses.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Length <> 3
                            dgvFoxProcesses.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0" + dgvFoxProcesses.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                        End While
                    Else
                        dgvFoxProcesses.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dgvFoxProcesses.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.ToUpper()
                    End If

                    cmd = New SqlCommand("", con)
                    cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessIDColumn").Value
                    cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
                    cmd.Parameters.Add("@ProcessStep", SqlDbType.Int).Value = dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessStepColumn").Value
                    cmd.Parameters.Add("@ProcessAddFG", SqlDbType.VarChar).Value = dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessAddFGColumn").Value
                    cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)

                    If Not dgvFoxProcesses.Columns(e.ColumnIndex).Name.Equals("ProcessAddFGColumn") Then
                        ''Adds Audit Trail entry
                        cmd.CommandText += "  DECLARE @OriginalData as varchar(100) = (SELECT 'FOX # ' + Cast(@FOXNumber as Varchar(10)) + ' Process Step # ' + Cast(ProcessStep as varchar(5)) + ' Process ID # ' + ProcessID + ' changed to ' FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep); INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @OriginalData + @AuditComment, @DivisionID);"

                        cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX FINISHED GOODS STEP ADDED"
                        cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessStepColumn").Value)
                        cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
                        cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = " Process Step # " + dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessStepColumn").Value.ToString() + " Process ID # " + dgvFoxProcesses.Rows(e.RowIndex).Cells("ProcessIDColumn").Value.ToString()
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End If
                    cmd.CommandText += " UPDATE FOXSched SET ProcessID = @ProcessID, ProcessAddFG = @ProcessAddFG WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep;  IF @ProductionNumber <> 0 UPDATE FOXProductionNumberSched SET ProcessAddFG = @ProcessAddFG, ProcessID = @ProcessID WHERE ProductionNumber = @ProductionNumber AND FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep;"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    ShowProcesses()
                    If con.State = ConnectionState.Open Then con.Close()
                    dgvFoxProcesses.ClearSelection()
                    dgvFoxProcesses.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                    dgvFoxProcesses.CurrentCell = dgvFoxProcesses.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    isLoaded = True
                End If
            End If
        End If
    End Sub

    Private Sub dgvFOXOutsideData_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFOXOutsideData.CellValueChanged
        If isLoaded Then

            cmd = New SqlCommand("UPDATE FOXOutsideOperations SET Vendor = @Vendor, Operation = @Operation, TurnAround = @TurnAround, ProcessStep = @ProcessStep WHERE FOXNumber = @FOXNumber AND EntryNumber = @EntryNumber", con)
            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
                .Add("@EntryNumber", SqlDbType.Int).Value = dgvFOXOutsideData.Rows(e.RowIndex).Cells("EntryNumber").Value
                .Add("@Vendor", SqlDbType.VarChar).Value = dgvFOXOutsideData.Rows(e.RowIndex).Cells("Vendor").Value.ToString.ToUpper
                .Add("@Operation", SqlDbType.VarChar).Value = dgvFOXOutsideData.Rows(e.RowIndex).Cells("Operation").Value.ToString.ToUpper
                .Add("@TurnAround", SqlDbType.VarChar).Value = Val(dgvFOXOutsideData.Rows(e.RowIndex).Cells("Turn Around").Value)
                .Add("@ProcessStep", SqlDbType.VarChar).Value = Val(dgvFOXOutsideData.Rows(e.RowIndex).Cells("Process Step").Value)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            LoadOutsideOperations()
        End If
    End Sub

    Private Sub dgvFoxProcesses_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFoxProcesses.CellContentClick
        If dgvFoxProcesses.Columns(e.ColumnIndex).DataPropertyName.Equals("ProcessAddFG") Then
            dgvFoxProcesses.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvFoxProcesses_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvFoxProcesses.DragOver
        e.Effect = DragDropEffects.Move
        If dragBoxFromMouseDown <> System.Drawing.Rectangle.Empty Then
            Dim clientPoint As System.Drawing.Point = dgvFoxProcesses.PointToClient(New System.Drawing.Point(e.X, e.Y))
            Dim ht As DataGridView.HitTestInfo = dgvFoxProcesses.HitTest(clientPoint.X, clientPoint.Y)
            If ht.RowIndex >= 0 Then
                dgvFoxProcesses.ClearSelection()
                dgvFoxProcesses.Rows(ht.RowIndex).Selected = True
                dgvFoxProcesses.CurrentCell = dgvFoxProcesses.Rows(ht.RowIndex).Cells("ProcessStepColumn")
            Else
                dgvFoxProcesses.ClearSelection()
            End If
        End If
    End Sub

    Private Sub dgvFoxProcesses_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvFoxProcesses.MouseMove
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If dragBoxFromMouseDown <> System.Drawing.Rectangle.Empty AndAlso (Not dragBoxFromMouseDown.Contains(e.X, e.Y)) Then
                'Sets drop icon
                Dim dropEffect As DragDropEffects = dgvFoxProcesses.DoDragDrop(dgvFoxProcesses.Rows(rowIndexFromMouseDown), DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub dgvFoxProcesses_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvFoxProcesses.MouseDown
        If rowIndexFromMouseDown <> -1 Then
            dgvFoxProcesses.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = dgvFoxProcesses.DefaultCellStyle.BackColor
        End If
        rowIndexFromMouseDown = dgvFoxProcesses.HitTest(e.X, e.Y).RowIndex
        If rowIndexFromMouseDown <> -1 Then
            dgvFoxProcesses.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = Color.LightGray
            ' Remember the point where the mouse down occurred. The DragSize indicates the size that the mouse can move before a drag event should be started.
            Dim dragSize As Size = SystemInformation.DragSize
            ' Create a rectangle using the DragSize, with the mouse position being at the center of the rectangle.
            dragBoxFromMouseDown = New System.Drawing.Rectangle(New System.Drawing.Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
        Else
            ' Reset the rectangle if the mouse is not over an item in the ListBox.
            dragBoxFromMouseDown = System.Drawing.Rectangle.Empty
        End If
    End Sub

    Private Sub dgvFoxProcesses_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFoxProcesses.KeyUp
        If e.KeyCode = Keys.Delete Then
            cmdDeleteProcess_Click(sender, New System.EventArgs())
        End If
    End Sub

    Private Sub dgvFOXOutsideData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFOXOutsideData.KeyUp
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Are you sure you wish to delete the outside process?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmdDeleteOutside_Click(sender, New System.EventArgs())
            End If
        End If
    End Sub

    Private Sub dgvFoxProcesses_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvFoxProcesses.DragDrop
        ' The mouse locations are relative to the screen, so they must be converted to client coordinates.
        Dim clientPoint As System.Drawing.Point = dgvFoxProcesses.PointToClient(New System.Drawing.Point(e.X, e.Y))
        ' Get the row index of the item the mouse is below.
        rowIndexOfItemUnderMouseToDrop = dgvFoxProcesses.HitTest(clientPoint.X, clientPoint.Y).RowIndex

        ' If the drag operation was a move then remove and insert the row.
        If e.Effect = DragDropEffects.Move AndAlso canReorderProcesses() Then

            LockBatch()

            If rowIndexOfItemUnderMouseToDrop < rowIndexFromMouseDown AndAlso rowIndexOfItemUnderMouseToDrop <> -1 Then
                cmd = New SqlCommand("UPDATE FOXSched SET ProcessStep = ProcessStep + 100 WHERE FOXNumber = @FOXNumber AND ProcessStep = @FromLineNumber;" _
                                     + " UPDATE FOXSched SET ProcessStep = ProcessStep + 1 WHERE FOXNumber = @FOXNumber AND ProcessStep BETWEEN @DropLineNumber AND (@FromLineNumber - 1);" _
                                     + " UPDATE FOXSched SET ProcessStep = @DropLineNumber WHERE FOXNumber = @FOXNumber AND ProcessStep = @FromLineNumber + 100;" _
                                     + " DECLARE @MAXProductionNumber int = (SELECT MAX(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status <> 'CLOSED');" _
                                     + " INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)" _
                                     + " IF (@MaxProductionNumber is not null) BEGIN" _
                                     + " UPDATE FOXProductionNumberSched SET ProcessStep = ProcessStep + 100 WHERE FOXNumber = @FOXNumber AND ProcessStep = @FromLineNumber AND ProductionNumber = @MAXProductionNumber;" _
                                     + " UPDATE FOXProductionNumberSched SET ProcessStep = ProcessStep + 1 WHERE FOXNumber = @FOXNumber AND ProcessStep BETWEEN @DropLineNumber AND (@FromLineNumber - 1) AND ProductionNumber = @MAXProductionNumber;" _
                                     + " UPDATE FOXProductionNumberSched SET ProcessStep = @DropLineNumber WHERE FOXNumber = @FOXNumber AND ProcessStep = @FromLineNumber + 100 AND ProductionNumber = @MAXProductionNumber; END", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                cmd.Parameters.Add("@DropLineNumber", SqlDbType.Int).Value = dgvFoxProcesses.Rows(rowIndexOfItemUnderMouseToDrop).Cells("ProcessStepColumn").Value
                cmd.Parameters.Add("@FromLineNumber", SqlDbType.Int).Value = dgvFoxProcesses.Rows(rowIndexFromMouseDown).Cells("ProcessStepColumn").Value

                cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX PROCESS REORDERING"
                cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(dgvFoxProcesses.Rows(rowIndexFromMouseDown).Cells("ProcessStepColumn").Value)
                cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
                cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = "FOX #" + cboFOXNumber.Text + " Process Step # " + dgvFoxProcesses.Rows(rowIndexFromMouseDown).Cells("ProcessStepColumn").Value.ToString() + " Machine # " + dgvFoxProcesses.Rows(rowIndexFromMouseDown).Cells("ProcessIDColumn").Value.ToString() + " moved to step" + dgvFoxProcesses.Rows(rowIndexOfItemUnderMouseToDrop).Cells("ProcessStepColumn").Value.ToString + "."
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As System.Exception
                    sendErrorToDataBase("FOXMenu - dgvFoxProcesses_DragDrop -- Error updating FOXSched table with new order", "FOX #" + cboFOXNumber.Text, ex.ToString)
                    MessageBox.Show("There was an issue re-ordering the rows. Try again and if issue persists contact system admin.", "Unable to reorder", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
                con.Close()
            ElseIf rowIndexOfItemUnderMouseToDrop <> -1 AndAlso rowIndexOfItemUnderMouseToDrop <> rowIndexFromMouseDown Then
                cmd = New SqlCommand("UPDATE FOXSched SET ProcessStep = ProcessStep + 100 WHERE FOXNumber = @FOXNumber AND ProcessStep = @FromLineNumber;" _
                                     + " UPDATE FOXSched SET ProcessStep = ProcessStep - 1 WHERE FOXNumber = @FOXNumber AND ProcessStep BETWEEN (@FromLineNumber + 1) AND @DropLineNumber;" _
                                     + " UPDATE FOXSched SET ProcessStep = @DropLineNumber WHERE FOXNumber = @FOXNumber AND ProcessStep = @FromLineNumber + 100;" _
                                     + " DECLARE @MAXProductionNumber int = (SELECT MAX(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status <> 'CLOSED');" _
                                     + " INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)" _
                                     + " IF (@MaxProductionNumber is not null) BEGIN" _
                                     + " UPDATE FOXProductionNumberSched SET ProcessStep = ProcessStep + 100 WHERE FOXNumber = @FOXNumber AND ProcessStep = @FromLineNumber  AND ProductionNumber = @MAXProductionNumber;" _
                                     + " UPDATE FOXProductionNumberSched SET ProcessStep = ProcessStep - 1 WHERE FOXNumber = @FOXNumber AND ProcessStep BETWEEN (@FromLineNumber + 1) AND @DropLineNumber  AND ProductionNumber = @MAXProductionNumber;" _
                                     + " UPDATE FOXProductionNumberSched SET ProcessStep = @DropLineNumber WHERE FOXNumber = @FOXNumber AND ProcessStep = @FromLineNumber + 100  AND ProductionNumber = @MAXProductionNumber; END", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                cmd.Parameters.Add("@DropLineNumber", SqlDbType.Int).Value = dgvFoxProcesses.Rows(rowIndexOfItemUnderMouseToDrop).Cells("ProcessStepColumn").Value
                cmd.Parameters.Add("@FromLineNumber", SqlDbType.Int).Value = dgvFoxProcesses.Rows(rowIndexFromMouseDown).Cells("ProcessStepColumn").Value

                cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX PROCESS REORDERING"
                cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(dgvFoxProcesses.Rows(rowIndexFromMouseDown).Cells("ProcessStepColumn").Value)
                cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
                cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = "FOX #" + cboFOXNumber.Text + " Process Step # " + dgvFoxProcesses.Rows(rowIndexFromMouseDown).Cells("ProcessStepColumn").Value.ToString() + " Machine # " + dgvFoxProcesses.Rows(rowIndexFromMouseDown).Cells("ProcessIDColumn").Value.ToString() + " moved to step" + dgvFoxProcesses.Rows(rowIndexOfItemUnderMouseToDrop).Cells("ProcessStepColumn").Value.ToString + "."
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As System.Exception
                    sendErrorToDataBase("FOXMenu - dgvFoxProcesses_DragDrop -- Error updating FOXSched table with new order", "FOX #" + cboFOXNumber.Text, ex.ToString)
                    MessageBox.Show("There was an issue re-ordering the rows. Try again and if issue persists contact system admin.", "Unable to reorder", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
                con.Close()
            End If
            dgvFoxProcesses.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = dgvFoxProcesses.DefaultCellStyle.BackColor
            rowIndexFromMouseDown = -1
            rowIndexFromMouseDown = -1
            dragBoxFromMouseDown = System.Drawing.Rectangle.Empty

            ShowProcesses()
        Else
            dgvFoxProcesses.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = dgvFoxProcesses.DefaultCellStyle.BackColor
        End If
    End Sub

    'Clear functions

    Public Sub ClearVariables()
        CheckShippingMethod = ""
        ShipToName = ""
        ThirdPartyShipper = ""
        ShipMethod = ""
        BillToName = ""
        BillToAddress1 = ""
        BillToAddress2 = ""
        BillToCity = ""
        BillToState = ""
        BillToZip = ""
        BlueprintRevision = ""
        MachineDescription = ""
        MAXSalesOrder = 0
        NextSalesOrderNumber = 0
        LastSalesOrderNumber = 0
        NextFOXNumber = 0
        LastFOXNumber = 0
        ProductTotal = 0
        SalesOrderTotal = 0
        GLCreditAccount = ""
        FirstReleaseDate = ""
        FinishedGoods = ""
        CertDescription = ""
        SteelDescription = ""
        RMID = ""
        PartNumber = ""
        BlueprintNumber = ""
        FluxLoadNumber = ""
        CreationDate = DateTime.Now
        Comments = ""
        CertificationCode = ""
        BoxType = ""
        RawMaterialWeight = 0
        FinishedWeight = 0
        ScrapWeight = 0
        TWDQuantityOnHand = 0
        OrderReferenceNumber = 0
        CustomerID = ""
        PromiseDate = DateTime.Now
        LongDescription = ""
        ShortDescription = ""
        ItemClass = ""
        PurchProdLineID = ""
        SalesProdLineID = ""
        OldPartNumber = ""
        PieceWeight = 0
        BoxWeight = 0
        PalletWeight = 0
        StandardCost = 0
        StandardPrice = 0
        ProductionQuantity = 0
        BoxCount = 0
        PalletCount = 0
        PalletPieces = 0
        MinimumStock = 0
        MaximumStock = 0
        NextReleaseLineNumber = 0
        LastReleaseLineNumber = 0
        NextProcessStepNumber = 0
        LastProcessStepNumber = 0
        TWDCommittedQuantity = 0
        GlobalFOXNumber = 0
        lastFOX = ""
        SOStatus = ""
        ShippingAccount = ""
        ShipEmail = ""
        CheckOldPreferredRMID = ""
        CheckOldAlternateRMID = ""
        AuditComment = ""
        ProductionNote = ""
        ATLPartNumber = ""
        CustomerPartNumber = ""
        CustomerPONumber = ""
        IsSteelTypeValid = ""
    End Sub

    Public Sub ClearData()
        isLoaded = False
        cboBoxType.Text = ""
        cboCertCode.Text = ""
        cboCertType.Text = ""
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboFOXStatus.Text = ""
        cboProcessID.Text = ""
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""
        cboShipToID.Text = ""
        cboShipVia.Text = ""
        cboSteelCarbon.Text = ""
        cboSteelSize.Text = ""
        cboSTState.Text = ""
        cboAlternateCarbon.Text = ""
        cboAlternateSteelSize.Text = ""
        cboShipMethod.Text = ""

        lblCertDescription.Text = ""
        lblCommittedQuantity.Text = ""
        lblItemClass.Text = ""
        lblLongDescription.Text = ""
        lblMaximum.Text = ""
        lblMinimum.Text = ""
        lblMTDProduction.Text = ""
        lblOldPartNumber.Text = ""
        lblPalletPieces.Text = ""
        lblPalletWeight.Text = ""
        lblPPL.Text = ""
        lblQuantityOnHand.Text = ""
        lblShortDescription.Text = ""
        lblSPL.Text = ""
        lblStandardCost.Text = ""
        lblStandardPrice.Text = ""
        lblYTDProduction.Text = ""

        cboBoxType.SelectedIndex = -1
        cboCertCode.SelectedIndex = -1
        cboCertType.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboFOXStatus.SelectedIndex = -1
        cboProcessID.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboSteelCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboSteelCarbon.SelectedIndex = -1
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
        cboAlternateCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboAlternateCarbon.SelectedIndex = -1
        cboAlternateSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboAlternateSteelSize.SelectedIndex = -1
        cboSTState.SelectedIndex = -1
        cboFluxLoadNumber.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboFluxLoadNumber.Text) Then
            cboFluxLoadNumber.Text = ""
        End If

        txtBlueprintNumber.Clear()
        txtBoxDescription.Clear()
        txtCustomerPO.Clear()
        txtFinishedWeight.Clear()
        txtFluxDescription.Clear()
        txtFOXComment.Clear()
        txtFreightCharge.Clear()
        txtLastShipDate.Clear()
        txtMachineDescription.Clear()
        txtNextShipDate.Clear()
        txtProcessStep.Clear()
        txtQuantityOpen.Clear()
        txtQuantityOrdered.Clear()
        txtQuantityShipped.Clear()
        txtQuantityShippedToDate.Clear()
        txtQuotedPrice.Clear()
        txtQuotedQuantity.Clear()
        txtQuoteNumber.Clear()
        txtRawMaterialWeight.Clear()
        txtReleaseQuantity.Clear()
        txtRevisionLevel.Clear()
        txtRMID.Clear()
        txtSalesOrderNumber.Clear()
        txtScrapWeight.Clear()
        txtSpecialInstructions.Clear()
        txtSTAddress1.Clear()
        txtSTAddress2.Clear()
        txtSTCity.Clear()
        txtSTCountry.Clear()
        txtSteelDescription.Clear()
        txtSTName.Clear()
        txtSTZip.Clear()
        txtUnitPrice.Clear()
        txtSteelAvailable.Clear()
        txtSteelCommitted.Clear()
        txtSteelQOH.Clear()
        txtSteelRemaining.Clear()
        txtSteelRequired.Clear()
        txtSteelShipped.Clear()
        txtQtyOnOrder.Clear()
        txtQtyOnReleases.Clear()
        txtDifference.Clear()
        txtAddPPAP.Clear()
        txtAddTooling.Clear()
        txtPieceWeightFOX.Clear()
        txtThirdPartyShipper.Clear()
        txtBillingAddress1.Clear()
        txtBillingAddress2.Clear()
        txtBillingCity.Clear()
        txtBillingCountry.Clear()
        txtBillingState.Clear()
        txtBillingZip.Clear()
        txtOverheadCost.Clear()
        txtOtherCost.Clear()
        txtShippingCost.Clear()
        txtTotalCost.Clear()
        txtRawMaterialCost.Clear()
        txtAlternateRMID.Clear()
        txtOpenSteelPOQuantity.Clear()
        txtSOStatus.Clear()
        txtNumberOfFoxes.Clear()
        txtShippingAccount.Clear()
        txtShipEmail.Clear()
        txtOrderStatus.Clear()
        txtPieceWeight.Clear()
        txtBoxCount.Clear()
        txtBoxWeight.Clear()
        txtPalletCount.Clear()
        txtProductionNote.Clear()
        txtATLPartNumber.Clear()
        txtCustomerPartNumber.Clear()
        txtCustomerPONumber.Clear()
        txtWIPAdjustmentQuantity.Clear()
        txtWIPBlanksInWIP.Clear()
        txtWIPComment.Clear()
        txtWIPFinishedGoodsStep.Clear()
        txtWIPProcessStep.Clear()

        dtpCreationDate.Value = DateTime.Now
        dtpOrderDate.Value = DateTime.Now
        dtpPromiseDate.Value = DateTime.Now
        dtpReleaseDate.Value = DateTime.Now
        dtpShipDate.Value = DateTime.Now
        dtpFOXPromiseDate.Value = DateTime.Now

        cboCustomerID.Enabled = True
        cboCustomerName.Enabled = True

        chkAddToFinishedGoods.Checked = False
        chkAddPPAP.Checked = False
        chkAddTooling.Checked = False
        chkAddExpedite.Checked = False
        chkFGPrint.Checked = False
        chkHeadingPrint.Checked = False
        chkHeatTreatPrints.Checked = False
        chkMachiningPrint.Checked = False
        chkToolingPrint.Checked = False
        chkTWEAccessories.Checked = False

        dgvProductionProcesses.DataSource = Nothing
        dgvFOXCertifications.DataSource = Nothing
        dgvFOXOutsideData.DataSource = Nothing
        dgvFoxProcesses.DataSource = Nothing
        dgvFOXProduction.DataSource = Nothing
        dgvFOXReleaseSchedule.DataSource = Nothing
        dgvHeatNumberLog.DataSource = Nothing
        dgvMachineCost.DataSource = Nothing
        dgvOverheadBreakdown.DataSource = Nothing
        dgvProductionData.DataSource = Nothing
        dgvProductionProcesses.DataSource = Nothing

        LoadFOXCertifications()

        ShowMachineCost()
        isLoaded = True
    End Sub

    'Command button functions

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            unlockBatch()
        End If
        If pnlOverHeadBreakdown.Visible Then pnlOverHeadBreakdown.Hide()
        cboFOXNumber.SelectedIndex = -1
        'Clear text boxes
        ClearVariables()
        ClearData()
        ClearProcesses()
        clearOutsideOperations()
        needsSaved = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            LockBatch()

            ValidateSteelInFOX()

            If IsSteelTypeValid = "INVALID STEEL" Then
                MsgBox("Scheduled/Alternate Steel is either closed or does not exist.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If

            Try
                'Call sub to save to Fox Table
                UpdateFOXTable()
                'Save FOX In Item List
                UpdateFOXInItemList()
                'Run save routine on Sales Order, if applicable
                UpdateSalesOrderFromFOX()
                'Run save on additional shipping address
                InsertUpdateAdditionalShipTo()
            Catch ex As Exception
                MessageBox.Show("There was a problem saving the FOX. Check data and try again. If problem persists, contact system admin.", "Unable to complete save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            LoadSalesOrderData()
            ShowProcesses()

            'resets the check to save
            needsSaved = False

            ''checks to see if there are still parts in WIP, it so this will correct the parts.
            If cboFOXStatus.Text.Equals("INACTIVE") Then
                Dim CompleteProduction As New ProductionCompletion(Val(txtProductionNumber.Text), Val(cboFOXNumber.Text), True)
                While CompleteProduction.IsRunning
                    System.Threading.Thread.Sleep(500)
                End While
                txtProductionQuantity.Clear()
                txtProductionNumber.Clear()
            Else
                If txtQuotedQuantity.Text <> txtProductionQuantity.Text And cboDivisionID.Text.Equals("TFP") Then
                    txtProductionQuantity.Text = (Val(txtQuotedQuantity.Text) * 1.1).ToString()
                    If String.IsNullOrEmpty(txtProductionNumber.Text) Or Val(txtProductionNumber.Text) = 0 Then
                        txtProductionNumber.Text = "80316"
                    End If

                    cmd = New SqlCommand("IF EXISTS(SELECT ProductionNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber) UPDATE FOXProductionNumberHeaderTable SET ProductionQuantity = @ProductionQuantity, Status = 'OPEN' WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber ELSE BEGIN INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status) VALUES(@ProductionNumber, @FOXNumber, CURRENT_TIMESTAMP, @ProductionQuantity, 'OPEN'); INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) SELECT @ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG FROM FOXSched WHERE FOXNumber = @FOXNumber; END;", con)
                    cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)
                    cmd.Parameters.Add("@ProductionQuantity", SqlDbType.Int).Value = Val(txtProductionQuantity.Text)
                    cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        sendErrorToDataBase("FOXMenu - cmdCreateSO --Error inserting/updating ProductionNumber", "FOX #" + cboFOXNumber.Text, ex.ToString())
                    End Try
                    con.Close()
                End If

            End If

            MessageBox.Show("FOX has been saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdGenerateFOX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateFOX.Click
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            unlockBatch()
        End If

        'Clear form on next number
        ClearVariables()
        ClearData()
        ShowHeatNumbers()
        ShowProcesses()
        ShowReleases()

        Try
            InsertFOXTable()
        Catch ex As Exception
            cboFOXNumber.Text = ""
            MessageBox.Show("There was an issue generating a new FOX Number. Contact system admin", "Unable to generate FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub cmdItemRacking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GlobalMaintenancePartNumber = cboPartNumber.Text

        Using NewInventoryRacking As New InventoryRacking
            Dim result = NewInventoryRacking.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewFOXListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFOXListing.Click
        GlobalFOXNumber = Val(cboFOXNumber.Text)

        Using NewViewFOXListing As New ViewFOXListing
            Dim result = NewViewFOXListing.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdProductionScheduling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintProductionWorkOrder.Click
        GlobalFOXNumber = Val(cboFOXNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text
        GlobalProductionWorkOrder = "Work Order"
        GlobalProductionOrderAutoprint = "YES"

        Using NewPrintProductionOrder As New PrintProductionOrderNew
            Dim Result = NewPrintProductionOrder.ShowDialog()
        End Using
    End Sub

    Private Sub cmdItemInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemInformation.Click
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalMaintenancePartDescription = lblShortDescription.Text
        GlobalItemListingPartNumber = cboPartNumber.Text
        Using NewItemMaintenance As New ItemMaintenance
            Dim result = NewItemMaintenance.ShowDialog()
        End Using
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdCreateSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateSO.Click
        Dim LastSONumber, NextSONumber As Integer
        If canCreateSO() Then
            'Validate - checking for existing order (open), if not, prompt to create new order
            Dim SOStatus As String = ""

            Dim SOStatusString As String = "SELECT SOStatus FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = 'TFP'"
            Dim SOStatusCommand As New SqlCommand(SOStatusString, con)
            SOStatusCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SOStatus = CStr(SOStatusCommand.ExecuteScalar)
            Catch ex As Exception
                SOStatus = "NONE"
            End Try
            con.Close()
            '**************************************************************************************************************
            If SOStatus = "NONE" Or SOStatus = "" Then '' OR SOStatus = "CLOSED" Then
                Dim button As DialogResult = MessageBox.Show("Do you wish to create a new Sales Order from this FOX?", "CREATE SALES ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    ValidateShippingMethod()

                    If CheckShippingMethod = "EXIT SUB" Then
                        MsgBox("You must select a valid shipping Method.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    'More validation!!!!!
                    InsertUpdateAdditionalShipTo()
                    '***********************************************************************************************************
                    Dim GetNewSONumberStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderHeaderTable"
                    Dim GetNewSONumberCommand As New SqlCommand(GetNewSONumberStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastSONumber = CInt(GetNewSONumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastSONumber = 0
                    End Try
                    con.Close()

                    NextSONumber = LastSONumber + 1
                    '***********************************************************************************************************
                    If txtSTName.Text = "" Or txtSTName.Text = "DEFAULT SHIP TO" Then
                        ShipToName = cboCustomerName.Text
                    Else
                        ShipToName = txtSTName.Text
                    End If
                    '***********************************************************************************************************
                    'Write Data to Sales Order Header Database Table
                    cmd = New SqlCommand("Insert Into SalesOrderHeaderTable(SalesOrderKey, SalesOrderDate, CustomerID, CustomerPO, CustomerPOType, SalesPerson, DivisionKey, ShipVia, ShippingDate, HeaderComment, PRONumber, FreightCharge, TotalSalesTax, ProductTotal, SOTotal, SOStatus, AdditionalShipTo, QuoteNumber, QuotedFreight, ShippingWeight, SpecialInstructions, DropShipPONumber, TotalSalesTax2, TotalSalesTax3, TotalEstCOS, TaxRate1, TaxRate2, TaxRate3, Locked, FOB, CustomerClass, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3)Values(@SalesOrderKey, @SalesOrderDate, @CustomerID, @CustomerPO, @CustomerPOType, @SalesPerson, @DivisionKey, @ShipVia, @ShippingDate, @HeaderComment, @PRONumber, @FreightCharge, @TotalSalesTax, @ProductTotal, @SOTotal, @SOStatus, @AdditionalShipTo, @QuoteNumber, @QuotedFreight, @ShippingWeight, @SpecialInstructions, @DropShipPONumber, @TotalSalesTax2, @TotalSalesTax3, @TotalEstCOS, @TaxRate1, @TaxRate2, @TaxRate3, @Locked, @FOB, @CustomerClass, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3)", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextSONumber
                        .Add("@SalesOrderDate", SqlDbType.VarChar).Value = dtpCreationDate.Text
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@SalesPerson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                        .Add("@TotalSalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                        .Add("@SOTotal", SqlDbType.VarChar).Value = 0
                        .Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"
                        .Add("@PRONumber", SqlDbType.VarChar).Value = ""
                        .Add("@ShippingDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                        .Add("@HeaderComment", SqlDbType.VarChar).Value = ""
                        .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                        .Add("@ShippingWeight", SqlDbType.VarChar).Value = 0
                        .Add("@QuoteNumber", SqlDbType.VarChar).Value = ""
                        .Add("@QuotedFreight", SqlDbType.VarChar).Value = 0
                        .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                        .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                        .Add("@CustomerPOType", SqlDbType.VarChar).Value = ""
                        .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = 0
                        .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = 0
                        .Add("@TotalEstCOS", SqlDbType.VarChar).Value = 0
                        .Add("@TaxRate1", SqlDbType.VarChar).Value = 0
                        .Add("@TaxRate2", SqlDbType.VarChar).Value = 0
                        .Add("@TaxRate3", SqlDbType.VarChar).Value = 0
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@FOB", SqlDbType.VarChar).Value = "Medina"
                        .Add("@CustomerClass", SqlDbType.VarChar).Value = "STANDARD"
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                        .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                        .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                        .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                        .Add("@ShipToCity", SqlDbType.VarChar).Value = txtSTCity.Text
                        .Add("@ShipToState", SqlDbType.VarChar).Value = cboSTState.Text
                        .Add("@ShipToZip", SqlDbType.VarChar).Value = txtSTZip.Text
                        .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtSTCountry.Text
                        .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
                        .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
                        .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
                        .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
                        .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************************************
                    Dim LineQuantity As Double = txtQuantityOrdered.Text
                    Dim LinePrice As Double = 0
                    Dim LineExtendedAmount As Double = 0

                    LineQuantity = Val(txtQuotedQuantity.Text)
                    LinePrice = Val(txtQuotedPrice.Text)
                    LineExtendedAmount = LineQuantity * LinePrice
                    LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                    'Write Data to Sales Order Line Database Table (Line Items)
                    cmd = New SqlCommand("Insert Into SalesOrderLineTable(SalesOrderKey, SalesOrderLineKey, ItemID, Description, Quantity, Price, LineComment, SalesTax, DivisionID, ExtendedAmount, LineWeight, LineBoxes, LineStatus, DebitGLAccount, CreditGLAccount, LeadTime, CertificationType, EstExtendedCOS)Values(@SalesOrderKey, @SalesOrderLineKey, @ItemID, @Description, @Quantity, @Price, @LineComment, @SalesTax, @DivisionID, @ExtendedAmount, @LineWeight, @LineBoxes, @LineStatus, @DebitGLAccount, @CreditGLAccount, @LeadTime, @CertificationType, @EstExtendedCOS)", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextSONumber
                        .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = 1
                        .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@Description", SqlDbType.VarChar).Value = cboPartDescription.Text
                        .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                        .Add("@Price", SqlDbType.VarChar).Value = LinePrice
                        .Add("@LineComment", SqlDbType.VarChar).Value = ""
                        .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@LineWeight", SqlDbType.VarChar).Value = Val(txtQuotedQuantity.Text) * PieceWeight
                        .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "49999"
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = "12500"
                        .Add("@LeadTime", SqlDbType.VarChar).Value = "  /  /"
                        .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                        .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '******************************************************************************************
                    'Sum Lines and update totals
                    Dim SumLineTotal As Double = 0
                    Dim SOTotal As Double = 0

                    Dim SumLineTotalString As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = 'TFP'"
                    Dim SumLineTotalCommand As New SqlCommand(SumLineTotalString, con)
                    SumLineTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextSONumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SumLineTotal = CDbl(SumLineTotalCommand.ExecuteScalar)
                    Catch ex As Exception
                        SumLineTotal = 0
                    End Try
                    con.Close()

                    SOTotal = SumLineTotal + Val(txtFreightCharge.Text)
                    '******************************************************************************************
                    'Update Total in Sales Order

                    'Update Data to Sales Order Header Database Table
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET ProductTotal = @ProductTotal, FreightCharge = @FreightCharge, SOTotal = @SOTotal WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextSONumber
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = SumLineTotal
                        .Add("@SOTotal", SqlDbType.VarChar).Value = SOTotal
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '******************************************************************************************
                    'Update FOX Table with Sales Order Number and Customer
                    cmd = New SqlCommand("Update FOXTable SET RMID = @RMID, PartNumber = @PartNumber, BlueprintNumber = @BlueprintNumber, RawMaterialWeight = @RawMaterialWeight, FinishedWeight = @FinishedWeight, ScrapWeight = @ScrapWeight, FluxLoadNumber = @FluxLoadNumber, CreationDate = @CreationDate, Comments = @Comments, CertificationType = @CertificationType, Status = @Status, BoxType = @BoxType, CustomerID = @CustomerID, ProductionQuantity = @ProductionQuantity, PromiseDate = @PromiseDate, OrderReferenceNumber = @OrderReferenceNumber, BlueprintRevision = @BlueprintRevision, Locked = @Locked, QuoteNumber = @QuoteNumber, QuotePrice = @QuotePrice WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                        .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = Val(txtRawMaterialWeight.Text)
                        .Add("@FinishedWeight", SqlDbType.VarChar).Value = Val(txtFinishedWeight.Text)
                        .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtScrapWeight.Text)
                        .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = cboFluxLoadNumber.Text
                        .Add("@CreationDate", SqlDbType.VarChar).Value = dtpCreationDate.Text
                        .Add("@Comments", SqlDbType.VarChar).Value = txtFOXComment.Text
                        .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                        .Add("@Status", SqlDbType.VarChar).Value = cboFOXStatus.Text
                        .Add("@BoxType", SqlDbType.VarChar).Value = cboBoxType.Text
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@ProductionQuantity", SqlDbType.VarChar).Value = Val(txtQuotedQuantity.Text)
                        .Add("@PromiseDate", SqlDbType.VarChar).Value = dtpFOXPromiseDate.Text
                        .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = NextSONumber
                        .Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtRevisionLevel.Text
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@QuoteNumber", SqlDbType.VarChar).Value = txtQuoteNumber.Text
                        .Add("@QuotePrice", SqlDbType.VarChar).Value = Val(txtQuotedPrice.Text)
                    End With

                    Try
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                        sendErrorToDataBase("FOXMenu - UpdateFOXTable --Error Updating FOXTable", "FOX #" + cboFOXNumber.Text, ex.ToString())
                        Throw ex
                    End Try
                    '******************************************************************************************
                    'Load Sales Order Data
                    txtSalesOrderNumber.Text = NextSONumber
                    '******************************************************************************************
                    LoadFOXData()
                    'LoadSalesOrderData()
                    txtProductionNumber.Text = ProductionAPI.StartNewProduction(0, Val(cboFOXNumber.Text), Val(txtQuotedQuantity.Text))
                    txtProductionQuantity.Text = txtQuotedQuantity.Text

                    MsgBox("Sales Order is created.", MsgBoxStyle.OkOnly)
                ElseIf button = DialogResult.No Then
                    ValidateShippingMethod()

                    If CheckShippingMethod = "EXIT SUB" Then
                        MsgBox("You must select a valid shipping Method.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    InsertUpdateAdditionalShipTo()
                    '***********************************************************************************************************
                    If txtSTName.Text = "" Or txtSTName.Text = "DEFAULT SHIP TO" Then
                        ShipToName = cboCustomerName.Text
                    Else
                        ShipToName = txtSTName.Text
                    End If
                    '***********************************************************************************************************
                    'Update existing Sales Order
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SalesOrderDate = @SalesOrderDate, CustomerID = @CustomerID, CustomerPO = @CustomerPO, CustomerPOType = @CustomerPOType, SalesPerson = @SalesPerson, ShipVia = @ShipVia, ShippingDate = @ShippingDate, HeaderComment = @HeaderComment, PRONumber = @PRONumber, FreightCharge = @FreightCharge, TotalSalesTax = @TotalSalesTax, ProductTotal = @ProductTotal, SOTotal = @SOTotal, SOStatus = @SOStatus, AdditionalShipTo = @AdditionalShipTo, QuoteNumber = @QuoteNumber, QuotedFreight = @QuotedFreight, ShippingWeight = @ShippingWeight, SpecialInstructions = @SpecialInstructions, DropShipPONumber = @DropShipPONumber, TotalSalesTax2 = TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3, TotalEstCOS = @TotalEstCOS, TaxRate1 = @TaxRate1, TaxRate2 = @TaxRate2, TaxRate3 = @TaxRate3, Locked = @Locked, FOB = @FOB, CustomerClass = @CustomerClass, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShipToAddress1 = @ShipToAddress1, ShipToAddress2 = @ShipToAddress2, ShipToCity = @ShipToCity, ShipToState = @ShipToState, ShipToZip = @ShipToZip, ShipToCountry = @ShipToCountry, ShipEmail = @ShipEmail, ShippingAccount = @ShippingAccount, SpecialLabelLine1 = @SpecialLabelLine1, SpecialLabelLine2 = @SpecialLabelLine2, SpecialLabelLine3 = @SpecialLabelLine3 WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        .Add("@SalesOrderDate", SqlDbType.VarChar).Value = dtpCreationDate.Text
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@SalesPerson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                        .Add("@TotalSalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                        .Add("@SOTotal", SqlDbType.VarChar).Value = 0
                        .Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"
                        .Add("@PRONumber", SqlDbType.VarChar).Value = ""
                        .Add("@ShippingDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                        .Add("@HeaderComment", SqlDbType.VarChar).Value = ""
                        .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                        .Add("@ShippingWeight", SqlDbType.VarChar).Value = 0
                        .Add("@QuoteNumber", SqlDbType.VarChar).Value = ""
                        .Add("@QuotedFreight", SqlDbType.VarChar).Value = 0
                        .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                        .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                        .Add("@CustomerPOType", SqlDbType.VarChar).Value = ""
                        .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = 0
                        .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = 0
                        .Add("@TotalEstCOS", SqlDbType.VarChar).Value = 0
                        .Add("@TaxRate1", SqlDbType.VarChar).Value = 0
                        .Add("@TaxRate2", SqlDbType.VarChar).Value = 0
                        .Add("@TaxRate3", SqlDbType.VarChar).Value = 0
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@FOB", SqlDbType.VarChar).Value = "Medina"
                        .Add("@CustomerClass", SqlDbType.VarChar).Value = "STANDARD"
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                        .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                        .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                        .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                        .Add("@ShipToCity", SqlDbType.VarChar).Value = txtSTCity.Text
                        .Add("@ShipToState", SqlDbType.VarChar).Value = cboSTState.Text
                        .Add("@ShipToZip", SqlDbType.VarChar).Value = txtSTZip.Text
                        .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtSTCountry.Text
                        .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
                        .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
                        .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
                        .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
                        .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************************************
                    'Check Line Quantity to see what has shipped prior to changing line quantity
                    Dim TotalShipped As Double = 0
                    Dim TotalPending As Double = 0

                    Dim TotalShippedString As String = "SELECT QuantityShipped FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = 'TFP'"
                    Dim TotalShippedCommand As New SqlCommand(TotalShippedString, con)
                    TotalShippedCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

                    Dim TotalPendingString As String = "SELECT PendingShippingQuantity FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = 'TFP'"
                    Dim TotalPendingCommand As New SqlCommand(TotalPendingString, con)
                    TotalPendingCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TotalShipped = CDbl(TotalShippedCommand.ExecuteScalar)
                    Catch ex As Exception
                        TotalShipped = 0
                    End Try
                    Try
                        TotalPending = CDbl(TotalPendingCommand.ExecuteScalar)
                    Catch ex As Exception
                        TotalPending = 0
                    End Try
                    con.Close()
                    '***********************************************************************************************************
                    Dim LineQuantity As Double = txtQuantityOrdered.Text
                    Dim LinePrice As Double = 0
                    Dim LineExtendedAmount As Double = 0

                    LineQuantity = Val(txtQuotedQuantity.Text)
                    LinePrice = Val(txtQuotedPrice.Text)
                    LineExtendedAmount = LineQuantity * LinePrice
                    LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                    If LineQuantity < (TotalShipped + TotalPending) Then
                        MsgBox("Quantity order cannot be changed to less than what has already shipped.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    'Write Data to Sales Order Line Database Table (Line Items)
                    cmd = New SqlCommand("UPDATE SalesOrderLineTable SET ItemID = @ItemID, Description = @Description, Quantity = @Quantity, Price = @Price, LineComment = @LineComment, SalesTax = @SalesTax, ExtendedAmount = @ExtendedAmount, LineWeight = @LineWeight, LineBoxes = @LineBoxes, LineStatus = @LineStatus, DebitGLAccount = @DebitGLAccount, CreditGLAccount = @CreditGLAccount, LeadTime = @LeadTime, CertificationType = @CertificationType, EstExtendedCOS = @EstExtendedCOS WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = 1
                        .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@Description", SqlDbType.VarChar).Value = cboPartDescription.Text
                        .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                        .Add("@Price", SqlDbType.VarChar).Value = LinePrice
                        .Add("@LineComment", SqlDbType.VarChar).Value = ""
                        .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@LineWeight", SqlDbType.VarChar).Value = Val(txtQuotedQuantity.Text) * PieceWeight
                        .Add("@LineBoxes", SqlDbType.VarChar).Value = 1
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "49999"
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = "12500"
                        .Add("@LeadTime", SqlDbType.VarChar).Value = "  /  /"
                        .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                        .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '******************************************************************************************
                    'Sum Lines and update totals
                    Dim SumLineTotal As Double = 0
                    Dim SOTotal As Double = 0

                    Dim SumLineTotalString As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = 'TFP'"
                    Dim SumLineTotalCommand As New SqlCommand(SumLineTotalString, con)
                    SumLineTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SumLineTotal = CDbl(SumLineTotalCommand.ExecuteScalar)
                    Catch ex As Exception
                        SumLineTotal = 0
                    End Try
                    con.Close()

                    SOTotal = SumLineTotal + Val(txtFreightCharge.Text)
                    '******************************************************************************************
                    'Update Total in Sales Order

                    'Update Data to Sales Order Header Database Table
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET ProductTotal = @ProductTotal, FreightCharge = @FreightCharge, SOTotal = @SOTotal WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = SumLineTotal
                        .Add("@SOTotal", SqlDbType.VarChar).Value = SOTotal
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '******************************************************************************************
                    'Update FOX Table with Sales Order Number and Customer
                    cmd = New SqlCommand("Update FOXTable SET RMID = @RMID, PartNumber = @PartNumber, BlueprintNumber = @BlueprintNumber, RawMaterialWeight = @RawMaterialWeight, FinishedWeight = @FinishedWeight, ScrapWeight = @ScrapWeight, FluxLoadNumber = @FluxLoadNumber, CreationDate = @CreationDate, Comments = @Comments, CertificationType = @CertificationType, Status = @Status, BoxType = @BoxType, CustomerID = @CustomerID, ProductionQuantity = @ProductionQuantity, PromiseDate = @PromiseDate, OrderReferenceNumber = @OrderReferenceNumber, BlueprintRevision = @BlueprintRevision, Locked = @Locked, QuoteNumber = @QuoteNumber, QuotePrice = @QuotePrice WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                        .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = Val(txtRawMaterialWeight.Text)
                        .Add("@FinishedWeight", SqlDbType.VarChar).Value = Val(txtFinishedWeight.Text)
                        .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtScrapWeight.Text)
                        .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = cboFluxLoadNumber.Text
                        .Add("@CreationDate", SqlDbType.VarChar).Value = dtpCreationDate.Text
                        .Add("@Comments", SqlDbType.VarChar).Value = txtFOXComment.Text
                        .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                        .Add("@Status", SqlDbType.VarChar).Value = cboFOXStatus.Text
                        .Add("@BoxType", SqlDbType.VarChar).Value = cboBoxType.Text
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@ProductionQuantity", SqlDbType.VarChar).Value = Val(txtQuotedQuantity.Text)
                        .Add("@PromiseDate", SqlDbType.VarChar).Value = dtpFOXPromiseDate.Text
                        .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        .Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtRevisionLevel.Text
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@QuoteNumber", SqlDbType.VarChar).Value = txtQuoteNumber.Text
                        .Add("@QuotePrice", SqlDbType.VarChar).Value = Val(txtQuotedPrice.Text)
                    End With

                    Try
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                        sendErrorToDataBase("FOXMenu - UpdateFOXTable --Error Updating FOXTable", "FOX #" + cboFOXNumber.Text, ex.ToString())
                        Throw ex
                    End Try
                    '******************************************************************************************
                    LoadFOXData()
                    LoadSalesOrderData()

                    txtProductionQuantity.Text = (Val(txtQuotedQuantity.Text) * 1.1).ToString()
                    If String.IsNullOrEmpty(txtProductionNumber.Text) Or Val(txtProductionNumber.Text) = 0 Then
                        txtProductionNumber.Text = "80316"
                    End If

                    cmd = New SqlCommand("IF EXISTS(SELECT ProductionNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber) UPDATE FOXProductionNumberHeaderTable SET ProductionQuantity = @ProductionQuantity, Status = 'OPEN' WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber ELSE BEGIN INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status) VALUES(@ProductionNumber, @FOXNumber, CURRENT_TIMESTAMP, @ProductionQuantity, 'OPEN'); INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) SELECT @ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG FROM FOXSched WHERE FOXNumber = @FOXNumber; END;", con)
                    cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)
                    cmd.Parameters.Add("@ProductionQuantity", SqlDbType.Int).Value = Val(txtProductionQuantity.Text)
                    cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        sendErrorToDataBase("FOXMenu - cmdCreateSO --Error inserting/updating ProductionNumber", "FOX #" + cboFOXNumber.Text, ex.ToString())
                    End Try

                    If con.State = ConnectionState.Open Then con.Close()

                    MsgBox("FOX and Sales Order has been updated.", MsgBoxStyle.OkOnly)
                End If
            Else
                'Update existing Sales Order
                Dim button As DialogResult = MessageBox.Show("Do you wish to update the existing Sales Order from this FOX?", "CREATE SALES ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    ValidateShippingMethod()

                    If CheckShippingMethod = "EXIT SUB" Then
                        MsgBox("You must select a valid shipping Method.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    InsertUpdateAdditionalShipTo()
                    '***********************************************************************************************************
                    If txtSTName.Text = "" Or txtSTName.Text = "DEFAULT SHIP TO" Then
                        ShipToName = cboCustomerName.Text
                    Else
                        ShipToName = txtSTName.Text
                    End If
                    '***********************************************************************************************************
                    'Write Data to Sales Order Header Database Table
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SalesOrderDate = @SalesOrderDate, CustomerID = @CustomerID, CustomerPO = @CustomerPO, CustomerPOType = @CustomerPOType, SalesPerson = @SalesPerson, ShipVia = @ShipVia, ShippingDate = @ShippingDate, HeaderComment = @HeaderComment, PRONumber = @PRONumber, FreightCharge = @FreightCharge, TotalSalesTax = @TotalSalesTax, ProductTotal = @ProductTotal, SOTotal = @SOTotal, SOStatus = @SOStatus, AdditionalShipTo = @AdditionalShipTo, QuoteNumber = @QuoteNumber, QuotedFreight = @QuotedFreight, ShippingWeight = @ShippingWeight, SpecialInstructions = @SpecialInstructions, DropShipPONumber = @DropShipPONumber, TotalSalesTax2 = TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3, TotalEstCOS = @TotalEstCOS, TaxRate1 = @TaxRate1, TaxRate2 = @TaxRate2, TaxRate3 = @TaxRate3, Locked = @Locked, FOB = @FOB, CustomerClass = @CustomerClass, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShipToAddress1 = @ShipToAddress1, ShipToAddress2 = @ShipToAddress2, ShipToCity = @ShipToCity, ShipToState = @ShipToState, ShipToZip = @ShipToZip, ShipToCountry = @ShipToCountry, ShipEmail = @ShipEmail, ShippingAccount = @ShippingAccount, SpecialLabelLine1 = @SpecialLabelLine1, SpecialLabelLine2 = @SpecialLabelLine2, SpecialLabelLine3 = @SpecialLabelLine3 WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        .Add("@SalesOrderDate", SqlDbType.VarChar).Value = dtpCreationDate.Text
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@SalesPerson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                        .Add("@TotalSalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                        .Add("@SOTotal", SqlDbType.VarChar).Value = 0
                        .Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"
                        .Add("@PRONumber", SqlDbType.VarChar).Value = ""
                        .Add("@ShippingDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                        .Add("@HeaderComment", SqlDbType.VarChar).Value = ""
                        .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                        .Add("@ShippingWeight", SqlDbType.VarChar).Value = 0
                        .Add("@QuoteNumber", SqlDbType.VarChar).Value = ""
                        .Add("@QuotedFreight", SqlDbType.VarChar).Value = 0
                        .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                        .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                        .Add("@CustomerPOType", SqlDbType.VarChar).Value = ""
                        .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = 0
                        .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = 0
                        .Add("@TotalEstCOS", SqlDbType.VarChar).Value = 0
                        .Add("@TaxRate1", SqlDbType.VarChar).Value = 0
                        .Add("@TaxRate2", SqlDbType.VarChar).Value = 0
                        .Add("@TaxRate3", SqlDbType.VarChar).Value = 0
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@FOB", SqlDbType.VarChar).Value = "Medina"
                        .Add("@CustomerClass", SqlDbType.VarChar).Value = "STANDARD"
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                        .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                        .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                        .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                        .Add("@ShipToCity", SqlDbType.VarChar).Value = txtSTCity.Text
                        .Add("@ShipToState", SqlDbType.VarChar).Value = cboSTState.Text
                        .Add("@ShipToZip", SqlDbType.VarChar).Value = txtSTZip.Text
                        .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtSTCountry.Text
                        .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
                        .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
                        .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
                        .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
                        .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************************************
                    'Check Line Quantity to see what has shipped prior to changing line quantity
                    Dim TotalShipped As Double = 0
                    Dim TotalPending As Double = 0

                    Dim TotalShippedString As String = "SELECT QuantityShipped FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = 'TFP'"
                    Dim TotalShippedCommand As New SqlCommand(TotalShippedString, con)
                    TotalShippedCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

                    Dim TotalPendingString As String = "SELECT PendingShippingQuantity FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = 'TFP'"
                    Dim TotalPendingCommand As New SqlCommand(TotalPendingString, con)
                    TotalPendingCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TotalShipped = CDbl(TotalShippedCommand.ExecuteScalar)
                    Catch ex As Exception
                        TotalShipped = 0
                    End Try
                    Try
                        TotalPending = CDbl(TotalPendingCommand.ExecuteScalar)
                    Catch ex As Exception
                        TotalPending = 0
                    End Try
                    con.Close()
                    '***********************************************************************************************************
                    Dim LineQuantity As Double = txtQuantityOrdered.Text
                    Dim LinePrice As Double = 0
                    Dim LineExtendedAmount As Double = 0

                    LineQuantity = Val(txtQuotedQuantity.Text)
                    LinePrice = Val(txtQuotedPrice.Text)
                    LineExtendedAmount = LineQuantity * LinePrice
                    LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                    If LineQuantity < (TotalShipped + TotalPending) Then
                        MsgBox("Quantity order cannot be changed to less than what has already shipped.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    'Write Data to Sales Order Line Database Table (Line Items)
                    cmd = New SqlCommand("UPDATE SalesOrderLineTable SET ItemID = @ItemID, Description = @Description, Quantity = @Quantity, Price = @Price, LineComment = @LineComment, SalesTax = @SalesTax, ExtendedAmount = @ExtendedAmount, LineWeight = @LineWeight, LineBoxes = @LineBoxes, LineStatus = @LineStatus, DebitGLAccount = @DebitGLAccount, CreditGLAccount = @CreditGLAccount, LeadTime = @LeadTime, CertificationType = @CertificationType, EstExtendedCOS = @EstExtendedCOS WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = 1
                        .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@Description", SqlDbType.VarChar).Value = cboPartDescription.Text
                        .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                        .Add("@Price", SqlDbType.VarChar).Value = LinePrice
                        .Add("@LineComment", SqlDbType.VarChar).Value = ""
                        .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@LineWeight", SqlDbType.VarChar).Value = Val(txtQuotedQuantity.Text) * PieceWeight
                        .Add("@LineBoxes", SqlDbType.VarChar).Value = 1
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "49999"
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = "12500"
                        .Add("@LeadTime", SqlDbType.VarChar).Value = "  /  /"
                        .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                        .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '******************************************************************************************
                    'Sum Lines and update totals
                    Dim SumLineTotal As Double = 0
                    Dim SOTotal As Double = 0

                    Dim SumLineTotalString As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = 'TFP'"
                    Dim SumLineTotalCommand As New SqlCommand(SumLineTotalString, con)
                    SumLineTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SumLineTotal = CDbl(SumLineTotalCommand.ExecuteScalar)
                    Catch ex As Exception
                        SumLineTotal = 0
                    End Try
                    con.Close()

                    SOTotal = SumLineTotal + Val(txtFreightCharge.Text)
                    '******************************************************************************************
                    'Update Total in Sales Order

                    'Update Data to Sales Order Header Database Table
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET ProductTotal = @ProductTotal, FreightCharge = @FreightCharge, SOTotal = @SOTotal WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = SumLineTotal
                        .Add("@SOTotal", SqlDbType.VarChar).Value = SOTotal
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '******************************************************************************************
                    'Update FOX Table with Sales Order Number and Customer
                    cmd = New SqlCommand("Update FOXTable SET RMID = @RMID, PartNumber = @PartNumber, BlueprintNumber = @BlueprintNumber, RawMaterialWeight = @RawMaterialWeight, FinishedWeight = @FinishedWeight, ScrapWeight = @ScrapWeight, FluxLoadNumber = @FluxLoadNumber, CreationDate = @CreationDate, Comments = @Comments, CertificationType = @CertificationType, Status = @Status, BoxType = @BoxType, CustomerID = @CustomerID, ProductionQuantity = @ProductionQuantity, PromiseDate = @PromiseDate, OrderReferenceNumber = @OrderReferenceNumber, BlueprintRevision = @BlueprintRevision, Locked = @Locked, QuoteNumber = @QuoteNumber, QuotePrice = @QuotePrice WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                        .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = Val(txtRawMaterialWeight.Text)
                        .Add("@FinishedWeight", SqlDbType.VarChar).Value = Val(txtFinishedWeight.Text)
                        .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtScrapWeight.Text)
                        .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = cboFluxLoadNumber.Text
                        .Add("@CreationDate", SqlDbType.VarChar).Value = dtpCreationDate.Text
                        .Add("@Comments", SqlDbType.VarChar).Value = txtFOXComment.Text
                        .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                        .Add("@Status", SqlDbType.VarChar).Value = cboFOXStatus.Text
                        .Add("@BoxType", SqlDbType.VarChar).Value = cboBoxType.Text
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@ProductionQuantity", SqlDbType.VarChar).Value = Val(txtQuotedQuantity.Text)
                        .Add("@PromiseDate", SqlDbType.VarChar).Value = dtpFOXPromiseDate.Text
                        .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        .Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtRevisionLevel.Text
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@QuoteNumber", SqlDbType.VarChar).Value = txtQuoteNumber.Text
                        .Add("@QuotePrice", SqlDbType.VarChar).Value = Val(txtQuotedPrice.Text)
                    End With

                    Try
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                        sendErrorToDataBase("FOXMenu - UpdateFOXTable --Error Updating FOXTable", "FOX #" + cboFOXNumber.Text, ex.ToString())
                        Throw ex
                    End Try
                    '******************************************************************************************
                    LoadFOXData()
                    LoadSalesOrderData()

                    txtProductionQuantity.Text = (Val(txtQuotedQuantity.Text) * 1.1).ToString()
                    If String.IsNullOrEmpty(txtProductionNumber.Text) Or Val(txtProductionNumber.Text) = 0 Then
                        txtProductionNumber.Text = "80316"
                    End If

                    cmd = New SqlCommand("IF EXISTS(SELECT ProductionNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber) UPDATE FOXProductionNumberHeaderTable SET ProductionQuantity = @ProductionQuantity, Status = 'OPEN' WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber ELSE BEGIN INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status) VALUES(@ProductionNumber, @FOXNumber, CURRENT_TIMESTAMP, @ProductionQuantity, 'OPEN'); INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) SELECT @ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG FROM FOXSched WHERE FOXNumber = @FOXNumber; END;", con)
                    cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)
                    cmd.Parameters.Add("@ProductionQuantity", SqlDbType.Int).Value = Val(txtProductionQuantity.Text)
                    cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        sendErrorToDataBase("FOXMenu - cmdCreateSO --Error inserting/updating ProductionNumber", "FOX #" + cboFOXNumber.Text, ex.ToString())
                    End Try

                    MsgBox("FOX and Sales Order has been updated.", MsgBoxStyle.OkOnly)
                ElseIf button = DialogResult.No Then
                    cmdClear.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDeleteFOX() Then
            'Check to see if this FOX has any order
            If txtSalesOrderNumber.Text = "" Or Val(txtSalesOrderNumber.Text) = 0 Then
                cmd = New SqlCommand("Delete FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Validate deletion of data
                MsgBox("This record has been deleted", MsgBoxStyle.OkOnly)

                'Clear text boxes
                ClearVariables()
                ClearData()
                ClearProcesses()
                clearOutsideOperations()
                isLoaded = False
                LoadFOXNumber()
                isLoaded = True
                needsSaved = False
            Else
                Dim button As DialogResult = MessageBox.Show("This FOX has an order associated with it, it cannot be deleted. Do you wish to de-activate?", "DE-ACTIVATE FOX", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    cmd = New SqlCommand("UPDATE FOXTable SET Status = @Status WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "INACTIVE"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    LoadFOXData()
                ElseIf button = DialogResult.No Then
                    cboFOXNumber.Focus()
                End If
            End If
        Else
            cboFOXNumber.Focus()
        End If
    End Sub

    Private Sub cmdAddRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRelease.Click
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MsgBox("You must have a valid FOX Number selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                ShowHeatNumbers()
                ShowProcesses()
                ShowReleases()
                LoadFOXData()
                isLoaded = False
                LoadRawMaterialData()
                isLoaded = True
                Exit Sub
            End If

            LockBatch()
            UpdateSalesOrderFromFOX()

            If CheckShippingMethod = "EXIT SUB" Then
                MsgBox("You must select a valid Shipping Method.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Try
                UpdateFOXTable()
                UpdateFOXInItemList()
                InsertUpdateAdditionalShipTo()
                LoadSalesOrderData()
                ShowProcesses()
            Catch ex As Exception
                MessageBox.Show("There was a problem saving the data. Check data and try again.", "Unable to save data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            'Create command to update Machine Processes
            cmd = New SqlCommand("Insert Into FOXReleaseSchedule (FOXNumber, ReleaseLineNumber, ReleaseDate, PromiseDate, ReleaseQuantity, ShippedQuantity, ShipDate, Status, ShipmentNumber)values(@FOXNumber, (SELECT isnull(MAX(ReleaseLineNumber) + 1, 1) FROM FOXReleaseSchedule Where FOXNumber = @FOXNumber), @ReleaseDate, @PromiseDate, @ReleaseQuantity, @ShippedQuantity, @PromiseDate, @Status, @ShipmentNumber)", con)

            With cmd.Parameters
                .Add("@FoxNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                .Add("@ReleaseDate", SqlDbType.VarChar).Value = dtpReleaseDate.Text
                .Add("@PromiseDate", SqlDbType.VarChar).Value = dtpPromiseDate.Text
                .Add("@ReleaseQuantity", SqlDbType.VarChar).Value = Val(txtReleaseQuantity.Text)
                .Add("@ShippedQuantity", SqlDbType.VarChar).Value = 0
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            dtpPromiseDate.Text = ""
            dtpReleaseDate.Text = ""
            txtReleaseQuantity.Clear()
            ShowReleases()
            LoadSalesOrderData()
        End If
    End Sub

    Private Sub cmdDeleteRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRelease.Click
        If canDeleteRelease() Then
            LockBatch()
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this release and any pending shipments?", "DELETE RELEASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then

                Dim RowLineNumber, RowShipmentNumber As Integer
                Dim RowStatus As String

                Dim RowIndex As Integer = Me.dgvFOXReleaseSchedule.CurrentCell.RowIndex

                RowLineNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseLineNumberColumn").Value
                RowShipmentNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
                RowStatus = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("StatusColumn").Value

                If RowStatus = "OPEN" Then
                    'Delete release from FOX
                    cmd = New SqlCommand("DELETE FROM FOXReleaseSchedule WHERE FOXNumber = @FOXNumber AND ReleaseLineNumber = @ReleaseLineNumber", con)

                    With cmd.Parameters
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                        .Add("@ReleaseLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    UpdateFOXTable()
                    UpdateFOXInItemList()
                    UpdateSalesOrderFromFOX()
                    InsertUpdateAdditionalShipTo()
                    LoadSalesOrderData()
                    ShowReleases()
                ElseIf RowStatus = "PENDING" Then
                    'Delete Pick Ticket and Shipment
                    Dim GetPickNumber As Integer

                    'Get Pick Ticket Number
                    Dim GetPickNumberString As String = "SELECT PickTicketNumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                    Dim GetPickNumberCommand As New SqlCommand(GetPickNumberString, con)
                    GetPickNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                    GetPickNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPickNumber = CInt(GetPickNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetPickNumber = 0
                    End Try
                    con.Close()

                    'Delete release from FOX
                    cmd = New SqlCommand("DELETE FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GetPickNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Delete release from FOX
                    cmd = New SqlCommand("DELETE FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Delete release from FOX
                    cmd = New SqlCommand("DELETE FROM FOXReleaseSchedule WHERE FOXNumber = @FOXNumber AND ReleaseLineNumber = @ReleaseLineNumber", con)

                    With cmd.Parameters
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                        .Add("@ReleaseLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    UpdateFOXTable()
                    UpdateFOXInItemList()
                    UpdateSalesOrderFromFOX()
                    InsertUpdateAdditionalShipTo()
                    LoadSalesOrderData()
                    ShowReleases()
                Else
                    MsgBox("Release has already shipped. It cannot be deleted.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            ElseIf button = DialogResult.No Then
                cmdDeleteRelease.Focus()
            End If
        End If
    End Sub

    Private Sub cmdExpediteRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExpediteRelease.Click
        Dim GetPickNumber, CurrentShipmentNumber, NextBatchNumber, ShipmentBatchNumber, NextShipmentNumber, LastShipmentNumber, LastTransactionNumber, NextTransactionNumber, LastPickBatchNumber, NextPickBatchNumber As Integer
        Dim CheckShipmentStatus As String = ""
        Dim GetSONumber As Integer = 0
        Dim SumLineTotal As Double = 0
        '*********************************************************************************************************
        'Check if Sales Order is open
        Dim GetSOStatus As String = ""

        Dim GetSOStatusString As String = "SELECT SOStatus FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim GetSOStatusCommand As New SqlCommand(GetSOStatusString, con)
        GetSOStatusCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        GetSOStatusCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSOStatus = CStr(GetSOStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetSOStatus = "NONE"
        End Try
        con.Close()
        '*********************************************************************************************************
        'Check Customer for HOLD Status
        Dim CheckHoldStatus As String = ""
        Dim CheckAccountingHold As String = ""

        Dim CheckHoldStatusString As String = "SELECT OnHoldStatus FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CheckHoldStatusCommand As New SqlCommand(CheckHoldStatusString, con)
        CheckHoldStatusCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CheckHoldStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckAccountingHoldString As String = "SELECT AccountingHold FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CheckAccountingHoldCommand As New SqlCommand(CheckAccountingHoldString, con)
        CheckAccountingHoldCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CheckAccountingHoldCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckHoldStatus = CStr(CheckHoldStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CheckHoldStatus = "NO"
        End Try
        Try
            CheckAccountingHold = CStr(CheckAccountingHoldCommand.ExecuteScalar)
        Catch ex As Exception
            CheckAccountingHold = "NO"
        End Try
        con.Close()

        If CheckAccountingHold = "YES" Or CheckHoldStatus = "YES" Then
            MsgBox("This customer is ON HOLD. Contact A/R to release.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If
        '*********************************************************************************************************
        'Check to see if same sales order exists on multiple foxes
        Dim CountFOXOrders As Integer = 0

        Dim CountFOXOrdersString As String = "SELECT COUNT(FOXNumber) FROM FOXTable WHERE OrderReferenceNumber = @OrderReferenceNumber AND DivisionID = @DivisionID"
        Dim CountFOXOrdersCommand As New SqlCommand(CountFOXOrdersString, con)
        CountFOXOrdersCommand.Parameters.Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        CountFOXOrdersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountFOXOrders = CInt(CountFOXOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            CountFOXOrders = 0
        End Try
        con.Close()

        If CountFOXOrders > 1 Then
            MsgBox("You have multiple FOXES linked to the same order #. You must delete order reference # from old FOXES to continue.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*********************************************************************************************************
        If cboShipVia.Text.StartsWith("UPS-") Or cboShipVia.Text.StartsWith("FDX-") Then
            If txtSTCountry.Text = "" Then
                MsgBox("FedEx and UPS Small Package shipments require a Ship To Country.", MsgBoxStyle.OkOnly)
                Exit Sub
                txtSTCountry.Focus()
            Else
                'Continue
            End If
        End If
        '*********************************************************************************************************
        If GetSOStatus = "NONE" Or GetSOStatus = "CLOSED" Or GetSOStatus = "" Then
            MsgBox("This FOX does not have an order created or the order is closed. Create new order or re-open sales order and try again.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Prompt before expediting
            Dim button As DialogResult = MessageBox.Show("Do you wish to Expedite this Release to Shipping?", "EXPEDITE TO SHIPPING", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '***************************************************************************************************************************
                'Save SO Header data
                UpdateSalesOrderFromFOX()

                If CheckShippingMethod = "EXIT SUB" Then
                    MsgBox("You must select a valid Shipping Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                UpdateFOXInItemList()
                UpdateFOXTable()
                InsertUpdateAdditionalShipTo()

                'Get Release Data
                Dim RowLineNumber, RowShipmentNumber As Integer
                Dim RowReleaseDate, RowPromiseDate As String
                Dim RowReleaseQuantity, RowExtendedAmount, RowLineWeight As Double
                Dim RowStatus As String = ""

                Dim RowIndex As Integer = Me.dgvFOXReleaseSchedule.CurrentCell.RowIndex

                Try
                    RowLineNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseLineNumberColumn").Value
                Catch ex As Exception
                    RowLineNumber = 0
                End Try
                Try
                    RowReleaseDate = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseDateColumn").Value
                Catch ex As Exception
                    RowReleaseDate = TodaysDate
                End Try
                Try
                    RowPromiseDate = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("PromiseDateColumn").Value
                Catch ex As Exception
                    RowPromiseDate = TodaysDate
                End Try
                Try
                    RowReleaseQuantity = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ReleaseQuantityColumn").Value
                Catch ex As Exception
                    RowReleaseQuantity = 0
                End Try
                Try
                    RowStatus = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("StatusColumn").Value
                Catch ex As Exception
                    RowStatus = ""
                End Try
                Try
                    RowShipmentNumber = Me.dgvFOXReleaseSchedule.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
                Catch ex As Exception
                    RowShipmentNumber = 0
                End Try

                If RowStatus = "SHIPPED" Then
                    MsgBox("This release has already shipped complete. Please select another release.", MsgBoxStyle.OkOnly)
                    Exit Sub
                    'ElseIf RowStatus = "PENDING" Then
                    '    MsgBox("This release is pending. Please select another release.", MsgBoxStyle.OkOnly)
                    '    Exit Sub
                Else
                    RowExtendedAmount = RowReleaseQuantity * Val(txtQuotedPrice.Text)
                    RowExtendedAmount = Math.Round(RowExtendedAmount, 2)

                    RowLineWeight = RowReleaseQuantity * Val(txtPieceWeight.Text)
                    RowLineWeight = Math.Round(RowLineWeight, 1)

                    UpdateSalesOrderFromFOX()
                    InsertUpdateAdditionalShipTo()
                    '***************************************************************************************************************************
                    'Get Part Comment from item list if available
                    Dim PartComment As String = ""

                    Dim PartCommentString As String = "SELECT Comments FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim PartCommentCommand As New SqlCommand(PartCommentString, con)
                    PartCommentCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                    PartCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PartComment = CStr(PartCommentCommand.ExecuteScalar)
                    Catch ex As Exception
                        PartComment = ""
                    End Try
                    con.Close()
                    '***************************************************************************************************************************
                    If RowShipmentNumber = 0 Then 'Create New Shipment
                        Dim DeclaredValue As Double = 0
                        Dim DeclaredValueAdded As String = ""

                        If (cboShipVia.Text.StartsWith("UPS-") Or cboShipVia.Text.StartsWith("FDX-")) And RowExtendedAmount > 101 Then
                            DeclaredValue = RowExtendedAmount
                            DeclaredValueAdded = "Y"
                        Else
                            DeclaredValue = 0
                            DeclaredValueAdded = "N"
                        End If

                        'Use new Batch Number for current selection
                        Dim PLBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM PickListHeaderTable"
                        Dim PLBatchNumberCommand As New SqlCommand(PLBatchNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastPickBatchNumber = CInt(PLBatchNumberCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            LastPickBatchNumber = 874000000
                        End Try
                        con.Close()

                        NextPickBatchNumber = LastPickBatchNumber + 1
                        '****************************************************************************************************
                        'Create new Pick Ticket Number
                        Dim PickTicketNumberStatement As String = "SELECT MAX(PickListHeaderKey) FROM PickListHeaderTable"
                        Dim PickTicketNumberCommand As New SqlCommand(PickTicketNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastTransactionNumber = CInt(PickTicketNumberCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            LastTransactionNumber = 660000
                        End Try
                        con.Close()

                        NextTransactionNumber = LastTransactionNumber + 1
                        '****************************************************************************************************
                        If txtSTName.Text = "" Or txtSTName.Text = "DEFAULT SHIP TO" Or txtSTName.Text = "" Then
                            ShipToName = cboCustomerName.Text
                        Else
                            ShipToName = txtSTName.Text
                        End If

                        'Write Data to Pick Ticket Header Database Table
                        cmd = New SqlCommand("Insert Into PickListHeaderTable(PickListHeaderKey, SalesOrderHeaderKey, PickDate, DivisionID, Comment, PLStatus, CustomerID, CustomerPO, ShipVia, AdditionalShipTo, BatchNumber, PRONumber, SalesmanID, SpecialInstructions, ShipDate, PickCount, RunningCount, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3, DeclaredValue, DeclaredValueAdded) Values (@PickListHeaderKey, @SalesOrderHeaderKey, @PickDate, @DivisionID, @Comment, @PLStatus, @CustomerID, @CustomerPO, @ShipVia, @AdditionalShipTo, @BatchNumber, @PRONumber, @SalesmanID, @SpecialInstructions, @ShipDate, @PickCount, @RunningCount, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3, @DeclaredValue, @DeclaredValueAdded)", con)

                        With cmd.Parameters
                            .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@SalesOrderHeaderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                            .Add("@PickDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = ""
                            .Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                            .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = NextPickBatchNumber
                            .Add("@PRONumber", SqlDbType.VarChar).Value = ""
                            .Add("@SalesmanID", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text + " -- " + PartComment
                            .Add("@ShipDate", SqlDbType.VarChar).Value = RowReleaseDate
                            .Add("@PickCount", SqlDbType.VarChar).Value = 1
                            .Add("@RunningCount", SqlDbType.VarChar).Value = 0
                            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                            .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                            .Add("@ShipToCity", SqlDbType.VarChar).Value = txtSTCity.Text
                            .Add("@ShipToState", SqlDbType.VarChar).Value = cboSTState.Text
                            .Add("@ShipToZip", SqlDbType.VarChar).Value = txtSTZip.Text
                            .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtSTCountry.Text
                            .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
                            .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
                            .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
                            .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
                            .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
                            .Add("@DeclaredValue", SqlDbType.VarChar).Value = DeclaredValue
                            .Add("@DeclaredValueAdded", SqlDbType.VarChar).Value = DeclaredValueAdded
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        GlobalPickListNumber = NextTransactionNumber
                        '****************************************************************************************************
                        'Write Data to Pick Ticket Line Database Table
                        cmd = New SqlCommand("Insert Into PickListLineTable(PickListHeaderKey, PickListLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, GLDebitAccount, GLCreditAccount, CertificationType, SOLineNumber, SerialNumber, QOH) Values (@PickListHeaderKey, @PickListLineKey, @ItemID, @Description, @Quantity, @Price, @SalesTax, @ExtendedAmount, @LineComment, @LineStatus, @DivisionID, @LineWeight, @LineBoxes, @GLDebitAccount, @GLCreditAccount, @CertificationType, @SOLineNumber, @SerialNumber, @QOH)", con)

                        With cmd.Parameters
                            .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@PickListLineKey", SqlDbType.VarChar).Value = 1
                            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@Description", SqlDbType.VarChar).Value = cboPartDescription.Text
                            .Add("@Quantity", SqlDbType.VarChar).Value = RowReleaseQuantity
                            .Add("@Price", SqlDbType.VarChar).Value = Val(txtQuotedPrice.Text)
                            .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = RowExtendedAmount
                            .Add("@LineComment", SqlDbType.VarChar).Value = ""
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@LineWeight", SqlDbType.VarChar).Value = RowLineWeight
                            .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "49999"
                            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12500"
                            .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                            .Add("@SOLineNumber", SqlDbType.VarChar).Value = 1
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                            .Add("@QOH", SqlDbType.VarChar).Value = TWDQuantityOnHand
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '****************************************************************************************************
                        Dim ShipmentBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM ShipmentHeaderTable"
                        Dim ShipmentBatchNumberCommand As New SqlCommand(ShipmentBatchNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ShipmentBatchNumber = CInt(ShipmentBatchNumberCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            ShipmentBatchNumber = 880000000
                        End Try
                        con.Close()

                        NextBatchNumber = ShipmentBatchNumber + 1
                        '****************************************************************************************************
                        'Create new Shipment Number
                        Dim ShipmentNumberStatement As String = "SELECT MAX(ShipmentNumber) FROM ShipmentHeaderTable"
                        Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            LastShipmentNumber = 4560000
                        End Try
                        con.Close()

                        NextShipmentNumber = LastShipmentNumber + 1
                        '****************************************************************************************************
                        'Write Data to Shipment Header Table
                        cmd = New SqlCommand("Insert Into ShipmentHeaderTable(ShipmentNumber, SalesOrderKey, ShipDate, DivisionID, Comment, PickTicketNumber, ShipVia, PRONumber, FreightQuoteNumber, FreightQuoteAmount, FreightActualAmount, ShippingWeight, NumberOfPallets, CustomerID, ShipToID, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, CustomerPO, ShipmentStatus, ProductTotal, TaxTotal, ShipmentTotal, BatchNumber, SalesmanID, SpecialInstructions, Tax2Total, Tax3Total, CertsAutoGenerated, SOLog, PulledBy, CertsPulled, PackingSlip, Locked, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper, ShipToName, ShippingAccount, ShipEmail, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3) Values (@ShipmentNumber, @SalesOrderKey, @ShipDate, @DivisionID, @Comment, @PickTicketNumber, @ShipVia, @PRONumber, @FreightQuoteNumber, @FreightQuoteAmount, @FreightActualAmount, @ShippingWeight, @NumberOfPallets, @CustomerID, @ShipToID, @ShipAddress1, @ShipAddress2, @ShipCity, @ShipState, @ShipZip, @ShipCountry, @CustomerPO, @ShipmentStatus, @ProductTotal, @TaxTotal, @ShipmentTotal, @BatchNumber, @SalesmanID, @SpecialInstructions, @Tax2Total, @Tax3Total, @CertsAutoGenerated, @SOLog, @PulledBy, @CertsPulled, @PackingSlip, @Locked, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShippingAccount, @ShipEmail, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3)", con)

                        With cmd.Parameters
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                            .Add("@ShipDate", SqlDbType.VarChar).Value = RowReleaseDate
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = ""
                            .Add("@PickTicketNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                            .Add("@PRONumber", SqlDbType.VarChar).Value = ""
                            .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = ""
                            .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = 0
                            .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                            .Add("@ShippingWeight", SqlDbType.VarChar).Value = RowLineWeight
                            .Add("@NumberOfPallets", SqlDbType.VarChar).Value = 1
                            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                            .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                            .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                            .Add("@ShipCity", SqlDbType.VarChar).Value = txtSTCity.Text
                            .Add("@ShipState", SqlDbType.VarChar).Value = cboSTState.Text
                            .Add("@ShipZip", SqlDbType.VarChar).Value = txtSTZip.Text
                            .Add("@ShipCountry", SqlDbType.VarChar).Value = txtSTCountry.Text
                            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                            .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = RowExtendedAmount
                            .Add("@TaxTotal", SqlDbType.VarChar).Value = 0
                            .Add("@ShipmentTotal", SqlDbType.VarChar).Value = RowExtendedAmount
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                            .Add("@SalesmanID", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                            .Add("@Tax2Total", SqlDbType.VarChar).Value = 0
                            .Add("@Tax3Total", SqlDbType.VarChar).Value = 0
                            .Add("@CertsAutoGenerated", SqlDbType.VarChar).Value = ""
                            .Add("@SOLog", SqlDbType.VarChar).Value = ""
                            .Add("@PulledBy", SqlDbType.VarChar).Value = ""
                            .Add("@CertsPulled", SqlDbType.VarChar).Value = ""
                            .Add("@PackingSlip", SqlDbType.VarChar).Value = ""
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@CustomerClass", SqlDbType.VarChar).Value = "STANDARD"
                            .Add("@FOB", SqlDbType.VarChar).Value = "Medina"
                            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                            .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                            .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
                            .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
                            .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
                            .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
                            .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '****************************************************************************************************
                        'Write Pick List Line data to Shipment Line Table
                        cmd = New SqlCommand("Insert Into ShipmentLineTable(ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, GLDebitAccount, GLCreditAccount, CertificationType, ExtendedCOS, SOLineNumber, SerialNumber, Dropship, BoxWeight) Values (@ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @GLDebitAccount, @GLCreditAccount, @CertificationType, @ExtendedCOS, @SOLineNumber, @SerialNumber, @Dropship, @BoxWeight)", con)

                        With cmd.Parameters
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = 1
                            .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                            .Add("@QuantityShipped", SqlDbType.VarChar).Value = RowReleaseQuantity
                            .Add("@Price", SqlDbType.VarChar).Value = Val(txtQuotedPrice.Text)
                            .Add("@LineComment", SqlDbType.VarChar).Value = ""
                            .Add("@LineWeight", SqlDbType.VarChar).Value = RowLineWeight
                            .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                            .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = RowExtendedAmount
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "49999"
                            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12500"
                            .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                            .Add("@ExtendedCOS", SqlDbType.VarChar).Value = 0
                            .Add("@SOLineNumber", SqlDbType.VarChar).Value = 1
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                            .Add("@Dropship", SqlDbType.VarChar).Value = "NO"
                            .Add("@BoxWeight", SqlDbType.VarChar).Value = 0
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '***************************************************************************************************
                        'Check PPAP and Tooling Charges to add
                        If chkAddPPAP.Checked = True Then
                            'Add PPAP to Sales Order Line Table
                            Dim MaxSOLineNumber As Integer = 0

                            Dim MaxSOLineNumberStatement As String = "SELECT MAX(SalesOrderLineKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                            Dim MaxSOLineNumberCommand As New SqlCommand(MaxSOLineNumberStatement, con)
                            MaxSOLineNumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                            MaxSOLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxSOLineNumber = CInt(MaxSOLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                MaxSOLineNumber = 1
                            End Try
                            con.Close()

                            Try
                                'Write Data to SO Line Database Table
                                cmd = New SqlCommand("Insert Into SalesOrderLineTable(SalesOrderKey, SalesOrderLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, DebitGLAccount, CreditGLAccount, LeadTime, CertificationType, EstExtendedCOS) Values (@SalesOrderKey, @SalesOrderLineKey, @ItemID, @Description, @Quantity, @Price, @SalesTax, @ExtendedAmount, @LineComment, @LineStatus, @DivisionID, @LineWeight, @LineBoxes, @DebitGLAccount, @CreditGLAccount, @LeadTime, @CertificationType, @EstExtendedCOS)", con)

                                With cmd.Parameters
                                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = MaxSOLineNumber + 1
                                    .Add("@ItemID", SqlDbType.VarChar).Value = "PPAP CHARGE"
                                    .Add("@Description", SqlDbType.VarChar).Value = "PPAP CHARGE"
                                    .Add("@Quantity", SqlDbType.VarChar).Value = 1
                                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtAddPPAP.Text)
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtAddPPAP.Text)
                                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "49999"
                                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = "12500"
                                    .Add("@LeadTime", SqlDbType.VarChar).Value = ""
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertType.Text
                                    .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = 0
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Error Log
                            End Try
                            '***************************************************************************************************
                            'Add PPAP to Pick List Line Table
                            'Get MAX Line Number
                            Dim MaxPickLineNumber As Integer = 0

                            Dim MaxPickLineNumberStatement As String = "SELECT MAX(PickListLineKey) FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
                            Dim MaxPickLineNumberCommand As New SqlCommand(MaxPickLineNumberStatement, con)
                            MaxPickLineNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            MaxPickLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxPickLineNumber = CInt(MaxPickLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                MaxPickLineNumber = 1
                            End Try
                            con.Close()

                            Try
                                'Write Data to Pick Ticket Line Database Table
                                cmd = New SqlCommand("Insert Into PickListLineTable(PickListHeaderKey, PickListLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, GLDebitAccount, GLCreditAccount, CertificationType, SOLineNumber, SerialNumber, QOH) Values (@PickListHeaderKey, @PickListLineKey, @ItemID, @Description, @Quantity, @Price, @SalesTax, @ExtendedAmount, @LineComment, @LineStatus, @DivisionID, @LineWeight, @LineBoxes, @GLDebitAccount, @GLCreditAccount, @CertificationType, @SOLineNumber, @SerialNumber, @QOH)", con)

                                With cmd.Parameters
                                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = MaxPickLineNumber + 1
                                    .Add("@ItemID", SqlDbType.VarChar).Value = "PPAP CHARGE"
                                    .Add("@Description", SqlDbType.VarChar).Value = "PPAP CHARGE"
                                    .Add("@Quantity", SqlDbType.VarChar).Value = 1
                                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtAddPPAP.Text)
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtAddPPAP.Text)
                                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "49999"
                                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12500"
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = MaxSOLineNumber + 1
                                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                    .Add("@QOH", SqlDbType.VarChar).Value = 0
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Error Log
                            End Try
                            '***************************************************************************************************
                            'Add PPAP to Shipment Line Table

                            'Get MAX Line Number
                            Dim MaxLineNumber As Integer = 0

                            Dim MaxLineNumberStatement As String = "SELECT MAX(ShipmentLineNumber) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                            Dim MaxLineNumberCommand As New SqlCommand(MaxLineNumberStatement, con)
                            MaxLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            MaxLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxLineNumber = CInt(MaxLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                MaxLineNumber = 1
                            End Try
                            con.Close()

                            Try
                                'Write PPAP Line data to Shipment Line Table
                                cmd = New SqlCommand("Insert Into ShipmentLineTable(ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, GLDebitAccount, GLCreditAccount, CertificationType, ExtendedCOS, SOLineNumber, SerialNumber, Dropship, BoxWeight) Values (@ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @GLDebitAccount, @GLCreditAccount, @CertificationType, @ExtendedCOS, @SOLineNumber, @SerialNumber, @Dropship, @BoxWeight)", con)

                                With cmd.Parameters
                                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = MaxLineNumber + 1
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = "PPAP CHARGE"
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = "PPAP CHARGE"
                                    .Add("@QuantityShipped", SqlDbType.VarChar).Value = 1
                                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtAddPPAP.Text)
                                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtAddPPAP.Text)
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "49999"
                                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12500"
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = 0
                                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = MaxSOLineNumber + 1
                                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                    .Add("@Dropship", SqlDbType.VarChar).Value = "NO"
                                    .Add("@BoxWeight", SqlDbType.VarChar).Value = 0
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Error Log
                            End Try
                        Else
                            'Skip
                        End If
                        '****************************************************************************************************
                        'Add Expedite Charge to Pick Ticket and Shipment
                        If chkAddExpedite.Checked = True Then
                            'Add EXPEDITE to Sales Order Line Table
                            Dim MaxSOLineNumber As Integer = 0

                            Dim MaxSOLineNumberStatement As String = "SELECT MAX(SalesOrderLineKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                            Dim MaxSOLineNumberCommand As New SqlCommand(MaxSOLineNumberStatement, con)
                            MaxSOLineNumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                            MaxSOLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxSOLineNumber = CInt(MaxSOLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                MaxSOLineNumber = 1
                            End Try
                            con.Close()

                            Try
                                'Write Data to SO Line Database Table
                                cmd = New SqlCommand("Insert Into SalesOrderLineTable(SalesOrderKey, SalesOrderLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, DebitGLAccount, CreditGLAccount, LeadTime, CertificationType, EstExtendedCOS) Values (@SalesOrderKey, @SalesOrderLineKey, @ItemID, @Description, @Quantity, @Price, @SalesTax, @ExtendedAmount, @LineComment, @LineStatus, @DivisionID, @LineWeight, @LineBoxes, @DebitGLAccount, @CreditGLAccount, @LeadTime, @CertificationType, @EstExtendedCOS)", con)

                                With cmd.Parameters
                                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = MaxSOLineNumber + 1
                                    .Add("@ItemID", SqlDbType.VarChar).Value = "EXPEDITE"
                                    .Add("@Description", SqlDbType.VarChar).Value = "EXPEDITE CHARGE"
                                    .Add("@Quantity", SqlDbType.VarChar).Value = 1
                                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtAddExpedite.Text)
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtAddExpedite.Text)
                                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "49999"
                                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = "12500"
                                    .Add("@LeadTime", SqlDbType.VarChar).Value = "  /  /"
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertType.Text
                                    .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = 0
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Error Log
                            End Try
                            '***************************************************************************************************
                            'Add EXPEDITE to Pick List Line Table
                            'Get MAX Line Number
                            Dim MaxPickLineNumber As Integer = 0

                            Dim MaxPickLineNumberStatement As String = "SELECT MAX(PickListLineKey) FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
                            Dim MaxPickLineNumberCommand As New SqlCommand(MaxPickLineNumberStatement, con)
                            MaxPickLineNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            MaxPickLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxPickLineNumber = CInt(MaxPickLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                MaxPickLineNumber = 1
                            End Try
                            con.Close()

                            Try
                                'Write Data to Pick Ticket Line Database Table
                                cmd = New SqlCommand("Insert Into PickListLineTable(PickListHeaderKey, PickListLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, GLDebitAccount, GLCreditAccount, CertificationType, SOLineNumber, SerialNumber, QOH) Values (@PickListHeaderKey, @PickListLineKey, @ItemID, @Description, @Quantity, @Price, @SalesTax, @ExtendedAmount, @LineComment, @LineStatus, @DivisionID, @LineWeight, @LineBoxes, @GLDebitAccount, @GLCreditAccount, @CertificationType, @SOLineNumber, @SerialNumber, @QOH)", con)

                                With cmd.Parameters
                                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = MaxPickLineNumber + 1
                                    .Add("@ItemID", SqlDbType.VarChar).Value = "EXPEDITE"
                                    .Add("@Description", SqlDbType.VarChar).Value = "EXPEDITE CHARGE"
                                    .Add("@Quantity", SqlDbType.VarChar).Value = 1
                                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtAddExpedite.Text)
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtAddExpedite.Text)
                                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "49999"
                                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12500"
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = MaxSOLineNumber + 1
                                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                    .Add("@QOH", SqlDbType.VarChar).Value = 0
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Error Log
                            End Try
                            '***************************************************************************************************
                            'Add EXPEDITE to Shipment Line Table

                            'Get MAX Line Number
                            Dim MaxLineNumber As Integer = 0

                            Dim MaxLineNumberStatement As String = "SELECT MAX(ShipmentLineNumber) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                            Dim MaxLineNumberCommand As New SqlCommand(MaxLineNumberStatement, con)
                            MaxLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            MaxLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxLineNumber = CInt(MaxLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                MaxLineNumber = 1
                            End Try
                            con.Close()

                            Try
                                'Write PPAP Line data to Shipment Line Table
                                cmd = New SqlCommand("Insert Into ShipmentLineTable(ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, GLDebitAccount, GLCreditAccount, CertificationType, ExtendedCOS, SOLineNumber, SerialNumber, Dropship, BoxWeight) Values (@ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @GLDebitAccount, @GLCreditAccount, @CertificationType, @ExtendedCOS, @SOLineNumber, @SerialNumber, @Dropship, @BoxWeight)", con)

                                With cmd.Parameters
                                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = MaxLineNumber + 1
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = "EXPEDITE"
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = "EXPEDITE CHARGE"
                                    .Add("@QuantityShipped", SqlDbType.VarChar).Value = 1
                                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtAddExpedite.Text)
                                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtAddExpedite.Text)
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "49999"
                                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12500"
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = 0
                                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = MaxSOLineNumber + 1
                                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                    .Add("@Dropship", SqlDbType.VarChar).Value = "NO"
                                    .Add("@BoxWeight", SqlDbType.VarChar).Value = 0
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Error Log
                            End Try
                        Else
                            'Skip
                        End If
                        '****************************************************************************************************
                        'Check Tooling Charges to add
                        If chkAddTooling.Checked = True Then
                            'Add Tooling to Sales Order Line Table
                            Dim MaxSOLineNumber As Integer = 0

                            Dim MaxSOLineNumberStatement As String = "SELECT MAX(SalesOrderLineKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                            Dim MaxSOLineNumberCommand As New SqlCommand(MaxSOLineNumberStatement, con)
                            MaxSOLineNumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                            MaxSOLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxSOLineNumber = CInt(MaxSOLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                MaxSOLineNumber = 1
                            End Try
                            con.Close()

                            Try
                                'Write Data to Pick Ticket Line Database Table
                                cmd = New SqlCommand("Insert Into SalesOrderLineTable(SalesOrderKey, SalesOrderLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, DebitGLAccount, CreditGLAccount, LeadTime, CertificationType, EstExtendedCOS) Values (@SalesOrderKey, @SalesOrderLineKey, @ItemID, @Description, @Quantity, @Price, @SalesTax, @ExtendedAmount, @LineComment, @LineStatus, @DivisionID, @LineWeight, @LineBoxes, @DebitGLAccount, @CreditGLAccount, @LeadTime, @CertificationType, @EstExtendedCOS)", con)

                                With cmd.Parameters
                                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = MaxSOLineNumber + 1
                                    .Add("@ItemID", SqlDbType.VarChar).Value = "TOOLING CHARGE"
                                    .Add("@Description", SqlDbType.VarChar).Value = "TOOLING CHARGE"
                                    .Add("@Quantity", SqlDbType.VarChar).Value = 1
                                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtAddTooling.Text)
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtAddTooling.Text)
                                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "49999"
                                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = "12500"
                                    .Add("@LeadTime", SqlDbType.VarChar).Value = "  /  /"
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertType.Text
                                    .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = 0
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Error Log
                            End Try
                            '***************************************************************************************************
                            'Add Tooling to Pick List Line Table
                            'Get MAX Line Number
                            Dim MaxPickLineNumber As Integer = 0

                            Dim MaxPickLineNumberStatement As String = "SELECT MAX(PickListLineKey) FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
                            Dim MaxPickLineNumberCommand As New SqlCommand(MaxPickLineNumberStatement, con)
                            MaxPickLineNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            MaxPickLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxPickLineNumber = CInt(MaxPickLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                MaxPickLineNumber = 1
                            End Try
                            con.Close()

                            Try
                                'Write Data to Pick Ticket Line Database Table
                                cmd = New SqlCommand("Insert Into PickListLineTable(PickListHeaderKey, PickListLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, GLDebitAccount, GLCreditAccount, CertificationType, SOLineNumber, SerialNumber, QOH) Values (@PickListHeaderKey, @PickListLineKey, @ItemID, @Description, @Quantity, @Price, @SalesTax, @ExtendedAmount, @LineComment, @LineStatus, @DivisionID, @LineWeight, @LineBoxes, @GLDebitAccount, @GLCreditAccount, @CertificationType, @SOLineNumber, @SerialNumber, @QOH)", con)

                                With cmd.Parameters
                                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = MaxPickLineNumber + 1
                                    .Add("@ItemID", SqlDbType.VarChar).Value = "TOOLING CHARGE"
                                    .Add("@Description", SqlDbType.VarChar).Value = "TOOLING CHARGE"
                                    .Add("@Quantity", SqlDbType.VarChar).Value = 1
                                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtAddTooling.Text)
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtAddTooling.Text)
                                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "49999"
                                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12500"
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = MaxSOLineNumber + 1
                                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                    .Add("@QOH", SqlDbType.VarChar).Value = 0
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Error Log
                            End Try
                            '***************************************************************************************************
                            'Add Tooling to Shipment Line Table

                            'Get MAX Line Number
                            Dim MaxLineNumber As Integer = 0

                            Dim MaxLineNumberStatement As String = "SELECT MAX(ShipmentLineNumber) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                            Dim MaxLineNumberCommand As New SqlCommand(MaxLineNumberStatement, con)
                            MaxLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            MaxLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxLineNumber = CInt(MaxLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                MaxLineNumber = 1
                            End Try
                            con.Close()

                            Try
                                'Write PPAP Line data to Shipment Line Table
                                cmd = New SqlCommand("Insert Into ShipmentLineTable(ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, GLDebitAccount, GLCreditAccount, CertificationType, ExtendedCOS, SOLineNumber, SerialNumber, Dropship, BoxWeight) Values (@ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @GLDebitAccount, @GLCreditAccount, @CertificationType, @ExtendedCOS, @SOLineNumber, @SerialNumber, @Dropship, @BoxWeight)", con)

                                With cmd.Parameters
                                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = MaxLineNumber + 1
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = "TOOLING CHARGE"
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = "TOOLING CHARGE"
                                    .Add("@QuantityShipped", SqlDbType.VarChar).Value = 1
                                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtAddTooling.Text)
                                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtAddTooling.Text)
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "49999"
                                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12500"
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = 0
                                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = MaxSOLineNumber + 1
                                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                    .Add("@Dropship", SqlDbType.VarChar).Value = "NO"
                                    .Add("@BoxWeight", SqlDbType.VarChar).Value = 0
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Error Log
                            End Try
                        Else
                            'Skip
                        End If

                        CurrentShipmentNumber = NextShipmentNumber
                        GlobalPickListNumber = NextTransactionNumber
                    Else
                        'If Shipment Exists, update shipment if it is pending.
                        Dim CheckShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                        Dim CheckShipmentStatusCommand As New SqlCommand(CheckShipmentStatusStatement, con)
                        CheckShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                        CheckShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CheckShipmentStatus = CStr(CheckShipmentStatusCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            CheckShipmentStatus = "SHIPPED"
                        End Try
                        con.Close()

                        If CheckShipmentStatus = "SHIPPED" Then
                            MsgBox("Shipment has already been completed for this release. Create a new release and try again.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        Else
                            '***************************************************************************************************************************
                            Dim GetPickNumberStatement As String = "SELECT PickTicketNumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                            Dim GetPickNumberCommand As New SqlCommand(GetPickNumberStatement, con)
                            GetPickNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                            GetPickNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetPickNumber = CInt(GetPickNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                GetPickNumber = 0
                            End Try
                            con.Close()

                            GlobalPickListNumber = GetPickNumber
                            '********************************************************************************************
                            'Update Picklist Header Table and Line Table
                            cmd = New SqlCommand("UPDATE PickListHeaderTable SET PickDate = @PickDate, ShipVia = @ShipVia, AdditionalShipTo = @AdditionalShipTo, CustomerPO = @CustomerPO, SpecialInstructions = @SpecialInstructions, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShipToAddress1 = @ShipToAddress1, ShipToAddress2 = @ShipToAddress2, ShipToCity = @ShipToCity, ShipToState = @ShipToState, ShipToZip = @ShipToZip, ShipToCountry = @ShipToCountry, ShippingAccount = @ShippingAccount, ShipEmail = @ShipEmail WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GetPickNumber
                                .Add("@PickDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                                .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text + " -- " + PartComment
                                .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                                .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                                .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                                .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                                .Add("@ShipToCity", SqlDbType.VarChar).Value = txtSTCity.Text
                                .Add("@ShipToState", SqlDbType.VarChar).Value = cboSTState.Text
                                .Add("@ShipToZip", SqlDbType.VarChar).Value = txtSTZip.Text
                                .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtSTCountry.Text
                                .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
                                .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'UPDATE PL Line Table
                            cmd = New SqlCommand("UPDATE PickListLineTable SET Quantity = @Quantity, QOH = @QOH WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey", con)

                            With cmd.Parameters
                                .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GetPickNumber
                                .Add("@PickListLineKey", SqlDbType.VarChar).Value = 1
                                .Add("@Quantity", SqlDbType.VarChar).Value = RowReleaseQuantity
                                .Add("@QOH", SqlDbType.VarChar).Value = TWDQuantityOnHand
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            GlobalPickListNumber = GetPickNumber

                            'UPDATE PL Line Table
                            cmd = New SqlCommand("UPDATE PickListLineTable SET ExtendedAmount = Quantity * Price WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey", con)

                            With cmd.Parameters
                                .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GetPickNumber
                                .Add("@PickListLineKey", SqlDbType.VarChar).Value = 1
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                            '*********************************************************************************************
                            'Update Shipment Header Table and Shipment Line Table
                            cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipDate = @ShipDate, ShipVia = @ShipVia, FreightActualAmount = @FreightActualAmount, ShipToID = @ShipToID, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, CustomerPO = @CustomerPO, SpecialInstructions = @SpecialInstructions, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShippingAccount = @ShippingAccount, ShipEmail = @ShipEmail WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                .Add("@ShipDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                                .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                                .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                                .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                                .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                                .Add("@ShipCity", SqlDbType.VarChar).Value = txtSTCity.Text
                                .Add("@ShipState", SqlDbType.VarChar).Value = cboSTState.Text
                                .Add("@ShipZip", SqlDbType.VarChar).Value = txtSTZip.Text
                                .Add("@ShipCountry", SqlDbType.VarChar).Value = txtSTCountry.Text
                                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                                .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                                .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                                .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
                                .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'UPDATE SL Line Table
                            cmd = New SqlCommand("UPDATE ShipmentLineTable SET QuantityShipped = @QuantityShipped WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                            With cmd.Parameters
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                                .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = 1
                                .Add("@QuantityShipped", SqlDbType.VarChar).Value = RowReleaseQuantity
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'UPDATE SL Line Table
                            cmd = New SqlCommand("UPDATE ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                            With cmd.Parameters
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                                .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = 1
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            CurrentShipmentNumber = RowShipmentNumber
                            '*********************************************************************************************
                        End If
                    End If
                    '****************************************************************************************************
                    'Update Shipment Totals
                    Dim SumLineTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                    Dim SumLineTotalCommand As New SqlCommand(SumLineTotalStatement, con)
                    SumLineTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = CurrentShipmentNumber
                    SumLineTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SumLineTotal = CDbl(SumLineTotalCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        SumLineTotal = 0
                    End Try
                    con.Close()
                    '****************************************************************************************************
                    'Update header with totals
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = CurrentShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = SumLineTotal
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '****************************************************************************************************
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = CurrentShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '****************************************************************************************************
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus, ShippingDate = @ShippingDate WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetSONumber
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@SOStatus", SqlDbType.VarChar).Value = "SHIPPED"
                        .Add("@ShippingDate", SqlDbType.VarChar).Value = dtpReleaseDate.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '****************************************************************************************************
                    'Update release to show pending quantity shipped
                    'Write Data to Pick Ticket Header Database Table
                    cmd = New SqlCommand("UPDATE FOXReleaseSchedule SET ShippedQuantity = @ShippedQuantity, ShipDate = @ShipDate, Status = @Status, ShipmentNumber = @ShipmentNumber WHERE FOXNumber = @FOXNumber AND ReleaseLineNumber = @ReleaseLineNumber", con)

                    With cmd.Parameters
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                        .Add("@ReleaseLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                        .Add("@ShippedQuantity", SqlDbType.VarChar).Value = RowReleaseQuantity
                        .Add("@ShipDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@Status", SqlDbType.VarChar).Value = "PENDING"
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = CurrentShipmentNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear Check Boxes and Fields
                    chkAddPPAP.Checked = False
                    chkAddTooling.Checked = False
                    txtAddPPAP.Clear()
                    txtAddTooling.Clear()

                    MsgBox("Pick Ticket and Pending Shipment created.", MsgBoxStyle.OkOnly)

                    Dim button1 As DialogResult = MessageBox.Show("Do you wish to print the Pick Ticket?", "PRINT PICK TICKET", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button1 = DialogResult.Yes Then
                        GlobalDivisionCode = cboDivisionID.Text

                        Using NewPrintPickTicketsAuto As New PrintPickTicketsAuto
                            Dim result = NewPrintPickTicketsAuto.ShowDialog()
                        End Using
                    ElseIf button1 = DialogResult.No Then
                        'Skip Printing Pick Ticket
                    End If

                    LoadSalesOrderData()
                    ShowReleases()
                End If
            ElseIf button = DialogResult.No Then
                cmdExpediteRelease.Focus()
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboFOXNumber.Text = "" Then
            MsgBox("You must have a valid FOX Number selected.", MsgBoxStyle.OkOnly)
        Else
            If Not isSomeoneEditing() Then
                ValidateSteelInFOX()

                If IsSteelTypeValid = "INVALID STEEL" Then
                    MsgBox("Scheduled/Alternate Steel is either closed or does not exist.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If

                Try
                    UpdateFOXTable()
                    UpdateFOXInItemList()
                    UpdateSalesOrderFromFOX()

                    If CheckShippingMethod = "EXIT SUB" Then
                        MsgBox("You must select a valid shipping Method.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    InsertUpdateAdditionalShipTo()
                    LoadSalesOrderData()
                Catch ex As Exception
                    MessageBox.Show("There was a problem saving the data. Contact system admin", "Unable to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
                'Show FOX Processes
                ShowProcesses()
            End If

            GlobalFOXNumber = Val(cboFOXNumber.Text)
            GlobalDivisionCode = cboDivisionID.Text
            Using NewPrintFOX As New PrintFOX
                Dim result = NewPrintFOX.ShowDialog()
            End Using
            needsSaved = False
        End If
    End Sub

    Private Sub cmdDeleteQCCertification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteFOXCertification.Click
        If dgvFOXCertifications.CurrentCell IsNot Nothing Then
            Dim row As Integer = dgvFOXCertifications.CurrentCell.RowIndex
            cmd = New SqlCommand("DELETE FOXCertifications WHERE FOXNumber = @FOXNumber and Certification = @Certification", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
            cmd.Parameters.Add("@Certification", SqlDbType.VarChar).Value = dgvFOXCertifications.Rows(row).Cells("Certification").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            LoadFOXCertifications()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Form Logout Routine
        FormLogoutRoutine()

        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            If needsSaved Then
                If Not isSomeoneEditing() Then
                    'Prompt before saving
                    Dim button As DialogResult = MessageBox.Show("Do you wish to save this FOX Data?", "SAVE DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button = DialogResult.Yes Then
                        Try
                            UpdateFOXTable()
                            UpdateFOXInItemList()
                            UpdateSalesOrderFromFOX()

                            If CheckShippingMethod = "EXIT SUB" Then
                                MsgBox("You must select a valid shipping Method.", MsgBoxStyle.OkOnly)
                                Exit Sub
                            End If

                            InsertUpdateAdditionalShipTo()
                        Catch ex As Exception
                            MessageBox.Show("There was a problem saving the data. Check the data and try again. If problem persists contact system admin", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End Try
                    End If
                End If
            End If
            unlockBatch()
        End If
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdDeleteOutside_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteOutside.Click
        If canDeleteOutside() Then
            cmd = New SqlCommand("DELETE FOXOutsideOperations WHERE FOXNumber = @FOXNumber and EntryNumber = @EntryNumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
            cmd.Parameters.Add("@EntryNumber", SqlDbType.Int).Value = dgvFOXOutsideData.Rows(dgvFOXOutsideData.CurrentCell.RowIndex).Cells("EntryNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            LoadOutsideOperations()
        End If
    End Sub

    Private Sub cmdReIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReIssue.Click
        'Prompt before committing
        If canReissue() Then
            isLoaded = False
            Dim GetNewFOXNumber As Integer = 0
            Dim NextFOXNumber As Integer = 0

            'Create new Shipment Number
            Dim GetNewFOXNumberStatement As String = "SELECT MAX(FOXNumber)+ 1 FROM FOXTable WHERE DivisionID = @DivisionID"
            Dim GetNewFOXNumberCommand As New SqlCommand(GetNewFOXNumberStatement, con)
            GetNewFOXNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetNewFOXNumber = CInt(GetNewFOXNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetNewFOXNumber = 9999
            End Try
            con.Close()

            NextFOXNumber = GetNewFOXNumber

            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("INSERT INTO FOXTable(FOXNumber, RMID, PartNumber, BlueprintNumber, DivisionID, RawMaterialWeight, FinishedWeight, ScrapWeight, FluxLoadNumber, CreationDate, Comments, CertificationType, Status, BoxType, CustomerID, ProductionQuantity, PromiseDate, OrderReferenceNumber, BlueprintRevision, Locked, QuoteNumber, QuotePrice, ScheduledRMID)Values(@FOXNumber, @RMID, @PartNumber, @BlueprintNumber, @DivisionID, @RawMaterialWeight, @FinishedWeight, @ScrapWeight, @FluxLoadNumber, @CreationDate, @Comments, @CertificationType, @Status, @BoxType, @CustomerID, @ProductionQuantity, @PromiseDate, @OrderReferenceNumber, @BlueprintRevision, @Locked, @QuoteNumber, @QuotePrice, @ScheduledRMID)", con)

            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.VarChar).Value = NextFOXNumber
                .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = Val(txtRawMaterialWeight.Text)
                .Add("@FinishedWeight", SqlDbType.VarChar).Value = Val(txtFinishedWeight.Text)
                .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtScrapWeight.Text)
                .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = cboFluxLoadNumber.Text
                .Add("@CreationDate", SqlDbType.VarChar).Value = dtpCreationDate.Text
                .Add("@Comments", SqlDbType.VarChar).Value = txtFOXComment.Text
                .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
                .Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
                .Add("@BoxType", SqlDbType.VarChar).Value = cboBoxType.Text
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@ProductionQuantity", SqlDbType.VarChar).Value = 0
                .Add("@PromiseDate", SqlDbType.Date).Value = dtpFOXPromiseDate.Value
                .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = 0
                .Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtRevisionLevel.Text
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@QuoteNumber", SqlDbType.VarChar).Value = ""
                .Add("@QuotePrice", SqlDbType.VarChar).Value = 0
                .Add("@ScheduledRMID", SqlDbType.VarChar).Value = txtAlternateRMID.Text
            End With

            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                'Log error on update failure
                Dim TempFOXNumber As Integer = 0
                Dim strFOXNumber As String
                TempFOXNumber = NextFOXNumber
                strFOXNumber = CStr(TempFOXNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "FOX Menu --- Re-Issue FOX Failure (Insert in FOX Table)"
                ErrorReferenceNumber = "FOX # " + strFOXNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
                MsgBox("There is a problem creating this FOX. Check data and try again.", MsgBoxStyle.OkOnly)
                Exit Sub
            End Try

            'Create FOX Production Order so time slips can be posted

            'Create MAX Production Numnber
            Dim CountProductionNumber As Integer = 0
            Dim NewProductionNumber As Integer = 0
            Dim MaxProductionNumber As Integer = 0

            Dim CountProductionNumberStatement As String = "SELECT COUNT(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber"
            Dim CountProductionNumberCommand As New SqlCommand(CountProductionNumberStatement, con)
            CountProductionNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = NextFOXNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountProductionNumber = CInt(CountProductionNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                CountProductionNumber = 0
            End Try
            con.Close()

            If CountProductionNumber = 0 Then
                NewProductionNumber = 80316
            Else
                'Get Max Production Number abd create a new production order.
                Dim MaxProductionNumberStatement As String = "SELECT MAX(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber"
                Dim MaxProductionNumberCommand As New SqlCommand(MaxProductionNumberStatement, con)
                MaxProductionNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = NextFOXNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxProductionNumber = CInt(MaxProductionNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    MaxProductionNumber = 0
                End Try
                con.Close()

                NewProductionNumber = MaxProductionNumber + 1

                'Close Old Production Number
                cmd = New SqlCommand("UPDATE FOXProductionNumberHeaderTable SET Status = @Status, EndDate = @EndDate WHERE FOXNumber = @FOXNumber", con)

                With cmd.Parameters
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = NextFOXNumber
                    .Add("@EndDate", SqlDbType.VarChar).Value = Now()
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            'Insert Into Header Table
            cmd = New SqlCommand("INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status) values (@ProductionNumber, @FOXNumber, @StartDate, @ProductionQuantity, @Status)", con)

            With cmd.Parameters
                .Add("@ProductionNumber", SqlDbType.VarChar).Value = NewProductionNumber
                .Add("@FOXNumber", SqlDbType.VarChar).Value = NextFOXNumber
                .Add("@StartDate", SqlDbType.VarChar).Value = Now()
                '.Add("@EndDate", SqlDbType.VarChar).Value = ""
                .Add("@ProductionQuantity", SqlDbType.VarChar).Value = Val(txtProductionQuantity.Text)
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Dim LineProcessStep As Integer
            Dim LineProcessID, LineProcessRemoveRM, LineProcessAddFG As String

            'UPDATE Line Table on changes in the datagrid and ensure no NULL values
            For Each row As DataGridViewRow In dgvFoxProcesses.Rows
                Try
                    LineProcessStep = row.Cells("ProcessStepColumn").Value
                Catch ex As System.Exception
                    LineProcessStep = 0
                End Try
                Try
                    LineProcessID = row.Cells("ProcessIDColumn").Value
                Catch ex As System.Exception
                    LineProcessID = ""
                End Try
                Try
                    LineProcessRemoveRM = row.Cells("ProcessRemoveRMColumn").Value
                Catch ex As System.Exception
                    LineProcessRemoveRM = ""
                End Try
                Try
                    LineProcessAddFG = row.Cells("ProcessAddFGColumn").Value
                Catch ex As System.Exception
                    LineProcessAddFG = ""
                End Try

                Try
                    'UPDATE Purchase Order Extended Amount based on line changes
                    cmd = New SqlCommand("INSERT INTO FoxSched (FOXNumber, ProcessStep, ProcessID, ProcessRemoveRM, ProcessAddFG) values (@FOXNumber, @ProcessStep, @ProcessID, @ProcessRemoveRM, @ProcessAddFG)", con)

                    With cmd.Parameters
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = NextFOXNumber
                        .Add("@ProcessStep", SqlDbType.VarChar).Value = LineProcessStep
                        .Add("@ProcessID", SqlDbType.VarChar).Value = LineProcessID
                        .Add("@ProcessRemoveRM", SqlDbType.VarChar).Value = LineProcessRemoveRM
                        .Add("@ProcessAddFG", SqlDbType.VarChar).Value = LineProcessAddFG
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'UPDATE Purchase Order Extended Amount based on line changes
                    cmd = New SqlCommand("INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) values (@ProductionNumber, @FOXNumber, @ProcessStep, @ProcessID, @ProcessAddFG)", con)

                    With cmd.Parameters
                        .Add("@ProductionNumber", SqlDbType.VarChar).Value = NewProductionNumber
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = NextFOXNumber
                        .Add("@ProcessStep", SqlDbType.VarChar).Value = LineProcessStep
                        .Add("@ProcessID", SqlDbType.VarChar).Value = LineProcessID
                        .Add("@ProcessAddFG", SqlDbType.VarChar).Value = LineProcessAddFG
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempFOXNumber As Integer = 0
                    Dim strFOXNumber As String
                    TempFOXNumber = NextFOXNumber
                    strFOXNumber = CStr(TempFOXNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "FOX Processes --- Re-Issue FOX  (Insert in FOX Sched)"
                    ErrorReferenceNumber = "FOX # " + strFOXNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                LineProcessStep = 0
                LineProcessAddFG = ""
                LineProcessRemoveRM = ""
                LineProcessID = ""
            Next

            'Rewrite FOX Outside Operations to the New FOX
            Dim OOTurnAround, OOProcessStep, OOEntryNumber As Integer
            Dim OOVendor, OOOperation As String

            'UPDATE Line Table on changes in the datagrid and ensure no NULL values
            For Each row2 As DataGridViewRow In dgvFOXOutsideData.Rows
                Try
                    OOTurnAround = row2.Cells("Turn Around").Value
                Catch ex As System.Exception
                    OOTurnAround = 0
                End Try
                Try
                    OOProcessStep = row2.Cells("Process Step").Value
                Catch ex As System.Exception
                    OOProcessStep = 0
                End Try
                Try
                    OOEntryNumber = row2.Cells("EntryNumber").Value
                Catch ex As System.Exception
                    OOEntryNumber = 0
                End Try
                Try
                    OOVendor = row2.Cells("Vendor").Value
                Catch ex As System.Exception
                    OOVendor = ""
                End Try
                Try
                    OOOperation = row2.Cells("Operation").Value
                Catch ex As System.Exception
                    OOOperation = ""
                End Try
                Try
                    'UPDATE Purchase Order Extended Amount based on line changes
                    cmd = New SqlCommand("INSERT INTO FOXOutsideOperations (FOXNumber, Vendor, Operation, TurnAround, ProcessStep, EntryNumber) values (@FOXNumber, @Vendor, @Operation, @TurnAround, @ProcessStep, @EntryNumber)", con)

                    With cmd.Parameters
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = NextFOXNumber
                        .Add("@Vendor", SqlDbType.VarChar).Value = OOVendor
                        .Add("@Operation", SqlDbType.VarChar).Value = OOOperation
                        .Add("@TurnAround", SqlDbType.VarChar).Value = OOTurnAround
                        .Add("@ProcessStep", SqlDbType.VarChar).Value = OOProcessStep
                        .Add("@EntryNumber", SqlDbType.VarChar).Value = OOEntryNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempFOXNumber As Integer = 0
                    Dim strFOXNumber As String
                    TempFOXNumber = NextFOXNumber
                    strFOXNumber = CStr(TempFOXNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "FOX Outside Ops --- Re-Issue FOX  (Insert in FOX Outside Ops)"
                    ErrorReferenceNumber = "FOX # " + strFOXNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                LineProcessStep = 0
                LineProcessAddFG = ""
                LineProcessRemoveRM = ""
                LineProcessID = ""
            Next

            Try
                cmd = New SqlCommand("INSERT INTO FOXCertifications (FOXNumber, Certification) SELECT @FOXNumber, Certification FROM FOXCertifications WHERE FOXNumber = @OldFOX", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = NextFOXNumber
                cmd.Parameters.Add("@OldFOX", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempFOXNumber As Integer = 0
                Dim strFOXNumber As String
                TempFOXNumber = NextFOXNumber
                strFOXNumber = CStr(TempFOXNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "FOXCertificaitons --- Re-Issue FOX  (Insert in FOXCertifications)"
                ErrorReferenceNumber = "FOX # " + strFOXNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            cboFOXNumber.Text = NextFOXNumber

            ShowProcesses()
            ShowReleases()
            ShowHeatNumbers()
            LoadFOXCertifications()
            ShowProcesses()
            ShowFOXProduction()

            txtSalesOrderNumber.Text = "0"
            NewProductionNumber = 0
            MaxProductionNumber = 0
            CountProductionNumber = 0

            txtQuotedQuantity.Clear()
            txtCustomerPO.Clear()
            cboFOXStatus.Text = "ACTIVE"
            dtpCreationDate.Value = Now.Date
            dtpFOXPromiseDate.Value = Now.Date
            dtpOrderDate.Value = Now.Date
            isLoaded = True

            MsgBox("New FOX Created.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdGenerateProcessStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateProcessStep.Click
        If canGetProcessStep() Then
            'Clear on next process number
            txtProcessStep.Clear()
            cboProcessID.SelectedIndex = -1

            'Find the next PO Number to use
            Dim MAXStatement As String = "SELECT MAX(ProcessStep) FROM FoxSched Where FOXNumber = @FOXNumber"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)
            MAXCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastProcessStepNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastProcessStepNumber = 0
            End Try
            con.Close()

            NextProcessStepNumber = LastProcessStepNumber + 1
            txtProcessStep.Text = NextProcessStepNumber
        End If
    End Sub

    Private Sub cmdAddProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddProcess.Click
        ''Add Process to FOX Record
        If canAddStep() Then
            LockBatch()
            'save changes in fox table
            InsertUpdateFOXTable()
            UpdateFOXInItemList()

            FinishedGoods = "NO"
            ''check to see if there is a need to remove
            If chkAddToFinishedGoods.Checked Then
                'remove any previous inventory add to finished goods
                cmd = New SqlCommand("update FOXSched set ProcessAddFG = 'NO' where FOXNumber = @foxnumber; update FOXProductionNumberSched set ProcessAddFG = 'NO' where FOXNumber = @foxnumber and ProductionNumber = @productionnumber;", con)
                ''Adds Audit trail entry for finished goods.
                cmd.CommandText += "  INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID);"
                FinishedGoods = "ADDINVENTORY"
                cmd.Parameters.Add("@foxnumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                cmd.Parameters.Add("@productionnumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)
                cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX FINISHED GOODS STEP ADDED"
                cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(txtProcessStep.Text)
                cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
                cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = "FOX #" + cboFOXNumber.Text + " Process Step # " + txtProcessStep.Text + " Process ID # " + cboProcessID.Text + " now adds to finished goods."
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            End If

            Try
                '' check to see if the process step exists
                cmd = New SqlCommand("if (@ProductionNumber = 0) SET @ProductionNumber = (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN'); if exists(select ProcessStep from FOXSched where FOXNumber = @foxnumber and ProcessStep = @processstep)", con)
                ''updates the FOX sched process step number at or above the current position being added
                cmd.CommandText += " BEGIN UPDATE FOXSched SET ProcessStep = ProcessStep + 1 WHERE FOXNumber = @foxnumber and ProcessStep >= @processstep;"
                ''updates the production number fox sched process step number at or above current position being added
                cmd.CommandText += "  if (@ProductionNumber <> 0) BEGIN update FOXProductionNumberSched set ProcessStep = ProcessStep + 1 where FOXNumber = @foxnumber and ProcessStep >= @processstep and ProductionNumber = @ProductionNumber;"
                ''Updates the timeslip line item so that it will corrispond to the proper step, if there is an entry for the FOX
                cmd.CommandText += " UPDATE TimeSlipLineItemTable SET FOXStep = FOXStep + 1 WHERE ProductionNumber = @ProductionNumber AND FOXNumber = @FOXNumber AND FOXStep >= @ProcessStep; END end"
                ''Inserts the new step into the fox sched
                cmd.CommandText += " INSERT into FOXSched (FOXNumber, ProcessStep, ProcessID, ProcessRemoveRM, ProcessAddFG)values(@foxnumber, @processstep, @processid, 'NO', @processaddfg);"
                ''Inserts the new step into the fox production number sched
                cmd.CommandText += " if (@ProductionNumber <> 0) insert into FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) values (@ProductionNumber, @foxnumber, @processstep, @processid, @processaddfg);"
                ''Adds the audit trail entry
                cmd.CommandText += " INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID);"
                With cmd.Parameters
                    .Add("@foxnumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                    .Add("@processstep", SqlDbType.VarChar).Value = Val(txtProcessStep.Text)
                    .Add("@processid", SqlDbType.VarChar).Value = cboProcessID.Text
                    .Add("@processaddfg", SqlDbType.VarChar).Value = FinishedGoods
                    .Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)
                    .Add("@AuditDate", SqlDbType.Date).Value = Now
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "FOX STEP ADDED"
                    .Add("@AuditAmount", SqlDbType.Float).Value = Val(txtProcessStep.Text)
                    .Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
                    .Add("@AuditComment", SqlDbType.VarChar).Value = "FOX #" + cboFOXNumber.Text + " Process Step # " + txtProcessStep.Text + " Process ID # " + cboProcessID.Text + " is now a part of the routing."
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                sendErrorToDataBase("foxmenu - cmdaddprocess_click -- adding new process to fox. Production #" + txtProductionNumber.Text, "fox #" + cboFOXNumber.Text, ex.ToString())
            End Try

            ShowProcesses()
            cboProcessID.SelectedIndex = -1
            txtProcessStep.Clear()
            chkAddToFinishedGoods.Checked = False
        End If
    End Sub

    Private Sub cmdDeleteProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteProcess.Click
        If canDeleteProcess() Then
            LockBatch()
            Dim currentRow As Integer = dgvFoxProcesses.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvFoxProcesses.CurrentCell.ColumnIndex

            cmd = New SqlCommand("DELETE FROM FoxSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep AND ProcessID = @ProcessID; IF (@ProductionNumber <> 0) DELETE FoxProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep AND ProcessID = @ProcessID AND ProductionNumber = @ProductionNumber; ", con)
            ''Adds audit entry for the deletion of a step
            cmd.CommandText += " INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType + ' STEP DELETED', @AuditAmount, @AuditReferenceNumber, @AuditComment + ' was deleted from the routing.', @DivisionID);"
            ''Adds audit entry for if it has to renumber the routing
            cmd.CommandText += " IF ((SELECT Count(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep > @ProcessStep) <> 0) INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType + ' PROCESS STEPS RENUMBERED', @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID);"
            ''Renumbers the process steps that cam after the deleted step
            cmd.CommandText += "  UPDATE FoxSched SET ProcessStep = ProcessStep - 1 WHERE FOXNumber = @FOXNumber AND ProcessStep > @ProcessStep; IF (@ProductionNumber <> 0) UPDATE FOXProductionNumberSched SET ProcessStep = ProcessStep - 1 WHERE FOXNumber = @FOXNumber AND ProcessStep > @ProcessStep AND ProductionNumber = @ProductionNumber;"
            ''Checks to see if the FOX still has a finished goods step. If it does not this will add it into the final step in the routing. Also adds audit trail entry if needed
            cmd.CommandText += " IF ((SELECT Count(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY') = 0) BEGIN IF ((SELECT Count(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber) > 0) BEGIN DECLARE @MaxStep as int = (SELECT MAX(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber); DECLARE @MaxProcessID as varchar(50) = (SELECT ProcessID FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @MaxStep); UPDATE FOXSched SET ProcessAddFG = 'ADDINVENTORY' WHERE ProcessStep = @MaxStep AND FOXNumber = @FOXNumber; INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, 'FOX FINISHED GOODS STEP CHANGED', @AuditAmount, @AuditReferenceNumber, 'FOX # ' + Cast(@FOXNumber as varchar(10)) + ' Process Step # ' + Cast(@MaxStep as varchar(5)) + ' Process ID # ' + @MaxProcessID + ' added as finished goods step', @DivisionID); IF (@ProductionNumber <> 0) UPDATE FOXProductionNumberSched SET ProcessAddFG = 'ADDINVENTORY' WHERE FOXNumber = @FOXnumber AND ProcessStep = @MaxStep AND ProductionNumber = @ProductionNumber; END END"
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
            cmd.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = dgvFoxProcesses.Rows(currentRow).Cells("ProcessStepColumn").Value
            cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = dgvFoxProcesses.Rows(currentRow).Cells("ProcessIDColumn").Value
            cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(txtProductionNumber.Text)
            ''Audit trail parameters
            cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX "
            cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(dgvFoxProcesses.Rows(currentRow).Cells("ProcessStepColumn").Value)
            cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
            cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = "FOX # " + cboFOXNumber.Text + " Process Step # " + dgvFoxProcesses.Rows(currentRow).Cells("ProcessStepColumn").Value.ToString() + " Process ID # " + dgvFoxProcesses.Rows(currentRow).Cells("ProcessIDColumn").Value.ToString()
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Save changes in Fox Table
            InsertUpdateFOXTable()
            UpdateFOXInItemList()
            UpdateSalesOrderFromFOX()
            InsertUpdateAdditionalShipTo()

            'Clear text boxes
            ShowProcesses()

            ''check to make sure that there are rows in the DGV before trying to select current cell
            If dgvFoxProcesses.Rows.Count > 0 Then
                If currentRow <= dgvFoxProcesses.Rows.Count - 1 Then
                    dgvFoxProcesses.CurrentCell = dgvFoxProcesses.Rows(currentRow).Cells(currentColumn)
                Else
                    If dgvFoxProcesses.Rows.Count > 0 Then
                        dgvFoxProcesses.CurrentCell = dgvFoxProcesses.Rows(currentRow - 1).Cells(currentColumn)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdAddFOXCertification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFOXCertification.Click
        If canAddCertification() Then
            cmd = New SqlCommand("IF not exists(SELECT Certification FROM FOXCertifications WHERE FOXNumber = @FOXNumber and Certification = @Certification) begin insert into FOXCertifications VALUES(@FOXNumber, @Certification); SELECT 0; END; ELSE SELECT 1;", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
            cmd.Parameters.Add("@Certification", SqlDbType.VarChar).Value = cboFOXCertifications.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim cnt As Integer = cmd.ExecuteScalar()
            con.Close()
            If cnt > 0 Then
                MessageBox.Show("Certificaiton was already added for this FOX", "Unable to add", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboFOXCertifications.SelectAll()
                cboFOXCertifications.Focus()
            End If
            LoadFOXCertifications()
            cboFOXCertifications.SelectedIndex = -1
        End If
    End Sub

    Private Sub cmdUpdateProductionQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateProductionQuantity.Click
        If canUpdateProdQty() Then
            Dim newProductionQuantity As Integer = ProductionAPI.GenerateNewProductionQuantityByFOX(cboFOXNumber.Text, con)
            If newProductionQuantity > 0 Then
                If ProductionAPI.UpdateProductionQuantity(txtProductionNumber.Text, cboFOXNumber.Text, newProductionQuantity, con) Then
                    txtProductionQuantity.Text = newProductionQuantity
                    MessageBox.Show("Production Quantity has been updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("There was an issue updating the quantity. Contact system admin.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Production quantity generated was not above 0. Contact system admin.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub cmdOrderSteel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOrderSteel.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalSteelOrderCarbon = cboSteelCarbon.Text
        GlobalSteelOrderFOXNumber = Val(cboFOXNumber.Text)
        GlobalSteelOrderPartNumber = cboPartNumber.Text
        GlobalSteelOrderProcessAgent = EmployeeLoginName
        GlobalSteelOrderRMID = txtRMID.Text
        GlobalSteelOrderSteelDescription = txtSteelDescription.Text
        GlobalSteelOrderSteelRequired = Val(txtSteelRequired.Text)
        GlobalSteelOrderSteelSize = cboSteelSize.Text
        GlobalSteelOrderPartDescription = cboPartDescription.Text

        Using NewFOXOrderSteelForm As New FOXSteelOrderForm
            Dim Result = NewFOXOrderSteelForm.ShowDialog()
        End Using
    End Sub

    Private Sub cmdAddOutside_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddOutside.Click
        If canAddOutside() Then
            cmd = New SqlCommand("INSERT INTO FOXOutsideOperations VALUES(@FOXNumber, @Vendor, @Operation, @TurnAround, @ProcessStep, (SELECT isnull(MAX(EntryNumber)+1, 1) FROM FOXOutsideOperations))", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
            cmd.Parameters.Add("@Vendor", SqlDbType.VarChar).Value = txtOutsideVendorID.Text
            cmd.Parameters.Add("@Operation", SqlDbType.VarChar).Value = txtOutsideOperation.Text
            cmd.Parameters.Add("@TurnAround", SqlDbType.Int).Value = Val(txtTurnAround.Text)
            cmd.Parameters.Add("@ProcessStep", SqlDbType.Int).Value = Val(txtRouting.Text)

            If con.State = ConnectionState.Closed Then con.Open()

            cmd.ExecuteNonQuery()
            con.Close()
            clearOutsideOperations()
            LoadOutsideOperations()
        End If
    End Sub

    Private Sub cmdNewProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewProduction.Click
        If CanStartNewProduction() Then
            Dim newProducitonQuantity As Integer = GenerateNewProductionQuantityByFOX(cboFOXNumber.Text, con)
            Dim newProductionNumber As String = ProductionAPI.StartNewProduction(Val(txtProductionNumber.Text), Val(cboFOXNumber.Text), newProducitonQuantity)
            ''check to see if there was a new production number genereated
            If Not newProductionNumber.Equals("0") Then
                ''starts the old production run completion process for Accounting.
                CompletionTasks.Add(New ProductionCompletion(txtProductionNumber.Text, cboFOXNumber.Text, True))
                txtProductionNumber.Text = newProductionNumber
                txtProductionQuantity.Text = newProducitonQuantity.ToString()
                ProductionAPI.LoadSingleFOXProductionData(New WIPDataPassed(dgvProductionData, cboFOXNumber.Text, pnlNoWIPData, True))
                MessageBox.Show("New production has been created.", "New Production success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("There was a problem creating the new production number, contact system admin.", "Unable to create new production number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub cmdClearBlanks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearBlanks.Click
        txtWIPAdjustmentQuantity.Clear()
        txtWIPComment.Clear()
    End Sub

    Private Sub cmdAdjustBlanks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdjustBlanks.Click
        Dim GetNextTimeslipKey, GetLastTimeslipKey As Integer

        Dim GetLastTimeslipKeyString As String = "SELECT MAX(TimeSlipKey) FROM TimeSlipHeaderTable"
        Dim GetLastTimeslipKeyCommand As New SqlCommand(GetLastTimeslipKeyString, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLastTimeslipKey = CInt(GetLastTimeslipKeyCommand.ExecuteScalar)
        Catch ex As Exception
            GetLastTimeslipKey = 0
        End Try
        con.Close()

        GetNextTimeslipKey = GetLastTimeslipKey + 1

        Try
            'Insert into Header Table
            cmd = New SqlCommand("INSERT INTO TimeSlipHeaderTable (TimeSlipKey, PostingDate, EmployeeID, Shift, DivisionID, Status, EmployeeName, PrintDate, PostedBy) values (@TimeSlipKey, @PostingDate, @EmployeeID, @Shift, @DivisionID, @Status, @EmployeeName, @PrintDate, @PostedBy)", con)

            With cmd.Parameters
                .Add("@TimeSlipKey", SqlDbType.VarChar).Value = GetNextTimeslipKey
                .Add("@PostingDate", SqlDbType.VarChar).Value = Now()
                .Add("@EmployeeID", SqlDbType.VarChar).Value = "ADMIN"
                .Add("@Shift", SqlDbType.VarChar).Value = 1
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "POSTED"
                .Add("@EmployeeName", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@PrintDate", SqlDbType.VarChar).Value = Now()
                .Add("@PostedBy", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Get Current Production Number
            Dim GetMAXProductionNumber As Integer = 0

            Dim GetMAXProductionNumberString As String = "SELECT MAX(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber"
            Dim GetMAXProductionNumberCommand As New SqlCommand(GetMAXProductionNumberString, con)
            GetMAXProductionNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetMAXProductionNumber = CInt(GetMAXProductionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetMAXProductionNumber = 0
            End Try
            con.Close()

            'Get Steel Weight
            Dim GetFOXPieceWeight As Double = 0
            Dim GetPostingSteelWeight As Double = 0
            Dim GetPostingQuantity As Double = 0

            GetPostingQuantity = Val(txtWIPAdjustmentQuantity.Text)
            GetFOXPieceWeight = Val(txtPieceWeightFOX.Text)
            GetPostingSteelWeight = GetPostingQuantity * GetFOXPieceWeight
            GetPostingSteelWeight = Math.Round(GetPostingSteelWeight, 0)

            'Insert INTO Line Table
            cmd = New SqlCommand("INSERT INTO TimeSlipLineItemTable (TimeSlipKey, LineKey, FOXNumber, MachineNumber, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, TotalHours, PiecesProduced, LineWeight, ScrapWeight, InventoryPieces, RMID, ExtendedCost, Cost, FOXStep, DivisionID, ExtendedSteelCost, PostedSpecial, PostingReversed, PostingAddFG, PostingChanger, PostingChangedDate, PostingChangeComment, ProductionNumber, AVGCostPerPiece, OriginalPart) values (@TimeSlipKey, @LineKey, @FOXNumber, @MachineNumber, @PartNumber, @MachineHours, @SetupHours, @ToolingHours, @OtherHours, @TotalHours, @PiecesProduced, @LineWeight, @ScrapWeight, @InventoryPieces, @RMID, @ExtendedCost, @Cost, @FOXStep, @DivisionID, @ExtendedSteelCost, @PostedSpecial, @PostingReversed, @PostingAddFG, @PostingChanger, @PostingChangedDate, @PostingChangeComment, @ProductionNumber, @AVGCostPerPiece, @OriginalPart)", con)

            With cmd.Parameters
                .Add("@TimeSlipKey", SqlDbType.VarChar).Value = GetNextTimeslipKey
                .Add("@LineKey", SqlDbType.VarChar).Value = 1
                .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                .Add("@MachineNumber", SqlDbType.VarChar).Value = txtWIPProcessStep.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@MachineHours", SqlDbType.VarChar).Value = 0
                .Add("@SetupHours", SqlDbType.VarChar).Value = 0
                .Add("@ToolingHours", SqlDbType.VarChar).Value = 0
                .Add("@OtherHours", SqlDbType.VarChar).Value = 0
                .Add("@TotalHours", SqlDbType.VarChar).Value = 0
                .Add("@PiecesProduced", SqlDbType.VarChar).Value = Val(txtWIPAdjustmentQuantity.Text)
                .Add("@LineWeight", SqlDbType.VarChar).Value = GetPostingSteelWeight
                .Add("@ScrapWeight", SqlDbType.VarChar).Value = 0
                .Add("@InventoryPieces", SqlDbType.VarChar).Value = 0
                .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
                .Add("@ExtendedCost", SqlDbType.VarChar).Value = 0
                .Add("@Cost", SqlDbType.VarChar).Value = 0
                .Add("@FOXStep", SqlDbType.VarChar).Value = 1
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ExtendedSteelCost", SqlDbType.VarChar).Value = 0
                .Add("@PostedSpecial", SqlDbType.VarChar).Value = False
                .Add("@PostingReversed", SqlDbType.VarChar).Value = False
                .Add("@PostingAddFG", SqlDbType.VarChar).Value = False
                .Add("@PostingChanger", SqlDbType.VarChar).Value = ""
                .Add("@PostingChangedDate", SqlDbType.VarChar).Value = Now()
                .Add("@PostingChangeComment", SqlDbType.VarChar).Value = txtWIPComment.Text
                .Add("@ProductionNumber", SqlDbType.VarChar).Value = GetMAXProductionNumber
                .Add("@AVGCostPerPiece", SqlDbType.VarChar).Value = 0
                .Add("@OriginalPart", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Blank adjustment is posted.", MsgBoxStyle.OkOnly)

            LoadWIPDataForAdjustments()

            txtWIPAdjustmentQuantity.Clear()
            txtWIPComment.Clear()
        Catch ex As Exception
            MsgBox("There was a problem posting - contact ADMIN.", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try
    End Sub

    'Menu functions

    Private Sub DeleteFOXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteFOXToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub SaveFOXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveFOXToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub FOXByPromiseDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FOXByPromiseDateToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintFOXByDate As New PrintFOXByDate
            Dim result = NewPrintFOXByDate.ShowDialog()
        End Using
    End Sub

    Private Sub FOXPostingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FOXPostingReportToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintFOXPostingReport As New PrintFOXPostingReport
            Dim result = NewPrintFOXPostingReport.ShowDialog()
        End Using
    End Sub

    Private Sub ShowReleasesShipmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowReleasesShipmentsToolStripMenuItem.Click
        GlobalFOXNumber = Val(cboFOXNumber.Text)

        Using NewFOXReleaseShippingDetails As New ViewFOXReleaseSchedule
            Dim result = NewFOXReleaseShippingDetails.ShowDialog()
        End Using
    End Sub

    Private Sub CreateSalesOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateSalesOrderToolStripMenuItem.Click
        cmdCreateSO_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        cmdClear_Click(sender, e)
    End Sub

    Private Sub PrintPickTicketsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPickTicketsToolStripMenuItem.Click
        GlobalSONumberPickList = Val(txtSalesOrderNumber.Text)
        GlobalDivisionCode = "TFP"

        Using NewPrintPickTicketsSO As New PrintPickTicketsSO
            Dim Result = NewPrintPickTicketsSO.ShowDialog
        End Using
    End Sub

    Private Sub PrintPackingSlipsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPackingSlipsToolStripMenuItem.Click
        GlobalSONumberPackSlip = Val(txtSalesOrderNumber.Text)
        GlobalDivisionCode = "TFP"

        Using NewPrintPackListSO As New PrintPackListSO
            Dim Result = NewPrintPackListSO.ShowDialog
        End Using
    End Sub

    Private Sub PrintOrderConfirmationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintOrderConfirmationsToolStripMenuItem.Click, PrintOrderConfirmationsToolStripMenuItem.Click
        GlobalTFPSOPrintForm = "TFP Acknowledgement"
        GlobalSONumber = Val(txtSalesOrderNumber.Text)
        GlobalDivisionCode = "TFP"
        GlobalFOXNumber = Val(cboFOXNumber.Text)

        Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
            Dim Result = NewPrintTFAcknowledgement.ShowDialog
        End Using
    End Sub

    Private Sub PrintInvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoicesToolStripMenuItem.Click
        GlobalSONumberInvoice = Val(txtSalesOrderNumber.Text)
        GlobalDivisionCode = "TFP"

        Using NewPrintInvoiceSO As New PrintInvoiceSO
            Dim Result = NewPrintInvoiceSO.ShowDialog
        End Using
    End Sub

    Private Sub PrintFOXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintFOXToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub DeleteSalesOrderReferenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSalesOrderReferenceToolStripMenuItem.Click
        Try
            'Update Pick Ticket
            cmd = New SqlCommand("UPDATE FOXTable SET OrderReferenceNumber = @OrderReferenceNumber WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtSalesOrderNumber.Clear()
            LoadSalesOrderData()
        Catch ex As Exception
            'Do nothing
        End Try
    End Sub

    Private Sub PrintNORLetterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintNORLetterToolStripMenuItem.Click
        If cboDivisionID.Text = "TFP" Then
            GlobalSONumber = Val(txtSalesOrderNumber.Text)
            GlobalDivisionCode = cboDivisionID.Text
            GlobalTFPSOPrintForm = "TFP NOR Letter"
            GlobalFOXNumber = Val(cboFOXNumber.Text)

            Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
                Dim result = NewPrintTFAcknowledgement.ShowDialog()
            End Using
        Else
            MsgBox("You must be logged in as TFP.", MsgBoxStyle.OkOnly)
        End If

    End Sub

    Private Sub PrintTFPFOXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintTFPFOXToolStripMenuItem.Click
        If cboDivisionID.Text = "TFP" Then
            GlobalSONumber = Val(txtSalesOrderNumber.Text)
            GlobalDivisionCode = cboDivisionID.Text
            GlobalTFPSOPrintForm = "TFP FOX FORM"
            GlobalFOXNumber = Val(cboFOXNumber.Text)

            Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
                Dim result = NewPrintTFAcknowledgement.ShowDialog()
            End Using
        Else
            MsgBox("You must be logged in as TFP.", MsgBoxStyle.OkOnly)
        End If

    End Sub

    Private Sub UnLockFOXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockFOXToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this FOX?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE FOXTable SET Locked = '' WHERE FOXNumber = @FOXNumber", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Fox is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a FOX number to un-lock", "Enter a FOX number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
        End If
    End Sub

    Private Sub ReOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReOpenToolStripMenuItem.Click
        If txtSOStatus.Text = "CLOSED" And txtSalesOrderNumber.Text <> "" And cboDivisionID.Text = "TFP" Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to re-open this Sales Order?", "RE-OPEN SALES ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Re-Open Sales Order Header
                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Open All Lines then auto-close lines where Quantity Open = 0
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                txtOrderStatus.Text = "OPEN"

                MsgBox("Order has been re-opened.", MsgBoxStyle.OkOnly)
                txtSOStatus.Text = "OPEN"
            ElseIf button = DialogResult.No Then
                'Do nothing
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub FindByPartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindByPartToolStripMenuItem.Click
        Dim newInput As New InputComboBox("Part Number", "")
        If newInput.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmd = New SqlCommand("SELECT FOXNumber, DivisionID FROM FOXTable WHERE PartNumber = @PartNumber AND Status = 'ACTIVE' ORDER BY FOXNumber DESC", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = newInput.cboInputValue.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim FOXNumber As String = Nothing
            Dim Division As String = Nothing
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If Not IsDBNull(reader.Item("FOXNumber")) Then
                    FOXNumber = reader.Item("FOXNumber")
                End If
                If Not IsDBNull(reader.Item("DivisionID")) Then
                    Division = reader.Item("DivisionID")
                End If
            End If
            reader.Close()
            con.Close()
            If FOXNumber IsNot Nothing AndAlso Division IsNot Nothing Then
                ClearData()
                If Not cboDivisionID.Text.Equals(Division) Then cboDivisionID.Text = Division
                cboFOXNumber.Text = FOXNumber
            Else
                MessageBox.Show("Unable to locate the FOX number for the given Part", "Unable to locate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    'Update or Insert Functions

    Public Sub InsertUpdateFOXTable()
        cmd = New SqlCommand("SELECT COUNT(FOXNumber) FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            InsertFOXTable()
        Else
            con.Close()
            UpdateFOXTable()
        End If
    End Sub

    Public Sub InsertFOXTable()
        cmd = New SqlCommand("SELECT isnull(MAX(FOXNumber), 0) FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim fx As Integer = 0

        If con.State = ConnectionState.Closed Then con.Open()
        fx = cmd.ExecuteScalar()
        con.Close()

        Dim nxt As Boolean = True
        cmd = New SqlCommand("SELECT Status, FOXNumber FROM FOXTable WHERE FOXNumber > @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = fx
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read() And nxt
                fx += 1
                If reader.GetValue(1) > fx Then
                    nxt = False
                Else
                    If reader.GetValue(0).Equals("INACTIVE") Then
                        nxt = False
                    End If
                End If
            End While
        Else
            fx += 1
            nxt = False
        End If
        reader.Close()
        con.Close()

        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("Insert Into FOXTable(FOXNumber, RMID, PartNumber, BlueprintNumber, DivisionID, RawMaterialWeight, FinishedWeight, ScrapWeight, FluxLoadNumber, CreationDate, Comments, CertificationType, Status, BoxType, CustomerID, ProductionQuantity, PromiseDate, OrderReferenceNumber, BlueprintRevision, Locked, QuoteNumber, QuotePrice, ProductionNote, PartNumber2, PartNumber3, CustomerPO)Values(@FOXNumber, @RMID, @PartNumber, @BlueprintNumber, @DivisionID, @RawMaterialWeight, @FinishedWeight, @ScrapWeight, @FluxLoadNumber, @CreationDate, @Comments, @CertificationType, @Status, @BoxType, @CustomerID, @ProductionQuantity, @PromiseDate, @OrderReferenceNumber, @BlueprintRevision, @Locked, @QuoteNumber, @QuotePrice, @ProductionNote, @PartNumber2, @PartNumber3, @CustomerPO)", con)

        With cmd.Parameters
            .Add("@FOXNumber", SqlDbType.VarChar).Value = fx
            .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = Val(txtRawMaterialWeight.Text)
            .Add("@FinishedWeight", SqlDbType.VarChar).Value = Val(txtFinishedWeight.Text)
            .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtScrapWeight.Text)
            .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = cboFluxLoadNumber.Text
            .Add("@CreationDate", SqlDbType.VarChar).Value = dtpCreationDate.Text
            .Add("@Comments", SqlDbType.VarChar).Value = txtFOXComment.Text
            .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
            .Add("@Status", SqlDbType.VarChar).Value = cboFOXStatus.Text
            .Add("@BoxType", SqlDbType.VarChar).Value = cboBoxType.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@ProductionQuantity", SqlDbType.VarChar).Value = Val(txtQuantityOrdered.Text)
            .Add("@PromiseDate", SqlDbType.VarChar).Value = dtpFOXPromiseDate.Text
            .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = txtSalesOrderNumber.Text
            .Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtRevisionLevel.Text
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@QuoteNumber", SqlDbType.VarChar).Value = txtQuoteNumber.Text
            .Add("@QuotePrice", SqlDbType.VarChar).Value = Val(txtQuotedPrice.Text)
            .Add("@ProductionNote", SqlDbType.VarChar).Value = txtProductionNote.Text
            .Add("@PartNumber2", SqlDbType.VarChar).Value = txtATLPartNumber.Text
            .Add("@PartNumber3", SqlDbType.VarChar).Value = txtCustomerPartNumber.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            sendErrorToDataBase("FOXMenu - InsertFOXTable --Error inserting into FOXTable", "FOX #" + cboFOXNumber.Text, ex.ToString())
            Throw ex
        End Try

        isLoaded = False
        LoadFOXNumber()
        isLoaded = True
        cboFOXNumber.Text = fx.ToString()
        lastFOX = cboFOXNumber.Text
        If cboDivisionID.Text.Equals("TWD") Then
            If String.IsNullOrEmpty(txtProductionNumber.Text) Then
                txtProductionQuantity.Text = "0"
                txtProductionNumber.Text = StartNewProduction(0, Val(cboFOXNumber.Text), 0)
            End If
        End If
    End Sub

    Private Sub UpdateFOXTable()
        'Log changes if necessary
        TrackChangesInSteel()

        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("Update FOXTable SET RMID = @RMID, PartNumber = @PartNumber, BlueprintNumber = @BlueprintNumber, RawMaterialWeight = @RawMaterialWeight, FinishedWeight = @FinishedWeight, ScrapWeight = @ScrapWeight, FluxLoadNumber = @FluxLoadNumber, CreationDate = @CreationDate, Comments = @Comments, CertificationType = @CertificationType, Status = @Status, BoxType = @BoxType, CustomerID = @CustomerID, ProductionQuantity = @ProductionQuantity, PromiseDate = @PromiseDate, OrderReferenceNumber = @OrderReferenceNumber, BlueprintRevision = @BlueprintRevision, QuoteNumber = @QuoteNumber, QuotePrice = @QuotePrice, ScheduledRMID = @ScheduledRMID, ProductionNote = @ProductionNote, PartNumber2 = @PartNumber2, PartNumber3 = @PartNumber3, CustomerPO = @CustomerPO WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
            .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = Val(txtRawMaterialWeight.Text)
            .Add("@FinishedWeight", SqlDbType.VarChar).Value = Val(txtFinishedWeight.Text)
            .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtScrapWeight.Text)
            .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = cboFluxLoadNumber.Text
            .Add("@CreationDate", SqlDbType.VarChar).Value = dtpCreationDate.Text
            .Add("@Comments", SqlDbType.VarChar).Value = txtFOXComment.Text
            .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertCode.Text
            .Add("@Status", SqlDbType.VarChar).Value = cboFOXStatus.Text
            .Add("@BoxType", SqlDbType.VarChar).Value = cboBoxType.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@ProductionQuantity", SqlDbType.VarChar).Value = Val(txtQuotedQuantity.Text)
            .Add("@PromiseDate", SqlDbType.VarChar).Value = dtpFOXPromiseDate.Text
            .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            .Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtRevisionLevel.Text
            .Add("@QuoteNumber", SqlDbType.VarChar).Value = txtQuoteNumber.Text
            .Add("@QuotePrice", SqlDbType.VarChar).Value = Val(txtQuotedPrice.Text)
            .Add("@ProductionNote", SqlDbType.VarChar).Value = txtProductionNote.Text
            .Add("@PartNumber2", SqlDbType.VarChar).Value = txtATLPartNumber.Text
            .Add("@PartNumber3", SqlDbType.VarChar).Value = txtCustomerPartNumber.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
        End With

        If String.IsNullOrEmpty(txtAlternateRMID.Text) And Not String.IsNullOrEmpty(txtRMID.Text) Then
            cmd.Parameters.Add("@ScheduledRMID", SqlDbType.VarChar).Value = txtRMID.Text
        Else
            cmd.Parameters.Add("@ScheduledRMID", SqlDbType.VarChar).Value = txtAlternateRMID.Text
        End If

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            sendErrorToDataBase("FOXMenu - UpdateFOXTable --Error inserting into FOXTable", "FOX #" + cboFOXNumber.Text, ex.ToString())
            Throw ex
        End Try

        If EmployeeSecurityCode = 1030 Or EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1001 Then
            If cboPartNumber.Text <> "" Then
                Try
                    'Update Item List for certain security codes
                    cmd = New SqlCommand("UPDATE ItemList SET PieceWeight = @PieceWeight, BoxCount = @BoxCount, PalletCount = @PalletCount, BoxWeight = @BoxWeight WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PieceWeight", SqlDbType.VarChar).Value = Val(txtPieceWeight.Text)
                        .Add("@BoxCount", SqlDbType.VarChar).Value = Val(txtBoxCount.Text)
                        .Add("@PalletCount", SqlDbType.VarChar).Value = Val(txtPalletCount.Text)
                        .Add("@BoxWeight", SqlDbType.VarChar).Value = Val(txtBoxWeight.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempFOXNumber As Integer = 0
                    Dim strFOXNumber As String
                    Dim TempPartNumber As String
                    TempPartNumber = cboPartNumber.Text
                    TempFOXNumber = Val(cboFOXNumber.Text)
                    strFOXNumber = CStr(TempFOXNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "FOX Save procedure --- Item List Shipping Details Command Failure"
                    ErrorReferenceNumber = "FOX # " + strFOXNumber + " , Part Number " + TempPartNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        End If
    End Sub

    Public Sub UpdateSalesOrderFromFOX()
        If cboDivisionID.Text = "TFP" And txtSalesOrderNumber.Text <> "" And Not txtSalesOrderNumber.Text.Equals("0") Then
            If cboFOXStatus.Text = "INACTIVE" Then
                'Skip
                If CanCloseSO() Then
                    ''updates the sales order header table to show closed
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = 'CLOSED' WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = 'TFP';", con)
                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.Int).Value = Val(txtSalesOrderNumber.Text)
                    ''updates the sales order lines to show as closed
                    cmd.CommandText += " UPDATE SalesOrderLineTable SET LineStatus = 'CLOSED' WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = 'TFP';"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        sendErrorToDataBase("FOXMenu - UpdateSalesOrderFromFOX --Error trying to update SALES ORDER HEADER and LINE tables to CLOSED.", "Sales Order #" + txtSalesOrderNumber.Text, ex.ToString())
                    End Try
                    If con.State = ConnectionState.Open Then con.Close()
                End If
            Else
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    MsgBox("Sales Order Data was not saved.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                If cboShipToID.Text = "" Or txtSTName.Text = "DEFAULT SHIP TO" Or txtSTName.Text = "" Then
                    ShipToName = cboCustomerName.Text
                Else
                    ShipToName = txtSTName.Text
                End If
            End If

            Try
                'Write Data to Sales Order Header Database Table (Added in summing of SO lines so that the totals were accurate --John)
                cmd = New SqlCommand("DECLARE @ProductTotal float = (SELECT ROUND(SUM(ExtendedAmount),2) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey);" _
                                     + " UPDATE SalesOrderHeaderTable SET ProductTotal = @ProductTotal, SOTotal = (@ProductTotal + @FreightCharge), SalesOrderDate = @SalesOrderDate, CustomerID = @CustomerID, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingDate = @ShippingDate, FreightCharge = @FreightCharge, AdditionalShipTo = @AdditionalShipTo, SpecialInstructions = @SpecialInstructions, Locked = @Locked, FOB = @FOB, CustomerClass = @CustomerClass, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShipToAddress1 = @ShipToAddress1, ShipToAddress2 = @ShipToAddress2, ShipToCity = @ShipToCity, ShipToState = @ShipToState, ShipToZip = @ShipToZip, ShipToCountry = @ShipToCountry WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    .Add("@SalesOrderDate", SqlDbType.Date).Value = dtpOrderDate.Value
                    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                    .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                    .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                    .Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"
                    .Add("@ShippingDate", SqlDbType.VarChar).Value = dtpShipDate.Value
                    .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                    .Add("@Locked", SqlDbType.VarChar).Value = ""
                    .Add("@FOB", SqlDbType.VarChar).Value = "Medina"
                    .Add("@CustomerClass", SqlDbType.VarChar).Value = "STANDARD"
                    .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                    .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                    .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                    .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                    .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                    .Add("@ShipToCity", SqlDbType.VarChar).Value = txtSTCity.Text
                    .Add("@ShipToState", SqlDbType.VarChar).Value = cboSTState.Text
                    .Add("@ShipToZip", SqlDbType.VarChar).Value = txtSTZip.Text
                    .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtSTCountry.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempFOXNumber As Integer = 0
                Dim strFOXNumber As String
                Dim TempSONumber As String
                Dim strTempSONumber As String

                TempSONumber = Val(txtSalesOrderNumber.Text)
                TempFOXNumber = Val(cboFOXNumber.Text)
                strFOXNumber = CStr(TempFOXNumber)
                strTempSONumber = CStr(TempSONumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "FOX Save procedure --- Sales Order FOX Update Command Failure"
                ErrorReferenceNumber = "FOX # " + strFOXNumber + " , SO # " + strTempSONumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        Else
            'Skip update
        End If
    End Sub

    Public Sub UpdateFOXInItemList()
        'Add FOX Number to Item Table
        Try
            cmd = New SqlCommand("UPDATE ItemList SET FOXNumber = @FOXNumber, BoxType = @BoxType, Comments = @Comments WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@BoxType", SqlDbType.VarChar).Value = cboBoxType.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Comments", SqlDbType.VarChar).Value = txtProductionNote.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempFOXNumber As Integer = 0
            Dim strFOXNumber As String
            Dim TempPartNumber As String
            TempPartNumber = cboPartNumber.Text
            TempFOXNumber = Val(cboFOXNumber.Text)
            strFOXNumber = CStr(TempFOXNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "FOX Save procedure --- Item List FOX Update Command Failure"
            ErrorReferenceNumber = "FOX # " + strFOXNumber + " , Part Number " + TempPartNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub InsertUpdateAdditionalShipTo()
        If cboShipToID.Text <> "" And cboDivisionID.Text = "TFP" And txtSalesOrderNumber.Text <> "" Then
            Try
                'Create new ship to from the text boxes
                cmd = New SqlCommand("Insert Into AdditionalShipTo(ShipToID, CustomerID, DivisionID, Address1, Address2, City, State, Zip, Country, Name) Values (@ShipToID, @CustomerID, @DivisionID, @Address1, @Address2, @City, @State, @Zip, @Country, @Name)", con)

                With cmd.Parameters
                    .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Address1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                    .Add("@Address2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtSTCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = cboSTState.Text
                    .Add("@Zip", SqlDbType.VarChar).Value = txtSTZip.Text
                    .Add("@Country", SqlDbType.VarChar).Value = txtSTCountry.Text
                    .Add("@Name", SqlDbType.VarChar).Value = txtSTName.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Command to save changes in the additional ship to from the text boxes
                cmd = New SqlCommand("UPDATE AdditionalShipTo SET Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, Name = @Name WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Address1", SqlDbType.VarChar).Value = txtSTAddress1.Text
                    .Add("@Address2", SqlDbType.VarChar).Value = txtSTAddress2.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtSTCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = cboSTState.Text
                    .Add("@Zip", SqlDbType.VarChar).Value = txtSTZip.Text
                    .Add("@Country", SqlDbType.VarChar).Value = txtSTCountry.Text
                    .Add("@Name", SqlDbType.VarChar).Value = txtSTName.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try
        Else
            'Skip update of shipping address
        End If
    End Sub

    'Misc Functions (Link Label, DateTimePicker, Check Boxes, etc.)

    Private Sub tabItemProcess_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabItemProcess.SelectedIndexChanged
        If tabItemProcess.SelectedIndex = 6 Then
            ProductionAPI.LoadSingleFOXProductionData(New WIPDataPassed(dgvProductionData, cboFOXNumber.Text, pnlNoWIPData, True))
        Else
            'Do nothing
        End If
    End Sub

    Private Sub chkAddExpedite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddExpedite.CheckedChanged
        If chkAddExpedite.Checked = True Then
            txtAddExpedite.Visible = True
        Else
            txtAddExpedite.Visible = False
        End If
    End Sub

    Private Sub llApproxOverheadCost_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llApproxOverheadCost.LinkClicked
        If pnlOverHeadBreakdown.Visible Then
            pnlOverHeadBreakdown.Hide()
        Else
            pnlOverHeadBreakdown.Show()
        End If
    End Sub

    Private Sub pnlOverHeadBreakdown_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlOverHeadBreakdown.VisibleChanged
        If pnlOverHeadBreakdown.Visible Then
            cmd = New SqlCommand("SELECT CAST(TimeSlipLineItemTable.FOXStep as Varchar(50)) as FOXStep, '' as MachineNumber, '' as MachineDescription, CASE WHEN SUM(ExtendedCost) < 0 THEN 0 ELSE SUM(ExtendedCost) END as TotalCost, SUM(TimeSlipLineItemTable.PiecesProduced) as TotalPieces, CASE WHEN SUM(TimeSlipLineItemTable.PiecesProduced) = 0 then 0 ELSE ROUND(SUM(ExtendedCost) / SUM(TimeSlipLineItemTable.PiecesProduced), 5) END as StepCostPerPiece FROM TimeSlipLineItemTable INNER JOIN MachineTable ON TimeSlipLineItemTable.MachineNumber = MachineTable.MachineID INNER JOIN (SELECT FOXNumber, PRocessStep, ProcessADdFG FROM FoxSched WHERE ProcessAddFG = 'ADDINVENTORY') AS FOXSched ON TimeSlipLineItemTable.FOXNumber = FoxSched.FOXNumber WHERE TimeSlipLineItemTable.FOXNumber = @FOXNumber AND LineKey < 100 AND FOXStep <> 999 AND FOXStep <= CASE WHEN (FOXSched.ProcessStep is not null) THEN FOXSched.ProcessStep ELSE 10 END GROUP BY TimeslipLineItemTable.FOXStep", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
            Dim dt As New Data.DataTable("TimeSlipLineItemTable")
            Dim adap As New SqlDataAdapter(cmd)

            If con.State = ConnectionState.Closed Then con.Open()
            adap.Fill(dt)

            cmd.CommandText = "SELECT FoxSched.ProcessStep, FOXSched.ProcessID, MachineTable.Description FROM FoxSched INNER JOIN MachineTable ON FoxSched.ProcessID = MachineTable.MachineID WHERE FoxSched.FOXNumber = @FOXNumber AND MachineTable.DivisionID = 'TWD'"

            Dim TotalCost As Double = 0D
            Dim TotalPieces As Integer = 0
            Dim TotalPieceCost As Double = 0D

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read
                    Dim rw As Data.DataRow() = dt.Select("FOXStep = '" + reader.Item("ProcessStep").ToString + "'")
                    If rw.Length > 0 Then
                        rw(0).Item("MachineNumber") = reader.Item("ProcessID").ToString
                        rw(0).Item("MachineDescription") = reader.Item("Description").ToString
                        TotalCost += rw(0).Item("TotalCost")
                        TotalPieces += rw(0).Item("TotalPieces")
                        TotalPieceCost += rw(0).Item("StepCostPerPiece")
                    End If
                End While
            End If
            reader.Close()
            con.Close()
            Dim nrw As Data.DataRow = dt.Rows.Add()
            nrw.Item("FOXStep") = "Total"
            nrw.Item("TotalCost") = TotalCost
            nrw.Item("TotalPieces") = TotalPieces
            nrw.Item("StepCostPerPiece") = TotalPieceCost


            dgvOverheadBreakdown.DataSource = dt
            dgvOverheadBreakdown.Columns("FOXStep").HeaderText = "Process Step"
            dgvOverheadBreakdown.Columns("FOXStep").Width = 50
            dgvOverheadBreakdown.Columns("FOXStep").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvOverheadBreakdown.Columns("MachineNumber").HeaderText = "Machine"
            dgvOverheadBreakdown.Columns("MachineNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvOverheadBreakdown.Columns("MachineNumber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvOverheadBreakdown.Columns("MachineDescription").HeaderText = "Description"
            dgvOverheadBreakdown.Columns("MachineDescription").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvOverheadBreakdown.Columns("TotalCost").HeaderText = "Total Cost"
            dgvOverheadBreakdown.Columns("TotalCost").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvOverheadBreakdown.Columns("TotalCost").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvOverheadBreakdown.Columns("TotalCost").DefaultCellStyle.Format = "C2"
            dgvOverheadBreakdown.Columns("TotalPieces").HeaderText = "Total Pieces"
            dgvOverheadBreakdown.Columns("TotalPieces").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvOverheadBreakdown.Columns("TotalPieces").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvOverheadBreakdown.Columns("TotalPieces").DefaultCellStyle.Format = "N0"
            dgvOverheadBreakdown.Columns("StepCostPerPiece").HeaderText = "Cost Per Piece"
            dgvOverheadBreakdown.Columns("StepCostPerPiece").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvOverheadBreakdown.Columns("StepCostPerPiece").DefaultCellStyle.Format = "C5"
            dgvOverheadBreakdown.Columns("StepCostPerPiece").Width = 50
            dgvOverheadBreakdown.Columns("StepCostPerPiece").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub llSalesOrderStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSalesOrderStatus.LinkClicked
        If txtSOStatus.Text = "CLOSED" And txtSalesOrderNumber.Text <> "" And cboDivisionID.Text = "TFP" Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to re-open this Sales Order?", "RE-OPEN SALES ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Re-Open Sales Order Header
                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Open All Lines then auto-close lines where Quantity Open = 0
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Order has been re-opened.", MsgBoxStyle.OkOnly)
                txtSOStatus.Text = "OPEN"
            ElseIf button = DialogResult.No Then
                'Do nothing
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub chkAddPPAP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddPPAP.CheckedChanged
        If chkAddPPAP.Checked = True Then
            txtAddPPAP.Visible = True
        Else
            txtAddPPAP.Visible = False
        End If
    End Sub

    Private Sub chkAddTooling_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddTooling.CheckedChanged
        If chkAddTooling.Checked = True Then
            txtAddTooling.Visible = True
        Else
            txtAddTooling.Visible = False
        End If
    End Sub

    Private Sub tabItemProcess_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tabItemProcess.MouseClick
        LoadFormatting()
    End Sub

    Private Sub llQtyInRack_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQtyInRack.LinkClicked
        GlobalDivisionCode = cboDivisionID.Text
        GlobalMaintenancePartNumber = cboPartNumber.Text

        Using NewItemMaintenanceRacking As New ItemMaintenanceRacking
            Dim Result = NewItemMaintenanceRacking.ShowDialog()
        End Using
    End Sub

    Private Sub dtpCreationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCreationDate.ValueChanged
        If isLoaded Then
            If dtpCreationDate.Focused Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub cmdResetProductionProcesses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetProductionProcesses.Click
        'Validate Fields
        If cboFOXNumber.Text = "" Then
            MsgBox("You must have a valid FOX Number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboDivisionID.Text <> "TFP" Then
            MsgBox("Reset is for TFP FOXES only.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'FOR TFP, use 80316 as the production number

        Dim CheckExistingProductionNumber As Integer = 0
        Dim GetProductionNumber As Integer = 0
        Dim RowProcessStepNumber As Integer = 0
        Dim RowProcessID As String = ""
        Dim RowAddToFG As String = ""
        Dim ProductionQuantity As Integer = 0

        If txtQuantityOpen.Text > 0 Then
            ProductionQuantity = Val(txtQuantityOpen.Text)
        Else
            ProductionQuantity = Val(txtQuotedQuantity.Text)
        End If

        Dim CheckExistingProductionNumberStatement As String = "SELECT ProductionNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber"
        Dim CheckExistingProductionNumberCommand As New SqlCommand(CheckExistingProductionNumberStatement, con)
        CheckExistingProductionNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
 
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckExistingProductionNumber = CInt(CheckExistingProductionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckExistingProductionNumber = 0
        End Try
        con.Close()

        If CheckExistingProductionNumber = 0 Then
            'Start New Production Record

            'Write to header table
            cmd = New SqlCommand("INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status) values (@ProductionNumber, @FOXNumber, @StartDate, @ProductionQuantity, @Status)", con)

            With cmd.Parameters
                .Add("@ProductionNumber", SqlDbType.VarChar).Value = 80316
                .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                .Add("@StartDate", SqlDbType.VarChar).Value = Today()
                '.Add("@EndDate", SqlDbType.VarChar).Value = ""
                .Add("@ProductionQuantity", SqlDbType.VarChar).Value = ProductionQuantity
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Add Routing
            For Each row As DataGridViewRow In dgvFoxProcesses.Rows
                Try
                    RowProcessStepNumber = row.Cells("ProcessStepColumn").Value
                Catch ex As Exception
                    RowProcessStepNumber = 0
                End Try
                Try
                    RowProcessID = row.Cells("ProcessIDColumn").Value
                Catch ex As Exception
                    RowProcessID = ""
                End Try
                Try
                    RowAddToFG = row.Cells("ProcessAddFGColumn").Value
                Catch ex As Exception
                    RowAddToFG = "NO"
                End Try

                'Write to Line Table
                cmd = New SqlCommand("INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) values (@ProductionNumber, @FOXNumber, @ProcessStep, @ProcessID, @ProcessAddFG)", con)

                With cmd.Parameters
                    .Add("@ProductionNumber", SqlDbType.VarChar).Value = 80316
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                    .Add("@ProcessStep", SqlDbType.VarChar).Value = RowProcessStepNumber
                    .Add("@ProcessID", SqlDbType.VarChar).Value = RowProcessID
                    .Add("@ProcessAddFG", SqlDbType.VarChar).Value = RowAddToFG
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next
        Else
            'Delete old production entry then create new production record
            cmd = New SqlCommand("DELETE FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber", con)

            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Write to header table
            cmd = New SqlCommand("INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status) values (@ProductionNumber, @FOXNumber, @StartDate, @ProductionQuantity, @Status)", con)

            With cmd.Parameters
                .Add("@ProductionNumber", SqlDbType.VarChar).Value = 80316
                .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                .Add("@StartDate", SqlDbType.VarChar).Value = Today()
                '.Add("@EndDate", SqlDbType.VarChar).Value = ""
                .Add("@ProductionQuantity", SqlDbType.VarChar).Value = ProductionQuantity
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Add Routing
            For Each row As DataGridViewRow In dgvFoxProcesses.Rows
                Try
                    RowProcessStepNumber = row.Cells("ProcessStepColumn").Value
                Catch ex As Exception
                    RowProcessStepNumber = 0
                End Try
                Try
                    RowProcessID = row.Cells("ProcessIDColumn").Value
                Catch ex As Exception
                    RowProcessID = ""
                End Try
                Try
                    RowAddToFG = row.Cells("ProcessAddFGColumn").Value
                Catch ex As Exception
                    RowAddToFG = "NO"
                End Try

                'Write to Line Table
                cmd = New SqlCommand("INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) values (@ProductionNumber, @FOXNumber, @ProcessStep, @ProcessID, @ProcessAddFG)", con)

                With cmd.Parameters
                    .Add("@ProductionNumber", SqlDbType.VarChar).Value = 80316
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                    .Add("@ProcessStep", SqlDbType.VarChar).Value = RowProcessStepNumber
                    .Add("@ProcessID", SqlDbType.VarChar).Value = RowProcessID
                    .Add("@ProcessAddFG", SqlDbType.VarChar).Value = RowAddToFG
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next
        End If

        LoadProductionProcesses()

        MsgBox("FOX Routing re-written to production table.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub ProductionOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionOrderToolStripMenuItem.Click
        GlobalFOXNumber = Val(cboFOXNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintProductionOrder02 As New PrintProductionOrderNew
            Dim result = NewPrintProductionOrder02.ShowDialog
        End Using
    End Sub

    Private Sub gpxFOXData_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpxFOXData.Enter

    End Sub

    Private Sub txtProductionNote_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductionNote.LostFocus
        If Len(txtProductionNote.Text) - Len(Replace(txtProductionNote.Text, vbCrLf, "")) > 4 Then
            MsgBox("More than 3 lines will not show on a production order.", MsgBoxStyle.OkOnly)
        End If
    End Sub

End Class