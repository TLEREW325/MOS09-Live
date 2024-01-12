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
Public Class ViewAuditTrail
    Inherits System.Windows.Forms.Form

    Dim AuditReferenceFilter As String = ""
    Dim DateFilter As String = ""
    Dim DivisionFilter As String = ""
    Dim UserFilter As String = ""
    Dim TypeFilter As String = ""
    Dim TextFilter As String = ""


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ViewAuditTrail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvAuditTrail.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If txtReferenceNumber.Text <> "" Then
            AuditReferenceFilter = " AND AuditReferenceNumber LIKE '%" + txtReferenceNumber.Text + "%'"
        Else
            AuditReferenceFilter = ""
        End If
        If txtUserID.Text <> "" Then
            UserFilter = " AND UserID LIKE '%" + txtUserID.Text + "%'"
        Else
            UserFilter = ""
        End If
        If txtAuditType.Text <> "" Then
            TypeFilter = " AND AuditType LIKE '%" + txtAuditType.Text + "%'"
        Else
            TypeFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (AuditComment LIKE '%" + txtTextFilter.Text + "%' OR AuditType LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboDivisionID.Text <> "ADM" Then
            DivisionFilter = " AND DivisionID = '" + cboDivisionID.Text + "'"
        Else
            DivisionFilter = " AND DivisionID <> 'ADM'"
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND AuditDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM AuditTrail WHERE DivisionID <> @DivisionID1" + AuditReferenceFilter + UserFilter + TextFilter + TypeFilter + DivisionFilter + DateFilter + " ORDER BY DivisionID", con)
        cmd.Parameters.Add("@DivisionID1", SqlDbType.VarChar).Value = "ZZZ"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AuditTrail")
        dgvAuditTrail.DataSource = ds.Tables("AuditTrail")
        con.Close()
    End Sub

    Public Sub ShowDataByFiltersADM()
        If txtReferenceNumber.Text <> "" Then
            AuditReferenceFilter = " AND AuditReferenceNumber LIKE '%" + txtReferenceNumber.Text + "%'"
        Else
            AuditReferenceFilter = ""
        End If
        If txtUserID.Text <> "" Then
            UserFilter = " AND UserID LIKE '%" + txtUserID.Text + "%'"
        Else
            UserFilter = ""
        End If
        If txtAuditType.Text <> "" Then
            TypeFilter = " AND AuditType LIKE '%" + txtAuditType.Text + "%'"
        Else
            TypeFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (AuditComment LIKE '%" + txtTextFilter.Text + "%' OR AuditType LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND AuditDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM AuditTrail WHERE DivisionID <> @DivisionID1" + AuditReferenceFilter + UserFilter + TextFilter + TypeFilter + DateFilter + " ORDER BY DivisionID", con)
        cmd.Parameters.Add("@DivisionID1", SqlDbType.VarChar).Value = "ZZZ"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AuditTrail")
        dgvAuditTrail.DataSource = ds.Tables("AuditTrail")
        con.Close()
    End Sub

    Public Sub ClearData()
        txtAuditType.Clear()
        txtReferenceNumber.Clear()
        txtUserID.Clear()
        txtTextFilter.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintAuditTrail As New PrintAuditTrail
            Dim Result = NewPrintAuditTrail.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintAuditTrail As New PrintAuditTrail
            Dim Result = NewPrintAuditTrail.ShowDialog()
        End Using
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        If cboDivisionID.Text = "ADM" Then
            ShowDataByFiltersADM()
        Else
            ShowDataByFilters()
        End If
    End Sub

    Private Sub cmdClear1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear1.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub txtTextFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTextFilter.TextChanged

    End Sub
End Class