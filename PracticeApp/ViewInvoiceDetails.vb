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
Public Class ViewInvoiceDetails
    Inherits System.Windows.Forms.Form

    Dim PRONumber, CustomerID, CustomerPO, PaymentTerms, Comment, InvoiceStatus, ShipVia, SpecialInstructions, BTAddress1, BTAddress2, BTCity, BTState, BTZip As String
    Dim ShipmentNumber, SalesOrderNumber As Integer
    Dim ProductTotal, BilledFreight, SalesTax, SalesTax2, SalesTax3, Discount, InvoiceTotal, PaymentsApplied As Double
    Dim InvoiceDate As Date
    Dim CheckPaymentTerms As Integer = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""
    Dim TodaysDate As Date = Now()

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim PTUpload As PickTicketScannerUploadAPI

    Private Sub ViewInvoiceDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCurrentDivision()

        'Load scan defaults
        If My.Computer.Name.StartsWith("TFP") Then
            ScanPickTicketToolStripMenuItem.Visible = True
            ReUploadPickTicketToolStripMenuItem.Enabled = False
            UploadPickTicket.Enabled = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
        Else
            ScanPickTicketToolStripMenuItem.Visible = False
            ReUploadPickTicketToolStripMenuItem.Enabled = False
            UploadPickTicket.Enabled = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
        End If

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        PTUpload = New PickTicketScannerUploadAPI(UploadPickTicket, lblShipmentNumber, ReUploadPickTicketToolStripMenuItem, Me, AppendUploadedPickTicketToolStripMenuItem)
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

    Public Sub ValidatePaymentTerms()
        If cboPaymentTerms.Text = "Prepaid" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "COD" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N30" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "CREDIT CARD" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "NetDue" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N60" And cboDivisionID.Text = "TFP" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N60" And cboDivisionID.Text = "TWD" And lblCustomerID.Text = "DAVIDEISENMA" Then
            CheckPaymentTerms = 1
        Else
            CheckPaymentTerms = 0
        End If
    End Sub

    Private Sub ViewInvoiceDetails_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearVariables()
        ClearData()
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvInvoiceLines.CellValueChanged
        Dim LineComment, SerialNumber As String
        Dim LineNumber As Integer

        ''UPDATE Line Table on changes in the datagrid
        For Each row As DataGridViewRow In dgvInvoiceLines.Rows
            Try
                LineComment = row.Cells("LineCommentColumn").Value
            Catch ex As Exception
                LineComment = ""
            End Try
            Try
                SerialNumber = row.Cells("SerialNumberColumn").Value
            Catch ex As Exception
                SerialNumber = ""
            End Try
            Try
                LineNumber = row.Cells("InvoiceLineKeyColumn").Value
            Catch ex As Exception
                LineNumber = 0
            End Try

            Try
                'UPDATE Shipment Line Table
                cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineComment = @LineComment, SerialNumber = @SerialNumber WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                With cmd.Parameters
                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = LineNumber
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'ShowData()
            Catch ex As Exception
                'Do nothing
            End Try
        Next
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey ORDER BY InvoiceHeaderKey, InvoiceLineKey ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceLineTable")
        dgvInvoiceLines.DataSource = ds.Tables("InvoiceLineTable")
        con.Close()
    End Sub

    Public Sub LoadInvoiceNumber()
        cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID ORDER BY InvoiceNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "InvoiceHeaderTable")
        cboInvoiceNumber.DataSource = ds1.Tables("InvoiceHeaderTable")
        con.Close()
        cboInvoiceNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadInvoiceLineData()
        Dim InvoiceDateStatement As String = "SELECT InvoiceDate FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceDateCommand As New SqlCommand(InvoiceDateStatement, con)
        InvoiceDateCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesOrderNumberStatement As String = "SELECT SalesOrderNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SalesOrderNumberCommand As New SqlCommand(SalesOrderNumberStatement, con)
        SalesOrderNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesOrderNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)
        ShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        ShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerIDStatement As String = "SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim CustomerIDCommand As New SqlCommand(CustomerIDStatement, con)
        CustomerIDCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        CustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerPOStatement As String = "SELECT CustomerPO FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim CustomerPOCommand As New SqlCommand(CustomerPOStatement, con)
        CustomerPOCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        CustomerPOCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ProductTotalStatement As String = "SELECT ProductTotal FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BilledFreightStatement As String = "SELECT BilledFreight FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim BilledFreightCommand As New SqlCommand(BilledFreightStatement, con)
        BilledFreightCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        BilledFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTaxStatement As String = "SELECT SalesTax FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber1 AND DivisionID = @DivisionID1"
        Dim SalesTaxCommand As New SqlCommand(SalesTaxStatement, con)
        SalesTaxCommand.Parameters.Add("@InvoiceNumber1", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesTaxCommand.Parameters.Add("@DivisionID1", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DiscountStatement As String = "SELECT Discount FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim DiscountCommand As New SqlCommand(DiscountStatement, con)
        SalesTaxCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceTotalStatement As String = "SELECT InvoiceTotal FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceTotalCommand As New SqlCommand(InvoiceTotalStatement, con)
        InvoiceTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentsAppliedStatement As String = "SELECT PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim PaymentsAppliedCommand As New SqlCommand(PaymentsAppliedStatement, con)
        PaymentsAppliedCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        PaymentsAppliedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceStatusStatement As String = "SELECT InvoiceStatus FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceStatusCommand As New SqlCommand(InvoiceStatusStatement, con)
        InvoiceStatusCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipViaStatement As String = "SELECT ShipVia FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim ShipViaCommand As New SqlCommand(ShipViaStatement, con)
        ShipViaCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        ShipViaCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CommentStatement As String = "SELECT Comment FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim CommentCommand As New SqlCommand(CommentStatement, con)
        CommentCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        CommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PRONumberStatement As String = "SELECT PRONumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim PRONumberCommand As New SqlCommand(PRONumberStatement, con)
        PRONumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        PRONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SpecialInstructionsStatement As String = "SELECT SpecialInstructions FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SpecialInstructionsCommand As New SqlCommand(SpecialInstructionsStatement, con)
        SpecialInstructionsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SpecialInstructionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
        PaymentTermsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BTAddress1Statement As String = "SELECT BTAddress1 FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim BTAddress1Command As New SqlCommand(BTAddress1Statement, con)
        BTAddress1Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        BTAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BTAddress2Statement As String = "SELECT BTAddress2 FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim BTAddress2Command As New SqlCommand(BTAddress2Statement, con)
        BTAddress2Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        BTAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BTCityStatement As String = "SELECT BTCity FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim BTCityCommand As New SqlCommand(BTCityStatement, con)
        BTCityCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        BTCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BTStateStatement As String = "SELECT BTState FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim BTStateCommand As New SqlCommand(BTStateStatement, con)
        BTStateCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        BTStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BTZipStatement As String = "SELECT BTZip FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim BTZipCommand As New SqlCommand(BTZipStatement, con)
        BTZipCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        BTZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTax2Statement As String = "SELECT SalesTax2 FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SalesTax2Command As New SqlCommand(SalesTax2Statement, con)
        SalesTax2Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesTax2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTax3Statement As String = "SELECT SalesTax3 FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SalesTax3Command As New SqlCommand(SalesTax3Statement, con)
        SalesTax3Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SalesTax3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InvoiceDate = CDate(InvoiceDateCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceDate = lblInvoiceDate.Text
        End Try
        Try
            SalesOrderNumber = CInt(SalesOrderNumberCommand.ExecuteScalar)
        Catch ex As Exception
            SalesOrderNumber = 0
        End Try
        Try
            ShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
        Catch ex As Exception
            ShipmentNumber = 0
        End Try
        Try
            CustomerID = CStr(CustomerIDCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerID = ""
        End Try
        Try
            CustomerPO = CStr(CustomerPOCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerPO = 0
        End Try
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            BilledFreight = CDbl(BilledFreightCommand.ExecuteScalar)
        Catch ex As Exception
            BilledFreight = 0
        End Try
        Try
            SalesTax = CDbl(SalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SalesTax = 0
        End Try
        Try
            Discount = CDbl(DiscountCommand.ExecuteScalar)
        Catch ex As Exception
            Discount = 0
        End Try
        Try
            InvoiceTotal = CDbl(InvoiceTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceTotal = 0
        End Try
        Try
            PaymentsApplied = CDbl(PaymentsAppliedCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentsApplied = 0
        End Try
        Try
            InvoiceStatus = CStr(InvoiceStatusCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceStatus = ""
        End Try
        Try
            ShipVia = CStr(ShipViaCommand.ExecuteScalar)
        Catch ex As Exception
            ShipVia = "Delivery"
        End Try
        Try
            PRONumber = CStr(PRONumberCommand.ExecuteScalar)
        Catch ex As Exception
            PRONumber = ""
        End Try
        Try
            Comment = CStr(CommentCommand.ExecuteScalar)
        Catch ex As Exception
            Comment = ""
        End Try
        Try
            SpecialInstructions = CStr(SpecialInstructionsCommand.ExecuteScalar)
        Catch ex As Exception
            SpecialInstructions = "STANDARD"
        End Try
        Try
            PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentTerms = "N30"
        End Try
        Try
            BTAddress1 = CStr(BTAddress1Command.ExecuteScalar)
        Catch ex As Exception
            BTAddress1 = ""
        End Try
        Try
            BTAddress2 = CStr(BTAddress2Command.ExecuteScalar)
        Catch ex As Exception
            BTAddress2 = ""
        End Try
        Try
            BTCity = CStr(BTCityCommand.ExecuteScalar)
        Catch ex As Exception
            BTCity = ""
        End Try
        Try
            BTState = CStr(BTStateCommand.ExecuteScalar)
        Catch ex As Exception
            BTState = ""
        End Try
        Try
            BTZip = CStr(BTZipCommand.ExecuteScalar)
        Catch ex As Exception
            BTZip = ""
        End Try
        Try
            SalesTax2 = CDbl(SalesTax2Command.ExecuteScalar)
        Catch ex As Exception
            SalesTax2 = 0
        End Try
        Try
            SalesTax3 = CDbl(SalesTax3Command.ExecuteScalar)
        Catch ex As Exception
            SalesTax3 = 0
        End Try
        con.Close()

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            SalesTax = SalesTax + SalesTax2 + SalesTax3
        Else
            'Skip - tax is correct
        End If

        lblInvoiceDate.Text = InvoiceDate
        lblSONumber.Text = SalesOrderNumber
        lblShipmentNumber.Text = ShipmentNumber
        lblCustomerID.Text = CustomerID
        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        lblBilledFreight.Text = FormatCurrency(BilledFreight, 2)
        lblSalesTax.Text = FormatCurrency(SalesTax, 2)
        lblDiscount.Text = FormatCurrency(Discount, 2)
        lblInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        lblPaymentsApplied.Text = FormatCurrency(PaymentsApplied, 2)
        lblInvoiceStatus.Text = InvoiceStatus

        txtCustomerPONumber.Text = CustomerPO
        cboShipVia.Text = ShipVia
        cboPaymentTerms.Text = PaymentTerms
        txtPRONumber.Text = PRONumber
        txtComment.Text = Comment
        txtSpecialInstructions.Text = SpecialInstructions
        txtAddress1.Text = BTAddress1
        txtAddress2.Text = BTAddress2
        txtCity.Text = BTCity
        txtState.Text = BTState
        txtZip.Text = BTZip
    End Sub

    Public Sub LoadUploadedPickTicket()
        If lblShipmentNumber.Text <> "" Then
            Dim UploadedShipmentNumber As String = ""
            Dim UploadedFileName As String = ""
            Dim UploadedFilenameAndPath As String = ""

            UploadedShipmentNumber = lblShipmentNumber.Text

            UploadedFileName = UploadedShipmentNumber + ".pdf"
            UploadedFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets" + "\" + UploadedFileName

            If My.Computer.Name.StartsWith("TFP") Then
                If File.Exists(UploadedFilenameAndPath) Then
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                    ReUploadPickTicketToolStripMenuItem.Enabled = False
                    ScanPickTicketToolStripMenuItem.Visible = True
                    UploadPickTicket.Enabled = False
                Else
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                    ReUploadPickTicketToolStripMenuItem.Enabled = False
                    ScanPickTicketToolStripMenuItem.Visible = True
                    UploadPickTicket.Enabled = False
                End If
            Else
                If File.Exists(UploadedFilenameAndPath) Then
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = True
                    ReUploadPickTicketToolStripMenuItem.Enabled = True
                    ScanPickTicketToolStripMenuItem.Visible = False
                    UploadPickTicket.Enabled = False
                Else
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                    ReUploadPickTicketToolStripMenuItem.Enabled = False
                    ScanPickTicketToolStripMenuItem.Visible = False
                    UploadPickTicket.Enabled = True
                End If
            End If
        Else
            'Do nothing
        End If
    End Sub

    Public Sub ClearData()
        cboInvoiceNumber.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1

        lblInvoiceDate.Text = ""
        lblSONumber.Text = ""
        lblShipmentNumber.Text = ""
        lblCustomerID.Text = ""
        lblProductTotal.Text = ""
        lblBilledFreight.Text = ""
        lblSalesTax.Text = ""
        lblDiscount.Text = ""
        lblInvoiceTotal.Text = ""
        lblPaymentsApplied.Text = ""
        lblInvoiceStatus.Text = ""

        txtCustomerPONumber.Clear()
        txtPRONumber.Clear()
        txtComment.Clear()
        txtSpecialInstructions.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtState.Clear()
        txtZip.Clear()
    End Sub

    Public Sub ClearVariables()
        CheckPaymentTerms = 0
        PRONumber = ""
        CustomerID = ""
        CustomerPO = ""
        PaymentTerms = ""
        Comment = ""
        InvoiceStatus = ""
        ShipVia = ""
        SpecialInstructions = ""
        ShipmentNumber = 0
        SalesOrderNumber = 0
        ProductTotal = 0
        BilledFreight = 0
        SalesTax = 0
        Discount = 0
        InvoiceTotal = 0
        PaymentsApplied = 0
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearVariables()
        LoadInvoiceNumber()
        ClearData()
        ShowData()
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAllToolStripMenuItem.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cmdViewInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowData()
        LoadInvoiceLineData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cboInvoiceNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvoiceNumber.SelectedIndexChanged
        ShowData()
        LoadInvoiceLineData()
        If PTUpload IsNot Nothing Then PTUpload.CheckUploadPickTicket()
    End Sub

    Public Sub Save()
        If cboInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Invoice Number selected.", MsgBoxStyle.OkOnly)
        Else
            '*****************************************************************
            'Validate Payment Terms
            ValidatePaymentTerms()

            If CheckPaymentTerms = 0 Then
                MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '*****************************************************************
            Try
                'Save data to Invoice Header Table
                cmd = New SqlCommand("Update InvoiceHeaderTable SET CustomerPO = @CustomerPO, Comment = @Comment, SpecialInstructions = @SpecialInstructions, PRONumber = @PRONumber, ShipVia = @ShipVia, PaymentTerms = @PaymentTerms, BTAddress1 = @BTAddress1, BTAddress2 = @BTAddress2, BTCity = @BTCity, BTState = @BTState, BTZip = @BTZip WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                    .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                    .Add("@BTAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                    .Add("@BTAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                    .Add("@BTCity", SqlDbType.VarChar).Value = txtCity.Text
                    .Add("@BTState", SqlDbType.VarChar).Value = txtState.Text
                    .Add("@BTZip", SqlDbType.VarChar).Value = txtZip.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If Val(lblShipmentNumber.Text) <> 0 Then
                    'Save PRO Number to Shipment Tab
                    cmd = New SqlCommand("Update ShipmentHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(lblShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Skip - no shipment for Invoice
                End If

                ShowData()
                MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                MsgBox("Changes cannot be saved at this time.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub SaveChangesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveChangesToolStripMenuItem.Click
        Save()
    End Sub

    Private Sub cmdSaveInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveInvoice.Click
        Save()
    End Sub

    Private Sub PrintInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoiceToolStripMenuItem.Click
        cmdPrintInvoice_Click(sender, e)
    End Sub

    Private Sub cmdPrintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintInvoice.Click
        If cboInvoiceNumber.Text = "" Then
            MsgBox("You must select an Invoice #.", MsgBoxStyle.OkOnly)
        Else
            Dim CustomerEmail As String = ""

            Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
            CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
            CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerEmail = ""
            End Try
            con.Close()

            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                If ShipmentNumber = 0 Or SalesOrderNumber = 0 Or SpecialInstructions = "CREDIT" Then
                    GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = lblCustomerID.Text
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
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = lblCustomerID.Text
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
            Else
                If ShipmentNumber = 0 Or SalesOrderNumber = 0 Or SpecialInstructions = "CREDIT" Then
                    GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = lblCustomerID.Text
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
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = lblCustomerID.Text
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
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ScanPickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanPickTicketToolStripMenuItem.Click
        Dim PickTicketFilename As String = ""
        Dim PickTicketFilenameAndPath As String = ""
        Dim strPickTicketNumber As String = ""
        Dim PickTicketNumber As Integer = 0

        'Scanning Program
        Dim My_Process As New Process()

        'Verify that they have a PickTicket selected
        If lblShipmentNumber.Text = "" Then
            MsgBox("You must select a valid PickTicket.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            PickTicketNumber = lblShipmentNumber.Text
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
                strPickTicketNumber = CStr(lblShipmentNumber.Text)
                PickTicketFilename = strPickTicketNumber + ".pdf"
                PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

                Try
                    My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    My_Process.StartInfo.CreateNoWindow = True
                    My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                    My_Process.Close()

                    lblShipmentNumber.Refresh()
                    LoadUploadedPickTicket()
                    lblShipmentNumber.Text = PickTicketNumber
 
                    MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
                Catch ex As System.Exception
                    '    'Log error on update failure
                    Dim TempPickTicketNumber As Integer = 0
                    Dim strPickTicketNumber1 As String = ""
                    TempPickTicketNumber = Val(lblShipmentNumber.Text)
                    strPickTicketNumber1 = CStr(TempPickTicketNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ApplicationFileAndPath & "" & PickTicketFilenameAndPath
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Edit Invoice Form --- Scan"
                    ErrorReferenceNumber = "Shipment # " + strPickTicketNumber1
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MsgBox("Scan failed", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"

            strPickTicketNumber = CStr(lblShipmentNumber.Text)
            PickTicketFilename = strPickTicketNumber + ".pdf"
            PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

            Try
                My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                My_Process.StartInfo.CreateNoWindow = True
                My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()

                lblShipmentNumber.Refresh()
                LoadUploadedPickTicket()
                lblShipmentNumber.Text = PickTicketNumber
              
                MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                '    'Log error on update failure
                Dim TempPickTicketNumber As Integer = 0
                Dim strPickTicketNumber1 As String = ""
                TempPickTicketNumber = Val(lblShipmentNumber.Text)
                strPickTicketNumber1 = CStr(TempPickTicketNumber)

                ErrorDate = TodaysDate
                ErrorComment = ApplicationFileAndPath & "" & PickTicketFilenameAndPath
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Edit Invoice Form --- Scan"
                ErrorReferenceNumber = "Shipment # " + strPickTicketNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan failed", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub
End Class