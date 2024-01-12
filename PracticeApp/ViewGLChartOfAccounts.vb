Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewGLChartOfAccounts
    Inherits System.Windows.Forms.Form

    Dim AccountTypeFilter, AccountFilter, TextFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewGLChartOfAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Public Sub ShowDataByFilters()
        If cboGLAccount.Text = "" Then
            AccountFilter = ""
        Else
            AccountFilter = " AND GLAccountNumber = '" + cboGLAccount.Text + "'"
        End If
        If cboGLAccountType.Text = "" Then
            AccountTypeFilter = ""
        Else
            AccountTypeFilter = " AND GLAccountType = '" + cboGLAccountType.Text + "'"
        End If
        If txtTextFilter.Text = "" Then
            TextFilter = ""
        Else
            TextFilter = " AND (GLAccountNumber LIKE '%" + txtTextFilter.Text + "%' OR GLAccountShortDescription LIKE '%" + txtTextFilter.Text + "%' OR GLAccountDescription LIKE '%" + txtTextFilter.Text + "%')"
        End If

        cmd = New SqlCommand("SELECT * FROM GLAccounts WHERE GLAccountNumber <> ''" + AccountTypeFilter + AccountFilter + TextFilter, con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLAccounts")
        dgvChartOfAccounts.DataSource = ds.Tables("GLAccounts")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvChartOfAccounts.DataSource = Nothing
    End Sub

    Public Sub LoadAccountNumber()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
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

    Public Sub LoadAccountType()
        cmd = New SqlCommand("SELECT DISTINCT GLAccountType FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLAccounts")
        cboGLAccountType.DataSource = ds2.Tables("GLAccounts")
        con.Close()
        cboGLAccountType.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboGLAccount.SelectedIndex = -1
        cboGLAccountType.SelectedIndex = -1
        cboGLDescription.SelectedIndex = -1

        txtTextFilter.Clear()

        cboGLAccount.Focus()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadAccountNumber()
        LoadAccountType()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        If txtAccountNumber.Text = "" Or txtAccountType.Text = "" Or txtCashFlow.Text = "" Or txtLongDescription.Text = "" Or txtShortDescription.Text = "" Or txtTypeID.Text = "' then" Then
            MsgBox("All fields must contain valid data", MsgBoxStyle.OkOnly)
        Else
            Try
                'Write new records only to GL Accounts
                cmd = New SqlCommand("INSERT INTO GLAccounts (GLAccountNumber, GLAccountShortDescription, GLAccountDescription, GLAccountType, GLAccountTypeID, GLAccountCashFlowCode) values (@GLAccountNumber, @GLAccountShortDescription, @GLAccountDescription, @GLAccountType, @GLAccountTypeID, @GLAccountCashFlowCode)", con)

                With cmd.Parameters
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtAccountNumber.Text
                    .Add("@GLAccountShortDescription", SqlDbType.VarChar).Value = txtShortDescription.Text
                    .Add("@GLaccountDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
                    .Add("@GLAccountType", SqlDbType.VarChar).Value = txtAccountType.Text
                    .Add("@GLAccountTypeID", SqlDbType.VarChar).Value = txtTypeID.Text
                    .Add("@GLAccountCashFlowCode", SqlDbType.VarChar).Value = txtCashFlow.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                MsgBox("You cannot write a duplicate record.", MsgBoxStyle.OkOnly)
            End Try
        End If

        'Clear Lines and reset form
        txtAccountNumber.Clear()
        txtAccountType.Clear()
        txtCashFlow.Clear()
        txtLongDescription.Clear()
        txtShortDescription.Clear()
        txtTypeID.Clear()

        MsgBox("A new GL Account has been created.", MsgBoxStyle.OkOnly)
        LoadAccountNumber()
        LoadAccountType()
    End Sub

    Private Sub dgvChartOfAccounts_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChartOfAccounts.CellValueChanged
        Dim RowGLAccountNumber As String = ""
        Dim RowShortDescription, RowLongDescription, RowAccountType, RowAccountTypeID, RowCashFlowCode As String

        If Me.dgvChartOfAccounts.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvChartOfAccounts.CurrentCell.RowIndex

            Try
                RowGLAccountNumber = Me.dgvChartOfAccounts.Rows(RowIndex).Cells("GLAccountNumberColumn").Value
            Catch ex As Exception
                RowGLAccountNumber = ""
            End Try
            Try
                RowShortDescription = Me.dgvChartOfAccounts.Rows(RowIndex).Cells("GLAccountShortDescriptionColumn").Value
            Catch ex As Exception
                RowShortDescription = ""
            End Try
            Try
                RowLongDescription = Me.dgvChartOfAccounts.Rows(RowIndex).Cells("GLAccountDescriptionColumn").Value
            Catch ex As Exception
                RowLongDescription = ""
            End Try
            Try
                RowAccountType = Me.dgvChartOfAccounts.Rows(RowIndex).Cells("GLAccountTypeColumn").Value
            Catch ex As Exception
                RowAccountType = ""
            End Try
            Try
                RowAccountTypeID = Me.dgvChartOfAccounts.Rows(RowIndex).Cells("GLAccountTypeIDColumn").Value
            Catch ex As Exception
                RowAccountTypeID = ""
            End Try
            Try
                RowCashFlowCode = Me.dgvChartOfAccounts.Rows(RowIndex).Cells("GLAccountCashFlowCodeColumn").Value
            Catch ex As Exception
                RowCashFlowCode = ""
            End Try

            'Validation

            If RowCashFlowCode = "BalanceSheet" Or RowCashFlowCode = "IncomeStatement" Then
                'Skip
            Else
                MsgBox("Update failed.", MsgBoxStyle.OkOnly)
                ShowDataByFilters()
                Exit Sub
            End If

            Try
                'Write new records only to GL Accounts
                cmd = New SqlCommand("UPDATE GLAccounts SET GLAccountShortDescription = @GLAccountShortDescription, GLaccountDescription = @GLaccountDescription, GLAccountType = @GLAccountType, GLAccountTypeID = @GLAccountTypeID, GLAccountCashFlowCode = @GLAccountCashFlowCode WHERE GLAccountNumber = @GLAccountNumber", con)

                With cmd.Parameters
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RowGLAccountNumber
                    .Add("@GLAccountShortDescription", SqlDbType.VarChar).Value = RowShortDescription
                    .Add("@GLaccountDescription", SqlDbType.VarChar).Value = RowLongDescription
                    .Add("@GLAccountType", SqlDbType.VarChar).Value = RowAccountType
                    .Add("@GLAccountTypeID", SqlDbType.VarChar).Value = RowAccountTypeID
                    .Add("@GLAccountCashFlowCode", SqlDbType.VarChar).Value = RowCashFlowCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'skip
            End Try
        End If
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Using NewPrintGLChartOfAccounts As New PrintGLChartOfAccounts
            Dim result = NewPrintGLChartOfAccounts.ShowDialog()
        End Using
    End Sub

    Private Sub PrintChartOfAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintChartOfAccountsToolStripMenuItem.Click
        Using NewPrintGLChartOfAccounts As New PrintGLChartOfAccounts
            Dim result = NewPrintGLChartOfAccounts.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class