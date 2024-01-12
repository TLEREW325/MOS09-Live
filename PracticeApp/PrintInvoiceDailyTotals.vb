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
Public Class PrintInvoiceDailyTotals
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

    Private Sub CRDailyViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRDailyViewer.Load
        'If EmployeeCompanyCode = "TFF" Or EmployeeCompanyCode = "TOR" Or EmployeeCompanyCode = "ALB" Then
        '    'Loads data into dataset for viewing
        '    cmd = New SqlCommand("SELECT * FROM InvoiceLineQueryCanadian WHERE DivisionID = @DivisionID ", con)
        '    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        '    If con.State = ConnectionState.Closed Then con.Open()
        '    ds = New DataSet()

        '    myAdapter.SelectCommand = cmd
        '    myAdapter.Fill(ds, "InvoiceLineQueryCanadian")

        '    'Sets up viewer to display data from the loaded dataset
        '    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '    MyReport = CRXInvoiceDailyTotalsCanadian1
        '    MyReport.SetDataSource(ds)
        '    CRDailyViewer.ReportSource = MyReport
        '    con.Close()
        'Else
        '    'Loads data into dataset for viewing
        '    cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        '    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        '    If con.State = ConnectionState.Closed Then con.Open()
        '    ds = New DataSet()

        '    myAdapter.SelectCommand = cmd
        '    myAdapter.Fill(ds, "InvoiceHeaderTable")

        '    'Sets up viewer to display data from the loaded dataset
        '    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '    MyReport = CRXInvoiceDailyTotals1
        '    MyReport.SetDataSource(ds)
        '    CRDailyViewer.ReportSource = MyReport
        '    con.Close()
        'End If
    End Sub

    Private Sub PrintInvoiceDailyTotals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        ClearFields()
        CRDailyViewer.ReportSource = Nothing

        If EmployeeCompanyCode = "TFF" Then
            rbSRLOnly.Enabled = True
            rbNotSRL.Enabled = True
            rbHarrisRebar.Enabled = True
            rbNotHarris.Enabled = True
            rdoAllCustomers.Enabled = True
        Else
            rbSRLOnly.Enabled = False
            rbNotSRL.Enabled = False
            rbHarrisRebar.Enabled = False
            rbNotHarris.Enabled = False
            rdoAllCustomers.Enabled = False
        End If
    End Sub

    Public Sub ClearFields()
        rbHarrisRebar.Checked = False
        rbNotHarris.Checked = False
        rbNotSRL.Checked = False
        rbSRLOnly.Checked = False
        rdoAllCustomers.Checked = True

        chkExclude.Checked = False

        cboItemClass.SelectedIndex = -1
        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        Dim SRLFilter As String = ""
        Dim HarrisFilter As String = ""
        Dim NotSRLFilter As String = ""
        Dim NotHarrisFilter As String = ""
        Dim ItemClassFilter As String = ""
        Dim BeginDate As Date = dtpBeginDate.Value
        Dim EndDate As Date = dtpEndDate.Value

        If rdoAllCustomers.Checked = True Then
            SRLFilter = ""
            HarrisFilter = ""
            NotSRLFilter = ""
            NotHarrisFilter = ""
        Else
            SRLFilter = ""
        End If
        If rbSRLOnly.Checked = True Then
            SRLFilter = " AND CustomerID = 'SRL INDUSTRIES'"
        Else
            SRLFilter = ""
        End If
        If rbHarrisRebar.Checked = True Then
            HarrisFilter = " AND CustomerID = 'HARRIS REBAR SASK.'"
        Else
            HarrisFilter = ""
        End If
        If rbNotSRL.Checked = True Then
            NotSRLFilter = " AND CustomerID <> 'SRL INDUSTRIES'"
        Else
            NotSRLFilter = ""
        End If
        If rbNotHarris.Checked = True Then
            NotHarrisFilter = " AND CustomerID <> 'HARRIS REBAR SASK.'"
        Else
            NotHarrisFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            If chkExclude.Checked = True Then
                ItemClassFilter = " AND ItemClass <> '" + cboItemClass.Text + "'"
            Else
                ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
            End If
        Else
            ItemClassFilter = ""
        End If
        If dtpBeginDate.Value = dtpEndDate.Value Then
            MsgBox("You must select a range of days (more than 1).", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Do nothing - date filter always used
        End If

        If EmployeeCompanyCode = "TFF" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceLineQueryCanadian WHERE DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate" + SRLFilter + HarrisFilter + NotSRLFilter + NotHarrisFilter + ItemClassFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Value

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceLineQueryCanadian")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXInvoiceDailyTotalsCanadian1
            MyReport.SetDataSource(ds)
            CRDailyViewer.ReportSource = MyReport
            con.Close()
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Value

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceHeaderTable")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXInvoiceDailyTotals1
            MyReport.SetDataSource(ds)
            CRDailyViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearFields()

        CRDailyViewer.ReportSource = Nothing
    End Sub
End Class