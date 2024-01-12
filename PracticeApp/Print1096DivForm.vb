Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Print1096DivForm
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    'Dim dt As DataTable

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        'Loads data into dataset for viewing
        ds1 = GDS2

        cmd1 = New SqlCommand("SELECT * FROM Vendor", con)
        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds1, "Vendor")

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)
        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds1, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

        MyReport = CRX1096FormDIV1
        MyReport.SetDataSource(ds1)
        CrystalReportViewer1.ReportSource = MyReport
        CRX1096FormDIV1.SetParameterValue("count", GlobalVariables.stringVar2)
        con.Close()
    End Sub

End Class

