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
Public Class AssemblyAddNewSerialNumber
    Inherits System.Windows.Forms.Form

    Dim SerialStatus As String = ""
    Dim CheckSerialStatus As String = ""
    Dim CheckPart As Integer = 0
    Dim CheckSerialNumber As Integer = 0
    Dim SerialCost As Double = 0

    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As New DataTable

    Private Sub AssemblyAddNewSerialNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPartNumber()
        LoadPartDescription()

        txtSerialNumber.Clear()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        cboPartNumber.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID = @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID = @PurchProdLineID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumberByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

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

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        Dim strGetCostType As String = ""

        'Check to see if part number exists
        Dim CheckPartStatement As String = "SELECT COUNT(AssemblyPartNumber) FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim CheckPartCommand As New SqlCommand(CheckPartStatement, con)
        CheckPartCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        CheckPartCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim CheckStatusStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim CheckStatusCommand As New SqlCommand(CheckStatusStatement, con)
        CheckStatusCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        CheckStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If GlobalDivisionCode = "TWE" Then
            strGetCostType = "TotalCost"
        Else
            strGetCostType = "ShipmentPrice"
        End If

        Dim SerialCostStatement As String = "SELECT " + strGetCostType + " FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim SerialCostCommand As New SqlCommand(SerialCostStatement, con)
        SerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        SerialCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPart = CInt(CheckPartCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPart = 0
        End Try
        Try
            CheckSerialStatus = CStr(CheckStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSerialStatus = "NO"
        End Try
        Try
            SerialCost = CDbl(SerialCostCommand.ExecuteScalar)
        Catch ex As Exception
            SerialCost = 0
        End Try
        con.Close()

        If CheckPart = 0 Or CheckSerialStatus = "NO" Then
            MsgBox("Part Number does not exist or it is not serialized.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check to see if serial number exists
        Dim CheckSerialNumberStatement As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND SerialNumber = @SerialNumber"
        Dim CheckSerialNumberCommand As New SqlCommand(CheckSerialNumberStatement, con)
        CheckSerialNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        CheckSerialNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        CheckSerialNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckSerialNumber = CInt(CheckSerialNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSerialNumber = 0
        End Try
        con.Close()

        Dim CheckSerialNumberOtherDivision As Integer = 0

        Dim CheckSerialNumberOtherStatement As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID <> @DivisionID AND SerialNumber = @SerialNumber"
        Dim CheckSerialNumberOtherCommand As New SqlCommand(CheckSerialNumberOtherStatement, con)
        CheckSerialNumberOtherCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        CheckSerialNumberOtherCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        CheckSerialNumberOtherCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckSerialNumberOtherDivision = CInt(CheckSerialNumberOtherCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSerialNumberOtherDivision = 0
        End Try
        con.Close()

        If CheckSerialNumber <> 0 Then
            MsgBox("Serial # for this part already exists.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If CheckSerialNumberOtherDivision <> 0 Then
            MsgBox("Serial # for this part already exists in another division.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If rdoAvailable.Checked = True Then
            SerialStatus = "AVAILABLE"
            SerialCost = 0
        ElseIf rdoClosed.Checked = True Then
            SerialStatus = "CLOSED"
        ElseIf rdoOpen.Checked = True Then
            SerialStatus = "OPEN"
        End If

        Try
            'Write to table
            cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, TransactionNumber, CustomerID, BatchNumber, BuildNumber) Values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @TransactionNumber, @CustomerID, @BatchNumber, @BuildNumber)", con)

            With cmd.Parameters
                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@TotalCost", SqlDbType.VarChar).Value = SerialCost
                .Add("@Comment", SqlDbType.VarChar).Value = "MANUAL ENTRY"
                .Add("@BuildDate", SqlDbType.VarChar).Value = Today()
                .Add("@Status", SqlDbType.VarChar).Value = SerialStatus
                .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'error Log
        End Try

        MsgBox("Serial # entered.", MsgBoxStyle.OkOnly)

        txtSerialNumber.Clear()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPartNumber()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartNumberByDescription()
    End Sub
End Class