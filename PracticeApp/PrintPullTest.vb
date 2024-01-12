Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintPullTest
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand


    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal testNumber As String)
        InitializeComponent()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From PullTestQuery WHERE TestNumber = @TestNumber", con)
        cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = testNumber
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "PullTestQuery")
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXPullTest1
        MyReport.SetDataSource(ds)
        CRTestViewer.ReportSource = MyReport
    End Sub
    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class