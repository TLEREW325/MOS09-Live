Imports System
Imports System.Math
Imports System.Net.Mail
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class CheckBackOrders
    Inherits System.Windows.Forms.Form

    'Variable for third party billing
    Dim CustomerTextFilter, ShipViaTextFilter As String
    Dim MasterPickTicketNumber As Integer = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Public Sub ShowDataByFilters()
        If txtCustomer.Text <> "" Then
            If chkExcludeCustomer.Checked = True Then
                CustomerTextFilter = " AND CustomerID NOT LIKE '%" + txtCustomer.Text + "%'"
            ElseIf chkIncludeCustomer.Checked = True Then
                CustomerTextFilter = " AND CustomerID LIKE '%" + txtCustomer.Text + "%'"
            Else
                CustomerTextFilter = ""
            End If
        Else
            CustomerTextFilter = ""
        End If
        If txtShipVia.Text <> "" Then
            If chkExcludeShipVia.Checked = True Then
                ShipViaTextFilter = " AND ShipVia NOT LIKE '%" + txtShipVia.Text + "%'"
            ElseIf chkIncludeShipVia.Checked = True Then
                ShipViaTextFilter = " AND ShipVia LIKE '%" + txtShipVia.Text + "%'"
            Else
                ShipViaTextFilter = ""
            End If
        Else
            ShipViaTextFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM PickListHeaderTable WHERE DivisionID = @DivisionID AND PLStatus = @PLStatus" + CustomerTextFilter + ShipViaTextFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "PickListHeaderTable")
        dgvViewOpenPicks.DataSource = ds1.Tables("PickListHeaderTable")
        con.Close()
    End Sub

    Public Sub LoadUpdateQOH()
        Dim CountPickLines As Integer = 0
        Dim Counter As Integer = 0
        Dim QOHPartNumber As String = ""
        Dim PickQOH As Double = 0

        Try
            'Count Lines in PickListLineTable for selected Pick Ticket
            Dim CountPickLinesStatement As String = "SELECT COUNT(PickListHeaderKey) FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
            Dim CountPickLinesCommand As New SqlCommand(CountPickLinesStatement, con)
            CountPickLinesCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = MasterPickTicketNumber
            CountPickLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPickLines = CInt(CountPickLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountPickLines = 0
            End Try
            con.Close()

            'Set Counter
            Counter = 1

            'Run FOR/NEXT Loop for each line to update QOH
            For i As Integer = 1 To CountPickLines
                'Get Part Number from Pick Ticket
                Dim GetPartNumberStatement As String = "SELECT ItemID FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID AND PickListLineKey = @PickListLineKey"
                Dim GetPartNumberCommand As New SqlCommand(GetPartNumberStatement, con)
                GetPartNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = MasterPickTicketNumber
                GetPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetPartNumberCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = Counter

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    QOHPartNumber = CStr(GetPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    QOHPartNumber = ""
                End Try
                con.Close()

                Dim GetQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetQOHCommand As New SqlCommand(GetQOHStatement, con)
                GetQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = QOHPartNumber
                GetQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PickQOH = CDbl(GetQOHCommand.ExecuteScalar)
                Catch ex As Exception
                    PickQOH = 0
                End Try
                con.Close()

                'Update PickList
                cmd = New SqlCommand("UPDATE PickListLineTable SET QOH = @QOH WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = MasterPickTicketNumber
                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = Counter
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@QOH", SqlDbType.VarChar).Value = PickQOH
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Counter = Counter + 1
            Next

            PickQOH = 0
            CountPickLines = 0
            Counter = 0
            QOHPartNumber = ""
        Catch ex As Exception
            'Log error on update failure
            Dim TempPickNumber As Integer = 0
            Dim strPickNumber As String
            TempPickNumber = MasterPickTicketNumber
            strPickNumber = CStr(TempPickNumber)

            ErrorDate = Now()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Check Back Orders --- Update Pick QOH Failure"
            ErrorReferenceNumber = "Pick Ticket # " + strPickNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
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

    Public Sub ClearData()
        chkExcludeCustomer.Checked = False
        chkExcludeShipVia.Checked = False
        chkIncludeCustomer.Checked = False
        chkIncludeShipVia.Checked = False

        txtCustomer.Clear()
        txtShipVia.Clear()
    End Sub

    Private Sub CheckBackOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        Me.dgvOpenPicksWithQOH.Visible = False
        Me.dgvViewOpenPicks.Visible = True

        ClearData()
    End Sub

    Private Sub cmdCheckForCompletedBackorders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckForCompletedBackorders.Click
        For Each Row As DataGridViewRow In dgvViewOpenPicks.Rows
            Dim LinePickTicketNumber As Integer = 0
            Dim LineSONumber As Integer = 0
            Dim LineCustomer As String = ""
            Dim LineShipVia As String = ""
            Dim LineComment As String = ""
            Dim strLineSONumber As String = ""
            Dim strLinePickTicketNumber As String = ""
            Dim CheckCount As Integer = 0
            Dim LineDate As String = ""

            Try
                LinePickTicketNumber = Row.Cells("PickListHeaderKeyColumn").Value
            Catch ex As System.Exception
                LinePickTicketNumber = 0
            End Try
            Try
                LineSONumber = Row.Cells("SalesOrderHeaderKeyColumn").Value
            Catch ex As System.Exception
                LineSONumber = 0
            End Try
            Try
                LineCustomer = Row.Cells("CustomerIDColumn").Value
            Catch ex As System.Exception
                LineCustomer = ""
            End Try
            Try
                LIneShipVia = Row.Cells("ShipViaColumn").Value
            Catch ex As System.Exception
                LIneShipVia = ""
            End Try
            Try
                LineComment = Row.Cells("CommentColumn").Value
            Catch ex As System.Exception
                LineComment = ""
            End Try
            Try
                LineDate = Row.Cells("OriginalPickDateColumn").Value
            Catch ex As System.Exception
                LineDate = ""
            End Try

            strLinePickTicketNumber = CStr(LinePickTicketNumber)
            strLineSONumber = CStr(LineSONumber)

            Dim CheckCountString As String = "SELECT COUNT(PickListHeaderKey) FROM PickListLineQOH WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID AND QuantityOnHand < Quantity"
            Dim CheckCountCommand As New SqlCommand(CheckCountString, con)
            CheckCountCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = LinePickTicketNumber
            CheckCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckCount = CInt(CheckCountCommand.ExecuteScalar)
            Catch ex As Exception
                CheckCount = 0
            End Try
            con.Close()

            If CheckCount = 0 Then
                'Add line to datagrid
                Me.dgvOpenPicksWithQOH.Rows.Add(strLinePickTicketNumber, strLineSONumber, LineCustomer, LineShipVia, LineComment, LineDate)
            Else
                'Skip Pick Ticket
            End If
        Next

        Me.dgvViewOpenPicks.Visible = False
        Me.dgvOpenPicksWithQOH.Visible = True

    End Sub

    Private Sub cmdViewOpenOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewOpenOrders.Click
        Me.dgvViewOpenPicks.DataSource = Nothing
        Me.dgvOpenPicksWithQOH.RowCount = 0
        Me.dgvViewOpenPicks.Visible = True
        Me.dgvOpenPicksWithQOH.Visible = False

        ShowDataByFilters()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvOpenPicksWithQOH_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpenPicksWithQOH.CellValueChanged
        If Me.dgvOpenPicksWithQOH.RowCount > 0 Then
            Dim RowPickNumber As Integer = 0
            Dim RowComment As String = ""

            Dim RowIndex As Integer = Me.dgvOpenPicksWithQOH.CurrentCell.RowIndex

            RowPickNumber = Me.dgvOpenPicksWithQOH.Rows(RowIndex).Cells("PickTicketNumber").Value
            RowComment = Me.dgvOpenPicksWithQOH.Rows(RowIndex).Cells("Comment").Value
            GlobalDivisionCode = cboDivisionID.Text

            Try
                'Update PickList for a reprint
                cmd = New SqlCommand("UPDATE PickListHeaderTable SET Comment = @Comment WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = RowPickNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempPickNumber As Integer = 0
                Dim strPickNumber As String
                TempPickNumber = RowPickNumber
                strPickNumber = CStr(TempPickNumber)

                ErrorDate = Now()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Check Back Orders --- Update comment field"
                ErrorReferenceNumber = "Pick Ticket # " + strPickNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Sub dgvOpenPicksWithQOH_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpenPicksWithQOH.CellDoubleClick
        If dgvOpenPicksWithQOH.RowCount > 0 Then
            Dim RowPickNumber As Integer = 0
            Dim RowIndex As Integer = Me.dgvOpenPicksWithQOH.CurrentCell.RowIndex

            RowPickNumber = Me.dgvOpenPicksWithQOH.Rows(RowIndex).Cells("PickTicketNumber").Value

            GlobalDivisionCode = cboDivisionID.Text
            GlobalPickListNumber = RowPickNumber
            MasterPickTicketNumber = RowPickNumber

            LoadUpdateQOH()

            'Update PickList for a reprint
            cmd = New SqlCommand("UPDATE PickListHeaderTable SET PickCount = @PickCount WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@PickCount", SqlDbType.VarChar).Value = 2
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

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
                Using NewReprintPickListRemote As New ReprintPickListRemote
                    Dim result = NewReprintPickListRemote.ShowDialog()
                End Using
            Else
                Using NewReprintPickList As New ReprintPickList
                    Dim result = NewReprintPickList.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        Me.dgvViewOpenPicks.DataSource = Nothing
        Me.dgvOpenPicksWithQOH.RowCount = 0
        Me.dgvViewOpenPicks.Visible = True
        Me.dgvOpenPicksWithQOH.Visible = False
        ClearData()
    End Sub

    Private Sub chkExcludeShipVia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExcludeShipVia.CheckedChanged
        If chkExcludeShipVia.Checked = True Then
            chkIncludeShipVia.Checked = False
        End If
    End Sub

    Private Sub chkIncludeShipVia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludeShipVia.CheckedChanged
        If chkIncludeShipVia.Checked = True Then
            chkExcludeShipVia.Checked = False
        End If
    End Sub

    Private Sub chkExcludeCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExcludeCustomer.CheckedChanged
        If chkExcludeCustomer.Checked = True Then
            chkIncludeCustomer.Checked = False
        End If
    End Sub

    Private Sub chkIncludeCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludeCustomer.CheckedChanged
        If chkIncludeCustomer.Checked = True Then
            chkExcludeCustomer.Checked = False
        End If
    End Sub

End Class