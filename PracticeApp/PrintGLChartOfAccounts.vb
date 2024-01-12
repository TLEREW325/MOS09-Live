Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintGLChartOfAccounts
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim isFirst As Boolean

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Public Sub LoadGLAccounts()
        cmd = New SqlCommand("Select GLAccountNumber, GLAccountShortDescription from GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "GLAccounts")
        cboGLAccount.DataSource = ds1.Tables("GLAccounts")
        cboGLDescription.DataSource = ds1.Tables("GLAccounts")
        con.Close()
        cboGLAccount.SelectedIndex = -1
        cboGLDescription.SelectedIndex = -1

    End Sub

    Public Sub LoadGLAccountType()
        cmd = New SqlCommand("Select Distinct GLAccountType from GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLAccounts")
        cboAccountType.DataSource = ds2.Tables("GLAccounts")
        con.Close()
        cboAccountType.SelectedIndex = -1
    End Sub
    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click

        cmd = New SqlCommand("Select * from GLAccounts", con)
      
        isFirst = True
        If isFirst Then
            If Not String.IsNullOrEmpty(cboGLAccount.Text) Then
                cmd.CommandText += " WHERE GLAccountNumber = @GLAccountNumber"
                cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                isFirst = False
            End If
        Else
            If Not String.IsNullOrEmpty(cboGLAccount.Text) Then
                cmd.CommandText += " and GLAccountNumber = @GLAccountNumber"
                cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                isFirst = True
            End If
        End If
        If isFirst Then
            If Not String.IsNullOrEmpty(cboAccountType.Text) Then
                cmd.CommandText += " WHERE GLAccountType = @GLAccountType"
                cmd.Parameters.Add("@GLAccountType", SqlDbType.VarChar).Value = cboAccountType.Text
                isFirst = False
            End If
        Else
            If Not String.IsNullOrEmpty(cboAccountType.Text) Then
                cmd.CommandText += " and GLAccountType = @GLAccountType"
                cmd.Parameters.Add("@GLAccountType", SqlDbType.VarChar).Value = cboAccountType.Text
                isFirst = True
            End If
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLAccounts")
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXGLAccounts1
        MyReport.SetDataSource(ds)
        CRGLAccountViewer.ReportSource = MyReport

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        CRGLAccountViewer.ReportSource = Nothing
        cboGLAccount.SelectedIndex = -1
        cboGLDescription.SelectedIndex = -1
        cboAccountType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboGLAccount.Text) Then
            cboGLAccount.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboGLDescription.Text) Then
            cboGLDescription.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboAccountType.Text) Then
            cboAccountType.Text = ""
        End If


    End Sub

    Private Sub PrintGLChartOfAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadGLAccounts()
        LoadGLAccountType()
    End Sub
End Class