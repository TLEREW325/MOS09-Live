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
Public Class SelectCustomerReturnsForCredit
    Inherits System.Windows.Forms.Form

    Dim MaxPONumber, ReturnLineNumber, CountNumber, LastTransactionNumber, NextTransactionNumber, ReturnNumber As Integer
    Dim LineComment, CustomerClass, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry As String
    Dim PartNumber, Description, DebitGLAccount, CreditGLAccount As String
    Dim Quantity, ExtendedCOS, UnitPrice, ExtendedAmount, SalesTax, SumExtendedCOS As Double

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub LoadReturns()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM ReturnProductHeaderTable WHERE DivisionID = @DivisionID AND ReturnStatus = @ReturnStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
        cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "PENDING"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReturnProductHeaderTable")
        dgvCustomerReturns.DataSource = ds.Tables("ReturnProductHeaderTable")
        con.Close()
    End Sub

    Public Sub LoadTempSerialLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM AssemblySerialTempTable WHERE DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
        cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = ReturnNumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "AssemblySerialTempTable")
        dgvSerialLines.DataSource = ds1.Tables("AssemblySerialTempTable")
        con.Close()
    End Sub

    Private Sub SelectCustomerReturnsForCredit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Disable Close Button on form
        Me.CenterToScreen()
        Call Disable(Me)
        GlobalVerifyCode = "FAILED"
        LoadReturns()
    End Sub

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        For Each row As DataGridViewRow In dgvCustomerReturns.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForProcessing")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdUnCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnCheckAll.Click
        For Each row As DataGridViewRow In dgvCustomerReturns.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForProcessing")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim NewARProcessBatch As New ARProcessBatch
        NewARProcessBatch.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
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

    Private Sub cmdProcessForCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcessForCredit.Click
        ReturnNumber = 0
        Dim SalesTaxTotal As Double = 0
        Dim SalesTax2Total As Double = 0
        Dim SalesTax3Total As Double = 0
        Dim ProductTotal As Double = 0
        Dim FreightTotal As Double = 0
        Dim ReturnTotal As Double = 0
        Dim SalesOrderNumber As Integer = 0
        Dim FOB As String = ""
        Dim CustomerPO As String = ""

        Dim ReturnDate, CustomerID, Salesperson, Reason, ReturnStatus As String

        'Retrieve Header data from Shipment Table and write to Invoicing Table
        For Each row As DataGridViewRow In dgvCustomerReturns.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForProcessing")

            If cell.Value = "SELECTED" Then
                Try
                    ReturnNumber = row.Cells("ReturnNumberColumn").Value
                Catch ex As Exception
                    ReturnNumber = 0
                End Try
                Try
                    ReturnDate = row.Cells("ReturnDateColumn").Value
                Catch ex As Exception
                    ReturnDate = ""
                End Try
                Try
                    CustomerID = row.Cells("CustomerIDColumn").Value
                Catch ex As Exception
                    CustomerID = ""
                End Try
                Try
                    SalesOrderNumber = row.Cells("SalesOrderNumberColumn").Value
                Catch ex As Exception
                    SalesOrderNumber = 0
                End Try
                Try
                    Salesperson = row.Cells("SalespersonColumn").Value
                Catch ex As Exception
                    Salesperson = EmployeeSalespersonCode
                End Try
                Try
                    ProductTotal = row.Cells("ProductTotalColumn").Value
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                Try
                    FreightTotal = row.Cells("FreightTotalColumn").Value
                Catch ex As Exception
                    FreightTotal = 0
                End Try
                Try
                    SalesTaxTotal = row.Cells("SalesTaxTotalColumn").Value
                Catch ex As Exception
                    SalesTaxTotal = 0
                End Try
                Try
                    SalesTax2Total = row.Cells("SalesTax2TotalColumn").Value
                Catch ex As Exception
                    SalesTax2Total = 0
                End Try
                Try
                    SalesTax3Total = row.Cells("SalesTax3TotalColumn").Value
                Catch ex As Exception
                    SalesTax3Total = 0
                End Try
                Try
                    ReturnTotal = row.Cells("ReturnTotalColumn").Value
                Catch ex As Exception
                    ReturnTotal = 0
                End Try
                Try
                    Reason = row.Cells("ReasonColumn").Value
                Catch ex As Exception
                    Reason = ""
                End Try
                Try
                    ReturnStatus = row.Cells("ReturnStatusColumn").Value
                Catch ex As Exception
                    ReturnStatus = "PENDING"
                End Try
                Try
                    CustomerClass = row.Cells("CustomerClassColumn").Value
                Catch ex As Exception
                    CustomerClass = "STANDARD"
                End Try
                Try
                    FOB = row.Cells("FOBColumn").Value
                Catch ex As Exception
                    FOB = "Medina"
                End Try
                Try
                    CustomerPO = row.Cells("CustomerPOColumn").Value
                Catch ex As Exception
                    CustomerPO = ""
                End Try
                '*********************************************************************************************************************
                Dim RecheckCustomerClass As String = ""

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

                Dim RecheckCustomerClassStatement As String = "SELECT RecheckCustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim RecheckCustomerClassCommand As New SqlCommand(RecheckCustomerClassStatement, con)
                RecheckCustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                RecheckCustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

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
                    RecheckCustomerClass = CStr(RecheckCustomerClassCommand.ExecuteScalar)
                Catch ex As Exception
                    RecheckCustomerClass = "STANDARD"
                End Try
                con.Close()
                '*********************************************************************************************************************
                If CustomerClass = "" Then
                    CustomerClass = RecheckCustomerClass
                End If
                '*********************************************************************************************************************
                'Define FOB from the name
                Select Case FOB
                    Case "HCW"
                        FOB = "Hayward"
                    Case "DCW"
                        FOB = "Downey"
                    Case "LCW"
                        FOB = "Lewisville"
                    Case "LSCW"
                        FOB = "Lake Stevens"
                    Case "RCW"
                        FOB = "Renton"
                    Case "PCW"
                        FOB = "Phoenix"
                    Case "YCW"
                        FOB = "Lyndhurst"
                    Case "BCW"
                        FOB = "Bessemer"
                    Case "SCW"
                        FOB = "Seattle"
                    Case Else
                        'Do nothing
                End Select
                '*********************************************************************************************************************
                'Find the next Invoice Number to use
                Dim MAXStatement As String = "SELECT MAX(InvoiceNumber) FROM InvoiceHeaderTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As Exception
                    LastTransactionNumber = 85200000
                End Try
                con.Close()

                NextTransactionNumber = LastTransactionNumber + 1

                'Write Line data to new table
                cmd = New SqlCommand("INSERT INTO InvoiceHeaderTable(InvoiceNumber, BatchNumber, InvoiceDate, SalesOrderNumber, ShipmentNumber, DivisionID, CustomerID, CustomerPO, PaymentTerms, Comment, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, ProductTotal, BilledFreight, SalesTax, Discount, InvoiceTotal, InvoiceStatus, ShipVia, PaymentsApplied, InvoiceCOS, PRONumber, SpecialInstructions, DropShipPONumber, SalesTax2, SalesTax3, ReprintBatch, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper, EmailSent)Values(@InvoiceNumber, @BatchNumber, @InvoiceDate, @SalesOrderNumber, @ShipmentNumber, @DivisionID, @CustomerID, @CustomerPO, @PaymentTerms, @Comment, @BTAddress1, @BTAddress2, @BTCity, @BTState, @BTZip, @BTCountry, @ProductTotal, @BilledFreight, @SalesTax, @Discount, @InvoiceTotal, @InvoiceStatus, @ShipVia, @PaymentsApplied, @InvoiceCOS, @PRONumber, @SpecialInstructions, @DropShipPONumber, @SalesTax2, @SalesTax3, @ReprintBatch, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper, @EmailSent)", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalARBatchNumber
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = Today()
                    .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = SalesOrderNumber
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ReturnNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
                    .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
                    .Add("@Comment", SqlDbType.VarChar).Value = Reason
                    .Add("@BTAddress1", SqlDbType.VarChar).Value = BillToAddress1
                    .Add("@BTAddress2", SqlDbType.VarChar).Value = BillToAddress2
                    .Add("@BTCity", SqlDbType.VarChar).Value = BillToCity
                    .Add("@BTState", SqlDbType.VarChar).Value = BillToState
                    .Add("@BTZip", SqlDbType.VarChar).Value = BillToZip
                    .Add("@BTCountry", SqlDbType.VarChar).Value = BillToCountry
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal * -1
                    .Add("@BilledFreight", SqlDbType.VarChar).Value = FreightTotal * -1
                    .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTaxTotal * -1
                    .Add("@Discount", SqlDbType.VarChar).Value = 0
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = ReturnTotal * -1
                    .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
                    .Add("@ShipVia", SqlDbType.VarChar).Value = "DELIVERY"
                    .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
                    .Add("@InvoiceCOS", SqlDbType.VarChar).Value = 0
                    .Add("@PRONumber", SqlDbType.VarChar).Value = ""
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = "CREDIT"
                    .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                    .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2Total * -1
                    .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3Total * -1
                    .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                    .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                    .Add("@FOB", SqlDbType.VarChar).Value = FOB
                    .Add("@ShippingMethod", SqlDbType.VarChar).Value = "OTHER"
                    .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ""
                    .Add("@EmailSent", SqlDbType.VarChar).Value = ""
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*********************************************************************************************************************
                'UPDATE Return Lines so they cannot be selected again
                cmd = New SqlCommand("UPDATE ReturnProductLineTable SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber", con)

                With cmd.Parameters
                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*********************************************************************************************************************
                'UPDATE Return Line so they cannot be selected again
                cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber", con)

                With cmd.Parameters
                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    .Add("@ReturnStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*********************************************************************************************************************
                'Find the number of Return Lines to add to the Invoice Line Table
                Dim CountLineStatement As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber"
                Dim CountLineCommand As New SqlCommand(CountLineStatement, con)
                CountLineCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountNumber = CInt(CountLineCommand.ExecuteScalar)
                Catch ex As Exception
                    CountNumber = 1
                End Try
                con.Close()

                ReturnLineNumber = 1

                For i As Integer = 1 To CountNumber
                    Dim PartNumberString As String = "SELECT PartNumber FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim PartNumberCommand As New SqlCommand(PartNumberString, con)
                    PartNumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    PartNumberCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    Dim DescriptionString As String = "SELECT Description FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim DescriptionCommand As New SqlCommand(DescriptionString, con)
                    DescriptionCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    DescriptionCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    Dim QuantityString As String = "SELECT Quantity FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim QuantityCommand As New SqlCommand(QuantityString, con)
                    QuantityCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    QuantityCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    Dim UnitPriceString As String = "SELECT UnitPrice FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim UnitPriceCommand As New SqlCommand(UnitPriceString, con)
                    UnitPriceCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    UnitPriceCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    Dim SalesTaxString As String = "SELECT SalesTax FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim SalesTaxCommand As New SqlCommand(SalesTaxString, con)
                    SalesTaxCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    SalesTaxCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    Dim ExtendedAmountString As String = "SELECT ExtendedAmount FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim ExtendedAmountCommand As New SqlCommand(ExtendedAmountString, con)
                    ExtendedAmountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    ExtendedAmountCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    Dim DebitGLAccountString As String = "SELECT DebitGLAccount FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim DebitGLAccountCommand As New SqlCommand(DebitGLAccountString, con)
                    DebitGLAccountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    DebitGLAccountCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    Dim CreditGLAccountString As String = "SELECT CreditGLAccount FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim CreditGLAccountCommand As New SqlCommand(CreditGLAccountString, con)
                    CreditGLAccountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    CreditGLAccountCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    Dim ExtendedCOSString As String = "SELECT ExtendedCOS FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim ExtendedCOSCommand As New SqlCommand(ExtendedCOSString, con)
                    ExtendedCOSCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    ExtendedCOSCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    Dim LineCommentString As String = "SELECT LineComment FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
                    Dim LineCommentCommand As New SqlCommand(LineCommentString, con)
                    LineCommentCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                    LineCommentCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = ReturnLineNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PartNumber = CStr(PartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        PartNumber = ""
                    End Try
                    Try
                        Description = CStr(DescriptionCommand.ExecuteScalar)
                    Catch ex As Exception
                        Description = ""
                    End Try
                    Try
                        Quantity = CDbl(QuantityCommand.ExecuteScalar)
                    Catch ex As Exception
                        Quantity = 0
                    End Try
                    Try
                        UnitPrice = CDbl(UnitPriceCommand.ExecuteScalar)
                    Catch ex As Exception
                        UnitPrice = 0
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
                        DebitGLAccount = CStr(DebitGLAccountCommand.ExecuteScalar)
                    Catch ex As Exception
                        DebitGLAccount = "49999"
                    End Try
                    Try
                        CreditGLAccount = CStr(CreditGLAccountCommand.ExecuteScalar)
                    Catch ex As Exception
                        CreditGLAccount = "12100"
                    End Try
                    Try
                        ExtendedCOS = CDbl(ExtendedCOSCommand.ExecuteScalar)
                    Catch ex As Exception
                        ExtendedCOS = 0
                    End Try
                    Try
                        LineComment = CStr(LineCommentCommand.ExecuteScalar)
                    Catch ex As Exception
                        LineComment = "CUSTOMER RETURN"
                    End Try
                    con.Close()

                    'Check to see if Canadian
                    If GlobalARDivisionCode = "TFF" Or GlobalARDivisionCode = "TOR" Or GlobalARDivisionCode = "ALB" Then
                        SalesTax = 0
                        'Do not write line sales tax to invoice line table if canadian
                    End If

                    'Write Shipment Lines to Invoice Line Table
                    cmd = New SqlCommand("Insert Into InvoiceLineTable (InvoiceHeaderKey, InvoiceLineKey, PartNumber, PartDescription, QuantityBilled, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, ExtendedCOS)Values(@InvoiceHeaderKey, @InvoiceLineKey, @PartNumber, @PartDescription, @QuantityBilled, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @ExtendedCOS)", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                        .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = ReturnLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        .Add("@PartDescription", SqlDbType.VarChar).Value = Description
                        .Add("@QuantityBilled", SqlDbType.VarChar).Value = Quantity * -1
                        .Add("@Price", SqlDbType.VarChar).Value = UnitPrice
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                        .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                        .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                        .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax * -1
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount * -1
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = DebitGLAccount
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = CreditGLAccount
                        .Add("@ExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS * -1
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ReturnLineNumber = ReturnLineNumber + 1
                Next i
                '*****************************************************************************************
                'UPDATE Invoice Header Table with COS from Line Table
                Dim SumExtendedCOSStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                Dim SumExtendedCOSCommand As New SqlCommand(SumExtendedCOSStatement, con)
                SumExtendedCOSCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                SumExtendedCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumExtendedCOS = CDbl(SumExtendedCOSCommand.ExecuteScalar)
                Catch ex As Exception
                    SumExtendedCOS = 0
                End Try
                con.Close()

                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceCOS = @InvoiceCOS WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode
                    .Add("@InvoiceCOS", SqlDbType.VarChar).Value = SumExtendedCOS
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*****************************************************************************************
                'Check for serial numbers
                Dim CountSerialLines As Integer = 0

                Dim CountSerialLinesStatement As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialTempTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                Dim CountSerialLinesCommand As New SqlCommand(CountSerialLinesStatement, con)
                CountSerialLinesCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = ReturnNumber
                CountSerialLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalARDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountSerialLines = CInt(CountSerialLinesCommand.ExecuteScalar)
                Catch ex As Exception
                    CountSerialLines = 0
                End Try
                con.Close()

                If CountSerialLines = 0 Then
                    'No serial lines - continue
                Else
                    'Load Serial Temp Datagrid
                    LoadTempSerialLines()

                    'Extract Line Data from grid
                    Dim InvoiceLineNumber As Integer = 0
                    Dim InvoiceSerialNumber As String = ""
                    Dim InvoiceSerialLineNumber As Integer = 0
                    Dim SerialNumberCost As Double = 0

                    For Each SerialRow As DataGridViewRow In dgvSerialLines.Rows
                        Try
                            InvoiceLineNumber = SerialRow.Cells("BatchNumberColumn2").Value
                        Catch ex As Exception
                            InvoiceLineNumber = 0
                        End Try
                        Try
                            InvoiceSerialNumber = SerialRow.Cells("SerialNumberColumn2").Value
                        Catch ex As Exception
                            InvoiceSerialNumber = 0
                        End Try
                        Try
                            SerialNumberCost = SerialRow.Cells("TotalCostColumn2").Value
                        Catch ex As Exception
                            SerialNumberCost = 0
                        End Try
                        '****************************************************************************************
                        'Get Max Serial Line Number
                        Dim MAXSerialLineNumber As Integer = 0

                        Dim MAXSerialLineNumberStatement As String = "SELECT MAX(InvoiceSerialLineNumber) FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber AND InvoiceLineNumber = @InvoiceLineNumber"
                        Dim MAXSerialLineNumberCommand As New SqlCommand(MAXSerialLineNumberStatement, con)
                        MAXSerialLineNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                        MAXSerialLineNumberCommand.Parameters.Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = InvoiceLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MAXSerialLineNumber = CInt(MAXSerialLineNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            MAXSerialLineNumber = 0
                        End Try
                        con.Close()

                        InvoiceSerialLineNumber = MAXSerialLineNumber + 1
                      
                        Try
                            'Write to Invoice Serial Line Table
                            cmd = New SqlCommand("INSERT INTO InvoiceSerialLineTable (InvoiceNumber, InvoiceLineNumber, InvoiceSerialLineNumber, InvoiceSerialNumber, InvoiceShipmentNumber, SerialNumberCost, SerialNumberQuantity) values (@InvoiceNumber, @InvoiceLineNumber, @InvoiceSerialLineNumber, @InvoiceSerialNumber, @InvoiceShipmentNumber, @SerialNumberCost, @SerialNumberQuantity)", con)

                            With cmd.Parameters
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                                .Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = InvoiceLineNumber
                                .Add("@InvoiceSerialLineNumber", SqlDbType.VarChar).Value = InvoiceSerialLineNumber
                                .Add("@InvoiceSerialNumber", SqlDbType.VarChar).Value = InvoiceSerialNumber
                                .Add("@InvoiceShipmentNumber", SqlDbType.VarChar).Value = ReturnNumber
                                .Add("@SerialNumberCost", SqlDbType.VarChar).Value = SerialNumberCost
                                .Add("@SerialNumberQuantity", SqlDbType.VarChar).Value = 1
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error Log
                            Dim strInvoiceNumber As String = ""
                            Dim TempInvoiceNumber As Integer = 0

                            TempInvoiceNumber = NextTransactionNumber
                            strInvoiceNumber = CStr(TempInvoiceNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = GlobalARDivisionCode
                            ErrorDescription = "Add Serial# from Return to Credit"
                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        'Clear Variables before next re-iteration
                        MAXSerialLineNumber = 0
                        InvoiceSerialLineNumber = 0
                        InvoiceSerialNumber = ""
                        SerialNumberCost = 0
                    Next
                End If

                'Clear Variables for next return processed
                ReturnNumber = 0
                SalesTaxTotal = 0
                SalesTax2Total = 0
                SalesTax3Total = 0
                ProductTotal = 0
                FreightTotal = 0
                ReturnTotal = 0
                SalesOrderNumber = 0
                ReturnDate = ""
                CustomerID = ""
                Salesperson = ""
                Reason = ""
                ReturnStatus = ""
            End If
        Next

        MsgBox("Returns have been processed for Credit", MsgBoxStyle.OkOnly)

        Dim NewARProcessBatch As New ARProcessBatch
        NewARProcessBatch.Show()

        Me.Dispose()
        Me.Close()
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