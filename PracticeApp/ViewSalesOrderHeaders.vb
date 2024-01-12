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
Public Class ViewSalesOrderHeaders
    Inherits System.Windows.Forms.Form

    Dim SalesOrderFilter, ShipToFilter, TextFilter, CustomerFilter, POFilter, DateFilter, StatusFilter, SalespersonFilter As String
    Dim BeginDate, EndDate As Date
    Dim FreightTotal, SalesTotal, ProductTotal As Double
    Dim OrderNumber, SalesOrderKey As Integer
    Dim strBeginDate, strEndDate, strSalesOrderKey As String
    Dim SONumberFilter As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable
    Dim isLoaded As Boolean = False

    Private Sub ViewSalesOrderHeaders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()
        LastThreeYearsToolStripMenuItem.Checked = True
        AllSalesOrdersToolStripMenuItem.Checked = False

        If EmployeeCompanyCode.Equals("SLC") Or EmployeeCompanyCode.Equals("TST") Then
            chkIncludeSLCLines.Visible = True
        End If

        isLoaded = True
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

    Private Sub dgvSalesOrders_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvSalesOrders.CellDoubleClick
        Dim RowSONumber As Integer = 0
        Dim RowStatus As String = ""
        Dim RowCustomer As String = ""

        Dim RowIndex As Integer = Me.dgvSalesOrders.CurrentCell.RowIndex

        RowSONumber = Me.dgvSalesOrders.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value
        RowStatus = Me.dgvSalesOrders.Rows(RowIndex).Cells("SOStatusColumn").Value
        RowCustomer = Me.dgvSalesOrders.Rows(RowIndex).Cells("CustomerIDColumn").Value

        If RowStatus = "QUOTE" Then
            'Choose correct print form for Quotes
            If cboDivisionID.Text = "TFP" Then
                GlobalSONumber = RowSONumber
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintTFQuote As New PrintTFQuote
                    Dim result = NewPrintTFQuote.ShowDialog()
                End Using
            Else
                GlobalSONumber = RowSONumber
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
                    Using NewPrintQuoteRemote As New PrintQuoteRemote
                        Dim result = NewPrintQuoteRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintQuote As New PrintQuote
                        Dim result = NewPrintQuote.ShowDialog()
                    End Using
                End If
            End If
        Else
            'Get Email address for confirmationsr
            Dim GetConfirmationEmail As String = ""

            Dim GetConfirmationEmailString As String = "SELECT ConfirmationEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim GetConfirmationEmailCommand As New SqlCommand(GetConfirmationEmailString, con)
            GetConfirmationEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
            GetConfirmationEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetConfirmationEmail = CStr(GetConfirmationEmailCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetConfirmationEmail = ""
            End Try
            con.Close()

            EmailCustomerConfirmations = GetConfirmationEmail

            'Choose correct print form for Sales Orders
            If cboDivisionID.Text = "TFP" Then
                'Get FOX Number
                Dim GetFOXNumber As Integer = 0

                Dim GetFOXNumberString As String = "SELECT FOXNumber FROM FOXTable WHERE OrderReferenceNumber = @OrderReferenceNumber AND DivisionID = @DivisionID"
                Dim GetFOXNumberCommand As New SqlCommand(GetFOXNumberString, con)
                GetFOXNumberCommand.Parameters.Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = RowSONumber
                GetFOXNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetFOXNumber = CInt(GetFOXNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetFOXNumber = 0
                End Try
                con.Close()

                GlobalSONumber = RowSONumber
                GlobalDivisionCode = cboDivisionID.Text
                GlobalTFPSOPrintForm = "TFP Acknowledgement"
                GlobalFOXNumber = GetFOXNumber

                Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
                    Dim result = NewPrintTFAcknowledgement.ShowDialog()
                End Using
            Else
                GlobalSONumber = RowSONumber
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
                    Using NewPrintSalesOrderRemote As New PrintSalesOrderRemote
                        Dim result = NewPrintSalesOrderRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintSalesOrder As New PrintSalesOrder
                        Dim result = NewPrintSalesOrder.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Public Sub ShowDataByFilter()
        If chkIncludeSLCLines.Checked = True Then
            dgvSalesOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            dgvSalesOrders.Columns("SalesOrderKeyColumn").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvSalesOrders.Columns("SalespersonColumn").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvSalesOrders.Columns("ShipViaColumn").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvSalesOrders.Columns("ShippingDateColumn").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            cmd = New SqlCommand("SELECT SalesOrderKey, SalesOrderDate, CustomerID, SalesOrderHeaderTable.CustomerPO, SalesPerson, ShipVia, ShippingDate, ShipmentNumber, CertsAutoGenerated, SOLog, PulledBy, CertsPulled, PackingSlip, ShipmentHeaderTable.ShippingMethod FROM SalesOrderHeaderTable INNER JOIN (SELECT ShipmentNumber, SalesOrderKey as SOKey, case when isnull(CertsAutoGenerated, 'NO') = '' then 'NO' else isnull(CertsAutoGenerated, 'NO') END as CertsAutoGenerated, isnull(SOLog, '') as SOLog, PulledBy, isnull(CertsPulled, '') as CertsPulled, isnull(PackingSlip, '') as PackingSlip, isnull(ShippingMethod, '') as ShippingMethod FROM ShipmentHeaderTable WHERE ShipmentStatus <> 'INVOICED' or ShipmentStatus <> 'SHIPPED') AS ShipmentHeaderTable ON SalesOrderHeaderTable.SalesOrderKey = ShipmentHeaderTable.SOKey WHERE DivisionKey = @DivisionKey", con)

            If Not dgvSalesOrders.Columns.Contains("CertsAutoGenerated") Then
                dgvSalesOrders.Columns.Add("ShipmentNumber", "Shipment #")
                dgvSalesOrders.Columns("ShipmentNumber").Width = 60

                Dim addCol As New DataGridViewCheckBoxColumn()
                With addCol
                    .TrueValue = "YES"
                    .FalseValue = "NO"
                    .IndeterminateValue = "NO"
                    .Name = "CertsAutoGenerated"
                    .HeaderText = "Certs (auto gen. By salesman)"
                End With

                dgvSalesOrders.Columns.Add(addCol)

                dgvSalesOrders.Columns.Add("SOLog", "S.O. Log")
                dgvSalesOrders.Columns("SOLog").Width = 40

                dgvSalesOrders.Columns.Add("PulledBy", "Pulled By / Packaging")
                dgvSalesOrders.Columns("PulledBy").Width = 120

                dgvSalesOrders.Columns.Add("CertsPulled", "Certs Pulled")
                dgvSalesOrders.Columns("CertsPulled").Width = 40

                dgvSalesOrders.Columns.Add("PackingSlip", "Packing Slip")
                dgvSalesOrders.Columns("PackingSlip").Width = 50

                dgvSalesOrders.Columns.Add("ShippingMethod", "ShippingMethod")
                dgvSalesOrders.Columns("ShippingMethod").Width = 120

                dgvSalesOrders.Columns("FreightChargeColumn").Visible = False
                dgvSalesOrders.Columns("ProductTotalColumn").Visible = False
                dgvSalesOrders.Columns("SOTotalColumn").Visible = False
                dgvSalesOrders.Columns("SOStatusColumn").Visible = False
                dgvSalesOrders.Columns("PRONumberColumn").Visible = False
                dgvSalesOrders.Columns("AdditionalShipToColumn").Visible = False
                dgvSalesOrders.Columns("QuoteNumberColumn").Visible = False
                dgvSalesOrders.Columns("QuotedFreightColumn").Visible = False
                dgvSalesOrders.Columns("ShippingWeightColumn").Visible = False
                dgvSalesOrders.Columns("HeaderCommentColumn").Visible = False
            End If
        Else
            cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey", con)

            If dgvSalesOrders.Columns.Contains("CertsAutoGenerated") Then
                dgvSalesOrders.Columns.Remove("ShipmentNumber")
                dgvSalesOrders.Columns.Remove("CertsAutoGenerated")
                dgvSalesOrders.Columns.Remove("SOLog")
                dgvSalesOrders.Columns.Remove("PulledBy")
                dgvSalesOrders.Columns.Remove("CertsPulled")
                dgvSalesOrders.Columns.Remove("PackingSlip")
                dgvSalesOrders.Columns.Remove("ShippingMethod")

                dgvSalesOrders.Columns("FreightChargeColumn").Visible = True
                dgvSalesOrders.Columns("ProductTotalColumn").Visible = True
                dgvSalesOrders.Columns("SOTotalColumn").Visible = True
                dgvSalesOrders.Columns("SOStatusColumn").Visible = True
                dgvSalesOrders.Columns("PRONumberColumn").Visible = True
                dgvSalesOrders.Columns("AdditionalShipToColumn").Visible = True
                dgvSalesOrders.Columns("QuoteNumberColumn").Visible = True
                dgvSalesOrders.Columns("QuotedFreightColumn").Visible = True
                dgvSalesOrders.Columns("ShippingWeightColumn").Visible = True
                dgvSalesOrders.Columns("HeaderCommentColumn").Visible = True
            End If
        End If

        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            cmd.CommandText += " AND CustomerID = @CustomerID"
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        End If
        If Not String.IsNullOrEmpty(cboSalesperson.Text) Then
            cmd.CommandText += " AND Salesperson = @SalesPerson"
            cmd.Parameters.Add("@SalesPerson", SqlDbType.VarChar).Value = cboSalesperson.Text
        End If
        If Not String.IsNullOrEmpty(cboSalesOrderKey.Text) Then
            cmd.CommandText += " AND SalesOrderKey = @SalesOrderKey"
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = cboSalesOrderKey.Text
        End If
        If Not String.IsNullOrEmpty(txtCustomerPO.Text) Then
            cmd.CommandText += " AND CustomerPO LIKE @CustomerPO"
            cmd.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = "%" + txtCustomerPO.Text + "%"
        End If
        If Not String.IsNullOrEmpty(cboSOStatus.Text) Then
            cmd.CommandText += " AND SOStatus = @SOStatus"
            cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = cboSOStatus.Text
        End If
        If Not String.IsNullOrEmpty(cboShipID.Text) Then
            cmd.CommandText += " AND AdditionalShipTo = @AdditionalShipTo"
            cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipID.Text
        End If
        If Not String.IsNullOrEmpty(txtTextFilter.Text) Then
            cmd.CommandText += " AND (CustomerID LIKE @CustomerIDLike OR ShipToName LIKE @CustomerNameLike)"
            cmd.Parameters.Add("@CustomerIDLike", SqlDbType.VarChar).Value = "%" + txtTextFilter.Text + "%"
            cmd.Parameters.Add("@CustomerNameLike", SqlDbType.VarChar).Value = "%" + txtTextFilter.Text + "%"
        End If
        If chkDateRange.Checked Then
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                BeginDate = dtpBeginDate.Value
                EndDate = dtpEndDate.Value
            Else
                BeginDate = dtpBeginDate.Value
                EndDate = dtpEndDate.Value
            End If

            strBeginDate = CStr(BeginDate)
            strEndDate = CStr(EndDate)

            cmd.CommandText += " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = strBeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = strEndDate
        End If
        If cboSOStatus.Text <> "QUOTE" Then
            cmd.CommandText += " AND SOStatus <> 'QUOTE'"
        End If
        isLoaded = False
        cmd.CommandText += " ORDER BY SalesOrderKey ASC"
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SalesOrderHeaderTable")
        dgvSalesOrders.DataSource = ds.Tables("SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds.Tables("SalesOrderHeaderTable")
        con.Close()

        If dgvSalesOrders.Columns.Contains("CertsAutoGenerated") Then
            isLoaded = False
            For i As Integer = 0 To ds.Tables("SalesOrderHeaderTable").Rows.Count - 1
                dgvSalesOrders.Rows(i).Cells("ShipmentNumber").Value = ds.Tables("SalesOrderHeaderTable").Rows(i).Item("ShipmentNumber").ToString()
                dgvSalesOrders.Rows(i).Cells("CertsAutoGenerated").Value = ds.Tables("SalesOrderHeaderTable").Rows(i).Item("CertsAutoGenerated").ToString()
                dgvSalesOrders.Rows(i).Cells("SOLog").Value = ds.Tables("SalesOrderHeaderTable").Rows(i).Item("SOLog").ToString()
                dgvSalesOrders.Rows(i).Cells("PulledBy").Value = ds.Tables("SalesOrderHeaderTable").Rows(i).Item("PulledBy").ToString()
                dgvSalesOrders.Rows(i).Cells("PackingSlip").Value = ds.Tables("SalesOrderHeaderTable").Rows(i).Item("PackingSlip").ToString()
                dgvSalesOrders.Rows(i).Cells("ShippingMethod").Value = ds.Tables("SalesOrderHeaderTable").Rows(i).Item("ShippingMethod").ToString()
            Next
        End If
        isLoaded = True
    End Sub

    Public Sub LoadCustomer()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass", con)
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

    Public Sub LoadSalesperson()
        If cboDivisionID.Text = "TWD" Then
            cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE EmployeeStatus <> 'CLOSED' AND (SalesPersonID LIKE 'TWD%' OR SalesPersonID LIKE 'ADM%')", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "EmployeeData")
            cboSalesperson.DataSource = ds3.Tables("EmployeeData")
            con.Close()
            cboSalesperson.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey AND SalesPersonID <> @SalesPersonID AND EmployeeStatus <> 'CLOSED'", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@SalesPersonID", SqlDbType.VarChar).Value = ""
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "EmployeeData")
            cboSalesperson.DataSource = ds3.Tables("EmployeeData")
            con.Close()
            cboSalesperson.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadShipTo()
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "AdditionalShipTo")
        cboShipID.DataSource = ds5.Tables("AdditionalShipTo")
        con.Close()
        cboShipID.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesOrderKey()
        If AllSalesOrdersToolStripMenuItem.Checked = True Then
            SONumberFilter = ""
        ElseIf LastThreeYearsToolStripMenuItem.Checked = True Then
            SONumberFilter = " AND SalesOrderDate >= '1/1/2020'"
        Else
            SONumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + SONumberFilter + " ORDER BY SalesOrderKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "SalesOrderHeaderTable")
        cboSalesOrderKey.DataSource = ds6.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderKey.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID ORDER BY CustomerID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As System.Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID ORDER BY CustomerName"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As System.Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub LoadTotalsByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesperson.Text <> "" Then
            SalespersonFilter = " AND Salesperson = '" + cboSalesperson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If cboSalesOrderKey.Text <> "" Then
            SalesOrderKey = cboSalesOrderKey.Text
            strSalesOrderKey = CStr(SalesOrderKey)
            SalesOrderFilter = " AND SalesOrderKey = '" + strSalesOrderKey + "'"
        Else
            SalesOrderFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            POFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            POFilter = ""
        End If
        If cboSOStatus.Text <> "" Then
            StatusFilter = " AND SOStatus = '" + cboSOStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If cboShipID.Text <> "" Then
            ShipToFilter = " AND AdditionalShipTo = '" + cboShipID.Text + "'"
        Else
            ShipToFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (CustomerID LIKE '%" + txtTextFilter.Text + "%' OR ShipToName LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If chkDateRange.Checked = True Then
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                BeginDate = dtpBeginDate.Value
                EndDate = dtpEndDate.Value
            Else
                BeginDate = dtpBeginDate.Value
                EndDate = dtpEndDate.Value
            End If

            DateFilter = " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Else
            If AllSalesOrdersToolStripMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf LastThreeYearsToolStripMenuItem.Checked = True Then
                DateFilter = " AND SalesOrderDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        End If

        If cboSOStatus.Text = "QUOTE" Then
            If chkDateRange.Checked = False Then
                Dim FreightTotalString As String = "SELECT SUM(FreightCharge) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter
                Dim FreightTotalCommand As New SqlCommand(FreightTotalString, con)
                FreightTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim ProductTotalString As String = "SELECT SUM(ProductTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter
                Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
                ProductTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim SOTotalString As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter
                Dim SOTotalCommand As New SqlCommand(SOTotalString, con)
                SOTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim OrderNumberString As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter
                Dim OrderNumberCommand As New SqlCommand(OrderNumberString, con)
                OrderNumberCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    FreightTotal = CDbl(FreightTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    FreightTotal = 0
                End Try
                Try
                    ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                Try
                    SalesTotal = CDbl(SOTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    SalesTotal = 0
                End Try
                Try
                    OrderNumber = CInt(OrderNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    OrderNumber = 0
                End Try
                con.Close()
            Else
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    BeginDate = dtpBeginDate.Value
                    EndDate = dtpEndDate.Value
                Else
                    BeginDate = dtpBeginDate.Value
                    EndDate = dtpEndDate.Value
                End If

                strBeginDate = CStr(BeginDate)
                strEndDate = CStr(EndDate)

                DateFilter = " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"

                Dim FreightTotalString As String = "SELECT SUM(FreightCharge) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + TextFilter + ShipToFilter + DateFilter
                Dim FreightTotalCommand As New SqlCommand(FreightTotalString, con)
                FreightTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                FreightTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = strBeginDate
                FreightTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = strEndDate

                Dim ProductTotalString As String = "SELECT SUM(ProductTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + TextFilter + ShipToFilter + DateFilter
                Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
                ProductTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = strBeginDate
                ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = strEndDate

                Dim SOTotalString As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + TextFilter + ShipToFilter + DateFilter
                Dim SOTotalCommand As New SqlCommand(SOTotalString, con)
                SOTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                SOTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = strBeginDate
                SOTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = strEndDate

                Dim OrderNumberString As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + TextFilter + ShipToFilter + DateFilter
                Dim OrderNumberCommand As New SqlCommand(OrderNumberString, con)
                OrderNumberCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                OrderNumberCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = strBeginDate
                OrderNumberCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = strBeginDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    FreightTotal = CDbl(FreightTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    FreightTotal = 0
                End Try
                Try
                    ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                Try
                    SalesTotal = CDbl(SOTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    SalesTotal = 0
                End Try
                Try
                    OrderNumber = CInt(OrderNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    OrderNumber = 0
                End Try
                con.Close()
            End If
        Else 'Not a quote
            If chkDateRange.Checked = False Then
                Dim FreightTotalString As String = "SELECT SUM(FreightCharge) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter
                Dim FreightTotalCommand As New SqlCommand(FreightTotalString, con)
                FreightTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                FreightTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

                Dim ProductTotalString As String = "SELECT SUM(ProductTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter
                Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
                ProductTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                ProductTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

                Dim SOTotalString As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter
                Dim SOTotalCommand As New SqlCommand(SOTotalString, con)
                SOTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                SOTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

                Dim OrderNumberString As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND DivisionKey = @DivisionKey" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter
                Dim OrderNumberCommand As New SqlCommand(OrderNumberString, con)
                OrderNumberCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                OrderNumberCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    FreightTotal = CDbl(FreightTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    FreightTotal = 0
                End Try
                Try
                    ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                Try
                    SalesTotal = CDbl(SOTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    SalesTotal = 0
                End Try
                Try
                    OrderNumber = CInt(OrderNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    OrderNumber = 0
                End Try
                con.Close()
            Else
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    BeginDate = dtpBeginDate.Value
                    EndDate = dtpEndDate.Value
                Else
                    BeginDate = dtpBeginDate.Value
                    EndDate = dtpEndDate.Value
                End If

                strBeginDate = CStr(BeginDate)
                strEndDate = CStr(EndDate)

                DateFilter = " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"

                Dim FreightTotalString As String = "SELECT SUM(FreightCharge) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter + DateFilter
                Dim FreightTotalCommand As New SqlCommand(FreightTotalString, con)
                FreightTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                FreightTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
                FreightTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                FreightTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                Dim ProductTotalString As String = "SELECT SUM(ProductTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter + DateFilter
                Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
                ProductTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                ProductTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
                ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                Dim SOTotalString As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter + DateFilter
                Dim SOTotalCommand As New SqlCommand(SOTotalString, con)
                SOTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                SOTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
                SOTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                SOTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                Dim OrderNumberString As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + SalesOrderFilter + POFilter + SalespersonFilter + StatusFilter + ShipToFilter + TextFilter + DateFilter
                Dim OrderNumberCommand As New SqlCommand(OrderNumberString, con)
                OrderNumberCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                OrderNumberCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
                OrderNumberCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                OrderNumberCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    FreightTotal = CDbl(FreightTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    FreightTotal = 0
                End Try
                Try
                    ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                Try
                    SalesTotal = CDbl(SOTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    SalesTotal = 0
                End Try
                Try
                    OrderNumber = CInt(OrderNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    OrderNumber = 0
                End Try
                con.Close()
            End If
        End If

        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtFreightTotal.Text = FormatCurrency(FreightTotal, 2)
        txtSalesTotal.Text = FormatCurrency(SalesTotal, 2)
        txtOrderNumber.Text = OrderNumber
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSalesOrders.DataSource = Nothing
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        'Set date format
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            dgvSalesOrders.Columns("TotalSalesTaxColumn").HeaderText = "GST"
            dgvSalesOrders.Columns("TotalSalesTax2Column").Visible = True
            dgvSalesOrders.Columns("TotalSalesTax3Column").Visible = True
        Else
            dgvSalesOrders.Columns("TotalSalesTaxColumn").HeaderText = "Sales Tax"
            dgvSalesOrders.Columns("TotalSalesTax2Column").Visible = False
            dgvSalesOrders.Columns("TotalSalesTax3Column").Visible = False
        End If

        LoadCustomer()
        LoadCustomerName()
        LoadShipTo()
        LoadSalesOrderKey()
        LoadSalesperson()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesperson.SelectedIndex = -1
        cboSOStatus.SelectedIndex = -1
        cboShipID.SelectedIndex = -1
        cboSalesOrderKey.SelectedIndex = -1

        txtFreightTotal.Clear()
        txtOrderNumber.Clear()
        txtProductTotal.Clear()
        txtSalesTotal.Clear()
        txtTextFilter.Clear()
        txtCustomerPO.Clear()

        GlobalSONumber = 0

        chkDateRange.Checked = False
        chkIncludeSLCLines.Checked = False
    End Sub

    Private Sub cmdOpenSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenSalesOrder.Click
        GlobalSONumber = Val(cboSalesOrderNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewSOForm As New SOForm
        NewSOForm.Show()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        isLoaded = False
        ShowDataByFilter()
        LoadTotalsByFilter()
        isLoaded = True
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintSalesOrderListing As New PrintSalesOrderListing
            Dim Result = NewPrintSalesOrderListing.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintSalesOrderListing As New PrintSalesOrderListing
            Dim Result = NewPrintSalesOrderListing.ShowDialog()
        End Using
    End Sub

    Private Sub PrintBySalesmanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBySalesmanToolStripMenuItem.Click
        GDS = ds
        Using NewPrintSalesOrderListingBySalesman As New PrintSalesOrderListingBySalesman
            Dim Result = NewPrintSalesOrderListingBySalesman.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvSalesOrders_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSalesOrders.CellValueChanged
        If isLoaded And e.RowIndex <> -1 Then
            Dim chgVal As String = ""
            Dim test As String = dgvSalesOrders.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If dgvSalesOrders.Columns(e.ColumnIndex).Name.Equals("CertsAutoGenerated") Or dgvSalesOrders.Columns(e.ColumnIndex).Name.Equals("SOLog") Or dgvSalesOrders.Columns(e.ColumnIndex).Name.Equals("PulledBy") Or dgvSalesOrders.Columns(e.ColumnIndex).Name.Equals("CertsPulled") Or dgvSalesOrders.Columns(e.ColumnIndex).Name.Equals("PackingSlip") Or dgvSalesOrders.Columns(e.ColumnIndex).Name.Equals("ShippingMethod") Then
                If Not dgvSalesOrders.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
                    If dgvSalesOrders.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Length > 5 And Not dgvSalesOrders.Columns(dgvSalesOrders.CurrentCell.ColumnIndex).Name.Equals("ShippingMethod") And Not dgvSalesOrders.Columns(dgvSalesOrders.CurrentCell.ColumnIndex).Name.Equals("PulledBy") Then
                        chgVal = dgvSalesOrders.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Substring(0, 5)
                    Else
                        chgVal = dgvSalesOrders.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                    End If
                End If
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET " + dgvSalesOrders.Columns(e.ColumnIndex).Name + " = @Value WHERE SalesOrderKey = @SalesOrderKey AND ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = chgVal
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = dgvSalesOrders.Rows(e.RowIndex).Cells("SalesOrderKeyColumn").Value
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvSalesOrders.Rows(e.RowIndex).Cells("ShipmentNumber").Value
            Else
                Dim colName As String = dgvSalesOrders.Columns(e.ColumnIndex).Name
                If dgvSalesOrders.Columns(e.ColumnIndex).Name.Contains("Column") Then
                    colName = colName.Substring(0, colName.IndexOf("Column"))
                End If
                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET " + colName + " = @Value WHERE SalesOrderKey = @SalesOrderKey", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = dgvSalesOrders.Rows(e.RowIndex).Cells("SalesOrderKeyColumn").Value
                cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = dgvSalesOrders.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub AllSalesOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllSalesOrdersToolStripMenuItem.Click
        AllSalesOrdersToolStripMenuItem.Checked = True
        LastThreeYearsToolStripMenuItem.Checked = False
        ClearData()
        ClearDataInDatagrid()

        LoadSalesOrderKey()
    End Sub

    Private Sub LastThreeYearsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastThreeYearsToolStripMenuItem.Click
        AllSalesOrdersToolStripMenuItem.Checked = False
        LastThreeYearsToolStripMenuItem.Checked = True
        ClearData()
        ClearDataInDatagrid()

        LoadSalesOrderKey()
    End Sub
End Class