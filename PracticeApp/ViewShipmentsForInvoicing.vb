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
Public Class ViewShipmentsForInvoicing
    Inherits System.Windows.Forms.Form

    Dim CustomerFilter, SOFilter, DateFilter As String
    Dim SONumber As Integer = 0
    Dim strSONumber As String = ""
    Dim BeginDate, EndDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewShipmentsForInvoicing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByDate

        LoadCurrentDivision()

        If EmployeeSecurityCode = "1003" Or EmployeeSecurityCode = "1002" Or EmployeeSecurityCode = "1001" Then
            gpxViewAll.Enabled = True
        Else
            gpxViewAll.Enabled = False
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

    Public Sub LoadTotals()
        Dim ShipmentTotal As Double = 0

        Dim ShipmentTotalStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus" + CustomerFilter + SOFilter + DateFilter
        Dim ShipmentTotalCommand As New SqlCommand(ShipmentTotalStatement, con)
        ShipmentTotalCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
        ShipmentTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ShipmentTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        ShipmentTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipmentTotal = CDbl(ShipmentTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ShipmentTotal = 0
        End Try
        con.Close()

        txtTotalShipments.Text = FormatCurrency(ShipmentTotal, 2)
    End Sub

    Public Sub LoadTotalsADM()
        Dim ShipmentTotal As Double = 0

        Dim ShipmentTotalStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID AND ShipmentStatus = @ShipmentStatus" + CustomerFilter + SOFilter + DateFilter
        Dim ShipmentTotalCommand As New SqlCommand(ShipmentTotalStatement, con)
        ShipmentTotalCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
        ShipmentTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        ShipmentTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        ShipmentTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipmentTotal = CDbl(ShipmentTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ShipmentTotal = 0
        End Try
        con.Close()

        txtTotalShipments.Text = FormatCurrency(ShipmentTotal, 2)
    End Sub

    Private Sub ViewShipmentsForInvoicing_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvShipmentHeader.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus" + CustomerFilter + SOFilter + DateFilter + " ORDER BY DivisionID, ShipmentNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")
        dgvShipmentHeader.DataSource = ds.Tables("ShipmentHeaderTable")
        con.Close()
        dgvShipmentHeader.Columns("DivisionIDColumn").Visible = False

        LoadTotals()
        LoadFormatting()
    End Sub

    Public Sub ShowDataAllCompanies()
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID AND ShipmentStatus = @ShipmentStatus ORDER BY DivisionID, CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")
        dgvShipmentHeader.DataSource = ds.Tables("ShipmentHeaderTable")
        con.Close()
        dgvShipmentHeader.Columns("DivisionIDColumn").Visible = True

        LoadTotalsADM()
        LoadFormatting()
    End Sub

    Public Sub LoadCustomer()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesOrderNumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds2.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerName.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomer()
        LoadCustomerName()
        LoadSalesOrderNumber()
        ClearData()
        ShowDataByFilters()
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

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1

        txtTotalShipments.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboCustomerID.Focus()
    End Sub

    Private Sub cmdViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAll.Click
        Dim LineDivision As String = ""

        Dim CountIndex As Integer = 0

        ShowDataAllCompanies()

        For Each row As DataGridViewRow In dgvShipmentHeader.Rows
            Try
                LineDivision = dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                LineDivision = ""
            End Try
      
            Select Case LineDivision
                Case "ATL"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightBlue
                    Catch ex As Exception
                        'skip
                    End Try
                Case "CBS"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightCoral
                    Catch ex As Exception
                        'skip
                    End Try
                Case "CGO"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSeaGreen
                    Catch ex As Exception
                        'skip
                    End Try
                Case "DEN"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSalmon
                    Catch ex As Exception
                        'skip
                    End Try
                Case "CHT"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightYellow
                    Catch ex As Exception
                        'skip
                    End Try
                Case "HOU"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSlateGray
                    Catch ex As Exception
                        'skip
                    End Try
                Case "SLC"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightPink
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFF"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightCoral
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFT"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightGoldenrodYellow
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TWD"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSteelBlue
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFP"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightGray
                    Catch ex As Exception
                        'skip
                    End Try
                Case "ALB"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.Wheat
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFJ"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.Linen
                    Catch ex As Exception
                        'skip
                    End Try
                Case Else
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.White
                    Catch ex As Exception
                        'skip
                    End Try
            End Select

            CountIndex = CountIndex + 1
        Next
    End Sub

    Private Sub cmdOpenForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenForm.Click
        Dim NewARProcessBatch As New ARProcessBatch
        NewARProcessBatch.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintShipmentsForInvoicing As New PrintShipmentsForInvoicing
            Dim Result = NewPrintShipmentsForInvoicing.ShowDialog
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintShipmentsForInvoicing As New PrintShipmentsForInvoicing
            Dim Result = NewPrintShipmentsForInvoicing.ShowDialog
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvShipmentHeader_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentHeader.CellDoubleClick
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""

        Dim RowIndex As Integer = Me.dgvShipmentHeader.CurrentCell.RowIndex

        RowShipNumber = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowDivision = Me.dgvShipmentHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value

        GlobalShipmentNumber = RowShipNumber
        GlobalDivisionCode = RowDivision

        Using NewPrintPackingList As New PrintPackingList
            Dim Result = NewPrintPackingList.ShowDialog()
        End Using
    End Sub

    Private Sub dgvShipmentHeader_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentHeader.CellValueChanged
        If dgvShipmentHeader.RowCount <> 0 Then
            Dim DivisionID, FreightQuoteNumber, ShipVia, PRONumber, CustomerPO, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, SpecialInstructions, SalesmanID, Comment As String
            Dim ShipmentNumber, NumberOfPallets As Integer
            Dim ShippingWeight, FreightQuoteAmount As Double

            Dim RowIndex As Integer = Me.dgvShipmentHeader.CurrentCell.RowIndex
            Try
                ShipmentNumber = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                ShipmentNumber = 0
            End Try
            Try
                DivisionID = Me.dgvShipmentHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                Comment = Me.dgvShipmentHeader.Rows(RowIndex).Cells("CommentColumn").Value
            Catch ex As Exception
                Comment = ""
            End Try
            Try
                ShipVia = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipViaColumn").Value
            Catch ex As Exception
                ShipVia = ""
            End Try
            Try
                PRONumber = Me.dgvShipmentHeader.Rows(RowIndex).Cells("PRONumberColumn").Value
            Catch ex As Exception
                PRONumber = ""
            End Try
            Try
                FreightQuoteNumber = Me.dgvShipmentHeader.Rows(RowIndex).Cells("FreightQuoteNumberColumn").Value
            Catch ex As Exception
                FreightQuoteNumber = ""
            End Try
            Try
                FreightQuoteAmount = Me.dgvShipmentHeader.Rows(RowIndex).Cells("FreightQuoteAmountColumn").Value
            Catch ex As Exception
                FreightQuoteAmount = 0
            End Try
            Try
                ShippingWeight = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShippingWeightColumn").Value
            Catch ex As Exception
                ShippingWeight = 0
            End Try
            Try
                NumberOfPallets = Me.dgvShipmentHeader.Rows(RowIndex).Cells("NumberOfPalletsColumn").Value
            Catch ex As Exception
                NumberOfPallets = 0
            End Try
            Try
                ShipAddress1 = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipAddress1Column").Value
            Catch ex As Exception
                ShipAddress1 = ""
            End Try
            Try
                ShipAddress2 = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipAddress2Column").Value
            Catch ex As Exception
                ShipAddress2 = ""
            End Try
            Try
                ShipCity = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipCityColumn").Value
            Catch ex As Exception
                ShipCity = ""
            End Try
            Try
                ShipState = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipStateColumn").Value
            Catch ex As Exception
                ShipState = ""
            End Try
            Try
                ShipZip = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipZipColumn").Value
            Catch ex As Exception
                ShipZip = ""
            End Try
            Try
                ShipCountry = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipCountryColumn").Value
            Catch ex As Exception
                ShipCountry = ""
            End Try
            Try
                CustomerPO = Me.dgvShipmentHeader.Rows(RowIndex).Cells("CustomerPOColumn").Value
            Catch ex As Exception
                CustomerPO = ""
            End Try
            Try
                SpecialInstructions = Me.dgvShipmentHeader.Rows(RowIndex).Cells("SpecialInstructionsColumn").Value
            Catch ex As Exception
                SpecialInstructions = ""
            End Try
            Try
                SalesmanID = Me.dgvShipmentHeader.Rows(RowIndex).Cells("SalesmanIDColumn").Value
            Catch ex As Exception
                SalesmanID = ""
            End Try

            If ShipmentNumber = 0 Then
                'Skip
            Else
                'UPDATE Shipment Header Table
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET Comment = @Comment, ShipVia = @ShipVia, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, CustomerPO = @CustomerPO, SpecialInstructions = @SpecialInstructions, SalesmanID = @SalesmanID WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                    .Add("@Comment", SqlDbType.VarChar).Value = Comment
                    .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                    .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                    .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = FreightQuoteNumber
                    .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = FreightQuoteAmount
                    .Add("@ShippingWeight", SqlDbType.VarChar).Value = ShippingWeight
                    .Add("@NumberOfPallets", SqlDbType.VarChar).Value = NumberOfPallets
                    .Add("@ShipAddress1", SqlDbType.VarChar).Value = ShipAddress1
                    .Add("@ShipAddress2", SqlDbType.VarChar).Value = ShipAddress2
                    .Add("@ShipCity", SqlDbType.VarChar).Value = ShipCity
                    .Add("@ShipState", SqlDbType.VarChar).Value = ShipState
                    .Add("@ShipZip", SqlDbType.VarChar).Value = ShipZip
                    .Add("@ShipCountry", SqlDbType.VarChar).Value = ShipCountry
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                    .Add("@SalesmanID", SqlDbType.VarChar).Value = SalesmanID
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub dgvShipmentHeader_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvShipmentHeader.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub dgvShipmentHeader_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvShipmentHeader.Sorted
        Dim LineDivision As String = ""

        Dim CountIndex As Integer = 0

        'ShowDataAllCompanies()

        For Each row As DataGridViewRow In dgvShipmentHeader.Rows
            Try
                LineDivision = dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                LineDivision = ""
            End Try

            Select Case LineDivision
                Case "ATL"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightBlue
                    Catch ex As Exception
                        'skip
                    End Try
                Case "CBS"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightCoral
                    Catch ex As Exception
                        'skip
                    End Try
                Case "CGO"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSeaGreen
                    Catch ex As Exception
                        'skip
                    End Try
                Case "CHT"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightYellow
                    Catch ex As Exception
                        'skip
                    End Try
                Case "HOU"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSlateGray
                    Catch ex As Exception
                        'skip
                    End Try
                Case "SLC"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightPink
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFF"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightCoral
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFT"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightGoldenrodYellow
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TWD"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSteelBlue
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFP"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightGray
                    Catch ex As Exception
                        'skip
                    End Try
                Case "ALB"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.Wheat
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFJ"
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.Linen
                    Catch ex As Exception
                        'skip
                    End Try
                Case Else
                    Try
                        dgvShipmentHeader.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.White
                    Catch ex As Exception
                        'skip
                    End Try
            End Select

            CountIndex = CountIndex + 1
        Next
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdViewByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByDate.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear2.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadFormatting()
        Dim ShipDate As String = ""
        Dim dtpShipDate, dtpCurrentdate As Date
        Dim ShipDayOfDate, ShipMonthOfDate, ShipYearOfDate As Integer
        Dim CurrentDayOfDate, CurrentMonthOfDate, CurrentYearOfDate As Integer
        Dim FormatLine As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvShipmentHeader.Rows
            Try
                ShipDate = row.Cells("ShipDateColumn").Value
            Catch ex As System.Exception
                ShipDate = ""
            End Try

            dtpShipDate = CDate(ShipDate)
            dtpCurrentdate = Today()

            CurrentDayOfDate = dtpCurrentdate.Day
            CurrentMonthOfDate = dtpCurrentdate.Month
            CurrentYearOfDate = dtpCurrentdate.Year

            ShipDayOfDate = dtpShipDate.Day
            ShipMonthOfDate = dtpShipDate.Month
            ShipYearOfDate = dtpShipDate.Year

            If ShipYearOfDate <> CurrentYearOfDate Then
                FormatLine = "YES"
            Else
                If ShipMonthOfDate <> CurrentMonthOfDate Then
                    FormatLine = "YES"
                Else
                    If ShipDayOfDate + 2 < CurrentDayOfDate Then
                        FormatLine = "YES"
                    Else
                        FormatLine = "NO"
                    End If
                End If
            End If

            If FormatLine = "YES" Then
                'Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                Me.dgvShipmentHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                'Do nothing
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub
End Class