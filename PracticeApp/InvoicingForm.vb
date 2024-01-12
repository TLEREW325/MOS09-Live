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
Imports WIA
Imports iTextSharp
Imports System.ComponentModel
Imports System.Net.Mail
Public Class InvoicingForm
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Dim CustomerNotes, EmailSent, LotPartNumber, CustomerID, CustomerPO, PaymentTerms, Comment, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry As String
    Dim GetSpecialType, LastLotLineNumber, NextLotLineNumber, BatchNumber, SalesOrderNumber, ShipmentNumber, InvoiceNumber As Integer
    Dim SUMExtendedCOS, LineExtendedAmount, LineSalesTax, Price, ProductTotal, BilledFreight, SalesTax, Discount, InvoiceTotal As Double
    Dim GetReceiver, DropShipPONumber, NextTransactionNumber, LastTransactionNumber As Integer
    Dim OldQuantityBilled, QuantityBilled, DiscountPercent, DiscountAmount, DiscountTaken As Double
    Dim FOB, CustomerClass, CheckInvoiceStatus, CustomerName, SpecialInstructions, InvoiceStatus, PRONumber, LineComment, ShipVia, ItemClass, GLInventoryAccount, GLAdjustmentAccount, GLSalesAccount, GLReturnsAccount, GLCOGSAccount, GLPurchasesAccount, GLSalesOffsetAccount, GLIssuesAccount As String
    Dim InvoiceEmail, InvoiceAddress1, InvoiceAddress2, InvoiceCity, InvoiceState, InvoiceZip, InvoiceCountry As String
    Dim CustomerTaxRate1, CustomerTaxRate2, CustomerTaxRate3 As Double

    'Variables for Canadian Data
    Dim HSTValue, GSTRate, PSTRate, HSTRate, GSTTotal, PSTTotal, HSTTotal, SalesTax2, SalesTax3 As Double
    Dim InvoiceDate As Date
    Dim SOGSTRate, SOPSTRate, SOHSTRate As Double
    Dim CheckShippingMethod As String = ""
    Dim ShippingMethod, ThirdPartyShipper As String
    Dim CheckPaymentTerms As Integer = 0
    Dim ShipDateFromShipment As String

    'Variable for third party billing
    Dim BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToName As String

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""
    Dim TodaysDate As Date = Now()

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10, cmd11 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim taxRemoved As Boolean = False

    Dim PTUpload As PickTicketScannerUploadAPI

    'Form Load

    Private Sub InvoicingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCurrentDivision()

        cboDivisionID.Enabled = False
        cboDivisionID.Text = GlobalARDivisionCode

        'Defaults for scanning
        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdUploadShowPickTicket.Visible = False
            cmdViewPickTicket.Visible = False
            ReUploadPickTicketToolStripMenuItem.Enabled = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
            ScanPickTicketToolStripMenuItem.Visible = True
        Else
            cmdRemoteScan.Visible = False
            cmdUploadShowPickTicket.Visible = True
            cmdViewPickTicket.Visible = False
            ScanPickTicketToolStripMenuItem.Visible = False
        End If

        'Set Canadian defaults
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            txtSalesTax2.Visible = True
            txtSalesTax3.Visible = True
            LabelHST.Visible = True
            LabelPST.Visible = True
            LabelSalesTax.Text = "GST"
            chkAddHST.Visible = True
            chkAddPST.Visible = True
            txtHSTRate.Visible = False
            txtGSTRate.Enabled = True
            txtPSTRate.Enabled = True
            txtHSTRate2.Enabled = True
            txtSalesTaxRate.Enabled = False
            dgvInvoiceLines.Columns("SalesTaxColumn").Visible = False
            AddTaxToInvoiceToolStripMenuItem.Enabled = False
        Else
            txtSalesTax2.Visible = False
            txtSalesTax3.Visible = False
            LabelHST.Visible = False
            LabelPST.Visible = False
            LabelSalesTax.Text = "Sales Tax"
            chkAddHST.Visible = False
            chkAddPST.Visible = False
            txtHSTRate.Visible = False
            txtGSTRate.Enabled = False
            txtPSTRate.Enabled = False
            txtHSTRate2.Enabled = False
            txtSalesTaxRate.Enabled = True
            dgvInvoiceLines.Columns("SalesTaxColumn").Visible = True
            AddTaxToInvoiceToolStripMenuItem.Enabled = True
        End If

        PTUpload = New PickTicketScannerUploadAPI(cmdUploadShowPickTicket, txtShipmentNumber, ReUploadPickTicketToolStripMenuItem, Me, AppendUploadedPickTicketToolStripMenuItem)

        If GlobalARBatchNumber > 1 Then
            cboBatchNumber.Text = GlobalARBatchNumber
            Try
                cboInvoiceNumber.SelectedIndex = 0
            Catch ex As Exception
                cboInvoiceNumber.SelectedIndex = -1
            End Try
        Else
            cboBatchNumber.SelectedIndex = -1
            cboInvoiceNumber.SelectedIndex = -1
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

    'Load Datagrids and controls with datasets

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID ORDER BY InvoiceHeaderKey, InvoiceLineKey ASC", con)
        cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceLineTable")
        dgvInvoiceLines.DataSource = ds.Tables("InvoiceLineTable")
        cboInvoiceLineNumber.DataSource = ds.Tables("InvoiceLineTable")
        cboLinePartNumber.DataSource = ds.Tables("InvoiceLineTable")
        cboLinePartDescription.DataSource = ds.Tables("InvoiceLineTable")
        con.Close()
    End Sub

    Public Sub LoadCustomerList()
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

    Public Sub LoadInvoiceNumber()
        cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID ORDER BY InvoiceNumber ASC", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalARBatchNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "InvoiceHeaderTable")
        cboInvoiceNumber.DataSource = ds4.Tables("InvoiceHeaderTable")
        con.Close()
        cboInvoiceNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadLotNumbersInGrid()
        cmd = New SqlCommand("SELECT * FROM InvoiceLotLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "InvoiceLotLineTable")
        dgvInvoiceLotNumbers.DataSource = ds5.Tables("InvoiceLotLineTable")
        con.Close()
    End Sub

    Public Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT BatchNumber FROM InvoiceProcessingBatchHeader WHERE DivisionID = @DivisionID AND BatchStatus = @BatchStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "InvoiceProcessingBatchHeader")
        cboBatchNumber.DataSource = ds6.Tables("InvoiceProcessingBatchHeader")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowSerialNumbers()
        cmd = New SqlCommand("SELECT * FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "InvoiceSerialLineTable")
        dgvInvoiceSerialLineTable.DataSource = ds7.Tables("InvoiceSerialLineTable")
        con.Close()
    End Sub

    Public Sub ClearSerialNumbers()
        dgvInvoiceSerialLineTable.DataSource = Nothing
    End Sub

    'Load Procedures

    Public Sub LoadInvoiceData()
        Dim T1, T2, T3 As Double
        Dim LoadBilledFreight As Double

        Dim InvoiceDateStatement As String = "SELECT InvoiceDate FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceDateCommand As New SqlCommand(InvoiceDateStatement, con)
        InvoiceDateCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesOrderNumberStatement As String = "SELECT SalesOrderNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SalesOrderNumberCommand As New SqlCommand(SalesOrderNumberStatement, con)
        SalesOrderNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesOrderNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)
        ShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        ShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerIDStatement As String = "SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim CustomerIDCommand As New SqlCommand(CustomerIDStatement, con)
        CustomerIDCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        CustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerPOStatement As String = "SELECT CustomerPO FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim CustomerPOCommand As New SqlCommand(CustomerPOStatement, con)
        CustomerPOCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        CustomerPOCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
        PaymentTermsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CommentStatement As String = "SELECT Comment FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim CommentCommand As New SqlCommand(CommentStatement, con)
        CommentCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        CommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ProductTotalStatement As String = "SELECT ProductTotal FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BilledFreightStatement As String = "SELECT BilledFreight FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim BilledFreightCommand As New SqlCommand(BilledFreightStatement, con)
        BilledFreightCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        BilledFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTaxStatement As String = "SELECT SalesTax FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SalesTaxCommand As New SqlCommand(SalesTaxStatement, con)
        SalesTaxCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTax2Statement As String = "SELECT SalesTax2 FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SalesTax2Command As New SqlCommand(SalesTax2Statement, con)
        SalesTax2Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesTax2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTax3Statement As String = "SELECT SalesTax3 FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SalesTax3Command As New SqlCommand(SalesTax3Statement, con)
        SalesTax3Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesTax3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DiscountStatement As String = "SELECT Discount FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim DiscountCommand As New SqlCommand(DiscountStatement, con)
        DiscountCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        DiscountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceTotalStatement As String = "SELECT InvoiceTotal FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceTotalCommand As New SqlCommand(InvoiceTotalStatement, con)
        InvoiceTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceStatusStatement As String = "SELECT InvoiceStatus FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceStatusCommand As New SqlCommand(InvoiceStatusStatement, con)
        InvoiceStatusCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipViaStatement As String = "SELECT ShipVia FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim ShipViaCommand As New SqlCommand(ShipViaStatement, con)
        ShipViaCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        ShipViaCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchNumberStatement As String = "SELECT BatchNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim BatchNumberCommand As New SqlCommand(BatchNumberStatement, con)
        BatchNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        BatchNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PRONumberStatement As String = "SELECT PRONumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim PRONumberCommand As New SqlCommand(PRONumberStatement, con)
        PRONumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        PRONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SpecialInstructionsStatement As String = "SELECT SpecialInstructions FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SpecialInstructionsCommand As New SqlCommand(SpecialInstructionsStatement, con)
        SpecialInstructionsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SpecialInstructionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DropShipPONumberStatement As String = "SELECT DropShipPONumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim DropShipPONumberCommand As New SqlCommand(DropShipPONumberStatement, con)
        DropShipPONumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        DropShipPONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceAddress1Statement As String = "SELECT BTAddress1 FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceAddress1Command As New SqlCommand(InvoiceAddress1Statement, con)
        InvoiceAddress1Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceAddress2Statement As String = "SELECT BTAddress2 FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceAddress2Command As New SqlCommand(InvoiceAddress2Statement, con)
        InvoiceAddress2Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceCityStatement As String = "SELECT BTCity FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceCityCommand As New SqlCommand(InvoiceCityStatement, con)
        InvoiceCityCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceStateStatement As String = "SELECT BTState FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceStateCommand As New SqlCommand(InvoiceStateStatement, con)
        InvoiceStateCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceZipStatement As String = "SELECT BTZip FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceZipCommand As New SqlCommand(InvoiceZipStatement, con)
        InvoiceZipCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceCountryStatement As String = "SELECT BTCountry FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceCountryCommand As New SqlCommand(InvoiceCountryStatement, con)
        InvoiceCountryCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerClassStatement As String = "SELECT CustomerClass FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim CustomerClassCommand As New SqlCommand(CustomerClassStatement, con)
        CustomerClassCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        CustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FOBStatement As String = "SELECT FOB FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim FOBCommand As New SqlCommand(FOBStatement, con)
        FOBCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        FOBCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ThirdPartyShipperStatement As String = "SELECT ThirdPartyShipper FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim ThirdPartyShipperCommand As New SqlCommand(ThirdPartyShipperStatement, con)
        ThirdPartyShipperCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        ThirdPartyShipperCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShippingMethodStatement As String = "SELECT ShippingMethod FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim ShippingMethodCommand As New SqlCommand(ShippingMethodStatement, con)
        ShippingMethodCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        ShippingMethodCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim EmailSentStatement As String = "SELECT EmailSent FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim EmailSentCommand As New SqlCommand(EmailSentStatement, con)
        EmailSentCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        EmailSentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InvoiceDate = CDate(InvoiceDateCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceDate = dtpInvoiceDate.Value
        End Try
        Try
            SalesOrderNumber = CInt(SalesOrderNumberCommand.ExecuteScalar)
        Catch ex As Exception
            SalesOrderNumber = 0
        End Try
        Try
            ShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
        Catch ex As Exception
            ShipmentNumber = 0
        End Try
        Try
            CustomerID = CStr(CustomerIDCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerID = ""
        End Try
        Try
            CustomerPO = CStr(CustomerPOCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerPO = ""
        End Try
        Try
            PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentTerms = "N30"
        End Try
        Try
            Comment = CStr(CommentCommand.ExecuteScalar)
        Catch ex As Exception
            Comment = ""
        End Try
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            LoadBilledFreight = CDbl(BilledFreightCommand.ExecuteScalar)
        Catch ex As Exception
            LoadBilledFreight = 0
        End Try
        Try
            SalesTax = CDbl(SalesTaxCommand.ExecuteScalar)
            T1 = SalesTax
        Catch ex As Exception
            SalesTax = 0
            T1 = SalesTax
        End Try
        Try
            SalesTax2 = CDbl(SalesTax2Command.ExecuteScalar)
            T2 = SalesTax2
        Catch ex As Exception
            SalesTax2 = 0
            T2 = SalesTax2
        End Try
        Try
            SalesTax3 = CDbl(SalesTax3Command.ExecuteScalar)
            T3 = SalesTax3
        Catch ex As Exception
            SalesTax3 = 0
            T3 = SalesTax3
        End Try
        Try
            Discount = CDbl(DiscountCommand.ExecuteScalar)
        Catch ex As Exception
            Discount = 0
        End Try
        Try
            InvoiceTotal = CDbl(InvoiceTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceTotal = 0
        End Try
        Try
            InvoiceStatus = CStr(InvoiceStatusCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceStatus = "OPEN"
        End Try
        Try
            ShipVia = CStr(ShipViaCommand.ExecuteScalar)
        Catch ex As Exception
            ShipVia = "DELIVERY"
        End Try
        Try
            BatchNumber = CInt(BatchNumberCommand.ExecuteScalar)
        Catch ex As Exception
            BatchNumber = Val(cboBatchNumber.Text)
        End Try
        Try
            PRONumber = CStr(PRONumberCommand.ExecuteScalar)
        Catch ex As Exception
            PRONumber = ""
        End Try
        Try
            SpecialInstructions = CStr(SpecialInstructionsCommand.ExecuteScalar)
        Catch ex As Exception
            SpecialInstructions = ""
        End Try
        Try
            DropShipPONumber = CInt(DropShipPONumberCommand.ExecuteScalar)
        Catch ex As Exception
            DropShipPONumber = 0
        End Try
        Try
            InvoiceAddress1 = CStr(InvoiceAddress1Command.ExecuteScalar)
        Catch ex As Exception
            InvoiceAddress1 = ""
        End Try
        Try
            InvoiceAddress2 = CStr(InvoiceAddress2Command.ExecuteScalar)
        Catch ex As Exception
            InvoiceAddress2 = ""
        End Try
        Try
            InvoiceCity = CStr(InvoiceCityCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceCity = ""
        End Try
        Try
            InvoiceState = CStr(InvoiceStateCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceState = ""
        End Try
        Try
            InvoiceZip = CStr(InvoiceZipCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceZip = ""
        End Try
        Try
            InvoiceCountry = CStr(InvoiceCountryCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceCountry = ""
        End Try
        Try
            CustomerClass = CStr(CustomerClassCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerClass = "STANDARD"
        End Try
        Try
            FOB = CStr(FOBCommand.ExecuteScalar)
        Catch ex As Exception
            FOB = ""
        End Try
        Try
            ThirdPartyShipper = CStr(ThirdPartyShipperCommand.ExecuteScalar)
        Catch ex As Exception
            ThirdPartyShipper = ""
        End Try
        Try
            ShippingMethod = CStr(ShippingMethodCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingMethod = ""
        End Try
        Try
            EmailSent = CStr(EmailSentCommand.ExecuteScalar)
        Catch ex As Exception
            EmailSent = ""
        End Try
        con.Close()

        LoadSOTaxRates()

        'Load defaults for Canada
        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And T2 <> 0 Then
            chkAddPST.Checked = True
        ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And T3 <> 0 Then
            chkAddHST.Checked = True
            txtHSTRate.Visible = True
            HSTRate = SOHSTRate
            HSTRate = Math.Round(HSTRate, 4)
            txtHSTRate.Text = HSTRate
        ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And T2 = 0 And T3 = 0 Then
            chkAddHST.Checked = False
            chkAddPST.Checked = False
            txtHSTRate.Visible = False
        Else
            'Do nothing
        End If

        'Load Tax from Invoice Table after check boxes are selected
        txtSalesTax.Text = FormatCurrency(T1, 2)
        txtSalesTax2.Text = FormatCurrency(T2, 2)
        txtSalesTax3.Text = FormatCurrency(T3, 2)

        txtSalesOrderNumber.Text = SalesOrderNumber
        txtShipmentNumber.Text = ShipmentNumber
        cboCustomerID.Text = CustomerID
        txtCustomerPONumber.Text = CustomerPO
        cboPaymentTerms.Text = PaymentTerms
        txtComment.Text = Comment
        txtProductSales.Text = FormatCurrency(ProductTotal, 2)
        txtFreightBilled.Text = FormatCurrency(LoadBilledFreight, 2)
        txtDiscount.Text = Discount
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        cboShipVia.Text = ShipVia
        cboBatchNumber.Text = BatchNumber
        txtProNumber.Text = PRONumber
        txtInvoiceStatus.Text = InvoiceStatus
        txtBTAddress1.Text = InvoiceAddress1
        txtBTAddress2.Text = InvoiceAddress2
        txtBTCity.Text = InvoiceCity
        txtBTCountry.Text = InvoiceCountry
        txtBTZip.Text = InvoiceZip
        cboBTState.Text = InvoiceState
        txtBilledFreight.Text = LoadBilledFreight
        txtSpecialInstructions.Text = SpecialInstructions
        cboShipMethod.Text = ShippingMethod
        txtThirdPartyShipper.Text = ThirdPartyShipper

        dtpInvoiceDate.Text = InvoiceDate

        If EmailSent = "" Then
            lblEmailSent.Text = ""
        Else
            lblEmailSent.Text = EmailSent
        End If

        If ShippingMethod = "THIRD PARTY" Then
            txtThirdPartyShipper.Enabled = True
        Else
            txtThirdPartyShipper.Enabled = False
        End If

        If InvoiceStatus = "CLOSED" Then
            cmdAddDiscount.Enabled = False
            cmdDelete.Enabled = False
            cmdDeleteDiscount.Enabled = False
            cmdSave.Enabled = False
            SaveInvoiceToolStripMenuItem.Enabled = False
            DeleteInvoiceToolStripMenuItem.Enabled = False
        Else
            cmdAddDiscount.Enabled = True
            cmdDelete.Enabled = True
            cmdDeleteDiscount.Enabled = True
            cmdSave.Enabled = True
            SaveInvoiceToolStripMenuItem.Enabled = True
            DeleteInvoiceToolStripMenuItem.Enabled = True
        End If

        LoadShippingDate()
    End Sub

    Public Sub LoadCustomerData()
        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
        PaymentTermsCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerNameCommand As New SqlCommand(CustomerNameStatement, con)
        CustomerNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim InvoiceEmailCommand As New SqlCommand(InvoiceEmailStatement, con)
        InvoiceEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        InvoiceEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerNotesStatement As String = "SELECT Comments FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerNotesCommand As New SqlCommand(CustomerNotesStatement, con)
        CustomerNotesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerNotesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentTerms = ""
        End Try
        Try
            CustomerName = CStr(CustomerNameCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerName = ""
        End Try
        Try
            InvoiceEmail = CStr(InvoiceEmailCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceEmail = ""
        End Try
        Try
            CustomerNotes = CStr(CustomerNotesCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerNotes = ""
        End Try
        con.Close()

        cboPaymentTerms.Text = PaymentTerms
        txtCustomerName.Text = CustomerName
        txtCustomerNotes.Text = CustomerNotes

        If InvoiceEmail <> "" Then
            lblEmailInvoice.Text = "***Email Invoice***"
        Else
            lblEmailInvoice.Text = ""
        End If
    End Sub

    Public Sub LoadShippingDate()
        Dim LoadQuotedFreight As Double = 0

        Dim ShipDateFromShipmentStatement As String = "SELECT ShipDate FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipDateFromShipmentCommand As New SqlCommand(ShipDateFromShipmentStatement, con)
        ShipDateFromShipmentCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        ShipDateFromShipmentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim QuotedFreightStatement As String = "SELECT FreightQuoteAmount FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim QuotedFreightCommand As New SqlCommand(QuotedFreightStatement, con)
        QuotedFreightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        QuotedFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipDateFromShipment = CStr(ShipDateFromShipmentCommand.ExecuteScalar)
        Catch ex As Exception
            ShipDateFromShipment = ""
        End Try
        Try
            LoadQuotedFreight = CDbl(QuotedFreightCommand.ExecuteScalar)
        Catch ex As Exception
            LoadQuotedFreight = 0
        End Try
        con.Close()

        lblShipDate.Text = ShipDateFromShipment
        txtQuotedFreight.Text = LoadQuotedFreight
    End Sub

    Public Sub LoadItemClassForPartNumber()
        Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
        ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboLinePartNumber.Text
        ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ItemClass = CStr(ItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            ItemClass = ""
        End Try
        con.Close()

        cboItemClass.Text = ItemClass
    End Sub

    Public Sub LoadInvoiceLineDetails()
        Dim QuantityBilledStatement As String = "SELECT QuantityBilled FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
        Dim QuantityBilledCommand As New SqlCommand(QuantityBilledStatement, con)
        QuantityBilledCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        QuantityBilledCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = Val(cboInvoiceLineNumber.Text)

        Dim PriceStatement As String = "SELECT Price FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
        Dim PriceCommand As New SqlCommand(PriceStatement, con)
        PriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        PriceCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = Val(cboInvoiceLineNumber.Text)

        Dim LineCommentStatement As String = "SELECT LineComment FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
        Dim LineCommentCommand As New SqlCommand(LineCommentStatement, con)
        LineCommentCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        LineCommentCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = Val(cboInvoiceLineNumber.Text)

        Dim SalesTaxStatement As String = "SELECT SalesTax FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
        Dim SalesTaxCommand As New SqlCommand(SalesTaxStatement, con)
        SalesTaxCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesTaxCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = Val(cboInvoiceLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantityBilled = CDbl(QuantityBilledCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityBilled = Val(txtLineQuantityBilled.Text)
        End Try
        Try
            Price = CDbl(PriceCommand.ExecuteScalar)
        Catch ex As Exception
            Price = Val(txtLinePrice.Text)
        End Try
        Try
            LineComment = CStr(LineCommentCommand.ExecuteScalar)
        Catch ex As Exception
            LineComment = ""
        End Try
        Try
            LineSalesTax = CDbl(SalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            LineSalesTax = Val(txtLineSalesTax.Text)
        End Try
        con.Close()

        LineExtendedAmount = QuantityBilled * Price
        txtLineComment.Text = LineComment
        txtLineExtendedAmount.Text = LineExtendedAmount
        txtLinePrice.Text = Price
        txtLineQuantityBilled.Text = QuantityBilled
        txtLineSalesTax.Text = LineSalesTax
    End Sub

    Public Sub LoadGLAccounts()
        Dim GLSalesAccountStatement As String = "SELECT GLSalesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLSalesAccountCommand As New SqlCommand(GLSalesAccountStatement, con)
        GLSalesAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        Dim GLReturnsAccountStatement As String = "SELECT GLReturnsAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLReturnsAccountCommand As New SqlCommand(GLReturnsAccountStatement, con)
        GLReturnsAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        Dim GLInventoryAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLInventoryAccountCommand As New SqlCommand(GLInventoryAccountStatement, con)
        GLInventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        Dim GLCOGSAccountStatement As String = "SELECT GLCOGSAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLCOGSAccountCommand As New SqlCommand(GLCOGSAccountStatement, con)
        GLCOGSAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        Dim GLPurchasesAccountStatement As String = "SELECT GLPurchasesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLPurchasesAccountCommand As New SqlCommand(GLPurchasesAccountStatement, con)
        GLPurchasesAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        Dim GLSalesOffsetAccountStatement As String = "SELECT GLSalesOffsetAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLSalesOffsetAccountCommand As New SqlCommand(GLSalesOffsetAccountStatement, con)
        GLSalesOffsetAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        Dim GLAdjustmentAccountStatement As String = "SELECT GLAdjustmentAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLAdjustmentAccountCommand As New SqlCommand(GLAdjustmentAccountStatement, con)
        GLAdjustmentAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        Dim GLIssuesAccountStatement As String = "SELECT GLIssuesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLIssuesAccountCommand As New SqlCommand(GLIssuesAccountStatement, con)
        GLIssuesAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GLSalesAccount = CStr(GLSalesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLSalesAccount = ""
        End Try
        Try
            GLReturnsAccount = CStr(GLReturnsAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLReturnsAccount = ""
        End Try
        Try
            GLInventoryAccount = CStr(GLInventoryAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLInventoryAccount = ""
        End Try
        Try
            GLCOGSAccount = CStr(GLCOGSAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLCOGSAccount = ""
        End Try
        Try
            GLPurchasesAccount = CStr(GLPurchasesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLPurchasesAccount = ""
        End Try
        Try
            GLSalesOffsetAccount = CStr(GLSalesOffsetAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLSalesOffsetAccount = ""
        End Try
        Try
            GLAdjustmentAccount = CStr(GLAdjustmentAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLAdjustmentAccount = ""
        End Try
        Try
            GLIssuesAccount = CStr(GLIssuesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLIssuesAccount = ""
        End Try
        con.Close()

        txtGLAdjustmentAccount.Text = GLAdjustmentAccount
        txtGLInventoryAccount.Text = GLInventoryAccount
        txtGLIssuesAccount.Text = GLIssuesAccount
        txtGLPurchasesAccount.Text = GLPurchasesAccount
        txtGLReturnsAccount.Text = GLReturnsAccount
        txtGLSalesAccount.Text = GLSalesAccount
        txtGLSalesOffsetAccount.Text = GLSalesOffsetAccount
        txtGLCOGSAccount.Text = GLCOGSAccount
    End Sub

    Public Sub LoadInvoiceTotals()
        Dim SUMTaxStatement As String = "SELECT SUM(SalesTax) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SUMTaxCommand As New SqlCommand(SUMTaxStatement, con)
        SUMTaxCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SUMTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SUMExtendedStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SUMExtendedCommand As New SqlCommand(SUMExtendedStatement, con)
        SUMExtendedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SUMExtendedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SUMExtendedCOSStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SUMExtendedCOSCommand As New SqlCommand(SUMExtendedCOSStatement, con)
        SUMExtendedCOSCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SUMExtendedCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SalesTax = CDbl(SUMTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SalesTax = 0
        End Try
        Try
            ProductTotal = CDbl(SUMExtendedCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            SUMExtendedCOS = CDbl(SUMExtendedCOSCommand.ExecuteScalar)
        Catch ex As Exception
            SUMExtendedCOS = 0
        End Try
        con.Close()

        BilledFreight = Val(txtBilledFreight.Text)

        InvoiceTotal = SalesTax + ProductTotal + BilledFreight

        txtProductSales.Text = FormatCurrency(ProductTotal, 2)
        txtSalesTax.Text = FormatCurrency(SalesTax, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtFreightBilled.Text = FormatCurrency(BilledFreight, 2)
        SalesTax2 = 0
        SalesTax3 = 0
    End Sub

    Public Sub CalculateCanadianTotals()
        Dim CustomerHSTRate, CustomerPSTRate, CustomerGSTRate As Double

        Dim SOHSTRateStatement As String = "SELECT TaxRate3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOHSTRateCommand As New SqlCommand(SOHSTRateStatement, con)
        SOHSTRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOHSTRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SOGSTRateStatement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOGSTRateCommand As New SqlCommand(SOGSTRateStatement, con)
        SOGSTRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOGSTRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SOPSTRateStatement As String = "SELECT TaxRate2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOPSTRateCommand As New SqlCommand(SOPSTRateStatement, con)
        SOPSTRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOPSTRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SOHSTRate = CDbl(SOHSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            SOHSTRate = 0
        End Try
        Try
            SOGSTRate = CDbl(SOGSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            SOGSTRate = 0
        End Try
        Try
            SOPSTRate = CDbl(SOPSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            SOPSTRate = 0
        End Try
        con.Close()

        If SOHSTRate = 0 Then
            Dim CustomerHSTRateStatement As String = "SELECT SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerHSTRateCommand As New SqlCommand(CustomerHSTRateStatement, con)
            CustomerHSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerHSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerHSTRate = CDbl(CustomerHSTRateCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerHSTRate = 0
            End Try
            con.Close()

            SOHSTRate = CustomerHSTRate
        End If

        If SOPSTRate = 0 Then
            Dim CustomerPSTRateStatement As String = "SELECT SalesTaxRate2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerPSTRateCommand As New SqlCommand(CustomerPSTRateStatement, con)
            CustomerPSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerPSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerPSTRate = CDbl(CustomerPSTRateCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerPSTRate = 0
            End Try
            con.Close()

            SOPSTRate = CustomerPSTRate
        End If

        If SOGSTRate = 0 Then
            Dim CustomerGSTRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerGSTRateCommand As New SqlCommand(CustomerGSTRateStatement, con)
            CustomerGSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerGSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerGSTRate = CDbl(CustomerGSTRateCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerGSTRate = 0
            End Try
            con.Close()

            SOGSTRate = CustomerGSTRate
        End If

        Dim SUMExtendedStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SUMExtendedCommand As New SqlCommand(SUMExtendedStatement, con)
        SUMExtendedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SUMExtendedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SUMExtendedCOSStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SUMExtendedCOSCommand As New SqlCommand(SUMExtendedCOSStatement, con)
        SUMExtendedCOSCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SUMExtendedCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMExtendedCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            SUMExtendedCOS = CDbl(SUMExtendedCOSCommand.ExecuteScalar)
        Catch ex As Exception
            SUMExtendedCOS = 0
        End Try
        con.Close()

        If SOHSTRate = 0 And txtHSTRate.Text = "" Then
            HSTRate = 0
        ElseIf SOHSTRate <> 0 And txtHSTRate.Text = "" Then
            HSTRate = SOHSTRate
            HSTRate = Math.Round(HSTRate, 4)
            txtHSTRate.Text = HSTRate
        Else
            HSTRate = Val(txtHSTRate.Text)
        End If

        BilledFreight = Val(txtBilledFreight.Text)

        If chkAddHST.Checked = True Then
            GSTTotal = 0
            PSTTotal = 0
            HSTTotal = HSTRate * (ProductTotal + BilledFreight)
        ElseIf chkAddPST.Checked = True Then
            GSTTotal = SOGSTRate * (ProductTotal + BilledFreight)
            PSTTotal = SOPSTRate * (ProductTotal + BilledFreight)
            HSTTotal = 0
        Else
            GSTTotal = SOGSTRate * (ProductTotal + BilledFreight)
            PSTTotal = 0
            HSTTotal = 0
        End If

        GSTTotal = Math.Round(GSTTotal, 2)
        PSTTotal = Math.Round(PSTTotal, 2)
        HSTTotal = Math.Round(HSTTotal, 2)

        SalesTax = GSTTotal
        SalesTax2 = PSTTotal
        SalesTax3 = HSTTotal

        InvoiceTotal = BilledFreight + GSTTotal + PSTTotal + HSTTotal + ProductTotal

        txtSalesTax.Text = FormatCurrency(GSTTotal, 2)
        txtSalesTax2.Text = FormatCurrency(PSTTotal, 2)
        txtSalesTax3.Text = FormatCurrency(HSTTotal, 2)
        txtFreightBilled.Text = FormatCurrency(BilledFreight, 2)
        txtProductSales.Text = FormatCurrency(ProductTotal, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Public Sub LoadCustomerEmail()
        Dim InvoiceEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim InvoiceEmailCommand As New SqlCommand(InvoiceEmailStatement, con)
        InvoiceEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        InvoiceEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InvoiceEmail = CStr(InvoiceEmailCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceEmail = ""
        End Try
        con.Close()

        EmailCustomerEmailAddress = InvoiceEmail

        If InvoiceEmail <> "" Then
            lblEmailInvoice.Text = "***Email Invoice***"
        Else
            lblEmailInvoice.Text = ""
        End If
    End Sub

    Public Sub LoadSOTaxRates()
        Dim SOHSTRateStatement As String = "SELECT TaxRate3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOHSTRateCommand As New SqlCommand(SOHSTRateStatement, con)
        SOHSTRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOHSTRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SOGSTRateStatement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOGSTRateCommand As New SqlCommand(SOGSTRateStatement, con)
        SOGSTRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOGSTRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SOPSTRateStatement As String = "SELECT TaxRate2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOPSTRateCommand As New SqlCommand(SOPSTRateStatement, con)
        SOPSTRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOPSTRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SOHSTRate = CDbl(SOHSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            SOHSTRate = 0
        End Try
        Try
            SOGSTRate = CDbl(SOGSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            SOGSTRate = 0
        End Try
        Try
            SOPSTRate = CDbl(SOPSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            SOPSTRate = 0
        End Try
        con.Close()
    End Sub

    Public Sub LoadCustomerTaxRates()
        Dim CustomerTaxRate1Statement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerTaxRate1Command As New SqlCommand(CustomerTaxRate1Statement, con)
        CustomerTaxRate1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerTaxRate1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerTaxRate2Statement As String = "SELECT SalesTaxRate2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerTaxRate2Command As New SqlCommand(CustomerTaxRate2Statement, con)
        CustomerTaxRate2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerTaxRate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerTaxRate3Statement As String = "SELECT SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerTaxRate3Command As New SqlCommand(CustomerTaxRate3Statement, con)
        CustomerTaxRate3Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerTaxRate3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerTaxRate1 = CDbl(CustomerTaxRate1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerTaxRate1 = 0
        End Try
        Try
            CustomerTaxRate2 = CDbl(CustomerTaxRate2Command.ExecuteScalar)
        Catch ex As Exception
            CustomerTaxRate2 = 0
        End Try
        Try
            CustomerTaxRate3 = CDbl(CustomerTaxRate3Command.ExecuteScalar)
        Catch ex As Exception
            CustomerTaxRate3 = 0
        End Try
        con.Close()
    End Sub

    Public Sub LoadCanadianTaxRates()
        chkAddHST.Checked = False
        chkAddPST.Checked = False

        Dim SOHSTRateStatement As String = "SELECT TaxRate3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOHSTRateCommand As New SqlCommand(SOHSTRateStatement, con)
        SOHSTRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOHSTRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SOGSTRateStatement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOGSTRateCommand As New SqlCommand(SOGSTRateStatement, con)
        SOGSTRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOGSTRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SOPSTRateStatement As String = "SELECT TaxRate2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOPSTRateCommand As New SqlCommand(SOPSTRateStatement, con)
        SOPSTRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SOPSTRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SOHSTRate = CDbl(SOHSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            SOHSTRate = 0
        End Try
        Try
            SOGSTRate = CDbl(SOGSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            SOGSTRate = 0
        End Try
        Try
            SOPSTRate = CDbl(SOPSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            SOPSTRate = 0
        End Try
        con.Close()

        If SOHSTRate > 0 Then chkAddHST.Checked = True
        If SOPSTRate > 0 Then chkAddPST.Checked = True
    End Sub

    Public Sub GetThirdPartyBillingData()
        Dim BillToNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToNameCommand As New SqlCommand(BillToNameStatement, con)
        BillToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
        BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
        BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
        BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
        BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
        BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BillToName = CStr(BillToNameCommand.ExecuteScalar)
        Catch ex As Exception
            BillToName = ""
        End Try
        Try
            BillToAddress1 = CStr(BillToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            BillToAddress1 = ""
        End Try
        Try
            BillToAddress2 = CStr(BillToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            BillToAddress2 = ""
        End Try
        Try
            BillToCity = CStr(BillToCityCommand.ExecuteScalar)
        Catch ex As Exception
            BillToCity = ""
        End Try
        Try
            BillToState = CStr(BillToStateCommand.ExecuteScalar)
        Catch ex As Exception
            BillToState = ""
        End Try
        Try
            BillToZip = CStr(BillToZipCommand.ExecuteScalar)
        Catch ex As Exception
            BillToZip = ""
        End Try
        con.Close()

        txtThirdPartyShipper.Text = BillToName + Environment.NewLine + BillToAddress1 + Environment.NewLine + BillToAddress2 + Environment.NewLine + BillToCity + ", " + BillToState + "  " + BillToZip
    End Sub

    Public Sub LoadTaxExemptCert()
        If cboCustomerID.Text = "" Then
            'Do nothing
        Else
            Dim TaxCertDivision As String = ""
            Dim TaxCertCustomerID As String = ""
            Dim TaxCertFileName As String = ""
            Dim TaxCertFilenameAndPath As String = ""

            TaxCertDivision = cboDivisionID.Text
            TaxCertCustomerID = cboCustomerID.Text
            TaxCertFileName = TaxCertCustomerID + ".pdf"
            TaxCertFilenameAndPath = "\\TFP-FS\TrufitCustomerDataPublic\Customer Sales Tax Exemption Cert" + "\" + TaxCertDivision + "\" + TaxCertFileName
            GlobalTaxExemptCert = TaxCertFilenameAndPath

            If File.Exists(TaxCertFilenameAndPath) Then
                LabelSalesTax.ForeColor = Color.Red
            Else
                LabelSalesTax.ForeColor = Color.Black
            End If
        End If
    End Sub

    Public Sub LoadUploadedPickTicket()
        If txtShipmentNumber.Text <> "" Then
            Dim UploadedShipmentNumber As String = ""
            Dim UploadedFileName As String = ""
            Dim UploadedFilenameAndPath As String = ""

            UploadedShipmentNumber = txtShipmentNumber.Text

            UploadedFileName = UploadedShipmentNumber + ".pdf"
            UploadedFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets" + "\" + UploadedFileName

            If My.Computer.Name.StartsWith("TFP") Then
                If File.Exists(UploadedFilenameAndPath) Then
                    cmdViewPickTicket.Visible = True
                    cmdUploadShowPickTicket.Visible = False
                    cmdRemoteScan.Visible = False
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                    ReUploadPickTicketToolStripMenuItem.Enabled = False
                    ScanPickTicketToolStripMenuItem.Visible = True
                Else
                    cmdViewPickTicket.Visible = False
                    cmdUploadShowPickTicket.Visible = False
                    cmdRemoteScan.Visible = True
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                    ReUploadPickTicketToolStripMenuItem.Enabled = False
                    ScanPickTicketToolStripMenuItem.Visible = True
                End If
            Else
                If File.Exists(UploadedFilenameAndPath) Then
                    cmdViewPickTicket.Visible = True
                    cmdUploadShowPickTicket.Visible = False
                    cmdRemoteScan.Visible = False
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = True
                    ReUploadPickTicketToolStripMenuItem.Enabled = True
                    ScanPickTicketToolStripMenuItem.Visible = False
                Else
                    cmdViewPickTicket.Visible = False
                    cmdUploadShowPickTicket.Visible = True
                    cmdRemoteScan.Visible = False
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = True
                    ReUploadPickTicketToolStripMenuItem.Enabled = True
                    ScanPickTicketToolStripMenuItem.Visible = False
                End If
            End If
        Else
            'Do nothing
        End If
    End Sub

    'Database Update/Insert/Delete

    Public Sub SaveUpdateInvoiceHeaderTable()
        'Save changes to Invoice Table
        cmd = New SqlCommand("Update InvoiceHeaderTable SET InvoiceDate = @InvoiceDate, CustomerPO = @CustomerPO, PaymentTerms = @PaymentTerms, Comment = @Comment, BTAddress1 = @btAddress1, BTAddress2 = @BTAddress2, BTCity = @BTCity, BTState = @BTState, BTZip = @BTZip, BTCountry = @BTCountry, ProductTotal = @ProductTotal, BilledFreight = @BilledFreight, SalesTax = @SalesTax, Discount = @Discount, InvoiceTotal = @InvoiceTotal, InvoiceStatus = @InvoiceStatus, ShipVia = @ShipVia, PaymentsApplied = @PaymentsApplied, InvoiceCOS = @InvoiceCOS, PRONumber = @PRONumber, SpecialInstructions = @SpecialInstructions, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3, ReprintBatch = @ReprintBatch, CustomerClass = @CustomerClass, FOB = @FOB, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE InvoiceNumber = @InvoiceNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@BTAddress1", SqlDbType.VarChar).Value = txtBTAddress1.Text
            .Add("@BTAddress2", SqlDbType.VarChar).Value = txtBTAddress2.Text
            .Add("@BTCity", SqlDbType.VarChar).Value = txtBTCity.Text
            .Add("@BTState", SqlDbType.VarChar).Value = cboBTState.Text
            .Add("@BTZip", SqlDbType.VarChar).Value = txtBTZip.Text
            .Add("@BTCountry", SqlDbType.VarChar).Value = txtBTCountry.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
            .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
            .Add("@Discount", SqlDbType.VarChar).Value = DiscountAmount
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            .Add("@InvoiceStatus", SqlDbType.VarChar).Value = txtInvoiceStatus.Text
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceCOS", SqlDbType.VarChar).Value = SUMExtendedCOS
            .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
            '.Add("@DropShipPONumber", SqlDbType.VarChar).Value = DropShipPONumber
            .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
            .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
            .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
            .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
            .Add("@FOB", SqlDbType.VarChar).Value = FOB
            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Validation and Error Checking

    Public Sub ValidatePaymentTerms()
        If cboPaymentTerms.Text = "Prepaid" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "NetDue" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "COD" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N30" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "CREDIT CARD" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N60" And cboDivisionID.Text = "TFP" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N60" And cboDivisionID.Text = "TWD" And cboCustomerID.Text = "DAVIDEISENMA" Then
            CheckPaymentTerms = 1
        Else
            CheckPaymentTerms = 0
        End If
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 399 Then
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

    Public Sub ValidateShippingMethod()
        ShippingMethod = cboShipMethod.Text

        Select Case ShippingMethod
            Case "COLLECT"
                'Do nothing
            Case "PREPAID"
                'Do nothing
            Case "PREPAID/NOADD"
                'Do nothing
            Case "PREPAID/ADD"
                If Val(txtBilledFreight.Text) = 0 Then
                    MsgBox("You must enter billed freight for this order.", MsgBoxStyle.OkOnly)
                    CheckShippingMethod = "EXIT SUB"
                    Exit Sub
                End If
            Case "THIRD PARTY"
                If txtThirdPartyShipper.Text = "" Then
                    MsgBox("You must fill-in third party shipping info", MsgBoxStyle.OkOnly)
                    CheckShippingMethod = "EXIT SUB"
                    txtThirdPartyShipper.Focus()
                    Exit Sub
                End If
            Case "OTHER"
                'Do nothing
            Case Else
                MsgBox("You must select a valid Shipping Method", MsgBoxStyle.OkOnly)
                CheckShippingMethod = "EXIT SUB"
                cboShipMethod.Focus()
                Exit Sub
        End Select
    End Sub

    Public Sub ClearData()
        cboBTState.Refresh()
        cboInvoiceNumber.Refresh()
        txtSalesOrderNumber.Refresh()
        cboCustomerID.Refresh()
        cboPaymentTerms.Refresh()
        cboShipVia.Refresh()
        cboLinePartNumber.Refresh()
        cboLinePartDescription.Refresh()
        cboItemClass.Refresh()
        cboShipMethod.Refresh()

        txtDiscountAmount.Refresh()
        txtDiscountPercent.Refresh()
        txtBilledFreight.Refresh()
        txtBTAddress1.Refresh()
        txtBTAddress2.Refresh()
        txtBTCity.Refresh()
        txtBTCountry.Refresh()
        txtBTZip.Refresh()
        txtComment.Refresh()
        txtDiscount.Refresh()
        txtFreightBilled.Refresh()
        txtInvoiceTotal.Refresh()
        txtProductSales.Refresh()
        txtSalesTax.Refresh()
        txtProNumber.Refresh()
        txtCustomerPONumber.Refresh()
        txtGLAdjustmentAccount.Refresh()
        txtGLCOGSAccount.Refresh()
        txtGLInventoryAccount.Refresh()
        txtGLIssuesAccount.Refresh()
        txtGLPurchasesAccount.Refresh()
        txtGLReturnsAccount.Refresh()
        txtGLSalesAccount.Refresh()
        txtGLSalesOffsetAccount.Refresh()
        txtLineComment.Refresh()
        txtLineExtendedAmount.Refresh()
        txtLinePrice.Refresh()
        txtLineQuantityBilled.Refresh()
        txtLineSalesTax.Refresh()
        txtInvoiceStatus.Refresh()
        txtCustomerName.Refresh()
        txtSpecialInstructions.Refresh()
        txtThirdPartyShipper.Refresh()
        txtShipmentNumber.Refresh()
        txtCustomerNotes.Refresh()

        cboBTState.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboLinePartNumber.SelectedIndex = -1
        cboLinePartDescription.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1

        cboBTState.Text = ""
        cboInvoiceNumber.Text = ""
        cboCustomerID.Text = ""
        cboPaymentTerms.Text = ""
        cboShipVia.Text = ""
        cboLinePartNumber.Text = ""
        cboLinePartDescription.Text = ""
        cboItemClass.Text = ""
        cboShipMethod.Text = ""

        txtDiscountAmount.Clear()
        txtDiscountPercent.Clear()
        txtBilledFreight.Clear()
        txtBTAddress1.Clear()
        txtBTAddress2.Clear()
        txtBTCity.Clear()
        txtBTCountry.Clear()
        txtBTZip.Clear()
        txtComment.Clear()
        txtDiscount.Clear()
        txtFreightBilled.Clear()
        txtInvoiceTotal.Clear()
        txtProductSales.Clear()
        txtSalesTax.Clear()
        txtProNumber.Clear()
        txtCustomerPONumber.Clear()
        txtGLAdjustmentAccount.Clear()
        txtGLCOGSAccount.Clear()
        txtGLInventoryAccount.Clear()
        txtGLIssuesAccount.Clear()
        txtGLPurchasesAccount.Clear()
        txtGLReturnsAccount.Clear()
        txtGLSalesAccount.Clear()
        txtGLSalesOffsetAccount.Clear()
        txtLineComment.Clear()
        txtLineExtendedAmount.Clear()
        txtLinePrice.Clear()
        txtLineQuantityBilled.Clear()
        txtLineSalesTax.Clear()
        txtInvoiceStatus.Clear()
        txtCustomerName.Clear()
        txtSalesOrderNumber.Clear()
        txtSpecialInstructions.Clear()
        txtThirdPartyShipper.Clear()
        txtShipmentNumber.Clear()
        txtQuotedFreight.Clear()
        txtCustomerNotes.Clear()

        dtpInvoiceDate.Text = ""
        lblShipDate.Text = ""
        lblEmailInvoice.Text = ""
        lblEmailSent.Text = ""
        LabelSalesTax.ForeColor = Color.Black

        If My.Computer.Name.StartsWith("TFP") Then
            cmdViewPickTicket.Visible = False
            cmdUploadShowPickTicket.Visible = False
            cmdRemoteScan.Visible = True
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
            ReUploadPickTicketToolStripMenuItem.Enabled = False
            ScanPickTicketToolStripMenuItem.Visible = True
        Else
            cmdViewPickTicket.Visible = False
            cmdUploadShowPickTicket.Visible = True
            cmdRemoteScan.Visible = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = True
            ReUploadPickTicketToolStripMenuItem.Enabled = True
            ScanPickTicketToolStripMenuItem.Visible = False
        End If

        ClearSerialNumbers()
        cboInvoiceNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        CheckPaymentTerms = 0
        BillToAddress1 = ""
        BillToAddress2 = ""
        BillToCity = ""
        BillToState = ""
        BillToZip = ""
        BillToName = ""
        ThirdPartyShipper = ""
        CheckShippingMethod = ""
        ShippingMethod = ""
        LotPartNumber = ""
        CustomerID = ""
        CustomerPO = ""
        PaymentTerms = ""
        Comment = ""
        BTAddress1 = ""
        BTAddress2 = ""
        BTCity = ""
        BTState = ""
        BTZip = ""
        BTCountry = ""
        QuantityBilled = 0
        LastLotLineNumber = 0
        NextLotLineNumber = 0
        SalesOrderNumber = 0
        ShipmentNumber = 0
        InvoiceNumber = 0
        LineExtendedAmount = 0
        LineSalesTax = 0
        Price = 0
        ProductTotal = 0
        BilledFreight = 0
        SalesTax = 0
        Discount = 0
        InvoiceTotal = 0
        NextTransactionNumber = 0
        LastTransactionNumber = 0
        DiscountPercent = 0
        DiscountAmount = 0
        DiscountTaken = 0
        PRONumber = ""
        LineComment = ""
        ShipVia = ""
        ItemClass = ""
        GLInventoryAccount = ""
        GLAdjustmentAccount = ""
        GLSalesAccount = ""
        GLReturnsAccount = ""
        GLCOGSAccount = ""
        GLPurchasesAccount = ""
        GLSalesOffsetAccount = ""
        GLIssuesAccount = ""
        InvoiceStatus = ""
        SpecialInstructions = ""
        DropShipPONumber = 0
        OldQuantityBilled = 0
        SUMExtendedCOS = 0
        CustomerName = ""
        InvoiceAddress1 = ""
        InvoiceAddress2 = ""
        InvoiceCity = ""
        InvoiceState = ""
        InvoiceZip = ""
        InvoiceCountry = ""
        GetSpecialType = 0
        GetReceiver = 0
        CheckInvoiceStatus = ""
        CustomerClass = ""
        FOB = ""
        GSTRate = 0
        PSTRate = 0
        HSTRate = 0
        GSTTotal = 0
        PSTTotal = 0
        HSTTotal = 0
        SalesTax2 = 0
        SalesTax3 = 0
        HSTValue = 0
        InvoiceEmail = ""
        SOGSTRate = 0
        SOPSTRate = 0
        SOHSTRate = 0
        EmailSent = ""
        CustomerNotes = ""

    End Sub

    'Command Buttons

    Private Sub cmdAddDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddDiscount.Click
        'Pulls current totals from database
        LoadInvoiceTotals()

        If txtDiscountAmount.Text <> "" And txtDiscountPercent.Text <> "" Then
            MsgBox("You must select only one discount method.", MsgBoxStyle.OkOnly)
        Else
            'Calculates discount
            If DiscountPercent > 0 Then
                DiscountTaken = DiscountPercent * ProductTotal
                txtDiscount.Text = DiscountTaken
            ElseIf DiscountPercent = 0 And DiscountAmount > 0 Then
                DiscountTaken = DiscountAmount
                txtDiscount.Text = DiscountTaken
            End If
            'Re-calculates the totals
            InvoiceTotal = ProductTotal + SalesTax + BilledFreight - DiscountTaken
            txtInvoiceTotal.Text = InvoiceTotal
        End If

        txtDiscountAmount.Clear()
        txtDiscountPercent.Clear()
    End Sub

    Private Sub cmdDeleteDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteDiscount.Click
        txtDiscount.Text = 0
        DiscountTaken = 0
        'Re-calculates the totals
        InvoiceTotal = ProductTotal + SalesTax + BilledFreight - DiscountTaken
        txtInvoiceTotal.Text = InvoiceTotal
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Invoice Number selected.", MsgBoxStyle.OkOnly)
        Else
            '*********************************************************************************
            'Check to see if it is some elses batch
            Dim CheckBatchUserID As String = ""

            Dim CheckBatchUserIDStatement As String = "SELECT Locked FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim CheckBatchUserIDCommand As New SqlCommand(CheckBatchUserIDStatement, con)
            CheckBatchUserIDCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            CheckBatchUserIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckBatchUserID = CStr(CheckBatchUserIDCommand.ExecuteScalar)
            Catch ex As Exception
                CheckBatchUserID = ""
            End Try
            con.Close()

            If CheckBatchUserID = EmployeeLoginName Or CheckBatchUserID = "" Then
                'skip
            Else
                MsgBox("You cannot delete an invoice from another user's batch.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '**************************************************************************
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Invoice?", "DELETE INVOICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Check to make sure Invoice is not posted
                Dim CheckInvoiceStatusStatement As String = "SELECT InvoiceStatus FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                Dim CheckInvoiceStatusCommand As New SqlCommand(CheckInvoiceStatusStatement, con)
                CheckInvoiceStatusCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                CheckInvoiceStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckInvoiceStatus = CStr(CheckInvoiceStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckInvoiceStatus = "PENDING"
                End Try
                con.Close()

                If InvoiceStatus = "PENDING" Then
                    'Reset Shipment or Customer Return to be selected again.
                    If Val(txtShipmentNumber.Text) = 0 Or Val(txtSalesOrderNumber.Text) = 0 Or SpecialInstructions = "CREDIT" Then
                        'Invoice is from a customer return
                        cmd = New SqlCommand("Update ReturnProductHeaderTable SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("ReturnNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@ReturnStatus", SqlDbType.VarChar).Value = "PENDING"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Check to see if Invoice is from a Drop Ship
                        Dim GetSpecialTypeStatement As String = "SELECT DropShipPONumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                        Dim GetSpecialTypeCommand As New SqlCommand(GetSpecialTypeStatement, con)
                        GetSpecialTypeCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        GetSpecialTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetSpecialType = CInt(GetSpecialTypeCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetSpecialType = 0
                        End Try
                        con.Close()

                        If GetSpecialType > 0 Then
                            'Invoice is from a drop ship - delete shipment and receiver and reset PO

                            'Get Receiver Number and PO Number
                            Dim GetReceiverStatement As String = "SELECT PickTicketNumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                            Dim GetReceiverCommand As New SqlCommand(GetReceiverStatement, con)
                            GetReceiverCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                            GetReceiverCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetReceiver = CInt(GetReceiverCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetReceiver = 0
                            End Try
                            con.Close()

                            Dim GetPOStatement As String = "SELECT PONumber FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
                            Dim GetPOCommand As New SqlCommand(GetPOStatement, con)
                            GetPOCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = GetReceiver
                            GetPOCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                DropShipPONumber = CInt(GetPOCommand.ExecuteScalar)
                            Catch ex As Exception
                                DropShipPONumber = 0
                            End Try
                            con.Close()

                            'Update SO Table
                            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                            With cmd.Parameters
                                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@SOStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Update SO Lines
                            cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Update PO Tables
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = DropShipPONumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Update PO Lines
                            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = DropShipPONumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Delete Receiver
                            cmd = New SqlCommand("DELETE FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = GetReceiver
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Delete Shipment
                            cmd = New SqlCommand("DELETE FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            'Invoice is from a shipment
                            cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    End If
                    '***************************************************************************************************
                    'Write to Audit Trail Table
                    Dim AuditComment As String = ""
                    Dim AuditInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String = ""

                    AuditInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(AuditInvoiceNumber)
                    AuditComment = "Invoice #" + strInvoiceNumber + " for customer " + txtCustomerName.Text + " was deleted on " + Today()
                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "INVOICE SINGLE - DELETION"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = InvoiceTotal
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strInvoiceNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try
                    '**************************************************************************************************
                    'Reset Serial Numbers (if applicable)
                    Dim CountSerialLines As Integer = 0

                    Dim CountSerialLinesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber"
                    Dim CountSerialLinesCommand As New SqlCommand(CountSerialLinesStatement, con)
                    CountSerialLinesCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountSerialLines = CInt(CountSerialLinesCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountSerialLines = 0
                    End Try
                    con.Close()

                    If CountSerialLines <> 0 Then
                        Dim SLInvoiceSerialNumber As String = ""
                        Dim SLInvoiceLineNumber As Integer = 0
                        Dim SerialPartNumber As String = ""

                        For Each row As DataGridViewRow In dgvInvoiceSerialLineTable.Rows
                            Try
                                SLInvoiceSerialNumber = row.Cells("SLInvoiceSerialNumberColumn").Value
                            Catch ex As Exception
                                SLInvoiceSerialNumber = ""
                            End Try
                            Try
                                SLInvoiceLineNumber = row.Cells("SLInvoiceLineNumberColumn").Value
                            Catch ex As Exception
                                SLInvoiceLineNumber = 1
                            End Try
                            '*****************************************************************
                            'Get Part Number for this serial line
                            Dim GetSerialPartStatement As String = "SELECT PartNumber FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                            Dim GetSerialPartCommand As New SqlCommand(GetSerialPartStatement, con)
                            GetSerialPartCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            GetSerialPartCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = SLInvoiceLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                SerialPartNumber = CStr(GetSerialPartCommand.ExecuteScalar)
                            Catch ex As Exception
                                SerialPartNumber = ""
                            End Try
                            con.Close()
                            '*******************************************************************
                            'Update Assembly Serial Log (Reset)
                            Try
                                cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, TransactionNumber = @TransactionNumber, BatchNumber = @BatchNumber, CustomerID = @CustomerID WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND TransactionNumber = @TransactionNumber2", con)

                                With cmd.Parameters
                                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = SerialPartNumber
                                    .Add("@SerialNumber", SqlDbType.VarChar).Value = SLInvoiceSerialNumber
                                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                                    .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                                    .Add("@TransactionNumber2", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Fail 
                            End Try
                        Next
                    Else
                        'No serial Lines
                    End If
                    '***************************************************************************************************
                    'Create command to save data from text boxes
                    cmd = New SqlCommand("DELETE FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear text boxes on delete
                    LoadBatchNumber()
                    LoadInvoiceNumber()
                    LoadCustomerList()
                    ShowData()
                    ClearData()

                    If GlobalARBatchNumber > 1 Then
                        cboBatchNumber.Text = GlobalARBatchNumber
                        Try
                            cboInvoiceNumber.SelectedIndex = 0
                        Catch ex As Exception
                            cboInvoiceNumber.SelectedIndex = -1
                        End Try
                    Else
                        cboBatchNumber.SelectedIndex = -1
                        cboInvoiceNumber.SelectedIndex = -1
                    End If

                    'Prompt after deletion
                    MsgBox("This Invoice has been deleted.", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("You cannot delete this Invoice at this time.", MsgBoxStyle.OkOnly)
                End If
            ElseIf button = DialogResult.No Then
                cmdClearAll.Focus()
            End If
        End If
    End Sub

    Private Sub cmdAddTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddTax.Click
        Dim AddGSTTax, ADDPSTTax, ADDHSTTax As Double
        Dim ADDExtendedAmount, ADDLineTax As Double
        Dim ADDLineNumber As Integer = 0

        Dim button As DialogResult = MessageBox.Show("Do you wish to add tax to this Invoice?", "ADD TAX TO INVOICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then 'Canadian Tax Routine
                'Get product Total and freight Total
                CalculateCanadianTotals()

                If txtGSTRate.Text <> "" Then
                    AddGSTTax = Val(txtGSTRate.Text) * (ProductTotal + BilledFreight)
                Else
                    AddGSTTax = 0
                End If
                If txtPSTRate.Text <> "" Then
                    ADDPSTTax = Val(txtPSTRate.Text) * (ProductTotal + BilledFreight)
                Else
                    ADDPSTTax = 0
                End If
                If txtHSTRate.Text <> "" Then
                    ADDHSTTax = Val(txtHSTRate2.Text) * (ProductTotal + BilledFreight)
                Else
                    ADDHSTTax = 0
                End If

                InvoiceTotal = BilledFreight + ProductTotal + AddGSTTax + ADDPSTTax + ADDHSTTax

                'Add Comand
                '************************************************************************************************
                'Write Data to Invoice Header Database Table (One Time)
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET SalesTax = @SalesTax, InvoiceTotal = @InvoiceTotal, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3 WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@SalesTax", SqlDbType.VarChar).Value = AddGSTTax
                    .Add("@SalesTax2", SqlDbType.VarChar).Value = ADDPSTTax
                    .Add("@SalesTax3", SqlDbType.VarChar).Value = ADDHSTTax
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '************************************************************************************************
                'Retotal Invoice and save
                CalculateCanadianTotals()
            Else 'American Tax Routine
                'Add Tax to each Line
                If txtSalesTaxRate.Text <> "" Then
                    For Each row As DataGridViewRow In dgvInvoiceLines.Rows
                        Try
                            ADDExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                        Catch ex As Exception
                            ADDExtendedAmount = 0
                        End Try
                        Try
                            ADDLineNumber = row.Cells("InvoiceLineKeyColumn").Value
                        Catch ex As Exception
                            ADDLineNumber = 0
                        End Try

                        ADDLineTax = Val(txtSalesTaxRate.Text) * ADDExtendedAmount

                        cmd = New SqlCommand("UPDATE InvoiceLineTable SET SalesTax = @SalesTax WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = ADDLineNumber
                            .Add("@SalesTax", SqlDbType.VarChar).Value = ADDLineTax
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Next
                Else
                    'Do nothing - no tax changes
                End If

                'Retotal Invoice and save
                LoadInvoiceTotals()

                'Write Data to Invoice Header Database Table (One Time)
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET SalesTax = @SalesTax, InvoiceTotal = @InvoiceTotal, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3 WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                    .Add("@SalesTax2", SqlDbType.VarChar).Value = 0
                    .Add("@SalesTax3", SqlDbType.VarChar).Value = 0
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowData()
            End If
        ElseIf button = DialogResult.No Then
            cmdSave.Focus()
        End If
    End Sub

    Private Sub cmdEmailBoth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmailBoth.Click
        If Not String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            Try
                '***************************************************************************
                'Load again to display any updates or changes
                If Not taxRemoved Then
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateCanadianTotals()
                    Else
                        LoadInvoiceTotals()
                    End If
                End If
                '***************************************************************************
                'Validate Payment Terms
                ValidatePaymentTerms()

                If CheckPaymentTerms = 0 Then
                    MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '***************************************************************************
                'Check Freight
                If Val(txtBilledFreight.Text) > 10000 Then
                    MsgBox("Check the amount for freight billed. Cannot exceed $10,000.00.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '*****************************************************************************************************************************************
                If Val(txtBilledFreight.Text) <> 0 And cboShipMethod.Text = "COLLECT" Then
                    MsgBox("You cannot add freight if ship method is COLLECT.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                'Check shipping and save data
                ValidateShippingMethod()
                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***************************************************************************
                'Load again to display any updates or changes
                If Not taxRemoved Then
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateCanadianTotals()
                    Else
                        LoadInvoiceTotals()
                    End If
                End If

                'Save changes to Invoice Table
                SaveUpdateInvoiceHeaderTable()
                '***************************************************************************
                'Update Shipment Table to reflect invoicing
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus, PRONumber = @PRONumber, FreightActualAmount = @FreightActualAmount, CustomerPO = @CustomerPO, FreightQuoteAmount = @FreightQuoteAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                    .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                    .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtBilledFreight.Text)
                    .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtQuotedFreight.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Re-Total Shipment in case of added freight
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***************************************************************************
            Catch ex As Exception
                'Do nothing
            End Try
            '*****************************************************************************************
            'Get Invoice Email Address
            Dim EmailAddressStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailAddressCommand As New SqlCommand(EmailAddressStatement, con)
            EmailAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            EmailAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerEmailAddress = CStr(EmailAddressCommand.ExecuteScalar)
            Catch ex As Exception
                EmailCustomerEmailAddress = ""
            End Try
            con.Close()
            '*******************************************************************************************
            Dim CheckForNoCerts As Integer = 0

            'Check to see if there are any certs that will not print
            Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
            Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
            CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
            CheckForNoCertsCommand.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = "NO CERT"

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader3 As SqlDataReader = CheckForNoCertsCommand.ExecuteReader()
            If reader3.HasRows Then
                reader3.Read()
                If IsDBNull(reader3.Item("CountNoCerts")) Then
                    CheckForNoCerts = 0
                Else
                    CheckForNoCerts = reader3.Item("CountNoCerts")
                End If
            Else
                CheckForNoCerts = 0
            End If
            reader3.Close()
            con.Close()

            If CheckForNoCerts = 0 Then
                'Set Global Variable to NO
                GlobalPrintNoCertPage = "NO"
            Else
                'Set Global Variable to YES
                GlobalPrintNoCertPage = "YES"
            End If

            EmailInvoiceNumber = cboInvoiceNumber.Text
            EmailSalesOrderNumber = txtSalesOrderNumber.Text
            EmailShipmentNumber = txtShipmentNumber.Text
            EmailInvoiceCustomer = cboCustomerID.Text
       
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
                Using NewEmailAllInvoiceDocsRemote As New EmailAllInvoiceDocsRemote
                    Dim Result = NewEmailAllInvoiceDocsRemote.ShowDialog()
                End Using
            Else
                Using NewEmailAllInvoiceDocs As New EmailAllInvoiceDocs
                    Dim Result = NewEmailAllInvoiceDocs.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdPrintCerts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCerts.Click
        If Not String.IsNullOrEmpty(txtShipmentNumber.Text) Then
            Try
                '***************************************************************************
                'Load again to display any updates or changes
                If Not taxRemoved Then
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateCanadianTotals()
                    Else
                        LoadInvoiceTotals()
                    End If
                End If
                '***************************************************************************
                'Validate Payment Terms
                ValidatePaymentTerms()

                If CheckPaymentTerms = 0 Then
                    MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '***************************************************************************
                'Check Freight
                If Val(txtBilledFreight.Text) > 10000 Then
                    MsgBox("Check the amount for freight billed. Cannot exceed $10,000.00.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '*****************************************************************************************************************************************
                If Val(txtBilledFreight.Text) <> 0 And cboShipMethod.Text = "COLLECT" Then
                    MsgBox("You cannot add freight if ship method is COLLECT.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                'Check shipping and save data
                ValidateShippingMethod()
                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***************************************************************************
                'Load again to display any updates or changes
                If Not taxRemoved Then
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateCanadianTotals()
                    Else
                        LoadInvoiceTotals()
                    End If
                End If

                SaveUpdateInvoiceHeaderTable()
                LoadCustomerEmail()
                '***************************************************************************
                'Update Shipment Table to reflect invoicing
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus, PRONumber = @PRONumber, FreightActualAmount = @FreightActualAmount, CustomerPO = @CustomerPO, FreightQuoteAmount = @FreightQuoteAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                    .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                    .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtBilledFreight.Text)
                    .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtQuotedFreight.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Re-Total Shipment in case of added freight
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***************************************************************************
            Catch ex As Exception
                'Do nothing
            End Try
            '*******************************************************************************************************************************************
            'Check to make sure at least one cert will print otherwise do not open Print Form
            Dim CheckForCerts As Integer = 0

            'Get Pull Test Number for selected Lot Number Data
            Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
            CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
            CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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
                Dim CheckForNoCerts As Integer = 0

                'Check to see if there are any certs that will not print
                Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
                Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
                CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                CheckForNoCertsCommand.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = "NO CERT"

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader3 As SqlDataReader = CheckForNoCertsCommand.ExecuteReader()
                If reader3.HasRows Then
                    reader3.Read()
                    If IsDBNull(reader3.Item("CountNoCerts")) Then
                        CheckForNoCerts = 0
                    Else
                        CheckForNoCerts = reader3.Item("CountNoCerts")
                    End If
                Else
                    CheckForNoCerts = 0
                End If
                reader3.Close()
                con.Close()

                If CheckForNoCerts = 0 Then
                    'Set Global Variable to NO
                    GlobalPrintNoCertPage = "NO"
                Else
                    'Set Global Variable to YES
                    GlobalPrintNoCertPage = "YES"
                End If

                GlobalShipmentNumber = txtShipmentNumber.Text
                GlobalInvoiceNumber = cboInvoiceNumber.Text
                GlobalDivisionCode = cboDivisionID.Text
                GlobalCertCustomer = cboCustomerID.Text

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
                    Using NewPrintTWCert01Remote As New PrintTWCert01Remote
                        Dim result = NewPrintTWCert01Remote.ShowDialog()
                    End Using
                Else
                    Using NewPrintTWCertBatch As New PrintTWCert01
                        Dim result = NewPrintTWCertBatch.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintInvoice.Click
        Try
            '***************************************************************************
            'Load again to display any updates or changes
            If Not taxRemoved Then
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CalculateCanadianTotals()
                Else
                    LoadInvoiceTotals()
                End If
            End If
            '***************************************************************************
            'Check Freight
            If Val(txtBilledFreight.Text) > 10000 Then
                MsgBox("Check the amount for freight billed. Cannot exceed $10,000.00.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '*****************************************************************************************************************************************
            If Val(txtBilledFreight.Text) <> 0 And cboShipMethod.Text = "COLLECT" Then
                MsgBox("You cannot add freight if ship method is COLLECT.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*****************************************************************************************************************************************
            'Check shipping and save data
            ValidateShippingMethod()
            If CheckShippingMethod = "EXIT SUB" Then
                CheckShippingMethod = ""
                MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '***************************************************************************
            'Load again to display any updates or changes
            If Not taxRemoved Then
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CalculateCanadianTotals()
                Else
                    LoadInvoiceTotals()
                End If
            End If

            SaveUpdateInvoiceHeaderTable()
            '***************************************************************************
            'Update Shipment Table to reflect invoicing
            cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus, PRONumber = @PRONumber, FreightActualAmount = @FreightActualAmount, CustomerPO = @CustomerPO, FreightQuoteAmount = @FreightQuoteAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtBilledFreight.Text)
                .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtQuotedFreight.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Re-Total Shipment in case of added freight
            cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '***************************************************************************
        Catch ex As Exception
            'Do nothing
        End Try

        'Get Invoice Email from Customer
        LoadCustomerEmail()

        'Get string Customer/InvoiceNumber for emails
        EmailInvoiceCustomer = txtCustomerName.Text
        EmailCustomerEmailAddress = InvoiceEmail
        EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)

        'Choose the Invoice Print Form by division
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            If Val(txtShipmentNumber.Text) = 0 Or Val(txtSalesOrderNumber.Text) = 0 Then
                GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text
                'Get sring Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = cboCustomerID.Text
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = InvoiceEmail

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
                    Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            Else
                GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text
                'Get sring Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = cboCustomerID.Text
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = InvoiceEmail

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
                    Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                        Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                        Dim result = NewPrintInvoiceSingle.ShowDialog()
                    End Using
                End If
            End If
        Else
            If Val(txtShipmentNumber.Text) = 0 Or Val(txtSalesOrderNumber.Text) = 0 Then
                GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text
                'Get sring Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = cboCustomerID.Text
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = InvoiceEmail

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
                    Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            Else
                GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text
                'Get sring Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = cboCustomerID.Text
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = InvoiceEmail

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
                    Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                        Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                        Dim result = NewPrintInvoiceSingle.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub cmdPrintPackList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPackList.Click
        Dim PLShipNumber As Integer = 0
        Dim PLDivision As String = ""
        Dim PLCustomer As String = ""

        'Get Invoice Email from customer
        LoadCustomerEmail()

        PLShipNumber = Val(txtShipmentNumber.Text)
        PLCustomer = cboCustomerID.Text
        PLDivision = cboDivisionID.Text

        'Auto-print certs based on the line items
        GlobalShipmentNumber = PLShipNumber
        GlobalCertCustomer = PLCustomer
        GlobalDivisionCode = PLDivision

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

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboInvoiceNumber.Text = "" Or Val(cboInvoiceLineNumber.Text) = 0 Then
            MsgBox("You must have a valid Invoice Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Invoice?", "SAVE INVOICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '***************************************************************************
                'Recalculate lines
                cmd = New SqlCommand("Update InvoiceLineTable SET ExtendedAmount = QuantityBilled * Price WHERE InvoiceHeaderKey = @InvoiceHeaderKey", con)
                cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***************************************************************************
                'Load again to display any updates or changes
                If Not taxRemoved Then
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateCanadianTotals()
                        InvoiceDate = dtpInvoiceDate.Value
                    Else
                        LoadInvoiceTotals()
                        InvoiceDate = dtpInvoiceDate.Value
                    End If
                End If
                '***************************************************************************
                'Validate Payment Terms
                ValidatePaymentTerms()

                If CheckPaymentTerms = 0 Then
                    MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '***************************************************************************
                'Check Freight
                If Val(txtBilledFreight.Text) > 10000 Then
                    MsgBox("Check the amount for freight billed. Cannot exceed $10,000.00.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '*****************************************************************************************************************************************
                If Val(txtBilledFreight.Text) <> 0 And cboShipMethod.Text = "COLLECT" Then
                    MsgBox("You cannot add freight if ship method is COLLECT.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                Try
                    'Check shipping and save data
                    ValidateShippingMethod()
                    If CheckShippingMethod = "EXIT SUB" Then
                        CheckShippingMethod = ""
                        MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    SaveUpdateInvoiceHeaderTable()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Edit Invoices --- Header Update Command Failure"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***************************************************************************
                Try
                    'Save Line Items in text fields
                    cmd = New SqlCommand("Update InvoiceLineTable SET PartNumber = @PartNumber, PartDescription = @PartDescription, QuantityBilled = @QuantityBilled, Price = @Price, LineComment = @LineComment, SalesTax = @SalesTax, ExtendedAmount = @ExtendedAmount, DebitGLAccount = @DebitGLAccount, CreditGLAccount = @CreditGLAccount WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = Val(cboInvoiceLineNumber.Text)
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboLinePartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = cboLinePartDescription.Text
                        .Add("@QuantityBilled", SqlDbType.VarChar).Value = Val(txtLineQuantityBilled.Text)
                        .Add("@Price", SqlDbType.VarChar).Value = Val(txtLinePrice.Text)
                        .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
                        .Add("@SalesTax", SqlDbType.VarChar).Value = Val(txtLineSalesTax.Text)
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = QuantityBilled * Price
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtGLSalesOffsetAccount.Text
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtGLInventoryAccount.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Edit Invoices --- Invoice Line Command Failure"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***************************************************************************
                'Load again to display any updates or changes
                If Not taxRemoved Then
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateCanadianTotals()
                    Else
                        LoadInvoiceTotals()
                    End If
                End If
                '***************************************************************************
                Try
                    'Update Shipment Table to reflect invoicing
                    cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus, PRONumber = @PRONumber, FreightActualAmount = @FreightActualAmount, CustomerPO = @CustomerPO, FreightQuoteAmount = @FreightQuoteAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                        .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtBilledFreight.Text)
                        .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtQuotedFreight.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Edit Invoices --- Shipment Status Command Failure"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***************************************************************************
                Try
                    'Re-Total Shipment in case of added freight
                    cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Edit Invoices --- Update Shipment Command Failure"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***************************************************************************
                'Prompt after Save
                ShowData()
                MsgBox("This data has been saved.", MsgBoxStyle.OkOnly)
            ElseIf button = DialogResult.No Then
                cmdSave.Focus()
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Prompt before Saving
        If InvoiceStatus = "CLOSED" Or cboInvoiceNumber.Text = "" Or Val(cboInvoiceNumber.Text) = 0 Then
            'Reload AR Batch Form
            GlobalARBatchNumber = Val(cboBatchNumber.Text)

            Dim NewARProcessBatch As New ARProcessBatch
            NewARProcessBatch.Show()

            ClearVariables()
            ClearData()

            Me.Dispose()
            Me.Close()
        Else
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Invoice?", "SAVE INVOICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '***************************************************************************
                'Load again to display any updates or changes
                If Not taxRemoved Then
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateCanadianTotals()
                        InvoiceDate = dtpInvoiceDate.Value
                    Else
                        LoadInvoiceTotals()
                        InvoiceDate = dtpInvoiceDate.Value
                    End If
                End If
                '***************************************************************************
                'Validate Payment Terms
                ValidatePaymentTerms()

                If CheckPaymentTerms = 0 Then
                    MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '***************************************************************************
                'Check Freight
                If Val(txtBilledFreight.Text) > 10000 Then
                    MsgBox("Check the amount for freight billed. Cannot exceed $10,000.00.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '*****************************************************************************************************************************************
                If Val(txtBilledFreight.Text) <> 0 And cboShipMethod.Text = "COLLECT" Then
                    MsgBox("You cannot add freight if ship method is COLLECT.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                'Check shipping and save data
                ValidateShippingMethod()
                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    Exit Sub
                End If
                '***************************************************************************
                'Load again to display any updates or changes
                If Not taxRemoved Then
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateCanadianTotals()
                    Else
                        LoadInvoiceTotals()
                    End If
                End If

                'Run Save Routine
                SaveUpdateInvoiceHeaderTable()
                '***************************************************************************
                'Update Shipment Table to reflect invoicing
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus, PRONumber = @PRONumber, FreightActualAmount = @FreightActualAmount, CustomerPO = @CustomerPO, FreightQuoteAmount = @FreightQuoteAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                    .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                    .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtBilledFreight.Text)
                    .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtQuotedFreight.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Re-Total Shipment in case of added freight
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***************************************************************************
                'Prompt after Save
                MsgBox("This data has been saved.", MsgBoxStyle.OkOnly)

                'Reload AR Batch Form
                GlobalARBatchNumber = Val(cboBatchNumber.Text)

                Dim NewARProcessBatch As New ARProcessBatch
                NewARProcessBatch.Show()

                ClearVariables()
                ClearData()

                Me.Dispose()
                Me.Close()
            ElseIf button = DialogResult.No Then
                'Reload AR Batch Form
                GlobalARBatchNumber = Val(cboBatchNumber.Text)

                Dim NewARProcessBatch As New ARProcessBatch
                NewARProcessBatch.Show()

                ClearVariables()
                ClearData()

                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdRemoveSalesTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveSalesTax.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to remove Sales Tax from this invoice?", "REMOVE TAX", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Dim SumInvoiceLines, SumFreight, SumInvoiceTotal As Double
            Try
                'Load Product Total and Freight to re-calc Quote Total
                Dim SUMStatement1 As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                Dim SUMCommand1 As New SqlCommand(SUMStatement1, con)
                SUMCommand1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                SUMCommand1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumInvoiceLines = CDbl(SUMCommand1.ExecuteScalar)
                Catch ex As Exception
                    SumInvoiceLines = 0
                End Try
                con.Close()

                SumFreight = Val(txtBilledFreight.Text)
                SumInvoiceTotal = SumInvoiceLines + SumFreight
                '************************************************************************************************
                'Write Data to Invoice Header Database Table (One Time)
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET SalesTax = @SalesTax, ProductTotal = @ProductTotal, BilledFreight = @BilledFreight, InvoiceTotal = @InvoiceTotal, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3 WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = SumInvoiceLines
                    .Add("@BilledFreight", SqlDbType.VarChar).Value = SumFreight
                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                    .Add("@SalesTax2", SqlDbType.VarChar).Value = 0
                    .Add("@SalesTax3", SqlDbType.VarChar).Value = 0
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = SumInvoiceTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '************************************************************************************************
                'Write Data to Invoice Line Database Table 
                cmd = New SqlCommand("UPDATE InvoiceLineTable SET SalesTax = @SalesTax WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '************************************************************************************************
                'Refresh datagrid and load totals
                If Not taxRemoved Then
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        CalculateCanadianTotals()
                    Else
                        LoadInvoiceTotals()
                    End If
                End If

                ShowData()

                'chkTaxable.Checked = False
                chkAddHST.Checked = False
                chkAddPST.Checked = False
                'Clear tax fields and update total
                txtSalesTax.Text = FormatCurrency(0, 2)
                txtSalesTax2.Text = FormatCurrency(0, 2)
                txtSalesTax3.Text = FormatCurrency(0, 2)
                txtInvoiceTotal.Text = FormatCurrency(SumInvoiceTotal, 2)
                txtHSTRate.Text = FormatCurrency(0, 2)
                txtHSTRate.Visible = False
                'txtLineSalesTaxRate.Visible = False
                SalesTax = 0
                SalesTax2 = 0
                SalesTax3 = 0
                InvoiceTotal = FormatCurrency(SumInvoiceTotal, 2)
                taxRemoved = Not taxRemoved
                MsgBox("Sales Tax has been removed.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                MsgBox("There is an error - sales tax not removed.", MsgBoxStyle.OkOnly)
            End Try
        ElseIf button = DialogResult.No Then
            cmdRemoveSalesTax.Focus()
        End If
    End Sub

    'Menu Strip Items

    Private Sub DeleteInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteInvoiceToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub PrintInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoiceToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ClearInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearInvoiceToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub AddTaxToInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddTaxToInvoiceToolStripMenuItem.Click
        Dim strTaxRate As String = ""
        Dim CurrentTaxRate As Double = 0

        strTaxRate = InputBox("Please Enter Tax Rate.", "Tax Rate", "0")

        CurrentTaxRate = CDbl(strTaxRate)

        If CurrentTaxRate > 0 And CurrentTaxRate < 1 Then
            'Update Invoice Lines
            cmd = New SqlCommand("Update InvoiceLineTable SET SalesTax = ExtendedAmount * @CurrentTaxRate WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@CurrentTaxRate", SqlDbType.VarChar).Value = CurrentTaxRate
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadInvoiceTotals()
            ShowData()

            MsgBox("Invoice has been updated.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub SaveInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveInvoiceToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    'Datagrid Operations

    Private Sub dgvInvoiceLotNumbers_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceLotNumbers.CellDoubleClick
        If dgvInvoiceLotNumbers.RowCount <> 0 Then

            GlobalShipmentNumber = Val(txtShipmentNumber.Text)
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
                Using NewPrintTWCert01Remote As New PrintTWCert01Remote
                    Dim result = NewPrintTWCert01Remote.ShowDialog()
                End Using
            Else
                Using NewPrintInvoiceCerts As New PrintTWCert01
                    Dim result = NewPrintInvoiceCerts.ShowDialog()
                End Using
            End If
        Else
            'No certs to print
        End If
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvInvoiceLines.CellValueChanged
        Dim SOTaxRate, LineQuantityBilled, LineExtendedAmount, LineUnitPrice, LineExtendedCOS, UnitCOS, LineSalesTax As Double
        Dim LineNumber As Integer
        Dim GridLineComment, SerialNumber As String

        If Me.dgvInvoiceLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInvoiceLines.CurrentCell.RowIndex

            Try
                LineUnitPrice = Me.dgvInvoiceLines.Rows(RowIndex).Cells("PriceColumn").Value
            Catch ex As Exception
                LineUnitPrice = 0
            End Try
            Try
                LineQuantityBilled = Me.dgvInvoiceLines.Rows(RowIndex).Cells("QuantityBilledColumn").Value
            Catch ex As Exception
                LineQuantityBilled = 0
            End Try
            Try
                LineExtendedCOS = Me.dgvInvoiceLines.Rows(RowIndex).Cells("ExtendedCOSColumn").Value
            Catch ex As Exception
                LineExtendedCOS = 0
            End Try
            Try
                GridLineComment = Me.dgvInvoiceLines.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                GridLineComment = ""
            End Try
            Try
                SerialNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("SerialNumberColumn").Value
            Catch ex As Exception
                SerialNumber = ""
            End Try
            Try
                LineNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("InvoiceLineKeyColumn").Value
            Catch ex As Exception
                LineNumber = 0
            End Try

            LineExtendedAmount = LineUnitPrice * LineQuantityBilled
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

            If cboDivisionID.Text = "TFF" Then
                LineSalesTax = 0
            ElseIf cboDivisionID.Text = "TOR" Then
                LineSalesTax = 0
            Else
                Dim SOTaxRateStatement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                Dim SOTaxRateCommand As New SqlCommand(SOTaxRateStatement, con)
                SOTaxRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                SOTaxRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SOTaxRate = CDbl(SOTaxRateCommand.ExecuteScalar)
                Catch ex As Exception
                    SOTaxRate = 0
                End Try
                con.Close()

                LineSalesTax = LineExtendedAmount * SOTaxRate
                LineSalesTax = Math.Round(LineSalesTax, 2)
            End If

            'UPDATE Invoice Line Table
            cmd = New SqlCommand("UPDATE InvoiceLineTable SET Price = @Price, ExtendedAmount = @ExtendedAmount, SalesTax = @SalesTax, LineComment = @LineComment, SerialNumber = @SerialNumber WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

            With cmd.Parameters
                .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = LineNumber
                .Add("@Price", SqlDbType.VarChar).Value = LineUnitPrice
                .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                .Add("@LineComment", SqlDbType.VarChar).Value = GridLineComment
                .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'UPDATE Header Table from line changes
            If Not taxRemoved Then
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CalculateCanadianTotals()
                Else
                    LoadInvoiceTotals()
                End If
            End If

            'UPDATE Purchase Order Extended Amount based on line changes
            cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ProductTotal = @ProductTotal, BilledFreight = @BilledFreight, InvoiceTotal = @InvoiceTotal, SalesTax = @SalesTax, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3, InvoiceCOS = @InvoiceCOS WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                .Add("@InvoiceCOS", SqlDbType.VarChar).Value = SUMExtendedCOS
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Clear Variables
            SOTaxRate = 0
            LineQuantityBilled = 0
            LineExtendedAmount = 0
            LineUnitPrice = 0
            LineExtendedCOS = 0
            UnitCOS = 0
            LineSalesTax = 0
            LineNumber = 0
            GridLineComment = ""
            SerialNumber = ""
            ProductTotal = 0
            BilledFreight = 0
            InvoiceTotal = 0
            SalesTax = 0
            SalesTax2 = 0
            SalesTax3 = 0
            SUMExtendedCOS = 0

            ShowData()
        End If
    End Sub

    'Combo Box Events

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadBatchNumber()
        LoadInvoiceNumber()
        LoadCustomerList()
        ShowData()
        ClearData()
    End Sub

    Private Sub cboInvoiceNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvoiceNumber.SelectedIndexChanged
        LoadLotNumbersInGrid()
        ShowData()
        LoadInvoiceData()
        ShowSerialNumbers()
        If PTUpload IsNot Nothing Then PTUpload.CheckUploadPickTicket()
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            CalculateCanadianTotals()
        Else
            LoadInvoiceTotals()
        End If
    End Sub

    Private Sub cboInvoiceLineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvoiceLineNumber.SelectedIndexChanged
        LoadInvoiceLineDetails()
    End Sub

    Private Sub cboLinePartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLinePartNumber.SelectedIndexChanged
        LoadItemClassForPartNumber()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadCanadianTaxRates()
        Else
            LoadTaxExemptCert()
        End If

        LoadCustomerData()
    End Sub

    Private Sub cboShipmentNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'LoadInvoiceNumberFromShipment()
        'LoadLotNumbersInGrid()
        LoadShippingDate()
    End Sub

    Private Sub cboItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClass.SelectedIndexChanged
        LoadGLAccounts()
    End Sub

    Private Sub cboShipMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipMethod.SelectedIndexChanged
        If cboShipMethod.Text = "THIRD PARTY" Then
            txtThirdPartyShipper.Enabled = True
            GetThirdPartyBillingData()
        Else
            txtThirdPartyShipper.Clear()
            txtThirdPartyShipper.Enabled = False
        End If
    End Sub

    'Text Box Events

    Private Sub txtHSTRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHSTRate.TextChanged
        If chkAddHST.Checked = True And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            HSTRate = Val(txtHSTRate.Text)
            HSTTotal = Math.Round(HSTTotal, 2)
            HSTTotal = HSTRate * (ProductTotal + BilledFreight)
            SalesTax = 0
            SalesTax2 = 0
            SalesTax3 = HSTTotal

            txtSalesTax3.Text = FormatCurrency(SalesTax3, 2)
            txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)
            txtSalesTax.Text = FormatCurrency(SalesTax, 2)

            InvoiceTotal = BilledFreight + SalesTax + SalesTax2 + SalesTax3 + ProductTotal
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        Else
            'Do nothing
        End If
    End Sub

    Private Sub txtDiscountPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPercent.TextChanged
        DiscountPercent = Val(txtDiscountPercent.Text)
    End Sub

    Private Sub txtDiscountAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountAmount.TextChanged
        DiscountAmount = Val(txtDiscountAmount.Text)
    End Sub

    Private Sub txtBilledFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBilledFreight.TextChanged
        BilledFreight = Val(txtBilledFreight.Text)
        txtFreightBilled.Text = FormatCurrency(BilledFreight, 2)

        'Retotal Invoice Data
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            CalculateCanadianTotals()
        Else
            LoadInvoiceTotals()
        End If
    End Sub

    Private Sub txtLineQuantityBilled_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineQuantityBilled.TextChanged
        QuantityBilled = Val(txtLineQuantityBilled.Text)
        LineExtendedAmount = QuantityBilled * Price
        txtLineExtendedAmount.Text = LineExtendedAmount
    End Sub

    Private Sub txtLinePrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLinePrice.TextChanged
        Price = Val(txtLinePrice.Text)
        LineExtendedAmount = QuantityBilled * Price
        txtLineExtendedAmount.Text = LineExtendedAmount
    End Sub

    Private Sub txtShipmentNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipmentNumber.TextChanged
        If txtShipmentNumber.Text = "" Then
            'Do nothing
        Else
            LoadUploadedPickTicket()
        End If
    End Sub

    'Misc Operations

    Private Sub chkAddHST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddHST.CheckedChanged
        If chkAddHST.Checked = True And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            'Get current product total to calculate tax, totals
            Dim SUMExtendedStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
            Dim SUMExtendedCommand As New SqlCommand(SUMExtendedStatement, con)
            SUMExtendedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SUMExtendedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(SUMExtendedCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            con.Close()

            LoadSOTaxRates()

            BilledFreight = Val(txtBilledFreight.Text)
            chkAddPST.Checked = False
            txtHSTRate.Visible = True

            txtHSTRate.Text = SOHSTRate

            GSTTotal = 0
            PSTTotal = 0
            HSTTotal = SOHSTRate * (ProductTotal + BilledFreight)

            GSTTotal = Math.Round(GSTTotal, 2)
            PSTTotal = Math.Round(PSTTotal, 2)
            HSTTotal = Math.Round(HSTTotal, 2)

            SalesTax = GSTTotal
            SalesTax2 = PSTTotal
            SalesTax3 = HSTTotal

            InvoiceTotal = BilledFreight + SalesTax + SalesTax2 + SalesTax3 + ProductTotal

            txtSalesTax.Text = FormatCurrency(SalesTax, 2)
            txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)
            txtSalesTax3.Text = FormatCurrency(SalesTax3, 2)
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        ElseIf chkAddHST.Checked = False And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            'Get current product total to calculate tax, totals
            Dim SUMExtendedStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
            Dim SUMExtendedCommand As New SqlCommand(SUMExtendedStatement, con)
            SUMExtendedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SUMExtendedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(SUMExtendedCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            con.Close()

            LoadSOTaxRates()

            BilledFreight = Val(txtBilledFreight.Text)
            txtHSTRate.Visible = False
            GSTRate = SOGSTRate
            PSTRate = SOPSTRate

            GSTTotal = GSTRate * (ProductTotal + BilledFreight)
            PSTTotal = 0
            HSTTotal = 0

            GSTTotal = Math.Round(GSTTotal, 2)
            PSTTotal = Math.Round(PSTTotal, 2)
            HSTTotal = Math.Round(HSTTotal, 2)

            SalesTax = GSTTotal
            SalesTax2 = PSTTotal
            SalesTax3 = HSTTotal

            InvoiceTotal = BilledFreight + SalesTax + SalesTax2 + SalesTax3 + ProductTotal

            txtSalesTax.Text = FormatCurrency(SalesTax, 2)
            txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)
            txtSalesTax3.Text = FormatCurrency(SalesTax3, 2)
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        Else
            'Do nothing
        End If
    End Sub

    Private Sub chkAddPST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddPST.CheckedChanged
        If chkAddPST.Checked = True And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            'Get current product total to calculate tax, totals
            Dim SUMExtendedStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
            Dim SUMExtendedCommand As New SqlCommand(SUMExtendedStatement, con)
            SUMExtendedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SUMExtendedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(SUMExtendedCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            con.Close()

            LoadSOTaxRates()

            BilledFreight = Val(txtBilledFreight.Text)

            chkAddHST.Checked = False

            PSTRate = SOPSTRate
            GSTRate = SOGSTRate

            GSTTotal = GSTRate * (ProductTotal + BilledFreight)
            PSTTotal = PSTRate * (ProductTotal + BilledFreight)
            HSTTotal = 0

            GSTTotal = Math.Round(GSTTotal, 2)
            PSTTotal = Math.Round(PSTTotal, 2)
            HSTTotal = Math.Round(HSTTotal, 2)

            SalesTax2 = PSTTotal
            SalesTax = GSTTotal
            SalesTax3 = HSTTotal

            InvoiceTotal = BilledFreight + SalesTax + SalesTax2 + SalesTax3 + ProductTotal

            txtSalesTax.Text = FormatCurrency(SalesTax, 2)
            txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)
            txtSalesTax3.Text = FormatCurrency(SalesTax3, 2)
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        ElseIf chkAddPST.Checked = False And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            'Get current product total to calculate tax, totals
            Dim SUMExtendedStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
            Dim SUMExtendedCommand As New SqlCommand(SUMExtendedStatement, con)
            SUMExtendedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SUMExtendedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(SUMExtendedCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            con.Close()

            LoadSOTaxRates()

            BilledFreight = Val(txtBilledFreight.Text)

            GSTTotal = SOGSTRate * (ProductTotal + BilledFreight)
            PSTTotal = 0
            HSTTotal = 0

            GSTTotal = Math.Round(GSTTotal, 2)
            PSTTotal = Math.Round(PSTTotal, 2)
            HSTTotal = Math.Round(HSTTotal, 2)

            SalesTax = GSTTotal
            SalesTax2 = PSTTotal
            SalesTax3 = HSTTotal

            InvoiceTotal = BilledFreight + SalesTax + SalesTax2 + SalesTax3 + ProductTotal

            txtSalesTax.Text = FormatCurrency(SalesTax, 2)
            txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)
            txtSalesTax3.Text = FormatCurrency(SalesTax3, 2)
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        Else
            'Do nothing
        End If
    End Sub

    Private Sub AutoEmailByPreferencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoEmailByPreferencesToolStripMenuItem.Click
        Dim TempShipmentNumber, TempInvoiceNumber As Integer
        Dim strShipmentNumber, strInvoiceNumber As String
        Dim CertEmail, PackingListEmail, InvoiceEmail As String
        Dim NextNoteNumber, LastNoteNumber As Integer

        GlobalDivisionCode = cboDivisionID.Text
        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
        strInvoiceNumber = CStr(TempInvoiceNumber)
        TempShipmentNumber = Val(txtShipmentNumber.Text)
        strShipmentNumber = CStr(TempShipmentNumber)

        Dim GetInvoiceEmailStatement As String = "SELECT InvoiceEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetInvoiceEmailCommand As New SqlCommand(GetInvoiceEmailStatement, con)
        GetInvoiceEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GetInvoiceEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim GetPackingListEmailStatement As String = "SELECT PackingListEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetPackingListEmailCommand As New SqlCommand(GetPackingListEmailStatement, con)
        GetPackingListEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GetPackingListEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim GetCertEmailStatement As String = "SELECT CertEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetCertEmailCommand As New SqlCommand(GetCertEmailStatement, con)
        GetCertEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GetCertEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InvoiceEmail = CStr(GetInvoiceEmailCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceEmail = ""
        End Try
        Try
            PackingListEmail = CStr(GetPackingListEmailCommand.ExecuteScalar)
        Catch ex As Exception
            PackingListEmail = ""
        End Try
        Try
            CertEmail = CStr(GetCertEmailCommand.ExecuteScalar)
        Catch ex As Exception
            CertEmail = ""
        End Try
        con.Close()
        '***********************************************************************************************************************************************************************************
        'Validate Email
        If InvoiceEmail.Contains(",") Then
            InvoiceEmail.Replace(",", ";")
        Else
            'Do nothing
        End If
        If PackingListEmail.Contains(",") Then
            PackingListEmail.Replace(",", ";")
        Else
            'Do nothing
        End If
        If CertEmail.Contains(",") Then
            CertEmail.Replace(",", ";")
        Else
            'Do nothing
        End If

        InvoiceEmail = InvoiceEmail.Replace(vbCr, " ")
        InvoiceEmail = InvoiceEmail.Replace(vbCrLf, " ")
        InvoiceEmail = InvoiceEmail.Replace(vbLf, " ")
        InvoiceEmail = InvoiceEmail.Replace(vbCr, " ")
        InvoiceEmail = InvoiceEmail.Replace(vbCrLf, " ")
        InvoiceEmail = InvoiceEmail.Replace(vbLf, " ")

        PackingListEmail = PackingListEmail.Replace(vbCr, " ")
        PackingListEmail = PackingListEmail.Replace(vbCrLf, " ")
        PackingListEmail = PackingListEmail.Replace(vbLf, " ")
        PackingListEmail = PackingListEmail.Replace(vbCr, " ")
        PackingListEmail = PackingListEmail.Replace(vbCrLf, " ")
        PackingListEmail = PackingListEmail.Replace(vbLf, " ")

        CertEmail = CertEmail.Replace(vbCr, " ")
        CertEmail = CertEmail.Replace(vbCrLf, " ")
        CertEmail = CertEmail.Replace(vbLf, " ")
        CertEmail = CertEmail.Replace(vbCr, " ")
        CertEmail = CertEmail.Replace(vbCrLf, " ")
        CertEmail = CertEmail.Replace(vbLf, " ")
        '************************************************************************************************************************************************************************************
        'Check if emails addresses exist for each and create the specific docs
        If InvoiceEmail <> "" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = TempInvoiceNumber

            cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = TempInvoiceNumber

            cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd5 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd8 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
            cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd9 = New SqlCommand("SELECT * FROM InvoiceLotLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
            cmd9.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = TempInvoiceNumber

            cmd10 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
            cmd10.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = TempInvoiceNumber

            cmd11 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "InvoiceLineQuery")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "ShipmentHeaderTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "DivisionTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "CustomerList")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "AdditionalShipTo")

            myAdapter8.SelectCommand = cmd8
            myAdapter8.Fill(ds, "ARCustomerPayment")

            myAdapter9.SelectCommand = cmd9
            myAdapter9.Fill(ds, "InvoiceLotLineTable")

            myAdapter10.SelectCommand = cmd10
            myAdapter10.Fill(ds, "InvoiceSerialLineTable")

            myAdapter11.SelectCommand = cmd11
            myAdapter11.Fill(ds, "SalesOrderHeaderTable")

            If cboDivisionID.Text = "TWD" Then
                MyReport = crxInvoice1
                MyReport.SetDataSource(ds)
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")
                con.Close()
            ElseIf cboDivisionID.Text = "TFF" Then
                MyReport = crxInvoiceTFF1
                MyReport.SetDataSource(ds)
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")
                con.Close()
            ElseIf cboDivisionID.Text = "TOR" Then
                MyReport = crxInvoiceTFF1
                MyReport.SetDataSource(ds)
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")
                con.Close()
            Else
                MyReport = crxInvoice1
                MyReport.SetDataSource(ds)
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")
                con.Close()
            End If

            Try
                'Set up email to be sent
                Dim MyMailMessage As New MailMessage()
                MyMailMessage.From = New MailAddress("customerstatements@tfpcorp.com")

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If InvoiceEmail.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(InvoiceEmail, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter)
                        MyMailMessage.To.Add(CurrentEmail)
                        Counter = Counter + 1
                    Next
                Else
                    MyMailMessage.To.Add(InvoiceEmail)
                End If

                MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf"))
                MyMailMessage.Subject = "Customer Invoice / TFP Corporation"
                MyMailMessage.ReplyTo = New MailAddress("ar@tfpcorp.com")
                MyMailMessage.Body = "This Customer Invoice was auto-generated from our system. Do not reply to this email address. If you have any questions, comments, or concerns email us at ar@tfpcorp.com or call 1-800-321-5588. Thank you for your business."
                Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                SMPT.Port = "587"
                SMPT.Timeout = 1500
                SMPT.EnableSsl = False
                SMPT.Credentials = New System.Net.NetworkCredential("customerstatements@tfpcorp.com", "1422325bogie")
                SMPT.Send(MyMailMessage)

                'Get Next Note Number
                Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
                MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("MAXNoteID")) Then
                        LastNoteNumber = 0
                    Else
                        LastNoteNumber = reader.Item("MAXNoteID")
                    End If
                Else
                    LastNoteNumber = 0
                End If
                reader.Close()
                con.Close()

                NextNoteNumber = LastNoteNumber + 1

                Dim MessageBodyText As String = ""

                MessageBodyText = EmployeeLoginName + " emailed Invoice to " + cboCustomerID.Text

                'Write Data to Customer Note Table
                cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

                With cmd.Parameters
                    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@NoteDate", SqlDbType.VarChar).Value = Today()
                    .Add("@NoteSubject", SqlDbType.VarChar).Value = "Auto-Email Invoice Form"
                    .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                    .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write to error log
                Dim TempInvoice As Integer = 0
                Dim strInvoice As String
                TempInvoice = Val(cboInvoiceNumber.Text)
                strInvoice = CStr(TempInvoice)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Edit Invoices --- Auto Email All (Invoice)"
                ErrorReferenceNumber = "Invoice # " + strInvoice
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        Else
            'Do nothing
        End If
        '***************************************************************************************************************************************
        'Generate email for packing list
        If PackingListEmail <> "" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = TempShipmentNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE ShipmentNumber = @ShipmentNumber ORDER BY ShipmentNumber, ShipmentLineNumber", con)
            cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = TempShipmentNumber

            cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd5 = New SqlCommand("SELECT * FROM CountryCodes", con)

            cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd7 = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID", con)
            cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd8 = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID", con)
            cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd9 = New SqlCommand("SELECT * FROM ShipmentLineHeatNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
            cmd9.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = TempShipmentNumber

            cmd10 = New SqlCommand("SELECT * FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
            cmd10.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = TempShipmentNumber

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ShipmentLineQuery2")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "CustomerList")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "DivisionTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "FoxTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "CountryCodes")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "AdditionalShipTo")

            myAdapter7.SelectCommand = cmd7
            myAdapter7.Fill(ds, "AssemblyLineTable")

            myAdapter8.SelectCommand = cmd8
            myAdapter8.Fill(ds, "AssemblyHeaderTable")

            myAdapter9.SelectCommand = cmd9
            myAdapter9.Fill(ds, "ShipmentLineHeatNumbers")

            myAdapter10.SelectCommand = cmd10
            myAdapter10.Fill(ds, "ShipmentLineSerialNumbers")

            If cboDivisionID.Text = "TWD" Then
                MyReport = crxPackingSlip1
                MyReport.SetDataSource(ds)
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & GlobalDivisionCode & strShipmentNumber & ".pdf")
                con.Close()
            ElseIf cboDivisionID.Text = "TFP" Then
                MyReport = crxPackingSlipTFP1
                MyReport.SetDataSource(ds)
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & GlobalDivisionCode & strShipmentNumber & ".pdf")
                con.Close()
            Else
                MyReport = crxPackingSlip1
                MyReport.SetDataSource(ds)
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & GlobalDivisionCode & strShipmentNumber & ".pdf")
                con.Close()
            End If

            Try
                'Set up email to be sent
                Dim MyMailMessage As New MailMessage()
                MyMailMessage.From = New MailAddress("customerstatements@tfpcorp.com")

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If PackingListEmail.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(PackingListEmail, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter)
                        MyMailMessage.To.Add(CurrentEmail)
                        Counter = Counter + 1
                    Next
                Else
                    MyMailMessage.To.Add(PackingListEmail)
                End If

                MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\TruweldPackList\" & GlobalDivisionCode & strShipmentNumber & ".pdf"))
                MyMailMessage.Subject = "Customer Packing Slip / TFP Corporation"
                MyMailMessage.ReplyTo = New MailAddress("ar@tfpcorp.com")
                MyMailMessage.Body = "This Packing Slip was auto-generated from our system. Do not reply to this email address. If you have any questions, comments, or concerns email us at ar@tfpcorp.com or call 1-800-321-5588. Thank you for your business."
                Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                SMPT.Port = "587"
                SMPT.Timeout = 1500
                SMPT.EnableSsl = False
                SMPT.Credentials = New System.Net.NetworkCredential("customerstatements@tfpcorp.com", "1422325bogie")
                SMPT.Send(MyMailMessage)
            Catch ex As Exception
                'Write to error log
                Dim TempShipNumber As Integer = 0
                Dim strShipNumber As String
                TempShipNumber = Val(txtShipmentNumber.Text)
                strShipNumber = CStr(TempShipNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Edit Invoices --- Auto Email All (Packing List)"
                ErrorReferenceNumber = "Shipment # " + strShipNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        Else
            'Do nothing
        End If
        '************************************************************************************************************************************************
        If CertEmail <> "" Then
            'Check to see if certs need to be emailed
            cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = TempShipmentNumber

            cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

            cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "TruweldCertData")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "CustomerList")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "PullTestLineTable")

            'Sets up viewer to display data from the loaded dataset
            MyReport = crxtwCert011
            MyReport.SetDataSource(ds)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\ExportedCerts\" & "CERT" & strShipmentNumber & ".pdf")
            con.Close()

            Try
                'Set up email to be sent
                Dim MyMailMessage As New MailMessage()
                MyMailMessage.From = New MailAddress("customerstatements@tfpcorp.com")

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If CertEmail.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(CertEmail, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter)
                        MyMailMessage.To.Add(CurrentEmail)
                        Counter = Counter + 1
                    Next
                Else
                    MyMailMessage.To.Add(CertEmail)
                End If

                MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\ExportedCerts\" & "CERT" & strShipmentNumber & ".pdf"))
                MyMailMessage.Subject = "Customer Certs / TFP Corporation"
                MyMailMessage.ReplyTo = New MailAddress("ar@tfpcorp.com")
                MyMailMessage.Body = "These Certs was auto-generated from our system. Do not reply to this email address. If you have any questions, comments, or concerns email us at ar@tfpcorp.com or call 1-800-321-5588. Thank you for your business."
                Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                SMPT.Port = "587"
                SMPT.Timeout = 1500
                SMPT.EnableSsl = False
                SMPT.Credentials = New System.Net.NetworkCredential("customerstatements@tfpcorp.com", "1422325bogie")
                SMPT.Send(MyMailMessage)
            Catch ex As Exception
                'Write to error log
                Dim TempShipNumber As Integer = 0
                Dim strShipNumber As String
                TempShipNumber = Val(txtShipmentNumber.Text)
                strShipNumber = CStr(TempShipNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Edit Invoices --- Auto Email All (Certs)"
                ErrorReferenceNumber = "Shipment # " + strShipNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        Else
            'Do nothing
        End If

        'Confirmation Message
        MsgBox("Email sent.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdUploadShowPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadShowPickTicket.Click
        GlobalShipmentNumber = Val(txtShipmentNumber.Text)
        TFPMailCustomer = cboCustomerID.Text
        TFPMailTransactionNumber = Val(txtShipmentNumber.Text)
    End Sub

    Private Sub cmdViewPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPickTicket.Click
        Dim UploadedShipmentNumber As String = ""
        Dim ShipmentFilename As String = ""
        Dim ShipmentFilenameAndPath As String = ""

        If txtShipmentNumber.Text <> "" Then
            GlobalShipmentNumber = Val(txtShipmentNumber.Text)
            UploadedShipmentNumber = CStr(GlobalShipmentNumber)
            ShipmentFilename = UploadedShipmentNumber + ".pdf"
            ShipmentFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + ShipmentFilename

            If File.Exists(ShipmentFilenameAndPath) Then
                System.Diagnostics.Process.Start(ShipmentFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox("You must have a valid shipment number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdRemoteScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoteScan.Click
        Dim PickTicketFilename As String = ""
        Dim PickTicketFilenameAndPath As String = ""
        Dim strPickTicketNumber As String = ""
        Dim PickTicketNumber As Integer = 0

        'Scanning Program
        Dim My_Process As New Process()

        'Verify that they have a PickTicket selected
        If txtShipmentNumber.Text = "" Then
            MsgBox("You must select a valid PickTicket.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            PickTicketNumber = txtShipmentNumber.Text
            strPickTicketNumber = CStr(PickTicketNumber)
        End If

        PickTicketFilename = strPickTicketNumber + ".pdf"
        PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

        If File.Exists(PickTicketFilenameAndPath) Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned Pick Ticket?", "OVERWRITE EXISTING PICK TICKET?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete existing PickTicket before upload
                File.Delete(PickTicketFilenameAndPath)

                Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                strPickTicketNumber = CStr(txtShipmentNumber.Text)
                PickTicketFilename = strPickTicketNumber + ".pdf"
                PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

                Try
                    My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    My_Process.StartInfo.CreateNoWindow = True
                    My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                    My_Process.Close()

                    txtShipmentNumber.Refresh()
                    LoadUploadedPickTicket()
                    txtShipmentNumber.Text = PickTicketNumber
                    cmdRemoteScan.Visible = False
                    cmdUploadShowPickTicket.Visible = False
                    cmdViewPickTicket.Visible = True
                    cmdRemoteScan.Visible = False
                    MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
                Catch ex As System.Exception
                    '    'Log error on update failure
                    Dim TempPickTicketNumber As Integer = 0
                    Dim strPickTicketNumber1 As String = ""
                    TempPickTicketNumber = Val(txtShipmentNumber.Text)
                    strPickTicketNumber1 = CStr(TempPickTicketNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ApplicationFileAndPath & "" & PickTicketFilenameAndPath
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Form --- Scan"
                    ErrorReferenceNumber = "Shipment # " + strPickTicketNumber1
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MsgBox("Scan failed", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"

            strPickTicketNumber = CStr(txtShipmentNumber.Text)
            PickTicketFilename = strPickTicketNumber + ".pdf"
            PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

            Try
                My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                My_Process.StartInfo.CreateNoWindow = True
                My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()

                txtShipmentNumber.Refresh()
                LoadUploadedPickTicket()
                txtShipmentNumber.Text = PickTicketNumber
                cmdRemoteScan.Visible = False
                cmdUploadShowPickTicket.Visible = False
                cmdViewPickTicket.Visible = True
                cmdRemoteScan.Visible = False
                MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                '    'Log error on update failure
                Dim TempPickTicketNumber As Integer = 0
                Dim strPickTicketNumber1 As String = ""
                TempPickTicketNumber = Val(txtShipmentNumber.Text)
                strPickTicketNumber1 = CStr(TempPickTicketNumber)

                ErrorDate = TodaysDate
                ErrorComment = ApplicationFileAndPath & "" & PickTicketFilenameAndPath
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Invoice Form --- Scan"
                ErrorReferenceNumber = "Shipment # " + strPickTicketNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan failed", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub ScanPickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanPickTicketToolStripMenuItem.Click
        cmdRemoteScan_Click(sender, e)
    End Sub
End Class