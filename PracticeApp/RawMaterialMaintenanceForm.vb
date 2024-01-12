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
Public Class RawMaterialMaintenanceForm
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim CarbonFilter, SteelSizeFilter, RMIDFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub RawMaterialMaintenanceForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowData()
        LoadRMID()
        LoadSteelCarbon()
        LoadSteelSize()
        LoadSecurity()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM RawMaterialsTable ORDER BY RMID ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RawMaterialsTable")
        dgvRawMaterials.DataSource = ds.Tables("RawMaterialsTable")
        con.Close()

        LoadFormatting()
    End Sub

    Public Sub ShowDataByFilters()
        If cboSearchCarbon.Text = "" Then
            CarbonFilter = ""
        Else
            CarbonFilter = " AND Carbon = '" + cboSearchCarbon.Text + "'"
        End If
        If cboSearchRMID.Text = "" Then
            RMIDFilter = ""
        Else
            RMIDFilter = " AND RMID = '" + cboSearchRMID.Text + "'"
        End If
        If cboSearchSteelSize.Text = "" Then
            SteelSizeFilter = ""
        Else
            SteelSizeFilter = " AND SteelSize = '" + cboSearchSteelSize.Text + "'"
        End If

        cmd = New SqlCommand("SELECT * FROM RawMaterialsTable WHERE DivisionID = 'TWD'" + CarbonFilter + SteelSizeFilter + RMIDFilter + " ORDER BY RMID ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RawMaterialsTable")
        dgvRawMaterials.DataSource = ds.Tables("RawMaterialsTable")
        con.Close()

        LoadFormatting()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvRawMaterials.DataSource = Nothing
    End Sub

    Public Sub LoadSteelCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboSearchCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboSearchCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSearchSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSearchSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadRMID()
        cmd = New SqlCommand("SELECT RMID FROM RawMaterialsTable ORDER BY RMID ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "RawMaterialsTable")
        cboSearchRMID.DataSource = ds3.Tables("RawMaterialsTable")
        con.Close()
        cboSearchRMID.SelectedIndex = -1
    End Sub

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length > 400 Then
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

    Public Sub LoadFormatting()
        'Load Formatting for closed steel items
        Dim SteelStatus As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvRawMaterials.Rows
            Try
                SteelStatus = row.Cells("SteelStatusColumn").Value
            Catch ex As System.Exception
                SteelStatus = ""
            End Try

            If SteelStatus = "OPEN" Then
                Me.dgvRawMaterials.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf SteelStatus = "CLOSED" Then
                Me.dgvRawMaterials.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Red
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadSecurity()
        If EmployeeSecurityCode = "1001" Or EmployeeSalespersonCode = "1002" Then
            grpDeleteSteel.Enabled = True
            gpxEnterNewRawMaterial.Enabled = True
            dgvRawMaterials.ReadOnly = False

            'Enable certain fields in the datagrid for editing
            Me.dgvRawMaterials.Columns("CarbonColumn").ReadOnly = False
            Me.dgvRawMaterials.Columns("SteelSizeColumn").ReadOnly = False
        End If

        If EmployeeLoginName = "TSKINNER" Or EmployeeLoginName = "JHOMAN" Or EmployeeLoginName = "JSCHULTZ" Or EmployeeLoginName = "TWHITE" Or EmployeeLoginName = "DBLACKBURN" Or EmployeeLoginName = "SAMRAY" Or EmployeeLoginName = "RBENNETT" Then
            grpDeleteSteel.Enabled = True
            gpxEnterNewRawMaterial.Enabled = True
            dgvRawMaterials.ReadOnly = False
        End If
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClearSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearSearch.Click
        cboSearchCarbon.SelectedIndex = -1
        cboSearchRMID.SelectedIndex = -1
        cboSearchSteelSize.SelectedIndex = -1

        ShowData()
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        'Validate Fields
        If txtCarbon.Text = "" Then
            MsgBox("You must enter carbon/alloy.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtSteelSize.Text = "" Then
            MsgBox("You must enter steel diameter.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtRMID.Text = "" Then
            MsgBox("New RMID not created - try again.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtDescription.Text = "" Then
            MsgBox("You must enter a steel description.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboSteelClass.Text = "" Then
            MsgBox("You must enter a steel class.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '****************************************************************************
        'Check To see of Carbon/Steel Size already exists
        Dim CheckForExistingRMID As Integer = 0

        Dim CheckForExistingRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim CheckForExistingRMIDCommand As New SqlCommand(CheckForExistingRMIDStatement, con)
        CheckForExistingRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = txtCarbon.Text
        CheckForExistingRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckForExistingRMID = CInt(CheckForExistingRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckForExistingRMID = 0
        End Try
        con.Close()

        If CheckForExistingRMID >= 1 Then
            MsgBox("Steel with this Carbon/Size already exists.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*******************************************************************************************
        Try
            'Create Steel in Raw Materials Table
            cmd = New SqlCommand("INSERT INTO RawMaterialsTable (RMID, Description, Carbon, SteelSize, BeginningBalance, CreationDate, DivisionID, SteelClass, SteelStatus, CloseDate) values (@RMID, @Description, @Carbon, @SteelSize, @BeginningBalance, @CreationDate, @DivisionID, @SteelClass, @SteelStatus, @CloseDate)", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
                .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = txtCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSize.Text
                .Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
                .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                .Add("@SteelClass", SqlDbType.VarChar).Value = cboSteelClass.Text
                .Add("@SteelStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@CloseDate", SqlDbType.VarChar).Value = "1/1/1900"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Write to error log when a new steel is created
            ErrorComment = "New Steel added to database - " + txtRMID.Text
            ErrorDate = Today()
            ErrorDescription = "Raw Materials Form - Add Steel"
            ErrorReferenceNumber = "NONE"
            ErrorUser = EmployeeLoginName
            ErrorDivision = EmployeeCompanyCode

            TFPErrorLogUpdate()
        Catch ex As Exception
            'Write to error log when a new steel is created
            ErrorComment = "Failure on Add New Steel"
            ErrorDate = Today()
            ErrorDescription = "Raw Materials Form - Add Steel"
            ErrorReferenceNumber = "NONE"
            ErrorUser = EmployeeLoginName
            ErrorDivision = EmployeeCompanyCode

            TFPErrorLogUpdate()

            MsgBox("Process erred - try again.", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try

        MsgBox("New steel added.", MsgBoxStyle.OkOnly)
        cmdClear_Click(sender, e)
        ShowData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtCarbon.Clear()
        txtRMID.Clear()
        txtSteelSize.Clear()
        txtDescription.Clear()
        txtRMIDFromDatagrid.Clear()

        cboSteelClass.SelectedIndex = -1
        dtpCreationDate.Text = ""

        txtCarbon.Focus()
    End Sub

    Private Sub cmdDeactivateSteel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeactivateSteel.Click
        If txtRMIDFromDatagrid.Text = "" Then
            MsgBox("You must select a raw material from the grid.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check for Activity
        Dim CheckSteelActivity As Double = 0
        Dim CheckSteelQOH As Double = 0
        Dim SteelOnFOX1, SteelOnFOX2 As Integer
        Dim CloseDate As Date = Now()

        Dim CheckSteelActivityStatement As String = "SELECT SUM(QuantityOpen) FROM SteelPurchaseQuantityStatus WHERE RMID = @RMID AND Status = @Status AND LineStatus = @LineStatus"
        Dim CheckSteelActivityCommand As New SqlCommand(CheckSteelActivityStatement, con)
        CheckSteelActivityCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.text
        CheckSteelActivityCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        CheckSteelActivityCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

        Dim CheckSteelQOHStatement As String = "SELECT SteelEndingInventory FROM SteelInventoryTotals WHERE RMID = @RMID"
        Dim CheckSteelQOHCommand As New SqlCommand(CheckSteelQOHStatement, con)
        CheckSteelQOHCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text

        Dim SteelOnFOX1Statement As String = "SELECT COUNT(FOXNumber) FROM FOXTable WHERE RMID = @RMID AND Status = @Status"
        Dim SteelOnFOX1Command As New SqlCommand(SteelOnFOX1Statement, con)
        SteelOnFOX1Command.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text
        SteelOnFOX1Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"

        Dim SteelOnFOX2Statement As String = "SELECT COUNT(FOXNumber) FROM FOXTable WHERE ScheduledRMID = @RMID AND Status = @Status"
        Dim SteelOnFOX2Command As New SqlCommand(SteelOnFOX2Statement, con)
        SteelOnFOX2Command.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text
        SteelOnFOX2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckSteelActivity = CDbl(CheckSteelActivityCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSteelActivity = 0
        End Try
        Try
            CheckSteelQOH = CDbl(CheckSteelQOHCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSteelQOH = 0
        End Try
        Try
            SteelOnFOX1 = CInt(SteelOnFOX1Command.ExecuteScalar)
        Catch ex As Exception
            SteelOnFOX1 = 0
        End Try
        Try
            SteelOnFOX2 = CInt(SteelOnFOX2Command.ExecuteScalar)
        Catch ex As Exception
            SteelOnFOX2 = 0
        End Try
        con.Close()

        If CheckSteelActivity > 0 Then
            MsgBox("You cannot de-activate a steel with an open PO Quantity.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If CheckSteelQOH > 0 Then
            MsgBox("You cannot de-activate a steel with QOH <> 0.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If SteelOnFOX1 > 0 Then
            MsgBox("You cannot de-activate a steel on an active FOX.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If SteelOnFOX2 > 0 Then
            MsgBox("You cannot de-activate a steel on an active FOX.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            cmd = New SqlCommand("UPDATE RawMaterialsTable SET SteelStatus = @SteelStatus, CloseDate = @CloseDate WHERE RMID = @RMID", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text
                .Add("@SteelStatus", SqlDbType.VarChar).Value = "CLOSED"
                .Add("@CloseDate", SqlDbType.VarChar).Value = CloseDate
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Write to error log when a new steel is created
            ErrorComment = "Failure on De-Activate Steel - " + txtRMIDFromDatagrid.Text
            ErrorDate = Today()
            ErrorDescription = "Raw Materials Form - De-activate Steel"
            ErrorReferenceNumber = "NONE"
            ErrorUser = EmployeeLoginName
            ErrorDivision = EmployeeCompanyCode

            TFPErrorLogUpdate()
        End Try

        MsgBox("Steel has been de-activated", MsgBoxStyle.OkOnly)
        ShowData()

        txtRMIDFromDatagrid.Clear()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If txtRMIDFromDatagrid.Text = "" Then
            MsgBox("You must select a raw material from the grid.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check for Activity
        Dim CheckSteelActivity As Double = 0
        Dim CheckSteelQOH As Double = 0
        Dim SteelOnFOX1, SteelOnFOX2 As Integer
        Dim CountSteelTransactions As Integer = 0
        Dim CountSteelOnLots As Integer = 0
        Dim GetCarbon, GetSteelSize As String
        Dim CountHeatFiles As Integer = 0

        'Get Carbon/Steel from RMID to check heat log
        Dim GetCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim GetCarbonCommand As New SqlCommand(GetCarbonStatement, con)
        GetCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text

        Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
        GetSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetCarbon = CStr(GetCarbonCommand.ExecuteScalar)
        Catch ex As Exception
            GetCarbon = ""
        End Try
        Try
            GetSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
        Catch ex As Exception
            GetSteelSize = ""
        End Try
        con.Close()

        Dim CountHeatFilesStatement As String = "SELECT COUNT(HeatFileNumber) FROM HeatNumberLog WHERE SteelType = @SteelType AND SteelSize = @SteelSize"
        Dim CountHeatFilesCommand As New SqlCommand(CountHeatFilesStatement, con)
        CountHeatFilesCommand.Parameters.Add("@SteelType", SqlDbType.VarChar).Value = GetCarbon
        CountHeatFilesCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = GetSteelSize

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountHeatFiles = CInt(CountHeatFilesCommand.ExecuteScalar)
        Catch ex As Exception
            CountHeatFiles = 0
        End Try
        con.Close()

        If CountHeatFiles > 0 Then
            MsgBox("You cannot delete a steel with a heat record.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************************************
        Dim CountSteelTransactionsStatement As String = "SELECT COUNT(TransactionNumber) FROM SteelTransactionTable WHERE RMID = @RMID"
        Dim CountSteelTransactionsCommand As New SqlCommand(CountSteelTransactionsStatement, con)
        CountSteelTransactionsCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text

        Dim CountSteelOnLotsStatement As String = "SELECT COUNT(LotNumber) FROM LotNumber WHERE RMID = @RMID"
        Dim CountSteelOnLotsCommand As New SqlCommand(CountSteelOnLotsStatement, con)
        CountSteelOnLotsCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text

        Dim CheckSteelActivityStatement As String = "SELECT SUM(QuantityOpen) FROM SteelPurchaseQuantityStatus WHERE RMID = @RMID AND Status = @Status AND LineStatus = @LineStatus"
        Dim CheckSteelActivityCommand As New SqlCommand(CheckSteelActivityStatement, con)
        CheckSteelActivityCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text
        CheckSteelActivityCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        CheckSteelActivityCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

        Dim CheckSteelQOHStatement As String = "SELECT SteelEndingInventory FROM SteelInventoryTotals WHERE RMID = @RMID"
        Dim CheckSteelQOHCommand As New SqlCommand(CheckSteelQOHStatement, con)
        CheckSteelQOHCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text

        Dim SteelOnFOX1Statement As String = "SELECT COUNT(FOXNumber) FROM FOXTable WHERE RMID = @RMID"
        Dim SteelOnFOX1Command As New SqlCommand(SteelOnFOX1Statement, con)
        SteelOnFOX1Command.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text

        Dim SteelOnFOX2Statement As String = "SELECT COUNT(FOXNumber) FROM FOXTable WHERE ScheduledRMID = @RMID"
        Dim SteelOnFOX2Command As New SqlCommand(SteelOnFOX2Statement, con)
        SteelOnFOX2Command.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountSteelTransactions = CInt(CountSteelTransactionsCommand.ExecuteScalar)
        Catch ex As Exception
            CountSteelTransactions = 0
        End Try
        Try
            CountSteelOnLots = CInt(CountSteelOnLotsCommand.ExecuteScalar)
        Catch ex As Exception
            CountSteelOnLots = 0
        End Try
        Try
            CheckSteelActivity = CDbl(CheckSteelActivityCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSteelActivity = 0
        End Try
        Try
            CheckSteelQOH = CDbl(CheckSteelQOHCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSteelQOH = 0
        End Try
        Try
            SteelOnFOX1 = CInt(SteelOnFOX1Command.ExecuteScalar)
        Catch ex As Exception
            SteelOnFOX1 = 0
        End Try
        Try
            SteelOnFOX2 = CInt(SteelOnFOX2Command.ExecuteScalar)
        Catch ex As Exception
            SteelOnFOX2 = 0
        End Try
        con.Close()

        If CountSteelTransactions > 0 Then
            MsgBox("You cannot delete a steel with history.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If CountSteelOnLots > 0 Then
            MsgBox("You cannot delete a steel attached to a lot number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If CheckSteelActivity > 0 Then
            MsgBox("You cannot delete a steel with an open PO Quantity.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If CheckSteelQOH > 0 Then
            MsgBox("You cannot delete a steel with QOH <> 0.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If SteelOnFOX1 > 0 Then
            MsgBox("You cannot delete a steel on an active FOX.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If SteelOnFOX2 > 0 Then
            MsgBox("You cannot delete a steel on an active FOX.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            cmd = New SqlCommand("DELETE FROM RawMaterialsTable WHERE RMID = @RMID", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Write to error log when a new steel is created
            ErrorComment = "Failure on Delete Steel - " + txtRMIDFromDatagrid.Text
            ErrorDate = Today()
            ErrorDescription = "Raw Materials Form - DELETE STEEL"
            ErrorReferenceNumber = "NONE"
            ErrorUser = EmployeeLoginName
            ErrorDivision = EmployeeCompanyCode

            TFPErrorLogUpdate()
        End Try

        MsgBox("Steel has been deleted.", MsgBoxStyle.OkOnly)

        ShowData()
        txtRMIDFromDatagrid.Clear()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ShowData()

        cboSearchCarbon.SelectedIndex = -1
        cboSearchRMID.SelectedIndex = -1
        cboSearchSteelSize.SelectedIndex = -1
        cboSteelClass.SelectedIndex = -1

        txtCarbon.Clear()
        txtDescription.Clear()
        txtRMID.Clear()
        txtRMIDFromDatagrid.Clear()
        txtSteelSize.Clear()

        cboSearchCarbon.Focus()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalSteelListFromRM = "RAW MATERIALS"

        Using NewPrintSteelList As New PrintSteelList
            Dim result = NewPrintSteelList.ShowDialog
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadNewRMID()
        'Define Number of spaces
        Dim OneSpace As String = " "
        Dim TwoSpaces As String = "  "
        Dim ThreeSpaces As String = "   "
        Dim FourSpaces As String = "    "
        Dim FiveSpaces As String = "     "
        Dim SixSpaces As String = "      "
        Dim SevenSpaces As String = "       "
        Dim EightSpaces As String = "        "
        Dim NineSpaces As String = "         "
        Dim TenSpaces As String = "          "
        Dim ElevenSpaces As String = "           "
        Dim TwelveSpaces As String = "            "
        Dim ThirteenSpaces As String = "             "
        Dim FourteenSpaces As String = "              "
        Dim FifteenSpaces As String = "               "

        'Create New RMID 
        Dim CountCarbon As Integer = 0
        Dim CountSteelSize As Integer = 0
        Dim CarbonField As String = ""
        Dim SteelSizeField As String = ""
        Dim NewRMID As String = ""
        Dim NumberOfSpaces As Integer = 0
        Dim strNumberOfSpaces As String = ""

        CountCarbon = txtCarbon.TextLength
        CountSteelSize = txtSteelSize.TextLength

        If CountCarbon + CountSteelSize < 5 Then
            MsgBox("Carbon/Size must be at least 5 characters..", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If CountSteelSize + CountCarbon > 20 Then
            MsgBox("RMID cannot exceed 20 characters.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            NumberOfSpaces = 20 - (CountCarbon + CountSteelSize)
        End If

        Select Case NumberOfSpaces
            Case 0
                strNumberOfSpaces = "-"
            Case 1
                strNumberOfSpaces = OneSpace
            Case 2
                strNumberOfSpaces = TwoSpaces
            Case 3
                strNumberOfSpaces = ThreeSpaces
            Case 4
                strNumberOfSpaces = FourSpaces
            Case 5
                strNumberOfSpaces = FiveSpaces
            Case 6
                strNumberOfSpaces = SixSpaces
            Case 7
                strNumberOfSpaces = SevenSpaces
            Case 8
                strNumberOfSpaces = EightSpaces
            Case 9
                strNumberOfSpaces = NineSpaces
            Case 10
                strNumberOfSpaces = TenSpaces
            Case 11
                strNumberOfSpaces = ElevenSpaces
            Case 12
                strNumberOfSpaces = TwelveSpaces
            Case 13
                strNumberOfSpaces = ThirteenSpaces
            Case 14
                strNumberOfSpaces = FourteenSpaces
            Case 15
                strNumberOfSpaces = FifteenSpaces
        End Select

        NewRMID = txtCarbon.Text + strNumberOfSpaces + txtSteelSize.Text
        txtRMID.Text = NewRMID
    End Sub

    Private Sub txtCarbon_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCarbon.LostFocus
        If txtCarbon.Text = "" Or txtSteelSize.Text = "" Then
            'Do nothing
            txtRMID.Clear()
        Else
            LoadNewRMID()
        End If
    End Sub

    Private Sub txtSteelSize_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSteelSize.LostFocus
        If txtCarbon.Text = "" Or txtSteelSize.Text = "" Then
            'Do nothing
            txtRMID.Clear()
        Else
            If txtSteelSize.Text.StartsWith(".") Then
                txtSteelSize.Text = "0" + txtSteelSize.Text
            End If

            LoadNewRMID()
        End If
    End Sub

    Private Sub dgvRawMaterials_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRawMaterials.CellClick
        Dim LineRMID As String = ""

        If Me.dgvRawMaterials.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvRawMaterials.CurrentCell.RowIndex

            Try
                LineRMID = Me.dgvRawMaterials.Rows(RowIndex).Cells("RMIDColumn").Value
            Catch ex As Exception
                LineRMID = ""
            End Try

            txtRMIDFromDatagrid.Text = LineRMID
        End If
    End Sub

    Private Sub dgvRawMaterials_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRawMaterials.CellContentClick
        Dim LineRMID As String = ""

        If Me.dgvRawMaterials.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvRawMaterials.CurrentCell.RowIndex

            Try
                LineRMID = Me.dgvRawMaterials.Rows(RowIndex).Cells("RMIDColumn").Value
            Catch ex As Exception
                LineRMID = ""
            End Try

            txtRMIDFromDatagrid.Text = LineRMID
        End If
    End Sub

    Private Sub dgvRawMaterials_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRawMaterials.CellDoubleClick
        'Open view to show steel of FOXES
        Dim LineRMID As String = ""

        If Me.dgvRawMaterials.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvRawMaterials.CurrentCell.RowIndex

            Try
                LineRMID = Me.dgvRawMaterials.Rows(RowIndex).Cells("RMIDColumn").Value
            Catch ex As Exception
                LineRMID = ""
            End Try

            GlobalSteelRMID = LineRMID

            Using NewRawMaterialsPopup As New RawMaterialsFOXSteelPopup
                Dim Result = NewRawMaterialsPopup.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvRawMaterials_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRawMaterials.CellValueChanged
        Dim LineRMID As String = ""
        Dim LineDescription As String = ""
        Dim LineSteelClass As String = ""
        Dim LineSteelCarbon As String = ""
        Dim LineSteelSize As String = ""

        If Me.dgvRawMaterials.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvRawMaterials.CurrentCell.RowIndex

            Try
                LineRMID = Me.dgvRawMaterials.Rows(RowIndex).Cells("RMIDColumn").Value
            Catch ex As Exception
                LineRMID = ""
            End Try
            Try
                LineDescription = Me.dgvRawMaterials.Rows(RowIndex).Cells("DescriptionColumn").Value
            Catch ex As Exception
                LineDescription = ""
            End Try
            Try
                LineSteelClass = Me.dgvRawMaterials.Rows(RowIndex).Cells("SteelClassColumn").Value
            Catch ex As Exception
                LineSteelClass = ""
            End Try
            Try
                LineSteelCarbon = Me.dgvRawMaterials.Rows(RowIndex).Cells("CarbonColumn").Value
            Catch ex As Exception
                LineSteelCarbon = ""
            End Try
            Try
                LineSteelSize = Me.dgvRawMaterials.Rows(RowIndex).Cells("SteelSizeColumn").Value
            Catch ex As Exception
                LineSteelSize = ""
            End Try
            Try
                cmd = New SqlCommand("UPDATE RawMaterialsTable SET Carbon = @Carbon, SteelSize = @SteelSize, Description = @Description, SteelClass = @SteelClass WHERE RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = LineRMID
                    .Add("@Carbon", SqlDbType.VarChar).Value = LineSteelCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = LineSteelSize
                    .Add("@Description", SqlDbType.VarChar).Value = LineDescription
                    .Add("@SteelClass", SqlDbType.VarChar).Value = LineSteelClass
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write to error log when a new steel is created
                ErrorComment = "Failure on update lines in datagrid - " + LineRMID
                ErrorDate = Today()
                ErrorDescription = "Raw Materials Form - Update Datagrid"
                ErrorReferenceNumber = "NONE"
                ErrorUser = EmployeeLoginName
                ErrorDivision = EmployeeCompanyCode

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Sub dgvRawMaterials_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRawMaterials.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub dgvRawMaterials_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRawMaterials.RowHeaderMouseClick
        Dim LineRMID As String = ""

        If Me.dgvRawMaterials.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvRawMaterials.CurrentCell.RowIndex

            Try
                LineRMID = Me.dgvRawMaterials.Rows(RowIndex).Cells("RMIDColumn").Value
            Catch ex As Exception
                LineRMID = ""
            End Try

            txtRMIDFromDatagrid.Text = LineRMID
        End If
    End Sub

    Private Sub PrintSteelListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSteelListToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        cmdClearAll_Click(sender, e)
    End Sub

    Private Sub dgvRawMaterials_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRawMaterials.Sorted
        LoadFormatting()
    End Sub

    Private Sub cmdReOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReOpen.Click
        If txtRMIDFromDatagrid.Text = "" Then
            MsgBox("You must select a raw material from the grid.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            cmd = New SqlCommand("UPDATE RawMaterialsTable SET SteelStatus = @SteelStatus, ClosDate = @CloseDate WHERE RMID = @RMID", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtRMIDFromDatagrid.Text
                .Add("@SteelStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@CloseDate", SqlDbType.VarChar).Value = "1/1/1900"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Write to error log when a new steel is created
            ErrorComment = "Failure on Re-Open Steel - " + txtRMIDFromDatagrid.Text
            ErrorDate = Today()
            ErrorDescription = "Raw Materials Form - Re-Open Steel"
            ErrorReferenceNumber = "NONE"
            ErrorUser = EmployeeLoginName
            ErrorDivision = EmployeeCompanyCode

            TFPErrorLogUpdate()
        End Try

        MsgBox("Steel has been re-opened", MsgBoxStyle.OkOnly)
        ShowData()

        txtRMIDFromDatagrid.Clear()
    End Sub
End Class