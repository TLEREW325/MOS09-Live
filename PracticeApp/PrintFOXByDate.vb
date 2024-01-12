Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintFOXByDate
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub LoadFoxNumber()
        cmd = New SqlCommand("Select FoxNumber from FoxTable where DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds1, "FoxTable")
        cboFox.DataSource = ds1.Tables("FoxTable")
        con.Close()
        cboFox.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerData()
        cmd = New SqlCommand("Select CustomerID, CustomerName from CustomerList where DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds2, "CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        cboCustomerName.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1

    End Sub
    Public Sub LoadPartData()
        cmd = New SqlCommand("Select ItemID, ShortDescription from ItemList where DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds3, "ItemList")
        cboPartNumber.DataSource = ds3.Tables("ItemList")
        cboPartDescription.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

    End Sub

    Private Sub CRFOXViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRFOXViewer.Load
        LoadFoxNumber()
        LoadCustomerData()
        LoadPartData()
    End Sub


    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub


    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        cmd1 = New SqlCommand("SELECT * FROM FOXReleaseSchedule", con)

        cmd2 = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionKey", con)
        cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If chkDateRange.Checked Then
            cmd1.CommandText += " WHERE PromiseDate Between @BeginDate and @EndDate"
            cmd1.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
            cmd1.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
        End If

        If Not String.IsNullOrEmpty(cboFox.Text) Then
            cmd.CommandText += " and FoxNumber = @FoxNumber"
            cmd.Parameters.Add("@FoxNumber", SqlDbType.Int).Value = Val(cboFox.Text)
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cmd.CommandText += " and PartNumber = @ItemID"
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            cmd2.CommandText += " and ItemID = @ItemID"
            cmd2.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            cmd.CommandText += " and CustomerID = @CustomerID"
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

            cmd3.CommandText += " and CustomerID = @CustomerID"
            cmd3.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        End If

        myAdapter.SelectCommand = cmd
        myAdapter1.SelectCommand = cmd1
        myAdapter2.SelectCommand = cmd2
        myAdapter3.SelectCommand = cmd3
        myAdapter4.SelectCommand = cmd4
        ds = New DataSet()

        If con.State = ConnectionState.Closed Then con.Open()

        myAdapter.Fill(ds, "FOXTable")
        myAdapter1.Fill(ds, "FoxReleaseSchedule")
        myAdapter2.Fill(ds, "ItemList")
        myAdapter3.Fill(ds, "CustomerList")
        myAdapter4.Fill(ds, "SalesOrderQuantityStatus")
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport As New CRXFoxbyPromiseDate
        'MyReport = CRXFoxbyPromiseDate1
        MyReport.SetDataSource(ds)
        CRFOXViewer.ReportSource = MyReport

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboFox.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateRange.Checked = False
        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            cboCustomerID.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cboCustomerName.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboFox.Text) Then
            cboFox.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
            cboPartDescription.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        CRFOXViewer.ReportSource = Nothing
    End Sub
End Class