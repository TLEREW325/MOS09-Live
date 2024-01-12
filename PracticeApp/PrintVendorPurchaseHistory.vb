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
Public Class PrintVendorPurchaseHistory
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

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboVendorID.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Private Sub PrintVendorPurchaseHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadVendor()

        If GlobalVendorID <> "" Then
            cboVendorID.Text = GlobalVendorID
        Else
            cboVendorID.SelectedIndex = -1
        End If
    End Sub

    Private Sub cmdFilterByVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterByVendor.Click
        If cboVendorID.Text = "" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * From ReceivingHeaderTable WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * From ReceivingLineTable", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceivingHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ReceivingLineTable")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXItemsPurVendor1
            MyReport.SetDataSource(ds)
            CRPurchaseHistoryViewer.ReportSource = MyReport
            con.Close()
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * From ReceivingHeaderTable WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text

            cmd1 = New SqlCommand("SELECT * From ReceivingLineTable", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceivingHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ReceivingLineTable")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXItemsPurVendor1
            MyReport.SetDataSource(ds)
            CRPurchaseHistoryViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboVendorID.SelectedIndex = -1

        CRPurchaseHistoryViewer.ReportSource = Nothing
    End Sub
End Class