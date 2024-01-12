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
Public Class PrintVendorBOLRemote
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

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRBOLViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRBOLViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM VendorBOLTable WHERE VendorBOLNumber = @VendorBOLNumber", con)
        cmd.Parameters.Add("@VendorBOLNumber", SqlDbType.VarChar).Value = GlobalVendorBOLNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "VendorBOLTable")

        MyReport = CRXVendorBOL1
        MyReport.SetDataSource(ds)
        CRBOLViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub EmailBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailBOLToolStripMenuItem.Click
        'Create new Filename for Sales Confirmation
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