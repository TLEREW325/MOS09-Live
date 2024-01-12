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
Public Class PrintInvoiceCerts
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim CertName, strMinute, strMonth, strYear, strDay, strCompany As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCertViewer.Load
        'Check to make sure at least one cert will print otherwise do not open Print Form
        Dim CheckForCerts As Integer = 0

        'Get Pull Test Number for selected Lot Number Data
        Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
        CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber
        CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
        If reader2.HasRows Then
            reader2.Read()
            If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                CheckForCerts = 0
            Else
                CheckForCerts = reader2.Item("CountShipmentNumber")
            End If
        Else
            CheckForCerts = 0
        End If
        reader2.Close()
        con.Close()

        If CheckForCerts = 0 Then
            MsgBox("There are no certs to print. If you entered a Lot #, check the error log.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

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
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXTWCert011
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            con.Close()
        End If

        'After printing, close the form
        Me.Close()
    End Sub

    Private Sub PrintInvoiceCerts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class