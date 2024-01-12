Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewPartNumberSalesTotals
    Inherits System.Windows.Forms.Form

    Dim TextFilterVariable, GetDescription As String
    Dim OmitFilter, ItemClassFilter, PPLFilter, PartFilter, SPLFilter, Text1Filter, Text2Filter, Text3Filter, Text4Filter, Text5Filter As String

    Dim LastSalesPrice, AverageSalesPrice, LastPurchaseCost, AveragePurchaseCost, TotalQuantitySold, QuantityOnHand As Double
    Dim LastActivityDate As String = ""
    Dim MaxDate1, MaxDate2 As Integer
    Dim PartNumber, PartDescription As String
    Dim TotalSales As Double = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewPartNumberSalesTotals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PurchaseProductLine' table. You can move, or remove it, as needed.
        Me.PurchaseProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PurchaseProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.SalesProductLine' table. You can move, or remove it, as needed.
        Me.SalesProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.SalesProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        LoadCurrentDivision()

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        ClearTempData()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
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
        If cboDivisionID.Text = "ADM" Then
            LoadPartNumberADM()
            LoadPartDescriptionADM()
        Else
            LoadPartNumber()
            LoadPartDescription()
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvItemList.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilter()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboPurchaseProductLine.Text <> "" Then
            PPLFilter = " AND PurchProdLineID LIKE '%" + cboPurchaseProductLine.Text + "%'"
        Else
            PPLFilter = ""
        End If
        If cboSalesProdLine.Text <> "" Then
            SPLFilter = " AND SalesProdLineID LIKE '%" + cboSalesProdLine.Text + "%'"
        Else
            SPLFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass LIKE '%" + cboItemClass.Text + "%'"
        Else
            ItemClassFilter = ""
        End If
        If txtTextFilter1.Text <> "" Then
            Text1Filter = " AND (ShortDescription LIKE '" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%' OR ItemID LIKE '" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%' OR LongDescription LIKE '" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%')"
        Else
            Text1Filter = ""
        End If
        If txtTextFilter2.Text <> "" Then
            Text2Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%' OR LongDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%')"
        Else
            Text2Filter = ""
        End If
        If txtTextFilter3.Text <> "" Then
            Text3Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%' OR LongDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%')"
        Else
            Text3Filter = ""
        End If
        If txtTextFilter4.Text <> "" Then
            Text4Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter4.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter4.Text) + "%' OR LongDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter4.Text) + "%')"
        Else
            Text4Filter = ""
        End If
        If txtTextFilter5.Text <> "" Then
            Text5Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter5.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter5.Text) + "%' OR LongDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter5.Text) + "%')"
        Else
            Text5Filter = ""
        End If
        If chkOmitNonInventory.Checked = True Then
            OmitFilter = " AND PurchProdLineID <> 'NON-INVENTORY'"
        Else
            OmitFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT ItemID FROM ItemList WHERE DivisionID <> @DivisionID" + PartFilter + SPLFilter + PPLFilter + ItemClassFilter + OmitFilter + Text1Filter + Text2Filter + Text3Filter + Text4Filter + Text5Filter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ItemList")
            dgvItemList.DataSource = ds.Tables("ItemList")
            con.Close()
        Else
            cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID" + PartFilter + SPLFilter + PPLFilter + ItemClassFilter + OmitFilter + Text1Filter + Text2Filter + Text3Filter + Text4Filter + Text5Filter + " ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ItemList")
            dgvItemList.DataSource = ds.Tables("ItemList")
            con.Close()
        End If
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

    Public Sub LoadPartNumberADM()
        cmd = New SqlCommand("SELECT DISTINCT ItemID FROM ItemList WHERE DivisionID <> @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartNumber.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescriptionADM()
        cmd = New SqlCommand("SELECT DISTINCT ShortDescription FROM ItemList WHERE DivisionID <> @DivisionID AND ItemClass <> @ItemClass ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboPartDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub ClearTempData()
        cmd = New SqlCommand("SELECT * FROM ItemListSalesDataTemp WHERE PartNumber = @PartNumber", con)
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = "ZZZZZZ"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemListSalesDataTemp")
        dgvSalesData.DataSource = ds5.Tables("ItemListSalesDataTemp")
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

    Public Sub LoadPartByDescriptionADM()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT DISTINCT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID <> @DivisionID"
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

    Public Sub LoadDescriptionByPartADM()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT DISTINCT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID <> @DivisionID"
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
        cboPurchaseProductLine.Text = ""
        cboSalesProdLine.Text = ""
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""

        cboItemClass.SelectedIndex = -1
        cboPurchaseProductLine.SelectedIndex = -1
        cboSalesProdLine.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1

        txtTextFilter1.Clear()
        txtTextFilter2.Clear()
        txtTextFilter3.Clear()
        txtTextFilter4.Clear()
        txtTextFilter5.Clear()

        lblLoading.Visible = False

        cboItemClass.Focus()
    End Sub

    Public Sub ClearVariables()
        TextFilterVariable = ""
        GetDescription = ""
        ItemClassFilter = ""
        PPLFilter = ""
        PartFilter = ""
        SPLFilter = ""
        Text1Filter = ""
        Text2Filter = ""
        Text3Filter = ""
        Text4Filter = ""
        Text5Filter = ""
        LastSalesPrice = 0
        AverageSalesPrice = 0
        LastPurchaseCost = 0
        AveragePurchaseCost = 0
        TotalQuantitySold = 0
        QuantityOnHand = 0
        LastActivityDate = ""
        MaxDate1 = 0
        MaxDate2 = 0
        PartNumber = ""
        PartDescription = ""
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        lblLoading.Visible = True

        'Filter Dataset
        ShowDataByFilter()

        'Delete Temp Data
        cmd = New SqlCommand("DELETE FROM ItemListSalesDataTemp", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()


        For Each row As DataGridViewRow In dgvItemList.Rows
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
            '****************************************************************************************************************************************************

            If cboDivisionID.Text = "ADM" Then
                'Get relevent data and write to temp table
                '************************************************************************************************************************************************
                'Get Last Sales Price
                Dim MAXDate1Statement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE ItemID = @ItemID"
                Dim MAXDate1Command As New SqlCommand(MAXDate1Statement, con)
                MAXDate1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxDate1 = CInt(MAXDate1Command.ExecuteScalar)
                Catch ex As Exception
                    MaxDate1 = 0
                End Try
                con.Close()

                Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
                Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate1

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
                Catch ex As Exception
                    LastSalesPrice = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Last Purchase Cost
                'Load values into Cost Field
                Dim MAXDate2Statement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE PartNumber = @PartNumber"
                Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
                MAXDate2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxDate2 = CInt(MAXDate2Command.ExecuteScalar)
                Catch ex As Exception
                    MaxDate2 = 0
                End Try
                con.Close()

                Dim LastCostStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
                Dim LastCostCommand As New SqlCommand(LastCostStatement, con)
                LastCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                LastCostCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate2

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastPurchaseCost = CDbl(LastCostCommand.ExecuteScalar)
                Catch ex As Exception
                    LastPurchaseCost = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Average Cost
                Dim AverageCostStatement As String = "SELECT AVG(UnitCost) FROM ReceivingLineQuery WHERE PartNumber = @PartNumber"
                Dim AverageCostCommand As New SqlCommand(AverageCostStatement, con)
                AverageCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    AveragePurchaseCost = CDbl(AverageCostCommand.ExecuteScalar)
                Catch ex As Exception
                    AveragePurchaseCost = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Average Price
                Dim AveragePriceStatement As String = "SELECT AVG(Price) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber"
                Dim AveragePriceCommand As New SqlCommand(AveragePriceStatement, con)
                AveragePriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    AverageSalesPrice = CDbl(AveragePriceCommand.ExecuteScalar)
                Catch ex As Exception
                    AverageSalesPrice = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get QOH
                Dim QuantityOnHandStatement As String = "SELECT SUM(QuantityOnHand) FROM ADMInventoryTotal WHERE ItemID = @ItemID"
                Dim QuantityOnHandCommand As New SqlCommand(QuantityOnHandStatement, con)
                QuantityOnHandCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    QuantityOnHand = CDbl(QuantityOnHandCommand.ExecuteScalar)
                Catch ex As Exception
                    QuantityOnHand = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Quantity Billed
                Dim QuantityBilledStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber"
                Dim QuantityBilledCommand As New SqlCommand(QuantityBilledStatement, con)
                QuantityBilledCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantitySold = CDbl(QuantityBilledCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalQuantitySold = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Last Activity Date
                Dim LastActivityDateStatement As String = "SELECT MAX(TransactionDate) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber"
                Dim LastActivityDateCommand As New SqlCommand(LastActivityDateStatement, con)
                LastActivityDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastActivityDate = CStr(LastActivityDateCommand.ExecuteScalar)
                Catch ex As Exception
                    LastActivityDate = ""
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Total Product Sales
                Dim TotalSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber"
                Dim TotalSalesCommand As New SqlCommand(TotalSalesStatement, con)
                TotalSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalSales = CDbl(TotalSalesCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalSales = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Part Description
                Dim GetDescriptionStatement As String = "SELECT MAX(ShortDescription) FROM ItemList WHERE ItemID = @ItemID"
                Dim GetDescriptionCommand As New SqlCommand(GetDescriptionStatement, con)
                GetDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetDescription = CStr(GetDescriptionCommand.ExecuteScalar)
                Catch ex As Exception
                    GetDescription = ""
                End Try
                con.Close()
                '**************************************************************************************************************************************************
                'Write Values to Temp Table
                cmd = New SqlCommand("INSERT INTO ItemListSalesDataTemp (PartNumber, PartDescription, LastSalesPrice, AverageSalesPrice, LastPurchaseCost, AveragePurchaseCost, TotalQuantitySold, TotalQOH, CurrentDate, LastActivityDate, TotalSales) values (@PartNumber, @PartDescription, @LastSalesPrice, @AverageSalesPrice, @LastPurchaseCost, @AveragePurchaseCost, @TotalQuantitySold, @TotalQOH, @CurrentDate, @LastActivityDate, @TotalSales)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = GetDescription
                    .Add("@LastSalesPrice", SqlDbType.VarChar).Value = LastSalesPrice
                    .Add("@AverageSalesPrice", SqlDbType.VarChar).Value = AverageSalesPrice
                    .Add("@LastPurchaseCost", SqlDbType.VarChar).Value = LastPurchaseCost
                    .Add("@AveragePurchaseCost", SqlDbType.VarChar).Value = AveragePurchaseCost
                    .Add("@TotalQuantitySold", SqlDbType.VarChar).Value = TotalQuantitySold
                    .Add("@TotalQOH", SqlDbType.VarChar).Value = QuantityOnHand
                    .Add("@CurrentDate", SqlDbType.VarChar).Value = Today()
                    .Add("@LastActivityDate", SqlDbType.VarChar).Value = LastActivityDate
                    .Add("@TotalSales", SqlDbType.VarChar).Value = TotalSales
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Get relevent data and write to temp table
                '************************************************************************************************************************************************
                'Get Last Sales Price
                Dim MAXDate1Statement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID"
                Dim MAXDate1Command As New SqlCommand(MAXDate1Statement, con)
                MAXDate1Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXDate1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxDate1 = CInt(MAXDate1Command.ExecuteScalar)
                Catch ex As Exception
                    MaxDate1 = 0
                End Try
                con.Close()

                Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
                Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                LastPriceCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate1

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
                Catch ex As Exception
                    LastSalesPrice = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Last Purchase Cost
                'Load values into Cost Field
                Dim MAXDate2Statement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
                MAXDate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXDate2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxDate2 = CInt(MAXDate2Command.ExecuteScalar)
                Catch ex As Exception
                    MaxDate2 = 0
                End Try
                con.Close()

                Dim LastCostStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
                Dim LastCostCommand As New SqlCommand(LastCostStatement, con)
                LastCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                LastCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                LastCostCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate2

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastPurchaseCost = CDbl(LastCostCommand.ExecuteScalar)
                Catch ex As Exception
                    LastPurchaseCost = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Average Cost
                Dim AverageCostStatement As String = "SELECT AVG(UnitCost) FROM ReceivingLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim AverageCostCommand As New SqlCommand(AverageCostStatement, con)
                AverageCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                AverageCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    AveragePurchaseCost = CDbl(AverageCostCommand.ExecuteScalar)
                Catch ex As Exception
                    AveragePurchaseCost = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Average Price
                Dim AveragePriceStatement As String = "SELECT AVG(Price) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim AveragePriceCommand As New SqlCommand(AveragePriceStatement, con)
                AveragePriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                AveragePriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    AverageSalesPrice = CDbl(AveragePriceCommand.ExecuteScalar)
                Catch ex As Exception
                    AverageSalesPrice = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get QOH
                Dim QuantityOnHandStatement As String = "SELECT SUM(QuantityOnHand) FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim QuantityOnHandCommand As New SqlCommand(QuantityOnHandStatement, con)
                QuantityOnHandCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                QuantityOnHandCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    QuantityOnHand = CDbl(QuantityOnHandCommand.ExecuteScalar)
                Catch ex As Exception
                    QuantityOnHand = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Quantity Billed
                Dim QuantityBilledStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim QuantityBilledCommand As New SqlCommand(QuantityBilledStatement, con)
                QuantityBilledCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                QuantityBilledCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantitySold = CDbl(QuantityBilledCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalQuantitySold = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Last Activity Date
                Dim LastActivityDateStatement As String = "SELECT MAX(TransactionDate) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim LastActivityDateCommand As New SqlCommand(LastActivityDateStatement, con)
                LastActivityDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                LastActivityDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastActivityDate = CStr(LastActivityDateCommand.ExecuteScalar)
                Catch ex As Exception
                    LastActivityDate = ""
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Get Total Product Sales
                Dim TotalSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim TotalSalesCommand As New SqlCommand(TotalSalesStatement, con)
                TotalSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                TotalSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalSales = CDbl(TotalSalesCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalSales = 0
                End Try
                con.Close()
                '************************************************************************************************************************************************
                'Write Values to Temp Table
                cmd = New SqlCommand("INSERT INTO ItemListSalesDataTemp (PartNumber, PartDescription, LastSalesPrice, AverageSalesPrice, LastPurchaseCost, AveragePurchaseCost, TotalQuantitySold, TotalQOH, CurrentDate, LastActivityDate, TotalSales) values (@PartNumber, @PartDescription, @LastSalesPrice, @AverageSalesPrice, @LastPurchaseCost, @AveragePurchaseCost, @TotalQuantitySold, @TotalQOH, @CurrentDate, @LastActivityDate, @TotalSales)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@LastSalesPrice", SqlDbType.VarChar).Value = LastSalesPrice
                    .Add("@AverageSalesPrice", SqlDbType.VarChar).Value = AverageSalesPrice
                    .Add("@LastPurchaseCost", SqlDbType.VarChar).Value = LastPurchaseCost
                    .Add("@AveragePurchaseCost", SqlDbType.VarChar).Value = AveragePurchaseCost
                    .Add("@TotalQuantitySold", SqlDbType.VarChar).Value = TotalQuantitySold
                    .Add("@TotalQOH", SqlDbType.VarChar).Value = QuantityOnHand
                    .Add("@CurrentDate", SqlDbType.VarChar).Value = Today()
                    .Add("@LastActivityDate", SqlDbType.VarChar).Value = LastActivityDate
                    .Add("@TotalSales", SqlDbType.VarChar).Value = TotalSales
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        'Show Temp Table
        ShowTempData()

        'Run Background worker
        bgLoading.RunWorkerAsync()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearTempData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If cboDivisionID.Text = "ADM" Then
            LoadDescriptionByPartADM()
        Else
            LoadDescriptionByPart()
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        If cboDivisionID.Text = "ADM" Then
            LoadPartByDescriptionADM()
        Else
            LoadPartByDescription()
        End If
    End Sub

    Private Sub bgLoading_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgLoading.DoWork
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "ItemListSalesDataTemp")
        con.Close()
    End Sub

    Public Sub ShowTempData()
        cmd = New SqlCommand("SELECT * FROM ItemListSalesDataTemp", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        'myAdapter5.Fill(ds5, "ItemListSalesDataTemp")
        'dgvPartNumberSalesData.DataSource = ds5.Tables("ItemListSalesDataTemp")
        con.Close()
    End Sub

    Private Sub BGLoading_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgLoading.RunWorkerCompleted
        dgvSalesData.DataSource = ds5.Tables("ItemListSalesDataTemp")
        lblLoading.Visible = False
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds5

        Using NewPrintPartSalesData As New PrintPartSalesData
            Dim Result = NewPrintPartSalesData.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

End Class