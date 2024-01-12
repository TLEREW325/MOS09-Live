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
Public Class PrintAPAgingDated
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        DeleteTempTable()
        ds = New DataSet
        GDS = New DataSet
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRAgingViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRAgingViewer.Load
        'Loads data into dataset for viewing
        ds = Nothing
        ds = GDS

        'Loads data into dataset for viewing
        'cmd = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID = @DivisionID", con)
        'cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        'cmd1 = New SqlCommand("SELECT * FROM DivisionTable", con)

        If con.State = ConnectionState.Closed Then con.Open()

        'myAdapter.SelectCommand = cmd
        'myAdapter.Fill(ds, "Vendor")

        'myAdapter1.SelectCommand = cmd1
        'myAdapter1.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXAPAgingDated1
        MyReport.SetDataSource(ds)
        CRAgingViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Public Sub DeleteTempTable()
        Try
            'Clear Temp Table before writing
            cmd = New SqlCommand("DELETE FROM APAgingTempDate WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip
        End Try
    End Sub

    Private Sub PrintAPAgingDated_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DeleteTempTable()
        ds = New DataSet
        GDS = New DataSet
    End Sub
End Class