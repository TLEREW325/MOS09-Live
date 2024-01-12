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
Public Class PrintPurchaseOrderRemote
    Inherits System.Windows.Forms.Form

    Dim VendorID As String = ""
    Dim VendorEmail As String = ""

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
        If GlobalDivisionCode = "CHT" And GlobalCompleteShipment = "COMPLETE SHIPMENT" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber

            cmd2 = New SqlCommand("SELECT * FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
            cmd2.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber

            cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TWD"

            cmd4 = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            cmd5 = New SqlCommand("SELECT PurchaseOrderHeaderKey, PurchaseOrderLineNumber, PartNumber, POQuantityReceived, POQuantityOpen FROM PurchaseOrderQuantityStatus WHERE DivisionID = @DivisionID AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
            cmd5.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            cmd7 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "PurchaseOrderHeaderTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "PurchaseOrderLineTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "DivisionTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "Vendor")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "PurchaseOrderQuantityStatus")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "AdditionalShipTo")

            myAdapter7.SelectCommand = cmd7
            myAdapter7.Fill(ds, "CustomerList")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPurchaseOrder1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            con.Close()
            Me.Close()

            GlobalPONumber = 0
            GlobalCompleteShipment = ""
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber

            cmd2 = New SqlCommand("SELECT * FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
            cmd2.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber

            cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd5 = New SqlCommand("SELECT PurchaseOrderHeaderKey, PurchaseOrderLineNumber, PartNumber, POQuantityReceived, POQuantityOpen FROM PurchaseOrderQuantityStatus WHERE DivisionID = @DivisionID AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
            cmd5.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd7 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "PurchaseOrderHeaderTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "PurchaseOrderLineTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "DivisionTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "Vendor")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "PurchaseOrderQuantityStatus")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "AdditionalShipTo")

            myAdapter7.SelectCommand = cmd7
            myAdapter7.Fill(ds, "CustomerList")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPurchaseOrder1
            MyReport.SetDataSource(ds)
            CRPOViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem3.Click
        GlobalPONumber = 0
        GlobalCompleteShipment = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EmailPurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailPurchaseOrderToolStripMenuItem.Click
        'Create new Filename for PO
        FileDate = Now()
        monthofyear = FileDate.Month
        dayofyear = FileDate.DayOfYear
        yearofyear = FileDate.Year
        minuteofyear = FileDate.Minute
        strMonth = CStr(monthofyear)
        strDay = CStr(dayofyear)
        strYear = CStr(yearofyear)
        strMinute = CStr(minuteofyear)
        strCompany = GlobalDivisionCode

        ConfirmName = strCompany + strMonth + strDay + strYear + strMinute

        Try
            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPOs\TWPO" & ConfirmName & ".pdf")
        Catch ex As Exception
            'Create new Filename for PO
            FileDate = Now()
            monthofyear = FileDate.Month
            dayofyear = FileDate.DayOfYear
            yearofyear = FileDate.Year
            minuteofyear = FileDate.Minute + 1
            strMonth = CStr(monthofyear)
            strDay = CStr(dayofyear)
            strYear = CStr(yearofyear)
            strMinute = CStr(minuteofyear)
            strCompany = GlobalDivisionCode

            ConfirmName = strCompany + strMonth + strDay + strYear + strMinute

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPOs\TWPO" & ConfirmName & ".pdf")
        End Try

        TFPMailFilename = ConfirmName + ".pdf"
        TFPMailFilePath = "\\TFP-FS\TransferData\TruweldPOs\TWPO" & ConfirmName & ".pdf"
        TFPMailTransactionType = "Print Purchase Order"
        TFPMailTransactionNumber = GlobalPONumber

        Using NewEmailPage As New EmailPage
            Dim Result = NewEmailPage.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub
End Class