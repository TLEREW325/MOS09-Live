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
Public Class LiftTruckRacking
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Racking Log Variables
    Dim LogActivityDateTime As DateTime
    Dim LogPickTicketNumber, LogBinNumber, LogPartNumber, LogLotNumber, LogHeatNumber, LogTransactionType, LogUserID As String
    Dim LogOriginalTotalPieces, LogCurrentTotalPieces, LogTotalPiecesDifference As Integer
    Dim LogOrderNumber As String = ""
    Dim DivisionFilter As String = ""

    Dim TotalPiecesToAdd As Integer = 0
    Dim TotalWeightToAdd As Double = 0
    Dim PieceWeight As Double = 0
    Dim RackingKey As Integer = 0
    Dim ControlFocus As String = ""
    Dim FieldLength As Integer = 0
    Dim EditedField As String = ""
    Dim CurrentField As String = ""
    Dim DatagridViewRackingKey As Integer = 0
    Dim DatagridviewRackFieldToEdit As String = ""
    Dim RackingColumnIndex As Integer = 0
    Dim RackingRowIndex As Integer = 0

    'Load Datasets

    Private Sub LiftTruckRacking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gpxLookupByRack.Visible = False
        gpxLookupByPart.Visible = False
        gpxAddToRack.Visible = False
        gpxLookupByOrder.Visible = False

        If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Or EmployeeCompanyCode = "ADM" Then
            DivisionFilter = " AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
            GlobalDivisionCode = EmployeeCompanyCode
        Else
            DivisionFilter = " AND DivisionID = '" + EmployeeCompanyCode + "'"
            GlobalDivisionCode = EmployeeCompanyCode
        End If
    End Sub

    Private Sub LoadOrderLines()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT * FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey" + DivisionFilter + " ORDER BY PickListLineKey", con)
        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtOrderNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "PickListLineTable")
        dgvOrderLines.DataSource = ds3.Tables("PickListLineTable")
        con.Close()
        dgvOrderLines.RowTemplate.Height = 50
    End Sub

    Private Sub LoadRacksByRackNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE BinNumber = @BinNumber" + DivisionFilter + " ORDER BY BoxQuantity, PartNumber", con)
        cmd.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = txtRackNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RackingTransactionTable")
        dgvRackLookup.DataSource = ds.Tables("RackingTransactionTable")
        con.Close()
        dgvRackLookup.RowTemplate.Height = 50
    End Sub

    Private Sub LoadRacksByPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE PartNumber = @PartNumber" + DivisionFilter + " ORDER BY BoxQuantity, BinNumber", con)
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberLookup.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RackingTransactionTable")
        dgvPartLookup.DataSource = ds1.Tables("RackingTransactionTable")
        con.Close()
        dgvPartLookup.RowTemplate.Height = 50
    End Sub

    'Clear command and error checking, validation

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 399 Then
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ClearAllDatagrids()
        dgvPartLookup.DataSource = Nothing
        dgvRackLookup.DataSource = Nothing
        dgvOrderLines.DataSource = Nothing
        dgvRackingByOrder.DataSource = Nothing
    End Sub

    Public Sub ClearInputFields()
        txtPartNumberLookup.Clear()
        txtRackNumber.Clear()
        txtTotalPiecesInRack.Clear()
        txtQOH.Clear()
        txtAddBinNumber.Clear()
        txtLotNumber.Clear()
        txtNumberOfBoxes.Clear()
        txtNumberOfPieces.Clear()
        txtPartNumber.Clear()
        txtTotalPieces.Clear()
        txtTotalWeight.Clear()
        txtOrderNumber.Clear()

        txtUpdateDatagrid.Clear()

        ControlFocus = ""
    End Sub

    Public Sub ClearVariables()
        LogBinNumber = ""
        LogPartNumber = ""
        LogLotNumber = ""
        LogHeatNumber = ""
        LogTransactionType = ""
        LogUserID = ""
        LogOriginalTotalPieces = 0
        LogCurrentTotalPieces = 0
        LogTotalPiecesDifference = 0
        TotalPiecesToAdd = 0
        TotalWeightToAdd = 0
        PieceWeight = 0
        RackingKey = 0
        ControlFocus = ""
        FieldLength = 0
        EditedField = ""
        CurrentField = ""
        DatagridViewRackingKey = 0
        DatagridviewRackFieldToEdit = ""
        RackingColumnIndex = 0
        RackingRowIndex = 0
        DivisionFilter = ""
    End Sub

    'Load data

    Private Sub LoadRackTotalByPart()
        'Get Part Total
        Dim PartTotal As Double = 0

        Dim PartTotalStatement As String = "SELECT SUM(TotalPieces) FROM RackingTransactionTable WHERE PartNumber = @PartNumber" + DivisionFilter
        Dim PartTotalCommand As New SqlCommand(PartTotalStatement, con)
        PartTotalCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberLookup.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartTotal = CDbl(PartTotalCommand.ExecuteScalar)
        Catch ex As Exception
            PartTotal = 0
        End Try
        con.Close()

        txtTotalPiecesInRack.Text = PartTotal
    End Sub

    Private Sub LoadQuantityOnHand()
        'Get Part Total
        Dim QOH As Double = 0

        Dim QuantityOnHandStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID" + DivisionFilter
        Dim QuantityOnHandCommand As New SqlCommand(QuantityOnHandStatement, con)
        QuantityOnHandCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumberLookup.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QOH = CDbl(QuantityOnHandCommand.ExecuteScalar)
        Catch ex As Exception
            QOH = 0
        End Try
        con.Close()

        txtQOH.Text = QOH
    End Sub

    Public Sub LoadLotNumberData()
        Dim HeatNumber As String = ""
        Dim BoxCount As Integer = 0
        Dim PartNumber As String = ""
        Dim PartDescription As String = ""

        Dim GetLotDataStatement As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetLotDataCommand As New SqlCommand(GetLotDataStatement, con)
        GetLotDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetLotDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                PartDescription = ""
            Else
                PartDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = ""
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                PieceWeight = 0
            Else
                PieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                BoxCount = 0
            Else
                BoxCount = reader.Item("BoxCount")
            End If
        Else
            HeatNumber = ""
            PieceWeight = 0
            BoxCount = 0
            PartDescription = ""
            PartNumber = ""
        End If
        reader.Close()
        con.Close()

        txtPartNumber.Text = PartNumber
        txtNumberOfPieces.Text = BoxCount
        txtHeatNumber.Text = HeatNumber
        txtPartDescription.Text = PartDescription
    End Sub

    Public Sub LoadPartNumberData()
        Dim PNBoxCount As Integer = 0
        Dim PNPartNumber As String = ""
        Dim PNPartDescription As String = ""

        Dim GetPartDataStatement As String = "SELECT * FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
        Dim GetPartDataCommand As New SqlCommand(GetPartDataStatement, con)
        GetPartDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPartDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ItemID")) Then
                PNPartNumber = ""
            Else
                PNPartNumber = reader.Item("ItemID")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                PNPartDescription = ""
            Else
                PNPartDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                PieceWeight = 0
            Else
                PieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                PNBoxCount = 0
            Else
                PNBoxCount = reader.Item("BoxCount")
            End If
        Else
            PieceWeight = 0
            PNBoxCount = 0
            PNPartDescription = ""
            PNPartNumber = ""
        End If
        reader.Close()
        con.Close()

        txtNumberOfPieces.Text = PNBoxCount
        txtPartDescription.Text = PNPartDescription
    End Sub

    'Command buttons

    Private Sub cmdLookupByRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLookupByRack.Click
        ClearAllDatagrids()
        ClearInputFields()

        gpxLookupByRack.Visible = True
        gpxLookupByPart.Visible = False
        gpxAddToRack.Visible = False
        gpxLookupByOrder.Visible = False

        txtRackNumber.Focus()
    End Sub

    Private Sub cmdLookupByOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLookupByOrder.Click
        ClearAllDatagrids()
        ClearInputFields()

        gpxLookupByPart.Visible = False
        gpxLookupByRack.Visible = False
        gpxAddToRack.Visible = False
        gpxLookupByOrder.Visible = True

        txtOrderNumber.Focus()
    End Sub

    Private Sub cmdLookupByPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLookupByPart.Click
        ClearAllDatagrids()
        ClearInputFields()

        gpxLookupByPart.Visible = True
        gpxLookupByRack.Visible = False
        gpxAddToRack.Visible = False
        gpxLookupByOrder.Visible = False

        txtPartNumberLookup.Focus()
    End Sub

    Private Sub cmdAddToRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToRack.Click
        ClearAllDatagrids()
        ClearInputFields()

        gpxLookupByPart.Visible = False
        gpxLookupByRack.Visible = False
        gpxAddToRack.Visible = True
        gpxLookupByOrder.Visible = False

        txtLotNumber.Focus()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearAllDatagrids()
        ClearInputFields()

        gpxLookupByPart.Visible = False
        gpxLookupByRack.Visible = False
        gpxAddToRack.Visible = False
        gpxLookupByOrder.Visible = False
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        Dim LineRackingKey As Integer = 0
        Dim LineBinNumber As String = ""
        Dim LinePartNumber As String = ""
        Dim LineHeatNumber As String = ""
        Dim LineLotNumber As String = ""
        Dim LineTotalPieces As Integer = 0

        If Me.dgvRackLookup.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvRackLookup.CurrentCell.RowIndex

            Try
                LineRackingKey = Me.dgvRackLookup.Rows(RowIndex).Cells("RackingKeyColumn").Value
            Catch ex As Exception
                LineRackingKey = 0
            End Try
            Try
                LineBinNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("BinNumberColumn").Value
            Catch ex As Exception
                LineBinNumber = ""
            End Try
            Try
                LinePartNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                LinePartNumber = 0
            End Try
            Try
                LineHeatNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("HeatNumberColumn").Value
            Catch ex As Exception
                LineHeatNumber = ""
            End Try
            Try
                LineLotNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("LotNumberColumn").Value
            Catch ex As Exception
                LineLotNumber = ""
            End Try
            Try
                LineTotalPieces = Me.dgvRackLookup.Rows(RowIndex).Cells("TotalPiecesColumn").Value
            Catch ex As Exception
                LineTotalPieces = 0
            End Try
            '***************************************************************************************************
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this selected line?", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '***********************************************************************************************
                'Log Rack Activity
                'Fill Log Variables
                LogHeatNumber = LineHeatNumber
                LogActivityDateTime = Now()
                LogCurrentTotalPieces = 0
                LogBinNumber = LineBinNumber
                LogLotNumber = LineLotNumber
                LogPartNumber = LinePartNumber
                LogTotalPiecesDifference = LineTotalPieces * -1
                LogOriginalTotalPieces = LineTotalPieces
                LogTransactionType = "DELETED"
                LogUserID = EmployeeLoginName
                LogPickTicketNumber = ""

                InsertIntoRackingLog()
                '***********************************************************************************************
                'Create command to delete selected line
                cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                With cmd.Parameters
                    .Add("@BinNumber", SqlDbType.VarChar).Value = LineBinNumber
                    .Add("@RackingKey", SqlDbType.VarChar).Value = LineRackingKey
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                LoadRacksByRackNumber()
            ElseIf button = DialogResult.No Then
                txtRackNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cmdDeletedLinePart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeletedLinePart.Click
        Dim LineRackingKey As Integer = 0
        Dim LineBinNumber As String = ""
        Dim LinePartNumber As String = ""
        Dim LineHeatNumber As String = ""
        Dim LineLotNumber As String = ""
        Dim LineTotalPieces As Integer = 0

        If Me.dgvPartLookup.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvPartLookup.CurrentCell.RowIndex

            Try
                LineRackingKey = Me.dgvPartLookup.Rows(RowIndex).Cells("RackingKeyColumn1").Value
            Catch ex As Exception
                LineRackingKey = 0
            End Try
            Try
                LineBinNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("BinNumberColumn1").Value
            Catch ex As Exception
                LineBinNumber = ""
            End Try
            Try
                LinePartNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("PartNumberColumn1").Value
            Catch ex As Exception
                LinePartNumber = 0
            End Try
            Try
                LineHeatNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("HeatNumberColumn1").Value
            Catch ex As Exception
                LineHeatNumber = ""
            End Try
            Try
                LineLotNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("LotNumberColumn1").Value
            Catch ex As Exception
                LineLotNumber = ""
            End Try
            Try
                LineTotalPieces = Me.dgvPartLookup.Rows(RowIndex).Cells("TotalPiecesColumn1").Value
            Catch ex As Exception
                LineTotalPieces = 0
            End Try

            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this selected line?", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    'Create command to delete selected line
                    cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                    With cmd.Parameters
                        .Add("@BinNumber", SqlDbType.VarChar).Value = LineBinNumber
                        .Add("@RackingKey", SqlDbType.VarChar).Value = LineRackingKey
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************************
                    'Log Rack Activity
                    'Fill Log Variables
                    LogHeatNumber = LineHeatNumber
                    LogActivityDateTime = Now()
                    LogCurrentTotalPieces = 0
                    LogBinNumber = LineBinNumber
                    LogLotNumber = LineLotNumber
                    LogPartNumber = LinePartNumber
                    LogTotalPiecesDifference = LineTotalPieces * -1
                    LogOriginalTotalPieces = LineTotalPieces
                    LogTransactionType = "DELETED"
                    LogUserID = EmployeeLoginName
                    LogPickTicketNumber = ""

                    InsertIntoRackingLog()
                    '***********************************************************************************************
                    'Reload datagrid
                    LoadRacksByPartNumber()
                Catch ex As Exception
                    'Error Log
                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Lift Truck Racking - Add to Master List - changes in datagrid"
                    ErrorReferenceNumber = "Bin # " + LineBinNumber + ", Part # - " + LinePartNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            ElseIf button = DialogResult.No Then
                txtRackNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cmdDeleteRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRack.Click
        If txtRackNumber.Text = "" Then
            MsgBox("You must select a valid rack number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim button As DialogResult = MessageBox.Show("Do you wish to delete the entire rack contents?", "DELETE ENTIRE RACK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Load Rack Data
            For Each row As DataGridViewRow In dgvRackLookup.Rows
                Try
                    LogBinNumber = row.Cells("BinNumberColumn").Value
                Catch ex As System.Exception
                    LogBinNumber = ""
                End Try
                Try
                    LogCurrentTotalPieces = row.Cells("TotalPiecesColumn").Value
                Catch ex As System.Exception
                    LogCurrentTotalPieces = 0
                End Try
                Try
                    LogHeatNumber = row.Cells("HeatNumberColumn").Value
                Catch ex As System.Exception
                    LogHeatNumber = ""
                End Try
                Try
                    LogLotNumber = row.Cells("LotNumberColumn").Value
                Catch ex As System.Exception
                    LogLotNumber = ""
                End Try
                Try
                    LogPartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As System.Exception
                    LogPartNumber = ""
                End Try

                If LogBinNumber = txtRackNumber.Text Then
                    'Log Rack Activity
                    'Fill Log Variables
                    LogActivityDateTime = Now()
                    LogCurrentTotalPieces = 0
                    LogTotalPiecesDifference = LogOriginalTotalPieces * -1
                    LogTransactionType = "DELETED"
                    LogUserID = EmployeeLoginName
                    LogPickTicketNumber = ""

                    InsertIntoRackingLog()
                End If

                'Clear Log Variables
                LogBinNumber = ""
                LogPartNumber = ""
                LogLotNumber = ""
                LogHeatNumber = ""
                LogTransactionType = ""
                LogUserID = ""
                LogOriginalTotalPieces = 0
                LogCurrentTotalPieces = 0
                LogTotalPiecesDifference = 0
            Next
            '***********************************************************************************************
            'Create command to delete entire rack
            cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE BinNumber = @BinNumber", con)

            With cmd.Parameters
                .Add("@BinNumber", SqlDbType.VarChar).Value = txtRackNumber.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadRacksByRackNumber()
        ElseIf button = DialogResult.No Then
            txtRackNumber.Focus()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAddToRackEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToRackEntry.Click
        If txtPartNumber.Text = "" Then
            MsgBox("You must have a valid part number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtAddBinNumber.Text = "" Then
            MsgBox("You must have a valid rack.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtNumberOfBoxes.Text = "" Or Val(txtNumberOfBoxes.Text) = 0 Then
            MsgBox("You must enter a box count.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtNumberOfPieces.Text = "" Or Val(txtNumberOfPieces.Text) = 0 Then
            MsgBox("You must enter a piece count.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '**************************************************************************************
        'Validate Part, Lot, and Rack
        Dim CheckPartNumber As Integer = 0
        Dim CheckLotNumber As Integer = 0
        Dim CheckRackNumber As Integer = 0

        Dim CheckPartNumberStatement As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
        Dim CheckPartNumberCommand As New SqlCommand(CheckPartNumberStatement, con)
        CheckPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text

        Dim CheckLotNumberStatement As String = "SELECT COUNT(LotNumber) FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim CheckLotNumberCommand As New SqlCommand(CheckLotNumberStatement, con)
        CheckLotNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        Dim CheckRackNumberStatement As String = "SELECT COUNT(BinNumber) FROM BinNumber WHERE BinNumber = @BinNumber"
        Dim CheckRackNumberCommand As New SqlCommand(CheckRackNumberStatement, con)
        CheckRackNumberCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = txtAddBinNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPartNumber = CInt(CheckPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPartNumber = 0
        End Try
        Try
            CheckLotNumber = CInt(CheckLotNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckLotNumber = 0
        End Try
        Try
            CheckRackNumber = CInt(CheckRackNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckRackNumber = 0
        End Try
        con.Close()

        If CheckPartNumber = 0 Then
            MsgBox("Part Number does not exist.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If CheckLotNumber = 0 And txtLotNumber.Text <> "" Then
            MsgBox("Lot Number does not exist.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If CheckRackNumber = 0 Then
            MsgBox("Rack Number does not exist.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '**************************************************************************************
        Dim LastRackingKey As Integer = 0
        Dim NextRackingKey As Integer = 0

        Dim LastRackingKeyStatement As String = "SELECT MAX(RackingKey) FROM RackingTransactionTable"
        Dim LastRackingKeyCommand As New SqlCommand(LastRackingKeyStatement, con)
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastRackingKey = CInt(LastRackingKeyCommand.ExecuteScalar)
        Catch ex As Exception
            LastRackingKey = 0
        End Try
        con.Close()

        NextRackingKey = LastRackingKey + 1
        '****************************************************************************************
        Try
            'Create command to delete selected line
            cmd = New SqlCommand("INSERT INTO RackingTransactionTable (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, ActivityDate, DivisionID, CreationDate, PickTicket, PickDate, AddedBy) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @ActivityDate, @DivisionID, @CreationDate, @PickTicket, @PickDate, @AddedBy)", con)

            With cmd.Parameters
                .Add("@RackingKey", SqlDbType.VarChar).Value = NextRackingKey
                .Add("@BinNumber", SqlDbType.VarChar).Value = txtAddBinNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = txtPartDescription.Text
                .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                .Add("@BoxQuantity", SqlDbType.VarChar).Value = Val(txtNumberOfBoxes.Text)
                .Add("@PiecesPerBox", SqlDbType.VarChar).Value = Val(txtNumberOfPieces.Text)
                .Add("@TotalPieces", SqlDbType.VarChar).Value = Val(txtTotalPieces.Text)
                .Add("@RackingWeight", SqlDbType.VarChar).Value = Val(txtTotalWeight.Text)
                .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                .Add("@PickTicket", SqlDbType.VarChar).Value = 0
                .Add("@PickDate", SqlDbType.VarChar).Value = ""
                .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*********************************************************************************************************
            'Create command to delete selected line
            cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

            With cmd.Parameters
                .Add("@RackingKey", SqlDbType.VarChar).Value = NextRackingKey
                .Add("@BinNumber", SqlDbType.VarChar).Value = txtAddBinNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = txtPartDescription.Text
                .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                .Add("@BoxQuantity", SqlDbType.VarChar).Value = Val(txtNumberOfBoxes.Text)
                .Add("@PiecesPerBox", SqlDbType.VarChar).Value = Val(txtNumberOfPieces.Text)
                .Add("@TotalPieces", SqlDbType.VarChar).Value = Val(txtTotalPieces.Text)
                .Add("@RackingWeight", SqlDbType.VarChar).Value = Val(txtTotalWeight.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************************************************************************
            'Update Rack Activity Log
            'Fill Log Variables
            LogHeatNumber = txtHeatNumber.Text
            LogActivityDateTime = Now()
            LogCurrentTotalPieces = Val(txtTotalPieces.Text)
            LogBinNumber = txtAddBinNumber.Text
            LogLotNumber = txtLotNumber.Text
            LogPartNumber = txtPartNumber.Text
            LogTotalPiecesDifference = Val(txtTotalPieces.Text)
            LogOriginalTotalPieces = 0
            LogTransactionType = "CREATED"
            LogUserID = EmployeeLoginName
            LogPickTicketNumber = ""

            'If no change in pieces, skip activity log
            If LogTotalPiecesDifference = 0 Then
                'Skip
            Else
                InsertIntoRackingLog()
            End If
            '********************************************************************************************************
            'Clear fields
            MsgBox("Part Added.", MsgBoxStyle.OkOnly)
            txtLotNumber.Clear()
            txtHeatNumber.Clear()
            txtPartNumber.Clear()
            txtPartDescription.Clear()
            txtNumberOfBoxes.Clear()
            txtNumberOfPieces.Clear()
            txtTotalPieces.Clear()
            txtTotalWeight.Clear()
            txtAddBinNumber.Clear()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = EmployeeCompanyCode
            ErrorDescription = "Lift Truck Racking - Add to Rack Button"
            ErrorReferenceNumber = "Bin # " + txtAddBinNumber.Text + ", Part # - " + txtPartNumber.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub cmdRemoveFromSelectedRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromSelectedRack.Click
        If Me.dgvPartLookup.RowCount = 0 Then
            'Do nothing
        Else
            If txtEditPieces.Text = "" Or Val(txtEditPieces.Text) = 0 Then
                MsgBox("You must have a valid quantity entered.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Dim RackingKey As Integer = 0
                Dim BinNumber As String = ""
                Dim PieceWeight, LineWeight As Double
                Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
                Dim PartNumber As String = ""
                Dim PartDescription As String = ""
                Dim RowDivisionID As String = ""
                Dim LotNumber As String = ""
                Dim HeatNumber As String = ""
                Dim OriginalPieceQuantity As Integer = 0

                Dim RowIndex As Integer = Me.dgvPartLookup.CurrentCell.RowIndex

                Try
                    RackingKey = Me.dgvPartLookup.Rows(RowIndex).Cells("RackingKeyColumn1").Value
                Catch ex As Exception
                    RackingKey = 0
                End Try
                Try
                    BinNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("BinNumberColumn1").Value
                Catch ex As Exception
                    BinNumber = ""
                End Try
                Try
                    BoxQuantity = Me.dgvPartLookup.Rows(RowIndex).Cells("BoxQuantityColumn1").Value
                Catch ex As Exception
                    BoxQuantity = 0
                End Try
                Try
                    PiecesPerBox = Me.dgvPartLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn1").Value
                Catch ex As Exception
                    PiecesPerBox = 0
                End Try
                Try
                    PartNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("PartNumberColumn1").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = Me.dgvPartLookup.Rows(RowIndex).Cells("PartDescriptionColumn1").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    HeatNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("HeatNumberColumn1").Value
                Catch ex As Exception
                    HeatNumber = ""
                End Try
                Try
                    LotNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("LotNumberColumn1").Value
                Catch ex As Exception
                    LotNumber = ""
                End Try
                Try
                    RowDivisionID = Me.dgvPartLookup.Rows(RowIndex).Cells("DivisionIDColumn1").Value
                Catch ex As Exception
                    RowDivisionID = GlobalDivisionCode
                End Try
                '*********************************************************************************************************
                'Validation - make sure that box count is one and pieces to remove is less than pieces in rack
                Dim PiecesToRemove As Integer = Val(txtEditPieces.Text)

                If BoxQuantity = 1 And PiecesPerBox >= PiecesToRemove Then
                    TotalPieces = PiecesPerBox - PiecesToRemove
                    OriginalPieceQuantity = PiecesPerBox

                    Me.dgvPartLookup.Rows(RowIndex).Cells("TotalPiecesColumn1").Value = TotalPieces
                    Me.dgvPartLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn1").Value = TotalPieces
                    '*********************************************************************************************************
                    'Get Piece Weight
                    Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
                    Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
                    GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        PieceWeight = 0
                    End Try
                    con.Close()

                    LineWeight = TotalPieces * PieceWeight
                    LineWeight = Math.Round(LineWeight, 0)

                    Me.dgvPartLookup.Rows(RowIndex).Cells("RackingWeightColumn1").Value = LineWeight
                    '*********************************************************************************************************
                    Try
                        'Create command to delete selected line
                        cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                        With cmd.Parameters
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = 1
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '*********************************************************************************************************
                        'Update Rack Activity Log
                        'Fill Log Variables
                        LogHeatNumber = HeatNumber
                        LogActivityDateTime = Now()
                        LogCurrentTotalPieces = TotalPieces
                        LogBinNumber = BinNumber
                        LogLotNumber = LotNumber
                        LogPartNumber = PartNumber
                        LogTotalPiecesDifference = TotalPieces - OriginalPieceQuantity
                        LogOriginalTotalPieces = OriginalPieceQuantity
                        LogTransactionType = "UPDATED"
                        LogUserID = EmployeeLoginName
                        LogPickTicketNumber = ""

                        'If no change in pieces, skip activity log
                        If LogTotalPiecesDifference = 0 Then
                            'Skip
                        Else
                            InsertIntoRackingLog()
                        End If
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = "Lift Truck Racking - Rack Transaction - Remove from Rack Button"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    Try
                        'Update Racking Master List (records all entries)
                        cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                        With cmd.Parameters
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                            .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                            .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = RowDivisionID
                        ErrorDescription = "Lift Truck Racking - Racking Master List - changes in datagrid"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    txtEditPieces.Clear()

                    MsgBox("Rack Updated.", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("You can't remove pieces unless box count = 1 and pieces are greater than the quantity to remove.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub cmdAddToSelectedRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToSelectedRack.Click
        If Me.dgvPartLookup.RowCount = 0 Then
            'Do nothing
        Else
            If txtEditPieces.Text = "" Or Val(txtEditPieces.Text) = 0 Then
                MsgBox("You must have a valid quantity entered.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Dim RackingKey As Integer = 0
                Dim BinNumber As String = ""
                Dim PieceWeight, LineWeight As Double
                Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
                Dim PartNumber As String = ""
                Dim PartDescription As String = ""
                Dim RowDivisionID As String = ""
                Dim LotNumber As String = ""
                Dim HeatNumber As String = ""
                Dim OriginalPieceQuantity As Integer = 0

                Dim RowIndex As Integer = Me.dgvPartLookup.CurrentCell.RowIndex

                Try
                    RackingKey = Me.dgvPartLookup.Rows(RowIndex).Cells("RackingKeyColumn1").Value
                Catch ex As Exception
                    RackingKey = 0
                End Try
                Try
                    BinNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("BinNumberColumn1").Value
                Catch ex As Exception
                    BinNumber = ""
                End Try
                Try
                    BoxQuantity = Me.dgvPartLookup.Rows(RowIndex).Cells("BoxQuantityColumn1").Value
                Catch ex As Exception
                    BoxQuantity = 0
                End Try
                Try
                    PiecesPerBox = Me.dgvPartLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn1").Value
                Catch ex As Exception
                    PiecesPerBox = 0
                End Try
                Try
                    PartNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("PartNumberColumn1").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = Me.dgvPartLookup.Rows(RowIndex).Cells("PartDescriptionColumn1").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    HeatNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("HeatNumberColumn1").Value
                Catch ex As Exception
                    HeatNumber = ""
                End Try
                Try
                    LotNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("LotNumberColumn1").Value
                Catch ex As Exception
                    LotNumber = ""
                End Try
                Try
                    RowDivisionID = Me.dgvPartLookup.Rows(RowIndex).Cells("DivisionIDColumn1").Value
                Catch ex As Exception
                    RowDivisionID = GlobalDivisionCode
                End Try
                '*********************************************************************************************************
                'Validation - make sure that box count is one and pieces to remove is less than pieces in rack
                Dim PiecesToAdd As Integer = Val(txtEditPieces.Text)

                If BoxQuantity = 1 Then
                    TotalPieces = PiecesPerBox + PiecesToAdd
                    OriginalPieceQuantity = PiecesPerBox

                    Me.dgvPartLookup.Rows(RowIndex).Cells("TotalPiecesColumn1").Value = TotalPieces
                    Me.dgvPartLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn1").Value = TotalPieces
                    '*********************************************************************************************************
                    'Get Piece Weight
                    Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
                    Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
                    GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        PieceWeight = 0
                    End Try
                    con.Close()

                    LineWeight = TotalPieces * PieceWeight
                    LineWeight = Math.Round(LineWeight, 0)

                    Me.dgvPartLookup.Rows(RowIndex).Cells("RackingWeightColumn1").Value = LineWeight
                    '*********************************************************************************************************
                    Try
                        'Create command to delete selected line
                        cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                        With cmd.Parameters
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = 1
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '*********************************************************************************************************
                        'Update Rack Activity Log
                        'Fill Log Variables
                        LogHeatNumber = HeatNumber
                        LogActivityDateTime = Now()
                        LogCurrentTotalPieces = TotalPieces
                        LogBinNumber = BinNumber
                        LogLotNumber = LotNumber
                        LogPartNumber = PartNumber
                        LogTotalPiecesDifference = TotalPieces - OriginalPieceQuantity
                        LogOriginalTotalPieces = OriginalPieceQuantity
                        LogTransactionType = "UPDATED"
                        LogUserID = EmployeeLoginName
                        LogPickTicketNumber = ""

                        'If no change in pieces, skip activity log
                        If LogTotalPiecesDifference = 0 Then
                            'Skip
                        Else
                            InsertIntoRackingLog()
                        End If
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = "Lift Truck Racking - Rack Transaction - Add to selected rack"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    Try
                        'Update Racking Master List (records all entries)
                        cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                        With cmd.Parameters
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                            .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                            .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = RowDivisionID
                        ErrorDescription = "Lift Truck Racking - Racking Master List - changes in datagrid"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    txtEditPieces.Clear()

                    MsgBox("Rack Updated.", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("You can't add pieces unless box count = 1.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub cmdSubtractFromRack2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubtractFromRack2.Click
        If Me.dgvRackLookup.RowCount = 0 Then
            'Do nothing
        Else
            If txtEditPieces2.Text = "" Or Val(txtEditPieces2.Text) = 0 Then
                MsgBox("You must have a valid quantity entered.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Dim RackingKey As Integer = 0
                Dim BinNumber As String = ""
                Dim PieceWeight, LineWeight As Double
                Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
                Dim PartNumber As String = ""
                Dim PartDescription As String = ""
                Dim RowDivisionID As String = ""
                Dim LotNumber As String = ""
                Dim HeatNumber As String = ""
                Dim OriginalPieceQuantity As Integer = 0

                Dim RowIndex As Integer = Me.dgvRackLookup.CurrentCell.RowIndex

                Try
                    RackingKey = Me.dgvRackLookup.Rows(RowIndex).Cells("RackingKeyColumn").Value
                Catch ex As Exception
                    RackingKey = 0
                End Try
                Try
                    BinNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("BinNumberColumn").Value
                Catch ex As Exception
                    BinNumber = ""
                End Try
                Try
                    BoxQuantity = Me.dgvRackLookup.Rows(RowIndex).Cells("BoxQuantityColumn").Value
                Catch ex As Exception
                    BoxQuantity = 0
                End Try
                Try
                    PiecesPerBox = Me.dgvRackLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
                Catch ex As Exception
                    PiecesPerBox = 0
                End Try
                Try
                    PartNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = Me.dgvRackLookup.Rows(RowIndex).Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    HeatNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("HeatNumberColumn").Value
                Catch ex As Exception
                    HeatNumber = ""
                End Try
                Try
                    LotNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("LotNumberColumn").Value
                Catch ex As Exception
                    LotNumber = ""
                End Try
                Try
                    RowDivisionID = Me.dgvRackLookup.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = GlobalDivisionCode
                End Try
                '*********************************************************************************************************
                'Validation - make sure that box count is one and pieces to remove is less than pieces in rack
                Dim PiecesToRemove As Integer = Val(txtEditPieces2.Text)

                If BoxQuantity = 1 And PiecesPerBox >= PiecesToRemove Then
                    TotalPieces = PiecesPerBox - PiecesToRemove
                    OriginalPieceQuantity = PiecesPerBox

                    Me.dgvRackLookup.Rows(RowIndex).Cells("TotalPiecesColumn").Value = TotalPieces
                    Me.dgvRackLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value = TotalPieces
                    '*********************************************************************************************************
                    'Get Piece Weight
                    Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
                    Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
                    GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        PieceWeight = 0
                    End Try
                    con.Close()

                    LineWeight = TotalPieces * PieceWeight
                    LineWeight = Math.Round(LineWeight, 0)

                    Me.dgvRackLookup.Rows(RowIndex).Cells("RackingWeightColumn").Value = LineWeight
                    '*********************************************************************************************************
                    Try
                        'Create command to delete selected line
                        cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                        With cmd.Parameters
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = 1
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '*********************************************************************************************************
                        'Update Rack Activity Log
                        'Fill Log Variables
                        LogHeatNumber = HeatNumber
                        LogActivityDateTime = Now()
                        LogCurrentTotalPieces = TotalPieces
                        LogBinNumber = BinNumber
                        LogLotNumber = LotNumber
                        LogPartNumber = PartNumber
                        LogTotalPiecesDifference = TotalPieces - OriginalPieceQuantity
                        LogOriginalTotalPieces = OriginalPieceQuantity
                        LogTransactionType = "UPDATED"
                        LogUserID = EmployeeLoginName
                        LogPickTicketNumber = ""

                        'If no change in pieces, skip activity log
                        If LogTotalPiecesDifference = 0 Then
                            'Skip
                        Else
                            InsertIntoRackingLog()
                        End If
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = "Lift Truck Racking - Rack Transaction - Subtract from selected rack"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    Try
                        'Update Racking Master List (records all entries)
                        cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                        With cmd.Parameters
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                            .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                            .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = RowDivisionID
                        ErrorDescription = "Lift Truck Racking - Racking Master List - changes in datagrid"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    txtEditPieces2.Clear()

                    MsgBox("Rack Updated.", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("You can't remove pieces unless box count = 1 and pieces are greater than the quantity to remove.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub cmdAddToRack2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToRack2.Click
        If Me.dgvRackLookup.RowCount = 0 Then
            'Do nothing
        Else
            If txtEditPieces2.Text = "" Or Val(txtEditPieces2.Text) = 0 Then
                MsgBox("You must have a valid quantity entered.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Dim RackingKey As Integer = 0
                Dim BinNumber As String = ""
                Dim PieceWeight, LineWeight As Double
                Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
                Dim PartNumber As String = ""
                Dim PartDescription As String = ""
                Dim RowDivisionID As String = ""
                Dim LotNumber As String = ""
                Dim HeatNumber As String = ""
                Dim OriginalPieceQuantity As Integer = 0

                Dim RowIndex As Integer = Me.dgvRackLookup.CurrentCell.RowIndex

                Try
                    RackingKey = Me.dgvRackLookup.Rows(RowIndex).Cells("RackingKeyColumn").Value
                Catch ex As Exception
                    RackingKey = 0
                End Try
                Try
                    BinNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("BinNumberColumn").Value
                Catch ex As Exception
                    BinNumber = ""
                End Try
                Try
                    BoxQuantity = Me.dgvRackLookup.Rows(RowIndex).Cells("BoxQuantityColumn").Value
                Catch ex As Exception
                    BoxQuantity = 0
                End Try
                Try
                    PiecesPerBox = Me.dgvRackLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
                Catch ex As Exception
                    PiecesPerBox = 0
                End Try
                Try
                    PartNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = Me.dgvRackLookup.Rows(RowIndex).Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    HeatNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("HeatNumberColumn").Value
                Catch ex As Exception
                    HeatNumber = ""
                End Try
                Try
                    LotNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("LotNumberColumn").Value
                Catch ex As Exception
                    LotNumber = ""
                End Try
                Try
                    RowDivisionID = Me.dgvRackLookup.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try
                '*********************************************************************************************************
                'Validation - make sure that box count is one and pieces to remove is less than pieces in rack
                Dim PiecesToAdd As Integer = Val(txtEditPieces2.Text)

                If BoxQuantity = 1 Then
                    TotalPieces = PiecesPerBox + PiecesToAdd
                    OriginalPieceQuantity = PiecesPerBox

                    Me.dgvRackLookup.Rows(RowIndex).Cells("TotalPiecesColumn").Value = TotalPieces
                    Me.dgvRackLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value = TotalPieces
                    '*********************************************************************************************************
                    'Get Piece Weight
                    Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
                    Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
                    GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        PieceWeight = 0
                    End Try
                    con.Close()

                    LineWeight = TotalPieces * PieceWeight
                    LineWeight = Math.Round(LineWeight, 0)

                    Me.dgvRackLookup.Rows(RowIndex).Cells("RackingWeightColumn").Value = LineWeight
                    '*********************************************************************************************************
                    Try
                        'Create command to delete selected line
                        cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                        With cmd.Parameters
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = 1
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '*********************************************************************************************************
                        'Update Rack Activity Log
                        'Fill Log Variables
                        LogHeatNumber = HeatNumber
                        LogActivityDateTime = Now()
                        LogCurrentTotalPieces = TotalPieces
                        LogBinNumber = BinNumber
                        LogLotNumber = LotNumber
                        LogPartNumber = PartNumber
                        LogTotalPiecesDifference = TotalPieces - OriginalPieceQuantity
                        LogOriginalTotalPieces = OriginalPieceQuantity
                        LogTransactionType = "UPDATED"
                        LogUserID = EmployeeLoginName
                        LogPickTicketNumber = ""

                        'If no change in pieces, skip activity log
                        If LogTotalPiecesDifference = 0 Then
                            'Skip
                        Else
                            InsertIntoRackingLog()
                        End If
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = "Lift Truck Racking - Rack Transaction - Add to selected rack"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    Try
                        'Update Racking Master List (records all entries)
                        cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                        With cmd.Parameters
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                            .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                            .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = RowDivisionID
                        ErrorDescription = "Lift Truck Racking - Racking Master List - changes in datagrid"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    txtEditPieces2.Clear()

                    MsgBox("Rack Updated.", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("You can't add pieces unless box count = 1.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub cmdAddToRack3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToRack3.Click
        If Me.dgvRackingByOrder.RowCount = 0 Then
            'Do nothing
        Else
            If txtEditPieces3.Text = "" Or Val(txtEditPieces3.Text) = 0 Then
                MsgBox("You must have a valid quantity entered.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Dim RackingKey As Integer = 0
                Dim BinNumber As String = ""
                Dim PieceWeight, LineWeight As Double
                Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
                Dim PartNumber As String = ""
                Dim PartDescription As String = ""
                Dim RowDivisionID As String = ""
                Dim LotNumber As String = ""
                Dim HeatNumber As String = ""
                Dim OriginalPieceQuantity As Integer = 0

                Dim RowIndex As Integer = Me.dgvRackingByOrder.CurrentCell.RowIndex

                Try
                    RackingKey = Me.dgvRackingByOrder.Rows(RowIndex).Cells("RackingKeyColumnOE").Value
                Catch ex As Exception
                    RackingKey = 0
                End Try
                Try
                    BinNumber = Me.dgvRackingByOrder.Rows(RowIndex).Cells("BinNumberColumnOE").Value
                Catch ex As Exception
                    BinNumber = ""
                End Try
                Try
                    BoxQuantity = Me.dgvRackingByOrder.Rows(RowIndex).Cells("BoxQuantityColumnOE").Value
                Catch ex As Exception
                    BoxQuantity = 0
                End Try
                Try
                    PiecesPerBox = Me.dgvRackingByOrder.Rows(RowIndex).Cells("PiecesPerBoxColumnOE").Value
                Catch ex As Exception
                    PiecesPerBox = 0
                End Try
                Try
                    PartNumber = Me.dgvRackingByOrder.Rows(RowIndex).Cells("PartNumberColumnOE").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = Me.dgvRackingByOrder.Rows(RowIndex).Cells("PartDescriptionColumnOE").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    HeatNumber = Me.dgvRackingByOrder.Rows(RowIndex).Cells("HeatNumberColumnOE").Value
                Catch ex As Exception
                    HeatNumber = ""
                End Try
                Try
                    LotNumber = Me.dgvRackingByOrder.Rows(RowIndex).Cells("LotNumberColumnOE").Value
                Catch ex As Exception
                    LotNumber = ""
                End Try
                Try
                    RowDivisionID = Me.dgvRackingByOrder.Rows(RowIndex).Cells("DivisionIDColumnOE").Value
                Catch ex As Exception
                    RowDivisionID = GlobalDivisionCode
                End Try
                '*********************************************************************************************************
                'Validation - make sure that box count is one and pieces to remove is less than pieces in rack
                Dim PiecesToAdd As Integer = Val(txtEditPieces3.Text)

                If BoxQuantity = 1 Then
                    TotalPieces = PiecesPerBox + PiecesToAdd
                    OriginalPieceQuantity = PiecesPerBox

                    Me.dgvRackingByOrder.Rows(RowIndex).Cells("TotalPiecesColumnOE").Value = TotalPieces
                    Me.dgvRackingByOrder.Rows(RowIndex).Cells("PiecesPerBoxColumnOE").Value = TotalPieces
                    '*********************************************************************************************************
                    'Get Piece Weight
                    Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
                    Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
                    GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        PieceWeight = 0
                    End Try
                    con.Close()

                    LineWeight = TotalPieces * PieceWeight
                    LineWeight = Math.Round(LineWeight, 0)

                    Me.dgvRackingByOrder.Rows(RowIndex).Cells("RackingWeightColumnOE").Value = LineWeight
                    '*********************************************************************************************************
                    Try
                        'Create command to delete selected line
                        cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                        With cmd.Parameters
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = 1
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '*********************************************************************************************************
                        'Update Rack Activity Log
                        'Fill Log Variables
                        LogHeatNumber = HeatNumber
                        LogActivityDateTime = Now()
                        LogCurrentTotalPieces = TotalPieces
                        LogBinNumber = BinNumber
                        LogLotNumber = LotNumber
                        LogPartNumber = PartNumber
                        LogTotalPiecesDifference = TotalPieces - OriginalPieceQuantity
                        LogOriginalTotalPieces = OriginalPieceQuantity
                        LogTransactionType = "UPDATED"
                        LogUserID = EmployeeLoginName
                        LogPickTicketNumber = txtOrderNumber.Text

                        'If no change in pieces, skip activity log
                        If LogTotalPiecesDifference = 0 Then
                            'Skip
                        Else
                            InsertIntoRackingLog()
                        End If
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = "Lift Truck Racking - Rack Transaction - Add to selected rack"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    Try
                        'Update Racking Master List (records all entries)
                        cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                        With cmd.Parameters
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                            .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                            .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = RowDivisionID
                        ErrorDescription = "Lift Truck Racking - Racking Master List - changes in datagrid"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    txtEditPieces3.Clear()

                    MsgBox("Rack Updated.", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("You can't add pieces unless box count = 1.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub cmdDeleteLineFromOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLineFromOrder.Click
        If Me.dgvRackingByOrder.RowCount > 0 Then
            Dim LineRackingKey As Integer = 0
            Dim LineBinNumber As String = ""
            Dim LinePartNumber As String = ""
            Dim LineHeatNumber As String = ""
            Dim LineLotNumber As String = ""
            Dim LineTotalPieces As Integer = 0

            Dim RowIndex2 As Integer = Me.dgvRackingByOrder.CurrentCell.RowIndex

            Try
                LineRackingKey = Me.dgvRackingByOrder.Rows(RowIndex2).Cells("RackingKeyColumnOE").Value
            Catch ex As Exception
                LineRackingKey = 0
            End Try
            Try
                LineBinNumber = Me.dgvRackingByOrder.Rows(RowIndex2).Cells("BinNumberColumnOE").Value
            Catch ex As Exception
                LineBinNumber = ""
            End Try
            Try
                LinePartNumber = Me.dgvRackingByOrder.Rows(RowIndex2).Cells("PartNumberColumnOE").Value
            Catch ex As Exception
                LinePartNumber = 0
            End Try
            Try
                LineHeatNumber = Me.dgvRackingByOrder.Rows(RowIndex2).Cells("HeatNumberColumnOE").Value
            Catch ex As Exception
                LineHeatNumber = ""
            End Try
            Try
                LineLotNumber = Me.dgvRackingByOrder.Rows(RowIndex2).Cells("LotNumberColumnOE").Value
            Catch ex As Exception
                LineLotNumber = ""
            End Try
            Try
                LineTotalPieces = Me.dgvRackingByOrder.Rows(RowIndex2).Cells("TotalPiecesColumnOE").Value
            Catch ex As Exception
                LineTotalPieces = 0
            End Try

            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this selected line?", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    'Create command to delete selected line
                    cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                    With cmd.Parameters
                        .Add("@BinNumber", SqlDbType.VarChar).Value = LineBinNumber
                        .Add("@RackingKey", SqlDbType.VarChar).Value = LineRackingKey
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************************
                    'Log Rack Activity
                    'Fill Log Variables
                    LogHeatNumber = LineHeatNumber
                    LogActivityDateTime = Now()
                    LogCurrentTotalPieces = 0
                    LogBinNumber = LineBinNumber
                    LogLotNumber = LineLotNumber
                    LogPartNumber = LinePartNumber
                    LogTotalPiecesDifference = LineTotalPieces * -1
                    LogOriginalTotalPieces = LineTotalPieces
                    LogTransactionType = "DELETED"
                    LogUserID = EmployeeLoginName
                    LogPickTicketNumber = txtOrderNumber.Text

                    InsertIntoRackingLog()
                    '***********************************************************************************************
                    'Reload datagrid
                    LoadRacksByPartNumber()
                Catch ex As Exception
                    'Error Log
                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Lift Truck Racking - Delete Line"
                    ErrorReferenceNumber = "Bin # " + LineBinNumber + ", Part # - " + LinePartNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            ElseIf button = DialogResult.No Then
                txtRackNumber.Focus()
            End If
        End If

        If Me.dgvOrderLines.RowCount > 0 Then
            Dim RowPartNumber As String = ""
            Dim RowDivisionID As String = ""

            Dim RowIndex As Integer = Me.dgvOrderLines.CurrentCell.RowIndex

            Try
                RowPartNumber = Me.dgvOrderLines.Rows(RowIndex).Cells("ItemIDColumnOL").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowDivisionID = Me.dgvOrderLines.Rows(RowIndex).Cells("DivisionIDColumnOL").Value
            Catch ex As Exception
                RowDivisionID = ""
            End Try

            'Loads part number and description for specific division
            cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE PartNumber = @PartNumber" + DivisionFilter + " ORDER BY BoxQuantity, BinNumber", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "RackingTransactionTable")
            dgvRackingByOrder.DataSource = ds4.Tables("RackingTransactionTable")
            con.Close()
            dgvRackingByOrder.RowTemplate.Height = 50
        End If
    End Sub

    'Save/update events

    Public Sub InsertIntoRackingLog()
        'Get Time and Date
        Dim TodaysDate As DateTime = Now()
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

        'Determine Computer name of PC
        Dim LoginPCName As String = My.Computer.Name

        'Create command to dwrite to activity log
        cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate, PickTicketNumber, LoginComputer) Values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate, @PickTicketNumber, @LoginComputer)", con)

        With cmd.Parameters
            .Add("@ActivityDateTime", SqlDbType.VarChar).Value = TodaysDate
            .Add("@BinNumber", SqlDbType.VarChar).Value = LogBinNumber
            .Add("@PartNumber", SqlDbType.VarChar).Value = LogPartNumber
            .Add("@HeatNumber", SqlDbType.VarChar).Value = LogHeatNumber
            .Add("@LotNumber", SqlDbType.VarChar).Value = LogLotNumber
            .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = LogOriginalTotalPieces
            .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = LogCurrentTotalPieces
            .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = LogTotalPiecesDifference
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@TransactionType", SqlDbType.VarChar).Value = LogTransactionType
            .Add("@UserID", SqlDbType.VarChar).Value = LogUserID
            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = LogOrderNumber
            .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
            .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
            .Add("@PickTicketNumber", SqlDbType.VarChar).Value = LogPickTicketNumber
            .Add("@LoginComputer", SqlDbType.VarChar).Value = LoginPCName
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Datagridview events

    Private Sub dgvPartLookup_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPartLookup.CellValueChanged
        Dim RackingKey As Integer = 0
        Dim BinNumber As String = ""
        Dim PieceWeight, LineWeight As Double
        Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
        Dim PartNumber As String = ""
        Dim PartDescription As String = ""
        Dim LotNumber As String = ""
        Dim HeatNumber As String = ""
        Dim OriginalPieceQuantity As Integer = 0
        Dim RowDivision As String = ""

        If Me.dgvPartLookup.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvPartLookup.CurrentCell.RowIndex

            Try
                RackingKey = Me.dgvPartLookup.Rows(RowIndex).Cells("RackingKeyColumn1").Value
            Catch ex As Exception
                RackingKey = 0
            End Try
            Try
                BinNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("BinNumberColumn1").Value
            Catch ex As Exception
                BinNumber = ""
            End Try
            Try
                BoxQuantity = Me.dgvPartLookup.Rows(RowIndex).Cells("BoxQuantityColumn1").Value
            Catch ex As Exception
                BoxQuantity = 0
            End Try
            Try
                PiecesPerBox = Me.dgvPartLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn1").Value
            Catch ex As Exception
                PiecesPerBox = 0
            End Try
            Try
                PartNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("PartNumberColumn1").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = Me.dgvPartLookup.Rows(RowIndex).Cells("PartDescriptionColumn1").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                HeatNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("HeatNumberColumn1").Value
            Catch ex As Exception
                HeatNumber = ""
            End Try
            Try
                LotNumber = Me.dgvPartLookup.Rows(RowIndex).Cells("LotNumberColumn1").Value
            Catch ex As Exception
                LotNumber = ""
            End Try
            Try
                RowDivision = Me.dgvPartLookup.Rows(RowIndex).Cells("DivisionIDColumn1").Value
            Catch ex As Exception
                RowDivision = GlobalDivisionCode
            End Try
            '*********************************************************************************************************
            TotalPieces = BoxQuantity * PiecesPerBox

            'Get original piece count
            Dim GetOriginalPiecesStatement As String = "SELECT TotalPieces FROM RackingTransactionTable WHERE RackingKey = @RackingKey"
            Dim GetOriginalPiecesCommand As New SqlCommand(GetOriginalPiecesStatement, con)
            GetOriginalPiecesCommand.Parameters.Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OriginalPieceQuantity = CInt(GetOriginalPiecesCommand.ExecuteScalar)
            Catch ex As Exception
                OriginalPieceQuantity = 0
            End Try
            con.Close()
            '*********************************************************************************************************
            'Get Piece Weight
            Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
            Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
            GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
            Catch ex As Exception
                PieceWeight = 0
            End Try
            con.Close()

            LineWeight = TotalPieces * PieceWeight
            LineWeight = Math.Round(LineWeight, 0)
            '*********************************************************************************************************
            Try
                'Create command to update line
                cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                With cmd.Parameters
                    .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                    .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                    .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*********************************************************************************************************
                'Update Rack Activity Log
                'Fill Log Variables
                LogHeatNumber = HeatNumber
                LogActivityDateTime = Now()
                LogCurrentTotalPieces = TotalPieces
                LogBinNumber = BinNumber
                LogLotNumber = LotNumber
                LogPartNumber = PartNumber
                LogTotalPiecesDifference = TotalPieces - OriginalPieceQuantity
                LogOriginalTotalPieces = OriginalPieceQuantity
                LogTransactionType = "UPDATED"
                LogUserID = EmployeeLoginName
                LogPickTicketNumber = ""

                'If no change in pieces, skip activity log
                If LogTotalPiecesDifference = 0 Then
                    'Skip
                Else
                    InsertIntoRackingLog()
                End If
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = RowDivision
                ErrorDescription = "Lift Truck Racking - Add to activity log - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*************************************************************************************************************
            Try
                'Update Racking Master List (records all entries)
                cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                    .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Now()
                ErrorComment = ex.ToString()
                ErrorDivision = RowDivision
                ErrorDescription = "Lift Truck Racking - Racking Master List - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*****************************************************************************************************************************
            'Update Datagrid
            'Me.dgvPartLookup.Rows(RowIndex).Cells("TotalPiecesColumn1").Value = TotalPieces
            'Me.dgvPartLookup.Rows(RowIndex).Cells("RackingWeightColumn1").Value = LineWeight

            LoadRacksByPartNumber()
        End If
    End Sub

    Private Sub dgvRackLookup_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRackLookup.CellBeginEdit
        If Me.dgvRackLookup.RowCount > 0 Then
            ControlFocus = "RackDatagridview"
            'Defines cell to edit
            Dim RowIndex As Integer = Me.dgvRackLookup.CurrentCell.RowIndex
            Dim ColumnIndex As Integer = Me.dgvRackLookup.CurrentCell.ColumnIndex

            'Defines Racking key to update
            Try
                DatagridViewRackingKey = Me.dgvRackLookup.Rows(RowIndex).Cells("RackingKeyColumn").Value
            Catch ex As Exception
                DatagridViewRackingKey = 0
            End Try

            RackingRowIndex = RowIndex
            RackingColumnIndex = ColumnIndex

            'Define field to edit
            If ColumnIndex = 1 Then
                DatagridviewRackFieldToEdit = "BOXES"
            ElseIf ColumnIndex = 2 Then
                DatagridviewRackFieldToEdit = "PIECES"
            Else
                'Do nothing
            End If
        End If
    End Sub

    Private Sub dgvRackLookup_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRackLookup.CellValueChanged
        Dim RackingKey As Integer = 0
        Dim BinNumber As String = ""
        Dim PieceWeight, LineWeight As Double
        Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
        Dim PartNumber As String = ""
        Dim PartDescription As String = ""
        Dim HeatNumber As String = ""
        Dim LotNumber As String = ""
        Dim OriginalPieceQuantity As Integer = 0
        Dim RowDivisionID As String = ""

        If Me.dgvRackLookup.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvRackLookup.CurrentCell.RowIndex

            Try
                RackingKey = Me.dgvRackLookup.Rows(RowIndex).Cells("RackingKeyColumn").Value
            Catch ex As Exception
                RackingKey = 0
            End Try
            Try
                BinNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("BinNumberColumn").Value
            Catch ex As Exception
                BinNumber = ""
            End Try
            Try
                BoxQuantity = Me.dgvRackLookup.Rows(RowIndex).Cells("BoxQuantityColumn").Value
            Catch ex As Exception
                BoxQuantity = 0
            End Try
            Try
                PiecesPerBox = Me.dgvRackLookup.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
            Catch ex As Exception
                PiecesPerBox = 0
            End Try
            Try
                PartNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = Me.dgvRackLookup.Rows(RowIndex).Cells("PartDescriptionColumn").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                HeatNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("HeatNumberColumn").Value
            Catch ex As Exception
                HeatNumber = ""
            End Try
            Try
                LotNumber = Me.dgvRackLookup.Rows(RowIndex).Cells("LotNumberColumn").Value
            Catch ex As Exception
                LotNumber = ""
            End Try
            Try
                RowDivisionID = Me.dgvRackLookup.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivisionID = GlobalDivisionCode
            End Try
            '*****************************************************************************************************
            'Get original piece count
            Dim GetOriginalPiecesStatement As String = "SELECT TotalPieces FROM RackingTransactionTable WHERE RackingKey = @RackingKey"
            Dim GetOriginalPiecesCommand As New SqlCommand(GetOriginalPiecesStatement, con)
            GetOriginalPiecesCommand.Parameters.Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OriginalPieceQuantity = CInt(GetOriginalPiecesCommand.ExecuteScalar)
            Catch ex As Exception
                OriginalPieceQuantity = 0
            End Try
            con.Close()

            TotalPieces = BoxQuantity * PiecesPerBox
            '*****************************************************************************************************
            'Get Piece Weight
            Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
            Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
            GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
            Catch ex As Exception
                PieceWeight = 0
            End Try
            con.Close()

            LineWeight = TotalPieces * PieceWeight
            LineWeight = Math.Round(LineWeight, 0)
            '*****************************************************************************************************
            Try
                'Create command to update selected line
                cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                With cmd.Parameters
                    .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                    .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                    .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*********************************************************************************************************
                'Update Rack Activity Log
                'Fill Log Variables
                LogHeatNumber = HeatNumber
                LogActivityDateTime = Now()
                LogCurrentTotalPieces = TotalPieces
                LogBinNumber = BinNumber
                LogLotNumber = LotNumber
                LogPartNumber = PartNumber
                LogTotalPiecesDifference = TotalPieces - OriginalPieceQuantity
                LogOriginalTotalPieces = OriginalPieceQuantity
                LogTransactionType = "UPDATED"
                LogUserID = EmployeeLoginName
                LogPickTicketNumber = ""

                'If no change in pieces, skip activity log
                If LogTotalPiecesDifference = 0 Then
                    'Skip
                Else
                    InsertIntoRackingLog()
                End If
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = RowDivisionID
                ErrorDescription = "Lift Truck Racking - Add to activity log - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '********************************************************************************************************
            Try
                'Update Racking Master List (records all entries)
                cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                    .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = RowDivisionID
                ErrorDescription = "Lift Truck Racking - Racking Master List - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Update Datagrid
            'Me.dgvRackLookup.Rows(RowIndex).Cells("TotalPiecesColumn").Value = TotalPieces
            'Me.dgvRackLookup.Rows(RowIndex).Cells("RackingWeightColumn").Value = LineWeight
            '*********************************************************************************************************
            LoadRacksByRackNumber()
        End If
    End Sub

    Private Sub dgvOrderLines_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrderLines.CellClick
        If Me.dgvOrderLines.RowCount > 0 Then
            Dim RowPartNumber As String = ""
            Dim RowDivisionID As String = ""

            Dim RowIndex As Integer = Me.dgvOrderLines.CurrentCell.RowIndex

            Try
                RowPartNumber = Me.dgvOrderLines.Rows(RowIndex).Cells("ItemIDColumnOL").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowDivisionID = Me.dgvOrderLines.Rows(RowIndex).Cells("DivisionIDColumnOL").Value
            Catch ex As Exception
                RowDivisionID = ""
            End Try

            'Loads part number and description for specific division
            cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE PartNumber = @PartNumber" + DivisionFilter + " ORDER BY BoxQuantity, BinNumber", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "RackingTransactionTable")
            dgvRackingByOrder.DataSource = ds1.Tables("RackingTransactionTable")
            con.Close()
            dgvRackingByOrder.RowTemplate.Height = 50
        End If
    End Sub

    Private Sub dgvOrderLines_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrderLines.CellContentClick
        If Me.dgvOrderLines.RowCount > 0 Then
            Dim RowPartNumber As String = ""
            Dim RowDivisionID As String = ""

            Dim RowIndex As Integer = Me.dgvOrderLines.CurrentCell.RowIndex

            Try
                RowPartNumber = Me.dgvOrderLines.Rows(RowIndex).Cells("ItemIDColumnOL").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowDivisionID = Me.dgvOrderLines.Rows(RowIndex).Cells("DivisionIDColumnOL").Value
            Catch ex As Exception
                RowDivisionID = ""
            End Try

            'Loads part number and description for specific division
            cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE PartNumber = @PartNumber" + DivisionFilter + " ORDER BY BoxQuantity, BinNumber", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "RackingTransactionTable")
            dgvRackingByOrder.DataSource = ds1.Tables("RackingTransactionTable")
            con.Close()
            dgvRackingByOrder.RowTemplate.Height = 50
        End If
    End Sub

    Private Sub dgvOrderLines_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOrderLines.RowHeaderMouseClick
        If Me.dgvOrderLines.RowCount > 0 Then
            Dim RowPartNumber As String = ""
            Dim RowDivisionID As String = ""

            Dim RowIndex As Integer = Me.dgvOrderLines.CurrentCell.RowIndex

            Try
                RowPartNumber = Me.dgvOrderLines.Rows(RowIndex).Cells("ItemIDColumnOL").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowDivisionID = Me.dgvOrderLines.Rows(RowIndex).Cells("DivisionIDColumnOL").Value
            Catch ex As Exception
                RowDivisionID = ""
            End Try

            'Loads part number and description for specific division
            cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE PartNumber = @PartNumber" + DivisionFilter + " ORDER BY BoxQuantity, BinNumber", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "RackingTransactionTable")
            dgvRackingByOrder.DataSource = ds4.Tables("RackingTransactionTable")
            con.Close()
            dgvRackingByOrder.RowTemplate.Height = 50
        End If
    End Sub

    Private Sub dgvRackingByOrder_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRackingByOrder.CellValueChanged
        Dim RackingKey As Integer = 0
        Dim BinNumber As String = ""
        Dim PieceWeight, LineWeight As Double
        Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
        Dim PartNumber As String = ""
        Dim PartDescription As String = ""
        Dim RowDivisionID As String = ""
        Dim HeatNumber As String = ""
        Dim LotNumber As String = ""
        Dim OriginalPieceQuantity As Integer = 0

        If Me.dgvRackingByOrder.RowCount > 0 Then
            Dim RowIndex3 As Integer = Me.dgvRackingByOrder.CurrentCell.RowIndex

            Try
                RackingKey = Me.dgvRackingByOrder.Rows(RowIndex3).Cells("RackingKeyColumnOE").Value
            Catch ex As Exception
                RackingKey = 0
            End Try
            Try
                BinNumber = Me.dgvRackingByOrder.Rows(RowIndex3).Cells("BinNumberColumnOE").Value
            Catch ex As Exception
                BinNumber = ""
            End Try
            Try
                BoxQuantity = Me.dgvRackingByOrder.Rows(RowIndex3).Cells("BoxQuantityColumnOE").Value
            Catch ex As Exception
                BoxQuantity = 0
            End Try
            Try
                PiecesPerBox = Me.dgvRackingByOrder.Rows(RowIndex3).Cells("PiecesPerBoxColumnOE").Value
            Catch ex As Exception
                PiecesPerBox = 0
            End Try
            Try
                PartNumber = Me.dgvRackingByOrder.Rows(RowIndex3).Cells("PartNumberColumnOE").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                PartDescription = Me.dgvRackingByOrder.Rows(RowIndex3).Cells("PartDescriptionColumnOE").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                HeatNumber = Me.dgvRackingByOrder.Rows(RowIndex3).Cells("HeatNumberColumnOE").Value
            Catch ex As Exception
                HeatNumber = ""
            End Try
            Try
                LotNumber = Me.dgvRackingByOrder.Rows(RowIndex3).Cells("LotNumberColumnOE").Value
            Catch ex As Exception
                LotNumber = ""
            End Try
            Try
                RowDivisionID = Me.dgvRackingByOrder.Rows(RowIndex3).Cells("DivisionIDColumnOE").Value
            Catch ex As Exception
                RowDivisionID = GlobalDivisionCode
            End Try
            '*****************************************************************************************************
            'Get original piece count
            Dim GetOriginalPiecesStatement As String = "SELECT TotalPieces FROM RackingTransactionTable WHERE RackingKey = @RackingKey"
            Dim GetOriginalPiecesCommand As New SqlCommand(GetOriginalPiecesStatement, con)
            GetOriginalPiecesCommand.Parameters.Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OriginalPieceQuantity = CInt(GetOriginalPiecesCommand.ExecuteScalar)
            Catch ex As Exception
                OriginalPieceQuantity = 0
            End Try
            con.Close()

            TotalPieces = BoxQuantity * PiecesPerBox
            '*****************************************************************************************************
            'Get Piece Weight
            Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
            Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
            GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
            Catch ex As Exception
                PieceWeight = 0
            End Try
            con.Close()

            LineWeight = TotalPieces * PieceWeight
            LineWeight = Math.Round(LineWeight, 0)
            '*****************************************************************************************************
            Try
                'Create command to update selected line
                cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                With cmd.Parameters
                    .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                    .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                    .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*********************************************************************************************************
                'Update Rack Activity Log
                'Fill Log Variables
                LogHeatNumber = HeatNumber
                LogActivityDateTime = Now()
                LogCurrentTotalPieces = TotalPieces
                LogBinNumber = BinNumber
                LogLotNumber = LotNumber
                LogPartNumber = PartNumber
                LogTotalPiecesDifference = TotalPieces - OriginalPieceQuantity
                LogOriginalTotalPieces = OriginalPieceQuantity
                LogTransactionType = "UPDATED"
                LogUserID = EmployeeLoginName
                LogPickTicketNumber = txtOrderNumber.Text

                'If no change in pieces, skip activity log
                If LogTotalPiecesDifference = 0 Then
                    'Skip
                Else
                    InsertIntoRackingLog()
                End If
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "Lift Truck Racking - Add to Rack Transactions - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '********************************************************************************************************
            Try
                'Update Racking Master List (records all entries)
                cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                    .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Now()
                ErrorComment = ex.ToString()
                ErrorDivision = RowDivisionID
                ErrorDescription = "Lift Truck Racking - Racking Master List - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************************
            'Update Datagrid
            Me.dgvRackingByOrder.Rows(RowIndex3).Cells("RackingWeightColumnOE").Value = LineWeight
            Me.dgvRackingByOrder.Rows(RowIndex3).Cells("TotalPiecesColumnOE").Value = TotalPieces
        End If
    End Sub

    'Text box events

    Private Sub txtLotNumber_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLotNumber.GotFocus
        ControlFocus = "LotNumber"
    End Sub

    Private Sub txtLotNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLotNumber.LostFocus
        'ControlFocus = ""
    End Sub

    Private Sub txtPartNumber_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartNumber.GotFocus
        ControlFocus = "PartNumber"
    End Sub

    Private Sub txtPartNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartNumber.LostFocus
        'ControlFocus = ""
    End Sub

    Private Sub txtAddBinNumber_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddBinNumber.GotFocus
        ControlFocus = "AddBinNumber"
    End Sub

    Private Sub txtAddBinNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddBinNumber.LostFocus
        'ControlFocus = ""
    End Sub

    Private Sub txtNumberOfBoxes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumberOfBoxes.GotFocus
        ControlFocus = "NumberOfBoxes"
    End Sub

    Private Sub txtNumberOfBoxes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumberOfBoxes.LostFocus
        'ControlFocus = ""
    End Sub

    Private Sub txtNumberOfPieces_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumberOfPieces.GotFocus
        ControlFocus = "NumberOfPieces"
    End Sub

    Private Sub txtNumberOfPieces_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumberOfPieces.LostFocus
        'ControlFocus = ""
    End Sub

    Private Sub txtPartNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartNumber.TextChanged
        If txtLotNumber.Text = "" Then
            LoadPartNumberData()
        End If
    End Sub

    Private Sub txtLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLotNumber.TextChanged
        LoadLotNumberData()
    End Sub

    Private Sub txtNumberOfBoxes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumberOfBoxes.TextChanged
        If Val(txtNumberOfBoxes.Text) = 0 Or Val(txtNumberOfPieces.Text) = 0 Then
            'Skip
        Else
            TotalPiecesToAdd = Val(txtNumberOfBoxes.Text) * Val(txtNumberOfPieces.Text)
            TotalWeightToAdd = TotalPiecesToAdd * PieceWeight
            txtTotalPieces.Text = TotalPiecesToAdd
            txtTotalWeight.Text = TotalWeightToAdd
        End If
    End Sub

    Private Sub txtNumberOfPieces_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumberOfPieces.TextChanged
        If Val(txtNumberOfBoxes.Text) = 0 Or Val(txtNumberOfPieces.Text) = 0 Then
            'Skip
        Else
            TotalPiecesToAdd = Val(txtNumberOfBoxes.Text) * Val(txtNumberOfPieces.Text)
            TotalWeightToAdd = TotalPiecesToAdd * PieceWeight
            txtTotalPieces.Text = TotalPiecesToAdd
            txtTotalWeight.Text = TotalWeightToAdd
        End If
    End Sub

    Private Sub txtUpdateDatagrid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ControlFocus = "RackDatagridview" Then
            If DatagridviewRackFieldToEdit = "BOXES" Then
                Me.dgvRackLookup.Rows(RackingRowIndex).Cells(RackingColumnIndex).Style.SelectionBackColor = Color.LightSkyBlue
                Me.dgvRackLookup.Rows(RackingRowIndex).Cells(RackingColumnIndex).Style.SelectionForeColor = Color.Crimson
                Me.dgvRackLookup.Rows(RackingRowIndex).Cells(RackingColumnIndex).Value = txtUpdateDatagrid.Text
            ElseIf DatagridviewRackFieldToEdit = "PIECES" Then
                Me.dgvRackLookup.Rows(RackingRowIndex).Cells(RackingColumnIndex).Style.SelectionBackColor = Color.LightYellow
                Me.dgvRackLookup.Rows(RackingRowIndex).Cells(RackingColumnIndex).Style.SelectionForeColor = Color.Crimson
                Me.dgvRackLookup.Rows(RackingRowIndex).Cells(RackingColumnIndex).Value = txtUpdateDatagrid.Text
            Else

            End If
        ElseIf ControlFocus = "PartDatagridview" Then

        Else

        End If
    End Sub

    Private Sub txtOrderNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderNumber.TextChanged
        LoadOrderLines()
    End Sub

    Private Sub txtRackNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRackNumber.TextChanged
        LoadRacksByRackNumber()
    End Sub

    Private Sub txtPartNumberLookup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartNumberLookup.TextChanged
        LoadRacksByPartNumber()
        LoadRackTotalByPart()
        LoadQuantityOnHand()
    End Sub

    Private Sub txtRemoveFromRack3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemoveFromRack3.Click
        If Me.dgvRackingByOrder.RowCount = 0 Then
            'Do nothing
        Else
            If txtEditPieces3.Text = "" Or Val(txtEditPieces3.Text) = 0 Then
                MsgBox("You must have a valid quantity entered.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Dim RackingKey As Integer = 0
                Dim BinNumber As String = ""
                Dim PieceWeight, LineWeight As Double
                Dim BoxQuantity, PiecesPerBox, TotalPieces As Integer
                Dim PartNumber As String = ""
                Dim PartDescription As String = ""
                Dim RowDivisionID As String = ""
                Dim LotNumber As String = ""
                Dim HeatNumber As String = ""
                Dim OriginalPieceQuantity As Integer = 0

                Dim RowIndex As Integer = Me.dgvRackingByOrder.CurrentCell.RowIndex

                Try
                    RackingKey = Me.dgvRackingByOrder.Rows(RowIndex).Cells("RackingKeyColumnOE").Value
                Catch ex As Exception
                    RackingKey = 0
                End Try
                Try
                    BinNumber = Me.dgvRackingByOrder.Rows(RowIndex).Cells("BinNumberColumnOE").Value
                Catch ex As Exception
                    BinNumber = ""
                End Try
                Try
                    BoxQuantity = Me.dgvRackingByOrder.Rows(RowIndex).Cells("BoxQuantityColumnOE").Value
                Catch ex As Exception
                    BoxQuantity = 0
                End Try
                Try
                    PiecesPerBox = Me.dgvRackingByOrder.Rows(RowIndex).Cells("PiecesPerBoxColumnOE").Value
                Catch ex As Exception
                    PiecesPerBox = 0
                End Try
                Try
                    PartNumber = Me.dgvRackingByOrder.Rows(RowIndex).Cells("PartNumberColumnOE").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = Me.dgvRackingByOrder.Rows(RowIndex).Cells("PartDescriptionColumnOE").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    HeatNumber = Me.dgvRackingByOrder.Rows(RowIndex).Cells("HeatNumberColumnOE").Value
                Catch ex As Exception
                    HeatNumber = ""
                End Try
                Try
                    LotNumber = Me.dgvRackingByOrder.Rows(RowIndex).Cells("LotNumberColumnOE").Value
                Catch ex As Exception
                    LotNumber = ""
                End Try
                Try
                    RowDivisionID = Me.dgvRackingByOrder.Rows(RowIndex).Cells("DivisionIDColumnOE").Value
                Catch ex As Exception
                    RowDivisionID = GlobalDivisionCode
                End Try
                '*********************************************************************************************************
                'Validation - make sure that box count is one and pieces to remove is less than pieces in rack
                Dim PiecesToRemove As Integer = Val(txtEditPieces3.Text)

                If BoxQuantity = 1 And PiecesPerBox >= PiecesToRemove Then
                    TotalPieces = PiecesPerBox - PiecesToRemove
                    OriginalPieceQuantity = PiecesPerBox

                    '*********************************************************************************************************
                    'Get Piece Weight
                    Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID" + DivisionFilter
                    Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
                    GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        PieceWeight = 0
                    End Try
                    con.Close()

                    LineWeight = TotalPieces * PieceWeight
                    LineWeight = Math.Round(LineWeight, 0)

                    Me.dgvRackingByOrder.Rows(RowIndex).Cells("TotalPiecesColumnOE").Value = TotalPieces
                    Me.dgvRackingByOrder.Rows(RowIndex).Cells("PiecesPerBoxColumnOE").Value = TotalPieces
                    Me.dgvRackingByOrder.Rows(RowIndex).Cells("RackingWeightColumnOE").Value = LineWeight
                    '*********************************************************************************************************
                    Try
                        'Create command to delete selected line
                        cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                        With cmd.Parameters
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = 1
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '*********************************************************************************************************
                        'Update Rack Activity Log
                        'Fill Log Variables
                        LogHeatNumber = HeatNumber
                        LogActivityDateTime = Now()
                        LogCurrentTotalPieces = TotalPieces
                        LogBinNumber = BinNumber
                        LogLotNumber = LotNumber
                        LogPartNumber = PartNumber
                        LogTotalPiecesDifference = TotalPieces - OriginalPieceQuantity
                        LogOriginalTotalPieces = OriginalPieceQuantity
                        LogTransactionType = "UPDATED"
                        LogUserID = EmployeeLoginName
                        LogPickTicketNumber = txtOrderNumber.Text

                        'If no change in pieces, skip activity log
                        If LogTotalPiecesDifference = 0 Then
                            'Skip
                        Else
                            InsertIntoRackingLog()
                        End If
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = "Lift Truck Racking - Rack Transaction - Remove from selected rack"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    Try
                        'Update Racking Master List (records all entries)
                        cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                        With cmd.Parameters
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                            .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                            .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                            .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                            .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                            .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                            .Add("@RackingWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                            .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = RowDivisionID
                        ErrorDescription = "Lift Truck Racking - Racking Master List - changes in datagrid"
                        ErrorReferenceNumber = "Bin # " + BinNumber + ", Part # - " + PartNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '********************************************************************************************************
                    txtEditPieces3.Clear()

                    MsgBox("Rack Updated.", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("You can't remove pieces unless box count = 1 and pieces are greater than the quantity to remove.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If
    End Sub
End Class