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
Public Class SteelAddNewCoilForm
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Sub SteelAddNewCoilForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSteelCarbon()
        LoadSteelSize()
        ClearData()
    End Sub

    Public Sub LoadSteelCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RawMaterialsTable")
        cboCarbon.DataSource = ds.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboSteelSize.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        txtCoilWeight.Clear()
        txtCoilID.Clear()
        txtComment.Clear()
        txtDescription.Clear()
        txtDespatchNumber.Clear()
        txtHeatNumber.Clear()
        txtLotNumber.Clear()
        txtPurchaseOrderNumber.Clear()
        txtSalesOrderNumber.Clear()

        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboCoilStatus.SelectedIndex = -1

        dtpReceiveDate.Value = Today()
    End Sub

    Public Sub InsertIntoCoilTable()
        'Write Data to Coil Table
        cmd = New SqlCommand("Insert Into CharterSteelCoilIdentification(CoilID, HeatNumber, Weight, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesOrderNumber, PurchaseOrderNumber, Description, Status, Location, InventoryID, AnnealLot, Comment) Values (@CoilID, @HeatNumber, @Weight, @LotNumber, @Carbon, @SteelSize, @ReceiveDate, @DespatchNumber, @SalesOrderNumber, @PurchaseOrderNumber, @Description, @Status, @Location, @InventoryID, @AnnealLot, @Comment)", con)

        With cmd.Parameters
            .Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
            .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
            .Add("@Weight", SqlDbType.VarChar).Value = Val(txtCoilWeight.Text)
            .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
            .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            .Add("@ReceiveDate", SqlDbType.VarChar).Value = dtpReceiveDate.Value
            .Add("@DespatchNumber", SqlDbType.VarChar).Value = txtDespatchNumber.Text
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = txtSalesOrderNumber.Text
            .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = txtPurchaseOrderNumber.Text
            .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
            .Add("@Status", SqlDbType.VarChar).Value = cboCoilStatus.Text
            .Add("@Location", SqlDbType.VarChar).Value = ""
            .Add("@InventoryID", SqlDbType.VarChar).Value = ""
            .Add("@AnnealLot", SqlDbType.VarChar).Value = ""
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Private Sub cmdEnterCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterCoil.Click
        'Validate Carbon and Steel Diameter
        Dim CheckRMID As Integer = 0

        Dim CheckRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim CheckRMIDCommand As New SqlCommand(CheckRMIDStatement, con)
        CheckRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        CheckRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckRMID = CInt(CheckRMIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            CheckRMID = 0
        End Try
        con.Close()

        If CheckRMID = 0 Then
            MsgBox("No steel exists with this carbon and size.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check Coil ID (if it is used)
        Dim CheckCoilID As Integer = 0

        Dim CheckCoilIDStatement As String = "SELECT COUNT(CoilID) FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID"
        Dim CheckCoilIDCommand As New SqlCommand(CheckCoilIDStatement, con)
        CheckCoilIDCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckCoilID = CInt(CheckCoilIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            CheckCoilID = 0
        End Try
        con.Close()

        If CheckCoilID <> 0 Then
            MsgBox("This Coil ID already exists in the database.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            'Enter into database
            InsertIntoCoilTable()
        Catch ex As Exception
            'Error Log
        End Try

        'Clear Fields
        ClearData()

        MsgBox("Coil has been added to the table.", MsgBoxStyle.OkOnly)
    End Sub
End Class