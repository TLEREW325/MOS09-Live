Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class DailySalesForYear
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Date Variables
    Dim strYear As String = ""
    Dim DayCounter As Integer = 0
    Dim CurrentDate As String = ""
    Dim strDay As String = ""
    Dim SumDailySales, SumDailyInvoices, SumDailyShipments As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub DailySalesForYear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByYear

        LoadCurrentDivision()

        ClearDataInDatagrid()
        ClearVariables()
        ClearData()
    End Sub

    Public Sub ClearData()
        cboCalendarYear.SelectedIndex = -1
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvDailySalesTotals.DataSource = Nothing
        Me.dgvDailySalesTotals.RowCount = 0
    End Sub

    Public Sub ClearVariables()
        strYear = ""
        DayCounter = 0
        CurrentDate = ""
        strDay = ""
        SumDailySales = 0
        SumDailyInvoices = 0
        SumDailyShipments = 0
    End Sub

    Public Sub RunYearTotals()
        strYear = cboCalendarYear.Text
        '**********************************************************************************************************************
        'January Loop
        DayCounter = 1

        For i As Integer = 1 To 31
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "1/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'February Loop
        DayCounter = 1

        For i As Integer = 1 To 28
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "2/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'March Loop

        DayCounter = 1

        For i As Integer = 1 To 31
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "3/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'April Loop

        DayCounter = 1

        For i As Integer = 1 To 30
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "4/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'May Loop

        DayCounter = 1

        For i As Integer = 1 To 31
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "5/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'June Loop

        DayCounter = 1

        For i As Integer = 1 To 30
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "6/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'July Loop

        DayCounter = 1

        For i As Integer = 1 To 31
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "7/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'August Loop

        DayCounter = 1

        For i As Integer = 1 To 31
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "8/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'September Loop

        DayCounter = 1

        For i As Integer = 1 To 30
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "9/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'October Loop

        DayCounter = 1

        For i As Integer = 1 To 31
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "10/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'November Loop

        DayCounter = 1

        For i As Integer = 1 To 30
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "11/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************************
        'December Loop
        DayCounter = 1

        For i As Integer = 1 To 31
            'Get Date
            strDay = CStr(DayCounter)
            CurrentDate = "12/" + strDay + "/" + strYear
            Dim CurrentDivision As String = cboDivisionID.Text

            Dim SUMDailySalesStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND (DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2) AND SalesOrderDate = @SalesOrderDate"
            Dim SUMDailySalesCommand As New SqlCommand(SUMDailySalesStatement, con)
            SUMDailySalesCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            SUMDailySalesCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailySalesCommand.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
            SUMDailySalesCommand.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyShipmentsStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND ShipDate = @ShipDate"
            Dim SUMDailyShipmentsCommand As New SqlCommand(SUMDailyShipmentsStatement, con)
            SUMDailyShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyShipmentsCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyShipmentsCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = CurrentDate

            Dim SUMDailyInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE InvoiceStatus <> @InvoiceStatus AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate = @InvoiceDate"
            Dim SUMDailyInvoicesCommand As New SqlCommand(SUMDailyInvoicesStatement, con)
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMDailyInvoicesCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            SUMDailyInvoicesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CurrentDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDailySales = CDbl(SUMDailySalesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailySales = 0
            End Try
            Try
                SumDailyShipments = CDbl(SUMDailyShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyShipments = 0
            End Try
            Try
                SumDailyInvoices = CDbl(SUMDailyInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SumDailyInvoices = 0
            End Try
            con.Close()

            'Add line to datagrid
            Me.dgvDailySalesTotals.Rows.Add(CurrentDate, SumDailySales, SumDailyShipments, SumDailyInvoices, CurrentDivision)

            DayCounter = DayCounter + 1
        Next

        SumDailySales = 0
        SumDailyShipments = 0
        SumDailyInvoices = 0
        '**********************************************************************************************************
        If Me.dgvDailySalesTotals.RowCount = 0 Then
            cmdViewByYear.Enabled = True
        Else
            cmdViewByYear.Enabled = False
        End If
        '***********************************************************************************************************
        MsgBox("Yearly Sales compiled.", MsgBoxStyle.OkOnly)
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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewByYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByYear.Click
        RunYearTotals()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCalendarYear.SelectedIndex = -1

        ClearVariables()
        ClearVariables()
        ClearDataInDatagrid()
        '**********************************************************************************************************
        If Me.dgvDailySalesTotals.RowCount = 0 Then
            cmdViewByYear.Enabled = True
        Else
            cmdViewByYear.Enabled = False
        End If
    End Sub
End Class