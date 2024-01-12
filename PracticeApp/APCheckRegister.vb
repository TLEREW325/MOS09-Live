Imports System
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
Public Class APCheckRegister
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub APCheckRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        If GlobalAPBatchNumber > 0 Then
            ShowCheckLinesForBatch()
        Else
            'Do nothing
        End If
    End Sub

    Public Sub ShowCheckLinesForBatch()
        cmd = New SqlCommand("SELECT * FROM APCheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckLog")
        dgvAPCheckLog.DataSource = ds.Tables("APCheckLog")
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintCheckRegisterFiltered As New PrintCheckRegisterFiltered
            Dim Result = NewPrintCheckRegisterFiltered.ShowDialog()
        End Using
    End Sub
End Class