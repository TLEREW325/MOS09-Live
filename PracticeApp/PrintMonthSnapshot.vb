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
Public Class PrintMonthSnapshot
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalMonthField = ""
        GlobalYearField = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRMonthViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRMonthViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM MonthTotalTempTable WHERE DivisionID = @DivisionID AND MonthField = @MonthField AND YearField = @YearField", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@MonthField", SqlDbType.VarChar).Value = GlobalMonthField
        cmd.Parameters.Add("@YearField", SqlDbType.VarChar).Value = GlobalYearField

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "MonthTotalTempTable")
        con.Close()

        MyReport = CRXMonthSnapshot1
        MyReport.SetDataSource(ds)
        CRMonthViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintMonthSnapshot_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalMonthField = ""
        GlobalYearField = ""
    End Sub
End Class