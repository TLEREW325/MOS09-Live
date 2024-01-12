Imports System.Data.SqlClient
Public Class PrintQCNonconReport
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal PNCNumber As String)
        InitializeComponent()

        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT QCTransactionNumber, QCDate, FOXNumber, ParTNumber, PartDescription, QuantityOnHold, CorrectiveAction, NonConformanceReason, ReworkInstructions, Comment FROM QCHoldAdjustment WHERE QCTransactionNumber = @QCTransactionNumber", con)
        cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.VarChar).Value = PNCNumber
        Dim myAdapter As New SqlDataAdapter(cmd)
        Dim ds As New DataSet

        cmd1 = New SqlCommand("SELECT QCTransactionNumber, LotNumber FROM QCHoldAdjustmentLotNumber WHERE QCTransactionNumber = @QCTransactionNumber", con)
        cmd1.Parameters.Add("@QCTransactionNumber", SqlDbType.VarChar).Value = PNCNumber
        Dim myAdapter1 As New SqlDataAdapter(cmd1)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "QCHoldAdjustment")
        myAdapter1.Fill(ds, "QCHoldAdjustmentLotNumber")
        con.Close()


        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CRXQCNonConReport()
        MyReport.SetDataSource(ds)
        CRReportViewer.ReportSource = MyReport
    End Sub
    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalQCTransactionNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub
End Class