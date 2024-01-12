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
Public Class ViewBinPreferences
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim PreferenceCode, Pref1, Pref2, Pref3, Pref4, Pref5, Pref6, Pref7, Pref8, Pref9, Pref10, Pref11, Pref12, Pref13, Pref14, Pref15, Pref16, Pref17, Pref18 As String
    Dim PreferenceKey As Integer = 0
    Dim LastPreferenceKey, NextPreferenceKey As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewBinPreferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Public Sub LoadBinPreferencesByDivision()
        cmd = New SqlCommand("SELECT * FROM BinPrefLocation WHERE DivisionID = @DivisionID1 ORDER BY RowName", con)
        cmd.Parameters.Add("@DivisionID1", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "BinPrefLocation")
        dgvBinPreferences.DataSource = ds.Tables("BinPrefLocation")
        con.Close()
    End Sub

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length > 400 Then
            ErrorComment = ErrorComment.Substring(0, 400)
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

    Public Sub ClearData()
        txtPref1.Clear()
        txtPref10.Clear()
        txtPref11.Clear()
        txtPref12.Clear()
        txtPref13.Clear()
        txtPref14.Clear()
        txtPref15.Clear()
        txtPref16.Clear()
        txtPref17.Clear()
        txtPref18.Clear()
        txtPref2.Clear()
        txtPref3.Clear()
        txtPref4.Clear()
        txtPref5.Clear()
        txtPref6.Clear()
        txtPref7.Clear()
        txtPref8.Clear()
        txtPref9.Clear()
        txtPrefCode.Clear()
    End Sub

    Public Sub ClearVariables()
        PreferenceCode = ""
        Pref1 = ""
        Pref2 = ""
        Pref3 = ""
        Pref4 = ""
        Pref5 = ""
        Pref6 = ""
        Pref7 = ""
        Pref8 = ""
        Pref9 = ""
        Pref10 = ""
        Pref11 = ""
        Pref12 = ""
        Pref13 = ""
        Pref14 = ""
        Pref15 = ""
        Pref16 = ""
        Pref17 = ""
        Pref18 = ""
        PreferenceKey = 0
        LastPreferenceKey = 0
        NextPreferenceKey = 0
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvBinPreferences.DataSource = Nothing
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewByDivision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByDivision.Click
        LoadBinPreferencesByDivision()
    End Sub

    Private Sub cmdAddPreference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddPreference.Click
        'Check if bins already exist
        Dim CheckPreference As Integer = 0

        Dim CheckPreferenceStatement As String = "SELECT COUNT(PreferenceKey) FROM BinPrefLocation WHERE DivisionID = @DivisionID AND RowName = @RowName"
        Dim CheckPreferenceCommand As New SqlCommand(CheckPreferenceStatement, con)
        CheckPreferenceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CheckPreferenceCommand.Parameters.Add("@RowName", SqlDbType.VarChar).Value = txtPrefCode.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPreference = CInt(CheckPreferenceCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPreference = 0
        End Try
        con.Close()

        If CheckPreference > 0 Then
            MsgBox("This preference already exists.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim MaxPreferenceKeyStatement As String = "SELECT MAX(PreferenceKey) FROM BinPrefLocation WHERE DivisionID = @DivisionID"
        Dim MaxPreferenceKeyCommand As New SqlCommand(MaxPreferenceKeyStatement, con)
        MaxPreferenceKeyCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPreferenceKey = CInt(MaxPreferenceKeyCommand.ExecuteScalar)
        Catch ex As Exception
            LastPreferenceKey = 0
        End Try
        con.Close()

        NextPreferenceKey = LastPreferenceKey + 1

        Try
            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("INSERT INTO BinPrefLocation (PreferenceKey, RowName, Pref01, Pref02, Pref03, Pref04, Pref05, Pref06, Pref07, Pref08, Pref09, Pref10, Pref11, Pref12, Pref13, Pref14, Pref15, Pref16, Pref17, Pref18, DivisionID) values (@PreferenceKey, @RowName, @Pref01, @Pref02, @Pref03, @Pref04, @Pref05, @Pref06, @Pref07, @Pref08, @Pref09, @Pref10, @Pref11, @Pref12, @Pref13, @Pref14, @Pref15, @Pref16, @Pref17, @Pref18, @DivisionID)", con)

            With cmd.Parameters
                .Add("@PreferenceKey", SqlDbType.VarChar).Value = NextPreferenceKey
                .Add("@RowName", SqlDbType.VarChar).Value = txtPrefCode.Text
                .Add("@Pref01", SqlDbType.VarChar).Value = txtPref1.Text
                .Add("@Pref02", SqlDbType.VarChar).Value = txtPref2.Text
                .Add("@Pref03", SqlDbType.VarChar).Value = txtPref3.Text
                .Add("@Pref04", SqlDbType.VarChar).Value = txtPref4.Text
                .Add("@Pref05", SqlDbType.VarChar).Value = txtPref5.Text
                .Add("@Pref06", SqlDbType.VarChar).Value = txtPref6.Text
                .Add("@Pref07", SqlDbType.VarChar).Value = txtPref7.Text
                .Add("@Pref08", SqlDbType.VarChar).Value = txtPref8.Text
                .Add("@Pref09", SqlDbType.VarChar).Value = txtPref9.Text
                .Add("@Pref10", SqlDbType.VarChar).Value = txtPref10.Text
                .Add("@Pref11", SqlDbType.VarChar).Value = txtPref11.Text
                .Add("@Pref12", SqlDbType.VarChar).Value = txtPref12.Text
                .Add("@Pref13", SqlDbType.VarChar).Value = txtPref13.Text
                .Add("@Pref14", SqlDbType.VarChar).Value = txtPref14.Text
                .Add("@Pref15", SqlDbType.VarChar).Value = txtPref15.Text
                .Add("@Pref16", SqlDbType.VarChar).Value = txtPref16.Text
                .Add("@Pref17", SqlDbType.VarChar).Value = txtPref17.Text
                .Add("@Pref18", SqlDbType.VarChar).Value = txtPref18.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            'Log error on update failure
            Dim TempPreferenceKey As Integer = 0
            Dim strTempPreferenceKey As String
            TempPreferenceKey = NextPreferenceKey
            strTempPreferenceKey = CStr(TempPreferenceKey)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Add Bin Preference - INSERT NEW Failure"
            ErrorReferenceNumber = "Preference Key # " + strTempPreferenceKey
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            MsgBox("Adding preference failed.", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try

        LoadBinPreferencesByDivision()

        MsgBox("Bin Preference added.", MsgBoxStyle.OkOnly)

        ClearData()
        ClearVariables()

        txtPrefCode.Focus()
    End Sub

    Private Sub dgvBinPreferences_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBinPreferences.CellValueChanged
        If Me.dgvBinPreferences.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvBinPreferences.CurrentCell.RowIndex
            Try
                PreferenceKey = Me.dgvBinPreferences.Rows(RowIndex).Cells("PreferenceKeyColumn").Value
            Catch ex As Exception
                PreferenceKey = 0
            End Try
            Try
                PreferenceCode = Me.dgvBinPreferences.Rows(RowIndex).Cells("RowNameColumn").Value
            Catch ex As Exception
                PreferenceCode = ""
            End Try
            Try
                Pref1 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref01Column").Value
            Catch ex As Exception
                Pref1 = ""
            End Try
            Try
                Pref2 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref02Column").Value
            Catch ex As Exception
                Pref2 = ""
            End Try
            Try
                Pref3 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref03Column").Value
            Catch ex As Exception
                Pref3 = ""
            End Try
            Try
                Pref4 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref04Column").Value
            Catch ex As Exception
                Pref4 = ""
            End Try
            Try
                Pref5 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref05Column").Value
            Catch ex As Exception
                Pref5 = ""
            End Try
            Try
                Pref6 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref06Column").Value
            Catch ex As Exception
                Pref6 = ""
            End Try
            Try
                Pref7 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref07Column").Value
            Catch ex As Exception
                Pref7 = ""
            End Try
            Try
                Pref8 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref08Column").Value
            Catch ex As Exception
                Pref8 = ""
            End Try
            Try
                Pref9 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref09Column").Value
            Catch ex As Exception
                Pref9 = ""
            End Try
            Try
                Pref10 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref10Column").Value
            Catch ex As Exception
                Pref10 = ""
            End Try
            Try
                Pref11 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref11Column").Value
            Catch ex As Exception
                Pref11 = ""
            End Try
            Try
                Pref12 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref12Column").Value
            Catch ex As Exception
                Pref12 = ""
            End Try
            Try
                Pref13 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref13Column").Value
            Catch ex As Exception
                Pref13 = ""
            End Try
            Try
                Pref14 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref14Column").Value
            Catch ex As Exception
                Pref14 = ""
            End Try
            Try
                Pref15 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref15Column").Value
            Catch ex As Exception
                Pref15 = ""
            End Try
            Try
                Pref16 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref16Column").Value
            Catch ex As Exception
                Pref16 = ""
            End Try
            Try
                Pref17 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref17Column").Value
            Catch ex As Exception
                Pref17 = ""
            End Try
            Try
                Pref18 = Me.dgvBinPreferences.Rows(RowIndex).Cells("Pref18Column").Value
            Catch ex As Exception
                Pref18 = ""
            End Try

            'Update Database
            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE BinPrefLocation SET RowName = @RowName, Pref01 = @Pref01, Pref02 = @Pref02, Pref03 = @Pref03, Pref04 = @Pref04, Pref05 = @Pref05, Pref06 = @Pref06, Pref07 = @Pref07, Pref08 = @Pref08, Pref09 = @Pref09, Pref10 = @Pref10, Pref11 = @Pref11, Pref12 = @Pref12, Pref13 = @Pref13, Pref14 = @Pref14, Pref15 = @Pref15, Pref16 = @Pref16, Pref17 = @Pref17, Pref18 = @Pref18 WHERE PreferenceKey = @PreferenceKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PreferenceKey", SqlDbType.VarChar).Value = PreferenceKey
                    .Add("@RowName", SqlDbType.VarChar).Value = PreferenceCode
                    .Add("@Pref01", SqlDbType.VarChar).Value = Pref1
                    .Add("@Pref02", SqlDbType.VarChar).Value = Pref2
                    .Add("@Pref03", SqlDbType.VarChar).Value = Pref3
                    .Add("@Pref04", SqlDbType.VarChar).Value = Pref4
                    .Add("@Pref05", SqlDbType.VarChar).Value = Pref5
                    .Add("@Pref06", SqlDbType.VarChar).Value = Pref6
                    .Add("@Pref07", SqlDbType.VarChar).Value = Pref7
                    .Add("@Pref08", SqlDbType.VarChar).Value = Pref8
                    .Add("@Pref09", SqlDbType.VarChar).Value = Pref9
                    .Add("@Pref10", SqlDbType.VarChar).Value = Pref10
                    .Add("@Pref11", SqlDbType.VarChar).Value = Pref11
                    .Add("@Pref12", SqlDbType.VarChar).Value = Pref12
                    .Add("@Pref13", SqlDbType.VarChar).Value = Pref13
                    .Add("@Pref14", SqlDbType.VarChar).Value = Pref14
                    .Add("@Pref15", SqlDbType.VarChar).Value = Pref15
                    .Add("@Pref16", SqlDbType.VarChar).Value = Pref16
                    .Add("@Pref17", SqlDbType.VarChar).Value = Pref17
                    .Add("@Pref18", SqlDbType.VarChar).Value = Pref18
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                'Log error on update failure
                Dim TempPreferenceKey As Integer = 0
                Dim strTempPreferenceKey As String
                TempPreferenceKey = PreferenceKey
                strTempPreferenceKey = CStr(TempPreferenceKey)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Add Bin Preference - UPDATE Datagrid Failure"
                ErrorReferenceNumber = "Preference Key # " + strTempPreferenceKey
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Adding preference failed.", MsgBoxStyle.OkOnly)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub cmdClearFields_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearFields.Click
        ClearData()
        ClearData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdDeletePreference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeletePreference.Click
        If Me.dgvBinPreferences.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvBinPreferences.CurrentCell.RowIndex

            Try
                PreferenceKey = Me.dgvBinPreferences.Rows(RowIndex).Cells("PreferenceKeyColumn").Value
            Catch ex As Exception
                PreferenceKey = 0
            End Try

            'Check to make sure they want to delete
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this bin preference?", "DELETE BIN PREFERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then

                'Create command to save data from text boxes
                cmd = New SqlCommand("DELETE FROM BinPrefLocation WHERE PreferenceKey = @PreferenceKey AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@PreferenceKey", SqlDbType.VarChar).Value = PreferenceKey
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Preference deleted.", MsgBoxStyle.OkOnly)

                LoadBinPreferencesByDivision()
                ClearData()
                ClearVariables()
            ElseIf button = DialogResult.No Then
                cmdClear.Focus()
            End If
        End If
    End Sub
End Class