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
Public Class PrintTimeSlipPostings
    Inherits System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd1 As New SqlCommand("SELECT EmployeeID, EmployeeLast, EmployeeFirst from EmployeeData WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'ADM'", con)
        Dim cmd2 As New SqlCommand("SELECT RMID, Carbon, SteelSize from RawMaterialsTable", con)
        Dim cmd3 As New SqlCommand("SELECT * FROM TimeSlipCombinedData WHERE TimeSlipKey = @TimeSlipKey", con)
        cmd3.Parameters.Add("@TimeSlipKey", SqlDbType.Int).Value = GlobalTimeSlipNumber
        Dim cmd4 As New SqlCommand("SELECT ItemID, ShortDescription, LongDescription, DivisionID FROM ItemList WHERE DivisionID = 'TWD' OR DivisionID = 'TFP'", con)
        Dim cmd5 As New SqlCommand("SELECT FOXNumber, ProcessStep, ProcessAddFG FROM FOXSched", con)
        Dim myAdapter1 As New SqlDataAdapter(cmd1)
        Dim myAdapter2 As New SqlDataAdapter(cmd2)
        Dim myAdapter3 As New SqlDataAdapter(cmd3)
        Dim myAdapter4 As New SqlDataAdapter(cmd4)
        Dim myAdapter5 As New SqlDataAdapter(cmd5)
        Dim ds As New DataSet()

        If con.State = ConnectionState.Closed Then con.Open()

        myAdapter1.Fill(ds, "EmployeeData")
        myAdapter2.Fill(ds, "RawMaterialsTable")
        myAdapter3.Fill(ds, "TimeSlipCombinedData")
        myAdapter4.Fill(ds, "ItemList")
        myAdapter5.Fill(ds, "ItemList")
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = New CRXTimeSlipPostings
        MyReport.SetDataSource(ds)
        CRTimeViewer.ReportSource = MyReport
    End Sub
    Public Sub New(ByVal ds As DataSet, Optional ByVal WithTotals As Boolean = False)
        InitializeComponent()

        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd1 As New SqlCommand("SELECT EmployeeID, EmployeeLast, EmployeeFirst from EmployeeData WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'ADM'", con)
        Dim cmd2 As New SqlCommand("SELECT RMID, Carbon, SteelSize from RawMaterialsTable", con)
        Dim cmd3 As New SqlCommand("SELECT ItemID, ShortDescription, LongDescription, DivisionID FROM ItemList WHERE DivisionID = 'TWD' OR DivisionID = 'TFP'", con)
        Dim cmd4 As New SqlCommand("SELECT FOXNumber, ProcessStep, ProcessAddFG FROM FOXSched", con)
        Dim myAdapter1 As New SqlDataAdapter(cmd1)
        Dim myAdapter2 As New SqlDataAdapter(cmd2)
        Dim myAdapter3 As New SqlDataAdapter(cmd3)
        Dim myAdapter4 As New SqlDataAdapter(cmd4)
        If con.State = ConnectionState.Closed Then con.Open()

        myAdapter1.Fill(ds, "EmployeeData")
        myAdapter2.Fill(ds, "RawMaterialsTable")
        myAdapter3.Fill(ds, "ItemList")
        myAdapter4.Fill(ds, "FOXSched")
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        If WithTotals Then
            MyReport = New CRXTimeSlipPostingsWithTotals
        Else
            MyReport = New CRXTimeSlipPostings
        End If

        MyReport.SetDataSource(ds)
        CRTimeViewer.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class