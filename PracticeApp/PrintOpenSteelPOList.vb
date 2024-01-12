Imports System.Data.SqlClient

Public Class PrintOpenSteelPOList
    Public Sub New()
        InitializeComponent()
        LoadCrystal(New DataSet())
    End Sub
    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        LoadCrystal(ds)
    End Sub

    Private Sub LoadCrystal(ByVal ds As DataSet)
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = crxOpenSteelPOList1
        MyReport.SetDataSource(ds)
        CROpenSteelPO.ReportSource = MyReport
    End Sub
End Class