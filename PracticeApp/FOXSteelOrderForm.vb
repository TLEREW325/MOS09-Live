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
Public Class FOXSteelOrderForm
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim BodyLine1, BodyLine2, BodyLine3, BodyLine4, BodyLine5, BodyLine6, BodyLine7, BodyLine8, BodyLine9 As String

    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12, myAdapter13, myAdapter14, myAdapter15, myAdapter16, myAdapter17, myAdapter18 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12, ds13, ds14, ds15, ds16, ds17, ds18, ds19 As DataSet

    Private Sub FOXSteelOrderForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Clear Global Variables
        GlobalSteelOrderCarbon = ""
        GlobalSteelOrderFOXNumber = 0
        GlobalSteelOrderPartNumber = ""
        GlobalSteelOrderProcessAgent = ""
        GlobalSteelOrderRMID = ""
        GlobalSteelOrderSteelDescription = ""
        GlobalSteelOrderSteelRequired = 0
        GlobalSteelOrderSteelSize = ""
        GlobalSteelOrderPartDescription = ""
    End Sub

    Private Sub FOXSteelOrderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load Vendor Combo Box
        LoadVendor()

        'GlobalDivisionCode
        txtSteelCarbon.Text = GlobalSteelOrderCarbon
        txtFOXNumber.Text = GlobalSteelOrderFOXNumber
        txtPartNumber.Text = GlobalSteelOrderPartNumber
        'GlobalSteelOrderProcessAgent
        txtSteelSize.Text = GlobalSteelOrderSteelSize
        txtSteelDescription.Text = GlobalSteelOrderSteelDescription
        txtSteelRequired.Text = GlobalSteelOrderSteelRequired
        txtRMID.Text = GlobalSteelOrderRMID
        txtPartDescription.Text = GlobalSteelOrderPartDescription
        cboUnits.Text = "Lbs."
        cboVendorID.Focus()
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass ORDER BY VendorCode", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "Vendor")
        cboVendorID.DataSource = ds.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Clear Global Variables
        GlobalSteelOrderCarbon = ""
        GlobalSteelOrderFOXNumber = 0
        GlobalSteelOrderPartNumber = ""
        GlobalSteelOrderProcessAgent = ""
        GlobalSteelOrderRMID = ""
        GlobalSteelOrderSteelDescription = ""
        GlobalSteelOrderSteelRequired = 0
        GlobalSteelOrderSteelSize = ""
        GlobalSteelOrderPartDescription = ""

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcess.Click
        'Convert Some varibales to string
        Dim strFOXNumber As String = ""
        strFOXNumber = CStr(GlobalSteelOrderFOXNumber)
        Dim strOrderQuantity As String = ""
        strOrderQuantity = txtOrderQuantity.Text
        Dim TodaysDate As Date
        Dim strTodaysDate As String = ""
        TodaysDate = Today.Date
        strTodaysDate = CStr(TodaysDate)
        Dim CalendarFileName As String = ""

        'Validate fields and write to table
        cmd = New SqlCommand("INSERT INTO SteelSpecialOrders (RMID, Carbon, SteelSize, OrderQuantity, Comment, DivisionID, FOXNumber, PartNumber, SteelDescription, OrderDate, EstDeliveryDate,ProcessAgent, SteelVendor, PurchaseAgent, OnOrder, Status) Values (@RMID, @Carbon, @SteelSize, @OrderQuantity, @Comment, @DivisionID, @FOXNumber, @PartNumber, @SteelDescription, @OrderDate, @EstDeliveryDate, @ProcessAgent, @SteelVendor, @PurchaseAgent, @OnOrder, @Status)", con)

        With cmd.Parameters
            .Add("@RMID", SqlDbType.VarChar).Value = GlobalSteelOrderRMID
            .Add("@Carbon", SqlDbType.VarChar).Value = GlobalSteelOrderCarbon
            .Add("@SteelSize", SqlDbType.VarChar).Value = GlobalSteelOrderSteelSize
            .Add("@OrderQuantity", SqlDbType.VarChar).Value = Val(txtOrderQuantity.Text)
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            .Add("@FOXNumber", SqlDbType.VarChar).Value = GlobalSteelOrderFOXNumber
            .Add("@PartNumber", SqlDbType.VarChar).Value = GlobalSteelOrderPartNumber
            .Add("@SteelDescription", SqlDbType.VarChar).Value = GlobalSteelOrderSteelDescription
            .Add("@OrderDate", SqlDbType.VarChar).Value = Today.Date
            .Add("@EstDeliveryDate", SqlDbType.VarChar).Value = dtpDeliveryDate.Text
            .Add("@ProcessAgent", SqlDbType.VarChar).Value = GlobalSteelOrderProcessAgent
            .Add("@SteelVendor", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@PurchaseAgent", SqlDbType.VarChar).Value = ""
            .Add("@OnOrder", SqlDbType.VarChar).Value = "NO"
            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '****************************************************************************************
        'Generate email
        Dim mail As MailItem
        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'adding subject information to the mail message
        mail.Subject = "ORDER STEEL - FOX # " + strFOXNumber

        mail.To = "dblackburn@tfpcorp.com; tblackburn@tfpcorp.com; j.davies@tfpcorp.com; j.schultz@tfpcorp.com"

        'adding body message information to the mail message
        BodyLine1 = "STEEL ORDER TO BE PLACED;"
        BodyLine2 = "_________________________"
        BodyLine3 = "FOX # " + strFOXNumber
        BodyLine4 = "Steel --" + GlobalSteelOrderCarbon + " " + GlobalSteelOrderSteelSize + "" + GlobalSteelOrderSteelDescription
        BodyLine5 = "ORDER QUANTITY -- " + strOrderQuantity + " " + cboUnits.Text
        BodyLine6 = "REQUIRED DATE -- " + dtpDeliveryDate.Text
        BodyLine7 = "DATE ISSUED -- " + Today()
        BodyLine8 = "SPECIAL INSTRUCTIONS -- " + txtComment.Text
        BodyLine9 = "PROCESSED BY -- " + GlobalSteelOrderProcessAgent

        mail.Body = BodyLine1 & Environment.NewLine & BodyLine2 & Environment.NewLine & BodyLine3 & Environment.NewLine & BodyLine4 & Environment.NewLine & BodyLine5 & Environment.NewLine & BodyLine6 & Environment.NewLine & BodyLine7 & Environment.NewLine & BodyLine8 & Environment.NewLine & BodyLine9

        'adding attachment
        'mail.Attachments.Add("\\TFP-FS\TransferData\TruweldInvoices\TWInvoiceBatch" & ConfirmName & ".pdf")

        'display mail
        mail.Display()
        '*********************************************************************************************
        Dim CalendarEvent As AppointmentItem
        CalendarFileName = "TWD-" + strFOXNumber + "-01" + ".ics"

        CalendarEvent = DirectCast(OLApp.CreateItem(OlItemType.olAppointmentItem), AppointmentItem)
        CalendarEvent.Start = dtpDeliveryDate.Text
        CalendarEvent.End = dtpDeliveryDate.Text
        CalendarEvent.Location = "TFP Purchasing Dept."
        CalendarEvent.Subject = "ORDER STEEL - FOX # " + strFOXNumber
        CalendarEvent.Body = "This is a request to order steel for this FOX. Steel --" + GlobalSteelOrderCarbon + " " + GlobalSteelOrderSteelSize + " " + GlobalSteelOrderSteelDescription + ". Steel Required - " + strOrderQuantity + " LBS."
        CalendarEvent.AllDayEvent = True
        CalendarEvent.ReminderPlaySound = True
        CalendarEvent.ReminderSet = True
        CalendarEvent.ResponseRequested = True
        CalendarEvent.Importance = OlImportance.olImportanceHigh

        CalendarEvent.SaveAs("\\TFP-FS\TransferData\ProgramMail\" & CalendarFileName)

        mail.Attachments.Add("\\TFP-FS\TransferData\ProgramMail\" & CalendarFileName)

        mail.Display()
        '*********************************************************************************************

        MsgBox("Steel Order has been sent to purchasing.", MsgBoxStyle.OkOnly)

        Me.Close()
    End Sub

    Private Sub txtComment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComment.TextChanged

    End Sub
End Class