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
Public Class SteelTransactionEntry
    Inherits System.Windows.Forms.Form

    Dim LongDescription, ItemClass, GLAccount As String
    Dim NextTransactionNumber, LastTransactionNumber As Integer
    Dim UnitCost, UnitPrice, ExtendedCost, ExtendedAmount, Quantity As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub SteelTransactionEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
                cboDivisionID.Enabled = True
            Else
                cboDivisionID.Enabled = False
            End If

            cboDivisionID.Text = EmployeeCompanyCode
        End If

        LoadCarbon()
        LoadSteelSize()
        ClearData()
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

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable WHERE SteelStatus <> @SteelStatus", con)
        cmd.Parameters.Add("@SteelStatus", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RawMaterialsTable")
        cboCarbon.DataSource = ds.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable WHERE SteelStatus <> @SteelStatus", con)
        cmd.Parameters.Add("@SteelStatus", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboSteelSize.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadRMID()
        Dim GetRMID As String = ""

        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            GetRMID = ""
        End Try
        con.Close()

        txtRMID.Text = GetRMID
    End Sub

    Public Sub ClearData()
        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboTransactionMath.SelectedIndex = -1

        txtExtendedCost.Clear()
        txtQuantity.Clear()
        txtReferenceLine.Clear()
        txtReferenceNumber.Clear()
        txtRMID.Clear()
        txtSteelCost.Clear()
        txtSteelTransactionKey.Clear()
        txtTransactionType.Clear()

        dtpTransactionDate.Text = ""

        txtSteelTransactionKey.Focus()
    End Sub

    Private Sub cmdGenerateTransactionNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateTransactionNumber.Click
        'Get Next Transaction Number
        Dim MAXStatement As String = "SELECT MAX(TransactionNumber) FROM SteelTransactionTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 1000000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        txtSteelTransactionKey.Text = NextTransactionNumber

        'Save (INSERT) into database
        Try
            cmd = New SqlCommand("Insert Into SteelTransactionTable (TransactionNumber, DivisionID, SteelTransactionDate, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType)Values(@TransactionNumber, @DivisionID, @SteelTransactionDate, @Carbon, @SteelSize, @Quantity, @SteelCost, @ExtendedCost, @SteelReferenceNumber, @SteelReferenceLine, @RMID, @TransactionMath, @TransactionType)", con)

            With cmd.Parameters
                .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SteelTransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                .Add("@SteelCost", SqlDbType.VarChar).Value = Val(txtSteelCost.Text)
                .Add("@ExtendedCost", SqlDbType.VarChar).Value = Val(txtExtendedCost.Text)
                .Add("@SteelReferenceNumber", SqlDbType.VarChar).Value = Val(txtReferenceNumber.Text)
                .Add("@SteelReferenceLine", SqlDbType.VarChar).Value = Val(txtReferenceLine.Text)
                .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
                .Add("@TransactionMath", SqlDbType.VarChar).Value = ""
                .Add("@TransactionType", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Do nothing
        End Try
    End Sub

    Private Sub cmdAddSteelTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSteelTransaction.Click
        'Validate Fields
        If txtSteelTransactionKey.Text = "" Or cboTransactionMath.Text = "" Or cboDivisionID.Text = "" Or cboSteelSize.Text = "" Or cboCarbon.Text = "" Then
            MsgBox("One or more entries are missing.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'INSERT INTO database
        Try
            cmd = New SqlCommand("UPDATE SteelTransactionTable SET SteelTransactionDate = @SteelTransactionDate, Carbon = @Carbon, SteelSize = @SteelSize, Quantity = @Quantity, SteelCost = @SteelCost, ExtendedCost = @ExtendedCost, SteelReferenceNumber = @SteelReferenceNumber, SteelReferenceLine = @SteelReferenceLine, RMID = @RMID, TransactionMath = @TransactionMath, TransactionType = @TransactionType WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(txtSteelTransactionKey.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SteelTransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                .Add("@SteelCost", SqlDbType.VarChar).Value = Val(txtSteelCost.Text)
                .Add("@ExtendedCost", SqlDbType.VarChar).Value = Val(txtExtendedCost.Text)
                .Add("@SteelReferenceNumber", SqlDbType.VarChar).Value = Val(txtReferenceNumber.Text)
                .Add("@SteelReferenceLine", SqlDbType.VarChar).Value = Val(txtReferenceLine.Text)
                .Add("@RMID", SqlDbType.VarChar).Value = txtRMID.Text
                .Add("@TransactionMath", SqlDbType.VarChar).Value = cboTransactionMath.Text
                .Add("@TransactionType", SqlDbType.VarChar).Value = txtTransactionType.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearData()

            MsgBox("Steel Transaction posted.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("Transaction Failed.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If cboSteelSize.Text <> "" Then
            LoadRMID()
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If cboCarbon.Text <> "" Then
            LoadRMID()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub
End Class