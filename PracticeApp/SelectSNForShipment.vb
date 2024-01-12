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
Public Class SelectSNForShipment
    Inherits System.Windows.Forms.Form

    Dim needsReopened As Boolean = True

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub SelectSNForShipment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()
        GlobalVerifyCode = "FAILED"
        ShowSerialNumbers()

        If GlobalDivisionCode = "TWE" Then
            Me.dgvSerialLog.Columns("TotalCostColumn").Visible = True
            Me.dgvSerialLog.Columns("ShipmentPriceColumn").Visible = False
        Else
            Me.dgvSerialLog.Columns("TotalCostColumn").Visible = False
            Me.dgvSerialLog.Columns("ShipmentPriceColumn").Visible = True
        End If
    End Sub

    Public Sub ShowSerialNumbers()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status ORDER BY SerialNumber ASC", con)
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = GlobalShipmentPartNumberSerial
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblySerialLog")
        dgvSerialLog.DataSource = ds.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvSerialLog.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvSerialLog.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        Dim BuildCost As Double = 0
        Dim SerialNumber As String = ""
        Dim MAXLineTotal As Integer = 0
        Dim NextLineNumber As Integer = 0
        Dim LastTransactionCost As Double = 0
        Dim MaxDate As Integer = 0
        Dim SumAssemblyCost As Double = 0

        'Retrieve line data from PO Table and write to Receipt Of Invoice Table
        For Each row As DataGridViewRow In dgvSerialLog.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

            If cell.Value = "SELECTED" Then
                Try
                    SerialNumber = row.Cells("SerialNumberColumn").Value
                Catch ex As Exception
                    SerialNumber = ""
                End Try
                If GlobalDivisionCode = "TWE" Then
                    Try
                        BuildCost = row.Cells("TotalCostColumn").Value
                    Catch ex As Exception
                        BuildCost = 0
                    End Try
                Else
                    Try
                        BuildCost = row.Cells("ShipmentPriceColumn").Value
                    Catch ex As Exception
                        BuildCost = 0
                    End Try
                End If

                If BuildCost = 0 Then
                    'If no build cost in the serial # log, get last transaction cost
                    Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalShipmentPartNumberSerial

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxDate = CInt(MAXDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MaxDate = 0
                    End Try
                    con.Close()

                    Dim LastTransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                    Dim LastTransactionCostCommand As New SqlCommand(LastTransactionCostStatement, con)
                    LastTransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    LastTransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalShipmentPartNumberSerial
                    LastTransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastTransactionCost = CDbl(LastTransactionCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastTransactionCost = 0
                    End Try
                    con.Close()

                    BuildCost = LastTransactionCost
                Else
                    'Skip
                End If

                If SerialNumber = "" Then
                    'Skip Entry
                Else
                    'Get next Line Number
                    Dim MAXLineStatement As String = "SELECT MAX(SerialLineNumber) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
                    MAXLineCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumberSerial
                    MAXLineCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = GlobalShipmentLineNumberSerial

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXLineTotal = CInt(MAXLineCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXLineTotal = 0
                    End Try
                    con.Close()

                    NextLineNumber = MAXLineTotal + 1

                    'UPDATE Shipment Line Serial Numbers
                    cmd = New SqlCommand("INSERT INTO ShipmentLineSerialNumbers (ShipmentNumber, ShipmentLineNumber, SerialLineNumber, SerialNumber, SerialCost, SerialQuantity) Values (@ShipmentNumber, @ShipmentLineNumber, @SerialLineNumber, @SerialNumber, @SerialCost, @SerialQuantity)", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumberSerial
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = GlobalShipmentLineNumberSerial
                        .Add("@SerialLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                        .Add("@SerialCost", SqlDbType.VarChar).Value = BuildCost
                        .Add("@SerialQuantity", SqlDbType.VarChar).Value = 1
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        Next

        'Sum Assembly Cost Total and update COS in Shipment Line
        Dim SumAssemblyCostStatement As String = "SELECT SUM(SerialCost) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
        Dim SumAssemblyCostCommand As New SqlCommand(SumAssemblyCostStatement, con)
        SumAssemblyCostCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumberSerial
        SumAssemblyCostCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = GlobalShipmentLineNumberSerial

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumAssemblyCost = CDbl(SumAssemblyCostCommand.ExecuteScalar)
        Catch ex As Exception
            SumAssemblyCost = 0
        End Try
        con.Close()

        'UPDATE Shipment Line Serial Numbers
        cmd = New SqlCommand("UPDATE ShipmentLineTable SET ExtendedCOS = @ExtendedCOS WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

        With cmd.Parameters
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumberSerial
            .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = GlobalShipmentLineNumberSerial
            .Add("@ExtendedCOS", SqlDbType.VarChar).Value = SumAssemblyCost
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("Serial Numbers have been added.", MsgBoxStyle.OkOnly)

        'Open the UPDATED Form
        GlobalSOShipmentNumber = GlobalShipmentNumberSerial

        Dim NewShipmentCompletion As New ShipmentCompletion
        NewShipmentCompletion.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Open the UPDATED Form
        GlobalSOShipmentNumber = GlobalShipmentNumberSerial

        Dim NewShipmentCompletion As New ShipmentCompletion
        NewShipmentCompletion.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        ' The return value specifies the previous state of the menu item (it is either      
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.      
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub

    Private Sub SelectPOLines_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub
End Class