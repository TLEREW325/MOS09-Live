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
Public Class PrintRackingByFilter
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalPrintRackingType = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRRackViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRRackViewer.Load
        If GlobalPrintRackingType = "PrintListing" Then
            ds = GDS

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXRackingByFilterNew1
            MyReport.SetDataSource(ds)
            CRRackViewer.ReportSource = MyReport
        ElseIf GlobalPrintRackingType = "PrintPickTicket" Then
            'Autoprint
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM PickListLineTable WHERE DivisionID = @DivisionID AND PickListHeaderKey = @PickListHeaderKey", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd1.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber

            cmd2 = New SqlCommand("SELECT * FROM ADMInventoryTotal WHERE DivisionID = @DivisionID", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "RackingTransactionTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "PickListLineTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "ADMInventoryTotal")

            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXRackingShipmentItemLocation1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            con.Close()

            Me.Close()
        Else
            ds = GDS

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXRackingFilter1
            MyReport.SetDataSource(ds)
            CRRackViewer.ReportSource = MyReport
        End If
    End Sub

    Private Sub PrintRackingByFilter_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalPrintRackingType = ""
    End Sub
End Class