Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class InventoryRackingEmptyBins
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet

    Private Sub InventoryRackingEmptyBins_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GlobalDivisionCode = "SLC" Then
            dgvEmptyBinsSLC.Visible = True
            dgvEmptyBinsTWD.Visible = False
            LoadEmptyBinsSLC()
        Else
            dgvEmptyBinsSLC.Visible = False
            dgvEmptyBinsTWD.Visible = True
            LoadEmptyBinsTWD()
        End If
    End Sub

    Public Sub LoadEmptyBinsSLC()
        cmd = New SqlCommand("SELECT DISTINCT(BinNumber), BarWeightOpen, DivisionID FROM EmptyBinQuerySLC WHERE RackContent = 0 AND RackPosition <> 'UNAVAILABLE' AND RackPosition <> 'FLOOR' AND DivisionID = @DivisionID ORDER BY BinNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "EmptyBinQuerySLC")
        dgvEmptyBinsSLC.DataSource = ds1.Tables("EmptyBinQuerySLC")
        con.Close()
    End Sub

    Public Sub LoadEmptyBinsTWD()
        cmd = New SqlCommand("SELECT * FROM EmptyBinQueryTWD ORDER BY BinNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "EmptyBinQueryTWD")
        dgvEmptyBinsTWD.DataSource = ds2.Tables("EmptyBinQueryTWD")
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class