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
Public Class PrintTWCert
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim CertName, strShipmentNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8 As SqlCommand

    Private Sub PrintTWCert_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalCertShipmentNumber = 0
        GlobalCertLotNumber = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRCertViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCertViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber AND LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalCertShipmentNumber
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = GlobalCertLotNumber

        cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

        cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TruweldCertData")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "CustomerList")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "PullTestLineTable")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXTWCert011
        MyReport.SetDataSource(ds)
        'CRCertViewer.ReportSource = MyReport
        con.Close()

        CreateCertFile()

        GlobalCertCustomer = ""
        GlobalCertHeatNumber = ""
        GlobalCertLotNumber = ""
        GlobalCertShipmentNumber = 0
        GlobalCertPartNumber = ""

        'Me.Dispose()
        Me.Close()
    End Sub

    Public Sub CreateCertFile()
        strShipmentNumber = CStr(GlobalCertShipmentNumber)
        CertName = strShipmentNumber + " " + GlobalCertHeatNumber + " " + GlobalCertPartNumber

        'Create Directory for Customer if one does not exit
        Dim path As String = "\\TFP-FS\TransferData\TruweldCerts\" + GlobalCertCustomer

        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCerts\" + GlobalCertCustomer + "\" & CertName & ".pdf")
    End Sub
End Class