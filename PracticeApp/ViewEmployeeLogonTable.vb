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
Public Class ViewEmployeeLogonTable
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ViewEmployeeLogonTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.EmployeeData' table. You can move, or remove it, as needed.
        Me.EmployeeDataTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.EmployeeData)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
            cmdClearLogonList.Enabled = True
        Else
            cmdClearLogonList.Enabled = False
        End If

        ClearAll()
        ShowData()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM UserLoginTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "UserLoginTable")
        dgvUserLoginTable.DataSource = ds.Tables("UserLoginTable")
        con.Close()
    End Sub

    Public Sub ShowDataByDateRange()
        cmd = New SqlCommand("SELECT * FROM UserLoginTable WHERE LoginDateTime BETWEEN @BeginDate AND @EndDate", con)
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "UserLoginTable")
        dgvUserLoginTable.DataSource = ds.Tables("UserLoginTable")
        con.Close()
    End Sub

    Public Sub ShowDataByEmployee()
        cmd = New SqlCommand("SELECT * FROM UserLoginTable WHERE LoginName = @LoginName", con)
        cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = cboLoginName.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "UserLoginTable")
        dgvUserLoginTable.DataSource = ds.Tables("UserLoginTable")
        con.Close()
    End Sub

    Public Sub ShowDataByDivision()
        cmd = New SqlCommand("SELECT * FROM UserLoginTable WHERE CompanyCode = @CompanyCode", con)
        cmd.Parameters.Add("@CompanyCode", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "UserLoginTable")
        dgvUserLoginTable.DataSource = ds.Tables("UserLoginTable")
        con.Close()
    End Sub

    Private Sub cmdViewByDivision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByDivision.Click
        ShowDataByDivision()
    End Sub

    Private Sub cmdViewByEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByEmployees.Click
        ShowDataByEmployee()
    End Sub

    Private Sub cmdViewByDateRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByDateRange.Click
        ShowDataByDateRange()
    End Sub

    Private Sub ClearAll()
        cboFName.SelectedIndex = -1
        cboLName.SelectedIndex = -1
        cboLoginName.SelectedIndex = -1
        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""
        ShowData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearAll()
        ShowData()
    End Sub

    Private Sub cmdClear1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear1.Click
        ClearAll()
        ShowData()
    End Sub

    Private Sub cmdClear2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear2.Click
        ClearAll()
        ShowData()
    End Sub

    Private Sub cmdClearLogonList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLogonList.Click
        Try
            'Delete logon records
            cmd = New SqlCommand("DELETE FROM UserLoginTable WHERE CompanyCode = @CompanyCode", con)

            With cmd.Parameters
                .Add("@CompanyCode", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox("Data cannot be cleared at this time.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class