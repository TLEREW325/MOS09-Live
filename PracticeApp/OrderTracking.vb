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
Public Class OrderTracking
    Inherits System.Windows.Forms.Form

    Dim FieldOneText As String = ""
    Dim FieldTwoText As String = ""
    Dim FieldThreeText As String = ""
    Dim FieldFourText As String = ""
    Dim FieldFiveText As String = ""


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub OrderTracking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdTrace
    End Sub

    Public Sub LoadSalesOrderData()
        Dim SODate, Customer, Salesperson, CustomerPO As String

        Dim SODateString As String = "SELECT SalesOrderDate FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
        Dim SODateCommand As New SqlCommand(SODateString, con)
        SODateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

        Dim SOCustomerString As String = "SELECT CustomerID FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
        Dim SOCustomerCommand As New SqlCommand(SOCustomerString, con)
        SOCustomerCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

        Dim SOSalespersonString As String = "SELECT Salesperson FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
        Dim SOSalespersonCommand As New SqlCommand(SOSalespersonString, con)
        SOSalespersonCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

        Dim CustomerPOString As String = "SELECT CustomerPO FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
        Dim CustomerPOCommand As New SqlCommand(CustomerPOString, con)
        CustomerPOCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SODate = CStr(SODateCommand.ExecuteScalar)
        Catch ex As Exception
            SODate = ""
        End Try
        Try
            Customer = CStr(SOCustomerCommand.ExecuteScalar)
        Catch ex As Exception
            Customer = ""
        End Try
        Try
            Salesperson = CStr(SOSalespersonCommand.ExecuteScalar)
        Catch ex As Exception
            Salesperson = ""
        End Try
        Try
            CustomerPO = CStr(CustomerPOCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerPO = ""
        End Try
        con.Close()

        FieldOneText = "This order was placed by " + Salesperson + ", on " + SODate + ", for the customer " + Customer + " with a Customer PO # of " + CustomerPO
        lblField1.Text = FieldOneText
    End Sub

    Public Sub LoadShipmentDetails()
        'Count the number of shipments for this order
        Dim CountShipments As Integer = 0

        Dim CountShipmentsString As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
        Dim CountShipmentsCommand As New SqlCommand(CountShipmentsString, con)
        CountShipmentsCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountShipments = CInt(CountShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            CountShipments = 0
        End Try
        con.Close()

        If CountShipments = 0 Then
            FieldTwoText = "This order has no shipments associated with it."
            lblField2.Text = FieldTwoText
        ElseIf CountShipments = 1 Then
            Dim ShipDate, ShipVia, ShipMethod As String
            Dim strShipmentNumber As String = ""
            Dim ShipmentNumber As Integer = 0

            Dim ShippingDataStatement As String = "SELECT ShipmentNumber, ShipDate, ShipVia, ShippingMethod FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim ShippingDataCommand As New SqlCommand(ShippingDataStatement, con)
            ShippingDataCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = ShippingDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("ShipmentNumber")) Then
                    ShipmentNumber = 0
                Else
                    ShipmentNumber = reader.Item("ShipmentNumber")
                    strShipmentNumber = CStr(ShipmentNumber)
                End If
                If IsDBNull(reader.Item("ShipDate")) Then
                    ShipDate = ""
                Else
                    ShipDate = reader.Item("ShipDate")
                End If
                If IsDBNull(reader.Item("ShipVia")) Then
                    ShipVia = ""
                Else
                    ShipVia = reader.Item("ShipVia")
                End If
                If IsDBNull(reader.Item("ShippingMethod")) Then
                    ShipMethod = ""
                Else
                    ShipMethod = reader.Item("ShippingMethod")
                End If
            Else
                ShipmentNumber = 0
                ShipDate = ""
                ShipVia = ""
                ShipMethod = ""
            End If
            reader.Close()
            con.Close()

            FieldTwoText = "Shipment # " + strShipmentNumber + " was shipped on " + ShipDate + ", via " + ShipVia + " (" + ShipMethod + ")."
            lblField2.Text = FieldTwoText
        Else
            'Load Shipments into datagrid
            cmd = New SqlCommand("SELECT ShipmentNumber, ShipDate, ShipVia, ShippingMethod FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "ShipmentHeaderTable")
            dgvShipments.DataSource = ds3.Tables("ShipmentHeaderTable")
            con.Close()

            Dim LineShipmentNumber As Integer = 0
            Dim LineShipDate, LineShipVia, LineShipMethod As String
            Dim Counter As Integer = 0


            For Each LineRow As DataGridViewRow In dgvShipments.Rows
                Try
                    LineShipmentNumber = LineRow.Cells("ShipmentNumberColumn").Value
                Catch ex As System.Exception
                    LineShipmentNumber = 0
                End Try
                Try
                    LineShipDate = LineRow.Cells("ShipDateColumn").Value
                Catch ex As System.Exception
                    LineShipDate = ""
                End Try
                Try
                    LineShipVia = LineRow.Cells("ShipViaColumn").Value
                Catch ex As System.Exception
                    LineShipVia = ""
                End Try
                Try
                    LineShipMethod = LineRow.Cells("ShippingMethodColumn").Value
                Catch ex As System.Exception
                    LineShipMethod = ""
                End Try

                Dim strShipmentNumber As String = ""
                strShipmentNumber = CStr(LineShipmentNumber)
                Dim CurrentTextBox As String = ""

                If LineShipmentNumber = 0 Then
                    'Skip
                Else
                    If Counter = 0 Then
                        FieldTwoText = "Shipment # " + strShipmentNumber + " was shipped on " + LineShipDate + ", via " + LineShipVia + " (" + LineShipMethod + ")." + Environment.NewLine
                        lblField2.Text = FieldTwoText

                        Counter = Counter + 1
                    Else
                        CurrentTextBox = lblField2.Text

                        FieldTwoText = CurrentTextBox + Environment.NewLine + "Shipment # " + strShipmentNumber + " was shipped on " + LineShipDate + ", via " + LineShipVia + " (" + LineShipMethod + ")." + Environment.NewLine
                        lblField2.Text = FieldTwoText

                        CurrentTextBox = ""
                        Counter = Counter + 1
                    End If

                    'Clear Variales
                    LineShipmentNumber = 0
                    LineShipDate = ""
                    LineShipMethod = ""
                    LineShipVia = ""
                End If
            Next

            'Clear Datagrid
            Me.dgvShipments.DataSource = Nothing
            Counter = 0
        End If
    End Sub

    Public Sub LoadInvoiceDetails()
        'Count the number of Invoices for this order
        Dim CountInvoices As Integer = 0

        Dim CountInvoicesString As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE SalesOrderNumber = @SalesOrderNumber"
        Dim CountInvoicesCommand As New SqlCommand(CountInvoicesString, con)
        CountInvoicesCommand.Parameters.Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountInvoices = CInt(CountInvoicesCommand.ExecuteScalar)
        Catch ex As Exception
            CountInvoices = 0
        End Try
        con.Close()

        If CountInvoices = 0 Then
            FieldThreeText = "This order has no Invoices associated with it."
            lblField3.Text = FieldThreeText
        ElseIf CountInvoices = 1 Then
            Dim InvoiceDate, PRONumber As String
            Dim strInvoiceNumber As String = ""
            Dim InvoiceNumber As Integer = 0
            Dim PaymentsApplied As Double = 0
            Dim strPaymentsApplied As String = ""
            Dim BilledFreight As Double = 0
            Dim strBilledFreight As String = ""
            Dim InvoiceTotal As Double = 0
            Dim strInvoiceTotal As String = ""

            Dim InvoiceDataStatement As String = "SELECT * FROM InvoiceHeaderTable WHERE SalesOrderNumber = @SalesOrderNumber"
            Dim InvoiceDataCommand As New SqlCommand(InvoiceDataStatement, con)
            InvoiceDataCommand.Parameters.Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = InvoiceDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("PRONumber")) Then
                    PRONumber = ""
                Else
                    PRONumber = reader.Item("PRONumber")
                End If
                If IsDBNull(reader.Item("InvoiceDate")) Then
                    InvoiceDate = ""
                Else
                    InvoiceDate = reader.Item("InvoiceDate")
                End If
                If IsDBNull(reader.Item("InvoiceNumber")) Then
                    InvoiceNumber = 0
                Else
                    InvoiceNumber = reader.Item("InvoiceNumber")
                    strInvoiceNumber = CStr(InvoiceNumber)
                End If
                If IsDBNull(reader.Item("PaymentsApplied")) Then
                    PaymentsApplied = 0
                Else
                    PaymentsApplied = reader.Item("PaymentsApplied")
                    strPaymentsApplied = CStr(PaymentsApplied)
                End If
                If IsDBNull(reader.Item("BilledFreight")) Then
                    BilledFreight = 0
                Else
                    BilledFreight = reader.Item("BilledFreight")
                    strBilledFreight = CStr(BilledFreight)
                End If
                If IsDBNull(reader.Item("InvoiceTotal")) Then
                    InvoiceTotal = 0
                Else
                    InvoiceTotal = reader.Item("InvoiceTotal")
                    strInvoiceTotal = CStr(InvoiceTotal)
                End If
            Else
                InvoiceNumber = 0
                InvoiceDate = ""
                PRONumber = ""
                PaymentsApplied = 0
                strPaymentsApplied = ""
                BilledFreight = 0
                strBilledFreight = ""
                InvoiceTotal = 0
                strInvoiceTotal = ""
            End If
            reader.Close()
            con.Close()

            FieldThreeText = "Invoice # " + strInvoiceNumber + " was invoiced on " + InvoiceDate + ", with PRO # (" + PRONumber + "), Invoice Total ($" + strInvoiceTotal + "), Billed Freight ($" + strBilledFreight + "), Payments Applied ($" + strPaymentsApplied + ")"
            lblField3.Text = FieldThreeText
        Else
            'Load Invoices into datagrid
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE SalesOrderNumber = @SalesOrderNumber", con)
            cmd.Parameters.Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd
            myAdapter2.Fill(ds2, "InvoiceHeaderTable")
            dgvInvoices.DataSource = ds2.Tables("InvoiceHeaderTable")
            con.Close()

            Dim LineInvoiceNumber As Integer = 0
            Dim LineInvoiceDate, LinePRONumber As String
            Dim LineBilledFreight, LinePaymentsApplied, LineInvoiceTotal As Double
            Dim strLineInvoiceNumber, strLineBilledFreight, strLinePaymentsApplied, strLineInvoiceTotal As String

            Dim Counter As Integer = 0

            For Each LineRow As DataGridViewRow In dgvInvoices.Rows
                Try
                    LineInvoiceNumber = LineRow.Cells("InvoiceNumberColumn1").Value
                Catch ex As System.Exception
                    LineInvoiceNumber = 0
                End Try
                Try
                    LineInvoiceDate = LineRow.Cells("InvoiceDateColumn1").Value
                Catch ex As System.Exception
                    LineInvoiceDate = ""
                End Try
                Try
                    LinePRONumber = LineRow.Cells("PRONumberColumn1").Value
                Catch ex As System.Exception
                    LinePRONumber = ""
                End Try
                Try
                    LineBilledFreight = LineRow.Cells("BilledFreightColumn1").Value
                Catch ex As System.Exception
                    LineBilledFreight = 0
                End Try
                Try
                    LinePaymentsApplied = LineRow.Cells("PaymentsAppliedColumn1").Value
                Catch ex As System.Exception
                    LinePaymentsApplied = 0
                End Try
                Try
                    LineInvoiceTotal = LineRow.Cells("InvoiceTotalColumn1").Value
                Catch ex As System.Exception
                    LineInvoiceTotal = 0
                End Try

                'Convert Number to strings
                strLineInvoiceNumber = CStr(LineInvoiceNumber)
                strLineBilledFreight = CStr(LineBilledFreight)
                strLineInvoiceTotal = CStr(LineInvoiceTotal)
                strLinePaymentsApplied = CStr(LinePaymentsApplied)

                Dim CurrentTextBox As String = ""

                If LineInvoiceNumber = 0 Then
                    'Skip
                Else
                    If Counter = 0 Then
                        FieldThreeText = "Invoice # " + strLineInvoiceNumber + " was invoiced on " + LineInvoiceDate + " - PRO # (" + LinePRONumber + "), Invoice Total (" + strLineInvoiceTotal + "), Billed Freight (" + strLineBilledFreight + "), Payments Applied {" + strLinePaymentsApplied + ")." + Environment.NewLine
                        lblField3.Text = FieldThreeText

                        Counter = Counter + 1
                    Else
                        CurrentTextBox = lblField3.Text

                        FieldThreeText = CurrentTextBox + Environment.NewLine + "Invoice # " + strLineInvoiceNumber + " was invoiced on " + LineInvoiceDate + " - PRO # (" + LinePRONumber + "), Invoice Total (" + strLineInvoiceTotal + "), Billed Freight (" + strLineBilledFreight + "), Payments Applied {" + strLinePaymentsApplied + ")." + Environment.NewLine
                        lblField3.Text = FieldThreeText

                        CurrentTextBox = ""
                        Counter = Counter + 1
                    End If

                    'Clear Variales
                    strLineInvoiceNumber = 0
                    LineInvoiceDate = ""
                    LinePRONumber = ""
                    LinePaymentsApplied = 0
                    LineInvoiceTotal = 0
                    LineInvoiceNumber = 0
                    LineBilledFreight = 0
                    strLineBilledFreight = ""
                    strLineInvoiceTotal = ""
                    strLinePaymentsApplied = ""
                End If
            Next

            'Clear Datagrid
            Me.dgvInvoices.DataSource = Nothing
            Counter = 0
        End If
    End Sub

    Public Sub LoadReturnDetails()
        'Count the number of Invoices for this order
        Dim CountReturns As Integer = 0

        Dim CountReturnsString As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductHeaderTable WHERE SalesOrderNumber = @SalesOrderNumber"
        Dim CountReturnsCommand As New SqlCommand(CountReturnsString, con)
        CountReturnsCommand.Parameters.Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountReturns = CInt(CountReturnsCommand.ExecuteScalar)
        Catch ex As Exception
            CountReturns = 0
        End Try
        con.Close()

        If CountReturns = 0 Then
            FieldFourText = "This order has no returns associated with it."
            lblField4.Text = FieldFourText
        ElseIf CountReturns = 1 Then
            Dim ReturnDate As String
            Dim strReturnNumber As String = ""
            Dim ReturnNumber As Integer = 0
            Dim ReturnTotal As Double = 0
            Dim strReturnTotal As String = ""

            Dim ReturnDataStatement As String = "SELECT * FROM ReturnProductHeaderTable WHERE SalesOrderNumber = @SalesOrderNumber"
            Dim ReturnDataCommand As New SqlCommand(ReturnDataStatement, con)
            ReturnDataCommand.Parameters.Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = ReturnDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("ReturnNumber")) Then
                    ReturnNumber = 0
                Else
                    ReturnNumber = reader.Item("ReturnNumber")
                    strReturnNumber = CStr(ReturnNumber)
                End If
                If IsDBNull(reader.Item("ReturnDate")) Then
                    ReturnDate = ""
                Else
                    ReturnDate = reader.Item("ReturnDate")
                End If
                If IsDBNull(reader.Item("ReturnTotal")) Then
                    ReturnTotal = 0
                Else
                    ReturnTotal = reader.Item("ReturnTotal")
                    strReturnTotal = CStr(ReturnTotal)
                End If
            Else
                ReturnNumber = 0
                ReturnDate = ""
                ReturnTotal = 0
                strReturnTotal = ""
            End If
            reader.Close()
            con.Close()

            FieldFourText = "Return # " + strReturnNumber + " was processed on " + ReturnDate + " for $" + strReturnTotal + "."
            lblField4.Text = FieldFourText
        Else
            'Load Return into datagrid
            cmd = New SqlCommand("SELECT * FROM ReturnProductHeaderTable WHERE SalesOrderNumber = @SalesOrderNumber", con)
            cmd.Parameters.Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "InvoiceHeaderTable")
            dgvInvoices.DataSource = ds1.Tables("InvoiceHeaderTable")
            con.Close()

            Dim LineReturnNumber As Integer = 0
            Dim LineReturnDate As String
            Dim LineReturnTotal As Double
            Dim strLineReturnNumber, strLineReturnTotal As String

            Dim Counter As Integer = 0

            For Each LineRow As DataGridViewRow In dgvInvoices.Rows
                Try
                    LineReturnNumber = LineRow.Cells("ReturnNumberColumn2").Value
                Catch ex As System.Exception
                    LineReturnNumber = 0
                End Try
                Try
                    LineReturnDate = LineRow.Cells("ReturnDateColumn2").Value
                Catch ex As System.Exception
                    LineReturnDate = ""
                End Try
                Try
                    LineReturnTotal = LineRow.Cells("ReturnTotalColumn2").Value
                Catch ex As System.Exception
                    LineReturnTotal = 0
                End Try

                'Convert Number to strings
                strLineReturnNumber = CStr(LineReturnNumber)
                strLineReturnTotal = CStr(LineReturnTotal)

                Dim CurrentTextBox As String = ""

                If LineReturnNumber = 0 Then
                    'Skip
                Else
                    If Counter = 0 Then
                        FieldFourText = "Return # " + strLineReturnNumber + " was processed on " + LineReturnDate + " for $" + strLineReturnTotal + "." + Environment.NewLine
                        lblField4.Text = FieldFourText

                        Counter = Counter + 1
                    Else
                        CurrentTextBox = lblField4.Text

                        FieldFourText = CurrentTextBox + Environment.NewLine + "Return # " + strLineReturnNumber + " was processed on " + LineReturnDate + " for $" + strLineReturnTotal + "." + Environment.NewLine
                        lblField4.Text = FieldFourText

                        CurrentTextBox = ""
                        Counter = Counter + 1
                    End If

                    'Clear Variales
                    strLineReturnNumber = 0
                    LineReturnDate = ""
                    LineReturnTotal = 0
                    LineReturnNumber = 0
                    strLineReturnTotal = ""
                End If
            Next

            'Clear Datagrid
            Me.dgvReturns.DataSource = Nothing
            Counter = 0
        End If
    End Sub

    Private Sub cmdTrace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTrace.Click
        If txtSalesOrderNumber.Text <> "" Then
            Dim CountSONumber As Integer = 0

            Dim CountSalesOrdersString As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim CountSalesOrdersCommand As New SqlCommand(CountSalesOrdersString, con)
            CountSalesOrdersCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountSONumber = CInt(CountSalesOrdersCommand.ExecuteScalar)
            Catch ex As Exception
                CountSONumber = 0
            End Try
            con.Close()

            If CountSONumber = 1 Then
                'Get Customer, Order Date, and Salesperson for field one
                LoadSalesOrderData()

                'Get pick number(s), shipment number(s) for order
                LoadShipmentDetails()

                'Load Invoice Data
                LoadInvoiceDetails()

                'Load Return Data
                LoadReturnDetails()
            Else
                MsgBox("There is no data for this Sales Order.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Else
            If txtCustomerPO.Text = "" Then
                MsgBox("You must enter a valid SO # or a valid Customer PO #.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Load Sales Order Number by Customer PO.
                Dim CustomerPONumber As String = ""
                Dim CountSONumber As Integer = 0
                Dim GetSalesOrderNumber As Integer = 0

                'Check the number of sales orders with the same PO Number
                Dim CountSalesOrdersString As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE CustomerPO = @CustomerPO"
                Dim CountSalesOrdersCommand As New SqlCommand(CountSalesOrdersString, con)
                CountSalesOrdersCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountSONumber = CInt(CountSalesOrdersCommand.ExecuteScalar)
                Catch ex As Exception
                    CountSONumber = 0
                End Try
                con.Close()

                If CountSONumber = 0 Then
                    MsgBox("There is no Sales Order associated with this PO Number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                ElseIf CountSONumber = 1 Then
                    'Get Sales Order Number for specific PO Number
                    Dim GetSalesOrderNumberString As String = "SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE CustomerPO = @CustomerPO"
                    Dim GetSalesOrderNumberCommand As New SqlCommand(GetSalesOrderNumberString, con)
                    GetSalesOrderNumberCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetSalesOrderNumber = CInt(GetSalesOrderNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetSalesOrderNumber = 0
                    End Try
                    con.Close()

                    txtSalesOrderNumber.Text = GetSalesOrderNumber

                    'Get Customer, Order Date, and Salesperson for field one
                    LoadSalesOrderData()

                    'Get pick number(s), shipment number(s) for order
                    LoadShipmentDetails()

                    'Load Invoice Data
                    LoadInvoiceDetails()

                    'Load Return Data
                    LoadReturnDetails()
                Else
                    MsgBox("This Customer PO # is associated with multiple Sales Orders.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtSalesOrderNumber.Clear()
        txtCustomerPO.Clear()

        lblField1.Text = ""
        lblField2.Text = ""
        lblField3.Text = ""
        lblField4.Text = ""

        Me.dgvInvoices.DataSource = Nothing
        Me.dgvShipments.DataSource = Nothing
        Me.dgvReturns.DataSource = Nothing

        txtSalesOrderNumber.Focus()
    End Sub
End Class