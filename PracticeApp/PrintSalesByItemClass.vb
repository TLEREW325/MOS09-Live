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
Public Class PrintSalesByItemClass
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRSalesViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRSalesViewer.Load
        'Loads data into dataset for viewing
        If GlobalDivisionCode = "TFP" Or GlobalDivisionCode = "TWD" Then
            cmd = New SqlCommand("SELECT * From InvoiceLineQuery WHERE DivisionID = 'TFP' OR DivisionID = 'TWD'", con)
        Else
            cmd = New SqlCommand("SELECT * From InvoiceLineQuery WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceLineQuery")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        If GlobalDivisionCode = "TWD" Then
            MyReport = CRXSalesByItemClass_TWD1
        ElseIf GlobalDivisionCode <> "TWD" Then
            MyReport = CRXSalesByItemClass1
        Else
            MyReport = Nothing
        End If
        MyReport.SetDataSource(ds)
        CRSalesViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class