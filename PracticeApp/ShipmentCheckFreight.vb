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
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class ShipmentCheckFreight
    Inherits System.Windows.Forms.Form

    Dim FreightCharge As Double = 0
    Dim ShippingDivision, ProNumber, ShippingDate, ShipVia, ShippingCustomer As String
    Dim SearchByCustomerPO As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ShipmentCheckFreight_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdSearchByPO

        txtCustomerPO.Focus()
    End Sub

    Private Sub cmdSearchByPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearchByPO.Click
        'Check to see if any multiples
        Dim CountShipments As Integer = 0
        SearchByCustomerPO = "%" + txtCustomerPO.Text + "%"

        Dim CountShipmentsStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE CustomerPO LIKE @CustomerPO"
        Dim CountShipmentsCommand As New SqlCommand(CountShipmentsStatement, con)
        CountShipmentsCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = SearchByCustomerPO

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountShipments = CInt(CountShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            CountShipments = 0
        End Try
        con.Close()

        If CountShipments = 0 Then
            lblMessage.Text = "There are no shipments with this PO #"
        ElseIf CountShipments = 1 Then
            LoadShippingDetails()
        Else
            lblMessage.Text = "There are multiple shipments with this PO #"
        End If
    End Sub

    Public Sub ClearData()
        txtCustomer.Clear()
        txtCustomerPO.Clear()
        txtFreightCharges.Clear()
        txtProNumber.Clear()
        txtShipDate.Clear()
        txtShippingDivision.Clear()
        txtShipVia.Clear()
        lblMessage.Text = ""

        FreightCharge = 0
        ShippingDivision = ""
        ProNumber = ""
        ShippingDate = ""
        ShipVia = ""
        ShippingCustomer = ""
        SearchByCustomerPO = ""
    End Sub

    Public Sub LoadShippingDetails()
        SearchByCustomerPO = "%" + txtCustomerPO.Text + "%"

        'Extract Shipment Data
        Dim PRONumberStatement As String = "SELECT PRONumber FROM ShipmentHeaderTable WHERE CustomerPO LIKE @CustomerPO"
        Dim PRONumberCommand As New SqlCommand(PRONumberStatement, con)
        PRONumberCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = SearchByCustomerPO

        Dim ShippingCustomerStatement As String = "SELECT CustomerID FROM ShipmentHeaderTable WHERE CustomerPO LIKE @CustomerPO"
        Dim ShippingCustomerCommand As New SqlCommand(ShippingCustomerStatement, con)
        ShippingCustomerCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = SearchByCustomerPO

        Dim ShipViaStatement As String = "SELECT ShipVia FROM ShipmentHeaderTable WHERE CustomerPO LIKE @CustomerPO"
        Dim ShipViaCommand As New SqlCommand(ShipViaStatement, con)
        ShipViaCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = SearchByCustomerPO

        Dim FreightActualAmountStatement As String = "SELECT FreightActualAmount FROM ShipmentHeaderTable WHERE CustomerPO LIKE @CustomerPO"
        Dim FreightActualAmountCommand As New SqlCommand(FreightActualAmountStatement, con)
        FreightActualAmountCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = SearchByCustomerPO

        Dim ShippingDivisionStatement As String = "SELECT DivisionID FROM ShipmentHeaderTable WHERE CustomerPO LIKE @CustomerPO"
        Dim ShippingDivisionCommand As New SqlCommand(ShippingDivisionStatement, con)
        ShippingDivisionCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = SearchByCustomerPO

        Dim ShippingDateStatement As String = "SELECT ShipDate FROM ShipmentHeaderTable WHERE CustomerPO LIKE @CustomerPO"
        Dim ShippingDateCommand As New SqlCommand(ShippingDateStatement, con)
        ShippingDateCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = SearchByCustomerPO

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProNumber = CStr(PRONumberCommand.ExecuteScalar)
        Catch ex As Exception
            ProNumber = ""
        End Try
        Try
            ShippingCustomer = CStr(ShippingCustomerCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingCustomer = ""
        End Try
        Try
            ShipVia = CStr(ShipViaCommand.ExecuteScalar)
        Catch ex As Exception
            ShipVia = 0
        End Try
        Try
            FreightCharge = CDbl(FreightActualAmountCommand.ExecuteScalar)
        Catch ex As Exception
            FreightCharge = 0
        End Try
        Try
            ShippingDivision = CStr(ShippingDivisionCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingDivision = ""
        End Try
        Try
            ShippingDate = CStr(ShippingDateCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingDate = ""
        End Try
        con.Close()

        If ProNumber = "" Then
            ProNumber = "NONE ENTERED"
        Else
            'Skip
        End If

        If FreightCharge = 0 Then
            txtFreightCharges.Text = "NONE ENTERED"
        Else
            txtFreightCharges.Text = FormatCurrency(FreightCharge, 2)
        End If

        txtCustomer.Text = ShippingCustomer
        txtProNumber.Text = ProNumber
        txtShipDate.Text = ShippingDate
        txtShippingDivision.Text = ShippingDivision
        txtShipVia.Text = ShipVia
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub
End Class