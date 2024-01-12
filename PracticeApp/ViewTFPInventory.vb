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
Public Class ViewTFPInventory
    Inherits System.Windows.Forms.Form

    Dim PartFilter, FOXFilter, BPFilter, QuantityFilter, OrderFilter As String
    Dim SONumber, FOXNumber As Integer
    Dim strSONumber, strFOXNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ViewTFPInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBlueprint()
        LoadPartNumber()
        LoadSalesOrderNumber()
        LoadFOXNumber()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        usefulFunctions.LoadSecurity(Me)
    End Sub

    Public Sub ShowDataByFilter()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboBlueprintNumber.Text <> "" Then
            BPFilter = " AND BlueprintNumber = '" + cboBlueprintNumber.Text + "'"
        Else
            BPFilter = ""
        End If
        If cboOrderNumber.Text <> "" Then
            SONumber = Val(cboOrderNumber.Text)
            strSONumber = CStr(SONumber)
            OrderFilter = " AND OrderReferenceNumber = '" + strSONumber + "'"
        Else
            OrderFilter = ""
        End If
        If cboFOXNumber.Text <> "" Then
            FOXNumber = Val(cboFOXNumber.Text)
            strFOXNumber = CStr(FOXNumber)
            FOXFilter = " AND FOXNumber = '" + strFOXNumber + "'"
        Else
            FOXFilter = ""
        End If
        If chkQOH.Checked = True Then
            QuantityFilter = " AND QuantityOnHand <> 0"
        Else
            QuantityFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM TFPInventoryTotals WHERE DivisionID = @DivisionID" + PartFilter + FOXFilter + QuantityFilter + BPFilter + OrderFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TFPInventoryTotals")
        dgvTFPInventory.DataSource = ds.Tables("TFPInventoryTotals")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvTFPInventory.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        con.Close()

        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDescription.DataSource = ds1.Tables("ItemList")
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBlueprint()
        cmd = New SqlCommand("SELECT DISTINCT BlueprintNumber FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "FOXTable")
        cboBlueprintNumber.DataSource = ds2.Tables("FOXTable")
        con.Close()
        cboBlueprintNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "FOXTable")
        cboFOXNumber.DataSource = ds3.Tables("FOXTable")
        con.Close()
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesOrderNumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SalesOrderHeaderTable")
        cboOrderNumber.DataSource = ds4.Tables("SalesOrderHeaderTable")
        con.Close()
        cboOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboBlueprintNumber.SelectedIndex = -1
        cboFOXNumber.SelectedIndex = -1
        cboOrderNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1

        chkQOH.Checked = True
    End Sub

    Public Sub LoadPartNumberByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1String As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1String, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPartNumber()
        Dim PartDescription1 As String = ""

        Dim PartDescription1String As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1String, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPartNumber()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartNumberByDescription()
    End Sub

    Public Sub ClearVariables()
        PartFilter = ""
        FOXFilter = ""
        BPFilter = ""
        QuantityFilter = ""
        OrderFilter = ""
        SONumber = 0
        FOXNumber = 0
        strSONumber = ""
        strFOXNumber = ""
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintTFPInventory As New PrintTFPInventory
            Dim Result = NewPrintTFPInventory.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintTFPInventory As New PrintTFPInventory
            Dim Result = NewPrintTFPInventory.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub
End Class
