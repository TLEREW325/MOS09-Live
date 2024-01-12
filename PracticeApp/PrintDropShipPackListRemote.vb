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
Public Class PrintDropShipPackListRemote
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay As String
    Dim strPONumber, POName As String
    Dim strCompany As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRDropShipPOViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CRDropShipPOViewer.Load
        'Load PO only if the email PO Link is selected
    End Sub

    Private Sub CRDropShipViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRDropShipViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SalesOrderKey = @SalesOrderKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

        cmd1 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey", con)
        cmd1.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

        cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo", con)

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "SalesOrderLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "DivisionTable")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "AdditionalShipTo")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXDropShipPackingSlip1
        MyReport.SetDataSource(ds)
        CRDropShipViewer.ReportSource = MyReport
        con.Close()

        'Create new Filename for Packing List
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

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf")
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

        ConfirmName = strCompany + strMonth + strDay + strYear + strMinute

        Try
            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf")
        Catch ex As Exception
            'Create new Filename for Pack List
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
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf")
        End Try

        TFPMailFilename = ConfirmName + ".pdf"
        TFPMailFilePath = "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf"
        TFPMailTransactionType = "Print Drop Ship Packing List"
        TFPMailTransactionNumber = GlobalShipmentNumber

        Using NewEmailPage As New EmailPage
            Dim Result = NewEmailPage.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EmailPackingListAndPOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailPackingListAndPOToolStripMenuItem.Click
        If GlobalDropShipPONumber <> 0 Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey= @PurchaseOrderHeaderKey", con)
            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalDropShipPONumber

            cmd2 = New SqlCommand("SELECT * FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
            cmd2.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalDropShipPONumber

            cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd5 = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus", con)

            cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd7 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds2, "PurchaseOrderHeaderTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds2, "PurchaseOrderLineTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds2, "DivisionTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds2, "Vendor")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds2, "PurchaseOrderQuantityStatus")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds2, "AdditionalShipTo")

            myAdapter7.SelectCommand = cmd7
            myAdapter7.Fill(ds2, "CustomerList")

            'Sets up viewer to display data from the loaded dataset
            MyReport2 = CRXPurchaseOrder1
            MyReport2.SetDataSource(ds2)
            'CRDropShipPOViewer.ReportSource = MyReport2
            con.Close()

            'Create PO File name
            strPONumber = CStr(GlobalDropShipPONumber)
            POName = GlobalDivisionCode + strPONumber

            'Export Document to Folder
            MyReport2.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" + POName + ".pdf")

            'Create new Filename for Sales Confirmation
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
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf")
            Catch ex As Exception
                'Create new Filename for Sales Confirmation
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
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf")
            End Try

            TFPMailFilename = ConfirmName + ".pdf"
            TFPMailFilePath = "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf"

            TFPMailFilename2 = POName + ".pdf"
            TFPMailFilePath2 = "\\TFP-FS\TransferData\TruweldPackList\" & POName & ".pdf"
            TFPMailTransactionType = "Print Drop Ship PO"
            TFPMailTransactionNumber = GlobalDropShipPONumber

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using

            Me.Dispose()
            Me.Close()
        End If
    End Sub
End Class