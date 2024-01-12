Imports System.Data.SqlClient
Public Class PrintElectronicSchedulingBoard
    Dim ds As New DataSet
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim adapt As New SqlDataAdapter
    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Public Sub setData(ByVal machine As String)
        cmd = New SqlCommand("SELECT * FROM ADMInventoryTotal LEFT OUTER JOIN FOXTable ON PartNumber=ItemID inner join (SELECT * FROM FOXSched  WHERE ProcessID = @Machine) as FOXSched on FOXSched.FOXNumber=FOXTable.FOXNumber", con)
        cmd.Parameters.Add("@Machine", SqlDbType.VarChar).Value = machine
        adapt.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.Fill(ds, "ADMInventoryTotal")
        con.Close()
        cmd = New SqlCommand("SELECT * FROM FOXTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.Fill(ds, "FOXTable")
        con.Close()
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = crxElectronicSchedulingBoard1
        MyReport.SetDataSource(ds)
        CRElectronicScheduling.ReportSource = MyReport
    End Sub
End Class