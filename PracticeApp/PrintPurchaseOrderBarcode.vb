Imports System
Imports System.Math
Imports System.IO
Imports System.Data
'Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook

Public Class PrintPurchaseOrderBarcode
    Inherits System.Windows.Forms.Form

   

    

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CRPOViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPOViewer.Load
        
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber

        cmd2 = New SqlCommand("SELECT * FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
        cmd2.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber

        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM AdditionalShipTo", con)

        cmd5 = New SqlCommand("SELECT * FROM CustomerList", con)

        cmd6 = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus", con)

        cmd7 = New SqlCommand("SELECT * FROM Vendor", con)

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "PurchaseOrderLineTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "DivisionTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "AdditionalShipTo")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "CustomerList")

        myAdapter6.SelectCommand = cmd6
        myAdapter6.Fill(ds, "PurchaseOrderQuantityStatus")

        myAdapter7.SelectCommand = cmd7
        myAdapter7.Fill(ds, "Vendor")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPurchaseOrderBarcode1
        MyReport.SetDataSource(ds)
        CRPOViewer.ReportSource = MyReport
        con.Close()

    End Sub

    Private Sub ExitToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem3.Click
        GlobalPONumber = 0
        GlobalCompleteShipment = ""
        Me.Dispose()
        Me.Close()
    End Sub

   
End Class