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
Imports System.Runtime.InteropServices
Public Class ShippingUpdaterRacking
    Inherits System.Windows.Forms.Form

    Dim PickListLineNumber As Integer = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Async=True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable

    Private Sub ShippingUpdaterRacking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowPickLines()
        lblPickTicketNumber.Text = GlobalPickListNumber
        lblPartNumber.Text = ""
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment.Substring(0, 200)
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ShowPickLines()
        cmd = New SqlCommand("SELECT * FROM PickListPulledLines WHERE PickListHeaderKey = @PickListHeaderKey", con)
        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PickListPulledLines")
        dgvPickPulledLines.DataSource = ds.Tables("PickListPulledLines")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        Dim PartNumber As String = ""

        Dim PartNumberStatement As String = "SELECT ItemID FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey"
        Dim PartNumberCommand As New SqlCommand(PartNumberStatement, con)
        PartNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber
        PartNumberCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = PickListLineNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber = CStr(PartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            PartNumber = ""
        End Try
        con.Close()

        lblPartNumber.Text = PartNumber
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvPickPulledLines_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPickPulledLines.CellClick
        If dgvPickPulledLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPickPulledLines.CurrentCell.RowIndex

            PickListLineNumber = Me.dgvPickPulledLines.Rows(RowIndex).Cells("PickListLineKeyColumn").Value

            LoadPartNumber()
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvPickPulledLines_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPickPulledLines.CellContentClick
        If dgvPickPulledLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPickPulledLines.CurrentCell.RowIndex

            PickListLineNumber = Me.dgvPickPulledLines.Rows(RowIndex).Cells("PickListLineKeyColumn").Value

            LoadPartNumber()
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvPickPulledLines_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPickPulledLines.CellMouseClick
        If dgvPickPulledLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPickPulledLines.CurrentCell.RowIndex

            PickListLineNumber = Me.dgvPickPulledLines.Rows(RowIndex).Cells("PickListLineKeyColumn").Value

            LoadPartNumber()
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvPickPulledLines_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPickPulledLines.RowHeaderMouseClick
        If dgvPickPulledLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPickPulledLines.CurrentCell.RowIndex

            PickListLineNumber = Me.dgvPickPulledLines.Rows(RowIndex).Cells("PickListLineKeyColumn").Value

            LoadPartNumber()
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub cmdAddBackToRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddBackToRack.Click
        If dgvPickPulledLines.RowCount <> 0 Then
            Dim RowRackingKey As Integer = 0
            Dim RowBinNumber As String = ""
            Dim RowHeatNumber As String = ""
            Dim RowLotNumber As String = ""
            Dim RowBoxQuantity As Integer = 0
            Dim RowPiecesPerBox As Integer = 0
            Dim RowTotalPieces As Integer = 0
            Dim RowRackingWeight As Double = 0
            Dim RowPartNumber As String = ""
            Dim RowPartDescription As String = ""
            Dim RowPickListLineKey As Integer = 0
            Dim RowShipmentNumber As Integer = 0
            Dim RowLineKey As Integer = 0
            Dim RowHeatQuantity As Integer = 0

            Dim RowIndex As Integer = Me.dgvPickPulledLines.CurrentCell.RowIndex

            RowRackingKey = Me.dgvPickPulledLines.Rows(RowIndex).Cells("RackingKeyColumn").Value
            RowBinNumber = Me.dgvPickPulledLines.Rows(RowIndex).Cells("BinNumberColumn").Value
            RowHeatNumber = Me.dgvPickPulledLines.Rows(RowIndex).Cells("HeatNumberColumn").Value
            RowLotNumber = Me.dgvPickPulledLines.Rows(RowIndex).Cells("LotNumberColumn").Value
            RowBoxQuantity = Me.dgvPickPulledLines.Rows(RowIndex).Cells("BoxQuantityColumn").Value
            RowPiecesPerBox = Me.dgvPickPulledLines.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
            RowTotalPieces = Me.dgvPickPulledLines.Rows(RowIndex).Cells("TotalPiecesColumn").Value
            RowRackingWeight = Me.dgvPickPulledLines.Rows(RowIndex).Cells("RackingWeightColumn").Value
            RowPickListLineKey = Me.dgvPickPulledLines.Rows(RowIndex).Cells("PickListLineKeyColumn").Value
            RowLineKey = Me.dgvPickPulledLines.Rows(RowIndex).Cells("LineKeyColumn").Value
            '**************************************************************************************************
            'Check Rack to see if it is empty
            Dim CheckBinNumber As Integer = 0

            Dim CheckBinNumberStatement As String = "SELECT COUNT(RackingKey) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
            Dim CheckBinNumberCommand As New SqlCommand(CheckBinNumberStatement, con)
            CheckBinNumberCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
            CheckBinNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckBinNumber = CInt(CheckBinNumberCommand.ExecuteScalar)
            Catch ex As Exception
                CheckBinNumber = 0
            End Try
            con.Close()

            If CheckBinNumber = 0 Then
                'Do nothing, proceed
            Else
                Dim button As DialogResult = MessageBox.Show("This rack is not empty. Would you like to add to this rack?", "ADD TO RACK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Continue
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            End If
            '***************************************************************************************************
            'Get Part Number, Description, Shipment Number, Shipment Line
            Dim PartNumberStatement As String = "SELECT ItemID FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey"
            Dim PartNumberCommand As New SqlCommand(PartNumberStatement, con)
            PartNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber
            PartNumberCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = RowPickListLineKey

            Dim PartDescriptionStatement As String = "SELECT Description FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey"
            Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
            PartDescriptionCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber
            PartDescriptionCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = RowPickListLineKey

            Dim ShipmentNumberStatement As String = "SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber AND DivisionID = @DivisionID"
            Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)
            ShipmentNumberCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = GlobalPickListNumber
            ShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                RowPartNumber = CStr(PartNumberCommand.ExecuteScalar)
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowPartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
            Catch ex As Exception
                RowPartDescription = ""
            End Try
            Try
                RowShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                RowShipmentNumber = 0
            End Try
            con.Close()
            '**************************************************************************************************
            'Update Shipment Line Lot Numbers

            Dim HeatQuantityStatement As String = "SELECT HeatQuantity FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber"
            Dim HeatQuantityCommand As New SqlCommand(HeatQuantityStatement, con)
            HeatQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
            HeatQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowPickListLineKey
            HeatQuantityCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                RowHeatQuantity = CInt(HeatQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                RowHeatQuantity = 0
            End Try
            con.Close()
            '**************************************************************************************************
            If RowHeatQuantity = RowTotalPieces Then 'Delete line in shipment line lot numbers
                Try
                    cmd = New SqlCommand("DELETE FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowPickListLineKey
                        .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log Error
                End Try
            ElseIf RowHeatQuantity > RowTotalPieces Then 'Update shipment line lot numbers to new quantity
                Try
                    cmd = New SqlCommand("UPDATE ShipmentLineLotNumbers SET HeatQuantity = @HeatQuantity WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowPickListLineKey
                        .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                        .Add("@HeatQuantity", SqlDbType.VarChar).Value = RowHeatQuantity - RowTotalPieces
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log Error
                End Try
            Else
                'Skip and log error

            End If
            '**************************************************************************************************
            'Delete Line fron Pick List Pulled Lines
            Try
                'Update Item List with new Standard Cost and Price
                cmd = New SqlCommand("DELETE FROM PickListPulledLines WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey AND LineKey = @LineKey", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber
                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = RowPickListLineKey
                    .Add("@LineKey", SqlDbType.VarChar).Value = RowLineKey
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log Error
            End Try
              '**************************************************************************************************
            'Get new Racking Key
            Dim NewRackingKey As Integer = 0

            Dim GetRackingKeyStatement As String = "SELECT MAX(RackingKey) FROM RackingTransactionTable"
            Dim GetRackingKeyCommand As New SqlCommand(GetRackingKeyStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                NewRackingKey = CInt(GetRackingKeyCommand.ExecuteScalar)
            Catch ex As Exception
                NewRackingKey = 0
            End Try
            con.Close()
            '**************************************************************************************************
            'Update Racking Transaction Table
            Try
                cmd = New SqlCommand("INSERT INTO RackingTransactionTable (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, ActivityDate, DivisionID, CreationDate, PickTicket, PickDate, AddedBy, Comment) values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @ActivityDate, @DivisionID, @CreationDate, @PickTicket, @PickDate, @AddedBy, @Comment)", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = NewRackingKey + 1
                    .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = RowPartDescription
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = RowBoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = RowPiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = RowRackingWeight
                    .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                    .Add("@PickTicket", SqlDbType.VarChar).Value = GlobalPickListNumber
                    .Add("@PickDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@Comment", SqlDbType.VarChar).Value = ""
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempPickNumber As Integer = 0
                Dim strPickNumber As String
                TempPickNumber = GlobalPickListNumber
                strPickNumber = CStr(TempPickNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "Shipping Updater - Add Back Into Rack"
                ErrorReferenceNumber = "PT # " + strPickNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************
            Try
                'Update Line
                cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = NewRackingKey + 1
                    .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = RowPartDescription
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = RowBoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = RowPiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = RowRackingWeight
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                Dim TempPickNumber As Integer = 0
                Dim strPickNumber As String
                TempPickNumber = GlobalPickListNumber
                strPickNumber = CStr(TempPickNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "Shipping Updater - Add Back Into Rack Master List"
                ErrorReferenceNumber = "PT # " + strPickNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************
            'Get Time and Date
            Dim TodaysDate As Date = Now()
            Dim intHours, intMinutes, intSeconds As Integer
            Dim strHours, strMinutes, strSeconds As String
            Dim RackTime As String = ""
            Dim RackDate As String = ""

            intHours = TodaysDate.Hour
            intMinutes = TodaysDate.Minute
            intSeconds = TodaysDate.Second

            strHours = CStr(intHours)
            strMinutes = CStr(intMinutes)
            strSeconds = CStr(intSeconds)

            RackTime = strHours + ":" + strMinutes + ":" + strSeconds
            RackDate = TodaysDate.ToString()

            Try
                'Update Racking Activity Log
                cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate) Values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate)", con)

                With cmd.Parameters
                    .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                    .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                    .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = 0
                    .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                    .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = RowTotalPieces
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "ADDED"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = GlobalPickListNumber
                    .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                    .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempPickNumber As Integer = 0
                Dim strPickNumber As String
                TempPickNumber = GlobalPickListNumber
                strPickNumber = CStr(TempPickNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "Shipping Updater - Add Back Into Rack"
                ErrorReferenceNumber = "PT # " + strPickNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************
            'Refresh Datagrid
            ShowPickLines()

            'Clear Variables
            PickListLineNumber = 0
        Else
            'Do Nothing
        End If
    End Sub
End Class