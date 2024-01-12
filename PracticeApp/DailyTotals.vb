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
Public Class DailyTotals
    Inherits System.Windows.Forms.Form

    Dim DateSelection As Date

    Dim QuoteTotal, APPaymentsMade, ARPaymentsReceived, ProductionValue, SalesData, ShippingData, InvoiceData, CustomerReturnData, PurchaseData, ReceiptData, VendorReturnData As Double
    Dim InventoryTotalADDUnits, InventoryTotalSUBTRACTUnits, InventoryTotalUnits, InventoryUnits, ProductionUnits, InventoryTotalPieces As Double
    Dim AgingLessThan30, Aging31To45, Aging46To60, Aging61To90, AgingMoreThan90 As Double
    Dim APAgingLessThan30, APAging31To45, APAging46To60, APAging61To90, APAgingMoreThan90 As Double
    Dim InventoryTotal, ConsignmentInventoryTotal, InventoryTotalCost, AverageCost As Double
    Dim TotalReceivables, TotalPayables, TotalRMDebits, TotalRMCredits, RawMaterialTotal As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub DailyTotals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

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

    Public Sub LoadSalesData()
        DateSelection = dtpDateSelection.Value

        Dim SalesDataStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SalesOrderDate = @SalesOrderDate AND SOStatus <> @SOStatus"
        Dim SalesDataCommand As New SqlCommand(SalesDataStatement, con)
        SalesDataCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        SalesDataCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = DateSelection
        SalesDataCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        Dim ShippingDataStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND ShipDate = @ShipDate AND ShipmentStatus <> @ShipmentStatus"
        Dim ShippingDataCommand As New SqlCommand(ShippingDataStatement, con)
        ShippingDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ShippingDataCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = DateSelection
        ShippingDataCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

        Dim InvoiceDataStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceDate = @InvoiceDate"
        Dim InvoiceDataCommand As New SqlCommand(InvoiceDataStatement, con)
        InvoiceDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        InvoiceDataCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = DateSelection

        Dim CustomerReturnDataStatement As String = "SELECT SUM(ReturnTotal) FROM ReportProductHeaderTable WHERE DivisionID = @DivisionID AND ReturnDate = @ReturnDate"
        Dim CustomerReturnDataCommand As New SqlCommand(CustomerReturnDataStatement, con)
        CustomerReturnDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CustomerReturnDataCommand.Parameters.Add("@ReturnDate", SqlDbType.VarChar).Value = DateSelection

        Dim QuotesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SalesOrderDate = @SalesOrderDate AND SOStatus = @SOStatus"
        Dim QuotesCommand As New SqlCommand(QuotesStatement, con)
        QuotesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        QuotesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = DateSelection
        QuotesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SalesData = CDbl(SalesDataCommand.ExecuteScalar)
        Catch ex As Exception
            SalesData = 0
        End Try
        Try
            ShippingData = CDbl(ShippingDataCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingData = 0
        End Try
        Try
            InvoiceData = CDbl(InvoiceDataCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceData = 0
        End Try
        Try
            CustomerReturnData = CDbl(CustomerReturnDataCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerReturnData = 0
        End Try
        Try
            QuoteTotal = CDbl(QuotesCommand.ExecuteScalar)
        Catch ex As Exception
            QuoteTotal = 0
        End Try
        con.Close()

        txtCustomerReturns.Text = FormatCurrency(CustomerReturnData, 2)
        txtInvoices.Text = FormatCurrency(InvoiceData, 2)
        txtSalesOrders.Text = FormatCurrency(SalesData, 2)
        txtShipments.Text = FormatCurrency(ShippingData, 2)
        txtQuotes.Text = FormatCurrency(QuoteTotal, 2)
    End Sub

    Public Sub LoadPurchaseData()
        DateSelection = dtpDateSelection.Value

        Dim PurchaseDataStatement As String = "SELECT SUM(POTotal) FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID AND PODate = @PODate"
        Dim PurchaseDataCommand As New SqlCommand(PurchaseDataStatement, con)
        PurchaseDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        PurchaseDataCommand.Parameters.Add("@PODate", SqlDbType.VarChar).Value = DateSelection

        Dim ReceiptDataStatement As String = "SELECT SUM(POTotal) FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID AND ReceivingDate = @ReceivingDate"
        Dim ReceiptDataCommand As New SqlCommand(ReceiptDataStatement, con)
        ReceiptDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ReceiptDataCommand.Parameters.Add("@ReceivingDate", SqlDbType.VarChar).Value = DateSelection

        Dim VendorReturnDataStatement As String = "SELECT SUM(ReturnTotal) FROM VendorReturn WHERE DivisionID = @DivisionID AND ReturnDate = @ReturnDate"
        Dim VendorReturnDataCommand As New SqlCommand(VendorReturnDataStatement, con)
        VendorReturnDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        VendorReturnDataCommand.Parameters.Add("@ReturnDate", SqlDbType.VarChar).Value = DateSelection

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PurchaseData = CDbl(PurchaseDataCommand.ExecuteScalar)
        Catch ex As Exception
            PurchaseData = 0
        End Try
        Try
            ReceiptData = CDbl(ReceiptDataCommand.ExecuteScalar)
        Catch ex As Exception
            ReceiptData = 0
        End Try
        Try
            VendorReturnData = CDbl(VendorReturnDataCommand.ExecuteScalar)
        Catch ex As Exception
            VendorReturnData = 0
        End Try
        con.Close()

        txtPurchaseOrders.Text = FormatCurrency(PurchaseData, 2)
        txtReceipts.Text = FormatCurrency(ReceiptData, 2)
        txtVendorReturns.Text = FormatCurrency(VendorReturnData, 2)
    End Sub

    Public Sub LoadProductionData()
        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            Dim ProductionUnitsStatement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE DivisionID = @DivisionID AND PostingDate = @PostingDate"
            Dim ProductionUnitsCommand As New SqlCommand(ProductionUnitsStatement, con)
            ProductionUnitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ProductionUnitsCommand.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpDateSelection.Text

            Dim InventoryUnitsStatement As String = "SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData WHERE DivisionID = @DivisionID AND PostingDate = @PostingDate"
            Dim InventoryUnitsCommand As New SqlCommand(InventoryUnitsStatement, con)
            InventoryUnitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            InventoryUnitsCommand.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpDateSelection.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductionUnits = CDbl(ProductionUnitsCommand.ExecuteScalar)
            Catch ex As Exception
                ProductionUnits = 0
            End Try
            Try
                InventoryUnits = CDbl(InventoryUnitsCommand.ExecuteScalar)
            Catch ex As Exception
                InventoryUnits = 0
            End Try
            con.Close()

            txtProductionUnits.Text = FormatNumber(ProductionUnits, 0)
            txtInventoryUnits.Text = FormatNumber(InventoryUnits, 0)
        Else
            txtProductionUnits.Text = 0
            txtInventoryUnits.Text = 0
        End If
    End Sub

    Public Sub LoadARData()
        DateSelection = dtpDateSelection.Value

        Dim ARPaymentsReceivedStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPaymentQuery WHERE DivisionID = @DivisionID AND PaymentDate = @PaymentDate"
        Dim ARPaymentsReceivedCommand As New SqlCommand(ARPaymentsReceivedStatement, con)
        ARPaymentsReceivedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ARPaymentsReceivedCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = DateSelection

        Dim AgingLessThan30Statement As String = "SELECT SUM(AgingLessThan30) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim AgingLessThan30Command As New SqlCommand(AgingLessThan30Statement, con)
        AgingLessThan30Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Aging31To45Statement As String = "SELECT SUM(Aging31To45) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim Aging31To45Command As New SqlCommand(Aging31To45Statement, con)
        Aging31To45Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Aging46To60Statement As String = "SELECT SUM(Aging46To60) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim Aging46To60Command As New SqlCommand(Aging46To60Statement, con)
        Aging46To60Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Aging61To90Statement As String = "SELECT SUM(Aging61To90) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim Aging61To90Command As New SqlCommand(Aging61To90Statement, con)
        Aging61To90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim AgingMoreThan90Statement As String = "SELECT SUM(AgingMoreThan90) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim AgingMoreThan90Command As New SqlCommand(AgingMoreThan90Statement, con)
        AgingMoreThan90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ARPaymentsReceived = CDbl(ARPaymentsReceivedCommand.ExecuteScalar)
        Catch ex As Exception
            ARPaymentsReceived = 0
        End Try
        Try
            AgingLessThan30 = CDbl(AgingLessThan30Command.ExecuteScalar)
        Catch ex As Exception
            AgingLessThan30 = 0
        End Try
        Try
            Aging31To45 = CDbl(Aging31To45Command.ExecuteScalar)
        Catch ex As Exception
            Aging31To45 = 0
        End Try
        Try
            Aging46To60 = CDbl(Aging46To60Command.ExecuteScalar)
        Catch ex As Exception
            Aging46To60 = 0
        End Try
        Try
            Aging61To90 = CDbl(Aging61To90Command.ExecuteScalar)
        Catch ex As Exception
            Aging61To90 = 0
        End Try
        Try
            AgingMoreThan90 = CDbl(AgingMoreThan90Command.ExecuteScalar)
        Catch ex As Exception
            AgingMoreThan90 = 0
        End Try
        con.Close()

        TotalReceivables = AgingLessThan30 + Aging31To45 + Aging46To60 + Aging61To90 + AgingMoreThan90

        txtARPaymentsReceived.Text = FormatCurrency(ARPaymentsReceived, 2)
        txtAR3145.Text = FormatCurrency(Aging31To45, 2)
        txtAR4660.Text = FormatCurrency(Aging46To60, 2)
        txtAR6190.Text = FormatCurrency(Aging61To90, 2)
        txtARLess30.Text = FormatCurrency(AgingLessThan30, 2)
        txtARMore90.Text = FormatCurrency(AgingMoreThan90, 2)
        txtTotalReceivables.Text = FormatCurrency(TotalReceivables, 2)
    End Sub

    Public Sub LoadAPData()
        DateSelection = dtpDateSelection.Value

        Dim APPaymentsMadeStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
        Dim APPaymentsMadeCommand As New SqlCommand(APPaymentsMadeStatement, con)
        APPaymentsMadeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        APPaymentsMadeCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = DateSelection

        Dim APAgingLessThan30Statement As String = "SELECT SUM(AgingLessThan30) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAgingLessThan30Command As New SqlCommand(APAgingLessThan30Statement, con)
        APAgingLessThan30Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim APAging31To45Statement As String = "SELECT SUM(Aging31To45) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAging31To45Command As New SqlCommand(APAging31To45Statement, con)
        APAging31To45Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim APAging46To60Statement As String = "SELECT SUM(Aging46To60) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAging46To60Command As New SqlCommand(APAging46To60Statement, con)
        APAging46To60Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim APAging61To90Statement As String = "SELECT SUM(Aging61To90) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAging61To90Command As New SqlCommand(APAging61To90Statement, con)
        APAging61To90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim APAgingMoreThan90Statement As String = "SELECT SUM(AgingMoreThan90) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAgingMoreThan90Command As New SqlCommand(APAgingMoreThan90Statement, con)
        APAgingMoreThan90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            APPaymentsMade = CDbl(APPaymentsMadeCommand.ExecuteScalar)
        Catch ex As Exception
            APPaymentsMade = 0
        End Try
        Try
            APAgingLessThan30 = CDbl(APAgingLessThan30Command.ExecuteScalar)
        Catch ex As Exception
            APAgingLessThan30 = 0
        End Try
        Try
            APAging31To45 = CDbl(APAging31To45Command.ExecuteScalar)
        Catch ex As Exception
            APAging31To45 = 0
        End Try
        Try
            APAging46To60 = CDbl(APAging46To60Command.ExecuteScalar)
        Catch ex As Exception
            APAging46To60 = 0
        End Try
        Try
            APAging61To90 = CDbl(APAging61To90Command.ExecuteScalar)
        Catch ex As Exception
            APAging61To90 = 0
        End Try
        Try
            APAgingMoreThan90 = CDbl(APAgingMoreThan90Command.ExecuteScalar)
        Catch ex As Exception
            APAgingMoreThan90 = 0
        End Try
        con.Close()

        TotalPayables = APAgingLessThan30 + APAging31To45 + APAging46To60 + APAging61To90 + APAgingMoreThan90

        txtAPPaymentsMade.Text = FormatCurrency(APPaymentsMade, 2)
        txtAP3145.Text = FormatCurrency(APAging31To45, 2)
        txtAP4660.Text = FormatCurrency(APAging46To60, 2)
        txtAP6190.Text = FormatCurrency(APAging61To90, 2)
        txtAPLess30.Text = FormatCurrency(APAgingLessThan30, 2)
        txtAPMore90.Text = FormatCurrency(APAgingMoreThan90, 2)
        txtPayableTotal.Text = FormatCurrency(TotalPayables, 2)
    End Sub

    Public Sub LoadMTDYTDSalesData()
        DateSelection = dtpDateSelection.Value

        'Variables to calculate MTD and YTD Sales
        Dim YearDate, MonthDate, BeginDate, EndDate As Date
        Dim YearOfYear, MonthOfYear, Year As Integer
        Dim strMonthOfYear, strYear As String
        Dim MTDSales, YTDSales As Double

        'Calculate MTD Totals
        MonthDate = dtpDateSelection.Value
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = DateSelection

        Dim MTDSalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDSalesCommand As New SqlCommand(MTDSalesStatement, con)
        MTDSalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        MTDSalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDSales = CDbl(MTDSalesCommand.ExecuteScalar)
        Catch ex As Exception
            MTDSales = 0
        End Try
        con.Close()
        txtMTDSales.Text = FormatCurrency(MTDSales, 2)

        'Calculate YTD Totals
        YearDate = dtpDateSelection.Value
        YearOfYear = YearDate.Year
        strYear = CStr(YearOfYear)

        If YearDate < "05/01/" + strYear Then
            YearOfYear = YearOfYear - 1
            strYear = CStr(YearOfYear)
        Else
            'Do nothing
        End If

        BeginDate = "05/01/" + strYear
        EndDate = DateSelection

        Dim YTDSalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDSalesCommand As New SqlCommand(YTDSalesStatement, con)
        YTDSalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        YTDSalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDSales = CDbl(YTDSalesCommand.ExecuteScalar)
        Catch ex As Exception
            YTDSales = 0
        End Try
        con.Close()

        txtYTDSales.Text = FormatCurrency(YTDSales, 2)
    End Sub

    Public Sub LoadMTDYTDPurchaseData()
        DateSelection = dtpDateSelection.Value

        'Variables to calculate MTD and YTD Purchases
        Dim YearDate, MonthDate, BeginDate, EndDate As Date
        Dim YearOfYear, MonthOfYear, Year As Integer
        Dim strMonthOfYear, strYear As String
        Dim MTDPurchases, YTDPurchases As Double

        'Calculate MTD Totals
        MonthDate = dtpDateSelection.Value
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = DateSelection

        Dim MTDPurchasesStatement As String = "SELECT SUM(POTotal) FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID AND PODate BETWEEN @BeginDate AND @EndDate"
        Dim MTDPurchasesCommand As New SqlCommand(MTDPurchasesStatement, con)
        MTDPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDPurchases = CDbl(MTDPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            MTDPurchases = 0
        End Try
        con.Close()
        txtMTDPurchases.Text = FormatCurrency(MTDPurchases, 2)

        'Calculate YTD Totals
        YearDate = dtpDateSelection.Value
        YearOfYear = YearDate.Year
        strYear = CStr(YearOfYear)

        If YearDate < "05/01/" + strYear Then
            YearOfYear = YearOfYear - 1
            strYear = CStr(YearOfYear)
        Else
            'Do nothing
        End If

        BeginDate = "05/01/" + strYear
        EndDate = DateSelection

        Dim YTDPurchasesStatement As String = "SELECT SUM(POTotal) FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID AND PODate BETWEEN @BeginDate AND @EndDate"
        Dim YTDPurchasesCommand As New SqlCommand(YTDPurchasesStatement, con)
        YTDPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDPurchases = CDbl(YTDPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            YTDPurchases = 0
        End Try
        con.Close()

        txtYTDPurchases.Text = FormatCurrency(YTDPurchases, 2)
    End Sub

    Public Sub LoadMTDYTDShipmentData()
        DateSelection = dtpDateSelection.Value

        'Variables to calculate MTD and YTD Purchases
        Dim YearDate, MonthDate, BeginDate, EndDate As Date
        Dim YearOfYear, MonthOfYear, Year As Integer
        Dim strMonthOfYear, strYear As String
        Dim MTDShipments, YTDShipments As Double

        'Calculate MTD Totals
        MonthDate = dtpDateSelection.Value
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = DateSelection

        Dim MTDShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND ShipmentStatus <> @ShipmentStatus AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDShipmentsCommand As New SqlCommand(MTDShipmentsStatement, con)
        MTDShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDShipmentsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDShipmentsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        MTDShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDShipments = CDbl(MTDShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            MTDShipments = 0
        End Try
        con.Close()
        txtMTDShipments.Text = FormatCurrency(MTDShipments, 2)

        'Calculate YTD Totals
        YearDate = dtpDateSelection.Value
        YearOfYear = YearDate.Year
        strYear = CStr(YearOfYear)

        If YearDate < "05/01/" + strYear Then
            YearOfYear = YearOfYear - 1
            strYear = CStr(YearOfYear)
        Else
            'Do nothing
        End If

        BeginDate = "05/01/" + strYear
        EndDate = DateSelection

        Dim YTDShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND ShipmentStatus <> @ShipmentStatus AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDShipmentsCommand As New SqlCommand(YTDShipmentsStatement, con)
        YTDShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDShipmentsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDShipmentsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        YTDShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDShipments = CDbl(YTDShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            YTDShipments = 0
        End Try
        con.Close()

        txtYTDShipments.Text = FormatCurrency(YTDShipments, 2)
    End Sub

    Public Sub LoadMTDYTDInvoiceData()
        DateSelection = dtpDateSelection.Value

        'Variables to calculate MTD and YTD Purchases
        Dim YearDate, MonthDate, BeginDate, EndDate As Date
        Dim YearOfYear, MonthOfYear, Year As Integer
        Dim strMonthOfYear, strYear As String
        Dim MTDInvoices, YTDInvoices As Double

        'Calculate MTD Totals
        MonthDate = dtpDateSelection.Value
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = DateSelection

        Dim MTDInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDInvoicesCommand As New SqlCommand(MTDInvoicesStatement, con)
        MTDInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDInvoicesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDInvoicesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDInvoices = CDbl(MTDInvoicesCommand.ExecuteScalar)
        Catch ex As Exception
            MTDInvoices = 0
        End Try
        con.Close()
        txtMTDInvoices.Text = FormatCurrency(MTDInvoices, 2)

        'Calculate YTD Totals
        YearDate = dtpDateSelection.Value
        YearOfYear = YearDate.Year
        strYear = CStr(YearOfYear)

        If YearDate < "05/01/" + strYear Then
            YearOfYear = YearOfYear - 1
            strYear = CStr(YearOfYear)
        Else
            'Do nothing
        End If

        BeginDate = "05/01/" + strYear
        EndDate = DateSelection

        Dim YTDInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDInvoicesCommand As New SqlCommand(YTDInvoicesStatement, con)
        YTDInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDInvoicesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDInvoicesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDInvoices = CDbl(YTDInvoicesCommand.ExecuteScalar)
        Catch ex As Exception
            YTDInvoices = 0
        End Try
        con.Close()

        txtYTDInvoices.Text = FormatCurrency(YTDInvoices, 2)
    End Sub

    Public Sub LoadMTDYTDReceiverData()
        DateSelection = dtpDateSelection.Value

        'Variables to calculate MTD and YTD Purchases
        Dim YearDate, MonthDate, BeginDate, EndDate As Date
        Dim YearOfYear, MonthOfYear, Year As Integer
        Dim strMonthOfYear, strYear As String
        Dim MTDReceivers, YTDReceivers As Double

        'Calculate MTD Totals
        MonthDate = dtpDateSelection.Value
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = DateSelection

        Dim MTDReceiversStatement As String = "SELECT SUM(POTotal) FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDReceiversCommand As New SqlCommand(MTDReceiversStatement, con)
        MTDReceiversCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDReceiversCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDReceiversCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDReceivers = CDbl(MTDReceiversCommand.ExecuteScalar)
        Catch ex As Exception
            MTDReceivers = 0
        End Try
        con.Close()
        txtMTDReceivers.Text = FormatCurrency(MTDReceivers, 2)

        'Calculate YTD Totals
        YearDate = dtpDateSelection.Value
        YearOfYear = YearDate.Year
        strYear = CStr(YearOfYear)

        If YearDate < "05/01/" + strYear Then
            YearOfYear = YearOfYear - 1
            strYear = CStr(YearOfYear)
        Else
            'Do nothing
        End If

        BeginDate = "05/01/" + strYear
        EndDate = DateSelection

        Dim YTDReceiversStatement As String = "SELECT SUM(POTotal) FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDReceiversCommand As New SqlCommand(YTDReceiversStatement, con)
        YTDReceiversCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDReceiversCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDReceiversCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDReceivers = CDbl(YTDReceiversCommand.ExecuteScalar)
        Catch ex As Exception
            YTDReceivers = 0
        End Try
        con.Close()

        txtYTDReceivers.Text = FormatCurrency(YTDReceivers, 2)
    End Sub

    Public Sub LoadMTDYTDProductionData()
        DateSelection = dtpDateSelection.Value

        'Variables to calculate MTD and YTD Purchases
        Dim YearDate, MonthDate, BeginDate, EndDate As Date
        Dim YearOfYear, MonthOfYear, Year As Integer
        Dim strMonthOfYear, strYear As String
        Dim MTDProduction, YTDProduction As Double

        'Calculate MTD Totals
        MonthDate = dtpDateSelection.Value
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = DateSelection

        Dim MTDProductionStatement As String = "SELECT SUM(ExtendedCost) FROM TimeSlipCombinedData WHERE DivisionID = @DivisionID AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDProductionCommand As New SqlCommand(MTDProductionStatement, con)
        MTDProductionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDProductionCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDProductionCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDProduction = CDbl(MTDProductionCommand.ExecuteScalar)
        Catch ex As Exception
            MTDProduction = 0
        End Try
        con.Close()
        txtMTDProduction.Text = FormatCurrency(MTDProduction, 2)

        'Calculate YTD Totals
        YearDate = dtpDateSelection.Value
        YearOfYear = YearDate.Year
        strYear = CStr(YearOfYear)

        If YearDate < "05/01/" + strYear Then
            YearOfYear = YearOfYear - 1
            strYear = CStr(YearOfYear)
        Else
            'Do nothing
        End If

        BeginDate = "05/01/" + strYear
        EndDate = DateSelection

        Dim YTDProductionStatement As String = "SELECT SUM(ExtendedCost) FROM TimeSlipCombinedData WHERE DivisionID = @DivisionID AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDProductionCommand As New SqlCommand(YTDProductionStatement, con)
        YTDProductionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDProductionCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDProductionCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDProduction = CDbl(YTDProductionCommand.ExecuteScalar)
        Catch ex As Exception
            YTDProduction = 0
        End Try
        con.Close()

        txtYTDProduction.Text = FormatCurrency(YTDProduction, 2)
    End Sub

    Public Sub LoadInventoryTotalQuantity()
        Dim InventoryTotalPiecesStatement As String = "SELECT SUM(QuantityOnHand) FROM ADMInventoryTotal WHERE DivisionID = @DivisionID"
        Dim InventoryTotalPiecesCommand As New SqlCommand(InventoryTotalPiecesStatement, con)
        InventoryTotalPiecesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InventoryTotalPieces = CDbl(InventoryTotalPiecesCommand.ExecuteScalar)
        Catch ex As Exception
            InventoryTotalPieces = 0
        End Try
        con.Close()

        InventoryTotalPieces = Math.Round(InventoryTotalPieces, 0)
        txtInventoryQuantity.Text = InventoryTotalPieces
    End Sub

    Public Sub LoadRawMaterialTotal()
        DateSelection = dtpDateSelection.Value

        Dim TotalRMDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND GLAccountNumber = @GLAccountNumber"
        Dim TotalRMDebitsCommand As New SqlCommand(TotalRMDebitsStatement, con)
        TotalRMDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalRMDebitsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        TotalRMDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"

        Dim TotalRMCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND GLAccountNumber = @GLAccountNumber"
        Dim TotalRMCreditsCommand As New SqlCommand(TotalRMCreditsStatement, con)
        TotalRMCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalRMCreditsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        TotalRMCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalRMDebits = CDbl(TotalRMDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            TotalRMDebits = 0
        End Try
        Try
            TotalRMCredits = CDbl(TotalRMCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            TotalRMCredits = 0
        End Try
        con.Close()

        RawMaterialTotal = TotalRMDebits - TotalRMCredits
        txtRawMaterialTotal.Text = FormatCurrency(RawMaterialTotal, 2)
    End Sub

    Public Sub LoadInventoryValuation()
        Dim T1AmericanCredits, T1AmericanDebits, T2AmericanCredits, T2AmericanDebits, AmericanConsignmentCredits, AmericanConsignmentDebits, T1CanadianCredits, T1CanadianDebits, T2CanadianCredits, T2CanadianDebits, CanadianConsignmentCredits, CanadianConsignmentDebits As Double

        DateSelection = dtpDateSelection.Value

        'Get Inventory (12001 - 12599)
        Dim T1AmericanDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber1)"
        Dim T1AmericanDebitsCommand As New SqlCommand(T1AmericanDebitsStatement, con)
        T1AmericanDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        T1AmericanDebitsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        T1AmericanDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12001"
        T1AmericanDebitsCommand.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "12599"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            T1AmericanDebits = CDbl(T1AmericanDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            T1AmericanDebits = 0
        End Try
        con.Close()

        Dim T1AmericanCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber1)"
        Dim T1AmericanCreditsCommand As New SqlCommand(T1AmericanCreditsStatement, con)
        T1AmericanCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        T1AmericanCreditsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        T1AmericanCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12001"
        T1AmericanCreditsCommand.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "12599"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            T1AmericanCredits = CDbl(T1AmericanCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            T1AmericanCredits = 0
        End Try
        con.Close()

        'Get Consignment Inventory (12600 - 12690)
        Dim AmericanConsignmentDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2)"
        Dim AmericanConsignmentDebitsCommand As New SqlCommand(AmericanConsignmentDebitsStatement, con)
        AmericanConsignmentDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AmericanConsignmentDebitsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        AmericanConsignmentDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12600"
        AmericanConsignmentDebitsCommand.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = "12690"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AmericanConsignmentDebits = CDbl(AmericanConsignmentDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            AmericanConsignmentDebits = 0
        End Try
        con.Close()

        Dim AmericanConsignmentCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2)"
        Dim AmericanConsignmentCreditsCommand As New SqlCommand(AmericanConsignmentCreditsStatement, con)
        AmericanConsignmentCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AmericanConsignmentCreditsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        AmericanConsignmentCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12600"
        AmericanConsignmentCreditsCommand.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = "12690"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AmericanConsignmentCredits = CDbl(AmericanConsignmentCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            AmericanConsignmentCredits = 0
        End Try
        con.Close()

        'Get Inventory (12800 - 12999)
        Dim T2AmericanDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2)"
        Dim T2AmericanDebitsCommand As New SqlCommand(T2AmericanDebitsStatement, con)
        T2AmericanDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        T2AmericanDebitsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        T2AmericanDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12800"
        T2AmericanDebitsCommand.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = "12999"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            T2AmericanDebits = CDbl(T2AmericanDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            T2AmericanDebits = 0
        End Try
        con.Close()

        Dim T2AmericanCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2)"
        Dim T2AmericanCreditsCommand As New SqlCommand(T2AmericanCreditsStatement, con)
        T2AmericanCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        T2AmericanCreditsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        T2AmericanCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12800"
        T2AmericanCreditsCommand.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = "12999"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            T2AmericanCredits = CDbl(T2AmericanCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            T2AmericanCredits = 0
        End Try
        con.Close()

        'Get Canadian Inventory (C$12001 - C$12599)
        Dim T1CanadianDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber1)"
        Dim T1CanadianDebitsCommand As New SqlCommand(T1CanadianDebitsStatement, con)
        T1CanadianDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        T1CanadianDebitsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        T1CanadianDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$12001"
        T1CanadianDebitsCommand.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "C$12599"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            T1CanadianDebits = CDbl(T1CanadianDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            T1CanadianDebits = 0
        End Try
        con.Close()

        Dim T1CanadianCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber1)"
        Dim T1CanadianCreditsCommand As New SqlCommand(T1CanadianCreditsStatement, con)
        T1CanadianCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        T1CanadianCreditsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        T1CanadianCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$12001"
        T1CanadianCreditsCommand.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "C$12599"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            T1CanadianCredits = CDbl(T1CanadianCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            T1CanadianCredits = 0
        End Try
        con.Close()

        'Get Canadian Consignment Inventory (C$12600 - C$12690)
        Dim CanadianConsignmentDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2)"
        Dim CanadianConsignmentDebitsCommand As New SqlCommand(CanadianConsignmentDebitsStatement, con)
        CanadianConsignmentDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CanadianConsignmentDebitsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        CanadianConsignmentDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$12600"
        CanadianConsignmentDebitsCommand.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = "C$12690"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CanadianConsignmentDebits = CDbl(CanadianConsignmentDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            CanadianConsignmentDebits = 0
        End Try
        con.Close()

        Dim CanadianConsignmentCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2)"
        Dim CanadianConsignmentCreditsCommand As New SqlCommand(CanadianConsignmentCreditsStatement, con)
        CanadianConsignmentCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CanadianConsignmentCreditsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        CanadianConsignmentCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$12600"
        CanadianConsignmentCreditsCommand.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = "C$12690"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CanadianConsignmentCredits = CDbl(CanadianConsignmentCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            CanadianConsignmentCredits = 0
        End Try
        con.Close()

        'Get Canadian Inventory (C$12800 - C$12999)
        Dim T2CanadianDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2)"
        Dim T2CanadianDebitsCommand As New SqlCommand(T2CanadianDebitsStatement, con)
        T2CanadianDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        T2CanadianDebitsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        T2CanadianDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$12800"
        T2CanadianDebitsCommand.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = "C$12999"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            T2CanadianDebits = CDbl(T2CanadianDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            T2CanadianDebits = 0
        End Try
        con.Close()

        Dim T2CanadianCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLTransactionDate <= @SelectDate AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2)"
        Dim T2CanadianCreditsCommand As New SqlCommand(T2CanadianCreditsStatement, con)
        T2CanadianCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        T2CanadianCreditsCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateSelection
        T2CanadianCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$12800"
        T2CanadianCreditsCommand.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = "C$12999"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            T2CanadianCredits = CDbl(T2CanadianCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            T2CanadianCredits = 0
        End Try
        con.Close()
        '***************************************************************************************
        InventoryTotal = (T1AmericanDebits + T2AmericanDebits + T1CanadianDebits + T2CanadianDebits) - (T1AmericanCredits + T2AmericanCredits + T1CanadianCredits + T2CanadianCredits)
        ConsignmentInventoryTotal = (AmericanConsignmentDebits + CanadianConsignmentDebits) - (AmericanConsignmentCredits + CanadianConsignmentCredits)

        txtValueByGL.Text = FormatCurrency(InventoryTotal, 2)
        txtConsignmentInventory.Text = FormatCurrency(ConsignmentInventoryTotal, 2)
    End Sub

    Private Sub dtpDateSelection_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateSelection.ValueChanged
        LoadAPData()
        LoadARData()
        LoadProductionData()
        LoadPurchaseData()
        LoadSalesData()
        LoadMTDYTDSalesData()
        LoadMTDYTDPurchaseData()
        LoadMTDYTDShipmentData()
        LoadMTDYTDProductionData()
        LoadMTDYTDInvoiceData()
        LoadMTDYTDReceiverData()
        'LoadInventoryTotalQuantity()
        LoadInventoryValuation()
        LoadRawMaterialTotal()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadAPData()
        LoadARData()
        LoadProductionData()
        LoadPurchaseData()
        LoadSalesData()
        LoadMTDYTDSalesData()
        LoadMTDYTDPurchaseData()
        LoadMTDYTDShipmentData()
        LoadMTDYTDProductionData()
        LoadMTDYTDInvoiceData()
        LoadMTDYTDReceiverData()
        'LoadInventoryTotalQuantity()
        LoadInventoryValuation()
        LoadRawMaterialTotal()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub MonthSnapshotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthSnapshotToolStripMenuItem.Click
        Dim NewMonthSnapshot As New MonthSnapshot
        NewMonthSnapshot.Show()
    End Sub
End Class