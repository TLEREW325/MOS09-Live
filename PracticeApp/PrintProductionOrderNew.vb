Imports System
Imports System.Math
Imports System.IO
Imports System.Data
'Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintProductionOrderNew
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myadapter9, myadapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CRProductionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRProductionViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM FOXProductionQuery WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = GlobalFOXNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXProductionQuery")

        If GlobalProductionWorkOrder = "Work Order" Then
            If GlobalProductionOrderAutoprint = "YES" Then
                If con.State = ConnectionState.Closed Then con.Open()
                MyReport = CRXProductionOrder0221
                MyReport.SetDataSource(ds)
                MyReport.PrintToPrinter(3, True, 1, 999)
                con.Close()

                Me.Dispose()
                Me.Close()
            Else
                If con.State = ConnectionState.Closed Then con.Open()
                MyReport = CRXProductionOrder0221
                MyReport.SetDataSource(ds)
                CRProductionViewer.ReportSource = MyReport
                con.Close()
            End If
        ElseIf GlobalProductionWorkOrder = "Production Order" Then
            If GlobalProductionOrderAutoprint = "YES" Then
                If con.State = ConnectionState.Closed Then con.Open()
                MyReport = CRXProductionOrder0331
                MyReport.SetDataSource(ds)
                MyReport.PrintToPrinter(1, True, 1, 999)
                con.Close()

                Me.Dispose()
                Me.Close()
            Else
                If con.State = ConnectionState.Closed Then con.Open()
                MyReport = CRXProductionOrder0331
                MyReport.SetDataSource(ds)
                CRProductionViewer.ReportSource = MyReport
                con.Close()
            End If
        Else
            Dim button As DialogResult = MessageBox.Show("Do you wish to print a Production Order? Click NO for Work Order.", "PRINT PRODUCTION ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                If con.State = ConnectionState.Closed Then con.Open()
                MyReport = CRXProductionOrder0331
                MyReport.SetDataSource(ds)
                CRProductionViewer.ReportSource = MyReport
                con.Close()
            ElseIf button = DialogResult.No Then
                If con.State = ConnectionState.Closed Then con.Open()
                MyReport = CRXProductionOrder0221
                MyReport.SetDataSource(ds)
                CRProductionViewer.ReportSource = MyReport
                con.Close()
            End If
        End If
    End Sub

    Private Sub PrintProductionOrderNew_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalProductionWorkOrder = ""
        GlobalProductionOrderAutoprint = ""
    End Sub
End Class