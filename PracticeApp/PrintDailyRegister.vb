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
Public Class PrintDailyRegister
    Inherits System.Windows.Forms.Form

    Dim CurrentDate As Date
    Dim BeginDate As String
    Dim EndDate As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub DefineDateRange()
        Dim MonthOfDate, YearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate, strYearOfDate As String

        CurrentDate = dtpEndDate.Value

        MonthOfDate = CurrentDate.Month
        YearOfDate = CurrentDate.Year

        strDayOfDate = "1"
        strMonthOfDate = CStr(MonthOfDate)
        strYearOfDate = CStr(YearOfDate)

        BeginDate = strMonthOfDate + "/" + strDayOfDate + "/" + strYearOfDate
        EndDate = dtpEndDate.Text
    End Sub

    Private Sub cmdFilterByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterByDate.Click
        'Delete from Temp Table
        cmd = New SqlCommand("DELETE FROM DivisionDateLinkTable WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '*********************************************************************************
        DefineDateRange()
        '*********************************************************************************
        'Write date and division into temp table
        cmd = New SqlCommand("INSERT INTO DivisionDateLinkTable (DivisionID, BeginDate, EndDate) values (@DivisionID, @BeginDate, @EndDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            .Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            .Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '*********************************************************************************
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM APCheckLog WHERE DivisionID = @DivisionID", con)
        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd6 = New SqlCommand("SELECT * FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd7 = New SqlCommand("SELECT * FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID", con)
        cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd8 = New SqlCommand("SELECT * FROM DivisionDateLinkTable WHERE DivisionID = @DivisionID", con)
        cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "PurchaseOrderHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "InvoiceHeaderTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ARCustomerPayment")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "APCheckLog")

        myAdapter6.SelectCommand = cmd6
        myAdapter6.Fill(ds, "ReceivingHeaderTable")

        myAdapter7.SelectCommand = cmd7
        myAdapter7.Fill(ds, "InventoryAdjustmentTable")

        myAdapter8.SelectCommand = cmd8
        myAdapter8.Fill(ds, "DivisionDateLinkTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXDailyRegister1
        MyReport.SetDataSource(ds)
        CRRegisterViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        dtpEndDate.Text = ""
        CRRegisterViewer.ReportSource = Nothing
    End Sub

    Private Sub PrintDailyRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CRRegisterViewer.ReportSource = Nothing
    End Sub

    Private Sub CRRegisterViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRRegisterViewer.Load
        CRRegisterViewer.ReportSource = Nothing
    End Sub
End Class