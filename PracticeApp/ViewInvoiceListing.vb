'Option Strict Off

Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Net.Mail
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports WIA
Imports PdfSharp.Pdf
Imports System.Threading
Imports iTextSharp.text.Image
Imports PdfSharp
Imports document = iTextSharp.text.Document
Imports System.Drawing
Imports System.ComponentModel
Imports iTextSharp
Imports System.Reflection
Public Class ViewInvoiceListing
    Inherits System.Windows.Forms.Form

    Dim ShipmentNumber, SalesOrderNumber, NumberOfCustomers As Integer
    Dim strShipmentNumber, strSONumber As String
    Dim PmtTermsFilter, TerritoryFilter, TextFilter, SOFilter, CustomerFilter, ShipFilter, DateFilter, CustomerPOFilter, StatusFilter, CustomerClassFilter As String
    Dim SpecialInstructions As String
    Dim PendingTotal, PostedTotal, ProductTotal, TaxTotal, Tax2Total, Tax3Total, InvoiceTotal, FreightTotal As Double
    Dim BeginDate, EndDate As Date
    Dim IsLoaded As Boolean = False
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""
    Dim TodaysDate As Date = Now()

    'Remote
    Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\CashReceipts\UploadedCashReceipts\")
    Dim FilesToDelete As List(Of String)
    Dim bgPDF As BackgroundWorker
    Dim bgAppendPDF As BackgroundWorker
    Dim LoadingScreen As New Loading

    ''Remote WIA variables
    Dim remoteWIA As MOSRemoteWIA
    Dim bgwkRemoteWIA As BackgroundWorker
    Dim frm As System.Windows.Forms.Form
    Dim remoteCheck As Boolean = False


    'Variables to generate unique reprint batch number
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    'Variables to limit data to the last three years
    Dim SONumberFilter As String = ""
    Dim ShipmentNumberFilter As String = ""
    Dim InvoiceNumberFilter As String = ""
    Dim FilterDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10, cmd11 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, tempDS As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    'Form load events

    Private Sub ViewInvoiceListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        IsLoaded = True

        LoadCurrentDivision()

        IsLoaded = False

        If EmployeeCompanyCode = "ADM" Then
            cmdPrintMultiple.Enabled = False
            ViewLastThreeMenuItem.Checked = True
            ViewAllDataMenuItem.Checked = False
        Else
            cmdPrintMultiple.Enabled = True
            ViewLastThreeMenuItem.Checked = True
            ViewAllDataMenuItem.Checked = False
        End If
        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdAppendPickTicket.Visible = False
            cmdReuploadPickTicket.Visible = False
        Else
            cmdRemoteScan.Visible = False
            cmdAppendPickTicket.Visible = True
            cmdReuploadPickTicket.Visible = True
        End If
        If EmployeeLoginName = "LEREW" Then
            PrintInvoiceDiscrepancyReportToolStripMenuItem.Enabled = True
            PrintInvoicePaymentReportToolStripMenuItem.Enabled = True
            cmdCloseInvoice.Visible = True
            cmdOpenInvoice.Visible = True
        Else
            PrintInvoiceDiscrepancyReportToolStripMenuItem.Enabled = False
            PrintInvoicePaymentReportToolStripMenuItem.Enabled = False
            cmdCloseInvoice.Visible = False
            cmdOpenInvoice.Visible = False
        End If

        LoadCustomerClass()

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        IsLoaded = True
        '(cmdUploadPickTicket, cboShipmentNumber, ReUploadPickTicketToolStripMenuItem, Me, AppendUploadedPickTicketToolStripMenuItem)

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
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

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

    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
            'Delete all child Directories
            For Each dir As String In Directory.GetDirectories(path)
                DeleteDirectory(dir)
            Next
            'Delete a Directory
            Directory.Delete(path)
        End If
    End Sub

    'Load datasets for the datagridview

    Public Sub ClearDataInDatagrid()
        dgvInvoiceHeader.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSONumber.Text <> "" Then
            SalesOrderNumber = Val(cboSONumber.Text)
            strSONumber = CStr(SalesOrderNumber)
            SOFilter = " AND SalesOrderNumber = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipFilter = ""
        End If
        If cboCustomerClass.Text <> "" Then
            CustomerClassFilter = " AND CustomerClass = '" + cboCustomerClass.Text + "'"
        Else
            CustomerClassFilter = ""
        End If
        If cboStatus.Text <> "" Then
            StatusFilter = " AND InvoiceStatus = '" + cboStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If cboCustomerTerritory.Text <> "" Then
            TerritoryFilter = " AND SalesTerritory = '" + cboCustomerTerritory.Text + "'"
        Else
            TerritoryFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustomerPOFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            CustomerPOFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (CustomerID LIKE '%" + txtTextFilter.Text + "%' OR CustomerPO LIKE '%" + txtTextFilter.Text + "%' OR PRONumber LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboPaymentTerms.Text <> "" Then
            PmtTermsFilter = " AND PaymentTerms = '" + cboPaymentTerms.Text + "'"
        Else
            PmtTermsFilter = ""
        End If
        If chkDateRange.Checked = False Then
            If ViewAllDataMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf ViewLastThreeMenuItem.Checked = True Then
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
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter + " ORDER BY DivisionID, InvoiceNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceHeaderQuery")
            dgvInvoiceHeader.DataSource = ds.Tables("InvoiceHeaderQuery")
            con.Close()

            Me.dgvInvoiceHeader.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter + " ORDER BY InvoiceNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceHeaderQuery")
            dgvInvoiceHeader.DataSource = ds.Tables("InvoiceHeaderQuery")
            con.Close()

            Me.dgvInvoiceHeader.Columns("DivisionIDColumn").Visible = False
        End If

        LoadFormatting()
    End Sub

    'Load datasets for controls

    Public Sub LoadSONumber()
        'Date Filter
        If ViewAllDataMenuItem.Checked = True Then
            SONumberFilter = ""
        ElseIf ViewLastThreeMenuItem.Checked = True Then
            SONumberFilter = " AND SalesOrderDate >= '1/1/2020'"
        Else
            SONumberFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey <> @DivisionKey" + SONumberFilter + " ORDER BY SalesOrderKey DESC", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + SONumberFilter + " ORDER BY SalesOrderKey DESC", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "SalesOrderHeaderTable")
        cboSONumber.DataSource = ds1.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSONumber.SelectedIndex = -1
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
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        cboCustomerID.DisplayMember = "CustomerID"
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        'Date Filter
        If ViewAllDataMenuItem.Checked = True Then
            ShipmentNumberFilter = ""
        ElseIf ViewLastThreeMenuItem.Checked = True Then
            ShipmentNumberFilter = " AND ShipDate >= '1/1/2020'"
        Else
            ShipmentNumberFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + ShipmentNumberFilter + " ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID" + ShipmentNumberFilter + " ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds3.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerClass()
        cmd = New SqlCommand("SELECT DISTINCT CustomerClassID FROM CustomerClass ORDER BY CustomerClassID ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerClass")
        cboCustomerClass.DataSource = ds4.Tables("CustomerClass")
        con.Close()
        cboCustomerClass.SelectedIndex = -1
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
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CustomerList")
        cboCustomerName.DataSource = ds5.Tables("CustomerList")
        cboCustomerName.DisplayMember = "CustomerName"
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadInvoiceNumber()
        'Date Filter
        If ViewAllDataMenuItem.Checked = True Then
            InvoiceNumberFilter = ""
        ElseIf ViewLastThreeMenuItem.Checked = True Then
            InvoiceNumberFilter = " AND InvoiceDate >= '1/1/2020'"
        Else
            InvoiceNumberFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID" + InvoiceNumberFilter + " ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID" + InvoiceNumberFilter + " ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "InvoiceHeaderQuery")
        cboInvoiceNumber.DataSource = ds6.Tables("InvoiceHeaderQuery")
        con.Close()
        cboInvoiceNumber.SelectedIndex = -1

        'MsgBox("Pause", MsgBoxStyle.OkOnly)
    End Sub

    Public Sub LoadSalesTerritory()
        cmd = New SqlCommand("SELECT DISTINCT SalesTerritory FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "CustomerList")
        cboCustomerTerritory.DataSource = ds9.Tables("CustomerList")
        con.Close()
        cboCustomerTerritory.SelectedIndex = -1
    End Sub

    'Load Data

    Public Sub LoadProductTotalByFilter()
        If cboDivisionID.Text = "ADM" Then
            Dim ProductTotalByDateString As String = "SELECT SUM(ProductTotal) FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim ProductTotalByDateCommand As New SqlCommand(ProductTotalByDateString, con)
            ProductTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            ProductTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            ProductTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim TaxTotalByDateString As String = "SELECT SUM(SalesTax) FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim TaxTotalByDateCommand As New SqlCommand(TaxTotalByDateString, con)
            TaxTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            TaxTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TaxTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            TaxTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim Tax2TotalByDateString As String = "SELECT SUM(SalesTax2) FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim Tax2TotalByDateCommand As New SqlCommand(Tax2TotalByDateString, con)
            Tax2TotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            Tax2TotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            Tax2TotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            Tax2TotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim Tax3TotalByDateString As String = "SELECT SUM(SalesTax3) FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim Tax3TotalByDateCommand As New SqlCommand(Tax3TotalByDateString, con)
            Tax3TotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            Tax3TotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            Tax3TotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            Tax3TotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim FreightTotalByDateString As String = "SELECT SUM(BilledFreight) FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim FreightTotalByDateCommand As New SqlCommand(FreightTotalByDateString, con)
            FreightTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            FreightTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            FreightTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            FreightTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim InvoiceTotalByDateString As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim InvoiceTotalByDateCommand As New SqlCommand(InvoiceTotalByDateString, con)
            InvoiceTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            InvoiceTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            InvoiceTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            InvoiceTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim PendingTotalByDateString As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceStatus = @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim PendingTotalByDateCommand As New SqlCommand(PendingTotalByDateString, con)
            PendingTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            PendingTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            PendingTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            PendingTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim NumberOfCustomersString As String = "SELECT COUNT(DISTINCT CustomerID) FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim NumberOfCustomersCommand As New SqlCommand(NumberOfCustomersString, con)
            NumberOfCustomersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            NumberOfCustomersCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            NumberOfCustomersCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            NumberOfCustomersCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(ProductTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                TaxTotal = CDbl(TaxTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                TaxTotal = 0
            End Try
            Try
                Tax2Total = CDbl(Tax2TotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                Tax2Total = 0
            End Try
            Try
                Tax3Total = CDbl(Tax3TotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                Tax3Total = 0
            End Try
            Try
                FreightTotal = CDbl(FreightTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                FreightTotal = 0
            End Try
            Try
                PostedTotal = CDbl(InvoiceTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                PostedTotal = 0
            End Try
            Try
                PendingTotal = CDbl(PendingTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                PendingTotal = 0
            End Try
            Try
                NumberOfCustomers = CInt(NumberOfCustomersCommand.ExecuteScalar)
            Catch ex As Exception
                NumberOfCustomers = 0
            End Try
            con.Close()

            InvoiceTotal = PostedTotal + PendingTotal
            TaxTotal = TaxTotal + Tax2Total + Tax3Total
        Else
            Dim ProductTotalByDateString As String = "SELECT SUM(ProductTotal) FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim ProductTotalByDateCommand As New SqlCommand(ProductTotalByDateString, con)
            ProductTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ProductTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            ProductTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim TaxTotalByDateString As String = "SELECT SUM(SalesTax) FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim TaxTotalByDateCommand As New SqlCommand(TaxTotalByDateString, con)
            TaxTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TaxTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TaxTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            TaxTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim Tax2TotalByDateString As String = "SELECT SUM(SalesTax2) FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim Tax2TotalByDateCommand As New SqlCommand(Tax2TotalByDateString, con)
            Tax2TotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            Tax2TotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            Tax2TotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            Tax2TotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim Tax3TotalByDateString As String = "SELECT SUM(SalesTax3) FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim Tax3TotalByDateCommand As New SqlCommand(Tax3TotalByDateString, con)
            Tax3TotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            Tax3TotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            Tax3TotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            Tax3TotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim FreightTotalByDateString As String = "SELECT SUM(BilledFreight) FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim FreightTotalByDateCommand As New SqlCommand(FreightTotalByDateString, con)
            FreightTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            FreightTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            FreightTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            FreightTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim InvoiceTotalByDateString As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim InvoiceTotalByDateCommand As New SqlCommand(InvoiceTotalByDateString, con)
            InvoiceTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            InvoiceTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            InvoiceTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            InvoiceTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            Dim PendingTotalByDateString As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND InvoiceStatus = @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim PendingTotalByDateCommand As New SqlCommand(PendingTotalByDateString, con)
            PendingTotalByDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            PendingTotalByDateCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
            PendingTotalByDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            PendingTotalByDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim NumberOfCustomersString As String = "SELECT COUNT(DISTINCT CustomerID) FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND InvoiceStatus <> @InvoiceStatus" + CustomerFilter + CustomerPOFilter + CustomerClassFilter + SOFilter + ShipFilter + StatusFilter + TerritoryFilter + TextFilter + PmtTermsFilter + DateFilter
            Dim NumberOfCustomersCommand As New SqlCommand(NumberOfCustomersString, con)
            NumberOfCustomersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            NumberOfCustomersCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            NumberOfCustomersCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            NumberOfCustomersCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(ProductTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                TaxTotal = CDbl(TaxTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                TaxTotal = 0
            End Try
            Try
                Tax2Total = CDbl(Tax2TotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                Tax2Total = 0
            End Try
            Try
                Tax3Total = CDbl(Tax3TotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                Tax3Total = 0
            End Try
            Try
                FreightTotal = CDbl(FreightTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                FreightTotal = 0
            End Try
            Try
                PostedTotal = CDbl(InvoiceTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                PostedTotal = 0
            End Try
            Try
                PendingTotal = CDbl(PendingTotalByDateCommand.ExecuteScalar)
            Catch ex As Exception
                PendingTotal = 0
            End Try
            Try
                NumberOfCustomers = CInt(NumberOfCustomersCommand.ExecuteScalar)
            Catch ex As Exception
                NumberOfCustomers = 0
            End Try
            con.Close()

            InvoiceTotal = PostedTotal + PendingTotal
            TaxTotal = TaxTotal + Tax2Total + Tax3Total
        End If

        txtTotalPending.Text = FormatCurrency(PendingTotal, 2)
        txtTotalPosted.Text = FormatCurrency(PostedTotal, 2)
        txtTotalProductSales.Text = FormatCurrency(ProductTotal, 2)
        txtTotalFreight.Text = FormatCurrency(FreightTotal, 2)
        txtTotalTax.Text = FormatCurrency(TaxTotal, 2)
        txtTotalInvoiceAmount.Text = FormatCurrency(InvoiceTotal, 2)
        txtUniqueCustomers.Text = NumberOfCustomers
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

    Public Sub LoadUploadedPickTicket()
        If Me.dgvInvoiceHeader.RowCount > 0 Then
            Dim UploadedShipmentNumber As String = ""
            Dim UploadedFileName As String = ""
            Dim UploadedFilenameAndPath As String = ""

            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex

            UploadedShipmentNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
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

    Public Sub ViewUploadedPickTicket()
        If Me.dgvInvoiceHeader.RowCount > 0 Then
            Dim UploadedShipmentNumber As String = ""
            Dim UploadedFileName As String = ""
            Dim UploadedFilenameAndPath As String = ""

            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex

            UploadedShipmentNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            UploadedFileName = UploadedShipmentNumber + ".pdf"
            UploadedFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets" + "\" + UploadedFileName

            If File.Exists(UploadedFilenameAndPath) Then
                cmdViewPickTicket.Enabled = True
            Else
                cmdViewPickTicket.Enabled = False
            End If
        Else
            'Do nothing
        End If
    End Sub

    'Clear, Validation, Error-checking, etc.

    Public Sub ClearData()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboCustomerClass.Text = ""
        cboInvoiceNumber.Text = ""
        cboShipmentNumber.Text = ""
        cboSONumber.Text = ""
        cboCustomerClass.Text = ""
        cboStatus.Text = ""
        cboCustomerTerritory.Text = ""
        cboPaymentTerms.Text = ""

        cboCustomerTerritory.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboCustomerClass.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1
        cboSONumber.SelectedIndex = -1
        cboCustomerClass.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        txtCustomerPO.Clear()
        txtTotalFreight.Clear()
        txtTotalInvoiceAmount.Clear()
        txtTotalProductSales.Clear()
        txtTotalTax.Clear()
        txtUniqueCustomers.Clear()
        txtTotalPending.Clear()
        txtTotalPosted.Clear()
        txtTextFilter.Clear()

        chkDateRange.Checked = False

        cboSONumber.Focus()
    End Sub

    Public Sub ClearVariables()
        ShipmentNumber = 0
        SalesOrderNumber = 0
        strShipmentNumber = ""
        strSONumber = ""
        SOFilter = ""
        CustomerFilter = ""
        TextFilter = ""
        ShipFilter = ""
        DateFilter = ""
        CustomerPOFilter = ""
        StatusFilter = ""
        CustomerClassFilter = ""
        TerritoryFilter = ""
        PmtTermsFilter = ""
        SpecialInstructions = ""
        ProductTotal = 0
        TaxTotal = 0
        Tax2Total = 0
        Tax3Total = 0
        InvoiceTotal = 0
        FreightTotal = 0
        PostedTotal = 0
        PendingTotal = 0
        NumberOfCustomers = 0
    End Sub

    Public Sub LoadFormatting()
        Dim InvoiceStatus As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvInvoiceHeader.Rows
            Try
                InvoiceStatus = row.Cells("InvoiceStatusColumn").Value
            Catch ex As System.Exception
                InvoiceStatus = ""
            End Try

            If InvoiceStatus = "OPEN" Then
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf InvoiceStatus = "CLOSED" Then
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
            ElseIf InvoiceStatus = "PENDING" Then
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Red
            ElseIf InvoiceStatus = "BILL ONLY" Then
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Green
            Else
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    'Command Buttons

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
        LoadProductTotalByFilter()
    End Sub

    Private Sub cmdInvoiceForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInvoiceForm.Click
        If cboInvoiceNumber.Text = "" Then
            Dim LineInvoiceNumber, LineShipmentNumber, LineSONumber As Integer
            Dim RowDivision, RowCustomer As String

            If Me.dgvInvoiceHeader.RowCount <> 0 Then
                Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex

                LineInvoiceNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
                LineShipmentNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
                LineSONumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
                RowDivision = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value
                RowCustomer = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("CustomerIDColumn").Value

                'Get Invoice Email Address
                Dim EmailAddressStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim EmailAddressCommand As New SqlCommand(EmailAddressStatement, con)
                EmailAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                EmailAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    EmailAddress = CStr(EmailAddressCommand.ExecuteScalar)
                Catch ex As Exception
                    EmailAddress = ""
                End Try
                con.Close()

                GlobalInvoiceNumber = LineInvoiceNumber
                SalesOrderNumber = LineSONumber
                ShipmentNumber = LineShipmentNumber
                GlobalDivisionCode = RowDivision

                'Choose the Invoice Print Form by division
                If ShipmentNumber = 0 Or SalesOrderNumber = 0 Then
                    'Get sring Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = RowCustomer
                    EmailCustomerEmailAddress = EmailAddress
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)

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
                    'Get sring Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = RowCustomer
                    EmailCustomerEmailAddress = EmailAddress
                    EmailStringInvoiceNumber = GlobalInvoiceNumber

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
            Else
                'Do nothing
            End If
        Else
            'Get Division Code for selected Invoice if combobox is ADM
            Dim CurrentDivisionCode As String = ""
            Dim InvoiceCustomer, CustomerEmail As String

            If cboDivisionID.Text = "ADM" Then
                Dim CurrentDivisionCodeStatement As String = "SELECT DivisionID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                Dim CurrentDivisionCodeCommand As New SqlCommand(CurrentDivisionCodeStatement, con)
                CurrentDivisionCodeCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CurrentDivisionCode = CStr(CurrentDivisionCodeCommand.ExecuteScalar)
                Catch ex As Exception
                    CurrentDivisionCode = ""
                End Try
                con.Close()
            Else
                CurrentDivisionCode = cboDivisionID.Text
            End If

            'Check to see if it is Standard or Bill Only
            Dim ShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)
            ShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            ShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            Dim SalesOrderNumberStatement As String = "SELECT SalesOrderNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim SalesOrderNumberCommand As New SqlCommand(SalesOrderNumberStatement, con)
            SalesOrderNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SalesOrderNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            Dim SpecialInstructionsStatement As String = "SELECT SpecialInstructions FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim SpecialInstructionsCommand As New SqlCommand(SpecialInstructionsStatement, con)
            SpecialInstructionsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SpecialInstructionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            Dim InvoiceCustomerStatement As String = "SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim InvoiceCustomerCommand As New SqlCommand(InvoiceCustomerStatement, con)
            InvoiceCustomerCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            InvoiceCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                ShipmentNumber = 0
            End Try
            Try
                SalesOrderNumber = CInt(SalesOrderNumberCommand.ExecuteScalar)
            Catch ex As Exception
                SalesOrderNumber = 0
            End Try
            Try
                SpecialInstructions = CStr(SpecialInstructionsCommand.ExecuteScalar)
            Catch ex As Exception
                SpecialInstructions = "STANDARD"
            End Try
            Try
                InvoiceCustomer = CStr(InvoiceCustomerCommand.ExecuteScalar)
            Catch ex As Exception
                InvoiceCustomer = ""
            End Try
            con.Close()

            Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
            CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = InvoiceCustomer
            CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerEmail = ""
            End Try
            con.Close()

            'Choose the Invoice Print Form by division
            If ShipmentNumber = 0 Or SalesOrderNumber = 0 Then
                GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                GlobalDivisionCode = CurrentDivisionCode
                'Get sring Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = InvoiceCustomer
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
                GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                GlobalDivisionCode = CurrentDivisionCode
                'Get sring Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = InvoiceCustomer
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
        End If
    End Sub

    Private Sub cmdPrintGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintGrid.Click
        GDS = ds

        Using NewPrintInvoiceListDatagrid As New PrintInvoiceListDatagrid
            Dim result = NewPrintInvoiceListDatagrid.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintMultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintMultiple.Click
        Dim ReprintBatchNumber As String
        Dim SelectedInvoice As Integer

        'Get Temp Batch Number to write to Invoice Header table
        'Create new Filename for Temp Batch
        FileDate = Now()
        monthofyear = FileDate.Month
        dayofyear = FileDate.DayOfYear
        yearofyear = FileDate.Year
        minuteofyear = FileDate.Minute
        strMonth = CStr(monthofyear)
        strDay = CStr(dayofyear)
        strYear = CStr(yearofyear)
        strMinute = CStr(minuteofyear)
        strCompany = cboDivisionID.Text

        ReprintBatchNumber = strCompany + strMonth + strDay + strYear + strMinute

        Try
            'Clear Old Temp Batch Numbers
            cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ReprintBatch = @ReprintBatch WHERE ReprintBatch = @ReprintBatch1 AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                .Add("@ReprintBatch1", SqlDbType.VarChar).Value = ReprintBatchNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip - none cleared
        End Try

        For Each row As DataGridViewRow In Me.dgvInvoiceHeader.SelectedRows
            Try
                SelectedInvoice = row.Cells("InvoiceNumberColumn").Value
            Catch ex As Exception
                SelectedInvoice = 0
            End Try

            'Write Data to Invoice Header Database Table
            cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ReprintBatch = @ReprintBatch WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = SelectedInvoice
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ReprintBatch", SqlDbType.VarChar).Value = ReprintBatchNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next

        GlobalReprintInvoiceBatch = ReprintBatchNumber
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
            Using NewReprintInvoiceBatchRemote As New ReprintInvoiceBatchRemote
                Dim Result = NewReprintInvoiceBatchRemote.ShowDialog
            End Using
        Else
            Using NewReprintInvoiceBatch As New ReprintInvoiceBatch
                Dim Result = NewReprintInvoiceBatch.ShowDialog
            End Using
        End If
    End Sub

    Private Sub cmdEmailWithCerts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmailWithCerts.Click
        If cboInvoiceNumber.Text = "" Then
            Dim LineInvoiceNumber, LineShipmentNumber, LineSONumber As Integer
            Dim RowDivision, RowCustomer As String

            If Me.dgvInvoiceHeader.RowCount <> 0 Then
                Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex

                LineInvoiceNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
                LineShipmentNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
                LineSONumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
                RowDivision = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value
                RowCustomer = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("CustomerIDColumn").Value

                'Get Invoice Email Address
                Dim EmailAddressStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim EmailAddressCommand As New SqlCommand(EmailAddressStatement, con)
                EmailAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                EmailAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    EmailAddress = CStr(EmailAddressCommand.ExecuteScalar)
                Catch ex As Exception
                    EmailAddress = ""
                End Try
                con.Close()

                EmailInvoiceNumber = LineInvoiceNumber
                EmailSalesOrderNumber = LineSONumber
                EmailShipmentNumber = LineShipmentNumber
                EmailInvoiceCustomer = RowCustomer
                GlobalDivisionCode = RowDivision
                EmailCustomerEmailAddress = EmailAddress

                Dim CheckForNoCerts As Integer = 0

                'Check to see if there are any certs that will not print
                Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
                Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
                CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = LineShipmentNumber
                CheckForNoCertsCommand.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = "NO CERT"

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader3 As SqlDataReader = CheckForNoCertsCommand.ExecuteReader()
                If reader3.HasRows Then
                    reader3.Read()
                    If IsDBNull(reader3.Item("CountNoCerts")) Then
                        CheckForNoCerts = 0
                    Else
                        CheckForNoCerts = reader3.Item("CountNoCerts")
                    End If
                Else
                    CheckForNoCerts = 0
                End If
                reader3.Close()
                con.Close()

                If CheckForNoCerts = 0 Then
                    'Set Global Variable to NO
                    GlobalPrintNoCertPage = "NO"
                Else
                    'Set Global Variable to YES
                    GlobalPrintNoCertPage = "YES"
                End If

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
                    Using NewEmailAllInvoiceDocsRemote As New EmailAllInvoiceDocsRemote
                        Dim Result = NewEmailAllInvoiceDocsRemote.ShowDialog()
                    End Using
                Else
                    Using NewEmailAllInvoiceDocs As New EmailAllInvoiceDocs
                        Dim Result = NewEmailAllInvoiceDocs.ShowDialog()
                    End Using
                End If
            Else
                'Do nothing
            End If
        Else
            'Get Division Code for selected Invoice if combobox is ADM
            Dim CurrentDivisionCode As String = ""
            Dim InvoiceCustomer, CustomerEmail As String

            If cboDivisionID.Text = "ADM" Then
                Dim CurrentDivisionCodeStatement As String = "SELECT DivisionID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                Dim CurrentDivisionCodeCommand As New SqlCommand(CurrentDivisionCodeStatement, con)
                CurrentDivisionCodeCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CurrentDivisionCode = CStr(CurrentDivisionCodeCommand.ExecuteScalar)
                Catch ex As Exception
                    CurrentDivisionCode = ""
                End Try
                con.Close()
            Else
                CurrentDivisionCode = cboDivisionID.Text
            End If

            'Check to see if it is Standard or Bill Only
            Dim ShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)
            ShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            ShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            Dim SalesOrderNumberStatement As String = "SELECT SalesOrderNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim SalesOrderNumberCommand As New SqlCommand(SalesOrderNumberStatement, con)
            SalesOrderNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SalesOrderNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            Dim SpecialInstructionsStatement As String = "SELECT SpecialInstructions FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim SpecialInstructionsCommand As New SqlCommand(SpecialInstructionsStatement, con)
            SpecialInstructionsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SpecialInstructionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            Dim InvoiceCustomerStatement As String = "SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim InvoiceCustomerCommand As New SqlCommand(InvoiceCustomerStatement, con)
            InvoiceCustomerCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            InvoiceCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                ShipmentNumber = 0
            End Try
            Try
                SalesOrderNumber = CInt(SalesOrderNumberCommand.ExecuteScalar)
            Catch ex As Exception
                SalesOrderNumber = 0
            End Try
            Try
                SpecialInstructions = CStr(SpecialInstructionsCommand.ExecuteScalar)
            Catch ex As Exception
                SpecialInstructions = "STANDARD"
            End Try
            Try
                InvoiceCustomer = CStr(InvoiceCustomerCommand.ExecuteScalar)
            Catch ex As Exception
                InvoiceCustomer = ""
            End Try
            con.Close()

            Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
            CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = InvoiceCustomer
            CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerEmail = ""
            End Try
            con.Close()

            EmailInvoiceNumber = Val(cboInvoiceNumber.Text)
            EmailInvoiceCustomer = InvoiceCustomer
            EmailSalesOrderNumber = SalesOrderNumber
            EmailShipmentNumber = ShipmentNumber
            GlobalDivisionCode = CurrentDivisionCode
            EmailCustomerEmailAddress = CustomerEmail

            Dim CheckForNoCerts As Integer = 0

            'Check to see if there are any certs that will not print
            Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
            Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
            CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
            CheckForNoCertsCommand.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = "NO CERT"

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader3 As SqlDataReader = CheckForNoCertsCommand.ExecuteReader()
            If reader3.HasRows Then
                reader3.Read()
                If IsDBNull(reader3.Item("CountNoCerts")) Then
                    CheckForNoCerts = 0
                Else
                    CheckForNoCerts = reader3.Item("CountNoCerts")
                End If
            Else
                CheckForNoCerts = 0
            End If
            reader3.Close()
            con.Close()

            If CheckForNoCerts = 0 Then
                'Set Global Variable to NO
                GlobalPrintNoCertPage = "NO"
            Else
                'Set Global Variable to YES
                GlobalPrintNoCertPage = "YES"
            End If

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
                Using NewEmailAllInvoiceDocsRemote As New EmailAllInvoiceDocsRemote
                    Dim Result = NewEmailAllInvoiceDocsRemote.ShowDialog()
                End Using
            Else
                Using NewEmailAllInvoiceDocs As New EmailAllInvoiceDocs
                    Dim Result = NewEmailAllInvoiceDocs.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdOpenInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenInvoice.Click
        If Me.dgvInvoiceHeader.RowCount <> 0 Then
            Dim RowInvoiceNumber As Integer = 0
            Dim RowStatus As String = ""
            Dim RowDivision As String = ""

            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex

            RowInvoiceNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            RowStatus = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceStatusColumn").Value
            RowDivision = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value

            If RowStatus = "OPEN" Then
                MsgBox("Invoice is already open.", MsgBoxStyle.OkOnly)
            ElseIf RowStatus = "PENDING" Then
                MsgBox("Invoice is pending and cannot be re-opened.", MsgBoxStyle.OkOnly)
            Else
                'UPDATE Invoice Header Table
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'UPDATE Invoice Line Table
                cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = RowInvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Invoice has been re-opened.", MsgBoxStyle.OkOnly)
                ShowDataByFilters()
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdCloseInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseInvoice.Click
        If Me.dgvInvoiceHeader.RowCount <> 0 Then
            Dim RowInvoiceNumber As Integer = 0
            Dim RowStatus As String = ""
            Dim RowDivision As String = ""

            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex

            RowInvoiceNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            RowStatus = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceStatusColumn").Value
            RowDivision = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value

            If RowStatus = "CLOSED" Then
                MsgBox("Invoice is already closed.", MsgBoxStyle.OkOnly)
            ElseIf RowStatus = "PENDING" Then
                MsgBox("Invoice is pending and cannot be closed.", MsgBoxStyle.OkOnly)
            Else
                'UPDATE Invoice Header Table
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'UPDATE Invoice Line Table
                cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = RowInvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Invoice has been closed.", MsgBoxStyle.OkOnly)
                ShowDataByFilters()
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdViewPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPickTicket.Click
        If Me.dgvInvoiceHeader.RowCount > 0 Then
            LoadUploadedPickTicket()
        End If
    End Sub

    Private Sub cmdAutoEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoEmail.Click
        Dim SelectedInvoice As Integer = 0
        Dim strSelectedInvoice As String = ""
        Dim SelectedCustomer As String = ""
        Dim CustomerInvoiceEmail As String = ""
        Dim NumberOfInvoices As Integer = 0
        Dim SelectedDivision As String = ""
        Dim InvoiceFileName As String = ""

        If Me.dgvInvoiceHeader.RowCount = 0 Then
            Exit Sub
        End If

        'Selected highlighted datagrid rows to get invoice and auto-email
        For Each row As DataGridViewRow In Me.dgvInvoiceHeader.SelectedRows
            Try
                SelectedInvoice = row.Cells("InvoiceNumberColumn").Value
            Catch ex As Exception
                SelectedInvoice = 0
            End Try
            Try
                SelectedCustomer = row.Cells("CustomerIDColumn").Value
            Catch ex As Exception
                SelectedCustomer = ""
            End Try
            Try
                SelectedDivision = row.Cells("DivisionIDColumn").Value
            Catch ex As Exception
                SelectedDivision = ""
            End Try

            'Create Invoice File Name
            strSelectedInvoice = Str(SelectedInvoice)
            InvoiceFileName = SelectedDivision + strSelectedInvoice + "'pdf"

            'Check to see if customer has an email address to send emails to
            Dim CustomerInvoiceEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
            Dim CustomerInvoiceEmailCommand As New SqlCommand(CustomerInvoiceEmailStatement, con)
            CustomerInvoiceEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = SelectedDivision
            CustomerInvoiceEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = SelectedCustomer

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerInvoiceEmail = CStr(CustomerInvoiceEmailCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerInvoiceEmail = ""
            End Try
            con.Close()

            If CustomerInvoiceEmail = "" Then
                'Skip
            Else
                'Create the Invoices into pdfs (if needed)
                'Loads data into dataset for viewing
                cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = SelectedInvoice

                cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
                cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = SelectedDivision
                cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = SelectedInvoice

                cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
                cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = SelectedDivision

                cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = SelectedDivision

                cmd5 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = SelectedDivision

                cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
                cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = SelectedDivision

                cmd8 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = SelectedDivision

                cmd9 = New SqlCommand("SELECT * FROM InvoiceLotLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
                cmd9.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = SelectedInvoice

                cmd10 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
                cmd10.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = SelectedInvoice

                cmd11 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionID", con)
                cmd11.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = SelectedDivision

                If con.State = ConnectionState.Closed Then con.Open()
                tempDS = New DataSet()

                myAdapter.SelectCommand = cmd
                myAdapter.Fill(tempDS, "InvoiceHeaderTable")

                myAdapter1.SelectCommand = cmd1
                myAdapter1.Fill(tempDS, "InvoiceLineQuery")

                myAdapter2.SelectCommand = cmd2
                myAdapter2.Fill(tempDS, "ShipmentHeaderTable")

                myAdapter4.SelectCommand = cmd4
                myAdapter4.Fill(tempDS, "DivisionTable")

                myAdapter5.SelectCommand = cmd5
                myAdapter5.Fill(tempDS, "CustomerList")

                myAdapter6.SelectCommand = cmd6
                myAdapter6.Fill(tempDS, "AdditionalShipTo")

                myAdapter8.SelectCommand = cmd8
                myAdapter8.Fill(tempDS, "ARCustomerPayment")

                myAdapter9.SelectCommand = cmd9
                myAdapter9.Fill(tempDS, "InvoiceLotLineTable")

                myAdapter10.SelectCommand = cmd10
                myAdapter10.Fill(tempDS, "InvoiceSerialLineTable")

                myAdapter11.SelectCommand = cmd11
                myAdapter11.Fill(tempDS, "SalesOrderHeaderTable")

                'Sets up viewer to display data from the loaded dataset
                If SelectedDivision = "TWD" Then
                    MyReport = CRXInvoice1
                    MyReport.SetDataSource(tempDS)
                    CRInvoiceViewer.ReportSource = MyReport
                    MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & InvoiceFileName)
                    con.Close()
                ElseIf SelectedDivision = "TFF" Then
                    MyReport = CRXInvoiceTFF1
                    MyReport.SetDataSource(tempDS)
                    CRInvoiceViewer.ReportSource = MyReport
                    MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & InvoiceFileName)
                    con.Close()
                ElseIf SelectedDivision = "TOR" Then
                    MyReport = CRXInvoiceTFF1
                    MyReport.SetDataSource(tempDS)
                    CRInvoiceViewer.ReportSource = MyReport
                    MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & InvoiceFileName)
                    con.Close()
                ElseIf SelectedDivision = "ALB" Then
                    MyReport = CRXInvoiceTFF1
                    MyReport.SetDataSource(tempDS)
                    CRInvoiceViewer.ReportSource = MyReport
                    MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & InvoiceFileName)
                    con.Close()
                Else
                    MyReport = CRXInvoice1
                    MyReport.SetDataSource(tempDS)
                    CRInvoiceViewer.ReportSource = MyReport
                    MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & InvoiceFileName)
                    con.Close()
                End If
            End If
        Next
    End Sub

    Private Sub cmdRemoteScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoteScan.Click
        Dim PickTicketFilename As String = ""
        Dim PickTicketFilenameAndPath As String = ""
        Dim strPickTicketNumber As String = ""
        Dim PickTicketNumber As Integer = 0
        Dim LineShipmentNumber As Integer = 0

        'Scanning Program
        Dim My_Process As New Process()

        Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
        LineShipmentNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value

        'Verify that they have a PickTicket selected
        If LineShipmentNumber = 0 Then
            MsgBox("You must select an invoice with a shipment.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            PickTicketNumber = LineShipmentNumber
            strPickTicketNumber = CStr(PickTicketNumber)
        End If

        PickTicketFilename = strPickTicketNumber + ".pdf"
        PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

        If File.Exists(PickTicketFilenameAndPath) Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned Pick Ticket?", "OVERWRITE EXISTING PICK TICKET?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete existing PickTicket before upload
                File.Delete(PickTicketFilenameAndPath)

                Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                strPickTicketNumber = CStr(cboShipmentNumber.Text)

                PickTicketFilename = strPickTicketNumber + ".pdf"
                PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

                'My_Process_Info.UseShellExecute = False
                'My_Process_Info.RedirectStandardOutput = True
                'My_Process_Info.RedirectStandardError = True
                'My_Process_Info.CreateNoWindow = True

                Try
                    My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                    'My_Process.WaitForExit()
                    My_Process.Close()

                    cboShipmentNumber.Refresh()
                    LoadUploadedPickTicket()
                    cboShipmentNumber.Text = PickTicketNumber
                    cmdRemoteScan.Visible = True
                    cmdViewPickTicket.Visible = True
                    cmdViewPickTicket.Enabled = True

                    MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempPickTicketNumber As Integer = 0
                    Dim strPickTicketNumber1 As String = ""
                    TempPickTicketNumber = Val(cboShipmentNumber.Text)
                    strPickTicketNumber1 = CStr(TempPickTicketNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ApplicationFileAndPath & "" & PickTicketFilenameAndPath
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View Invoice Listing --- Upload Pick Ticket"
                    ErrorReferenceNumber = "PickTicket # " + strPickTicketNumber1
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MsgBox("Scan failed", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"

            strPickTicketNumber = CStr(cboShipmentNumber.Text)

            PickTicketFilename = strPickTicketNumber + ".pdf"
            PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

            'My_Process_Info.UseShellExecute = False
            'My_Process_Info.RedirectStandardOutput = True
            'My_Process_Info.RedirectStandardError = True
            'My_Process_Info.CreateNoWindow = True

            Try
                My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()

                cboShipmentNumber.Refresh()
                LoadUploadedPickTicket()
                cboShipmentNumber.Text = PickTicketNumber
                cmdRemoteScan.Visible = True
                cmdViewPickTicket.Visible = True
                cmdViewPickTicket.Enabled = True

                MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                '    'Log error on update failure
                Dim TempPickTicketNumber As Integer = 0
                Dim strPickTicketNumber1 As String = ""
                TempPickTicketNumber = Val(cboShipmentNumber.Text)
                strPickTicketNumber1 = CStr(TempPickTicketNumber)

                ErrorDate = TodaysDate
                ErrorComment = ApplicationFileAndPath & "" & PickTicketFilenameAndPath
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "View Invoice Listing --- Upload Pick Ticket"
                ErrorReferenceNumber = "Pick Ticket # " + strPickTicketNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan failed", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub cmdAppendUploadPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAppendPickTicket.Click
        If Me.dgvInvoiceHeader.SelectedRows.Count <> 0 And Me.dgvInvoiceHeader.SelectedRows.Count < 2 Then

            Dim name1, name2, final1 As String
            Dim remoteScan As Boolean = False
            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
            Dim shipmentNumber As String = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value.ToString



            Dim PickTicketExists As String = "\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNumber + ".pdf"
            If File.Exists(PickTicketExists) Then
                If canSave() Then

                    ' Deletes the WIA testing temp file
                    Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                    ' Creates the folder if the temp folder is not currently created
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")

                    path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                    'If there had been a previous scan then delete the picture from the picturebox
                    GlobalVariables.Counter = 0
                    Dim mgr As New WIA.DeviceManagerClass
                    Dim Scanner As WIA.Device = Nothing
                    If mgr.DeviceInfos.Count > 1 Then
                        ''More than 1 scanner was detected
                        Dim lst As New List(Of Integer)
                        ''Finds all the USB scanners
                        For i As Integer = 1 To mgr.DeviceInfos.Count()
                            If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                                lst.Add(i)
                            End If
                        Next
                        ''Check to see how many usb scanners were found
                        If lst.Count > 1 Or lst.Count = 0 Then
                            Dim selectScanner As New WIA.CommonDialog
                            Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                        Else
                            Scanner = mgr.DeviceInfos(lst(0)).Connect()
                        End If
                    ElseIf mgr.DeviceInfos.Count = 0 Then
                        ''No scanners were detected
                        If My.Computer.Name.ToString.StartsWith("TFP") Then
                            Dim loadingScreen As New Loading



                            bgwkRemoteWIA = New BackgroundWorker()
                            bgwkRemoteWIA.WorkerReportsProgress = True
                            AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                            AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_CompletedAppend
                            AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                            remoteScan = True

                            remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, shipmentNumber)
                            bgwkRemoteWIA.RunWorkerAsync()

                            loadingScreen.Close()
                        Else
                            ''No scanners were detected
                            MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        ''Only 1 scanner is connected
                        Scanner = mgr.DeviceInfos(1).Connect()
                    End If
                    If Scanner IsNot Nothing Then
                        Dim item As WIA.Item = Scanner.Items(1)
                        Dim obj As Object
                        Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                        ''Specific scanning properties
                        For Each prop As WIA.Property In Scanner.Items(1).Properties
                            Dim x As WIA.IProperty = prop
                            Select Case prop.PropertyID
                                Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                                    obj = 0
                                    x.let_Value(obj)
                                Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                                    obj = 2
                                    x.let_Value(obj)
                                Case "6147" ''(DPI) Horizontal Resolution
                                    obj = 200
                                    x.let_Value(obj)
                                Case "6148" ''(DPI) Vertical Resolution
                                    obj = 200
                                    x.let_Value(obj)
                                Case "6151" ''horizontal extent (width)
                                    obj = 1700
                                    x.let_Value(obj)
                                Case "6152" ''vertical extent (height)
                                    obj = 2338
                                    x.let_Value(obj)
                            End Select
                        Next

                        Dim dial As New WIA.CommonDialog
                        Dim hasMorePages As Boolean = True
                        Dim ScannedAtleastOnePage As Boolean = False
                        Dim pages As Integer = 0
                        Dim ScannedImages As New List(Of iTextSharp.text.Image)
                        If remoteScan = False Then
                            ''Loops until all pages are scanned.
                            While hasMorePages
                                GlobalVariables.Counter = GlobalVariables.Counter + 1
                                pages += 1
                                Try
                                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                                    Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                                    Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                                    Img.SaveFile(tmp)
                                    'ScannedImages.Add(Img.fromfile(tmp))
                                    ScannedAtleastOnePage = True


                                Catch ex As System.Exception
                                    ''Looks for paper empty error to break the loop and/or to show error message
                                    If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                                        If Not ScannedAtleastOnePage Then
                                            MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            GlobalVariables.paperscan = False
                                        Else
                                            GlobalVariables.paperscan = True
                                        End If
                                        hasMorePages = False
                                    End If
                                End Try
                            End While
                        End If
                        'Displays the first saved scan into the picturebox
                        If GlobalVariables.paperscan Then
                            GlobalVariables.StartCounter = 1
                            Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                            GlobalVariables.NextPrevious = GlobalVariables.StartCounter

                        End If
                    End If
                    'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
                    GlobalVariables.previousScan = True
                    GlobalVariables.NextPrevious = 1


                    Dim extensions As New List(Of String)
                    extensions.Add("*.bmp")
                    Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                    'counts the files in the folder
                    Dim fileCount As Integer
                    For i As Integer = 0 To extensions.Count - 1
                        fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
                    Next
                    GlobalVariables.totalfiles = fileCount




                End If
                If remoteScan = False Then
                    Try

                        'Variables Declared
                        Dim comboboxSelection As String = shipmentNumber

                        Dim strDir As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\"
                        If Not System.IO.Directory.Exists(strDir) Then System.IO.Directory.CreateDirectory(strDir)

                        'Name of file

                        Dim strFilename As String = "Appended2.pdf"
                        'path to bmp
                        Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                        Dim strCompletePath As String = strDir & strFilename
                        Dim pdfDoc As New document()
                        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
                        pdfDoc.Open()
                        'Grabs the bmp image seen on screen
                        Dim img As iTextSharp.text.Image = GetInstance(strPathname)
                        'structures it to fit on pdf file
                        img.ScalePercent(72.0F / img.DpiX * 100)
                        img.SetAbsolutePosition(0, 0)
                        'adds image to the document
                        pdfDoc.Add(img)
                        'closes the pdf and saves it
                        pdfDoc.Close()

                        'messagebox confirmation on saving
                        MessageBox.Show("Save Confirmation", "Saved Cash Receipt PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        'declares list of bmp files to be counted
                        Dim extensions As New List(Of String)
                        extensions.Add("*.bmp")
                        Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                        GlobalVariables.previousScan = True


                        Dim initial As String = "\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNumber + ".pdf"
                        Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                        My.Computer.FileSystem.MoveFile(initial, final)
                        final1 = "\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNumber + ".pdf"
                        name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                        name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"

                        Dim bytecount3 As Integer = 0
                        bytecount3 = FileLen(name1)
                        If bytecount3 = 15 Then
                            My.Computer.FileSystem.DeleteFile(name1)
                            MsgBox("Scanning Error, Initial File Not Valid, Please Re-Upload File")
                            Exit Sub
                        End If

                        Dim bytecount2 As Integer = 0
                        bytecount2 = FileLen(name2)
                        If bytecount2 = 15 Then
                            My.Computer.FileSystem.DeleteFile(name2)
                            MsgBox("Scanning Error, Appended File Not Valid, Please Re-Upload File")
                            My.Computer.FileSystem.MoveFile(final, initial)
                            Exit Sub
                        End If

                        Dim pathArray = New String() {name1, name2}
                        Try
                            MergePdfFiles(pathArray, final1)
                            MsgBox("File Appended")
                        Catch ex As Exception
                            MsgBox("File Not Appended")
                        End Try

                    Catch ex As TargetInvocationException
                        'We only catch this one, so you can catch other exception later on
                        'We get the inner exception because ex is not helpfull
                        Dim iEX = ex.InnerException
                    Catch ex As Exception

                    End Try
                End If
            Else
                MsgBox("No Initial Upload")
            End If

            Dim CashReceiptExists As String = "\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNumber + ".pdf"
            'Sets buttons to see if pdf is viewable

            Dim bytecount As Integer = 0
            bytecount = FileLen("\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNumber + ".pdf")
            If bytecount = 15 Then
                My.Computer.FileSystem.DeleteFile("\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNumber + ".pdf")
                MsgBox("Scanning Error, Please ReUpload File")
            End If
        Else
            MsgBox("Please Select A Single Row then try again.")
        End If
    End Sub

    'Tool Strip Menu Items

    Private Sub ReprintInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprintInvoiceToolStripMenuItem.Click
        cmdInvoiceForm_Click(sender, e)
    End Sub

    Private Sub PrintSalesByWeekToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSalesByWeekToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintSalesByDayOfWeek As New PrintSalesByDayOfWeek
            Dim Result = NewPrintSalesByDayOfWeek.ShowDialog()
        End Using
    End Sub

    Private Sub PrintInvoiceGLPostingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoiceGLPostingsToolStripMenuItem.Click
        GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintInvoiceGLPostings As New PrintInvoiceGLPostings
            Dim Result = NewPrintInvoiceGLPostings.ShowDialog()
        End Using
    End Sub

    Private Sub PrintInvoiceListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoiceListingToolStripMenuItem.Click
        cmdPrintGrid_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintInvoiceDiscrepancyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoiceDiscrepancyReportToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalInvoiceReports = "INVOICE DISCREPANCY"

        Using NewPrintInvoiceDiscrepancyReport As New PrintInvoiceDiscrepancyReport
            Dim Result = NewPrintInvoiceDiscrepancyReport.ShowDialog()
        End Using
    End Sub

    Private Sub PrintInvoicePaymentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoicePaymentReportToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalInvoiceReports = "COMPARE INVOICE PAYMENTS"

        Using NewPrintInvoiceDiscrepancyReport As New PrintInvoiceDiscrepancyReport
            Dim Result = NewPrintInvoiceDiscrepancyReport.ShowDialog()
        End Using
    End Sub

    'Datagridview Events

    Private Sub dgvInvoiceHeader_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvInvoiceHeader.CellDoubleClick
        Dim RowInvoiceNumber, RowSONumber, RowShipmentNumber As Integer
        Dim RowDivision, RowCustomer, CustomerEmail As String

        Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
        RowSONumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
        RowShipmentNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowDivision = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value
        RowCustomer = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("CustomerIDColumn").Value

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

    Private Sub dgvInvoiceHeader_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceHeader.CellValueChanged
        Dim LineInvoiceNumber, LineShipmentNumber As Integer
        Dim RowDivision, LineReprintBatchNumber, LineCustomerPO, LineComment, LineInstructions, LineShipVia, LinePRONumber As String

        If Me.dgvInvoiceHeader.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex

            LineInvoiceNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            LineCustomerPO = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("CustomerPOColumn").Value
            LineInstructions = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("SpecialInstructionsColumn").Value
            LineComment = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("CommentColumn").Value
            LineShipVia = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipViaColumn").Value
            LinePRONumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("PRONumberColumn").Value
            RowDivision = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value
            LineShipmentNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            LineReprintBatchNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ReprintBatchColumn").Value

            Try
                'UPDATE Invoice Header Table
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET CustomerPO = @CustomerPO, Comment = @Comment, SpecialInstructions = @SpecialInstructions, ShipVia = @ShipVia, PRONumber = @PRONumber, ReprintBatch = @ReprintBatch WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = LineInvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = LineCustomerPO
                    .Add("@Comment", SqlDbType.VarChar).Value = LineComment
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = LineInstructions
                    .Add("@ShipVia", SqlDbType.VarChar).Value = LineShipVia
                    .Add("@PRONumber", SqlDbType.VarChar).Value = LinePRONumber
                    .Add("@ReprintBatch", SqlDbType.VarChar).Value = LineReprintBatchNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try

            If LinePRONumber <> "" Or LineShipmentNumber <> 0 Then
                Try
                    'Update Shipment Table with the PRO#
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET PRONumber = @PRONumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = LineShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@PRONumber", SqlDbType.VarChar).Value = LinePRONumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Do nothing
                End Try
            End If
        Else
            'Skip
        End If
    End Sub

    Private Sub dgvInvoiceHeader_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInvoiceHeader.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub dgvInvoiceHeader_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInvoiceHeader.RowHeaderMouseClick
        If Me.dgvInvoiceHeader.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
            Dim RowDivision As String = ""
            Dim LineInvoiceNumber As Integer = 0

            LineInvoiceNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            RowDivision = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value

            If RowDivision = cboDivisionID.Text And cboDivisionID.Text <> "ADM" Then
                cboInvoiceNumber.Text = LineInvoiceNumber
            ElseIf RowDivision <> cboDivisionID.Text And cboDivisionID.Text = "ADM" Then
                cboInvoiceNumber.Text = LineInvoiceNumber
            Else
                'Do nothing
            End If

            ViewUploadedPickTicket()
        End If
    End Sub

    Private Sub dgvInvoiceHeader_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceHeader.CellClick
        If Me.dgvInvoiceHeader.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
            Dim RowDivision As String = ""
            Dim LineInvoiceNumber As Integer = 0
            Dim ShipmentNumber As Integer = 0
            LineInvoiceNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            RowDivision = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("DivisionIDColumn").Value
            ShipmentNumber = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value

            If RowDivision = cboDivisionID.Text And cboDivisionID.Text <> "ADM" Then
                cboInvoiceNumber.Text = LineInvoiceNumber
            ElseIf RowDivision <> cboDivisionID.Text And cboDivisionID.Text = "ADM" Then
                cboInvoiceNumber.Text = LineInvoiceNumber
            Else
                'Do nothing
            End If

            ViewUploadedPickTicket()
        End If
    End Sub

    'Combobox Events

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        If IsLoaded = True Then
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                dgvInvoiceHeader.Columns("SalesTaxColumn").Visible = True
                dgvInvoiceHeader.Columns("SalesTax2Column").Visible = True
                dgvInvoiceHeader.Columns("SalesTax3Column").Visible = True
                dgvInvoiceHeader.Columns("SalesTaxColumn").HeaderText = "GST"
                dgvInvoiceHeader.Columns("SalesTax2Column").HeaderText = "PST"
                dgvInvoiceHeader.Columns("SalesTax3Column").HeaderText = "HST"
            Else
                dgvInvoiceHeader.Columns("SalesTaxColumn").Visible = True
                dgvInvoiceHeader.Columns("SalesTax2Column").Visible = False
                dgvInvoiceHeader.Columns("SalesTax3Column").Visible = False
                dgvInvoiceHeader.Columns("SalesTaxColumn").HeaderText = "Sales Tax"
            End If

            If cboDivisionID.Text = "ADM" Then
                cmdPrintMultiple.Enabled = False
            ElseIf cboDivisionID.Text = "" Then
                'Do nothing
            Else
                cmdPrintMultiple.Enabled = True
                LoadSONumber()
                LoadCustomer()
                LoadCustomerName()
                LoadShipmentNumber()
                LoadInvoiceNumber()
                LoadSalesTerritory()
            End If
        End If
    End Sub

    Private Sub cboCustomerID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomerID.GotFocus
        If cboDivisionID.Text = "ADM" Then
            LoadCustomer()
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If IsLoaded = True Then
            LoadCustomerNameByID()
        End If
    End Sub

    Private Sub cboCustomerName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomerName.GotFocus
        If cboDivisionID.Text = "ADM" Then
            LoadCustomerName()
        End If
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        If IsLoaded = True Then
            LoadCustomerIDByName()
        End If
    End Sub

    Private Sub PrintByReprintBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintByReprintBatchToolStripMenuItem.Click
        'GlobalReprintInvoiceBatch = txtReprintNumber.Text
        'GlobalDivisionCode = cboDivisionID.Text

        ''Choose the correct Print Form (REMOTE or LOCAL)

        ''Get Login Type
        'Dim GetLoginType As String = ""

        'Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
        'Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
        'GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        'If con.State = ConnectionState.Closed Then con.Open()
        'Try
        '    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
        'Catch ex As System.Exception
        '    GetLoginType = ""
        'End Try
        'con.Close()

        'If GetLoginType = "REMOTE" Then
        '    Using NewReprintInvoiceBatchRemote As New ReprintInvoiceBatchRemote
        '        Dim Result = NewReprintInvoiceBatchRemote.ShowDialog
        '    End Using
        'Else
        '    Using NewReprintInvoiceBatch As New ReprintInvoiceBatch
        '        Dim Result = NewReprintInvoiceBatch.ShowDialog
        '    End Using
        'End If
    End Sub

    Private Sub ViewLastThreeMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLastThreeMenuItem.Click
        ViewLastThreeMenuItem.Checked = True
        ViewAllDataMenuItem.Checked = False
        ClearDataInDatagrid()
        ClearData()
        ClearVariables()

        LoadInvoiceNumber()
        LoadSONumber()
        LoadShipmentNumber()
    End Sub

    Private Sub ViewAllDataMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllDataMenuItem.Click
        ViewLastThreeMenuItem.Checked = False
        ViewAllDataMenuItem.Checked = True
        ClearDataInDatagrid()
        ClearData()
        ClearVariables()

        LoadInvoiceNumber()
        LoadSONumber()
        LoadShipmentNumber()
    End Sub

    Public Function canSave() As Boolean
        If Me.dgvInvoiceHeader.RowCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ReScanPickTicket(Optional ByVal newPDF As Boolean = True)
        Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
        remoteCheck = False
        If canSave() Then
            Dim shipmentNum As String = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value.ToString


            ' Deletes the WIA testing temp file
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            ' Creates the folder if the temp folder is not currently created
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")

            If File.Exists("\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNum + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\TransferData\UploadedPickTickets" + ShipmentNumber + ".pdf")

            path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            'If there had been a previous scan then delete the picture from the picturebox
            GlobalVariables.Counter = 0

            Dim mgr As New WIA.DeviceManagerClass
            Dim Scanner As WIA.Device = Nothing
            If mgr.DeviceInfos.Count > 1 Then
                ''More than 1 scanner was detected
                Dim lst As New List(Of Integer)
                ''Finds all the USB scanners
                For i As Integer = 1 To mgr.DeviceInfos.Count()
                    If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                        lst.Add(i)
                    End If
                Next
                ''Check to see how many usb scanners were found
                If lst.Count > 1 Or lst.Count = 0 Then
                    Dim selectScanner As New WIA.CommonDialog
                    Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                Else
                    Scanner = mgr.DeviceInfos(lst(0)).Connect()
                End If
            ElseIf mgr.DeviceInfos.Count = 0 Then
                ''No scanners were detected
                If My.Computer.Name.ToString.StartsWith("TFP") Then
                    Dim loadingScreen As New Loading


                    bgwkRemoteWIA = New BackgroundWorker()
                    bgwkRemoteWIA.WorkerReportsProgress = True
                    AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                    AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_Completed
                    AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                    remoteCheck = True

                    remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, shipmentNum)
                    bgwkRemoteWIA.RunWorkerAsync()
                Else
                    ''No scanners were detected
                    MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ''Only 1 scanner is connected
                Scanner = mgr.DeviceInfos(1).Connect()
            End If
            If Scanner IsNot Nothing Then
                Dim item As WIA.Item = Scanner.Items(1)
                Dim obj As Object
                Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                ''Specific scanning properties
                For Each prop As WIA.Property In Scanner.Items(1).Properties
                    Dim x As WIA.IProperty = prop
                    Select Case prop.PropertyID
                        Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                            obj = 0
                            x.let_Value(obj)
                        Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                            obj = 2
                            x.let_Value(obj)
                        Case "6147" ''(DPI) Horizontal Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6148" ''(DPI) Vertical Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6151" ''horizontal extent (width)
                            obj = 1700
                            x.let_Value(obj)
                        Case "6152" ''vertical extent (height)
                            obj = 2338
                            x.let_Value(obj)
                    End Select
                Next

                Dim dial As New WIA.CommonDialog
                Dim hasMorePages As Boolean = True
                Dim ScannedAtleastOnePage As Boolean = False
                Dim pages As Integer = 0
                Dim ScannedImages As New List(Of iTextSharp.text.Image)

                ''Loops until all pages are scanned.
                While hasMorePages
                    GlobalVariables.Counter = GlobalVariables.Counter + 1
                    pages += 1
                    Try
                        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                        Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                        Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                        Img.SaveFile(tmp)
                        'ScannedImages.Add(Img.fromfile(tmp))
                        ScannedAtleastOnePage = True


                    Catch ex As System.Exception
                        ''Looks for paper empty error to break the loop and/or to show error message
                        If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                            If Not ScannedAtleastOnePage Then
                                MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                GlobalVariables.paperscan = False
                            Else
                                GlobalVariables.paperscan = True
                            End If
                            hasMorePages = False
                        End If
                    End Try
                End While

                'Displays the first saved scan into the picturebox
                If GlobalVariables.paperscan Then
                    GlobalVariables.StartCounter = 1
                    Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                    GlobalVariables.NextPrevious = GlobalVariables.StartCounter

                End If
            End If
            'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
            GlobalVariables.previousScan = True
            GlobalVariables.NextPrevious = 1


            Dim extensions As New List(Of String)
            extensions.Add("*.bmp")
            Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

            'counts the files in the folder
            Dim fileCount As Integer
            For i As Integer = 0 To extensions.Count - 1
                fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
            Next
            GlobalVariables.totalfiles = fileCount

        End If

    End Sub

    Public Sub ReFinalUploadPickTicket()
        'Tries to upload the file from the temp file and then saves it to correct folder
        Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
        Dim shipmentNum As String = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value.ToString

        Try
            Dim boolCheck As Boolean = True
            Dim FilesInFolder As Integer
            Dim FullName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"
            FilesInFolder = Directory.GetFiles(FullName, "*.bmp").Count

            'Variables Declared
            Dim comboboxSelection As String = shipmentNum

            Dim strDir As String = "\\TFP-FS\TransferData\UploadedPickTickets\"


            'Dim pdfDoc As New document()

            'Name of file
            Dim strFilename As String = shipmentNum + ".pdf"
            Dim pdfDoc As New document()
            Dim i As Integer = 1
            Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
            'path to bmp
            Dim strCompletePath As String = strDir & strFilename
            Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
            pdfDoc.Open()
            'Grabs the bmp image seen on screen
            Dim img As iTextSharp.text.Image = GetInstance(strPathname)
            'structures it to fit on pdf file
            img.ScalePercent(72.0F / img.DpiX * 100)
            img.SetAbsolutePosition(0, 0)
            'adds image to the document
            pdfDoc.Add(img)

            i += 1
            While i <= FilesInFolder
                pdfDoc.NewPage()
                strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
                'path to bmp
                strCompletePath = strDir & strFilename
                'Grabs the bmp image seen on screen
                img = GetInstance(strPathname)
                'structures it to fit on pdf file
                img.ScalePercent(72.0F / img.DpiX * 100)
                img.SetAbsolutePosition(0, 0)
                'adds image to the document
                pdfDoc.Add(img)
                i += 1
            End While
            pdfDoc.Close()


        Catch ex As TargetInvocationException
            'We only catch this one, so you can catch other exception later on
            'We get the inner exception because ex is not helpfull
            Dim iEX = ex.InnerException
        Catch ex As Exception

        End Try

        Dim bytecount As Integer = 0
        bytecount = FileLen("\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNum + ".pdf")
        If bytecount = 15 Then
            My.Computer.FileSystem.DeleteFile("\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNum + ".pdf")
            MsgBox("Scanning Error, Please Re-Upload File")
        End If
    End Sub

    Private Sub bgwk_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Try
            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
            Dim shipmentNum As String = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value.ToString

            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(dir.FullName + "\" + shipmentNum + ".pdf", System.IO.FileMode.Create)).SetFullCompression()

            doc.Open()
            ''Adds images to the pdf
            For Each img As System.Drawing.Image In images
                Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                doc.Add(iImage)
                doc.Add(New iTextSharp.text.Paragraph())
            Next
            doc.Close()

            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkAppendPDF_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
        Try

            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            ''Creates a memory stream for the document
            Using tempStream As New System.IO.MemoryStream()

                Dim shipmentNum As String = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value.ToString


                Dim copyDoc As New iTextSharp.text.Document()
                Dim copy As New iTextSharp.text.pdf.PdfCopy(copyDoc, tempStream)
                copyDoc.Open()
                Dim pageCounter As Integer = 0
                Dim reader As New iTextSharp.text.pdf.PdfReader(dir.FullName + "\" + shipmentNum + ".pdf")

                ''Gets pages for the pdf document
                Dim numberOfPages As Integer = reader.NumberOfPages
                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next
                copy.FreeReader(reader)
                reader.Close()

                System.IO.File.Delete(dir.FullName + "\" + shipmentNum + ".pdf")
                ''Creates a document in memory of the newly scanned pages
                Dim imageStream As New System.IO.MemoryStream()
                Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, imageStream).SetFullCompression()
                doc.Open()

                ''Adds the image to the pdf page
                For Each img As System.Drawing.Image In images
                    Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                    iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                    doc.Add(iImage)
                    doc.Add(New iTextSharp.text.Paragraph())
                Next
                doc.Close()

                ''Merges the newly scanned image document into the current document
                reader = New iTextSharp.text.pdf.PdfReader(imageStream.GetBuffer())
                numberOfPages = reader.NumberOfPages

                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next

                copy.FreeReader(reader)
                reader.Close()
                copyDoc.Close()
                imageStream.Close()
                imageStream.Dispose()

                Using fs As New System.IO.FileStream(dir.FullName + "\" + shipmentNum + ".pdf", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                    fs.Write(tempStream.GetBuffer(), 0, tempStream.GetBuffer().Length)
                End Using
            End Using


            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwk_Completed(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim images As List(Of System.Drawing.Image) = CType(e.Result, List(Of System.Drawing.Image))
        Dim TotalPages As Integer = images.Count

        While images.Count > 0
            images(0).Dispose()
            images.RemoveAt(0)
        End While

        If FilesToDelete IsNot Nothing AndAlso FilesToDelete.Count > 0 Then
            For Each filename As String In FilesToDelete
                System.IO.File.Delete(filename)
            Next
        End If

        frm.Enabled = True
        LoadingScreen.Hide()


        MessageBox.Show("Pick Ticket Uploaded With " + TotalPages.ToString + " pages.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub bgwkRemoteWIA_run(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            remoteWIA.StartClient()
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkRemoteWIA_Progress(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        Select Case e.ProgressPercentage
            Case 0
                LoadingScreen.Label1.Text = "Connecting to local system, please wait."
            Case 1
                LoadingScreen.Label1.Text = "Connected to local system, initializing scan."
            Case 2
                LoadingScreen.Label1.Text = "Attempting to scan, please wait."
            Case 3
                LoadingScreen.Label1.Text = "Waiting on file from local system."
            Case 4
                LoadingScreen.Label1.Text = "File received and being saved."
        End Select
    End Sub

    Private Sub bgwkRemoteWIA_Completed(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
            LoadingScreen.Hide()
            Dim shipmentNum As String = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value.ToString


            If remoteWIA.SaveFile(dir.FullName + "\" + shipmentNum + ".pdf") Then
                MessageBox.Show("Pick Ticket uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'ErrorDescription = "Scan Error"
                'ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If

            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception
        End Try

    End Sub

    Private Sub bgwkRemoteWIA_CompletedAppend(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            LoadingScreen.Hide()
            Dim name1, name2, final1 As String
            Dim RowIndex As Integer = Me.dgvInvoiceHeader.CurrentCell.RowIndex
            Dim shipmentNum As String = Me.dgvInvoiceHeader.Rows(RowIndex).Cells("ShipmentNumberColumn").Value.ToString

            If remoteWIA.SaveFile(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") Then
                MessageBox.Show("Pick Ticket uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                'ErrorDescription = "Scan Error"
                'ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If
            Dim initial As String = "\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNum + ".pdf"
            Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
            My.Computer.FileSystem.MoveFile(initial, final)

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") And File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf") Then

                final1 = "\\TFP-FS\TransferData\UploadedPickTickets\" + shipmentNum + ".pdf"
                name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"
                Dim pathArray = New String() {name1, name2}

                MergePdfFiles(pathArray, final1)
            End If

            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception
        End Try

    End Sub

    Public Shared Function MergePdfFiles(ByVal pdfFiles() As String, ByVal outputPath As String) As Boolean
        Dim result As Boolean = False
        Dim pdfCount As Integer = 0     'total input pdf file count
        Dim f As Integer = 0    'pointer to current input pdf file
        Dim fileName As String
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim pageCount As Integer = 0
        Dim pdfDoc As iTextSharp.text.Document = Nothing    'the output pdf document
        Dim writer As PdfWriter = Nothing
        Dim cb As PdfContentByte = Nothing

        Dim page As PdfImportedPage = Nothing
        Dim rotation As Integer = 0

        'Try
        pdfCount = pdfFiles.Length
        If pdfCount > 1 Then
            'Open the 1st item in the array PDFFiles
            fileName = pdfFiles(f)
            reader = New iTextSharp.text.pdf.PdfReader(fileName)
            'Get page count
            pageCount = reader.NumberOfPages

            pdfDoc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1), 18, 18, 18, 18)

            writer = PdfWriter.GetInstance(pdfDoc, New FileStream(outputPath, FileMode.OpenOrCreate))


            With pdfDoc
                .Open()
            End With
            'Instantiate a PdfContentByte object
            cb = writer.DirectContent
            'Now loop thru the input pdfs
            While f < pdfCount
                'Declare a page counter variable
                Dim i As Integer = 0
                'Loop thru the current input pdf's pages starting at page 1
                While i < pageCount
                    i += 1
                    'Get the input page size
                    pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(i))
                    'Create a new page on the output document
                    pdfDoc.NewPage()
                    'If it is the 1st page, we add bookmarks to the page
                    'Now we get the imported page
                    page = writer.GetImportedPage(reader, i)
                    'Read the imported page's rotation
                    rotation = reader.GetPageRotation(i)
                    'Then add the imported page to the PdfContentByte object as a template based on the page's rotation
                    If rotation = 90 Then
                        cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height)
                    ElseIf rotation = 270 Then
                        cb.AddTemplate(page, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(i).Width + 60, -30)
                    Else
                        cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                    End If
                End While
                'Increment f and read the next input pdf file
                f += 1
                If f < pdfCount Then
                    fileName = pdfFiles(f)
                    reader = New iTextSharp.text.pdf.PdfReader(fileName)
                    pageCount = reader.NumberOfPages
                End If
            End While
            'When all done, we close the document so that the pdfwriter object can write it to the output file
            pdfDoc.Close()
            result = True
        End If
        'Catch ex As Exception
        Return False
        'End Try
        Return result
    End Function


End Class