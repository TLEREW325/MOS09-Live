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
Public Class PrintConsignmentInventory
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds As DataSet

    Private Sub CRConsignmentInventoryViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRConsignmentInventoryViewer.Load
        ds = GDS

        'Sets up viewer to display data from the loaded dataset
        If con.State = ConnectionState.Closed Then con.Open()
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = crxConsignmentInventory1
        MyReport.SetDataSource(ds)
        CRConsignmentInventoryViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class