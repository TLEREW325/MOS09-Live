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
Public Class ViewOpenSOLines
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewOpenSOLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
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

    Private Sub dgvOpenOrderLines_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvOpenOrderLines.CellDoubleClick
        Dim RowSONumber As Integer

        If Me.dgvOpenOrderLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvOpenOrderLines.CurrentCell.RowIndex

            RowSONumber = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

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
                        Dim Result = NewPrintSalesOrderRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintSalesOrder As New PrintSalesOrder
                        Dim Result = NewPrintSalesOrder.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Public Sub ShowOpenSOLines()
        cmd = New SqlCommand("SELECT * FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionKey AND QuantityOpen > 0 AND SOStatus <> @SOStatus AND LineStatus <> @LineStatus ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderQuantityStatus")
        dgvOpenOrderLines.DataSource = ds.Tables("SalesOrderQuantityStatus")
        con.Close()

        'Get Line Data
        Dim DropShipPONumber As Integer = 0
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvOpenOrderLines.Rows
            DropShipPONumber = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("DropShipPONumberColumn").Value

            If DropShipPONumber > 0 Then
                Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SOTypeColumn").Value = "DROP SHIP"
                Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SOTypeColumn").Style.ForeColor = Color.Red
            Else
                Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SOTypeColumn").Value = "STANDARD"
                Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SOTypeColumn").Style.ForeColor = Color.Blue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadOpenTotal()
        Dim OpenTotal As Double = 0

        Dim OpenTotalStatement As String = "SELECT SUM(SOExtendedAmount) FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionKey AND QuantityOpen > 0 AND SOStatus <> @SOStatus AND LineStatus <> @LineStatus"
        Dim OpenTotalCommand As New SqlCommand(OpenTotalStatement, con)
        OpenTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        OpenTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        OpenTotalCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OpenTotal = CDbl(OpenTotalCommand.ExecuteScalar)
        Catch ex As Exception
            OpenTotal = 0
        End Try
        con.Close()

        txtTotalOpenOrders.Text = FormatCurrency(OpenTotal, 2)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ShowOpenSOLines()
        LoadOpenTotal()
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintOpenSalesOrderLineReport As New PrintOpenSalesOrderLineReport
            Dim Result = NewPrintOpenSalesOrderLineReport.ShowDialog
        End Using
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalOpenOrderReport = "YES"

        GDS = ds

        Using NewPrintOpenSalesOrderLineReport As New PrintOpenSalesOrderLineReport
            Dim Result = NewPrintOpenSalesOrderLineReport.ShowDialog
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSOForm.Click
        Dim RowSONumber As Integer = 0

        If Me.dgvOpenOrderLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvOpenOrderLines.CurrentCell.RowIndex

            RowSONumber = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

            GlobalSONumber = RowSONumber
            GlobalDivisionCode = cboDivisionID.Text
        End If

        Dim NewSOForm As New SOForm
        NewSOForm.Show()
    End Sub

    Private Sub PrintBOListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBOListingToolStripMenuItem.Click
        Dim RowCustomer As String = ""

        If Me.dgvOpenOrderLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvOpenOrderLines.CurrentCell.RowIndex

            RowCustomer = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("CustomerIDColumn").Value

            BackorderCustomer = RowCustomer
            GlobalDivisionCode = cboDivisionID.Text
            BackorderReportFilter = "CUSTOMER"

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
                Using NewPrintBackOrdersFilteredRemote As New PrintBackOrdersFilteredRemote
                    Dim Result = NewPrintBackOrdersFilteredRemote.ShowDialog()
                End Using
            Else
                Using NewPrintBackOrdersFiltered As New PrintBackOrdersFiltered
                    Dim Result = NewPrintBackOrdersFiltered.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub dgvOpenOrderLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpenOrderLines.CellValueChanged
        Dim LineSONumber As Integer = 0
        Dim LineSOLineNumber As Integer = 0
        Dim LineLineComment As String = ""
        Dim LineLeadTime As String = ""

        If Me.dgvOpenOrderLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvOpenOrderLines.CurrentCell.RowIndex

            Try
                LineSONumber = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value
            Catch ex As Exception
                LineSONumber = 0
            End Try
            Try
                LineSOLineNumber = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SalesOrderLineKeyColumn").Value
            Catch ex As Exception
                LineSOLineNumber = 0
            End Try
            Try
                LineLineComment = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                LineLineComment = ""
            End Try
            Try
                LineLeadTime = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("LeadTimeColumn").Value
            Catch ex As Exception
                LineLeadTime = ""
            End Try

            Try
                'Update Item List with new Standard Cost and Price
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LeadTime = @LeadTime, LineComment = @LineComment WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = LineSONumber
                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = LineSOLineNumber
                    .Add("@LeadTime", SqlDbType.VarChar).Value = LineLeadTime
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineLineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip - no price sheet data available
            End Try
        Else
            'Skip update
        End If
    End Sub

    Private Sub dgvOpenOrderLines_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOpenOrderLines.ColumnHeaderMouseClick
        'Get Line Data
        Dim DropShipPONumber As Integer = 0
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvOpenOrderLines.Rows
            DropShipPONumber = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("DropShipPONumberColumn").Value

            If DropShipPONumber > 0 Then
                Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SOTypeColumn").Value = "DROP SHIP"
                Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SOTypeColumn").Style.ForeColor = Color.Red
            Else
                Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SOTypeColumn").Value = "STANDARD"
                Me.dgvOpenOrderLines.Rows(RowIndex).Cells("SOTypeColumn").Style.ForeColor = Color.Blue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        ShowOpenSOLines()
        LoadOpenTotal()
    End Sub
End Class