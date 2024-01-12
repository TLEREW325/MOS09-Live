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
Public Class InventoryValuation
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim ValuationDate As Date
    Dim InventoryTotalCost, FIFOTotalUnits, FIFOTotalCost As Double
    Dim InventoryTotalUnits, LowerLimit, NextLowerLimit, UpperLimit, NextUpperLimit As Double
    Dim SerializedAssembly, PurchaseProdLine, GLAccount, ItemClass, PreferredVendor, VendorClass As String
    Dim ConsignmentDivision As String = ""
    Dim MAXCostingDate As Date
    Dim GetSerialCost As Double = 0

    'Variables for WeldStuds
    Dim HeadedTotal, NoHeadTotal, DebarTotal, WeldStudTotal As Double

    'Defaults

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

    Private Sub InventoryValuation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Auto-close division
        Try
            cmd = New SqlCommand("UPDATE InventoryValuationTempADD SET Status = @Status WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE InventoryValuationTempSUBTRACT SET Status = @Status WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Now()
            ErrorDescription = "Inventory Valuation - Close on exit."
            ErrorUser = EmployeeLoginName
            ErrorComment = "Failed to close/reset division - Contact admin."
            ErrorDivision = cboDivisionID.Text
            ErrorReferenceNumber = ""

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub InventoryValuation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ValuationDate = dtpValuationDate.Value
        dgvFIFOInventory.Visible = False
        dgvInventoryTotals.Visible = False
        dgvInventorySteelValue.Visible = False
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

    Public Sub ClearDatagrids()
        dgvFIFOInventory.DataSource = Nothing
        dgvInventorySteelValue.DataSource = Nothing
        dgvInventoryTotals.DataSource = Nothing
        dgvInventoryTransactions.DataSource = Nothing
        dgvInventoryValuation.DataSource = Nothing
    End Sub

    'Load datasets 

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND TransactionDate <= @ValuationDate AND Quantity <> 0", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ValuationDate", SqlDbType.VarChar).Value = ValuationDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryTransactionTable")
        dgvInventoryTransactions.DataSource = ds.Tables("InventoryTransactionTable")
        con.Close()
    End Sub

    Public Sub ShowInventoryValue()
        cmd = New SqlCommand("SELECT * FROM InventoryValuationSummary WHERE DivisionID = @DivisionID AND NetQuantity <> 0", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "InventoryValuationSummary")
        dgvInventoryValuation.DataSource = ds1.Tables("InventoryValuationSummary")
        con.Close()
    End Sub

    Public Sub ShowFIFOValue()
        cmd = New SqlCommand("SELECT * FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "InventoryFIFOValuation")
        dgvFIFOInventory.DataSource = ds2.Tables("InventoryFIFOValuation")
        con.Close()
    End Sub

    Public Sub ShowDataConsignment()
        cmd = New SqlCommand("SELECT * FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND TransactionDate <= @ValuationDate AND Quantity <> 0", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
        cmd.Parameters.Add("@ValuationDate", SqlDbType.VarChar).Value = ValuationDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "InventoryTransactionTable")
        dgvInventoryTransactions.DataSource = ds3.Tables("InventoryTransactionTable")
        con.Close()
    End Sub

    Public Sub ShowInventoryValueConsignment()
        cmd = New SqlCommand("SELECT * FROM InventoryValuationSummary WHERE DivisionID = @DivisionID AND NetQuantity <> 0", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "InventoryValuationSummary")
        dgvInventoryValuation.DataSource = ds4.Tables("InventoryValuationSummary")
        con.Close()
    End Sub

    Public Sub ShowWeldStuds()
        'Define Fields to display
        Dim DisplayFields, FilterFields As String

        DisplayFields = "ItemID, ShortDescription, DivisionID, QuantityOnHand, OpenSOQuantity, OpenPOQuantity, ItemClass, TotalShipQuantityPending, LastYearShippedToDate"

        FilterFields = " AND (ItemClass = 'TW CA' OR ItemClass = 'TW CD' OR ItemClass = 'TW SC' OR ItemClass = 'TW DS' OR ItemClass = 'TW DB' OR ItemClass = 'TW CS' OR ItemClass = 'TW IT' OR ItemClass = 'TW PS' OR ItemClass = 'TW NT' OR ItemClass = 'TW TD' OR ItemClass = 'TW TF' OR ItemClass = 'TW TP' OR ItemClass = 'TW TT' OR ItemClass = 'TW TR') "

        cmd = New SqlCommand("SELECT " + DisplayFields + " FROM ADMInventoryTotal WHERE DivisionID = @DivisionID AND QuantityOnHand <> 0" + FilterFields + "ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ADMInventoryTotal")
        dgvInventoryTotals.DataSource = ds5.Tables("ADMInventoryTotal")
        con.Close()
    End Sub

    Public Sub ShowFIFOValueConsignment()
        cmd = New SqlCommand("SELECT * FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "InventoryFIFOValuation")
        dgvFIFOInventory.DataSource = ds6.Tables("InventoryFIFOValuation")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "ItemList")
        cboPartNumber.DataSource = ds7.Tables("ItemList")
        cboPartDescription.DataSource = ds7.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub ShowSteelValue()
        cmd = New SqlCommand("SELECT * FROM InventorySteelValuation WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "InventorySteelValuation")
        dgvInventorySteelValue.DataSource = ds8.Tables("InventorySteelValuation")
        con.Close()
    End Sub

    'Load Fields, routines, variables

    Public Sub LoadInventoryFIFOValue()
        Dim CountItems, GetMaxTransactionNumber, MAXTransactionDate As Integer
        Dim GetUpperLimit, QuantityRemaining As Double

        Dim CountItemsStatement As String = "SELECT COUNT(ItemID) FROM InventoryValuationSummary WHERE DivisionID = @DivisionID"
        Dim CountItemsCommand As New SqlCommand(CountItemsStatement, con)
        CountItemsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountItems = CInt(CountItemsCommand.ExecuteScalar)
        Catch ex As Exception
            CountItems = 0
        End Try
        con.Close()

        Me.pbFIFOBar.Maximum = CountItems
        Me.pbFIFOBar.Minimum = 0
        Me.pbFIFOBar.Step = 2

        Me.pbFIFOBar.Increment(4)

        Me.pbFIFOBar.PerformStep()

        Dim PartNumber, PartDescription As String
        Dim QuantityOnHand As Double = 0
        Dim FIFOCost As Double = 0
        Dim FIFOExtendedAmount As Double = 0
        Dim StandardCost As Double = 0
        Dim LastPurchaseCost As Double = 0
        Dim TransactionCost As Double = 0
        Dim MaxDate As Integer

        'Delete Temp Tables
        cmd = New SqlCommand("Delete FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        For Each row As DataGridViewRow In dgvInventoryValuation.Rows
            Try
                PartNumber = row.Cells("VSItemIDColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = row.Cells("VSShortDescriptionColumn").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                QuantityOnHand = row.Cells("VSNetQuantityColumn").Value
            Catch ex As Exception
                QuantityOnHand = 0
            End Try

            'Check if QOH is less than .1 and greater than zero or more than -.1 and less than zero
            If (QuantityOnHand > 0 And QuantityOnHand < 0.1) Or (QuantityOnHand > -0.1 And QuantityOnHand < 0) Then
                QuantityOnHand = 0
            End If

            Me.pbFIFOBar.PerformStep()
            '******************************************************************************************************************************************
            'Get Item Class
            Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
            ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
            ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ItemClass = CStr(ItemClassCommand.ExecuteScalar)
            Catch ex As Exception
                ItemClass = "TW CA"
            End Try
            con.Close()

            'Get GL Account for part
            Dim GLAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
            Dim GLAccountCommand As New SqlCommand(GLAccountStatement, con)
            GLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GLAccount = CStr(GLAccountCommand.ExecuteScalar)
            Catch ex As Exception
                GLAccount = "12100"
            End Try
            con.Close()

            If cboDivisionID.Text = "TWE" Then
                Dim PurchaseProdLineStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim PurchaseProdLineCommand As New SqlCommand(PurchaseProdLineStatement, con)
                PurchaseProdLineCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                PurchaseProdLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PurchaseProdLine = CStr(PurchaseProdLineCommand.ExecuteScalar)
                Catch ex As Exception
                    PurchaseProdLine = ""
                End Try
                con.Close()

                If PurchaseProdLine = "ASSEMBLY" Then
                    'Dim SerializedAssemblyStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    'Dim SerializedAssemblyCommand As New SqlCommand(SerializedAssemblyStatement, con)
                    'SerializedAssemblyCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                    'SerializedAssemblyCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    'If con.State = ConnectionState.Closed Then con.Open()
                    'Try
                    '    SerializedAssembly = CStr(SerializedAssemblyCommand.ExecuteScalar)
                    'Catch ex As Exception
                    '    SerializedAssembly = "NO"
                    'End Try
                    'con.Close()

                    SerializedAssembly = "NO"
                Else
                    SerializedAssembly = "NO"
                End If
            Else
                'Skip
            End If
            '******************************************************************************************************************************************
            'Select American or Canadian Vendor to determine Inventory Account
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                Dim PreferredVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim PreferredVendorCommand As New SqlCommand(PreferredVendorStatement, con)
                PreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                PreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PreferredVendor = CStr(PreferredVendorCommand.ExecuteScalar)
                Catch ex As Exception
                    PreferredVendor = "AMERICAN"
                End Try
                con.Close()

                If PreferredVendor = "AMERICAN" Then
                    'GL is American Style
                ElseIf PreferredVendor = "CANADIAN" Then
                    GLAccount = "C$" + GLAccount
                Else
                    'Get Vendor Class of Vendor
                    Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                    Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
                    VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = PreferredVendor
                    VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VendorClass = CStr(VendorClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        VendorClass = "AMERICAN"
                    End Try
                    con.Close()

                    If VendorClass = "AMERICAN" Then
                        'GL Account is American
                    Else
                        GLAccount = "C$" + GLAccount
                    End If
                End If
            Else
                'Skip - use American GL Accounts
            End If

            '******************************************************************************************************************************************
            'Get FIFO Cost of Part
            '******************************************************************************************************************************************
            'Determine FIFO Cost on Part Number to remove from Inventory
            Dim TotalQuantityShipped As Double = 0
            Dim WasTQSZero As String = ""
            Dim NoCostTierFound As String = "FALSE"
            FIFOCost = 0
            FIFOExtendedAmount = 0
            '******************************************************************************************************************************************
            'If Division = TWE and it is a serialized assembly, then get serial cost
            If cboDivisionID.Text = "TWE" And SerializedAssembly = "YES" Then
                Dim GetSerialCostStatement As String = "SELECT SUM(TotalCost) FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status"
                Dim GetSerialCostCommand As New SqlCommand(GetSerialCostStatement, con)
                GetSerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                GetSerialCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetSerialCostCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSerialCost = CDbl(GetSerialCostCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSerialCost = 0
                End Try
                con.Close()

                FIFOExtendedAmount = GetSerialCost
            ElseIf cboDivisionID.Text = "CHT" And (ItemClass = "WC WIP" Or ItemClass = "WC RAW MATERIALS") Then
                'Get Highest Cost Tier for the specified date
                Dim MAXCostingDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
                Dim MAXCostingDateCommand As New SqlCommand(MAXCostingDateStatement, con)
                MAXCostingDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                MAXCostingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXCostingDateCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = ValuationDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXCostingDate = CDate(MAXCostingDateCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXCostingDate = Today()
                End Try
                con.Close()

                Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
                Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MAXCostingDate

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
                GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
                Catch ex As Exception
                    GetUpperLimit = 0
                End Try
                con.Close()

                'Subtract current quantity on had from MAX Quantity (Highest Upper Limit for that date) to estimate TQS
                TotalQuantityShipped = GetUpperLimit - QuantityOnHand

                'Get Cost for Part for that tier
                Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND (@TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit OR @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit)"
                Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                ItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    FIFOCost = CDbl(ItemCostCommand.ExecuteScalar)
                Catch ex As Exception
                    FIFOCost = 0
                End Try
                con.Close()

                If FIFOCost = 0 Then
                    'Get Standard Cost from Item Maintenance
                    Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                    StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        FIFOCost = CDbl(StandardCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        FIFOCost = 0
                    End Try
                    con.Close()

                    FIFOExtendedAmount = FIFOCost * QuantityOnHand
                Else
                    FIFOExtendedAmount = FIFOCost * QuantityOnHand
                End If
            Else       'Normal FIFO Routine
                'Determine Total Quantity Shipped
                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship AND LineStatus <> @LineStatus"
                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = ValuationDate
                TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"
                TotalQuantityShippedCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalQuantityShipped = 0
                End Try
                con.Close()
                '******************************************************************************************************************************************
                'Add Total Quantity used in assemblies
                Dim BuildQuantity As Double = 0

                Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND ComponentPartNumber <> AssemblyPartNumber AND DivisionID = @DivisionID AND BuildDate <= @BuildDate"
                Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
                TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = PartNumber
                TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                TotalBuildQuantityCommand.Parameters.Add("@BuildDate", SqlDbType.VarChar).Value = ValuationDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    BuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
                Catch ex As Exception
                    BuildQuantity = 0
                End Try
                con.Close()

                BuildQuantity = BuildQuantity * -1

                TotalQuantityShipped = TotalQuantityShipped + BuildQuantity
                '******************************************************************************************************************************************
                'Check to see if Total Quantity Shipped falls within the Cost Tiers
                Dim MAXCostingDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
                Dim MAXCostingDateCommand As New SqlCommand(MAXCostingDateStatement, con)
                MAXCostingDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                MAXCostingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXCostingDateCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXCostingDate = CDate(MAXCostingDateCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXCostingDate = Today()
                End Try
                con.Close()

                Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
                Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MAXCostingDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMaxTransactionNumber = 0
                End Try
                con.Close()

                Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
                GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber
                GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
                Catch ex As Exception
                    GetUpperLimit = 0
                End Try
                con.Close()

                If TotalQuantityShipped + QuantityOnHand - 1 > GetUpperLimit Then
                    'Item is beyond the Cost Tier - skip FIFO
                    FIFOCost = 0
                    FIFOExtendedAmount = 0

                    'If Insert fails, write error message to database

                    ErrorDate = Today()
                    ErrorComment = PartNumber + " valuation is past the Cost Tier"
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory QOH -- " + CStr(QuantityOnHand) + ", TQS -- " + CStr(TotalQuantityShipped) + ", Highest Cost Tier -- " + CStr(GetUpperLimit)
                    ErrorReferenceNumber = "Valuation Date -- " + dtpValuationDate.Text.ToString
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                Else     'Continue with FIFO Costing
                    '******************************************************************************************************************************************
                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                    If TotalQuantityShipped = 0 Then
                        TotalQuantityShipped = 1
                        WasTQSZero = "YES"
                    Else
                        WasTQSZero = "NO"
                    End If

                    'Get Max Transaction Number where Lower is less than than upper
                    Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                    Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
                    GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                    GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
                    Catch ex As Exception
                        GetMaxTransactionNumber = 0
                    End Try
                    con.Close()

                    If GetMaxTransactionNumber = 0 Then
                        'Get Max Transaction Number where Upper is less than than Lower
                        Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit"
                        Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                        GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                        GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetMaxTransactionNumber = CInt(GetMaxTransactionNumber2Command.ExecuteScalar)
                        Catch ex As Exception
                            GetMaxTransactionNumber = 0
                        End Try
                        con.Close()
                    End If

                    If GetMaxTransactionNumber = 0 Then
                        NoCostTierFound = "TRUE"
                        FIFOCost = 0
                        FIFOExtendedAmount = 0
                    Else
                        Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                        Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                        ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                            'Do nothing
                        End If

                        If TotalQuantityShipped + QuantityOnHand > UpperLimit Then
                            'Quantity crosses a cost tier
                            QuantityRemaining = (TotalQuantityShipped + QuantityOnHand) - UpperLimit

                            FIFOExtendedAmount = (UpperLimit - TotalQuantityShipped) * FIFOCost

                            'Create loop to calculate remainder of quantity
                            Do While QuantityRemaining > 0
                                Dim TempQuantity As Double = 0

                                'Get Max Transaction Number where Lower is less than Upper Limit
                                Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                                GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumber2Command.ExecuteScalar)
                                Catch ex As Exception
                                    GetMaxTransactionNumber = 0
                                End Try
                                con.Close()

                                If GetMaxTransactionNumber = 0 Then
                                    'Get Max Transaction Number where Upper is less than Lower Limit 
                                    Dim GetMaxTransactionNumber3Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit"
                                    Dim GetMaxTransactionNumber3Command As New SqlCommand(GetMaxTransactionNumber3Statement, con)
                                    GetMaxTransactionNumber3Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    GetMaxTransactionNumber3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    GetMaxTransactionNumber3Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    GetMaxTransactionNumber3Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber3Command.ExecuteScalar)
                                    Catch ex As Exception
                                        GetMaxTransactionNumber = 0
                                    End Try
                                    con.Close()
                                End If

                                If GetMaxTransactionNumber = 0 Then
                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        FIFOCost = CDbl(NextItemCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        FIFOCost = 0
                                    End Try
                                    con.Close()

                                    If FIFOCost = 0 Then
                                        Dim NextItemCost1Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit"
                                        Dim NextItemCost1Command As New SqlCommand(NextItemCost1Statement, con)
                                        NextItemCost1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        NextItemCost1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        NextItemCost1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                        NextItemCost1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            FIFOCost = CDbl(NextItemCost1Command.ExecuteScalar)
                                        Catch ex As Exception
                                            FIFOCost = 0
                                        End Try
                                        con.Close()
                                    End If

                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        NextUpperLimit = CDbl(NextUpperLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextUpperLimit = 0
                                    End Try
                                    con.Close()

                                    If NextUpperLimit = 0 Then
                                        Dim NextUpperLimit1Statement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit"
                                        Dim NextUpperLimit1Command As New SqlCommand(NextUpperLimit1Statement, con)
                                        NextUpperLimit1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        NextUpperLimit1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        NextUpperLimit1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                        NextUpperLimit1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            NextUpperLimit = CDbl(NextUpperLimit1Command.ExecuteScalar)
                                        Catch ex As Exception
                                            NextUpperLimit = 0
                                        End Try
                                        con.Close()
                                    End If

                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        NextLowerLimit = CDbl(NextLowerLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextLowerLimit = 0
                                    End Try
                                    con.Close()

                                    If NextLowerLimit = 0 Then
                                        Dim NextLowerLimit1Statement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit"
                                        Dim NextLowerLimit1Command As New SqlCommand(NextLowerLimit1Statement, con)
                                        NextLowerLimit1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        NextLowerLimit1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        NextLowerLimit1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                        NextLowerLimit1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            NextLowerLimit = CDbl(NextLowerLimit1Command.ExecuteScalar)
                                        Catch ex As Exception
                                            NextLowerLimit = 0
                                        End Try
                                        con.Close()
                                    End If
                                Else
                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                '****************************************************************************************************************************************
                'Skip alternative costing methods if item class is FERRULE and division is not TWD
                If ItemClass = "FERRULE" And cboDivisionID.Text <> "TWD" And FIFOCost = 0 Then
                    FIFOExtendedAmount = 0
                Else
                    'Run routine if no FIFO Cost is retrieved - Use Transaction Cost, Last Purchase Cost, STD Cost
                    '*****************************************************************************************************************************************
                    If FIFOExtendedAmount = 0 Then
                        Dim MAXTransactionDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionDate <= @TransactionDate"
                        Dim MAXTransactionDateCommand As New SqlCommand(MAXTransactionDateStatement, con)
                        MAXTransactionDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        MAXTransactionDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        MAXTransactionDateCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = ValuationDate

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MAXTransactionDate = CInt(MAXTransactionDateCommand.ExecuteScalar)
                        Catch ex As Exception
                            MAXTransactionDate = 0
                        End Try
                        con.Close()

                        Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                        Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                        TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXTransactionDate

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            TransactionCost = 0
                        End Try
                        con.Close()


                        FIFOCost = TransactionCost
                        FIFOExtendedAmount = FIFOCost * QuantityOnHand
                    End If
                    '*****************************************************************************************************************************************
                    If FIFOExtendedAmount = 0 Then
                        Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingDate <= @ReceivingDate"
                        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        MAXDateCommand.Parameters.Add("@ReceivingDate", SqlDbType.VarChar).Value = ValuationDate

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
                        LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastPurchaseCost = 0
                        End Try
                        con.Close()

                        FIFOCost = LastPurchaseCost
                        FIFOExtendedAmount = FIFOCost * QuantityOnHand
                    End If
                    '*****************************************************************************************************************************************
                    'If FIFO Cost = 0, pull Standard Cost from Item List
                    If FIFOExtendedAmount = 0 Then
                        Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                        Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                        StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            StandardCost = 0
                        End Try
                        con.Close()

                        FIFOCost = StandardCost
                        FIFOExtendedAmount = FIFOCost * QuantityOnHand
                    End If
                    '*****************************************************************************************************************************************
                End If
            End If

            If QuantityOnHand <> 0 Then
                FIFOCost = FIFOExtendedAmount / QuantityOnHand
                FIFOCost = Math.Round(FIFOCost, 5)
            Else
                FIFOCost = 0
                FIFOExtendedAmount = 0
            End If

            If QuantityOnHand = 0 Then
                'Skip Line
            Else
                'Write to Temp Table
                cmd = New SqlCommand("INSERT INTO InventoryFIFOValuation (PartNumber, Description, DivisionID, QuantityOnHand, FIFOCost, FIFOExtendedAmount, GLAccount, ValuationDate)values(@PartNumber, @Description, @DivisionID, @QuantityOnHand, @FIFOCost, @FIFOExtendedAmount, @GLAccount, @ValuationDate)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@QuantityOnHand", SqlDbType.VarChar).Value = QuantityOnHand
                    .Add("@FIFOCost", SqlDbType.VarChar).Value = FIFOCost
                    .Add("@FIFOExtendedAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                    .Add("@ValuationDate", SqlDbType.VarChar).Value = ValuationDate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
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
            ItemClass = ""
            GLAccount = ""
        Next

        pbFIFOBar.Value = CountItems - 10
    End Sub

    Public Sub LoadInventoryFIFOValueConsignment()
        ValuationDate = dtpValuationDate.Value

        Dim GetMaxTransactionNumber, MAXTransactionDate As Integer
        Dim GetUpperLimit, QuantityRemaining As Double

        Dim PartNumber, PartDescription As String
        Dim QuantityOnHand As Double = 0
        Dim FIFOCost As Double = 0
        Dim FIFOExtendedAmount As Double = 0
        Dim StandardCost As Double = 0
        Dim LastPurchaseCost As Double = 0
        Dim TransactionCost As Double = 0

        'Delete Temp Tables
        cmd = New SqlCommand("Delete FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        For Each row As DataGridViewRow In dgvInventoryValuation.Rows
            Try
                PartNumber = row.Cells("VSItemIDColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = row.Cells("VSShortDescriptionColumn").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                QuantityOnHand = row.Cells("VSNetQuantityColumn").Value
            Catch ex As Exception
                QuantityOnHand = 0
            End Try

            'Set Consignment Defaults
            Select Case ConsignmentDivision
                Case "BCW"
                    GLAccount = "12610"
                Case "DCW"
                    GLAccount = "12630"
                Case "HCW"
                    GLAccount = "12620"
                Case "LCW"
                    GLAccount = "12650"
                Case "PCW"
                    GLAccount = "12660"
                Case "YCW"
                    GLAccount = "12600"
                Case "SCW"
                    GLAccount = "12640"
            End Select

            Me.pbFIFOBar.PerformStep()
            '******************************************************************************************************************************************
            '******************************************************************************************************************************************
            'Get FIFO Cost of Part
            '******************************************************************************************************************************************
            'Determine FIFO Cost on Part Number to remove from Inventory
            Dim TotalQuantityBilled As Double = 0
            Dim NoCostTierFound As String = "FALSE"
            FIFOCost = 0
            FIFOExtendedAmount = 0
            '******************************************************************************************************************************************
            'Determine Total Quantity Billed
            Dim TotalQuantityBilledStatement As String = "SELECT SUM(QuantityBilled) FROM ConsignmentBillingTable WHERE PartNumber = @PartNumber AND CustomerClass = @CustomerClass AND BillDate <= @BillDate"
            Dim TotalQuantityBilledCommand As New SqlCommand(TotalQuantityBilledStatement, con)
            TotalQuantityBilledCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            TotalQuantityBilledCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = ConsignmentDivision
            TotalQuantityBilledCommand.Parameters.Add("@BillDate", SqlDbType.VarChar).Value = ValuationDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalQuantityBilled = CDbl(TotalQuantityBilledCommand.ExecuteScalar)
            Catch ex As Exception
                TotalQuantityBilled = 0
            End Try
            con.Close()
            '******************************************************************************************************************************************
            'Check to see if Total Quantity Billed falls within the Cost Tiers
            Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
            Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
            GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
            GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = ValuationDate

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

            If TotalQuantityBilled + QuantityOnHand > GetUpperLimit Then
                'Item is beyond the Cost Tier - skip FIFO
                FIFOCost = 0
                FIFOExtendedAmount = 0
            Else
                '******************************************************************************************************************************************
                'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                If TotalQuantityBilled = 0 Then TotalQuantityBilled = 1
                'Get Max Transaction Number where 
                Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
                GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityBilled
                GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

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
                    Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber"
                    Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                    ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    ItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                    Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber"
                    Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                    UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
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
                    If TotalQuantityBilled + QuantityOnHand > UpperLimit Then
                        'Quantity crosses a cost tier
                        QuantityRemaining = (TotalQuantityBilled + QuantityOnHand) - UpperLimit

                        FIFOExtendedAmount = (UpperLimit - TotalQuantityBilled) * FIFOCost

                        'Create loop to calculate remainder of quantity
                        Do While QuantityRemaining > 0
                            Dim TempQuantity As Double = 0

                            'Get Max Transaction Number where 
                            Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                            Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                            GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                            GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                            GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

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
                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

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
                                Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                                NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
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

            'Run routine if no FIFO Cost is retrieved - Use LPC, TC, STD Cost
            '*****************************************************************************************************************************************
            If FIFOExtendedAmount = 0 Then
                Dim MAXTransactionDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionDate <= @TransactionDate"
                Dim MAXTransactionDateCommand As New SqlCommand(MAXTransactionDateStatement, con)
                MAXTransactionDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXTransactionDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                MAXTransactionDateCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = ValuationDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXTransactionDate = CInt(MAXTransactionDateCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXTransactionDate = 0
                End Try
                con.Close()

                Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXTransactionDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                Catch ex As Exception
                    TransactionCost = 0
                End Try
                con.Close()

                FIFOCost = TransactionCost
                FIFOExtendedAmount = FIFOCost * QuantityOnHand
            End If
            '*****************************************************************************************************************************************
            'If FIFO Cost = 0, pull Standard Cost from Item List
            If FIFOCost = 0 Then
                Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                Catch ex As Exception
                    StandardCost = 0
                End Try
                con.Close()

                FIFOCost = StandardCost
                FIFOExtendedAmount = FIFOCost * QuantityOnHand
            End If
            '*****************************************************************************************************************************************
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
                .Add("@ValuationDate", SqlDbType.VarChar).Value = ValuationDate
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
            TotalQuantityBilled = 0
            UpperLimit = 0
            LowerLimit = 0
            QuantityOnHand = 0
            GetUpperLimit = 0
            GetMaxTransactionNumber = 0
            PartNumber = ""
            PartDescription = ""
            ItemClass = ""
            GLAccount = ""
        Next
    End Sub

    Public Sub LoadWeldStudFIFOValue()
        Dim GetMaxTransactionNumber, MaxTransactionDate As Integer
        Dim GetUpperLimit, QuantityRemaining As Double
        Dim ItemClassType As String

        'Dim CountItemsStatement As String = "SELECT COUNT(ItemID) FROM ADMInventory WHERE DivisionID = @DivisionID AND (ItemClass = 'TW CA' OR ItemClass = 'TW CD' OR ItemClass = 'TW SC' OR ItemClass = 'TW DS' OR ItemClass = 'TW DB' OR ItemClass = 'TW CS' OR ItemClass = 'TW IT' OR ItemClass = 'TW PS' OR ItemClass = 'TW NT' OR ItemClass = 'TW TD' OR ItemClass = 'TW TF' OR ItemClass = 'TW TP' OR ItemClass = 'TW TT' OR ItemClass = 'TW TR')"
        'Dim CountItemsCommand As New SqlCommand(CountItemsStatement, con)
        'CountItemsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        'If con.State = ConnectionState.Closed Then con.Open()
        'Try
        '    CountItems = CInt(CountItemsCommand.ExecuteScalar)
        'Catch ex As Exception
        '    CountItems = 0
        'End Try
        'con.Close()

        'Me.pbWeldStudBar.Maximum = CountItems
        'Me.pbWeldStudBar.Minimum = 0
        'Me.pbWeldStudBar.Step = 2

        'Me.pbWeldStudBar.Increment(4)

        'Me.pbWeldStudBar.PerformStep()

        Dim PartNumber, PartDescription, ItemClass As String
        Dim QuantityOnHand, FIFOCost, FIFOExtendedAmount, StandardCost, LastPurchaseCost, TransactionCost As Double
        Dim MaxDate As Integer

        'Delete Temp Tables
        cmd = New SqlCommand("Delete FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        For Each row As DataGridViewRow In dgvInventoryTotals.Rows
            Try
                PartNumber = row.Cells("ITItemIDColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = row.Cells("ITShortDescriptionColumn").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                QuantityOnHand = row.Cells("ITQuantityOnHandColumn").Value
            Catch ex As Exception
                QuantityOnHand = 0
            End Try
            Try
                ItemClass = row.Cells("ITItemClassColumn").Value
            Catch ex As Exception
                ItemClass = 0
            End Try

            'Me.pbWeldStudBar.PerformStep()
            '******************************************************************************************************************************************
            'Get FIFO Cost of Part
            '******************************************************************************************************************************************
            'Determine FIFO Cost on Part Number to remove from Inventory
            Dim TotalQuantityShipped As Double = 0
            Dim NoCostTierFound As String = "FALSE"
            FIFOCost = 0
            FIFOExtendedAmount = 0
            '******************************************************************************************************************************************
            'Determine Total Quantity Shipped
            Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship"
            Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
            TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = ValuationDate
            TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"

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
            GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = ValuationDate

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
            GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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
                'Get Max Transaction Number where 
                Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
                GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

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
                    Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                    Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                    ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                    Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                    Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                    UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    'Skip cost tier
                Else
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
                            GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                            GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

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
                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

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
                                Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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

            'Run routine if no FIFO Cost is retrieved - Use LPC, TC, STD Cost
            '*****************************************************************************************************************************************
            If FIFOCost = 0 Then
                Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

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
                LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                Catch ex As Exception
                    LastPurchaseCost = 0
                End Try
                con.Close()

                FIFOCost = LastPurchaseCost
                FIFOExtendedAmount = FIFOCost * QuantityOnHand
            End If
            '*****************************************************************************************************************************************
            If FIFOExtendedAmount = 0 Then
                Dim MAXTransactionDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionDate <= @TransactionDate"
                Dim MAXTransactionDateCommand As New SqlCommand(MAXTransactionDateStatement, con)
                MAXTransactionDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXTransactionDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                MAXTransactionDateCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = ValuationDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXTransactionDate = CInt(MAXTransactionDateCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXTransactionDate = 0
                End Try
                con.Close()

                Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXTransactionDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                Catch ex As Exception
                    TransactionCost = 0
                End Try
                con.Close()

                FIFOCost = TransactionCost
                FIFOExtendedAmount = FIFOCost * QuantityOnHand
            End If
            '*****************************************************************************************************************************************
            'If FIFO Cost = 0, pull Standard Cost from Item List
            If FIFOCost = 0 Then
                Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                Catch ex As Exception
                    StandardCost = 0
                End Try
                con.Close()

                FIFOCost = StandardCost
                FIFOExtendedAmount = FIFOCost * QuantityOnHand
            End If
            '*****************************************************************************************************************************************
            'Define Item Class Types
            ItemClassType = ""

            Select Case ItemClass
                Case "TW CA"
                    ItemClassType = "HEADED"
                Case "TW CD"
                    ItemClassType = "NO-HEAD"
                Case "TW CS"
                    ItemClassType = "NO-HEAD"
                Case "TW DB"
                    ItemClassType = "DEBAR"
                Case "TW DS"
                    ItemClassType = "HEADED"
                Case "TW IT"
                    ItemClassType = "NO-HEAD"
                Case "TW NT"
                    ItemClassType = "NO-HEAD"
                Case "TW PS"
                    ItemClassType = "HEADED"
                Case "TW SC"
                    ItemClassType = "HEADED"
                Case "TW SH"
                    ItemClassType = "NO-HEAD"
                Case "TW TD"
                    ItemClassType = "NO-HEAD"
                Case "TW TF"
                    ItemClassType = "NO-HEAD"
                Case "TW TP"
                    ItemClassType = "NO-HEAD"
                Case "TW TR"
                    ItemClassType = "NO-HEAD"
                Case "TW TT"
                    ItemClassType = "NO-HEAD"
            End Select

            'Write to Temp Table
            cmd = New SqlCommand("INSERT INTO InventoryFIFOValuation (PartNumber, Description, DivisionID, QuantityOnHand, FIFOCost, FIFOExtendedAmount, GLAccount, ValuationDate)values(@PartNumber, @Description, @DivisionID, @QuantityOnHand, @FIFOCost, @FIFOExtendedAmount, @GLAccount, @ValuationDate)", con)

            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@QuantityOnHand", SqlDbType.VarChar).Value = QuantityOnHand
                .Add("@FIFOCost", SqlDbType.VarChar).Value = FIFOCost
                .Add("@FIFOExtendedAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                .Add("@GLAccount", SqlDbType.VarChar).Value = ItemClassType
                .Add("@ValuationDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
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
            ItemClass = ""
            GLAccount = ""
            ItemClassType = ""
        Next

        'pbWeldStudBar.Value = CountItems - 10
    End Sub

    Public Sub LoadInventoryDataForConsigment()
        Dim PartNumber, PartDescription, TransactionDate As String
        Dim Quantity As Double
        Dim ItemCost, ExtendedCost As Double

        'Delete Temp Tables
        cmd = New SqlCommand("Delete FROM InventoryValuationTempADD WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        cmd = New SqlCommand("Delete FROM InventoryValuationTempSUBTRACT WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Set Consignment Defaults
        Select Case ConsignmentDivision
            Case "BCW"
                GLAccount = "12610"
            Case "DCW"
                GLAccount = "12630"
            Case "HCW"
                GLAccount = "12620"
            Case "LCW"
                GLAccount = "12650"
            Case "PCW"
                GLAccount = "12660"
            Case "YCW"
                GLAccount = "12600"
            Case "SCW"
                GLAccount = "12640"
        End Select

        'Retrieve line data from Inventory Transaction Table
        For Each row As DataGridViewRow In dgvInventoryTransactions.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("TransactionMathColumn")

            If cell.Value = "ADD" Then
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    Quantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    Quantity = 0
                End Try
                Try
                    ItemCost = row.Cells("ItemCostColumn").Value
                Catch ex As Exception
                    ItemCost = 0
                End Try
                Try
                    ExtendedCost = row.Cells("ExtendedCostColumn").Value
                Catch ex As Exception
                    ExtendedCost = 0
                End Try
                Try
                    TransactionDate = row.Cells("TransactionDateColumn").Value
                Catch ex As Exception
                    TransactionDate = ""
                End Try
                '******************************************************************************************************************************************
                'Write ADD Data to Temp Table
                cmd = New SqlCommand("INSERT INTO InventoryValuationTempADD (PartNumber, PartDescription, Quantity, Cost, ExtendedCost, Date, DivisionID, GLAccount)values(@PartNumber, @PartDescription, @Quantity, @Cost, @ExtendedCost, @Date, @DivisionID, @GLAccount)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@Cost", SqlDbType.VarChar).Value = ItemCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                    .Add("@Date", SqlDbType.VarChar).Value = TransactionDate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

            ElseIf cell.Value = "SUBTRACT" Then
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    Quantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    Quantity = 0
                End Try
                Try
                    ItemCost = row.Cells("ItemCostColumn").Value
                Catch ex As Exception
                    ItemCost = 0
                End Try
                Try
                    ExtendedCost = row.Cells("ExtendedCostColumn").Value
                Catch ex As Exception
                    ExtendedCost = 0
                End Try
                Try
                    TransactionDate = row.Cells("TransactionDateColumn").Value
                Catch ex As Exception
                    TransactionDate = ""
                End Try
                '******************************************************************************************************************************************
                'Write SUBTRACT Data to Temp Table
                cmd = New SqlCommand("INSERT INTO InventoryValuationTempSUBTRACT (PartNumber, PartDescription, Quantity, Cost, ExtendedCost, Date, DivisionID, GLAccount)values(@PartNumber, @PartDescription, @Quantity, @Cost, @ExtendedCost, @Date, @DivisionID, @GLAccount)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@Cost", SqlDbType.VarChar).Value = ItemCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                    .Add("@Date", SqlDbType.VarChar).Value = TransactionDate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Do nothing
            End If
        Next
    End Sub

    Public Sub LoadInventoryData()
        'Add inventory items for the specific criteria

        Dim PartNumber, PartDescription, TransactionDate As String
        Dim Quantity As Double
        Dim ItemCost, ExtendedCost As Double

        'Delete Temp Tables
        cmd = New SqlCommand("DELETE FROM InventoryValuationTempADD WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        cmd = New SqlCommand("DELETE FROM InventoryValuationTempSUBTRACT WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Retrieve line data from Inventory Transaction Table
        For Each row As DataGridViewRow In dgvInventoryTransactions.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("TransactionMathColumn")

            If cell.Value = "ADD" Then
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    Quantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    Quantity = 0
                End Try
                Try
                    ItemCost = row.Cells("ItemCostColumn").Value
                Catch ex As Exception
                    ItemCost = 0
                End Try
                Try
                    ExtendedCost = row.Cells("ExtendedCostColumn").Value
                Catch ex As Exception
                    ExtendedCost = 0
                End Try
                Try
                    TransactionDate = row.Cells("TransactionDateColumn").Value
                Catch ex As Exception
                    TransactionDate = ""
                End Try
                '***********************************************************************************************************************************************
                'Get Item Class from the Item List
                Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    ItemClass = "TW CA"
                End Try
                con.Close()

                'Get GL Account from the Item Class
                Dim GetGLAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim GetGLAccountCommand As New SqlCommand(GetGLAccountStatement, con)
                GetGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLAccount = CStr(GetGLAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    GLAccount = "12100"
                End Try
                con.Close()
                '******************************************************************************************************************************************
                'Select American or Canadian Vendor to determine Inventory Account
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    Dim PreferredVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim PreferredVendorCommand As New SqlCommand(PreferredVendorStatement, con)
                    PreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    PreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PreferredVendor = CStr(PreferredVendorCommand.ExecuteScalar)
                    Catch ex As Exception
                        PreferredVendor = "AMERICAN"
                    End Try
                    con.Close()

                    If PreferredVendor = "AMERICAN" Then
                        'GL is American Style
                    ElseIf PreferredVendor = "CANADIAN" Then
                        GLAccount = "C$" + GLAccount
                    Else
                        'Get Vendor Class of Vendor
                        Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                        Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
                        VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = PreferredVendor
                        VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            VendorClass = CStr(VendorClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            VendorClass = "AMERICAN"
                        End Try
                        con.Close()

                        If VendorClass = "AMERICAN" Then
                            'GL Account is American
                        Else
                            GLAccount = "C$" + GLAccount
                        End If
                    End If
                Else
                    'Skip - use American GL Accounts
                End If
                '******************************************************************************************************************************************
                'Write ADD Data to Temp Table
                cmd = New SqlCommand("INSERT INTO InventoryValuationTempADD (PartNumber, PartDescription, Quantity, Cost, ExtendedCost, Date, DivisionID, GLAccount, Status, PrintDate, UserID)values(@PartNumber, @PartDescription, @Quantity, @Cost, @ExtendedCost, @Date, @DivisionID, @GLAccount, @Status, @PrintDate, @UserID)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@Cost", SqlDbType.VarChar).Value = ItemCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                    .Add("@Date", SqlDbType.VarChar).Value = TransactionDate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@PrintDate", SqlDbType.VarChar).Value = Today.ToShortDateString
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear Variables
                PartNumber = ""
                PartDescription = ""
                TransactionDate = ""
                Quantity = 0
                ItemCost = 0
                ExtendedCost = 0
            ElseIf cell.Value = "SUBTRACT" Then
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    Quantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    Quantity = 0
                End Try
                Try
                    ItemCost = row.Cells("ItemCostColumn").Value
                Catch ex As Exception
                    ItemCost = 0
                End Try
                Try
                    ExtendedCost = row.Cells("ExtendedCostColumn").Value
                Catch ex As Exception
                    ExtendedCost = 0
                End Try
                Try
                    TransactionDate = row.Cells("TransactionDateColumn").Value
                Catch ex As Exception
                    TransactionDate = ""
                End Try
                '***********************************************************************************************************************************************
                'Get Item Class from the Item List
                Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    ItemClass = "TW CA"
                End Try
                con.Close()

                'Get GL Account from the Item Class
                Dim GetGLAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim GetGLAccountCommand As New SqlCommand(GetGLAccountStatement, con)
                GetGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLAccount = CStr(GetGLAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    GLAccount = "12100"
                End Try
                con.Close()
                '***********************************************************************************************************************************************
                'Select American or Canadian Vendor to determine Inventory Account
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    Dim PreferredVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim PreferredVendorCommand As New SqlCommand(PreferredVendorStatement, con)
                    PreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    PreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PreferredVendor = CStr(PreferredVendorCommand.ExecuteScalar)
                    Catch ex As Exception
                        PreferredVendor = "AMERICAN"
                    End Try
                    con.Close()

                    If PreferredVendor = "AMERICAN" Then
                        'GL is American Style
                    ElseIf PreferredVendor = "CANADIAN" Then
                        GLAccount = "C$" + GLAccount
                    Else
                        'Get Vendor Class of Vendor
                        Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                        Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
                        VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = PreferredVendor
                        VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            VendorClass = CStr(VendorClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            VendorClass = "AMERICAN"
                        End Try
                        con.Close()

                        If VendorClass = "AMERICAN" Then
                            'GL Account is American
                        Else
                            GLAccount = "C$" + GLAccount
                        End If
                    End If
                Else
                    'Skip - use American GL Accounts
                End If
                '******************************************************************************************************************************************
                'Write SUBTRACT Data to Temp Table
                cmd = New SqlCommand("INSERT INTO InventoryValuationTempSUBTRACT (PartNumber, PartDescription, Quantity, Cost, ExtendedCost, Date, DivisionID, GLAccount, Status, PrintDate, UserID)values(@PartNumber, @PartDescription, @Quantity, @Cost, @ExtendedCost, @Date, @DivisionID, @GLAccount, @Status, @PrintDate, @UserID)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@Cost", SqlDbType.VarChar).Value = ItemCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                    .Add("@Date", SqlDbType.VarChar).Value = TransactionDate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@PrintDate", SqlDbType.VarChar).Value = Today.ToShortDateString
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear Variables
                PartNumber = ""
                PartDescription = ""
                TransactionDate = ""
                Quantity = 0
                ItemCost = 0
                ExtendedCost = 0
                GLAccount = ""
            Else
                'Do nothing
            End If
        Next
    End Sub

    Public Sub LoadInventoryTotal()
        Dim InventoryTotalCostStatement As String = "SELECT SUM(NetCost) FROM InventoryValuationSummary WHERE DivisionID = @DivisionID"
        Dim InventoryTotalCostCommand As New SqlCommand(InventoryTotalCostStatement, con)
        InventoryTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InventoryTotalUnitsStatement As String = "SELECT SUM(NetQuantity) FROM InventoryValuationSummary WHERE DivisionID = @DivisionID"
        Dim InventoryTotalUnitsCommand As New SqlCommand(InventoryTotalUnitsStatement, con)
        InventoryTotalUnitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InventoryTotalCost = CDbl(InventoryTotalCostCommand.ExecuteScalar)
        Catch ex As Exception
            InventoryTotalCost = 0
        End Try
        Try
            InventoryTotalUnits = CDbl(InventoryTotalUnitsCommand.ExecuteScalar)
        Catch ex As Exception
            InventoryTotalUnits = 0
        End Try
        con.Close()

        txtInventoryTotal.Text = FormatCurrency(InventoryTotalCost, 2)
        txtTotalUnits.Text = FormatNumber(InventoryTotalUnits, 0)
    End Sub

    Public Sub LoadInventoryTotalConsignment()
        Dim InventoryTotalCostStatement As String = "SELECT SUM(NetCost) FROM InventoryValuationSummary WHERE DivisionID = @DivisionID"
        Dim InventoryTotalCostCommand As New SqlCommand(InventoryTotalCostStatement, con)
        InventoryTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision

        Dim InventoryTotalUnitsStatement As String = "SELECT SUM(NetQuantity) FROM InventoryValuationSummary WHERE DivisionID = @DivisionID"
        Dim InventoryTotalUnitsCommand As New SqlCommand(InventoryTotalUnitsStatement, con)
        InventoryTotalUnitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InventoryTotalCost = CDbl(InventoryTotalCostCommand.ExecuteScalar)
        Catch ex As Exception
            InventoryTotalCost = 0
        End Try
        Try
            InventoryTotalUnits = CDbl(InventoryTotalUnitsCommand.ExecuteScalar)
        Catch ex As Exception
            InventoryTotalUnits = 0
        End Try
        con.Close()

        txtInventoryTotal.Text = FormatCurrency(InventoryTotalCost, 2)
        txtTotalUnits.Text = FormatNumber(InventoryTotalUnits, 0)
    End Sub

    Public Sub LoadFIFOTotal()
        Dim FIFOTotalCostStatement As String = "SELECT SUM(FIFOExtendedAmount) FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID"
        Dim FIFOTotalCostCommand As New SqlCommand(FIFOTotalCostStatement, con)
        FIFOTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FIFOTotalUnitsStatement As String = "SELECT SUM(QuantityOnHand) FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID"
        Dim FIFOTotalUnitsCommand As New SqlCommand(FIFOTotalUnitsStatement, con)
        FIFOTotalUnitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            FIFOTotalCost = CDbl(FIFOTotalCostCommand.ExecuteScalar)
        Catch ex As Exception
            FIFOTotalCost = 0
        End Try
        Try
            FIFOTotalUnits = CDbl(FIFOTotalUnitsCommand.ExecuteScalar)
        Catch ex As Exception
            FIFOTotalUnits = 0
        End Try
        con.Close()

        txtFIFOTotal.Text = FormatCurrency(FIFOTotalCost, 2)
        txtFIFOQuantity.Text = FormatNumber(FIFOTotalUnits, 0)
    End Sub

    Public Sub LoadFIFOTotalConsignment()
        Dim FIFOTotalCostStatement As String = "SELECT SUM(FIFOExtendedAmount) FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID"
        Dim FIFOTotalCostCommand As New SqlCommand(FIFOTotalCostStatement, con)
        FIFOTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision

        Dim FIFOTotalUnitsStatement As String = "SELECT SUM(QuantityOnHand) FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID"
        Dim FIFOTotalUnitsCommand As New SqlCommand(FIFOTotalUnitsStatement, con)
        FIFOTotalUnitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ConsignmentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            FIFOTotalCost = CDbl(FIFOTotalCostCommand.ExecuteScalar)
        Catch ex As Exception
            FIFOTotalCost = 0
        End Try
        Try
            FIFOTotalUnits = CDbl(FIFOTotalUnitsCommand.ExecuteScalar)
        Catch ex As Exception
            FIFOTotalUnits = 0
        End Try
        con.Close()

        txtFIFOTotal.Text = FormatCurrency(FIFOTotalCost, 2)
        txtFIFOQuantity.Text = FormatNumber(FIFOTotalUnits, 0)
    End Sub

    Public Sub LoadWeldStudTotals()
        Dim HeadedTotalStatement As String = "SELECT SUM(FIFOExtendedAmount) FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID AND GLAccount = @GLAccount"
        Dim HeadedTotalCommand As New SqlCommand(HeadedTotalStatement, con)
        HeadedTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        HeadedTotalCommand.Parameters.Add("@GLAccount", SqlDbType.VarChar).Value = "HEADED"

        Dim NOHeadTotalStatement As String = "SELECT SUM(FIFOExtendedAmount) FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID AND GLAccount = @GLAccount"
        Dim NOHeadTotalCommand As New SqlCommand(NOHeadTotalStatement, con)
        NOHeadTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        NOHeadTotalCommand.Parameters.Add("@GLAccount", SqlDbType.VarChar).Value = "NO-HEAD"

        Dim DebarTotalStatement As String = "SELECT SUM(FIFOExtendedAmount) FROM InventoryFIFOValuation WHERE DivisionID = @DivisionID AND GLAccount = @GLAccount"
        Dim DebarTotalCommand As New SqlCommand(DebarTotalStatement, con)
        DebarTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        DebarTotalCommand.Parameters.Add("@GLAccount", SqlDbType.VarChar).Value = "DEBAR"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            HeadedTotal = CDbl(HeadedTotalCommand.ExecuteScalar)
        Catch ex As Exception
            HeadedTotal = 0
        End Try
        Try
            DebarTotal = CDbl(DebarTotalCommand.ExecuteScalar)
        Catch ex As Exception
            DebarTotal = 0
        End Try
        Try
            NoHeadTotal = CDbl(NOHeadTotalCommand.ExecuteScalar)
        Catch ex As Exception
            NoHeadTotal = 0
        End Try
        con.Close()

        WeldStudTotal = HeadedTotal + NoHeadTotal + DebarTotal

        txtHeadedStuds.Text = FormatCurrency(HeadedTotal, 2)
        txtNonHeadedStuds.Text = FormatCurrency(NoHeadTotal, 2)
        txtDebar.Text = FormatCurrency(DebarTotal, 2)
        txtTotalWeldStuds.Text = FormatCurrency(WeldStudTotal, 2)
    End Sub

    Public Sub LoadInventorySteelValue()
        Dim CountItems As Integer

        Dim CountItemsStatement As String = "SELECT COUNT(ItemID) FROM InventoryValuationSummary WHERE DivisionID = @DivisionID"
        Dim CountItemsCommand As New SqlCommand(CountItemsStatement, con)
        CountItemsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountItems = CInt(CountItemsCommand.ExecuteScalar)
        Catch ex As Exception
            CountItems = 0
        End Try
        con.Close()

        Me.pbSteelBar.Maximum = CountItems
        Me.pbSteelBar.Minimum = 0
        Me.pbSteelBar.Step = 2

        Me.pbSteelBar.Increment(4)

        Me.pbSteelBar.PerformStep()

        Dim PartNumber, PartDescription As String
        Dim QuantityOnHand As Double = 0
        Dim SteelCostUnit As Double = 0
        Dim SteelCostTotal As Double = 0
        Dim PieceWeight As Double = 0
        Dim FOXNumber As Integer
        Dim SteelCarbon, SteelSize, RMID As String

        'Delete Temp Tables
        cmd = New SqlCommand("Delete FROM InventorySteelValuation", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        For Each row As DataGridViewRow In dgvInventoryValuation.Rows
            Try
                PartNumber = row.Cells("VSItemIDColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = row.Cells("VSShortDescriptionColumn").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                QuantityOnHand = row.Cells("VSNetQuantityColumn").Value
            Catch ex As Exception
                QuantityOnHand = 0
            End Try

            Me.pbSteelBar.PerformStep()
            '******************************************************************************************************************************************
            'Get FOX Number for part
            Dim FOXNumberStatement As String = "SELECT MAX(FOXNumber) FROM FOXTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND RMID <> ''"
            Dim FOXNumberCommand As New SqlCommand(FOXNumberStatement, con)
            FOXNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            FOXNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim PieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PieceWeightCommand As New SqlCommand(PieceWeightStatement, con)
            PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
            PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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
            RMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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
            ' Get Current steel usage
            Dim TotalSteelUsage As Double = 0

            Dim GetSteelUsageStatement As String = "SELECT SUM (UsageWeight) FROM SteelUsageTable WHERE RMID = @RMID AND UsageDate <= @UsageDate AND Status = 'POSTED'"
            Dim GetSteelUsageCommand As New SqlCommand(GetSteelUsageStatement, con)
            GetSteelUsageCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RMID
            GetSteelUsageCommand.Parameters.Add("@UsageDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalSteelUsage = CDbl(GetSteelUsageCommand.ExecuteScalar)
            Catch ex As Exception
                TotalSteelUsage = 0
            End Try
            con.Close()
            '********************************************************************************************
            'Get MAX Transaction Number for steel costing for that specific date
            Dim GetMAXTransactionNumber As Integer = 0

            Dim GetMAXTransactionNumberStatement As String = "SELECT MAX (TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate <= @CostingDate AND @TotalSteelUsage BETWEEN LowerLimit AND UpperLimit"
            Dim GetMAXTransactionNumberCommand As New SqlCommand(GetMAXTransactionNumberStatement, con)
            GetMAXTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RMID
            GetMAXTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
            GetMAXTransactionNumberCommand.Parameters.Add("@TotalSteelUsage", SqlDbType.VarChar).Value = TotalSteelUsage

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetMAXTransactionNumber = CInt(GetMAXTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetMAXTransactionNumber = 0
            End Try
            con.Close()
            '********************************************************************************************
            'Get MAX Transaction Number for steel costing for that specific date
            Dim SteelFIFOCost As Double = 0

            Dim SteelFIFOCostStatement As String = "SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber"
            Dim SteelFIFOCostCommand As New SqlCommand(SteelFIFOCostStatement, con)
            SteelFIFOCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RMID
            SteelFIFOCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
            SteelFIFOCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMAXTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SteelFIFOCost = CDbl(SteelFIFOCostCommand.ExecuteScalar)
            Catch ex As Exception
                SteelFIFOCost = 0
            End Try
            con.Close()

            SteelCostUnit = Math.Round(SteelFIFOCost, 5)
            '**********************************************************************************************
            If SteelCostUnit = 0 Then
                cmd = New SqlCommand("SELECT isnull(SteelCostPerPound, 0) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND (SELECT isnull(case when SUM(UsageWeight)=0 then 1 else SUM(UsageWeight) END, 1) FROM SteelUsageTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit;", con)
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelCarbon
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SteelCostUnit = cmd.ExecuteScalar()
                Catch ex As System.Exception
                    SteelCostUnit = 0
                End Try

                If SteelCostUnit = 0 Then
                    cmd = New SqlCommand("SELECT (SteelExtendedCost / isnull(ReceiveWeight, 1)) FROM SteelReceivingLineTable  WHERE SteelReceivingHeaderKey = (SELECT MAX(SteelReceivingHeaderKey) FROM SteelReceivingLineTable  WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize));", con)
                    cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelCarbon
                    cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SteelCostUnit = cmd.ExecuteScalar()
                    Catch ex As System.Exception
                        SteelCostUnit = 0
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
                Dim strFoxNumber As String = CStr(FOXNumber)
                'Error Log
                ErrorDate = Now()
                ErrorDescription = "Steel Valuation for Finished Goods"
                ErrorUser = EmployeeLoginName
                ErrorComment = "Part # -" + PartNumber + " /FOX-" + strFoxNumber + " /RMID-" + RMID + " /Steel Carbon -" + SteelCarbon + " /Steel Size - " + SteelSize
                ErrorDivision = cboDivisionID.Text
                ErrorReferenceNumber = ""

                TFPErrorLogUpdate()
            Else
                'Write to Temp Table
                cmd = New SqlCommand("INSERT INTO InventorySteelValuation (PartNumber, Description, DivisionID, QuantityOnHand, FOXNumber, RMID, SteelCarbon, SteelSize, SteelCostUnit, SteelCostTotal, ValuationDate, PieceWeight)values(@PartNumber, @Description, @DivisionID, @QuantityOnHand, @FOXNumber, @RMID, @SteelCarbon, @SteelSize, @SteelCostUnit, @SteelCostTotal, @ValuationDate, @PieceWeight)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@QuantityOnHand", SqlDbType.VarChar).Value = QuantityOnHand
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
                    .Add("@RMID", SqlDbType.VarChar).Value = RMID
                    .Add("@SteelCarbon", SqlDbType.VarChar).Value = SteelCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize
                    .Add("@SteelCostUnit", SqlDbType.VarChar).Value = SteelCostUnit
                    .Add("@SteelCostTotal", SqlDbType.VarChar).Value = SteelCostTotal
                    .Add("@ValuationDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
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

        pbSteelBar.Value = CountItems - 10
    End Sub

    'Command Buttons

    Private Sub cmdShowFIFOCosting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowFIFOCosting.Click
        'Check Table so two people can't run at the same time, for the same division

        Dim CheckStatusAdd, CheckStatusSubtract, CheckStatusTotal As Integer
        CheckStatusAdd = 0
        CheckStatusSubtract = 0
        CheckStatusTotal = 0

        Dim CheckStatusAddStatement As String = "SELECT COUNT(PartNumber) FROM InventoryValuationTempADD WHERE DivisionID = @DivisionID AND Status = @Status AND PrintDate = @PrintDate"
        Dim CheckStatusAddCommand As New SqlCommand(CheckStatusAddStatement, con)
        CheckStatusAddCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CheckStatusAddCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        CheckStatusAddCommand.Parameters.Add("@PrintDate", SqlDbType.VarChar).Value = Today.ToShortDateString()

        Dim CheckStatusSubtractStatement As String = "SELECT COUNT(PartNumber) FROM InventoryValuationTempSubtract WHERE DivisionID = @DivisionID AND Status = @Status AND PrintDate = @PrintDate"
        Dim CheckStatusSubtractCommand As New SqlCommand(CheckStatusSubtractStatement, con)
        CheckStatusSubtractCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CheckStatusSubtractCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        CheckStatusSubtractCommand.Parameters.Add("@PrintDate", SqlDbType.VarChar).Value = Today.ToShortDateString()

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckStatusAdd = CInt(CheckStatusAddCommand.ExecuteScalar)
        Catch ex As Exception
            CheckStatusAdd = 0
        End Try
        Try
            CheckStatusSubtract = CInt(CheckStatusSubtractCommand.ExecuteScalar)
        Catch ex As Exception
            CheckStatusSubtract = 0
        End Try
        con.Close()

        CheckStatusTotal = CheckStatusAdd + CheckStatusSubtract

        If CheckStatusTotal = 0 Then
            'Contnue - no use in the form
        Else
            MsgBox("Another user is running valuation.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        ShowData()
        LoadInventoryData()
        ShowInventoryValue()
        LoadInventoryTotal()
        MsgBox("Date filter has been applied", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdValueFIFO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValueFIFO.Click
        pbFIFOBar.Visible = True
        LoadInventoryFIFOValue()
        ShowFIFOValue()
        LoadFIFOTotal()
        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
        dgvInventorySteelValue.Visible = False
        pbFIFOBar.Visible = False
    End Sub

    Private Sub cmdViewFIFOValuation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFIFOValuation.Click
        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
        dgvInventoryTotals.Visible = False
    End Sub

    Private Sub cmdViewInventoryValuation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewInventoryValuation.Click
        dgvFIFOInventory.Visible = False
        dgvInventoryTotals.Visible = False
        dgvInventoryValuation.Visible = True
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Auto-close division
        Try
            cmd = New SqlCommand("UPDATE InventoryValuationTempADD SET Status = @Status WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE InventoryValuationTempSUBTRACT SET Status = @Status WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Now()
            ErrorDescription = "Inventory Valuation - Close on exit."
            ErrorUser = EmployeeLoginName
            ErrorComment = "Failed to close/reset division - Contact admin."
            ErrorDivision = cboDivisionID.Text
            ErrorReferenceNumber = ""

            TFPErrorLogUpdate()
        End Try

        ClearDatagrids()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdShowInventorySteel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowInventorySteel.Click
        ShowData()
        LoadInventoryData()
        ShowInventoryValue()
        MsgBox("Date filter has been applied", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdValueInventorySteel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValueInventorySteel.Click
        pbSteelBar.Visible = True
        LoadInventorySteelValue()
        ShowSteelValue()
        dgvFIFOInventory.Visible = False
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
        dgvInventorySteelValue.Visible = True
        pbSteelBar.Visible = False
    End Sub

    Private Sub cmdPrintInventorySteel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintInventorySteel.Click
        GDS = ds8

        Using NewPrintInventorySteelValue As New PrintInventorySteelValue
            Dim result = NewPrintInventorySteelValue.ShowDialog()
        End Using
    End Sub

    Private Sub cmdAddFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFilter.Click
        ShowData()
        MsgBox("Date filter has been applied", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdValueInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValueInventory.Click
        pbInventoryValue.Visible = True

        'Set defaults for progress bar
        Me.pbInventoryValue.Maximum = 100
        Me.pbInventoryValue.Minimum = 0
        Me.pbInventoryValue.Step = 25

        'Me.pbInventoryValue.Increment(3)

        Me.pbInventoryValue.PerformStep()

        LoadInventoryData()
        Me.pbInventoryValue.PerformStep()
        ShowInventoryValue()
        Me.pbInventoryValue.PerformStep()
        LoadInventoryTotal()
        Me.pbInventoryValue.PerformStep()
        dgvFIFOInventory.Visible = False
        dgvInventoryValuation.Visible = True
        dgvInventoryTotals.Visible = False
        pbInventoryValue.Visible = False
    End Sub

    Private Sub cmdShowWeldStuds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowWeldStuds.Click
        ShowWeldStuds()
        dgvFIFOInventory.Visible = False
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = True
        MsgBox("Inventory list is compiled. You may now Value Inventory.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdValueWeldStuds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValueWeldStuds.Click
        'pbWeldStudBar.Visible = True
        LoadWeldStudFIFOValue()
        ShowFIFOValue()
        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
        dgvInventorySteelValue.Visible = False
        LoadWeldStudTotals()
        'pbWeldStudBar.Visible = False
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If dgvFIFOInventory.Visible = False And dgvInventoryValuation.Visible = True Then
            GlobalDivisionCode = cboDivisionID.Text
            Using NewPrintInventoryValuationByDate As New PrintInventoryValuationByDate
                Dim result = NewPrintInventoryValuationByDate.ShowDialog()
            End Using
        Else
            GDS = ds2
            Using NewPrintInventoryFIFOFiltered As New PrintInventoryFIFOFiltered
                Dim result = NewPrintInventoryFIFOFiltered.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdPrintFIFO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintFIFO.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintInventoryFIFOValue As New PrintInventoryFIFOValue
            Dim result = NewPrintInventoryFIFOValue.ShowDialog()
        End Using
    End Sub

    Private Sub cmdGetPartValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetPartValue.Click
        Dim MAXDate, GetMaxTransactionNumber, MAXTransactionDate As Integer
        Dim StandardCost, LastPurchaseCost, TransactionCost, GetUpperLimit, QuantityRemaining, QOH, QuantityADD, QuantitySUBTRACT As Double
        Dim FIFOCost As Double = 0
        Dim FIFOExtendedAmount As Double = 0

        '******************************************************************************************************************************************
        'Get GL Account for part
        Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
        ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ItemClass = CStr(ItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            ItemClass = "TW CA"
        End Try
        con.Close()

        Dim GLAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLAccountCommand As New SqlCommand(GLAccountStatement, con)
        GLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GLAccount = CStr(GLAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLAccount = "12100"
        End Try
        con.Close()

        If cboDivisionID.Text = "TWE" Then
            Dim PurchaseProdLineStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PurchaseProdLineCommand As New SqlCommand(PurchaseProdLineStatement, con)
            PurchaseProdLineCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            PurchaseProdLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PurchaseProdLine = CStr(PurchaseProdLineCommand.ExecuteScalar)
            Catch ex As Exception
                PurchaseProdLine = ""
            End Try
            con.Close()

            If PurchaseProdLine = "ASSEMBLY" Then
                'Dim SerializedAssemblyStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                'Dim SerializedAssemblyCommand As New SqlCommand(SerializedAssemblyStatement, con)
                'SerializedAssemblyCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                'SerializedAssemblyCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                'If con.State = ConnectionState.Closed Then con.Open()
                'Try
                '    SerializedAssembly = CStr(SerializedAssemblyCommand.ExecuteScalar)
                'Catch ex As Exception
                '    SerializedAssembly = "NO"
                'End Try
                'con.Close()

                SerializedAssembly = "NO"
            Else
                SerializedAssembly = "NO"
            End If
        Else
            'Skip
        End If
        '******************************************************************************************************************************************
        'Get QOH from Item
        Dim QuantityADDStatement As String = "SELECT SUM(Quantity) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath AND DivisionID = @DivisionID"
        Dim QuantityADDCommand As New SqlCommand(QuantityADDStatement, con)
        QuantityADDCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        QuantityADDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        QuantityADDCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = ValuationDate
        QuantityADDCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantityADD = CDbl(QuantityADDCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityADD = 0
        End Try
        con.Close()

        Dim QuantitySUBTRACTStatement As String = "SELECT SUM(Quantity) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath AND DivisionID = @DivisionID"
        Dim QuantitySUBTRACTCommand As New SqlCommand(QuantitySUBTRACTStatement, con)
        QuantitySUBTRACTCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        QuantitySUBTRACTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        QuantitySUBTRACTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = ValuationDate
        QuantitySUBTRACTCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantitySUBTRACT = CDbl(QuantitySUBTRACTCommand.ExecuteScalar)
        Catch ex As Exception
            QuantitySUBTRACT = 0
        End Try
        con.Close()

        QOH = QuantityADD - QuantitySUBTRACT

        'Check if QOH is less than .1
        If (QOH > 0 And QOH < 0.1) Or (QOH > -0.1 And QOH < 0) Then
            QOH = 0
        End If
        '******************************************************************************************************************************************
        'Select American or Canadian Vendor to determine Inventory Account
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            Dim PreferredVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PreferredVendorCommand As New SqlCommand(PreferredVendorStatement, con)
            PreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            PreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PreferredVendor = CStr(PreferredVendorCommand.ExecuteScalar)
            Catch ex As Exception
                PreferredVendor = "AMERICAN"
            End Try
            con.Close()

            If PreferredVendor = "AMERICAN" Then
                'GL is American Style
            ElseIf PreferredVendor = "CANADIAN" Then
                GLAccount = "C$" + GLAccount
            Else
                'Get Vendor Class of Vendor
                Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
                VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = PreferredVendor
                VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VendorClass = CStr(VendorClassCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorClass = "AMERICAN"
                End Try
                con.Close()

                If VendorClass = "AMERICAN" Then
                    'GL Account is American
                Else
                    GLAccount = "C$" + GLAccount
                End If
            End If
        Else
            'Skip - use American GL Accounts
        End If
        '******************************************************************************************************************************************
        '******************************************************************************************************************************************
        'Get FIFO Cost of Part
        '******************************************************************************************************************************************
        'Determine FIFO Cost on Part Number to remove from Inventory
        Dim TotalQuantityShipped As Double = 0
        Dim WasTQSZero As String = ""
        Dim NoCostTierFound As String = "FALSE"
        FIFOCost = 0
        FIFOExtendedAmount = 0
        '******************************************************************************************************************************************
        If cboDivisionID.Text = "TWE" And SerializedAssembly = "YES" Then
            Dim GetSerialCostStatement As String = "SELECT SUM(TotalCost) FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status"
            Dim GetSerialCostCommand As New SqlCommand(GetSerialCostStatement, con)
            GetSerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetSerialCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetSerialCostCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetSerialCost = CDbl(GetSerialCostCommand.ExecuteScalar)
            Catch ex As Exception
                GetSerialCost = 0
            End Try
            con.Close()

            If QOH <> 0 Then
                FIFOCost = GetSerialCost / QOH

                FIFOExtendedAmount = GetSerialCost
            Else
                FIFOCost = 0
                FIFOExtendedAmount = 0
            End If
        ElseIf cboDivisionID.Text = "CHT" And (ItemClass = "WC WIP" Or ItemClass = "WC RAW MATERIALS") Then
            'Get Highest Cost Tier for the specified date
            Dim MAXCostingDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
            Dim MAXCostingDateCommand As New SqlCommand(MAXCostingDateStatement, con)
            MAXCostingDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            MAXCostingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXCostingDateCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = ValuationDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXCostingDate = CDate(MAXCostingDateCommand.ExecuteScalar)
            Catch ex As Exception
                MAXCostingDate = Today()
            End Try
            con.Close()

            Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
            Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
            GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MAXCostingDate

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
            GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                GetUpperLimit = 0
            End Try
            con.Close()

            'Subtract current quantity on had from MAX Quantity (Highest Upper Limit for that date) to estimate TQS
            TotalQuantityShipped = GetUpperLimit - QOH

            'Get Cost for Part for that tier
            Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
            Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
            ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
            ItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FIFOCost = CDbl(ItemCostCommand.ExecuteScalar)
            Catch ex As Exception
                FIFOCost = 0
            End Try
            con.Close()

            If FIFOCost = 0 Then
                'Get Standard Cost from Item Maintenance
                Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    FIFOCost = CDbl(StandardCostCommand.ExecuteScalar)
                Catch ex As Exception
                    FIFOCost = 0
                End Try
                con.Close()

                FIFOExtendedAmount = FIFOCost * QOH
            Else
                FIFOExtendedAmount = FIFOCost * QOH
            End If
        Else
            'Determine Total Quantity Shipped
            Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship AND LineStatus <> @LineStatus"
            Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
            TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = ValuationDate
            TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"
            TotalQuantityShippedCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
            Catch ex As Exception
                TotalQuantityShipped = 0
            End Try
            con.Close()
            '******************************************************************************************************************************************
            'Add Total Quantity used in assemblies
            Dim BuildQuantity As Double = 0

            Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND BuildDate <= @BuildDate AND ComponentPartNumber <> AssemblyPartNumber"
            Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
            TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalBuildQuantityCommand.Parameters.Add("@BuildDate", SqlDbType.VarChar).Value = ValuationDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                BuildQuantity = 0
            End Try
            con.Close()

            BuildQuantity = BuildQuantity * -1

            TotalQuantityShipped = TotalQuantityShipped + BuildQuantity
            '******************************************************************************************************************************************
            'Check to see if Total Quantity Shipped falls within the Cost Tiers
            Dim MAXCostingDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
            Dim MAXCostingDateCommand As New SqlCommand(MAXCostingDateStatement, con)
            MAXCostingDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            MAXCostingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXCostingDateCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = ValuationDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXCostingDate = CDate(MAXCostingDateCommand.ExecuteScalar)
            Catch ex As Exception
                MAXCostingDate = Today()
            End Try
            con.Close()

            Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
            Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
            GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MAXCostingDate

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
            GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                GetUpperLimit = 0
            End Try
            con.Close()
            '******************************************************************************************************************************************
            'Check point #1

            'ErrorDate = Today()
            'ErrorComment = "Checkpoint #1"
            'ErrorDivision = cboDivisionID.Text
            'ErrorDescription = "TQS = " + CStr(TotalQuantityShipped) + ", Max Costing Date = " + CStr(MAXCostingDate) + ", Max Trans. # = " + CStr(GetMaxTransactionNumber) + ", Get Upper = " + CStr(GetUpperLimit)
            'ErrorReferenceNumber = "Valuation Date -- " + dtpValuationDate.Text.ToString
            'ErrorUser = EmployeeLoginName

            'TFPErrorLogUpdate()

            'MsgBox("Check Point 1", MsgBoxStyle.OkOnly)
            '******************************************************************************************************************************************
            If TotalQuantityShipped + QOH - 1 > GetUpperLimit Then
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
                    WasTQSZero = "NO"
                End If
                '*****************************************************************************************
                'Get Max Transaction Number where cost tier falls within
                Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND (@TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit OR @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit)"
                Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
                GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

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
                    Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND CostingDate <= @CostingDate"
                    Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                    ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    ItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                    Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND CostingDate <= @CostingDate"
                    Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                    UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
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
                        'Do nothing
                    End If

                    If TotalQuantityShipped + QOH > UpperLimit Then
                        'Quantity crosses a cost tier
                        QuantityRemaining = (TotalQuantityShipped + QOH) - UpperLimit

                        FIFOExtendedAmount = (UpperLimit - TotalQuantityShipped) * FIFOCost

                        'Create loop to calculate remainder of quantity
                        Do While QuantityRemaining > 0
                            Dim TempQuantity As Double = 0

                            'Get Max Transaction Number where 
                            Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND (@TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit OR @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit)"
                            Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                            GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                            GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                            GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetMaxTransactionNumber = CInt(GetMaxTransactionNumber2Command.ExecuteScalar)
                            Catch ex As Exception
                                GetMaxTransactionNumber = 0
                            End Try
                            con.Close()

                            If GetMaxTransactionNumber = 0 Then
                                'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND (@TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit OR @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit)"
                                Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND (@TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit OR @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit)"
                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND (@TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit OR @TotalQuantityShipped BETWEEN UpperLimit AND LowerLimit)"
                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value

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
                                Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                                NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                                NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
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
                        FIFOExtendedAmount = FIFOCost * QOH
                    End If
                End If
            End If
            '****************************************************************************************************************************************
            'Skip alternative costing methods if item class is FERRULE and division is not TWD
            If ItemClass = "FERRULE" And cboDivisionID.Text <> "TWD" And FIFOCost = 0 Then
                FIFOExtendedAmount = 0
            Else
                'Run routine if no FIFO Cost is retrieved - Use Transaction Cost, Last Purchase Cost, STD Cost
                '*****************************************************************************************************************************************
                If FIFOExtendedAmount = 0 Then
                    Dim MAXTransactionDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionDate <= @TransactionDate"
                    Dim MAXTransactionDateCommand As New SqlCommand(MAXTransactionDateStatement, con)
                    MAXTransactionDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    MAXTransactionDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    MAXTransactionDateCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = ValuationDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXTransactionDate = CInt(MAXTransactionDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXTransactionDate = 0
                    End Try
                    con.Close()

                    Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXTransactionDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        TransactionCost = 0
                    End Try
                    con.Close()

                    FIFOCost = TransactionCost
                    FIFOExtendedAmount = FIFOCost * QOH
                End If
                '*****************************************************************************************************************************************
                If FIFOExtendedAmount = 0 Then
                    Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingDate <= @ReceivingDate"
                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    MAXDateCommand.Parameters.Add("@ReceivingDate", SqlDbType.VarChar).Value = ValuationDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXDate = CInt(MAXDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXDate = 0
                    End Try
                    con.Close()

                    Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
                    Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                    LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MAXDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastPurchaseCost = 0
                    End Try
                    con.Close()

                    FIFOCost = LastPurchaseCost
                    FIFOExtendedAmount = FIFOCost * QOH
                End If
                '*****************************************************************************************************************************************
                'If FIFO Cost = 0, pull Standard Cost from Item List
                If FIFOExtendedAmount = 0 Then
                    Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                    Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                    StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        StandardCost = 0
                    End Try
                    con.Close()

                    FIFOCost = StandardCost
                    FIFOExtendedAmount = FIFOCost * QOH
                End If
            End If
        End If
        '*****************************************************************************************************************************************
        If QOH = 0 Then
            FIFOExtendedAmount = 0
        End If

        txtPartQOH.Text = Math.Round(QOH, 2)
        txtPartValue.Text = Math.Round(FIFOExtendedAmount, 2)
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
        QOH = 0
        GetUpperLimit = 0
        GetMaxTransactionNumber = 0
        ItemClass = ""
        GLAccount = ""
    End Sub

    Private Sub cmdPrintByGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintByGL.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalValuationDate = dtpValuationDate.Value

        Using NewPrintInventoryValuationByGL As New PrintInventoryValuationByGL
            Dim result = NewPrintInventoryValuationByGL.ShowDialog()
        End Using
    End Sub


    'Combo Box Events

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
    End Sub

    'Menu Strip Items

    Private Sub ValuationByGLSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValuationByGLSummaryToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalValuationDate = dtpValuationDate.Value

        Using NewPrintInventoryValuationByGL As New PrintInventoryValuationByGL
            Dim result = NewPrintInventoryValuationByGL.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        'Auto-close division
        Try
            cmd = New SqlCommand("UPDATE InventoryValuationTempADD SET Status = @Status WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE InventoryValuationTempSUBTRACT SET Status = @Status WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Now()
            ErrorDescription = "Inventory Valuation - Close on exit."
            ErrorUser = EmployeeLoginName
            ErrorComment = "Failed to close/reset division - Contact admin."
            ErrorDivision = cboDivisionID.Text
            ErrorReferenceNumber = ""

            TFPErrorLogUpdate()
        End Try

        ClearDatagrids()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub BCWValuationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCWValuationToolStripMenuItem.Click
        ConsignmentDivision = "BCW"

        ShowDataConsignment()
        LoadInventoryDataForConsigment()
        ShowInventoryValueConsignment()
        LoadInventoryTotalConsignment()

        MsgBox("Date filter has been applied for this consignment warehouse. Proceed with valuation...", MsgBoxStyle.OkOnly)

        LoadInventoryFIFOValueConsignment()
        ShowFIFOValueConsignment()
        LoadFIFOTotalConsignment()

        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
    End Sub

    Private Sub DCWValuationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCWValuationToolStripMenuItem.Click
        ConsignmentDivision = "DCW"

        ShowDataConsignment()
        LoadInventoryDataForConsigment()
        ShowInventoryValueConsignment()
        LoadInventoryTotalConsignment()

        MsgBox("Date filter has been applied for this consignment warehouse. Proceed with valuation...", MsgBoxStyle.OkOnly)

        LoadInventoryFIFOValueConsignment()
        ShowFIFOValueConsignment()
        LoadFIFOTotalConsignment()

        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
    End Sub

    Private Sub HCWValuationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HCWValuationToolStripMenuItem.Click
        ConsignmentDivision = "HCW"

        ShowDataConsignment()
        LoadInventoryDataForConsigment()
        ShowInventoryValueConsignment()
        LoadInventoryTotalConsignment()

        MsgBox("Date filter has been applied for this consignment warehouse. Proceed with valuation...", MsgBoxStyle.OkOnly)

        LoadInventoryFIFOValueConsignment()
        ShowFIFOValueConsignment()
        LoadFIFOTotalConsignment()

        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
    End Sub

    Private Sub LCWValuationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LCWValuationToolStripMenuItem.Click
        ConsignmentDivision = "LCW"

        ShowDataConsignment()
        LoadInventoryDataForConsigment()
        ShowInventoryValueConsignment()
        LoadInventoryTotalConsignment()

        MsgBox("Date filter has been applied for this consignment warehouse. Proceed with valuation...", MsgBoxStyle.OkOnly)

        LoadInventoryFIFOValueConsignment()
        ShowFIFOValueConsignment()
        LoadFIFOTotalConsignment()

        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
    End Sub

    Private Sub PCWValuationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PCWValuationToolStripMenuItem.Click
        ConsignmentDivision = "PCW"

        ShowDataConsignment()
        LoadInventoryDataForConsigment()
        ShowInventoryValueConsignment()
        LoadInventoryTotalConsignment()

        MsgBox("Date filter has been applied for this consignment warehouse. Proceed with valuation...", MsgBoxStyle.OkOnly)

        LoadInventoryFIFOValueConsignment()
        ShowFIFOValueConsignment()
        LoadFIFOTotalConsignment()

        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
    End Sub

    Private Sub SCWValuationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SCWValuationToolStripMenuItem.Click
        ConsignmentDivision = "SCW"

        ShowDataConsignment()
        LoadInventoryDataForConsigment()
        ShowInventoryValueConsignment()
        LoadInventoryTotalConsignment()

        MsgBox("Date filter has been applied for this consignment warehouse. Proceed with valuation...", MsgBoxStyle.OkOnly)

        LoadInventoryFIFOValueConsignment()
        ShowFIFOValueConsignment()
        LoadFIFOTotalConsignment()

        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
    End Sub

    Private Sub YCWValuationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YCWValuationToolStripMenuItem.Click
        ConsignmentDivision = "YCW"

        ShowDataConsignment()
        LoadInventoryDataForConsigment()
        ShowInventoryValueConsignment()
        LoadInventoryTotalConsignment()

        MsgBox("Date filter has been applied for this consignment warehouse. Proceed with valuation...", MsgBoxStyle.OkOnly)

        LoadInventoryFIFOValueConsignment()
        ShowFIFOValueConsignment()
        LoadFIFOTotalConsignment()

        dgvFIFOInventory.Visible = True
        dgvInventoryValuation.Visible = False
        dgvInventoryTotals.Visible = False
    End Sub

    Private Sub ValuationByToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValuationByToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintInventoryFIFOValue As New PrintInventorySteelValue
            Dim result = NewPrintInventoryFIFOValue.ShowDialog()
        End Using
    End Sub

    Private Sub CloseDivisionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseDivisionToolStripMenuItem.Click
        Try
            'Manually close division for ADD Table
            cmd = New SqlCommand("UPDATE InventoryValuationTempADD SET Status = @Status WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            'Manually close division for SUBTRACT Table
            cmd = New SqlCommand("UPDATE InventoryValuationTempSUBTRACT SET Status = @Status WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Previous value is closed, you may run valuation.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Error Log
            ErrorDate = Now()
            ErrorDescription = "Inventory Valuation - Manual Close"
            ErrorUser = EmployeeLoginName
            ErrorComment = "Failed to close/reset division - Contact admin."
            ErrorDivision = cboDivisionID.Text
            ErrorReferenceNumber = ""

            TFPErrorLogUpdate()

            MsgBox("There is an error closing division - Contact Admin.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    'Other

    Private Sub dtpValuationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpValuationDate.ValueChanged
        ValuationDate = dtpValuationDate.Value
    End Sub
End Class