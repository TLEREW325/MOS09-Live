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
Public Class SteelReceivingCoilsPopup
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub SteelCoilsPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDatagrid()
        lblReceiverNumber.Text = "Steel Receiver # - " + CStr(GlobalSteelReceiverNumberPopup)
        lblRMID.Text = GlobalSteelReceiverRMIDPopup
    End Sub

    Public Sub LoadDatagrid()
        cmd = New SqlCommand("SELECT * FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceiverNumberPopup
        cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = GlobalSteelReceiverLinePopup
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReceivingCoilLines")
        dgvCoilLines.DataSource = ds.Tables("SteelReceivingCoilLines")
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalSteelReceiverLinePopup = 0
        GlobalSteelReceiverNumberPopup = 0
        GlobalSteelReceiverRMIDPopup = ""

        Me.Dispose()
        Me.Close()
    End Sub
End Class