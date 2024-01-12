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
Public Class SelectSteelCoilsForReturn
    Inherits System.Windows.Forms.Form

    Dim LastGLNumber, NextGLNumber, LineNumber As Integer
    Dim DebitGLAccount, CreditGLAccount As String
    Dim ExtendedAmount, FreightCharge, SalesTax, ProductTotal, ReceiverTotal As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim ShipDate As Date

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

    Private Sub SelectSteelCoilsForReturn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalSteelReturnFormType = ""
        GlobalSteelReturnCarbon = ""
        GlobalSteelReturnPONumber = 0
        GlobalSteelReturnSize = ""
        GlobalSteelReturnNumber = 0
    End Sub

    Private Sub SelectSteelCoilsForReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GlobalSteelReturnFormType = "RECEIVER" Then
            Me.dgvCoilListing.Visible = False
            Me.dgvSteelReceivingCoilLines.Visible = True

            LoadCoilsByPO()
        ElseIf GlobalSteelReturnFormType = "COIL LIST" Then
            Me.dgvCoilListing.Visible = True
            Me.dgvSteelReceivingCoilLines.Visible = False

            LoadCoilsByList()
        Else
            'Error Log
        End If
    End Sub

    Public Sub LoadCoilsByPO()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM SteelReceivingCoilLines WHERE PONumber = @PONumber", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = GlobalSteelReturnPONumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReceivingCoilLines")
        dgvSteelReceivingCoilLines.DataSource = ds.Tables("SteelReceivingCoilLines")
        con.Close()
    End Sub

    Public Sub LoadCoilsByList()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM CharterSteelCoilIdentification WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND Status = 'RAW' ORDER BY CoilID", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = GlobalSteelReturnCarbon
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = GlobalSteelReturnSize
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CharterSteelCoilIdentification")
        dgvCoilListing.DataSource = ds.Tables("CharterSteelCoilIdentification")
        con.Close()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        If GlobalSteelReturnFormType = "RECEIVER" Then
            For Each row As DataGridViewRow In dgvSteelReceivingCoilLines.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectCoilsColumn")
                cell.Value = "SELECTED"
            Next
        ElseIf GlobalSteelReturnFormType = "COIL LIST" Then
            For Each row As DataGridViewRow In dgvCoilListing.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectCoilsColumn2")
                cell.Value = "SELECTED"
            Next
        Else
            'Error Log
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        If GlobalSteelReturnFormType = "RECEIVER" Then
            For Each row As DataGridViewRow In dgvSteelReceivingCoilLines.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectCoilsColumn")
                cell.Value = "UNSELECTED"
            Next
        ElseIf GlobalSteelReturnFormType = "COIL LIST" Then
            For Each row As DataGridViewRow In dgvCoilListing.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectCoilsColumn2")
                cell.Value = "UNSELECTED"
            Next
        Else
            'Error Log
        End If
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        If GlobalSteelReturnFormType = "RECEIVER" Then
            Dim SteelReceiverNumber, SteelReceiverLine, SteelPONumber, SteelPOLine As Integer
            Dim SteelCoilID, SteelHeatNumber As String
            Dim SteelCoilWeight, SteelUnitCost, SteelExtendedAmount As Double
            Dim GetRMID As String = ""

            'Get data from each selected row
            For Each row As DataGridViewRow In dgvSteelReceivingCoilLines.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectCoilsColumn")

                If cell.Value = "SELECTED" Then
                    Try
                        SteelReceiverNumber = row.Cells("SteelReceivingHeaderKeyColumn").Value
                    Catch ex As Exception
                        SteelReceiverNumber = 0
                    End Try
                    Try
                        SteelReceiverLine = row.Cells("SteelReceivingLineKeyColumn").Value
                    Catch ex As Exception
                        SteelReceiverLine = 0
                    End Try
                    Try
                        SteelPONumber = row.Cells("PONumberColumn").Value
                    Catch ex As Exception
                        SteelPONumber = 0
                    End Try
                    Try
                        SteelPOLine = row.Cells("POLineNumberColumn").Value
                    Catch ex As Exception
                        SteelPOLine = 0
                    End Try
                    Try
                        SteelCoilWeight = row.Cells("CoilWeightColumn").Value
                    Catch ex As Exception
                        SteelCoilWeight = 0
                    End Try
                    Try
                        SteelUnitCost = row.Cells("SteelCostPerPoundColumn").Value
                    Catch ex As Exception
                        SteelUnitCost = 0
                    End Try
                    Try
                        SteelExtendedAmount = row.Cells("SteelExtendedAmountColumn").Value
                    Catch ex As Exception
                        SteelExtendedAmount = 0
                    End Try
                    Try
                        SteelCoilID = row.Cells("CoilIDColumn").Value
                    Catch ex As Exception
                        SteelCoilID = ""
                    End Try
                    Try
                        SteelHeatNumber = row.Cells("HeatNumberColumn").Value
                    Catch ex As Exception
                        SteelHeatNumber = ""
                    End Try

                    If SteelCoilID = "" Then

                    Else

                    End If
                    '***********************************************************************************************************
                    'Get RMID for carbon, steel size
                    Dim GetRMIDStatement As String = "SELECT RMID FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey"
                    Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
                    GetRMIDCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = SteelReceiverNumber
                    GetRMIDCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = SteelReceiverLine

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetRMID = ""
                    End Try
                    con.Close()
                    '***********************************************************************************************************
                    'Get next line number
                    Dim GetLastLineNumber, GetNextLineNumber As Integer

                    Dim MAXStatement As String = "SELECT MAX(SteelReturnLine) FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber"
                    Dim MAXCommand As New SqlCommand(MAXStatement, con)
                    MAXCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetLastLineNumber = CInt(MAXCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetLastLineNumber = 0
                    End Try
                    con.Close()

                    GetNextLineNumber = GetLastLineNumber + 1
                    '***********************************************************************************************************
                    Try
                        'Insert in return line column
                        cmd = New SqlCommand("INSERT INTO SteelReturnLineTable (SteelReturnNumber, SteelReturnLine, RMID, ReturnQuantity, UnitCost, ExtendedCost, LineStatus, GLDebitAccount, GLCreditAccount, LineComment) Values (@SteelReturnNumber, @SteelReturnLine, @RMID, @ReturnQuantity, @UnitCost, @ExtendedCost, @LineStatus, @GLDebitAccount, @GLCreditAccount, @LineComment)", con)

                        With cmd.Parameters
                            .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
                            .Add("@SteelReturnLine", SqlDbType.VarChar).Value = GetNextLineNumber
                            .Add("@RMID", SqlDbType.VarChar).Value = GetRMID
                            .Add("@ReturnQuantity", SqlDbType.VarChar).Value = SteelCoilWeight
                            .Add("@UnitCost", SqlDbType.VarChar).Value = SteelUnitCost
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = SteelExtendedAmount
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "20995"
                            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12000"
                            .Add("@LineComment", SqlDbType.VarChar).Value = SteelHeatNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log

                    End Try
                    '***********************************************************************************************************
                    Try
                        'Insert into steel return coil lines
                        cmd = New SqlCommand("INSERT INTO SteelReturnCoilLines (SteelReturnNumber, SteelReturnLine, CoilID, CoilWeight, CoilCostPerPound, CoilExtendedCost, SteelPONumber, SteelPOLine, HeatNumber, SteelReceiverNumber, SteelReceiverLineNumber) Values (@SteelReturnNumber, @SteelReturnLine, @CoilID, @CoilWeight, @CoilCostPerPound, @CoilExtendedCost, @SteelPONumber, @SteelPOLine, @HeatNumber, @SteelReceiverNumber, @SteelReceiverLineNumber)", con)

                        With cmd.Parameters
                            .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
                            .Add("@SteelReturnLine", SqlDbType.VarChar).Value = GetNextLineNumber
                            .Add("@CoilID", SqlDbType.VarChar).Value = SteelCoilID
                            .Add("@CoilWeight", SqlDbType.VarChar).Value = SteelCoilWeight
                            .Add("@CoilCostPerPound", SqlDbType.VarChar).Value = SteelUnitCost
                            .Add("@CoilExtendedCost", SqlDbType.VarChar).Value = SteelExtendedAmount
                            .Add("@SteelPONumber", SqlDbType.VarChar).Value = SteelPONumber
                            .Add("@SteelPOLine", SqlDbType.VarChar).Value = SteelPOLine
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = SteelHeatNumber
                            .Add("@SteelReceiverNumber", SqlDbType.VarChar).Value = SteelReceiverNumber
                            .Add("@SteelReceiverLineNumber", SqlDbType.VarChar).Value = SteelReceiverLine
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log

                    End Try
                End If
            Next

            Me.Dispose()
            Me.Close()
        ElseIf GlobalSteelReturnFormType = "COIL LIST" Then
            Dim SteelCarbon, SteelSize As String
            Dim SteelCoilID, SteelHeatNumber As String
            Dim SteelCoilWeight, SteelUnitCost, SteelExtendedAmount As Double
            Dim GetRMID As String = ""
            Dim SteelPONumber As String = ""

            'Get data from each selected row
            For Each row As DataGridViewRow In dgvCoilListing.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectCoilsColumn2")

                If cell.Value = "SELECTED" Then
                    Try
                        SteelCoilID = row.Cells("CoilIDColumn2").Value
                    Catch ex As Exception
                        SteelCoilID = ""
                    End Try
                    Try
                        SteelHeatNumber = row.Cells("HeatNumberColumn2").Value
                    Catch ex As Exception
                        SteelHeatNumber = ""
                    End Try
                    Try
                        SteelCarbon = row.Cells("CarbonColumn2").Value
                    Catch ex As Exception
                        SteelCarbon = ""
                    End Try
                    Try
                        SteelSize = row.Cells("SteelSizeColumn2").Value
                    Catch ex As Exception
                        SteelSize = ""
                    End Try
                    Try
                        SteelCoilWeight = row.Cells("WeightColumn2").Value
                    Catch ex As Exception
                        SteelCoilWeight = 0
                    End Try
                    Try
                        SteelPONumber = row.Cells("PurchaseOrderNumberColumn2").Value
                    Catch ex As Exception
                        SteelPONumber = ""
                    End Try
                    '***********************************************************************************************************
                    'Get RMID for carbon, steel size
                    Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
                    Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
                    GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelCarbon
                    GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetRMID = ""
                    End Try
                    con.Close()
                    '************************************************************************************
                    'Get Steel Cost
                    Dim GetMaxUsage As Double = 0

                    Dim GetUsageStatement As String = "SELECT SUM(UsageWeight) FROM SteelUsageTable WHERE RMID = @RMID"
                    Dim GetUsageCommand As New SqlCommand(GetUsageStatement, con)
                    GetUsageCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMaxUsage = CDbl(GetUsageCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMaxUsage = 0
                    End Try
                    con.Close()

                    Dim GetSteelCostStatement As String = "SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND @SteelUsage BETWEEN LowerLimit AND UpperLimit"
                    Dim GetSteelCostCommand As New SqlCommand(GetSteelCostStatement, con)
                    GetSteelCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID
                    GetSteelCostCommand.Parameters.Add("@SteelUsage", SqlDbType.VarChar).Value = GetMaxUsage

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SteelUnitCost = CDbl(GetSteelCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        SteelUnitCost = 0
                    End Try
                    con.Close()

                    If SteelUnitCost = 0 Then
                        'Get Steel Cost
                        Dim GetMaxTransactionNumber As Integer = 0

                        Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM SteelTransactionTable WHERE RMID = @RMID"
                        Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                        GetMaxTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetMaxTransactionNumber = 0
                        End Try
                        con.Close()

                        Dim GetLastCostStatement As String = "SELECT SteelCost FROM SteelTransactionTable WHERE TransactionNumber = @TransactionNumber"
                        Dim GetLastCostCommand As New SqlCommand(GetLastCostStatement, con)
                        GetLastCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber
   
                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SteelUnitCost = CDbl(GetLastCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            SteelUnitCost = 0
                        End Try
                        con.Close()
                    End If

                    SteelUnitCost = Math.Round(SteelUnitCost, 4)
                    SteelExtendedAmount = SteelUnitCost * SteelCoilWeight
                    SteelExtendedAmount = Math.Round(SteelExtendedAmount, 2)
                    '***********************************************************************************************************
                    'Get next line number
                    Dim GetLastLineNumber, GetNextLineNumber As Integer

                    Dim MAXStatement As String = "SELECT MAX(SteelReturnLine) FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber"
                    Dim MAXCommand As New SqlCommand(MAXStatement, con)
                    MAXCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetLastLineNumber = CInt(MAXCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetLastLineNumber = 0
                    End Try
                    con.Close()

                    GetNextLineNumber = GetLastLineNumber + 1
                    '***********************************************************************************************************
                    Try
                        'Insert in return line column
                        cmd = New SqlCommand("INSERT INTO SteelReturnLineTable (SteelReturnNumber, SteelReturnLine, RMID, ReturnQuantity, UnitCost, ExtendedCost, LineStatus, GLDebitAccount, GLCreditAccount, LineComment) Values (@SteelReturnNumber, @SteelReturnLine, @RMID, @ReturnQuantity, @UnitCost, @ExtendedCost, @LineStatus, @GLDebitAccount, @GLCreditAccount, @LineComment)", con)

                        With cmd.Parameters
                            .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
                            .Add("@SteelReturnLine", SqlDbType.VarChar).Value = GetNextLineNumber
                            .Add("@RMID", SqlDbType.VarChar).Value = GetRMID
                            .Add("@ReturnQuantity", SqlDbType.VarChar).Value = SteelCoilWeight
                            .Add("@UnitCost", SqlDbType.VarChar).Value = SteelUnitCost
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = SteelExtendedAmount
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "20995"
                            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "12000"
                            .Add("@LineComment", SqlDbType.VarChar).Value = SteelHeatNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log

                    End Try
                    '***********************************************************************************************************
                    Try
                        'Insert into steel return coil lines
                        cmd = New SqlCommand("INSERT INTO SteelReturnCoilLines (SteelReturnNumber, SteelReturnLine, CoilID, CoilWeight, CoilCostPerPound, CoilExtendedCost, SteelPONumber, SteelPOLine, HeatNumber, SteelReceiverNumber, SteelReceiverLineNumber) Values (@SteelReturnNumber, @SteelReturnLine, @CoilID, @CoilWeight, @CoilCostPerPound, @CoilExtendedCost, @SteelPONumber, @SteelPOLine, @HeatNumber, @SteelReceiverNumber, @SteelReceiverLineNumber)", con)

                        With cmd.Parameters
                            .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
                            .Add("@SteelReturnLine", SqlDbType.VarChar).Value = GetNextLineNumber
                            .Add("@CoilID", SqlDbType.VarChar).Value = SteelCoilID
                            .Add("@CoilWeight", SqlDbType.VarChar).Value = SteelCoilWeight
                            .Add("@CoilCostPerPound", SqlDbType.VarChar).Value = SteelUnitCost
                            .Add("@CoilExtendedCost", SqlDbType.VarChar).Value = SteelExtendedAmount
                            .Add("@SteelPONumber", SqlDbType.VarChar).Value = SteelPONumber
                            .Add("@SteelPOLine", SqlDbType.VarChar).Value = 0
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = SteelHeatNumber
                            .Add("@SteelReceiverNumber", SqlDbType.VarChar).Value = 0
                            .Add("@SteelReceiverLineNumber", SqlDbType.VarChar).Value = 0
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log

                    End Try
                End If
            Next

            Me.Dispose()
            Me.Close()
        Else
            'Error Log
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalSteelReturnFormType = ""
        GlobalSteelReturnCarbon = ""
        GlobalSteelReturnPONumber = 0
        GlobalSteelReturnSize = ""
        GlobalSteelReturnNumber = 0

        Me.Dispose()
        Me.Close()
    End Sub
End Class