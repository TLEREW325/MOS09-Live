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
Public Class PrintFOXPostingReport
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "FOXTable")
        cboFox.DataSource = ds4.Tables("FOXTable")
        con.Close()
        cboFox.SelectedIndex = -1
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintFOXPostingReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFOXNumber()
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM TimeSlipHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM TimeSlipLineItemTable", con)

        cmd2 = New SqlCommand("SELECT * FROM MachineTable WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode


        If Not String.IsNullOrEmpty(cboFox.Text) Then
            cmd1.CommandText += " WHERE FoxNumber = @FoxNumber"
            cmd1.Parameters.Add("@FoxNumber", SqlDbType.VarChar).Value = cboFox.Text
        End If

        If chkDateRange.Checked Then
            cmd.CommandText += " AND PostingDate BETWEEN @BeginDate AND @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TimeSlipHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "TimeSlipLineItemTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "MachineTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXFoxPostingReport1
        MyReport.SetDataSource(ds)
        CRFOXViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdCLear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCLear.Click
        CRFOXViewer.ReportSource = Nothing

        cboFox.SelectedIndex = -1

        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateRange.Checked = False

        If Not String.IsNullOrEmpty(cboFox.Text) Then
            cboFox.Text = ""
        End If
    End Sub
End Class