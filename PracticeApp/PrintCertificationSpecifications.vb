Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class PrintCertificationSpecifications

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT CertificationCode, CertificationType, Description, MaterialSpec FROM CertificationType ORDER BY (CASE WHEN ISNUMERIC( CertificationCode) <> 1 then 9999 else CAST(CertificationCode as int) END)", con)

        Dim ds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "CertificationType")
        con.Close()

        Dim rpt As New CRXCertificationSpecifications()
        rpt.SetDataSource(ds.Tables("CertificationType"))
        CRVCertificaitonSpecifications.ReportSource = rpt
    End Sub
End Class