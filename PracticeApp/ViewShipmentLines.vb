Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
'Imports CrystalDecisions.Windows.Forms
'Imports CrystalDecisions.ReportSource
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewShipmentLines
    Inherits System.Windows.Forms.Form

    Dim ShippedStatus, ZeroPriceFilter, ProcessFilter, PickFilter, CityFilter, ZipFilter, StateFilter, DropShipFilter, TextFilter, StatusFilter, PartFilter, CustomerFilter, POFilter, HeatFilter, ShipmentFilter, SOFilter, DateFilter As String
    Dim ShipViaFilter, CustPOFilter, SalespersonFilter As String
    Dim BeginDate, EndDate As Date
    Dim ProductTotal, TotalCOS, ProfitMargin, TotalQuantity As Double
    Dim strBeginDate, strEndDate, strSalesOrder, strShipment As String
    Dim ShipmentNumber, SONumber As Integer
    Dim SONumberFilter As String = ""
    Dim ShipNumberFilter As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd, cmd2, cmd3 As SqlCommand
    'Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myadapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewShipmentLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()

        'By Default - only load last three years of data unless manually changed
        ViewAllLinesToolStripMenuItem.Checked = False
        ViewLast3YearsToolStripMenuItem.Checked = True

        LoadSecurity()
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

    Public Sub LoadSecurity()
        Select Case EmployeeCompanyCode
            Case "TWD"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtProfitMargin.Visible = True
                    txtTotalCOS.Visible = True
                    dgvShipmentLineQuery.Columns("ExtendedCOSColumn").Visible = True
                    dgvShipmentLineQuery.Columns("UnitCostColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtProfitMargin.Visible = False
                    txtTotalCOS.Visible = False
                    dgvShipmentLineQuery.Columns("ExtendedCOSColumn").Visible = False
                    dgvShipmentLineQuery.Columns("UnitCostColumn").Visible = False
                End If
            Case "TWE"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtProfitMargin.Visible = True
                    txtTotalCOS.Visible = True
                    dgvShipmentLineQuery.Columns("ExtendedCOSColumn").Visible = True
                    dgvShipmentLineQuery.Columns("UnitCostColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtProfitMargin.Visible = False
                    txtTotalCOS.Visible = False
                    dgvShipmentLineQuery.Columns("ExtendedCOSColumn").Visible = False
                    dgvShipmentLineQuery.Columns("UnitCostColumn").Visible = False
                End If
            Case "TFP"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtProfitMargin.Visible = True
                    txtTotalCOS.Visible = True
                    dgvShipmentLineQuery.Columns("ExtendedCOSColumn").Visible = True
                    dgvShipmentLineQuery.Columns("UnitCostColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtProfitMargin.Visible = False
                    txtTotalCOS.Visible = False
                    dgvShipmentLineQuery.Columns("ExtendedCOSColumn").Visible = False
                    dgvShipmentLineQuery.Columns("UnitCostColumn").Visible = False
                End If
            Case "ADM"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtProfitMargin.Visible = True
                    txtTotalCOS.Visible = True
                    dgvShipmentLineQuery.Columns("ExtendedCOSColumn").Visible = True
                    dgvShipmentLineQuery.Columns("UnitCostColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtProfitMargin.Visible = False
                    txtTotalCOS.Visible = False
                    dgvShipmentLineQuery.Columns("ExtendedCOSColumn").Visible = False
                    dgvShipmentLineQuery.Columns("UnitCostColumn").Visible = False
                End If
            Case Else
                lblCOGS.Visible = True
                lblMargin.Visible = True
                txtProfitMargin.Visible = True
                txtTotalCOS.Visible = True
                dgvShipmentLineQuery.Columns("ExtendedCOSColumn").Visible = True
                dgvShipmentLineQuery.Columns("UnitCostColumn").Visible = True
        End Select
    End Sub

    Public Sub ShowDataByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If chkExcludeZeroPrice.Checked = True Then
            ZeroPriceFilter = " AND Price <> 0"
        Else
            ZeroPriceFilter = ""
        End If
        If cboPickTicketNumber.Text <> "" Then
            PickFilter = " AND PickTicketNumber = '" + cboPickTicketNumber.Text + "'"
        Else
            PickFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            POFilter = " AND CustomerPO LIKE '%" + usefulFunctions.checkQuote(txtCustomerPO.Text) + "%'"
        Else
            POFilter = ""
        End If
        If txtShipCity.Text <> "" Then
            CityFilter = " AND ShipCity LIKE '%" + usefulFunctions.checkQuote(txtShipCity.Text) + "%'"
        Else
            CityFilter = ""
        End If
        If txtState.Text <> "" Then
            StateFilter = " AND ShipState LIKE '%" + usefulFunctions.checkQuote(txtState.Text) + "%'"
        Else
            StateFilter = ""
        End If
        If txtZip.Text <> "" Then
            zipFilter = " AND ShipZip LIKE '%" + usefulFunctions.checkQuote(txtZip.Text) + "%'"
        Else
            ZipFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + txtTextFilter.Text + "%' OR PartDescription LIKE '%" + txtTextFilter.Text + "%' OR CustomerID LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If txtShipProcess.Text <> "" Then
            ProcessFilter = " AND (PackingSlip LIKE '%" + txtShipProcess.Text + "%' OR SOLog LIKE '%" + txtShipProcess.Text + "%' OR CertsPulled LIKE '%" + txtShipProcess.Text + "%' OR PulledBy LIKE '%" + txtShipProcess.Text + "%')"
        Else
            ProcessFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipment = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipment + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboSalesOrderKey.Text <> "" Then
            SONumber = Val(cboSalesOrderKey.Text)
            strSalesOrder = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSalesOrder + "'"
        Else
            SOFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            If ViewAllLinesToolStripMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
                DateFilter = " AND ShipDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        End If
        If chkViewPending.Checked = True Then
            StatusFilter = " AND ShipmentStatus = 'PENDING'"
        Else
            StatusFilter = ""
        End If
        If chkViewDropShips.Checked = True Then
            DropShipFilter = " AND Dropship = 'YES'"
        Else
            DropShipFilter = ""
        End If
        If chkShippedStatus.Checked = True Then
            ShippedStatus = " AND LineStatus = 'SHIPPED'"
        Else
            ShippedStatus = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE DivisionID <> @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus + " ORDER BY DivisionID, ShipmentNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentLineQuery2")
            dgvShipmentLineQuery.DataSource = ds.Tables("ShipmentLineQuery2")
            con.Close()

            Me.dgvShipmentLineQuery.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE DivisionID = @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus + " ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentLineQuery2")
            dgvShipmentLineQuery.DataSource = ds.Tables("ShipmentLineQuery2")
            con.Close()

            Me.dgvShipmentLineQuery.Columns("DivisionIDColumn").Visible = False
        End If

        'Enable editing of COS for admin
        If EmployeeSecurityCode = 1001 Then
            Me.dgvShipmentLineQuery.Columns("ExtendedCOSColumn").ReadOnly = False
        Else
            Me.dgvShipmentLineQuery.Columns("ExtendedCOSColumn").ReadOnly = True
        End If
        GlobalVariables.stringVar = "SELECT * FROM ShipmentLineQuery2 WHERE DivisionID <> @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus + " ORDER BY DivisionID, ShipmentNumber"
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvShipmentLineQuery.DataSource = Nothing

        Me.dgvShipmentLineQuery.Columns("DivisionIDColumn").Visible = False

        If EmployeeSecurityCode = "1001" Then
            Me.dgvShipmentLineQuery.Columns("ExtendedCOSColumn").ReadOnly = False
        Else
            Me.dgvShipmentLineQuery.Columns("ExtendedCOSColumn").ReadOnly = True
        End If
    End Sub

    Public Sub LoadItemList()
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

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        If ViewAllLinesToolStripMenuItem.Checked = True Then
            ShipNumberFilter = ""
        ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
            ShipNumberFilter = " AND ShipDate >= '1/1/2020'"
        Else
            ShipNumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID" + ShipNumberFilter + " ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds3.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesOrderKey()
        If ViewAllLinesToolStripMenuItem.Checked = True Then
            SONumberFilter = ""
        ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
            SONumberFilter = " AND SalesOrderDate >= '1/1/2020'"
        Else
            SONumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + SONumberFilter + " AND SOStatus <> 'QUOTE' ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SalesOrderHeaderTable")
        cboSalesOrderKey.DataSource = ds4.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderKey.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemList")
        cboPartDescription.DataSource = ds5.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CustomerList")
        cboCustomerName.DataSource = ds6.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadPickTicketNumber()
        cmd = New SqlCommand("SELECT PickListHeaderKey FROM PickListHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "PickListHeaderTable")
        cboPickTicketNumber.DataSource = ds7.Tables("PickListHeaderTable")
        con.Close()
        cboPickTicketNumber.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadItemList()
        LoadPickTicketNumber()
        LoadPartDescription()
        LoadShipmentNumber()
        LoadSalesOrderKey()
        LoadCustomerList()
        LoadCustomerName()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearVariables()
        PickFilter = ""
        ShippedStatus = ""
        CityFilter = ""
        ZipFilter = ""
        StateFilter = ""
        DropShipFilter = ""
        ProcessFilter = ""
        TextFilter = ""
        StatusFilter = ""
        PartFilter = ""
        CustomerFilter = ""
        POFilter = ""
        HeatFilter = ""
        ShipmentFilter = ""
        SOFilter = ""
        DateFilter = ""
        ProductTotal = 0
        TotalCOS = 0
        ProfitMargin = 0
        TotalQuantity = 0
        strBeginDate = ""
        strEndDate = ""
        strSalesOrder = ""
        strShipment = ""
        ShipmentNumber = 0
        SONumber = 0
        ZeroPriceFilter = ""
        SONumberFilter = ""
        ShipNumberFilter = ""
    End Sub

    Public Sub ClearData()
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""
        cboShipmentNumber.Text = ""
        cboSalesOrderKey.Text = ""
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboPickTicketNumber.Text = ""

        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1
        cboSalesOrderKey.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPickTicketNumber.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False
        chkViewDropShips.Checked = False
        chkShippedStatus.Checked = False
        chkExcludeZeroPrice.Checked = False

        txtCustomerPO.Clear()
        txtProductTotal.Clear()
        txtProfitMargin.Clear()
        txtTotalCOS.Clear()
        txtTotalQuantity.Clear()
        txtTextFilter.Clear()
        txtZip.Clear()
        txtState.Clear()
        txtShipCity.Clear()
        txtShipProcess.Clear()

        cboPartNumber.Focus()
    End Sub

    Public Sub LoadShipmentTotalsByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If chkExcludeZeroPrice.Checked = True Then
            ZeroPriceFilter = " AND Price <> 0"
        Else
            ZeroPriceFilter = ""
        End If
        If cboPickTicketNumber.Text <> "" Then
            PickFilter = " AND FOB = '" + usefulFunctions.checkQuote(cboPickTicketNumber.Text) + "'"
        Else
            PickFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            POFilter = " AND CustomerPO LIKE '%" + usefulFunctions.checkQuote(txtCustomerPO.Text) + "%'"
        Else
            POFilter = ""
        End If
        If txtShipCity.Text <> "" Then
            CityFilter = " AND ShipCity LIKE '%" + usefulFunctions.checkQuote(txtShipCity.Text) + "%'"
        Else
            CityFilter = ""
        End If
        If txtState.Text <> "" Then
            StateFilter = " AND ShipState LIKE '%" + usefulFunctions.checkQuote(txtState.Text) + "%'"
        Else
            StateFilter = ""
        End If
        If txtZip.Text <> "" Then
            ZipFilter = " AND ShipZip LIKE '%" + usefulFunctions.checkQuote(txtZip.Text) + "%'"
        Else
            ZipFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + txtTextFilter.Text + "%' OR PartDescription LIKE '%" + txtTextFilter.Text + "%' OR CustomerID LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If txtShipProcess.Text <> "" Then
            ProcessFilter = " AND (PackingSlip LIKE '%" + txtShipProcess.Text + "%' OR SOLog LIKE '%" + txtShipProcess.Text + "%' OR CertsPulled LIKE '%" + txtShipProcess.Text + "%' OR PulledBy LIKE '%" + txtShipProcess.Text + "%')"
        Else
            ProcessFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipment = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipment + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboSalesOrderKey.Text <> "" Then
            SONumber = Val(cboSalesOrderKey.Text)
            strSalesOrder = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSalesOrder + "'"
        Else
            SOFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            If ViewAllLinesToolStripMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
                DateFilter = " AND ShipDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        End If
        If chkViewPending.Checked = True Then
            StatusFilter = " AND ShipmentStatus = 'PENDING'"
        Else
            StatusFilter = ""
        End If
        If chkViewDropShips.Checked = True Then
            DropShipFilter = " AND Dropship = 'YES'"
        Else
            DropShipFilter = ""
        End If
        If chkShippedStatus.Checked = True Then
            ShippedStatus = " AND LineStatus = 'SHIPPED'"
        Else
            ShippedStatus = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            Dim ProductTotalString As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineQuery2 WHERE DivisionID <> @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus
            Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
            ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalCOSString As String = "SELECT SUM(ExtendedCOS) FROM ShipmentLineQuery2 WHERE DivisionID <> @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus
            Dim TotalCOSCommand As New SqlCommand(TotalCOSString, con)
            TotalCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            TotalCOSCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalCOSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalQuantityString As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery2 WHERE DivisionID <> @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus
            Dim TotalQuantityCommand As New SqlCommand(TotalQuantityString, con)
            TotalQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            TotalQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                TotalCOS = CDbl(TotalCOSCommand.ExecuteScalar)
            Catch ex As Exception
                TotalCOS = 0
            End Try
            Try
                TotalQuantity = CDbl(TotalQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                TotalQuantity = 0
            End Try
            con.Close()

            If ProductTotal <> 0 Then
                ProfitMargin = 1 - (TotalCOS / ProductTotal)
            Else
                ProfitMargin = 0.0
            End If
        Else
            Dim ProductTotalString As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineQuery2 WHERE DivisionID = @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus
            Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
            ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalCOSString As String = "SELECT SUM(ExtendedCOS) FROM ShipmentLineQuery2 WHERE DivisionID = @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus
            Dim TotalCOSCommand As New SqlCommand(TotalCOSString, con)
            TotalCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalCOSCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalCOSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalQuantityString As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery2 WHERE DivisionID = @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus
            Dim TotalQuantityCommand As New SqlCommand(TotalQuantityString, con)
            TotalQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                TotalCOS = CDbl(TotalCOSCommand.ExecuteScalar)
            Catch ex As Exception
                TotalCOS = 0
            End Try
            Try
                TotalQuantity = CDbl(TotalQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                TotalQuantity = 0
            End Try
            con.Close()

            If ProductTotal <> 0 Then
                ProfitMargin = 1 - (TotalCOS / ProductTotal)
            Else
                ProfitMargin = 0.0
            End If
        End If

        txtTotalQuantity.Text = TotalQuantity
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtTotalCOS.Text = FormatCurrency(TotalCOS, 2)
        txtProfitMargin.Text = FormatPercent(ProfitMargin, 2)
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilter()
        LoadShipmentTotalsByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
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

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If rdoCustomer.Checked = True Then
            GlobalGroupingShipmentLines = "CUSTOMER"
        ElseIf rdoPart.Checked = True Then
            GlobalGroupingShipmentLines = "PART"
        ElseIf rdoShipment.Checked = True Then
            GlobalGroupingShipmentLines = "SHIPMENT"
        ElseIf rdoZip.Checked = True Then
            GlobalGroupingShipmentLines = "ZIP"
        Else
            GlobalGroupingShipmentLines = "SHIPMENT"
        End If

        GDS = ds

        Using NewPrintShipmentLinesFiltered As New PrintShipmentLinesFiltered
            Dim result = NewPrintShipmentLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintShipmentLinesFiltered As New PrintShipmentLinesFiltered
            Dim result = NewPrintShipmentLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvShipmentLineQuery_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentLineQuery.CellDoubleClick
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowIndex As Integer = Me.dgvShipmentLineQuery.CurrentCell.RowIndex

        RowShipNumber = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowDivision = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("DivisionIDColumn").Value

        GlobalShipmentNumber = RowShipNumber

        If cboDivisionID.Text = "ADM" Then
            GlobalDivisionCode = RowDivision
        Else
            GlobalDivisionCode = cboDivisionID.Text
        End If

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
            Using NewPrintPackingListRemote As New PrintPackingListRemote
                Dim Result = NewPrintPackingListRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPackingList As New PrintPackingList
                Dim Result = NewPrintPackingList.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvShipmentLineQuery_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentLineQuery.CellValueChanged
        Dim RowShipmentNumber, RowShipmentLineNumber As Integer
        Dim RowExtendedCOS As Double
        Dim RowLineComment, RowSerialNumber, RowDivision As String
        Dim RowLineBoxes, RowLineWeight As Double
        Dim RowPackingSlip, RowCertsPulled, RowPulledBy, RowSOLog As String

        If Me.dgvShipmentLineQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentLineQuery.CurrentCell.RowIndex

            Try
                RowShipmentNumber = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                RowShipmentNumber = 0
            End Try
            Try
                RowShipmentLineNumber = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("ShipmentLineNumberColumn").Value
            Catch ex As Exception
                RowShipmentLineNumber = 0
            End Try
            Try
                RowExtendedCOS = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("ExtendedCOSColumn").Value
            Catch ex As Exception
                RowExtendedCOS = 0
            End Try
            Try
                RowLineBoxes = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("LineBoxesColumn").Value
            Catch ex As Exception
                RowLineBoxes = 0
            End Try
            Try
                RowLineComment = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                RowLineComment = ""
            End Try
            Try
                RowLineWeight = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("LineWeightColumn").Value
            Catch ex As Exception
                RowLineWeight = 0
            End Try
            Try
                RowSerialNumber = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("SerialNumberColumn").Value
            Catch ex As Exception
                RowSerialNumber = ""
            End Try
            Try
                RowDivision = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try
            Try
                RowPackingSlip = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("PackingSlipColumn").Value
            Catch ex As Exception
                RowPackingSlip = ""
            End Try
            Try
                RowCertsPulled = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("CertsPulledColumn").Value
            Catch ex As Exception
                RowCertsPulled = 0
            End Try
            Try
                RowPulledBy = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("PulledColumn").Value
            Catch ex As Exception
                RowPulledBy = ""
            End Try
            Try
                RowSOLog = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("SOLogColumn").Value
            Catch ex As Exception
                RowSOLog = ""
            End Try

            If EmployeeSecurityCode = 1001 Then
                'UPDATE Ship Lines
                cmd = New SqlCommand("UPDATE ShipmentLineTable SET ExtendedCOS = @ExtendedCOS, LineBoxes = @LineBoxes, LineWeight = @LineWeight, LineComment = @LineComment, SerialNumber = @SerialNumber WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber
                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = RowExtendedCOS
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = RowLineBoxes
                    .Add("@LineWeight", SqlDbType.VarChar).Value = RowLineWeight
                    .Add("@LineComment", SqlDbType.VarChar).Value = RowLineComment
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'UPDATE Ship Header
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET PackingSlip = @PackingSlip, CertsPulled = @CertsPulled, PulledBy = @PulledBy, SOLog = @SOLog WHERE ShipmentNumber = @ShipmentNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                    .Add("@PackingSlip", SqlDbType.VarChar).Value = RowPackingSlip
                    .Add("@CertsPulled", SqlDbType.VarChar).Value = RowCertsPulled
                    .Add("@PulledBy", SqlDbType.VarChar).Value = RowPulledBy
                    .Add("@SOLog", SqlDbType.VarChar).Value = RowSOLog
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowDataByFilter()
            Else
                'UPDATE Ship Lines
                cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineBoxes = @LineBoxes, LineWeight = @LineWeight, LineComment = @LineComment, SerialNumber = @SerialNumber WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = RowLineBoxes
                    .Add("@LineWeight", SqlDbType.VarChar).Value = RowLineWeight
                    .Add("@LineComment", SqlDbType.VarChar).Value = RowLineComment
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@PackingSlip", SqlDbType.VarChar).Value = RowPackingSlip
                    .Add("@CertsPulled", SqlDbType.VarChar).Value = RowCertsPulled
                    .Add("@PulledBy", SqlDbType.VarChar).Value = RowPulledBy
                    .Add("@SOLog", SqlDbType.VarChar).Value = RowSOLog
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'UPDATE Ship Header
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET PackingSlip = @PackingSlip, CertsPulled = @CertsPulled, PulledBy = @PulledBy, SOLog = @SOLog WHERE ShipmentNumber = @ShipmentNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                    .Add("@PackingSlip", SqlDbType.VarChar).Value = RowPackingSlip
                    .Add("@CertsPulled", SqlDbType.VarChar).Value = RowCertsPulled
                    .Add("@PulledBy", SqlDbType.VarChar).Value = RowPulledBy
                    .Add("@SOLog", SqlDbType.VarChar).Value = RowSOLog
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowDataByFilter()
            End If
        Else
            'Skip Update
        End If
    End Sub

    Private Sub chkViewPending_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewPending.CheckedChanged
        If chkViewPending.Checked = True Then
            chkShippedStatus.Checked = False
        End If
    End Sub

    Private Sub chkShippedStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShippedStatus.CheckedChanged
        If chkShippedStatus.Checked = True Then
            chkViewPending.Checked = False
        End If
    End Sub

    Private Sub ViewAllLinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllLinesToolStripMenuItem.Click
        ViewAllLinesToolStripMenuItem.Checked = True
        ViewLast3YearsToolStripMenuItem.Checked = False
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        LoadSalesOrderKey()
        LoadShipmentNumber()
    End Sub

    Private Sub ViewLast3YearsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLast3YearsToolStripMenuItem.Click
        ViewAllLinesToolStripMenuItem.Checked = False
        ViewLast3YearsToolStripMenuItem.Checked = True
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        LoadSalesOrderKey()
        LoadShipmentNumber()
    End Sub

    Private Sub cmdCoC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCoC.Click
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If chkExcludeZeroPrice.Checked = True Then
            ZeroPriceFilter = " AND Price <> 0"
        Else
            ZeroPriceFilter = ""
        End If
        If cboPickTicketNumber.Text <> "" Then
            PickFilter = " AND PickTicketNumber = '" + cboPickTicketNumber.Text + "'"
        Else
            PickFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            POFilter = " AND CustomerPO LIKE '%" + usefulFunctions.checkQuote(txtCustomerPO.Text) + "%'"
        Else
            POFilter = ""
        End If
        If txtShipCity.Text <> "" Then
            CityFilter = " AND ShipCity LIKE '%" + usefulFunctions.checkQuote(txtShipCity.Text) + "%'"
        Else
            CityFilter = ""
        End If
        If txtState.Text <> "" Then
            StateFilter = " AND ShipState LIKE '%" + usefulFunctions.checkQuote(txtState.Text) + "%'"
        Else
            StateFilter = ""
        End If
        If txtZip.Text <> "" Then
            ZipFilter = " AND ShipZip LIKE '%" + usefulFunctions.checkQuote(txtZip.Text) + "%'"
        Else
            ZipFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + txtTextFilter.Text + "%' OR PartDescription LIKE '%" + txtTextFilter.Text + "%' OR CustomerID LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If txtShipProcess.Text <> "" Then
            ProcessFilter = " AND (PackingSlip LIKE '%" + txtShipProcess.Text + "%' OR SOLog LIKE '%" + txtShipProcess.Text + "%' OR CertsPulled LIKE '%" + txtShipProcess.Text + "%' OR PulledBy LIKE '%" + txtShipProcess.Text + "%')"
        Else
            ProcessFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipment = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipment + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboSalesOrderKey.Text <> "" Then
            SONumber = Val(cboSalesOrderKey.Text)
            strSalesOrder = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSalesOrder + "'"
        Else
            SOFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            If ViewAllLinesToolStripMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
                DateFilter = " AND ShipDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        End If
        If chkViewPending.Checked = True Then
            StatusFilter = " AND ShipmentStatus = 'PENDING'"
        Else
            StatusFilter = ""
        End If
        If chkViewDropShips.Checked = True Then
            DropShipFilter = " AND Dropship = 'YES'"
        Else
            DropShipFilter = ""
        End If
        If chkShippedStatus.Checked = True Then
            ShippedStatus = " AND LineStatus = 'SHIPPED'"
        Else
            ShippedStatus = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE DivisionID <> @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus + " ORDER BY DivisionID, ShipmentNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentLineQuery2")
            dgvShipmentLineQuery.DataSource = ds.Tables("ShipmentLineQuery2")
            con.Close()

            Me.dgvShipmentLineQuery.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE DivisionID = @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus + " ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentLineQuery2")
            dgvShipmentLineQuery.DataSource = ds.Tables("ShipmentLineQuery2")
            con.Close()

            Me.dgvShipmentLineQuery.Columns("DivisionIDColumn").Visible = False
        End If

        'Enable editing of COS for admin
        If EmployeeSecurityCode = 1001 Then
            Me.dgvShipmentLineQuery.Columns("ExtendedCOSColumn").ReadOnly = False
        Else
            Me.dgvShipmentLineQuery.Columns("ExtendedCOSColumn").ReadOnly = True
        End If

        GlobalVariables.stringVar = "SELECT * FROM ShipmentLineQuery2 WHERE DivisionID <> @DivisionID" + PartFilter + CustomerFilter + PickFilter + POFilter + StateFilter + CityFilter + ZipFilter + ShipmentFilter + SOFilter + TextFilter + DropShipFilter + DateFilter + StatusFilter + ProcessFilter + ZeroPriceFilter + ShippedStatus + " ORDER BY DivisionID, ShipmentNumber"

        If con.State = ConnectionState.Closed Then con.Open()
        
        cmd = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        GlobalDivisionCode = cboDivisionID.Text

        cmd3 = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = @DivisionID AND (ItemClass = 'ANCHOR BOLTS' OR ItemClass = 'MACHINING' OR ItemClass = 'CARR BOLTS' OR ItemClass = 'CLEVIS' OR ItemClass = 'CPG NUTS' OR ItemClass = 'DES' OR ItemClass = 'EPOXY' OR ItemClass = 'EXP ANCHOR' OR ItemClass = 'EYE BOLTS' OR ItemClass = 'HEX BOLTS' OR ItemClass = 'HEX NUTS' OR ItemClass = 'JAM NUTS' OR ItemClass = 'LAG BOLTS' OR ItemClass = 'LOCK NUTS' OR ItemClass = 'METRIC' OR ItemClass = 'SES' OR ItemClass = 'THREADED ROD' OR ItemClass = 'TURNBUCKLES' OR ItemClass = 'U BOLTS' OR ItemClass = 'WASHERS')", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        GDS1 = New DataSet()

        GDS1 = ds

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(GDS1, "CustomerList")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(GDS1, "ItemList")

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
            Dim NewPrintCustCertOfCompliance As New PrintCertOfComplianceRemote
            NewPrintCustCertOfCompliance.Show()
        Else
            Dim NewPrintCustCertOfCompliance As New PrintCertOfCompliance
            NewPrintCustCertOfCompliance.Show()
        End If

    End Sub

    Private Sub cmdPackingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPackingSlip.Click
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""

        If Me.dgvShipmentLineQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentLineQuery.CurrentCell.RowIndex

            RowShipNumber = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowCustomer = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDivision = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("DivisionIDColumn").Value

            'Auto-print certs based on the line items
            GlobalShipmentNumber = RowShipNumber
            GlobalCertCustomer = RowCustomer
            GlobalDivisionCode = RowDivision

            'Chose the correct Print Form (REMOTE or LOCAL)

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
                Using NewPrintPackingListRemote As New PrintPackingListRemote
                    Dim result = NewPrintPackingListRemote.ShowDialog()
                End Using
            Else
                Using NewPrintPackingList As New PrintPackingList
                    Dim Result = NewPrintPackingList.ShowDialog()
                End Using
            End If
        Else
            'skip
        End If
    End Sub

    Private Sub cmdTWECerts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTWECerts.Click

        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""

        If Me.dgvShipmentLineQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentLineQuery.CurrentCell.RowIndex

            RowShipNumber = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowCustomer = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDivision = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("DivisionIDColumn").Value

            'Auto-print certs based on the line items
            GlobalShipmentNumber = RowShipNumber
            GlobalCertCustomer = RowCustomer
            GlobalDivisionCode = RowDivision
            '*******************************************************************************************************************************************
            'Check to make sure at least one cert will print otherwise do not open Print Form
            Dim CheckForCerts As Integer = 0

            'Get Pull Test Number for selected Lot Number Data
            Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
            CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipNumber
            CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
            If reader2.HasRows Then
                reader2.Read()
                If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                    CheckForCerts = 0
                Else
                    CheckForCerts = reader2.Item("CountShipmentNumber")
                End If
            Else
                CheckForCerts = 0
            End If
            reader2.Close()
            con.Close()

            If CheckForCerts = 0 Then
                MsgBox("There are no certs to print. If you entered a Lot #, check the error log.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Chose the correct Print Form (REMOTE or LOCAL)

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
                    Using NewPrintTWCert01Remote As New PrintTWCert01Remote
                        Dim result = NewPrintTWCert01Remote.ShowDialog()
                    End Using
                Else
                    Using NewPrintTWCert01 As New PrintTWCert01
                        Dim result = NewPrintTWCert01.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

End Class