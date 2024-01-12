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
Public Class PrintInventoryUsageByMonth
    Inherits System.Windows.Forms.Form

    Dim ItemClassFilter, PartFilter, Text1Filter, Text2Filter, Text3Filter, Text4Filter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub PrintInventoryUsageByMonth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        LoadPartNumber()

        cboItemClass.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboDescription.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboDescription.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1

        txtTextFilter1.Clear()
        txtTextFilter2.Clear()
        txtTextFilter3.Clear()
        txtTextFilter4.Clear()

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        ItemClassFilter = ""
        PartFilter = ""
        Text1Filter = ""
        Text2Filter = ""
        Text3Filter = ""
        Text4Filter = ""
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        'Loads data into dataset for viewing
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtTextFilter1.Text <> "" Then
            Text1Filter = " AND (PartNumber LIKE '%" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%' OR PartDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter1.Text) + "%')"
        Else
            Text1Filter = ""
        End If
        If txtTextFilter2.Text <> "" Then
            Text2Filter = " AND (PartNumber LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%' OR PartDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%')"
        Else
            Text2Filter = ""
        End If
        If txtTextFilter3.Text <> "" Then
            Text3Filter = " AND (PartNumber LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%' OR PartDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%')"
        Else
            Text3Filter = ""
        End If
        If txtTextFilter4.Text <> "" Then
            Text4Filter = " AND (PartNumber LIKE '%" + usefulFunctions.checkQuote(txtTextFilter4.Text) + "%' OR PartDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter4.Text) + "%')"
        Else
            Text4Filter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID" + PartFilter + ItemClassFilter + Text1Filter + Text2Filter + Text3Filter + Text4Filter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd1.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceLineQuery")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXInventoryUsebyMonth1
        MyReport.SetDataSource(ds)
        CRInventoryViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        CRInventoryViewer.ReportSource = Nothing
        con.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

End Class