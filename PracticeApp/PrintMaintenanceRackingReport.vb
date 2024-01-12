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
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports WIA
Imports PdfSharp.Pdf
Imports System.Threading
Imports iTextSharp.text.Image
Imports PdfSharp
Imports document = iTextSharp.text.Document
Imports System.Drawing
Imports System.ComponentModel
Imports iTextSharp
Imports System.Reflection

Public Class PrintMaintenanceRackingReport
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable



    Private Sub ViewMaintenanceRackingReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If EmployeeCompanyCode = "ADM" Then
            If con.State = ConnectionState.Closed Then con.Open()
            cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable ORDER BY BinNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "MaintenanceRackingTable")
        Else
            If con.State = ConnectionState.Closed Then con.Open()
            cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID ORDER BY BinNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "MaintenanceRackingTable")
        End If



        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXMaintenanceRackingReport1
        MyReport.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class