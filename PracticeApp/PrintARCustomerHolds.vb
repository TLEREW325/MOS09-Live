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
Public Class PrintARCustomerHolds
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRCustomerViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCustomerViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID AND (OnHoldStatus ='YES' OR AccountingHold = 'YES')", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CustomerList")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ARAgingCategory")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXARCustomerHolds1
        MyReport.SetDataSource(ds)
        CRCustomerViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub AllCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllCompanyToolStripMenuItem.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM CustomerList WHERE OnHoldStatus ='YES' OR AccountingHold = 'YES' ORDER BY DivisionID", con)
        'cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM ARAgingCategory", con)
        'cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CustomerList")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ARAgingCategory")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXARCustomerHolds1
        MyReport.SetDataSource(ds)
        CRCustomerViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintARCustomerHolds_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If EmployeeSecurityCode = "1002" Or EmployeeSecurityCode = "1001" Then
            AllCompanyToolStripMenuItem.Enabled = True
        Else
            AllCompanyToolStripMenuItem.Enabled = False
        End If
    End Sub
End Class