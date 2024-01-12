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
Public Class SelectSteelCoilsForReceiving
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub SelecSteelCoilsForReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()
        LoadCharterCoils()
    End Sub

    Public Sub LoadCharterCoils()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM CharterSteelCoilIdentification WHERE DespatchNumber = @DespatchNumber AND Status = @Status", con)
        cmd.Parameters.Add("@DespatchNumber", SqlDbType.VarChar).Value = GlobalSteelDespatchNumber
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CharterSteelCoilIdentification")
        dgvCharterCoils.DataSource = ds.Tables("CharterSteelCoilIdentification")
        con.Close()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment.Substring(0, 300)
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim NewSteelCoilReceiving As New SteelReceivingByCoil
        NewSteelCoilReceiving.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        'Retrieve line data from Steel Return Table
        Dim LastLineNumber, NextLineNumber, SteelPONumber, SteelPOLineNumber As Integer
        Dim LineComment, CoilID, Carbon, SteelSize, HeatNumber, GetRMID As String
        Dim GetTotalWeight, GetSteelTotal, CoilWeight, LineWeight, GetSteelCost, CoilExtendedCost, LineExtendedCost As Double
        Dim Counter As Integer = 1

        For Each row As DataGridViewRow In dgvCharterCoils.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForReceiptColumn")

            If cell.Value = "SELECTED" Then
                Try
                    CoilID = row.Cells("CoilIDColumn").Value
                Catch ex As Exception
                    CoilID = ""
                End Try
                Try
                    Carbon = row.Cells("CarbonColumn").Value
                Catch ex As Exception
                    Carbon = ""
                End Try
                Try
                    SteelSize = row.Cells("SteelSizeColumn").Value
                Catch ex As Exception
                    SteelSize = ""
                End Try
                Try
                    HeatNumber = row.Cells("HeatNumberColumn").Value
                Catch ex As Exception
                    HeatNumber = ""
                End Try
                Try
                    SteelPONumber = row.Cells("PurchaseOrderNumberColumn").Value
                Catch ex As Exception
                    SteelPONumber = 0
                End Try
                Try
                    CoilWeight = row.Cells("WeightColumn").Value
                Catch ex As Exception
                    CoilWeight = 0
                End Try
                '************************************************************************************
                'Get RMID for carbon/steel size
                Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
                Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
                GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = Carbon
                GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
                Catch ex As Exception
                    GetRMID = ""
                End Try
                con.Close()
                '************************************************************************************
                'Get Steel PO Line # based on PO # and RMID
                Dim GetLineNumberStatement As String = "SELECT SteelPurchaseLineNumber FROM SteelPurchaseLine WHERE RMID = @RMID AND SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey"
                Dim GetLineNumberCommand As New SqlCommand(GetLineNumberStatement, con)
                GetLineNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID
                GetLineNumberCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = SteelPONumber

                Dim GetSteelCostStatement As String = "SELECT PurchasePricePerPound FROM SteelPurchaseLine WHERE RMID = @RMID AND SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey"
                Dim GetSteelCostCommand As New SqlCommand(GetSteelCostStatement, con)
                GetSteelCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID
                GetSteelCostCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = SteelPONumber

                Dim LineCommentStatement As String = "SELECT LineComment FROM SteelPurchaseLine WHERE RMID = @RMID AND SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey"
                Dim LineCommentCommand As New SqlCommand(LineCommentStatement, con)
                LineCommentCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID
                LineCommentCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = SteelPONumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SteelPOLineNumber = CInt(GetLineNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    SteelPOLineNumber = 0
                End Try
                Try
                    GetSteelCost = CDbl(GetSteelCostCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSteelCost = 0
                End Try
                Try
                    LineComment = CStr(LineCommentCommand.ExecuteScalar)
                Catch ex As Exception
                    LineComment = ""
                End Try
                con.Close()

                'Calculate Coil Cost
                CoilExtendedCost = CoilWeight * GetSteelCost
                CoilExtendedCost = Math.Round(CoilExtendedCost, 5)
                '************************************************************************************
                'Insert into Steel Receiving Line Table (one time)
                If Counter = 1 Then
                    '**************************************************************************************************
                    'Get Next Line Number
                    Dim LastLineNumberStatement As String = "SELECT MAX(SteelReceivingLineKey) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey"
                    Dim LastLineNumberCommand As New SqlCommand(LastLineNumberStatement, con)
                    LastLineNumberCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastLineNumber = CInt(LastLineNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastLineNumber = 0
                    End Try
                    con.Close()

                    NextLineNumber = LastLineNumber + 1
                    '***********************************************************************************
                    Try
                        'Write Data to Receiving Line Database Table
                        cmd = New SqlCommand("INSERT INTO SteelReceivingLineTable(SteelReceivingHeaderKey, SteelReceivingLineKey, RMID, ReceiveWeight, SteelExtendedCost, LineStatus, SelectForInvoice, LineComment, DebitGLAccount, CreditGLAccount, SteelPONumber, SteelPOLineNumber) Values (@SteelReceivingHeaderKey, @SteelReceivingLineKey, @RMID, @ReceiveWeight, @SteelExtendedCost, @LineStatus, @SelectForInvoice, @LineComment, @DebitGLAccount, @CreditGLAccount, @SteelPONumber, @SteelPOLineNumber)", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber
                            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = NextLineNumber
                            .Add("@RMID", SqlDbType.VarChar).Value = GetRMID
                            .Add("@ReceiveWeight", SqlDbType.VarChar).Value = 0
                            .Add("@SteelExtendedCost", SqlDbType.VarChar).Value = 0
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                            .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "12000"
                            .Add("@CreditGLAccount", SqlDbType.VarChar).Value = "20995"
                            .Add("@SteelPONumber", SqlDbType.VarChar).Value = SteelPONumber
                            .Add("@SteelPOLineNumber", SqlDbType.VarChar).Value = SteelPOLineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                    End Try
                Else
                    'Skip - write to line table one time only
                End If

                Counter = Counter + 1
                '************************************************************************************
                'Insert in Coil Line Table
                Try
                    'Write Data to Receiving Line Database Table
                    cmd = New SqlCommand("INSERT INTO SteelReceivingCoilLines(SteelReceivingHeaderKey, SteelReceivingLineKey, CoilID, CoilWeight, HeatNumber, PONumber, POLineNumber, SteelCostPerPound, SteelExtendedAmount) Values (@SteelReceivingHeaderKey, @SteelReceivingLineKey, @CoilID, @CoilWeight, @HeatNumber, @PONumber, @POLineNumber, @SteelCostPerPound, @SteelExtendedAmount)", con)

                    With cmd.Parameters
                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber
                        .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = NextLineNumber
                        .Add("@CoilID", SqlDbType.VarChar).Value = CoilID
                        .Add("@CoilWeight", SqlDbType.VarChar).Value = CoilWeight
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                        .Add("@PONumber", SqlDbType.VarChar).Value = SteelPONumber
                        .Add("@POLineNumber", SqlDbType.VarChar).Value = SteelPOLineNumber
                        .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = GetSteelCost
                        .Add("@SteelExtendedAmount", SqlDbType.VarChar).Value = CoilExtendedCost
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                End Try

                'Update Charter Table
                Try
                    cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Status = @Status, ReceiveDate = @ReceiveDate WHERE CoilID = @CoilID AND Status = @Status2", con)

                    With cmd.Parameters
                        .Add("@CoilID", SqlDbType.VarChar).Value = CoilID
                        .Add("@Status", SqlDbType.VarChar).Value = "RAW"
                        .Add("@Status2", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@ReceiveDate", SqlDbType.VarChar).Value = Today()
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                End Try
            End If
        Next

        'Update Receiver Line Totals
        Dim GetLineWeightStatement As String = "SELECT SUM(CoilWeight) FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey"
        Dim GetLineWeightCommand As New SqlCommand(GetLineWeightStatement, con)
        GetLineWeightCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber
        GetLineWeightCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = NextLineNumber

        Dim GetExtendedAmountStatement As String = "SELECT SUM(SteelExtendedAmount) FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey"
        Dim GetExtendedAmountCommand As New SqlCommand(GetExtendedAmountStatement, con)
        GetExtendedAmountCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber
        GetExtendedAmountCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = NextLineNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LineWeight = CDbl(GetLineWeightCommand.ExecuteScalar)
        Catch ex As Exception
            LineWeight = 0
        End Try
        Try
            LineExtendedCost = CDbl(GetExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            LineExtendedCost = 0
        End Try
        con.Close()

        LineWeight = Math.Round(LineWeight, 0)
        LineExtendedCost = Math.Round(LineExtendedCost, 2)

        Try
            'Write values to Batch Table
            cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET ReceiveWeight = @ReceiveWeight, SteelExtendedCost = @SteelExtendedCost WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

            With cmd.Parameters
                .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber
                .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = NextLineNumber
                .Add("@ReceiveWeight", SqlDbType.VarChar).Value = LineWeight
                .Add("@SteelExtendedCost", SqlDbType.VarChar).Value = LineExtendedCost
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
        End Try

        'Update Receiver Header Totals
        Dim GetTotalWeightStatement As String = "SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey"
        Dim GetTotalWeightCommand As New SqlCommand(GetTotalWeightStatement, con)
        GetTotalWeightCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber
        GetTotalWeightCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = NextLineNumber

        Dim GetTotalExtendedAmountStatement As String = "SELECT SUM(SteelExtendedCost) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey"
        Dim GetTotalExtendedAmountCommand As New SqlCommand(GetTotalExtendedAmountStatement, con)
        GetTotalExtendedAmountCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber
        GetTotalExtendedAmountCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = NextLineNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetTotalWeight = CDbl(GetTotalWeightCommand.ExecuteScalar)
        Catch ex As Exception
            GetTotalWeight = 0
        End Try
        Try
            GetSteelTotal = CDbl(GetTotalExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            GetSteelTotal = 0
        End Try
        con.Close()

        GetTotalWeight = Math.Round(GetTotalWeight, 0)
        GetSteelTotal = Math.Round(GetSteelTotal, 2)

        Try
            'Write values to Header Table
            cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET SteelTotalWeight = @SteelTotalWeight, SteelTotal = @SteelTotal WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)

            With cmd.Parameters
                .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber
                .Add("@SteelTotalWeight", SqlDbType.VarChar).Value = GetTotalWeight
                .Add("@SteelTotal", SqlDbType.VarChar).Value = GetSteelTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET InvoiceTotal = SteelTotal + SteelFreightCharges + SteelOtherCharges WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)

            With cmd.Parameters
                .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
        End Try

        Dim NewSteelCoilReceiving As New SteelReceivingByCoil
        NewSteelCoilReceiving.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvCharterCoils.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForReceiptColumn")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvCharterCoils.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForReceiptColumn")
            cell.Value = "SELECTED"
        Next
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

    Private Sub LoginPage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub
End Class