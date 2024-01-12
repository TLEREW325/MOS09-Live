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
Public Class ViewInvoiceLines
    Inherits System.Windows.Forms.Form

    Dim LineStatusFilter, FOBFilter, POFilter, TextFilter, CustomerFilter, SOFilter, InvoiceFilter, ShipmentFilter, DateFilter, PartFilter As String
    Dim strSONumber, strShipmentNumber, strInvoiceNumber As String
    Dim ShipmentNumber, SalesOrderNumber, InvoiceNumber As Integer
    Dim ProductTotal, COGS, ProfitMargin, TotalQuantity As Double
    Dim LineComment, SerialNumber As String
    Dim BeginDate, EndDate As Date
    Dim ConvertedFOB As String = ""
    Dim SONumberFilter As String = ""
    Dim ShipNumberFilter As String = ""
    Dim InvoiceNumberFilter As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewInvoiceLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()

        'By default - load last three years of data unless told differently
        ViewAllLinesToolStripMenuItem.Checked = False
        ViewLast3YearsToolStripMenuItem.Checked = True

        LoadSecurity()
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

    Public Sub LoadSecurity()
        Select Case EmployeeCompanyCode
            Case "TWD"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case "TWE"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Or EmployeeSecurityCode = "1003" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case "TFP"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case "ADM"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case Else
                lblCOGS.Visible = True
                lblMargin.Visible = True
                txtMargin.Visible = True
                txtCOGS.Visible = True
                dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
        End Select
    End Sub

    Private Sub dgvInvoiceLines_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvInvoiceLines.CellDoubleClick
        Dim RowInvoiceNumber, RowShipmentNumber, RowSONumber As Integer
        Dim RowDivision As String = ""
        Dim CustomerEmail, RowCustomer As String

        Dim RowIndex As Integer = Me.dgvInvoiceLines.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("InvoiceHeaderKeyColumn").Value
        RowShipmentNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowSONumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
        RowDivision = Me.dgvInvoiceLines.Rows(RowIndex).Cells("DivisionIDColumn").Value
        RowCustomer = Me.dgvInvoiceLines.Rows(RowIndex).Cells("CustomerIDColumn").Value

        Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
        CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
        CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerEmail = ""
        End Try
        con.Close()

        GlobalShipmentNumber = RowShipmentNumber
        GlobalDivisionCode = RowDivision

        'Choose the Invoice Print Form by division
        If RowShipmentNumber = 0 Or RowSONumber = 0 Then
            GlobalInvoiceNumber = RowInvoiceNumber
            GlobalDivisionCode = RowDivision
            'Get string Customer/InvoiceNumber for emails
            EmailInvoiceCustomer = RowCustomer
            EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
            EmailCustomerEmailAddress = CustomerEmail

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
                Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                    Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                End Using
            Else
                Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                    Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                End Using
            End If
        Else
            GlobalInvoiceNumber = RowInvoiceNumber
            GlobalDivisionCode = RowDivision
            'Get string Customer/InvoiceNumber for emails
            EmailInvoiceCustomer = RowCustomer
            EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
            EmailCustomerEmailAddress = CustomerEmail

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
                Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                    Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                End Using
            Else
                Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                    Dim result = NewPrintInvoiceSingle.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvInvoiceLines.Columns("DivisionIDColumn").Visible = False
        Me.dgvInvoiceLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboFOB.Text <> "" Then
            ConvertFOB()
            FOBFilter = " AND FOB = '" + ConvertedFOB + "'"
        Else
            FOBFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SalesOrderNumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SalesOrderNumber)
            SOFilter = " AND SalesOrderNumber = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboInvoiceNumber.Text <> "" Then
            InvoiceNumber = Val(cboInvoiceNumber.Text)
            strInvoiceNumber = CStr(InvoiceNumber)
            InvoiceFilter = " AND InvoiceHeaderKey = '" + strInvoiceNumber + "'"
        Else
            InvoiceFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR PartDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR CustomerID LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            POFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            POFilter = ""
        End If
        If cboLineStatus.Text <> "" Then
            LineStatusFilter = " AND LineStatus = '" + cboLineStatus.Text + "'"
        Else
            LineStatusFilter = ""
        End If
        If chkDateRange.Checked = False Then
            If ViewAllLinesToolStripMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
                DateFilter = " AND InvoiceDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        End If
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID <> @DivisionID" + SOFilter + FOBFilter + InvoiceFilter + POFilter + ShipmentFilter + PartFilter + CustomerFilter + TextFilter + LineStatusFilter + DateFilter + " ORDER BY DivisionID, InvoiceHeaderKey", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceLineQuery")
            dgvInvoiceLines.DataSource = ds.Tables("InvoiceLineQuery")
            con.Close()

            Me.dgvInvoiceLines.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID" + SOFilter + FOBFilter + InvoiceFilter + ShipmentFilter + PartFilter + POFilter + CustomerFilter + TextFilter + LineStatusFilter + DateFilter + " ORDER BY InvoiceHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceLineQuery")
            dgvInvoiceLines.DataSource = ds.Tables("InvoiceLineQuery")
            con.Close()

            Me.dgvInvoiceLines.Columns("DivisionIDColumn").Visible = False
        End If
    End Sub

    Public Sub LoadPartNumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID <> @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        Else
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        'View Last Three Years Or Not
        If ViewAllLinesToolStripMenuItem.Checked = True Then
            ShipNumberFilter = ""
        ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
            ShipNumberFilter = " AND ShipDate >= '1/1/2020'"
        Else
            ShipNumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID" + ShipNumberFilter + " ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds2.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesOrderNumber()
        'View Last Three Years Or Not
        If ViewAllLinesToolStripMenuItem.Checked = True Then
            SONumberFilter = ""
        ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
            SONumberFilter = " AND SalesOrderDate >= '1/1/2020'"
        Else
            SONumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + SONumberFilter + " ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds3.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomer()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerID FROM CustomerList WHERE DivisionID <> @DivisionID ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerID.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadInvoiceNumber()
        'View Last Three Years Or Not
        If ViewAllLinesToolStripMenuItem.Checked = True Then
            InvoiceNumberFilter = ""
        ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
            InvoiceNumberFilter = " AND InvoiceDate >= '1/1/2020'"
        Else
            InvoiceNumberFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cboInvoiceNumber.DataSource = Nothing
        Else
            cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID" + InvoiceNumberFilter + " ORDER BY InvoiceNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds5 = New DataSet()
            myAdapter5.SelectCommand = cmd
            myAdapter5.Fill(ds5, "InvoiceHeaderTable")
            cboInvoiceNumber.DataSource = ds5.Tables("InvoiceHeaderTable")
            con.Close()
            cboInvoiceNumber.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPartDescription()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID <> @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        Else
            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "ItemList")
        cboPartDescription.DataSource = ds6.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerName FROM CustomerList WHERE DivisionID <> @DivisionID ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "CustomerList")
        cboCustomerName.DataSource = ds7.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadFOB()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT FOBID FROM FOBTable WHERE DivisionID <> @DivisionID ORDER BY FOBID ASC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT FOBID FROM FOBTable WHERE DivisionID = @DivisionID ORDER BY FOBID ASC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "FOBTable")
        cboFOB.DataSource = ds8.Tables("FOBTable")
        con.Close()
        cboFOB.SelectedIndex = -1
    End Sub

    Public Sub ConvertFOB()
        Dim GetFOB As String = ""
        GetFOB = cboFOB.Text

        Select Case GetFOB
            Case "BCW"
                ConvertedFOB = "Bessemer"
            Case "DCW"
                ConvertedFOB = "Downey"
            Case "HCW"
                ConvertedFOB = "Hayward"
            Case "LCW"
                ConvertedFOB = "Lewisville"
            Case "LSCW"
                ConvertedFOB = "Lake Stevens"
            Case "PCW"
                ConvertedFOB = "Phoenix"
            Case "RCW"
                ConvertedFOB = "Renton"
            Case "SCW"
                ConvertedFOB = "Seattle"
            Case "SRL"
                ConvertedFOB = "SRL"
            Case "YCW"
                ConvertedFOB = "Lyndhurst"
            Case "Medina"
                ConvertedFOB = "Medina"
            Case "STANDARD"
                ConvertedFOB = "STANDARD"
            Case Else
                ConvertedFOB = cboFOB.Text
        End Select
    End Sub

    Public Sub LoadCustomerIDByName()
        If cboDivisionID.Text = "ADM" Then
            Dim CustomerID1 As String = ""

            Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID <> @DivisionID"
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
        Else
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
        End If
    End Sub

    Public Sub LoadCustomerNameByID()
        If cboDivisionID.Text = "ADM" Then
            Dim CustomerName1 As String = ""

            Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID <> @DivisionID"
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
        Else
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
        End If
    End Sub

    Public Sub LoadPartByDescription()
        If cboDivisionID.Text = "ADM" Then
            Dim PartNumber1 As String = ""

            Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID <> @DivisionID"
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
        Else
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
        End If
    End Sub

    Public Sub LoadDescriptionByPart()
        If cboDivisionID.Text = "ADM" Then
            Dim PartDescription1 As String = ""

            Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID <> @DivisionID"
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
        Else
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
        End If
    End Sub

    Public Sub LoadTotals()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboFOB.Text <> "" Then
            ConvertFOB()
            FOBFilter = " AND FOB = '" + ConvertedFOB + "'"
        Else
            FOBFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SalesOrderNumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SalesOrderNumber)
            SOFilter = " AND SalesOrderNumber = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboInvoiceNumber.Text <> "" Then
            InvoiceNumber = Val(cboInvoiceNumber.Text)
            strInvoiceNumber = CStr(InvoiceNumber)
            InvoiceFilter = " AND InvoiceHeaderKey = '" + strInvoiceNumber + "'"
        Else
            InvoiceFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            POFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            POFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR PartDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR CustomerID LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboLineStatus.Text <> "" Then
            LineStatusFilter = " AND LineStatus = '" + cboLineStatus.Text + "'"
        Else
            LineStatusFilter = ""
        End If
        If chkDateRange.Checked = False Then
            If ViewAllLinesToolStripMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
                DateFilter = " AND InvoiceDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        End If

        If cboDivisionID.Text = "ADM" Then
            Dim ProductTotalAllStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID <> @DivisionID" + SOFilter + FOBFilter + InvoiceFilter + POFilter + ShipmentFilter + PartFilter + CustomerFilter + TextFilter + LineStatusFilter + DateFilter
            Dim ProductTotalAllCommand As New SqlCommand(ProductTotalAllStatement, con)
            ProductTotalAllCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            ProductTotalAllCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalAllCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim COGSAllStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineQuery WHERE DivisionID <> @DivisionID" + SOFilter + FOBFilter + InvoiceFilter + POFilter + ShipmentFilter + PartFilter + CustomerFilter + TextFilter + LineStatusFilter + DateFilter
            Dim COGSAllCommand As New SqlCommand(COGSAllStatement, con)
            COGSAllCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            COGSAllCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            COGSAllCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim QuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE DivisionID <> @DivisionID" + SOFilter + FOBFilter + InvoiceFilter + POFilter + ShipmentFilter + PartFilter + CustomerFilter + TextFilter + DateFilter
            Dim QuantityCommand As New SqlCommand(QuantityStatement, con)
            QuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            QuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            QuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(ProductTotalAllCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                COGS = CDbl(COGSAllCommand.ExecuteScalar)
            Catch ex As Exception
                COGS = 0
            End Try
            Try
                TotalQuantity = CDbl(QuantityCommand.ExecuteScalar)
            Catch ex As Exception
                TotalQuantity = 0
            End Try
            con.Close()

            If ProductTotal <> 0 Then
                ProfitMargin = 1 - (COGS / ProductTotal)
            Else
                ProfitMargin = 0.0
            End If
        Else
            Dim ProductTotalAllStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID" + SOFilter + FOBFilter + InvoiceFilter + ShipmentFilter + PartFilter + CustomerFilter + TextFilter + LineStatusFilter + DateFilter
            Dim ProductTotalAllCommand As New SqlCommand(ProductTotalAllStatement, con)
            ProductTotalAllCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ProductTotalAllCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalAllCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim COGSAllStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID" + SOFilter + FOBFilter + InvoiceFilter + ShipmentFilter + PartFilter + CustomerFilter + TextFilter + LineStatusFilter + DateFilter
            Dim COGSAllCommand As New SqlCommand(COGSAllStatement, con)
            COGSAllCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            COGSAllCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            COGSAllCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim QuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID" + SOFilter + FOBFilter + InvoiceFilter + ShipmentFilter + PartFilter + CustomerFilter + TextFilter + LineStatusFilter + DateFilter
            Dim QuantityCommand As New SqlCommand(QuantityStatement, con)
            QuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            QuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            QuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(ProductTotalAllCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                COGS = CDbl(COGSAllCommand.ExecuteScalar)
            Catch ex As Exception
                COGS = 0
            End Try
            Try
                TotalQuantity = CDbl(QuantityCommand.ExecuteScalar)
            Catch ex As Exception
                TotalQuantity = 0
            End Try
            con.Close()

            If ProductTotal <> 0 Then
                ProfitMargin = 1 - (COGS / ProductTotal)
            Else
                ProfitMargin = 0.0
            End If
        End If

        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtCOGS.Text = FormatCurrency(COGS, 2)
        txtMargin.Text = FormatPercent(ProfitMargin, 2)
        txtTotalQuantity.Text = TotalQuantity
    End Sub

    Public Sub ClearData()
        'Clear text fields
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboInvoiceNumber.Text = ""
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""
        cboSalesOrderNumber.Text = ""
        cboShipmentNumber.Text = ""
        cboFOB.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1
        cboFOB.SelectedIndex = -1
        cboLineStatus.SelectedIndex = -1

        txtCOGS.Clear()
        txtMargin.Clear()
        txtProductTotal.Clear()
        txtTextFilter.Clear()
        txtTotalQuantity.Clear()
        txtCustomerPO.Clear()

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        CustomerFilter = ""
        POFilter = ""
        SOFilter = ""
        InvoiceFilter = ""
        ShipmentFilter = ""
        DateFilter = ""
        PartFilter = ""
        FOBFilter = ""
        LineStatusFilter = ""
        strSONumber = ""
        strShipmentNumber = ""
        strInvoiceNumber = ""
        ShipmentNumber = 0
        SalesOrderNumber = 0
        InvoiceNumber = 0
        ProductTotal = 0
        COGS = 0
        ProfitMargin = 0
        LineComment = ""
        SerialNumber = ""
        GlobalSONumber = 0
        GlobalShipmentNumber = 0
        GlobalInvoiceNumber = 0
        ConvertedFOB = ""
        SONumberFilter = ""
        ShipNumberFilter = ""
        InvoiceNumberFilter = ""
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearData()
        ClearVariables()
        LoadPartNumber()
        LoadPartDescription()
        LoadFOB()
        LoadShipmentNumber()
        LoadSalesOrderNumber()
        LoadCustomer()
        LoadCustomerName()
        LoadInvoiceNumber()
        ClearDataInDatagrid()
    End Sub

    Private Sub dgvInvoiceLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceLines.CellValueChanged
        Dim LineInvoiceNumber, LineInvoiceLineNumber As Integer
        Dim LineComment, SerialNumber, RowDivision As String
        Dim LineExtendedCOS, InvoiceCOS As Double

        If Me.dgvInvoiceLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInvoiceLines.CurrentCell.RowIndex

            Try
                LineInvoiceNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("InvoiceHeaderKeyColumn").Value
            Catch ex As Exception
                LineInvoiceNumber = 0
            End Try
            Try
                LineInvoiceLineNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("InvoiceLineKeyColumn").Value
            Catch ex As Exception
                LineInvoiceLineNumber = 0
            End Try
            Try
                LineComment = Me.dgvInvoiceLines.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                LineComment = ""
            End Try
            Try
                SerialNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("SerialNumberColumn").Value
            Catch ex As Exception
                SerialNumber = ""
            End Try
            Try
                LineExtendedCOS = Me.dgvInvoiceLines.Rows(RowIndex).Cells("ExtendedCOSColumn").Value
            Catch ex As Exception
                LineExtendedCOS = 0
            End Try
            Try
                RowDivision = Me.dgvInvoiceLines.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try

            If LineInvoiceNumber = 0 Then
                'Skip all Updates
            Else
                If EmployeeSecurityCode = "1001" Then
                    'UPDATE Invoice Lines
                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET ExtendedCOS = @ExtendedCOS, LineComment = @LineComment, SerialNumber = @SerialNumber WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = LineInvoiceNumber
                        .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = LineInvoiceLineNumber
                        .Add("@ExtendedCOS", SqlDbType.VarChar).Value = LineExtendedCOS
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Get SUM of Line COS to update Header
                    Dim InvoiceCOSStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey"
                    Dim InvoiceCOSCommand As New SqlCommand(InvoiceCOSStatement, con)
                    InvoiceCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    InvoiceCOSCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = LineInvoiceNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        InvoiceCOS = CDbl(InvoiceCOSCommand.ExecuteScalar)
                    Catch ex As Exception
                        InvoiceCOS = 0
                    End Try

                    'UPDATE Invoice Header (COS)
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceCOS = @InvoiceCOS WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = LineInvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@InvoiceCOS", SqlDbType.VarChar).Value = InvoiceCOS
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'UPDATE Invoice Lines
                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineComment = @LineComment, SerialNumber = @SerialNumber WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = LineInvoiceNumber
                        .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = LineInvoiceLineNumber
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        Else
            'Skip Update
        End If
    End Sub

    Private Sub cmdPrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintList.Click
        GDS = ds
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintInvoiceLinesFiltered As New PrintInvoiceLinesFiltered
            Dim result = NewPrintInvoiceLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintInvoiceLinesFiltered As New PrintInvoiceLinesFiltered
            Dim result = NewPrintInvoiceLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintInvoice.Click
        Dim RowInvoiceNumber, RowShipmentNumber, RowSONumber As Integer
        Dim RowDivision As String = ""
        Dim RowCustomer, CustomerEmail As String
        Dim RowIndex As Integer = Me.dgvInvoiceLines.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("InvoiceHeaderKeyColumn").Value
        RowShipmentNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowSONumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
        RowDivision = Me.dgvInvoiceLines.Rows(RowIndex).Cells("DivisionIDColumn").Value
        RowCustomer = Me.dgvInvoiceLines.Rows(RowIndex).Cells("CustomerIDColumn").Value

        Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
        CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowInvoiceNumber
        CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerEmail = ""
        End Try
        con.Close()

        GlobalShipmentNumber = RowShipmentNumber
        GlobalSONumber = RowSONumber
        GlobalInvoiceNumber = RowInvoiceNumber
        GlobalDivisionCode = RowDivision
        'Get string Customer/InvoiceNumber for emails
        EmailInvoiceCustomer = RowCustomer
        EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
        EmailCustomerEmailAddress = CustomerEmail

        'Choose the Invoice Print Form by division
        If GlobalShipmentNumber = 0 Or GlobalSONumber = 0 Then
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
                Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                    Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                End Using
            Else
                Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                    Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                End Using
            End If
        Else
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
                Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                    Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                End Using
            Else
                Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                    Dim result = NewPrintInvoiceSingle.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub RePrintInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RePrintInvoiceToolStripMenuItem.Click
        cmdPrintInvoice_Click(sender, e)
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilters()
        LoadTotals()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division)", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage.Substring(0, 200)
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub CustomerSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerSummaryReportToolStripMenuItem.Click
        GDS = ds

        Using NewPrintCustomerSummaryReport As New PrintCustomerSummaryReport
            Dim Result = NewPrintCustomerSummaryReport.ShowDialog()
        End Using
    End Sub

    Private Sub cmdInvoiceNoFerrules_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInvoiceNoFerrules.Click
        NoFerrulesInvoiceDivision.Division = cboDivisionID.Text
        'Sets the global variables for the "No Ferrule" Report
        If chkDateRange.Checked = False Then
            NoFerrulesInvoiceDivision.DateCheck = False
        Else
            NoFerrulesInvoiceDivision.DateCheck = True
            NoFerrulesInvoiceDivision.BeginDate = dtpBeginDate.Text
            NoFerrulesInvoiceDivision.EndDate = dtpEndDate.Text
        End If

        Using newPrintTotalNoFerrules As New PrintInvoiceTotalNoFerrules
            Dim Result = newPrintTotalNoFerrules.ShowDialog
        End Using
    End Sub

    Private Sub ViewAllLinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllLinesToolStripMenuItem.Click
        ViewAllLinesToolStripMenuItem.Checked = True
        ViewLast3YearsToolStripMenuItem.Checked = False
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        LoadInvoiceNumber()
        LoadSalesOrderNumber()
        LoadShipmentNumber()
    End Sub

    Private Sub ViewLast3YearsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLast3YearsToolStripMenuItem.Click
        ViewAllLinesToolStripMenuItem.Checked = False
        ViewLast3YearsToolStripMenuItem.Checked = True
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        LoadInvoiceNumber()
        LoadSalesOrderNumber()
        LoadShipmentNumber()
    End Sub

    Public Sub LoadUploadedPickTicket()
        If Me.dgvInvoiceLines.RowCount > 0 Then
            Dim UploadedShipmentNumber As String = ""
            Dim UploadedFileName As String = ""
            Dim UploadedFilenameAndPath As String = ""

            Dim RowIndex As Integer = Me.dgvInvoiceLines.CurrentCell.RowIndex

            UploadedShipmentNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            UploadedFileName = UploadedShipmentNumber + ".pdf"
            UploadedFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets" + "\" + UploadedFileName

            If UploadedShipmentNumber = 0 Then
                MsgBox("File can not be found.", MsgBoxStyle.OkOnly)
            Else
                If File.Exists(UploadedFilenameAndPath) Then
                    System.Diagnostics.Process.Start(UploadedFilenameAndPath)
                Else
                    MsgBox("File can not be found.", MsgBoxStyle.OkOnly)
                End If
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdViewPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPickTicket.Click
        If Me.dgvInvoiceLines.RowCount > 0 Then
            LoadUploadedPickTicket()
        End If
    End Sub
End Class