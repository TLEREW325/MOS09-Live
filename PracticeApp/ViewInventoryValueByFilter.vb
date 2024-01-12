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
Public Class ViewInventoryValueByFilter
    Inherits System.Windows.Forms.Form

    Dim PartFilter, ItemClassFilter, ItemClassTextFilter, ZeroQuantityFilter, Text1Filter, Text2Filter, Text3Filter, Text4Filter, Text5Filter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewInventoryValueByFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        LoadCurrentDivision()

        usefulFunctions.LoadSecurity(Me)
        cboDivisionID.Text = EmployeeCompanyCode
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

    Public Sub ClearDataInDatagrid()
        dgvADMInventoryTotals.DataSource = Nothing
        dgvFIFOCurrentValue.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDescription.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub ShowFIFOCurrentValue()
        cmd = New SqlCommand("SELECT * FROM InventoryFIFOCurrentValue WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "InventoryFIFOCurrentValue")
        dgvFIFOCurrentValue.DataSource = ds2.Tables("InventoryFIFOCurrentValue")
        con.Close()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID >= '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
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
            Text1Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%')"
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

        cmd = New SqlCommand("SELECT ItemID, ShortDescription, QuantityOnHand, TotalShipQuantityPending, LastYearShippedToDate, StandardCost, StandardPrice, MinimumStock, MaximumStock, OpenSOQuantity, OpenPOQuantity, ItemClass FROM ADMInventoryTotal WHERE DivisionID = @DivisionID" + PartFilter + ItemClassFilter + ItemClassTextFilter + ZeroQuantityFilter + Text1Filter + Text2Filter + Text3Filter + Text4Filter + Text5Filter + " ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ADMInventoryTotal")
        dgvADMInventoryTotals.DataSource = ds.Tables("ADMInventoryTotal")
        con.Close()

        dgvADMInventoryTotals.Visible = True
        dgvFIFOCurrentValue.Visible = False
    End Sub

    Public Sub ClearData()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1

        txtClassTextFilter.Clear()
        txtTextFilter1.Clear()
        txtTextFilter2.Clear()
        txtTextFilter3.Clear()
        txtTextFilter4.Clear()
        txtTextFilter5.Clear()

        chkOmit.Checked = False

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        PartFilter = ""
        ItemClassFilter = ""
        ItemClassTextFilter = ""
        ZeroQuantityFilter = ""
        Text1Filter = ""
        Text2Filter = ""
        Text3Filter = ""
        Text4Filter = ""
        Text5Filter = ""
    End Sub

    Public Sub LoadInventoryData()
        Dim PartNumber, PartDescription, ItemClass, TextFilter As String
        Dim QuantityOnHand As Double = 0
        Dim FIFOCost As Double = 0
        Dim FIFOExtendedAmount As Double = 0
        Dim StandardCost As Double = 0
        Dim LastPurchaseCost As Double = 0
        Dim TransactionCost As Double = 0
        Dim MaxDate, GetMaxTransactionNumber As Integer
        Dim GetUpperLimit As Integer = 0
        Dim UpperLimit As Integer = 0
        Dim LowerLimit As Integer = 0
        Dim QuantityRemaining As Double = 0
        Dim NextUpperLimit, NextLowerLimit As Integer
        TextFilter = ""
        ItemClass = ""

        'Delete Temp Tables
        cmd = New SqlCommand("Delete FROM InventoryFIFOCurrentValue WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        For Each row As DataGridViewRow In dgvADMInventoryTotals.Rows
            Try
                PartNumber = row.Cells("ItemIDColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = row.Cells("ShortDescriptionColumn").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                QuantityOnHand = row.Cells("QuantityOnHandColumn").Value
            Catch ex As Exception
                QuantityOnHand = 0
            End Try
            Try
                ItemClass = row.Cells("ItemClassColumn").Value
            Catch ex As Exception
                ItemClass = "TW CA"
            End Try
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
            Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND Dropship <> @Dropship"
            Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
            TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
            Catch ex As Exception
                TotalQuantityShipped = 0
            End Try
            con.Close()
            '******************************************************************************************************************************************
            'Add Total Quantity used in assemblies
            Dim GetBuildQuantity As Double = 0

            Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
            Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
            TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = PartNumber
            TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                GetBuildQuantity = 0
            End Try
            con.Close()

            GetBuildQuantity = GetBuildQuantity * -1

            TotalQuantityShipped = TotalQuantityShipped + GetBuildQuantity
            '******************************************************************************************************************************************
            'Check to see if Total Quantity Shipped falls within the Cost Tiers
            Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
            GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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
                Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
                GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
       
                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
                Catch ex As Exception
                    GetMaxTransactionNumber = 0
                End Try
                con.Close()

                If GetMaxTransactionNumber = 0 Then
                    FIFOCost = 0
                    FIFOExtendedAmount = 0
                    NoCostTierFound = "TRUE"
                Else
                    Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                    Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                    ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                    ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                    Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                    Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                    UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    UpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
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
                    'Skip Cost tiers
                    FIFOCost = 0
                    FIFOExtendedAmount = 0
                Else
                    If TotalQuantityShipped + QuantityOnHand > UpperLimit Then
                        'Quantity crosses a cost tier
                        QuantityRemaining = (TotalQuantityShipped + QuantityOnHand) - UpperLimit

                        FIFOExtendedAmount = (UpperLimit - TotalQuantityShipped) * FIFOCost

                        'Create loop to calculate remainder of quantity
                        Do While QuantityRemaining > 0
                            Dim TempQuantity As Double = 0

                            'Get Max Transaction Number where 
                            Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                            Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                            GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetMaxTransactionNumber = CInt(GetMaxTransactionNumber2Command.ExecuteScalar)
                            Catch ex As Exception
                                GetMaxTransactionNumber = 0
                            End Try
                            con.Close()

                            If GetMaxTransactionNumber = 0 Then
                                'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1

                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1

                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1

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
                                Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
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
                Dim MAXDate2 As Integer = 0

                Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXDate2 = CInt(MAXDateCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXDate2 = 0
                End Try
                con.Close()

                Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE TransactionNumber = @TransactionNumber"
                Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXDate2

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
            'Write to Temp Table
            Try
                cmd = New SqlCommand("INSERT INTO InventoryFIFOCurrentValue (PartNumber, PartDescription, DivisionID, QuantityOnHand, FIFOCost, FIFOExtendedAmount, ItemClass, FilterField)values(@PartNumber, @PartDescription, @DivisionID, @QuantityOnHand, @FIFOCost, @FIFOExtendedAmount, @ItemClass, @FilterField)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@QuantityOnHand", SqlDbType.VarChar).Value = QuantityOnHand
                    .Add("@FIFOCost", SqlDbType.VarChar).Value = FIFOCost
                    .Add("@FIFOExtendedAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                    .Add("@ItemClass", SqlDbType.VarChar).Value = ItemClass
                    .Add("@FilterField", SqlDbType.VarChar).Value = ""
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip
            End Try
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
            TextFilter = ""
        Next
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        dgvADMInventoryTotals.Visible = True
        dgvFIFOCurrentValue.Visible = False
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintStockStatus As New PrintStockStatus
            Dim result = NewPrintStockStatus.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdValueInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValueInventory.Click
        LoadInventoryData()
        ShowFIFOCurrentValue()
        dgvADMInventoryTotals.Visible = False
        dgvFIFOCurrentValue.Visible = True
    End Sub

    Private Sub cmdPrintValueReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintValueReport.Click
        GDS = ds2
        Using NewPrintInventoryValueByFilter As New PrintInventoryValueByFilter
            Dim result = NewPrintInventoryValueByFilter.ShowDialog()
        End Using
    End Sub
End Class