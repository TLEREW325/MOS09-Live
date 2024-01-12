Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintSingleAPCheck
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim RemmittanceReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadRemmittancePrinter()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * from APCheckQuery where CheckNumber = @CheckNumber AND DivisionID = @DivisionID AND ExtendedCheck ='YES'", con)
        cmd.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = GlobalAPCheckNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * from DivisionTable where DivisionKey = @DivisionKey AND DivisionKey = @DivisionKey", con)
        cmd1.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds2, "APCheckQuery")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds2, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        RemmittanceReport = CRXPTRemittance1
        RemmittanceReport.SetDataSource(ds2)
        RemmittanceReport.PrintToPrinter(2, True, 1, 999)
        con.Close()
    End Sub

    Private Sub CRCheckViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCheckViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM APCheckQuery WHERE CheckNumber = @CheckNumber", con)
        cmd.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = GlobalAPCheckNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckQuery")

        'Sets up viewer to display data from the loaded dataset

        If GlobalAPCheckType = "STANDARD" Then
            MyReport = CRXMICRCheck1
        ElseIf GlobalAPCheckType = "American" Then
            MyReport = CRXMICRCheck1
        ElseIf GlobalAPCheckType = "Canadian" Then
            MyReport = CRXMICRCANCheck1
        ElseIf GlobalAPCheckType = "CANADIAN" Then
            MyReport = CRXMICRCANCheck1
        Else
            MyReport = CRXMICRCheck1
        End If

        MyReport.SetDataSource(ds)
        CRCheckViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintRemmittanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintRemmittanceToolStripMenuItem.Click
        'Check to see if an extended check needs printed
        Dim CountNumberOfChecks As Integer = 0

        Dim CountChecksString As String = "SELECT COUNT(CheckNumber) FROM APCheckQuery WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID AND ExtendedCheck ='YES'"
        Dim CountChecksCommand As New SqlCommand(CountChecksString, con)
        CountChecksCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = GlobalAPCheckNumber
        CountChecksCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountNumberOfChecks = CInt(CountChecksCommand.ExecuteScalar)
        Catch ex As Exception
            CountNumberOfChecks = 0
        End Try
        con.Close()

        If CountNumberOfChecks = 0 Then
            'Skip Remmittance
            MsgBox("No extended remmittance to print.", MsgBoxStyle.OkOnly)
        Else
            'Print Extended Remmittance, if necessary
            LoadRemmittancePrinter()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        CRCheckViewer.PrintReport()

        'Check to see if an extended check needs printed
        Dim CountNumberOfChecks As Integer = 0

        Dim CountChecksString As String = "SELECT COUNT(CheckNumber) FROM APCheckQuery WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID AND ExtendedCheck ='YES'"
        Dim CountChecksCommand As New SqlCommand(CountChecksString, con)
        CountChecksCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = GlobalAPCheckNumber
        CountChecksCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountNumberOfChecks = CInt(CountChecksCommand.ExecuteScalar)
        Catch ex As Exception
            CountNumberOfChecks = 0
        End Try
        con.Close()

        If CountNumberOfChecks = 0 Then
            'Skip Remmittance
        Else
            'Print Extended Remmittance, if necessary
            LoadRemmittancePrinter()
        End If
    End Sub

    Private Sub PrintSingleAPCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class