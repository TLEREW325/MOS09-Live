
Public Class PrintInventoryCostingFiltered
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables

    Dim dt As Data.DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Public Sub New()
        InitializeComponent()

        Dim MyReport = New CRXSteelInventoryCosting

        CRInventoryViewer.ReportSource = MyReport

    End Sub
    Public Sub New(ByVal dt As Data.DataTable)
        InitializeComponent()

        Dim MyReport = New CRXSteelInventoryCosting
        MyReport.SetDataSource(dt)
        CRInventoryViewer.ReportSource = MyReport

    End Sub
    'Private Sub CRInventoryViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRInventoryViewer.Load
    '    'Loads data into dataset for viewing
    '    ds = GDS
    '    'Sets up viewer to display data from the loaded dataset
    '    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '    If ds.Tables.Contains("SteelCostingTable") Then
    '        MyReport = crxSteelInventoryCosting1
    '    Else
    '        MyReport = CRXInventoryCosting1
    '    End If

    '    MyReport.SetDataSource(ds)
    '    CRInventoryViewer.ReportSource = MyReport
    '    con.Close()
    'End Sub
End Class