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
Public Class PrintSteelAdjustment
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds As New DataSet()

    Dim batch As String = ""
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal data As DataSet)
        InitializeComponent()
        ds = data
    End Sub
    Public Sub New(ByVal bat As String)
        InitializeComponent()
        batch = bat
        LoadDataSet()
    End Sub
    Public Sub New(ByVal data As Data.DataTable)
        InitializeComponent()
        ds = New Data.DataSet
        ds.Tables.Add(data)
    End Sub
    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub LoadDataSet()
        cmd = New SqlCommand("SELECT * FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = batch
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SteelAdjustmentTable")
        con.Close()
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSteelAdjustment1
        MyReport.SetDataSource(ds)
        CRAdjustmentViewer.ReportSource = MyReport
    End Sub

    Public Sub setAdjustmentNumber(ByVal adj As String)
        cmd = New SqlCommand("Select isnull(BatchNumber, 0) FROM SteelAdjustmentTable WHERE SteelAdjustmentKey = @SteelAdjustmentKey", con)
        cmd.Parameters.Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = adj

        If con.State = ConnectionState.Closed Then con.Open()
        batch = cmd.ExecuteScalar()
        con.Close()

        LoadDataSet()
    End Sub

    Private Sub CRAdjustmentViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRAdjustmentViewer.Load
        If ds.Tables.Count > 0 Then
            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXSteelAdjustment1
            MyReport.SetDataSource(ds)
            CRAdjustmentViewer.ReportSource = MyReport
        End If
    End Sub
End Class