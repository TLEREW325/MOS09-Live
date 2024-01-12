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
Public Class ViewDailyShipmentLog
    Inherits System.Windows.Forms.Form

    Dim DivisionFilter, StatusFilter, ShipViaFilter, SalespersonFilter, CustomerFilter, DateFilter, SOFilter, CustPOFilter, ShipmentFilter As String
    Dim SONumber, ShipmentNumber As Integer
    Dim strSONumber, strShipmentNumber As String
    Dim ProductTotal, ShipmentTotal, SalesTaxTotal, FreightTotal As Double
    Dim TotalPallets, TotalShipments As Integer
    Dim TotalWeight As Double
    Dim BeginDate, EndDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ViewDailyShipmentLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadCurrentDivision()

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
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

    Private Sub dgvShipmentHeader_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvShipmentHeader.CellDoubleClick
        Dim RowShipmentNumber As Integer
        Dim RowDivision As String

        Dim RowIndex As Integer = Me.dgvShipmentHeader.CurrentCell.RowIndex

        RowShipmentNumber = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowDivision = Me.dgvShipmentHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value

        GlobalShipmentNumber = RowShipmentNumber
        GlobalDivisionCode = RowDivision

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
            Using NewPrintPackingListRemote As New PrintPackingListRemote
                Dim result = NewPrintPackingListRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPackingList As New PrintPackingList
                Dim result = NewPrintPackingList.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvShipmentHeader_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentHeader.CellValueChanged
        Dim RowShipmentNumber As Integer
        Dim RowComment, RowPRONumber, RowShipVia, RowFreightQuoteNumber, RowShipAddress1, RowShipAddress2, RowShipCity, RowShipState, RowShipZip, RowShipCountry, RowCustomerPO, RowSalesmanID, RowSpecialInstructions As String
        Dim RowShippingWeight, RowFreightQuoteAmount As Double
        Dim RowPallets As Integer

        Try
            Dim RowIndex As Integer = Me.dgvShipmentHeader.CurrentCell.RowIndex

            RowShipmentNumber = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowComment = Me.dgvShipmentHeader.Rows(RowIndex).Cells("CommentColumn").Value
            RowShipVia = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipViaColumn").Value
            RowPRONumber = Me.dgvShipmentHeader.Rows(RowIndex).Cells("PRONumberColumn").Value
            RowFreightQuoteNumber = Me.dgvShipmentHeader.Rows(RowIndex).Cells("FreightQuoteNumberColumn").Value
            RowShippingWeight = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShippingWeightColumn").Value
            RowPallets = Me.dgvShipmentHeader.Rows(RowIndex).Cells("NumberOfPalletsColumn").Value
            RowShipAddress1 = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipAddress1Column").Value
            RowShipAddress2 = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipAddress2Column").Value
            RowShipCity = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipCityColumn").Value
            RowShipState = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipStateColumn").Value
            RowShipZip = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipZipColumn").Value
            RowShipCountry = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipCountryColumn").Value
            RowCustomerPO = Me.dgvShipmentHeader.Rows(RowIndex).Cells("CustomerPOColumn").Value
            RowSpecialInstructions = Me.dgvShipmentHeader.Rows(RowIndex).Cells("SpecialInstructionsColumn").Value
            RowFreightQuoteAmount = Me.dgvShipmentHeader.Rows(RowIndex).Cells("FreightQuoteAmountColumn").Value
            RowSalesmanID = Me.dgvShipmentHeader.Rows(RowIndex).Cells("SalesmanIDColumn").Value

            'Save grid changes to Shipment Table
            cmd = New SqlCommand("Update ShipmentHeaderTable SET Comment = @Comment, ShipVia = @ShipVia, PRONumber = @PRONumber,  FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, CustomerPO = @CustomerPO, SpecialInstructions = @SpecialInstructions, SalesmanID = @SalesmanID WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                .Add("@PRONumber", SqlDbType.VarChar).Value = RowPRONumber
                .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = RowFreightQuoteNumber
                .Add("@ShippingWeight", SqlDbType.VarChar).Value = RowShippingWeight
                .Add("@NumberOfPallets", SqlDbType.VarChar).Value = RowPallets
                .Add("@ShipAddress1", SqlDbType.VarChar).Value = RowShipAddress1
                .Add("@ShipAddress2", SqlDbType.VarChar).Value = RowShipAddress2
                .Add("@ShipCity", SqlDbType.VarChar).Value = RowShipCity
                .Add("@ShipState", SqlDbType.VarChar).Value = RowShipState
                .Add("@ShipZip", SqlDbType.VarChar).Value = RowShipZip
                .Add("@ShipCountry", SqlDbType.VarChar).Value = RowShipCountry
                .Add("@CustomerPO", SqlDbType.VarChar).Value = RowCustomerPO
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = RowSpecialInstructions
                .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = RowFreightQuoteAmount
                .Add("@SalesmanID", SqlDbType.VarChar).Value = RowSalesmanID
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip on load
        End Try
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomer()
        LoadCustomerName()
        LoadShipmentNumber()
        LoadSONumber()
        LoadSalesperson()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        If cboDivisionID.Text = "TWD" Then
            chkIncludeTFP.Visible = True
            chkIncludeTFP.Text = "Include TFP?"
            chkIncludeTFP.Checked = True
        ElseIf cboDivisionID.Text = "TFP" Then
            chkIncludeTFP.Visible = True
            chkIncludeTFP.Text = "Include TWD?"
            chkIncludeTFP.Checked = True
        Else
            chkIncludeTFP.Visible = False
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvShipmentHeader.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO = '" + usefulFunctions.checkQuote(txtCustomerPO.Text) + "'"
        Else
            CustPOFilter = ""
        End If
        If cboSalesperson.Text <> "" Then
            SalespersonFilter = " AND SalesmanID = '" + cboSalesperson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If txtShipVia.Text <> "" Then
            ShipViaFilter = " AND ShipVia LIKE '%" + txtShipVia.Text + "%'"
        Else
            ShipViaFilter = ""
        End If
        If chkCompleted.Checked = True Then
            StatusFilter = " AND ShipmentStatus <> 'PENDING'"
        Else
            StatusFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
      
            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        'Choose query by division (ADMIN)
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter + " ORDER BY DivisionID, ShipmentNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvShipmentHeader.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

            'Make Division column visible
            Me.dgvShipmentHeader.Columns("DivisionIDColumn").Visible = True
        ElseIf cboDivisionID.Text = "TWD" And chkIncludeTFP.Checked = True Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE (DivisionID = 'TWD' OR DivisionID = 'TFP')" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvShipmentHeader.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

            Me.dgvShipmentHeader.Columns("DivisionIDColumn").Visible = False
        ElseIf cboDivisionID.Text = "TWD" And chkIncludeTFP.Checked = False Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvShipmentHeader.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

            Me.dgvShipmentHeader.Columns("DivisionIDColumn").Visible = False
        ElseIf cboDivisionID.Text = "TFP" And chkIncludeTFP.Checked = True Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE (DivisionID = 'TWD' OR DivisionID = 'TFP')" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvShipmentHeader.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

            Me.dgvShipmentHeader.Columns("DivisionIDColumn").Visible = False
        ElseIf cboDivisionID.Text = "TFP" And chkIncludeTFP.Checked = False Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvShipmentHeader.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

            Me.dgvShipmentHeader.Columns("DivisionIDColumn").Visible = False
        Else
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvShipmentHeader.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

            Me.dgvShipmentHeader.Columns("DivisionIDColumn").Visible = False
        End If
    End Sub

    Public Sub LoadCustomer()
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

    Public Sub LoadSONumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds2.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds3.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesperson()
        cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "EmployeeData")
        cboSalesperson.DataSource = ds4.Tables("EmployeeData")
        con.Close()
        cboSalesperson.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CustomerList")
        cboCustomerName.DataSource = ds5.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
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

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Public Sub LoadTotalsByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO = '" + usefulFunctions.checkQuote(txtCustomerPO.Text) + "'"
        Else
            CustPOFilter = ""
        End If
        If cboSalesperson.Text <> "" Then
            SalespersonFilter = " AND SalesmanID = '" + cboSalesperson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If txtShipVia.Text <> "" Then
            ShipViaFilter = " AND ShipVia LIKE '%" + txtShipVia.Text + "%'"
        Else
            ShipViaFilter = ""
        End If
        If chkCompleted.Checked = True Then
            StatusFilter = " AND ShipmentStatus <> 'PENDING'"
        Else
            StatusFilter = ""
        End If
        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            If chkIncludeTFP.Checked = True Then
                DivisionFilter = "(DivisionID = 'TWD' OR DivisionID = 'TFP')"
            Else
                DivisionFilter = "DivisionID = @DivisionID"
            End If
        Else
            DivisionFilter = "DivisionID = @DivisionID"
        End If

        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
       
            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            Dim FreightTotalStatement As String = "SELECT SUM(FreightActualAmount) FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim FreightTotalCommand As New SqlCommand(FreightTotalStatement, con)
            FreightTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            FreightTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            FreightTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim SalesTaxTotalStatement As String = "SELECT SUM(TaxTotal + Tax3Total + Tax2Total) FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim SalesTaxTotalCommand As New SqlCommand(SalesTaxTotalStatement, con)
            SalesTaxTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            SalesTaxTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            SalesTaxTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim ProductTotalStatement As String = "SELECT SUM(ProductTotal) FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
            ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim ShipmentTotalStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim ShipmentTotalCommand As New SqlCommand(ShipmentTotalStatement, con)
            ShipmentTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            ShipmentTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ShipmentTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalWeightStatement As String = "SELECT SUM(ShippingWeight) FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim TotalWeightCommand As New SqlCommand(TotalWeightStatement, con)
            TotalWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            TotalWeightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalWeightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalPalletsStatement As String = "SELECT SUM(NumberOfPallets) FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim TotalPalletsCommand As New SqlCommand(TotalPalletsStatement, con)
            TotalPalletsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            TotalPalletsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalPalletsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalNumberOfShipmentsStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim TotalNumberOfShipmentsCommand As New SqlCommand(TotalNumberOfShipmentsStatement, con)
            TotalNumberOfShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            TotalNumberOfShipmentsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalNumberOfShipmentsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FreightTotal = CDbl(FreightTotalCommand.ExecuteScalar)
            Catch ex As Exception
                FreightTotal = 0
            End Try
            Try
                SalesTaxTotal = CDbl(SalesTaxTotalCommand.ExecuteScalar)
            Catch ex As Exception
                SalesTaxTotal = 0
            End Try
            Try
                ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                ShipmentTotal = CDbl(ShipmentTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ShipmentTotal = 0
            End Try
            Try
                TotalWeight = CDbl(TotalWeightCommand.ExecuteScalar)
            Catch ex As Exception
                TotalWeight = 0
            End Try
            Try
                TotalPallets = CDbl(TotalPalletsCommand.ExecuteScalar)
            Catch ex As Exception
                TotalPallets = 0
            End Try
            Try
                TotalShipments = CDbl(TotalNumberOfShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                TotalShipments = 0
            End Try
            con.Close()
        Else
            Dim FreightTotalStatement As String = "SELECT SUM(FreightActualAmount) FROM ShipmentHeaderTable WHERE " + DivisionFilter + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim FreightTotalCommand As New SqlCommand(FreightTotalStatement, con)
            FreightTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            FreightTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            FreightTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim SalesTaxTotalStatement As String = "SELECT SUM(TaxTotal + Tax3Total + Tax2Total) FROM ShipmentHeaderTable WHERE " + DivisionFilter + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim SalesTaxTotalCommand As New SqlCommand(SalesTaxTotalStatement, con)
            SalesTaxTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SalesTaxTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            SalesTaxTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim ProductTotalStatement As String = "SELECT SUM(ProductTotal) FROM ShipmentHeaderTable WHERE " + DivisionFilter + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
            ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim ShipmentTotalStatement As String = "SELECT SUM(ShipmentTotal) FROM ShipmentHeaderTable WHERE " + DivisionFilter + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim ShipmentTotalCommand As New SqlCommand(ShipmentTotalStatement, con)
            ShipmentTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ShipmentTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ShipmentTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalWeightStatement As String = "SELECT SUM(ShippingWeight) FROM ShipmentHeaderTable WHERE " + DivisionFilter + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim TotalWeightCommand As New SqlCommand(TotalWeightStatement, con)
            TotalWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalWeightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalWeightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalPalletsStatement As String = "SELECT SUM(NumberOfPallets) FROM ShipmentHeaderTable WHERE " + DivisionFilter + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim TotalPalletsCommand As New SqlCommand(TotalPalletsStatement, con)
            TotalPalletsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalPalletsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalPalletsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalNumberOfShipmentsStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE " + DivisionFilter + CustPOFilter + SOFilter + ShipmentFilter + CustomerFilter + SalespersonFilter + ShipViaFilter + StatusFilter + DateFilter
            Dim TotalNumberOfShipmentsCommand As New SqlCommand(TotalNumberOfShipmentsStatement, con)
            TotalNumberOfShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalNumberOfShipmentsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalNumberOfShipmentsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FreightTotal = CDbl(FreightTotalCommand.ExecuteScalar)
            Catch ex As Exception
                FreightTotal = 0
            End Try
            Try
                SalesTaxTotal = CDbl(SalesTaxTotalCommand.ExecuteScalar)
            Catch ex As Exception
                SalesTaxTotal = 0
            End Try
            Try
                ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                ShipmentTotal = CDbl(ShipmentTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ShipmentTotal = 0
            End Try
            Try
                TotalWeight = CDbl(TotalWeightCommand.ExecuteScalar)
            Catch ex As Exception
                TotalWeight = 0
            End Try
            Try
                TotalPallets = CDbl(TotalPalletsCommand.ExecuteScalar)
            Catch ex As Exception
                TotalPallets = 0
            End Try
            Try
                TotalShipments = CDbl(TotalNumberOfShipmentsCommand.ExecuteScalar)
            Catch ex As Exception
                TotalShipments = 0
            End Try
            con.Close()
        End If

        txtFreightTotal.Text = FormatCurrency(FreightTotal, 2)
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtShipmentTotal.Text = FormatCurrency(ShipmentTotal, 2)
        txtTaxTotal.Text = FormatCurrency(SalesTaxTotal, 2)
        txtTotalNumberOfShipments.Text = TotalShipments
        txtTotalPallets.Text = TotalPallets
        txtTotalWeight.Text = TotalWeight
    End Sub

    Public Sub ClearVariables()
        CustomerFilter = ""
        DateFilter = ""
        SOFilter = ""
        CustPOFilter = ""
        ShipmentFilter = ""
        ShipViaFilter = ""
        StatusFilter = ""
        SONumber = 0
        ShipmentNumber = 0
        strSONumber = ""
        strShipmentNumber = ""
        ProductTotal = 0
        ShipmentTotal = 0
        SalesTaxTotal = 0
        FreightTotal = 0
        TotalWeight = 0
        TotalShipments = 0
        TotalPallets = 0
    End Sub

    Public Sub ClearData()
        txtFreightTotal.Clear()
        txtProductTotal.Clear()
        txtShipmentTotal.Clear()
        txtTaxTotal.Clear()
        txtCustomerPO.Clear()
        txtShipVia.Clear()
        txtTotalNumberOfShipments.Clear()
        txtTotalPallets.Clear()
        txtTotalWeight.Clear()

        cboShipmentNumber.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboSalesperson.SelectedIndex = -1

        chkDateRange.Checked = False
        chkCompleted.Checked = True

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboCustomerID.Focus()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        clearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
        LoadTotalsByFilter()
    End Sub

    Private Sub cmdShipmentDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShipmentDetails.Click
        Dim RowShipmentNumber As Integer

        Dim RowIndex As Integer = Me.dgvShipmentHeader.CurrentCell.RowIndex

        RowShipmentNumber = Me.dgvShipmentHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value

        GlobalShipmentNumber = RowShipmentNumber
        GlobalDivisionCode = cboDivisionID.Text

        Using NewShipmentLineComments As New ShipmentLineComments
            Dim Result = NewShipmentLineComments.ShowDialog
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrintListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintListing.Click
        GDS = ds
        Using NewPrintShipmentLogReportFiltered As New PrintShipmentLogReportFiltered
            Dim Result = NewPrintShipmentLogReportFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintShipmentLogReportFiltered As New PrintShipmentLogReportFiltered
            Dim Result = NewPrintShipmentLogReportFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintDetailedLogReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintDetailedLogReportToolStripMenuItem.Click
        GDS = ds
        Using NewPrintDailyShipmentLog As New PrintDailyShipmentLog
            Dim Result = NewPrintDailyShipmentLog.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintDailyShipmentLog As New PrintDailyShipmentLog
            Dim Result = NewPrintDailyShipmentLog.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub
End Class