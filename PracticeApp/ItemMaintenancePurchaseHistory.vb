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
Public Class ItemMaintenancePurchaseHistory
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ItemMaintenancePurchaseHistory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ds = New DataSet()
        GDS = New DataSet()
        GlobalMaintenancePartNumber = ""
    End Sub

    Private Sub ItemMaintenancePurchaseHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowData()
        LoadTotalPurchases()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber ORDER BY PONumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalMaintenancePartNumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceivingLineQuery")
        dgvPurchaseHistory.DataSource = ds.Tables("ReceivingLineQuery")
        con.Close()
    End Sub

    Public Sub LoadTotalPurchases()
        'Get Rack Totals
        Dim TotalPurchases As Double = 0
        Dim strTotalPurchases As String = ""

        Dim TotalPurchasesStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceivingLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim TotalPurchasesCommand As New SqlCommand(TotalPurchasesStatement, con)
        TotalPurchasesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalMaintenancePartNumber
        TotalPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalPurchases = CDbl(TotalPurchasesCommand.ExecuteScalar)
            TotalPurchases = Math.Round(TotalPurchases, 2)
        Catch ex As System.Exception
            TotalPurchases = 0
        End Try
        con.Close()

        strTotalPurchases = CStr(TotalPurchases)

        lblTotalPartDollars.Text = strTotalPurchases + " total Purchases for this part."
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ds = New DataSet()
        GDS = New DataSet()
        GlobalMaintenancePartNumber = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ds = New DataSet()
        GDS = New DataSet()
        GlobalMaintenancePartNumber = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvPurchaseHistory_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPurchaseHistory.CellDoubleClick
        If Me.dgvPurchaseHistory.RowCount = 0 Then
            'Skip
        Else
            Dim RowPONumber As Integer

            Dim RowIndex As Integer = Me.dgvPurchaseHistory.CurrentCell.RowIndex

            RowPONumber = Me.dgvPurchaseHistory.Rows(RowIndex).Cells("PONumberColumn").Value

            GlobalPONumber = RowPONumber

            'Choose the correct Print Form (REMOTE or LOCAL)

            'Get Login Type
            Dim GetLoginType As String = ""

            Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
            GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetLoginType = ""
            End Try
            con.Close()

            If GetLoginType = "REMOTE" Then
                Using NewPrintPurchaseOrderRemote As New PrintPurchaseOrderRemote
                    Dim Result = NewPrintPurchaseOrderRemote.ShowDialog()
                End Using
            Else
                Using NewPrintPurchaseOrder As New PrintPurchaseOrder
                    Dim Result = NewPrintPurchaseOrder.ShowDialog()
                End Using
            End If
        End If
    End Sub
End Class