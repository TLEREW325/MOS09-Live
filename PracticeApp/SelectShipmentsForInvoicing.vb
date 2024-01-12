Imports System
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class SelectShipmentsForInvoicing
    Inherits System.Windows.Forms.Form

    Dim CountSerialLineNumber, LastTransactionNumber, NextTransactionNumber, CountNumber, ShipmentLineNumber As Integer
    Dim ThirdPartyShipper, ShipMethod, CustomerClass, FOB, SerialNumber, PaymentTerms, PartNumber, PartDescription, LineComment, GLDebitAccount, GLCreditAccount As String
    Dim SOLineNumber As Integer
    Dim Price, LineWeight, QuantityShipped, LineBoxes, SalesTax, ExtendedAmount, ExtendedCOS, UpdatedInvoiceTotal, SumExtendedInvoiceAmount, SumExtendedAmount, SumExtendedCOS As Double
    Dim BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, nmyAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim ShipDate As Date

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment.Substring(0, 300)
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub LoadShipments()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus ORDER BY ShipmentNumber ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
        cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")
        dgvShipmentHeader.DataSource = ds.Tables("ShipmentHeaderTable")
        con.Close()
    End Sub

    Private Sub SelectShipmentsForInvoicing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()
        GlobalVerifyCode = "FAILED"

        LoadShipments()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim NewARProcessBatch As New ARProcessBatch
        NewARProcessBatch.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdProcessForInvoicing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcessForInvoicing.Click
        'Variables for Shipment Invoicing
        Dim ShipmentNumber, SalesOrderKey, CountLotLineNumber As Integer
        Dim SpecialInstructions, Comment, PRONumber, ShipVia, CustomerID, ShipToID, CustomerPO As String
        Dim FreightActualAmount, ProductTotal, TaxTotal, Tax2Total, Tax3Total, ShipmentTotal As Double
        Dim CheckForInvoice As Integer = 0

        'Verify that an Invoice with the same shipment number does not already exist
        For Each row As DataGridViewRow In dgvShipmentHeader.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")

            If cell.Value = "SELECTED" Then
                Try
                    ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                Catch ex As Exception
                    ShipmentNumber = 0
                End Try

                'Check for Invoice for shipment
                Dim CheckForInvoiceString As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim CheckForInvoiceCommand As New SqlCommand(CheckForInvoiceString, con)
                CheckForInvoiceCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                CheckForInvoiceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckForInvoice = CInt(CheckForInvoiceCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckForInvoice = 0
                End Try
                con.Close()

                If CheckForInvoice = 0 Then
                    'Continue
                Else
                    MsgBox("An Invoice already exists for one or more shipments in this batch. Check open batches or contact System Administrator.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        Next

        'Retrieve Header data from Shipment Table and write to Invoicing Table
        For Each row As DataGridViewRow In dgvShipmentHeader.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")

            LastTransactionNumber = 0

            If cell.Value = "SELECTED" Then
                Try
                    ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                Catch ex As Exception
                    ShipmentNumber = 0
                End Try
                Try
                    SalesOrderKey = row.Cells("SalesOrderKeyColumn").Value
                Catch ex As Exception
                    SalesOrderKey = 0
                End Try
                Try
                    Comment = row.Cells("CommentColumn").Value
                Catch ex As Exception
                    Comment = ""
                End Try
                Try
                    ShipVia = row.Cells("ShipViaColumn").Value
                Catch ex As Exception
                    ShipVia = ""
                End Try
                Try
                    PRONumber = row.Cells("PRONumberColumn").Value
                Catch ex As Exception
                    PRONumber = ""
                End Try
                Try
                    FreightActualAmount = row.Cells("FreightActualAmountColumn").Value
                Catch ex As Exception
                    FreightActualAmount = 0
                End Try
                Try
                    CustomerID = row.Cells("CustomerIDColumn").Value
                Catch ex As Exception
                    CustomerID = ""
                End Try
                Try
                    ShipToID = row.Cells("ShipToIDColumn").Value
                Catch ex As Exception
                    ShipToID = ""
                End Try
                Try
                    CustomerPO = row.Cells("CustomerPOColumn").Value
                Catch ex As Exception
                    CustomerPO = ""
                End Try
                Try
                    ProductTotal = row.Cells("ProductTotalColumn").Value
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                Try
                    TaxTotal = row.Cells("TaxTotalColumn").Value
                Catch ex As Exception
                    TaxTotal = 0
                End Try
                Try
                    ShipmentTotal = row.Cells("ShipmentTotalColumn").Value
                Catch ex As Exception
                    ShipmentTotal = 0
                End Try
                Try
                    Tax2Total = row.Cells("Tax2TotalColumn").Value
                Catch ex As Exception
                    Tax2Total = 0
                End Try
                Try
                    Tax3Total = row.Cells("Tax3TotalColumn").Value
                Catch ex As Exception
                    Tax3Total = 0
                End Try
                Try
                    ShipDate = row.Cells("ShipDateColumn").Value
                Catch ex As Exception
                    ShipDate = Today()
                End Try
                Try
                    CustomerClass = row.Cells("CustomerClassColumn").Value
                Catch ex As Exception
                    CustomerClass = "STANDARD"
                End Try
                Try
                    FOB = row.Cells("FOBColumn").Value
                Catch ex As Exception
                    FOB = ""
                End Try
                Try
                    SpecialInstructions = row.Cells("SpecialInstructionsColumn").Value
                Catch ex As Exception
                    SpecialInstructions = ""
                End Try
                Try
                    ShipMethod = row.Cells("ShippingMethodColumn").Value
                Catch ex As Exception
                    ShipMethod = ""
                End Try
                Try
                    ThirdPartyShipper = row.Cells("ThirdPartyShipperColumn").Value
                Catch ex As Exception
                    ThirdPartyShipper = ""
                End Try
                If CustomerID = "" Then
                    MsgBox("One of more shipments do not have a valid customer.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Verify Line Total for Product Total
                Dim SumExtendedAmountString As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim SumExtendedAmountCommand As New SqlCommand(SumExtendedAmountString, con)
                SumExtendedAmountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                SumExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumExtendedAmount = CDbl(SumExtendedAmountCommand.ExecuteScalar)
                Catch ex As Exception
                    SumExtendedAmount = 0
                End Try
                con.Close()

                'Verify Line COS for Total COS
                Dim SumExtendedCOSString As String = "SELECT SUM(ExtendedCOS) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim SumExtendedCOSCommand As New SqlCommand(SumExtendedCOSString, con)
                SumExtendedCOSCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                SumExtendedCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumExtendedCOS = CDbl(SumExtendedCOSCommand.ExecuteScalar)
                Catch ex As Exception
                    SumExtendedCOS = 0
                End Try
                con.Close()

                'Declare variables to calculate Sales Tax from Sales Order
                Dim SalesTaxRate1, SalesTaxRate2, SalesTaxRate3 As Double

                'Verify that Sales Tax is calculated correctly from the Sales Order
                If GlobalARDivisionCode = "TOR" Or GlobalARDivisionCode = "TFF" Or GlobalARDivisionCode = "ALB" Then
                    Dim SalesTaxRate1Statement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                    Dim SalesTaxRate1Command As New SqlCommand(SalesTaxRate1Statement, con)
                    SalesTaxRate1Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                    SalesTaxRate1Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalARDivisionCode

                    Dim SalesTaxRate2Statement As String = "SELECT TaxRate2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                    Dim SalesTaxRate2Command As New SqlCommand(SalesTaxRate2Statement, con)
                    SalesTaxRate2Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                    SalesTaxRate2Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalARDivisionCode

                    Dim SalesTaxRate3Statement As String = "SELECT TaxRate3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                    Dim SalesTaxRate3Command As New SqlCommand(SalesTaxRate3Statement, con)
                    SalesTaxRate3Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                    SalesTaxRate3Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalARDivisionCode

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SalesTaxRate1 = CDbl(SalesTaxRate1Command.ExecuteScalar)
                    Catch ex As Exception
                        SalesTaxRate1 = 0
                    End Try
                    Try
                        SalesTaxRate2 = CDbl(SalesTaxRate2Command.ExecuteScalar)
                    Catch ex As Exception
                        SalesTaxRate2 = 0
                    End Try
                    Try
                        SalesTaxRate3 = CDbl(SalesTaxRate3Command.ExecuteScalar)
                    Catch ex As Exception
                        SalesTaxRate3 = 0
                    End Try
                    con.Close()

                    TaxTotal = SalesTaxRate1 * (SumExtendedAmount + FreightActualAmount)
                    Tax2Total = SalesTaxRate2 * (SumExtendedAmount + FreightActualAmount)
                    Tax3Total = SalesTaxRate3 * (SumExtendedAmount + FreightActualAmount)
                Else
                    Dim SalesTaxRate1Statement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                    Dim SalesTaxRate1Command As New SqlCommand(SalesTaxRate1Statement, con)
                    SalesTaxRate1Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                    SalesTaxRate1Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalARDivisionCode

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SalesTaxRate1 = CDbl(SalesTaxRate1Command.ExecuteScalar)
                    Catch ex As Exception
                        SalesTaxRate1 = 0
                    End Try
                    con.Close()

                    TaxTotal = SalesTaxRate1 * SumExtendedAmount
                    Tax2Total = 0
                    Tax3Total = 0
                End If

                ProductTotal = SumExtendedAmount
                ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total

                'Round variables to 2 digits
                FreightActualAmount = Math.Round(FreightActualAmount, 2)
                ProductTotal = Math.Round(ProductTotal, 2)
                TaxTotal = Math.Round(TaxTotal, 2)
                Tax2Total = Math.Round(Tax2Total, 2)
                Tax3Total = Math.Round(Tax3Total, 2)
                ShipmentTotal = Math.Round(ShipmentTotal, 2)

                'Extract Customer Bill To details
                Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
                BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
                BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
                BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
                BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
                BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                Dim BillToCountryStatement As String = "SELECT BillToCountry FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim BillToCountryCommand As New SqlCommand(BillToCountryStatement, con)
                BillToCountryCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                BillToCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
                PaymentTermsCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
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
                Try
                    BillToCountry = CStr(BillToCountryCommand.ExecuteScalar)
                Catch ex As Exception
                    BillToCountry = ""
                End Try
                Try
                    PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
                    If PaymentTerms = "" Then PaymentTerms = "N30"
                Catch ex As Exception
                    PaymentTerms = "N30"
                End Try
                con.Close()
                '*****************************************************************************************************
                Try
                    'Find the next Invoice Number to use
                    Dim MAXStatement As String = "SELECT MAX(InvoiceNumber) FROM InvoiceHeaderTable"
                    Dim MAXCommand As New SqlCommand(MAXStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
                    Catch ex7 As Exception
                        LastTransactionNumber = 85200000
                    End Try
                    con.Close()

                    NextTransactionNumber = LastTransactionNumber + 1

                    'Write Header data to new table
                    cmd = New SqlCommand("Insert Into InvoiceHeaderTable(InvoiceNumber, BatchNumber, InvoiceDate, SalesOrderNumber, ShipmentNumber, DivisionID, CustomerID, CustomerPO, PaymentTerms, Comment, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, ProductTotal, BilledFreight, SalesTax, Discount, InvoiceTotal, InvoiceStatus, ShipVia, PaymentsApplied, InvoiceCOS, PRONumber, SpecialInstructions, DropShipPONumber, SalesTax2, SalesTax3, ReprintBatch, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper)Values(@InvoiceNumber, @BatchNumber, @InvoiceDate, @SalesOrderNumber, @ShipmentNumber, @DivisionID, @CustomerID, @CustomerPO, @PaymentTerms, @Comment, @BTAddress1, @BTAddress2, @BTCity, @BTState, @BTZip, @BTCountry, @ProductTotal, @BilledFreight, @SalesTax, @Discount, @InvoiceTotal, @InvoiceStatus, @ShipVia, @PaymentsApplied, @InvoiceCOS, @PRONumber, @SpecialInstructions, @DropShipPONumber, @SalesTax2, @SalesTax3, @ReprintBatch, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper)", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalARBatchNumber
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = ShipDate
                        .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = SalesOrderKey
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
                        .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                        .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                        .Add("@Comment", SqlDbType.VarChar).Value = Comment
                        .Add("@BTAddress1", SqlDbType.VarChar).Value = BillToAddress1
                        .Add("@BTAddress2", SqlDbType.VarChar).Value = BillToAddress2
                        .Add("@BTCity", SqlDbType.VarChar).Value = BillToCity
                        .Add("@BTState", SqlDbType.VarChar).Value = BillToState
                        .Add("@BTZip", SqlDbType.VarChar).Value = BillToZip
                        .Add("@BTCountry", SqlDbType.VarChar).Value = BillToCountry
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@BilledFreight", SqlDbType.VarChar).Value = FreightActualAmount
                        .Add("@SalesTax", SqlDbType.VarChar).Value = TaxTotal
                        .Add("@Discount", SqlDbType.VarChar).Value = 0
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = ShipmentTotal
                        .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
                        .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                        .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
                        .Add("@InvoiceCOS", SqlDbType.VarChar).Value = SumExtendedCOS
                        .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                        .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                        .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                        .Add("@SalesTax2", SqlDbType.VarChar).Value = Tax2Total
                        .Add("@SalesTax3", SqlDbType.VarChar).Value = Tax3Total
                        .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                        .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                        .Add("@FOB", SqlDbType.VarChar).Value = FOB
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShipMethod
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'UPDATE ShipmentHeader so they cannot be selected again
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                        .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    Try
                        'Find the next Invoice Number to use
                        Dim MAXStatement As String = "SELECT MAX(InvoiceNumber) FROM InvoiceHeaderTable"
                        Dim MAXCommand As New SqlCommand(MAXStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
                        Catch ex7 As Exception
                            LastTransactionNumber = 85200000
                        End Try
                        con.Close()

                        NextTransactionNumber = LastTransactionNumber + 1

                        'Write Header data to new table
                        cmd = New SqlCommand("Insert Into InvoiceHeaderTable(InvoiceNumber, BatchNumber, InvoiceDate, SalesOrderNumber, ShipmentNumber, DivisionID, CustomerID, CustomerPO, PaymentTerms, Comment, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, ProductTotal, BilledFreight, SalesTax, Discount, InvoiceTotal, InvoiceStatus, ShipVia, PaymentsApplied, InvoiceCOS, PRONumber, SpecialInstructions, DropShipPONumber, SalesTax2, SalesTax3, ReprintBatch, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper)Values(@InvoiceNumber, @BatchNumber, @InvoiceDate, @SalesOrderNumber, @ShipmentNumber, @DivisionID, @CustomerID, @CustomerPO, @PaymentTerms, @Comment, @BTAddress1, @BTAddress2, @BTCity, @BTState, @BTZip, @BTCountry, @ProductTotal, @BilledFreight, @SalesTax, @Discount, @InvoiceTotal, @InvoiceStatus, @ShipVia, @PaymentsApplied, @InvoiceCOS, @PRONumber, @SpecialInstructions, @DropShipPONumber, @SalesTax2, @SalesTax3, @ReprintBatch, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper)", con)

                        With cmd.Parameters
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalARBatchNumber
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = SalesOrderKey
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
                            .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                            .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                            .Add("@Comment", SqlDbType.VarChar).Value = Comment
                            .Add("@BTAddress1", SqlDbType.VarChar).Value = BillToAddress1
                            .Add("@BTAddress2", SqlDbType.VarChar).Value = BillToAddress2
                            .Add("@BTCity", SqlDbType.VarChar).Value = BillToCity
                            .Add("@BTState", SqlDbType.VarChar).Value = BillToState
                            .Add("@BTZip", SqlDbType.VarChar).Value = BillToZip
                            .Add("@BTCountry", SqlDbType.VarChar).Value = BillToCountry
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                            .Add("@BilledFreight", SqlDbType.VarChar).Value = FreightActualAmount
                            .Add("@SalesTax", SqlDbType.VarChar).Value = TaxTotal
                            .Add("@Discount", SqlDbType.VarChar).Value = 0
                            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = ShipmentTotal
                            .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                            .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
                            .Add("@InvoiceCOS", SqlDbType.VarChar).Value = SumExtendedCOS
                            .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                            .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                            .Add("@SalesTax2", SqlDbType.VarChar).Value = Tax2Total
                            .Add("@SalesTax3", SqlDbType.VarChar).Value = Tax3Total
                            .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                            .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                            .Add("@FOB", SqlDbType.VarChar).Value = FOB
                            .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShipMethod
                            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'UPDATE ShipmentHeader so they cannot be selected again
                        cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber", con)

                        With cmd.Parameters
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex2 As Exception
                        'Log error on update failure
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = NextTransactionNumber
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = GlobalARDivisionCode
                        ErrorDescription = "Select Shipments for Invoicing --- Insert Invoice Header Failure"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End Try
                '************************************************************************************************************************************
                'Find the number of Shipment Lines to add to the Invoice Line Table
                Dim CountLineStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber"
                Dim CountLineCommand As New SqlCommand(CountLineStatement, con)
                CountLineCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountNumber = CInt(CountLineCommand.ExecuteScalar)
                Catch ex As Exception
                    CountNumber = 1
                End Try
                con.Close()

                ShipmentLineNumber = 1

                For i As Integer = 1 To CountNumber
                    Dim PartNumberString As String = "SELECT PartNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim PartNumberCommand As New SqlCommand(PartNumberString, con)
                    PartNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    PartNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim PartDescriptionString As String = "SELECT PartDescription FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim PartDescriptionCommand As New SqlCommand(PartDescriptionString, con)
                    PartDescriptionCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    PartDescriptionCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim QuantityShippedString As String = "SELECT QuantityShipped FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim QuantityShippedCommand As New SqlCommand(QuantityShippedString, con)
                    QuantityShippedCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    QuantityShippedCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim PriceString As String = "SELECT Price FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim PriceCommand As New SqlCommand(PriceString, con)
                    PriceCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    PriceCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim LineCommentString As String = "SELECT LineComment FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim LineCommentCommand As New SqlCommand(LineCommentString, con)
                    LineCommentCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    LineCommentCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim LineWeightString As String = "SELECT LineWeight FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim LineWeightCommand As New SqlCommand(LineWeightString, con)
                    LineWeightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    LineWeightCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim LineBoxesString As String = "SELECT LineBoxes FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim LineBoxesCommand As New SqlCommand(LineBoxesString, con)
                    LineBoxesCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    LineBoxesCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim SalesTaxString As String = "SELECT SalesTax FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim SalesTaxCommand As New SqlCommand(SalesTaxString, con)
                    SalesTaxCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    SalesTaxCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim ExtendedAmountString As String = "SELECT ExtendedAmount FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim ExtendedAmountCommand As New SqlCommand(ExtendedAmountString, con)
                    ExtendedAmountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    ExtendedAmountCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim GLDebitAccountString As String = "SELECT GLDebitAccount FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim GLDebitAccountCommand As New SqlCommand(GLDebitAccountString, con)
                    GLDebitAccountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    GLDebitAccountCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim GLCreditAccountString As String = "SELECT GLCreditAccount FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim GLCreditAccountCommand As New SqlCommand(GLCreditAccountString, con)
                    GLCreditAccountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    GLCreditAccountCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim ExtendedCOSString As String = "SELECT ExtendedCOS FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim ExtendedCOSCommand As New SqlCommand(ExtendedCOSString, con)
                    ExtendedCOSCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    ExtendedCOSCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim SOLineNumberString As String = "SELECT SOLineNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim SOLineNumberCommand As New SqlCommand(SOLineNumberString, con)
                    SOLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    SOLineNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    Dim SerialNumberString As String = "SELECT SerialNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim SerialNumberCommand As New SqlCommand(SerialNumberString, con)
                    SerialNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    SerialNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PartNumber = CStr(PartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        PartNumber = ""
                    End Try
                    Try
                        PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
                    Catch ex As Exception
                        PartDescription = ""
                    End Try
                    Try
                        QuantityShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
                    Catch ex As Exception
                        QuantityShipped = 0
                    End Try
                    Try
                        Price = CDbl(PriceCommand.ExecuteScalar)
                    Catch ex As Exception
                        Price = 0
                    End Try
                    Try
                        LineComment = CStr(LineCommentCommand.ExecuteScalar)
                    Catch ex As Exception
                        LineComment = 0
                    End Try
                    Try
                        LineWeight = CDbl(LineWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        LineWeight = 0
                    End Try
                    Try
                        LineBoxes = CDbl(LineBoxesCommand.ExecuteScalar)
                    Catch ex As Exception
                        LineBoxes = 0
                    End Try
                    Try
                        SalesTax = CDbl(SalesTaxCommand.ExecuteScalar)
                    Catch ex As Exception
                        SalesTax = 0
                    End Try
                    Try
                        ExtendedAmount = CDbl(ExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ExtendedAmount = 0
                    End Try
                    Try
                        GLDebitAccount = CStr(GLDebitAccountCommand.ExecuteScalar)
                    Catch ex As Exception
                        GLDebitAccount = ""
                    End Try
                    Try
                        GLCreditAccount = CStr(GLCreditAccountCommand.ExecuteScalar)
                    Catch ex As Exception
                        GLCreditAccount = ""
                    End Try
                    Try
                        ExtendedCOS = CDbl(ExtendedCOSCommand.ExecuteScalar)
                    Catch ex As Exception
                        ExtendedCOS = 0
                    End Try
                    Try
                        SOLineNumber = CInt(SOLineNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        SOLineNumber = 0
                    End Try
                    Try
                        SerialNumber = CStr(SerialNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        SerialNumber = ""
                    End Try
                    con.Close()

                    'Round Line items to two decimals
                    ExtendedCOS = Math.Round(ExtendedCOS, 2)
                    SalesTax = Math.Round(SalesTax, 2)
                    Price = Math.Round(Price, 5)
                    ExtendedAmount = Price * QuantityShipped
                    ExtendedAmount = Math.Round(ExtendedAmount, 2)

                    Try
                        'Write Shipment Lines to Invoice Line Table
                        cmd = New SqlCommand("Insert Into InvoiceLineTable (InvoiceHeaderKey, InvoiceLineKey, PartNumber, PartDescription, QuantityBilled, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, ExtendedCOS, SOLineNumber, SerialNumber)Values(@InvoiceHeaderKey, @InvoiceLineKey, @PartNumber, @PartDescription, @QuantityBilled, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @ExtendedCOS, @SOLineNumber, @SerialNumber)", con)

                        With cmd.Parameters
                            .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = ShipmentLineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@QuantityBilled", SqlDbType.VarChar).Value = QuantityShipped
                            .Add("@Price", SqlDbType.VarChar).Value = Price
                            .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                            .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxes
                            .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
                            .Add("@DebitGLAccount", SqlDbType.VarChar).Value = GLDebitAccount
                            .Add("@CreditGLAccount", SqlDbType.VarChar).Value = GLCreditAccount
                            .Add("@ExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS
                            .Add("@SOLineNumber", SqlDbType.VarChar).Value = SOLineNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = NextTransactionNumber
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = GlobalARDivisionCode
                        ErrorDescription = "Select Shipments for Invoicing --- Insert Invoice Line Failure"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '*******************************************************************************************************************************
                    'Copy any Lot Numbers over to Invoice Lot Line Table
                    Dim CountLotLineStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim CountLotLineCommand As New SqlCommand(CountLotLineStatement, con)
                    CountLotLineCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    CountLotLineCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountLotLineNumber = CInt(CountLotLineCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountLotLineNumber = 0
                    End Try
                    con.Close()

                    If CountLotLineNumber = 0 Then
                        'Skip - no lot lines
                    Else
                        Dim ShipmentLotLineNumber As Integer = 1
                        Dim ShipmentLotNumber As String = ""
                        Dim ShipmentHeatQuantity As Double = 0
                        Dim ShipmentHeatNumber As String = ""

                        For i2 As Integer = 1 To CountLotLineNumber

                            'Get Lot Number / Heat Quantity
                            Dim ShipmentLotNumberString As String = "SELECT LotNumber FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotLineNumber = @LotLineNumber"
                            Dim ShipmentLotNumberCommand As New SqlCommand(ShipmentLotNumberString, con)
                            ShipmentLotNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            ShipmentLotNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                            ShipmentLotNumberCommand.Parameters.Add("@LotLineNumber", SqlDbType.VarChar).Value = ShipmentLotLineNumber

                            Dim ShipmentHeatQuantityString As String = "SELECT HeatQuantity FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotLineNumber = @LotLineNumber"
                            Dim ShipmentHeatQuantityCommand As New SqlCommand(ShipmentHeatQuantityString, con)
                            ShipmentHeatQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            ShipmentHeatQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                            ShipmentHeatQuantityCommand.Parameters.Add("@LotLineNumber", SqlDbType.VarChar).Value = ShipmentLotLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ShipmentLotNumber = CStr(ShipmentLotNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                ShipmentLotNumber = ""
                            End Try
                            Try
                                ShipmentHeatQuantity = CDbl(ShipmentHeatQuantityCommand.ExecuteScalar)
                            Catch ex As Exception
                                ShipmentHeatQuantity = 0
                            End Try
                            con.Close()

                            'Get Heat Number
                            Dim GetHeatNumberString As String = "SELECT HeatNumber FROM LotNumber WHERE LotNumber = @LotNumber"
                            Dim GetHeatNumberCommand As New SqlCommand(GetHeatNumberString, con)
                            GetHeatNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = ShipmentLotNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ShipmentHeatNumber = CStr(GetHeatNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                ShipmentHeatNumber = ""
                            End Try
                            con.Close()

                            Try
                                'Write to Invoice Lot Number Table
                                cmd = New SqlCommand("Insert Into InvoiceLotLineTable (InvoiceNumber, InvoiceLineNumber, InvoiceLotLineNumber, InvoiceLotNumber, InvoiceHeatNumber, InvoiceHeatQuantity)Values(@InvoiceNumber, @InvoiceLineNumber, @InvoiceLotLineNumber, @InvoiceLotNumber, @InvoiceHeatNumber, @InvoiceHeatQuantity)", con)

                                With cmd.Parameters
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                                    .Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                                    .Add("@InvoiceLotLineNumber", SqlDbType.VarChar).Value = ShipmentLotLineNumber
                                    .Add("@InvoiceLotNumber", SqlDbType.VarChar).Value = ShipmentLotNumber
                                    .Add("@InvoiceHeatNumber", SqlDbType.VarChar).Value = ShipmentHeatNumber
                                    .Add("@InvoiceHeatQuantity", SqlDbType.VarChar).Value = ShipmentHeatQuantity
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Skip
                            End Try

                            'Clear Variables
                            ShipmentLotNumber = ""
                            ShipmentHeatQuantity = 0
                            ShipmentHeatNumber = ""

                            'Advance count to next Lot Line Number
                            ShipmentLotLineNumber = ShipmentLotLineNumber + 1
                        Next i2
                    End If
                    '*************************************************************************************************************************
                    'Copy any Serial Numbers over to Invoice Serial Line Table
                    Dim CountSerialLineStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim CountSerialLineCommand As New SqlCommand(CountSerialLineStatement, con)
                    CountSerialLineCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    CountSerialLineCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountSerialLineNumber = CInt(CountSerialLineCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountSerialLineNumber = 0
                    End Try
                    con.Close()

                    If CountSerialLineNumber = 0 Then
                        'Skip - no Serial Lines
                    Else
                        Dim ShipmentSerialLineNumber As Integer = 1
                        Dim ShipmentSerialNumber As String = ""
                        Dim ShipmentSerialQuantity As Double = 0

                        For i3 As Integer = 1 To CountSerialLineNumber

                            'Get Serial Number
                            Dim ShipmentLotNumberString As String = "SELECT SerialNumber FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND SerialLineNumber = @SerialLineNumber"
                            Dim ShipmentLotNumberCommand As New SqlCommand(ShipmentLotNumberString, con)
                            ShipmentLotNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                            ShipmentLotNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                            ShipmentLotNumberCommand.Parameters.Add("@SerialLineNumber", SqlDbType.VarChar).Value = ShipmentSerialLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ShipmentSerialNumber = CStr(ShipmentLotNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                ShipmentSerialNumber = ""
                            End Try
                            con.Close()
                            '***************************************************************************************
                            'Get Serial Cost
                            Dim SerialNumberCost As Double = 0

                            Dim SerialNumberCostString As String = "SELECT TotalCost FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber"
                            Dim SerialNumberCostCommand As New SqlCommand(SerialNumberCostString, con)
                            SerialNumberCostCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = ShipmentSerialNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                SerialNumberCost = CDbl(SerialNumberCostCommand.ExecuteScalar)
                            Catch ex As Exception
                                SerialNumberCost = 0
                            End Try
                            con.Close()
                            '***************************************************************************************
                            Try
                                'Write to Invoice Serial Number Table
                                cmd = New SqlCommand("Insert Into InvoiceSerialLineTable (InvoiceNumber, InvoiceLineNumber, InvoiceSerialLineNumber, InvoiceSerialNumber, InvoiceShipmentNumber, SerialNumberCost, SerialNumberQuantity)Values(@InvoiceNumber, @InvoiceLineNumber, @InvoiceSerialLineNumber, @InvoiceSerialNumber, @InvoiceShipmentNumber, @SerialNumberCost, @SerialNumberQuantity)", con)

                                With cmd.Parameters
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                                    .Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                                    .Add("@InvoiceSerialLineNumber", SqlDbType.VarChar).Value = ShipmentSerialLineNumber
                                    .Add("@InvoiceSerialNumber", SqlDbType.VarChar).Value = ShipmentSerialNumber
                                    .Add("@InvoiceShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                                    .Add("@SerialNumberCost", SqlDbType.VarChar).Value = SerialNumberCost
                                    .Add("@SerialNumberQuantity", SqlDbType.VarChar).Value = 1
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Skip
                            End Try

                            'Clear Variables
                            ShipmentSerialNumber = ""
                            SerialNumberCost = 0

                            'Advance count to next Lot Line Number
                            ShipmentSerialLineNumber = ShipmentSerialLineNumber + 1
                        Next i3
                    End If
                    '*********************************************************************************************************************
                    'Advance count to next line number
                    ShipmentLineNumber = ShipmentLineNumber + 1
                Next i
                '*********************************************************************************************************************************
                'Update Invoice Header Table
                Dim SumExtendedInvoiceAmountString As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                Dim SumExtendedInvoiceAmountCommand As New SqlCommand(SumExtendedInvoiceAmountString, con)
                SumExtendedInvoiceAmountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                SumExtendedInvoiceAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumExtendedInvoiceAmount = CDbl(SumExtendedInvoiceAmountCommand.ExecuteScalar)
                Catch ex As Exception
                    SumExtendedInvoiceAmount = 0
                End Try
                con.Close()

                UpdatedInvoiceTotal = SumExtendedInvoiceAmount + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total

                'UPDATE Invoice Header with Totals
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedInvoiceAmount
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = UpdatedInvoiceTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            'Clear Variables before next entry
            ThirdPartyShipper = ""
            ShipMethod = ""
            ShipmentNumber = 0
            SalesOrderKey = 0
            CountLotLineNumber = 0
            Comment = ""
            PRONumber = ""
            ShipVia = ""
            CustomerID = ""
            ShipToID = ""
            CustomerPO = ""
            FreightActualAmount = 0
            ProductTotal = 0
            TaxTotal = 0
            Tax2Total = 0
            Tax3Total = 0
            ShipmentTotal = 0
            NextTransactionNumber = 0
            LastTransactionNumber = 0
            CountNumber = 0
            ShipmentLineNumber = 0
            CustomerClass = ""
            FOB = ""
            SerialNumber = ""
            PaymentTerms = ""
            PartNumber = ""
            PartDescription = ""
            LineComment = ""
            GLDebitAccount = ""
            GLCreditAccount = ""
            SOLineNumber = 0
            Price = 0
            LineWeight = 0
            QuantityShipped = 0
            LineBoxes = 0
            SalesTax = 0
            ExtendedAmount = 0
            ExtendedCOS = 0
            UpdatedInvoiceTotal = 0
            SumExtendedInvoiceAmount = 0
            SumExtendedAmount = 0
            SumExtendedCOS = 0
            BillToAddress1 = ""
            BillToAddress2 = ""
            BillToCity = ""
            BillToState = ""
            BillToZip = ""
            BillToCountry = ""
        Next

        Try
            'Total Invoices
            cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceTotal = ProductTotal + BilledFreight + SalesTax + SalesTax2 + SalesTax3 - Discount WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalARBatchNumber

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Do nothing
        End Try

        MsgBox("Shipments have been processed for Invoicing", MsgBoxStyle.OkOnly)

        Dim NewARProcessBatch As New ARProcessBatch
        NewARProcessBatch.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        For Each row As DataGridViewRow In dgvShipmentHeader.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdUnCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnCheckAll.Click
        For Each row As DataGridViewRow In dgvShipmentHeader.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        ' The return value specifies the previous state of the menu item (it is either      
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.      
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub

    Private Sub LoginPage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub
End Class