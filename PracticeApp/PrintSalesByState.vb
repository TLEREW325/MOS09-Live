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
Public Class PrintSalesByState
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRStateViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRStateViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM StateTable", con)

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderQuery")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "StateTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSalesbyState1
        MyReport.SetDataSource(ds)
        CRStateViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintSalesByState_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)
        cboState.SelectedIndex = -1
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        If cboState.Text = "" Then
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        Else
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID and FinalShipState = @ShipState", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@ShipState", SqlDbType.VarChar).Value = cboState.Text
        End If
       
        cmd1 = New SqlCommand("SELECT * FROM StateTable", con)

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderQuery")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "StateTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSalesbyState1
        MyReport.SetDataSource(ds)
        CRStateViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class