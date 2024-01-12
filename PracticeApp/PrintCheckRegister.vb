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
Public Class PrintCheckRegister
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadCheckNumber()
        cmd = New SqlCommand("SELECT CheckNumber FROM APCheckQuery WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "APCheckQuery")
        cboCheckNumber.DataSource = ds1.Tables("APCheckQuery")
        con.Close()
        cboCheckNumber.SelectedIndex = -1
    End Sub

    Private Sub PrintCheckRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCheckNumber()
    End Sub

    Private Sub cmdCheckNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckNumber.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM APCheckQuery WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode


        cmd1 = New SqlCommand("SELECT * FROM DivisionTable", con)

        cmd2 = New SqlCommand("SELECT * FROM APVoucherTable WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode


        If Not String.IsNullOrEmpty(cboCheckNumber.Text) Then
            cmd.CommandText += " and CheckNumber = @CheckNumber"
            cmd.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
        End If

        If chkDateRange.Checked Then
            cmd.CommandText += " and CheckDate BETWEEN @BeginDate and @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckQuery")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "DivisionTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "APVoucherTable")
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCheckRegister1
        MyReport.SetDataSource(ds)
        CRCheckRegisterViewer.ReportSource = MyReport
    End Sub

    

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCheckNumber.SelectedIndex = -1
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateRange.Checked = False
        If Not String.IsNullOrEmpty(cboCheckNumber.Text) Then
            cboCheckNumber.Text = ""
        End If

        CRCheckRegisterViewer.ReportSource = Nothing

    End Sub

End Class