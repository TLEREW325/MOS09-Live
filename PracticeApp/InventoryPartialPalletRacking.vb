Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class InventoryPartialPalletRacking
    Inherits System.Windows.Forms.Form

    Const PalletWeight As Double = 36D

    Dim isLoaded As Boolean = False

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async=True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3 As DataSet

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim LoginPCName As String = My.Computer.Name

    Dim bc As New BarcodeLabel
    'Setup for Barcode Label
    Dim LabelFormat(42), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V16, V23 As String
    Dim LabelLines As Integer

    Dim FocusedField As New usefulFunctions.FocusedItem()
    Dim wasDeleted As Boolean = False
    Dim notFinished As Boolean = False

    Dim totalScanTime As Integer
    Dim barcodeScanner As Boolean = False

    Private Class RackSuggestData
        Public Rack As String
        Public LotNumber As String
        Public weight As Double
        Public lst As List(Of String)
        Public Sub New()
        End Sub

        Public Sub New(ByVal rk As String, ByVal lot As String, ByVal wei As Double, ByVal lt As List(Of String))
            Rack = rk
            LotNumber = lot
            weight = wei
            lst = lt
        End Sub
    End Class

    Public Sub New()
        InitializeComponent()
        usefulFunctions.LoadSecurity(Me)
        CalculateEmptyRacks()
        isLoaded = True
    End Sub

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

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvRackingView.CellValueChanged
        Dim LineRackingKey As Integer = 0
        Dim LineRackComment, LineBinNumber, LineDivisionID As String
        Dim LineBoxQuantity, LinePiecesPerBox, LineTotalPieces As Integer
        Dim LinePieceWeight, LineRackingWeight As Double
        Dim LinePartNumber As String = ""
        Dim LinePartDescription As String = ""
        Dim LineHeatNumber As String = ""
        Dim LineLotNumber As String = ""

        If Me.dgvRackingView.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvRackingView.CurrentCell.RowIndex

            Try
                LineRackingKey = Me.dgvRackingView.Rows(RowIndex).Cells("RackingKeyColumn").Value
            Catch ex As Exception
                LineRackingKey = 0
            End Try
            Try
                LineBinNumber = Me.dgvRackingView.Rows(RowIndex).Cells("BinNumberColumn").Value
            Catch ex As Exception
                LineBinNumber = ""
            End Try
            Try
                LineDivisionID = Me.dgvRackingView.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                LineDivisionID = EmployeeCompanyCode
            End Try
            Try
                LineRackComment = Me.dgvRackingView.Rows(RowIndex).Cells("RackCommentColumn").Value
            Catch ex As Exception
                LineRackComment = ""
            End Try
            Try
                LineBoxQuantity = Me.dgvRackingView.Rows(RowIndex).Cells("BoxQuantityColumn").Value
            Catch ex As Exception
                LineBoxQuantity = 0
            End Try
            Try
                LinePiecesPerBox = Me.dgvRackingView.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
            Catch ex As Exception
                LinePiecesPerBox = 0
            End Try
            Try
                LinePieceWeight = Me.dgvRackingView.Rows(RowIndex).Cells("PieceWeightColumn").Value
            Catch ex As Exception
                LinePieceWeight = 0
            End Try
            Try
                LineRackComment = Me.dgvRackingView.Rows(RowIndex).Cells("RackCommentColumn").Value
            Catch ex As Exception
                LineRackComment = ""
            End Try
            Try
                LinePartNumber = Me.dgvRackingView.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                LinePartNumber = ""
            End Try
            Try
                LinePartDescription = Me.dgvRackingView.Rows(RowIndex).Cells("PartDescriptionColumn").Value
            Catch ex As Exception
                LinePartDescription = ""
            End Try
            Try
                LineHeatNumber = Me.dgvRackingView.Rows(RowIndex).Cells("HeatNumberColumn").Value
            Catch ex As Exception
                LineHeatNumber = ""
            End Try
            Try
                LineLotNumber = Me.dgvRackingView.Rows(RowIndex).Cells("LotNumberColumn").Value
            Catch ex As Exception
                LineLotNumber = ""
            End Try

            LineTotalPieces = LineBoxQuantity * LinePiecesPerBox
            LineTotalPieces = Math.Round(LineTotalPieces, 0)

            LineRackingWeight = LineTotalPieces * LinePieceWeight
            LineRackingWeight = Math.Round(LineRackingWeight, 0)

            'Get Previous pieces for this racking key
            Dim OriginalTotalPieces, TotalPieceDifference As Integer

            Dim OriginalTotalPiecesString As String = "SELECT TotalPieces FROM RackingTransactionTable WHERE RackingKey = @RackingKey AND (DivisionID = 'TFP' OR DivisionID = 'TWD')"
            Dim OriginalTotalPiecesCommand As New SqlCommand(OriginalTotalPiecesString, con)
            OriginalTotalPiecesCommand.Parameters.Add("@RackingKey", SqlDbType.VarChar).Value = LineRackingKey
            OriginalTotalPiecesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = LineDivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OriginalTotalPieces = CInt(OriginalTotalPiecesCommand.ExecuteScalar)
            Catch ex As System.Exception
                OriginalTotalPieces = 0
            End Try
            con.Close()

            TotalPieceDifference = LineTotalPieces - OriginalTotalPieces
            '*************************************************************************************************************
            'Update command to racking transaction table
            Try
                'Update Line
                cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate, AddedBy = @AddedBy, Comment = @Comment WHERE RackingKey = @RackingKey", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = LineRackingKey
                    .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivisionID
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = LineBoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = LinePiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = LineTotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = LineRackingWeight
                    .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@Comment", SqlDbType.VarChar).Value = LineRackComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Now()
                ErrorComment = ex.ToString()
                ErrorDivision = LineDivisionID
                ErrorDescription = "FULL PALLET Racking - Racking Transaction Table - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + LineBinNumber + ", Part # - " + LinePartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*************************************************************************************************************
            Try
                'Update Racking Master List (records all entries)
                cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = LineRackingKey
                    .Add("@BinNumber", SqlDbType.VarChar).Value = LineBinNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = LinePartDescription
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = LineHeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = LineLotNumber
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = LineBoxQuantity
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = LinePiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = LineTotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = LineRackingWeight
                    .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivisionID
                    .Add("@CreationDate", SqlDbType.VarChar).Value = Now()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Now()
                ErrorComment = ex.ToString()
                ErrorDivision = LineDivisionID
                ErrorDescription = "FULL PALLET Racking - Racking Master List - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + LineBinNumber + ", Part # - " + LinePartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*************************************************************************************************************
            Try
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

                'Update command to racking activity table
                cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate, PickTicketNumber, LoginComputer) Values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate, @PickTicketNumber, @LoginComputer)", con)

                With cmd.Parameters
                    .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                    .Add("@BinNumber", SqlDbType.VarChar).Value = LineBinNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = LineHeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = LineLotNumber
                    .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = OriginalTotalPieces
                    .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = LineTotalPieces
                    .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = TotalPieceDifference
                    .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivisionID
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "UPDATED"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ""
                    .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                    .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                    .Add("@PickTicketNumber", SqlDbType.VarChar).Value = ""
                    .Add("@LoginComputer", SqlDbType.VarChar).Value = LoginPCName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Now()
                ErrorComment = ex.ToString()
                ErrorDivision = LineDivisionID
                ErrorDescription = "FULL PALLET Racking - Activity Log - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + LineBinNumber + ", Part # - " + LinePartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*************************************************************************************************
       
            isLoaded = False
            ShowData()
            isLoaded = True
        End If
    End Sub

    Private Function canUpdate(ByVal currentRow As Integer)
        If dgvRackingView.Rows(currentRow).Cells("PiecesPerBox").Value Is Nothing Or IsDBNull(dgvRackingView.Rows(currentRow).Cells("PiecesPerBox").Value) Then
            MessageBox.Show("You must enter in a valid number for pieces per box", "Invalid number for pieces per box", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If dgvRackingView.Rows(currentRow).Cells("BoxQuantity").Value Is Nothing Or IsDBNull(dgvRackingView.Rows(currentRow).Cells("BoxQuantity").Value) Then
            MessageBox.Show("You must enter in a valid number of boxes", "Invalid number of boxes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Public Sub ShowData()
        'Loads Rack data
        If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Or EmployeeCompanyCode = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM RackingTransactionQuery WHERE (DivisionID = 'TFP' OR DivisionID = 'TWD') AND PartNumber = @PartNumber ORDER BY BinNumber", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
        Else
            cmd = New SqlCommand("SELECT * FROM RackingTransactionQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber ORDER BY BinNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RackingTransactionQuery")
        dgvRackingView.DataSource = ds.Tables("RackingTransactionQuery")
        con.Close()
    End Sub

    Public Sub CalculateEmptyRacks()
        If EmployeeCompanyCode = "SLC" Then
            'If TFP or TWD, get total number of racks
            Dim CountTotalRacks, CountFilledRacks, CountEmptyRacks As Integer

            Dim CountTotalRacksStatement As String = "SELECT COUNT(BinNumber) FROM BinNumber WHERE DivisionID = 'SLC' AND RackPosition <> 'UNAVAILABLE'"
            Dim CountTotalRacksCommand As New SqlCommand(CountTotalRacksStatement, con)

            Dim CountFilledRacksStatement As String = "SELECT COUNT(DISTINCT(BinNumber)) FROM RackingTransactionTable WHERE DivisionID = 'SLC'"
            Dim CountFilledRacksCommand As New SqlCommand(CountFilledRacksStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTotalRacks = CInt(CountTotalRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountTotalRacks = 0
            End Try
            Try
                CountFilledRacks = CInt(CountFilledRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountFilledRacks = 0
            End Try
            con.Close()

            CountEmptyRacks = CountTotalRacks - CountFilledRacks

            txtEmptyRacks.Text = CountEmptyRacks
        ElseIf EmployeeCompanyCode = "TFF" Then
            'If TFP or TWD, get total number of racks
            Dim CountTotalRacks, CountFilledRacks, CountEmptyRacks As Integer

            Dim CountTotalRacksStatement As String = "SELECT COUNT(BinNumber) FROM BinNumber WHERE DivisionID = 'TFF' AND RackPosition <> 'UNAVAILABLE'"
            Dim CountTotalRacksCommand As New SqlCommand(CountTotalRacksStatement, con)

            Dim CountFilledRacksStatement As String = "SELECT COUNT(DISTINCT(BinNumber)) FROM RackingTransactionTable WHERE DivisionID = 'TFF'"
            Dim CountFilledRacksCommand As New SqlCommand(CountFilledRacksStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTotalRacks = CInt(CountTotalRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountTotalRacks = 0
            End Try
            Try
                CountFilledRacks = CInt(CountFilledRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountFilledRacks = 0
            End Try
            con.Close()

            CountEmptyRacks = CountTotalRacks - CountFilledRacks

            txtEmptyRacks.Text = CountEmptyRacks
        Else
            'If TFP or TWD, get total number of racks
            Dim CountTotalRacks, CountFilledRacks, CountEmptyRacks As Integer
            Dim ActualEmptyRackCount As Integer = 0

            Dim CountTotalRacksStatement As String = "SELECT COUNT(BinNumber) FROM BinNumber WHERE DivisionID <> 'SLC' AND RackPosition <> 'UNAVAILABLE' AND BinNumber NOT LIKE 'FL%' AND BinNumber NOT LIKE 'PF%'"
            Dim CountTotalRacksCommand As New SqlCommand(CountTotalRacksStatement, con)

            Dim CountFilledRacksStatement As String = "SELECT COUNT(DISTINCT(BinNumber)) FROM RackingTransactionTable WHERE DivisionID <> 'SLC'"
            Dim CountFilledRacksCommand As New SqlCommand(CountFilledRacksStatement, con)

            Dim ActualEmptyRackCountStatement As String = "SELECT COUNT(BinNumber) FROM EmptyBinQueryTWD"
            Dim ActualEmptyRackCountCommand As New SqlCommand(ActualEmptyRackCountStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTotalRacks = CInt(CountTotalRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountTotalRacks = 0
            End Try
            Try
                CountFilledRacks = CInt(CountFilledRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountFilledRacks = 0
            End Try
            Try
                ActualEmptyRackCount = CInt(ActualEmptyRackCountCommand.ExecuteScalar)
            Catch ex As Exception
                ActualEmptyRackCount = 0
            End Try
            con.Close()

            CountEmptyRacks = CountTotalRacks - CountFilledRacks

            If CountEmptyRacks <> ActualEmptyRackCount Then
                txtEmptyRacks.Text = ActualEmptyRackCount
            Else
                txtEmptyRacks.Text = ActualEmptyRackCount
            End If
        End If
    End Sub

    Public Function LoadLotNumberData() As String
        Dim PartNumber, HeatNumber, BoxType As String
        Dim BoxPieces, PalletCount As Integer
        Dim BoxWeight As Double
        Dim divisionID As String = ""

        Try
            Dim cmd As New SqlCommand("SELECT PartNumber, HeatNumber, BoxCount, BoxWeight, BoxType, PalletCount, DivisionID FROM LotNumber WHERE LotNumber = @LotNumber;", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("PartNumber")) Then
                    PartNumber = ""
                Else
                    PartNumber = reader.Item("PartNumber")
                End If
                If IsDBNull(reader.Item("HeatNumber")) Then
                    HeatNumber = ""
                Else
                    HeatNumber = reader.Item("HeatNumber")
                End If
                If IsDBNull(reader.Item("BoxCount")) Then
                    BoxPieces = 0
                Else
                    BoxPieces = reader.Item("BoxCount")
                End If
                If IsDBNull(reader.Item("BoxWeight")) Then
                    BoxWeight = 0D
                Else
                    BoxWeight = reader.Item("BoxWeight")
                End If
                If IsDBNull(reader.Item("BoxType")) Then
                    BoxType = "Z"
                Else
                    BoxType = reader.Item("BoxType")
                End If
                If IsDBNull(reader.Item("PalletCount")) Then
                    PalletCount = 0
                Else
                    PalletCount = reader.Item("PalletCount")
                End If
                If IsDBNull(reader.Item("DivisionID")) Then
                    divisionID = "TWD"
                Else
                    divisionID = reader.Item("DivisionID")
                End If
            Else
                BoxType = ""
                HeatNumber = ""
                PartNumber = ""
                PalletCount = 0
                divisionID = "TWD"
            End If
            reader.Close()
            con.Close()

            txtBoxPieces.Text = BoxPieces
            txtBoxWeight.Text = BoxWeight
            txtBoxCount.Text = PalletCount
            txtContainer.Text = BoxType
            txtHeatNumber.Text = HeatNumber
            txtPartNumber.Text = PartNumber
        Catch ex As System.Exception
            MessageBox.Show("Something went wrong" + Environment.NewLine + ex.ToString(), "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return divisionID
    End Function

    Public Sub DeterminePartCodeType(ByVal DivisionID As String)
        'Determine Part Code Type and load Preferential Racks
        Dim PartNumber01, PartCode As String
        If Not DivisionID.Equals("TFP") Then
            PartNumber01 = txtPartNumber.Text
            If PartNumber01.Length > 4 Then
                Select Case PartNumber01.Substring(0, 2)
                    Case "CA", "SC"
                        PartCode = PartNumber01.Substring(0, 4)
                    Case "CD", "CS", "IT", "NT", "TD", "TP", "TR", "TT", "RB", "PS", "FE"
                        PartCode = PartNumber01.Substring(0, 2)
                    Case "DS", "DB"
                        PartCode = PartNumber01.Substring(0, 2) & PartNumber01.Substring(3, 2)
                    Case Else
                        If Not DivisionID.Equals("TWD") Then
                            PartCode = PartNumber01
                        Else
                            PartCode = ""
                        End If
                End Select
            Else
                PartCode = ""
            End If
        Else
            PartCode = "TFP"
        End If
        '**************************************************************************************
        If Not String.IsNullOrEmpty(PartCode) Then
            '*****************************************************************************************
            'Code to determine which Empty Bin Query to use
            Dim TableDivision As String = ""

            If DivisionID = "SLC" Then
                TableDivision = "SLC"
            ElseIf DivisionID = "TFF" Then
                TableDivision = "TFF"
            ElseIf DivisionID = "TWD" Then
                TableDivision = "TWD"
            ElseIf DivisionID = "TFP" Then
                TableDivision = "TWD"
            ElseIf DivisionID = "ADM" Then
                TableDivision = "TWD"
            Else
                TableDivision = "TWD"
            End If
            '*****************************************************************************************
            cmd = New SqlCommand("EXEC AvailableRackingLocationLookup @DivisionID = @DivisionID, @RowName = @RowName, @BarWeightOpen = @BarWeightOpen, @Box = @Box, @PartNumber = @PartNumber", con)
            cmd.Parameters.Add("@RowName", SqlDbType.VarChar).Value = PartCode
            cmd.Parameters.Add("@BarWeightOpen", SqlDbType.VarChar).Value = Val(txtTotalWeight.Text) + PalletWeight
            cmd.Parameters.Add("@Box", SqlDbType.VarChar).Value = txtContainer.Text
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID

            myAdapter2.SelectCommand = cmd
            ds2 = New DataSet()

            'Populate text field with empty bin numbers only
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                myAdapter2.Fill(ds2, "EmptyBinQuery" + TableDivision)
            Catch ex As Exception
                sendErrorToDataBase("InventoryPartialPalletRacking - DeterminePartCodeType --Error Looking up an empty location", "Lot " + txtLotNumber.Text, ex.ToString())
            End Try

            '*****************************************************************************************
            ''If no bins are prefered, this will suggest up to 50 from the list of bins
            If ds2.Tables("EmptyBinQuery" + TableDivision).Rows.Count = 0 Then
                Dim DivisionString As String = " DivisionID = '" + EmployeeCompanyCode + "'"
                If DivisionID.Equals("TWD") Or DivisionID.Equals("TFP") Then
                    DivisionString = " (DivisionID = 'TWD' OR DivisionID = 'TFP')"
                End If
                cmd = New SqlCommand("DECLARE @BoxType as varchar(50) = CASE WHEN EXISTS(SELECT BoxTypeID FROM BoxType WHERE BoxTypeID = @Box) THEN (SELECT ItemID FROM BoxType WHERE BoxTypeID = @Box) ELSE (Select @Box) END, @Pref18 as varchar(10); SELECT TOP 50 PossibleLocations.BinNumber FROM (SELECT BinNumber,PartnerBinNumber, MaxBarWeight FROM BinNumber WHERE BinNumber Not IN (SELECT BinNumber FROM (SELECT BinNumber FROM RackingTransactionTable WHERE " + DivisionString + ") AS RackingTrans UNION (SELECT BinNumber FROM BinNumberBoxPref WHERE BoxType = @BoxType AND CanFit = 'False' AND  " + DivisionString + ")) AND RackPosition <> 'UNAVAILABLE' AND " + DivisionString + ") as PossibleLocations  LEFT OUTER JOIN (SELECT BinNumber, SUM(RackingWeight) as TotalWeight FROM RackingTransactionTable WHERE DivisionID = @DivisionID AND BinNumber in (SELECT PartnerBinNumber FROM BinNumber WHERE BinNumber Not IN (SELECT BinNumber FROM RackingTransactionTable WHERE " + DivisionString + ") AND RackPosition <> 'UNAVAILABLE' AND " + DivisionString + ") GROUP BY BinNumber) as PartnerLocation ON PossibleLocations.PartnerBinNumber = PartnerLocation.BinNumber WHERE isnull(PartnerLocation.TotalWeight, 0) + @BarWeightOpen < PossibleLocations.MaxBarWeight ORDER BY PossibleLocations.BinNumber", con)
                cmd.Parameters.Add("@BarWeightOpen", SqlDbType.VarChar).Value = Val(txtTotalWeight.Text) + PalletWeight
                cmd.Parameters.Add("@Box", SqlDbType.VarChar).Value = txtContainer.Text
                If DivisionID.Equals("TWD") Or DivisionID.Equals("TFP") Then

                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                End If
                myAdapter2.SelectCommand = cmd
                If con.State = ConnectionState.Closed Then con.Open()
                myAdapter2.Fill(ds2, "EmptyBinQuery" + TableDivision)
            End If
            con.Close()
            '*******************************************************************************************
            cboRackNumber.DisplayMember = "BinNumber"
            cboRackNumber.DataSource = ds2.Tables("EmptyBinQuery" + TableDivision)

            If cboRackNumber.Items.Count > 0 Then
                cboRackNumber.SelectedIndex = 0
            Else
                cboRackNumber.SelectedIndex = -1
            End If
        Else

        End If
    End Sub

    Public Sub LoadPartDescription()
        Dim PartDescription As String
        Dim PartDescriptionString As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND"
        Dim PartDescriptionCommand As New SqlCommand(PartDescriptionString, con)
        PartDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text
        If EmployeeCompanyCode.Equals("TWD") Or EmployeeCompanyCode.Equals("TFP") Then
            PartDescriptionCommand.CommandText += " (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Else
            PartDescriptionCommand.CommandText += " DivisionID = @DivisionID"
            PartDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
        Catch ex As System.Exception
            PartDescription = ""
        End Try
        con.Close()

        txtPartDescription.Text = PartDescription
    End Sub

    Public Sub ClearData()
        txtLotNumber.Clear()
        cboRackNumber.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboRackNumber.Text) Then
            cboRackNumber.Text = ""
        End If

        cboRackNumber.DataSource = Nothing

        txtPartNumber.Clear()
        txtHeatNumber.Clear()
        txtBoxCount.Clear()
        txtBoxPieces.Clear()
        txtBoxWeight.Clear()
        txtContainer.Clear()
        txtPartDescription.Clear()
        txtTotalWeight.Clear()
        txtLabelCount.Text = "1"
        dtpInventoryDate.Text = Today()

        txtLotNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        barcodeScanner = False
    End Sub

    Private Sub cmdAddToRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToRack.Click
        If canAddToRack() Then
            Try
                Dim TotalPieces As Double = Convert.ToInt32(txtBoxCount.Text) * Convert.ToInt32(txtBoxPieces.Text)
                Dim TotalNewPalletWeight As Double = TotalPieces
                Dim PieceWeight As Double = 0
                Dim PartnerLocationTotalWeight As Double = 0
                Dim MaxBarWeight As Double = 0
                Dim PartnerBinLocation As String = ""

                ''calculates the total weight of the new item to be added
                TotalNewPalletWeight = Convert.ToDecimal(txtTotalWeight.Text)

                'Get MAX Weight for SLC
                If EmployeeCompanyCode = "SLC" Then
                    'Gets the partner bin location
                    Dim PartnerBinLocationStatement As String = "SELECT PartnerBinNumber FROM BinNumber WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
                    Dim PartnerBinLocationCommand As New SqlCommand(PartnerBinLocationStatement, con)
                    PartnerBinLocationCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
                    PartnerBinLocationCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PartnerBinLocation = CStr(PartnerBinLocationCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        PartnerBinLocation = ""
                    End Try
                    con.Close()

                    If PartnerBinLocation = "" Then
                        PartnerLocationTotalWeight = 0
                    Else
                        'Gets the total rack weight of the partner bin
                        Dim GetBinRackWeightStatement As String = "SELECT SUM(RackingWeight) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
                        Dim GetBinRackWeightCommand As New SqlCommand(GetBinRackWeightStatement, con)
                        GetBinRackWeightCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = PartnerBinLocation
                        GetBinRackWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            PartnerLocationTotalWeight = CDbl(GetBinRackWeightCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            PartnerLocationTotalWeight = 0
                        End Try
                        con.Close()
                    End If

                    'Gets the MAX Bar Weight of the Bin
                    Dim GetMAXBarWeightStatement As String = "SELECT MaxBarWeight FROM BinNumber WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
                    Dim GetMAXBarWeightCommand As New SqlCommand(GetMAXBarWeightStatement, con)
                    GetMAXBarWeightCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
                    GetMAXBarWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxBarWeight = CDbl(GetMAXBarWeightCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        MaxBarWeight = 0
                    End Try
                    con.Close()
                ElseIf EmployeeCompanyCode = "TFF" Then
                    'Gets Partner Bin Location








                Else
                    'Gets the partner bin location
                    Dim PartnerBinLocationStatement As String = "SELECT PartnerBinNumber FROM BinNumber WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
                    Dim PartnerBinLocationCommand As New SqlCommand(PartnerBinLocationStatement, con)
                    PartnerBinLocationCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
                    PartnerBinLocationCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PartnerBinLocation = CStr(PartnerBinLocationCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        PartnerBinLocation = ""
                    End Try
                    con.Close()

                    If PartnerBinLocation = "" Then
                        PartnerLocationTotalWeight = 0
                    Else
                        'Gets the total rack weight of the partner bin
                        Dim GetBinRackWeightStatement As String = "SELECT SUM(RackingWeight) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID <> @DivisionID"
                        Dim GetBinRackWeightCommand As New SqlCommand(GetBinRackWeightStatement, con)
                        GetBinRackWeightCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = PartnerBinLocation
                        GetBinRackWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            PartnerLocationTotalWeight = CDbl(GetBinRackWeightCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            PartnerLocationTotalWeight = 0
                        End Try
                        con.Close()
                    End If

                    'Gets the MAX Bar Weight of the Bin
                    Dim GetMAXBarWeightStatement As String = "SELECT MaxBarWeight FROM BinNumber WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
                    Dim GetMAXBarWeightCommand As New SqlCommand(GetMAXBarWeightStatement, con)
                    GetMAXBarWeightCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
                    GetMAXBarWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxBarWeight = CDbl(GetMAXBarWeightCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        MaxBarWeight = 0
                    End Try
                    con.Close()
                End If

                'Verify that Pallet Weight on the crossbar is less than MAX Bar Weighht

                If PartnerLocationTotalWeight + TotalNewPalletWeight < MaxBarWeight Then
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
                    '********************************************************************************************************************************************
                    'Create commands to populate database
                    Dim divisionID As String = ""
                    cmd = New SqlCommand("", con)
                    If EmployeeCompanyCode.Equals("TWD") Or EmployeeCompanyCode.Equals("TFP") Or EmployeeCompanyCode.Equals("ADM") Then
                        cmd.CommandText += "DECLARE @DivisionID as varchar(50) = (SELECT TOP 1 DivisionID FROM ItemList WHERE ItemID = @PartNumber AND (DivisionID = 'TWD' OR DivisionID = 'TFP'));"
                    Else
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    End If
                    ''gets the next key that is to be used
                    cmd.CommandText += " BEGIN TRAN DECLARE @RackingKey as int = CASE WHEN EXISTS(SELECT MAX(isnull(RackingKey, 661000)) + 1 FROM RackingMasterList) THEN (SELECT MAX(isnull(RackingKey, 661000)) + 1 FROM RackingMasterList) ELSE 66001 END;"
                    ''adds the entry into the master list
                    cmd.CommandText += " INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate)"
                    cmd.CommandText += " VALUES (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)"
                    ''Adds the row into the transaction table
                    cmd.CommandText += " INSERT INTO RackingTransactionTable (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, ActivityDate, DivisionID, CreationDate, AddedBy)"
                    cmd.CommandText += " VALUES (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @CreationDate, @DivisionID, @CreationDate, @UserID)"
                    cmd.CommandText += " COMMIT TRAN;"
                    cmd.CommandText += " INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate, PickTicketNumber, LoginComputer)"
                    cmd.CommandText += " VALUES(@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, 0, @TotalPieces,  @TotalPieces, @DivisionID, 'CREATED', @UserID, @ReferenceNumber, @RackTime, @RackDate, @PickTicketNumber, @LoginComputer)"

                    With cmd.Parameters
                        .Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = txtPartDescription.Text
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
                        .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                        .Add("@BoxQuantity", SqlDbType.VarChar).Value = txtBoxCount.Text
                        .Add("@PiecesPerBox", SqlDbType.VarChar).Value = txtBoxPieces.Text
                        .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                        .Add("@ActivityDate", SqlDbType.VarChar).Value = dtpInventoryDate.Value
                        .Add("@RackingWeight", SqlDbType.VarChar).Value = TotalNewPalletWeight
                        .Add("@CreationDate", SqlDbType.VarChar).Value = dtpInventoryDate.Value
                        .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ""
                        .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                        .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                        .Add("@PickTicketNumber", SqlDbType.VarChar).Value = ""
                        .Add("@LoginComputer", SqlDbType.VarChar).Value = LoginPCName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New SqlCommand("SELECT PalletCount FROM LotNumber WHERE LotNumber = @LotNumber;", con)
                    cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim obj As Object = cmd.ExecuteScalar()
                    con.Close()

                    'Skip if label count = 0
                    If txtLabelCount.Text = "0" Or Val(txtLabelCount.Text) = 0 Then
                        'Skip Label
                    Else
                        Dim palletpcs As Integer = Val(txtBoxCount.Text) * Val(txtBoxPieces.Text)
                        Dim palletwt As Integer = Math.Ceiling(Val(txtBoxCount.Text) * Val(txtBoxWeight.Text))
                        Dim stand As New BarcodeLabel.standardLabel

                        'Fill barcode variable data ---
                        If Val(txtLabelCount.Text) > 0 Then
                            If Not IsDBNull(obj) AndAlso obj IsNot Nothing And obj = Val(txtBoxCount.Text) Then
                                V04 = "FULL PALLET"
                            Else
                                V04 = "PARTIAL PALLET"
                            End If

                            If txtPartDescription.Text.Length > 30 Then
                                V05 = txtPartDescription.Text.Substring(0, 30)
                                If txtPartDescription.Text.Length > 60 Then
                                    V06 = txtPartDescription.Text.Substring(30, 30)
                                Else
                                    V06 = txtPartDescription.Text.Substring(30, txtPartDescription.Text.Length - 30)
                                End If
                            Else
                                V05 = txtPartDescription.Text
                                V06 = ""
                            End If
                            V00 = "P" + txtPartNumber.Text
                            V01 = "Q" + palletpcs.ToString()
                            V02 = "W" + palletwt.ToString()
                            V16 = "EH" + txtHeatNumber.Text
                            V09 = Today()
                            V03 = "S" + txtLotNumber.Text
                            V23 = cboRackNumber.Text

                            stand.description1 = V04
                            If V05 Is Nothing Then
                                stand.description2 = ""
                            Else
                                stand.description2 = V05
                            End If
                            If V06 Is Nothing Then
                                stand.description3 = ""
                            Else
                                stand.description3 = V06
                            End If

                            stand.partNumber = V00
                            stand.quantityPerPallet = V01
                            stand.weightPerPallet = V02
                            stand.heat = V16
                            stand.dat = V09
                            stand.serialLotNumber = V03
                            stand.rackLocation = V23
                            bc.clearFormat()
                            bc.standardLabelSetup(stand, Val(txtLabelCount.Text))
                            bc.PrintBarcodeLine("Zebra" + EmployeeCompanyCode)
                        End If

                        If EmployeeCompanyCode.Equals("TWD") Or EmployeeCompanyCode.Equals("TFP") Then
                            bc.PalletBinLabelSetup(cboRackNumber.Text, 1)
                            bc.PrintBarcodeLine("Zebra" + EmployeeCompanyCode)
                        End If
                    End If
                    '***************************************************
                    'Clear text fields for next entry
                    CalculateEmptyRacks()
                    ClearData()
                    isLoaded = False
                    ShowData()
                    isLoaded = True
                    txtLotNumber.Focus()
                Else
                    con.Close()
                    ''prints message saying the cross weight will be over the weight restriction
                    Dim totalWeight As Decimal = TotalNewPalletWeight + PartnerLocationTotalWeight
                    MessageBox.Show("Max Cross Weight exceded when trying to add to " + cboRackNumber.Text + " location" + Environment.NewLine + "Current cross weight is " + PartnerLocationTotalWeight.ToString() + " of " + MaxBarWeight.ToString() + Environment.NewLine + "new weight would of been " + totalWeight.ToString(), "Over weight", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As System.Exception
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

                MessageBox.Show("There was an error processing your addition to the racking" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function canAddToRack()
        If String.IsNullOrEmpty(txtLotNumber.Text) Then
            Return False
        End If
        cmd = New SqlCommand("SELECT isnull(Status,'OPEN') as Status, isnull(QCInspected, '') as QCInspected FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            If reader.Item("Status").Equals("OPEN") Then
                reader.Close()
                con.Close()
                MessageBox.Show("Lot entered has not been completed by QC. Contact QC, unable to print labels.", "Unable to proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            If EmployeeCompanyCode.Equals("TWD") Or EmployeeCompanyCode.Equals("TFP") Or EmployeeCompanyCode.Equals("TST") Then
                If reader.Item("QCInspected").Equals("NO") Then
                    reader.Close()
                    con.Close()
                    MessageBox.Show("Lot has not been checked for final piece inspection. Contact QC, to perform final piece inspection.", "Unable to proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End If
        Else
            reader.Close()
            con.Close()
            MessageBox.Show("Lot does not exist.", "Unable to proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        reader.Close()
        con.Close()
        If String.IsNullOrEmpty(txtPartNumber.Text) Then
            MessageBox.Show("You have to have a part number entered", "Must enter a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBoxCount.Text) Then
            MessageBox.Show("You must enter a quantity for boxes", "Must enter quantity for boxes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBoxCount.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBoxPieces.Text) Then
            MessageBox.Show("You must enter a quantity for boxes", "Must enter quantity for boxes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBoxPieces.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBoxWeight.Text) Then
            MessageBox.Show("You must enter in a weight per box", "Must enter in a wweight per box", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBoxWeight.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTotalWeight.Text) Then
            MessageBox.Show("You must have a total weight entered", "Must enter total weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTotalWeight.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtHeatNumber.Text) Then
            MessageBox.Show("You must have a heat number entered", "Must enter a heat number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHeatNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboRackNumber.Text) Then
            MessageBox.Show("You must select a rack location for this item", "Must select rack location", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        '*************************************************************************
        cmd = New SqlCommand("SELECT BinNumber FROM BinNumber WHERE BinNumber = @BinNumber AND RackPosition <> 'UNAVAILABLE'", con)
        cmd.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        reader = cmd.ExecuteReader()
        If reader.HasRows() = False Then
            reader.Close()
            con.Close()
            MessageBox.Show("Bin Location does not exist or is unavailable", "Bin Location does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            reader.Close()
        End If
        '****************************************************************************
        'Check Rack for existing items
        Dim CheckRackCount As Integer = 0

        Dim CheckRackCountCommand As New SqlCommand("", con)
        If EmployeeCompanyCode.Equals("TWD") Or EmployeeCompanyCode.Equals("TFP") Then
            CheckRackCountCommand.CommandText = "SELECT COUNT(RackingKey) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Else
            CheckRackCountCommand.CommandText = "SELECT COUNT(RackingKey) FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID"
            CheckRackCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End If

        CheckRackCountCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckRackCount = CInt(CheckRackCountCommand.ExecuteScalar)
        Catch ex As Exception
            CheckRackCount = 0
        End Try
        con.Close()

        If CheckRackCount > 0 Then
            Dim button As DialogResult = MessageBox.Show("Rack Location already has items. Do you wish to add anyways?", "CHECK RACKING", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Return True
            ElseIf button = DialogResult.No Then
                Return False
            End If
        End If
        '*************************************************************************
        If String.IsNullOrEmpty(txtLabelCount.Text) Then
            txtLabelCount.Text = "1"
        End If

        Return True
    End Function

    Private Sub txtPartNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartNumber.TextChanged
        If isLoaded Then
            LoadPartDescription()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalPrintRackingType = "PrintListing"
        GDS = ds
        Using newprintrackingbyfilter As New PrintRackingByFilter
            Dim result = newprintrackingbyfilter.ShowDialog()
        End Using
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        GDS = ds
        Using NewPrintRackingByFilter As New PrintRackingByFilter
            Dim Result = NewPrintRackingByFilter.ShowDialog()
        End Using
    End Sub

    Private Sub cmdClearLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLotNumber.Click, ClearToolStripMenuItem.Click
        CalculateEmptyRacks()
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click, cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub txtLotNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLotNumber.KeyUp
        If barcodeScanner And e.KeyCode = Keys.Enter Then
            tmrScanTime.Stop()
            barcodeScanner = False
            isLoaded = False
            isLoaded = True
        End If
        If e.KeyCode = Keys.Enter Then
            txtBoxCount.Focus()
        End If
    End Sub

    Private Sub dtpInventoryDate_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpInventoryDate.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboRackNumber.Focus()
        End If
    End Sub

    Private Sub cboRackNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRackNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            usefulFunctions.CheckBinNumber(sender)
            cmdAddToRack.Focus()
        End If
    End Sub

    Private Sub dgvRackingView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvRackingView.DataError
        If isLoaded Then
            If dgvRackingView.Rows.Count > 0 Then
                If e.Exception.Message.ToString().Contains("Input string was not in a correct") Then
                    dgvRackingView.RefreshEdit()
                End If
            End If
        End If
    End Sub

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub addText(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal tex As String, Optional ByVal charCount As Integer = 1)
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to see if there is a selection
            If FocusedField.SelectionLength > 0 Then
                cmdBackspace_Click(sender, e)
            End If
            If FocusedField.Position = FocusedField.Text.Length Then
                FocusedField.Text += tex
            Else
                If FocusedField.Position > FocusedField.Text.Length Then
                    FocusedField.Position = FocusedField.Text.Length
                End If
                FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + tex + FocusedField.Text.Substring(FocusedField.Position, FocusedField.Text.Length - FocusedField.Position)
            End If
            If charCount > 1 Then
                FocusedField.Position += charCount - 1
            End If
            If FocusedField.Position = 0 Then
                FocusedField.Position = 1
            End If
            FocusedField.Focus()
        End If
    End Sub

    Private Sub cmdBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to make sure there is something to delete
            If FocusedField.Text.Length > 0 Then
                wasDeleted = True
                ''check to see if there was a selection made
                If FocusedField.SelectionLength > 0 Then
                    Select Case True
                        Case FocusedField.SelectionLength = FocusedField.Text.Length
                            FocusedField.Text = ""
                            FocusedField.Position = 0
                            Exit Select
                        Case FocusedField.Position = 0
                            FocusedField.Text = FocusedField.Text.Substring(FocusedField.SelectionLength, FocusedField.Text.Length - FocusedField.SelectionLength)
                            Exit Select
                        Case FocusedField.SelectionLength = (FocusedField.Text.Length - FocusedField.Position)
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position)
                            FocusedField.Position = FocusedField.Text.Length
                            Exit Select
                        Case Else
                            If FocusedField.Position > FocusedField.Text.Length Then
                                FocusedField.Position = FocusedField.Text.Length
                            End If
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + FocusedField.Text.Substring(FocusedField.Position + FocusedField.SelectionLength, FocusedField.Text.Length - (FocusedField.Position + FocusedField.SelectionLength))
                    End Select
                    FocusedField.SelectionLength = 0
                Else
                    ''check to se if we are at the back of the text
                    If FocusedField.Position = FocusedField.Text.Length Then
                        FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Text.Length - 1)
                        FocusedField.Position = FocusedField.Text.Length
                    Else
                        If FocusedField.Position > 0 Then
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position - 1)
                            FocusedField.Position -= 1
                        End If
                    End If
                End If
            End If
            FocusedField.Focus()
        End If
    End Sub

    Private Sub hideSuggest(ByVal ctrl As String)
        If Not String.IsNullOrEmpty(ctrl) Then
            Select Case ctrl
                Case "cboLotNumber"
                    lstLotSuggest.Visible = False
            End Select
        End If
    End Sub

    Private Sub txtLotNumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLotNumber.Enter
        If FocusedField.isSet() Then
            If FocusedField.Name.Equals("txtLotNumber") Then
                txtLotNumber.SelectionStart = FocusedField.Position
            Else
                FocusedField = New FocusedItem(txtLotNumber)
            End If
        Else
            FocusedField = New FocusedItem(txtLotNumber)
        End If
    End Sub

    Private Sub cboLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLotNumber.TextChanged
        If isLoaded Then
            If txtLotNumber.Focused Then
                FocusedField.Position = txtLotNumber.SelectionStart
                FocusedField.SelectionLength = 0
                If wasDeleted Then
                    wasDeleted = False
                End If
            Else
                If Not wasDeleted Then
                    FocusedField.Position += 1
                Else
                    wasDeleted = False
                End If
            End If
            If canSuggestLot() Then
                While bgwkLotSuggest.IsBusy
                    Exit Sub
                End While
                If lstLotSuggest.Visible Then
                    lstLotSuggest.Visible = False
                End If
                lstLotSuggest.Items.Clear()
                If bgwkLotSuggest.IsBusy Then
                    bgwkLotSuggest.CancelAsync()
                End If
                While bgwkLotSuggest.IsBusy
                    System.Windows.Forms.Application.DoEvents()
                End While
                bgwkLotSuggest.RunWorkerAsync(txtLotNumber.Text)
            End If
        End If
    End Sub

    Private Function canSuggestLot() As Boolean
        If barcodeScanner Then
            Return False
        End If
        If String.IsNullOrEmpty(FocusedField.Name) Then
            Return False
        End If
        If Not FocusedField.Name.Equals("txtLotNumber") Then
            Return False
        End If
        If txtLotNumber.Text.Length < 4 Then
            Return False
        End If
        Return True
    End Function

    Private Sub formatListbox(ByRef lstbx As System.Windows.Forms.ListBox)
        If lstbx.Items.Count < 5 Then
            If lstbx.Items.Count = 0 Then
                lstbx.Height = 40
            Else
                lstbx.Height = lstbx.Items.Count * 40
            End If
        Else
            lstbx.Height = 5 * 20
        End If
        If FocusedField.Name.Equals("txtLotNumber") Then
            lstbx.Visible = True
        End If
    End Sub

    Private Sub cboRackNumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRackNumber.Enter
        If FocusedField.isSet() Then
            If FocusedField.Name.Equals("cboRackNumber") Then
                cboRackNumber.SelectionStart = FocusedField.Position
            Else
                FocusedField = New FocusedItem(cboRackNumber)
            End If
        Else
            FocusedField = New FocusedItem(cboRackNumber)
        End If
    End Sub

    Private Sub lstLotSuggest_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLotSuggest.SelectedValueChanged
        If lstLotSuggest.Visible Then
            If Not String.IsNullOrEmpty(lstLotSuggest.SelectedItem) Then
                FocusedField = New FocusedItem()
                txtLotNumber.Text = lstLotSuggest.SelectedItem
                lstLotSuggest.Visible = False
                LoadLotNumberData()
                isLoaded = False
                ShowData()
                isLoaded = True
                txtBoxCount.Focus()
            End If
        End If
    End Sub

    Private Sub bgwkLotSuggest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkLotSuggest.DoWork
        Dim lst As New List(Of String)
        cmd1 = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE LotNumber Like @LotNumber;", con1)
        cmd1.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = e.Argument.ToString() + "%"
        If con1.State = ConnectionState.Closed Then con1.Open()
        Dim reader As SqlDataReader = cmd1.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If bgwkLotSuggest.CancellationPending() Then
                    Exit While
                End If
                lst.Add(reader.Item("LotNumber"))
            End While
        End If
        reader.Close()
        con1.Close()

        e.Result = lst
    End Sub

    Private Sub bgwkLotSuggest_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkLotSuggest.RunWorkerCompleted
        If e.Cancelled Then
            Exit Sub
        End If
        Dim lst As List(Of String) = e.Result
        For i As Integer = 0 To lst.Count - 1
            lstLotSuggest.Items.Add(lst(i))
        Next
        formatListbox(lstLotSuggest)
    End Sub

    Private Sub cboRackNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRackNumber.TextChanged
        If isLoaded Then
            If cboRackNumber.Focused Then
                If cboRackNumber.Text.Length >= 2 And cboRackNumber.Text.Length < 5 Then
                    If bgwkRackingSuggest.IsBusy Then
                        If Not bgwkRackingSuggest.CancellationPending Then
                            bgwkRackingSuggest.CancelAsync()
                        End If
                        While bgwkRackingSuggest.IsBusy
                            System.Threading.Thread.Sleep(500)
                        End While
                    End If
                    If cboRackNumber.Text.Length > 2 Then
                        Dim lst As New List(Of String)
                        For i As Integer = 0 To lstRackSuggest.Items.Count - 1
                            lst.Add(lstRackSuggest.Items(i))
                        Next
                        bgwkRackingSuggest.RunWorkerAsync(New RackSuggestData(cboRackNumber.Text, txtLotNumber.Text, Val(txtTotalWeight.Text), lst))
                    Else
                        bgwkRackingSuggest.RunWorkerAsync(New RackSuggestData(cboRackNumber.Text, txtLotNumber.Text, Val(txtTotalWeight.Text), New List(Of String)))
                    End If
                Else
                    If cboRackNumber.Text.Length = 5 Then
                        If lstRackSuggest.Visible Then
                            lstRackSuggest.Hide()
                        End If
                    End If
                End If

                FocusedField.Position = cboRackNumber.SelectionStart
                FocusedField.SelectionLength = 0
                If wasDeleted Then
                    wasDeleted = False
                End If
            Else
                If Not wasDeleted Then
                    FocusedField.Position += 1
                Else
                    wasDeleted = False
                End If
            End If
        End If
    End Sub

    Private Sub txtLotNumber_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLotNumber.MouseUp
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Name.Equals("txtLotNumber") Then
                FocusedField.Position = txtLotNumber.SelectionStart
                FocusedField.SelectionLength = txtLotNumber.SelectionLength
            End If
        End If
    End Sub

    Private Sub cboRackNumber_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboRackNumber.MouseUp
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Name.Equals("cboRackNumber") Then
                FocusedField.Position = cboRackNumber.SelectionStart
                FocusedField.SelectionLength = cboRackNumber.SelectionLength
            End If
        End If
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case FocusedField.Name
            Case "txtLotNumber"
                If lstLotSuggest.Items.Count = 1 Then
                    If Not txtLotNumber.Text.Equals(lstLotSuggest.Items(0)) Then
                        txtLotNumber.Text = lstLotSuggest.Items(0)
                    End If
                End If
                cmdAddToRack.Focus()
            Case "txtBoxCount"
                txtBoxPieces.Focus()
            Case "txtBoxPieces"
                cboRackNumber.Focus()
            Case "cboRackNumber"
                cmdAddToRack.Focus()
        End Select
    End Sub

    Private Sub txtBoxCount_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxCount.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtBoxPieces.Focus()
        End If
    End Sub

    Private Sub txtBoxCount_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxCount.Enter
        If lstLotSuggest.Visible Then
            lstLotSuggest.Visible = False
        End If

        If FocusedField.isSet() Then
            If FocusedField.Name.Equals("txtBoxCount") Then
                txtBoxCount.SelectionStart = FocusedField.Position
            Else
                txtBoxCount.SelectAll()
                FocusedField = New FocusedItem(txtBoxCount)
            End If
        Else
            txtBoxCount.SelectAll()
            FocusedField = New FocusedItem(txtBoxCount)
        End If
    End Sub

    Private Sub txtBoxCount_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBoxCount.MouseUp
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Name.Equals("txtBoxCount") Then
                FocusedField.Position = txtBoxCount.SelectionStart
                FocusedField.SelectionLength = txtBoxCount.SelectionLength
            End If
        End If
    End Sub

    Private Sub txtBoxCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxCount.TextChanged
        If isLoaded Then
            If txtBoxCount.Focused Then
                FocusedField.Position = txtBoxCount.SelectionStart
                FocusedField.SelectionLength = 0
                If wasDeleted Then
                    wasDeleted = False
                End If
            Else
                If Not wasDeleted Then
                    FocusedField.Position += 1
                Else
                    wasDeleted = False
                End If
            End If
            txtTotalWeight.Text = (Val(txtBoxWeight.Text) * Val(txtBoxCount.Text)).ToString()
        End If
    End Sub

    Private Sub txtLabelCount_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLabelCount.Enter
        txtLabelCount.SelectAll()
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("txtLabelCount") Then
                FocusedField = New FocusedItem(txtLabelCount)
            End If
        Else
            FocusedField = New FocusedItem(txtLabelCount)
        End If
    End Sub

    Private Sub nbrLabelCount_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            cmdAddToRack.Focus()
        End If
    End Sub

    Private Sub txtLabelCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLabelCount.TextChanged
        If isLoaded Then
            If txtLabelCount.Focused Then
                FocusedField.Position = txtLabelCount.SelectionStart
                FocusedField.SelectionLength = 0
                If wasDeleted Then
                    wasDeleted = False
                End If
            Else
                If Not wasDeleted Then
                    FocusedField.Position += 1
                Else
                    wasDeleted = False
                End If
            End If
        End If
    End Sub

    Private Sub lstLotSuggest_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLotSuggest.VisibleChanged
        If lstLotSuggest.Visible Then
            If Not FocusedField.Name.Equals("txtLotNumber") Then
                lstLotSuggest.Visible = False
            End If
        End If
    End Sub

    Private Sub dtpInventoryDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInventoryDate.Enter
        If FocusedField.isSet() Then
            FocusedField = New FocusedItem()
        End If
        If lstLotSuggest.Visible Then
            lstLotSuggest.Visible = False
        End If
    End Sub

    Private Sub cmdAddToRack_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToRack.Enter
        If FocusedField.isSet() Then
            FocusedField = New FocusedItem()
        End If
        If lstLotSuggest.Visible Then
            lstLotSuggest.Visible = False
        End If
    End Sub

    Private Sub txtBoxPieces_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxPieces.Enter
        If lstLotSuggest.Visible Then
            lstLotSuggest.Visible = False
        End If
        If FocusedField.isSet() Then
            If FocusedField.Name.Equals("txtBoxPieces") Then
                txtBoxCount.SelectionStart = FocusedField.Position
            Else
                txtBoxPieces.SelectAll()
                FocusedField = New FocusedItem(txtBoxPieces)
            End If
        Else
            txtBoxPieces.SelectAll()
            FocusedField = New FocusedItem(txtBoxPieces)
        End If
    End Sub

    Private Sub txtBoxPieces_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBoxPieces.MouseUp
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            If FocusedField.Name.Equals("txtBoxPieces") Then
                FocusedField.Position = txtBoxPieces.SelectionStart
                FocusedField.SelectionLength = txtBoxPieces.SelectionLength
            End If
        End If
    End Sub

    Private Sub txtBoxPieces_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxPieces.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboRackNumber.Focus()
        End If
    End Sub

    Private Sub txtBoxPieces_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxPieces.TextChanged
        If isLoaded Then
            If txtBoxPieces.Focused Then
                FocusedField.Position = txtBoxPieces.SelectionStart
                FocusedField.SelectionLength = 0
                If wasDeleted Then
                    wasDeleted = False
                End If
            Else
                If Not wasDeleted Then
                    FocusedField.Position += 1
                Else
                    wasDeleted = False
                End If
            End If

            cmd = New SqlCommand("SELECT isnull(PieceWeight, 0) FROM LotNumber WHERE LotNumber = @LotNumber", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
            Dim pieceWeight As Double = 0D
            If con.State = ConnectionState.Closed Then con.Open()

            Try
                pieceWeight = cmd.ExecuteScalar()
            Catch ex As System.Exception

            End Try
            con.Close()

            txtBoxWeight.Text = Math.Round(Val(txtBoxPieces.Text) * pieceWeight, 2, MidpointRounding.AwayFromZero).ToString()
            txtTotalWeight.Text = Math.Ceiling(Val(txtBoxWeight.Text) * Val(txtBoxCount.Text)).ToString()
        End If
    End Sub

    Private Sub txtLotNumber_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtLotNumber.PreviewKeyDown
        If e.Modifiers = Keys.Shift AndAlso e.KeyCode = Keys.Oemcomma Then
            barcodeScanner = True
            tmrScanTime.Start()
        End If
    End Sub

    Private Sub txtLotNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLotNumber.KeyPress
        If barcodeScanner Then
            If e.KeyChar = "<"c Then
                e.KeyChar = Nothing
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub tmrScanTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If totalScanTime >= 5 Then
            tmrScanTime.Stop()
            totalScanTime = 0
            barcodeScanner = False
            txtLotNumber.Text = "<" + txtLotNumber.Text
            txtLotNumber.SelectionStart = txtLotNumber.Text.Length
        Else
            totalScanTime += 1
        End If
    End Sub

    Private Sub txtLotNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLotNumber.Leave
        If isLoaded Then
            If barcodeScanner Then
                barcodeScanner = False
            End If
            If txtLotNumber.Text.Length > 5 AndAlso cboRackNumber.Items.Count = 0 Then
                ''checks to see if something was scanned that shouldnt have been
                Select Case txtLotNumber.Text.Substring(0, 1).ToUpper()
                    Case "S"
                        txtLotNumber.Text = txtLotNumber.Text.Substring(1, txtLotNumber.Text.Length - 1)
                        Dim divisionID = LoadLotNumberData()
                        isLoaded = False
                        ShowData()
                        isLoaded = True
                        If Val(txtBoxCount.Text) > 0 Then
                            If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
                                DeterminePartCodeType(divisionID)
                            Else
                                DeterminePartCodeType(EmployeeCompanyCode)
                            End If
                        End If

                    Case "P", "Q", "W", "E", "A"
                        ClearData()
                    Case Else
                        Dim divisionID = LoadLotNumberData()
                        isLoaded = False
                        ShowData()
                        isLoaded = True
                        If Val(txtBoxCount.Text) > 0 Then
                            If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
                                DeterminePartCodeType(divisionID)
                            Else
                                DeterminePartCodeType(EmployeeCompanyCode)
                            End If
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub cboRackNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRackNumber.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub txtBoxCount_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxCount.Leave
        If String.IsNullOrEmpty(txtBoxCount.Text) AndAlso Not String.IsNullOrEmpty(txtLotNumber.Text) Then
            GetPalletBoxCount()
        End If
        If Val(txtBoxCount.Text) <> 0 And Val(txtBoxPieces.Text) <> 0 Then
            If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
                Dim divisionID As String = "TWD"
                cmd = New SqlCommand("SELECT isnull(DivisionID, 'TWD') FROM LotNumber WHERE LotNumber = @LotNumber", con)
                cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd.ExecuteScalar()

                If Not IsDBNull(obj) Then
                    divisionID = Convert.ToString(obj)
                End If
                DeterminePartCodeType(divisionID)
            Else
                DeterminePartCodeType(EmployeeCompanyCode)
            End If
        End If
    End Sub

    Private Sub GetPalletBoxCount()
        cmd = New SqlCommand("SELECT PalletCount FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()
        If Not IsDBNull(obj) AndAlso obj IsNot Nothing Then
            txtBoxCount.Text = obj.ToString()
        End If
    End Sub

    Private Sub txtBoxPieces_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxPieces.Leave
        If String.IsNullOrEmpty(txtBoxPieces.Text) AndAlso Not String.IsNullOrEmpty(txtLotNumber.Text) Then
            GetBoxPieceCount()
        End If
        If Val(txtBoxCount.Text) <> 0 And Val(txtBoxPieces.Text) <> 0 Then
            If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
                Dim divisionID As String = "TWD"
                cmd = New SqlCommand("SELECT isnull(DivisionID, 'TWD') FROM LotNumber WHERE LotNumber = @LotNumber", con)
                cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd.ExecuteScalar()

                If Not IsDBNull(obj) Then
                    divisionID = Convert.ToString(obj)
                End If
                DeterminePartCodeType(divisionID)
            Else
                DeterminePartCodeType(EmployeeCompanyCode)
            End If
        End If
    End Sub

    Private Sub GetBoxPieceCount()
        cmd = New SqlCommand("SELECT BoxCount FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()
        If Not IsDBNull(obj) AndAlso obj IsNot Nothing Then
            txtBoxPieces.Text = obj.ToString()
        End If
    End Sub

    Private Sub lstRackSuggest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRackSuggest.SelectedIndexChanged
        If lstRackSuggest.Focused And lstRackSuggest.SelectedIndex <> -1 Then
            cboRackNumber.Text = lstRackSuggest.SelectedItem.ToString()
            lstRackSuggest.Hide()
            cmdAddToRack.Focus()
        End If
    End Sub

    Private Sub bgwkRackingSuggest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkRackingSuggest.DoWork
        Dim RackData As RackSuggestData = e.Argument
        If RackData.Rack.Length = 2 Then
            Dim DivisionString As String = " DivisionID = '" + EmployeeCompanyCode + "'"
            If EmployeeCompanyCode.Equals("TWD") Or EmployeeCompanyCode.Equals("TFP") Then
                DivisionString = " (DivisionID = 'TWD' OR DivisionID = 'TFP')"
            End If
            Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async=True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
            Dim cmdSugg = New SqlCommand("DECLARE @DivisionID as varchar = (SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber); SELECT PossibleLocations.BinNumber FROM (SELECT * FROM BinNumber WHERE LEFT(BinNumber,2) = @RackPref  AND BinNumber Not IN (SELECT BinNumber FROM RackingTransactionTable WHERE LEFT(BinNumber, 2) = @RackPref AND " + DivisionString + ") AND RackPosition <> 'UNAVAILABLE' AND " + DivisionString + ") as PossibleLocations  LEFT OUTER JOIN (SELECT BinNumber, SUM(RackingWeight) as TotalWeight FROM RackingTransactionTable WHERE DivisionID = @DivisionID AND BinNumber in (SELECT PartnerBinNumber FROM BinNumber WHERE LEFT(BinNumber,2) = @RackPref  AND BinNumber Not IN (SELECT BinNumber FROM RackingTransactionTable WHERE LEFT(BinNumber, 2) = @RackPref AND " + DivisionString + ") AND RackPosition <> 'UNAVAILABLE' AND " + DivisionString + ") GROUP BY BinNumber) as PartnerLocation ON PossibleLocations.PartnerBinNumber = PartnerLocation.BinNumber WHERE isnull(PartnerLocation.TotalWeight,0) + @BarWeightOpen < PossibleLocations.MaxBarWeight", con2)
            cmdSugg.Parameters.Add("@RackPref", SqlDbType.VarChar).Value = RackData.Rack
            cmdSugg.Parameters.Add("@BarWeightOpen", SqlDbType.VarChar).Value = RackData.weight + PalletWeight
            cmdSugg.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RackData.LotNumber

            Dim autoComp As New List(Of String)
            If con2.State = ConnectionState.Closed Then con2.Open()
            Dim reader As SqlDataReader = cmdSugg.ExecuteReader()

            If reader.HasRows Then
                While reader.Read()
                    If Not e.Cancel Then
                        If Not reader.IsDBNull(0) Then
                            Dim test As String = reader.Item(0)
                            autoComp.Add(reader.Item(0))
                        End If
                    Else
                        reader.Close()
                        con2.Close()
                        e.Result = New List(Of String)
                        Exit Sub
                    End If
                End While
            End If
            reader.Close()
            con2.Close()
            e.Result = autoComp
        Else
            Dim i As Integer = 0
            While i < RackData.lst.Count
                If Not RackData.lst(i).StartsWith(RackData.Rack) Then
                    RackData.lst.RemoveAt(i)
                Else
                    i += 1
                End If
            End While
            e.Result = RackData.lst
        End If
    End Sub

    Private Sub bgwkRackingSuggest_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkRackingSuggest.RunWorkerCompleted
        Dim lst As List(Of String) = e.Result
        lstRackSuggest.Items.Clear()
        lstRackSuggest.Items.AddRange(lst.ToArray())
        If Not e.Cancelled Then
            lstRackSuggest.Show()
        End If
    End Sub

    Private Sub cboRackNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRackNumber.Leave, lstRackSuggest.Leave
        If Not lstRackSuggest.Focused Then
            If lstRackSuggest.Visible Then
                lstRackSuggest.Hide()
            End If
        End If
        If TypeOf sender Is System.Windows.Forms.ComboBox Then
            usefulFunctions.CheckBinNumber(sender)
        End If
    End Sub

    Private Sub cmdPrintLotLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLotLines.Click
        If txtShipmentNumber.Text = "" Then
            'Skip Print Form
        Else
            GlobalShipmentNumber = Val(txtShipmentNumber.Text)

            Using NewPrintShipmentBarCodes As New PrintShipmentBarCodes
                Dim Result = NewPrintShipmentBarCodes.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub InventoryPartialPalletRacking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class