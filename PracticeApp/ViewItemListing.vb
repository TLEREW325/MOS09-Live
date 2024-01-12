Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewItemListing
    Inherits System.Windows.Forms.Form

    Dim TextFilterVariable As String
    Dim OtherDivisionFilter, OmitFilter, ItemClassFilter, PPLFilter, PartFilter, SPLFilter, Text1Filter, Text2Filter, Text3Filter, Text4Filter, Text5Filter As String
    Dim CurrentDivision As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim Authorized As Boolean = True

    Private Sub ViewItemListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.SalesProductLine' table. You can move, or remove it, as needed.
        Me.SalesProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.SalesProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PurchaseProductLine' table. You can move, or remove it, as needed.
        Me.PurchaseProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PurchaseProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        LoadCurrentDivision()
        usefulFunctions.LoadSecurity(Me)
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
        dgvItemList.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilter()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID >= '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
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
        If chkOmitNonInventory.Checked = True Then
            OmitFilter = " AND PurchProdLineID <> 'NON-INVENTORY'"
        Else
            OmitFilter = ""
        End If
        If cboOtherDivision.Text <> "" Then
            OtherDivisionFilter = " AND DivisionID = '" + cboDivisionID.Text + "'"
            CurrentDivision = cboOtherDivision.Text
        Else
            OtherDivisionFilter = ""
            CurrentDivision = cboDivisionID.Text
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID <> @DivisionID" + PartFilter + SPLFilter + PPLFilter + ItemClassFilter + OmitFilter + Text1Filter + Text2Filter + Text3Filter + Text4Filter + Text5Filter + " ORDER BY DivisionID, ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ItemList")
            dgvItemList.DataSource = ds.Tables("ItemList")
            con.Close()
            Me.dgvItemList.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = @DivisionID" + PartFilter + SPLFilter + PPLFilter + ItemClassFilter + OmitFilter + Text1Filter + Text2Filter + Text3Filter + Text4Filter + Text5Filter + " ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ItemList")
            dgvItemList.DataSource = ds.Tables("ItemList")
            con.Close()

            Me.dgvItemList.Columns("DivisionIDColumn").Visible = False

            If cboOtherDivision.Text <> "" And Me.dgvItemList.RowCount <> 0 Then
                If cboDivisionID.Text = cboOtherDivision.Text Then
                    cmdCopyPartNumber.Enabled = False
                Else
                    cmdCopyPartNumber.Enabled = True
                End If
            Else
                cmdCopyPartNumber.Enabled = False
            End If
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "ADM" Then
            LoadPartNumberADM()
            LoadPartDescriptionADM()
        Else
            LoadPartNumber()
            LoadPartDescription()
        End If

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
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

    Public Sub ClearData()
        cboItemClass.Text = ""
        cboPurchaseProductLine.Text = ""
        cboSalesProdLine.Text = ""
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""

        cboOtherDivision.SelectedIndex = -1
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

        cmdCopyPartNumber.Enabled = False

        cboItemClass.Focus()
    End Sub

    Public Sub ClearVariables()
        TextFilterVariable = ""
        ItemClassFilter = ""
        PPLFilter = ""
        PartFilter = ""
        SPLFilter = ""
        Text1Filter = ""
        Text2Filter = ""
        Text3Filter = ""
        Text4Filter = ""
        Text5Filter = ""
        OtherDivisionFilter = ""
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdItemForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemForm.Click
        If Me.dgvItemList.RowCount <> 0 Then
            Dim RowPartNumber As String
            Dim RowIndex As Integer = Me.dgvItemList.CurrentCell.RowIndex

            RowPartNumber = Me.dgvItemList.Rows(RowIndex).Cells("ItemIDColumn").Value

            GlobalItemListingPartNumber = RowPartNumber
        Else
            GlobalItemListingPartNumber = ""
        End If

        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintItemListFiltered As New PrintItemListFiltered
            Dim result = NewPrintItemListFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub dgvItemList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemList.CellValueChanged
        If Authorized Then
            Dim PieceWeight, StandardCost, StandardPrice, NominalDiameter, NominalLength As Double
            Dim BinPreferenceCode, LeadTime, Comments, ItemID, ShortDescription, LongDescription, OldPartNumber, BoxType, AddAccessory As String
            Dim BoxWeight, BoxCount, PalletCount, MinimumStock, MaximumStock As Integer
            Dim DivisionID As String = ""

            If Me.dgvItemList.RowCount <> 0 Then
                Dim RowIndex As Integer = Me.dgvItemList.CurrentCell.RowIndex

                Try
                    ItemID = Me.dgvItemList.Rows(RowIndex).Cells("ItemIDColumn").Value
                Catch ex As Exception
                    ItemID = ""
                End Try
                Try
                    ShortDescription = Me.dgvItemList.Rows(RowIndex).Cells("ShortDescriptionColumn").Value
                Catch ex As Exception
                    ShortDescription = ""
                End Try
                Try
                    LongDescription = Me.dgvItemList.Rows(RowIndex).Cells("LongDescriptionColumn").Value
                Catch ex As Exception
                    LongDescription = ""
                End Try
                Try
                    PieceWeight = Me.dgvItemList.Rows(RowIndex).Cells("PieceWeightColumn").Value
                Catch ex As Exception
                    PieceWeight = 0
                End Try
                Try
                    BoxCount = Me.dgvItemList.Rows(RowIndex).Cells("BoxCountColumn").Value
                Catch ex As Exception
                    BoxCount = 0
                End Try
                Try
                    PalletCount = Me.dgvItemList.Rows(RowIndex).Cells("PalletCountColumn").Value
                Catch ex As Exception
                    PalletCount = 0
                End Try
                Try
                    StandardCost = Me.dgvItemList.Rows(RowIndex).Cells("StandardCostColumn").Value
                Catch ex As Exception
                    StandardCost = 0
                End Try
                Try
                    StandardPrice = Me.dgvItemList.Rows(RowIndex).Cells("StandardPriceColumn").Value
                Catch ex As Exception
                    OldPartNumber = ""
                End Try
                Try
                    OldPartNumber = Me.dgvItemList.Rows(RowIndex).Cells("OldPartNumberColumn").Value
                Catch ex As Exception
                    OldPartNumber = ""
                End Try
                Try
                    MinimumStock = Me.dgvItemList.Rows(RowIndex).Cells("MinimumStockColumn").Value
                Catch ex As Exception
                    MinimumStock = 0
                End Try
                Try
                    MaximumStock = Me.dgvItemList.Rows(RowIndex).Cells("MaximumStockColumn").Value
                Catch ex As Exception
                    MaximumStock = 0
                End Try
                Try
                    BoxType = Me.dgvItemList.Rows(RowIndex).Cells("BoxTypeColumn").Value
                Catch ex As Exception
                    BoxType = ""
                End Try
                Try
                    NominalDiameter = Me.dgvItemList.Rows(RowIndex).Cells("NominalDiameterColumn").Value
                Catch ex As Exception
                    NominalDiameter = 0
                End Try
                Try
                    NominalLength = Me.dgvItemList.Rows(RowIndex).Cells("NominalLengthColumn").Value
                Catch ex As Exception
                    NominalLength = 0
                End Try
                Try
                    AddAccessory = Me.dgvItemList.Rows(RowIndex).Cells("AddAccessoryColumn").Value
                Catch ex As Exception
                    AddAccessory = "NO"
                End Try
                Try
                    Comments = Me.dgvItemList.Rows(RowIndex).Cells("CommentsColumn").Value
                Catch ex As Exception
                    Comments = ""
                End Try
                Try
                    LeadTime = Me.dgvItemList.Rows(RowIndex).Cells("LeadTimeColumn").Value
                Catch ex As Exception
                    LeadTime = ""
                End Try
                Try
                    BoxWeight = Me.dgvItemList.Rows(RowIndex).Cells("BoxWeightColumn").Value
                Catch ex As Exception
                    BoxWeight = 0
                End Try
                Try
                    DivisionID = Me.dgvItemList.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    DivisionID = cboDivisionID.Text
                End Try
                Try
                    BinPreferenceCode = Me.dgvItemList.Rows(RowIndex).Cells("BinPreferenceColumn").Value
                Catch ex As Exception
                    BinPreferenceCode = ""
                End Try


                Try
                    'Create command to update database and fill with text box enties
                    cmd = New SqlCommand("UPDATE ItemList SET ShortDescription = @ShortDescription, LongDescription = @LongDescription, PieceWeight = @PieceWeight, BoxCount = @BoxCount, PalletCount = @PalletCount, StandardCost = @StandardCost, StandardPrice = @StandardPrice, OldPartNumber = @OldPartNumber, MinimumStock = @MinimumStock, MaximumStock = @MaximumStock, BoxType = @BoxType, NominalDiameter = @NominalDiameter, NominalLength = @NominalLength, AddAccessory = @AddAccessory, Comments = @Comments, LeadTime = @LeadTime, BoxWeight = @BoxWeight, BinPreference = @BinPreference WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ItemID", SqlDbType.VarChar).Value = ItemID
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        .Add("@ShortDescription", SqlDbType.VarChar).Value = ShortDescription
                        .Add("@LongDescription", SqlDbType.VarChar).Value = LongDescription
                        '.Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
                        '.Add("@PurchProdLineID", SqlDbType.VarChar).Value = cboPurchaseProductID.Text
                        '.Add("@SalesProdLineID", SqlDbType.VarChar).Value = cboSalesProductLine.Text
                        .Add("@PieceWeight", SqlDbType.VarChar).Value = PieceWeight
                        .Add("@BoxCount", SqlDbType.VarChar).Value = BoxCount
                        .Add("@PalletCount", SqlDbType.VarChar).Value = PalletCount
                        .Add("@StandardCost", SqlDbType.VarChar).Value = StandardCost
                        .Add("@StandardPrice", SqlDbType.VarChar).Value = StandardPrice
                        .Add("@OldPartNumber", SqlDbType.VarChar).Value = OldPartNumber
                        .Add("@MinimumStock", SqlDbType.VarChar).Value = MinimumStock
                        .Add("@MaximumStock", SqlDbType.VarChar).Value = MaximumStock
                        '.Add("@CreationDate", SqlDbType.VarChar).Value = CreationDate
                        '.Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
                        .Add("@BoxType", SqlDbType.VarChar).Value = "Z"
                        .Add("@NominalDiameter", SqlDbType.VarChar).Value = NominalDiameter
                        .Add("@NominalLength", SqlDbType.VarChar).Value = NominalLength
                        .Add("@AddAccessory", SqlDbType.VarChar).Value = AddAccessory
                        '.Add("@PreferredVendor", SqlDbType.VarChar).Value = VendorID
                        .Add("@Comments", SqlDbType.VarChar).Value = Comments
                        .Add("@LeadTime", SqlDbType.VarChar).Value = LeadTime
                        .Add("@BoxWeight", SqlDbType.VarChar).Value = BoxWeight
                        .Add("@BinPreference", SqlDbType.VarChar).Value = BinPreferenceCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    Try
                        If StandardCost = 0 Then
                            'skip update
                        Else
                            'Update Item List with new Standard Cost and Price
                            cmd = New SqlCommand("UPDATE ItemPriceSheet SET StandardUnitCost = @StandardUnitCost WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PartNumber", SqlDbType.VarChar).Value = ItemID
                                .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                                .Add("@StandardUnitCost", SqlDbType.VarChar).Value = StandardCost
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If

                        If StandardPrice = 0 Then
                            'Skip Update
                        Else
                            'Update Item List with new Standard Cost and Price
                            cmd = New SqlCommand("UPDATE ItemPriceSheet SET StandardUnitPrice = @StandardUnitPrice WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PartNumber", SqlDbType.VarChar).Value = ItemID
                                .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                                .Add("@StandardUnitPrice", SqlDbType.VarChar).Value = StandardPrice
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Catch ex As Exception
                        'Skip - no price sheet data available
                    End Try

                Catch ex As Exception
                    'Do nothing
                End Try
            Else
                'Skip update
            End If
        End If
    End Sub

    Private Sub dgvItemList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemList.CellDoubleClick
        If Authorized Then
            Dim RowPartNumber As String
            Dim RowIndex As Integer = Me.dgvItemList.CurrentCell.RowIndex

            RowPartNumber = Me.dgvItemList.Rows(RowIndex).Cells("ItemIDColumn").Value

            GlobalPartNumberLookup = RowPartNumber
            GlobalDivisionCode = cboDivisionID.Text

            Using NewItemLookup As New ItemLookup
                Dim Result = NewItemLookup.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrintQCListingType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintQCListingType.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintItemListFiltered As New PrintItemListFiltered(True)
            Dim result = NewPrintItemListFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdCopyPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyPartNumber.Click
        Dim BoxWeight, PieceWeight, NominalDiameter, NominalLength As Double
        Dim ItemClass, ItemID, ShortDescription, LongDescription, OldPartNumber, BoxType As String
        Dim BoxCount, PalletCount, FOXNumber As Integer
        Dim Comments, LeadTime, PreferredVendor As String
        Dim CheckIfPartExists As Integer = 0

        If Me.dgvItemList.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvItemList.CurrentCell.RowIndex

            Try
                ItemID = Me.dgvItemList.Rows(RowIndex).Cells("ItemIDColumn").Value
            Catch ex As Exception
                ItemID = ""
            End Try
            Try
                ShortDescription = Me.dgvItemList.Rows(RowIndex).Cells("ShortDescriptionColumn").Value
            Catch ex As Exception
                ShortDescription = ""
            End Try
            Try
                LongDescription = Me.dgvItemList.Rows(RowIndex).Cells("LongDescriptionColumn").Value
            Catch ex As Exception
                LongDescription = ""
            End Try
            Try
                ItemClass = Me.dgvItemList.Rows(RowIndex).Cells("ItemClassColumn").Value
            Catch ex As Exception
                ItemClass = ""
            End Try
            Try
                PieceWeight = Me.dgvItemList.Rows(RowIndex).Cells("PieceWeightColumn").Value
            Catch ex As Exception
                PieceWeight = 0
            End Try
            Try
                BoxCount = Me.dgvItemList.Rows(RowIndex).Cells("BoxCountColumn").Value
            Catch ex As Exception
                BoxCount = 0
            End Try
            Try
                PalletCount = Me.dgvItemList.Rows(RowIndex).Cells("PalletCountColumn").Value
            Catch ex As Exception
                PalletCount = 0
            End Try
            Try
                OldPartNumber = Me.dgvItemList.Rows(RowIndex).Cells("OldPartNumberColumn").Value
            Catch ex As Exception
                OldPartNumber = ""
            End Try
            Try
                FOXNumber = Me.dgvItemList.Rows(RowIndex).Cells("FOXNumberColumn").Value
            Catch ex As Exception
                FOXNumber = 0
            End Try
            Try
                BoxType = Me.dgvItemList.Rows(RowIndex).Cells("BoxTypeColumn").Value
            Catch ex As Exception
                BoxType = ""
            End Try
            Try
                NominalDiameter = Me.dgvItemList.Rows(RowIndex).Cells("NominalDiameterColumn").Value
            Catch ex As Exception
                NominalDiameter = 0
            End Try
            Try
                NominalLength = Me.dgvItemList.Rows(RowIndex).Cells("NominalLengthColumn").Value
            Catch ex As Exception
                NominalLength = 0
            End Try
            Try
                BoxWeight = Me.dgvItemList.Rows(RowIndex).Cells("BoxWeightColumn").Value
            Catch ex As Exception
                BoxWeight = 0
            End Try
            Try
                Comments = Me.dgvItemList.Rows(RowIndex).Cells("CommentsColumn").Value
            Catch ex As Exception
                Comments = ""
            End Try
            Try
                LeadTime = Me.dgvItemList.Rows(RowIndex).Cells("LeadTimeColumn").Value
            Catch ex As Exception
                LeadTime = ""
            End Try

            'Check to see if part exists
            Dim CheckIfPartExistsStatement As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim CheckIfPartExistsCommand As New SqlCommand(CheckIfPartExistsStatement, con)
            CheckIfPartExistsCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ItemID
            CheckIfPartExistsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckIfPartExists = CInt(CheckIfPartExistsCommand.ExecuteScalar)
            Catch ex As Exception
                CheckIfPartExists = 0
            End Try
            con.Close()
            '*************************************************************************************************************
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                Dim button As DialogResult = MessageBox.Show("Is this part from a Canadian Vendor?", "Canadian or American?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    PreferredVendor = "CANADIAN"
                ElseIf button = DialogResult.No Then
                    PreferredVendor = "AMERICAN"
                End If
            Else
                PreferredVendor = ""
            End If
            '*************************************************************************************************************
            If CheckIfPartExists = 0 Then
                Try
                    'Create command to update database and fill with text box enties
                    cmd = New SqlCommand("INSERT INTO ItemList (ItemID, DivisionID, ShortDescription, LongDescription, ItemClass, PurchProdLineID, SalesProdLineID, PieceWeight, BoxCount, PalletCount, StandardCost, StandardPrice, OldPartNumber, MinimumStock, MaximumStock, CreationDate, BeginningBalance, FOXNumber, BoxType, NominalDiameter, NominalLength, AddAccessory, PreferredVendor, Locked, SafetyDataSheet, BoxWeight, Comments, LeadTime, BinPreference)values(@ItemID, @DivisionID, @ShortDescription, @LongDescription, @ItemClass, @PurchProdLineID, @SalesProdLineID, @PieceWeight, @BoxCount, @PalletCount, @StandardCost, @StandardPrice, @OldPartNumber, @MinimumStock, @MaximumStock, @CreationDate, @BeginningBalance, @FOXNumber, @BoxType, @NominalDiameter, @NominalLength, @AddAccessory, @PreferredVendor, @Locked, @SafetyDataSheet, @BoxWeight, @Comments, @LeadTime, @BinPreference)", con)

                    With cmd.Parameters
                        .Add("@ItemID", SqlDbType.VarChar).Value = ItemID.ToUpper
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ShortDescription", SqlDbType.VarChar).Value = ShortDescription.ToUpper
                        .Add("@LongDescription", SqlDbType.VarChar).Value = LongDescription.ToUpper
                        .Add("@ItemClass", SqlDbType.VarChar).Value = ItemClass
                        .Add("@PurchProdLineID", SqlDbType.VarChar).Value = cboDivisionID.Text + "-PURCHASEPRODUCTS"
                        .Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SPL-" + cboDivisionID.Text
                        .Add("@PieceWeight", SqlDbType.VarChar).Value = PieceWeight
                        .Add("@BoxCount", SqlDbType.VarChar).Value = BoxCount
                        .Add("@PalletCount", SqlDbType.VarChar).Value = PalletCount
                        .Add("@StandardCost", SqlDbType.VarChar).Value = 0
                        .Add("@StandardPrice", SqlDbType.VarChar).Value = 0
                        .Add("@OldPartNumber", SqlDbType.VarChar).Value = OldPartNumber
                        .Add("@MinimumStock", SqlDbType.VarChar).Value = 0
                        .Add("@MaximumStock", SqlDbType.VarChar).Value = 0
                        .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                        .Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
                        .Add("@BoxType", SqlDbType.VarChar).Value = BoxType
                        .Add("@NominalDiameter", SqlDbType.VarChar).Value = NominalDiameter
                        .Add("@NominalLength", SqlDbType.VarChar).Value = NominalLength
                        .Add("@AddAccessory", SqlDbType.VarChar).Value = "NO"
                        .Add("@PreferredVendor", SqlDbType.VarChar).Value = PreferredVendor
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@SafetyDataSheet", SqlDbType.VarChar).Value = ""
                        .Add("@BoxWeight", SqlDbType.VarChar).Value = BoxWeight
                        .Add("@Comments", SqlDbType.VarChar).Value = ""
                        .Add("@LeadTime", SqlDbType.VarChar).Value = ""
                        .Add("@BinPreference", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    MsgBox("Part Number has been created.", MsgBoxStyle.OkOnly)
                Catch ex As Exception
                    MsgBox("There was an error creating this part number.", MsgBoxStyle.OkOnly)
                End Try
            Else
                MsgBox("This part already exists in your division.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub HideItemClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideItemClass.Click
        If HideItemClass.Checked = True Then
            dgvItemList.Columns("ItemClassColumn").Visible = False
        Else
            dgvItemList.Columns("ItemClassColumn").Visible = True
        End If
    End Sub

    Private Sub HidePieceWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HidePieceWeight.Click
        If HidePieceWeight.Checked = True Then
            dgvItemList.Columns("PieceWeightColumn").Visible = False
        Else
            dgvItemList.Columns("PieceWeightColumn").Visible = True
        End If
    End Sub

    Private Sub HideBoxCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideBoxCount.Click
        If HideBoxCount.Checked = True Then
            dgvItemList.Columns("BoxCountColumn").Visible = False
        Else
            dgvItemList.Columns("BoxCountColumn").Visible = True
        End If
    End Sub

    Private Sub HidePalletCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HidePalletCount.Click
        If HidePalletCount.Checked = True Then
            dgvItemList.Columns("PalletCountColumn").Visible = False
        Else
            dgvItemList.Columns("PalletCountColumn").Visible = True
        End If
    End Sub

    Private Sub HideStandardCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideStandardCost.Click
        If HideStandardCost.Checked = True Then
            dgvItemList.Columns("StandardCostColumn").Visible = False
        Else
            dgvItemList.Columns("StandardCostColumn").Visible = True
        End If
    End Sub

    Private Sub HideStandardPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideStandardPrice.Click
        If HideStandardPrice.Checked = True Then
            dgvItemList.Columns("StandardPriceColumn").Visible = False
        Else
            dgvItemList.Columns("StandardPriceColumn").Visible = True
        End If
    End Sub

    Private Sub HideMinStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideMinStock.Click
        If HideMinStock.Checked = True Then
            dgvItemList.Columns("MinimumStockColumn").Visible = False
        Else
            dgvItemList.Columns("MinimumStockColumn").Visible = True
        End If
    End Sub

    Private Sub HideMaxStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideMaxStock.Click
        If HideMaxStock.Checked = True Then
            dgvItemList.Columns("MaximumStockColumn").Visible = False
        Else
            dgvItemList.Columns("MaximumStockColumn").Visible = True
        End If
    End Sub
End Class