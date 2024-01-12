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
Public Class ViewReceiverLines
    Inherits System.Windows.Forms.Form

    Dim VendorName, TextFilter, DateFilter, VendorFilter, PartFilter, StatusFilter, QuantityOpenFilter, POFilter, ReceiverFilter As String
    Dim BeginDate, EndDate As Date
    Dim PONumber, ReceiverNumber As Integer
    Dim strPONumber, strReceiverNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\TransferData\UploadedPackingSlips")

    Private Sub ViewReceiverLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()
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

    Private Sub dgvReceivingLines_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceivingLines.CellDoubleClick
        Dim RowReceiverNumber As Integer
        Dim RowIndex As Integer = Me.dgvReceivingLines.CurrentCell.RowIndex

        RowReceiverNumber = Me.dgvReceivingLines.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value

        GlobalReceiverNumber = RowReceiverNumber
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintReceiver As New PrintReceiver
            Dim Result = NewPrintReceiver.ShowDialog()
        End Using
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvReceivingLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilter()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorCode = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboAPStatus.Text <> "" Then
            StatusFilter = " AND SelectForInvoice = '" + cboAPStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + txtTextFilter.Text + "%' OR VendorCode LIKE '%" + txtTextFilter.Text + "%' OR PONumber LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PONumber = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboReceiverNumber.Text <> "" Then
            ReceiverNumber = Val(cboReceiverNumber.Text)
            strReceiverNumber = CStr(ReceiverNumber)
            ReceiverFilter = " AND ReceivingHeaderKey = '" + strReceiverNumber + "'"
        Else
            ReceiverFilter = ""
        End If
        If chkQuantityOpen.Checked = True Then
            QuantityOpenFilter = " AND QuantityOpen > 0"
        Else
            QuantityOpenFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ReceivingLineQuery WHERE DivisionID <> @DivisionID" + POFilter + ReceiverFilter + PartFilter + VendorFilter + StatusFilter + QuantityOpenFilter + TextFilter + DateFilter + " ORDER BY ReceivingHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceivingLineQuery")
            dgvReceivingLines.DataSource = ds.Tables("ReceivingLineQuery")
            con.Close()

            Me.dgvReceivingLines.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ReceivingLineQuery WHERE DivisionID = @DivisionID" + POFilter + ReceiverFilter + PartFilter + VendorFilter + StatusFilter + QuantityOpenFilter + TextFilter + DateFilter + " ORDER BY ReceivingHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceivingLineQuery")
            dgvReceivingLines.DataSource = ds.Tables("ReceivingLineQuery")
            con.Close()

            Me.dgvReceivingLines.Columns("DivisionIDColumn").Visible = False
        End If
    End Sub

    Public Sub LoadVendor()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT VendorCode FROM Vendor WHERE DivisionID <> @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "Vendor")
            cboVendorID.DataSource = ds1.Tables("Vendor")
            con.Close()
            cboVendorID.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID ORDER BY VendorCode", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "Vendor")
            cboVendorID.DataSource = ds1.Tables("Vendor")
            con.Close()
            cboVendorID.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPartNumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT ItemID FROM ItemList WHERE DivisionID <> @DivisionID ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd
            myAdapter2.Fill(ds2, "ItemList")
            cboPartNumber.DataSource = ds2.Tables("ItemList")
            con.Close()
            cboPartNumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd
            myAdapter2.Fill(ds2, "ItemList")
            cboPartNumber.DataSource = ds2.Tables("ItemList")
            con.Close()
            cboPartNumber.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPartDescription()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT ShortDescription FROM ItemList WHERE DivisionID <> @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "ItemList")
            cboPartDescription.DataSource = ds3.Tables("ItemList")
            con.Close()
            cboPartDescription.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "ItemList")
            cboPartDescription.DataSource = ds3.Tables("ItemList")
            con.Close()
            cboPartDescription.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPurchaseOrder()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID <> @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "PurchaseOrderHeaderTable")
            cboPONumber.DataSource = ds4.Tables("PurchaseOrderHeaderTable")
            con.Close()
            cboPONumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "PurchaseOrderHeaderTable")
            cboPONumber.DataSource = ds4.Tables("PurchaseOrderHeaderTable")
            con.Close()
            cboPONumber.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadReceiverNumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT ReceivingHeaderKey FROM ReceivingHeaderTable WHERE DivisionID <> @DivisionID ORDER BY ReceivingHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds5 = New DataSet()
            myAdapter5.SelectCommand = cmd
            myAdapter5.Fill(ds5, "ReceivingHeaderTable")
            cboReceiverNumber.DataSource = ds5.Tables("ReceivingHeaderTable")
            con.Close()
            cboPONumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT ReceivingHeaderKey FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID ORDER BY ReceivingHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds5 = New DataSet()
            myAdapter5.SelectCommand = cmd
            myAdapter5.Fill(ds5, "ReceivingHeaderTable")
            cboReceiverNumber.DataSource = ds5.Tables("ReceivingHeaderTable")
            con.Close()
            cboPONumber.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        LoadPurchaseOrder()
        LoadReceiverNumber()
        LoadVendor()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        If cboDivisionID.Text = "ADM" Then
            Dim PartNumber1Statement As String = "SELECT TOP 1 (ItemID) FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID <> @DivisionID"
            Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
            PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
            PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
            Catch ex As Exception
                PartNumber1 = ""
            End Try
            con.Close()
        Else
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
        End If

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        If cboDivisionID.Text = "ADM" Then
            Dim PartDescription1Statement As String = "SELECT TOP 1 (ShortDescription) FROM ItemList WHERE ItemID = @ItemID AND DivisionID <> @DivisionID"
            Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
            PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
            Catch ex As Exception
                PartDescription1 = ""
            End Try
            con.Close()
        Else
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
        End If

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadVendorName()
        If cboDivisionID.Text = "ADM" Then
            Dim VendorNameString As String = "SELECT TOP 1 (VendorName) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID <> @DivisionID"
            Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
            VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorName = CStr(VendorNameCommand.ExecuteScalar)
            Catch ex As Exception
                VendorName = ""
            End Try
            con.Close()
        Else
            Dim VendorNameString As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
            VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorName = CStr(VendorNameCommand.ExecuteScalar)
            Catch ex As Exception
                VendorName = ""
            End Try
            con.Close()
        End If

        txtVendorName.Text = VendorName
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Public Sub ClearData()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboReceiverNumber.SelectedIndex = -1
        cboAPStatus.SelectedIndex = -1

        txtVendorName.Clear()
        txtTextFilter.Clear()

        chkDateRange.Checked = False
        chkQuantityOpen.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""
        cboVendorID.Focus()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintReceiverLinesFiltered As New PrintReceiverLinesFiltered
            Dim Result = NewPrintReceiverLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem1.Click
        GDS = ds
        Using NewPrintReceiverLinesFiltered As New PrintReceiverLinesFiltered
            Dim Result = NewPrintReceiverLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdOpenEditMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenEditMode.Click
        Dim RowReceiverNumber As Integer = 0
        Dim RowDivisionID As String = ""

        If Me.dgvReceivingLines.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvReceivingLines.CurrentCell.RowIndex

            RowReceiverNumber = Me.dgvReceivingLines.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value
            RowDivisionID = Me.dgvReceivingLines.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalReceiverNumber = RowReceiverNumber
            GlobalDivisionCode = RowDivisionID
        End If

        Dim NewReceiverEditMode As New ReceiverEditMode
        NewReceiverEditMode.Show()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvReceivingLines_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvReceivingLines.SelectionChanged
        CheckPackingSlipUpload()
    End Sub

    Private Sub CheckPackingSlipUpload()
        If dgvReceivingLines.SelectedCells.Count > 0 AndAlso dgvReceivingLines.SelectedCells(0).RowIndex >= 0 Then
            Dim fls As IO.FileInfo() = dir.GetFiles(dgvReceivingLines.Rows(dgvReceivingLines.SelectedCells(0).RowIndex).Cells("ReceivingHeaderKeyColumn").Value.ToString + ".pdf")
            If fls.Length > 0 Then
                cmdViewPackingSlip.Enabled = True
                UploadPackingSlipToolStripMenuItem.Enabled = False
                ReUploadPackingSlipToolStripMenuItem.Enabled = True
            Else
                cmdViewPackingSlip.Enabled = False
                UploadPackingSlipToolStripMenuItem.Enabled = True
                ReUploadPackingSlipToolStripMenuItem.Enabled = False
            End If
        Else
            cmdViewPackingSlip.Enabled = False
            UploadPackingSlipToolStripMenuItem.Enabled = True
            ReUploadPackingSlipToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub cmdViewPackingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPackingSlip.Click
        Dim RowReceiverNumber As Integer = 0
        Dim ReceiverFilename As String = ""
        Dim ReceiverFilenameAndPath As String = ""

        If Me.dgvReceivingLines.RowCount > 0 Then
            Dim UploadedReceiverNumber As String = ""
            Dim RowIndex As Integer = Me.dgvReceivingLines.CurrentCell.RowIndex

            RowReceiverNumber = Me.dgvReceivingLines.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value

            UploadedReceiverNumber = CStr(RowReceiverNumber)
            ReceiverFilename = UploadedReceiverNumber + ".pdf"
            ReceiverFilenameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + ReceiverFilename

            If File.Exists(ReceiverFilenameAndPath) Then
                System.Diagnostics.Process.Start(ReceiverFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox("You must have a valid Receiver number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Private Sub UploadPackingSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadPackingSlipToolStripMenuItem.Click
        Dim psUpload As New PackingSlipScannerUploadAPI(New Windows.Forms.Button(), New Windows.Forms.Control(dgvReceivingLines.Rows(dgvReceivingLines.SelectedCells(0).RowIndex).Cells("ReceivingHeaderKeyColumn").Value), New Windows.Forms.ToolStripMenuItem(), Me, AppendUploadedPackingSlipToolStripMenuItem)
        psUpload.UploadPackingSlip()
        CheckPackingSlipUpload()
        Me.BringToFront()
    End Sub

    Private Sub ReUploadPackingSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReUploadPackingSlipToolStripMenuItem.Click
        Dim psUpload As New PackingSlipScannerUploadAPI(New Windows.Forms.Button(), New Windows.Forms.Control(dgvReceivingLines.Rows(dgvReceivingLines.SelectedCells(0).RowIndex).Cells("ReceivingHeaderKeyColumn").Value), New Windows.Forms.ToolStripMenuItem(), Me, AppendUploadedPackingSlipToolStripMenuItem)
        psUpload.ReUploadPackingSlip()
        CheckPackingSlipUpload()
        Me.BringToFront()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub
End Class