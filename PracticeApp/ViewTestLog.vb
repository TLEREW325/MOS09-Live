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
Imports System.Drawing.Printing
Public Class ViewTestLog
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Dim isLoaded As Boolean = False

    Public Sub New()
        InitializeComponent()

        LoadHeatNumbers()
        LoadLotNumbers()
        LoadPartNumbers()
        If con.State = ConnectionState.Open Then con.Close()
        isLoaded = True
    End Sub

    Private Sub LoadHeatNumbers()
        cmd = New SqlCommand("SELECT DISTINCT(HeatNumber) FROM HeatNumberLog", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboHeatNumber.Items.Add(reader.Item("HeatNumber"))
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadLotNumbers()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboLotNumber.Items.Add(reader.Item("LotNumber"))
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadPartNumbers()
        cmd = New SqlCommand("SELECT DISTINCT(ItemID) FROM ItemList WHERE DivisionID = 'TWD' OR DivisionID = 'TFP'", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboPartNumber.Items.Add(reader.Item("ItemID"))
            End While
        End If
        reader.Close()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        cmd = New SqlCommand("SELECT EntryDate, HeatNumber, LotNumber, PartNumber, NominalDiameter, NominalLength, TestType, ItemClass, PullTestNumber, TorqueTestNumber FROM PullTestLog ", con)

        Dim isFirst As Boolean = True

        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE HeatNumber = @HeatNumber"
                isFirst = False
            Else
                cmd.CommandText += " AND HeatNumber = @HeatNumber"
            End If
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        End If

        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE PartNumber = @PartNumber"
            Else
                cmd.CommandText += " AND PartNumber = @PartNumber"
            End If
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        End If

        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE LotNumber = @LotNumber"
                isFirst = False
            Else
                cmd.CommandText += " AND LotNumber = @LotNumber"
            End If
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        End If

        If Not chkShowFinished.Checked Then
            If Not String.IsNullOrEmpty(cboTestType.Text) Then
                If isFirst Then
                    cmd.CommandText += " WHERE TestType = @TestType"
                    isFirst = False
                Else
                    cmd.CommandText += " AND TestType = @TestType"
                End If
                cmd.Parameters.Add("@TestType", SqlDbType.VarChar).Value = cboTestType.Text
            Else
                If isFirst Then
                    cmd.CommandText += " WHERE ((TestType = 'PULL AND TORQUE' AND PullTestNumber IS NULL AND TorqueTestNumber IS NULL) OR (TestType = 'PULL' AND PullTestNumber IS NULL) OR (TestType = 'TORQUE' AND TorqueTestNumber IS NULL))"
                    isFirst = False
                Else
                    cmd.CommandText += " AND ((TestType = 'PULL AND TORQUE' AND PullTestNumber IS NULL AND TorqueTestNumber IS NULL) OR (TestType = 'PULL' AND PullTestNumber IS NULL) OR (TestType = 'TORQUE' AND TorqueTestNumber IS NULL))"
                End If
            End If
        End If
        isLoaded = False

        Dim tempds As New DataSet
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "PullTestLog")
        con.Close()

        dgvPullTestLog.DataSource = tempds.Tables("PullTestLog")

        dgvPullTestLog.Columns("EntryDate").HeaderText = "Entry Date"
        dgvPullTestLog.Columns("EntryDate").ReadOnly = True
        dgvPullTestLog.Columns("EntryDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvPullTestLog.Columns("HeatNumber").HeaderText = "Heat Number"
        dgvPullTestLog.Columns("HeatNumber").ReadOnly = True
        dgvPullTestLog.Columns("LotNumber").HeaderText = "Lot Number"
        dgvPullTestLog.Columns("LotNumber").ReadOnly = True
        dgvPullTestLog.Columns("PartNumber").HeaderText = "Part Number"
        dgvPullTestLog.Columns("PartNumber").ReadOnly = True
        dgvPullTestLog.Columns("NominalDiameter").HeaderText = "Nominal Diameter"
        dgvPullTestLog.Columns("NominalDiameter").ReadOnly = True
        dgvPullTestLog.Columns("NominalLength").HeaderText = "Nominal Length"
        dgvPullTestLog.Columns("NominalLength").ReadOnly = True
        dgvPullTestLog.Columns("ItemClass").HeaderText = "Item Class"
        dgvPullTestLog.Columns("ItemClass").ReadOnly = True
        dgvPullTestLog.Columns("TestType").HeaderText = "Test Type"
        dgvPullTestLog.Columns("TestType").ReadOnly = True
        dgvPullTestLog.Columns("PullTestNumber").HeaderText = "Pull Test Number"
        dgvPullTestLog.Columns("PullTestNumber").ReadOnly = True
        dgvPullTestLog.Columns("TorqueTestNumber").HeaderText = "Torque Test Number"
        dgvPullTestLog.Columns("TorqueTestNumber").ReadOnly = True
        isLoaded = True
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboHeatNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cboHeatNumber.Text = ""
        End If
        cboPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        cboLotNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            cboLotNumber.Text = ""
        End If
        cboTestType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboTestType.Text) Then
            cboTestType.Text = ""
        End If
        chkShowFinished.Checked = False

        isLoaded = False
        dgvPullTestLog.DataSource = Nothing
        isLoaded = True
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim newPrintPullTestLog As New PrintPullTestLog(dgvPullTestLog.DataSource())
        newPrintPullTestLog.ShowDialog()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvPullTestLog_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPullTestLog.CellValueChanged
        If isLoaded Then
            Dim RowLotNumber As Integer = 0
            Dim RowPullTestNumber, RowHeatNumber, RowTorqueTestNumber As String

            If Me.dgvPullTestLog.RowCount <> 0 Then
                Dim RowIndex As Integer = Me.dgvPullTestLog.CurrentCell.RowIndex

                Try
                    RowLotNumber = Me.dgvPullTestLog.Rows(RowIndex).Cells("LotNumber").Value
                Catch ex As Exception
                    RowLotNumber = 0
                End Try
                Try
                    RowPullTestNumber = Me.dgvPullTestLog.Rows(RowIndex).Cells("PullTestNumber").Value
                Catch ex As Exception
                    RowPullTestNumber = ""
                End Try
                Try
                    RowHeatNumber = Me.dgvPullTestLog.Rows(RowIndex).Cells("HeatNumber").Value
                Catch ex As Exception
                    RowHeatNumber = ""
                End Try
                Try
                    RowTorqueTestNumber = Me.dgvPullTestLog.Rows(RowIndex).Cells("TorqueTestNumber").Value
                Catch ex As Exception
                    RowTorqueTestNumber = ""
                End Try

                Try
                    'UPDATE Purchase Order Extended Amount based on line changes
                    cmd = New SqlCommand("UPDATE PullTestLog SET PullTestNumber = @PullTestNumber, TorqueTestNumber = @TorqueTestNumber WHERE HeatNumber = @HeatNumber AND LotNumber = @LotNumber", con)

                    With cmd.Parameters
                        .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                        .Add("@PullTestNumber", SqlDbType.VarChar).Value = RowPullTestNumber
                        .Add("@TorqueTestNumber", SqlDbType.VarChar).Value = RowTorqueTestNumber
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
        End If
    End Sub

    Private Sub ViewTestLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If EmployeeLoginName = "SBALLIET" Or EmployeeLoginName = "SAMRAY" Or EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            gpxRemove.Enabled = True
        Else
            gpxRemove.Enabled = False
        End If
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        Dim RowLotNumber As String = ""

        If Me.dgvPullTestLog.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPullTestLog.CurrentCell.RowIndex

            Try
                RowLotNumber = Me.dgvPullTestLog.Rows(RowIndex).Cells("LotNumber").Value
            Catch ex As Exception
                RowLotNumber = ""
            End Try

            If RowLotNumber <> "" Then
                'Update Pull Test Log to remove
                cmd = New SqlCommand("UPDATE PullTestLog SET PullTestNumber = @PullTestNumber WHERE LotNumber = @LotNumber", con)

                With cmd.Parameters
                    .Add("@PullTestNumber", SqlDbType.VarChar).Value = "NONE"
                    .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cmdView_Click(sender, e)
            End If
        End If
    End Sub
End Class