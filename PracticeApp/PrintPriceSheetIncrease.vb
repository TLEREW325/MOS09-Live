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
Public Class PrintPriceSheetIncrease
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub CRPriceSheetIncreaseViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPriceSheetIncreaseViewer1.Load
        'Loads data into dataset for viewing
        CRPriceSheetIncreaseViewer1.ReportSource = Nothing
    End Sub

    Private Sub ShowDataByFiltersMildSteel()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ItemPriceSheetQuery WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPriceSheetIncrease1
        MyReport.SetDataSource(ds)
        CRPriceSheetIncreaseViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub ShowDataByFiltersStainlessSteel()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ItemPriceSheetQuery WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPriceSheetIncreaseSS1
        MyReport.SetDataSource(ds)
        CRPriceSheetIncreaseViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub ShowDataByFiltersPSR()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ItemPriceSheetQuery WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPriceSheetIncreasePSR1
        MyReport.SetDataSource(ds)
        CRPriceSheetIncreaseViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub ShowDataByFiltersSWR()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ItemPriceSheetQuery WHERE DivisionID = @DivisionID ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPriceSheetIncreaseSWR1
        MyReport.SetDataSource(ds)
        CRPriceSheetIncreaseViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub chkMildSteel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMildSteel.CheckedChanged
        If chkMildSteel.Checked = True Then
            chkPSR.Checked = False
            chkStainlessSteel.Checked = False
            chkSWR.Checked = False
        End If
    End Sub

    Private Sub chkStainlessSteel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStainlessSteel.CheckedChanged
        If chkStainlessSteel.Checked = True Then
            chkPSR.Checked = False
            chkMildSteel.Checked = False
            chkSWR.Checked = False
        End If
    End Sub

    Private Sub chkPSR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPSR.CheckedChanged
        If chkPSR.Checked = True Then
            chkStainlessSteel.Checked = False
            chkMildSteel.Checked = False
            chkSWR.Checked = False
        End If
    End Sub

    Private Sub chkSWR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSWR.CheckedChanged
        If chkSWR.Checked = True Then
            chkStainlessSteel.Checked = False
            chkMildSteel.Checked = False
            chkPSR.Checked = False
        End If
    End Sub

    Private Sub cboFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilter.Click
        If chkMildSteel.Checked = True Then
            ShowDataByFiltersMildSteel()
        ElseIf chkStainlessSteel.Checked = True Then
            ShowDataByFiltersStainlessSteel()
        ElseIf chkPSR.Checked = True Then
            ShowDataByFiltersPSR()
        ElseIf chkSWR.Checked = True Then
            ShowDataByFiltersSWR()
        Else
            CRPriceSheetIncreaseViewer1.ReportSource = Nothing
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EmailPriceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailPriceSheetToolStripMenuItem.Click
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
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\SalesConfirmations\PriceSheet" & ConfirmName & ".pdf")

        'creating outlook mailitem
        Dim mail As MailItem
        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'Dim recipient As Recipient
        'Adding recipeints to the mail message
        'recipient = mail.Recipients.Add("name@hotmail.com")
        'Do Check Name here
        'recipient.Resolve()

        'adding subject information to the mail message
        mail.Subject = "Price Sheet"

        'adding body message information to the mail message
        mail.Body = "This is a Price Sheet from Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\SalesConfirmations\PriceSheet" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()
    End Sub

    Private Sub PrintPriceSheetIncrease_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class