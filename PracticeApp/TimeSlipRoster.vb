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
Public Class TimeSlipRoster
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;async=true;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12, myAdapter13, myAdapter14, myAdapter15, myAdapter16, myAdapter17, myAdapter18 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12, ds13, ds14, ds15, ds16, ds17, ds18 As DataSet

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    Private Sub TimeSlipRoster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)

        'Load date from time slip posting form
        dtpPostingDate.Value = GlobalTimeSlipValidationDate

        LoadEmployeeRoster()
        LoadDataFromTimeslips()
        'LoadFormatting()
    End Sub

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        ' The return value specifies the previous state of the menu item (it is either      
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.      
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub

    Public Sub LoadEmployeeRoster()
        'Loads only Time Slip Employees
        cmd = New SqlCommand("SELECT * FROM EmployeeData WHERE Department = @Department AND (DivisionKey = 'TWD' OR DivisionKey = 'TFP') ORDER BY EmployeeLast", con)
        cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = "TS005"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "EmployeeData")
        dgvTimeSlipRoster.DataSource = ds.Tables("EmployeeData")
        con.Close()
    End Sub

    'Public Sub LoadFormatting()
    '    Dim RowIndex As Integer = 0
    '    Dim RowPosting As String = ""

    '    For Each row As DataGridViewRow In dgvTimeSlipRoster.Rows
    '        Try
    '            RowPosting = dgvTimeSlipRoster.Rows(RowIndex).Cells("PostingColumn").Value
    '        Catch ex As Exception
    '            RowPosting = ""
    '        End Try

    '        If RowPosting = "UNSELECTED" Then
    '            Me.dgvTimeSlipRoster.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
    '            Me.dgvTimeSlipRoster.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
    '            Me.dgvTimeSlipRoster.Rows(RowIndex).ReadOnly = False
    '        Else
    '            Me.dgvTimeSlipRoster.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
    '            Me.dgvTimeSlipRoster.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
    '            Me.dgvTimeSlipRoster.Rows(RowIndex).ReadOnly = True
    '        End If

    '        RowIndex = RowIndex + 1
    '    Next
    'End Sub

    Public Sub LoadDataFromTimeslips()
        Dim EmployeeID As String = ""
        Dim CountIndex As Integer = 0
        Dim CountPostings As Integer = 0
        Dim SumHours As Double = 0

        For Each row As DataGridViewRow In dgvTimeSlipRoster.Rows
            Try
                EmployeeID = dgvTimeSlipRoster.Rows(CountIndex).Cells("EmployeeIDColumn").Value
            Catch ex As Exception
                EmployeeID = ""
            End Try

            'Get Time slip data for each Employee ID and for the date
            Dim CountPostingsString As String = "SELECT COUNT(TimeSlipKey) FROM TimeSlipCombinedData WHERE EmployeeID = @EmployeeID AND PostingDate = @PostingDate"
            Dim CountPostingsCommand As New SqlCommand(CountPostingsString, con)
            CountPostingsCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = EmployeeID
            CountPostingsCommand.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpPostingDate.Value

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPostings = CInt(CountPostingsCommand.ExecuteScalar)
            Catch ex As System.Exception
                CountPostings = 0
            End Try
            con.Close()

            If CountPostings > 0 Then
                Me.dgvTimeSlipRoster.Rows(CountIndex).Cells("PostingColumn").Value = "SELECTED"
            Else
                Me.dgvTimeSlipRoster.Rows(CountIndex).Cells("PostingColumn").Value = "UNSELECTED"
            End If

            'Dim SumHoursString As String = "SELECT SUM(TotalHours) FROM TimeSlipCombinedData WHERE EmployeeID = @EmployeeID AND PostingDate = @PostingDate"
            'Dim SumHoursCommand As New SqlCommand(SumHoursString, con)
            'SumHoursCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = EmployeeID
            'SumHoursCommand.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpPostingDate.Value

            'If con.State = ConnectionState.Closed Then con.Open()
            'Try
            '    SumHours = CDbl(SumHoursCommand.ExecuteScalar)
            'Catch ex As System.Exception
            '    SumHours = 0
            'End Try
            'con.Close()

            'Me.dgvTimeSlipRoster.Rows(CountIndex).Cells("HoursColumn").Value = SumHours

            CountIndex = CountIndex + 1
        Next

        For r As Integer = Me.dgvTimeSlipRoster.Rows.Count - 1 To 0 Step -1
            Dim row As DataGridViewRow = Me.dgvTimeSlipRoster.Rows(r)

            If Me.dgvTimeSlipRoster.Rows(r).Cells("PostingColumn").Value = "SELECTED" Then
                Me.dgvTimeSlipRoster.Rows.RemoveAt(r)
            End If
        Next
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalTimeSlipValidation = "FAIL"
        GlobalTimeSlipValidationDate = Today()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dtpPostingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPostingDate.ValueChanged
        LoadEmployeeRoster()
        LoadDataFromTimeslips()
        'LoadFormatting()
    End Sub

    Private Sub cmdProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProceed.Click
        If chkSaturdayPosting.Checked = True Then
            GlobalTimeSlipValidation = "PASS"

            Me.Close()
        Else
            Dim CheckIndex As Integer = 0
            Dim CheckPosting As String = ""
            Dim CheckReason As String = ""
            Dim DoesPostingExist As String = ""

            'Run Check to see if you can proceed or not
            For Each Row As DataGridViewRow In dgvTimeSlipRoster.Rows
                Try
                    CheckPosting = dgvTimeSlipRoster.Rows(CheckIndex).Cells("PostingColumn").Value
                Catch ex As Exception
                    CheckPosting = ""
                End Try
                Try
                    CheckReason = dgvTimeSlipRoster.Rows(CheckIndex).Cells("ReasonColumn").Value
                Catch ex As Exception
                    CheckReason = ""
                End Try

                If CheckPosting = "UNSELECTED" And CheckReason = "" Then
                    GlobalTimeSlipValidation = "FAIL"
                    MsgBox("You must state a reason for every employee w/o a timeslip.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Proceed to next
                End If

                CheckIndex = CheckIndex + 1
            Next
            '*********************************************************************************************************
            Dim RowPosting, RowDivisionID, RowEmployeeID, RowEmployeeFirst, RowEmployeeLast, RowShift As String
            Dim RowHours As Double = 0
            Dim RowReason As String = ""
            Dim CountIndex As Integer = 0

            'Check every employee in group to see if they have a posting or reason
            For Each row As DataGridViewRow In dgvTimeSlipRoster.Rows
                Try
                    RowDivisionID = dgvTimeSlipRoster.Rows(CountIndex).Cells("DivisionKeyColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try
                Try
                    RowEmployeeID = dgvTimeSlipRoster.Rows(CountIndex).Cells("EmployeeIDColumn").Value
                Catch ex As Exception
                    RowEmployeeID = ""
                End Try
                Try
                    RowEmployeeFirst = dgvTimeSlipRoster.Rows(CountIndex).Cells("EmployeeFirstColumn").Value
                Catch ex As Exception
                    RowEmployeeFirst = ""
                End Try
                Try
                    RowEmployeeLast = dgvTimeSlipRoster.Rows(CountIndex).Cells("EmployeeLastColumn").Value
                Catch ex As Exception
                    RowEmployeeLast = ""
                End Try
                Try
                    RowReason = dgvTimeSlipRoster.Rows(CountIndex).Cells("ReasonColumn").Value
                Catch ex As Exception
                    RowReason = ""
                End Try
                Try
                    RowShift = dgvTimeSlipRoster.Rows(CountIndex).Cells("ShiftColumn").Value
                Catch ex As Exception
                    RowShift = ""
                End Try
                Try
                    RowHours = dgvTimeSlipRoster.Rows(CountIndex).Cells("HoursColumn").Value
                Catch ex As Exception
                    RowHours = 0
                End Try
                Try
                    RowPosting = dgvTimeSlipRoster.Rows(CountIndex).Cells("PostingColumn").Value
                Catch ex As Exception
                    RowPosting = ""
                End Try

                If RowPosting = "SELECTED" Then
                    DoesPostingExist = "YES"
                Else
                    DoesPostingExist = "NO"
                End If

                'Write Data to Table
                cmd = New SqlCommand("INSERT INTO TimeSlipPostingRoster (EmployeeID, EmployeeLast, EmployeeFirst, PostDate, SumHours, Reason, EmployeeShift, PostingExist) Values (@EmployeeID, @EmployeeLast, @EmployeeFirst, @PostDate, @SumHours, @Reason, @EmployeeShift, @PostingExist)", con)

                With cmd.Parameters
                    .Add("@EmployeeID", SqlDbType.VarChar).Value = RowEmployeeID
                    .Add("@EmployeeLast", SqlDbType.VarChar).Value = RowEmployeeLast
                    .Add("@EmployeeFirst", SqlDbType.VarChar).Value = RowEmployeeFirst
                    .Add("@PostDate", SqlDbType.VarChar).Value = dtpPostingDate.Value
                    .Add("@SumHours", SqlDbType.VarChar).Value = RowHours
                    .Add("@Reason", SqlDbType.VarChar).Value = RowReason
                    .Add("@EmployeeShift", SqlDbType.VarChar).Value = RowShift
                    .Add("@PostingExist", SqlDbType.VarChar).Value = DoesPostingExist
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                CountIndex = CountIndex + 1
            Next

            GlobalTimeSlipValidation = "PASS"

            Me.Close()
        End If
    End Sub

    Private Sub dgvTimeSlipRoster_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTimeSlipRoster.ColumnHeaderMouseClick
        LoadDataFromTimeslips()
        'LoadFormatting()
    End Sub

    Private Sub chkSaturdayPosting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSaturdayPosting.CheckedChanged
        If chkSaturdayPosting.Checked = True Then
            cmdExit.Enabled = False
        ElseIf chkSaturdayPosting.Checked = False Then
            cmdExit.Enabled = True
        Else
            'Do nothing
        End If
    End Sub
End Class