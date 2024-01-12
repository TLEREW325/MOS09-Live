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
Public Class ShipmentTaskCreation
    Inherits System.Windows.Forms.Form

    Dim strShipmentNumber As String

    'Created Outlook Application object
    Dim OLApp As New Application

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ShipmentTaskCreation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateAppointmentRecord()

        GlobalCustomerID = ""
        GlobalShipmentNumber = 0

        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub CreateAppointmentRecord()
        Dim Appointment As AppointmentItem
        Dim Task As TaskItem

        strShipmentNumber = CStr(GlobalShipmentNumber)

        Appointment = OLApp.CreateItem(OlItemType.olAppointmentItem)
        Task = OLApp.CreateItem(OlItemType.olTaskItem)

        Task.Body = "Shipment # " & strShipmentNumber & " sent to " & GlobalCustomerID
        Task.Subject = "TW Shipment - " & GlobalCustomerID
        Task.StartDate = Today()
        Task.DueDate = Today()
        Task.ReminderPlaySound = True
        Task.Importance = OlImportance.olImportanceHigh
        Task.Save()

        Appointment.Start = Today() & " 8:00AM"
        Appointment.End = Today() & " 5:00PM"
        Appointment.Location = "Shipment Sent"
        Appointment.Body = "Shipment # " & strShipmentNumber & " sent to " & GlobalCustomerID
        Appointment.Subject = GlobalCustomerID & " / " & strShipmentNumber
        Appointment.AllDayEvent = False

        Appointment.Save()
    End Sub
End Class