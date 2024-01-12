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
Public Class PrintBOLRemote
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CRBOLViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRBOLViewer.Load
        If GlobalShipmentBatchNumber > 0 And GlobalShipmentPrintType = "PRINT MULTIPLE" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalShipmentBatchNumber

            cmd1 = New SqlCommand("SELECT * FROM ShipmentLineTable", con)

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM CustomerContacts WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ShipmentLineTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "CustomerList")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "CustomerContacts")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "AdditionalShipTo")
        ElseIf GlobalShipmentPrintType = "PRINT FEDEX" Then
            'Loads data into dataset for viewing 
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipVia LIKE 'FEDEX%' AND ShipDate = @ShipDate AND ShipmentStatus <> @ShipmentStatus", con)
            cmd.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = GlobalShipmentDate
            cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

            cmd1 = New SqlCommand("SELECT * FROM ShipmentLineTable", con)

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM CustomerContacts WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ShipmentLineTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "CustomerList")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "CustomerContacts")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "AdditionalShipTo")
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

            cmd1 = New SqlCommand("SELECT * FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber", con)
            cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM CustomerContacts WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ShipmentLineTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "CustomerList")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "CustomerContacts")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "AdditionalShipTo")
        End If

        If GlobalDivisionCode = "TWD" And GlobalCompleteShipment = "COMPLETE SHIPMENT" Then
            MyReport = CRXBOL1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(2, True, 1, 999)
            con.Close()
            Me.Close()

            GlobalCompleteShipment = ""
        ElseIf GlobalDivisionCode = "TFP" And GlobalCompleteShipment = "COMPLETE SHIPMENT" Then
            MyReport = CRXBOL1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(2, True, 1, 999)
            con.Close()
            Me.Close()

            GlobalCompleteShipment = ""
        Else
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXBOL1
            MyReport.SetDataSource(ds)
            CRBOLViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalShipmentNumber = 0
        GlobalShipmentDate = ""
        GlobalCertCustomer = ""
        GlobalShipmentPrintType = ""
        GlobalShipmentBatchNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintBOL_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalShipmentNumber = 0
        GlobalShipmentDate = ""
        GlobalCertCustomer = ""
        GlobalShipmentPrintType = ""
        GlobalShipmentBatchNumber = 0
    End Sub

    Private Sub EmailBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailBOLToolStripMenuItem.Click
        'Create new Filename for BOL
        FileDate = Today()
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

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\TWPL" & ConfirmName & ".pdf")

        TFPMailFilename = ConfirmName + ".pdf"
        TFPMailFilename2 = ""
        TFPMailFilename3 = ""
        TFPMailFilePath = "\\TFP-FS\TransferData\TruweldPackList\TWPL" & ConfirmName & ".pdf"
        TFPMailFilePath2 = ""
        TFPMailFilePath3 = ""
        TFPMailCustomer = ""
        TFPMailTransactionType = "Print BOL"
        TFPMailTransactionNumber = GlobalShipmentNumber

        Using NewEmailPage As New EmailPage
            Dim Result = NewEmailPage.ShowDialog()
        End Using
    End Sub
End Class