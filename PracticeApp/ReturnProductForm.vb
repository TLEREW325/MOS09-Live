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
Public Class ReturnProductForm
    Inherits System.Windows.Forms.Form

    Dim CustomerPO, GetItemClass, GetVendor, GetVendorClass, LongDescription, ReturnStatus, CustomerClass, GLSalesAccount, GLReturnsAccount, GLInventoryAccount, GLCOGSAccount, GLSalesOffsetAccount, ItemClass, ItemClassName, CustomerID, CustomerName, Salesperson, Reason, PartNumber, Description As String
    Dim NextConsignmentReturnNumber, LastConsignmentReturnNumber, ConsignmentReturnNumber, SalesOrderNumber, ReturnNumber, ReturnLineNumber As Integer
    Dim TransactionCost, ProductTotal, FreightTotal, ReturnTotal, SalesTaxRate As Double
    Dim MaxPONumber, LastInventoryTransactionNumber, NextInventoryTransactionNumber, LastGLNumber, NextGLNumber, LastBatchNumber, GLBatchNumber, LastLineNumber, NextLineNumber, Counter, NextTransactionNumber, LastTransactionNumber As Integer
    Dim NextCostingTransactionNumber, LastCostingTransactionNumber, MaxDate, MaxTransactionNumber As Integer
    Dim Quantity, LineQuantity, TotalCOS, ShipmentUnitCost, LastTransactionCost, UnitPrice, ExtendedAmount, LinePrice, LineSalesTax, LineTotal As Double
    Dim StdUnitCost, SalesTaxTotal, SalesTax2Total, SalesTax3Total, GSTTotal, PSTTotal, HSTTotal, GSTRate, PSTRate, HSTRate, LastPurchaseCost, FIFOCost, FIFOExtendedAmount As Double
    Dim ReturnDate As Date
    Dim VerifyGL As Integer = 0
    Dim ExtendedCOS As Double = 0
    Dim Status, strCheckNegativeQuantity, strCheckNegativePrice As String
    Dim GetPurchProdLineID, GetSerialStatus As String
    Dim CustomerClas As String = ""
    Dim FOB As String = ""
    Dim BillingType As String = ""
    Dim FOBName As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isLoaded = False
    Dim lastReturn As String = ""

    'Form Routines

    Private Sub ReturnProductForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.EmployeeData' table. You can move, or remove it, as needed.
        Me.EmployeeDataTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.EmployeeData)

        isLoaded = True

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboReturnSalesperson.Text = EmployeeSalespersonCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboReturnSalesperson.Text = EmployeeSalespersonCode
            cboDivisionID.Enabled = False
        End If

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            ManuallyCloseReturnToolStripMenuItem.Enabled = True
        Else
            ManuallyCloseReturnToolStripMenuItem.Enabled = False
        End If

        LoadCustomerClass()
        cboFOB.Text = EmployeeCompanyCode

        If cboDivisionID.Text = "TWD" Then
            gpxConsignmentBox.Enabled = True
            cmdDeleteSN.Enabled = True
        ElseIf cboDivisionID.Text = "TFF" Then
            gpxConsignmentBox.Enabled = True
            cmdDeleteSN.Enabled = True
        ElseIf cboDivisionID.Text = "TWE" Then
            gpxConsignmentBox.Enabled = True
            cmdDeleteSN.Enabled = True
        Else
            gpxConsignmentBox.Enabled = False
            cmdDeleteSN.Enabled = True
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

    Private Sub ReturnProductForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not String.IsNullOrEmpty(cboReturnNumber.Text) Then
            unlockBatch()
        End If

        ClearVariables()
        ClearData()
    End Sub

    'Load Data into controls and datagrid (datasets)

    Public Sub ShowReturnLineData()
        cmd = New SqlCommand("SELECT * FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReturnProductLineTable")
        dgvReturnLines.DataSource = ds.Tables("ReturnProductLineTable")
        cboLineNumber.DataSource = ds.Tables("ReturnProductLineTable")
        cboLinePartNumber.DataSource = ds.Tables("ReturnProductLineTable")
        con.Close()
    End Sub

    Public Sub ClearReturnLineData()
        dgvReturnLines.DataSource = Nothing
    End Sub

    Public Sub LoadItemList()
        'Load Item List for correct division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboReturnPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboReturnPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerList()
        'Load Customer List for correct division
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboReturnCustomer.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboReturnCustomer.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        'Load Customer List for correct division
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

    Public Sub LoadSalesOrderNumber()
        'Load Customer List for correct division
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboReturnCustomer.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds4.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadReturnNumber()
        'Load Customer List for correct division
        cmd = New SqlCommand("SELECT ReturnNumber FROM ReturnProductHeaderTable WHERE DivisionID = @DivisionID AND ReturnStatus <> @ReturnStatus ORDER BY ReturnNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ReturnProductHeaderTable")
        cboReturnNumber.DataSource = ds5.Tables("ReturnProductHeaderTable")
        con.Close()
        cboReturnNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Load Item List for correct division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "ItemList")
        cboDescription.DataSource = ds6.Tables("ItemList")
        con.Close()
        cboDescription.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerClass()
        'Load CustomerClass for correct division
        cmd = New SqlCommand("SELECT CustomerClassID FROM CustomerClass WHERE DivisionID = @DivisionID AND Status = @Status", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "CustomerClass")
        cboCustomerClass.DataSource = ds7.Tables("CustomerClass")
        con.Close()
        cboCustomerClass.SelectedIndex = -1
    End Sub

    Public Sub ShowSerialLines()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialTempTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "AssemblySerialTempTable")
        dgvSerialLogTemp.DataSource = ds8.Tables("AssemblySerialTempTable")
        con.Close()
    End Sub

    Public Sub ClearSerialLines()
        dgvSerialLogTemp.DataSource = Nothing
    End Sub

    'Load Data Subroutines

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

        cboReturnCustomer.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboReturnCustomer.Text
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

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboReturnPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboReturnPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboDescription.Text = PartDescription1
    End Sub

    Public Sub LoadSalesTaxRate()
        Dim SalesTaxRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim SalesTaxRateCommand As New SqlCommand(SalesTaxRateStatement, con)
        SalesTaxRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboReturnCustomer.Text
        SalesTaxRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SalesTaxRate = CDbl(SalesTaxRateCommand.ExecuteScalar)
        Catch ex As Exception
            SalesTaxRate = 0
        End Try
        con.Close()

        txtSalesTaxLineRate.Text = SalesTaxRate

        If SalesTaxRate > 0 And cboDivisionID.Text <> "TFF" Then
            txtSalesTaxLineRate.Visible = True
            chkAddLineTax.Checked = True
        Else
            txtSalesTaxLineRate.Visible = False
            chkAddLineTax.Checked = False
        End If
    End Sub

    Public Sub LoadCanadianTaxRate()
        Dim GSTRateStatement As String = "SELECT SalesTaxRate, SalesTaxRate2, SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GSTRateCommand As New SqlCommand(GSTRateStatement, con)
        GSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboReturnCustomer.Text
        GSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GSTRateCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SalesTaxRate")) Then
                GSTRate = 0
            Else
                GSTRate = reader.Item("SalesTaxRate")
            End If
            If IsDBNull(reader.Item("SalesTaxRate2")) Then
                PSTRate = 0
            Else
                PSTRate = reader.Item("SalesTaxRate2")
            End If
            If IsDBNull(reader.Item("SalesTaxRate3")) Then
                HSTRate = 0
            Else
                HSTRate = reader.Item("SalesTaxRate3")
            End If
        Else
            GSTRate = 0
            PSTRate = 0
            HSTRate = 0
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub CalculateTotals()
        'Update extended Amount
        cmd = New SqlCommand("UPDATE ReturnProductLineTable SET ExtendedAmount = Quantity * UnitPrice  WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '********************************************************************************************************************************
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount), SUM(SalesTax), SUM(ExtendedCOS) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = ProductTotalCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                SalesTaxTotal = Val(txtReturnSalesTax.Text)
            Else
                SalesTaxTotal = reader.GetValue(1)
            End If
            If IsDBNull(reader.GetValue(2)) Then
                ExtendedCOS = 0
            Else
                ExtendedCOS = reader.GetValue(2)
            End If
        Else
            ProductTotal = 0
            SalesTaxTotal = Val(txtReturnSalesTax.Text)
            ExtendedCOS = 0
        End If
        reader.Close()
        con.Close()

        ProductTotal = Math.Round(ProductTotal, 2)
        SalesTaxTotal = Math.Round(SalesTaxTotal, 2)

        SalesTax2Total = Val(txtReturnSalesTax2.Text)
        SalesTax3Total = Val(txtReturnSalesTax3.Text)

        FreightTotal = Val(txtReturnFreight.Text)

        ReturnTotal = FreightTotal + SalesTaxTotal + ProductTotal + SalesTax2Total + SalesTax3Total

        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        lblReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
        txtReturnSalesTax.Text = SalesTaxTotal
    End Sub

    Public Sub CalculateTotalsCanadian()
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        FreightTotal = Val(txtReturnFreight.Text)

        GSTTotal = GSTRate * (ProductTotal + FreightTotal)
        PSTTotal = PSTRate * (ProductTotal + FreightTotal)
        HSTTotal = HSTRate * (ProductTotal + FreightTotal)

        GSTTotal = Math.Round(GSTTotal, 2)
        PSTTotal = Math.Round(PSTTotal, 2)
        HSTTotal = Math.Round(HSTTotal, 2)

        SalesTaxTotal = GSTTotal
        SalesTax2Total = PSTTotal
        SalesTax3Total = HSTTotal

        ProductTotal = Math.Round(ProductTotal, 2)

        txtReturnSalesTax.Text = SalesTaxTotal
        txtReturnSalesTax2.Text = SalesTax2Total
        txtReturnSalesTax3.Text = SalesTax3Total

        ReturnTotal = FreightTotal + SalesTaxTotal + SalesTax2Total + SalesTax3Total + ProductTotal

        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        lblReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
    End Sub

    Public Sub CalculateCanadianTaxes()
        LoadCanadianTaxRate()

        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber1 AND DivisionID = @DivisionID1"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@ReturnNumber1", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID1", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        GSTTotal = ProductTotal * GSTRate
        PSTTotal = ProductTotal * PSTRate
        HSTTotal = ProductTotal * HSTRate

        GSTTotal = Math.Round(GSTTotal, 2)
        PSTTotal = Math.Round(PSTTotal, 2)
        HSTTotal = Math.Round(HSTTotal, 2)

        txtReturnSalesTax.Text = GSTTotal
        txtReturnSalesTax2.Text = PSTTotal
        txtReturnSalesTax3.Text = HSTTotal
    End Sub

    Public Sub ReLoadTotals()
        Dim GetTotalsStatement As String = "SELECT ProductTotal, FreightTotal, ReturnTotal, SalesTaxTotal, SalesTax2Total, SalesTax3Total FROM ReturnProductHeaderTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim GetTotalsCommand As New SqlCommand(GetTotalsStatement, con)
        GetTotalsCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        GetTotalsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetTotalsCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ProductTotal")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("FreightTotal")) Then
                FreightTotal = 0
            Else
                FreightTotal = reader.Item("FreightTotal")
            End If
            If IsDBNull(reader.Item("ReturnTotal")) Then
                ReturnTotal = 0
            Else
                ReturnTotal = reader.Item("ReturnTotal")
            End If
            If IsDBNull(reader.Item("SalesTaxTotal")) Then
                SalesTaxTotal = 0
            Else
                SalesTaxTotal = reader.Item("SalesTaxTotal")
            End If
            If IsDBNull(reader.Item("SalesTax2Total")) Then
                SalesTax2Total = 0
            Else
                SalesTax2Total = reader.Item("SalesTax2Total")
            End If
            If IsDBNull(reader.Item("SalesTax3Total")) Then
                SalesTax3Total = 0
            Else
                SalesTax3Total = reader.Item("SalesTax3Total")
            End If

        Else
            ProductTotal = 0
            FreightTotal = 0
            ReturnTotal = 0
            SalesTaxTotal = 0
            SalesTax2Total = 0
            SalesTax3Total = 0
        End If
        reader.Close()
        con.Close()

        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtReturnSalesTax.Text = SalesTaxTotal
        txtReturnSalesTax2.Text = SalesTax2Total
        txtReturnSalesTax3.Text = SalesTax3Total
        txtReturnFreight.Text = FreightTotal
        lblReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
    End Sub

    Public Sub LoadItemData()
        Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
        ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboReturnPartNumber.Text
        ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = ItemClassCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ItemClass")) Then
                ItemClass = cboItemClass.Text
            Else
                ItemClass = reader.Item("ItemClass")
            End If
        Else
            ItemClass = cboItemClass.Text
        End If
        reader.Close()
        con.Close()

        cboItemClass.Text = ItemClass
    End Sub

    Public Sub LoadItemClassInfo()
        Dim ItemClassNameStatement As String = "SELECT * FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim ItemClassNameCommand As New SqlCommand(ItemClassNameStatement, con)
        ItemClassNameCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = ItemClassNameCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ItemClassName")) Then
                ItemClassName = ""
            Else
                ItemClassName = reader.Item("ItemClassName")
            End If
            If IsDBNull(reader.Item("GLSalesAccount")) Then
                GLSalesAccount = ""
            Else
                GLSalesAccount = reader.Item("GLSalesAccount")
            End If
            If IsDBNull(reader.Item("GLReturnsAccount")) Then
                GLReturnsAccount = ""
            Else
                GLReturnsAccount = reader.Item("GLReturnsAccount")
            End If
            If IsDBNull(reader.Item("GLInventoryAccount")) Then
                GLInventoryAccount = ""
            Else
                GLInventoryAccount = reader.Item("GLInventoryAccount")
            End If
            If IsDBNull(reader.Item("GLCOGSAccount")) Then
                GLCOGSAccount = ""
            Else
                GLCOGSAccount = reader.Item("GLCOGSAccount")
            End If
            If IsDBNull(reader.Item("GLSalesOffsetAccount")) Then
                GLSalesOffsetAccount = ""
            Else
                GLSalesOffsetAccount = reader.Item("GLSalesOffsetAccount")
            End If
        Else
            ItemClassName = ""
            GLSalesAccount = ""
            GLReturnsAccount = ""
            GLInventoryAccount = ""
            GLCOGSAccount = ""
            GLSalesOffsetAccount = ""
        End If
        reader.Close()
        con.Close()

        txtGLCOGSAccount.Text = GLCOGSAccount
        txtGLInventoryAccount.Text = GLInventoryAccount
        txtGLReturnsAccount.Text = GLReturnsAccount
        txtGLSalesAccount.Text = GLSalesAccount
        txtSalesOffset.Text = GLSalesOffsetAccount
        txtItemClassDescription.Text = ItemClassName
    End Sub

    Public Sub LoadReturnHeaderData()
        Dim GetReturnDataStatement As String = "SELECT * FROM ReturnProductHeaderTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim GetReturnDataCommand As New SqlCommand(GetReturnDataStatement, con)
        GetReturnDataCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        GetReturnDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetReturnDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ReturnDate")) Then
                ReturnDate = dtpReturnDate.Value
            Else
                ReturnDate = reader.Item("ReturnDate")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                CustomerID = ""
            Else
                CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("SalesOrderNumber")) Then
                SalesOrderNumber = 0
            Else
                SalesOrderNumber = reader.Item("SalesOrderNumber")
            End If
            If IsDBNull(reader.Item("Salesperson")) Then
                Salesperson = EmployeeSalespersonCode
            Else
                Salesperson = reader.Item("Salesperson")
            End If
            If IsDBNull(reader.Item("ProductTotal")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("FreightTotal")) Then
                FreightTotal = 0
            Else
                FreightTotal = reader.Item("FreightTotal")
            End If
            If IsDBNull(reader.Item("SalesTaxTotal")) Then
                SalesTaxTotal = 0
            Else
                SalesTaxTotal = reader.Item("SalesTaxTotal")
            End If
            If IsDBNull(reader.Item("ReturnTotal")) Then
                ReturnTotal = 0
            Else
                ReturnTotal = reader.Item("ReturnTotal")
            End If
            If IsDBNull(reader.Item("Reason")) Then
                Reason = ""
            Else
                Reason = reader.Item("Reason")
            End If
            If IsDBNull(reader.Item("ReturnStatus")) Then
                ReturnStatus = ""
            Else
                ReturnStatus = reader.Item("ReturnStatus")
            End If
            If IsDBNull(reader.Item("SalesTax2Total")) Then
                SalesTax2Total = 0
            Else
                SalesTax2Total = reader.Item("SalesTax2Total")
            End If
            If IsDBNull(reader.Item("SalesTax3Total")) Then
                SalesTax3Total = 0
            Else
                SalesTax3Total = reader.Item("SalesTax3Total")
            End If
            If IsDBNull(reader.Item("CustomerClass")) Then
                CustomerClass = "STANDARD"
            Else
                CustomerClass = reader.Item("CustomerClass")
            End If
            If IsDBNull(reader.Item("FOB")) Then
                FOB = cboDivisionID.Text
            Else
                FOB = reader.Item("FOB")
            End If
            If IsDBNull(reader.Item("CustomerPO")) Then
                CustomerPO = ""
            Else
                CustomerPO = reader.Item("CustomerPO")
            End If
        Else
            ReturnDate = dtpReturnDate.Value
            CustomerID = ""
            SalesOrderNumber = Val(cboSalesOrderNumber.Text)
            Salesperson = EmployeeSalespersonCode
            ProductTotal = 0
            FreightTotal = 0
            SalesTaxTotal = 0
            ReturnTotal = 0
            Reason = ""
            ReturnStatus = ""
            SalesTax2Total = 0
            SalesTax3Total = 0
            FOB = cboDivisionID.Text
            CustomerClass = "STANDARD"
            CustomerPO = ""
        End If
        reader.Close()
        con.Close()

        If ReturnStatus = "CLOSED" Or ReturnStatus = "PENDING" Then
            cmdDelete.Enabled = False
            cmdEnter.Enabled = False
            cmdPostReturn.Enabled = False
            cmdSave.Enabled = False
            cmdSelectLinesFromSO.Enabled = False
            SaveReturnToolStripMenuItem.Enabled = False
            DeleteReturnToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnter.Enabled = True
            cmdPostReturn.Enabled = True
            cmdSave.Enabled = True
            cmdSelectLinesFromSO.Enabled = True
            SaveReturnToolStripMenuItem.Enabled = True
            DeleteReturnToolStripMenuItem.Enabled = True
        End If

        dtpReturnDate.Text = ReturnDate
        cboReturnCustomer.Text = CustomerID
        cboSalesOrderNumber.Text = SalesOrderNumber
        cboReturnSalesperson.Text = Salesperson
        txtReturnFreight.Text = FreightTotal
        txtReturnSalesTax.Text = SalesTaxTotal
        txtReturnReason.Text = Reason
        txtReturnStatus.Text = ReturnStatus
        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        lblReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
        txtReturnSalesTax2.Text = SalesTax2Total
        txtReturnSalesTax3.Text = SalesTax3Total
        cboCustomerClass.Text = CustomerClass
        txtCustomerPO.Text = CustomerPO
        cboFOB.Text = FOB
    End Sub

    Public Sub LoadStatus()
        Dim ReturnStatusStatement As String = "SELECT ReturnStatus FROM ReturnProductHeaderTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim ReturnStatusCommand As New SqlCommand(ReturnStatusStatement, con)
        ReturnStatusCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        ReturnStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ReturnStatus = CStr(ReturnStatusCommand.ExecuteScalar)
        Catch ex As Exception
            ReturnStatus = ""
        End Try
        con.Close()

        txtReturnStatus.Text = ReturnStatus

        If ReturnStatus = "CLOSED" Or ReturnStatus = "PENDING" Then
            cmdDelete.Enabled = False
            cmdEnter.Enabled = False
            cmdPostReturn.Enabled = False
            cmdSave.Enabled = False
            cmdSelectLinesFromSO.Enabled = False
            SaveReturnToolStripMenuItem.Enabled = False
            DeleteReturnToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnter.Enabled = True
            cmdPostReturn.Enabled = True
            cmdSave.Enabled = True
            cmdSelectLinesFromSO.Enabled = True
            SaveReturnToolStripMenuItem.Enabled = True
            DeleteReturnToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Sub LoadFOBName()
        Dim FOBNameStatement As String = "SELECT FOBName FROM FOBTable WHERE FOBID = @FOBID AND DivisionID = @DivisionID"
        Dim FOBNameCommand As New SqlCommand(FOBNameStatement, con)
        FOBNameCommand.Parameters.Add("@FOBID", SqlDbType.VarChar).Value = cboFOB.Text
        FOBNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            FOBName = CStr(FOBNameCommand.ExecuteScalar)
        Catch ex As Exception
            FOBName = "Standard"
        End Try
        con.Close()

        txtFOBName.Text = FOBName
    End Sub

    Public Sub LoadCanadianDefaults()
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LabelGST.Text = "GST"
            LabelPST.Text = "PST"
            LabelHST.Text = "HST"
            LabelPST.Visible = True
            LabelHST.Visible = True
            txtReturnSalesTax2.Visible = True
            txtReturnSalesTax3.Visible = True
            chkAddLineTax.Visible = False
            txtSalesTaxLineRate.Visible = False
        Else
            LabelGST.Text = "Return Sales Tax"
            LabelPST.Visible = False
            LabelHST.Visible = False
            txtReturnSalesTax2.Visible = False
            txtReturnSalesTax3.Visible = False
            chkAddLineTax.Visible = True
        End If
    End Sub

    'Update / Insert Routines

    Private Sub UpdateTotals()
        'Update Totals in Header Table
        cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET ProductTotal = @ProductTotal, OtherTotal = @OtherTotal, FreightTotal = @FreightTotal, SalesTaxTotal = @SalesTaxTotal, SalesTax2Total = @SalesTax2Total, SalesTax3Total = @Salestax3Total, ReturnTotal = @ReturnTotal WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@FreightTotal", SqlDbType.VarChar).Value = FreightTotal
            .Add("@SalesTaxTotal", SqlDbType.VarChar).Value = SalesTaxTotal
            .Add("@ReturnTotal", SqlDbType.VarChar).Value = ReturnTotal
            .Add("@OtherTotal", SqlDbType.VarChar).Value = 0
            .Add("@SalesTax2Total", SqlDbType.VarChar).Value = SalesTax2Total
            .Add("@SalesTax3Total", SqlDbType.VarChar).Value = SalesTax3Total
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub InsertReturnHeaderTable()
        'Write Data to Return Order Header Database Table (One Time)
        cmd = New SqlCommand("Insert Into ReturnProductHeaderTable(ReturnNumber, ReturnDate, CustomerID, DivisionID, SalesOrderNumber, Salesperson, ProductTotal, FreightTotal, SalesTaxTotal, OtherTotal, ReturnTotal, Reason, ReturnStatus, SalesTax2Total, SalesTax3Total, TotalCOS, Locked, CustomerClass, FOB, CustomerPO)Values(@ReturnNumber, @ReturnDate, @CustomerID, @DivisionID, @SalesOrderNumber, @Salesperson, @ProductTotal, @FreightTotal, @SalesTaxTotal, @OtherTotal, @ReturnTotal, @Reason, @ReturnStatus, @SalesTax2Total, @SalesTax3Total, @TotalCOS, @Locked, @CustomerClass, @FOB, @CustomerPO)", con)

        With cmd.Parameters
            .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@ReturnDate", SqlDbType.VarChar).Value = ReturnDate
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboReturnCustomer.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)
            .Add("@Salesperson", SqlDbType.VarChar).Value = cboReturnSalesperson.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@FreightTotal", SqlDbType.VarChar).Value = Val(txtReturnFreight.Text)
            .Add("@SalesTaxTotal", SqlDbType.VarChar).Value = Val(txtReturnSalesTax.Text)
            .Add("@OtherTotal", SqlDbType.VarChar).Value = 0
            .Add("@ReturnTotal", SqlDbType.VarChar).Value = ReturnTotal
            .Add("@Reason", SqlDbType.VarChar).Value = txtReturnReason.Text
            .Add("@ReturnStatus", SqlDbType.VarChar).Value = Status
            .Add("@SalesTax2Total", SqlDbType.VarChar).Value = Val(txtReturnSalesTax2.Text)
            .Add("@SalesTax3Total", SqlDbType.VarChar).Value = Val(txtReturnSalesTax3.Text)
            .Add("@TotalCOS", SqlDbType.VarChar).Value = ExtendedCOS
            .Add("@Locked", SqlDbType.VarChar).Value = ""
            .Add("@CustomerClass", SqlDbType.VarChar).Value = cboCustomerClass.Text
            .Add("@FOB", SqlDbType.VarChar).Value = cboFOB.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateReturnHeaderTable()
        'Write Data to Return Order Header Database Table (One Time)
        cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET ReturnDate = @ReturnDate, CustomerID = @CustomerID, SalesOrderNumber = @SalesOrderNumber, Salesperson = @Salesperson, ProductTotal = @ProductTotal, FreightTotal = @FreightTotal, SalesTaxTotal = @SalesTaxTotal, OtherTotal = @OtherTotal, ReturnTotal = @ReturnTotal, Reason = @Reason, ReturnStatus = @ReturnStatus, SalesTax2Total = @SalesTax2Total, SalesTax3Total = @SalesTax3Total, TotalCOS = @TotalCOS, Locked = @Locked, CustomerClass = @CustomerClass, FOB = @FOB, CustomerPO = @CustomerPO WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@ReturnDate", SqlDbType.VarChar).Value = ReturnDate
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboReturnCustomer.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)
            .Add("@Salesperson", SqlDbType.VarChar).Value = cboReturnSalesperson.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@FreightTotal", SqlDbType.VarChar).Value = Val(txtReturnFreight.Text)
            .Add("@SalesTaxTotal", SqlDbType.VarChar).Value = Val(txtReturnSalesTax.Text)
            .Add("@OtherTotal", SqlDbType.VarChar).Value = 0
            .Add("@ReturnTotal", SqlDbType.VarChar).Value = ReturnTotal
            .Add("@Reason", SqlDbType.VarChar).Value = txtReturnReason.Text
            .Add("@ReturnStatus", SqlDbType.VarChar).Value = ReturnStatus
            .Add("@SalesTax2Total", SqlDbType.VarChar).Value = Val(txtReturnSalesTax2.Text)
            .Add("@SalesTax3Total", SqlDbType.VarChar).Value = Val(txtReturnSalesTax3.Text)
            .Add("@TotalCOS", SqlDbType.VarChar).Value = ExtendedCOS
            .Add("@Locked", SqlDbType.VarChar).Value = ""
            .Add("@CustomerClass", SqlDbType.VarChar).Value = cboCustomerClass.Text
            .Add("@FOB", SqlDbType.VarChar).Value = cboFOB.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Clear functions

    Public Sub ClearVariables()
        CustomerPO = ""
        FOBName = ""
        CustomerClass = ""
        GLSalesAccount = ""
        GLReturnsAccount = ""
        GLInventoryAccount = ""
        GLCOGSAccount = ""
        GLSalesOffsetAccount = ""
        ItemClass = ""
        ItemClassName = ""
        CustomerID = ""
        CustomerName = ""
        Salesperson = EmployeeSalespersonCode
        Reason = ""
        PartNumber = ""
        Description = ""
        NextConsignmentReturnNumber = 0
        ConsignmentReturnNumber = 0
        SalesOrderNumber = 0
        ReturnNumber = 0
        ReturnLineNumber = 0
        ProductTotal = 0
        FreightTotal = 0
        SalesTaxTotal = 0
        ReturnTotal = 0
        LastInventoryTransactionNumber = 0
        NextInventoryTransactionNumber = 0
        NextCostingTransactionNumber = 0
        LastCostingTransactionNumber = 0
        LastGLNumber = 0
        NextGLNumber = 0
        LastBatchNumber = 0
        GLBatchNumber = 0
        LastLineNumber = 0
        NextLineNumber = 0
        Counter = 0
        NextTransactionNumber = 0
        LastTransactionNumber = 0
        Quantity = 0
        UnitPrice = 0
        ExtendedAmount = 0
        LineQuantity = 0
        LinePrice = 0
        LineTotal = 0
        SalesTaxRate = 0
        Status = ""
        ReturnStatus = ""
        FIFOCost = 0
        FIFOExtendedAmount = 0
        LongDescription = ""
        SalesTax2Total = 0
        SalesTax3Total = 0
        GSTTotal = 0
        PSTTotal = 0
        HSTTotal = 0
        GSTRate = 0
        PSTRate = 0
        HSTRate = 0
        LineSalesTax = 0
        GlobalCustomerID = ""
        GlobalCustomerReturnNumber = 0
        SalesOrderNumber = 0
        GetVendor = ""
        GetVendorClass = ""
        MaxTransactionNumber = 0
        LastTransactionCost = 0
        ShipmentUnitCost = 0
        TotalCOS = 0
        ExtendedCOS = 0
        StdUnitCost = 0
        strCheckNegativeQuantity = ""
        strCheckNegativePrice = ""
        GetItemClass = ""
        lastReturn = ""
        CustomerClass = ""
        FOB = ""

        cmdDelete.Enabled = True
        cmdEnter.Enabled = True
        cmdPostReturn.Enabled = True
        cmdSave.Enabled = True
        cmdSelectLinesFromSO.Enabled = True
        SaveReturnToolStripMenuItem.Enabled = True
        DeleteReturnToolStripMenuItem.Enabled = True
    End Sub

    Public Sub ClearData()
        'Clear All Text Boxes
        cboReturnNumber.Text = ""

        cboDescription.Refresh()
        cboReturnNumber.Refresh()
        cboReturnCustomer.Enabled = True
        cboReturnCustomer.Refresh()
        cboReturnPartNumber.Refresh()
        cboSalesOrderNumber.Refresh()
        cboSalesOrderNumber.Enabled = True
        cboCustomerName.Refresh()
        cboItemClass.Refresh()
        cboLineNumber.Refresh()
        cboLinePartNumber.Refresh()

        txtGLCOGSAccount.Refresh()
        txtGLInventoryAccount.Refresh()
        txtGLReturnsAccount.Refresh()
        txtGLSalesAccount.Refresh()
        txtItemClassDescription.Refresh()
        txtLineTotal.Refresh()
        txtReturnFreight.Refresh()
        txtReturnPrice.Refresh()
        txtReturnQuantity.Refresh()
        txtReturnReason.Refresh()
        txtReturnSalesTax.Refresh()
        txtReturnSalesTax2.Refresh()
        txtReturnSalesTax3.Refresh()
        txtReturnStatus.Refresh()
        txtSalesOffset.Refresh()
        txtSalesTaxLineRate.Refresh()
        txtCustomerPO.Refresh()

        cboReturnSalesperson.Text = EmployeeSalespersonCode
        cboDescription.SelectedIndex = -1
        cboReturnNumber.SelectedIndex = -1
        cboReturnCustomer.SelectedIndex = -1
        cboReturnPartNumber.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboLineNumber.SelectedIndex = -1
        cboLinePartNumber.SelectedIndex = -1
        cboCustomerClass.SelectedIndex = -1
        cboFOB.SelectedIndex = -1

        txtGLCOGSAccount.Clear()
        txtGLInventoryAccount.Clear()
        txtGLReturnsAccount.Clear()
        txtGLSalesAccount.Clear()
        txtItemClassDescription.Clear()
        txtLineTotal.Clear()
        txtReturnFreight.Clear()
        txtReturnPrice.Clear()
        txtReturnQuantity.Clear()
        txtReturnReason.Clear()
        txtReturnSalesTax.Clear()
        txtReturnSalesTax2.Clear()
        txtReturnSalesTax3.Clear()
        txtReturnStatus.Clear()
        txtSalesOffset.Clear()
        txtSalesTaxLineRate.Clear()
        txtFOBName.Clear()
        txtCustomerPO.Clear()

        lblReturnTotal.Text = ""
        lblProductTotal.Text = ""
        Counter = 1

        cboFOB.Text = cboDivisionID.Text

        dtpReturnDate.Text = ""

        chkAddLineTax.Checked = False

        cmdDelete.Enabled = True
        cmdEnter.Enabled = True
        cmdPostReturn.Enabled = True
        cmdSave.Enabled = True
        cmdSelectLinesFromSO.Enabled = True
        SaveReturnToolStripMenuItem.Enabled = True
        DeleteReturnToolStripMenuItem.Enabled = True

        cmdGenerateNewReturnNumber.Focus()
    End Sub

    'Command Buttons

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        unlockBatch()
        'Clear text boxes
        cboReturnPartNumber.SelectedIndex = -1
        cboDescription.SelectedIndex = -1
        txtReturnPrice.Clear()
        txtReturnQuantity.Clear()
        txtLineTotal.Clear()
        cboReturnPartNumber.Focus()
    End Sub

    Private Sub cmdItemForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemForm.Click
        Using NewItemMaintenance As New ItemMaintenance
            Dim Result = NewItemMaintenance.ShowDialog()
        End Using
        LoadItemList()
    End Sub

    Private Sub cmdCustomerForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomerForm.Click
        GlobalCustomerID = cboReturnCustomer.Text
        Dim tempCustName As String = cboReturnCustomer.Text
        Using NewCustomerData As New CustomerData
            Dim Result = NewCustomerData.ShowDialog()
        End Using
        isLoaded = False
        LoadCustomerList()
        isLoaded = True
        cboCustomerName.Text = tempCustName
    End Sub

    Private Sub cmdViewOpenReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewOpenReturns.Click
        Using NewViewCustomerReturnListing As New ViewCustomerReturnListing
            Dim result = NewViewCustomerReturnListing.ShowDialog()
        End Using
    End Sub

    Private Sub cmdGenerateNewReturnNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewReturnNumber.Click
        If Not String.IsNullOrEmpty(cboReturnNumber.Text) Then
            unlockBatch()
        End If

        'Create New Transaction Number
        ClearVariables()
        ClearData()

        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a valid division.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim MAXStatement As String = "SELECT MAX(ReturnNumber) FROM ReturnProductHeaderTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 7500000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        cboReturnNumber.Text = NextTransactionNumber

        ReturnDate = dtpReturnDate.Value

        'Save Return Number so it can not be selected again
        Try
            ReturnStatus = "OPEN"
            txtReturnStatus.Text = ReturnStatus
            InsertReturnHeaderTable()
        Catch ex As Exception
            'Log error on update failure
            Dim TempReturnNumber As Integer = 0
            Dim strReturnNumber As String
            TempReturnNumber = Val(cboReturnNumber.Text)
            strReturnNumber = CStr(TempReturnNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Return Product Form --- Generate new Return Number"
            ErrorReferenceNumber = "Return # " + strReturnNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        isLoaded = False
        LoadReturnNumber()
        cboReturnNumber.Text = NextTransactionNumber
        txtReturnStatus.Text = "OPEN"
        isLoaded = True
        LockBatch()
        lastReturn = cboReturnNumber.Text
    End Sub

    Private Sub cmdRemoveSalesTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveSalesTax.Click
        If isSomeoneEditing() Then
            LoadReturnHeaderData()
            ShowReturnLineData()
            Exit Sub
        End If

        LockBatch()

        Try
            Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber6 AND DivisionID = @DivisionID6"
            Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
            ProductTotalCommand.Parameters.Add("@ReturnNumber6", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            ProductTotalCommand.Parameters.Add("@DivisionID6", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            con.Close()

            FreightTotal = Val(txtReturnFreight.Text)
            ReturnTotal = ProductTotal + FreightTotal

            SalesTaxTotal = 0
            SalesTax2Total = 0
            SalesTax3Total = 0

            'Update Totals
            Try
                UpdateTotals()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Return Product Form --- Update Totals on remove tax"
                ErrorReferenceNumber = "Return # " + strReturnNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            '************************************************************************************************
            Try
                'Update sales tax in line table
                cmd = New SqlCommand("UPDATE ReturnProductLineTable SET SalesTax = @SalesTax WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Return Product Form --- Remove Tax"
                ErrorReferenceNumber = "Return # " + strReturnNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Refresh fields and datagrid
            ShowReturnLineData()

            SalesTaxTotal = 0
            SalesTax2Total = 0
            SalesTax3Total = 0

            lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
            lblReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
            txtReturnSalesTax.Text = 0
            txtReturnSalesTax2.Text = 0
            txtReturnSalesTax3.Text = 0
        Catch ex As Exception
            MsgBox("Cannot remove sales tax at this time. Check return and then try again.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub cmdSelectLinesFromSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectLinesFromSO.Click
        If canSelectLinesFromPO() Then
            LockBatch()
            'Convert date if necessary and load totals
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                ReturnDate = dtpReturnDate.Value
                'Load totals
                CalculateTotalsCanadian()
            Else
                ReturnDate = dtpReturnDate.Value
                'Load totals
                CalculateTotals()
            End If

            Try
                ReturnStatus = "OPEN"
                txtReturnStatus.Text = ReturnStatus
                InsertReturnHeaderTable()
            Catch ex As Exception
                ReturnStatus = "OPEN"
                txtReturnStatus.Text = ReturnStatus
                UpdateReturnHeaderTable()
            End Try

            Dim NewSelectItemsForCustomerReturn As New SelectItemsForCustomerReturn
            NewSelectItemsForCustomerReturn.setSalesOrderNumber(cboSalesOrderNumber.Text)
            NewSelectItemsForCustomerReturn.setReturnNumber(cboReturnNumber.Text)
            NewSelectItemsForCustomerReturn.setDivisionID(cboDivisionID.Text)
            NewSelectItemsForCustomerReturn.setCustomerID(cboReturnCustomer.Text)
            NewSelectItemsForCustomerReturn.ShowSalesOrderLines()

            Me.Hide()

            If NewSelectItemsForCustomerReturn.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If cboSalesOrderNumber.Enabled Then
                    cboSalesOrderNumber.Enabled = False
                    cboReturnCustomer.Enabled = False
                    cboCustomerName.Enabled = False
                    Try
                        cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET SalesOrderNumber = @SONumber WHERE ReturnNumber = @ReturnNumber", con)
                        cmd.Parameters.Add("@SONumber", SqlDbType.VarChar).Value = cboSalesOrderNumber.Text
                        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = cboReturnNumber.Text
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempReturnNumber As Integer = 0
                        Dim strReturnNumber As String
                        TempReturnNumber = Val(cboReturnNumber.Text)
                        strReturnNumber = CStr(TempReturnNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Return Product Form --- Select SO Lines"
                        ErrorReferenceNumber = "Return # " + strReturnNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
                ShowReturnLineData()
                ReLoadTotals()
            End If
            Me.Show()
            Me.Focus()
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        unlockBatch()
        ClearVariables()
        ClearData()
        ShowReturnLineData()
        ClearSerialLines()
    End Sub

    Private Sub cmdPostReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostReturn.Click
        'Count Lines on the Return and warn if Zero Lines
        Dim CountReturnLines As Integer = 0

        Dim CountReturnLinesStatement As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim CountReturnLinesCommand As New SqlCommand(CountReturnLinesStatement, con)
        CountReturnLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CountReturnLinesCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountReturnLines = CInt(CountReturnLinesCommand.ExecuteScalar)
        Catch ex As Exception
            CountReturnLines = 0
        End Try
        con.Close()

        If CountReturnLines = 0 Then
            MsgBox("You must have a least one line on a Return.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '**********************************************************************************************************
        If cboCustomerClass.Text = "DE-ACTIVATED" Then
            MsgBox("You cannot process a return for a De-Activated Customer.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Skip
        End If
        '**********************************************************************************************************
        If cboFOB.Text = "" Then
            cboFOB.Text = cboDivisionID.Text
        End If
        '**********************************************************************************************************
        If cboCustomerClass.Text = "" Then
            Dim GetCustomerClass As String = ""

            Dim GetCustomerClassStatement As String = "SELECT CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim GetCustomerClassCommand As New SqlCommand(GetCustomerClassStatement, con)
            GetCustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetCustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboReturnCustomer.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCustomerClass = CStr(GetCustomerClassCommand.ExecuteScalar)
            Catch ex As Exception
                GetCustomerClass = "STANDARD"
            End Try
            con.Close()

            cboCustomerClass.Text = GetCustomerClass
        End If
        '**********************************************************************************************************
        If cboCustomerClass.Text = "DE-ACTIVATED" Then
            MsgBox("You cannot process a return for a De-Activated Customer.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Skip
        End If
        '**********************************************************************************************************
        If ReturnStatus = "CLOSED" Or ReturnStatus = "PENDING" Then
            MsgBox("This Return has already been POSTED.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboReturnNumber.Text = "" Or cboReturnCustomer.Text = "" Then
            MsgBox("You must have a valid Return # / Customer selected before posting.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If isSomeoneEditing() Then
            LoadReturnHeaderData()
            ShowReturnLineData()
            Exit Sub
        End If
        '******************************************************************************************************
        'Validate if Return Number, Line has been written to GL
        Dim VerifyGLStatement As String = "SELECT COUNT(GLTransactionKey) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
        Dim VerifyGLCommand As New SqlCommand(VerifyGLStatement, con)
        VerifyGLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        VerifyGLCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyGL = CInt(VerifyGLCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGL = 0
        End Try
        con.Close()

        If VerifyGL <> 0 Then
            MsgBox("This return has already been posted in the ledger.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '******************************************************************************************************
        If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
            'Skip Date Validation
        Else
            ''Validate Date
            'Dim CurrentDate, TodaysDate As Date
            'Dim MonthOfYear, YearOfYear, TodaysMonthOfYear, TodaysYearOfYear As Integer

            'TodaysDate = Today()
            'CurrentDate = dtpReturnDate.Value

            'MonthOfYear = CurrentDate.Month
            'YearOfYear = CurrentDate.Year
            'TodaysMonthOfYear = TodaysDate.Month
            'TodaysYearOfYear = TodaysDate.Year

            'If TodaysYearOfYear - YearOfYear > 1 Then
            '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear < 5 And (TodaysMonthOfYear >= 1 And TodaysMonthOfYear < 5) Then
            '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear > 5 And (TodaysMonthOfYear >= 5 And TodaysMonthOfYear <= 12) Then
            '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear = 0 And MonthOfYear < 5 And TodaysMonthOfYear >= 5 Then
            '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear < 0 Then
            '    MsgBox("You cannot post a Return to a future period.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear = 0 And TodaysMonthOfYear < MonthOfYear Then
            '    MsgBox("You cannot post a Return to a future period.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'Else
            '    'Date is okay --- Continue
            'End If
        End If
        '***********************************************************************************************************
        'Check to see if negative
        If ReturnTotal < 0 Then
            MsgBox("This return is negative. Enter quantities as a positive number.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Proceed
        End If
        '***********************************************************************************************************
        'Prompt before Posting
        Dim button As DialogResult = MessageBox.Show("Do you wish to post this Customer Return?", "POST CUSTOMER RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Do nothing and continue
        ElseIf button = DialogResult.No Then
            cboReturnNumber.Focus()
            Exit Sub
        End If
        '***********************************************************************************************************
        'If it passes validation, then lock the batch
        LockBatch()
        '***********************************************************************************************************
        'Convert date if necessary and load totals
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            ReturnDate = dtpReturnDate.Value
            'Load totals
            LoadCanadianTaxRate()
            CalculateTotalsCanadian()
        Else
            ReturnDate = dtpReturnDate.Value
            'Load totals
            CalculateTotals()
        End If
        '***********************************************************************************************************
        'See if number of serial lines match serial entries
        If cboDivisionID.Text = "TWE" Then
            'Check for serial Numbers
            Dim CheckPartNumber As String = ""
            Dim CheckSerialNumbers As String = ""
            Dim CheckLineNumber As Integer = 0
            Dim CheckLineQuantity As Double = 0
            Dim CountSerialLines As Integer = 0

            For Each row2 As DataGridViewRow In dgvReturnLines.Rows
                Try
                    CheckPartNumber = row2.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    CheckPartNumber = ""
                End Try
                Try
                    CheckLineNumber = row2.Cells("ReturnLineNumberColumn").Value
                Catch ex As Exception
                    CheckLineNumber = 1
                End Try
                Try
                    CheckLineQuantity = row2.Cells("QuantityColumn").Value
                Catch ex As Exception
                    CheckLineQuantity = 0
                End Try
                '*************************************************************************
                Dim SerializedAssemblyStatus As String = ""

                'Check for Assembly
                Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CheckPartNumber
                GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPurchProdLineID = CStr(GetPPLCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPurchProdLineID = ""
                End Try
                con.Close()

                'Check to see if part is a serialized assembly
                If GetPurchProdLineID = "ASSEMBLY" Then
                    Dim CheckSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
                    CheckSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                    CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetSerialStatus = CStr(CheckSerializedCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetSerialStatus = "NO"
                    End Try
                    con.Close()
                    '*******************************************************************************
                    If GetSerialStatus = "YES" Then
                        Dim CountSerialLinesStatement As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialTempTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND TransactionNumber = @TransactionNumber AND BatchNumber = @BatchNumber"
                        Dim CountSerialLinesCommand As New SqlCommand(CountSerialLinesStatement, con)
                        CountSerialLinesCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                        CountSerialLinesCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                        CountSerialLinesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = CheckLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountSerialLines = CInt(CountSerialLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountSerialLines = 0
                        End Try
                        con.Close()

                        If CountSerialLines = CheckLineQuantity Then
                            'Do nothing
                        Else
                            MsgBox("The number of serial numbers entered must match the line quantity.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                    Else
                        'Do nothing
                    End If
                Else
                    'Do nothing
                End If

                CheckPartNumber = ""
                CheckSerialNumbers = ""
                CheckLineNumber = 0
                CheckLineQuantity = 0
                CountSerialLines = 0
                GetSerialStatus = ""
                GetPurchProdLineID = ""
            Next
        End If
        '***********************************************************************************************************
        Dim PostDivision As String = ""

        If cboDivisionID.Text = "TFP" Then
            PostDivision = "TWD"
        Else
            PostDivision = cboDivisionID.Text
        End If
        '***********************************************************************************************************
        'Command to Save all data and write to Database
        ReturnStatus = "PENDING"
        txtReturnStatus.Text = ReturnStatus

        'Save to Header Table
        Try
            UpdateReturnHeaderTable()
        Catch ex As Exception
            'Log error on update failure
            Dim TempReturnNumber As Integer = 0
            Dim strReturnNumber As String
            TempReturnNumber = Val(cboReturnNumber.Text)
            strReturnNumber = CStr(TempReturnNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Return Product Form --- Update Header Failure on Posting"
            ErrorReferenceNumber = "Return # " + strReturnNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
            Exit Sub
        End Try
        '***********************************************************************************************************
        'Create Batch Number for all current Postings
        Dim MAXBatchStatement As String = "SELECT MAX(GLBatchNumber) FROM GLTransactionMasterList"
        Dim MAXBatchCommand As New SqlCommand(MAXBatchStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXBatchCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 541000000
        End Try
        con.Close()

        GLBatchNumber = LastBatchNumber + 1
        '***********************************************************************************************************
        'Define Billing Types

        'REGULAR - Standard Return for an American or Canadian Customer

        'CONSIGNMENT TO - Product is returned to the consignment warehouse from a customer
        '               - COS/Inventory will post in G/L on the invoice, not the return
        '               - Revenues will post on the invoice

        'CONSIGNMENT FROM - Product is returned to the division from the consignemnt warehouse
        '                 - This will generate a Bill-Only Invoice (No COS/Inventory Posting)
        '                 - COS/Inventory will post when the retun is posted
        '***********************************************************************************************************
        ' Three different billing scenarios, depending on which division and customer class / FOB

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TWE" Then
            If cboCustomerClass.Text = "STANDARD" Then
                BillingType = "REGULAR"
            ElseIf cboCustomerClass.Text <> "STANDARD" And cboFOB.Text = cboDivisionID.Text Then
                BillingType = "CONSIGNMENT FROM"
            ElseIf cboCustomerClass.Text <> "STANDARD" And cboFOB.Text <> cboDivisionID.Text Then
                BillingType = "CONSIGNMENT TO"
            Else
                BillingType = "REGULAR"
            End If
        ElseIf cboDivisionID.Text = "TFF" Then
            If cboCustomerClass.Text = "AMERICAN" Then
                BillingType = "REGULAR"
            ElseIf cboCustomerClass.Text = "CANADIAN" Then
                BillingType = "REGULAR"
            ElseIf cboCustomerClass.Text = "SRL" And cboFOB.Text = "SRL" Then
                BillingType = "CONSIGNMENT TO"
            ElseIf cboCustomerClass.Text = "SRL" And cboFOB.Text = "TFF" Then
                BillingType = "CONSIGNMENT FROM"
            Else
                BillingType = "REGULAR"
            End If
        Else
            'Skip - Regular Billing
            BillingType = "REGULAR"
        End If
        '***********************************************************************************************************
        'Choose Billing Type based on what's in the selected fields

        Select Case BillingType
            Case "REGULAR"
                'Define Variables for line data
                Dim ReturnLineNumber, SOLineNumber As Integer
                Dim ReturnQuantity As Double = 0
                Dim ExtendedAmount As Double = 0
                Dim ReturnPrice As Double = 0
                Dim PartNumber, PartDescription As String
                Dim SerialCost As Double = 0

                '**********************************
                'Write to General Ledger
                '**********************************

                'Extract Line data from the datagrid
                For Each row As DataGridViewRow In dgvReturnLines.Rows
                    Dim cell As DataGridViewTextBoxCell = row.Cells("ReturnNumberColumn")

                    If cell.Value = Val(cboReturnNumber.Text) Then
                        Try
                            ReturnLineNumber = row.Cells("ReturnLineNumberColumn").Value
                        Catch ex As Exception
                            ReturnLineNumber = 1
                        End Try
                        Try
                            ExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                        Catch ex As Exception
                            ExtendedAmount = 0
                        End Try
                        Try
                            PartNumber = row.Cells("PartNumberColumn").Value
                        Catch ex As Exception
                            PartNumber = ""
                        End Try
                        Try
                            PartDescription = row.Cells("DescriptionColumn").Value
                        Catch ex As Exception
                            PartDescription = ""
                        End Try
                        Try
                            ReturnQuantity = row.Cells("QuantityColumn").Value
                        Catch ex As Exception
                            ReturnQuantity = 0
                        End Try
                        Try
                            ReturnPrice = row.Cells("UnitPriceColumn").Value
                        Catch ex As Exception
                            ReturnPrice = 0
                        End Try
                        Try
                            SOLineNumber = row.Cells("SOLineNumberColumn").Value
                        Catch ex As Exception
                            SOLineNumber = 0
                        End Try
                        '**********************************************************************************************************
                        'If serialized assembly and TWE, get serial cost
                        Dim SerializedAssemblyStatus As String = ""

                        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Then
                            'Check for Assembly
                            Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                            GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetPurchProdLineID = CStr(GetPPLCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetPurchProdLineID = ""
                            End Try
                            con.Close()

                            'Check to see if part is a serialized assembly
                            If GetPurchProdLineID = "ASSEMBLY" Then
                                Dim CheckSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                                Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
                                CheckSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                                CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetSerialStatus = CStr(CheckSerializedCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetSerialStatus = "NO"
                                End Try
                                con.Close()
                                '*******************************************************************************
                                If GetSerialStatus = "YES" Then
                                    Dim GetSerialCostStatement As String = "SELECT SUM(TotalCost) FROM AssemblySerialTempTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND TransactionNumber = @TransactionNumber AND BatchNumber = @BatchNumber"
                                    Dim GetSerialCostCommand As New SqlCommand(GetSerialCostStatement, con)
                                    GetSerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                                    GetSerialCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    GetSerialCostCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        SerialCost = CDbl(GetSerialCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SerialCost = 0
                                    End Try
                                    con.Close()

                                    FIFOExtendedAmount = SerialCost
                                    FIFOCost = SerialCost / ReturnQuantity
                                    FIFOCost = Math.Round(FIFOCost, 4)
                                    SerializedAssemblyStatus = "YES"
                                Else
                                    SerializedAssemblyStatus = "NO"
                                End If
                            Else
                                SerializedAssemblyStatus = "NO"
                            End If
                        Else
                            SerializedAssemblyStatus = "NO"
                        End If
                        '**********************************************************************************************************
                        'If division = TWE and serial status = yes, use Serial Cost as FIFO - else calculate FIFO Cost
                        If SerializedAssemblyStatus = "YES" Then
                            'FIFO Cost is calculated from Serial Cost
                        Else 'Calculate FIFO, Shipping Cost, or Alternate Cost
                            'Get unit cost from shipment table - if applicable
                            Dim ShipmentCOSStatement As String = "SELECT UnitCost FROM ShipmentLineQuery WHERE DivisionID = @DivisionID AND SalesOrderKey = @SalesOrderKey AND SOLineNumber = @SOLineNumber"
                            Dim ShipmentCOSCommand As New SqlCommand(ShipmentCOSStatement, con)
                            ShipmentCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            ShipmentCOSCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)
                            ShipmentCOSCommand.Parameters.Add("@SOLineNumber", SqlDbType.VarChar).Value = SOLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ShipmentUnitCost = CDbl(ShipmentCOSCommand.ExecuteScalar)
                            Catch ex As Exception
                                ShipmentUnitCost = 0
                            End Try
                            con.Close()

                            FIFOCost = ShipmentUnitCost
                            FIFOExtendedAmount = ShipmentUnitCost * ReturnQuantity

                            If FIFOExtendedAmount = 0 Then
                                '******************************************************************************************************************************************
                                'Get FIFO Cost of Part

                                'Define Variables used in FIFO
                                Dim GetMaxTransactionNumber As Integer = 0
                                Dim GetUpperLimit As Double = 0
                                Dim UpperLimit As Double = 0
                                Dim QuantityRemaining As Double = 0
                                Dim NextUpperLimit As Double = 0
                                Dim NextLowerLimit As Double = 0
                                '******************************************************************************************************************************************
                                'Determine FIFO Cost on Part Number to remove from Inventory
                                Dim TotalQuantityShipped As Double = 0
                                Dim TotalQuantityBuilt As Double = 0
                                '******************************************************************************************************************************************
                                'Determine Total Quantity Shipped
                                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship"
                                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                                Catch ex As Exception
                                    TotalQuantityShipped = 0
                                End Try
                                con.Close()
                                '********************************************************************************************************************************************
                                'Determine Total Quantity built (if an assembly)
                                Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
                                Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
                                TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = PartNumber
                                TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    TotalQuantityBuilt = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
                                Catch ex As Exception
                                    TotalQuantityBuilt = 0
                                End Try
                                con.Close()

                                TotalQuantityBuilt = TotalQuantityBuilt * -1

                                TotalQuantityShipped = TotalQuantityShipped + TotalQuantityBuilt
                                '******************************************************************************************************************************************
                                'Check to see if Total Quantity Shipped falls within the Cost Tiers
                                Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
                                Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                                GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

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

                                If TotalQuantityShipped - ReturnQuantity = 0 Then
                                    TotalQuantityShipped = 1
                                Else
                                    TotalQuantityShipped = TotalQuantityShipped - ReturnQuantity
                                End If

                                If TotalQuantityShipped > GetUpperLimit Then
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
                                    GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
                                    Catch ex As Exception
                                        GetMaxTransactionNumber = 0
                                    End Try
                                    con.Close()

                                    If GetMaxTransactionNumber = 0 Then
                                        Dim ItemCost2Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                                        ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        'ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        UpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        'UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            FIFOCost = CDbl(ItemCost2Command.ExecuteScalar)
                                        Catch ex As Exception
                                            FIFOCost = 0
                                        End Try
                                        Try
                                            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            UpperLimit = 0
                                        End Try
                                        con.Close()
                                    Else
                                        Dim ItemCost2Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                                        ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        ItemCost2Command.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        UpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            FIFOCost = CDbl(ItemCost2Command.ExecuteScalar)
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

                                    If TotalQuantityShipped + ReturnQuantity > UpperLimit Then
                                        'Quantity crosses a cost tier
                                        QuantityRemaining = (TotalQuantityShipped + ReturnQuantity) - UpperLimit

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
                                            GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

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
                                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

                                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

                                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

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
                                                Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                                NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                                NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                                NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
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
                                        FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                    End If
                                End If

                                'Run routine if no FIFO Cost is retrieved - Use LPC, TC, STD Cost
                                '*****************************************************************************************************************************************
                                If FIFOCost = 0 Then
                                    LastPurchaseCost = 0

                                    Dim MAXDateStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
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

                                    Dim LastPriceStatement As String = "SELECT UnitCost FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
                                    Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                                    LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    LastPriceCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MaxDate

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        LastPurchaseCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = LastPurchaseCost
                                    FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                End If
                                '*****************************************************************************************************************************************
                                If FIFOCost = 0 Then
                                    TransactionCost = 0

                                    Dim TransactionCostStatement As String = "SELECT MAX(ItemCost) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        TransactionCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = TransactionCost
                                    FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                End If
                                '*****************************************************************************************************************************************
                                'If FIFO Cost = 0, pull Standard Cost from Item List
                                If FIFOCost = 0 Then
                                    Dim StandardCost As Double = 0

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
                                    FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                End If
                                '*****************************************************************************************************************************************
                            Else   'Use Shipment COS
                                'Do nothing - Shipment COS is used
                            End If
                        End If
                        '***********************************************************************************************************
                        'Clear variables after determining serial/FIFO Cost
                        GetSerialStatus = ""
                        GetPurchProdLineID = ""
                        SerializedAssemblyStatus = ""

                        FIFOExtendedAmount = Math.Round(FIFOExtendedAmount, 2)
                        '******************************************************************************************************************************************
                        'Get Item Class 
                        Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                        Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetItemClass = "TW CA"
                        End Try
                        con.Close()
                        '*****************************************************************************************************************************************
                        Dim GetItemClassType As String = ""

                        Dim GetItemClassTypeStatement As String = "SELECT InventoryItem FROM ItemClass WHERE ItemClassID = @ItemClassID"
                        Dim GetItemClassTypeCommand As New SqlCommand(GetItemClassTypeStatement, con)
                        GetItemClassTypeCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetItemClassType = CStr(GetItemClassTypeCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetItemClassType = "YES"
                        End Try
                        con.Close()
                        '******************************************************************************************************************************************
                        Dim GetDebitAccount, GetCreditAccount As String

                        'Get GL Accounts
                        Dim GetDebitAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                        Dim GetDebitAccountCommand As New SqlCommand(GetDebitAccountStatement, con)
                        GetDebitAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                        Dim GetCreditAccountStatement As String = "SELECT GLSalesOffsetAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                        Dim GetCreditAccountCommand As New SqlCommand(GetCreditAccountStatement, con)
                        GetCreditAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetDebitAccount = CStr(GetDebitAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetDebitAccount = "12100"
                        End Try
                        Try
                            GetCreditAccount = CStr(GetCreditAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetCreditAccount = "49999"
                        End Try
                        con.Close()
                        '******************************************************************************************************************************************
                        If GetItemClassType = "NO" Then
                            FIFOExtendedAmount = 0
                        Else
                            'FIFO is correct
                        End If
                        '******************************************************************************************************************************************
                        'Update Extended COS in the Return Line Table
                        Try
                            cmd = New SqlCommand("UPDATE ReturnProductLineTable SET ExtendedCOS = @ExtendedCOS WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber
                                .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Return Product Form --- Update Line COS on Posting"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '***********************************************************************************************************
                        'If Customer is canadian, get GL Accounts
                        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                            'Get Vendor for specific part number to determine GL
                            Dim GetVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim GetVendorCommand As New SqlCommand(GetVendorStatement, con)
                            GetVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetVendor = CStr(GetVendorCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetVendor = ""
                            End Try
                            con.Close()

                            If GetVendor = "AMERICAN" Then
                                GetVendorClass = "AMERICAN"
                            ElseIf GetVendor = "CANADIAN" Then
                                GetVendorClass = "CANADIAN"
                            Else
                                'Get Vendor Class
                                Dim GetVendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                                Dim GetVendorClassCommand As New SqlCommand(GetVendorClassStatement, con)
                                GetVendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GetVendor
                                GetVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetVendorClass = CStr(GetVendorClassCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetVendorClass = "CANADIAN"
                                End Try
                                con.Close()
                            End If

                            If GetVendorClass = "AMERICAN" Then
                                'Do nothing - GL Accounts are ok
                            ElseIf GetVendorClass = "CANADIAN" And cboCustomerClass.Text = "CANADIAN" Then
                                GetDebitAccount = "C$" & GetDebitAccount
                                GetCreditAccount = "C$" & GetCreditAccount
                            ElseIf GetVendorClass = "CANADIAN" And cboCustomerClass.Text = "SRL" Then
                                'Do nothing - GL Accounts are ok
                            ElseIf GetVendorClass = "AMERICAN" And cboCustomerClass.Text = "SRL" Then
                                'Do nothing - GL Accounts are ok
                            Else
                                GetDebitAccount = "C$" & GetDebitAccount
                                GetCreditAccount = "C$" & GetCreditAccount
                            End If
                        Else
                            'Do nothing - gl accounts are correct
                        End If
                        '***********************************************************************************************************
                        Try
                            'Command to write Line Amount to GL
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GetDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Customer Return"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order Number " & cboSalesOrderNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = GLBatchNumber
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ReturnLineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Return Product Form --- GL Debit Failure on Posting"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*******************************************************************************************************************
                        Try
                            'Command to write Line Amount to GL
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GetCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Customer Return"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order Number " & cboSalesOrderNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = GLBatchNumber
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ReturnLineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Return Product Form --- GL Credit Failure on Posting"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '***********************************************************************************************************
                        If GetItemClassType = "NO" Then
                            'Skip Inventory Transaction
                        Else
                            'Write Values to Inventory Transaction Table

                            'Find Next Transaction Number
                            Dim InventoryTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
                            Dim InventoryTransactionNumberCommand As New SqlCommand(InventoryTransactionNumberStatement, con)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastInventoryTransactionNumber = CInt(InventoryTransactionNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                LastInventoryTransactionNumber = 867500000
                            End Try
                            con.Close()

                            NextInventoryTransactionNumber = LastInventoryTransactionNumber + 1

                            Try
                                'Write Data to the Inventory Transaction Table
                                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                                With cmd.Parameters
                                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                                    .Add("@TransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Customer Return"
                                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                    .Add("@Quantity", SqlDbType.VarChar).Value = ReturnQuantity
                                    .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@ItemPrice", SqlDbType.VarChar).Value = ReturnPrice
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                                    .Add("@GLAccount", SqlDbType.VarChar).Value = GetDebitAccount
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Return Product Form --- Inv. Transaction Failure on Posting"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '*******************************************************************************************************
                            'Create a Cost Tier
                            'Extract the Upper and Lower Limit of the Inventory Costing Table
                            Dim NewUpperLimit, LowerLimit, UpperLimit As Double
                            Dim MaxTransactionNumber As Integer = 0
                            Dim MAXDate As String = ""

                            Dim MAXDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MAXDate = CStr(MAXDateCommand.ExecuteScalar)
                            Catch ex As Exception
                                MAXDate = ""
                            End Try
                            con.Close()

                            Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
                            Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                            MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            MaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MAXDate

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                MaxTransactionNumber = 0
                            End Try
                            con.Close()

                            Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID AND PartNumber = @PartNumber"
                            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                            UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
                            UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                            Catch ex As Exception
                                UpperLimit = 0
                            End Try
                            con.Close()

                            'Calculate the NEW Lower/Upper Limit for the next post
                            LowerLimit = UpperLimit + 1
                            NewUpperLimit = LowerLimit + ReturnQuantity - 1

                            'Get next Transaction Number
                            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
                            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                LastCostingTransactionNumber = 63600000
                            End Try
                            con.Close()

                            NextCostingTransactionNumber = LastCostingTransactionNumber + 1

                            Try
                                'Write Values to Inventory Costing Table
                                cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                                With cmd.Parameters
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@CostingDate", SqlDbType.VarChar).Value = ReturnDate
                                    .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@CostQuantity", SqlDbType.VarChar).Value = ReturnQuantity
                                    .Add("@Status", SqlDbType.VarChar).Value = "Customer Return"
                                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = ReturnLineNumber
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Return Product Form --- Create Cost Tier on Posting"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End If
                    End If
                Next

                '**********************************
                'End of Ledger Entry
                '**********************************

            Case "CONSIGNMENT TO"
                'Define Variables for line data
                Dim ReturnLineNumber, SOLineNumber As Integer
                Dim ReturnQuantity As Double = 0
                Dim ExtendedAmount As Double = 0
                Dim ReturnPrice As Double = 0
                Dim PartNumber, PartDescription As String
                Dim SerialCost As Double = 0

                '**********************************
                'Write to General Ledger
                '**********************************

                'Extract Line data from the datagrid
                For Each row As DataGridViewRow In dgvReturnLines.Rows
                    Dim cell As DataGridViewTextBoxCell = row.Cells("ReturnNumberColumn")

                    If cell.Value = Val(cboReturnNumber.Text) Then
                        Try
                            ReturnLineNumber = row.Cells("ReturnLineNumberColumn").Value
                        Catch ex As Exception
                            ReturnLineNumber = 1
                        End Try
                        Try
                            ExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                        Catch ex As Exception
                            ExtendedAmount = 0
                        End Try
                        Try
                            PartNumber = row.Cells("PartNumberColumn").Value
                        Catch ex As Exception
                            PartNumber = ""
                        End Try
                        Try
                            PartDescription = row.Cells("DescriptionColumn").Value
                        Catch ex As Exception
                            PartDescription = ""
                        End Try
                        Try
                            ReturnQuantity = row.Cells("QuantityColumn").Value
                        Catch ex As Exception
                            ReturnQuantity = 0
                        End Try
                        Try
                            ReturnPrice = row.Cells("UnitPriceColumn").Value
                        Catch ex As Exception
                            ReturnPrice = 0
                        End Try
                        Try
                            SOLineNumber = row.Cells("SOLineNumberColumn").Value
                        Catch ex As Exception
                            SOLineNumber = 0
                        End Try
                        '**********************************************************************************************************
                        'If serialized assembly and TWE, get serial cost
                        Dim SerializedAssemblyStatus As String = ""

                        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Then
                            'Check for Assembly
                            Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                            GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetPurchProdLineID = CStr(GetPPLCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetPurchProdLineID = ""
                            End Try
                            con.Close()

                            'Check to see if part is a serialized assembly
                            If GetPurchProdLineID = "ASSEMBLY" Then
                                Dim CheckSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                                Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
                                CheckSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                                CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetSerialStatus = CStr(CheckSerializedCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetSerialStatus = "NO"
                                End Try
                                con.Close()
                                '*******************************************************************************
                                If GetSerialStatus = "YES" Then
                                    Dim GetSerialCostStatement As String = "SELECT SUM(TotalCost) FROM AssemblySerialTempTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND TransactionNumber = @TransactionNumber AND BatchNumber = @BatchNumber"
                                    Dim GetSerialCostCommand As New SqlCommand(GetSerialCostStatement, con)
                                    GetSerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                                    GetSerialCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    GetSerialCostCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        SerialCost = CDbl(GetSerialCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SerialCost = 0
                                    End Try
                                    con.Close()

                                    FIFOExtendedAmount = SerialCost
                                    FIFOCost = SerialCost / ReturnQuantity
                                    FIFOCost = Math.Round(FIFOCost, 4)
                                    SerializedAssemblyStatus = "YES"
                                Else
                                    SerializedAssemblyStatus = "NO"
                                End If
                            Else
                                SerializedAssemblyStatus = "NO"
                            End If
                        Else
                            SerializedAssemblyStatus = "NO"
                        End If
                        '**********************************************************************************************************
                        'If division = TWE and serial status = yes, use Serial Cost as FIFO - else calculate FIFO Cost
                        If SerializedAssemblyStatus = "YES" Then
                            'FIFI Cost is calculated from Serial Cost
                        Else 'Calculate FIFO, Shipping Cost, or Alternate Cost
                            'Get unit cost from shipment table - if applicable
                            Dim ShipmentCOSStatement As String = "SELECT UnitCost FROM ShipmentLineQuery WHERE DivisionID = @DivisionID AND SalesOrderKey = @SalesOrderKey AND SOLineNumber = @SOLineNumber"
                            Dim ShipmentCOSCommand As New SqlCommand(ShipmentCOSStatement, con)
                            ShipmentCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            ShipmentCOSCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)
                            ShipmentCOSCommand.Parameters.Add("@SOLineNumber", SqlDbType.VarChar).Value = SOLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ShipmentUnitCost = CDbl(ShipmentCOSCommand.ExecuteScalar)
                            Catch ex As Exception
                                ShipmentUnitCost = 0
                            End Try
                            con.Close()

                            FIFOCost = ShipmentUnitCost
                            FIFOExtendedAmount = ShipmentUnitCost * ReturnQuantity

                            If FIFOExtendedAmount = 0 Then
                                '******************************************************************************************************************************************
                                'Get FIFO Cost of Part

                                'Define Variables used in FIFO
                                Dim GetMaxTransactionNumber As Integer = 0
                                Dim GetUpperLimit As Double = 0
                                Dim UpperLimit As Double = 0
                                Dim QuantityRemaining As Double = 0
                                Dim NextUpperLimit As Double = 0
                                Dim NextLowerLimit As Double = 0
                                '******************************************************************************************************************************************
                                'Determine FIFO Cost on Part Number to remove from Inventory
                                Dim TotalQuantityShipped As Double = 0
                                Dim TotalQuantityBuilt As Double = 0
                                '******************************************************************************************************************************************
                                'Determine Total Quantity Shipped
                                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship"
                                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                                Catch ex As Exception
                                    TotalQuantityShipped = 0
                                End Try
                                con.Close()
                                '********************************************************************************************************************************************
                                'Determine Total Quantity built (if an assembly)
                                Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
                                Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
                                TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = PartNumber
                                TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    TotalQuantityBuilt = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
                                Catch ex As Exception
                                    TotalQuantityBuilt = 0
                                End Try
                                con.Close()

                                TotalQuantityBuilt = TotalQuantityBuilt * -1

                                TotalQuantityShipped = TotalQuantityShipped + TotalQuantityBuilt
                                '******************************************************************************************************************************************
                                'Check to see if Total Quantity Shipped falls within the Cost Tiers
                                Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
                                Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                                GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

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

                                If TotalQuantityShipped - ReturnQuantity = 0 Then
                                    TotalQuantityShipped = 1
                                Else
                                    TotalQuantityShipped = TotalQuantityShipped - ReturnQuantity
                                End If

                                If TotalQuantityShipped > GetUpperLimit Then
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
                                    GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
                                    Catch ex As Exception
                                        GetMaxTransactionNumber = 0
                                    End Try
                                    con.Close()

                                    If GetMaxTransactionNumber = 0 Then
                                        Dim ItemCost2Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                                        ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        'ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        UpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        'UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            FIFOCost = CDbl(ItemCost2Command.ExecuteScalar)
                                        Catch ex As Exception
                                            FIFOCost = 0
                                        End Try
                                        Try
                                            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            UpperLimit = 0
                                        End Try
                                        con.Close()
                                    Else
                                        Dim ItemCost2Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                                        ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        ItemCost2Command.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        UpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            FIFOCost = CDbl(ItemCost2Command.ExecuteScalar)
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

                                    If TotalQuantityShipped + ReturnQuantity > UpperLimit Then
                                        'Quantity crosses a cost tier
                                        QuantityRemaining = (TotalQuantityShipped + ReturnQuantity) - UpperLimit

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
                                            GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

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
                                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

                                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

                                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

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
                                                Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                                NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                                NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                                NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
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
                                        FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                    End If
                                End If

                                'Run routine if no FIFO Cost is retrieved - Use LPC, TC, STD Cost
                                '*****************************************************************************************************************************************
                                If FIFOCost = 0 Then
                                    LastPurchaseCost = 0

                                    Dim MAXDateStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
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

                                    Dim LastPriceStatement As String = "SELECT UnitCost FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
                                    Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                                    LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    LastPriceCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MaxDate

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        LastPurchaseCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = LastPurchaseCost
                                    FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                End If
                                '*****************************************************************************************************************************************
                                If FIFOCost = 0 Then
                                    TransactionCost = 0

                                    Dim TransactionCostStatement As String = "SELECT MAX(ItemCost) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        TransactionCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = TransactionCost
                                    FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                End If
                                '*****************************************************************************************************************************************
                                'If FIFO Cost = 0, pull Standard Cost from Item List
                                If FIFOCost = 0 Then
                                    Dim StandardCost As Double = 0

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
                                    FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                End If
                                '*****************************************************************************************************************************************
                            Else   'Use Shipment COS
                                'Do nothing - Shipment COS is used
                            End If
                        End If
                        '***********************************************************************************************************
                        'Clear variables after determining serial/FIFO Cost
                        GetSerialStatus = ""
                        GetPurchProdLineID = ""
                        SerializedAssemblyStatus = ""

                        FIFOExtendedAmount = Math.Round(FIFOExtendedAmount, 2)
                        '******************************************************************************************************************************************
                        'Get Item Class 
                        Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                        Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetItemClass = "TW CA"
                        End Try
                        con.Close()
                        '*****************************************************************************************************************************************
                        Dim GetItemClassType As String = ""

                        Dim GetItemClassTypeStatement As String = "SELECT InventoryItem FROM ItemClass WHERE ItemClassID = @ItemClassID"
                        Dim GetItemClassTypeCommand As New SqlCommand(GetItemClassTypeStatement, con)
                        GetItemClassTypeCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetItemClassType = CStr(GetItemClassTypeCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetItemClassType = "YES"
                        End Try
                        con.Close()
                        '******************************************************************************************************************************************
                        Dim GetDebitAccount, GetCreditAccount As String
                        '******************************************************************************************************************************************
                        'Get GL Accounts
                        CustomerClass = cboCustomerClass.Text

                        Select Case CustomerClass
                            Case "BCW"
                                GetDebitAccount = "12610"
                                GetCreditAccount = "52610"
                            Case "DCW"
                                GetDebitAccount = "12630"
                                GetCreditAccount = "52630"
                            Case "HCW"
                                GetDebitAccount = "12620"
                                GetCreditAccount = "52620"
                            Case "PCW"
                                GetDebitAccount = "12660"
                                GetCreditAccount = "52660"
                            Case "LCW"
                                GetDebitAccount = "12650"
                                GetCreditAccount = "52650"
                            Case "YCW"
                                GetDebitAccount = "12600"
                                GetCreditAccount = "52600"
                            Case "SCW"
                                GetDebitAccount = "12640"
                                GetCreditAccount = "52640"
                            Case "LSCW"
                                GetDebitAccount = "12690"
                                GetCreditAccount = "52690"
                            Case "RCW"
                                GetDebitAccount = "12680"
                                GetCreditAccount = "52680"
                            Case "SRL"
                                GetDebitAccount = "12670"
                                GetCreditAccount = "52670"
                            Case Else
                                GetDebitAccount = "12610"
                                GetCreditAccount = "52610"
                        End Select
                        '******************************************************************************************************************************************
                        If GetItemClassType = "NO" Or GetItemClass = "FERRULE" Then
                            FIFOExtendedAmount = 0
                        Else
                            'Skip - FIFO is correct
                        End If
                        '******************************************************************************************************************************************
                        'Update Extended COS in the Return Line Table
                        Try
                            cmd = New SqlCommand("UPDATE ReturnProductLineTable SET ExtendedCOS = @ExtendedCOS WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber
                                .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Return Product Form --- Update Line COS on Posting"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '***********************************************************************************************************
                        'If Customer is canadian, get GL Accounts
                        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                            'Get Vendor for specific part number to determine GL
                            Dim GetVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim GetVendorCommand As New SqlCommand(GetVendorStatement, con)
                            GetVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetVendor = CStr(GetVendorCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetVendor = ""
                            End Try
                            con.Close()

                            If GetVendor = "AMERICAN" Then
                                GetVendorClass = "AMERICAN"
                            ElseIf GetVendor = "CANADIAN" Then
                                GetVendorClass = "CANADIAN"
                            Else
                                'Get Vendor Class
                                Dim GetVendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                                Dim GetVendorClassCommand As New SqlCommand(GetVendorClassStatement, con)
                                GetVendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GetVendor
                                GetVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetVendorClass = CStr(GetVendorClassCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetVendorClass = "CANADIAN"
                                End Try
                                con.Close()
                            End If

                            If GetVendorClass = "AMERICAN" Then
                                'Do nothing - GL Accounts are ok
                            ElseIf GetVendorClass = "CANADIAN" And cboCustomerClass.Text = "CANADIAN" Then
                                GetDebitAccount = "C$" & GetDebitAccount
                                GetCreditAccount = "C$" & GetCreditAccount
                            ElseIf GetVendorClass = "CANADIAN" And cboCustomerClass.Text = "SRL" Then
                                'Do nothing - GL Accounts are ok
                            ElseIf GetVendorClass = "AMERICAN" And cboCustomerClass.Text = "SRL" Then
                                'Do nothing - GL Accounts are ok
                            Else
                                GetDebitAccount = "C$" & GetDebitAccount
                                GetCreditAccount = "C$" & GetCreditAccount
                            End If
                        Else
                            'Do nothing - gl accounts are correct
                        End If
                        '***********************************************************************************************************
                        Try
                            'Command to write Line Amount to GL
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GetDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Customer Return to Consignment"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order Number " & cboSalesOrderNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = GLBatchNumber
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ReturnLineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Return Product Form --- GL Debit Failure on Posting"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*******************************************************************************************************************
                        Try
                            'Command to write Line Amount to GL
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GetCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Customer Return to Consignment"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order Number " & cboSalesOrderNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = GLBatchNumber
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ReturnLineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Return Product Form --- GL Credit Failure on Posting"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '***********************************************************************************************************
                        If GetItemClassType = "NO" Then
                            'Skip Inventory Transaction Table
                        Else
                            'Write Values to Inventory Transaction Table

                            'Find Next Transaction Number
                            Dim InventoryTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
                            Dim InventoryTransactionNumberCommand As New SqlCommand(InventoryTransactionNumberStatement, con)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastInventoryTransactionNumber = CInt(InventoryTransactionNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                LastInventoryTransactionNumber = 867500000
                            End Try
                            con.Close()

                            NextInventoryTransactionNumber = LastInventoryTransactionNumber + 1

                            Try
                                'Write Data to the Inventory Transaction Table
                                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                                With cmd.Parameters
                                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                                    .Add("@TransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Customer Return to Consignment"
                                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                    .Add("@Quantity", SqlDbType.VarChar).Value = ReturnQuantity
                                    .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@ItemPrice", SqlDbType.VarChar).Value = ReturnPrice
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboFOB.Text
                                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                                    .Add("@GLAccount", SqlDbType.VarChar).Value = GetDebitAccount
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Return Product Form --- Inv. Transaction Failure on Posting"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '*******************************************************************************************************
                            Try
                                'Get MAX Consignment Return Number
                                Dim MaxReturnNumberStatement As String = "SELECT MAX(ConsignmentReturnNumber) FROM ConsignmentReturnTable"
                                Dim MaxReturnNumberCommand As New SqlCommand(MaxReturnNumberStatement, con)

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    LastConsignmentReturnNumber = CInt(MaxReturnNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    LastConsignmentReturnNumber = 867500000
                                End Try
                                con.Close()

                                NextConsignmentReturnNumber = LastConsignmentReturnNumber + 1

                                'Write To Return Table
                                cmd = New SqlCommand("INSERT INTO ConsignmentReturnTable (ConsignmentReturnNumber, PartNumber, PartDescription, QuantityReturned, UnitCost, UnitPrice, ExtendedCost, ExtendedAmount, DivisionID, ReturnDate, ReturnNumber, CustomerClass, LineComment) VALUES(@ConsignmentReturnNumber,  @PartNumber, @PartDescription, @QuantityReturned, @UnitCost, @UnitPrice, @ExtendedCost, @ExtendedAmount, @DivisionID, @ReturnDate, @ReturnNumber, @CustomerClass, @LineComment)", con)

                                With cmd.Parameters
                                    .Add("@ConsignmentReturnNumber", SqlDbType.VarChar).Value = NextConsignmentReturnNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                    .Add("@QuantityReturned", SqlDbType.VarChar).Value = ReturnQuantity
                                    .Add("@UnitCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@UnitPrice", SqlDbType.VarChar).Value = ReturnPrice
                                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@ReturnDate", SqlDbType.VarChar).Value = ReturnDate
                                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    .Add("@CustomerClass", SqlDbType.VarChar).Value = cboFOB.Text
                                    .Add("@LineComment", SqlDbType.VarChar).Value = "Return From Customer To Warehouse"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Return Product Form --- Consignment Entry on Posting"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '***********************************************************************************************************************************
                            'Create Cost tier adjustment
                            'Extract the Upper and Lower Limit of the Inventory Costing Table
                            Dim NewUpperLimit1, LowerLimit1, UpperLimit1 As Double
                            Dim MaxTransactionNumber1 As Integer = 0
                            Dim LastCostingTransactionNumber1 As Integer = 0
                            Dim NextCostingTransactionNumber1 As Integer = 0

                            Dim MaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                            Dim MaxTransactionNumber1Command As New SqlCommand(MaxTransactionNumber1Statement, con)
                            MaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            MaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboFOB.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxTransactionNumber1 = CInt(MaxTransactionNumber1Command.ExecuteScalar)
                            Catch ex As Exception
                                MaxTransactionNumber1 = 0
                            End Try
                            con.Close()

                            Dim UpperLimit1Statement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                            Dim UpperLimit1Command As New SqlCommand(UpperLimit1Statement, con)
                            UpperLimit1Command.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber1
                            UpperLimit1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboFOB.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                UpperLimit1 = CDbl(UpperLimit1Command.ExecuteScalar)
                            Catch ex As Exception
                                UpperLimit1 = 0
                            End Try
                            con.Close()

                            'Calculate the NEW Lower/Upper Limit for the next post
                            LowerLimit1 = UpperLimit1 + 1
                            NewUpperLimit1 = LowerLimit1 + ReturnQuantity - 1

                            'Get next Transaction Number
                            Dim CostingTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
                            Dim CostingTransactionNumber1Command As New SqlCommand(CostingTransactionNumber1Statement, con)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastCostingTransactionNumber1 = CInt(CostingTransactionNumber1Command.ExecuteScalar)
                            Catch ex As Exception
                                LastCostingTransactionNumber1 = 63600000
                            End Try
                            con.Close()

                            NextCostingTransactionNumber1 = LastCostingTransactionNumber1 + 1

                            'Write Values to Inventory Costing Table
                            cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                            With cmd.Parameters
                                .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboFOB.Text
                                .Add("@CostingDate", SqlDbType.VarChar).Value = ReturnDate
                                .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                                .Add("@CostQuantity", SqlDbType.VarChar).Value = ReturnQuantity
                                .Add("@Status", SqlDbType.VarChar).Value = "Customer Return - Consignment"
                                .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit1
                                .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit1
                                .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber1
                                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@ReferenceLine", SqlDbType.VarChar).Value = ReturnLineNumber
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    End If
                Next

                '**********************************
                'End of Ledger Entry
                '**********************************


            Case "CONSIGNMENT FROM"
                'Define Variables for line data
                Dim ReturnLineNumber, SOLineNumber As Integer
                Dim ReturnQuantity As Double = 0
                Dim ExtendedAmount As Double = 0
                Dim ReturnPrice As Double = 0
                Dim PartNumber, PartDescription As String
                Dim SerialCost As Double = 0

                '**********************************
                'Write to General Ledger
                '**********************************

                'Extract Line data from the datagrid
                For Each row As DataGridViewRow In dgvReturnLines.Rows
                    Dim cell As DataGridViewTextBoxCell = row.Cells("ReturnNumberColumn")

                    If cell.Value = Val(cboReturnNumber.Text) Then
                        Try
                            ReturnLineNumber = row.Cells("ReturnLineNumberColumn").Value
                        Catch ex As Exception
                            ReturnLineNumber = 1
                        End Try
                        Try
                            ExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                        Catch ex As Exception
                            ExtendedAmount = 0
                        End Try
                        Try
                            PartNumber = row.Cells("PartNumberColumn").Value
                        Catch ex As Exception
                            PartNumber = ""
                        End Try
                        Try
                            PartDescription = row.Cells("DescriptionColumn").Value
                        Catch ex As Exception
                            PartDescription = ""
                        End Try
                        Try
                            ReturnQuantity = row.Cells("QuantityColumn").Value
                        Catch ex As Exception
                            ReturnQuantity = 0
                        End Try
                        Try
                            ReturnPrice = row.Cells("UnitPriceColumn").Value
                        Catch ex As Exception
                            ReturnPrice = 0
                        End Try
                        Try
                            SOLineNumber = row.Cells("SOLineNumberColumn").Value
                        Catch ex As Exception
                            SOLineNumber = 0
                        End Try
                        '**********************************************************************************************************
                        'If serialized assembly and TWE, get serial cost
                        Dim SerializedAssemblyStatus As String = ""

                        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Then
                            'Check for Assembly
                            Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                            GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetPurchProdLineID = CStr(GetPPLCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetPurchProdLineID = ""
                            End Try
                            con.Close()

                            'Check to see if part is a serialized assembly
                            If GetPurchProdLineID = "ASSEMBLY" Then
                                Dim CheckSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                                Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
                                CheckSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                                CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetSerialStatus = CStr(CheckSerializedCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetSerialStatus = "NO"
                                End Try
                                con.Close()
                                '*******************************************************************************
                                If GetSerialStatus = "YES" Then
                                    Dim GetSerialCostStatement As String = "SELECT SUM(TotalCost) FROM AssemblySerialTempTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND TransactionNumber = @TransactionNumber AND BatchNumber = @BatchNumber"
                                    Dim GetSerialCostCommand As New SqlCommand(GetSerialCostStatement, con)
                                    GetSerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                                    GetSerialCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    GetSerialCostCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        SerialCost = CDbl(GetSerialCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SerialCost = 0
                                    End Try
                                    con.Close()

                                    FIFOExtendedAmount = SerialCost
                                    FIFOCost = SerialCost / ReturnQuantity
                                    FIFOCost = Math.Round(FIFOCost, 4)
                                    SerializedAssemblyStatus = "YES"
                                Else
                                    SerializedAssemblyStatus = "NO"
                                End If
                            Else
                                SerializedAssemblyStatus = "NO"
                            End If
                        Else
                            SerializedAssemblyStatus = "NO"
                        End If
                        '**********************************************************************************************************
                        'If division = TWE and serial status = yes, use Serial Cost as FIFO - else calculate FIFO Cost
                        If SerializedAssemblyStatus = "YES" Then
                            'FIFI Cost is calculated from Serial Cost
                        Else 'Calculate FIFO, Shipping Cost, or Alternate Cost
                            'Get unit cost from shipment table - if applicable
                            Dim ShipmentCOSStatement As String = "SELECT UnitCost FROM ShipmentLineQuery WHERE DivisionID = @DivisionID AND SalesOrderKey = @SalesOrderKey AND SOLineNumber = @SOLineNumber"
                            Dim ShipmentCOSCommand As New SqlCommand(ShipmentCOSStatement, con)
                            ShipmentCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            ShipmentCOSCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)
                            ShipmentCOSCommand.Parameters.Add("@SOLineNumber", SqlDbType.VarChar).Value = SOLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ShipmentUnitCost = CDbl(ShipmentCOSCommand.ExecuteScalar)
                            Catch ex As Exception
                                ShipmentUnitCost = 0
                            End Try
                            con.Close()

                            FIFOCost = ShipmentUnitCost
                            FIFOExtendedAmount = ShipmentUnitCost * ReturnQuantity

                            If FIFOExtendedAmount = 0 Then
                                '******************************************************************************************************************************************
                                'Get FIFO Cost of Part

                                'Define Variables used in FIFO
                                Dim GetMaxTransactionNumber As Integer = 0
                                Dim GetUpperLimit As Double = 0
                                Dim UpperLimit As Double = 0
                                Dim QuantityRemaining As Double = 0
                                Dim NextUpperLimit As Double = 0
                                Dim NextLowerLimit As Double = 0
                                '******************************************************************************************************************************************
                                'Determine FIFO Cost on Part Number to remove from Inventory
                                Dim TotalQuantityShipped As Double = 0
                                Dim TotalQuantityBuilt As Double = 0
                                '******************************************************************************************************************************************
                                'Determine Total Quantity Shipped
                                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship"
                                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                                Catch ex As Exception
                                    TotalQuantityShipped = 0
                                End Try
                                con.Close()
                                '********************************************************************************************************************************************
                                'Determine Total Quantity built (if an assembly)
                                Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
                                Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
                                TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = PartNumber
                                TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    TotalQuantityBuilt = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
                                Catch ex As Exception
                                    TotalQuantityBuilt = 0
                                End Try
                                con.Close()

                                TotalQuantityBuilt = TotalQuantityBuilt * -1

                                TotalQuantityShipped = TotalQuantityShipped + TotalQuantityBuilt
                                '******************************************************************************************************************************************
                                'Check to see if Total Quantity Shipped falls within the Cost Tiers
                                Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
                                Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                                GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

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

                                If TotalQuantityShipped - ReturnQuantity = 0 Then
                                    TotalQuantityShipped = 1
                                Else
                                    TotalQuantityShipped = TotalQuantityShipped - ReturnQuantity
                                End If

                                If TotalQuantityShipped > GetUpperLimit Then
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
                                    GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
                                    Catch ex As Exception
                                        GetMaxTransactionNumber = 0
                                    End Try
                                    con.Close()

                                    If GetMaxTransactionNumber = 0 Then
                                        Dim ItemCost2Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                                        ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        'ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        UpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        'UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            FIFOCost = CDbl(ItemCost2Command.ExecuteScalar)
                                        Catch ex As Exception
                                            FIFOCost = 0
                                        End Try
                                        Try
                                            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            UpperLimit = 0
                                        End Try
                                        con.Close()
                                    Else
                                        Dim ItemCost2Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                                        ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        ItemCost2Command.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        UpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                        UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            FIFOCost = CDbl(ItemCost2Command.ExecuteScalar)
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

                                    If TotalQuantityShipped + ReturnQuantity > UpperLimit Then
                                        'Quantity crosses a cost tier
                                        QuantityRemaining = (TotalQuantityShipped + ReturnQuantity) - UpperLimit

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
                                            GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

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
                                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

                                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

                                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text

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
                                                Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                                NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                                NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                                NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                                                NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                                Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                                Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                                NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                                NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                                NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
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
                                        FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                    End If
                                End If

                                'Run routine if no FIFO Cost is retrieved - Use LPC, TC, STD Cost
                                '*****************************************************************************************************************************************
                                If FIFOCost = 0 Then
                                    LastPurchaseCost = 0

                                    Dim MAXDateStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
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

                                    Dim LastPriceStatement As String = "SELECT UnitCost FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
                                    Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                                    LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    LastPriceCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MaxDate

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        LastPurchaseCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = LastPurchaseCost
                                    FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                End If
                                '*****************************************************************************************************************************************
                                If FIFOCost = 0 Then
                                    TransactionCost = 0

                                    Dim TransactionCostStatement As String = "SELECT MAX(ItemCost) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        TransactionCost = 0
                                    End Try
                                    con.Close()

                                    FIFOCost = TransactionCost
                                    FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                End If
                                '*****************************************************************************************************************************************
                                'If FIFO Cost = 0, pull Standard Cost from Item List
                                If FIFOCost = 0 Then
                                    Dim StandardCost As Double = 0

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
                                    FIFOExtendedAmount = FIFOCost * ReturnQuantity
                                End If
                                '*****************************************************************************************************************************************
                            Else   'Use Shipment COS
                                'Do nothing - Shipment COS is used
                            End If
                        End If
                        '***********************************************************************************************************
                        'Clear variables after determining serial/FIFO Cost
                        GetSerialStatus = ""
                        GetPurchProdLineID = ""
                        SerializedAssemblyStatus = ""

                        FIFOExtendedAmount = Math.Round(FIFOExtendedAmount, 2)
                        '******************************************************************************************************************************************
                        'Get Item Class 
                        Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                        Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetItemClass = "TW CA"
                        End Try
                        con.Close()
                        '*****************************************************************************************************************************************
                        Dim GetItemClassType As String = ""

                        Dim GetItemClassTypeStatement As String = "SELECT InventoryItem FROM ItemClass WHERE ItemClassID = @ItemClassID"
                        Dim GetItemClassTypeCommand As New SqlCommand(GetItemClassTypeStatement, con)
                        GetItemClassTypeCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetItemClassType = CStr(GetItemClassTypeCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetItemClassType = "YES"
                        End Try
                        con.Close()
                        '******************************************************************************************************************************************
                        Dim GetDebitAccount, GetCreditAccount As String
                        '******************************************************************************************************************************************
                        'Get GL Accounts
                        CustomerClass = cboCustomerClass.Text

                        Dim GetDebitAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                        Dim GetDebitAccountCommand As New SqlCommand(GetDebitAccountStatement, con)
                        GetDebitAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetDebitAccount = CStr(GetDebitAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetDebitAccount = "12100"
                        End Try
                        con.Close()

                        Select Case CustomerClass
                            Case "BCW"
                                GetCreditAccount = "12610"
                            Case "DCW"
                                GetCreditAccount = "12630"
                            Case "HCW"
                                GetCreditAccount = "12620"
                            Case "PCW"
                                GetCreditAccount = "12660"
                            Case "LCW"
                                GetCreditAccount = "12650"
                            Case "YCW"
                                GetCreditAccount = "12600"
                            Case "SCW"
                                GetCreditAccount = "12640"
                            Case "RCW"
                                GetCreditAccount = "12680"
                            Case "LSCW"
                                GetCreditAccount = "12690"
                            Case "SRL"
                                GetCreditAccount = "12670"
                            Case Else
                                GetCreditAccount = "12610"
                        End Select
                        '******************************************************************************************************************************************
                        If GetItemClassType = "NO" Or GetItemClass = "FERRULE" Then
                            FIFOExtendedAmount = 0
                        Else
                            'FIFO is correct
                        End If
                        '******************************************************************************************************************************************
                        'Update Extended COS in the Return Line Table
                        Try
                            cmd = New SqlCommand("UPDATE ReturnProductLineTable SET ExtendedCOS = @ExtendedCOS WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber
                                .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Return Product Form --- Update Line COS on Posting"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '***********************************************************************************************************
                        'If Customer is canadian, get GL Accounts
                        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                            'Get Vendor for specific part number to determine GL
                            Dim GetVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim GetVendorCommand As New SqlCommand(GetVendorStatement, con)
                            GetVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetVendor = CStr(GetVendorCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetVendor = ""
                            End Try
                            con.Close()

                            If GetVendor = "AMERICAN" Then
                                GetVendorClass = "AMERICAN"
                            ElseIf GetVendor = "CANADIAN" Then
                                GetVendorClass = "CANADIAN"
                            Else
                                'Get Vendor Class
                                Dim GetVendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                                Dim GetVendorClassCommand As New SqlCommand(GetVendorClassStatement, con)
                                GetVendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GetVendor
                                GetVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetVendorClass = CStr(GetVendorClassCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetVendorClass = "CANADIAN"
                                End Try
                                con.Close()
                            End If

                            If GetVendorClass = "AMERICAN" Then
                                'Do nothing - GL Accounts are ok
                            ElseIf GetVendorClass = "CANADIAN" And cboCustomerClass.Text = "CANADIAN" Then
                                GetDebitAccount = "C$" & GetDebitAccount
                                GetCreditAccount = "C$" & GetCreditAccount
                            ElseIf GetVendorClass = "CANADIAN" And cboCustomerClass.Text = "SRL" Then
                                'Do nothing - GL Accounts are ok
                            ElseIf GetVendorClass = "AMERICAN" And cboCustomerClass.Text = "SRL" Then
                                'Do nothing - GL Accounts are ok
                            Else
                                GetDebitAccount = "C$" & GetDebitAccount
                                GetCreditAccount = "C$" & GetCreditAccount
                            End If
                        Else
                            'Do nothing - gl accounts are correct
                        End If
                        '***********************************************************************************************************
                        Try
                            'Command to write Line Amount to GL
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GetDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Customer Return"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "From Consignment -" + cboCustomerClass.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = GLBatchNumber
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ReturnLineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Return Product Form --- GL Debit Failure on Posting"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*******************************************************************************************************************
                        Try
                            'Command to write Line Amount to GL
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GetCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Customer Return"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "From Consignment -" + cboCustomerClass.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = GLBatchNumber
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ReturnLineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Return Product Form --- GL Credit Failure on Posting"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '***********************************************************************************************************
                        If GetItemClassType = "NO" Then
                            'Skip Inventory Transaction Table
                        Else
                            'Write Values to Inventory Transaction Table

                            'Find Next Transaction Number
                            Dim InventoryTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
                            Dim InventoryTransactionNumberCommand As New SqlCommand(InventoryTransactionNumberStatement, con)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastInventoryTransactionNumber = CInt(InventoryTransactionNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                LastInventoryTransactionNumber = 867500000
                            End Try
                            con.Close()

                            NextInventoryTransactionNumber = LastInventoryTransactionNumber + 1

                            Try
                                'Write Data to the Inventory Transaction Table
                                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                                With cmd.Parameters
                                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                                    .Add("@TransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Customer Return - Consignment"
                                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                    .Add("@Quantity", SqlDbType.VarChar).Value = ReturnQuantity
                                    .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@ItemPrice", SqlDbType.VarChar).Value = ReturnPrice
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                                    .Add("@GLAccount", SqlDbType.VarChar).Value = GetDebitAccount
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Return Product Form --- Inv. Transaction Failure on Posting"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '*******************************************************************************************************
                            'Create Cost Tier for the Division
                            '*******************************************************************************************************
                            'Extract the Upper and Lower Limit of the Inventory Costing Table
                            Dim NewUpperLimit, LowerLimit, UpperLimit As Double
                            Dim MaxTransactionNumber As Integer

                            Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                            Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                            MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                MaxTransactionNumber = 0
                            End Try
                            con.Close()

                            Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                            UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
                            UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                            Catch ex As Exception
                                UpperLimit = 0
                            End Try
                            con.Close()

                            'Calculate the NEW Lower/Upper Limit for the next post
                            LowerLimit = UpperLimit + 1
                            NewUpperLimit = LowerLimit + ReturnQuantity - 1

                            'Get next Transaction Number
                            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
                            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                LastCostingTransactionNumber = 63600000
                            End Try
                            con.Close()

                            NextCostingTransactionNumber = LastCostingTransactionNumber + 1

                            Try
                                'Write Values to Inventory Costing Table
                                cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                                With cmd.Parameters
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@CostingDate", SqlDbType.VarChar).Value = ReturnDate
                                    .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@CostQuantity", SqlDbType.VarChar).Value = ReturnQuantity
                                    .Add("@Status", SqlDbType.VarChar).Value = "Customer Return"
                                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = ReturnLineNumber
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Return Product Form --- Create Cost Tier on Posting"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '*******************************************************************************************************
                            'Creates entry into Transaction Table for Consignment and Consignment Return Table
                            Try
                                'Get MAX Consignment Return Number
                                Dim MaxReturnNumberStatement As String = "SELECT MAX(ConsignmentReturnNumber) FROM ConsignmentReturnTable"
                                Dim MaxReturnNumberCommand As New SqlCommand(MaxReturnNumberStatement, con)

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    LastConsignmentReturnNumber = CInt(MaxReturnNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    LastConsignmentReturnNumber = 867500000
                                End Try
                                con.Close()

                                NextConsignmentReturnNumber = LastConsignmentReturnNumber + 1

                                'Write To Return Table
                                cmd = New SqlCommand("INSERT INTO ConsignmentReturnTable (ConsignmentReturnNumber, PartNumber, PartDescription, QuantityReturned, UnitCost, UnitPrice, ExtendedCost, ExtendedAmount, DivisionID, ReturnDate, ReturnNumber, CustomerClass, LineComment) VALUES(@ConsignmentReturnNumber,  @PartNumber, @PartDescription, @QuantityReturned, @UnitCost, @UnitPrice, @ExtendedCost, @ExtendedAmount, @DivisionID, @ReturnDate, @ReturnNumber, @CustomerClass, @LineComment)", con)

                                With cmd.Parameters
                                    .Add("@ConsignmentReturnNumber", SqlDbType.VarChar).Value = NextConsignmentReturnNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                    .Add("@QuantityReturned", SqlDbType.VarChar).Value = ReturnQuantity * -1
                                    .Add("@UnitCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@UnitPrice", SqlDbType.VarChar).Value = ReturnPrice
                                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount * -1
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount * -1
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@ReturnDate", SqlDbType.VarChar).Value = ReturnDate
                                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    .Add("@CustomerClass", SqlDbType.VarChar).Value = cboCustomerClass.Text
                                    .Add("@LineComment", SqlDbType.VarChar).Value = "Return From Warehouse to Division"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Return Product Form --- Consignment Entry on Posting"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '*****************************************************************************************************************************************
                            Try
                                'Write Data to the Inventory Transaction Table
                                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                                With cmd.Parameters
                                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber + 1
                                    .Add("@TransactionDate", SqlDbType.VarChar).Value = ReturnDate
                                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Customer Return - Consignment"
                                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                    .Add("@Quantity", SqlDbType.VarChar).Value = ReturnQuantity
                                    .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                                    .Add("@ItemPrice", SqlDbType.VarChar).Value = ReturnPrice
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboCustomerClass.Text
                                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                                    .Add("@GLAccount", SqlDbType.VarChar).Value = GetCreditAccount
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Return Product Form --- Consignment Inv. Transaction Entry on Posting"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                            '***********************************************************************************************************************************
                        End If
                    End If
                Next

                '**********************************
                'End of Ledger Entry
                '**********************************

            Case Else
                MsgBox("There was a problem with this return. Contact system Admin.", MsgBoxStyle.OkOnly)
                Exit Sub
        End Select

        '*************************************************************************************************************************************
        'End of GL and Line Details
        '*************************************************************************************************************************************

        '*************************************************************************************************************************************
        'Update Header with Total COS and change status

        'Get total COS from lines
        Dim SUMLineCOSStatement As String = "SELECT SUM(ExtendedCOS) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim SUMLineCOSCommand As New SqlCommand(SUMLineCOSStatement, con)
        SUMLineCOSCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        SUMLineCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalCOS = CDbl(SUMLineCOSCommand.ExecuteScalar)
        Catch ex As Exception
            TotalCOS = 0
        End Try
        con.Close()

        Try
            'Update COS
            cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET TotalCOS = @TotalCOS, ReturnStatus = @ReturnStatus, PrintDate = @PrintDate WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@TotalCOS", SqlDbType.VarChar).Value = TotalCOS
                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "PENDING"
                .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempReturnNumber As Integer = 0
            Dim strReturnNumber As String
            TempReturnNumber = Val(cboReturnNumber.Text)
            strReturnNumber = CStr(TempReturnNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Return Product Form --- Last Update Header/Status on Posting"
            ErrorReferenceNumber = "Return # " + strReturnNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '*************************************************************************************************************************

        'Show Serial Lines
        ShowSerialLines()

        '=====================================================================
        'Update Serial Log from the temp table if applicable
        If dgvSerialLogTemp.RowCount > 0 Then
            Dim RowPartNumber As String = ""
            Dim RowSerialNumber As String = ""
            Dim RowBuildNumber As Integer = 0
            Dim RowStatus As String = ""
            Dim RowCustomerID As String = ""
            Dim RowBatchNumber As Integer = 0
            Dim RowTransactionNumber As Integer = 0
            Dim RowTotalCost As Double = 0

            For Each row As DataGridViewRow In dgvSerialLogTemp.Rows
                Try
                    RowPartNumber = row.Cells("AssemblyPartNumberColumn").Value
                Catch ex As Exception
                    RowPartNumber = ""
                End Try
                Try
                    RowSerialNumber = row.Cells("SerialNumberColumn").Value
                Catch ex As Exception
                    RowSerialNumber = ""
                End Try
                Try
                    RowBuildNumber = row.Cells("BuildNumberColumn").Value
                Catch ex As Exception
                    RowBuildNumber = 0
                End Try
                Try
                    RowCustomerID = row.Cells("CustomerIDColumn").Value
                Catch ex As Exception
                    RowCustomerID = ""
                End Try
                Try
                    RowBatchNumber = row.Cells("BatchNumberColumn").Value
                Catch ex As Exception
                    RowBatchNumber = 0
                End Try
                Try
                    RowTransactionNumber = row.Cells("TransactionNumberColumn").Value
                Catch ex As Exception
                    RowTransactionNumber = 0
                End Try
                Try
                    RowTotalCost = row.Cells("TotalCostColumn").Value
                Catch ex As Exception
                    RowTotalCost = 0
                End Try
                '****************************************************************************************
                Try
                    'Update Serial Log
                    cmd = New SqlCommand("UPDATE AssemblySerialLog SET DivisionID = @DivisionID, Comment = @Comment, Status = @Status, TransactionNumber = @TransactionNumber, CustomerID = @CustomerID, BatchNumber = @BatchNumber WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = "Customer Return"
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = RowBatchNumber
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempReturnNumber As Integer = 0
                    Dim strReturnNumber As String
                    TempReturnNumber = Val(cboReturnNumber.Text)
                    strReturnNumber = CStr(TempReturnNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Return Product Form --- Update Serial # to open failure."
                    ErrorReferenceNumber = "Return # " + strReturnNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '****************************************************************************************
                'Update Line Comment Field --- Concatenate comments if necessary
                'get current line comment
                Dim CurrentLineComment As String = ""
                Dim FinalLineComment As String = ""

                Dim CurrentLineCommentStatement As String = "SELECT LineComment FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                Dim CurrentLineCommentCommand As New SqlCommand(CurrentLineCommentStatement, con)
                CurrentLineCommentCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                CurrentLineCommentCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = RowBatchNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CurrentLineComment = CStr(CurrentLineCommentCommand.ExecuteScalar)
                Catch ex As Exception
                    CurrentLineComment = ""
                End Try
                con.Close()

                If CurrentLineComment = "" Then
                    FinalLineComment = RowSerialNumber
                Else
                    FinalLineComment = CurrentLineComment + ", S/N - " + RowSerialNumber
                End If

                'Update line Comment to Return Line table
                cmd = New SqlCommand("UPDATE ReturnProductLineTable SET LineComment = @LineComment WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                With cmd.Parameters
                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = RowBatchNumber
                    .Add("@LineComment", SqlDbType.VarChar).Value = FinalLineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next
        End If
        '======================================================================
        unlockBatch()
        ClearVariables()
        ClearData()
        ShowReturnLineData()

        MsgBox("Customer Return has been posted.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboReturnNumber.Text = "" Or Val(cboReturnNumber.Text) = 0 Then
            MsgBox("You must select a valid Return Number to continue", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                LoadReturnHeaderData()
                ShowReturnLineData()
                Exit Sub
            End If
            LockBatch()

            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Return?", "SAVE RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '**********************************************************************************************************
                If cboCustomerClass.Text = "DE-ACTIVATED" Then
                    MsgBox("You cannot save a return for a De-Activated Customer.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Skip
                End If
                '**********************************************************************************************************
                Try
                    'Convert date if necessary and load totals
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        ReturnDate = dtpReturnDate.Value
                        'Load totals
                        LoadCanadianTaxRate()
                        CalculateTotalsCanadian()
                    Else
                        ReturnDate = dtpReturnDate.Value
                        'Load totals
                        CalculateTotals()
                    End If
                    '**********************************************************************************************************************
                    'Validate Customer Class and FOB
                    If cboCustomerClass.Text = "" Then
                        cboCustomerClass.Text = "STANDARD"
                    End If

                    If cboFOB.Text = "" Then
                        cboFOB.Text = cboDivisionID.Text
                    End If
                    '**********************************************************************************************************************
                    'Command to Save all data and write to Database
                    Try
                        ReturnStatus = "OPEN"
                        txtReturnStatus.Text = ReturnStatus
                        UpdateReturnHeaderTable()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempReturnNumber As Integer = 0
                        Dim strReturnNumber As String
                        TempReturnNumber = Val(cboReturnNumber.Text)
                        strReturnNumber = CStr(TempReturnNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Return Product Form --- Update Header Failure"
                        ErrorReferenceNumber = "Return # " + strReturnNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '**********************************************************************************************************************
                    'Call procedure to populate grid on form
                    ShowReturnLineData()
                    ShowSerialLines()
                    ReLoadTotals()
                    '**********************************************************************************************************************
                    'Prompt after Save
                    MsgBox("This Return has been saved.", MsgBoxStyle.OkOnly)
                Catch ex As Exception
                    MsgBox("This Return has not been saved. Verify data and try again.", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                cboReturnNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If canAddLine() Then
            LockBatch()
            '**********************************************************************************************************
            If cboCustomerClass.Text = "DE-ACTIVATED" Then
                MsgBox("You cannot process a return for a De-Activated Customer.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Skip
            End If
            '**********************************************************************************************************
            'Convert date if necessary and load totals
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                ReturnDate = dtpReturnDate.Value
                'Load totals
                CalculateTotalsCanadian()
            Else
                ReturnDate = dtpReturnDate.Value
                'Load totals
                CalculateTotals()
            End If

            'Calculate and display current totals from line entry
            Status = "OPEN"
            LineQuantity = Val(txtReturnQuantity.Text)
            LinePrice = Val(txtReturnPrice.Text)
            LineTotal = LineQuantity * LinePrice
            LineTotal = Math.Round(LineTotal, 2)
            ExtendedAmount = LineTotal

            'Valid negatives in Line Entry
            CheckNegatives()

            If strCheckNegativePrice = "YES" Then
                MsgBox("Price cannot be negative.", MsgBoxStyle.OkOnly)
                txtReturnPrice.Clear()
                txtReturnPrice.Focus()
                strCheckNegativePrice = ""
                Exit Sub
            Else
                'Continue
            End If

            If strCheckNegativeQuantity = "YES" Then
                Dim button As DialogResult = MessageBox.Show("A negative quantity will result in a charge to the customer. Is this correct?", "NEGATIVE QUANTITY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Do nothing and continue
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            Else
                'Do nothing and continue
            End If

            'If canadian, do not calculate sales tax for lines
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                LineSalesTax = 0
                SalesTaxTotal = 0
                'Sales Tax will be calculated later
            Else
                LineSalesTax = LineTotal * Val(txtSalesTaxLineRate.Text)
                LineSalesTax = Math.Round(LineSalesTax, 2)
                SalesTaxTotal = SalesTaxTotal + LineSalesTax
                txtReturnSalesTax.Text = SalesTaxTotal
            End If

            ProductTotal = ProductTotal + LineTotal
            ReturnTotal = ProductTotal + Val(txtReturnFreight.Text) + SalesTaxTotal + Val(txtReturnSalesTax2.Text) + Val(txtReturnSalesTax3.Text)

            Try
                ReturnStatus = "OPEN"
                txtReturnStatus.Text = ReturnStatus
                InsertReturnHeaderTable()
            Catch ex As Exception
                ReturnStatus = "OPEN"
                txtReturnStatus.Text = ReturnStatus
                UpdateReturnHeaderTable()
            End Try

            'Get Item Class 
            Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
            GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboReturnPartNumber.Text
            GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
            Catch ex As Exception
                GetItemClass = "TW CA"
            End Try
            con.Close()
            '*****************************************************************************************************************************************
            Dim GetItemClassType As String = ""

            Dim GetItemClassTypeStatement As String = "SELECT InventoryItem FROM ItemClass WHERE ItemClassID = @ItemClassID"
            Dim GetItemClassTypeCommand As New SqlCommand(GetItemClassTypeStatement, con)
            GetItemClassTypeCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetItemClassType = CStr(GetItemClassTypeCommand.ExecuteScalar)
            Catch ex As Exception
                GetItemClassType = "YES"
            End Try
            con.Close()
            '******************************************************************************************************************************************
            'Get COS
            '******************************************************************************************************************************************
            'Determine FIFO Cost on Part Number to remove from Inventory
            Dim TotalQuantityShipped As Double = 0
            Dim NoCostTierFound As String = "FALSE"
            FIFOCost = 0
            FIFOExtendedAmount = 0
            '******************************************************************************************************************************************
            'Determine Total Quantity Shipped
            Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
            TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboReturnPartNumber.Text
            TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
            Catch ex As Exception
                TotalQuantityShipped = 1
            End Try
            con.Close()

            TotalQuantityShipped = TotalQuantityShipped - LineQuantity
            '******************************************************************************************************************************************
            'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
            Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
            Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
            ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboReturnPartNumber.Text
            ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FIFOCost = CDbl(ItemCostCommand.ExecuteScalar)
            Catch ex As Exception
                FIFOCost = 0
            End Try
            con.Close()

            FIFOExtendedAmount = FIFOCost * LineQuantity
            '*****************************************************************************************************************************************
            'If FIFO Cost is Zero for Inventory Items (excluding Ferrules), use Last Purchase Cost
            If FIFOCost = 0 Then
                If ItemClass <> "FERRULE" And ItemClass <> "WC FERRULES" And ItemClass <> "WC WELD TILES" Then
                    Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboReturnPartNumber.Text

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
                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboReturnPartNumber.Text
                    LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastPurchaseCost = 0
                    End Try
                    con.Close()

                    FIFOCost = LastPurchaseCost
                    FIFOExtendedAmount = FIFOCost * LineQuantity

                    If FIFOCost = 0 Then

                        Dim TransactionCostStatement As String = "SELECT MAX(ItemCost) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                        Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                        TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboReturnPartNumber.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            TransactionCost = 0
                        End Try
                        con.Close()

                        FIFOCost = TransactionCost
                        FIFOExtendedAmount = FIFOCost * LineQuantity

                        If FIFOCost = 0 Then
                            Dim StdUnitCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                            Dim StdUnitCostCommand As New SqlCommand(StdUnitCostStatement, con)
                            StdUnitCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            StdUnitCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboReturnPartNumber.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                StdUnitCost = CDbl(StdUnitCostCommand.ExecuteScalar)
                            Catch ex As Exception
                                StdUnitCost = 0
                            End Try
                            con.Close()

                            FIFOCost = StdUnitCost
                            FIFOExtendedAmount = FIFOCost * LineQuantity
                        End If
                    End If
                ElseIf ItemClass = "WC FERRULES" Or ItemClass = "WC WELD TILES" Then
                    Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboReturnPartNumber.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxDate = CInt(MAXDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MaxDate = 0
                    End Try
                    con.Close()

                    Dim LastPriceStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                    Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                    LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboReturnPartNumber.Text
                    LastPriceCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastPurchaseCost = 0
                    End Try
                    con.Close()

                    FIFOCost = LastPurchaseCost
                    FIFOExtendedAmount = FIFOCost * LineQuantity

                    If FIFOCost = 0 Then

                        Dim TransactionCostStatement As String = "SELECT MAX(ItemCost) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                        Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                        TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboReturnPartNumber.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            TransactionCost = 0
                        End Try
                        con.Close()

                        FIFOCost = TransactionCost
                        FIFOExtendedAmount = FIFOCost * LineQuantity
                    End If
                Else
                    'Do nothing - Ferrules have 0 Cost
                End If
            Else
                'Do nothing - continue
            End If

            'Round FIFO Amount to two digits
            FIFOExtendedAmount = Math.Round(FIFOExtendedAmount, 2)
            '******************************************************************************************************************************************
            If GetItemClassType = "NO" Then
                FIFOExtendedAmount = 0
            Else
                'FIFO is correct
            End If
            '******************************************************************************************************************************************
            'Create New Line Number
            Dim MAXLineStatement As String = "SELECT MAX(ReturnLineNumber) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber"
            Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
            MAXLineCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
            Catch ex As Exception
                LastLineNumber = 0
            End Try
            con.Close()

            NextLineNumber = LastLineNumber + 1

            Try
                'Write Data to Return Line Database Table
                cmd = New SqlCommand("Insert Into ReturnProductLineTable(ReturnNumber, ReturnLineNumber, PartNumber, Description, Quantity, UnitPrice, ExtendedAmount, DivisionID, LineStatus, DebitGLAccount, CreditGLAccount, SalesTax, SOLineNumber, ExtendedCOS, LineComment) Values (@ReturnNumber, @ReturnLineNumber, @PartNumber, @Description, @Quantity, @UnitPrice, @ExtendedAmount, @DivisionID, @LineStatus, @DebitGLAccount, @CreditGLAccount, @SalesTax, @SOLineNumber, @ExtendedCOS, @LineComment)", con)

                With cmd.Parameters
                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboReturnPartNumber.Text
                    .Add("@Description", SqlDbType.VarChar).Value = cboDescription.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                    .Add("@UnitPrice", SqlDbType.VarChar).Value = LinePrice
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtGLInventoryAccount.Text
                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtSalesOffset.Text
                    .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                    .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Return Product Form --- Insert into Line COS on Enter"
                ErrorReferenceNumber = "Return # " + strReturnNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*****************************************************************************************************************
            'UPDATE Totals
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                CalculateCanadianTaxes()
            Else
                CalculateTotals()
            End If

            Try
                'Update Totals
                UpdateTotals()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Return Product Form --- Update Totals on enter"
                ErrorReferenceNumber = "Return # " + strReturnNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Call procedure to populate grid on form
            ShowReturnLineData()
            ReLoadTotals()

            Try
                'Set focus to current cell in the datagrid
                Me.dgvReturnLines.Rows(dgvReturnLines.Rows.Count - 1).Selected = True
                Me.dgvReturnLines.CurrentCell = Me.dgvReturnLines.Rows(Me.dgvReturnLines.Rows.Count - 1).Cells(1)
            Catch ex As Exception
                'Skip
            End Try

            'Clear text boxes and reset data
            LineTotal = 0
            Counter = Counter + 1
            cboDescription.SelectedIndex = -1
            cboReturnPartNumber.SelectedIndex = -1
            cboItemClass.SelectedIndex = -1
            strCheckNegativePrice = ""
            strCheckNegativeQuantity = ""
            txtReturnPrice.Clear()
            txtReturnQuantity.Clear()
            txtLineTotal.Clear()
            cboReturnPartNumber.Focus()

            If cboCustomerName.Enabled Then
                cboCustomerName.Enabled = False
                cboReturnCustomer.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If Not String.IsNullOrEmpty(cboReturnNumber.Text) Then
            unlockBatch()
        End If

        ClearVariables()
        ClearData()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If cboReturnNumber.Text = "" Or Val(cboReturnNumber.Text) = 0 Then
            MsgBox("You must select a valid Return Number to continue", MsgBoxStyle.OkOnly)
        Else
            If ReturnStatus = "POSTED" Then
                MsgBox("You cannot delete a line from a Return that has been posted.", MsgBoxStyle.OkOnly)
            Else
                If isSomeoneEditing() Then
                    LoadReturnHeaderData()
                    ShowReturnLineData()
                    Exit Sub
                End If

                LockBatch()

                'Prompt before deleting
                Dim button As DialogResult = MessageBox.Show("Do you wish to delete this line", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then

                    Try
                        'Create command to delete data from text boxes
                        cmd = New SqlCommand("DELETE FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)
                        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                        cmd.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = Val(cboLineNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        'Log error on update failure
                        Dim TempReturnNumber As Integer = 0
                        Dim strReturnNumber As String
                        TempReturnNumber = Val(cboReturnNumber.Text)
                        strReturnNumber = CStr(TempReturnNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Return Product Form --- Delete Line Failure"
                        ErrorReferenceNumber = "Return # " + strReturnNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MsgBox("Return Line cannot be deleted.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End Try

                    'Show updated table
                    ShowReturnLineData()

                    Dim TempReturnLine As Integer = 1000

                    'Renumber lines with temp line number
                    For Each row As DataGridViewRow In dgvReturnLines.Rows
                        Try
                            ReturnLineNumber = row.Cells("ReturnLineNumberColumn").Value
                        Catch ex As Exception
                            ReturnLineNumber = 1
                        End Try

                        Try
                            'Get current Line Number
                            cmd = New SqlCommand("UPDATE ReturnProductLineTable SET ReturnLineNumber = @TempReturnLine WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)
                            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                            cmd.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber
                            cmd.Parameters.Add("@TempReturnLine", SqlDbType.VarChar).Value = TempReturnLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error Log

                        End Try

                        TempReturnLine = TempReturnLine + 1
                    Next

                    'Show updated table
                    ShowReturnLineData()

                    'New starting line number
                    TempReturnLine = 1

                    'Renumber lines with new line number
                    For Each row As DataGridViewRow In dgvReturnLines.Rows
                        Try
                            ReturnLineNumber = row.Cells("ReturnLineNumberColumn").Value
                        Catch ex As Exception
                            ReturnLineNumber = 1000
                        End Try

                        Try
                            'Get current Line Number
                            cmd = New SqlCommand("UPDATE ReturnProductLineTable SET ReturnLineNumber = @TempReturnLine WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)
                            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                            cmd.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber
                            cmd.Parameters.Add("@TempReturnLine", SqlDbType.VarChar).Value = TempReturnLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error Log

                        End Try

                        TempReturnLine = TempReturnLine + 1
                    Next

                    'Load new totals
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateTotalsCanadian()
                    Else
                        CalculateTotals()
                    End If

                    'Update totals
                    Try
                        UpdateTotals()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempReturnNumber As Integer = 0
                        Dim strReturnNumber As String
                        TempReturnNumber = Val(cboReturnNumber.Text)
                        strReturnNumber = CStr(TempReturnNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Return Product Form --- Update Totals on delete line"
                        ErrorReferenceNumber = "Return # " + strReturnNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    'Reload datagrid
                    ShowReturnLineData()

                    If dgvReturnLines.Rows.Count = 0 Then
                        cboLineNumber.Text = ""
                        cboLinePartNumber.Text = ""
                    End If

                    'Prompt after deletion
                    MsgBox("This line has been deleted.", MsgBoxStyle.OkOnly)

                    If dgvReturnLines.Rows.Count = 0 Then
                        If cboCustomerName.Enabled = False Then
                            cboCustomerName.Enabled = True
                            cboReturnCustomer.Enabled = True
                        End If

                        If cboSalesOrderNumber.Enabled = False Then
                            cboSalesOrderNumber.Enabled = True
                        End If
                    Else
                        cboSalesOrderNumber.Enabled = True
                    End If
                ElseIf button = DialogResult.No Then
                    cboReturnNumber.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboReturnNumber.Text = "" Or Val(cboReturnNumber.Text) = 0 Then
            MsgBox("You must select a valid Return Number to continue", MsgBoxStyle.OkOnly)
        Else
            If ReturnStatus = "CLOSED" Or ReturnStatus = "PENDING" Then
                MsgBox("You cannot delete a Return that has been posted.", MsgBoxStyle.OkOnly)
            Else
                If isSomeoneEditing() Then
                    LoadReturnHeaderData()
                    ShowReturnLineData()
                    Exit Sub
                End If

                'Prompt before deleting
                Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Customer Return?", "DELETE RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Write to Audit Trail Table
                    Dim AuditComment As String = ""
                    Dim AuditReturnNumber As Integer = 0
                    Dim strReturnNumber As String = ""

                    AuditReturnNumber = Val(cboReturnNumber.Text)
                    strReturnNumber = CStr(AuditReturnNumber)
                    AuditComment = "Return #" + strReturnNumber + " for customer " + cboCustomerName.Text + " was deleted on " + Today()

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "CUSTOMER RETURN - DELETION"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = ReturnTotal
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strReturnNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        'Log error on update failure
                        Dim TempReturnNumber As Integer = 0
                        Dim strReturnNumber2 As String
                        TempReturnNumber = Val(cboReturnNumber.Text)
                        strReturnNumber2 = CStr(TempReturnNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Return Product Form --- Audit Trail Entry Failure"
                        ErrorReferenceNumber = "Return # " + strReturnNumber2
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '************************************************************************************************
                    Try
                        'Create command to delete data from text boxes
                        cmd = New SqlCommand("DELETE FROM ReturnProductHeaderTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        'Log error on update failure
                        Dim TempReturnNumber As Integer = 0
                        Dim strReturnNumber2 As String
                        TempReturnNumber = Val(cboReturnNumber.Text)
                        strReturnNumber2 = CStr(TempReturnNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Return Product Form --- Delete Return Failure"
                        ErrorReferenceNumber = "Return # " + strReturnNumber2
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                        Exit Sub
                    End Try
                    '***********************************************************************************
                    'Delete from Serial Lines if applicable
                    Try
                        'Create command to delete data from text boxes
                        cmd = New SqlCommand("DELETE FROM AssemblySerialTempTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        'Log error on update failure
                        Dim TempReturnNumber As Integer = 0
                        Dim strReturnNumber2 As String
                        TempReturnNumber = Val(cboReturnNumber.Text)
                        strReturnNumber2 = CStr(TempReturnNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Return Product Form --- Delete Serial Temp"
                        ErrorReferenceNumber = "Return # " + strReturnNumber2
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '****************************************************************************************
                    isLoaded = False
                    'Clear All Text Boxes
                    ClearVariables()
                    ClearData()
                    LoadReturnNumber()
                    ShowReturnLineData()
                    ShowSerialLines()
                    isLoaded = True

                    'Prompt after deletion
                    MsgBox("This Return has been deleted.", MsgBoxStyle.OkOnly)
                ElseIf button = DialogResult.No Then
                    cboReturnNumber.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdDeleteSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSN.Click
        Dim RowTransactionNumber As Integer = 0
        Dim RowSerialNumber As String = ""
        Dim RowBatchNumber As Integer = 0

        If Me.dgvReturnLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvReturnLines.CurrentCell.RowIndex

            Try
                RowTransactionNumber = Me.dgvReturnLines.Rows(RowIndex).Cells("TransactionNumberColumn").Value
            Catch ex As Exception
                RowTransactionNumber = 0
            End Try
            Try
                RowSerialNumber = Me.dgvReturnLines.Rows(RowIndex).Cells("SerialNumberColumn").Value
            Catch ex As Exception
                RowSerialNumber = ""
            End Try
            Try
                RowBatchNumber = Me.dgvReturnLines.Rows(RowIndex).Cells("BatchNumberColumn").Value
            Catch ex As Exception
                RowBatchNumber = 0
            End Try

            'Update Totals in Header Table
            cmd = New SqlCommand("DELETE FROM AssemblySerialTempTable WHERE SerialNumber = @SerialNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND BatchNumber = @BatchNumber", con)

            With cmd.Parameters
                .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@TransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                .Add("@BatchNumber", SqlDbType.VarChar).Value = RowBatchNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Serial # has been deleted.", MsgBoxStyle.OkOnly)

            'Refresh Datagrid
            ShowSerialLines()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboReturnNumber.Text = "" Or Val(cboReturnNumber.Text) = 0 Then
            MsgBox("You must have a valid Return Number.", MsgBoxStyle.OkOnly)
        Else
            If Not isSomeoneEditing() Then
                LockBatch()
                '**********************************************************************************************************
                If cboCustomerClass.Text = "DE-ACTIVATED" Then
                    MsgBox("You cannot process a return for a De-Activated Customer.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Skip
                End If
                '**********************************************************************************************************
                'Convert date if necessary and load totals
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    ReturnDate = dtpReturnDate.Value
                    'Load totals
                    CalculateTotalsCanadian()
                Else
                    ReturnDate = dtpReturnDate.Value
                    'Load totals
                    CalculateTotals()
                End If
                '**********************************************************************************************************************
                'Validate Customer Class and FOB
                If cboCustomerClass.Text = "" Then
                    cboCustomerClass.Text = "STANDARD"
                End If

                If cboFOB.Text = "" Then
                    cboFOB.Text = cboDivisionID.Text
                End If
                '**********************************************************************************************************************
                Try
                    ReturnStatus = txtReturnStatus.Text

                    UpdateReturnHeaderTable()
                Catch ex As Exception
                    'Error Log
                    'Log error on update failure
                    Dim TempReturnNumber As Integer = 0
                    Dim strReturnNumber As String
                    TempReturnNumber = Val(cboReturnNumber.Text)
                    strReturnNumber = CStr(TempReturnNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Return Product Form --- Update Header Failure"
                    ErrorReferenceNumber = "Return # " + strReturnNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Call procedure to populate grid on form
                ShowReturnLineData()
                ShowSerialLines()
                ReLoadTotals()
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
                GlobalCustomerReturnNumber = Val(cboReturnNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintCustomerReturnRemote As New PrintCustomerReturnRemote
                    Dim result = NewPrintCustomerReturnRemote.ShowDialog()
                End Using
            Else
                GlobalCustomerReturnNumber = Val(cboReturnNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintCustomerReturn As New PrintCustomerReturn
                    Dim result = NewPrintCustomerReturn.ShowDialog()
                End Using
            End If
        End If
    End Sub

    'Menu Strip Routines

    Private Sub UnLockReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockReturnToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboReturnNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this batch?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET Locked = '' WHERE ReturnNumber = @ReturnNumber", con)
                cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Batch is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a batch number to un-lock", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.Focus()
        End If
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub PrintReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReturnToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ManuallyCloseReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyCloseReturnToolStripMenuItem.Click
        If txtReturnStatus.Text = "PENDING" Then
            If isSomeoneEditing() Then
                LoadReturnHeaderData()
                ShowReturnLineData()
                Exit Sub
            End If

            ReturnStatus = "CLOSED"
            txtReturnStatus.Text = ReturnStatus

            'Update Return Header to Closed
            Try
                UpdateReturnHeaderTable()
            Catch ex As Exception
                'Error Log
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Return Product Form --- Update error on Closing"
                ErrorReferenceNumber = "Return # " + strReturnNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Update Line Status to closed
            cmd = New SqlCommand("UPDATE ReturnProductLineTable SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@LineStatus", SqlDbType.VarChar).Value = ReturnStatus
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtReturnStatus.Text = "CLOSED"
        End If
    End Sub

    Private Sub DeleteReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteReturnToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub SaveReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveReturnToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    'Combo Box Routines

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(lastReturn) Then
                unlockBatch(lastReturn)
            End If

            lastReturn = ""

            LoadCustomerClass()

            If cboDivisionID.Text = "TWD" Then
                gpxConsignmentBox.Enabled = True
                cmdDeleteSN.Enabled = True
            ElseIf cboDivisionID.Text = "TFF" Then
                gpxConsignmentBox.Enabled = True
                cmdDeleteSN.Enabled = True
            ElseIf cboDivisionID.Text = "TWE" Then
                gpxConsignmentBox.Enabled = True
                cmdDeleteSN.Enabled = True
            ElseIf cboDivisionID.Text = "SLC" Then
                gpxConsignmentBox.Enabled = False
                cmdDeleteSN.Enabled = True
            Else
                gpxConsignmentBox.Enabled = False
                cmdDeleteSN.Enabled = True
            End If

            If cboReturnSalesperson.Text = "" Then
                cboReturnSalesperson.Text = EmployeeSalespersonCode
            Else
                'Do nothing
            End If

            ShowReturnLineData()

            cboItemClass.SelectedIndex = -1

            'Load procedures
            LoadItemList()
            LoadCustomerList()
            LoadCustomerName()
            LoadPartDescription()
            LoadCanadianDefaults()
            LoadSalesOrderNumber()
            LoadReturnNumber()
        End If
    End Sub

    Private Sub cboReturnCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReturnCustomer.SelectedIndexChanged
        If isLoaded Then
            LoadSalesOrderNumber()

            'Load Customer Name
            Dim CustomerNameStatement As String = "SELECT CustomerName, CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerNameCommand As New SqlCommand(CustomerNameStatement, con)
            CustomerNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboReturnCustomer.Text
            CustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            Dim customerClass As String = "STANDARD"

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = CustomerNameCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("CustomerName")) Then
                    CustomerName = cboCustomerName.Text
                Else
                    CustomerName = reader.Item("CustomerName")
                End If
                If Not IsDBNull(reader.Item("CustomerClass")) Then
                    customerClass = reader.Item("CustomerClass")
                End If
            Else
                CustomerName = cboCustomerName.Text
            End If
            reader.Close()
            con.Close()

            cboCustomerName.Text = CustomerName
            cboCustomerClass.Text = customerClass
            LoadSalesTaxRate()
        End If
    End Sub

    Private Sub cboReturnPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReturnPartNumber.SelectedIndexChanged
        If isLoaded Then
            LoadItemData()
            LoadDescriptionByPart()
        End If
    End Sub

    Private Sub cboReturnNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReturnNumber.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(lastReturn) Then
                unlockBatch(lastReturn)
            End If

            Dim returnNumb As String = cboReturnNumber.Text
            isLoaded = False

            ClearData()
            cboReturnNumber.Text = returnNumb
            cboReturnNumber.SelectAll()
            cboReturnNumber.Focus()
            isLoaded = True

            LoadReturnHeaderData()
            ShowReturnLineData()
            ShowSerialLines()

            If dgvReturnLines.Rows.Count > 0 And Val(cboSalesOrderNumber.Text) <> 0 Then
                cboReturnCustomer.Enabled = False
                cboCustomerName.Enabled = False
            Else
                cboReturnCustomer.Enabled = True
                cboCustomerName.Enabled = True
                cboSalesOrderNumber.Enabled = True
            End If
            lastReturn = cboReturnNumber.Text
        End If
    End Sub

    Private Sub cboItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClass.SelectedIndexChanged
        If isLoaded Then
            LoadItemClassInfo()
        End If
    End Sub

    Private Sub cboFOB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOB.SelectedIndexChanged
        'Load FOB Name on change
        If cboFOB.Text = "HOU" Or cboFOB.Text = "CHT" Or cboFOB.Text = "TFT" Or cboFOB.Text = "TWD" Or cboFOB.Text = "TWE" Or cboFOB.Text = "TFP" Or cboFOB.Text = "TOR" Or cboFOB.Text = "SLC" Or cboFOB.Text = "TFF" Or cboFOB.Text = "ALB" Or cboFOB.Text = "ATL" Or cboFOB.Text = "DEN" Or cboFOB.Text = "CBS" Then
            txtFOBName.Text = "Standard"
        Else
            LoadFOBName()
        End If
    End Sub

    Private Sub cboSalesOrderNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesOrderNumber.SelectedIndexChanged
        'Load Customer PO from the Sales Order
        Dim CustomerPOStatement As String = "SELECT CustomerPO FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim CustomerPOCommand As New SqlCommand(CustomerPOStatement, con)
        CustomerPOCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)
        CustomerPOCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerPO = CStr(CustomerPOCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerPO = ""
        End Try
        con.Close()

        txtCustomerPO.Text = CustomerPO
    End Sub

    'Text Box Routines

    Private Sub txtReturnFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnFreight.TextChanged
        FreightTotal = Val(txtReturnFreight.Text)
        ReturnTotal = ProductTotal + FreightTotal + Val(txtReturnSalesTax.Text) + Val(txtReturnSalesTax2.Text) + Val(txtReturnSalesTax3.Text)
        lblReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
    End Sub

    Private Sub txtReturnSalesTax2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnSalesTax2.TextChanged
        SalesTax2Total = Val(txtReturnSalesTax2.Text)
        ReturnTotal = ProductTotal + Val(txtReturnFreight.Text) + Val(txtReturnSalesTax.Text) + Val(txtReturnSalesTax2.Text) + Val(txtReturnSalesTax3.Text)
        lblReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
    End Sub

    Private Sub txtReturnSalesTax3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnSalesTax3.TextChanged
        SalesTax3Total = Val(txtReturnSalesTax3.Text)
        ReturnTotal = ProductTotal + Val(txtReturnFreight.Text) + Val(txtReturnSalesTax.Text) + Val(txtReturnSalesTax2.Text) + Val(txtReturnSalesTax3.Text)
        lblReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
    End Sub

    Private Sub txtReturnSalesTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnSalesTax.TextChanged
        SalesTaxTotal = Val(txtReturnSalesTax.Text)
        ReturnTotal = ProductTotal + Val(txtReturnFreight.Text) + SalesTaxTotal + Val(txtReturnSalesTax2.Text) + Val(txtReturnSalesTax3.Text)
        lblReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
    End Sub

    Private Sub txtReturnQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnQuantity.TextChanged
        LineQuantity = Val(txtReturnQuantity.Text)
        LinePrice = Val(txtReturnPrice.Text)
        LineTotal = LineQuantity * LinePrice
        txtLineTotal.Text = FormatCurrency(LineTotal, 2)
    End Sub

    Private Sub txtReturnPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnPrice.TextChanged
        'Calculate Line Total of Product Return
        LineQuantity = Val(txtReturnQuantity.Text)
        LinePrice = Val(txtReturnPrice.Text)
        LineTotal = LineQuantity * LinePrice
        txtLineTotal.Text = FormatCurrency(LineTotal, 2)
    End Sub

    'Datagrid Routines

    Private Sub dgvReturnLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReturnLines.CellDoubleClick
        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC" Then
            'Get Part Data and open Serial Popup
            Dim RowPartNumber As String = ""
            Dim RowQuantity As Double = 0
            Dim RowLineNumber As Integer = 0

            Dim RowIndex As Integer = Me.dgvReturnLines.CurrentCell.RowIndex

            RowPartNumber = Me.dgvReturnLines.Rows(RowIndex).Cells("PartNumberColumn").Value
            RowQuantity = Me.dgvReturnLines.Rows(RowIndex).Cells("QuantityColumn").Value
            RowLineNumber = Me.dgvReturnLines.Rows(RowIndex).Cells("ReturnLineNumberColumn").Value
            '*************************************************************************************************************
            'Check to see if part is a serialized assembly
            Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
            GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPurchProdLineID = CStr(GetPPLCommand.ExecuteScalar)
            Catch ex As Exception
                GetPurchProdLineID = ""
            End Try
            con.Close()
            '*************************************************************************************************************
            If GetPurchProdLineID = "ASSEMBLY" Then
                Dim CheckSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
                CheckSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSerialStatus = CStr(CheckSerializedCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSerialStatus = "NO"
                End Try
                con.Close()
                '*********************************************************************************************************
                If GetSerialStatus = "YES" Then
                    'Open serial popup
                    GlobalAssemblyTransactionNumber = Val(cboReturnNumber.Text)
                    GlobalSerialAssemblyQuantity = RowQuantity
                    GlobalSerialFormLocation = "CUSTOMERRETURN"
                    GlobalAssemblyPartNumber = RowPartNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalAssemblyBatchNumber = RowLineNumber

                    Using NewAssemblySerialPopup As New AssemblySerialPopup
                        Dim Result = NewAssemblySerialPopup.ShowDialog()
                    End Using

                    'Show Lines
                    ShowSerialLines()
                Else
                    'Do nothing - exit sub
                    Exit Sub
                End If
            Else
                'Do nothing - exit sub
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvReturnLines.CellValueChanged
        If isLoaded Then
            If isSomeoneEditing() Then
                LoadReturnHeaderData()
                ShowReturnLineData()
                Exit Sub
            End If

            LockBatch()

            Dim LineExtendedAmount, LinePrice, LineQuantity, LineTaxTotal, LineTaxRate As Double
            Dim LineNumber As Integer = 0
            Dim LineDescription As String = ""
            Dim LineComment As String = ""

            Dim RowQuantity, RowPrice As Double

            If Me.dgvReturnLines.RowCount <> 0 Then
                Dim RowIndex As Integer = Me.dgvReturnLines.CurrentCell.RowIndex

                Try
                    RowQuantity = Me.dgvReturnLines.Rows(RowIndex).Cells("QuantityColumn").Value
                Catch ex As Exception
                    RowQuantity = 0
                End Try
                Try
                    RowPrice = Me.dgvReturnLines.Rows(RowIndex).Cells("UnitPriceColumn").Value
                Catch ex As Exception
                    RowPrice = 0
                End Try

                'Valid negatives in Line Entry
                If RowPrice < 0 Then strCheckNegativePrice = "YES"
                If RowQuantity < 0 Then strCheckNegativeQuantity = "YES"

                If strCheckNegativePrice = "YES" Then
                    MsgBox("Price cannot be negative.", MsgBoxStyle.OkOnly)
                    ShowReturnLineData()
                    Exit Sub
                Else
                    'Continue
                End If

                If strCheckNegativeQuantity = "YES" Then
                    Dim button As DialogResult = MessageBox.Show("A negative quantity will result in a charge to the customer. Is this correct?", "NEGATIVE QUANTITY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button = DialogResult.Yes Then
                        'Do nothing and continue
                    ElseIf button = DialogResult.No Then
                        ShowReturnLineData()
                        Exit Sub
                    End If
                Else
                    'Do nothing and continue
                End If

                'Retrieve line data from Line Table
                Try
                    LinePrice = Me.dgvReturnLines.Rows(RowIndex).Cells("UnitPriceColumn").Value
                Catch ex As Exception
                    LinePrice = 0
                End Try
                Try
                    LineQuantity = Me.dgvReturnLines.Rows(RowIndex).Cells("QuantityColumn").Value
                Catch ex As Exception
                    LineQuantity = 0
                End Try
                Try
                    LineNumber = Me.dgvReturnLines.Rows(RowIndex).Cells("ReturnLineNumberColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try
                Try
                    LineTaxTotal = Me.dgvReturnLines.Rows(RowIndex).Cells("SalesTaxColumn").Value
                Catch ex As Exception
                    LineTaxTotal = 0
                End Try
                Try
                    LineExtendedAmount = Me.dgvReturnLines.Rows(RowIndex).Cells("ExtendedAmountColumn").Value
                Catch ex As Exception
                    LineExtendedAmount = 0
                End Try
                Try
                    LineDescription = Me.dgvReturnLines.Rows(RowIndex).Cells("DescriptionColumn").Value
                Catch ex As Exception
                    LineDescription = ""
                End Try
                Try
                    LineComment = Me.dgvReturnLines.Rows(RowIndex).Cells("LineCommentColumn").Value
                Catch ex As Exception
                    LineComment = ""
                End Try

                'Check to see if Sales Tax is on the return
                If LineTaxTotal <> 0 And LineExtendedAmount <> 0 And (cboDivisionID.Text <> "TOR" Or cboDivisionID.Text <> "TFF" Or cboDivisionID.Text <> "ALB") Then
                    LineTaxRate = LineTaxTotal / LineExtendedAmount
                Else
                    'No line Sales Tax
                    LineTaxRate = 0
                End If

                LineExtendedAmount = LineQuantity * LinePrice
                LineTaxTotal = LineExtendedAmount * LineTaxRate
                LineTaxTotal = Math.Round(LineTaxTotal, 2)
                LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                Try
                    'UPDATE Line Table based on line changes
                    cmd = New SqlCommand("UPDATE ReturnProductLineTable SET UnitPrice = @UnitPrice, Quantity = @Quantity, ExtendedAmount = @ExtendedAmount, SalesTax = @SalesTax, Description = @Description, LineComment = @LineComment WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                    With cmd.Parameters
                        .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                        .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = LineNumber
                        .Add("@UnitPrice", SqlDbType.VarChar).Value = LinePrice
                        .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@SalesTax", SqlDbType.VarChar).Value = LineTaxTotal
                        .Add("@Description", SqlDbType.VarChar).Value = LineDescription
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempReturnNumber As Integer = 0
                    Dim strReturnNumber As String
                    TempReturnNumber = Val(cboReturnNumber.Text)
                    strReturnNumber = CStr(TempReturnNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Return Product Form --- DGV Line Changes"
                    ErrorReferenceNumber = "Return # " + strReturnNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CalculateCanadianTaxes()
                    CalculateTotalsCanadian()
                Else
                    CalculateTotals()
                End If

                'Update Totals
                UpdateTotals()

                'Refresh datagrid
                ShowReturnLineData()
            End If
        End If
    End Sub

    'Validation / Error Checking / Misc.

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

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

    Private Function canAddLine() As Boolean
        If String.IsNullOrEmpty(cboReturnNumber.Text) Then
            MessageBox.Show("You must enter a return number", "Enter a return number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.Focus()
            Return False
        End If
        If cboReturnNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid return number", "Enter a return number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.SelectAll()
            cboReturnNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            LoadReturnHeaderData()
            ShowReturnLineData()
            Return False
        End If
        If String.IsNullOrEmpty(cboCustomerName.Text) Then
            MessageBox.Show("You must enter a customer ID", "Enter a customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerName.Focus()
            Return False
        End If
        If cboCustomerName.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid customer ID", "Enter a valid customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerName.SelectAll()
            cboCustomerName.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboReturnPartNumber.Text) Then
            MessageBox.Show("You must enter a part number", "Enter a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLinePartNumber.Focus()
            Return False
        End If
        If cboReturnPartNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid part number", "Enter a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLinePartNumber.SelectAll()
            cboLinePartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtReturnQuantity.Text) Then
            MessageBox.Show("You must enter a quantity", "Enter a quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReturnQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtReturnQuantity.Text) = False Then
            MessageBox.Show("You must enter a valid number", "Enter a quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReturnQuantity.SelectAll()
            txtReturnQuantity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtReturnPrice.Text) Then
            MessageBox.Show("You muste enter a unit price", "Enter a unit price", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReturnPrice.Focus()
            Return False
        End If
        If IsNumeric(txtReturnPrice.Text) = False Then
            MessageBox.Show("You must enter a valid unit price", "enter a unit price", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReturnPrice.SelectAll()
            txtReturnPrice.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtGLInventoryAccount.Text) Then
            MessageBox.Show("You must have an GL Inventory Account entered", "Enter a GL Inventory Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtGLInventoryAccount.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtSalesOffset.Text) Then
            MessageBox.Show("You must have a Sales Offset Account entered", "Enter a Sales Offset Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSalesOffset.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canSelectLinesFromPO() As Boolean
        If String.IsNullOrEmpty(cboReturnNumber.Text) Then
            MessageBox.Show("You must select a Return Number", "Select a Return Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.Focus()
            Return False
        End If
        If cboReturnNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Return Number", "Enter a valid Return Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.SelectAll()
            cboReturnNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            LoadReturnHeaderData()
            ShowReturnLineData()
            Exit Function
        End If
        If String.IsNullOrEmpty(cboSalesOrderNumber.Text) Then
            MessageBox.Show("Please select a sales order", "Select a SO Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSalesOrderNumber.Focus()
            Return False
        End If
        If cboSalesOrderNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid sales order", "Select a valid SO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSalesOrderNumber.SelectAll()
            cboSalesOrderNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM ReturnProductHeaderTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.GetValue(0)) Then
                personEditing = reader.GetValue(0)
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this batch. You are unable to make any changes.", "Unable to save/Post", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET Locked = @Locked WHERE ReturnNumber = @ReturnNumber", con)
        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = cboReturnNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET Locked = '' WHERE ReturnNumber = @ReturnNumber AND Locked = @Locked", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        Else
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub CheckNegatives()
        Dim CheckLineQuantity As Double = 0
        Dim CheckLinePrice As Double = 0

        CheckLineQuantity = Val(txtReturnQuantity.Text)
        CheckLinePrice = Val(txtReturnPrice.Text)

        If CheckLinePrice < 0 Then strCheckNegativePrice = "YES"
        If CheckLineQuantity < 0 Then strCheckNegativeQuantity = "YES"
    End Sub

    Private Sub chkAddLineTax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddLineTax.CheckedChanged
        If chkAddLineTax.Checked = True Then
            txtSalesTaxLineRate.Visible = True
            txtSalesTaxLineRate.Text = SalesTaxRate
        Else
            txtSalesTaxLineRate.Visible = False
        End If
    End Sub
End Class