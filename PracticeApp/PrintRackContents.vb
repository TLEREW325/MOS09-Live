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
Public Class PrintRackContents
    Inherits System.Windows.Forms.Form

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

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE ItemClass <> @ItemClass AND SalesProdLineID <> @SalesProdLineID AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartNumber.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE ItemClass <> @ItemClass AND SalesProdLineID <> @SalesProdLineID AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboPartDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        PartNumber1Command.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        PartDescription1Command.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Private Sub PrintRackContents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPartNumber()
        LoadPartDescription()
    End Sub

    Private Sub cmdFilterByRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterByRack.Click
        If txtRackNumber.Text = "" Then
            MsgBox("You must select a Bin Number.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE BinNumber LIKE @BinNumber AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) ORDER BY BinNumber, PartNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
            cmd.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = "%" + txtRackNumber.Text + "%"

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "RackingTransactionTable")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXPrintRackContents1
            MyReport.SetDataSource(ds)
            CRRackViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub cmdFilterByPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterByPart.Click
        If cboPartNumber.Text = "" Then
            MsgBox("You must select a part number.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE PartNumber = @PartNumber AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) ORDER BY BinNumber, PartNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
            cmd.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "RackingTransactionTable")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXPrintRackContents1
            MyReport.SetDataSource(ds)
            CRRackViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub CRRackViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRRackViewer.Load
  
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtRackNumber.Clear()
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        txtRackNumber.Focus()

        'ds = New DataSet()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = Nothing
        'MyReport.SetDataSource(ds)
        CRRackViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class