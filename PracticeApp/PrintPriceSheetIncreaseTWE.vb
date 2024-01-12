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
Public Class PrintPriceSheetIncreaseTWE
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

    Private Sub ShowDataByFiltersDistributer()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ItemPriceSheetQuery WHERE DivisionID = @DivisionID AND B100To199 > 0 ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPriceSheetIncreaseTWEDist1
        MyReport.SetDataSource(ds)
        CRPriceSheetIncreaseViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub ShowDataByFiltersEndUser()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ItemPriceSheetQuery WHERE DivisionID = @DivisionID AND B200To299 > 0 ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPriceSheetIncreaseTWEEnd1
        MyReport.SetDataSource(ds)
        CRPriceSheetIncreaseViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub ShowDataByFiltersSWP()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ItemPriceSheetQuery WHERE DivisionID = @DivisionID AND B300To399 > 0 ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPriceSheetIncreaseTWESwp1
        MyReport.SetDataSource(ds)
        CRPriceSheetIncreaseViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub ShowDataByFiltersRedDArc()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ItemPriceSheetQuery WHERE DivisionID = @DivisionID AND B400To499 > 0 ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPriceSheetIncreaseTWERedD1
        MyReport.SetDataSource(ds)
        CRPriceSheetIncreaseViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub ShowDataByFiltersHanlon()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ItemPriceSheetQuery WHERE DivisionID = @DivisionID AND B500To749 > 0 ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPriceSheetIncreaseTWEHanlon1
        MyReport.SetDataSource(ds)
        CRPriceSheetIncreaseViewer1.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub chkMildSteel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDistributer.CheckedChanged
        If chkDistributer.Checked = True Then
            chkSWP.Checked = False
            chkEndUser.Checked = False
            chkRedDArce.Checked = False
            chkHanlon.Checked = False
        End If
    End Sub

    Private Sub chkStainlessSteel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEndUser.CheckedChanged
        If chkEndUser.Checked = True Then
            chkSWP.Checked = False
            chkDistributer.Checked = False
            chkRedDArce.Checked = False
            chkHanlon.Checked = False
        End If
    End Sub

    Private Sub chkPSR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSWP.CheckedChanged
        If chkSWP.Checked = True Then
            chkEndUser.Checked = False
            chkDistributer.Checked = False
            chkRedDArce.Checked = False
            chkHanlon.Checked = False
        End If
    End Sub

    Private Sub chkSWR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedDArce.CheckedChanged
        If chkRedDArce.Checked = True Then
            chkEndUser.Checked = False
            chkDistributer.Checked = False
            chkSWP.Checked = False
            chkHanlon.Checked = False
        End If
    End Sub

    Private Sub cboFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilter.Click

        If chkDistributer.Checked = True Then
            ShowDataByFiltersDistributer()
        ElseIf chkEndUser.Checked = True Then
            ShowDataByFiltersEndUser()
        ElseIf chkSWP.Checked = True Then
            ShowDataByFiltersSWP()
        ElseIf chkRedDArce.Checked = True Then
            ShowDataByFiltersRedDArc()
        ElseIf chkHanlon.Checked = True Then
            ShowDataByFiltersHanlon()
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
        mail.Body = "This is a Price Sheet from Tru-Weld Equipment."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\SalesConfirmations\PriceSheet" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()
    End Sub

    Private Sub chkHanlon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHanlon.CheckedChanged
        If chkHanlon.Checked = True Then
            chkEndUser.Checked = False
            chkDistributer.Checked = False
            chkSWP.Checked = False
            chkRedDArce.Checked = False
        End If
    End Sub
End Class