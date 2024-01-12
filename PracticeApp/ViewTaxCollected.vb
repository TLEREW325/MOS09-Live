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
Public Class ViewTaxCollected
    Inherits System.Windows.Forms.Form

    Dim DateFilter, InvoiceFilter, SOFilter, CustomerFilter, MonthFilter As String
    Dim SONumber, InvoiceNumber As Integer
    Dim strInvoiceNumber, strSONumber As String
    Dim BeginDate, EndDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewTaxCollected_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.MonthTable' table. You can move, or remove it, as needed.
        Me.MonthTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.MonthTable)

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

    Private Sub dgvInvoiceQuery_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvInvoiceQuery.CellDoubleClick
        If Me.dgvInvoiceQuery.RowCount > 0 Then
            Dim RowInvoiceNumber, RowShipmentNumber As Integer

            Dim RowIndex As Integer = Me.dgvInvoiceQuery.CurrentCell.RowIndex
            RowInvoiceNumber = Me.dgvInvoiceQuery.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            RowShipmentNumber = Me.dgvInvoiceQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value

            GlobalInvoiceNumber = RowInvoiceNumber
            GlobalShipmentNumber = RowShipmentNumber
            GlobalDivisionCode = cboDivisionID.Text

            'Choose the Invoice Print Form by division
            If RowShipmentNumber = 0 Then
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                    Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                End Using
            Else
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                    Dim result = NewPrintInvoiceSingle.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Public Sub ClearData()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboSONumber.Text = ""
        cboMonth.Text = ""
        cboYear.Text = ""
        cboInvoiceNumber.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSONumber.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
        cboYear.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        DateFilter = ""
        InvoiceFilter = ""
        SOFilter = ""
        CustomerFilter = ""
        MonthFilter = ""
        SONumber = 0
        InvoiceNumber = 0
        strInvoiceNumber = ""
        strSONumber = ""
        GlobalInvoiceNumber = 0
        GlobalShipmentNumber = 0
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvInvoiceQuery.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSONumber.Text <> "" Then
            SONumber = Val(cboSONumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderNumber = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboInvoiceNumber.Text <> "" Then
            InvoiceNumber = Val(cboInvoiceNumber.Text)
            strInvoiceNumber = CStr(InvoiceNumber)
            InvoiceFilter = " AND InvoiceNumber = '" + strInvoiceNumber + "'"
        Else
            InvoiceFilter = ""
        End If
        If cboInvoiceNumber.Text <> "" Then
            InvoiceNumber = Val(cboInvoiceNumber.Text)
            strInvoiceNumber = CStr(InvoiceNumber)
            InvoiceFilter = " AND InvoiceHeaderKey = '" + strInvoiceNumber + "'"
        Else
            InvoiceFilter = ""
        End If
        If cboMonth.Text <> "" Then
            LoadMonth()
            MonthFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Else
            MonthFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID" + CustomerFilter + SOFilter + InvoiceFilter + MonthFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderQuery")
        dgvInvoiceQuery.DataSource = ds.Tables("InvoiceHeaderQuery")
        con.Close()
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

    Public Sub LoadSalesOrder()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SalesOrderHeaderTable")
        cboSONumber.DataSource = ds2.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadInvoiceNumber()
        cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID ORDER BY InvoiceNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "InvoiceHeaderTable")
        cboInvoiceNumber.DataSource = ds3.Tables("InvoiceHeaderTable")
        con.Close()
        cboInvoiceNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        'Set date format
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            dgvInvoiceQuery.Columns("SalesTax2Column").Visible = True
            dgvInvoiceQuery.Columns("SalesTax3Column").Visible = True
        Else
            dgvInvoiceQuery.Columns("SalesTax2Column").Visible = False
            dgvInvoiceQuery.Columns("SalesTax3Column").Visible = False
        End If

        LoadSalesOrder()
        LoadInvoiceNumber()
        LoadCustomer()
        LoadCustomerName()
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

    Public Sub LoadMonth()
        If cboMonth.Text = "January" Then
            BeginDate = "1/1/" + cboYear.Text
            EndDate = "1/31/" + cboYear.Text
        ElseIf cboMonth.Text = "Febuary" Then
            BeginDate = "2/1/" + cboYear.Text
            EndDate = "2/28/" + cboYear.Text
        ElseIf cboMonth.Text = "March" Then
            BeginDate = "3/1/" + cboYear.Text
            EndDate = "3/31/" + cboYear.Text
        ElseIf cboMonth.Text = "April" Then
            BeginDate = "4/1/" + cboYear.Text
            EndDate = "4/30/" + cboYear.Text
        ElseIf cboMonth.Text = "May" Then
            BeginDate = "5/1/" + cboYear.Text
            EndDate = "5/31/" + cboYear.Text
        ElseIf cboMonth.Text = "June" Then
            BeginDate = "6/1/" + cboYear.Text
            EndDate = "6/30/" + cboYear.Text
        ElseIf cboMonth.Text = "July" Then
            BeginDate = "7/1/" + cboYear.Text
            EndDate = "7/31/" + cboYear.Text
        ElseIf cboMonth.Text = "August" Then
            BeginDate = "8/1/" + cboYear.Text
            EndDate = "8/31/" + cboYear.Text
        ElseIf cboMonth.Text = "September" Then
            BeginDate = "9/1/" + cboYear.Text
            EndDate = "9/30/" + cboYear.Text
        ElseIf cboMonth.Text = "October" Then
            BeginDate = "10/1/" + cboYear.Text
            EndDate = "10/31/" + cboYear.Text
        ElseIf cboMonth.Text = "November" Then
            BeginDate = "11/1/" + cboYear.Text
            EndDate = "11/30/" + cboYear.Text
        ElseIf cboMonth.Text = "December" Then
            BeginDate = "12/1/" + cboYear.Text
            EndDate = "12/31/" + cboYear.Text
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        If chkDateRange.Checked = True Then
            cboMonth.SelectedIndex = -1
            cboYear.SelectedIndex = -1
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            GDS = ds
            Using NewPrintSalesTaxReportTFF As New PrintSalesTaxReportTFF
                Dim Result = NewPrintSalesTaxReportTFF.ShowDialog()
            End Using
        Else
            GDS = ds
            Using NewPrintSalesTaxReport As New PrintSalesTaxReport
                Dim Result = NewPrintSalesTaxReport.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PrintTaxSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintTaxSummaryToolStripMenuItem.Click
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            GDS = ds
            Using NewPrintSalesTaxReportTFF As New PrintSalesTaxReportTFF
                Dim Result = NewPrintSalesTaxReportTFF.ShowDialog()
            End Using
        Else
            GDS = ds
            Using NewPrintSalesTaxReport As New PrintSalesTaxReport
                Dim Result = NewPrintSalesTaxReport.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub
End Class