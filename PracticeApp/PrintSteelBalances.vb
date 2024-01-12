Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class PrintSteelBalances
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim dt As Data.DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Public Sub New()
        InitializeComponent()
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CRXSteelBalances
        CRVSteelBalances.ReportSource = MyReport
        con.Close()
    End Sub
    Public Sub New(ByVal dt As Data.DataTable)
        InitializeComponent()
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CRXSteelBalances
        MyReport.SetDataSource(dt)
        CRVSteelBalances.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub CRVSteelBalances_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVSteelBalances.Load

    End Sub
End Class