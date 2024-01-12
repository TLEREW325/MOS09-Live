Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintTFPDiscrepancyReport
    Inherits System.Windows.Forms.Form

    Dim TextFilter As String = ""
    Dim ZeroFilter As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim ds, ds1, ds2 As DataSet

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdItemClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemClass.Click
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + txtTextFilter.Text + "%' OR ShortDescription LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If chkZero.Checked = True Then
            ZeroFilter = " AND QuantityOnHand - TotalRackPieces <> 0"
        Else
            ZeroFilter = ""
        End If

        'Command to load Dataset into Viewer
        cmd = New SqlCommand("SELECT * FROM RackingWithQOH WHERE DivisionID = @DivisionID AND (QuantityOnHand <> 0 OR TotalRackPieces <> 0)" + TextFilter + ZeroFilter + " ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RackingWithQOH")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTFPInventoryReport1
        MyReport.SetDataSource(ds)
        CRInventoryViewer.ReportSource = MyReport
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        CRInventoryViewer.ReportSource = Nothing
    End Sub

    Private Sub PrintTFPDiscrepancyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CRInventoryViewer.ReportSource = Nothing
    End Sub

    Private Sub CRInventoryViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRInventoryViewer.Load
        CRInventoryViewer.ReportSource = Nothing
    End Sub
End Class