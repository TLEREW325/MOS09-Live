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
Public Class ViewSteelTransactions
    Inherits System.Windows.Forms.Form

    Dim CarbonFilter, SteelSizeFilter, TransactionTypeFilter, ReferenceNumberFilter, CarbonLikeFilter, DateFilter As String
    Dim BeginDate, EndDate As String
    Dim TotalSteelAdded, TotalSteelRemoved As Double
    Dim CarbonPrefix As String = ""
    Dim CarbonLength As Integer = 0


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ViewSteelTransactions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        ClearData()
        ClearVariables()

        LoadSteelSize()
        LoadSteelType()
        LoadTransactionType()
        LoadReferenceNumber()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If
    End Sub

    Public Sub ShowDataByFilters()
        If cboCarbon.Text <> "" Then
            If chkAllTypes.Checked = True Then
                CarbonLength = cboCarbon.Text.Length
                If CarbonLength > 4 Then
                    CarbonPrefix = cboCarbon.Text.Substring(0, 5)
                Else
                    CarbonPrefix = cboCarbon.Text.Substring(0, CarbonLength)
                End If
                CarbonFilter = " AND Carbon LIKE '%" + CarbonPrefix + "%'"
            Else
                CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
            End If
        Else
            CarbonFilter = ""
        End If
        If cboSteelSize.Text <> "" Then
            SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
        Else
            SteelSizeFilter = ""
        End If
        If cboTransactionType.Text <> "" Then
            TransactionTypeFilter = " AND TransactionType = '" + cboTransactionType.Text + "'"
        Else
            TransactionTypeFilter = ""
        End If
        If cboReferenceNumber.Text <> "" Then
            ReferenceNumberFilter = " AND SteelReferenceNumber = '" + cboReferenceNumber.Text + "'"
        Else
            ReferenceNumberFilter = ""
        End If
        If chkDateRange.Checked = False Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND SteelTransactionDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM SteelTransactionTable WHERE DivisionID = 'TWD'" + CarbonFilter + SteelSizeFilter + TransactionTypeFilter + ReferenceNumberFilter + DateFilter + " ORDER BY SteelTransactionDate", con)
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelTransactionTable")
        dgvSteelTransactions.DataSource = ds.Tables("SteelTransactionTable")
        con.Close()
    End Sub

    Public Sub ClearDatagrid()
        dgvSteelTransactions.DataSource = Nothing
    End Sub

    Public Sub LoadSteelType()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadTransactionType()
        cmd = New SqlCommand("SELECT DISTINCT TransactionType FROM SteelTransactionTable ORDER BY TransactionType", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SteelTransactionTable")
        cboTransactionType.DataSource = ds3.Tables("SteelTransactionTable")
        con.Close()
        cboTransactionType.SelectedIndex = -1
    End Sub

    Public Sub LoadReferenceNumber()
        cmd = New SqlCommand("SELECT DISTINCT SteelReferenceNumber FROM SteelTransactionTable ORDER BY SteelReferenceNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SteelTransactionTable")
        cboReferenceNumber.DataSource = ds3.Tables("SteelTransactionTable")
        con.Close()
        cboReferenceNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadTotals()
        If cboCarbon.Text <> "" Then
            If chkAllTypes.Checked = True Then
                CarbonLength = cboCarbon.Text.Length
                If CarbonLength > 4 Then
                    CarbonPrefix = cboCarbon.Text.Substring(0, 5)
                Else
                    CarbonPrefix = cboCarbon.Text.Substring(0, CarbonLength)
                End If
                CarbonFilter = " AND Carbon LIKE '%" + CarbonPrefix + "%'"
            Else
                CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
            End If
        Else
            CarbonFilter = ""
        End If
        If cboSteelSize.Text <> "" Then
            SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
        Else
            SteelSizeFilter = ""
        End If
        If cboTransactionType.Text <> "" Then
            TransactionTypeFilter = " AND TransactionType = '" + cboTransactionType.Text + "'"
        Else
            TransactionTypeFilter = ""
        End If
        If cboReferenceNumber.Text <> "" Then
            ReferenceNumberFilter = " AND SteelReferenceNumber = '" + cboReferenceNumber.Text + "'"
        Else
            ReferenceNumberFilter = ""
        End If
        If chkDateRange.Checked = False Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND SteelTransactionDate BETWEEN @BeginDate AND @EndDate"
        End If

        Dim TotalSteelAddedStatement As String = "SELECT SUM(Quantity) FROM SteelTransactionTable WHERE DivisionID = 'TWD' AND TransactionMath = 'ADD'" + CarbonFilter + SteelSizeFilter + TransactionTypeFilter + ReferenceNumberFilter + DateFilter
        Dim TotalSteelAddedCommand As New SqlCommand(TotalSteelAddedStatement, con)
        TotalSteelAddedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalSteelAddedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalSteelRemovedStatement As String = "SELECT SUM(Quantity) FROM SteelTransactionTable WHERE DivisionID = 'TWD' AND TransactionMath = 'SUBTRACT'" + CarbonFilter + SteelSizeFilter + TransactionTypeFilter + ReferenceNumberFilter + DateFilter
        Dim TotalSteelRemovedCommand As New SqlCommand(TotalSteelRemovedStatement, con)
        TotalSteelRemovedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalSteelRemovedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalSteelAdded = CDbl(TotalSteelAddedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSteelAdded = 0
        End Try
        Try
            TotalSteelRemoved = CDbl(TotalSteelRemovedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSteelRemoved = 0
        End Try
        con.Close()

        lblTotalMaterialAdded.Text = TotalSteelAdded
        lblTotalMaterialRemoved.Text = TotalSteelRemoved
    End Sub

    Public Sub ClearData()
        chkAllTypes.Checked = False
        chkDateRange.Checked = False

        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboReferenceNumber.SelectedIndex = -1
        cboTransactionType.SelectedIndex = -1


    End Sub

    Public Sub ClearVariables()

    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearDatagrid()
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cmdPrintListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintListing.Click

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class
