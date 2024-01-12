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
Public Class PrintAllInvoiceDocs
    Inherits System.Windows.Forms.Form

    Dim FormShipmentNumber, FormInvoiceNumber, FormSONumber As Integer

    Dim MyReport1 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport3 = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myadapter8, myAdapter9 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim dt As DataTable

    Public Sub LoadInvoiceShipments()
        cmd = New SqlCommand("SELECT BatchNumber, ShipmentNumber, DivisionID, InvoiceNumber, SalesOrderNumber, CustomerID FROM InvoiceShipmentQuery WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID ORDER BY CustomerID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalARBatchNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "InvoiceShipmentQuery")
        dgvInvoiceShipments.DataSource = ds1.Tables("InvoiceShipmentQuery")
        con.Close()
    End Sub

    Private Sub CRCertViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCertViewer.Load
        'Load Shipments in the Invoice Batch
        LoadInvoiceShipments()

        For Each row As DataGridViewRow In dgvInvoiceShipments.Rows
            Try
                FormInvoiceNumber = row.Cells("InvoiceNumberColumn").Value
            Catch ex As Exception
                FormInvoiceNumber = 0
            End Try
            Try
                FormShipmentNumber = row.Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                FormShipmentNumber = 0
            End Try
            Try
                FormSONumber = row.Cells("SalesOrderNumberColumn").Value
            Catch ex As Exception
                FormSONumber = 0
            End Try

            'Choose the Invoice Print Form by division
            If GlobalDivisionCode = "TFF" Or GlobalDivisionCode = "TOR" Or GlobalDivisionCode = "ALB" Then
                If FormShipmentNumber = 0 Or FormSONumber = 0 Then
                    'Bill Only Invoice - Canadian
                    cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = FormInvoiceNumber
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID", con)
                    cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                    cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                    cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                    cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    If con.State = ConnectionState.Closed Then con.Open()
                    ds = New DataSet()

                    myAdapter.SelectCommand = cmd
                    myAdapter.Fill(ds, "InvoiceHeaderTable")

                    myAdapter1.SelectCommand = cmd1
                    myAdapter1.Fill(ds, "InvoiceLineQuery")

                    myAdapter2.SelectCommand = cmd2
                    myAdapter2.Fill(ds, "DivisionTable")

                    myAdapter3.SelectCommand = cmd3
                    myAdapter3.Fill(ds, "CustomerList")

                    myAdapter4.SelectCommand = cmd4
                    myAdapter4.Fill(ds, "ARCustomerPayment")

                    'Sets up viewer to display data from the loaded dataset
                    MyReport1 = CRXInvoiceTFFBillOnly1
                    MyReport1.SetDataSource(ds)
                    MyReport1.PrintToPrinter(1, True, 1, 999)
                    con.Close()
                Else
                    'Loads data into dataset for viewing
                    cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = FormInvoiceNumber

                    cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
                    cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = FormInvoiceNumber

                    cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
                    cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                    cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd4 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                    cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
                    cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd6 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND InvoiceNumber = @InvoiceNumber", con)
                    cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd7 = New SqlCommand("SELECT * FROM InvoiceLotLineTable", con)
                    cmd7.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = FormInvoiceNumber

                    cmd8 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd8.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = FormInvoiceNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    ds = New DataSet()

                    myAdapter.SelectCommand = cmd
                    myAdapter.Fill(ds, "InvoiceHeaderTable")

                    myAdapter1.SelectCommand = cmd1
                    myAdapter1.Fill(ds, "InvoiceLineQuery")

                    myAdapter2.SelectCommand = cmd2
                    myAdapter2.Fill(ds, "ShipmentHeaderTable")

                    myAdapter3.SelectCommand = cmd3
                    myAdapter3.Fill(ds, "DivisionTable")

                    myAdapter4.SelectCommand = cmd4
                    myAdapter4.Fill(ds, "CustomerList")

                    myAdapter5.SelectCommand = cmd5
                    myAdapter5.Fill(ds, "AdditionalShipTo")

                    myAdapter6.SelectCommand = cmd6
                    myAdapter6.Fill(ds, "ARCustomerPayment")

                    myAdapter7.SelectCommand = cmd7
                    myAdapter7.Fill(ds, "InvoiceLotLineTable")

                    myadapter8.SelectCommand = cmd8
                    myadapter8.Fill(ds, "InvoiceSerialLineTable")

                    'Sets up viewer to display data from the loaded dataset
                    MyReport1 = CRXInvoiceTFF1
                    MyReport1.SetDataSource(ds)
                    MyReport1.PrintToPrinter(1, True, 1, 999)
                    con.Close()
                End If
            Else
                If FormShipmentNumber = 0 Or FormSONumber = 0 Then
                    cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = FormInvoiceNumber
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
                    cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                    cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                    cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                    cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    If con.State = ConnectionState.Closed Then con.Open()
                    ds = New DataSet()

                    myAdapter.SelectCommand = cmd
                    myAdapter.Fill(ds, "InvoiceHeaderTable")

                    myAdapter1.SelectCommand = cmd1
                    myAdapter1.Fill(ds, "InvoiceLineTable")

                    myAdapter2.SelectCommand = cmd2
                    myAdapter2.Fill(ds, "DivisionTable")

                    myAdapter3.SelectCommand = cmd3
                    myAdapter3.Fill(ds, "CustomerList")

                    myAdapter4.SelectCommand = cmd4
                    myAdapter4.Fill(ds, "ARCustomerPayment")

                    'Sets up viewer to display data from the loaded dataset
                    If GlobalDivisionCode = "TFP" Then
                        MyReport1 = CRXInvoiceBillOnlyTFP1
                        MyReport1.SetDataSource(ds)
                        MyReport1.PrintToPrinter(1, True, 1, 999)
                        con.Close()
                    Else
                        MyReport1 = CRXInvoiceBillOnly1
                        MyReport1.SetDataSource(ds)
                        MyReport1.PrintToPrinter(1, True, 1, 999)
                        con.Close()
                    End If
                Else
                    'Loads data into dataset for viewing
                    cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = FormInvoiceNumber

                    cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
                    cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = FormInvoiceNumber

                    cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
                    cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                    cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd4 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                    cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
                    cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd6 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                    cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    cmd7 = New SqlCommand("SELECT * FROM InvoiceLotLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd7.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = FormInvoiceNumber

                    cmd8 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd8.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = FormInvoiceNumber

                    cmd9 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable", con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    ds = New DataSet()

                    myAdapter.SelectCommand = cmd
                    myAdapter.Fill(ds, "InvoiceHeaderTable")

                    myAdapter1.SelectCommand = cmd1
                    myAdapter1.Fill(ds, "InvoiceLineQuery")

                    myAdapter2.SelectCommand = cmd2
                    myAdapter2.Fill(ds, "ShipmentHeaderTable")

                    myAdapter3.SelectCommand = cmd3
                    myAdapter3.Fill(ds, "DivisionTable")

                    myAdapter4.SelectCommand = cmd4
                    myAdapter4.Fill(ds, "CustomerList")

                    myAdapter5.SelectCommand = cmd5
                    myAdapter5.Fill(ds, "AdditionalShipTo")

                    myAdapter6.SelectCommand = cmd6
                    myAdapter6.Fill(ds, "ARCustomerPayment")

                    myAdapter7.SelectCommand = cmd7
                    myAdapter7.Fill(ds, "InvoiceLotLineTable")

                    myadapter8.SelectCommand = cmd8
                    myadapter8.Fill(ds, "InvoiceSerialLineTable")

                    myAdapter9.SelectCommand = cmd9
                    myAdapter9.Fill(ds, "SalesOrderHeaderTable")

                    'Sets up viewer to display data from the loaded dataset
                    If GlobalDivisionCode = "TFP" Then
                        MyReport1 = CRXInvoiceTFP1
                        MyReport1.SetDataSource(ds)
                        MyReport1.PrintToPrinter(1, True, 1, 999)
                        con.Close()
                    Else
                        MyReport1 = CRXInvoice1
                        MyReport1.SetDataSource(ds)
                        MyReport1.PrintToPrinter(1, True, 1, 999)
                        con.Close()
                    End If
                End If
            End If

            If FormShipmentNumber = 0 Then
                'Skip Certs
            Else
                'Check to make sure at least one cert will print otherwise do not open Print Form
                Dim CheckForCerts As Integer = 0

                'Get Pull Test Number for selected Lot Number Data
                Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
                CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = FormShipmentNumber
                CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

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
                    'Skip
                Else
                    'Loads data into dataset for viewing
                    cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = FormShipmentNumber

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
                    MyReport2 = CRXTWCert011
                    MyReport2.SetDataSource(ds)
                    MyReport2.PrintToPrinter(1, True, 1, 999)
                    con.Close()

                    If GlobalPrintNoCertPage = "YES" Then
                        MyReport3 = CRXTruweldNOCERT1
                        MyReport3.PrintToPrinter(1, True, 1, 999)
                    Else
                        'Skip
                    End If
                End If
            End If
        Next

        Me.Close()
    End Sub

    Private Sub PrintAllInvoiceDocs_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalPrintNoCertPage = ""
    End Sub
End Class