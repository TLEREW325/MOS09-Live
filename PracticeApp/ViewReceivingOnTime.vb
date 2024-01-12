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
Public Class ViewReceivingOnTime
    Inherits System.Windows.Forms.Form

    Dim VendorName, VendorFilter, DateFilter, StatusFilter, POFilter, ReceiverFilter As String
    Dim BeginDate, EndDate As Date
    Dim PONumber, ReceiverNumber As Integer
    Dim strPONumber, strReceiverNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewReceivingOnTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCurrentDivision()
        usefulFunctions.LoadSecurity(Me)
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

    Public Sub ClearVariables()
        VendorName = ""
        VendorFilter = ""
        DateFilter = ""
        StatusFilter = ""
        POFilter = ""
        ReceiverFilter = ""
        PONumber = 0
        ReceiverNumber = 0
        strPONumber = ""
        strReceiverNumber = ""
    End Sub

    Public Sub ClearData()
        cboPONumber.Text = ""
        cboVendorID.Text = ""
        cboStatus.Text = ""
        cboReceiverNumber.Text = ""

        cboPONumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboReceiverNumber.SelectedIndex = -1

        txtVendorName.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboVendorID.Focus()
    End Sub

    Public Sub ShowDataByFilter()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorCode = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
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
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ReceivingOnTimeQuery WHERE DivisionID <> @DivisionID" + POFilter + ReceiverFilter + StatusFilter + VendorFilter + DateFilter + " ORDER BY DivisionID, ReceivingHeaderKey", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceivingOnTimeQuery")
            dgvReceivingPOQuery.DataSource = ds.Tables("ReceivingOnTimeQuery")
            con.Close()
            Me.dgvReceivingPOQuery.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ReceivingOnTimeQuery WHERE DivisionID = @DivisionID" + POFilter + ReceiverFilter + StatusFilter + VendorFilter + DateFilter + " ORDER BY ReceivingHeaderKey DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceivingOnTimeQuery")
            dgvReceivingPOQuery.DataSource = ds.Tables("ReceivingOnTimeQuery")
            con.Close()
            Me.dgvReceivingPOQuery.Columns("DivisionIDColumn").Visible = False
        End If

        LoadCellFormatting()
    End Sub

    Public Sub LoadCellFormatting()
        Dim CountIndex As Integer = 0
        Dim PromiseDate, ReceiveDate As Date

        For Each row As DataGridViewRow In dgvReceivingPOQuery.Rows
            Try
                PromiseDate = dgvReceivingPOQuery.Rows(CountIndex).Cells("ShipDateColumn").Value
            Catch ex As Exception

            End Try
            Try
                ReceiveDate = dgvReceivingPOQuery.Rows(CountIndex).Cells("ReceivingDateColumn").Value
            Catch ex As Exception
                'skip
            End Try
            If ReceiveDate <= PromiseDate Then
                Try
                    dgvReceivingPOQuery.Rows(CountIndex).Cells("ShipDateColumn").Style.ForeColor = Color.Blue
                Catch ex As Exception
                    'skip
                End Try
            Else
                Try
                    dgvReceivingPOQuery.Rows(CountIndex).Cells("ShipDateColumn").Style.ForeColor = Color.Red
                Catch ex As Exception
                    'skip
                End Try
            End If

            CountIndex = CountIndex + 1
        Next
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvReceivingPOQuery.DataSource = Nothing
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode, VendorName FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboVendorID.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadPONumber()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "PurchaseOrderHeaderTable")
        cboPONumber.DataSource = ds2.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadReceiverNumber()
        cmd = New SqlCommand("SELECT ReceivingHeaderKey FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID ORDER BY ReceivingHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ReceivingHeaderTable")
        cboReceiverNumber.DataSource = ds3.Tables("ReceivingHeaderTable")
        con.Close()
        cboReceiverNumber.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadVendor()
        LoadPONumber()
        LoadReceiverNumber()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub dgvReceivingPOQuery_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceivingPOQuery.CellDoubleClick
        Dim PONumber As Integer

        Dim RowIndex As Integer = Me.dgvReceivingPOQuery.CurrentCell.RowIndex

        Try
            PONumber = Me.dgvReceivingPOQuery.Rows(RowIndex).Cells("PONumberColumn").Value
        Catch ex As Exception
            PONumber = 0
        End Try

        GlobalPONumber = PONumber
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
            Using NewPrintPurchaseOrderRemote As New PrintPurchaseOrderRemote
                Dim Result = NewPrintPurchaseOrderRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPurchaseOrder As New PrintPurchaseOrder
                Dim Result = NewPrintPurchaseOrder.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvReceivingPOQuery_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvReceivingPOQuery.CellFormatting
        ' LoadCellFormatting()
    End Sub

    Private Sub dgvReceivingPOQuery_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceivingPOQuery.CellValueChanged
        If canChangeDGVValue(e.RowIndex) Then
            Dim PODate, PromiseDate, ShipVia As String
            Dim PONumber, ReceiverNumber As Integer

            Dim RowIndex As Integer = e.RowIndex

            Try
                PONumber = Me.dgvReceivingPOQuery.Rows(RowIndex).Cells("PONumberColumn").Value
            Catch ex As Exception
                PONumber = 0
            End Try
            Try
                ReceiverNumber = Me.dgvReceivingPOQuery.Rows(RowIndex).Cells("ReceivingHeaderKeyColumn").Value
            Catch ex As Exception
                ReceiverNumber = ""
            End Try
            Try
                PODate = Me.dgvReceivingPOQuery.Rows(RowIndex).Cells("PODateColumn").Value
            Catch ex As Exception
                PODate = ""
            End Try
            Try
                PromiseDate = Me.dgvReceivingPOQuery.Rows(RowIndex).Cells("ShipDateColumn").Value
            Catch ex As Exception
                PromiseDate = ""
            End Try
            Try
                ShipVia = Me.dgvReceivingPOQuery.Rows(RowIndex).Cells("ShipMethodIDColumn").Value
            Catch ex As Exception
                ShipVia = ""
            End Try

            If PONumber = 0 Then
                'Skip
            Else
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET PODate = @PODate, ShipDate = @ShipDate, ShipMethodID = @ShipMethodID WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = PONumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PODate", SqlDbType.VarChar).Value = PODate
                    .Add("@ShipDate", SqlDbType.VarChar).Value = PromiseDate
                    .Add("@ShipMethodID", SqlDbType.VarChar).Value = ShipVia
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            If ReceiverNumber = 0 Then
                'Skip
            Else
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET ShipMethodID = @ShipMethodID, PODate = @PODate WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ShipMethodID", SqlDbType.VarChar).Value = ShipVia
                    .Add("@PODate", SqlDbType.VarChar).Value = PODate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Private Function canChangeDGVValue(ByVal i As Integer) As Boolean
        If dgvReceivingPOQuery.RowCount = 0 Then
            Return False
        End If
        If String.IsNullOrEmpty(dgvReceivingPOQuery.Rows(i).Cells("PODateColumn").Value) Then
            MessageBox.Show("You must enter a date", "Enter a date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvReceivingPOQuery.Rows(i).Cells("PODateColumn").Value.ToString.Split(New String() {"/"}, StringSplitOptions.None).Count <> 3 Then
            MessageBox.Show("You must enter the date in this format: 01/01/2015", "Incorrect format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(dgvReceivingPOQuery.Rows(i).Cells("ShipDateColumn").Value) Then
            MessageBox.Show("You must enter a date", "Enter a date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvReceivingPOQuery.Rows(i).Cells("ShipDateColumn").Value.ToString.Split(New String() {"/"}, StringSplitOptions.None).Count <> 3 Then
            MessageBox.Show("You must enter the date in this format: 01/01/2015", "Incorrect format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Public Sub LoadVendorName()
        'Check to see if line is open or closed
        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
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

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintVendorOnTimeReport As New PrintVendorOnTimeReport
            Dim result = NewPrintVendorOnTimeReport.ShowDialog()
        End Using
    End Sub

    Private Sub PrintOnTimeReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintOnTimeReportToolStripMenuItem.Click
        GDS = ds

        Using NewPrintVendorOnTimeReport As New PrintVendorOnTimeReport
            Dim result = NewPrintVendorOnTimeReport.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvReceivingPOQuery_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvReceivingPOQuery.ColumnHeaderMouseClick
        LoadCellFormatting()
    End Sub
End Class