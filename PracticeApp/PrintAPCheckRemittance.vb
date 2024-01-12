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
Public Class PrintAPCheckRemittance
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application

    'Variables for Date/Filename Creation
    Dim ConfirmName, strBatchNumber, strCompany As String

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub CRRemmittanceViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRRemmittanceViewer.Load
        If GlobalNoAutoPrintCheckRemittance = "NO AUTOPRINT" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * from APCheckQuery where CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = GlobalAPCheckNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * from DivisionTable where DivisionKey = @DivisionKey", con)
            cmd1.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "APCheckQuery")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "DivisionTable")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPTRemittance1
            MyReport.SetDataSource(ds)
            CRRemmittanceViewer.ReportSource = MyReport
            con.Close()
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * from APCheckQuery where CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = GlobalAPCheckNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * from DivisionTable where DivisionKey = @DivisionKey", con)
            cmd1.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "APCheckQuery")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "DivisionTable")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXPTRemittance1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            con.Close()

            Me.Close()
        End If
    End Sub

    Private Sub PrintAPCheckRemittance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalNoAutoPrintCheckRemittance = ""
    End Sub

    Private Sub EmailRemittanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailRemittanceToolStripMenuItem.Click
        'Create new Filename for Pack List
        strBatchNumber = CStr(GlobalAPBatchNumber)
        strCompany = GlobalDivisionCode

        ConfirmName = strCompany + strBatchNumber

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCustomerStatements\AP-" & ConfirmName & ".pdf")

        'creating outlook mailitem
        Dim mail As MailItem
        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'Dim recipient As Recipient
        mail.To = GlobalAPRemittanceEmail

        'adding subject information to the mail message
        mail.Subject = "Truweld / Trufit AP Remittance"

        'adding body message information to the mail message
        mail.Body = "This is a Check Remittance from Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldCustomerStatements\AP-" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()

        Me.Close()
    End Sub
End Class