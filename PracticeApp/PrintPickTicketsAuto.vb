﻿Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class PrintPickTicketsAuto
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")

    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub CRPickViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPickViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM PickListHeaderTable WHERE DivisionID = @DivisionID AND PickListHeaderKey = @PickListHeaderKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber

        cmd1 = New SqlCommand("SELECT * FROM PickListLineTable WHERE DivisionID = @DivisionID", con2)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo", con)

        If con.State = ConnectionState.Closed Then con.Open()
        If con2.State = ConnectionState.Closed Then con2.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PickListHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "PickListLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "FoxTable")

        myAdapter6.SelectCommand = cmd6
        myAdapter6.Fill(ds, "AdditionalShipTo")

        con.Close()
        con2.Close()

        'Sets up viewer to display data from the loaded dataset
        If con.State = ConnectionState.Closed Then con.Open()
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXPickTicket1
        MyReport.SetDataSource(ds)

        If GlobalDivisionCode.Equals("TWD") Then
            Dim pd As New PrintDialog()
            Dim i As Integer
            pd.UseEXDialog = True

            pd.PrinterSettings = New PrinterSettings()
            Dim printers(pd.PrinterSettings.InstalledPrinters.Count) As [String]
            pd.PrinterSettings.InstalledPrinters.CopyTo(printers, 0)
            pd.PrinterSettings.PrinterName = ""
            Dim notFound As Boolean = True
            ''checks to see if the designated printer is present
            While i < printers.Count() - 1 And notFound
                Dim test As String = printers(i)
                If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains(usefulFunctions.shippingPrinterName) Then
                    pd.PrinterSettings.PrinterName = printers(i)
                    notFound = False
                End If
                i += 1
            End While
            If notFound Then
                MyReport.PrintToPrinter(1, True, 0, 0)
            Else
                ''check to see if the printer is in a state that i can print if not will open print dialog
                If usefulFunctions.ShippingPrinterStatus(pd.PrinterSettings.PrinterName) Then
                    MyReport.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName
                    MyReport.PrintToPrinter(1, True, 0, 0)
                Else
                    MyReport.PrintToPrinter(1, True, 0, 0)
                End If
            End If
            Me.Dispose()
            Me.Close()
        Else
            MyReport.PrintToPrinter(1, True, 1, 999)
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNo.Click
        'Sets up viewer to display data from the loaded dataset
        If con.State = ConnectionState.Closed Then con.Open()
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXPickTicket1
        MyReport.SetDataSource(ds)
        MyReport.PrintToPrinter(1, True, 1, 999)
        con.Close()
    End Sub

    Private Sub PrintPickTicketsAuto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class