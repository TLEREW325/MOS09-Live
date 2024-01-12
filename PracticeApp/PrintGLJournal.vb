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
Public Class PrintGLJournal
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadGLAccount()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)

        ds3 = New DataSet()

        If con.State = ConnectionState.Closed Then con.Open()

        myAdapter3.SelectCommand = cmd

        myAdapter3.Fill(ds3, "GLAccounts")

        cboGLAccountNumber.DisplayMember = "GLAccountNumber"
        cboGlDesc.DisplayMember = "GLAccountShortDescription"
        cboGLAccountNumber.DataSource = ds3.Tables("GLAccounts")
        cboGlDesc.DataSource = ds3.Tables("GLAccounts")

        con.Close()
        cboGLAccountNumber.SelectedIndex = -1
        cboGlDesc.SelectedIndex = -1

    End Sub

    Private Sub PrintGLJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadGLAccount()
    End Sub

    Private Sub cmdGLAccountNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGLAccountNumber.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        cmd1 = New SqlCommand("SELECT * FROM GLAccounts", con)

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If Not String.IsNullOrEmpty(cboGlDesc.Text) Then
            cmd1.CommandText += " Where GLAccountShortDescription = @GLAccountShortDescription"
            cmd1.Parameters.Add("@GLAccountShortDescription", SqlDbType.VarChar).Value = cboGlDesc.Text
        End If
        If Not String.IsNullOrEmpty(cboGLAccountNumber.Text) Then
            cmd.CommandText += " and GLAccountNumber = @GLAccountNumber"
            cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        End If
        If chkDateRange.Checked Then
            cmd.CommandText += " and GLTransactionDate Between @BeginDate and @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLTransactionMasterList")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "GLAccounts")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXGLJournal1
        MyReport.SetDataSource(ds)
        CRJournalViewer.ReportSource = MyReport
        con.Close()
    End Sub

    

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboGLAccountNumber.SelectedIndex = -1
        cboGlDesc.SelectedIndex = -1
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateRange.Checked = False

        If Not String.IsNullOrEmpty(cboGLAccountNumber.Text) Then
            cboGLAccountNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboGlDesc.Text) Then
            cboGlDesc.Text = ""
        End If
        CRJournalViewer.ReportSource = Nothing

    End Sub
End Class