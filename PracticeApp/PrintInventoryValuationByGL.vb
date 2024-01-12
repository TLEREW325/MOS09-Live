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
Public Class PrintInventoryValuationByGL
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

    Private Sub PrintInventoryValuationByGL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadGLAccounts()
    End Sub

    Public Sub LoadGLAccounts()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "GLAccounts")
        cboGLInvAccount.DataSource = ds1.Tables("GLAccounts")
        cboAccountDescription.DataSource = ds1.Tables("GLAccounts")
        con.Close()
        cboGLInvAccount.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
    End Sub

    Private Sub CRGLViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRGLViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND TransactionDate <= @TransactionDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = GlobalValuationDate

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryTransactionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXInventoryValuationByGL1
        MyReport.SetDataSource(ds)
        CRGLViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub Filter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InventoryTransactionTable WHERE DivisionID = @DivisionID and GLAccount = @GLAccount AND TransactionDate <= @TransactionDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@GLAccount", SqlDbType.VarChar).Value = cboGLInvAccount.Text
        cmd.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = GlobalValuationDate

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryTransactionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXInventoryValuationByGL1
        MyReport.SetDataSource(ds)
        CRGLViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboGLInvAccount.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1

        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND TransactionDate <= @TransactionDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = GlobalValuationDate

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryTransactionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXInventoryValuationByGL1
        MyReport.SetDataSource(ds)
        CRGLViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class