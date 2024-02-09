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
Imports Microsoft.Office.Interop.Outlook
Public Class PrintPackingList
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Microsoft.Office.Interop.Outlook.Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim EmailPackingSlip As String = ""
    Dim strShipmentNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalShipmentNumber = 0
        GlobalCertCustomer = ""
        GlobalCompleteShipment = ""
        GlobalShipmentBatchNumber = 0
        GlobalShipmentPrintType = ""
        GlobalAutoPrintPackingList = ""

        'Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRPackingListViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPackingListViewer.Load
        If GlobalShipmentBatchNumber > 0 And GlobalShipmentPrintType = "PRINT MULTIPLE" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalShipmentBatchNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM ShipmentLineQuery2", con)

            cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd5 = New SqlCommand("SELECT * FROM CountryCodes", con)

            cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd7 = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID", con)
            cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd8 = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID", con)
            cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd9 = New SqlCommand("SELECT * FROM ShipmentLineHeatNumbers", con)

            cmd10 = New SqlCommand("SELECT * FROM ShipmentLineSerialNumbers", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ShipmentLineQuery2")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "CustomerList")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "DivisionTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "FoxTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "CountryCodes")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "AdditionalShipTo")

            myAdapter7.SelectCommand = cmd7
            myAdapter7.Fill(ds, "AssemblyLineTable")

            myAdapter8.SelectCommand = cmd8
            myAdapter8.Fill(ds, "AssemblyHeaderTable")

            myAdapter9.SelectCommand = cmd9
            myAdapter9.Fill(ds, "ShipmentLineHeatNumbers")

            myAdapter10.SelectCommand = cmd10
            myAdapter10.Fill(ds, "ShipmentLineSerialNumbers")
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE ShipmentNumber = @ShipmentNumber ORDER BY ShipmentNumber, ShipmentLineNumber", con)
            cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

            cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd5 = New SqlCommand("SELECT * FROM CountryCodes", con)

            cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd7 = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID", con)
            cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd8 = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID", con)
            cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd9 = New SqlCommand("SELECT * FROM ShipmentLineHeatNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
            cmd9.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

            cmd10 = New SqlCommand("SELECT * FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
            cmd10.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ShipmentLineQuery2")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "CustomerList")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "DivisionTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "FoxTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "CountryCodes")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "AdditionalShipTo")

            myAdapter7.SelectCommand = cmd7
            myAdapter7.Fill(ds, "AssemblyLineTable")

            myAdapter8.SelectCommand = cmd8
            myAdapter8.Fill(ds, "AssemblyHeaderTable")

            myAdapter9.SelectCommand = cmd9
            myAdapter9.Fill(ds, "ShipmentLineHeatNumbers")

            myAdapter10.SelectCommand = cmd10
            myAdapter10.Fill(ds, "ShipmentLineSerialNumbers")
        End If

        ''Save pdf in folder
        strShipmentNumber = CStr(GlobalShipmentNumber)
        EmailPackingSlip = GlobalDivisionCode + strShipmentNumber + ".pdf"

        If GlobalDivisionCode = "TFP" And GlobalCompleteShipment = "COMPLETE SHIPMENT" Then
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPackingSlipTFP1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(2, True, 1, 999)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)
            con.Close()
            Me.Close()

            GlobalCompleteShipment = ""
        ElseIf (GlobalDivisionCode = "TWD" Or GlobalDivisionCode = "TWE") And GlobalCompleteShipment = "COMPLETE SHIPMENT" Then
            MyReport = CRXPackingSlip1
            MyReport.SetDataSource(ds)

            If GlobalDivisionCode = "TWD" Then
                MyReport.PrintToPrinter(2, True, 1, 999)
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)
            Else
                MyReport.PrintToPrinter(1, True, 1, 999)
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)
            End If
            con.Close()
            Me.Close()

            GlobalCompleteShipment = ""
        ElseIf (GlobalDivisionCode = "TWD" Or GlobalDivisionCode = "TWE") And GlobalCompleteShipment <> "COMPLETE SHIPMENT" Then
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPackingSlip1
            MyReport.SetDataSource(ds)
            CRPackingListViewer.ReportSource = MyReport
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)
            con.Close()
        ElseIf GlobalDivisionCode = "CHT" And GlobalCompleteShipment = "COMPLETE SHIPMENT" And GlobalAutoPrintPackingList = "YES" Then
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPackingSlip1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(2, True, 1, 999)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)
            con.Close()
            Me.Close()

            GlobalCompleteShipment = ""
            GlobalAutoPrintPackingList = ""
        ElseIf GlobalDivisionCode = "CHT" And GlobalCompleteShipment = "COMPLETE SHIPMENT" And (GlobalAutoPrintPackingList = "NO" Or GlobalAutoPrintPackingList = "") Then
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPackingSlip1
            MyReport.SetDataSource(ds)
            CRPackingListViewer.ReportSource = MyReport
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)
            con.Close()

            GlobalCompleteShipment = ""
            GlobalAutoPrintPackingList = ""
        ElseIf GlobalDivisionCode = "TFP" And GlobalCompleteShipment <> "COMPLETE SHIPMENT" Then
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPackingSlip1
            MyReport.SetDataSource(ds)
            CRPackingListViewer.ReportSource = MyReport
            'MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)
            con.Close()
        Else
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPackingSlip1
            MyReport.SetDataSource(ds)
            CRPackingListViewer.ReportSource = MyReport
            'MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)
            con.Close()
        End If
    End Sub

    Private Sub EmailPackingListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailPackingListToolStripMenuItem.Click
        'Create new Filename for Pack List
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
        strShipmentNumber = CStr(GlobalShipmentNumber)

        ConfirmName = strCompany + strShipmentNumber

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf")

        'creating outlook mailitem
        Dim mail As MailItem
        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'adding to into the address field
        mail.To = EmailCustomerEmailAddress

        'adding subject information to the mail message
        mail.Subject = "Truweld / Trufit Packing List"

        'adding body message information to the mail message
        mail.Body = "This is a Packing List for a Shipment from Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub

    Private Sub PrintPackingList_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        GlobalShipmentNumber = 0
        GlobalCertCustomer = ""
        GlobalCompleteShipment = ""
        GlobalShipmentBatchNumber = 0
        GlobalShipmentPrintType = ""
        GlobalAutoPrintPackingList = ""
    End Sub

    Private Sub PrintPackingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (GlobalDivisionCode = "TWD" Or GlobalDivisionCode = "TFP") And GlobalCompleteShipment = "COMPLETE SHIPMENT" Then
            Me.Visible = False
        Else
            Me.Visible = True
        End If
    End Sub
End Class