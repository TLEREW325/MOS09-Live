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
Public Class PrintSalesByCategory
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalGroupByCustomer = ""
        GlobalGroupByItemClass = ""
        GlobalGroupByMonth = ""
        GlobalGroupByPartNumber = ""
        GlobalGroupBySubtotal = ""
        GlobalGroupByAll = ""

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRSalesViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRSalesViewer.Load
        'Loads data into dataset for viewing
        ds = GDS

        'Sets up viewer to display data from the loaded dataset
        If con.State = ConnectionState.Closed Then con.Open()
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

        If GlobalGroupByAll = "YES" Then
            MyReport = CRXSalesByCategoryListing1
        ElseIf GlobalGroupByCustomer = "YES" Then
            MyReport = CRXSalesByCategoryCustomer1
        ElseIf GlobalGroupByItemClass = "YES" Then
            MyReport = CRXSalesByCategoryClass1
        ElseIf GlobalGroupByMonth = "YES" Then
            MyReport = CRXCustomerSalesbyMonth1
        ElseIf GlobalGroupByPartNumber = "YES" Then
            MyReport = CRXSalesByCategoryPart1
        ElseIf GlobalGroupBySubtotal = "YES" Then
            MyReport = CRXSalesByCategorySubtotal1
        Else
            MyReport = Nothing
        End If

        MyReport.SetDataSource(ds)
        CRSalesViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintSalesByCategory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalGroupByCustomer = ""
        GlobalGroupByItemClass = ""
        GlobalGroupByMonth = ""
        GlobalGroupByPartNumber = ""
        GlobalGroupBySubtotal = ""
        GlobalGroupByAll = ""
    End Sub
End Class