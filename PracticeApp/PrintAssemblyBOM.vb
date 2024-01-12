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
Public Class PrintAssemblyBOM
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalAssemblyPartNumber = ""

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRBOMViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRBOMViewer.Load
        'Loads data into dataset for viewing
       
        cmd1 = New SqlCommand("SELECT * FROM AssemblyLineQuery WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber AND ItemClass <> 'TWE TFP MACHINE COST'", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalAssemblyPartNumber


        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "AssemblyLineQuery")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXAssemblyBOM1
        MyReport.SetDataSource(ds)
        CRBOMViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class