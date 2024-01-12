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
Public Class ViewPOHeaders
    Inherits System.Windows.Forms.Form

    Dim VendorFilter, POFilter, StatusFilter, DateFilter, TextFilter As String
    Dim FreightCharge, POTotal, ProductTotal, SalesTaxTotal As Double
    Dim VendorName As String
    Dim BeginDate, EndDate As Date
    Dim PONumber As Integer = 0
    Dim strPONumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewPOHeaders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCurrentDivision()

        If EmployeeSecurityCode > 1005 And EmployeeSecurityCode <> 1015 Then
            cmdAddFreight.Enabled = False
        End If

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

    Private Sub dgvPurchaseOrderHeaders_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvPurchaseOrderHeaders.CellDoubleClick
        If Me.dgvPurchaseOrderHeaders.RowCount <> 0 Then
            Dim RowPONumber As Integer = 0
            Dim RowDivision As String = ""

            Dim RowIndex As Integer = Me.dgvPurchaseOrderHeaders.CurrentCell.RowIndex

            RowPONumber = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("PurchaseOrderHeaderKeyColumn").Value
            RowDivision = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalPONumber = RowPONumber
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
                Using NewPrintPurchaseOrderRemote As New PrintPurchaseOrderRemote
                    Dim Result = NewPrintPurchaseOrderRemote.ShowDialog()
                End Using
            Else
                Using NewPrintPurchaseOrder As New PrintPurchaseOrder
                    Dim Result = NewPrintPurchaseOrder.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub ViewPOHeaders_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
    End Sub

    Public Sub ClearData()
        cboVendorID.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        cboStatus.SelectedIndex = -1

        txtVendorName.Clear()
        txtPOFreight.Clear()
        txtTextSearch.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkUseDateRange.Checked = False
        cboVendorID.Focus()
    End Sub

    Public Sub ShowDataByFilter()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboStatus.Text <> "" Then
            StatusFilter = " AND Status = '" + cboStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PurchaseOrderHeaderKey = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If txtTextSearch.Text <> "" Then
            TextFilter = " AND (VendorID LIKE '%" + usefulFunctions.checkQuote(txtTextSearch.Text) + "%' OR PODropShipCustomerID LIKE '%" + usefulFunctions.checkQuote(txtTextSearch.Text) + "%')"
        Else
            TextFilter = ""
        End If
        If chkUseDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
  
            DateFilter = " AND PODate BETWEEN @BeginDate AND @EndDate"
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE DivisionID <> @DivisionID" + VendorFilter + StatusFilter + POFilter + TextFilter + DateFilter + " ORDER BY DivisionID, PurchaseOrderHeaderKey", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "PurchaseOrderHeaderTable")
            dgvPurchaseOrderHeaders.DataSource = ds.Tables("PurchaseOrderHeaderTable")
            cboPurchaseOrderNumber.DataSource = ds.Tables("PurchaseOrderHeaderTable")
            con.Close()

            Me.dgvPurchaseOrderHeaders.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID" + VendorFilter + StatusFilter + POFilter + TextFilter + DateFilter + " ORDER BY PurchaseOrderHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "PurchaseOrderHeaderTable")
            dgvPurchaseOrderHeaders.DataSource = ds.Tables("PurchaseOrderHeaderTable")
            cboPurchaseOrderNumber.DataSource = ds.Tables("PurchaseOrderHeaderTable")
            con.Close()

            Me.dgvPurchaseOrderHeaders.Columns("DivisionIDColumn").Visible = False
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvPurchaseOrderHeaders.DataSource = Nothing
        cboPurchaseOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorID()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT VendorCode FROM Vendor WHERE DivisionID <> @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "Vendor")
        con.Close()

        cboVendorID.DataSource = ds1.Tables("Vendor")
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadPONumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID <> @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "PurchaseOrderHeaderTable")
        con.Close()

        cboPONumber.DataSource = ds2.Tables("PurchaseOrderHeaderTable")
        cboPONumber.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadVendorID()
        LoadPONumber()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadVendorName()
        If cboDivisionID.Text = "ADM" Then
            Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID <> @DivisionID"
            Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
            VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorName = CStr(VendorNameCommand.ExecuteScalar)
            Catch ex As System.Exception
                VendorName = ""
            End Try
            con.Close()

            txtVendorName.Text = VendorName
        Else
            Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
            VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorName = CStr(VendorNameCommand.ExecuteScalar)
            Catch ex As System.Exception
                VendorName = ""
            End Try
            con.Close()

            txtVendorName.Text = VendorName
        End If
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Private Sub cboOpenPOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOpenPOForm.Click
        If Me.dgvPurchaseOrderHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPurchaseOrderHeaders.CurrentCell.RowIndex

            Try
                GlobalPONumber = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("PurchaseOrderHeaderKeyColumn").Value
            Catch ex As Exception
                GlobalPONumber = 0
            End Try
        End If

        GlobalDivisionCode = cboDivisionID.Text

        Dim NewPOForm As New POForm
        NewPOForm.Show()
    End Sub

    Private Sub cmdAddFreight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFreight.Click
        If cboPurchaseOrderNumber.Text = "" Then
            MsgBox("You must have a valid PO Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
            Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
            SUMExtendedAmountCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim SalesTaxStatement As String = "SELECT SalesTax FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
            Dim SalesTaxCommand As New SqlCommand(SalesTaxStatement, con)
            SalesTaxCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            SalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
            Catch ex As System.Exception
                ProductTotal = 0
            End Try
            Try
                SalesTaxTotal = CDbl(SalesTaxCommand.ExecuteScalar)
            Catch ex As System.Exception
                SalesTaxTotal = 0
            End Try
            con.Close()

            FreightCharge = Val(txtPOFreight.Text)
            POTotal = ProductTotal + SalesTaxTotal + FreightCharge

            'UPDATE Purchase Order Header Totals
            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET FreightCharge = @FreightCharge, POTotal = @POTotal WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = FreightCharge
                .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Purchase Order has been updated.", MsgBoxStyle.OkOnly)
            cmdView_Click(sender, e)
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprint.Click
        GlobalPONumber = Val(cboPurchaseOrderNumber.Text)

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
            Using NewPrintPurchaseOrderRemote As New PrintPurchaseOrderRemote
                Dim Result = NewPrintPurchaseOrderRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPurchaseOrder As New PrintPurchaseOrder
                Dim Result = NewPrintPurchaseOrder.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintPOHeadersFiltered As New PrintPOHeadersFiltered
            Dim result = NewPrintPOHeadersFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintPOHeadersFiltered As New PrintPOHeadersFiltered
            Dim result = NewPrintPOHeadersFiltered.ShowDialog()
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

    Private Sub dgvPurchaseOrderHeaders_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPurchaseOrderHeaders.CellValueChanged
        Dim FreightCharge As Double = 0
        Dim PODate, ShipDate, ShipMethodID, PurchaseAgent, POComment, PaymentCode As String
        Dim PurchaseOrderHeaderKey As Integer = 0
        Dim RowDivision As String = ""

        If Me.dgvPurchaseOrderHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPurchaseOrderHeaders.CurrentCell.RowIndex

            Try
                PurchaseOrderHeaderKey = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("PurchaseOrderHeaderKeyColumn").Value
            Catch ex As Exception
                PurchaseOrderHeaderKey = 0
            End Try
            Try
                FreightCharge = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("FreightChargeColumn").Value
            Catch ex As Exception
                FreightCharge = 0
            End Try
            Try
                PODate = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("PODateColumn").Value
            Catch ex As Exception
                PODate = ""
            End Try
            Try
                ShipDate = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("ShipDateColumn").Value
            Catch ex As Exception
                ShipDate = ""
            End Try
            Try
                ShipMethodID = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("ShipMethodIDColumn").Value
            Catch ex As Exception
                ShipMethodID = ""
            End Try
            Try
                PurchaseAgent = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("PurchaseAgentColumn").Value
            Catch ex As Exception
                PurchaseAgent = ""
            End Try
            Try
                POComment = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("POHeaderCommentColumn").Value
            Catch ex As Exception
                POComment = ""
            End Try
            Try
                PaymentCode = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("PaymentCodeColumn").Value
            Catch ex As Exception
                PaymentCode = "N30"
            End Try
            Try
                RowDivision = Me.dgvPurchaseOrderHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try

            Try
                'UPDATE Purchase Order Header Table
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET PODate = @PODate, PaymentCode = @PaymentCode, POHeaderComment = @POHeaderComment, ShipDate = @ShipDate, ShipMethodID = @ShipMethodID, FreightCharge = @FreightCharge, PurchaseAgent = @PurchaseAgent WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = PurchaseOrderHeaderKey
                    .Add("@PODate", SqlDbType.VarChar).Value = PODate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@PaymentCode", SqlDbType.VarChar).Value = PaymentCode
                    .Add("@POHeaderComment", SqlDbType.VarChar).Value = POComment
                    .Add("@ShipDate", SqlDbType.VarChar).Value = ShipDate
                    .Add("@ShipMethodID", SqlDbType.VarChar).Value = ShipMethodID
                    .Add("@FreightCharge", SqlDbType.VarChar).Value = FreightCharge
                    .Add("@PurchaseAgent", SqlDbType.VarChar).Value = PurchaseAgent
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try

            Try
                'UPDATE PO Totals
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET POTotal = ProductTotal + FreightCharge + SalesTax WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = PurchaseOrderHeaderKey
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try

            cmdView_Click(sender, e)
        Else
            'Skip update
        End If
    End Sub
End Class