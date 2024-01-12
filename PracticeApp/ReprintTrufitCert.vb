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
Public Class ReprintTrufitCert
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myadapter5, myadapter6, myadapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRCertViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCertViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = GlobalTrufitCertNumber

        cmd1 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey", con)
        cmd1.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"

        cmd2 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        cmd3 = New SqlCommand("SELECT * FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        cmd4 = New SqlCommand("SELECT * FROM RawMaterialsTable", con)

        cmd5 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd5.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"

        cmd6 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        cmd7 = New SqlCommand("SELECT * FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd7.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = GlobalTrufitCertNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TrufitCertificationTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "SalesOrderHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "SalesOrderLineTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "FOXTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "RawMaterialsTable")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "DivisionTable")

        myAdapter6.SelectCommand = cmd6
        myAdapter6.Fill(ds, "CustomerList")

        myAdapter7.SelectCommand = cmd7
        myAdapter7.Fill(ds, "TrufitCertificationHeatLines")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTFCert1
        MyReport.SetDataSource(ds)
        CRCertViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub ReprintTrufitCert_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalTrufitCertNumber = 0
    End Sub
End Class