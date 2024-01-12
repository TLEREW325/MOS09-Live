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
Public Class ViewPurchaseLines
    Inherits System.Windows.Forms.Form

    Dim PastDueFilter, ItemClassFilter, PPLFilter, TextFilter, LongDescription, VendorName, VendorFilter, PartFilter, SOFilter, POFilter, StatusFilter, DateFilter As String
    Dim BeginDate, EndDate As Date
    Dim PONumber, SONumber As Integer
    Dim strPONumber, strSONumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewPurchaseLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PurchaseProductLine' table. You can move, or remove it, as needed.
        Me.PurchaseProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PurchaseProductLine)

        LoadCurrentDivision()
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

    Private Sub dgvPurchaseLines_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPurchaseLines.CellDoubleClick
        If Me.dgvPurchaseLines.RowCount > 0 Then
            Dim RowPONumber As Integer
            Dim RowDivision As String

            Dim RowIndex As Integer = Me.dgvPurchaseLines.CurrentCell.RowIndex

            Try
                RowPONumber = Me.dgvPurchaseLines.Rows(RowIndex).Cells("PurchaseOrderHeaderKeyColumn").Value
            Catch ex As Exception
                RowPONumber = 0
            End Try
            Try
                RowDivision = Me.dgvPurchaseLines.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = EmployeeCompanyCode
            End Try

            GlobalPONumber = RowPONumber
            GlobalDivisionCode = RowDivision

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
                Using NewPrintPurchaseOrderRemote As New PrintPurchaseOrderRemote
                    Dim Result = NewPrintPurchaseOrderRemote.ShowDialog()
                End Using
            Else
                Using NewPrintPurchaseOrder As New PrintPurchaseOrder
                    Dim Result = NewPrintPurchaseOrder.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Public Sub ShowDataByFilters()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboLineStatus.Text <> "" Then
            StatusFilter = " AND LineStatus = '" + cboLineStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If cboSONumber.Text <> "" Then
            SONumber = Val(cboSONumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND DropShipSalesOrderNumber = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If cboPurchaseLine.Text <> "" Then
            PPLFilter = " AND PurchProdLineID = '" + cboPurchaseLine.Text + "'"
        Else
            PPLFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboPurchaseOrderNumber.Text <> "" Then
            PONumber = Val(cboPurchaseOrderNumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PurchaseOrderHeaderKey = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR PartDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%')"
        Else
            TextFilter = ""
        End If
        If chkOpenAndPastDue.Checked = True Then
            Dim TodaysDate As Date = Today()
            Dim strTodaysDate As String
            strTodaysDate = CStr(TodaysDate)

            PastDueFilter = " AND (LineStatus = 'OPEN' AND  ShipDate < '" + strTodaysDate + "')"
        Else
            PastDueFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND PODate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus WHERE DivisionID = @DivisionID" + VendorFilter + PartFilter + StatusFilter + TextFilter + POFilter + SOFilter + PPLFilter + ItemClassFilter + PastDueFilter + DateFilter + " ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderQuantityStatus")
        dgvPurchaseLines.DataSource = ds.Tables("PurchaseOrderQuantityStatus")
        cboPOLookup.DataSource = ds.Tables("PurchaseOrderQuantityStatus")
        con.Close()
    End Sub

    Public Sub ShowDataByFiltersADM()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboLineStatus.Text <> "" Then
            StatusFilter = " AND LineStatus = '" + cboLineStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If cboSONumber.Text <> "" Then
            SONumber = Val(cboSONumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND DropShipSalesOrderNumber = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If cboPurchaseLine.Text <> "" Then
            PPLFilter = " AND PurchProdLineID = '" + cboPurchaseLine.Text + "'"
        Else
            PPLFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboPurchaseOrderNumber.Text <> "" Then
            PONumber = Val(cboPurchaseOrderNumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PurchaseOrderHeaderKey = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND PODate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus WHERE DivisionID <> @DivisionID AND PurchaseOrderHeaderKey > 1" + VendorFilter + PartFilter + StatusFilter + POFilter + SOFilter + ItemClassFilter + PPLFilter + DateFilter + " ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderQuantityStatus")
        dgvPurchaseLines.DataSource = ds.Tables("PurchaseOrderQuantityStatus")
        cboPOLookup.DataSource = ds.Tables("PurchaseOrderQuantityStatus")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvPurchaseLines.DataSource = Nothing
    End Sub

    Public Sub ShowAllCompanyData()
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus Order By PurchaseOrderHeaderKey", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderQuantityStatus")
        dgvPurchaseLines.DataSource = ds.Tables("PurchaseOrderQuantityStatus")
        cboPOLookup.DataSource = ds.Tables("PurchaseOrderQuantityStatus")
        con.Close()
    End Sub

    Public Sub LoadVendor()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT VendorCode FROM Vendor WHERE DivisionID <> @DivisionID AND VendorClass <> @VendorClass", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "Vendor")
            cboVendorID.DataSource = ds1.Tables("Vendor")
            con.Close()
            cboVendorID.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "Vendor")
            cboVendorID.DataSource = ds1.Tables("Vendor")
            con.Close()
            cboVendorID.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPartNumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT ItemID FROM ItemList WHERE DivisionID <> @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd
            myAdapter2.Fill(ds2, "ItemList")
            cboPartNumber.DataSource = ds2.Tables("ItemList")
            con.Close()
            cboPartNumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd
            myAdapter2.Fill(ds2, "ItemList")
            cboPartNumber.DataSource = ds2.Tables("ItemList")
            con.Close()
            cboPartNumber.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPartDescription()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT ShortDescription FROM ItemList WHERE DivisionID <> @DivisionID AND ItemClass <> @ItemClass ORDER BY ShortDescription", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "ItemList")
            cboPartDescription.DataSource = ds3.Tables("ItemList")
            con.Close()
            cboPartDescription.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "ItemList")
            cboPartDescription.DataSource = ds3.Tables("ItemList")
            con.Close()
            cboPartDescription.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadSONumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey <> @DivisionKey ORDER BY SalesOrderKey DESC", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "SalesOrderHeaderTable")
            cboSONumber.DataSource = ds6.Tables("SalesOrderHeaderTable")
            con.Close()
            cboSONumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey ORDER BY SalesOrderKey DESC", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "SalesOrderHeaderTable")
            cboSONumber.DataSource = ds6.Tables("SalesOrderHeaderTable")
            con.Close()
            cboSONumber.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPONumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID <> @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds7 = New DataSet()
            myAdapter7.SelectCommand = cmd
            myAdapter7.Fill(ds7, "PurchaseOrderHeaderTable")
            cboPurchaseOrderNumber.DataSource = ds7.Tables("PurchaseOrderHeaderTable")
            con.Close()
            cboPurchaseOrderNumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds7 = New DataSet()
            myAdapter7.SelectCommand = cmd
            myAdapter7.Fill(ds7, "PurchaseOrderHeaderTable")
            cboPurchaseOrderNumber.DataSource = ds7.Tables("PurchaseOrderHeaderTable")
            con.Close()
            cboPurchaseOrderNumber.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "ADM" Then
            dgvPurchaseLines.Columns("DivisionIDColumn").Visible = True
        Else
            dgvPurchaseLines.Columns("DivisionIDColumn").Visible = False
        End If

        LoadPartNumber()
        LoadPartDescription()
        LoadVendor()
        LoadSONumber()
        LoadPONumber()
        ClearData()
        ClearDataInDatagrid()
        usefulFunctions.LoadSecurity(Me, cboDivisionID.Text)
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        If cboDivisionID.Text = "ADM" Then
            Dim PartNumber1Statement As String = "SELECT TOP 1 ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID <> @DivisionID"
            Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
            PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
            PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
            Catch ex As Exception
                PartNumber1 = ""
            End Try
            con.Close()
        Else
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
        End If

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        If cboDivisionID.Text = "ADM" Then
            Dim PartDescription1Statement As String = "SELECT TOP 1 ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID <> @DivisionID"
            Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
            PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
            Catch ex As Exception
                PartDescription1 = ""
            End Try
            con.Close()
        Else
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
        End If

        cboPartDescription.Text = PartDescription1
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Public Sub LoadVendorName()
        If cboDivisionID.Text = "ADM" Then
            Dim VendorNameString As String = "SELECT TOP 1 VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID <> @DivisionID"
            Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
            VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorName = CStr(VendorNameCommand.ExecuteScalar)
            Catch ex As Exception
                VendorName = ""
            End Try
            con.Close()
        Else
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
        End If

        txtVendorName.Text = VendorName
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Public Sub ClearVariables()
        ItemClassFilter = ""
        PPLFilter = ""
        TextFilter = ""
        LongDescription = ""
        VendorName = ""
        VendorFilter = ""
        PartFilter = ""
        SOFilter = ""
        POFilter = ""
        StatusFilter = ""
        DateFilter = ""
        PONumber = 0
        SONumber = 0
        strPONumber = ""
        strSONumber = ""
    End Sub

    Public Sub ClearData()
        cboVendorID.Text = ""
        cboLineStatus.Text = ""
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""
        cboPurchaseOrderNumber.Text = ""
        cboSONumber.Text = ""
        cboItemClass.Text = ""
        cboPurchaseLine.Text = ""

        cboVendorID.SelectedIndex = -1
        cboLineStatus.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPurchaseOrderNumber.SelectedIndex = -1
        cboSONumber.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboPurchaseLine.SelectedIndex = -1

        chkDateRange.Checked = False
        chkOpenAndPastDue.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboVendorID.Focus()
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvPurchaseLines.CellValueChanged
        Dim LineComment As String
        Dim LinePONumber, LineNumber As Integer

        If Me.dgvPurchaseLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPurchaseLines.CurrentCell.RowIndex

            Try
                LinePONumber = Me.dgvPurchaseLines.Rows(RowIndex).Cells("PurchaseOrderHeaderKeyColumn").Value
            Catch ex As Exception
                LinePONumber = 0
            End Try
            Try
                LineNumber = Me.dgvPurchaseLines.Rows(RowIndex).Cells("PurchaseOrderLineNumberColumn").Value
            Catch ex As Exception
                LineNumber = 0
            End Try
            Try
                LineComment = Me.dgvPurchaseLines.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                LineComment = ""
            End Try

            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineComment = @LineComment WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = LinePONumber
                    .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        If cboDivisionID.Text = "ADM" Then
            dgvPurchaseLines.Columns(1).Visible = True
            ShowDataByFiltersADM()
        Else
            dgvPurchaseLines.Columns(1).Visible = False
            ShowDataByFilters()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdOpenPurchaseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenPurchaseOrder.Click
        Dim RowPONumber As Integer
        Dim RowDivision As String

        If Me.dgvPurchaseLines.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvPurchaseLines.CurrentCell.RowIndex

            Try
                RowPONumber = Me.dgvPurchaseLines.Rows(RowIndex).Cells("PurchaseOrderHeaderKeyColumn").Value
            Catch ex As Exception
                RowPONumber = 0
            End Try
            Try
                RowDivision = Me.dgvPurchaseLines.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = EmployeeCompanyCode
            End Try
        End If

        GlobalPONumber = RowPONumber
        GlobalDivisionCode = RowDivision

        Dim NewPOForm As New POForm
        NewPOForm.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalPurchaseLineReport = "No Sort"
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintPurchaseLinesFiltered As New PrintPurchaseLinesFiltered
            Dim result = NewPrintPurchaseLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintPOListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPOListingToolStripMenuItem.Click
        GlobalPurchaseLineReport = "No Sort"
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintPurchaseLinesFiltered As New PrintPurchaseLinesFiltered
            Dim result = NewPrintPurchaseLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroup.Click
        GlobalPurchaseLineReport = "Part Sort"

        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintPurchaseLinesFiltered As New PrintPurchaseLinesFiltered
            Dim result = NewPrintPurchaseLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdGroupByVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupByVendor.Click
        GlobalPurchaseLineReport = "Vendor Sort"
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintPurchaseLinesFiltered As New PrintPurchaseLinesFiltered
            Dim result = NewPrintPurchaseLinesFiltered.ShowDialog()
        End Using
    End Sub
End Class