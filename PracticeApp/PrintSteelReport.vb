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
Public Class PrintSteelReport
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable


    Public Sub LoadRawMaterials()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM SteelFoxListing WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd2 = New SqlCommand("SELECT DISTINCT SteelSize FROM SteelFoxListing WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        ds4 = New DataSet()

        myAdapter5.SelectCommand = cmd
        myAdapter4.SelectCommand = cmd2

        myAdapter5.Fill(ds5, "SteelFoxListing")
        myAdapter4.Fill(ds4, "SteelFoxListing")

        cboCarbon.DisplayMember = "Carbon"
        cboSize.DisplayMember = "SteelSize"
        cboCarbon.DataSource = ds5.Tables("SteelFoxListing")
        cboSize.DataSource = ds4.Tables("SteelFoxListing")
        con.Close()
        cboCarbon.SelectedIndex = -1
        cboSize.SelectedIndex = -1

     


    End Sub
    Private Sub PrintSteelReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadRawMaterials()
    End Sub

    Private Sub cmdRMID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRMID.Click


        cmd = New SqlCommand("SELECT * from SteelFOXListing Where DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cmd.CommandText += " AND Carbon = @CARBON"
            cmd.Parameters.Add("@CARBON", SqlDbType.VarChar).Value = cboCarbon.Text
        End If

        If Not String.IsNullOrEmpty(cboSize.Text) Then
            cmd.CommandText += " AND SteelSize = @STEELSIZE"
            cmd.Parameters.Add("@STEELSIZE", SqlDbType.VarChar).Value = cboSize.Text
        End If


        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelFOXListing")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSteelReport1
        MyReport.SetDataSource(ds)
        CRSteelViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
     
        CRSteelViewer.ReportSource = Nothing

        cboCarbon.SelectedIndex = -1
        cboSize.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cboCarbon.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboSize.Text) Then
            cboSize.Text = ""
        End If
      
    End Sub
End Class