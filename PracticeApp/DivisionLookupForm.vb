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
Public Class DivisionLookupForm
    Inherits System.Windows.Forms.Form

    Dim CountLookups As Integer = 0
    Dim CountPRONumber, CountARCheck, CountSalesOrder, CountShipment, CountPO, CountAR, CountAP, CountVendor, CountCustomer As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT DISTINCT VendorCode FROM Vendor WHERE DivisionID <> @DivisionID AND VendorClass <> @VendorClass ORDER BY VendorCode ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboVendorLookup.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboVendorLookup.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomer()
        cmd = New SqlCommand("SELECT DISTINCT CustomerID FROM CustomerList WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerLookup.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerLookup.SelectedIndex = -1
    End Sub

    Private Sub DivisionLookupForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdLookup

        'Load Vendor
        LoadVendor()

        'Load Customer
        LoadCustomer()

        txtPOLookup.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLookup.Click
        CountLookups = 0

        '************************************************************************
        If txtAPInvoiceLookup.Text = "" Then
            CountAP = 0
        Else
            CountAP = 1
        End If
        If txtARCheck.Text = "" Then
            CountARCheck = 0
        Else
            CountARCheck = 1
        End If
        If txtARInvoiceLookup.Text = "" Then
            CountAR = 0
        Else
            CountAR = 1
        End If
        If txtPOLookup.Text = "" Then
            CountPO = 0
        Else
            CountPO = 1
        End If
        If txtShipmentNumber.Text = "" Then
            CountShipment = 0
        Else
            CountShipment = 1
        End If
        If cboCustomerLookup.Text = "" Then
            CountCustomer = 0
        Else
            CountCustomer = 1
        End If
        If cboVendorLookup.Text = "" Then
            CountVendor = 0
        Else
            CountVendor = 1
        End If
        If txtSalesOrderNumber.Text = "" Then
            CountSalesOrder = 0
        Else
            CountSalesOrder = 1
        End If
        If txtPRONumber.Text = "" Then
            CountPRONumber = 0
        Else
            CountPRONumber = 1
        End If

        CountLookups = CountAP + CountAR + CountPO + CountCustomer + CountVendor + CountShipment + CountSalesOrder + CountARCheck + CountPRONumber

        If CountLookups = 0 Then
            MsgBox("You must select only one field.", MsgBoxStyle.OkOnly)
            Exit Sub
        ElseIf CountLookups = 1 Then
            'Continue
        ElseIf CountLookups > 1 Then
            MsgBox("You must select only one field to filter on.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '***********************************************************************************
        If txtPOLookup.Text <> "" Then
            Dim VendorID, PODate, PODivision As String

            Dim GetPODataString As String = "SELECT VendorID, DivisionID, PODate FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
            Dim GetPODataCommand As New SqlCommand(GetPODataString, con)
            GetPODataCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(txtPOLookup.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetPODataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("VendorID")) Then
                    VendorID = ""
                Else
                    VendorID = reader.Item("VendorID")
                End If
                If IsDBNull(reader.Item("DivisionID")) Then
                    PODivision = ""
                Else
                    PODivision = reader.Item("DivisionID")
                End If
                If IsDBNull(reader.Item("PODate")) Then
                    PODate = ""
                Else
                    PODate = reader.Item("PODate")
                End If
            Else
                VendorID = ""
                PODivision = ""
                PODate = ""
            End If
            reader.Close()
            con.Close()

            txtLookupDivision.Text = PODivision
            txtLookupNotes.Text = "This PO is for " + PODivision + " issued on " + PODate + " for " + VendorID
        ElseIf txtAPInvoiceLookup.Text <> "" Then
            Dim APVendorID, APDate, APDivision As String

            Dim GetAPDataString As String = "SELECT VendorID, DivisionID, InvoiceDate FROM ReceiptOfInvoiceBatchLine WHERE InvoiceNumber = @InvoiceNumber"
            Dim GetAPDataCommand As New SqlCommand(GetAPDataString, con)
            GetAPDataCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtAPInvoiceLookup.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetAPDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("VendorID")) Then
                    APVendorID = ""
                Else
                    APVendorID = reader.Item("VendorID")
                End If
                If IsDBNull(reader.Item("DivisionID")) Then
                    APDivision = ""
                Else
                    APDivision = reader.Item("DivisionID")
                End If
                If IsDBNull(reader.Item("InvoiceDate")) Then
                    APDate = ""
                Else
                    APDate = reader.Item("InvoiceDate")
                End If
            Else
                APVendorID = ""
                APDivision = ""
                APDate = ""
            End If
            reader.Close()
            con.Close()

            txtLookupDivision.Text = APDivision
            txtLookupNotes.Text = "This Invoice is for " + APDivision + " issued on " + APDate + " for " + APVendorID
        ElseIf txtPRONumber.Text <> "" Then
            Dim PROShipment, PROShipmentDate, PRODivision As String
            Dim FreightQuoteAmount, FreightActualAmount As Double

            Dim GetPRODataString As String = "SELECT ShipmentNumber, ShipDate, DivisionID, FreightQuoteAmount, FreightActualAmount FROM ShipmentHeaderTable WHERE PRONumber = @PRONumber"
            Dim GetPRODataCommand As New SqlCommand(GetPRODataString, con)
            GetPRODataCommand.Parameters.Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetPRODataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("ShipmentNumber")) Then
                    PROShipment = ""
                Else
                    PROShipment = reader.Item("ShipmentNumber")
                End If
                If IsDBNull(reader.Item("DivisionID")) Then
                    PRODivision = ""
                Else
                    PRODivision = reader.Item("DivisionID")
                End If
                If IsDBNull(reader.Item("ShipDate")) Then
                    PROShipmentDate = ""
                Else
                    PROShipmentDate = reader.Item("ShipDate")
                End If
                If IsDBNull(reader.Item("FreightActualAmount")) Then
                    FreightActualAmount = 0
                Else
                    FreightActualAmount = reader.Item("FreightActualAmount")
                End If
                If IsDBNull(reader.Item("FreightQuoteAmount")) Then
                    FreightQuoteAmount = 0
                Else
                    FreightQuoteAmount = reader.Item("FreightQuoteAmount")
                End If
            Else
                PROShipment = ""
                PRODivision = ""
                PROShipmentDate = ""
                FreightActualAmount = 0
                FreightQuoteAmount = 0
            End If
            reader.Close()
            con.Close()

            'Convert freight values to string
            Dim strFreightQuoteAmount As String = ""
            Dim strFreightActualAmount As String = ""

            strFreightActualAmount = CStr(FreightActualAmount)
            strFreightQuoteAmount = CStr(FreightQuoteAmount)

            txtLookupDivision.Text = PRODivision
            txtLookupNotes.Text = "This PRO # is for " + PRODivision + " issued on " + PROShipmentDate + " for Shipment # " + PROShipment + " -- Freight Quote Amount (" + strFreightQuoteAmount + ")" + " -- Billed Amount (" + strFreightActualAmount + ")"
        ElseIf txtARCheck.Text <> "" Then
            Dim CheckCustomer, CheckDivision, CheckDate As String

            Dim GetAPDataString As String = "SELECT CustomerID, PaymentDate, DivisionID FROM ARCustomerPayment WHERE CheckNumber = @CheckNumber"
            Dim GetAPDataCommand As New SqlCommand(GetAPDataString, con)
            GetAPDataCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = txtARCheck.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetAPDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("CustomerID")) Then
                    CheckCustomer = ""
                Else
                    CheckCustomer = reader.Item("CustomerID")
                End If
                If IsDBNull(reader.Item("DivisionID")) Then
                    CheckDivision = ""
                Else
                    CheckDivision = reader.Item("DivisionID")
                End If
                If IsDBNull(reader.Item("PaymentDate")) Then
                    CheckDate = ""
                Else
                    CheckDate = reader.Item("PaymentDate")
                End If
            Else
                CheckCustomer = ""
                CheckDivision = ""
                CheckDate = ""
            End If
            reader.Close()
            con.Close()

            txtLookupDivision.Text = CheckDivision
            txtLookupNotes.Text = "This check is for " + CheckDivision + " posted on " + CheckDate + " for " + CheckCustomer
        ElseIf txtARInvoiceLookup.Text <> "" Then
            Dim ARCustomerID, ARDate, ARDivision As String

            Dim GetARDataString As String = "SELECT CustomerID, DivisionID, InvoiceDate FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
            Dim GetARDataCommand As New SqlCommand(GetARDataString, con)
            GetARDataCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(txtARInvoiceLookup.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetARDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("CustomerID")) Then
                    ARCustomerID = ""
                Else
                    ARCustomerID = reader.Item("CustomerID")
                End If
                If IsDBNull(reader.Item("DivisionID")) Then
                    ARDivision = ""
                Else
                    ARDivision = reader.Item("DivisionID")
                End If
                If IsDBNull(reader.Item("InvoiceDate")) Then
                    ARDate = ""
                Else
                    ARDate = reader.Item("InvoiceDate")
                End If
            Else
                ARCustomerID = ""
                ARDivision = ""
                ARDate = ""
            End If
            reader.Close()
            con.Close()

            txtLookupDivision.Text = ARDivision
            txtLookupNotes.Text = "This Invoice is for " + ARDivision + " issued on " + ARDate + " for " + ARCustomerID
        ElseIf txtShipmentNumber.Text <> "" Then
            Dim CustomerID, ShipDate, ShipDivision As String

            Dim GetShipDataString As String = "SELECT CustomerID, DivisionID, ShipDate FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim GetShipDataCommand As New SqlCommand(GetShipDataString, con)
            GetShipDataCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetShipDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("CustomerID")) Then
                    CustomerID = ""
                Else
                    CustomerID = reader.Item("CustomerID")
                End If
                If IsDBNull(reader.Item("DivisionID")) Then
                    ShipDivision = ""
                Else
                    ShipDivision = reader.Item("DivisionID")
                End If
                If IsDBNull(reader.Item("ShipDate")) Then
                    ShipDate = ""
                Else
                    ShipDate = reader.Item("ShipDate")
                End If
            Else
                CustomerID = ""
                ShipDivision = ""
                ShipDate = ""
            End If
            reader.Close()
            con.Close()

            txtLookupDivision.Text = ShipDivision
            txtLookupNotes.Text = "This Shipment is for " + ShipDivision + " issued on " + ShipDate + " for " + CustomerID
        ElseIf txtSalesOrderNumber.Text <> "" Then
            Dim CustomerID, SODate, SODivision As String

            Dim GetShipDataString As String = "SELECT CustomerID, DivisionKey, SalesOrderDate FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim GetShipDataCommand As New SqlCommand(GetShipDataString, con)
            GetShipDataCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetShipDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("CustomerID")) Then
                    CustomerID = ""
                Else
                    CustomerID = reader.Item("CustomerID")
                End If
                If IsDBNull(reader.Item("DivisionKey")) Then
                    SODivision = ""
                Else
                    SODivision = reader.Item("DivisionKey")
                End If
                If IsDBNull(reader.Item("SalesOrderDate")) Then
                    SODate = ""
                Else
                    SODate = reader.Item("SalesOrderDate")
                End If
            Else
                CustomerID = ""
                SODivision = ""
                SODate = ""
            End If
            reader.Close()
            con.Close()

            txtLookupDivision.Text = SODivision
            txtLookupNotes.Text = "This Sales Order is for " + SODivision + " issued on " + SODate + " for " + CustomerID
        ElseIf cboCustomerLookup.Text <> "" Then
            'Count Customers
            Dim CountCustomerID As Integer = 0

            Dim CountCustomerIDStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID"
            Dim CountCustomerIDCommand As New SqlCommand(CountCustomerIDStatement, con)
            CountCustomerIDCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountCustomerID = CInt(CountCustomerIDCommand.ExecuteScalar)
            Catch ex As Exception
                CountCustomerID = 0
            End Try
            con.Close()

            If CountCustomerID = 0 Then
                txtLookupDivision.Text = "NONE"
                txtLookupNotes.Text = "This Customer ID does not exist."
            ElseIf CountCustomerID = 1 Then
                Dim GetCustomerDivision As String = ""
                Dim CustomerName As String = ""

                Dim GetCustomerDivisionStatement As String = "SELECT DivisionID FROM CustomerList WHERE CustomerID = @CustomerID"
                Dim GetCustomerDivisionCommand As New SqlCommand(GetCustomerDivisionStatement, con)
                GetCustomerDivisionCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetCustomerDivision = CStr(GetCustomerDivisionCommand.ExecuteScalar)
                Catch ex As Exception
                    GetCustomerDivision = ""
                End Try
                con.Close()

                Dim GetCustomerNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim GetCustomerNameCommand As New SqlCommand(GetCustomerNameStatement, con)
                GetCustomerNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                GetCustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetCustomerDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CustomerName = CStr(GetCustomerNameCommand.ExecuteScalar)
                Catch ex As Exception
                    CustomerName = ""
                End Try
                con.Close()

                txtLookupDivision.Text = GetCustomerDivision
                txtLookupNotes.Text = "This Customer ID is used in " + GetCustomerDivision + " Division (Customer Name - " + CustomerName + ")"
            ElseIf CountCustomerID > 1 Then
                'Grab all divisions that exist for this customer
                Dim ATLCustomer, ALBCustomer, CBSCustomer, DENCustomer, CHTCustomer, CGOCustomer, HOUCustomer, TFFCustomer, TFJCustomer, TFTCustomer, TFPCustomer, TWDCustomer, TWECustomer, TORCustomer, SLCCustomer As String
                Dim ATLCustomerCount, ALBCustomerCount, CBSCustomerCount, DENCustomerCount, CHTCustomerCount, CGOCustomerCount, HOUCustomerCount, TFFCustomerCount, TFJCustomerCount, TFTCustomerCount, TFPCustomerCount, TWDCustomerCount, TWECustomerCount, TORCustomerCount, SLCCustomerCount As Integer

                Dim CountATLStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountATLCommand As New SqlCommand(CountATLStatement, con)
                CountATLCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountATLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"

                Dim CountALBStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountALBCommand As New SqlCommand(CountALBStatement, con)
                CountALBCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountALBCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"

                Dim CountCBSStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountCBSCommand As New SqlCommand(CountCBSStatement, con)
                CountCBSCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountCBSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"

                Dim CountCGOStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountCGOCommand As New SqlCommand(CountCGOStatement, con)
                CountCGOCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountCGOCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"

                Dim CountCHTStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountCHTCommand As New SqlCommand(CountCHTStatement, con)
                CountCHTCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountCHTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"

                Dim CountDENStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountDENCommand As New SqlCommand(CountDENStatement, con)
                CountDENCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountDENCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"

                Dim CountHOUStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountHOUCommand As New SqlCommand(CountHOUStatement, con)
                CountHOUCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountHOUCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"

                Dim CountTFFStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountTFFCommand As New SqlCommand(CountTFFStatement, con)
                CountTFFCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountTFFCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"

                Dim CountTFJStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountTFJCommand As New SqlCommand(CountTFJStatement, con)
                CountTFJCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountTFJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"

                Dim CountTFTStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountTFTCommand As New SqlCommand(CountTFTStatement, con)
                CountTFTCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountTFTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"

                Dim CountTFPStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountTFPCommand As New SqlCommand(CountTFPStatement, con)
                CountTFPCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountTFPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

                Dim CountTWDStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountTWDCommand As New SqlCommand(CountTWDStatement, con)
                CountTWDCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountTWDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                Dim CountTWEStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountTWECommand As New SqlCommand(CountTWEStatement, con)
                CountTWECommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountTWECommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

                Dim CountTORStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountTORCommand As New SqlCommand(CountTORStatement, con)
                CountTORCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountTORCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"

                Dim CountSLCStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountSLCCommand As New SqlCommand(CountSLCStatement, con)
                CountSLCCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerLookup.Text
                CountSLCCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ATLCustomerCount = CInt(CountATLCommand.ExecuteScalar)
                Catch ex As Exception
                    ATLCustomerCount = 0
                End Try
                Try
                    CBSCustomerCount = CInt(CountCBSCommand.ExecuteScalar)
                Catch ex As Exception
                    CBSCustomerCount = 0
                End Try
                Try
                    CHTCustomerCount = CInt(CountCHTCommand.ExecuteScalar)
                Catch ex As Exception
                    CHTCustomerCount = 0
                End Try
                Try
                    CGOCustomerCount = CInt(CountCGOCommand.ExecuteScalar)
                Catch ex As Exception
                    CGOCustomerCount = 0
                End Try
                Try
                    DENCustomerCount = CInt(CountDENCommand.ExecuteScalar)
                Catch ex As Exception
                    DENCustomerCount = 0
                End Try
                Try
                    HOUCustomerCount = CInt(CountHOUCommand.ExecuteScalar)
                Catch ex As Exception
                    HOUCustomerCount = 0
                End Try
                Try
                    TFFCustomerCount = CInt(CountTFFCommand.ExecuteScalar)
                Catch ex As Exception
                    TFFCustomerCount = 0
                End Try
                Try
                    TFTCustomerCount = CInt(CountTFTCommand.ExecuteScalar)
                Catch ex As Exception
                    TFTCustomerCount = 0
                End Try
                Try
                    TFPCustomerCount = CInt(CountTFPCommand.ExecuteScalar)
                Catch ex As Exception
                    TFPCustomerCount = 0
                End Try
                Try
                    TWDCustomerCount = CInt(CountTWDCommand.ExecuteScalar)
                Catch ex As Exception
                    TWDCustomerCount = 0
                End Try
                Try
                    TWECustomerCount = CInt(CountTWECommand.ExecuteScalar)
                Catch ex As Exception
                    TWECustomerCount = 0
                End Try
                Try
                    TORCustomerCount = CInt(CountTORCommand.ExecuteScalar)
                Catch ex As Exception
                    TORCustomerCount = 0
                End Try
                Try
                    SLCCustomerCount = CInt(CountSLCCommand.ExecuteScalar)
                Catch ex As Exception
                    SLCCustomerCount = 0
                End Try
                Try
                    ALBCustomerCount = CInt(CountALBCommand.ExecuteScalar)
                Catch ex As Exception
                    ALBCustomerCount = 0
                End Try
                Try
                    TFJCustomerCount = CInt(CountTFJCommand.ExecuteScalar)
                Catch ex As Exception
                    TFJCustomerCount = 0
                End Try
                con.Close()

                If ATLCustomerCount = 0 Then
                    ATLCustomer = ""
                Else
                    ATLCustomer = " **ATL** "
                End If
                If CBSCustomerCount = 0 Then
                    CBSCustomer = ""
                Else
                    CBSCustomer = " **CBS** "
                End If
                If CGOCustomerCount = 0 Then
                    CGOCustomer = ""
                Else
                    CGOCustomer = " **CGO** "
                End If
                If CHTCustomerCount = 0 Then
                    CHTCustomer = ""
                Else
                    CHTCustomer = " **CHT** "
                End If
                If DENCustomerCount = 0 Then
                    DENCustomer = ""
                Else
                    DENCustomer = " **DEN** "
                End If
                If HOUCustomerCount = 0 Then
                    HOUCustomer = ""
                Else
                    HOUCustomer = " **HOU** "
                End If
                If TFFCustomerCount = 0 Then
                    TFFCustomer = ""
                Else
                    TFFCustomer = " **TFF** "
                End If
                If TFTCustomerCount = 0 Then
                    TFTCustomer = ""
                Else
                    TFTCustomer = " **TFT** "
                End If
                If TFPCustomerCount = 0 Then
                    TFPCustomer = ""
                Else
                    TFPCustomer = " **TFP** "
                End If
                If TWDCustomerCount = 0 Then
                    TWDCustomer = ""
                Else
                    TWDCustomer = " **TWD** "
                End If
                If TWECustomerCount = 0 Then
                    TWECustomer = ""
                Else
                    TWECustomer = " **TWE** "
                End If
                If TORCustomerCount = 0 Then
                    TORCustomer = ""
                Else
                    TORCustomer = " **TOR** "
                End If
                If SLCCustomerCount = 0 Then
                    SLCCustomer = ""
                Else
                    SLCCustomer = " **SLC** "
                End If
                If ALBCustomerCount = 0 Then
                    ALBCustomer = ""
                Else
                    ALBCustomer = " **ALB** "
                End If
                If TFJCustomerCount = 0 Then
                    TFJCustomer = ""
                Else
                    TFJCustomer = " **TFJ** "
                End If

                txtLookupDivision.Text = "Multiple divisions"
                txtLookupNotes.Text = "This same Customer ID is used in -- " + ALBCustomer + ATLCustomer + CBSCustomer + CGOCustomer + CHTCustomer + DENCustomer + HOUCustomer + TFFCustomer + TFJCustomer + TFTCustomer + TFPCustomer + TWDCustomer + TWECustomer + TORCustomer + SLCCustomer
            End If
        ElseIf cboVendorLookup.Text <> "" Then
            'Count Vendors
            Dim CountVendorID As Integer = 0

            Dim CountVendorIDStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode"
            Dim CountVendorIDCommand As New SqlCommand(CountVendorIDStatement, con)
            CountVendorIDCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountVendorID = CInt(CountVendorIDCommand.ExecuteScalar)
            Catch ex As Exception
                CountVendorID = 0
            End Try
            con.Close()

            If CountVendorID = 0 Then
                txtLookupDivision.Text = "NONE"
                txtLookupNotes.Text = "This Vendor ID does not exist."
            ElseIf CountVendorID = 1 Then
                Dim GetVendorDivision As String = ""

                Dim GetVendorDivisionStatement As String = "SELECT DivisionID FROM Vendor WHERE VendorCode = @VendorCode"
                Dim GetVendorDivisionCommand As New SqlCommand(GetVendorDivisionStatement, con)
                GetVendorDivisionCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetVendorDivision = CStr(GetVendorDivisionCommand.ExecuteScalar)
                Catch ex As Exception
                    GetVendorDivision = 0
                End Try
                con.Close()

                txtLookupDivision.Text = GetVendorDivision
                txtLookupNotes.Text = "This Vendor ID is used in " + GetVendorDivision + " Division"
            ElseIf CountVendorID > 1 Then
                'Grab all divisions that exist for this Vendor
                Dim ATLVendor, CBSVendor, DENVendor, CHTVendor, CGOVendor, HOUVendor, TFFVendor, TFTVendor, TFPVendor, TWDVendor, TWEVendor, TORVendor, SLCVendor, ALBVendor, TFJVendor As String
                Dim ATLVendorCount, CBSVendorCount, DENVendorCount, CHTVendorCount, CGOVendorCount, HOUVendorCount, TFFVendorCount, TFTVendorCount, TFPVendorCount, TWDVendorCount, TWEVendorCount, TORVendorCount, SLCVendorCount, ALBVendorCount, TFJVendorCount As Integer

                Dim CountATLStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountATLCommand As New SqlCommand(CountATLStatement, con)
                CountATLCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountATLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"

                Dim CountCBSStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountCBSCommand As New SqlCommand(CountCBSStatement, con)
                CountCBSCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountCBSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"

                Dim CountCGOStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountCGOCommand As New SqlCommand(CountCGOStatement, con)
                CountCGOCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountCGOCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"

                Dim CountCHTStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountCHTCommand As New SqlCommand(CountCHTStatement, con)
                CountCHTCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountCHTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"

                Dim CountDENStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountDENCommand As New SqlCommand(CountDENStatement, con)
                CountDENCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountDENCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"

                Dim CountHOUStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountHOUCommand As New SqlCommand(CountHOUStatement, con)
                CountHOUCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountHOUCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"

                Dim CountTFFStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountTFFCommand As New SqlCommand(CountTFFStatement, con)
                CountTFFCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountTFFCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"

                Dim CountTFTStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountTFTCommand As New SqlCommand(CountTFTStatement, con)
                CountTFTCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountTFTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"

                Dim CountTFPStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountTFPCommand As New SqlCommand(CountTFPStatement, con)
                CountTFPCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountTFPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

                Dim CountTWDStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountTWDCommand As New SqlCommand(CountTWDStatement, con)
                CountTWDCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountTWDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                Dim CountTWEStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountTWECommand As New SqlCommand(CountTWEStatement, con)
                CountTWECommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountTWECommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

                Dim CountTORStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountTORCommand As New SqlCommand(CountTORStatement, con)
                CountTORCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountTORCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"

                Dim CountSLCStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountSLCCommand As New SqlCommand(CountSLCStatement, con)
                CountSLCCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountSLCCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

                Dim CountALBStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountALBCommand As New SqlCommand(CountALBStatement, con)
                CountALBCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountALBCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"

                Dim CountTFJStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CountTFJCommand As New SqlCommand(CountTFJStatement, con)
                CountTFJCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorLookup.Text
                CountTFJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ATLVendorCount = CInt(CountATLCommand.ExecuteScalar)
                Catch ex As Exception
                    ATLVendorCount = 0
                End Try
                Try
                    CBSVendorCount = CInt(CountCBSCommand.ExecuteScalar)
                Catch ex As Exception
                    CBSVendorCount = 0
                End Try
                Try
                    CHTVendorCount = CInt(CountCHTCommand.ExecuteScalar)
                Catch ex As Exception
                    CHTVendorCount = 0
                End Try
                Try
                    CGOVendorCount = CInt(CountCGOCommand.ExecuteScalar)
                Catch ex As Exception
                    CGOVendorCount = 0
                End Try
                Try
                    DENVendorCount = CInt(CountDENCommand.ExecuteScalar)
                Catch ex As Exception
                    DENVendorCount = 0
                End Try
                Try
                    HOUVendorCount = CInt(CountHOUCommand.ExecuteScalar)
                Catch ex As Exception
                    HOUVendorCount = 0
                End Try
                Try
                    TFFVendorCount = CInt(CountTFFCommand.ExecuteScalar)
                Catch ex As Exception
                    TFFVendorCount = 0
                End Try
                Try
                    TFTVendorCount = CInt(CountTFTCommand.ExecuteScalar)
                Catch ex As Exception
                    TFTVendorCount = 0
                End Try
                Try
                    TFPVendorCount = CInt(CountTFPCommand.ExecuteScalar)
                Catch ex As Exception
                    TFPVendorCount = 0
                End Try
                Try
                    TWDVendorCount = CInt(CountTWDCommand.ExecuteScalar)
                Catch ex As Exception
                    TWDVendorCount = 0
                End Try
                Try
                    TWEVendorCount = CInt(CountTWECommand.ExecuteScalar)
                Catch ex As Exception
                    TWEVendorCount = 0
                End Try
                Try
                    TORVendorCount = CInt(CountTORCommand.ExecuteScalar)
                Catch ex As Exception
                    TORVendorCount = 0
                End Try
                Try
                    SLCVendorCount = CInt(CountSLCCommand.ExecuteScalar)
                Catch ex As Exception
                    SLCVendorCount = 0
                End Try
                Try
                    ALBVendorCount = CInt(CountALBCommand.ExecuteScalar)
                Catch ex As Exception
                    ALBVendorCount = 0
                End Try
                Try
                    TFJVendorCount = CInt(CountTFJCommand.ExecuteScalar)
                Catch ex As Exception
                    TFJVendorCount = 0
                End Try
                con.Close()

                If ATLVendorCount = 0 Then
                    ATLVendor = ""
                Else
                    ATLVendor = " **ATL** "
                End If
                If CBSVendorCount = 0 Then
                    CBSVendor = ""
                Else
                    CBSVendor = " **CBS** "
                End If
                If CGOVendorCount = 0 Then
                    CGOVendor = ""
                Else
                    CGOVendor = " **CGO** "
                End If
                If CHTVendorCount = 0 Then
                    CHTVendor = ""
                Else
                    CHTVendor = " **CHT** "
                End If
                If DENVendorCount = 0 Then
                    DENVendor = ""
                Else
                    DENVendor = " **DEN** "
                End If
                If HOUVendorCount = 0 Then
                    HOUVendor = ""
                Else
                    HOUVendor = " **HOU** "
                End If
                If TFFVendorCount = 0 Then
                    TFFVendor = ""
                Else
                    TFFVendor = " **TFF** "
                End If
                If TFTVendorCount = 0 Then
                    TFTVendor = ""
                Else
                    TFTVendor = " **TFT** "
                End If
                If TFPVendorCount = 0 Then
                    TFPVendor = ""
                Else
                    TFPVendor = " **TFP** "
                End If
                If TWDVendorCount = 0 Then
                    TWDVendor = ""
                Else
                    TWDVendor = " **TWD** "
                End If
                If TWEVendorCount = 0 Then
                    TWEVendor = ""
                Else
                    TWEVendor = " **TWE** "
                End If
                If TORVendorCount = 0 Then
                    TORVendor = ""
                Else
                    TORVendor = " **TOR** "
                End If
                If SLCVendorCount = 0 Then
                    SLCVendor = ""
                Else
                    SLCVendor = " **SLC** "
                End If
                If ALBVendorCount = 0 Then
                    ALBVendor = ""
                Else
                    ALBVendor = " **ALB** "
                End If
                If TFJVendorCount = 0 Then
                    TFJVendor = ""
                Else
                    TFJVendor = " **TFJ** "
                End If

                txtLookupDivision.Text = "Multiple divisions"
                txtLookupNotes.Text = "This same Vendor ID is used in -- " + ALBVendor + ATLVendor + CBSVendor + CGOVendor + CHTVendor + DENVendor + HOUVendor + TFFVendor + TFJVendor + TFTVendor + TFPVendor + TWDVendor + TWEVendor + TORVendor + SLCVendor
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtAPInvoiceLookup.Clear()
        txtARInvoiceLookup.Clear()
        txtLookupDivision.Clear()
        txtLookupNotes.Clear()
        txtPOLookup.Clear()
        txtShipmentNumber.Clear()
        txtSalesOrderNumber.Clear()
        txtARCheck.Clear()
        txtPRONumber.Clear()

        cboCustomerLookup.SelectedIndex = -1
        cboVendorLookup.SelectedIndex = -1

        txtPOLookup.Focus()
    End Sub
End Class