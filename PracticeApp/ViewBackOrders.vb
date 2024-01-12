Imports System
Imports System.Math
Imports System.IO
Imports System.Net.Mail
Imports System.Web
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewBackOrders
    Inherits System.Windows.Forms.Form

    Dim BeginDate, EndDate As Date
    Dim TextFilter, BackOrderFilter, PickedOrderFilter, OpenOrderFilter, SOFilter, PartFilter, DateFilter, CustPOFilter, CustomerFilter, SalespersonFilter As String
    Dim SONumber, RunningCount, LastCountNumber As Integer
    Dim strSONumber As String
    Dim SalesOrderKey As Integer = 0
    Dim NextPickBatchNumber, LastPickBatchNumber, NextPickNumber, LastPickNumber, LastPickLineNumber, NextPickLineNumber As Integer
    Dim NextShipBatchNumber, LastShipBatchNumber, NextShipmentNumber, LastShipmentNumber, LastShipLineNumber, NextShipLineNumber As Integer
    Dim ShipToName, ShipEmail, AdditionalShipTo, CustomerClass, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, CustomerID As String
    Dim ProductTotal, ProductWeight, SalesTax, BoxWeight As Double

    'Variables for updating QOH
    Dim PickQOH As Double = 0
    Dim CountPickLines As Integer = 0
    Dim MasterPickTicketNumber As Integer = 0
    Dim Counter As Integer = 0
    Dim QOHPartNumber As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewBackOrders_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
        GlobalPickBatchNumber = 0
        GlobalPickListNumber = 0
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

    Public Sub LoadUpdateQOH()
        Try
            'Count Lines in PickListLineTable for selected Pick Ticket
            Dim CountPickLinesStatement As String = "SELECT COUNT(PickListHeaderKey) FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
            Dim CountPickLinesCommand As New SqlCommand(CountPickLinesStatement, con)
            CountPickLinesCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = MasterPickTicketNumber
            CountPickLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPickLines = CInt(CountPickLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountPickLines = 0
            End Try
            con.Close()

            'Set Counter
            Counter = 1

            'Run FOR/NEXT Loop for each line to update QOH
            For i As Integer = 1 To CountPickLines
                'Get Part Number from Pick Ticket
                Dim GetPartNumberStatement As String = "SELECT ItemID FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID AND PickListLineKey = @PickListLineKey"
                Dim GetPartNumberCommand As New SqlCommand(GetPartNumberStatement, con)
                GetPartNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = MasterPickTicketNumber
                GetPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetPartNumberCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = Counter

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    QOHPartNumber = CStr(GetPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    QOHPartNumber = ""
                End Try
                con.Close()

                Dim GetQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetQOHCommand As New SqlCommand(GetQOHStatement, con)
                GetQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = QOHPartNumber
                GetQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PickQOH = CDbl(GetQOHCommand.ExecuteScalar)
                Catch ex As Exception
                    PickQOH = 0
                End Try
                con.Close()

                'Update PickList
                cmd = New SqlCommand("UPDATE PickListLineTable SET QOH = @QOH WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = MasterPickTicketNumber
                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = Counter
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@QOH", SqlDbType.VarChar).Value = PickQOH
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Counter = Counter + 1
            Next

            PickQOH = 0
            CountPickLines = 0
            Counter = 0
            QOHPartNumber = ""
        Catch ex As Exception
            'Log error on update failure
            Dim TempPickNumber As Integer = 0
            Dim strPickNumber As String
            TempPickNumber = MasterPickTicketNumber
            strPickNumber = CStr(TempPickNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Maintain Back Orders --- Update Pick QOH Failure"
            ErrorReferenceNumber = "Pick Ticket # " + strPickNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub ViewBackOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            cmdProcessBackOrder.Enabled = False
        Else
            cmdProcessBackOrder.Enabled = True
        End If

        If cboDivisionID.Text.Equals("TWD") Or cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text = "ALB" Then
            cmdViewWIP.Visible = True
        End If
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO LIKE '%" + usefulFunctions.checkQuote(txtCustomerPO.Text) + "%'"
        Else
            CustPOFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (ItemID LIKE '%" + txtTextFilter.Text + "%' OR Description LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboSalesperson.Text <> "" Then
            SalespersonFilter = " AND Salesperson = '" + cboSalesperson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If chkBackOrders.Checked = False Then
            BackOrderFilter = ""
        Else
            BackOrderFilter = " AND LineStatus = 'OPEN' AND SOStatus = 'OPEN' AND MAXShipmentNumber > 0"
        End If
        If chkOpenOrders.Checked = False Then
            OpenOrderFilter = ""
        Else
            OpenOrderFilter = " AND QuantityShipped = 0 AND LineStatus = 'OPEN' AND SOStatus = 'OPEN' AND MAXShipmentNumber = 0"
        End If
        If chkPickedOrders.Checked = False Then
            PickedOrderFilter = ""
        Else
            PickedOrderFilter = " AND SOStatus = 'SHIPPED'"
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
 
            DateFilter = " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM BackOrderTest WHERE DivisionKey = @DivisionKey" + CustPOFilter + CustomerFilter + PartFilter + SalespersonFilter + SOFilter + BackOrderFilter + PickedOrderFilter + OpenOrderFilter + TextFilter + DateFilter + " ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        lblLoading.Visible = True
    End Sub

    Public Sub ShowDataByFiltersADM()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO LIKE '%" + usefulFunctions.checkQuote(txtCustomerPO.Text) + "%'"
        Else
            CustPOFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboSalesperson.Text <> "" Then
            SalespersonFilter = " AND Salesperson = '" + cboSalesperson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM BackOrderTest where DivisionKey <> @DivisionKey AND QuantityOpen > 0 AND LineStatus = 'OPEN'" + CustPOFilter + CustomerFilter + PartFilter + SalespersonFilter + SOFilter + DateFilter + " ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "BackOrderTest")
        dgvBackOrderLineQuery.DataSource = ds.Tables("BackOrderTest")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvBackOrderLineQuery.DataSource = Nothing
    End Sub

    Public Sub PrintSalesOrders()
        Dim SalesOrderKey As Integer

        'Get Sales Order Number
        If Me.dgvBackOrderLineQuery.RowCount <> 0 Then

            Dim RowIndex As Integer = Me.dgvBackOrderLineQuery.CurrentCell.RowIndex

            SalesOrderKey = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

            'Choose correct print form
            If cboDivisionID.Text = "TFP" Then
                GlobalSONumber = SalesOrderKey
                GlobalDivisionCode = cboDivisionID.Text
                GlobalTFPSOPrintForm = "TFP Acknowledgement"

                Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
                    Dim result = NewPrintTFAcknowledgement.ShowDialog()
                End Using
            Else
                'Chose the correct Print Form (REMOTE or LOCAL)

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
                    GlobalSONumber = SalesOrderKey
                    GlobalDivisionCode = cboDivisionID.Text
                    Using NewPrintSalesOrderRemote As New PrintSalesOrderRemote
                        Dim result = NewPrintSalesOrderRemote.ShowDialog()
                    End Using
                Else
                    GlobalSONumber = SalesOrderKey
                    GlobalDivisionCode = cboDivisionID.Text
                    Using NewPrintSalesOrder As New PrintSalesOrder
                        Dim result = NewPrintSalesOrder.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Public Sub PrintPicks()
        'Get Sales Order Number
        Dim SalesOrderKey As Integer

        'Get Sales Order Number
        If Me.dgvBackOrderLineQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvBackOrderLineQuery.CurrentCell.RowIndex

            SalesOrderKey = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

            'heck database to see if pick tickets exist
            Dim CountPicks As Integer

            Dim CountPicksString As String = "SELECT COUNT(PickListHeaderKey) FROM PickListHeaderTable WHERE SalesOrderHeaderKey = @SalesOrderHeaderKey AND DivisionID = @DivisionID"
            Dim CountPicksCommand As New SqlCommand(CountPicksString, con)
            CountPicksCommand.Parameters.Add("@SalesOrderHeaderKey", SqlDbType.VarChar).Value = SalesOrderKey
            CountPicksCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPicks = CInt(CountPicksCommand.ExecuteScalar)
            Catch ex As System.Exception
                CountPicks = 0
            End Try
            con.Close()

            If CountPicks = 0 Then
                MsgBox("There are no Pick Tickets for this Sales Order.", MsgBoxStyle.OkOnly)
            Else
                GlobalSONumberPickList = SalesOrderKey
                GlobalDivisionCode = cboDivisionID.Text

                'Chose the correct Print Form (REMOTE or LOCAL)

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
                    Using NewPrintPickTicketsSORemote As New PrintPickTicketsSORemote
                        Dim Result = NewPrintPickTicketsSORemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintPickTicketSO As New PrintPickTicketsSO()
                        Dim Result = NewPrintPickTicketSO.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Public Sub PrintPackingSlips()
        'Get Sales Order Number
        Dim SalesOrderKey As Integer

        'Get Sales Order Number
        If Me.dgvBackOrderLineQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvBackOrderLineQuery.CurrentCell.RowIndex

            SalesOrderKey = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

            'Check database to see if shipments exist
            Dim CountPacks As Integer

            Dim CountPacksString As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
            Dim CountPacksCommand As New SqlCommand(CountPacksString, con)
            CountPacksCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
            CountPacksCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPacks = CInt(CountPacksCommand.ExecuteScalar)
            Catch ex As System.Exception
                CountPacks = 0
            End Try
            con.Close()

            If CountPacks = 0 Then
                MsgBox("There are no Packing Lists for this Sales Order.", MsgBoxStyle.OkOnly)
            Else
                GlobalSONumberPackSlip = SalesOrderKey
                GlobalDivisionCode = cboDivisionID.Text

                'Chose the correct Print Form (REMOTE or LOCAL)

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
                    Using NewPrintPackListSORemote As New PrintPackListSORemote
                        Dim Result = NewPrintPackListSORemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintPackListSO As New PrintPackListSO
                        Dim Result = NewPrintPackListSO.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Public Sub LoadCustomerID()
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

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerName.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList where DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID <> @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "NON-INVENTORY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartNumber.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList where DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID <> @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "NON-INVENTORY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboPartDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadSONumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable where DivisionKey = @DivisionKey ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds5.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesperson()
        If cboDivisionID.Text = "TWD" Then
            cmd = New SqlCommand("SELECT DISTINCT SalesPersonID FROM EmployeeData where DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "EmployeeData")
            cboSalesperson.DataSource = ds6.Tables("EmployeeData")
            con.Close()
            cboSalesperson.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT DISTINCT SalesPersonID FROM EmployeeData where DivisionKey = @DivisionKey", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "EmployeeData")
            cboSalesperson.DataSource = ds6.Tables("EmployeeData")
            con.Close()
            cboSalesperson.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadSOLines()
        cmd = New SqlCommand("SELECT * FROM SalesOrderQuantityStatus where SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey AND QuantityOpen > @QuantityOpen AND LineStatus <> @LineStatus", con)
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@QuantityOpen", SqlDbType.VarChar).Value = 0
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "SalesOrderQuantityStatus")
        dgvSOLines.DataSource = ds7.Tables("SalesOrderQuantityStatus")
        con.Close()
    End Sub

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

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
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

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadShippingFormatting()
        Dim QuantityShipped As Double = 0
        Dim QuantityOpen As Double = 0
        Dim RowIndex As Integer = 0
        Dim SOStatus As String = ""
        Dim LineStatus As String = ""
        Dim MaxShipmentNumber As Integer = 0

        For Each row As DataGridViewRow In dgvBackOrderLineQuery.Rows
            Try
                QuantityShipped = row.Cells("QuantityShippedColumn").Value
            Catch ex As System.Exception
                QuantityShipped = 0
            End Try
            Try
                QuantityOpen = row.Cells("QuantityOpenColumn").Value
            Catch ex As System.Exception
                QuantityOpen = 0
            End Try
            Try
                SOStatus = row.Cells("SOStatusColumn").Value
            Catch ex As System.Exception
                SOStatus = ""
            End Try
            Try
                LineStatus = row.Cells("LineStatusColumn").Value
            Catch ex As System.Exception
                LineStatus = ""
            End Try
            Try
                MaxShipmentNumber = row.Cells("MAXShipmentNumberColumn").Value
            Catch ex As System.Exception
                MaxShipmentNumber = 0
            End Try

            If QuantityShipped = 0 And LineStatus = "OPEN" And SOStatus = "OPEN" And MaxShipmentNumber = 0 Then
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf QuantityShipped = 0 And LineStatus = "OPEN" And SOStatus = "OPEN" And MaxShipmentNumber <> 0 Then
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
            ElseIf QuantityShipped > 0 And LineStatus = "OPEN" And SOStatus = "OPEN" And MaxShipmentNumber <> 0 Then
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
            ElseIf LineStatus = "OPEN" And SOStatus = "SHIPPED" Then
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            Else
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvBackOrderLineQuery.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboSalesperson.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        txtCustomerPO.Clear()
        txtTextFilter.Clear()

        chkBackOrders.Checked = False
        chkDateRange.Checked = False
        chkOpenOrders.Checked = False
        chkPickedOrders.Checked = False
        chkPrintPackingList.Checked = False
        chkPrintPickTicket.Checked = False

        GlobalSONumber = 0
    End Sub

    Public Sub ClearVariables()
        BackOrderFilter = ""
        ShipToName = ""
        PickedOrderFilter = ""
        OpenOrderFilter = ""
        SOFilter = ""
        PartFilter = ""
        DateFilter = ""
        TextFilter = ""
        CustPOFilter = ""
        CustomerFilter = ""
        SalespersonFilter = ""
        SONumber = 0
        strSONumber = ""
        SalesOrderKey = 0
        'NextPickBatchNumber = 0
        LastPickBatchNumber = 0
        NextPickNumber = 0
        LastPickNumber = 0
        LastPickLineNumber = 0
        NextPickLineNumber = 0
        'NextShipBatchNumber = 0
        LastShipBatchNumber = 0
        NextShipmentNumber = 0
        LastShipmentNumber = 0
        LastShipLineNumber = 0
        NextShipLineNumber = 0
        AdditionalShipTo = ""
        CustomerClass = ""
        ShipToAddress1 = ""
        ShipToAddress2 = ""
        ShipToCity = ""
        ShipToState = ""
        ShipToZip = ""
        ShipToCountry = ""
        ShipEmail = ""
        CustomerID = ""
        ProductTotal = 0
        ProductWeight = 0
        SalesTax = 0
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        LoadCustomerID()
        LoadCustomerName()
        LoadSONumber()
        LoadSalesperson()
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdOpenSOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenSOForm.Click
        Dim RowSONumber As Integer
        Dim RowIndex As Integer = Me.dgvBackOrderLineQuery.CurrentCell.RowIndex

        RowSONumber = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

        GlobalSONumber = RowSONumber
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewSOForm As New SOForm
        NewSOForm.Show()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        If cboDivisionID.Text = "ADM" Then
            ShowDataByFiltersADM()
            Me.dgvBackOrderLineQuery.Columns("DivisionKeyColumn").Visible = True
        Else
            ShowDataByFilters()
            BGLoading.RunWorkerAsync()
            Me.dgvBackOrderLineQuery.Columns("DivisionKeyColumn").Visible = False
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        lblLoading.Visible = False
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        lblLoading.Visible = False

        GDS = ds

        Using NewPrintBackOrdersFiltered As New PrintBackOrdersFiltered
            Dim Result = NewPrintBackOrdersFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintBOListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBOListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintBackOrdersFiltered As New PrintBackOrdersFiltered
            Dim Result = NewPrintBackOrdersFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvBackOrderLineQuery_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        LoadShippingFormatting()
    End Sub

    Private Sub chkOpenOrders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOpenOrders.CheckedChanged
        If chkOpenOrders.Checked = True Then
            chkPickedOrders.Checked = False
            chkBackOrders.Checked = False
        End If
    End Sub

    Private Sub chkPickedOrders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPickedOrders.CheckedChanged
        If chkPickedOrders.Checked = True Then
            chkOpenOrders.Checked = False
            chkBackOrders.Checked = False
        End If
    End Sub

    Private Sub chkBackOrders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBackOrders.CheckedChanged
        If chkBackOrders.Checked = True Then
            chkPickedOrders.Checked = False
            chkOpenOrders.Checked = False
        End If
    End Sub

    Private Sub cmdCompleteShipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompleteShipment.Click
        Dim NewShipmentCompletion As New ShipmentCompletion
        NewShipmentCompletion.Show()
    End Sub

    Private Sub chkPrintPickTicket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintPickTicket.CheckedChanged
        If chkPrintPickTicket.Checked = True Then
            chkPrintPackingList.Checked = False
        End If
    End Sub

    Private Sub chkPrintPackingList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintPackingList.CheckedChanged
        If chkPrintPackingList.Checked = True Then
            chkPrintPickTicket.Checked = False
        End If
    End Sub

    Private Sub cmdProcessBackOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcessBackOrder.Click
        lblLoading.Visible = False

        Dim SOStatus As String = ""
        Dim QuantityShipped As Double = 0
        Dim MaxShipmentNumber As Integer = 0
        Dim SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3 As String

        Dim RowIndex As Integer = Me.dgvBackOrderLineQuery.CurrentCell.RowIndex

        SalesOrderKey = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value
        SOStatus = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SOStatusColumn").Value
        QuantityShipped = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("QuantityShippedColumn").Value
        MaxShipmentNumber = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("MAXShipmentNumberColumn").Value

        If SOStatus = "OPEN" And MaxShipmentNumber > 0 Then
            'Get SO Header data to create pick ticket and shipment headers
            Dim ThirdPartyShipper, ShippingMethod, CustomerPO, PRONumber, ShipVia, ShippingDate, Salesperson, SpecialInstructions, HeaderComment, ShippingAccount As String

            Try
                CustomerID = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("CustomerIDColumn").Value
            Catch ex As System.Exception
                CustomerID = ""
            End Try
            Try
                CustomerPO = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("CustomerPOColumn").Value
            Catch ex As System.Exception
                CustomerPO = ""
            End Try
            Try
                ShipVia = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("ShipViaColumn").Value
            Catch ex As System.Exception
                ShipVia = "DELIVERY"
            End Try
            Try
                ShippingDate = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("ShippingDateColumn").Value
            Catch ex As System.Exception
                ShippingDate = ""
            End Try
            Try
                Salesperson = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SalespersonColumn").Value
            Catch ex As System.Exception
                Salesperson = ""
            End Try
            Try
                ShippingMethod = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("ShippingMethodColumn").Value
            Catch ex As System.Exception
                ShippingMethod = ""
            End Try

            'Get Sales Order Header Data
            Dim GetSODataStatement As String = "SELECT * FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
            Dim GetSODataCommand As New SqlCommand(GetSODataStatement, con)
            GetSODataCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
            GetSODataCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetSODataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("SpecialInstructions")) Then
                    SpecialInstructions = ""
                Else
                    SpecialInstructions = reader.Item("SpecialInstructions")
                End If
                If IsDBNull(reader.Item("HeaderComment")) Then
                    HeaderComment = ""
                Else
                    HeaderComment = reader.Item("HeaderComment")
                End If
                If IsDBNull(reader.Item("ShipToName")) Then
                    ShipToName = ""
                Else
                    ShipToName = reader.Item("ShipToName")
                End If
                If IsDBNull(reader.Item("ShipToAddress1")) Then
                    ShipToAddress1 = ""
                Else
                    ShipToAddress1 = reader.Item("ShipToAddress1")
                End If
                If IsDBNull(reader.Item("ShipToAddress2")) Then
                    ShipToAddress2 = ""
                Else
                    ShipToAddress2 = reader.Item("ShipToAddress2")
                End If
                If IsDBNull(reader.Item("ShipToCity")) Then
                    ShipToCity = ""
                Else
                    ShipToCity = reader.Item("ShipToCity")
                End If
                If IsDBNull(reader.Item("ShipToState")) Then
                    ShipToState = ""
                Else
                    ShipToState = reader.Item("ShipToState")
                End If
                If IsDBNull(reader.Item("ShipToZip")) Then
                    ShipToZip = ""
                Else
                    ShipToZip = reader.Item("ShipToZip")
                End If
                If IsDBNull(reader.Item("ShipToCountry")) Then
                    ShipToCountry = ""
                Else
                    ShipToCountry = reader.Item("ShipToCountry")
                End If
                If IsDBNull(reader.Item("ThirdPartyShipper")) Then
                    ThirdPartyShipper = ""
                Else
                    ThirdPartyShipper = reader.Item("ThirdPartyShipper")
                End If
                If IsDBNull(reader.Item("PRONumber")) Then
                    PRONumber = ""
                Else
                    PRONumber = reader.Item("PRONumber")
                End If
                If IsDBNull(reader.Item("AdditionalShipTo")) Then
                    AdditionalShipTo = ""
                Else
                    AdditionalShipTo = reader.Item("AdditionalShipTo")
                End If
                If IsDBNull(reader.Item("CustomerClass")) Then
                    CustomerClass = ""
                Else
                    CustomerClass = reader.Item("CustomerClass")
                End If
                If IsDBNull(reader.Item("ShipEmail")) Then
                    ShipEmail = ""
                Else
                    ShipEmail = reader.Item("ShipEmail")
                End If
                If IsDBNull(reader.Item("ShippingAccount")) Then
                    ShippingAccount = ""
                Else
                    ShippingAccount = reader.Item("ShippingAccount")
                End If
                If IsDBNull(reader.Item("SpecialLabelLine1")) Then
                    SpecialLabelLine1 = ""
                Else
                    SpecialLabelLine1 = reader.Item("SpecialLabelLine1")
                End If
                If IsDBNull(reader.Item("SpecialLabelLine2")) Then
                    SpecialLabelLine2 = ""
                Else
                    SpecialLabelLine2 = reader.Item("SpecialLabelLine2")
                End If
                If IsDBNull(reader.Item("SpecialLabelLine3")) Then
                    SpecialLabelLine3 = ""
                Else
                    SpecialLabelLine3 = reader.Item("SpecialLabelLine3")
                End If
            Else
                SpecialInstructions = ""
                HeaderComment = ""
                ShipToName = ""
                ShipToAddress1 = ""
                ShipToAddress2 = ""
                ShipToCity = ""
                ShipToCountry = ""
                ShipToZip = ""
                ShipToState = ""
                ThirdPartyShipper = ""
                PRONumber = ""
                AdditionalShipTo = ""
                CustomerClass = ""
                ShipEmail = ""
                ShippingAccount = ""
                SpecialLabelLine1 = ""
                SpecialLabelLine2 = ""
                SpecialLabelLine3 = ""
            End If
            reader.Close()
            con.Close()
            '******************************************************************************************
            'If Ship To Name is blank, get from customer, add ship to
            If ShipToName = "" And AdditionalShipTo = "" Then
                Dim GetShipToNameCustomer As String = ""

                Dim GetShipToNameCustomerStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim GetShipToNameCustomerCommand As New SqlCommand(GetShipToNameCustomerStatement, con)
                GetShipToNameCustomerCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                GetShipToNameCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipToNameCustomer = CStr(GetShipToNameCustomerCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetShipToNameCustomer = ""
                End Try
                con.Close()

                ShipToName = GetShipToNameCustomer
            ElseIf ShipToName = "" And AdditionalShipTo <> "" Then
                Dim GetAdditionalShipToName As String = ""

                Dim GetAdditionalShipToNameStatement As String = "SELECT AdditionalShipTo FROM SalesOrderHeaderTable WHERE CustomerID = @CustomerID AND ShipToID = @ShipToID AND DivisionID = @DivisionID"
                Dim GetAdditionalShipToNameCommand As New SqlCommand(GetAdditionalShipToNameStatement, con)
                GetAdditionalShipToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                GetAdditionalShipToNameCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = AdditionalShipTo
                GetAdditionalShipToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetAdditionalShipToName = CStr(GetAdditionalShipToNameCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetAdditionalShipToName = ""
                End Try
                con.Close()

                ShipToName = GetAdditionalShipToName
            End If

            'Create New Pick Ticket Header
            '****************************************************************************************************
            'Use new Batch Number for current selection
            Dim PLBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM PickListHeaderTable"
            Dim PLBatchNumberCommand As New SqlCommand(PLBatchNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastPickBatchNumber = CInt(PLBatchNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastPickBatchNumber = 874000000
            End Try
            con.Close()

            NextPickBatchNumber = LastPickBatchNumber + 1
            '****************************************************************************************************
            'Create new Pick Ticket Number
            Dim PickTicketNumberStatement As String = "SELECT MAX(PickListHeaderKey) FROM PickListHeaderTable"
            Dim PickTicketNumberCommand As New SqlCommand(PickTicketNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastPickNumber = CInt(PickTicketNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastPickNumber = 660000
            End Try
            con.Close()

            NextPickNumber = LastPickNumber + 1
            '****************************************************************************************************
            'If TWD, get running count number
            If cboDivisionID.Text = "TWD" Then
                Dim RunningCountStatement As String = "SELECT MAX(RunningCount) FROM PickListHeaderTable"
                Dim RunningCountCommand As New SqlCommand(RunningCountStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastCountNumber = CInt(RunningCountCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastCountNumber = 0
                End Try
                con.Close()

                RunningCount = LastCountNumber + 1
            Else
                RunningCount = 0
            End If
            '****************************************************************************************************
            'Write Data to Pick Ticket Header Database Table
            cmd = New SqlCommand("Insert Into PickListHeaderTable(PickListHeaderKey, SalesOrderHeaderKey, PickDate, DivisionID, Comment, PLStatus, CustomerID, CustomerPO, ShipVia, AdditionalShipTo, BatchNumber, PRONumber, SalesmanID, SpecialInstructions, ShipDate, PickCount, RunningCount, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3, DeclaredValue, DeclaredValueAdded) Values (@PickListHeaderKey, @SalesOrderHeaderKey, @PickDate, @DivisionID, @Comment, @PLStatus, @CustomerID, @CustomerPO, @ShipVia, @AdditionalShipTo, @BatchNumber, @PRONumber, @SalesmanID, @SpecialInstructions, @ShipDate, @PickCount, @RunningCount, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3, @DeclaredValue, @DeclaredValueAdded)", con)

            With cmd.Parameters
                .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextPickNumber
                .Add("@SalesOrderHeaderKey", SqlDbType.VarChar).Value = SalesOrderKey
                .Add("@PickDate", SqlDbType.VarChar).Value = Today()
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Comment", SqlDbType.VarChar).Value = HeaderComment
                .Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
                .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = AdditionalShipTo
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NextPickBatchNumber
                .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                .Add("@SalesmanID", SqlDbType.VarChar).Value = Salesperson
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                .Add("@ShipDate", SqlDbType.VarChar).Value = Today()
                .Add("@PickCount", SqlDbType.VarChar).Value = 3
                .Add("@RunningCount", SqlDbType.VarChar).Value = RunningCount
                .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                .Add("@ShipToAddress1", SqlDbType.VarChar).Value = ShipToAddress1
                .Add("@ShipToAddress2", SqlDbType.VarChar).Value = ShipToAddress2
                .Add("@ShipToCity", SqlDbType.VarChar).Value = ShipToCity
                .Add("@ShipToState", SqlDbType.VarChar).Value = ShipToState
                .Add("@ShipToZip", SqlDbType.VarChar).Value = ShipToZip
                .Add("@ShipToCountry", SqlDbType.VarChar).Value = ShipToCountry
                .Add("@ShipEmail", SqlDbType.VarChar).Value = ShipEmail
                .Add("@ShippingAccount", SqlDbType.VarChar).Value = ShippingAccount
                .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = SpecialLabelLine1
                .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = SpecialLabelLine2
                .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = SpecialLabelLine3
                .Add("@DeclaredValue", SqlDbType.VarChar).Value = 0
                .Add("@DeclaredValueAdded", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '****************************************************************************************************
            Dim GLBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM ShipmentHeaderTable"
            Dim GLBatchNumberCommand As New SqlCommand(GLBatchNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastShipBatchNumber = CInt(GLBatchNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastShipBatchNumber = 880000000
            End Try
            con.Close()

            NextShipBatchNumber = LastShipBatchNumber + 1
            '****************************************************************************************************
            'Create new Shipment Number
            Dim ShipmentNumberStatement As String = "SELECT MAX(ShipmentNumber) FROM ShipmentHeaderTable"
            Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastShipmentNumber = 4560000
            End Try
            con.Close()

            NextShipmentNumber = LastShipmentNumber + 1
            '****************************************************************************************************
            'Write Data to Shipment Header Table
            cmd = New SqlCommand("Insert Into ShipmentHeaderTable(ShipmentNumber, SalesOrderKey, ShipDate, DivisionID, Comment, PickTicketNumber, ShipVia, PRONumber, FreightQuoteNumber, FreightQuoteAmount, FreightActualAmount, ShippingWeight, NumberOfPallets, CustomerID, ShipToID, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, CustomerPO, ShipmentStatus, ProductTotal, TaxTotal, ShipmentTotal, BatchNumber, SalesmanID, SpecialInstructions, Tax2Total, Tax3Total, CertsAutoGenerated, SOLog, PulledBy, CertsPulled, PackingSlip, Locked, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper, ShipToName, PostedBy, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3) Values (@ShipmentNumber, @SalesOrderKey, @ShipDate, @DivisionID, @Comment, @PickTicketNumber, @ShipVia, @PRONumber, @FreightQuoteNumber, @FreightQuoteAmount, @FreightActualAmount, @ShippingWeight, @NumberOfPallets, @CustomerID, @ShipToID, @ShipAddress1, @ShipAddress2, @ShipCity, @ShipState, @ShipZip, @ShipCountry, @CustomerPO, @ShipmentStatus, @ProductTotal, @TaxTotal, @ShipmentTotal, @BatchNumber, @SalesmanID, @SpecialInstructions, @Tax2Total, @Tax3Total, @CertsAutoGenerated, @SOLog, @PulledBy, @CertsPulled, @PackingSlip, @Locked, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @PostedBy, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3)", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                .Add("@ShipDate", SqlDbType.VarChar).Value = ShippingDate
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Comment", SqlDbType.VarChar).Value = HeaderComment
                .Add("@PickTicketNumber", SqlDbType.VarChar).Value = NextPickNumber
                .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = ""
                .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = 0
                .Add("@FreightActualAmount", SqlDbType.VarChar).Value = 0
                .Add("@ShippingWeight", SqlDbType.VarChar).Value = 0
                .Add("@NumberOfPallets", SqlDbType.VarChar).Value = 1
                .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                .Add("@ShipToID", SqlDbType.VarChar).Value = AdditionalShipTo
                .Add("@ShipAddress1", SqlDbType.VarChar).Value = ShipToAddress1
                .Add("@ShipAddress2", SqlDbType.VarChar).Value = ShipToAddress2
                .Add("@ShipCity", SqlDbType.VarChar).Value = ShipToCity
                .Add("@ShipState", SqlDbType.VarChar).Value = ShipToState
                .Add("@ShipZip", SqlDbType.VarChar).Value = ShipToZip
                .Add("@ShipCountry", SqlDbType.VarChar).Value = ShipToCountry
                .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
                .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                .Add("@TaxTotal", SqlDbType.VarChar).Value = 0
                .Add("@ShipmentTotal", SqlDbType.VarChar).Value = 0
                .Add("@BatchNumber", SqlDbType.VarChar).Value = LastShipBatchNumber
                .Add("@SalesmanID", SqlDbType.VarChar).Value = Salesperson
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                .Add("@Tax2Total", SqlDbType.VarChar).Value = 0
                .Add("@Tax3Total", SqlDbType.VarChar).Value = 0
                .Add("@CertsAutoGenerated", SqlDbType.VarChar).Value = "NO"
                .Add("@SOLog", SqlDbType.VarChar).Value = ""
                .Add("@PulledBy", SqlDbType.VarChar).Value = ""
                .Add("@CertsPulled", SqlDbType.VarChar).Value = ""
                .Add("@PackingSlip", SqlDbType.VarChar).Value = ""
                .Add("@Locked", SqlDbType.VarChar).Value = ""
                .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                .Add("@FOB", SqlDbType.VarChar).Value = "Medina"
                .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                .Add("@PostedBy", SqlDbType.VarChar).Value = ""
                .Add("@ShipEmail", SqlDbType.VarChar).Value = ShipEmail
                .Add("@ShippingAccount", SqlDbType.VarChar).Value = ShippingAccount
                .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = SpecialLabelLine1
                .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = SpecialLabelLine2
                .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = SpecialLabelLine3
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Load SO Line data
            LoadSOLines()

            'Define Line Variables
            Dim SalesOrderLineKey As Integer = 0
            Dim BoxCount As Double = 0
            Dim LineBoxesOpen As Integer = 0
            Dim Price, QuantityOpen, LineWeightOpen, SalesTaxOpen As Double
            Dim PartNumber, PartDescription, LineComment, DebitGLAccount, CreditGLAccount, CertType As String

            'Run routine to add lines to each table
            For Each row As DataGridViewRow In dgvSOLines.Rows
                Try
                    SalesOrderLineKey = row.Cells("SOSalesOrderLineKeyColumn").Value
                Catch ex As System.Exception
                    SalesOrderLineKey = 0
                End Try
                Try
                    Price = row.Cells("SOPriceColumn").Value
                Catch ex As System.Exception
                    Price = 0
                End Try
                Try
                    QuantityOpen = row.Cells("SOQuantityOpenColumn").Value
                Catch ex As System.Exception
                    QuantityOpen = 0
                End Try
                Try
                    SalesTaxOpen = row.Cells("SOSalesTaxOpenColumn").Value
                Catch ex As System.Exception
                    SalesTaxOpen = 0
                End Try
                Try
                    PartNumber = row.Cells("SOItemIDColumn").Value
                Catch ex As System.Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("SODescriptionColumn").Value
                Catch ex As System.Exception
                    PartDescription = ""
                End Try
                Try
                    LineComment = row.Cells("SOLineCommentColumn").Value
                Catch ex As System.Exception
                    LineComment = ""
                End Try
                Try
                    DebitGLAccount = row.Cells("SODebitGLAccountColumn").Value
                Catch ex As System.Exception
                    DebitGLAccount = "49999"
                End Try
                Try
                    CreditGLAccount = row.Cells("SOCreditGLAccountColumn").Value
                Catch ex As System.Exception
                    CreditGLAccount = "12100"
                End Try
                Try
                    CertType = row.Cells("SOCertificationTypeColumn").Value
                Catch ex As System.Exception
                    CertType = "0"
                End Try
                '****************************************************************************************************
                Dim PieceWeight As Double = 0

                Dim BoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim BoxCountCommand As New SqlCommand(BoxCountStatement, con)
                BoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                BoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim PieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim PieceWeightCommand As New SqlCommand(PieceWeightStatement, con)
                PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim BoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim BoxWeightCommand As New SqlCommand(BoxWeightStatement, con)
                BoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                BoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetQOHCommand As New SqlCommand(GetQOHStatement, con)
                GetQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                GetQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    BoxCount = CDbl(BoxCountCommand.ExecuteScalar)
                Catch ex As System.Exception
                    BoxCount = 0
                End Try
                Try
                    PieceWeight = CDbl(PieceWeightCommand.ExecuteScalar)
                Catch ex As System.Exception
                    PieceWeight = 0
                End Try
                Try
                    BoxWeight = CDbl(BoxWeightCommand.ExecuteScalar)
                Catch ex As System.Exception
                    BoxWeight = 0
                End Try
                Try
                    PickQOH = CDbl(GetQOHCommand.ExecuteScalar)
                Catch ex As Exception
                    PickQOH = 0
                End Try
                con.Close()

                LineWeightOpen = PieceWeight * QuantityOpen
                LineWeightOpen = Math.Round(LineWeightOpen, 1)
                '****************************************************************************************************
                'Determine Open Box Count
                'Avoid Divide-By-Zero Error
                If BoxCount = 0 Then
                    LineBoxesOpen = 0
                Else
                    'LineBoxesOpen = SLQuantity / BoxCount

                    'Verify full boxes
                    If QuantityOpen Mod BoxCount = 0 Then
                        LineBoxesOpen = QuantityOpen / BoxCount
                    Else
                        LineBoxesOpen = QuantityOpen / BoxCount
                        LineBoxesOpen = Math.Round(LineBoxesOpen, 1)
                    End If
                End If
                '****************************************************************************************************
                'Routine to calculate the weight of stacked pallets minus the bottom one
                If PartNumber = "PALLET-36 X 36" Or PartNumber = "PALLET- 36 X 36 HT" Or PartNumber = "PALLETS" Or PartNumber = "PALLET- 40 X 40" Or PartNumber = "PALLET- 40 X 40 HT" Then
                    Select Case PartNumber
                        Case "PALLET-36 X 36"
                            LineWeightOpen = (QuantityOpen - 1) * 34
                            LineWeightOpen = Math.Round(LineWeightOpen, 2)
                            LineBoxesOpen = QuantityOpen
                        Case "PALLET- 36 X 36 HT"
                            LineWeightOpen = (QuantityOpen - 1) * 34
                            LineWeightOpen = Math.Round(LineWeightOpen, 2)
                            LineBoxesOpen = QuantityOpen
                        Case "PALLETS"
                            LineWeightOpen = (QuantityOpen - 1) * 34
                            LineWeightOpen = Math.Round(LineWeightOpen, 2)
                            LineBoxesOpen = QuantityOpen
                        Case "PALLET- 40 X 40"
                            LineWeightOpen = (QuantityOpen - 1) * 39
                            LineWeightOpen = Math.Round(LineWeightOpen, 2)
                            LineBoxesOpen = QuantityOpen
                        Case "PALLET- 40 X 40 HT"
                            LineWeightOpen = (QuantityOpen - 1) * 39
                            LineWeightOpen = Math.Round(LineWeightOpen, 2)
                            LineBoxesOpen = QuantityOpen
                    End Select
                End If
                '****************************************************************************************************
                'Don not write sales tax to lines if Canadian
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    SalesTaxOpen = 0
                End If
                '****************************************************************************************************
                'Add new line to Pick List Line Table
                'Get Next Line Number
                Dim PickLineNumberStatement As String = "SELECT MAX(PickListLineKey) FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
                Dim PickLineNumberCommand As New SqlCommand(PickLineNumberStatement, con)
                PickLineNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextPickNumber
                PickLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastPickLineNumber = CInt(PickLineNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastPickLineNumber = 0
                End Try
                con.Close()

                NextPickLineNumber = LastPickLineNumber + 1

                'Write Sales Order Data to Pick List Line Table
                cmd = New SqlCommand("Insert Into PickListLineTable(PickListHeaderKey, PickListLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, GLDebitAccount, GLCreditAccount, CertificationType, SOLineNumber, SerialNumber, QOH) Values (@PickListHeaderKey, @PickListLineKey, @ItemID, @Description, @Quantity, @Price, @SalesTax, @ExtendedAmount, @LineComment, @LineStatus, @DivisionID, @LineWeight, @LineBoxes, @GLDebitAccount, @GLCreditAccount, @CertificationType, @SOLineNumber, @SerialNumber, @QOH)", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextPickNumber
                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = NextPickLineNumber
                    .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = QuantityOpen
                    .Add("@Price", SqlDbType.VarChar).Value = Price
                    .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTaxOpen
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Price * QuantityOpen
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeightOpen
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxesOpen
                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = DebitGLAccount
                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = CreditGLAccount
                    .Add("@CertificationType", SqlDbType.VarChar).Value = CertType
                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLineKey
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                    .Add("@QOH", SqlDbType.VarChar).Value = PickQOH
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Write Pick List Line data to Shipment Line Table
                cmd = New SqlCommand("Insert Into ShipmentLineTable(ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, GLDebitAccount, GLCreditAccount, CertificationType, ExtendedCOS, SOLineNumber, SerialNumber, Dropship, BoxWeight) Values (@ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @GLDebitAccount, @GLCreditAccount, @CertificationType, @ExtendedCOS, @SOLineNumber, @SerialNumber, @Dropship, @BoxWeight)", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = NextPickLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@QuantityShipped", SqlDbType.VarChar).Value = QuantityOpen
                    .Add("@Price", SqlDbType.VarChar).Value = Price
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeightOpen
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxesOpen
                    .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTaxOpen
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = QuantityOpen * Price
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = DebitGLAccount
                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = CreditGLAccount
                    .Add("@CertificationType", SqlDbType.VarChar).Value = CertType
                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = 0
                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLineKey
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                    .Add("@Dropship", SqlDbType.VarChar).Value = "NO"
                    .Add("@BoxWeight", SqlDbType.VarChar).Value = BoxWeight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            'Get Totals from lines and update header (Shipment)
            'Extract Totals to write to Shipment Header Table
            Dim LineProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim LineProductTotalCommand As New SqlCommand(LineProductTotalStatement, con)
            LineProductTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
            LineProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim LineProductWeightStatement As String = "SELECT SUM(LineWeight) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim LineProductWeightCommand As New SqlCommand(LineProductWeightStatement, con)
            LineProductWeightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
            LineProductWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim LineSalesTaxStatement As String = "SELECT SUM(SalesTax) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim LineSalesTaxCommand As New SqlCommand(LineSalesTaxStatement, con)
            LineSalesTaxCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
            LineSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(LineProductTotalCommand.ExecuteScalar)
            Catch ex As System.Exception
                ProductTotal = 0
            End Try
            Try
                ProductWeight = CDbl(LineProductWeightCommand.ExecuteScalar)
            Catch ex As System.Exception
                ProductWeight = 0
            End Try
            Try
                SalesTax = CDbl(LineSalesTaxCommand.ExecuteScalar)
            Catch ex As System.Exception
                SalesTax = 0
            End Try
            con.Close()
            '****************************************************************************************************
            'Update Totals in Shipment Header Table
            cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal, TaxTotal = @TaxTotal, ShippingWeight = @ShippingWeight WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@TaxTotal", SqlDbType.VarChar).Value = SalesTax
                .Add("@ShippingWeight", SqlDbType.VarChar).Value = ProductWeight
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '****************************************************************************************************
            'Update Totals in Shipment Header Table
            cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '***************************************************************************************************
            'Update Pick Ticket if UPS or FEDEX (Declared Value)
            If (ShipVia.StartsWith("UPS-") Or ShipVia.StartsWith("FDX-")) And ProductTotal > 101 Then
                'Update pick ticket
                cmd = New SqlCommand("UPDATE PickListHeaderTable SET DeclaredValue = @DeclaredValue, DeclaredValueAdded = @DeclaredValueAdded WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextPickNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DeclaredValue", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@DeclaredValueAdded", SqlDbType.VarChar).Value = "Y"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If ProductWeight > 200 Then
                    Try
                        Dim strPickNumber As String = ""
                        strPickNumber = CStr(NextPickNumber)
                        Dim MyMailMessage As New MailMessage()
                        MyMailMessage.From = New MailAddress("t.lerew@tfpcorp.com")
                        MyMailMessage.To.Add("k.reusch@tfpcorp.com")
                        MyMailMessage.Subject = "Check Declared Value on UPS Backorder"
                        MyMailMessage.Body = "Check declared value on Pick# " + strPickNumber
                        Dim SMTP As New SmtpClient("Mail.tfpcorp.com")
                        SMTP.Port = "587"
                        SMTP.EnableSsl = False
                        SMTP.Credentials = New System.Net.NetworkCredential("t.lerew@tfpcorp.com", "1422325B@gie")
                        SMTP.Send(MyMailMessage)
                    Catch ex As Exception

                    End Try
                End If
            End If
            '****************************************************************************************************
            'Update sales order header table to shipped status
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SOStatus", SqlDbType.VarChar).Value = "SHIPPED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '****************************************************************************************************
            MsgBox("Back Order has been processed.", MsgBoxStyle.OkOnly)
            '****************************************************************************************************
            Dim button1 As DialogResult = MessageBox.Show("Do you wish to print all of the Pick Tickets?", "PRINT PICK TICKETS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If button1 = DialogResult.Yes Then
                GlobalDivisionCode = cboDivisionID.Text
                GlobalPickListNumber = NextPickNumber

                Using NewPrintPickTicketsAuto As New PrintPickTicketsAuto
                    Dim result = NewPrintPickTicketsAuto.ShowDialog()
                End Using
            ElseIf button1 = DialogResult.No Then
                'continue
            End If

            ShowDataByFilters()
            BGLoading.RunWorkerAsync()
            Me.dgvBackOrderLineQuery.Columns("DivisionKeyColumn").Visible = False
            '****************************************************************************************************
        Else
            MsgBox("This order cannot be processed at this time. It is either already pending or has not been committed by sales.", MsgBoxStyle.OkOnly)
        End If

        ShowDataByFilters()
        ClearVariables()
        'ClearData()
    End Sub

    Private Sub cmdProcessAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcessAll.Click
        lblLoading.Visible = False

        Dim SOStatus As String = ""
        Dim QuantityShipped As Double = 0
        Dim MaxShipmentNumber As Integer = 0
        Dim ShippingAccount As String = ""
        Dim SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3 As String

        'Create New Pick Ticket Header
        '****************************************************************************************************
        'Use new Batch Number for current selection
        Dim PLBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM PickListHeaderTable"
        Dim PLBatchNumberCommand As New SqlCommand(PLBatchNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPickBatchNumber = CInt(PLBatchNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastPickBatchNumber = 874000000
        End Try
        con.Close()

        NextPickBatchNumber = LastPickBatchNumber + 1
        '****************************************************************************************************
        Dim GLBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM ShipmentHeaderTable"
        Dim GLBatchNumberCommand As New SqlCommand(GLBatchNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastShipBatchNumber = CInt(GLBatchNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastShipBatchNumber = 880000000
        End Try
        con.Close()

        NextShipBatchNumber = LastShipBatchNumber + 1
        '****************************************************************************************************
        'Check to see if datagrid has rows
        If Me.dgvBackOrderLineQuery.RowCount <> 0 Then
            'Check to see if there is a pending Pick Ticket/Shipment for this line - if there is, skip and go to next
            For Each row As DataGridViewRow In dgvBackOrderLineQuery.Rows
                Try
                    SalesOrderKey = row.Cells("SalesOrderKeyColumn").Value
                Catch ex As System.Exception
                    SalesOrderKey = 0
                End Try
                Try
                    SOStatus = row.Cells("SOStatusColumn").Value
                Catch ex As System.Exception
                    SOStatus = ""
                End Try
                Try
                    QuantityShipped = row.Cells("QuantityShippedColumn").Value
                Catch ex As System.Exception
                    QuantityShipped = 0
                End Try
                Try
                    MaxShipmentNumber = row.Cells("MAXShipmentNumberColumn").Value
                Catch ex As System.Exception
                    MaxShipmentNumber = 0
                End Try

                If SOStatus = "OPEN" And MaxShipmentNumber > 0 Then
                    Dim CheckForPending As Integer = 0

                    'Check to see if existing pending shipment exists
                    Dim CheckForPendingStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus"
                    Dim CheckForPendingCommand As New SqlCommand(CheckForPendingStatement, con)
                    CheckForPendingCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                    CheckForPendingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    CheckForPendingCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckForPending = CInt(CheckForPendingCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        CheckForPending = 0
                    End Try
                    con.Close()

                    If CheckForPending = 0 Then
                        'Get SO Header data to create pick ticket and shipment headers
                        Dim ThirdPartyShipper, ShippingMethod, CustomerPO, PRONumber, ShipVia, ShippingDate, Salesperson, SpecialInstructions, HeaderComment As String

                        Try
                            CustomerID = row.Cells("CustomerIDColumn").Value
                        Catch ex As System.Exception
                            CustomerID = ""
                        End Try
                        Try
                            CustomerPO = row.Cells("CustomerPOColumn").Value
                        Catch ex As System.Exception
                            CustomerPO = ""
                        End Try
                        Try
                            ShipVia = row.Cells("ShipViaColumn").Value
                        Catch ex As System.Exception
                            ShipVia = "DELIVERY"
                        End Try
                        Try
                            ShippingDate = row.Cells("ShippingDateColumn").Value
                        Catch ex As System.Exception
                            ShippingDate = ""
                        End Try
                        Try
                            Salesperson = row.Cells("SalespersonColumn").Value
                        Catch ex As System.Exception
                            Salesperson = ""
                        End Try
                        Try
                            ShippingMethod = row.Cells("ShippingMethodColumn").Value
                        Catch ex As System.Exception
                            ShippingMethod = ""
                        End Try

                        'Get Sales Order Header Date
                        Dim GetSODataStatement As String = "SELECT * FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                        Dim GetSODataCommand As New SqlCommand(GetSODataStatement, con)
                        GetSODataCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                        GetSODataCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Dim reader As SqlDataReader = GetSODataCommand.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            If IsDBNull(reader.Item("SpecialInstructions")) Then
                                SpecialInstructions = ""
                            Else
                                SpecialInstructions = reader.Item("SpecialInstructions")
                            End If
                            If IsDBNull(reader.Item("HeaderComment")) Then
                                HeaderComment = ""
                            Else
                                HeaderComment = reader.Item("HeaderComment")
                            End If
                            If IsDBNull(reader.Item("ShipToName")) Then
                                ShipToName = ""
                            Else
                                ShipToName = reader.Item("ShipToName")
                            End If
                            If IsDBNull(reader.Item("ShipToAddress1")) Then
                                ShipToAddress1 = ""
                            Else
                                ShipToAddress1 = reader.Item("ShipToAddress1")
                            End If
                            If IsDBNull(reader.Item("ShipToAddress2")) Then
                                ShipToAddress2 = ""
                            Else
                                ShipToAddress2 = reader.Item("ShipToAddress2")
                            End If
                            If IsDBNull(reader.Item("ShipToCity")) Then
                                ShipToCity = ""
                            Else
                                ShipToCity = reader.Item("ShipToCity")
                            End If
                            If IsDBNull(reader.Item("ShipToState")) Then
                                ShipToState = ""
                            Else
                                ShipToState = reader.Item("ShipToState")
                            End If
                            If IsDBNull(reader.Item("ShipToZip")) Then
                                ShipToZip = ""
                            Else
                                ShipToZip = reader.Item("ShipToZip")
                            End If
                            If IsDBNull(reader.Item("ShipToCountry")) Then
                                ShipToCountry = ""
                            Else
                                ShipToCountry = reader.Item("ShipToCountry")
                            End If
                            If IsDBNull(reader.Item("ThirdPartyShipper")) Then
                                ThirdPartyShipper = ""
                            Else
                                ThirdPartyShipper = reader.Item("ThirdPartyShipper")
                            End If
                            If IsDBNull(reader.Item("PRONumber")) Then
                                PRONumber = ""
                            Else
                                PRONumber = reader.Item("PRONumber")
                            End If
                            If IsDBNull(reader.Item("AdditionalShipTo")) Then
                                AdditionalShipTo = ""
                            Else
                                AdditionalShipTo = reader.Item("AdditionalShipTo")
                            End If
                            If IsDBNull(reader.Item("CustomerClass")) Then
                                CustomerClass = ""
                            Else
                                CustomerClass = reader.Item("CustomerClass")
                            End If
                            If IsDBNull(reader.Item("ShipEmail")) Then
                                ShipEmail = ""
                            Else
                                ShipEmail = reader.Item("ShipEmail")
                            End If
                            If IsDBNull(reader.Item("ShippingAccount")) Then
                                ShippingAccount = ""
                            Else
                                ShippingAccount = reader.Item("ShippingAccount")
                            End If
                            If IsDBNull(reader.Item("SpecialLabelLine1")) Then
                                SpecialLabelLine1 = ""
                            Else
                                SpecialLabelLine1 = reader.Item("SpecialLabelLine1")
                            End If
                            If IsDBNull(reader.Item("SpecialLabelLine2")) Then
                                SpecialLabelLine2 = ""
                            Else
                                SpecialLabelLine2 = reader.Item("SpecialLabelLine2")
                            End If
                            If IsDBNull(reader.Item("SpecialLabelLine3")) Then
                                SpecialLabelLine3 = ""
                            Else
                                SpecialLabelLine3 = reader.Item("SpecialLabelLine3")
                            End If
                        Else
                            SpecialInstructions = ""
                            HeaderComment = ""
                            ShipToName = ""
                            ShipToAddress1 = ""
                            ShipToAddress2 = ""
                            ShipToCity = ""
                            ShipToCountry = ""
                            ShipToZip = ""
                            ShipToState = ""
                            ThirdPartyShipper = ""
                            PRONumber = ""
                            AdditionalShipTo = ""
                            CustomerClass = ""
                            ShipEmail = ""
                            ShippingAccount = ""
                            SpecialLabelLine1 = ""
                            SpecialLabelLine2 = ""
                            SpecialLabelLine3 = ""
                        End If
                        reader.Close()
                        con.Close()
                        '******************************************************************************************
                        'If Ship To Name is blank, get from customer, add ship to
                        If ShipToName = "" And AdditionalShipTo = "" Then
                            Dim GetShipToNameCustomer As String = ""

                            Dim GetShipToNameCustomerStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                            Dim GetShipToNameCustomerCommand As New SqlCommand(GetShipToNameCustomerStatement, con)
                            GetShipToNameCustomerCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                            GetShipToNameCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetShipToNameCustomer = CStr(GetShipToNameCustomerCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                GetShipToNameCustomer = ""
                            End Try
                            con.Close()

                            ShipToName = GetShipToNameCustomer
                        ElseIf ShipToName = "" And AdditionalShipTo <> "" Then
                            Dim GetAdditionalShipToName As String = ""

                            Dim GetAdditionalShipToNameStatement As String = "SELECT AdditionalShipTo FROM SalesOrderHeaderTable WHERE CustomerID = @CustomerID AND ShipToID = @ShipToID AND DivisionID = @DivisionID"
                            Dim GetAdditionalShipToNameCommand As New SqlCommand(GetAdditionalShipToNameStatement, con)
                            GetAdditionalShipToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                            GetAdditionalShipToNameCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = AdditionalShipTo
                            GetAdditionalShipToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetAdditionalShipToName = CStr(GetAdditionalShipToNameCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                GetAdditionalShipToName = ""
                            End Try
                            con.Close()

                            ShipToName = GetAdditionalShipToName
                        End If

                        'Create new Pick Ticket Number
                        Dim PickTicketNumberStatement As String = "SELECT MAX(PickListHeaderKey) FROM PickListHeaderTable"
                        Dim PickTicketNumberCommand As New SqlCommand(PickTicketNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastPickNumber = CInt(PickTicketNumberCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            LastPickNumber = 660000
                        End Try
                        con.Close()

                        NextPickNumber = LastPickNumber + 1
                        '****************************************************************************************************
                        'If TWD, get running count number
                        If cboDivisionID.Text = "TWD" Then
                            Dim RunningCountStatement As String = "SELECT MAX(RunningCount) FROM PickListHeaderTable"
                            Dim RunningCountCommand As New SqlCommand(RunningCountStatement, con)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastCountNumber = CInt(RunningCountCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                LastCountNumber = 0
                            End Try
                            con.Close()

                            RunningCount = LastCountNumber + 1
                        Else
                            RunningCount = 0
                        End If
                        '****************************************************************************************************
                        'Write Data to Pick Ticket Header Database Table
                        cmd = New SqlCommand("Insert Into PickListHeaderTable(PickListHeaderKey, SalesOrderHeaderKey, PickDate, DivisionID, Comment, PLStatus, CustomerID, CustomerPO, ShipVia, AdditionalShipTo, BatchNumber, PRONumber, SalesmanID, SpecialInstructions, ShipDate, PickCount, RunningCount, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3, DeclaredValue, DeclaredValueAdded) Values (@PickListHeaderKey, @SalesOrderHeaderKey, @PickDate, @DivisionID, @Comment, @PLStatus, @CustomerID, @CustomerPO, @ShipVia, @AdditionalShipTo, @BatchNumber, @PRONumber, @SalesmanID, @SpecialInstructions, @ShipDate, @PickCount, @RunningCount, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3, @DeclaredValue, @DeclaredValueAdded)", con)

                        With cmd.Parameters
                            .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextPickNumber
                            .Add("@SalesOrderHeaderKey", SqlDbType.VarChar).Value = SalesOrderKey
                            .Add("@PickDate", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = HeaderComment
                            .Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                            .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                            .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                            .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = AdditionalShipTo
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = NextPickBatchNumber
                            .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                            .Add("@SalesmanID", SqlDbType.VarChar).Value = Salesperson
                            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                            .Add("@ShipDate", SqlDbType.VarChar).Value = Today()
                            .Add("@PickCount", SqlDbType.VarChar).Value = 3
                            .Add("@RunningCount", SqlDbType.VarChar).Value = RunningCount
                            .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                            .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = ShipToAddress1
                            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = ShipToAddress2
                            .Add("@ShipToCity", SqlDbType.VarChar).Value = ShipToCity
                            .Add("@ShipToState", SqlDbType.VarChar).Value = ShipToState
                            .Add("@ShipToZip", SqlDbType.VarChar).Value = ShipToZip
                            .Add("@ShipToCountry", SqlDbType.VarChar).Value = ShipToCountry
                            .Add("@ShipEmail", SqlDbType.VarChar).Value = ShipEmail
                            .Add("@ShippingAccount", SqlDbType.VarChar).Value = ShippingAccount
                            .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = SpecialLabelLine1
                            .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = SpecialLabelLine2
                            .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = SpecialLabelLine3
                            .Add("@DeclaredValue", SqlDbType.VarChar).Value = 0
                            .Add("@DeclaredValueAdded", SqlDbType.VarChar).Value = ""
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '****************************************************************************************************
                        'Create new Shipment Number
                        Dim ShipmentNumberStatement As String = "SELECT MAX(ShipmentNumber) FROM ShipmentHeaderTable"
                        Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            LastShipmentNumber = 4560000
                        End Try
                        con.Close()

                        NextShipmentNumber = LastShipmentNumber + 1
                        '****************************************************************************************************
                        'Write Data to Shipment Header Table
                        cmd = New SqlCommand("Insert Into ShipmentHeaderTable(ShipmentNumber, SalesOrderKey, ShipDate, DivisionID, Comment, PickTicketNumber, ShipVia, PRONumber, FreightQuoteNumber, FreightQuoteAmount, FreightActualAmount, ShippingWeight, NumberOfPallets, CustomerID, ShipToID, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, CustomerPO, ShipmentStatus, ProductTotal, TaxTotal, ShipmentTotal, BatchNumber, SalesmanID, SpecialInstructions, Tax2Total, Tax3Total, CertsAutoGenerated, SOLog, PulledBy, CertsPulled, PackingSlip, Locked, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper, ShipToName, PostedBy, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3) Values (@ShipmentNumber, @SalesOrderKey, @ShipDate, @DivisionID, @Comment, @PickTicketNumber, @ShipVia, @PRONumber, @FreightQuoteNumber, @FreightQuoteAmount, @FreightActualAmount, @ShippingWeight, @NumberOfPallets, @CustomerID, @ShipToID, @ShipAddress1, @ShipAddress2, @ShipCity, @ShipState, @ShipZip, @ShipCountry, @CustomerPO, @ShipmentStatus, @ProductTotal, @TaxTotal, @ShipmentTotal, @BatchNumber, @SalesmanID, @SpecialInstructions, @Tax2Total, @Tax3Total, @CertsAutoGenerated, @SOLog, @PulledBy, @CertsPulled, @PackingSlip, @Locked, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @PostedBy, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3)", con)

                        With cmd.Parameters
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                            .Add("@ShipDate", SqlDbType.VarChar).Value = ShippingDate
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = HeaderComment
                            .Add("@PickTicketNumber", SqlDbType.VarChar).Value = NextPickNumber
                            .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                            .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                            .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = ""
                            .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = 0
                            .Add("@FreightActualAmount", SqlDbType.VarChar).Value = 0
                            .Add("@ShippingWeight", SqlDbType.VarChar).Value = 0
                            .Add("@NumberOfPallets", SqlDbType.VarChar).Value = 1
                            .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                            .Add("@ShipToID", SqlDbType.VarChar).Value = AdditionalShipTo
                            .Add("@ShipAddress1", SqlDbType.VarChar).Value = ShipToAddress1
                            .Add("@ShipAddress2", SqlDbType.VarChar).Value = ShipToAddress2
                            .Add("@ShipCity", SqlDbType.VarChar).Value = ShipToCity
                            .Add("@ShipState", SqlDbType.VarChar).Value = ShipToState
                            .Add("@ShipZip", SqlDbType.VarChar).Value = ShipToZip
                            .Add("@ShipCountry", SqlDbType.VarChar).Value = ShipToCountry
                            .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                            .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                            .Add("@TaxTotal", SqlDbType.VarChar).Value = 0
                            .Add("@ShipmentTotal", SqlDbType.VarChar).Value = 0
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = LastShipBatchNumber
                            .Add("@SalesmanID", SqlDbType.VarChar).Value = Salesperson
                            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                            .Add("@Tax2Total", SqlDbType.VarChar).Value = 0
                            .Add("@Tax3Total", SqlDbType.VarChar).Value = 0
                            .Add("@CertsAutoGenerated", SqlDbType.VarChar).Value = "NO"
                            .Add("@SOLog", SqlDbType.VarChar).Value = ""
                            .Add("@PulledBy", SqlDbType.VarChar).Value = ""
                            .Add("@CertsPulled", SqlDbType.VarChar).Value = ""
                            .Add("@PackingSlip", SqlDbType.VarChar).Value = ""
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                            .Add("@FOB", SqlDbType.VarChar).Value = "Medina"
                            .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                            .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                            .Add("@PostedBy", SqlDbType.VarChar).Value = ""
                            .Add("@ShipEmail", SqlDbType.VarChar).Value = ShipEmail
                            .Add("@ShippingAccount", SqlDbType.VarChar).Value = ShippingAccount
                            .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = SpecialLabelLine1
                            .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = SpecialLabelLine2
                            .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = SpecialLabelLine3
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Load SO Line data for current sales order
                        LoadSOLines()

                        'Define Line Variables
                        Dim SalesOrderLineKey As Integer = 0
                        Dim BoxCount As Double = 0
                        Dim LineBoxesOpen As Integer = 0
                        Dim Price, QuantityOpen, LineWeightOpen, SalesTaxOpen As Double
                        Dim PartNumber, PartDescription, LineComment, DebitGLAccount, CreditGLAccount, CertType As String

                        'Run routine to add lines to each table
                        For Each row2 As DataGridViewRow In dgvSOLines.Rows
                            Try
                                SalesOrderLineKey = row2.Cells("SOSalesOrderLineKeyColumn").Value
                            Catch ex As System.Exception
                                SalesOrderLineKey = 0
                            End Try
                            Try
                                Price = row2.Cells("SOPriceColumn").Value
                            Catch ex As System.Exception
                                Price = 0
                            End Try
                            Try
                                QuantityOpen = row2.Cells("SOQuantityOpenColumn").Value
                            Catch ex As System.Exception
                                QuantityOpen = 0
                            End Try
                            Try
                                SalesTaxOpen = row2.Cells("SOSalesTaxOpenColumn").Value
                            Catch ex As System.Exception
                                SalesTaxOpen = 0
                            End Try
                            Try
                                PartNumber = row2.Cells("SOItemIDColumn").Value
                            Catch ex As System.Exception
                                PartNumber = ""
                            End Try
                            Try
                                PartDescription = row2.Cells("SODescriptionColumn").Value
                            Catch ex As System.Exception
                                PartDescription = ""
                            End Try
                            Try
                                LineComment = row2.Cells("SOLineCommentColumn").Value
                            Catch ex As System.Exception
                                LineComment = ""
                            End Try
                            Try
                                DebitGLAccount = row2.Cells("SODebitGLAccountColumn").Value
                            Catch ex As System.Exception
                                DebitGLAccount = "49999"
                            End Try
                            Try
                                CreditGLAccount = row2.Cells("SOCreditGLAccountColumn").Value
                            Catch ex As System.Exception
                                CreditGLAccount = "12100"
                            End Try
                            Try
                                CertType = row2.Cells("SOCertificationTypeColumn").Value
                            Catch ex As System.Exception
                                CertType = "0"
                            End Try
                            '****************************************************************************************************
                            Dim PieceWeight As Double = 0

                            Dim BoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim BoxCountCommand As New SqlCommand(BoxCountStatement, con)
                            BoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            BoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            Dim PieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim PieceWeightCommand As New SqlCommand(PieceWeightStatement, con)
                            PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            Dim BoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim BoxWeightCommand As New SqlCommand(BoxWeightStatement, con)
                            BoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            BoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            Dim GetQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim GetQOHCommand As New SqlCommand(GetQOHStatement, con)
                            GetQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                BoxCount = CDbl(BoxCountCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                BoxCount = 0
                            End Try
                            Try
                                PieceWeight = CDbl(PieceWeightCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                PieceWeight = 0
                            End Try
                            Try
                                BoxWeight = CDbl(BoxWeightCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                BoxWeight = 0
                            End Try
                            Try
                                PickQOH = CDbl(GetQOHCommand.ExecuteScalar)
                            Catch ex As Exception
                                PickQOH = 0
                            End Try
                            con.Close()

                            LineWeightOpen = PieceWeight * QuantityOpen
                            LineWeightOpen = Math.Round(LineWeightOpen, 1)
                            '****************************************************************************************************
                            'Determine Open Box Count
                            'Avoid Divide-By-Zero Error
                            If BoxCount = 0 Then
                                LineBoxesOpen = 0
                            Else
                                'LineBoxesOpen = SLQuantity / BoxCount

                                'Verify full boxes
                                If QuantityOpen Mod BoxCount = 0 Then
                                    LineBoxesOpen = QuantityOpen / BoxCount
                                Else
                                    LineBoxesOpen = QuantityOpen / BoxCount
                                    LineBoxesOpen = Math.Round(LineBoxesOpen, 1)
                                End If
                            End If
                            '****************************************************************************************************
                            'Routine to calculate the weight of stacked pallets minus the bottom one
                            If PartNumber = "PALLET-36 X 36" Or PartNumber = "PALLET- 36 X 36 HT" Or PartNumber = "PALLETS" Or PartNumber = "PALLET- 40 X 40" Or PartNumber = "PALLET- 40 X 40 HT" Then
                                Select Case PartNumber
                                    Case "PALLET-36 X 36"
                                        LineWeightOpen = (QuantityOpen - 1) * 34
                                        LineWeightOpen = Math.Round(LineWeightOpen, 2)
                                        LineBoxesOpen = QuantityOpen
                                    Case "PALLET- 36 X 36 HT"
                                        LineWeightOpen = (QuantityOpen - 1) * 34
                                        LineWeightOpen = Math.Round(LineWeightOpen, 2)
                                        LineBoxesOpen = QuantityOpen
                                    Case "PALLETS"
                                        LineWeightOpen = (QuantityOpen - 1) * 34
                                        LineWeightOpen = Math.Round(LineWeightOpen, 2)
                                        LineBoxesOpen = QuantityOpen
                                    Case "PALLET- 40 X 40"
                                        LineWeightOpen = (QuantityOpen - 1) * 39
                                        LineWeightOpen = Math.Round(LineWeightOpen, 2)
                                        LineBoxesOpen = QuantityOpen
                                    Case "PALLET- 40 X 40 HT"
                                        LineWeightOpen = (QuantityOpen - 1) * 39
                                        LineWeightOpen = Math.Round(LineWeightOpen, 2)
                                        LineBoxesOpen = QuantityOpen
                                End Select
                            End If
                            '****************************************************************************************************
                            'Don not write sales tax to lines if Canadian
                            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                                SalesTaxOpen = 0
                            End If
                            '****************************************************************************************************
                            'Add new line to Pick List Line Table
                            'Get Next Line Number
                            Dim PickLineNumberStatement As String = "SELECT MAX(PickListLineKey) FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
                            Dim PickLineNumberCommand As New SqlCommand(PickLineNumberStatement, con)
                            PickLineNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextPickNumber
                            PickLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastPickLineNumber = CInt(PickLineNumberCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                LastPickLineNumber = 0
                            End Try
                            con.Close()

                            NextPickLineNumber = LastPickLineNumber + 1

                            'Write Sales Order Data to Pick List Line Table
                            cmd = New SqlCommand("Insert Into PickListLineTable(PickListHeaderKey, PickListLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, GLDebitAccount, GLCreditAccount, CertificationType, SOLineNumber, SerialNumber, QOH) Values (@PickListHeaderKey, @PickListLineKey, @ItemID, @Description, @Quantity, @Price, @SalesTax, @ExtendedAmount, @LineComment, @LineStatus, @DivisionID, @LineWeight, @LineBoxes, @GLDebitAccount, @GLCreditAccount, @CertificationType, @SOLineNumber, @SerialNumber, @QOH)", con)

                            With cmd.Parameters
                                .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextPickNumber
                                .Add("@PickListLineKey", SqlDbType.VarChar).Value = NextPickLineNumber
                                .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                                .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                                .Add("@Quantity", SqlDbType.VarChar).Value = QuantityOpen
                                .Add("@Price", SqlDbType.VarChar).Value = Price
                                .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTaxOpen
                                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Price * QuantityOpen
                                .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeightOpen
                                .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxesOpen
                                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = DebitGLAccount
                                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = CreditGLAccount
                                .Add("@CertificationType", SqlDbType.VarChar).Value = CertType
                                .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLineKey
                                .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                .Add("@QOH", SqlDbType.VarChar).Value = PickQOH
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Write Pick List Line data to Shipment Line Table
                            cmd = New SqlCommand("Insert Into ShipmentLineTable(ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, GLDebitAccount, GLCreditAccount, CertificationType, ExtendedCOS, SOLineNumber, SerialNumber, Dropship, BoxWeight) Values (@ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @GLDebitAccount, @GLCreditAccount, @CertificationType, @ExtendedCOS, @SOLineNumber, @SerialNumber, @Dropship, @BoxWeight)", con)

                            With cmd.Parameters
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = NextPickLineNumber
                                .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                                .Add("@QuantityShipped", SqlDbType.VarChar).Value = QuantityOpen
                                .Add("@Price", SqlDbType.VarChar).Value = Price
                                .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                                .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeightOpen
                                .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxesOpen
                                .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTaxOpen
                                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = QuantityOpen * Price
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = DebitGLAccount
                                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = CreditGLAccount
                                .Add("@CertificationType", SqlDbType.VarChar).Value = CertType
                                .Add("@ExtendedCOS", SqlDbType.VarChar).Value = 0
                                .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLineKey
                                .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                .Add("@Dropship", SqlDbType.VarChar).Value = "NO"
                                .Add("@BoxWeight", SqlDbType.VarChar).Value = BoxWeight
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Next

                        'Get Totals from lines and update header (Shipment)
                        'Extract Totals to write to Shipment Header Table
                        Dim LineProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                        Dim LineProductTotalCommand As New SqlCommand(LineProductTotalStatement, con)
                        LineProductTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                        LineProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim LineProductWeightStatement As String = "SELECT SUM(LineWeight) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                        Dim LineProductWeightCommand As New SqlCommand(LineProductWeightStatement, con)
                        LineProductWeightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                        LineProductWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim LineSalesTaxStatement As String = "SELECT SUM(SalesTax) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                        Dim LineSalesTaxCommand As New SqlCommand(LineSalesTaxStatement, con)
                        LineSalesTaxCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                        LineSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(LineProductTotalCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            ProductTotal = 0
                        End Try
                        Try
                            ProductWeight = CDbl(LineProductWeightCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            ProductWeight = 0
                        End Try
                        Try
                            SalesTax = CDbl(LineSalesTaxCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            SalesTax = 0
                        End Try
                        con.Close()
                        '****************************************************************************************************
                        'Update Totals in Shipment Header Table
                        cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal, TaxTotal = @TaxTotal, ShippingWeight = @ShippingWeight WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                            .Add("@TaxTotal", SqlDbType.VarChar).Value = SalesTax
                            .Add("@ShippingWeight", SqlDbType.VarChar).Value = ProductWeight
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '****************************************************************************************************
                        'Update Totals in Shipment Header Table
                        cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '***************************************************************************************************
                        'Update Pick Ticket if UPS or FEDEX (Declared Value)
                        If (ShipVia.StartsWith("UPS-") Or ShipVia.StartsWith("FDX-")) And ProductTotal > 101 Then
                            'Update pick ticket
                            cmd = New SqlCommand("UPDATE PickListHeaderTable SET DeclaredValue = @DeclaredValue, DeclaredValueAdded = @DeclaredValueAdded WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = NextPickNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@DeclaredValue", SqlDbType.VarChar).Value = ProductTotal
                                .Add("@DeclaredValueAdded", SqlDbType.VarChar).Value = "Y"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            If ProductWeight > 200 Then
                                Try
                                    Dim strPickNumber As String = ""
                                    strPickNumber = CStr(NextPickNumber)
                                    Dim MyMailMessage As New MailMessage()
                                    MyMailMessage.From = New MailAddress("t.lerew@tfpcorp.com")
                                    MyMailMessage.To.Add("k.reusch@tfpcorp.com")
                                    MyMailMessage.Subject = "Check Declared Value on UPS Backorder"
                                    MyMailMessage.Body = "Check declared value on Pick# " + strPickNumber
                                    Dim SMTP As New SmtpClient("Mail.tfpcorp.com")
                                    SMTP.Port = "587"
                                    SMTP.EnableSsl = False
                                    SMTP.Credentials = New System.Net.NetworkCredential("t.lerew@tfpcorp.com", "1422325B@gie")
                                    SMTP.Send(MyMailMessage)
                                Catch ex As Exception

                                End Try
                            End If
                        End If
                        '****************************************************************************************************
                        'Update sales order header table to shipped status
                        cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                        With cmd.Parameters
                            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                            .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@SOStatus", SqlDbType.VarChar).Value = "SHIPPED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Skip
                    End If

                    ShowDataByFilters()
                    ClearVariables()
                    'ClearData()
                Else
                    'Skip line
                End If
            Next

            '****************************************************************************************************
            MsgBox("Back Orders have been processed.", MsgBoxStyle.OkOnly)
            '****************************************************************************************************
            Dim button1 As DialogResult = MessageBox.Show("Do you wish to print all of the Pick Tickets?", "PRINT PICK TICKETS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If button1 = DialogResult.Yes Then
                GlobalDivisionCode = cboDivisionID.Text
                GlobalPickBatchNumber = NextPickBatchNumber
                GlobalPrintPickTickets = "AUTOPRINT"

                'Chose the correct Print Form (REMOTE or LOCAL)

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
                    Using NewPrintPickTicketBatch As New PrintPickTicketBatchRemote
                        Dim result = NewPrintPickTicketBatch.ShowDialog()
                    End Using
                Else
                    Using NewPrintPickTicketBatch As New PrintPickTicketBatch
                        Dim result = NewPrintPickTicketBatch.ShowDialog()
                    End Using
                End If
            ElseIf button1 = DialogResult.No Then
                'continue
            End If

            ShowDataByFilters()
            BGLoading.RunWorkerAsync()
            Me.dgvBackOrderLineQuery.Columns("DivisionKeyColumn").Visible = False
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub BGLoading_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGLoading.DoWork
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "BackOrderTest")
        con.Close()
    End Sub

    Private Sub BGLoading_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGLoading.RunWorkerCompleted
        dgvBackOrderLineQuery.DataSource = ds.Tables("BackOrderTest")
        LoadShippingFormatting()
        lblLoading.Visible = False
    End Sub

    Private Sub cmdItemList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemList.Click
        If dgvBackOrderLineQuery.CurrentCell IsNot Nothing Then
            GlobalItemListingPartNumber = dgvBackOrderLineQuery.Rows(dgvBackOrderLineQuery.CurrentCell.RowIndex).Cells("ItemIDColumn").Value
        ElseIf dgvBackOrderLineQuery.CurrentRow IsNot Nothing Then
            GlobalItemListingPartNumber = dgvBackOrderLineQuery.CurrentRow.Cells("ItemIDColumn").Value
        End If
        Dim newItemMaintenance As New ItemMaintenance
        newItemMaintenance.Parent = Me.Parent
        newItemMaintenance.Show()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdViewWIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewWIP.Click
        If dgvBackOrderLineQuery.SelectedCells.Count > 0 Or dgvBackOrderLineQuery.SelectedRows.Count > 0 Then
            If dgvBackOrderLineQuery.SelectedRows.Count > 0 Then
                Dim lst As New List(Of String)
                For i As Integer = dgvBackOrderLineQuery.SelectedRows.Count - 1 To 0 Step -1
                    lst.Add(dgvBackOrderLineQuery.SelectedRows(i).Cells("ItemIDColumn").Value)
                Next
                Dim newViewWIPPopup As New ViewWIPPopup(lst)
                newViewWIPPopup.ShowDialog()
            Else
                Dim test As String = dgvBackOrderLineQuery.Rows(dgvBackOrderLineQuery.SelectedCells(0).RowIndex).Cells("ItemIDColumn").Value
                Dim newViewWIPPopup As New ViewWIPPopup(dgvBackOrderLineQuery.Rows(dgvBackOrderLineQuery.SelectedCells(0).RowIndex).Cells("ItemIDColumn").Value)
                newViewWIPPopup.ShowDialog()
            End If

            Me.BringToFront()
        End If
    End Sub

    Private Sub dgvBackOrderLineQuery_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBackOrderLineQuery.CellDoubleClick
        If chkPrintPackingList.Checked = True Then
            PrintPackingSlips()
        ElseIf chkPrintPickTicket.Checked = True Then
            PrintPicks()
        Else
            PrintSalesOrders()
        End If
    End Sub

    Private Sub dgvBackOrderLineQuery_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBackOrderLineQuery.CellValueChanged
        Dim SalesOrderKey, SalesOrderLinekey As Integer
        Dim LeadTime, LineStatus, SOStatus, RowDivision, Description, LineComment, ShipVia, ShippingDate, Salesperson, CustomerPO As String
        Dim QuantityShipped As Double = 0

        If Me.dgvBackOrderLineQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvBackOrderLineQuery.CurrentCell.RowIndex

            SalesOrderKey = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value
            SalesOrderLinekey = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SalesOrderLinekeyColumn").Value
            RowDivision = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("DivisionKeyColumn").Value
            Description = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("DescriptionColumn").Value
            LineComment = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("LineCommentColumn").Value
            ShipVia = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("ShipViaColumn").Value
            ShippingDate = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("ShippingDateColumn").Value
            Salesperson = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SalespersonColumn").Value
            CustomerPO = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("CustomerPOColumn").Value
            QuantityShipped = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("QuantityShippedColumn").Value
            LineStatus = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("LineStatusColumn").Value
            SOStatus = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("SOStatusColumn").Value
            LeadTime = Me.dgvBackOrderLineQuery.Rows(RowIndex).Cells("LeadTimeColumn").Value

            Try
                'UPDATE SO Header Table
                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET CustomerPO = @CustomerPO, Salesperson = @Salesperson, ShipVia = @ShipVia, ShippingDate = @ShippingDate WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = RowDivision
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                    .Add("@Salesperson", SqlDbType.VarChar).Value = Salesperson
                    .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                    .Add("@ShippingDate", SqlDbType.VarChar).Value = ShippingDate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try

            Try
                'UPDATE SO Line Table
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET Description = @Description, LineComment = @LineComment, LeadTime = @LeadTime WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = SalesOrderLinekey
                    .Add("@Description", SqlDbType.VarChar).Value = Description
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    .Add("@LeadTime", SqlDbType.VarChar).Value = LineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try

            'Update Pick Ticket if it is a pending shipment
            If SOStatus = "SHIPPED" Then
                'Get Pick Ticket Number
                Dim GetPickNumber As Integer = 0

                Dim GetPickNumberString As String = "SELECT PickListHeaderKey FROM PickListHeaderTable WHERE SalesOrderHeaderKey = @SalesOrderHeaderKey AND DivisionID = @DivisionID AND PLStatus = @PLStatus"
                Dim GetPickNumberCommand As New SqlCommand(GetPickNumberString, con)
                GetPickNumberCommand.Parameters.Add("@SalesOrderHeaderKey", SqlDbType.VarChar).Value = SalesOrderKey
                GetPickNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                GetPickNumberCommand.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPickNumber = CInt(GetPickNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetPickNumber = 0
                End Try
                con.Close()

                Try
                    'UPDATE SO Header Table
                    cmd = New SqlCommand("UPDATE PickListHeaderTable SET CustomerPO = @CustomerPO, SalesmanID = @SalesmanID, ShipVia = @ShipVia, ShipDate = @ShipDate WHERE PickListHeaderKey = @PickListHeaderKey AND SalesOrderHeaderKey = @SalesOrderHeaderKey AND DivisionID = @DivisionID AND PLStatus = @PLStatus", con)

                    With cmd.Parameters
                        .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GetPickNumber
                        .Add("@SalesOrderHeaderKey", SqlDbType.VarChar).Value = SalesOrderKey
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                        .Add("@SalesmanID", SqlDbType.VarChar).Value = Salesperson
                        .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                        .Add("@ShipDate", SqlDbType.VarChar).Value = ShippingDate
                        .Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Do nothing
                End Try

                Try
                    'UPDATE Pick List Line Table
                    cmd = New SqlCommand("UPDATE PickListLineTable SET Description = @Description, LineComment = @LineComment WHERE PickListHeaderKey = @PickListHeaderKey AND SOLineNumber = @SOLineNumber AND LineStatus = @LineStatus", con)

                    With cmd.Parameters
                        .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GetPickNumber
                        .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLinekey
                        .Add("@Description", SqlDbType.VarChar).Value = Description
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Do nothing
                End Try

                'Get Shipment Number
                Dim GetShipNumber As Integer = 0

                Dim GetShipNumberString As String = "SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND PickTicketNumber = @PickTicketNumber"
                Dim GetShipNumberCommand As New SqlCommand(GetShipNumberString, con)
                GetShipNumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                GetShipNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                GetShipNumberCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = GetPickNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipNumber = CInt(GetShipNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetShipNumber = 0
                End Try
                con.Close()

                Try
                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET CustomerPO = @CustomerPO, SalesmanID = @SalesmanID, ShipVia = @ShipVia, ShipDate = @ShipDate WHERE PickTicketNumber = @PickTicketNumber AND SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND ShipmentNumber = @ShipmentNumber", con)

                    With cmd.Parameters
                        .Add("@PickTicketNumber", SqlDbType.VarChar).Value = GetPickNumber
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderKey
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                        .Add("@SalesmanID", SqlDbType.VarChar).Value = Salesperson
                        .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                        .Add("@ShipDate", SqlDbType.VarChar).Value = ShippingDate
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Do nothing
                End Try

                Try
                    'UPDATE Shipment Line Table
                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET PartDescription = @PartDescription, LineComment = @LineComment WHERE ShipmentNumber = @ShipmentNumber AND SOLineNumber = @SOLineNumber AND LineStatus = @LineStatus", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipNumber
                        .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLinekey
                        .Add("@PartDescription", SqlDbType.VarChar).Value = Description
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Do nothing
                End Try
            Else
                'Skip
            End If

            'ShowDataByFilters()
        Else
            'Skip
        End If
    End Sub

    Private Sub dgvBackOrderLineQuery_ColumnHeaderMouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBackOrderLineQuery.ColumnHeaderMouseClick
        LoadShippingFormatting()
    End Sub
End Class