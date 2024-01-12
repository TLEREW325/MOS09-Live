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
Public Class PrintCustomerMTDYTDTotals
    Inherits System.Windows.Forms.Form

    Dim CustomerFilter, SalespersonFilter, SalesTerritoryFilter, DateFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomer.DataSource = ds4.Tables("CustomerList")
        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomer.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesTerritory()
        cmd = New SqlCommand("SELECT DISTINCT SalesTerritory FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CustomerList")
        cboSalesTerritory.DataSource = ds5.Tables("CustomerList")
        con.Close()
        cboSalesTerritory.SelectedIndex = -1
    End Sub

    Private Sub PrintCustomerMTDYTDTotals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If EmployeeCompanyCode = "TWD" Then
            chkTerritory.Visible = True
            chkState.Visible = True
            chkGroupByZip.Visible = False
            chkSalesTerritory.Visible = False
        Else
            chkTerritory.Visible = False
            chkState.Visible = False
            chkGroupByZip.Visible = True
            chkSalesTerritory.Visible = True
        End If

        LoadCustomerList()
        LoadSalesTerritory()
    End Sub

    Public Sub ShowDataByFiltersGrouped()
        'Loads data into dataset for viewing
        If cboCustomer.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomer.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesTerritory.Text <> "" Then
            SalesTerritoryFilter = " AND SalesTerritory = '" + usefulFunctions.checkQuote(cboSalesTerritory.Text) + "'"
        Else
            SalesTerritoryFilter = ""
        End If

        cmd1 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID" + CustomerFilter + SalesTerritoryFilter, con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text


        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceHeaderQuery")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCustMTD_YTDInvoicesZip1
        MyReport.SetDataSource(ds)
        CRCustomerYTDViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Public Sub ShowDataByFiltersUnGrouped()
        'Loads data into dataset for viewing
        If cboCustomer.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomer.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesTerritory.Text <> "" Then
            SalesTerritoryFilter = " AND SalesTerritory = '" + usefulFunctions.checkQuote(cboSalesTerritory.Text) + "'"
        Else
            SalesTerritoryFilter = ""
        End If
    
        cmd1 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID" + CustomerFilter + SalesTerritoryFilter, con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text


        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceHeaderQuery")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCustMTD_YTDInvoices1
        MyReport.SetDataSource(ds)
        CRCustomerYTDViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Public Sub ShowDataByFiltersGroupByTerritory()
        'Loads data into dataset for viewing
        If cboCustomer.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomer.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesTerritory.Text <> "" Then
            SalesTerritoryFilter = " AND SalesTerritory = '" + usefulFunctions.checkQuote(cboSalesTerritory.Text) + "'"
        Else
            SalesTerritoryFilter = ""
        End If

        cmd1 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID" + CustomerFilter + SalesTerritoryFilter, con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text


        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceHeaderQuery")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCustMTD_YTDInvoicesTerritory1
        MyReport.SetDataSource(ds)
        CRCustomerYTDViewer.ReportSource = MyReport
        con.Close()
    End Sub
    Public Sub ShowDataByFiltersGroupByTerritoryPete()
        'Loads data into dataset for viewing
        If cboCustomer.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomer.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesTerritory.Text <> "" Then
            SalesTerritoryFilter = " AND SalesTerritory = '" + usefulFunctions.checkQuote(cboSalesTerritory.Text) + "'"
        Else
            SalesTerritoryFilter = ""
        End If

        cmd1 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID" + CustomerFilter + SalesTerritoryFilter, con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text


        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceHeaderQuery")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCustMTD_YTDInvoicesbyTerritory1
        MyReport.SetDataSource(ds)
        CRCustomerYTDViewer.ReportSource = MyReport
        con.Close()
    End Sub
    Public Sub ShowDataByFiltersGroupByState()
        'Loads data into dataset for viewing
        If cboCustomer.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomer.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesTerritory.Text <> "" Then
            SalesTerritoryFilter = " AND SalesTerritory = '" + usefulFunctions.checkQuote(cboSalesTerritory.Text) + "'"
        Else
            SalesTerritoryFilter = ""
        End If

        cmd1 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID" + CustomerFilter + SalesTerritoryFilter, con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text


        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceHeaderQuery")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCustMTD_YTDInvoicesbyState1
        MyReport.SetDataSource(ds)
        CRCustomerYTDViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        If chkGroupByZip.Checked = True Then
            ShowDataByFiltersGrouped()
        ElseIf chkSalesTerritory.Checked = True Then
            ShowDataByFiltersGroupByTerritory()
        ElseIf chkState.Checked = True Then
            ShowDataByFiltersGroupByState()
        ElseIf chkTerritory.Checked = True Then
            ShowDataByFiltersGroupByTerritoryPete()
        Else
            ShowDataByFiltersUnGrouped()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCustomer.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesTerritory.SelectedIndex = -1

        chkGroupByZip.Checked = False
        chkSalesTerritory.Checked = False
        chkState.Checked = False
        chkSalesTerritory.Checked = False

        'Loads data into dataset for viewing
        cmd1 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ZZZZ"


        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceHeaderQuery")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCustMTD_YTDInvoices1
        MyReport.SetDataSource(ds)
        CRCustomerYTDViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub chkGroupByZip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGroupByZip.CheckedChanged
        If chkGroupByZip.Checked = True Then chkSalesTerritory.Checked = False
    End Sub

    Private Sub chkSalesTerritory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSalesTerritory.CheckedChanged
        If chkSalesTerritory.Checked = True Then chkGroupByZip.Checked = False
    End Sub

    Private Sub CRCustomerYTDViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCustomerYTDViewer.Load
        If EmployeeCompanyCode = "TWD" Then
            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXCustMTD_YTDInvoices1
            MyReport.SetDataSource(ds)
            CRCustomerYTDViewer.ReportSource = Nothing

        Else
            ShowDataByFiltersUnGrouped()

        End If

    End Sub

    Private Sub chkTerritory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTerritory.CheckedChanged
        If chkTerritory.Checked = True Then chkState.Checked = False
    End Sub

    Private Sub chkState_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkState.CheckedChanged
        If chkState.Checked = True Then chkTerritory.Checked = False
    End Sub
End Class