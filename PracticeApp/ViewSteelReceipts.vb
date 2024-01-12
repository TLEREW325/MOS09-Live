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
Public Class ViewSteelReceipts
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Public ctmMenu As New ContextMenu

    Dim CarbonFilter, SteelSizeFilter, SteelPOFilter, BOLFilter, DateFilter, VendorFilter As String
    Dim SteelPONumber As Integer = 0
    Dim strSteelPONumber As String = ""

    Private Sub ViewSteelReceipts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ctmMenu.MenuItems.Add("View Steel Coils", AddressOf ViewSteelCoils_Click)
        ctmMenu.MenuItems(0).Name = "ViewSteelCoils"

        Me.AcceptButton = cmdView

        LoadCurrentDivision()
        ClearData()
    End Sub

    Private Sub ViewSteelCoils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.dgvSteelReceivingLines.RowCount > 0 Then
            Dim RowReceiverNumber, RowLineNumber As Integer
            Dim RowRMID As String = ""

            Dim RowIndex As Integer = Me.dgvSteelReceivingLines.CurrentCell.RowIndex

            Try
                RowReceiverNumber = Me.dgvSteelReceivingLines.Rows(RowIndex).Cells("SteelReceivingHeaderKeyColumn").Value
            Catch ex As Exception
                RowReceiverNumber = 0
            End Try
            Try
                RowLineNumber = Me.dgvSteelReceivingLines.Rows(RowIndex).Cells("SteelReceivingLineKeyColumn").Value
            Catch ex As Exception
                RowLineNumber = 0
            End Try
            Try
                RowRMID = Me.dgvSteelReceivingLines.Rows(RowIndex).Cells("RMIDColumn").Value
            Catch ex As Exception
                RowRMID = ""
            End Try

            GlobalSteelReceiverNumberPopup = RowReceiverNumber
            GlobalSteelReceiverLinePopup = RowLineNumber
            GlobalSteelReceiverRMIDPopup = RowRMID

            Using NewSteelCoilPopup As New SteelReceivingCoilsPopup
                Dim result = NewSteelCoilPopup.ShowDialog()
            End Using
        End If
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

    Public Sub ShowData()
        If cboCarbon.Text = "" Then
            CarbonFilter = ""
        Else
            If chkAllTypes.Checked = True Then
                CarbonFilter = " AND Carbon LIKE '" + cboCarbon.Text + "%'"
            Else
                CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
            End If
        End If
        If cboSteelSize.Text = "" Then
            SteelSizeFilter = ""
        Else
            If chkAllTypes.Checked = True Then
                SteelSizeFilter = " AND SteelSize LIKE '" + cboSteelSize.Text + "%'"
            Else
                SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
            End If
        End If
        If cboBOL.Text = "" Then
            BOLFilter = ""
        Else
            BOLFilter = " AND SteelBOLNumber = '" + cboBOL.Text + "'"
        End If
        If cboSteelVendor.Text = "" Then
            VendorFilter = ""
        Else
            VendorFilter = " AND SteelVendor = '" + cboSteelVendor.Text + "'"
        End If
        If cboPONumber.Text = "" Then
            SteelPOFilter = ""
        Else
            SteelPONumber = Val(cboPONumber.Text)
            strSteelPONumber = CStr(SteelPONumber)

            SteelPOFilter = " AND SteelPONumber = '" + strSteelPONumber + "'"
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            DateFilter = " AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM SteelReceivingLineQuery2 WHERE DivisionID = @DivisionID" + CarbonFilter + SteelSizeFilter + SteelPOFilter + BOLFilter + DateFilter + VendorFilter + " ORDER BY ReceivingDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBegin.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEnd.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReceivingLineQuery2")
        dgvSteelReceivingLines.DataSource = ds.Tables("SteelReceivingLineQuery2")
        con.Close()

        LoadTotals()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSteelReceivingLines.DataSource = Nothing
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass = 'SteelVendor' ORDER BY VendorCode", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboSteelVendor.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboSteelVendor.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelPONumber()
        cmd = New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID ORDER BY SteelPurchaseOrderKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SteelPurchaseOrderHeader")
        cboPONumber.DataSource = ds2.Tables("SteelPurchaseOrderHeader")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY Carbon", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "RawMaterialsTable")
        cboCarbon.DataSource = ds3.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY SteelSize", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "RawMaterialsTable")
        cboSteelSize.DataSource = ds4.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub LoadBOL()
        cmd = New SqlCommand("SELECT DISTINCT SteelBOLNumber FROM SteelReceivingHeaderTable WHERE DivisionID = @DivisionID ORDER BY SteelBOLNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "SteelReceivingHeaderTable")
        cboBOL.DataSource = ds5.Tables("SteelReceivingHeaderTable")
        con.Close()
        cboBOL.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorName()
        Dim VendorName As String = ""

        Dim VendorNameString As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboSteelVendor.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
    End Sub

    Public Sub LoadTotals()
        Dim TotalWeight, TotalAmount As Double

        Dim GetTotalWeightString As String = "SELECT SUM(ReceiveWeight) FROM SteelReceivingLineQuery2 WHERE DivisionID = @DivisionID" + CarbonFilter + SteelSizeFilter + SteelPOFilter + BOLFilter + DateFilter + VendorFilter
        Dim GetTotalWeightCommand As New SqlCommand(GetTotalWeightString, con)
        GetTotalWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetTotalWeightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBegin.Text
        GetTotalWeightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEnd.Text

        Dim GetTotalCostString As String = "SELECT SUM(SteelExtendedCost) FROM SteelReceivingLineQuery2 WHERE DivisionID = @DivisionID" + CarbonFilter + SteelSizeFilter + SteelPOFilter + BOLFilter + DateFilter + VendorFilter
        Dim GetTotalCostCommand As New SqlCommand(GetTotalCostString, con)
        GetTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetTotalCostCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBegin.Text
        GetTotalCostCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEnd.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalWeight = CDbl(GetTotalWeightCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalWeight = 0
        End Try
        Try
            TotalAmount = CDbl(GetTotalCostCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalAmount = 0
        End Try
        con.Close()

        lblTotalCost.Text = FormatCurrency(TotalAmount, 2)
        lblTotalWeight.Text = FormatNumber(TotalWeight, 0)
    End Sub

    Public Sub ClearData()
        cboBOL.SelectedIndex = -1
        cboCarbon.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        cboSteelVendor.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1

        lblTotalCost.Text = ""
        lblTotalWeight.Text = ""


        dtpBegin.Text = ""
        dtpEnd.Text = ""

        chkAllTypes.Checked = False
        chkDateRange.Checked = False

        cboCarbon.Focus()
    End Sub

    Private Sub cboSteelVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelVendor.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintSteelReceivingLines As New PrintSteelReceivingLines()
            Dim Result = NewPrintSteelReceivingLines.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.TextChanged
        If cboSteelSize.Text.StartsWith(".") Then
            cboSteelSize.Text = "0."
            cboSteelSize.Select(cboSteelSize.Text.Length, 0)
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadSteelCarbon()
        LoadSteelSize()
        LoadSteelPONumber()
        LoadVendor()
        LoadBOL()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub dgvSteelReceivingLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelReceivingLines.CellDoubleClick




    End Sub

    Private Sub dgvSteelReceivingLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelReceivingLines.CellValueChanged
        If Me.dgvSteelReceivingLines.RowCount > 0 Then
            Dim RowReceiverNumber, RowLineNumber As Integer
            Dim RowLineComment As String = ""

            Dim RowIndex As Integer = Me.dgvSteelReceivingLines.CurrentCell.RowIndex

            Try
                RowReceiverNumber = Me.dgvSteelReceivingLines.Rows(RowIndex).Cells("SteelReceivingHeaderKeyColumn").Value
            Catch ex As Exception
                RowReceiverNumber = 0
            End Try
            Try
                RowLineNumber = Me.dgvSteelReceivingLines.Rows(RowIndex).Cells("SteelReceivingLineKeyColumn").Value
            Catch ex As Exception
                RowLineNumber = 0
            End Try
            Try
                RowLineComment = Me.dgvSteelReceivingLines.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                RowLineComment = ""
            End Try

            Try
                'Update in database
                cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET LineComment = @LineComment WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                With cmd.Parameters
                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = RowReceiverNumber
                    .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = RowLineNumber
                    .Add("@LineComment", SqlDbType.VarChar).Value = RowLineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                RowLineComment = ""
                RowLineNumber = 0
                RowReceiverNumber = 0
            Catch ex As Exception
                'Skip
            End Try
        End If
    End Sub

    Private Sub dgvSteelReceivingLines_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvSteelReceivingLines.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo = dgvSteelReceivingLines.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                dgvSteelReceivingLines.SelectedCells(0).Selected = False
                dgvSteelReceivingLines.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Selected = True
                dgvSteelReceivingLines.CurrentCell = dgvSteelReceivingLines.Rows(ht.RowIndex).Cells(ht.ColumnIndex)
                'If ht.RowIndex <> -1 Then
                '    If dgvProductionScheduling.Rows(ht.RowIndex).Cells("ProductionNumber").Value = 0 Then
                '        ctmMenu.MenuItems("UpdateProductionQuantity").Enabled = False
                '    Else
                '        ctmMenu.MenuItems("UpdateProductionQuantity").Enabled = True
                '    End If
                'End If

                ctmMenu.Show(dgvSteelReceivingLines, New System.Drawing.Point(e.X, e.Y))
            End If
        End If
    End Sub
End Class