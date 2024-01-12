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
Public Class RackingUtility
    Inherits System.Windows.Forms.Form

    Dim TextFilter, SearchBinPrefernceFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub RackingUtility2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()
    End Sub

    Public Sub LoadBinNumbers()
        'Load Data by filter
        If txtFilter.Text = "" Then
            TextFilter = ""
        Else
            TextFilter = " AND BinNumber LIKE '%" + txtFilter.Text + "%'"
        End If

        cmd = New SqlCommand("SELECT * FROM BinNumber WHERE DivisionID = @DivisionID" + TextFilter + " ORDER BY BinNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "BinNumber")
        dgvBinNumbers.DataSource = ds.Tables("BinNumber")
        con.Close()

        Me.dgvBinNumbers.Visible = True
        Me.dgvBinPreferences.Visible = False
    End Sub

    Public Sub LoadBinPreferences()
        'Load Data by filter
        If txtSearchBinPreference.Text = "" Then
            SearchBinPrefernceFilter = ""
        Else
            SearchBinPrefernceFilter = " AND RowName LIKE '%" + txtSearchBinPreference.Text + "%'"
        End If

        cmd = New SqlCommand("SELECT * FROM BinPrefLocation WHERE DivisionID = @DivisionID" + SearchBinPrefernceFilter + " ORDER BY PreferenceKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "BinPrefLocation")
        dgvBinPreferences.DataSource = ds1.Tables("BinPrefLocation")
        con.Close()

        Me.dgvBinNumbers.Visible = False
        Me.dgvBinPreferences.Visible = True
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

    Private Sub cmdViewRacks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewRacks.Click
        Me.dgvBinNumbers.Visible = True
        Me.dgvBinPreferences.Visible = False

        LoadBinNumbers()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Me.dgvBinNumbers.Visible = True
        Me.dgvBinPreferences.Visible = False

        Me.dgvBinNumbers.DataSource = Nothing

        txtFilter.Clear()
        txtFilter.Focus()
    End Sub

    Private Sub cmdAddRacks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRacks.Click
        'Enter a Single Rack into the database
        Dim RacksToAdd As String = ""

        'Check if you are adding multiple racks or just one
        If txtAddFirstNumber.Text <> "" And txtAddLastNumber.Text = "" Then
            RacksToAdd = "Single Rack"
        ElseIf txtAddFirstNumber.Text = "" And txtAddLastNumber.Text <> "" Then
            RacksToAdd = "INVALID"
            MsgBox("You must add the first rack number.", MsgBoxStyle.OkOnly)
            Exit Sub
        ElseIf txtAddFirstNumber.Text <> "" And txtAddLastNumber.Text <> "" Then
            RacksToAdd = "Multiple Racks"
        Else
            RacksToAdd = "INVALID"
            MsgBox("Invalid data.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Validate Fields
        If txtAddRackPrefix.Text = "" Then
            MsgBox("You must have a two-digit rack prefix.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If Val(txtAddFirstNumber.Text) > 999 Then
            MsgBox("Rack # cannot be 1000 or over.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If Val(txtAddLastNumber.Text) > 999 Then
            MsgBox("Rack # cannot be 1000 or over.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboRackPosition.Text = "" Then
            MsgBox("You must select a rack position.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If Val(txtAddMaxBarWeight.Text) = 0 Then
            MsgBox("You must add MAX Bar Weight.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If Not IsNumeric(txtAddFirstNumber.Text) Then
            MsgBox("You must add an integer for the first rack #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtAddLastNumber.Text <> "" Then
            If Not IsNumeric(txtAddLastNumber.Text) Then
                MsgBox("You must add an integer for the last rack #.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        If Not IsNumeric(txtAddMaxBarWeight.Text) Then
            MsgBox("You must add a number for MAX Bar Weight.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Enter single or multiple racks into the database
        If RacksToAdd = "Single Rack" Then
            'Set variables
            Dim PrefixLength As Integer = 0
            Dim strPrefix As String = ""
            Dim NumberPrefix As String = ""
            Dim strFirstRackNumber As String = ""
            Dim strLastRackNumber As String = ""
            Dim FirstRackNumber As Integer = 0
            Dim LastRackNumber As Integer = 0

            'Check Prefix length
            PrefixLength = txtAddRackPrefix.Text.Length
            strPrefix = txtAddRackPrefix.Text

            If PrefixLength = 2 Then
                'Continue
            Else
                MsgBox("Prefix length must be two characters (letters).", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Add zeroes, if necessary to rack number
            FirstRackNumber = Val(txtAddFirstNumber.Text)
            strFirstRackNumber = CStr(FirstRackNumber)

            If FirstRackNumber = 0 Then
                MsgBox("You cannot have a rack zero.", MsgBoxStyle.OkOnly)
                Exit Sub
            ElseIf FirstRackNumber > 0 And FirstRackNumber < 10 Then
                strFirstRackNumber = "00" + strFirstRackNumber
            ElseIf FirstRackNumber > 9 And FirstRackNumber < 100 Then
                strFirstRackNumber = "0" + strFirstRackNumber
            ElseIf FirstRackNumber > 99 And FirstRackNumber < 1000 Then
                strFirstRackNumber = strFirstRackNumber
            Else
                'Error Check
            End If

            'Add new rack into the database
            Dim NewRackNumber As String = strPrefix + strFirstRackNumber

            Try
                cmd = New SqlCommand("INSERT INTO BinNumber (BinNumber, PartnerBinNumber, MaxBarWeight, MaxUprightWeight, RackPosition, DivisionID, RackLevel) values (@BinNumber, @PartnerBinNumber, @MaxBarWeight, @MaxUprightWeight, @RackPosition, @DivisionID, @RackLevel)", con)

                With cmd.Parameters
                    .Add("@BinNumber", SqlDbType.VarChar).Value = NewRackNumber
                    .Add("@PartnerBinNumber", SqlDbType.VarChar).Value = txtAddPartnerBin.Text
                    .Add("@MaxBarWeight", SqlDbType.VarChar).Value = Val(txtAddMaxBarWeight.Text)
                    .Add("@MaxUprightWeight", SqlDbType.VarChar).Value = Val(txtAddMaxUprightWeight.Text)
                    .Add("@RackPosition", SqlDbType.VarChar).Value = cboRackPosition.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@RackLevel", SqlDbType.VarChar).Value = Val(txtAddRackLevel.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Rack has been added.", MsgBoxStyle.OkOnly)
                LoadBinNumbers()
                cmdClearAddRacks_Click(sender, e)
            Catch ex As Exception
                'Error Check
            End Try
        ElseIf RacksToAdd = "Multiple Racks" Then
            'Set variables
            Dim PrefixLength As Integer = 0
            Dim strPrefix As String = ""
            Dim NumberPrefix As String = ""
            Dim strFirstRackNumber As String = ""
            Dim strLastRackNumber As String = ""
            Dim FirstRackNumber As Integer = 0
            Dim LastRackNumber As Integer = 0
            Dim NumberOfRacksToAdd As Integer = 0
            Dim Counter As Integer = 0
            Dim NextRackNumber As Integer = 0

            'Check Prefix length
            PrefixLength = txtAddRackPrefix.Text.Length
            strPrefix = txtAddRackPrefix.Text

            If PrefixLength = 2 Then
                'Continue
            Else
                MsgBox("Prefix length must be two characters (letters).", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            FirstRackNumber = Val(txtAddFirstNumber.Text)
            LastRackNumber = Val(txtAddLastNumber.Text)

            If LastRackNumber > FirstRackNumber Then
                'Do nothing
            Else
                MsgBox("Last rack # has to be greater than the first rack #.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            NumberOfRacksToAdd = LastRackNumber - FirstRackNumber + 1

            For i As Integer = 1 To NumberOfRacksToAdd
                NextRackNumber = FirstRackNumber + Counter
                strFirstRackNumber = CStr(NextRackNumber)

                If NextRackNumber = 0 Then
                    MsgBox("You cannot have a rack zero.", MsgBoxStyle.OkOnly)
                    Exit Sub
                ElseIf NextRackNumber > 0 And NextRackNumber < 10 Then
                    strFirstRackNumber = "00" + strFirstRackNumber
                ElseIf NextRackNumber > 9 And NextRackNumber < 100 Then
                    strFirstRackNumber = "0" + strFirstRackNumber
                ElseIf NextRackNumber > 99 And NextRackNumber < 1000 Then
                    strFirstRackNumber = strFirstRackNumber
                Else
                    'Error Check
                End If

                'Add new rack into the database
                Dim NewRackNumber As String = strPrefix + strFirstRackNumber

                Try
                    cmd = New SqlCommand("INSERT INTO BinNumber (BinNumber, PartnerBinNumber, MaxBarWeight, MaxUprightWeight, RackPosition, DivisionID, RackLevel) values (@BinNumber, @PartnerBinNumber, @MaxBarWeight, @MaxUprightWeight, @RackPosition, @DivisionID, @RackLevel)", con)

                    With cmd.Parameters
                        .Add("@BinNumber", SqlDbType.VarChar).Value = NewRackNumber
                        .Add("@PartnerBinNumber", SqlDbType.VarChar).Value = txtAddPartnerBin.Text
                        .Add("@MaxBarWeight", SqlDbType.VarChar).Value = Val(txtAddMaxBarWeight.Text)
                        .Add("@MaxUprightWeight", SqlDbType.VarChar).Value = Val(txtAddMaxUprightWeight.Text)
                        .Add("@RackPosition", SqlDbType.VarChar).Value = cboRackPosition.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@RackLevel", SqlDbType.VarChar).Value = Val(txtAddRackLevel.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Check
                End Try

                Counter = Counter + 1
            Next i

            MsgBox("All racks have been added.", MsgBoxStyle.OkOnly)
            LoadBinNumbers()
            cmdClearAddRacks_Click(sender, e)
        Else
            MsgBox("Missing or invalid data.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdClearAddRacks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAddRacks.Click
        txtAddRackPrefix.Clear()
        txtAddFirstNumber.Clear()
        txtAddLastNumber.Clear()
        txtAddMaxBarWeight.Clear()
        txtAddMaxUprightWeight.Clear()
        txtAddPartnerBin.Clear()
        txtAddRackLevel.Clear()
        cboRackPosition.SelectedIndex = -1
    End Sub

    Private Sub dgvBinNumbers_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBinNumbers.CellValueChanged
        Dim RowBinNumber As String = ""
        Dim RowPartnerBinNumber As String = ""
        Dim RowMaxBarWeight As Integer = 0
        Dim RowMaxUprightWeight As Integer = 0
        Dim RowRackPosition As String = ""
        Dim RowRackLevel As Integer = 0
        Dim RowDivision As String = ""

        If Me.dgvBinNumbers.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvBinNumbers.CurrentCell.RowIndex

            Try
                RowBinNumber = Me.dgvBinNumbers.Rows(RowIndex).Cells("BinNumberColumn").Value
            Catch ex As Exception
                RowBinNumber = ""
            End Try
            Try
                RowPartnerBinNumber = Me.dgvBinNumbers.Rows(RowIndex).Cells("PartnerBinNumberColumn").Value
            Catch ex As Exception
                RowPartnerBinNumber = ""
            End Try
            Try
                RowMaxBarWeight = Me.dgvBinNumbers.Rows(RowIndex).Cells("MaxBarWeightColumn").Value
            Catch ex As Exception
                RowMaxBarWeight = 0
            End Try
            Try
                RowMaxUprightWeight = Me.dgvBinNumbers.Rows(RowIndex).Cells("MaxUprightWeightColumn").Value
            Catch ex As Exception
                RowMaxUprightWeight = 0
            End Try
            Try
                RowRackLevel = Me.dgvBinNumbers.Rows(RowIndex).Cells("RackLevelColumn").Value
            Catch ex As Exception
                RowRackLevel = 0
            End Try
            Try
                RowRackPosition = Me.dgvBinNumbers.Rows(RowIndex).Cells("RackPositionColumn").Value
            Catch ex As Exception
                RowRackPosition = ""
            End Try
            Try
                RowDivision = Me.dgvBinNumbers.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try

            'Validate if rack is used.
            Dim CountRackItems As Integer = 0

            Dim CountRackItemsStatement As String = "SELECT COUNT(RackingKey) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
            Dim CountRackItemsCommand As New SqlCommand(CountRackItemsStatement, con)
            CountRackItemsCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
            CountRackItemsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountRackItems = CInt(CountRackItemsCommand.ExecuteScalar)
            Catch ex As Exception
                CountRackItems = 0
            End Try
            con.Close()

            If CountRackItems = 0 Then
                'Proceed
            ElseIf CountRackItems <> 0 And RowRackPosition = "UNAVAILABLE" Then
                MsgBox("Rack is not empty and can't be closed.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Proceed
            End If

            Try
                cmd = New SqlCommand("UPDATE BinNumber SET PartnerBinNumber = @PartnerBinNumber, MaxBarWeight = @MaxBarWeight, MaxUprightWeight = @MaxUprightWeight, RackPosition = @RackPosition, RackLevel = @RackLevel WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                    .Add("@PartnerBinNumber", SqlDbType.VarChar).Value = RowPartnerBinNumber
                    .Add("@MaxBarWeight", SqlDbType.VarChar).Value = RowMaxBarWeight
                    .Add("@MaxUprightWeight", SqlDbType.VarChar).Value = RowMaxUprightWeight
                    .Add("@RackPosition", SqlDbType.VarChar).Value = RowRackPosition
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@RackLevel", SqlDbType.VarChar).Value = RowRackLevel
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Check
            End Try
        End If
    End Sub

    Private Sub cmdDeleteRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRack.Click
        'Check to see if rack is in use
        Dim CountRackItems As Integer = 0

        Dim CountRackItemsStatement As String = "SELECT COUNT(RackingKey) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
        Dim CountRackItemsCommand As New SqlCommand(CountRackItemsStatement, con)
        CountRackItemsCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = txtDeleteRack.Text
        CountRackItemsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountRackItems = CInt(CountRackItemsCommand.ExecuteScalar)
        Catch ex As Exception
            CountRackItems = 0
        End Try
        con.Close()

        If CountRackItems = 0 Then
            'Do nothing - continue
        Else
            MsgBox("Rack is not empty and can't be deleted.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            cmd = New SqlCommand("DELETE FROM BinNumber WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BinNumber", SqlDbType.VarChar).Value = txtDeleteRack.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Check
        End Try

        MsgBox("Rack has been deleted.", MsgBoxStyle.OkOnly)
        LoadBinNumbers()
        cmdClearAddRacks_Click(sender, e)
    End Sub

    Private Sub cmdViewBinPreference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewBinPreference.Click
        Me.dgvBinNumbers.Visible = False
        Me.dgvBinPreferences.Visible = True

        LoadBinPreferences()
    End Sub

    Private Sub cmdClearBinReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearBinReference.Click
        Me.dgvBinNumbers.Visible = False
        Me.dgvBinPreferences.Visible = True

        Me.dgvBinPreferences.DataSource = Nothing

        txtSearchBinPreference.Clear()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

End Class