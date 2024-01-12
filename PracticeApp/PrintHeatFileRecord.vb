Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintHeatFileRecord
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds As DataSet

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal heatFile As String)
        InitializeComponent()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber;", con)
        cmd.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = heatFile
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "HeatNumberLog")
        con.Close()
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport As CrystalDecisions.CrystalReports.Engine.ReportDocument = crxHeatFileRecord1
        MyReport.SetDataSource(ds)
        CRVHeatFileRecord.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRVHeatFileRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVHeatFileRecord.Load

    End Sub
End Class