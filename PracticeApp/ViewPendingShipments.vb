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
Public Class ViewPendingShipments
    Inherits System.Windows.Forms.Form

    Dim BeginDate, EndDate As Date
    Dim CustomerFilter, POFilter, ShipmentFilter, SOFilter, DateFilter, PartFilter, SalesmanFilter As String
    Dim SONumber, ShipmentNumber As Integer
    Dim strSONumber, strShipmentNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewPendingShipments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

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

    Private Sub dgvPendingShipments_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim RowShipmentNumber As Integer
        Dim RowIndex As Integer = Me.dgvShipmentLineQuery.CurrentCell.RowIndex

        RowShipmentNumber = Me.dgvShipmentLineQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value

        GlobalShipmentNumber = RowShipmentNumber
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
            Using NewPrintPackingListRemote As New PrintPackingListRemote
                Dim Result = NewPrintPackingListRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPackingList As New PrintPackingList
                Dim Result = NewPrintPackingList.ShowDialog()
            End Using
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvShipmentLineQuery.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            POFilter = " AND CustomerPO = '" + txtCustomerPO.Text + "'"
        Else
            POFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboSalesman.Text <> "" Then
            SalesmanFilter = " AND SalesmanID = '" + cboSalesman.Text + "'"
        Else
            SalesmanFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM ShipmentLineQuery WHERE DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus" + PartFilter + CustomerFilter + SOFilter + ShipmentFilter + SalesmanFilter + POFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentLineQuery")
        dgvShipmentLineQuery.DataSource = ds.Tables("ShipmentLineQuery")
        con.Close()
    End Sub

    Public Sub LoadCustomer()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        cboCustomerName.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesOrder()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds3.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds4.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesperson()
        cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "EmployeeData")
        cboSalesman.DataSource = ds5.Tables("EmployeeData")
        con.Close()
        cboSalesman.SelectedIndex = -1
    End Sub

    Public Sub LoadSalespersonTWD()
        cmd = New SqlCommand("SELECT DISTINCT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2 OR DivisionKey = @DivisionKey3", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@DivisionKey3", SqlDbType.VarChar).Value = "TFP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "EmployeeData")
        cboSalesman.DataSource = ds5.Tables("EmployeeData")
        con.Close()
        cboSalesman.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            LoadSalespersonTWD()
        Else
            LoadSalesperson()
        End If

        LoadCustomer()
        LoadSalesOrder()
        LoadPartNumber()

        LoadShipmentNumber()
        ClearData()
        'ShowDataByFilters()
    End Sub

    Public Sub ClearVariables()
        CustomerFilter = ""
        POFilter = ""
        ShipmentFilter = ""
        SOFilter = ""
        DateFilter = ""
        PartFilter = ""
        SONumber = 0
        ShipmentNumber = 0
        strSONumber = ""
        strShipmentNumber = ""
    End Sub

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboSalesman.SelectedIndex = -1

        txtCustomerPO.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        cboCustomerID.Focus()
    End Sub

    Private Sub cmdOpenShipmentForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenShipmentForm.Click
        GlobalShipmentNumber = Val(cboShipmentNumber.Text)

        Dim NewShipmentCompletion As New ShipmentCompletion
        NewShipmentCompletion.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintPendingShipmentsFiltered As New PrintPendingShipmentsFiltered
            Dim result = NewPrintPendingShipmentsFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem1.Click
        GDS = ds

        Using NewPrintPendingShipmentsFiltered As New PrintPendingShipmentsFiltered
            Dim result = NewPrintPendingShipmentsFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub
End Class