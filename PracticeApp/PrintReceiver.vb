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
Public Class PrintReceiver
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=45")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalReceiverNumber = 0
        GlobalAutoPrintReceiver = "NO"

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRReceiverViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRReceiverViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID AND ReceivingHeaderKey = @ReceivingHeaderKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalReceiverNumber

        cmd1 = New SqlCommand("SELECT * FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND ReceivingHeaderKey = @ReceivingHeaderKey", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalReceiverNumber

        cmd2 = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceivingHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ReceivingLineQuery")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "PurchaseOrderQuantityStatus")

        If GlobalAutoPrintReceiver = "YES" Then
            MyReport = CRXReceivingTicket1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            con.Close()

            Me.Close()
        Else
            MyReport = CRXReceivingTicket1
            MyReport.SetDataSource(ds)
            CRReceiverViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub PrintReceiver_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        GlobalReceiverNumber = 0
        GlobalAutoPrintReceiver = "NO"
    End Sub
End Class